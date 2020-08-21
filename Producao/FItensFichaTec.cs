using CamadaDados.Estoque.Cadastros;
using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Producao
{
    public partial class TFItensFichaTec : Form
    {
        public CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem rFicha
        {
            get
            {
                if (bsFichaTec.Current != null)
                    return bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem;
                else
                    return null;
            }
        }
        public TFItensFichaTec()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void BuscarProduto(KeyEventArgs chave)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (chave == null ? false : chave.KeyCode.Equals(Keys.Enter) && string.IsNullOrEmpty(CD_Produto.Text))
            {
                if (UtilPesquisa.BuscarProduto(string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                               filtro) == null)
                {
                    MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Clear();
                    CD_Produto.Focus();
                    return;
                }
            }
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
            {
                if (UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                               string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                               filtro) == null)
                {
                    MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Clear();
                    CD_Produto.Focus();
                    return;
                }
            }
            else if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 2].vOperador = "<>";
                filtro[filtro.Length - 2].vVL_Busca = "'C'";
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.cd_produto like '%" + CD_Produto.Text.Trim() + "') or " +
                                                        "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                                                        "(exists(select 1 from tb_est_codbarra x " +
                                                        "           where x.cd_produto = a.cd_produto " +
                                                        "           and x.cd_codbarra = '" + CD_Produto.Text.Trim() + "'))";
                TList_CadProduto lProd = new TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                {
                    CD_Produto.Text = lProd[0].CD_Produto;
                    DS_Produto.Text = lProd[0].DS_Produto;
                    SG_Unidade_Estoque.Text = lProd[0].Sigla_unidade;
                }
                else
                    CD_Produto.Text = string.Empty;
            }
            else
                DS_Produto.Focus();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                CD_Local.Focus();
        }

        private void TFItensFichaTec_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsFichaTec.AddNew();
            CD_Produto.Focus();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            bsFichaTec.Clear();
            DialogResult = DialogResult.OK;
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            BuscarProduto(null);
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                BuscarProduto(e);
        }

        private void TFItensFichaTec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                BB_Cancelar_Click(this, new EventArgs());
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_local|=|'" + CD_Local.Text.Trim() + "'",
                                    new Componentes.EditDefault[] { CD_Local, DS_Local },
                                    new TCD_CadLocalArm());
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80",
               new Componentes.EditDefault[] { CD_Local, DS_Local },
               new TCD_CadLocalArm(),
               string.Empty);
        }
    }
}
