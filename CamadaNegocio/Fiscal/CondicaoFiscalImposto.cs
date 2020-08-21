using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CondicaoFiscalImposto
    {
        public static TList_CondicaoFiscalImposto Buscar(string cd_municipiogeradoriss,
                                                         string Cd_imposto, 
                                                         string Id_condicao,
                                                         string Tp_faturamento,
                                                         string Tp_pessoa,
                                                         string Cd_condfiscal_produto,
                                                         string Cd_movimentacao,
                                                         string Cd_empresa,
                                                         string Cd_condfiscal_clifor,
                                                         BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_imposto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_Imposto";
                vBusca[vBusca.Length - 1].vVL_Busca = Cd_imposto.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Id_condicao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Condicao";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_condicao.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Tp_faturamento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Faturamento";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + Tp_faturamento.Trim() + ")";
                vBusca[vBusca.Length - 1].vOperador = "in";
            }
            if (!string.IsNullOrEmpty(Tp_pessoa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Pessoa";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + Tp_pessoa.Trim() + ")";
                vBusca[vBusca.Length - 1].vOperador = "in";
            }
            if (!string.IsNullOrEmpty(Cd_condfiscal_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_condfiscal_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_condfiscal_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_movimentacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_movimentacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Cd_movimentacao.ToString();
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_condfiscal_clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_condfiscal_clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_condfiscal_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_municipiogeradoriss))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_municipiogeradoriss";
                vBusca[vBusca.Length - 1].vVL_Busca = cd_municipiogeradoriss.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            
            return new TCD_CondicaoFiscalImposto(banco).Select(vBusca, 0, "");
        }

        public static string gravarFiscImposto(TRegistro_CondicaoFiscalImposto val, 
                                               List<TRegistro_CadMovimentacao> lMov, 
                                               List<TRegistro_CadCondFiscalClifor> lClifor, 
                                               List<TRegistro_CadCondFiscalProduto> lProd,
                                               bool St_fisica,
                                               bool St_juridica,
                                               bool St_estrangeiro,
                                               BancoDados.TObjetoBanco banco)
        {
            string retorno = string.Empty;
            TCD_CondicaoFiscalImposto fis = new TCD_CondicaoFiscalImposto(banco);
            lMov.ForEach(p =>
                {
                    lClifor.ForEach(v =>
                        {
                            if (lProd.Count > 0)
                                lProd.ForEach(x =>
                                    {
                                        if (St_fisica)
                                        {
                                            val.cd_movimentacao = p.Cd_movimentacao.Value;
                                            val.cd_condfiscal_clifor = v.Cd_condFiscal_clifor;
                                            val.cd_condfiscal_produto = x.CD_CONDFISCAL_PRODUTO;
                                            val.Tp_pessoa = "F";
                                            retorno = fis.Gravar(val);
                                        }
                                        if (St_juridica)
                                        {
                                            val.cd_movimentacao = p.Cd_movimentacao.Value;
                                            val.cd_condfiscal_clifor = v.Cd_condFiscal_clifor;
                                            val.cd_condfiscal_produto = x.CD_CONDFISCAL_PRODUTO;
                                            val.Tp_pessoa = "J";
                                            retorno = fis.Gravar(val);
                                        }
                                        if (St_estrangeiro)
                                        {
                                            val.cd_movimentacao = p.Cd_movimentacao.Value;
                                            val.cd_condfiscal_clifor = v.Cd_condFiscal_clifor;
                                            val.cd_condfiscal_produto = x.CD_CONDFISCAL_PRODUTO;
                                            val.Tp_pessoa = "E";
                                            retorno = fis.Gravar(val);
                                        }
                                    });
                            else
                            {
                                if (St_fisica)
                                {
                                    val.cd_movimentacao = p.Cd_movimentacao.Value;
                                    val.cd_condfiscal_clifor = v.Cd_condFiscal_clifor;
                                    val.Tp_pessoa = "F";
                                    retorno = fis.Gravar(val);
                                }
                                if (St_juridica)
                                {
                                    val.cd_movimentacao = p.Cd_movimentacao.Value;
                                    val.cd_condfiscal_clifor = v.Cd_condFiscal_clifor;
                                    val.Tp_pessoa = "J";
                                    retorno = fis.Gravar(val);
                                }
                                if (St_estrangeiro)
                                {
                                    val.cd_movimentacao = p.Cd_movimentacao.Value;
                                    val.cd_condfiscal_clifor = v.Cd_condFiscal_clifor;
                                    val.Tp_pessoa = "E";
                                    retorno = fis.Gravar(val);
                                }
                            }
                        });
                });
            return retorno;
        }

        public static string deletarFisImposto(TList_CondicaoFiscalImposto val, BancoDados.TObjetoBanco banco)
        {
            string retorno = string.Empty;
            val.ForEach(p => retorno = deletarFisImposto(p, banco));
            return retorno;
        }

        public static string deletarFisImposto(TRegistro_CondicaoFiscalImposto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CondicaoFiscalImposto qtb_cond = new TCD_CondicaoFiscalImposto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cond.CriarBanco_Dados(true);
                else
                    qtb_cond.Banco_Dados = banco;
                qtb_cond.Excluir(val);
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if(st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }
    }
}
