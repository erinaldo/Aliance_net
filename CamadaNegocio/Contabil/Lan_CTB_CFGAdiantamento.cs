using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Contabil;

namespace CamadaNegocio.Contabil
{
    public class TCN_CTB_CFGAdiantamento
    {
        public static TList_CTB_CFGAdiantamento Buscar(string Id_ctbcfg,
                                                       string Cd_empresa,
                                                       string Cd_historico,
                                                       string Cd_contager,
                                                       string Tp_movimento,
                                                       string Cd_clifor,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_ctbcfg))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cfgctb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ctbcfg;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_movimento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            return new TCD_CTB_CFGAdiantamento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CTB_CFGAdiantamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGAdiantamento qtb_adto = new TCD_CTB_CFGAdiantamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else qtb_adto.Banco_Dados = banco;
                if (!val.Id_cfgctb.HasValue)
                {
                    Utils.TpBusca[] filtro = new Utils.TpBusca[5];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + val.Cd_empresa.Trim() + "'";

                    filtro[1].vNM_Campo = "a.cd_contager";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = "'" + val.Cd_contager.Trim() + "'";

                    filtro[2].vNM_Campo = "a.cd_historico";
                    filtro[2].vOperador = "=";
                    filtro[2].vVL_Busca = "'" + val.Cd_historico.Trim() + "'";

                    filtro[3].vNM_Campo = "a.tp_movimento";
                    filtro[3].vOperador = "=";
                    filtro[3].vVL_Busca = "'" + val.Tp_movimento.Trim() + "'";

                    filtro[4].vNM_Campo = "a.cd_clifor";
                    filtro[4].vOperador = "=";
                    filtro[4].vVL_Busca = "'" + val.Cd_clifor.Trim() + "'";

                    object obj = qtb_adto.BuscarEscalar(filtro, "a.id_cfgctb");
                    if (obj != null)
                        val.Id_cfgctb = decimal.Parse(obj.ToString());
                }
                val.Id_cfgctbstr = CamadaDados.TDataQuery.getPubVariavel(qtb_adto.Gravar(val), "@P_ID_CFGCTB");
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return val.Id_cfgctbstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar configuração adiantamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTB_CFGAdiantamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTB_CFGAdiantamento qtb_adto = new TCD_CTB_CFGAdiantamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else qtb_adto.Banco_Dados = banco;
                qtb_adto.Excluir(val);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return val.Id_cfgctbstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir configuração adiantamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }
    }
}
