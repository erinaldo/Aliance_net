using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Contrato;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using Utils;

namespace CamadaNegocio.Financeiro.Contrato
{
    #region Contrato Financeiro
    public class TCN_ContratoFin
    {
        public static TList_ContratoFin Buscar(string Nr_contrato,
                                               string Nr_contratoOrigem,
                                               string Cd_empresa,
                                               string Cd_clifor,
                                               string Nr_lancto,
                                               string vTp_data,
                                               string Dt_ini,
                                               string Dt_fin,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Nr_contratoOrigem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contratoOrigem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_contratoOrigem.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_lancto";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            if (Dt_ini.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("C") ? "a.dt_contrato" : vTp_data.Trim().ToUpper().Equals("V") ? "a.dt_vencimento" : string.Empty) + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (Dt_fin.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("C") ? "a.dt_contrato" : vTp_data.Trim().ToUpper().Equals("V") ? "a.dt_vencimento" : string.Empty) + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }

            return new TCD_ContratoFin(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDup(string Cd_empresa,
                                                                                       string Nr_contrato,
                                                                                       BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_FIN_ContratoFin x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.nr_contrato = '" + Nr_contrato.Trim() + "')"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ContratoFin val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ContratoFin qtb_contr = new TCD_ContratoFin();
            try
            {
                if (banco == null)
                    st_transacao = qtb_contr.CriarBanco_Dados(true);
                else
                    qtb_contr.Banco_Dados = banco;
                //Gravar Emprestimo
                val.NR_ContratoStr = CamadaDados.TDataQuery.getPubVariavel(qtb_contr.Gravar(val), "@P_NR_CONTRATO");
                //Excluir
                val.lParcDel.ForEach(p => TCN_ParcelaContrato.Excluir(p, qtb_contr.Banco_Dados));
                //Gravar
                val.lParc.ForEach(p=> 
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.NR_Contrato = val.NR_Contrato;
                        TCN_ParcelaContrato.Gravar(p, qtb_contr.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_contr.Banco_Dados.Commit_Tran();
                return val.NR_ContratoStr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contr.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ContratoFin val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ContratoFin qtb_contr = new TCD_ContratoFin();
            try
            {
                if (banco == null)
                    st_transacao = qtb_contr.CriarBanco_Dados(true);
                else
                    qtb_contr.Banco_Dados = banco;
                //Excluir Parcelas
                val.lParc.ForEach(p=> TCN_ParcelaContrato.Excluir(p,qtb_contr.Banco_Dados));
                //Excluir Contrato
                qtb_contr.Excluir(val);
                if (st_transacao)
                    qtb_contr.Banco_Dados.Commit_Tran();
                return val.NR_ContratoStr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contr.deletarBanco_Dados();
            }
        }

        public static string ProcessarContratoFin(TRegistro_ContratoFin val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ContratoFin qtb_contr = new TCD_ContratoFin();
            try
            {
                if (banco == null)
                    st_transacao = qtb_contr.CriarBanco_Dados(true);
                else
                    qtb_contr.Banco_Dados = banco;
                //Gravar Duplicata
                if (val.Nr_lancto == null && val.lDup.Count > 0)
                {
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.lDup, false, qtb_contr.Banco_Dados);
                    val.Nr_lancto = val.lDup[0].Nr_lancto;
                    TCN_ContratoFin.Gravar(val, qtb_contr.Banco_Dados);
                    val.lParc.ForEach(p =>
                        {
                            p.St_registro = "P";
                            p.Cd_empresa = val.Cd_empresa;
                            p.NR_Contrato = val.NR_Contrato;
                            CamadaNegocio.Financeiro.Contrato.TCN_ParcelaContrato.Gravar(p, qtb_contr.Banco_Dados);
                        });
                }
                if (st_transacao)
                    qtb_contr.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contr.deletarBanco_Dados();
            }
        }

        public static string EstornarProcessamento(TRegistro_ContratoFin val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ContratoFin qtb_contr = new TCD_ContratoFin();
            try
            {
                if (banco == null)
                    st_transacao = qtb_contr.CriarBanco_Dados(true);
                else
                    qtb_contr.Banco_Dados = banco;
                //Excluir duplicata
                //Verificar se usuario tem permissão para excluir duplicata
                if (Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim().ToUpper(), "PERMITIR EXCLUSAO DE DOCUMENTO FINANCEIRO", banco))
                {
                    //Verificar se o usuario tem acesso a tela de duplicata
                    if ((CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Financeiro.TFLanContas") == null) &&
                        (!Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER")) &&
                        (!Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV")))
                        throw new Exception("Não é permitido estornar contrato com movimentação financeira.\r\n" +
                                            "Para estornar contrato é necessário cancelar primeiro o financeiro.");
                    else
                    {
                        val.Nr_lancto = null;
                        TCN_ContratoFin.Gravar(val, qtb_contr.Banco_Dados);
                          val.lParc.ForEach(p=>  
                              {
                                  //Alterar Parcelas para Aberta
                                  p.St_registro = "A";
                                  TCN_ParcelaContrato.Gravar(p, qtb_contr.Banco_Dados);
                              });
                          //Cancelar Duplicata
                          val.lDup.ForEach(v=> CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(v, qtb_contr.Banco_Dados));
                    }
                }
                else
                    throw new Exception("Usuário não tem permissão para cancelar Duplicata!");
                if (st_transacao)
                    qtb_contr.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contr.deletarBanco_Dados();
            }

        }

        public static TList_ParcelaContrato Calcula_Parcelas(TRegistro_ContratoFin val)
        {
            TList_ParcelaContrato retorno = new TList_ParcelaContrato();
            if ((val.Vl_Contrato > 0) && (val.QTD_parcelas > 0))
            {
                TList_Parcelas Lista_Parcela = TLanCalcParcelas.CalcularParcelas(val.Vl_Contrato,
                                                                                 val.Vl_Contrato,
                                                                                 val.Dt_contrato.Value,
                                                                                 val.QTD_parcelas,
                                                                                 val.QTD_diasdesdobro);
                Lista_Parcela.ForEach(p =>
                {
                    retorno.Add(
                        new CamadaDados.Financeiro.Contrato.TRegistro_ParcelaContrato()
                        {
                            Dt_venctoProvisaostr = p.Dt_vencimentostr,
                            Vl_parcProvisao = p.Vl_parcela
                        });
                });
            }
            return retorno;
        }

        public static void RecalculaParc(TList_ParcelaContrato lParc,
                                         decimal Vl_documento,
                                         int index)
        {
            if (lParc.Sum(p => p.Vl_parcProvisao) != Vl_documento)
            {
                decimal vl_parc = Math.Round((Vl_documento - lParc.Sum(p => p.Vl_parcProvisao)) / (lParc.Count - index - 1), 2);
                for (int i = ++index; i < lParc.Count; i++)
                    lParc[i].Vl_parcProvisao += vl_parc;
                lParc[lParc.Count - 1].Vl_parcProvisao += Vl_documento - lParc.Sum(p => p.Vl_parcProvisao);
            }
        }

        public static void RecalcDiaVencto(TList_ParcelaContrato val, decimal Qtd_desdobro, int index)
        {
            for (int i = (index + 1); i < val.Count; i++)
                val[i].Dt_venctoProvisao = val[i - 1].Dt_venctoProvisao.Value.AddDays(Convert.ToDouble(Qtd_desdobro));
        }
    }
    #endregion

    #region Parcela contrato
    public class TCN_ParcelaContrato
    {
        public static TList_ParcelaContrato Buscar(string Nr_contrato,
                                                      string Cd_empresa,
                                                      string Id_parcela,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_parcela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_parcela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_parcela;
            }
            return new TCD_ParcelaContrato(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ParcelaContrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ParcelaContrato qtb_parc = new TCD_ParcelaContrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_parc.CriarBanco_Dados(true);
                else
                    qtb_parc.Banco_Dados = banco;
                string retorno = qtb_parc.Gravar(val);
                if (st_transacao)
                    qtb_parc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_parc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar parcela contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_parc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ParcelaContrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ParcelaContrato qtb_parc = new TCD_ParcelaContrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_parc.CriarBanco_Dados(true);
                else
                    qtb_parc.Banco_Dados = banco;
                qtb_parc.Excluir(val);
                if (st_transacao)
                    qtb_parc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_parc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro exclui parcela contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_parc.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
