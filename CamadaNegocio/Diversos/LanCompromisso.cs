using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_LanCompromisso
    {
        public static TList_LanCompromisso Busca(string vIdCompromisso, 
                                                 string vNmCompromisso,
                                                 string vDs_Compromisso, 
                                                 string vDtInicio,
                                                 string vDtFinal, 
                                                 string vUsuarioCompromisso, 
                                                 string vStCompromisso,
                                                 BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vIdCompromisso))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "Id_Compromisso";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vIdCompromisso + "'";

            }
            if (!string.IsNullOrEmpty(vUsuarioCompromisso))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "UsuarioCompromisso";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vUsuarioCompromisso + "%'";
            }
            if (!string.IsNullOrEmpty(vNmCompromisso))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "Nm_Compromisso";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vNmCompromisso + "%'";
            }
            if ((!string.IsNullOrEmpty(vDtInicio)) && (vDtInicio.Trim() != "/  /       :"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "dt_Compromisso";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDtInicio).ToString("yyyyMMdd HH:mm:ss")) + "'";
            }
            if ((!string.IsNullOrEmpty(vDtFinal)) && (vDtFinal.Trim() != "/  /       :"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "dt_Compromisso";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDtFinal).ToString("yyyyMMdd HH:mm:ss")) + "'";
            }
            if (!string.IsNullOrEmpty(vStCompromisso))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "st_Compromisso";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + vStCompromisso + ")";
            }
            return new TCD_LanCompromisso(banco).Select(vBusca, 0, string.Empty);
        }
        public static string Gravar(TRegistro_LanCompromisso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanCompromisso qtb_comp = new TCD_LanCompromisso();
            try
            {
                if (banco == null)
                    st_transacao = qtb_comp.CriarBanco_Dados(true);
                else
                    qtb_comp.Banco_Dados = banco;
                if(!val.Id_Compromisso.HasValue)
                    val.Login = Utils.Parametros.pubLogin;
                string retorno = qtb_comp.Grava(val);
                if (st_transacao)
                    qtb_comp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_comp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar compromisso: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_comp.deletarBanco_Dados();
            }
        }
        public static string Deleta(TRegistro_LanCompromisso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanCompromisso cd = new TCD_LanCompromisso();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.St_Compromisso = "C";
                cd.Grava(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir compromisso: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
