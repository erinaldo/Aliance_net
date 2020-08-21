using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Adiantamento;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Caixa;

namespace CamadaNegocio.Financeiro.Adiantamento
{
    #region Adiantamento
    public class TCN_LanAdiantamento
    {
        public static TList_LanAdiantamento Buscar(string vId_adto,
                                                   string vCd_Empresa,
                                                   string vCd_Clifor,
                                                   string vDs_adto,
                                                   string vTp_movimento,
                                                   string vDt_lancto,
                                                   decimal vVl_adto,
                                                   string vDT_Inicial,
                                                   string vDT_Final,
                                                   decimal vVl_inicial,
                                                   decimal vVl_final,
                                                   bool vEncerrado,
                                                   bool vAberto,
                                                   bool vFechado,
                                                   string Tp_lancto,
                                                   bool vCancelado,
                                                   bool vSt_saldoDev,
                                                   string Id_caixaPDV,
                                                   string Id_locacao,
                                                   int vTop,
                                                   string vNm_campo,
                                                   TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_adto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Adto";
                filtro[filtro.Length - 1].vVL_Busca = vId_adto;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_Empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(vCd_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_Clifor.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDs_adto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Adto";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDs_adto.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vTp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Movimento";
                filtro[filtro.Length - 1].vVL_Busca = "(" + vTp_movimento.Trim() + ")";
                filtro[filtro.Length - 1].vOperador = "in";
            }
            if ((!string.IsNullOrEmpty(vDt_lancto)) && (vDt_lancto.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Lancto)))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Convert.ToDateTime(vDt_lancto).ToString("yyyyMMdd")) + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVl_adto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Vl_Adto";
                filtro[filtro.Length - 1].vVL_Busca = vVl_adto.ToString(new CultureInfo("en-US", true));
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if ((!string.IsNullOrEmpty(vDT_Inicial)) && (vDT_Inicial.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Inicial).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(vDT_Final)) && (vDT_Final.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Final).ToString("yyyyMMdd") + " 23:59:59'";
            }
            if (vEncerrado)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "((select isnull(case when tp_movimento = 'C' then sum(isnull(x.vl_receber,0)) else sum(isnull(x.vl_pagar,0)) end,0) " +
                                                      "from tb_fin_caixa x " +
                                                      "inner join tb_fin_adiantamento_x_caixa y " +
                                                      "on x.cd_contager = y.cd_contager " +
                                                      "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                      "where y.id_adto = a.id_adto " +
                                                      "and isnull(x.st_estorno, 'N') <> 'S') = a.vl_adto) ";
                if (!vCancelado)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.st_adto";
                    filtro[filtro.Length - 1].vOperador = "<>";
                    filtro[filtro.Length - 1].vVL_Busca = "'C'";
                }
            }
            if (vAberto)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.vl_adto > (select case when a.tp_movimento = 'C' then isNull(sum(isNull(y.vl_pagar,0)),0)" +
                                                      " else isNull(sum(isNull(y.vl_receber,0)),0) end " +
                                                      "        from tb_fin_adiantamento_x_caixa x " +
                                                      "	      inner join tb_fin_caixa y " +
                                                      "         on x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                      "        and x.cd_contager = y.cd_contager " +
                                                      "       where (a.id_adto = x.id_adto) and (isNull(y.st_estorno, 'N') = 'N'))) ";
                if (!vCancelado)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.st_adto";
                    filtro[filtro.Length - 1].vOperador = "<>";
                    filtro[filtro.Length - 1].vVL_Busca = "'C'";
                }
            }
            if (vFechado)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "((a.vl_adto = (select case when a.tp_movimento = 'C' then isNull(sum(isNull(y.vl_pagar,0)),0) " +
                                                      "else isNull(sum(isNull(y.vl_receber,0)),0) end " +
                                                      "       from tb_fin_adiantamento_x_caixa x " +
                                                      "      inner join tb_fin_caixa y " +
                                                      "     on x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                      "    and x.cd_contager = y.cd_contager " +
                                                      "   where (a.id_adto = x.id_adto) and (isNull(y.st_estorno, 'N') = 'N')))" +
                                                      "and ((select isnull(case when tp_movimento = 'C' then sum(isnull(x.vl_receber,0)) else sum(isnull(x.vl_pagar,0)) end,0) " +
                                                      "     from tb_fin_caixa x " +
                                                      "     inner join tb_fin_adiantamento_x_caixa y " +
                                                      "     on x.cd_contager = y.cd_contager " +
                                                      "     and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                      "     where y.id_adto = a.id_adto " +
                                                      "     and isnull(x.st_estorno, 'N') <> 'S') < a.vl_adto))";
                if (!vCancelado)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.st_adto";
                    filtro[filtro.Length - 1].vOperador = "<>";
                    filtro[filtro.Length - 1].vVL_Busca = "'C'";
                }
            }
            if (vCancelado)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_adto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'C'";
            }
            if (!string.IsNullOrEmpty(Tp_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_lancto";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_lancto.Trim() + ")";
                filtro[filtro.Length - 1].vOperador = "in";
            }
            if (vVl_inicial > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_adto";
                filtro[filtro.Length - 1].vVL_Busca = vVl_inicial.ToString(new System.Globalization.CultureInfo("en-US"));
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if (vVl_final > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_adto";
                filtro[filtro.Length - 1].vVL_Busca = vVl_final.ToString(new System.Globalization.CultureInfo("en-US"));
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(Id_caixaPDV))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixaPDV";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixaPDV;
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_LOC_AdtoLocacao x " +
                                                       "where x.Id_Adto = a.Id_Adto " +
                                                       "and x.ID_Locacao = " + Id_locacao + ") or " +
                                                       "not exists(select 1 from TB_LOC_AdtoLocacao x " +
                                                       "where x.Id_Adto = a.Id_Adto) ";
            }
            if (vSt_saldoDev)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "case when a.tp_movimento = 'C' then a.vl_pagar - a.vl_receber else a.vl_receber - a.vl_pagar end";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }

            return new TCD_LanAdiantamento(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TList_LanAdiantamento BuscarAdtoContrato(string Nr_contrato,
                                                               TObjetoBanco banco)
        {
            if (!string.IsNullOrEmpty(Nr_contrato.Trim()))
                return new TCD_LanAdiantamento(banco).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_gro_adto_contrato x " +
                                        "where x.id_adto = a.id_adto " +
                                        "and x.nr_contrato = " + Nr_contrato + ")"
                        }
                    }, 0, string.Empty);
            else
                return new TList_LanAdiantamento();
        }
        public static string Gravar(TRegistro_LanAdiantamento val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanAdiantamento qtb_adto = new TCD_LanAdiantamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                //Gravar Adiantamento
                string retorno = qtb_adto.Gravar(val);
                val.Id_adto = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_ADTO"));
                if (!string.IsNullOrEmpty(val.Cd_contager_qt))
                {
                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadConfigAdto(qtb_adto.Banco_Dados).BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        }
                                    }, val.Tp_movimento.Trim().ToUpper().Equals("C") ? "a.cd_historico_adto_c" : "a.cd_historico_adto_r");
                    if (obj == null ? true : string.IsNullOrEmpty(obj.ToString()))
                        throw new Exception("Não existe historico de quitação adiantamento " + val.Tipo_movimento + " para a empresa " + val.Cd_empresa.Trim());
                    //Quitar Adiantamento
                    val.List_Caixa.Add(new TRegistro_LanCaixa()
                    {
                        Cd_ContaGer = val.Cd_contager_qt,
                        Cd_Empresa = val.Cd_empresa,
                        Nr_Docto = "ADTO" + val.Id_adto.ToString(),
                        Cd_Historico = obj.ToString(),
                        Login = Parametros.pubLogin,
                        ComplHistorico = "QUITACAO ADIANTAMENTO " + val.Id_adto.ToString(),
                        Dt_lancto = val.Dt_lancto,
                        Vl_PAGAR = val.Tp_movimento.Trim().ToUpper().Equals("C") ? val.Vl_adto : decimal.Zero,
                        Vl_RECEBER = val.Tp_movimento.Trim().ToUpper().Equals("R") ? val.Vl_adto : decimal.Zero,
                        St_Titulo = "N",
                        St_Estorno = "N",
                        NM_Clifor = val.Nm_clifor,
                        St_avulso = "N"
                    });
                    TCN_LanAdiantamentoXCaixa.Quitar_Adiantamento(val, qtb_adto.Banco_Dados);
                }
                else if (val.lCheques.Count > 0)
                    TCN_LanAdiantamentoXCaixa.Quitar_AdiantamentoCheque(val, qtb_adto.Banco_Dados);
                else if (val.lFatura.Count > 0)
                    TCN_LanAdiantamentoXCaixa.Quitar_AdiantamentoFaturaCartao(val, qtb_adto.Banco_Dados);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar adiantamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanAdiantamento val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanAdiantamento qtb_adto = new TCD_LanAdiantamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                //Excluir Adiantamento
                object obj = new TCD_LanCaixa(qtb_adto.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x "+
                                        "where a.cd_contager = x.cd_contager "+
                                        "and a.cd_lanctocaixa = x.cd_lanctocaixa "+
                                        "and x.id_adto = " + val.Id_adto.ToString() + ")"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_estorno, 'N')",
                            vOperador = "<>",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = (val.Tp_movimento.Trim().ToUpper().Equals("C") ? "a.vl_receber": "a.vl_pagar"),
                            vOperador = ">",
                            vVL_Busca = "0"
                        }
                    }, "1");
                if (obj != null)
                    throw new Exception("Não é permitido cancelar adiantamentos com devoluções.");
                TList_LanCaixa lQuitacao = new TCD_LanCaixa(qtb_adto.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x "+
                                        "where a.cd_contager = x.cd_contager "+
                                        "and a.cd_lanctocaixa = x.cd_lanctocaixa "+
                                        "and x.id_adto = " + val.Id_adto.ToString() + ")"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_estorno, 'N')",
                            vOperador = "<>",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = (val.Tp_movimento.Trim().ToUpper().Equals("C") ? "a.vl_pagar": "a.vl_receber"),
                            vOperador = ">",
                            vVL_Busca = "0"
                        }
                    }, 0, string.Empty);
                lQuitacao.ForEach(p => TCN_LanCaixa.EstornarCaixa(p, null, qtb_adto.Banco_Dados));
                //Excluir Centro Resultado
                TCN_Adiantamento_X_CCusto.Buscar(val.Id_adto.ToString(),
                                                 string.Empty,
                                                 qtb_adto.Banco_Dados).ForEach(p =>
                                                     {
                                                         //Excluir Adiantamento X Centro Resultado
                                                         TCN_Adiantamento_X_CCusto.Excluir(p, qtb_adto.Banco_Dados);
                                                         //Excluir Centro Resultado
                                                         CCustoLan.TCN_LanCCustoLancto.Excluir(
                                                             new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                             {
                                                                 Id_ccustolan = p.Id_ccustolan
                                                             }, qtb_adto.Banco_Dados);
                                                     });
                qtb_adto.Excluir(val);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir adiantamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }

        public static TRegistro_LanCaixa DevolverAdto(TRegistro_LanAdiantamento val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanAdiantamento qtb_adto = new TCD_LanAdiantamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                //Buscar configuracao adiantamento
                CamadaDados.Financeiro.Cadastros.TList_ConfigAdto lConfig =
                    Cadastros.TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                       string.Empty,
                                                       string.Empty,
                                                       string.Empty,
                                                       string.Empty,
                                                       1,
                                                       string.Empty,
                                                       qtb_adto.Banco_Dados);
                if (lConfig.Count == 0)
                    throw new Exception("Não existe configuração adiantamento para a empresa " + val.Cd_empresa.Trim());
                if (string.IsNullOrEmpty(val.Tp_movimento.Trim().ToUpper().Equals("R") ? lConfig[0].Cd_historico_DEVADTO_R : lConfig[0].Cd_historico_DEVADTO_C))
                    throw new Exception("Não existe histórico de devolução adiantamento " + val.Tipo_movimento.Trim() + " para a empresa " + val.Cd_empresa.Trim());
                    //Gravar Caixa Devolucao
                    TRegistro_LanCaixa rCaixa = new TRegistro_LanCaixa();
                    //Campo responsavel por identificar que o lancamento de caixa pertence a um adiantamento
                    //Para que o mesmo não seja contabilizado automaticamente como lancamento de caixa
                    rCaixa.Id_adto = val.Id_adto;
                    rCaixa.Cd_ContaGer = string.IsNullOrEmpty(val.Cd_contagerDev) ? val.Cd_contager_qt : val.Cd_contagerDev;
                    rCaixa.Cd_Empresa = val.Cd_empresa;
                    rCaixa.Nr_Docto = "DEV" + val.Id_adto.ToString();
                    rCaixa.Cd_Historico = val.Tp_movimento.Trim().ToUpper().Equals("R") ? lConfig[0].Cd_historico_DEVADTO_R : lConfig[0].Cd_historico_DEVADTO_C;
                    rCaixa.Login = Utils.Parametros.pubLogin;
                    rCaixa.ComplHistorico = "DEVOLUCAO ADIANTAMENTO " + val.Id_adto.ToString();
                    rCaixa.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                    rCaixa.Vl_PAGAR = val.Tp_movimento.Trim().ToUpper().Equals("R") ? val.Vl_devolver : decimal.Zero;
                    rCaixa.Vl_RECEBER = val.Tp_movimento.Trim().ToUpper().Equals("R") ? decimal.Zero : val.Vl_devolver;
                    rCaixa.St_Titulo = "N";
                    rCaixa.St_Estorno = "N";
                    rCaixa.NM_Clifor = val.Nm_clifor;
                    TCN_LanCaixa.GravaLanCaixa(rCaixa, qtb_adto.Banco_Dados);
                    val.Cd_lanctoCaixaDev = rCaixa.Cd_LanctoCaixa;
                    //Gravar Adiantamento X Caixa
                    TCN_LanAdiantamentoXCaixa.Gravar(
                        new TRegistro_LanAdiantamentoXCaixa()
                        {
                            Cd_contager = string.IsNullOrEmpty(val.Cd_contagerDev) ? val.Cd_contager_qt : val.Cd_contagerDev,
                            Cd_lanctocaixa = rCaixa.Cd_LanctoCaixa,
                            Id_adto = val.Id_adto
                        }, qtb_adto.Banco_Dados);
                    //Contabilizar Devolucao
                    List<CamadaDados.Contabil.TRegistro_ProcAdiantamento> lProcAdto =
                    CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscarProc_Adiantamento(string.Empty,
                                                                                        string.IsNullOrEmpty(val.Cd_contagerDev) ? val.Cd_contager_qt : val.Cd_contagerDev,
                                                                                        rCaixa.Cd_LanctoCaixa.ToString(),
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        decimal.Zero,
                                                                                        decimal.Zero,
                                                                                        decimal.Zero,
                                                                                        false,
                                                                                        qtb_adto.Banco_Dados);
                    if (lProcAdto.Count > 0)
                        if (lProcAdto.Exists(v => v.CD_ContaDeb.HasValue && v.CD_ContaCre.HasValue))
                            CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Adto(lProcAdto.FindAll(v => v.CD_ContaCre.HasValue && v.CD_ContaDeb.HasValue), qtb_adto.Banco_Dados);
                    //Gravar Centro Resultado Devolucao Adiantamento
                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                     val.Cd_empresa,
                                                                     qtb_adto.Banco_Dados).Trim().ToUpper().Equals("S"))
                    {
                    if (val.lCustoLanDel != null)
                        //Excluir Centro Resultado
                        val.lCustoLanDel.ForEach(p =>
                        {
                            TCN_Adiantamento_X_CCusto.Excluir(new TRegistro_Adiantamento_X_CCusto()
                            {
                                Id_adto = val.Id_adto,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_adto.Banco_Dados);
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(p, qtb_adto.Banco_Dados);
                        });
                    if (val.lCustoLancto != null)
                        //Gravar Centro Resultado
                        val.lCustoLancto.ForEach(p =>
                        {
                            p.Cd_empresa = val.Cd_empresa;
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(p, qtb_adto.Banco_Dados);
                            //Gravar Emprestimo X CCusto
                            TCN_Adiantamento_X_CCusto.Gravar(new TRegistro_Adiantamento_X_CCusto()
                            {
                                Id_adto = val.Id_adto,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_adto.Banco_Dados);
                        });
                    if (val.Tp_movimento.Trim().ToUpper().Equals("C") &&
                            (!string.IsNullOrEmpty(lConfig[0].Cd_centroresult_DEVADTO_C)))
                        {
                            string id_lan =
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                                new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                {
                                    Cd_empresa = val.Cd_empresa,
                                    Cd_centroresult = lConfig[0].Cd_centroresult_DEVADTO_C,
                                    Vl_lancto = val.List_Caixa.Sum(p => p.Vl_PAGAR),
                                    Dt_lancto = val.List_Caixa[0].Dt_lancto
                                }, qtb_adto.Banco_Dados);
                            //Gravar Emprestimo X CCusto
                            TCN_Adiantamento_X_CCusto.Gravar(new TRegistro_Adiantamento_X_CCusto()
                            {
                                Id_adto = val.Id_adto,
                                Id_ccustolan = decimal.Parse(id_lan)
                            }, qtb_adto.Banco_Dados);
                        }
                        else if (val.Tp_movimento.Trim().ToUpper().Equals("R") &&
                            (!string.IsNullOrEmpty(lConfig[0].Cd_centroresult_DEVADTO_R)))
                        {
                            string id_lan =
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                                new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                {
                                    Cd_empresa = val.Cd_empresa,
                                    Cd_centroresult = lConfig[0].Cd_centroresult_DEVADTO_R,
                                    Vl_lancto = val.List_Caixa.Sum(p => p.Vl_RECEBER),
                                    Dt_lancto = val.List_Caixa[0].Dt_lancto
                                }, qtb_adto.Banco_Dados);
                            //Gravar Emprestimo X CCusto
                            TCN_Adiantamento_X_CCusto.Gravar(new TRegistro_Adiantamento_X_CCusto()
                            {
                                Id_adto = val.Id_adto,
                                Id_ccustolan = decimal.Parse(id_lan)
                            }, qtb_adto.Banco_Dados);
                        }
                    }
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return rCaixa;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro devolver adiantamento: " + ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Adiantamento X Caixa
    public class TCN_LanAdiantamentoXCaixa
    {
        public static TList_LanAdiantamentoXCaixa Buscar(decimal vId_Adto,
                                                         decimal vCD_LanctoCaixa,
                                                         string vCD_ContaGer,
                                                         bool vSt_LanCaixa,
                                                         int vTop, 
                                                         string vNm_campo)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vId_Adto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Adto";
                filtro[filtro.Length - 1].vVL_Busca = vId_Adto.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vCD_LanctoCaixa > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_LanctoCaixa";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LanctoCaixa.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(vCD_ContaGer))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaGer";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_ContaGer.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vSt_LanCaixa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_caixa x " +
                                                      "where x.cd_contager = a.cd_contager " +
                                                      "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                      "and isnull(x.st_estorno, 'N') <> 'S')";
            }

            return new TCD_AdiantamentoXCaixa().Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_LanAdiantamentoXCaixa val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AdiantamentoXCaixa qtb_adto = new TCD_AdiantamentoXCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                string retorno = qtb_adto.Gravar(val);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }

        public static string Quitar_Adiantamento(TRegistro_LanAdiantamento val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            string retorno = string.Empty;
            TCD_AdiantamentoXCaixa qtb_AdiantamentoXCaixa = new TCD_AdiantamentoXCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_AdiantamentoXCaixa.CriarBanco_Dados(true);
                else
                    qtb_AdiantamentoXCaixa.Banco_Dados = banco;

                val.List_Caixa.ForEach(p =>
                {
                    //Campo responsavel por identificar que o lancamento de caixa pertence a um adiantamento
                    //Para que o mesmo não seja contabilizado automaticamente como lancamento de caixa
                    p.Id_adto = val.Id_adto;
                    //Gravar caixa
                    retorno = TCN_LanCaixa.GravaLanCaixa(p, qtb_AdiantamentoXCaixa.Banco_Dados);
                    //Gravar Adiantamento X Caixa
                    qtb_AdiantamentoXCaixa.Gravar(new TRegistro_LanAdiantamentoXCaixa()
                        {
                            Cd_contager = p.Cd_ContaGer,
                            Cd_lanctocaixa = p.Cd_LanctoCaixa,
                            Id_adto = val.Id_adto
                        });
                    //Contabilizar Quitação Adiantamento
                    List<CamadaDados.Contabil.TRegistro_ProcAdiantamento> lProcAdto =
                        CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscarProc_Adiantamento(string.Empty,
                                                                                            p.Cd_ContaGer,
                                                                                            p.Cd_LanctoCaixa.ToString(),
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            decimal.Zero,
                                                                                            decimal.Zero,
                                                                                            decimal.Zero,
                                                                                            false,
                                                                                            qtb_AdiantamentoXCaixa.Banco_Dados);
                    if (lProcAdto.Count > 0)
                        if (lProcAdto.Exists(v => v.CD_ContaDeb.HasValue && v.CD_ContaCre.HasValue))
                            CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Adto(lProcAdto.FindAll(v => v.CD_ContaCre.HasValue && v.CD_ContaDeb.HasValue), qtb_AdiantamentoXCaixa.Banco_Dados);
                });
                //Buscar Config Adiantamento
                CamadaDados.Financeiro.Cadastros.TList_ConfigAdto lCfg =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1,
                                                                                string.Empty,
                                                                                qtb_AdiantamentoXCaixa.Banco_Dados);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração para quitar adiantamento na empresa " + val.Cd_empresa.Trim());
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                         val.Cd_empresa,
                                                                         qtb_AdiantamentoXCaixa.Banco_Dados).Trim().ToUpper().Equals("S"))
                {
                    if (val.lCustoLanDel != null)
                        //Excluir Centro Resultado
                        val.lCustoLanDel.ForEach(p =>
                        {
                            TCN_Adiantamento_X_CCusto.Excluir(new TRegistro_Adiantamento_X_CCusto()
                            {
                                Id_adto = val.Id_adto,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_AdiantamentoXCaixa.Banco_Dados);
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(p, qtb_AdiantamentoXCaixa.Banco_Dados);
                        });
                    if (val.lCustoLancto != null)
                        //Gravar Centro Resultado
                        val.lCustoLancto.ForEach(p =>
                        {
                            p.Cd_empresa = val.Cd_empresa;
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(p, qtb_AdiantamentoXCaixa.Banco_Dados);
                            //Gravar Emprestimo X CCusto
                            TCN_Adiantamento_X_CCusto.Gravar(new TRegistro_Adiantamento_X_CCusto()
                            {
                                Id_adto = val.Id_adto,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_AdiantamentoXCaixa.Banco_Dados);
                        });
                    if (val.Tp_movimento.Trim().ToUpper().Equals("C") &&
                        (!string.IsNullOrEmpty(lCfg[0].Cd_centroresult_ADTO_C)))
                    {
                        string id_lan =
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_centroresult = lCfg[0].Cd_centroresult_ADTO_C,
                                Vl_lancto = val.List_Caixa.Sum(p=> p.Vl_PAGAR),
                                Dt_lancto = val.List_Caixa[0].Dt_lancto
                            }, qtb_AdiantamentoXCaixa.Banco_Dados);
                        //Gravar Emprestimo X CCusto
                        TCN_Adiantamento_X_CCusto.Gravar(new TRegistro_Adiantamento_X_CCusto()
                        {
                            Id_adto = val.Id_adto,
                            Id_ccustolan = decimal.Parse(id_lan)
                        }, qtb_AdiantamentoXCaixa.Banco_Dados);
                    }
                    else if (val.Tp_movimento.Trim().ToUpper().Equals("R") &&
                        (!string.IsNullOrEmpty(lCfg[0].Cd_centroresult_ADTO_R)))
                    {
                        string id_lan =
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_centroresult = lCfg[0].Cd_centroresult_ADTO_R,
                                Vl_lancto = val.List_Caixa.Sum(p => p.Vl_RECEBER),
                                Dt_lancto = val.List_Caixa[0].Dt_lancto
                            }, qtb_AdiantamentoXCaixa.Banco_Dados);
                        //Gravar Emprestimo X CCusto
                        TCN_Adiantamento_X_CCusto.Gravar(new TRegistro_Adiantamento_X_CCusto()
                        {
                            Id_adto = val.Id_adto,
                            Id_ccustolan = decimal.Parse(id_lan)
                        }, qtb_AdiantamentoXCaixa.Banco_Dados);
                    }
                }

                if (st_transacao)
                    qtb_AdiantamentoXCaixa.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_AdiantamentoXCaixa.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_AdiantamentoXCaixa.deletarBanco_Dados();
            }
        }

        public static void Quitar_AdiantamentoCheque(TRegistro_LanAdiantamento val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AdiantamentoXCaixa qtb_adto = new TCD_AdiantamentoXCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                //Gravar os cheques
                val.lCheques.ForEach(p =>
                {
                    p.St_lancarcaixa = true;//Gravar titulo e caixa
                    p.Id_adto = val.Id_adto;//Contabilizar caixa automaticamente pelo caixa
                    string ret = CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.GravarTitulo(p, qtb_adto.Banco_Dados);
                    //Gravar adiantamento x caixa
                    Gravar(new TRegistro_LanAdiantamentoXCaixa()
                    {
                        Cd_contager = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_CD_CONTAGER"),
                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_CD_LANCTOCAIXA")),
                        Id_adto = val.Id_adto
                    }, qtb_adto.Banco_Dados);
                    List<CamadaDados.Contabil.TRegistro_ProcAdiantamento> lProcAdto =
                        CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscarProc_Adiantamento(string.Empty,
                                                                                            CamadaDados.TDataQuery.getPubVariavel(ret, "@P_CD_CONTAGER"),
                                                                                            CamadaDados.TDataQuery.getPubVariavel(ret, "@P_CD_LANCTOCAIXA"),
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            decimal.Zero,
                                                                                            decimal.Zero,
                                                                                            decimal.Zero,
                                                                                            false,
                                                                                            qtb_adto.Banco_Dados);
                    if (lProcAdto.Count > 0)
                        if (lProcAdto.Exists(v => v.CD_ContaDeb.HasValue && v.CD_ContaCre.HasValue))
                            CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Adto(lProcAdto.FindAll(v => v.CD_ContaCre.HasValue && v.CD_ContaDeb.HasValue), qtb_adto.Banco_Dados);
                });
                //Buscar Config Adiantamento
                CamadaDados.Financeiro.Cadastros.TList_ConfigAdto lCfg =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1,
                                                                                string.Empty,
                                                                                qtb_adto.Banco_Dados);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração para quitar adiantamento na empresa " + val.Cd_empresa.Trim());
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                         val.Cd_empresa,
                                                                         qtb_adto.Banco_Dados).Trim().ToUpper().Equals("S"))
                {
                    if (val.lCustoLanDel != null)
                        //Excluir Centro Resultado
                        val.lCustoLanDel.ForEach(p =>
                        {
                            TCN_Adiantamento_X_CCusto.Excluir(new TRegistro_Adiantamento_X_CCusto()
                            {
                                Id_adto = val.Id_adto,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_adto.Banco_Dados);
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(p, qtb_adto.Banco_Dados);
                        });
                    if (val.lCustoLancto != null)
                        //Gravar Centro Resultado
                        val.lCustoLancto.ForEach(p =>
                        {
                            p.Cd_empresa = val.Cd_empresa;
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(p, qtb_adto.Banco_Dados);
                            //Gravar Emprestimo X CCusto
                            TCN_Adiantamento_X_CCusto.Gravar(new TRegistro_Adiantamento_X_CCusto()
                            {
                                Id_adto = val.Id_adto,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_adto.Banco_Dados);
                        });
                    if (val.Tp_movimento.Trim().ToUpper().Equals("C") &&
                        (!string.IsNullOrEmpty(lCfg[0].Cd_centroresult_ADTO_C)))
                    {
                        string id_lan =
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_centroresult = lCfg[0].Cd_centroresult_ADTO_C,
                                Vl_lancto = val.List_Caixa.Sum(p => p.Vl_PAGAR),
                                Dt_lancto = val.List_Caixa[0].Dt_lancto
                            }, qtb_adto.Banco_Dados);
                        //Gravar Emprestimo X CCusto
                        TCN_Adiantamento_X_CCusto.Gravar(new TRegistro_Adiantamento_X_CCusto()
                        {
                            Id_adto = val.Id_adto,
                            Id_ccustolan = decimal.Parse(id_lan)
                        }, qtb_adto.Banco_Dados);
                    }
                    else if (val.Tp_movimento.Trim().ToUpper().Equals("R") &&
                        (!string.IsNullOrEmpty(lCfg[0].Cd_centroresult_ADTO_R)))
                    {
                        string id_lan =
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_centroresult = lCfg[0].Cd_centroresult_ADTO_R,
                                Vl_lancto = val.List_Caixa.Sum(p => p.Vl_RECEBER),
                                Dt_lancto = val.List_Caixa[0].Dt_lancto
                            }, qtb_adto.Banco_Dados);
                        //Gravar Emprestimo X CCusto
                        TCN_Adiantamento_X_CCusto.Gravar(new TRegistro_Adiantamento_X_CCusto()
                        {
                            Id_adto = val.Id_adto,
                            Id_ccustolan = decimal.Parse(id_lan)
                        }, qtb_adto.Banco_Dados);
                    }
                }
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }

        public static void Quitar_AdiantamentoFaturaCartao(TRegistro_LanAdiantamento val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AdiantamentoXCaixa qtb_adto = new TCD_AdiantamentoXCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                //Gravar os cheques
                val.lFatura.ForEach(p =>
                {
                    p.Id_adto = val.Id_adto;
                    CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.Gravar(p, qtb_adto.Banco_Dados);
                    //Buscar Financeiro Caixa
                    p.lCaixa = new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(qtb_adto.Banco_Dados).Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                                "where x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                                "and x.cd_contager = a.cd_contager " +
                                                                "and x.cd_contager = '" + p.Cd_contager.Trim() + "'" +
                                                                "and x.id_fatura = " + p.Id_fatura + ") "
                                                }
                                            }, 0, string.Empty);
                    if (p.lCaixa.Count > 0)
                        p.lCaixa.ForEach(x =>
                        {
                            //Gravar adiantamento x caixa
                            Gravar(new TRegistro_LanAdiantamentoXCaixa()
                            {
                                Cd_contager = p.Cd_contager,
                                Cd_lanctocaixa = x.Cd_LanctoCaixa,
                                Id_adto = val.Id_adto
                            }, qtb_adto.Banco_Dados);
                            List<CamadaDados.Contabil.TRegistro_ProcAdiantamento> lProcAdto =
                                CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscarProc_Adiantamento(string.Empty,
                                                                                                    x.Cd_ContaGer,
                                                                                                    x.Cd_LanctoCaixa.ToString(),
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    decimal.Zero,
                                                                                                    decimal.Zero,
                                                                                                    decimal.Zero,
                                                                                                    false,
                                                                                                    qtb_adto.Banco_Dados);
                            if (lProcAdto.Count > 0)
                                if (lProcAdto.Exists(v => v.CD_ContaDeb.HasValue && v.CD_ContaCre.HasValue))
                                    CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Adto(lProcAdto.FindAll(v => v.CD_ContaCre.HasValue && v.CD_ContaDeb.HasValue), qtb_adto.Banco_Dados);
                        });
                });
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanAdiantamentoXCaixa val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AdiantamentoXCaixa qtb_adto = new TCD_AdiantamentoXCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                qtb_adto.Excluir(val);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Adiantamento X Centro Resultado
    public class TCN_Adiantamento_X_CCusto
    {
        public static TList_Adiantamento_X_CCusto Buscar(string Id_adto,
                                                         string Id_ccustolan,
                                                         BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_adto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_adto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_adto;
            }
            if (!string.IsNullOrEmpty(Id_ccustolan))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ccustolan";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ccustolan;
            }
            return new TCD_Adiantamento_X_CCusto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Adiantamento_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Adiantamento_X_CCusto qtb_custo = new TCD_Adiantamento_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else
                    qtb_custo.Banco_Dados = banco;
                string retorno = qtb_custo.Gravar(val);
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Adiantamento_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Adiantamento_X_CCusto qtb_custo = new TCD_Adiantamento_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else
                    qtb_custo.Banco_Dados = banco;
                qtb_custo.Excluir(val);
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
