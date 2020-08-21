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
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Estoque;
using CamadaDados.Estoque;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Graos;
using CamadaDados.Graos;
using CamadaDados.Faturamento.NotaFiscal;
using Faturamento;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Fiscal;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Adiantamento;
using CamadaNegocio.Financeiro.Duplicata;
using Financeiro;
using NumeroNota;

namespace Commoditties
{
    public partial class TFLan_Transferencia : FormPadrao.FFormPadrao
    {
        public TFLan_Transferencia()
        {
            InitializeComponent();
        }

        private void BB_Pedido_Click(object sender, EventArgs e)
        {
            string vColunas = "contrato.NR_Contrato|NRº Contrato|80;" +
                              "n.CD_Empresa|Cód. Empresa|80;" +
                              "n.NM_Empresa|Empresa |100;" +
                              "a.NR_Pedido|NRº Pedido|80;" +
                              "n.DT_Pedido|Data|80;" +
                              "n.TP_MOVIMENTO|Tipo Movimento|80;" +
                              "a.CD_Clifor|Cód. Clifor|80;" +
                              "clifor.NM_Clifor|Nome Clifor|150;" +
                              "clifor.NR_CGC_CPF|CNPJ/CPF|150;" +
                              "endereco.ds_endereco|Endereço|100;" +
                              "endereco.ds_cidade|Cidade|100;" +
                              "endereco.UF|UF|40;" +
                              "a.CD_Produto|Cód. Produto|80;" +
                              "d.DS_Produto|Descrição Produto|150;" +
                              "a.CD_Local|Cód. Local|80;" +
                              "d.DS_Local|Local Armazenagem|150;" +
                              "a.CD_Variedade|Cód. Variedade|80;" +
                              "e.DS_Variedade|Variedade|150;" +
                              "a.VL_Unitario|Valor Unitário|90;" +
                              "sg_unidade_valor|Unidade Valor|40;" +
                              "cd_unidade_valor|Cód. Unidade Valor|80;" +
                              "a.Quantidade|Quantidade|90;" +
                              "sg_unidade_est|Unidade Estoque|40;" +
                              "cd_unidade_est|Cód. Unidade Estoque|80";
                                   

            string vParamFixo =
                // O Tipo De pedido tem que permitir transferência
                                "cfgped.ST_PermiteTransf|=|'S';" +
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = n.cfg_pedido " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Pedido tem que estar amarrado a um contrato
                                 "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                 "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto); " +
                // O parte Fiscal Pedido tem que ser deposito
                               "|EXISTS|(select 1 from tb_fat_pedido_Fiscal x " +
                              "where x.nr_pedido = a.nr_pedido and x.TP_Fiscal = 'D') ";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { NR_Pedido,
               NR_Contrato,
               DT_Pedido,
               TP_Movimento,
               CD_Empresa,
               NM_Empresa,
               CD_Clifor,
               NM_Clifor,
               CPF,
               DS_Endereco,
               DS_Cidade,
               UF,
               CD_Produto,
               DS_Produto,
               CD_Local,
               DS_Local,
               VL_Unitario,
               QTD_Origem,
            CD_Unidade_Origem_Est,
            CD_Unidade_Origem_VL,
            Unidade_Origem_Est,
            Unidade_Origem_VL,
            }, new TCD_LanPedido_Item(), vParamFixo);



