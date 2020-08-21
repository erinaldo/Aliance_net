using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Consulta.Cadastro;
using Utils;
using BancoDados;

namespace CamadaNegocio.Consulta.Cadastro
{
    public class TCN_Cad_Report_X_Consulta
    {
        public static TList_Cad_Report_X_Consulta Buscar(decimal vID_Report,
                                                         string vID_Consulta)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (vID_Report > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Report";
                filtro[filtro.Length - 1].vVL_Busca = "" + vID_Report.ToString() + "";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vID_Consulta.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Consulta";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vID_Consulta.ToString() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            TCD_Cad_Report_X_Consulta qtb_Report_X_Consulta = new TCD_Cad_Report_X_Consulta();
            return qtb_Report_X_Consulta.Select(filtro, 0, "");
        }

        public static string GravarReport_X_Consulta(TRegistro_Cad_Report_X_Consulta val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_Report_X_Consulta qtb_Report_X_Consulta = new TCD_Cad_Report_X_Consulta();
            try
            {
                if (banco == null)
                {
                    qtb_Report_X_Consulta.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Report_X_Consulta.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_Report_X_Consulta.GravarReport_X_Consulta(val);
                if (st_transacao)
                    qtb_Report_X_Consulta.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Report_X_Consulta.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Report_X_Consulta.deletarBanco_Dados();
            }
        }

        public static string DeletarReport_X_Consulta(TRegistro_Cad_Report_X_Consulta val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_Report_X_Consulta qtb_Report_X_Consulta = new TCD_Cad_Report_X_Consulta();
            try
            {
                if (banco == null)
                {
                    qtb_Report_X_Consulta.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Report_X_Consulta.Banco_Dados = banco;
                //Deletar Uf
                qtb_Report_X_Consulta.DeletarReport_X_Consulta(val);
                if (st_transacao)
                    qtb_Report_X_Consulta.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Report_X_Consulta.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Report_X_Consulta.deletarBanco_Dados();
            }
        }
    }
}
