using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using CamadaNegocio.ConfigGer;
using PerpetuumSoft.Reporting.Components;
using System.Xml;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using FormRelPadrao.Resources;
using Utils;
using PerpetuumSoft.Reporting.Export.Pdf;
using PerpetuumSoft.Reporting.Export.Excel;

namespace FormRelPadrao
{
    public class Relatorio
    {
        public ReportManager reportManager = new ReportManager();
        PdfExportFilter pdf = new PdfExportFilter();
        ExcelExportFilter excel = new ExcelExportFilter();
        public Hashtable Parametros_Relatorio = new Hashtable();
        public string Nome_Relatorio = string.Empty;
        public string NM_Classe = string.Empty;
        public string Modulo = string.Empty;
        public string Ident = string.Empty;
        public string vURLWebService = string.Empty;
        public bool Homologacao = false;
        public BindingSource DTS_Relatorio;
        public bool Altera_Relatorio = false;
        public TRegistro_Cad_Report Cad_Report = new TRegistro_Cad_Report();

        public void Adiciona_DataSource(string Nome_DataSource, BindingSource DataSource)
        {
            reportManager.DataSources.Add(Nome_DataSource, DataSource);
        }

        public bool Gera_Relatorio()
        {
            return Gera_Relatorio(string.Empty,
                                  false,
                                  true,
                                  false,
                                  false,
                                  string.Empty,
                                  new List<string>(),
                                  null,
                                  string.Empty,
                                  string.Empty);
        }

        public bool Gera_Relatorio(string Documento,
                                   bool St_imprimir,
                                   bool St_visualizar,
                                   bool St_enviaremail,
                                   bool St_exportPdf,
                                   string Path_exportPdf,
                                   List<string> Destinatarios,
                                   List<string> Anexos,
                                   string Titulo,
                                   string Mensagem,
                                   bool St_enviarcomoanexo)
        {
            bool retorno = false;
            try
            {
                //VERIFICA SE JÁ TEM O ITEM LANÇADO
                if (string.IsNullOrEmpty(Cad_Report.DS_Report))
                {
                    Cad_Report.Modulo = Modulo;
                    Cad_Report.NM_Classe = NM_Classe;
                    Cad_Report.DS_Report = NM_Classe;
                    Cad_Report.Ident = Ident;
                }

                //Se nao existir relatorio no banco, baixar da net
                if (!BuscaRelatorio())
                    if (AtualizarRDC.VerificarVersaoRDC(Cad_Report, false))
                        BuscaRelatorio();

                XmlDocument docXMLRelatorio = new XmlDocument();
                if (Cad_Report.Code_Report != null)
                    docXMLRelatorio.LoadXml(System.Text.ASCIIEncoding.UTF8.GetString(Compact_Data.Descompactar(Cad_Report.Code_Report, string.Empty)));

                //CRIA O ARQUIVO PARA O RELATORIO
                InlineReportSlot ArquivoRelatorio = new InlineReportSlot();
                //ADICIONAR O NOME E OS PARAMETROS
                ArquivoRelatorio.GetReportParameter += new GetReportParameterEventHandler(Parametros);
                Nome_Relatorio = Nome_Relatorio.Replace(' ', '_');
                ArquivoRelatorio.ReportName = Nome_Relatorio;
                reportManager.DataSources.Add("DTS", DTS_Relatorio);

                if (Cad_Report.Code_Report != null)
                {
                    //ADICIONA O STREAM DO RELATORIO (XML)
                    ArquivoRelatorio.DocumentStream = docXMLRelatorio.InnerXml;
                    reportManager.Reports.Add(ArquivoRelatorio);

                    if (!Altera_Relatorio)
                    {
                        reportManager.Reports[0].LoadReport();
                        reportManager.Reports[0].Prepare();
                        reportManager.Reports[0].RenderDocument();

                        using (PerpetuumSoft.Reporting.View.PreviewForm view = new PerpetuumSoft.Reporting.View.PreviewForm(reportManager.Reports[0]))
                        {
                            if (St_imprimir)
                            {
                                object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
                                string print = obj == null ? string.Empty : obj.ToString();
                                if (!string.IsNullOrEmpty(print))
                                {
                                    bool existe = false;
                                    for (int i = 0; i < System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count; i++)
                                    {
                                        string teste = System.Drawing.Printing.PrinterSettings.InstalledPrinters[i];
                                        if (System.Drawing.Printing.PrinterSettings.InstalledPrinters[i].Trim().ToUpper().Equals(print.Trim().ToUpper()))
                                        {
                                            existe = true;
                                            break;
                                        }
                                    }
                                    if (!existe)
                                        print = string.Empty;
                                }

                                if (!string.IsNullOrEmpty(print))
                                    using (ReportPrintDocument rpd = new ReportPrintDocument())
                                    {
                                        decimal copias = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("QTD_VIA_DANFE", null);
                                        rpd.PrinterSettings.Copies = copias == decimal.Zero ? (short)1 : (short)copias;
                                        rpd.PrinterSettings.PrinterName = print;
                                        rpd.Source = ArquivoRelatorio;
                                        rpd.Print();
                                    }
                                else
                                    using (System.Windows.Forms.PrintDialog pd = new PrintDialog())
                                    {
                                        pd.UseEXDialog = true;
                                        if (pd.ShowDialog() == DialogResult.OK)
                                        {
                                            using (ReportPrintDocument rpd = new ReportPrintDocument())
                                            {
                                                rpd.PrinterSettings = pd.PrinterSettings;
                                                rpd.Source = ArquivoRelatorio;
                                                rpd.Print();
                                            }
                                        }
                                    }
                            }
                            else if (St_visualizar)
                            {
                                view.WindowState = FormWindowState.Maximized;
                                view.ShowDialog();
                                retorno = true;
                            }
                            else if (St_exportPdf && !string.IsNullOrEmpty(Path_exportPdf))
                            {
                                using (PdfExportFilter pdf = new PdfExportFilter())
                                {
                                    pdf.Export(this.reportManager.Reports[0].Document, Path_exportPdf, false);
                                    retorno = true;
                                }
                            }
                        }
                        if (St_enviaremail)
                        {
                            using (PdfExportFilter pdf = new PdfExportFilter())
                            {
                                string path_anexo = TCN_CadParamGer.BuscaVlString("PATH_ANEXO_EMAIL", null);
                                if (string.IsNullOrEmpty(path_anexo))
                                    throw new Exception("Não existe path anexo cadastrado nas configurações gerais do sistema!");
                                if (!System.IO.Directory.Exists(path_anexo))
                                    System.IO.Directory.CreateDirectory(path_anexo);
                                if (!path_anexo.EndsWith("\\"))
                                    path_anexo += System.IO.Path.DirectorySeparatorChar.ToString();
                                path_anexo += "NFCE" + DateTime.Now.Date.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf";
                                pdf.Export(this.reportManager.Reports[0].Document, path_anexo, false);
                                if (Anexos == null)
                                    Anexos = new List<string>();
                                Anexos.Add(path_anexo);
                                new Email(Destinatarios,
                                              Titulo,
                                              Mensagem,
                                              Anexos).EnviarEmail();
                                retorno = true;
                            }
                        }
                    }
                    else
                        Editar();
                }
                else
                    Editar();
            }
            catch (Exception erro)
            { MessageBox.Show(erro.Message, "Mensagem"); }
            return retorno;
        }

