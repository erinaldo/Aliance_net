using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.WS_RDC;
using Utils;
using BancoDados;

namespace CamadaNegocio.WS_RDC
{
    public class TCN_Cad_RDC_X_DataSource
    {
        public static TList_Cad_RDC_X_DataSource Buscar(decimal vID_RDC,
                                                         decimal vID_DataSource)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (vID_RDC > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_RDC";
                filtro[filtro.Length - 1].vVL_Busca = "" + vID_RDC.ToString() + "";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vID_DataSource > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_DataSource";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vID_DataSource.ToString() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            TCD_Cad_RDC_X_DataSource qtb_RDC_X_DataSource = new TCD_Cad_RDC_X_DataSource();
            return qtb_RDC_X_DataSource.Select(filtro, 0, "");
        }

        public static string GravarRDC_X_DataSource(TRegistro_Cad_RDC_X_DataSource val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_RDC_X_DataSource qtb_RDC_X_DataSource = new TCD_Cad_RDC_X_DataSource();
            try
            {
                if (banco == null)
                {
                    qtb_RDC_X_DataSource.CriarBanco_Dados(true);
                    st_transacao = true;
                    banco = qtb_RDC_X_DataSource.Banco_Dados;
                }
                else
                    qtb_RDC_X_DataSource.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_RDC_X_DataSource.GravarRDC_X_DataSource(val);
                if (st_transacao)
                    qtb_RDC_X_DataSource.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_RDC_X_DataSource.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_RDC_X_DataSource.deletarBanco_Dados();
            }
        }

        public static string DeletarRDC_X_DataSource(TRegistro_Cad_RDC_X_DataSource val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_RDC_X_DataSource qtb_RDC_X_DataSource = new TCD_Cad_RDC_X_DataSource();
            try
            {
                if (banco == null)
                {
                    qtb_RDC_X_DataSource.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_RDC_X_DataSource.Banco_Dados = banco;
                //Deletar Uf
                qtb_RDC_X_DataSource.DeletarRDC_X_DataSource(val);
                if (st_transacao)
                    qtb_RDC_X_DataSource.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_RDC_X_DataSource.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_RDC_X_DataSource.deletarBanco_Dados();
            }
        }

        public static string DeletarRDCPorRDC(string vID_RDC, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_RDC_X_DataSource qtb_RDC_X_DataSource = new TCD_Cad_RDC_X_DataSource();
            try
            {
                if (banco == null)
                {
                    qtb_RDC_X_DataSource.CriarBanco_Dados(true);
                    st_transacao = true;
                    banco = qtb_RDC_X_DataSource.Banco_Dados;
                }
                else
                    qtb_RDC_X_DataSource.Banco_Dados = banco;
                
                qtb_RDC_X_DataSource.DeletarRDCPorRDC(vID_RDC);
                if (st_transacao)
                    qtb_RDC_X_DataSource.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_RDC_X_DataSource.Banco_Dados.RollBack_Tran();
                else
                    return ex.Message;
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_RDC_X_DataSource.deletarBanco_Dados();
            }
        }
    }
}
