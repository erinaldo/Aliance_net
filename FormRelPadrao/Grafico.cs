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
using System.Xml;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using PerpetuumSoft.Charts.Windows.Forms;
using PerpetuumSoft.Charts;

namespace FormRelPadrao
{
    public class Grafico
    {
        public PerpetuumSoft.Charts.Windows.Forms.ChartViewer ChartViewer = new PerpetuumSoft.Charts.Windows.Forms.ChartViewer();
        public string Nome_Relatorio = string.Empty;
        public string NM_Classe = string.Empty;
        public string Modulo = string.Empty;
        public string Ident = string.Empty;
        public string vURLWebService = string.Empty;
        public bool Homologacao = false;
        public BindingSource DTS_Grafico = new BindingSource();
        public bool Altera_Grafico = false;
        public TRegistro_Cad_Report Cad_Report = new TRegistro_Cad_Report();

        public bool Gera_Grafico()
        {
            return Gera_Grafico(string.Empty,
                                 false,
                                 true,
                                 false,
                                 new List<string>(),
                                 string.Empty,
                                 string.Empty);
        }

        public bool Gera_Grafico(string Documento,
                                   bool St_imprimir,
                                   bool St_visualizar,
                                   bool St_enviaremail,
                                   List<string> Destinatarios,
                                   string Titulo,
                                   string Mensagem)
        {
            bool retorno = false;
                //AQUI A CLASSE PARA VISUALIZAçÂO DO GRAFICO
                //BUSCA O CAD REPORT SE NÃO TIVER
                if ((Cad_Report.ID_Report == 0) && (NM_Classe != ""))
                {
                    TList_Cad_Report lista = TCN_Cad_Report.Buscar(0, 
                                                                   string.Empty, 
                                                                   Modulo, 
                                                                   NM_Classe, 
                                                                   Ident, 
                                                                   0, 
                                                                   string.Empty,
                                                                   false, 
                                                                   false, 
                                                                   false);

                    if (lista.Count > 0)
                        Cad_Report = lista[0];
                }

                ChartViewer.DataSources.Add(new ChartDataSource(DTS_Grafico, "DTS"));

                XmlDocument docXMLRelatorio = new XmlDocument();
                if (Cad_Report.Code_Chart != null)
                    docXMLRelatorio.LoadXml(System.Text.ASCIIEncoding.UTF8.GetString(Utils.Compact_Data.Descompactar(Cad_Report.Code_Chart, string.Empty)));

                if (Cad_Report.Code_Chart != null)
                {
                    if (Altera_Grafico == false)
                    {
                        TFPreviewChart fChart = new TFPreviewChart();
                        fChart.Text = Cad_Report.DS_Report;
                        fChart.chartViewer.ChartStream = docXMLRelatorio.InnerXml;
                        fChart.chartViewer.DataSources.Add(new ChartDataSource(DTS_Grafico, "DTS"));
                        fChart.chartViewer.ShowNew = false;
                        fChart.chartViewer.ShowSave = false;
                        fChart.chartViewer.ShowDesigner = false;
                        fChart.chartViewer.ResumeLayout(true);

                        if (St_imprimir)
                            fChart.chartViewer.PrintDialog();
                        else if (St_visualizar)
                        {
                            fChart.WindowState = FormWindowState.Maximized;
                            fChart.ShowDialog();
                            retorno = true;
                        }
                    }
                    else
                    {
                        //ADICIONA O STREAM DO RELATORIO (XML)
                        ChartViewer.ChartStream = docXMLRelatorio.InnerXml;

                        //DEFINE O DESIGNER
                        ChartViewer.RunDesigner();

                        //BUSCA OS DADOS DO DESIGNER EM XML +E GRAVA EM BINARY
                        if (ChartViewer.ChartStream != "")
                        {
                            docXMLRelatorio.LoadXml(ChartViewer.ChartStream);

                            //INCREMENTA NOVAMENTE OS DADOS
                            Cad_Report.Code_Chart = Utils.Compact_Data.Compactar(System.Text.ASCIIEncoding.UTF8.GetBytes(docXMLRelatorio.InnerXml));

                            //grava o report
                            if ((Cad_Report.DS_Report) != "" && (!Homologacao))
                                TCN_Cad_Report.GravarReport(Cad_Report, null);
                        }
                    }
                }
                else
                {
                    //VERIFICA SE JÁ TEM O ITEM LANÇADO
                    if (Cad_Report.ID_Report == 0)
                    {
                        Cad_Report.Modulo = Modulo;
                        Cad_Report.NM_Classe = NM_Classe;
                        Cad_Report.DS_Report = NM_Classe;
                        Cad_Report.Ident = Ident;
                        Cad_Report.Versao = 1;

                        //CHAMA A CLASSE Q DEFINE O MODELO DO RELATORIO
                        string modeloRelatorio = DefineDesigner(null);

                        if (modeloRelatorio != "")
                            Cad_Report.Code_Chart = Utils.Compact_Data.Compactar(System.Text.ASCIIEncoding.UTF8.GetBytes(modeloRelatorio));

                        //GRAVA O REPORT
                        if ((Cad_Report.DS_Report) != "" && (!Homologacao))
                            TCN_Cad_Report.GravarReport(Cad_Report, null);
                    }
                    else
                        Cad_Report.Code_Chart = Utils.Compact_Data.Compactar(System.Text.ASCIIEncoding.UTF8.GetBytes(DefineDesigner(ChartViewer)));
                }

            return retorno;
        }


        public string DefineDesigner(ChartViewer ChartViewerParam)
        {
            ChartViewer ChartViewer = ChartViewerParam;
            if (ChartViewerParam != null)
                ChartViewer = new ChartViewer();

            if (Cad_Report.Code_Chart != null)
            {
                XmlDocument docXML = new XmlDocument();
                docXML.LoadXml(System.Text.ASCIIEncoding.UTF8.GetString(Utils.Compact_Data.Descompactar(Cad_Report.Code_Chart, string.Empty)));
                ChartViewer.ChartStream = docXML.InnerXml;
            }

            ChartViewer.RunDesigner();

            return ChartViewer.ChartStream;
        }
    }
}
