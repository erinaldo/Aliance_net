namespace Parametros.Diversos
{
    partial class TFAuditoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAuditoria));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados3 = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsAuditoria = new System.Windows.Forms.BindingSource(this.components);
            this.panelDados4 = new Componentes.PanelDados(this.components);
            this.dataGridDefault2 = new Componentes.DataGridDefault(this.components);
            this.idauditoriaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idregistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcolunaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vloldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlatualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsColuna = new System.Windows.Forms.BindingSource(this.components);
            this.panelDados5 = new Componentes.PanelDados(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.eddtfim = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.eddtini = new Componentes.EditData(this.components);
            this.cbTrigger = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tabela = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.idauditoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dteventostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmtabelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoeventoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_chave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelDados3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAuditoria)).BeginInit();
            this.panelDados4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColuna)).BeginInit();
            this.panelDados5.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Buscar,
            this.toolStripSeparator5,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(940, 43);
            this.barraMenu.TabIndex = 5;
            // 
            // BB_Buscar
            // 
            this.BB_Buscar.AutoSize = false;
            this.BB_Buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BB_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Buscar.Image")));
            this.BB_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Size = new System.Drawing.Size(80, 40);
            this.BB_Buscar.Text = "(F7)\r\nBuscar";
            this.BB_Buscar.ToolTipText = "Localizar Registros";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 43);
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.tableLayoutPanel1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(940, 395);
            this.panelDados1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDados5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(940, 395);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.tableLayoutPanel2);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 37);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(934, 355);
            this.panelDados2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panelDados3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelDados4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(934, 355);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panelDados3
            // 
            this.panelDados3.Controls.Add(this.dataGridDefault1);
            this.panelDados3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados3.Location = new System.Drawing.Point(3, 3);
            this.panelDados3.Name = "panelDados3";
            this.panelDados3.NM_ProcDeletar = "";
            this.panelDados3.NM_ProcGravar = "";
            this.panelDados3.Size = new System.Drawing.Size(461, 349);
            this.panelDados3.TabIndex = 0;
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
            this.idauditoriaDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.dteventostrDataGridViewTextBoxColumn,
            this.nmtabelaDataGridViewTextBoxColumn,
            this.tipoeventoDataGridViewTextBoxColumn,
            this.id_chave});
            this.dataGridDefault1.DataSource = this.bsAuditoria;
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
            this.dataGridDefault1.Size = new System.Drawing.Size(461, 349);
            this.dataGridDefault1.TabIndex = 0;
            this.dataGridDefault1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridDefault1_CellFormatting);
            // 
            // bsAuditoria
            // 
            this.bsAuditoria.DataSource = typeof(CamadaDados.Diversos.TList_Auditoria);
            this.bsAuditoria.PositionChanged += new System.EventHandler(this.bsAuditoria_PositionChanged);
            // 
            // panelDados4
            // 
            this.panelDados4.Controls.Add(this.dataGridDefault2);
            this.panelDados4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados4.Location = new System.Drawing.Point(470, 3);
            this.panelDados4.Name = "panelDados4";
            this.panelDados4.NM_ProcDeletar = "";
            this.panelDados4.NM_ProcGravar = "";
            this.panelDados4.Size = new System.Drawing.Size(461, 349);
            this.panelDados4.TabIndex = 1;
            // 
            // dataGridDefault2
            // 
            this.dataGridDefault2.AllowUserToAddRows = false;
            this.dataGridDefault2.AllowUserToDeleteRows = false;
            this.dataGridDefault2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault2.AutoGenerateColumns = false;
            this.dataGridDefault2.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridDefault2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idauditoriaDataGridViewTextBoxColumn1,
            this.idregistroDataGridViewTextBoxColumn,
            this.nmcolunaDataGridViewTextBoxColumn,
            this.vloldDataGridViewTextBoxColumn,
            this.vlatualDataGridViewTextBoxColumn});
            this.dataGridDefault2.DataSource = this.bsColuna;
            this.dataGridDefault2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault2.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault2.Name = "dataGridDefault2";
            this.dataGridDefault2.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault2.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridDefault2.RowHeadersWidth = 23;
            this.dataGridDefault2.Size = new System.Drawing.Size(461, 349);
            this.dataGridDefault2.TabIndex = 0;
            // 
            // idauditoriaDataGridViewTextBoxColumn1
            // 
            this.idauditoriaDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idauditoriaDataGridViewTextBoxColumn1.DataPropertyName = "Id_auditoria";
            this.idauditoriaDataGridViewTextBoxColumn1.HeaderText = "Id_auditoria";
            this.idauditoriaDataGridViewTextBoxColumn1.Name = "idauditoriaDataGridViewTextBoxColumn1";
            this.idauditoriaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idauditoriaDataGridViewTextBoxColumn1.Width = 87;
            // 
            // idregistroDataGridViewTextBoxColumn
            // 
            this.idregistroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idregistroDataGridViewTextBoxColumn.DataPropertyName = "Id_registro";
            this.idregistroDataGridViewTextBoxColumn.HeaderText = "Id_registro";
            this.idregistroDataGridViewTextBoxColumn.Name = "idregistroDataGridViewTextBoxColumn";
            this.idregistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.idregistroDataGridViewTextBoxColumn.Width = 81;
            // 
            // nmcolunaDataGridViewTextBoxColumn
            // 
            this.nmcolunaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcolunaDataGridViewTextBoxColumn.DataPropertyName = "Nm_coluna";
            this.nmcolunaDataGridViewTextBoxColumn.HeaderText = "Nm_coluna";
            this.nmcolunaDataGridViewTextBoxColumn.Name = "nmcolunaDataGridViewTextBoxColumn";
            this.nmcolunaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcolunaDataGridViewTextBoxColumn.Width = 86;
            // 
            // vloldDataGridViewTextBoxColumn
            // 
            this.vloldDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vloldDataGridViewTextBoxColumn.DataPropertyName = "Vl_old";
            this.vloldDataGridViewTextBoxColumn.HeaderText = "Vl_old";
            this.vloldDataGridViewTextBoxColumn.Name = "vloldDataGridViewTextBoxColumn";
            this.vloldDataGridViewTextBoxColumn.ReadOnly = true;
            this.vloldDataGridViewTextBoxColumn.Width = 61;
            // 
            // vlatualDataGridViewTextBoxColumn
            // 
            this.vlatualDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlatualDataGridViewTextBoxColumn.DataPropertyName = "Vl_atual";
            this.vlatualDataGridViewTextBoxColumn.HeaderText = "Vl_atual";
            this.vlatualDataGridViewTextBoxColumn.Name = "vlatualDataGridViewTextBoxColumn";
            this.vlatualDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlatualDataGridViewTextBoxColumn.Width = 70;
            // 
            // bsColuna
            // 
            this.bsColuna.DataSource = typeof(CamadaDados.Diversos.TList_ColunasAudit);
            // 
            // panelDados5
            // 
            this.panelDados5.Controls.Add(this.label4);
            this.panelDados5.Controls.Add(this.eddtfim);
            this.panelDados5.Controls.Add(this.label3);
            this.panelDados5.Controls.Add(this.eddtini);
            this.panelDados5.Controls.Add(this.cbTrigger);
            this.panelDados5.Controls.Add(this.label2);
            this.panelDados5.Controls.Add(this.tabela);
            this.panelDados5.Controls.Add(this.label1);
            this.panelDados5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados5.Location = new System.Drawing.Point(3, 3);
            this.panelDados5.Name = "panelDados5";
            this.panelDados5.NM_ProcDeletar = "";
            this.panelDados5.NM_ProcGravar = "";
            this.panelDados5.Size = new System.Drawing.Size(934, 28);
            this.panelDados5.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 162;
            this.label4.Text = "Dt.Fim";
            // 
            // eddtfim
            // 
            this.eddtfim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eddtfim.Location = new System.Drawing.Point(319, 4);
            this.eddtfim.Mask = "00/00/0000";
            this.eddtfim.Name = "eddtfim";
            this.eddtfim.NM_Alias = "";
            this.eddtfim.NM_Campo = "";
            this.eddtfim.NM_CampoBusca = "";
            this.eddtfim.NM_Param = "";
            this.eddtfim.Operador = "";
            this.eddtfim.Size = new System.Drawing.Size(77, 20);
            this.eddtfim.ST_Gravar = false;
            this.eddtfim.ST_LimpaCampo = true;
            this.eddtfim.ST_NotNull = false;
            this.eddtfim.ST_PrimaryKey = false;
            this.eddtfim.TabIndex = 161;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 160;
            this.label3.Text = "Dt.Ini";
            // 
            // eddtini
            // 
            this.eddtini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eddtini.Location = new System.Drawing.Point(196, 4);
            this.eddtini.Mask = "00/00/0000";
            this.eddtini.Name = "eddtini";
            this.eddtini.NM_Alias = "";
            this.eddtini.NM_Campo = "";
            this.eddtini.NM_CampoBusca = "";
            this.eddtini.NM_Param = "";
            this.eddtini.Operador = "";
            this.eddtini.Size = new System.Drawing.Size(77, 20);
            this.eddtini.ST_Gravar = false;
            this.eddtini.ST_LimpaCampo = true;
            this.eddtini.ST_NotNull = false;
            this.eddtini.ST_PrimaryKey = false;
            this.eddtini.TabIndex = 159;
            this.eddtini.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.editData1_MaskInputRejected);
            // 
            // cbTrigger
            // 
            this.cbTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrigger.FormattingEnabled = true;
            this.cbTrigger.Location = new System.Drawing.Point(470, 4);
            this.cbTrigger.Name = "cbTrigger";
            this.cbTrigger.NM_Alias = "";
            this.cbTrigger.NM_Campo = "";
            this.cbTrigger.NM_Param = "";
            this.cbTrigger.Size = new System.Drawing.Size(171, 21);
            this.cbTrigger.ST_Gravar = false;
            this.cbTrigger.ST_LimparCampo = true;
            this.cbTrigger.ST_NotNull = false;
            this.cbTrigger.TabIndex = 158;
            this.cbTrigger.SelectedIndexChanged += new System.EventHandler(this.cbTrigger_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 157;
            this.label2.Text = "Operação:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tabela
            // 
            this.tabela.BackColor = System.Drawing.SystemColors.Window;
            this.tabela.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tabela.Location = new System.Drawing.Point(52, 4);
            this.tabela.Name = "tabela";
            this.tabela.NM_Alias = "";
            this.tabela.NM_Campo = "";
            this.tabela.NM_CampoBusca = "";
            this.tabela.NM_Param = "";
            this.tabela.QTD_Zero = 0;
            this.tabela.Size = new System.Drawing.Size(100, 20);
            this.tabela.ST_AutoInc = false;
            this.tabela.ST_DisableAuto = false;
            this.tabela.ST_Float = false;
            this.tabela.ST_Gravar = false;
            this.tabela.ST_Int = false;
            this.tabela.ST_LimpaCampo = true;
            this.tabela.ST_NotNull = false;
            this.tabela.ST_PrimaryKey = false;
            this.tabela.TabIndex = 1;
            this.tabela.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabela";
            // 
            // idauditoriaDataGridViewTextBoxColumn
            // 
            this.idauditoriaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idauditoriaDataGridViewTextBoxColumn.DataPropertyName = "Id_auditoria";
            this.idauditoriaDataGridViewTextBoxColumn.HeaderText = "Id.Auditoria";
            this.idauditoriaDataGridViewTextBoxColumn.Name = "idauditoriaDataGridViewTextBoxColumn";
            this.idauditoriaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idauditoriaDataGridViewTextBoxColumn.Width = 85;
            // 
            // loginDataGridViewTextBoxColumn
            // 
            this.loginDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.loginDataGridViewTextBoxColumn.DataPropertyName = "Login";
            this.loginDataGridViewTextBoxColumn.HeaderText = "Login";
            this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
            this.loginDataGridViewTextBoxColumn.ReadOnly = true;
            this.loginDataGridViewTextBoxColumn.Width = 58;
            // 
            // dteventostrDataGridViewTextBoxColumn
            // 
            this.dteventostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dteventostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_eventostr";
            this.dteventostrDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dteventostrDataGridViewTextBoxColumn.Name = "dteventostrDataGridViewTextBoxColumn";
            this.dteventostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dteventostrDataGridViewTextBoxColumn.Width = 55;
            // 
            // nmtabelaDataGridViewTextBoxColumn
            // 
            this.nmtabelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmtabelaDataGridViewTextBoxColumn.DataPropertyName = "Nm_tabela";
            this.nmtabelaDataGridViewTextBoxColumn.HeaderText = "Tabela";
            this.nmtabelaDataGridViewTextBoxColumn.Name = "nmtabelaDataGridViewTextBoxColumn";
            this.nmtabelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmtabelaDataGridViewTextBoxColumn.Width = 65;
            // 
            // tipoeventoDataGridViewTextBoxColumn
            // 
            this.tipoeventoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipoeventoDataGridViewTextBoxColumn.DataPropertyName = "Tipo_evento";
            this.tipoeventoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoeventoDataGridViewTextBoxColumn.Name = "tipoeventoDataGridViewTextBoxColumn";
            this.tipoeventoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoeventoDataGridViewTextBoxColumn.Width = 53;
            // 
            // id_chave
            // 
            this.id_chave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.id_chave.DataPropertyName = "id_chave";
            this.id_chave.HeaderText = "Valor Chave Primaria";
            this.id_chave.Name = "id_chave";
            this.id_chave.ReadOnly = true;
            this.id_chave.Width = 119;
            // 
            // TFAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 438);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFAuditoria";
            this.Text = "Auditoria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFAuditoria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAuditoria_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelDados3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAuditoria)).EndInit();
            this.panelDados4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColuna)).EndInit();
            this.panelDados5.ResumeLayout(false);
            this.panelDados5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Componentes.PanelDados panelDados3;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsAuditoria;
        private Componentes.PanelDados panelDados4;
        private Componentes.DataGridDefault dataGridDefault2;
        private System.Windows.Forms.BindingSource bsColuna;
        private System.Windows.Forms.DataGridViewTextBoxColumn idauditoriaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idregistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcolunaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vloldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlatualDataGridViewTextBoxColumn;
        private Componentes.PanelDados panelDados5;
        private Componentes.EditDefault tabela;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault cbTrigger;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Componentes.EditData eddtfim;
        private System.Windows.Forms.Label label3;
        private Componentes.EditData eddtini;
        private System.Windows.Forms.DataGridViewTextBoxColumn idauditoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dteventostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtabelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoeventoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_chave;
    }
}