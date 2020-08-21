using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Producao.Producao;

namespace CamadaNegocio.Producao.Producao
{
    #region Série Produto
    public class TCN_SerieProduto
    {
        public static TList_SerieProduto Buscar(string NR_Serie,
                                                 string Cd_empresa,
                                                 string Cd_produto,
                                                 string Id_ordem,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(NR_Serie))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_Serie";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" +  NR_Serie + "'";
            }
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
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ordem;
            }

            return new TCD_SerieProduto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_SerieProduto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SerieProduto qtb_ordem = new TCD_SerieProduto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                //Gravar Nº Série
                val.Id_serie = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_ordem.Gravar(val), "@P_ID_SERIE"));
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return val.Id_seriestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Nº Série: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_SerieProduto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SerieProduto qtb_ordem = new TCD_SerieProduto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                //Cancelar
                val.St_registro = "C";
                qtb_ordem.Gravar(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Nº Série: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
