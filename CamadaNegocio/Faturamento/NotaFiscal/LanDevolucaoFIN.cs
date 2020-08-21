using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_DevolucaoFIN
    {
        public static TList_DevolucaoFIN Buscar(string Cd_empresa,
                                                string Nr_lanctofiscal,
                                                string Nr_lancto,
                                                string Cd_parcela,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            if (!string.IsNullOrEmpty(Cd_parcela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_parcela;
            }
            return new TCD_DevolucaoFIN(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DevolucaoFIN val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DevolucaoFIN qtb_dev = new TCD_DevolucaoFIN();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dev.CriarBanco_Dados(true);
                else qtb_dev.Banco_Dados = banco;
                val.Id_devolucaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_dev.Gravar(val), "@P_ID_DEVOLUCAO");
                if (st_transacao)
                    qtb_dev.Banco_Dados.Commit_Tran();
                return val.Id_devolucaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dev.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dev.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DevolucaoFIN val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DevolucaoFIN qtb_dev = new TCD_DevolucaoFIN();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dev.CriarBanco_Dados(true);
                else qtb_dev.Banco_Dados = banco;
                if (val.Cd_lanctocaixa.HasValue)
                    Financeiro.Caixa.TCN_LanCaixa.EstornarSomenteCaixa(
                        Financeiro.Caixa.TCN_LanCaixa.Busca(val.Cd_contager,
                                                            val.Cd_lanctocaixastr,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            decimal.Zero,
                                                            decimal.Zero,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            false,
                                                            string.Empty,
                                                            decimal.Zero,
                                                            false,
                                                            qtb_dev.Banco_Dados)[0], qtb_dev.Banco_Dados);
                qtb_dev.Excluir(val);
                if (st_transacao)
                    qtb_dev.Banco_Dados.Commit_Tran();
                return val.Id_devolucaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dev.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dev.deletarBanco_Dados();
            }
        }
    }
}
