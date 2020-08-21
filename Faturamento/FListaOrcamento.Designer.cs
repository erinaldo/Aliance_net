namespace Faturamento
{
    partial class TFListaOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaOrcamento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.gItens = new Componentes.DataGridDefault(this.components);
            this.bsItens = new System.Windows.Forms.BindingSource(this.components);
            this.stfaturarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaunidprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdfaturarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdfaturarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdsaldoestoqueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlunitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlsubtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vldescontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlfreteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlsubtotalliqDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.sd_faturar = new Componentes.EditFloat(this.components);
            this.qtd_faturar = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbProcessar = new Componentes.CheckBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sd_faturar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_faturar)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(991, 43);
            this.barraMenu.TabIndex = 6;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(105, 40);
            this.BB_Gravar.Text = "(F4)\r\nConfirmar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
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
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpCentral.Size = new System.Drawing.Size(991, 563);
            this.tlpCentral.TabIndex = 7;
            // 
            // gItens
            // 
            this.gItens.AllowUserToAddRows = false;
            this.gItens.AllowUserToDeleteRows = false;
            this.gItens.AllowUserToOrderColumns = true;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gItens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.gItens.AutoGenerateColumns = false;
            this.gItens.BackgroundColor = System.Drawing.Color.LightGray;
            this.gItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gItens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.gItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stfaturarDataGridViewCheckBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.siglaunidprodutoDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.sdfaturarDataGridViewTextBoxColumn,
            this.qtdfaturarDataGridViewTextBoxColumn,
            this.qtdsaldoestoqueDataGridViewTextBoxColumn,
            this.vlunitarioDataGridViewTextBoxColumn,
            this.vlsubtotalDataGridViewTextBoxColumn,
            this.vldescontoDataGridViewTextBoxColumn,
            this.vlfreteDataGridViewTextBoxColumn,
            this.vlsubtotalliqDataGridViewTextBoxColumn});
            this.gItens.DataSource = this.bsItens;
            this.gItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gItens.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gItens.Location = new System.Drawing.Point(0, 0);
            this.gItens.Name = "gItens";
            this.gItens.ReadOnly = true;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItens.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.gItens.RowHeadersWidth = 23;
            this.gItens.Size = new System.Drawing.Size(977, 476);
            this.gItens.TabIndex = 0;
            this.gItens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gItens_CellClick);
            // 
            // bsItens
            // 
            this.bsItens.DataSource = typeof(CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item);
            // 
            // stfaturarDataGridViewCheckBoxColumn
            // 
            this.stfaturarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stfaturarDataGridViewCheckBoxColumn.DataPropertyName = "St_faturar";
            this.stfaturarDataGridViewCheckBoxColumn.HeaderText = "Faturar";
            this.stfaturarDataGridViewCheckBoxColumn.Name = "stfaturarDataGridViewCheckBoxColumn";
            this.stfaturarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stfaturarDataGridViewCheckBoxColumn.Width = 46;
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
            // siglaunidprodutoDataGridViewTextBoxColumn
            // 
            this.siglaunidprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaunidprodutoDataGridViewTextBoxColumn.DataPropertyName = "Sigla_unid_produto";
            this.siglaunidprodutoDataGridViewTextBoxColumn.HeaderText = "UND";
            this.siglaunidprodutoDataGridViewTextBoxColumn.Name = "siglaunidprodutoDataGridViewTextBoxColumn";
            this.siglaunidprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.siglaunidprodutoDataGridViewTextBoxColumn.Width = 56;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.Format = "N3";
            dataGridViewCellStyle27.NullValue = "0";
            this.quantidadeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle27;
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantidadeDataGridViewTextBoxColumn.Width = 87;
            // 
            // sdfaturarDataGridViewTextBoxColumn
            // 
            this.sdfaturarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sdfaturarDataGridViewTextBoxColumn.DataPropertyName = "Sd_faturar";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle28.Format = "N3";
            dataGridViewCellStyle28.NullValue = "0";
            this.sdfaturarDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle28;
            this.sdfaturarDataGridViewTextBoxColumn.HeaderText = "Saldo Faturar";
            this.sdfaturarDataGridViewTextBoxColumn.Name = "sdfaturarDataGridViewTextBoxColumn";
            this.sdfaturarDataGridViewTextBoxColumn.ReadOnly = true;
            this.sdfaturarDataGridViewTextBoxColumn.Width = 95;
            // 
            // qtdfaturarDataGridViewTextBoxColumn
            // 
            this.qtdfaturarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdfaturarDataGridViewTextBoxColumn.DataPropertyName = "Qtd_faturar";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.Format = "N3";
            dataGridViewCellStyle29.NullValue = "0";
            this.qtdfaturarDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle29;
            this.qtdfaturarDataGridViewTextBoxColumn.HeaderText = "Qtd. Faturar";
            this.qtdfaturarDataGridViewTextBoxColumn.Name = "qtdfaturarDataGridViewTextBoxColumn";
            this.qtdfaturarDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtdfaturarDataGridViewTextBoxColumn.Width = 88;
            // 
            // qtdsaldoestoqueDataGridViewTextBoxColumn
            // 
            this.qtdsaldoestoqueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdsaldoestoqueDataGridViewTextBoxColumn.DataPropertyName = "Qtd_saldoestoque";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.Format = "N3";
            dataGridViewCellStyle30.NullValue = "0";
            this.qtdsaldoestoqueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle30;
            this.qtdsaldoestoqueDataGridViewTextBoxColumn.HeaderText = "Saldo Estoque";
            this.qtdsaldoestoqueDataGridViewTextBoxColumn.Name = "qtdsaldoestoqueDataGridViewTextBoxColumn";
            this.qtdsaldoestoqueDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtdsaldoestoqueDataGridViewTextBoxColumn.Width = 101;
            // 
            // vlunitarioDataGridViewTextBoxColumn
            // 
            this.vlunitarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlunitarioDataGridViewTextBoxColumn.DataPropertyName = "Vl_unitario";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle31.Format = "N5";
            dataGridViewCellStyle31.NullValue = "0";
            this.vlunitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle31;
            this.vlunitarioDataGridViewTextBoxColumn.HeaderText = "Vl. Unitario";
            this.vlunitarioDataGridViewTextBoxColumn.Name = "vlunitarioDataGridViewTextBoxColumn";
            this.vlunitarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlunitarioDataGridViewTextBoxColumn.Width = 83;
            // 
            // vlsubtotalDataGridViewTextBoxColumn
            // 
            this.vlsubtotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlsubtotalDataGridViewTextBoxColumn.DataPropertyName = "Vl_subtotal";
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle32.Format = "N2";
            dataGridViewCellStyle32.NullValue = "0";
            this.vlsubtotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle32;
            this.vlsubtotalDataGridViewTextBoxColumn.HeaderText = "Vl. SubTotal";
            this.vlsubtotalDataGridViewTextBoxColumn.Name = "vlsubtotalDataGridViewTextBoxColumn";
            this.vlsubtotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlsubtotalDataGridViewTextBoxColumn.Width = 90;
            // 
            // vldescontoDataGridViewTextBoxColumn
            // 
            this.vldescontoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vldescontoDataGridViewTextBoxColumn.DataPropertyName = "Vl_desconto";
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle33.Format = "N2";
            dataGridViewCellStyle33.NullValue = "0";
            this.vldescontoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle33;
            this.vldescontoDataGridViewTextBoxColumn.HeaderText = "Vl. Desconto";
            this.vldescontoDataGridViewTextBoxColumn.Name = "vldescontoDataGridViewTextBoxColumn";
            this.vldescontoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vldescontoDataGridViewTextBoxColumn.Width = 93;
            // 
            // vlfreteDataGridViewTextBoxColumn
            // 
            this.vlfreteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlfreteDataGridViewTextBoxColumn.DataPropertyName = "Vl_frete";
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle34.Format = "N2";
            dataGridViewCellStyle34.NullValue = "0";
            this.vlfreteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle34;
            this.vlfreteDataGridViewTextBoxColumn.HeaderText = "Vl. Frete";
            this.vlfreteDataGridViewTextBoxColumn.Name = "vlfreteDataGridViewTextBoxColumn";
            this.vlfreteDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlfreteDataGridViewTextBoxColumn.Width = 71;
            // 
            // vlsubtotalliqDataGridViewTextBoxColumn
            // 
            this.vlsubtotalliqDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlsubtotalliqDataGridViewTextBoxColumn.DataPropertyName = "Vl_subtotalliq";
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle35.Format = "N2";
            dataGridViewCellStyle35.NullValue = "0";
            this.vlsubtotalliqDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle35;
            this.vlsubtotalliqDataGridViewTextBoxColumn.HeaderText = "Vl. Liquido";
            this.vlsubtotalliqDataGridViewTextBoxColumn.Name = "vlsubtotalliqDataGridViewTextBoxColumn";
            this.vlsubtotalliqDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlsubtotalliqDataGridViewTextBoxColumn.Width = 81;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.cbProcessar);
            this.panelDados1.Controls.Add(this.gItens);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 5);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(981, 505);
            this.panelDados1.TabIndex = 1;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsItens;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 476);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(977, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            this.pDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.qtd_faturar);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.sd_faturar);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 518);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(981, 40);
            this.pDados.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo Faturar:";
            // 
            // sd_faturar
            // 
            this.sd_faturar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItens, "Sd_faturar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sd_faturar.DecimalPlaces = 3;
            this.sd_faturar.Enabled = false;
            this.sd_faturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sd_faturar.Location = new System.Drawing.Point(118, 9);
            this.sd_faturar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.sd_faturar.Name = "sd_faturar";
            this.sd_faturar.NM_Alias = "";
            this.sd_faturar.NM_Campo = "";
            this.sd_faturar.NM_Param = "";
            this.sd_faturar.Operador = "";
            this.sd_faturar.Size = new System.Drawing.Size(135, 22);
            this.sd_faturar.ST_AutoInc = false;
            this.sd_faturar.ST_DisableAuto = false;
            this.sd_faturar.ST_Gravar = false;
            this.sd_faturar.ST_LimparCampo = true;
            this.sd_faturar.ST_NotNull = false;
            this.sd_faturar.ST_PrimaryKey = false;
            this.sd_faturar.TabIndex = 1;
            this.sd_faturar.ThousandsSeparator = true;
            // 
            // qtd_faturar
            // 
            this.qtd_faturar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItens, "Qtd_faturar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_faturar.DecimalPlaces = 3;
            this.qtd_faturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtd_faturar.Location = new System.Drawing.Point(358, 3);
            this.qtd_faturar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_faturar.Name = "qtd_faturar";
            this.qtd_faturar.NM_Alias = "";
            this.qtd_faturar.NM_Campo = "";
            this.qtd_faturar.NM_Param = "";
            this.qtd_faturar.Operador = "";
            this.qtd_faturar.Size = new System.Drawing.Size(135, 29);
            this.qtd_faturar.ST_AutoInc = false;
            this.qtd_faturar.ST_DisableAuto = false;
            this.qtd_faturar.ST_Gravar = false;
            this.qtd_faturar.ST_LimparCampo = true;
            this.qtd_faturar.ST_NotNull = false;
            this.qtd_faturar.ST_PrimaryKey = false;
            this.qtd_faturar.TabIndex = 3;
            this.qtd_faturar.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Qtd. Faturar:";
            // 
            // cbProcessar
            // 
            this.cbProcessar.AutoSize = true;
            this.cbProcessar.Location = new System.Drawing.Point(7, 5);
            this.cbProcessar.Name = "cbProcessar";
            this.cbProcessar.NM_Alias = "";
            this.cbProcessar.NM_Campo = "";
            this.cbProcessar.NM_Param = "";
            this.cbProcessar.Size = new System.Drawing.Size(15, 14);
            this.cbProcessar.ST_Gravar = false;
            this.cbProcessar.ST_LimparCampo = true;
            this.cbProcessar.ST_NotNull = false;
            this.cbProcessar.TabIndex = 4;
            this.cbProcessar.UseVisualStyleBackColor = true;
            this.cbProcessar.Vl_False = "";
            this.cbProcessar.Vl_True = "";
            this.cbProcessar.Click += new System.EventHandler(this.cbProcessar_Click);
            // 
            // TFListaOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 606);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaOrcamento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itens Orçamento a Faturar";
            this.Load += new System.EventHandler(this.TFListaOrcamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaOrcamento_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sd_faturar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_faturar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.DataGridDefault gItens;
        private System.Windows.Forms.BindingSource bsItens;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stfaturarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaunidprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdfaturarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdfaturarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdsaldoestoqueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlsubtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vldescontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlfreteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlsubtotalliqDataGridViewTextBoxColumn;
        private Componentes.PanelDados panelDados1;
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
        private Componentes.EditFloat qtd_faturar;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat sd_faturar;
        private System.Windows.Forms.Label label1;
        private Componentes.CheckBoxDefault cbProcessar;
    }
}