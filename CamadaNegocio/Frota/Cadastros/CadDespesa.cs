using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota.Cadastros;

namespace CamadaNegocio.Frota.Cadastros
{
    public class TCN_Despesa
    {
        public static TList_Despesa Buscar(string Id_despesa,
                                           string Ds_despesa,
                                           string Tp_despesa,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_despesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_despesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_despesa;
            }
            if (!string.IsNullOrEmpty(Ds_despesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_despesa";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_despesa.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Tp_despesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_despesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_despesa + "'";
            }
            return new TCD_Despesa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Despesa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Despesa qtb_desp = new TCD_Despesa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else
                    qtb_desp.Banco_Dados = banco;
                val.Id_despesastr = CamadaDados.TDataQuery.getPubVariavel(qtb_desp.Gravar(val), "@P_ID_DESPESA");
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return val.Id_despesastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar despesa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Despesa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Despesa qtb_desp = new TCD_Despesa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else
                    qtb_desp.Banco_Dados = banco;
                qtb_desp.Excluir(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return val.Id_despesastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir despesa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }
}
