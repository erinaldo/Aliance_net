using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFInserirItensCompra : Form
    {
        private CamadaDados.Faturamento.Orcamento.TRegistro_ItensCompraOrcProj ritem;
        public CamadaDados.Faturamento.Orcamento.TRegistro_ItensCompraOrcProj rItem
        {
            get
            {
                if (bsItensCompra.Current != null)
                    return bsItensCompra.Current as CamadaDados.Faturamento.Orcamento.TRegistro_ItensCompraOrcProj;
                else
                    return null;
            }
            set { ritem = value; }
        }
        public TFInserirItensCompra()
        {
            InitializeComponent();
        }

        private void BuscarProduto()
        {
            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
            if (string.IsNullOrEmpty(CD_Produto.Text))
                rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             null);
            else if (CD_Produto.Text.SoNumero().Trim().Length != CD_Produto.Text.Trim().Length)
                rProd = FormBusca.UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                             null);
            else
            {
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                    new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "(a.cd_produto like '%" + CD_Produto.Text.Trim() + "') or " +
                                            "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                                            "(exists(select 1 from tb_est_codbarra x " +
                                            "           where x.cd_produto = a.cd_produto " +
                                            "           and x.cd_codbarra = '" + CD_Produto.Text.Trim() + "'))"
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }
            if (rProd != null)
            {
                CD_Produto.Text = rProd.CD_Produto;
                DS_Produto.Text = rProd.DS_Produto;
            }
            else
            {
                CD_Produto.Clear();
                CD_Produto.Focus();
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFInserirItensCompra_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsItensCompra.AddNew();
            (bsItensCompra.Current as CamadaDados.Faturamento.Orcamento.TRegistro_ItensCompraOrcProj).Quantidade = 1;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFInserirItensCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "||(a.cd_produto = '" + CD_Produto.Text.Trim() + "') or " +
               "(a.Codigo_Alternativo = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "') or " +
                             "(exists(select 1 from tb_est_codbarra x " +
                             "         where x.cd_produto = a.cd_produto " +
                             "         and x.cd_codbarra = '" + (CD_Produto.TextOld != null ? CD_Produto.TextOld.ToString() : CD_Produto.Text.Trim()) + "'));" +
                             "isnull(a.st_registro, 'A')|<>|'C'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                DS_Produto.Enabled = false;
                quantidade.Focus();
            }
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Enter))
            {
                this.BuscarProduto();
                quantidade.Focus();
            }
        }
    }
}
