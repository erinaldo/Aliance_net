using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessaFinanceiro : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro> lfin;
        public List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro> lFin
        {
            get
            {
                if (bsFinanceiro.Count > 0)
                    return (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>).FindAll(p => p.St_processar);
                else return null;
            }
            set { lfin = value; }
        }

        public TFProcessaFinanceiro()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            bsFinanceiro.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_Financeiro(cd_empresa.Text,
                                                                                                       string.Empty,
                                                                                                       dt_ini.Text,
                                                                                                       dt_fin.Text,
                                                                                                       nr_documento.Text,
                                                                                                       cd_clifor.Text,
                                                                                                       cd_historico.Text,
                                                                                                       decimal.Zero,
                                                                                                       st_reprocessar.Checked,
                                                                                                       tp_duplicata.Text,
                                                                                                       contadeb.Text,
                                                                                                       contacred.Text,
                                                                                                       vl_ini.Value,
                                                                                                       vl_fin.Value,
                                                                                                       null);
            if (bsFinanceiro.Count > 0)
            {
                tot_pagar.Text = (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>).Where(p => p.Tp_movduplicata.Trim().ToUpper().Equals("P")).Sum(p => p.VL_Lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                tot_receber.Text = (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>).Where(p => p.Tp_movduplicata.Trim().ToUpper().Equals("R")).Sum(p => p.VL_Lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                lblInconsistente.Text = "{" + (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>).Count(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                                                        (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                                                        p.CD_LoteCTB.HasValue).ToString() +
                                        "} Registros Inconsistentes";
            }
        }

        private void afterConfig()
        {
            using (TFCFGFinanceiro fCfg = new TFCFGFinanceiro())
            {
                if (bsFinanceiro.Current != null)
                {
                    fCfg.pCd_empresa = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_Empresa;
                    fCfg.pNm_empresa = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Nm_empresa;
                    fCfg.pCd_historico = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_Historico;
                    fCfg.pDs_historico = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).DS_Historico;
                    fCfg.pTp_movhistorico = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Tp_movhistorico;
                    fCfg.pCd_clifor = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_Clifor;
                    fCfg.pNm_clifor = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).NM_Clifor;
                    fCfg.pTp_duplicata = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).TP_Duplicata;
                    fCfg.pDs_tpduplicata = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Ds_tpduplicata;
                    fCfg.pTp_movduplicata = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Tp_movduplicata;
                    fCfg.pCd_contadeb = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Ds_contadeb;
                    fCfg.pClassifdeb = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Cd_classificacaodeb;
                    fCfg.pCd_contacred = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Ds_contacre;
                    fCfg.pClassifcred = (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Cd_classificacaocre;
                }
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rFin != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGFinanceiro.Gravar(fCfg.rFin, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessaFinanceiro_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            if (lfin != null)
                if (lfin.Count > 0)
                    bsFinanceiro.DataSource = lfin;
        }

        private void gFinanceiro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsFinanceiro.Current != null))
            {
                if (!(bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).St_processar)
                {
                    if (!(bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_ContaCre.HasValue ||
                        !(bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_ContaDeb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_Empresa.Trim() + "\r\n" +
                                        "TP. Duplicata: " + (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).TP_Duplicata.Trim() + "\r\n" +
                                        "Historico: " + (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_Historico.Trim() + "\r\n" +
                                        "Tipo Movimento: " + (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).TP_Movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).St_processar = true;
                }
                else
                    (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).St_processar = false;
                bsFinanceiro.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void cbMarcaFin_Click(object sender, EventArgs e)
        {
            if (bsFinanceiro.Count > 0)
            {
                (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>).Where(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaFin.Checked);
                bsFinanceiro.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            this.afterConfig();
        }

        private void TFProcessaFinanceiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.afterConfig();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico|200;a.cd_historico|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico },
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), string.Empty);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_historico|=|'" + cd_historico.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_historico }, new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim(),
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaTpDuplicata(new Componentes.EditDefault[] { tp_duplicata }, string.Empty);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveTpDuplicata("a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "'",
                new Componentes.EditDefault[] { tp_duplicata });
        }

        private void bb_contadeb_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                            FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
                contadeb.Text = rConta.Cd_conta_ctbstr;
        }

        private void contadeb_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + contadeb.Text + "';isnull(a.st_Registro, 'A')|<>|'C';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { contadeb }, new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_contacred_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                            FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
                contacred.Text = rConta.Cd_conta_ctbstr;
        }

        private void contacred_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + contacred.Text + "';isnull(a.st_Registro, 'A')|<>|'C';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { contacred }, new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void alterarHistoricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsFinanceiro.Current != null)
            {
                string vColunas = "a.ds_historico|Historico Financeiro|200;" +
                                  "a.cd_historico|Código|60";
                DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null,
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(),
                                    "a.tp_mov|=|'" + (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Tp_movduplicata.Trim() + "'");
                if(linha != null)
                    try
                    {
                        new CamadaDados.TDataQuery().executarSql("update tb_fin_duplicata set cd_historico = '" + linha["cd_historico"].ToString().Trim() + "' " +
                                                                 "where cd_empresa = '" + (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).CD_Empresa.Trim() + "' " +
                                                                 "and nr_lancto = " + (bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro).Nr_lanctostr, null);
                        MessageBox.Show("Historico alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro alterar historico duplicata: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void st_reprocessar_CheckedChanged(object sender, EventArgs e)
        {
            cContaCreditada.Visible = st_reprocessar.Checked;
            cContaDebitada.Visible = st_reprocessar.Checked;
        }

        private void gFinanceiro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (((bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>)[e.RowIndex].CD_ContaCre !=
                    (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>)[e.RowIndex].Cd_contactb_C ||
                    (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>)[e.RowIndex].CD_ContaDeb !=
                    (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>)[e.RowIndex].Cd_contactb_D) &&
                    (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>)[e.RowIndex].CD_LoteCTB.HasValue)
                    gFinanceiro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else gFinanceiro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void lblInconsistente_Click(object sender, EventArgs e)
        {
            if (bsFinanceiro.Count > 0)
            {
                List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro> lista =
                    (bsFinanceiro.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro>).Where(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                              (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                              p.CD_LoteCTB.HasValue).ToList();
                if (lista.Count > 0)
                    bsFinanceiro.DataSource = lista;
            }
        }

        private void gFinanceiro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFinanceiro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsFinanceiro.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro());
            CamadaDados.Contabil.TList_ProcFinanceiro lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcFinanceiro(lP.Find(gFinanceiro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFinanceiro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcFinanceiro(lP.Find(gFinanceiro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFinanceiro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsFinanceiro.List as CamadaDados.Contabil.TList_ProcFinanceiro).Sort(lComparer);
            bsFinanceiro.ResetBindings(false);
            gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
