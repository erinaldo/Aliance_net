using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_EventoNFCe
    {
        public static TList_EventoNFCe Buscar(string Cd_empresa,
                                              string Id_nfce,
                                              string St_registro,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_nfce))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfce;
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_registro.Trim() + "'";
            }
            return new TCD_EventoNFCe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_EventoNFCe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EventoNFCe qtb_evento = new TCD_EventoNFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evento.CriarBanco_Dados(true);
                else qtb_evento.Banco_Dados = banco;
                val.Id_eventostr = CamadaDados.TDataQuery.getPubVariavel(qtb_evento.Gravar(val), "@P_ID_EVENTO");
                if (st_transacao)
                    qtb_evento.Banco_Dados.Commit_Tran();
                return val.Id_eventostr;
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

        public static string Excluir(TRegistro_EventoNFCe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EventoNFCe qtb_evento = new TCD_EventoNFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evento.CriarBanco_Dados(true);
                else qtb_evento.Banco_Dados = banco;
                qtb_evento.Excluir(val);
                if (st_transacao)
                    qtb_evento.Banco_Dados.Commit_Tran();
                return val.Id_eventostr;
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
