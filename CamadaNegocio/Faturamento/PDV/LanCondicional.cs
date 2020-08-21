using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.PDV;
using System.IO;
using Utils;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_Condicional
    {
        public static TList_Condicional Buscar(string Cd_empresa,
                                               string Id_condicional,
                                               string Cd_clifor,
                                               string Cd_produto,
                                               string Tp_data,
                                               string Dt_ini,
                                               string Dt_fin,
                                               string Tp_movimento,
                                               string St_registro,
                                               bool St_saldoDev,
                                               bool St_saldonfnormal,
                                               bool St_saldonfdev,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_condicional))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_condicional";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_condicional;
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_itenscondicional x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_condicional = a.id_condicional " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (Tp_data.Trim().ToUpper().Equals("C") ? "a.dt_condicional" : "a.dt_prevdevolucao") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (Tp_data.Trim().ToUpper().Equals("C") ? "a.dt_condicional" : "a.dt_prevdevolucao") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_movimento.Trim() + ")";
            }
            if (St_saldoDev)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from vtb_pdv_itenscondicional x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_condicional = a.id_condicional " +
                                                      "and x.quantidade - x.qtd_devolvida > 0)";
            }
            if (St_saldonfnormal)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from vtb_pdv_itenscondicional x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_condicional = a.id_condicional " +
                                                      "and x.quantidade - x.Qtd_nfcond > 0)";
            }
            if (St_saldonfdev)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from vtb_pdv_itenscondicional x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_condicional = a.id_condicional " +
                                                      "and x.Qtd_devolvida - x.Qtd_nfdev > 0)";
            }
            return new TCD_Condicional(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Condicional val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Condicional qtb_cond = new TCD_Condicional();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cond.CriarBanco_Dados(true);
                else
                    qtb_cond.Banco_Dados = banco;
                //Gravar condicional
                val.Id_condicionalstr = CamadaDados.TDataQuery.getPubVariavel(qtb_cond.Gravar(val), "@P_ID_CONDICIONAL");
                //Excluir itens condicional
                val.lItensDel.ForEach(p => TCN_ItensCondicional.Excluir(p, qtb_cond.Banco_Dados));
                //Gravar itens condicional
                bool st_movestoque = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal(qtb_cond.Banco_Dados).BuscarEscalar(
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
                                                vNM_Campo = "isnull(a.st_movestoque, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            }
                                        }, "1") != null;
                val.lItens.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_condicional = val.Id_condicional;
                        p.Tp_movimento = val.Tp_movimento;
                        TCN_ItensCondicional.Gravar(p, 
                                                    (st_movestoque ? (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_cond.Banco_Dados).ItemServico(p.Cd_produto)) &&
                                                    (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_cond.Banco_Dados).ProdutoConsumoInterno(p.Cd_produto)) : false),
                                                    qtb_cond.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
                return val.Id_condicionalstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Condicional val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Condicional qtb_cond = new TCD_Condicional();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cond.CriarBanco_Dados(true);
                else
                    qtb_cond.Banco_Dados = banco;
                //Verificar se condic
                val.lItensDel.ForEach(p => TCN_ItensCondicional.Excluir(p, qtb_cond.Banco_Dados));
                val.lItens.ForEach(p => TCN_ItensCondicional.Excluir(p, qtb_cond.Banco_Dados));
                val.St_registro = "C";
                qtb_cond.Gravar(val);
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
                return val.Id_condicionalstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }

        public static void ImprimirReduzido(TRegistro_Condicional val, BancoDados.TObjetoBanco banco)
        {
            object obj1 = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_terminal",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                            }
                                        }, "a.porta_imptick");
            if (obj1 == null)
                throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
            //Buscar dados da empresa
            CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                            string.Empty,
                                                            string.Empty,
                                                            null);
            if (lEmpresa.Count < 1)
                throw new Exception("Não foi possivel localizar empresa " + val.Cd_empresa);
            //Buscar Endereco do cliente
            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                         val.Cd_endereco,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         0,
                                                                         null);
            if (lEndereco.Count < 1)
                throw new Exception("Não foi possivel localizar endereço " + val.Cd_endereco);

            FileInfo f = null;
            StreamWriter w = null;
            f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Condicional.txt");
            w = f.CreateText();
            try
            {
                w.WriteLine("  REQUISIÇÃO DE MATERIAL Nº " + (val.Id_condicionalstr) + " " + val.Dt_condicionalstr);
                w.WriteLine(" =========================================");
                w.WriteLine("               DADOS EMPRESA              ");
                w.WriteLine(" =========================================");
                w.WriteLine("  " + lEmpresa[0].Nm_empresa.Trim().ToUpper());
                w.WriteLine("  " + lEmpresa[0].Ds_endereco.Trim().ToUpper() + "," + lEmpresa[0].rEndereco.Numero);
                w.WriteLine("  " + lEmpresa[0].rEndereco.Bairro.Trim().ToUpper());
                w.WriteLine(" -----------------------------------------");
                w.WriteLine("               DADOS CLIENTE              ");
                w.WriteLine(" -----------------------------------------");
                w.WriteLine("  " + val.Nm_clifor.Trim().ToUpper());
                w.WriteLine("  " + lEndereco[0].Ds_endereco.Trim().ToUpper() + "," + lEndereco[0].Numero);
                w.WriteLine("  " + lEndereco[0].Bairro.Trim().ToUpper());
                w.WriteLine("  " + lEndereco[0].DS_Cidade.Trim().ToUpper() + " - " + lEndereco[0].UF);
                w.WriteLine("  " + lEndereco[0].Proximo.Trim().ToUpper());
                w.WriteLine(" -----------------------------------------");
                w.WriteLine("  PROD      QTD      DEVOLVIDO    DEVOLVER");
                w.WriteLine(" -----------------------------------------");

                w.WriteLine("  " + (val.Tp_movimento.ToString().ToUpper().Equals("E") ? "ENTRADA" : "SAÍDA"));
                val.lItens.ForEach(p =>
                {
                    w.WriteLine("  " + (p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim().ToUpper()));
                    w.Write(p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(14, ' ') + "x");
                    w.Write(p.Qtd_devolvida.ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(15, ' '));
                    w.Write(p.Saldo_devolver.ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' '));
                    w.WriteLine();
                });

                w.WriteLine(" -----------------------------------------");
                w.WriteLine("                  TOTAL                   ");
                w.Write(val.lItens.Sum(p => p.Quantidade).ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(14, ' ') + "x");
                w.Write(val.lItens.Sum(p => p.Qtd_devolvida).ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(15, ' '));
                w.Write(val.lItens.Sum(p => p.Saldo_devolver).ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' '));
                w.WriteLine();
                w.WriteLine(" -----------------------------------------");
                w.WriteLine("  STATUS: " + (val.lItens.Sum(p => p.Saldo_devolver).Equals(0) ? "DEVOLVIDO" : "ABERTO"));
                w.WriteLine("  VENDEDOR: " + val.Nm_vendedor.ToString().ToUpper());

                w.WriteLine();
                w.WriteLine();
                w.WriteLine("  ----------------------------------- ");
                w.WriteLine("                Assinatura            ");

                w.Write(Convert.ToChar(12));
                w.Write(Convert.ToChar(27));
                w.Write(Convert.ToChar(109));
                w.Flush();

                decimal copias = CamadaNegocio.ConfigGer.TCN_CadParamGer.VlNumericoEmpresa("QTD_VIA_REC_ECF", val.Cd_empresa, null);
                if (copias.Equals(decimal.Zero))
                    copias = 1;
                for (int i = 0; i < copias; i++)
                    f.CopyTo(obj1.ToString());
            }
            catch (Exception ex)
            { throw new Exception("Erro na impressao: " + ex.Message.Trim()); }
            finally
            {
                w.Dispose();
                f = null;
            }
        }

        public static void ProcessarNFCondicional(CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Condicional qtb_cond = new TCD_Condicional();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cond.CriarBanco_Dados(true);
                //Buscar moeda padrao
                string moeda = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", rNf.Cd_empresa, qtb_cond.Banco_Dados);
                if (string.IsNullOrEmpty(moeda))
                    throw new Exception("Não existe moeda padrão configurada para a empresa " + rNf.Cd_empresa);
                //Gravar Pedido
                CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                rPed.CD_Empresa = rNf.Cd_empresa;
                rPed.CD_Clifor = rNf.Cd_clifor;
                rPed.CD_Endereco = rNf.Cd_endereco;
                rPed.Cd_moeda = moeda;
                rPed.Cd_moeda = moeda;
                rPed.CFG_Pedido = rNf.lCFGFiscal[0].Cfg_pedido;
                rPed.DT_Pedido = rNf.Dt_emissao;
                rPed.TP_Movimento = rNf.Tp_movimento; //Pedido de saida
                rPed.ST_Pedido = "F"; //Pedido fechado
                rPed.ST_Registro = "F"; //Pedido fechado
                //Montar itens do pedido
                rNf.ItensNota.ForEach(p =>
                    {
                        rPed.Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                        {
                            Cd_Empresa = p.Cd_empresa,
                            Cd_local = p.Cd_local,
                            Cd_produto = p.Cd_produto,
                            Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                            Cd_unidade_est = p.Cd_unidade,
                            Cd_unidade_valor = p.Cd_unidade,
                            Quantidade = p.Quantidade,
                            Vl_unitario = p.Vl_unitario,
                            Vl_subtotal = p.Vl_subtotal
                        });
                    });
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, qtb_cond.Banco_Dados);
                //Gravar Nota Fiscal
                rNf.Nr_pedido = rPed.Nr_pedido;
                for (int i = 0; i < rPed.Pedido_Itens.Count; i++)
                {
                    rNf.ItensNota[i].Nr_pedido = rPed.Pedido_Itens[i].Nr_pedido.Value;
                    rNf.ItensNota[i].Id_pedidoitem = rPed.Pedido_Itens[i].Id_pedidoitem;
                }
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rNf, null, qtb_cond.Banco_Dados);
                //Amarrar Itens NF a Itens Condicional
                rNf.ItensNota.ForEach(p =>
                    TCN_ItensCondicional_xNFItem.Gravar(new TRegistro_ItensCondicional_x_NFItem()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Id_condicional = p.rItemCondicional.Id_condicional,
                        Id_item = p.rItemCondicional.Id_item,
                        Nr_lanctofiscal = p.Nr_lanctofiscal,
                        Id_nfitem = p.Id_nfitem
                    }, qtb_cond.Banco_Dados));
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar NF Condicional: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }

        public static void ProcessarNFDevCond(CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Condicional qtb_cond = new TCD_Condicional();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cond.CriarBanco_Dados(true);
                rNf.ItensNota.ForEach(p =>
                    {
                        CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item lPedItem =
                            new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item(qtb_cond.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                "where x.nr_pedido = a.nr_pedido " +
                                                "and x.cd_produto = a.cd_produto " +
                                                "and x.id_pedidoitem = a.id_pedidoitem " +
                                                "and x.cd_empresa = '" + p.lNfcompdev[0].Cd_empresa.Trim() + "' " +
                                                "and x.nr_lanctofiscal = " + p.lNfcompdev[0].Nr_lanctofiscal_origem.ToString() + " " +
                                                "and x.id_nfitem = " + p.lNfcompdev[0].Id_nfitem_origem.ToString() + ")"

                                }
                            }, 1, string.Empty, string.Empty, string.Empty);
                        if (lPedItem.Count > 0)
                        {
                            p.Nr_pedido = lPedItem[0].Nr_pedido.Value;
                            p.Id_pedidoitem = lPedItem[0].Id_pedidoitem;
                        }
                    });
                rNf.Nr_pedido = rNf.ItensNota[0].Nr_pedido;
                //Gravar Nota Fiscal
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rNf, null, qtb_cond.Banco_Dados);
                //Amarrar Itens NF a Itens Condicional
                rNf.ItensNota.ForEach(p =>
                    TCN_ItensCondicional_xNFItem.Gravar(new TRegistro_ItensCondicional_x_NFItem()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Id_condicional = p.rItemCondicional.Id_condicional,
                        Id_item = p.rItemCondicional.Id_item,
                        Nr_lanctofiscal = p.Nr_lanctofiscal,
                        Id_nfitem = p.Id_nfitem
                    }, qtb_cond.Banco_Dados));
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar NF Condicional: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensCondicional
    {
        public static TList_ItensCondicional Buscar(string Cd_empresa,
                                                    string Id_condicional,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_condicional))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_condicional";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_condicional;
            }
            return new TCD_ItensCondicional(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensCondicional val, 
                                    bool St_movestoque,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCondicional qtb_itens = new TCD_ItensCondicional();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                val.Id_itemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_ITEM");
                //Gravar estoque para cada item
                if (St_movestoque)
                {
                    CamadaDados.Estoque.TRegistro_LanEstoque rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                    rEstoque.Cd_empresa = val.Cd_empresa;
                    rEstoque.Cd_produto = val.Cd_produto;
                    rEstoque.Cd_local = val.Cd_local;
                    rEstoque.Dt_lancto = CamadaDados.UtilData.Data_Servidor(qtb_itens.Banco_Dados);
                    rEstoque.Tp_movimento = val.Tp_movimento;
                    rEstoque.Qtd_entrada = val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Quantidade : decimal.Zero;
                    rEstoque.Qtd_saida = val.Tp_movimento.Trim().ToUpper().Equals("S") ? val.Quantidade : decimal.Zero;
                    rEstoque.Vl_unitario = val.Vl_unitario;
                    rEstoque.Vl_subtotal = val.Vl_subtotal;
                    rEstoque.Tp_lancto = "N";//Normal
                    rEstoque.St_registro = "A";//Ativo
                    rEstoque.Ds_observacao = "CONDICIONAL Nº" + val.Id_condicionalstr;
                    val.lGrade.ForEach(p => { rEstoque.lGrade.Add(p); });
                    CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(rEstoque, qtb_itens.Banco_Dados);
                    //Item condicional x estoque
                    TCN_ItensCondicional_X_Estoque.Gravar(new TRegistro_ItensCondicional_X_Estoque()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_condicional = val.Id_condicional,
                        Id_item = val.Id_item,
                        Cd_produto = val.Cd_produto,
                        Id_lanctoestoque = rEstoque.Id_lanctoestoque
                    }, qtb_itens.Banco_Dados);
                }
                //Amarrar item condicional a item pre venda
                if (val.rItemPreVenda != null)
                    TCN_PreVenda_X_Condicional.Gravar(new TRegistro_PreVenda_X_Condicional()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_prevenda = val.rItemPreVenda.Id_prevenda,
                        Id_itemprevenda = val.rItemPreVenda.Id_itemprevenda,
                        Id_condicional = val.Id_condicional,
                        Id_item = val.Id_item
                    }, qtb_itens.Banco_Dados);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensCondicional val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCondicional qtb_itens = new TCD_ItensCondicional();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                if (!string.IsNullOrEmpty(val.Cd_empresa) &&
                    !string.IsNullOrEmpty(val.Id_condicionalstr) &&
                    !string.IsNullOrEmpty(val.Id_itemstr))
                {
                    //Verificar se o item esta faturado
                    if (new TCD_VendaRapida_Item(qtb_itens.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_itenscondicional_x_vendarapida x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_cupom = a.id_vendarapida " +
                                        "and x.id_lancto = a.id_lanctovenda " +
                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                        "and x.id_condicional = " + val.Id_condicionalstr + " " +
                                        "and x.id_item = " + val.Id_itemstr + ")"
                        }
                        }, "1") != null)
                        throw new Exception("Não é permitido cancelar item condicional faturado.");
                    //Verificar se o item movimentou estoque
                    TCN_ItensCondicional_X_Estoque.BuscarEstoque(val.Cd_empresa,
                                                                 val.Id_condicionalstr,
                                                                 val.Id_itemstr,
                                                                 qtb_itens.Banco_Dados).ForEach(p =>
                                                                     {
                                                                     //Cancelar estoque
                                                                     Estoque.TCN_LanEstoque.CancelarEstoque(p, qtb_itens.Banco_Dados);
                                                                     //Excluir item x estoque
                                                                     TCN_ItensCondicional_X_Estoque.Excluir(new TRegistro_ItensCondicional_X_Estoque()
                                                                         {
                                                                             Cd_empresa = val.Cd_empresa,
                                                                             Id_condicional = val.Id_condicional,
                                                                             Id_item = val.Id_item,
                                                                             Cd_produto = p.Cd_produto,
                                                                             Id_lanctoestoque = p.Id_lanctoestoque
                                                                         }, qtb_itens.Banco_Dados);
                                                                     });
                    //Verificar se o item teve origem pre venda
                    TCN_PreVenda_X_Condicional.Buscar(val.Cd_empresa,
                                                      string.Empty,
                                                      string.Empty,
                                                      val.Id_condicionalstr,
                                                      val.Id_itemstr,
                                                      qtb_itens.Banco_Dados).ForEach(p => TCN_PreVenda_X_Condicional.Excluir(p, qtb_itens.Banco_Dados));
                    val.St_registro = "C";//Cancelar item
                    qtb_itens.Gravar(val);
                }
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static void DevolverItensCond(List<TRegistro_ItensCondicional> val, BancoDados.TObjetoBanco banco)
        {
            bool st_transcao = false;
            TCD_ItensCondicional qtb_itens = new TCD_ItensCondicional();
            try
            {
                if (banco == null)
                    st_transcao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        decimal vl_medio = decimal.Zero;
                        //Buscar Vl.Unitario
                        object objVl_unit = new CamadaDados.Estoque.TCD_LanEstoque(qtb_itens.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_PDV_ItensCondicional_X_Estoque x " +
                                                    "where a.Id_LanctoEstoque = x.Id_LanctoEstoque " +
                                                    "and a.cd_empresa = x.cd_empresa " +
                                                    "and a.cd_produto = x.cd_produto " +
                                                    "and x.id_item = " + p.Id_itemstr + " " +
                                                    "and x.id_condicional = " + p.Id_condicionalstr + " " +
                                                    "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                    "and x.cd_produto = '" + p.Cd_produto.Trim() + "')"
                                    }
                                }, "a.vl_unitario");
                        if (objVl_unit == null || string.IsNullOrEmpty(objVl_unit.ToString()))
                            vl_medio = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(p.Cd_empresa, p.Cd_produto, qtb_itens.Banco_Dados);
                        else
                            vl_medio = decimal.Parse(objVl_unit.ToString());
                        //Gravar estoque devolucao
                        CamadaDados.Estoque.TRegistro_LanEstoque rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                        rEstoque.Cd_empresa = p.Cd_empresa;
                        rEstoque.Cd_produto = p.Cd_produto;
                        rEstoque.Cd_local = p.Cd_local;
                        rEstoque.Dt_lancto = CamadaDados.UtilData.Data_Servidor(qtb_itens.Banco_Dados);
                        rEstoque.Tp_movimento = p.Tp_movimento.Trim().ToUpper().Equals("E") ? "S" : "E";
                        rEstoque.Qtd_entrada = p.Tp_movimento.Trim().ToUpper().Equals("S") ? p.Qtd_devolver : decimal.Zero;
                        rEstoque.Qtd_saida = p.Tp_movimento.Trim().ToUpper().Equals("E") ? p.Qtd_devolver : decimal.Zero;
                        rEstoque.Vl_unitario = vl_medio;
                        rEstoque.Vl_subtotal = p.Vl_subtotal;
                        rEstoque.Tp_lancto = "N";//Normal
                        rEstoque.St_registro = "A";//Ativo
                        rEstoque.Ds_observacao = "DEVOLUÇÃO CONDICIONAL Nº" + p.Id_condicionalstr;
                        p.lGrade.ForEach(v => { rEstoque.lGrade.Add(v); });
                        
                        CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(rEstoque, qtb_itens.Banco_Dados);
                        //Item condicional x estoque
                        TCN_ItensCondicional_X_Estoque.Gravar(new TRegistro_ItensCondicional_X_Estoque()
                        {
                            
                            Cd_empresa = p.Cd_empresa,
                            Id_condicional = p.Id_condicional,
                            Id_item = p.Id_item,
                            Cd_produto = p.Cd_produto,
                            Id_lanctoestoque = rEstoque.Id_lanctoestoque
                        }, qtb_itens.Banco_Dados);
                    });
                if (st_transcao)
                    qtb_itens.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transcao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro devolver itens: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transcao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensCondicional_X_Estoque
    {
        public static TList_ItensCondicional_X_Estoque Buscar(string Cd_empresa,
                                                              string Id_condicional,
                                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_condicional))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_condicional";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Id_condicional.Trim() + "'";
            }
            return new TCD_ItensCondicional_X_Estoque(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Estoque.TList_RegLanEstoque BuscarEstoque(string Cd_empresa,
                                                                            string Id_condicional,
                                                                            string Id_item,
                                                                            BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Estoque.TCD_LanEstoque(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdv_itenscondicional_x_estoque x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_produto = a.cd_produto " +
                                    "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_condicional = " + Id_condicional + " " +
                                    "and x.id_item = " + Id_item + ")"
                    }
                }, 0, string.Empty, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_ItensCondicional_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCondicional_X_Estoque qtb_itens = new TCD_ItensCondicional_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                string retorno = qtb_itens.Gravar(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensCondicional_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCondicional_X_Estoque qtb_itens = new TCD_ItensCondicional_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else

                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensCondicional_X_VendaRapida
    {
        public static TList_ItensCondicional_X_VendaRapida Buscar(string Cd_empresa,
                                                                  string Id_condicional,
                                                                  string Id_cupom,
                                                                  string Id_lancto,
                                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_condicional))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_condicional";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_condicional;
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
            return new TCD_ItensCondicional_X_VendaRapida(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensCondicional_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCondicional_X_VendaRapida qtb_itens = new TCD_ItensCondicional_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                string retorno = qtb_itens.Gravar(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensCondicional_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCondicional_X_VendaRapida qtb_itens = new TCD_ItensCondicional_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensCondicional_xNFItem
    {
        public static TList_ItensCondicional_x_NFItem Buscar(string Cd_empresa,
                                                             string Id_condicional,
                                                             string Id_item,
                                                             string Nr_lanctofiscal,
                                                             string Id_nfitem,
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
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfitem;
            }
            return new TCD_ItensCondicional_x_NFItem(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento BuscarNF(string Cd_empresa,
                                                                                          string Id_condicional,
                                                                                          BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdv_itenscondicional_x_nfitem x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                    "and x.id_nfitem = a.id_nfitem " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_condicional = " + Id_condicional.Trim() + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensCondicional_x_NFItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCondicional_x_NFItem qtb_itens = new TCD_ItensCondicional_x_NFItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                string retorno = qtb_itens.Gravar(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensCondicional_x_NFItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCondicional_x_NFItem qtb_itens = new TCD_ItensCondicional_x_NFItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }
}
