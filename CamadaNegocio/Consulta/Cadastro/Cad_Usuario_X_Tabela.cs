/*
 * Douglas Emanoel - 21/11/2008
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Consulta.Cadastro;
using Utils;

namespace CamadaNegocio.Consulta.Cadastro
{
    public class TCN_Cad_Usuario_X_Tabela
    {
        public static TList_Cad_Usuario_X_Tabela Busca(string vLogin, string vNMTabela, string vNMTabelaDiferente)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vLogin.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.login";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vLogin + "%'";
            }
            if (vNMTabela.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_Tabela";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vNMTabela + "%'";
            }
            if (vNMTabelaDiferente.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_Tabela";
                vBusca[vBusca.Length - 1].vOperador = "<>";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNMTabelaDiferente + "'";
            }

            TCD_Cad_Usuario_X_Tabela cd = new TCD_Cad_Usuario_X_Tabela();
            return cd.Select(vBusca, 0, "");
        }

        public static string GravaUsuario_X_Tabela(TList_Cad_Usuario_X_Tabela listaUsuarioXTabela, string vD_Clifor, string vLogin)
        {
            bool pode_comitar = false;
            string ret = "";

            TCD_Cad_Usuario_X_Tabela cd = new TCD_Cad_Usuario_X_Tabela();
            cd.CriarBanco_Dados(true);
            pode_comitar = true;

            try
            {
                //COMEÇA A TRANSAÇÃO PARA GRAVAR OS VALORES
                TRegistro_Cad_Usuario_X_Tabela registroUsuarioXTabela = new TRegistro_Cad_Usuario_X_Tabela();
               

                for (int i = 0; i < listaUsuarioXTabela.Count; i++)
                {
                   ret= cd.Grava(listaUsuarioXTabela[i]);
                }

                if (pode_comitar)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (pode_comitar)
                    cd.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (pode_comitar)
                    cd.deletarBanco_Dados();
            }
            return ret;
        }


        public static string GravaUsuario_X_Tabela(TRegistro_Cad_Usuario_X_Tabela val)
        {
            TCD_Cad_Usuario_X_Tabela CD = new TCD_Cad_Usuario_X_Tabela();
            return CD.Grava(val);
        }

        public static string DeletaUsuario_X_Tabela(TRegistro_Cad_Usuario_X_Tabela val)
        {
            TCD_Cad_Usuario_X_Tabela CD = new TCD_Cad_Usuario_X_Tabela();
            return CD.Deleta(val);
        }

        public static string DeletaUsuario_X_Tabela(TList_Cad_Usuario_X_Tabela listaUsuarioXTabela, string vD_Clifor, string vLogin)
        {
            bool pode_comitar = false;
            string ret = "";

            TCD_Cad_Usuario_X_Tabela cd = new TCD_Cad_Usuario_X_Tabela();
            cd.CriarBanco_Dados(true);
            pode_comitar = true;

            try
            {
                //COMEÇA A TRANSAÇÃO PARA GRAVAR OS VALORES
                TRegistro_Cad_Usuario_X_Tabela registroUsuarioXTabela = new TRegistro_Cad_Usuario_X_Tabela();
                //cd.DeletaTodos(registroUsuarioXTabela);

                for (int i = 0; i < listaUsuarioXTabela.Count; i++)
                {
                    ret = cd.Deleta(listaUsuarioXTabela[i]);
                }

                if (pode_comitar)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (pode_comitar)
                    cd.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (pode_comitar)
                    cd.deletarBanco_Dados();
            }
            return ret;
        }

    }
}
