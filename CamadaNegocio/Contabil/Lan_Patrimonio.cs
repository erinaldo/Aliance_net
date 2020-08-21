using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BancoDados;
using CamadaDados.Contabil;
using Utils;
using System.Data;

namespace CamadaNegocio.Contabil
{
    public class TCN_LanPatrimonio
    {
        public static TList_LanPatrimonio Busca(string vID_Patrimonio, 
                                                string vID_Lancto,
                                                string vCD_Empresa,
                                                string vDT_Inicio,
                                                string vDT_Final,
                                                bool vFiltroReprocessa,
                                                bool vST_Reprocessa,
                                                decimal vID_LoteCTB,
                                                string vTipo)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vID_Patrimonio.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Patrimonio";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Patrimonio;
            }
            if (vTipo.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Lancto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTipo.Trim() + "'";
            }

            if (vID_Lancto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Lancto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Lancto;
            }
            if (vDT_Inicio.Trim() != "" && vDT_Inicio != "  /  /")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Lancto";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDT_Inicio.Trim() + "'";
            }
            if (vDT_Final.Trim() != "" && vDT_Final != "  /  /")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Lancto";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDT_Final.Trim() + "'";
            }
            if (vCD_Empresa.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (vFiltroReprocessa)
            {
                if (vST_Reprocessa)
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                    vBusca[vBusca.Length - 1].vOperador = "is";
                    vBusca[vBusca.Length - 1].vVL_Busca = "not null";
                }
                else
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                    vBusca[vBusca.Length - 1].vOperador = "is";
                    vBusca[vBusca.Length - 1].vVL_Busca = "null";
                }
            }

            TCD_LanPatrimonio qtb_LanPatrimonio = new TCD_LanPatrimonio();
            return qtb_LanPatrimonio.Select(vBusca, 0, "");
        }

        public static string Grava_LanPatrimonio(TRegistro_LanPatrimonio val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPatrimonio qtb_LanPatrimonio = new TCD_LanPatrimonio();
            try
            {
                if (banco == null)
                {
                    qtb_LanPatrimonio.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_LanPatrimonio.Banco_Dados = banco;

                string retorno = qtb_LanPatrimonio.Grava(val);
                if (st_transacao)
                    qtb_LanPatrimonio.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_LanPatrimonio.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_LanPatrimonio.deletarBanco_Dados();
            }
        }

        public static string Deleta_LanPatrimonio(TRegistro_LanPatrimonio val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPatrimonio qtb_LanPatrimonio = new TCD_LanPatrimonio();
            try
            {
                if (banco == null)
                {
                    qtb_LanPatrimonio.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_LanPatrimonio.Banco_Dados = banco;

                string retorno = qtb_LanPatrimonio.Deleta(val);
                if (st_transacao)
                    qtb_LanPatrimonio.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_LanPatrimonio.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_LanPatrimonio.deletarBanco_Dados();
            }

        }

        public static DataTable Busca_TodosPatrimonios(string vDT_Lancto, string vID_GrupoPatrim)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vDT_Lancto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Lancto";
                vBusca[vBusca.Length - 1].vOperador = "<";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_Lancto).ToString("yyyyMMdd")) + "'";
                
            }
            
            if (vID_GrupoPatrim.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_GrupoPatrim";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_GrupoPatrim.Trim();
            }

            TCD_LanPatrimonio qtb_LanPatrimonio = new TCD_LanPatrimonio();
            return qtb_LanPatrimonio.SqlCodeBusca_LanTodosPatrimonios(vBusca, 
                "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_Lancto).ToString("yyyyMMdd")) + "'", 0, "");
        }

        public static string Grava_LanPatrimonio_Lista(TList_LanPatrimonio val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPatrimonio qtb_LanPatrimonio = new TCD_LanPatrimonio();
            try
            {
                if (banco == null)
                {
                    qtb_LanPatrimonio.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_LanPatrimonio.Banco_Dados = banco;
                
                for (int x = 0; x < val.Count; x++)
                {
                    Grava_LanPatrimonio(val[x], qtb_LanPatrimonio.Banco_Dados);
                }

                if (st_transacao)
                    qtb_LanPatrimonio.Banco_Dados.Commit_Tran();
                return "";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_LanPatrimonio.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_LanPatrimonio.deletarBanco_Dados();
            }
        }
        
    }
}
