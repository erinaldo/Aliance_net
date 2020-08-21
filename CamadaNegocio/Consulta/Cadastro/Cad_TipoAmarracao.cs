/*
 * Douglas Emanoel - 21/11/2008
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Consulta.Cadastro;
using Utils;
using BancoDados;


namespace CamadaNegocio.Consulta.Cadastro
{
    public class TCN_Cad_TipoAmarracao
    {
        public static TList_Cad_TipoAmarracao Buscar(
                                         string vID_Tipo_Amarracao,
                                         string vNm_Tipo_Amarracao,
                                         string vSigla_Amarracao,
                                         string vNm_campo,
                                         int vTop,
                                         TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];

            try
            {
                

                if (decimal.Parse(vID_Tipo_Amarracao) >0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_Tipo_Amarracao";
                    filtro[filtro.Length - 1].vVL_Busca = "" + vID_Tipo_Amarracao.Trim() + "";
                    filtro[filtro.Length - 1].vOperador = "=";
                }

            }
            catch  { 

            }



            if (vNm_Tipo_Amarracao.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nm_Tipo_Amarracao";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + vNm_Tipo_Amarracao.Replace("'", "''") + "%'";
                filtro[filtro.Length - 1].vOperador = "LIKE";
            }
            if (vSigla_Amarracao.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Sigla_Amarracao";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + vSigla_Amarracao.Replace("'", "''") + "%'";
                filtro[filtro.Length - 1].vOperador = "LIKE";
            }

            TCD_Cad_TipoAmarracao qtb_Tipo_Amarracao = new TCD_Cad_TipoAmarracao();
            return qtb_Tipo_Amarracao.Select(filtro, vTop, vNm_campo);
        }

        public static string GravarTipo_Amarracao(TRegistro_Cad_TipoAmarracao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_TipoAmarracao qtb_Tipo_Amarracao = new TCD_Cad_TipoAmarracao();
            try
            {
                if (banco == null)
                {
                    qtb_Tipo_Amarracao.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Tipo_Amarracao.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_Tipo_Amarracao.GravarTipo_Amarracao(val);
                if (st_transacao)
                    qtb_Tipo_Amarracao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Tipo_Amarracao.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Tipo_Amarracao.deletarBanco_Dados();
            }
        }

        public static string DeletarTipo_Amarracao(TRegistro_Cad_TipoAmarracao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_TipoAmarracao qtb_Tipo_Amarracao = new TCD_Cad_TipoAmarracao();
            try
            {
                if (banco == null)
                {
                    qtb_Tipo_Amarracao.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Tipo_Amarracao.Banco_Dados = banco;
                //Deletar Uf
                qtb_Tipo_Amarracao.DeletarTipo_Amarracao(val);
                if (st_transacao)
                    qtb_Tipo_Amarracao.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Tipo_Amarracao.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Tipo_Amarracao.deletarBanco_Dados();
            }
        }
    }
}
