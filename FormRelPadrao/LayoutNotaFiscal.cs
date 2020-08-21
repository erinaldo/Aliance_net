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
using CamadaDados.Faturamento.Cadastros;
using System.Xml;
using System.IO;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Financeiro.Duplicata;
using System.Drawing;

namespace FormRelPadrao
{
    public class LayoutNotaFiscal : Relatorio
    {
        public string imagemBranco = "/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwg" +
                                   "JC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIy" +
                                   "MjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCAABAAEDASIAAhEBAxEB/8QA" +
                                   "HwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIh" +
                                   "MUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVW" +
                                   "V1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXG" +
                                   "x8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQF" +
                                   "BgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAV" +
                                   "YnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOE" +
                                   "hYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq" +
                                   "8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD3+iiigD//2Q==";

        public string Gera_ModeloNF(TRegistro_CFGImpNF RegCfgImpNf)
        {
            TList_RegLanFaturamento listNF = new TList_RegLanFaturamento();
            this.reportManager.DataSources.Add("DTS", listNF);

            return DefineDesigner(RegCfgImpNf);
        }

        private TList_RegLanFaturamento_Item ObservacaoFiscalItemNf(TRegistro_LanFaturamento rNf, decimal Tam_DadosAdic)
        {
            TList_RegLanFaturamento_Item lItens = new TList_RegLanFaturamento_Item();
            rNf.ItensNota.ForEach(p =>
                {
                    lItens.Add(p);
                    if (p.Observacao_item.Trim() != string.Empty)
                    {
                        string[] obs = p.Observacao_item.Trim().Split(new char[] { '\n' });
                        if (Tam_DadosAdic > 0)
                        {
                            foreach (string str in obs)
                                if (str.Trim() != string.Empty)
                                {
                                    if (str.Trim().Length > Convert.ToInt32(Tam_DadosAdic))
                                    {
                                        int index = 0;
                                        int total_copiar = 0;
                                        do
                                        {
                                            total_copiar = (Convert.ToInt32(Tam_DadosAdic) > str.Trim().Substring(index, str.Trim().Length - index).Length ?
                                                str.Trim().Substring(index, str.Trim().Length - index).Length : Convert.ToInt32(Tam_DadosAdic));
                                            lItens.Add(new TRegistro_LanFaturamento_Item()
                                            {
                                                Ds_produto = str.Trim().Substring(index, total_copiar)
                                            });
                                            index += total_copiar;
                                        }
                                        while (index < str.Trim().Length);
                                    }
                                    else
                                        lItens.Add(new TRegistro_LanFaturamento_Item()
                                        {
                                            Ds_produto = str
                                        });
                                }
                        }
                        else
                            foreach (string str in obs)
                                if(str.Trim() != string.Empty)
                                    lItens.Add(new TRegistro_LanFaturamento_Item()
                                    {
                                        Ds_produto = str
                                    });
                    }
                });
            return lItens;
        }

