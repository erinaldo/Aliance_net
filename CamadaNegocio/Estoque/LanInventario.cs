using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Utils;
using BancoDados;
using CamadaDados.Estoque;

namespace CamadaNegocio.Estoque
{
    public class TCN_LanInventario
    {
        public static Tlist_Inventario Busca(string vId_inventario,
                                             string vCd_empresa,
                                             string vSt_inventario,
                                             string vDt_ini,
                                             string vDt_fin,
                                             TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_inventario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Inventario";
                filtro[filtro.Length - 1].vVL_Busca = vId_inventario;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(vSt_inventario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_inventario, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + vSt_inventario.Trim() + ")";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_inventario";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_inventario";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }

            return new TCD_Inventario(banco).Select(filtro, 0, string.Empty);
        }

        public static System.Data.DataTable Busca(decimal vId_inventario)
        {
            if (vId_inventario > 0)
            {
                TpBusca[] filtro = new TpBusca[1];
                filtro[0].vNM_Campo = "a.ID_Inventario";
                filtro[0].vVL_Busca = vId_inventario.ToString();
                filtro[0].vOperador = "=";

                return new TCD_Inventario().BuscarRelItens(filtro);
            }
            else
                return null;
        }

        public static string GravarInventario(Tregistro_Inventario val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Inventario qtb_inventario = new TCD_Inventario();
            try
            {
                if (banco == null)
                    st_transacao = qtb_inventario.CriarBanco_Dados(true);
                else
                    qtb_inventario.Banco_Dados = banco;
                //Gravar Inventario
                val.Id_inventario = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_inventario.GravarInventario(val), "@P_ID_INVENTARIO"));
                //Excluir itens inventario
                val.lItensDel.ForEach(p => TCN_Inventario_Item.DeletarInventarioItem(p, qtb_inventario.Banco_Dados));
                //Gravar itens inventario
                val.lItensInventario.ForEach(p =>
                    {
                        p.Id_inventario = val.Id_inventario;
                        TCN_Inventario_Item.GravarInventarioItem(p, qtb_inventario.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_inventario.Banco_Dados.Commit_Tran();
                return val.Id_inventario.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_inventario.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar inventario: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_inventario.deletarBanco_Dados();
            }
        }

        public static string DeletarInventario(Tregistro_Inventario val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Inventario qtb_inventario = new TCD_Inventario();
            try
            {
                if (banco == null)
                    st_transacao = qtb_inventario.CriarBanco_Dados(true);
                else
                    qtb_inventario.Banco_Dados = banco;
                if (val.St_inventario.Trim().ToUpper().Equals("P"))
                    throw new Exception("Não é permitido excluir inventario PROCESSADO.");
                //A stored procedure ja ira excluir os itens e o saldo caso exista
                qtb_inventario.DeletarInvetario(val);
                if (st_transacao)
                    qtb_inventario.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_inventario.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir inventario: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_inventario.deletarBanco_Dados();
            }
        }

        public static void ProcessarInventario(Tregistro_Inventario val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Inventario_Item_X_Saldo qtb_saldo = new TCD_Inventario_Item_X_Saldo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_saldo.CriarBanco_Dados(true);
                else
                    qtb_saldo.Banco_Dados = banco;
                TList_Inventario_Item_X_Saldo lSaldo = TCN_Inventario_Item_X_Saldo.Buscar(val.Id_inventario.Value.ToString(),
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          qtb_saldo.Banco_Dados);
                lSaldo.ForEach(p =>
                {
                    //Para produtos derivados de consumo interno
                    //O sistema deve gerar lançamento no almoxarifado
                    if (p.Id_Almox != null)
                    {
                        if (p.Qtd_saldoAmx != p.Qtd_contada)
                        {
                            p.Qtd_saldo = p.Qtd_saldoAmx;
                            CamadaDados.Almoxarifado.TRegistro_Movimentacao _Movimentacao = new CamadaDados.Almoxarifado.TRegistro_Movimentacao();
                            _Movimentacao.Cd_empresa = p.Cd_empresa;
                            _Movimentacao.LoginAlmoxarife = Parametros.pubLogin;
                            _Movimentacao.Id_almoxstr = p.Id_Almox.ToString();
                            _Movimentacao.Cd_produto = p.Cd_produto;
                            _Movimentacao.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                            if (p.Qtd_saldoAmx < p.Qtd_contada)
                            {
                                _Movimentacao.Tp_movimento = "E";
                                _Movimentacao.Quantidade = p.Qtd_contada - p.Qtd_saldoAmx;
                                _Movimentacao.Vl_subtotal = p.Vl_unitario * (p.Qtd_contada - p.Qtd_saldoatual);
                                _Movimentacao.Ds_observacao = "ENTRADA DEVIDA AO INVENTÁRIO " + p.Id_inventario;
                            }
                            else
                            {
                                _Movimentacao.Tp_movimento = "S";
                                _Movimentacao.Quantidade = p.Qtd_saldoAmx - p.Qtd_contada;
                                _Movimentacao.Vl_subtotal = p.Vl_unitario * (p.Qtd_saldoatual - p.Qtd_contada);
                                _Movimentacao.Ds_observacao = "SAÍDA DEVIDA AO INVENTÁRIO " + p.Id_inventario;
                            }

                            _Movimentacao.Vl_unitario = p.Vl_unitario;

                            string retorno = CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(_Movimentacao, qtb_saldo.Banco_Dados);
                            //Gravar Inventario X Almoxarifado
                            TCN_Inventario_X_Estoque.GravarInventarioXEstoque(
                                new TRegistro_Inventario_X_Estoque()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Cd_produto = p.Cd_produto,
                                    Id_inventario = p.Id_inventario,
                                    Id_movimentoAlmox = Convert.ToDecimal(retorno),
                                    Id_registro = p.Id_registro
                                }, qtb_saldo.Banco_Dados);
                        }
                    }
                    else
                    {
                        if (p.Qtd_saldoatual != p.Qtd_contada)
                        {
                            //Gravar no estoque
                            TRegistro_LanEstoque regEstoque = new TRegistro_LanEstoque();
                            regEstoque.Cd_empresa = p.Cd_empresa;
                            regEstoque.Cd_produto = p.Cd_produto;
                            regEstoque.Cd_local = p.Cd_local;
                            regEstoque.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                            regEstoque.St_registro = "A";
                            regEstoque.Tp_lancto = "I";
                            if (p.Qtd_saldoatual < p.Qtd_contada)
                            {
                                regEstoque.Tp_movimento = "E";
                                regEstoque.Qtd_entrada = p.Qtd_contada - p.Qtd_saldoatual;
                                regEstoque.Vl_subtotal = p.Vl_unitario * (p.Qtd_contada - p.Qtd_saldoatual);
                            }
                            else
                            {
                                regEstoque.Tp_movimento = "S";
                                regEstoque.Qtd_saida = p.Qtd_saldoatual - p.Qtd_contada;
                                regEstoque.Vl_subtotal = p.Vl_unitario * (p.Qtd_saldoatual - p.Qtd_contada);
                            }
                            regEstoque.Vl_unitario = p.Vl_unitario;

                            string retorno = TCN_LanEstoque.GravarEstoque(regEstoque, qtb_saldo.Banco_Dados);
                            //Gravar Inventario X Estoque
                            TCN_Inventario_X_Estoque.GravarInventarioXEstoque(
                                new TRegistro_Inventario_X_Estoque()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Cd_produto = p.Cd_produto,
                                    Id_inventario = p.Id_inventario,
                                    Id_registro = p.Id_registro,
                                    Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@@P_ID_LANCTOESTOQUE"))
                                }, qtb_saldo.Banco_Dados);
                        }
                    }

                    if (p.Id_Almox == null && p.Qtd_saldoatual != p.Qtd_saldo)
                    {
                        p.Qtd_saldo = p.Qtd_saldoatual;
                        TCN_Inventario_Item_X_Saldo.GravarInventarioItemSaldo(p, qtb_saldo.Banco_Dados);
                    }
                    else
                        TCN_Inventario_Item_X_Saldo.GravarInventarioItemSaldo(p, qtb_saldo.Banco_Dados);
                });
                //Alterar Status do Inventario para Processado
                val.St_inventario = "P";
                GravarInventario(val, qtb_saldo.Banco_Dados);
                if (st_transacao)
                    qtb_saldo.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_saldo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar inventario: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_saldo.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Inventario_Item
    {
        public static TList_Inventario_Item Busca(string vId_Inventario,
                                                  string vCd_produto,
                                                  TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_Inventario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Inventario";
                filtro[filtro.Length - 1].vVL_Busca = vId_Inventario;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Produto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_Inventario_Item(banco).Select(filtro, 0, string.Empty);
        }

        public static string GravarInventarioItem(TRegistro_Inventario_Item val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Inventario_Item qtb_inventarioItem = new TCD_Inventario_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_inventarioItem.CriarBanco_Dados(true);
                else
                    qtb_inventarioItem.Banco_Dados = banco;

                string retorno = qtb_inventarioItem.GravarInventario_Item(val);
                if (st_transacao)
                    qtb_inventarioItem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_inventarioItem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_inventarioItem.deletarBanco_Dados();
            }
        }

