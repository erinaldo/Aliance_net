using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados;
using CamadaDados.Contabil;
using System.Data;
using System.Linq;

namespace CamadaNegocio.Contabil
{
    public class TCN_LanContabil 
    {
        public static TList_LanContabil Buscar(string Cd_empresa,
                                               string Cd_conta,
                                               string Dt_ini,
                                               string Dt_fin,
                                               string Id_loteCTB,
                                               string Nr_docto,
                                               decimal Vl_ini,
                                               decimal Vl_fin,
                                               string Tp_integracao,
                                               TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_conta))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_conta_ctb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_conta;
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Id_loteCTB))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_loteCTB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_loteCTB;
            }
            if (!string.IsNullOrEmpty(Nr_docto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_docto.Trim() + "'";
            }
            if (Vl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = Vl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (Vl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = Vl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (!string.IsNullOrEmpty(Tp_integracao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "d.tp_integracao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_integracao.Trim() + "'";
            }
            return new TCD_LanctosCTB(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static string ProcessaCTB_Caixa(List<TRegistro_Lan_ProcCaixa> ListaProc, 
                                               TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else Query.Banco_Dados = banco;
            
            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();

                ListaProc.ForEach(p =>
                {
                    if (p.CD_LoteCTB.HasValue)
                        Query.ExcluiLanctosLote(p.CD_LoteCTB);
                    p.Cd_lotectbstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB(){Tp_integracao = "CX"}, Query.Banco_Dados);

                    //ADD OS DADOS CREDITAR
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.DS_ComplHistorico,
                        Nr_docto = p.Nr_Documento,
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.VL_Lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.CD_ContaCre
                    });

                    //ADD OS DADOS DEBITAR
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.DS_ComplHistorico,
                        Nr_docto = p.Nr_Documento,
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.VL_Lancto,
                        D_c = "D",
                        Cd_conta_ctb = p.CD_ContaDeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p => new TCD_Lan_ProcCaixa(Query.Banco_Dados).AtualizaLoteCaixa(p));
                
                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();

                throw new Exception("Erro processar contabilidade caixa gerencial: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }

        public static string ProcessaCTB_Adto(List<TRegistro_ProcAdiantamento> ListaProc,
                                              TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();

                ListaProc.ForEach(p =>
                {
                    if (p.Id_loteCTB.HasValue)
                        Query.ExcluiLanctosLote(p.Id_loteCTB);
                    p.Id_loteCTBstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "AD" }, Query.Banco_Dados);

                    //ADD OS DADOS CREDITAR
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Data = p.Dt_lancto,
                        Ds_compl_historico = p.Complhistorico,
                        Nr_docto = p.Nr_docto,
                        ID_LoteCTB = p.Id_loteCTB,
                        Valor = p.Vl_lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.CD_ContaCre
                    });

                    //ADD OS DADOS DEBITAR
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Data = p.Dt_lancto,
                        Ds_compl_historico = p.Complhistorico,
                        Nr_docto = p.Nr_docto,
                        ID_LoteCTB = p.Id_loteCTB,
                        Valor = p.Vl_lancto,
                        D_c = "D",
                        Cd_conta_ctb = p.CD_ContaDeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p =>
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.AppendLine("update tb_fin_caixa set id_lotectb = " + p.Id_loteCTBstr);
                        sql.AppendLine("where cd_contager = '" + p.Cd_contager.Trim() + "'");
                        sql.AppendLine("and cd_lanctocaixa = " + p.Cd_lanctocaixastr);
                        Query.executarSql(sql.ToString(), null);
                    });

                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();

                throw new Exception("Erro processar contabilidade adiantamento: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }
        
        public static string ProcessaCTB_Faturamento(List<TRegistro_Lan_ProcFaturamento> ListaProc,
                                                     TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else
                Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                ListaProc.ForEach(p =>
                {
                    if (p.CD_LoteCTB.HasValue)
                        Query.ExcluiLanctosLote(p.CD_LoteCTB);
                    //Novo Lote
                    p.Cd_lotectbstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB(){Tp_integracao = "FA"}, Query.Banco_Dados);
                    //Conta Creditar
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.NM_Clifor,
                        Nr_docto = p.Nr_Documento,
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.VL_Lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.CD_ContaCre
                    });
                    
                    //Conta Debitar
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.NM_Clifor,
                        Nr_docto = p.Nr_Documento,
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.VL_Lancto,
                        D_c = "D",
                        Cd_conta_ctb = p.CD_ContaDeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p => new TCD_Lan_ProcFaturamento(Query.Banco_Dados).AtualizaLoteNotaFiscalItem(p));
                
                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();

                throw new Exception("Erro processar contabilidade faturamento: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }

        public static string ProcessaCTB_NFCe(List<TRegistro_Lan_ProcNFCe> ListaProc,
                                              TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else
                Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                ListaProc.ForEach(p =>
                {
                    if (p.CD_LoteCTB.HasValue)
                        Query.ExcluiLanctosLote(p.CD_LoteCTB);
                    //Novo Lote
                    p.Cd_lotectbstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "CE" }, Query.Banco_Dados);
                    //Conta Creditar
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.NM_Clifor,
                        Nr_docto = p.Nr_Documento,
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.VL_Lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.CD_ContaCre
                    });

                    //Conta Debitar
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.NM_Clifor,
                        Nr_docto = p.Nr_Documento,
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.VL_Lancto,
                        D_c = "D",
                        Cd_conta_ctb = p.CD_ContaDeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p => new TCD_Lan_ProcNFCe(Query.Banco_Dados).AtualizaLoteNFCeItem(p));

                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();

                throw new Exception("Erro processar contabilidade NFC-e: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }

        public static string ProcessaCTB_Frete(List<TRegistro_ProcConhecimentoFrete> ListaProc,
                                               TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else
                Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                ListaProc.ForEach(p =>
                {
                    if (p.Id_loteCTB.HasValue)
                        Query.ExcluiLanctosLote(p.Id_loteCTB);
                    //Novo Lote
                    p.Id_loteCTB = decimal.Parse(TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "CT" }, Query.Banco_Dados));
                    //Conta Creditar
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Data = p.Dt_documento,
                        Ds_compl_historico = p.Nm_transportadora,
                        Nr_docto = p.Nr_ctrc.ToString(),
                        ID_LoteCTB = p.Id_loteCTB,
                        Valor = p.Vl_lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.CD_ContaCre
                    });

                    //Conta Debitar
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Data = p.Dt_documento,
                        Ds_compl_historico = p.Nm_transportadora,
                        Nr_docto = p.Nr_ctrc.ToString(),
                        ID_LoteCTB = p.Id_loteCTB,
                        Valor = p.Vl_lancto,
                        D_c = "D",
                        Cd_conta_ctb = p.CD_ContaDeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p =>
                {
                    string sql = "update tb_ctr_conhecimentofrete set id_lotectb = @ID_LOTE where cd_empresa = @CD_EMPRESA and nr_lanctoctr = @NR_LANCTOCTR";
                    System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
                    hs.Add("@ID_LOTE", p.Id_loteCTB);
                    hs.Add("@CD_EMPRESA", p.Cd_empresa);
                    hs.Add("@NR_LANCTOCTR", p.Nr_lanctoCTR);
                    new TDataQuery(Query.Banco_Dados).executarSql(sql, hs);
                });

                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();

                throw new Exception("Erro processar contabilidade NFC-e: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }

        public static void ProcessaCTB_CMV(List<TRegistro_Lan_ProcCMV> ListaProc,
                                           TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else
                Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                ListaProc.ForEach(p =>
                {
                    if (p.CD_LoteCTB.HasValue)
                        Query.ExcluiLanctosLote(p.CD_LoteCTB);
                    //Novo Lote
                    p.Cd_lotectbstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "CM" }, Query.Banco_Dados);
                    //Conta Creditar
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Data = p.Dt_lancto,
                        Ds_compl_historico = p.Nm_clifor,
                        Nr_docto = p.Nr_docto,
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.Vl_lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.CD_ContaCre
                    });

                    //Conta Debitar
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Data = p.Dt_lancto,
                        Ds_compl_historico = p.Nm_clifor,
                        Nr_docto = p.Nr_docto,
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.Vl_lancto,
                        D_c = "D",
                        Cd_conta_ctb = p.CD_ContaDeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p =>
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.AppendLine("update tb_fat_notafiscal_item set id_lotectb_cmv = " + p.Cd_lotectbstr);
                        sql.AppendLine("where cd_empresa = '" + p.Cd_empresa.Trim() + "'");
                        sql.AppendLine("and nr_lanctofiscal = " + p.Nr_lanctofiscalstr);
                        sql.AppendLine("and id_nfitem = " + p.Id_nfitem);
                        Query.executarSql(sql.ToString(), null);
                    });

                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();

                throw new Exception("Erro processar contabilidade faturamento: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }
        
        public static void ProcessaCTB_CompFixar(List<TRegistro_ProcCompFixar> ListaProc,
                                                 TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else
                Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                ListaProc.ForEach(p =>
                {
                    if (p.CD_LoteCTB.HasValue)
                        Query.ExcluiLanctosLote(p.CD_LoteCTB);
                    //Novo Lote
                    p.Cd_lotectbstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "CF" }, Query.Banco_Dados);
                    //Conta Creditar
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Data = p.Dt_lancto,
                        Ds_compl_historico = p.Cd_produto,
                        Nr_docto = p.Id_atualizastr.ToString(),
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.Vl_lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.CD_ContaCre
                    });

                    //Conta Debitar
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Data = p.Dt_lancto,
                        Ds_compl_historico = p.Cd_produto,
                        Nr_docto = p.Id_atualizastr.ToString(),
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.Vl_lancto,
                        D_c = "D",
                        Cd_conta_ctb = p.CD_ContaDeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p =>
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("update TB_CTB_AtualizaEstFixar set ID_LoteCTB = " + p.Cd_lotectbstr);
                    sql.AppendLine("where cd_empresa = '" + p.Cd_empresa.Trim() + "'");
                    sql.AppendLine("and cd_produto = '" + p.Cd_produto.Trim() + "'");
                    sql.AppendLine("and id_atualiza = " + p.Id_atualizastr);
                    Query.executarSql(sql.ToString(), null);
                });

                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();

                throw new Exception("Erro processar contabilidade complemento notas fixar: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }
        
        public static string ProcessaCTB_Impostos(List<TRegistro_ProcImpostos> ListaProc,
                                                  TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else
                Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                ListaProc.ForEach(p =>
                {
                    if (p.Vl_impostocalc > decimal.Zero)
                    {
                        if (p.Id_lotectb_calculado.HasValue)
                            Query.ExcluiLanctosLote(p.Id_lotectb_calculado);
                        p.Id_lotectb_calculado = decimal.Parse(TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "IF" }, Query.Banco_Dados));

                        //ADD OS DADOS CREDITAR
                        listaCre.Add(new TRegistro_LanctosCTB()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Data = p.Dt_documento,
                            Ds_compl_historico = p.Nm_clifor,
                            Nr_docto = p.Nr_notafiscal.Value.ToString(),
                            ID_LoteCTB = p.Id_lotectb_calculado,
                            Valor = p.Vl_impostocalc,
                            D_c = "C",
                            Cd_conta_ctb = p.Cd_contactb_cred
                        });

                        //ADD OS DADOS DEBITAR
                        listaDeb.Add(new TRegistro_LanctosCTB()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Data = p.Dt_documento,
                            Ds_compl_historico = p.Nm_clifor,
                            Nr_docto = p.Nr_notafiscal.Value.ToString(),
                            ID_LoteCTB = p.Id_lotectb_calculado,
                            Valor = p.Vl_impostocalc,
                            D_c = "D",
                            Cd_conta_ctb = p.Cd_contactb_deb
                        });
                    }
                    if(p.Vl_impostoretido > decimal.Zero)
                    {
                        if (p.Id_lotectb_retido.HasValue)
                            Query.ExcluiLanctosLote(p.Id_lotectb_retido);
                        p.Id_lotectb_retido = decimal.Parse(TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "IF" }, Query.Banco_Dados));

                        //ADD OS DADOS CREDITAR
                        listaCre.Add(new TRegistro_LanctosCTB()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Data = p.Dt_documento,
                            Ds_compl_historico = p.Nm_clifor,
                            Nr_docto = p.Nr_notafiscal.Value.ToString(),
                            ID_LoteCTB = p.Id_lotectb_retido,
                            Valor = p.Vl_impostoretido,
                            D_c = "C",
                            Cd_conta_ctb = p.Cd_contactb_cred
                        });

                        //ADD OS DADOS DEBITAR
                        listaDeb.Add(new TRegistro_LanctosCTB()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Data = p.Dt_documento,
                            Ds_compl_historico = p.Nm_clifor,
                            Nr_docto = p.Nr_notafiscal.Value.ToString(),
                            ID_LoteCTB = p.Id_lotectb_retido,
                            Valor = p.Vl_impostoretido,
                            D_c = "D",
                            Cd_conta_ctb = p.Cd_contactb_deb
                        });
                    }
                });
                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p =>
                    {
                        System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
                        hs.Add("@P_CD_EMPRESA", p.Cd_empresa);
                        hs.Add("@P_NR_LANCTOFISCAL", p.Nr_lanctofiscal);
                        hs.Add("@P_ID_NFITEM", p.Id_nfitem);
                        hs.Add("@P_CD_IMPOSTO", p.Cd_imposto);
                        hs.Add("@P_ID_LOTECTB_RETIDO", p.Id_lotectb_retido);
                        hs.Add("@P_ID_LOTECTB_CALCULADO", p.Id_lotectb_calculado);
                        Query.executarProc("IA_FAT_CTBIMPOSTOSNF", hs);
                        //StringBuilder sql = new StringBuilder();
                        //sql.AppendLine("update tb_fat_impostosnf ");
                        //if(p.Id_lotectb_calculado.HasValue)
                        //    sql.AppendLine("set id_lotectb_calculado = " + p.Id_lotectb_calculado.Value.ToString());
                        //if (p.Id_lotectb_retido.HasValue)
                        //    sql.AppendLine((p.Id_lotectb_calculado.HasValue ? ", id_lotectb_retido = " : "set id_lotectb_retido = ") + p.Id_lotectb_retido.Value.ToString());
                        //sql.AppendLine("where id_lancto = " + p.Id_lancto.Value.ToString());
                        //Query.executarSql(sql.ToString(), null);
                    });

                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar contabilidade faturamento: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }

        public static string ProcessaCTB_ChequeCompensado(List<TRegistro_Lan_ProcChequeCompensado> ListaProc,
                                                          TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else
                Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                ListaProc.ForEach(p =>
                {
                    if (p.Cd_lotectb.HasValue)
                        Query.ExcluiLanctosLote(p.Cd_lotectb);
                    p.Cd_lotectbstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB(){Tp_integracao = "CC"}, Query.Banco_Dados);

                    //ADD OS DADOS CREDITAR
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.DS_ComplHistorico,
                        Nr_docto = p.Nr_Documento.ToString(),
                        ID_LoteCTB = p.Cd_lotectb,
                        Valor = p.VL_Lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.Cd_contacred
                    });

                    //ADD OS DADOS DEBITAR
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.DS_ComplHistorico,
                        Nr_docto = p.Nr_Documento.ToString(),
                        ID_LoteCTB = p.Cd_lotectb,
                        Valor = p.VL_Lancto,
                        D_c = "D",
                        Cd_conta_ctb = p.Cd_contadeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p => new TCD_Lan_ProcCaixa(Query.Banco_Dados).AtualizaLoteCaixa(
                    new TRegistro_Lan_ProcCaixa()
                    {
                        CD_LoteCTB = p.Cd_lotectb,
                        ID_LanctoCaixa = p.Id_lanctocaixa,
                        CD_ContaGer = p.CD_ContaGerDest
                    }));

                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar contabilidade cheques compensados: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }

        public static string ProcessaCTB_CartaoDC(List<TRegistro_ProcCartao_DC> ListaProc, TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else
                Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                ListaProc.ForEach(p =>
                {
                    if (p.Cd_lotectb.HasValue)
                        Query.ExcluiLanctosLote(p.Cd_lotectb);
                    p.Cd_lotectbstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "FC" }, Query.Banco_Dados);

                    //ADD OS DADOS CREDITAR
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = "FATURA CARTÃO " + p.Ds_bandeira,
                        Nr_docto = p.Id_fatura.Value.ToString(),
                        ID_LoteCTB = p.Cd_lotectb,
                        Valor = p.VL_Lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.Cd_contacred
                    });

                    //ADD OS DADOS DEBITAR
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = "FATURA CARTÃO " + p.Ds_bandeira,
                        Nr_docto = p.Id_fatura.Value.ToString(),
                        ID_LoteCTB = p.Cd_lotectb,
                        Valor = p.VL_Lancto,
                        D_c = "D",
                        Cd_conta_ctb = p.Cd_contadeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p => new TCD_ProcCartao_DC(Query.Banco_Dados).AtualizaLoteCartao(
                    new TRegistro_ProcCartao_DC()
                    {
                        Cd_lotectb = p.Cd_lotectb,
                        Id_quitar = p.Id_quitar,
                        Tp_lancto = p.Tp_lancto
                    }));

                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar contabilidade cartão: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }

        public static string ProcessaCTB_Financeiro(List<TRegistro_Lan_ProcFinanceiro> ListaProc,
                                                    TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else
                Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                ListaProc.ForEach(p =>
                {
                    if (p.CD_LoteCTB.HasValue)
                        Query.ExcluiLanctosLote(p.CD_LoteCTB);
                    p.Cd_lotectbstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB(){Tp_integracao = "FI"}, Query.Banco_Dados);

                    //ADD OS DADOS CREDITAR
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.DS_Historico,
                        Nr_docto = p.Nr_Documento,
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.VL_Lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.CD_ContaCre
                    });

                    //ADD OS DADOS DEBITAR
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.DS_Historico,
                        Nr_docto = p.Nr_Documento,
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.VL_Lancto,
                        D_c = "D",
                        Cd_conta_ctb = p.CD_ContaDeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p => new TCD_Lan_ProcFinanceiro(Query.Banco_Dados).AtualizaLoteFinanceiro(p));

                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar contabilidade financeiro avulso: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }

        public static string ProcessaCTB_ProvEstoque(List<TRegistro_Lan_ProcProvEstoque> ListaProc,
                                               TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else
                Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                ListaProc.ForEach(p =>
                {
                    TRegistro_LanctosCTB reg_LanctoCTBDEB = new TRegistro_LanctosCTB();
                    if (p.CD_LoteCTB.HasValue)
                        Query.ExcluiLanctosLote(p.CD_LoteCTB);
                    p.Cd_lotectbstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB(){Tp_integracao = "PE"}, Query.Banco_Dados);

                    //ADD OS DADOS A CREDITAR
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Nr_docto = p.ID_Provisao.ToString(),
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.VL_Lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.CD_ContaCre
                    });

                    //ADD OS DADOS DEBITAR
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Nr_docto = p.ID_Provisao.ToString(),
                        ID_LoteCTB = p.CD_LoteCTB,
                        Valor = p.VL_Lancto,
                        D_c = "D",
                        Cd_conta_ctb = p.CD_ContaDeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);
                ListaProc.ForEach(p => new TCD_Lan_ProcProvEstoque(Query.Banco_Dados).AtualizaLoteProvEstoque(p));

                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();

                throw new Exception(erro.Message);
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }
        
        public static string ProcessaCTB_Patrimonio(List<TRegistro_LanPatrimonio> ListaProc,
                                                    TObjetoBanco banco)
        {
            //CRIA A TRANSAÇÃO
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            bool LiberarTransacao = false;
            if (banco == null)
                LiberarTransacao = Query.CriarBanco_Dados(true);
            else
                Query.Banco_Dados = banco;

            try
            {
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                ListaProc.ForEach(p =>
                {
                    if (!p.ID_LoteCTB.HasValue)
                        p.ID_LoteCTB_String = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB(){Tp_integracao = "PA"}, Query.Banco_Dados);
                    else
                        //EXCLUI OS LANCAMENTOS
                        Query.ExcluiLanctosLote(Convert.ToDecimal(p.ID_LoteCTB));

                    //ADD OS DADOS CREDITAR
                    listaCre.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.DS_Patrimonio,
                        Nr_docto = p.Nr_Docto.ToString(),
                        ID_LoteCTB = p.ID_LoteCTB,
                        Valor = p.VL_Lancto,
                        D_c = "C",
                        Cd_conta_ctb = p.CD_ContaCre
                    });

                    //ADD OS DADOS DEBITAR
                    listaDeb.Add(new TRegistro_LanctosCTB()
                    {
                        Cd_empresa = p.CD_Empresa,
                        Data = p.DT_Lancto,
                        Ds_compl_historico = p.DS_Patrimonio,
                        Nr_docto = p.Nr_Docto.ToString(),
                        ID_LoteCTB = p.ID_LoteCTB,
                        Valor = p.VL_Lancto,
                        Cd_conta_ctb = p.CD_ContaDeb
                    });
                });

                //CHAMA O PROCESSAMENTO Q FECHA O CONTABIL
                GravarContabil(listaDeb, listaCre, false, Query.Banco_Dados);

                ListaProc.ForEach(p => new TCD_LanPatrimonio(Query.Banco_Dados).AtualizaLotePatrimonio(p));
                
                //COMITA A TRANSAÇÃO
                if (LiberarTransacao)
                    Query.Banco_Dados.Commit_Tran();

                return "OK";
            }
            catch (Exception erro)
            {
                if (LiberarTransacao)
                    Query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro contabilizar patrimonio: " + erro.Message.Trim());
            }
            finally
            {
                if (LiberarTransacao)
                    Query.deletarBanco_Dados();
            }
        }

        public static string GravarContabil(List<TRegistro_LanctosCTB> ListDeb, 
                                            List<TRegistro_LanctosCTB> ListCred, 
                                            bool St_implatarSaldo,
                                            TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanctosCTB Query = new TCD_LanctosCTB();
            try
            {
                //VERIFICA SE OS TOTAIS BATEM
                if(!St_implatarSaldo && !ListDeb.Sum(p=> p.Valor).Equals(ListCred.Sum(p=> p.Valor)))
                    throw new Exception("Erro: Total de Créditos diferente do Total de Débitos.\r\n" +
                                        "Total de Créditos: " + string.Format("{0:N2}", ListCred.Sum(p=> p.Valor)) + "\r\n" +
                                        "Total de Débitos : " + string.Format("{0:N2}", ListDeb.Sum(p=> p.Valor)));
                
                //VERIFICA SE OS CAMPOS OBRIGATÓRIOS ESTÃO PREENCHIDOS
                if (ListDeb.FindAll(p => string.IsNullOrEmpty(p.Cd_empresa) || !p.ID_LoteCTB.HasValue).Count > 0)
                    throw new Exception("Erro: Campo Obrigatório !\r\n" +
                                        "Campo: CD_Empresa ou ID_LoteCTB\r\n" +
                                        "Método: GravarContabil\r\n" +
                                        "Classe: TCN_LanContabil");

                if (ListCred.FindAll(p => string.IsNullOrEmpty(p.Cd_empresa) || !p.ID_LoteCTB.HasValue).Count > 0)
                    throw new Exception("Erro: Campo Obrigatório !\r\n" +
                                        "Campo: CD_Empresa ou ID_LoteCTB\r\n" +
                                        "Método: GravarContabil\r\n" +
                                        "Classe: TCN_LanContabil");
                string retorno = string.Empty;
                if (banco == null)
                    pode_liberar = Query.CriarBanco_Dados(true);
                else Query.Banco_Dados = banco; 
                //Gravar lista com os registros a Debito
                ListDeb.ForEach(p =>
                {
                    if (p.Data != null)
                        if (TCN_Zeramento.BuscarUltimoFechamento(p.Cd_empresa,
                                                                 p.Data.Value,
                                                                 Query.Banco_Dados))
                        {
                            p.D_c = "D";
                            Query.GravaLanctosCTB(p as TRegistro_LanctosCTB);
                        }
                        else
                            throw new Exception("Erro: Os lançamentos datados em '" + Convert.ToDateTime(p.Data).ToString("dd/MM/yyyy") + "' já tiveram fechamento contábil!");
                    else
                        throw new Exception("Erro: Data inválida!");
                });
                //Gravar Lista com os registros a Credito
                ListCred.ForEach(p =>
                {
                    if (p.Data != null)
                        if (TCN_Zeramento.BuscarUltimoFechamento(p.Cd_empresa,
                                                                 p.Data.Value,
                                                                 Query.Banco_Dados))
                        {
                            p.D_c = "C";
                            Query.GravaLanctosCTB(p as TRegistro_LanctosCTB);
                        }
                        else
                            throw new Exception("Erro: Os lançamentos datados de '" + Convert.ToDateTime(p.Data).ToString("dd/MM/yyyy") + "' já teve fechamento contábil!");
                    else
                        throw new Exception("Erro: Data inválida!");
                });

                if (pode_liberar)
                    Query.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (pode_liberar)
                    Query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registros contabeis: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                   Query.deletarBanco_Dados();                
            }
        }

        public static void ExcluirLanctoAvulso(TRegistro_LanctosCTB rLancto, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanctosCTB query = new TCD_LanctosCTB();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                if (TCN_Zeramento.BuscarUltimoFechamento(rLancto.Cd_empresa, rLancto.Data.Value, query.Banco_Dados))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("delete tb_ctb_lanctoavulso ");
                    sql.AppendLine("from tb_ctb_lanctoavulso a ");
                    sql.AppendLine("inner join tb_ctb_lanmultiplo b ");
                    sql.AppendLine("on a.id_lan = b.id_lan ");
                    sql.AppendLine("where b.id_loteCTB = " + rLancto.Id_lotectbstr);
                    sql.AppendLine("delete tb_ctb_lanmultiplo ");
                    sql.AppendLine("where id_loteCTB = " + rLancto.Id_lotectbstr);
                    sql.AppendLine("exec dbo.EXCLUI_CTB_LANCTOSLOTE @P_ID_LOTECTB = " + rLancto.Id_lotectbstr);
                    query.executarSql(sql.ToString(), null);
                }
                else throw new Exception("Os lançamentos datados em '" + Convert.ToDateTime(rLancto.Data).ToString("dd/MM/yyyy") + "' já tiveram fechamento contábil!");
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();

            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lançamento avulso: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static void AlterarLancto(string Id_loteCTB,
                                         string Cd_empresa,
                                         DateTime Dt_lancto,
                                         string Nr_docto,
                                         string Ds_complemento,
                                         decimal Valor,
                                         TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanctosCTB qtb_ctb = new TCD_LanctosCTB();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctb.CriarBanco_Dados(true);
                else qtb_ctb.Banco_Dados = banco;
                if (TCN_Zeramento.BuscarUltimoFechamento(Cd_empresa, Dt_lancto, qtb_ctb.Banco_Dados))
                {
                    //Buscar todos os lancamentos do lote
                    qtb_ctb.Select(new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_loteCTB",
                            vOperador = "=",
                            vVL_Busca = Id_loteCTB
                        }
                    }, 0, string.Empty, string.Empty).ForEach(p =>
                        {
                            p.Data = Dt_lancto;
                            p.Nr_docto = Nr_docto;
                            p.Ds_compl_historico = Ds_complemento;
                            if (Valor > decimal.Zero)
                                p.Valor = Valor;
                            qtb_ctb.GravaLanctosCTB(p);
                        });
                }
                else throw new Exception("Os lançamentos datados em '" + Dt_lancto.ToString("dd/MM/yyyy") + "' já tiveram fechamento contábil!");
                if (st_transacao)
                    qtb_ctb.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar lançamentos do lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctb.deletarBanco_Dados();
            }
        }

        public static void ExcluirLoteCTB(string Id_loteCTB, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanctosCTB query = new TCD_LanctosCTB();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("delete tb_ctb_lanctosCTB ");
                sql.AppendLine("where id_loteCTB = " + Id_loteCTB);
                sql.AppendLine("delete tb_ctb_lotelan ");
                sql.AppendLine("where id_loteCTB = " + Id_loteCTB);
                query.executarSql(sql.ToString(), null);
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote contabil: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static List<TRegistro_BalancoSintetico> GerarBalanco(string Cd_empresa,
                                                                    string Cd_classificacao,
                                                                    string CD_Conta_CTB,
                                                                    DateTime? Dt_ini,
                                                                    DateTime? Dt_fin,
                                                                    bool St_contaMovimento,
                                                                    bool St_contaSaldo,
                                                                    string Tp_conta,
                                                                    bool St_ignorarZeramento,
                                                                    bool St_cliforSintetico)
        {
            List<TRegistro_BalancoSintetico> retorno =
                new TCD_LanctosCTB().SelectBalancoSintetico(Cd_empresa,
                                                            Cd_classificacao,
                                                            CD_Conta_CTB,
                                                            Dt_ini,
                                                            Dt_fin,
                                                            St_contaMovimento,
                                                            St_ignorarZeramento);
            retorno.ForEach(p =>
                {
                    if (p.Tp_conta.Trim().ToUpper().Equals("S"))
                    {
                        p.Vl_saldoant += retorno.Where(v => v.Classificacao.Trim().StartsWith(p.Classificacao.Trim())).Sum(v => v.Vl_saldoant);
                        p.Vl_debito += retorno.Where(v => v.Classificacao.Trim().StartsWith(p.Classificacao.Trim())).Sum(v => v.Vl_debito);
                        p.Vl_credito += retorno.Where(v => v.Classificacao.Trim().StartsWith(p.Classificacao.Trim())).Sum(v => v.Vl_credito);
                        p.Vl_atual += retorno.Where(v => v.Classificacao.Trim().StartsWith(p.Classificacao.Trim())).Sum(v => v.Vl_atual);
                    }
                });
            if (St_contaSaldo)
                retorno = retorno.FindAll(p => !p.Vl_atual.Equals(decimal.Zero));
            if (!string.IsNullOrWhiteSpace(Tp_conta))
                retorno = retorno.FindAll(p => p.Tp_conta.Trim().ToUpper().Equals(Tp_conta.Trim().ToUpper()));
            else if(St_cliforSintetico)
                retorno.RemoveAll(x => x.Cd_contaCTBPai == 11 ||
                                        x.Cd_contaCTBPai == 1366 ||
                                        x.Cd_contaCTBPai == 20 ||
                                        x.Cd_contaCTBPai == 39 ||
                                        x.Cd_contaCTBPai == 1364 ||
                                        x.Cd_contaCTBPai == 1365 ||
                                        x.Cd_contaCTBPai == 376);
            return retorno;
        }

        public static List<TRegistro_DRE> GerarDRE(string Cd_empresa,
                                                   string Id_dre,
                                                   decimal Exercicio)
        {
            List<TRegistro_DRE> retorno =
                new TCD_LanctosCTB().SelectDRE(Cd_empresa,
                                               Id_dre,
                                               Exercicio);
            decimal result_ant = decimal.Zero;
            decimal result_atual = decimal.Zero;
            retorno.ForEach(p =>
                {
                    result_ant += (p.Operador.Trim().ToUpper().Equals("D") ? -1 : 1) * p.Sd_ant;
                    result_atual += (p.Operador.Trim().ToUpper().Equals("D") ? -1 : 1) * p.Sd_atual;
                    if (p.Tp_conta.Trim().ToUpper().Equals("R"))
                    {
                        p.Tot_ant = result_ant;
                        p.Tot_atual = result_atual;
                    }
                    else
                    {
                        p.Tot_ant += retorno.Where(v => v.Classificacao.Trim().StartsWith(p.Classificacao.Trim())).Sum(v => (p.Operador.Trim().ToUpper().Equals(v.Operador.Trim().ToUpper()) ? 1 : -1) * v.Sd_ant);
                        p.Tot_atual += retorno.Where(v => v.Classificacao.Trim().StartsWith(p.Classificacao.Trim())).Sum(v => (p.Operador.Trim().ToUpper().Equals(v.Operador.Trim().ToUpper()) ? 1 : -1) * v.Sd_atual);
                    }
                });
            return retorno;
        }
    }
}
