using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Caixa;

namespace CamadaNegocio.Financeiro.Caixa
{
    public class TCN_LanFechamentoCaixa
    {
        public static TList_LanFechamentoCaixa Buscar(decimal vId_fechamento,
                                               string vDt_fechamento,
                                               string vDt_fechamentoini,
                                               string vDt_fechamentofin,
                                               string vCd_contager,
                                               int vTop,
                                               string vNm_campo,
                                               string vOrder,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vId_fechamento > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.id_fechamento";
                filtro[filtro.Length - 1].vVL_Busca = vId_fechamento.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if ((vDt_fechamento.Trim() != string.Empty) && (vDt_fechamento.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), b.dt_fechamento)))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_fechamento).ToString("yyyyMMdd")) + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if ((vDt_fechamentoini.Trim() != string.Empty) && (vDt_fechamentoini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), b.dt_fechamento)))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_fechamentoini).ToString("yyyyMMdd")) + "'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((vDt_fechamentofin.Trim() != string.Empty) && (vDt_fechamentofin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), b.dt_fechamento)))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_fechamentofin).ToString("yyyyMMdd")) + "'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if(vCd_contager.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.cd_contager";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_contager.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new TCD_LanFechamentoCaixa(banco).Select(filtro, vTop, vNm_campo, vOrder);
        }

        public static string GravarFechamentoCaixa(TRegistro_LanFechamentoCaixa val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFechamentoCaixa qtb_fechamento = new TCD_LanFechamentoCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fechamento.CriarBanco_Dados(true);
                else
                    qtb_fechamento.Banco_Dados = banco;
                string retorno = qtb_fechamento.GravarFechamentoCaixa(val);
                if (st_transacao)
                    qtb_fechamento.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (st_transacao)
                    qtb_fechamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar fechamento de caixa: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_fechamento.deletarBanco_Dados();
            }
        }

        public static string DeletarFechamentoCaixa(TRegistro_LanFechamentoCaixa val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFechamentoCaixa qtb_fechamento = new TCD_LanFechamentoCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fechamento.CriarBanco_Dados(true);
                else
                    qtb_fechamento.Banco_Dados = banco;
                TList_LanFechamentoCaixa lFechamento = Buscar(decimal.Zero,
                                                             string.Empty,
                                                             val.Dt_ultimofechamentostring,
                                                             string.Empty,
                                                             val.Cd_contager,
                                                             0,
                                                             string.Empty,
                                                             string.Empty,
                                                             qtb_fechamento.Banco_Dados);
                lFechamento.ForEach(p => qtb_fechamento.DeletarFechamentoCaixa(p));
                if (st_transacao)
                    qtb_fechamento.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (st_transacao)
                    qtb_fechamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir fechamento caixa: " +  ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_fechamento.deletarBanco_Dados();
            }
        }
    }
}