            if (NR_Pedido.Text.Trim().Equals(string.Empty))
            {
                NR_Pedido.Clear();
                NR_Contrato.Clear();
                DT_Pedido.Clear();
                TP_Movimento.Clear();
                CD_Empresa.Clear();
                NM_Empresa.Clear();
                CD_Clifor.Clear();
                NM_Clifor.Clear();
                CPF.Clear();
                DS_Endereco.Clear();
                DS_Cidade.Clear();
                UF.Clear();
                CD_Produto.Clear();
                DS_Produto.Clear();
                CD_Local.Clear();
                DS_Local.Clear();
                Saldo_Origem.Clear();
                VL_Unitario.Clear();
                VL_Sub_Total_Origem.Value = 0;
                VL_Unitario_Transf.Value = 0;
                QTD_Transferir.Value = 0;
                QTD_Origem.Clear();
                CD_Unidade_Origem_Est.Clear();
                CD_Unidade_Origem_VL.Clear();
                Unidade_Origem_Est.Clear();
                Unidade_Origem_VL.Clear();
            }
            else
            {
                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text));
                Busca_Saldo_Contrato_Origem();
                Valores_Fixos();

                
                    if ((Saldo_Contrato_Origem.Text.Trim() != "") && (Saldo_Contrato_Origem.Text.Trim() != "0"))
                    {
                        try
                        {
                            QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);

                            if ((Saldo_Origem.Text.Trim() != "") && (Saldo_Origem.Text.Trim() != "0"))
                            {
                                if (Convert.ToDecimal(Saldo_Contrato_Origem.Text) > Convert.ToDecimal(Saldo_Origem.Text))
                                {
                                    QTD_Transferir.Value = Convert.ToDecimal(Saldo_Origem.Text);
                                }
                            }                            
                        }
                        catch
                        {
                        }
                    }
                

                
                    if ((VL_Unitario.Text.Trim() != "") && (VL_Unitario.Text.Trim() != "0"))
                    {
                        try
                        {
                            VL_Unitario_Transf.Value = Convert.ToDecimal(VL_Unitario.Text);
                            
                            if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                                VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value); 
                            else
                                VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                        }
                        catch
                        {
                        }
                    }
                

                NR_Pedido_Destino.Clear();
                NR_Contrato_Destino.Clear();
                DT_Pedido_Destino.Clear();
                TP_Movimento_Destino.Clear();
                CD_Empresa_Destino.Clear();
                NM_Empresa_Destino.Clear();
                CD_Clifor_Destino.Clear();
                NM_Clifor_Destino.Clear();
                CPF_Destino.Clear();
                DS_Endereco_Destino.Clear();
                DS_Cidade_Destino.Clear();
                UF_Destino.Clear();
                CD_Produto_Destino.Clear();
                DS_Produto_Destino.Clear();
                CD_Local_Destino.Clear();
                DS_Local_Destino.Clear();
                Saldo_Destino.Clear();
                VL_Unitario_Destino.Clear();
                
                VL_Sub_Total_Destino.Value = 0;
                VL_Unitario_Destino_Transf.Value = 0;
                
                QTD_Destino.Clear();
                CD_Unidade_Destino_Est.Clear();
                CD_Unidade_Destino_VL.Clear();
                Unidade_Destino_Est.Clear();
                Unidade_Destino_VL.Clear();
            }

        }

        private void NR_Pedido_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.NR_Pedido|=|" + NR_Pedido.Text + ";" +

                // O Tipo De pedido tem que permitir transferência
                                "cfgped.ST_PermiteTransf|=|'S';" +
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = n.cfg_pedido " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Pedido tem que estar amarrado a um contrato
                                 "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                 "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto); " +
                // O parte Fiscal Pedido tem que te ser deposito
                                 "|EXISTS|(select 1 from tb_fat_pedido_Fiscal x " +
                                "where x.nr_pedido = a.nr_pedido and x.TP_Fiscal = 'D') "

            , new Componentes.EditDefault[] { 
               NR_Pedido,
               NR_Contrato,
               DT_Pedido,
               TP_Movimento,
               CD_Empresa,
               NM_Empresa,
               CD_Clifor,
               NM_Clifor,
               CPF,
               DS_Endereco,
               DS_Cidade,
               UF,
               CD_Produto,
               DS_Produto,
               CD_Local,
               DS_Local,
               VL_Unitario,
               QTD_Origem,
                CD_Unidade_Origem_Est,
                CD_Unidade_Origem_VL,
                Unidade_Origem_Est,
                Unidade_Origem_VL
            }, new TCD_LanPedido_Item());

            if (NR_Pedido.Text.Trim().Equals(string.Empty))
            {
                NR_Pedido.Clear();
                NR_Contrato.Clear();
                DT_Pedido.Clear();
                TP_Movimento.Clear();
                CD_Empresa.Clear();
                NM_Empresa.Clear();
                CD_Clifor.Clear();
                NM_Clifor.Clear();
                CPF.Clear();
                DS_Endereco.Clear();
                DS_Cidade.Clear();
                UF.Clear();
                CD_Produto.Clear();
                DS_Produto.Clear();
                CD_Local.Clear();
                DS_Local.Clear();
                Saldo_Origem.Clear();
                VL_Unitario.Clear();
                VL_Sub_Total_Origem.Value = 0;
                VL_Unitario_Transf.Value = 0;
                QTD_Transferir.Value = 0;
                QTD_Origem.Clear();
                CD_Unidade_Origem_Est.Clear();
                CD_Unidade_Origem_VL.Clear();
                Unidade_Origem_Est.Clear();
                Unidade_Origem_VL.Clear();
            }
            else
            {
                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text));
                Busca_Saldo_Contrato_Origem();
                Valores_Fixos();


                if ((Saldo_Contrato_Origem.Text.Trim() != "") && (Saldo_Contrato_Origem.Text.Trim() != "0"))
                {
                    try
                    {
                        QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);

                        if ((Saldo_Origem.Text.Trim() != "") && (Saldo_Origem.Text.Trim() != "0"))
                        {
                            if (Convert.ToDecimal(Saldo_Contrato_Origem.Text) > Convert.ToDecimal(Saldo_Origem.Text))
                            {
                                QTD_Transferir.Value = Convert.ToDecimal(Saldo_Origem.Text);
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                

                
                    if ((VL_Unitario.Text.Trim() != "") && (VL_Unitario.Text.Trim() != "0"))
                    {
                        try
                        {
                            VL_Unitario_Transf.Value = Convert.ToDecimal(VL_Unitario.Text);

                            if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                                VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value);
                            else
                                VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                        }
                        catch
                        {
                        }
                    }
                

                NR_Pedido_Destino.Clear();
                NR_Contrato_Destino.Clear();
                DT_Pedido_Destino.Clear();
                TP_Movimento_Destino.Clear();
                CD_Empresa_Destino.Clear();
                NM_Empresa_Destino.Clear();
                CD_Clifor_Destino.Clear();
                NM_Clifor_Destino.Clear();
                CPF_Destino.Clear();
                DS_Endereco_Destino.Clear();
                DS_Cidade_Destino.Clear();
                UF_Destino.Clear();
                CD_Produto_Destino.Clear();
                DS_Produto_Destino.Clear();
                CD_Local_Destino.Clear();
                DS_Local_Destino.Clear();
                Saldo_Destino.Clear();
                VL_Unitario_Destino.Clear();
                
                VL_Sub_Total_Destino.Value = 0;
                VL_Unitario_Destino_Transf.Value = 0;
                
                QTD_Destino.Clear();
                CD_Unidade_Destino_Est.Clear();
                CD_Unidade_Destino_VL.Clear();
                Unidade_Destino_Est.Clear();
                Unidade_Destino_VL.Clear();
            }

        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {                              
            if (!(NR_Pedido.Text.Trim().Equals(string.Empty)))
            {
                string vColunas = "b.DS_Produto|Descrição Produto|350;" +
                                  "a.CD_Produto|Cód. Produto|100;" +
                                  "a.Quantidade|Quantidade|80;" +
                                   "sg_unidade_est|Unidade Estoque|40;" +
                              "cd_unidade_est|Cód. Unidade Estoque|80;" +
                                  "a.VL_Unitario|Valor Unitário|100;" +
                "sg_unidade_valor|Unidade Valor|40;" +
                "cd_unidade_valor|Cód. Unidade Valor|80";
                string vParamFixo = "n.nr_Pedido|=|" + NR_Pedido.Text;

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto, QTD_Origem, VL_Unitario, 
                CD_Unidade_Origem_Est,
                CD_Unidade_Origem_VL,
                Unidade_Origem_Est,
                Unidade_Origem_VL,
                },new TCD_LanPedido_Item(), vParamFixo);

                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text));
                Busca_Saldo_Contrato_Origem();

                if ((Saldo_Contrato_Origem.Text.Trim() != "") && (Saldo_Contrato_Origem.Text.Trim() != "0"))
                {
                    try
                    {
                        QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);

                        if ((Saldo_Origem.Text.Trim() != "") && (Saldo_Origem.Text.Trim() != "0"))
                        {
                            if (Convert.ToDecimal(Saldo_Contrato_Origem.Text) > Convert.ToDecimal(Saldo_Origem.Text))
                            {
                                QTD_Transferir.Value = Convert.ToDecimal(Saldo_Origem.Text);
                            }
                        }
                    }
                    catch
                    {
                    }
                }



                if ((VL_Unitario.Text.Trim() != "") && (VL_Unitario.Text.Trim() != "0"))
                {
                    try
                    {
                        VL_Unitario_Transf.Value = Convert.ToDecimal(VL_Unitario.Text);

                        if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                            VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value);
                        else
                            VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                    }
                    catch
                    {
                    }
                }

                if (CD_Produto.Text.Trim() != CD_Produto_Destino.Text.Trim())
                {
                    if (TCN_Transferencia.Confere_Produto_Fixo_Fixar(CD_Produto.Text, CD_Produto_Destino.Text) == false)
                    {
                        CD_Produto_Destino.Clear();
                        DS_Produto_Destino.Clear();
                        VL_Unitario_Destino.Clear();
                        CD_Unidade_Destino_Est.Clear();
                        CD_Unidade_Destino_VL.Clear();
                        Unidade_Destino_Est.Clear();
                        Unidade_Destino_VL.Clear();
                        Saldo_Destino.Clear();
                        VL_Unitario_Destino_Transf.Value = 0;
                        VL_Sub_Total_Destino.Value = 0;
                    }
                                        
                }
            }
            else
            {
                CD_Produto.Clear();
            }
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            if (!(NR_Pedido.Text.Trim().Equals(string.Empty)))
            {
                UtilPesquisa.EDIT_LEAVE("a.CD_Produto|=|'" + CD_Produto.Text + "';" +
                                        "n.nr_Pedido|=|" + NR_Pedido.Text,
                new Componentes.EditDefault[] { CD_Produto, DS_Produto, QTD_Origem, VL_Unitario,
                CD_Unidade_Origem_Est,
                CD_Unidade_Origem_VL,
                Unidade_Origem_Est,
                Unidade_Origem_VL,
                },
                new TCD_LanPedido_Item());

                Busca_Saldo_Contrato_Origem();
                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text));

                if ((Saldo_Contrato_Origem.Text.Trim() != "") && (Saldo_Contrato_Origem.Text.Trim() != "0"))
                {
                    try
                    {
                        QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);

                        if ((Saldo_Origem.Text.Trim() != "") && (Saldo_Origem.Text.Trim() != "0"))
                        {
                            if (Convert.ToDecimal(Saldo_Contrato_Origem.Text) > Convert.ToDecimal(Saldo_Origem.Text))
                            {
                                QTD_Transferir.Value = Convert.ToDecimal(Saldo_Origem.Text);
                            }
                        }
                    }
                    catch
                    {
                    }
                }



                if ((VL_Unitario.Text.Trim() != "") && (VL_Unitario.Text.Trim() != "0"))
                {
                    try
                    {
                        VL_Unitario_Transf.Value = Convert.ToDecimal(VL_Unitario.Text);

                        if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                            VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value);
                        else
                            VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                    }
                    catch
                    {
                    }
                }

                if (CD_Produto.Text.Trim() != CD_Produto_Destino.Text.Trim())
                {
                    if (TCN_Transferencia.Confere_Produto_Fixo_Fixar(CD_Produto.Text, CD_Produto_Destino.Text) == false)
                    {
                        CD_Produto_Destino.Clear();
                        DS_Produto_Destino.Clear();
                        VL_Unitario_Destino.Clear();
                        CD_Unidade_Destino_Est.Clear();
                        CD_Unidade_Destino_VL.Clear();
                        Unidade_Destino_Est.Clear();
                        Unidade_Destino_VL.Clear();
                        Saldo_Destino.Clear();
                        VL_Unitario_Destino_Transf.Value = 0;
                        VL_Sub_Total_Destino.Value = 0;
                    }

                }
            }
            else
            {
                CD_Produto.Clear();
            }
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            if (!(NR_Pedido.Text.Trim().Equals(string.Empty)))
            {
                string vColunas = "a.DS_Local|Local de Armazenagem|350;" +
                                 "a.CD_Local|Cód. Local|100";
                string vParamFixo = "";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local, DS_Local },
                                        new TCD_CadLocalArm(), vParamFixo);

                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text));
            }
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            if (!(NR_Pedido.Text.Trim().Equals(string.Empty)))
            {
                UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + CD_Local.Text + "'",
                new Componentes.EditDefault[] { CD_Local, DS_Local },
                new TCD_CadLocalArm());

                Saldo_Origem.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local.Text));
            }
        }

        private void BB_Pedido_Destino_Click(object sender, EventArgs e)
        {
            if ((!(NR_Pedido.Text.Trim().Equals(string.Empty))) && (!(CD_Produto.Text.Trim().Equals(string.Empty))))
            {
                string vColunas = "contrato.NR_Contrato|NRº Contrato|80;" +
                                "n.CD_Empresa|Cód. Empresa|80;" +
                                "n.NM_Empresa|Empresa |100;" +
                                "a.NR_Pedido|NRº Pedido|80;" +
                                "n.DT_Pedido|Data|80;" +
                                "n.TP_MOVIMENTO|Tipo Movimento|80;" +
                                "a.CD_Clifor|Cód. Clifor|80;" +
                                "clifor.NM_Clifor|Nome Clifor|150;" +
                                "clifor.NR_CGC_CPF|CNPJ/CPF|150;" +
                                "endereco.ds_endereco|Endereço|100;" +
                                "endereco.ds_cidade|Cidade|100;" +
                                "endereco.UF|UF|40;" +
                                "a.CD_Produto|Cód. Produto|80;" +
                                "d.DS_Produto|Descrição Produto|150;" +
                                "a.CD_Local|Cód. Local|80;" +
                                "d.DS_Local|Local Armazenagem|150;" +
                                "a.CD_Variedade|Cód. Variedade|80;" +
                                "e.DS_Variedade|Variedade|150;" +
                                "a.VL_Unitario|VL. Unitário|90;" +
                                "sg_unidade_valor|Unidade Valor|40;" +
                                "cd_unidade_valor|Cód. Unidade Valor|80;"+   
                                "a.Quantidade|Quantidade|90;" + 
                                "sg_unidade_est|Unidade Estoque|40;" +
                                "cd_unidade_est|Cód. Unidade Estoque|80";


                string vParamFixo =
                    // O Tipo De pedido tem que permitir transferência
                                    "a.NR_pedido|<>|" + NR_Pedido.Text.Trim() + ";" +
                                    "a.cd_produto = " + CD_Produto.Text + " or |EXISTS|(select 1 from tb_gro_ProdFixo_AFixar x where x.Cd_Produto_Fixo = " + CD_Produto.Text + ");" +
                                    "n.TP_Movimento|=|'" + TP_Movimento.Text.Trim() + "';" +
                    //Usuario tem que ter acesso a empresa  
                                     "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                    //Usuario tem que ter acesso ao tipo de pedido
                                     "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                     "where x.cfg_pedido = n.cfg_pedido " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                    //Pedido tem que estar amarrado a um contrato
                                     "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                     "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto ";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { NR_Pedido_Destino,
               NR_Contrato_Destino,
               DT_Pedido_Destino,
               TP_Movimento_Destino,
               CD_Empresa_Destino,
               NM_Empresa_Destino,
               CD_Clifor_Destino,
               NM_Clifor_Destino,
               CPF_Destino,
               DS_Endereco_Destino,
               DS_Cidade_Destino,
               UF_Destino,
               CD_Produto_Destino,
               DS_Produto_Destino,
               CD_Local_Destino,
               DS_Local_Destino,
               VL_Unitario_Destino,
               QTD_Destino,
               CD_Unidade_Destino_Est,
               CD_Unidade_Destino_VL,
               Unidade_Destino_Est,
               Unidade_Destino_VL}, new TCD_LanPedido_Item(), vParamFixo);



                if (NR_Pedido_Destino.Text.Trim().Equals(string.Empty))
                {
                    NR_Pedido_Destino.Clear();
                    NR_Contrato_Destino.Clear();
                    DT_Pedido_Destino.Clear();
                    TP_Movimento_Destino.Clear();
                    CD_Empresa_Destino.Clear();
                    NM_Empresa_Destino.Clear();
                    CD_Clifor_Destino.Clear();
                    NM_Clifor_Destino.Clear();
                    CPF_Destino.Clear();
                    DS_Endereco_Destino.Clear();
                    DS_Cidade_Destino.Clear();
                    UF_Destino.Clear();
                    CD_Produto_Destino.Clear();
                    DS_Produto_Destino.Clear();
                    CD_Local_Destino.Clear();
                    DS_Local_Destino.Clear();
                    Saldo_Destino.Clear();
                    VL_Unitario_Destino.Clear();
                    
                    VL_Sub_Total_Destino.Value = 0;
                    VL_Unitario_Destino_Transf.Value = 0;
                    

                    QTD_Destino.Clear();
                    CD_Unidade_Destino_Est.Clear();
                    CD_Unidade_Destino_VL.Clear();
                    Unidade_Destino_Est.Clear();
                    Unidade_Destino_VL.Clear();
                }
                else
                {
                    Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text));

                    if ((TCN_Transferencia.Confere_Saldo(NR_Pedido_Destino.Text)) == true)
                    {
                        QTD_Transferir.Value = (Convert.ToDecimal(QTD_Destino.Text) - Convert.ToDecimal(Saldo_Contrato_Destino.Text));

                        if (QTD_Transferir.Value > Convert.ToDecimal(Saldo_Contrato_Origem.Text))
                        {
                            QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);
                        }
                    }
                    
                        if ((VL_Unitario_Destino.Text.Trim() != "") && (VL_Unitario_Destino.Text.Trim() != "0"))
                        {
                            try
                            {
                                VL_Unitario_Destino_Transf.Value = Convert.ToDecimal(VL_Unitario_Destino.Text);

                                if (CD_Unidade_Destino_Est.Text.Trim() != CD_Unidade_Destino_VL.Text.Trim())
                                    VL_Sub_Total_Destino.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Destino_Est.Text, CD_Unidade_Destino_VL.Text, QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value);
                                else
                                    VL_Sub_Total_Destino.Value = (QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value);

                                if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                                    VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value);
                                else
                                    VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                            }
                            catch
                            {
                            }
                        }
                }
            }
            else
            {
                MessageBox.Show("É necessário informar o Contrato de Origem com seu respectivo Produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

        }

        private void NR_Pedido_Destino_Leave(object sender, EventArgs e)
        {
            if ((!(NR_Pedido.Text.Trim().Equals(string.Empty))) && (!(CD_Produto.Text.Trim().Equals(string.Empty))))
            {
                UtilPesquisa.EDIT_LEAVE("a.NR_Pedido|=|" + NR_Pedido_Destino.Text + ";" +
                                        "a.NR_pedido|<>|" + NR_Pedido.Text.Trim() + ";" +
                                        "n.TP_Movimento|=|'" + TP_Movimento.Text.Trim() + "';" +
                                        "a.cd_produto = " + CD_Produto.Text + " or |EXISTS|(select 1 from tb_gro_ProdFixo_AFixar x where x.Cd_Produto_Fixo = " + CD_Produto.Text + ");" +
                    //Usuario tem que ter acesso a empresa  
                                     "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                    //Usuario tem que ter acesso ao tipo de pedido
                                     "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                     "where x.cfg_pedido = n.cfg_pedido " +
                                     "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                     "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                     "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))" +
                    //Pedido tem que estar amarrado a um contrato
                                     "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                     "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto "


                , new Componentes.EditDefault[] { 
               NR_Pedido_Destino,
               NR_Contrato_Destino,
               DT_Pedido_Destino,
               TP_Movimento_Destino,
               CD_Empresa_Destino,
               NM_Empresa_Destino,
               CD_Clifor_Destino,
               NM_Clifor_Destino,
               CPF_Destino,
               DS_Endereco_Destino,
               DS_Cidade_Destino,
               UF_Destino,
               CD_Produto_Destino,
               DS_Produto_Destino,
               CD_Local_Destino,
               DS_Local_Destino,
               VL_Unitario_Destino,
               QTD_Destino,
                CD_Unidade_Destino_Est,
                CD_Unidade_Destino_VL,
                Unidade_Destino_Est,
                Unidade_Destino_VL}, new TCD_LanPedido_Item());

                if (NR_Pedido_Destino.Text.Trim().Equals(string.Empty))
                {
                    NR_Pedido_Destino.Clear();
                    NR_Contrato_Destino.Clear();
                    DT_Pedido_Destino.Clear();
                    TP_Movimento_Destino.Clear();
                    CD_Empresa_Destino.Clear();
                    NM_Empresa_Destino.Clear();
                    CD_Clifor_Destino.Clear();
                    NM_Clifor_Destino.Clear();
                    CPF_Destino.Clear();
                    DS_Endereco_Destino.Clear();
                    DS_Cidade_Destino.Clear();
                    UF_Destino.Clear();
                    CD_Produto_Destino.Clear();
                    DS_Produto_Destino.Clear();
                    CD_Local_Destino.Clear();
                    DS_Local_Destino.Clear();
                    Saldo_Destino.Clear();
                    VL_Unitario_Destino.Clear();

                    VL_Sub_Total_Destino.Value = 0;
                    VL_Unitario_Destino_Transf.Value = 0;

                    QTD_Destino.Clear();
                    CD_Unidade_Destino_Est.Clear();
                    CD_Unidade_Destino_VL.Clear();
                    Unidade_Destino_Est.Clear();
                    Unidade_Destino_VL.Clear();
                }
                else
                {
                    Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text));

                    if ((TCN_Transferencia.Confere_Saldo(NR_Pedido_Destino.Text)) == true)
                    {
                        QTD_Transferir.Value = (Convert.ToDecimal(QTD_Destino.Text) - Convert.ToDecimal(Saldo_Contrato_Destino.Text));

                        if (QTD_Transferir.Value > Convert.ToDecimal(Saldo_Contrato_Origem.Text))
                        {
                            QTD_Transferir.Value = Convert.ToDecimal(Saldo_Contrato_Origem.Text);
                        }
                    }

                    if ((VL_Unitario_Destino.Text.Trim() != "") && (VL_Unitario_Destino.Text.Trim() != "0"))
                    {
                        try
                        {
                            VL_Unitario_Destino_Transf.Value = Convert.ToDecimal(VL_Unitario_Destino.Text);

                            if (CD_Unidade_Destino_Est.Text.Trim() != CD_Unidade_Destino_VL.Text.Trim())
                                VL_Sub_Total_Destino.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Destino_Est.Text, CD_Unidade_Destino_VL.Text, QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value);
                            else
                                VL_Sub_Total_Destino.Value = (QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value);

                            if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                                VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value);
                            else
                                VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            else
            {
                NR_Pedido_Destino.Clear();
            }
        }

        private void BB_Produto_Destino_Click(object sender, EventArgs e)
        {
            if ((!(NR_Pedido_Destino.Text.Trim().Equals(string.Empty))) && (!(CD_Produto.Text.Trim().Equals(string.Empty))))
            {
                string vColunas = "b.DS_Produto|Descrição Produto|350;" +
                                  "a.CD_Produto|Cód. Produto|100;" +
                                  "a.Quantidade|Quantidade|80;" +
                                  "sg_unidade_est|Unidade Estoque|40;" +
                                  "cd_unidade_est|Cód. Unidade Estoque|80;" +
                                  "a.VL_Unitario|Valor Unitário|100;" +
                                  "sg_unidade_valor|Unidade Valor|40;" +
                                  "cd_unidade_valor|Cód. Unidade Valor|80"; 
                               
                               
                string vParamFixo = "n.nr_Pedido|=|" + NR_Pedido_Destino.Text +
                                    ";a.cd_produto = '" + CD_Produto.Text + "' or |EXISTS|(select top 1 1 from tb_gro_prodfixo_Afixar x where x.cd_produto_Afixar = a.cd_produto and x.cd_produto_Fixo = " + CD_Produto.Text + ")";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Produto_Destino, DS_Produto_Destino, QTD_Destino, VL_Unitario_Destino, 
                CD_Unidade_Destino_Est,
                CD_Unidade_Destino_VL,
                Unidade_Destino_Est,
                Unidade_Destino_VL
            }, new TCD_LanPedido_Item(), vParamFixo);

                Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text));
            }
        }

        private void CD_Produto_Destino_Leave(object sender, EventArgs e)
        {
            if (!(NR_Pedido_Destino.Text.Trim().Equals(string.Empty)) && !(CD_Produto.Text.Trim().Equals(string.Empty)))
            {
                UtilPesquisa.EDIT_LEAVE("a.CD_Produto|=|'" + CD_Produto_Destino.Text + "';" +
                                        "n.nr_Pedido|=|" + NR_Pedido_Destino.Text +
                                        ";a.cd_produto = '" + CD_Produto.Text + "' or |EXISTS|(select top 1 1 from tb_gro_prodfixo_Afixar x where x.cd_produto_Afixar = a.cd_produto and x.cd_produto_Fixo = " + CD_Produto.Text + ")",
                new Componentes.EditDefault[] { CD_Produto_Destino, DS_Produto_Destino, QTD_Destino, VL_Unitario_Destino,
                CD_Unidade_Destino_Est,
                CD_Unidade_Destino_VL,
                Unidade_Destino_Est,
                Unidade_Destino_VL},
                new TCD_LanPedido_Item());

                Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text));
            }
            else
            {
                CD_Produto_Destino.Clear();
            }
        }

        private void BB_Local_Destino_Click(object sender, EventArgs e)
        {
            if (!(NR_Pedido_Destino.Text.Trim().Equals(string.Empty)))
            {
                string vColunas = "a.DS_Local|Local de Armazenagem|350;" +
                                 "a.CD_Local|Cód. Local|100";
                string vParamFixo = "";

                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local_Destino, DS_Local_Destino },
                                        new TCD_CadLocalArm(), vParamFixo);

                Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text));
            }
            else
            {
                CD_Local_Destino.Clear();
            }
        }

        private void CD_Local_Destino_Leave(object sender, EventArgs e)
        {
            if (!(NR_Pedido_Destino.Text.Trim().Equals(string.Empty)))
            {
                UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + CD_Local_Destino.Text + "'",
                new Componentes.EditDefault[] { CD_Local_Destino, DS_Local_Destino },
                new TCD_CadLocalArm());

                Saldo_Destino.Text = Convert.ToString(TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa_Destino.Text, CD_Produto_Destino.Text, CD_Local_Destino.Text));
            }
        }

        private void TFLan_Transferencia_Load(object sender, EventArgs e)
        {
            pnl_Destino.set_FormatZero();
            pnl_Origem.set_FormatZero();
            pnl_Busca.set_FormatZero();
            Habilita_Campos(3);

            g_Pedido_Destino.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g_Pedido_Destino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            g_Pedido_Origem.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g_Pedido_Origem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            g_Transferencia.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g_Transferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public override void afterGrava()
        {
            try
            {
                if (NR_Pedido.Text.Trim() == "")
                {
                    throw new Exception("Para Transferir: Você deve informar um Pedido de Origem.");
                }

                if (NR_Pedido_Destino.Text.Trim() == "")
                {
                    throw new Exception("Para Transferir: Você deve informar um Pedido de Destino.");
                }

                if (CD_Local.Text.Trim() == "")
                {
                    throw new Exception("Para Transferir: Você deve informar um Local de Origem.");
                }
                
                if (CD_Local_Destino.Text.Trim() == "")
                {
                    throw new Exception("Para Transferir: Você deve informar um Local de Destino.");
                }

                if (QTD_Transferir.Value <= 0)
                {
                    throw new Exception("Para Transferir: Você deve informar uma quantidade a Transferir.");
                }

                if ((VL_Unitario_Transf.Value <= 0) || (VL_Unitario_Destino_Transf.Value <= 0))
                {
                    throw new Exception("Para Transferir: Você deve informar um Valor Unitário tanto na Origem quanto no Destino.");
                }

                if (Convert.ToDecimal(Saldo_Origem.Text) <= 0)
                {
                    throw new Exception("Para Transferir: Você deve possuir Saldo no Local de Origem.");
                }

                if (Convert.ToDecimal(Saldo_Origem.Text) < QTD_Transferir.Value)
                {
                    throw new Exception("A quantidade transferida não pode ser maior que Saldo no Local de Origem.");
                }

                if (Convert.ToDecimal(Saldo_Contrato_Origem.Text) < QTD_Transferir.Value)
                {
                    throw new Exception("A quantidade transferida não pode ser maior que Saldo do  Contrato de Origem.");
                }

                if ((TCN_Transferencia.Confere_Saldo(NR_Pedido_Destino.Text)) == true)
                {
                    if(QTD_Transferir.Value > (Convert.ToDecimal(QTD_Destino.Text) - Convert.ToDecimal(Saldo_Contrato_Destino.Text)))
                    {
                        throw new Exception("A quantidade transferida deve ser igual ou menor ao Saldo do Pedido de Destino.");
                    }
                }

                TList_LanFat_ComplementoDevolucao Complemento_Devolucao = new TList_LanFat_ComplementoDevolucao();
                TFLanCompDevol_NF fCompDevol = new TFLanCompDevol_NF();

                fCompDevol.Cd_empresa = CD_Empresa.Text;
                fCompDevol.Nr_pedido = NR_Pedido.Text;
                fCompDevol.Cd_produto = CD_Produto.Text;
                fCompDevol.Cd_clifor = CD_Clifor.Text;

                fCompDevol.Tp_operacao = "D";
                fCompDevol.Tp_movimento = "E";
                fCompDevol.Quantidade = QTD_Transferir.Value;
                fCompDevol.Valor = VL_Sub_Total_Origem.Value; 

                if (fCompDevol.ShowDialog() == DialogResult.OK)
                {

                    Complemento_Devolucao = fCompDevol.ListaCompDev;

                    bool Pode_Gravar_Origem = false;
                    bool ST_SequenciaNF_Origem = false;
                    decimal NR_Nota_Origem = 0;

                    TList_CadCFGPedidoFiscal List_Pedido_Fiscal = new TCD_CadCFGPedidoFiscal().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                            "where x.cfg_pedido = a.cfg_pedido "+
                                            "and x.nr_pedido = "+NR_Pedido.Text+")"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.tp_fiscal",
                                vOperador = "=",
                                vVL_Busca = "'D'"
                            }
                        }, 1, string.Empty);

                    if (List_Pedido_Fiscal.Count > 0)
                    {
                        if (List_Pedido_Fiscal[0].Nr_serie != "")
                        {
                            TList_CadSerieNF List_SerieNF = TCN_CadSerieNF.Busca(List_Pedido_Fiscal[0].Nr_serie, "", 0, "", "", "", "", "", "", null);
                            if (List_SerieNF.Count > 0)
                            {
                                if (List_SerieNF[0].ST_SequenciaAutoBool == false)
                                {
                                    TFNumero_Nota Numero_Nota = new TFNumero_Nota();
                                    Numero_Nota.pCd_empresa = CD_Empresa.Text;
                                    Numero_Nota.pNm_empresa = NM_Empresa.Text;
                                    Numero_Nota.pCd_clifor = CD_Clifor.Text;
                                    Numero_Nota.pNm_clifor = NM_Clifor.Text;
                                    Numero_Nota.pNr_serie = List_Pedido_Fiscal[0].Nr_serie;
                                    Numero_Nota.pDs_serie = List_Pedido_Fiscal[0].Ds_serienf;
                                    Numero_Nota.pTp_nota = "P";
                                    if (Numero_Nota.ShowDialog() == DialogResult.OK)
                                    {
                                        NR_Nota_Origem = Numero_Nota.pNr_notafiscal;
                                        Pode_Gravar_Origem = true;
                                    }
                                    else
                                    {
                                        Pode_Gravar_Origem = false;
                                    }
                                }
                                else
                                {
                                    ST_SequenciaNF_Origem = true;
                                    Pode_Gravar_Origem = true;
                                }
                            }
                            else
                            {
                                Pode_Gravar_Origem = true;
                            }
                        }
                    }


                    bool Pode_Gravar_Destino = false;
                    bool ST_SequenciaNF_Destino = false;
                    decimal NR_Nota_Destino = 0;

                    TList_CadCFGPedidoFiscal List_Pedido_Fiscal_Destino = new TCD_CadCFGPedidoFiscal().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                            "where x.cfg_pedido = a.cfg_pedido "+
                                            "and x.nr_pedido = "+NR_Pedido_Destino.Text+")"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.tp_fiscal",
                                vOperador = "=",
                                vVL_Busca = "'N'"
                            }
                        }, 1, string.Empty);

                    if (List_Pedido_Fiscal_Destino.Count > 0)
                    {
                        if (List_Pedido_Fiscal_Destino[0].Nr_serie != "")
                        {
                            TList_CadSerieNF List_SerieNF_Destino = TCN_CadSerieNF.Busca(List_Pedido_Fiscal_Destino[0].Nr_serie, "", 0, "", "", "", "", "", "", null);
                            if (List_SerieNF_Destino.Count > 0)
                            {
                                if (List_SerieNF_Destino[0].ST_SequenciaAutoBool == false)
                                {
                                    TFNumero_Nota Numero_Nota_Destino = new TFNumero_Nota();
                                    Numero_Nota_Destino.pCd_empresa = CD_Empresa_Destino.Text;
                                    Numero_Nota_Destino.pNm_empresa = NM_Empresa_Destino.Text;
                                    Numero_Nota_Destino.pCd_clifor = CD_Clifor_Destino.Text;
                                    Numero_Nota_Destino.pNm_clifor = NM_Clifor_Destino.Text;
                                    Numero_Nota_Destino.pNr_serie = List_Pedido_Fiscal_Destino[0].Nr_serie;
                                    Numero_Nota_Destino.pDs_serie = List_Pedido_Fiscal_Destino[0].Ds_serienf;
                                    Numero_Nota_Destino.pTp_nota = "P";
                                    if (Numero_Nota_Destino.ShowDialog() == DialogResult.OK)
                                    {
                                        NR_Nota_Destino = Numero_Nota_Destino.pNr_notafiscal;
                                        Pode_Gravar_Destino = true;
                                    }
                                    else
                                    {
                                        Pode_Gravar_Destino = false;
                                    }
                                }
                                else
                                {
                                    ST_SequenciaNF_Destino = true;
                                    Pode_Gravar_Destino = true;
                                }
                            }
                        }
                        else
                        {
                            Pode_Gravar_Destino = true;
                        }
                    }


                    if ((Pode_Gravar_Origem == true) && (Pode_Gravar_Destino == true))
                    {
                        TList_RegLanDuplicata Duplicata_Origem = new TList_RegLanDuplicata();
                        Duplicata_Origem = Gera_Financeiro(Convert.ToDecimal(NR_Pedido.Text), "O");
                        TList_RegLanDuplicata Duplicata_Destino = new TList_RegLanDuplicata();
                        Duplicata_Destino = Gera_Financeiro(Convert.ToDecimal(NR_Pedido_Destino.Text), "D");
                        
                        if ((Duplicata_Origem != null) && (Duplicata_Destino != null))
                        {                        

                                TList_Pedido List_Pedido_Origem = new TList_Pedido();
                                TRegistro_Pedido Pedido_Origem = new TRegistro_Pedido();
                                List_Pedido_Origem = TCN_Pedido.Busca("", "", Convert.ToInt16(NR_Pedido.Text), "", "", "", "", "", "", false, false, false, false, false, false, "", "", "", "", "", "", "", 0, 0, 0, "", null);
                                Pedido_Origem = List_Pedido_Origem[0];
                                Pedido_Origem.Pedido_Fiscal = new TCD_CadCFGPedidoFiscal().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                        "where x.cfg_pedido = a.cfg_pedido " +
                                                        "and x.nr_pedido = " + Pedido_Origem + ")"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_fiscal",
                                            vOperador = "=",
                                            vVL_Busca = "'D'"
                                        }
                                    }, 1, string.Empty);
                                Pedido_Origem.Pedido_Itens = TCN_LanPedido_Item.Busca(string.Empty,
                                                                                      string.Empty, 
                                                                                      CD_Produto.Text, 
                                                                                      Pedido_Origem.Nr_pedido,
                                                                                      decimal.Zero,
                                                                                      string.Empty, 
                                                                                      "b.ds_produto asc", 
                                                                                      false,
                                                                                      null);

                                TRegistro_CadClifor Reg_Clifor_Origem = new TRegistro_CadClifor();
                                Reg_Clifor_Origem = TCN_CadClifor.Busca_Clifor_Codigo(CD_Clifor.Text);

                                TRegistro_CadProduto Reg_Produto_Origem = new TRegistro_CadProduto();
                                Reg_Produto_Origem = TCN_CadProduto.Busca_Produto_Codigo(CD_Produto.Text);

                                TList_CadEmpresa List_Empresa_Origem = new TList_CadEmpresa();
                                TRegistro_CadEmpresa Reg_Empresa_Origem = new TRegistro_CadEmpresa();
                                List_Empresa_Origem = TCN_CadEmpresa.Busca(CD_Empresa.Text, string.Empty, string.Empty, null);
                                    Reg_Empresa_Origem = List_Empresa_Origem[0];


                                TList_Pedido List_Pedido_Destino = new TList_Pedido();
                                TRegistro_Pedido Pedido_Destino = new TRegistro_Pedido();
                                List_Pedido_Destino = TCN_Pedido.Busca(string.Empty, string.Empty, Convert.ToInt16(NR_Pedido_Destino.Text), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, false, false, false, false, false, false, "", "", "", "", "", "", "", 0, 0, 0, "", null);
                                Pedido_Destino = List_Pedido_Destino[0];
                                Pedido_Destino.Pedido_Fiscal = new TCD_CadCFGPedidoFiscal().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                        "where x.cfg_pedido = a.cfg_pedido "+
                                                        "and x.nr_pedido = "+Pedido_Destino+")"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_fiscal",
                                            vOperador = "=",
                                            vVL_Busca = "'N'"
                                        }
                                    }, 1, string.Empty);
                                Pedido_Destino.Pedido_Itens = TCN_LanPedido_Item.Busca(string.Empty,
                                                                                       string.Empty, 
                                                                                       CD_Produto_Destino.Text, 
                                                                                       Pedido_Destino.Nr_pedido, 
                                                                                       decimal.Zero, 
                                                                                       string.Empty, 
                                                                                       "b.ds_produto asc", 
                                                                                       false,
                                                                                       null);

                                TRegistro_CadClifor Reg_Clifor_Destino = new TRegistro_CadClifor();
                                Reg_Clifor_Destino = TCN_CadClifor.Busca_Clifor_Codigo(CD_Clifor_Destino.Text);

                                TRegistro_CadProduto Reg_Produto_Destino = new TRegistro_CadProduto();
                                Reg_Produto_Destino = TCN_CadProduto.Busca_Produto_Codigo(CD_Produto_Destino.Text);

                                TList_CadEmpresa List_Empresa_Destino = new TList_CadEmpresa();
                                TRegistro_CadEmpresa Reg_Empresa_Destino = new TRegistro_CadEmpresa();
                                List_Empresa_Destino = TCN_CadEmpresa.Busca(CD_Empresa_Destino.Text, "", "", null);
                                Reg_Empresa_Destino = List_Empresa_Destino[0];

                                TCN_Transferencia.Grava_Transferencia(BS_Transferencia.Current as TRegistro_Transferencia,
                                                                      Complemento_Devolucao, 
                                                                      NR_Nota_Origem, 
                                                                      NR_Nota_Destino, 
                                                                      ST_SequenciaNF_Origem, 
                                                                      ST_SequenciaNF_Destino, 
                                                                      Pedido_Origem, 
                                                                      Reg_Clifor_Origem, 
                                                                      Reg_Produto_Origem, 
                                                                      Reg_Empresa_Origem,
                                                                      Pedido_Destino, 
                                                                      Reg_Clifor_Destino, 
                                                                      Reg_Produto_Destino, 
                                                                      Reg_Empresa_Destino, 
                                                                      Duplicata_Origem, 
                                                                      Duplicata_Destino,
                                                                      null);
                                afterBusca();
                                MessageBox.Show("Transferência Realizada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            MessageBox.Show("Por favor! \r\n  - Verifique os dados das Duplicatas.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        
                     }
                }
                else
                {
                    MessageBox.Show("Obrigatório informar as notas a serem Devolvidas ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao Transferir o Contrato: \r\n \r\n" + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
            }
        }

        public override void afterNovo()
        {
            modoBotoes(TTpModo.tm_Standby, false, false, true, false, true, true, false);
            Habilita_Campos(1);
            BS_Transferencia.Clear();
            BS_Transferencia.AddNew();
            BS_Transf_Origem.Clear();
            BS_Transf_Origem.AddNew();
            BS_Transf_Destino.Clear();
            BS_Transf_Destino.AddNew();

            if (tcCentral.SelectedTab == tpPadrao)
            {
                tcCentral.SelectedTab = TP_Lancamento;
            }
            NR_Pedido.Focus();

        }

        private void Habilita_Campos(int Modo)
        {
            if (Modo == 1)
            {
                NR_Pedido.Enabled = true;
                BB_Pedido.Enabled = true;
                CD_Produto.Enabled = true;
                BB_Produto.Enabled = true;
                CD_Local.Enabled = true;
                BB_Local.Enabled = true;

                NR_Pedido_Destino.Enabled = true;
                BB_Pedido_Destino.Enabled = true;
                CD_Produto_Destino.Enabled = true;
                BB_Produto_Destino.Enabled = true;
                CD_Local_Destino.Enabled = true;
                BB_Local_Destino.Enabled = true;

                DT_Lancto.Enabled = true;
                QTD_Transferir.Enabled = true;
                VL_Unitario_Transf.Enabled = true;
                VL_Unitario_Destino_Transf.Enabled = true;
                DS_Observacao.Enabled = true;

                VL_Sub_Total_Origem.Enabled = true;
                VL_Sub_Total_Destino.Enabled = true;

            }
            else
            {
                if (Modo == 2)
                {
                }
                else
                {
                    if (Modo == 3)
                    {
                        NR_Pedido.Enabled = false;
                        BB_Pedido.Enabled = false;
                        CD_Produto.Enabled = false;
                        BB_Produto.Enabled = false;
                        CD_Local.Enabled = false;
                        BB_Local.Enabled = false;

                        NR_Pedido_Destino.Enabled = false;
                        BB_Pedido_Destino.Enabled = false;
                        CD_Produto_Destino.Enabled = false;
                        BB_Produto_Destino.Enabled = false;
                        CD_Local_Destino.Enabled = false;
                        BB_Local_Destino.Enabled = false;

                        DT_Lancto.Enabled = false;
                        QTD_Transferir.Enabled = false;
                        VL_Unitario_Transf.Enabled = false;
                        VL_Unitario_Destino_Transf.Enabled = false;
                        DS_Observacao.Enabled = false;

                        VL_Sub_Total_Origem.Enabled = false;
                        VL_Sub_Total_Destino.Enabled = false;
                    }

                }

            }
        }

        public override void afterAltera()
        {
            //
        }

        public override void afterBusca()
        {
            
        }

        public override void afterExclui()
        {
            try
            {

                TCN_Transferencia.Cancela_Transferencia(BS_Transferencia.Current as TRegistro_Transferencia,
                                                        BS_Transf_Origem.Current as TRegistro_Transf_X_Pedido,
                                                        BS_Transf_Destino.Current as TRegistro_Transf_X_Pedido, 
                                                        null);
                MessageBox.Show("Cancelamento da Transferência Realizada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                afterCancela();
            }
            catch(Exception e)
            {
                 MessageBox.Show("Erro ao Cancelar a Transferencia do Contrato: \r\n \r\n" + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
            }
        }

        public override void afterCancela()
        {
            Habilita_Campos(3);
            modoBotoes(TTpModo.tm_Standby, true, false, false, false, false, true, false);
            BS_Transferencia.Clear();
            BS_Transf_Origem.Clear();
            BS_Transf_Destino.Clear();
            
        }

        public override void afterPrint()
        {
            //
        }

        private void Busca_Saldo_Contrato_Origem()
        {
            Saldo_Contrato_Origem.Text = Convert.ToString(TCN_Transferencia.Saldo_Contrato(NR_Contrato.Text, NR_Pedido.Text, CD_Produto.Text));
        }

        private void Busca_Saldo_Contrato_Destino()
        {
            Saldo_Contrato_Destino.Text = Convert.ToString(TCN_Transferencia.Saldo_Contrato(NR_Contrato_Destino.Text, NR_Pedido_Destino.Text, CD_Produto_Destino.Text));
        }

        public TList_RegLanDuplicata Gera_Financeiro(decimal NR_Pedido, string Origem_Destino)
        {
            TList_RegLanDuplicata Duplicata = new TList_RegLanDuplicata();

            if (NR_Pedido > 0)
            {
                TRegistro_Pedido Pedido = TCN_Pedido.Busca_Registro_Pedido(NR_Pedido);

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                      "where x.cfg_pedido = a.cfg_pedido " +
                                                      "and x.nr_pedido = " + NR_Pedido.ToString() + ")";
                vBusca[vBusca.Length - 1].vOperador = "exists";

                if (Origem_Destino == "D")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_FISCAL";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'N'";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                }
                else
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_FISCAL";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'D'";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                }

                DataTable DT_Pedido_Fiscal = new TCD_CadCFGPedidoFiscal().Buscar(vBusca, 0);

                if (DT_Pedido_Fiscal.Rows.Count > 0)
                {
                    if (DT_Pedido_Fiscal.Rows[0]["tp_duplicata"].ToString().Trim() != string.Empty)
                    {
                        TList_Pedido_DT_Vencto Pedido_DT_Vencto = TCN_LanPedido_DT_Vencto.Busca(NR_Pedido);

                        TpBusca[] vBusca_Mov = new TpBusca[0];
                        Array.Resize(ref vBusca_Mov, vBusca_Mov.Length + 1);
                        vBusca_Mov[vBusca_Mov.Length - 1].vNM_Campo = "a.cd_movimentacao";
                        vBusca_Mov[vBusca_Mov.Length - 1].vVL_Busca = "'" + DT_Pedido_Fiscal.Rows[0]["cd_movto"].ToString().Trim() + "'";
                        vBusca_Mov[vBusca_Mov.Length - 1].vOperador = "=";

                        TList_CadMovimentacao List_Movimentacao = new TCD_CadMovimentacao().Select(vBusca_Mov, 0, "");
                                                
                        TList_CadCondPgto List_CondPagamento = TCN_CadCondPgto.Buscar(Pedido.CD_CondPGTO, "", "", "", "", "", 0, 0, "", "", 1, "", null);
                        if (List_CondPagamento.Count > 0)
                        {
                            List_CondPagamento[0].lCondPgto_X_Parcelas = TCN_CadCondPgto_X_Parcelas.Buscar(List_CondPagamento[0].Cd_condpgto);
                       }
                        
                        TRegistro_LanDuplicata Reg_Duplicata = new TRegistro_LanDuplicata();
                        TList_CadTpDuplicata List_TPDuplicata = TCN_CadTpDuplicata.Buscar(DT_Pedido_Fiscal.Rows[0]["tp_duplicata"].ToString().Trim(), "", "");
                        if ((DT_Pedido_Fiscal.Rows[0]["ST_Devolucao"].ToString().Trim().ToUpper() != "S") && 
                            (!List_CondPagamento[0].St_solicitardtvenctobool) && 
                            (List_CondPagamento[0].lCondPgto_X_Parcelas.Count > 0) && 
                            (List_Movimentacao[0].cd_historico.Trim() != string.Empty) &&
                            (!List_TPDuplicata[0].St_gerarboletoautobool))
                        {
                            Reg_Duplicata.Cd_empresa = Pedido.CD_Empresa.Trim();
                            Reg_Duplicata.Nm_empresa = Pedido.Nm_Empresa.Trim();
                            Reg_Duplicata.Cd_clifor = Pedido.CD_Clifor.Trim();
                            Reg_Duplicata.Nm_clifor = Pedido.NM_Clifor.Trim();
                            Reg_Duplicata.Cd_endereco = Pedido.CD_Endereco.Trim();
                            Reg_Duplicata.Ds_endereco = Pedido.DS_Endereco.Trim();
                            
                            Reg_Duplicata.Cd_historico = List_Movimentacao[0].cd_historico.Trim();
                            Reg_Duplicata.Ds_historico = List_Movimentacao[0].ds_historico.Trim();
                            
                            Reg_Duplicata.Tp_duplicata = DT_Pedido_Fiscal.Rows[0]["tp_duplicata"].ToString().Trim();
                            Reg_Duplicata.Ds_tpduplicata = DT_Pedido_Fiscal.Rows[0]["ds_tpduplicata"].ToString().Trim();
                            Reg_Duplicata.Tp_mov = DT_Pedido_Fiscal.Rows[0]["tp_movimento"].ToString().Trim().ToUpper() == "E" ? "P" :
                                          DT_Pedido_Fiscal.Rows[0]["tp_movimento"].ToString().Trim().ToUpper() == "S" ? "R" : "";
                            Reg_Duplicata.Tp_docto = DT_Pedido_Fiscal.Rows[0]["tp_docto"].ToString().Trim() != string.Empty ? Convert.ToDecimal(DT_Pedido_Fiscal.Rows[0]["tp_docto"].ToString()) : 0;
                            Reg_Duplicata.Ds_tpdocto = DT_Pedido_Fiscal.Rows[0]["ds_tpdocto"].ToString().Trim();
                           
                            
                            
                            Reg_Duplicata.Cd_condpgto = List_CondPagamento[0].Cd_condpgto.Trim();
                            Reg_Duplicata.Ds_condpgto = List_CondPagamento[0].Ds_condpgto.Trim();
                            Reg_Duplicata.St_comentrada = List_CondPagamento[0].St_comentrada.Trim();
                            Reg_Duplicata.Cd_juro = List_CondPagamento[0].Cd_juro.Trim();
                            Reg_Duplicata.Ds_juro = List_CondPagamento[0].Ds_juro.Trim();
                            Reg_Duplicata.Tp_juro = List_CondPagamento[0].Tp_juro.Trim();
                            
                            Reg_Duplicata.Cd_moeda = Pedido.Cd_moeda.Trim();
                            Reg_Duplicata.Ds_moeda = Pedido.Ds_moeda.Trim();
                            Reg_Duplicata.Sigla_moeda = Pedido.Sigla.Trim();
                            Reg_Duplicata.Qt_dias_desdobro = List_CondPagamento[0].Qt_diasdesdobro;
                            Reg_Duplicata.Qt_parcelas = List_CondPagamento[0].Qt_parcelas;
                            Reg_Duplicata.Pc_jurodiario_atrazo = List_CondPagamento[0].Pc_jurodiario_atrazo;
                            Reg_Duplicata.Cd_portador = List_CondPagamento[0].Cd_portador.Trim();
                            Reg_Duplicata.Ds_portador = List_CondPagamento[0].Ds_portador.Trim();
                            Reg_Duplicata.Nr_docto = string.Empty;
                            Reg_Duplicata.Dt_emissao = (BS_Transferencia.Current as TRegistro_Transferencia).DT_Lancto;
                            if (Origem_Destino == "O")
                            {
                                Reg_Duplicata.Vl_documento = VL_Sub_Total_Origem.Value;
                                Reg_Duplicata.Vl_documento_padrao = VL_Sub_Total_Origem.Value;
                            }
                            else
                            {
                                Reg_Duplicata.Vl_documento = VL_Sub_Total_Destino.Value;
                                Reg_Duplicata.Vl_documento_padrao = VL_Sub_Total_Destino.Value;
                            }

                            decimal vl_saldoadto = TCN_LanAdiantamento.SaldoAdiantamentoDevolver(Pedido.CD_Empresa.Trim(), Pedido.CD_Clifor.Trim(), Pedido.TP_Movimento.Trim(), null);

                            if (Reg_Duplicata.Vl_documento_padrao > 0)
                            {
                                if (Reg_Duplicata.Vl_documento_padrao > vl_saldoadto)
                                {
                                    Reg_Duplicata.cVl_adiantamento = vl_saldoadto;
                                }
                                else
                                {
                                    Reg_Duplicata.cVl_adiantamento = Reg_Duplicata.Vl_documento_padrao;
                                }
                            }
                            else
                            {
                                Reg_Duplicata.cVl_adiantamento = 0;
                            }
                            
                            Reg_Duplicata.Parcelas = TCN_LanDuplicata.calcularParcelas(Reg_Duplicata);
                                                                                    
                        }
                        else
                        {
                            
                            TFLanDuplicata fDuplicata = new TFLanDuplicata();
                           // if ((DT_Pedido_Fiscal.Rows[0]["ST_Complementar"].ToString().Trim().ToUpper() != "S") && 
                            //    (DT_Pedido_Fiscal.Rows[0]["ST_Devolucao"].ToString().Trim().ToUpper() != "S"))
                            
                            fDuplicata.vNr_pedido = null;
                            fDuplicata.vSt_notafiscal = true;
                            fDuplicata.vCd_empresa = Pedido.CD_Empresa.Trim();
                            fDuplicata.vNm_empresa = Pedido.Nm_Empresa.Trim();
                            fDuplicata.vCd_clifor = Pedido.CD_Clifor.Trim();
                            fDuplicata.vNm_clifor = Pedido.NM_Clifor.Trim();
                            fDuplicata.vCd_endereco = Pedido.CD_Endereco.Trim();
                            fDuplicata.vDs_endereco = Pedido.DS_Endereco.Trim();
                            if (List_Movimentacao.Count > 0)
                            {
                                fDuplicata.vCd_historico = List_Movimentacao[0].cd_historico;
                                fDuplicata.vDs_historico = List_Movimentacao[0].ds_historico;
                            }
                            
                            fDuplicata.vTp_duplicata = DT_Pedido_Fiscal.Rows[0]["tp_duplicata"].ToString().Trim();
                            fDuplicata.vDs_tpduplicata = DT_Pedido_Fiscal.Rows[0]["ds_tpduplicata"].ToString().Trim();
                            fDuplicata.vTp_mov = DT_Pedido_Fiscal.Rows[0]["tp_movimento"].ToString().Trim().ToUpper() == "E" ? "P" :
                                          DT_Pedido_Fiscal.Rows[0]["tp_movimento"].ToString().Trim().ToUpper() == "S" ? "R" : "";
                            fDuplicata.vTp_docto = DT_Pedido_Fiscal.Rows[0]["tp_docto"].ToString().Trim();
                            fDuplicata.vDs_tpdocto = DT_Pedido_Fiscal.Rows[0]["ds_tpdocto"].ToString().Trim();
                            if (List_TPDuplicata[0].St_gerarboletoauto.Trim().ToUpper().Equals("S"))
                            {
                                TList_CadContaGer List_Conta = TCN_CadContaGer.Buscar(List_TPDuplicata[0].Cd_contager_boletoauto, "", null, "", "", "", "", 0, "", "", "","", 0, null);

                                fDuplicata.vSt_gerarboletoauto = List_TPDuplicata[0].St_gerarboletoauto;
                                fDuplicata.vCd_contager = List_TPDuplicata[0].Cd_contager_boletoauto;
                                fDuplicata.vDs_contager = List_TPDuplicata[0].Ds_contager_boletoauto;
                            }
                            if (List_CondPagamento.Count > 0)
                            {
                                fDuplicata.vCd_condpgto = List_CondPagamento[0].Cd_condpgto.Trim();
                                fDuplicata.vDs_condpgto = List_CondPagamento[0].Ds_condpgto.Trim();
                                fDuplicata.vSt_comentrada = List_CondPagamento[0].St_comentrada.Trim();
                                fDuplicata.vCd_juro = List_CondPagamento[0].Cd_juro.Trim();
                                fDuplicata.vDs_juro = List_CondPagamento[0].Ds_juro.Trim();
                                fDuplicata.vTp_juro = List_CondPagamento[0].Tp_juro.Trim();
                                
                                fDuplicata.vCd_moeda = Pedido.Cd_moeda;
                                fDuplicata.vDs_moeda = Pedido.Ds_moeda;
                                fDuplicata.vSigla_moeda = Pedido.Sigla;

                                fDuplicata.vQt_dias_desdobro = List_CondPagamento[0].Qt_diasdesdobro;
                                fDuplicata.vQt_parcelas = List_CondPagamento[0].Qt_parcelas;
                                fDuplicata.vPc_jurodiario_atrazo = List_CondPagamento[0].Pc_jurodiario_atrazo;
                                fDuplicata.vCd_portador = List_CondPagamento[0].Cd_portador.Trim();
                                fDuplicata.vDs_portador = List_CondPagamento[0].Ds_portador.Trim();
                                fDuplicata.vSt_solicitardtvencto = List_CondPagamento[0].St_solicitardtvenctobool;
                            }
                            fDuplicata.vNr_docto = "0";
                            fDuplicata.vDt_emissao = (BS_Transferencia.Current as TRegistro_Transferencia).DT_Lancto_String;
                            if (Origem_Destino == "O")
                            {
                                fDuplicata.vVl_documento = VL_Sub_Total_Origem.Value;
                            
                            }
                            else
                            {
                                fDuplicata.vVl_documento = VL_Sub_Total_Destino.Value;
                            }

                            if (fDuplicata.ShowDialog() == DialogResult.OK)
                            {
                               Reg_Duplicata = (fDuplicata.dsDuplicata[0] as TRegistro_LanDuplicata);
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar financeiro para gravar aplicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return null;
                            }
                        }

                        
                                                
                        Duplicata.Add(Reg_Duplicata);
                        return Duplicata;
                    }

                    return Duplicata;
                }
            }

            return Duplicata;
        }

        private void Valores_Fixos()
        {
            if (NR_Pedido.Text != "")
            {
                if ((TCN_Transferencia.Verifica_Valores_Fixos(NR_Pedido.Text)) == true)
                {
                    VL_Unitario_Transf.Enabled = false;
                    VL_Unitario_Destino_Transf.Enabled = false;
                }
                else
                {
                    VL_Unitario_Transf.Enabled = true;
                    VL_Unitario_Destino_Transf.Enabled = true;
                }
            }
        }

        private void BS_Transferencia_PositionChanged(object sender, EventArgs e)
        {
            Atualiza();
                        
        }

        private void Atualiza()
        {
            if (BS_Transferencia.Count > 0)
            {
                TCN_Transferencia.Busca_Transf_Origem(BS_Transferencia.Current as TRegistro_Transferencia);
                TCN_Transferencia.Busca_Transf_Destino(BS_Transferencia.Current as TRegistro_Transferencia);
                
                if ((BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem.Count > 0)
                {
                    if ((BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].Saldo_Contrato <= 0)
                    {
                        (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].Saldo_Contrato = TCN_Transferencia.Saldo_Contrato(
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].NR_Contrato.ToString(),
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].NR_Pedido.ToString(),
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].CD_Produto.ToString()
                            );
                    }

                    if ((BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].Saldo_Local <= 0)
                    {
                        (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].Saldo_Local = TCN_LanEstoque.Busca_Saldo_Local(
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].CD_Empresa.ToString(),
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].CD_Produto.ToString(),
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].CD_Local.ToString()
                            );
                    }

                    if ((BS_Transferencia.Current as TRegistro_Transferencia).VL_Sub_Total_Origem <= 0)
                    {
                        (BS_Transferencia.Current as TRegistro_Transferencia).VL_Sub_Total_Origem = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid((BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].CD_Unidade_Est,
                                                                                                                                       (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Origem[0].CD_Unidade_VL,
                                                                                                                                       (BS_Transferencia.Current as TRegistro_Transferencia).QTD_Transf * (BS_Transferencia.Current as TRegistro_Transferencia).VL_Unit_Origem);
                    }
                    
                }

                if ((BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino.Count > 0)
                {
                    if ((BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].Saldo_Contrato <= 0)
                    {
                        (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].Saldo_Contrato = TCN_Transferencia.Saldo_Contrato(
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].NR_Contrato.ToString(),
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].NR_Pedido.ToString(),
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].CD_Produto.ToString());
                    }


                    if ((BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].Saldo_Local <= 0)
                    {
                        (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].Saldo_Local = TCN_LanEstoque.Busca_Saldo_Local(
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].CD_Empresa.ToString(),
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].CD_Produto.ToString(),
                            (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].CD_Local.ToString()
                            );
                    }

                    if ((BS_Transferencia.Current as TRegistro_Transferencia).VL_Sub_Total_Destino <= 0)
                    {
                        (BS_Transferencia.Current as TRegistro_Transferencia).VL_Sub_Total_Destino = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid((BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].CD_Unidade_Est,
                                                                                                                                       (BS_Transferencia.Current as TRegistro_Transferencia).Transf_X_Pedido_Destino[0].CD_Unidade_VL,
                                                                                                                                      (BS_Transferencia.Current as TRegistro_Transferencia).QTD_Transf * (BS_Transferencia.Current as TRegistro_Transferencia).VL_Unit_Destino);
                    }
                }
                

                BS_Transferencia.ResetBindings(true);
                
            }
        }
               
        private void QTD_Transferir_Leave(object sender, EventArgs e)
        {
            if (QTD_Transferir.Value > 0)
            {
                if ((NR_Pedido.Text.Trim() != "") && (NR_Pedido_Destino.Text.Trim() != ""))
                {
                    if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                        VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value);
                    else
                        VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);

                    if (CD_Unidade_Destino_Est.Text.Trim() != CD_Unidade_Destino_VL.Text.Trim())
                        VL_Sub_Total_Destino.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Destino_Est.Text, CD_Unidade_Destino_VL.Text, QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value);
                    else
                        VL_Sub_Total_Destino.Value = (QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value);
                }
            }
            else
            {
                VL_Unitario_Transf.Value = 0;
                VL_Unitario_Destino_Transf.Value = 0;
                VL_Sub_Total_Origem.Value = 0;
                VL_Sub_Total_Destino.Value = 0;

            }
        }

        private void VL_Unitario_Transf_Leave(object sender, EventArgs e)
        {
            if (NR_Pedido.Text.Trim() != "") 
                if (CD_Unidade_Origem_Est.Text.Trim() != CD_Unidade_Origem_VL.Text.Trim())
                    VL_Sub_Total_Origem.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Origem_Est.Text, CD_Unidade_Origem_VL.Text, QTD_Transferir.Value * VL_Unitario_Transf.Value);
                else
                    VL_Sub_Total_Origem.Value = (QTD_Transferir.Value * VL_Unitario_Transf.Value);
        }

        private void VL_Unitario_Destino_Transf_Leave(object sender, EventArgs e)
        {
            if (NR_Pedido_Destino.Text.Trim() != "")
                if (CD_Unidade_Destino_Est.Text.Trim() != CD_Unidade_Destino_VL.Text.Trim())
                    VL_Sub_Total_Destino.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Destino_Est.Text, CD_Unidade_Destino_VL.Text, QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value);
                else
                    VL_Sub_Total_Destino.Value = (QTD_Transferir.Value * VL_Unitario_Destino_Transf.Value);
        }

        private void VL_Sub_Total_Origem_Leave(object sender, EventArgs e)
        {
            if (NR_Pedido.Text.Trim() != "")
                if (QTD_Transferir.Value > 0)
                    VL_Unitario_Destino_Transf.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Destino_VL.Text.Trim(), CD_Unidade_Destino_Est.Text.Trim(), VL_Sub_Total_Destino.Value / QTD_Transferir.Value);
        }

        private void VL_Sub_Total_Destino_Leave(object sender, EventArgs e)
        {
            if (NR_Pedido_Destino.Text.Trim() != "")
                if (QTD_Transferir.Value > 0)
                    VL_Unitario_Destino_Transf.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(CD_Unidade_Destino_VL.Text.Trim(), CD_Unidade_Destino_Est.Text.Trim(), VL_Sub_Total_Destino.Value / QTD_Transferir.Value);
        }

        private void BB_Clifor_Origem_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasiaa|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100"
                , new Componentes.EditDefault[] { CD_Clifor_Origem_Busca }, new TCD_CadClifor(), null);
        }

        private void CD_Clifor_Origem_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Origem_Busca.Text + "'"
               , new Componentes.EditDefault[] { CD_Clifor_Origem_Busca }, new TCD_CadClifor());
        }

        private void BB_Clifor_Destino_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasiaa|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100"
                , new Componentes.EditDefault[] { CD_Clifor_Destino_Busca }, new TCD_CadClifor(), null);
        }

        private void CD_Clifor_Destino_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Origem_Busca.Text + "'"
               , new Componentes.EditDefault[] { CD_Clifor_Origem_Busca }, new TCD_CadClifor());
        }

        private void BB_Pedido_Origem_Busca_Click(object sender, EventArgs e)
        {
            string vColunas = "contrato.NR_Contrato|NRº Contrato|80;" +
                              "n.CD_Empresa|Cód. Empresa|80;" +
                              "n.NM_Empresa|Empresa |100;" +
                              "a.NR_Pedido|NRº Pedido|80;" +
                              "n.DT_Pedido|Data|80;" +
                              "n.TP_MOVIMENTO|Tipo Movimento|80;" +
                              "a.CD_Clifor|Cód. Clifor|80;" +
                              "clifor.NM_Clifor|Nome Clifor|150;" +
                              "clifor.NR_CGC_CPF|CNPJ/CPF|150;" +
                              "endereco.ds_endereco|Endereço|100;" +
                              "endereco.ds_cidade|Cidade|100;" +
                              "endereco.UF|UF|40;" +
                              "a.CD_Produto|Cód. Produto|80;" +
                              "d.DS_Produto|Descrição Produto|150;" +
                              "a.CD_Local|Cód. Local|80;" +
                              "d.DS_Local|Local Armazenagem|150;" +
                              "a.CD_Variedade|Cód. Variedade|80;" +
                              "e.DS_Variedade|Variedade|150;" +
                              "a.VL_Unitario|Valor Unitário|90;" +
                              "sg_unidade_valor|Unidade Valor|40;" +
                              "cd_unidade_valor|Cód. Unidade Valor|80;" +
                              "a.Quantidade|Quantidade|90;" +
                              "sg_unidade_est|Unidade Estoque|40;" +
                              "cd_unidade_est|Cód. Unidade Estoque|80";
                                   

            string vParamFixo =
                // O Tipo De pedido tem que permitir transferência
                                "cfgped.ST_PermiteTransf|=|'S';" +
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = n.cfg_pedido " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Pedido tem que estar amarrado a um contrato
                                 "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                 "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto); " +
                // O parte Fiscal Pedido tem que te ser deposito
                               "|EXISTS|(select 1 from tb_fat_pedido_Fiscal x " +
                              "where x.nr_pedido = a.nr_pedido and x.TP_Fiscal = 'D') ";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { NR_Pedido_Origem_Busca }, new TCD_LanPedido_Item(), vParamFixo);
        }

        private void BB_Pedido_Destino_Busca_Click(object sender, EventArgs e)
        {
            string vColunas = "contrato.NR_Contrato|NRº Contrato|80;" +
                                 "n.CD_Empresa|Cód. Empresa|80;" +
                                 "n.NM_Empresa|Empresa |100;" +
                                 "a.NR_Pedido|NRº Pedido|80;" +
                                 "n.DT_Pedido|Data|80;" +
                                 "n.TP_MOVIMENTO|Tipo Movimento|80;" +
                                 "a.CD_Clifor|Cód. Clifor|80;" +
                                 "clifor.NM_Clifor|Nome Clifor|150;" +
                                 "clifor.NR_CGC_CPF|CNPJ/CPF|150;" +
                                 "endereco.ds_endereco|Endereço|100;" +
                                 "endereco.ds_cidade|Cidade|100;" +
                                 "endereco.UF|UF|40;" +
                                 "a.CD_Produto|Cód. Produto|80;" +
                                 "d.DS_Produto|Descrição Produto|150;" +
                                 "a.CD_Local|Cód. Local|80;" +
                                 "d.DS_Local|Local Armazenagem|150;" +
                                 "a.CD_Variedade|Cód. Variedade|80;" +
                                 "e.DS_Variedade|Variedade|150;" +
                                 "a.VL_Unitario|Valor Unitário|90;" +
                                 "sg_unidade_valor|Unidade Valor|40;" +
                                 "cd_unidade_valor|Cód. Unidade Valor|80;" +
                                 "a.Quantidade|Quantidade|90;" +
                                 "sg_unidade_est|Unidade Estoque|40;" +
                                 "cd_unidade_est|Cód. Unidade Estoque|80";


            string vParamFixo =
                // O Tipo De pedido tem que permitir transferência
                                "cfgped.ST_PermiteTransf|=|'S';" +
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = n.cfg_pedido " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Pedido tem que estar amarrado a um contrato
                                 "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                 "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto) "; 
                
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { NR_Pedido_Destino_Busca }, new TCD_LanPedido_Item(), vParamFixo);

        }

        private void NR_Pedido_Origem_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.NR_Pedido|=|" + NR_Pedido_Origem_Busca.Text + ";" +

           // O Tipo De pedido tem que permitir transferência
                           "cfgped.ST_PermiteTransf|=|'S';" +
                //Usuario tem que ter acesso a empresa  
                            "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                            "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                            "where x.cfg_pedido = n.cfg_pedido " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Pedido tem que estar amarrado a um contrato
                            "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                            "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto); " +
                // O parte Fiscal Pedido tem que te ser deposito
                            "|EXISTS|(select 1 from tb_fat_pedido_Fiscal x " +
                           "where x.nr_pedido = a.nr_pedido and x.TP_Fiscal = 'D') "

       , new Componentes.EditDefault[] { 
               NR_Pedido_Origem_Busca            
            }, new TCD_LanPedido_Item());

            
        }

        private void NR_Pedido_Destino_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.NR_Pedido|=|" + NR_Pedido_Destino_Busca.Text + ";" +

                // O Tipo De pedido tem que permitir transferência
                                "cfgped.ST_PermiteTransf|=|'S';" +
                //Usuario tem que ter acesso a empresa  
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = n.cd_empresa " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Usuario tem que ter acesso ao tipo de pedido
                                 "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                 "where x.cfg_pedido = n.cfg_pedido " +
                                 "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                 "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                 "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                //Pedido tem que estar amarrado a um contrato
                                 "|EXISTS|(select 1 from tb_gro_contrato_x_pedidoitem x inner join tb_gro_contrato y " +
                                 "on x.nr_contrato = y.nr_contrato where x.nr_pedido = a.nr_pedido and x.cd_produto = a.cd_produto); " +
                // O parte Fiscal Pedido tem que te ser deposito
                                 "|EXISTS|(select 1 from tb_fat_pedido_Fiscal x " +
                                "where x.nr_pedido = a.nr_pedido and x.TP_Fiscal = 'D') "

            , new Componentes.EditDefault[] { 
               NR_Pedido_Destino_Busca            
            }, new TCD_LanPedido_Item());
        }

        private void NR_Pedido_Destino_Busca_TextChanged(object sender, EventArgs e)
        {

        }

        private void NR_Contrato_Destino_Busca_TextChanged(object sender, EventArgs e)
        {

        }

        private void CD_Clifor_Destino_Busca_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnl_Origem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Unidade_Destino_Est_TextChanged(object sender, EventArgs e)
        {

        }
                               
   }
}
