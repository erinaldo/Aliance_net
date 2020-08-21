using System.Text;
using System.Windows.Forms;
using FormBusca;
using Querys;
using Querys.Financeiro;
using Utils;
using Querys.Estoque;
using CamadaDados.Compra.Lancamento;
using CamadaNegocio.Compra.Lancamento;
using CamadaNegocio.Compra;
using CamadaDados.Compra;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Compra
{
    public partial class TFLanPrecoCotacaoItem : FormCadPadrao.FFormCadPadrao
    {
        private List<int> controleGridGrava = new List<int>();

        public TFLanPrecoCotacaoItem()
        {
            InitializeComponent();
            DTS = BS_Cotacao_Item;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override int buscarRegistros()
        {
            if ((CD_Cotacao.Text.Trim().Length > 0))
            {
                TList_LanCotacao_Item lista = TCN_LanCotacao_Item.Busca(Convert.ToDecimal(CD_Cotacao.Text), 
                                                                        "", 
                                                                        0M, "NG");
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        this.Lista = lista;
                        BS_Cotacao_Item.DataSource = lista;
                    }
                    else
                    {
                        BS_Cotacao_Item.Clear();
                    }

                    return lista.Count;
                }
            }
            else
            {
                MessageBox.Show("Atenção, é necessário informar a cotação para efetuar a busca!");
                CD_Cotacao.Focus();
            }

            return 0;
        }

        public override string gravarRegistro()
        {
            try
            {
                grid_CotacaoItem.Focus();
                if (controleGridGrava != null)
                {
                    TList_LanCotacao_Item LanCotacao_Item = new TList_LanCotacao_Item();
                    foreach (int i in controleGridGrava)
                    {
                            LanCotacao_Item.Add(grid_CotacaoItem.Rows[i].DataBoundItem as TRegistro_LanCotacao_Item);
                    }

                    if (LanCotacao_Item.Count > 0)
                    {
                        TCN_LanCotacao_Item.Grava_LanCotacao_Item(LanCotacao_Item);
                    }
                }
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            
            return "1";
        }

        public override void afterBusca()
        {
            if (CD_Cotacao.Text.Trim() != "")
            {
                base.afterBusca();
                if (grid_CotacaoItem.CurrentCell == null)
                {
                    this.modoBotoes(TTpModo.tm_Standby, true, false, false, false, false, true, false);
                }
            }
            else
            {

                MessageBox.Show("Atenção, é necessário informar a cotação", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                afterNovo();
            }
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                base.afterNovo();
                grid_CotacaoItem.ReadOnly = false;

            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            grid_CotacaoItem.ReadOnly = true;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            grid_CotacaoItem.ReadOnly = false;
        }

        private void bb_Cotacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ID_Cotacao|Cód. Cotação|100;" +
                              "a.NM_Vendedor|Vendedor|350;" +
                              "a.cd_clifor|Cód. Clifor|100;" +
                              "b.nm_clifor|Nome Clifor|350;" +
                              "a.NM_Contato|Contato|350";

            string vParam = "e.st_requisicao |=|'NG'";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Cotacao, CD_Clifor, NM_Clifor, NM_Contato },
                                    new TCD_LanCotacao(), vParam);
            if (!CD_Cotacao.Text.Equals(""))
                buscarRegistros();
        }

        private void CD_Cotacao_Leave(object sender, System.EventArgs e)
        {
            string vColunas = "a.ID_Cotacao |=|'" + CD_Cotacao.Text + "';e.st_requisicao |=|'NG'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Cotacao, CD_Clifor, NM_Clifor, NM_Contato },
                                    new TCD_LanCotacao());
            if (!CD_Cotacao.Text.Equals(""))
                buscarRegistros();
        }

        private void grid_CotacaoItem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (grid_CotacaoItem.Columns[e.ColumnIndex].Name == "qtdAtendidaColumn"
                || grid_CotacaoItem.Columns[e.ColumnIndex].Name == "vlUnitarioNegociadoColumn"
                || grid_CotacaoItem.Columns[e.ColumnIndex].Name == "vlUnitarioCotadoColumn"
                || grid_CotacaoItem.Columns[e.ColumnIndex].Name == "dsMarcaColumn"
                || grid_CotacaoItem.Columns[e.ColumnIndex].Name == "dtPrazoEntregaColumn"
                || (vTP_Modo != TTpModo.tm_Insert))
            {
                adicionaControleGrid(e.RowIndex);
            }
            else
            {
                e.Cancel = true;
            }
        }

        public void adicionaControleGrid(int linhaGrid)
        {
            if (controleGridGrava != null)
            {
                if (!controleGridGrava.Contains(linhaGrid))
                {
                    controleGridGrava.Add(linhaGrid);
                }
            }
        }

        private void grid_CotacaoItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (BS_Cotacao_Item != null))
            {
                if (e.ColumnIndex >= 5 && e.ColumnIndex <= 9)
                {
                    DataGridViewCell Celula = grid_CotacaoItem.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    Celula.Style.ForeColor = Color.Blue;
                }
            }
        }
    }
}
