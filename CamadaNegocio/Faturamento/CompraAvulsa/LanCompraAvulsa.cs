using System;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.CompraAvulsa;

namespace CamadaNegocio.Faturamento.CompraAvulsa
{
    public class TCN_CompraAvulsa
    {
        public static TList_CompraAvulsa Buscar(string Cd_empresa,
                                                string NR_compra,
                                                string Id_compra,
                                                string Cd_clifor,
                                                string Cd_produto,
                                                string Dt_ini,
                                                string Dt_fin,
                                                string St_registro,
                                                BancoDados.TObjetoBanco banco)
            {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(NR_compra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_compra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + NR_compra.Trim() + "'"; 
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_compra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_compra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_compra;
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
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_compra_itens x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_compra = a.id_compra " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_compra)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_compra)))";
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

            return new TCD_CompraAvulsa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CompraAvulsa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraAvulsa qtb_compra = new TCD_CompraAvulsa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                //Buscar config compra avulsa
                CamadaDados.Faturamento.Cadastros.TList_CfgCompraAvulsa lCfg = Cadastros.TCN_CfgCompraAvulsa.Buscar(val.Cd_empresa, qtb_compra.Banco_Dados);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração para gravar romaneio de compra na empresa " + val.Cd_empresa.Trim());
                val.Id_comprastr = CamadaDados.TDataQuery.getPubVariavel(qtb_compra.Gravar(val), "@P_ID_COMPRA");
                //Item Compra
                val.lItensDel.ForEach(p => TCN_Compra_Itens.Excluir(p, qtb_compra.Banco_Dados));
                val.lItens.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_compra = val.Id_compra;
                        p.Cd_local = lCfg[0].Cd_local;
                        TCN_Compra_Itens.Gravar(p, qtb_compra.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return val.Id_comprastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar compra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CompraAvulsa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraAvulsa qtb_compra = new TCD_CompraAvulsa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                //Verificar se existe item faturado
                if (new TCD_CompraItens_X_PedidoItens(qtb_compra.Banco_Dados).BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_compra",
                            vOperador = "=",
                            vVL_Busca = val.Id_comprastr
                        }
                    }, "1") != null)
                    throw new Exception("Não é permitido excluir romaneio com itens faturados.");
                val.lItens.ForEach(p => TCN_Compra_Itens.Excluir(p, qtb_compra.Banco_Dados));
                qtb_compra.Excluir(val);
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return val.Id_comprastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir compra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }

