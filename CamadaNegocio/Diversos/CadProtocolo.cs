using System;
using Utils;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadProtocolo
    {
        public static TList_RegCadProtocolo Busca(string vCD_Protocolo,
                                                  string vDS_Protocolo,
                                                  string vCD_Terminal,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Protocolo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "CD_Protocolo";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Protocolo.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDS_Protocolo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_Protocolo";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDS_Protocolo.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Terminal))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vVL_Busca = "(Select 1 From TB_DIV_Terminal_X_Protocolo x " +
                                                      "Where x.CD_Protocolo = a.CD_Protocolo " +
                                                      "and x.CD_Terminal = '"+vCD_Terminal+"')";
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
            }
            return new TCD_CadProtocolo(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadProtocolo val, BancoDados.TObjetoBanco banco)
        {
            TCD_CadProtocolo qtb_protocolo = new TCD_CadProtocolo();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_protocolo.CriarBanco_Dados(true);
                else qtb_protocolo.Banco_Dados = banco;
                val.Cd_protocolo = CamadaDados.TDataQuery.getPubVariavel(qtb_protocolo.Gravar(val), "@P_CD_PROTOCOLO");
                if (st_transacao)
                    qtb_protocolo.Banco_Dados.Commit_Tran();
                return val.Cd_protocolo;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_protocolo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar protocolo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_protocolo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadProtocolo val, BancoDados.TObjetoBanco banco)
        {
            TCD_CadProtocolo qtb_protocolo = new TCD_CadProtocolo();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_protocolo.CriarBanco_Dados(true);
                else qtb_protocolo.Banco_Dados = banco;
                qtb_protocolo.Excluir(val);
                if (st_transacao)
                    qtb_protocolo.Banco_Dados.Commit_Tran();
                return val.Cd_protocolo;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_protocolo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir protocolo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_protocolo.deletarBanco_Dados();
            }
        }
    }
}
