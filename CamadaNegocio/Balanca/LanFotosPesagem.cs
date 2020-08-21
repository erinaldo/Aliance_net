using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Balanca;

namespace CamadaNegocio.Balanca
{
    public class TCN_FotosPesagem
    {
        public static TList_FotosPesagem Buscar(string Cd_empresa,
                                                string Id_ticket,
                                                string Tp_pesagem,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ticket))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticket";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket;
            }
            if (!string.IsNullOrEmpty(Tp_pesagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem.Trim() + "'";
            }
            return new TCD_FotosPesagem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FotosPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FotosPesagem qtb_fotos = new TCD_FotosPesagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fotos.CriarBanco_Dados(true);
                else
                    qtb_fotos.Banco_Dados = banco;
                string retorno = qtb_fotos.Gravar(val);
                if (st_transacao)
                    qtb_fotos.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fotos.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar foto pesagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fotos.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FotosPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FotosPesagem qtb_fotos = new TCD_FotosPesagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fotos.CriarBanco_Dados(true);
                else
                    qtb_fotos.Banco_Dados = banco;
                qtb_fotos.Excluir(val);
                if (st_transacao)
                    qtb_fotos.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fotos.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir foto pesagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fotos.deletarBanco_Dados();
            }
        }
    }
}
