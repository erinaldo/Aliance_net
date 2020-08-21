using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFCadCodBarra : Form
    {
        public TFCadCodBarra()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(cd_produto.Text))
            {
                MessageBox.Show("Obrigatorio informar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_produto.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_codbarra.Text))
            {
                MessageBox.Show("Obrigatorio informar codigo barra.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_codbarra.Focus();
                return;
            }
            try
            {
                CamadaNegocio.Estoque.Cadastros.TCN_CodBarra.Gravar(
                    new CamadaDados.Estoque.Cadastros.TRegistro_CodBarra()
                    {
                        Cd_produto = cd_produto.Text,
                        Cd_codbarra = cd_codbarra.Text
                    }, null);
                MessageBox.Show("Codigo barra gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFCadCodBarra_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }
    }
}
