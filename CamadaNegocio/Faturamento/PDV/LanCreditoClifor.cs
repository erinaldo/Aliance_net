using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Faturamento.PDV
{
    #region Credito Clifor
    public class TCN_CreditoClifor
    {
        public static TList_CreditoClifor Buscar(string Id_credito,
                                                 string Cd_empresa,
                                                 string Cd_clifor,
                                                 string Cd_endereco,
                                                 string Dt_ini,
                                                 string Dt_fin,
                                                 bool St_comsaldo,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_credito))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_credito";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_credito;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_endereco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_endereco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_endereco.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_credito";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_credito";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + " 23:59:59'";
            }
            if (St_comsaldo)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_credito - a.vl_devolvido";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }

            return new TCD_CreditoClifor(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CreditoClifor val, 
                                    CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa rCaixa,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CreditoClifor qtb_cred = new TCD_CreditoClifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cred.CriarBanco_Dados(true);
                else
                    qtb_cred.Banco_Dados = banco;
                //Gravar Credito
                val.Id_creditostr = CamadaDados.TDataQuery.getPubVariavel(qtb_cred.Gravar(val), "@P_ID_CREDITO");
                //Gravar Caixa
                CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(rCaixa, qtb_cred.Banco_Dados);
                //Gravar Credito X Caixa
                TCN_CreditoClifor_X_Caixa.Gravar(new TRegistro_CreditoClifor_X_Caixa()
                {
                    Cd_contager = rCaixa.Cd_ContaGer,
                    Cd_empresa = val.Cd_empresa,
                    Cd_lanctocaixa = rCaixa.Cd_LanctoCaixa,
                    Id_credito = val.Id_credito
                }, qtb_cred.Banco_Dados);
                if (st_transacao)
                    qtb_cred.Banco_Dados.Commit_Tran();
                return val.Id_creditostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cred.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar credito: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cred.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CreditoClifor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CreditoClifor qtb_cred = new TCD_CreditoClifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cred.CriarBanco_Dados(true);
                else
                    qtb_cred.Banco_Dados = banco;
                qtb_cred.Excluir(val);
                if (st_transacao)
                    qtb_cred.Banco_Dados.Commit_Tran();
                return val.Id_creditostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cred.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir credito: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cred.deletarBanco_Dados();
            }
        }

        public static CamadaDados.Financeiro.Caixa.TList_LanCaixa DevolverCredito(string Cd_empresa,
                                                                                  string Cd_clifor,
                                                                                  string Cd_historico,
                                                                                  DateTime? Dt_lancto,
                                                                                  decimal Vl_credito,
                                                                                  BancoDados.TObjetoBanco banco)
        {
            //Buscar lista de credito da empresa/cliente
            TList_CreditoClifor lCredito = Buscar(string.Empty,
                                                  Cd_empresa,
                                                  Cd_clifor,
                                                  string.Empty,
                                                  string.Empty,
                                                  string.Empty,
                                                  true,
                                                  banco);
            CamadaDados.Financeiro.Caixa.TList_LanCaixa lCaixa = new CamadaDados.Financeiro.Caixa.TList_LanCaixa();
            if (lCredito.Count > 0)
            {
                decimal saldo_credito = Vl_credito;
                foreach (TRegistro_CreditoClifor rCred in lCredito)
                {
                    if (saldo_credito > 0)
                        if (rCred.Vl_saldodevolver > decimal.Zero)
                        {
                            CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa rCaixa =
                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                {
                                    Cd_ContaGer = rCred.Cd_contager,
                                    Cd_Empresa = Cd_empresa,
                                    Cd_Historico = Cd_historico,
                                    ComplHistorico = "DEVOLUCAO CREDITO: " + rCred.Id_creditostr,
                                    Nr_Docto = "DEV" + rCred.Id_creditostr,
                                    NM_Clifor = rCred.Nm_clifor,
                                    Dt_lancto = Dt_lancto,
                                    St_Titulo = "N",
                                    Vl_PAGAR = rCred.Vl_saldodevolver > saldo_credito ? saldo_credito : rCred.Vl_saldodevolver,
                                    Vl_RECEBER = decimal.Zero
                                };
                            CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(rCaixa, banco);
                            lCaixa.Add(rCaixa);

                            //Gravar Credito X Caixa
                            TCN_CreditoClifor_X_Caixa.Gravar(new TRegistro_CreditoClifor_X_Caixa()
                            {
                                Cd_contager = rCaixa.Cd_ContaGer,
                                Cd_lanctocaixa = rCaixa.Cd_LanctoCaixa,
                                Cd_empresa = rCred.Cd_empresa,
                                Id_credito = rCred.Id_credito
                            }, banco);

                            saldo_credito -= rCred.Vl_saldodevolver > Vl_credito ? Vl_credito : rCred.Vl_saldodevolver;
                        }
                        else
                            continue;
                    else
                        break;
                }
            }
            return lCaixa;
        }
    }
    #endregion

    #region Credito Clifor X Caixa
    public class TCN_CreditoClifor_X_Caixa
    {
        public static TList_CreditoClifor_X_Caixa Buscar(string Id_credito,
                                                         string Cd_empresa,
                                                         string Cd_contager,
                                                         string Cd_lanctocaixa,
                                                         BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_credito))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_credito";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_credito;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_lanctocaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_lanctocaixa.Trim() + "'";
            }

            return new TCD_CreditoClifor_X_Caixa(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Caixa.TList_LanCaixa BuscarCaixa(string Id_credito,
                                                                              string Cd_empresa,
                                                                              BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdv_creditoclifor_x_caixa x " +
                                    "where x.cd_contager = a.cd_contager " +
                                    "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                    "and x.id_credito = " + Id_credito + " " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "')"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CreditoClifor_X_Caixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CreditoClifor_X_Caixa qtb_cred = new TCD_CreditoClifor_X_Caixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cred.CriarBanco_Dados(true);
                else
                    qtb_cred.Banco_Dados = banco;
                string retorno = qtb_cred.Gravar(val);
                if (st_transacao)
                    qtb_cred.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cred.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar caixa credito: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cred.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CreditoClifor_X_Caixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CreditoClifor_X_Caixa qtb_cred = new TCD_CreditoClifor_X_Caixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cred.CriarBanco_Dados(true);
                else
                    qtb_cred.Banco_Dados = banco;
                qtb_cred.Excluir(val);
                if (st_transacao)
                    qtb_cred.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cred.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir caixa credito: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cred.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
