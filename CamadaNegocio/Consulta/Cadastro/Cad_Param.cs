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
    public class TCN_Cad_Param
    {
        public static TList_Cad_Param Buscar(decimal vID_Param,
                                             decimal vID_Consulta,
                                             int vTop,
                                             TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (vID_Param > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_ParamClasse";
                filtro[filtro.Length - 1].vVL_Busca = "" + vID_Param.ToString() + "";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vID_Consulta > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Consulta";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vID_Consulta + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            
            TCD_Cad_Param qtb_Param = new TCD_Cad_Param();
            return qtb_Param.Select(filtro, vTop, "");
        }

        public static string GravarParam(TRegistro_Cad_Param val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_Param qtb_Param = new TCD_Cad_Param();
            try
            {
                if (banco == null)
                {
                    qtb_Param.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Param.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_Param.GravarParam(val);
                if (st_transacao)
                    qtb_Param.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Param.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Param.deletarBanco_Dados();
            }
        }

        public static string DeletarParam(TRegistro_Cad_Param val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_Param qtb_Param = new TCD_Cad_Param();
            try
            {
                if (banco == null)
                {
                    qtb_Param.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Param.Banco_Dados = banco;
                //Deletar Uf
                qtb_Param.DeletarParam(val);
                if (st_transacao)
                    qtb_Param.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Param.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Param.deletarBanco_Dados();
            }
        }
    }
}
