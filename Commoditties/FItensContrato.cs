using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;

namespace Commoditties
{
    public partial class TFItensContrato : Form
    {
        public bool St_alterar
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Cd_tabeladesconto
        { get; set; }
        public int IndexItem
        { get; set; }
        public string Tp_movimento
        { get; set; }

        private CamadaDados.Faturamento.Pedido.TRegistro_Pedido rped;
        public CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed
        {
            get
            {
                if (bsPedido.Current != null)
                    return bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido;
                else
                    return null;
            }
            set { rped = value; }
        }

        private bool st_valoresfixos = false;

        public TFItensContrato()
        {
            InitializeComponent();
            this.rped = null;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Cd_tabeladesconto = string.Empty;
            this.St_alterar = false;
            this.IndexItem = 0;
        }

        private void afterGrava()
        {
            if (pPedido.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BB_CFGPedido_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_commoditties, 'N')|=|'S';"+
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            if (!string.IsNullOrEmpty(this.Tp_movimento))
                vParam += ";a.tp_movimento|=|'" + this.Tp_movimento.Trim() + "'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;TP_Movimento|Movimento|50;a.CFG_Pedido|CD. CFG Pedido|80;ST_Servico|Servico|50;A.st_ValoresFixos|Permitir valores fixos|50",
                                    new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido, TP_Mov },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
            if (linha != null)
            {
                st_valoresfixos = linha["st_ValoresFixos"].ToString().Trim().ToUpper().Equals("S");
                if(bsPedido.Current != null)
                    (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).St_valoresfixosbool = st_valoresfixos;
            }
        }

