using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Empreendimento;

namespace CamadaNegocio.Empreendimento
{
    public class TCN_ExecDespesas
    {
        public static TList_ExecDespesas Buscar(string Cd_empresa,
                                          string Id_orcamento,
                                          string Nr_versao,
                                          string Cd_clifor,
                                          string Cd_vendedor,
                                          string Tp_data,
                                          string Dt_ini,
                                          string Dt_fin,
                                          string St_registro,
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
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;// + " or ( b.id_orc = '" + Id_orcamento + "')";
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_versao;
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_previni" : Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_prevfin" : "a.dt_orcamento") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_previni" : Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_prevfin" : "a.dt_orcamento") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = St_registro.Trim();
            }
            return new TCD_ExecDespesas(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ExecDespesas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ExecDespesas qtb_orc = new TCD_ExecDespesas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                
                string retorno = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDuplicata, false, qtb_orc.Banco_Dados);
                val.nr_lancto = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_LANCTO"));

                string ret = qtb_orc.Gravar(val);
                val.id_execucao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_EXECUCAO"));

                if (val.lCCusto != null)
                    val.lCCusto.ForEach(p =>
                    {
                        p.Nr_lancto = val.nr_lancto;
                        p.Cd_empresa = val.Cd_empresa;
                        p.Cd_clifor = val.Tp_pagamento.Trim().ToUpper().Equals("E") ? val.Cd_fornecedor : val.Cd_funcionario;
                        p.Nr_docto = val.rDuplicata.Nr_docto;
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(p, qtb_orc.Banco_Dados);
                        TCN_DespViagem_X_CCusto.Gravar(new TRegistro_DespViagem_X_CCusto()
                        {
                            cd_empresa = val.Cd_empresa,
                            Id_despesa = val.Id_RegDesp,
                            Id_execucao = val.id_execucao,
                            Id_orcamento = val.Id_orcamento,
                            Nr_versao = val.Nr_versao,
                            nr_lancto = val.nr_lancto,
                            Id_CCustoLan = p.Id_ccustolan
                        }, qtb_orc.Banco_Dados);
                    });
                // val.Nr_versaostr = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_NR_VERSAO");

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.id_execucao.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Despesa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        

        public static string Excluir(TRegistro_ExecDespesas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ExecDespesas qtb_orc = new TCD_ExecDespesas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                
                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    
    }



    public class TCN_DespViagem_X_CCusto
    {
        public static TList_DespViagem_X_CCusto Buscar(string Id_landespesa,
                                                       string Id_viagem,
                                                       string Cd_empresa,
                                                       string Nr_lancto,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_landespesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_landespesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_landespesa;
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
            return new TCD_DespViagem_X_CCusto(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDup(string Id_landespesa,
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
                        vVL_Busca = "(select 1 from tb_frt_DespViagem_X_CCusto x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and x.id_landespesa = " + Id_landespesa + " " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_viagem = " + Id_viagem + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DespViagem_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DespViagem_X_CCusto qtb_desp = new TCD_DespViagem_X_CCusto();
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

        public static string Excluir(TRegistro_DespViagem_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DespViagem_X_CCusto qtb_desp = new TCD_DespViagem_X_CCusto();
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
}
