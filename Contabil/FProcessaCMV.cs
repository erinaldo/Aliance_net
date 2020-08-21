using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessaCMV : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV> lcmv;
        public List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV> lCMV
        {
            get
            {
                if (bsCMV.Count > 0)
                    return (bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>).FindAll(p => p.St_processar);
                else return null;
            }
            set { lcmv = value; }
        }
        public TFProcessaCMV()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            bsCMV.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_CMV(cd_empresa.Text,
                                                                                         string.Empty,
                                                                                         nr_notafiscal.Text,
                                                                                         string.Empty,
                                                                                         dt_ini.Text,
                                                                                         dt_fin.Text,
                                                                                         st_reprocessar.Checked,
                                                                                         string.Empty,
                                                                                         cd_movimentacao.Text,
                                                                                         string.Empty,
                                                                                         cd_produto.Text,
                                                                                         cd_clifor.Text,
                                                                                         contadeb.Text,
                                                                                         contacred.Text,
                                                                                         vl_ini.Value,
                                                                                         vl_fin.Value,
                                                                                         null);
            if (bsCMV.Count > 0)
            {
                totCmv.Text = (bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>).Sum(p => p.Vl_lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                lblInconsistente.Text = "{" + (bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>).Count(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                                          (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                                          p.CD_LoteCTB.HasValue).ToString() +
                                        "} Registros Inconsistentes";
            }
        }

        private void afterConfig()
        {
            using (TFCFGCMV fCfg = new TFCFGCMV())
            {
                if (bsCMV.Current != null)
                {
                    fCfg.pCd_empresa = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Cd_empresa;
                    fCfg.pNm_empresa = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Nm_empresa;
                    fCfg.pCd_movimentacao = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Cd_movtostr;
                    fCfg.pDs_movimentacao = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Ds_movimentacao;
                    fCfg.pCd_produto = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Cd_produto;
                    fCfg.pDs_produto = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Ds_produto;
                    fCfg.pCd_contadeb = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Ds_contadeb;
                    fCfg.pClassifdeb = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Cd_classificacaodeb;
                    fCfg.pCd_contacred = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Ds_contacred;
                    fCfg.pClassifcred = (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Cd_classificacaocred;
                }
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rCmv != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGCMV.Gravar(fCfg.rCmv, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessaCMV_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            if (lcmv != null)
                if (lcmv.Count > 0)
                    bsCMV.DataSource = lcmv;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_Movimentacao|Movimentação|350;a.CD_Movimentacao|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacao },
                                            new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
        }

        private void cd_movimentacao_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_movimentacao|=|'" + cd_movimentacao.Text.Trim() + "'"
            , new Componentes.EditDefault[] { cd_movimentacao }, new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            this.afterConfig();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cbMarcaFaturamento_Click(object sender, EventArgs e)
        {
            if (bsCMV.Count > 0)
            {
                (bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>).Where(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaFaturamento.Checked);
                bsCMV.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void gCMV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsCMV.Current != null))
            {
                if (!(bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).St_processar)
                {
                    if (!(bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).CD_ContaCre.HasValue ||
                        !(bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).CD_ContaDeb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Cd_empresa.Trim() + "\r\n" +
                                        "Movimentação: " + (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).Cd_movtostr.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).St_processar = true;
                }
                else
                    (bsCMV.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCMV).St_processar = false;
                bsCMV.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void TFProcessaCMV_KeyDown(object sender, KeyEventArgs e)
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

        private void st_reprocessar_CheckedChanged(object sender, EventArgs e)
        {
            cContaCreditada.Visible = st_reprocessar.Checked;
            cContaDebitada.Visible = st_reprocessar.Checked;
        }

        private void gCMV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (((bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>)[e.RowIndex].CD_ContaCre !=
                    (bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>)[e.RowIndex].Cd_contactb_C ||
                    (bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>)[e.RowIndex].CD_ContaDeb !=
                    (bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>)[e.RowIndex].Cd_contactb_D) &&
                    (bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>)[e.RowIndex].CD_LoteCTB.HasValue)
                    gCMV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else gCMV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void lblInconsistente_Click(object sender, EventArgs e)
        {
            if (bsCMV.Count > 0)
            {
                List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV> lista =
                    (bsCMV.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCMV>).Where(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                p.CD_LoteCTB.HasValue).ToList();
                if (lista.Count > 0)
                    bsCMV.DataSource = lista;
            }
        }

        private void gCMV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCMV.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCMV.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_Lan_ProcCMV());
            CamadaDados.Contabil.TList_ProcCMV lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCMV.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCMV.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcCMV(lP.Find(gCMV.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCMV.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcCMV(lP.Find(gCMV.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCMV.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCMV.List as CamadaDados.Contabil.TList_ProcCMV).Sort(lComparer);
            bsCMV.ResetBindings(false);
            gCMV.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
