using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.ProvisaoDRG;

namespace CamadaNegocio.Financeiro.ProvisaoDRG
{
    public class TCN_SaldoProvisaoDRG
    {
        public static TList_SaldoProvisaoDRG Buscar(string Cd_empresa,
                                                    decimal Ano,
                                                    decimal Mes,
                                                    int vTop,
                                                    string vNm_campo,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Ano > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ano";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Ano.ToString();
            }
            if (Mes > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.mes";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Mes.ToString();
            }
            return new TCD_SaldoProvisaoDRG(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarSaldoProvisaoDRG(TRegistro_SaldoProvisaoDRG val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SaldoProvisaoDRG qtb_saldo = new TCD_SaldoProvisaoDRG();
            try
            {
                if (banco == null)
                {
                    qtb_saldo.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_saldo.Banco_Dados = banco;
                //Gravar Saldo Provisao
                string retorno = qtb_saldo.GravarSaldoProvisaoDRG(val);
                if (st_transacao)
                    qtb_saldo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if(st_transacao)
                    qtb_saldo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: "+ex.Message);
            }
            finally
            {
                if(st_transacao)
                    qtb_saldo.deletarBanco_Dados();
            }
        }

        public static string DeletarSaldoProvisaoDRG(TRegistro_SaldoProvisaoDRG val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SaldoProvisaoDRG qtb_saldo = new TCD_SaldoProvisaoDRG();
            try
            {
                if (banco == null)
                {
                    qtb_saldo.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_saldo.Banco_Dados = banco;
                //Deletar Saldo Provisao
                qtb_saldo.DeletarSaldoProvisaoDRG(val);
                if (st_transacao)
                    qtb_saldo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_saldo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_saldo.deletarBanco_Dados();
            }
        }
    }
}
