using System;
using System.Collections.Generic;
using CamadaDados.Financeiro.Cadastros;
using System.Text;
using Utils;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadTpDuplicata
    {
        public static TList_CadTpDuplicata Buscar(string tp_duplicata, 
                                                  string ds_duplicata, 
                                                  string tp_mov,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(tp_duplicata))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_duplicata";
                filtro[filtro.Length - 1].vVL_Busca = "'" + tp_duplicata.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(ds_duplicata))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_tpduplicata";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + ds_duplicata.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(tp_mov))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_mov";
                filtro[filtro.Length - 1].vVL_Busca = "'" + tp_mov.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_CadTpDuplicata(banco).Select(filtro, 0, "");
        }

        public static string Gravar(TRegistro_CadTpDuplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpDuplicata qtb_tp = new TCD_CadTpDuplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                val.Tp_duplicata = CamadaDados.TDataQuery.getPubVariavel(qtb_tp.Gravar(val), "@P_TP_DUPLICATA");
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return val.Tp_duplicata;
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

        public static string Excluir(TRegistro_CadTpDuplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpDuplicata qtb_tp = new TCD_CadTpDuplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                qtb_tp.Excluir(val);
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return val.Tp_duplicata;
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
