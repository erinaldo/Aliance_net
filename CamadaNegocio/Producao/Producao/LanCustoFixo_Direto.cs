using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Producao.Producao;

namespace CamadaNegocio.Producao.Producao
{
    public class TCN_CustoFixo_Direto
    {
        public static TList_CustoFixo_Direto Buscar(string Cd_empresa,
                                                    string Id_formulacao,
                                                    string Id_custo,
                                                    string Cd_moeda,
                                                    string Cd_unidade,
                                                    int vTop,
                                                    string vNm_campo,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Id_formulacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_formulacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_formulacao.Trim();
            }
            if (Id_custo.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_custo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_custo.Trim();
            }
            if (Cd_moeda.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_moeda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_moeda.Trim() + "'";
            }
            if (Cd_unidade.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_unidade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_unidade.Trim() + "'";
            }
            return new TCD_CustoFixo_Direto(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarCustoFixo_Direto(TRegistro_CustoFixo_Direto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CustoFixo_Direto qtb_custo = new TCD_CustoFixo_Direto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else
                    qtb_custo.Banco_Dados = banco;
                //Gravar custo fixo direto
                string retorno = qtb_custo.GravarCustoFixoDireto(val);
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }

        public static string DeletarCustoFixo_Direto(TRegistro_CustoFixo_Direto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CustoFixo_Direto qtb_custo = new TCD_CustoFixo_Direto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else
                    qtb_custo.Banco_Dados = banco;
                //Deletar Custo Fixo Direto
                qtb_custo.DeletarCustoFixoDireto(val);
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }
    }
}
