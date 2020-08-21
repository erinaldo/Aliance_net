using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CadImposto
    {
        public static TList_CadImposto Busca(string cd_impostoSt, 
                                             string ds_imposto,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(cd_impostoSt))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "CD_Imposto";
                vBusca[vBusca.Length - 1].vVL_Busca = cd_impostoSt;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(ds_imposto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_Imposto";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + ds_imposto.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = " like ";
            }
            return new TCD_CadImposto(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadImposto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadImposto qtb_imposto = new TCD_CadImposto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_imposto.CriarBanco_Dados(true);
                else
                    qtb_imposto.Banco_Dados = banco;
                val.Cd_impostoSt = CamadaDados.TDataQuery.getPubVariavel(qtb_imposto.Gravar(val), "@P_CD_IMPOSTO");
                if (st_transacao)
                    qtb_imposto.Banco_Dados.Commit_Tran();
                return val.Cd_impostoSt;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_imposto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar imposto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_imposto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadImposto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadImposto qtb_imposto = new TCD_CadImposto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_imposto.CriarBanco_Dados(true);
                else
                    qtb_imposto.Banco_Dados = banco;
                qtb_imposto.Excluir(val);
                if (st_transacao)
                    qtb_imposto.Banco_Dados.Commit_Tran();
                return val.Cd_impostoSt;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_imposto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir imposto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_imposto.deletarBanco_Dados();
            }
        }
    }
}
