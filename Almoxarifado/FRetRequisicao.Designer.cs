namespace Almoxarifado
{
    partial class TFRetRequisicao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRetRequisicao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gSaldoAlmox = new Componentes.DataGridDefault(this.components);
            this.idalmoxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsalmoxarifadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaunidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsSaldoAlmox = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pDados = new Componentes.PanelDados(this.components);
            this.qtd_retirar = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.saldo_retirar = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.saldo_almox = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gSaldoAlmox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSaldoAlmox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_retirar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saldo_retirar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saldo_almox)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(726, 43);
            this.barraMenu.TabIndex = 13;
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
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 0);
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlpCentral.Size = new System.Drawing.Size(726, 334);
            this.tlpCentral.TabIndex = 14;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.gSaldoAlmox);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 5);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(716, 261);
            this.panelDados1.TabIndex = 0;
            // 
            // gSaldoAlmox
            // 
            this.gSaldoAlmox.AllowUserToAddRows = false;
            this.gSaldoAlmox.AllowUserToDeleteRows = false;
            this.gSaldoAlmox.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gSaldoAlmox.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gSaldoAlmox.AutoGenerateColumns = false;
            this.gSaldoAlmox.BackgroundColor = System.Drawing.Color.LightGray;
            this.gSaldoAlmox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gSaldoAlmox.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gSaldoAlmox.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gSaldoAlmox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gSaldoAlmox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idalmoxDataGridViewTextBoxColumn,
            this.dsalmoxarifadoDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.saldoDataGridViewTextBoxColumn,
            this.siglaunidadeDataGridViewTextBoxColumn});
            this.gSaldoAlmox.DataSource = this.bsSaldoAlmox;
            this.gSaldoAlmox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gSaldoAlmox.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gSaldoAlmox.Location = new System.Drawing.Point(0, 20);
            this.gSaldoAlmox.Name = "gSaldoAlmox";
            this.gSaldoAlmox.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gSaldoAlmox.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gSaldoAlmox.RowHeadersWidth = 23;
            this.gSaldoAlmox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gSaldoAlmox.Size = new System.Drawing.Size(712, 212);
            this.gSaldoAlmox.TabIndex = 7;
            // 
            // idalmoxDataGridViewTextBoxColumn
            // 
            this.idalmoxDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idalmoxDataGridViewTextBoxColumn.DataPropertyName = "Id_almox";
            this.idalmoxDataGridViewTextBoxColumn.HeaderText = "Id. Almox.";
            this.idalmoxDataGridViewTextBoxColumn.Name = "idalmoxDataGridViewTextBoxColumn";
            this.idalmoxDataGridViewTextBoxColumn.ReadOnly = true;
            this.idalmoxDataGridViewTextBoxColumn.Width = 78;
            // 
            // dsalmoxarifadoDataGridViewTextBoxColumn
            // 
            this.dsalmoxarifadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsalmoxarifadoDataGridViewTextBoxColumn.DataPropertyName = "Ds_almoxarifado";
            this.dsalmoxarifadoDataGridViewTextBoxColumn.HeaderText = "Almoxarifado";
            this.dsalmoxarifadoDataGridViewTextBoxColumn.Name = "dsalmoxarifadoDataGridViewTextBoxColumn";
            this.dsalmoxarifadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsalmoxarifadoDataGridViewTextBoxColumn.Width = 92;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 88;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // saldoDataGridViewTextBoxColumn
            // 
            this.saldoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.saldoDataGridViewTextBoxColumn.DataPropertyName = "Saldo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = "0";
            this.saldoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.saldoDataGridViewTextBoxColumn.HeaderText = "Saldo";
            this.saldoDataGridViewTextBoxColumn.Name = "saldoDataGridViewTextBoxColumn";
            this.saldoDataGridViewTextBoxColumn.ReadOnly = true;
            this.saldoDataGridViewTextBoxColumn.Width = 59;
            // 
            // siglaunidadeDataGridViewTextBoxColumn
            // 
            this.siglaunidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaunidadeDataGridViewTextBoxColumn.DataPropertyName = "Sigla_unidade";
            this.siglaunidadeDataGridViewTextBoxColumn.HeaderText = "UND";
            this.siglaunidadeDataGridViewTextBoxColumn.Name = "siglaunidadeDataGridViewTextBoxColumn";
            this.siglaunidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.siglaunidadeDataGridViewTextBoxColumn.Width = 56;
            // 
            // bsSaldoAlmox
            // 
            this.bsSaldoAlmox.DataSource = typeof(CamadaDados.Almoxarifado.TList_SaldoAlmoxarifado);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsSaldoAlmox;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 232);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(712, 25);
            this.bindingNavigator1.TabIndex = 8;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
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
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(712, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "ALMOXARIFADOS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pDados
            // 
            this.pDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.qtd_retirar);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.saldo_retirar);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.saldo_almox);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.editDefault2);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 274);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(716, 55);
            this.pDados.TabIndex = 0;
            // 
            // qtd_retirar
            // 
            this.qtd_retirar.DecimalPlaces = 3;
            this.qtd_retirar.Location = new System.Drawing.Point(444, 29);
            this.qtd_retirar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_retirar.Name = "qtd_retirar";
            this.qtd_retirar.NM_Alias = "";
            this.qtd_retirar.NM_Campo = "";
            this.qtd_retirar.NM_Param = "";
            this.qtd_retirar.Operador = "";
            this.qtd_retirar.Size = new System.Drawing.Size(101, 20);
            this.qtd_retirar.ST_AutoInc = false;
            this.qtd_retirar.ST_DisableAuto = false;
            this.qtd_retirar.ST_Gravar = false;
            this.qtd_retirar.ST_LimparCampo = true;
            this.qtd_retirar.ST_NotNull = false;
            this.qtd_retirar.ST_PrimaryKey = false;
            this.qtd_retirar.TabIndex = 0;
            this.qtd_retirar.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Qtd. Retirar:";
            // 
            // saldo_retirar
            // 
            this.saldo_retirar.DecimalPlaces = 3;
            this.saldo_retirar.Enabled = false;
            this.saldo_retirar.Location = new System.Drawing.Point(267, 29);
            this.saldo_retirar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.saldo_retirar.Name = "saldo_retirar";
            this.saldo_retirar.NM_Alias = "";
            this.saldo_retirar.NM_Campo = "";
            this.saldo_retirar.NM_Param = "";
            this.saldo_retirar.Operador = "";
            this.saldo_retirar.Size = new System.Drawing.Size(101, 20);
            this.saldo_retirar.ST_AutoInc = false;
            this.saldo_retirar.ST_DisableAuto = false;
            this.saldo_retirar.ST_Gravar = false;
            this.saldo_retirar.ST_LimparCampo = true;
            this.saldo_retirar.ST_NotNull = false;
            this.saldo_retirar.ST_PrimaryKey = false;
            this.saldo_retirar.TabIndex = 6;
            this.saldo_retirar.ThousandsSeparator = true;
            this.saldo_retirar.ValueChanged += new System.EventHandler(this.saldo_retirar_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Saldo Retirar:";
            // 
            // saldo_almox
            // 
            this.saldo_almox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsSaldoAlmox, "Saldo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.saldo_almox.DecimalPlaces = 3;
            this.saldo_almox.Enabled = false;
            this.saldo_almox.Location = new System.Drawing.Point(83, 29);
            this.saldo_almox.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.saldo_almox.Name = "saldo_almox";
            this.saldo_almox.NM_Alias = "";
            this.saldo_almox.NM_Campo = "";
            this.saldo_almox.NM_Param = "";
            this.saldo_almox.Operador = "";
            this.saldo_almox.Size = new System.Drawing.Size(101, 20);
            this.saldo_almox.ST_AutoInc = false;
            this.saldo_almox.ST_DisableAuto = false;
            this.saldo_almox.ST_Gravar = false;
            this.saldo_almox.ST_LimparCampo = true;
            this.saldo_almox.ST_NotNull = false;
            this.saldo_almox.ST_PrimaryKey = false;
            this.saldo_almox.TabIndex = 4;
            this.saldo_almox.ThousandsSeparator = true;
            this.saldo_almox.ValueChanged += new System.EventHandler(this.saldo_almox_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Saldo Almox.:";
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSaldoAlmox, "Ds_almoxarifado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Enabled = false;
            this.editDefault2.Location = new System.Drawing.Point(148, 3);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "";
            this.editDefault2.NM_CampoBusca = "";
            this.editDefault2.NM_Param = "";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.Size = new System.Drawing.Size(560, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = false;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = false;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 2;
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSaldoAlmox, "Id_almox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(82, 3);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(63, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Almoxarifado:";
            // 
            // TFRetRequisicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 377);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFRetRequisicao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retirada Produto Almoxarifado";
            this.Load += new System.EventHandler(this.TFRetRequisicao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFRetRequisicao_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRetRequisicao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gSaldoAlmox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSaldoAlmox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_retirar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saldo_retirar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saldo_almox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gSaldoAlmox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idalmoxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsalmoxarifadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsSaldoAlmox;
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
        private Componentes.EditDefault editDefault2;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat saldo_almox;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat qtd_retirar;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat saldo_retirar;
        private System.Windows.Forms.Label label3;
    }
}