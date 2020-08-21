using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CodANP
    {
        public static TList_CodANP Buscar(string Cd_anp,
                                          string Ds_anp,
                                          BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_anp))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_anp";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_anp.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_anp))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_anp";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Ds_anp.Trim() + "'";
            }
            return new TCD_CodANP(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CodANP val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CodANP qtb_cod = new TCD_CodANP();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cod.CriarBanco_Dados(true);
                else
                    qtb_cod.Banco_Dados = banco;
                val.Cd_anp = CamadaDados.TDataQuery.getPubVariavel(qtb_cod.Gravar(val), "@P_CD_ANP");
                if (st_transacao)
                    qtb_cod.Banco_Dados.Commit_Tran();
                return val.Cd_anp;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar codigo ANP: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cod.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CodANP val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CodANP qtb_cod = new TCD_CodANP();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cod.CriarBanco_Dados(true);
                else
                    qtb_cod.Banco_Dados = banco;
                qtb_cod.Excluir(val);
                if (st_transacao)
                    qtb_cod.Banco_Dados.Commit_Tran();
                return val.Cd_anp;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir codigo ANP: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cod.deletarBanco_Dados();
            }
        }
    }
}
