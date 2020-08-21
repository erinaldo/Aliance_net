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
    public partial class TFItensOrdem : Form
    {
        private CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico ritem;
        public CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico rItem
        {
            get
            {
                if (bsItens.Current != null)
                    return bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico;
                else
                    return null;
            }
            set { ritem = value; }
        }
        public string Cd_empresa
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }

        public TFItensOrdem()
        {
            InitializeComponent();
        }

        private void ConsultaPreco()
        {
            if ((!string.IsNullOrEmpty(Cd_empresa)) &&
                (!string.IsNullOrEmpty(Cd_tabelapreco)) &&
                (!string.IsNullOrEmpty(cd_produto.Text)))
            {
                vl_unitario.Value = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(Cd_empresa, cd_produto.Text, Cd_tabelapreco);
                vl_unitario.Enabled = vl_unitario.Value.Equals(decimal.Zero);
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (quantidade.Focused)
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Quantidade = quantidade.Value;
                if (vl_unitario.Focused)
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Vl_unitario = vl_unitario.Value;
                if (km_validade.Focused)
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Km_validade = km_validade.Value;
                if (dias_validade.Focused)
                    (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).Dias_validade = dias_validade.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFItensOrdem_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (ritem != null)
            {
                bsItens.DataSource = new CamadaDados.PostoCombustivel.TList_ItensOrdemServico() { ritem };
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
            }
            else
            {
                bsItens.AddNew();
                //Buscar local armazenagem
                if (!string.IsNullOrEmpty(Cd_empresa))
                {
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                        }
                                    }, "a.cd_local");
                    if (obj != null)
                    {
                        cd_local.Text = obj.ToString();
                        cd_local_Leave(this, new EventArgs());
                    }
                }
            }
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto, sigla_unidade }, string.Empty);
            this.ConsultaPreco();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_produto, ds_produto, sigla_unidade },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            this.ConsultaPreco();
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = 
                new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);
            string vParam = "a.cd_local|=|'" + cd_local.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam,
                                    new Componentes.EditDefault[] { cd_local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, Cd_empresa));
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = 
                new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);
            string vParam = string.Empty;
            FormBusca.UtilPesquisa.BTN_BUSCA("DS_Local|Local|300;CD_Local|Código|80",
                new Componentes.EditDefault[] { cd_local, ds_local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, Cd_empresa),
                vParam);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFItensOrdem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
