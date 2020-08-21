namespace Financeiro
{
    partial class TFRateioCentro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRateioCentro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.tlpRateio = new System.Windows.Forms.TableLayoutPanel();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bsCResultado = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.dscentroresultadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vllanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados = new Componentes.PanelDados(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.vl_documento = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pc_total = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vl_total = new Componentes.EditFloat(this.components);
            this.vl_saldovalor = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.vl_rateiocc = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pc_rateiocc = new Componentes.EditFloat(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpRateio.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            this.pDados.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldovalor)).BeginInit();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_rateiocc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_rateiocc)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(713, 43);
            this.barraMenu.TabIndex = 7;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Duplicata";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // tlpRateio
            // 
            this.tlpRateio.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpRateio.ColumnCount = 1;
            this.tlpRateio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRateio.Controls.Add(this.pGrid, 0, 1);
            this.tlpRateio.Controls.Add(this.pDados, 0, 0);
            this.tlpRateio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRateio.Location = new System.Drawing.Point(0, 43);
            this.tlpRateio.Name = "tlpRateio";
            this.tlpRateio.RowCount = 2;
            this.tlpRateio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tlpRateio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRateio.Size = new System.Drawing.Size(713, 388);
            this.tlpRateio.TabIndex = 8;
            // 
            // pGrid
            // 
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pGrid.Controls.Add(this.dataGridDefault1);
            this.pGrid.Controls.Add(this.bindingNavigator1);
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid.Location = new System.Drawing.Point(5, 109);
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            this.pGrid.Size = new System.Drawing.Size(703, 274);
            this.pGrid.TabIndex = 1;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 245);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(699, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bsCResultado
            // 
            this.bsCResultado.DataSource = typeof(CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto);
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
            this.dscentroresultadoDataGridViewTextBoxColumn,
            this.vllanctoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsCResultado;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(699, 245);
            this.dataGridDefault1.TabIndex = 2;
            // 
            // dscentroresultadoDataGridViewTextBoxColumn
            // 
            this.dscentroresultadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscentroresultadoDataGridViewTextBoxColumn.DataPropertyName = "Ds_centroresultado";
            this.dscentroresultadoDataGridViewTextBoxColumn.HeaderText = "Centro Resultado";
            this.dscentroresultadoDataGridViewTextBoxColumn.Name = "dscentroresultadoDataGridViewTextBoxColumn";
            this.dscentroresultadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscentroresultadoDataGridViewTextBoxColumn.Width = 105;
            // 
            // vllanctoDataGridViewTextBoxColumn
            // 
            this.vllanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vllanctoDataGridViewTextBoxColumn.DataPropertyName = "Vl_lancto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.vllanctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.vllanctoDataGridViewTextBoxColumn.HeaderText = "Vl. Rateio";
            this.vllanctoDataGridViewTextBoxColumn.Name = "vllanctoDataGridViewTextBoxColumn";
            this.vllanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vllanctoDataGridViewTextBoxColumn.Width = 72;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.panelDados1);
            this.pDados.Controls.Add(this.panelDados2);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 5);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(703, 96);
            this.pDados.TabIndex = 2;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.Transparent;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.vl_documento);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.pc_total);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.vl_total);
            this.panelDados1.Controls.Add(this.vl_saldovalor);
            this.panelDados1.Controls.Add(this.label8);
            this.panelDados1.Location = new System.Drawing.Point(12, 45);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(477, 49);
            this.panelDados1.TabIndex = 7;
            // 
            // vl_documento
            // 
            this.vl_documento.DecimalPlaces = 2;
            this.vl_documento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.vl_documento.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_documento.Location = new System.Drawing.Point(6, 18);
            this.vl_documento.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_documento.Name = "vl_documento";
            this.vl_documento.NM_Alias = "";
            this.vl_documento.NM_Campo = "";
            this.vl_documento.NM_Param = "";
            this.vl_documento.Operador = "";
            this.vl_documento.ReadOnly = true;
            this.vl_documento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_documento.Size = new System.Drawing.Size(97, 23);
            this.vl_documento.ST_AutoInc = false;
            this.vl_documento.ST_DisableAuto = false;
            this.vl_documento.ST_Gravar = false;
            this.vl_documento.ST_LimparCampo = true;
            this.vl_documento.ST_NotNull = false;
            this.vl_documento.ST_PrimaryKey = false;
            this.vl_documento.TabIndex = 40;
            this.vl_documento.TabStop = false;
            this.vl_documento.ThousandsSeparator = true;
            this.vl_documento.ValueChanged += new System.EventHandler(this.vl_documento_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Vl. Documento";
            // 
            // pc_total
            // 
            this.pc_total.DecimalPlaces = 2;
            this.pc_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pc_total.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pc_total.Location = new System.Drawing.Point(315, 18);
            this.pc_total.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_total.Name = "pc_total";
            this.pc_total.NM_Alias = "";
            this.pc_total.NM_Campo = "";
            this.pc_total.NM_Param = "";
            this.pc_total.Operador = "";
            this.pc_total.ReadOnly = true;
            this.pc_total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pc_total.Size = new System.Drawing.Size(97, 23);
            this.pc_total.ST_AutoInc = false;
            this.pc_total.ST_DisableAuto = false;
            this.pc_total.ST_Gravar = false;
            this.pc_total.ST_LimparCampo = true;
            this.pc_total.ST_NotNull = false;
            this.pc_total.ST_PrimaryKey = false;
            this.pc_total.TabIndex = 46;
            this.pc_total.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(106, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Total Rateio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(312, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Total % Rateio";
            // 
            // vl_total
            // 
            this.vl_total.DecimalPlaces = 2;
            this.vl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.vl_total.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_total.Location = new System.Drawing.Point(109, 18);
            this.vl_total.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_total.Name = "vl_total";
            this.vl_total.NM_Alias = "";
            this.vl_total.NM_Campo = "";
            this.vl_total.NM_Param = "";
            this.vl_total.Operador = "";
            this.vl_total.ReadOnly = true;
            this.vl_total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_total.Size = new System.Drawing.Size(97, 23);
            this.vl_total.ST_AutoInc = false;
            this.vl_total.ST_DisableAuto = false;
            this.vl_total.ST_Gravar = false;
            this.vl_total.ST_LimparCampo = true;
            this.vl_total.ST_NotNull = false;
            this.vl_total.ST_PrimaryKey = false;
            this.vl_total.TabIndex = 42;
            this.vl_total.TabStop = false;
            this.vl_total.ThousandsSeparator = true;
            this.vl_total.ValueChanged += new System.EventHandler(this.vl_total_ValueChanged);
            // 
            // vl_saldovalor
            // 
            this.vl_saldovalor.DecimalPlaces = 2;
            this.vl_saldovalor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.vl_saldovalor.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_saldovalor.Location = new System.Drawing.Point(212, 18);
            this.vl_saldovalor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_saldovalor.Name = "vl_saldovalor";
            this.vl_saldovalor.NM_Alias = "";
            this.vl_saldovalor.NM_Campo = "";
            this.vl_saldovalor.NM_Param = "";
            this.vl_saldovalor.Operador = "";
            this.vl_saldovalor.ReadOnly = true;
            this.vl_saldovalor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_saldovalor.Size = new System.Drawing.Size(97, 23);
            this.vl_saldovalor.ST_AutoInc = false;
            this.vl_saldovalor.ST_DisableAuto = false;
            this.vl_saldovalor.ST_Gravar = false;
            this.vl_saldovalor.ST_LimparCampo = true;
            this.vl_saldovalor.ST_NotNull = false;
            this.vl_saldovalor.ST_PrimaryKey = false;
            this.vl_saldovalor.TabIndex = 44;
            this.vl_saldovalor.TabStop = false;
            this.vl_saldovalor.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(209, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Saldo Ratear";
            // 
            // panelDados2
            // 
            this.panelDados2.BackColor = System.Drawing.Color.Transparent;
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(this.label1);
            this.panelDados2.Controls.Add(this.vl_rateiocc);
            this.panelDados2.Controls.Add(this.label2);
            this.panelDados2.Controls.Add(this.pc_rateiocc);
            this.panelDados2.Location = new System.Drawing.Point(12, 6);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(477, 33);
            this.panelDados2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vl. Rateio:";
            // 
            // vl_rateiocc
            // 
            this.vl_rateiocc.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCResultado, "Vl_lancto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_rateiocc.DecimalPlaces = 2;
            this.vl_rateiocc.Enabled = false;
            this.vl_rateiocc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.vl_rateiocc.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_rateiocc.Location = new System.Drawing.Point(77, 3);
            this.vl_rateiocc.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_rateiocc.Name = "vl_rateiocc";
            this.vl_rateiocc.NM_Alias = "";
            this.vl_rateiocc.NM_Campo = "";
            this.vl_rateiocc.NM_Param = "";
            this.vl_rateiocc.Operador = "";
            this.vl_rateiocc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_rateiocc.Size = new System.Drawing.Size(103, 23);
            this.vl_rateiocc.ST_AutoInc = false;
            this.vl_rateiocc.ST_DisableAuto = false;
            this.vl_rateiocc.ST_Gravar = false;
            this.vl_rateiocc.ST_LimparCampo = true;
            this.vl_rateiocc.ST_NotNull = false;
            this.vl_rateiocc.ST_PrimaryKey = false;
            this.vl_rateiocc.TabIndex = 0;
            this.vl_rateiocc.ThousandsSeparator = true;
            this.vl_rateiocc.Leave += new System.EventHandler(this.vl_rateiocc_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(186, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "% Rateio:";
            // 
            // pc_rateiocc
            // 
            this.pc_rateiocc.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCResultado, "Pc_lancto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_rateiocc.DecimalPlaces = 2;
            this.pc_rateiocc.Enabled = false;
            this.pc_rateiocc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pc_rateiocc.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pc_rateiocc.Location = new System.Drawing.Point(253, 3);
            this.pc_rateiocc.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_rateiocc.Name = "pc_rateiocc";
            this.pc_rateiocc.NM_Alias = "";
            this.pc_rateiocc.NM_Campo = "";
            this.pc_rateiocc.NM_Param = "";
            this.pc_rateiocc.Operador = "";
            this.pc_rateiocc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pc_rateiocc.Size = new System.Drawing.Size(73, 23);
            this.pc_rateiocc.ST_AutoInc = false;
            this.pc_rateiocc.ST_DisableAuto = false;
            this.pc_rateiocc.ST_Gravar = false;
            this.pc_rateiocc.ST_LimparCampo = true;
            this.pc_rateiocc.ST_NotNull = false;
            this.pc_rateiocc.ST_PrimaryKey = false;
            this.pc_rateiocc.TabIndex = 1;
            this.pc_rateiocc.ThousandsSeparator = true;
            this.pc_rateiocc.Leave += new System.EventHandler(this.pc_rateiocc_Leave);
            // 
            // TFRateioCentro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 431);
            this.Controls.Add(this.tlpRateio);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFRateioCentro";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rateio Centro Resultado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFRateioCentro_FormClosing);
            this.Load += new System.EventHandler(this.TFRateioCentro_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRateioCentro_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpRateio.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            this.pDados.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldovalor)).EndInit();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_rateiocc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_rateiocc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.TableLayoutPanel tlpRateio;
        private Componentes.PanelDados pGrid;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.BindingSource bsCResultado;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscentroresultadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vllanctoDataGridViewTextBoxColumn;
        private Componentes.PanelDados pDados;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditFloat vl_documento;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat pc_total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat vl_total;
        private Componentes.EditFloat vl_saldovalor;
        private System.Windows.Forms.Label label8;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat vl_rateiocc;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat pc_rateiocc;
    }
}