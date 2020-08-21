using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Contabil.Cadastro;
using BancoDados;
using Utils;

namespace CamadaNegocio.Contabil.Cadastro
{
    public class TCN_CadPatrimonio
    {
        public static TList_CadPatrimonio Busca(string vID_Patrimonio)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vID_Patrimonio.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Patrimonio";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Patrimonio;
            }


            TCD_CadPatrimonio qtb_CadPatrimonio = new TCD_CadPatrimonio();
            return qtb_CadPatrimonio.Select(vBusca, 0, "");
        }

        public static string Grava_Patrimonio(TRegistro_CadPatrimonio val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPatrimonio qtb_Patrimonio = new TCD_CadPatrimonio();
            try
            {
                if (banco == null)
                {
                    qtb_Patrimonio.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Patrimonio.Banco_Dados = banco;

                string retorno = qtb_Patrimonio.Grava(val);
                if (st_transacao)
                    qtb_Patrimonio.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Patrimonio.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Patrimonio.deletarBanco_Dados();
            }
        }

        public static string Deleta_Patrimonio(TRegistro_CadPatrimonio val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPatrimonio qtb_Patrimonio = new TCD_CadPatrimonio();
            try
            {
                if (banco == null)
                {
                    qtb_Patrimonio.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Patrimonio.Banco_Dados = banco;

                string retorno = qtb_Patrimonio.Deleta(val);
                if (st_transacao)
                    qtb_Patrimonio.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Patrimonio.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Patrimonio.deletarBanco_Dados();
            }

        }
    }
}
