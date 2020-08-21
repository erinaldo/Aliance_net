namespace Producao
{
    partial class TFFichaTecOrc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFFichaTecOrc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gFicha = new System.Windows.Forms.DataGridView();
            this.cditemDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsitemDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgunditemDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFichaTec = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bbAdd = new System.Windows.Forms.ToolStripButton();
            this.bbExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bb_copiarFicha = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cditemDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsitemDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgunditemDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cditemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsitemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgunditemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlunitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlSubtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gFicha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(830, 43);
            this.barraMenu.TabIndex = 12;
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
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.gFicha);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(830, 424);
            this.panelDados1.TabIndex = 13;
            // 
            // gFicha
            // 
            this.gFicha.AllowUserToAddRows = false;
            this.gFicha.AllowUserToDeleteRows = false;
            this.gFicha.AllowUserToOrderColumns = true;
            this.gFicha.AutoGenerateColumns = false;
            this.gFicha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gFicha.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.gFicha.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.gFicha.ColumnHeadersHeight = 34;
            this.gFicha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cditemDataGridViewTextBoxColumn2,
            this.dsitemDataGridViewTextBoxColumn2,
            this.sgunditemDataGridViewTextBoxColumn2,
            this.quantidadeDataGridViewTextBoxColumn2,
            this.SaldoEstoque,
            this.Cd_local,
            this.Ds_local});
            this.gFicha.DataSource = this.bsFichaTec;
            this.gFicha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gFicha.Location = new System.Drawing.Point(0, 0);
            this.gFicha.MultiSelect = false;
            this.gFicha.Name = "gFicha";
            this.gFicha.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gFicha.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gFicha.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gFicha.Size = new System.Drawing.Size(828, 397);
            this.gFicha.TabIndex = 4;
            this.gFicha.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gFicha_CellFormatting);
            this.gFicha.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gFicha_DataError);
            this.gFicha.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gFicha_EditingControlShowing);
            // 
            // cditemDataGridViewTextBoxColumn2
            // 
            this.cditemDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cditemDataGridViewTextBoxColumn2.DataPropertyName = "Cd_item";
            this.cditemDataGridViewTextBoxColumn2.HeaderText = "Cd.Item";
            this.cditemDataGridViewTextBoxColumn2.Name = "cditemDataGridViewTextBoxColumn2";
            this.cditemDataGridViewTextBoxColumn2.ReadOnly = true;
            this.cditemDataGridViewTextBoxColumn2.Width = 68;
            // 
            // dsitemDataGridViewTextBoxColumn2
            // 
            this.dsitemDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsitemDataGridViewTextBoxColumn2.DataPropertyName = "Ds_item";
            this.dsitemDataGridViewTextBoxColumn2.HeaderText = "Item";
            this.dsitemDataGridViewTextBoxColumn2.Name = "dsitemDataGridViewTextBoxColumn2";
            this.dsitemDataGridViewTextBoxColumn2.ReadOnly = true;
            this.dsitemDataGridViewTextBoxColumn2.Width = 52;
            // 
            // sgunditemDataGridViewTextBoxColumn2
            // 
            this.sgunditemDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sgunditemDataGridViewTextBoxColumn2.DataPropertyName = "Sg_unditem";
            this.sgunditemDataGridViewTextBoxColumn2.HeaderText = "UN";
            this.sgunditemDataGridViewTextBoxColumn2.Name = "sgunditemDataGridViewTextBoxColumn2";
            this.sgunditemDataGridViewTextBoxColumn2.ReadOnly = true;
            this.sgunditemDataGridViewTextBoxColumn2.Width = 48;
            // 
            // quantidadeDataGridViewTextBoxColumn2
            // 
            this.quantidadeDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.quantidadeDataGridViewTextBoxColumn2.DataPropertyName = "Quantidade";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = "0";
            this.quantidadeDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.quantidadeDataGridViewTextBoxColumn2.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn2.Name = "quantidadeDataGridViewTextBoxColumn2";
            this.quantidadeDataGridViewTextBoxColumn2.Width = 87;
            // 
            // SaldoEstoque
            // 
            this.SaldoEstoque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SaldoEstoque.DataPropertyName = "SaldoEstoque";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = "0";
            this.SaldoEstoque.DefaultCellStyle = dataGridViewCellStyle2;
            this.SaldoEstoque.HeaderText = "QTD. Estoque";
            this.SaldoEstoque.Name = "SaldoEstoque";
            this.SaldoEstoque.ReadOnly = true;
            this.SaldoEstoque.Width = 92;
            // 
            // Cd_local
            // 
            this.Cd_local.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_local.DataPropertyName = "Cd_local";
            this.Cd_local.HeaderText = "Cd.Local";
            this.Cd_local.Name = "Cd_local";
            this.Cd_local.ReadOnly = true;
            this.Cd_local.Width = 74;
            // 
            // Ds_local
            // 
            this.Ds_local.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_local.DataPropertyName = "Ds_local";
            this.Ds_local.HeaderText = "Local Arm.";
            this.Ds_local.Name = "Ds_local";
            this.Ds_local.ReadOnly = true;
            this.Ds_local.Width = 76;
            // 
            // bsFichaTec
            // 
            this.bsFichaTec.DataSource = typeof(CamadaDados.Faturamento.Orcamento.TList_FichaTecOrcItem);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsFichaTec;
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
            this.toolStripSeparator1,
            this.bbAdd,
            this.bbExcluir,
            this.toolStripSeparator2,
            this.bb_copiarFicha,
            this.toolStripSeparator3,
            this.toolStripLabel1});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 397);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(828, 25);
            this.bindingNavigator1.TabIndex = 3;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bbAdd
            // 
            this.bbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bbAdd.Image = ((System.Drawing.Image)(resources.GetObject("bbAdd.Image")));
            this.bbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbAdd.Name = "bbAdd";
            this.bbAdd.Size = new System.Drawing.Size(23, 22);
            this.bbAdd.ToolTipText = "Adicionar Matéria Prima";
            this.bbAdd.Click += new System.EventHandler(this.bbAdd_Click);
            // 
            // bbExcluir
            // 
            this.bbExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bbExcluir.Image = ((System.Drawing.Image)(resources.GetObject("bbExcluir.Image")));
            this.bbExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbExcluir.Name = "bbExcluir";
            this.bbExcluir.Size = new System.Drawing.Size(23, 22);
            this.bbExcluir.Text = "toolStripButton3";
            this.bbExcluir.ToolTipText = "Excluir Matéria Prima";
            this.bbExcluir.Click += new System.EventHandler(this.bbExcluir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bb_copiarFicha
            // 
            this.bb_copiarFicha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_copiarFicha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bb_copiarFicha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_copiarFicha.Name = "bb_copiarFicha";
            this.bb_copiarFicha.Size = new System.Drawing.Size(77, 22);
            this.bb_copiarFicha.Text = "Copiar Ficha";
            this.bb_copiarFicha.Click += new System.EventHandler(this.bb_copiarFicha_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(114, 22);
            this.toolStripLabel1.Text = "SALDO SUFICIENTE";
            // 
            // cditemDataGridViewTextBoxColumn1
            // 
            this.cditemDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cditemDataGridViewTextBoxColumn1.DataPropertyName = "Cd_item";
            this.cditemDataGridViewTextBoxColumn1.HeaderText = "Cd.Item";
            this.cditemDataGridViewTextBoxColumn1.Name = "cditemDataGridViewTextBoxColumn1";
            this.cditemDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dsitemDataGridViewTextBoxColumn1
            // 
            this.dsitemDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsitemDataGridViewTextBoxColumn1.DataPropertyName = "Ds_item";
            this.dsitemDataGridViewTextBoxColumn1.HeaderText = "Item";
            this.dsitemDataGridViewTextBoxColumn1.Name = "dsitemDataGridViewTextBoxColumn1";
            this.dsitemDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // sgunditemDataGridViewTextBoxColumn1
            // 
            this.sgunditemDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sgunditemDataGridViewTextBoxColumn1.DataPropertyName = "Sg_unditem";
            this.sgunditemDataGridViewTextBoxColumn1.HeaderText = "UN";
            this.sgunditemDataGridViewTextBoxColumn1.Name = "sgunditemDataGridViewTextBoxColumn1";
            this.sgunditemDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn1
            // 
            this.quantidadeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.quantidadeDataGridViewTextBoxColumn1.DataPropertyName = "Quantidade";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = "0";
            this.quantidadeDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.quantidadeDataGridViewTextBoxColumn1.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn1.Name = "quantidadeDataGridViewTextBoxColumn1";
            this.quantidadeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cditemDataGridViewTextBoxColumn
            // 
            this.cditemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cditemDataGridViewTextBoxColumn.DataPropertyName = "Cd_item";
            this.cditemDataGridViewTextBoxColumn.HeaderText = "Cd. Item";
            this.cditemDataGridViewTextBoxColumn.Name = "cditemDataGridViewTextBoxColumn";
            this.cditemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsitemDataGridViewTextBoxColumn
            // 
            this.dsitemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsitemDataGridViewTextBoxColumn.DataPropertyName = "Ds_item";
            this.dsitemDataGridViewTextBoxColumn.HeaderText = "Descrição Item";
            this.dsitemDataGridViewTextBoxColumn.Name = "dsitemDataGridViewTextBoxColumn";
            this.dsitemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sgunditemDataGridViewTextBoxColumn
            // 
            this.sgunditemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sgunditemDataGridViewTextBoxColumn.DataPropertyName = "Sg_unditem";
            this.sgunditemDataGridViewTextBoxColumn.HeaderText = "UND";
            this.sgunditemDataGridViewTextBoxColumn.Name = "sgunditemDataGridViewTextBoxColumn";
            this.sgunditemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = "0";
            this.quantidadeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlunitarioDataGridViewTextBoxColumn
            // 
            this.vlunitarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlunitarioDataGridViewTextBoxColumn.DataPropertyName = "Vl_unitario";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N5";
            dataGridViewCellStyle6.NullValue = "0";
            this.vlunitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.vlunitarioDataGridViewTextBoxColumn.HeaderText = "Vl. Unitario";
            this.vlunitarioDataGridViewTextBoxColumn.Name = "vlunitarioDataGridViewTextBoxColumn";
            this.vlunitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlSubtotalDataGridViewTextBoxColumn
            // 
            this.vlSubtotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlSubtotalDataGridViewTextBoxColumn.DataPropertyName = "Vl_Subtotal";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.vlSubtotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.vlSubtotalDataGridViewTextBoxColumn.HeaderText = "Vl. Total";
            this.vlSubtotalDataGridViewTextBoxColumn.Name = "vlSubtotalDataGridViewTextBoxColumn";
            this.vlSubtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFFichaTecOrc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 467);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFFichaTecOrc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ficha Técnica";
            this.Load += new System.EventHandler(this.TFFichaTecOrc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFFichaTecOrc_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gFicha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingSource bsFichaTec;
        private System.Windows.Forms.DataGridViewTextBoxColumn cditemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsitemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgunditemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlSubtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bbAdd;
        private System.Windows.Forms.ToolStripButton bbExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn cditemDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsitemDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgunditemDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bb_copiarFicha;
        private System.Windows.Forms.DataGridView gFicha;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cditemDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsitemDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgunditemDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_local;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_local;
    }
}