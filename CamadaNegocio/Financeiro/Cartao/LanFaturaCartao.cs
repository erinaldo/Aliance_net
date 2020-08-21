using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cartao;
using CamadaNegocio.Financeiro.Caixa;
using CamadaDados.Financeiro.Caixa;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cartao
{
    #region Fatura Cartao
    public class TCN_FaturaCartao
    {
        public static TList_FaturaCartao Buscar(string Id_fatura,
                                                string Cd_empresa,
                                                string Nr_cartao,
                                                string Id_bandeira,
                                                string Id_maquina,
                                                string Nomeusuario,
                                                string Tp_cartao,
                                                string Tp_movimento,
                                                string Nr_autorizacao,
                                                string Cd_contager,
                                                string Cd_domiciliobancario,
                                                string Tp_data,
                                                string Dt_ini,
                                                string Dt_fin,
                                                decimal Vl_ini,
                                                decimal Vl_fin,
                                                bool St_PrePago,
                                                string Status,
                                                string vOrder,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_fatura))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_fatura";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_fatura;
            }   
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_cartao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_cartao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nr_cartao.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Id_bandeira))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_bandeira";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_bandeira;
            }
            if(!string.IsNullOrEmpty(Id_maquina))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_maquina";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_maquina;
            }
            if (!string.IsNullOrEmpty(Nomeusuario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nomeusuario";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nomeusuario.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Tp_cartao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.tp_cartao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_cartao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_movimento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_autorizacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_autorizacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_autorizacao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_domiciliobancario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "d.cd_domiciliobancario";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_domiciliobancario.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("F") ? "a.DT_Emissao" : "a.dt_vencto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("F") ? "a.DT_Emissao" : "a.dt_vencto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (Vl_ini > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "(a.vl_nominal + a.vl_juro)";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = Vl_ini.ToString(new System.Globalization.CultureInfo("en-US"));
            }
            if (Vl_fin > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "(a.vl_nominal + a.vl_juro)";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = Vl_fin.ToString(new System.Globalization.CultureInfo("en-US"));
            }
            if (St_PrePago)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(f.ST_PrePago, 'N')";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (!string.IsNullOrEmpty(Status))
            {
                if (Status.Trim().ToUpper().Equals("A") ||
                    Status.Trim().ToUpper().Equals("Q"))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = string.Empty;
                    filtro[filtro.Length - 1].vVL_Busca = Status.Trim().ToUpper().Equals("A") ? "((a.vl_nominal + a.vl_juro) - case when isnull(d.pc_taxa, 0) > 0 then ((a.vl_nominal + a.vl_juro - a.vl_quitado) * (d.pc_taxa / 100)) else 0 end - a.vl_quitado) > 0" : "((a.vl_nominal + a.vl_juro) - a.vl_quitado) = 0";
                }
            }
            return new TCD_FaturaCartao(banco).Select(filtro, 0, string.Empty, vOrder);
        }

        public static string Gravar(TRegistro_FaturaCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturaCartao qtb_fatura = new TCD_FaturaCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatura.CriarBanco_Dados(true);
                else
                    qtb_fatura.Banco_Dados = banco;
                string retorno = qtb_fatura.Gravar(val);
                val.Id_fatura = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_FATURA"));
                if (!string.IsNullOrEmpty(val.Cd_contager))
                {
                    //Gravar caixa
                    string ret =
                    TCN_LanCaixa.GravaLanCaixa(
                        new TRegistro_LanCaixa()
                        {
                            Cd_ContaGer = val.Cd_contager,
                            Cd_Empresa = val.Cd_empresa,
                            Nr_Docto = "FAT" + val.Id_fatura.Value.ToString(),
                            Cd_Historico = val.Cd_historico,
                            Login = Utils.Parametros.pubLogin,
                            ComplHistorico = "FATURA CARTAO AVULSA",
                            Dt_lancto = val.Dt_fatura,
                            Vl_PAGAR = decimal.Zero,
                            Vl_RECEBER = val.Vl_nominal,
                            St_Titulo = "N",
                            St_Estorno = "N",
                            St_avulso = "N",
                            Id_adto = val.Id_adto
                        }, qtb_fatura.Banco_Dados);
                    //Amarrar caixa com fatura
                    TCN_FaturaCartao_X_Caixa.Gravar(new TRegistro_FaturaCartao_X_Caixa()
                    {
                        Cd_contager = val.Cd_contager,
                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_CD_LANCTOCAIXA")),
                        Id_fatura = val.Id_fatura
                    }, qtb_fatura.Banco_Dados);
                }
                if (st_transacao)
                    qtb_fatura.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatura.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar fatura: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatura.deletarBanco_Dados();
            }
        }

        public static string Gravar(TList_FaturaCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturaCartao qtb_fatura = new TCD_FaturaCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatura.CriarBanco_Dados(true);
                else
                    qtb_fatura.Banco_Dados = banco;
                string retorno = string.Empty;
                val.ForEach(p => retorno += Gravar(p, qtb_fatura.Banco_Dados));
                if (st_transacao)
                    qtb_fatura.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatura.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar fatura: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatura.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FaturaCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturaCartao qtb_fatura = new TCD_FaturaCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatura.CriarBanco_Dados(true);
                else
                    qtb_fatura.Banco_Dados = banco;
                qtb_fatura.Excluir(val);
                if (st_transacao)
                    qtb_fatura.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatura.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir fatura: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatura.deletarBanco_Dados();
            }
        }

        public static void CancelarFatura(TRegistro_FaturaCartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturaCartao qtb_fatura = new TCD_FaturaCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatura.CriarBanco_Dados(true);
                else
                    qtb_fatura.Banco_Dados = banco;
                //Verificar se a fatura possui quitacao
                if (new TCD_QuitarFatura(qtb_fatura.Banco_Dados).BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_fatura",
                            vOperador = "=",
                            vVL_Busca = val.Id_fatura.Value.ToString()
                        }
                    }, string.Empty) != null)
                    throw new Exception("Fatura cartão possui quitação. Obrigatorio extornar primeiro quitação.");
                //Buscar lista de caixa da fatura
                TList_LanCaixa lCaixa =
                    new TCD_LanCaixa(qtb_fatura.Banco_Dados).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_faturacartao_x_caixa x " + 
                                        "where x.cd_contager = a.cd_contager " +
                                        "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                        "and x.id_fatura = " + val.Id_fatura.Value.ToString() + ")"
                        }
                    }, 0, string.Empty);
                //Excluir caixa
                lCaixa.ForEach(p =>
                    TCN_FaturaCartao_X_Caixa.Excluir(new TRegistro_FaturaCartao_X_Caixa()
                    {
                        Cd_contager = p.Cd_ContaGer,
                        Cd_lanctocaixa = p.Cd_LanctoCaixa,
                        Id_fatura = val.Id_fatura
                    }, qtb_fatura.Banco_Dados));
                //Excluir fatura
                Excluir(val, qtb_fatura.Banco_Dados);
                //Cancelar lancamentos de caixa
                lCaixa.ForEach(p =>
                    {
                        if (p.St_Estorno.Trim().ToUpper() != "S")
                            CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarCaixa(p, null, qtb_fatura.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_fatura.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatura.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar fatura: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatura.deletarBanco_Dados();
            }
        }

        public static void QuitarFatura(List<TRegistro_FaturaCartao> val,
                                        DateTime Dt_quitacao,
                                        string Cd_contager,
                                        string Cd_empresa,
                                        string Tp_movimento,
                                        BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturaCartao qtb_fatura = new TCD_FaturaCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatura.CriarBanco_Dados(true);
                else
                    qtb_fatura.Banco_Dados = banco;
                //Buscar configuracao para quitar fatura
                TList_CFGFaturaCartao lCfg = TCN_CFGFaturaCartao.Buscar(Cd_empresa,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        qtb_fatura.Banco_Dados);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração para quitar fatura na empresa " + Cd_empresa.Trim());
                //Incluir lancamento de caixa na conta de quitacao
                string cd_lanctocaixa_q = TCN_LanCaixa.GravaLanCaixa(
                    new TRegistro_LanCaixa()
                    {
                        Cd_Empresa = Cd_empresa,
                        Cd_ContaGer = Cd_contager,
                        Nr_Docto = "QUITARFAT",
                        ComplHistorico = "QUITACAO FATURA CARTAO",
                        Dt_lancto = Dt_quitacao,
                        Cd_Historico = Tp_movimento.Trim().ToUpper().Equals("P") ? lCfg[0].Cd_historico_pag : lCfg[0].Cd_historico_rec,
                        Vl_RECEBER = Tp_movimento.Trim().ToUpper().Equals("R") ? val.Sum(p=> p.Vl_nominal - p.Vl_quitado) : decimal.Zero,
                        Vl_PAGAR = Tp_movimento.Trim().ToUpper().Equals("P") ? val.Sum(p=> p.Vl_nominal - p.Vl_quitado) : decimal.Zero,
                        St_Estorno = "N"
                    }, qtb_fatura.Banco_Dados);
                //Gravar Juro
                string cd_lanctocaixajr = string.Empty;
                if (val.Sum(p => p.Vl_juro) > decimal.Zero)
                {
                    if (string.IsNullOrEmpty(lCfg[0].Cd_historico_juro))
                        throw new Exception("Não existe configuração para quitar juro da fatura na empresa " + Cd_empresa.Trim());
                    cd_lanctocaixajr = TCN_LanCaixa.GravaLanCaixa(new TRegistro_LanCaixa()
                                        {
                                            Cd_Empresa = Cd_empresa,
                                            Cd_ContaGer = Cd_contager,
                                            Nr_Docto = "JUROFATURA",
                                            ComplHistorico = "JURO FATURA CARTAO",
                                            Dt_lancto = Dt_quitacao,
                                            Cd_Historico = lCfg[0].Cd_historico_juro,
                                            Vl_RECEBER = decimal.Zero,
                                            Vl_PAGAR = val.Sum(p => p.Vl_juro),
                                            St_Titulo = "N",
                                            St_Estorno = "N"
                                        }, qtb_fatura.Banco_Dados);
                }
                //Gravar Caixa Taxa
                string cd_lanctocaixatx = string.Empty;
                if (val.Sum(p => p.Vl_taxa) > decimal.Zero)
                {
                    if (string.IsNullOrEmpty(lCfg[0].Cd_historico_taxa))
                        throw new Exception("Não existe configuração para quitar taxa da fatura na empresa " + Cd_empresa.Trim());
                    cd_lanctocaixatx = TCN_LanCaixa.GravaLanCaixa(new TRegistro_LanCaixa()
                                        {
                                            Cd_Empresa = Cd_empresa,
                                            Cd_ContaGer = Cd_contager,
                                            Nr_Docto = "TXFATURA",
                                            ComplHistorico = "TAXA FATURA CARTAO",
                                            Dt_lancto = Dt_quitacao,
                                            Cd_Historico = lCfg[0].Cd_historico_taxa,
                                            Vl_RECEBER = decimal.Zero,
                                            Vl_PAGAR = Math.Round(val.Sum(p => p.Vl_taxa), 2),
                                            St_Estorno = "N",
                                            St_Titulo = "N"
                                        }, qtb_fatura.Banco_Dados);
                }
                val.ForEach(p =>
                {
                    if ((p.Vl_fatura - p.Vl_quitado) > decimal.Zero)
                    {
                        if (p.Dt_fatura.Value.Date > Dt_quitacao.Date)
                            throw new Exception("Não é permitido quitar fatura com data de lançamento maior que a data de quitação.");
                        //Incluir lancamento de caixa contrario ao original
                        string cd_lanctocaixa_o = TCN_LanCaixa.GravaLanCaixa(new TRegistro_LanCaixa()
                                                    {
                                                        Cd_Empresa = Cd_empresa,
                                                        Cd_ContaGer = p.Cd_contager,
                                                        Nr_Docto = p.Id_fatura.Value.ToString(),
                                                        Dt_lancto = Dt_quitacao,
                                                        Cd_Historico = p.Tp_movimento.Trim().ToUpper().Equals("P") ? lCfg[0].Cd_historico_pag : lCfg[0].Cd_historico_rec,
                                                        Vl_RECEBER = p.Tp_movimento.Trim().ToUpper().Equals("P") ? p.Vl_fatura - p.Vl_quitado : decimal.Zero,
                                                        Vl_PAGAR = p.Tp_movimento.Trim().ToUpper().Equals("R") ? p.Vl_fatura - p.Vl_quitado : decimal.Zero,
                                                        St_Estorno = "N"
                                                    }, qtb_fatura.Banco_Dados);
                        decimal? cd_tx = null;
                        if (p.Pc_taxa > decimal.Zero)
                            cd_tx = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixatx, "@P_CD_LANCTOCAIXA"));
                        decimal? cd_jr = null;
                        if (!string.IsNullOrEmpty(cd_lanctocaixajr))
                            cd_jr = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixajr, "@P_CD_LANCTOCAIXA"));
                        //Incluir Registo na Tabela de Quitacao
                        TCN_QuitarFatura.Gravar(
                            new TRegistro_Quitarfatura()
                            {
                                Id_quitar = null,
                                Id_fatura = p.Id_fatura,
                                Cd_contager = p.Cd_contager,
                                Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixa_o, "@P_CD_LANCTOCAIXA")),
                                Cd_contagerquit = Cd_contager,
                                Cd_lanctocaixaquit = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixa_q, "@P_CD_LANCTOCAIXA")),
                                Cd_lanctocaixajuro = cd_jr,
                                Cd_lanctocaixatx = cd_tx,
                                Dt_lancto = Dt_quitacao,
                                Vl_quitado = p.Vl_fatura - p.Vl_quitado,
                                Vl_juro = p.Vl_juro,
                                Vl_taxa = p.Vl_taxa
                            }, qtb_fatura.Banco_Dados);
                    }
                });
                if (st_transacao)
                    qtb_fatura.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatura.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro quitar fatura: " + ex.Message.Trim()); 
            }
            finally
            {
                if (st_transacao)
                    qtb_fatura.deletarBanco_Dados();
            }
        }

        public static void EstornarQuitacaoFatura(TRegistro_Quitarfatura val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturaCartao qtb_fatura = new TCD_FaturaCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatura.CriarBanco_Dados(true);
                else
                    qtb_fatura.Banco_Dados = banco;
                //Buscar caixa da quitacao
                string aux = string.Empty;
                string virg = string.Empty;
                if (!string.IsNullOrEmpty(val.Cd_lanctocaixaquitstr))
                {
                    aux = val.Cd_lanctocaixaquitstr;
                    virg = ",";
                }
                if (!string.IsNullOrEmpty(val.Cd_lanctocaixajurostr))
                {
                    aux += virg + val.Cd_lanctocaixajurostr;
                    virg = ",";
                }
                if (!string.IsNullOrEmpty(val.Cd_lanctocaixatxstr))
                    aux += virg + val.Cd_lanctocaixatxstr;
                TList_LanCaixa lCaixa =
                    new TCD_LanCaixa(qtb_fatura.Banco_Dados).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_estorno, 'N')",
                            vOperador = "<>",
                            vVL_Busca = "'S'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "((a.cd_contager = '" + val.Cd_contager.Trim() + "' " +
                                            "and a.cd_lanctocaixa = " + val.Cd_lanctocaixastr + ") or " +
                                            "(a.cd_contager = '" + val.Cd_contagerquit.Trim() + "' " +
                                            "and a.cd_lanctocaixa in(" + aux + ")))"
                        }
                    }, 0, string.Empty);
                //Excluir registro quitacao
                TCN_QuitarFatura.Excluir(val, qtb_fatura.Banco_Dados);
                lCaixa.ForEach(p => CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarCaixa(p, null, qtb_fatura.Banco_Dados));
                if (st_transacao)
                    qtb_fatura.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatura.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar quitação fatura: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatura.deletarBanco_Dados();
            }
        }

        public static string TransferirContaCartao(TList_FaturaCartao lFatura, string Cd_empresa, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturaCartao qtb_fatura = new TCD_FaturaCartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatura.CriarBanco_Dados(true);
                else
                    qtb_fatura.Banco_Dados = banco;
                //Buscar conta gerencial
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(Cd_empresa, qtb_fatura.Banco_Dados);
                if (lCfg.Count < 1)
                    throw new Exception("Não existe configuração ECF para a empresa: " + Cd_empresa.Trim());
                if (string.IsNullOrEmpty(lCfg[0].Cd_contacartao))
                    throw new Exception("Não existe conta gerencial cartão para processar fechamento do portador cartão!");

                lFatura.ForEach(v =>
                    {
                        //Buscar lancamento de caixa da fatura
                        new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(qtb_fatura.Banco_Dados).Select(
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
                                    rTransf.Complemento = "TRANSFERENCIA PARA CONTA CARTÃO" ;
                                    rTransf.Valor_Transferencia = c.Vl_RECEBER > decimal.Zero ? c.Vl_RECEBER : c.Vl_PAGAR;
                                    rTransf.DT_Lancto = CamadaDados.UtilData.Data_Servidor();
                                    rTransf.NR_Docto = "TRANSFERENCIA PARA CONTA CARTÃO";
                                    CamadaNegocio.Financeiro.Caixa.TCN_Lan_Transfere_Caixa.Transfere_Caixa(rTransf, qtb_fatura.Banco_Dados);
                                        //Gravar fatura cartao x novo lancamento caixa
                                        CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao_X_Caixa.Gravar(
                                            new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao_X_Caixa()
                                            {
                                                Cd_contager = c.Vl_RECEBER > decimal.Zero ? lCfg[0].Cd_contaoperacional : lCfg[0].Cd_contacartao,
                                                Cd_lanctocaixa = rTransf.CD_LANCTOCAIXA_SAI,
                                                Id_fatura = v.Id_fatura
                                            }, qtb_fatura.Banco_Dados);

                                    CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao_X_Caixa.Gravar(
                                            new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao_X_Caixa()
                                            {
                                                Cd_contager = c.Vl_RECEBER > decimal.Zero ? lCfg[0].Cd_contacartao : lCfg[0].Cd_contaoperacional,
                                                Cd_lanctocaixa = rTransf.CD_LANCTOCAIXA_ENT,
                                                Id_fatura = v.Id_fatura
                                            }, qtb_fatura.Banco_Dados);
                                });
                    });
                if (st_transacao)
                    qtb_fatura.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatura.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar fatura: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatura.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Fatura Cartao X Caixa
    public class TCN_FaturaCartao_X_Caixa
    {
        public static TList_FaturaCartao_X_Caixa Buscar(string Id_fatura,
                                                        string Cd_contager,
                                                        string Cd_lanctocaixa,
                                                        BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_fatura))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_fatura";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_fatura;
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_lanctocaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa;
            }

            return new TCD_FaturaCartao_X_Caixa(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_LanCaixa BuscarCaixa(string Id_fatura, BancoDados.TObjetoBanco banco)
        {
            return new TCD_LanCaixa(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_faturacartao_x_caixa x " +
                                    "where x.cd_contager = a.cd_contager " +
                                    "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                    "and x.id_fatura = " + Id_fatura + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FaturaCartao_X_Caixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturaCartao_X_Caixa qtb_fatura = new TCD_FaturaCartao_X_Caixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatura.CriarBanco_Dados(true);
                else
                    qtb_fatura.Banco_Dados = banco;
                string retorno = qtb_fatura.Gravar(val);
                if (st_transacao)
                    qtb_fatura.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatura.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar fatura x caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatura.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FaturaCartao_X_Caixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FaturaCartao_X_Caixa qtb_fatura = new TCD_FaturaCartao_X_Caixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fatura.CriarBanco_Dados(true);
                else
                    qtb_fatura.Banco_Dados = banco;
                qtb_fatura.Excluir(val);
                if (st_transacao)
                    qtb_fatura.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fatura.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir fatura x caixa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fatura.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Quitar Fatura
    public class TCN_QuitarFatura
    {
        public static TList_Quitarfatura Buscar(string id_fatura,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_fatura))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_fatura";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_fatura;
            }

            return new TCD_QuitarFatura(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Quitarfatura val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_QuitarFatura qtb_quitar = new TCD_QuitarFatura();
            try
            {
                if (banco == null)
                    st_transacao = qtb_quitar.CriarBanco_Dados(true);
                else
                    qtb_quitar.Banco_Dados = banco;
                string retorno = qtb_quitar.Gravar(val);
                if (st_transacao)
                    qtb_quitar.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_quitar.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar quitação fatura: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_quitar.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Quitarfatura val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_QuitarFatura qtb_quitar = new TCD_QuitarFatura();
            try
            {
                if (banco == null)
                    st_transacao = qtb_quitar.CriarBanco_Dados(true);
                else
                    qtb_quitar.Banco_Dados = banco;
                qtb_quitar.Excluir(val);
                if (st_transacao)
                    qtb_quitar.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_quitar.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir quitação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_quitar.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
