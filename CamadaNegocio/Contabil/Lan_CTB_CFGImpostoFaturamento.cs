using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Contabil;

namespace CamadaNegocio.Contabil
{
    public class TCN_CFGImpostoFaturamento
    {
        public static TList_CFGImpostoFaturamento Buscar(string Id_cfgctb,
                                                         string Cd_empresa,
                                                         string Cd_movimentacao,
                                                         string Cd_imposto,
                                                         string Cd_clifor,
                                                         string Cd_produto,
                                                         string Cd_conta_ctb_cred,
                                                         string Cd_conta_ctb_deb,
                                                         BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_cfgctb))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cfgctb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cfgctb;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_movimentacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_movimentacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_movimentacao;
            }
            if (!string.IsNullOrEmpty(Cd_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_imposto;
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_conta_ctb_cred))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_conta_ctb_cred";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_conta_ctb_cred;
            }
            if (!string.IsNullOrEmpty(Cd_conta_ctb_deb))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_conta_ctb_deb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_conta_ctb_deb;
            }
            return new TCD_CFGImpostoFaturamento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CFGImpostoFaturamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGImpostoFaturamento qtb_cfg = new TCD_CFGImpostoFaturamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                if (!val.Id_cfgctb.HasValue)
                {
                    Utils.TpBusca[] filtro = new Utils.TpBusca[5];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + val.Cd_empresa.Trim() + "'";

                    filtro[1].vNM_Campo = "a.cd_movimentacao";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = val.Cd_movimentacaostr;

                    filtro[2].vNM_Campo = "a.cd_imposto";
                    filtro[2].vOperador = "=";
                    filtro[2].vVL_Busca = val.Cd_impostostr;
                    
                    filtro[3].vNM_Campo = "a.cd_clifor";
                    filtro[3].vOperador = string.IsNullOrEmpty(val.Cd_clifor) ? "is" : "=";
                    filtro[3].vVL_Busca = string.IsNullOrEmpty(val.Cd_clifor) ? "null" : "'" + val.Cd_clifor.Trim() + "'";

                    filtro[4].vNM_Campo = "a.cd_produto";
                    filtro[4].vOperador = string.IsNullOrEmpty(val.Cd_produto) ? "is" : "=";
                    filtro[4].vVL_Busca = string.IsNullOrEmpty(val.Cd_produto) ? "null" : "'" + val.Cd_produto.Trim() + "'";

                    object obj = qtb_cfg.BuscarEscalar(filtro, "a.id_cfgctb");
                    if (obj != null)
                        val.Id_cfgctb = decimal.Parse(obj.ToString());
                }
                val.Id_cfgctbstr = CamadaDados.TDataQuery.getPubVariavel(qtb_cfg.Gravar(val), "@P_ID_CFGCTB");
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Id_cfgctbstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar configuração: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CFGImpostoFaturamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGImpostoFaturamento qtb_cfg = new TCD_CFGImpostoFaturamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                qtb_cfg.Excluir(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Id_cfgctbstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir configuração: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
