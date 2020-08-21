using System;
using System.Collections.Generic;
using System.Linq;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_CaixaPDV
    {
        public static TList_CaixaPDV Buscar(string Id_caixa,
                                            string Tp_data,
                                            string Dt_ini,
                                            string Dt_fin,
                                            string St_registro,
                                            string Login,
                                            BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_fechamento" : "a.dt_auditado";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_fechamento" : "a.dt_auditado";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Login))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.login";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Login.Trim() + "'";
            }

            return new TCD_CaixaPDV(banco).Select(filtro, 0, string.Empty);
        }

        public static List<TRegistro_MovCaixa> BuscarMovCaixa(string Id_caixa,
                                                              string Cd_portador,
                                                              string vOrder,
                                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            if (!string.IsNullOrEmpty(Cd_portador))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_portador";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_portador.Trim() + "'";
            }
            
            return new TCD_CaixaPDV(banco).SelectMovCaixa(filtro, vOrder);
        }

        public static string Gravar(TRegistro_CaixaPDV val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CaixaPDV qtb_caixa = new TCD_CaixaPDV();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                val.Id_caixastr = CamadaDados.TDataQuery.getPubVariavel(qtb_caixa.Gravar(val), "@P_ID_CAIXA");
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
                return val.Id_caixastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar caixa PDV: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CaixaPDV val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CaixaPDV qtb_caixa = new TCD_CaixaPDV();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                //Verificar se o caixa possui movimentacao
                if (new CamadaDados.Faturamento.PDV.TCD_Cupom_X_MovCaixa(qtb_caixa.Banco_Dados).BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_caixa",
                            vOperador = "=",
                            vVL_Busca = val.Id_caixastr
                        }
                    }, "1") != null)
                    throw new Exception("Não é permitido excluir caixa com movimentação.");
                //Buscar config cupom fiscal
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(val.Cd_empresa, qtb_caixa.Banco_Dados);
                //Buscar retiradas do caixa
                TCN_RetiradaCaixa.Buscar(string.Empty,
                                         val.Id_caixastr,
                                         string.Empty,
                                         string.Empty,
                                         qtb_caixa.Banco_Dados).ForEach(p =>
                                             {
                                                 if (p.St_registro.Trim().ToUpper().Equals("P"))
                                                 {
                                                     if (p.Id_transf.HasValue)
                                                     {

                                                         new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(qtb_caixa.Banco_Dados).Select(
                                                             new Utils.TpBusca[]
                                                             {
                                                                 new Utils.TpBusca()
                                                                 {
                                                                     vNM_Campo = string.Empty,
                                                                     vOperador = "exists",
                                                                     vVL_Busca = "(select 1 from TB_FIN_TransfCaixa x " +
                                                                                 "where ((x.cd_conta_ent = a.cd_contager " +
                                                                                 "and x.cd_lanctocaixa_ent = a.cd_lanctocaixa) or " +
                                                                                 "(x.cd_conta_sai = a.cd_contager " +
                                                                                 "and x.cd_lanctocaixa_sai = a.cd_lanctocaixa)) " +
                                                                                 "and x.id_transf = " + p.Id_transfstr + ")"
                                                                 }
                                                             }, 0, string.Empty).ForEach(x =>
                                                                 CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarCaixa(x, null, qtb_caixa.Banco_Dados));
                                                     }
                                                     else
                                                         TCN_Retirada_X_Cheque.BuscarCh(p.Id_retiradastr, qtb_caixa.Banco_Dados).ForEach(v =>
                                                             {
                                                                 //Transferir titulo para caixa operacional
                                                                 v.Cd_contager_destino = lCfg[0].Cd_contaoperacional;
                                                                 CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.TransferirTitulo(v, qtb_caixa.Banco_Dados);
                                                                 //Excluir registro
                                                                 TCN_Retirada_X_Cheque.Excluir(
                                                                     new TRegistro_Retirada_X_Cheque()
                                                                     {
                                                                         Id_retirada = p.Id_retirada,
                                                                         Cd_empresa = v.Cd_empresa,
                                                                         Nr_lanctocheque = v.Nr_lanctocheque,
                                                                         Cd_banco = v.Cd_banco
                                                                     }, qtb_caixa.Banco_Dados);
                                                             });
                                                     TCN_RetiradaCaixa.Excluir(p, qtb_caixa.Banco_Dados);
                                                 }
                                                 else
                                                 {
                                                     TCN_Retirada_X_Cheque.Buscar(p.Id_retiradastr, 
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  qtb_caixa.Banco_Dados).ForEach(v => TCN_Retirada_X_Cheque.Excluir(v, qtb_caixa.Banco_Dados));
                                                     TCN_RetiradaCaixa.Excluir(p, qtb_caixa.Banco_Dados);
                                                 }
                                             });
                qtb_caixa.Excluir(val);
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
                return val.Id_caixastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir caixa PDV: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static void AbrirCaixa(TRegistro_CaixaPDV val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CaixaPDV qtb_caixa = new TCD_CaixaPDV();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                if (qtb_caixa.BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.login",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Login.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                    }, "1") != null)
                    throw new Exception("Já existe caixa aberto para o Login " + val.Login.Trim());
                //Gravar Caixa PDV
                val.Dt_abertura = CamadaDados.UtilData.Data_Servidor(qtb_caixa.Banco_Dados);
                val.Id_caixastr = CamadaDados.TDataQuery.getPubVariavel(qtb_caixa.Gravar(val), "@P_ID_CAIXA");
                if(val.Vl_abertura > decimal.Zero)
                    if (!val.St_valortransportar)
                    {
                        //Gravar retirada caixa
                        TRegistro_RetiradaCaixa rRet = new TRegistro_RetiradaCaixa();
                        rRet.Id_caixa = val.Id_caixa;
                        rRet.Dt_retirada = val.Dt_abertura;
                        rRet.Vl_retirada = val.Vl_abertura;
                        rRet.Ds_observacao = "ABERTURA CAIXA Nº" + val.Id_caixastr;
                        rRet.Tp_registro = "S";//Suprimento
                        rRet.St_registro = "A";
                        TCN_RetiradaCaixa.Gravar(rRet, qtb_caixa.Banco_Dados);
                        //Processar retirada
                        CamadaDados.Financeiro.Cadastros.TList_CadPortador lPortador =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(qtb_caixa.Banco_Dados).Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.TP_PortadorPDV",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "ISNULL(a.ST_CartaFrete, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "ISNULL(a.ST_ControleTitulo, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "ISNULL(a.ST_DevCredito, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.ST_CartaoCredito",
                                    vOperador = "=",
                                    vVL_Busca = "1"
                                }
                            }, 1, string.Empty, string.Empty);
                        if (lPortador.Count > 0)
                        {
                            lPortador[0].Vl_pagtoPDV = rRet.Vl_retirada;
                            rRet.lPortador = lPortador;
                            TCN_RetiradaCaixa.ProcessarRetirada(rRet, qtb_caixa.Banco_Dados);
                        }
                    }
                    else
                    {
                        //Gravar retirada caixa
                        TRegistro_RetiradaCaixa rRet = new TRegistro_RetiradaCaixa();
                        rRet.Id_caixa = val.Id_caixa;
                        rRet.Dt_retirada = val.Dt_abertura;
                        rRet.Vl_retirada = val.Vl_abertura;
                        rRet.Ds_observacao = "ABERTURA CAIXA Nº" + val.Id_caixastr;
                        rRet.Tp_registro = "S";//Suprimento
                        rRet.St_registro = "P";
                        TCN_RetiradaCaixa.Gravar(rRet, qtb_caixa.Banco_Dados);
                    }   
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro abrir caixa PDV: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static void FecharCaixa(TRegistro_CaixaPDV val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CaixaPDV qtb_caixa = new TCD_CaixaPDV();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                //Gravar alteracao caixa
                Gravar(val, qtb_caixa.Banco_Dados);
                //Gravar fechamento caixa portador
                val.lPorFecharCaixa.ForEach(p => 
                    {
                        decimal vl_mov = new TCD_CaixaPDV(qtb_caixa.Banco_Dados).SelectMovCaixa(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.id_caixa",
                                                    vOperador = "=",
                                                    vVL_Busca = val.Id_caixastr
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_portador",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_portador.Trim() + "'"
                                                }
                                            }, string.Empty).Sum(v => v.Vl_recebido - v.Vl_DevCredito);
                        TCN_FechamentoCaixa.Gravar(new TRegistro_FechamentoCaixa()
                        {
                            Cd_portador = p.Cd_portador,
                            Id_caixa = val.Id_caixa,
                            Vl_movimento = vl_mov,
                            Vl_fechamento = p.Vl_pagtoPDV,
                            Vl_auditado = p.St_cartaocreditobool ? vl_mov : decimal.Zero
                        }, qtb_caixa.Banco_Dados);
                    });
                //Verificar se caixa esta configurado para processar comissao
                if (new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal(qtb_caixa.Banco_Dados).BuscarEscalar(
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
                            vNM_Campo = "isnull(a.st_apurarcomcx, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    }, "1") != null)
                {
                    CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao lComissao =
                        new CamadaDados.Faturamento.Comissao.TCD_Fechamento_Comissao(qtb_caixa.Banco_Dados).Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "exists(select 1 from TB_PDV_Cupom_X_MovCaixa x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_cupom = a.id_cupom " +
                                            "and x.id_caixa = " + val.Id_caixastr + ") or " +
                                            "exists(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_cupom = a.id_cupom " +
                                            "and x.id_caixa = " + val.Id_caixastr + ")"
                            }
                        }, 0, string.Empty);
                    if (lComissao.Count > 0)
                    {
                        //Buscar configuracao processar comissao
                        CamadaDados.Faturamento.Cadastros.TList_CFGComissao lCfg =
                            CamadaNegocio.Faturamento.Cadastros.TCN_CFGComissao.Buscar(val.Cd_empresa, qtb_caixa.Banco_Dados);
                        if (lCfg.Count.Equals(0))
                            throw new Exception("Não existe configuração para processar comissão.");
                        DateTime dt_atual = CamadaDados.UtilData.Data_Servidor(qtb_caixa.Banco_Dados);
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rCond =
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
                                                                                      qtb_caixa.Banco_Dados)[0];
                        lComissao.GroupBy(p => p.Cd_vendedor,
                            (aux, comissao) =>
                                new
                                {
                                    cd_vendedor = aux,
                                    vl_comissao = comissao.Sum(x => x.Vl_saldofaturar)
                                }).ToList().ForEach(p =>
                                    {
                                        //Gerar Duplicata
                                        CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                                        rDup.Cd_empresa = val.Cd_empresa;
                                        rDup.Id_caixaoperacional = val.Id_caixa;
                                        rDup.Cd_historico = lCfg[0].Cd_historico;
                                        rDup.Tp_docto = lCfg[0].Tp_docto;
                                        rDup.Tp_duplicata = lCfg[0].Tp_duplicata;
                                        rDup.Tp_mov = "P";
                                        rDup.Cd_clifor = p.cd_vendedor;
                                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(qtb_caixa.Banco_Dados).BuscarEscalar(
                                                        new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_clifor",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + p.cd_vendedor.Trim() + "'"
                                                            }
                                                        }, "a.cd_endereco");
                                        rDup.Cd_endereco = obj != null ? obj.ToString() : string.Empty;
                                        rDup.Cd_juro = rCond.Cd_juro;
                                        rDup.Cd_moeda = !string.IsNullOrEmpty(rCond.Cd_moeda) ? rCond.Cd_moeda :
                                            CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", val.Cd_empresa, qtb_caixa.Banco_Dados);
                                        rDup.Cd_condpgto = lCfg[0].Cd_condpgto;
                                        rDup.Nr_docto = "COMISSAO";
                                        rDup.Vl_documento = p.vl_comissao;
                                        rDup.Vl_documento_padrao = p.vl_comissao;
                                        rDup.Dt_emissao = dt_atual;
                                        rDup.Qt_parcelas = rCond.Qt_parcelas;
                                        rDup.Qt_dias_desdobro = rCond.Qt_diasdesdobro;
                                        rDup.St_comentrada = rCond.St_comentrada;
                                        rDup.Tp_juro = rCond.Tp_juro;
                                        rDup.Pc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo;
                                        rDup.St_registro = "A";
                                        rDup.Cd_portador = rCond.Cd_portador;
                                        rDup.Cd_contager = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal(qtb_caixa.Banco_Dados).BuscarEscalar(
                                                            new Utils.TpBusca[]
                                                            {
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                                }
                                                            }, "a.cd_contaoperacional").ToString();
                                        rDup.Cd_historico_Dup = lCfg[0].Cd_historico;
                                        rDup.Parcelas.Add(new CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela()
                                        {
                                            Cd_parcela = 1,
                                            Dt_vencto = dt_atual,
                                            Vl_parcela = p.vl_comissao,
                                            Vl_parcela_padrao = p.vl_comissao,
                                            St_registro = "A"
                                        });
                                        //Gravar duplicata
                                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(rDup, false, qtb_caixa.Banco_Dados);
                                        //Gravar duplicata x comissao
                                        lComissao.FindAll(v => v.Cd_vendedor.Trim().Equals(p.cd_vendedor.Trim())).ForEach(v =>
                                            CamadaNegocio.Faturamento.Comissao.TCN_Comissao_X_Duplicata.Gravar(
                                            new CamadaDados.Faturamento.Comissao.TRegistro_Comissao_X_Duplicata()
                                            {
                                                Id_comissao = v.Id_comissao,
                                                Cd_empresa = v.Cd_empresa,
                                                Nr_lancto = rDup.Nr_lancto,
                                                Vl_faturado = p.vl_comissao
                                            }, qtb_caixa.Banco_Dados));
                                    });
                    }
                }
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro fechar caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static bool AuditarCaixa(TRegistro_CaixaPDV val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CaixaPDV qtb_caixa = new TCD_CaixaPDV();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                bool st_auditar = true;
                val.lFechamentoCaixa.ForEach(p =>
                    {
                        if (p.Vl_auditado.Equals(decimal.Zero) && (!p.St_cartao))
                            st_auditar = false;
                        else
                        {
                            if (p.St_cartao)
                                p.Vl_auditado = p.Vl_recebido;
                            p.Vl_movimento = p.Vl_recebido;
                            p.Loginaudit = Utils.Parametros.pubLogin;
                            TCN_FechamentoCaixa.Gravar(p, qtb_caixa.Banco_Dados);
                        }
                    });
                if (st_auditar)
                {
                    val.Dt_auditado = CamadaDados.UtilData.Data_Servidor(qtb_caixa.Banco_Dados);
                    val.St_registro = "D";//Auditado
                    Gravar(val, qtb_caixa.Banco_Dados);
                }
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
                return st_auditar;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro auditar caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static void EstornarFechamento(TRegistro_CaixaPDV val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CaixaPDV qtb_caixa = new TCD_CaixaPDV();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                //Verificar se login possui caixa aberto
                if (qtb_caixa.BuscarEscalar(
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
                            vNM_Campo = "a.login",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Login.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                    }, "1") != null)
                    throw new Exception("Usuário já possui caixa ABERTO.\r\nNão é permitido dois caixa ABERTOS para o mesmo usuário.");
                //Excluir fechamento caixa
                TCN_FechamentoCaixa.Buscar(val.Id_caixastr, string.Empty, string.Empty, qtb_caixa.Banco_Dados).ForEach(p =>
                    TCN_FechamentoCaixa.Excluir(p, qtb_caixa.Banco_Dados));
                val.Dt_auditado = null;
                val.St_registro = "A";
                qtb_caixa.Gravar(val);
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar fechamento caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static void ProcessarCaixa(TRegistro_CaixaPDV val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CaixaPDV qtb_caixa = new TCD_CaixaPDV();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                //Verificar status atual do caixa
                if(qtb_caixa.BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_caixa",
                                vOperador = "=",
                                vVL_Busca = val.Id_caixastr
                            }
                        }, "isnull(a.st_registro, 'A')").ToString().Trim().ToUpper() != "D")
                    throw new Exception("Permitido processar somente caixa AUDITADO.");
                //Data transf
                DateTime dt_transf = CamadaDados.UtilData.Data_Servidor(qtb_caixa.Banco_Dados);
                //Buscar conta gerencial
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(val.Cd_empresa, qtb_caixa.Banco_Dados);
                if (lCfg.Count < 1)
                    throw new Exception("Não existe configuração ECF para a empresa: " + val.Cd_empresa.Trim());
                //Buscar fechamento de caixa
                TCN_FechamentoCaixa.Buscar(val.Id_caixastr,
                                           string.Empty,
                                           "'A'",
                                           null).ForEach(p =>
                                               {
                                                   if (p.St_cheque)
                                                   {
                                                       //Transferir os cheques recebidos no caixa operacional
                                                       new CamadaDados.Financeiro.Titulo.TCD_LanTitulo(qtb_caixa.Banco_Dados).Select(
                                                           new Utils.TpBusca[]
                                                            {
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = "a.tp_titulo",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'R'"
                                                                },
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = "isNull(a.Status_Compensado, 'N')",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'N'"
                                                                },
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = string.Empty,
                                                                    vOperador = string.Empty,
                                                                    vVL_Busca = "(exists(select 1 from tb_fin_titulo_x_caixa x " +
                                                                                "inner join tb_pdv_cupom_x_movcaixa y " +
                                                                                "on x.cd_contager = y.cd_contager " +
                                                                                "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                                "and x.cd_banco = a.cd_banco " +
                                                                                "and x.nr_lanctocheque = a.nr_lanctocheque " + 
                                                                                "and y.id_caixa = " + val.Id_caixastr + ") or " +
                                                                                "exists(select 1 from tb_fin_titulo_x_caixa x " +
                                                                                "inner join tb_fin_liquidacao y " +
                                                                                "on x.cd_contager = y.cd_contager " +
                                                                                "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                                                "inner join tb_pdv_caixa_x_liquidacao  z " +
                                                                                "on y.cd_empresa = z.cd_empresa " +
                                                                                "and y.nr_lancto = z.nr_lancto " +
                                                                                "and y.cd_parcela = z.cd_parcela " +
                                                                                "and y.id_liquid = z.id_liquid " +
                                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                                "and x.cd_banco = a.cd_banco " +
                                                                                "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                                                "and z.id_caixa = " + val.Id_caixastr + ") or " +
                                                                                "exists(select 1 from tb_fin_titulo_x_caixa x " +
                                                                                "inner join tb_fin_adiantamento_x_caixa y " +
                                                                                "on x.cd_contager = y.cd_contager " +
                                                                                "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                                                "inner join tb_fin_adiantamento z " +
                                                                                "on y.id_adto = z.id_adto " +
                                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                                "and x.cd_banco = a.cd_banco " +
                                                                                "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                                                "and z.id_caixaPDV = " + val.Id_caixastr + ") or " +
                                                                                "exists(select 1 from TB_PDV_TrocaEspecie x " +
                                                                                "where x.CD_Empresa = a.cd_empresa " +
                                                                                "and x.CD_Banco = a.cd_banco " +
                                                                                "and x.Nr_LanctoCheque = a.nr_lanctocheque " +
                                                                                "and x.ID_Caixa = " + val.Id_caixastr + "))"
                                                                },
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = string.Empty,
                                                                    vOperador = "not exists",
                                                                    vVL_Busca = "(select 1 from tb_pdv_retirada_x_cheque x " + 
                                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                                "and x.cd_banco = a.cd_banco " +
                                                                                "and x.nr_lanctocheque = a.nr_lanctocheque)"
                                                                }
                                                            }, 0, string.Empty, string.Empty).ForEach(v =>
                                                                                               {
                                                                                                   //Transferir CC do Titulo
                                                                                                   v.Dt_compensacao = dt_transf;
                                                                                                   v.Cd_contager_destino = lCfg[0].Cd_contacaixa;
                                                                                                   CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.TransferirTitulo(v, qtb_caixa.Banco_Dados);
                                                                                                   //ProcCaixa X Cheque
                                                                                                   TCN_ProcCaixa_X_Cheque.Gravar(new TRegistro_ProcCaixa_X_Cheque()
                                                                                                   {
                                                                                                       Cd_banco = v.Cd_banco,
                                                                                                       Cd_empresa = v.Cd_empresa,
                                                                                                       Nr_lanctocheque = v.Nr_lanctocheque,
                                                                                                       Id_caixa = val.Id_caixa
                                                                                                   }, qtb_caixa.Banco_Dados);
                                                                                               });
                                                       //Apurar diferenca portador cheque
                                                       if (p.Vl_liquido > p.Vl_auditado)
                                                       {
                                                           if (string.IsNullOrEmpty(lCfg[0].Cd_historico_sobracaixa))
                                                               throw new Exception("Não existe historico de sobra de caixa configurado.");
                                                           //Gravar Caixa
                                                           string ret_caixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                               new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                               {
                                                                                   Cd_Empresa = lCfg[0].Cd_empresa,
                                                                                   Cd_ContaGer = lCfg[0].Cd_contacaixa,
                                                                                   Cd_Historico = lCfg[0].Cd_historico_sobracaixa,
                                                                                   Cd_LanctoCaixa = decimal.Zero,
                                                                                   ComplHistorico = "SOBRA CAIXA OPERACIONAL Nº" + val.Id_caixastr + " PORTADOR " + p.Ds_portador,
                                                                                   NM_Clifor = string.Empty,
                                                                                   Dt_lancto = dt_transf,
                                                                                   Nr_Docto = "CAIXA Nº" + val.Id_caixastr,
                                                                                   St_Estorno = "N",
                                                                                   St_Titulo = "N",
                                                                                   Vl_PAGAR = p.Vl_liquido - p.Vl_auditado,
                                                                                   Vl_RECEBER = decimal.Zero
                                                                               }, qtb_caixa.Banco_Dados);
                                                           p.Cd_contager = lCfg[0].Cd_contacaixa;
                                                           p.Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA"));
                                                           //Alterar fechamento de caixa do portador
                                                           TCN_FechamentoCaixa.Gravar(p, qtb_caixa.Banco_Dados);
                                                       }
                                                       else if (p.Vl_liquido < p.Vl_auditado)
                                                       {
                                                           if (string.IsNullOrEmpty(lCfg[0].Cd_historico_faltacaixa))
                                                               throw new Exception("Não existe historico de falta de caixa configurado.");
                                                           //Gravar Caixa
                                                           string ret_caixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                               new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                               {
                                                                                   Cd_Empresa = lCfg[0].Cd_empresa,
                                                                                   Cd_ContaGer = lCfg[0].Cd_contacaixa,
                                                                                   Cd_Historico = lCfg[0].Cd_historico_faltacaixa,
                                                                                   Cd_LanctoCaixa = decimal.Zero,
                                                                                   ComplHistorico = "FALTA CAIXA OPERACIONAL Nº" + val.Id_caixastr + " PORTADOR " + p.Ds_portador,
                                                                                   NM_Clifor = string.Empty,
                                                                                   Dt_lancto = dt_transf,
                                                                                   Nr_Docto = "CAIXA Nº" + val.Id_caixastr,
                                                                                   St_Estorno = "N",
                                                                                   St_Titulo = "N",
                                                                                   Vl_PAGAR = decimal.Zero,
                                                                                   Vl_RECEBER = Math.Abs(p.Vl_liquido - p.Vl_auditado)
                                                                               }, qtb_caixa.Banco_Dados);
                                                           p.Cd_contager = lCfg[0].Cd_contacaixa;
                                                           p.Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA"));
                                                           //Alterar fechamento caixa do portador
                                                           TCN_FechamentoCaixa.Gravar(p, qtb_caixa.Banco_Dados);
                                                       }
                                                   }
                                                   else if (p.St_cartao)
                                                   {
                                                       if (string.IsNullOrEmpty(lCfg[0].Cd_contacartao))
                                                           throw new Exception("Não existe conta gerencial cartão para processar fechamento do portador " + p.Ds_portador);

                                                       //Buscar todas as faturas de cartao amarrado ao caixa
                                                       new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao(qtb_caixa.Banco_Dados).Select(
                                                           new Utils.TpBusca[]
                                                           {
                                                               new Utils.TpBusca()
                                                               {
                                                                   vNM_Campo = string.Empty,
                                                                   vOperador = string.Empty,
                                                                   vVL_Busca = "(exists(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                                               "inner join TB_FIN_Caixa y " +
                                                                               "on x.CD_ContaGer = y.CD_ContaGer " + 
                                                                               "and x.CD_LanctoCaixa = y.CD_LanctoCaixa " +
                                                                               "inner join TB_PDV_Cupom_X_MovCaixa z " +
                                                                               "on y.CD_ContaGer = z.CD_ContaGer " +
                                                                               "and y.CD_LanctoCaixa = z.CD_LanctoCaixa " +
                                                                               "where x.ID_Fatura = a.ID_Fatura " +
                                                                               "and z.ID_Caixa = " + val.Id_caixastr + ") or " +
                                                                               "exists(select 1 from tb_fin_faturacartao_x_caixa x " +
                                                                               "inner join tb_fin_liquidacao y " +
                                                                               "on x.cd_contager = y.cd_contager " + 
                                                                               "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                                               "inner join tb_pdv_caixa_x_liquidacao z " +
                                                                               "on y.cd_empresa = z.cd_empresa " +
                                                                               "and y.nr_lancto = z.nr_lancto " +
                                                                               "and y.cd_parcela = z.cd_parcela " +
                                                                               "and y.id_liquid = z.id_liquid " +
                                                                               "where x.id_fatura = a.id_fatura " +
                                                                               "and z.id_caixa = " + val.Id_caixastr + ") or " +
                                                                               "exists(select 1 from tb_pdv_trocaespecie x " +
                                                                               "where x.id_fatura = a.id_fatura " +
                                                                               "and x.id_caixa = " + val.Id_caixastr + "))"
                                                               }
                                                           }, 0, string.Empty, string.Empty).ForEach(v =>
                                                               {
                                                                   //Buscar lancamento de caixa da fatura
                                                                       new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(qtb_caixa.Banco_Dados).Select(
                                                                       new Utils.TpBusca[]
                                                                       {
                                                                           new Utils.TpBusca()
                                                                           {
                                                                               vNM_Campo = string.Empty,
                                                                               vOperador = "exists",
                                                                               vVL_Busca = "(select 1 from tb_fin_faturacartao_x_caixa x " +
                                                                                           "where x.cd_contager = a.cd_contager " +
                                                                                           "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                                                           "and x.cd_contager <> '" + lCfg[0].Cd_contacartao.Trim() + "' " +
                                                                                           "and x.id_fatura = " + v.Id_fatura.Value.ToString() + ")"
                                                                           }
                                                                       }, 0, string.Empty).ForEach(c =>
                                                                           {
                                                                               //Gravar transferencia de caixa
                                                                               CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa rTransf = new CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa();
                                                                               rTransf.CD_ContaGer_Entrada = c.Vl_RECEBER > decimal.Zero ? lCfg[0].Cd_contacartao : lCfg[0].Cd_contaoperacional;
                                                                               rTransf.CD_ContaGer_Saida = c.Vl_RECEBER > decimal.Zero ? lCfg[0].Cd_contaoperacional : lCfg[0].Cd_contacartao;
                                                                               rTransf.CD_Empresa = lCfg[0].Cd_empresa;
                                                                               rTransf.CD_Historico = lCfg[0].Cd_historico_transf;
                                                                               rTransf.Complemento = "FECHAMENTO CAIXA OPERACIONAL Nº" + val.Id_caixastr;
                                                                               rTransf.Valor_Transferencia = c.Vl_RECEBER > decimal.Zero ? c.Vl_RECEBER : c.Vl_PAGAR;
                                                                               rTransf.DT_Lancto = dt_transf;
                                                                               rTransf.NR_Docto = "CAIXA Nº" + val.Id_caixastr;
                                                                               CamadaNegocio.Financeiro.Caixa.TCN_Lan_Transfere_Caixa.Transfere_Caixa(rTransf, qtb_caixa.Banco_Dados);
                                                                               //Gravar fatura cartao x novo lancamento caixa
                                                                               CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao_X_Caixa.Gravar(
                                                                                   new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao_X_Caixa()
                                                                                   {
                                                                                       Cd_contager = c.Vl_RECEBER > decimal.Zero ? lCfg[0].Cd_contaoperacional : lCfg[0].Cd_contacartao,
                                                                                       Cd_lanctocaixa = rTransf.CD_LANCTOCAIXA_SAI,
                                                                                       Id_fatura = v.Id_fatura
                                                                                   }, qtb_caixa.Banco_Dados);

                                                                               CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao_X_Caixa.Gravar(
                                                                                   new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao_X_Caixa()
                                                                                   {
                                                                                       Cd_contager = c.Vl_RECEBER > decimal.Zero ? lCfg[0].Cd_contacartao : lCfg[0].Cd_contaoperacional,
                                                                                       Cd_lanctocaixa = rTransf.CD_LANCTOCAIXA_ENT,
                                                                                       Id_fatura = v.Id_fatura
                                                                                   }, qtb_caixa.Banco_Dados);
                                                                           });
                                                               });
                                                   }
                                                   else
                                                   {
                                                       //Transferencia de caixa com o saldo dos outros portadores
                                                       CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa rTransf = new CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa();
                                                       rTransf.CD_ContaGer_Entrada = lCfg[0].Cd_contacaixa;
                                                       rTransf.CD_ContaGer_Saida = lCfg[0].Cd_contaoperacional;
                                                       rTransf.CD_Empresa = lCfg[0].Cd_empresa;
                                                       rTransf.CD_Historico = lCfg[0].Cd_historico_transf;
                                                       rTransf.Complemento = "FECHAMENTO CAIXA OPERACIONAL Nº" + val.Id_caixastr;
                                                       rTransf.Valor_Transferencia = p.Vl_liquido;
                                                       rTransf.DT_Lancto = dt_transf;
                                                       rTransf.NR_Docto = "CAIXA Nº" + val.Id_caixastr;
                                                       CamadaNegocio.Financeiro.Caixa.TCN_Lan_Transfere_Caixa.Transfere_Caixa(rTransf, qtb_caixa.Banco_Dados);
                                                       p.Id_transf = rTransf.ID_TRANSF;
                                                       //Apurar diferenca entre valor movimento e valor auditado
                                                       if (p.Vl_liquido > p.Vl_auditado)
                                                       {
                                                           if (string.IsNullOrEmpty(lCfg[0].Cd_historico_sobracaixa))
                                                               throw new Exception("Não existe historico de sobra de caixa configurado.");
                                                           //Gravar Caixa
                                                           string ret_caixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                               new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                               {
                                                                                   Cd_Empresa = lCfg[0].Cd_empresa,
                                                                                   Cd_ContaGer = lCfg[0].Cd_contacaixa,
                                                                                   Cd_Historico = lCfg[0].Cd_historico_sobracaixa,
                                                                                   Cd_LanctoCaixa = decimal.Zero,
                                                                                   ComplHistorico = "SOBRA CAIXA OPERACIONAL Nº" + val.Id_caixastr + " PORTADOR " + p.Ds_portador,
                                                                                   NM_Clifor = string.Empty,
                                                                                   Dt_lancto = dt_transf,
                                                                                   Nr_Docto = "CAIXA Nº" + val.Id_caixastr,
                                                                                   St_Estorno = "N",
                                                                                   St_Titulo = "N",
                                                                                   Vl_PAGAR = p.Vl_liquido - p.Vl_auditado,
                                                                                   Vl_RECEBER = decimal.Zero
                                                                               }, qtb_caixa.Banco_Dados);
                                                           p.Cd_contager = lCfg[0].Cd_contacaixa;
                                                           p.Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA"));
                                                           //Alterar fechamento caixa do portador
                                                           TCN_FechamentoCaixa.Gravar(p, qtb_caixa.Banco_Dados);
                                                       }
                                                       else if (p.Vl_liquido < p.Vl_auditado)
                                                       {
                                                           if (string.IsNullOrEmpty(lCfg[0].Cd_historico_faltacaixa))
                                                               throw new Exception("Não existe historico de falta de caixa configurado.");
                                                           //Gravar Caixa
                                                           string ret_caixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                               new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                               {
                                                                                   Cd_Empresa = lCfg[0].Cd_empresa,
                                                                                   Cd_ContaGer = lCfg[0].Cd_contacaixa,
                                                                                   Cd_Historico = lCfg[0].Cd_historico_faltacaixa,
                                                                                   Cd_LanctoCaixa = decimal.Zero,
                                                                                   ComplHistorico = "FALTA CAIXA OPERACIONAL Nº" + val.Id_caixastr + " PORTADOR " + p.Ds_portador,
                                                                                   NM_Clifor = string.Empty,
                                                                                   Dt_lancto = dt_transf,
                                                                                   Nr_Docto = "CAIXA Nº" + val.Id_caixastr,
                                                                                   St_Estorno = "N",
                                                                                   St_Titulo = "N",
                                                                                   Vl_PAGAR = decimal.Zero,
                                                                                   Vl_RECEBER = Math.Abs(p.Vl_liquido - p.Vl_auditado)
                                                                               }, qtb_caixa.Banco_Dados);
                                                           p.Cd_contager = lCfg[0].Cd_contacaixa;
                                                           p.Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA"));
                                                           //Alterar fechamento caixa do portador
                                                           TCN_FechamentoCaixa.Gravar(p, qtb_caixa.Banco_Dados);
                                                       }
                                                   }
                                               });
                //Processar Cheque Troco
                TCN_TrocoCH.Buscar(string.Empty,
                                   string.Empty,                
                                   val.Id_caixastr,
                                   string.Empty,
                                   string.Empty,
                                   string.Empty,
                                   qtb_caixa.Banco_Dados).ForEach(p =>
                                         {
                                             //Buscar Titulo
                                             CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rCh =
                                                 CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.Busca(p.Cd_empresa,
                                                                                                     p.Nr_lanctocheque.Value,
                                                                                                     p.Cd_banco,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     decimal.Zero,
                                                                                                     decimal.Zero,
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
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     1,
                                                                                                     string.Empty,
                                                                                                     qtb_caixa.Banco_Dados)[0];
                                             if (rCh.Tp_titulo.Trim().ToUpper().Equals("R"))//Repasse de Cheque
                                             {
                                                 rCh.Cd_contager_destino = lCfg[0].Cd_contacaixa;
                                                 rCh.Dt_compensacao = dt_transf;
                                                 rCh.Status_compensado = "R";
                                                 CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.CompensarCheques(
                                                     new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo() { rCh }, qtb_caixa.Banco_Dados);
                                                 //Lancamento de caixa de repasse de cheque
                                                 string retorno = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                     new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                     {
                                                         Cd_Empresa = lCfg[0].Cd_empresa,
                                                         Cd_ContaGer = lCfg[0].Cd_contacaixa,
                                                         Cd_Historico = lCfg[0].Cd_historico,
                                                         ComplHistorico = "REPASSE DE CHEQUE Nº" + rCh.Nr_cheque,
                                                         NM_Clifor = rCh.Nomeclifor,
                                                         Dt_lancto = dt_transf,
                                                         Nr_Docto = "CH" + rCh.Nr_cheque,
                                                         St_Estorno = "N",
                                                         St_Titulo = "N",
                                                         Vl_PAGAR = rCh.Vl_titulo,
                                                         Vl_RECEBER = decimal.Zero
                                                     }, qtb_caixa.Banco_Dados);
                                                 //Gravar repasse
                                                 CamadaNegocio.Financeiro.Titulo.TCN_Rastreab_ChTerceiro.GravarRastreab_ChTerceiro(
                                                     new CamadaDados.Financeiro.Titulo.TRegistro_Rastreab_ChTerceiro()
                                                     {
                                                         Cd_banco = p.Cd_banco,
                                                         Cd_clifor_origem = p.Cd_clifor,
                                                         Cd_empresa = p.Cd_empresa,
                                                         Nr_lanctocheque = rCh.Nr_lanctocheque,
                                                         Cd_contager = lCfg[0].Cd_contacaixa,
                                                         Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_LANCTOCAIXA")),
                                                         Tp_registro = "D"
                                                     }, qtb_caixa.Banco_Dados);
                                             }
                                             else//Processar Cheque Troco
                                             {
                                                 rCh.Status_compensado = rCh.Status_compensado.ToUpper().Trim().Equals("S") ? "S" : "N";
                                                 rCh.Nomeclifor = p.Nm_clifor;
                                                 rCh.Nr_cgccpf = p.Nr_cgccpf;
                                                 CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.AlterarTitulo(rCh, qtb_caixa.Banco_Dados);
                                             }
                                         });
                //Gravar Caixa Operacional
                val.St_registro = "P";
                qtb_caixa.Gravar(val);
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }
    }

    public class TCN_FechamentoCaixa
    {
        public static TList_FechamentoCaixa Buscar(string Id_caixa,
                                                   string Cd_portador,
                                                   string St_registro,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            if (!string.IsNullOrEmpty(Cd_portador))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_portador";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_portador.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            
            return new TCD_FechamentoCaixa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FechamentoCaixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FechamentoCaixa qtb_fechamento = new TCD_FechamentoCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fechamento.CriarBanco_Dados(true);
                else
                    qtb_fechamento.Banco_Dados = banco;
                string retorno = qtb_fechamento.Gravar(val);
                if (st_transacao)
                    qtb_fechamento.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fechamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar fechamento caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fechamento.deletarBanco_Dados();
            }
        }

        public static string Cancelar(TRegistro_FechamentoCaixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FechamentoCaixa qtb_fechamento = new TCD_FechamentoCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fechamento.CriarBanco_Dados(true);
                else
                    qtb_fechamento.Banco_Dados = banco;
                val.St_registro = "C";
                val.Loginaudit = Utils.Parametros.pubLogin;
                string retorno = qtb_fechamento.Gravar(val);
                if (st_transacao)
                    qtb_fechamento.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fechamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar fechamento caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fechamento.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FechamentoCaixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FechamentoCaixa qtb_fechamento = new TCD_FechamentoCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fechamento.CriarBanco_Dados(true);
                else
                    qtb_fechamento.Banco_Dados = banco;
                qtb_fechamento.Excluir(val);
                if (st_transacao)
                    qtb_fechamento.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fechamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir fechamento caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fechamento.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ProcCaixa_X_Cheque
    {
        public static TList_ProcCaixa_X_Cheque Buscar(string Id_caixa,
                                                      string Cd_empresa,
                                                      string Nr_lanctocheque,
                                                      string Cd_banco,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctocheque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctocheque;
            }
            if (!string.IsNullOrEmpty(Cd_banco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            return new TCD_ProcCaixa_X_Cheque(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ProcCaixa_X_Cheque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProcCaixa_X_Cheque qtb_proc = new TCD_ProcCaixa_X_Cheque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_proc.CriarBanco_Dados(true);
                else
                    qtb_proc.Banco_Dados = banco;
                string retorno = qtb_proc.Gravar(val);
                if (st_transacao)
                    qtb_proc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_proc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_proc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ProcCaixa_X_Cheque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProcCaixa_X_Cheque qtb_proc = new TCD_ProcCaixa_X_Cheque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_proc.CriarBanco_Dados(true);
                else
                    qtb_proc.Banco_Dados = banco;
                qtb_proc.Excluir(val);
                if (st_transacao)
                    qtb_proc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_proc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_proc.deletarBanco_Dados();
            }
        }
    }

    public class TCN_RetiradaCaixa
    {
        public static TList_RetiradaCaixa Buscar(string Id_retirada,
                                                 string Id_caixa,
                                                 string Tp_registro,
                                                 string St_registro,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_retirada))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_retirada";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_retirada;
            }
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            if (!string.IsNullOrEmpty(Tp_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_registro.Trim() + "'";
            }
            return new TCD_RetiradaCaixa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_RetiradaCaixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RetiradaCaixa qtb_ret = new TCD_RetiradaCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ret.CriarBanco_Dados(true);
                else
                    qtb_ret.Banco_Dados = banco;
                val.Id_retiradastr = CamadaDados.TDataQuery.getPubVariavel(qtb_ret.Gravar(val), "@P_ID_RETIRADA");
                bool st_processar = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("PROC_RETIRADA", qtb_ret.Banco_Dados);
                if (st_processar)
                {
                    if (val.lPortador.Count > 0)
                        ProcessarRetirada(val, qtb_ret.Banco_Dados);
                }
                if (st_transacao)
                    qtb_ret.Banco_Dados.Commit_Tran();
                return val.Id_retiradastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ret.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar retirada: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ret.deletarBanco_Dados();
            }
        }

        public static void Cancelar(TRegistro_RetiradaCaixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RetiradaCaixa qtb_ret = new TCD_RetiradaCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ret.CriarBanco_Dados(true);
                else
                    qtb_ret.Banco_Dados = banco;
                val.St_registro = "C";
                Gravar(val, qtb_ret.Banco_Dados);
                if (st_transacao)
                    qtb_ret.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ret.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar retirada: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ret.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_RetiradaCaixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RetiradaCaixa qtb_ret = new TCD_RetiradaCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ret.CriarBanco_Dados(true);
                else
                    qtb_ret.Banco_Dados = banco;
                qtb_ret.Excluir(val);
                if (st_transacao)
                    qtb_ret.Banco_Dados.Commit_Tran();
                return val.Id_retiradastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ret.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir retirada: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ret.deletarBanco_Dados();
            }
        }

        public static void ProcessarRetirada(TRegistro_RetiradaCaixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RetiradaCaixa qtb_ret = new TCD_RetiradaCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ret.CriarBanco_Dados(true);
                else
                    qtb_ret.Banco_Dados = banco;
                //Buscar configuracao da empresa
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(val.Cd_empresa, null);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração para a empresa " + val.Cd_empresa);
                val.lPortador.ForEach(p =>
                    {
                        if (p.St_controletitulobool)
                        {
                            //Data transf
                            DateTime dt_transf = CamadaDados.UtilData.Data_Servidor(qtb_ret.Banco_Dados);
                            p.lCheque.ForEach(v =>
                                {
                                    //Transferir CC do Titulo
                                    v.Dt_compensacao = dt_transf;
                                    v.Cd_contager_destino = val.Tp_registro.Trim().ToUpper().Equals("R") ? lCfg[0].Cd_contacaixa : lCfg[0].Cd_contaoperacional;
                                    CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.TransferirTitulo(v, qtb_ret.Banco_Dados);
                                    //Retirada X Cheque
                                    TCN_Retirada_X_Cheque.Gravar(new TRegistro_Retirada_X_Cheque()
                                    {
                                        Cd_banco = v.Cd_banco,
                                        Cd_empresa = v.Cd_empresa,
                                        Nr_lanctocheque = v.Nr_lanctocheque,
                                        Id_retirada = val.Id_retirada
                                    }, qtb_ret.Banco_Dados);
                                });
                            //Alterar retirada
                            val.St_registro = "P";
                            qtb_ret.Gravar(val);
                        }
                        else
                        {
                            //Transferir valor da conta PDV para conta Caixa
                            CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa rTransf = new CamadaDados.Financeiro.Caixa.TRegistro_Lan_Transfere_Caixa();
                            rTransf.CD_ContaGer_Entrada = val.Tp_registro.Trim().ToUpper().Equals("R") ? lCfg[0].Cd_contacaixa : lCfg[0].Cd_contaoperacional;
                            rTransf.CD_ContaGer_Saida = val.Tp_registro.Trim().ToUpper().Equals("R") ? lCfg[0].Cd_contaoperacional : lCfg[0].Cd_contacaixa;
                            rTransf.CD_Empresa = lCfg[0].Cd_empresa;
                            rTransf.CD_Historico = lCfg[0].Cd_historico_ret;
                            rTransf.Complemento = val.Ds_observacao;
                            rTransf.Valor_Transferencia = p.Vl_pagtoPDV;
                            rTransf.DT_Lancto = CamadaDados.UtilData.Data_Servidor(qtb_ret.Banco_Dados);
                            rTransf.NR_Docto = "RET Nº" + val.Id_retiradastr;
                            CamadaNegocio.Financeiro.Caixa.TCN_Lan_Transfere_Caixa.Transfere_Caixa(rTransf, qtb_ret.Banco_Dados);
                            //Alterar retirada
                            val.Id_transf = rTransf.ID_TRANSF;
                            val.St_registro = "P";
                            qtb_ret.Gravar(val);
                        }
                    });
                if (st_transacao)
                    qtb_ret.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ret.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar retirada: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ret.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Retirada_X_Cheque
    {
        public static TList_Retirada_X_Cheque Buscar(string Id_retirada,
                                                     string Cd_empresa,
                                                     string Cd_banco,
                                                     string Nr_lanctocheque,
                                                     BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_retirada))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_retirada";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_retirada;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_banco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctocheque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctocheque;
            }
            return new TCD_Retirada_X_Cheque(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Titulo.TList_RegLanTitulo BuscarCh(string Id_retirada,
                                                                                BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Titulo.TCD_LanTitulo(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdv_retirada_x_cheque x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_banco = a.cd_banco " +
                                    "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                    "and x.id_retirada = " + Id_retirada + ")"
                    }
                }, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_Retirada_X_Cheque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Retirada_X_Cheque qtb_ret = new TCD_Retirada_X_Cheque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ret.CriarBanco_Dados(true);
                else
                    qtb_ret.Banco_Dados = banco;
                string retorno = qtb_ret.Gravar(val);
                if (st_transacao)
                    qtb_ret.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ret.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ret.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Retirada_X_Cheque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Retirada_X_Cheque qtb_ret = new TCD_Retirada_X_Cheque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ret.CriarBanco_Dados(true);
                else
                    qtb_ret.Banco_Dados = banco;
                qtb_ret.Excluir(val);
                if (st_transacao)
                    qtb_ret.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ret.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ret.Banco_Dados.RollBack_Tran();
            }
        }
    }

    public class TCN_Caixa_X_Liquidacao
    {
        public static TList_Caixa_X_Liquidacao Buscar(string Id_caixa,
                                                      string Cd_empresa,
                                                      string Nr_lancto,
                                                      string Cd_parcela,
                                                      string Id_liquid,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
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
            if (!string.IsNullOrEmpty(Cd_parcela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_parcela;
            }
            if (!string.IsNullOrEmpty(Id_liquid))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_liquid";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_liquid;
            }
            return new TCD_Caixa_X_Liquidacao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Caixa_X_Liquidacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Caixa_X_Liquidacao qtb_caixa = new TCD_Caixa_X_Liquidacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                string retorno = qtb_caixa.Gravar(val);
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar liquidação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Caixa_X_Liquidacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Caixa_X_Liquidacao qtb_caixa = new TCD_Caixa_X_Liquidacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else
                    qtb_caixa.Banco_Dados = banco;
                qtb_caixa.Excluir(val);
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir liquidação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Caixa_X_DevCredAvulso
    {
        public static TList_Caixa_X_DevCredAvulso Buscar(string Id_devcred,
                                                         string Id_caixa,
                                                         string Id_adto,
                                                         string Cd_lanctocaixa,
                                                         string Cd_contager,
                                                         BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_devcred))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_devcred";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_devcred;
            }
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            if (!string.IsNullOrEmpty(Id_adto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_adto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_adto;
            }
            if (!string.IsNullOrEmpty(Cd_lanctocaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa;
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            return new TCD_Caixa_X_DevCredAvulso(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Caixa_X_DevCredAvulso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Caixa_X_DevCredAvulso qtb_caixa = new TCD_Caixa_X_DevCredAvulso();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else qtb_caixa.Banco_Dados = banco;
                val.Id_devcredstr = CamadaDados.TDataQuery.getPubVariavel(qtb_caixa.Gravar(val), "@P_ID_DEVCRED");
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
                return val.Id_devcredstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Caixa_X_DevCredAvulso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Caixa_X_DevCredAvulso qtb_caixa = new TCD_Caixa_X_DevCredAvulso();
            try
            {
                if (banco == null)
                    st_transacao = qtb_caixa.CriarBanco_Dados(true);
                else qtb_caixa.Banco_Dados = banco;
                qtb_caixa.Excluir(val);
                if (st_transacao)
                    qtb_caixa.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_caixa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_caixa.deletarBanco_Dados();
            }
        }

        public static void DevolverCredito(TRegistro_Caixa_X_DevCredAvulso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Caixa_X_DevCredAvulso qtb_cx = new TCD_Caixa_X_DevCredAvulso();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cx.CriarBanco_Dados(true);
                else qtb_cx.Banco_Dados = banco;
                //Gravar Caixa Devolucao
                //Buscar configuracao adiantamento
                CamadaDados.Financeiro.Cadastros.TList_ConfigAdto lConfig =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1,
                                                                                string.Empty,
                                                                                qtb_cx.Banco_Dados);
                if (lConfig.Count == 0)
                    throw new Exception("Não existe configuração adiantamento para a empresa " + val.Cd_empresa.Trim());
                if (string.IsNullOrEmpty(lConfig[0].Cd_historico_DEVADTO_R))
                    throw new Exception("Não existe histórico de devolução adiantamento RECEBIDO para a empresa " + val.Cd_empresa.Trim());
               CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa rCaixa = new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa();
                rCaixa.Cd_ContaGer = val.rAdto.Cd_contager_qt;
                rCaixa.Cd_Empresa = val.rAdto.Cd_empresa;
                rCaixa.Nr_Docto = "DEV" + val.rAdto.Id_adto.ToString();
                rCaixa.Cd_Historico = lConfig[0].Cd_historico_DEVADTO_R;
                rCaixa.Login = Utils.Parametros.pubLogin;
                rCaixa.ComplHistorico = "DEVOLUCAO ADIANTAMENTO " + val.rAdto.Id_adto.ToString();
                rCaixa.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                rCaixa.Vl_PAGAR = val.rAdto.Vl_processar;
                rCaixa.Vl_RECEBER = decimal.Zero;
                rCaixa.St_Titulo = "N";
                rCaixa.St_Estorno = "N";
                rCaixa.NM_Clifor = val.rAdto.Nm_clifor;
                CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(rCaixa, qtb_cx.Banco_Dados);
                //Gravar Adiantamento X Caixa
                CamadaNegocio.Financeiro.Adiantamento. TCN_LanAdiantamentoXCaixa.Gravar(
                    new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamentoXCaixa()
                    {
                        Cd_contager = val.rAdto.Cd_contager_qt,
                        Cd_lanctocaixa = rCaixa.Cd_LanctoCaixa,
                        Id_adto = val.rAdto.Id_adto
                    }, qtb_cx.Banco_Dados);
                //Gravar Dev Cred Avulso
                val.Id_adto = val.rAdto.Id_adto;
                val.Cd_contager = rCaixa.Cd_ContaGer;
                val.Cd_lanctocaixa = rCaixa.Cd_LanctoCaixa;
                val.Id_devcredstr = CamadaDados.TDataQuery.getPubVariavel(qtb_cx.Gravar(val), "@P_ID_DEVCRED");
                if (val.lDevCHP != null)
                {
                    //Gravar troco cheque proprio
                    val.lDevCHP.ForEach(v =>
                    {
                        if (v.Tp_titulo.Trim().ToUpper().Equals("P") && v.Nr_lanctocheque.Equals(decimal.Zero))
                        {
                            v.St_lancarcaixa = true;
                            v.Status_compensado = "T";
                            CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.GravarTitulo(v, qtb_cx.Banco_Dados);
                        }
                        //Gravar Troco CH
                        TCN_TrocoCH.Gravar(new TRegistro_TrocoCH()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_caixa = val.Id_caixa,
                            Nr_lanctocheque = v.Nr_lanctocheque,
                            Cd_banco = v.Cd_banco,
                            Id_devcred = val.Id_devcred
                        }, qtb_cx.Banco_Dados);
                    });
                }
                if (val.lDevCHT != null)
                {
                    val.lDevCHT.ForEach(v =>
                    {
                        //Gravar Troco CH
                        TCN_TrocoCH.Gravar(new TRegistro_TrocoCH()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_caixa = val.Id_caixa,
                            Nr_lanctocheque = v.Nr_lanctocheque,
                            Cd_banco = v.Cd_banco,
                            Id_devcred = val.Id_devcred
                        }, qtb_cx.Banco_Dados);
                    });
                }
                if (st_transacao)
                    qtb_cx.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cx.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro devolver credito: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cx.deletarBanco_Dados();
            }
        }

        public static void EstornarDevCredito(TRegistro_Caixa_X_DevCredAvulso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Caixa_X_DevCredAvulso qtb_cx = new TCD_Caixa_X_DevCredAvulso();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cx.CriarBanco_Dados(true);
                else qtb_cx.Banco_Dados = banco;
                //Estornar cheque troco
                new TCD_TrocoCH(qtb_cx.Banco_Dados).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_devcred",
                            vOperador = "=",
                            vVL_Busca = val.Id_devcredstr
                        }
                    }, 0, string.Empty).ForEach(p => TCN_TrocoCH.Excluir(p, qtb_cx.Banco_Dados));
                //Estornar caixa devolucao credito
                CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarSomenteCaixa(
                    CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.Busca(val.Cd_contager,
                                                                      val.Cd_lanctocaixastr,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      decimal.Zero,
                                                                      decimal.Zero,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      false,
                                                                      string.Empty,
                                                                      decimal.Zero,
                                                                      false,
                                                                      qtb_cx.Banco_Dados)[0], qtb_cx.Banco_Dados);
                //Estornar caixa x dev avulso
                qtb_cx.Excluir(val);
                if (st_transacao)
                    qtb_cx.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cx.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar devolução: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cx.deletarBanco_Dados();
            }
        }
    }
}