        public bool Gera_Relatorio(string Documento,
                                   bool St_imprimir,
                                   bool St_visualizar,
                                   bool St_enviaremail,
                                   bool St_exportPdf,
                                   string Path_exportPdf,
                                   List<string> Destinatarios,
                                   List<string> Anexos,
                                   string Titulo,
                                   string Mensagem)
        {
            return Gera_Relatorio(Documento,
                                  St_imprimir,
                                  St_visualizar,
                                  St_enviaremail,
                                  St_exportPdf,
                                  Path_exportPdf,
                                  Destinatarios,
                                  Anexos,
                                  Titulo,
                                  Mensagem,
                                  true);
        }

        public bool BuscaRelatorio()
        {
            //BUSCA O CAD REPORT SE NÃO TIVER
            if ((!string.IsNullOrEmpty(Cad_Report.NM_Classe)) ||
                (!string.IsNullOrEmpty(Cad_Report.ID_RDC)))
            {
                TList_Cad_Report lista = TCN_Cad_Report.Buscar(0,
                                                               string.Empty,
                                                               Cad_Report.Modulo,
                                                               Cad_Report.NM_Classe,
                                                               Cad_Report.Ident,
                                                               0,
                                                               Cad_Report.ID_RDC,
                                                               false,
                                                               false,
                                                               false);

                if (lista.Count > 0)
                {
                    Cad_Report = lista[0];
                    return true;
                }
                return false;
            }
            return false;
        }

