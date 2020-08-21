using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Utils;
using FormBusca;

namespace Faturamento
{
    public partial class TFPrintOrcamentoWord : Form
    {
        public CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento rCFG
        { get; set; }
        public CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndereco { get; set; }
        public CamadaDados.Financeiro.Cadastros.TList_CadContatoCliFor lContatoClifor { get; set; }
        public CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor { get; set; }
        public CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento rOrcamento
        { get; set; }
        public CamadaDados.Faturamento.Orcamento.TList_Orcamento_DT_Vencto lParcelas { get; set; }
        public CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item lItem
        { get; set; }
        public TFPrintOrcamentoWord()
        {
            InitializeComponent();
            lItem = new CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item();
        }


        private void GerarPrint(string st_layout)
        {
            ////Mudar Representante
            //DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, "isnull(a.st_representante, 'N')|=|'S'");
            //if (linha != null)
            //{
            //    rOrcamento.Cd_representante = linha["cd_clifor"].ToString();
            //    System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            //    hs.Add("@CD_REP", rOrcamento.Cd_representante);
            //    hs.Add("@NR_ORCAMENTO", rOrcamento.Nr_orcamento);                
            //    new CamadaDados.TDataQuery().executarSql("update tb_fat_orcamento set cd_representante = @CD_REP " +
            //                                                         "where NR_ORCAMENTO = @NR_ORCAMENTO ", hs);
            //}
            Proc_Commoditties.ThreadLoadWordPrint espera = new Proc_Commoditties.ThreadLoadWordPrint("GERANDO PROPOSTA");
            CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item lista = new CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item();
            (bsItens.DataSource as CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item).Where(p => p.St_processar).ToList().ForEach(p => lista.Add(p));
            if (lista.Count == 0)
                return;
            //Abre a aplicação Word e faz uma cópia do documento mapeado
            Microsoft.Office.Interop.Word.Application aplication = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            //Objeto a ser usado nos parâmetros opcionais
            object missing = System.Reflection.Missing.Value;

            //Buscar layout
            byte[] arquivoBuffer = st_layout.ToUpper().Equals("J") ? rCFG.LayoutJaquetado :
                                   st_layout.ToUpper().Equals("R") ? rCFG.LayoutJaquetadoRes :
                                   st_layout.ToUpper().Equals("A") ? rCFG.LayoutAereo :
                                   st_layout.ToUpper().Equals("P") ? rCFG.LayoutPerifericos :
                                   st_layout.ToUpper().Equals("G") ? rCFG.LayoutAgua :
                                   st_layout.ToUpper().Equals("F") ? rCFG.LayoutFlex :
                                   rCFG.LayoutVertical;
                    string extensao = ".docx"; // retornar do banco tbm
                    string nameTemp = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);
                    System.IO.File.WriteAllBytes(
                        nameTemp,
                        arquivoBuffer);
                    object Template = nameTemp;

                    //aplication = new Microsoft.Office.Interop.Word.ApplicationClass();//
                    doc = aplication.Documents.Add(ref Template, ref missing, ref missing, ref missing);

