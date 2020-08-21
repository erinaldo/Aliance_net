using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Financeiro.Duplicata
{
    public class TCN_DadosBloqueio
    {
        public static CamadaDados.Financeiro.Duplicata.TList_DadosBloqueio Buscar(string Cd_clifor,
                                                                                  BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_DadosBloqueio(banco).Select(new Utils.TpBusca[] { new Utils.TpBusca() { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + Cd_clifor.Trim() + "'" } });
        }

        public static bool VerificarBloqueioCredito(string Cd_clifor,
                                                    decimal Vl_fatura,
                                                    bool St_duplicata,
                                                    ref CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados,
                                                    BancoDados.TObjetoBanco banco)
        {
            CamadaDados.Financeiro.Duplicata.TList_DadosBloqueio lDados =
                TCN_DadosBloqueio.Buscar(Cd_clifor, banco);
            if (lDados.Count > 0)
            {
                rDados = lDados[0];
                if (St_duplicata)
                    return ((rDados.Vl_limitecredito > decimal.Zero) && ((rDados.Vl_limitecredito - rDados.Vl_debito_aberto) < Vl_fatura)) ||
                        (rDados.St_bloq_debitovencidobool && (rDados.Vl_debito_vencto > decimal.Zero)) ||
                        rDados.Vl_dupPerdidas > decimal.Zero ||
                        rDados.St_bloqcreditoavulsobool ||
                        rDados.St_renovarcadastro ||
                        rDados.St_bloqueiospcbool;
                else
                    return (rDados.Vl_ch_devolvido > decimal.Zero) ||
                        ((rDados.Vl_limitecredCH > decimal.Zero) && ((rDados.Vl_limitecredCH - rDados.Vl_ch_predatado) < Vl_fatura));
            }
            else
                return false;
        }
    }

    public class TCN_LiberarCredito
    {
        public static CamadaDados.Financeiro.Duplicata.TList_LiberarCredito Buscar(string Id_solicitacao,
                                                                                   string Cd_empresa,
                                                                                   string Cd_clifor,
                                                                                   string LoginBloqueio,
                                                                                   string LoginDesbloqueio,
                                                                                   string Tp_data,
                                                                                   string Dt_ini,
                                                                                   string Dt_fin,
                                                                                   decimal Vl_ini,
                                                                                   decimal Vl_fin,
                                                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_solicitacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_solicitacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_solicitacao;
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
            if (!string.IsNullOrEmpty(LoginBloqueio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.loginbloqueio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + LoginBloqueio.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(LoginDesbloqueio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.logindesbloqueio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + LoginDesbloqueio.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().Equals("S") ? "a.dt_solicitacao" : "a.dt_liberacao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().Equals("S") ? "a.dt_solicitacao" : "a.dt_liberacao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + " 23:59:59'";
            }
            if (Vl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_compra";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = Vl_ini.ToString("N2", new System.Globalization.CultureInfo("en-US"));
            }
            if (Vl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_compra";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = Vl_fin.ToString("N2", new System.Globalization.CultureInfo("en-US"));
            }

            return new CamadaDados.Financeiro.Duplicata.TCD_LiberarCredito(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(CamadaDados.Financeiro.Duplicata.TRegistro_LiberarCredito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Financeiro.Duplicata.TCD_LiberarCredito qtb_liberar = new CamadaDados.Financeiro.Duplicata.TCD_LiberarCredito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_liberar.CriarBanco_Dados(true);
                else
                    qtb_liberar.Banco_Dados = banco;
                val.Id_solicitacao = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(qtb_liberar.Gravar(val), "@P_ID_SOLICITACAO"));
                if (st_transacao)
                    qtb_liberar.Banco_Dados.Commit_Tran();
                return val.Id_solicitacaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liberar.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar liberação crédito: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_liberar.deletarBanco_Dados();
            }
        }

        public static string Excluir(CamadaDados.Financeiro.Duplicata.TRegistro_LiberarCredito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Financeiro.Duplicata.TCD_LiberarCredito qtb_liberar = new CamadaDados.Financeiro.Duplicata.TCD_LiberarCredito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_liberar.CriarBanco_Dados(true);
                else
                    qtb_liberar.Banco_Dados = banco;
                qtb_liberar.Excluir(val);
                if (st_transacao)
                    qtb_liberar.Banco_Dados.Commit_Tran();
                return val.Id_solicitacaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_liberar.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir liberação crédito: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_liberar.deletarBanco_Dados();
            }
        }
    }
}
