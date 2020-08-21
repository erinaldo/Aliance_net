using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Entrega;
using Utils;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.Entrega
{
    public class TCN_CargaAvulsa
    {
        public static TList_CargaAvulsa Buscar(string Cd_empresa,
                                                string Id_carga,
                                                string Cd_motorista,
                                                string Cd_produto,
                                                string Dt_ini,
                                                string Dt_fin,
                                                string St_registro,
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
            if (!string.IsNullOrEmpty(Id_carga))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_carga";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_carga;
            }
            if (!string.IsNullOrEmpty(Cd_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_motorista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_motorista.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_itenscarga x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.ID_Carga = a.ID_Carga " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Carga)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Carga)))";
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

            return new TCD_CargaAvulsa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CargaAvulsa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CargaAvulsa qtb_carga = new TCD_CargaAvulsa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carga.CriarBanco_Dados(true);
                else
                    qtb_carga.Banco_Dados = banco;
                val.Id_cargastr = CamadaDados.TDataQuery.getPubVariavel(qtb_carga.Gravar(val), "@P_ID_CARGA");
                //Buscar Local Arm
                object obj = new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa(qtb_carga.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        }
                    }, "a.CD_Local");
                if (obj == null)
                    throw new Exception("Não existe Local de armazenagem configurado para Empresa" + val.Cd_empresa.Trim() + "!");
                //Item Carga
                val.lItensDel.ForEach(p =>
                {
                    //Cancelar Estoque
                    new CamadaDados.Estoque.TCD_LanEstoque(qtb_carga.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_lanctoestoque",
                                vOperador = "=",
                                vVL_Busca = p.Id_lanctoEstoqueS.ToString()
                            }
                        }, 0, string.Empty, string.Empty, string.Empty).ForEach(x => Estoque.TCN_LanEstoque.CancelarEstoque(x, qtb_carga.Banco_Dados));
                    TCN_ItensCargaAvulsa.Excluir(p, qtb_carga.Banco_Dados);
                });
                val.lItens.FindAll(p=> p.Id_lanctoEstoqueS == null).ForEach(p =>
                {
                    //Buscar Vl.Médio
                    decimal vl_unit = Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(val.Cd_empresa,
                                                                                     p.Cd_produto,
                                                                                     qtb_carga.Banco_Dados);
                    //Gravar Estoque
                    string ret_est =
                       Estoque.TCN_LanEstoque.GravarEstoque(
                           new CamadaDados.Estoque.TRegistro_LanEstoque()
                           {
                               Cd_empresa = val.Cd_empresa,
                               Cd_produto = p.Cd_produto,
                               Cd_local = obj.ToString(),
                               Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                               Tp_movimento = "S",
                               Qtd_entrada = decimal.Zero,
                               Qtd_saida = p.Quantidade,
                               Vl_unitario = vl_unit,
                               Vl_subtotal = vl_unit * p.Quantidade,
                               Tp_lancto = "N",
                               St_registro = "A",
                               Ds_observacao = "SAÍDA DE PRODUTOS CARGA Nº " + val.Id_cargastr,
                           }, qtb_carga.Banco_Dados);
                    p.Id_lanctoEstoqueS = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_est, "@@P_ID_LANCTOESTOQUE"));
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_carga = val.Id_carga;
                    TCN_ItensCargaAvulsa.Gravar(p, qtb_carga.Banco_Dados);
                });
                if (st_transacao)
                    qtb_carga.Banco_Dados.Commit_Tran();
                return val.Id_cargastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carga.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Carga: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carga.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CargaAvulsa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CargaAvulsa qtb_carga = new TCD_CargaAvulsa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carga.CriarBanco_Dados(true);
                else
                    qtb_carga.Banco_Dados = banco;
                val.lItensDel.ForEach(p => TCN_ItensCargaAvulsa.Excluir(p, qtb_carga.Banco_Dados));
                val.lItens.ForEach(p =>
                {
                    //Cancelar Estoque - Saída
                    if(p.Id_lanctoEstoqueS.HasValue)
                        new CamadaDados.Estoque.TCD_LanEstoque(qtb_carga.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_lanctoestoque",
                                    vOperador = "=",
                                    vVL_Busca = p.Id_lanctoEstoqueS.ToString()
                                }
                            }, 0, string.Empty, string.Empty, string.Empty).ForEach(x => Estoque.TCN_LanEstoque.CancelarEstoque(x, qtb_carga.Banco_Dados));

                    //Cancelar Estoque - Devolução
                    if(p.Id_lanctoEstoqueD.HasValue)
                        new CamadaDados.Estoque.TCD_LanEstoque(qtb_carga.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_lanctoestoque",
                                    vOperador = "=",
                                    vVL_Busca = p.Id_lanctoEstoqueD.ToString()
                                }
                            }, 0, string.Empty, string.Empty, string.Empty).ForEach(x => Estoque.TCN_LanEstoque.CancelarEstoque(x, qtb_carga.Banco_Dados));
                    //Excluir Item
                    TCN_ItensCargaAvulsa.Excluir(p, qtb_carga.Banco_Dados);
                });
                qtb_carga.Excluir(val);
                if (st_transacao)
                    qtb_carga.Banco_Dados.Commit_Tran();
                return val.Id_cargastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carga.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Carga: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carga.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensCargaAvulsa
    {
        public static TList_ItensCargaAvulsa Buscar(string Cd_empresa,
                                                string Id_carga,
                                                string Id_item,
                                                string Cd_produto,
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
            if (!string.IsNullOrEmpty(Id_carga))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_carga";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_carga;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_ItensCargaAvulsa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensCargaAvulsa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCargaAvulsa qtb_carga = new TCD_ItensCargaAvulsa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carga.CriarBanco_Dados(true);
                else
                    qtb_carga.Banco_Dados = banco;
                val.Id_itemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_carga.Gravar(val), "@P_ID_ITEM");
                if (st_transacao)
                    qtb_carga.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carga.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens Carga: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carga.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensCargaAvulsa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCargaAvulsa qtb_carga = new TCD_ItensCargaAvulsa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carga.CriarBanco_Dados(true);
                else
                    qtb_carga.Banco_Dados = banco;
                if (new CamadaDados.Locacao.TCD_AbastItens(qtb_carga.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa + "'" },
                        new TpBusca { vNM_Campo = "a.id_carga", vOperador = "=", vVL_Busca = val.Id_cargastr },
                        new TpBusca { vNM_Campo = "a.id_itemcarga", vOperador = "=", vVL_Busca = val.Id_itemstr }
                    }, "1") != null)
                    throw new Exception("Não é possível excluir uma carga avulsa que contenha produtos relacionados com abastecimento de patrimônio."+
                        " Produto em questão: "+val.Cd_produto+".");
                qtb_carga.Excluir(val);
                if (st_transacao)
                    qtb_carga.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carga.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item Carga: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carga.deletarBanco_Dados();
            }
        }

        public static string DevCarga(List<TRegistro_ItensCargaAvulsa> lista, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCargaAvulsa qtb_carga = new TCD_ItensCargaAvulsa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carga.CriarBanco_Dados(true);
                else
                    qtb_carga.Banco_Dados = banco;
                //Buscar Local Arm
                object obj = new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa(qtb_carga.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + lista[0].Cd_empresa.Trim() + "'"
                        }
                    }, "a.CD_Local");
                if (obj == null)
                    throw new Exception("Não existe Local de armazenagem configurado para Empresa" + lista[0].Cd_empresa.Trim() + "!");
                lista.ForEach(p =>
                {
                    decimal vl_unit = decimal.Zero;
                    //Buscar Vl.Unitário origem da saida
                    object OBJvl_unit = new CamadaDados.Estoque.TCD_LanEstoque(qtb_carga.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.Id_LanctoEstoque",
                                    vOperador = "=",
                                    vVL_Busca = p.Id_lanctoEstoqueS.ToString()
                                }
                        }, "a.vl_unitario");
                    if (OBJvl_unit == null ? false : !string.IsNullOrEmpty(OBJvl_unit.ToString()))
                        vl_unit = decimal.Parse(OBJvl_unit.ToString());
                    else
                        vl_unit = Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(p.Cd_empresa, p.Cd_produto, qtb_carga.Banco_Dados);
                    if (p.Qtd_devolvida > decimal.Zero)
                    {
                        //Cancelar Estoque - Devolução
                        if (p.Id_lanctoEstoqueD != null)
                            new CamadaDados.Estoque.TCD_LanEstoque(qtb_carga.Banco_Dados).Select(
                                new TpBusca[]
                                {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_lanctoestoque",
                                vOperador = "=",
                                vVL_Busca = p.Id_lanctoEstoqueD.ToString()
                            }
                        }, 0, string.Empty, string.Empty, string.Empty).ForEach(x => Estoque.TCN_LanEstoque.CancelarEstoque(x, qtb_carga.Banco_Dados));
                        //Gravar Estoque
                        string ret_est =
                           Estoque.TCN_LanEstoque.GravarEstoque(
                               new CamadaDados.Estoque.TRegistro_LanEstoque()
                               {
                                   Cd_empresa = p.Cd_empresa,
                                   Cd_produto = p.Cd_produto,
                                   Cd_local = obj.ToString(),
                                   Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                   Tp_movimento = "E",
                                   Qtd_entrada = p.Qtd_devolvida,
                                   Qtd_saida = decimal.Zero,
                                   Vl_unitario = vl_unit,
                                   Vl_subtotal = vl_unit * p.Quantidade,
                                   Tp_lancto = "N",
                                   St_registro = "A",
                                   Ds_observacao = "DEVOLUÇÃO DE PRODUTOS CARGA Nº " + p.Id_cargastr,
                               }, qtb_carga.Banco_Dados);
                        p.Id_lanctoEstoqueD = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_est, "@@P_ID_LANCTOESTOQUE"));
                        p.Cd_empresa = p.Cd_empresa;
                        p.Id_carga = p.Id_carga;
                        Gravar(p, qtb_carga.Banco_Dados);
                    }
                });
                if (st_transacao)
                    qtb_carga.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carga.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens Carga: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carga.deletarBanco_Dados();
            }
        }

        public static string RetornoCarga(List<TRegistro_ItensCargaAvulsa> lista, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCargaAvulsa qtb_carga = new TCD_ItensCargaAvulsa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carga.CriarBanco_Dados(true);
                else
                    qtb_carga.Banco_Dados = banco;
                //Buscar Local Arm
                object obj = new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa(qtb_carga.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + lista[0].Cd_empresa.Trim() + "'"
                        }
                    }, "a.CD_Local");
                if (obj == null)
                    throw new Exception("Não existe Local de armazenagem configurado para Empresa" + lista[0].Cd_empresa.Trim() + "!");
                lista.ForEach(p =>
                {
                    decimal vl_unit = decimal.Zero;
                    //Buscar Vl.Unitário origem da saida
                    object OBJvl_unit = new CamadaDados.Estoque.TCD_LanEstoque(qtb_carga.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.Id_LanctoEstoque",
                                    vOperador = "=",
                                    vVL_Busca = p.Id_lanctoEstoqueS.ToString()
                                }
                        }, "a.vl_unitario");
                    if (OBJvl_unit == null ? false : !string.IsNullOrEmpty(OBJvl_unit.ToString()))
                        vl_unit = decimal.Parse(OBJvl_unit.ToString());
                    else
                        vl_unit = Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(p.Cd_empresa, p.Cd_produto, qtb_carga.Banco_Dados);
                    p.lItensLocTerceiro.FindAll(x=> x.Qtd_consumo > decimal.Zero).ForEach(x =>
                    {
                        CamadaNegocio.Locacao.TCN_AbastItens.Gravar(
                            new CamadaDados.Locacao.TRegistro_AbastItens()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Id_loc = x.Id_loc,
                                Id_item = x.Id_item,
                                Id_carga = p.Id_carga,
                                Id_itemcarga = p.Id_item,
                                Dt_abast = CamadaDados.UtilData.Data_Servidor(),
                                Quantidade = x.Qtd_consumo,
                                Vl_unitCusto = vl_unit
                            }, qtb_carga.Banco_Dados);
                    });
                });
                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                hs.Add("@CD_EMPRESA", lista[0].Cd_empresa);
                hs.Add("@ID_CARGA", lista[0].Id_carga);
                qtb_carga.executarSql("update TB_FAT_CargaAvulsa set ST_Registro = 'E' " +
                                      "where CD_Empresa = @CD_EMPRESA " +
                                      "and ID_Carga = @ID_CARGA ", hs);
                if (st_transacao)
                    qtb_carga.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carga.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens Carga: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carga.deletarBanco_Dados();
            }
        }
    }
}
