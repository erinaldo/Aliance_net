using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessaCheque : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado> lch;
        public List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado> lCh
        {
            get
            {
                if (bsCheque.Count > 0)
                    return (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>).FindAll(p => p.St_processar);
                else return null;
            }
            set { lch = value; }
        }

        public TFProcessaCheque()
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
            bsCheque.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_ChequeCompensado(cd_empresa.Text,
                                                                                                         dt_ini.Text,
                                                                                                         dt_fin.Text,
                                                                                                         st_reprocessar.Checked,
                                                                                                         decimal.Zero,
                                                                                                         cd_contagerorig.Text,
                                                                                                         cd_contagerdest.Text,
                                                                                                         string.Empty,
                                                                                                         decimal.Zero,
                                                                                                         nr_documento.Text,
                                                                                                         contadeb.Text,
                                                                                                         contacred.Text,
                                                                                                         vl_ini.Value,
                                                                                                         vl_fin.Value,
                                                                                                         null);
            if (bsCheque.Count > 0)
            {
                tot_ch.Text = (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>).Sum(p => p.VL_Lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                lblInconsistente.Text = "{" + (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>).Count(p => ((p.Cd_contadeb != p.Cd_contactb_D) ||
                                                                                                                                          (p.Cd_contacred != p.Cd_contactb_C)) &&
                                                                                                                                          p.Cd_lotectb.HasValue).ToString() +
                                        "} Registros Inconsistentes";
            }
        }

        private void afterConfig()
        {
            using (TFCFGChequeComp fCfg = new TFCFGChequeComp())
            {
                if (bsCheque.Current != null)
                {
                    fCfg.pCd_empresa = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_Empresa;
                    fCfg.pNm_empresa = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Nm_empresa;
                    fCfg.pCd_contagerorig = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_ContaGerOrig;
                    fCfg.pDs_contagerorig = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).DS_ContaGerOrig;
                    fCfg.pCd_contagerdest = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_ContaGerDest;
                    fCfg.pDs_contagerdest = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).DS_ContaGerDest;
                    fCfg.pTp_movimento = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).TP_Movimento;
                    fCfg.pCd_contadeb = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Ds_contadeb;
                    fCfg.pCd_classificacaodeb = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_classificacao_deb;
                    fCfg.pCd_contacred = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_contacredstr;
                    fCfg.pDs_contacred = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Ds_contacred;
                    fCfg.pCd_classificacaocred = (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_classificacao_cred;
                }
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rCheque != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGChequeCompensado.Gravar(fCfg.rCheque , null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessaCheque_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            if (lch != null)
                if (lch.Count > 0)
                    bsCheque.DataSource = lch;
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

        private void bb_contagerorig_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;a.cd_contager|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contagerorig },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contagerorig_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contagerorig.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contagerorig }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_contagerdest_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;a.cd_contager|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contagerdest },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contagerdest_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contagerdest.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contagerdest }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void gFinanceiro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsCheque.Current != null))
            {
                if (!(bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).St_processar)
                {
                    if (!(bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_contacred.HasValue ||
                        !(bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).Cd_contadeb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_Empresa.Trim() + "\r\n" +
                                        "Conta Ger. Orig.: " + (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_ContaGerOrig.Trim() + "\r\n" +
                                        "Conta Ger. Dest.: " + (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).CD_ContaGerDest.Trim() + "\r\n" +
                                        "Tipo Movimento: " + (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).TP_Movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).St_processar = true;
                }
                else
                    (bsCheque.Current as CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado).St_processar = false;
                bsCheque.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>).Count(p=> p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void cbMarcaCheque_Click(object sender, EventArgs e)
        {
            if (bsCheque.Count > 0)
            {
                (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>).Where(p => p.Cd_contacred.HasValue && p.Cd_contadeb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaCheque.Checked);
                bsCheque.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>).Count(p=> p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            this.afterConfig();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFProcessaCheque_KeyDown(object sender, KeyEventArgs e)
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

        private void gFinanceiro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (((bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>)[e.RowIndex].Cd_contacred !=
                    (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>)[e.RowIndex].Cd_contactb_C ||
                    (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>)[e.RowIndex].Cd_contadeb !=
                    (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>)[e.RowIndex].Cd_contactb_D) &&
                    (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>)[e.RowIndex].Cd_lotectb.HasValue)
                    gFinanceiro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else gFinanceiro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void lblInconsistente_Click(object sender, EventArgs e)
        {
            if (bsCheque.Count > 0)
            {
                List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado> lista =
                    (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>).Where(p => ((p.Cd_contadeb != p.Cd_contactb_D) ||
                                                                                                                (p.Cd_contacred != p.Cd_contactb_C)) &&
                                                                                                                p.Cd_lotectb.HasValue).ToList();
                if (lista.Count > 0)
                    bsCheque.DataSource = lista;
            }
        }

        private void gFinanceiro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFinanceiro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCheque.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado());
            CamadaDados.Contabil.TList_ProcChequeCompensado lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcChequeCompensado(lP.Find(gFinanceiro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFinanceiro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcChequeCompensado(lP.Find(gFinanceiro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFinanceiro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCheque.List as List<CamadaDados.Contabil.TRegistro_Lan_ProcChequeCompensado>).Sort(lComparer);
            bsCheque.ResetBindings(false);
            gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }        
    }
}
