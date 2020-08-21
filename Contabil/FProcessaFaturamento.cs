using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessaFaturamento : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento> lfat;
        public List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento> lFat
        {
            get
            {
                if (bsFaturamento.Count > 0)
                    return (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>).FindAll(p => p.St_processar);
                else return null;
            }
            set { lfat = value; }
        }

        public TFProcessaFaturamento()
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
            bsFaturamento.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_Faturamento(cd_empresa.Text,
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
            if (bsFaturamento.Count > 0)
            {
                tot_pagar.Text = (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>).Where(p => p.TP_Movimento.Trim().ToUpper().Equals("E")).Sum(p => p.VL_Lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                tot_receber.Text = (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>).Where(p => p.TP_Movimento.Trim().ToUpper().Equals("S")).Sum(p => p.VL_Lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                lblInconsistente.Text = "{" + (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>).Count(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                                                          (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                                                          p.CD_LoteCTB.HasValue).ToString() +
                                        "} Registros Inconsistentes";
            }
        }

        private void afterConfig()
        {
            using (TFCFGFaturamento fCfg = new TFCFGFaturamento())
            {
                if (bsFaturamento.Current != null)
                {
                    fCfg.pCd_empresa = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_Empresa;
                    fCfg.pNm_empresa = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Nm_empresa;
                    fCfg.pCd_movimentacao = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Cd_movtostr;
                    fCfg.pDs_movimentacao = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Ds_movimentacao;
                    fCfg.pCd_clifor = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_Clifor;
                    fCfg.pNm_clifor = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).NM_Clifor;
                    fCfg.pCd_produto = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_Produto;
                    fCfg.pDs_produto = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).DS_Produto;
                    fCfg.pCd_contadeb = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Ds_contadeb;
                    fCfg.pClassifdeb = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Cd_classificacaodeb;
                    fCfg.pCd_contacred = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Ds_contacred;
                    fCfg.pClassifcred = (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Cd_classificacaocred;
                }
                if(fCfg.ShowDialog() == DialogResult.OK)
                    if(fCfg.rFat != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGFaturamento.Gravar(fCfg.rFat, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessaFaturamento_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            if (lfat != null)
                if (lfat.Count > 0)
                    bsFaturamento.DataSource = lfat;
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
            afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFProcessaFaturamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                afterConfig();
        }

        private void cbMarcaFaturamento_Click(object sender, EventArgs e)
        {
            if (bsFaturamento.Count > 0)
            {
                (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>).Where(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaFaturamento.Checked);
                bsFaturamento.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void gFaturamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsFaturamento.Current != null))
            {
                if (!(bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).St_processar)
                {
                    if (!(bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_ContaCre.HasValue ||
                        !(bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_ContaDeb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).CD_Empresa.Trim() + "\r\n" +
                                        "Movimentação: " + (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).Cd_movtostr.Trim() + "\r\n" +
                                        "Tipo Movimento: " + (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).TP_Movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).St_processar = true;
                }
                else
                    (bsFaturamento.Current as CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento).St_processar = false;
                bsFaturamento.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            afterConfig();
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

        private void gFaturamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (((bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>)[e.RowIndex].CD_ContaCre !=
                    (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>)[e.RowIndex].Cd_contactb_C ||
                    (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>)[e.RowIndex].CD_ContaDeb !=
                    (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>)[e.RowIndex].Cd_contactb_D) &&
                    (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>)[e.RowIndex].CD_LoteCTB.HasValue)
                    gFaturamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else gFaturamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void lblInconsistente_Click(object sender, EventArgs e)
        {
            if (bsFaturamento.Count > 0)
            {
                List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento> lista =
                    (bsFaturamento.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento>).Where(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                                (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                                p.CD_LoteCTB.HasValue).ToList();
                if (lista.Count > 0)
                    bsFaturamento.DataSource = lista;
            }
        }

        private void gFaturamento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFaturamento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsFaturamento.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_Lan_ProcFaturamento());
            CamadaDados.Contabil.TList_ProcFaturamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcFaturamento(lP.Find(gFaturamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFaturamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcFaturamento(lP.Find(gFaturamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFaturamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsFaturamento.List as CamadaDados.Contabil.TList_ProcFaturamento).Sort(lComparer);
            bsFaturamento.ResetBindings(false);
            gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
