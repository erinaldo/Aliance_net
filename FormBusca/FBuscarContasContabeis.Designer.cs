namespace FormBusca
{
    partial class TFBuscarContasContabeis
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFBuscarContasContabeis));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.g_CadPlanocontas = new Componentes.DataGridDefault(this.components);
            this.Nat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.novaContaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirContaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.moverParaCimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverParaBaixoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordemAlfabéticaGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BN_CadPlanoContas = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbResultados = new System.Windows.Forms.ToolStripLabel();
            this.lbSequencia = new System.Windows.Forms.ToolStripLabel();
            this.bb_movcima = new System.Windows.Forms.ToolStripButton();
            this.bb_movbaixo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bb_alfabetica = new System.Windows.Forms.ToolStripButton();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.ds_conta = new Componentes.EditDefault(this.components);
            this.cdcontactbstrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDs_contactb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdclassificacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocontaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdeducaoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BS_CadPlanoContas = new System.Windows.Forms.BindingSource(this.components);
            label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadPlanocontas)).BeginInit();
            this.cmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadPlanoContas)).BeginInit();
            this.BN_CadPlanoContas.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadPlanoContas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(23, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 13);
            label2.TabIndex = 63;
            label2.Text = "Conta:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1097, 576);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.g_CadPlanocontas);
            this.panelDados1.Controls.Add(this.BN_CadPlanoContas);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 42);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1091, 531);
            this.panelDados1.TabIndex = 0;
            // 
            // g_CadPlanocontas
            // 
            this.g_CadPlanocontas.AllowUserToAddRows = false;
            this.g_CadPlanocontas.AllowUserToDeleteRows = false;
            this.g_CadPlanocontas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_CadPlanocontas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.g_CadPlanocontas.AutoGenerateColumns = false;
            this.g_CadPlanocontas.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_CadPlanocontas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_CadPlanocontas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadPlanocontas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.g_CadPlanocontas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_CadPlanocontas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdcontactbstrDataGridViewTextBoxColumn,
            this.pDs_contactb,
            this.cdclassificacaoDataGridViewTextBoxColumn,
            this.tipocontaDataGridViewTextBoxColumn,
            this.Nat,
            this.stdeducaoboolDataGridViewCheckBoxColumn});
            this.g_CadPlanocontas.ContextMenuStrip = this.cmMenu;
            this.g_CadPlanocontas.DataSource = this.BS_CadPlanoContas;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.g_CadPlanocontas.DefaultCellStyle = dataGridViewCellStyle7;
            this.g_CadPlanocontas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g_CadPlanocontas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_CadPlanocontas.Location = new System.Drawing.Point(0, 0);
            this.g_CadPlanocontas.Name = "g_CadPlanocontas";
            this.g_CadPlanocontas.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadPlanocontas.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.g_CadPlanocontas.RowHeadersWidth = 23;
            this.g_CadPlanocontas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_CadPlanocontas.Size = new System.Drawing.Size(1089, 504);
            this.g_CadPlanocontas.TabIndex = 4;
            this.g_CadPlanocontas.TabStop = false;
            this.g_CadPlanocontas.DoubleClick += new System.EventHandler(this.g_CadPlanocontas_DoubleClick);
            this.g_CadPlanocontas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.g_CadPlanocontas_CellFormatting);
            // 
            // Nat
            // 
            this.Nat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nat.DataPropertyName = "Nat";
            this.Nat.HeaderText = "Natureza";
            this.Nat.Name = "Nat";
            this.Nat.ReadOnly = true;
            this.Nat.Width = 75;
            // 
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaContaToolStripMenuItem,
            this.excluirContaToolStripMenuItem,
            this.toolStripMenuItem1,
            this.moverParaCimaToolStripMenuItem,
            this.moverParaBaixoToolStripMenuItem,
            this.ordemAlfabéticaGrupoToolStripMenuItem});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(212, 120);
            // 
            // novaContaToolStripMenuItem
            // 
            this.novaContaToolStripMenuItem.Name = "novaContaToolStripMenuItem";
            this.novaContaToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.novaContaToolStripMenuItem.Text = "Nova Conta";
            this.novaContaToolStripMenuItem.Click += new System.EventHandler(this.novaContaToolStripMenuItem_Click);
            // 
            // excluirContaToolStripMenuItem
            // 
            this.excluirContaToolStripMenuItem.Name = "excluirContaToolStripMenuItem";
            this.excluirContaToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.excluirContaToolStripMenuItem.Text = "Excluir Conta";
            this.excluirContaToolStripMenuItem.Click += new System.EventHandler(this.excluirContaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
            // 
            // moverParaCimaToolStripMenuItem
            // 
            this.moverParaCimaToolStripMenuItem.Name = "moverParaCimaToolStripMenuItem";
            this.moverParaCimaToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.moverParaCimaToolStripMenuItem.Text = "Mover Para Cima";
            this.moverParaCimaToolStripMenuItem.Click += new System.EventHandler(this.moverParaCimaToolStripMenuItem_Click);
            // 
            // moverParaBaixoToolStripMenuItem
            // 
            this.moverParaBaixoToolStripMenuItem.Name = "moverParaBaixoToolStripMenuItem";
            this.moverParaBaixoToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.moverParaBaixoToolStripMenuItem.Text = "Mover Para Baixo";
            this.moverParaBaixoToolStripMenuItem.Click += new System.EventHandler(this.moverParaBaixoToolStripMenuItem_Click);
            // 
            // ordemAlfabéticaGrupoToolStripMenuItem
            // 
            this.ordemAlfabéticaGrupoToolStripMenuItem.Name = "ordemAlfabéticaGrupoToolStripMenuItem";
            this.ordemAlfabéticaGrupoToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.ordemAlfabéticaGrupoToolStripMenuItem.Text = "Ordem Alfabética - Grupo";
            this.ordemAlfabéticaGrupoToolStripMenuItem.Click += new System.EventHandler(this.ordemAlfabéticaGrupoToolStripMenuItem_Click);
            // 
            // BN_CadPlanoContas
            // 
            this.BN_CadPlanoContas.AddNewItem = null;
            this.BN_CadPlanoContas.BindingSource = this.BS_CadPlanoContas;
            this.BN_CadPlanoContas.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadPlanoContas.CountItemFormat = "de {0}";
            this.BN_CadPlanoContas.DeleteItem = null;
            this.BN_CadPlanoContas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_CadPlanoContas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator1,
            this.lbResultados,
            this.lbSequencia,
            this.bb_movcima,
            this.bb_movbaixo,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.bb_alfabetica});
            this.BN_CadPlanoContas.Location = new System.Drawing.Point(0, 504);
            this.BN_CadPlanoContas.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadPlanoContas.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadPlanoContas.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadPlanoContas.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadPlanoContas.Name = "BN_CadPlanoContas";
            this.BN_CadPlanoContas.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_CadPlanoContas.Size = new System.Drawing.Size(1089, 25);
            this.BN_CadPlanoContas.TabIndex = 3;
            this.BN_CadPlanoContas.Text = "bindingNavigator1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lbResultados
            // 
            this.lbResultados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbResultados.ForeColor = System.Drawing.Color.Blue;
            this.lbResultados.Name = "lbResultados";
            this.lbResultados.Size = new System.Drawing.Size(0, 22);
            // 
            // lbSequencia
            // 
            this.lbSequencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbSequencia.ForeColor = System.Drawing.Color.Blue;
            this.lbSequencia.Name = "lbSequencia";
            this.lbSequencia.Size = new System.Drawing.Size(0, 22);
            // 
            // bb_movcima
            // 
            this.bb_movcima.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_movcima.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bb_movcima.Image = ((System.Drawing.Image)(resources.GetObject("bb_movcima.Image")));
            this.bb_movcima.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_movcima.Name = "bb_movcima";
            this.bb_movcima.Size = new System.Drawing.Size(140, 22);
            this.bb_movcima.Text = "Mover Conta Para Cima";
            this.bb_movcima.Click += new System.EventHandler(this.bb_movcima_Click);
            // 
            // bb_movbaixo
            // 
            this.bb_movbaixo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_movbaixo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bb_movbaixo.Image = ((System.Drawing.Image)(resources.GetObject("bb_movbaixo.Image")));
            this.bb_movbaixo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_movbaixo.Name = "bb_movbaixo";
            this.bb_movbaixo.Size = new System.Drawing.Size(144, 22);
            this.bb_movbaixo.Text = "Mover Conta Para Baixo";
            this.bb_movbaixo.Click += new System.EventHandler(this.bb_movbaixo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bb_alfabetica
            // 
            this.bb_alfabetica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_alfabetica.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bb_alfabetica.ForeColor = System.Drawing.Color.Blue;
            this.bb_alfabetica.Image = ((System.Drawing.Image)(resources.GetObject("bb_alfabetica.Image")));
            this.bb_alfabetica.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_alfabetica.Name = "bb_alfabetica";
            this.bb_alfabetica.Size = new System.Drawing.Size(188, 22);
            this.bb_alfabetica.Text = "Organizar por Ordem Alfabética";
            this.bb_alfabetica.Click += new System.EventHandler(this.bb_alfabetica_Click);
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(label2);
            this.panelDados2.Controls.Add(this.ds_conta);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 3);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(1091, 33);
            this.panelDados2.TabIndex = 1;
            // 
            // ds_conta
            // 
            this.ds_conta.BackColor = System.Drawing.SystemColors.Window;
            this.ds_conta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_conta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_conta.Location = new System.Drawing.Point(67, 6);
            this.ds_conta.Name = "ds_conta";
            this.ds_conta.NM_Alias = "";
            this.ds_conta.NM_Campo = "";
            this.ds_conta.NM_CampoBusca = "";
            this.ds_conta.NM_Param = "";
            this.ds_conta.QTD_Zero = 0;
            this.ds_conta.Size = new System.Drawing.Size(727, 20);
            this.ds_conta.ST_AutoInc = false;
            this.ds_conta.ST_DisableAuto = false;
            this.ds_conta.ST_Float = false;
            this.ds_conta.ST_Gravar = false;
            this.ds_conta.ST_Int = false;
            this.ds_conta.ST_LimpaCampo = true;
            this.ds_conta.ST_NotNull = false;
            this.ds_conta.ST_PrimaryKey = false;
            this.ds_conta.TabIndex = 0;
            this.ds_conta.TextOld = null;
            this.ds_conta.TextChanged += new System.EventHandler(this.ds_conta_TextChanged);
            // 
            // cdcontactbstrDataGridViewTextBoxColumn
            // 
            this.cdcontactbstrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcontactbstrDataGridViewTextBoxColumn.DataPropertyName = "Cd_conta_ctbstr";
            this.cdcontactbstrDataGridViewTextBoxColumn.HeaderText = "Cd. Conta";
            this.cdcontactbstrDataGridViewTextBoxColumn.Name = "cdcontactbstrDataGridViewTextBoxColumn";
            this.cdcontactbstrDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcontactbstrDataGridViewTextBoxColumn.Width = 79;
            // 
            // pDs_contactb
            // 
            this.pDs_contactb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pDs_contactb.DataPropertyName = "Ds_contactb";
            this.pDs_contactb.HeaderText = "Conta Contabil";
            this.pDs_contactb.Name = "pDs_contactb";
            this.pDs_contactb.ReadOnly = true;
            this.pDs_contactb.Width = 101;
            // 
            // cdclassificacaoDataGridViewTextBoxColumn
            // 
            this.cdclassificacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdclassificacaoDataGridViewTextBoxColumn.DataPropertyName = "Cd_classificacao";
            this.cdclassificacaoDataGridViewTextBoxColumn.HeaderText = "Classificação";
            this.cdclassificacaoDataGridViewTextBoxColumn.Name = "cdclassificacaoDataGridViewTextBoxColumn";
            this.cdclassificacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdclassificacaoDataGridViewTextBoxColumn.Width = 94;
            // 
            // tipocontaDataGridViewTextBoxColumn
            // 
            this.tipocontaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipocontaDataGridViewTextBoxColumn.DataPropertyName = "Tipo_conta";
            this.tipocontaDataGridViewTextBoxColumn.HeaderText = "Tipo Conta";
            this.tipocontaDataGridViewTextBoxColumn.Name = "tipocontaDataGridViewTextBoxColumn";
            this.tipocontaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipocontaDataGridViewTextBoxColumn.Width = 84;
            // 
            // stdeducaoboolDataGridViewCheckBoxColumn
            // 
            this.stdeducaoboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stdeducaoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_deducaobool";
            this.stdeducaoboolDataGridViewCheckBoxColumn.HeaderText = "Dedução";
            this.stdeducaoboolDataGridViewCheckBoxColumn.Name = "stdeducaoboolDataGridViewCheckBoxColumn";
            this.stdeducaoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stdeducaoboolDataGridViewCheckBoxColumn.Width = 57;
            // 
            // BS_CadPlanoContas
            // 
            this.BS_CadPlanoContas.DataSource = typeof(CamadaDados.Contabil.Cadastro.TList_CadPlanoContas);
            // 
            // TFBuscarContasContabeis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 576);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "TFBuscarContasContabeis";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busca - Contas";
            this.Load += new System.EventHandler(this.TFBuscarContasContabeis_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFBuscarContasContabeis_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadPlanocontas)).EndInit();
            this.cmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadPlanoContas)).EndInit();
            this.BN_CadPlanoContas.ResumeLayout(false);
            this.BN_CadPlanoContas.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadPlanoContas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingNavigator BN_CadPlanoContas;
        private System.Windows.Forms.BindingSource BS_CadPlanoContas;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault g_CadPlanocontas;
        private Componentes.PanelDados panelDados2;
        private Componentes.EditDefault ds_conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcontactbstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDs_contactb;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdclassificacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocontaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stdeducaoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem novaContaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverParaCimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverParaBaixoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirContaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lbResultados;
        private System.Windows.Forms.ToolStripLabel lbSequencia;
        private System.Windows.Forms.ToolStripButton bb_movcima;
        private System.Windows.Forms.ToolStripButton bb_movbaixo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton bb_alfabetica;
        private System.Windows.Forms.ToolStripMenuItem ordemAlfabéticaGrupoToolStripMenuItem;
    }
}