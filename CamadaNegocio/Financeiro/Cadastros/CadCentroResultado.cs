using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CentroResultado
    {
        public static TList_CentroResultado Buscar(string Cd_centroresult,
                                                   string Ds_centroresult,
                                                   string Cd_centroresult_pai,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_centroresult))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_centroresult";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_centroresult.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_centroresult))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_centroresultado";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_centroresult.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Cd_centroresult_pai))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_centroresult_pai";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_centroresult_pai.Trim() + "'";
            }

            return new TCD_CentroResultado(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CentroResultado val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CentroResultado qtb_cr = new TCD_CentroResultado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cr.CriarBanco_Dados(true);
                else
                    qtb_cr.Banco_Dados = banco;
                if (val.St_sinteticobool)
                    val.Tp_registro = string.Empty;
                val.Cd_centroresult = CamadaDados.TDataQuery.getPubVariavel(qtb_cr.Gravar(val), "@P_CD_CENTRORESULT");
                //Excluir Histórico
                val.lHistDel.ForEach(p =>
                {
                    TCN_CentroResult_X_Historico.Excluir(
                        new TRegistro_CentroResult_X_Historico()
                        {
                            Cd_centroresult = val.Cd_centroresult,
                            Cd_historico = p.Cd_historico
                        }, qtb_cr.Banco_Dados);
                });
                //Gravar Histórico
                val.lHist.ForEach(p =>
                {
                    TCN_CentroResult_X_Historico.Gravar(
                        new TRegistro_CentroResult_X_Historico()
                        {
                            Cd_centroresult = val.Cd_centroresult,
                            Cd_historico = p.Cd_historico
                        }, qtb_cr.Banco_Dados);
                });
                if (st_transacao)
                    qtb_cr.Banco_Dados.Commit_Tran();
                return val.Cd_centroresult;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar centro resultado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cr.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CentroResultado val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CentroResultado qtb_cr = new TCD_CentroResultado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cr.CriarBanco_Dados(true);
                else
                    qtb_cr.Banco_Dados = banco;
                qtb_cr.Excluir(val);
                if (st_transacao)
                    qtb_cr.Banco_Dados.Commit_Tran();
                return val.Cd_centroresult;
            }
            catch
            {
                if (st_transacao)
                    qtb_cr.Banco_Dados.RollBack_Tran();
                val.St_registro = "C";
                qtb_cr.Gravar(val);
                return val.Cd_centroresult;
            }
            finally
            {
                if (st_transacao)
                    qtb_cr.deletarBanco_Dados();
            }
        }
    }

    public class TCN_CentroResult_X_Historico
    {
        public static TList_CentroResult_X_Historico Buscar(string Cd_centroresult,
                                                            string Cd_historico,
                                                            BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_centroresult))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_centroresult";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_centroresult.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico.Trim() + "'";
            }
            return new TCD_CentroResult_X_Historico(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CentroResult_X_Historico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CentroResult_X_Historico qtb_cr = new TCD_CentroResult_X_Historico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cr.CriarBanco_Dados(true);
                else
                    qtb_cr.Banco_Dados = banco;
                qtb_cr.Gravar(val);
                if (st_transacao)
                    qtb_cr.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cr.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CentroResult_X_Historico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CentroResult_X_Historico qtb_cr = new TCD_CentroResult_X_Historico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cr.CriarBanco_Dados(true);
                else
                    qtb_cr.Banco_Dados = banco;
                qtb_cr.Excluir(val);
                if (st_transacao)
                    qtb_cr.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cr.deletarBanco_Dados();
            }
        }
    }
}
