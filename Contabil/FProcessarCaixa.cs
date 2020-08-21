using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessarCaixa : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa> lcaixa;
        public List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa> lCaixa
        {
            get
            {
                if (bsCaixa.Count > 0)
                    return (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>).FindAll(p => p.St_processar);
                else return null;
            }
            set { lcaixa = value; }
        }

        public TFProcessarCaixa()
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
            bsCaixa.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_Caixa(cd_empresa.Text,
                                                                                             cd_contager.Text,
                                                                                             string.Empty,
                                                                                             dt_ini.Text,
                                                                                             dt_fin.Text,
                                                                                             st_reprocessar.Checked,
                                                                                             decimal.Zero,
                                                                                             nr_documento.Text,
                                                                                             cd_historico.Text,
                                                                                             contadeb.Text,
                                                                                             contacred.Text,
                                                                                             vl_ini.Value,
                                                                                             vl_fin.Value,
                                                                                             cb_mov.SelectedIndex.Equals(1) ? "'P'" : cb_mov.SelectedIndex.Equals(2) ? "'R'" : string.Empty,
                                                                                             null);
            if (bsCaixa.Count > 0)
            {
                tot_pagar.Text = (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>).Where(p => p.TP_Movimento.Trim().ToUpper().Equals("P")).Sum(p => p.VL_Lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                tot_receber.Text = (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>).Where(p => p.TP_Movimento.Trim().ToUpper().Equals("R")).Sum(p => p.VL_Lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                tot_saldo.Text = (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>).Sum(p => p.TP_Movimento.Trim().ToUpper().Equals("P") ? (-1) * p.VL_Lancto : p.VL_Lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                lblInconsistente.Text = "{" + (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>).Count(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                                              (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                                              p.CD_LoteCTB.HasValue).ToString() +
                                        "} Registros Inconsistentes";
            }
        }

        private void afterConfig()
        {
            using (TFCFGCaixa fCfg = new TFCFGCaixa())
            {
                if (bsCaixa.Current != null)
                {
                    fCfg.pCd_empresa = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_Empresa;
                    fCfg.pNm_empresa = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Nm_empresa;
                    fCfg.pCd_historico = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_Historico;
                    fCfg.pDs_historico = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).DS_Historico;
                    fCfg.pCd_contager = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_ContaGer;
                    fCfg.pDs_contager = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).DS_ContaGer;
                    fCfg.pTp_movimento = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).TP_Movimento;
                    fCfg.pCd_contadeb = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Ds_contadeb;
                    fCfg.pClassifdeb = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Cd_classificacao_deb;
                    fCfg.pCd_contacred = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Ds_contacred;
                    fCfg.pClassifcred = (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Cd_classificacao_cred;
                }
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rCaixa != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGCaixa.Gravar(fCfg.rCaixa, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessarCaixa_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            if (lcaixa != null)
                if (lcaixa.Count > 0)
                    bsCaixa.DataSource = lcaixa;
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

        private void bb_historico_Click(object sender, EventArgs e)
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

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;a.cd_contager|Codigo|60";
            string vParam = "a.st_contacartao|<>|0;a.st_contacf|<>|0";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contager.Text.Trim() + "';" +
                                              "a.st_contacartao|<>|0;a.st_contacf|<>|0",
                new Componentes.EditDefault[] { cd_contager }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void gFinanceiro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsCaixa.Current != null))
            {
                if (!(bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).St_processar)
                {
                    if (!(bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_ContaCre.HasValue ||
                        !(bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_ContaDeb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_Empresa.Trim() + "\r\n" +
                                        "Conta Ger.: " + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_ContaGer.Trim() + "\r\n" +
                                        "Historico: " + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_Historico.Trim() + "\r\n" +
                                        "Tipo Movimento: " + (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).TP_Movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).St_processar = true;
                }
                else
                    (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).St_processar = false;
                bsCaixa.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void cbMarcaCaixa_Click(object sender, EventArgs e)
        {
            if (bsCaixa.Count > 0)
            {
                (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>).Where(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaCaixa.Checked);
                bsCaixa.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            afterConfig();
        }

        private void TFProcessarCaixa_KeyDown(object sender, KeyEventArgs e)
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

        private void alterarLançamentoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsCaixa.Current != null)
                using (Financeiro.TFLanCaixa FLanCaixa = new Financeiro.TFLanCaixa())
                {
                    CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa rCaixa =
                        CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.Busca((bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).CD_ContaGer,
                                                                          (bsCaixa.Current as CamadaDados.Contabil.TRegistro_Lan_ProcCaixa).Id_lanctocaixastr,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          decimal.Zero,
                                                                          decimal.Zero,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          false,
                                                                          string.Empty,
                                                                          decimal.Zero,
                                                                          false,
                                                                          null)[0];
                    FLanCaixa.CD_ContaGer.Enabled = false;
                    FLanCaixa.BB_ContaGer.Enabled = false;
                    FLanCaixa.CD_Empresa.Enabled = false;
                    FLanCaixa.BB_Empresa.Enabled = false;
                    FLanCaixa.DT_Lancto.Enabled = false;
                    FLanCaixa.RB_Pagar.Enabled = false;
                    FLanCaixa.RB_Receber.Enabled = false;
                    FLanCaixa.VL_Receber.Enabled = false;
                    FLanCaixa.VL_Pagar.Enabled = false;
                    FLanCaixa.RB_Receber.Checked = rCaixa.Vl_RECEBER > 0;
                    FLanCaixa.RB_Pagar.Checked = rCaixa.Vl_PAGAR > 0;
                    FLanCaixa.dsLanCaixa.Add(rCaixa);
                    if (FLanCaixa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.AlterarLanCaixa(rCaixa, null);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
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
                if (((bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>)[e.RowIndex].CD_ContaCre !=
                    (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>)[e.RowIndex].Cd_contactb_C ||
                    (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>)[e.RowIndex].CD_ContaDeb !=
                    (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>)[e.RowIndex].Cd_contactb_D) &&
                    (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>)[e.RowIndex].CD_LoteCTB.HasValue)
                    gFinanceiro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else gFinanceiro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void lblInconsistente_Click(object sender, EventArgs e)
        {
            if (bsCaixa.Count > 0)
            {
                List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa> lista =
                    (bsCaixa.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa>).Where(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                    (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                    p.CD_LoteCTB.HasValue).ToList();
                if (lista.Count > 0)
                    bsCaixa.DataSource = lista;
            }
        }

        private void gFinanceiro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFinanceiro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCaixa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_Lan_ProcCaixa());
            CamadaDados.Contabil.TList_ProcCaixa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcCaixa(lP.Find(gFinanceiro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFinanceiro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcCaixa(lP.Find(gFinanceiro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFinanceiro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCaixa.List as CamadaDados.Contabil.TList_ProcCaixa).Sort(lComparer);
            bsCaixa.ResetBindings(false);
            gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void pFiltro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textMovimento_TextChanged(object sender, EventArgs e)
        {

        }

        private void nr_documento_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
