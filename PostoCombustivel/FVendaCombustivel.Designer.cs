namespace PostoCombustivel
{
    partial class TFVendaCombustivel
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
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFVendaCombustivel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.encerranteFinal = new Componentes.EditFloat(this.components);
            this.bsVendaCombustivel = new System.Windows.Forms.BindingSource(this.components);
            this.encerranteIni = new Componentes.EditFloat(this.components);
            this.gBico = new Componentes.DataGridDefault(this.components);
            this.stprocessarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dslabelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsBico = new System.Windows.Forms.BindingSource(this.components);
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.volumeabastecido = new Componentes.EditFloat(this.components);
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encerranteFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVendaCombustivel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encerranteIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gBico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeabastecido)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(10, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(48, 13);
            label8.TabIndex = 120;
            label8.Text = "Empresa";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(445, 336);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(65, 13);
            label6.TabIndex = 114;
            label6.Text = "Vl. SubTotal";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(302, 336);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(58, 13);
            label5.TabIndex = 112;
            label5.Text = "Vl. Unitario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(138, 336);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(98, 13);
            label3.TabIndex = 111;
            label3.Text = "Volume Abastecido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(10, 336);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(89, 13);
            label1.TabIndex = 124;
            label1.Text = "Encerrante Inicial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(592, 335);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(84, 13);
            label2.TabIndex = 126;
            label2.Text = "Encerrante Final";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(727, 43);
            this.barraMenu.TabIndex = 6;
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
            this.BB_Gravar.Size = new System.Drawing.Size(95, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Confirmar vendas para faturar";
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.cbEmpresa);
            this.pDados.Controls.Add(this.encerranteFinal);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.encerranteIni);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.gBico);
            this.pDados.Controls.Add(label8);
            this.pDados.Controls.Add(this.sigla_unidade);
            this.pDados.Controls.Add(this.vl_subtotal);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.vl_unitario);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.volumeabastecido);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(727, 384);
            this.pDados.TabIndex = 7;
            // 
            // encerranteFinal
            // 
            this.encerranteFinal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsVendaCombustivel, "Encerrantebico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.encerranteFinal.DecimalPlaces = 3;
            this.encerranteFinal.Enabled = false;
            this.encerranteFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encerranteFinal.Location = new System.Drawing.Point(592, 351);
            this.encerranteFinal.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.encerranteFinal.Name = "encerranteFinal";
            this.encerranteFinal.NM_Alias = "";
            this.encerranteFinal.NM_Campo = "volumeabastecido";
            this.encerranteFinal.NM_Param = "@P_VOLUMEABASTECIDO";
            this.encerranteFinal.Operador = "";
            this.encerranteFinal.Size = new System.Drawing.Size(125, 26);
            this.encerranteFinal.ST_AutoInc = false;
            this.encerranteFinal.ST_DisableAuto = false;
            this.encerranteFinal.ST_Gravar = true;
            this.encerranteFinal.ST_LimparCampo = true;
            this.encerranteFinal.ST_NotNull = true;
            this.encerranteFinal.ST_PrimaryKey = false;
            this.encerranteFinal.TabIndex = 127;
            this.encerranteFinal.ThousandsSeparator = true;
            this.encerranteFinal.Leave += new System.EventHandler(this.encerranteFinal_Leave);
            // 
            // bsVendaCombustivel
            // 
            this.bsVendaCombustivel.DataSource = typeof(CamadaDados.PostoCombustivel.TList_VendaCombustivel);
            // 
            // encerranteIni
            // 
            this.encerranteIni.DecimalPlaces = 3;
            this.encerranteIni.Enabled = false;
            this.encerranteIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encerranteIni.Location = new System.Drawing.Point(10, 352);
            this.encerranteIni.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.encerranteIni.Name = "encerranteIni";
            this.encerranteIni.NM_Alias = "";
            this.encerranteIni.NM_Campo = "volumeabastecido";
            this.encerranteIni.NM_Param = "@P_VOLUMEABASTECIDO";
            this.encerranteIni.Operador = "";
            this.encerranteIni.Size = new System.Drawing.Size(125, 26);
            this.encerranteIni.ST_AutoInc = false;
            this.encerranteIni.ST_DisableAuto = false;
            this.encerranteIni.ST_Gravar = true;
            this.encerranteIni.ST_LimparCampo = true;
            this.encerranteIni.ST_NotNull = true;
            this.encerranteIni.ST_PrimaryKey = false;
            this.encerranteIni.TabIndex = 125;
            this.encerranteIni.ThousandsSeparator = true;
            // 
            // gBico
            // 
            this.gBico.AllowUserToAddRows = false;
            this.gBico.AllowUserToDeleteRows = false;
            this.gBico.AllowUserToOrderColumns = true;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gBico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.gBico.AutoGenerateColumns = false;
            this.gBico.BackgroundColor = System.Drawing.Color.LightGray;
            this.gBico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gBico.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gBico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gBico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stprocessarDataGridViewCheckBoxColumn,
            this.dslabelDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn});
            this.gBico.DataSource = this.bsBico;
            this.gBico.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gBico.Location = new System.Drawing.Point(10, 43);
            this.gBico.Name = "gBico";
            this.gBico.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBico.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.gBico.RowHeadersWidth = 23;
            this.gBico.Size = new System.Drawing.Size(703, 287);
            this.gBico.TabIndex = 123;
            this.gBico.TabStop = false;
            this.gBico.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gBico_CellClick);
            // 
            // stprocessarDataGridViewCheckBoxColumn
            // 
            this.stprocessarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stprocessarDataGridViewCheckBoxColumn.DataPropertyName = "St_processar";
            this.stprocessarDataGridViewCheckBoxColumn.HeaderText = "Marcar";
            this.stprocessarDataGridViewCheckBoxColumn.Name = "stprocessarDataGridViewCheckBoxColumn";
            this.stprocessarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stprocessarDataGridViewCheckBoxColumn.Width = 46;
            // 
            // dslabelDataGridViewTextBoxColumn
            // 
            this.dslabelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dslabelDataGridViewTextBoxColumn.DataPropertyName = "Ds_label";
            this.dslabelDataGridViewTextBoxColumn.HeaderText = "Nº Bico";
            this.dslabelDataGridViewTextBoxColumn.Name = "dslabelDataGridViewTextBoxColumn";
            this.dslabelDataGridViewTextBoxColumn.ReadOnly = true;
            this.dslabelDataGridViewTextBoxColumn.Width = 68;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Combustivel";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsBico
            // 
            this.bsBico.DataSource = typeof(CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba);
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sigla_unidade.Location = new System.Drawing.Point(273, 352);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "sigla_unidade";
            this.sigla_unidade.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidade.NM_Param = "@P_NM_CLIFOR";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.Size = new System.Drawing.Size(26, 26);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 118;
            this.sigla_unidade.TextOld = null;
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsVendaCombustivel, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_subtotal.Location = new System.Drawing.Point(448, 352);
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
            this.vl_subtotal.Size = new System.Drawing.Size(138, 26);
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = true;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = true;
            this.vl_subtotal.ST_PrimaryKey = false;
            this.vl_subtotal.TabIndex = 7;
            this.vl_subtotal.ThousandsSeparator = true;
            this.vl_subtotal.Leave += new System.EventHandler(this.vl_subtotal_Leave);
            // 
            // vl_unitario
            // 
            this.vl_unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsVendaCombustivel, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_unitario.DecimalPlaces = 7;
            this.vl_unitario.Enabled = false;
            this.vl_unitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_unitario.Location = new System.Drawing.Point(305, 352);
            this.vl_unitario.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_unitario.Name = "vl_unitario";
            this.vl_unitario.NM_Alias = "";
            this.vl_unitario.NM_Campo = "vl_unitario";
            this.vl_unitario.NM_Param = "@P_VL_UNITARIO";
            this.vl_unitario.Operador = "";
            this.vl_unitario.Size = new System.Drawing.Size(137, 26);
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = true;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = true;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.TabIndex = 6;
            this.vl_unitario.ThousandsSeparator = true;
            // 
            // volumeabastecido
            // 
            this.volumeabastecido.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsVendaCombustivel, "Volumeabastecido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.volumeabastecido.DecimalPlaces = 3;
            this.volumeabastecido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeabastecido.Location = new System.Drawing.Point(141, 352);
            this.volumeabastecido.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.volumeabastecido.Name = "volumeabastecido";
            this.volumeabastecido.NM_Alias = "";
            this.volumeabastecido.NM_Campo = "volumeabastecido";
            this.volumeabastecido.NM_Param = "@P_VOLUMEABASTECIDO";
            this.volumeabastecido.Operador = "";
            this.volumeabastecido.Size = new System.Drawing.Size(130, 26);
            this.volumeabastecido.ST_AutoInc = false;
            this.volumeabastecido.ST_DisableAuto = false;
            this.volumeabastecido.ST_Gravar = true;
            this.volumeabastecido.ST_LimparCampo = true;
            this.volumeabastecido.ST_NotNull = true;
            this.volumeabastecido.ST_PrimaryKey = false;
            this.volumeabastecido.TabIndex = 5;
            this.volumeabastecido.ThousandsSeparator = true;
            this.volumeabastecido.Leave += new System.EventHandler(this.volumeabastecido_Leave);
            this.volumeabastecido.Enter += new System.EventHandler(this.volumeabastecido_Enter);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bsVendaCombustivel, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsVendaCombustivel, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(10, 16);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(703, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 129;
            this.cbEmpresa.Leave += new System.EventHandler(this.cbEmpresa_Leave);
            // 
            // TFVendaCombustivel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 427);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFVendaCombustivel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada Manual de Venda Combustivel";
            this.Load += new System.EventHandler(this.TFVendaCombustivel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFVendaCombustivel_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encerranteFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVendaCombustivel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encerranteIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gBico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeabastecido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditFloat volumeabastecido;
        private Componentes.EditFloat vl_subtotal;
        private Componentes.EditFloat vl_unitario;
        private System.Windows.Forms.BindingSource bsVendaCombustivel;
        private Componentes.EditDefault sigla_unidade;
        private Componentes.DataGridDefault gBico;
        private System.Windows.Forms.BindingSource bsBico;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dslabelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private Componentes.EditFloat encerranteIni;
        private Componentes.EditFloat encerranteFinal;
        private Componentes.ComboBoxDefault cbEmpresa;
    }
}