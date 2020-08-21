using System;
using System.Linq;
using CamadaDados.Contabil;
using BancoDados;
using Utils;

namespace CamadaNegocio.Contabil
{
    public class TCN_CTB_CFGNFCe
    {
        public static TList_CTB_CFGNFCe Buscar(string Id_cfgctb,
                                               string Cd_empresa,
                                               string Cd_cfop,
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
            if (!string.IsNullOrEmpty(Cd_cfop))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_cfop";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_cfop.Trim() + "'";
            }
            return new TCD_CTB_CFGNFCe(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CTB_CFGNFCe val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGNFCe qtb_CTB_CFG = new TCD_CTB_CFGNFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFG.CriarBanco_Dados(true);
                else
                    qtb_CTB_CFG.Banco_Dados = banco;
                if (!val.Id_cfgctb.HasValue)
                {
                    TpBusca[] filtro = new TpBusca[3];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + val.Cd_empresa.Trim() + "'";

                    filtro[1].vNM_Campo = "a.cd_cfop";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = val.Cd_cfop;

                    filtro[2].vNM_Campo = "a.cd_produto";
                    filtro[2].vOperador = string.IsNullOrEmpty(val.Cd_produto) ? "is" : "=";
                    filtro[2].vVL_Busca = string.IsNullOrEmpty(val.Cd_produto) ? "null" : "'" + val.Cd_produto.Trim() + "'";

                    object obj = qtb_CTB_CFG.BuscarEscalar(filtro, "a.id_cfgctb");
                    if (obj != null)
                        val.Id_cfgctb = decimal.Parse(obj.ToString());
                }
                string retorno = qtb_CTB_CFG.Grava(val);
                if (st_transacao)
                    qtb_CTB_CFG.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFG.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFG.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTB_CFGNFCe val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGNFCe qtb_CTB_CFG = new TCD_CTB_CFGNFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFG.CriarBanco_Dados(true);
                else
                    qtb_CTB_CFG.Banco_Dados = banco;

                qtb_CTB_CFG.Deleta(val);
                if (st_transacao)
                    qtb_CTB_CFG.Banco_Dados.Commit_Tran();
                return val.Id_cfgctbstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFG.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFG.deletarBanco_Dados();
            }
        }
    }
}
