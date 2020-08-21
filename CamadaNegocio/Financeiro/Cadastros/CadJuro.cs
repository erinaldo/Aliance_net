using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadJuro
    {
        public static TList_CadJuro Buscar(string Cd_juro,
                                           string Ds_juro,
                                           string Tp_juro,
                                           int vTop,
                                           string vNm_campo)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Cd_juro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "cd_juro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_juro.Trim() + "'";
            }
            if (Ds_juro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "ds_juro";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_juro.Trim() + "%')";
            }
            if (Tp_juro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "tp_juro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_juro.Trim() + "'";
            }
            
            return new TCD_CadJuro().Select(filtro, vTop, vNm_campo);
        }

        public static string GravarJuro(TRegistro_CadJuro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadJuro qtb_juro = new TCD_CadJuro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_juro.CriarBanco_Dados(true);
                else
                    qtb_juro.Banco_Dados = banco;
                val.Cd_juro = CamadaDados.TDataQuery.getPubVariavel(qtb_juro.GravarJuro(val), "@P_CD_JURO");
                if (st_transacao)
                    qtb_juro.Banco_Dados.Commit_Tran();
                return val.Cd_juro;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_juro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar juro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_juro.deletarBanco_Dados();
            }
        }

        public static string DeletarJuro(TRegistro_CadJuro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadJuro qtb_juro = new TCD_CadJuro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_juro.CriarBanco_Dados(true);
                else
                    qtb_juro.Banco_Dados = banco;
                qtb_juro.DeletarJuro(val);
                if (st_transacao)
                    qtb_juro.Banco_Dados.Commit_Tran();
                return val.Cd_juro;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_juro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir juro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_juro.deletarBanco_Dados();
            }
        }
    }
}
