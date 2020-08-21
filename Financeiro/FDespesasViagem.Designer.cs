namespace Financeiro
{
    partial class TFDespesasViagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDespesasViagem));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDespesas = new Componentes.PanelDados(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tp_pagamento = new Componentes.ComboBoxDefault(this.components);
            this.bsDespesas = new System.Windows.Forms.BindingSource(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.quantidade = new Componentes.EditFloat(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.bb_fornecedor = new System.Windows.Forms.Button();
            this.nm_fornecedor = new Componentes.EditDefault(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.nr_notafiscal = new Componentes.EditDefault(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.dt_despesa = new Componentes.EditData(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.ds_despesa = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bbCliente = new System.Windows.Forms.Button();
            this.cd_cliente = new Componentes.EditDefault(this.components);
            this.nm_cliente = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDespesas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDespesas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(472, 43);
            this.barraMenu.TabIndex = 11;
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
            // pDespesas
            // 
            this.pDespesas.BackColor = System.Drawing.Color.Gainsboro;
            this.pDespesas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDespesas.Controls.Add(this.nm_cliente);
            this.pDespesas.Controls.Add(this.bbCliente);
            this.pDespesas.Controls.Add(this.cd_cliente);
            this.pDespesas.Controls.Add(this.label1);
            this.pDespesas.Controls.Add(this.button1);
            this.pDespesas.Controls.Add(this.tp_pagamento);
            this.pDespesas.Controls.Add(this.label17);
            this.pDespesas.Controls.Add(this.ds_observacao);
            this.pDespesas.Controls.Add(this.label18);
            this.pDespesas.Controls.Add(this.vl_subtotal);
            this.pDespesas.Controls.Add(this.label16);
            this.pDespesas.Controls.Add(this.vl_unitario);
            this.pDespesas.Controls.Add(this.label15);
            this.pDespesas.Controls.Add(this.quantidade);
            this.pDespesas.Controls.Add(this.label14);
            this.pDespesas.Controls.Add(this.bb_fornecedor);
            this.pDespesas.Controls.Add(this.nm_fornecedor);
            this.pDespesas.Controls.Add(this.label13);
            this.pDespesas.Controls.Add(this.nr_notafiscal);
            this.pDespesas.Controls.Add(this.label12);
            this.pDespesas.Controls.Add(this.dt_despesa);
            this.pDespesas.Controls.Add(this.label11);
            this.pDespesas.Controls.Add(this.ds_despesa);
            this.pDespesas.Controls.Add(this.label10);
            this.pDespesas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDespesas.Location = new System.Drawing.Point(0, 43);
            this.pDespesas.Name = "pDespesas";
            this.pDespesas.NM_ProcDeletar = "";
            this.pDespesas.NM_ProcGravar = "";
            this.pDespesas.Size = new System.Drawing.Size(472, 300);
            this.pDespesas.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(434, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 20);
            this.button1.TabIndex = 141;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tp_pagamento
            // 
            this.tp_pagamento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsDespesas, "Tp_pagamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_pagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_pagamento.FormattingEnabled = true;
            this.tp_pagamento.Location = new System.Drawing.Point(6, 148);
            this.tp_pagamento.Name = "tp_pagamento";
            this.tp_pagamento.NM_Alias = "";
            this.tp_pagamento.NM_Campo = "Tipo de Pagamento";
            this.tp_pagamento.NM_Param = "@P_TIPO DE PAGAMENTO";
            this.tp_pagamento.Size = new System.Drawing.Size(458, 21);
            this.tp_pagamento.ST_Gravar = true;
            this.tp_pagamento.ST_LimparCampo = true;
            this.tp_pagamento.ST_NotNull = true;
            this.tp_pagamento.TabIndex = 5;
            // 
            // bsDespesas
            // 
            this.bsDespesas.DataSource = typeof(CamadaDados.Financeiro.Viagem.TList_DespesasViagem);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 132);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 13);
            this.label17.TabIndex = 122;
            this.label17.Text = "Tipo Pagamento";
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Obs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(6, 231);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(458, 60);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 11;
            this.ds_observacao.TextOld = null;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 215);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 120;
            this.label18.Text = "Observação";
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDespesas, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_subtotal.Location = new System.Drawing.Point(376, 192);
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
            this.vl_subtotal.Size = new System.Drawing.Size(88, 20);
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = true;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = true;
            this.vl_subtotal.ST_PrimaryKey = false;
            this.vl_subtotal.TabIndex = 10;
            this.vl_subtotal.ThousandsSeparator = true;
            this.vl_subtotal.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_subtotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vl_subtotal_KeyDown);
            this.vl_subtotal.Leave += new System.EventHandler(this.vl_subtotal_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(373, 176);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 116;
            this.label16.Text = "Vl. SubTotal";
            // 
            // vl_unitario
            // 
            this.vl_unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDespesas, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_unitario.DecimalPlaces = 2;
            this.vl_unitario.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_unitario.Location = new System.Drawing.Point(285, 192);
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
            this.vl_unitario.Size = new System.Drawing.Size(85, 20);
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = true;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = true;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.TabIndex = 9;
            this.vl_unitario.ThousandsSeparator = true;
            this.vl_unitario.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_unitario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vl_unitario_KeyDown);
            this.vl_unitario.Leave += new System.EventHandler(this.vl_unitario_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(282, 176);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 13);
            this.label15.TabIndex = 114;
            this.label15.Text = "Vl. Unitario";
            // 
            // quantidade
            // 
            this.quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDespesas, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.quantidade.Location = new System.Drawing.Point(192, 192);
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
            this.quantidade.Size = new System.Drawing.Size(87, 20);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = true;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = true;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 8;
            this.quantidade.ThousandsSeparator = true;
            this.quantidade.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.quantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quantidade_KeyDown);
            this.quantidade.Leave += new System.EventHandler(this.quantidade_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(189, 176);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 112;
            this.label14.Text = "Quantidade";
            // 
            // bb_fornecedor
            // 
            this.bb_fornecedor.Image = ((System.Drawing.Image)(resources.GetObject("bb_fornecedor.Image")));
            this.bb_fornecedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_fornecedor.Location = new System.Drawing.Point(400, 69);
            this.bb_fornecedor.Name = "bb_fornecedor";
            this.bb_fornecedor.Size = new System.Drawing.Size(28, 22);
            this.bb_fornecedor.TabIndex = 2;
            this.bb_fornecedor.UseVisualStyleBackColor = true;
            this.bb_fornecedor.Click += new System.EventHandler(this.bb_fornecedor_Click);
            // 
            // nm_fornecedor
            // 
            this.nm_fornecedor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_fornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_fornecedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Nm_fornecedor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_fornecedor.Location = new System.Drawing.Point(6, 70);
            this.nm_fornecedor.Name = "nm_fornecedor";
            this.nm_fornecedor.NM_Alias = "";
            this.nm_fornecedor.NM_Campo = "nm_clifor";
            this.nm_fornecedor.NM_CampoBusca = "nm_clifor";
            this.nm_fornecedor.NM_Param = "@P_NM_FORNECEDOR";
            this.nm_fornecedor.QTD_Zero = 0;
            this.nm_fornecedor.Size = new System.Drawing.Size(390, 20);
            this.nm_fornecedor.ST_AutoInc = false;
            this.nm_fornecedor.ST_DisableAuto = false;
            this.nm_fornecedor.ST_Float = false;
            this.nm_fornecedor.ST_Gravar = true;
            this.nm_fornecedor.ST_Int = false;
            this.nm_fornecedor.ST_LimpaCampo = true;
            this.nm_fornecedor.ST_NotNull = false;
            this.nm_fornecedor.ST_PrimaryKey = false;
            this.nm_fornecedor.TabIndex = 1;
            this.nm_fornecedor.TextOld = null;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 109;
            this.label13.Text = "Fornecedor";
            // 
            // nr_notafiscal
            // 
            this.nr_notafiscal.BackColor = System.Drawing.SystemColors.Window;
            this.nr_notafiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_notafiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_notafiscal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Nr_notafiscal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_notafiscal.Location = new System.Drawing.Point(93, 192);
            this.nr_notafiscal.Name = "nr_notafiscal";
            this.nr_notafiscal.NM_Alias = "";
            this.nr_notafiscal.NM_Campo = "nr_notafiscal";
            this.nr_notafiscal.NM_CampoBusca = "nr_notafiscal";
            this.nr_notafiscal.NM_Param = "@P_NR_NOTAFISCAL";
            this.nr_notafiscal.QTD_Zero = 0;
            this.nr_notafiscal.Size = new System.Drawing.Size(91, 20);
            this.nr_notafiscal.ST_AutoInc = false;
            this.nr_notafiscal.ST_DisableAuto = false;
            this.nr_notafiscal.ST_Float = false;
            this.nr_notafiscal.ST_Gravar = true;
            this.nr_notafiscal.ST_Int = false;
            this.nr_notafiscal.ST_LimpaCampo = true;
            this.nr_notafiscal.ST_NotNull = false;
            this.nr_notafiscal.ST_PrimaryKey = false;
            this.nr_notafiscal.TabIndex = 7;
            this.nr_notafiscal.TextOld = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(90, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 107;
            this.label12.Text = "Nº Nota Fiscal";
            // 
            // dt_despesa
            // 
            this.dt_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Dt_despesastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_despesa.Location = new System.Drawing.Point(6, 192);
            this.dt_despesa.Mask = "00/00/0000";
            this.dt_despesa.Name = "dt_despesa";
            this.dt_despesa.NM_Alias = "";
            this.dt_despesa.NM_Campo = "Dt.Despesa";
            this.dt_despesa.NM_CampoBusca = "dt_despesa";
            this.dt_despesa.NM_Param = "@P_DT_DESPESA";
            this.dt_despesa.Operador = "";
            this.dt_despesa.Size = new System.Drawing.Size(81, 20);
            this.dt_despesa.ST_Gravar = true;
            this.dt_despesa.ST_LimpaCampo = true;
            this.dt_despesa.ST_NotNull = true;
            this.dt_despesa.ST_PrimaryKey = false;
            this.dt_despesa.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 105;
            this.label11.Text = "Dt. Despesa";
            // 
            // ds_despesa
            // 
            this.ds_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_despesa.Location = new System.Drawing.Point(6, 23);
            this.ds_despesa.Name = "ds_despesa";
            this.ds_despesa.NM_Alias = "";
            this.ds_despesa.NM_Campo = "Despesa";
            this.ds_despesa.NM_CampoBusca = "ds_despesa";
            this.ds_despesa.NM_Param = "@P_NM_EMPRESA";
            this.ds_despesa.QTD_Zero = 0;
            this.ds_despesa.Size = new System.Drawing.Size(458, 20);
            this.ds_despesa.ST_AutoInc = false;
            this.ds_despesa.ST_DisableAuto = false;
            this.ds_despesa.ST_Float = false;
            this.ds_despesa.ST_Gravar = false;
            this.ds_despesa.ST_Int = false;
            this.ds_despesa.ST_LimpaCampo = true;
            this.ds_despesa.ST_NotNull = false;
            this.ds_despesa.ST_PrimaryKey = false;
            this.ds_despesa.TabIndex = 0;
            this.ds_despesa.TextOld = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 100;
            this.label10.Text = "Despesa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 142;
            this.label1.Text = "Cliente";
            // 
            // bbCliente
            // 
            this.bbCliente.Image = ((System.Drawing.Image)(resources.GetObject("bbCliente.Image")));
            this.bbCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbCliente.Location = new System.Drawing.Point(90, 109);
            this.bbCliente.Name = "bbCliente";
            this.bbCliente.Size = new System.Drawing.Size(29, 20);
            this.bbCliente.TabIndex = 4;
            this.bbCliente.UseVisualStyleBackColor = true;
            this.bbCliente.Click += new System.EventHandler(this.bbCliente_Click);
            // 
            // cd_cliente
            // 
            this.cd_cliente.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cliente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Cd_cliente", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_cliente.Location = new System.Drawing.Point(6, 109);
            this.cd_cliente.Name = "cd_cliente";
            this.cd_cliente.NM_Alias = "";
            this.cd_cliente.NM_Campo = "Cd_clifor";
            this.cd_cliente.NM_CampoBusca = "Cd_clifor";
            this.cd_cliente.NM_Param = "";
            this.cd_cliente.QTD_Zero = 0;
            this.cd_cliente.Size = new System.Drawing.Size(82, 20);
            this.cd_cliente.ST_AutoInc = false;
            this.cd_cliente.ST_DisableAuto = false;
            this.cd_cliente.ST_Float = false;
            this.cd_cliente.ST_Gravar = false;
            this.cd_cliente.ST_Int = false;
            this.cd_cliente.ST_LimpaCampo = true;
            this.cd_cliente.ST_NotNull = false;
            this.cd_cliente.ST_PrimaryKey = false;
            this.cd_cliente.TabIndex = 3;
            this.cd_cliente.TextOld = null;
            this.cd_cliente.Leave += new System.EventHandler(this.cd_cliente_Leave);
            // 
            // nm_cliente
            // 
            this.nm_cliente.BackColor = System.Drawing.SystemColors.Window;
            this.nm_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_cliente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Nm_cliente", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_cliente.Enabled = false;
            this.nm_cliente.Location = new System.Drawing.Point(125, 109);
            this.nm_cliente.Name = "nm_cliente";
            this.nm_cliente.NM_Alias = "";
            this.nm_cliente.NM_Campo = "nm_clifor";
            this.nm_cliente.NM_CampoBusca = "nm_clifor";
            this.nm_cliente.NM_Param = "@P_NM_CLIFOR";
            this.nm_cliente.QTD_Zero = 0;
            this.nm_cliente.Size = new System.Drawing.Size(337, 20);
            this.nm_cliente.ST_AutoInc = false;
            this.nm_cliente.ST_DisableAuto = false;
            this.nm_cliente.ST_Float = false;
            this.nm_cliente.ST_Gravar = false;
            this.nm_cliente.ST_Int = false;
            this.nm_cliente.ST_LimpaCampo = true;
            this.nm_cliente.ST_NotNull = false;
            this.nm_cliente.ST_PrimaryKey = false;
            this.nm_cliente.TabIndex = 145;
            this.nm_cliente.TextOld = null;
            // 
            // TFDespesasViagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 343);
            this.Controls.Add(this.pDespesas);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDespesasViagem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Despesas Viagem";
            this.Load += new System.EventHandler(this.TFDespesasViagem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDespesasViagem_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDespesas.ResumeLayout(false);
            this.pDespesas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDespesas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDespesas;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label18;
        private Componentes.EditFloat vl_subtotal;
        private System.Windows.Forms.Label label16;
        private Componentes.EditFloat vl_unitario;
        private System.Windows.Forms.Label label15;
        private Componentes.EditFloat quantidade;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button bb_fornecedor;
        private Componentes.EditDefault nm_fornecedor;
        private System.Windows.Forms.Label label13;
        private Componentes.EditDefault nr_notafiscal;
        private System.Windows.Forms.Label label12;
        private Componentes.EditData dt_despesa;
        private System.Windows.Forms.Label label11;
        private Componentes.EditDefault ds_despesa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource bsDespesas;
        private Componentes.ComboBoxDefault tp_pagamento;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault nm_cliente;
        private System.Windows.Forms.Button bbCliente;
        private Componentes.EditDefault cd_cliente;
    }
}