namespace Proc_Commoditties
{
    partial class TFSaldoEstPrecoVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFSaldoEstPrecoVenda));
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label label6;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pSaldoEstoque = new Componentes.PanelDados(this.components);
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.quantidade = new Componentes.EditFloat(this.components);
            this.ds_local = new Componentes.EditDefault(this.components);
            this.bb_local = new System.Windows.Forms.Button();
            this.cd_local = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.gTabPreco = new Componentes.DataGridDefault(this.components);
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDTabelaPrecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSTabelaPrecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTabPreco = new System.Windows.Forms.BindingSource(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.vl_precovenda = new Componentes.EditFloat(this.components);
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pSaldoEstoque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTabPreco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTabPreco)).BeginInit();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_precovenda)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(384, 43);
            this.barraMenu.TabIndex = 4;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pSaldoEstoque, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 315);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // pSaldoEstoque
            // 
            this.pSaldoEstoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSaldoEstoque.Controls.Add(this.vl_subtotal);
            this.pSaldoEstoque.Controls.Add(label4);
            this.pSaldoEstoque.Controls.Add(this.vl_unitario);
            this.pSaldoEstoque.Controls.Add(label3);
            this.pSaldoEstoque.Controls.Add(this.quantidade);
            this.pSaldoEstoque.Controls.Add(label2);
            this.pSaldoEstoque.Controls.Add(this.ds_local);
            this.pSaldoEstoque.Controls.Add(this.bb_local);
            this.pSaldoEstoque.Controls.Add(this.cd_local);
            this.pSaldoEstoque.Controls.Add(label1);
            this.pSaldoEstoque.Controls.Add(this.nm_empresa);
            this.pSaldoEstoque.Controls.Add(this.bb_empresa);
            this.pSaldoEstoque.Controls.Add(this.cd_empresa);
            this.pSaldoEstoque.Controls.Add(cd_empresaLabel);
            this.pSaldoEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSaldoEstoque.Location = new System.Drawing.Point(4, 4);
            this.pSaldoEstoque.Name = "pSaldoEstoque";
            this.pSaldoEstoque.NM_ProcDeletar = "";
            this.pSaldoEstoque.NM_ProcGravar = "";
            this.pSaldoEstoque.Size = new System.Drawing.Size(376, 126);
            this.pSaldoEstoque.TabIndex = 0;
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Enabled = false;
            this.vl_subtotal.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_subtotal.Location = new System.Drawing.Point(257, 97);
            this.vl_subtotal.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_subtotal.Name = "vl_subtotal";
            this.vl_subtotal.NM_Alias = "";
            this.vl_subtotal.NM_Campo = "";
            this.vl_subtotal.NM_Param = "";
            this.vl_subtotal.Operador = "";
            this.vl_subtotal.Size = new System.Drawing.Size(107, 20);
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = false;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = false;
            this.vl_subtotal.ST_PrimaryKey = false;
            this.vl_subtotal.TabIndex = 129;
            this.vl_subtotal.ThousandsSeparator = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(254, 81);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(61, 13);
            label4.TabIndex = 128;
            label4.Text = "Custo Total";
            // 
            // vl_unitario
            // 
            this.vl_unitario.DecimalPlaces = 5;
            this.vl_unitario.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_unitario.Location = new System.Drawing.Point(122, 97);
            this.vl_unitario.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_unitario.Name = "vl_unitario";
            this.vl_unitario.NM_Alias = "";
            this.vl_unitario.NM_Campo = "";
            this.vl_unitario.NM_Param = "";
            this.vl_unitario.Operador = "";
            this.vl_unitario.Size = new System.Drawing.Size(107, 20);
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = false;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = false;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.TabIndex = 5;
            this.vl_unitario.ThousandsSeparator = true;
            this.vl_unitario.Leave += new System.EventHandler(this.vl_unitario_Leave);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(119, 81);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 13);
            label3.TabIndex = 126;
            label3.Text = "Vl. Custo";
            // 
            // quantidade
            // 
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.quantidade.Location = new System.Drawing.Point(9, 97);
            this.quantidade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.quantidade.Name = "quantidade";
            this.quantidade.NM_Alias = "";
            this.quantidade.NM_Campo = "";
            this.quantidade.NM_Param = "";
            this.quantidade.Operador = "";
            this.quantidade.Size = new System.Drawing.Size(107, 20);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = false;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = false;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 4;
            this.quantidade.ThousandsSeparator = true;
            this.quantidade.Leave += new System.EventHandler(this.quantidade_Leave);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(6, 81);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 13);
            label2.TabIndex = 124;
            label2.Text = "Quantidade";
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.Enabled = false;
            this.ds_local.Location = new System.Drawing.Point(108, 58);
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "a";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_NM_EMPRESA";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.Size = new System.Drawing.Size(256, 20);
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = false;
            this.ds_local.ST_Int = false;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = false;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TabIndex = 123;
            this.ds_local.TextOld = null;
            // 
            // bb_local
            // 
            this.bb_local.BackColor = System.Drawing.SystemColors.Control;
            this.bb_local.Image = ((System.Drawing.Image)(resources.GetObject("bb_local.Image")));
            this.bb_local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_local.Location = new System.Drawing.Point(74, 58);
            this.bb_local.Name = "bb_local";
            this.bb_local.Size = new System.Drawing.Size(28, 19);
            this.bb_local.TabIndex = 3;
            this.bb_local.UseVisualStyleBackColor = false;
            this.bb_local.Click += new System.EventHandler(this.bb_local_Click);
            // 
            // cd_local
            // 
            this.cd_local.BackColor = System.Drawing.Color.White;
            this.cd_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_local.Location = new System.Drawing.Point(6, 58);
            this.cd_local.MaxLength = 4;
            this.cd_local.Name = "cd_local";
            this.cd_local.NM_Alias = "a";
            this.cd_local.NM_Campo = "cd_local";
            this.cd_local.NM_CampoBusca = "cd_local";
            this.cd_local.NM_Param = "@P_CD_EMPRESA";
            this.cd_local.QTD_Zero = 0;
            this.cd_local.Size = new System.Drawing.Size(67, 20);
            this.cd_local.ST_AutoInc = false;
            this.cd_local.ST_DisableAuto = false;
            this.cd_local.ST_Float = false;
            this.cd_local.ST_Gravar = true;
            this.cd_local.ST_Int = false;
            this.cd_local.ST_LimpaCampo = true;
            this.cd_local.ST_NotNull = false;
            this.cd_local.ST_PrimaryKey = false;
            this.cd_local.TabIndex = 2;
            this.cd_local.TextOld = null;
            this.cd_local.Leave += new System.EventHandler(this.cd_local_Leave);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(3, 42);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(103, 13);
            label1.TabIndex = 122;
            label1.Text = "Local Armazenagem";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(108, 19);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(256, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 119;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(74, 19);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(6, 19);
            this.cd_empresa.MaxLength = 4;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(67, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(3, 3);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(48, 13);
            cd_empresaLabel.TabIndex = 118;
            cd_empresaLabel.Text = "Empresa";
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.cbTodos);
            this.panelDados1.Controls.Add(this.gTabPreco);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(4, 137);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(376, 125);
            this.panelDados1.TabIndex = 1;
            // 
            // cbTodos
            // 
            this.cbTodos.AutoSize = true;
            this.cbTodos.Location = new System.Drawing.Point(6, 4);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.NM_Alias = "";
            this.cbTodos.NM_Campo = "";
            this.cbTodos.NM_Param = "";
            this.cbTodos.Size = new System.Drawing.Size(15, 14);
            this.cbTodos.ST_Gravar = false;
            this.cbTodos.ST_LimparCampo = true;
            this.cbTodos.ST_NotNull = false;
            this.cbTodos.TabIndex = 6;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            this.cbTodos.Click += new System.EventHandler(this.cbTodos_Click);
            // 
            // gTabPreco
            // 
            this.gTabPreco.AllowUserToAddRows = false;
            this.gTabPreco.AllowUserToDeleteRows = false;
            this.gTabPreco.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTabPreco.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gTabPreco.AutoGenerateColumns = false;
            this.gTabPreco.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTabPreco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTabPreco.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTabPreco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gTabPreco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTabPreco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.cDTabelaPrecoDataGridViewTextBoxColumn,
            this.dSTabelaPrecoDataGridViewTextBoxColumn});
            this.gTabPreco.DataSource = this.bsTabPreco;
            this.gTabPreco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTabPreco.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTabPreco.Location = new System.Drawing.Point(0, 0);
            this.gTabPreco.Name = "gTabPreco";
            this.gTabPreco.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTabPreco.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gTabPreco.RowHeadersWidth = 23;
            this.gTabPreco.Size = new System.Drawing.Size(374, 123);
            this.gTabPreco.TabIndex = 0;
            this.gTabPreco.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gTabPreco_CellClick);
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
            // cDTabelaPrecoDataGridViewTextBoxColumn
            // 
            this.cDTabelaPrecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDTabelaPrecoDataGridViewTextBoxColumn.DataPropertyName = "CD_TabelaPreco";
            this.cDTabelaPrecoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.cDTabelaPrecoDataGridViewTextBoxColumn.Name = "cDTabelaPrecoDataGridViewTextBoxColumn";
            this.cDTabelaPrecoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDTabelaPrecoDataGridViewTextBoxColumn.Width = 65;
            // 
            // dSTabelaPrecoDataGridViewTextBoxColumn
            // 
            this.dSTabelaPrecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSTabelaPrecoDataGridViewTextBoxColumn.DataPropertyName = "DS_TabelaPreco";
            this.dSTabelaPrecoDataGridViewTextBoxColumn.HeaderText = "Tabela Preço";
            this.dSTabelaPrecoDataGridViewTextBoxColumn.Name = "dSTabelaPrecoDataGridViewTextBoxColumn";
            this.dSTabelaPrecoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSTabelaPrecoDataGridViewTextBoxColumn.Width = 96;
            // 
            // bsTabPreco
            // 
            this.bsTabPreco.DataSource = typeof(CamadaDados.Diversos.TList_CadTbPreco);
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.vl_precovenda);
            this.panelDados2.Controls.Add(label6);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(4, 269);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(376, 42);
            this.panelDados2.TabIndex = 2;
            // 
            // vl_precovenda
            // 
            this.vl_precovenda.DecimalPlaces = 2;
            this.vl_precovenda.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_precovenda.Location = new System.Drawing.Point(7, 20);
            this.vl_precovenda.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_precovenda.Name = "vl_precovenda";
            this.vl_precovenda.NM_Alias = "";
            this.vl_precovenda.NM_Campo = "";
            this.vl_precovenda.NM_Param = "";
            this.vl_precovenda.Operador = "";
            this.vl_precovenda.Size = new System.Drawing.Size(107, 20);
            this.vl_precovenda.ST_AutoInc = false;
            this.vl_precovenda.ST_DisableAuto = false;
            this.vl_precovenda.ST_Gravar = false;
            this.vl_precovenda.ST_LimparCampo = true;
            this.vl_precovenda.ST_NotNull = false;
            this.vl_precovenda.ST_PrimaryKey = false;
            this.vl_precovenda.TabIndex = 8;
            this.vl_precovenda.ThousandsSeparator = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(4, 4);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(69, 13);
            label6.TabIndex = 134;
            label6.Text = "Preço Venda";
            // 
            // TFSaldoEstPrecoVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 358);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFSaldoEstPrecoVenda";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incluir Saldo Estoque/Preço Venda";
            this.Load += new System.EventHandler(this.FSaldoEstPrecoVenda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFSaldoEstPrecoVenda_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pSaldoEstoque.ResumeLayout(false);
            this.pSaldoEstoque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTabPreco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTabPreco)).EndInit();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_precovenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pSaldoEstoque;
        private Componentes.EditDefault ds_local;
        private System.Windows.Forms.Button bb_local;
        private Componentes.EditDefault cd_local;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditFloat vl_precovenda;
        private Componentes.EditFloat vl_subtotal;
        private Componentes.EditFloat vl_unitario;
        private Componentes.EditFloat quantidade;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gTabPreco;
        private System.Windows.Forms.BindingSource bsTabPreco;
        private Componentes.PanelDados panelDados2;
        private Componentes.CheckBoxDefault cbTodos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDTabelaPrecoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSTabelaPrecoDataGridViewTextBoxColumn;
    }
}