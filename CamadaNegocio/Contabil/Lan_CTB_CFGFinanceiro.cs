using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Contabil;
using BancoDados;

namespace CamadaNegocio.Contabil
{
    public class TCN_CTB_CFGFinanceiro
    {
        public static TList_CTB_CFGFinanceiro Busca(string Id_cfgctb,
                                                    string Cd_empresa,
                                                    string Tp_duplicata,
                                                    string Cd_historico,
                                                    string Cd_clifor,
                                                    string Cd_conta_ctb_deb,
                                                    string Cd_conta_ctb_cred,
                                                    BancoDados.TObjetoBanco banco)
        {

            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_cfgctb))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_cfgctb";
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
            if (!string.IsNullOrEmpty(Tp_duplicata))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_duplicata";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Tp_duplicata.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_historico))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_historico";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_historico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_conta_ctb_deb))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_conta_ctb_deb";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_conta_ctb_deb.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_conta_ctb_cred))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_conta_ctb_cred";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_conta_ctb_cred.Trim() + "'";
            }

            return new TCD_CTB_CFGFinanceiro(banco).Select(vBusca, 0, "");
        }

        public static string Gravar(TRegistro_CTB_CFGFinanceiro val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGFinanceiro qtb_CTB_CFGFinanceiro = new TCD_CTB_CFGFinanceiro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFGFinanceiro.CriarBanco_Dados(true);
                else qtb_CTB_CFGFinanceiro.Banco_Dados = banco;
                if (!val.Id_cfgctb.HasValue)
                {
                    TpBusca[] filtro = new TpBusca[4];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + val.Cd_empresa.Trim() + "'";

                    filtro[1].vNM_Campo = "a.tp_duplicata";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = "'" + val.Tp_duplicata.Trim() + "'";

                    filtro[2].vNM_Campo = "a.cd_historico";
                    filtro[2].vOperador = "=";
                    filtro[2].vVL_Busca = "'" + val.Cd_historico.Trim() + "'";

                    filtro[3].vNM_Campo = "a.cd_clifor";
                    filtro[3].vOperador = string.IsNullOrEmpty(val.Cd_clifor) ? "is" : "=";
                    filtro[3].vVL_Busca = string.IsNullOrEmpty(val.Cd_clifor) ? "null" : "'" + val.Cd_clifor.Trim() + "'";

                    object obj = qtb_CTB_CFGFinanceiro.BuscarEscalar(filtro, "a.id_cfgctb");
                    if (obj != null)
                        val.Id_cfgctb = decimal.Parse(obj.ToString());
                }
                string retorno = qtb_CTB_CFGFinanceiro.Grava(val);
                if (st_transacao)
                    qtb_CTB_CFGFinanceiro.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFGFinanceiro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFGFinanceiro.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTB_CFGFinanceiro val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGFinanceiro qtb_CTB_CFGFinanceiro= new TCD_CTB_CFGFinanceiro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CTB_CFGFinanceiro.CriarBanco_Dados(true);
                else
                    qtb_CTB_CFGFinanceiro.Banco_Dados = banco;

                string retorno = qtb_CTB_CFGFinanceiro.Deleta(val);
                if (st_transacao)
                    qtb_CTB_CFGFinanceiro.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CTB_CFGFinanceiro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_CTB_CFGFinanceiro.deletarBanco_Dados();
            }
        }
    }
}
