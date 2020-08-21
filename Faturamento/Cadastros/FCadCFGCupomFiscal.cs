using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Faturamento.Cadastros
{
    public partial class TFCadCFGCupomFiscal : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCFGCupomFiscal()
        {
            InitializeComponent();
            this.DTS = bsCfGCupom;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Gravar(
                    bsCfGCupom.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lista =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(cd_empresa.Text,
                                                                              null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfGCupom.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCfGCupom.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsCfGCupom.AddNew();
                base.afterNovo();
                cd_empresa.Focus();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfGCupom.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                cd_historico.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Excluir(
                        bsCfGCupom.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal, null);
                    bsCfGCupom.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, 
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, 
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.tp_mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_transf_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.tp_mov|=|'R';" +
                            "isnull(a.st_transferencia, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_transf, ds_historico_transf },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_transf_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico_transf.Text.Trim() + "';" +
                            "a.tp_mov|=|'R';" +
                            "isnull(a.st_transferencia, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico_transf, ds_historico_transf },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Cd. Tabela|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                    new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                    new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_local|Local Armazenagem|200;" +
                              "a.cd_local|Cd. Local|80";
            string vParam = "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_local|=|'" + cd_local.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Cliente|200;" +
                              "a.cd_clifor|Cd. Cliente|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_clifor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_clifor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
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

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdocto|Tipo Documento|200;" +
                              "a.tp_docto|TP. Docto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_docto.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void TFCadCFGCupomFiscal_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.pDados.set_FormatZero();
        }

        private void bb_historico_ret_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.tp_mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_ret },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_ret_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "';" +
                            "a.tp_mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico_ret },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historicocaixa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.tp_mov|=|'R';" +
                            "isnull(a.st_transferencia, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicocaixa, ds_historicocaixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historicocaixa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico_transf.Text.Trim() + "';" +
                            "a.tp_mov|=|'R';" +
                            "isnull(a.st_transferencia, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historicocaixa, ds_historicocaixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Cd. Conta|80";
            string vParam = "isnull(a.st_contacompensacao, 'N')|=|'N';" +
                            "a.st_contaCF|=|1;" +
                            "a.st_contacartao|=|1;" +
                            "|exists|(select 1 from TB_FIN_ContaGer_X_Empresa x " +
                            "         where x.cd_contager = a.cd_contager " +
                            "         and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contacaixa, ds_contacaixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contacaixa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contacaixa.Text.Trim() + "';" +
                            "isnull(a.st_contacompensacao, 'N')|=|'N';" +
                            "a.st_contaCF|=|1;" +
                            "a.st_contacartao|=|1;" +
                            "|exists|(select 1 from TB_FIN_ContaGer_X_Empresa x " +
                            "         where x.cd_contager = a.cd_contager " +
                            "         and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contacaixa, ds_contacaixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_movimentacao|Movimentação Comercial|200;" +
                              "a.cd_movimentacao|Cd. Movimentação|80";
            string vParam = "a.tp_movimento|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao },
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao(), vParam);
        }

        private void cd_movimentacao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_movimentacao|=|" + cd_movimentacao.Text + ";" +
                            "a.tp_movimento|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_movimentacao, ds_movimentacao },
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_serie_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_serienf|Serie Nota|200;" +
                              "a.nr_serie|Nº Serie|80;" +
                              "a.cd_modelo|Cd. Modelo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_serie, ds_serienf, cd_modelo },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), string.Empty);
        }

        private void nr_serie_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_serie|=|'" + nr_serie.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_serie, ds_serienf, cd_modelo },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
        }

        private void bb_historico_troco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.tp_mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_troco },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_troco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico_troco.Text.Trim() + "';" +
                            "a.tp_mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico_troco },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_cfgpedido_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TipoPedido|DS CFG Pedido|300;" +
                              "a.CFG_Pedido|CD. CFG Pedido|80";
            string vParam = "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas,
                            new Componentes.EditDefault[] { cfg_pedido },
                            new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), vParam);
        }

        private void cfg_pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + cfg_pedido.Text.Trim() + "';" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedido },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_historico_sobracaixa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.tp_mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_sobracaixa, ds_historico_sobracaixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_sobracaixa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico_sobracaixa.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico_sobracaixa, ds_historico_sobracaixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_faltacaixa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.tp_mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_faltacaixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_faltacaixa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico_faltacaixa.Text.Trim() + "';" +
                            "a.tp_mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico_faltacaixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_cfgpedidovinculado_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TipoPedido|DS CFG Pedido|300;" +
                              "a.CFG_Pedido|CD. CFG Pedido|80";
            string vParam = "isnull(a.st_vincularcf, 'N')|=|'S';" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'S'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedidovinculado },
                                                        new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), vParam);
        }

        private void cfg_pedidovinculado_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + cfg_pedidovinculado.Text.Trim() + "';" +
                            "isnull(a.st_vincularcf, 'N')|=|'S';" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedidovinculado },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_contacartao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Cd. Conta|80";
            string vParam = "a.st_contacartao|=|0;" +
                            "a.st_contaCF|=|1;" +
                            "|exists|(select 1 from TB_FIN_ContaGer_X_Empresa x " +
                            "         where x.cd_contager = a.cd_contager " +
                            "         and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contacartao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contacartao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contacartao.Text.Trim() + "';" +
                            "a.st_contacartao|=|0;" +
                            "a.st_contaCF|=|1;" +
                            "|exists|(select 1 from TB_FIN_ContaGer_X_Empresa x " +
                            "         where x.cd_contager = a.cd_contager " +
                            "         and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contacartao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_contaoperacional_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Operacional|200;" +
                              "a.cd_contager|Cd. Conta|80";
            string vParam = "a.st_contaCF|=|0;" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "           where x.cd_contager = a.cd_contager " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contaoperacional },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
            
        }

        private void cd_contaoperacional_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contaoperacional.Text.Trim() + "';" +
                            "a.st_contaCF|=|0;" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "           where x.cd_contager = a.cd_contager " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contaoperacional },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_cfgpedservico_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TipoPedido|DS CFG Pedido|300;" +
                              "a.CFG_Pedido|CD. CFG Pedido|80";
            string vParam = "isnull(a.st_servico, 'N')|=|'S';" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'S'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedservico },
                                                        new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), vParam);
        }

        private void cfg_pedservico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + cfg_pedservico.Text.Trim() + "';" +
                            "isnull(a.st_servico, 'N')|=|'S';" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedservico },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_cfgvendaconsumo_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TipoPedido|DS CFG Pedido|300;" +
                              "a.CFG_Pedido|CD. CFG Pedido|80";
            string vParam = "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'S'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedvendaconsumo },
                                                        new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), vParam);
        }

        private void cfg_pedvendaconsumo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + cfg_pedvendaconsumo.Text.Trim() + "';" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedvendaconsumo },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void TFCadCFGCupomFiscal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }

        private void bb_centroresult_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResult fBusca = new TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                        cd_centroresult.Text = fBusca.Cd_centro;
            }
        }

        private void cd_centroresult_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "a.tp_registro|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_pedcondicional_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TipoPedido|DS CFG Pedido|300;" +
                              "a.CFG_Pedido|CD. CFG Pedido|80";
            string vParam = "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'S'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedcondicional },
                                                        new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), vParam);
        }

        private void cfg_pedcondicional_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + cfg_pedcondicional.Text.Trim() + "';" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedcondicional },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_cfgpeddevolucao_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TipoPedido|DS CFG Pedido|300;" +
                              "a.CFG_Pedido|CD. CFG Pedido|80";
            string vParam = "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'E'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_peddevolucao },
                                                        new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), vParam);
        }

        private void cfg_peddevolucao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + cfg_peddevolucao.Text.Trim() + "';" +
                            "isnull(a.st_permitelanpedido, 'N')|=|'S';" +
                            "a.tp_movimento|=|'E'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_peddevolucao },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_serienfce_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_serienf|Serie Nota|200;" +
                              "a.nr_serie|Nº Serie|80;" +
                              "a.cd_modelo|Cd. Modelo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_serienfce, ds_serienfce, cd_modelonfce },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), "a.cd_modelo|=|'65'");
        }

        private void nr_serienfce_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_serie|=|'" + nr_serie.Text.Trim() + "';a.cd_modelo|=|'65'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_serienfce, ds_serienfce, cd_modelonfce },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Código|60;" +
                              "a.qt_diasdesdobro|Dias Parcela|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "'isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto }, new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void cd_centroresultfrete_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresultfrete.Text.Trim() + ";" +
                           "isnull(a.st_sintetico, 'N')|<>|'S';" +
                           "a.tp_registro|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresultfrete },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_centroresultfrete_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResult fBusca = new TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                        cd_centroresultfrete.Text = fBusca.Cd_centro;
            }
        }

        private void cd_centroresultbaixa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresultbaixa.Text.Trim() + ";" +
                           "isnull(a.st_sintetico, 'N')|<>|'S';" +
                           "a.tp_registro|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresultbaixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_centroresultbaixa_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResult fBusca = new TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                        cd_centroresultbaixa.Text = fBusca.Cd_centro;
            }
        }
    }
}
