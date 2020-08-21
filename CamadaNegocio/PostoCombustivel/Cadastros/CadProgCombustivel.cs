using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel.Cadastros;

namespace CamadaNegocio.PostoCombustivel.Cadastros
{
    public class TCN_ProgCombustivel
    {
        public static TList_ProgCombustivel Buscar(string Cd_empresa,
                                                   string Cd_produto,
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
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_ProgCombustivel(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ProgCombustivel val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProgCombustivel qtb_prog = new TCD_ProgCombustivel();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prog.CriarBanco_Dados(true);
                else
                    qtb_prog.Banco_Dados = banco;
                string retorno = qtb_prog.Gravar(val);
                if (st_transacao)
                    qtb_prog.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prog.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar programação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prog.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ProgCombustivel val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProgCombustivel qtb_prog = new TCD_ProgCombustivel();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prog.CriarBanco_Dados(true);
                else
                    qtb_prog.Banco_Dados = banco;
                qtb_prog.Excluir(val);
                if (st_transacao)
                    qtb_prog.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prog.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir programação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prog.deletarBanco_Dados();
            }
        }
    }
}
