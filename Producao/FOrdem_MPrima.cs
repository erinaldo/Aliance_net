using CamadaDados.Estoque.Cadastros;
using CamadaDados.Producao.Producao;
using FormBusca;
using System;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace Producao
{
    public partial class TFOrdem_MPrima : Form
    {
        public string pCd_empresa { get; set; }
        private TRegistro_Ordem_MPrima rordem_MPrima;

        public TRegistro_Ordem_MPrima ROrdem_MPrima
        {
            get
            {
                if (bsOrdem_MPrima.Current != null)
                    return bsOrdem_MPrima.Current as TRegistro_Ordem_MPrima;
                else return null;
            }
            set
            { rordem_MPrima = value; }
        }

        public TFOrdem_MPrima()
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
                    CD_Unidade.Text = lProd[0].CD_Unidade;
                    DS_Unidade.Text = lProd[0].DS_Unidade;
                }
            }
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                if (!string.IsNullOrEmpty(CD_Local.Text))
                    Quantidade.Focus();
                else
                    CD_Local.Focus();
        }

        private void TFOrdem_MPrima_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if(rordem_MPrima != null)
            {
                bsOrdem_MPrima.DataSource = new TList_Ordem_MPrima() { rordem_MPrima };
                CD_Produto.Enabled = false;
                Quantidade.Focus();
            }
            else
            {
                bsOrdem_MPrima.AddNew();
                CD_Produto.Focus();
            }
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_unidade|Unidade|150;" +
                              "a.cd_unidade|Código|50;" +
                              "a.sigla_unidade|UND|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), string.Empty);
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_unidade|=|'" + CD_Unidade.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD },
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_local|Local Armazenagem|150;" +
                              "a.cd_local|Código|50";
            string vParam = "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local and x.cd_empresa = '" + pCd_empresa.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_local|=|'" + CD_Local.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local and x.cd_empresa = '" + pCd_empresa.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Local, DS_Local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFOrdem_MPrima_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void CD_Produto_Leave_1(object sender, EventArgs e)
        {
            this.BuscarProduto();
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                this.BuscarProduto();
        }
    }
}
