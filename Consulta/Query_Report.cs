using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using Utils;
using FormRelPadrao;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using System.Collections;
using System.Windows.Forms;
using Componentes;
using FormBusca;
using System.Reflection;
using CamadaDados.Diversos;
using System.ComponentModel;
using System.IO;
using CamadaNegocio.ConfigGer;

namespace Consulta
{
    public class Query_Report
    {
        private struct param
        {
            public string nmparam;
            public string vlparam;
            public string st_null;
        }

        public bool vEditor = false;
        public bool vBIntelligence = false;
        public string vURLWebService = string.Empty;
        public string vSistema = "AL";
        private FRelPadrao formRelPadrao = null;
        private Relatorio Relatorio = new Relatorio();
        public bool Homologacao = false;
        private bool Altera_Relatorio = false;
        private DefaultData_Consulta DefaultData = new DefaultData_Consulta();
        private int totalParametro = 0;
        private int tabIndex = 0;
        private ComponentResourceManager resources = new ComponentResourceManager(typeof(FRelPadrao));
        public TRegistro_Cad_Report Cad_Report;
        public TList_Cad_Consulta ListConsulta = new TList_Cad_Consulta();
        public TList_Cad_ParamClasse listaParamClasse = new TList_Cad_ParamClasse();

        public void MontaFormRelatorio(TRegistro_Cad_Report Cad_ReportParam, Form formPaiMDI)
        {
            //CRIA AS PRINCIPAIS INSTANCIA PARA MONTAR O FORM DO RELATORIO
            formRelPadrao = new FRelPadrao();
            formRelPadrao.Text = Cad_ReportParam.DS_Report;
            Cad_Report = Cad_ReportParam;
            totalParametro = 0;
            int totalGroup = 0;
            bool formatZero = true;

            //CRIA O GROUPBOX DAS PROPRIEDADES Q SERÃO USADAS
            GroupBox groupBox = new GroupBox();
            groupBox.Text = Cad_Report.DS_Report;
            groupBox.Dock = DockStyle.Fill;

            //INSTANCIA OS COMP DO TABLELAYOUT
            TableLayoutPanel Table_Layout = null;

            if (vBIntelligence)
            {
                Type t = Application.OpenForms["TFBInteligence"].GetType();
                t.GetMethod("DefineDadosConexao").Invoke(Application.OpenForms["TFBInteligence"], new object[] { "C" });
            }

            for (int w = 0; w < Cad_ReportParam.lConsulta.Count; w++)
            {
                TRegistro_Cad_Consulta Cad_Consulta = Cad_ReportParam.lConsulta[w];

                //BUSCO OS DADOS DA CONSULTA PARA VER SE NECESSITA PARAMETROS
                if (Cad_Consulta.DS_SQL.Trim() == "")
                {
                    TList_Cad_Filtro listaFiltro = TCN_Cad_Filtro.Busca(0, Cad_Consulta.ID_Consulta, "");

                    for (int i = 0; i < listaFiltro.Count; i++)
                    {
                        TList_Cad_ParamClasse listaParam = TCN_Cad_ParamClasse.Buscar(listaFiltro[i].ID_ParamClasse, "", "", "", 0, null);

                        for (int x = 0; x < listaParam.Count; x++)
                        {
                            if (Table_Layout == null)
                                Table_Layout = new TableLayoutPanel();

                            if (!VerificaParamClasse((listaParam[x] as TRegistro_Cad_ParamClasse).NM_CampoFormat))
                            {
                                Table_Layout = AdicionaCampoBusca(listaParam[x] as TRegistro_Cad_ParamClasse, Table_Layout, x);
                                listaParamClasse.Add(listaParam[x] as TRegistro_Cad_ParamClasse);
                            }
                        }
                    }
                }
                else
                {
                    TList_Cad_ParamClasse lParamRetorno = TCN_Cad_ParamClasse.BuscaParamClasseSQLString(Cad_Consulta.DS_SQL);

                    foreach (TRegistro_Cad_ParamClasse reg_param in lParamRetorno)
                    {
                        if (Table_Layout == null)
                            Table_Layout = new TableLayoutPanel();

                        //ADICIONA O COMPONENTE PARA O RESULTADO
                        if (!listaParamClasse.Exists(p => p.NM_CampoFormat == reg_param.NM_CampoFormat))
                        {
                            Table_Layout = AdicionaCampoBusca(reg_param, Table_Layout, totalParametro);
                            listaParamClasse.Add(reg_param);
                        }
                    }
                }

                //ADICIONAR OS COMPONENTES NO FORM PADRÃO DE RELATÒRIO
                

                if (Table_Layout != null)
                {
                    //ADICIONA AO FORM
                    Table_Layout.Margin = new Padding(0, 0, 0, 0);
                    Table_Layout.Dock = DockStyle.Fill;
                    Table_Layout.AutoSize = false;
                    groupBox.Controls.Add(Table_Layout);
                    totalGroup++;
                }

                ListConsulta.Add(Cad_Consulta);
            }

            if (groupBox.Controls.Count == 0)
            {
                Label labelInf = new Label();
                labelInf.Text = "Atenção, não há nenhum filtro no relatório!";
                labelInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelInf.AutoSize = true;
                labelInf.Location = new System.Drawing.Point(10, 15);
                groupBox.Controls.Add(labelInf);
                totalGroup = 2;
                formatZero = false;
            }

            //EVENTOS DOS BOTOES
            formRelPadrao.BB_Imprimir.Click += new EventHandler(BB_RelatorioClick);
            formRelPadrao.BB_Publicar.Click += new EventHandler(BB_PublicarClick);
            formRelPadrao.BB_DataCube.Click += new EventHandler(BB_RelatorioClick);
            formRelPadrao.BB_Chart.Click += new EventHandler(BB_RelatorioClick);
            formRelPadrao.BB_Atualizar.Click += new EventHandler(BB_AtualizarClick);

            //ADD O GROUPBOX DOS FILTROS NO FORM
            formRelPadrao.pFiltro.Controls.Add(groupBox);


            if (vBIntelligence)
            {
                Type t = Application.OpenForms["TFBInteligence"].GetType();
                t.GetMethod("DefineDadosConexao").Invoke(Application.OpenForms["TFBInteligence"], new object[] { "N" });
            }

            if (formatZero)
                formRelPadrao.pFiltro.set_FormatZero();
            formRelPadrao.AutoSize = false;

            if (vBIntelligence)
            {
                Type t = Application.OpenForms["TFBInteligence"].GetType();
                t.GetMethod("DefineDadosConexao").Invoke(Application.OpenForms["TFBInteligence"], new object[] { "C" });
            }

            if (!vEditor && !vBIntelligence)
            {
                //VERIFICA QUAIS BOTÕES FICARAM HABILITADOS
                if ((!Homologacao) && CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR PUBLICAR RELATÓRIO", null))
                    formRelPadrao.BB_Publicar.Visible = true;
                
                if (Cad_Report.Code_Report != null)
                    formRelPadrao.BB_Imprimir.Visible = true;
                if (Cad_Report.Code_DataCube != null)
                    formRelPadrao.BB_DataCube.Visible = true;
                if (Cad_Report.Code_Chart != null)
                    formRelPadrao.BB_Chart.Visible = true;
                if ((Cad_Report.ID_RDC.Trim() != "") && (!Homologacao))
                    formRelPadrao.BB_Atualizar.Visible = true;

            }
            else
            {
                formRelPadrao.BB_Imprimir.Visible = true;
                formRelPadrao.BB_DataCube.Visible = true;
                formRelPadrao.BB_Chart.Visible = true;

                if (vBIntelligence)
                {
                    if ((Utils.Parametros.pubLogin == "MASTER") || (Utils.Parametros.pubLogin == "DESENV"))
                        formRelPadrao.BB_Publicar.Visible = true;
                }
            }
            
            //CALCULA O TAMANHO DO FORM
            formRelPadrao.KeyDown += new KeyEventHandler(FRelPadrao_KeyDown);
            formRelPadrao.Size = new Size(650, (70 + (listaParamClasse.Count * 30) + (totalGroup * 22)));

            //DIZ Q O FORM É FILHO DO FORM PRINCIPAL
            if (formPaiMDI != null)
            {
                formRelPadrao.MdiParent = formPaiMDI;
                formRelPadrao.Show();
            }
            else
            {
                if (!Homologacao)
                {
                    formRelPadrao.MdiParent = Application.OpenForms["FMenuPrin"];
                    formRelPadrao.Show();
                }
                else
                {
                    formRelPadrao.WindowState = FormWindowState.Normal;
                    formRelPadrao.ShowDialog();
                }
            }

            if (vBIntelligence)
            {
                Type t = Application.OpenForms["TFBInteligence"].GetType();
                t.GetMethod("DefineDadosConexao").Invoke(Application.OpenForms["TFBInteligence"], new object[] { "N" });
            }
        }

        public TableLayoutPanel AdicionaCampoBusca(TRegistro_Cad_ParamClasse Cad_ParamClasse, TableLayoutPanel Table_Layout, int x)
        {
            Label labelParam = new Label();
            Table_Layout.AutoSize = false;

            if (Cad_ParamClasse.TP_Dado.Trim() != "RADIO")
            {
                // 
                // labelParam
                // 
                labelParam.AutoSize = true;
                labelParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelParam.Location = new System.Drawing.Point(10, ((x + 1) * 5));
                labelParam.Name = "labelParam." + Cad_ParamClasse.ID_ParamClasse;
                labelParam.Anchor = System.Windows.Forms.AnchorStyles.Right;
                if (Cad_ParamClasse.TP_Dado.Trim() != "CHECKBOX")
                    labelParam.Text = Cad_ParamClasse.NM_Param + ":";
            }

            if (Cad_ParamClasse.NM_Classe.Trim() != "")
            {
                EditDefault NM_Param = new EditDefault();
                Button BB_Param = new Button();
                EditDefault ID_Param = new EditDefault();

                // 
                // ID_Param
                // 
                ID_Param.BackColor = System.Drawing.SystemColors.Window;
                ID_Param.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                ID_Param.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ID_Param.Location = new System.Drawing.Point(105, ((x + 1) * 5));
                ID_Param.MaxLength = 4;
                ID_Param.Name = "ID_Param." + Cad_ParamClasse.ID_ParamClasse;

                if (Cad_ParamClasse.CodigoCMP.IndexOf(".") < 0)
                {
                    ID_Param.NM_Campo = Cad_ParamClasse.CodigoCMP;
                    ID_Param.NM_CampoBusca = Cad_ParamClasse.CodigoCMP;
                }
                else
                {
                    string[] CodigoCMP = Cad_ParamClasse.CodigoCMP.Split(new char[] { '.' });
                    ID_Param.NM_Alias = CodigoCMP[0];
                    ID_Param.NM_Campo = CodigoCMP[1];
                    ID_Param.NM_CampoBusca = CodigoCMP[1];
                }

                ID_Param.QTD_Zero = 0;
                if (Cad_ParamClasse.TP_Dado.Trim() == "LISTA")
                    ID_Param.Size = new System.Drawing.Size(200, 20);
                else
                    ID_Param.Size = new System.Drawing.Size(70, 20);
                ID_Param.ST_AutoInc = false;
                ID_Param.ST_DisableAuto = false;
                ID_Param.ST_Float = false;
                ID_Param.ST_Gravar = true;
                ID_Param.ST_Int = true;
                ID_Param.ST_LimpaCampo = true;
                ID_Param.ST_PrimaryKey = false;
                ID_Param.MaxLength = 20;
                ID_Param.TabIndex = tabIndex;
                tabIndex++;
                ID_Param.Tag = Cad_ParamClasse.NM_Classe;
                if (Cad_ParamClasse.St_Obrigatorio == "S")
                {
                    ID_Param.ST_Gravar = true;
                    ID_Param.ST_NotNull = true;
                }
                else
                {
                    ID_Param.ST_Gravar = false;
                    ID_Param.ST_NotNull = false;
                }

                ID_Param.AccessibleName = Cad_ParamClasse.St_Null;
                ID_Param.NM_Param = Cad_ParamClasse.NM_CampoFormat;
                if (Cad_ParamClasse.TP_Dado.Trim() != "LISTA")
                    ID_Param.Leave += new EventHandler(ID_Param_Leave);

                //ADICIONA O VALOR DEFAUT
                ID_Param.Text = DefaultData.LerDefaultData(Cad_ParamClasse.NM_CampoFormat + Cad_Report.ID_Report);

                // 
                // BB_Param
                // 
                BB_Param.Image = ((System.Drawing.Image)(resources.GetObject("BB_Menu.Image")));
                BB_Param.Location = new System.Drawing.Point(180, ((x + 1) * 5));
                BB_Param.Name = "BB_Param." + Cad_ParamClasse.ID_ParamClasse;
                BB_Param.AutoSize = false;
                BB_Param.Size = new System.Drawing.Size(30, 20);
                BB_Param.TabIndex = tabIndex;
                BB_Param.UseVisualStyleBackColor = true;
                BB_Param.Tag = Cad_ParamClasse.CondicaoBusca;
                BB_Param.AccessibleName = Cad_ParamClasse.TP_Dado;
                BB_Param.Click += new System.EventHandler(BB_Param_Click);
                tabIndex++;

                // 
                // NM_Param
                // 
                NM_Param.BackColor = System.Drawing.SystemColors.Window;
                NM_Param.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                NM_Param.Enabled = false;
                NM_Param.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NM_Param.Location = new System.Drawing.Point(215, ((x + 1) * 5));
                NM_Param.Name = "NM_Param." + Cad_ParamClasse.ID_ParamClasse;

                if (Cad_ParamClasse.CodigoCMP.IndexOf(".") < 0)
                {
                    NM_Param.NM_Campo = Cad_ParamClasse.NomeCMP;
                    NM_Param.NM_CampoBusca = Cad_ParamClasse.NomeCMP;
                }
                else
                {
                    string[] NomeCMP = Cad_ParamClasse.NomeCMP.Split(new char[] { '.' });
                    NM_Param.NM_Alias = NomeCMP[0];
                    NM_Param.NM_Campo = NomeCMP[1];
                    NM_Param.NM_CampoBusca = NomeCMP[1];
                }

                NM_Param.NM_Param = Cad_ParamClasse.NM_DLL;
                NM_Param.QTD_Zero = 0;
                NM_Param.Size = new System.Drawing.Size(280, 20);
                NM_Param.ST_AutoInc = false;
                NM_Param.ST_DisableAuto = true;
                NM_Param.ST_Float = false;
                NM_Param.ST_Gravar = false;
                NM_Param.ST_Int = false;
                NM_Param.ST_LimpaCampo = true;
                NM_Param.ST_Gravar = false;
                NM_Param.ST_PrimaryKey = false;
                NM_Param.TabIndex = tabIndex;

                tabIndex++;

                if (Cad_ParamClasse.TP_Dado.Trim() == "LISTA")
                {
                    ID_Param.ReadOnly = true;
                    NM_Param.Visible = false;
                }
                //ADD
                Table_Layout = GerenciaTabelaLayout(Table_Layout, labelParam, new Control[] { ID_Param, BB_Param, NM_Param }, 23, false);
            }
            else if (Cad_ParamClasse.TP_Dado.Trim() == "STRING" ||
                     Cad_ParamClasse.TP_Dado.Trim() == "FLOAT" ||
                     Cad_ParamClasse.TP_Dado.Trim() == "INTEIRO")
            {
                //ADICIONA UMA STRING NORMAL
                EditDefault NM_Param = new EditDefault();

                // 
                // NM_Param
                // 
                NM_Param.BackColor = System.Drawing.SystemColors.Window;
                NM_Param.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                NM_Param.Enabled = true;
                NM_Param.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NM_Param.Location = new System.Drawing.Point(105, ((x + 1) * 5));
                NM_Param.Name = "NM_Param." + Cad_ParamClasse.ID_ParamClasse;
                NM_Param.NM_Param = Cad_ParamClasse.TP_Dado;
                NM_Param.QTD_Zero = 0;
                NM_Param.ST_AutoInc = false;
                NM_Param.ST_DisableAuto = true;
                if (Cad_ParamClasse.TP_Dado.Trim() == "STRING")
                {
                    NM_Param.ST_Float = false;
                    NM_Param.ST_Int = false;
                    NM_Param.Size = new System.Drawing.Size(392, 20);
                }
                else if (Cad_ParamClasse.TP_Dado.Trim() == "INTEIRO")
                {
                    NM_Param.ST_Float = false;
                    NM_Param.ST_Int = true;
                    NM_Param.Size = new System.Drawing.Size(280, 20);
                }
                else if (Cad_ParamClasse.TP_Dado.Trim() == "FLOAT")
                {
                    NM_Param.ST_Float = true;
                    NM_Param.ST_Int = false;
                    NM_Param.Size = new System.Drawing.Size(280, 20);
                }
                NM_Param.ST_Gravar = false;
                NM_Param.ST_LimpaCampo = true;
                if (Cad_ParamClasse.St_Obrigatorio == "S")
                {
                    NM_Param.ST_Gravar = true;
                    NM_Param.ST_NotNull = true;
                }
                else
                {
                    NM_Param.ST_Gravar = false;
                    NM_Param.ST_NotNull = false;
                }
                NM_Param.AccessibleName = Cad_ParamClasse.St_Null;
                NM_Param.ST_PrimaryKey = false;
                NM_Param.TabIndex = tabIndex;
                //ADICIONA O VALOR DEFAUT
                NM_Param.Text = DefaultData.LerDefaultData(Cad_ParamClasse.NM_CampoFormat + Cad_Report.ID_Report);
                tabIndex++;

                Table_Layout = GerenciaTabelaLayout(Table_Layout, labelParam, new Control[] { NM_Param }, 23, false);
            }
            else if (Cad_ParamClasse.TP_Dado.Trim() == "DATA" ||
                     Cad_ParamClasse.TP_Dado.Trim() == "DATAHORA" ||
                     Cad_ParamClasse.TP_Dado.Trim() == "HORA" ||
                     Cad_ParamClasse.TP_Dado.Trim() == "ANO")
            {
                //ADICIONA UMA STRING NORMAL
                EditMask NM_Param = new EditMask();

                // 
                // NM_Param
                // 
                NM_Param.Location = new System.Drawing.Point(105, ((x + 1) * 5));
                if (Cad_ParamClasse.TP_Dado.Trim() == "DATA")
                {
                    NM_Param.Mask = "00/00/0000";
                }
                else if (Cad_ParamClasse.TP_Dado.Trim() == "DATAHORA")
                {
                    NM_Param.Mask = "00/00/0000 90:00";
                }
                else if (Cad_ParamClasse.TP_Dado.Trim() == "HORA")
                {
                    NM_Param.Mask = "90:00";
                }
                else if (Cad_ParamClasse.TP_Dado.Trim() == "ANO")
                {
                    NM_Param.Mask = "0000";
                }
                NM_Param.Name = "NM_Param." + Cad_ParamClasse.ID_ParamClasse;
                NM_Param.NM_Param = Cad_ParamClasse.TP_Dado;
                NM_Param.Size = new System.Drawing.Size(120, 20);
                NM_Param.ST_Gravar = false;
                NM_Param.ST_LimpaCampo = true;
                if (Cad_ParamClasse.St_Obrigatorio == "S")
                {
                    NM_Param.ST_Gravar = true;
                    NM_Param.ST_NotNull = true;
                }
                else
                {
                    NM_Param.ST_Gravar = false;
                    NM_Param.ST_NotNull = false;
                }
                NM_Param.AccessibleName = Cad_ParamClasse.St_Null;
                NM_Param.ST_PrimaryKey = false;
                NM_Param.TabIndex = tabIndex;
                //ADICIONA O VALOR DEFAUT
                NM_Param.Text = DefaultData.LerDefaultData(Cad_ParamClasse.NM_CampoFormat + Cad_Report.ID_Report);
                tabIndex++;
                NM_Param.ValidatingType = typeof(System.DateTime);

                Table_Layout = GerenciaTabelaLayout(Table_Layout, labelParam, new Control[] { NM_Param }, 23, false);
            }
            else if (Cad_ParamClasse.TP_Dado.Trim() == "RADIO")
            {
                RadioGroup radioGroup = new RadioGroup();
                int tamanhoTotal = 0;
                int QTDRadio = 0;

                radioGroup.Name = "NM_Param." + Cad_ParamClasse.ID_ParamClasse;
                radioGroup.AutoSize = false;
                radioGroup.ST_Gravar = false;
                radioGroup.TabStop = false;
                radioGroup.Text = Cad_ParamClasse.NM_Param;

                if (Cad_ParamClasse.RadioCheckGroup != "")
                {
                    string[] opcoesArray = Cad_ParamClasse.RadioCheckGroup.Split(new char[] { ';' });
                    
                    for (int i = 0; i < opcoesArray.Length; i++)
                    {
                        string[] opcoes = opcoesArray[i].Trim().Split(new char[] { ':' });

                        if (opcoes.Length == 2)
                        {
                            RadioButtonDefault radioButton = new RadioButtonDefault();

                            radioButton.AutoSize = true;
                            radioButton.Location = new System.Drawing.Point(10, ((i + 1) * 15));
                            radioButton.Name = "Radio_Param." + i;
                            radioButton.TabIndex = tabIndex;
                            tabIndex++;
                            radioButton.TabStop = true;
                            radioButton.Text = opcoes[1].Trim();
                            radioButton.UseVisualStyleBackColor = true;
                            radioButton.Valor = opcoes[0].Trim();
                            radioButton.AccessibleName = Cad_ParamClasse.St_Null;

                            if (i == 0)
                                radioButton.Checked = true;

                            if (tamanhoTotal < (opcoes[1].Trim().Length * 5))
                            {
                                tamanhoTotal = (opcoes[1].Trim().Length * 5);
                            }

                            radioGroup.Controls.Add(radioButton);
                            QTDRadio++;
                        }
                    }
                }

                if (radioGroup.Controls.Count > 0)
                {
                    radioGroup.Size = new Size(400, (QTDRadio * 25));

                    Table_Layout = GerenciaTabelaLayout(Table_Layout, labelParam, new Control[] { radioGroup }, (QTDRadio * 25), true);
                }
            }
            else if (Cad_ParamClasse.TP_Dado.Trim() == "CHECKBOX")
            {
                if (Cad_ParamClasse.RadioCheckGroup != "")
                {
                    CheckBoxDefault checkBox = new CheckBoxDefault();

                    checkBox.AutoSize = true;
                    checkBox.Location = new System.Drawing.Point(5, 5);
                    checkBox.Name = "NM_Param." + Cad_ParamClasse.ID_ParamClasse;
                    checkBox.Text = Cad_ParamClasse.NM_Param;
                    checkBox.UseVisualStyleBackColor = true;
                    checkBox.TabIndex = tabIndex;
                    tabIndex++;
                    checkBox.AccessibleName = Cad_ParamClasse.St_Null;

                    string[] opcoes = Cad_ParamClasse.RadioCheckGroup.Trim().Split(new char[] { ';' });
                    if (opcoes.Length > 1)
                    {
                        checkBox.Vl_True = opcoes[0].Trim();
                        checkBox.Vl_False = opcoes[1].Trim();
                    }
                    else
                    {
                        checkBox.Vl_True = Cad_ParamClasse.RadioCheckGroup;
                    }

                    Table_Layout = GerenciaTabelaLayout(Table_Layout, labelParam, new Control[] { checkBox }, 23, false);
                }
            }

            return Table_Layout;
        }

        public TableLayoutPanel GerenciaTabelaLayout(TableLayoutPanel Table_Layout, Label labelParam, Control[] compArray, int altura, bool radioGroup)
        {
            //ADICIONA A LINHA PARA A TABELA
            if (radioGroup)
            {
                if (altura > 450 && altura < 550)
                    Table_Layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
                else if (altura > 550 && altura < 650)
                    Table_Layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
                else if (altura > 650)
                    Table_Layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
                else
                    Table_Layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            }
            else
            {
                Table_Layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            }

            //CRIA A LINHA DO COMPONENTE DA VEZ PARA O LAYOUT
            TableLayoutPanel tableRow = new TableLayoutPanel();
            tableRow.RowStyles.Clear();
            tableRow.ColumnStyles.Clear();
            tableRow.AutoSize = false;
            tableRow.Size = new Size(tableRow.Bounds.Width, altura);
            tableRow.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableRow.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            
            //ADICIONA O LABEL PARA A PRIMEIRA COLUNA DA LINHA CORRENTE
            labelParam.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            labelParam.Margin = new Padding(0, 5, 2, 0);
            Table_Layout.Controls.Add(labelParam, 0, totalParametro);

            //ADICIONA OS COMPONENTE
            for (int i = 0; i < compArray.Length; i++)
            {
                tableRow.Controls.Add(compArray[i], i, 0);
            }

            //ADD AS ULTIMAS CONFIGURAÇÔES DO LAYOUT
            tableRow.Margin = new Padding(0, 0, 0, 0);
            tableRow.Dock = DockStyle.Fill;
            Table_Layout.Margin = new Padding(0, 0, 0, 0);
            Table_Layout.Controls.Add(tableRow, 1, totalParametro);
            totalParametro++;

            return Table_Layout;
        }

        private void BB_RelatorioClick(object sender, EventArgs e)
        {
            ToolStripButton BB_Imprimir = (sender as ToolStripButton);

            string TP_RDC = "R";
            if (vEditor && (Cad_Report.Code_Report == null))
                Relatorio.Cad_Report = Cad_Report;

            Imprimir(TP_RDC);
        }

        private void BB_AtualizarClick(object sender, EventArgs e)
        {
            try
            {
                AtualizarRDC.VerificarVersaoRDC(Cad_Report, true);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem");
            }
        }

        private void BB_PublicarClick(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja realmente publicar esta versão de relatório?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Cad_Report = TCN_Cad_Report.Buscar(Cad_Report.ID_Report, 
                                                       Cad_Report.DS_Report, 
                                                       string.Empty, 
                                                       string.Empty, 
                                                       string.Empty, 
                                                       0, 
                                                       string.Empty,
                                                       false, 
                                                       false, 
                                                       false)[0];
                    Cad_Report.lConsulta = ListConsulta;
                    Cad_Report.Versao ++;
                    CamadaDados.WS_RDC.TList_Cad_ParamClasse lParam = new CamadaDados.WS_RDC.TList_Cad_ParamClasse();
                    listaParamClasse.ForEach(p =>
                        lParam.Add(new CamadaDados.WS_RDC.TRegistro_Cad_ParamClasse
                        {
                            CodigoCMP = p.CodigoCMP,
                            CondicaoBusca = p.CondicaoBusca,
                            NM_CampoFormat = p.NM_CampoFormat,
                            NM_Classe = p.NM_Classe,
                            NM_DLL = p.NM_DLL,
                            NM_Param = p.NM_Param,
                            NomeCMP = p.NomeCMP,
                            RadioCheckGroup = p.RadioCheckGroup,
                            St_Null = p.St_Null,
                            St_Obrigatorio = p.St_Obrigatorio,
                            TP_Dado = p.TP_Dado
                        }));
                    AtualizarRDC.GravarRDC(Cad_Report, lParam, Cad_Report.ID_RDC.Trim().Equals("") ? "H" : "P");
                    formRelPadrao.BB_Atualizar.Visible = true;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem");
            }
        }

