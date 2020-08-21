using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    #region "Originacao_x_CUSTOHeadge"

        public class TCN_Cad_OriginacaoCustoHeadge
        {
            public static TList_Cad_OriginacaoCustoHeadge Buscar(decimal vID_Originacao,
                                                                 decimal vID_Headge,
                                                                 decimal vID_LanctoHeadge,
                                                                 int vTop,
                                                                 TObjetoBanco banco)
            {

                TpBusca[] filtro = new TpBusca[0];

                if ((vID_Originacao > 0))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_Originacao";
                    filtro[filtro.Length - 1].vVL_Busca = vID_Originacao.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vID_Headge > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_Headge";
                    filtro[filtro.Length - 1].vVL_Busca = vID_Headge.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }
                if (vID_LanctoHeadge > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_LanctoHeadge";
                    filtro[filtro.Length - 1].vVL_Busca = vID_LanctoHeadge.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }

                return new TCD_Cad_OriginacaoCustoHeadge().Select(filtro, vTop, "");
            }

            public static string GravarOriginacaoCustoHeadge(TRegistro_Cad_OriginacaoCustoHeadge val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Cad_OriginacaoCustoHeadge qtb_OriginacaoCustoHeadge = new TCD_Cad_OriginacaoCustoHeadge();
                try
                {
                    if (banco == null)
                    {
                        qtb_OriginacaoCustoHeadge.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_OriginacaoCustoHeadge.Banco_Dados = banco;

                    string retorno = qtb_OriginacaoCustoHeadge.Grava(val);

                    if (st_transacao)
                        qtb_OriginacaoCustoHeadge.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_OriginacaoCustoHeadge.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_OriginacaoCustoHeadge.deletarBanco_Dados();
                }
            }

            public static string DeletarOriginacaoCustoHeadge(TRegistro_Cad_OriginacaoCustoHeadge val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_Cad_OriginacaoCustoHeadge qtb_OriginacaoCustoHeadge = new TCD_Cad_OriginacaoCustoHeadge();
                try
                {
                    if (banco == null)
                    {
                        qtb_OriginacaoCustoHeadge.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_OriginacaoCustoHeadge.Banco_Dados = banco;
                    qtb_OriginacaoCustoHeadge.Deleta(val);
                    if (st_transacao)
                        qtb_OriginacaoCustoHeadge.Banco_Dados.Commit_Tran();
                    return "OK";
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_OriginacaoCustoHeadge.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (st_transacao)
                        qtb_OriginacaoCustoHeadge.deletarBanco_Dados();
                }
            }
        }

    #endregion
}