        public static string DeletarInventarioItem(TRegistro_Inventario_Item val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Inventario_Item qtb_inventarioItem = new TCD_Inventario_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_inventarioItem.CriarBanco_Dados(true);
                else
                    qtb_inventarioItem.Banco_Dados = banco;

                qtb_inventarioItem.DeletarInventario_Item(val);
                if (st_transacao)
                    qtb_inventarioItem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_inventarioItem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_inventarioItem.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Inventario_Item_X_Saldo
    {
        public static TList_Inventario_Item_X_Saldo Buscar(string vId_inventario,
                                                           string vCd_produto,
                                                           string vCd_local,
                                                           string vId_almox,
                                                           TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_inventario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "x.ID_Inventario";
                filtro[filtro.Length - 1].vVL_Busca = vId_inventario;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "x.CD_Produto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_local))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Local";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_local.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if(!string.IsNullOrEmpty(vId_almox))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Almox";
                filtro[filtro.Length - 1].vVL_Busca = vId_almox;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new TCD_Inventario_Item_X_Saldo(banco).Select(filtro, 0, string.Empty);
        }

        public static System.Data.DataTable Buscar(decimal vId_inventario)
        {
            if (vId_inventario > 0)
            {
                TpBusca[] filtro = new TpBusca[1];
                filtro[0].vNM_Campo = "a.ID_Inventario";
                filtro[0].vVL_Busca = vId_inventario.ToString();
                filtro[0].vOperador = "=";
                return new TCD_Inventario_Item_X_Saldo().BuscarRelItensSaldo(filtro);
            }
            else
                return null;
        }

        public static string GravarInventarioItemSaldo(TRegistro_Inventario_Item_X_Saldo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Inventario_Item_X_Saldo qtb_saldo = new TCD_Inventario_Item_X_Saldo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_saldo.CriarBanco_Dados(true);
                else
                    qtb_saldo.Banco_Dados = banco;
                
                //Validar veracidade da informação cd. almoxarifado
                if (val.Id_Almox != null)
                {
                    TpBusca[] tpBuscas = new TpBusca[0];
                    Estruturas.CriarParametro(ref tpBuscas, "a.id_almox", "'" + val.Id_Almox + "'");
                    if (new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado().BuscarEscalar(tpBuscas, "1") == null)
                    {
                        throw new Exception("Código de almoxarifado informado não foi encontrado pré-cadastrado no sistema. " +
                            "Não será possível finalizar a operação.");
                    }
                }

                string retorno = qtb_saldo.GravarInventario_Item_X_Saldo(val);
                if (st_transacao)
                    qtb_saldo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_saldo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar saldo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_saldo.deletarBanco_Dados();
            }
        }

        public static string DeletarInventarioItemSaldo(TRegistro_Inventario_Item_X_Saldo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Inventario_Item_X_Saldo qtb_saldo = new TCD_Inventario_Item_X_Saldo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_saldo.CriarBanco_Dados(true);
                else
                    qtb_saldo.Banco_Dados = banco;

                //Excluir Inventario X Saldo
                qtb_saldo.DeletarInventario_Item_X_Saldo(val);
                if (st_transacao)
                    qtb_saldo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_saldo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir saldo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_saldo.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Inventario_X_Estoque
    {
        public static TList_Inventario_X_Estoque Buscar(decimal vId_inventario,
                                                        string vCd_produto,
                                                        string vCd_empresa,
                                                        decimal vId_lanctoestoque,
                                                        int vTop,
                                                        string vNm_campo)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vId_inventario > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Inventario";
                filtro[filtro.Length - 1].vVL_Busca = vId_inventario.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_produto.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Produto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_produto + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_empresa.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vId_lanctoestoque > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LanctoEstoque";
                filtro[filtro.Length - 1].vVL_Busca = vId_lanctoestoque.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new TCD_Inventario_X_Estoque().Select(filtro, vTop, vNm_campo);
        }

        public static string GravarInventarioXEstoque(TRegistro_Inventario_X_Estoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Inventario_X_Estoque qtb_inv = new TCD_Inventario_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_inv.CriarBanco_Dados(true);
                else
                    qtb_inv.Banco_Dados = banco;

                string retorno = qtb_inv.GravarInventarioEstoque(val);
                if (st_transacao)
                    qtb_inv.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_inv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_inv.deletarBanco_Dados();
            }
        }

        public static string DeletarInventarioXEstoque(TRegistro_Inventario_X_Estoque val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Inventario_X_Estoque qtb_inv = new TCD_Inventario_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_inv.CriarBanco_Dados(true);
                else
                    qtb_inv.Banco_Dados = banco;
                qtb_inv.DeletarInventarioEstoque(val);
                if (st_transacao)
                    qtb_inv.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_inv.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_inv.deletarBanco_Dados();
            }
        }
    }
}
