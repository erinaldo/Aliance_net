namespace Financeiro
{
    partial class TFSaldoCreditos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFSaldoCreditos));
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label6;
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gSaldoAdto = new Componentes.DataGridDefault(this.components);
            this.stprocessarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nm_clifor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vLtotalquitadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vltotaldevolverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlprocessarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dt_adto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAdto = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_confirmar = new System.Windows.Forms.Button();
            this.saldo_financeiro = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vl_devolver = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.vl_financeiro = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.panelDados3 = new Componentes.PanelDados(this.components);
            this.DT_Final = new Componentes.EditData(this.components);
            this.DT_Inicial = new Componentes.EditData(this.components);
            this.bb_buscar = new System.Windows.Forms.Button();
            this.BB_Clifor = new System.Windows.Forms.Button();
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.label42 = new System.Windows.Forms.Label();
            this.id_adto = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.tlpCentral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gSaldoAdto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAdto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saldo_financeiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_devolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_financeiro)).BeginInit();
            this.pFiltro.SuspendLayout();
            this.panelDados3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 2;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 0);
            this.tlpCentral.Controls.Add(this.pDados, 1, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(5, 72);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(880, 405);
            this.tlpCentral.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tlpCentral, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pFiltro, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(890, 482);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.gSaldoAdto);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 5);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(698, 395);
            this.panelDados1.TabIndex = 0;
            // 
            // gSaldoAdto
            // 
            this.gSaldoAdto.AllowUserToAddRows = false;
            this.gSaldoAdto.AllowUserToDeleteRows = false;
            this.gSaldoAdto.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gSaldoAdto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gSaldoAdto.AutoGenerateColumns = false;
            this.gSaldoAdto.BackgroundColor = System.Drawing.Color.LightGray;
            this.gSaldoAdto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gSaldoAdto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gSaldoAdto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gSaldoAdto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gSaldoAdto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stprocessarDataGridViewCheckBoxColumn,
            this.Column1,
            this.Nm_clifor,
            this.vLtotalquitadoDataGridViewTextBoxColumn,
            this.vltotaldevolverDataGridViewTextBoxColumn,
            this.vlprocessarDataGridViewTextBoxColumn,
            this.Dt_adto});
            this.gSaldoAdto.DataSource = this.bsAdto;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gSaldoAdto.DefaultCellStyle = dataGridViewCellStyle7;
            this.gSaldoAdto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gSaldoAdto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gSaldoAdto.Location = new System.Drawing.Point(0, 0);
            this.gSaldoAdto.Name = "gSaldoAdto";
            this.gSaldoAdto.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gSaldoAdto.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gSaldoAdto.RowHeadersWidth = 23;
            this.gSaldoAdto.Size = new System.Drawing.Size(694, 366);
            this.gSaldoAdto.TabIndex = 0;
            this.gSaldoAdto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gSaldoAdto_CellClick);
            this.gSaldoAdto.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gSaldoAdto_ColumnHeaderMouseClick);
            // 
            // stprocessarDataGridViewCheckBoxColumn
            // 
            this.stprocessarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stprocessarDataGridViewCheckBoxColumn.DataPropertyName = "St_processar";
            this.stprocessarDataGridViewCheckBoxColumn.HeaderText = "Devolver";
            this.stprocessarDataGridViewCheckBoxColumn.Name = "stprocessarDataGridViewCheckBoxColumn";
            this.stprocessarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stprocessarDataGridViewCheckBoxColumn.Width = 56;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.DataPropertyName = "Id_adto";
            this.Column1.HeaderText = "Nº Crédito";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 74;
            // 
            // Nm_clifor
            // 
            this.Nm_clifor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nm_clifor.DataPropertyName = "Nm_clifor";
            this.Nm_clifor.HeaderText = "Cliente/Fornecedor";
            this.Nm_clifor.Name = "Nm_clifor";
            this.Nm_clifor.ReadOnly = true;
            this.Nm_clifor.Width = 123;
            // 
            // vLtotalquitadoDataGridViewTextBoxColumn
            // 
            this.vLtotalquitadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vLtotalquitadoDataGridViewTextBoxColumn.DataPropertyName = "VL_total_quitado";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.vLtotalquitadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.vLtotalquitadoDataGridViewTextBoxColumn.HeaderText = "Vl. Crédito";
            this.vLtotalquitadoDataGridViewTextBoxColumn.Name = "vLtotalquitadoDataGridViewTextBoxColumn";
            this.vLtotalquitadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vLtotalquitadoDataGridViewTextBoxColumn.Width = 74;
            // 
            // vltotaldevolverDataGridViewTextBoxColumn
            // 
            this.vltotaldevolverDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vltotaldevolverDataGridViewTextBoxColumn.DataPropertyName = "Vl_total_devolver";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vltotaldevolverDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.vltotaldevolverDataGridViewTextBoxColumn.HeaderText = "Saldo Devolver";
            this.vltotaldevolverDataGridViewTextBoxColumn.Name = "vltotaldevolverDataGridViewTextBoxColumn";
            this.vltotaldevolverDataGridViewTextBoxColumn.ReadOnly = true;
            this.vltotaldevolverDataGridViewTextBoxColumn.Width = 96;
            // 
            // vlprocessarDataGridViewTextBoxColumn
            // 
            this.vlprocessarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlprocessarDataGridViewTextBoxColumn.DataPropertyName = "Vl_processar";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.vlprocessarDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.vlprocessarDataGridViewTextBoxColumn.HeaderText = "Vl. Devolver";
            this.vlprocessarDataGridViewTextBoxColumn.Name = "vlprocessarDataGridViewTextBoxColumn";
            this.vlprocessarDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlprocessarDataGridViewTextBoxColumn.Width = 83;
            // 
            // Dt_adto
            // 
            this.Dt_adto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dt_adto.DataPropertyName = "Dt_lancto";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.Dt_adto.DefaultCellStyle = dataGridViewCellStyle6;
            this.Dt_adto.HeaderText = "Dt. Adto";
            this.Dt_adto.Name = "Dt_adto";
            this.Dt_adto.ReadOnly = true;
            this.Dt_adto.Width = 66;
            // 
            // bsAdto
            // 
            this.bsAdto.DataSource = typeof(CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento);
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
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 366);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(694, 25);
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.bb_confirmar);
            this.pDados.Controls.Add(this.saldo_financeiro);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.vl_devolver);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.vl_financeiro);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(711, 5);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(164, 395);
            this.pDados.TabIndex = 1;
            // 
            // bb_confirmar
            // 
            this.bb_confirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_confirmar.ForeColor = System.Drawing.Color.Green;
            this.bb_confirmar.Image = ((System.Drawing.Image)(resources.GetObject("bb_confirmar.Image")));
            this.bb_confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_confirmar.Location = new System.Drawing.Point(8, 162);
            this.bb_confirmar.Name = "bb_confirmar";
            this.bb_confirmar.Size = new System.Drawing.Size(134, 46);
            this.bb_confirmar.TabIndex = 110;
            this.bb_confirmar.Text = "(F4)\r\nConfirmar";
            this.bb_confirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_confirmar.UseVisualStyleBackColor = true;
            this.bb_confirmar.Click += new System.EventHandler(this.bb_confirmar_Click);
            // 
            // saldo_financeiro
            // 
            this.saldo_financeiro.DecimalPlaces = 2;
            this.saldo_financeiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saldo_financeiro.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.saldo_financeiro.Location = new System.Drawing.Point(8, 127);
            this.saldo_financeiro.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.saldo_financeiro.Name = "saldo_financeiro";
            this.saldo_financeiro.NM_Alias = "";
            this.saldo_financeiro.NM_Campo = "";
            this.saldo_financeiro.NM_Param = "";
            this.saldo_financeiro.Operador = "";
            this.saldo_financeiro.ReadOnly = true;
            this.saldo_financeiro.Size = new System.Drawing.Size(134, 29);
            this.saldo_financeiro.ST_AutoInc = false;
            this.saldo_financeiro.ST_DisableAuto = false;
            this.saldo_financeiro.ST_Gravar = false;
            this.saldo_financeiro.ST_LimparCampo = true;
            this.saldo_financeiro.ST_NotNull = false;
            this.saldo_financeiro.ST_PrimaryKey = false;
            this.saldo_financeiro.TabIndex = 5;
            this.saldo_financeiro.TabStop = false;
            this.saldo_financeiro.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Saldo Financeiro";
            // 
            // vl_devolver
            // 
            this.vl_devolver.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAdto, "Vl_processar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_devolver.DecimalPlaces = 2;
            this.vl_devolver.Enabled = false;
            this.vl_devolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_devolver.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_devolver.Location = new System.Drawing.Point(8, 76);
            this.vl_devolver.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_devolver.Name = "vl_devolver";
            this.vl_devolver.NM_Alias = "";
            this.vl_devolver.NM_Campo = "";
            this.vl_devolver.NM_Param = "";
            this.vl_devolver.Operador = "";
            this.vl_devolver.Size = new System.Drawing.Size(134, 29);
            this.vl_devolver.ST_AutoInc = false;
            this.vl_devolver.ST_DisableAuto = false;
            this.vl_devolver.ST_Gravar = false;
            this.vl_devolver.ST_LimparCampo = true;
            this.vl_devolver.ST_NotNull = false;
            this.vl_devolver.ST_PrimaryKey = false;
            this.vl_devolver.TabIndex = 3;
            this.vl_devolver.ThousandsSeparator = true;
            this.vl_devolver.Leave += new System.EventHandler(this.vl_devolver_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vl. Devolver";
            // 
            // vl_financeiro
            // 
            this.vl_financeiro.DecimalPlaces = 2;
            this.vl_financeiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_financeiro.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_financeiro.Location = new System.Drawing.Point(8, 25);
            this.vl_financeiro.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_financeiro.Name = "vl_financeiro";
            this.vl_financeiro.NM_Alias = "";
            this.vl_financeiro.NM_Campo = "";
            this.vl_financeiro.NM_Param = "";
            this.vl_financeiro.Operador = "";
            this.vl_financeiro.ReadOnly = true;
            this.vl_financeiro.Size = new System.Drawing.Size(134, 29);
            this.vl_financeiro.ST_AutoInc = false;
            this.vl_financeiro.ST_DisableAuto = false;
            this.vl_financeiro.ST_Gravar = false;
            this.vl_financeiro.ST_LimparCampo = true;
            this.vl_financeiro.ST_NotNull = false;
            this.vl_financeiro.ST_PrimaryKey = false;
            this.vl_financeiro.TabIndex = 1;
            this.vl_financeiro.TabStop = false;
            this.vl_financeiro.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vl. Financeiro";
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.panelDados3);
            this.pFiltro.Controls.Add(this.bb_buscar);
            this.pFiltro.Controls.Add(this.BB_Clifor);
            this.pFiltro.Controls.Add(this.CD_Clifor);
            this.pFiltro.Controls.Add(this.label42);
            this.pFiltro.Controls.Add(this.id_adto);
            this.pFiltro.Controls.Add(this.label4);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(880, 59);
            this.pFiltro.TabIndex = 10;
            // 
            // panelDados3
            // 
            this.panelDados3.BackColor = System.Drawing.SystemColors.Control;
            this.panelDados3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados3.Controls.Add(this.DT_Final);
            this.panelDados3.Controls.Add(label8);
            this.panelDados3.Controls.Add(this.DT_Inicial);
            this.panelDados3.Controls.Add(label6);
            this.panelDados3.Location = new System.Drawing.Point(192, 2);
            this.panelDados3.Name = "panelDados3";
            this.panelDados3.NM_ProcDeletar = "";
            this.panelDados3.NM_ProcGravar = "";
            this.panelDados3.Size = new System.Drawing.Size(141, 51);
            this.panelDados3.TabIndex = 110;
            // 
            // DT_Final
            // 
            this.DT_Final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Final.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DT_Final.Location = new System.Drawing.Point(60, 25);
            this.DT_Final.Mask = "00/00/0000";
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.NM_Alias = "";
            this.DT_Final.NM_Campo = "";
            this.DT_Final.NM_CampoBusca = "";
            this.DT_Final.NM_Param = "";
            this.DT_Final.Operador = "";
            this.DT_Final.Size = new System.Drawing.Size(67, 20);
            this.DT_Final.ST_Gravar = true;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = true;
            this.DT_Final.ST_PrimaryKey = false;
            this.DT_Final.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(1, 28);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(53, 13);
            label8.TabIndex = 79;
            label8.Text = "Dt. Fin.:";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DT_Inicial
            // 
            this.DT_Inicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(137)))));
            this.DT_Inicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DT_Inicial.Location = new System.Drawing.Point(59, 3);
            this.DT_Inicial.Mask = "00/00/0000";
            this.DT_Inicial.Name = "DT_Inicial";
            this.DT_Inicial.NM_Alias = "";
            this.DT_Inicial.NM_Campo = "";
            this.DT_Inicial.NM_CampoBusca = "";
            this.DT_Inicial.NM_Param = "";
            this.DT_Inicial.Operador = "";
            this.DT_Inicial.Size = new System.Drawing.Size(68, 20);
            this.DT_Inicial.ST_Gravar = true;
            this.DT_Inicial.ST_LimpaCampo = true;
            this.DT_Inicial.ST_NotNull = true;
            this.DT_Inicial.ST_PrimaryKey = false;
            this.DT_Inicial.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(3, 6);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(50, 13);
            label6.TabIndex = 77;
            label6.Text = "Dt. Ini.:";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_buscar
            // 
            this.bb_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_buscar.ForeColor = System.Drawing.Color.Green;
            this.bb_buscar.Image = ((System.Drawing.Image)(resources.GetObject("bb_buscar.Image")));
            this.bb_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_buscar.Location = new System.Drawing.Point(339, 5);
            this.bb_buscar.Name = "bb_buscar";
            this.bb_buscar.Size = new System.Drawing.Size(90, 46);
            this.bb_buscar.TabIndex = 109;
            this.bb_buscar.Text = "(F7)\r\nBuscar";
            this.bb_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_buscar.UseVisualStyleBackColor = true;
            this.bb_buscar.Click += new System.EventHandler(this.bb_buscar_Click);
            // 
            // BB_Clifor
            // 
            this.BB_Clifor.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Clifor.Image = ((System.Drawing.Image)(resources.GetObject("BB_Clifor.Image")));
            this.BB_Clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Clifor.Location = new System.Drawing.Point(158, 29);
            this.BB_Clifor.Name = "BB_Clifor";
            this.BB_Clifor.Size = new System.Drawing.Size(28, 20);
            this.BB_Clifor.TabIndex = 107;
            this.BB_Clifor.UseVisualStyleBackColor = false;
            this.BB_Clifor.Click += new System.EventHandler(this.BB_Clifor_Click);
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Clifor.Location = new System.Drawing.Point(81, 29);
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.Size = new System.Drawing.Size(76, 20);
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = true;
            this.CD_Clifor.ST_Int = true;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = false;
            this.CD_Clifor.ST_PrimaryKey = false;
            this.CD_Clifor.TabIndex = 106;
            this.CD_Clifor.TextOld = null;
            this.CD_Clifor.Leave += new System.EventHandler(this.CD_Clifor_Leave);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(25, 32);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(50, 13);
            this.label42.TabIndex = 108;
            this.label42.Text = "Cliente:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // id_adto
            // 
            this.id_adto.BackColor = System.Drawing.SystemColors.Window;
            this.id_adto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_adto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_adto.Location = new System.Drawing.Point(81, 3);
            this.id_adto.Name = "id_adto";
            this.id_adto.NM_Alias = "";
            this.id_adto.NM_Campo = "";
            this.id_adto.NM_CampoBusca = "";
            this.id_adto.NM_Param = "";
            this.id_adto.QTD_Zero = 0;
            this.id_adto.Size = new System.Drawing.Size(105, 20);
            this.id_adto.ST_AutoInc = false;
            this.id_adto.ST_DisableAuto = false;
            this.id_adto.ST_Float = false;
            this.id_adto.ST_Gravar = true;
            this.id_adto.ST_Int = true;
            this.id_adto.ST_LimpaCampo = true;
            this.id_adto.ST_NotNull = false;
            this.id_adto.ST_PrimaryKey = false;
            this.id_adto.TabIndex = 1;
            this.id_adto.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nº Crédito:";
            // 
            // TFSaldoCreditos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 482);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFSaldoCreditos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creditos a Devolver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFSaldoCreditos_FormClosing);
            this.Load += new System.EventHandler(this.TFSaldoCreditos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFSaldoCreditos_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gSaldoAdto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAdto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saldo_financeiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_devolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_financeiro)).EndInit();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.panelDados3.ResumeLayout(false);
            this.panelDados3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gSaldoAdto;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.PanelDados pDados;
        private Componentes.EditFloat vl_devolver;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat vl_financeiro;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat saldo_financeiro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados pFiltro;
        private Componentes.EditDefault id_adto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_buscar;
        private System.Windows.Forms.Button BB_Clifor;
        private Componentes.EditDefault CD_Clifor;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button bb_confirmar;
        private Componentes.PanelDados panelDados3;
        private Componentes.EditData DT_Final;
        private Componentes.EditData DT_Inicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn vladiantamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vldevolverDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsAdto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nm_clifor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vLtotalquitadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vltotaldevolverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlprocessarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_adto;
    }
}