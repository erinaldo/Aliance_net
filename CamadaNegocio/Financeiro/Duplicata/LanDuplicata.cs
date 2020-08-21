using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Financeiro.Caixa;
using CamadaDados.Financeiro.Titulo;
using CamadaNegocio.Financeiro.Titulo;
using CamadaNegocio.Financeiro.Caixa;
using CamadaDados.Financeiro.Adiantamento;
using CamadaNegocio.Financeiro.Adiantamento;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaNegocio.ConfigGer;

namespace CamadaNegocio.Financeiro.Duplicata
{
    public class TCN_LanDuplicata
    {
        public static void validaFeriado(bool vST_VenctoFeriado, ref DateTime vDT_VenctoFeriado)
        {
            if (vST_VenctoFeriado)
                return;
            else
            {
                if (vDT_VenctoFeriado.DayOfWeek == DayOfWeek.Saturday)
                {
                    vDT_VenctoFeriado = vDT_VenctoFeriado.AddDays(2);
                    validaFeriado(vST_VenctoFeriado, ref vDT_VenctoFeriado);
                }
                if (vDT_VenctoFeriado.DayOfWeek == DayOfWeek.Sunday)
                {
                    vDT_VenctoFeriado = vDT_VenctoFeriado.AddDays(1);
                    validaFeriado(vST_VenctoFeriado, ref vDT_VenctoFeriado);
                }
                //Buscar Feriado no Banco
                CamadaDados.Diversos.TList_CadFeriado lFeriado =
                    new CamadaDados.Diversos.TCD_CadFeriado().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "day(a.dt_feriado)",
                            vOperador = "=",
                            vVL_Busca = vDT_VenctoFeriado.Day.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "month(a.dt_feriado)",
                            vOperador = "=",
                            vVL_Busca = vDT_VenctoFeriado.Month.ToString()
                        }
                    }, 1, string.Empty);
                if (lFeriado.Count > 0)
                {
                    if ((lFeriado[0].Dt_Feriado.Value.Year == vDT_VenctoFeriado.Year) || ((lFeriado[0].St_RepeteAnual)) && (lFeriado[0].Dt_Feriado.Value.Year < vDT_VenctoFeriado.Year))
                    {
                        vDT_VenctoFeriado = vDT_VenctoFeriado.AddDays(1);
                        validaFeriado(vST_VenctoFeriado, ref vDT_VenctoFeriado);
                    }
                }
            }
        }

        private static decimal somaParcelas(TRegistro_LanDuplicata val, bool St_valorPadrao)
        {
            decimal retorno = 0;
            for (int i = 0; i < val.Parcelas.Count; i++)
                if (St_valorPadrao)
                    retorno += Convert.ToDecimal(string.Format("{0:F2}", val.Parcelas[i].Vl_parcela_padrao));
                else
                    retorno += Convert.ToDecimal(string.Format("{0:F2}", val.Parcelas[i].Vl_parcela));

            return retorno;
        }

        private static decimal somaParcelasAnteriores(TRegistro_LanDuplicata val, int index, bool St_valorPadrao)
        {
            decimal retorno = 0;
            for (int i = 0; i < index; i++)
                if (St_valorPadrao)
                    retorno += Convert.ToDecimal(string.Format("{0:F2}", val.Parcelas[i].Vl_parcela_padrao));
                else
                    retorno += Convert.ToDecimal(string.Format("{0:F2}", val.Parcelas[i].Vl_parcela));
            return retorno;
        }

        private static void recalcParcelas(TRegistro_LanDuplicata val, bool St_valorPadrao)
        {
            decimal somaParcela = somaParcelas(val, St_valorPadrao);
            if (St_valorPadrao)
            {
                if (somaParcela != (val.Vl_documento_padrao - val.Vl_entrada_padrao))
                {
                    val.Parcelas[val.Parcelas.Count - 1].St_CalcVl_Parcela = false;
                    val.Parcelas[val.Parcelas.Count - 1].Vl_parcela_padrao += (val.Vl_documento_padrao - somaParcela);
                    val.Parcelas[val.Parcelas.Count - 1].Vl_atual = val.Parcelas[val.Parcelas.Count - 1].Vl_parcela_padrao;
                    val.Parcelas[val.Parcelas.Count - 1].cVl_atual = val.Parcelas[val.Parcelas.Count - 1].Vl_parcela;
                }
            }
            else
                if (somaParcela != (val.Vl_documento - val.Vl_entrada))
            {
                val.Parcelas[val.Parcelas.Count - 1].Vl_parcela += (val.Vl_documento - somaParcela);
                val.Parcelas[val.Parcelas.Count - 1].Vl_atual = val.Parcelas[val.Parcelas.Count - 1].Vl_parcela_padrao;
                val.Parcelas[val.Parcelas.Count - 1].cVl_atual = val.Parcelas[val.Parcelas.Count - 1].Vl_parcela;
            }
        }

        private static void reajustaValorParcela(TRegistro_LanDuplicata val, int index, bool St_valorPadrao)
        {
            decimal somaParcAnteriores = somaParcelasAnteriores(val, index, St_valorPadrao);
            if (St_valorPadrao)
            {
                if ((somaParcAnteriores + val.Parcelas[index].Vl_parcela_padrao) > (val.Vl_documento_padrao - (val.Parcelas.Count - index - 1)))
                {
                    val.Parcelas[index].Vl_parcela_padrao = (val.Vl_documento_padrao - (val.Parcelas.Count - index - 1) - somaParcAnteriores);
                    val.Parcelas[index].Vl_atual = val.Parcelas[index].Vl_parcela_padrao;
                    val.Parcelas[index].cVl_atual = val.Parcelas[index].Vl_parcela;
                }
            }
            else
                if ((somaParcAnteriores + val.Parcelas[index].Vl_parcela) > (val.Vl_documento - (val.Parcelas.Count - index - 1)))
            {
                val.Parcelas[index].Vl_parcela = (val.Vl_documento - (val.Parcelas.Count - index - 1) - somaParcAnteriores);
                val.Parcelas[index].Vl_atual = val.Parcelas[index].Vl_parcela_padrao;
                val.Parcelas[index].cVl_atual = val.Parcelas[index].Vl_parcela;
            }
        }

        private static void recalcDataVencimento(TRegistro_LanDuplicata val, int index)
        {
            DateTime dt_vencto = val.Parcelas[index].Dt_vencto.Value;
            validaFeriado(val.St_venctoferiado.Trim().Equals("S"), ref dt_vencto);
            val.Parcelas[index].Dt_vencto = dt_vencto;
            //if(val.Parcelas[index].Dt_vencto.Value.Date >= val.Parcelas[index + 1].Dt_vencto.Value.Date)
            for (int i = (index + 1); i < val.Parcelas.Count; i++)
            {
                DateTime dt_feriado = val.Parcelas[i - 1].Dt_vencto.Value.AddDays(Convert.ToDouble(val.Qt_dias_desdobro));
                validaFeriado(val.St_venctoferiado.Trim().Equals("S"), ref dt_feriado);
                val.Parcelas[i].Dt_vencto = dt_feriado;
            }
        }

        public static TList_RegLanDuplicata Busca(string vCD_Empresa,
                                                  string vNR_Lancto,
                                                  string vCD_Historico,
                                                  string vCD_Clifor,
                                                  string vCD_CondPgto,
                                                  string vNR_Docto,
                                                  string vVl_Documento,
                                                  string vDT_Emissao,
                                                  bool vSt_parcelasemaberto,
                                                  string vCd_moeda,
                                                  string vTp_movimento,
                                                  string parcelas,
                                                  string vSt_registro,
                                                  string vDt_ini,
                                                  string vDt_fin,
                                                  bool vSt_tp_duplicata,
                                                  int vTop,
                                                  string vNM_Campo,
                                                  TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(vNR_Lancto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Lancto";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Lancto;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Historico))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Historico";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Historico + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Clifor + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_CondPgto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CondPgto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_CondPgto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNR_Docto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Docto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNR_Docto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vVl_Documento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Vl_Documento";
                vBusca[vBusca.Length - 1].vVL_Busca = vVl_Documento;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!(vDT_Emissao.Trim().Equals("/  /")) && (vDT_Emissao != ""))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Emissao)))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Emissao).ToString("yyyyMMdd") + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vSt_parcelasemaberto)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "";
                vBusca[vBusca.Length - 1].vVL_Busca = "(Select 1 From TB_FIN_Parcela x " +
                                                      "Where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and x.st_registro in ('A', 'P'))";
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
            }
            if (!string.IsNullOrEmpty(vCd_moeda))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Moeda";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_moeda + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTp_movimento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "g.TP_Mov";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_movimento + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(parcelas))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and(" + parcelas + "))";
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
            }
            if (!string.IsNullOrEmpty(vSt_registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isNull(a.ST_Registro, 'A')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vSt_registro.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
            }
            if (vSt_tp_duplicata)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_DIV_Usuario_X_TpDuplicata x " +
                                                       "where x.tp_duplicata = a.tp_duplicata " +
                                                       "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                       "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                       "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            return new TCD_LanDuplicata(banco).Select(vBusca, vTop, vNM_Campo);
        }

        public static TList_RegLanDuplicata BuscaAudit(string vCD_Empresa,
                                                      string vNR_Docto,
                                                      string vNR_Lancto,
                                                      string vCD_Clifor,
                                                      string vCd_moeda,
                                                      string vCD_Historico,
                                                      string vCD_CondPgto,
                                                      string vTp_Duplicata,
                                                      decimal vVl_DocumentoIni,
                                                      decimal vVl_DocumentoFin,
                                                      string vDT_EmissaoIni,
                                                      string vDT_EmissaoFin,
                                                      TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(vNR_Lancto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Lancto";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Lancto;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Historico))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Historico";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Historico + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Clifor + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_CondPgto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CondPgto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_CondPgto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNR_Docto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Docto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNR_Docto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vVl_DocumentoIni > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Vl_Documento";
                vBusca[vBusca.Length - 1].vVL_Busca = vVl_DocumentoIni.ToString();
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if (vVl_DocumentoFin > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Vl_Documento";
                vBusca[vBusca.Length - 1].vVL_Busca = vVl_DocumentoFin.ToString();
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }

            //Data emissao
            if (!(vDT_EmissaoIni.Trim().Equals("/  /")) && (vDT_EmissaoIni != ""))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Emissao)))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_EmissaoIni).ToString("yyyyMMdd") + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if (!(vDT_EmissaoFin.Trim().Equals("/  /")) && (vDT_EmissaoFin != ""))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Emissao)))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_EmissaoFin).ToString("yyyyMMdd") + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(vCd_moeda))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Moeda";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_moeda + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTp_Duplicata))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_duplicata";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_Duplicata + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            Estruturas.CriarParametro(ref vBusca, "isnull(a.ST_Registro, 'A')", "'C'", "<>");
            Estruturas.CriarParametro(ref vBusca, "isnull(a.st_avulso, 0)", "0", "<>");
            Estruturas.CriarParametro(ref vBusca, "a.dt_auditavulso", "null", "is");

            return new TCD_LanDuplicata(banco).Select(vBusca, 0, string.Empty);
        }

        public static string AuditarDuplicatas(TList_RegLanDuplicata _LanDuplicatas, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanDuplicata qtb_duplicata = new TCD_LanDuplicata();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_duplicata.CriarBanco_Dados(true);
                else
                    qtb_duplicata.Banco_Dados = banco;

                _LanDuplicatas.ForEach(r => 
                {
                    qtb_duplicata.executarEscalar(" update tb_fin_duplicata " +
                        "set DT_AuditAvulso = '" + CamadaDados.UtilData.Data_Servidor() + "' " +
                        "where nr_lancto = " + r.Nr_lancto + " " +

                        "update tb_fin_duplicata " +
                        "set ST_Avulso = 1 " +
                        "where nr_lancto = " + r.Nr_lancto + " " +
                        
                        "update tb_fin_duplicata " +
                        "set LoginAuditAvulso = '" + Parametros.pubLogin + "' " +
                        "where nr_lancto = " + r.Nr_lancto + " ", null);
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

        public static TList_RegLanDuplicata BuscarFinRatearCResultado(string Cd_empresa,
                                                                      string Cd_historico,
                                                                      string Cd_clifor,
                                                                      string Cd_moeda,
                                                                      string Cd_centroresult,
                                                                      string Id_locacao,
                                                                      string Tp_movimento,
                                                                      string Dt_ini,
                                                                      string Dt_fin,
                                                                      bool St_alocado,
                                                                      TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[3];
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = St_alocado ? "exists" : "not exists";
            filtro[0].vVL_Busca = "(select 1 from tb_fin_duplicata_x_ccusto x " +
                                  "     where x.cd_empresa = a.cd_empresa " +
                                  "     and x.nr_lancto = a.nr_lancto)";
            filtro[1].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'A'";
            //Retirar duplicatas que são originadas do frente de caixa
            filtro[2].vNM_Campo = string.Empty;
            filtro[2].vOperador = "not exists";
            filtro[2].vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                  "      where x.cd_empresa = a.cd_empresa " +
                                  "      and x.nr_lancto = a.nr_lancto) ";
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_moeda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_moeda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_moeda.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_centroresult))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_duplicata_x_ccusto x " +
                                                      "inner join TB_FIN_CCustoLancto y " +
                                                      "on x.Id_CCustoLan = y.Id_CCustoLan " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and y.CD_CentroResult = '" + Cd_centroresult.Trim() + "') ";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_LOC_Locacao_X_Duplicata x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.Nr_lancto = a.Nr_lancto " +
                                                      "and x.id_locacao = " + Id_locacao + ") ";
            }
            if (!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "g.TP_Mov";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_movimento.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            return new TCD_LanDuplicata(banco).Select(filtro, 0, string.Empty);
        }

        public static string GravarDuplicata(TList_RegLanDuplicata val, bool ST_Avulso, TObjetoBanco banco)
        {
            if (val != null)
            {
                string retorno = "";
                for (int i = 0; i < val.Count; i++)
                    retorno += GravarDuplicata(val[i], ST_Avulso, banco);
                return retorno;
            }
            else
                return "";
        }

        public static string GravarDuplicata(TRegistro_LanDuplicata val, bool ST_Avulso, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanDuplicata qtb_duplicata = new TCD_LanDuplicata();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_duplicata.CriarBanco_Dados(true);
                else
                    qtb_duplicata.Banco_Dados = banco;

                if (val.Parcelas.Sum(p => p.Vl_parcela) != val.Vl_documento)
                    throw new Exception("Soma total das parcelas é diferente do valor da duplicata!");
                if (string.IsNullOrEmpty(val.Cd_endereco))
                    throw new Exception("Não é permitido gravar financeiro de cliente/fornecedor sem endereço.");

                //Validar CNPJ/CPF do Cliente/Fornecedor
                if (TCN_CadParamGer.BuscaVL_Bool("ST_FIN_CLIFOR_VALIDO", val.Cd_empresa, qtb_duplicata.Banco_Dados).Trim().ToUpper().Equals("S"))
                {
                    TRegistro_CadClifor rClifor = TCN_CadClifor.Busca_Clifor_Codigo(val.Cd_clifor, qtb_duplicata.Banco_Dados);
                    if (rClifor.Tp_pessoa.Trim().ToUpper().Equals("J"))
                    {
                        CNPJ_Valido.nr_CNPJ = rClifor.Nr_cgc;
                        if (string.IsNullOrEmpty(CNPJ_Valido.nr_CNPJ))
                            throw new Exception("Não é permitido emitir DUPLICATA para Cliente/Fornecedor(" + rClifor.Cd_clifor.Trim() + "-" + rClifor.Nm_clifor.Trim() + ")com CNPJ invalido.");
                    }
                    else if (rClifor.Tp_pessoa.Trim().ToUpper().Equals("F"))
                    {
                        CPF_Valido.nr_CPF = rClifor.Nr_cpf;
                        if (string.IsNullOrEmpty(CPF_Valido.nr_CPF))
                            throw new Exception("Não é permitido emitir DUPLICATA para Cliente/Fornecedor(" + rClifor.Cd_clifor.Trim() + "-" + rClifor.Nm_clifor.Trim() + ")com CPF invalido.");
                    }
                }
                string retorno = qtb_duplicata.GravaDuplicata(val);
                val.Nr_lancto = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_LANCTO"));

                retorno += "|" + TCN_LanParcela.GravarParcela(val.Parcelas, qtb_duplicata.Banco_Dados);
                //Buscar Parcelas Gravadas
                val.Parcelas = TCN_LanParcela.Busca(val.Cd_empresa,
                                                    val.Nr_lancto,
                                                    decimal.Zero,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    0,
                                                    string.Empty,
                                                    qtb_duplicata.Banco_Dados);

                TRegistro_LanLiquidacao regLiquidacao = new TRegistro_LanLiquidacao();
                //Se condição de pagamento for a vista ou com entrada, gravar quitação
                if (val.Qt_parcelas.Equals(decimal.Zero) ||
                    val.St_comentrada.Trim().ToUpper().Equals("S"))
                {
                    //Criar objeto liquidacao
                    regLiquidacao.Cd_empresa = val.Cd_empresa;
                    regLiquidacao.Id_caixaoperacional = val.Id_caixaoperacional;
                    regLiquidacao.Nr_lancto = val.Nr_lancto;
                    regLiquidacao.Nr_docto = val.Nr_docto;
                    regLiquidacao.Dt_Liquidacao = val.Dt_emissao;
                    regLiquidacao.Cd_contager = val.Cd_contager;
                    regLiquidacao.Cd_historico = val.Cd_historico_Dup;//Historico de quitacao
                    regLiquidacao.Cd_historico_desc = val.Cd_historico_Desconto;
                    regLiquidacao.ComplHistorico = val.Complhistorico;
                    regLiquidacao.Tp_mov = val.Tp_mov;
                    regLiquidacao.Cd_portador = val.Cd_portador;
                    regLiquidacao.cVl_Atual = val.Parcelas[0].Vl_parcela_padrao;
                    regLiquidacao.cVl_descontoconcedido = val.Vl_desconto;
                    regLiquidacao.cVl_DescontoTotal = decimal.Zero;
                    regLiquidacao.cVl_juroliquidar = decimal.Zero;
                    regLiquidacao.cVl_JuroTotal = decimal.Zero;
                    regLiquidacao.cVl_Liquidado = decimal.Zero;
                    regLiquidacao.cVl_Nominal = val.Parcelas[0].Vl_parcela_padrao;
                    regLiquidacao.Cvl_aliquidar_padrao = val.Parcelas[0].Vl_parcela_padrao;
                    regLiquidacao.cVl_adiantamento = val.Qt_parcelas.Equals(decimal.Zero) ? val.cVl_adiantamento : decimal.Zero;
                    regLiquidacao.lCred = val.lCred;
                    regLiquidacao.Vl_trocoCH = val.cVl_trocoCH;
                    regLiquidacao.Vl_trocoDH = val.cVl_trocoDH;
                    regLiquidacao.lChTroco = val.lChTroco;
                    regLiquidacao.Vl_adto = val.cVl_adtoCH;
                    regLiquidacao.St_AdtoTrocoCH = val.St_AdtoTrocoCH;
                    if ((val.cVl_trocoCH > decimal.Zero) ||
                        (val.cVl_trocoDH > decimal.Zero))
                    {
                        //Buscar historico de troco ch
                        object obj = new TCD_CadTpDuplicata(qtb_duplicata.Banco_Dados).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.tp_duplicata",
                                                vOperador = "=",
                                                vVL_Busca = "'" + val.Tp_duplicata.Trim() + "'"
                                            }
                                        }, "a.cd_historico_trocoCH");
                        if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                            regLiquidacao.Cd_historico_trocoCH = obj.ToString();
                        else
                            throw new Exception("Não existe historico troco cheque configurado para o tipo de duplicata " + val.Tp_duplicata.Trim());
                    }
                    //Gravar liquidacao                    
                    TCN_LanLiquidacao.GravarLiquidacao(val.Parcelas,
                                                       regLiquidacao,
                                                       (val.Titulos.Count > 0 ? val.Titulos : null),
                                                       (val.lFatura.Count > 0 ? val.lFatura : null),
                                                       null,
                                                       null,
                                                       qtb_duplicata.Banco_Dados);
                }
                if ((!val.Qt_parcelas.Equals(decimal.Zero)) &&
                    (val.cVl_adiantamento > decimal.Zero))
                {
                    //Buscar Config Adto
                    TList_ConfigAdto lCfgAdto = TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         1,
                                                                         string.Empty,
                                                                         qtb_duplicata.Banco_Dados);
                    if (lCfgAdto.Count == 0)
                        throw new Exception("Não existe CFG. Adiantamento para a Empresa: " + val.Cd_empresa.Trim());
                    if (lCfgAdto.Count > 0)
                    {
                        val.Cd_portador = lCfgAdto[0].CD_Portador;
                        val.Cd_contager = lCfgAdto[0].Cd_contagerDEV_CV;
                    }
                    //Criar objeto liquidacao
                    regLiquidacao.Cd_empresa = val.Cd_empresa;
                    regLiquidacao.Cd_clifor = val.Cd_clifor;
                    regLiquidacao.Nr_lancto = val.Nr_lancto;
                    regLiquidacao.Nr_docto = val.Nr_docto;
                    regLiquidacao.Dt_Liquidacao = val.Dt_emissao;
                    regLiquidacao.Cd_contager = val.Cd_contager;
                    if (!string.IsNullOrEmpty(val.Cd_historico_Dup))
                        regLiquidacao.Cd_historico = val.Cd_historico_Dup;//Historico de quitacao
                    else
                    {
                        object obj = new TCD_CadConfigAdto(qtb_duplicata.Banco_Dados).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                            }
                                        }, val.Tp_mov.Trim().ToUpper().Equals("P") ? "a.cd_historico_devadto_C" : "a.cd_historico_devadto_R");
                        if (obj == null)
                            throw new Exception("Não existe historico de devolução configurado.");
                        else regLiquidacao.Cd_historico = obj.ToString();
                    }
                    regLiquidacao.ComplHistorico = val.Complhistorico;
                    regLiquidacao.Tp_mov = val.Tp_mov;
                    regLiquidacao.Cd_portador = val.Cd_portador;
                    regLiquidacao.cVl_Atual = val.cVl_adiantamento;
                    regLiquidacao.cVl_descontoconcedido = decimal.Zero;
                    regLiquidacao.cVl_DescontoTotal = decimal.Zero;
                    regLiquidacao.cVl_juroliquidar = decimal.Zero;
                    regLiquidacao.cVl_JuroTotal = decimal.Zero;
                    regLiquidacao.cVl_Liquidado = decimal.Zero;
                    regLiquidacao.cVl_Nominal = val.cVl_adiantamento;
                    regLiquidacao.Cvl_aliquidar_padrao = val.cVl_adiantamento;
                    regLiquidacao.cVl_adiantamento = val.cVl_adiantamento;
                    regLiquidacao.lCred = val.lCred;
                    regLiquidacao.Id_caixaoperacional = val.Id_caixaoperacional;
                    //Gravar liquidacao do adiantamento
                    //Caso seja a vista ou com entrada, remover a primeira parcela que ja estara liquidada
                    TList_RegLanParcela lParc = new TList_RegLanParcela();
                    val.Parcelas.ForEach(p =>
                    {
                        if (p.St_registro.Trim().ToUpper() != "L")
                            lParc.Add(p);
                    });
                    TCN_LanLiquidacao.GravarLiquidacao(lParc,
                                                       regLiquidacao,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       qtb_duplicata.Banco_Dados);
                }
                //Gerar bloqueto apos a liquidacao
                if (val.Id_configBoleto.HasValue)
                    Bloqueto.TCN_Titulo.GerarBloqueto(val.Id_configboletostr,
                                                      val.Parcelas,
                                                      qtb_duplicata.Banco_Dados);
                if (val.lCustoLanctoDel != null)
                    //Deletar Duplicata X Centro Custo
                    val.lCustoLanctoDel.ForEach(p =>
                        {
                            TCN_DuplicataXCCusto.Excluir(new TRegistro_DuplicataXCCusto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Nr_lancto = val.Nr_lancto,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_duplicata.Banco_Dados);
                            CCustoLan.TCN_LanCCustoLancto.Excluir(p, qtb_duplicata.Banco_Dados);
                        });
                if (val.lCustoLancto != null)
                    //Gravar Duplicata X Centro Custo
                    val.lCustoLancto.ForEach(p =>
                        {
                            //Gravar custo lancto
                            p.Cd_empresa = val.Cd_empresa;
                            CCustoLan.TCN_LanCCustoLancto.Gravar(p, qtb_duplicata.Banco_Dados);
                            //Gravar Custo X Duplicata
                            TCN_DuplicataXCCusto.Gravar(new TRegistro_DuplicataXCCusto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Nr_lancto = val.Nr_lancto,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_duplicata.Banco_Dados);
                        });

                //Gravar Cotacao de lancamento da Duplicata
                if ((!string.IsNullOrEmpty(val.Cd_moeda)) && (!string.IsNullOrEmpty(val.DupCotacao.Cd_moedaresult.Trim())))
                    TCN_DuplicataCotacao.GravarDuplicataCotacao(new TRegistro_DuplicataCotacao()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_lancto = val.Nr_lancto,
                        Cd_moeda = val.Cd_moeda,
                        Cd_moedaresult = val.DupCotacao.Cd_moedaresult,
                        Vl_cotacao = val.DupCotacao.Vl_cotacao,
                        Operador = val.DupCotacao.Operador,
                        Dt_cotacao = val.DupCotacao.Dt_cotacao,
                        Login = Parametros.pubLogin
                    }, qtb_duplicata.Banco_Dados);

                //Gravar contabilidade
                if (ST_Avulso)//Somente financeiro avulso pode ser contabilizado
                {
                    List<CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro> lProcFin =
                        CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_Financeiro(val.Cd_empresa,
                                                                                         val.Nr_lancto.ToString(),
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         val.Nr_docto,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         decimal.Zero,
                                                                                         false,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         decimal.Zero,
                                                                                         decimal.Zero,
                                                                                         qtb_duplicata.Banco_Dados);
                    if (lProcFin.Count > 0)
                        if (lProcFin.Exists(p => p.CD_ContaDeb.HasValue && p.CD_ContaCre.HasValue))
                            CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Financeiro(lProcFin.FindAll(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue), qtb_duplicata.Banco_Dados);
                }
                if (pode_liberar)
                    qtb_duplicata.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (pode_liberar)
                    qtb_duplicata.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar duplicata: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_duplicata.deletarBanco_Dados();
            }
        }

        public static string AlterarDuplicata(TRegistro_LanDuplicata val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanDuplicata qtb_dup = new TCD_LanDuplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dup.CriarBanco_Dados(true);
                else
                    qtb_dup.Banco_Dados = banco;
                //Alterar Duplicata
                string retorno = qtb_dup.GravaDuplicata(val);
                //Alterar Parcelas
                foreach (TRegistro_LanParcela rParc in val.Parcelas)
                    TCN_LanParcela.AlterarParcela(rParc, qtb_dup.Banco_Dados);
                //Deletar Duplicata X Centro Custo
                if (val.lCustoLanctoDel != null)
                    val.lCustoLanctoDel.ForEach(p =>
                        {
                            TCN_DuplicataXCCusto.Excluir(new TRegistro_DuplicataXCCusto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Nr_lancto = val.Nr_lancto,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_dup.Banco_Dados);
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(p, qtb_dup.Banco_Dados);
                        });
                //Gravar Duplicata X Centro Custo
                if (val.lCustoLancto != null)
                    val.lCustoLancto.ForEach(p =>
                        {
                            //Gravar rateio
                            p.Cd_empresa = val.Cd_empresa;
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(p, qtb_dup.Banco_Dados);
                            //Gravar rateio X duplicata
                            TCN_DuplicataXCCusto.Gravar(
                                new TRegistro_DuplicataXCCusto()
                                {
                                    Cd_empresa = val.Cd_empresa,
                                    Nr_lancto = val.Nr_lancto,
                                    Id_ccustolan = p.Id_ccustolan
                                }, qtb_dup.Banco_Dados);
                        });
                if (st_transacao)
                    qtb_dup.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dup.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar duplicata: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }

        public static string CancelarDuplicata(TRegistro_LanDuplicata val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanDuplicata qtb_duplicata = new TCD_LanDuplicata();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_duplicata.CriarBanco_Dados(true);
                else
                    qtb_duplicata.Banco_Dados = banco;

                //Verificar se a duplicata teve origem na fixacao
                object obj = new CamadaDados.Graos.TCD_Fixacao_X_Duplicata(qtb_duplicata.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lancto",
                                        vOperador = "=",
                                        vVL_Busca = val.Nr_lancto.ToString()
                                    }
                                }, "a.id_fixacao");
                if (obj != null)
                    throw new Exception("Duplicata teve origem no processo de FIXAÇÃO de CONTRATOS.\r\n" +
                                        "Para cancelar a duplicata deve-se cancelar a FIXAÇÃO Nº " + obj.ToString());
                //Verificar se a duplicata teve origem abastecimento frota
                obj = new CamadaDados.Frota.TCD_Abast_X_Duplicata(qtb_duplicata.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = val.Nr_lancto.ToString()
                            }
                        }, "a.id_abastecimento");
                if (obj != null)
                    throw new Exception("Duplicata teve origem no abastecimento de frota.\r\n" +
                                        "Para cancelar a duplicata deve-se cancelar o ABASTECIMENTO Nº" + obj.ToString());
                //Verificar se a duplicata teve origem despesa frota
                if (new CamadaDados.Frota.TCD_Despesa_X_Duplicata(qtb_duplicata.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_lancto",
                            vOperador = "=",
                            vVL_Busca = val.Nr_lancto.ToString()
                        }
                    }, "1") != null)
                    throw new Exception("Duplicata teve origem nas despesas de viagem do modulo FROTA.\r\n" +
                                        "Para cancelar a duplicata deve-se cancelar a DESPESA.");
                //Verificar se a duplicata teve origem no Pedido
                if (new CamadaDados.Faturamento.Pedido.TCD_LanPedido_X_Duplicata(qtb_duplicata.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_lancto",
                            vOperador = "=",
                            vVL_Busca = val.Nr_lancto.ToString()
                        }
                    }, "1") != null)
                {
                    TCN_LanPedido_X_Duplicata.BuscarDup(val.Nr_pedido.Value, qtb_duplicata.Banco_Dados).ForEach(p =>
                                    {
                                        TCN_LanPedido_X_Duplicata.Excluir(new TRegistro_LanPedido_X_Duplicata()
                                        {
                                            Nr_pedido = val.Nr_pedido,
                                            Cd_empresa = val.Cd_empresa,
                                            Nr_lancto = val.Nr_lancto
                                        }, qtb_duplicata.Banco_Dados);
                                    });
                }
                //Verificar se a duplicata teve origem na OS
                if (new CamadaDados.Servicos.TCD_LanServico_X_Duplicata(qtb_duplicata.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_lancto",
                            vOperador = "=",
                            vVL_Busca = val.Nr_lancto.ToString()
                        }
                    }, "1") != null)
                    throw new Exception("Duplicata teve origem no modulo SERVICO.\r\n" +
                                        "Para cancelar a duplicata deve-se cancelar o SERVIÇO.");
                //Verificar se duplicata teve o Origem no contrato financeiro
                if (new CamadaDados.Financeiro.Contrato.TCD_ParcelaContrato(qtb_duplicata.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                       new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_lancto",
                            vOperador = "=",
                            vVL_Busca = val.Nr_lancto.ToString()
                        }
                    }, "1") != null)
                    throw new Exception("Duplicata teve origem do modulo Contrato financeiro.\r\n" +
                                                "Para cancelar a duplicata deve-se estornar o processamento!");
                //Verificar se existe liquidacao em aberto para alguma parcela do documento
                TList_RegLanLiquidacao lLiquidacao = TCN_LanLiquidacao.Busca(val.Cd_empresa,
                                                                             val.Nr_lancto,
                                                                             decimal.Zero,
                                                                             0,
                                                                             string.Empty,
                                                                             decimal.Zero,
                                                                             decimal.Zero,
                                                                             decimal.Zero,
                                                                             decimal.Zero,
                                                                             decimal.Zero,
                                                                             decimal.Zero,
                                                                             decimal.Zero,
                                                                             false,
                                                                             "A",
                                                                             0,
                                                                             string.Empty,
                                                                             qtb_duplicata.Banco_Dados);
                if (lLiquidacao.Count > 0)
                {
                    string vmsg = "";
                    for (int i = 0; i < lLiquidacao.Count; i++)
                        vmsg += "Duplicata: " + lLiquidacao[i].Nr_lancto.ToString() + "\r\n" +
                                "Parcela: " + lLiquidacao[i].Cd_parcela.ToString() + "\r\n" +
                                "Liquidacao: " + lLiquidacao[i].Id_liquid.ToString() + "\r\n\r\n";
                    throw new Exception("Documento possui parcela liquidada. Obrigatório estornar liquidação.\r\n\r\n" + vmsg);
                }
                val.St_registro = "C";
                val.Logincanc = Utils.Parametros.pubLogin;
                string retorno = qtb_duplicata.GravaDuplicata(val);
                //Verificar se a duplicata teve origem na folha pagamento
                CamadaDados.Financeiro.Folha_Pagamento.TList_Folha_X_Funcionarios lFolha =
                    CamadaNegocio.Financeiro.Folha_Pagamento.TCN_Folha_X_Funcionarios.Buscar(string.Empty,
                                                                                             string.Empty,
                                                                                             val.Cd_empresa,
                                                                                             val.Nr_lancto.ToString(),
                                                                                             qtb_duplicata.Banco_Dados);
                if (lFolha.Count > 0)
                {
                    lFolha[0].Nr_lancto = null;
                    CamadaNegocio.Financeiro.Folha_Pagamento.TCN_Folha_X_Funcionarios.Gravar(lFolha[0], qtb_duplicata.Banco_Dados);
                    //Verificar se o lote nao tem mais pagamento processado
                    object objfolha = new CamadaDados.Financeiro.Folha_Pagamento.TCD_Folha_X_Funcionarios(qtb_duplicata.Banco_Dados).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_folha",
                                                vOperador = "=",
                                                vVL_Busca = lFolha[0].Id_folha.Value.ToString()
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.nr_lancto",
                                                vOperador = "is not",
                                                vVL_Busca = "null"
                                            }
                                        }, "1");
                    if (objfolha == null)
                    {
                        //Buscar lote para alterar status
                        CamadaDados.Financeiro.Folha_Pagamento.TList_FolhaPagamento lLote =
                            CamadaNegocio.Financeiro.Folha_Pagamento.TCN_FolhaPagamento.Buscar(lFolha[0].Id_folha.Value.ToString(),
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               qtb_duplicata.Banco_Dados);
                        lLote[0].St_registro = "A";
                        CamadaNegocio.Financeiro.Folha_Pagamento.TCN_FolhaPagamento.Gravar(lLote[0], qtb_duplicata.Banco_Dados);
                    }
                }
                //Verificar se a duplicata possui bloqueto
                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloq =
                    new CamadaDados.Financeiro.Bloqueto.TCD_Titulo(qtb_duplicata.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.Nr_lancto",
                                vOperador = "=",
                                vVL_Busca = val.Nr_lancto.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                        }, 0, string.Empty);
                CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Excluir(lBloq, qtb_duplicata.Banco_Dados);
                //Duplicata agrupadora
                TCN_VincularDup.Buscar(val.Cd_empresa,
                                       val.Nr_lancto.ToString(),
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       qtb_duplicata.Banco_Dados).ForEach(p => TCN_VincularDup.Excluir(p, qtb_duplicata.Banco_Dados));
                //Verificar se a duplicata possui centro de resultado
                TCN_DuplicataXCCusto.BuscarCusto(val.Cd_empresa,
                                                 val.Nr_lancto.ToString(),
                                                 qtb_duplicata.Banco_Dados).ForEach(p =>
                {
                    //Excluir amarracao centro resultado com duplicata
                    TCN_DuplicataXCCusto.Excluir(new TRegistro_DuplicataXCCusto()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_lancto = val.Nr_lancto,
                        Id_ccustolan = p.Id_ccustolan
                    }, qtb_duplicata.Banco_Dados);
                    //Excluir lancamento centro resultado
                    CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(p, qtb_duplicata.Banco_Dados);
                });
                //Excluir faturamento comissao
                CamadaNegocio.Faturamento.Comissao.TCN_Comissao_X_Duplicata.Buscar(string.Empty,
                                                                                   val.Cd_empresa,
                                                                                   val.Nr_lancto.ToString(),
                                                                                   qtb_duplicata.Banco_Dados).ForEach(p =>
                                                                                       CamadaNegocio.Faturamento.Comissao.TCN_Comissao_X_Duplicata.Excluir(p, qtb_duplicata.Banco_Dados));
                //Excluir Lançamento Contabil
                if (val.Id_lotectb.HasValue)
                    qtb_duplicata.executarSql("exec dbo.EXCLUI_CTB_LANCTOSLOTE @P_ID_LOTECTB = " + val.Id_lotectb.Value.ToString(), null);
                if (pode_liberar)
                    qtb_duplicata.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (pode_liberar)
                    qtb_duplicata.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar Duplicata: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_duplicata.deletarBanco_Dados();
            }
        }

        public static string AgruparDuplicata(TRegistro_LanDuplicata val,
                                              List<TRegistro_LanParcela> lParcAgrupar,
                                              decimal vl_juro,
                                              decimal vl_desconto,
                                              TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanDuplicata qtb_dup = new TCD_LanDuplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dup.CriarBanco_Dados(true);
                else
                    qtb_dup.Banco_Dados = banco;
                //Gravar a duplicata Agrupamento
                string retorno = GravarDuplicata(val, false, qtb_dup.Banco_Dados);
                //Gravar Vincular Dup
                lParcAgrupar.ForEach(p =>
                {
                    //Verificar se parcela possui boleto
                    new CamadaDados.Financeiro.Bloqueto.TCD_Titulo(qtb_dup.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = p.Nr_lanctostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_parcela",
                                vOperador = "=",
                                vVL_Busca = p.Cd_parcelastr
                            }
                        }, 0, string.Empty).ForEach(x => CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Excluir(x, qtb_dup.Banco_Dados));
                    TCN_VincularDup.Gravar(new TRegistro_VincularDup()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_lancto = val.Nr_lancto,
                        Nr_lanctovinculado = p.Nr_lancto,
                        Cd_parcelavinculado = p.Cd_parcela,
                        Vl_parcelavinculado = p.cVl_atual
                    }, qtb_dup.Banco_Dados);
                });
                if (st_transacao)
                    qtb_dup.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dup.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro agrupar duplicata: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }

        public static void DuplicatasPerdidas(List<TRegistro_LanParcela> lParcPerdida,
                                              TObjetoBanco banco, string st_Registro = "D")
        {
            bool st_transacao = false;
            TCD_LanDuplicata qtb_dup = new TCD_LanDuplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dup.CriarBanco_Dados(true);
                else
                    qtb_dup.Banco_Dados = banco;
                //Gravar Parcela como Perdida
                lParcPerdida.FindAll(p => p.St_processar).ForEach(p =>
                 {
                     p.St_registro = st_Registro;
                     CamadaNegocio.Financeiro.Duplicata.TCN_LanParcela.GravarParcela(p, qtb_dup.Banco_Dados);
                 });
                if (st_transacao)
                    qtb_dup.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dup.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar parcela como perdida: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }

        public static TList_RegLanParcela calcularParcelas(TRegistro_LanDuplicata val, TObjetoBanco banco)
        {
            if (val != null)
            {
                //Buscar Parcelas da Condicao de pagamento
                TList_CadCondPgto_X_Parcelas lCondParc = TCN_CadCondPgto_X_Parcelas.Buscar(val.Cd_condpgto, banco);
                if (val.Parcelas == null)
                    val.Parcelas = new TList_RegLanParcela();
                if (val.Nr_pedido != null && !TCN_CadParamGer.BuscaVL_Bool("CALC_PARCELASDUP_NF", val.Cd_empresa, banco).Equals("S"))
                {
                    //Verificar se existe financeiro para o pedido
                    TList_Pedido_DT_Vencto lPedFin = TCN_LanPedido_DT_Vencto.Busca(val.Nr_pedido != null ? Convert.ToDecimal(val.Nr_pedido) : 0, banco);
                    if (lPedFin.Count > 0)
                    {
                        decimal total_finped = lPedFin.Sum(p => p.VL_Parcela);
                        //Verificar se o total do financeiro do pedido e igual ao valor do documento
                        if (total_finped.Equals(val.Vl_documento_padrao))
                        {
                            for (int i = 0; i < lPedFin.Count; i++)
                            {
                                TRegistro_LanParcela reg_parcela = new TRegistro_LanParcela();
                                reg_parcela.St_CalcVl_Parcela = true;
                                reg_parcela.Cd_empresa = val.Cd_empresa;
                                reg_parcela.Nr_lancto = val.Nr_lancto;
                                reg_parcela.Cd_parcela = i + 1;
                                reg_parcela.Vl_atual = lPedFin[i].VL_Parcela;
                                reg_parcela.Vl_parcela = lPedFin[i].VL_Parcela;
                                reg_parcela.cVl_atual = lPedFin[i].VL_Parcela;
                                DateTime dt_feriado = lPedFin[i].Dt_vencto.Value;
                                validaFeriado(val.St_venctoferiado.Trim().ToUpper().Equals("S"), ref dt_feriado);
                                reg_parcela.Dt_vencto = dt_feriado;
                                val.Parcelas.Add(reg_parcela);
                            }
                            return val.Parcelas;
                        }
                        else
                        {
                            //Fazer rateio do valor faturado 
                            decimal cd_parcela = decimal.Zero;
                            lPedFin.ForEach(p =>
                                {
                                    val.Parcelas.Add(new TRegistro_LanParcela()
                                    {
                                        St_CalcVl_Parcela = true,
                                        Cd_empresa = val.Cd_empresa,
                                        Nr_lancto = val.Nr_lancto,
                                        Cd_parcela = ++cd_parcela,
                                        Vl_atual = Math.Round((val.Vl_documento * Math.Round((p.VL_Parcela / total_finped * 100), 2) / 100), 2),
                                        Vl_parcela = Math.Round((val.Vl_documento * Math.Round((p.VL_Parcela / total_finped * 100), 2) / 100), 2),
                                        cVl_atual = Math.Round((val.Vl_documento * Math.Round((p.VL_Parcela / total_finped * 100), 2) / 100), 2),
                                        Dt_vencto = p.Dt_vencto.Value
                                    });
                                });
                            total_finped = val.Parcelas.Sum(p => p.Vl_parcela);
                            if (total_finped != val.Vl_documento)
                                val.Parcelas[val.Parcelas.Count - 1].Vl_parcela += (val.Vl_documento - total_finped);
                        }
                    }
                    else
                    {
                        //A vista
                        if (val.Qt_parcelas.Equals(0))
                        {
                            TRegistro_LanParcela reg_parcela = new TRegistro_LanParcela();
                            reg_parcela.St_CalcVl_Parcela = true;
                            reg_parcela.Cd_empresa = val.Cd_empresa;
                            reg_parcela.Nr_lancto = val.Nr_lancto;
                            reg_parcela.Cd_parcela = 1;
                            reg_parcela.Vl_parcela_padrao = val.Vl_documento_padrao;
                            reg_parcela.Vl_atual = val.Vl_documento_padrao;
                            reg_parcela.cVl_atual = val.Vl_documento;
                            DateTime dt_feriado = Convert.ToDateTime(val.Dt_emissao);
                            validaFeriado(val.St_venctoferiado.Trim().ToUpper().Equals("S"), ref dt_feriado);
                            reg_parcela.Dt_vencto = dt_feriado;
                            val.Parcelas.Add(reg_parcela);
                        }
                        else
                        {
                            if (lCondParc.Count > 0)
                            {
                                TList_Parcelas lParc = TLanCalcParcelas.CalcularParcelas(val.Vl_documento, val.Vl_documento_padrao, val.Dt_emissao.Value, lCondParc);
                                TList_RegLanParcela lista = new TList_RegLanParcela();
                                DateTime dt_venctoanterior = DateTime.Now;
                                for (int i = 0; i < lParc.Count; i++)
                                {
                                    DateTime dt_vencto = lParc[i].Dt_vencimento.Value;
                                    if (i == 0)
                                    {
                                        validaFeriado(val.St_venctoferiado.Trim().Equals("S"), ref dt_vencto);
                                        dt_venctoanterior = dt_vencto;
                                    }
                                    else
                                    {
                                        if (dt_venctoanterior.Date.Equals(dt_vencto.Date))
                                            dt_vencto = dt_vencto.AddDays(1);
                                        validaFeriado(val.St_venctoferiado.Trim().Equals("S"), ref dt_vencto);
                                        dt_venctoanterior = dt_vencto;
                                    }

                                    lista.Add(new TRegistro_LanParcela()
                                    {
                                        St_CalcVl_Parcela = true,
                                        Cd_empresa = val.Cd_empresa,
                                        Nr_lancto = val.Nr_lancto,
                                        Cd_parcela = i + 1,
                                        Vl_parcela_padrao = lParc[i].Vl_parcela_padrao,
                                        Vl_parcela = lParc[i].Vl_parcela,
                                        Vl_atual = lParc[i].Vl_parcela_padrao,
                                        cVl_atual = lParc[i].Vl_parcela_padrao,
                                        Dt_vencto = dt_vencto
                                    }
                                    );
                                }
                                val.Parcelas = lista;
                            }
                            else
                            {
                                decimal vl_parcela = 0;
                                if (val.St_comentrada.Trim().Equals("S"))
                                    vl_parcela = ((val.Vl_documento - val.Vl_entrada) / (val.Qt_parcelas - 1));
                                else
                                    vl_parcela = val.Vl_documento / val.Qt_parcelas;
                                TList_RegLanParcela lista = new TList_RegLanParcela();
                                for (int i = 0; i < val.Qt_parcelas; i++)
                                {
                                    TRegistro_LanParcela reg_parcela = new TRegistro_LanParcela();
                                    reg_parcela.St_CalcVl_Parcela = true;
                                    reg_parcela.Cd_empresa = val.Cd_empresa;
                                    reg_parcela.Nr_lancto = val.Nr_lancto;
                                    reg_parcela.Cd_parcela = i + 1;
                                    if ((i == 0) && (val.St_comentrada.Trim().Equals("S")))
                                    {
                                        reg_parcela.Vl_parcela_padrao = val.Vl_entrada_padrao;
                                        reg_parcela.Vl_atual = val.Vl_entrada_padrao;
                                        reg_parcela.cVl_atual = val.Vl_entrada;
                                        reg_parcela.Dt_vencto = Convert.ToDateTime(val.Dt_emissao);
                                    }
                                    else
                                    {
                                        reg_parcela.Vl_parcela = vl_parcela;
                                        reg_parcela.Vl_atual = reg_parcela.Vl_parcela_padrao;
                                        reg_parcela.cVl_atual = reg_parcela.Vl_parcela;
                                        DateTime dt_emissao = new DateTime();
                                        if (val.Qt_dias_desdobro == 0)
                                            dt_emissao = val.Dt_emissao.Value;
                                        else
                                            if (i == 0)
                                            dt_emissao = val.Dt_emissao.Value.AddDays(Convert.ToDouble(val.Qt_dias_desdobro));
                                        else
                                            dt_emissao = lista[i - 1].Dt_vencto.Value.AddDays(Convert.ToDouble(val.Qt_dias_desdobro));
                                        DateTime dt_feriado = dt_emissao;
                                        validaFeriado(val.St_venctoferiado.Trim().Equals("S"), ref dt_feriado);
                                        reg_parcela.Dt_vencto = dt_feriado;
                                    }
                                    lista.Add(reg_parcela);
                                }
                                val.Parcelas = lista;
                            }
                            /***
                            ****Função responsavel por verificar a diferença entre
                            ****o valor da duplicata e a soma dos valores das parcelas
                            ****, ocasionado devido ao arredondamento para duas casas decimais,
                            ****e lançar esta diferença na ultima parcela.
                            ***/
                            recalcParcelas(val, false); //Recalcula valor Moeda da Duplicata
                            recalcParcelas(val, true); //Recalcula valor Moeda Padrao
                        }
                    }
                }
                else
                {
                    //A vista
                    if (val.Qt_parcelas.Equals(0))
                    {
                        TRegistro_LanParcela reg_parcela = new TRegistro_LanParcela();
                        reg_parcela.St_CalcVl_Parcela = true;
                        reg_parcela.Cd_empresa = val.Cd_empresa;
                        reg_parcela.Nr_lancto = val.Nr_lancto;
                        reg_parcela.Cd_parcela = 1;
                        reg_parcela.Vl_parcela_padrao = val.Vl_documento_padrao;
                        reg_parcela.Vl_atual = val.Vl_documento_padrao;
                        reg_parcela.cVl_atual = val.Vl_documento;
                        DateTime dt_feriado = Convert.ToDateTime(val.Dt_emissao);
                        validaFeriado(val.St_venctoferiado.Trim().ToUpper().Equals("S"), ref dt_feriado);
                        reg_parcela.Dt_vencto = dt_feriado;
                        val.Parcelas.Add(reg_parcela);
                    }
                    else
                    {
                        if (lCondParc.Count > 0)
                        {
                            TList_Parcelas lParc = TLanCalcParcelas.CalcularParcelas(val.Vl_documento, val.Vl_documento_padrao, val.Dt_emissao.Value, lCondParc);
                            TList_RegLanParcela lista = new TList_RegLanParcela();
                            DateTime dt_venctoanterior = DateTime.Now;
                            for (int i = 0; i < lParc.Count; i++)
                            {
                                DateTime dt_vencto = lParc[i].Dt_vencimento.Value;
                                if (i == 0)
                                {
                                    validaFeriado(val.St_venctoferiado.Trim().Equals("S"), ref dt_vencto);
                                    dt_venctoanterior = dt_vencto;
                                }
                                else
                                {
                                    if (dt_venctoanterior.Date.Equals(dt_vencto.Date))
                                        dt_vencto = dt_vencto.AddDays(1);
                                    validaFeriado(val.St_venctoferiado.Trim().Equals("S"), ref dt_vencto);
                                    dt_venctoanterior = dt_vencto;
                                }

                                lista.Add(new TRegistro_LanParcela()
                                {
                                    St_CalcVl_Parcela = true,
                                    Cd_empresa = val.Cd_empresa,
                                    Nr_lancto = val.Nr_lancto,
                                    Cd_parcela = i + 1,
                                    Vl_parcela_padrao = lParc[i].Vl_parcela_padrao,
                                    Vl_parcela = lParc[i].Vl_parcela,
                                    Vl_atual = lParc[i].Vl_parcela_padrao,
                                    cVl_atual = lParc[i].Vl_parcela_padrao,
                                    Dt_vencto = dt_vencto
                                }
                                );
                            }
                            val.Parcelas = lista;
                        }
                        else
                        {
                            decimal vl_parcela = 0;
                            if (val.St_comentrada.Trim().Equals("S"))
                                vl_parcela = ((val.Vl_documento - val.Vl_entrada) / (val.Qt_parcelas - 1));
                            else
                                vl_parcela = val.Vl_documento / val.Qt_parcelas;
                            TList_RegLanParcela lista = new TList_RegLanParcela();
                            for (int i = 0; i < val.Qt_parcelas; i++)
                            {
                                TRegistro_LanParcela reg_parcela = new TRegistro_LanParcela();
                                reg_parcela.St_CalcVl_Parcela = true;
                                reg_parcela.Cd_empresa = val.Cd_empresa;
                                reg_parcela.Nr_lancto = val.Nr_lancto;
                                reg_parcela.Cd_parcela = i + 1;
                                if ((i == 0) && (val.St_comentrada.Trim().Equals("S")))
                                {
                                    reg_parcela.Vl_parcela_padrao = val.Vl_entrada_padrao;
                                    reg_parcela.Vl_atual = val.Vl_entrada_padrao;
                                    reg_parcela.cVl_atual = val.Vl_entrada;
                                    reg_parcela.Dt_vencto = Convert.ToDateTime(val.Dt_emissao);
                                }
                                else
                                {
                                    reg_parcela.Vl_parcela = vl_parcela;
                                    reg_parcela.Vl_atual = reg_parcela.Vl_parcela_padrao;
                                    reg_parcela.cVl_atual = reg_parcela.Vl_parcela;
                                    DateTime dt_emissao = new DateTime();
                                    if (val.Qt_dias_desdobro == 0)
                                        dt_emissao = val.Dt_emissao.Value;
                                    else
                                        if (i == 0)
                                        dt_emissao = val.Dt_emissao.Value.AddDays(Convert.ToDouble(val.Qt_dias_desdobro));
                                    else
                                        dt_emissao = lista[i - 1].Dt_vencto.Value.AddDays(Convert.ToDouble(val.Qt_dias_desdobro));
                                    DateTime dt_feriado = dt_emissao;
                                    validaFeriado(val.St_venctoferiado.Trim().Equals("S"), ref dt_feriado);
                                    reg_parcela.Dt_vencto = dt_feriado;
                                }
                                lista.Add(reg_parcela);
                            }
                            val.Parcelas = lista;
                        }
                        /***
                        ****Função responsavel por verificar a diferença entre
                        ****o valor da duplicata e a soma dos valores das parcelas
                        ****, ocasionado devido ao arredondamento para duas casas decimais,
                        ****e lançar esta diferença na ultima parcela.
                        ***/
                        recalcParcelas(val, false); //Recalcula valor Moeda da Duplicata
                        recalcParcelas(val, true); //Recalcula valor Moeda Padrao
                    }
                }
                return val.Parcelas;
            }
            else
                return null;
        }

        public static void recalculaParcelas(TRegistro_LanDuplicata val, int index, bool st_valorPadrao)
        {
            if (val != null)
                if (val.Parcelas != null)
                {
                    reajustaValorParcela(val, index, st_valorPadrao);
                    decimal diferenca = decimal.Zero;
                    if (st_valorPadrao)
                        diferenca = (val.Vl_documento_padrao - somaParcelas(val, st_valorPadrao));
                    else
                        diferenca = (val.Vl_documento - somaParcelas(val, st_valorPadrao));
                    decimal nParcelas = (val.Qt_parcelas - (index + 1));
                    diferenca = (diferenca / nParcelas);
                    for (int i = (index + 1); i < val.Qt_parcelas; i++)
                    {
                        if (st_valorPadrao)
                            val.Parcelas[i].Vl_parcela_padrao += diferenca;
                        else
                            val.Parcelas[i].Vl_parcela += diferenca;
                        reajustaValorParcela(val, i, st_valorPadrao);
                    }
                    recalcParcelas(val, false); //Recalcula valor Moeda da Duplicata
                    recalcParcelas(val, true); //Recalcula valor Moeda Padrao
                }
        }

        public static TList_RegLanParcela Recalcula_Parcelas_List(TRegistro_LanDuplicata val, int index)
        {
            if (val != null)
            {
                if (val.Parcelas != null)
                {
                    reajustaValorParcela(val, index, false);
                    decimal diferenca = (val.Vl_documento - somaParcelas(val, false));
                    decimal nParcelas = (val.Qt_parcelas - (index + 1)); //restantes
                    if (nParcelas > decimal.Zero && diferenca > decimal.Zero)
                    {
                        diferenca = decimal.Divide(diferenca, nParcelas);
                        for (int i = (index + 1); i < val.Qt_parcelas; i++)
                        {
                            val.Parcelas[i].Vl_parcela += diferenca;
                            reajustaValorParcela(val, i, false);
                        }
                    }
                    recalcParcelas(val, false);
                    return val.Parcelas;
                }
            }
            return null;
        }

        public static void validaDataVencimento(TRegistro_LanDuplicata val, int index)
        {
            try
            {
                if (index != 0)
                {
                    if (val.Parcelas[index].Dt_vencto < val.Parcelas[index - 1].Dt_vencto)
                    {
                        DateTime dt_feriado = val.Parcelas[index - 1].Dt_vencto.Value.AddDays(1);
                        validaFeriado(val.St_venctoferiado.Trim().Equals("S"), ref dt_feriado);
                        val.Parcelas[index].Dt_vencto = dt_feriado;
                    }
                }
                else
                    if (val.Parcelas[index].Dt_vencto < val.Dt_emissao)
                {
                    DateTime dt_feriado = Convert.ToDateTime(val.Dt_emissao);
                    validaFeriado(val.St_venctoferiado.Trim().Equals("S"), ref dt_feriado);
                    val.Parcelas[index].Dt_vencto = dt_feriado;
                }
                recalcDataVencimento(val, index);
            }
            catch
            { }
        }

        public static void ProcessarVendasExterna(CamadaDados.Faturamento.Cadastros.TRegistro_CFGVendasExterna rCfg,
                                                  CamadaDados.Faturamento.VendasExterna.Boleto rVenda)
        {
            TCD_LanDuplicata qtb_dup = new TCD_LanDuplicata();
            try
            {
                qtb_dup.CriarBanco_Dados(true);
                //Buscar condição pagamento
                TRegistro_CadCondPgto rCond = TCN_CadCondPgto.Buscar(rCfg.Cd_condpgto,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     decimal.Zero,
                                                                     decimal.Zero,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     1,
                                                                     string.Empty,
                                                                     qtb_dup.Banco_Dados)[0];
                //Buscar Cliente
                object objC = new TCD_CadClifor().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "a.cd_integracao = " + rVenda.ATENDIMENTOS[0].ATENDIMENTO.CLIENTE.CODIGO + " or " +
                                        "dbo.FVALIDA_NUMEROS(" + (rVenda.ATENDIMENTOS[0].ATENDIMENTO.CLIENTE.DOCUMENTO.SoNumero().Length.Equals(11) ? "a.nr_cpf" : "a.nr_cgc") + ") = '" + rVenda.ATENDIMENTOS[0].ATENDIMENTO.CLIENTE.DOCUMENTO.SoNumero() + "'"
                        }
                    }, "a.cd_clifor");
                if (objC == null ? true : string.IsNullOrWhiteSpace(objC.ToString()))
                    throw new Exception("Cliente não cadastrado no sistema Aliance.NET.");
                //Buscar endereco cliente
                object objE = new TCD_CadEndereco().BuscarEscalar(new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + objC.ToString() + "'" } }, "a.cd_endereco");
                //Gerar Duplicata
                string ret = qtb_dup.GravaDuplicata(new TRegistro_LanDuplicata
                {
                    Cd_empresa = rCfg.Cd_empresa,
                    Cd_historico = rCfg.Cd_historico,
                    Tp_docto = rCfg.Tp_docto,
                    Tp_duplicata = rCfg.Tp_duplicata,
                    Cd_clifor = objC.ToString(),
                    Cd_endereco = objE.ToString(),
                    Cd_juro = rCond.Cd_juro,
                    Cd_moeda = TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", rCfg.Cd_empresa) ?? rCond.Cd_moeda,
                    Cd_condpgto = rCond.Cd_condpgto,
                    Nr_docto = rVenda.NUMERO_DOCUMENTO,
                    Vl_documento = rVenda.VALOR,
                    Vl_documento_padrao = rVenda.VALOR,
                    Dt_emissao = rVenda.PROCESSAMENTO,
                    Qt_parcelas = rCond.Qt_parcelas,
                    Qt_dias_desdobro = rCond.Qt_diasdesdobro,
                    St_comentrada = rCond.St_comentrada,
                    Tp_juro = rCond.Tp_juro,
                    Pc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo,
                    Ds_observacao = "INTEGRAÇÃO VENDAS EXTERNA",
                    St_registro = "A"
                });
                //Gerar Parcela
                string retP = TCN_LanParcela.GravarParcela(new TRegistro_LanParcela
                {
                    Cd_empresa = rCfg.Cd_empresa,
                    Nr_lancto = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_NR_LANCTO")),
                    Cd_parcela = 1,
                    Dt_vencto = rVenda.VENCIMENTO,
                    Vl_parcela = rVenda.VALOR,
                    Vl_parcela_padrao = rVenda.VALOR,
                    St_registro = "A"
                }, qtb_dup.Banco_Dados);
                //Gravar Boleto
                //Buscar Config de Cobranca
                TList_CadCFGBanco lCfgbanco = TCN_CadCFGBanco.Buscar(rCfg.Id_configstr,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     "A",
                                                                     string.Empty,
                                                                     0,
                                                                     qtb_dup.Banco_Dados);
                CamadaDados.Financeiro.Bloqueto.blTitulo rTitulo = new CamadaDados.Financeiro.Bloqueto.blTitulo();
                rTitulo.Cd_empresa = rCfg.Cd_empresa.Trim();
                rTitulo.Nr_lancto = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_NR_LANCTO"));
                rTitulo.Cd_parcela = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retP, "@P_CD_PARCELA"));
                rTitulo.Id_config = lCfgbanco[0].Id_config;
                rTitulo.Cd_contager = lCfgbanco[0].Cd_contager;
                rTitulo.Tp_cobranca = lCfgbanco[0].Tp_cobranca;
                rTitulo.Dt_emissaobloqueto = rVenda.PROCESSAMENTO;
                rTitulo.Nosso_numero = rVenda.NUMERO_DOCUMENTO.FormatStringEsquerda(7, '0');
                if (new CamadaDados.Financeiro.Bloqueto.TCD_Titulo(qtb_dup.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.CD_ContaGer",
                            vOperador = "=",
                            vVL_Busca = "'" + lCfgbanco[0].Cd_contager.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.codigocedente",
                            vOperador = "=",
                            vVL_Busca = "'" + lCfgbanco[0].Codigocedente.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nossonumero",
                            vOperador = "=",
                            vVL_Busca = "'" + rTitulo.Nosso_numero.Trim() + "'"
                        }
                    }, "1") != null)
                    throw new Exception("Ja existe um boleto no sistema com o nosso numero " + rTitulo.Nosso_numero.Trim() + ".");
                rTitulo.Aceite_documento = lCfgbanco[0].Aceite_sn.Trim().ToUpper().Equals("S") ? CamadaDados.Financeiro.Bloqueto.TAceiteDocumento.adSim : CamadaDados.Financeiro.Bloqueto.TAceiteDocumento.adNao;
                rTitulo.Carteira = lCfgbanco[0].Tp_carteira;
                rTitulo.Local_pagamento = lCfgbanco[0].Ds_localpagamento;
                rTitulo.Instrucoes = Bloqueto.TCN_Titulo.GerarInstrucoes(lCfgbanco[0].Tp_multa,
                                                                         lCfgbanco[0].Pc_multa,
                                                                         lCfgbanco[0].Nr_diasmulta,
                                                                         lCfgbanco[0].Tp_jurodia,
                                                                         lCfgbanco[0].Pc_jurodia,
                                                                         lCfgbanco[0].Tp_desconto,
                                                                         lCfgbanco[0].Pc_desconto,
                                                                         lCfgbanco[0].Nr_diasdesconto,
                                                                         lCfgbanco[0].St_protestoautobool,
                                                                         lCfgbanco[0].Nr_diasprotesto,
                                                                         lCfgbanco[0].Ds_instrucoes,
                                                                         rVenda.VALOR,
                                                                         rVenda.VENCIMENTO);
                rTitulo.Especie_documento = CamadaDados.Financeiro.Bloqueto.blTitulo.RetornarEspecieDocumento(Convert.ToInt32(lCfgbanco[0].EspecieDocumento));
                rTitulo.Cedente.CodigoCedente = lCfgbanco[0].Codigocedente;
                if (lCfgbanco[0].Nr_diasprotesto > 0)
                    rTitulo.Dt_protesto = rVenda.VENCIMENTO.AddDays(Convert.ToDouble(lCfgbanco[0].Nr_diasprotesto));
                rTitulo.Cd_integracao = rVenda.CODIGO;
                //Gravar o Titulo
                Bloqueto.TCN_Titulo.Gravar(rTitulo, qtb_dup.Banco_Dados);
                qtb_dup.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                qtb_dup.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message.Trim());
            }
            finally { qtb_dup.deletarBanco_Dados(); }
        }
    }

    public class TCN_DuplicataCotacao
    {
        public static TList_DuplicataCotacao Buscar(string vCd_empresa,
                                                    decimal vNr_lancto,
                                                    string vCd_moeda,
                                                    string vCd_moedaresult,
                                                    int vTop,
                                                    string vNm_campo, TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vCd_empresa.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vNr_lancto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_Lancto";
                filtro[filtro.Length - 1].vVL_Busca = vNr_lancto.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_moeda.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Moeda";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_moeda + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_moedaresult.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_MoedaResult";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_moedaresult + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new TCD_DuplicataCotacao(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarDuplicataCotacao(TRegistro_DuplicataCotacao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DuplicataCotacao qtb_dup = new TCD_DuplicataCotacao();
            try
            {
                if (banco == null)
                {
                    qtb_dup.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_dup.Banco_Dados = banco;
                string retorno = qtb_dup.GravarDuplicataCotacao(val);
                if (st_transacao)
                    qtb_dup.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dup.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar cotação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }

        public static string DeletarDuplicataCotacao(TRegistro_DuplicataCotacao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DuplicataCotacao qtb_dup = new TCD_DuplicataCotacao();
            try
            {
                if (banco == null)
                {
                    qtb_dup.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_dup.Banco_Dados = banco;
                qtb_dup.DeletarDuplicataCotacao(val);
                if (st_transacao)
                    qtb_dup.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dup.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir cotação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }
    }

    public class TCN_LanParcela
    {
        public static TList_RegLanParcela Busca(string vCD_Empresa,
                                                decimal vNR_Lancto,
                                                decimal vCD_Parcela,
                                                string vDT_Vencto,
                                                string vSt_registro,
                                                string vCd_clifor,
                                                string vCd_moeda,
                                                string vTp_mov,
                                                int vTop,
                                                string vNM_Campo,
                                                TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vNR_Lancto > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Lancto";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Lancto.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_Parcela > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Parcela";
                vBusca[vBusca.Length - 1].vVL_Busca = vCD_Parcela.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if ((!string.IsNullOrEmpty(vDT_Vencto)) && (vDT_Vencto.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Vencto)))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Vencto).ToString("yyyyMMdd") + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vSt_registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isNull(a.ST_Registro, 'A')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vSt_registro + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "c.CD_Clifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_clifor + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_moeda))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "e.CD_Moeda";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_moeda + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTp_mov))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "t.TP_Mov";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_mov + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            return new TCD_LanParcela(banco).Select(vBusca, vTop, vNM_Campo, "a.dt_vencto, c.nm_clifor", string.Empty);
        }

        public static TRegistro_LanParcela BuscarParcela(string Cd_empresa,
                                                         string Nr_lancto,
                                                         string Cd_parcela,
                                                         TObjetoBanco banco)
        {
            if ((Cd_empresa.Trim() != string.Empty) &&
                (Nr_lancto.Trim() != string.Empty) &&
                (Cd_parcela.Trim() != string.Empty))
            {
                TList_RegLanParcela lParc = new TCD_LanParcela(banco).Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_lancto",
                                                        vOperador = "=",
                                                        vVL_Busca = Nr_lancto
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_parcela",
                                                        vOperador = "=",
                                                        vVL_Busca = Cd_parcela
                                                    }
                                                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                if (lParc.Count > 0)
                    return lParc[0];
                else
                    return null;
            }
            else
                return null;
        }

        public static DataTable BuscaRelGeralContas(string vDt_ini,
                                                    string vDt_fin,
                                                    string vTp_data,
                                                    string vCd_empresa,
                                                    string vTp_mov,
                                                    string vNr_docto,
                                                    string vNr_contrato,
                                                    string vTp_duplicata,
                                                    string vId_regiao,
                                                    string vCd_ccusto,
                                                    string vCd_clifor,
                                                    string vTp_status)
        {
            TpBusca[] filtro = new TpBusca[0];
            if ((vDt_ini.Trim() != "") && (vDt_ini.Trim() != "/  /       :"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = vTp_data.Trim().ToUpper().Equals("E") ? "a.DT_Emissao" :
                    vTp_data.Trim().ToUpper().Equals("V") ? "c.DT_Vencto" :
                    vTp_data.Trim().ToUpper().Equals("L") ? "(select max(x.dt_liquidacao) from tb_fin_liquidacao x " +
                                                          "where x.cd_empresa = c.cd_empresa " +
                                                          "and x.nr_lancto = c.nr_lancto " +
                                                          "and x.cd_parcela = c.cd_parcela " +
                                                          "and isNull(x.st_registro, 'A') <> 'C')" : "";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_ini).ToString("yyyyMMdd HH:mm")) + "'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((vDt_fin.Trim() != "") && (vDt_fin.Trim() != "/  /       :"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = vTp_data.Trim().ToUpper().Equals("E") ? "a.DT_Emissao" :
                    vTp_data.Trim().ToUpper().Equals("V") ? "c.DT_Vencto" :
                    vTp_data.Trim().ToUpper().Equals("L") ? "(select max(x.dt_liquidacao) from tb_fin_liquidacao x " +
                                                          "where x.cd_empresa = c.cd_empresa " +
                                                          "and x.nr_lancto = c.nr_lancto " +
                                                          "and x.cd_parcela = c.cd_parcela " +
                                                          "and isNull(x.st_registro, 'A') <> 'C')" : "";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_fin).ToString("yyyyMMdd HH:mm")) + "'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (vCd_empresa.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vTp_mov.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.tp_mov";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_mov.Trim().ToUpper() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vNr_docto.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_docto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_docto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vNr_contrato.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "contrato.NR_Contrato";
                filtro[filtro.Length - 1].vVL_Busca = vNr_contrato;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vTp_duplicata.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.TP_Duplicata";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_duplicata.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vId_regiao.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "e.ID_Regiao";
                filtro[filtro.Length - 1].vVL_Busca = vId_regiao;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_ccusto.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = " ";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_duplicata_x_ccusto x " +
                                                      "inner join tb_fin_centrocusto y " +
                                                      "on x.cd_ccusto = y.cd_ccusto " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and((x.cd_ccusto = '" + vCd_ccusto.Trim() + "')" +
                                                      "or(y.cd_ccusto_pai = '" + vCd_ccusto.Trim() + "')))";
                filtro[filtro.Length - 1].vOperador = "EXISTS";
            }
            if (vCd_clifor.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_clifor.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vTp_status.Trim().ToUpper().Equals("TA"))
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "isNull(a.st_registro, 'A')";
                filtro[filtro.Length - 2].vVL_Busca = "'A'";
                filtro[filtro.Length - 2].vOperador = "=";
                filtro[filtro.Length - 1].vNM_Campo = "isNull(c.st_registro, 'A')";
                filtro[filtro.Length - 1].vVL_Busca = "('A', 'P')";
                filtro[filtro.Length - 1].vOperador = "IN";
            }
            else if (vTp_status.Trim().ToUpper().Equals("T"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isNull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vVL_Busca = "'C'";
                filtro[filtro.Length - 1].vOperador = "<>";
            }
            else if (vTp_status.Trim().ToUpper().Equals("L"))
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "isNull(a.st_registro, 'A')";
                filtro[filtro.Length - 2].vVL_Busca = "'A'";
                filtro[filtro.Length - 2].vOperador = "=";
                filtro[filtro.Length - 1].vNM_Campo = "isNull(c.st_registro, 'A')";
                filtro[filtro.Length - 1].vVL_Busca = "('L','P')";
                filtro[filtro.Length - 1].vOperador = "IN";
            }
            else if (vTp_status.Trim().ToUpper().Equals("AV"))
            {
                Array.Resize(ref filtro, filtro.Length + 3);
                filtro[filtro.Length - 3].vNM_Campo = "isNull(a.st_registro, 'A')";
                filtro[filtro.Length - 3].vVL_Busca = "'A'";
                filtro[filtro.Length - 3].vOperador = "=";
                filtro[filtro.Length - 2].vNM_Campo = "isNull(c.st_registro, 'A')";
                filtro[filtro.Length - 2].vVL_Busca = "('A', 'P')";
                filtro[filtro.Length - 2].vOperador = "IN";
                filtro[filtro.Length - 1].vNM_Campo = "c.DT_Vencto";
                filtro[filtro.Length - 1].vVL_Busca = "getDate()";
                filtro[filtro.Length - 1].vOperador = ">";
            }
            else if (vTp_status.Trim().ToUpper().Equals("V"))
            {
                Array.Resize(ref filtro, filtro.Length + 3);
                filtro[filtro.Length - 3].vNM_Campo = "isNull(a.st_registro, 'A')";
                filtro[filtro.Length - 3].vVL_Busca = "'A'";
                filtro[filtro.Length - 3].vOperador = "=";
                filtro[filtro.Length - 2].vNM_Campo = "isNull(c.st_registro, 'A')";
                filtro[filtro.Length - 2].vVL_Busca = "('A', 'P')";
                filtro[filtro.Length - 2].vOperador = "IN";
                filtro[filtro.Length - 1].vNM_Campo = "c.DT_Vencto";
                filtro[filtro.Length - 1].vVL_Busca = "getDate()";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            return new TCD_LanParcela().BuscarRelGeralContas(filtro);
        }

        public static DataTable BuscaRelExtratoContas(string vDt_ini,
                                                      string vDt_fin,
                                                      string vCd_empresa,
                                                      string vCd_historico,
                                                      string vTp_mov,
                                                      string vTp_duplicata,
                                                      string vTp_relatorio,
                                                      string vCd_contager,
                                                      string vCd_clifor)
        {
            TpBusca[] filtro = new TpBusca[0];
            if ((vDt_ini.Trim() != string.Empty) && (vDt_ini.Trim() != "/  /       :"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_ini).ToString("yyyyMMdd HH:mm")) + "'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((vDt_fin.Trim() != string.Empty) && (vDt_fin.Trim() != "/  /       :"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_fin).ToString("yyyyMMdd HH:mm")) + "'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (vCd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
            }
            if (vCd_historico.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_historico.Trim() + "'";
            }
            if ((vTp_mov.Trim() != string.Empty) && (vTp_mov.Trim().ToUpper() != "T"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.tp_mov";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_mov.Trim() + "'";
            }
            if (vTp_duplicata.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_duplicata";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_duplicata.Trim() + "'";
            }
            if (vCd_clifor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_clifor.Trim() + "'";
            }
            return new TCD_LanParcela().BuscarRelExtratoContas(filtro, vTp_relatorio, vCd_contager);
        }

        public static string GravarParcela(TList_RegLanParcela lista, TObjetoBanco banco)
        {
            string retorno = string.Empty;
            lista.ForEach(p => retorno = GravarParcela(p, banco) + "|" + retorno);
            return retorno.Trim().Remove(retorno.Length - 1);
        }

        public static string GravarParcela(TRegistro_LanParcela val, TObjetoBanco banco)
        {
            TCD_LanParcela qtb_parcela = new TCD_LanParcela();
            qtb_parcela.Banco_Dados = banco;
            string retorno = qtb_parcela.GravaParcela(val);
            val.Cd_parcela = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_PARCELA"));
            return retorno;
        }

        public static string AlterarParcela(TRegistro_LanParcela val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanParcela qtb_parc = new TCD_LanParcela();
            try
            {
                if (banco == null)
                    st_transacao = qtb_parc.CriarBanco_Dados(true);
                else
                    qtb_parc.Banco_Dados = banco;
                //Alterar parcelas
                string retorno = qtb_parc.GravaParcela(val);
                //Alterar boletos
                CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar(val.Cd_empresa,
                                                                    val.Nr_lancto.Value,
                                                                    val.Cd_parcela.Value,
                                                                    decimal.Zero,
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
                                                                    "'A'",
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    false,
                                                                    1,
                                                                    qtb_parc.Banco_Dados).ForEach(p =>
                                                                        {
                                                                            //Gerar Nova Instrução
                                                                            p.Instrucoes = CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.GerarInstrucoes(p.Tp_multa,
                                                                                                                                                        p.Pc_multa,
                                                                                                                                                        p.Nr_diasmulta,
                                                                                                                                                        p.Tp_jurodia,
                                                                                                                                                        p.Pc_jurodia,
                                                                                                                                                        p.Tp_desconto,
                                                                                                                                                        p.Pc_desconto,
                                                                                                                                                        p.Nr_diasdesconto,
                                                                                                                                                        p.St_protestarauto,
                                                                                                                                                        p.Nr_diasprotestar,
                                                                                                                                                        p.DS_Instrucoes,
                                                                                                                                                        p.Vl_documento,
                                                                                                                                                        p.Dt_vencimento.Value);
                                                                            qtb_parc.executarSql("update tb_cob_titulo set ds_instrucoes = '" + p.Instrucoes.Trim() + "', dt_alt = getdate() " +
                                                                                                 "where cd_empresa = '" + p.Cd_empresa.Trim() + "' and nr_lancto = " + p.Nr_lancto.Value.ToString() +
                                                                                                 " and cd_parcela = " + p.Cd_parcela.Value.ToString() + " and id_cobranca = " + p.Id_cobranca.Value.ToString(), null);
                                                                        });

                if (st_transacao)
                    qtb_parc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_parc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar parcela: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_parc.deletarBanco_Dados();
            }
        }

        public static void RecalcVlAtualParcelas(System.Collections.IList lParcelas,
                                                 string vOperador,
                                                 decimal vVl_cotacao)
        {
            foreach (TRegistro_LanParcela p in lParcelas)
            {
                if (p.Vl_cotacao.Equals(vVl_cotacao))
                    p.Vl_atual = Math.Round(p.Vl_parcela_padrao - p.Vl_liquidado, 2);
                else if (vOperador.Trim().Equals("*"))
                    p.Vl_atual = Math.Round(((p.Vl_parcela_padrao - p.Vl_liquidado) / p.Vl_cotacao) * vVl_cotacao, 2);
                else if (vOperador.Trim().Equals("/"))
                    if (vVl_cotacao > 0)
                        p.Vl_atual = Math.Round(((p.Vl_parcela_padrao - p.Vl_liquidado) * p.Vl_cotacao) / vVl_cotacao, 2);
                    else
                        p.Vl_atual = Math.Round((p.Vl_parcela_padrao - p.Vl_liquidado) / p.Vl_cotacao, 2);
            }
        }
    }

    public class TCN_LanLiquidacao
    {
        private static decimal CalcVlDifCamb(decimal vVl_liquidar,
                                             decimal vVl_atual,
                                             decimal vVl_difcamb,
                                             string vCd_moeda,
                                             string vCd_moedaresult)
        {
            if (vCd_moeda.Trim().Equals(vCd_moedaresult.Trim()))
                return 0;
            else
            {
                if (vVl_liquidar < vVl_atual)
                {
                    //Calcular percentual de representatividade
                    decimal perc = Math.Round(vVl_liquidar * 100 / vVl_atual, 2);
                    //Calcular valor da diferenca cambial ativa em relação ao percentual
                    if (vVl_difcamb > 0)
                        if (vVl_atual > 0)
                            return Math.Round(vVl_difcamb * perc / 100, 2);
                        else
                            return vVl_difcamb;
                    else
                        return vVl_difcamb;
                }
                else
                    return vVl_difcamb;
            }
        }

        private static void CalcularVlDifCamb(List<TRegistro_LanParcela> lParcelas,
                                              TRegistro_LanLiquidacao Liquidacao)
        {
            Liquidacao.Cvl_diferencacambialativa = 0;
            Liquidacao.Cvl_diferencacambialpassiva = 0;
            if (Liquidacao.lCotacao.Cd_moeda.Trim().Equals(Liquidacao.lCotacao.Cd_moedaresult.Trim()))
                return;
            else
            {
                decimal vl_saldo_liquidar = Liquidacao.Cvl_aliquidar_padrao - Liquidacao.cVl_juroliquidar;
                foreach (TRegistro_LanParcela p in lParcelas)
                {
                    if (vl_saldo_liquidar <= 0)
                        return;
                    else
                        if (vl_saldo_liquidar >= p.Vl_atual)
                    {
                        Liquidacao.Cvl_diferencacambialativa += Math.Round(p.cVl_DifCamb_Ativa, 2);
                        Liquidacao.Cvl_diferencacambialpassiva += Math.Round(p.cVl_DifCamb_Passiva, 2);
                    }
                    else
                    {
                        //Calcular percentual de representatividade
                        decimal perc = Math.Round(vl_saldo_liquidar * 100 / p.Vl_atual, 2);
                        //Calcular valor da difenrenca cambial ativa em relação ao percentual
                        if (p.cVl_DifCamb_Ativa > 0)
                            if (p.Vl_atual > 0)
                                Liquidacao.Cvl_diferencacambialativa += Math.Round(p.cVl_DifCamb_Ativa * perc / 100, 2);
                        //Calcular valor da difenrenca cambial passiva em relação ao percentual
                        if (p.cVl_DifCamb_Passiva > 0)
                            if (p.Vl_atual > 0)
                                Liquidacao.Cvl_diferencacambialpassiva += Math.Round(p.cVl_DifCamb_Passiva * perc / 100, 2);
                    }
                    vl_saldo_liquidar -= p.Vl_atual;
                }
            }
        }

        public static TList_RegLanLiquidacao Busca(string vCD_Empresa,
                                                   decimal vNr_lancto,
                                                   decimal vCD_parcela,
                                                   decimal vId_liquid,
                                                   string vCd_contager,
                                                   decimal vCd_lanctocaixa,
                                                   decimal vCd_lanctocaixa_juro,
                                                   decimal vCd_lanctocaixa_desc,
                                                   decimal vCd_lanctocaixa_dcamb_AT,
                                                   decimal vCd_lanctocaixa_dcamb_PA,
                                                   decimal vCd_lanctocaixa_trocoCH,
                                                   decimal vCd_lanctocaixa_perdaDUP,
                                                   bool vOperadorLanctoCaixa,
                                                   string vSt_registro,
                                                   int vTop,
                                                   string vNm_campo,
                                                   TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (vNr_lancto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_lancto.ToString();
            }
            if (vCD_parcela > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCD_parcela.ToString();
            }
            if (vId_liquid > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_liquid";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_liquid.ToString();
            }
            if (!string.IsNullOrEmpty(vCd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_contager.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if ((vCd_lanctocaixa > decimal.Zero) &&
                (vCd_lanctocaixa_desc > decimal.Zero) &&
                (vCd_lanctocaixa_juro > decimal.Zero) &&
                (vCd_lanctocaixa_dcamb_AT > decimal.Zero) &&
                (vCd_lanctocaixa_dcamb_PA > decimal.Zero) &&
                (vCd_lanctocaixa_trocoCH > decimal.Zero) &&
                (vCd_lanctocaixa_perdaDUP > decimal.Zero) &&
                vOperadorLanctoCaixa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "((a.cd_lanctocaixa = " + vCd_lanctocaixa.ToString() + ")or" +
                                                      "(a.cd_lanctocaixa_juro = " + vCd_lanctocaixa_juro.ToString() + ")or" +
                                                      "(a.cd_lanctocaixa_desc = " + vCd_lanctocaixa_desc.ToString() + ") or " +
                                                      "(a.cd_lanctocaixa_dcamb_at = " + vCd_lanctocaixa_dcamb_AT.ToString() + ") or " +
                                                      "(a.cd_lanctocaixa_dcamb_pa = " + vCd_lanctocaixa_dcamb_PA.ToString() + ") or " +
                                                      "(a.cd_lanctocaixa_trocoCH = " + vCd_lanctocaixa_trocoCH.ToString() + ") or " +
                                                      "(a.cd_lanctocaixa_perdaDup = " + vCd_lanctocaixa_perdaDUP.ToString() + "))";
                filtro[filtro.Length - 1].vOperador = string.Empty;
            }
            else
            {
                if (vCd_lanctocaixa > decimal.Zero)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                    filtro[filtro.Length - 1].vVL_Busca = vCd_lanctocaixa.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vCd_lanctocaixa_desc > decimal.Zero)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa_desc";
                    filtro[filtro.Length - 1].vVL_Busca = vCd_lanctocaixa_desc.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vCd_lanctocaixa_juro > decimal.Zero)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa_juro";
                    filtro[filtro.Length - 1].vVL_Busca = vCd_lanctocaixa_juro.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vCd_lanctocaixa_dcamb_AT > decimal.Zero)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa_dcamb_at";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = vCd_lanctocaixa_dcamb_AT.ToString();
                }
                if (vCd_lanctocaixa_dcamb_PA > decimal.Zero)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa_dcamb_pa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = vCd_lanctocaixa_dcamb_PA.ToString();
                }
                if (vCd_lanctocaixa_perdaDUP > decimal.Zero)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa_perdaDup";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = vCd_lanctocaixa_perdaDUP.ToString();
                }
                if (vCd_lanctocaixa_trocoCH > decimal.Zero)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa_trocoCH";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = vCd_lanctocaixa_trocoCH.ToString();
                }
            }
            if (!string.IsNullOrEmpty(vSt_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isNull(a.St_Registro, 'A')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_registro.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new TCD_LanLiquidacao(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TRegistro_LanCaixa PreparaCaixa(string vCD_Contager,
                                                      string vCD_Empresa,
                                                      string vCD_Historico,
                                                      string vComplHistorico,
                                                      string vNM_Clifor,
                                                      DateTime? vDT_Lancto,
                                                      string vTp_mov,
                                                      string vNr_Docto,
                                                      string vST_Estorno,
                                                      string vST_Titulo,
                                                      decimal vVl_lancto)
        {
            TRegistro_LanCaixa reg = new TRegistro_LanCaixa();
            reg.Cd_ContaGer = vCD_Contager;
            reg.Cd_Empresa = vCD_Empresa;
            reg.Cd_Historico = vCD_Historico;
            reg.Cd_LanctoCaixa = 0;
            reg.ComplHistorico = vComplHistorico;
            reg.NM_Clifor = vNM_Clifor;
            reg.Dt_lancto = vDT_Lancto;
            reg.Nr_Docto = vNr_Docto;
            reg.St_Estorno = vST_Estorno;
            reg.St_Titulo = vST_Titulo;
            if (vTp_mov == "P")
                reg.Vl_PAGAR = vVl_lancto;
            else
                reg.Vl_RECEBER = vVl_lancto;

            return reg;
        }

        public static void LiquidarDupComCheque(TRegistro_LanTitulo rCheque,
                                                string Cd_contaliq,
                                                decimal Vl_liquidar,
                                                decimal Vl_desconto,
                                                TList_RegLanParcela lParc,
                                                TObjetoBanco banco)
        {
            bool st_transao = false;
            TCD_LanLiquidacao qtb_liq = new TCD_LanLiquidacao();
            try
            {
                if (banco == null)
                    st_transao = qtb_liq.CriarBanco_Dados(true);
                else qtb_liq.Banco_Dados = banco;
                if (rCheque.Nr_lanctocheque.Equals(decimal.Zero))
                {
                    //Gravar Cheque 
                    rCheque.St_lancarcaixa = true;
                    TCN_LanTitulo.GravarTitulo(rCheque, qtb_liq.Banco_Dados);
                }
                //Gerar Credito Titulo
                TCN_LanTitulo.GerarCreditoTitulo(new TRegistro_CreditoTitulo()
                {
                    Cd_empresa = rCheque.Cd_empresa,
                    Cd_contager = rCheque.Cd_contager,
                    Nr_lanctocheque = rCheque.Nr_lanctocheque,
                    Nr_cheque = rCheque.Nr_cheque,
                    Cd_banco = rCheque.Cd_banco,
                    Cd_empresacredito = rCheque.Cd_empresa,
                    Cd_contagercredito = Cd_contaliq,
                    Cd_historico = rCheque.Cd_historico,
                    Dt_lancto = rCheque.Dt_emissao,
                    Vl_titulo = rCheque.Vl_titulo
                }, qtb_liq.Banco_Dados);
                //Gravar liquidacao parcelas
                TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                rLiq.Cd_empresa = rCheque.Cd_empresa;
                string nr_docto = string.Empty;
                string virg = string.Empty;
                decimal saldo = rCheque.Vl_titulo;
                decimal juro = decimal.Zero;
                lParc.ForEach(p =>
                    {
                        if (saldo > decimal.Zero)
                        {
                            if (p.cVl_atual < saldo)
                                juro += p.Vl_juro;
                            else if (p.cVl_atual - p.Vl_juro < saldo)
                                juro += saldo - (p.cVl_atual - p.Vl_juro);
                            saldo -= p.cVl_atual;
                        }

                        nr_docto += virg + p.Nr_docto;
                        virg = ",";
                    });
                if (saldo > decimal.Zero)
                    juro += saldo;
                rLiq.Nr_docto = nr_docto;
                rLiq.Dt_Liquidacao = rCheque.Dt_emissao;
                rLiq.Cd_contager = Cd_contaliq;
                rLiq.Cd_historico = rCheque.Cd_historico;//Historico de quitacao
                rLiq.Cd_historico_desc = lParc[0].Cd_historico_desconto;
                rLiq.Cd_historico_juro = lParc[0].Cd_historico_juro;
                rLiq.Tp_mov = "P";
                rLiq.Cd_portador = rCheque.Cd_portador;
                rLiq.cVl_Atual = Vl_liquidar;
                rLiq.cVl_Nominal = lParc.Sum(p => p.Vl_atual);
                rLiq.Cvl_aliquidar_padrao = Vl_liquidar;
                rLiq.cVl_descontoconcedido = Vl_desconto;
                rLiq.cVl_juroliquidar = juro;
                TCN_LanLiquidacao.GravarLiquidacao(lParc,
                                                   rLiq,
                                                   null,
                                                   null,
                                                   null,
                                                   null,
                                                   qtb_liq.Banco_Dados);
                //Amarrar cheque x liquidacao
                lParc.ForEach(p => TCN_Titulo_x_Liquidacao.Gravar(new TRegistro_Titulo_x_Liquidacao()
                {
                    Cd_empresa = rCheque.Cd_empresa,
                    Cd_banco = rCheque.Cd_banco,
                    Nr_lanctocheque = rCheque.Nr_lanctocheque,
                    Nr_lancto = p.Nr_lancto,
                    Cd_parcela = p.Cd_parcela,
                    Id_liquid = rLiq.Id_liquid
                }, qtb_liq.Banco_Dados));
                if (st_transao)
                    qtb_liq.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transao)
                    qtb_liq.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar liquidação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transao)
                    qtb_liq.deletarBanco_Dados();
            }
        }

        public static string GravarLiquidacao(List<TRegistro_LanParcela> lParcelas,
                                              TRegistro_LanLiquidacao Liquidacao,
                                              List<TRegistro_LanTitulo> lTitulo,
                                              CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFatura,
                                              CamadaDados.PostoCombustivel.TList_CartaFrete lCartaFrete,
                                              ThreadEspera tEspera,
                                              TObjetoBanco bd)
        {
            bool st_transacao = false;
            TCD_LanLiquidacao qtb_liquid = new TCD_LanLiquidacao();
            if (bd == null)
            {
                if (tEspera != null)
                    tEspera.Msg("Criando conexão com o banco de dados...");
                st_transacao = qtb_liquid.CriarBanco_Dados(true);
            }
            else
                qtb_liquid.Banco_Dados = bd;
            try
            {
                if (lTitulo == null ? true :
                    lTitulo.Count < 2 ||
                    Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))
                {
                    string retorno = GravaLiquid(lParcelas,
                                                 Liquidacao,
                                                 lTitulo,
                                                 lFatura,
                                                 lCartaFrete,
                                                 tEspera,
                                                 qtb_liquid.Banco_Dados);
                    //Devolver Credito
                    DevolverCredito(Liquidacao, qtb_liquid.Banco_Dados);
                    //Processar Comissao
                    ProcessarComissao(Liquidacao, qtb_liquid.Banco_Dados);
                    if (st_transacao)
                        qtb_liquid.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                else
                {

                    //Fazer copia da lista de parcelas
                    TList_RegLanParcela lParc = new TList_RegLanParcela();
                    TList_RegLanParcela lP = new TList_RegLanParcela();
                    int cont = 0;
                    decimal somadesc = decimal.Zero;
                    decimal somajuro = decimal.Zero;
                    decimal somatrocoC = decimal.Zero;
                    decimal somatrocoD = decimal.Zero;
                    lParcelas.ForEach(p => lParc.Add(p));
                    lTitulo.ForEach(p =>
                        {
                            //Remover parcelas com status (L - Liquidada)
                            lP.ForEach(v =>
                                {
                                    if (v.St_registro.Trim().ToUpper().Equals("L"))
                                        lParc.RemoveAll(x => x.Cd_empresa == v.Cd_empresa &&
                                                            x.Nr_lancto == v.Nr_lancto &&
                                                            x.Cd_parcela == v.Cd_parcela);
                                    if (v.St_registro.Trim().ToUpper().Equals("P"))
                                    {
                                        //Buscar indice
                                        int i = lParc.FindIndex(x => x.Cd_empresa == v.Cd_empresa &&
                                                                x.Nr_lancto == v.Nr_lancto &&
                                                                x.Cd_parcela == v.Cd_parcela);
                                        //Remover da lista origem
                                        lParc.RemoveAt(i);
                                        //Adicionar item alterado no mesmo indice
                                        lParc.Insert(i, v);
                                    }
                                });
                            //Criar registro liquidacao com o valor do titulo
                            TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                            rLiq.Cd_empresa = Liquidacao.Cd_empresa;
                            rLiq.Nr_lancto = Liquidacao.Nr_lancto;
                            rLiq.Nr_docto = Liquidacao.Nr_docto;
                            rLiq.Dt_Liquidacao = Liquidacao.Dt_Liquidacao;
                            rLiq.Cd_contager = Liquidacao.Cd_contager;
                            rLiq.Cd_historico = Liquidacao.Cd_historico;
                            rLiq.Cd_historico_desc = Liquidacao.Cd_historico_desc;
                            rLiq.Cd_historico_juro = Liquidacao.Cd_historico_juro;
                            rLiq.Cd_historico_trocoCH = Liquidacao.Cd_historico_trocoCH;
                            rLiq.ComplHistorico = Liquidacao.ComplHistorico;
                            rLiq.Tp_mov = Liquidacao.Tp_mov;
                            rLiq.Cd_portador = Liquidacao.Cd_portador;
                            rLiq.Id_caixaoperacional = Liquidacao.Id_caixaoperacional;
                            //Ratear valor desconto concedido                         
                            decimal peso = Math.Round(p.Vl_titulo / (Liquidacao.Cvl_aliquidar_padrao - Liquidacao.cVl_descontoconcedido) * 100, 2);
                            decimal pesoTroco = Math.Round(p.Vl_titulo / (Liquidacao.Cvl_aliquidar_padrao - Liquidacao.cVl_descontoconcedido + Liquidacao.Vl_trocoCH + Liquidacao.Vl_trocoDH) * 100, 2);
                            decimal vl_desc = Math.Round(Liquidacao.cVl_descontoconcedido * peso / 100, 2);
                            if (cont.Equals(lTitulo.Count - 1))
                                if ((somadesc + vl_desc) != Liquidacao.cVl_descontoconcedido)
                                    vl_desc = Liquidacao.cVl_descontoconcedido - somadesc;
                            rLiq.cVl_descontoconcedido = vl_desc;
                            //Calcular Juro
                            decimal dif_juro = decimal.Zero;
                            if (cont.Equals(lTitulo.Count - 1))
                                if (lParc.Sum(v => v.Vl_juro) < Liquidacao.cVl_juroliquidar)
                                    dif_juro = Math.Round(Liquidacao.cVl_juroliquidar - lParcelas.Sum(v => v.Vl_juro), 2);
                            decimal saldo = decimal.Zero;
                            decimal vl_juro = decimal.Zero;
                            lP = new TList_RegLanParcela();
                            for (int i = 0; i < lParc.Count; i++)
                                if (saldo < (p.Vl_titulo + vl_desc))
                                {
                                    if (lParc[i].cVl_atual - lParc[i].Vl_juro < p.Vl_titulo - saldo)
                                        if (lParc[i].Vl_juro < (p.Vl_titulo - saldo) - (lParc[i].cVl_atual - lParc[i].Vl_juro))
                                            vl_juro += lParc[i].Vl_juro;
                                        else vl_juro += lParc[i].Vl_juro - (p.Vl_titulo - saldo) - (lParc[i].cVl_atual - lParc[i].Vl_juro);
                                    saldo += lParc[i].cVl_atual;
                                    lP.Add(lParc[i]);
                                }
                                else
                                    break;
                            rLiq.cVl_juroliquidar = vl_juro + dif_juro;
                            //Calculando troco cheque proporcional
                            decimal vl_troco = Math.Round(Liquidacao.Vl_trocoCH * pesoTroco / 100, 2);
                            if (cont.Equals(lTitulo.Count - 1))
                                if ((somatrocoC + vl_troco) != Liquidacao.Vl_trocoCH)
                                    vl_troco = Liquidacao.Vl_trocoCH - somatrocoC;
                            rLiq.Vl_trocoCH = vl_troco;
                            Liquidacao.lChTroco.ForEach(x => rLiq.lChTroco.Add(x));
                            //Calculando troco dinheiro proporcional
                            vl_troco = Math.Round(Liquidacao.Vl_trocoDH * pesoTroco / 100, 2);
                            if (cont.Equals(lTitulo.Count - 1))
                                if ((somatrocoD + vl_troco) != Liquidacao.Vl_trocoDH)
                                    vl_troco = Liquidacao.Vl_trocoDH - somatrocoD;
                            rLiq.Vl_trocoDH = vl_troco;
                            //Adiantamento sera amarrado ao ultimo cheque
                            if (cont.Equals(lTitulo.Count - 1))
                                rLiq.Vl_adto = Liquidacao.Vl_adto;
                            rLiq.cVl_Atual = p.Vl_titulo + vl_desc - rLiq.cVl_juroliquidar;
                            rLiq.cVl_Nominal = p.Vl_titulo + vl_desc - rLiq.cVl_juroliquidar;
                            rLiq.Cvl_aliquidar_padrao = p.Vl_titulo + vl_desc - rLiq.Vl_trocoCH - rLiq.Vl_trocoDH;
                            somatrocoC += rLiq.Vl_trocoCH;
                            somatrocoD += rLiq.Vl_trocoDH;
                            GravaLiquid(lP,
                                        rLiq,
                                        new TList_RegLanTitulo() { p },
                                        lFatura,
                                        lCartaFrete,
                                        tEspera,
                                        qtb_liquid.Banco_Dados);
                            //Processar Comissao
                            ProcessarComissao(rLiq, qtb_liquid.Banco_Dados);
                            cont++;
                            somadesc += rLiq.cVl_descontoconcedido;
                            somajuro += rLiq.cVl_juroliquidar;
                        });
                    if (Liquidacao.cVl_adiantamento > decimal.Zero)
                    {
                        lP = new TList_RegLanParcela();
                        //Atualizar Parcela
                        //Buscar parcela novamente com os dados atualizados
                        lParcelas.ForEach(p =>
                        {
                            p = TCN_LanParcela.BuscarParcela(p.Cd_empresa,
                                                             p.Nr_lancto.ToString(),
                                                             p.Cd_parcela.ToString(),
                                                             qtb_liquid.Banco_Dados);
                            if (p.St_registro.Trim().ToUpper() != "L")
                            {
                                System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
                                hs.Add("@P_CD_EMPRESA", p.Cd_empresa);
                                hs.Add("@P_NR_LANCTO", p.Nr_lancto);
                                hs.Add("@P_CD_PARCELA", p.Cd_parcela);
                                hs.Add("@P_DATA_ATUAL", Liquidacao.Dt_Liquidacao.Value);
                                hs.Add("@P_ST_CALCMOEDAPADRAO", "N");
                                try
                                {
                                    p.Vl_atual = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(new CamadaDados.TDataQuery(qtb_liquid.Banco_Dados).executarProc("STP_FIN_CALC_ATUAL", hs), "@@VL_RET"));
                                    p.cVl_atual = p.Vl_atual;
                                }
                                catch
                                { }

                                lP.Add(p);
                            }
                        });
                        Liquidacao.cVl_descontoconcedido -= somadesc;
                        Liquidacao.cVl_juroliquidar -= somajuro;
                        Liquidacao.Cvl_aliquidar_padrao = Liquidacao.cVl_adiantamento;
                        GravaLiquid(lP, Liquidacao, null, null, null, tEspera, qtb_liquid.Banco_Dados);
                        //Devolver Credito
                        DevolverCredito(Liquidacao, qtb_liquid.Banco_Dados);
                        //Processar Comissao
                        ProcessarComissao(Liquidacao, qtb_liquid.Banco_Dados);
                    }
                    if (st_transacao)
                        qtb_liquid.Banco_Dados.Commit_Tran();
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liquid.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar liquidação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_liquid.deletarBanco_Dados();
            }
        }

        public static void LiquidarListaContasPagar(TList_RegLanParcela lista,
                                                    string Cd_contager,
                                                    string Cd_portador,
                                                    DateTime? Dt_liquidacao,
                                                    ref System.ComponentModel.BackgroundWorker back,
                                                    ref string Nome,
                                                    TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanLiquidacao qtb_liquid = new TCD_LanLiquidacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_liquid.CriarBanco_Dados(true);
                else
                    qtb_liquid.Banco_Dados = banco;
                int cont = 0;
                for (int i = 0; lista.Count > i; i++)
                {
                    if (lista[i].St_processar)
                    {
                        Nome = "GERANDO LIQUIDAÇÃO : " + lista[i].Nm_clifor;
                        //Criar o objeto liquidacao
                        TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                        rLiq.Cd_contager = Cd_contager;
                        rLiq.Cd_empresa = lista[i].Cd_empresa;
                        if (lista[i].Cd_historico.Trim().Equals(string.Empty))
                            throw new Exception("Histórico " + lista[i].Cd_historico.Trim() + " - " + lista[i].Ds_historico.Trim() + " não tem histórico de quitação configurado.");
                        rLiq.Cd_historico = lista[i].Cd_historico;
                        rLiq.Cd_historico_desc = lista[i].Cd_historico_desconto;
                        rLiq.Cd_historico_juro = lista[i].Cd_historico_juro;
                        rLiq.Cd_parcela = lista[i].Cd_parcela;
                        rLiq.Cd_portador = Cd_portador;
                        rLiq.cVl_Nominal = lista[i].Vl_atual;
                        rLiq.Cvl_aliquidar_padrao = lista[i].Vl_atual;
                        rLiq.cVl_Atual = lista[i].Vl_atual;
                        rLiq.Dt_Liquidacao = Dt_liquidacao ?? CamadaDados.UtilData.Data_Servidor();
                        rLiq.Id_liquid = null;
                        rLiq.Nr_docto = lista[i].Nr_docto;
                        rLiq.Nr_lancto = lista[i].Nr_lancto;
                        rLiq.Tp_mov = lista[i].Tp_mov;
                        //Chamar procedimento liquidar
                        TList_RegLanParcela lPar = new TList_RegLanParcela();
                        lPar.Add(lista[i]);
                        TCN_LanLiquidacao.GravarLiquidacao(lPar,
                                                           rLiq,
                                                           null,
                                                           null,
                                                           null,
                                                           null,
                                                           qtb_liquid.Banco_Dados);
                        back.ReportProgress(cont++);
                    }
                }
                if (st_transacao)
                    qtb_liquid.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (banco == null)
                    qtb_liquid.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar liquidação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_liquid.deletarBanco_Dados();
            }
        }

        public static void ProcessarComissao(TRegistro_LanLiquidacao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPedido_Item qtb_item = new TCD_LanPedido_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                //Verificar se ja existe comissao
                CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao lComissao =
                    new CamadaDados.Faturamento.Comissao.TCD_Fechamento_Comissao(qtb_item.Banco_Dados).Select(
                        new TpBusca[]{
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = val.Nr_lancto.ToString()
                            },
                            new TpBusca(){
                                vNM_Campo = "a.Id_liquid",
                                vOperador = "=",
                                vVL_Busca = val.Id_liquid != null ? val.Id_liquid.ToString() : "a.Id_liquid"
                            },
                            new TpBusca(){
                                vNM_Campo = "a.Cd_parcela",
                                vOperador = "=",
                                vVL_Busca = val.Cd_parcela.ToString()
                            }

                        }, 0, string.Empty);
                if (lComissao.Count > 0)
                {
                    lComissao.ForEach(p =>
                    {
                        //Verificar se comissao possui faturamento
                        if (new CamadaDados.Faturamento.Comissao.TCD_Comissao_X_Duplicata(qtb_item.Banco_Dados).BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                       vNM_Campo = string.Empty,
                                       vOperador = "exists",
                                       vVL_Busca = "(select 1 from TB_FAT_Fechamento_Comissao x " +
                                                    "where a.cd_empresa = x.cd_empresa " +
                                                    "and a.id_comissao = x.id_comissao " +
                                                    "and x.cd_empresa = " + val.Cd_empresa +
                                                    "and x.nr_lancto = " + val.Nr_lancto +
                                                    "and x.Cd_parcela = " + val.Cd_parcela +
                                                    "and x.Id_liquid = " + val.Id_liquid + ")"
                                    }
                            }, "1") == null)
                            Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_item.Banco_Dados);
                        else
                            throw new Exception("Item possui comissão faturada. Obrigatorio antes cancelar faturamento comissão.");
                    });
                }
                object cd_vendedor = new TCD_Pedido(qtb_item.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vOperador = "exists",
                            vVL_Busca = "( select 1 from tb_fat_notafiscal x "+
                                        " inner join TB_FAT_NotaFiscal_X_Duplicata y on y.cd_empresa = x.cd_empresa "+
                                        " and y.nr_lanctofiscal =  x.nr_lanctofiscal and a.nr_pedido = x.Nr_Pedido "+
                                        "where y.nr_lanctoduplicata = " + val.Nr_lancto+ " and y.cd_empresa = " + val.Cd_empresa + ")"
                        }
                    }, "a.cd_vendedor");

                if (cd_vendedor == null ? false : !string.IsNullOrEmpty(cd_vendedor.ToString()))
                    //Verificar se o item e servico e se vendedor e comissionado sobre recebimento
                    if ((new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_Empresa(qtb_item.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_vendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_vendedor.ToString().Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo= "isnull(a.St_comrecebimento, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                }
                            }, "1") != null))
                    {
                        if (!string.IsNullOrEmpty(cd_vendedor.ToString()))
                        {
                            decimal vl_basecalc = (val.Vl_LiquidadoTotal_padrao);
                            decimal pc_comissao = decimal.Zero;
                            string tp_comissao = "P";
                            decimal vl_comissao = CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.CalcularComissao(val.Cd_empresa,
                                                                                                                              cd_vendedor.ToString(),
                                                                                                                              string.Empty,
                                                                                                                              string.Empty,
                                                                                                                              string.Empty,
                                                                                                                              decimal.Zero,
                                                                                                                              ref vl_basecalc,
                                                                                                                              ref pc_comissao,
                                                                                                                              ref tp_comissao,
                                                                                                                              qtb_item.Banco_Dados);
                            //Gravar fechamento comissao
                            CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Gravar(
                                new CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao()
                                {
                                    Cd_empresa = val.Cd_empresa,
                                    Cd_vendedor = cd_vendedor.ToString(),
                                    nr_lancto = val.Nr_lancto,
                                    cd_parcela = val.Cd_parcela,
                                    id_liquid = val.Id_liquid,
                                    Tp_comissao = tp_comissao,
                                    Pc_comissao = pc_comissao,
                                    Vl_basecalc = vl_basecalc,
                                    Vl_comissao = vl_comissao
                                }, qtb_item.Banco_Dados);
                            if (st_transacao)
                                qtb_item.Banco_Dados.Commit_Tran();
                        }
                    }

            }
            catch (Exception ex)
            {
                if (banco == null)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        private static void DevolverCredito(TRegistro_LanLiquidacao Liquidacao, TObjetoBanco banco)
        {
            if (Liquidacao.cVl_adiantamento > decimal.Zero)
            {
                //Buscar configuracao adiantamento
                TList_ConfigAdto lConfig = TCN_CadConfigAdto.Buscar(Liquidacao.Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    1,
                                                                    string.Empty,
                                                                    banco);
                if (lConfig.Count.Equals(0))
                    throw new Exception("Não existe configuração de adiantamento para a empresa " + Liquidacao.Cd_empresa.Trim() + "!");
                if (string.IsNullOrEmpty(lConfig[0].CD_Portador))
                    throw new Exception("Não existe portador configurado para devolução do adiantamento.");
                string cd_histdev = Liquidacao.Tp_mov.Trim().ToUpper().Equals("R") ? lConfig[0].Cd_historico_DEVADTO_R : lConfig[0].Cd_historico_DEVADTO_C;
                if (cd_histdev.Trim().Equals(string.Empty))
                    throw new Exception("Não existe configuração de histórico de devolução de adiantamento " +
                                    Liquidacao.Tp_mov.Trim().ToUpper() == "R" ? "recebido " : "concedido " +
                                    "para a empresa " + Liquidacao.Cd_empresa.Trim() + "!");
                decimal vl_devolver = Liquidacao.cVl_adiantamento > Liquidacao.Cvl_aliquidar_padrao ? Liquidacao.Cvl_aliquidar_padrao : Liquidacao.cVl_adiantamento;
                //Buscar saldo adiantamentos do clifor
                if (Liquidacao.lCred == null ? true : Liquidacao.lCred.Count.Equals(0))
                    Liquidacao.lCred = TCN_LanAdiantamento.Buscar(string.Empty,
                                                                  Liquidacao.Cd_empresa,
                                                                  Liquidacao.Cd_clifor,
                                                                  string.Empty,
                                                                  Liquidacao.Tp_mov.Trim().ToUpper().Equals("R") ? "'R'" : "'C'",
                                                                  string.Empty,
                                                                  decimal.Zero,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  decimal.Zero,
                                                                  decimal.Zero,
                                                                  false,
                                                                  false,
                                                                  true,
                                                                  string.Empty,
                                                                  false,
                                                                  true,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  0,
                                                                  string.Empty,
                                                                  banco);
                Liquidacao.lCred.FindAll(p => p.Vl_total_devolver > decimal.Zero).ForEach(p =>
                 {
                     if (vl_devolver > decimal.Zero)
                     {
                         decimal valor = vl_devolver > p.Vl_total_devolver ? p.Vl_total_devolver : vl_devolver;
                         //Gravar caixa devolucao
                         TRegistro_LanCaixa rCaixa = PreparaCaixa(Liquidacao.Cd_contager,
                                                                   p.Cd_empresa,
                                                                   (Liquidacao.Tp_mov.Trim().ToUpper().Equals("R") ? lConfig[0].Cd_historico_DEVADTO_R : lConfig[0].Cd_historico_DEVADTO_C),
                                                                   "DEVOLUCAO DE ADIANTAMENTO: " + p.Id_adto.ToString(),
                                                                   Liquidacao.Nm_clifor,
                                                                   Liquidacao.Dt_Liquidacao,
                                                                   Liquidacao.Tp_mov.Trim().ToUpper().Equals("R") ? "P" : "R",
                                                                   "DEVADTO:" + p.Id_adto.ToString(),
                                                                   "N",
                                                                   "N",
                                                                   valor);
                         TCN_LanCaixa.GravaLanCaixa(rCaixa, banco);
                         //Gravar Adiantamento X Caixa
                         TCN_LanAdiantamentoXCaixa.Gravar(
                              new TRegistro_LanAdiantamentoXCaixa()
                              {
                                  Cd_contager = rCaixa.Cd_ContaGer,
                                  Cd_lanctocaixa = rCaixa.Cd_LanctoCaixa,
                                  Id_adto = p.Id_adto
                              }, banco);
                         //Gravar Liquidacao X AdtoCaixa
                         TCN_Liquidacao_X_Adto_Caixa.GravarLiquidacao_X_AdtoCaixa(
                              new TRegistro_Liquidacao_X_Adto_Caixa
                              {
                                  Cd_contager = rCaixa.Cd_ContaGer,
                                  Cd_lanctocaixa = rCaixa.Cd_LanctoCaixa,
                                  Cd_empresa = Liquidacao.Cd_empresa,
                                  Id_liquid = Liquidacao.Id_liquid,
                                  Nr_lancto = Liquidacao.Nr_lancto,
                                  Cd_parcela = Liquidacao.Cd_parcela,
                                  Id_adto = p.Id_adto,
                                  Vl_lancto = valor
                              }, banco);
                         //Gravar Centro Resultado devolucao do credito
                         if (ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                     p.Cd_empresa,
                                                                     banco).Trim().ToUpper().Equals("S"))
                         {
                             if (p.Tp_movimento.Trim().ToUpper().Equals("C") &&
                                 (!string.IsNullOrEmpty(lConfig[0].Cd_centroresult_DEVADTO_C)))
                             {
                                 string id_lan =
                                 CCustoLan.TCN_LanCCustoLancto.Gravar(
                                     new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                     {
                                         Cd_empresa = p.Cd_empresa,
                                         Cd_centroresult = lConfig[0].Cd_centroresult_DEVADTO_C,
                                         Vl_lancto = valor,
                                         Dt_lancto = Liquidacao.Dt_Liquidacao
                                     }, banco);
                                 //Gravar Emprestimo X CCusto
                                 TCN_Adiantamento_X_CCusto.Gravar(new TRegistro_Adiantamento_X_CCusto()
                                 {
                                     Id_adto = p.Id_adto,
                                     Id_ccustolan = decimal.Parse(id_lan)
                                 }, banco);
                             }
                             else if (p.Tp_movimento.Trim().ToUpper().Equals("R") &&
                                 (!string.IsNullOrEmpty(lConfig[0].Cd_centroresult_DEVADTO_R)))
                             {
                                 string id_lan =
                                 CCustoLan.TCN_LanCCustoLancto.Gravar(
                                     new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                     {
                                         Cd_empresa = p.Cd_empresa,
                                         Cd_centroresult = lConfig[0].Cd_centroresult_DEVADTO_R,
                                         Vl_lancto = valor,
                                         Dt_lancto = Liquidacao.Dt_Liquidacao
                                     }, banco);
                                 //Gravar Emprestimo X CCusto
                                 TCN_Adiantamento_X_CCusto.Gravar(new TRegistro_Adiantamento_X_CCusto()
                                 {
                                     Id_adto = p.Id_adto,
                                     Id_ccustolan = decimal.Parse(id_lan)
                                 }, banco);
                             }
                         }
                         if (p.Tp_movimento.Trim().ToUpper().Equals("R"))
                             p.VL_Receber += valor;
                         else p.VL_Pagar += valor;
                         vl_devolver -= valor;
                     }
                 });
            }
        }

        private static string GravaLiquid(List<TRegistro_LanParcela> lParcelas,
                                          TRegistro_LanLiquidacao Liquidacao,
                                          List<TRegistro_LanTitulo> lTitulo,
                                          CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFatura,
                                          CamadaDados.PostoCombustivel.TList_CartaFrete lCartaFrete,
                                          ThreadEspera tEspera,
                                          TObjetoBanco vBanco) //colocar o parametro contabil
        {
            if (lParcelas.Count > 0)
            {
                bool st_transacao = false;
                TCD_LanLiquidacao qtb_liquid = new TCD_LanLiquidacao();
                try
                {
                    if (vBanco == null)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Criando conexão com o banco de dados...");
                        st_transacao = qtb_liquid.CriarBanco_Dados(true);
                    }
                    else
                        qtb_liquid.Banco_Dados = vBanco;
                    string retorno = string.Empty;
                    string LanCX = string.Empty;
                    string LanCXJuro = string.Empty;
                    string LanCXDesc = string.Empty;
                    string LanCXDCambAT = string.Empty;
                    string LanCXDCambPA = string.Empty;
                    string LanCXTrocoCH = string.Empty;
                    string LanCXTrocoDH = string.Empty;
                    string LanCXAdtoCH = string.Empty;
                    string LanTit = string.Empty;
                    string LanLiq = string.Empty;
                    //Verifica se a data do caixa nao esta fechada para a a data da liquidacao
                    if (TCN_LanCaixa.DataCaixa(Liquidacao.Cd_contager, Liquidacao.Dt_Liquidacao, qtb_liquid.Banco_Dados))
                    {
                        //Gravar Caixa da Liquidação
                        if ((Liquidacao.Cvl_aliquidar_padrao - Liquidacao.cVl_juroliquidar) > 0)
                        {
                            if (tEspera != null)
                                tEspera.Msg("Gravando caixa da liquidação...");
                            CalcularVlDifCamb(lParcelas, Liquidacao);
                            TRegistro_LanCaixa regcx = new TRegistro_LanCaixa();
                            if (Liquidacao.Tp_mov.Trim().ToUpper().Equals("P"))
                            {
                                if (Liquidacao.Cvl_diferencacambialativa > 0)
                                    regcx = PreparaCaixa(Liquidacao.Cd_contager,
                                                         Liquidacao.Cd_empresa,
                                                         Liquidacao.Cd_historico,
                                                         Liquidacao.ComplHistorico,
                                                         lParcelas[0].Nm_clifor,
                                                         Liquidacao.Dt_Liquidacao,
                                                         Liquidacao.Tp_mov,
                                                         Liquidacao.Nr_docto,
                                                         "N",
                                                         ((lTitulo != null) && (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))) ? "S" : "N",
                                                         (Liquidacao.Cvl_aliquidar_padrao - Liquidacao.cVl_juroliquidar) + Liquidacao.Cvl_diferencacambialativa);
                                else if (Liquidacao.Cvl_diferencacambialpassiva > 0)
                                    regcx = PreparaCaixa(Liquidacao.Cd_contager,
                                                         Liquidacao.Cd_empresa,
                                                         Liquidacao.Cd_historico,
                                                         Liquidacao.ComplHistorico,
                                                         lParcelas[0].Nm_clifor,
                                                         Liquidacao.Dt_Liquidacao,
                                                         Liquidacao.Tp_mov,
                                                         Liquidacao.Nr_docto,
                                                         "N",
                                                         ((lTitulo != null) && (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))) ? "S" : "N",
                                                         (Liquidacao.Cvl_aliquidar_padrao - Liquidacao.cVl_juroliquidar - Liquidacao.Cvl_diferencacambialpassiva));
                                else
                                {
                                    regcx = PreparaCaixa(Liquidacao.Cd_contager,
                                                         Liquidacao.Cd_empresa,
                                                         Liquidacao.Cd_historico,
                                                         Liquidacao.ComplHistorico,
                                                         lParcelas[0].Nm_clifor,
                                                         Liquidacao.Dt_Liquidacao,
                                                         Liquidacao.Tp_mov,
                                                         Liquidacao.Nr_docto,
                                                         "N",
                                                         ((lTitulo != null) && (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))) ? "S" : "N",
                                                         (Liquidacao.Cvl_aliquidar_padrao - Liquidacao.cVl_juroliquidar));
                                }
                            }
                            else if (Liquidacao.Tp_mov.Trim().ToUpper().Equals("R"))
                            {
                                if (Liquidacao.Cvl_diferencacambialativa > 0)
                                    regcx = PreparaCaixa(Liquidacao.Cd_contager,
                                                         Liquidacao.Cd_empresa,
                                                         Liquidacao.Cd_historico,
                                                         Liquidacao.ComplHistorico,
                                                         lParcelas[0].Nm_clifor,
                                                         Liquidacao.Dt_Liquidacao,
                                                         Liquidacao.Tp_mov,
                                                         Liquidacao.Nr_docto,
                                                         "N",
                                                         ((lTitulo != null) && (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))) ? "S" : "N",
                                                         (Liquidacao.Cvl_aliquidar_padrao - Liquidacao.cVl_juroliquidar - Liquidacao.Cvl_diferencacambialativa));
                                else if (Liquidacao.Cvl_diferencacambialpassiva > 0)
                                    regcx = PreparaCaixa(Liquidacao.Cd_contager,
                                                         Liquidacao.Cd_empresa,
                                                         Liquidacao.Cd_historico,
                                                         Liquidacao.ComplHistorico,
                                                         lParcelas[0].Nm_clifor,
                                                         Liquidacao.Dt_Liquidacao, Liquidacao.Tp_mov,
                                                         Liquidacao.Nr_docto,
                                                         "N",
                                                         ((lTitulo != null) && (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))) ? "S" : "N",
                                                         (Liquidacao.Cvl_aliquidar_padrao - Liquidacao.cVl_juroliquidar) + Liquidacao.Cvl_diferencacambialpassiva);
                                else
                                {
                                    regcx = PreparaCaixa(Liquidacao.Cd_contager,
                                                         Liquidacao.Cd_empresa,
                                                         Liquidacao.Cd_historico,
                                                         Liquidacao.ComplHistorico,
                                                         lParcelas[0].Nm_clifor,
                                                         Liquidacao.Dt_Liquidacao, Liquidacao.Tp_mov,
                                                         Liquidacao.Nr_docto,
                                                         "N",
                                                         ((lTitulo != null) && (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))) ? "S" : "N",
                                                         (Liquidacao.Cvl_aliquidar_padrao - Liquidacao.cVl_juroliquidar + Liquidacao.Vl_trocoCH));
                                }
                            }
                            LanCX = TCN_LanCaixa.GravaLanCaixa(regcx, qtb_liquid.Banco_Dados);
                            Liquidacao.Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCX, "@P_CD_LANCTOCAIXA"));

                            //PROCESSAR CONTABILIDADE
                        }
                        //Gravar caixa do juro
                        if (Liquidacao.cVl_juroliquidar > decimal.Zero)
                        {
                            if (tEspera != null)
                                tEspera.Msg("Gravando caixa do juro...");
                            TRegistro_LanCaixa regcx = new TRegistro_LanCaixa();
                            regcx = PreparaCaixa(Liquidacao.Cd_contager,
                                                 Liquidacao.Cd_empresa,
                                                 Liquidacao.Cd_historico_juro,
                                                 Liquidacao.ComplHistorico,
                                                 lParcelas[0].Nm_clifor,
                                                 Liquidacao.Dt_Liquidacao,
                                                 Liquidacao.Tp_mov,
                                                 Liquidacao.Nr_docto,
                                                 "N",
                                                 ((lTitulo != null) && (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))) ? "S" : "N",
                                                 Liquidacao.cVl_juroliquidar);
                            LanCXJuro = TCN_LanCaixa.GravaLanCaixa(regcx, qtb_liquid.Banco_Dados);
                            Liquidacao.Cd_lanctocaixa_Juro = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXJuro, "@P_CD_LANCTOCAIXA"));
                            //Gravar Centro Resultado Juro
                            if (ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                       regcx.Cd_Empresa,
                                                                       qtb_liquid.Banco_Dados).Trim().ToUpper().Equals("S"))
                            {
                                //Verificar se historico possui centro resultado cadastrado
                                object obj = new TCD_CentroResult_X_Historico(qtb_liquid.Banco_Dados).BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_historico",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + regcx.Cd_Historico.Trim() + "'"
                                                    }
                                                }, "a.cd_centroresult");
                                if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                                {
                                    string ccusto = CCustoLan.TCN_LanCCustoLancto.Gravar(
                                                    new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                    {
                                                        Cd_empresa = regcx.Cd_Empresa,
                                                        Cd_centroresult = obj.ToString(),
                                                        Vl_lancto = regcx.Vl_PAGAR > decimal.Zero ? regcx.Vl_PAGAR : regcx.Vl_RECEBER,
                                                        Dt_lancto = regcx.Dt_lancto,
                                                        Tp_registro = "A"
                                                    }, qtb_liquid.Banco_Dados);
                                    //Centro Custo X Caixa
                                    TCN_Caixa_X_CCusto.Gravar(new TRegistro_Caixa_X_CCusto()
                                    {
                                        Cd_contager = regcx.Cd_ContaGer,
                                        Cd_lanctocaixa = regcx.Cd_LanctoCaixa,
                                        Id_ccustolanstr = ccusto
                                    }, qtb_liquid.Banco_Dados);
                                }
                            }
                            //PROCESSAR CONTABILIDADE
                        }
                        //Gravar caixa do desconto
                        if (Liquidacao.cVl_descontoconcedido > decimal.Zero)
                        {
                            if (tEspera != null)
                                tEspera.Msg("Gravando caixa do desconto...");
                            TRegistro_LanCaixa regcx = new TRegistro_LanCaixa();
                            string tpmov = string.Empty;
                            if (Liquidacao.Tp_mov == "P") tpmov = "R"; else tpmov = "P";
                            regcx = PreparaCaixa(Liquidacao.Cd_contager,
                                                 Liquidacao.Cd_empresa,
                                                 Liquidacao.Cd_historico_desc,
                                                 Liquidacao.ComplHistorico,
                                                 lParcelas[0].Nm_clifor,
                                                 Liquidacao.Dt_Liquidacao,
                                                 tpmov,
                                                 Liquidacao.Nr_docto,
                                                 "N",
                                                 ((lTitulo != null) && (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))) ? "S" : "N",
                                                 Liquidacao.cVl_descontoconcedido);
                            LanCXDesc = TCN_LanCaixa.GravaLanCaixa(regcx, qtb_liquid.Banco_Dados);
                            Liquidacao.Cd_lanctocaixa_Desc = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXDesc, "@P_CD_LANCTOCAIXA"));
                            //Gravar Centro Resultado Juro
                            if (ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                       regcx.Cd_Empresa,
                                                                       qtb_liquid.Banco_Dados).Trim().ToUpper().Equals("S"))
                            {
                                //Verificar se historico possui centro resultado cadastrado
                                object obj = new TCD_CentroResult_X_Historico(qtb_liquid.Banco_Dados).BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_historico",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + regcx.Cd_Historico.Trim() + "'"
                                                    }
                                                }, "a.cd_centroresult");
                                if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                                {
                                    string ccusto = CCustoLan.TCN_LanCCustoLancto.Gravar(
                                                    new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                    {
                                                        Cd_empresa = regcx.Cd_Empresa,
                                                        Cd_centroresult = obj.ToString(),
                                                        Vl_lancto = regcx.Vl_PAGAR > decimal.Zero ? regcx.Vl_PAGAR : regcx.Vl_RECEBER,
                                                        Dt_lancto = regcx.Dt_lancto,
                                                        Tp_registro = "A"
                                                    }, qtb_liquid.Banco_Dados);
                                    //Centro Custo X Caixa
                                    TCN_Caixa_X_CCusto.Gravar(new TRegistro_Caixa_X_CCusto()
                                    {
                                        Cd_contager = regcx.Cd_ContaGer,
                                        Cd_lanctocaixa = regcx.Cd_LanctoCaixa,
                                        Id_ccustolanstr = ccusto
                                    }, qtb_liquid.Banco_Dados);
                                }
                            }
                            //PROCESSAR CONTABILIDADE
                        }
                        //Gravar Caixa Perda Duplicata
                        if (Liquidacao.cVl_perdaduplicata > decimal.Zero)
                        {
                            if (tEspera != null)
                                tEspera.Msg("Gravando caixa perda duplicata...");
                            TRegistro_LanCaixa regcx = new TRegistro_LanCaixa();
                            String tpmov = "";
                            if (Liquidacao.Tp_mov == "P") tpmov = "R"; else tpmov = "P";
                            regcx = PreparaCaixa(Liquidacao.Cd_contager,
                                                 Liquidacao.Cd_empresa,
                                                 Liquidacao.Cd_historicoperdaDup,
                                                 Liquidacao.ComplHistorico,
                                                 lParcelas[0].Nm_clifor,
                                                 Liquidacao.Dt_Liquidacao,
                                                 tpmov,
                                                 Liquidacao.Nr_docto,
                                                 "N",
                                                 ((lTitulo != null) && (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))) ? "S" : "N",
                                                 Liquidacao.cVl_perdaduplicata);
                            Liquidacao.Cd_lanctocaixa_perdaDup = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(TCN_LanCaixa.GravaLanCaixa(regcx, qtb_liquid.Banco_Dados), "@P_CD_LANCTOCAIXA"));
                            //PROCESSAR CONTABILIDADE
                        }
                        //Gravar Credito
                        if (Liquidacao.Vl_adto > decimal.Zero)
                        {
                            if (tEspera != null)
                                tEspera.Msg("Gravando adiantamento troco cheque...");
                            //Gravar adiantamento de caixa
                            string ret_adto = TCN_LanAdiantamento.Gravar(
                                                new TRegistro_LanAdiantamento()
                                                {
                                                    Cd_empresa = Liquidacao.Cd_empresa,
                                                    Cd_clifor = lParcelas[0].Cd_clifor,
                                                    CD_Endereco = string.Empty,
                                                    Ds_adto = "ADIANTAMENTO " + (Liquidacao.Tp_mov.Trim().ToUpper().Equals("R") ? "RECEBIDO" : "CONCEDIDO") + " COM CHEQUE",
                                                    Dt_lancto = Liquidacao.Dt_Liquidacao,
                                                    Tp_movimento = Liquidacao.Tp_mov.Trim().ToUpper().Equals("R") ? "R" : "C",
                                                    TP_Lancto = "T",//Frente Caixa
                                                    ST_ADTO = "A",//Aberto
                                                    Vl_adto = Liquidacao.Vl_adto
                                                }, qtb_liquid.Banco_Dados);
                            //Quitar adiantamento
                            TList_ConfigAdto lCfgAdto = TCN_CadConfigAdto.Buscar(Liquidacao.Cd_empresa,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            0,
                                                                                            string.Empty,
                                                                                            qtb_liquid.Banco_Dados);
                            if (lCfgAdto.Count > 0)
                            {
                                //Buscar adiantamento gravado
                                TList_LanAdiantamento lAdto = TCN_LanAdiantamento.Buscar(CamadaDados.TDataQuery.getPubVariavel(ret_adto, "@P_ID_ADTO"),
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     decimal.Zero,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     decimal.Zero,
                                                                                                     decimal.Zero,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     string.Empty,
                                                                                                     false,
                                                                                                     false,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     0,
                                                                                                     string.Empty,
                                                                                                     qtb_liquid.Banco_Dados);
                                if (lAdto.Count > 0)
                                {
                                    lAdto[0].List_Caixa.Add(new TRegistro_LanCaixa()
                                    {
                                        Cd_ContaGer = Liquidacao.Cd_contager,
                                        Cd_Empresa = Liquidacao.Cd_empresa,
                                        Cd_Historico = Liquidacao.Tp_mov.Trim().ToUpper().Equals("R") ? lCfgAdto[0].Cd_historico_ADTO_R : lCfgAdto[0].Cd_historico_ADTO_C,
                                        Cd_LanctoCaixa = decimal.Zero,
                                        ComplHistorico = "QUITAÇÃO ADIANTAMENTO " + (Liquidacao.Tp_mov.Trim().ToUpper().Equals("R") ? "RECEBIDO" : "CONCEDIDO") + " LIQUIDAÇÃO",
                                        Dt_lancto = Liquidacao.Dt_Liquidacao,
                                        Login = Utils.Parametros.pubLogin,
                                        Nr_Docto = "ADTO:" + lAdto[0].Id_adto.ToString(),
                                        St_Estorno = "N",
                                        St_Titulo = "N",
                                        Vl_PAGAR = Liquidacao.Tp_mov.Trim().ToUpper().Equals("R") ? decimal.Zero : Liquidacao.Vl_adto,
                                        Vl_RECEBER = Liquidacao.Tp_mov.Trim().ToUpper().Equals("R") ? Liquidacao.Vl_adto : decimal.Zero,
                                        NM_Clifor = lParcelas[0].Nm_clifor
                                    });
                                    LanCXAdtoCH = CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamentoXCaixa.Quitar_Adiantamento(lAdto[0], qtb_liquid.Banco_Dados);
                                    Liquidacao.Cd_lanctocaixa_adto = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(LanCXAdtoCH, "@P_CD_LANCTOCAIXA"));
                                }
                            }
                            else
                                throw new Exception("Não existe configuração de adiantamento para a empresa " + Liquidacao.Cd_empresa);
                        }
                        //Gravar Troco Cheque
                        if (Liquidacao.Vl_trocoCH > decimal.Zero)
                        {
                            if (tEspera != null)
                                tEspera.Msg("Gravando caixa troco cheque...");
                            TRegistro_LanCaixa regcx = new TRegistro_LanCaixa();
                            regcx = PreparaCaixa(Liquidacao.Cd_contager,
                                                 Liquidacao.Cd_empresa,
                                                 Liquidacao.Cd_historico_trocoCH,
                                                 Liquidacao.ComplHistorico,
                                                 lParcelas[0].Nm_clifor,
                                                 Liquidacao.Dt_Liquidacao,
                                                 "P",
                                                 Liquidacao.Nr_docto,
                                                 "N",
                                                 "S",
                                                 Liquidacao.Vl_trocoCH);
                            LanCXTrocoCH = TCN_LanCaixa.GravaLanCaixa(regcx, qtb_liquid.Banco_Dados);
                            Liquidacao.Cd_lanctocaixa_trocoCH = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(LanCXTrocoCH, "@P_CD_LANCTOCAIXA"));
                        }
                        //Troco Dinheiro
                        if (Liquidacao.Vl_trocoDH > decimal.Zero)
                        {
                            if (tEspera != null)
                                tEspera.Msg("Gravando caixa troco dinheiro...");
                            TRegistro_LanCaixa regcx = new TRegistro_LanCaixa();
                            regcx = PreparaCaixa(Liquidacao.Cd_contager,
                                                 Liquidacao.Cd_empresa,
                                                 Liquidacao.Cd_historico_trocoCH,
                                                 Liquidacao.ComplHistorico,
                                                 lParcelas[0].Nm_clifor,
                                                 Liquidacao.Dt_Liquidacao,
                                                 "P",
                                                 Liquidacao.Nr_docto,
                                                 "N",
                                                 "S",
                                                 Liquidacao.Vl_trocoDH);
                            LanCXTrocoDH = TCN_LanCaixa.GravaLanCaixa(regcx, qtb_liquid.Banco_Dados);
                            Liquidacao.Cd_lanctocaixa_trocoDH = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(LanCXTrocoDH, "@P_CD_LANCTOCAIXA"));
                        }
                        //PROCESSAR DIFERENCA CAMBIAL
                        if ((Liquidacao.Cvl_diferencacambialativa > 0) || (Liquidacao.Cvl_diferencacambialpassiva > 0))
                        {
                            //Buscar Historico de Diferenca Cambial no Tipo Duplicata
                            TList_CadTpDuplicata lTpDup = TCN_CadTpDuplicata.Buscar(lParcelas[0].Tp_duplicata,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    qtb_liquid.Banco_Dados);
                            if (lTpDup.Count > 0)
                            {
                                if (Liquidacao.Cvl_diferencacambialpassiva > 0)
                                {
                                    if (tEspera != null)
                                        tEspera.Msg("Gravando diferença cambial passiva...");
                                    //Diferenca Cambial Passiva
                                    if (lTpDup[0].Cd_historico_dcamb_passiva.Trim() != "")
                                    {
                                        TRegistro_LanCaixa regcx = new TRegistro_LanCaixa();
                                        regcx = PreparaCaixa(Liquidacao.Cd_contager, Liquidacao.Cd_empresa, lTpDup[0].Cd_historico_dcamb_passiva, "DIFERENCA CAMBIAL PASSIVA: " + Liquidacao.ComplHistorico, lParcelas[0].Nm_clifor,
                                            Liquidacao.Dt_Liquidacao, "P", Liquidacao.Nr_docto, "N", ((lTitulo != null) && (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))) ? "S" : "N", Math.Abs(Liquidacao.Cvl_diferencacambialpassiva));
                                        LanCXDCambPA = TCN_LanCaixa.GravaLanCaixa(regcx, qtb_liquid.Banco_Dados);
                                        Liquidacao.Cd_lanctocaixa_dcamb_pa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXDCambPA, "@P_CD_LANCTOCAIXA"));
                                    }
                                    else
                                        throw new Exception("Não existe histórico de diferença cambial passiva\r\n" +
                                                        "configurado para o tipo de duplicata " + lParcelas[0].Tp_duplicata.Trim() + "!");
                                }
                                if (Liquidacao.Cvl_diferencacambialativa > 0)
                                {
                                    if (tEspera != null)
                                        tEspera.Msg("Gravando diferença cambial ativa...");
                                    //Diferenca Cambial Ativa
                                    if (lTpDup[0].Cd_historico_dcamb_ativa.Trim() != "")
                                    {
                                        TRegistro_LanCaixa regcx = new TRegistro_LanCaixa();
                                        regcx = PreparaCaixa(Liquidacao.Cd_contager, Liquidacao.Cd_empresa, lTpDup[0].Cd_historico_dcamb_ativa, "DIFERENCA CAMBIAL ATIVA: " + Liquidacao.ComplHistorico, lParcelas[0].Nm_clifor, Liquidacao.Dt_Liquidacao,
                                                             "R", Liquidacao.Nr_docto, "N", ((lTitulo != null) && (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))) ? "S" : "N", Math.Abs(Liquidacao.Cvl_diferencacambialativa));
                                        LanCXDCambAT = TCN_LanCaixa.GravaLanCaixa(regcx, qtb_liquid.Banco_Dados);
                                        Liquidacao.Cd_lanctocaixa_dcamb_at = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXDCambAT, "@P_CD_LANCTOCAIXA"));
                                    }
                                    else
                                        throw new Exception("Não existe histórico de diferença cambial ativa\r\n" +
                                                        "configurado para o tipo de duplicata " + lParcelas[0].Tp_duplicata.Trim() + "\r\nFavor verificar o cadastro do tipo de duplicata!");
                                }
                            }
                            else
                                throw new Exception("Tipo de Duplicata Invalido!");
                        }
                    }
                    else
                        throw new Exception("Caixa já esta FECHADO para a DATA de lançamento desejada!");

                    //GRAVACAO DE LANÇAMENTO COM CHEQUE
                    //CHAMAR CAMADA DE NEGOCIO DO CHEQUE
                    if (lTitulo != null)
                        if (lTitulo.Count > 0)
                            if (!Liquidacao.St_tituloterceiro.Trim().ToUpper().Equals("S"))
                            {
                                if (tEspera != null)
                                    tEspera.Msg("Gravando cheques EMITIDOS/RECEBIDOS...");
                                lTitulo.ForEach(p =>
                                {
                                    p.Observacao = Liquidacao.ComplHistorico;
                                    LanTit = TCN_LanTitulo.GravarTitulo(p, qtb_liquid.Banco_Dados);
                                    if (!string.IsNullOrEmpty(LanTit))
                                        p.Nr_lanctocheque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanTit, "@P_NR_LANCTOCHEQUE"));
                                    else
                                        throw new Exception("Nao foi possível gravar o cheque! ");

                                    if (!string.IsNullOrEmpty(LanCX))
                                        TCN_TituloXCaixa.GravarTituloCaixa(
                                            new TRegistro_LanTituloXCaixa()
                                            {
                                                Cd_banco = p.Cd_banco,
                                                Cd_contager = p.Cd_contager,
                                                Cd_empresa = p.Cd_empresa,
                                                Nr_lanctocheque = p.Nr_lanctocheque,
                                                Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCX, "@P_CD_LANCTOCAIXA")),
                                                Tp_lancto = "OR",//Lancamento de origem do cheque, registro de caixa que deve ser compensado
                                                Tp_caixa = "S"
                                            },
                                            qtb_liquid.Banco_Dados);
                                    if (!string.IsNullOrEmpty(LanCXJuro))
                                        TCN_TituloXCaixa.GravarTituloCaixa(
                                            new TRegistro_LanTituloXCaixa()
                                            {
                                                Cd_banco = p.Cd_banco,
                                                Cd_contager = p.Cd_contager,
                                                Cd_empresa = p.Cd_empresa,
                                                Nr_lanctocheque = p.Nr_lanctocheque,
                                                Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXJuro, "@P_CD_LANCTOCAIXA")),
                                                Tp_lancto = "OR",//Lancamento de caixa de juro tambem entra com origem
                                                Tp_caixa = "S"
                                            },
                                            qtb_liquid.Banco_Dados);
                                    if (!string.IsNullOrEmpty(LanCXDesc))
                                        TCN_TituloXCaixa.GravarTituloCaixa(
                                            new TRegistro_LanTituloXCaixa()
                                            {
                                                Cd_banco = p.Cd_banco,
                                                Cd_contager = p.Cd_contager,
                                                Cd_empresa = p.Cd_empresa,
                                                Nr_lanctocheque = p.Nr_lanctocheque,
                                                Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXDesc, "@P_CD_LANCTOCAIXA")),
                                                Tp_lancto = "OR",//Entra como origem
                                                Tp_caixa = "S"
                                            }
                                            , qtb_liquid.Banco_Dados);
                                    if (!string.IsNullOrEmpty(LanCXDCambAT))
                                        TCN_TituloXCaixa.GravarTituloCaixa(
                                            new TRegistro_LanTituloXCaixa()
                                            {
                                                Cd_banco = p.Cd_banco,
                                                Cd_contager = p.Cd_contager,
                                                Cd_empresa = p.Cd_empresa,
                                                Nr_lanctocheque = p.Nr_lanctocheque,
                                                Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXDCambAT, "@P_CD_LANCTOCAIXA")),
                                                Tp_lancto = "OR",//Entra como origem
                                                Tp_caixa = "S"
                                            }
                                            , qtb_liquid.Banco_Dados);
                                    if (!string.IsNullOrEmpty(LanCXDCambPA))
                                        TCN_TituloXCaixa.GravarTituloCaixa(
                                            new TRegistro_LanTituloXCaixa()
                                            {
                                                Cd_banco = p.Cd_banco,
                                                Cd_contager = p.Cd_contager,
                                                Cd_empresa = p.Cd_empresa,
                                                Nr_lanctocheque = p.Nr_lanctocheque,
                                                Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXDCambPA, "@P_CD_LANCTOCAIXA")),
                                                Tp_lancto = "OR",//Origem
                                                Tp_caixa = "S"
                                            }
                                            , qtb_liquid.Banco_Dados);
                                });
                                if (!string.IsNullOrEmpty(LanCXTrocoCH))
                                    TCN_TituloXCaixa.GravarTituloCaixa(
                                            new TRegistro_LanTituloXCaixa()
                                            {
                                                Cd_banco = lTitulo[lTitulo.Count - 1].Cd_banco,
                                                Cd_contager = lTitulo[lTitulo.Count - 1].Cd_contager,
                                                Cd_empresa = lTitulo[lTitulo.Count - 1].Cd_empresa,
                                                Nr_lanctocheque = lTitulo[lTitulo.Count - 1].Nr_lanctocheque,
                                                Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXTrocoCH, "@P_CD_LANCTOCAIXA")),
                                                Tp_lancto = "OR",//Origem
                                                Tp_caixa = "S"
                                            }
                                            , qtb_liquid.Banco_Dados);
                                if (!string.IsNullOrEmpty(LanCXAdtoCH))
                                    TCN_TituloXCaixa.GravarTituloCaixa(
                                            new TRegistro_LanTituloXCaixa()
                                            {
                                                Cd_banco = lTitulo[lTitulo.Count - 1].Cd_banco,
                                                Cd_contager = lTitulo[lTitulo.Count - 1].Cd_contager,
                                                Cd_empresa = lTitulo[lTitulo.Count - 1].Cd_empresa,
                                                Nr_lanctocheque = lTitulo[lTitulo.Count - 1].Nr_lanctocheque,
                                                Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXAdtoCH, "@P_CD_LANCTOCAIXA")),
                                                Tp_lancto = "OR",//Origem
                                                Tp_caixa = "S"
                                            }
                                            , qtb_liquid.Banco_Dados);
                            }
                            else
                            {
                                if (tEspera != null)
                                    tEspera.Msg("Gravando repasse de cheques para terceiros...");
                                //Se for repasse de cheques para terceiro
                                lTitulo.ForEach(p =>
                                {
                                    //Compensar os cheques
                                    p.Cd_contager_destino = Liquidacao.Cd_contager;
                                    p.Dt_compensacao = Liquidacao.Dt_Liquidacao;
                                    TCN_LanTitulo.CompensarCheques(new TList_RegLanTitulo() { p }, qtb_liquid.Banco_Dados);

                                    //Gravar na tabela TB_FIN_Rastreab_ChTerceiro
                                    if (!string.IsNullOrEmpty(LanCX))
                                        TCN_Rastreab_ChTerceiro.GravarRastreab_ChTerceiro(
                                            new TRegistro_Rastreab_ChTerceiro()
                                            {
                                                Cd_banco = p.Cd_banco,
                                                Cd_clifor_origem = lParcelas[0].Cd_clifor,
                                                Cd_empresa = p.Cd_empresa,
                                                Nr_lanctocheque = p.Nr_lanctocheque,
                                                Cd_contager = Liquidacao.Cd_contager,
                                                Cd_lanctocaixa = Liquidacao.Cd_lanctocaixa,
                                                Tp_registro = (lParcelas[0].Tp_mov.Trim().ToUpper().Equals("P") ? "D" :
                                                              lParcelas[0].Tp_mov.Trim().ToUpper().Equals("R") ? "O" : string.Empty)
                                            }, qtb_liquid.Banco_Dados);
                                    if (!string.IsNullOrEmpty(LanCXJuro))
                                        TCN_Rastreab_ChTerceiro.GravarRastreab_ChTerceiro(
                                            new TRegistro_Rastreab_ChTerceiro()
                                            {
                                                Cd_banco = p.Cd_banco,
                                                Cd_clifor_origem = lParcelas[0].Cd_clifor,
                                                Cd_empresa = p.Cd_empresa,
                                                Nr_lanctocheque = p.Nr_lanctocheque,
                                                Cd_contager = Liquidacao.Cd_contager,
                                                Cd_lanctocaixa = Liquidacao.Cd_lanctocaixa_Juro,
                                                Tp_registro = (lParcelas[0].Tp_mov.Trim().ToUpper().Equals("P") ? "D" :
                                                              lParcelas[0].Tp_mov.Trim().ToUpper().Equals("R") ? "O" : string.Empty)
                                            }, qtb_liquid.Banco_Dados);
                                    if (!string.IsNullOrEmpty(LanCXDesc))
                                        TCN_Rastreab_ChTerceiro.GravarRastreab_ChTerceiro(
                                            new TRegistro_Rastreab_ChTerceiro()
                                            {
                                                Cd_banco = p.Cd_banco,
                                                Cd_clifor_origem = lParcelas[0].Cd_clifor,
                                                Cd_empresa = p.Cd_empresa,
                                                Nr_lanctocheque = p.Nr_lanctocheque,
                                                Cd_contager = Liquidacao.Cd_contager,
                                                Cd_lanctocaixa = Liquidacao.Cd_lanctocaixa_Desc,
                                                Tp_registro = (lParcelas[0].Tp_mov.Trim().ToUpper().Equals("P") ? "D" :
                                                              lParcelas[0].Tp_mov.Trim().ToUpper().Equals("R") ? "O" : string.Empty)
                                            }, qtb_liquid.Banco_Dados);
                                    if (!string.IsNullOrEmpty(LanCXDCambAT))
                                        TCN_Rastreab_ChTerceiro.GravarRastreab_ChTerceiro(
                                            new TRegistro_Rastreab_ChTerceiro()
                                            {
                                                Cd_banco = p.Cd_banco,
                                                Cd_clifor_origem = lParcelas[0].Cd_clifor,
                                                Cd_empresa = p.Cd_empresa,
                                                Nr_lanctocheque = p.Nr_lanctocheque,
                                                Cd_contager = Liquidacao.Cd_contager,
                                                Cd_lanctocaixa = Liquidacao.Cd_lanctocaixa_dcamb_at,
                                                Tp_registro = (lParcelas[0].Tp_mov.Trim().ToUpper().Equals("P") ? "D" :
                                                              lParcelas[0].Tp_mov.Trim().ToUpper().Equals("R") ? "O" : string.Empty)
                                            }, qtb_liquid.Banco_Dados);
                                    if (!string.IsNullOrEmpty(LanCXDCambPA))
                                        TCN_Rastreab_ChTerceiro.GravarRastreab_ChTerceiro(
                                            new TRegistro_Rastreab_ChTerceiro()
                                            {
                                                Cd_banco = p.Cd_banco,
                                                Cd_clifor_origem = lParcelas[0].Cd_clifor,
                                                Cd_empresa = p.Cd_empresa,
                                                Nr_lanctocheque = p.Nr_lanctocheque,
                                                Cd_contager = Liquidacao.Cd_contager,
                                                Cd_lanctocaixa = Liquidacao.Cd_lanctocaixa_dcamb_pa,
                                                Tp_registro = (lParcelas[0].Tp_mov.Trim().ToUpper().Equals("P") ? "D" :
                                                              lParcelas[0].Tp_mov.Trim().ToUpper().Equals("R") ? "O" : string.Empty)
                                            }, qtb_liquid.Banco_Dados);
                                    //Alterar status do cheque para Repassado
                                    p.Status_compensado = "R";
                                    TCN_LanTitulo.GravarTitulo(p, qtb_liquid.Banco_Dados);
                                });
                            }
                    //Gravar Faturar Cartao Credito
                    if (lFatura != null)
                        lFatura.ForEach(p =>
                        {
                            CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.Gravar(p, qtb_liquid.Banco_Dados);
                            if (!string.IsNullOrEmpty(LanCX))
                                CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao_X_Caixa.Gravar(
                                    new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao_X_Caixa()
                                    {
                                        Cd_contager = Liquidacao.Cd_contager,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCX, "@P_CD_LANCTOCAIXA")),
                                        Id_fatura = p.Id_fatura
                                    },
                                    qtb_liquid.Banco_Dados);
                            if (!string.IsNullOrEmpty(LanCXJuro))
                                CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao_X_Caixa.Gravar(
                                    new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao_X_Caixa()
                                    {
                                        Cd_contager = Liquidacao.Cd_contager,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXJuro, "@P_CD_LANCTOCAIXA")),
                                        Id_fatura = p.Id_fatura
                                    },
                                    qtb_liquid.Banco_Dados);
                            if (!string.IsNullOrEmpty(LanCXDesc))
                                CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao_X_Caixa.Gravar(
                                    new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao_X_Caixa()
                                    {
                                        Cd_contager = Liquidacao.Cd_contager,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXDesc, "@P_CD_LANCTOCAIXA")),
                                        Id_fatura = p.Id_fatura
                                    },
                                    qtb_liquid.Banco_Dados);
                            if (!string.IsNullOrEmpty(LanCXDCambAT))
                                CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao_X_Caixa.Gravar(
                                    new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao_X_Caixa()
                                    {
                                        Cd_contager = Liquidacao.Cd_contager,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXDCambAT, "@P_CD_LANCTOCAIXA")),
                                        Id_fatura = p.Id_fatura
                                    },
                                    qtb_liquid.Banco_Dados);
                            if (!string.IsNullOrEmpty(LanCXDCambPA))
                                CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao_X_Caixa.Gravar(
                                    new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao_X_Caixa()
                                    {
                                        Cd_contager = Liquidacao.Cd_contager,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(LanCXDCambPA, "@P_CD_LANCTOCAIXA")),
                                        Id_fatura = p.Id_fatura
                                    },
                                    qtb_liquid.Banco_Dados);
                        });
                    //Gravar Carta Frete
                    if (lCartaFrete != null)
                        lCartaFrete.ForEach(p =>
                            {
                                //Gravar carta frete
                                CamadaNegocio.PostoCombustivel.TCN_CartaFrete.Gravar(p, qtb_liquid.Banco_Dados);
                                //Gravar Liquid X Carta Frete
                                TCN_LiquidCartaFrete.Gravar(
                                    new TRegistro_LiquidCartaFrete()
                                    {
                                        Cd_contager = Liquidacao.Cd_contager,
                                        Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(LanCX, "@P_CD_LANCTOCAIXA")),
                                        Cd_empresa = p.Cd_empresa,
                                        Id_cartafrete = p.Id_cartafrete
                                    }, qtb_liquid.Banco_Dados);
                            });
                    //Gravar Cheque Troco
                    if (Liquidacao.lChTroco != null)
                        Liquidacao.lChTroco.ForEach(p =>
                            {
                                if (p.Tp_titulo.Trim().ToUpper().Equals("P") &&
                                    p.Nr_lanctocheque.Equals(decimal.Zero))
                                {
                                    p.St_lancarcaixa = true;
                                    p.Status_compensado = "T";
                                    CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.GravarTitulo(p, qtb_liquid.Banco_Dados);
                                }
                                else
                                {
                                    //Compensar os cheques
                                    p.Cd_contager_destino = Liquidacao.Cd_contager;
                                    p.Dt_compensacao = Liquidacao.Dt_Liquidacao;
                                    TCN_LanTitulo.CompensarCheques(new TList_RegLanTitulo() { p }, qtb_liquid.Banco_Dados);
                                }
                                TCN_TrocoCH.Gravar(new TRegistro_TrocoCH()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Nr_lanctocheque = p.Nr_lanctocheque,
                                    Cd_banco = p.Cd_banco,
                                    Cd_contager = Liquidacao.Cd_contager,
                                    Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(LanCX, "@P_CD_LANCTOCAIXA"))
                                }, qtb_liquid.Banco_Dados);
                            });

                    processaLiquidacao(lParcelas, Liquidacao, tEspera, qtb_liquid.Banco_Dados);
                    if (st_transacao)
                        qtb_liquid.Banco_Dados.Commit_Tran();
                    return LanLiq;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_liquid.Banco_Dados.RollBack_Tran();
                    throw new Exception("Erro gravar liquidação: " + ex.Message.Trim());
                }
                finally
                {
                    if (st_transacao)
                        qtb_liquid.deletarBanco_Dados();
                }
            }
            else
                return string.Empty;
        }

        private static decimal calcularVlLiquidado(decimal vVl_atual,
                                                   decimal vVl_atual_padrao,
                                                   decimal vVl_DifCamb,
                                                   decimal vVl_Liquidar_Padrao,
                                                   decimal vVl_DifCamb_Ativa,
                                                   decimal vVl_DifCamb_Passiva)
        {
            if (vVl_atual_padrao > 0)
            {
                decimal pc_vl_atual = Math.Round((vVl_Liquidar_Padrao - vVl_DifCamb_Ativa - vVl_DifCamb_Passiva) * 100 / (vVl_atual_padrao - vVl_DifCamb), 2);
                return Math.Round(vVl_atual * pc_vl_atual / 100, 2);
            }
            else
                throw new Exception("Valor Atual Padrao tem que ser maior que zero.");
        }

        private static void processaLiquidacao(List<TRegistro_LanParcela> lParcelas,
                                               TRegistro_LanLiquidacao Liquidacao,
                                               ThreadEspera tEspera,
                                               TObjetoBanco banco)
        {
            decimal vVl_SaldoLiquidar = Liquidacao.Cvl_aliquidar_padrao - Liquidacao.cVl_juroliquidar;
            decimal vSALDOVl_Desc = Liquidacao.cVl_descontoconcedido;
            decimal vSALDOVl_Juro = Liquidacao.cVl_juroliquidar;
            decimal vSALDOVl_TrocoCH = Liquidacao.Vl_trocoCH;
            decimal cVl_trocoCH = Liquidacao.Vl_trocoCH;
            Liquidacao.Vl_trocoCH = decimal.Zero;
            decimal vSALDOVl_TrocoDH = Liquidacao.Vl_trocoDH;
            decimal cVl_trocoDH = Liquidacao.Vl_trocoDH;
            Liquidacao.Vl_trocoDH = decimal.Zero;
            decimal vSALDOVl_adtoCH = Liquidacao.Vl_adto;
            decimal cVl_adtoCH = Liquidacao.Vl_adto;
            Liquidacao.Vl_adto = decimal.Zero;
            decimal vVl_Desc_Prop = decimal.Zero;
            decimal vVl_JuroLiq = decimal.Zero;
            decimal vVl_TrocoCH_Prop = decimal.Zero;
            decimal vVl_TrocoDH_Prop = decimal.Zero;
            decimal vVl_adto_Prop = decimal.Zero;
            decimal vVl_Liquidar = decimal.Zero;
            decimal vVl_LiquidarPadrao = decimal.Zero;
            decimal vVl_Atual = decimal.Zero;
            decimal vVl_difcamb_ativa = decimal.Zero;
            decimal vVl_difcamb_passiva = decimal.Zero;
            Int32 vQtdReg = lParcelas.Count;
            //Calculando juro proporcional
            decimal calc_juro = decimal.Zero;
            decimal dif_juro = decimal.Zero;
            if (lParcelas.Sum(p => p.Vl_juro) < Liquidacao.cVl_juroliquidar)
            {
                calc_juro = Math.Round((Liquidacao.cVl_juroliquidar - lParcelas.Sum(p => p.Vl_juro)) / vQtdReg, 2);
                dif_juro = (Liquidacao.cVl_juroliquidar - lParcelas.Sum(p => p.Vl_juro)) - (calc_juro * vQtdReg);
            }

            for (int x = 0; ((x < lParcelas.Count) && ((vVl_SaldoLiquidar > decimal.Zero) || (vSALDOVl_Juro > decimal.Zero))); x++)
            {
                //Verificar se a parcela possui bloquetos amarrados a um lote em aberto
                CamadaDados.Financeiro.Bloqueto.TList_Lote_X_Titulo lLoteBloq =
                    new CamadaDados.Financeiro.Bloqueto.TCD_Lote_X_Titulo(banco).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + lParcelas[x].Cd_empresa.Trim() + "'",
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.nr_lancto",
                            vOperador = "=",
                            vVL_Busca = lParcelas[x].Nr_lancto.ToString()
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_parcela",
                            vOperador = "=",
                            vVL_Busca = lParcelas[x].Cd_parcela.ToString()
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(b.st_registro, 'A')",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                    }, 0, string.Empty);
                if ((lLoteBloq.Count > 0) && (tEspera != null))
                    tEspera.Msg("Excluindo bloquetos de lote desconto em aberto...");
                //Excluir lote de bloquetos se existir
                lLoteBloq.ForEach(p => CamadaNegocio.Financeiro.Bloqueto.TCN_Lote_X_Titulo.Excluir(p, banco));

                if (DateTime.Parse(lParcelas[x].Dt_emissao.Value.ToString("dd/MM/yyyy")) <=
                    DateTime.Parse(Liquidacao.Dt_Liquidacao.Value.ToString("dd/MM/yyyy")))
                {
                    if (tEspera != null)
                        tEspera.Msg("Gravando objeto liquidação...");

                    //Calculando desconto proporcional
                    vVl_Desc_Prop = Decimal.Round(((Liquidacao.cVl_descontoconcedido / Liquidacao.Cvl_aliquidar_padrao) * lParcelas[x].Vl_atual), 2);
                    if ((vVl_Desc_Prop > vSALDOVl_Desc) || (vQtdReg == 1))
                        vVl_Desc_Prop = vSALDOVl_Desc;
                    vSALDOVl_Desc -= vVl_Desc_Prop;

                    //Calculando juro
                    if (lParcelas[x].Vl_juro > decimal.Zero)
                    {
                        if (vVl_SaldoLiquidar >= (lParcelas[x].Vl_atual - lParcelas[x].Vl_juro))
                        {
                            if (x == 0)
                                vVl_JuroLiq = (vSALDOVl_Juro > lParcelas[x].Vl_juro ? lParcelas[x].Vl_juro : vSALDOVl_Juro) + calc_juro + dif_juro;
                            else
                                vVl_JuroLiq = (vSALDOVl_Juro > lParcelas[x].Vl_juro ? lParcelas[x].Vl_juro : vSALDOVl_Juro) + calc_juro;
                        }
                        else vVl_JuroLiq = decimal.Zero;
                    }
                    else
                        if (x == 0)
                        vVl_JuroLiq = calc_juro + dif_juro;
                    else
                        vVl_JuroLiq = calc_juro;
                    vSALDOVl_Juro -= vVl_JuroLiq;
                    //Calculando troco cheque proporcional
                    vVl_TrocoCH_Prop = Decimal.Round((cVl_trocoCH / Liquidacao.Cvl_aliquidar_padrao) * (vVl_SaldoLiquidar > lParcelas[x].Vl_atual ? lParcelas[x].Vl_atual : vVl_SaldoLiquidar), 2);
                    if ((vVl_TrocoCH_Prop > vSALDOVl_TrocoCH) || (vQtdReg == 1))
                        vVl_TrocoCH_Prop = vSALDOVl_TrocoCH;
                    vSALDOVl_TrocoCH -= vVl_TrocoCH_Prop;
                    //Calculando troco dinheiro proporcional
                    vVl_TrocoDH_Prop = Decimal.Round((cVl_trocoDH / (Liquidacao.Cvl_aliquidar_padrao)) * (vVl_SaldoLiquidar > lParcelas[x].Vl_atual ? lParcelas[x].Vl_atual : vVl_SaldoLiquidar), 2);
                    if ((vVl_TrocoDH_Prop > vSALDOVl_TrocoDH) || (vQtdReg == 1))
                        vVl_TrocoDH_Prop = vSALDOVl_TrocoDH;
                    vSALDOVl_TrocoDH -= vVl_TrocoDH_Prop;

                    //Calcular adto proporcional
                    vVl_adto_Prop = Decimal.Round((cVl_adtoCH / Liquidacao.Cvl_aliquidar_padrao) * lParcelas[x].Vl_atual, 2);
                    if ((vVl_adto_Prop > vSALDOVl_adtoCH) || (vQtdReg == 1))
                        vVl_adto_Prop = vSALDOVl_adtoCH;
                    vSALDOVl_adtoCH -= vVl_adto_Prop;

                    vQtdReg -= 1;

                    if (vVl_SaldoLiquidar >= (lParcelas[x].Vl_atual - lParcelas[x].Vl_juro))
                        vVl_Liquidar = lParcelas[x].Vl_atual - lParcelas[x].Vl_juro;
                    else
                        vVl_Liquidar = vVl_SaldoLiquidar;

                    vVl_difcamb_ativa = CalcVlDifCamb(vVl_Liquidar, lParcelas[x].Vl_atual,
                                                                            lParcelas[x].cVl_DifCamb_Ativa,
                                                                            Liquidacao.lCotacao.Cd_moeda,
                                                                            Liquidacao.lCotacao.Cd_moedaresult);
                    vVl_difcamb_passiva = CalcVlDifCamb(vVl_Liquidar, lParcelas[x].Vl_atual,
                                                                            lParcelas[x].cVl_DifCamb_Passiva,
                                                                            Liquidacao.lCotacao.Cd_moeda,
                                                                            Liquidacao.lCotacao.Cd_moedaresult);
                    //Criar objeto Liquidação
                    TCD_LanLiquidacao cd = new TCD_LanLiquidacao();
                    cd.Banco_Dados = banco;
                    Liquidacao.Cd_empresa = lParcelas[x].Cd_empresa;
                    Liquidacao.Nr_lancto = lParcelas[x].Nr_lancto;
                    Liquidacao.Cd_parcela = lParcelas[x].Cd_parcela;
                    if (Liquidacao.Tp_mov.Trim().ToUpper().Equals("P"))
                    {
                        if (vVl_difcamb_ativa > 0)
                        {
                            vVl_LiquidarPadrao = vVl_Liquidar + vVl_difcamb_ativa;
                            vVl_Atual = lParcelas[x].Vl_atual + vVl_difcamb_ativa;
                        }
                        else if (vVl_difcamb_passiva > 0)
                        {
                            vVl_LiquidarPadrao = vVl_Liquidar - vVl_difcamb_passiva;
                            vVl_Atual = lParcelas[x].Vl_atual - vVl_difcamb_passiva;
                        }
                        else
                        {
                            vVl_LiquidarPadrao = vVl_Liquidar;
                            vVl_Atual = lParcelas[x].Vl_atual;
                        }
                    }
                    else if (Liquidacao.Tp_mov.Trim().ToUpper().Equals("R"))
                        if (vVl_difcamb_ativa > 0)
                        {
                            vVl_LiquidarPadrao = vVl_Liquidar - vVl_difcamb_ativa;
                            vVl_Atual = lParcelas[x].Vl_atual - vVl_difcamb_ativa;
                        }
                        else if (vVl_difcamb_passiva > 0)
                        {
                            vVl_LiquidarPadrao = vVl_Liquidar + vVl_difcamb_passiva;
                            vVl_Atual = lParcelas[x].Vl_atual + vVl_difcamb_passiva;
                        }
                        else
                        {
                            vVl_LiquidarPadrao = vVl_Liquidar;
                            vVl_Atual = lParcelas[x].Vl_atual;
                        }
                    if (lParcelas[0].Cd_moeda != lParcelas[0].Cd_moedaresult)
                        Liquidacao.Vl_Liquidado = calcularVlLiquidado(lParcelas[x].cVl_atual,
                                                                      lParcelas[x].Vl_atual,
                                                                      (vVl_difcamb_ativa + vVl_difcamb_passiva),
                                                                      vVl_Liquidar,
                                                                      vVl_difcamb_ativa,
                                                                      vVl_difcamb_passiva);
                    else
                        Liquidacao.Vl_Liquidado = vVl_LiquidarPadrao;

                    Liquidacao.Vl_liquidado_padrao = vVl_LiquidarPadrao;
                    Liquidacao.Vl_JuroAcrescimo = vVl_JuroLiq;
                    Liquidacao.Vl_DescontoBonus = vVl_Desc_Prop;
                    Liquidacao.Vl_trocoCH = vVl_TrocoCH_Prop;
                    Liquidacao.Vl_trocoDH = vVl_TrocoDH_Prop;
                    Liquidacao.Vl_adto = vVl_adto_Prop;
                    Liquidacao.Vl_atual = vVl_Atual;
                    Liquidacao.Vl_difcamb_at = vVl_difcamb_ativa;
                    Liquidacao.Vl_difcamb_pa = vVl_difcamb_passiva;
                    if (validaDados(Liquidacao))
                    {
                        Liquidacao.Id_liquid = null;
                        string retorno = cd.GravaLiquidacao(Liquidacao);
                        Liquidacao.Id_liquid = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LIQUID"));
                        //Buscar parcela novamente com os dados atualizados
                        lParcelas[x] = TCN_LanParcela.BuscarParcela(lParcelas[x].Cd_empresa,
                                                                     lParcelas[x].Nr_lancto.ToString(),
                                                                     lParcelas[x].Cd_parcela.ToString(),
                                                                     banco);
                        //Recalcular valor da parcela se liquidacao PARCIAL
                        if (lParcelas[x].St_registro.Trim().ToUpper().Equals("P"))
                        {
                            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
                            hs.Add("@P_CD_EMPRESA", lParcelas[x].Cd_empresa);
                            hs.Add("@P_NR_LANCTO", lParcelas[x].Nr_lancto);
                            hs.Add("@P_CD_PARCELA", lParcelas[x].Cd_parcela);
                            hs.Add("@P_DATA_ATUAL", Liquidacao.Dt_Liquidacao.Value);
                            hs.Add("@P_ST_CALCMOEDAPADRAO", "N");
                            try
                            {
                                lParcelas[x].Vl_atual = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(new CamadaDados.TDataQuery(banco).executarProc("STP_FIN_CALC_ATUAL", hs), "@@VL_RET"));
                                lParcelas[x].cVl_atual = lParcelas[x].Vl_atual;
                            }
                            catch
                            { }
                        }
                        //Guardar objeto liquidacao na parcela
                        lParcelas[x].Id_liquidAgrupar = Liquidacao.Id_liquid;
                        //GRAVAR COTACAO DA LIQUIDACAO
                        if ((!string.IsNullOrEmpty(Liquidacao.lCotacao.Cd_moeda)) && (!string.IsNullOrEmpty(Liquidacao.lCotacao.Cd_moedaresult)))
                            TCN_LiquidacaoCotacao.GravarLiquidacaoCotacao(new TRegistro_LiquidacaoCotacao()
                            {
                                Cd_empresa = Liquidacao.Cd_empresa,
                                Nr_lancto = Liquidacao.Nr_lancto,
                                Cd_parcela = Liquidacao.Cd_parcela,
                                Id_liquid = Liquidacao.Id_liquid,
                                Cd_moeda = Liquidacao.lCotacao.Cd_moeda,
                                Cd_moedaresult = Liquidacao.lCotacao.Cd_moedaresult,
                                Vl_cotacao = Liquidacao.lCotacao.Vl_cotacao,
                                Operador = Liquidacao.lCotacao.Operador,
                                Login = Parametros.pubLogin,
                                Dt_cotacao = Liquidacao.lCotacao.Dt_cotacao
                            }, banco);
                        //Se a liquidacao vier da tela de liquidacao e tiver bloqueto tem que cancelar o bloqueto
                        if (lParcelas[x].St_bloquetobool && Liquidacao.St_BloqLiquidacao)
                        {
                            CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloq = CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar(lParcelas[x].Cd_empresa,
                                                                                                                                      lParcelas[x].Nr_lancto.Value,
                                                                                                                                      lParcelas[x].Cd_parcela.Value,
                                                                                                                                      decimal.Zero,
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
                                                                                                                                      "'A'",
                                                                                                                                      string.Empty,
                                                                                                                                      string.Empty,
                                                                                                                                      string.Empty,
                                                                                                                                      string.Empty,
                                                                                                                                      string.Empty,
                                                                                                                                      string.Empty,
                                                                                                                                      false,
                                                                                                                                      0,
                                                                                                                                      banco);
                            if ((lBloq.Count > 0) && (tEspera != null))
                                tEspera.Msg("Cancelando bloqueto emitido...");
                            lBloq.ForEach(p =>
                                {
                                    p.St_registro = "C"; //Cancelado
                                    CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Gravar(p, banco);
                                });
                        }
                        //Liquidacao X Adto_Caixa
                        int j = 0;
                        decimal saldo_liquidar = Liquidacao.Vl_Liquidado;
                        if (Liquidacao.LiqAdtoCaixa.Count > 0)
                            while ((j < Liquidacao.LiqAdtoCaixa.Count) && (saldo_liquidar > 0))
                            {
                                if (Liquidacao.LiqAdtoCaixa[j].Vl_saldo > 0)
                                {
                                    Liquidacao.LiqAdtoCaixa[j].Cd_empresa = Liquidacao.Cd_empresa;
                                    Liquidacao.LiqAdtoCaixa[j].Nr_lancto = Liquidacao.Nr_lancto;
                                    Liquidacao.LiqAdtoCaixa[j].Cd_parcela = Liquidacao.Cd_parcela;
                                    Liquidacao.LiqAdtoCaixa[j].Id_liquid = Liquidacao.Id_liquid;
                                    decimal vl_devolvido = Liquidacao.LiqAdtoCaixa[j].Vl_saldo > saldo_liquidar ? saldo_liquidar : Liquidacao.LiqAdtoCaixa[j].Vl_saldo;
                                    Liquidacao.LiqAdtoCaixa[j].Vl_devolvido += vl_devolvido;
                                    TCN_Liquidacao_X_Adto_Caixa.GravarLiquidacao_X_AdtoCaixa(Liquidacao.LiqAdtoCaixa[j], banco);
                                    saldo_liquidar -= vl_devolvido;
                                }
                                else
                                {
                                    j++;
                                    continue;
                                }
                            }
                        //Amarrar liquidacao com caixa operacional
                        if (Liquidacao.Id_caixaoperacional != null)
                            CamadaNegocio.Faturamento.PDV.TCN_Caixa_X_Liquidacao.Gravar(
                                new CamadaDados.Faturamento.PDV.TRegistro_Caixa_X_Liquidacao()
                                {
                                    Id_caixa = Liquidacao.Id_caixaoperacional,
                                    Cd_empresa = Liquidacao.Cd_empresa,
                                    Nr_lancto = Liquidacao.Nr_lancto,
                                    Cd_parcela = Liquidacao.Cd_parcela,
                                    Id_liquid = Liquidacao.Id_liquid
                                }, banco);
                    }
                    vVl_SaldoLiquidar -= vVl_Liquidar;
                }
                else
                    throw new Exception("Não é Permitido uma Liquidação com data inferior à Emissão do Documento: " + lParcelas[x].Dt_emissao.ToString());
            }
        }

        public static bool CancelarLiquidacao(TRegistro_LanLiquidacao val,
                                              ThreadEspera tEspera,
                                              TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanLiquidacao qtb_liquid = new TCD_LanLiquidacao();
            try
            {
                //Verificar se liquidação esta vinculado a uma troca de cliente proposta
                if (new CamadaDados.Faturamento.Orcamento.TCD_Troca_X_Mov().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca{vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"},
                        new TpBusca{vNM_Campo = "a.nr_lancto", vOperador = "=", vVL_Busca = val.Nr_lancto.Value.ToString()},
                        new TpBusca{vNM_Campo = "a.cd_parcela", vOperador = "=", vVL_Busca = val.Cd_parcela.Value.ToString()},
                        new TpBusca{vNM_Campo = "a.id_liquid", vOperador = "=", vVL_Busca = val.Id_liquid.Value.ToString()}
                    }, "1") != null)
                    throw new Exception("Não é permitido cancelar liquidação amarrada a uma troca de cliente na proposta.");
                //Verificar se liquidação esta vinculado a uma troca de item da proposta
                if(new CamadaDados.Faturamento.Orcamento.TCD_Troca_X_Liquid().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca{vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"},
                        new TpBusca{vNM_Campo = "a.nr_lancto", vOperador = "=", vVL_Busca = val.Nr_lancto.Value.ToString()},
                        new TpBusca{vNM_Campo = "a.cd_parcela", vOperador = "=", vVL_Busca = val.Cd_parcela.Value.ToString()},
                        new TpBusca{vNM_Campo = "a.id_liquid", vOperador = "=", vVL_Busca = val.Id_liquid.Value.ToString()}
                    }, "1") != null)
                    throw new Exception("Não é permitido cancelar liquidação amarrada a uma troca de item da proposta.");
                //Verificar se liquidacao esta vinculado a duplicata agrupadora
                object dup_grupo = new TCD_VincularDup().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctovinculado",
                                            vOperador = "=",
                                            vVL_Busca = val.Nr_lancto.Value.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_parcelavinculado",
                                            vOperador = "=",
                                            vVL_Busca = val.Cd_parcela.Value.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_liquidvinculado",
                                            vOperador = "=",
                                            vVL_Busca = val.Id_liquid.Value.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo= string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and isnull(x.st_registro, 'A') <> 'C')"
                                        }
                                    }, "a.nr_lancto");
                if (dup_grupo != null)
                    throw new Exception("Liquidação foi gerada pelo agrupamento de duplicatas.\r\n" +
                                        "Liquidação só pode ser cancelada atravéz do cancelamento da duplicata agrupadora Nº" + dup_grupo.ToString());
                if (banco == null)
                {
                    if (tEspera != null)
                        tEspera.Msg("Criando conexão com o banco de dados...");
                    st_transacao = qtb_liquid.CriarBanco_Dados(true);
                }
                else
                    qtb_liquid.Banco_Dados = banco;
                if (tEspera != null)
                    tEspera.Msg("Cancelando objeto liquidação...");
                //Alterar o status da liquidacao para C - Cancelado
                val.St_registro = "C";
                qtb_liquid.GravaLiquidacao(val);
                //Buscar dados da parcela
                TList_RegLanParcela lParcela = TCN_LanParcela.Busca(val.Cd_empresa,
                                                                    val.Nr_lancto.Value,
                                                                    val.Cd_parcela.Value,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    0,
                                                                    string.Empty,
                                                                    qtb_liquid.Banco_Dados);
                if (lParcela.Count > 0)
                {
                    if (tEspera != null)
                        tEspera.Msg("Alterando status da parcela...");
                    //Verificar se para a parcela existe alguma outra liquidacao
                    TList_RegLanLiquidacao lLiquidacao = TCN_LanLiquidacao.Busca(val.Cd_empresa,
                                                                                 val.Nr_lancto.Value,
                                                                                 val.Cd_parcela.Value,
                                                                                 0,
                                                                                 string.Empty,
                                                                                 decimal.Zero,
                                                                                 decimal.Zero,
                                                                                 decimal.Zero,
                                                                                 decimal.Zero,
                                                                                 decimal.Zero,
                                                                                 decimal.Zero,
                                                                                 decimal.Zero,
                                                                                 false,
                                                                                 "A",
                                                                                 0,
                                                                                 string.Empty,
                                                                                 qtb_liquid.Banco_Dados);
                    if (lLiquidacao.Count > 0)
                        //Se sim alterar o status da parcela para P
                        lParcela[0].St_registro = "P";
                    else
                        //Se nao alterar o status da parcela para A
                        lParcela[0].St_registro = "A";
                    //Gravar alteracao da parcela
                    TCN_LanParcela.GravarParcela(lParcela[0], qtb_liquid.Banco_Dados);

                    //Cancelar caixa da liquidacao
                    if (val.Cd_lanctocaixa.HasValue)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Cancelando lançamento de caixa da liquidação...");
                        TCN_LanCaixa.Busca(val.Cd_contager,
                                           val.Cd_lanctocaixa.ToString(),
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
                                           qtb_liquid.Banco_Dados).ForEach(p =>
                                               TCN_LanCaixa.EstornarCaixa(p, tEspera, qtb_liquid.Banco_Dados));
                    }
                    //Cancelar caixa do juro (se existir)
                    if (val.Cd_lanctocaixa_Juro.HasValue)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Cancelando lançamento de caixa juro...");
                        TCN_LanCaixa.Busca(val.Cd_contager,
                                           val.Cd_lanctocaixa_Juro.ToString(),
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
                                           qtb_liquid.Banco_Dados).ForEach(p =>
                                               TCN_LanCaixa.EstornarCaixa(p, tEspera, qtb_liquid.Banco_Dados));
                    }
                    //Cancelar caixa do desconto (se existir)
                    if (val.Cd_lanctocaixa_Desc.HasValue)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Cancelando lançamento de caixa desconto...");
                        TCN_LanCaixa.Busca(val.Cd_contager,
                                           val.Cd_lanctocaixa_Desc.ToString(),
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
                                           qtb_liquid.Banco_Dados).ForEach(p =>
                                               TCN_LanCaixa.EstornarCaixa(p, tEspera, qtb_liquid.Banco_Dados));
                    }
                    //Cancelar caixa da diferença cambial ativa (se existir)
                    if (val.Cd_lanctocaixa_dcamb_at.HasValue)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Cancelando lançamento de caixa da diferença cambial ativa...");
                        TCN_LanCaixa.Busca(val.Cd_contager,
                                           val.Cd_lanctocaixa_dcamb_at.ToString(),
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
                                           qtb_liquid.Banco_Dados).ForEach(p =>
                                               TCN_LanCaixa.EstornarCaixa(p, tEspera, qtb_liquid.Banco_Dados));
                    }
                    //Cancelar caixa da diferença cambial passiva (se existir)
                    if (val.Cd_lanctocaixa_dcamb_pa.HasValue)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Cancelando lançamento de caixa da diferença cambial passiva...");
                        TCN_LanCaixa.Busca(val.Cd_contager,
                                           val.Cd_lanctocaixa_dcamb_pa.ToString(),
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
                                           qtb_liquid.Banco_Dados).ForEach(p =>
                                               TCN_LanCaixa.EstornarCaixa(p, tEspera, qtb_liquid.Banco_Dados));
                    }
                    //Cancelar caixa troco cheque
                    if (val.Cd_lanctocaixa_trocoCH.HasValue)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Cancelando lançamento de caixa troco cheque...");
                        TCN_LanCaixa.Busca(val.Cd_contager,
                                           val.Cd_lanctocaixa_trocoCH.Value.ToString(),
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
                                           qtb_liquid.Banco_Dados).ForEach(p =>
                                               TCN_LanCaixa.EstornarCaixa(p, tEspera, qtb_liquid.Banco_Dados));
                    }
                    //Cancelar caixa troco dinheiro
                    if (val.Cd_lanctocaixa_trocoDH.HasValue)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Cancelando lançamento de caixa troco dinheiro...");
                        TCN_LanCaixa.Busca(val.Cd_contager,
                                           val.Cd_lanctocaixa_trocoDH.Value.ToString(),
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
                                           qtb_liquid.Banco_Dados).ForEach(p =>
                                               TCN_LanCaixa.EstornarCaixa(p, tEspera, qtb_liquid.Banco_Dados));
                    }
                    //Cancelar caixa Adto
                    if (val.Cd_lanctocaixa_adto.HasValue)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Cancelando credito recebido...");
                        //Buscar adiantamento
                        TList_LanAdiantamento lAdto = new TCD_LanAdiantamento(qtb_liquid.Banco_Dados).Select(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from TB_FIN_Adiantamento_X_Caixa x " +
                                                                            "where x.id_adto = a.id_adto " +
                                                                            "and x.cd_contager = '" + val.Cd_contager.Trim() + "' " +
                                                                            "and x.cd_lanctocaixa = " + val.Cd_lanctocaixa_adto.Value.ToString() + ")"
                                                            }
                                                        }, 1, string.Empty);
                        if (lAdto.Count > 0)
                            TCN_LanAdiantamento.Excluir(lAdto[0], qtb_liquid.Banco_Dados);
                    }
                    //Cancelar caixa perda duplicata
                    if (val.Cd_lanctocaixa_perdaDup.HasValue)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Cancelando lançamento caixa perda duplicata...");
                        TCN_LanCaixa.Busca(val.Cd_contager,
                                           val.Cd_lanctocaixa_perdaDup.Value.ToString(),
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
                                           qtb_liquid.Banco_Dados).ForEach(p =>
                                               TCN_LanCaixa.EstornarCaixa(p, tEspera, qtb_liquid.Banco_Dados));
                    }
                    //Verificar se a parcela possui bloqueto
                    CamadaDados.Financeiro.Bloqueto.blListaTitulo lTitulo =
                        CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar(lParcela[0].Cd_empresa,
                                                                            lParcela[0].Nr_lancto.Value,
                                                                            lParcela[0].Cd_parcela.Value,
                                                                            decimal.Zero,
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
                                                                            string.Empty,
                                                                            false,
                                                                            1,
                                                                            qtb_liquid.Banco_Dados);
                    //Se a parcela tiver bloqueto Abrir o titulo novamente
                    if (lTitulo.Count > 0)
                    {
                        if (tEspera != null)
                            tEspera.Msg("Reabrindo bloqueto...");
                        lTitulo[0].Dt_ocorrencia = null;
                        lTitulo[0].Dt_credito = null;
                        lTitulo[0].Vl_despesa_cobranca = 0;
                        lTitulo[0].St_registro = "A";
                        CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Gravar(lTitulo[0], qtb_liquid.Banco_Dados);
                    }
                }
                //Verificar se liquidacao gerou devolucao de adiantamento
                TList_LanCaixa lCaixaDev = TCN_Liquidacao_X_Adto_Caixa.BuscarCaixaDev(val.Cd_empresa,
                                                                                      val.Nr_lancto.Value,
                                                                                      val.Cd_parcela.Value,
                                                                                      val.Id_liquid.Value,
                                                                                      qtb_liquid.Banco_Dados);
                if ((lCaixaDev.Count > 0) && (tEspera != null))
                    tEspera.Msg("Cancelando lançamento de caixa de devolução de adiantamento...");
                lCaixaDev.ForEach(p => TCN_LanCaixa.EstornarCaixa(p, tEspera, qtb_liquid.Banco_Dados));
                //Verificar se liquidacao gerou centro resultado devolucao credito
                TList_Adiantamento_X_CCusto lCCusto =
                    new TCD_Adiantamento_X_CCusto(qtb_liquid.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fin_liquidacao_x_adto_caixa x " +
                                            "where x.id_adto = a.id_adto " +
                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                            "and x.nr_lancto = " + val.Nr_lancto.Value.ToString() + " " +
                                            "and x.cd_parcela = " + val.Cd_parcela.Value.ToString() + " " +
                                            "and x.id_liquid = " + val.Id_liquid.Value.ToString() + ")"
                            }
                        }, 0, string.Empty);
                if (lCCusto.Count > 0)
                    tEspera.Msg("Excluindo centro resultado devolução de adiantamento...");
                lCCusto.ForEach(p =>
                    {
                        //Excluir Adiantamento X Centro Resultado
                        TCN_Adiantamento_X_CCusto.Excluir(p, qtb_liquid.Banco_Dados);
                        //Excluir centro resultado
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(
                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                            {
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_liquid.Banco_Dados);
                    });
                //Verificar se a liquidacao originou de um desconto de duplicata
                TList_LanCaixa lCaixaDesc = TCN_LanLiquidacao_X_DescDup.BuscarCaixaDesc(val.Cd_empresa,
                                                                                        val.Nr_lancto.Value,
                                                                                        val.Cd_parcela.Value,
                                                                                        val.Id_liquid.Value,
                                                                                        0,
                                                                                        string.Empty,
                                                                                        qtb_liquid.Banco_Dados);
                if ((lCaixaDesc.Count > 0) && (tEspera != null))
                    tEspera.Msg("Cancelando lançamento de caixa desconto de duplicata...");
                lCaixaDesc.ForEach(v => TCN_LanCaixa.EstornarCaixa(v, tEspera, qtb_liquid.Banco_Dados));
                //Cancelar Retenção Financeira GMO
                if (tEspera != null)
                    tEspera.Msg("Cancelando retenção financeira GMO...");
                CamadaNegocio.Graos.TCN_Lan_RetencaoFinanceiraGMO.Deletar(val.Cd_empresa,
                                                                          val.Nr_lancto.ToString(),
                                                                          val.Id_liquid.ToString(),
                                                                          val.Cd_parcela.ToString(),
                                                                          qtb_liquid.Banco_Dados);
                //Verifica se liquidacao com cheque
                if (tEspera != null)
                    tEspera.Msg("Cancelando cheque gerou credito liquidação...");
                CamadaNegocio.Financeiro.Titulo.TCN_Titulo_x_Liquidacao.Buscar(val.Cd_empresa,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               val.Nr_lancto.Value.ToString(),
                                                                               val.Cd_parcela.Value.ToString(),
                                                                               val.Id_liquid.Value.ToString(),
                                                                               qtb_liquid.Banco_Dados).ForEach(p =>
                                                                                   {
                                                                                       //Buscar cheque
                                                                                       CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rCh =
                                                                                           CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.Busca(p.Cd_empresa,
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
                                                                                                                                               qtb_liquid.Banco_Dados)[0];
                                                                                       //Excluir titulo x liquidacao
                                                                                       CamadaNegocio.Financeiro.Titulo.TCN_Titulo_x_Liquidacao.Excluir(p, qtb_liquid.Banco_Dados);
                                                                                       //Cancelar titulo
                                                                                       rCh.St_lancarcaixa = true;
                                                                                       CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.CancelarTitulo(rCh, qtb_liquid.Banco_Dados);
                                                                                   });
                if (st_transacao)
                    qtb_liquid.Banco_Dados.Commit_Tran();
                return true;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liquid.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar liquidação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_liquid.deletarBanco_Dados();
            }
        }

        public static bool validaDados(TRegistro_LanLiquidacao val)
        {
            if (!string.IsNullOrEmpty(val.Cd_empresa))
                if (!string.IsNullOrEmpty(val.Cd_contager))
                    if ((val.Cd_lanctocaixa > 0) || (val.Cd_lanctocaixa_Desc > 0) || (val.Cd_lanctocaixa_Juro > 0))
                        if (val.Cd_parcela > 0)
                            if (!string.IsNullOrEmpty(val.Cd_portador))
                                if (!string.IsNullOrEmpty(val.Nr_docto))
                                    if (val.Nr_lancto > 0)
                                        if (!string.IsNullOrEmpty(val.Tp_mov))
                                            if (val.Cvl_aliquidar_padrao > 0)
                                                return true;
                                            else
                                                throw new Exception("Valor liquidação é obrigatório!");
                                        else
                                            throw new Exception("Tp.Movimento é obrigatorio!");
                                    else
                                        throw new Exception("Lancto é obrigatorio!");
                                else
                                    throw new Exception("Documento é obrigatorio!");
                            else
                                throw new Exception("CD.Portador é obrigatorio!");
                        else
                            throw new Exception("Cd.Parcela é obrigatorio!");
                    else
                        throw new Exception("Lançamento de Caixa é obrigatorio!");
                else
                    throw new Exception("CD.Conta Ger é obrigatorio!");
            else
                throw new Exception("CD.Empresa é obrigatorio!");
        }
    }

    public class TCN_LiquidacaoCotacao
    {
        public static TList_LiquidacaoCotacao Buscar(string vCd_empresa,
                                                     decimal vNr_lancto,
                                                     decimal vCd_parcela,
                                                     decimal vId_liquid,
                                                     string vCd_moeda,
                                                     string vCd_moedaresult,
                                                     int vTop,
                                                     string vNm_campo,
                                                     TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vNr_lancto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_Lancto";
                filtro[filtro.Length - 1].vVL_Busca = vNr_lancto.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_parcela > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Parcela";
                filtro[filtro.Length - 1].vVL_Busca = vCd_parcela.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vId_liquid > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Liquid";
                filtro[filtro.Length - 1].vVL_Busca = vId_liquid.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_moeda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_moeda + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_moedaresult))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_moedaresult + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new TCD_LiquidacaoCotacao(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarLiquidacaoCotacao(TRegistro_LiquidacaoCotacao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LiquidacaoCotacao qtb_liq = new TCD_LiquidacaoCotacao();
            try
            {
                if (banco == null)
                {
                    qtb_liq.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_liq.Banco_Dados = banco;

                string retorno = qtb_liq.GravarLiquidacaoCotacao(val);
                if (st_transacao)
                    qtb_liq.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liq.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar cotação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_liq.deletarBanco_Dados();
            }
        }

        public static string DeletarLiquidacaoCotacao(TRegistro_LiquidacaoCotacao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LiquidacaoCotacao qtb_liq = new TCD_LiquidacaoCotacao();
            try
            {
                if (banco == null)
                {
                    qtb_liq.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_liq.Banco_Dados = banco;

                qtb_liq.DeletarLiquidacaoCotacao(val);
                if (st_transacao)
                    qtb_liq.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liq.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir cotação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_liq.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Liquidacao_X_Adto_Caixa
    {
        public static TList_LanCaixa BuscarCaixaDev(string Cd_empresa,
                                                    decimal Nr_lancto,
                                                    decimal Cd_parcela,
                                                    decimal Id_liquid,
                                                    TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[2];
            filtro[0].vNM_Campo = "isnull(a.st_estorno, 'N')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'S'";

            filtro[1].vNM_Campo = string.Empty;
            filtro[1].vOperador = "exists";
            filtro[1].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                  "inner join tb_fin_liquidacao_x_adto_caixa y " +
                                  "on x.id_adto = y.id_adto " +
                                  "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                  "and x.cd_contager = y.cd_contager " +
                                  "where y.cd_contager = a.cd_contager " +
                                  "and y.cd_lanctocaixa = a.cd_lanctocaixa " +
                                  "and y.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                  "and y.nr_lancto = " + Nr_lancto.ToString() + " " +
                                  "and y.cd_parcela = " + Cd_parcela.ToString() + " " +
                                  "and y.id_liquid = " + Id_liquid.ToString() + ")";
            return new TCD_LanCaixa(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_RegLanLiquidacao BuscarLiquidDev(string Cd_contager,
                                                             decimal Cd_lanctocaixa,
                                                             TObjetoBanco banco)
        {
            return new TCD_LanLiquidacao(banco).Select(
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
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                    "inner join tb_fin_liquidacao_x_adto_caixa y " +
                                    "on x.id_adto = y.id_adto " +
                                    "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                    "and x.cd_contager = y.cd_contager " +
                                    "where y.cd_empresa = a.cd_empresa " +
                                    "and y.nr_lancto = a.nr_lancto " +
                                    "and y.cd_parcela = a.cd_parcela " +
                                    "and y.id_liquid = a.id_liquid " +
                                    "and y.cd_contager = '" + Cd_contager.Trim() + "' " +
                                    "and y.cd_lanctocaixa = " + Cd_lanctocaixa.ToString() + ")"
                    }
                }, 0, string.Empty);
        }

        public static string GravarLiquidacao_X_AdtoCaixa(TRegistro_Liquidacao_X_Adto_Caixa val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Liquidacao_X_Adto_Caixa qtb_liqadto = new TCD_Liquidacao_X_Adto_Caixa();
            try
            {
                if (banco == null)
                {
                    qtb_liqadto.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_liqadto.Banco_Dados = banco;
                string retorno = qtb_liqadto.GravarLiquidacao_x_Adto_Caixa(val);
                if (st_transacao)
                    qtb_liqadto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liqadto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_liqadto.deletarBanco_Dados();
            }
        }

        public static string DeletarLiquidacao_x_AdtoCaixa(TRegistro_Liquidacao_X_Adto_Caixa val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Liquidacao_X_Adto_Caixa qtb_liq = new TCD_Liquidacao_X_Adto_Caixa();
            try
            {
                if (banco == null)
                {
                    qtb_liq.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_liq.Banco_Dados = banco;
                qtb_liq.DeletarLiquidacao_x_Adto_Caixa(val);
                if (st_transacao)
                    qtb_liq.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liq.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_liq.deletarBanco_Dados();
            }
        }
    }

    public class TCN_TrocoCH
    {
        public static TList_TrocoCH Buscar(string Cd_empresa,
                                           string Nr_lanctocheque,
                                           string Cd_banco,
                                           string Cd_contager,
                                           string Cd_lanctocaixa,
                                           TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctocheque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctocheque;
            }
            if (!string.IsNullOrEmpty(Cd_banco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
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
            return new TCD_TrocoCH(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TrocoCH val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocoCH qtb_troco = new TCD_TrocoCH();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troco.CriarBanco_Dados(true);
                else
                    qtb_troco.Banco_Dados = banco;
                string retorno = qtb_troco.Gravar(val);
                if (st_transacao)
                    qtb_troco.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_troco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar troco: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troco.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TrocoCH val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocoCH qtb_troco = new TCD_TrocoCH();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troco.CriarBanco_Dados(true);
                else
                    qtb_troco.Banco_Dados = banco;
                qtb_troco.Excluir(val);
                if (st_transacao)
                    qtb_troco.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_troco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir troco: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troco.deletarBanco_Dados();
            }
        }
    }

    public class TCN_LiquidCartaFrete
    {
        public static TList_LiquidCartaFrete Buscar(string Cd_empresa,
                                                    string Id_cartafrete,
                                                    string Cd_contager,
                                                    string Cd_lanctocaixa,
                                                    TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_cartafrete))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cartafrete";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cartafrete;
            }
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
            return new TCD_LiquidCartaFrete(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LiquidCartaFrete val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LiquidCartaFrete qtb_liquid = new TCD_LiquidCartaFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_liquid.CriarBanco_Dados(true);
                else qtb_liquid.Banco_Dados = banco;
                string retorno = qtb_liquid.Gravar(val);
                if (st_transacao)
                    qtb_liquid.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liquid.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar liquid carta frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_liquid.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LiquidCartaFrete val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LiquidCartaFrete qtb_liquid = new TCD_LiquidCartaFrete();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_liquid.CriarBanco_Dados(true);
                else qtb_liquid.Banco_Dados = banco;
                qtb_liquid.Excluir(val);
                //Estornar carta frete
                CamadaNegocio.PostoCombustivel.TCN_CartaFrete.Excluir(
                    CamadaNegocio.PostoCombustivel.TCN_CartaFrete.Buscar(val.Cd_empresa,
                                                                         val.Id_cartafretestr,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         qtb_liquid.Banco_Dados)[0], qtb_liquid.Banco_Dados);
                if (st_transacao)
                    qtb_liquid.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liquid.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir liquid carta frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_liquid.deletarBanco_Dados();
            }
        }
    }

    public class TCN_DuplicataXCCusto
    {
        public static TList_DuplicataXCcusto Buscar(string vCd_empresa,
                                                    string vNr_lancto,
                                                    string Id_ccustolan,
                                                    int vTop,
                                                    string vNm_campo,
                                                    TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNr_lancto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Lancto";
                vBusca[vBusca.Length - 1].vVL_Busca = vNr_lancto;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Id_ccustolan))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_CCustolan";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_ccustolan;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            return new TCD_DuplicataXCCusto(banco).Select(vBusca, vTop, vNm_campo);
        }

        public static CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto BuscarCusto(string Cd_empresa,
                                                                                         string Nr_lancto,
                                                                                         TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.CCustoLan.TCD_LanCCustoLancto(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_duplicata_x_ccusto x "+
                                    "where x.id_ccustolan = a.id_ccustolan "+
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "'" +
                                    "and x.nr_lancto = " + Nr_lancto + ")"
                    }
                }, 0, string.Empty);
        }

        public static void ProcessarFinCResultado(TRegistro_LanDuplicata lDup,
                                                CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCResultado,
                                               TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DuplicataXCCusto qtb_dup = new TCD_DuplicataXCCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dup.CriarBanco_Dados(true);
                else
                    qtb_dup.Banco_Dados = banco;
                //Verificar se Duplicata possui centro de resultado
                TCN_DuplicataXCCusto.Buscar(lDup.Cd_empresa,
                                            lDup.Nr_lancto.ToString(),
                                               string.Empty,
                                               0,
                                               string.Empty,
                                               qtb_dup.Banco_Dados).ForEach(v =>
                                               {
                                                   TCN_DuplicataXCCusto.Excluir(v, qtb_dup.Banco_Dados);
                                                   CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(
                                                           new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                           {
                                                               Id_ccustolan = v.Id_ccustolan
                                                           }, qtb_dup.Banco_Dados);
                                               });
                lCResultado.ForEach(p =>
                {

                    if (!string.IsNullOrEmpty(p.Cd_centroresult))
                    {
                        //Gravar Lancto Resultado
                        string id = CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                        new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                        {
                            Cd_empresa = lDup.Cd_empresa,
                            Cd_centroresult = p.Cd_centroresult,
                            Vl_lancto = p.Vl_lancto,
                            Dt_lancto = p.Dt_lancto
                        }, qtb_dup.Banco_Dados);
                        //Amarrar Lancto a Duplicata
                        Gravar(new TRegistro_DuplicataXCCusto()
                        {
                            Cd_empresa = lDup.Cd_empresa,
                            Nr_lancto = lDup.Nr_lancto,
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
                throw new Exception("Erro processar duplicata x centro resultado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }


        public static void ProcessarFinCResultado(List<TRegistro_LanDuplicata> lDup,
                                                  string Cd_cresultado,
                                                  TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DuplicataXCCusto qtb_dup = new TCD_DuplicataXCCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dup.CriarBanco_Dados(true);
                else
                    qtb_dup.Banco_Dados = banco;
                lDup.ForEach(p =>
                    {
                        //Verificar se Duplicata possui centro de resultado
                        TCN_DuplicataXCCusto.Buscar(p.Cd_empresa,
                                                    p.Nr_lancto.ToString(),
                                                       string.Empty,
                                                       0,
                                                       string.Empty,
                                                       qtb_dup.Banco_Dados).ForEach(v =>
                                                       {
                                                           TCN_DuplicataXCCusto.Excluir(v, qtb_dup.Banco_Dados);
                                                           CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(
                                                                   new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                                   {
                                                                       Id_ccustolan = v.Id_ccustolan
                                                                   }, qtb_dup.Banco_Dados);
                                                       });
                        if (!string.IsNullOrEmpty(Cd_cresultado))
                        {
                            //Gravar Lancto Resultado
                            string id = CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                                new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Cd_centroresult = Cd_cresultado,
                                    Vl_lancto = p.Vl_documento_padrao,
                                    Dt_lancto = p.Dt_emissao
                                }, qtb_dup.Banco_Dados);
                            //Amarrar Lancto a Duplicata
                            Gravar(new TRegistro_DuplicataXCCusto()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Nr_lancto = p.Nr_lancto,
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
                throw new Exception("Erro processar duplicata x centro resultado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_DuplicataXCCusto val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DuplicataXCCusto qtb_dup = new TCD_DuplicataXCCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dup.CriarBanco_Dados(true);
                else
                    qtb_dup.Banco_Dados = banco;
                //Gravar Duplicata X CentroCusto
                string retorno = qtb_dup.Gravar(val);
                if (st_transacao)
                    qtb_dup.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dup.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DuplicataXCCusto val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DuplicataXCCusto qtb_dup = new TCD_DuplicataXCCusto();
            try
            {
                if (banco == null)
                {
                    qtb_dup.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_dup.Banco_Dados = banco;
                //Deletar Duplicata x Centro Custo
                qtb_dup.Excluir(val);
                //Verificar se Rateio esta amarrado a um empreendimento
                CamadaDados.Financeiro.Empreendimento.TList_Empreendimento_X_LanCCusto lEmpreendimento =
                    CamadaNegocio.Financeiro.Empreendimento.TCN_Empreendimento_X_LanCCusto.Buscar(string.Empty,
                                                                                                  val.Id_ccustolan.ToString(),
                                                                                                  0,
                                                                                                  string.Empty,
                                                                                                  qtb_dup.Banco_Dados);
                lEmpreendimento.ForEach(p => CamadaNegocio.Financeiro.Empreendimento.TCN_Empreendimento_X_LanCCusto.ExcluirEmpreendimentoLanCCusto(p, qtb_dup.Banco_Dados));
                //Deletar CCustoLan
                CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                {
                    Id_ccustolan = val.Id_ccustolan
                }, qtb_dup.Banco_Dados);
                if (st_transacao)
                    qtb_dup.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dup.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AtVenctoParcela
    {
        public static TList_AtVenctoParcela Busca(string CD_Empresa,
                                                string NR_Lancto,
                                                string CD_Parcela,
                                                string ID_Atualiza,
                                                TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_Empresa + "'";
            }
            if (!string.IsNullOrEmpty(NR_Lancto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Lancto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = NR_Lancto;
            }
            if (!string.IsNullOrEmpty(CD_Parcela))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Parcela";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = CD_Parcela;
            }
            if (!string.IsNullOrEmpty(ID_Atualiza))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Atualiza";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = ID_Atualiza;
            }
            return new TCD_AtVenctoParcela(banco).Select(vBusca, 0, string.Empty, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_AtVenctoParcela val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AtVenctoParcela qtb_at = new TCD_AtVenctoParcela();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_at.CriarBanco_Dados(true);
                else
                    qtb_at.Banco_Dados = banco;
                val.Id_atualizastr = CamadaDados.TDataQuery.getPubVariavel(qtb_at.Grava(val), "@P_ID_ATUALIZA");
                if (st_transacao)
                    qtb_at.Banco_Dados.Commit_Tran();
                return val.Id_atualizastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_at.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Atualização: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_at.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AtVenctoParcela val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AtVenctoParcela qtb_at = new TCD_AtVenctoParcela();
            try
            {
                if (banco == null)
                    st_transacao = qtb_at.CriarBanco_Dados(true);
                else
                    qtb_at.Banco_Dados = banco;
                qtb_at.Exclui(val);
                if (st_transacao)
                    qtb_at.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_at.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Atualização " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_at.deletarBanco_Dados();
            }
        }
    }
}
