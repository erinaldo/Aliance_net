using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessaNFCe : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe> lfat;
        public List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe> lFat
        {
            get
            {
                if (bsNFCe.Count > 0)
                    return (bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>).FindAll(p => p.St_processar);
                else return null;
            }
            set { lfat = value; }
        }

        public TFProcessaNFCe()
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
            bsNFCe.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_NFCe(cd_empresa.Text,
                                                                                           nr_notafiscal.Text,
                                                                                           string.Empty,
                                                                                           dt_ini.Text,
                                                                                           dt_fin.Text,
                                                                                           st_reprocessar.Checked,
                                                                                           string.Empty,
                                                                                           cd_produto.Text,
                                                                                           cd_cfop.Text,
                                                                                           contadeb.Text,
                                                                                           contacred.Text,
                                                                                           vl_ini.Value,
                                                                                           vl_fin.Value,
                                                                                           null);
            if (bsNFCe.Count > 0)
            {
                tot_receber.Text = (bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>).Sum(p => p.VL_Lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                lblInconsistente.Text = "{" + (bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>).Count(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                                                          (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                                                          p.CD_LoteCTB.HasValue).ToString() +
                                        "} Registros Inconsistentes";
            }
        }

        private void afterConfig()
        {
            using (TFCFGNFCe fCfg = new TFCFGNFCe())
            {
                if (bsNFCe.Current != null)
                {
                    fCfg.pCd_empresa = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).CD_Empresa;
                    fCfg.pNm_empresa = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).Nm_empresa;
                    fCfg.pCd_cfop = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).CD_CFOP;
                    fCfg.pDs_cfop = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).Ds_cfop;
                    fCfg.pCd_produto = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).CD_Produto;
                    fCfg.pDs_produto = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).DS_Produto;
                    fCfg.pCd_contadeb = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).Ds_contadeb;
                    fCfg.pClassifdeb = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).Cd_classificacaodeb;
                    fCfg.pCd_contacred = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).Ds_contacred;
                    fCfg.pClassifcred = (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).Cd_classificacaocred;
                }
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rFat != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGNFCe.Gravar(fCfg.rFat, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessaNFCe_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            if (lfat != null)
                if (lfat.Count > 0)
                    bsNFCe.DataSource = lfat;
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

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
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

        private void cbMarcaFaturamento_Click(object sender, EventArgs e)
        {
            if (bsNFCe.Count > 0)
            {
                (bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>).Where(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaFaturamento.Checked);
                bsNFCe.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void gFaturamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsNFCe.Current != null))
            {
                if (!(bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).St_processar)
                {
                    if (!(bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).CD_ContaCre.HasValue ||
                        !(bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).CD_ContaDeb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).CD_Empresa.Trim() + "\r\n" +
                                        "Movimentação: " + (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).Cd_movimentacao.ToString().Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).St_processar = true;
                }
                else
                    (bsNFCe.Current as CamadaDados.Contabil.TRegistro_Lan_ProcNFCe).St_processar = false;
                bsNFCe.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void gFaturamento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFaturamento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsNFCe.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_Lan_ProcNFCe());
            CamadaDados.Contabil.TList_ProcNFCe lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcNFCe(lP.Find(gFaturamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFaturamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcNFCe(lP.Find(gFaturamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFaturamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsNFCe.List as CamadaDados.Contabil.TList_ProcNFCe).Sort(lComparer);
            bsNFCe.ResetBindings(false);
            gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void lblInconsistente_Click(object sender, EventArgs e)
        {
            if (bsNFCe.Count > 0)
            {
                List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe> lista =
                    (bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>).Where(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                                (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                                p.CD_LoteCTB.HasValue).ToList();
                if (lista.Count > 0)
                    bsNFCe.DataSource = lista;
            }
        }

        private void gFaturamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (((bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>)[e.RowIndex].CD_ContaCre !=
                    (bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>)[e.RowIndex].Cd_contactb_C ||
                    (bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>)[e.RowIndex].CD_ContaDeb !=
                    (bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>)[e.RowIndex].Cd_contactb_D) &&
                    (bsNFCe.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcNFCe>)[e.RowIndex].CD_LoteCTB.HasValue)
                    gFaturamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else gFaturamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void st_reprocessar_CheckedChanged(object sender, EventArgs e)
        {
            cContaCreditada.Visible = st_reprocessar.Checked;
            cContaDebitada.Visible = st_reprocessar.Checked;
        }

        private void TFProcessaNFCe_KeyDown(object sender, KeyEventArgs e)
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

        private void bb_config_Click(object sender, EventArgs e)
        {
            afterConfig();
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

        private void bb_cfop_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_CFOP|CFOP|350;a.CD_CFOP|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cfop },
                                            new CamadaDados.Fiscal.TCD_CadCFOP(), string.Empty);
        }

        private void cd_cfop_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_cfop|=|'" + cd_cfop.Text.Trim() + "'"
            , new Componentes.EditDefault[] { cd_cfop }, new CamadaDados.Fiscal.TCD_CadCFOP());
        }
    }
}
