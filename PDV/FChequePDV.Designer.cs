namespace PDV
{
    partial class TFChequePDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFChequePDV));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsTitulos = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.cbMarcarTodos = new Componentes.CheckBoxDefault(this.components);
            this.gTitulos = new Componentes.DataGridDefault(this.components);
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.BB_Localizar = new System.Windows.Forms.Button();
            this.nr_cheque = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bnCheques = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.stconciliarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nrchequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtemissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vltituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvenctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomecliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrcgccpfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulos)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTitulos)).BeginInit();
            this.pFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnCheques)).BeginInit();
            this.bnCheques.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(722, 43);
            this.barraMenu.TabIndex = 535;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(100, 40);
            this.BB_Gravar.Text = " (F4)\r\n Confirmar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // bsTitulos
            // 
            this.bsTitulos.DataSource = typeof(CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pFiltro, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(722, 390);
            this.tableLayoutPanel1.TabIndex = 536;
            // 
            // pGrid
            // 
            this.pGrid.AutoScroll = true;
            this.pGrid.BackColor = System.Drawing.SystemColors.Control;
            this.pGrid.Controls.Add(this.cbMarcarTodos);
            this.pGrid.Controls.Add(this.gTitulos);
            this.pGrid.Controls.Add(this.bnCheques);
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid.Location = new System.Drawing.Point(5, 50);
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            this.pGrid.Size = new System.Drawing.Size(712, 335);
            this.pGrid.TabIndex = 0;
            // 
            // cbMarcarTodos
            // 
            this.cbMarcarTodos.AutoSize = true;
            this.cbMarcarTodos.Location = new System.Drawing.Point(6, 12);
            this.cbMarcarTodos.Name = "cbMarcarTodos";
            this.cbMarcarTodos.NM_Alias = "";
            this.cbMarcarTodos.NM_Campo = "";
            this.cbMarcarTodos.NM_Param = "";
            this.cbMarcarTodos.Size = new System.Drawing.Size(15, 14);
            this.cbMarcarTodos.ST_Gravar = false;
            this.cbMarcarTodos.ST_LimparCampo = true;
            this.cbMarcarTodos.ST_NotNull = false;
            this.cbMarcarTodos.TabIndex = 4;
            this.cbMarcarTodos.UseVisualStyleBackColor = true;
            this.cbMarcarTodos.Vl_False = "";
            this.cbMarcarTodos.Vl_True = "";
            this.cbMarcarTodos.Click += new System.EventHandler(this.cbMarcarTodos_Click);
            // 
            // gTitulos
            // 
            this.gTitulos.AllowUserToAddRows = false;
            this.gTitulos.AllowUserToDeleteRows = false;
            this.gTitulos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTitulos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gTitulos.AutoGenerateColumns = false;
            this.gTitulos.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTitulos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTitulos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTitulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gTitulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTitulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stconciliarDataGridViewCheckBoxColumn,
            this.nrchequeDataGridViewTextBoxColumn,
            this.dtemissaoDataGridViewTextBoxColumn,
            this.vltituloDataGridViewTextBoxColumn,
            this.dtvenctoDataGridViewTextBoxColumn,
            this.nomecliforDataGridViewTextBoxColumn,
            this.nrcgccpfDataGridViewTextBoxColumn,
            this.foneDataGridViewTextBoxColumn,
            this.cdbancoDataGridViewTextBoxColumn,
            this.dsbancoDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.observacaoDataGridViewTextBoxColumn});
            this.gTitulos.DataSource = this.bsTitulos;
            this.gTitulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTitulos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTitulos.Location = new System.Drawing.Point(0, 0);
            this.gTitulos.Name = "gTitulos";
            this.gTitulos.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTitulos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gTitulos.RowHeadersWidth = 23;
            this.gTitulos.Size = new System.Drawing.Size(712, 310);
            this.gTitulos.TabIndex = 1;
            this.gTitulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gTitulos_CellClick);
            // 
            // pFiltro
            // 
            this.pFiltro.BackColor = System.Drawing.SystemColors.Control;
            this.pFiltro.Controls.Add(this.BB_Localizar);
            this.pFiltro.Controls.Add(this.nr_cheque);
            this.pFiltro.Controls.Add(this.label3);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(712, 37);
            this.pFiltro.TabIndex = 3;
            // 
            // BB_Localizar
            // 
            this.BB_Localizar.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Localizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BB_Localizar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.BB_Localizar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BB_Localizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(207)))), ((int)(((byte)(169)))));
            this.BB_Localizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BB_Localizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Localizar.ForeColor = System.Drawing.Color.Green;
            this.BB_Localizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Localizar.Location = new System.Drawing.Point(312, 3);
            this.BB_Localizar.Name = "BB_Localizar";
            this.BB_Localizar.Size = new System.Drawing.Size(96, 30);
            this.BB_Localizar.TabIndex = 14;
            this.BB_Localizar.Text = "Localizar (F5)";
            this.BB_Localizar.UseVisualStyleBackColor = false;
            this.BB_Localizar.Click += new System.EventHandler(this.BB_Localizar_Click);
            // 
            // nr_cheque
            // 
            this.nr_cheque.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_cheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cheque.Location = new System.Drawing.Point(139, 8);
            this.nr_cheque.Name = "nr_cheque";
            this.nr_cheque.NM_Alias = "";
            this.nr_cheque.NM_Campo = "";
            this.nr_cheque.NM_CampoBusca = "";
            this.nr_cheque.NM_Param = "";
            this.nr_cheque.QTD_Zero = 0;
            this.nr_cheque.Size = new System.Drawing.Size(167, 20);
            this.nr_cheque.ST_AutoInc = false;
            this.nr_cheque.ST_DisableAuto = false;
            this.nr_cheque.ST_Float = false;
            this.nr_cheque.ST_Gravar = false;
            this.nr_cheque.ST_Int = false;
            this.nr_cheque.ST_LimpaCampo = true;
            this.nr_cheque.ST_NotNull = false;
            this.nr_cheque.ST_PrimaryKey = false;
            this.nr_cheque.TabIndex = 1;
            this.nr_cheque.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Localizar Cheque Nº:";
            // 
            // bnCheques
            // 
            this.bnCheques.AddNewItem = null;
            this.bnCheques.BindingSource = this.bsTitulos;
            this.bnCheques.CountItem = this.bindingNavigatorCountItem;
            this.bnCheques.CountItemFormat = "de {0}";
            this.bnCheques.DeleteItem = null;
            this.bnCheques.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnCheques.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnCheques.Location = new System.Drawing.Point(0, 310);
            this.bnCheques.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnCheques.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnCheques.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnCheques.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnCheques.Name = "bnCheques";
            this.bnCheques.PositionItem = this.bindingNavigatorPositionItem;
            this.bnCheques.Size = new System.Drawing.Size(712, 25);
            this.bnCheques.TabIndex = 2;
            this.bnCheques.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total de Registros";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
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
            // stconciliarDataGridViewCheckBoxColumn
            // 
            this.stconciliarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stconciliarDataGridViewCheckBoxColumn.DataPropertyName = "St_conciliar";
            this.stconciliarDataGridViewCheckBoxColumn.HeaderText = "Processar";
            this.stconciliarDataGridViewCheckBoxColumn.Name = "stconciliarDataGridViewCheckBoxColumn";
            this.stconciliarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stconciliarDataGridViewCheckBoxColumn.Width = 60;
            // 
            // nrchequeDataGridViewTextBoxColumn
            // 
            this.nrchequeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrchequeDataGridViewTextBoxColumn.DataPropertyName = "Nr_cheque";
            this.nrchequeDataGridViewTextBoxColumn.HeaderText = "Nº Cheque";
            this.nrchequeDataGridViewTextBoxColumn.Name = "nrchequeDataGridViewTextBoxColumn";
            this.nrchequeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrchequeDataGridViewTextBoxColumn.Width = 84;
            // 
            // dtemissaoDataGridViewTextBoxColumn
            // 
            this.dtemissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaoDataGridViewTextBoxColumn.DataPropertyName = "Dt_emissao";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dtemissaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtemissaoDataGridViewTextBoxColumn.HeaderText = "Dt. Emissão";
            this.dtemissaoDataGridViewTextBoxColumn.Name = "dtemissaoDataGridViewTextBoxColumn";
            this.dtemissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtemissaoDataGridViewTextBoxColumn.Width = 88;
            // 
            // vltituloDataGridViewTextBoxColumn
            // 
            this.vltituloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vltituloDataGridViewTextBoxColumn.DataPropertyName = "Vl_titulo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vltituloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.vltituloDataGridViewTextBoxColumn.HeaderText = "Vl. Titulo";
            this.vltituloDataGridViewTextBoxColumn.Name = "vltituloDataGridViewTextBoxColumn";
            this.vltituloDataGridViewTextBoxColumn.ReadOnly = true;
            this.vltituloDataGridViewTextBoxColumn.Width = 73;
            // 
            // dtvenctoDataGridViewTextBoxColumn
            // 
            this.dtvenctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvenctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_vencto";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.dtvenctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtvenctoDataGridViewTextBoxColumn.HeaderText = "Dt. Vencimento";
            this.dtvenctoDataGridViewTextBoxColumn.Name = "dtvenctoDataGridViewTextBoxColumn";
            this.dtvenctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtvenctoDataGridViewTextBoxColumn.Width = 97;
            // 
            // nomecliforDataGridViewTextBoxColumn
            // 
            this.nomecliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nomecliforDataGridViewTextBoxColumn.DataPropertyName = "Nomeclifor";
            this.nomecliforDataGridViewTextBoxColumn.HeaderText = "Emitente";
            this.nomecliforDataGridViewTextBoxColumn.Name = "nomecliforDataGridViewTextBoxColumn";
            this.nomecliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomecliforDataGridViewTextBoxColumn.Width = 73;
            // 
            // nrcgccpfDataGridViewTextBoxColumn
            // 
            this.nrcgccpfDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrcgccpfDataGridViewTextBoxColumn.DataPropertyName = "Nr_cgccpf";
            this.nrcgccpfDataGridViewTextBoxColumn.HeaderText = "CNPJ/CPF";
            this.nrcgccpfDataGridViewTextBoxColumn.Name = "nrcgccpfDataGridViewTextBoxColumn";
            this.nrcgccpfDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrcgccpfDataGridViewTextBoxColumn.Width = 84;
            // 
            // foneDataGridViewTextBoxColumn
            // 
            this.foneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.foneDataGridViewTextBoxColumn.DataPropertyName = "Fone";
            this.foneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            this.foneDataGridViewTextBoxColumn.Name = "foneDataGridViewTextBoxColumn";
            this.foneDataGridViewTextBoxColumn.ReadOnly = true;
            this.foneDataGridViewTextBoxColumn.Width = 74;
            // 
            // cdbancoDataGridViewTextBoxColumn
            // 
            this.cdbancoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdbancoDataGridViewTextBoxColumn.DataPropertyName = "Cd_banco";
            this.cdbancoDataGridViewTextBoxColumn.HeaderText = "Cd. Banco";
            this.cdbancoDataGridViewTextBoxColumn.Name = "cdbancoDataGridViewTextBoxColumn";
            this.cdbancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdbancoDataGridViewTextBoxColumn.Width = 76;
            // 
            // dsbancoDataGridViewTextBoxColumn
            // 
            this.dsbancoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsbancoDataGridViewTextBoxColumn.DataPropertyName = "Ds_banco";
            this.dsbancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.dsbancoDataGridViewTextBoxColumn.Name = "dsbancoDataGridViewTextBoxColumn";
            this.dsbancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsbancoDataGridViewTextBoxColumn.Width = 63;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 85;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            this.nmempresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmempresaDataGridViewTextBoxColumn.Width = 73;
            // 
            // observacaoDataGridViewTextBoxColumn
            // 
            this.observacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.observacaoDataGridViewTextBoxColumn.DataPropertyName = "Observacao";
            this.observacaoDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.observacaoDataGridViewTextBoxColumn.Name = "observacaoDataGridViewTextBoxColumn";
            this.observacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.observacaoDataGridViewTextBoxColumn.Width = 90;
            // 
            // TFChequePDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 433);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFChequePDV";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheques Caixa Operacional";
            this.Load += new System.EventHandler(this.TFChequePDV_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFChequePDV_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFChequePDV_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulos)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTitulos)).EndInit();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnCheques)).EndInit();
            this.bnCheques.ResumeLayout(false);
            this.bnCheques.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        public System.Windows.Forms.BindingSource bsTitulos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados pGrid;
        private Componentes.DataGridDefault gTitulos;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.Button BB_Localizar;
        private Componentes.EditDefault nr_cheque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingNavigator bnCheques;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.CheckBoxDefault cbMarcarTodos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stconciliarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrchequeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtemissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vltituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvenctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomecliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcgccpfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacaoDataGridViewTextBoxColumn;
    }
}