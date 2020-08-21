namespace Financeiro
{
    partial class TFAcertoViagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAcertoViagem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pConsulta = new Componentes.PanelDados(this.components);
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.nm_funcionario = new Componentes.EditDefault(this.components);
            this.bb_funcionario = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cd_funcionario = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.gViagem = new Componentes.DataGridDefault(this.components);
            this.bsViagem = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.TotalPagar = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.SaldoRestante = new Componentes.EditFloat(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.SaldoAtual = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.TotalDespesas = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idviagemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsviagemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtiniDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtfinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_despesas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kMiniDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kMfinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pConsulta.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gViagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsViagem)).BeginInit();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaldoRestante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaldoAtual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDespesas)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(1028, 43);
            this.barraMenu.TabIndex = 20;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pConsulta, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 390);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // pConsulta
            // 
            this.pConsulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pConsulta.Controls.Add(this.cbEmpresa);
            this.pConsulta.Controls.Add(this.nm_funcionario);
            this.pConsulta.Controls.Add(this.bb_funcionario);
            this.pConsulta.Controls.Add(this.label4);
            this.pConsulta.Controls.Add(this.cd_funcionario);
            this.pConsulta.Controls.Add(this.label3);
            this.pConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pConsulta.Location = new System.Drawing.Point(3, 3);
            this.pConsulta.Name = "pConsulta";
            this.pConsulta.NM_ProcDeletar = "";
            this.pConsulta.NM_ProcGravar = "";
            this.pConsulta.Size = new System.Drawing.Size(1022, 32);
            this.pConsulta.TabIndex = 1;
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(66, 4);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(403, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 84;
            this.cbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbEmpresa_SelectedIndexChanged);
            // 
            // nm_funcionario
            // 
            this.nm_funcionario.BackColor = System.Drawing.SystemColors.Window;
            this.nm_funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_funcionario.Enabled = false;
            this.nm_funcionario.Location = new System.Drawing.Point(665, 4);
            this.nm_funcionario.Name = "nm_funcionario";
            this.nm_funcionario.NM_Alias = "";
            this.nm_funcionario.NM_Campo = "nm_clifor";
            this.nm_funcionario.NM_CampoBusca = "nm_clifor";
            this.nm_funcionario.NM_Param = "@P_NM_EMPRESA";
            this.nm_funcionario.QTD_Zero = 0;
            this.nm_funcionario.Size = new System.Drawing.Size(336, 20);
            this.nm_funcionario.ST_AutoInc = false;
            this.nm_funcionario.ST_DisableAuto = false;
            this.nm_funcionario.ST_Float = false;
            this.nm_funcionario.ST_Gravar = false;
            this.nm_funcionario.ST_Int = false;
            this.nm_funcionario.ST_LimpaCampo = true;
            this.nm_funcionario.ST_NotNull = false;
            this.nm_funcionario.ST_PrimaryKey = false;
            this.nm_funcionario.TabIndex = 83;
            this.nm_funcionario.TextOld = null;
            // 
            // bb_funcionario
            // 
            this.bb_funcionario.Image = ((System.Drawing.Image)(resources.GetObject("bb_funcionario.Image")));
            this.bb_funcionario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_funcionario.Location = new System.Drawing.Point(631, 4);
            this.bb_funcionario.Name = "bb_funcionario";
            this.bb_funcionario.Size = new System.Drawing.Size(28, 20);
            this.bb_funcionario.TabIndex = 81;
            this.bb_funcionario.UseVisualStyleBackColor = true;
            this.bb_funcionario.Click += new System.EventHandler(this.bb_funcionario_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(479, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "Funcionário:";
            // 
            // cd_funcionario
            // 
            this.cd_funcionario.BackColor = System.Drawing.SystemColors.Window;
            this.cd_funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_funcionario.Location = new System.Drawing.Point(547, 4);
            this.cd_funcionario.Name = "cd_funcionario";
            this.cd_funcionario.NM_Alias = "";
            this.cd_funcionario.NM_Campo = "cd_clifor";
            this.cd_funcionario.NM_CampoBusca = "cd_clifor";
            this.cd_funcionario.NM_Param = "@P_CD_CIDADE";
            this.cd_funcionario.QTD_Zero = 0;
            this.cd_funcionario.Size = new System.Drawing.Size(83, 20);
            this.cd_funcionario.ST_AutoInc = false;
            this.cd_funcionario.ST_DisableAuto = false;
            this.cd_funcionario.ST_Float = false;
            this.cd_funcionario.ST_Gravar = true;
            this.cd_funcionario.ST_Int = true;
            this.cd_funcionario.ST_LimpaCampo = true;
            this.cd_funcionario.ST_NotNull = true;
            this.cd_funcionario.ST_PrimaryKey = false;
            this.cd_funcionario.TabIndex = 80;
            this.cd_funcionario.TextOld = null;
            this.cd_funcionario.Leave += new System.EventHandler(this.cd_funcionario_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Empresa:";
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.cbTodos);
            this.panelDados1.Controls.Add(this.gViagem);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 41);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1022, 301);
            this.panelDados1.TabIndex = 2;
            // 
            // cbTodos
            // 
            this.cbTodos.AutoSize = true;
            this.cbTodos.Location = new System.Drawing.Point(6, 25);
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
            // gViagem
            // 
            this.gViagem.AllowUserToAddRows = false;
            this.gViagem.AllowUserToDeleteRows = false;
            this.gViagem.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gViagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gViagem.AutoGenerateColumns = false;
            this.gViagem.BackgroundColor = System.Drawing.Color.LightGray;
            this.gViagem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gViagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gViagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gViagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gViagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.dataGridViewTextBoxColumn1,
            this.idviagemDataGridViewTextBoxColumn,
            this.dsviagemDataGridViewTextBoxColumn,
            this.dtiniDataGridViewTextBoxColumn,
            this.dtfinDataGridViewTextBoxColumn,
            this.Vl_despesas,
            this.kMiniDataGridViewTextBoxColumn,
            this.kMfinDataGridViewTextBoxColumn,
            this.obsDataGridViewTextBoxColumn});
            this.gViagem.DataSource = this.bsViagem;
            this.gViagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gViagem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gViagem.Location = new System.Drawing.Point(0, 20);
            this.gViagem.Name = "gViagem";
            this.gViagem.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gViagem.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gViagem.RowHeadersWidth = 23;
            this.gViagem.Size = new System.Drawing.Size(1020, 279);
            this.gViagem.TabIndex = 5;
            this.gViagem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gViagem_CellClick);
            // 
            // bsViagem
            // 
            this.bsViagem.DataSource = typeof(CamadaDados.Financeiro.Viagem.TList_Viagem);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(88)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(1020, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "VIAGENS EM ABERTO PARA ACERTO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(this.TotalPagar);
            this.panelDados2.Controls.Add(this.label2);
            this.panelDados2.Controls.Add(this.SaldoRestante);
            this.panelDados2.Controls.Add(this.label12);
            this.panelDados2.Controls.Add(this.SaldoAtual);
            this.panelDados2.Controls.Add(this.label5);
            this.panelDados2.Controls.Add(this.TotalDespesas);
            this.panelDados2.Controls.Add(this.label8);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 348);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(1022, 39);
            this.panelDados2.TabIndex = 3;
            // 
            // TotalPagar
            // 
            this.TotalPagar.DecimalPlaces = 2;
            this.TotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPagar.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TotalPagar.Location = new System.Drawing.Point(914, 9);
            this.TotalPagar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.TotalPagar.Name = "TotalPagar";
            this.TotalPagar.NM_Alias = "";
            this.TotalPagar.NM_Campo = "";
            this.TotalPagar.NM_Param = "";
            this.TotalPagar.Operador = "";
            this.TotalPagar.ReadOnly = true;
            this.TotalPagar.Size = new System.Drawing.Size(86, 20);
            this.TotalPagar.ST_AutoInc = false;
            this.TotalPagar.ST_DisableAuto = false;
            this.TotalPagar.ST_Gravar = false;
            this.TotalPagar.ST_LimparCampo = true;
            this.TotalPagar.ST_NotNull = false;
            this.TotalPagar.ST_PrimaryKey = false;
            this.TotalPagar.TabIndex = 96;
            this.TotalPagar.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(764, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "(=)Vl.Pagar Funcionário:";
            // 
            // SaldoRestante
            // 
            this.SaldoRestante.DecimalPlaces = 2;
            this.SaldoRestante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaldoRestante.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SaldoRestante.Location = new System.Drawing.Point(671, 9);
            this.SaldoRestante.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.SaldoRestante.Name = "SaldoRestante";
            this.SaldoRestante.NM_Alias = "";
            this.SaldoRestante.NM_Campo = "";
            this.SaldoRestante.NM_Param = "";
            this.SaldoRestante.Operador = "";
            this.SaldoRestante.ReadOnly = true;
            this.SaldoRestante.Size = new System.Drawing.Size(86, 20);
            this.SaldoRestante.ST_AutoInc = false;
            this.SaldoRestante.ST_DisableAuto = false;
            this.SaldoRestante.ST_Gravar = false;
            this.SaldoRestante.ST_LimparCampo = true;
            this.SaldoRestante.ST_NotNull = false;
            this.SaldoRestante.ST_PrimaryKey = false;
            this.SaldoRestante.TabIndex = 94;
            this.SaldoRestante.ThousandsSeparator = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(501, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 13);
            this.label12.TabIndex = 93;
            this.label12.Text = "(=)Saldo com o Funcionário:";
            // 
            // SaldoAtual
            // 
            this.SaldoAtual.DecimalPlaces = 2;
            this.SaldoAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaldoAtual.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SaldoAtual.Location = new System.Drawing.Point(177, 9);
            this.SaldoAtual.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.SaldoAtual.Name = "SaldoAtual";
            this.SaldoAtual.NM_Alias = "";
            this.SaldoAtual.NM_Campo = "";
            this.SaldoAtual.NM_Param = "";
            this.SaldoAtual.Operador = "";
            this.SaldoAtual.ReadOnly = true;
            this.SaldoAtual.Size = new System.Drawing.Size(102, 20);
            this.SaldoAtual.ST_AutoInc = false;
            this.SaldoAtual.ST_DisableAuto = false;
            this.SaldoAtual.ST_Gravar = false;
            this.SaldoAtual.ST_LimparCampo = true;
            this.SaldoAtual.ST_NotNull = false;
            this.SaldoAtual.ST_PrimaryKey = false;
            this.SaldoAtual.TabIndex = 88;
            this.SaldoAtual.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "(+)Total Adiantamentos:";
            // 
            // TotalDespesas
            // 
            this.TotalDespesas.DecimalPlaces = 2;
            this.TotalDespesas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalDespesas.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TotalDespesas.Location = new System.Drawing.Point(380, 9);
            this.TotalDespesas.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.TotalDespesas.Name = "TotalDespesas";
            this.TotalDespesas.NM_Alias = "";
            this.TotalDespesas.NM_Campo = "";
            this.TotalDespesas.NM_Param = "";
            this.TotalDespesas.Operador = "";
            this.TotalDespesas.ReadOnly = true;
            this.TotalDespesas.Size = new System.Drawing.Size(100, 20);
            this.TotalDespesas.ST_AutoInc = false;
            this.TotalDespesas.ST_DisableAuto = false;
            this.TotalDespesas.ST_Gravar = false;
            this.TotalDespesas.ST_LimparCampo = true;
            this.TotalDespesas.ST_NotNull = false;
            this.TotalDespesas.ST_PrimaryKey = false;
            this.TotalDespesas.TabIndex = 86;
            this.TotalDespesas.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(301, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 85;
            this.label8.Text = "(-)Despesas:";
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Selecionar";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Width = 63;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn1.HeaderText = "Status";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 62;
            // 
            // idviagemDataGridViewTextBoxColumn
            // 
            this.idviagemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idviagemDataGridViewTextBoxColumn.DataPropertyName = "Id_viagem";
            this.idviagemDataGridViewTextBoxColumn.HeaderText = "ID.Viagem";
            this.idviagemDataGridViewTextBoxColumn.Name = "idviagemDataGridViewTextBoxColumn";
            this.idviagemDataGridViewTextBoxColumn.ReadOnly = true;
            this.idviagemDataGridViewTextBoxColumn.Width = 81;
            // 
            // dsviagemDataGridViewTextBoxColumn
            // 
            this.dsviagemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsviagemDataGridViewTextBoxColumn.DataPropertyName = "Ds_viagem";
            this.dsviagemDataGridViewTextBoxColumn.HeaderText = "Viagem";
            this.dsviagemDataGridViewTextBoxColumn.Name = "dsviagemDataGridViewTextBoxColumn";
            this.dsviagemDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsviagemDataGridViewTextBoxColumn.Width = 67;
            // 
            // dtiniDataGridViewTextBoxColumn
            // 
            this.dtiniDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtiniDataGridViewTextBoxColumn.DataPropertyName = "Dt_ini";
            this.dtiniDataGridViewTextBoxColumn.HeaderText = "DT. Início";
            this.dtiniDataGridViewTextBoxColumn.Name = "dtiniDataGridViewTextBoxColumn";
            this.dtiniDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtiniDataGridViewTextBoxColumn.Width = 80;
            // 
            // dtfinDataGridViewTextBoxColumn
            // 
            this.dtfinDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtfinDataGridViewTextBoxColumn.DataPropertyName = "Dt_fin";
            this.dtfinDataGridViewTextBoxColumn.HeaderText = "DT. Final";
            this.dtfinDataGridViewTextBoxColumn.Name = "dtfinDataGridViewTextBoxColumn";
            this.dtfinDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtfinDataGridViewTextBoxColumn.Width = 75;
            // 
            // Vl_despesas
            // 
            this.Vl_despesas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_despesas.DataPropertyName = "Vl_despesasM";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.Vl_despesas.DefaultCellStyle = dataGridViewCellStyle3;
            this.Vl_despesas.HeaderText = "Vl.Despesas Func.";
            this.Vl_despesas.Name = "Vl_despesas";
            this.Vl_despesas.ReadOnly = true;
            this.Vl_despesas.Width = 111;
            // 
            // kMiniDataGridViewTextBoxColumn
            // 
            this.kMiniDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.kMiniDataGridViewTextBoxColumn.DataPropertyName = "KM_ini";
            this.kMiniDataGridViewTextBoxColumn.HeaderText = "KM  Inicial";
            this.kMiniDataGridViewTextBoxColumn.Name = "kMiniDataGridViewTextBoxColumn";
            this.kMiniDataGridViewTextBoxColumn.ReadOnly = true;
            this.kMiniDataGridViewTextBoxColumn.Width = 75;
            // 
            // kMfinDataGridViewTextBoxColumn
            // 
            this.kMfinDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.kMfinDataGridViewTextBoxColumn.DataPropertyName = "KM_fin";
            this.kMfinDataGridViewTextBoxColumn.HeaderText = "KM  Final";
            this.kMfinDataGridViewTextBoxColumn.Name = "kMfinDataGridViewTextBoxColumn";
            this.kMfinDataGridViewTextBoxColumn.ReadOnly = true;
            this.kMfinDataGridViewTextBoxColumn.Width = 70;
            // 
            // obsDataGridViewTextBoxColumn
            // 
            this.obsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.obsDataGridViewTextBoxColumn.DataPropertyName = "Obs";
            this.obsDataGridViewTextBoxColumn.HeaderText = "Obs";
            this.obsDataGridViewTextBoxColumn.Name = "obsDataGridViewTextBoxColumn";
            this.obsDataGridViewTextBoxColumn.ReadOnly = true;
            this.obsDataGridViewTextBoxColumn.Width = 51;
            // 
            // TFAcertoViagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 433);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFAcertoViagem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acerto Viagem";
            this.Load += new System.EventHandler(this.TFAcertoViagem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAcertoViagem_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pConsulta.ResumeLayout(false);
            this.pConsulta.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gViagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsViagem)).EndInit();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaldoRestante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaldoAtual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDespesas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados pConsulta;
        private Componentes.EditDefault nm_funcionario;
        private System.Windows.Forms.Button bb_funcionario;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault cd_funcionario;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault cbEmpresa;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsViagem;
        private Componentes.DataGridDefault gViagem;
        private Componentes.PanelDados panelDados2;
        private Componentes.CheckBoxDefault cbTodos;
        private Componentes.EditFloat TotalDespesas;
        private System.Windows.Forms.Label label8;
        private Componentes.EditFloat SaldoAtual;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat TotalPagar;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat SaldoRestante;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idviagemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsviagemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtiniDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtfinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_despesas;
        private System.Windows.Forms.DataGridViewTextBoxColumn kMiniDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kMfinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn obsDataGridViewTextBoxColumn;
    }
}