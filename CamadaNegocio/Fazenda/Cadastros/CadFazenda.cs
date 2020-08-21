using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Fazenda.Cadastros;

namespace CamadaNegocio.Fazenda.Cadastros
{
    public class TCN_Fazenda
    {
        public static TList_Fazenda Buscar(string Cd_fazenda,
                                           BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_fazenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fazenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fazenda.Trim() + "'";
            }
            return new TCD_Fazenda(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Fazenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fazenda qtb_fazenda = new TCD_Fazenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fazenda.CriarBanco_Dados(true);
                else
                    qtb_fazenda.Banco_Dados = banco;
                qtb_fazenda.Gravar(val);
                if (st_transacao)
                    qtb_fazenda.Banco_Dados.Commit_Tran();
                return val.Cd_fazenda;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fazenda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar fazenda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fazenda.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Fazenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fazenda qtb_fazenda = new TCD_Fazenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fazenda.CriarBanco_Dados(true);
                else
                    qtb_fazenda.Banco_Dados = banco;
                qtb_fazenda.Excluir(val);
                if (st_transacao)
                    qtb_fazenda.Banco_Dados.Commit_Tran();
                return val.Cd_fazenda;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fazenda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir fazenda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fazenda.deletarBanco_Dados();
            }
        }
    }
}
    



    
