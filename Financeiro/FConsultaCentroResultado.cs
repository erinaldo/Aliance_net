using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFConsultaCentroResultado : Form
    {
        private bool Altera_Relatorio = false;
        public TFConsultaCentroResultado()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFCCustoLancto fLancto = new TFCCustoLancto())
            {
                if(fLancto.ShowDialog() == DialogResult.OK)
                    if(fLancto.rLancto != null)
                        try
                        {
                            fLancto.rLancto.Tp_registro = "M";
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(fLancto.rLancto, null);
                            MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterExclui()
        {
            if (bsCCustoLan.Current != null)
            {
                if ((bsCCustoLan.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto).Tp_registro.Trim().ToUpper().Equals("M"))
                {
                    if(MessageBox.Show("Confirma exclusão registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(bsCCustoLan.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else MessageBox.Show("Permitido excluir somente lançamento MANUAL.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterBusca()
        {
            bsCCustoLan.DataSource = CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Buscar(string.Empty,
                                                                                                   cd_centroresult.Text,
                                                                                                   CD_Empresa.Text,
                                                                                                   buscarClifor.Text,
                                                                                                   dt_ini.Text,
                                                                                                   dt_fin.Text,
                                                                                                   decimal.Zero,
                                                                                                   null);
            tot_despesa.Value = (bsCCustoLan.List as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("D") && (!p.St_deducaobool)).Sum(p => p.Vl_lancto);
            tot_reducao_despesa.Value = (bsCCustoLan.List as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("D") && p.St_deducaobool).Sum(p => p.Vl_lancto);
            tot_receita.Value = (bsCCustoLan.List as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("R") && (!p.St_deducaobool)).Sum(p => p.Vl_lancto);
            tot_reducao_receita.Value = (bsCCustoLan.List as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Where(p => p.Tp_movimento.Trim().ToUpper().Equals("R") && p.St_deducaobool).Sum(p => p.Vl_lancto);
            resultado.Value = tot_receita.Value - tot_reducao_receita.Value - tot_despesa.Value - tot_reducao_despesa.Value;
        }

        private void ReprocessarCentroResultado()
        {
            using (TFConsultaFinCentroResultado fConsulta = new TFConsultaFinCentroResultado())
            {
                fConsulta.ShowDialog();
                afterBusca();
            }
        }

        public void afterPrint()
        {
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                Rel.DTS_Relatorio = bsCCustoLan;
                Rel.Nome_Relatorio = "TFConsultaCentroResultado";
                Rel.NM_Classe = "TFConsultaCentroResultado";
                Rel.Modulo = "FIN";
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO " + Text.Trim();

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                       fImp.pSt_imprimir,
                                       fImp.pSt_visualizar,
                                       fImp.pSt_enviaremail,
                                       fImp.pSt_exportPdf,
                                       fImp.Path_exportPdf,
                                       fImp.pDestinatarios,
                                       null,
                                       "RELATORIO " + Text.Trim(),
                                       fImp.pDs_mensagem);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           null,
                                           fImp.pDestinatarios,
                                           "RELATORIO " + Text.Trim(),
                                           fImp.pDs_mensagem);
            }
        }

        private void TFConsultaCentroResultado_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            bb_reprocessar.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR CENTRO RESULTADO", null);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa });
        }

        private void bb_centroresult_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResultado fBusca = new FormBusca.TFBuscaCentroResultado())
            {
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                        cd_centroresult.Text = fBusca.Cd_centro;
            }
        }

        private void cd_centroresult_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|'" + cd_centroresult.Text.Trim() + "';" +
                            "isnull(a.st_sintetico, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFConsultaCentroResultado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9) && bb_reprocessar.Visible)
                ReprocessarCentroResultado();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gCCustoLan_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCCustoLan.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCCustoLan.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto());
            CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCCustoLan.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCCustoLan.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto(lP.Find(gCCustoLan.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCCustoLan.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto(lP.Find(gCCustoLan.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCCustoLan.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCCustoLan.List as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Sort(lComparer);
            bsCCustoLan.ResetBindings(false);
            gCCustoLan.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_reprocessar_Click(object sender, EventArgs e)
        {
            ReprocessarCentroResultado();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bbClifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { buscarClifor }, string.Empty);
        }

        private void buscarClifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + buscarClifor.Text.Trim() + "'", new Componentes.EditDefault[] { buscarClifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
    }
}
