using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Servicos.Cadastros;
using BancoDados;


namespace CamadaNegocio.Servicos.Cadastros
{
    public class TCN_OSE_Historico
    {
        public static TList_OSE_Historico Buscar(decimal vID_OS,
                                                 string vCD_EMPRESA,
                                                 decimal vID_Historico
                                                    )
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vID_OS > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_OS";
                filtro[filtro.Length - 1].vVL_Busca = vID_OS.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vCD_EMPRESA.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_EMPRESA + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vID_Historico > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Historico";
                filtro[filtro.Length - 1].vVL_Busca = vID_Historico.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_OSE_Historico().Select(filtro, 0, "");
        }

        public static string Gravar_Historico(TRegistro_OSE_Historico val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OSE_Historico qtb_Historico = new TCD_OSE_Historico();
            try
            {
                if (banco == null)
                {
                    qtb_Historico.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Historico.Banco_Dados = banco;
                //Gravar imagem
                string retorno = qtb_Historico.Grava(val);
                if (st_transacao)
                    qtb_Historico.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Historico.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Historico.deletarBanco_Dados();
            }
        }

        public static string Deletar_Historico(TRegistro_OSE_Historico val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OSE_Historico qtb_Historico = new TCD_OSE_Historico();
            try
            {
                if (banco == null)
                {
                    qtb_Historico.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Historico.Banco_Dados = banco;
                qtb_Historico.Deleta(val);
                if (st_transacao)
                    qtb_Historico.Banco_Dados.Commit_Tran();
                return "";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Historico.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Historico.deletarBanco_Dados();
            }
        }
    }
}
