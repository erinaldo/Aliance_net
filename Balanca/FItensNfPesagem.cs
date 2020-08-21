using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Componentes;
using CamadaDados.Faturamento.Pedido;

namespace Balanca
{
    public partial class TFItensNfPesagem : Form
    {
        public string Nr_pedido
        { get; set; }
        public string Nr_contrato
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public CamadaDados.Balanca.TRegistro_LanPesagemProduto rPsProduto
        {
            get
            {
                if (bsNFItens.Current != null)
                    return (bsNFItens.Current as CamadaDados.Balanca.TRegistro_LanPesagemProduto);
                else
                    return null;
            }
        }

        public TFItensNfPesagem()
        {
            InitializeComponent();
            this.Nr_pedido = string.Empty;
            this.Nr_contrato = string.Empty;
            this.Cd_produto = string.Empty;
            this.Cd_empresa = string.Empty;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFItensNfPesagem_Load(object sender, EventArgs e)
        {
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.pDados.set_FormatZero();
            bsNFItens.AddNew();
            if (this.Nr_pedido.Trim().Equals(string.Empty))
            {
                nr_pedido.Clear();

                ID_PedidoItem.Enabled = false;
                ID_PedidoItem.ST_NotNull = false;
                bb_pedidoitem.Enabled = false;

                cd_produto.Enabled = true;
                bb_produto.Enabled = true;
                cd_produto.ST_NotNull = true;

                cd_produto.Focus();
            }
            else
            {
                nr_pedido.Text = this.Nr_pedido;

                ID_PedidoItem.Enabled = true;
                ID_PedidoItem.ST_NotNull = true;
                bb_pedidoitem.Enabled = true;

                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
                //Buscar item do pedido
                object obj = new TCD_LanPedido_Item().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.nr_pedido",
                                        vOperador = "=",
                                        vVL_Busca = this.Nr_pedido
                                    }
                                }, "a.id_pedidoitem");
                if (obj != null)
                {
                    ID_PedidoItem.Text = obj.ToString();
                    ID_PedidoItem_Leave(this, new EventArgs());
                    qtd_nota.Focus();
                }
                else
                    ID_PedidoItem.Focus();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFItensNfPesagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_pedidoitem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nr_pedido|Nr.Pedido|50;" +
                              "contrato.nr_contrato|Nr.Contrato|50;" +
                              "d.DS_Produto|Descrição Produto|350;" +
                              "d.CD_Produto|Cód. Produto|100;" +
                              "a.quantidade|Quantidade|100;" +
                              "a.vl_unitario|Vl. Unitario|80;" +
                              "a.vl_subtotal|Valor Tot|100;" +
                              "a.ID_PedidoItem|Id. Item|80";
            string vParamFixo = "a.nr_pedido|=|" + this.Nr_pedido;
            if (this.Nr_contrato.Trim() != string.Empty)
                vParamFixo += "; contrato.nr_Contrato|=|" + this.Nr_contrato;
            if (this.Cd_produto.Trim() != string.Empty)
                vParamFixo += ";|EXISTS|(select 1 from tb_fat_pedido_itens m where m.nr_pedido = a.nr_pedido and m.cd_produto = '" + this.Cd_produto.Trim() + "')";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { ID_PedidoItem, cd_produto, ds_produto },
                                    new TCD_LanPedido_Item(), vParamFixo);
            if (linha != null)
            {
                cd_unidest.Text = linha["cd_unidade_est"].ToString();
                cd_unidade.Text = linha["cd_unidade_valor"].ToString();
                cd_unidade_Leave(this, new EventArgs());
                vl_unitario.Value = Convert.ToDecimal(linha["vl_unitario"].ToString());
            }
        }

        private void ID_PedidoItem_Leave(object sender, EventArgs e)
        {
            string vParamFixo = "a.nr_pedido|=|" + this.Nr_pedido + ";" +
                                "a.id_pedidoitem|=|" + ID_PedidoItem.Text;
            if (this.Nr_contrato.Trim() != string.Empty)
                vParamFixo += "; contrato.nr_Contrato|=|" + this.Nr_contrato;
            if (this.Cd_produto.Trim() != string.Empty)
                vParamFixo += ";|EXISTS|(select 1 from tb_fat_pedido_itens m where m.nr_pedido = a.nr_pedido and m.cd_produto = '" + this.Cd_produto.Trim() + "')";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParamFixo, new EditDefault[] { ID_PedidoItem, cd_produto, ds_produto },
                                    new TCD_LanPedido_Item());
            if (linha != null)
            {
                cd_unidest.Text = linha["cd_unidade_est"].ToString();
                cd_unidade.Text = linha["cd_unidade_valor"].ToString();
                cd_unidade_Leave(this, new EventArgs());
                vl_unitario.Value = Convert.ToDecimal(linha["vl_unitario"].ToString());
            }
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_produto|Produto|200;" +
                              "a.cd_produto|Cd. Produto|80;" +
                              "b.sigla_unidade|UND|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_produto, ds_produto, cd_unidest },
                new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_produto, ds_produto, cd_unidest },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_unidade|Unidade Medida|200;" +
                              "a.cd_unidade|Cd. Unidade|80;" +
                              "a.sigla_unidade|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_unidade, ds_unidade, sigla_unidvalor, sigla_unidvalor1 },
                                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), string.Empty);
        }

        private void cd_unidade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_unidade|=|'" + cd_unidade.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_unidade, ds_unidade, sigla_unidvalor1, sigla_unidvalor },
                                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }
    }
}
