using CamadaDados.Restaurante;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante;
using CamadaNegocio.Restaurante.Cadastro;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Restaurante.Impressao
{
    public class IMP_Cartao
    {
        private static TRegistro_Cfg _Cfg { get; set; } = null;
        private static TRegistro_PontoVenda _PontoVenda { get; set; } = null;

        private static bool carregarCfgRes()
        {
            if (_Cfg == null)
            {
                try
                {
                    _Cfg = TCN_CFG.Buscar(string.Empty, null)[0];
                    return true;
                }
                catch
                {
                    MessageBox.Show("Erro ao obter configuração restaurante, não será possível finalizar operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private static bool carregarPontoVenda(string id_pdv = null)
        {
            if (_PontoVenda == null)
            {
                try
                {
                    _PontoVenda = TCN_PontoVenda.Buscar(id_pdv, string.Empty, Utils.Parametros.pubTerminal, _Cfg.cd_empresa, null)[0];
                }
                catch
                {
                    MessageBox.Show("Erro ao obter ponto de venda, não será possível finalizar operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private static void formatStringBuilder(ref StringBuilder atribuido, string formato, TList_PreVenda_Item itens = null, TList_Cartao cartaos = null)
        {
            int count = 0;
            switch (formato)
            {
                case "clientePorCartao":
                    {
                        atribuido.AppendLine("CLIENTE/CARTÃO: ");
                        foreach (TRegistro_Cartao c in cartaos)
                        {
                            if ((c.Nm_Clifor + "-" + c.nr_card).Length > 24) atribuido.AppendLine("");
                            atribuido.Append("  " + c.Nm_Clifor + "-" + c.nr_card);
                            count++;
                            if (count % 3 == 0) atribuido.AppendLine("");
                        }
                        atribuido.AppendLine("                                                ");
                        break;
                    }
                case "cartaoPorItens":
                    {
                        atribuido.AppendLine("Produto".FormatStringDireita(26, ' ') + "Qtd.".FormatStringEsquerda(7, ' ') + "Vl.Unit".FormatStringEsquerda(7, ' ') + "Total".FormatStringEsquerda(8, ' '));
                        atribuido.AppendLine("------------------------------------------------");
                        foreach (TRegistro_Cartao c in cartaos)
                        {
                            atribuido.AppendLine("CARTÃO: " + c.nr_card);
                            foreach (TRegistro_PreVenda_Item i in itens)
                            {
                                if (c.id_cartao.Equals(i.id_cartao))
                                {
                                    //Produto //Quantidade //Vl unitario // Total
                                    atribuido.AppendLine("  " + i.ds_produto.Trim().FormatStringDireita(24, ' ') + (i.quantidade).FormatStringEsquerda(7, ' ') + ((i.vl_unitario - i.vl_desconto).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true))).FormatStringEsquerda(7, ' ') + i.vl_liquido.FormatStringEsquerda(8, ' '));
                                    //Sabores do item
                                    if (i.lSabores.Count > 0)
                                    {
                                        atribuido.AppendLine("      Sabores:");
                                        foreach (TRegistro_SaboresItens s in i.lSabores)
                                        {
                                            atribuido.AppendLine("      " + s.DS_Sabor);
                                        }
                                    }
                                    //Observação
                                    if (!string.IsNullOrEmpty(i.obsItem.Trim()))
                                        atribuido.AppendLine(("   Obs:" + i.obsItem).FormatStringDireita(40, ' '));
                                }
                            }
                        }
                        atribuido.AppendLine("------------------------------------------------");
                        break;
                    }
                case "locaisPorMesas":
                    {
                        atribuido.AppendLine("LOCAL/MESA/CARTÃO: ");
                        foreach (TRegistro_Cartao c in cartaos)
                        {
                            if (!string.IsNullOrEmpty(c.ds_local) && !string.IsNullOrEmpty(c.nr_mesa))
                            {
                                atribuido.Append("  " + c.ds_local + " - " + c.nr_mesa + " - " + c.nr_card);
                                atribuido.AppendLine("");
                            }
                        }
                        atribuido.AppendLine("------------------------------------------------");
                        break;
                    }
            }
        }

        private static void formatStreamWriter(ref StreamWriter atribuido, string formato, TList_PreVenda_Item itens = null, TList_Cartao cartaos = null)
        {
            int count = 0;
            switch (formato)
            {
                case "clientePorCartao":
                    {
                        atribuido.WriteLine("CLIENTE/CARTÃO: ");
                        foreach (TRegistro_Cartao c in cartaos)
                        {
                            if ((c.Nm_Clifor + "-" + c.nr_card).Length > 24) atribuido.WriteLine("");
                            atribuido.Write("  " + c.Nm_Clifor + "-" + c.nr_card);
                            count++;
                            if (count % 3 == 0) atribuido.WriteLine("");
                        }
                        atribuido.WriteLine("                                                ");
                        break;
                    }
                case "cartaoPorItens":
                    {
                        atribuido.WriteLine("Produto".FormatStringDireita(26, ' ') + "Qtd.".FormatStringEsquerda(7, ' ') + "Vl.Unit".FormatStringEsquerda(7, ' ') + "Total".FormatStringEsquerda(8, ' '));
                        atribuido.WriteLine("------------------------------------------------");
                        foreach (TRegistro_Cartao c in cartaos)
                        {
                            atribuido.WriteLine("CARTÃO: " + c.nr_card);
                            foreach (TRegistro_PreVenda_Item i in itens)
                            {
                                if (c.id_cartao.Equals(i.id_cartao))
                                {
                                    //Produto //Quantidade //Vl unitario // Total
                                    atribuido.WriteLine("  " + i.ds_produto.Trim().FormatStringDireita(24, ' ') + (i.quantidade).FormatStringEsquerda(7, ' ') + ((i.vl_unitario - i.vl_desconto).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true))).FormatStringEsquerda(7, ' ') + i.vl_liquido.FormatStringEsquerda(8, ' '));
                                    //Sabores do item
                                    if (i.lSabores.Count > 0)
                                    {
                                        atribuido.WriteLine("      Sabores:");
                                        foreach (TRegistro_SaboresItens s in i.lSabores)
                                        {
                                            atribuido.WriteLine("      " + s.DS_Sabor);
                                        }
                                    }
                                    //Observação
                                    if (!string.IsNullOrEmpty(i.obsItem.Trim()))
                                        atribuido.WriteLine(("   Obs:" + i.obsItem).FormatStringDireita(40, ' '));
                                }
                            }
                        }
                        atribuido.WriteLine("------------------------------------------------");
                        break;
                    }
                case "locaisPorMesas":
                    {
                        atribuido.WriteLine("LOCAL/MESA/CARTÃO: ");
                        foreach (TRegistro_Cartao c in cartaos)
                        {
                            if (!string.IsNullOrEmpty(c.ds_local) && !string.IsNullOrEmpty(c.nr_mesa))
                            {
                                atribuido.Write("  " + c.ds_local + " - " + c.nr_mesa + " - " + c.nr_card);
                                atribuido.WriteLine("");
                            }
                        }
                        atribuido.WriteLine("------------------------------------------------");
                        break;
                    }
            }
        }

        public static void Impressao_FASTFOOD(TRegistro_PreVenda prevenda, TRegistro_Cartao cartao, string id_pdv = null)
        {
            TList_CFG cfg = TCN_CFG.Buscar(string.Empty, null);

            TList_CFG lcfg = new TList_CFG();
            lcfg = TCN_CFG.Buscar(string.Empty, null);
            TList_PontoVenda pdv = new TList_PontoVenda();
            pdv = TCN_PontoVenda.Buscar(string.Empty, string.Empty, Utils.Parametros.pubTerminal, lcfg[0].cd_empresa, null);
            //busca tipo de impressora 0 é bematech
            object tp_impressora = null;
            tp_impressora = new TCD_LocalImp().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_pontovenda x where x.id_pdv = '" + id_pdv + "' and x.id_localimp = a.id_localimp)"
                        }
                    }, "tp_impressora");

            if (tp_impressora == null ? false : tp_impressora.Equals("0"))
            {
                #region BEMATECH
                StringBuilder imp = new StringBuilder();
                if (!string.IsNullOrEmpty(prevenda.NR_SenhaDelivery.ToString()))//se for fazio é delivery
                    imp.AppendLine("       E X T R A T O  DE  C O N S U M O         ");
                imp.AppendLine("");
                if (cfg[0].Tp_cartao.Equals("2"))
                    imp.AppendLine("SENHA: ".FormatStringEsquerda(9, ' ') + prevenda.NR_SenhaDelivery.FormatStringEsquerda(12, ' '));
                else if (cfg[0].Tp_cartao.Equals("1") || cfg[0].bool_mesacartao)
                {
                    imp.AppendLine("Local: " + cartao.ds_local.Trim().FormatStringDireita(8, ' ') + "Mesa: " + cartao.nr_mesa.Trim());
                    if (cfg[0].bool_mesacartao)
                        imp.AppendLine("Cartão: " + prevenda.nr_cartao.Trim());
                }
                else if (cfg[0].Tp_cartao.Equals("0"))
                    imp.AppendLine("Cartao: " + cartao.nr_cartao.Trim());
                imp.AppendLine("CAIXA: " + Utils.Parametros.pubLogin);
                imp.AppendLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm"));
                imp.AppendLine("CLIENTE: " + cartao.Nm_Clifor);

                imp.AppendLine("------------------------------------------------");
                imp.AppendLine("Produto".FormatStringDireita(26, ' ')
                            + "Qtd.".FormatStringEsquerda(7, ' ')
                            + "Vl.Unit".FormatStringEsquerda(7, ' ')
                            + "Total".FormatStringEsquerda(8, ' '));
                imp.AppendLine("------------------------------------------------");
                prevenda.lItens.ForEach(o =>
                {
                    if (string.IsNullOrEmpty(o.id_itemPaiAdic.ToString()))
                    {
                        imp.AppendLine(o.ds_produto.FormatStringDireita(26, ' ')
                            + (o.quantidade).FormatStringEsquerda(7, ' ')
                            + ((o.vl_unitario - o.vl_desconto).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true))).FormatStringEsquerda(7, ' ')
                            + o.vl_liquido.FormatStringEsquerda(8, ' '));
                        if (!string.IsNullOrEmpty(o.obsItem.Trim()))
                            imp.AppendLine(("   Obs:" + o.obsItem).FormatStringDireita(40, ' '));
                        TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                        adicionais = new TCD_PreVenda_Item().Select(
                            new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_itempaiadic",
                                vOperador = "=",
                                vVL_Busca = o.id_item.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_prevenda",
                                vOperador = "=",
                                vVL_Busca = o.id_prevenda.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_registro",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            }
                            }, 0, string.Empty);
                        adicionais.ForEach(ad =>
                        {
                            ad.ds_produto = "    " + ad.ds_produto;
                            imp.AppendLine(ad.ds_produto.FormatStringDireita(26, ' ')
                               + (ad.quantidade).FormatStringEsquerda(7, ' ')
                               + (Convert.ToDecimal(ad.vl_unitario - ad.vl_desconto)).ToString().FormatStringEsquerda(7, ' ')
                               + ad.vl_liquido.FormatStringEsquerda(8, ' '));
                        });
                        TList_SaboresItens itens = new TList_SaboresItens();
                        if (o.lSabores.Count > 0)
                        {
                            o.lSabores.ForEach(u =>
                            {
                                itens.Add(u);
                            });
                        }
                        else
                        {
                            itens = TCN_SaboresItens.Buscar(o.Cd_empresa, o.id_prevenda.ToString(), o.id_item.ToString(), string.Empty, null);
                        }

                        if (itens.Count > 0)
                        {
                            imp.AppendLine("    Sabores "); //+ o.ds_produto);
                            itens.ForEach(i =>
                            {
                                imp.AppendLine("      " + i.DS_Sabor);
                            });
                        }
                    }
                });

                imp.AppendLine("------------------------------------------------");
                imp.AppendLine("Total" + prevenda.lItens.Sum(p => p.vl_liquido).FormatStringEsquerda(37, ' '));
                imp.AppendLine("------------------------------------------------");
                TList_PreVenda_Item lResumo = new TList_PreVenda_Item();
                prevenda.lItens.Where(p => !string.IsNullOrWhiteSpace(p.Ch_torneira))
                    .GroupBy(p => p.ds_produto,
                    (aux, item) =>
                    new TRegistro_PreVenda_Item
                    {
                        ds_produto = aux,
                        quantidade = item.Sum(x => x.quantidade)
                    }).ToList().ForEach(p => lResumo.Add(p));
                if (lResumo.Count > 0)
                {
                    imp.AppendLine("-------------RESUMO TORNEIRA--------------");
                    imp.AppendLine("Produto                         Quantidade");
                    lResumo.ForEach(p =>
                        imp.AppendLine(p.ds_produto.FormatStringDireita(32, ' ') + (p.quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "LT").FormatStringEsquerda(10, ' ')));
                    imp.AppendLine("");
                }
                imp.AppendLine("Obs: Posicao ate o momento - SEM VALOR FISCAL");
                imp.AppendLine("         AGRADECEMOS A PREFERENCIA  ");
                imp.AppendLine("");
                try
                {
                    if (PDV.TGerenciarImpNaoFiscal.IniciarPorta(pdv[0].porta_imp).Equals(1))
                        switch (PDV.TGerenciarImpNaoFiscal.LerStatus())
                        {
                            case 0:
                                {
                                    MessageBox.Show("Erro de comunicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            case 5:
                                {
                                    PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                    PDV.TGerenciarImpNaoFiscal.Guilhotina();
                                    MessageBox.Show("Impressão realizada com sucesso.\r\n" +
                                                    "Obs.: Impressora com pouco papel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            case 9:
                                {
                                    MessageBox.Show("Erro imprimir: Tampa da impressora esta aberta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            case 24:
                                {
                                    PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                    PDV.TGerenciarImpNaoFiscal.Guilhotina();
                                    break;
                                }
                            case 32:
                                {
                                    MessageBox.Show("Erro imprimir: Impressora sem papel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                        }
                    else
                    {
                        MessageBox.Show("Erro imprimir: Não foi possível conexão com impressora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("Erro: " + ex.Message.Trim()); }
                finally
                { PDV.TGerenciarImpNaoFiscal.FecharPorta(); }
                #endregion
            }
            if (tp_impressora == null ? true : !tp_impressora.Equals("0"))
            {
                #region NETUSE
                // imprimir pedido
                FileInfo fi = null;
                StreamWriter wi = null;
                fi = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "impressao cliente " + ".txt");
                wi = fi.CreateText();
                try
                {
                    if (!string.IsNullOrEmpty(prevenda.NR_SenhaDelivery.ToString()))//se for fazio é delivery
                        wi.WriteLine("       E X T R A T O  DE  C O N S U M O         ");
                    wi.WriteLine("");
                    if (cfg[0].Tp_cartao.Equals("2"))
                        wi.WriteLine("SENHA: ".FormatStringEsquerda(9, ' ') + prevenda.NR_SenhaDelivery.FormatStringEsquerda(12, ' '));
                    else if (cfg[0].Tp_cartao.Equals("1") || cfg[0].bool_mesacartao)
                    {
                        wi.WriteLine("Local: " + cartao.ds_local.FormatStringDireita(8, ' ') + "Mesa: " + cartao.nr_mesa.Trim());
                        if (cfg[0].bool_mesacartao)
                            wi.WriteLine("Cartão: " + prevenda.nr_cartao);
                    }
                    else if (cfg[0].Tp_cartao.Equals("0"))
                        wi.WriteLine("Cartao: ".FormatStringEsquerda(9, ' ') + cartao.nr_cartao.FormatStringEsquerda(12, ' '));
                    wi.WriteLine("Caixa: " + Utils.Parametros.pubLogin);
                    wi.WriteLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm"));
                    wi.WriteLine("CLIENTE: " + cartao.Nm_Clifor);

                    wi.WriteLine("------------------------------------------");
                    wi.WriteLine("Produto".FormatStringDireita(19, ' ')
                                + "Qtd.".FormatStringEsquerda(6, ' ')
                                + "Vl.Unit".FormatStringEsquerda(7, ' ')
                                + "Total".FormatStringEsquerda(6, ' '));
                    wi.WriteLine("------------------------------------------");
                    prevenda.lItens.ForEach(o =>
                    {
                        if (string.IsNullOrEmpty(o.id_itemPaiAdic.ToString()))
                        {
                            wi.WriteLine(o.ds_produto.FormatStringDireita(19, ' ')
                                + (o.quantidade).FormatStringEsquerda(6, ' ')
                                + ((o.vl_unitario - o.vl_desconto).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true))).FormatStringEsquerda(7, ' ')
                                + o.vl_liquido.FormatStringEsquerda(6, ' '));
                            if (!string.IsNullOrEmpty(o.obsItem.Trim()))
                                wi.WriteLine(("   Obs:" + o.obsItem).FormatStringDireita(40, ' '));
                            if (o.id_item.HasValue)
                            {
                                TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                                adicionais = new TCD_PreVenda_Item().Select(
                                    new TpBusca[]
                                    {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_itempaiadic",
                                    vOperador = "=",
                                    vVL_Busca = o.id_item.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_prevenda",
                                    vOperador = "=",
                                    vVL_Busca = o.id_prevenda.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.st_registro",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                }
                                    }, 0, string.Empty);
                                adicionais.ForEach(ad =>
                                {
                                    ad.ds_produto = "    " + ad.ds_produto;
                                    wi.WriteLine(ad.ds_produto.FormatStringDireita(19, ' ')
                                        + (ad.quantidade).FormatStringEsquerda(6, ' ')
                                        + (Convert.ToDecimal(ad.vl_unitario - ad.vl_desconto)).ToString().FormatStringEsquerda(7, ' ')
                                        + ad.vl_liquido.FormatStringEsquerda(6, ' '));
                                });
                                TList_SaboresItens itens = new TList_SaboresItens();
                                if (o.lSabores.Count > 0)
                                {
                                    o.lSabores.ForEach(u =>
                                    {
                                        itens.Add(u);
                                    });
                                }
                                else
                                {
                                    itens = TCN_SaboresItens.Buscar(o.Cd_empresa, o.id_prevenda.ToString(), o.id_item.ToString(), string.Empty, null);
                                }

                                if (itens.Count > 0)
                                {
                                    wi.WriteLine("    Sabores "); //+ o.ds_produto);
                                    itens.ForEach(i =>
                                    {
                                        wi.WriteLine("      " + i.DS_Sabor);
                                    });
                                }
                            }
                        }
                    });

                    wi.WriteLine("------------------------------------------");
                    wi.WriteLine("Total" + prevenda.lItens.Sum(p => p.vl_liquido).FormatStringEsquerda(33, ' '));
                    wi.WriteLine("------------------------------------------");
                    TList_PreVenda_Item lResumo = new TList_PreVenda_Item();
                    prevenda.lItens.Where(p => !string.IsNullOrWhiteSpace(p.Ch_torneira))
                        .GroupBy(p => p.ds_produto,
                        (aux, item) =>
                        new TRegistro_PreVenda_Item
                        {
                            ds_produto = aux,
                            quantidade = item.Sum(x => x.quantidade)
                        }).ToList().ForEach(p => lResumo.Add(p));
                    if (lResumo.Count > 0)
                    {
                        wi.WriteLine("-------------RESUMO TORNEIRA--------------");
                        wi.WriteLine("Produto                         Quantidade");
                        lResumo.ForEach(p =>
                            wi.WriteLine(p.ds_produto.FormatStringDireita(32, ' ') + (p.quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "LT").FormatStringEsquerda(10, ' ')));
                        wi.WriteLine("");
                    }
                    wi.WriteLine("obs:Posicao ate o momento-SEM VALOR FISCAL");
                    wi.WriteLine("         AGRADECEMOS A PREFERENCIA  ");

                    wi.WriteLine("");
                    wi.WriteLine("");
                    wi.WriteLine("");
                    wi.WriteLine("");
                    wi.WriteLine("");
                    wi.WriteLine("");
                    wi.WriteLine("");
                    wi.WriteLine("");
                    wi.WriteLine("");

                    if (pdv[0].tp_imp.Equals("1"))
                    {
                        wi.Write(Convert.ToChar(12));
                        wi.Write(Convert.ToChar(27));
                        wi.Write(Convert.ToChar(109));
                    }
                    else if (pdv[0].tp_imp.Equals("2"))
                    {
                        wi.Write(Convert.ToChar(27));
                        wi.Write(Convert.ToChar(109));
                    }
                    wi.Flush();
                    fi.CopyTo(pdv[0].porta_imp, true);
                }
                catch (Exception ex)
                { MessageBox.Show("Erro impressão pedido a cozinha: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    wi.Dispose();
                    fi = null;
                }
                #endregion
            }
        }

        /// <summary>
        /// Utilizado ao excluir um delivery, emitido nota de cancelamento
        /// para os respectivos pontos de impressão
        /// </summary>
        /// <param name="registro_PreVenda">Registro delivery</param>
        internal static void CancelamentoDelivery(TRegistro_PreVenda registro_PreVenda)
        {
            if (!carregarCfgRes()) return;
            else if (registro_PreVenda == null || registro_PreVenda.lItens == null || registro_PreVenda.lItens.Count.Equals(0))
            {
                MessageBox.Show("Erro na leitura dos parâmetros para emitir nota de cancelamento do pedido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Validar que todos registros não estejam impressos
            registro_PreVenda.lItens.ForEach(i => i.St_impressobool = false);

            registro_PreVenda.lItens.ForEach(i =>
            {
                //Validar se item já não foi agrupado e impresso
                if (i.St_impressobool.Equals(true))
                    return;

                //Buscar tipo da impressora pela porta do item
                object tp_impressora = null;
                tp_impressora = new TCD_LocalImp().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_localimp",
                                vOperador = "=",
                                vVL_Busca = i.id_portaimp.ToString()
                            }
                        }, "tp_impressora");

                if (tp_impressora != null ? tp_impressora.Equals("0") : false)
                {
                    #region Bematech
                    StringBuilder imp = new StringBuilder();
                    imp.AppendLine("------------------------------------------");
                    imp.AppendLine("* * * * * C A N C E L A M E N T O * * * * ");
                    imp.AppendLine("------------------------------------------");
                    imp.AppendLine("CLIENTE: " + registro_PreVenda.nm_clifor);
                    imp.AppendLine("FONE: " + registro_PreVenda.numero);

                    //Buscar todos itens com a mesma porta, para imprimir junto
                    registro_PreVenda.lItens.FindAll(p => p.id_portaimp.Equals(i.id_portaimp)).ForEach(x =>
                    {
                        x.St_impressobool = true;
                        imp.AppendLine(x.quantidade.FormatStringDireita(6, ' ') + (x.ds_produto).FormatStringDireita(25, ' '));

                        //Observação do Item
                        if (!string.IsNullOrEmpty(x.obsItem))
                        {
                            string obs = "Obs: " + x.obsItem.Trim();
                            while (true)
                            {
                                if (obs.Length <= 42)
                                {
                                    imp.AppendLine(obs);
                                    break;
                                }
                                else
                                {
                                    imp.AppendLine(obs.Substring(0, 42));
                                    obs = obs.Remove(0, 42);
                                }
                            }
                        }

                        //TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                        //adicionais = new TCD_PreVenda_Item().Select(
                        //    new TpBusca[]
                        //    {
                        //        new TpBusca()
                        //        {
                        //            vNM_Campo = "a.id_itempaiadic",
                        //            vOperador = "=",
                        //            vVL_Busca = x.id_item.ToString()
                        //        },
                        //        new TpBusca()
                        //        {
                        //            vNM_Campo = "a.id_prevenda",
                        //            vOperador = "=",
                        //            vVL_Busca = x.id_prevenda.ToString()
                        //        }
                        //    }, 0, string.Empty);
                        //adicionais.ForEach(ad =>
                        //{
                        //    imp.AppendLine("    " + ad.ds_produto);
                        //});

                        TList_SaboresItens itens = new TList_SaboresItens();
                        if (x.lSabores.Count > 0)
                        {
                            x.lSabores.ForEach(u =>
                            {
                                itens.Add(u);
                            });
                        }
                        else
                        {
                            itens = TCN_SaboresItens.Buscar(x.Cd_empresa, x.id_prevenda.ToString(), x.id_item.ToString(), string.Empty, null);
                        }

                        if (itens.Count > 0)
                        {
                            imp.AppendLine("    Sabores ");
                            itens.ForEach(o =>
                            {
                                imp.AppendLine("      " + o.DS_Sabor);
                            });
                        }
                    });

                    imp.AppendLine("------------------------------------------");
                    imp.AppendLine("Cancelamento de pedido solicitado por:");
                    imp.AppendLine("USUÁRIO: " + Utils.Parametros.pubLogin);
                    imp.AppendLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm"));
                    imp.AppendLine();

                    try
                    {
                        if (PDV.TGerenciarImpNaoFiscal.IniciarPorta(i.porta_imp.Trim()).Equals(1))
                            switch (PDV.TGerenciarImpNaoFiscal.LerStatus())
                            {
                                case 0:
                                    {
                                        MessageBox.Show("Erro de comunicação com a impressora pelo IP. Não foi possível emitir a nota de cancelamento do pedido na cozinha. " +
                                            "Porta: " + i.porta_imp.Trim(),
                                            "Erro",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                                        break;
                                    }
                                case 5:
                                    {
                                        PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                        PDV.TGerenciarImpNaoFiscal.Guilhotina();

                                        MessageBox.Show("Impressão de cancelamento do pedido realizada com sucesso.\r\n" +
                                                        "Obs.: Impressora com pouco papel pelo IP: " + i.porta_imp.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    }
                                case 9:
                                    {
                                        MessageBox.Show("Erro imprimir: Tampa da impressora esta aberta pelo IP: " + i.porta_imp.Trim() + ". " +
                                            "Não será possível emitir a nota de cancelamento do pedido na cozinha.",
                                            "Erro",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                                        break;
                                    }
                                case 24:
                                    {
                                        PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                        PDV.TGerenciarImpNaoFiscal.Guilhotina();
                                        break;
                                    }
                                case 32:
                                    {
                                        MessageBox.Show("Erro imprimir: Impressora sem papel pelo IP: " + i.porta_imp.Trim() + ". " +
                                            "Não será possível emitir a nota de cancelamento do pedido na cozinha.",
                                            "Erro",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                                        break;
                                    }
                            }
                        else
                        {
                            MessageBox.Show("Não foi possível estabelecer conexão com a impressora pelo IP: " + i.porta_imp.Trim() + ". " +
                                "Não será possível emitir a nota de cancelamento do pedido na cozinha.",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    { PDV.TGerenciarImpNaoFiscal.FecharPorta(); }
                    #endregion
                }
                else
                {
                    #region NetUse
                    FileInfo fi = null;
                    StreamWriter wi = null;
                    fi = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "cancelamentoPedido" + i.porta_imp.Trim() + "delivery.txt");
                    wi = fi.CreateText();
                    try
                    {
                        wi.Write(Convert.ToChar(27));
                        wi.Write(Convert.ToChar(15));
                        wi.Write(Convert.ToChar(15));

                        wi.WriteLine("------------------------------------------");
                        wi.WriteLine("* * * * * C A N C E L A M E N T O * * * * ");
                        wi.WriteLine("------------------------------------------");
                        wi.WriteLine("CLIENTE: " + registro_PreVenda.nm_clifor);
                        wi.WriteLine("FONE: " + registro_PreVenda.numero);

                        //Buscar todos itens com a mesma porta, para imprimir junto
                        registro_PreVenda.lItens.FindAll(p => p.id_portaimp.Equals(i.id_portaimp)).ForEach(x =>
                        {
                            x.St_impressobool = true;
                            wi.WriteLine(x.quantidade.FormatStringDireita(6, ' ') + (x.ds_produto).FormatStringDireita(25, ' '));

                            //Observação do Item
                            if (!string.IsNullOrEmpty(x.obsItem))
                            {
                                string obs = "Obs: " + x.obsItem.Trim();
                                while (true)
                                {
                                    if (obs.Length <= 42)
                                    {
                                        wi.WriteLine(obs);
                                        break;
                                    }
                                    else
                                    {
                                        wi.WriteLine(obs.Substring(0, 42));
                                        obs = obs.Remove(0, 42);
                                    }
                                }
                            }

                            //TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                            //adicionais = new TCD_PreVenda_Item().Select(
                            //    new TpBusca[]
                            //    {
                            //    new TpBusca()
                            //    {
                            //        vNM_Campo = "a.id_itempaiadic",
                            //        vOperador = "=",
                            //        vVL_Busca = x.id_item.ToString()
                            //    },
                            //    new TpBusca()
                            //    {
                            //        vNM_Campo = "a.id_prevenda",
                            //        vOperador = "=",
                            //        vVL_Busca = x.id_prevenda.ToString()
                            //    }
                            //    }, 0, string.Empty);
                            //adicionais.ForEach(ad =>
                            //{
                            //    wi.WriteLine("    " + ad.ds_produto);
                            //});

                            TList_SaboresItens itens = new TList_SaboresItens();
                            if (x.lSabores.Count > 0)
                            {
                                x.lSabores.ForEach(u =>
                                {
                                    itens.Add(u);
                                });
                            }
                            else
                            {
                                itens = TCN_SaboresItens.Buscar(x.Cd_empresa, x.id_prevenda.ToString(), x.id_item.ToString(), string.Empty, null);
                            }

                            if (itens.Count > 0)
                            {
                                wi.WriteLine("    Sabores ");
                                itens.ForEach(o =>
                                {
                                    wi.WriteLine("      " + o.DS_Sabor);
                                });
                            }
                        });

                        wi.WriteLine("------------------------------------------");
                        wi.WriteLine("Cancelamento de pedido solicitado por:");
                        wi.WriteLine("USUÁRIO: " + Utils.Parametros.pubLogin);
                        wi.WriteLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm"));
                        wi.WriteLine();

                        if (tp_impressora == null ? false : tp_impressora.Equals("1"))
                        {
                            wi.Write(Convert.ToChar(12));
                            wi.Write(Convert.ToChar(27));
                            wi.Write(Convert.ToChar(109));
                        }
                        else
                        {
                            wi.Write(Convert.ToChar(27));
                            wi.Write(Convert.ToChar(109));
                        }
                        wi.Flush();

                        fi.CopyTo(i.porta_imp.Trim(), true);
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro impressão cancelamento de pedido. Porta: " + i.porta_imp.Trim() + ". Descrição: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        wi.Dispose();
                        fi = null;
                    }
                    #endregion
                }
            });
        }

        public static void Impressao_PEDIDOS(TRegistro_PreVenda prevenda, TRegistro_Cartao cartao, bool reimp = false)
        {
            TList_CFG lcfg = TCN_CFG.Buscar(string.Empty, null);
            if (lcfg == null || lcfg.Count.Equals(0)) { MessageBox.Show("Erro ao obter a CFG.Restaurante. Não será possível finalizar a impressão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            TList_PreVenda lprevenda = new TList_PreVenda();
            string porta = string.Empty;
            prevenda.lItens.ForEach(p =>
            {
                if (p.id_portaimp == decimal.Zero)
                    return;
                TRegistro_PreVenda venda = new TRegistro_PreVenda();

                venda.NR_SenhaDelivery = prevenda.NR_SenhaDelivery;
                venda.id_portaimp = p.id_portaimp;
                venda.porta_imp = p.porta_imp;
                porta = venda.porta_imp;
                object portaimp = null;
                if (string.IsNullOrEmpty(p.porta_imp))
                {
                    portaimp = new TCD_LocalImp().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_localimp",
                                vOperador = "=",
                                vVL_Busca = venda.id_portaimp.ToString()
                            }
                        }, "porta_imp");
                    if (portaimp != null)
                        venda.porta_imp = portaimp.ToString();
                }
                venda.bool_clientetira = prevenda.bool_clientetira;
                //Verificar se porta já existe na lista, se estiver ignorar senão adicionar
                if (lprevenda.Count == 0 ? true : lprevenda.Exists(x => x.porta_imp != venda.porta_imp))
                    lprevenda.Add(venda);
            });

            //Adicionar Itens ao pedido
            prevenda.lItens.ForEach(p =>
                lprevenda.ForEach(o =>
                {
                    o.bool_clientetira = prevenda.bool_clientetira;
                    o.St_delivery = p.st_registro;

                    if (p.id_portaimp.Equals(o.id_portaimp))
                        if (string.IsNullOrEmpty(p.id_itemPaiAdic.ToString()))
                            o.lItens.Add(p);
                }));

            TList_Clifor clifor = new TList_Clifor();
            clifor = new TCD_Clifor().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = cartao.Cd_Clifor
                    }
                }, 1, string.Empty);

            //Gerar Impressão
            lprevenda.ForEach(p =>
            {
                object tp_impressora = null;
                tp_impressora = new TCD_LocalImp().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_localimp",
                                vOperador = "=",
                                vVL_Busca = p.id_portaimp.ToString()
                            }
                        }, "tp_impressora");
                if (tp_impressora != null ? tp_impressora.Equals("0") : false)
                {
                    #region BEMATECH
                    StringBuilder imp = new StringBuilder();

                    if (lcfg[0].Tp_cartao.Equals("0"))
                    {
                        imp.AppendLine("C A R T A O".FormatStringEsquerda(32, ' '));
                        if (cartao.Id_mesa != null)
                            imp.AppendLine(("M E S A " + cartao.nr_mesa).FormatStringEsquerda(32, ' '));
                    }
                    else
                    if (lcfg[0].Tp_cartao.Equals("1"))
                    {
                        imp.AppendLine(("Local: " + cartao.ds_local + " Mesa: " + cartao.nr_mesa).FormatStringEsquerda(32, ' '));
                    }
                    else
                    if (!string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))//se for vazio é delivery
                        imp.AppendLine("F A S T F O O D".FormatStringEsquerda(32, ' '));
                    else if (!string.IsNullOrEmpty(cartao.nr_cartao))
                    {
                        if (!string.IsNullOrEmpty(cartao.id_local.ToString()))
                            imp.AppendLine("L o c a l " + cartao.ds_local + " m e s a " + cartao.nr_mesa);
                        else
                            imp.AppendLine("C a r t a o " + cartao.nr_cartao);
                    }
                    else
                        imp.AppendLine("D E L I V E R Y".FormatStringEsquerda(32, ' '));

                    if (reimp)
                    {
                        imp.AppendLine("------------------------------------------");
                        imp.AppendLine("       REIMPRESSAO DE COMANDA");
                        imp.AppendLine("------------------------------------------");
                    }

                    imp.AppendLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm"));
                    imp.AppendLine("CLIENTE: " + cartao.Nm_Clifor);

                    if (lcfg[0].Tp_cartao.Equals("1") || lcfg[0].bool_mesacartao)
                    {
                        imp.AppendLine("Local: ".FormatStringEsquerda(7, ' ') + cartao.ds_local.FormatStringEsquerda(8, ' ') +
                            "Mesa: ".FormatStringEsquerda(7, ' ') + cartao.nr_mesa.FormatStringEsquerda(8, ' '));
                        if (lcfg[0].bool_mesacartao)
                            imp.AppendLine("Cartão: ".FormatStringEsquerda(9, ' ') + p.nr_cartao.FormatStringEsquerda(12, ' '));
                    }
                    else if (!string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))
                        imp.AppendLine("SENHA: ".FormatStringEsquerda(9, ' ') + p.NR_SenhaDelivery.FormatStringEsquerda(12, ' '));
                    else if (lcfg[0].Tp_cartao.Equals("0"))
                        imp.AppendLine("Cartao: ".FormatStringDireita(9, ' ') + cartao.nr_cartao.FormatStringEsquerda(12, ' '));
                    else if (!lcfg[0].Tp_cartao.Equals("2"))
                        imp.AppendLine("COMANDA: ".FormatStringDireita(9, ' ') + cartao.nr_cartao.FormatStringEsquerda(12, ' '));
                    else
                        imp.AppendLine("COMANDA: ".FormatStringDireita(9, ' ') + prevenda.nr_cartao.FormatStringEsquerda(12, ' '));


                    if (p.bool_clientetira)
                        imp.AppendLine(" * * * CLIENTE VEM BUSCAR * * * ");

                    if (string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))//se for fazio é delivery
                    {
                        if (lcfg[0].Bool_imp_end_cozinha)
                        {
                            imp.AppendLine(("Fone: " + clifor[0].celular).FormatStringDireita(42, ' '));
                            imp.AppendLine(("Endereco: " + clifor[0].endereco + " " + clifor[0].numero));
                            imp.AppendLine(("Bairro: " + clifor[0].bairro).FormatStringDireita(42, ' '));
                            imp.AppendLine(("Proximo: " + clifor[0].obs));
                        }
                    }


                    imp.AppendLine("------------------------------------------");
                    imp.AppendLine("Qta".FormatStringDireita(6, ' ') + "Produto".FormatStringDireita(25, ' '));
                    imp.AppendLine("------------------------------------------");
                    p.lItens.ForEach(o =>
                    {
                        imp.AppendLine(o.quantidade.FormatStringDireita(6, ' ')
                        + (o.ds_produto).FormatStringDireita(25, ' '));
                        if (o.st_registro.Trim().ToUpper().Equals("C"))
                            imp.AppendLine("      *****CANCELADO*****      ");
                        if (!string.IsNullOrEmpty(o.obsItem))
                        {
                            string obs = "Obs: " + o.obsItem.Trim();
                            while (true)
                            {
                                if (obs.Length <= 42)
                                {
                                    imp.AppendLine(obs);
                                    break;
                                }
                                else
                                {
                                    imp.AppendLine(obs.Substring(0, 42));
                                    obs = obs.Remove(0, 42);
                                }
                            }
                        }

                        TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                        adicionais = new TCD_PreVenda_Item().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_itempaiadic",
                                    vOperador = "=",
                                    vVL_Busca = o.id_item.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_prevenda",
                                    vOperador = "=",
                                    vVL_Busca = o.id_prevenda.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.st_registro",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                }
                            }, 0, string.Empty);
                        adicionais.ForEach(ad =>
                        {
                            imp.AppendLine("    " + ad.quantidade + " " + ad.ds_produto);
                        });
                        if (adicionais.Count > 0)
                            imp.AppendLine("------------------------------------------");
                        TList_SaboresItens itens = new TList_SaboresItens();
                        if (o.lSabores.Count > 0)
                        {
                            o.lSabores.ForEach(u =>
                            {
                                itens.Add(u);
                            });
                        }
                        else
                        {
                            itens = TCN_SaboresItens.Buscar(o.Cd_empresa, o.id_prevenda.ToString(), o.id_item.ToString(), string.Empty, null);
                        }

                        if (itens.Count > 0)
                        {
                            imp.AppendLine("    Sabores "); //+ o.ds_produto);
                            itens.ForEach(i =>
                            {
                                imp.AppendLine("      " + i.DS_Sabor);
                            });
                        }
                    });
                    try
                    {
                        if (PDV.TGerenciarImpNaoFiscal.IniciarPorta(porta).Equals(1))
                            switch (PDV.TGerenciarImpNaoFiscal.LerStatus())
                            {
                                case 0:
                                    {
                                        MessageBox.Show("Erro de comunicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                case 5:
                                    {
                                        PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                        PDV.TGerenciarImpNaoFiscal.Guilhotina();
                                        MessageBox.Show("Impressão realizada com sucesso.\r\n" +
                                                        "Obs.: Impressora com pouco papel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    }
                                case 9:
                                    {
                                        MessageBox.Show("Erro imprimir: Tampa da impressora esta aberta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                case 24:
                                    {
                                        PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                        PDV.TGerenciarImpNaoFiscal.Guilhotina();
                                        break;
                                    }
                                case 32:
                                    {
                                        MessageBox.Show("Erro imprimir: Impressora sem papel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                            }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message.Trim()); }
                    finally
                    { PDV.TGerenciarImpNaoFiscal.FecharPorta(); }
                    #endregion
                }
                if (tp_impressora == null ? true : !tp_impressora.Equals("0"))
                {
                    #region NETUSE
                    // imprimir pedido
                    FileInfo f = null;
                    StreamWriter w = null;
                    if (!string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))
                        f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Pedido" + p.porta_imp + "fastfood.txt");
                    else if (!string.IsNullOrEmpty(cartao.nr_cartao))
                        f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Pedido" + p.porta_imp + "pedido.txt");
                    else
                        f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Pedido" + p.porta_imp + "delivery.txt");
                    w = f.CreateText();
                    try
                    {
                        if (lcfg[0].Tp_cartao.Equals("0"))
                        {
                            w.WriteLine("C A R T A O".FormatStringEsquerda(32, ' '));
                        }
                        else
                        if (lcfg[0].Tp_cartao.Equals("1"))
                        {
                            w.WriteLine(("Local: " + cartao.ds_local + " Mesa: " + cartao.nr_mesa).FormatStringEsquerda(32, ' '));
                        }
                        else
                        if (!string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))//se for fazio é delivery
                            w.WriteLine("F A S T F O O D".FormatStringEsquerda(32, ' '));
                        else if (!string.IsNullOrEmpty(cartao.nr_cartao))
                        {
                            if (!string.IsNullOrEmpty(cartao.id_local.ToString()))
                                w.WriteLine("L o c a l " + cartao.ds_local + " m e s a " + cartao.nr_mesa);
                            else
                                w.WriteLine("C a r t a o " + cartao.nr_cartao);
                        }
                        else
                            w.WriteLine("D E L I V E R Y".FormatStringEsquerda(32, ' '));

                        if (reimp)
                        {
                            w.WriteLine("------------------------------------------");
                            w.WriteLine("       REIMPRESSAO DE COMANDA");
                            w.WriteLine("------------------------------------------");
                        }

                        w.WriteLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm"));
                        w.WriteLine("CLIENTE: " + cartao.Nm_Clifor);

                        if (lcfg[0].Tp_cartao.Equals("1") || lcfg[0].bool_mesacartao)
                        {
                            w.WriteLine("Local: ".FormatStringEsquerda(7, ' ') + cartao.ds_local.FormatStringEsquerda(8, ' ') +
                                "Mesa: ".FormatStringEsquerda(7, ' ') + cartao.nr_mesa.FormatStringEsquerda(8, ' '));
                            if (lcfg[0].bool_mesacartao)
                                w.WriteLine("Cartão: ".FormatStringEsquerda(9, ' ') + p.nr_cartao.FormatStringEsquerda(12, ' '));
                        }
                        else if (!string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))
                            w.WriteLine("SENHA: ".FormatStringEsquerda(9, ' ') + p.NR_SenhaDelivery.FormatStringEsquerda(12, ' '));
                        else if (lcfg[0].Tp_cartao.Equals("0"))
                            w.WriteLine("Cartao: ".FormatStringDireita(9, ' ') + cartao.nr_cartao.FormatStringEsquerda(12, ' '));
                        else if (!lcfg[0].Tp_cartao.Equals("2"))
                            w.WriteLine("COMANDA: ".FormatStringDireita(9, ' ') + cartao.nr_cartao.FormatStringEsquerda(12, ' '));
                        else
                            w.WriteLine("COMANDA: ".FormatStringDireita(9, ' ') + prevenda.nr_cartao.FormatStringEsquerda(12, ' '));


                        if (p.bool_clientetira)
                            w.WriteLine(" * * * CLIENTE VEM BUSCAR * * * ");

                        if (string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))//se for fazio é delivery
                        {
                            if (lcfg[0].Bool_imp_end_cozinha)
                            {
                                w.WriteLine(("Fone: " + clifor[0].celular).FormatStringDireita(42, ' '));
                                w.WriteLine(("Endereco: " + clifor[0].endereco + " " + clifor[0].numero));
                                w.WriteLine(("Bairro: " + clifor[0].bairro).FormatStringDireita(42, ' '));
                                w.WriteLine(("Proximo: " + clifor[0].obs));
                            }
                        }


                        w.WriteLine("------------------------------------------");
                        w.WriteLine("Qta".FormatStringDireita(6, ' ')
                                    + "Produto".FormatStringDireita(25, ' '));
                        w.WriteLine("------------------------------------------");
                        p.lItens.ForEach(o =>
                        {
                            w.WriteLine(o.quantidade.FormatStringDireita(6, ' ')
                            + (o.ds_produto).FormatStringDireita(25, ' '));
                            if (o.st_registro.Trim().ToUpper().Equals("C"))
                                w.WriteLine("      *****CANCELADO*****      ");
                            if (!string.IsNullOrEmpty(o.obsItem))
                            {
                                string obs = "Obs: " + o.obsItem.Trim();
                                while (true)
                                {
                                    if (obs.Length <= 42)
                                    {
                                        w.WriteLine(obs);
                                        break;
                                    }
                                    else
                                    {
                                        w.WriteLine(obs.Substring(0, 42));
                                        obs = obs.Remove(0, 42);
                                    }
                                }
                            }
                            TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                            adicionais = new TCD_PreVenda_Item().Select(
                                new TpBusca[]
                                {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_itempaiadic",
                                vOperador = "=",
                                vVL_Busca = o.id_item.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_prevenda",
                                vOperador = "=",
                                vVL_Busca = o.id_prevenda.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_registro",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            }
                                }, 0, string.Empty);
                            adicionais.ForEach(ad =>
                            {
                                w.WriteLine("    " + ad.quantidade + " " + ad.ds_produto);
                            });

                            if (adicionais.Count > 0)
                                w.WriteLine("------------------------------------------");
                            TList_SaboresItens itens = new TList_SaboresItens();
                            if (o.lSabores.Count > 0)
                            {
                                o.lSabores.ForEach(u =>
                                {
                                    itens.Add(u);
                                });
                            }
                            else
                            {
                                itens = TCN_SaboresItens.Buscar(o.Cd_empresa, o.id_prevenda.ToString(), o.id_item.ToString(), string.Empty, null);
                            }

                            if (itens.Count > 0)
                            {
                                w.WriteLine("    Sabores "); //+ o.ds_produto);
                                itens.ForEach(i =>
                                {
                                    w.WriteLine("      " + i.DS_Sabor);
                                });
                            }
                        });


                        object tp_impi = new TCD_LocalImp().BuscarEscalar(
                            new TpBusca[] {
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_localimp",
                            vOperador = "=",
                            vVL_Busca = p.id_portaimp.ToString()
                        }
                            }, "a.tp_impressora");
                        //Inserir  linhas de espaço para separação do corte
                        int linhas = 9;
                        for (int i = 0; linhas > i; i++)
                            w.WriteLine();
                        if (tp_impi == null ? false : tp_impi.Equals("1"))
                        {
                            w.Write(Convert.ToChar(12));
                            w.Write(Convert.ToChar(27));
                            w.Write(Convert.ToChar(109));
                        }
                        else
                        {
                            w.Write(Convert.ToChar(27));
                            w.Write(Convert.ToChar(109));
                        }

                        w.Flush();

                        f.CopyTo(p.porta_imp, true);

                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro impressão pedido a cozinha: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        w.Dispose();
                        f = null;
                    }
                    #endregion
                }
            });
        }

        public static void Impressao_DELIVERY(TRegistro_PreVenda prevenda)
        {
            TList_CFG lcfg = TCN_CFG.Buscar(string.Empty, null);
            CamadaDados.Diversos.TList_CadEmpresa empresa = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lcfg[0].cd_empresa, string.Empty, string.Empty, null);
            CamadaDados.Financeiro.Cadastros.TList_CadEndereco end = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(empresa[0].Cd_clifor, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, null);
            TRegistro_Cartao rcard = TCN_Cartao.Buscar(prevenda.Cd_empresa, prevenda.id_cartao.ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null)[0];
            TList_Clifor clifor = new TList_Clifor();
            clifor = new TCD_Clifor().Select(new TpBusca[]
            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = rcard.Cd_Clifor
                                }
            }, 1, string.Empty);

            decimal total = decimal.Zero;
            decimal liq = decimal.Zero;

            CamadaDados.Faturamento.Cadastros.TList_PontoVenda pdv = CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty, string.Empty, Utils.Parametros.pubTerminal, lcfg[0].cd_empresa, null);
            if (pdv.Count.Equals(0)) { MessageBox.Show("Não foi localizado ponto de venda instânciado para o terminal: " + Utils.Parametros.pubTerminal + ". Não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; };

            //Buscar tipo da impressora
            object tp_impressora = null;
            if (pdv.Count > 0)
            {
                tp_impressora = new TCD_LocalImp().BuscarEscalar(
                    new TpBusca[]
                    {
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_localimp",
                        vOperador = "=",
                        vVL_Busca = pdv[0].id_localimp.ToString()
                    }
                    }, "tp_impressora");
            }

            if (tp_impressora != null ? tp_impressora.Equals("0") : false)
            {
                #region Bematech
                StringBuilder imp = new StringBuilder();
                imp.AppendLine(empresa[0].Nm_empresa);
                imp.AppendLine((!string.IsNullOrEmpty(end[0].Celular) ? end[0].Celular.FormatStringEsquerda(25, ' ') : end[0].Fone).FormatStringEsquerda(25, ' '));
                imp.AppendLine("                TOLEDO - PR              ");
                imp.AppendLine("================================================");
                imp.AppendLine("                 DELIVERY                ");
                imp.AppendLine("================================================");
                if (!string.IsNullOrEmpty(prevenda.St_delivery.ToString()))//se for vazio é fastfood
                    if (prevenda.bool_clientetira)
                        imp.AppendLine(" * * * CLIENTE VEM BUSCAR * * * ");
                imp.AppendLine("Comanda: ".FormatStringDireita(30, ' ') + (prevenda.nr_cartao).FormatStringEsquerda(18, ' '));
                imp.AppendLine("Data hora pedido: ".FormatStringDireita(20, ' ') + (prevenda.Dt_dataentregastr).FormatStringEsquerda(28, ' '));
                imp.AppendLine(("Cliente: " + clifor[0].Nm_clifor).FormatStringDireita(48, ' '));
                imp.AppendLine(("ID Cliente: " + clifor[0].Cd_clifor).FormatStringDireita(48, ' '));
                imp.AppendLine(("Fone: " + clifor[0].celular).FormatStringDireita(48, ' '));
                imp.AppendLine(("Bairro: " + clifor[0].bairro).FormatStringDireita(48, ' '));
                imp.AppendLine(("Endereco: " + clifor[0].endereco + " N " + clifor[0].numero));
                imp.AppendLine(("Proximo: " + clifor[0].obs).FormatStringDireita(48, ' '));
                imp.AppendLine("------------------------------------------------");
                imp.AppendLine("Produto".FormatStringDireita(24, ' ')
                    + "Qta".FormatStringEsquerda(8, ' ')
                    + "Unit R$".FormatStringEsquerda(8, ' ')
                    + "Total R$".FormatStringEsquerda(8, ' '));
                imp.AppendLine("------------------------------------------------");
                prevenda.lItens.ForEach(o =>
                {
                    total += o.vl_subtotal;
                    liq += o.vl_liquido;
                    if (!string.IsNullOrEmpty(o.id_itemPaiAdic.ToString()))
                        o.ds_produto = "     " + o.ds_produto;

                    imp.AppendLine((o.ds_produto).FormatStringDireita(24, ' ')
                        + (Convert.ToDecimal(o.quantidade.ToString("N2", new System.Globalization.CultureInfo("pt-BR")))).FormatStringEsquerda(8, ' ')
                        + (Convert.ToDecimal((o.vl_unitario - o.vl_desconto).ToString("N2", new System.Globalization.CultureInfo("pt-BR")))).FormatStringEsquerda(8, ' ')
                        + (Convert.ToDecimal(o.vl_liquido.ToString("N2", new System.Globalization.CultureInfo("pt-BR")))).FormatStringEsquerda(8, ' '));
                    //Observação do Item
                    if (!string.IsNullOrEmpty(o.obsItem))
                    {
                        string obs = "Obs: " + o.obsItem.Trim();
                        while (true)
                        {
                            if (obs.Length <= 48)
                            {
                                imp.AppendLine(obs);
                                break;
                            }
                            else
                            {
                                imp.AppendLine(obs.Substring(0, 48));
                                obs = obs.Remove(0, 48);
                            }
                        }
                    }
                    //Sabores
                    if (o.lSabores.Count > 0)
                    {
                        imp.AppendLine("    Sabores "); //+ o.ds_produto);
                        o.lSabores.ForEach(i =>
                        {
                            imp.AppendLine("      " + i.DS_Sabor);
                        });
                    }
                });

                imp.AppendLine("------------------------------------------------");
                if (!prevenda.St_levarcartaobool)
                    imp.AppendLine(("Troco para R$").FormatStringDireita(18, ' ') + ((Convert.ToDecimal(prevenda.Vl_TrocoPara.ToString("N2", new System.Globalization.CultureInfo("pt-BR"))))).FormatStringEsquerda(30, ' '));
                else
                    imp.AppendLine(("Troco para R$").FormatStringDireita(18, ' ') + ((Convert.ToDecimal(prevenda.Vl_TrocoPara.ToString("N2", new System.Globalization.CultureInfo("pt-BR"))))).FormatStringEsquerda(30, ' '));
                imp.AppendLine(("TOTAL PEDIDO R$").FormatStringDireita(18, ' ') + ((Convert.ToDecimal(liq.ToString("N2", new System.Globalization.CultureInfo("pt-BR"))))).FormatStringEsquerda(30, ' '));
                imp.AppendLine(("TROCO R$").FormatStringDireita(18, ' ') + ((Convert.ToDecimal((prevenda.Vl_TrocoPara - liq).ToString("N2", new System.Globalization.CultureInfo("pt-BR"))))).FormatStringEsquerda(30, ' '));
                if (prevenda.St_levarcartaobool)
                {
                    imp.AppendLine("------------------------------------------------");
                    imp.AppendLine("           LEVAR MAQUINA CARTAO            ");
                    imp.AppendLine("------------------------------------------------");
                }

                imp.AppendLine("------------------------------------------------");
                imp.AppendLine(("TOTAL A RECEBER R$").FormatStringDireita(22, ' ') + ((Convert.ToDecimal(liq.ToString("N2", new System.Globalization.CultureInfo("pt-BR"))))).FormatStringEsquerda(26, ' '));
                imp.AppendLine("------------------------------------------------");
                imp.AppendLine("        AGRADECEMOS A PREFERENCIA        ");
                if (!string.IsNullOrEmpty(prevenda.ObsFecharDelivery))
                    imp.AppendLine("Observaçao de entrega: " + prevenda.ObsFecharDelivery);

                try
                {
                    if (PDV.TGerenciarImpNaoFiscal.IniciarPorta(pdv[0].porta_imp.Trim()).Equals(1))
                    {
                        switch (PDV.TGerenciarImpNaoFiscal.LerStatus())
                        {
                            case 0:
                                {
                                    MessageBox.Show("Erro de comunicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            case 5:
                                {
                                    PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                    PDV.TGerenciarImpNaoFiscal.Guilhotina();
                                    MessageBox.Show("Impressão realizada com sucesso.\r\n" +
                                                    "Obs.: Impressora com pouco papel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            case 9:
                                {
                                    MessageBox.Show("Erro imprimir: Tampa da impressora esta aberta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            case 24:
                                {
                                    PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                    PDV.TGerenciarImpNaoFiscal.Guilhotina();
                                    break;
                                }
                            case 32:
                                {
                                    MessageBox.Show("Erro imprimir: Impressora sem papel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro imprimir: Não foi possível conexão com impressora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("Erro: " + ex.Message.Trim()); }
                finally
                { PDV.TGerenciarImpNaoFiscal.FecharPorta(); }
                #endregion
            }
            else
            {
                #region NetUse
                FileInfo f = null;
                StreamWriter w = null;
                f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Pedidodelivery" + ".txt");
                w = f.CreateText();
                try
                {
                    w.WriteLine(empresa[0].Nm_empresa);
                    w.WriteLine((!string.IsNullOrEmpty(end[0].Celular) ? end[0].Celular.FormatStringEsquerda(25, ' ') : end[0].Fone).FormatStringEsquerda(25, ' '));
                    w.WriteLine("                TOLEDO - PR              ");
                    w.WriteLine("================================================");
                    w.WriteLine("                 DELIVERY                ");
                    w.WriteLine("================================================");
                    if (!string.IsNullOrEmpty(prevenda.St_delivery.ToString()))//se for vazio é fastfood
                        if (prevenda.bool_clientetira)
                            w.WriteLine(" * * * CLIENTE VEM BUSCAR * * * ");
                    w.WriteLine("Comanda: ".FormatStringDireita(30, ' ') + (prevenda.nr_cartao).FormatStringEsquerda(18, ' '));
                    w.WriteLine("Data hora pedido: ".FormatStringDireita(20, ' ') + (prevenda.Dt_dataentregastr).FormatStringEsquerda(28, ' '));
                    w.WriteLine(("Cliente: " + clifor[0].Nm_clifor).FormatStringDireita(48, ' '));
                    w.WriteLine(("ID Cliente: " + clifor[0].Cd_clifor).FormatStringDireita(48, ' '));
                    w.WriteLine(("Fone: " + clifor[0].celular).FormatStringDireita(48, ' '));
                    w.WriteLine(("Bairro: " + clifor[0].bairro).FormatStringDireita(48, ' '));
                    w.WriteLine(("Endereco: " + clifor[0].endereco + " N " + clifor[0].numero));
                    w.WriteLine(("Proximo: " + clifor[0].obs).FormatStringDireita(48, ' '));
                    w.WriteLine("------------------------------------------------");
                    w.WriteLine("Produto".FormatStringDireita(24, ' ')
                        + "Qta".FormatStringEsquerda(8, ' ')
                        + "Unit R$".FormatStringEsquerda(8, ' ')
                        + "Total R$".FormatStringEsquerda(8, ' '));
                    w.WriteLine("------------------------------------------------");
                    prevenda.lItens.ForEach(o =>
                    {
                        total += o.vl_subtotal;
                        liq += o.vl_liquido;
                        if (!string.IsNullOrEmpty(o.id_itemPaiAdic.ToString()))
                            o.ds_produto = "     " + o.ds_produto;

                        w.WriteLine((o.ds_produto).FormatStringDireita(24, ' ')
                            + (Convert.ToDecimal(o.quantidade.ToString("N2", new System.Globalization.CultureInfo("pt-BR")))).FormatStringEsquerda(8, ' ')
                            + (Convert.ToDecimal((o.vl_unitario - o.vl_desconto).ToString("N2", new System.Globalization.CultureInfo("pt-BR")))).FormatStringEsquerda(8, ' ')
                            + (Convert.ToDecimal(o.vl_liquido.ToString("N2", new System.Globalization.CultureInfo("pt-BR")))).FormatStringEsquerda(8, ' '));
                        //Observação do Item
                        if (!string.IsNullOrEmpty(o.obsItem))
                        {
                            string obs = "Obs: " + o.obsItem.Trim();
                            while (true)
                            {
                                if (obs.Length <= 48)
                                {
                                    w.WriteLine(obs);
                                    break;
                                }
                                else
                                {
                                    w.WriteLine(obs.Substring(0, 48));
                                    obs = obs.Remove(0, 48);
                                }
                            }
                        }
                        //Sabores
                        if (o.lSabores.Count > 0)
                        {
                            w.WriteLine("    Sabores "); //+ o.ds_produto);
                            o.lSabores.ForEach(i =>
                            {
                                w.WriteLine("      " + i.DS_Sabor);
                            });
                        }
                    });

                    w.WriteLine("------------------------------------------------");
                    if (!prevenda.St_levarcartaobool)
                        w.WriteLine(("Troco para R$").FormatStringDireita(18, ' ') + ((Convert.ToDecimal(prevenda.Vl_TrocoPara.ToString("N2", new System.Globalization.CultureInfo("pt-BR"))))).FormatStringEsquerda(30, ' '));
                    else
                        w.WriteLine(("Troco para R$").FormatStringDireita(18, ' ') + ((Convert.ToDecimal(prevenda.Vl_TrocoPara.ToString("N2", new System.Globalization.CultureInfo("pt-BR"))))).FormatStringEsquerda(30, ' '));
                    w.WriteLine(("TOTAL PEDIDO R$").FormatStringDireita(18, ' ') + ((Convert.ToDecimal(liq.ToString("N2", new System.Globalization.CultureInfo("pt-BR"))))).FormatStringEsquerda(30, ' '));
                    w.WriteLine(("TROCO R$").FormatStringDireita(18, ' ') + ((Convert.ToDecimal((prevenda.Vl_TrocoPara - liq).ToString("N2", new System.Globalization.CultureInfo("pt-BR"))))).FormatStringEsquerda(30, ' '));
                    if (prevenda.St_levarcartaobool)
                    {
                        w.WriteLine("------------------------------------------------");
                        w.WriteLine("           LEVAR MAQUINA CARTAO            ");
                        w.WriteLine("------------------------------------------------");
                    }

                    w.WriteLine("------------------------------------------------");
                    w.WriteLine(("TOTAL A RECEBER R$").FormatStringDireita(22, ' ') + ((Convert.ToDecimal(liq.ToString("N2", new System.Globalization.CultureInfo("pt-BR"))))).FormatStringEsquerda(26, ' '));
                    w.WriteLine("------------------------------------------------");
                    w.WriteLine("        AGRADECEMOS A PREFERENCIA        ");
                    if (!string.IsNullOrEmpty(prevenda.ObsFecharDelivery))
                        w.WriteLine("Observaçao de entrega: " + prevenda.ObsFecharDelivery);

                    if (pdv.Count > 0)
                    {
                        if (pdv[0].id_localimp.Equals("1"))
                        {
                            w.Write(Convert.ToChar(12));
                            w.Write(Convert.ToChar(27));
                            w.Write(Convert.ToChar(109));
                        }
                        else if (pdv[0].id_localimp.Equals("2"))
                        {
                            w.WriteLine();
                            w.Write(Convert.ToChar(27));
                            w.Write(Convert.ToChar(109));
                        }
                        w.Flush();
                        f.CopyTo(pdv[0].porta_imp, true);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("Erro impressão comprovante comanda de entrega: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    w.Dispose();
                    f = null;
                }
                #endregion
            }
        }

        public static void ReImpressao_PEDIDOS(TRegistro_Clifor clifor, TRegistro_PreVenda prevenda, TRegistro_Cartao cartao = null)
        {
            TList_CFG lcfg = TCN_CFG.Buscar(string.Empty, null);
            if (cartao != null && !string.IsNullOrEmpty(cartao.id_cartao.ToString()))
                cartao = TCN_Cartao.Buscar(string.Empty, cartao.id_cartao.ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null)[0];

            TList_PreVenda lprevenda = new TList_PreVenda();
            prevenda.lItens.ForEach(p =>
            {
                if (p.id_portaimp == decimal.Zero)
                    return;
                TRegistro_PreVenda venda = new TRegistro_PreVenda();
                venda.id_prevenda = p.id_prevenda;

                venda.NR_SenhaDelivery = prevenda.NR_SenhaDelivery;

                if (string.IsNullOrEmpty(p.id_portaimp.ToString()) || p.id_portaimp == decimal.Zero)
                {
                    //Buscar Produto
                    CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                         new TpBusca[]
                         {
                             new TpBusca()
                             {
                                 vNM_Campo = "a.cd_produto",
                                 vOperador = "=",
                                 vVL_Busca = "'" + p.cd_produto.Trim() + "'"
                             }
                         }, 1, string.Empty, string.Empty, string.Empty);
                    if (lProd.Count > 0)
                    {
                        p.id_portaimp = Convert.ToDecimal(lProd[0].id_localimp.ToString());
                        p.porta_imp = lProd[0].porta_imp;
                    }
                }

                venda.id_portaimp = p.id_portaimp;
                prevenda.bool_clientetira = prevenda.bool_clientetira;
                venda.porta_imp = p.porta_imp;
                venda.NR_SenhaDelivery = prevenda.NR_SenhaDelivery;

                //Verificar se porta já existe na lista, se estiver ignorar senão adicionar
                if (lprevenda.Count == 0 ? true : lprevenda.Exists(x => x.porta_imp != venda.porta_imp))
                    lprevenda.Add(venda);
            });

            // adiciona itens no para a impressão
            prevenda.lItens.ForEach(p =>
                lprevenda.ForEach(o =>
                {
                    o.bool_clientetira = prevenda.bool_clientetira;
                    if (p.id_portaimp.Equals(o.id_portaimp) && !p.St_impressobool)
                        if (string.IsNullOrEmpty(p.id_itemPaiAdic.ToString()))
                            o.lItens.Add(p);
                }));
            prevenda.lDelItens.ForEach(p =>
                lprevenda.ForEach(o =>
                {
                    if (p.id_portaimp.Equals(o.id_portaimp))
                        if (string.IsNullOrEmpty(p.id_itemPaiAdic.ToString()))
                            o.lDelItens.Add(p);
                }));

            //Gerar Impressão
            lprevenda.ForEach(p =>
            {
                //busca tipo de impressora 0 é bematech
                object tp_impressora = null;
                tp_impressora = new TCD_LocalImp().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_localimp",
                                vOperador = "=",
                                vVL_Busca = p.id_portaimp.ToString()
                            }
                        }, "tp_impressora");

                if (tp_impressora != null ? tp_impressora.Equals("0") : false)
                {
                    #region bematech
                    StringBuilder imp = new StringBuilder();
                    if (lcfg[0].Tp_cartao.Equals("0"))
                    {
                        imp.AppendLine(("C A R T A O " + cartao.nr_cartao).FormatStringEsquerda(32, ' '));
                        if (!string.IsNullOrEmpty(cartao.nr_mesa))
                            imp.AppendLine(("MESA " + cartao.nr_mesa).FormatStringEsquerda(32, ' '));
                    }
                    else if (lcfg[0].Tp_cartao.Equals("1"))
                    {
                        imp.AppendLine((" LOCAL " + cartao.ds_local).FormatStringEsquerda(32, ' '));
                    }
                    else if (string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))//se for fazio é delivery 
                    {
                        imp.AppendLine("D E L I V E R Y".FormatStringEsquerda(32, ' '));

                        if (p.bool_clientetira)
                            imp.AppendLine(" * * * CLIENTE VEM BUSCAR * * * ");
                    }
                    imp.AppendLine("------------------------------------------");
                    if (lcfg[0].Tp_cartao.Equals("2"))
                        imp.AppendLine("* * * ALTERACAO DA COMANDA N " + p.nr_cartao + " * * * ");
                    else if (lcfg[0].Tp_cartao.Equals("1"))
                    {
                        imp.AppendLine("* * * ALTERACAO DA COMANDA * * * ");
                        imp.AppendLine("* PEDIDO NO LOCAL" + cartao.ds_local + " Mesa " + cartao.nr_mesa + " *");
                    }
                    imp.AppendLine("------------------------------------------");
                    imp.AppendLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm"));
                    imp.AppendLine("CLIENTE: " + clifor.Nm_clifor);
                    if (lcfg[0].Bool_imp_end_cozinha)//se for fazio é delivery
                    {
                        imp.AppendLine(("Celular: " + clifor.celular).FormatStringDireita(46, ' '));
                        imp.AppendLine(("Endereco: " + clifor.endereco + " N " + clifor.numero).FormatStringDireita(46, ' '));
                        imp.AppendLine(("Bairro: " + clifor.bairro).FormatStringDireita(46, ' '));
                        imp.AppendLine(("Proximo: " + clifor.obs).FormatStringDireita(46, ' '));
                    }
                    int rem = 0;
                    p.lDelItens.ForEach(i =>
                    {
                        if (rem == 0)
                        {
                            imp.AppendLine("------------------------------------------");
                            imp.AppendLine("* * * R E M O V E R DA C O M A N D A * * ");
                            imp.AppendLine("------------------------------------------");
                            imp.AppendLine("COMANDA: ".FormatStringDireita(8, ' ') + p.id_prevenda.FormatStringEsquerda(8, ' '));
                            imp.AppendLine("Qta".FormatStringDireita(6, ' ')
                                        + "Produto".FormatStringDireita(25, ' '));
                            imp.AppendLine("------------------------------------------");
                            rem++;
                        }
                        imp.AppendLine(i.quantidade.FormatStringDireita(6, ' ') + (i.ds_produto).FormatStringDireita(25, ' '));
                        //Observação do Item
                        if (!string.IsNullOrEmpty(i.obsItem))
                        {
                            string obs = "Obs: " + i.obsItem.Trim();
                            while (true)
                            {
                                if (obs.Length <= 42)
                                {
                                    imp.AppendLine(obs);
                                    break;
                                }
                                else
                                {
                                    imp.AppendLine(obs.Substring(0, 42));
                                    obs = obs.Remove(0, 42);
                                }
                            }
                        }
                        TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                        adicionais = new TCD_PreVenda_Item().Select(
                            new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_itempaiadic",
                                vOperador = "=",
                                vVL_Busca = i.id_item.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_prevenda",
                                vOperador = "=",
                                vVL_Busca = i.id_prevenda.ToString()
                            }
                            }, 0, string.Empty);

                        adicionais.ForEach(ad =>
                        {
                            imp.AppendLine("     " + ad.quantidade + " " + ad.ds_produto);
                        });
                        if (adicionais.Count > 0)
                            imp.AppendLine("------------------------------------------");

                    });
                    if (rem > 0)
                        imp.AppendLine();
                    int adc = 0;
                    p.lItens.ForEach(i =>
                    {
                        //Marcar como Impresso
                        i.St_impressobool = true;
                        i.St_impresso = "S";

                        if (adc == 0)
                        {
                            imp.AppendLine("------------------------------------------");
                            imp.AppendLine("* * A D I C I O N A R NA C O M A N D A * *");
                            imp.AppendLine("------------------------------------------");
                            imp.AppendLine("COMANDA: ".FormatStringDireita(8, ' ') + p.nr_cartao.FormatStringEsquerda(8, ' '));
                            imp.AppendLine("Qta".FormatStringDireita(6, ' ')
                                        + "Produto".FormatStringDireita(25, ' '));
                            imp.AppendLine("------------------------------------------");
                            adc++;
                        }
                        imp.AppendLine(i.quantidade.FormatStringDireita(6, ' ') + (i.ds_produto).FormatStringDireita(25, ' '));
                        //Observação do Item
                        if (!string.IsNullOrEmpty(i.obsItem))
                        {
                            string obs = "Obs: " + i.obsItem.Trim();
                            while (true)
                            {
                                if (obs.Length <= 42)
                                {
                                    imp.AppendLine(obs);
                                    break;
                                }
                                else
                                {
                                    imp.AppendLine(obs.Substring(0, 42));
                                    obs = obs.Remove(0, 42);
                                }
                            }
                        }
                        TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                        adicionais = new TCD_PreVenda_Item().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_itempaiadic",
                                    vOperador = "=",
                                    vVL_Busca = i.id_item.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_prevenda",
                                    vOperador = "=",
                                    vVL_Busca = i.id_prevenda.ToString()
                                }
                            }, 0, string.Empty);
                        adicionais.ForEach(ad =>
                        {
                            imp.AppendLine("    " + ad.ds_produto);
                        });
                        TList_SaboresItens itens = new TList_SaboresItens();
                        if (i.lSabores.Count > 0)
                        {
                            i.lSabores.ForEach(u =>
                            {
                                itens.Add(u);
                            });
                        }
                        else
                        {
                            itens = TCN_SaboresItens.Buscar(i.Cd_empresa, i.id_prevenda.ToString(), i.id_item.ToString(), string.Empty, null);
                        }

                        if (itens.Count > 0)
                        {
                            imp.AppendLine("    Sabores "); //+ i.ds_produto);
                            itens.ForEach(o =>
                            {
                                imp.AppendLine("      " + o.DS_Sabor);
                            });
                        }
                    });
                    if (p.lItens.Count > 0)
                    {
                        try
                        {
                            if (PDV.TGerenciarImpNaoFiscal.IniciarPorta(p.porta_imp.Trim()).Equals(1))
                                switch (PDV.TGerenciarImpNaoFiscal.LerStatus())
                                {
                                    case 0:
                                        {
                                            MessageBox.Show("Erro de comunicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                        }
                                    case 5:
                                        {
                                            PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                            PDV.TGerenciarImpNaoFiscal.Guilhotina();
                                            //Gravar Itens para registrar impressão
                                            p.lItens.ForEach(x => TCN_PreVenda_Item.Gravar(x, null));
                                            MessageBox.Show("Impressão realizada com sucesso.\r\n" +
                                                            "Obs.: Impressora com pouco papel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            break;
                                        }
                                    case 9:
                                        {
                                            MessageBox.Show("Erro imprimir: Tampa da impressora esta aberta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                        }
                                    case 24:
                                        {
                                            PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                            PDV.TGerenciarImpNaoFiscal.Guilhotina();
                                            //Gravar Itens para registrar impressão
                                            p.lItens.ForEach(x => TCN_PreVenda_Item.Gravar(x, null));
                                            break;
                                        }
                                    case 32:
                                        {
                                            MessageBox.Show("Erro imprimir: Impressora sem papel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                        }
                                }
                            else
                            {
                                MessageBox.Show("Não foi possível conexão com impressora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro: " + ex.Message.Trim()); }
                        finally
                        { PDV.TGerenciarImpNaoFiscal.FecharPorta(); }
                    }
                    #endregion
                }
                if (tp_impressora == null ? true : !tp_impressora.Equals("0")) //netuse
                {
                    #region netuse
                    FileInfo fi = null;
                    StreamWriter wi = null;
                    fi = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Pedido" + p.porta_imp.Trim() + "delivery.txt");
                    wi = fi.CreateText();
                    try
                    {
                        wi.Write(Convert.ToChar(27));
                        wi.Write(Convert.ToChar(15));
                        wi.Write(Convert.ToChar(15));
                        if (lcfg[0].Tp_cartao.Equals("0"))
                        {
                            wi.WriteLine(("C A R T A O " + cartao.nr_cartao).FormatStringEsquerda(32, ' '));
                            if (!string.IsNullOrEmpty(cartao.nr_mesa))
                                wi.WriteLine(("MESA " + cartao.nr_mesa).FormatStringEsquerda(32, ' '));
                        }
                        else
                        if (lcfg[0].Tp_cartao.Equals("1"))
                        {
                            wi.WriteLine((" LOCAL " + cartao.ds_local).FormatStringEsquerda(32, ' '));
                        }
                        else
                        if (string.IsNullOrEmpty(p.NR_SenhaDelivery.ToString()))//se for fazio é delivery 
                        {
                            wi.WriteLine("D E L I V E R Y".FormatStringEsquerda(32, ' '));

                            if (p.bool_clientetira)
                                wi.WriteLine(" * * * CLIENTE VEM BUSCAR * * * ");
                        }
                        //wi.WriteLine("------------------------------------------");
                        if (lcfg[0].Tp_cartao.Equals("2"))
                            wi.WriteLine("* * * ALTERACAO DA COMANDA N " + p.nr_cartao + " * * * ");
                        else if (lcfg[0].Tp_cartao.Equals("1"))
                        {
                            wi.WriteLine("* * * ALTERACAO DA COMANDA * * * ");
                            wi.WriteLine("* PEDIDO NO LOCAL" + cartao.ds_local + " Mesa " + cartao.nr_mesa + " *");
                        }
                        wi.WriteLine("------------------------------------------");
                        wi.WriteLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm"));
                        wi.WriteLine("CLIENTE: " + clifor.Nm_clifor);
                        if (lcfg[0].Bool_imp_end_cozinha)//se for fazio é delivery
                        {
                            wi.WriteLine(("Celular: " + clifor.celular).FormatStringDireita(46, ' '));
                            wi.WriteLine(("Endereco: " + clifor.endereco + " N " + clifor.numero).FormatStringDireita(46, ' '));
                            wi.WriteLine(("Bairro: " + clifor.bairro).FormatStringDireita(46, ' '));
                            wi.WriteLine(("Proximo: " + clifor.obs).FormatStringDireita(46, ' '));
                        }
                        int rem = 0;
                        p.lDelItens.ForEach(i =>
                        {
                            if (rem == 0)
                            {
                                wi.WriteLine("------------------------------------------");
                                wi.WriteLine("* * * R E M O V E R DA C O M A N D A * * ");
                                wi.WriteLine("------------------------------------------");
                                wi.WriteLine("COMANDA: ".FormatStringDireita(8, ' ') + p.id_prevenda.FormatStringEsquerda(8, ' '));
                                wi.WriteLine("Qta".FormatStringDireita(6, ' ')
                                            + "Produto".FormatStringDireita(25, ' '));
                                wi.WriteLine("------------------------------------------");
                                rem++;
                            }
                            wi.WriteLine(i.quantidade.FormatStringDireita(6, ' ') + (i.ds_produto).FormatStringDireita(25, ' '));
                            //Observação do Item
                            if (!string.IsNullOrEmpty(i.obsItem))
                            {
                                string obs = "Obs: " + i.obsItem.Trim();
                                while (true)
                                {
                                    if (obs.Length <= 42)
                                    {
                                        wi.WriteLine(obs);
                                        break;
                                    }
                                    else
                                    {
                                        wi.WriteLine(obs.Substring(0, 42));
                                        obs = obs.Remove(0, 42);
                                    }
                                }
                            }
                            TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                            adicionais = new TCD_PreVenda_Item().Select(
                                new TpBusca[]
                                {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_itempaiadic",
                                vOperador = "=",
                                vVL_Busca = i.id_item.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_prevenda",
                                vOperador = "=",
                                vVL_Busca = i.id_prevenda.ToString()
                            }
                                }, 0, string.Empty);

                            adicionais.ForEach(ad =>
                            {
                                wi.WriteLine("     " + ad.quantidade + " " + ad.ds_produto);
                            });
                            if (adicionais.Count > 0)
                                wi.WriteLine("------------------------------------------");

                        });
                        if (rem > 0)
                            wi.WriteLine();
                        int adc = 0;
                        p.lItens.ForEach(i =>
                        {
                            //Marcar como Impresso
                            i.St_impressobool = true;
                            i.St_impresso = "S";

                            if (adc == 0)
                            {
                                wi.WriteLine("------------------------------------------");
                                wi.WriteLine("* * A D I C I O N A R NA C O M A N D A * *");
                                wi.WriteLine("------------------------------------------");
                                wi.WriteLine("COMANDA: ".FormatStringDireita(8, ' ') + p.nr_cartao.FormatStringEsquerda(8, ' '));
                                wi.WriteLine("Qta".FormatStringDireita(6, ' ')
                                            + "Produto".FormatStringDireita(25, ' '));
                                wi.WriteLine("------------------------------------------");
                                adc++;
                            }
                            wi.WriteLine(i.quantidade.FormatStringDireita(6, ' ') + (i.ds_produto).FormatStringDireita(25, ' '));
                            //Observação do Item
                            if (!string.IsNullOrEmpty(i.obsItem))
                            {
                                string obs = "Obs: " + i.obsItem.Trim();
                                while (true)
                                {
                                    if (obs.Length <= 42)
                                    {
                                        wi.WriteLine(obs);
                                        break;
                                    }
                                    else
                                    {
                                        wi.WriteLine(obs.Substring(0, 42));
                                        obs = obs.Remove(0, 42);
                                    }
                                }
                            }
                            TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                            adicionais = new TCD_PreVenda_Item().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_itempaiadic",
                                        vOperador = "=",
                                        vVL_Busca = i.id_item.ToString()
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_prevenda",
                                        vOperador = "=",
                                        vVL_Busca = i.id_prevenda.ToString()
                                    }
                                }, 0, string.Empty);
                            adicionais.ForEach(ad =>
                            {
                                wi.WriteLine("    " + ad.ds_produto);
                            });
                            TList_SaboresItens itens = new TList_SaboresItens();
                            if (i.lSabores.Count > 0)
                            {
                                i.lSabores.ForEach(u =>
                                {
                                    itens.Add(u);
                                });
                            }
                            else
                            {
                                itens = TCN_SaboresItens.Buscar(i.Cd_empresa, i.id_prevenda.ToString(), i.id_item.ToString(), string.Empty, null);
                            }

                            if (itens.Count > 0)
                            {
                                wi.WriteLine("    Sabores "); //+ i.ds_produto);
                                itens.ForEach(o =>
                                {
                                    wi.WriteLine("      " + o.DS_Sabor);
                                });
                            }
                        });


                        wi.WriteLine();
                        wi.WriteLine();

                        object tp_imp = new TCD_LocalImp().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_localimp",
                                    vOperador = "=",
                                    vVL_Busca = p.id_portaimp.ToString()
                                }
                            }, "a.tp_impressora");
                        //Inserir linhas de espaço para separação do corte
                        int linhas = 9;
                        for (int i = 0; linhas > i; i++)
                            wi.WriteLine();
                        if (tp_imp == null ? false : tp_imp.Equals("1"))
                        {
                            wi.Write(Convert.ToChar(12));
                            wi.Write(Convert.ToChar(27));
                            wi.Write(Convert.ToChar(109));
                        }
                        else
                        {
                            wi.Write(Convert.ToChar(27));
                            wi.Write(Convert.ToChar(109));
                        }
                        wi.Flush();

                        fi.CopyTo(p.porta_imp, true);
                        //Gravar Itens para registrar impressão
                        p.lItens.ForEach(x => TCN_PreVenda_Item.Gravar(x, null));
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro impressão pedido " + p.porta_imp.Trim() + ": " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        wi.Dispose();
                        fi = null;
                    }
                    #endregion
                }

            });
        }

        /// <summary>
        /// A impressão de extrato composto, consiste na listagem de vários cartões, com vários itens de prévenda.
        /// Encaminhada para um determinado ponto de venda pré-configurado, todos parametros devem ser informados.
        /// </summary>
        /// <param name="_Itens"></param>
        /// <param name="_Cartaos"></param>
        public static void Impressao_ExtratoComposto(TList_PreVenda_Item _Itens, TList_Cartao _Cartaos, string id_pdv)
        {
            if (!carregarCfgRes() || !carregarPontoVenda(id_pdv)) return;
            if (_Itens == null || _Cartaos == null || string.IsNullOrEmpty(id_pdv))
            {
                MessageBox.Show("Erro na leitura dos parâmetros para gerar extrato composto. Parâmetros: Itens da pré-venda, Cartões e Ponto de venda configurado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (_Itens.Count.Equals(0) || _Cartaos.Count.Equals(0))
            {
                MessageBox.Show("Erro na leitura dos parâmetros para gerar extrato composto. Parâmetros: Itens da pré-venda, Cartões e Ponto de venda configurado. Para gerar extrato é necessário pelo menos um cartão e um item.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Buscar impressora por ponto de venda
            object tp_impressora = null;
            tp_impressora = new TCD_LocalImp().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_pontovenda x where x.id_pdv = '" + _PontoVenda.Id_pdv + "' and x.id_localimp = a.id_localimp)"
                        }
                    }, "tp_impressora");

            #region Bematech
            if (tp_impressora == null ? false : tp_impressora.Equals("0"))
            {
                StringBuilder imp = new StringBuilder();
                imp.AppendLine("       E X T R A T O  DE  C O N S U M O         ");
                imp.AppendLine("                                                ");
                imp.AppendLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm").Replace("/", "-"));
                formatStringBuilder(ref imp, "clientePorCartao", cartaos: _Cartaos);
                formatStringBuilder(ref imp, "locaisPorMesas", cartaos: _Cartaos);
                formatStringBuilder(ref imp, "cartaoPorItens", itens: _Itens, cartaos: _Cartaos);
                imp.AppendLine("Total" + _Itens.Sum(p => p.vl_liquido).FormatStringEsquerda(37, ' '));
                imp.AppendLine("------------------------------------------------");
                imp.AppendLine("             SEM VALOR FISCAL                   ");
                imp.AppendLine("                                                ");
                imp.AppendLine("         AGRADECEMOS A PREFERÊNCIA              ");
                imp.AppendLine("          " + _Cfg.ds_empresa);
                try
                {
                    if (PDV.TGerenciarImpNaoFiscal.IniciarPorta(_PontoVenda.porta_imp).Equals(1))
                        switch (PDV.TGerenciarImpNaoFiscal.LerStatus())
                        {
                            case 0:
                                {
                                    MessageBox.Show("Erro de comunicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            case 5:
                                {
                                    PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                    PDV.TGerenciarImpNaoFiscal.Guilhotina();
                                    MessageBox.Show("Impressão realizada com sucesso.\r\n" +
                                                    "Obs.: Impressora com pouco papel.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            case 9:
                                {
                                    MessageBox.Show("Erro imprimir: Tampa da impressora esta aberta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            case 24:
                                {
                                    PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                    PDV.TGerenciarImpNaoFiscal.Guilhotina();
                                    break;
                                }
                            case 32:
                                {
                                    MessageBox.Show("Erro imprimir: Impressora sem papel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                        }
                    else
                    {
                        MessageBox.Show("Erro imprimir: Não foi possível conexão com impressora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("Erro: " + ex.Message.Trim()); }
                finally
                { PDV.TGerenciarImpNaoFiscal.FecharPorta(); }
            }
            #endregion
            #region Netuse
            else
            {
                FileInfo fi = null;
                StreamWriter wi = null;
                fi = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "impressao cliente " + ".txt");
                wi = fi.CreateText();
                try
                {
                    wi.WriteLine("       E X T R A T O  DE  C O N S U M O         ");
                    wi.WriteLine("                                                ");
                    wi.WriteLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm").Replace("/", "-"));
                    formatStreamWriter(ref wi, "clientePorCartao", cartaos: _Cartaos);
                    formatStreamWriter(ref wi, "locaisPorMesas", cartaos: _Cartaos);
                    formatStreamWriter(ref wi, "cartaoPorItens", itens: _Itens, cartaos: _Cartaos);
                    wi.WriteLine("Total" + _Itens.Sum(p => p.vl_liquido).FormatStringEsquerda(37, ' '));
                    wi.WriteLine("------------------------------------------------");
                    wi.WriteLine("             SEM VALOR FISCAL                   ");
                    wi.WriteLine("                                                ");
                    wi.WriteLine("         AGRADECEMOS A PREFERÊNCIA              ");
                    wi.WriteLine("          " + _Cfg.ds_empresa);

                    if (_PontoVenda.tp_imp.Equals("1"))
                    {
                        wi.Write(Convert.ToChar(12));
                        wi.Write(Convert.ToChar(27));
                        wi.Write(Convert.ToChar(109));
                    }
                    else if (_PontoVenda.tp_imp.Equals("2"))
                    {
                        wi.Write(Convert.ToChar(27));
                        wi.Write(Convert.ToChar(109));
                    }
                    wi.Flush();
                    fi.CopyTo(_PontoVenda.porta_imp, true);
                }
                catch (Exception ex)
                { MessageBox.Show("Erro impressão pedido a cozinha: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    wi.Dispose();
                    fi = null;
                }

            }
            #endregion
        }

        /// <summary>
        /// Permite impressão de uma lista de itens, que devem ter id_porta e st_impresso false
        /// </summary>
        /// <param name="_Clifor"> Não pode ser nulo </param>
        /// <param name="_Itens"> Não pode ser nulo</param>
        /// <param name="_Cartao"></param>
        public static void Impressao_ITENSPORPORTA(TRegistro_Clifor _Clifor, TList_PreVenda_Item _Itens, TRegistro_Cartao _Cartao)
        {
            _Itens.RemoveAll(i => i.St_impressobool.Equals(true));
            if (_Clifor.Equals(null) || _Itens.Equals(null) || _Itens.Count.Equals(0))
            {
                return;
            }
            else if (!carregarCfgRes())
            {
                return;
            }

            _Itens.ForEach(i =>
            {
                //Validar se item já não foi agrupado e impresso
                if (i.St_impressobool.Equals(true))
                    return;

                //Buscar tipo da impressora pela porta do item
                object tp_impressora = null;
                tp_impressora = new TCD_LocalImp().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_localimp",
                                vOperador = "=",
                                vVL_Busca = i.id_portaimp.ToString()
                            }
                        }, "tp_impressora");

                if (tp_impressora != null ? tp_impressora.Equals("0") : false)
                {
                    #region Bematech
                    StringBuilder imp = new StringBuilder();
                    if (_Cfg.Tp_cartao.Equals("0"))
                    {
                        imp.AppendLine(("C A R T A O " + _Cartao.nr_cartao).FormatStringEsquerda(32, ' '));
                        if (!string.IsNullOrEmpty(_Cartao.nr_mesa))
                            imp.AppendLine(("MESA " + _Cartao.nr_mesa).FormatStringEsquerda(32, ' '));
                    }
                    else if (_Cfg.Tp_cartao.Equals("1"))
                        imp.AppendLine((" LOCAL " + _Cartao.ds_local).FormatStringEsquerda(32, ' '));

                    imp.AppendLine("------------------------------------------");
                    if (_Cfg.Tp_cartao.Equals("2"))
                        imp.AppendLine("* * * ALTERACAO DA COMANDA N " + _Cartao.nr_cartao + " * * * ");
                    else if (_Cfg.Tp_cartao.Equals("1"))
                    {
                        imp.AppendLine("* * * ALTERACAO DA COMANDA * * * ");
                        imp.AppendLine("* PEDIDO NO LOCAL" + _Cartao.ds_local + " Mesa " + _Cartao.nr_mesa + " *");
                    }
                    imp.AppendLine("------------------------------------------");
                    imp.AppendLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm"));
                    imp.AppendLine("CLIENTE: " + _Clifor.Nm_clifor);
                    if (_Cfg.Bool_imp_end_cozinha)//se for fazio é delivery
                    {
                        imp.AppendLine(("Celular: " + _Clifor.celular).FormatStringDireita(46, ' '));
                        imp.AppendLine(("Endereco: " + _Clifor.endereco + " N " + _Clifor.numero).FormatStringDireita(46, ' '));
                        imp.AppendLine(("Bairro: " + _Clifor.bairro).FormatStringDireita(46, ' '));
                        imp.AppendLine(("Proximo: " + _Clifor.obs).FormatStringDireita(46, ' '));
                    }

                    imp.AppendLine("------------------------------------------");
                    imp.AppendLine("* * A D I C I O N A R NA C O M A N D A * *");
                    imp.AppendLine("------------------------------------------");
                    imp.AppendLine("COMANDA: ".FormatStringDireita(8, ' ') + _Cartao.nr_card.FormatStringEsquerda(8, ' '));
                    imp.AppendLine("Qta".FormatStringDireita(6, ' ')
                                + "Produto".FormatStringDireita(25, ' '));
                    imp.AppendLine("------------------------------------------");

                    //Buscar todos itens com a mesma porta, para imprimir junto
                    _Itens.FindAll(p => p.id_portaimp.Equals(i.id_portaimp)).ForEach(x =>
                    {
                        x.St_impressobool = true;
                        imp.AppendLine(x.quantidade.FormatStringDireita(6, ' ') + (x.ds_produto).FormatStringDireita(25, ' '));

                        //Observação do Item
                        if (!string.IsNullOrEmpty(x.obsItem))
                        {
                            string obs = "Obs: " + x.obsItem.Trim();
                            while (true)
                            {
                                if (obs.Length <= 42)
                                {
                                    imp.AppendLine(obs);
                                    break;
                                }
                                else
                                {
                                    imp.AppendLine(obs.Substring(0, 42));
                                    obs = obs.Remove(0, 42);
                                }
                            }
                        }

                        TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                        adicionais = new TCD_PreVenda_Item().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_itempaiadic",
                                    vOperador = "=",
                                    vVL_Busca = x.id_item.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_prevenda",
                                    vOperador = "=",
                                    vVL_Busca = x.id_prevenda.ToString()
                                }
                            }, 0, string.Empty);
                        adicionais.ForEach(ad =>
                        {
                            imp.AppendLine("    " + ad.ds_produto);
                        });

                        TList_SaboresItens itens = new TList_SaboresItens();
                        if (x.lSabores.Count > 0)
                        {
                            x.lSabores.ForEach(u =>
                            {
                                itens.Add(u);
                            });
                        }
                        else
                        {
                            itens = TCN_SaboresItens.Buscar(x.Cd_empresa, x.id_prevenda.ToString(), x.id_item.ToString(), string.Empty, null);
                        }

                        if (itens.Count > 0)
                        {
                            imp.AppendLine("    Sabores ");
                            itens.ForEach(o =>
                            {
                                imp.AppendLine("      " + o.DS_Sabor);
                            });
                        }
                    });

                    try
                    {
                        if (PDV.TGerenciarImpNaoFiscal.IniciarPorta(i.porta_imp.Trim()).Equals(1))
                            switch (PDV.TGerenciarImpNaoFiscal.LerStatus())
                            {
                                case 0:
                                    {
                                        MessageBox.Show("Erro de comunicação com a impressora pelo IP. " + i.porta_imp.Trim(),
                                                         "Erro",
                                                         MessageBoxButtons.OK,
                                                         MessageBoxIcon.Error);
                                        _Itens.FindAll(x => x.id_portaimp.Equals(i.id_portaimp)).ForEach(y => y.st_gerouErroImpressao = true);
                                        break;
                                    }
                                case 5:
                                    {
                                        PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                        PDV.TGerenciarImpNaoFiscal.Guilhotina();

                                        //Gravar Itens para registrar impressão
                                        _Itens.FindAll(x => x.id_portaimp.Equals(i.id_portaimp)).ForEach(x => TCN_PreVenda_Item.Gravar(x, null));
                                        MessageBox.Show("Impressão realizada com sucesso.\r\n" +
                                                        "Obs.: Impressora com pouco papel pelo IP. " + i.porta_imp.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    }
                                case 9:
                                    {
                                        MessageBox.Show("Erro imprimir: Tampa da impressora esta aberta pelo IP. " + i.porta_imp.Trim(),
                                                        "Erro",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Error);
                                        _Itens.FindAll(x => x.id_portaimp.Equals(i.id_portaimp)).ForEach(y => y.st_gerouErroImpressao = true);
                                        break;
                                    }
                                case 24:
                                    {
                                        PDV.TGerenciarImpNaoFiscal.Texto(imp.ToString());
                                        PDV.TGerenciarImpNaoFiscal.Guilhotina();

                                        //Gravar Itens para registrar impressão
                                        _Itens.FindAll(x => x.id_portaimp.Equals(i.id_portaimp)).ForEach(x => TCN_PreVenda_Item.Gravar(x, null));
                                        break;
                                    }
                                case 32:
                                    {
                                        MessageBox.Show("Erro imprimir: Impressora sem papel pelo IP. " + i.porta_imp.Trim(),
                                                        "Erro",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Error);
                                        _Itens.FindAll(x => x.id_portaimp.Equals(i.id_portaimp)).ForEach(y => y.st_gerouErroImpressao = true);
                                        break;
                                    }
                            }
                        else
                        {
                            MessageBox.Show("Não foi possível conectar a impressora pelo IP. " + i.porta_imp.Trim(),
                                        "Erro",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                            _Itens.FindAll(x => x.id_portaimp.Equals(i.id_portaimp)).ForEach(y => y.st_gerouErroImpressao = true);
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    { PDV.TGerenciarImpNaoFiscal.FecharPorta(); }
                    #endregion
                }
                else
                {
                    #region NetUse
                    FileInfo fi = null;
                    StreamWriter wi = null;
                    fi = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Pedido" + i.porta_imp.Trim() + "delivery.txt");
                    wi = fi.CreateText();
                    try
                    {
                        wi.Write(Convert.ToChar(27));
                        wi.Write(Convert.ToChar(15));
                        wi.Write(Convert.ToChar(15));
                        if (_Cfg.Tp_cartao.Equals("0"))
                        {
                            wi.WriteLine(("C A R T A O " + _Cartao.nr_cartao).FormatStringEsquerda(32, ' '));
                            if (!string.IsNullOrEmpty(_Cartao.nr_mesa))
                                wi.WriteLine(("MESA " + _Cartao.nr_mesa).FormatStringEsquerda(32, ' '));
                        }
                        else if (_Cfg.Tp_cartao.Equals("1"))
                        {
                            wi.WriteLine((" LOCAL " + _Cartao.ds_local).FormatStringEsquerda(32, ' '));
                        }
                        if (_Cfg.Tp_cartao.Equals("2"))
                            wi.WriteLine("* * * ALTERACAO DA COMANDA N " + _Cartao.nr_cartao + " * * * ");
                        else if (_Cfg.Tp_cartao.Equals("1"))
                        {
                            wi.WriteLine("* * * ALTERACAO DA COMANDA * * * ");
                            wi.WriteLine("* PEDIDO NO LOCAL" + _Cartao.ds_local + " Mesa " + _Cartao.nr_mesa + " *");
                        }
                        wi.WriteLine("------------------------------------------");
                        wi.WriteLine("DATA: " + Convert.ToDateTime(CamadaDados.UtilData.Data_Servidor()).ToString("dd/MM/yyyy hh:mm"));
                        wi.WriteLine("CLIENTE: " + _Clifor.Nm_clifor);
                        if (_Cfg.Bool_imp_end_cozinha)//se for fazio é delivery
                        {
                            wi.WriteLine(("Celular: " + _Clifor.celular).FormatStringDireita(46, ' '));
                            wi.WriteLine(("Endereco: " + _Clifor.endereco + " N " + _Clifor.numero).FormatStringDireita(46, ' '));
                            wi.WriteLine(("Bairro: " + _Clifor.bairro).FormatStringDireita(46, ' '));
                            wi.WriteLine(("Proximo: " + _Clifor.obs).FormatStringDireita(46, ' '));
                        }

                        wi.WriteLine("------------------------------------------");
                        wi.WriteLine("* * A D I C I O N A R NA C O M A N D A * *");
                        wi.WriteLine("------------------------------------------");
                        wi.WriteLine("COMANDA: ".FormatStringDireita(8, ' ') + _Cartao.nr_cartao.FormatStringEsquerda(8, ' '));
                        wi.WriteLine("Qta".FormatStringDireita(6, ' ')
                                    + "Produto".FormatStringDireita(25, ' '));
                        wi.WriteLine("------------------------------------------");

                        //Buscar todos itens com a mesma porta, para imprimir junto
                        _Itens.FindAll(p => p.St_impressobool.Equals(false) && p.id_portaimp.Equals(i.id_portaimp)).ForEach(x =>
                        {
                            x.St_impressobool = true;
                            wi.WriteLine(x.quantidade.FormatStringDireita(6, ' ') + (x.ds_produto).FormatStringDireita(25, ' '));

                            //Observação do Item
                            if (!string.IsNullOrEmpty(x.obsItem))
                            {
                                string obs = "Obs: " + x.obsItem.Trim();
                                while (true)
                                {
                                    if (obs.Length <= 42)
                                    {
                                        wi.WriteLine(obs);
                                        break;
                                    }
                                    else
                                    {
                                        wi.WriteLine(obs.Substring(0, 42));
                                        obs = obs.Remove(0, 42);
                                    }
                                }
                            }

                            TList_PreVenda_Item adicionais = new TList_PreVenda_Item();
                            adicionais = new TCD_PreVenda_Item().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_itempaiadic",
                                        vOperador = "=",
                                        vVL_Busca = x.id_item.ToString()
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_prevenda",
                                        vOperador = "=",
                                        vVL_Busca = x.id_prevenda.ToString()
                                    }
                                }, 0, string.Empty);
                            adicionais.ForEach(ad =>
                            {
                                wi.WriteLine("    " + ad.ds_produto);
                            });

                            TList_SaboresItens itens = new TList_SaboresItens();
                            if (x.lSabores.Count > 0)
                            {
                                x.lSabores.ForEach(u =>
                                {
                                    itens.Add(u);
                                });
                            }
                            else
                            {
                                itens = TCN_SaboresItens.Buscar(x.Cd_empresa, x.id_prevenda.ToString(), x.id_item.ToString(), string.Empty, null);
                            }

                            if (itens.Count > 0)
                            {
                                wi.WriteLine("    Sabores ");
                                itens.ForEach(o =>
                                {
                                    wi.WriteLine("      " + o.DS_Sabor);
                                });
                            }
                        });

                        wi.WriteLine();
                        wi.WriteLine();

                        if (tp_impressora == null ? false : tp_impressora.Equals("1"))
                        {
                            wi.Write(Convert.ToChar(12));
                            wi.Write(Convert.ToChar(27));
                            wi.Write(Convert.ToChar(109));
                        }
                        else
                        {
                            wi.Write(Convert.ToChar(27));
                            wi.Write(Convert.ToChar(109));
                        }
                        wi.Flush();

                        fi.CopyTo("Pedido" + i.porta_imp.Trim() + "delivery", true);
                        //Gravar Itens para registrar impressão
                        _Itens.FindAll(x => x.id_portaimp.Equals(i.id_portaimp)).ForEach(x => TCN_PreVenda_Item.Gravar(x, null));
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro impressão pedido " + i.porta_imp.Trim() + ": " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        wi.Dispose();
                        fi = null;
                    }
                    #endregion
                }
            });

            _Itens.FindAll(z => z.st_gerouErroImpressao.Equals(true)).ForEach(w => w.St_impressobool = false);
        }

    }
}
