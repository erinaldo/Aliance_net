namespace Parametros.Diversos
{
    partial class FCadTrigger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadTrigger));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bbExecutar = new System.Windows.Forms.ToolStripButton();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.st_marcamov = new Componentes.CheckBoxDefault(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.st_agregar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nomecolunaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tamanhoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsColunas = new System.Windows.Forms.BindingSource(this.components);
            this.bsTrigger = new System.Windows.Forms.BindingSource(this.components);
            this.panelDados3 = new Componentes.PanelDados(this.components);
            this.panelDados4 = new Componentes.PanelDados(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados5 = new Componentes.PanelDados(this.components);
            this.scriptText = new System.Windows.Forms.RichTextBox();
            this.panelDados6 = new Componentes.PanelDados(this.components);
            this.cbTrigger = new Componentes.ComboBoxDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColunas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrigger)).BeginInit();
            this.panelDados3.SuspendLayout();
            this.panelDados4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelDados5.SuspendLayout();
            this.panelDados6.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bbExecutar,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(951, 43);
            this.barraMenu.TabIndex = 12;
            // 
            // bbExecutar
            // 
            this.bbExecutar.AutoSize = false;
            this.bbExecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbExecutar.ForeColor = System.Drawing.Color.Green;
            this.bbExecutar.Image = ((System.Drawing.Image)(resources.GetObject("bbExecutar.Image")));
            this.bbExecutar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbExecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbExecutar.Name = "bbExecutar";
            this.bbExecutar.Size = new System.Drawing.Size(95, 40);
            this.bbExecutar.Text = "(F5)\r\nExecutar";
            this.bbExecutar.ToolTipText = "Executar";
            this.bbExecutar.Click += new System.EventHandler(this.bbExecutar_Click);
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(54, 40);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDados3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 410);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.panelDados2);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(374, 404);
            this.panelDados1.TabIndex = 0;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.st_marcamov);
            this.panelDados2.Controls.Add(this.dataGridDefault1);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(0, 0);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(374, 404);
            this.panelDados2.TabIndex = 14;
            // 
            // st_marcamov
            // 
            this.st_marcamov.AutoSize = true;
            this.st_marcamov.Location = new System.Drawing.Point(6, 5);
            this.st_marcamov.Name = "st_marcamov";
            this.st_marcamov.NM_Alias = "";
            this.st_marcamov.NM_Campo = "";
            this.st_marcamov.NM_Param = "";
            this.st_marcamov.Size = new System.Drawing.Size(15, 14);
            this.st_marcamov.ST_Gravar = true;
            this.st_marcamov.ST_LimparCampo = true;
            this.st_marcamov.ST_NotNull = false;
            this.st_marcamov.TabIndex = 17;
            this.st_marcamov.UseVisualStyleBackColor = true;
            this.st_marcamov.Vl_False = "";
            this.st_marcamov.Vl_True = "";
            this.st_marcamov.Click += new System.EventHandler(this.st_marcamov_Click);
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.st_agregar,
            this.nomecolunaDataGridViewTextBoxColumn,
            this.chaveDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn,
            this.tamanhoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsColunas;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(374, 404);
            this.dataGridDefault1.TabIndex = 0;
            this.dataGridDefault1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDefault1_CellClick);
            this.dataGridDefault1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridDefault1_CellFormatting);
            // 
            // st_agregar
            // 
            this.st_agregar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.st_agregar.DataPropertyName = "st_agregar";
            this.st_agregar.HeaderText = "Sincronizar";
            this.st_agregar.Name = "st_agregar";
            this.st_agregar.ReadOnly = true;
            this.st_agregar.Width = 65;
            // 
            // nomecolunaDataGridViewTextBoxColumn
            // 
            this.nomecolunaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nomecolunaDataGridViewTextBoxColumn.DataPropertyName = "nome_coluna";
            this.nomecolunaDataGridViewTextBoxColumn.HeaderText = "Coluna";
            this.nomecolunaDataGridViewTextBoxColumn.Name = "nomecolunaDataGridViewTextBoxColumn";
            this.nomecolunaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomecolunaDataGridViewTextBoxColumn.Width = 65;
            // 
            // chaveDataGridViewTextBoxColumn
            // 
            this.chaveDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.chaveDataGridViewTextBoxColumn.DataPropertyName = "chave";
            this.chaveDataGridViewTextBoxColumn.HeaderText = "Key";
            this.chaveDataGridViewTextBoxColumn.Name = "chaveDataGridViewTextBoxColumn";
            this.chaveDataGridViewTextBoxColumn.ReadOnly = true;
            this.chaveDataGridViewTextBoxColumn.Width = 50;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDataGridViewTextBoxColumn.Width = 53;
            // 
            // tamanhoDataGridViewTextBoxColumn
            // 
            this.tamanhoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tamanhoDataGridViewTextBoxColumn.DataPropertyName = "tamanho";
            this.tamanhoDataGridViewTextBoxColumn.HeaderText = "Tamanho";
            this.tamanhoDataGridViewTextBoxColumn.Name = "tamanhoDataGridViewTextBoxColumn";
            this.tamanhoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tamanhoDataGridViewTextBoxColumn.Width = 77;
            // 
            // bsColunas
            // 
            this.bsColunas.DataMember = "lColunas";
            this.bsColunas.DataSource = this.bsTrigger;
            // 
            // bsTrigger
            // 
            this.bsTrigger.DataSource = typeof(CamadaDados.Diversos.TList_Triggers);
            // 
            // panelDados3
            // 
            this.panelDados3.Controls.Add(this.panelDados4);
            this.panelDados3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados3.Location = new System.Drawing.Point(383, 3);
            this.panelDados3.Name = "panelDados3";
            this.panelDados3.NM_ProcDeletar = "";
            this.panelDados3.NM_ProcGravar = "";
            this.panelDados3.Size = new System.Drawing.Size(565, 404);
            this.panelDados3.TabIndex = 1;
            // 
            // panelDados4
            // 
            this.panelDados4.Controls.Add(this.tableLayoutPanel2);
            this.panelDados4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados4.Location = new System.Drawing.Point(0, 0);
            this.panelDados4.Name = "panelDados4";
            this.panelDados4.NM_ProcDeletar = "";
            this.panelDados4.NM_ProcGravar = "";
            this.panelDados4.Size = new System.Drawing.Size(565, 404);
            this.panelDados4.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panelDados5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelDados6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.158416F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.84158F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(565, 404);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panelDados5
            // 
            this.panelDados5.Controls.Add(this.scriptText);
            this.panelDados5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados5.Location = new System.Drawing.Point(3, 39);
            this.panelDados5.Name = "panelDados5";
            this.panelDados5.NM_ProcDeletar = "";
            this.panelDados5.NM_ProcGravar = "";
            this.panelDados5.Size = new System.Drawing.Size(559, 362);
            this.panelDados5.TabIndex = 0;
            // 
            // scriptText
            // 
            this.scriptText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptText.Location = new System.Drawing.Point(0, 0);
            this.scriptText.Name = "scriptText";
            this.scriptText.Size = new System.Drawing.Size(559, 362);
            this.scriptText.TabIndex = 0;
            this.scriptText.Text = "";
            // 
            // panelDados6
            // 
            this.panelDados6.Controls.Add(this.cbTrigger);
            this.panelDados6.Controls.Add(this.label1);
            this.panelDados6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados6.Location = new System.Drawing.Point(3, 3);
            this.panelDados6.Name = "panelDados6";
            this.panelDados6.NM_ProcDeletar = "";
            this.panelDados6.NM_ProcGravar = "";
            this.panelDados6.Size = new System.Drawing.Size(559, 30);
            this.panelDados6.TabIndex = 1;
            // 
            // cbTrigger
            // 
            this.cbTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrigger.FormattingEnabled = true;
            this.cbTrigger.Location = new System.Drawing.Point(64, 4);
            this.cbTrigger.Name = "cbTrigger";
            this.cbTrigger.NM_Alias = "";
            this.cbTrigger.NM_Campo = "";
            this.cbTrigger.NM_Param = "";
            this.cbTrigger.Size = new System.Drawing.Size(307, 21);
            this.cbTrigger.ST_Gravar = false;
            this.cbTrigger.ST_LimparCampo = true;
            this.cbTrigger.ST_NotNull = false;
            this.cbTrigger.TabIndex = 156;
            this.cbTrigger.SelectedIndexChanged += new System.EventHandler(this.cbTrigger_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operação:";
            // 
            // FCadTrigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "FCadTrigger";
            this.Text = "Construtor de Triggers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FCadTrigger_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCadTrigger_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColunas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrigger)).EndInit();
            this.panelDados3.ResumeLayout(false);
            this.panelDados4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelDados5.ResumeLayout(false);
            this.panelDados6.ResumeLayout(false);
            this.panelDados6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private Componentes.PanelDados panelDados2;
        private Componentes.DataGridDefault dataGridDefault1;
        private Componentes.PanelDados panelDados3;
        private Componentes.PanelDados panelDados4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Componentes.PanelDados panelDados5;
        private System.Windows.Forms.BindingSource bsTrigger;
        private System.Windows.Forms.BindingSource bsColunas;
        private Componentes.PanelDados panelDados6;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault cbTrigger;
        private System.Windows.Forms.RichTextBox scriptText;
        private Componentes.CheckBoxDefault st_marcamov;
        private System.Windows.Forms.ToolStripButton bbExecutar;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_agregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomecolunaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamanhoDataGridViewTextBoxColumn;
    }
}