                    //Criar linhas e colunas
                    for (int i = 0; lista.Count > i; i++)
                    {
                        object row = doc.Application.ActiveDocument.Tables[2].Rows[1];
                        doc.Application.ActiveDocument.Tables[2].Rows.Add(ref row);
                    }
                    doc.Tables[2].Cell(1, 1).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    doc.Tables[2].Cell(1, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    doc.Tables[2].Cell(1, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    doc.Tables[2].Cell(1, 3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    doc.Tables[2].Cell(1, 4).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    doc.Tables[2].Cell(1, 5).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    if (!st_layout.ToUpper().Equals("R"))
                    {
                        doc.Tables[2].Cell(1, 6).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        doc.Tables[2].Cell(1, 7).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    }
                    doc.Tables[2].Cell(1, 1).Range.Font.Bold = 1;
                    doc.Tables[2].Cell(1, 1).Range.Font.Name = "Arial Narrow"; 
                    doc.Tables[2].Cell(1, 2).Range.Font.Bold = 1;
                    doc.Tables[2].Cell(1, 2).Range.Font.Name = "Arial Narrow"; 
                    doc.Tables[2].Cell(1, 3).Range.Font.Bold = 1;
                    doc.Tables[2].Cell(1, 3).Range.Font.Name = "Arial Narrow"; 
                    doc.Tables[2].Cell(1, 4).Range.Font.Bold = 1;
                    doc.Tables[2].Cell(1, 4).Range.Font.Name = "Arial Narrow"; 
                    doc.Tables[2].Cell(1, 5).Range.Font.Bold = 1;
                    doc.Tables[2].Cell(1, 5).Range.Font.Name = "Arial Narrow";
                    if (!st_layout.ToUpper().Equals("R"))
                    {
                        doc.Tables[2].Cell(1, 6).Range.Font.Bold = 1;
                        doc.Tables[2].Cell(1, 6).Range.Font.Name = "Arial Narrow";
                        doc.Tables[2].Cell(1, 7).Range.Font.Bold = 1;
                        doc.Tables[2].Cell(1, 7).Range.Font.Name = "Arial Narrow";
                    }
                    doc.Tables[2].Cell(1, 1).Range.Font.Size = 10;
                    doc.Tables[2].Cell(1, 2).Range.Font.Size = 10;
                    doc.Tables[2].Cell(1, 2).Range.Font.Size = 10;
                    doc.Tables[2].Cell(1, 3).Range.Font.Size = 10;
                    doc.Tables[2].Cell(1, 4).Range.Font.Size = 10;
                    doc.Tables[2].Cell(1, 5).Range.Font.Size = 10;
                    if (!st_layout.ToUpper().Equals("R"))
                    {
                        doc.Tables[2].Cell(1, 6).Range.Font.Size = 10;
                        doc.Tables[2].Cell(1, 7).Range.Font.Size = 10;
                    }
                    if (!st_layout.ToUpper().Equals("R"))
                    {
                        doc.Tables[2].Cell(1, 1).Range.Text = "NCM";
                        doc.Tables[2].Cell(1, 2).Range.Text = "Qtde.";
                        doc.Tables[2].Cell(1, 3).Range.Text = "UN";
                        doc.Tables[2].Cell(1, 4).Range.Text = "Produto";
                        doc.Tables[2].Cell(1, 5).Range.Text = "Vl.Unit.";
                        doc.Tables[2].Cell(1, 6).Range.Text = "SubTotal";
                        doc.Tables[2].Cell(1, 7).Range.Text = "Tot.Líquido";
                    }
                    else
                    {
                        doc.Tables[2].Cell(1, 1).Range.Text = "NCM";
                        doc.Tables[2].Cell(1, 2).Range.Text = "UN";
                        doc.Tables[2].Cell(1, 3).Range.Text = "Produto";
                        doc.Tables[2].Cell(1, 4).Range.Text = "SubTotal";
                        doc.Tables[2].Cell(1, 5).Range.Text = "Tot.Líquido";
                    }
                    //Preencher Informações dos Itens

                    decimal subtotal = decimal.Zero;
                    for (int i = 0; lista.Count > i; i++)
                    {
                        doc.Tables[2].Cell(i + 2, 1).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        doc.Tables[2].Cell(i + 2, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        doc.Tables[2].Cell(i + 2, 3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        doc.Tables[2].Cell(i + 2, 4).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        doc.Tables[2].Cell(i + 2, 5).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        if (!st_layout.ToUpper().Equals("R"))
                        {
                            doc.Tables[2].Cell(i + 2, 6).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            doc.Tables[2].Cell(i + 2, 7).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        }
                        doc.Tables[2].Cell(i + 2, 1).Range.Font.Name = "Arial Narrow";
                        doc.Tables[2].Cell(i + 2, 2).Range.Font.Name = "Arial Narrow";
                        doc.Tables[2].Cell(i + 2, 3).Range.Font.Name = "Arial Narrow";
                        doc.Tables[2].Cell(i + 2, 4).Range.Font.Name = "Arial Narrow";
                        doc.Tables[2].Cell(i + 2, 5).Range.Font.Name = "Arial Narrow";
                        if (!st_layout.ToUpper().Equals("R"))
                        {
                            doc.Tables[2].Cell(i + 2, 6).Range.Font.Name = "Arial Narrow";
                            doc.Tables[2].Cell(i + 2, 7).Range.Font.Name = "Arial Narrow";
                        }
                        doc.Tables[2].Cell(i + 2, 1).Range.Font.Size = 10;
                        doc.Tables[2].Cell(i + 2, 2).Range.Font.Size = 10;
                        doc.Tables[2].Cell(i + 2, 3).Range.Font.Size = 10;
                        doc.Tables[2].Cell(i + 2, 4).Range.Font.Size = 10;
                        doc.Tables[2].Cell(i + 2, 5).Range.Font.Size = 10;
                        if (!st_layout.ToUpper().Equals("R"))
                        {
                            doc.Tables[2].Cell(i + 2, 6).Range.Font.Size = 10;
                            doc.Tables[2].Cell(i + 2, 7).Range.Font.Size = 10;
                        }
                        if (!st_layout.ToUpper().Equals("R"))
                        {
                            doc.Tables[2].Cell(i + 2, 1).Range.Text = lista[i].NCM;
                            doc.Tables[2].Cell(i + 2, 2).Range.Text = lista[i].Quantidade.ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
                            doc.Tables[2].Cell(i + 2, 3).Range.Text = lista[i].Sigla_unid_produto;
                            doc.Tables[2].Cell(i + 2, 4).Range.Text = lista[i].Ds_produto.Trim() + "\r\n Obs: " + lItem[i].Ds_projespecial;
                            doc.Tables[2].Cell(i + 2, 5).Range.Text = (lista[i].Vl_subtotalliq / lista[i].Quantidade).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                            doc.Tables[2].Cell(i + 2, 6).Range.Text = lista[i].Vl_subtotalliq.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                            doc.Tables[2].Cell(i + 2, 7).Range.Text = lista[i].Vl_subtotalliq.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                        }
                        else
                        {
                            doc.Tables[2].Cell(i + 2, 1).Range.Text = lista[i].NCM;
                            doc.Tables[2].Cell(i + 2, 2).Range.Text = lista[i].Sigla_unid_produto;
                            doc.Tables[2].Cell(i + 2, 3).Range.Text = lista[i].Ds_produto.Trim() + "\r\n Obs: " + lItem[i].Ds_projespecial;
                            doc.Tables[2].Cell(i + 2, 4).Range.Text = lista[i].Vl_subtotalliq.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                            doc.Tables[2].Cell(i + 2, 5).Range.Text = lista[i].Vl_subtotalliq.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                        }
                        subtotal += lista[i].Vl_subtotalliq;
                    }
                    //Parcela
                    for (int i = 0; lParcelas.Count > i; i++)
                    {
                        object row = doc.Application.ActiveDocument.Tables[3].Rows[1];
                        doc.Application.ActiveDocument.Tables[3].Rows.Add(ref row);
                    }
                    doc.Tables[3].Cell(1, 1).Range.Font.Name = "Arial Narrow";
                    doc.Tables[3].Cell(1, 2).Range.Font.Name = "Arial Narrow";
                    doc.Tables[3].Cell(1, 1).Range.Font.Bold = 1;
                    doc.Tables[3].Cell(1, 2).Range.Font.Bold = 1;
                    doc.Tables[3].Cell(1, 1).Range.Font.Size = 10;
                    doc.Tables[3].Cell(1, 2).Range.Font.Size = 10;
                    doc.Tables[3].Cell(1, 1).Range.Text = "Vl. Parcela";
                    doc.Tables[3].Cell(1, 2).Range.Text = "Dt. Parcela";
                    //Preencher Informações das Parcelas
                    for (int i = 0; lParcelas.Count > i; i++)
                    {
                        doc.Tables[3].Cell(i + 2, 1).Range.Font.Size = 10;
                        doc.Tables[3].Cell(i + 2, 2).Range.Font.Size = 10;
                        doc.Tables[3].Cell(i + 2, 1).Range.Text = lParcelas[i].Vl_parcela.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                        doc.Tables[3].Cell(i + 2, 2).Range.Text = lParcelas[i].Dt_vencto.ToString("dd/MM/yyyy");
                    }
            /*
            * Codigo comentado conforme solicitação do Kleber <Ticket Nº5796>
            * 
            if (st_layout.ToUpper().Equals("A"))
            {
                //fichatec
                for (int i = 0; lista.Count > i; i++)
                {
                    object row = doc.Application.ActiveDocument.Tables[5].Rows[1];
                    doc.Application.ActiveDocument.Tables[5].Rows.Add(ref row);
                }

                doc.Tables[5].Cell(1, 1).Range.Font.Name = "Arial Narrow";
                doc.Tables[5].Cell(1, 1).Range.Font.Bold = 1;
                doc.Tables[5].Cell(1, 1).Range.Font.Size = 12;
                doc.Tables[5].Cell(1, 1).Range.Text = "Caracteristicas Técnicas dos Produtos";
                //Preencher Informações dos Itens
                for (int i = 0; lista.Count > i; i++)
                {
                    doc.Tables[5].Cell(i + 2, 1).Range.Font.Name = "Arial Narrow";;
                    doc.Tables[5].Cell(i + 2, 1).Range.Font.Size = 10;
                    doc.Tables[5].Cell(i + 2, 1).Range.Text = lista[i].Ds_produto + "\n" + lista[i].DS_TecnicaAssistencia;
                }      
            }
            */
            #region foreach
                foreach (Microsoft.Office.Interop.Word.Field field in doc.Fields)
                {
                    if (field.Code.Text.Contains("dataembarque"))
                    {
                        field.Select();
                        aplication.Selection.Font.Size = 10;
                        aplication.Selection.TypeText((rOrcamento.Dt_orcamento.Value.AddDays(Convert.ToDouble(rOrcamento.PrazoEntrega))).ToString("dd/MM/yyyy"));
                    }
                    else
                    if (field.Code.Text.Contains("datahora"))
                        {
                            field.Select();
                            aplication.Selection.Font.Size = 10;
                            aplication.Selection.TypeText(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        } else 
                        if (field.Code.Text.Contains("subtotal"))
                        {
                            field.Select();
                            aplication.Selection.Font.Size = 10;
                            aplication.Selection.TypeText(string.IsNullOrEmpty(subtotal.ToString()) ? "0,00" : "R$ " + subtotal.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                        }
                        else if (field.Code.Text.Contains("nr_orcamento") || field.Code.Text.Contains("nr_orcamento2"))
                        {
                            field.Select();
                            aplication.Selection.Font.Size = 10;
                            aplication.Selection.TypeText(string.IsNullOrEmpty(rOrcamento.Nr_orcamentostr) ? " " : "N°Pedido:" + rOrcamento.Nr_orcamentostr);
                        }
                        else if (field.Code.Text.Contains("nm_cliente") || field.Code.Text.Contains("nm_cliente2"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(rOrcamento.Nm_clifor);
                        }
                        //Endereco entrega
                        else if (field.Code.Text.Contains("Logradouroent"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(!string.IsNullOrEmpty(rOrcamento.Logradouroent) ? rOrcamento.Logradouroent : " ");
                        }
                        else if (field.Code.Text.Contains("Numeroent"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(!string.IsNullOrEmpty(rOrcamento.Numeroent) ? rOrcamento.Numeroent : " ");
                        }
                        else if (field.Code.Text.Contains("Bairroent"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(!string.IsNullOrEmpty(rOrcamento.Bairroent) ? rOrcamento.Bairroent : " ");
                        }
                        else if (field.Code.Text.Contains("Complementoent"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(!string.IsNullOrEmpty(rOrcamento.Complementoent) ? rOrcamento.Complementoent : " ");
                        }
                        else if (field.Code.Text.Contains("Cd_cidadeent"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(!string.IsNullOrEmpty(rOrcamento.Cd_cidadeent) ? rOrcamento.Cd_cidadeent : " ");
                        }
                        else if (field.Code.Text.Contains("Ds_cidadeent"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(!string.IsNullOrEmpty(rOrcamento.Ds_cidadeent) ? rOrcamento.Ds_cidadeent : " ");
                        }
                        else if (field.Code.Text.Contains("Uf_ent"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(!string.IsNullOrEmpty(rOrcamento.Uf_ent) ? rOrcamento.Uf_ent : " ");
                        }
                        else if (field.Code.Text.Contains("cpf_cnpj"))
                        {
                            field.Select();
                            if (string.IsNullOrEmpty(rOrcamento.Cd_clifor))
                                aplication.Selection.TypeText(" ");
                            else if (!string.IsNullOrEmpty(rClifor.Nr_cgc))
                                aplication.Selection.TypeText(rClifor.Nr_cgc);
                            else if (!string.IsNullOrEmpty(rClifor.Nr_cpf))
                                aplication.Selection.TypeText(rClifor.Nr_cpf);
                            else
                                aplication.Selection.TypeText("          ");
                        }
                        else if (field.Code.Text.Contains("uf"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(rOrcamento.Uf);
                        }
                        else if (field.Code.Text.Contains("Pc_Icms_UF"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(!string.IsNullOrEmpty(rOrcamento.Ds_tabelapreco) ? rOrcamento.Ds_tabelapreco.Trim() : " ");
                        }
                        else if (field.Code.Text.Contains("cidade"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(rOrcamento.Ds_cidade);
                        }
                        else if (field.Code.Text.Contains("endereco"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(!string.IsNullOrEmpty(rOrcamento.Ds_endereco) ? rOrcamento.Ds_endereco : " ");
                        }
                        else if (field.Code.Text.Contains("representante"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(!string.IsNullOrEmpty(rOrcamento.Nm_representante) ? rOrcamento.Nm_representante : "   ");
                        }
                        else if (field.Code.Text.Contains("fone_comercial"))
                        {
                            field.Select();
                            aplication.Selection.Font.Size = 10;
                            if (rEndereco != null)
                                aplication.Selection.TypeText(!string.IsNullOrEmpty(rEndereco.Fone_comercial) ? rEndereco.Fone_comercial : " ");
                            else
                                aplication.Selection.TypeText(rOrcamento.Fone_clifor);
                        }
                        else if (field.Code.Text.Contains("fonecel"))
                        {
                            field.Select();
                            aplication.Selection.Font.Size = 10;
                            if (rEndereco != null)
                                aplication.Selection.TypeText(!string.IsNullOrEmpty(rEndereco.Celular) ? rEndereco.Celular : " ");
                            else
                                aplication.Selection.TypeText(" ");
                        }
                        else if (field.Code.Text.Contains("cep"))
                        {
                            field.Select();
                            if (rEndereco != null)
                                aplication.Selection.TypeText(rEndereco.Cep);
                            else
                                aplication.Selection.TypeText(" ");
                        }
                        else if (field.Code.Text.Contains("bairro"))
                        {
                            field.Select();
                            if (rEndereco != null)
                                aplication.Selection.TypeText(rEndereco.Bairro);
                            else
                                aplication.Selection.TypeText(" ");
                        }
                        else if (field.Code.Text.Contains("ie"))
                        {
                            field.Select();
                            if (rEndereco != null)
                                aplication.Selection.TypeText(string.IsNullOrEmpty(rEndereco.Insc_estadual) ? " " : rEndereco.Insc_estadual);
                            else
                                aplication.Selection.TypeText(" ");
                        }
                        else if (field.Code.Text.Contains("condicao_pgto"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(string.IsNullOrEmpty(rOrcamento.Ds_condpgto) ? " " : rOrcamento.Ds_condpgto);
                        }
                        else if (field.Code.Text.Contains("dt_embarque"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(rOrcamento.Dt_orcamento.Value.AddDays(double.Parse(rOrcamento.PrazoEntrega.ToString())).ToString("dd/MM/yyyy"));
                        }
                        else if (field.Code.Text.Contains("tp_descarga"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(string.IsNullOrEmpty(rOrcamento.TP_descarga) ? "NÃO INCLUSO" : 
                                rOrcamento.TP_descarga.ToUpper().Equals("P") ? "INCLUSO" : "NÃO INCLUSO");
                        }
                        else if (field.Code.Text.Contains("tp_frete"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(rOrcamento.Tp_frete.ToUpper().Equals("0") ? "INCLUSO" : "NÃO INCLUSO");
                        }
                        else if (field.Code.Text.Contains("valor_frete"))
                        {
                            field.Select();
                            aplication.Selection.TypeText(rOrcamento.Vl_frete.ToString());
                        }
                        else if (field.Code.Text.Contains("nome_contato"))
                        {
                            field.Select();
                            if (lContatoClifor != null)
                                if (lContatoClifor.Count > 0)
                                    aplication.Selection.TypeText(string.IsNullOrEmpty(lContatoClifor[0].Nm_Contato) ? (" ") : (lContatoClifor[0].Nm_Contato));
                                else 
                                    aplication.Selection.TypeText(" ");
                            else
                                aplication.Selection.TypeText(" ");
                        }
                        else if (field.Code.Text.Contains("email_contato"))
                        {
                            field.Select();
                            if (lContatoClifor != null)
                            {
                                if (lContatoClifor.Count > 0)
                                {
                                    aplication.Selection.Font.Size = 10;
                                    aplication.Selection.TypeText(string.IsNullOrEmpty(lContatoClifor[0].Email) ? (" ") : (lContatoClifor[0].Email));
                                }
                                else
                                    aplication.Selection.TypeText(" ");
                            }
                            else
                                aplication.Selection.TypeText(" ");
                        }
                        else if (field.Code.Text.Contains("fone_contato"))
                        {
                            field.Select();
                            if (lContatoClifor != null)
                            {
                                if (lContatoClifor.Count > 0)
                                {
                                    aplication.Selection.Font.Size = 10;
                                    aplication.Selection.TypeText(string.IsNullOrEmpty(lContatoClifor[0].Fone) ? (" ") : (lContatoClifor[0].Fone));
                                }
                                else
                                    aplication.Selection.TypeText(" ");
                            }
                            else
                                aplication.Selection.TypeText(" ");
                        }
                        else if (field.Code.Text.Contains("email"))
                        {
                            field.Select();
                            aplication.Selection.Font.Size = 10;
                            if (rClifor != null)
                                aplication.Selection.TypeText(string.IsNullOrEmpty(rClifor.Email) ? " " : rClifor.Email);
                            else
                                aplication.Selection.TypeText(" ");
                        }
                        else if (field.Code.Text.Contains("dt_orcamento"))
                        {
                            field.Select();
                            aplication.Selection.Font.Bold = 1;
                            aplication.Selection.TypeText(string.IsNullOrEmpty(rOrcamento.Dt_orcamentostr) ? CamadaDados.UtilData.Data_Servidor().ToLongDateString() : rOrcamento.Dt_orcamento.Value.ToLongDateString());
                        }
                    }
                    #endregion
                    aplication.Visible = false;
                    doc.Activate();
                    FileInfo wordFile = new FileInfo(Template.ToString());
                    object outputFileName = null;
                    object fileFormat = null;
                    if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR WORD", null))
                    {               
                        using (TFWordPDF fTela = new TFWordPDF())
                        {
                            if (fTela.ShowDialog() == DialogResult.OK)
                                if (fTela.St_pdf)
                                {
                                    outputFileName = wordFile.FullName.Replace(".docx", ".pdf");
                                    fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
                                }
                                else
                                {
                                    outputFileName = wordFile.FullName;
                                    fileFormat = System.Reflection.Missing.Value;
                                }
                        }
                    }
                    else
                    {
                        outputFileName = wordFile.FullName.Replace(".docx", ".pdf");
                        fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
                    }
                    //Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
                    doc.SaveAs(ref outputFileName, ref fileFormat, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                    System.Diagnostics.Process.Start(outputFileName.ToString());
                    espera.Fechar();
                    espera = null;
                    doc = null;
                    //Retirando Word da memória
                    aplication.Quit(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(aplication);
                    aplication = null;
                    GC.Collect();
        }	

        private void TFPrintOrcamentoWord_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsItens.DataSource = lItem;
        }

        private void JaquetadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rCFG.LayoutJaquetado.ToString()))
            {
                MessageBox.Show("Obrigatório configurar layout jaquetado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                this.GerarPrint("J");
        }

        private void AereoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rCFG.LayoutAereo.ToString()))
            {
                MessageBox.Show("Obrigatório configurar layout aéreo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.GerarPrint("A");
        }

        private void periféricosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rCFG.LayoutPerifericos.ToString()))
            {
                MessageBox.Show("Obrigatório configurar layout periféricos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.GerarPrint("P");
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).St_processar =
                    !(bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).St_processar;
                bsItens.ResetCurrentItem();
            }
        }

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                (bsItens.DataSource as CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item).ForEach(p => p.St_processar = cbTodos.Checked);
                bsItens.ResetBindings(true);
            }
        }

        private void flexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rCFG.LayoutPerifericos.ToString()))
            {
                MessageBox.Show("Obrigatório configurar layout flex!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.GerarPrint("F");
        }

        private void aguaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rCFG.LayoutPerifericos.ToString()))
            {
                MessageBox.Show("Obrigatório configurar layout agua!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.GerarPrint("G");
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (string.IsNullOrEmpty(rCFG.LayoutPerifericos.ToString()))
            {
                MessageBox.Show("Obrigatório configurar layout Vertical!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.GerarPrint("V");
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rCFG.LayoutJaquetado.ToString()))
            {
                MessageBox.Show("Obrigatório configurar layout jaquetado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.GerarPrint("J");
        }

        private void resumidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rCFG.LayoutJaquetadoRes.ToString()))
            {
                MessageBox.Show("Obrigatório configurar layout jaquetado resumido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.GerarPrint("R");
        }
    }
}
