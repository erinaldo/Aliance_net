using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Servicos.Cadastros;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Financeiro.Cadastros;

namespace Locacao.Cadastros
{
    public partial class TFCFGLocacao : FormCadPadrao.FFormCadPadrao
    {
        public TFCFGLocacao()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Locacao.Cadastros.TCN_CFGLocacao.Gravar(
                    bsCFGLocacao.Current as CamadaDados.Locacao.Cadastros.TRegistro_CFGLocacao, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Locacao.Cadastros.TList_CFGLocacao lista =
                CamadaNegocio.Locacao.Cadastros.TCN_CFGLocacao.buscar(cd_empresa.Text,
                                                                      tp_ordem.Text,
                                                                      null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCFGLocacao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCFGLocacao.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsCFGLocacao.AddNew();
                base.afterNovo();
                cd_empresa.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCFGLocacao.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                cd_empresa.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Locacao.Cadastros.TCN_CFGLocacao.Excluir(
                        bsCFGLocacao.Current as CamadaDados.Locacao.Cadastros.TRegistro_CFGLocacao, null);
                    bsCFGLocacao.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void tp_ordem_Leave(object sender, EventArgs e)
        {

            string vColunas = "tp_ordem|=|" + tp_ordem.Text.Trim();
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { tp_ordem, ds_tipoordem },
                                    new TCD_TpOrdem());
        }

        private void bb_ordem_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_tipoordem|Tipo Ordem|200;" +
                              "TP_Ordem|TP. Ordem|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_ordem, ds_tipoordem },
                                    new TCD_TpOrdem(), string.Empty);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                           "a.tp_mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                             "a.tp_duplicata|TP. Duplicata|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), "a.tp_mov|=|'R'");
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

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico Financeiro|200;" +
                             "a.cd_historico|Cd. Historico|80";
            string vParam = "a.tp_mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
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

        private void Cd_PedidoServico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + Cd_PedidoServico.Text.Trim() + "';" +
                           "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                           "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                           "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_PedidoServico, Ds_PedidoServico },
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_config|Configuração Boleto|200;" +
                              "a.id_config|Id. Config.|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_config, ds_config },
                new TCD_CadCFGBanco(), "a.st_registro|<>|'C'");
        }

        private void id_config_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_config|=|" + id_config.Text + ";" +
                            "a.st_registro|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_config, ds_config }, new TCD_CadCFGBanco());
        }
                
        private void bb_centroresultdia_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResult fBusca = new TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresultdia.Text = fBusca.Cd_centro;
                        ds_centroresultdia.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresultdia_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresultdia.Text.Trim() + ";" +
                           "isnull(a.st_sintetico, 'N')|<>|'S';" +
                           "a.tp_registro|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresultdia, ds_centroresultdia },
                                    new TCD_CentroResultado());
        }

        private void bb_centroresultsem_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResult fBusca = new TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresultsem.Text = fBusca.Cd_centro;
                        ds_centroresultsem.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresultsem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresultsem.Text.Trim() + ";" +
                           "isnull(a.st_sintetico, 'N')|<>|'S';" +
                           "a.tp_registro|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresultsem, ds_centroresultsem },
                                    new TCD_CentroResultado());
        }

        private void bb_centroresultquinz_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResult fBusca = new TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresultquinz.Text = fBusca.Cd_centro;
                        ds_centroresultquinz.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresultquinz_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresultquinz.Text.Trim() + ";" +
                           "isnull(a.st_sintetico, 'N')|<>|'S';" +
                           "a.tp_registro|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresultquinz, ds_centroresultquinz },
                                    new TCD_CentroResultado());
        }

        private void bb_centroresultmes_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResult fBusca = new TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresultmes.Text = fBusca.Cd_centro;
                        ds_centroresultmes.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresultmes_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresultmes.Text.Trim() + ";" +
                           "isnull(a.st_sintetico, 'N')|<>|'S';" +
                           "a.tp_registro|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresultmes, ds_centroresultmes },
                                    new TCD_CentroResultado());
        }

        private void bb_tpprodcombustivel_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_tpproduto|Tipo Produto|200;a.tp_produto|TP. Produto|80",
                new Componentes.EditDefault[] { tp_prodcombustivel, ds_tpprodcombustivel },
                new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(), string.Empty);
        }

        private void tp_prodcombustivel_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.tp_produto|=|'" + tp_prodcombustivel.Text.Trim() + "'",
                new Componentes.EditDefault[] { tp_prodcombustivel, ds_tpprodcombustivel },
                new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());
        }

        private void BB_Tp_Ordemp_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_tipoordem|Tipo Ordem|200;" +
                              "TP_Ordem|TP. Ordem|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_ordemp, ds_tipoordemp },
                                    new TCD_TpOrdem(), string.Empty);
        }
    }
}
