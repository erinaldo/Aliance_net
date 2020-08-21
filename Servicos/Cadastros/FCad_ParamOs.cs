using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaNegocio.Servicos.Cadastros;
using CamadaDados.Servicos.Cadastros;
using CamadaDados.Diversos;
using FormBusca;
using Utils;
using CamadaDados.Faturamento.Cadastros;

namespace Servicos.Cadastros
{
    public partial class TFCad_ParamOs : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_ParamOs()
        {
            InitializeComponent();
            DTS = BS_CadParamOS;
        }

        private void BuscarEnd()
        {
            if (cd_transportadora.Text.Trim() != string.Empty)
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'"+cd_transportadora.Text.Trim()+"'"
                        }
                    }, "a.cd_endereco");
                if (obj != null)
                    cd_enderecotransp.Text = obj.ToString();
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                BS_CadParamOS.AddNew();
            base.afterNovo();
            tp_ordem.Focus();
            
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo.Equals(TTpModo.tm_Edit))
                bb_ordem.Enabled = false;
        }

        public override void afterCancela()
        {
            base.afterCancela();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                try
                {
                    return TCN_OSE_ParamOS.Gravar_OSE_ParamOS(BS_CadParamOS.Current as TRegistro_OSE_ParamOS, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro gravar config. " + ex.Message.Trim());
                    return string.Empty;
                }
            else
                return string.Empty;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_OSE_ParamOS.Deletar_OSE_ParamOS(BS_CadParamOS.Current as TRegistro_OSE_ParamOS,null);
                    BS_CadParamOS.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override int buscarRegistros()
        {
            TList_OSE_ParamOS lista = TCN_OSE_ParamOS.Buscar(tp_ordem.Text,
                                                             Cd_Moeda.Text,
                                                             Cd_PedidoItem.Text,
                                                             Cd_PedidoServico.Text,
                                                             Cd_Pedido_Garantia.Text,
                                                             Cd_PedidoTranspRemessa.Text,
                                                             cd_produtofrete.Text,
                                                             cd_transportadora.Text,
                                                             cd_enderecotransp.Text,
                                                             0,
                                                             string.Empty,
                                                             null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadParamOS.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadParamOS.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        private void bb_Moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_Moeda_Singular|Descrição Moeda|350;" +
                         "a.cd_Moeda|Cód. Moeda|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_Moeda, Ds_Moeda},
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda(), "");
        }

        private void Cd_Moeda_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_Moeda |=| '" + Cd_Moeda.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Cd_Moeda, Ds_Moeda},
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

        private void bb_PedidoItem_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_TipoPedido|Tipo Pedido|350;" +
                         "a.CFG_Pedido|Cód. CFG Pedido|100";
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_PedidoItem, Ds_PedidoItem },
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void PedidoItem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + Cd_PedidoItem.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_PedidoItem, Ds_PedidoItem},
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void bb_PedidoServico_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_TipoPedido|Tipo Pedido|350;" +
                         "a.CFG_Pedido|Cód. CFG Pedido|100";
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_PedidoServico, Ds_PedidoServico },
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void bb_Pedido_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_TipoPedido|Tipo Pedido|350;" +
                         "a.CFG_Pedido|Cód. CFG Pedido|100";
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_Pedido_Garantia, Ds_Pedido},
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void bb_PedidoTransp_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_TipoPedido|Tipo Pedido|350;" +
                         "a.CFG_Pedido|Cód. CFG Pedido|100";
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_PedidoTranspRemessa },
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void PedidoServico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + Cd_PedidoServico.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_PedidoServico, Ds_PedidoServico },
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));

        }

        private void Pedido_Garantia_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + Cd_Pedido_Garantia.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_Pedido_Garantia, Ds_Pedido},
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void PedidoTranspRemessa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + Cd_PedidoTranspRemessa.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_PedidoTranspRemessa },
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void bb_ordem_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_tipoordem|Tipo Ordem|200;" +
                              "TP_Ordem|TP. Ordem|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_ordem, ds_tipoordem },
                                    new TCD_TpOrdem(), string.Empty);
        }

        private void tp_ordem_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.tp_ordem|=|" + tp_ordem.Text.Trim();
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { tp_ordem, ds_tipoordem },
                                    new TCD_TpOrdem());
        }

        private void bb_transpremessaenvio_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_TipoPedido|Tipo Pedido|350;" +
                         "a.CFG_Pedido|Cód. CFG Pedido|100";
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedido_transpremessaenvio },
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void cfg_pedido_transpremessaenvio_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + cfg_pedido_transpremessaenvio.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedido_transpremessaenvio },
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void bb_produtofrete_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produtofrete, ds_produtofrete }, string.Empty);
        }

        private void cd_produtofrete_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produtofrete.Text.Trim() + "'",
                                            new Componentes.EditDefault[] { cd_produtofrete, ds_produtofrete },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100;" +
                "a.cd_transportador|Cd. Tranportadora|80;" +
                "transp.nm_clifor|Transportadora|200;" +
                "a.cd_endereco_transp|Cd. Transportadora|80;" +
                "endTransp.ds_endereco|Endereco Transportadora|200"
                , new Componentes.EditDefault[] { cd_transportadora, nm_transportadora },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), "isnull(a.st_registro, 'A')|<>|'C';isnull(a.st_transportadora, 'N')|=|'S'");
            this.BuscarEnd();
        }

        private void cd_transportadora_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "isnull(a.st_fornecedor, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_transportadora, nm_transportadora },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.BuscarEnd();
        }

        private void bb_enderecotransp_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereco|150;" +
                              "a.cd_endereco|Código Endereço|80;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "a.UF|Estado|150;" +
                              "a.fone|Telefone|80";
            string vParam = "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_enderecotransp },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
        }

        private void cd_enderecotransp_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_enderecotransp.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + cd_transportadora.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_enderecotransp },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void TFCad_ParamOs_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                              "a.tp_duplicata|TP. Duplicata|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), "a.tp_mov|=|'R'");
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_docto.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdocto|Tipo Documento|200;" +
                              "a.tp_docto|TP. Docto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico Financeiro|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.tp_mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[]{cd_historico, ds_historico},
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_servicopadrao_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_servicopadrao }, "isnull(e.st_servico, 'N')|=|'S'");
        }

        private void cd_servicopadrao_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_servicopadrao.Text.Trim() + "';" +
                                           "isnull(e.st_servico, 'N')|=|'S'",
                                           new Componentes.EditDefault[] { cd_servicopadrao },
                                           new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void TFCad_ParamOs_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco },
                                    new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabelapreco },
                                    new CamadaDados.Diversos.TCD_CadTbPreco());
        }
    }
}
