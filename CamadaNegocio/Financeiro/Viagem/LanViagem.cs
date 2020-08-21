using System;
using System.Collections.Generic;
using CamadaDados.Financeiro.Viagem;
using Utils;

namespace CamadaNegocio.Financeiro.Viagem
{
    public class TCN_Viagem
    {
        public static TList_Viagem Buscar(string Id_viagem,
                                          string Cd_empresa,
                                          string Cd_funcionario,
                                          string vTp_data,
                                          string vDt_ini,
                                          string vDt_fin,
                                          string NR_NotaFiscal,
                                          string NM_Fornecedor,
                                          string Cd_cliente,
                                          string St_registro,
                                          BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_funcionario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_funcionario";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_funcionario.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("F") ? "a.dt_fin" : "a.dt_ini") + ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("F") ? "a.dt_fin" : "a.dt_ini") + ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.St_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(NR_NotaFiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "";
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FIN_DespesasViagem x " +
                                                      "where x.CD_Empresa = a.CD_Empresa " +
                                                      "and x.ID_Viagem = a.ID_Viagem " +
                                                      "and x.NR_NotaFiscal = '" + NR_NotaFiscal + "')";
            }
            if (!string.IsNullOrEmpty(NM_Fornecedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "";
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FIN_DespesasViagem x " +
                                                      "where x.CD_Empresa = a.CD_Empresa " +
                                                      "and x.ID_Viagem = a.ID_Viagem " +
                                                      "and x.NM_Fornecedor like '%" + NM_Fornecedor + "%')";
            }
            if(!string.IsNullOrEmpty(Cd_cliente))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "";
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FIN_DespesasViagem x " +
                                                      "where x.CD_Empresa = a.CD_Empresa " +
                                                      "and x.ID_Viagem = a.ID_Viagem " +
                                                      "and x.cd_cliente = '" + Cd_cliente.Trim() + "')";
            }
            return new TCD_Viagem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Viagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem qtb_viagem = new TCD_Viagem();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_viagem.CriarBanco_Dados(true);
                else
                    qtb_viagem.Banco_Dados = banco;
                val.Id_viagemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_viagem.Gravar(val), "@P_ID_VIAGEM");
                //Excluir
                val.lDespesasDel.ForEach(p => TCN_DespesasViagem.Excluir(p, qtb_viagem.Banco_Dados));
                //Despesas
                val.lDespesas.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_viagem = val.Id_viagem;
                    TCN_DespesasViagem.Gravar(p, qtb_viagem.Banco_Dados);
                });
                if (st_transacao)
                    qtb_viagem.Banco_Dados.Commit_Tran();
                return val.Id_viagemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_viagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_viagem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Viagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem qtb_viagem = new TCD_Viagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_viagem.CriarBanco_Dados(true);
                else
                    qtb_viagem.Banco_Dados = banco;
                //Excluir despesas
                val.lDespesas.ForEach(p => TCN_DespesasViagem.Excluir(p, qtb_viagem.Banco_Dados));
                qtb_viagem.Excluir(val);
                if (st_transacao)
                    qtb_viagem.Banco_Dados.Commit_Tran();
                return val.Id_viagemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_viagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Viagem " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_viagem.deletarBanco_Dados();
            }
        }

        public static void IncluirAdiantamento(TRegistro_Viagem val,
                                               CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rAdto,
                                               BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem qtb_viagem = new TCD_Viagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_viagem.CriarBanco_Dados(true);
                else
                    qtb_viagem.Banco_Dados = banco;
                //Gravar Adiantamento
                CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(rAdto, qtb_viagem.Banco_Dados);
                //Gravar Viagem X Adiantamento
                TCN_AdtoViagem.Gravar(new TRegistro_AdtoViagem()
                {
                    Cd_empresa = val.Cd_empresa,
                    Id_viagem = val.Id_viagem,
                    Id_adto = rAdto.Id_adto
                }, qtb_viagem.Banco_Dados);
                if (st_transacao)
                    qtb_viagem.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_viagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro incluir adiantamento viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_viagem.deletarBanco_Dados();
            }
        }
        public static void AcertoViagem(List<TRegistro_Viagem> lista,
                                  BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem qtb_viagem = new TCD_Viagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_viagem.CriarBanco_Dados(true);
                else
                    qtb_viagem.Banco_Dados = banco;
                //Lista Viagens
                lista.ForEach(p =>
                {
                    //Gravar Duplicata
                    if (p.rDup != null)
                    {
                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(p.rDup, false, qtb_viagem.Banco_Dados);
                        p.Nr_lancto = p.rDup.Nr_lancto;
                    }
                    //Gravar Despesas
                    if (p.rCaixa != null)
                    {
                        CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(p.rCaixa, qtb_viagem.Banco_Dados);
                        p.Cd_contager = p.rCaixa.Cd_ContaGer;
                        p.Cd_lanctocaixa = p.rCaixa.Cd_LanctoCaixa;

                        //Buscar Adto com saldo a Devolver do Funcionário
                        CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lAdto =
                            new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento(qtb_viagem.Banco_Dados).Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.vl_pagar, 0) - isnull(a.vl_receber, 0)",
                                            vOperador = ">",
                                            vVL_Busca = "0"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.Tp_movimento",
                                            vOperador = "=",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.Cd_funcionario.Trim() + "'"
                                        }
                                    }, 0, string.Empty);
                        //Devolucao credito
                        decimal vl_devolver = decimal.Zero;
                        decimal saldo = p.Vl_despesas;
                        lAdto.FindAll(x => x.Vl_total_devolver > 0).ForEach(x =>
                         {
                             if (saldo > 0)
                             {
                                 vl_devolver = saldo > x.Vl_total_devolver ? x.Vl_total_devolver : saldo;
                                 x.Cd_contagerDev = p.rCaixa.Cd_ContaGer;
                                 x.Vl_devolver = vl_devolver;
                                 CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.DevolverAdto(x, qtb_viagem.Banco_Dados);
                                 saldo = saldo - x.Vl_total_devolver;
                                 TCN_Viagem_X_DevCred.Gravar(
                                     new TRegistro_Viagem_X_DevCred()
                                     {
                                         Cd_empresa = p.Cd_empresa,
                                         Id_viagem = p.Id_viagem,
                                         Id_adto = x.Id_adto,
                                         Cd_contager = p.rCaixa.Cd_ContaGer,
                                         Cd_lanctocaixa = x.Cd_lanctoCaixaDev
                                     }, qtb_viagem.Banco_Dados);
                             }
                         });
                    }
                    p.Dt_acerto = CamadaDados.UtilData.Data_Servidor();
                    p.St_registro = "P";
                    TCN_Viagem.Gravar(p, qtb_viagem.Banco_Dados);
                });
                if (st_transacao)
                    qtb_viagem.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_viagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar acerto viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_viagem.deletarBanco_Dados();
            }
        }

        public static void EstornoViagem(TRegistro_Viagem val,
                                 BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem qtb_viagem = new TCD_Viagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_viagem.CriarBanco_Dados(true);
                else
                    qtb_viagem.Banco_Dados = banco;
                //Buscar Lançamento de caixa
                new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(qtb_viagem.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.CD_ContaGer",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_contager.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.CD_LanctoCaixa",
                            vOperador = "=",
                            vVL_Busca = val.Cd_lanctocaixa.ToString()
                        }
                    }, 1, string.Empty).ForEach(p => Caixa.TCN_LanCaixa.EstornarCaixa(p, null, qtb_viagem.Banco_Dados));
                //Buscar Lançamento de caixa Viagem_X_DevCred 
                new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(qtb_viagem.Banco_Dados).Select(
                   new TpBusca[]
                   {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_FIN_Viagem_X_DevCred x " +
                                        "where x.CD_ContaGer = a.CD_ContaGer " +
                                        "and x.CD_LanctoCaixa = a.CD_LanctoCaixa " +
                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                        "and x.id_viagem = " + val.Id_viagemstr + ") "
                        }
                   }, 0, string.Empty).ForEach(p => Caixa.TCN_LanCaixa.EstornarCaixa(p, null, qtb_viagem.Banco_Dados));
                //Buscar Viagem X DevCred
                TCN_Viagem_X_DevCred.Buscar(string.Empty,
                                            val.Id_viagemstr,
                                            val.Cd_empresa,
                                            string.Empty,
                                            string.Empty,
                                            qtb_viagem.Banco_Dados).ForEach(p => TCN_Viagem_X_DevCred.Excluir(p, qtb_viagem.Banco_Dados));
                if (val.Nr_lancto != null)
                {
                    //Buscar Duplicata a pagar funcionario
                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(qtb_viagem.Banco_Dados).Select(
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
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = val.Nr_lancto.ToString()
                            }
                        }, 0, string.Empty).ForEach(p => CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(p, qtb_viagem.Banco_Dados));
                }
                val.Dt_acerto = null;
                val.St_registro = "A";
                val.Cd_contager = string.Empty;
                val.Cd_lanctocaixa = null;
                //Gravar Viagem
                qtb_viagem.Gravar(val);
                if (st_transacao)
                    qtb_viagem.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_viagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar acerto viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_viagem.deletarBanco_Dados();
            }
        }
    }

    public class TCN_DespesasViagem
    {
        public static TList_DespesasViagem Buscar(string Id_viagem,
                                                  string Cd_empresa,
                                                  string Id_despesa,
                                                  string Dt_ini,
                                                  string Dt_fin,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
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
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_despesa)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_despesa)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            return new TCD_DespesasViagem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DespesasViagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DespesasViagem qtb_des = new TCD_DespesasViagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_des.CriarBanco_Dados(true);
                else
                    qtb_des.Banco_Dados = banco;
                val.Id_despesastr = CamadaDados.TDataQuery.getPubVariavel(qtb_des.Gravar(val), "@P_ID_DESPESA");
                if (val.rDup != null)
                {
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDup, false, qtb_des.Banco_Dados);
                    //Gravar Despesas X Duplicata
                    TCN_Despesa_X_Duplicata.Gravar(new TRegistro_Despesa_X_Duplicata()
                    {
                        Id_despesa = val.Id_despesa,
                        Cd_empresa = val.Cd_empresa,
                        Nr_lancto = val.rDup.Nr_lancto,
                        Id_viagem = val.Id_viagem
                    }, qtb_des.Banco_Dados);
                }
                //Gravar Viagem x CCusto
                if (val.lCCusto != null)
                    val.lCCusto.ForEach(x =>
                    {
                        x.Cd_empresa = val.Cd_empresa;
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(x, qtb_des.Banco_Dados);
                        TCN_Viagem_X_CCusto.Gravar(new TRegistro_Viagem_X_CCusto()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_despesa = val.Id_despesa,
                            Id_ccustolan = x.Id_ccustolan,
                            Id_viagem = val.Id_viagem
                        }, qtb_des.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_des.Banco_Dados.Commit_Tran();
                return val.Id_despesastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_des.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar despesa viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_des.deletarBanco_Dados();
            }
        }

        public static string Alterar(TRegistro_DespesasViagem val, bool st_alteravalor, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DespesasViagem qtb_des = new TCD_DespesasViagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_des.CriarBanco_Dados(true);
                else
                    qtb_des.Banco_Dados = banco;
                if (st_alteravalor)
                    ExcluirDupCentroCCusto(val, qtb_des.Banco_Dados);
                val.Id_despesastr = CamadaDados.TDataQuery.getPubVariavel(qtb_des.Gravar(val), "@P_ID_DESPESA");
                if (val.rDup != null)
                {
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDup, false, qtb_des.Banco_Dados);
                    //Gravar Despesas X Duplicata
                    TCN_Despesa_X_Duplicata.Gravar(new TRegistro_Despesa_X_Duplicata()
                    {
                        Id_despesa = val.Id_despesa,
                        Cd_empresa = val.Cd_empresa,
                        Nr_lancto = val.rDup.Nr_lancto,
                        Id_viagem = val.Id_viagem
                    }, qtb_des.Banco_Dados);
                }
                //Gravar Viagem x CCusto
                if (val.lCCusto != null)
                    val.lCCusto.ForEach(x =>
                    {
                        x.Cd_empresa = val.Cd_empresa;
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(x, qtb_des.Banco_Dados);
                        TCN_Viagem_X_CCusto.Gravar(new TRegistro_Viagem_X_CCusto()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_despesa = val.Id_despesa,
                            Id_ccustolan = x.Id_ccustolan,
                            Id_viagem = val.Id_viagem
                        }, qtb_des.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_des.Banco_Dados.Commit_Tran();
                return val.Id_despesastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_des.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar despesa viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_des.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DespesasViagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DespesasViagem qtb_desp = new TCD_DespesasViagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else
                    qtb_desp.Banco_Dados = banco;
                ExcluirDupCentroCCusto(val, qtb_desp.Banco_Dados);
                qtb_desp.Excluir(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return val.Id_despesastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir despesa viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }

        public static string ExcluirDupCentroCCusto(TRegistro_DespesasViagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DespesasViagem qtb_desp = new TCD_DespesasViagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else
                    qtb_desp.Banco_Dados = banco;
                //Buscar Centro de Custo
                CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCCusto =
                    new CamadaDados.Financeiro.CCustoLan.TCD_LanCCustoLancto(qtb_desp.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FIN_Viagem_X_CCusto x " +
                                            "where a.Id_CCustoLan = x.Id_CCustoLan " +
                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                            "and x.ID_Viagem = " + val.Id_viagemstr + " " +
                                            "and x.ID_Despesa =  " + val.Id_despesastr + ") "
                            }
                        }, 0, string.Empty);
                //Cancelar Duplicatas
                CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                CamadaNegocio.Financeiro.Viagem.TCN_Despesa_X_Duplicata.BuscarDup(val.Id_despesastr,
                                                                                  val.Cd_empresa,
                                                                                  val.Id_viagemstr,
                                                                                  qtb_desp.Banco_Dados);

                if (lDup.Count > 0)
                {
                    if (Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim().ToUpper(), "PERMITIR EXCLUSAO DE DOCUMENTO FINANCEIRO", banco))
                    {
                        //Verificar se o usuario tem acesso a tela de duplicata
                        if ((Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Parametros.pubLogin, "Financeiro.TFLanContas") == null) &&
                            (!Parametros.pubLogin.Trim().ToUpper().Equals("MASTER")) &&
                            (!Parametros.pubLogin.Trim().ToUpper().Equals("DESENV")))
                            throw new Exception("Não é permitido cancelar uma nota fiscal com movimentação financeira.\r\n" +
                                                "Para cancelar a nota fiscal é necessário cancelar primeiro o financeiro.");
                        else
                            lDup.ForEach(p => CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(p, qtb_desp.Banco_Dados));
                    }
                }
                System.Collections.Hashtable h = new System.Collections.Hashtable();
                h.Add("@P_ID_VIAGEM", val.Id_viagem);
                h.Add("@P_ID_DESPESA", val.Id_despesa);
                h.Add("@P_CD_EMPRESA", val.Cd_empresa);
                //Excluir Viagem X CCusto
                qtb_desp.executarSql("delete TB_FIN_Viagem_X_CCusto " +
                                        "where ID_Viagem = @P_ID_VIAGEM " +
                                        "and ID_Despesa = @P_ID_DESPESA " +
                                        "and CD_Empresa = @P_CD_EMPRESA " +
                                       //Excluir Despesas X Duplicata
                                       "delete TB_FIN_DESPESAS_X_DUPLICATA " +
                                       "where ID_Viagem = @P_ID_VIAGEM " +
                                       "and CD_Empresa = @P_CD_EMPRESA " +
                                       "and ID_Despesa = @P_ID_DESPESA ", h);
                //Excluir Centro de CCusto
                lCCusto.ForEach(p => CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(p, qtb_desp.Banco_Dados));
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return val.Id_despesastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir despesa viagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AdtoViagem
    {
        public static TList_AdtoViagem Buscar(string Id_adto,
                                              string Id_viagem,
                                              string Cd_empresa,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_adto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_adto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_adto;
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_AdtoViagem(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento BuscarAdto(string Cd_empresa,
                                                                                           string Id_viagem,
                                                                                           BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo= string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_FIN_Viagem_X_Adto x " +
                                    "where x.id_adto = a.id_adto " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_viagem = " + Id_viagem + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AdtoViagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AdtoViagem qtb_adto = new TCD_AdtoViagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                string retorno = qtb_adto.Gravar(val);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AdtoViagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AdtoViagem qtb_adto = new TCD_AdtoViagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                qtb_adto.Excluir(val);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Viagem_X_CCusto
    {
        public static TList_Viagem_X_CCusto Buscar(string Id_despesa,
                                                       string Id_viagem,
                                                       string Cd_empresa,
                                                       string Id_ccustolan,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_despesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_despesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_despesa;
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ccustolan))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ccustolan";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ccustolan;
            }
            return new TCD_Viagem_X_CCusto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Viagem_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem_X_CCusto qtb_desp = new TCD_Viagem_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                string retorno = qtb_desp.Gravar(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Viagem_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem_X_CCusto qtb_desp = new TCD_Viagem_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                qtb_desp.Excluir(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }

        public static void ProcessarDespCResultado(List<TRegistro_DespesasViagem> lDespesas,
                                                   string CD_CentroResult,
                                                   BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem_X_CCusto qtb_desp = new TCD_Viagem_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                if (string.IsNullOrEmpty(CD_CentroResult))
                    throw new Exception("Obrigatório informar centro de resultado.");
                lDespesas.ForEach(p =>
                {
                    //Verificar se despesa possui centro de resultado
                    TCN_Viagem_X_CCusto.Buscar(p.Id_despesastr,
                                                   p.Id_viagemstr,
                                                   p.Cd_empresa,
                                                   string.Empty,
                                                   qtb_desp.Banco_Dados).ForEach(v =>
                                                   {
                                                       TCN_Viagem_X_CCusto.Excluir(v, qtb_desp.Banco_Dados);
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
                            Dt_lancto = p.Dt_despesa
                        }, qtb_desp.Banco_Dados);
                    //Amarrar Lancto a Caixa
                    Gravar(new TRegistro_Viagem_X_CCusto()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Id_ccustolan = decimal.Parse(id),
                        Id_despesa = p.Id_despesa,
                        Id_viagem = p.Id_viagem
                    }, qtb_desp.Banco_Dados);
                });
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar despesas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Despesa_X_Duplicata
    {
        public static TList_Despesa_X_Duplicata Buscar(string Id_despesa,
                                                       string Id_viagem,
                                                       string Cd_empresa,
                                                       string Nr_lancto,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_despesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_despesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_despesa;
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
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
            return new TCD_Despesa_X_Duplicata(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDup(string Id_despesa,
                                                                                       string Cd_empresa,
                                                                                       string Id_viagem,
                                                                                       BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_FIN_Despesas_X_Duplicata x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    (!string.IsNullOrEmpty(Id_despesa) ?
                                    "and x.id_despesa = " + Id_despesa  + " " : string.Empty) +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_viagem = " + Id_viagem + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Despesa_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Despesa_X_Duplicata qtb_desp = new TCD_Despesa_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else
                    qtb_desp.Banco_Dados = banco;
                string retorno = qtb_desp.Gravar(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Despesa_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Despesa_X_Duplicata qtb_desp = new TCD_Despesa_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else
                    qtb_desp.Banco_Dados = banco;
                qtb_desp.Excluir(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Viagem_X_DevCred
    {
        public static TList_Viagem_X_DevCred Buscar(string Id_adto,
                                              string Id_viagem,
                                              string Cd_empresa,
                                              string Cd_lanctocaixa,
                                              string Cd_contager,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_adto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_adto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_adto;
            }
            if (!string.IsNullOrEmpty(Id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_viagem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_lanctocaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa;
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            return new TCD_Viagem_X_DevCred(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Viagem_X_DevCred val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem_X_DevCred qtb_adto = new TCD_Viagem_X_DevCred();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                string retorno = qtb_adto.Gravar(val);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Viagem_X_DevCred val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Viagem_X_DevCred qtb_adto = new TCD_Viagem_X_DevCred();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                qtb_adto.Excluir(val);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }
    }
}