        public void Imprime_NF(TRegistro_LanFaturamento listNF, 
                               bool St_imprimir, 
                               bool St_visualizar, 
                               bool St_enviaremail, 
                               List<string> Destinatarios,
                               string Titulo,
                               string Mensagem)
        {
            TList_CFGImpNF CfgImpNf = TCN_CFGImpNF.Buscar(listNF.Nr_serie, listNF.Cd_modelo, listNF.Cd_empresa, null);
            if (CfgImpNf.Count > 0)
            {
                //Buscar itens da nota
                listNF.ItensNota = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(listNF.Cd_empresa, listNF.Nr_lanctofiscalstr, string.Empty, null);
                //Tratar observacao Fiscal dos itens da nota
                listNF.ItensNota = this.ObservacaoFiscalItemNf(listNF, CfgImpNf[0].Tam_dadosadic);
                //ADD A QTD DE LINHAS Q FALTA
                if (listNF.ItensNota.Count < CfgImpNf[0].Qt_itensnota)
                {
                    int QtdItemVazio = (Convert.ToInt32(CfgImpNf[0].Qt_itensnota) - listNF.ItensNota.Count);
                    if (listNF.Vl_desconto > 0)
                        QtdItemVazio -= 1;
                    for (int i = 0; i < QtdItemVazio; i++)
                        listNF.ItensNota.Add(new TRegistro_LanFaturamento_Item());
                    if(listNF.Vl_desconto > 0)
                        listNF.ItensNota.Add(new TRegistro_LanFaturamento_Item()
                                            {
                                                Ds_produto = "Desconto sobre produtos: " + Math.Round(listNF.Vl_desconto, 2)
                                            });
                }
                else
                {
                    TList_RegLanFaturamento_Item ListaItem = new TList_RegLanFaturamento_Item();
                    int contador = 0;
                    
                    for (int i = 0; i < listNF.ItensNota.Count; i++)
                    {
                        if (contador == ((Convert.ToInt32(CfgImpNf[0].Qt_itensnota) - 1)))
                        {
                            ListaItem.Add(new TRegistro_LanFaturamento_Item()
                                {
                                   Ds_produto = "VALOR A TRANSPORTAR... " + ListaItem.Sum(p => p.Vl_subtotal).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true))
                                });
                            for (int x = 0; x < CfgImpNf[0].Qt_linha; x++)
                                ListaItem.Add(new TRegistro_LanFaturamento_Item());
                            ListaItem.Add(new TRegistro_LanFaturamento_Item()
                                {
                                    Ds_produto = "VALOR TRANSPORTADO... " + ListaItem.Sum(p => p.Vl_subtotal).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true)) 
                                });
                            //PARA PULAR DE LINHA
                            contador = 1;
                        }

                        contador++;
                        ListaItem.Add(listNF.ItensNota[i]);
                        if (i == (listNF.ItensNota.Count - 1))
                        {
                            if (CfgImpNf[0].Qt_itensnota > 0)
                            {
                                int QtdItemVazio = (Convert.ToInt32(CfgImpNf[0].Qt_itensnota) - contador);
                                if (listNF.Vl_desconto > 0)
                                    QtdItemVazio -= 1;
                                for (int x = 0; x < QtdItemVazio; x++)
                                    ListaItem.Add(new TRegistro_LanFaturamento_Item());
                                if (listNF.Vl_desconto > 0)
                                    ListaItem.Add(new TRegistro_LanFaturamento_Item()
                                    {
                                        Ds_produto = "Desconto sobre produtos: " + Math.Round(listNF.Vl_desconto, 2)
                                    });
                            }
                        }
                    }

