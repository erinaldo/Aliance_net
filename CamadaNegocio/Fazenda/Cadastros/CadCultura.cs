using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fazenda.Cadastros;

namespace CamadaNegocio.Fazenda.Cadastros
{
    public class TCN_Cultura
    {
        public static TList_Cultura Buscar(string Id_cultura,
                                           string Ds_cultura,
                                           string Cd_produto,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_cultura))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cultura";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cultura;
            }
            if (!string.IsNullOrEmpty(Ds_cultura))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_cultura";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_cultura.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_Cultura(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Cultura val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cultura qtb_cult = new TCD_Cultura();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cult.CriarBanco_Dados(true);
                else
                    qtb_cult.Banco_Dados = banco;
                val.Id_culturastr = CamadaDados.TDataQuery.getPubVariavel(qtb_cult.Gravar(val), "@P_ID_CULTURA");
                if (st_transacao)
                    qtb_cult.Banco_Dados.Commit_Tran();
                return val.Id_culturastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cult.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar cultura: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cult.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Cultura val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cultura qtb_cult = new TCD_Cultura();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cult.CriarBanco_Dados(true);
                else
                    qtb_cult.Banco_Dados = banco;
                qtb_cult.Excluir(val);
                if (st_transacao)
                    qtb_cult.Banco_Dados.Commit_Tran();
                return val.Id_culturastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cult.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir cultura: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cult.deletarBanco_Dados();
            }
        }
    }
}