        private void FRelPadrao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                (sender as FRelPadrao).afterNovo();
            else if (e.KeyCode.Equals(Keys.F8) && ((sender as FRelPadrao).BB_Imprimir.Visible))
                Imprimir("R");
            else if (e.KeyCode.Equals(Keys.F9) && ((sender as FRelPadrao).BB_DataCube.Visible))
                Imprimir("D");
            else if (e.KeyCode.Equals(Keys.F10) && ((sender as FRelPadrao).BB_Chart.Visible))
                Imprimir("C");
            else if (e.KeyCode.Equals(Keys.F11) && ((sender as FRelPadrao).BB_Atualizar.Visible))
                this.BB_AtualizarClick(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F12) && ((sender as FRelPadrao).BB_Publicar.Visible))
                this.BB_PublicarClick(this, new EventArgs());
            else if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        public bool VerificaParamClasse(string ID_ParamClasse)
        {
            for (int i = 0; i < listaParamClasse.Count; i++)
            {
                if (listaParamClasse[i].NM_CampoFormat == ID_ParamClasse)
                {
                    return true;
                }
            }

            return false;
        }

        private void ID_Param_Leave(object sender, EventArgs e)
        {
            EditDefault CD_Param = (sender as EditDefault);

            string[] ID_ParamClasse = CD_Param.Name.Split(new char[] { '.' });
            Button BB_Param = BuscaComponentForm("BB_Param." + ID_ParamClasse[1].Trim(), formRelPadrao.pFiltro as System.Windows.Forms.Control) as Button;
            EditDefault NM_Param = BuscaComponentForm("NM_Param." + ID_ParamClasse[1].Trim(), formRelPadrao.pFiltro as System.Windows.Forms.Control) as EditDefault;

            if ((BB_Param != null) && (NM_Param != null))
            {
                string separador = ";";
                if (BB_Param.Tag.ToString() == string.Empty)
                    separador = string.Empty;

                string vColunas = CD_Param.NM_Alias + "." + CD_Param.NM_CampoBusca + "|=|'" + CD_Param.Text + "'" + separador + BB_Param.Tag.ToString().Trim();

                object extParam = BuscaAssembly(CD_Param.Tag.ToString().Trim(), NM_Param.NM_Param);

                if (extParam != null)
                    UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Param, NM_Param }, (extParam as CamadaDados.TDataQuery));
            }
        }

        private void BB_Param_Click(object sender, EventArgs e)
        {
            Button BB_Param = (sender as Button);

            string[] ID_ParamClasse = BB_Param.Name.Split(new char[] { '.' });
            EditDefault CD_Param = BuscaComponentForm("ID_Param." + ID_ParamClasse[1].Trim(), formRelPadrao.pFiltro as System.Windows.Forms.Control) as EditDefault;
            EditDefault NM_Param = BuscaComponentForm("NM_Param." + ID_ParamClasse[1].Trim(), formRelPadrao.pFiltro as System.Windows.Forms.Control) as EditDefault;

            if (CD_Param != null && NM_Param != null)
            {
                string NM_Busca = NM_Param.NM_CampoBusca;
                string CD_Busca = CD_Param.NM_CampoBusca;
                if (NM_Param.NM_Alias != "")
                {
                    NM_Busca = NM_Param.NM_Alias + "." + NM_Param.NM_CampoBusca;
                }

                if (NM_Param.NM_Alias != "")
                {
                    CD_Busca = CD_Param.NM_Alias + "." + CD_Param.NM_CampoBusca;
                }

                string vColunas = CD_Busca + "|Código|80;" +
                                  NM_Busca + "|Descrição|350";

                object extParam = BuscaAssembly(CD_Param.Tag.ToString().Trim(), NM_Param.NM_Param);

                if (extParam != null)
                {
                    if (BB_Param.AccessibleName.ToString() == "LISTA")
                        UtilPesquisa.BTN_BUSCALISTA(vColunas, CD_Param, (extParam as CamadaDados.TDataQuery), BB_Param.Tag.ToString().Trim());
                    else
                        UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Param, NM_Param }, (extParam as CamadaDados.TDataQuery), BB_Param.Tag.ToString().Trim());
                }
                else
                {
                    MessageBox.Show("Não foi possivel encontrar a classe do parâmetro!");
                }
            }
        }

        public object BuscaAssembly(string Classe, string NMDLL)
        {
            if (!string.IsNullOrEmpty(NMDLL))
            {
                Assembly extAssembly = Assembly.LoadFrom(Utils.Parametros.pubPathAliance.Trim() + 
                                                         System.IO.Path.DirectorySeparatorChar.ToString() +
                                                         NMDLL);
                object extParam = extAssembly.CreateInstance(Classe);
                return extParam;
            }
            else
                return null;
        }

        public Component BuscaComponentForm(string busca, System.Windows.Forms.Control ComponenteBusca)
        {
            if (ComponenteBusca != null)
            {
                if (ComponenteBusca is EditDefault)
                {
                    if ((ComponenteBusca as EditDefault).Name == busca)
                        return (ComponenteBusca as Component);
                }
                else if (ComponenteBusca is EditMask)
                {
                    if ((ComponenteBusca as EditMask).Name == busca)
                        return (ComponenteBusca as Component);
                }
                else if (ComponenteBusca is Button)
                {
                    if ((ComponenteBusca as Button).Name == busca)
                        return (ComponenteBusca as Component);
                }
                else if (ComponenteBusca is CheckBoxDefault)
                {
                    if ((ComponenteBusca as CheckBoxDefault).Name == busca)
                        return (ComponenteBusca as Component);
                }
                else if (ComponenteBusca is RadioGroup)
                {
                    if ((ComponenteBusca as RadioGroup).Name == busca)
                        return (ComponenteBusca as Component);
                }
                else
                {
                    for (int i = 0; i < ComponenteBusca.Controls.Count; i++)
                    {
                        if (ComponenteBusca.Controls[i] is EditDefault)
                        {
                            if ((ComponenteBusca.Controls[i] as EditDefault).Name == busca)
                                return (ComponenteBusca.Controls[i] as Component);
                        }
                        else if (ComponenteBusca.Controls[i] is EditMask)
                        {
                            if ((ComponenteBusca.Controls[i] as EditMask).Name == busca)
                                return (ComponenteBusca.Controls[i] as Component);
                        }
                        else if (ComponenteBusca.Controls[i] is Button)
                        {
                            if ((ComponenteBusca.Controls[i] as Button).Name == busca)
                                return (ComponenteBusca.Controls[i] as Component);
                        }
                        else if (ComponenteBusca.Controls[i] is CheckBoxDefault)
                        {
                            if ((ComponenteBusca.Controls[i] as CheckBoxDefault).Name == busca)
                                return (ComponenteBusca.Controls[i] as Component);
                        }
                        else if (ComponenteBusca.Controls[i] is RadioGroup)
                        {
                            if ((ComponenteBusca.Controls[i] as RadioGroup).Name == busca)
                                return (ComponenteBusca.Controls[i] as Component);
                        }
                        else if ((ComponenteBusca.Controls[i] is PanelDados) ||
                                 (ComponenteBusca.Controls[i] is Panel) ||
                                 (ComponenteBusca.Controls[i] is TableLayoutPanel) ||
                                 (ComponenteBusca.Controls[i] is GroupBox))
                        {
                            if (ComponenteBusca.Controls[i].Controls.Count > 0)
                                for (int x = 0; x < ComponenteBusca.Controls[i].Controls.Count; x++)
                                {
                                    Component comp = BuscaComponentForm(busca, (ComponenteBusca.Controls[i].Controls[x] as System.Windows.Forms.Control));
                                    if (comp != null)
                                        return comp;
                                }
                        }
                    }
                }
            }
            return null;
        }

        public void Imprimir(string TP_RDC)
        {
            try
            {
                if (formRelPadrao.pFiltro.validarCampoObrigatorio())
                {
                    Relatorio = new Relatorio();
                    List<param> param = new List<param>();

                    //BUSCA A STRING SQL
                    for (int x = 0; x < ListConsulta.Count; x++)
                    {
                        BindingSource BS_Relatorio = new BindingSource();
                        string SQL = ListConsulta[x].DS_SQL;

                        if (vBIntelligence)
                        {
                            Type t = Application.OpenForms["TFBInteligence"].GetType();
                            t.GetMethod("DefineDadosConexao").Invoke(Application.OpenForms["TFBInteligence"], new object[] { "N" });
                        }

                        if (SQL.Trim() == "")
                        {
                            SQL = TCN_Cad_Consulta.BuscaStringSQL(ListConsulta[x], true).ToUpper();
                        }

                        if (SQL.Trim() != "")
                        {
                            for (int i = 0; i < listaParamClasse.Count; i++)
                            {
                                string Valor = "";
                                string CampoFormat = "";
                                string ST_Null = "N";

                                Control ID_Param = BuscaComponentForm("ID_Param." + listaParamClasse[i].ID_ParamClasse.ToString(), formRelPadrao.pFiltro) as Control;
                                if (ID_Param != null)
                                {
                                    CampoFormat = listaParamClasse[i].NM_CampoFormat.ToUpper();
                                    Valor = ID_Param.Text.Trim();
                                    ST_Null = ID_Param.AccessibleName.ToString().Trim();
                                    DefaultData.GravaDefaultData(listaParamClasse[i].NM_CampoFormat.ToUpper() + Cad_Report.ID_Report, ID_Param.Text);
                                }
                                else
                                {
                                    Control NM_Param = BuscaComponentForm("NM_Param." + listaParamClasse[i].ID_ParamClasse.ToString(), formRelPadrao.pFiltro) as Control;
                                    if (NM_Param != null)
                                    {
                                        CampoFormat = listaParamClasse[i].NM_CampoFormat.ToUpper();

                                        if (NM_Param is CheckBoxDefault)
                                        {
                                            CheckBoxDefault check = (NM_Param as CheckBoxDefault);
                                            if (check.Checked)
                                            {
                                                Valor = check.Vl_True;
                                            }
                                            else
                                            {
                                                Valor = check.Vl_False;
                                            }
                                        }
                                        else if (NM_Param is RadioGroup)
                                        {
                                            Valor = "";
                                            for (int y = 0; y < (NM_Param as RadioGroup).Controls.Count; y++)
                                            {
                                                if ((NM_Param as RadioGroup).Controls[y] is RadioButtonDefault)
                                                {
                                                    if (((NM_Param as RadioGroup).Controls[y] as RadioButtonDefault).Checked)
                                                    {
                                                        Valor = ((NM_Param as RadioGroup).Controls[y] as RadioButtonDefault).Valor;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            ST_Null = NM_Param.AccessibleName.ToString().Trim();
                                            if (NM_Param.Text.Equals("  /  /") || NM_Param.Text.Equals("  /  /       :"))
                                            {
                                                Valor = "";
                                                DefaultData.GravaDefaultData(listaParamClasse[i].NM_CampoFormat.ToUpper() + Cad_Report.ID_Report, NM_Param.Text);
                                            }
                                            else
                                            {
                                                Valor = NM_Param.Text.Trim();
                                                DefaultData.GravaDefaultData(listaParamClasse[i].NM_CampoFormat.ToUpper() + Cad_Report.ID_Report, NM_Param.Text);
                                            }
                                        }
                                    }
                                }

                                if (CampoFormat != "")
                                {
                                    param.Add(new param
                                    {
                                        nmparam = CampoFormat,
                                        vlparam = Valor,
                                        st_null = ST_Null
                                    });
                                }
                            }

                            if (vBIntelligence)
                            {
                                Type t = Application.OpenForms["TFBInteligence"].GetType();
                                t.GetMethod("DefineDadosConexao").Invoke(Application.OpenForms["TFBInteligence"], new object[] { "N" });
                            }

                            DataTable dataTable = TCN_Cad_Consulta.BuscarSQL("SET DATEFORMAT dmy; " + processaSQL(SQL, param).Replace("\n", " ").Replace("\t", " "));

                            if (dataTable != null)
                            {
                                //Relatorio
                                BS_Relatorio.DataSource = dataTable;
                                BS_Relatorio.ResetBindings(true);

                                if (TP_RDC.Trim().ToUpper().Equals("R"))
                                {
                                    if (ListConsulta.Count <= 1)
                                        Relatorio.DTS_Relatorio = BS_Relatorio;
                                    else
                                        Relatorio.Adiciona_DataSource(ListConsulta[x].DS_Consulta.Replace(" ", "_").Replace("-", "").Replace("/", ""), BS_Relatorio);
                                }
                            }
                        }
                        else
                        {
                            if (TP_RDC.Trim().ToUpper().Equals("R"))
                            {
                                if (ListConsulta.Count <= 1)
                                    Relatorio.DTS_Relatorio = BS_Relatorio;
                                else
                                    Relatorio.Adiciona_DataSource(ListConsulta[x].DS_Consulta.Replace(" ", "_").Replace("-", "").Replace("/", ""), BS_Relatorio);
                            }
                        }
                    }
                    
                    //ADD OS CAMPOS DE BUSCAS PARA O DTS_PARAM
                    BindingSource DTS_Param = new BindingSource();
                    
                    for (int i = 0; i < param.Count; i++)
                    {
                        if (!Relatorio.Parametros_Relatorio.ContainsKey(param[i].nmparam.ToUpper().Trim()))
                            Relatorio.Parametros_Relatorio.Add(param[i].nmparam.ToUpper().Trim(), param[i].vlparam.Trim());
                    }

                    //BUSCA A LISTA DOS DADOS
                    ImprimeRelatorio(TP_RDC);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("ERRO: " + erro.Message);
            }
            finally
            {
                if (vBIntelligence)
                {
                    Type t = Application.OpenForms["TFBInteligence"].GetType();
                    t.GetMethod("DefineDadosConexao").Invoke(Application.OpenForms["TFBInteligence"], new object[] { "C" });
                }
            }
        }

        private void ImprimeRelatorio(string ID_RDC)
        {
            if (ID_RDC.Trim().ToUpper().Equals("R"))
            {
                Relatorio.Cad_Report = Cad_Report;
                Relatorio.Altera_Relatorio = Altera_Relatorio;
                Relatorio.Nome_Relatorio = Cad_Report.DS_Report;
                Relatorio.Homologacao = Homologacao;
                Relatorio.vURLWebService = vURLWebService;
                Relatorio.Gera_Relatorio();

                if (Homologacao)
                    Cad_Report.Code_Report = Relatorio.Cad_Report.Code_Report;
            }
            Altera_Relatorio = false;
        }

        private string Remove32(string str, char chrbusca, char dir)
        {
            int fp = 0;
            int afp = 0;
            int k = 0;
            if (dir == 'D')
                k = 1;
            else
                k = -1;

            do
            {

                fp = str.IndexOf(chrbusca, afp);
                if (fp > 0)
                {
                    if ((fp + (1 * k)) < str.Length)
                    {
                        char teste = Convert.ToChar(32);
                        if (str[fp + (1 * k)] == 32)
                        {
                            if (fp + (1 * k) >= 0)
                                str = str.Remove(fp + (1 * k), 1);
                        }
                        else
                            afp = fp + 1;
                    }
                    else
                        afp = fp + 1;
                }
            }
            while (fp > 0);
            return str;
        }

        private string RemoveEspacoParentese(string sql)
        {

            string tmp = sql;
            tmp = Remove32(tmp, '(', 'E');
            tmp = Remove32(tmp, '(', 'D');
            tmp = Remove32(tmp, ')', 'E');
            tmp = Remove32(tmp, ')', 'D');

            return tmp;
        }

        private void SubSelects(ref string sql, List<string> subselect, ref int indice)
        {
            int ini = sql.IndexOf("(SELECT");
            if (ini > 0)
            {
                int qtaP = 1;
                int fin;
                for (fin = ini + 1; fin < sql.Length; fin++)
                {
                    if (sql[fin] == '(')
                        qtaP++;
                    if (sql[fin] == ')')
                        qtaP--;
                    if (qtaP == 0)
                        break;
                }
                subselect.Add(sql.Substring(ini, (fin - ini) + 1));
                sql = sql.Replace(subselect[indice], "$[" + indice.ToString() + ']');
                indice++;

                SubSelects(ref sql, subselect, ref indice);
            }
        }

        private void Union(string sql, List<string> union)
        {
            int ini = 0;
            int fin = sql.IndexOf("UNION");
            if (fin > 0)
            {
                if (sql.Substring(fin, 9).Trim().ToUpper().Equals("UNION ALL"))
                    fin += 9;
                else
                    fin += 5;

                union.Add(sql.Substring(ini, (fin - ini) + 1));
                Union(sql.Substring(fin, (sql.Length - fin)), union);
            }
            else
                union.Add(sql);
        }

        private string processaSQL(string sqlQuery, List<param> param)
        {
            //PRIMEIRO PASSO
            //ELIMINAR ESPACOS APOS QUAISQUER PARENTES
            string retorno = string.Empty;
            if (sqlQuery.Contains("{@"))
            {
                sqlQuery = sqlQuery.ToUpper().Replace("  ", " ");
                sqlQuery = RemoveEspacoParentese(sqlQuery);
                //SEPARAR E IDENTIFICAR OS UNION
                List<string> sqlUnion = new List<string>();
                Union(sqlQuery, sqlUnion);
                if (sqlUnion.Count.Equals(0))
                    sqlUnion.Add(sqlQuery);
                //SEPARAR E IDENTIFICAR OS 'SUBSELECTS E EXISTS'
                for(int id = 0; id < sqlUnion.Count; id++)
                {
                    string strSql = sqlUnion[id];
                    List<string> subselects = new List<string>();
                    int indice = 0;
                    SubSelects(ref strSql, subselects, ref indice);

                    //1)SUBSTITUI O ORDER WHERE E AFINS
                    strSql = SubstituiParametros(strSql, param);

                    for (int i = 0; i < subselects.Count; i++)
                    {
                        string sqlSub = subselects[i].Substring(1, (subselects[i].Trim().Length - 2));
                        SubSelects(ref sqlSub, subselects, ref indice);
                        subselects[i] = "(" + sqlSub + ")";
                    }

                    //2)SUBSTITUI VALORES DE PARAMETROS NA LISTA DE SUBSELECTS
                    for (int i = 0; i < subselects.Count; i++)
                    {
                        string sqlSub = subselects[i].Substring(1, (subselects[i].Trim().Length - 2));
                        subselects[i] = SubstituiParametros(sqlSub, param);
                        strSql = strSql.Replace("$[" + i + "]", "(" + subselects[i] + ")");
                    }
                    retorno += strSql;
                }
            }
            //MONTAR NOVAMENTE O SELECT
            return retorno;
        }

        private string SubstituiParametros(string sqlQuery, List<param> param)
        {
            //SEPARAR AS CLAUSULAS SELECT E FROM 
            string sqlSELECT = "";
            int posicaoWhere = sqlQuery.IndexOf("WHERE");
            if (posicaoWhere > 0)
            {
                sqlSELECT = sqlQuery.Substring(0, posicaoWhere);
                string sqlWHERE = "";
                string sqlORDER = "";

                int fimwhere = sqlQuery.IndexOf("GROUP BY");
                if (fimwhere < 0)
                {
                    if (fimwhere < 0)
                        fimwhere = sqlQuery.IndexOf("ORDER BY");
                    else
                        fimwhere = sqlQuery.Length;
                }

                if (fimwhere > 0)
                {
                    sqlWHERE = sqlQuery.Substring(sqlQuery.IndexOf("WHERE"), (fimwhere - sqlQuery.IndexOf("WHERE")));
                    sqlORDER = sqlQuery.Substring(fimwhere);
                }
                else
                    sqlWHERE = sqlQuery.Substring(sqlQuery.IndexOf("WHERE"), (sqlQuery.Length - sqlQuery.IndexOf("WHERE")));


                //1) SUBSTITUI VALORES DE PARAMETROS NO SQL PRINCIPAL
                //1.1) substitui valores de parametros de clausula select e from 
                for (int i = 0; i < param.Count; i++)
                {
                    if (string.IsNullOrEmpty(param[i].vlparam))
                    {
                        sqlSELECT = sqlSELECT.Replace(param[i].nmparam, "NULL");
                        sqlORDER = sqlORDER.Replace(param[i].nmparam, "NULL");
                    }
                    else
                    {
                        sqlSELECT = sqlSELECT.Replace(param[i].nmparam, param[i].vlparam);
                        sqlORDER = sqlORDER.Replace(param[i].nmparam, param[i].vlparam);
                    }
                }
                sqlSELECT = sqlSELECT.Replace("'NULL'", "NULL");
                sqlORDER = sqlORDER.Replace("'NULL'", "NULL");

                //1.2) substitui valores de parametros de clausula where
                sqlWHERE = sqlWHERE.Replace("\n", " ").Replace("\r", " ").Replace("\t", " ");
                sqlWHERE = sqlWHERE.Replace("  ", " ");
                List<string> SQLCondicoes = ParseWhere(sqlWHERE);

                for (int i = 0; i < SQLCondicoes.Count; i++)
                {
                    string condicao = "(" + SQLCondicoes[i].Trim() + ")";

                    if (condicao.Contains("{@"))
                    {
                        condicao = SubstituiParam(condicao, param);
                        sqlWHERE = sqlWHERE.Replace(SQLCondicoes[i], condicao);
                    }
                }

                sqlWHERE = sqlWHERE.Replace("'NULL'", "NULL");
                sqlWHERE = sqlWHERE.Replace("'%NULL%'", "'%%'");

                return sqlSELECT + " " + sqlWHERE + " " + sqlORDER;
            }
            else
            {
                if (sqlQuery.Contains("{@"))
                {
                    sqlQuery = SubstituiParam(sqlQuery, param);
                }

                sqlQuery = sqlQuery.Replace("'NULL'", "NULL");
                sqlQuery = sqlQuery.Replace("'%NULL%'", "'%%'");

                return sqlQuery;
            }
        }

        private string SubstituiParam(string condicao, List<param> param)
        {
            for (int x = 0; x < param.Count; x++)
            {
                if (condicao.Contains(param[x].nmparam))
                {
                    if (param[x].vlparam == "" && param[x].st_null == "N")
                    {
                        condicao = condicao.Replace(param[x].nmparam, "NULL");
                        if(!condicao.Contains("SELECT"))
                            condicao = "(" + condicao + " OR (1 = 1))";
                    }
                    else if (param[x].vlparam == "" && param[x].st_null == "S")
                    {
                        condicao = condicao.Replace(param[x].nmparam, "NULL");
                    }
                    else
                    {
                        condicao = condicao.Replace(param[x].nmparam, param[x].vlparam);
                    }
                }
            }

            return condicao;
        }

        public List<string> ParseWhere(string strWhere)
        {
            List<string> listaCondicoes = new List<string>();

            string[] strWhereArray = strWhere.Split(new string[]{" "}, StringSplitOptions.None);

            for (int i = 0; i < strWhereArray.Length; i++)
            {
                string condicao = "";

                if ((strWhereArray[i].Equals("WHERE") ||
                     strWhereArray[i].Equals("AND") ||
                     strWhereArray[i].Equals("OR")) ||
                    (strWhereArray[i].Contains("WHERE(") ||
                     strWhereArray[i].Contains("AND(") ||
                     strWhereArray[i].Contains("OR(")))
                {
                    bool continuar = true;
                    bool gravar = false;
                    string espaco = "";
                    while (continuar)
                    {
                        gravar = false;
                        if (strWhereArray[i].Equals("WHERE") ||
                            strWhereArray[i].Equals("AND") ||
                            strWhereArray[i].Equals("OR"))
                        {
                            i++;
                            condicao += espaco + strWhereArray[i];
                            espaco = " ";
                            i++;
                        }
                        else if (strWhereArray[i].Contains("WHERE(") ||
                                 strWhereArray[i].Contains("AND(") ||
                                 strWhereArray[i].Contains("OR("))
                        {
                            gravar = false;

                            if (strWhereArray[i].Contains("WHERE("))
                                condicao += espaco + "(" + strWhereArray[i].Replace("WHERE(", "");
                            else if (strWhereArray[i].Contains("AND("))
                                condicao += espaco + "(" + strWhereArray[i].Replace("AND(", "");
                            else
                                condicao += espaco + "(" + strWhereArray[i].Replace("OR(", "");
                            
                            espaco = " ";
                            i++;
                        }
                        else
                        {
                            condicao += espaco + strWhereArray[i];
                            espaco = " ";
                            i++;
                        }

                        if (i < strWhereArray.Length)
                        {
                            if (strWhereArray[i].Equals("WHERE") ||
                                strWhereArray[i].Equals("AND") ||
                                strWhereArray[i].Equals("OR"))
                            {
                                gravar = true;
                            }
                            else if (strWhereArray[i].Contains("WHERE(") ||
                                     strWhereArray[i].Contains("AND(") ||
                                     strWhereArray[i].Contains("OR("))
                            {
                                gravar = true;
                            }
                        }
                        else
                        {
                            gravar = true;
                        }

                        if (gravar)
                        {
                            if (condicao.Trim() != "")
                                listaCondicoes.Add(condicao);
                            continuar = false;
                            i--;
                        }
                    }
                }
            }

            return listaCondicoes;
        }

    }
}