        public void Parametros(object sender, GetReportParameterEventArgs e)
        {
            try
            {
                if (e.Parameters.Count > 0)
                {
                    for (int x = 0; x < e.Parameters.Count; x++)
                    {
                        if (e.Parameters[x].Name.Trim().ToUpper().Equals("USUARIO"))
                            e.Parameters["USUARIO"].Value = Utils.Parametros.pubLogin;
                        else
                        {
                            if (e.Parameters[x].Name.Trim().ToUpper().Equals("TERMINAL"))
                                e.Parameters["TERMINAL"].Value = Utils.Parametros.pubTerminal + " - " + new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.ds_terminal").ToString();
                            else
                            {
                                if (e.Parameters[x].Name.Trim().ToUpper().Equals("RODAPE_RELATORIO"))
                                    e.Parameters["RODAPE_RELATORIO"].Value = TCN_CadParamGer.BuscaVL_String_Empresa("RODAPE_RELATORIO", string.Empty);
                                else
                                {
                                    if (Parametros_Relatorio == null ? false :
                                        (!Parametros_Relatorio.ContainsKey("IMAGEM_RELATORIO")) &&
                                        e.Parameters[x].Name.Trim().ToUpper().Equals("IMAGEM_RELATORIO"))
                                        e.Parameters["IMAGEM_RELATORIO"].Value = TCN_CadParamGer.BuscaVlImagem("IMAGEM_RELATORIO", string.Empty, null);
                                    else
                                    {
                                        if (e.Parameters[x].Name.Trim().ToUpper().Equals("ESTILO_RELATORIO"))
                                        {
                                            if (TCN_CadParamGer.BuscaVL_Bool("ESTILO_RELATORIO", string.Empty, null) == "S")
                                                e.Parameters["ESTILO_RELATORIO"].Value = "S";
                                            else
                                                e.Parameters["ESTILO_RELATORIO"].Value = "N";
                                        }
                                        else
                                        {
                                            if ((Parametros_Relatorio != null) && (Parametros_Relatorio.Count > 0))
                                            {
                                                if (Parametros_Relatorio.ContainsKey(e.Parameters[x].Name.Trim().ToUpper().ToString()))
                                                    e.Parameters[x].Value = Parametros_Relatorio[e.Parameters[x].ToString()];
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch { }
        }

        public string DefineDesigner()
        {
            InlineReportSlot InlineNF = new InlineReportSlot();
            XmlDocument docXML = new XmlDocument();
            this.reportManager.Reports.Add(InlineNF);

            if (Cad_Report.Code_Report == null)
                docXML.LoadXml(RDCPadrao.Code_Report);
            else
                docXML.LoadXml(System.Text.ASCIIEncoding.UTF8.GetString(Utils.Compact_Data.Descompactar(Cad_Report.Code_Report, string.Empty)));

            InlineNF.DocumentStream = docXML.InnerXml;
            InlineNF.DesignTemplate();
            docXML.LoadXml(InlineNF.DocumentStream);

            return docXML.InnerXml;
        }

        public void Editar()
        {
            try
            {
                //CHAMA A CLASSE Q DEFINE O MODELO DO RELATORIO
                string modeloRelatorio = DefineDesigner();

                //GRAVA O REPORT
                if ((modeloRelatorio != "") && (!Homologacao))
                {
                    bool gravarRelatorio = false;
                    bool verificar = false;

                    if (Cad_Report.Code_Report == null)
                        verificar = true;
                    else
                        if (System.Text.ASCIIEncoding.UTF8.GetString(Utils.Compact_Data.Descompactar(Cad_Report.Code_Report, string.Empty)) != modeloRelatorio)
                        verificar = true;

                    //VERIFICA SE FOR MASTER
                    if (verificar)
                    {
                        //GRAVA O REPORT JÁ
                        if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR RELATÓRIO", null))
                            gravarRelatorio = true;
                        else
                        {
                            if (MessageBox.Show("Deseja realmente salvar a alteração neste relatório?\nAtenção, ao salvar a alteração PERDERÁ o suporte de versão deste relatório!", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                            System.Windows.Forms.DialogResult.Yes)
                            {
                                Cad_Report.ID_RDC = "";
                                gravarRelatorio = true;
                            }
                            else
                                gravarRelatorio = false;
                        }

                        //GRAVA O REPORT
                        if (gravarRelatorio)
                        {
                            if (Cad_Report.DS_Report != "")
                            {
                                if (Cad_Report.Versao == 0)
                                    Cad_Report.Versao = 1;

                                Cad_Report.Code_Report = Utils.Compact_Data.Compactar(System.Text.ASCIIEncoding.UTF8.GetBytes(modeloRelatorio));
                                string ret_report = TCN_Cad_Report.GravarReport(Cad_Report, null);
                                Cad_Report.ID_Report = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_report, "@P_ID_REPORT"));
                            }
                        }

                        if ((Utils.Parametros.pubLogin == "MASTER") || (Utils.Parametros.pubLogin == "DESENV"))
                        {
                            if (MessageBox.Show("Deseja publicar esta versão?\nAtenção, ao publicar a versão já será homologada automaticamente!", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                Cad_Report.Versao++;
                                Cad_Report.lConsulta = TCN_Cad_Consulta.Busca(decimal.Zero,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              Cad_Report.ID_Report);
                                AtualizarRDC.GravarRDC(Cad_Report, null, "P");
                            }
                        }
                    }
                }
                else
                    Cad_Report.Code_Report = Compact_Data.Compactar(System.Text.ASCIIEncoding.UTF8.GetBytes(modeloRelatorio));
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem");
            }
        }

        public bool ImprimiGraficoReduzida(string Print,
                                           bool St_imprimir,
                                           bool St_visualizar,
                                           List<string> Destinatarios,
                                           string Titulo,
                                           string Mensagem,
                                           short copia)
        {
            bool retorno = false;
            try
            {
                //VERIFICA SE JÁ TEM O ITEM LANÇADO
                if (string.IsNullOrEmpty(Cad_Report.DS_Report))
                {
                    Cad_Report.Modulo = Modulo;
                    Cad_Report.NM_Classe = NM_Classe;
                    Cad_Report.DS_Report = NM_Classe;
                    Cad_Report.Ident = Ident;
                }

                //Se nao existir relatorio no banco, baixar da net
                if (!BuscaRelatorio())
                    if (AtualizarRDC.VerificarVersaoRDC(Cad_Report, false))
                        BuscaRelatorio();

                XmlDocument docXMLRelatorio = new XmlDocument();
                if (Cad_Report.Code_Report != null)
                    docXMLRelatorio.LoadXml(System.Text.ASCIIEncoding.UTF8.GetString(Compact_Data.Descompactar(Cad_Report.Code_Report, string.Empty)));

                //CRIA O ARQUIVO PARA O RELATORIO
                InlineReportSlot ArquivoRelatorio = new InlineReportSlot();
                //ADICIONAR O NOME E OS PARAMETROS
                ArquivoRelatorio.GetReportParameter += new GetReportParameterEventHandler(Parametros);
                Nome_Relatorio = Nome_Relatorio.Replace(' ', '_');
                ArquivoRelatorio.ReportName = Nome_Relatorio;
                reportManager.DataSources.Add("DTS", DTS_Relatorio);

                if (Cad_Report.Code_Report != null)
                {
                    //ADICIONA O STREAM DO RELATORIO (XML)
                    ArquivoRelatorio.DocumentStream = docXMLRelatorio.InnerXml;
                    reportManager.Reports.Add(ArquivoRelatorio);

                    if (!Altera_Relatorio)
                    {
                        reportManager.Reports[0].LoadReport();
                        reportManager.Reports[0].Prepare();
                        reportManager.Reports[0].RenderDocument();

                        using (PerpetuumSoft.Reporting.View.PreviewForm view = new PerpetuumSoft.Reporting.View.PreviewForm(reportManager.Reports[0]))
                        {
                            if (St_imprimir)
                            {
                                using (ReportPrintDocument rpd = new ReportPrintDocument())
                                {
                                    rpd.PrinterSettings.PrinterName = Print;
                                    rpd.Source = ArquivoRelatorio;
                                    for (int i = 0; i < copia; i++)
                                        rpd.Print();
                                }
                            }
                            else if (St_visualizar)
                            {
                                view.WindowState = FormWindowState.Maximized;
                                view.ShowDialog();
                                retorno = true;
                            }
                        }
                        if (Destinatarios == null ? false : Destinatarios.Count > 0)
                        {
                            using (PdfExportFilter pdf = new PdfExportFilter())
                            {
                                string path_anexo = TCN_CadParamGer.BuscaVlString("PATH_ANEXO_EMAIL", null);
                                if (string.IsNullOrEmpty(path_anexo))
                                    throw new Exception("Não existe path anexo cadastrado nas configurações gerais do sistema!");
                                if (!System.IO.Directory.Exists(path_anexo))
                                    System.IO.Directory.CreateDirectory(path_anexo);
                                if (!path_anexo.EndsWith("\\"))
                                    path_anexo += System.IO.Path.DirectorySeparatorChar.ToString();
                                path_anexo += "NFCE" + DateTime.Now.Date.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf";
                                pdf.Export(this.reportManager.Reports[0].Document, path_anexo, false);
                                List<string> Anexos = new List<string>();
                                Anexos.Add(path_anexo);
                                new Email(Destinatarios,
                                          Titulo,
                                          Mensagem,
                                          Anexos).EnviarEmail();
                                retorno = true;
                            }
                        }
                    }
                    else
                        Editar();
                }
                else
                    Editar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem");
            }
            return retorno;
        }
    }
}