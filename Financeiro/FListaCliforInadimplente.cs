using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFListaCliforInadimplente : Form
    {
        public bool Altera_Relatorio = false;

        public TFListaCliforInadimplente()
        {
            InitializeComponent();
        }

        private void afterPrint()
        {
            if (bsDadosBloqueio.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsDadosBloqueio;
                    Rel.Nome_Relatorio = "TFListaCliforInadimplente";
                    Rel.Ident = "TFListaCliforInadimplente";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "FIN";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO CLIENTES NEGATIVADOS";

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
                                                    "RELATORIO CLIENTES NEGATIVADOS",
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
                                               "RELATORIO CLIENTES NEGATIVADOS",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void TFListaCliforInadimplente_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];

            bsDadosBloqueio.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_DadosBloqueio().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = string.Empty,
                                                    vVL_Busca = "(isnull(a.ST_Bloq_DebitoVencido, 'N') = 'S' and a.vl_debito_vencto > 0 or " +
                                                                "isnull(a.ST_BLOQCREDITOAVULSO, 'N') = 'S' or " +
                                                                "convert(datetime, floor(convert(decimal(30,10), getdate()))) > " +
                                                                "convert(datetime, floor(convert(decimal(30,10), case when a.diasrenovacaocadastro > 0 then dateadd(day, a.diasrenovacaocadastro, a.dt_renovacaocadastro) else getdate() end))) or " +
                                                                "isnull(a.ST_BloqueioSPC, 'N') = 'S' or " +
                                                                "a.vl_ch_devolvido > 0)"
                                                }
                                            });
        }

        private void gGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gGrid.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsDadosBloqueio.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio());
            CamadaDados.Financeiro.Duplicata.TList_DadosBloqueio lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gGrid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gGrid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Duplicata.TList_DadosBloqueio(lP.Find(gGrid.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gGrid.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Duplicata.TList_DadosBloqueio(lP.Find(gGrid.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gGrid.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsDadosBloqueio.List as CamadaDados.Financeiro.Duplicata.TList_DadosBloqueio).Sort(lComparer);
            bsDadosBloqueio.ResetBindings(false);
            gGrid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFListaCliforInadimplente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Altera_Relatorio = true;
            }
        }
    }
}
