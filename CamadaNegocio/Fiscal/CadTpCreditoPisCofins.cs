using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_TpCreditoPisCofins
    {
        public static TList_TpCreditoPisCofins Buscar(string Id_tpcred,
                                                      string Ds_tpcred,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_tpcred))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_tpcred";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_tpcred;
            }
            if (!string.IsNullOrEmpty(Ds_tpcred))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_tpcred";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_tpcred.Trim() + "%'";
            }
            return new TCD_TpCreditoPisCofins(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TpCreditoPisCofins val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpCreditoPisCofins qtb_tp = new TCD_TpCreditoPisCofins();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                val.Id_tpcredstr = CamadaDados.TDataQuery.getPubVariavel(qtb_tp.Gravar(val), "@P_ID_TPCRED");
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return val.Id_tpcredstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TpCreditoPisCofins val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpCreditoPisCofins qtb_tp = new TCD_TpCreditoPisCofins();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                qtb_tp.Excluir(val);
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return val.Id_tpcredstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }
    }
}
