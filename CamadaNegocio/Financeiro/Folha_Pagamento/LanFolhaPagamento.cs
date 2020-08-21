using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Folha_Pagamento;

namespace CamadaNegocio.Financeiro.Folha_Pagamento
{
    #region Folha Pagamento
    public class TCN_FolhaPagamento
    {
        public static TList_FolhaPagamento Buscar(string Id_folha,
                                                  string Cd_empresa,
                                                  string Mes,
                                                  string Ano,
                                                  string Cd_funcionario,
                                                  string St_registro,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_folha))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_folha";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_folha;
            }   
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Mes))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.mes_folha";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Mes.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ano))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ano_folha";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Ano.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_funcionario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_folha_x_funcionarios x " +
                                                      "where x.id_folha = a.id_folha " +
                                                      "and x.cd_funcionario = '" + Cd_funcionario.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_FolhaPagamento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FolhaPagamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FolhaPagamento qtb_folha = new TCD_FolhaPagamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_folha.CriarBanco_Dados(true);
                else
                    qtb_folha.Banco_Dados = banco;
                val.Id_folha = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_folha.Gravar(val), "@P_ID_FOLHA"));
                val.lFolhaFuncDel.ForEach(p => TCN_Folha_X_Funcionarios.Excluir(p, qtb_folha.Banco_Dados));
                val.lFolhaFunc.ForEach(p =>
                    {
                        p.Id_folha = val.Id_folha;
                        TCN_Folha_X_Funcionarios.Gravar(p, qtb_folha.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_folha.Banco_Dados.Commit_Tran();
                return val.Id_folha.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_folha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar folha: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_folha.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FolhaPagamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FolhaPagamento qtb_folha = new TCD_FolhaPagamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_folha.CriarBanco_Dados(true);
                else
                    qtb_folha.Banco_Dados = banco;
                val.lFolhaFuncDel.ForEach(p => TCN_Folha_X_Funcionarios.Excluir(p, qtb_folha.Banco_Dados));
                val.lFolhaFunc.ForEach(p => TCN_Folha_X_Funcionarios.Excluir(p, qtb_folha.Banco_Dados));
                qtb_folha.Excluir(val);
                if (st_transacao)
                    qtb_folha.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_folha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir folha: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_folha.deletarBanco_Dados();
            }
        }

        public static void ProcessarLoteFolha(TRegistro_FolhaPagamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FolhaPagamento qtb_folha = new TCD_FolhaPagamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_folha.CriarBanco_Dados(true);
                else
                    qtb_folha.Banco_Dados = banco;
                //Buscar parametros para processar lote
                CamadaDados.Financeiro.Cadastros.TList_CfgFolhaPagamento lCfg =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CfgFolhaPagamento.Buscar(val.Cd_empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    qtb_folha.Banco_Dados);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração para processar folha na empresa " + val.Cd_empresa.Trim());
                //Buscar condicao pagamento
                CamadaDados.Financeiro.Cadastros.TList_CadCondPgto lCond =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(lCfg[0].Cd_condpgto,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              decimal.Zero,
                                                                              decimal.Zero,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              string.Empty,
                                                                              qtb_folha.Banco_Dados);
                //Gerar duplicata
                val.lFolhaFunc.ForEach(p =>
                    {
                        if (p.Vl_pagamento > 0)
                        {
                            CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                            rDup.Cd_empresa = val.Cd_empresa;
                            rDup.Cd_historico = lCfg[0].Cd_historico;
                            //Buscar historico de quitacao
                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(qtb_folha.Banco_Dados).BuscarEscalar(
                                            new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_historico",
                                                vOperador = "=",
                                                vVL_Busca = "'" + lCfg[0].Cd_historico.Trim() + "'"
                                            }
                                        }, "a.cd_historico_quitacao");
                            rDup.Cd_historico_Dup = obj == null ? lCfg[0].Cd_historico : obj.ToString();
                            rDup.Nr_docto = "FLH" + val.Id_folha.Value.ToString();
                            rDup.Vl_documento = p.Vl_pagamento;
                            rDup.Vl_documento_padrao = p.Vl_pagamento;
                            DateTime dt_emissao = new DateTime(Convert.ToInt32(val.Ano_folha.Value), Convert.ToInt32(val.Mes_folha.Value), lCfg[0].Diapagamento > 0 ? Convert.ToInt32(lCfg[0].Diapagamento) : 1);
                            if (lCfg[0].St_despmesanteriorbool)
                            {
                                dt_emissao = dt_emissao.AddMonths(-1);
                                dt_emissao = new DateTime(dt_emissao.Year, dt_emissao.Month, DateTime.DaysInMonth(dt_emissao.Year, dt_emissao.Month));
                            }
                            rDup.Dt_emissao = dt_emissao;
                            rDup.Qt_parcelas = lCond[0].Qt_parcelas;
                            rDup.Qt_dias_desdobro = lCond[0].Qt_diasdesdobro;
                            rDup.St_comentrada = lCond[0].St_comentrada;
                            rDup.Tp_docto = lCfg[0].Tp_docto;
                            rDup.Tp_juro = lCond[0].Tp_juro;
                            rDup.Tp_duplicata = lCfg[0].Tp_duplicata;
                            rDup.Tp_mov = lCfg[0].Tp_movduplicata;
                            rDup.Pc_jurodiario_atrazo = lCond[0].Pc_jurodiario_atrazo;
                            rDup.Cd_clifor = p.Cd_funcionario;
                            //Buscar endereco do funcionario
                            obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(qtb_folha.Banco_Dados).BuscarEscalar(
                                    new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_funcionario.Trim() + "'"
                                    }
                                }, "a.cd_endereco");
                            rDup.Cd_endereco = obj != null ? obj.ToString() : string.Empty;
                            rDup.Cd_juro = lCond[0].Cd_juro;
                            rDup.Cd_moeda = string.IsNullOrEmpty(lCond[0].Cd_moeda) ? CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", val.Cd_empresa, qtb_folha.Banco_Dados) : lCond[0].Cd_moeda;
                            rDup.Cd_condpgto = lCfg[0].Cd_condpgto;
                            rDup.Complhistorico = "REF FOLHA PAGAMENTO DE " + val.Mes_folhastr + "/" + val.Ano_folhastr;
                            rDup.cVl_adiantamento = p.Vl_adtodevolver;
                            //Calcular parcelas
                            rDup.Parcelas = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.calcularParcelas(rDup, null);
                            if (lCfg[0].Diapagamento > 0)
                            {
                                //Ajustar data vencimento da folha para dia configurado
                                rDup.Parcelas.ForEach(x =>
                                    {
                                        DateTime dt_feriado = new DateTime(x.Dt_vencto.Value.Year, x.Dt_vencto.Value.Month, Convert.ToInt32(lCfg[0].Diapagamento));
                                        Duplicata.TCN_LanDuplicata.validaFeriado(rDup.St_venctoferiado.Trim().ToUpper().Equals("S"), ref dt_feriado);
                                        x.Dt_vencto = dt_feriado;
                                    });
                            }
                            //Verificar se a condicao de pagamento e a vista
                            obj = new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(qtb_folha.Banco_Dados).BuscarEscalar(
                                    new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_condpgto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + lCfg[0].Cd_condpgto.Trim() + "'"
                                    }
                                }, "a.qt_parcelas");
                            if (obj == null ? false : obj.ToString().Trim().Equals("0"))
                            {
                                if (string.IsNullOrEmpty(lCfg[0].Cd_portador) || string.IsNullOrEmpty(lCfg[0].Cd_contager))
                                    throw new Exception("Obrigatorio configurar portador e conta gerencial para processar lote folha com condição pagamento a vista.");
                                rDup.Cd_portador = lCfg[0].Cd_portador;
                                rDup.Cd_contager = lCfg[0].Cd_contager;
                                //Verificar se o portador movimenta titulo
                                obj = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(qtb_folha.Banco_Dados).BuscarEscalar(
                                        new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "cd_portador",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lCfg[0].Cd_portador.Trim() + "'"
                                        }
                                    }, "st_controletitulo");
                                if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("S"))
                                {
                                    //Buscar dados contager
                                    CamadaDados.Financeiro.Cadastros.TList_CadContaGer lConta =
                                        CamadaNegocio.Financeiro.Cadastros.TCN_CadContaGer.Buscar(lCfg[0].Cd_contager,
                                                                                                  string.Empty,
                                                                                                  null,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  decimal.Zero,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  1,
                                                                                                  qtb_folha.Banco_Dados);
                                    if (lConta.Count.Equals(0))
                                        throw new Exception("Erro localizar registro conta gerencial Nº" + lCfg[0].Cd_contager.Trim());
                                    if (!lConta[0].St_contacompensacaobool)
                                        throw new Exception("Só é permitido emitir cheque a pagar em conta de compensação.");
                                    if (string.IsNullOrEmpty(lConta[0].Banco.Cd_banco))
                                        throw new Exception("Não existe banco configurado para a conta Nº" + lCfg[0].Cd_contager.Trim());
                                    //Criar lista de titulo
                                    CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rTitulo = new CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo();
                                    rTitulo.Cd_banco = lConta[0].Banco.Cd_banco;
                                    rTitulo.Nomebanco = lConta[0].Banco.Ds_banco;
                                    rTitulo.Cd_contager = lConta[0].Cd_contager;
                                    rTitulo.Cd_empresa = val.Cd_empresa;
                                    rTitulo.Cd_historico = rDup.Cd_historico_Dup;
                                    rTitulo.Cd_portador = lCfg[0].Cd_portador;
                                    rTitulo.Dt_emissao = rDup.Dt_emissao;
                                    rTitulo.Dt_vencto = rDup.Parcelas[0].Dt_vencto;
                                    rTitulo.Nm_clifor_nominal = p.Nm_funcionario;
                                    rTitulo.Nomeclifor = p.Nm_funcionario;
                                    //Buscar numero cheque
                                    obj = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(qtb_folha.Banco_Dados).BuscarEscalar(
                                            new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_contager",
                                                vOperador = "=",
                                                vVL_Busca = "'" + lCfg[0].Cd_contager.Trim() + "'"
                                            }
                                        }, "a.nr_cheque_seq");
                                    if (obj != null)
                                        try
                                        {
                                            rTitulo.Nr_cheque = (Convert.ToDecimal(obj.ToString()) + 1).ToString();
                                        }
                                        catch (Exception ex)
                                        { throw new Exception("Erro gerar numero cheque: " + ex.Message.Trim()); }
                                    rTitulo.Observacao = "REF PAGAMENTO SALARIO MES/ANO " + val.Mes_folhastr + "/" + val.Ano_folhastr;
                                    rTitulo.Tp_titulo = "P";
                                    rTitulo.Vl_titulo = p.Vl_pagamento - p.Vl_adtodevolver;
                                    //Incluir titulo na lista
                                    rDup.Titulos.Add(rTitulo);
                                }
                            }
                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                                     rDup.Cd_empresa,
                                                                                     null).Trim().ToUpper().Equals("S") &&
                                    (!string.IsNullOrEmpty(lCfg[0].Cd_centroresult)))
                                rDup.lCustoLancto = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto()
                                    {
                                        new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                        {
                                            Cd_empresa = rDup.Cd_empresa,
                                            Cd_centroresult = lCfg[0].Cd_centroresult,
                                            Vl_lancto = rDup.Vl_documento,
                                            Dt_lancto = rDup.Dt_emissao
                                        }
                                    };
                            //Gravar duplicata
                            CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(rDup, false, qtb_folha.Banco_Dados);
                            p.Cd_empresa = rDup.Cd_empresa;
                            p.Nr_lancto = rDup.Nr_lancto;
                        }
                    });
                //Alterar status do lote para processado
                val.St_registro = "P";
                Gravar(val, qtb_folha.Banco_Dados);
                //Commitar Dados
                if (st_transacao)
                    qtb_folha.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_folha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar lote folha: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_folha.deletarBanco_Dados();
            }
        }

        public static void EstornarProcessoFolha(TRegistro_FolhaPagamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FolhaPagamento qtb_folha = new TCD_FolhaPagamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_folha.CriarBanco_Dados(true);
                else
                    qtb_folha.Banco_Dados = banco;
                val.lFolhaFunc.ForEach(p =>
                    {
                        if (p.Nr_lancto != null)
                        {
                            //Buscar duplicata amarrada ao pagamento
                            CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(p.Cd_empresa,
                                                                                          p.Nr_lancto.Value.ToString(),
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          false,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          false,
                                                                                          1,
                                                                                          string.Empty,
                                                                                          qtb_folha.Banco_Dados);
                            if (lDup.Count > 0)
                                CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(lDup[0], qtb_folha.Banco_Dados);
                            p.Nr_lancto = null;
                            TCN_Folha_X_Funcionarios.Gravar(p, qtb_folha.Banco_Dados);
                        }
                    });
                val.St_registro = "A";
                Gravar(val, qtb_folha.Banco_Dados);
                if (st_transacao)
                    qtb_folha.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_folha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar processamento folha: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_folha.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Folha X Funcionarios
    public class TCN_Folha_X_Funcionarios
    {
        public static TList_Folha_X_Funcionarios Buscar(string Id_folha,
                                                        string Cd_funcionario,
                                                        string Cd_empresa,
                                                        string Nr_lancto,
                                                        BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_folha))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_folha";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_folha;
            }
            if (!string.IsNullOrEmpty(Cd_funcionario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_funcionario";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_funcionario.Trim() + "'";
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
            return new TCD_Folha_X_Funcionarios(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Folha_X_Funcionarios val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Folha_X_Funcionarios qtb_folha = new TCD_Folha_X_Funcionarios();
            try
            {
                if (banco == null)
                    st_transacao = qtb_folha.CriarBanco_Dados(true);
                else
                    qtb_folha.Banco_Dados = banco;
                string retorno = qtb_folha.Gravar(val);
                if (st_transacao)
                    qtb_folha.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_folha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar folha: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_folha.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Folha_X_Funcionarios val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Folha_X_Funcionarios qtb_folha = new TCD_Folha_X_Funcionarios();
            try
            {
                if (banco == null)
                    st_transacao = qtb_folha.CriarBanco_Dados(true);
                else
                    qtb_folha.Banco_Dados = banco;
                qtb_folha.Excluir(val);
                if (st_transacao)
                    qtb_folha.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_folha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir folha: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_folha.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
