using System;
using System.Collections.Generic;
using Utils;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CadCondFiscalICMS
    {
        public static TList_CadCondFiscalICMS Busca(string id_condFiscalICMS, 
                                                    string cd_condFiscalProd, 
                                                    string Cd_condFiscalClifor,
                                                    string Cd_uforigem,
                                                    string Cd_ufdestino,
                                                    string Tp_movimento,
                                                    string Cd_st,
                                                    string Cd_imposto,
                                                    string Cd_movimentacao,
                                                    string Cd_empresa,
                                                    string Cd_cfop,
                                                    bool St_somaripibaseicms,
                                                    bool St_somaripibasest,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(id_condFiscalICMS))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_condFiscal_ICMS";
                vBusca[vBusca.Length - 1].vVL_Busca = id_condFiscalICMS;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(cd_condFiscalProd))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CondFiscal_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cd_condFiscalProd.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_condFiscalClifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CondFiscal_Clifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_condFiscalClifor.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_uforigem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_UFOrig";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_uforigem.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_ufdestino))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_UFDest";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_ufdestino.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_movimento";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Tp_movimento.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_st))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_st";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_st.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_imposto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_imposto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_imposto.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_movimentacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_movimentacao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_movimentacao.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if(!string.IsNullOrEmpty(Cd_cfop))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_cfop";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_cfop.Trim() + "'";
            }
            if (St_somaripibaseicms)
                Estruturas.CriarParametro(ref vBusca, "a.ST_SomarIPIBaseICMS", "1");
            if (St_somaripibasest)
                Estruturas.CriarParametro(ref vBusca, "a.ST_SomarIPIBaseST", "1");
            return new TCD_CadCondFiscalICMS(banco).Select(vBusca, 0, string.Empty);
        }
        
        public static string Gravar(TRegistro_CadCondFiscalICMS val, 
                                    List<TRegistro_CadMovimentacao> lMov,
                                    List<CamadaDados.Financeiro.Cadastros.TRegistro_CadUf> lUfOrig,
                                    List<CamadaDados.Financeiro.Cadastros.TRegistro_CadUf> lUfDest,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCondFiscalICMS icms = new TCD_CadCondFiscalICMS();
            try
            {
                if (banco == null)
                    st_transacao = icms.CriarBanco_Dados(true);
                else
                    icms.Banco_Dados = banco;
                string retorno = string.Empty;
                lMov.ForEach(p =>
                    {
                        lUfOrig.ForEach(v =>
                            {
                                lUfDest.ForEach(x =>
                                    {
                                        val.Cd_movimentacao = p.Cd_movimentacao;
                                        val.Cd_uforig = v.Cd_uf;
                                        val.Cd_ufdest = x.Cd_uf;
                                        retorno = icms.Gravar(val);
                                    });
                            });
                    });
                if (st_transacao)
                    icms.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    icms.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    icms.deletarBanco_Dados();
            }
        }
        
        public static string Excluir(TRegistro_CadCondFiscalICMS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCondFiscalICMS icms = new TCD_CadCondFiscalICMS();
            try
            {
                if (banco == null)
                    st_transacao = icms.CriarBanco_Dados(true);
                else
                    icms.Banco_Dados = banco;
                icms.Excluir(val);
                if (st_transacao)
                    icms.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    icms.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    icms.deletarBanco_Dados();
            }
        }
    }
}
