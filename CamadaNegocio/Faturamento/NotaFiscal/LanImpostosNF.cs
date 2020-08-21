using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.NotaFiscal;
using Utils;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_ImpostosNF
    {
        public static TList_ImpostosNF Buscar(string Id_lancto,
                                              string Cd_empresa,
                                              string Nr_lanctofiscal,
                                              string Id_nfitem,
                                              string Nr_lanctoctr,
                                              string Cd_imposto,
                                              string Cd_historico,
                                              string Tp_movimento,
                                              string Dt_inicial,
                                              string Dt_final,
                                              string Tp_registro,
                                              bool St_aprocessar,
                                              string Id_lotefis,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lancto;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Id_nfitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfitem;
            }
            if (!string.IsNullOrEmpty(Nr_lanctoctr))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctoctr";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoctr;
            }
            if (!string.IsNullOrEmpty(Cd_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_imposto;
            }
            if (!string.IsNullOrEmpty(Cd_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "nf.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_movimento.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_inicial)) && (Dt_inicial.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "((case when nf.tp_movimento = 'E' then nf.dt_saient else nf.dt_emissao end) >= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_inicial).ToString("yyyyMMdd")) + " 00:00:00') or" +
                                                       "((case when ctrc.tp_movimento = 'E' then ctrc.DT_SaiEnt else ctrc.DT_Emissao end) >= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_inicial).ToString("yyyyMMdd")) + " 00:00:00')";
            }
            if ((!string.IsNullOrEmpty(Dt_final)) && (Dt_final.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "((case when nf.tp_movimento = 'E' then nf.dt_saient else nf.dt_emissao end) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_final).ToString("yyyyMMdd")) + " 23:59:59') or" +
                                                       "((case when ctrc.tp_movimento = 'E' then ctrc.DT_SaiEnt else ctrc.DT_Emissao end) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_final).ToString("yyyyMMdd")) + " 23:59:59')";
            }
            if (!string.IsNullOrEmpty(Tp_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.tp_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_registro.Trim() + "'";
            }
            if (St_aprocessar)
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "a.id_lotefis";
                filtro[filtro.Length - 2].vOperador = "is";
                filtro[filtro.Length - 2].vVL_Busca = "null";
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(exists(select 1 from tb_fat_serienf serie " +
                                                      "        where nf.nr_serie = serie.nr_serie " +
                                                      "        and nf.cd_modelo = serie.cd_modelo " +
                                                      "        and isnull(serie.st_gerasintegra, 'N') = 'S') or " +
                                                      "       exists(select 1 from tb_fat_serienf serie " +
                                                      "        where ctrc.nr_serie = serie.nr_serie " +
                                                      "        and ctrc.cd_modelo = serie.cd_modelo " +
                                                      "        and isnull(serie.st_gerasintegra, 'N') = 'S'))";
            }
            if (!string.IsNullOrEmpty(Id_lotefis))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lotefis";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lotefis;
            }

            return new TCD_ImpostosNF(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ImpostosNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ImpostosNF qtb_imp = new TCD_ImpostosNF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_imp.CriarBanco_Dados(true);
                else
                    qtb_imp.Banco_Dados = banco;
                string retorno = qtb_imp.Gravar(val);
                //Gravar Contabilidade Imposto Calculado
                //if (val.Vl_impostocalc > decimal.Zero && val.Nr_lanctofiscal != null)
                //{
                //    List<CamadaDados.Contabil.TRegistro_ProcImpostos> lProcImpCalc =
                //    CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscarProc_Impostos(val.Cd_empresa,
                //                                                                    val.Nr_lanctofiscal.Value.ToString(),
                //                                                                    string.Empty,
                //                                                                    string.Empty,
                //                                                                    val.Cd_impostostr,
                //                                                                    string.Empty,
                //                                                                    string.Empty,
                //                                                                    string.Empty,
                //                                                                    string.Empty,
                //                                                                    string.Empty,
                //                                                                    string.Empty,
                //                                                                    string.Empty,
                //                                                                    decimal.Zero,
                //                                                                    decimal.Zero,
                //                                                                    false,
                //                                                                    qtb_imp.Banco_Dados);
                //    if (lProcImpCalc.Count > 0)
                //        if (lProcImpCalc.Exists(p => p.Cd_contactb_deb.HasValue && p.Cd_contactb_cred.HasValue))
                //            CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Impostos(lProcImpCalc.FindAll(p => p.Cd_contactb_cred.HasValue && p.Cd_contactb_deb.HasValue), qtb_imp.Banco_Dados);
                //}
                ////Gravar Contabilidade Imposto Retido
                //if (val.Vl_impostoretido > decimal.Zero && val.Nr_lanctofiscal != null)
                //{
                //    List<CamadaDados.Contabil.TRegistro_ProcImpostos> lProcImpRet =
                //        CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscarProc_Impostos(val.Cd_empresa,
                //                                                                        val.Nr_lanctofiscal.Value.ToString(),
                //                                                                        string.Empty,
                //                                                                        string.Empty,
                //                                                                        val.Cd_impostostr,
                //                                                                        string.Empty,
                //                                                                        string.Empty,
                //                                                                        string.Empty,
                //                                                                        string.Empty,
                //                                                                        string.Empty,
                //                                                                        string.Empty,
                //                                                                        string.Empty,
                //                                                                        decimal.Zero,
                //                                                                        decimal.Zero,
                //                                                                        false,
                //                                                                        qtb_imp.Banco_Dados);
                //    if (lProcImpRet.Count > 0)
                //        if (lProcImpRet.Exists(p => p.Cd_contactb_deb.HasValue && p.Cd_contactb_cred.HasValue))
                //            CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_Impostos(lProcImpRet.FindAll(p => p.Cd_contactb_cred.HasValue && p.Cd_contactb_deb.HasValue), qtb_imp.Banco_Dados);
                //}
                if (st_transacao)
                    qtb_imp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_imp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar impostos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_imp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ImpostosNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ImpostosNF qtb_imp = new TCD_ImpostosNF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_imp.CriarBanco_Dados(true);
                else
                    qtb_imp.Banco_Dados = banco;
                qtb_imp.Excluir(val);
                if (st_transacao)
                    qtb_imp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_imp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir impostos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_imp.deletarBanco_Dados();
            }
        }

        public static void CalcValorImposto(TRegistro_ImpostosNF val,
                                            decimal Vl_TotalNota,
                                            bool st_reducaobasecalcfocus)
        {
            //Calcular valor do imposto
            if (val.Pc_reducaobasecalc > 0)
            {
                val.Vl_impostocalc = (Vl_TotalNota * ((100 - Math.Round(val.Pc_reducaobasecalc, 2)) / 100)) * ((Math.Round(val.Pc_aliquota, 2) - (Math.Round(val.Pc_aliquota, 2) * (Math.Round(val.Pc_reducaoaliquota, 2) / 100)) - Math.Round(val.Pc_retencao, 2)) / 100);
                val.Vl_impostoretido = (Vl_TotalNota * ((100 - Math.Round(val.Pc_reducaobasecalc, 2)) / 100)) * ((Math.Round(val.Pc_retencao, 2) - (Math.Round(val.Pc_retencao, 2) * (Math.Round(val.Pc_reducaoaliquota, 2) / 100))) / 100);
            }
            else
            {
                val.Vl_impostocalc = val.Vl_basecalc * ((Math.Round(val.Pc_aliquota, 2) - (Math.Round(val.Pc_aliquota, 2) * (Math.Round(val.Pc_reducaoaliquota, 2) / 100)) - Math.Round(val.Pc_retencao, 2)) / 100);
                val.Vl_impostoretido = val.Vl_basecalc * ((Math.Round(val.Pc_retencao, 2) - (Math.Round(val.Pc_retencao, 2) * (Math.Round(val.Pc_reducaoaliquota, 2) / 100))) / 100);
            }
            if (st_reducaobasecalcfocus)
                if ((val.Vl_basecalc > 0) && (val.Vl_basecalc <= Vl_TotalNota))
                    val.Vl_basecalc = (Vl_TotalNota * (1 - (val.Pc_reducaobasecalc / 100)));
            else
                if ((Vl_TotalNota > 0) && (val.Vl_basecalc > 0))
                    if (val.Vl_basecalc <= Vl_TotalNota)
                        val.Pc_reducaobasecalc = 100 - ((val.Vl_basecalc * 100) / (Vl_TotalNota));
                    else
                        val.Pc_reducaobasecalc = decimal.Zero;
        }

        public static void CalcValorImpostoSubst(TRegistro_ImpostosNF val,
                                                 decimal Vl_TotalNota,
                                                 bool st_reducaobasecalcSubstFocus)
        {
            //Calcular Vl_ICMS
            if (val.Pc_reducaobasecalcsubsttrib > 0)
                val.Vl_impostosubsttrib = Vl_TotalNota * ((100 - val.Pc_reducaobasecalcsubsttrib) / 100) * (val.Pc_aliquotasubst / 100);
            else
                val.Vl_impostosubsttrib = val.Vl_basecalcsubsttrib * 1 * (val.Pc_aliquotasubst / 100);
            if (st_reducaobasecalcSubstFocus)
                if ((val.Vl_basecalcsubsttrib > 0) && (val.Vl_basecalcsubsttrib <= Vl_TotalNota))
                    val.Vl_basecalcsubsttrib = (Vl_TotalNota * (1 - (val.Pc_reducaobasecalcsubsttrib / 100)));
            else
                if (Vl_TotalNota > 0)
                    if (val.Vl_basecalcsubsttrib <= Vl_TotalNota)
                        val.Pc_reducaobasecalcsubsttrib = 100 - ((val.Vl_basecalcsubsttrib * 100) / (Vl_TotalNota));
                    else
                        val.Pc_reducaobasecalcsubsttrib = decimal.Zero;
        }

        public static void ReprocessarImpostos(TRegistro_LanFaturamento rNf,
                                               CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete rCtrc,
                                               CamadaDados.Faturamento.PDV.TRegistro_NFCe rEcf,
                                               decimal Vl_TotalNota,
                                               BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ImpostosNF qtb_imp = new TCD_ImpostosNF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_imp.CriarBanco_Dados(true);
                else
                    qtb_imp.Banco_Dados = banco;
                TList_ImpostosNF lImp = new TList_ImpostosNF();
                if (rCtrc != null)
                {
                    //Verificar se o ctrc possui imposto processado
                    object objfiscal = new TCD_ImpostosNF(banco).BuscarEscalar(
                                            new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCtrc.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctoCTR",
                                            vOperador = "=",
                                            vVL_Busca = rCtrc.Nr_lanctoCTRC.Value.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_lotefis",
                                            vOperador = "is",
                                            vVL_Busca = "not null"
                                        }
                                    }, "1");
                    if (objfiscal != null)
                        throw new Exception("Não é permitido reprocessar impostos de conhecimento de frete com registro fiscal processado.");
                    //Buscar impostos CTRC gravados para excluir
                    lImp = Buscar(string.Empty,
                                  rCtrc.Cd_empresa,
                                  string.Empty,
                                  string.Empty,
                                  rCtrc.Nr_lanctoCTRC.Value.ToString(),
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  false,
                                  string.Empty,
                                  qtb_imp.Banco_Dados);
                }
                //Excluir impostos
                lImp.ForEach(p => Excluir(p, qtb_imp.Banco_Dados));
                //Gravar novos impostos
                if (rCtrc != null)
                {
                    rCtrc.lImpostos.ForEach(p =>
                        {
                            p.Cd_empresa = rCtrc.Cd_empresa;
                            p.Nr_lanctoctr = rCtrc.Nr_lanctoCTRC;
                            Gravar(p, qtb_imp.Banco_Dados);
                        });
                }
                else if (rNf != null)
                    rNf.ItensNota.ForEach(p => TCN_LanFaturamento_Item.AlterarFaturamentoItem(p, qtb_imp.Banco_Dados));
                else if (rEcf != null)
                    rEcf.lItem.ForEach(p => new CamadaDados.Faturamento.PDV.TCD_NFCe_Item(qtb_imp.Banco_Dados).Gravar(p));
                if (st_transacao)
                    qtb_imp.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_imp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro reprocessar impostos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_imp.deletarBanco_Dados();
            }
        }
    }
}
