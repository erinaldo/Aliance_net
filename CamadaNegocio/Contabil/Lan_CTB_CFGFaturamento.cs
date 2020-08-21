using System;
using CamadaDados.Contabil;
using BancoDados;
using Utils;

namespace CamadaNegocio.Contabil
{
    public class TCN_CTB_CFGFaturamento
    {
        public static TList_CTB_CFGFaturamento Buscar(string Id_cfgctb,
                                                      string Cd_empresa,
                                                      string Cd_movimentacao,
                                                      TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_cfgctb))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_CFGCTB";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_cfgctb;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_movimentacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_movimentacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_movimentacao.Trim() + "'";
            }
            return new TCD_CTB_CFGFaturamento(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CTB_CFGFaturamento val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGFaturamento qtb_CTB_CFGFaturamento = new TCD_CTB_CFGFaturamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFGFaturamento.CriarBanco_Dados(true);
                else
                    qtb_CTB_CFGFaturamento.Banco_Dados = banco;
                if (!val.ID_CFGCTB.HasValue)
                {
                    TpBusca[] filtro = new TpBusca[5];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + val.CD_Empresa.Trim() + "'";

                    filtro[1].vNM_Campo = "a.cd_movimentacao";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = val.CD_Movimentacao_String;
                    
                    filtro[2].vNM_Campo = "a.cd_clifor";
                    filtro[2].vOperador = string.IsNullOrEmpty(val.CD_Clifor) ? "is" : "=";
                    filtro[2].vVL_Busca = string.IsNullOrEmpty(val.CD_Clifor) ? "null" : "'" + val.CD_Clifor.Trim() + "'";
                    
                    filtro[3].vNM_Campo = "a.cd_produto";
                    filtro[3].vOperador = string.IsNullOrEmpty(val.CD_Produto) ? "is" : "=";
                    filtro[3].vVL_Busca = string.IsNullOrEmpty(val.CD_Produto) ? "null" : "'" + val.CD_Produto.Trim() + "'";

                    filtro[4].vNM_Campo = "a.cd_grupo";
                    filtro[4].vOperador = string.IsNullOrEmpty(val.Cd_grupo) ? "is" : "=";
                    filtro[4].vVL_Busca = string.IsNullOrEmpty(val.Cd_grupo) ? "null" : "'" + val.Cd_grupo.Trim() + "'";

                    object obj = qtb_CTB_CFGFaturamento.BuscarEscalar(filtro, "a.id_cfgctb");
                    if (obj != null)
                        val.ID_CFGCTB = decimal.Parse(obj.ToString());
                }
                string retorno = qtb_CTB_CFGFaturamento.Grava(val);
                if (st_transacao)
                    qtb_CTB_CFGFaturamento.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFGFaturamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFGFaturamento.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTB_CFGFaturamento val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGFaturamento qtb_CTB_CFGFaturamento = new TCD_CTB_CFGFaturamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFGFaturamento.CriarBanco_Dados(true);
                else
                    qtb_CTB_CFGFaturamento.Banco_Dados = banco;

                qtb_CTB_CFGFaturamento.Deleta(val);
                if (st_transacao)
                    qtb_CTB_CFGFaturamento.Banco_Dados.Commit_Tran();
                return val.ID_CFGCTB_String;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFGFaturamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFGFaturamento.deletarBanco_Dados();
            }

        }
    }
}
