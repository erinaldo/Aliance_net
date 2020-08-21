using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessaCartao : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_ProcCartao_DC> lccd;
        public List<CamadaDados.Contabil.TRegistro_ProcCartao_DC> lCcd
        {
            get
            {
                if (bsCartao.Count > 0)
                    return (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>).FindAll(p => p.St_processar);
                else return null;
            }
            set { lccd = value; }
        }
        public TFProcessaCartao()
        {
            InitializeComponent();
            ArrayList cbx = new ArrayList();
            cbx.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx.Add(new Utils.TDataCombo("CRÉDITO", "C"));
            cbx.Add(new Utils.TDataCombo("DÉBITO", "D"));
            tp_cartao.DataSource = cbx;
            tp_cartao.DisplayMember = "Display";
            tp_cartao.ValueMember = "Value";
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            bsCartao.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_CartaoDC(cd_empresa.Text,
                                                                                                 dt_ini.Text,
                                                                                                 dt_fin.Text,
                                                                                                 st_reprocessar.Checked,
                                                                                                 decimal.Zero,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 id_fatura.Text,
                                                                                                 contadeb.Text,
                                                                                                 contacred.Text,
                                                                                                 tp_cartao.SelectedValue != null ? tp_cartao.SelectedValue.ToString() : string.Empty,
                                                                                                 id_bandeira.Text,
                                                                                                 vl_ini.Value,
                                                                                                 vl_fin.Value,
                                                                                                 null);
            if (bsCartao.Count > 0)
            {
                tot_ch.Text = (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>).Sum(p => p.VL_Lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                lblInconsistente.Text = "{" + (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>).Count(p => ((p.Cd_contadeb != p.Cd_contactb_D) ||
                                                                                                                                (p.Cd_contacred != p.Cd_contactb_C)) &&
                                                                                                                                p.Cd_lotectb.HasValue).ToString() +
                                        "} Registros Inconsistentes";
            }
        }

        private void afterConfig()
        {
            using (TFCFGCartao_DC fCfg = new TFCFGCartao_DC())
            {
                if (bsCartao.Current != null)
                {
                    fCfg.pCd_empresa = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).CD_Empresa;
                    fCfg.pNm_empresa = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).Nm_empresa;
                    fCfg.pCd_contagerorig = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).CD_ContaGerOrig;
                    fCfg.pDs_contagerorig = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).DS_ContaGerOrig;
                    fCfg.pCd_contagerdest = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).CD_ContaGerDest;
                    fCfg.pDs_contagerdest = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).DS_ContaGerDest;
                    fCfg.pTp_movimento = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).TP_Movimento;
                    fCfg.pCd_contadeb = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).Ds_contadeb;
                    fCfg.pCd_classificacaodeb = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).Cd_classificacao_deb;
                    fCfg.pCd_contacred = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).Cd_contacredstr;
                    fCfg.pDs_contacred = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).Ds_contacred;
                    fCfg.pCd_classificacaocred = (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).Cd_classificacao_cred;
                }
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rCartao != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGCartao_DC.Gravar(fCfg.rCartao, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessaCartao_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            if (lccd != null)
                if (lccd.Count > 0)
                    bsCartao.DataSource = lccd;
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
        
        private void gFinanceiro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsCartao.Current != null))
            {
                if (!(bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).St_processar)
                {
                    if (!(bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).Cd_contacred.HasValue ||
                        !(bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).Cd_contadeb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).CD_Empresa.Trim() + "\r\n" +
                                        "Conta Ger. Orig.: " + (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).CD_ContaGerOrig.Trim() + "\r\n" +
                                        "Conta Ger. Dest.: " + (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).CD_ContaGerDest.Trim() + "\r\n" +
                                        "Tipo Movimento: " + (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).TP_Movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).St_processar = true;
                }
                else
                    (bsCartao.Current as CamadaDados.Contabil.TRegistro_ProcCartao_DC).St_processar = false;
                bsCartao.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void cbMarcaCartao_Click(object sender, EventArgs e)
        {
            if (bsCartao.Count > 0)
            {
                (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>).Where(p => p.Cd_contacred.HasValue && p.Cd_contadeb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaCartao.Checked);
                bsCartao.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
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

        private void TFProcessaCartao_KeyDown(object sender, KeyEventArgs e)
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

        private void gFinanceiro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (((bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>)[e.RowIndex].Cd_contacred !=
                    (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>)[e.RowIndex].Cd_contactb_C ||
                    (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>)[e.RowIndex].Cd_contadeb !=
                    (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>)[e.RowIndex].Cd_contactb_D) &&
                    (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>)[e.RowIndex].Cd_lotectb.HasValue)
                    gFinanceiro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else gFinanceiro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void lblInconsistente_Click(object sender, EventArgs e)
        {
            if (bsCartao.Count > 0)
            {
                List<CamadaDados.Contabil.TRegistro_ProcCartao_DC> lista =
                    (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>).Where(p => ((p.Cd_contadeb != p.Cd_contactb_D) ||
                                                                                                      (p.Cd_contacred != p.Cd_contactb_C)) &&
                                                                                                      p.Cd_lotectb.HasValue).ToList();
                if (lista.Count > 0)
                    bsCartao.DataSource = lista;
            }
        }

        private void gFinanceiro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFinanceiro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCartao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_ProcCartao_DC());
            CamadaDados.Contabil.TList_ProcCartao_DC lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcCartao_DC(lP.Find(gFinanceiro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFinanceiro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcCartao_DC(lP.Find(gFinanceiro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFinanceiro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCartao.List as List<CamadaDados.Contabil.TRegistro_ProcCartao_DC>).Sort(lComparer);
            bsCartao.ResetBindings(false);
            gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_bandeira_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_bandeira|Bandeira|150;a.id_bandeira|Código|50",
                new Componentes.EditDefault[] { id_bandeira }, new CamadaDados.Financeiro.Cadastros.TCD_Cad_BandeiraCartao(), string.Empty);
        }

        private void id_bandeira_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.id_bandeira|=|" + id_bandeira.Text,
                new Componentes.EditDefault[] { id_bandeira }, new CamadaDados.Financeiro.Cadastros.TCD_Cad_BandeiraCartao());
        }
    }
}
