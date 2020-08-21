using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFConsultaProduto : Form
    {
        public TFConsultaProduto()
        {
            InitializeComponent();
        }

        public void Produtos()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[2];
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            filtro[1].vNM_Campo = string.Empty;
            filtro[1].vOperador = string.Empty;
            filtro[1].vVL_Busca = "(a.cd_produto like '%" + ds_Produto.Text.Trim() + "') or " +
                                  "(a.ds_produto like " + (Utils.Parametros.ST_UtilizarCoringaEsq ? "'%" : "'") + ds_Produto.Text.Trim() + "%') or " +
                                  "(exists(select 1 from tb_est_codbarra x " +
                                  "           where x.cd_produto = a.cd_produto " +
                                  "           and x.cd_codbarra = '" + ds_Produto.Text.Trim() + "'))";
            if (!string.IsNullOrEmpty(cd_marca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_marca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_marca.Text;

            }
            bsProduto.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(filtro, Utils.Parametros.pubTopMax, string.Empty, string.Empty, "a.ds_produto");
            bsProduto_PositionChanged(this, new EventArgs());
        }

        private void TFConsultaProduto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR CUSTO VENDA", null))
            {
                lblVisualizarCustos.Visible = false;
                pVl_medio.Visible = false;
                pVl_ultimacompra.Visible = false;
            }
        }

        private void ds_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                Produtos();
        }

        private void bsProduto_PositionChanged(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
            {
                //Buscar Ficha Tecnica
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFicha = 
                    CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                               string.Empty,
                                                                               null);
                //Dados Estoque
                bs_ConsultaLocal.DataSource = CamadaNegocio.Estoque.TCN_ConsultaProdutos.buscaLocal(string.Empty, (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto);
                //Preco Produto
                bsConsultaPrecoVenda.DataSource = CamadaNegocio.Estoque.TCN_ConsultaProdutos.buscaConsultaPreco(string.Empty,
                                                                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                                                                string.Empty,
                                                                                                                string.Empty);
            }
        }

        private void lblVisualizarCustos_Click(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
                using (FormBusca.TFCustoProduto fCusto = new FormBusca.TFCustoProduto())
                {
                    fCusto.pCd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                    fCusto.pDs_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto;
                    fCusto.pUnd = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Sigla_unidade;
                    fCusto.ShowDialog();
                }
            else
                MessageBox.Show("Necessario selecionar produto para visualizar custo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFConsultaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void bb_marca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_marca|Marca|200;" +
                              "a.cd_marca|Id. Marca|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_marca, ds_marca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMarca(),
                                    string.Empty);
        }

        private void cd_marca_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_marca|=|" + cd_marca.Text,
                                    new Componentes.EditDefault[] { cd_marca, ds_marca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMarca());
        }
    }
}
