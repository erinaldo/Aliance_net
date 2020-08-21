namespace Financeiro
{
    partial class FDescontarCartao
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
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDescontarCartao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.BB_ProcessarLote = new System.Windows.Forms.ToolStripButton();
            this.BB_Estornar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.tcLote = new System.Windows.Forms.TabControl();
            this.tpBloquetos = new System.Windows.Forms.TabPage();
            this.gBloquetos = new Componentes.DataGridDefault(this.components);
            this.Vl_documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vl_taxa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vl_liquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pc_taxa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLoteDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFaturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlnominalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlliquidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlfaturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlquitadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlquitarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vltaxaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pctaxaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpmovimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtFaturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtFaturastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCartao = new System.Windows.Forms.BindingSource(this.components);
            this.bsLoteCartao = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.cbProcessado = new Componentes.CheckBoxDefault(this.components);
            this.cbAberto = new Componentes.CheckBoxDefault(this.components);
            this.DT_Final = new Componentes.EditData(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.DT_Inicial = new Componentes.EditData(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_lotebusca = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.id_lote = new Componentes.EditDefault(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.gLote = new Componentes.DataGridDefault(this.components);
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsLoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_Bandeira = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdContaGerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_Contager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdLanctoCaixaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtLotestrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtProcessamentostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnLote = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tot_taxa = new System.Windows.Forms.ToolStripLabel();
            this.tot_liquido = new System.Windows.Forms.ToolStripLabel();
            this.gCaixa = new Componentes.DataGridDefault(this.components);
            this.FDs_ContaGer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label7 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.tcLote.SuspendLayout();
            this.tpBloquetos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBloquetos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoteCartao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gLote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnLote)).BeginInit();
            this.bnLote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCaixa)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(270, 8);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(58, 13);
            label7.TabIndex = 33;
            label7.Text = "Descrição:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(5, 35);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(51, 13);
            label5.TabIndex = 28;
            label5.Text = "Empresa:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(8, 8);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(46, 13);
            label6.TabIndex = 22;
            label6.Text = "Id. Lote:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Excluir,
            this.BB_Buscar,
            this.BB_ProcessarLote,
            this.BB_Estornar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1273, 43);
            this.barraMenu.TabIndex = 7;
            // 
            // BB_Novo
            // 
            this.BB_Novo.AutoSize = false;
            this.BB_Novo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Novo.Image")));
            this.BB_Novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Novo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Novo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BB_Novo.Size = new System.Drawing.Size(75, 40);
            this.BB_Novo.Text = "(F2)\r\n Novo";
            this.BB_Novo.ToolTipText = "Novo Registro";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(90, 40);
            this.BB_Excluir.Text = " (F5)\r\n Excluir";
            this.BB_Excluir.ToolTipText = "Excluir Registro";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
            // 
            // BB_Buscar
            // 
            this.BB_Buscar.AutoSize = false;
            this.BB_Buscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Buscar.Image")));
            this.BB_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Size = new System.Drawing.Size(90, 40);
            this.BB_Buscar.Text = "(F7)\r\n Buscar";
            this.BB_Buscar.ToolTipText = "Buscar Registros";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // BB_ProcessarLote
            // 
            this.BB_ProcessarLote.AutoSize = false;
            this.BB_ProcessarLote.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
            this.BB_ProcessarLote.ForeColor = System.Drawing.Color.Green;
            this.BB_ProcessarLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_ProcessarLote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_ProcessarLote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_ProcessarLote.Name = "BB_ProcessarLote";
            this.BB_ProcessarLote.Size = new System.Drawing.Size(100, 40);
            this.BB_ProcessarLote.Text = "(F9)\r\n Processar \r\n Lote";
            this.BB_ProcessarLote.ToolTipText = "Transferir Titulo";
            this.BB_ProcessarLote.Click += new System.EventHandler(this.BB_ProcessarLote_Click);
            // 
            // BB_Estornar
            // 
            this.BB_Estornar.AutoSize = false;
            this.BB_Estornar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Estornar.ForeColor = System.Drawing.Color.Green;
            this.BB_Estornar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Estornar.Image")));
            this.BB_Estornar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Estornar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Estornar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Estornar.Name = "BB_Estornar";
            this.BB_Estornar.Size = new System.Drawing.Size(90, 40);
            this.BB_Estornar.Text = " (F10)\r\n Estornar";
            this.BB_Estornar.ToolTipText = "Estornar Processamento de Lote";
            this.BB_Estornar.Click += new System.EventHandler(this.BB_Estornar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
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
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.tcLote, 0, 2);
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados2, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 3;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.3271F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.6729F));
            this.tlpCentral.Size = new System.Drawing.Size(1273, 609);
            this.tlpCentral.TabIndex = 10;
            // 
            // tcLote
            // 
            this.tcLote.Controls.Add(this.tpBloquetos);
            this.tcLote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcLote.Location = new System.Drawing.Point(3, 314);
            this.tcLote.Name = "tcLote";
            this.tcLote.SelectedIndex = 0;
            this.tcLote.Size = new System.Drawing.Size(1267, 292);
            this.tcLote.TabIndex = 1;
            // 
            // tpBloquetos
            // 
            this.tpBloquetos.AutoScroll = true;
            this.tpBloquetos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tpBloquetos.Controls.Add(this.gBloquetos);
            this.tpBloquetos.Controls.Add(this.bindingNavigator1);
            this.tpBloquetos.Location = new System.Drawing.Point(4, 22);
            this.tpBloquetos.Name = "tpBloquetos";
            this.tpBloquetos.Padding = new System.Windows.Forms.Padding(3);
            this.tpBloquetos.Size = new System.Drawing.Size(1259, 266);
            this.tpBloquetos.TabIndex = 1;
            this.tpBloquetos.Text = "Faturas";
            this.tpBloquetos.UseVisualStyleBackColor = true;
            // 
            // gBloquetos
            // 
            this.gBloquetos.AllowUserToAddRows = false;
            this.gBloquetos.AllowUserToDeleteRows = false;
            this.gBloquetos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gBloquetos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gBloquetos.AutoGenerateColumns = false;
            this.gBloquetos.BackgroundColor = System.Drawing.Color.LightGray;
            this.gBloquetos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gBloquetos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBloquetos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gBloquetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gBloquetos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vl_documento,
            this.vl_taxa,
            this.vl_liquido,
            this.pc_taxa,
            this.cdEmpresaDataGridViewTextBoxColumn,
            this.idLoteDataGridViewTextBoxColumn1,
            this.idFaturaDataGridViewTextBoxColumn,
            this.vlnominalDataGridViewTextBoxColumn,
            this.vlliquidoDataGridViewTextBoxColumn,
            this.vlfaturaDataGridViewTextBoxColumn,
            this.vlquitadoDataGridViewTextBoxColumn,
            this.vlquitarDataGridViewTextBoxColumn,
            this.vltaxaDataGridViewTextBoxColumn,
            this.pctaxaDataGridViewTextBoxColumn,
            this.tpmovimentoDataGridViewTextBoxColumn,
            this.dtFaturaDataGridViewTextBoxColumn,
            this.dtFaturastrDataGridViewTextBoxColumn});
            this.gBloquetos.DataSource = this.bsCartao;
            this.gBloquetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBloquetos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gBloquetos.Location = new System.Drawing.Point(3, 3);
            this.gBloquetos.MultiSelect = false;
            this.gBloquetos.Name = "gBloquetos";
            this.gBloquetos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBloquetos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gBloquetos.RowHeadersWidth = 23;
            this.gBloquetos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gBloquetos.Size = new System.Drawing.Size(1249, 231);
            this.gBloquetos.TabIndex = 14;
            this.gBloquetos.TabStop = false;
            // 
            // Vl_documento
            // 
            this.Vl_documento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_documento.DataPropertyName = "Vl_nominal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.Vl_documento.DefaultCellStyle = dataGridViewCellStyle3;
            this.Vl_documento.HeaderText = "Vl. Nominal";
            this.Vl_documento.Name = "Vl_documento";
            this.Vl_documento.ReadOnly = true;
            this.Vl_documento.Width = 85;
            // 
            // vl_taxa
            // 
            this.vl_taxa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vl_taxa.DataPropertyName = "vl_taxa";
            this.vl_taxa.HeaderText = "Vl. Taxa";
            this.vl_taxa.Name = "vl_taxa";
            this.vl_taxa.ReadOnly = true;
            this.vl_taxa.Width = 71;
            // 
            // vl_liquido
            // 
            this.vl_liquido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vl_liquido.DataPropertyName = "vl_liquido";
            this.vl_liquido.HeaderText = "Vl. Liquido";
            this.vl_liquido.Name = "vl_liquido";
            this.vl_liquido.ReadOnly = true;
            this.vl_liquido.Width = 81;
            // 
            // pc_taxa
            // 
            this.pc_taxa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pc_taxa.DataPropertyName = "pc_taxa";
            this.pc_taxa.HeaderText = "% Taxa";
            this.pc_taxa.Name = "pc_taxa";
            this.pc_taxa.ReadOnly = true;
            this.pc_taxa.Width = 67;
            // 
            // cdEmpresaDataGridViewTextBoxColumn
            // 
            this.cdEmpresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_Empresa";
            this.cdEmpresaDataGridViewTextBoxColumn.HeaderText = "Cd_Empresa";
            this.cdEmpresaDataGridViewTextBoxColumn.Name = "cdEmpresaDataGridViewTextBoxColumn";
            this.cdEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idLoteDataGridViewTextBoxColumn1
            // 
            this.idLoteDataGridViewTextBoxColumn1.DataPropertyName = "Id_Lote";
            this.idLoteDataGridViewTextBoxColumn1.HeaderText = "Id_Lote";
            this.idLoteDataGridViewTextBoxColumn1.Name = "idLoteDataGridViewTextBoxColumn1";
            this.idLoteDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // idFaturaDataGridViewTextBoxColumn
            // 
            this.idFaturaDataGridViewTextBoxColumn.DataPropertyName = "Id_Fatura";
            this.idFaturaDataGridViewTextBoxColumn.HeaderText = "Id_Fatura";
            this.idFaturaDataGridViewTextBoxColumn.Name = "idFaturaDataGridViewTextBoxColumn";
            this.idFaturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlnominalDataGridViewTextBoxColumn
            // 
            this.vlnominalDataGridViewTextBoxColumn.DataPropertyName = "vl_nominal";
            this.vlnominalDataGridViewTextBoxColumn.HeaderText = "vl_nominal";
            this.vlnominalDataGridViewTextBoxColumn.Name = "vlnominalDataGridViewTextBoxColumn";
            this.vlnominalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlliquidoDataGridViewTextBoxColumn
            // 
            this.vlliquidoDataGridViewTextBoxColumn.DataPropertyName = "vl_liquido";
            this.vlliquidoDataGridViewTextBoxColumn.HeaderText = "vl_liquido";
            this.vlliquidoDataGridViewTextBoxColumn.Name = "vlliquidoDataGridViewTextBoxColumn";
            this.vlliquidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlfaturaDataGridViewTextBoxColumn
            // 
            this.vlfaturaDataGridViewTextBoxColumn.DataPropertyName = "vl_fatura";
            this.vlfaturaDataGridViewTextBoxColumn.HeaderText = "vl_fatura";
            this.vlfaturaDataGridViewTextBoxColumn.Name = "vlfaturaDataGridViewTextBoxColumn";
            this.vlfaturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlquitadoDataGridViewTextBoxColumn
            // 
            this.vlquitadoDataGridViewTextBoxColumn.DataPropertyName = "vl_quitado";
            this.vlquitadoDataGridViewTextBoxColumn.HeaderText = "vl_quitado";
            this.vlquitadoDataGridViewTextBoxColumn.Name = "vlquitadoDataGridViewTextBoxColumn";
            this.vlquitadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlquitarDataGridViewTextBoxColumn
            // 
            this.vlquitarDataGridViewTextBoxColumn.DataPropertyName = "vl_quitar";
            this.vlquitarDataGridViewTextBoxColumn.HeaderText = "vl_quitar";
            this.vlquitarDataGridViewTextBoxColumn.Name = "vlquitarDataGridViewTextBoxColumn";
            this.vlquitarDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vltaxaDataGridViewTextBoxColumn
            // 
            this.vltaxaDataGridViewTextBoxColumn.DataPropertyName = "vl_taxa";
            this.vltaxaDataGridViewTextBoxColumn.HeaderText = "vl_taxa";
            this.vltaxaDataGridViewTextBoxColumn.Name = "vltaxaDataGridViewTextBoxColumn";
            this.vltaxaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pctaxaDataGridViewTextBoxColumn
            // 
            this.pctaxaDataGridViewTextBoxColumn.DataPropertyName = "pc_taxa";
            this.pctaxaDataGridViewTextBoxColumn.HeaderText = "pc_taxa";
            this.pctaxaDataGridViewTextBoxColumn.Name = "pctaxaDataGridViewTextBoxColumn";
            this.pctaxaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpmovimentoDataGridViewTextBoxColumn
            // 
            this.tpmovimentoDataGridViewTextBoxColumn.DataPropertyName = "tp_movimento";
            this.tpmovimentoDataGridViewTextBoxColumn.HeaderText = "tp_movimento";
            this.tpmovimentoDataGridViewTextBoxColumn.Name = "tpmovimentoDataGridViewTextBoxColumn";
            this.tpmovimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtFaturaDataGridViewTextBoxColumn
            // 
            this.dtFaturaDataGridViewTextBoxColumn.DataPropertyName = "Dt_Fatura";
            this.dtFaturaDataGridViewTextBoxColumn.HeaderText = "Dt_Fatura";
            this.dtFaturaDataGridViewTextBoxColumn.Name = "dtFaturaDataGridViewTextBoxColumn";
            this.dtFaturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtFaturastrDataGridViewTextBoxColumn
            // 
            this.dtFaturastrDataGridViewTextBoxColumn.DataPropertyName = "Dt_Faturastr";
            this.dtFaturastrDataGridViewTextBoxColumn.HeaderText = "Dt_Faturastr";
            this.dtFaturastrDataGridViewTextBoxColumn.Name = "dtFaturastrDataGridViewTextBoxColumn";
            this.dtFaturastrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsCartao
            // 
            this.bsCartao.DataMember = "lCartao";
            this.bsCartao.DataSource = this.bsLoteCartao;
            // 
            // bsLoteCartao
            // 
            this.bsLoteCartao.DataSource = typeof(CamadaDados.Financeiro.Cartao.TList_LanLoteCartao);
            this.bsLoteCartao.PositionChanged += new System.EventHandler(this.bsLoteCartao_PositionChanged);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem1;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 234);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem1;
            this.bindingNavigator1.Size = new System.Drawing.Size(1249, 25);
            this.bindingNavigator1.TabIndex = 16;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem1.Text = "de {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Ultimo Registro";
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.radioGroup1);
            this.pFiltro.Controls.Add(this.DT_Final);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.DT_Inicial);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(label7);
            this.pFiltro.Controls.Add(this.ds_lotebusca);
            this.pFiltro.Controls.Add(this.bb_empresa);
            this.pFiltro.Controls.Add(label5);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Controls.Add(label6);
            this.pFiltro.Controls.Add(this.id_lote);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 3);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(1267, 59);
            this.pFiltro.TabIndex = 0;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.cbProcessado);
            this.radioGroup1.Controls.Add(this.cbAberto);
            this.radioGroup1.Location = new System.Drawing.Point(704, 5);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(185, 47);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 95;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Status";
            // 
            // cbProcessado
            // 
            this.cbProcessado.AutoSize = true;
            this.cbProcessado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbProcessado.ForeColor = System.Drawing.Color.Blue;
            this.cbProcessado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbProcessado.Location = new System.Drawing.Point(75, 19);
            this.cbProcessado.Name = "cbProcessado";
            this.cbProcessado.NM_Alias = "";
            this.cbProcessado.NM_Campo = "";
            this.cbProcessado.NM_Param = "";
            this.cbProcessado.Size = new System.Drawing.Size(92, 17);
            this.cbProcessado.ST_Gravar = false;
            this.cbProcessado.ST_LimparCampo = true;
            this.cbProcessado.ST_NotNull = false;
            this.cbProcessado.TabIndex = 1;
            this.cbProcessado.Text = "Processado";
            this.cbProcessado.UseVisualStyleBackColor = true;
            this.cbProcessado.Vl_False = "";
            this.cbProcessado.Vl_True = "";
            // 
            // cbAberto
            // 
            this.cbAberto.AutoSize = true;
            this.cbAberto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbAberto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbAberto.Location = new System.Drawing.Point(6, 19);
            this.cbAberto.Name = "cbAberto";
            this.cbAberto.NM_Alias = "";
            this.cbAberto.NM_Campo = "";
            this.cbAberto.NM_Param = "";
            this.cbAberto.Size = new System.Drawing.Size(63, 17);
            this.cbAberto.ST_Gravar = false;
            this.cbAberto.ST_LimparCampo = true;
            this.cbAberto.ST_NotNull = false;
            this.cbAberto.TabIndex = 0;
            this.cbAberto.Text = "Aberto";
            this.cbAberto.UseVisualStyleBackColor = true;
            this.cbAberto.Vl_False = "";
            this.cbAberto.Vl_True = "";
            // 
            // DT_Final
            // 
            this.DT_Final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Final.Location = new System.Drawing.Point(195, 33);
            this.DT_Final.Mask = "00/00/0000";
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.NM_Alias = "";
            this.DT_Final.NM_Campo = "";
            this.DT_Final.NM_CampoBusca = "";
            this.DT_Final.NM_Param = "";
            this.DT_Final.Operador = "";
            this.DT_Final.Size = new System.Drawing.Size(69, 20);
            this.DT_Final.ST_Gravar = false;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = false;
            this.DT_Final.ST_PrimaryKey = false;
            this.DT_Final.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(145, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "DT.Fin:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DT_Inicial
            // 
            this.DT_Inicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Inicial.Location = new System.Drawing.Point(195, 5);
            this.DT_Inicial.Mask = "00/00/0000";
            this.DT_Inicial.Name = "DT_Inicial";
            this.DT_Inicial.NM_Alias = "";
            this.DT_Inicial.NM_Campo = "";
            this.DT_Inicial.NM_CampoBusca = "";
            this.DT_Inicial.NM_Param = "";
            this.DT_Inicial.Operador = "";
            this.DT_Inicial.Size = new System.Drawing.Size(69, 20);
            this.DT_Inicial.ST_Gravar = false;
            this.DT_Inicial.ST_LimpaCampo = true;
            this.DT_Inicial.ST_NotNull = false;
            this.DT_Inicial.ST_PrimaryKey = false;
            this.DT_Inicial.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(148, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "DT.Ini:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ds_lotebusca
            // 
            this.ds_lotebusca.BackColor = System.Drawing.SystemColors.Window;
            this.ds_lotebusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_lotebusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_lotebusca.Location = new System.Drawing.Point(330, 5);
            this.ds_lotebusca.Name = "ds_lotebusca";
            this.ds_lotebusca.NM_Alias = "";
            this.ds_lotebusca.NM_Campo = "";
            this.ds_lotebusca.NM_CampoBusca = "";
            this.ds_lotebusca.NM_Param = "";
            this.ds_lotebusca.QTD_Zero = 0;
            this.ds_lotebusca.Size = new System.Drawing.Size(368, 20);
            this.ds_lotebusca.ST_AutoInc = false;
            this.ds_lotebusca.ST_DisableAuto = false;
            this.ds_lotebusca.ST_Float = false;
            this.ds_lotebusca.ST_Gravar = false;
            this.ds_lotebusca.ST_Int = false;
            this.ds_lotebusca.ST_LimpaCampo = true;
            this.ds_lotebusca.ST_NotNull = true;
            this.ds_lotebusca.ST_PrimaryKey = false;
            this.ds_lotebusca.TabIndex = 5;
            this.ds_lotebusca.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(114, 32);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 2;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Location = new System.Drawing.Point(56, 32);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_Empresa";
            this.cd_empresa.NM_CampoBusca = "cd_Empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(55, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 1;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // id_lote
            // 
            this.id_lote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(220)))), ((int)(((byte)(169)))));
            this.id_lote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_lote.Location = new System.Drawing.Point(56, 6);
            this.id_lote.Name = "id_lote";
            this.id_lote.NM_Alias = "";
            this.id_lote.NM_Campo = "";
            this.id_lote.NM_CampoBusca = "";
            this.id_lote.NM_Param = "";
            this.id_lote.QTD_Zero = 0;
            this.id_lote.Size = new System.Drawing.Size(86, 20);
            this.id_lote.ST_AutoInc = false;
            this.id_lote.ST_DisableAuto = false;
            this.id_lote.ST_Float = false;
            this.id_lote.ST_Gravar = true;
            this.id_lote.ST_Int = true;
            this.id_lote.ST_LimpaCampo = true;
            this.id_lote.ST_NotNull = false;
            this.id_lote.ST_PrimaryKey = false;
            this.id_lote.TabIndex = 0;
            this.id_lote.TextOld = null;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.gLote);
            this.panelDados2.Controls.Add(this.bnLote);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 68);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(1267, 240);
            this.panelDados2.TabIndex = 1;
            // 
            // gLote
            // 
            this.gLote.AllowUserToAddRows = false;
            this.gLote.AllowUserToDeleteRows = false;
            this.gLote.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gLote.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gLote.AutoGenerateColumns = false;
            this.gLote.BackgroundColor = System.Drawing.Color.LightGray;
            this.gLote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gLote.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gLote.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gLote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gLote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewTextBoxColumn,
            this.idLoteDataGridViewTextBoxColumn,
            this.dsLoteDataGridViewTextBoxColumn,
            this.Ds_Bandeira,
            this.cdContaGerDataGridViewTextBoxColumn,
            this.Ds_Contager,
            this.cdLanctoCaixaDataGridViewTextBoxColumn,
            this.dtLotestrDataGridViewTextBoxColumn,
            this.dtProcessamentostrDataGridViewTextBoxColumn});
            this.gLote.DataSource = this.bsLoteCartao;
            this.gLote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gLote.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gLote.Location = new System.Drawing.Point(0, 0);
            this.gLote.Name = "gLote";
            this.gLote.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gLote.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gLote.RowHeadersWidth = 23;
            this.gLote.Size = new System.Drawing.Size(1267, 215);
            this.gLote.TabIndex = 0;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 62;
            // 
            // idLoteDataGridViewTextBoxColumn
            // 
            this.idLoteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idLoteDataGridViewTextBoxColumn.DataPropertyName = "Id_Lote";
            this.idLoteDataGridViewTextBoxColumn.HeaderText = "Id. Lote";
            this.idLoteDataGridViewTextBoxColumn.Name = "idLoteDataGridViewTextBoxColumn";
            this.idLoteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idLoteDataGridViewTextBoxColumn.Width = 68;
            // 
            // dsLoteDataGridViewTextBoxColumn
            // 
            this.dsLoteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsLoteDataGridViewTextBoxColumn.DataPropertyName = "Ds_Lote";
            this.dsLoteDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.dsLoteDataGridViewTextBoxColumn.Name = "dsLoteDataGridViewTextBoxColumn";
            this.dsLoteDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsLoteDataGridViewTextBoxColumn.Width = 53;
            // 
            // Ds_Bandeira
            // 
            this.Ds_Bandeira.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_Bandeira.DataPropertyName = "Ds_Bandeira";
            this.Ds_Bandeira.HeaderText = "Bandeira";
            this.Ds_Bandeira.Name = "Ds_Bandeira";
            this.Ds_Bandeira.ReadOnly = true;
            this.Ds_Bandeira.Width = 74;
            // 
            // cdContaGerDataGridViewTextBoxColumn
            // 
            this.cdContaGerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdContaGerDataGridViewTextBoxColumn.DataPropertyName = "Cd_ContaGer";
            this.cdContaGerDataGridViewTextBoxColumn.HeaderText = "Cd. Conta Ger.";
            this.cdContaGerDataGridViewTextBoxColumn.Name = "cdContaGerDataGridViewTextBoxColumn";
            this.cdContaGerDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdContaGerDataGridViewTextBoxColumn.Width = 102;
            // 
            // Ds_Contager
            // 
            this.Ds_Contager.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_Contager.DataPropertyName = "Ds_Contager";
            this.Ds_Contager.HeaderText = "Conta Gerencial";
            this.Ds_Contager.Name = "Ds_Contager";
            this.Ds_Contager.ReadOnly = true;
            this.Ds_Contager.Width = 99;
            // 
            // cdLanctoCaixaDataGridViewTextBoxColumn
            // 
            this.cdLanctoCaixaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdLanctoCaixaDataGridViewTextBoxColumn.DataPropertyName = "Cd_LanctoCaixa";
            this.cdLanctoCaixaDataGridViewTextBoxColumn.HeaderText = "Cd. Caixa";
            this.cdLanctoCaixaDataGridViewTextBoxColumn.Name = "cdLanctoCaixaDataGridViewTextBoxColumn";
            this.cdLanctoCaixaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdLanctoCaixaDataGridViewTextBoxColumn.Width = 71;
            // 
            // dtLotestrDataGridViewTextBoxColumn
            // 
            this.dtLotestrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtLotestrDataGridViewTextBoxColumn.DataPropertyName = "Dt_Lotestr";
            this.dtLotestrDataGridViewTextBoxColumn.HeaderText = "Data Lote";
            this.dtLotestrDataGridViewTextBoxColumn.Name = "dtLotestrDataGridViewTextBoxColumn";
            this.dtLotestrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtLotestrDataGridViewTextBoxColumn.Width = 73;
            // 
            // dtProcessamentostrDataGridViewTextBoxColumn
            // 
            this.dtProcessamentostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtProcessamentostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_Processamentostr";
            this.dtProcessamentostrDataGridViewTextBoxColumn.HeaderText = "Data Processamento";
            this.dtProcessamentostrDataGridViewTextBoxColumn.Name = "dtProcessamentostrDataGridViewTextBoxColumn";
            this.dtProcessamentostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtProcessamentostrDataGridViewTextBoxColumn.Width = 120;
            // 
            // bnLote
            // 
            this.bnLote.AddNewItem = null;
            this.bnLote.CountItem = this.bindingNavigatorCountItem;
            this.bnLote.CountItemFormat = "de {0}";
            this.bnLote.DeleteItem = null;
            this.bnLote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnLote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator2,
            this.tot_taxa,
            this.tot_liquido});
            this.bnLote.Location = new System.Drawing.Point(0, 215);
            this.bnLote.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnLote.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnLote.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnLote.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnLote.Name = "bnLote";
            this.bnLote.PositionItem = this.bindingNavigatorPositionItem;
            this.bnLote.Size = new System.Drawing.Size(1267, 25);
            this.bnLote.TabIndex = 8;
            this.bnLote.Text = "bindingNavigator1";
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
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.ToolTipText = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.ToolTipText = "Registro Anterior";
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tot_taxa
            // 
            this.tot_taxa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tot_taxa.Name = "tot_taxa";
            this.tot_taxa.Size = new System.Drawing.Size(0, 22);
            // 
            // tot_liquido
            // 
            this.tot_liquido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tot_liquido.Name = "tot_liquido";
            this.tot_liquido.Size = new System.Drawing.Size(0, 22);
            // 
            // gCaixa
            // 
            this.gCaixa.AllowUserToAddRows = false;
            this.gCaixa.AllowUserToDeleteRows = false;
            this.gCaixa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gCaixa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.gCaixa.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCaixa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCaixa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCaixa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gCaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCaixa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FDs_ContaGer,
            this.dataGridViewTextBoxColumn52});
            this.gCaixa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCaixa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCaixa.Location = new System.Drawing.Point(3, 3);
            this.gCaixa.Name = "gCaixa";
            this.gCaixa.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCaixa.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gCaixa.RowHeadersWidth = 23;
            this.gCaixa.Size = new System.Drawing.Size(1013, 230);
            this.gCaixa.TabIndex = 1;
            // 
            // FDs_ContaGer
            // 
            this.FDs_ContaGer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FDs_ContaGer.DataPropertyName = "Ds_ContaGer";
            this.FDs_ContaGer.HeaderText = "Conta Gerencial";
            this.FDs_ContaGer.Name = "FDs_ContaGer";
            this.FDs_ContaGer.ReadOnly = true;
            this.FDs_ContaGer.Width = 99;
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn52.DataPropertyName = "Nm_empresa";
            this.dataGridViewTextBoxColumn52.HeaderText = "Empresa";
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            this.dataGridViewTextBoxColumn52.ReadOnly = true;
            this.dataGridViewTextBoxColumn52.Width = 73;
            // 
            // FDescontarCartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 652);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "FDescontarCartao";
            this.Text = "Descontar do cartão";
            this.Load += new System.EventHandler(this.FDescontarCartao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FDescontarCartao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.tcLote.ResumeLayout(false);
            this.tpBloquetos.ResumeLayout(false);
            this.tpBloquetos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBloquetos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoteCartao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gLote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnLote)).EndInit();
            this.bnLote.ResumeLayout(false);
            this.bnLote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCaixa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripButton BB_ProcessarLote;
        private System.Windows.Forms.ToolStripButton BB_Estornar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private System.Windows.Forms.TabControl tcLote;
        private System.Windows.Forms.TabPage tpBloquetos;
        private Componentes.DataGridDefault gBloquetos;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private Componentes.DataGridDefault gCaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDs_ContaGer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private Componentes.PanelDados pFiltro;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.CheckBoxDefault cbProcessado;
        private Componentes.CheckBoxDefault cbAberto;
        private Componentes.EditData DT_Final;
        private System.Windows.Forms.Label label2;
        private Componentes.EditData DT_Inicial;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_lotebusca;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault id_lote;
        private Componentes.PanelDados panelDados2;
        private Componentes.DataGridDefault gLote;
        private System.Windows.Forms.BindingNavigator bnLote;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tot_taxa;
        private System.Windows.Forms.ToolStripLabel tot_liquido;
        private System.Windows.Forms.BindingSource bsLoteCartao;
        private System.Windows.Forms.BindingSource bsCartao;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsLoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBandeiraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_Bandeira;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdContaGerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_Contager;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdLanctoCaixaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtLotestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtProcessamentostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFaturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn vl_taxa;
        private System.Windows.Forms.DataGridViewTextBoxColumn vl_liquido;
        private System.Windows.Forms.DataGridViewTextBoxColumn pc_taxa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLoteDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlnominalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlliquidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlfaturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlquitadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlquitarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vltaxaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pctaxaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpmovimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtFaturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtFaturastrDataGridViewTextBoxColumn;
    }
}