                    listNF.ItensNota.Clear();
                    listNF.ItensNota = ListaItem;
                }

                if (listNF.Duplicata.Count == 0)
                    listNF.Duplicata.Add(new TRegistro_LanDuplicata());

                //ADD AS PARCELAS
                for (int i = 0; i < listNF.Duplicata[0].Parcelas.Count; i++)
                {
                    this.Parametros_Relatorio.Add("CDPARCELA" + i, listNF.Duplicata[0].Parcelas[i].Cd_parcela.ToString());
                    this.Parametros_Relatorio.Add("DTVENCTO" + i, listNF.Duplicata[0].Parcelas[i].Dt_vencto);
                    this.Parametros_Relatorio.Add("VLPARCELA" + i, listNF.Duplicata[0].Parcelas[i].Vl_parcela);
                }

                this.reportManager.DataSources.Add("DTS", listNF);

                Imprime(CfgImpNf[0], 
                        listNF.Nr_notafiscal.ToString(),
                        St_imprimir, 
                        St_visualizar, 
                        St_enviaremail, 
                        Destinatarios, 
                        Titulo, 
                        Mensagem);
            }
        }

        private string DefineDesigner(TRegistro_CFGImpNF RegCfgImpNf)
        {
            InlineReportSlot InlineNF = new InlineReportSlot();
            XmlDocument docXML = new XmlDocument();
            XmlNode no;
            this.reportManager.Reports.Add(InlineNF);

            if (RegCfgImpNf.Modelorst.Trim().Equals(string.Empty))
            {
                Document doc = new Document();
                doc.Name = "NotaFiscal";
                doc.IsTemplate = true;
                doc.ScriptLanguage = ScriptLanguage.CSharp;

                Page page = new Page();
                page.Name = "pageNotaFiscal";
                page.Size = new PerpetuumSoft.Framework.Drawing.Vector(Convert.ToDouble(RegCfgImpNf.Larguranf), Convert.ToDouble(RegCfgImpNf.Alturanf)).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                page.TemplateSize = new PerpetuumSoft.Framework.Drawing.Vector(Convert.ToDouble(RegCfgImpNf.Larguranf), Convert.ToDouble(RegCfgImpNf.Alturanf)).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                page.PaperKind = PaperKind.Custom;
                page.CustomSize = new PerpetuumSoft.Framework.Drawing.Vector(Convert.ToDouble(RegCfgImpNf.Larguranf), Convert.ToDouble(RegCfgImpNf.Alturanf)).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                doc.Pages.Add(page);

                Picture imagemFundo = new Picture();
                imagemFundo.Name = "ImagemNF";
                imagemFundo.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                imagemFundo.Size = new PerpetuumSoft.Framework.Drawing.Vector(Convert.ToDouble(RegCfgImpNf.Larguranf), Convert.ToDouble(RegCfgImpNf.Alturanf)).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                if (RegCfgImpNf.Img != null)
                    imagemFundo.Image = RegCfgImpNf.Imagem;
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    ms.Write(Convert.FromBase64String(imagemBranco), 0, Convert.FromBase64String(imagemBranco).Length);
                    imagemFundo.Image = Image.FromStream(ms);
                }
                page.Controls.Add(imagemFundo);

                DataBand dataBand = new DataBand();
                dataBand.Name = "BandaDadosGeral";
                page.Controls.Add(dataBand);
                dataBand.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                dataBand.Size = new PerpetuumSoft.Framework.Drawing.Vector(Convert.ToDouble(RegCfgImpNf.Larguranf), Convert.ToDouble(RegCfgImpNf.Alturanf)).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                dataBand.DataSource = "DTS";
                dataBand.ColumnsCount = 1;
                dataBand.ColumnsGap = Unit.Convert(0.5f, Unit.Centimeter, Unit.InternalUnit);

                DataBand dataBandProduto = new DataBand();
                dataBandProduto.Name = "BandaDadosProdutos";
                dataBand.Controls.Add(dataBandProduto);
                dataBandProduto.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                dataBandProduto.Size = new PerpetuumSoft.Framework.Drawing.Vector(21.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                dataBandProduto.DataSource = "DTS.ItensNota";
                dataBandProduto.ColumnsCount = 1;
                dataBandProduto.ColumnsGap = Unit.Convert(0.5f, Unit.Centimeter, Unit.InternalUnit);

                InlineNF.SaveReport(doc);
            }
            else
            {
                docXML.LoadXml(RegCfgImpNf.Modelorst);

                if (RegCfgImpNf.Img != null)
                {
                    no = docXML.SelectSingleNode(String.Format("/root/Pages/Item/Controls/Item"));
                    XmlNode noImg = no.SelectSingleNode("./Image");

                    if (noImg != null)
                    {
                        if (RegCfgImpNf.Img == null)
                            no.SelectSingleNode("./Image").InnerText = imagemBranco;
                        else
                            no.SelectSingleNode("./Image").InnerText = Convert.ToBase64String(RegCfgImpNf.Img);
                    }
                }

                InlineNF.DocumentStream = docXML.InnerXml;
            }

            InlineNF.DesignTemplate();
            docXML.LoadXml(InlineNF.DocumentStream);

            no = docXML.SelectSingleNode(String.Format("/root/Pages/Item/Controls/Item"));
            XmlNode noImage = no.SelectSingleNode("./Image");

            if (noImage != null)
                no.SelectSingleNode("./Image").InnerText = imagemBranco;

            return docXML.InnerXml;
        }

        private void Imprime(TRegistro_CFGImpNF CfgImpNf, 
                             string Nr_notafiscal,
                             bool St_imprimir, 
                             bool St_visualizar, 
                             bool St_enviaremail, 
                             List<string> Destinatarios, 
                             string Titulo,
                             string Mensagem
                             )
        {
            if (CfgImpNf.Modelorst.Trim() != string.Empty)
            {
                InlineReportSlot InlineNF = new InlineReportSlot();
                InlineNF.DocumentStream = CfgImpNf.Modelorst;
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
                        path_anexo += "NF" + Nr_notafiscal.Trim() + DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Hour.ToString() + DateTime.Now.Date.Minute.ToString() + DateTime.Now.Date.Second.ToString() + ".pdf";
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
        }
    }
}
