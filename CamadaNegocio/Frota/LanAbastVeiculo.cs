using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.CCustoLan;

namespace CamadaNegocio.Frota
{
    public class TCN_Abast_X_Duplicata
    {
        public static TList_Abast_X_Duplicata Buscar(string Id_abastecimento,
                                                     string Cd_empresa,
                                                     string Nr_lancto,
                                                     BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_abastecimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_abastecimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_abastecimento;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            return new TCD_Abast_X_Duplicata(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDup(string Id_abastecimento,
                                                                                       BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_frt_abast_x_duplicata x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and x.id_abastecimento = " + Id_abastecimento + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Abast_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Abast_X_Duplicata qtb_abast = new TCD_Abast_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else
                    qtb_abast.Banco_Dados = banco;
                string retorno = qtb_abast.Gravar(val);
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Abast_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Abast_X_Duplicata qtb_abast = new TCD_Abast_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else
                    qtb_abast.Banco_Dados = banco;
                qtb_abast.Excluir(val);
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AbastVeiculo
    {
        public static TList_AbastVeiculo Buscar(string Id_abastecimento,
                                                string Cd_empresa,
                                                string Id_viagem,
                                                string Id_veiculo,
                                                string Placa,
                                                string Id_despesa,
                                                string Tp_data,
                                                string Dt_ini,
                                                string Dt_fin,
                                                string Tp_abastecimento,
                                                string Tp_pagamento,
                                                string Tp_registro,
                                                string vNr_NotaFiscal,
                                                string Nr_docagrupador,
                                                int vTop,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_abastecimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_abastecimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_abastecimento;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_veiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_veiculo;
            }
            if (!string.IsNullOrEmpty(Placa.Replace("-", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "REPLACE(d.placa, '-', '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placa.Replace("-", string.Empty).Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_despesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_despesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_despesa;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (Tp_data.Trim().Equals("R") ? "a.dt_requisicao" : "a.dt_abastecimento") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (Tp_data.Trim().Equals("R") ? "a.dt_requisicao" : "a.dt_abastecimento") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Tp_abastecimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_abastecimento";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_abastecimento.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Tp_pagamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pagamento";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_pagamento.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Tp_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_registro.Trim() + ")";
            }
            if(!string.IsNullOrWhiteSpace(vNr_NotaFiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_NotaFiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_NotaFiscal.Trim() + "'";
            }
            if(!string.IsNullOrWhiteSpace(Nr_docagrupador))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_frt_abast_x_duplicata x " +
                                                      "inner join tb_fin_duplicata y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lancto = y.nr_lancto " +
                                                      "and isnull(y.st_registro, 'A') <> 'C' " +
                                                      "and y.nr_docto = '" + Nr_docagrupador.Trim() + "' " +
                                                      "and x.id_abastecimento = a.id_abastecimento)";
            }
            return new TCD_AbastVeiculo(banco).Select(filtro, vTop, string.Empty);
        }

        public static string Gravar(TRegistro_AbastVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastVeiculo qtb_abast = new TCD_AbastVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else
                    qtb_abast.Banco_Dados = banco;
                if (val.Tp_abastecimento.Trim().ToUpper().Equals("P") &&
                    val.Tp_registro.Trim().ToUpper().Equals("A") &&
                    (!val.Id_lanctoestoque.HasValue))
                {
                    //Buscar local armazenagem
                    object obj = new CamadaDados.Frota.Cadastros.TCD_CfgFrota(qtb_abast.Banco_Dados).BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        }
                                    }, "a.cd_local");
                    if (obj == null)
                        throw new Exception("Não existe local armazenagem configurado para empresa " + val.Cd_empresa.Trim());
                    //Baixar estoque
                    string ret_est =
                    CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(
                        new CamadaDados.Estoque.TRegistro_LanEstoque()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_produto = val.Cd_produto,
                            Cd_local = obj.ToString(),
                            Dt_lancto = val.Dt_abastecimento,
                            Tp_movimento = "S",
                            Qtd_entrada = decimal.Zero,
                            Qtd_saida = val.Volume,
                            Vl_unitario = val.Vl_unitario,
                            Vl_subtotal = val.Vl_subtotal,
                            Tp_lancto = "N",
                            St_registro = "A",
                            Ds_observacao = "BAIXA ABASTECIMENTO INTERNO"
                        }, qtb_abast.Banco_Dados);
                    //baixa estoque no abastecimento
                    val.Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_est, "@@P_ID_LANCTOESTOQUE"));
                }
                val.Id_abastecimentostr = CamadaDados.TDataQuery.getPubVariavel(qtb_abast.Gravar(val), "@P_ID_ABASTECIMENTO");
                if (val.rAbast != null)
                {
                    val.rAbast.Id_abastecimento = val.Id_abastecimento;
                    TCN_Abastecidas.Gravar(val.rAbast, qtb_abast.Banco_Dados);
                }
                if (val.rDup != null)
                {
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDup, false, qtb_abast.Banco_Dados);
                    //Gravar Abast X Duplicata
                    TCN_Abast_X_Duplicata.Gravar(new TRegistro_Abast_X_Duplicata()
                    {
                        Id_abastecimento = val.Id_abastecimento,
                        Cd_empresa = val.rDup.Cd_empresa,
                        Nr_lancto = val.rDup.Nr_lancto
                    }, qtb_abast.Banco_Dados);
                }
                if(val.lCCusto != null)
                    val.lCCusto.ForEach(p =>
                        {
                            p.Cd_empresa = val.Cd_empresa;
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(p, qtb_abast.Banco_Dados);
                            TCN_AbastFrota_X_CCusto.Gravar(new TRegistro_AbastFrota_X_CCusto()
                            {
                                Id_abastecimento = val.Id_abastecimento,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_abast.Banco_Dados);
                        });
                //Gravar configuracao produto x fornecedor
                if (val.rProdForn != null)
                    CamadaNegocio.Estoque.Cadastros.TCN_Produto_X_Fornecedor.Gravar(
                        new CamadaDados.Estoque.Cadastros.TRegistro_Produto_X_Fornecedor()
                        {
                            Cd_fornecedor = val.Cd_fornecedor,
                            Cd_produto = val.Cd_produto,
                            Cd_unidade_fornec = val.rProdForn.Cd_unidade_fornec,
                            Codigo_fornecedor = val.rProdForn.Cd_produto_xml,
                        }, qtb_abast.Banco_Dados);
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
                return val.Id_abastecimentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar abastecimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }

        public static void Gravar(List<TRegistro_AbastVeiculo> lista, 
                                  CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup,
                                  BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastVeiculo qtb_abast = new TCD_AbastVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else
                    qtb_abast.Banco_Dados = banco;
                //Gravar duplicata
                if(rDup != null)
                    TCN_LanDuplicata.GravarDuplicata(rDup, false, qtb_abast.Banco_Dados);
                //Gravar abastecidas
                lista.ForEach(x =>
                {
                    Gravar(x, qtb_abast.Banco_Dados);
                    //Amarrar abast x duplicata
                    if(x.Tp_pagamento.Trim().ToUpper().Equals("E"))
                        TCN_Abast_X_Duplicata.Gravar(new TRegistro_Abast_X_Duplicata
                            {
                                Id_abastecimento = x.Id_abastecimento,
                                Cd_empresa = rDup.Cd_empresa,
                                Nr_lancto = rDup.Nr_lancto
                            }, qtb_abast.Banco_Dados);
                });
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar abastecimentos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AbastVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastVeiculo qtb_abast = new TCD_AbastVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else
                    qtb_abast.Banco_Dados = banco;
                //Verificar se abastecimento esta amarrado a abastecida
                TCN_Abastecidas.Buscar(string.Empty, string.Empty, val.Id_abastecimentostr, qtb_abast.Banco_Dados).ForEach(p =>
                    {
                        p.Id_abastecimento = null;
                        TCN_Abastecidas.Gravar(p, qtb_abast.Banco_Dados);
                    });
                //Verificar se abastecimento esta amarrado a financeiro
                TCN_Abast_X_Duplicata.BuscarDup(val.Id_abastecimentostr, qtb_abast.Banco_Dados).ForEach(p =>
                    {
                        //Excluir abast x duplicata
                        TCN_Abast_X_Duplicata.Excluir(new TRegistro_Abast_X_Duplicata()
                        {
                            Id_abastecimento = val.Id_abastecimento,
                            Cd_empresa = p.Cd_empresa,
                            Nr_lancto = p.Nr_lancto
                        }, qtb_abast.Banco_Dados);
                        //Cancelar duplicata
                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(p, qtb_abast.Banco_Dados);
                    });
                TCN_AbastFrota_X_CCusto.Buscar(val.Id_abastecimentostr,
                                               string.Empty,
                                               qtb_abast.Banco_Dados).ForEach(p =>
                                                   {
                                                       TCN_AbastFrota_X_CCusto.Excluir(p, qtb_abast.Banco_Dados);
                                                       CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(
                                                           new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                           {
                                                               Id_ccustolan = p.Id_ccustolan
                                                           }, qtb_abast.Banco_Dados);
                                                   });
                //Excluir abastecimento
                qtb_abast.Excluir(val);
                //Cancelar estoque abastecimento proprio
                if (val.Id_lanctoestoque.HasValue)
                    CamadaNegocio.Estoque.TCN_LanEstoque.DeletarEstoque(
                        new CamadaDados.Estoque.TRegistro_LanEstoque()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_produto = val.Cd_produto,
                            Id_lanctoestoque = val.Id_lanctoestoque.Value
                        }, qtb_abast.Banco_Dados);
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
                return val.Id_abastecimentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir abastecimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }

        public static void Excluir(TList_AbastVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastVeiculo qtb_abast = new TCD_AbastVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else
                    qtb_abast.Banco_Dados = banco;
                CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
                val.ForEach(x =>
                {
                    TCN_Abast_X_Duplicata.BuscarDup(x.Id_abastecimentostr, qtb_abast.Banco_Dados)
                    .ForEach(y =>
                    {
                        //Excluir abast x duplicata
                        TCN_Abast_X_Duplicata.Excluir(new TRegistro_Abast_X_Duplicata()
                        {
                            Id_abastecimento = x.Id_abastecimento,
                            Cd_empresa = y.Cd_empresa,
                            Nr_lancto = y.Nr_lancto
                        }, qtb_abast.Banco_Dados);
                        if (!lDup.Exists(w => w.Cd_empresa.Trim().Equals(y.Cd_empresa.Trim()) && w.Nr_lancto.Equals(y.Nr_lancto)))
                            lDup.Add(y);
                    });
                    qtb_abast.Excluir(x);
                });
                lDup.ForEach(z => TCN_LanDuplicata.CancelarDuplicata(z, qtb_abast.Banco_Dados));
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir abastecimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AbastFrota_X_CCusto
    {
        public static TList_AbastFrota_X_CCusto Buscar(string Id_abastecimento,
                                                       string Id_ccustolan,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_abastecimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_abastecimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_abastecimento;
            }
            if (!string.IsNullOrEmpty(Id_ccustolan))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ccustolan";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ccustolan;
            }
            return new TCD_AbastFrota_X_CCusto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AbastFrota_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastFrota_X_CCusto qtb_custo = new TCD_AbastFrota_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else qtb_custo.Banco_Dados = banco;
                string retorno = qtb_custo.Gravar(val);
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AbastFrota_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastFrota_X_CCusto qtb_custo = new TCD_AbastFrota_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else qtb_custo.Banco_Dados = banco;
                qtb_custo.Excluir(val);
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }

        public static void ProcessarAbasCResultado(List<TRegistro_AbastVeiculo> lAbast,
                                                   string CD_CentroResult,
                                                   BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastFrota_X_CCusto qtb_desp = new TCD_AbastFrota_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                if (string.IsNullOrEmpty(CD_CentroResult))
                    throw new Exception("Obrigatório informar centro de resultado.");
                lAbast.ForEach(p =>
                {
                    //Verificar se despesa possui centro de resultado
                    TCN_AbastFrota_X_CCusto.Buscar(p.Id_abastecimentostr,
                                                   string.Empty,
                                                   qtb_desp.Banco_Dados).ForEach(v =>
                                                   {
                                                       TCN_AbastFrota_X_CCusto.Excluir(v, qtb_desp.Banco_Dados);
                                                       CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(
                                                           new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                           {
                                                               Id_ccustolan = v.Id_ccustolan
                                                           }, qtb_desp.Banco_Dados);
                                                   });
                    //Gravar Lancto Resultado
                    string id = CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                        new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Cd_centroresult = CD_CentroResult,
                            Vl_lancto = p.Vl_subtotal,
                            Dt_lancto = p.Dt_abastecimento
                        }, qtb_desp.Banco_Dados);
                    //Amarrar Lancto a Caixa
                    Gravar(new TRegistro_AbastFrota_X_CCusto()
                    {
                        Id_abastecimento = p.Id_abastecimento,
                        Id_ccustolan = decimal.Parse(id)
                    }, qtb_desp.Banco_Dados);
                });
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar abastecimentos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }
}
