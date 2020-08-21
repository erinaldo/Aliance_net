using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_LanFaturamento_CMI
    {
        public static TList_RegLanFaturamento_CMI Busca(string vCD_Empresa,
                                                 string vNR_LanctoFiscal,
                                                 int vTop,
                                                 string vNM_Campo,
                                                 TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNR_LanctoFiscal))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_LanctoFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_LanctoFiscal;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            return new TCD_LanFaturamento_CMI(banco).Select(vBusca, vTop, vNM_Campo);
        }

        public static string Gravar(TRegistro_LanFaturamento_CMI val, TObjetoBanco banco)
        {
            TCD_LanFaturamento_CMI qtb_fatcmi = new TCD_LanFaturamento_CMI();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatcmi.CriarBanco_Dados(true);
                else
                    qtb_fatcmi.Banco_Dados = banco;
                string retorno = qtb_fatcmi.Gravar(val);
                if (st_transacao)
                    qtb_fatcmi.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatcmi.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar CMI Nota: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatcmi.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanFaturamento_CMI val, TObjetoBanco banco)
        {
            TCD_LanFaturamento_CMI qtb_fatcmi = new TCD_LanFaturamento_CMI();
            bool st_transacao = false;
            try
            {
                if (st_transacao)
                    st_transacao = qtb_fatcmi.CriarBanco_Dados(true);
                else
                    qtb_fatcmi.Banco_Dados = banco;
                qtb_fatcmi.Excluir(val);
                if (st_transacao)
                    qtb_fatcmi.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatcmi.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir CMI Nota: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatcmi.deletarBanco_Dados();
            }
        }

        public static void PreencherCMINota(TRegistro_LanFaturamento val, TObjetoBanco banco)
        {
            //Buscar registro cmi
            CamadaDados.Fiscal.TList_CadCMI lCmi =
                CamadaNegocio.Fiscal.TCN_CadCMI.Busca(val.Cd_cmistring,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      false,
                                                      false,
                                                      false,
                                                      false,
                                                      false,
                                                      false,
                                                      false,
                                                      banco);
            if (lCmi.Count > 0)
            {
                val.Cminf.Clear();
                val.Cminf.Add(
                    new TRegistro_LanFaturamento_CMI()
                    {
                        St_complementar = lCmi[0].St_complementar,
                        St_devolucao = lCmi[0].St_devolucao,
                        St_geraestoque = lCmi[0].St_geraestoque,
                        St_mestra = lCmi[0].St_mestra,
                        St_simplesremessa = lCmi[0].St_simplesremessa,
                        St_compdevimposto = lCmi[0].St_compdevimposto,
                        St_retorno = lCmi[0].St_retorno
                    });
            }
        }
    }
}
