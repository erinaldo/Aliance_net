using FormBusca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils;
using System.Linq;

namespace Locacao
{
    public partial class TFListaProdutoItem : Form
    {
        private CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
        public CamadaDados.Locacao.TList_ProdutoItens lProdDel { get; set; }
        public List<CamadaDados.Locacao.TRegistro_ProdutoItens> lProd
        {
            get
            {
                if (bsProdutos.Count > 0)
                    return (bsProdutos.List as ICollection<CamadaDados.Locacao.TRegistro_ProdutoItens>).ToList();
                else return null;
            }
        }

        public TFListaProdutoItem()
        {
            InitializeComponent();
            lProdDel = new CamadaDados.Locacao.TList_ProdutoItens();
        }

        private void BuscarProduto()
        {
            
            if (string.IsNullOrEmpty(cd_produto.Text))
                rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   null,
                                                   null);
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                rProd = UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   null,
                                                   null);
            else
            {
                TpBusca[] filtro = new TpBusca[0];
                //Buscar Produto
                Estruturas.CriarParametro(ref filtro,
                                          string.Empty,
                                          "(a.cd_produto like '%" + cd_produto.Text.Trim() + "') or " +
                                               "(a.Codigo_Alternativo = '" + (cd_produto.TextOld != null ? cd_produto.TextOld.ToString() : cd_produto.Text.Trim()) + "') or " +
                                               "(exists(select 1 from tb_est_codbarra x " +
                                               "           where x.cd_produto = a.cd_produto " +
                                               "           and x.cd_codbarra = '" + cd_produto.Text.Trim() + "'))", string.Empty);
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }
            if (rProd != null)
                pDsProduto.Text = rProd.DS_Produto;
            cd_produto.Clear();
            cd_produto.Focus();
            bsProdutos.ResetCurrentItem();
            txtEndereco.Focus();
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                BuscarProduto();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_produto.Text.Trim()))
                BuscarProduto();
        }
        
        private void txtEndereco_Leave(object sender, EventArgs e)
        {
            if (bsProdutos.Count > 0 && !string.IsNullOrWhiteSpace(txtEndereco.Text))
            {
                int i = (bsProdutos.List as ICollection<CamadaDados.Locacao.TRegistro_ProdutoItens>).Count;
                if((bsProdutos.List as ICollection<CamadaDados.Locacao.TRegistro_ProdutoItens>).ToList().Exists(x=> x.Endereco.Trim().Equals(txtEndereco.Text.Trim())))
                {
                    MessageBox.Show("Endereço ja existe na lista.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEndereco.Clear();
                    txtEndereco.Focus();
                    return;
                }
            }
        }

        private void txtEndereco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                bbAdd.Focus();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void bbExcluirProduto_Click(object sender, EventArgs e)
        {
            if(bsProdutos.Current != null)
                if(MessageBox.Show("Confirma exclusão do produto selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (!string.IsNullOrWhiteSpace((bsProdutos.Current as CamadaDados.Locacao.TRegistro_ProdutoItens).Cd_empresa))
                        lProdDel.Add(bsProdutos.Current as CamadaDados.Locacao.TRegistro_ProdutoItens);
                    bsProdutos.RemoveCurrent();
                }
        }

        private void TFListaProdutoItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F12))
                BuscarProduto();
        }

        private void bbAdd_Click(object sender, EventArgs e)
        {
            if(rProd == null)
            {
                MessageBox.Show("Obrigatório informar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_produto.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(txtEndereco.Text))
            {
                MessageBox.Show("Obrigatório informar endereço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEndereco.Focus();
                return;
            }
            bsProdutos.AddNew();
            (bsProdutos.Current as CamadaDados.Locacao.TRegistro_ProdutoItens).Cd_produto = rProd.CD_Produto;
            (bsProdutos.Current as CamadaDados.Locacao.TRegistro_ProdutoItens).Ds_produto = rProd.DS_Produto;
            (bsProdutos.Current as CamadaDados.Locacao.TRegistro_ProdutoItens).Endereco = txtEndereco.Text;
            txtEndereco.Clear();
            pDsProduto.Clear();
            rProd = null;
            cd_produto.Focus();
        }
    }
}
