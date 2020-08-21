using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using Querys;
using Querys.Estoque;
using Querys.Diversos;
using Querys.Financeiro;
using Querys.Faturamento;
using FormBusca;
using CamadaDados.Balanca;
using CamadaNegocio.Balanca;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Financeiro.Cadastros;
using Financeiro;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Graos;

namespace Commoditties.Relatorios
{
    public partial class TFRel_HistoricoContrato : FormRelPadrao.FRelPadrao
    {
        public TFRel_HistoricoContrato()
        {
            InitializeComponent();
        }

        #region "Opções de Filtros"

            private void bb_empresa_Click(object sender, EventArgs e)
            {
                UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
                    , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new TDatEmpresa(),
                    "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)");
            }

            private void cd_empresa_Leave(object sender, EventArgs e)
            {
                UtilPesquisa.EDIT_LEAVE("cd_empresa|=|'" + cd_empresa.Text + "';" +
                            "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)"
                            , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new TDatEmpresa());
            }

            private void bb_pedido_Click(object sender, EventArgs e)
            {
                string vColunas = "a.NR_Pedido|Nº Pedido|80;" +
                                  "contrato.NR_Contrato|Nº Contrato|80;" +
                                  "a.CD_Clifor|Cód. Clifor|80;" +
                                  "clifor.NM_Clifor|Nome Clifor|350;" +
                                  "clifor.NR_CGC_CPF|CNPJ/CPF|150;" +
                                  "b.CD_Produto|Cód. Produto|80;" +
                                  "d.DS_Produto|Descrição Produto|350;" +
                                  "contrato.TP_Natureza_Pesagem|Origem/Destino|100;" +
                                  "n.cfg_pedido|CFG. Pedido|100;" +
                                  "cfgped.ds_tipopedido|Tipo Pedido|100";

                string vParamFixo = "n.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                    "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = n.cd_empresa);" +
                                    "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                    "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto)";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_pedido, cd_clifor, nm_clifor, cfg_pedido, ds_tipopedido }, new TCD_LanPedido_Item(), vParamFixo);
            }

            private void nr_pedido_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.nr_pedido|=|" + nr_pedido.Text + ";" +
                                  "n.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = n.cd_empresa);" +
                                    "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                    "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto)";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { nr_pedido, cd_clifor, nm_clifor, cfg_pedido, ds_tipopedido },
                                        new TCD_LanPedido_Item());
            }

            private void bb_tipo_Click(object sender, EventArgs e)
            {
                string vColunas = "DS_TipoPedido|Tipo Pedido|350;" +
                                  "CFG_Pedido|CFG. Pedido|80";
                string vParamFixo = "";
                if (nr_pedido.Text.Trim() != "")
                    vParamFixo = "|EXISTS|(Select 1 From TB_FAT_Pedido x Where x.CFG_Pedido = TB_FAT_CFGPedido.CFG_Pedido and x.NR_Pedido = " + nr_pedido.Text + ")";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                                        new TDatCFG_Pedidos(), vParamFixo);
            }

            private void cfg_pedido_Leave(object sender, EventArgs e)
            {
                string vColunas = "CFG_Pedido|=|'" + cfg_pedido.Text + "'";
                if (nr_pedido.Text.Trim() != "")
                    vColunas += ";|EXISTS|(Select 1 From TB_FAT_Pedido x Where x.CFG_Pedido = TB_FAT_CFGPedido.CFG_Pedido and x.NR_Pedido = " + nr_pedido.Text + ")";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                                        new TDatCFG_Pedidos());
            }

            private void bb_clifor_Click(object sender, EventArgs e)
            {
                string vColunas = "a.NM_Clifor|Nome Clifor|350;" +
                                  "a.CD_Clifor|Cód. Clifor|100";
                string vParamFixo = "";
                if (nr_pedido.Text.Trim() != "")
                    vParamFixo = "|EXISTS|(Select 1 From TB_FAT_Pedido x Where x.CD_Clifor = a.CD_Clifor and x.NR_Pedido = " + nr_pedido.Text + ")";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                        new TDatClifor(), vParamFixo);
            }

            private void cd_clifor_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Clifor|=|'" + cd_clifor.Text + "'";
                if (nr_pedido.Text.Trim() != "")
                    vColunas += ";|EXISTS|(Select 1 From TB_FAT_Pedido x Where x.CD_Clifor = a.CD_Clifor and x.NR_Pedido = " + nr_pedido.Text + ")";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                        new TDatClifor());
            }

            private void bbProduto_Click(object sender, EventArgs e)
            {
                string vColunas = "a.DS_Produto|Descrição Produto|350;" +
                              "a.CD_Produto|Cód. Produto|100;" +
                              "a.Sigla|Sigla|20";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                        new TCD_CadProduto(), "");
            }

            private void Cd_Produto_Busca_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Produto|=|'" + CD_Produto.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                        new TCD_CadProduto());
            }

            private void bb_contrato_Click(object sender, EventArgs e)
            {
                string vColunas = "d.nm_clifor|Nome Contratante|250;" +
                                  "a.cd_clifor|Cd. Contratante|80;" +
                                  "f.nm_empresa|Empresa|250;" +
                                  "a.cd_empresa|Cd. Empresa|80;" +
                                  "a.nr_contrato|Nº Contrato|80";
                string vParam = string.Empty;
                string pontoevirgula = string.Empty;
                if (cd_empresa.Text.Trim() != string.Empty)
                {
                    vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
                    pontoevirgula = ";";
                }
                else
                {
                    vParam += pontoevirgula + "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                             "where x.cd_empresa = a.cd_empresa " +
                             "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                             "(exists(select 1 from tb_div_usuario_x_grupos y " +
                             "          where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
                }
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Nr_Contrato },
                                        new TCD_CadContrato(), vParam);
            }

            private void Nr_Contrato_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.nr_contrato|=|" + Nr_Contrato.Text + ";";
                if (cd_empresa.Text.Trim() != string.Empty)
                    vColunas += "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
                else
                {
                    vColunas += "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                                "where x.cd_empresa = a.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
                }
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Nr_Contrato },
                                        new TCD_CadContrato());
            }

        #endregion
    }
}
