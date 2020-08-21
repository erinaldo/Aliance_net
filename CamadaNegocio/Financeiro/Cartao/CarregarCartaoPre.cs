using CamadaDados.Financeiro.Caixa;
using CamadaDados.Financeiro.Cartao;
using CamadaNegocio.Financeiro.Caixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Financeiro.Cartao
{
    #region Fatura Cartao
    public class TCN_CarregarCartaoPre
    {
        public static TList_CarregaCartaoPre Buscar(string Id_carga,
                                                string Cd_empresa,
                                                string Id_cartao,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_carga))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_carga";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_carga;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_cartao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_cartao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cartao;
            }
            return new TCD_CarregaCartaoPre(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_CarregaCartaoPre val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CarregaCartaoPre qtb_fatura = new TCD_CarregaCartaoPre();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatura.CriarBanco_Dados(true);
                else
                    qtb_fatura.Banco_Dados = banco;
                CamadaDados.Financeiro.Cadastros.TList_CFGFaturaCartao lCfg =
                new CamadaDados.Financeiro.Cadastros.TCD_CFGFaturaCartao(qtb_fatura.Banco_Dados).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        }
                    }, 1, string.Empty);
                if (lCfg.Count == 0)
                    throw new Exception("Não existe CFG. Fatura Cartão!");
                if (!string.IsNullOrEmpty(val.Cd_contager))
                {
                    //Gravar caixa
                    string ret =
                    TCN_LanCaixa.GravaLanCaixa(
                        new TRegistro_LanCaixa()
                        {
                            Cd_ContaGer = val.Cd_contager,
                            Cd_Empresa = val.Cd_empresa,
                            Nr_Docto = "CRÉD. " + val.Nr_cartao.Trim(),
                            Cd_Historico = lCfg[0].Cd_historico_pag,
                            Login = Utils.Parametros.pubLogin,
                            ComplHistorico = "CRÉDITO CARTÃO",
                            Dt_lancto = val.Dt_carga,
                            Vl_PAGAR = val.Vl_carga,
                            Vl_RECEBER = decimal.Zero,
                            St_Titulo = "N",
                            St_Estorno = "N",
                            St_avulso = "N"
                        }, qtb_fatura.Banco_Dados);
                    val.Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_CD_LANCTOCAIXA"));
                }              
                val.Id_cargastr = CamadaDados.TDataQuery.getPubVariavel(qtb_fatura.Gravar(val), "@P_ID_CARGA");
                if (st_transacao)
                    qtb_fatura.Banco_Dados.Commit_Tran();
                return val.Id_cargastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatura.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar fatura: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatura.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CarregaCartaoPre val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CarregaCartaoPre qtb_fatura = new TCD_CarregaCartaoPre();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatura.CriarBanco_Dados(true);
                else
                    qtb_fatura.Banco_Dados = banco;
                //Estornar Caixa
                new TCD_LanCaixa(qtb_fatura.Banco_Dados).Select(
                    new Utils.TpBusca[]
                    {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.CD_ContaGer",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_contager.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.CD_LanctoCaixa",
                                    vOperador = "=",
                                    vVL_Busca = val.Cd_lanctocaixa.ToString()
                                }
                    }, 0, string.Empty).ForEach(x => TCN_LanCaixa.EstornarCaixa(x, null, qtb_fatura.Banco_Dados));
                qtb_fatura.Excluir(val);
                if (st_transacao)
                    qtb_fatura.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatura.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir fatura: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatura.deletarBanco_Dados();
            }
        }

    }
    #endregion
}
