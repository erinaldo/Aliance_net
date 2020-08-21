using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Balanca.Cadastros;

namespace CamadaNegocio.Balanca.Cadastros
{
    public class TCN_CadTpPesagem
    {
        public static TList_CadTpPesagem Buscar(string Tp_pesagem,
                                         string Nm_tppesagem,
                                         bool St_seqmanual,
                                         string Tp_modo,
                                         string Ordempesagem,
                                         string Tp_movdefault,
                                         bool Tp_transbordo,
                                         int vTop,
                                         string vNm_campo,
                                         BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Tp_pesagem.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nm_tppesagem.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_tppesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nm_tppesagem.Trim() + "'";
            }
            if (St_seqmanual)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_seqmanual";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (!string.IsNullOrEmpty(Tp_modo.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_modo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_modo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ordempesagem.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ordempesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Ordempesagem.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_movdefault.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movdefault";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_movdefault.Trim() + "'";
            }
            if (Tp_transbordo)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_transbordo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            
            return new TCD_CadTpPesagem(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_CadTpPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpPesagem qtb_tpps = new TCD_CadTpPesagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tpps.CriarBanco_Dados(true);
                else
                    qtb_tpps.Banco_Dados = banco;
                //Gravar Tipo Pesagem
                string retorno = qtb_tpps.Gravar(val);
                if (st_transacao)
                    qtb_tpps.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tpps.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_tpps.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadTpPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpPesagem qtb_tpps = new TCD_CadTpPesagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tpps.CriarBanco_Dados(true);
                else
                    qtb_tpps.Banco_Dados = banco;
                //Deletar tipo Pesagem
                qtb_tpps.Excluir(val);
                if (st_transacao)
                    qtb_tpps.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tpps.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_tpps.deletarBanco_Dados();
            }
        }
    }
}
