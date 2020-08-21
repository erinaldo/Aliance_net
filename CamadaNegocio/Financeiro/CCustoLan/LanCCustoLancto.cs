using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.CCustoLan;
using CamadaNegocio.ConfigGer;

namespace CamadaNegocio.Financeiro.CCustoLan
{
    public class TCN_LanCCustoLancto
    {
        public static TList_LanCCustoLancto Buscar(string vId_CCustoLan, 
                                                   string vCd_CentroResult,
                                                   string vCd_empresa,
                                                   string vCd_clifor,
                                                   string vDt_ini,
                                                   string vDt_fin,
                                                   decimal vVl_Lancto,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_CCustoLan))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_ccustolan";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_CCustoLan;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_CentroResult))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_centroresult";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_CentroResult.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_clifor))
                Estruturas.CriarParametro(ref vBusca, "ISNULL(dup.CD_Clifor, venda.CD_Clifor)", "'" + vCd_clifor.Trim() + "'");
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
            }
            if (vVl_Lancto > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.vl_lancto";
                vBusca[vBusca.Length - 1].vVL_Busca = vVl_Lancto.ToString(new System.Globalization.CultureInfo("en-US"));
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            return new TCD_LanCCustoLancto(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanCCustoLancto val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanCCustoLancto lan = new TCD_LanCCustoLancto();
            try
            {
                if (banco == null)
                    st_transacao = lan.CriarBanco_Dados(true);
                else
                    lan.Banco_Dados = banco;
                val.Id_ccustolan = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(lan.Gravar(val), "@P_ID_CCUSTO"));
                if (st_transacao)
                    lan.Banco_Dados.Commit_Tran();
                return val.Id_ccustolanstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    lan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar resultado: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    lan.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanCCustoLancto val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanCCustoLancto lan = new TCD_LanCCustoLancto();
            try
            {
                if (banco == null)
                    st_transacao = lan.CriarBanco_Dados(true);
                else
                    lan.Banco_Dados = banco;
                lan.Excluir(val);
                if (st_transacao)
                    lan.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (st_transacao)
                    lan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir resultado: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    lan.deletarBanco_Dados();
            }
        }
    }
}
