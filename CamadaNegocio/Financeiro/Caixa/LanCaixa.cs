using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using CamadaDados.Financeiro.Caixa;
using BancoDados;
using CamadaDados.Financeiro.Titulo;
using CamadaNegocio.Financeiro.Titulo;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using System.Globalization;

namespace CamadaNegocio.Financeiro.Caixa
{
    public class TCN_LanCaixa
    {
        #region Caixa
        public static decimal BuscarSaldoCaixa(string Cd_contager,
                                               TObjetoBanco banco)
        {
            object obj = new TCD_LanCaixa(banco).BuscarSaldoCaixa(Cd_contager);
            try
            {
                return decimal.Parse(obj.ToString());
            }
            catch { return decimal.Zero; }
        }

        public static decimal BuscarSaldoCaixaData(string Cd_contager,
                                                   DateTime Dt_lancto,
                                                   TObjetoBanco banco)
        {
            object obj = new TCD_LanCaixa(banco).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_contager",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_contager.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "CONVERT(datetime, FLOOR(CONVERT(decimal(30,10), a.DT_Lancto)))",
                                    vOperador = "<=",
                                    vVL_Busca = "'" + Dt_lancto.ToString("yyyyMMdd") + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_estorno, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                }
                            }, "isnull(sum(a.vl_receber - a.vl_pagar), 0)");
            return obj != null ? decimal.Parse(obj.ToString()) : decimal.Zero;
        }

        public static bool BloquearCaixaSemSaldo(TRegistro_LanCaixa val,
                                                 TObjetoBanco banco)
        {
            if (val.Vl_RECEBER > 0)
                return false;
            else
            {
                //Buscar registro conta gerencial
                CamadaDados.Financeiro.Cadastros.TList_CadContaGer lConta =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadContaGer.Buscar(val.Cd_ContaGer,
                                                                              string.Empty,
                                                                              null,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              decimal.Zero,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              banco);
                if (lConta[0].St_controlarsaldobool)
                {
                    decimal vl_atual = BuscarSaldoCaixa(val.Cd_ContaGer, banco);
                    if (val.Vl_PAGAR > (vl_atual + lConta[0].Vl_limite))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        public static TList_LanCaixa BuscaAudit(string vCD_ContaGer,
                                             string vCD_LanctoCaixa,
                                             string vCD_Empresa,
                                             string vNr_Docto,
                                             string vCD_Historico,
                                             string vComplHistorico,
                                             string vDT_lancto_ini,
                                             string vDT_lancto_fin,
                                             decimal vVl_ini,
                                             decimal vVl_fin,
                                             string vTp_valor,
                                             string vST_Titulo,
                                             string vST_Estorno,
                                             bool vMostrar_Estornos,
                                             string vLanctoTitulo,
                                             decimal vID_Adto,
                                             bool St_avulso,
                                             TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if ((vCD_ContaGer.Trim() != "") && (vCD_ContaGer.Trim() != "0"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaGer";
                filtro[filtro.Length - 1].vVL_Busca = vCD_ContaGer;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if ((vCD_LanctoCaixa.Trim() != "") && (vCD_LanctoCaixa.Trim() != "0"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_LanctoCaixa";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LanctoCaixa;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = vCD_Empresa;
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

            if (vNr_Docto.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Docto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_Docto + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if ((vCD_Historico.Trim() != "") && (vCD_Historico.Trim() != "0"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Historico";
                filtro[filtro.Length - 1].vVL_Busca = vCD_Historico;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vComplHistorico.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ComplHistorico";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vComplHistorico + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if ((vDT_lancto_ini.Trim() != "") && (vDT_lancto_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DT_Lancto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_lancto_ini).ToString("yyyyMMdd")) + " 00:00'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((vDT_lancto_fin.Trim() != "") && (vDT_lancto_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DT_Lancto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_lancto_fin).ToString("yyyyMMdd")) + " 23:59'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }

            if (vST_Titulo.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.ST_Titulo,'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vST_Titulo + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vST_Estorno.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.ST_Estorno,'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vST_Estorno + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vLanctoTitulo.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "";
                filtro[filtro.Length - 1].vVL_Busca = "(Select 1 From TB_FIN_Titulo_X_Caixa x " +
                                                      "Where x.CD_ContaGer = a.CD_ContaGer " +
                                                      "and x.CD_LanctoCaixa = a.CD_LanctoCaixa and " + vLanctoTitulo + ")";
                filtro[filtro.Length - 1].vOperador = "EXISTS";
            }

            if (vID_Adto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "e.ID_Adto";
                filtro[filtro.Length - 1].vVL_Busca = vID_Adto.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vMostrar_Estornos == true)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_estorno, 'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
                filtro[filtro.Length - 1].vOperador = "<>";
            }
            if (vTp_valor.Trim() != string.Empty)
            {
                if (vVl_ini > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    if (vTp_valor.Trim().ToUpper().Equals("P"))
                        filtro[filtro.Length - 1].vNM_Campo = "a.vl_pagar";
                    else
                        filtro[filtro.Length - 1].vNM_Campo = "a.vl_receber";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new CultureInfo("en-US", true));
                }
                if (vVl_fin > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    if (vTp_valor.Trim().ToUpper().Equals("P"))
                        filtro[filtro.Length - 1].vNM_Campo = "a.vl_pagar";
                    else
                        filtro[filtro.Length - 1].vNM_Campo = "a.vl_receber";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new CultureInfo("en-US", true));
                }
            }
            if (St_avulso)
                Estruturas.CriarParametro(ref filtro, "isnull(a.st_avulso, 'N')", "'S'");
            Estruturas.CriarParametro(ref filtro, "a.dt_auditavulso", "null", "is");

            return new TCD_LanCaixa(banco).Select(filtro, 0, "");
        }

        public static TList_LanCaixa Busca(string vCD_ContaGer,
                                             string vCD_LanctoCaixa,
                                             string vCD_Empresa,
                                             string vNr_Docto,
                                             string vCD_Historico,
                                             string vComplHistorico,
                                             string vDT_lancto_ini,
                                             string vDT_lancto_fin,
                                             decimal vVl_ini,
                                             decimal vVl_fin,
                                             string vTp_valor,
                                             string vST_Titulo,
                                             string vST_Estorno,
                                             bool vMostrar_Estornos,
                                             string vLanctoTitulo,
                                             decimal vID_Adto,
                                             bool St_avulso,
                                             TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if ((vCD_ContaGer.Trim() != "") && (vCD_ContaGer.Trim() != "0"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaGer";
                filtro[filtro.Length - 1].vVL_Busca = vCD_ContaGer;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if ((vCD_LanctoCaixa.Trim() != "") && (vCD_LanctoCaixa.Trim() != "0"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_LanctoCaixa";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LanctoCaixa;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = vCD_Empresa;
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

            if (vNr_Docto.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Docto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_Docto + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if ((vCD_Historico.Trim() != "") && (vCD_Historico.Trim() != "0"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Historico";
                filtro[filtro.Length - 1].vVL_Busca = vCD_Historico;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vComplHistorico.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ComplHistorico";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vComplHistorico + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if ((vDT_lancto_ini.Trim() != "") && (vDT_lancto_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DT_Lancto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_lancto_ini).ToString("yyyyMMdd")) + " 00:00'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((vDT_lancto_fin.Trim() != "") && (vDT_lancto_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DT_Lancto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_lancto_fin).ToString("yyyyMMdd")) + " 23:59'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }

            if (vST_Titulo.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.ST_Titulo,'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vST_Titulo + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vST_Estorno.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.ST_Estorno,'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vST_Estorno + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vLanctoTitulo.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "";
                filtro[filtro.Length - 1].vVL_Busca = "(Select 1 From TB_FIN_Titulo_X_Caixa x " +
                                                      "Where x.CD_ContaGer = a.CD_ContaGer " +
                                                      "and x.CD_LanctoCaixa = a.CD_LanctoCaixa and " + vLanctoTitulo + ")";
                filtro[filtro.Length - 1].vOperador = "EXISTS";
            }

            if (vID_Adto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "e.ID_Adto";
                filtro[filtro.Length - 1].vVL_Busca = vID_Adto.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vMostrar_Estornos == true)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_estorno, 'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
                filtro[filtro.Length - 1].vOperador = "<>";
            }
            if (vTp_valor.Trim() != string.Empty)
            {
                if (vVl_ini > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    if (vTp_valor.Trim().ToUpper().Equals("P"))
                        filtro[filtro.Length - 1].vNM_Campo = "a.vl_pagar";
                    else
                        filtro[filtro.Length - 1].vNM_Campo = "a.vl_receber";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new CultureInfo("en-US", true));
                }
                if (vVl_fin > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    if (vTp_valor.Trim().ToUpper().Equals("P"))
                        filtro[filtro.Length - 1].vNM_Campo = "a.vl_pagar";
                    else
                        filtro[filtro.Length - 1].vNM_Campo = "a.vl_receber";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new CultureInfo("en-US", true));
                }
            }
            if (St_avulso)
                Estruturas.CriarParametro(ref filtro, "isnull(a.st_avulso, 'N')", "'S'");
            return new TCD_LanCaixa(banco).Select(filtro, 0, "");
        }

        public static TList_LanCaixa BuscarRelDetalhesResultado(string Cd_empresa,
                                                                string Cd_grupocf,
                                                                string Ano,
                                                                string Mes,
                                                                TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Ano.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "year(a.dt_lancto)";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Ano.Trim();
            }
            if (Mes.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "month(a.dt_lancto)";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Mes.Trim();
            }
            if (Cd_grupocf.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_caixa_x_ccusto x " +
                                                      "where x.cd_contager = a.cd_contager " +
                                                      "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                      "and x.cd_grupocf = '" + Cd_grupocf.Trim() + " " +
                                                      "and isnull(a.st_estorno, 'N') <> 'S')";
            }
            return new TCD_LanCaixa(banco).Select(filtro, 0, string.Empty);
        }

        public static System.Data.DataTable BuscarRelTransacaoCaixa(string vCd_Empresa,
                                                                    string vCd_contager,
                                                                    string vCd_historico,
                                                                    bool vSt_listarestornos,
                                                                    string vDt_ini,
                                                                    string vDt_fin)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[2];
            filtro[0].vNM_Campo = "a.dt_lancto";
            filtro[0].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_ini).ToString("yyyyMMdd HH:mm")) + "'";
            filtro[0].vOperador = ">=";
            filtro[1].vNM_Campo = "a.dt_lancto";
            filtro[1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_fin).ToString("yyyyMMdd HH:mm")) + "'";
            filtro[1].vOperador = "<=";
            if (!string.IsNullOrEmpty(vCd_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_Empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_contager.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_historico.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!vSt_listarestornos)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_estorno, 'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'N'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().BuscarRelTransacaoCaixa(filtro, "a.cd_contager, a.dt_lancto, a.cd_lanctocaixa");
        }

        public static decimal TotalChequesEmiRec(string vCd_empresa,
                                                    string vCd_contager,
                                                    string vDt_fin,
                                                    string vTp_mov)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vCd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
            }
            if (vCd_contager.Trim() != string.Empty)
            {
                //Buscar conta de compensacao de cheque
                CamadaDados.Financeiro.Cadastros.TList_CadContaGer lConta =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadContaGer.Buscar(vCd_contager,
                                                                              string.Empty,
                                                                              null,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              decimal.Zero,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              null);
                if (lConta.Count > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "c.cd_contager";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + lConta[0].Cd_contager_compensacao.Trim() + "'";
                }
            }
            if ((vDt_fin.Trim() != string.Empty) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.dt_lancto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_fin).ToString("yyyyMMdd")) + " 23:59'";
            }
            if (vTp_mov.Trim().ToUpper().Equals("R"))
                return new TCD_LanCaixa().TotChequeRec(filtro);
            else
                return new TCD_LanCaixa().TotChequePag(filtro);
        }

        public static string AlterarLanCaixa(TRegistro_LanCaixa val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanCaixa cx = new TCD_LanCaixa();
            try
            {
                if (banco == null)
                    st_transacao = cx.CriarBanco_Dados(true);
                else
                    cx.Banco_Dados = banco;
                string retorno = cx.Altera(val);
                if (st_transacao)
                    cx.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cx.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cx.deletarBanco_Dados();
            }
        }

        public static string GravaLanCaixa(TRegistro_LanCaixa val, TObjetoBanco banco)
        {
            TCD_LanCaixa cx = new TCD_LanCaixa();
            bool podecomitar = (banco == null);
            if (banco == null)
                podecomitar = cx.CriarBanco_Dados(true);
            else
                cx.Banco_Dados = banco;

            if (!string.IsNullOrEmpty(val.Cd_ContaGer))
                if (!string.IsNullOrEmpty(val.Cd_Empresa))
                    if (!string.IsNullOrEmpty(val.Cd_Historico))
                        if ((val.Vl_RECEBER - val.Vl_PAGAR) != 0)
                            if (DataCaixa(val.Cd_ContaGer, val.Dt_lancto, cx.Banco_Dados))
                                if (!BloquearCaixaSemSaldo(val, cx.Banco_Dados))
                                    try
                                    {
                                        string ret = cx.Grava(val);
                                        val.Cd_LanctoCaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_CD_LANCTOCAIXA"));
                                        if (val.lCustoLanDel != null)
                                            //Excluir Centro Resultado
                                            val.lCustoLanDel.ForEach(p =>
                                                {
                                                    TCN_Caixa_X_CCusto.Excluir(new TRegistro_Caixa_X_CCusto()
                                                    {
                                                        Cd_contager = val.Cd_ContaGer,
                                                        Cd_lanctocaixa = val.Cd_LanctoCaixa,
                                                        Id_ccustolan = p.Id_ccustolan
                                                    }, cx.Banco_Dados);
                                                    CCustoLan.TCN_LanCCustoLancto.Excluir(p, cx.Banco_Dados);
                                                });
                                        if (val.lCustoLancto != null)
                                            //Gravar Centro Resultado
                                            val.lCustoLancto.ForEach(p =>
                                                {
                                                    p.Cd_empresa = val.Cd_Empresa;
                                                    CCustoLan.TCN_LanCCustoLancto.Gravar(p, cx.Banco_Dados);
                                                    //Gravar Caixa X Centro Resultado
                                                    TCN_Caixa_X_CCusto.Gravar(new TRegistro_Caixa_X_CCusto()
                                                    {
                                                        Cd_contager = val.Cd_ContaGer,
                                                        Cd_lanctocaixa = val.Cd_LanctoCaixa,
                                                        Id_ccustolan = p.Id_ccustolan
                                                    }, cx.Banco_Dados);
                                                });
                                        //Contabilidade
                                        if (!val.Id_adto.HasValue)
                                        {
                                            List<CamadaDados.Contabil.TRegistro_Lan_ProcCaixa> lProcCX =
                                                CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_Caixa(string.Empty,
                                                                                                            val.Cd_ContaGer,
                                                                                                            val.Cd_LanctoCaixa.ToString(),
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            false,
                                                                                                            decimal.Zero,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            decimal.Zero,
                                                                                                            decimal.Zero,
                                                                                                            string.Empty,
                                                                                                            cx.Banco_Dados);
                                            if (lProcCX.Count > 0)
                                                if (lProcCX.Exists(p => p.CD_ContaDeb.HasValue && p.CD_ContaCre.HasValue))
                                                    CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Caixa(lProcCX.FindAll(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue), cx.Banco_Dados);
                                        }
                                        if (podecomitar)
                                            cx.Banco_Dados.Commit_Tran();
                                        return ret;
                                    }
                                    catch (Exception ex)
                                    {
                                        if (podecomitar)
                                            cx.Banco_Dados.RollBack_Tran();
                                        throw new Exception("Erro gravar caixa: " + ex.Message.Trim());
                                    }
                                    finally
                                    {
                                        if (podecomitar)
                                            cx.deletarBanco_Dados();
                                    }
                                else
                                    throw new Exception("Conta Gerencial não tem saldo suficiente para realizar o pagamento.");
                            else
                                throw new Exception("Data de movimentação " + val.Dt_lancto.ToString() + " está FECHADA para lançamentos");
                        else
                            throw new Exception("Valor de lançamento de caixa deve ser MAIOR QUE ZERO !");
                    else
                        throw new Exception("Histórico é obrigatório para lançamento de caixa!");
                else
                    throw new Exception("Empresa é obrigatória para o lançamento de caixa!");
            else
                throw new Exception("Conta é obrigatória para o lançamento de caixa");

            throw new Exception("Lancamento de caixa nao foi efetuado! ");
        }

        public static bool OrigemDescontoBloqueto(TRegistro_LanCaixa val, TObjetoBanco banco)
        {
            object obj = new TCD_LanCaixa(banco).BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_cob_lote_x_caixa x " +
                                    "where x.cd_contager = a.cd_contager " +
                                    "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                    "and a.cd_contager = '" + val.Cd_ContaGer.Trim() + "'" +
                                    "and a.cd_lanctocaixa = " + val.Cd_LanctoCaixa.ToString() + ")"
                    }
                }, "1");
            return obj != null;
        }

        public static bool DataCaixa(string vContaGer, DateTime? vData, TObjetoBanco banco)
        {
            if (vContaGer.Trim().Equals(string.Empty))
            {
                throw new Exception("Conta Gerencial não foi informada! ");
            }
            if (vData == null)
            {
                throw new Exception("Data não foi informada! ");
            }
            //Verificar se a data de lancamento nao e menor que a data do ultimo fechamento
            TList_LanFechamentoCaixa lFechamento = TCN_LanFechamentoCaixa.Buscar(decimal.Zero,
                                                                                 string.Empty,
                                                                                 (vData.HasValue ? vData.Value.ToString() : string.Empty),
                                                                                 string.Empty,
                                                                                 vContaGer,
                                                                                 1,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 banco);
            if (lFechamento.Count > 0)
                throw new Exception("Caixa ja se encontra fechado para a data\r\n" +
                                    "Conta: " + vContaGer.Trim() + "\r\n" +
                                    "Data: " + vData.Value.ToString("dd/MM/yyyy"));
            else
                return true;
        }

        public static bool EstornarSomenteCaixa(TRegistro_LanCaixa val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanCaixa qtb_caixa = new TCD_LanCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                //Verificar se o usuario tem permissao para estornar lancamento de caixa
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ESTORNAR CAIXA OU BANCO", qtb_caixa.Banco_Dados))
                    throw new Exception("Usuario " + Utils.Parametros.pubLogin.Trim() + " não tem permissão para estornar lançamento de caixa.");
                //Verificar se nao se encontra fechado para a data do lançamento de origem
                //O lançamento de estorno sera feito sempre na data do lançamento de origem
                if (DataCaixa(val.Cd_ContaGer, val.Dt_lancto, qtb_caixa.Banco_Dados))
                {
                    //Alterar o ST_Estorno do registro de caixa origem para S - Sim
                    val.St_Estorno = "S";
                    qtb_caixa.Grava(val);
                    //Verificar se o caixa possui rateio centro resultado
                    TCN_Caixa_X_CCusto.BuscarCResultado(val.Cd_ContaGer,
                                                        val.Cd_LanctoCaixa.ToString(),
                                                        qtb_caixa.Banco_Dados).ForEach(p =>
                                                            {
                                                                //Excluir amarracao centro resultado x caixa
                                                                TCN_Caixa_X_CCusto.Excluir(new TRegistro_Caixa_X_CCusto()
                                                                {
                                                                    Cd_contager = val.Cd_ContaGer,
                                                                    Cd_lanctocaixa = val.Cd_LanctoCaixa,
                                                                    Id_ccustolan = p.Id_ccustolan
                                                                }, qtb_caixa.Banco_Dados);
                                                                //Excluir centro resultado
                                                                CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(p, qtb_caixa.Banco_Dados);
                                                            });
                    //Fazer um novo lançamento de caixa com valor contrario ao lançamento de origem
                    //com a data de lançamento igual a data do lançamento de origem
                    //Inverter os valores
                    if (val.Vl_PAGAR > 0)
                    {
                        val.Vl_RECEBER = val.Vl_PAGAR;
                        val.Vl_PAGAR = 0;
                    }
                    else
                    {
                        val.Vl_PAGAR = val.Vl_RECEBER;
                        val.Vl_RECEBER = 0;
                    }
                    //Pegar o cd_lanctocaixa de origem
                    decimal vCd_lanctocaixa_origem = val.Cd_LanctoCaixa;
                    //Zerar cd_lanctocaixa
                    val.Cd_LanctoCaixa = 0;
                    //Chamar o metodo gravar da camada de dados
                    //para gravar somente o lançamento na tabela caixa
                    string retorno = qtb_caixa.Grava(val);
                    //Pegar cd_lanctocaixa do estorno
                    decimal vCd_lanctocaixa_estorno = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_LANCTOCAIXA"));

                    //Gravar a amarração do lançamento de origem com o lançamento de estorno
                    TRegistro_LanEstornoCaixa regEstorno = new TRegistro_LanEstornoCaixa();
                    regEstorno.Cd_contager = val.Cd_ContaGer;
                    regEstorno.Cd_lancto_origem = vCd_lanctocaixa_origem;
                    regEstorno.Cd_lancto_estorno = vCd_lanctocaixa_estorno;
                    TCN_EstornoCaixa.GravarEstornoCaixa(regEstorno, qtb_caixa.Banco_Dados);
                    //Estornar Lancamento Contabil
                    if (val.ID_LoteCTB.HasValue)
                        qtb_caixa.executarSql("exec dbo.EXCLUI_CTB_LANCTOSLOTE @P_ID_LOTECTB = " + val.ID_LoteCTB.Value.ToString(), null);
                    //Recalcular o caixa
                    qtb_caixa.Recalcula(val);

                    if (st_transacao)
                        qtb_caixa.Banco_Dados.Commit_Tran();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static bool EstornarCaixa(TRegistro_LanCaixa val,
                                         ThreadEspera tEspera,
                                         TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanCaixa qtb_caixa = new TCD_LanCaixa();
            try
            {
                if (banco == null)
                {
                    if (tEspera != null)
                        tEspera.Msg("Criando conexão com o banco de dados...");
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                }
                else
                    qtb_caixa.Banco_Dados = banco;

                //Verificar se o usuario tem permissao para estornar lancamento de caixa
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ESTORNAR CAIXA OU BANCO", qtb_caixa.Banco_Dados))
                    throw new Exception("Usuário " + Utils.Parametros.pubLogin.Trim() + " não tem permissão para estornar lançamento de caixa.");

                //Verificar se nao se encontra fechado para a data do lançamento de origem
                //O lançamento de estorno sera feito sempre na data do lançamento de origem
                if (DataCaixa(val.Cd_ContaGer, val.Dt_lancto, qtb_caixa.Banco_Dados))
                {
                    //Verificar se o lancamento de caixa teve origem no caixa operacional
                    if (new CamadaDados.Faturamento.PDV.TCD_Cupom_X_MovCaixa(qtb_caixa.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_contager",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_ContaGer.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_lanctocaixa",
                                vOperador = "=",
                                vVL_Busca = val.Cd_LanctoCaixa.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_pdv_caixa x " +
                                            "where x.id_caixa = a.id_caixa " +
                                            "and isnull(x.st_registro, 'A') in ('D', 'P'))"
                            }
                        }, "1") != null)
                        throw new Exception("Não é permitido estornar lançamento de caixa de um caixa operacional AUDITADO ou PROCESSADO.");
                    //Verificar se o lancamento de caixa teve origem na devolucao de creditos caixa operacional
                    object obj = new CamadaDados.Faturamento.PDV.TCD_Cupom_X_DevCredito(qtb_caixa.Banco_Dados).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_contager",
                                                vOperador = "=",
                                                vVL_Busca = "'" + val.Cd_ContaGer.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = string.Empty,
                                                vVL_Busca = "(a.cd_lanctocaixa = " + val.Cd_LanctoCaixa.ToString() + ") or " +
                                                            "(a.cd_lanctocaixa_dev = " + val.Cd_LanctoCaixa.ToString() + ")"
                                            }
                                        }, "a.id_cupom");
                    if (obj != null)
                        throw new Exception("Caixa teve origem na devolução de créditos no módulo frente de caixa.\r\n" +
                                            "Para cancelar lançamento de caixa, deve-se cancelar o recebimento da venda rapida Nº" + obj.ToString());
                    //Verificar se o caixa teve origem em emprestimos
                    obj = new CamadaDados.Financeiro.Emprestimos.TCD_Emprestimos(qtb_caixa.Banco_Dados).BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Caption = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fin_emprestimo_x_caixa x " +
                                                        "where x.id_emprestimo = a.id_emprestimo " +
                                                        "and x.cd_empresa = a.cd_empresa " +
                                                        "and x.cd_contager = '" + val.Cd_ContaGer.Trim() + "' " +
                                                        "and x.cd_lanctocaixa = " + val.Cd_LanctoCaixa.ToString() + " " +
                                                        "and x.tp_lancto = 'O')"
                                        }
                                    }, "a.id_emprestimo");
                    if (obj != null)
                        throw new Exception("Caixa teve origem no controle de empréstimos.\r\n" +
                                            "Para cancelar lançamento de caixa, deve-se cancelar o empréstimo Nº" + obj.ToString());
                    //Verificar se o lancamento de caixa e um lancamento de quitacao de adiantamento
                    obj = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento(qtb_caixa.Banco_Dados).BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                        "inner join tb_fin_caixa y " +
                                                        "on x.cd_contager = y.cd_contager " +
                                                        "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                        "where x.id_adto = a.id_adto " +
                                                        "and isnull(a.st_adto, 'A') <> 'C' " +
                                                        "and isnull(y.st_estorno, 'N') <> 'S' " +
                                                        "and case when a.tp_movimento = 'C' then y.vl_pagar else y.vl_receber end > 0 " +
                                                        "and y.CD_ContaGer = '" + val.Cd_ContaGer.Trim() + "' " +
                                                        "and y.cd_lanctocaixa = " + val.Cd_LanctoCaixa.ToString() + ")"
                                        }
                                    }, "a.id_adto");
                    if (obj != null)
                    {
                        //Verificar se o adiantamento possui devolucao
                        obj = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento(qtb_caixa.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                    "inner join tb_fin_caixa y " +
                                                    "on x.cd_contager = y.cd_contager " +
                                                    "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                    "where x.id_adto = a.id_adto " +
                                                    "and isnull(a.st_adto, 'A') <> 'C' " +
                                                    "and isnull(y.st_estorno, 'N') <> 'S' " +
                                                    "and case when a.tp_movimento = 'C' then y.vl_receber else y.vl_pagar end > 0 " +
                                                    "and a.id_adto = " + obj.ToString() + ")"
                                    }
                                }, "1");
                        if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                            throw new Exception("Lançamento de caixa teve origem na quitação de adiantamento que possui devolução.\r\n" +
                                                "para cancelar o mesmo e necessário antes cancelar os lançamentos de devolução.");
                    }
                    //Verificar se o lancamento de caixa teve origem agrupamento duplicata
                    if (new CamadaDados.Financeiro.Duplicata.TCD_VincularDup(qtb_caixa.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fin_vincularDup x " +
                                            "inner join tb_fin_duplicata y " +
                                            "on x.cd_empresa = y.cd_empresa " +
                                            "and x.nr_lancto = y.nr_lancto " +
                                            "where x.cd_contager = '" + val.Cd_ContaGer.Trim() + "' " +
                                            "and x.cd_lanctocaixa = " + val.Cd_LanctoCaixa.ToString() + " " +
                                            "and isnull(y.st_registro, 'A') <> 'C')"
                            }
                        }, "1") != null)
                        throw new Exception("Lançamento caixa teve origem vincular duplicata.\r\n" +
                                            "Para cancelar o lançamento é necessário cancelar a duplicata de vinculação.");
                    //Verificar se o lancamento de caixa esta amarrado a um cheque compensado
                    obj = new TCD_LanTitulo(qtb_caixa.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isNull(a.status_compensado, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.cd_banco = a.cd_banco " +
                                                "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                "and x.cd_contager = '" + val.Cd_ContaGer.Trim() + "' " +
                                                "and x.cd_lanctocaixa = " + val.Cd_LanctoCaixa.ToString() + ")"
                                }
                            }, "a.nr_cheque");
                    if (obj != null)
                        throw new Exception("Lançamento caixa esta amarrado a um cheque COMPENSADO.\r\n" +
                                            "Localize o cheque Nº" + obj.ToString().Trim() + ", e estorne a compensação, ou cancele o mesmo.");
                    //Verificar se o lancamento de caixa esta amarrado ao Processamento Caixa Operacional
                    if (new CamadaDados.Faturamento.PDV.TCD_FechamentoCaixa(qtb_caixa.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FIN_TransfCaixa x " +
                                            "where x.id_transf = a.id_transf " +
                                            "and ((x.cd_conta_ent = '" + val.Cd_ContaGer.Trim() + "' " +
                                            "       and x.cd_lanctocaixa_ent = " + val.Cd_LanctoCaixa.ToString() + ") " +
                                            "   or(x.cd_conta_sai = '" + val.Cd_ContaGer.Trim() + "' " +
                                            "       and x.cd_lanctocaixa_sai = " + val.Cd_LanctoCaixa.ToString() + ")))"
                            }
                        }, "1") != null)
                        throw new Exception("Não é permitido excluir lançamento de caixa que teve origem processamento de CAIXA OPERACIONAL.");
                    if (tEspera != null)
                        tEspera.Msg("Estornando lançamento de caixa origem...");
                    //Alterar o ST_Estorno do registro de caixa origem para S - Sim
                    val.St_Estorno = "S";
                    qtb_caixa.Grava(val);
                    //Verificar se o lancamento de caixa nao e um lancamento de transf de origem
                    TList_Lan_Transfere_Caixa lTransf = TCN_Lan_Transfere_Caixa.Buscar(decimal.Zero,
                                                                                       val.Cd_ContaGer,
                                                                                       val.Cd_LanctoCaixa,
                                                                                       string.Empty,
                                                                                       0,
                                                                                       1,
                                                                                       string.Empty,
                                                                                       qtb_caixa.Banco_Dados);
                    if (lTransf.Count > 0)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Estornar lançamento de transferencia de caixa...");
                        TList_LanCaixa lCaixaTransf = TCN_LanCaixa.Busca(lTransf[0].CD_ContaGer_Saida,
                                                                         lTransf[0].CD_LANCTOCAIXA_SAI.ToString(),
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         decimal.Zero,
                                                                         decimal.Zero,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         "N",
                                                                         false,
                                                                         string.Empty,
                                                                         decimal.Zero,
                                                                         false,
                                                                         qtb_caixa.Banco_Dados);
                        if (lCaixaTransf.Count > 0)
                            //Chamar a funcao estornar caixa de forma recursiva
                            //Para estornar a outra perna da transferencia
                            EstornarCaixa(lCaixaTransf[0], tEspera, qtb_caixa.Banco_Dados);
                    }
                    //Verificar se o lancamento de caixa nao e um lancamento de transf de destino
                    lTransf = TCN_Lan_Transfere_Caixa.Buscar(decimal.Zero,
                                                             string.Empty,
                                                             decimal.Zero,
                                                             val.Cd_ContaGer,
                                                             val.Cd_LanctoCaixa,
                                                             1,
                                                             string.Empty,
                                                             qtb_caixa.Banco_Dados);
                    if (lTransf.Count > 0)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Estornar lançamento de transferencia de caixa...");
                        TList_LanCaixa lCaixaTransf = TCN_LanCaixa.Busca(lTransf[0].CD_ContaGer_Entrada,
                                                                         lTransf[0].CD_LANCTOCAIXA_ENT.ToString(),
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         decimal.Zero,
                                                                         decimal.Zero,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         "N",
                                                                         false,
                                                                         string.Empty,
                                                                         decimal.Zero,
                                                                         false,
                                                                         qtb_caixa.Banco_Dados);
                        if (lCaixaTransf.Count > 0)
                            //Chamar a funcao estornar caixa de forma recursiva
                            //Para estornar a outra perna da transferencia
                            EstornarCaixa(lCaixaTransf[0], tEspera, qtb_caixa.Banco_Dados);
                    }
                    //Verificar se o lançamento de caixa e um credito de cheque
                    TList_RegLanTituloXCaixa lChequeCaixa = new TCD_TituloXCaixa(qtb_caixa.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_contager",
                                vOperador = "=",
                                vVL_Busca = "'"+val.Cd_ContaGer.Trim()+"'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_lanctocaixa",
                                vOperador = "=",
                                vVL_Busca = val.Cd_LanctoCaixa.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.tp_lancto, '')",
                                vOperador = "=",
                                vVL_Busca = "'GC'"
                            }
                        }, 0, string.Empty);
                    if (lChequeCaixa.Count > 0)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Excluir credito cheque...");
                        TCN_TituloXCaixa.DeletarTituloCaixa(lChequeCaixa[0], qtb_caixa.Banco_Dados);
                    }
                    else
                    {
                        //Verificar se o lançamento de origem movimenta titulo com status_compensado <> C
                        TList_RegLanTitulo lTitulos = TCN_TituloXCaixa.Buscar(val.Cd_ContaGer,
                                                                              val.Cd_LanctoCaixa,
                                                                              "C",
                                                                              "<>",
                                                                              0,
                                                                              string.Empty,
                                                                              qtb_caixa.Banco_Dados);
                        if ((lTitulos.Count > 0) && (tEspera != null))
                            tEspera.Msg("Cancelar cheques...");
                        for (int i = 0; i < lTitulos.Count; i++)
                            TCN_LanTitulo.CancelarTitulo(lTitulos[i], qtb_caixa.Banco_Dados);
                    }
                    //Listar todas as liquidações amarradas ao lançamento de caixa origem
                    //com cd_lanctocaixa ou cd_lanctocaixa_juro ou cd_lanctocaixa_desc
                    //igual ao cd_lanctocaixa de origem
                    TList_RegLanLiquidacao lLiq = TCN_LanLiquidacao.Busca(string.Empty,
                                                                          decimal.Zero,
                                                                          decimal.Zero,
                                                                          decimal.Zero,
                                                                          val.Cd_ContaGer,
                                                                          val.Cd_LanctoCaixa,
                                                                          val.Cd_LanctoCaixa,
                                                                          val.Cd_LanctoCaixa,
                                                                          val.Cd_LanctoCaixa,
                                                                          val.Cd_LanctoCaixa,
                                                                          val.Cd_LanctoCaixa,
                                                                          val.Cd_LanctoCaixa,
                                                                          true,
                                                                          "A",
                                                                          0,
                                                                          string.Empty,
                                                                          qtb_caixa.Banco_Dados);
                    if ((lLiq.Count > 0) && (tEspera != null))
                        tEspera.Msg("Estornando liquidação...");
                    lLiq.ForEach(p =>
                        //Para cada liquidação chamar o procedimento CancelarLiquidacao
                        TCN_LanLiquidacao.CancelarLiquidacao(p, null, qtb_caixa.Banco_Dados));

                    //Verificar se o lancamento de caixa esta amarrado a devolucao de adiantamento
                    //e se existe liquidacao em aberto para este lancamento de caixa
                    TList_RegLanLiquidacao lLiqDev = TCN_Liquidacao_X_Adto_Caixa.BuscarLiquidDev(val.Cd_ContaGer, val.Cd_LanctoCaixa, qtb_caixa.Banco_Dados);
                    if ((lLiqDev.Count > 0) && (tEspera != null))
                        tEspera.Msg("Estornando devolução de adiantamento...");
                    for (int i = 0; i < lLiqDev.Count; i++)
                        //Para cada liquidacao chamar o procedimento CancelarLiquidacao
                        TCN_LanLiquidacao.CancelarLiquidacao(lLiqDev[i], null, qtb_caixa.Banco_Dados);
                    //Verificar se o lancamento de caixa esta amarrado a carta frete
                    TList_LiquidCartaFrete lCF = TCN_LiquidCartaFrete.Buscar(string.Empty,
                                                                             string.Empty,
                                                                             val.Cd_ContaGer,
                                                                             val.Cd_LanctoCaixa.ToString(),
                                                                             qtb_caixa.Banco_Dados);
                    if ((lCF.Count > 0) && (tEspera != null))
                        tEspera.Msg("Estornando carta frete...");
                    lCF.ForEach(p => TCN_LiquidCartaFrete.Excluir(p, qtb_caixa.Banco_Dados));
                    //Verificar se o lancamento de caixa esta amarrado ao cheque troco
                    TList_TrocoCH lChTroco = TCN_TrocoCH.Buscar(string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                val.Cd_ContaGer,
                                                                val.Cd_LanctoCaixa.ToString(),
                                                                qtb_caixa.Banco_Dados);
                    if ((lChTroco.Count > 0) && (tEspera != null))
                        tEspera.Msg("Estornando cheques trocos...");
                    lChTroco.ForEach(p =>
                        {
                            TCN_TrocoCH.Excluir(p, qtb_caixa.Banco_Dados);
                            TCN_LanTitulo.EstornarCompensacaoTitulo(
                                TCN_LanTitulo.Busca(p.Cd_empresa,
                                                    p.Nr_lanctocheque.Value,
                                                    p.Cd_banco,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    decimal.Zero,
                                                    decimal.Zero,
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
                                                    false,
                                                    false,
                                                    false,
                                                    false,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    1,
                                                    string.Empty,
                                                    qtb_caixa.Banco_Dados)[0], qtb_caixa.Banco_Dados);
                        });
                    //Verificar se o lancamento de caixa esta amarrado ao repasse de cheque
                    TList_RegLanTitulo lChequesRep = TCN_Rastreab_ChTerceiro.BuscarCheques(val.Cd_ContaGer,
                                                                                           val.Cd_LanctoCaixa.ToString(),
                                                                                           qtb_caixa.Banco_Dados);
                    if ((lChequesRep.Count > 0) && (tEspera != null))
                        tEspera.Msg("Estornando cheques repassados...");
                    lChequesRep.ForEach(p =>
                        {
                            //Para cada cheque, estornar compensacao
                            TCN_LanTitulo.EstornarCompensacaoTitulo(p, qtb_caixa.Banco_Dados);
                            //Buscar registro Titulo Repassado
                            TList_Rastreab_ChTerceiro lRepasse = TCN_Rastreab_ChTerceiro.Buscar(p.Cd_empresa,
                                                                                                p.Cd_banco,
                                                                                                p.Nr_lanctocheque.ToString(),
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                0,
                                                                                                string.Empty,
                                                                                                qtb_caixa.Banco_Dados);
                            if (lRepasse.Count > 0)
                                TCN_Rastreab_ChTerceiro.DeletarRastreab_ChTerceiro(lRepasse[0], qtb_caixa.Banco_Dados);
                        });
                    //Verificar se o lancamento de caixa esta amarrado a fatura cartao
                    CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFatura =
                        new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao(qtb_caixa.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fin_faturacartao_x_caixa x " +
                                            "where x.id_fatura = a.id_fatura " +
                                            "and x.cd_contager = '" + val.Cd_ContaGer.Trim() + "' " +
                                            "and x.cd_lanctocaixa = " + val.Cd_LanctoCaixa.ToString() + ")"
                            }
                        }, 0, string.Empty, string.Empty);
                    if (lFatura.Count > 0)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Estornando fatura cartão...");
                        lFatura.ForEach(p => CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.CancelarFatura(p, qtb_caixa.Banco_Dados));
                    }
                    //Verificar se o lancamento de caixa esta amarrado a uma quitacao de fatura de cartao
                    CamadaDados.Financeiro.Cartao.TList_Quitarfatura lQuitar =
                        new CamadaDados.Financeiro.Cartao.TCD_QuitarFatura(qtb_caixa.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "((a.cd_contager = '" + val.Cd_ContaGer.Trim() + "' " +
                                            "and a.cd_lanctocaixa = " + val.Cd_LanctoCaixa.ToString() + ") or " +
                                            "(a.cd_contagerquit = '" + val.Cd_ContaGer.Trim() + "' " +
                                            "and (a.cd_lanctocaixaquit = " + val.Cd_LanctoCaixa.ToString() + " or " +
                                            "       a.cd_lanctocaixajuro = " + val.Cd_LanctoCaixa.ToString() + " or " +
                                            "       a.cd_lanctocaixaTX = " + val.Cd_LanctoCaixa.ToString() + ")))"
                            }
                        }, 0, string.Empty);
                    if (lQuitar.Count > 0)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Estornando quitação fatura cartão...");
                        lQuitar.ForEach(p => CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.EstornarQuitacaoFatura(p, qtb_caixa.Banco_Dados));
                    }
                    //Verificar se lancamento de caixa possui centro resultado
                    TCN_Caixa_X_CCusto.BuscarCResultado(val.Cd_ContaGer,
                                                        val.Cd_LanctoCaixa.ToString(),
                                                        qtb_caixa.Banco_Dados).ForEach(p =>
                                                        {
                                                            //Estornar amarracao
                                                            TCN_Caixa_X_CCusto.Excluir(new TRegistro_Caixa_X_CCusto()
                                                            {
                                                                Cd_contager = val.Cd_ContaGer,
                                                                Cd_lanctocaixa = val.Cd_LanctoCaixa,
                                                                Id_ccustolan = p.Id_ccustolan
                                                            }, qtb_caixa.Banco_Dados);
                                                            //Estornar rateio
                                                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(p, qtb_caixa.Banco_Dados);
                                                        });
                    if (val.ID_LoteCTB.HasValue)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Estornando lançamento contabil...");
                        qtb_caixa.executarSql("exec dbo.EXCLUI_CTB_LANCTOSLOTE @P_ID_LOTECTB = " + val.ID_LoteCTB.Value.ToString(), null);
                    }
                    if (tEspera != null)
                        tEspera.Msg("Gravando lançamento de estorno de caixa...");
                    //Fazer um novo lançamento de caixa com valor contrario ao lançamento de origem
                    //com a data de lançamento igual a data do lançamento de origem
                    //Inverter os valores
                    if (val.Vl_PAGAR > 0)
                    {
                        val.Vl_RECEBER = val.Vl_PAGAR;
                        val.Vl_PAGAR = 0;
                    }
                    else
                    {
                        val.Vl_PAGAR = val.Vl_RECEBER;
                        val.Vl_RECEBER = 0;
                    }
                    //Pegar o cd_lanctocaixa de origem
                    decimal vCd_lanctocaixa_origem = val.Cd_LanctoCaixa;
                    //Zerar cd_lanctocaixa
                    val.Cd_LanctoCaixa = 0;
                    //Chamar o metodo gravar da camada de dados
                    //para gravar somente o lançamento na tabela caixa
                    string retorno = qtb_caixa.Grava(val);
                    //Pegar cd_lanctocaixa do estorno
                    decimal vCd_lanctocaixa_estorno = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_LANCTOCAIXA"));

                    //Gravar a amarração do lançamento de origem com o lançamento de estorno
                    TRegistro_LanEstornoCaixa regEstorno = new TRegistro_LanEstornoCaixa();
                    regEstorno.Cd_contager = val.Cd_ContaGer;
                    regEstorno.Cd_lancto_origem = vCd_lanctocaixa_origem;
                    regEstorno.Cd_lancto_estorno = vCd_lanctocaixa_estorno;
                    TCN_EstornoCaixa.GravarEstornoCaixa(regEstorno, qtb_caixa.Banco_Dados);
                    if (tEspera != null)
                        tEspera.Msg("Recalcular o caixa...");
                    //Recalcular o caixa
                    qtb_caixa.Recalcula(val);

                    if (st_transacao)
                        qtb_caixa.Banco_Dados.Commit_Tran();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static string AuditarCaixa(TList_LanCaixa val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanDuplicata qtb_duplicata = new TCD_LanDuplicata();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_duplicata.CriarBanco_Dados(true);
                else
                    qtb_duplicata.Banco_Dados = banco;

                val.ForEach(r =>
                {
                    qtb_duplicata.executarEscalar(" update tb_fin_caixa " +
                        "set DT_AuditAvulso = '" + CamadaDados.UtilData.Data_Servidor() + "' " +
                        "where CD_ContaGer = " + r.Cd_ContaGer + " " +
                        "and CD_LanctoCaixa = " + r.Cd_LanctoCaixa + " " +

                        "update tb_fin_caixa " +
                        "set ST_Avulso = 1 " +
                        "where CD_ContaGer = " + r.Cd_ContaGer + " " +
                        "and CD_LanctoCaixa = " + r.Cd_LanctoCaixa + " " +

                        "update tb_fin_caixa " +
                        "set LoginAuditAvulso = '" + Parametros.pubLogin + "' " +
                        "where CD_ContaGer = " + r.Cd_ContaGer + " " +
                        "and CD_LanctoCaixa = " + r.Cd_LanctoCaixa + " ", null);
                });

                if (pode_liberar)
                    qtb_duplicata.Banco_Dados.Commit_Tran();
                return "";
            }
            catch (Exception ex)
            {
                if (pode_liberar)
                    qtb_duplicata.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao auditar duplicata: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_duplicata.deletarBanco_Dados();
            }
        }

        #endregion

        #region Estorno Caixa
        public class TCN_EstornoCaixa
        {
            public static string GravarEstornoCaixa(TRegistro_LanEstornoCaixa val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_EstornoCaixa qtb_estorno = new TCD_EstornoCaixa();
                try
                {
                    if (banco == null)
                    {
                        qtb_estorno.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_estorno.Banco_Dados = banco;
                    //Login do estorno
                    val.Login = Utils.Parametros.pubLogin;
                    string retorno = qtb_estorno.GravarEstornoCaixa(val);
                    if (st_transacao)
                        qtb_estorno.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_estorno.Banco_Dados.RollBack_Tran();
                    else
                        throw new Exception(ex.Message);
                    return "";
                }
                finally
                {
                    if (st_transacao)
                        qtb_estorno.deletarBanco_Dados();
                }
            }
        }
        #endregion
    }

    #region Caixa X Centro Resultado
    public class TCN_Caixa_X_CCusto
    {
        public static TList_Caixa_X_Ccusto Buscar(string Cd_contager,
                                                  string Cd_lanctocaixa,
                                                  string Id_ccustolan,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_lanctocaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa;
            }
            if (!string.IsNullOrEmpty(Id_ccustolan))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ccustolan";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ccustolan;
            }

            return new TCD_Caixa_X_CCusto(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto BuscarCResultado(string Cd_contager,
                                                                                              string Cd_lanctocaixa,
                                                                                              BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.CCustoLan.TCD_LanCCustoLancto(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_caixa_x_ccusto x " +
                                    "where x.id_ccustolan = a.id_ccustolan " +
                                    "and x.cd_contager = '" + Cd_contager.Trim() + "' " +
                                    "and x.cd_lanctocaixa = " + Cd_lanctocaixa + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Caixa_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Caixa_X_CCusto qtb_caixa = new TCD_Caixa_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                string retorno = qtb_caixa.Gravar(val);
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar centro resultado caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Caixa_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Caixa_X_CCusto qtb_caixa = new TCD_Caixa_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                qtb_caixa.Excluir(val);
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir centro resultado caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static void ProcessarCaixaCResultado(List<TRegistro_LanCaixa> lCaixa,
                                                    string Cd_cresultado,
                                                    TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Caixa_X_CCusto qtb_dup = new TCD_Caixa_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dup.CriarBanco_Dados(true);
                else
                    qtb_dup.Banco_Dados = banco;
                lCaixa.ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(Cd_cresultado))
                    {
                            //Gravar Lancto Resultado
                            string id = CCustoLan.TCN_LanCCustoLancto.Gravar(
                                new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                {
                                    Cd_empresa = p.Cd_Empresa,
                                    Cd_centroresult = Cd_cresultado,
                                    Vl_lancto = p.Vl_PAGAR > decimal.Zero ? p.Vl_PAGAR : p.Vl_RECEBER,
                                    Dt_lancto = p.Dt_lancto
                                }, qtb_dup.Banco_Dados);
                            //Amarrar Lancto a Caixa
                            Gravar(new TRegistro_Caixa_X_CCusto()
                        {
                            Cd_contager = p.Cd_ContaGer,
                            Cd_lanctocaixa = p.Cd_LanctoCaixa,
                            Id_ccustolan = decimal.Parse(id)
                        }, qtb_dup.Banco_Dados);
                    }
                });
                if (st_transacao)
                    qtb_dup.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dup.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar caixa x centro resultado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }
    }
    #endregion

}
