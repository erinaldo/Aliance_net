using CamadaDados.Estoque.Cadastros;
using CamadaDados.Faturamento.Pedido;
using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFFichaTecItemPed : Form
    {
        private TRegistro_LanPedido_Item ritem;
        public TRegistro_LanPedido_Item rItem
        {
            get
            {
                return BS_Itens_Pedido.Current as TRegistro_LanPedido_Item;
            }
            set { ritem = value; }
        }
        public TFFichaTecItemPed()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            if (bsFichaTec.Count > 0)
            {
                if ((BS_Itens_Pedido.Current as TRegistro_LanPedido_Item).lFichaTec.Exists(p=> string.IsNullOrEmpty(p.Cd_item)))
                {
                    MessageBox.Show("Ainda existe item sem cadastro na ficha técnica!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void BuscarProduto()
        {
            TRegistro_CadProduto rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               null,
                                               null);
            if (rProd == null)
            {
                MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                (bsFichaTec.Current as TRegistro_FichaTecItemPed).Cd_item = rProd.CD_Produto;
                (bsFichaTec.Current as TRegistro_FichaTecItemPed).Ds_item = rProd.DS_Produto;
                bsFichaTec.ResetCurrentItem();
            }
        }

        private void TFFichaTecItemPed_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            BS_Itens_Pedido.DataSource = new TList_RegLanPedido_Item() { ritem };
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_incluirProduto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((bsFichaTec.Current as TRegistro_FichaTecItemPed).Cd_item))
            {
                MessageBox.Show("Item já possui produto cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Confirma a inclusão do produto no item da ficha sem cadastro?",
                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {               
                BuscarProduto();
            }            
        }

        private void TFFichaTecItemPed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
