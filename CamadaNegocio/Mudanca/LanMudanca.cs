using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Mudanca;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Mudanca
{
    public class TCN_LanMudanca
    {
        public static TList_LanMudanca Buscar(string Cd_empresa,
                                              string Id_Mudanca,
                                              string Nr_guardavol,  
                                              string Cd_clifor,
                                              string Id_veiculo,
                                              string Cd_motorista,
                                              string Cd_vendedor,
                                              string vTp_data,
                                              string vDt_ini,
                                              string vDt_fin,
                                              string St_registro,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_Mudanca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_Mudanca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_Mudanca;
            }
            if (!string.IsNullOrEmpty(Nr_guardavol))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_mud_guardavolume x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_mudanca = a.id_mudanca " +
                                                      "and isnull(x.st_registro, 'A') <> 'C' " +
                                                      "and x.nr_guardavol = '" + Nr_guardavol.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_veiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_veiculo;
            }
            if (!string.IsNullOrEmpty(Cd_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_motorista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_motorista.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("C") ? "a.dt_coleta" : vTp_data.Trim().ToUpper().Equals("E") ? "a.dt_entrega" : 
                    vTp_data.Trim().ToUpper().Equals("V") ? "a.dt_viagem" : "a.dt_saient") + ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("C") ? "a.dt_coleta" : vTp_data.Trim().ToUpper().Equals("E") ? "a.dt_entrega" :
                    vTp_data.Trim().ToUpper().Equals("V") ? "a.dt_viagem" : "a.dt_saient") + ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
           
            return new TCD_LanMudanca(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanMudanca val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanMudanca qtb_mud = new TCD_LanMudanca();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mud.CriarBanco_Dados(true);
                else
                    qtb_mud.Banco_Dados = banco;
                val.Id_mudancastr = CamadaDados.TDataQuery.getPubVariavel(qtb_mud.Gravar(val), "@P_ID_MUDANCA");
                //Excluir Itens Mudança
                val.lItensMudDel.ForEach(p => TCN_LanItensMud.Excluir(p, qtb_mud.Banco_Dados));
                //Gravar Itens Mudança
                val.lItensMud.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_mudanca = val.Id_mudanca;
                        TCN_LanItensMud.Gravar(p, qtb_mud.Banco_Dados);
                    });
                //Excluir Serviços Mudança
                val.lServicosMudDel.ForEach(p => TCN_LanServicosMud.Excluir(p, qtb_mud.Banco_Dados));
                //Gravar Serviços Mudança
                val.lServicosMud.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_mudanca = val.Id_mudanca;
                    TCN_LanServicosMud.Gravar(p, qtb_mud.Banco_Dados);
                });
                //Excluir Parcelas Mudança
                val.lParcelasMudDel.ForEach(p => TCN_ParcelasMud.Excluir(p, qtb_mud.Banco_Dados));
                //Gravar Parcelas Mudança
                val.lParcelasMud.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_mudanca = val.Id_mudanca;
                    TCN_ParcelasMud.Gravar(p, qtb_mud.Banco_Dados);
                });
                //Excluir Material Mudança
                val.lMaterialMudDel.ForEach(p => TCN_MaterialMud.Excluir(p, qtb_mud.Banco_Dados));
                //Gravar Material Mudança
                val.lMaterialMud.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_mudanca = val.Id_mudanca;
                    TCN_MaterialMud.Gravar(p, qtb_mud.Banco_Dados);
                });
                //Excluir Ajudantes Mudança
                val.lAjudantesMudDel.ForEach(p => TCN_AjudantesMud.Excluir(p, qtb_mud.Banco_Dados));
                //Gravar Ajudantes Mudança
                val.lAjudantesMud.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_mudanca = val.Id_mudanca;
                    TCN_AjudantesMud.Gravar(p, qtb_mud.Banco_Dados);
                });
                //Gravar Orcamento
                val.lOrcamento.ForEach(p => 
                    {
                        p.Id_mudancastr = val.Id_mudancastr;
                        p.St_registro = "1";
                        TCN_Orcamento.Gravar(p, qtb_mud.Banco_Dados);
                        TCN_LanMudanca.AprovarMudanca(val, qtb_mud.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_mud.Banco_Dados.Commit_Tran();
                return val.Id_mudancastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mud.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar mudança: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mud.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanMudanca val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanMudanca qtb_mud = new TCD_LanMudanca();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mud.CriarBanco_Dados(true);
                else
                    qtb_mud.Banco_Dados = banco;
                try
                {
                    //Excluir
                    qtb_mud.Excluir(val);
                }
                catch
                {
                    //Cancelar
                    val.St_registro = "3";
                    qtb_mud.Gravar(val);
                }
                //Verificar se Mudança possui Orçamento
                TList_Orcamento lOrcamento =
                    new TCD_Orcamento(qtb_mud.Banco_Dados).Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_mudanca",
                                vOperador = "=",
                                vVL_Busca = val.Id_mudancastr
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            }
                        }, 0, string.Empty);
                lOrcamento.ForEach(p =>
                    {
                        p.St_registro = "0";
                        p.Id_mudancastr = string.Empty;
                        TCN_Orcamento.Gravar(p, qtb_mud.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_mud.Banco_Dados.Commit_Tran();
                return val.Id_mudancastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mud.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir mudança: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mud.deletarBanco_Dados();
            }
        }

        public static void AprovarMudanca(TRegistro_LanMudanca val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanMudanca qtb_mud = new TCD_LanMudanca();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mud.CriarBanco_Dados(true);
                else qtb_mud.Banco_Dados = banco;
                val.St_registro = "1";//Aprovado
                //Gravar Viagem
                if (!val.Id_viagem.HasValue)
                {
                    CamadaDados.Frota.TRegistro_Viagem rViagem = new CamadaDados.Frota.TRegistro_Viagem();
                    rViagem.Cd_empresa = val.Cd_empresa;
                    rViagem.Id_veiculostr = val.Id_veiculostr;
                    rViagem.Cd_motorista = val.Cd_motorista;
                    rViagem.Dt_viagemstr = val.Dt_coletastr;
                    rViagem.Ds_viagem = "VIAGEM REALIZADA PELA MUDANÇA Nº" + val.Id_mudancastr;
                    rViagem.St_viagem = "E";
                    CamadaNegocio.Frota.TCN_Viagem.Gravar(rViagem, qtb_mud.Banco_Dados);
                    val.Id_viagem = rViagem.Id_viagem;
                }
                //Gravar Guarda Volume
                if (val.St_utilizaguardamoveisbool)
                {
                    TRegistro_GuardaVolume rGuarda = new TRegistro_GuardaVolume();
                    rGuarda.Cd_empresa = val.Cd_empresa;
                    rGuarda.Cd_clifor = val.Cd_clifor;
                    rGuarda.Cd_endereco = val.Cd_endereco;
                    rGuarda.Id_mudanca = val.Id_mudanca;
                    rGuarda.Dt_registro = CamadaDados.UtilData.Data_Servidor();
                    rGuarda.Dt_prevretirada = CamadaDados.UtilData.Data_Servidor().AddDays(Convert.ToDouble(val.NR_DiasGuardaMoveis.ToString()));
                    rGuarda.NR_GuardaVol = val.Nr_guardavol;
                    rGuarda.St_registro = "A";
                    val.lItensMud.ForEach(p =>
                    {
                        rGuarda.lItensGuardaVolume.Add(
                            new TRegistro_ItensGuardaVolume()
                            {
                                Id_item = p.Id_item,
                                Dt_locacao = rGuarda.Dt_registro,
                                Quantidade = p.Quantidade,
                                St_registro = "A"
                            });
                    });
                    TCN_GuardaVolume.Gravar(rGuarda, qtb_mud.Banco_Dados);
                }
                //Gravar Aprovação
                qtb_mud.Gravar(val);
                if (st_transacao)
                    qtb_mud.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mud.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro aprovar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mud.deletarBanco_Dados();
            }
        }

        public static string ProcessarMudanca(TRegistro_LanMudanca val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanMudanca qtb_mud = new TCD_LanMudanca();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mud.CriarBanco_Dados(true);
                else
                    qtb_mud.Banco_Dados = banco;
                //Gravar Duplicata
                if (val.lDup.Count > 0)
                {
                    TCN_LanDuplicata.GravarDuplicata(val.lDup, false, qtb_mud.Banco_Dados);
                    val.Nr_lancto = val.lDup[0].Nr_lancto;
                }
                //Gravar lançamento almoxarifado
                val.lMaterialMud.ForEach(p =>
                    {
                        //Buscar Almoxarifado
                        CamadaDados.Almoxarifado.TList_CadAlmoxarifado lAlmox =
                            new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado().Select(
                            new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_amx_almox_x_empresa x " +
                                            "where x.id_almox = a.id_almox " +
                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "')"
                            }
                        }, 1, string.Empty);
                        if (lAlmox.Count == 0)
                            throw new Exception("Não existe configuração de almoxarifado para a empresa!");
                        //Criar registro movimentação
                        CamadaDados.Almoxarifado.TRegistro_Movimentacao rMov =
                            new CamadaDados.Almoxarifado.TRegistro_Movimentacao();
                        rMov.Ds_observacao = "PRODUTO RETIRADO PELO MÓDULO MUDANÇA";
                        rMov.Cd_empresa = val.Cd_empresa;
                        rMov.Id_almoxstr = lAlmox[0].Id_almoxString;
                        rMov.Cd_produto = p.Cd_produto;
                        rMov.Quantidade = p.Quantidade;
                        rMov.Vl_unitario = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Vl_Custo_Almox_Prod(val.Cd_empresa,
                                                                                                 lAlmox[0].Id_almoxString,
                                                                                                 p.Cd_produto,
                                                                                                 qtb_mud.Banco_Dados);
                        rMov.Tp_movimento = "S";
                        rMov.LoginAlmoxarife = Utils.Parametros.pubLogin;
                        rMov.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                        rMov.St_registro = "A";
                        //Gravar Movimentação
                        CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(rMov, qtb_mud.Banco_Dados);
                        //Gravar Material mudança
                        p.Id_movimento = rMov.Id_movimento;
                        TCN_MaterialMud.Gravar(p, qtb_mud.Banco_Dados);
                    });
                val.St_registro = "4";//Processada
                //Gravar processamento mudança
                qtb_mud.Gravar(val);
                if (st_transacao)
                    qtb_mud.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mud.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mud.deletarBanco_Dados();
            }
        }

        public static TList_ParcelasMud Calcula_Parcelas(TRegistro_LanMudanca val)
        {
            TList_ParcelasMud retorno = new TList_ParcelasMud();
            if (val.Vl_mudanca > 0)
            {
                TList_Parcelas Lista_Parcela = TLanCalcParcelas.CalcularParcelas(val.Vl_mudanca,
                                                                                 val.Vl_mudanca,
                                                                                 CamadaDados.UtilData.Data_Servidor(),
                                                                                 val.QTD_parcelas.Equals(decimal.Zero) ? 1 : val.QTD_parcelas,
                                                                                 val.QTD_diasdesdobro);
                Lista_Parcela.ForEach(p =>
                {
                    retorno.Add(
                        new CamadaDados.Mudanca.TRegistro_ParcelasMud()
                        {
                            DiaVencto = p.Dt_vencimento.Value.Subtract(CamadaDados.UtilData.Data_Servidor()).Days,
                            Vl_parcela = p.Vl_parcela,
                        });
                });
            }
            return retorno;
        }

        public static void RecalcDiaVencto(TList_ParcelasMud val, decimal Qtd_desdobro, int index)
        {
            for (int i = (index + 1); i < val.Count; i++)
                val[i].DiaVencto = val[i - 1].DiaVencto + Qtd_desdobro;
        }

        public static void RecalculaParc(TList_ParcelasMud lParc,
                                        decimal Vl_documento,
                                        int index)
        {
            if (lParc.Sum(p => p.Vl_parcela) != Vl_documento)
            {
                decimal vl_parc = Math.Round((Vl_documento - lParc.Sum(p => p.Vl_parcela)) / (lParc.Count - index - 1), 2);
                for (int i = ++index; i < lParc.Count; i++)
                    lParc[i].Vl_parcela += vl_parc;
                lParc[lParc.Count - 1].Vl_parcela += Vl_documento - lParc.Sum(p => p.Vl_parcela);
            }
        }

        public static void GerarPedidoMudanca(ref CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed,
                                              CamadaDados.Mudanca.TRegistro_LanMudanca rMudanca,
                                              decimal valor,
                                              CamadaDados.Mudanca.Cadastros.TList_CFGMudanca lCfg)
        {
            if (!string.IsNullOrEmpty(lCfg[0].CFG_PedServico))
            {
                if (rPed == null)
                {
                    rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                    rPed.CD_Empresa = rMudanca != null ? rMudanca.Cd_empresa : string.Empty;
                    rPed.DT_Pedido = DateTime.Now;
                    rPed.CFG_Pedido = lCfg[0].CFG_PedServico;
                    rPed.TP_Movimento = "S"; //Pedido de saida
                    rPed.ST_Pedido = "F"; //Pedido fechado
                    rPed.ST_Registro = "F"; //Pedido fechado
                    rPed.CD_Clifor = rMudanca != null ? rMudanca.Cd_clifor : string.Empty;
                    rPed.CD_Endereco = rMudanca != null ? rMudanca.Cd_endereco : string.Empty;

                    CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item reg = new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item();
                    reg.Cd_Empresa = rMudanca.Cd_empresa;
                    reg.Cd_local = "000001";
                    reg.Cd_produto = lCfg[0].CD_ServPadrao;
                    reg.Ds_produto = lCfg[0].DS_ServPadrao;
                    reg.Quantidade = 1;
                    reg.Vl_unitario = valor;
                    reg.Vl_subtotal = valor;
                    reg.Tp_pedOS = "SV";
                    rPed.Pedido_Itens.Add(reg);
                }
            }
            else
                throw new Exception("Não existe configuracao para emitir pedido de serviço para mudança!");
        }

        public static string GravarFaturamento(TRegistro_LanFaturamento val, TRegistro_LanMudanca rMudanca, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanMudanca qtb_mud = new TCD_LanMudanca();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mud.CriarBanco_Dados(true);
                else
                    qtb_mud.Banco_Dados = banco;
                //Gravar Nota Fiscal
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(val, null, qtb_mud.Banco_Dados);
                //Gravar Mudança_X_NFSe
                TCN_Mudanca_X_NFSe.Gravar(
                    new TRegistro_Mudanca_X_NFSe()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_LanctoFiscal = val.Nr_lanctofiscal,
                        Id_mudanca = rMudanca.Id_mudanca
                    }, qtb_mud.Banco_Dados);
                if (st_transacao)
                    qtb_mud.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mud.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar faturamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mud.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ParcelasMud
    {
        public static TList_ParcelasMud Buscar(string Cd_empresa,
                                               string Id_mudanca,
                                               string Cd_parcela,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mudanca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_mudanca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mudanca;
            }
            if (!string.IsNullOrEmpty(Cd_parcela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_parcela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_parcela;
            }
            return new TCD_ParcelasMud(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ParcelasMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ParcelasMud qtb_parcela = new TCD_ParcelasMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_parcela.CriarBanco_Dados(true);
                else
                    qtb_parcela.Banco_Dados = banco;
                val.Cd_parcelastr = CamadaDados.TDataQuery.getPubVariavel(qtb_parcela.Gravar(val), "@P_CD_PARCELA");
                if (st_transacao)
                    qtb_parcela.Banco_Dados.Commit_Tran();
                return val.Cd_parcelastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_parcela.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar parcela: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_parcela.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ParcelasMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ParcelasMud qtb_parcela = new TCD_ParcelasMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_parcela.CriarBanco_Dados(true);
                else
                    qtb_parcela.Banco_Dados = banco;
                qtb_parcela.Excluir(val);
                if (st_transacao)
                    qtb_parcela.Banco_Dados.Commit_Tran();
                return val.Cd_parcelastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_parcela.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir parcela: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_parcela.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MaterialMud
    {
        public static TList_MaterialMud Buscar(string Cd_empresa,
                                               string Id_mudanca,
                                               string Cd_produto,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mudanca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_mudanca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mudanca;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_MaterialMud(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MaterialMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MaterialMud qtb_material = new TCD_MaterialMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_material.CriarBanco_Dados(true);
                else
                    qtb_material.Banco_Dados = banco;
                string retorno = qtb_material.Gravar(val);
                if (st_transacao)
                    qtb_material.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_material.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar material: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_material.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MaterialMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MaterialMud qtb_material = new TCD_MaterialMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_material.CriarBanco_Dados(true);
                else
                    qtb_material.Banco_Dados = banco;
                qtb_material.Excluir(val);
                if (st_transacao)
                    qtb_material.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_material.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir material: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_material.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AjudantesMud
    {
        public static TList_AjudantesMud Buscar(string Cd_empresa,
                                               string Id_mudanca,
                                               string Cd_ajudante,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mudanca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_mudanca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mudanca;
            }
            if (!string.IsNullOrEmpty(Cd_ajudante))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_ajudante";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_ajudante.Trim() + "'";
            }
            return new TCD_AjudantesMud(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AjudantesMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AjudantesMud qtb_ajudante = new TCD_AjudantesMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ajudante.CriarBanco_Dados(true);
                else
                    qtb_ajudante.Banco_Dados = banco;
                string retorno = qtb_ajudante.Gravar(val);
                if (st_transacao)
                    qtb_ajudante.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ajudante.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ajudante: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ajudante.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AjudantesMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AjudantesMud qtb_ajudante = new TCD_AjudantesMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ajudante.CriarBanco_Dados(true);
                else
                    qtb_ajudante.Banco_Dados = banco;
                qtb_ajudante.Excluir(val);
                if (st_transacao)
                    qtb_ajudante.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ajudante.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ajudante: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ajudante.deletarBanco_Dados();
            }
        }
    }
}
