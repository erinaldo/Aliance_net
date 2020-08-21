using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Faturamento.CTRC;

namespace CamadaNegocio.Faturamento.CTRC
{
    public static class TCN_CTREstoque
    {
        public static TList_CTREstoque Buscar(string Cd_empresa,
                                              string Nr_lanctoctr,
                                              string Id_nota,
                                              string Cd_produto,
                                              string Id_lanctoestoque,
                                              short vTop,
                                              string vNm_campo,
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
            if (!string.IsNullOrEmpty(Nr_lanctoctr))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctoctr";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoctr;
            }
            if (!string.IsNullOrEmpty(Id_nota))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nota";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nota;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_lanctoestoque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lanctoestoque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lanctoestoque;
            }
            return new TCD_CTREstoque(banco).Select(filtro, vTop, vNm_campo);
        }

        public static CamadaDados.Estoque.TList_RegLanEstoque BuscarEstoque(string Cd_empresa,
                                                                            string Nr_lanctoctr,
                                                                            string Id_nota,
                                                                            BancoDados.TObjetoBanco banco)
        {
            if ((!string.IsNullOrEmpty(Cd_empresa)) &&
                (!string.IsNullOrEmpty(Nr_lanctoctr)) &&
                (!string.IsNullOrEmpty(Id_nota)))
                return new CamadaDados.Estoque.TCD_LanEstoque(banco).Select(new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_ctr_estoque x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_produto = a.cd_produto " +
                                    "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.nr_lanctoctr = " + Nr_lanctoctr + " " +
                                    "and x.id_nota = " + Id_nota + ")"
                    }
                }, 0, string.Empty, string.Empty, string.Empty);
            else
                return new CamadaDados.Estoque.TList_RegLanEstoque();
        }

        public static string Gravar(TRegistro_CTREstoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTREstoque qtb_ctrc = new TCD_CTREstoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctrc.CriarBanco_Dados(true);
                else
                    qtb_ctrc.Banco_Dados = banco;
                //Gravar Estoque CTRC
                string retorno = qtb_ctrc.Gravar(val);
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar estoque CTRC: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctrc.deletarBanco_Dados();
            }
        }

        public static void Processar(TRegistro_ConhecimentoFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTREstoque qtb_ctrc = new TCD_CTREstoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctrc.CriarBanco_Dados(true);
                else
                    qtb_ctrc.Banco_Dados = banco;
                val.lNf.ForEach(p =>
                    //Para cada nota fiscal buscar os itens
                        p.ItensNota = NotaFiscal.TCN_LanFaturamento_Item.Busca(p.Cd_empresa,
                                                                               p.Nr_lanctofiscalstr,
                                                                               string.Empty,
                                                                               qtb_ctrc.Banco_Dados));
                //Totalizar os valores das notas fiscais
                decimal vl_total = val.lNf.Sum(p => p.ItensNota.Sum(v => v.Vl_subtotal + v.Vl_freteitem + v.Vl_ipi));
                val.lNf.ForEach(p =>
                    {
                        CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_CMI lFatCmi =
                            NotaFiscal.TCN_LanFaturamento_CMI.Busca(p.Cd_empresa,
                                                                    p.Nr_lanctofiscal.ToString(),
                                                                    0,
                                                                    string.Empty,
                                                                    qtb_ctrc.Banco_Dados);
                        if(lFatCmi.Exists(x=> x.St_geraestoque.Trim().ToUpper().Equals("S")))
                        {
                            p.ItensNota.ForEach(v=>
                                {
                                    if (v.St_servico.Trim().ToUpper() != "S")
                                        v.Vl_complementoEstoqueCTRC = Math.Round(((val.Vl_frete * (((v.Vl_subtotal + v.Vl_freteitem + v.Vl_ipi) / vl_total) * 100)) / 100), 2);
                                });
                        }
                    });
                //Validar total rateio do frete igual ao valor do frete
                decimal vl_diferenca = val.Vl_frete - val.lNf.Sum(p=> p.ItensNota.Sum(v=> v.Vl_complementoEstoqueCTRC));
                if (!vl_diferenca.Equals(0))
                    for (int i = val.lNf.Count - 1; i >= 0; i--)
                    {
                        CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_CMI lFatCmi =
                            NotaFiscal.TCN_LanFaturamento_CMI.Busca(val.lNf[i].Cd_empresa,
                                                                    val.lNf[i].Nr_lanctofiscal.ToString(),
                                                                    0,
                                                                    string.Empty,
                                                                    qtb_ctrc.Banco_Dados);
                        if (lFatCmi.Exists(x => x.St_geraestoque.Trim().ToUpper().Equals("S")))
                        {
                            val.lNf[i].ItensNota[val.lNf[i].ItensNota.Count - 1].Vl_complementoEstoqueCTRC += vl_diferenca;
                            break;
                        }
                    }
                //Gravar lancamentos de estoque
                val.lNf.ForEach(p =>
                    {
                        p.ItensNota.ForEach(v =>
                            {
                                if (v.Vl_complementoEstoqueCTRC > 0)
                                {
                                    if(!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_ctrc.Banco_Dados).ProdutoConsumoInterno(v.Cd_produto))
                                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_ctrc.Banco_Dados).ProdutoComposto(v.Cd_produto))
                                        {
                                            //Buscar versao da formula
                                            CamadaDados.Producao.Producao.TList_FichaTec_MPrima lFicha = 
                                                new CamadaDados.Producao.Producao.TCD_FichaTec_MPrima(qtb_ctrc.Banco_Dados).Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_prd_formula_apontamento x "+
                                                                    "inner join tb_prd_fichatec_acabado y "+
                                                                    "on x.cd_empresa = y.cd_empresa " +
                                                                    "and x.id_formulacao = y.id_formulacao "+
                                                                    "where x.cd_empresa = a.cd_empresa "+
                                                                    "and x.id_formulacao = a.id_formulacao "+
                                                                    "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' "+
                                                                    "and y.cd_produto = '" + v.Cd_produto.Trim() + "')"
                                                    }
                                                }, 0, string.Empty);
                                            
                                            decimal qtd_itens = lFicha.Sum(q => q.Qtd_produto);
                                            lFicha.ForEach(r => r.Vl_complementoEstoqueCTRC = Math.Round(((v.Vl_complementoEstoqueCTRC * ((r.Qtd_produto / qtd_itens) * 100)) / 100), 2));
                                            decimal diferenca = v.Vl_complementoEstoqueCTRC - lFicha.Sum(r => r.Vl_complementoEstoqueCTRC);
                                            if (!vl_diferenca.Equals(0))
                                                lFicha[lFicha.Count - 1].Vl_complementoEstoqueCTRC += vl_diferenca;
                                            lFicha.ForEach(r =>
                                                {
                                                    string ret_estoque = Estoque.TCN_LanEstoque.GravarEstoque(
                                                                    new CamadaDados.Estoque.TRegistro_LanEstoque()
                                                                    {
                                                                        Cd_empresa = r.Cd_empresa,
                                                                        Cd_local = r.Cd_local,
                                                                        Cd_produto = r.Cd_produto,
                                                                        Ds_observacao = "CTRC: " + val.Nr_ctrcstr.Trim(),
                                                                        Dt_lancto = val.Dt_saient,
                                                                        Qtd_entrada = decimal.Zero,
                                                                        Qtd_saida = decimal.Zero,
                                                                        St_registro = "A",
                                                                        Tp_lancto = "L", //Complemento
                                                                        Tp_movimento = "E",
                                                                        Vl_subtotal = r.Vl_complementoEstoqueCTRC,
                                                                        Vl_unitario = r.Vl_complementoEstoqueCTRC
                                                                    }, qtb_ctrc.Banco_Dados);
                                                    //Buscar Id_nota
                                                    object obj_id_nota = new TCD_CTRNotaFiscal(qtb_ctrc.Banco_Dados).BuscarEscalar(
                                                                            new TpBusca[]
                                                                            {
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = "a.cd_empresa",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                                                },
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = "a.nr_lanctofiscal",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = v.Nr_lanctofiscal.ToString()
                                                                                }
                                                                            }, "a.id_nota");
                                                    TCN_CTREstoque.Gravar(
                                                        new TRegistro_CTREstoque()
                                                        {
                                                            Cd_empresa = r.Cd_empresa,
                                                            Cd_produto = r.Cd_produto,
                                                            Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_estoque, "@@P_ID_LANCTOESTOQUE")),
                                                            Nr_lanctoctr = val.Nr_lanctoCTRC,
                                                            Id_nota = decimal.Parse(obj_id_nota.ToString()),
                                                            Nr_lanctofiscal = v.Nr_lanctofiscal,
                                                            ID_NFItem = v.Id_nfitem
                                                        }, qtb_ctrc.Banco_Dados);
                                                });
                                        }
                                        else
                                        {
                                            string ret_estoque = CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(
                                                                    new CamadaDados.Estoque.TRegistro_LanEstoque()
                                                                    {
                                                                        Cd_empresa = val.Cd_empresa,
                                                                        Cd_local = v.Cd_local,
                                                                        Cd_produto = v.Cd_produto,
                                                                        Ds_observacao = "CTRC: " + val.Nr_ctrcstr.Trim(),
                                                                        Dt_lancto = val.Dt_saient,
                                                                        Qtd_entrada = decimal.Zero,
                                                                        Qtd_saida = decimal.Zero,
                                                                        St_registro = "A",
                                                                        Tp_lancto = "L", //Complemento
                                                                        Tp_movimento = "E",
                                                                        Vl_subtotal = v.Vl_complementoEstoqueCTRC,
                                                                        Vl_unitario = v.Vl_complementoEstoqueCTRC
                                                                    }, qtb_ctrc.Banco_Dados);
                                            //Buscar Id_nota
                                            object obj_id_nota = new CamadaDados.Faturamento.CTRC.TCD_CTRNotaFiscal(qtb_ctrc.Banco_Dados).BuscarEscalar(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.cd_empresa",
                                                                            vOperador = "=",
                                                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                                        },
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.nr_lanctofiscal",
                                                                            vOperador = "=",
                                                                            vVL_Busca = v.Nr_lanctofiscal.ToString()
                                                                        }
                                                                    }, "a.id_nota");
                                            TCN_CTREstoque.Gravar(
                                                new TRegistro_CTREstoque()
                                                {
                                                    Cd_empresa = val.Cd_empresa,
                                                    Cd_produto = v.Cd_produto,
                                                    Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_estoque, "@@P_ID_LANCTOESTOQUE")),
                                                    Nr_lanctoctr = val.Nr_lanctoCTRC,
                                                    Id_nota = decimal.Parse(obj_id_nota.ToString()),
                                                    Nr_lanctofiscal = v.Nr_lanctofiscal,
                                                    ID_NFItem = v.Id_nfitem
                                                }, qtb_ctrc.Banco_Dados);
                                        }
                                }
                            });
                    });
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar estoque conhecimento frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctrc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTREstoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTREstoque qtb_ctrc = new TCD_CTREstoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctrc.CriarBanco_Dados(true);
                else
                    qtb_ctrc.Banco_Dados = banco;
                //Deletar Estoque CTRC
                qtb_ctrc.Excluir(val);
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar estoque CTRC: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctrc.deletarBanco_Dados();
            }
        }
    }
}
