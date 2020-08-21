using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadContaGer
    {
        public static TList_CadContaGer Buscar(string vCd_contager,
                                               string vDs_contager,
                                               TRegistro_CadBanco banco,
                                               string vNr_agencia,
                                               string vNr_contacorrente,
                                               string vSt_contacompensacao,
                                               string vSt_integractb,
                                               decimal vVl_limite,
                                               string vCd_contager_compensacao,
                                               string vCd_empresa,
                                               string vCd_moeda,
                                               string vNm_campo,
                                               int vTop,
                                               BancoDados.TObjetoBanco BD)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_ContaGer";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_contager.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDs_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_ContaGer";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDs_contager.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (banco != null)
                if (!string.IsNullOrEmpty(banco.Cd_banco))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "b.CD_Banco";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + banco.Cd_banco.Trim() + "'";
                    filtro[filtro.Length - 1].vOperador = "=";
                }
            if (!string.IsNullOrEmpty(vNr_agencia))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_Agencia";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_agencia.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNr_contacorrente))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_ContaCorrente";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_contacorrente.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vSt_contacompensacao.Trim().ToUpper().Equals("S"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_ContaCompensacao";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_contacompensacao.Trim().ToUpper() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vSt_integractb.Trim().ToUpper().Equals("S"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_IntegraCTB";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_integractb.Trim().ToUpper() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVl_limite > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Vl_Limite";
                filtro[filtro.Length - 1].vVL_Busca = vVl_limite.ToString(new System.Globalization.CultureInfo("en-US", true));
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_contager_compensacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager_compensacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_contager_compensacao.Trim() + "'";
            }
            if (vCd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_contager_x_empresa x " +
                                                      "where x.cd_contager = a.cd_contager " +
                                                      "and x.cd_empresa = '" + vCd_empresa.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(vCd_moeda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_moeda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_moeda.Trim() + "'";
            }

            return new TCD_CadContaGer(BD).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_CadContaGer val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContaGer cd = new TCD_CadContaGer();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.Gravar(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar conta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadContaGer val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContaGer cd = new TCD_CadContaGer();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Excluir(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir conta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
