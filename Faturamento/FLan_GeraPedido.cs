using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Faturamento.Cadastros;

namespace Faturamento
{
    public partial class TFLan_GeraPedido : Form
    {
        public TFLan_GeraPedido()
        {
            InitializeComponent();
        }

        private void TFLan_GeraPedido_Load(object sender, EventArgs e)
        {
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            pnl_Gera_Pedido.set_FormatZero();
            DT_Pedido.Text = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
            this.BuscarEndClifor();
            this.BuscarEndTransp();
        }

        private void BuscarEndClifor()
        {
            if (CD_Clifor.Text.Trim() != string.Empty)
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              null);
                if (lEnd.Count > 0)
                {
                    CD_Endereco.Text = lEnd[0].Cd_endereco;
                    DS_Endereco.Text = lEnd[0].Ds_endereco;
                }
            }
        }

        private void BuscarEndTransp()
        {
            if (cd_transportadora.Text.Trim() != string.Empty)
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_transportadora.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              null);
                if (lEnd.Count > 0)
                {
                    cd_endtransp.Text = lEnd[0].Cd_endereco;
                    ds_endtransp.Text = lEnd[0].Ds_endereco;
                }
            }
        }

        private void BuscarCfgPrePedido()
        {
            if (CD_Empresa.Text.Trim() != string.Empty)
            {
                CamadaDados.Faturamento.Cadastros.TList_CFGPrePedido lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGPrePedido.Buscar(CD_Empresa.Text,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1,
                                                                                string.Empty,
                                                                                null);
                if (lCfg.Count > 0)
                {
                    CFG_Pedido.Text = lCfg[0].Cfg_pedido.Trim();
                    DS_CFGPedido.Text = lCfg[0].Ds_tipopedido.Trim();
                    TP_Mov.Text = lCfg[0].Tp_movimento.Trim().ToUpper();
                    CD_Moeda.Text = lCfg[0].Cd_moeda.Trim();
                    DS_Moeda.Text = lCfg[0].Ds_moeda.Trim();
                    Sigla_Moeda.Text = lCfg[0].Sigla.Trim();
                    cd_vendedor.Text = lCfg[0].Cd_vendedorstr;
                    nomevendedor.Text = lCfg[0].Nomevendedor;
                }
                CFG_Pedido.Enabled = lCfg.Count.Equals(0);
                BB_CFGPedido.Enabled = lCfg.Count.Equals(0);
                CD_Moeda.Enabled = lCfg.Count.Equals(0);
                BB_Moeda.Enabled = lCfg.Count.Equals(0);
            }
        }

        private void TFLan_GeraPedido_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F6):
                    {
                        BB_Cancelar_Click(sender, new EventArgs()); break;
                    }
                case (Keys.F4):
                    {
                        BB_Gravar_Click(sender, new EventArgs()); break;
                    };
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (pnl_Gera_Pedido.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                         , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
                         , new CamadaDados.Diversos.TCD_CadEmpresa(),
                         "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)");
            this.BuscarCfgPrePedido();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)"
               , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
            this.BuscarCfgPrePedido();
        }

        private void BB_CFGPedido_Click(object sender, EventArgs e)
        {
            string vParam = "A.TP_Movimento|=|'S';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;TP_Movimento|Movimento|50;ST_PermiteCFG_Fiscal|CFG Fiscal|50;a.CFG_Pedido|CD. CFG Pedido|80;ST_Servico|Servico|50"
                            , new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido, TP_Mov }, new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void CFG_Pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + CFG_Pedido.Text.Trim() + "';" +
                            "A.TP_Movimento|=|'S';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_Pedido, DS_CFGPedido, TP_Mov }, new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void BB_Moeda_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_Moeda_Singular|Moeda|200;Sigla|Sigla|80;CD_Moeda|Cód. Moeda|80"
                                      , new Componentes.EditDefault[] { CD_Moeda, DS_Moeda, Sigla_Moeda }, new CamadaDados.Financeiro.Cadastros.TCD_Moeda(),
                                      null);
        }

        private void CD_Moeda_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_Moeda|=|'" + CD_Moeda.Text + "'"
                            , new Componentes.EditDefault[] { CD_Moeda, DS_Moeda, Sigla_Moeda }, new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

       
        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;c.cd_uf|uf|50;c.DS_UF|Estado|150"
             , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text + "'");
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
           UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + CD_Clifor.Text + "'"
           , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());       

        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90"
                , new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), null);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                , new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90"
                , new Componentes.EditDefault[] { cd_transportadora, ds_transportadora }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), "isnull(a.st_transportadora, 'N')|=|'S'");
        }

        private void cd_transportadora_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "';isnull(a.st_transportadora, 'N')|=|'S'"
                , new Componentes.EditDefault[] { cd_transportadora, ds_transportadora }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void CD_Endereco_Enter(object sender, EventArgs e)
        {
            this.BuscarEndClifor();
        }

        private void bb_endtransp_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;c.cd_uf|uf|50;c.DS_UF|Estado|150"
             , new Componentes.EditDefault[] { cd_endtransp, ds_endtransp }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "'");
        }

        private void cd_endtransp_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + cd_endtransp.Text.Trim() + "';a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "'"
           , new Componentes.EditDefault[] { cd_endtransp, ds_endtransp }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());       
        }

        private void cd_endtransp_Enter(object sender, EventArgs e)
        {
            this.BuscarEndTransp();
        }
    }
}
