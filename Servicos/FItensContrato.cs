using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFItensContrato : Form
    {
        private CamadaDados.Servicos.TRegistro_Contrato_Itens ritem;
        public CamadaDados.Servicos.TRegistro_Contrato_Itens rItem
        {
            get
            {
                if (bsItensContrato.Current != null)
                    return bsItensContrato.Current as CamadaDados.Servicos.TRegistro_Contrato_Itens;
                else
                    return null;
            }
            set { ritem = value; }
        }

        public string Cd_empresa
        { get; set; }

        public TFItensContrato()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (Quantidade.Focused)
                (bsItensContrato.Current as CamadaDados.Servicos.TRegistro_Contrato_Itens).Quantidade = Quantidade.Value;
            if (Vl_Unitario.Focused)
                (bsItensContrato.Current as CamadaDados.Servicos.TRegistro_Contrato_Itens).Vl_unitario = Vl_Unitario.Value;
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(e.st_servico, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto, SG_Unidade_Estoque }, vParam);
            if((!string.IsNullOrEmpty(Cd_empresa)) &&
                (!string.IsNullOrEmpty(CD_Produto.Text)))
            {
                object obj = new CamadaDados.Servicos.Cadastros.TCD_CfgContrato().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                    }
                                }, "a.cd_tabelapreco");
                if(obj != null)
                {
                    Vl_Unitario.Value = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(Cd_empresa, CD_Produto.Text, obj.ToString(), null);
                    Vl_Unitario.Enabled = Vl_Unitario.Value.Equals(decimal.Zero);
                }
            }
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + CD_Produto.Text.Trim() + "';" +
                                                                     "isnull(e.st_servico, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { CD_Produto, DS_Produto, SG_Unidade_Estoque },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if ((!string.IsNullOrEmpty(Cd_empresa)) &&
                (!string.IsNullOrEmpty(CD_Produto.Text)))
            {
                object obj = new CamadaDados.Servicos.Cadastros.TCD_CfgContrato().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                    }
                                }, "a.cd_tabelapreco");
                if (obj != null)
                {
                    Vl_Unitario.Value = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(Cd_empresa, CD_Produto.Text, obj.ToString(), null);
                    Vl_Unitario.Enabled = Vl_Unitario.Value.Equals(decimal.Zero);
                }
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFItensContrato_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (ritem != null)
            {
                bsItensContrato.DataSource = new CamadaDados.Servicos.TList_Contrato_Itens() { ritem };
                CD_Produto.Enabled = false;
                BB_Produto.Enabled = false;
                Quantidade.Focus();
            }
            else
            {
                bsItensContrato.AddNew();
                CD_Produto.Focus();
            }
        }
    }
}
