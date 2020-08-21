using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaNegocio.ConfigGer;
using System.Windows.Forms;
using CamadaDados.Consulta.Cadastro;
using PerpetuumSoft.Olap.Windows.Forms;
using PerpetuumSoft.Olap;
using System.Xml;
using CamadaNegocio.Consulta.Cadastro;

namespace FormRelPadrao
{
    public class DataCube
    {
        public string Nome_CuboDados;
        public BindingSource DTS_CuboDados;
        public string NM_Classe = "";
        public string Modulo = "";
        public string Ident = "";
        public string vURLWebService = "";
        public bool Homologacao = false;
        public bool Altera_CuboDados = false;
        public TRegistro_Cad_Report Cad_Report = new TRegistro_Cad_Report();

        public bool Gera_DataCube()
        {
            return Gera_DataCube(string.Empty,
                                 false,
                                 true,
                                 false,
                                 new List<string>(),
                                 string.Empty,
                                 string.Empty);
        }

        public bool Gera_DataCube(string Documento,
                                   bool St_imprimir,
                                   bool St_visualizar,
                                   bool St_enviaremail,
                                   List<string> Destinatarios,
                                   string Titulo,
                                   string Mensagem)
        {
            bool retorno = false;
            TFPreviewDataCube fDataCube = new TFPreviewDataCube();
            fDataCube.Text = Cad_Report.DS_Report;

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

                XmlDocument docXMLRelatorio = new XmlDocument();
                
                fDataCube.bsCubo.DataSource = DTS_CuboDados;

                if (Cad_Report.Code_DataCube != null)
                {
                    docXMLRelatorio.LoadXml(System.Text.ASCIIEncoding.UTF8.GetString(Utils.Compact_Data.Descompactar(Cad_Report.Code_DataCube, string.Empty)));
                    fDataCube.dataCube.Layout = docXMLRelatorio.InnerXml;
                }

                //ADD O LAYOUT
                fDataCube.dcGrid.RefreshDataCubeGrid();
                try
                {
                    fDataCube.dataCube.Recalculate();
                }
                catch { }

                if (Cad_Report.Code_DataCube != null)
                {
                    if (Altera_CuboDados == false)
                    {
                        fDataCube.dcGrid.ShowOpen = false;
                        fDataCube.dcGrid.ShowSave = false;
                        fDataCube.dcGrid.ShowWizard = true;

                        if (St_imprimir)
                            fDataCube.dcGrid.PrintPreview();
                        else if (St_visualizar)
                        {
                            fDataCube.WindowState = FormWindowState.Maximized;
                            fDataCube.ShowDialog();
                            retorno = true;
                        }
                    }
                    else
                    {
                        //CHAMA A CLASSE Q DEFINE O MODELO DO RELATORIO
                        string modeloRelatorio = DefineDesigner(fDataCube);

                        if (modeloRelatorio != "")
                            Cad_Report.Code_DataCube = Utils.Compact_Data.Compactar(System.Text.ASCIIEncoding.UTF8.GetBytes(modeloRelatorio));

                        //GRAVA O REPORT
                        if ((Cad_Report.DS_Report) != "" && (!Homologacao))
                            TCN_Cad_Report.GravarReport(Cad_Report, null);
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
                        string modeloRelatorio = DefineDesigner(fDataCube);

                        if (modeloRelatorio != "")
                            Cad_Report.Code_DataCube = Utils.Compact_Data.Compactar(System.Text.ASCIIEncoding.UTF8.GetBytes(modeloRelatorio));

                        //GRAVA O REPORT
                        if ((Cad_Report.DS_Report) != "" && (!Homologacao))
                            TCN_Cad_Report.GravarReport(Cad_Report, null);
                    }
                    else
                        Cad_Report.Code_DataCube = Utils.Compact_Data.Compactar(System.Text.ASCIIEncoding.UTF8.GetBytes(DefineDesigner(fDataCube)));
                }
            return retorno;
        }

        public string DefineDesigner(TFPreviewDataCube previewDataCube)
        {
            if (previewDataCube == null)
                previewDataCube = new TFPreviewDataCube();

            if (Cad_Report.Code_DataCube != null)
            {
                XmlDocument docXML = new XmlDocument();
                docXML.LoadXml(System.Text.ASCIIEncoding.UTF8.GetString(Utils.Compact_Data.Descompactar(Cad_Report.Code_DataCube, string.Empty)));
                previewDataCube.dataCube.Layout = docXML.InnerXml;
            }

            previewDataCube.dcGrid.ShowWizardDialog();

            return previewDataCube.dataCube.Layout;
        }
    }
}
