using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using System.Collections;
using System.Text.RegularExpressions;
using Componentes;

namespace Consulta
{
    public partial class TFCad_SQL : Form
    {
        int PosFocusRich = 0;
        public TRegistro_Cad_Consulta Cad_Consulta;
        public bool Homologacao = false;
        public bool Editar = false;
        private TList_Cad_Usuario_X_Tabela ListaTabelasPermitidas;
        public string ConsultaSql = string.Empty;

        public TFCad_SQL(TRegistro_Cad_Consulta Reg_Consulta, bool vEditar)
        {
            InitializeComponent();
            Cad_Consulta = Reg_Consulta;
            DS_SQL.Text = Cad_Consulta.DS_SQL;
            Editar = vEditar;

            //ADD O HIGHLIGHT
            //Parse();

            //BUSCA AS TABELAS PERMITIDAS
            if (!Editar)
                ListaTabelasPermitidas = TCN_Cad_Usuario_X_Tabela.Busca(Utils.Parametros.pubLogin, "", "");

            //DA O FOCUS
            if ((pNMConsulta.Visible))
                NM_Consulta.Focus();
            else
                DS_SQL.Focus();
        }

        private void BB_ParamClasse_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ID_ParamClasse|Código Parâmetro|80;" +
                                   "a.NM_Param|Nome Parâmetro|350;" +
                                   "a.NM_CampoFormat|Campo Format|350;" +
                                   "a.NM_Classe|Nome Classe|350",
                                   new Componentes.EditDefault[] { ID_ParamClasse, NM_Param, NM_CampoFormat, NM_Classe },
                                   new TCD_Cad_ParamClasse(), "");
        }

        private void ID_ParamClasse_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.ID_ParamClasse|=|'" + ID_ParamClasse.Text + "'",
                                    new Componentes.EditDefault[] { ID_ParamClasse, NM_Param, NM_CampoFormat, NM_Classe },
                                    new TCD_Cad_ParamClasse());
        }

        private void TFCad_SQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                tsBB_SalvarSQL_Click(null, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                tsBB_Cancelar_Click(null, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                tsBB_AddParam_Click(null, null);
                ID_ParamClasse.Focus();
            }
            else if (e.KeyCode == Keys.F5)
            {
                tsBB_Executar_Click(null, null);
            }
        }

        private void DS_SQL_Leave(object sender, EventArgs e)
        {
            PosFocusRich = DS_SQL.SelectionStart;
        }

        #region "Parametros"

            private void tsBB_Executar_Click(object sender, EventArgs e)
            {
                List<string> lista = new List<string>();
                System.IO.StringReader rd = new System.IO.StringReader(DS_SQL.Text);
                string linha = string.Empty;
                while (linha != null)
                {
                    linha = rd.ReadLine();
                    if (linha != null)
                        if (linha.Contains("'{@"))  
                        {
                           string[] var = linha.Split(new char[] { '{' });
                           for (int i = 0; var.Length > i; i++)
                           {
                               if (var[i].Contains("@") && var[i].Contains("}"))
                                   if (!lista.Exists(p=> p.Equals(var[i])))
                                        lista.Add(var[i].Split(new char[] {'}'})[0]);
                           }
                        };
                }
                if (lista.Count > 0)
                {
                    using (TFParametrosConsulta fParam = new TFParametrosConsulta())
                    {
                        //Criar fonte de dados
                        fParam.lista = lista;
                        if (fParam.ShowDialog() == DialogResult.OK)
                            if (fParam.data != null)
                            {
                                string Sql = DS_SQL.Text;
                                for (int i = 0; fParam.data.Rows.Count > i; i++)
                                {
                                    if (!string.IsNullOrEmpty(ConsultaSql))
                                        Sql = ConsultaSql;
                                    string param = "{" + fParam.data.Rows[i]["param"] + "}";
                                    string valor = fParam.data.Rows[i]["valor"].ToString();
                                    ConsultaSql = Sql.Replace(param, valor);
                                }
                            }
                    }
                }
                else
                    ConsultaSql = DS_SQL.Text;

                if (VerificaAcessoSyntax() && VerificaTabelasPermitidas())
                {
                    try
                    {
                        adicionaMSGErro("Aguarde... executanto a consulta SQL!");

                        if (grid_Resultado.Columns.Count > 0)
                            grid_Resultado.Columns.Clear();

                        if (grid_Resultado.Rows.Count > 0)
                            grid_Resultado.Rows.Clear();

                        if (DS_SQL.Text != "")
                        {
                            DataTable dataTable = TCN_Cad_Consulta.BuscarSQL(ConsultaSql.Replace("\n", " ").Replace("\t", " "));

                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                DataGridViewTextBoxColumn coluna = new DataGridViewTextBoxColumn();
                                coluna.Name = dataTable.Columns[i].ColumnName;
                                coluna.HeaderText = dataTable.Columns[i].ColumnName;
                                coluna.DataPropertyName = dataTable.Columns[i].ColumnName;
                                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                                grid_Resultado.Columns.Add(coluna);
                            }

                            BS_Resultado.DataSource = dataTable;
                            BS_Resultado.ResetBindings(true);

                            grid_Resultado.Visible = true;
                            tabPageResult.Controls.Clear();
                            tabPageResult.Controls.Add(grid_Resultado);
                        }
                        else
                        {
                            adicionaMSGErro("Atenção há erros na SQL!");
                        }
                    }
                    catch (Exception erro)
                    {
                        adicionaMSGErro("ERRO: " + erro.Message);
                    }
                }
            }

            public void adicionaMSGErro(string msg)
            {
                grid_Resultado.Visible = false;
                tabPageResult.Controls.Clear();
                EditDefault edit = new EditDefault();
                edit.Text = msg;
                edit.ReadOnly = true;
                edit.Multiline = true;
                edit.ForeColor = Color.Red;
                edit.Dock = DockStyle.Fill;
                tabPageResult.Controls.Add(edit);
                DS_SQL.Focus();
            }

            private void tsBB_AddParam_Click(object sender, EventArgs e)
            {
                //limpa os dados do parametro
                pDadosParam.LimparRegistro();
                pDadosParam.Visible = true;
                ID_ParamClasse.Focus();
            }

            private void tsBB_Cancelar_Click(object sender, EventArgs e)
            {
                if (MessageBox.Show("Deseja realmente cancelar a edição desta SQL?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    DS_SQL.Focus();
                }
            }

            private void tsBB_SalvarSQL_Click(object sender, EventArgs e)
            {
                if (VerificaAcessoSyntax() && VerificaTabelasPermitidas())
                {
                    //GRAVA A CONSULTA
                    Cad_Consulta.DS_SQL = DS_SQL.Text;

                    if (!Homologacao)
                    {
                        string retorno = TCN_Cad_Consulta.GravaConsulta(Cad_Consulta, null);

                        if (retorno == "")
                        {
                            MessageBox.Show("Atenção não foi possível gravar os dados do SQL, por favor tente novamente!");
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        if ((pNMConsulta.Visible) && (NM_Consulta.Text.Trim() == ""))
                            MessageBox.Show("É obrigatório o preenchimento do nome da consulta!");
                        else
                            this.Close();
                    }
                }
            }

            private void bb_Cancelar_Click(object sender, EventArgs e)
            {
                pDadosParam.LimparRegistro();
                pDadosParam.Visible = false;
            }

            private void bb_Adicionar_Click(object sender, EventArgs e)
            {
                //ADICIONA VALOR DO PARAMETRO AO TEXTO
                DS_SQL.Text = DS_SQL.Text.Insert(PosFocusRich, NM_CampoFormat.Text);
                DS_SQL.SelectionStart = (NM_CampoFormat.Text.Length + PosFocusRich);
                DS_SQL.Focus();
                pDadosParam.Visible = false;
            }

        #endregion

        #region "HighLights"

            public void Parse()
            {
                string texto = DS_SQL.Text;
                DS_SQL.Text = "";
                ParseLine(texto);
                DS_SQL.TextChanged += new System.EventHandler(this.TextChangedEvent);
            }

            public void ParseLine(string line)
            {
                //DS_SQL.HideSelection = true;
                Regex r = new Regex("([ \\t{}();])");
                string[] tokens = r.Split(line);
                string[] keywords = keywordsArray();
                string[] keywordsSyntax = keywordsArraySyntax();

                for (int x = 0; x < tokens.Length; x++)
                {
                    string token = tokens[x].Replace("\n", "").Replace("\t", "");
                    string tokenNormal = tokens[x];
                    // SETA A FONT E A COR
                    DS_SQL.SelectionColor = Color.Black;
                    DS_SQL.SelectionFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);

                    if (token == "--" || token.StartsWith("--"))
                    {
                        // PROCURA SE TEM COMENTARIO
                        int index = line.IndexOf("--");
                        string comment = line.Substring(index, line.Length - index);
                        DS_SQL.SelectionColor = Color.LightGreen;
                        DS_SQL.SelectionFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
                        DS_SQL.SelectedText = comment;
                        break;
                    }

                    // VERIFICA SE TEM OS KEYWORDS DA SQL
                    for (int i = 0; i < keywords.Length; i++)
                    {
                        if (keywords[i] == token || keywords[i].ToLower() == token.ToLower())
                        {
                            DS_SQL.SelectionColor = Color.Blue;
                            DS_SQL.SelectionFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
                            break;
                        }
                    }

                    //SYNTAX INVALIDA
                    if (keywordsSyntax != null)
                    {
                        for (int i = 0; i < keywordsSyntax.Length; i++)
                        {
                            if (keywordsSyntax[i] == token || keywordsSyntax[i].ToLower() == token.ToLower())
                            {
                                DS_SQL.SelectionColor = Color.Red;
                                DS_SQL.SelectionFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
                                break;
                            }
                        }
                    }

                    DS_SQL.SelectedText = tokenNormal;
                }
                //DS_SQL.SelectedText = "\n";
            }

            private void TextChangedEvent(object sender, EventArgs e)
            {
                Color corBack = DS_SQL.SelectionBackColor;
                DS_SQL.SelectionBackColor = Color.White;
                string[] keywords = keywordsArray();
                string[] keywordsSyntax = keywordsArraySyntax();
                
                // CALCULA A POSICAO INICIAL
                int start = 0, end = 0;
                for (start = DS_SQL.SelectionStart - 1; start > 0; start--)
                {
                    if (DS_SQL.Text[start] == '\n') { start++; break; }
                }

                // CALCULA A POSICAO FINAL
                for (end = DS_SQL.SelectionStart; end < DS_SQL.Text.Length; end++)
                {
                    if (DS_SQL.Text[end] == '\n') break;
                }

                // EXTRAI TEXTO
                if ((end - start) >= 0 && start >= 0)
                {
                    String line = DS_SQL.Text.Substring(start, end - start);

                    int selectionStart = DS_SQL.SelectionStart;
                    int selectionLength = DS_SQL.SelectionLength;

                    //DS_SQL.HideSelection = true;
                    Regex r = new Regex("([ \\t{}();])");
                    string[] tokens = r.Split(line);
                    int index = start;

                    //foreach (string token in tokens)
                    for (int x = 0; x < tokens.Length; x++)
                    {
                        string token = tokens[x];
                        DS_SQL.SelectionStart = index;
                        DS_SQL.SelectionLength = token.Length;
                        DS_SQL.SelectionColor = Color.Black;
                        DS_SQL.SelectionFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);

                        if (token == "--" || token.StartsWith("--"))
                        {
                            int length = line.Length - (index - start);
                            string commentText = DS_SQL.Text.Substring(index, length);
                            DS_SQL.SelectionStart = index;
                            DS_SQL.SelectionLength = length;
                            DS_SQL.SelectionColor = Color.LightGreen;
                            DS_SQL.SelectionFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
                            break;
                        }

                        for (int i = 0; i < keywords.Length; i++)
                        {
                            if (keywords[i] == token || keywords[i].ToLower() == token.ToLower())
                            {
                                DS_SQL.SelectionColor = Color.Blue;
                                DS_SQL.SelectionFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
                                break;
                            }
                        }

                        //SYNTAX INVALIDA
                        if (keywordsSyntax != null)
                        {
                            for (int i = 0; i < keywordsSyntax.Length; i++)
                            {
                                if (keywordsSyntax[i] == token || keywordsSyntax[i].ToLower() == token.ToLower())
                                {
                                    DS_SQL.SelectionColor = Color.Red;
                                    DS_SQL.SelectionFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
                                    break;
                                }
                            }
                        }

                        index += token.Length;
                    }
                    DS_SQL.SelectionStart = selectionStart;
                    DS_SQL.SelectionLength = selectionLength;
                    DS_SQL.SelectionBackColor = corBack;
                }
            }

            public string[] keywordsArray()
            {
                return new String[] { "ADD", "EXCEPT", "PERCENT",
                                      "ALL", "EXEC", "PLAN", "EXECUTE", "PRECISION",
                                      "AND", "EXISTS", "PRIMARY",
                                      "ANY", "EXIT", "PRINT",
                                      "AS", "FETCH", "PROC",
                                      "ASC", "FILE", "PROCEDURE",
                                      "AUTHORIZATION", "FILLFACTOR", "PUBLIC",
                                      "BACKUP", "FOR", "RAISERROR",
                                      "BEGIN", "FOREIGN", "READ",
                                      "BETWEEN", "FREETEXT", "READTEXT",
                                      "BREAK", "FREETEXTTABLE", "RECONFIGURE",
                                      "BROWSE", "FROM", "REFERENCES",
                                      "BULK", "FULL", "REPLICATION",
                                      "BY", "FUNCTION", "RESTORE",
                                      "CASCADE", "GOTO", "RESTRICT",
                                      "CASE", "GRANT", "RETURN",
                                      "CHECK", "GROUP", "REVOKE",
                                      "CHECKPOINT", "HAVING", "RIGHT",
                                      "CLOSE", "HOLDLOCK", "ROLLBACK",
                                      "CLUSTERED", "IDENTITY", "ROWCOUNT",
                                      "COALESCE", "IDENTITY_INSERT", "ROWGUIDCOL",
                                      "COLLATE", "IDENTITYCOL", "RULE",
                                      "COLUMN", "IF", "SAVE",
                                      "COMMIT", "IN", "SCHEMA",
                                      "COMPUTE", "INDEX", "SELECT",
                                      "CONSTRAINT", "INNER", "SESSION_USER",
                                      "CONTAINS", "SET", "CONTAINSTABLE", "INTERSECT", "SETUSER",
                                      "CONTINUE", "INTO", "SHUTDOWN",
                                      "CONVERT", "IS", "SOME",
                                      "CREATE", "JOIN", "STATISTICS",
                                      "CROSS", "KEY", "SYSTEM_USER",
                                      "CURRENT", "KILL", "TABLE",
                                      "CURRENT_DATE", "LEFT", "TEXTSIZE",
                                      "CURRENT_TIME", "LIKE", "THEN",
                                      "CURRENT_TIMESTAMP", "LINENO", "TO",
                                      "CURRENT_USER", "LOAD", "TOP",
                                      "CURSOR", "NATIONAL", "TRAN",
                                      "DATABASE", "NOCHECK", "TRANSACTION",
                                      "DBCC", "NONCLUSTERED", "TRIGGER",
                                      "DEALLOCATE", "NOT", "TRUNCATE",
                                      "DECLARE", "NULL", "TSEQUAL",
                                      "DEFAULT", "NULLIF", "UNION", "OF", "UNIQUE",
                                      "DENY", "OFF", "DESC", "OFFSETS", "UPDATETEXT",
                                      "DISK", "ON", "USE",
                                      "DISTINCT", "OPEN", "USER",
                                      "DISTRIBUTED", "OPENDATASOURCE", "VALUES",
                                      "DOUBLE", "OPENQUERY", "VARYING", "OPENROWSET", "VIEW",
                                      "DUMMY", "OPENXML", "WAITFOR", "OPTION", "WHEN",
                                      "ELSE", "OR", "WHERE",
                                      "END", "ORDER", "WHILE",
                                      "ERRLVL", "OUTER", "WITH",
                                      "ESCAPE", "OVER", "WRITETEXT", "UPDATE", "INSERT", "DELETE", "ALTER", "DROP", "DUMP"  };
            }

            public string[] keywordsArraySyntax()
            {
                String[] regras = new String[] { "UPDATE", "INSERT", "DELETE", "ALTER", "DROP", "DUMP" };

                DataTable datatable = new CamadaDados.Diversos.TCD_Usuario_RegraEspecial().Buscar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.login",
                            vOperador = "=",
                            vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "   ((a.DS_Regra = 'PERMITIR INSERT') "+ 
                                        "OR (a.DS_Regra = 'PERMITIR UPDATE') "+
                                        "OR (a.DS_Regra = 'PERMITIR DELETE') "+
                                        "OR (a.DS_Regra = 'PERMITIR ALTER') "+
                                        "OR (a.DS_Regra = 'PERMITIR DROP') "+
                                        "OR (a.DS_Regra = 'PERMITIR DUMP'))"
                        }
                    }, 0);

                if (datatable.Rows.Count > 0)
                {
                    String[] stringArray = new String[(regras.Length - datatable.Rows.Count)];

                    int x = 0;
                    for (int y = 0; y < regras.Length; y++)
                    {
                        bool existe = false;
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if (regras[y] == datatable.Rows[i]["DS_Regra"].ToString().Replace("PERMITIR ", "").Trim())
                            {
                                existe = true;
                                break;
                            }
                        }

                        if (!existe)
                        {
                            stringArray[x] = regras[y];
                            x++;
                        }
                    }

                    return stringArray;
                }
                else
                {
                    return regras;
                }
            }

            private bool VerificaAcessoSyntax()
            {
                bool valido = true;

                if (!Editar)
                {
                    string sql = DS_SQL.Text;
                    string[] keywordsSyntax = keywordsArraySyntax();

                    Regex r = new Regex("([ \\t{}();])");
                    String[] tokens = r.Split(sql);

                    if (keywordsSyntax != null)
                    {
                        for (int x = 0; x < tokens.Length; x++)
                        {
                            string token = tokens[x].Replace("\n", "").Replace("\t", "");
                            string tokenNormal = tokens[x];

                            // VERIFICA SE TEM OS KEYWORDS DA SQL
                            for (int i = 0; i < keywordsSyntax.Length; i++)
                            {
                                if (keywordsSyntax[i] == token || keywordsSyntax[i].ToLower() == token.ToLower())
                                {
                                    DS_SQL.SelectionColor = Color.Red;
                                    DS_SQL.SelectionFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
                                    valido = false;
                                    break;
                                }
                            }

                            if (!valido)
                            {
                                break;
                            }
                        }
                    }
                }
                if (valido)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Atenção, a SQL contém syntax não autorizadas!");
                    DS_SQL.Focus();

                    return false;
                }

            }

            private bool VerificaTabelasPermitidas()
            {
                bool retorno = true;

                if (!Editar)
                {
                    String[] sqlArray = DS_SQL.Text.ToUpper().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int x = 0; x < sqlArray.Length; x++)
                    {
                        string NMTabelas = sqlArray[x].Trim();
                        if (NMTabelas.StartsWith("TB_") || NMTabelas.StartsWith("VTB_"))
                        {
                            if (NMTabelas.Contains("JOIN") ||
                                NMTabelas.Contains("FROM"))
                            {
                                retorno = false;

                                for (int i = 0; i < ListaTabelasPermitidas.Count; i++)
                                {
                                    if (ListaTabelasPermitidas[i].NM_Tabela.ToUpper().Trim() == NMTabelas)
                                    {
                                        retorno = true;
                                        break;
                                    }
                                }

                                if (!retorno)
                                {
                                    break;
                                }
                            }
                        }
                    }

                }
                if (retorno)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Atenção, a SQL contém tabelas não autorizadas que o usuário " + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + " não tem permissão de acesso!");
                    DS_SQL.Focus();

                    return false;
                }

            }
        
        #endregion

            private void TFCad_SQL_Load(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                    Idioma.TIdioma.AjustaCultura(this);
            }

    }
}