        private void CFG_Pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + CFG_Pedido.Text.Trim() + "';" +
                            "isnull(a.st_commoditties, 'N')|=|'S';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            if (!string.IsNullOrEmpty(this.Tp_movimento))
                vParam += ";a.tp_movimento|=|'" + this.Tp_movimento.Trim() + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido, TP_Mov },
                            new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
            if (linha != null)
            {
                st_valoresfixos = linha["st_ValoresFixos"].ToString().Trim().ToUpper().Equals("S");
                if (bsPedido.Current != null)
                    (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).St_valoresfixosbool = st_valoresfixos;
            }
        }

        private void BB_Moeda_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Moeda_Singular|Moeda|200;a.Sigla|Sigla|80;a.CD_Moeda|Cód. Moeda|80"
                                     , new Componentes.EditDefault[] { CD_Moeda, DS_Moeda, Sigla_Moeda },
                                     new CamadaDados.Financeiro.Cadastros.TCD_Moeda(),
                                     string.Empty);
        }

        private void CD_Moeda_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_moeda|=|'" + CD_Moeda.Text.Trim() + "'",
                                    new Componentes.EditDefault[] { CD_Moeda, DS_Moeda, Sigla_Moeda },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            string cond = "|exists|(select 1 from tb_gro_descontoXproduto x " +
                          "         where x.cd_produto = a.cd_produto " +
                          "         and x.cd_tabeladesconto = '" + this.Cd_tabeladesconto.Trim() + "')";
            if (!st_valoresfixos)
                cond += (cond.Equals(string.Empty) ? string.Empty : ";") + "isnull(e.st_produtofixar, 'N')|=|'S'";
            if (this.TP_Mov.Text.Trim().ToUpper().Equals("S"))
                cond += (cond.Equals(string.Empty) ? string.Empty : ";") + "||((a.tp_produto is null) or (exists(select 1 from tb_est_tpproduto x " +
                                                                                    "where x.tp_produto = a.tp_produto " +
                                                                                    "and isnull(x.st_mprima, 'N') <> 'S')))";


            DataRowView linha = UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto }, cond);
            if (linha != null)
            {
                cd_unidestoque.Text = linha["cd_unidade"].ToString();
                SG_Unidade_Estoque.Text = linha["sigla_unidade"].ToString();
            }
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string cond = "a.CD_Produto|=|'" + CD_Produto.Text + "';" +
                          "|exists|(select 1 from tb_gro_descontoXproduto x " +
                          "         where x.cd_produto = a.cd_produto " +
                          "         and x.cd_tabeladesconto = '" + this.Cd_tabeladesconto.Trim() + "')";
            if (!st_valoresfixos)
                cond += ";isnull(e.st_produtofixar, 'N')|=|'S'";
            if (this.TP_Mov.Text.Trim().ToUpper().Equals("S"))
                cond += ";||((a.tp_produto is null) or (exists(select 1 from tb_est_tpproduto x " +
                                                                                    "where x.tp_produto = a.tp_produto " +
                                                                                    "and isnull(x.st_mprima, 'N') <> 'S')))";

            UtilPesquisa.EDIT_LEAVEProduto(cond
                    , new Componentes.EditDefault[] { CD_Produto, DS_Produto, cd_unidestoque, SG_Unidade_Estoque },
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Variedade_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Variedade|Ds Variedade|300;a.CD_Variedade|Cd.Variedade|80", 
                                    new Componentes.EditDefault[] { CD_Variedade, DS_Variedade }, 
                                    new CamadaDados.Estoque.Cadastros.TCD_CadVariedades(),
                                    "a.CD_Produto|=|'" + CD_Produto.Text.Trim() + "'");
        }

        private void CD_Variedade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_Variedade|=|'" + CD_Variedade.Text.Trim() + 
                                    "';a.cd_Produto|=|'" + CD_Produto.Text.Trim() + "'"
                                    , new Componentes.EditDefault[] { CD_Variedade, DS_Variedade }, 
                                    new CamadaDados.Estoque.Cadastros.TCD_CadVariedades());
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_Unidade|Ds Unidade|300;CD_Unidade|Cd.Unidade|80;Sigla_Unidade|Unid|60", 
                new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD }, 
                new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(),
                string.Empty);
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_Unidade|=|'" + CD_Unidade.Text.Trim() + "'", 
                                    new Componentes.EditDefault[] { CD_Unidade, DS_Unidade, SG_UniQTD }, 
                                    new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Empresa List_Local_x_Empresa = new TList_CadLocalArm_X_Empresa();
            if (!string.IsNullOrEmpty(CD_Empresa.Text.Trim()))
                List_Local_x_Empresa = TCN_CadLocalArm_X_Empresa.Busca(string.Empty, CD_Empresa.Text, string.Empty, string.Empty, null);

            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text.Trim()))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);
            string vColunas = "a.DS_Local|Local Armazenagem|300;" +
                                  "a.CD_Local|Cd. Local|80";
            if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count > 0))
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local }, new TCD_CadLocalArm(CD_Produto.Text, CD_Empresa.Text), string.Empty);
            else if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count == 0))
            {
                string vParam = "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                                "where x.cd_local = a.cd_local " +
                                "and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "')";
                UtilPesquisa.BTN_BUSCA("DS_Local|Local|300;CD_Local|Código|80"
                               , new Componentes.EditDefault[] { CD_Local, DS_Local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
            }
            else if ((List_Local_x_Empresa.Count == 0) && (List_Local_x_Produto.Count > 0))
            {
                string vParam = "|exists|(select top 1 from tb_est_localarm_x_produto x " +
                                "where x.cd_local = a.cd_local " +
                                "and x.cd_produto = '" + CD_Produto.Text.Trim() + "')";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
            }
            else
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), null);
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Empresa List_Local_x_Empresa = new TList_CadLocalArm_X_Empresa();
            if (!string.IsNullOrEmpty(CD_Empresa.Text.Trim()))
                List_Local_x_Empresa = TCN_CadLocalArm_X_Empresa.Busca(string.Empty, CD_Empresa.Text, string.Empty, string.Empty, null);

            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text.Trim()))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca("", CD_Produto.Text);

            if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count > 0))
                UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + CD_Local.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Local, DS_Local }, new TCD_CadLocalArm(CD_Produto.Text, CD_Empresa.Text));
            else if ((List_Local_x_Empresa.Count > 0) && (List_Local_x_Produto.Count == 0))
            {
                string vColunas = "a.cd_local|=|'" + CD_Local.Text.Trim() + "';" +
                                  "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                                  "where x.cd_local = a.cd_local " +
                                  "and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "')";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
            }
            else if ((List_Local_x_Empresa.Count == 0) && (List_Local_x_Produto.Count > 0))
            {
                string vColunas = "a.cd_local|=|'" + CD_Local.Text.Trim() + "';" +
                                  "|exists|(select 1 from tb_est_localarm_x_produto x " +
                                  "where x.cd_local = a.cd_local " +
                                  "and x.cd_produto = '" + CD_Produto.Text.Trim() + "')";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
            }
            else
                UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + CD_Local.Text.Trim() + "'"
                , new Componentes.EditDefault[] { CD_Local, DS_Local }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFItensContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFItensContrato_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pPedido.set_FormatZero();
            if (rped != null)
            {
                bsPedido.DataSource = new CamadaDados.Faturamento.Pedido.TList_Pedido() { rped };
                CFG_Pedido.Enabled = false;
                BB_CFGPedido.Enabled = false;
                CD_Produto.Enabled = !this.St_alterar;
                BB_Produto.Enabled = !this.St_alterar;
                DT_Pedido.Enabled = this.St_alterar;
                CD_Moeda.Enabled = this.St_alterar;
                BB_Moeda.Enabled = this.St_alterar;
                Nr_PedidoOrigem.Enabled = this.St_alterar;
                Vl_Frete.Enabled = this.St_alterar;
                if (!this.St_alterar)
                    bsItens.AddNew();
                else
                    bsItens.Position = this.IndexItem;
                st_valoresfixos = rped.St_valoresfixos.Trim().ToUpper().Equals("S");
                bsPedido.ResetCurrentItem();
            }
            else
            {
                bsPedido.AddNew();
                bsItens.AddNew();
                CD_Empresa.Text = this.Cd_empresa;
                NM_Empresa.Text = this.Nm_empresa;
                CD_Clifor.Text = this.Cd_clifor;
                NM_Clifor.Text = this.Nm_clifor;
                CD_Endereco.Text = this.Cd_endereco;
                DS_Endereco.Text = this.Ds_endereco;
                (bsPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).ST_Pedido = "F";//Pedido Fechado
                //Buscar Moeda Padrao
                CamadaDados.Financeiro.Cadastros.TList_Moeda tabela = CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(CD_Empresa.Text);
                if (tabela != null)
                {
                    CD_Moeda.Text = tabela[0].Cd_moeda;
                    DS_Moeda.Text = tabela[0].Ds_moeda_singular;
                    Sigla_Moeda.Text = tabela[0].Sigla;
                }
            }
        }
    }
}
