namespace Faturamento
{
    partial class TFItensExpedicao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItensExpedicao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsItensExpedicao = new System.Windows.Forms.BindingSource(this.components);
            this.bsExpedicao = new System.Windows.Forms.BindingSource(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.gItensExpedicao = new Componentes.DataGridDefault(this.components);
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoCarregar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PS_Unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pDados = new Componentes.PanelDados(this.components);
            this.vlPeso = new Componentes.EditFloat(this.components);
            this.lbNumPedido = new System.Windows.Forms.Label();
            this.Obs_Pedido = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.Obs = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.volume = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bn_pedido = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem2 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem2 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtCodBarras = new System.Windows.Forms.ToolStripTextBox();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensExpedicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsExpedicao)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gItensExpedicao)).BeginInit();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_pedido)).BeginInit();
            this.bn_pedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1232, 43);
            this.barraMenu.TabIndex = 13;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // bsItensExpedicao
            // 
            this.bsItensExpedicao.DataMember = "lItens";
            this.bsItensExpedicao.DataSource = this.bsExpedicao;
            // 
            // bsExpedicao
            // 
            this.bsExpedicao.DataSource = typeof(CamadaDados.Faturamento.Pedido.TList_Expedicao);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.tableLayoutPanel1);
            this.panelDados1.Controls.Add(this.bn_pedido);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1232, 626);
            this.panelDados1.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pDados, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1232, 601);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.cbTodos);
            this.panelDados2.Controls.Add(this.gItensExpedicao);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 156);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(1226, 442);
            this.panelDados2.TabIndex = 0;
            // 
            // cbTodos
            // 
            this.cbTodos.AutoSize = true;
            this.cbTodos.Location = new System.Drawing.Point(5, 4);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.NM_Alias = "";
            this.cbTodos.NM_Campo = "";
            this.cbTodos.NM_Param = "";
            this.cbTodos.Size = new System.Drawing.Size(15, 14);
            this.cbTodos.ST_Gravar = false;
            this.cbTodos.ST_LimparCampo = true;
            this.cbTodos.ST_NotNull = false;
            this.cbTodos.TabIndex = 1;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            this.cbTodos.CheckedChanged += new System.EventHandler(this.cbTodos_CheckedChanged);
            // 
            // gItensExpedicao
            // 
            this.gItensExpedicao.AllowUserToAddRows = false;
            this.gItensExpedicao.AllowUserToDeleteRows = false;
            this.gItensExpedicao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gItensExpedicao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gItensExpedicao.AutoGenerateColumns = false;
            this.gItensExpedicao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gItensExpedicao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gItensExpedicao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItensExpedicao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gItensExpedicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gItensExpedicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn12,
            this.quantidadeDataGridViewTextBoxColumn,
            this.SaldoCarregar,
            this.PS_Unitario,
            this.dataGridViewCheckBoxColumn1});
            this.gItensExpedicao.DataSource = this.bsItensExpedicao;
            this.gItensExpedicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gItensExpedicao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gItensExpedicao.Location = new System.Drawing.Point(0, 0);
            this.gItensExpedicao.Name = "gItensExpedicao";
            this.gItensExpedicao.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItensExpedicao.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gItensExpedicao.RowHeadersWidth = 23;
            this.gItensExpedicao.Size = new System.Drawing.Size(1226, 442);
            this.gItensExpedicao.TabIndex = 0;
            this.gItensExpedicao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gItensExpedicao_CellClick);
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Add";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Width = 32;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Cd_produto";
            this.dataGridViewTextBoxColumn8.HeaderText = "Cd.Produto";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 85;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Ds_produto";
            this.dataGridViewTextBoxColumn9.HeaderText = "Produto";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 69;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Nr_serie";
            this.dataGridViewTextBoxColumn12.HeaderText = "Nº Série";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 71;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N3";
            dataGridViewCellStyle9.NullValue = "0";
            this.quantidadeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantidadeDataGridViewTextBoxColumn.Width = 87;
            // 
            // SaldoCarregar
            // 
            this.SaldoCarregar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SaldoCarregar.DataPropertyName = "SaldoCarregar";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N3";
            dataGridViewCellStyle10.NullValue = "0";
            this.SaldoCarregar.DefaultCellStyle = dataGridViewCellStyle10;
            this.SaldoCarregar.HeaderText = "Saldo Carregar";
            this.SaldoCarregar.Name = "SaldoCarregar";
            this.SaldoCarregar.ReadOnly = true;
            this.SaldoCarregar.Width = 102;
            // 
            // PS_Unitario
            // 
            this.PS_Unitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PS_Unitario.DataPropertyName = "PS_Unitario";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N3";
            dataGridViewCellStyle11.NullValue = "0";
            this.PS_Unitario.DefaultCellStyle = dataGridViewCellStyle11;
            this.PS_Unitario.HeaderText = "Peso Unitário";
            this.PS_Unitario.Name = "PS_Unitario";
            this.PS_Unitario.ReadOnly = true;
            this.PS_Unitario.Width = 95;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "St_exigirserie";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Exigir Série";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 65;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.vlPeso);
            this.pDados.Controls.Add(this.lbNumPedido);
            this.pDados.Controls.Add(this.Obs_Pedido);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.Obs);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.volume);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(3, 3);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(1226, 147);
            this.pDados.TabIndex = 1;
            // 
            // vlPeso
            // 
            this.vlPeso.DecimalPlaces = 3;
            this.vlPeso.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vlPeso.Location = new System.Drawing.Point(65, 9);
            this.vlPeso.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.vlPeso.Name = "vlPeso";
            this.vlPeso.NM_Alias = "";
            this.vlPeso.NM_Campo = "";
            this.vlPeso.NM_Param = "";
            this.vlPeso.Operador = "";
            this.vlPeso.Size = new System.Drawing.Size(120, 20);
            this.vlPeso.ST_AutoInc = false;
            this.vlPeso.ST_DisableAuto = false;
            this.vlPeso.ST_Gravar = false;
            this.vlPeso.ST_LimparCampo = true;
            this.vlPeso.ST_NotNull = false;
            this.vlPeso.ST_PrimaryKey = false;
            this.vlPeso.TabIndex = 9;
            this.vlPeso.ThousandsSeparator = true;
            this.vlPeso.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lbNumPedido
            // 
            this.lbNumPedido.AutoSize = true;
            this.lbNumPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumPedido.Location = new System.Drawing.Point(62, 76);
            this.lbNumPedido.Name = "lbNumPedido";
            this.lbNumPedido.Size = new System.Drawing.Size(33, 13);
            this.lbNumPedido.TabIndex = 8;
            this.lbNumPedido.Text = "Obs:";
            // 
            // Obs_Pedido
            // 
            this.Obs_Pedido.BackColor = System.Drawing.SystemColors.Window;
            this.Obs_Pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Obs_Pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Obs_Pedido.Location = new System.Drawing.Point(65, 92);
            this.Obs_Pedido.Multiline = true;
            this.Obs_Pedido.Name = "Obs_Pedido";
            this.Obs_Pedido.NM_Alias = "";
            this.Obs_Pedido.NM_Campo = "";
            this.Obs_Pedido.NM_CampoBusca = "";
            this.Obs_Pedido.NM_Param = "";
            this.Obs_Pedido.QTD_Zero = 0;
            this.Obs_Pedido.ReadOnly = true;
            this.Obs_Pedido.Size = new System.Drawing.Size(856, 50);
            this.Obs_Pedido.ST_AutoInc = false;
            this.Obs_Pedido.ST_DisableAuto = false;
            this.Obs_Pedido.ST_Float = false;
            this.Obs_Pedido.ST_Gravar = false;
            this.Obs_Pedido.ST_Int = false;
            this.Obs_Pedido.ST_LimpaCampo = true;
            this.Obs_Pedido.ST_NotNull = false;
            this.Obs_Pedido.ST_PrimaryKey = false;
            this.Obs_Pedido.TabIndex = 7;
            this.Obs_Pedido.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Obs:";
            // 
            // Obs
            // 
            this.Obs.BackColor = System.Drawing.SystemColors.Window;
            this.Obs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Obs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Obs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsExpedicao, "Obs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Obs.Location = new System.Drawing.Point(65, 35);
            this.Obs.Multiline = true;
            this.Obs.Name = "Obs";
            this.Obs.NM_Alias = "";
            this.Obs.NM_Campo = "";
            this.Obs.NM_CampoBusca = "";
            this.Obs.NM_Param = "";
            this.Obs.QTD_Zero = 0;
            this.Obs.Size = new System.Drawing.Size(856, 34);
            this.Obs.ST_AutoInc = false;
            this.Obs.ST_DisableAuto = false;
            this.Obs.ST_Float = false;
            this.Obs.ST_Gravar = false;
            this.Obs.ST_Int = false;
            this.Obs.ST_LimpaCampo = true;
            this.Obs.ST_NotNull = false;
            this.Obs.ST_PrimaryKey = false;
            this.Obs.TabIndex = 5;
            this.Obs.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Volume:";
            // 
            // volume
            // 
            this.volume.BackColor = System.Drawing.SystemColors.Window;
            this.volume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.volume.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.volume.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsExpedicao, "Volume", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.volume.Location = new System.Drawing.Point(286, 9);
            this.volume.Name = "volume";
            this.volume.NM_Alias = "";
            this.volume.NM_Campo = "";
            this.volume.NM_CampoBusca = "";
            this.volume.NM_Param = "";
            this.volume.QTD_Zero = 0;
            this.volume.Size = new System.Drawing.Size(635, 20);
            this.volume.ST_AutoInc = false;
            this.volume.ST_DisableAuto = false;
            this.volume.ST_Float = false;
            this.volume.ST_Gravar = false;
            this.volume.ST_Int = false;
            this.volume.ST_LimpaCampo = true;
            this.volume.ST_NotNull = false;
            this.volume.ST_PrimaryKey = false;
            this.volume.TabIndex = 3;
            this.volume.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Peso:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // bn_pedido
            // 
            this.bn_pedido.AddNewItem = null;
            this.bn_pedido.BindingSource = this.bsItensExpedicao;
            this.bn_pedido.CountItem = this.bindingNavigatorCountItem2;
            this.bn_pedido.CountItemFormat = "de {0}";
            this.bn_pedido.DeleteItem = null;
            this.bn_pedido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bn_pedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem2,
            this.bindingNavigatorMovePreviousItem2,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorPositionItem2,
            this.bindingNavigatorCountItem2,
            this.bindingNavigatorSeparator5,
            this.bindingNavigatorMoveNextItem2,
            this.bindingNavigatorMoveLastItem2,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtCodBarras});
            this.bn_pedido.Location = new System.Drawing.Point(0, 601);
            this.bn_pedido.MoveFirstItem = this.bindingNavigatorMoveFirstItem2;
            this.bn_pedido.MoveLastItem = this.bindingNavigatorMoveLastItem2;
            this.bn_pedido.MoveNextItem = this.bindingNavigatorMoveNextItem2;
            this.bn_pedido.MovePreviousItem = this.bindingNavigatorMovePreviousItem2;
            this.bn_pedido.Name = "bn_pedido";
            this.bn_pedido.PositionItem = this.bindingNavigatorPositionItem2;
            this.bn_pedido.Size = new System.Drawing.Size(1232, 25);
            this.bn_pedido.TabIndex = 6;
            this.bn_pedido.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem2
            // 
            this.bindingNavigatorCountItem2.Name = "bindingNavigatorCountItem2";
            this.bindingNavigatorCountItem2.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem2.Text = "de {0}";
            this.bindingNavigatorCountItem2.ToolTipText = "Total de Registros";
            // 
            // bindingNavigatorMoveFirstItem2
            // 
            this.bindingNavigatorMoveFirstItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem2.Image")));
            this.bindingNavigatorMoveFirstItem2.Name = "bindingNavigatorMoveFirstItem2";
            this.bindingNavigatorMoveFirstItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem2.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem2
            // 
            this.bindingNavigatorMovePreviousItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem2.Image")));
            this.bindingNavigatorMovePreviousItem2.Name = "bindingNavigatorMovePreviousItem2";
            this.bindingNavigatorMovePreviousItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem2.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem2
            // 
            this.bindingNavigatorPositionItem2.AccessibleName = "Position";
            this.bindingNavigatorPositionItem2.AutoSize = false;
            this.bindingNavigatorPositionItem2.Name = "bindingNavigatorPositionItem2";
            this.bindingNavigatorPositionItem2.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem2.Text = "0";
            this.bindingNavigatorPositionItem2.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem2
            // 
            this.bindingNavigatorMoveNextItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem2.Image")));
            this.bindingNavigatorMoveNextItem2.Name = "bindingNavigatorMoveNextItem2";
            this.bindingNavigatorMoveNextItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem2.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem2
            // 
            this.bindingNavigatorMoveLastItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem2.Image")));
            this.bindingNavigatorMoveLastItem2.Name = "bindingNavigatorMoveLastItem2";
            this.bindingNavigatorMoveLastItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem2.Text = "Ultimo Registro";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(103, 22);
            this.toolStripLabel1.Text = "Código de Barras:";
            // 
            // txtCodBarras
            // 
            this.txtCodBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodBarras.Enabled = false;
            this.txtCodBarras.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtCodBarras.Name = "txtCodBarras";
            this.txtCodBarras.ReadOnly = true;
            this.txtCodBarras.Size = new System.Drawing.Size(500, 25);
            // 
            // TFItensExpedicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 669);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFItensExpedicao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itens Expedicao";
            this.Load += new System.EventHandler(this.TFItensExpedicao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensExpedicao_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TFItensExpedicao_KeyPress);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensExpedicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsExpedicao)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gItensExpedicao)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_pedido)).EndInit();
            this.bn_pedido.ResumeLayout(false);
            this.bn_pedido.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gItensExpedicao;
        private System.Windows.Forms.BindingNavigator bn_pedido;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idordemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idordemstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrpedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrpedidostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpedidoitemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpedidoitemstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iditemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iditemstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idserieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idseriestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrserieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diametroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comprimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pSUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stexigirserieDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados2;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsExpedicao;
        private System.Windows.Forms.BindingSource bsItensExpedicao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault Obs;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault volume;
        private System.Windows.Forms.Label label2;
        private Componentes.CheckBoxDefault cbTodos;
        private System.Windows.Forms.Label lbNumPedido;
        private Componentes.EditDefault Obs_Pedido;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoCarregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn PS_Unitario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtCodBarras;
        private Componentes.EditFloat vlPeso;
    }
}