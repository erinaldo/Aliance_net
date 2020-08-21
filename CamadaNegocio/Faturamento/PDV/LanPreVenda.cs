using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Faturamento.PDV;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_PreVenda
    {
        public static TList_PreVenda Buscar(string Cd_empresa,
                                            string Id_prevenda,
                                            string Cd_clifor,
                                            string Nm_clifor,
                                            string Cd_vendedor,
                                            string Dt_ini,
                                            string Dt_fin,
                                            string St_registro,
                                            bool St_SaldoFaturar,
                                            string vOrder,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nm_clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.nm_clifor";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + Nm_clifor.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_prevenda";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_prevenda;
            }
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_vendedor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (St_SaldoFaturar)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_faturada, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "<>";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
            }
            return new TCD_PreVenda(banco).Select(vBusca, 0, string.Empty, vOrder);
        }

        public static string Gravar(TRegistro_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda qtb_pre = new TCD_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pre.CriarBanco_Dados(true);
                else
                    qtb_pre.Banco_Dados = banco;
                val.Id_prevendastr = CamadaDados.TDataQuery.getPubVariavel(qtb_pre.Gravar(val), "@P_ID_PREVENDA");
                //Gravar itens venda
                val.lItensDel.ForEach(p => TCN_ItensPreVenda.Excluir(p, qtb_pre.Banco_Dados));
                val.lItens.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_prevenda = val.Id_prevenda;
                        TCN_ItensPreVenda.Gravar(p, qtb_pre.Banco_Dados);
                    });
                //Excluir financeiro
                TList_PreVenda_DT_Vencto lParc = TCN_PreVenda_DT_Vencto.Buscar(val.Id_prevendastr, val.Cd_empresa, qtb_pre.Banco_Dados);
                lParc.ForEach(p => TCN_PreVenda_DT_Vencto.Excluir(p, qtb_pre.Banco_Dados));
                //Gravar financeiro
                val.DT_Vencto.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_prevenda = val.Id_prevenda;
                    TCN_PreVenda_DT_Vencto.Gravar(p, qtb_pre.Banco_Dados);
                });
                //Resgatar Pontos Fidelidade
                if (val.lItens.Exists(p => p.Qtd_pontosutilizados > decimal.Zero))
                {
                    //Buscar listagem de pontos com saldo a recuperar
                    CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade lPontos =
                        new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade(qtb_pre.Banco_Dados).Select(
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
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = string.Empty,
                                        vVL_Busca = "a.dt_validade is null or convert(datetime, floor(convert(decimal(30,10), a.dt_validade))) >= convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    }
                        }, 0, string.Empty, string.Empty);
                    val.lItens.Where(p => p.Qtd_pontosutilizados > decimal.Zero).ToList().ForEach(p =>
                        {
                            decimal pontos_resgatar = p.Qtd_pontosutilizados;
                            decimal pontos = decimal.Zero;
                            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor(qtb_pre.Banco_Dados);
                            foreach (CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade rPonto in lPontos.OrderBy(v => v.Dt_registro).ToList())
                            {
                                if (pontos_resgatar > decimal.Zero)
                                {
                                    pontos = pontos_resgatar < rPonto.SD_Pontos ? pontos_resgatar : rPonto.SD_Pontos;
                                    CamadaNegocio.Faturamento.Fidelizacao.TCN_ResgatePontos.Gravar(
                                        new CamadaDados.Faturamento.Fidelizacao.TRegistro_ResgatePontos()
                                        {
                                            Cd_empresa = rPonto.Cd_empresa,
                                            Id_ponto = rPonto.Id_ponto,
                                            Login = Utils.Parametros.pubLogin,
                                            Qt_pontos = pontos,
                                            Dt_resgate = dt_atual,
                                            Id_prevenda = val.Id_prevenda,
                                            Id_itemprevenda = p.Id_itemprevenda,
                                            St_registro = "A"
                                        }, qtb_pre.Banco_Dados);
                                    pontos_resgatar -= pontos;
                                    rPonto.Pontos_res += pontos;
                                }
                                else break;
                            }
                        });
                }
                if (st_transacao)
                    qtb_pre.Banco_Dados.Commit_Tran();
                return val.Id_prevendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pre.deletarBanco_Dados();
                throw new Exception("Erro gravar venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pre.deletarBanco_Dados();
            }
        }

        public static void Excluir(List<TRegistro_PreVenda> val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda qtb_pre = new TCD_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pre.CriarBanco_Dados(true);
                else
                    qtb_pre.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        //Verificar se prevenda possui faturamento
                        object obj = new TCD_VendaRapida(qtb_pre.Banco_Dados).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador= "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new TpBusca
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_prevenda_x_vendarapida x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.id_cupom = a.id_vendarapida " +
                                                            "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                            "and x.id_prevenda = " + p.Id_prevendastr + ")"
                                            }
                                        }, "a.Id_Cupom");
                        if (obj != null)
                            throw new Exception("Item Pre Venda Nº" + p.Id_prevendastr + " esta faturado.\r\n" +
                                                "Para excluir o item, necessario estornar venda Nº" + obj.ToString() + ".");
                        //Verificar se prevenda tem item com origem locacao
                        if (new TCD_ItensPreVenda(qtb_pre.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(exists(select 1 from tb_fat_locacao_x_prevenda x " +
                                                "            where x.cd_empresa = '" + p.Cd_empresa.Trim()+"'"+
                                                "           and x.id_prevenda = "+p.Id_prevendastr+ ") or " +
                                                "exists(select 1 from tb_fat_itenslocacao_x_prevenda x " +
                                                "           where x.cd_empresa = " + p.Cd_empresa.Trim()+"'"+
                                                "           and x.id_prevenda = "+p.Id_prevendastr+ "))"
                                }
                            }, "1") != null)
                            throw new Exception("Item Pre Venda Nº" + p.Id_prevendastr + " teve origem Locação.\r\n" +
                                                "Para excluir o item, necessario estornar processamento locação.");
                        //Verificar se prevenda possui romaneio entrega
                        new CamadaDados.Faturamento.Entrega.TCD_RomaneioEntrega(qtb_pre.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_itensromaneio x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.id_romaneio = a.id_romaneio " +
                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                "and x.id_prevenda = " + p.Id_prevendastr + ")"
                                }
                            }, 0, string.Empty).ForEach(v=> Entrega.TCN_RomaneioEntrega.Excluir(v, qtb_pre.Banco_Dados));
                        //Verificar se Pré-venda possui OS
                        new CamadaDados.Servicos.TCD_Pecas_X_PreVenda(qtb_pre.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from VTB_PDV_ITENSPREVENDA x " +
                                                "where a.id_itemprevenda = x.id_itemprevenda " +
                                                "and a.cd_empresa = '" + p.Cd_empresa.Trim() + "'" + 
                                                "and a.id_prevenda = " + p.Id_prevendastr + ")"
                                }
                            },0, string.Empty).ForEach(x=> Servicos.TCN_Pecas_X_PreVenda.Excluir(x, qtb_pre.Banco_Dados));
                        //Verificar se Pré-venda possui Locação - Modulo Locação
                        new CamadaDados.Locacao.TCD_Itens_X_PreVenda(qtb_pre.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from VTB_PDV_ITENSPREVENDA x " +
                                                "where a.id_itemprevenda = x.id_itemprevenda " +
                                                "and a.cd_empresa = '" + p.Cd_empresa.Trim() + "'" + 
                                                "and a.id_prevenda = " + p.Id_prevendastr + ")"
                                }
                            }, 0, string.Empty).ForEach(x => CamadaNegocio.Locacao.TCN_Itens_X_PreVenda.Excluir(x, qtb_pre.Banco_Dados));
                        //Cancelar Resgate Pontos
                        Fidelizacao.TCN_ResgatePontos.Buscar(p.Cd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             p.Id_prevendastr,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             qtb_pre.Banco_Dados).ForEach(v =>
                                                                {
                                                                    v.St_registro = "C";
                                                                    v.Logincanc = Parametros.pubLogin;
                                                                    Fidelizacao.TCN_ResgatePontos.Gravar(v, qtb_pre.Banco_Dados);
                                                                });
                        p.St_registro = "C";
                        qtb_pre.Gravar(p);
                    });
                if (st_transacao)
                    qtb_pre.Banco_Dados.Commit_Tran();
            }catch(Exception ex)
            {
                if(st_transacao)
                    qtb_pre.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir venda: " + ex.Message.Trim());
            }finally
            {
                if(st_transacao)
                    qtb_pre.deletarBanco_Dados();
            }
        }

        public static void RatearDesconto(TRegistro_PreVenda val, decimal Tot_desconto, decimal Pc_desconto)
        {
            if (val != null)
            {
                decimal tot_subtotal = val.lItens.Sum(p => p.Vl_subtotal);
                if (Pc_desconto.Equals(decimal.Zero))
                    Pc_desconto = Math.Round(decimal.Divide(decimal.Multiply(Tot_desconto, 100), tot_subtotal), 2, MidpointRounding.AwayFromZero);
                if (Tot_desconto.Equals(decimal.Zero))
                    Tot_desconto = Math.Round(decimal.Divide(decimal.Multiply(Pc_desconto, tot_subtotal), 100), 2, MidpointRounding.AwayFromZero);
                val.lItens.ForEach(p =>
                {
                    p.Vl_desconto = Math.Round(decimal.Multiply(p.Vl_subtotal, decimal.Divide(Pc_desconto, 100)), 2, MidpointRounding.AwayFromZero);
                    p.Pc_desconto = Pc_desconto;
                });
                decimal dif = Tot_desconto - val.lItens.Sum(p => p.Vl_desconto);
                if (dif != decimal.Zero)
                    val.lItens.FindLast(p => p.Vl_desconto + dif >= decimal.Zero).Vl_desconto += dif;
            }
        }

        public static void RatearAcrescimo(TRegistro_PreVenda val, decimal Tot_acrescimo, decimal Pc_acrescimo)
        {
            if (val != null)
            {
                decimal tot_subtotal = val.lItens.Sum(p => p.Vl_subtotal);
                if (Pc_acrescimo.Equals(decimal.Zero))
                    Pc_acrescimo = Math.Round(decimal.Divide(decimal.Multiply(Tot_acrescimo, 100), tot_subtotal), 2, MidpointRounding.AwayFromZero);
                if (Tot_acrescimo.Equals(decimal.Zero))
                    Tot_acrescimo = Math.Round(decimal.Divide(decimal.Multiply(Pc_acrescimo, tot_subtotal), 100), 2, MidpointRounding.AwayFromZero);
                val.lItens.ForEach(p =>
                {
                    p.Vl_acrescimo = Math.Round(decimal.Multiply(p.Vl_subtotal, decimal.Divide(Pc_acrescimo, 100)), 2, MidpointRounding.AwayFromZero);
                    p.Pc_acrescimo = Pc_acrescimo;
                });
                decimal dif = Tot_acrescimo - val.lItens.Sum(p => p.Vl_acrescimo);
                if (dif != decimal.Zero)
                    val.lItens.FindLast(p => p.Vl_acrescimo + dif >= decimal.Zero).Vl_acrescimo += dif;
            }
        }

        public static void RatearFrete(TRegistro_PreVenda val, decimal Tot_frete)
        {
            if (val != null)
            {
                //Ratear Frete de acordo com a % do Item
                   val.lItens.ForEach(p=>
                    {                      
                        decimal pc_frete = Math.Round(decimal.Multiply(decimal.Divide(p.Vl_subtotal, val.lItens.Sum(x=> x.Vl_subtotal)), 100), 2, MidpointRounding.AwayFromZero);
                        p.Vl_frete = Math.Round(decimal.Divide(decimal.Multiply(Tot_frete, pc_frete), 100), 2, MidpointRounding.AwayFromZero);
                    });
                   val.lItens[val.lItens.Count - 1].Vl_frete += Tot_frete - val.lItens.Sum(p => p.Vl_frete);
            }
        }

        public static TList_PreVenda_DT_Vencto Calcula_Parcelas(TRegistro_PreVenda val, bool St_calcular)
        {
            TList_PreVenda_DT_Vencto retorno = new TList_PreVenda_DT_Vencto();
            if (((val.Vl_prevenda - val.Vl_devcred) > 0) && (!string.IsNullOrEmpty(val.Cd_condPgto)) && (val.QTD_Parcelas > 0) && (St_calcular))
            {
                TList_Parcelas Lista_Parcela = TLanCalcParcelas.CalcularParcelas(val.Vl_prevenda - val.Vl_devcred, 
                                                                                 val.Vl_prevenda - val.Vl_devcred, 
                                                                                 val.Dt_emissao.Value, 
                                                                                 val.QTD_Parcelas,
                                                                                 val.Parcelas_Dias_Desdobro);
                int cont = 1;
                Lista_Parcela.ForEach(p =>
                {
                    retorno.Add(
                        new CamadaDados.Faturamento.PDV.TRegistro_PreVenda_DT_Vencto()
                        {
                            DiasVencto = p.Dt_vencimento.Value.Subtract(val.Dt_prevenda.Value).Days,
                            Vl_parcela = p.Vl_parcela,
                            id_parcela = cont++
                        });
                });
            }
            return retorno;
        }

        public static TList_PreVenda_DT_Vencto ReCalcula_VlParcela(TRegistro_PreVenda val, bool St_calcular)
        {
            //Recalcular vl.parcela quando for faturar prevenda com duplicata
            TList_PreVenda_DT_Vencto retorno = new TList_PreVenda_DT_Vencto();
            if (((val.Vl_prevenda - val.Vl_devcred) > 0) && (!string.IsNullOrEmpty(val.Cd_condPgto)) && (val.QTD_Parcelas > 0) && (St_calcular))
            {
                decimal vl_parcela = Math.Round((val.Vl_prevenda - val.Vl_devcred) / val.QTD_Parcelas, 2);
                int cont = 1;
                val.DT_Vencto.ForEach(p =>
                {
                    retorno.Add(new CamadaDados.Faturamento.PDV.TRegistro_PreVenda_DT_Vencto()
                    {
                        DiasVencto = p.DiasVencto,
                        Vl_parcela = vl_parcela,
                        id_parcela = cont++
                    });
                });
                if (retorno.Count > 0)
                    retorno[retorno.Count - 1].Vl_parcela += val.Vl_prevenda - val.Vl_devcred - retorno.Sum(p => p.Vl_parcela);
            }
            return retorno;
        }

        public static void RecalculaParc(TList_PreVenda_DT_Vencto lParc,
                                         TRegistro_PreVenda val,
                                         int index)
        {
            if (lParc != null)
                if (lParc.Sum(p => p.Vl_parcela) != (val.Vl_prevenda - val.Vl_devcred))
                {
                    decimal vl_parc = val.Vl_prevenda - val.Vl_devcred - lParc.Sum(p => p.Vl_parcela);
                    decimal nParcelas = (lParc.Count - (index + 1));
                    if (nParcelas.Equals(0))
                        nParcelas = 1;
                    vl_parc = (vl_parc / nParcelas);
                    for (int i = ++index; i < lParc.Count; i++)
                        lParc[i].Vl_parcela += vl_parc;
                    lParc[lParc.Count - 1].Vl_parcela += val.Vl_prevenda - val.Vl_devcred - lParc.Sum(p => p.Vl_parcela);

                    //Recalcular Parcelas se valor informado for maior que valor a faturar
                    decimal somaParcAnt = SomaParcelasAnt(lParc, index);
                    if ((somaParcAnt) > val.Vl_prevenda - val.Vl_devcred)
                    {
                        lParc[index - 1].Vl_parcela = (val.Vl_prevenda - val.Vl_devcred - (somaParcAnt - lParc[index - 1].Vl_parcela) - nParcelas);
                        for (int i = index; i < lParc.Count; i++)
                            lParc[i].Vl_parcela = 1;
                    }
                }
        }

        public static void RecalcDiaVencto(TList_PreVenda_DT_Vencto val, decimal Qtd_desdobro, int index)
        {
            for (int i = (index + 1); i < val.Count; i++)
                val[i].DiasVencto = val[i - 1].DiasVencto + Qtd_desdobro;
        }

        private static decimal SomaParcelasAnt(TList_PreVenda_DT_Vencto lParc, decimal index)
        {
            // Soma Parcelas Anteriores
            decimal somaParcelaAnt = 0;
            for (int i = 0; i < index; i++)
                somaParcelaAnt += Convert.ToDecimal(string.Format("{0:F2}", lParc[i].Vl_parcela));

            return somaParcelaAnt;
        }
    }

    public class TCN_ItensPreVenda
    {
        public static TList_ItensPreVenda Buscar(string Cd_empresa,
                                                 string Id_prevenda,
                                                 string Id_itemprevenda,
                                                 string Cd_produto,
                                                 bool ST_SaldoFat,
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
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_prevenda;
            }
            if (!string.IsNullOrEmpty(Id_itemprevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_itemprevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemprevenda;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (ST_SaldoFat)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "not exists(select 1 from tb_pdv_prevenda_x_vendarapida x " +
                                                      "             where x.CD_Empresa = a.CD_Empresa " +
                                                      "             and x.ID_PreVenda = a.id_prevenda " +
                                                      "             and x.ID_ItemPreVenda = a.ID_ItemPreVenda) and " +
                                                      "not exists(select 1 from tb_pdv_prevenda_x_condicional x " +
                                                      "             where x.CD_Empresa = a.CD_Empresa " +
                                                      "             and x.ID_PreVenda = a.id_prevenda " +
                                                      "             and x.ID_ItemPreVenda = a.ID_ItemPreVenda)";
            }
            return new TCD_ItensPreVenda(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensPreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensPreVenda qtb_itens = new TCD_ItensPreVenda();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                val.Id_itemprevendastr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_ITEMPREVENDA");
                //Gravar Item Pre Venda X Peca OS
                val.lPecasOS.ForEach(p =>
                    CamadaNegocio.Servicos.TCN_Pecas_X_PreVenda.Gravar(
                    new CamadaDados.Servicos.TRegistro_Pecas_X_PreVenda()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_prevenda = val.Id_prevenda,
                        Id_itemprevenda = val.Id_itemprevenda,
                        Id_os = p.Id_os,
                        Id_peca = p.Id_peca
                    }, qtb_itens.Banco_Dados));
                //Gravar Item Locação X Pre Venda
                if (val.rItemLocacao != null)
                    CamadaNegocio.Faturamento.Locacao.TCN_ItensLocacao_X_PreVenda.Gravar(
                        new CamadaDados.Faturamento.Locacao.TRegistro_ItensLocacao_X_PreVenda()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_locacao = val.rItemLocacao.Id_locacao,
                            Id_item = val.rItemLocacao.Id_item,
                            Id_prevenda = val.Id_prevenda,
                            Id_itemprevenda = val.Id_itemprevenda
                        }, qtb_itens.Banco_Dados);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemprevendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
        
        public static string Excluir(TRegistro_ItensPreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensPreVenda qtb_itens = new TCD_ItensPreVenda();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                if (new TCD_ItensPreVenda(qtb_itens.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "(exists(select 1 from tb_fat_locacao_x_prevenda x " +
                                        "           where x.cd_empresa = '" + val.Cd_empresa.Trim()+"'"+
                                        "           and x.id_prevenda =  " + val.Id_prevendastr+
                                        "           and x.id_itemprevenda = " + val.Id_itemprevendastr + ") or " +
                                        "exists(select 1 from tb_fat_itenslocacao_x_prevenda x " +
                                        "           where x.cd_empresa =  '" + val.Cd_empresa.Trim()+"'"+
                                        "           and x.id_prevenda = " + val.Id_prevendastr+
                                        "           and x.id_itemprevenda = " + val.Id_itemprevendastr + "))"
                        }
                    }, "1") != null)
                    throw new Exception("Item Pre Venda teve origem Locação.\r\n" +
                                        "Para excluir o item, necessario estornar processamento locação.");
                //Excluir resgate de pontos
                new CamadaDados.Faturamento.Fidelizacao.TCD_ResgatePontos(qtb_itens.Banco_Dados).Select(
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
                            vNM_Campo = "a.id_prevenda",
                            vOperador = "=",
                            vVL_Busca = val.Id_prevendastr
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_itemprevenda",
                            vOperador = "=",
                            vVL_Busca = val.Id_itemprevendastr
                        }
                    }, 0, string.Empty).ForEach(p => CamadaNegocio.Faturamento.Fidelizacao.TCN_ResgatePontos.Excluir(p, qtb_itens.Banco_Dados));
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemprevendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }

    public class TCN_PreVenda_X_VendaRapida
    {
        public static TList_PreVenda_X_VendaRapida Buscar(string Cd_empresa,
                                                          string Id_prevenda,
                                                          string Id_itemprevenda,
                                                          string Id_cupom,
                                                          string Id_lancto,
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
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_prevenda;
            }
            if (!string.IsNullOrEmpty(Id_itemprevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_itemprevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemprevenda;
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lancto;
            }
            return new TCD_PreVenda_X_VendaRapida(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PreVenda_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda_X_VendaRapida qtb_pre = new TCD_PreVenda_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pre.CriarBanco_Dados(true);
                else
                    qtb_pre.Banco_Dados = banco;
                string retorno = qtb_pre.Gravar(val);
                if (st_transacao)
                    qtb_pre.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pre.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pre.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PreVenda_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda_X_VendaRapida qtb_pre = new TCD_PreVenda_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pre.CriarBanco_Dados(true);
                else
                    qtb_pre.Banco_Dados = banco;
                qtb_pre.Excluir(val);
                if (st_transacao)
                    qtb_pre.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_pre.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pre.deletarBanco_Dados();
            }
        }
    }

    public class TCN_PreVenda_X_Condicional
    {
        public static TList_PreVenda_X_Condicional Buscar(string Cd_empresa,
                                                          string Id_prevenda,
                                                          string Id_itemprevenda,
                                                          string Id_condicional,
                                                          string Id_item,
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
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_prevenda;
            }
            if (!string.IsNullOrEmpty(Id_itemprevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_itemprevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemprevenda;
            }
            if (!string.IsNullOrEmpty(Id_condicional))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_condicional";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_condicional;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            return new TCD_PreVenda_X_Condicional(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PreVenda_X_Condicional val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda_X_Condicional qtb_pre = new TCD_PreVenda_X_Condicional();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pre.CriarBanco_Dados(true);
                else
                    qtb_pre.Banco_Dados = banco;
                string retorno = qtb_pre.Gravar(val);
                if (st_transacao)
                    qtb_pre.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pre.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pre.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PreVenda_X_Condicional val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda_X_Condicional qtb_pre = new TCD_PreVenda_X_Condicional();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pre.CriarBanco_Dados(true);
                else
                    qtb_pre.Banco_Dados = banco;
                qtb_pre.Excluir(val);
                if (st_transacao)
                    qtb_pre.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pre.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pre.deletarBanco_Dados();
            }
        }
    }

    public class TCN_PreVenda_DT_Vencto
    {
        public static TList_PreVenda_DT_Vencto Buscar(string Id_prevenda,
                                                      string Cd_empresa,  
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_prevenda;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_PreVenda_DT_Vencto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PreVenda_DT_Vencto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda_DT_Vencto qtb_pre = new TCD_PreVenda_DT_Vencto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pre.CriarBanco_Dados(true);
                else
                    qtb_pre.Banco_Dados = banco;
                string retorno = qtb_pre.Gravar(val);
                if (st_transacao)
                    qtb_pre.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pre.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar financeiro PreVenda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pre.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PreVenda_DT_Vencto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda_DT_Vencto qtb_pre = new TCD_PreVenda_DT_Vencto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pre.CriarBanco_Dados(true);
                else
                    qtb_pre.Banco_Dados = banco;
                qtb_pre.Excluir(val);
                if (st_transacao)
                    qtb_pre.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pre.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir financeiro PreVenda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pre.deletarBanco_Dados();
            }
        }
    }
}
