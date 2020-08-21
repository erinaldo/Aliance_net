using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using CamadaDados.Producao.Producao;
using CamadaNegocio.Estoque.Cadastros;
using CamadaNegocio.Estoque;

namespace CamadaNegocio.Producao.Producao
{
    public class TCN_OrdemProducao
    {
        public static TList_OrdemProducao Buscar(string Id_ordem,
                                                 string Cd_empresa,
                                                 string Cd_produto,
                                                 string Id_formula,
                                                 string Nr_pedido,
                                                 string St_registro,
                                                 string Tp_data,
                                                 string Dt_ini,
                                                 string Dt_fin,
                                                 bool St_parcial,
                                                 bool St_produzido,
                                                 bool St_comatrazoiniproducao,
                                                 bool St_comatrazofinproducao,
                                                 BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ordem;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_formula))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_formulacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_formula;
            }
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_prd_ordemproducao_x_peditem x " +
                                                      "where x.id_ordem = a.id_ordem " +
                                                      "and x.nr_pedido = " + Nr_pedido + ")";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
                if (!St_parcial)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = string.Empty;
                    filtro[filtro.Length - 1].vVL_Busca = "(a.qtd_produzida = 0 or ((a.qtd_batch * a.qt_produto) - a.qtd_produzida) = 0)";
                }
                if (!St_produzido)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "((a.qtd_batch * a.qt_produto) - a.qtd_produzida)";
                    filtro[filtro.Length - 1].vOperador = ">";
                    filtro[filtro.Length - 1].vVL_Busca = "0";
                }
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (Tp_data.Trim().ToUpper().Equals("PI") ? "a.dt_previniprod" :
                    Tp_data.Trim().ToUpper().Equals("PF") ? "a.dt_prevfinprod" :
                    Tp_data.Trim().ToUpper().Equals("IP") ? "a.dt_iniprod" : "a.dt_finprod") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (Tp_data.Trim().ToUpper().Equals("PI") ? "a.dt_previniprod" :
                    Tp_data.Trim().ToUpper().Equals("PF") ? "a.dt_prevfinprod" :
                    Tp_data.Trim().ToUpper().Equals("IP") ? "a.dt_iniprod" : "a.dt_finprod") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (St_parcial)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "a.qtd_produzida > 0 and ((a.qtd_batch * a.qt_produto) - a.qtd_produzida) > 0";
            }
            if (St_produzido)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "(a.qtd_batch * a.qt_produto) - a.qtd_produzida";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            if (St_comatrazoiniproducao)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), case when a.dt_previniprod is null then getdate() else a.dt_previniprod end)))";
                filtro[filtro.Length - 1].vOperador = "<";
                filtro[filtro.Length - 1].vVL_Busca = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), case when a.dt_iniprod is null then getdate() else a.dt_iniprod end)))";
            }
            if (St_comatrazofinproducao)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), case when a.dt_prevfinprod is null then getdate() else a.dt_prevfinprod end)))";
                filtro[filtro.Length - 1].vOperador = "<";
                filtro[filtro.Length - 1].vVL_Busca = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), case when a.dt_finprod is null then getdate() else a.dt_finprod end)))";
            }

            return new TCD_OrdemProducao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_OrdemProducao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemProducao qtb_ordem = new TCD_OrdemProducao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                //Gerar Formula
                if (string.IsNullOrEmpty(val.Id_formulacaostr))
                {
                    val.Id_formulacaostr =
                    TCN_FormulaApontamento.Gravar(
                        TCN_FormulaApontamento.CriarFormulaApontamentoProd(val.Cd_empresa,
                                                                           val.Cd_produto,
                                                                           val.Cd_unidade,
                                                                           val.Cd_local,
                                                                           qtb_ordem.Banco_Dados), qtb_ordem.Banco_Dados);
                }
                //Gravar Ordem Producao
                val.Id_ordem = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_ordem.Gravar(val), "@P_ID_ORDEM"));
                //Gravar Ficha Ordem
                val.lOrdem_MPrima.ForEach(p =>
                {
                    p.Id_ordem = val.Id_ordem;
                    TCN_Ordem_MPrima.Gravar(p, qtb_ordem.Banco_Dados);
                });
                //Excluir Ficha Ordem
                val.lOrdem_MPrimaDel.ForEach(p => TCN_Ordem_MPrima.Excluir(p, qtb_ordem.Banco_Dados));
                //Gravar Ordem X Pedido Item
                val.lPedItem.ForEach(p =>
                    {
                        p.Id_ordem = val.Id_ordem;
                        TCN_OrdemProducao_X_PedItem.Gravar(p, qtb_ordem.Banco_Dados);
                    });
                //Excluir Ordem X Pedido Item
                val.lPedItemDel.ForEach(p => TCN_OrdemProducao_X_PedItem.Excluir(p, qtb_ordem.Banco_Dados));
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return val.Id_ordem.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ordem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_OrdemProducao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemProducao qtb_ordem = new TCD_OrdemProducao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                //Verificar se ordem de producao tem apontamento
                object obj = new TCD_ApontamentoProducao(qtb_ordem.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_prd_ordemproducao_x_apontamento x " +
                                                    "where x.id_apontamento = a.id_apontamento " +
                                                    "and x.id_ordem = " + val.Id_ordem.Value.ToString() + ")"
                                    }
                                }, "1");
                if (obj != null)
                    throw new Exception("Ordem produção possui apontamento. Necessario cancelar antes os apontamentos.");
                //Excluir origem da ordem producao
                TCN_OrdemProducao_X_PedItem.Buscar(val.Id_ordem.Value.ToString(),
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   qtb_ordem.Banco_Dados).ForEach(p => TCN_OrdemProducao_X_PedItem.Excluir(p, qtb_ordem.Banco_Dados));
                //Excluir Ficha Ordem
                TCN_Ordem_MPrima.Buscar(val.Id_ordem.Value.ToString(), qtb_ordem.Banco_Dados).ForEach(p => TCN_Ordem_MPrima.Excluir(p, qtb_ordem.Banco_Dados));
                //Excluir serie
                TCN_SerieProduto.Buscar(string.Empty, string.Empty, string.Empty, val.Id_ordem.Value.ToString(), qtb_ordem.Banco_Dados).ForEach(p => TCN_SerieProduto.Excluir(p, qtb_ordem.Banco_Dados));
                qtb_ordem.Excluir(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ordem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static void IniciarProducao(TRegistro_OrdemProducao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemProducao qtb_ordem = new TCD_OrdemProducao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else qtb_ordem.Banco_Dados = banco;
                val.Dt_iniprod = CamadaDados.UtilData.Data_Servidor(qtb_ordem.Banco_Dados);
                val.St_registro = "P";
                qtb_ordem.Gravar(val);
                //Gravar Série Produto
                val.lSerie.ForEach(p =>
                {
                    p.Id_ordem = val.Id_ordem;
                    TCN_SerieProduto.Gravar(p, qtb_ordem.Banco_Dados);
                });
                if (st_transacao)
                qtb_ordem.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro iniciar produção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static void EstornarIniProducao(TRegistro_OrdemProducao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemProducao qtb_ordem = new TCD_OrdemProducao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else qtb_ordem.Banco_Dados = banco;
                val.Dt_iniprod = null;
                val.St_registro = "A";
                qtb_ordem.Gravar(val);
                //Excluir serie produto
                TCN_SerieProduto.Buscar(string.Empty,
                                        string.Empty,
                                        string.Empty,
                                        val.Id_ordem.Value.ToString(),
                                        qtb_ordem.Banco_Dados)
                                        .ForEach(p => TCN_SerieProduto.Excluir(p, qtb_ordem.Banco_Dados));
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar inicio produção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static void GerarExcel(TRegistro_OrdemProducao val)
        {
            try
            {

                TList_SerieProduto lSerie =
                        new TCD_SerieProduto().Select(
                            new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_ordem",
                                vOperador = "=",
                                vVL_Busca = val.Id_ordem.ToString()
                            }
                            }, 0, string.Empty);
                if (lSerie.Count.Equals(0))
                    throw new Exception("Não existe Nº Série cadastrada para ordem para gerar Planilha no Excel!");
                lSerie.ForEach(p =>
                {
                    string path1 = "C:\\Aliance.NET\\Producao\\Modelo\\Ficha Produção1.xls";
                    string path2 = "C:\\Aliance.NET\\Producao\\Modelo\\Ficha Produção2.xls";

                    Microsoft.Office.Interop.Excel.Application oApp;
                    Microsoft.Office.Interop.Excel.Worksheet oSheet;
                    Microsoft.Office.Interop.Excel.Workbook oBook;

                    object misValue = System.Reflection.Missing.Value;

                    #region Path 1
                    string pathSalvar = "C:\\Aliance.NET\\Producao\\OP-" + val.Id_ordem.ToString() + "\\1 - Nº Série " + p.Nr_serie.Trim() + ".xls";
                    if (!System.IO.Directory.Exists("C:\\Aliance.NET\\Producao\\OP-" + val.Id_ordem.ToString()))
                        System.IO.Directory.CreateDirectory("C:\\Aliance.NET\\Producao\\OP-" + val.Id_ordem.ToString());

                    if (ArquivoEmUso(pathSalvar))
                        throw new Exception("Arquivo em uso!\r\n" + pathSalvar.Trim() +
                                        "\r\nPor favor feche esse arquivo para continuar");
                    if (System.IO.File.Exists(pathSalvar))
                        System.IO.File.Delete(pathSalvar);

                    oApp = new Microsoft.Office.Interop.Excel.Application();
                    oBook = oApp.Workbooks.Open(path1, misValue, false, misValue,
                    misValue, misValue, misValue, misValue,
                    misValue, true, misValue, misValue,
                    misValue, misValue, misValue);
                    //Planilha 1
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(1);
                    //Nº Série
                    oSheet.Cells[2, 6] = p.Nr_serie;
                    //Planilha 2
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(2);
                    //Nº Série
                    oSheet.Cells[9, 10] = p.Nr_serie;
                    //Produto
                    if (!string.IsNullOrEmpty(val.Ds_interna))
                    {
                        string s1 = string.Empty;
                        string[] str1 = new string[4];
                        string[] prod1 = val.Ds_comercial.Split(new char[] { ' ' });
                        for (int i = 0; prod1.Count() > i; i++)
                        {
                            s1 += " " + prod1[i];
                            if (s1.TrimStart().Length <= 88)
                            {
                                str1[0] += " " + prod1[i];
                                oSheet.Cells[10, 1] = str1[0].TrimStart();
                            }
                            else if (s1.Length <= 176)
                            {
                                str1[1] += " " + prod1[i];
                                oSheet.Cells[11, 1] = str1[1].TrimStart();
                            }
                            else if (s1.Length <= 264)
                            {
                                str1[2] += " " + prod1[i];
                                oSheet.Cells[12, 1] = str1[2].TrimStart();
                            }
                            else if (s1.Length <= 352)
                            {
                                str1[3] += " " + prod1[i];
                                oSheet.Cells[13, 1] = str1[3].TrimStart();
                            }
                        }
                    }
                    //Dt.Entrega
                    if (!string.IsNullOrEmpty(val.Dt_prevfinprodstr))
                        oSheet.Cells[5, 10] = val.Dt_prevfinprodstr;
                     
                    if (!string.IsNullOrEmpty(val.Ds_interna))
                    {
                        List<string> ds = new List<string>();
                        val.Ds_interna.Replace("\r\n", ";").Split(new char[] { ';' }).ToList().ForEach(x => ds.Add(x));
                        if (ds.Count >= 14)
                        {
                            oSheet.Cells[17, 1] = ds[0].ToLower();
                            oSheet.Cells[18, 1] = ds[1].ToLower();
                            oSheet.Cells[19, 1] = ds[2].ToLower();
                            oSheet.Cells[20, 1] = ds[3].ToLower();
                            oSheet.Cells[21, 1] = ds[4].ToLower();
                            oSheet.Cells[22, 1] = ds[5].ToLower();

                            oSheet.Cells[27, 1] = ds[7].ToLower();
                            oSheet.Cells[28, 1] = ds[8].ToLower();
                            oSheet.Cells[29, 1] = ds[9].ToLower();
                            oSheet.Cells[30, 1] = ds[10].ToLower();
                            oSheet.Cells[31, 1] = ds[11].ToLower();
                            oSheet.Cells[32, 1] = ds[12].ToLower();
                            oSheet.Cells[33, 1] = ds[13].ToLower();
                        }
                        else
                        {
                            oSheet.Cells[17, 1] = "CADASTRE AS INFORMAÇÕES";
                            oSheet.Cells[18, 1] = "CORRETAMENTE NA DS.INTERNA DO PRODUTO:";
                            oSheet.Cells[19, 1] = "6 LINHAS + UM LINHA VAZIA +";
                            oSheet.Cells[20, 1] = "7 LINHAS";
                            oSheet.Cells[21, 1] = "CADASTRO DEVE TER 14 LINHAS";
                            oSheet.Cells[22, 1] = "NESTE FORMATO.";

                            oSheet.Cells[27, 1] = string.Empty;
                            oSheet.Cells[28, 1] = string.Empty;
                            oSheet.Cells[29, 1] = string.Empty;
                            oSheet.Cells[30, 1] = string.Empty;
                            oSheet.Cells[31, 1] = string.Empty;
                            oSheet.Cells[32, 1] = string.Empty;
                            oSheet.Cells[33, 1] = string.Empty;
                        }
                    }
                    else
                    {
                        oSheet.Cells[17, 1] = "PREENCHA DESCRIÇÃO INTERNA";
                        oSheet.Cells[18, 1] = "NO CADASTRO DO PRODUTO.";
                        oSheet.Cells[19, 1] = string.Empty;
                        oSheet.Cells[20, 1] = string.Empty;
                        oSheet.Cells[21, 1] = string.Empty;
                        oSheet.Cells[22, 1] = string.Empty;

                        oSheet.Cells[27, 1] = string.Empty;
                        oSheet.Cells[28, 1] = string.Empty;
                        oSheet.Cells[29, 1] = string.Empty;
                        oSheet.Cells[30, 1] = string.Empty;
                        oSheet.Cells[31, 1] = string.Empty;
                        oSheet.Cells[32, 1] = string.Empty;
                        oSheet.Cells[33, 1] = string.Empty;
                    }

                    //Salvando informações
                    oBook.SaveAs(pathSalvar, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, false, misValue,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, misValue, misValue, misValue, misValue, misValue);
                    oBook.Close(true, misValue, misValue);

                    //Eliminando o Excel da memória
                    oSheet = null;
                    oBook = null;
                    oApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oApp);
                    oApp = null;
                    GC.Collect();
                    System.Diagnostics.Process.Start(pathSalvar);
                    #endregion

                    #region Path 2
                    pathSalvar = "C:\\Aliance.NET\\Producao\\OP-" + val.Id_ordem.ToString() + "\\2 - Nº Série " + p.Nr_serie.Trim() + ".xls";
                    if (!System.IO.Directory.Exists("C:\\Aliance.NET\\Producao\\OP-" + val.Id_ordem.ToString()))
                        System.IO.Directory.CreateDirectory("C:\\Aliance.NET\\Producao\\OP-" + val.Id_ordem.ToString());

                    if (ArquivoEmUso(pathSalvar))
                        throw new Exception("Arquivo em uso!\r\n" + pathSalvar.Trim() +
                                        "\r\nPor favor feche esse arquivo para continuar");
                    if (System.IO.File.Exists(pathSalvar))
                        System.IO.File.Delete(pathSalvar);



                    oApp = new Microsoft.Office.Interop.Excel.Application();
                    oBook = oApp.Workbooks.Open(path2, misValue, false, misValue,
                    misValue, misValue, misValue, misValue,
                    misValue, true, misValue, misValue,
                    misValue, misValue, misValue);
                    //Planilha 1
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(1);
                    //Nº Série
                    oSheet.Cells[9, 10] = p.Nr_serie;
                    //Produto
                    string s2 = string.Empty;
                    string[] str2 = new string[4];
                    string[] prod2 = val.Ds_comercial.Split(new char[] { ' ' });
                    for (int i = 0; prod2.Count() > i; i++)
                    {
                        s2 += " " + prod2[i];
                        if (s2.TrimStart().Length <= 88)
                        {
                            str2[0] += " " + prod2[i];
                            oSheet.Cells[10, 1] = str2[0].TrimStart();
                        }
                        else if (s2.Length <= 176)
                        {
                            str2[1] += " " + prod2[i];
                            oSheet.Cells[11, 1] = str2[1].TrimStart();
                        }
                        else if (s2.Length <= 264)
                        {
                            str2[2] += " " + prod2[i];
                            oSheet.Cells[12, 1] = str2[2].TrimStart();
                        }
                        else if (s2.Length <= 352)
                        {
                            str2[3] += " " + prod2[i];
                            oSheet.Cells[13, 1] = str2[3].TrimStart();
                        }
                    }
                    //Dt.Entrega
                    if (!string.IsNullOrEmpty(val.Dt_prevfinprodstr))
                        oSheet.Cells[5, 10] = val.Dt_prevfinprodstr;
                    //Peso
                    oSheet.Cells[16, 10] = val.PesoLiquido.ToString("N0", new System.Globalization.CultureInfo("pt-BR")) + " Kg";
                    //Planilha 2
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(2);
                    //Nº Série
                    oSheet.Cells[2, 6] = p.Nr_serie;
                    //Peso
                    oSheet.Cells[16, 1] = val.PesoLiquido.ToString("N0", new System.Globalization.CultureInfo("pt-BR")) + " Kg";
                    //Planilha 3
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(3);
                    //Nº Série
                    oSheet.Cells[2, 6] = p.Nr_serie;
                    //Planilha 4
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(4);
                    //Nº Série
                    oSheet.Cells[2, 6] = p.Nr_serie;
                    //Planilha 5
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(5);
                    //Nº Série
                    oSheet.Cells[2, 12] = p.Nr_serie;
                    //Planilha 6
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(6);
                    //Nº Série
                    oSheet.Cells[2, 12] = p.Nr_serie;
                    //Planilha 7
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(7);
                    //Nº Série
                    oSheet.Cells[2, 12] = p.Nr_serie;
                    //Planilha 8
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(8);
                    //Nº Série
                    oSheet.Cells[2, 6] = p.Nr_serie;


                    //Salvando informações
                    oBook.SaveAs(pathSalvar, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, false, misValue,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, misValue, misValue, misValue, misValue, misValue);
                    oBook.Close(true, misValue, misValue);

                    //Eliminando o Excel da memória
                    oSheet = null;
                    oBook = null;
                    oApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oApp);
                    oApp = null;
                    GC.Collect();
                    System.Diagnostics.Process.Start(pathSalvar);
                    #endregion
                });
            }
            catch (Exception ex)
            { throw new Exception("Erro gerar arquivo excel: " + ex.Message.Trim()); }
        }

        public static bool ArquivoEmUso(string caminhoArquivo)
        {
            try
            {
                System.IO.FileStream fs = System.IO.File.OpenWrite(caminhoArquivo);
                fs.Close();
                return false;
            }
            catch
            {return true;}
        }

        public static decimal CalcularQtdBatch(TRegistro_OrdemProducao rOrdem, 
                                               TRegistro_FormulaApontamento rFormula,
                                               BancoDados.TObjetoBanco banco)
        {
            return TCN_CadConvUnidade.ConvertUnid(rOrdem.Cd_unidade, rFormula.Cd_unidade, rOrdem.Qtd_saldoproduzir, 3, banco) / rFormula.Qt_produto;
        }
    }
    public class TCN_Ordem_MPrima
    {
        public static TList_Ordem_MPrima Buscar(string Id_ordem, BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if(!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ordem;
            }
            return new TCD_Ordem_MPrima(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_Ordem_MPrima val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Ordem_MPrima qtb_ordem = new TCD_Ordem_MPrima();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else qtb_ordem.Banco_Dados = banco;
                string retorno = qtb_ordem.Gravar(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ficha ordem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_Ordem_MPrima val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Ordem_MPrima qtb_ordem = new TCD_Ordem_MPrima();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else qtb_ordem.Banco_Dados = banco;
                qtb_ordem.Excluir(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ficha: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }
    }
    public class TCN_OrdemProducao_X_PedItem
    {
        public static TList_OrdemProducao_X_PedItem Buscar(string Id_ordem,
                                                           string Nr_pedido,
                                                           string Cd_produto,
                                                           string Id_pedidoitem,
                                                           BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ordem;
            }
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_pedidoitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pedidoitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pedidoitem;
            }

            return new TCD_OrdemProducao_X_PedItem(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item BuscarItem(string Id_ordem,
                                                                                        BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item(banco).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_prd_ordemproducao_x_peditem x " +
                                            "where x.nr_pedido = a.nr_pedido " +
                                            "and x.cd_produto = a.cd_produto " +
                                            "and x.id_pedidoitem = a.id_pedidoitem " +
                                            "and x.id_ordem = " + Id_ordem + ")"
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_OrdemProducao_X_PedItem val, BancoDados.TObjetoBanco banco)
        {
            TCD_OrdemProducao_X_PedItem qtb_ordem = new TCD_OrdemProducao_X_PedItem();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                string retorno = qtb_ordem.Gravar(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_OrdemProducao_X_PedItem val, BancoDados.TObjetoBanco banco)
        {
            TCD_OrdemProducao_X_PedItem qtb_ordem = new TCD_OrdemProducao_X_PedItem();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                qtb_ordem.Excluir(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }
    }
    public class TCN_OrdemProducao_X_Apontamento
    {
        public static TList_OrdemProducao_X_Apontamento Buscar(string Id_ordem,
                                                               string Id_apontamento,
                                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ordem;
            }
            if (!string.IsNullOrEmpty(Id_apontamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_apontamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_apontamento;
            }

            return new TCD_OrdemProducao_X_Apontamento(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_OrdemProducao BuscarOrdem(string Id_apontamento,
                                                      BancoDados.TObjetoBanco banco)
        {
            return new TCD_OrdemProducao(banco).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_prd_ordemproducao_x_apontamento x " +
                                        "where x.id_ordem = a.id_ordem " +
                                        "and x.id_apontamento = " + Id_apontamento + ")"
                        }
                    }, 0, string.Empty);
        }

        public static TList_ApontamentoProducao BuscarApontamento(string Id_ordem,
                                                                  BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Producao.Producao.TCD_ApontamentoProducao(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_prd_ordemproducao_x_apontamento x " +
                                    "where x.id_apontamento = a.id_apontamento " +
                                    "and x.id_ordem = " + Id_ordem + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_OrdemProducao_X_Apontamento val, BancoDados.TObjetoBanco banco)
        {
            TCD_OrdemProducao_X_Apontamento qtb_ordem = new TCD_OrdemProducao_X_Apontamento();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                string retorno = qtb_ordem.Gravar(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_OrdemProducao_X_Apontamento val, BancoDados.TObjetoBanco banco)
        {
            TCD_OrdemProducao_X_Apontamento qtb_ordem = new TCD_OrdemProducao_X_Apontamento();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                qtb_ordem.Excluir(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }
    }
    public class TCN_OrdemProducao_X_Requisicao
    {
        public static TList_OrdemProducao_X_Requisicao Buscar(string Id_ordem,
                                                           string Id_requisicao,
                                                           string Cd_empresa,
                                                           BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ordem;
            }
            if (!string.IsNullOrEmpty(Id_requisicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_requisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_requisicao;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }

            return new TCD_OrdemProducao_X_Requisicao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_OrdemProducao_X_Requisicao val, BancoDados.TObjetoBanco banco)
        {
            TCD_OrdemProducao_X_Requisicao qtb_ordem = new TCD_OrdemProducao_X_Requisicao();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                string retorno = qtb_ordem.Gravar(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_OrdemProducao_X_Requisicao val, BancoDados.TObjetoBanco banco)
        {
            TCD_OrdemProducao_X_Requisicao qtb_ordem = new TCD_OrdemProducao_X_Requisicao();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                qtb_ordem.Excluir(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }
    }
    public class TCN_MPrima
    {
        public static TList_MPrima MontarListaMPrima(string Cd_empresa,
                                                     string Id_formula,
                                                     decimal qtd_batch,
                                                     TList_MPrima lista,
                                                     BancoDados.TObjetoBanco banco)
        {
            //Buscar lista de materia prima da formula
            TList_FichaTec_MPrima lMPrima = TCN_FichaTec_MPrima.Buscar(Cd_empresa,
                                                                       Id_formula,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       0,
                                                                       string.Empty,
                                                                       banco);
            if (lista == null)
                lista = new TList_MPrima();
            lMPrima.ForEach(p =>
                {
                    if (p.Id_formulacao_mprima != null)
                    {
                        //Se for subproduto, chamar o metodo MontarListaMPrima recursivamente
                        MontarListaMPrima(p.Cd_empresa, p.Id_formulacao_mprimastr, qtd_batch, lista, banco);
                    }
                    else
                    {
                        //Verificar se o item ja existe na lista
                        if (lista.Exists(v => v.Cd_mprima.Trim().Equals(p.Cd_produto.Trim()) && v.Cd_local.Trim().Equals(p.Cd_local.Trim())))
                            //Somar quantidade da materia prima convertida para unidade do estoque
                            lista.Find(v => v.Cd_mprima.Trim().Equals(p.Cd_produto.Trim()) && v.Cd_local.Trim().Equals(p.Cd_local.Trim())).Qtd_mprima +=
                                TCN_CadConvUnidade.ConvertUnid(p.Cd_unidade, p.Cd_unid_produto, p.Qtd_produto, 3, banco);
                        else
                            //Acrescentar novo registro 
                            lista.Add(new TRegistro_MPrima()
                            {
                                Cd_local = p.Cd_local,
                                Cd_mprima = p.Cd_produto,
                                Ds_local = p.Ds_local,
                                Ds_mprima = p.Ds_produto,
                                Cd_alternativo = p.Cd_alternativo,
                                Cd_marca = p.Cd_marca,
                                Ds_marca = p.Ds_marca,
                                Sigla_unidade = p.Sigla_unid_produto,
                                Qtd_mprima = TCN_CadConvUnidade.ConvertUnid(p.Cd_unidade, p.Cd_unid_produto, p.Qtd_produto, 3, banco) * qtd_batch,
                                Qtd_saldolocal = TCN_LanEstoque.Busca_Saldo_Local(p.Cd_empresa, p.Cd_produto, p.Cd_local, banco),
                                Vl_custounit = TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(p.Cd_empresa, p.Cd_produto, banco)
                            });
                    }
                });
            return lista;
        }

        public static TList_MPrima MontarListaMPrimaOrdem(string Cd_empresa,
                                                         string Id_ordem,
                                                         decimal Qtd_batch,
                                                         TList_MPrima lista,
                                                         BancoDados.TObjetoBanco banco)
        {
            //Buscar lista de materia prima da ordem
            TList_Ordem_MPrima lMPrima = TCN_Ordem_MPrima.Buscar(Id_ordem, banco);
            if (lista == null)
                lista = new TList_MPrima();
            lMPrima.ForEach(p =>
            {
                if (p.ID_Formulacao_MPrima != null)
                {
                    //Calcular novo indice
                    TList_FormulaApontamento lFormula = TCN_FormulaApontamento.Buscar(p.CD_Empresa,
                                                                                      p.ID_Formulacao_MPrima.Value.ToString(),
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      banco);
                    //Se for subproduto, chamar o metodo MontarListaMPrima recursivamente
                    MontarListaMPrima(p.CD_Empresa, p.ID_Formulacao_MPrima.Value.ToString(), Qtd_batch, lista, banco);
                }
                else
                {
                    //Verificar se o item ja existe na lista
                    if (lista.Exists(v => v.Cd_mprima.Trim().Equals(p.Cd_produto.Trim()) && v.Cd_local.Trim().Equals(p.Cd_local.Trim())))
                        //Somar quantidade da materia prima convertida para unidade do estoque
                        lista.Find(v => v.Cd_mprima.Trim().Equals(p.Cd_produto.Trim()) && v.Cd_local.Trim().Equals(p.Cd_local.Trim())).Qtd_mprima +=
                            TCN_CadConvUnidade.ConvertUnid(p.Cd_unidade, p.Cd_unid_produto, p.Qtd_produto, 3, banco);
                    else
                        //Acrescentar novo registro 
                        lista.Add(new TRegistro_MPrima()
                        {
                            Cd_local = p.Cd_local,
                            Cd_mprima = p.Cd_produto,
                            Ds_local = p.Ds_local,
                            Ds_mprima = p.Ds_produto,
                            Sigla_unidade = p.Sigla_unidade,
                            Qtd_mprima = TCN_CadConvUnidade.ConvertUnid(p.Cd_unidade, p.Cd_unid_produto, p.Qtd_produto, 3, banco),
                            Qtd_saldolocal = TCN_LanEstoque.Busca_Saldo_Local(p.CD_Empresa, p.Cd_produto, p.Cd_local, banco),
                            Vl_custounit = TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(p.CD_Empresa, p.Cd_produto, banco)
                        });
                }
            });
            return lista;
        }
    }
}
