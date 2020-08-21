using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_Evento
    {
        public static TList_Evento Buscar(string Cd_evento,
                                          string Ds_evento,
                                          string Tp_evento,
                                          BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_evento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_evento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_evento;
            }
            if (!string.IsNullOrEmpty(Ds_evento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_evento";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_evento.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Tp_evento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_evento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_evento.Trim() + "'";
            }
            return new TCD_Evento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Evento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Evento qtb_evento = new TCD_Evento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evento.CriarBanco_Dados(true);
                else
                    qtb_evento.Banco_Dados = banco;
                string retorno = qtb_evento.Gravar(val);
                if (st_transacao)
                    qtb_evento.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_evento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar evento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_evento.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Evento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Evento qtb_evento = new TCD_Evento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evento.CriarBanco_Dados(true);
                else
                    qtb_evento.Banco_Dados = banco;
                qtb_evento.Excluir(val);
                if (st_transacao)
                    qtb_evento.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_evento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir evento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_evento.deletarBanco_Dados();
            }
        }
    }
}
