using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFProcessarAdto : Form
    {
        public string pCd_empresa
        { get; set; }
        private List<CamadaDados.Contabil.TRegistro_ProcAdiantamento> ladto;
        public List<CamadaDados.Contabil.TRegistro_ProcAdiantamento> lAdto
        {
            get
            {
                if (bsAdto.Count > 0)
                    return (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>).FindAll(p => p.St_processar);
                else return null;
            }
            set { ladto = value; }
        }

        public TFProcessarAdto()
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
            bsAdto.DataSource = CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscarProc_Adiantamento(cd_empresa.Text,
                                                                                                    cd_contager.Text,
                                                                                                    string.Empty,
                                                                                                    cd_historico.Text,
                                                                                                    cd_clifor.Text,
                                                                                                    dt_ini.Text,
                                                                                                    dt_fin.Text,
                                                                                                    contadeb.Text,
                                                                                                    contacred.Text,
                                                                                                    decimal.Zero,
                                                                                                    vl_ini.Value,
                                                                                                    vl_fin.Value,
                                                                                                    st_reprocessar.Checked,
                                                                                                    null);
            if (bsAdto.Count > 0)
            {
                tot_concedido.Text = (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("C") && p.Tp_movcaixa.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                tot_recebido.Text = (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("R") && p.Tp_movcaixa.Trim().ToUpper().Equals("R")).Sum(p => p.Vl_lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                tot_devconcedido.Text = (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("C") && p.Tp_movcaixa.Trim().ToUpper().Equals("R")).Sum(p => p.Vl_lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                tot_devrecebido.Text = (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("R") && p.Tp_movcaixa.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_lancto).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                lblInconsistente.Text = "{" + (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>).Count(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                                                (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                                                p.Id_loteCTB.HasValue).ToString() +
                                        "} Registros Inconsistentes";
            }
        }

        private void afterConfig()
        {
            using (TFCFGAdiantamento fCfg = new TFCFGAdiantamento())
            {
                if (bsAdto.Current != null)
                {
                    fCfg.pCd_empresa = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Cd_empresa;
                    fCfg.pNm_empresa = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Nm_empresa;
                    fCfg.pCd_historico = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Cd_historico;
                    fCfg.pDs_historico = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Ds_historico;
                    fCfg.pCd_contager = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Cd_contager;
                    fCfg.pDs_contager = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Ds_contager;
                    fCfg.pTp_movimento = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Tp_movimento;
                    fCfg.pCd_clifor = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Cd_clifor;
                    fCfg.pNm_clifor = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Nm_clifor;

                    fCfg.pCd_contadeb = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Cd_contadebstr;
                    fCfg.pDs_contadeb = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Ds_contadeb;
                    fCfg.pClassifdeb = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Cd_classificacao_deb;
                    fCfg.pCd_contacred = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Cd_contacrestr;
                    fCfg.pDs_contacred = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Ds_contacred;
                    fCfg.pClassifcred = (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Cd_classificacao_cred;
                }
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rAdto != null)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGAdiantamento.Gravar(fCfg.rAdto, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFProcessarAdto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            if (ladto != null)
                if (ladto.Count > 0)
                    bsAdto.DataSource = ladto;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
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
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contager.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contager }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
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

        private void TFProcessarAdto_KeyDown(object sender, KeyEventArgs e)
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

        private void cbMarcaCaixa_Click(object sender, EventArgs e)
        {
            if (bsAdto.Count > 0)
            {
                (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>).Where(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue).ToList().ForEach(p =>
                        p.St_processar = cbMarcaCaixa.Checked);
                bsAdto.ResetBindings(true);
                lblSelecionados.Text = "{" + (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void gAdto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsAdto.Current != null))
            {
                if (!(bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).St_processar)
                {
                    if (!(bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).CD_ContaCre.HasValue ||
                        !(bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).CD_ContaDeb.HasValue)
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Cd_empresa.Trim() + "\r\n" +
                                        "Conta Ger.: " + (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Cd_contager.Trim() + "\r\n" +
                                        "Historico: " + (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Cd_historico.Trim() + "\r\n" +
                                        "Tipo Movimento: " + (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).Tp_movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).St_processar = true;
                }
                else
                    (bsAdto.Current as CamadaDados.Contabil.TRegistro_ProcAdiantamento).St_processar = false;
                bsAdto.ResetCurrentItem();
                lblSelecionados.Text = "{" + (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>).Count(p => p.St_processar).ToString() + "} Registros Selecionados";
            }
        }

        private void st_reprocessar_CheckedChanged(object sender, EventArgs e)
        {
            cContaCreditada.Visible = st_reprocessar.Checked;
            cContaDebitada.Visible = st_reprocessar.Checked;
        }

        private void gAdto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (((bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>)[e.RowIndex].CD_ContaCre !=
                    (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>)[e.RowIndex].Cd_contactb_C ||
                    (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>)[e.RowIndex].CD_ContaDeb !=
                    (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>)[e.RowIndex].Cd_contactb_D) &&
                    (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>)[e.RowIndex].Id_loteCTB.HasValue)
                    gAdto.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else gAdto.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void lblInconsistente_Click(object sender, EventArgs e)
        {
            if (bsAdto.Count > 0)
            {
                List<CamadaDados.Contabil.TRegistro_ProcAdiantamento> lista =
                    (bsAdto.List as List<CamadaDados.Contabil.TRegistro_ProcAdiantamento>).Where(p => ((p.CD_ContaDeb != p.Cd_contactb_D) ||
                                                                                                      (p.CD_ContaCre != p.Cd_contactb_C)) &&
                                                                                                      p.Id_loteCTB.HasValue).ToList();
                if (lista.Count > 0)
                    bsAdto.DataSource = lista;
            }
        }

        private void gAdto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gAdto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAdto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_ProcAdiantamento());
            CamadaDados.Contabil.TList_ProcAdiantamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gAdto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gAdto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_ProcAdiantamento(lP.Find(gAdto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gAdto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_ProcAdiantamento(lP.Find(gAdto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gAdto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAdto.List as CamadaDados.Contabil.TList_ProcAdiantamento).Sort(lComparer);
            bsAdto.ResetBindings(false);
            gAdto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
