using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFItensFichaTecOrc : Form
    {
        private CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem rficha;
        public CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem rFicha
        {
            get
            {
                if (bsFichaTec.Current != null)
                    return bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem;
                else
                    return null;
            }
            set { rficha = value; }
        }

        public string CD_Empresa = string.Empty;
        public string CD_TabelaPreco = string.Empty;

        private void BuscaPrecoItem()
        {
            if (bsFichaTec.Current != null)
            {
                (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Vl_unitario =
                    CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(CD_Empresa, CD_Produto.Text, CD_TabelaPreco, null);
                subtotal.Value = (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Vl_Subtotal;
                Vl_Unitario.Enabled = string.IsNullOrEmpty(CD_TabelaPreco) || Vl_Unitario.Value.Equals(0);
                //Buscar custo produto
                vl_custo.Value = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(CD_Empresa, CD_Produto.Text, null);
                vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_OBRIGAR_CUSTO_UNIT_ORC",
                                                                         null).Equals(true);
            }
        }

        public TFItensFichaTecOrc()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (Quantidade.Focused)
                (bsFichaTec.Current as CamadaDados.Faturamento.Orcamento.TRegistro_FichaTecOrcItem).Quantidade = Quantidade.Value;
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string cond = "a.cd_produto|=|'" + CD_Produto.Text.Trim() + "'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVEProduto(cond
                    , new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (linha != null)
            {
                SG_Unidade_Estoque.Text = linha["sigla_unidade"].ToString();
                BuscaPrecoItem();
            }
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto }, string.Empty);
            if (linha != null)
            {
                SG_Unidade_Estoque.Text = linha["sigla_unidade"].ToString();
                BuscaPrecoItem();
            }
        }

        private void TFItensFichaTecOrc_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rficha != null)
            {
                bsFichaTec.DataSource = new CamadaDados.Faturamento.Orcamento.TList_FichaTecOrcItem() { rficha };
                CD_Produto.Enabled = false;
                BB_Produto.Enabled = false;
                Vl_Unitario.Enabled = rficha.Vl_unitario.Equals(decimal.Zero);
                Quantidade.Focus();
                vl_custo.Enabled = vl_custo.Value.Equals(decimal.Zero) && CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_OBRIGAR_CUSTO_UNIT_ORC",
                                                                         null).Equals(true);
            }
            else
            {
                bsFichaTec.AddNew();
                CD_Produto.Focus();
            }
            Vl_Unitario.Enabled = string.IsNullOrEmpty(CD_TabelaPreco);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFItensFichaTecOrc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
