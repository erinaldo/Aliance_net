using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Proc_Commoditties
{
    public partial class TFPedidoPsDiversa : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pNm_clifor
        { get; set; }
        public string pCd_produto
        { get; set; }
        public string pDs_produto
        { get; set; }
        public string pCd_unidade
        { get; set; }
        public string pSg_produto
        { get; set; }
        public decimal pQuantidade
        { get; set; }
        public string pTp_movimento
        { get; set; }
        public string cfg_pedido
        { get { return CFG_Pedido.Text; } }
        public string cd_endereco
        { get { return CD_Endereco.Text; } }
        public string cd_unidade
        { get { return CD_Unidade.Text; } }
        public string cd_local
        { get { return CD_Local.Text; } }
        public decimal quantidade
        { get { return Quantidade.Value; } }
        public decimal vl_unitario
        { get { return Vl_Unitario.Value; } }
        public decimal vl_subtotal
        { get { return Sub_Total.Value; } }

        public TFPedidoPsDiversa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if(string.IsNullOrEmpty(CFG_Pedido.Text))
            {
                MessageBox.Show("Obrigatorio informar tipo pedido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CFG_Pedido.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Endereco.Text))
            {
                MessageBox.Show("Obrigatorio informar endereço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Endereco.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Unidade.Text))
            {
                MessageBox.Show("Obrigatorio informar unidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Unidade.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFPedidoPsDiversa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            cd_empresa.Text = this.pCd_empresa;
            nm_empresa.Text = this.pNm_empresa;
            CD_Clifor.Text = this.pCd_clifor;
            NM_Clifor.Text = this.pNm_clifor;
            cd_produto.Text = this.pCd_produto;
            ds_produto.Text = this.pDs_produto;
            SG_Unidade_Estoque.Text = this.pSg_produto;
            Quantidade.Value = this.pQuantidade;
        }

        private void BB_CFGPedido_Click(object sender, EventArgs e)
        {
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')));" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'" + this.pTp_movimento.Trim() + "'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;" +
                                                       "TP_Movimento|Movimento|50;" +
                                                       "a.CFG_Pedido|CD. CFG Pedido|80;" +
                                                       "ST_Servico|Servico|50;" +
                                                       "a.st_integraralmox|Integrar Almox.|80;" +
                                                       "A.st_ValoresFixos|Permitir valores fixos|50;" +
                                                       "a.st_fecharpedidoauto|Fechar Pedido Automaticamente|50",
                            new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido, TP_Mov },
                            new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void CFG_Pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + CFG_Pedido.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')));" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'" + this.pTp_movimento.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido, TP_Mov },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEndereco(new Componentes.EditDefault[] { CD_Endereco, DS_Endereco }, "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEndereco("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';a.cd_endereco|=|'" + CD_Endereco.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Endereco, DS_Endereco });
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_Unidade|Ds Unidade|300;CD_Unidade|Cd.Unidade|80;Sigla_Unidade|Unid|60"
                , new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD }, new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), null);
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_Unidade|=|'" + CD_Unidade.Text + "'"
                , new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD }, new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";

            UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80",
                new Componentes.EditDefault[] { CD_Local, DS_Local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, cd_empresa.Text),
                vParam);
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);
            string vParam = "a.cd_local|=|'" + CD_Local.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam,
                                    new Componentes.EditDefault[] { CD_Local, DS_Local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, cd_empresa.Text));
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFPedidoPsDiversa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if(Quantidade.Value > decimal.Zero)
                if (Vl_Unitario.Value > decimal.Zero)
                    Sub_Total.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(pCd_unidade, CD_Unidade.Text, decimal.Multiply(Quantidade.Value, Vl_Unitario.Value), 2, null);
                else if (Sub_Total.Value > decimal.Zero)
                    Vl_Unitario.Value = decimal.Divide(Sub_Total.Value, CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(pCd_unidade, CD_Unidade.Text, Quantidade.Value, 3, null));
        }

        private void Vl_Unitario_Leave(object sender, EventArgs e)
        {
            if (Vl_Unitario.Value > decimal.Zero)
                if (Quantidade.Value > decimal.Zero)
                    Sub_Total.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(pCd_unidade, CD_Unidade.Text, decimal.Multiply(Quantidade.Value, Vl_Unitario.Value), 2, null);
                else if (Sub_Total.Value > decimal.Zero)
                    Quantidade.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade.Text, pCd_unidade, decimal.Divide(Sub_Total.Value, Vl_Unitario.Value), 3, null);
        }

        private void Sub_Total_Leave(object sender, EventArgs e)
        {
            if (Sub_Total.Value > decimal.Zero)
                if (Vl_Unitario.Value > decimal.Zero)
                    Quantidade.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade.Text, pCd_unidade, decimal.Divide(Sub_Total.Value, Vl_Unitario.Value), 3, null);
                else if (Quantidade.Value > decimal.Zero)
                    Vl_Unitario.Value = decimal.Divide(Sub_Total.Value, CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(pCd_unidade, CD_Unidade.Text, Quantidade.Value, 5, null));
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bbCliente_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
        }

        private void bbProduto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto, ds_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }
    }
}
