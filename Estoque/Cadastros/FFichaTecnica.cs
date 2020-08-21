using System;
using Utils;
using System.Windows.Forms;

namespace Estoque.Cadastros
{
    public partial class TFFichaTecnica : Form
    {
        private CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rprod;
        public CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha
        {
            get
            {
                return rprod.lFicha as CamadaDados.Estoque.Cadastros.TList_FichaTecProduto;
            }
            set { rprod.lFicha = value; }
        }
        
        public TFFichaTecnica()
        {
            InitializeComponent();
        }
        private void produto()
        {
            if (string.IsNullOrWhiteSpace(CD_Produto.Text.SoNumero()) ? false : CD_Produto.Text.SoNumero().Trim().Length.Equals(CD_Produto.Text.Trim().Length))
            {
                FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + CD_Produto.Text.Trim() + "';|exists|(select 1 from TB_EST_FichaTecProduto x where x.cd_produto = '" + CD_Produto.Text + "')",
                    new Componentes.EditDefault[] { CD_Produto, editDefault1 }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
                rprod = new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto();
                rprod.CD_Produto = CD_Produto.Text;
                rprod.DS_Produto = editDefault1.Text;
            }
            else
            {
                TpBusca[] filtro = new TpBusca[1];
                filtro[0].vNM_Campo = "isnull(e.st_composto, 'N')";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'S'";
                rprod = FormBusca.UtilPesquisa.BuscarProduto(CD_Produto.Text,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             new Componentes.EditDefault[] { CD_Produto },
                                                             filtro);
                if (rprod != null)
                    editDefault1.Text = rprod.DS_Produto;
            }
        }
        
        private void FFichaTecnica_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            panelDados2.set_FormatZero();
            CD_Produto.Focus();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {

            if (panelDados2.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void CD_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                dataGridDefault1.Focus();
        }
        private void buscarFicha(){
            if (rprod != null)
            {
                bsFichaTec.DataSource = new CamadaDados.Estoque.Cadastros.TCD_FichaTecProduto().Buscar(
                    new TpBusca[]{
                    new TpBusca(){
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = rprod.CD_Produto
                    }
                
                }, 100

                    );

                rprod.lFicha = new CamadaDados.Estoque.Cadastros.TCD_FichaTecProduto().Select(new TpBusca[]{
                    new TpBusca(){
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = rprod.CD_Produto
                    }
                
                }, 100, string.Empty

                    );
            }
        }
        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            produto();
            buscarFicha();
        }
    }
}
