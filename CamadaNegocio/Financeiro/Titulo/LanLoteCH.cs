using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Financeiro.Titulo;

namespace CamadaNegocio.Financeiro.Titulo
{
    #region "Lote Cheque"
    public class TCN_LoteCH
    {
        public static TList_LoteCH Buscar(string Id_lote,
                                          string Cd_empresa,
                                          string Dt_loteIni,
                                          string Dt_loteFin,
                                          string Ds_lote,
                                          string Dt_procIni,
                                          string Dt_procFin,
                                          string St_registro,
                                          string Nr_cheque,
                                          int vTop,
                                          string vNm_campo,
                                          BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Id_lote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if ((Dt_loteIni.Trim() != string.Empty) && (Dt_loteIni.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lote";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_loteIni).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((Dt_loteFin.Trim() != string.Empty) && (Dt_loteFin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lote";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_loteFin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (Ds_lote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_lote";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_lote.Trim() + "%')";
            }
            if ((Dt_procIni.Trim() != string.Empty) && (Dt_procIni.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_processamento";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_procIni).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((Dt_procFin.Trim() != string.Empty) && (Dt_procFin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_processamento";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_procFin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (St_registro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Nr_cheque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_lotech_x_titulo x " +
                                                      "inner join tb_fin_titulo y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lanctocheque = y.nr_lanctocheque " +
                                                      "and x.cd_banco = y.cd_banco " +
                                                      "where x.id_lote = a.id_lote " +
                                                      "and y.nr_cheque = '" + Nr_cheque.Trim() + "')";
            }

            return new TCD_LoteCH(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarLoteCH(TRegistro_LoteCH val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCH qtb_lote = new TCD_LoteCH();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Gravar lote
                string retorno = qtb_lote.GravarLoteCH(val);
                val.Id_lote = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LOTE"));
                //Desamarrar lista de cheques
                val.lChequesesc.ForEach(p => TCN_LoteCH_X_Titulo.DeletarLoteCh_X_Titulo(
                    new TRegistro_LoteCH_X_Titulo()
                    {
                        Cd_banco = p.Cd_banco,
                        Cd_empresa = p.Cd_empresa,
                        Id_lote = val.Id_lote,
                        Nr_lanctocheque = p.Nr_lanctocheque
                    }, qtb_lote.Banco_Dados));
                //Gravar lote x cheques
                val.lCheques.ForEach(p =>
                    {
                        TCN_LoteCH_X_Titulo.GravarLoteCh_X_Titulo(
                            new TRegistro_LoteCH_X_Titulo()
                            {
                                Cd_banco = p.Cd_banco,
                                Cd_empresa = p.Cd_empresa,
                                Id_lote = val.Id_lote,
                                Nr_lanctocheque = p.Nr_lanctocheque
                            }, qtb_lote.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string DeletarLoteCH(TRegistro_LoteCH val, BancoDados.TObjetoBanco banco)
        {
            if (val.St_registro.Trim().ToUpper().Equals("P"))
                throw new Exception("Não é permitido excluir lote <PROCESSADO>.");
            bool st_transacao = false;
            TCD_LoteCH qtb_lote = new TCD_LoteCH();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                if (val.St_registro.Trim().ToUpper().Equals("E"))
                {
                    val.lCheques.ForEach(p =>
                        {
                            //transferir os cheques de volta para a conta de origem
                            CamadaDados.Financeiro.Titulo.TList_TransfTitulo lTransf =
                                CamadaNegocio.Financeiro.Titulo.TCN_TransfTitulo.Buscar(p.Cd_empresa,
                                                                                        string.Empty,
                                                                                        p.Cd_contager,
                                                                                        decimal.Zero,
                                                                                        decimal.Zero,
                                                                                        decimal.Zero,
                                                                                        p.Cd_banco,
                                                                                        1,
                                                                                        string.Empty,
                                                                                        qtb_lote.Banco_Dados);
                            if (lTransf.Count < 1)
                                throw new Exception("Registro transferencia nao encontrado.");
                            //Realizar a transferencia dos cheques entre contas
                            p.Cd_contager_destino = lTransf[0].Cd_conta_orig;
                            p.Dt_compensacao = val.Dt_enviolote;
                            //Setar status do cheque para enviado
                            p.Status_compensado = "N"; //A Compensar
                            TCN_LanTitulo.TransferirTitulo(p, qtb_lote.Banco_Dados);
                            //Gravar somente o cheque sem mecher no lancamento de caixa
                            p.St_lancarcaixa = false;
                            TCN_LanTitulo.GravarTitulo(p, qtb_lote.Banco_Dados);
                            //Deletar amarracao do cheque com o lote
                            TCN_LoteCH_X_Titulo.DeletarLoteCh_X_Titulo(
                                new TRegistro_LoteCH_X_Titulo()
                                {
                                    Cd_banco = p.Cd_banco,
                                    Cd_empresa = p.Cd_empresa,
                                    Id_lote = val.Id_lote,
                                    Nr_lanctocheque = p.Nr_lanctocheque
                                }, qtb_lote.Banco_Dados);
                        });
                }
                //Deletar cheques amarrados
                val.lCheques.ForEach(p => TCN_LoteCH_X_Titulo.DeletarLoteCh_X_Titulo(
                    new TRegistro_LoteCH_X_Titulo()
                    {
                        Cd_banco = p.Cd_banco,
                        Cd_empresa = p.Cd_empresa,
                        Id_lote = val.Id_lote,
                        Nr_lanctocheque = p.Nr_lanctocheque
                    }, qtb_lote.Banco_Dados));
                //Deletar lote
                qtb_lote.DeletarLoteCH(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void EnviarLoteCH(TRegistro_LoteCH val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCH qtb_lote = new TCD_LoteCH();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                
                val.lCheques.ForEach(p =>
                    {
                        //Realizar a transferencia dos cheques entre contas
                        p.Cd_contager_destino = val.Cd_contager;
                        p.Dt_compensacao = val.Dt_enviolote;
                        //Setar status do cheque para enviado
                        p.Status_compensado = "E"; //Enviado
                        TCN_LanTitulo.TransferirTitulo(p, qtb_lote.Banco_Dados);
                        TCN_LanTitulo.GravarTitulo(p, qtb_lote.Banco_Dados);
                    });
                //Gravar lote cheque
                val.St_registro = "E"; //Enviado
                val.Cd_contager = string.Empty;
                GravarLoteCH(val, qtb_lote.Banco_Dados);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro enviar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void ProcessarLoteCH(TRegistro_LoteCH val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCH qtb_lote = new TCD_LoteCH();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Buscar config para descontar cheque
                CamadaDados.Financeiro.Cadastros.TList_CFGCheque lCfg =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CFGCheque.Buscar(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1,
                                                                                string.Empty,
                                                                                qtb_lote.Banco_Dados);
                if (lCfg.Count < 1)
                    throw new Exception("Não existe configuração para processar desconto de cheques.");
                if (lCfg[0].Cd_historico_desconto.Trim().Equals(string.Empty))
                    throw new Exception("Não existe configuração de historico de desconto para processar cheques.");
                if (lCfg[0].Cd_historico_taxa.Trim().Equals(string.Empty))
                    throw new Exception("Não existe configuração de historico de taxa para processar cheques.");
                if(lCfg[0].Cd_historico_creddesconto.Trim().Equals(string.Empty))
                    throw new Exception("Não existe configuração de historico de credito de desconto para processar cheques.");
                //Total cheque descontar
                decimal tot_ch_descontar = val.lCheques.Where(p => p.St_conciliar).Sum(p => p.Vl_titulo);
                //Total taxa
                decimal tot_taxa = decimal.Zero;
                int cont = 0;
                //Buscar conta de compensacao do cheque
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().BuscarEscalar(
                    new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_contager_compensacao",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.lCheques[0].Cd_contager.Trim() + "'"
                                    }
                                }, "a.cd_contager");
                if (obj == null)
                    throw new Exception("Não existe conta de compensação configurada para a conta gerencial " + val.lCheques[0].Cd_contager.Trim());
                if(obj.ToString().Trim().Equals(string.Empty))
                    throw new Exception("Não existe conta de compensação configurada para a conta gerencial " + val.lCheques[0].Cd_contager.Trim());
                val.lCheques.ForEach(p =>
                    {
                        if (p.St_conciliar)
                        {
                            //Compensar cheque descontado
                            p.Dt_compensacao = val.Dt_processamento;
                            p.Cd_contager_destino = obj.ToString();
                            CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.CompensarCheques(
                                new TList_RegLanTitulo() { p },
                                qtb_lote.Banco_Dados);
                            decimal taxa = Math.Round((val.Vl_taxa * (p.Vl_titulo / tot_ch_descontar * 100) / 100), 2);
                            if (cont.Equals(val.lCheques.Count - 1))
                                taxa += (val.Vl_taxa - (tot_taxa + taxa));
                            //Gravar lancamento de caixa devolvendo credito adiantado pelo banco
                            string ret_caixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                {
                                                    Cd_ContaGer = obj.ToString(),
                                                    Cd_Empresa = p.Cd_empresa,
                                                    Cd_Historico = lCfg[0].Cd_historico_desconto,
                                                    Cd_LanctoCaixa = 0,
                                                    ComplHistorico = "DEVOLUCAO CREDITO DESCONTO CHEQUE " + p.Nr_cheque.Trim(),
                                                    Dt_lancto = val.Dt_processamento,
                                                    NM_Clifor = p.Nomeclifor,
                                                    Nr_Docto = p.Nr_cheque,
                                                    Vl_PAGAR = Math.Round(p.Vl_titulo - taxa, 2),
                                                    Vl_RECEBER = decimal.Zero
                                                }, qtb_lote.Banco_Dados);
                            //Gravar Cheque X Caixa
                            CamadaNegocio.Financeiro.Titulo.TCN_TituloXCaixa.GravarTituloCaixa(
                                new TRegistro_LanTituloXCaixa()
                                {
                                    Cd_banco = p.Cd_banco,
                                    Cd_contager = obj.ToString(),
                                    Cd_empresa = p.Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA")),
                                    Nr_lanctocheque = p.Nr_lanctocheque
                                }, qtb_lote.Banco_Dados);
                            //Gravar Lote X Caixa
                            CamadaNegocio.Financeiro.Titulo.TCN_LoteCH_X_Caixa.GravarLoteCH_X_Caixa(
                                new TRegistro_LoteCH_X_Caixa()
                                {
                                    Cd_banco = p.Cd_banco,
                                    Cd_contager = obj.ToString(),
                                    Cd_empresa = p.Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA")),
                                    Nr_lanctocheque = p.Nr_lanctocheque
                                }, qtb_lote.Banco_Dados);
                            //Gravar lancamento de caixa debitando taxa cobrada pelo banco
                            string ret_taxa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                {
                                                    Cd_ContaGer = obj.ToString(),
                                                    Cd_Empresa = p.Cd_empresa,
                                                    Cd_Historico = lCfg[0].Cd_historico_taxa,
                                                    Cd_LanctoCaixa = 0,
                                                    ComplHistorico = "TAXA DESCONTO CHEQUE " + p.Nr_cheque.Trim(),
                                                    Dt_lancto = val.Dt_processamento,
                                                    NM_Clifor = p.Nomeclifor,
                                                    Nr_Docto = p.Nr_cheque,
                                                    Vl_PAGAR = taxa,
                                                    Vl_RECEBER = decimal.Zero
                                                }, qtb_lote.Banco_Dados);
                            //Gravar cheque X Caixa
                            CamadaNegocio.Financeiro.Titulo.TCN_TituloXCaixa.GravarTituloCaixa(
                                new TRegistro_LanTituloXCaixa()
                                {
                                    Cd_banco = p.Cd_banco,
                                    Cd_contager = obj.ToString(),
                                    Cd_empresa = p.Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_taxa, "@P_CD_LANCTOCAIXA")),
                                    Nr_lanctocheque = p.Nr_lanctocheque
                                }, qtb_lote.Banco_Dados);
                            //Gravar Lote X Caixa
                            CamadaNegocio.Financeiro.Titulo.TCN_LoteCH_X_Caixa.GravarLoteCH_X_Caixa(
                                new TRegistro_LoteCH_X_Caixa()
                                {
                                    Cd_banco = p.Cd_banco,
                                    Cd_contager = obj.ToString(),
                                    Cd_empresa = p.Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_taxa, "@P_CD_LANCTOCAIXA")),
                                    Nr_lanctocheque = p.Nr_lanctocheque
                                }, qtb_lote.Banco_Dados);
                            //Totalizar taxas
                            tot_taxa += taxa;
                        }
                        else
                        {
                            //Os cheques que nao forem descontados,
                            //transferir de volta para a conta de origem
                            CamadaDados.Financeiro.Titulo.TList_TransfTitulo lTransf =
                                CamadaNegocio.Financeiro.Titulo.TCN_TransfTitulo.Buscar(p.Cd_empresa,
                                                                                        string.Empty,
                                                                                        p.Cd_contager,
                                                                                        decimal.Zero,
                                                                                        decimal.Zero,
                                                                                        decimal.Zero,
                                                                                        p.Cd_banco,
                                                                                        1,
                                                                                        string.Empty,
                                                                                        qtb_lote.Banco_Dados);
                            if (lTransf.Count < 1)
                                throw new Exception("Registro transferencia nao encontrado.");
                            //Realizar a transferencia dos cheques entre contas
                            p.Cd_contager_destino = lTransf[0].Cd_conta_orig;
                            p.Dt_compensacao = val.Dt_processamento;
                            //Setar status do cheque para enviado
                            p.Status_compensado = "N"; //A Compensar
                            TCN_LanTitulo.TransferirTitulo(p, qtb_lote.Banco_Dados);
                            //Gravar somente o cheque sem mecher no lancamento de caixa
                            p.St_lancarcaixa = false;
                            TCN_LanTitulo.GravarTitulo(p, qtb_lote.Banco_Dados);
                            //Deletar amarracao do cheque com o lote
                            TCN_LoteCH_X_Titulo.DeletarLoteCh_X_Titulo(
                                new TRegistro_LoteCH_X_Titulo()
                                {
                                    Cd_banco = p.Cd_banco,
                                    Cd_empresa = p.Cd_empresa,
                                    Id_lote = val.Id_lote,
                                    Nr_lanctocheque = p.Nr_lanctocheque
                                }, qtb_lote.Banco_Dados);
                        }
                        cont++;
                    });
                //Gravar lancamento de caixa creditando o valor adiantado pelo banco
                string ret_cred = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                    {
                                        Cd_ContaGer = obj.ToString(),
                                        Cd_Empresa = val.Cd_empresa,
                                        Cd_Historico = lCfg[0].Cd_historico_creddesconto,
                                        Cd_LanctoCaixa = 0,
                                        ComplHistorico = "CREDITO DESCONTO CHEQUE DO LOTE" + val.Id_lote.ToString(),
                                        Dt_lancto = val.Dt_processamento,
                                        NM_Clifor = string.Empty,
                                        Nr_Docto = val.Id_lote.ToString(),
                                        Vl_PAGAR = decimal.Zero,
                                        Vl_RECEBER = val.Vl_credito
                                    }, qtb_lote.Banco_Dados);
                //Gravar lote
                val.St_registro = "P";//Processado
                val.Cd_contager = string.Empty;
                val.Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_cred, "@P_CD_LANCTOCAIXA"));
                qtb_lote.GravarLoteCH(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region "Lote X titulo"
    public class TCN_LoteCH_X_Titulo
    {
        public static TList_LoteCH_X_Titulo Buscar(string Cd_empresa,
                                                   string Nr_lanctocheque,
                                                   string Cd_banco,
                                                   string Id_lote,
                                                   int vTop,
                                                   string vNm_campo,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Nr_lanctocheque.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctocheque;
            }
            if (Cd_banco.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            if (Id_lote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            return new TCD_LoteCH_X_Titulo(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TList_RegLanTitulo BuscarCheques(string Id_lote,
                                                       BancoDados.TObjetoBanco banco)
        {
            if (Id_lote.Trim() != string.Empty)
                return new TCD_LanTitulo(banco).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_lotech_x_titulo x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                        "and x.cd_banco = a.cd_banco " +
                                        "and x.id_lote = " + Id_lote + ")"
                        }
                    }, 0, string.Empty, string.Empty);
            else
                return new TList_RegLanTitulo();
        }

        public static string GravarLoteCh_X_Titulo(TRegistro_LoteCH_X_Titulo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCH_X_Titulo qtb_lote = new TCD_LoteCH_X_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Gravar lote x cheque
                string retorno = qtb_lote.GravarLoteCH_X_Titulo(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lote x cheques: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string DeletarLoteCh_X_Titulo(TRegistro_LoteCH_X_Titulo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCH_X_Titulo qtb_lote = new TCD_LoteCH_X_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Deletar lote x cheque
                qtb_lote.DeletarLoteCH_X_Titulo(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar lote x cheque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region "Lote Cheque X Caixa"
    public class TCN_LoteCH_X_Caixa
    {
        public static TList_LoteCH_X_Caixa Buscar(string Cd_empresa,
                                                  string Nr_lanctocheque,
                                                  string Cd_banco,
                                                  string Cd_contager,
                                                  string Cd_lanctocaixa,
                                                  int vTop,
                                                  string vNm_campo,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Nr_lanctocheque.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctocheque;
            }
            if (Cd_banco.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            if (Cd_contager.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (Cd_lanctocaixa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa;
            }
            return new TCD_LoteCH_X_Caixa(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarLoteCH_X_Caixa(TRegistro_LoteCH_X_Caixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCH_X_Caixa qtb_lote = new TCD_LoteCH_X_Caixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                string retorno = qtb_lote.GravarLoteCH_X_Caixa(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar caixa lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string DeletarLoteCH_X_Caixa(TRegistro_LoteCH_X_Caixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteCH_X_Caixa qtb_lote = new TCD_LoteCH_X_Caixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                qtb_lote.DeletarLoteCH_X_Caixa(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar caixa lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
