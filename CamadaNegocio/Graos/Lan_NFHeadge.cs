using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    #region "LAN NFHEADGE"

        public class TCN_Lan_NFHeadge
        {
            public static TList_Lan_NFHeadge Buscar(decimal vID_LanctoHeage,
                                                    decimal vID_Headge,
                                                    string vCD_Empresa,
                                                    decimal vNr_LanctoFiscal,
                                                    decimal vID_NFItem,
                                                    decimal vNr_LanctoFiscalSaida,
                                                    string vNM_Proc)
            {

                TpBusca[] filtro = new TpBusca[0];

                if ((vID_LanctoHeage > 0))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_LanctoHeage";
                    filtro[filtro.Length - 1].vVL_Busca = vID_LanctoHeage.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vID_Headge > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_Headge";
                    filtro[filtro.Length - 1].vVL_Busca = vID_Headge.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vNr_LanctoFiscal > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.Nr_LanctoFiscal";
                    filtro[filtro.Length - 1].vVL_Busca = vNr_LanctoFiscal.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vCD_Empresa.Trim() != "")
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.ToString() + "'";
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vID_NFItem > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_NFItem";
                    filtro[filtro.Length - 1].vVL_Busca = vID_NFItem.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if ((vNr_LanctoFiscalSaida > 0) && (vNM_Proc != ""))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "e.nr_lanctofiscal";
                    filtro[filtro.Length - 1].vVL_Busca = ""+vNr_LanctoFiscalSaida.ToString()+"";
                    filtro[filtro.Length - 1].vOperador = "=";
                }

                return new TCD_Lan_NFHeadge(vNM_Proc).Select(filtro, 0, "");
            }

            public static TList_Lan_NFHeadge Buscar(decimal vNr_LanctoFiscal)
            {

                TpBusca[] filtro = new TpBusca[0];

                if ((vNr_LanctoFiscal > 0))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.Nr_LanctoFiscal";
                    filtro[filtro.Length - 1].vVL_Busca = vNr_LanctoFiscal.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                
                return new TCD_Lan_NFHeadge().SelectTotais(filtro, 0, "");
            }

            public static TList_Lan_NFHeadge Buscar(decimal vNr_LanctoFiscal,
                                                    decimal vID_NFItem,
                                                    string vNM_Proc,
                                                    decimal vQuantidade,
                                                    decimal vValor,
                                                    decimal vID_Originacao)
            {

                TpBusca[] filtro = new TpBusca[0];

                if ((vNr_LanctoFiscal > 0))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.Nr_LanctoFiscal";
                    filtro[filtro.Length - 1].vVL_Busca = vNr_LanctoFiscal.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vID_NFItem > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_NFItem";
                    filtro[filtro.Length - 1].vVL_Busca = vID_NFItem.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }

                return new TCD_Lan_NFHeadge(vNM_Proc).SelectLanctoHeadge(filtro, 0, "", vQuantidade, vValor, vID_Originacao);
            }

            public static string GravarNFHeadge(TRegistro_Lan_NFHeadge val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Lan_NFHeadge qtb_NFHeadge = new TCD_Lan_NFHeadge();
                try
                {
                    if (banco == null)
                    {
                        qtb_NFHeadge.CriarBanco_Dados(true);
                        st_transacao = true;
                        banco = qtb_NFHeadge.Banco_Dados;
                    }
                    else
                        qtb_NFHeadge.Banco_Dados = banco;

                    string retorno = qtb_NFHeadge.Grava(val);

                    TRegistro_Cad_OriginacaoCustoHeadge Reg_Cad_OriginacaoCustoHeadge = new TRegistro_Cad_OriginacaoCustoHeadge();
                    Reg_Cad_OriginacaoCustoHeadge.ID_LanctoHeadge = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LANCTOHEADGE"));
                    Reg_Cad_OriginacaoCustoHeadge.ID_Originacao = val.ID_Originacao;
                    Reg_Cad_OriginacaoCustoHeadge.ID_Headge = val.ID_Headge;

                    TCN_Cad_OriginacaoCustoHeadge.GravarOriginacaoCustoHeadge(Reg_Cad_OriginacaoCustoHeadge, banco);

                    if (st_transacao)
                        qtb_NFHeadge.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_NFHeadge.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_NFHeadge.deletarBanco_Dados();
                }
            }

            public static string GravarNFHeadge(TList_Lan_NFHeadge val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Lan_NFHeadge qtb_NFHeadge = new TCD_Lan_NFHeadge();
                try
                {
                    if (banco == null)
                    {
                        qtb_NFHeadge.CriarBanco_Dados(true);
                        st_transacao = true;
                        banco = qtb_NFHeadge.Banco_Dados;
                    }
                    else
                        qtb_NFHeadge.Banco_Dados = banco;

                    string retorno = "";

                    //DELETE OS LANCTO SE TIVER
                    qtb_NFHeadge.DeletaTodos(val[0]);
                    foreach (TRegistro_Lan_NFHeadge reg in val)
                    {
                        retorno = qtb_NFHeadge.Grava(reg);

                        TRegistro_Cad_OriginacaoCustoHeadge Reg_Cad_OriginacaoCustoHeadge = new TRegistro_Cad_OriginacaoCustoHeadge();
                        Reg_Cad_OriginacaoCustoHeadge.ID_LanctoHeadge = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LANCTOHEADGE"));
                        Reg_Cad_OriginacaoCustoHeadge.ID_Originacao = reg.ID_Originacao;
                        Reg_Cad_OriginacaoCustoHeadge.ID_Headge = reg.ID_Headge;

                        TCN_Cad_OriginacaoCustoHeadge.GravarOriginacaoCustoHeadge(Reg_Cad_OriginacaoCustoHeadge, banco);
                    }

                    if (st_transacao)
                        qtb_NFHeadge.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_NFHeadge.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_NFHeadge.deletarBanco_Dados();
                }
            }

            public static string AlterarNFHeadge(TRegistro_Lan_NFHeadge val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Lan_NFHeadge qtb_NFHeadge = new TCD_Lan_NFHeadge();
                try
                {
                    if (banco == null)
                    {
                        qtb_NFHeadge.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_NFHeadge.Banco_Dados = banco;

                    string retorno = qtb_NFHeadge.Alterar(val);

                    if (st_transacao)
                        qtb_NFHeadge.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_NFHeadge.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_NFHeadge.deletarBanco_Dados();
                }
            }

            public static string AlterarNFHeadge(TList_Lan_NFHeadge val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Lan_NFHeadge qtb_NFHeadge = new TCD_Lan_NFHeadge();
                try
                {
                    if (banco == null)
                    {
                        qtb_NFHeadge.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_NFHeadge.Banco_Dados = banco;

                    string retorno = "";
                    foreach (TRegistro_Lan_NFHeadge reg in val)
                        retorno += qtb_NFHeadge.Alterar(reg);

                    if (st_transacao)
                        qtb_NFHeadge.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_NFHeadge.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_NFHeadge.deletarBanco_Dados();
                }
            }

            public static string DeletarNFHeadge(TRegistro_Lan_NFHeadge val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Lan_NFHeadge qtb_NFHeadge = new TCD_Lan_NFHeadge();
                try
                {
                    if (banco == null)
                    {
                        qtb_NFHeadge.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_NFHeadge.Banco_Dados = banco;
                    qtb_NFHeadge.Deleta(val);
                    if (st_transacao)
                        qtb_NFHeadge.Banco_Dados.Commit_Tran();
                    return "OK";
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_NFHeadge.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_NFHeadge.deletarBanco_Dados();
                }
            }
        }

    #endregion
}
