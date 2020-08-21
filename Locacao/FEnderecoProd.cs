using System;
using System.Windows.Forms;

namespace Locacao
{
    public partial class TFEnderecoProd : Form
    {
        private string pcd_produto = string.Empty;
        public string pCd_produto { get { return cd_produto.Text; } set { pcd_produto = value; } }
        public string pDs_produto { get; set; }
        private string pendereco = string.Empty;
        public string pEndereco { get { return endereco.Text; } set { pendereco = value; } }
        public TFEnderecoProd()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if(string.IsNullOrWhiteSpace(cd_produto.Text))
            {
                MessageBox.Show("Obrigatório informar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_produto.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(endereco.Text))
            {
                MessageBox.Show("Obrigatório informar endereço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                endereco.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void bbProduto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto, ds_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFEnderecoProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void TFEnderecoProd_Load(object sender, EventArgs e)
        {
            cd_produto.Text = pcd_produto;
            ds_produto.Text = pDs_produto;
            endereco.Text = pendereco;
            endereco.Enabled = string.IsNullOrWhiteSpace(pendereco);
        }
    }
}
