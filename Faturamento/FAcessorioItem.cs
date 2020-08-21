using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using FormBusca;
using System;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFAcessorioItem : Form
    {
        public string pCd_empresa
        { get; set; }
        private CamadaDados.Faturamento.Pedido.TRegistro_AcessoriosPed racessorio;
        public CamadaDados.Faturamento.Pedido.TRegistro_AcessoriosPed rAcessorio
        {
            get
            {
                if (bsAcessorioItem.Current != null)
                    return bsAcessorioItem.Current as CamadaDados.Faturamento.Pedido.TRegistro_AcessoriosPed;
                else
                    return null;
            }
            set { racessorio = value; }
        }
        public TFAcessorioItem()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void BuscarProduto()
        {
            TpBusca[] filtro = new TpBusca[0];
            if (string.IsNullOrEmpty(CD_Produto.Text))
            {
                if (UtilPesquisa.BuscarProduto(string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                               null) == null)
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
                                               null) == null)
                {
                    MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Produto.Clear();
                    CD_Produto.Focus();
                    return;
                }
            }
            else
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
                }
            }
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                if (!string.IsNullOrEmpty(CD_Local.Text))
                    Quantidade.Focus();
                else
                    CD_Local.Focus();
        }

        private void TFAcessorioItem_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            bsAcessorioItem.AddNew();
            pDados.set_FormatZero();
            TList_CadLocalArm_X_Empresa List_Local_x_Empresa = new TList_CadLocalArm_X_Empresa();
            if (!string.IsNullOrEmpty(pCd_empresa))
                List_Local_x_Empresa = TCN_CadLocalArm_X_Empresa.Busca(string.Empty,
                                                                       pCd_empresa,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       null);
            string produto = CD_Produto.Text;
            if (List_Local_x_Empresa.Count == 1)
            {
                CD_Local.Text = List_Local_x_Empresa[0].CD_Local;
                DS_Local.Text = List_Local_x_Empresa[0].DS_Local;
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFAcessorioItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                BuscarProduto();
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80",
                new Componentes.EditDefault[] { CD_Local, DS_Local },
                new TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, pCd_empresa),
                vParam);
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);
            string vParam = "a.cd_local|=|'" + CD_Local.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam,
                                    new Componentes.EditDefault[] { CD_Local, DS_Local },
                                    new TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, pCd_empresa));
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            BuscarProduto();
        }
    }
}
