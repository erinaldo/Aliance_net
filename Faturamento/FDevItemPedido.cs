using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Pedido;
using Utils;

namespace Faturamento
{
    public partial class FDevItemPedido : Form
    {
        public decimal? NrPedido { get; set; } = null;

        public FDevItemPedido()
        {
            InitializeComponent();
        }

        private void FDevItemPedido_Load(object sender, EventArgs e)
        {
            if (NrPedido != null)
            {
                edNrPedido.Text = NrPedido.ToString().Trim();
                buscarItens();
            }
            else edNrPedido.Select();
        }

        private void buscarItens()
        {
            if (string.IsNullOrEmpty(edNrPedido.Text.ToString()))
            {
                limparCampos();
                return;
            }

            bsPedidoItem.DataSource = TCN_LanPedido_Item.Busca(string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               edNrPedido.Text.ToString().Trim(),
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               false,
                                                               null);

        }

        private void limparCampos()
        {
            bsPedidoItem.Clear();
            edNrPedido.Clear();
            edNrPedido.Select();
        }

        private void edNrPedido_TextChanged(object sender, EventArgs e)
        {
            bsPedidoItem.Clear();
        }

        private void FDevItemPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                buscarItens();
            else if (e.KeyCode.Equals(Keys.F5))
                inserirQuantidadeDevolver();
        }

        private void inserirQuantidadeDevolver()
        {
            if (txQtdSdFaturar == null || string.IsNullOrEmpty(txQtdSdFaturar.Text))
            {
                MessageBox.Show("O Saldo não foi informado corretamente. Não será possível finalizar a operação.",
                    "Informativo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            else if (qtdDevolver.Value > Convert.ToDecimal(txQtdSdFaturar.Text))
            {
                MessageBox.Show("O Saldo não deve ser maior que o saldo. Não será possível finalizar a operação.",
                    "Informativo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                (bsPedidoItem.Current as TRegistro_LanPedido_Item).Qtd_devolver = Convert.ToDecimal(txQtdSdFaturar.Text);
                return;
            }
            else
            {
                MessageBox.Show("Gravado com sucesso.",
                    "Informativo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                bsPedidoItem.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            buscarItens();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            TList_ItensDevolvidos _ItensDevolvidos = new TList_ItensDevolvidos();
            (bsPedidoItem.List as IEnumerable<TRegistro_LanPedido_Item>).ToList().ForEach(r =>
            {
                if (r.Qtd_devolver > 0)
                    _ItensDevolvidos.Add(new TRegistro_ItensDevolvidos()
                    {
                        Nr_Pedido = Convert.ToDecimal(edNrPedido.Text.ToString().Trim()),
                        CD_Produto = r.Cd_produto,
                        ID_PedidoItem = r.Id_pedidoitem,
                        DT_Devolucao = CamadaDados.UtilData.Data_Servidor(),
                        QTD_Devolvida = r.Qtd_devolver
                    });
            });

            try
            {
                if (_ItensDevolvidos.Count > 0)
                {
                    TCN_ItensDevolvidos.Gravar(_ItensDevolvidos, null);
                    MessageBox.Show("Salvo com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            inserirQuantidadeDevolver();
        }

    }
}
