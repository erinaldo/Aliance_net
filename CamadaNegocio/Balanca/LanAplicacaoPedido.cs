using System;
using System.Data;
using Utils;
using BancoDados;
using CamadaDados.Graos;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Balanca;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaNegocio.Estoque.Cadastros;
using CamadaNegocio.Graos;

namespace CamadaNegocio.Balanca
{    
    public class TCN_PedidoAplicacao
    {
        public static TList_PedidoAplicacao Buscar(string vCD_Empresa,
                                                     string vNR_Pedido,
                                                     string vCFG_Pedido,
                                                     string vCD_Contratante,
                                                     string vTP_Movto,
                                                     bool vST_Pendentes,
                                                     string vNr_contrato,
                                                     string vAnosafra,
                                                     string vCd_tabeladesconto,
                                                     string vData,
                                                     string vDt_ini,
                                                     string vDt_fin,
                                                     bool vSemPedidoDeposito,
                                                     string vCD_Produto,
                                                     bool vSt_PedidoFixar,
                                                     bool vSt_SaldoFixar,
                                                     string vTp_Movimento,
                                                     bool vSomenteAdtoLancado,
                                                     bool St_ContratoAberto,
                                                     Int16 vTop)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vNR_Pedido.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNR_Pedido.Trim();
            }
            if (!string.IsNullOrEmpty(vCFG_Pedido.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cfg_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCFG_Pedido.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Contratante.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Contratante.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vTp_Movimento.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_Movimento.Trim() + "'";
            }
            if (vST_Pendentes)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "";
                filtro[filtro.Length - 1].vVL_Busca = "(Select 1 From VTB_BAL_PSGRAOS x " +
                                                      "inner join VTB_BAL_DESDOBRO y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.tp_pesagem = y.tp_pesagem " + 
                                                      "and x.id_ticket = y.id_ticket " +
                                                      "Where y.CD_CliforPedido = a.CD_Clifor " + 
                                                      "and y.CD_Empresa = a.CD_Empresa " + 
                                                      "and y.CD_Produto = a.CD_Produto " +
                                                      "and a.CD_TabelaDesconto = x.CD_TabelaDesconto " + 
                                                      "and x.TP_Movimento = '" + vTP_Movto + "'" +
                                                      "and isNull((case when x.TP_Movimento = 'E' then " +
                                                      "             (case when y.TP_Pessoa = 'F' then " +
                                                      "                 y.QTD_NotaLiquido " +
                                                      "             else " +
                                                      "                 (case when(a.tp_natureza_pesagem = 'O')then " +
                                                      "                     y.QTD_Nota " +
                                                      "                 else " +
                                                      "                     y.QTD_NotaLiquido " +
                                                      "                 end) " +
                                                      "             end) " +
                                                      "else " +
                                                      "     y.QTD_NotaLiquido " +
                                                      "end " +
                                                      "),0) > " +
                                                      "isNull((Select sum(isNull(aplic.QTD_Aplicado,0)) " + 
                                                      "From TB_BAL_Aplicacao_Pedido aplic " +
                                                      "Where aplic.CD_Empresa = y.CD_Empresa " +
                                                      "and aplic.ID_Ticket = y.ID_Ticket " + 
                                                      "and aplic.TP_Pesagem = y.TP_Pesagem " +
                                                      "and aplic.CD_Produto = y.CD_Produto " +
                                                      "and aplic.ID_Item = y.ID_Item " +
                                                      "and aplic.ID_Desdobro = y.ID_Desdobro),0))";
                filtro[filtro.Length - 1].vOperador = "EXISTS";
            }
            if (vSomenteAdtoLancado)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "";
                filtro[filtro.Length - 1].vVL_Busca = "(SELECT 1 FROM TB_GRO_Adto_Contrato x " +
                                                      "INNER JOIN TB_FIN_Adiantamento y " +
                                                      "on x.Id_Adto = y.Id_Adto " +
                                                      "WHERE isnull(y.ST_Adto, 'N') <> 'C'" +
                                                      "AND x.nr_pedido = a.nr_pedido " +
                                                      "AND x.cd_produto = a.cd_produto)";
                filtro[filtro.Length - 1].vOperador = "EXISTS";
            }
            if (!string.IsNullOrEmpty(vNr_contrato.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_contrato;
            }
            if (!string.IsNullOrEmpty(vAnosafra.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.anosafra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vAnosafra.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCd_tabeladesconto.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabeladesconto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_tabeladesconto.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_ini.Trim())) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = vData.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : "a.dt_encerramento";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_ini).ToString("yyyyMMdd")) + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_fin.Trim())) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = vData.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : "a.dt_encerramento";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_fin).ToString("yyyyMMdd")) + "'";
            }
            if (vSemPedidoDeposito)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.ST_Deposito, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'N'";
            }

            if (!string.IsNullOrEmpty(vCD_Produto.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
            }
            if (vSt_PedidoFixar)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_valoresfixos, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'N'";
                if (vTP_Movto.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + vTP_Movto.Trim() + "'";
                }
            }
            if (vSt_SaldoFixar)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "case when a.tp_movimento = 'E' then " +
                                                        //Total Entrada
                                                        "((isnull((select sum(isnull(y.qtd_entrada, 0)) from tb_fat_pedido_x_estoque x " +
                                                        "inner join tb_est_estoque y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.cd_produto = y.cd_produto " +
                                                        "and x.id_lanctoestoque = y.id_lanctoestoque " +
                                                        "where x.nr_pedido = a.nr_pedido " +
                                                        "and x.cd_produto = a.cd_produto " +
                                                        "and y.st_registro <> 'C'), 0) - " +
                                                        //Total Saida
                                                        "isnull((select sum(isnull(y.qtd_saida, 0)) from tb_fat_pedido_x_estoque x " +
                                                        "inner join tb_est_estoque y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.cd_produto = y.cd_produto " +
                                                        "and x.id_lanctoestoque = y.id_lanctoestoque " +
                                                        "where x.nr_pedido = a.nr_pedido " +
                                                        "and x.cd_produto = a.cd_produto " +
                                                        "and y.st_registro <> 'C'), 0)) - " +
                                                        //Total Fixado
                                                        "isnull((select sum(isnull(x.ps_fixado_total, 0)) " +
                                                        "from tb_gro_fixacao x " +
                                                        "inner join tb_gro_fixacao_x_contrato y " +
                                                        "on x.id_fixacao = y.id_fixacao " +
                                                        "where y.nr_contrato = a.nr_contrato " +
                                                        "and isnull(x.st_registro, 'A') <> 'C'), 0)) else " +
                                                        //Total Saida
                                                        "((isnull((select sum(isnull(y.qtd_saida, 0)) from tb_fat_pedido_x_estoque x " +
                                                        "inner join tb_est_estoque y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.cd_produto = y.cd_produto " +
                                                        "and x.id_lanctoestoque = y.id_lanctoestoque " +
                                                        "where x.nr_pedido = a.nr_pedido " +
                                                        "and x.cd_produto = a.cd_produto " +
                                                        "and y.st_registro <> 'C'), 0) - " +
                                                        //Total Entrada
                                                        "isnull((select sum(isnull(y.qtd_entrada, 0)) from tb_fat_pedido_x_estoque x " +
                                                        "inner join tb_est_estoque y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.cd_produto = y.cd_produto " +
                                                        "and x.id_lanctoestoque = y.id_lanctoestoque " +
                                                        "where x.nr_pedido = a.nr_pedido " +
                                                        "and x.cd_produto = a.cd_produto " +
                                                        "and y.st_registro <> 'C'), 0)) - " +
                                                        //Total Fixado
                                                        "isnull((select sum(isnull(x.ps_fixado_total, 0)) " +
                                                        "from tb_gro_fixacao x " +
                                                        "inner join tb_gro_fixacao_x_contrato y " +
                                                        "on x.id_fixacao = y.id_fixacao " +
                                                        "where y.nr_contrato = a.nr_contrato " +
                                                        "and isnull(x.st_registro, 'A') <> 'C'), 0)) end > 0 ";
            }
            if (St_ContratoAberto)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'A'";
            }

            return new TCD_PedidoAplicacao().Select(filtro, vTop, string.Empty);
        }
    }
    
    public class TCN_LanAplicacaoPedido
    {
        // regras de gravacao de aplicacao
        public static TList_LanAplicacaoPedido Buscar(string vID_Aplicacao,
                                                      string vNR_Pedido,
                                                      string vCD_Produto,
                                                      string vCD_Empresa,
                                                      string vID_LanctoEstoque,
                                                      string vID_Ticket,
                                                      string vTP_Pesagem,TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if ((vID_Aplicacao.Trim() != string.Empty)&&(vID_Aplicacao.Trim() != "0"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Aplicacao";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Aplicacao;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if ((vNR_Pedido.Trim() != string.Empty)&&(vNR_Pedido.Trim() != "0"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Pedido";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Pedido;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_Produto.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_Empresa.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if ((vID_LanctoEstoque.Trim() != string.Empty) && (vID_LanctoEstoque.Trim() != "0"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_LanctoEstoque";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_LanctoEstoque;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if ((vID_Ticket.Trim() != string.Empty) && (vID_Ticket.Trim() != "0"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Ticket";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Ticket;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vTP_Pesagem.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Pesagem";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Pesagem.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            return new TCD_LanAplicacaoPedido(banco).Select(vBusca, 0, string.Empty, string.Empty, string.Empty);
        }

        public static TList_LanAplicacaoPedido BuscaAplicacao(string vCD_Contratante,
                                                              string vCD_Empresa,
                                                              string vCD_TabelaDesconto,
                                                              string vNR_Contrato,
                                                              string vNR_Pedido,
                                                              string vTP_Movimento,
                                                              string vLogin,
                                                              decimal vNr_lanctofiscal,
                                                              string vOrder,
                                                              TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[2];
            vBusca[0].vNM_Campo = string.Empty;
            vBusca[0].vVL_Busca = "(Select 1 From TB_DIV_Usuario_X_Empresa xy Where xy.CD_Empresa = a.CD_Empresa " +
                                  "and ((xy.Login = '" + vLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos yy " +
                                  "         where yy.logingrp = xy.login and yy.loginusr = '" + vLogin.Trim() + "'))))";
            vBusca[0].vOperador = "EXISTS";
            //Pesagem Fechada
            vBusca[1].vNM_Campo = "isnull(i.ST_Registro, 'A')";
            vBusca[1].vVL_Busca = "'F'";
            vBusca[1].vOperador = "=";
            if (!string.IsNullOrEmpty(vCD_Contratante))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "c.CD_Clifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Contratante.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_TabelaDesconto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "i.CD_TabelaDesconto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TabelaDesconto.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNR_Contrato))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "i.nr_contrato";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Contrato;
            }
            if (!string.IsNullOrEmpty(vNR_Pedido))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Pedido";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Pedido.Trim();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTP_Movimento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "i.TP_Movimento";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Movimento.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if(vNr_lanctofiscal > 0)
            {
                //Com notas
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fat_aplicacao_x_notafiscal xy " +
                                                      "inner join tb_fat_notafiscal yy " +
                                                      "on xy.cd_empresa = yy.cd_empresa " +
                                                      "and xy.nr_lanctofiscal = yy.nr_lanctofiscal " +
                                                      "where xy.id_aplicacao = a.id_aplicacao " +
                                                      "and isnull(yy.st_registro, 'A') <> 'C' " +
                                                      "and xy.cd_empresa = '" + vCD_Empresa.Trim() + "' " +
                                                      "and xy.nr_lanctofiscal = " + vNr_lanctofiscal.ToString() + ")";

            }
            return new TCD_LanAplicacaoPedido(banco).Select(vBusca, 0, string.Empty, string.Empty, vOrder);
        }      

        public static void ProcessarAplicacaoPedido(TList_RegLanFaturamento lNotas, 
                                                    decimal Qtd_saldoAplicar, 
                                                    TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanAplicacaoPedido qtb_aplic = new TCD_LanAplicacaoPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_aplic.CriarBanco_Dados(true);
                else
                    qtb_aplic.Banco_Dados = banco;
                lNotas.ForEach(p => p.lTicketAplicar.ForEach(v =>
                    GravarAplicacaoPedido(v.Cd_empresa,
                                          Qtd_saldoAplicar,
                                          p,
                                          qtb_aplic.Banco_Dados)));
                if (st_transacao)
                    qtb_aplic.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_aplic.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar aplicação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_aplic.deletarBanco_Dados();
            }
        }

        public static string GravarAplicacaoPedido(string CD_Empresa, 
                                                   decimal saldoAplicar, 
                                                   TRegistro_LanFaturamento rNotaFiscal, 
                                                   TObjetoBanco banco)
        {            
            TCD_LanAplicacaoPedido qtb_aplic = new TCD_LanAplicacaoPedido();
            bool pode_liberar = false;
            try
            {
                //Start Transação
                if (banco == null)
                    pode_liberar = qtb_aplic.CriarBanco_Dados(true);
                else
                    qtb_aplic.Banco_Dados = banco;

                //Gravar Notas Fiscais da Aplicacao                 
                if (rNotaFiscal == null)
                    throw new Exception("Erro processar aplicação. Não existe nota para processar.");

                if ((rNotaFiscal.Nr_pedido == null) || (rNotaFiscal.Nr_pedido == 0))
                    throw new Exception("ERRO: Não existe pedido informado para a nota fiscal " + rNotaFiscal.Nr_notafiscal.ToString());

                rNotaFiscal.ItensNota.ForEach(p =>
                {
                    if (p.Nr_pedido.Equals(0))
                        throw new Exception("ERRO: Não existe pedido informado para o item: " + p.Cd_produto.Trim() + "-"+ p.Ds_produto.Trim() + " da nota fiscal " + rNotaFiscal.Nr_notafiscal.ToString());

                    if ((p.Id_pedidoitem == null) || (p.Id_pedidoitem == 0))
                        throw new Exception("ERRO: Não existe item de pedido informado para o item: " + p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim() + " da nota fiscal " + rNotaFiscal.Nr_notafiscal.ToString());

                    TRegistro_EntregaPedido rgent = new TRegistro_EntregaPedido()
                    {
                        Id_entrega = null,
                        Nr_pedido = p.Nr_pedido,
                        Cd_produto = p.Cd_produto,
                        Id_pedidoitem = p.Id_pedidoitem,
                        Qtd_entregue = p.Quantidade_estoque > 0 ? p.Quantidade_estoque : p.Quantidade,
                        Dt_entrega = rNotaFiscal.Dt_saient,
                        Ds_observacao = "ENTREGA GRAVADA AUTOMATICAMENTE PELA APLICACAO"
                    };

                    rgent.Id_entregastr = TCN_LanEntregaPedido.Gravar(rgent, qtb_aplic.Banco_Dados);

                    //ADICIONAR A ENTREGA NA NOTAITEM PARA SER UTILIZADA NO PROCESSAMENTO DA NOTA 
                    //QUANDO FOR APLICACAO A ENTREGA A SER CUMPRIDA OBRIGATORIAMENTE SERA A GRAVADA ACIMA E NAO OUTRAS COM SALDO DISPONIVEL
                    p.lEntrega = new TList_EntregaPedido();
                    p.lEntrega.Add(rgent);
                });

                //Grava Nota Fiscal
                //gravar taxas de deposito separado da nota
                string retorno = TCN_LanFaturamento.GravarFaturamento(rNotaFiscal, false, null, qtb_aplic.Banco_Dados);
                //Para cada item da nota fiscal, gravar um registro aplicacao
                rNotaFiscal.ItensNota.ForEach(p =>
                {
                    if (p.rEstoque == null)
                        throw new Exception("Aplicação não pode ser processada. Não foi possivel gerar estoque.");
                    p.lTicketAplicar.ForEach(v =>
                        {
                            TRegistro_LanAplicacaoPedido val = new TRegistro_LanAplicacaoPedido();
                            //Gravar Aplicação
                            val.Cd_empresa = p.Cd_empresa;
                            val.Id_ticket = v.Id_ticket.Value;
                            val.Tp_pesagem = v.Tp_pesagem;
                            val.Nr_pedido = p.Nr_pedido;
                            val.Cd_produto = p.Cd_produto;
                            val.Id_pedidoitem = p.Id_pedidoitem.Value;
                            val.Id_lanctoestoque = p.rEstoque.Id_lanctoestoque;
                            val.Qtd_aplicado = v.Ps_Aplicar;
                            val.Vl_unitario = TCN_CadConvUnidade.ConvertUnid(v.Cd_unid_produto, v.Cd_unid_contrato, v.Vl_unit_contrato, 7, qtb_aplic.Banco_Dados);
                            val.Vl_subtotal = Math.Round(v.Ps_Aplicar * val.Vl_unitario, 2);
                            val.Id_aplicacao = null;
                            val.Id_autoriz = v.Id_autoriz;
                            string retorno_aplicacao = qtb_aplic.Gravar(val);
                            retorno = retorno + "|" + retorno_aplicacao;
                            val.Id_aplicacao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno_aplicacao, "@P_ID_APLICACAO"));
                            //Gravar Aplicação X Nota Fiscal
                            retorno = retorno + "|" + TCN_LanAplicacao_NotaFiscal.GravarAplicacaoXNotaFiscal(
                                new TRegistro_LanAplicacao_NotaFiscal()
                                {
                                    Cd_empresa = val.Cd_empresa,
                                    Id_aplicacao = val.Id_aplicacao,
                                    Id_nfitem = p.Id_nfitem,
                                    Nr_lanctofiscal = p.Nr_lanctofiscal
                                }, qtb_aplic.Banco_Dados);
                        });
                        //Gravar Movimento Deposito
                        TCN_MovDeposito.GravarMovDeposito(new TRegistro_MovDeposito()
                        {
                            Id_Movto = 0,
                            Nr_Pedido = p.Nr_pedido,
                            CD_Produto = p.Cd_produto,
                            CD_Empresa = p.Cd_empresa,
                            Id_LanctoEstoque = p.rEstoque.Id_lanctoestoque,
                            Id_pedidoitem = p.Id_pedidoitem.Value
                        }, qtb_aplic.Banco_Dados);
                        //Gravar Pesagem GMO
                        CamadaNegocio.Graos.TCN_LanRoyaltiesGMO.GravaPesagemGMO(p, rNotaFiscal.Tp_movimento, qtb_aplic.Banco_Dados);
                    //Contrato Entrada a Fixar
                    TRegistro_CadCFGPedido rCfg = new TCD_CadCFGPedido(qtb_aplic.Banco_Dados).Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                                        "where x.cfg_pedido = a.cfg_pedido " +
                                                                        "and x.nr_pedido = " + p.Nr_pedido.ToString() + ")"
                                                        }
                                                    }, 1, string.Empty)[0];
                });
                if (pode_liberar)
                    qtb_aplic.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_aplic.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar aplicação: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_aplic.deletarBanco_Dados();
            }
        }
    }
}
