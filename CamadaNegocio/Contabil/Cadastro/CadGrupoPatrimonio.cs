using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Contabil.Cadastro;
using BancoDados;
using Utils;

namespace CamadaNegocio.Contabil.Cadastro
{
    public class TCN_CadGrupoPatrimonio
    {
        public static TList_CadGrupoPatrimonio Busca(string vID_GrupoPatrim )
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vID_GrupoPatrim.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_GrupoPatrim";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_GrupoPatrim;
            }


            TCD_CadGrupoPatrimonio qtb_CadGrupoPatrimonio = new TCD_CadGrupoPatrimonio();
            return qtb_CadGrupoPatrimonio.Select(vBusca, 0, "");
        }

        public static string Grava_GrupoPatrimonio(TRegistro_CadGrupoPatrimonio val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadGrupoPatrimonio qtb_GrupoPatrimonio = new TCD_CadGrupoPatrimonio();
            try
            {
                if (banco == null)
                {
                    qtb_GrupoPatrimonio.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_GrupoPatrimonio.Banco_Dados = banco;

                string retorno = qtb_GrupoPatrimonio.Grava(val);
                if (st_transacao)
                    qtb_GrupoPatrimonio.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_GrupoPatrimonio.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_GrupoPatrimonio.deletarBanco_Dados();
            }
        }

        public static string Deleta_GrupoPatrimonio(TRegistro_CadGrupoPatrimonio val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadGrupoPatrimonio qtb_GrupoPatrimonio = new TCD_CadGrupoPatrimonio();
            try
            {
                if (banco == null)
                {
                    qtb_GrupoPatrimonio.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_GrupoPatrimonio.Banco_Dados = banco;

                string retorno = qtb_GrupoPatrimonio.Deleta(val);
                if (st_transacao)
                    qtb_GrupoPatrimonio.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_GrupoPatrimonio.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_GrupoPatrimonio.deletarBanco_Dados();
            }

        }
    }
}
