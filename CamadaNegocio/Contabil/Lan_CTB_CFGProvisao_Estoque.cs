using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Contabil;
using BancoDados;

namespace CamadaNegocio.Contabil
{
    public class TCN_CTB_CFGProvisao_Estoque
    {
        public static TList_CTB_CFGProvisao_Estoque Busca(string Id_cfgctb,
                                                          string Cd_empresa,
                                                          string Cd_produto,
                                                          BancoDados.TObjetoBanco banco)
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
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }

            return new TCD_CTB_CFGProvisao_Estoque().Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CTB_CFGProvisao_Estoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGProvisao_Estoque qtb_CTB_CFGProvisao_Estoque = new TCD_CTB_CFGProvisao_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFGProvisao_Estoque.CriarBanco_Dados(true);
                else
                    qtb_CTB_CFGProvisao_Estoque.Banco_Dados = banco;
                if (!val.ID_CFGCTB.HasValue)
                {
                    Utils.TpBusca[] filtro = new Utils.TpBusca[3];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + val.Cd_empresa.Trim() + "'";

                    filtro[1].vNM_Campo = "a.cd_produto";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = "'" + val.CD_Produto.Trim() + "'";

                    filtro[2].vNM_Campo = "a.tp_movimento";
                    filtro[2].vOperador = "=";
                    filtro[2].vVL_Busca = "'" + val.Tp_movimento.Trim() + "'";

                    object obj = qtb_CTB_CFGProvisao_Estoque.BuscarEscalar(filtro, "a.id_cfgctb");
                    if (obj != null)
                        val.ID_CFGCTB = decimal.Parse(obj.ToString());
                }
                val.ID_CFGCTB_String = CamadaDados.TDataQuery.getPubVariavel(qtb_CTB_CFGProvisao_Estoque.Grava(val), "@P_ID_CFGCTB");
                if (st_transacao)
                    qtb_CTB_CFGProvisao_Estoque.Banco_Dados.Commit_Tran();
                return val.ID_CFGCTB_String;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFGProvisao_Estoque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFGProvisao_Estoque.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTB_CFGProvisao_Estoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGProvisao_Estoque qtb_CTB_CFGProvisao_Estoque = new TCD_CTB_CFGProvisao_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFGProvisao_Estoque.CriarBanco_Dados(true);
                else
                    qtb_CTB_CFGProvisao_Estoque.Banco_Dados = banco;

                qtb_CTB_CFGProvisao_Estoque.Deleta(val);
                if (st_transacao)
                    qtb_CTB_CFGProvisao_Estoque.Banco_Dados.Commit_Tran();
                return val.ID_CFGCTB_String;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFGProvisao_Estoque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFGProvisao_Estoque.deletarBanco_Dados();
            }
        }
    }
}