        public static void RatearDesconto(TRegistro_CompraAvulsa val, bool St_perc)
        {
            decimal total = val.lItens.Sum(p => p.Vl_subtotal);
            if (total > decimal.Zero)
            {
                if (!St_perc)
                    val.Pc_desconto = val.Vl_desconto * 100 / total;
                else
                    val.Vl_desconto = total * val.Pc_desconto / 100;
                val.lItens.ForEach(p =>
                {
                    p.Vl_desconto = (p.Vl_subtotal * val.Vl_desconto) / total;
                    p.Pc_desconto = val.Pc_desconto;
                });
            }
        }

        

        
    }

    public class TCN_Compra_Itens
    {
        public static TList_Compra_Itens Buscar(string Cd_empresa,
                                                string Id_compra,
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
            if (!string.IsNullOrEmpty(Id_compra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_compra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_compra;
            }
            TList_Compra_Itens lItem = new TCD_Compra_Itens(banco).Select(filtro, 0, string.Empty);
            lItem.ForEach(p =>
            {
                p.lItemOs = TCN_CompraItens_X_PecaOS.Buscar(p.Cd_empresa, p.Id_comprastr, p.Id_itemcomprastr, banco);
                p.lOs = new CamadaDados.Servicos.TCD_LanServico(banco).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_compraitens_x_pecaos x " +
                                        "where x.cd_empresa = '" + p.Cd_empresa.Trim() + "'" +
                                        "and x.id_compra = " + p.Id_comprastr + " " +
                                        "and x.id_itemcompra = " + p.Id_itemcomprastr + " " +
                                        "and x.cd_empresa = a.cd_empresa and x.id_os = a.id_os)"
                        }
                    }, 0, string.Empty, string.Empty);
            });
            return lItem;
        }

        public static string Gravar(TRegistro_Compra_Itens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Compra_Itens qtb_compra = new TCD_Compra_Itens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                val.Id_itemcomprastr = CamadaDados.TDataQuery.getPubVariavel(qtb_compra.Gravar(val), "@P_ID_ITEMCOMPRA");
                if (!string.IsNullOrEmpty(val.Cd_produto))
                {
                    //Produto movimenta estoque ou almoxarifado
                    if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_compra.Banco_Dados).ProdutoConsumoInterno(val.Cd_produto))
                    {
                        if (new CamadaDados.Estoque.TCD_LanEstoque(qtb_compra.Banco_Dados).BuscarEscalar(
                               new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FAT_CompraItens_X_Estoque x " +
                                                    "where x.id_lanctoestoque = a.id_lanctoestoque " +
                                                    "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                                                    "and x.id_compra = " + val.Id_comprastr + " " +
                                                    "and x.id_itemcompra = " + val.Id_itemcomprastr + ") "
                                    }
                                }, "1") == null)
                        {
                            //Gravar estoque da compra
                            string ret_estoque =
                            Estoque.TCN_LanEstoque.GravarEstoque(
                                new CamadaDados.Estoque.TRegistro_LanEstoque()
                                {
                                    Cd_empresa = val.Cd_empresa,
                                    Cd_produto = val.Cd_produto,
                                    Cd_local = val.Cd_local,
                                    Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                    Tp_movimento = "E",
                                    Qtd_entrada = val.Quantidade,
                                    Qtd_saida = decimal.Zero,
                                    Vl_unitario = Math.Round(decimal.Divide(val.Vl_subtotal + val.Vl_despesas - val.Vl_desconto, val.Quantidade), 7, MidpointRounding.AwayFromZero),
                                    Vl_subtotal = val.Vl_subtotal + val.Vl_despesas - val.Vl_desconto,
                                    Tp_lancto = "N",
                                    Ds_observacao = "ENTRADA DEVIDA AO ROMANEIRO DE COMPRA N. " + val.Id_comprastr
                                }, qtb_compra.Banco_Dados);
                            //Gravar estoque X compra avulsa
                            TCN_CompraItens_X_Estoque.Gravar(new TRegistro_CompraItens_X_Estoque()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Id_compra = val.Id_compra,
                                Id_itemcompra = val.Id_itemcompra,
                                Cd_produto = val.Cd_produto,
                                Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_estoque, "@@P_ID_LANCTOESTOQUE"))
                            }, qtb_compra.Banco_Dados);
                        }
                    }
                    else
                    {
                        if (new CamadaDados.Almoxarifado.TCD_Movimentacao(qtb_compra.Banco_Dados).BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FAT_CompraItens_X_Almox x " +
                                                    "where x.id_movimento = a.id_movimento " +
                                                    "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                                                    "and x.id_compra = " + val.Id_comprastr + " " +
                                                    "and x.id_itemcompra = " + val.Id_itemcomprastr + ") "
                                    }
                                }, "1") == null)
                        {
                            //Buscar Almoxarifado
                            CamadaDados.Faturamento.Cadastros.TList_CfgCompraAvulsa lCfg =
                                new CamadaDados.Faturamento.Cadastros.TCD_CfgCompraAvulsa().Select(
                                new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_almox",
                                vOperador = "is not",
                                vVL_Busca = "null"
                            }
                        }, 1, string.Empty);
                            if (lCfg.Count == 0)
                                throw new Exception("Não existe configuração de almoxarifado para a empresa!");
                            //Criar registro movimentação
                            CamadaDados.Almoxarifado.TRegistro_Movimentacao rMov = new CamadaDados.Almoxarifado.TRegistro_Movimentacao();
                            rMov.Ds_observacao = "ENTRADA REALIZADA PELO ROMANEIO DE COMPRA N. " + val.Id_itemcomprastr;
                            rMov.Cd_empresa = val.Cd_empresa;
                            rMov.Id_almoxstr = lCfg[0].Id_almoxstr;
                            rMov.Cd_produto = val.Cd_produto;
                            rMov.Quantidade = val.Quantidade;
                            rMov.Vl_unitario = Math.Round(decimal.Divide(val.Vl_subtotal + val.Vl_despesas - val.Vl_desconto, val.Quantidade), 5, MidpointRounding.AwayFromZero);
                            rMov.Tp_movimento = "E";
                            rMov.LoginAlmoxarife = Utils.Parametros.pubLogin;
                            rMov.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                            rMov.St_registro = "A";
                            //Gravar Movimentação
                            Almoxarifado.TCN_Movimentacao.Gravar(rMov, qtb_compra.Banco_Dados);
                            //Gravar almoxarifado X compra avulsa
                            TCN_CompraItens_X_Almox.Gravar(new TRegistro_CompraItens_X_Almox()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Id_compra = val.Id_compra,
                                Id_itemcompra = val.Id_itemcompra,
                                Cd_produto = val.Cd_produto,
                                Id_movimentostr = rMov.Id_movimentostr
                            }, qtb_compra.Banco_Dados);
                        }
                    }
                }
                //Amarrar item a Ordem servico
                val.lItemOs.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_compra = val.Id_compra;
                        p.Id_itemcompra = val.Id_itemcompra;
                        TCN_CompraItens_X_PecaOS.Gravar(p, qtb_compra.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return val.Id_itemcomprastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens compra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Compra_Itens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Compra_Itens qtb_compra = new TCD_Compra_Itens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                //Excluir alocacao do item a os
                val.lItemOs.ForEach(p => TCN_CompraItens_X_PecaOS.Excluir(p, qtb_compra.Banco_Dados));
                if (!string.IsNullOrEmpty(val.Cd_empresa) &&
                        val.Id_compra.HasValue &&
                        val.Id_itemcompra.HasValue)
                    if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_compra.Banco_Dados).ProdutoConsumoInterno(val.Cd_produto))
                        //Cancelar estoque
                        TCN_CompraItens_X_Estoque.Buscar(val.Cd_empresa,
                                                            val.Id_comprastr,
                                                            val.Id_itemcomprastr,
                                                            qtb_compra.Banco_Dados).ForEach(p =>
                                                                {
                                                                    Estoque.TCN_LanEstoque.CancelarEstoque(
                                                                        new CamadaDados.Estoque.TRegistro_LanEstoque()
                                                                        {
                                                                            Cd_empresa = p.Cd_empresa,
                                                                            Cd_produto = p.Cd_produto,
                                                                            Id_lanctoestoque = p.Id_lanctoestoque.Value
                                                                        }, qtb_compra.Banco_Dados);
                                                                    TCN_CompraItens_X_Estoque.Excluir(p, qtb_compra.Banco_Dados);
                                                                });
                    else
                        //Cancelar estoque
                        TCN_CompraItens_X_Almox.Buscar(val.Cd_empresa,
                                                         val.Id_comprastr,
                                                         val.Id_itemcomprastr,
                                                         qtb_compra.Banco_Dados).ForEach(p =>
                                                         {
                                                             Almoxarifado.TCN_Movimentacao.Cancelar(
                                                                 new CamadaDados.Almoxarifado.TRegistro_Movimentacao()
                                                                 {
                                                                     Cd_empresa = p.Cd_empresa,
                                                                     Cd_produto = p.Cd_produto,
                                                                     Id_movimento = p.Id_movimento
                                                                 }, qtb_compra.Banco_Dados);
                                                             TCN_CompraItens_X_Almox.Excluir(p, qtb_compra.Banco_Dados);
                                                         });
                qtb_compra.Excluir(val);
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return val.Id_itemcomprastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item compra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }
    }

    public class TCN_CompraItens_X_Estoque
    {
        public static TList_CompraItens_X_Estoque Buscar(string Cd_empresa,
                                                         string Id_compra,
                                                         string Id_itemcompra,
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
            if (!string.IsNullOrEmpty(Id_compra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_compra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_compra;
            }
            if (!string.IsNullOrEmpty(Id_itemcompra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_itemcompra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemcompra;
            }
            return new TCD_CompraItens_X_Estoque(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CompraItens_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraItens_X_Estoque qtb_compra = new TCD_CompraItens_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                string retorno = qtb_compra.Gravar(val);
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CompraItens_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraItens_X_Estoque qtb_compra = new TCD_CompraItens_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                qtb_compra.Excluir(val);
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }
    }

    public class TCN_CompraItens_X_Almox
    {
        public static TList_CompraItens_X_Almox Buscar(string Cd_empresa,
                                                         string Id_compra,
                                                         string Id_itemcompra,
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
            if (!string.IsNullOrEmpty(Id_compra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_compra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_compra;
            }
            if (!string.IsNullOrEmpty(Id_itemcompra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_itemcompra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemcompra;
            }
            return new TCD_CompraItens_X_Almox(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CompraItens_X_Almox val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraItens_X_Almox qtb_compra = new TCD_CompraItens_X_Almox();
            try
            {
                if (banco == null)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                string retorno = qtb_compra.Gravar(val);
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CompraItens_X_Almox val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraItens_X_Almox qtb_compra = new TCD_CompraItens_X_Almox();
            try
            {
                if (banco == null)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                qtb_compra.Excluir(val);
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }
    }

    public class TCN_CompraItens_X_PecaOS
    {
        public static TList_CompraItens_X_PecaOS Buscar(string Cd_empresa,
                                                        string Id_compra,
                                                        string Id_itemcompra,
                                                        BancoDados.TObjetoBanco banco,
                                                        string Id_Os = "",
                                                        string id_pecastr = "")
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_compra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_compra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_compra;
            }
            if (!string.IsNullOrEmpty(Id_itemcompra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_itemcompra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemcompra;
            }

            if (!string.IsNullOrEmpty(Id_Os))
                Utils.Estruturas.CriarParametro(ref filtro, "a.id_os", Id_Os);
            if (!string.IsNullOrEmpty(Id_Os))
                Utils.Estruturas.CriarParametro(ref filtro, "a.id_peca", id_pecastr);

            return new TCD_CompraItens_X_PecaOS(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CompraItens_X_PecaOS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraItens_X_PecaOS qtb_compra = new TCD_CompraItens_X_PecaOS();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                string retorno = qtb_compra.Gravar(val);
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CompraItens_X_PecaOS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraItens_X_PecaOS qtb_compra = new TCD_CompraItens_X_PecaOS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                qtb_compra.Excluir(val);
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }
    }

    public class TCN_CompraItens_X_PedidoItens
    {
        public static TList_CompraItens_X_PedidoItens Buscar(string Cd_empresa,
                                                             string Id_compra,
                                                             string Id_itemcompra,
                                                             string Nr_pedido,
                                                             string Cd_produto,
                                                             string Id_pedidoitem,
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
            if (!string.IsNullOrEmpty(Id_compra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_compra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_compra;
            }
            if (!string.IsNullOrEmpty(Id_itemcompra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_itemcompra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemcompra;
            }
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_pedidoitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pedidoitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pedidoitem;
            }

            return new TCD_CompraItens_X_PedidoItens(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CompraItens_X_PedidoItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraItens_X_PedidoItens qtb_compra = new TCD_CompraItens_X_PedidoItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                string retorno = qtb_compra.Gravar(val);
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CompraItens_X_PedidoItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraItens_X_PedidoItens qtb_compra = new TCD_CompraItens_X_PedidoItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_compra.CriarBanco_Dados(true);
                else
                    qtb_compra.Banco_Dados = banco;
                qtb_compra.Excluir(val);
                if (st_transacao)
                    qtb_compra.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compra.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_compra.deletarBanco_Dados();
            }
        }
    }
}
