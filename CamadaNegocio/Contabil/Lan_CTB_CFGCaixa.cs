using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Contabil;
using BancoDados;

namespace CamadaNegocio.Contabil
{
    public class TCN_CTB_CFGCaixa
    {
        public static TList_CTB_CFGCaixa Busca(string Id_ctbcfg,
                                               string Cd_empresa,
                                               string Cd_contager,
                                               string Cd_historico,
                                               string Cd_conta_deb,
                                               string Cd_conta_cred,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_ctbcfg))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_CFGCTB";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_ctbcfg;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_contager";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_historico))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_historico";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_historico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_conta_deb))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CONTA_CTB_DEB";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Cd_conta_deb;
            }
            if (!string.IsNullOrEmpty(Cd_conta_cred))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CONTA_CTB_CRED";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Cd_conta_cred;
            }

            return new TCD_CTB_CFGCaixa(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CTB_CFGCaixa val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGCaixa qtb_CTB_CFGCaixa  = new TCD_CTB_CFGCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFGCaixa.CriarBanco_Dados(true);
                else
                    qtb_CTB_CFGCaixa.Banco_Dados = banco;
                if (!val.ID_CFGCTB.HasValue)
                {
                    Utils.TpBusca[] filtro = new Utils.TpBusca[4];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + val.CD_Empresa.Trim() + "'";

                    filtro[1].vNM_Campo = "a.cd_contager";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = "'" + val.CD_ContaGer.Trim() + "'";

                    filtro[2].vNM_Campo = "a.cd_historico";
                    filtro[2].vOperador = "=";
                    filtro[2].vVL_Busca = "'" + val.CD_Historico.Trim() + "'";

                    filtro[3].vNM_Campo = "a.tp_movimento";
                    filtro[3].vOperador = "=";
                    filtro[3].vVL_Busca = "'" + val.TP_Movimento.Trim() + "'";

                    object obj = qtb_CTB_CFGCaixa.BuscarEscalar(filtro, "a.id_cfgctb");
                    if (obj != null)
                        val.ID_CFGCTB = decimal.Parse(obj.ToString());
                }
                string retorno = qtb_CTB_CFGCaixa.Grava(val);
                if (st_transacao)
                    qtb_CTB_CFGCaixa.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFGCaixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFGCaixa.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTB_CFGCaixa val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGCaixa qtb_CTB_CFGCaixa = new TCD_CTB_CFGCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFGCaixa.CriarBanco_Dados(true);
                else
                    qtb_CTB_CFGCaixa.Banco_Dados = banco;

                string retorno = qtb_CTB_CFGCaixa.Deleta(val);
                if (st_transacao)
                    qtb_CTB_CFGCaixa.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFGCaixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFGCaixa.deletarBanco_Dados();
            }
        }
    }
}
