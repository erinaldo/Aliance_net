using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using CamadaNegocio.Diversos;
using CamadaNegocio.ConfigGer;
using PerpetuumSoft.Reporting.Components;
using PerpetuumSoft.Reporting.View;
using PerpetuumSoft.Reporting.Wizards;
using PerpetuumSoft.Reporting.DOM;
using PerpetuumSoft.Framework.Drawing;
using System.Xml;
using System.IO;
using System.Drawing;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Titulo;
using CamadaNegocio.Financeiro.Cadastros;

namespace FormRelPadrao
{
    public class LayoutCheque : Relatorio
    {
        public void Imprime_Cheque(List<TRegistro_LanTitulo> ListaTitulo)
        {
            Imprime_Cheque(ListaTitulo,
                           true,
                           false,
                           false,
                           null,
                           string.Empty,
                           string.Empty);
        }

        public void Imprime_Cheque(List<TRegistro_LanTitulo> ListaTitulo,
                                  bool St_imprimir,
                                  bool St_visualizar,
                                  bool St_enviaremail,
                                  List<string> Destinatarios,
                                  string Titulo,
                                  string Mensagem)
        {
            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(ListaTitulo[0].Cd_empresa, string.Empty, string.Empty, null);

            //Buscar moeda para impressao dos cheques
            ListaTitulo.ForEach(p =>
                {
                    //Buscar moeda da conta gerencial
                    CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda =
                        new CamadaDados.Financeiro.Cadastros.TCD_Moeda().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fin_contager x "+
                                            "where x.cd_moeda = a.cd_moeda "+
                                            "and x.cd_contager = '" + p.Cd_contager + "')"
                            }
                        }, 1, string.Empty);
                    if (lMoeda.Count > 0)
                    {
                        p.Ds_moeda = lMoeda[0].Ds_moeda_singular;
                        p.Ds_moeda_plural = lMoeda[0].Ds_moeda_plural;
                    }
                });
            this.reportManager.DataSources.Add("BIMEMPRESA", BinEmpresa);
            this.reportManager.DataSources.Add("DTS", ListaTitulo.OrderBy(p => p.Nr_cheque).ToList());
            //BUSCA OS DADOS DO BANCO
            TRegistro_CadContaGer RegModelo = TCN_CadContaGer.Buscar(ListaTitulo[0].Cd_contager,
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
                                                                     null)[0];

            this.Imprime(RegModelo,
                         St_imprimir,
                         St_visualizar,
                         St_enviaremail,
                         Destinatarios,
                         Titulo,
                         Mensagem);
            //Para cada cheque impresso, alterar flag st_impresso para S - Sim
            TList_RegLanTitulo lTitulo = new TList_RegLanTitulo();
            ListaTitulo.ForEach(p =>
                {
                    p.St_impresso = "S";
                    lTitulo.Add(p);
                });
            try
            {
                CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.AlterarTitulos(lTitulo, null);
            }
            catch
            { }
        }

        private void Imprime(TRegistro_CadContaGer LayoutCh,
                             bool St_imprimir,
                             bool St_visualizar,
                             bool St_enviaremail,
                             List<string> Destinatarios,
                             string Titulo,
                             string Mensagem)
        {
                InlineReportSlot InlineNF = new InlineReportSlot();
                if (!string.IsNullOrEmpty(LayoutCh.LayoutCheque))
                    InlineNF.DocumentStream = LayoutCh.LayoutCheque;
                else
                    InlineNF.DocumentStream = Utils.ResourcesUtils.ModeloCheque; 
                this.reportManager.Reports.Add(InlineNF);
                this.reportManager.Reports[0].LoadReport();
                this.reportManager.Reports[0].Prepare();
                this.reportManager.Reports[0].GetReportParameter += new PerpetuumSoft.Reporting.Components.GetReportParameterEventHandler(this.Parametros);
                if (St_imprimir)
                {
                    using (System.Windows.Forms.PrintDialog pd = new PrintDialog())
                    {
                        pd.UseEXDialog = true;
                        if (pd.ShowDialog() == DialogResult.OK)
                        {
                            using (ReportPrintDocument rpd = new ReportPrintDocument())
                            {
                                rpd.PrinterSettings = pd.PrinterSettings;
                                rpd.Source = InlineNF;
                                rpd.Print();
                            }
                        }
                    }
                }
                else if (St_visualizar)
                {
                    using (PerpetuumSoft.Reporting.View.PreviewForm view = new PerpetuumSoft.Reporting.View.PreviewForm(this.reportManager.Reports[0]))
                    {
                        view.WindowState = FormWindowState.Maximized;
                        view.ShowDialog();
                    }
                }

                if (St_enviaremail)
                    using (PerpetuumSoft.Reporting.Export.Pdf.PdfExportFilter pdf = new PerpetuumSoft.Reporting.Export.Pdf.PdfExportFilter())
                    {
                        string path_anexo = System.IO.Path.GetTempPath();
                        if (!path_anexo.EndsWith("\\"))
                            path_anexo += System.IO.Path.DirectorySeparatorChar.ToString();
                        path_anexo += "CHEQUE" + DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Hour.ToString() + DateTime.Now.Date.Minute.ToString() + DateTime.Now.Date.Second.ToString() + ".pdf";
                        if (pdf.ShowDialog() == DialogResult.OK)
                        {
                            pdf.Export(InlineNF.Document, path_anexo, false);
                            if (new Email(Destinatarios,
                                          Titulo,
                                          Mensagem,
                                          new List<string>()
                                          {
                                              path_anexo
                                          }).EnviarEmail())
                                MessageBox.Show("Email enviado com sucesso.");
                            if (System.IO.File.Exists(path_anexo))
                                try
                                {
                                    System.IO.File.Delete(path_anexo);
                                }
                                catch { }
                        }
                    }
        }

        public string Gera_ModeloCheque(TRegistro_CadContaGer RegModelo)
        {
            TList_CadContaGer listCC = new TList_CadContaGer();
            this.reportManager.DataSources.Add("DTS", listCC);

            return DefineDesigner(RegModelo);
        }

        private  string DefineDesigner(TRegistro_CadContaGer RegModelo)
        {
            InlineReportSlot InlineCheque = new InlineReportSlot();
            XmlDocument docXML = new XmlDocument();

            if (string.IsNullOrEmpty(RegModelo.LayoutCheque))
                docXML.LoadXml(Utils.ResourcesUtils.ModeloCheque);
            else
                docXML.LoadXml(RegModelo.LayoutCheque);

            InlineCheque.DocumentStream = docXML.InnerXml;
            //this.reportManager.Reports.Add(InlineCheque);
            InlineCheque.DesignTemplate();
            docXML.LoadXml(InlineCheque.DocumentStream);
            return docXML.InnerXml;
        }
    }
}
