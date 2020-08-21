using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.PostoCombustivel;
using CamadaNegocio.PostoCombustivel;

namespace PostoCombustivel
{
    public partial class TFLanCartaFrete : Form
    {
        private bool Altera_Relatorio = false;
        public TFLanCartaFrete()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_cartafrete.Clear();
            cd_empresa.Clear();
            nr_cartafrete.Clear();
            cd_transportadora.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            bsCartaFrete.DataSource = TCN_CartaFrete.Buscar(cd_empresa.Text,
                                                            id_cartafrete.Text,
                                                            cd_transportadora.Text,
                                                            string.Empty,
                                                            nr_cartafrete.Text,
                                                            rbEmissao.Checked ? "E" : rbVencimento.Checked ? "V" : string.Empty,
                                                            dt_ini.Text,
                                                            dt_fin.Text,
                                                            string.Empty,
                                                            null);
            vl_total.Value = (bsCartaFrete.List as TList_CartaFrete).Sum(p => p.Vl_documento);
        }

        private void afterPrint()
        {
            if (bsCartaFrete.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsCartaFrete;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = "POC";
                    Rel.Ident = Name;
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO CARTA FRETE";

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
                                           "RELATORIO CARTA FRETE",
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
                                               fImp.pDestinatarios,
                                               null,
                                               "RELATORIO CARTA FRETE",
                                               fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void TFLanCartaFrete_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
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

        private void bb_transportadora_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_transportadora }, "isnull(a.st_transportadora, 'N')|=|'S'");
        }

        private void cd_transportadora_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "';" +
                "isnull(a.st_transportadora, 'N')|=|'S'", new Componentes.EditDefault[] { cd_transportadora },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanCartaFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F7))
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void gCartaFrete_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCartaFrete.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCartaFrete.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CartaFrete());
            TList_CartaFrete lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCartaFrete.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCartaFrete.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CartaFrete(lP.Find(gCartaFrete.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCartaFrete.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CartaFrete(lP.Find(gCartaFrete.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCartaFrete.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCartaFrete.List as TList_CartaFrete).Sort(lComparer);
            bsCartaFrete.ResetBindings(false);
            gCartaFrete.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
