namespace Empreendimento
{
    partial class FExecucaoDespesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FExecucaoDespesas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bbBuscar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.cd_funcionario = new Componentes.EditDefault(this.components);
            this.bsDespesas = new System.Windows.Forms.BindingSource(this.components);
            this.bbFuncionario = new System.Windows.Forms.Button();
            this.nm_funcionario = new Componentes.EditDefault(this.components);
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.valor_total = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.id_regDesp = new Componentes.EditDefault(this.components);
            this.cd_fornecedor = new Componentes.EditDefault(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.tp_pagamento = new Componentes.ComboBoxDefault(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.valor = new Componentes.EditFloat(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.bb_fornecedor = new System.Windows.Forms.Button();
            this.nm_fornecedor = new Componentes.EditDefault(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.nr_notafiscal = new Componentes.EditDefault(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.dt_despesa = new Componentes.EditData(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.ds_desp = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stimportarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idRegDespDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRegDespstrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idorcamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idorcamentostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrversaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrversaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddespesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddespesastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsdespesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdunidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsunidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaunidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcargostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlbasesalarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargahorariamesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlunitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlsubtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDespesas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor_total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bbBuscar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(508, 43);
            this.barraMenu.TabIndex = 9;
            // 
            // bbBuscar
            // 
            this.bbBuscar.AutoSize = false;
            this.bbBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.bbBuscar.ForeColor = System.Drawing.Color.Green;
            this.bbBuscar.Image = ((System.Drawing.Image)(resources.GetObject("bbBuscar.Image")));
            this.bbBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bbBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbBuscar.Name = "bbBuscar";
            this.bbBuscar.Size = new System.Drawing.Size(80, 40);
            this.bbBuscar.Text = "(F4)\r\nGravar";
            this.bbBuscar.ToolTipText = "Localizar Registros";
            this.bbBuscar.Click += new System.EventHandler(this.bbBuscar_Click);
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.panelDados2);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(508, 271);
            this.panelDados1.TabIndex = 10;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.cd_funcionario);
            this.panelDados2.Controls.Add(this.bbFuncionario);
            this.panelDados2.Controls.Add(this.nm_funcionario);
            this.panelDados2.Controls.Add(this.lblFuncionario);
            this.panelDados2.Controls.Add(this.button1);
            this.panelDados2.Controls.Add(this.valor_total);
            this.panelDados2.Controls.Add(this.label2);
            this.panelDados2.Controls.Add(this.id_regDesp);
            this.panelDados2.Controls.Add(this.cd_fornecedor);
            this.panelDados2.Controls.Add(this.ds_observacao);
            this.panelDados2.Controls.Add(this.label18);
            this.panelDados2.Controls.Add(this.tp_pagamento);
            this.panelDados2.Controls.Add(this.label17);
            this.panelDados2.Controls.Add(this.valor);
            this.panelDados2.Controls.Add(this.label15);
            this.panelDados2.Controls.Add(this.bb_fornecedor);
            this.panelDados2.Controls.Add(this.nm_fornecedor);
            this.panelDados2.Controls.Add(this.label13);
            this.panelDados2.Controls.Add(this.nr_notafiscal);
            this.panelDados2.Controls.Add(this.label12);
            this.panelDados2.Controls.Add(this.dt_despesa);
            this.panelDados2.Controls.Add(this.label11);
            this.panelDados2.Controls.Add(this.ds_desp);
            this.panelDados2.Controls.Add(this.bb_empresa);
            this.panelDados2.Controls.Add(this.label1);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(0, 0);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(508, 271);
            this.panelDados2.TabIndex = 0;
            // 
            // cd_funcionario
            // 
            this.cd_funcionario.BackColor = System.Drawing.SystemColors.Window;
            this.cd_funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_funcionario.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Cd_funcionario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_funcionario.Location = new System.Drawing.Point(158, 135);
            this.cd_funcionario.Name = "cd_funcionario";
            this.cd_funcionario.NM_Alias = "";
            this.cd_funcionario.NM_Campo = "cd_clifor";
            this.cd_funcionario.NM_CampoBusca = "cd_clifor";
            this.cd_funcionario.NM_Param = "@P_CD_CLIFOR";
            this.cd_funcionario.QTD_Zero = 0;
            this.cd_funcionario.Size = new System.Drawing.Size(81, 20);
            this.cd_funcionario.ST_AutoInc = false;
            this.cd_funcionario.ST_DisableAuto = false;
            this.cd_funcionario.ST_Float = false;
            this.cd_funcionario.ST_Gravar = true;
            this.cd_funcionario.ST_Int = false;
            this.cd_funcionario.ST_LimpaCampo = true;
            this.cd_funcionario.ST_NotNull = false;
            this.cd_funcionario.ST_PrimaryKey = false;
            this.cd_funcionario.TabIndex = 9;
            this.cd_funcionario.TextOld = null;
            this.cd_funcionario.Visible = false;
            this.cd_funcionario.VisibleChanged += new System.EventHandler(this.cd_funcionario_VisibleChanged);
            this.cd_funcionario.Leave += new System.EventHandler(this.cd_funcionario_Leave);
            // 
            // bsDespesas
            // 
            this.bsDespesas.DataSource = typeof(CamadaDados.Empreendimento.TList_ExecDespesas);
            // 
            // bbFuncionario
            // 
            this.bbFuncionario.Image = ((System.Drawing.Image)(resources.GetObject("bbFuncionario.Image")));
            this.bbFuncionario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbFuncionario.Location = new System.Drawing.Point(245, 135);
            this.bbFuncionario.Name = "bbFuncionario";
            this.bbFuncionario.Size = new System.Drawing.Size(28, 22);
            this.bbFuncionario.TabIndex = 10;
            this.bbFuncionario.UseVisualStyleBackColor = true;
            this.bbFuncionario.Click += new System.EventHandler(this.bbFuncionario_Click);
            // 
            // nm_funcionario
            // 
            this.nm_funcionario.BackColor = System.Drawing.SystemColors.Window;
            this.nm_funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_funcionario.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Nm_funcionario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_funcionario.Enabled = false;
            this.nm_funcionario.Location = new System.Drawing.Point(279, 135);
            this.nm_funcionario.Name = "nm_funcionario";
            this.nm_funcionario.NM_Alias = "";
            this.nm_funcionario.NM_Campo = "nm_clifor";
            this.nm_funcionario.NM_CampoBusca = "nm_clifor";
            this.nm_funcionario.NM_Param = "@P_NM_FORNECEDOR";
            this.nm_funcionario.QTD_Zero = 0;
            this.nm_funcionario.Size = new System.Drawing.Size(214, 20);
            this.nm_funcionario.ST_AutoInc = false;
            this.nm_funcionario.ST_DisableAuto = false;
            this.nm_funcionario.ST_Float = false;
            this.nm_funcionario.ST_Gravar = true;
            this.nm_funcionario.ST_Int = false;
            this.nm_funcionario.ST_LimpaCampo = true;
            this.nm_funcionario.ST_NotNull = true;
            this.nm_funcionario.ST_PrimaryKey = false;
            this.nm_funcionario.TabIndex = 143;
            this.nm_funcionario.TextOld = null;
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.AutoSize = true;
            this.lblFuncionario.Location = new System.Drawing.Point(155, 121);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(62, 13);
            this.lblFuncionario.TabIndex = 144;
            this.lblFuncionario.Text = "Funcionario";
            this.lblFuncionario.Visible = false;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(124, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 20);
            this.button1.TabIndex = 140;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // valor_total
            // 
            this.valor_total.DecimalPlaces = 2;
            this.valor_total.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valor_total.Location = new System.Drawing.Point(320, 97);
            this.valor_total.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.valor_total.Name = "valor_total";
            this.valor_total.NM_Alias = "";
            this.valor_total.NM_Campo = "";
            this.valor_total.NM_Param = "";
            this.valor_total.Operador = "";
            this.valor_total.ReadOnly = true;
            this.valor_total.Size = new System.Drawing.Size(85, 20);
            this.valor_total.ST_AutoInc = false;
            this.valor_total.ST_DisableAuto = false;
            this.valor_total.ST_Gravar = true;
            this.valor_total.ST_LimparCampo = true;
            this.valor_total.ST_NotNull = false;
            this.valor_total.ST_PrimaryKey = false;
            this.valor_total.TabIndex = 7;
            this.valor_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valor_total.ThousandsSeparator = true;
            this.valor_total.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 139;
            this.label2.Text = "Valor Total";
            // 
            // id_regDesp
            // 
            this.id_regDesp.BackColor = System.Drawing.SystemColors.Window;
            this.id_regDesp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_regDesp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_regDesp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Id_RegDesp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_regDesp.Location = new System.Drawing.Point(7, 22);
            this.id_regDesp.Name = "id_regDesp";
            this.id_regDesp.NM_Alias = "";
            this.id_regDesp.NM_Campo = "id_regdesp";
            this.id_regDesp.NM_CampoBusca = "id_regdesp";
            this.id_regDesp.NM_Param = "@P_ID_REGDESP";
            this.id_regDesp.QTD_Zero = 0;
            this.id_regDesp.Size = new System.Drawing.Size(81, 20);
            this.id_regDesp.ST_AutoInc = false;
            this.id_regDesp.ST_DisableAuto = false;
            this.id_regDesp.ST_Float = false;
            this.id_regDesp.ST_Gravar = false;
            this.id_regDesp.ST_Int = false;
            this.id_regDesp.ST_LimpaCampo = true;
            this.id_regDesp.ST_NotNull = false;
            this.id_regDesp.ST_PrimaryKey = false;
            this.id_regDesp.TabIndex = 0;
            this.id_regDesp.TextOld = null;
            this.id_regDesp.Leave += new System.EventHandler(this.id_regDesp_Leave);
            // 
            // cd_fornecedor
            // 
            this.cd_fornecedor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_fornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_fornecedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Cd_fornecedor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_fornecedor.Location = new System.Drawing.Point(7, 59);
            this.cd_fornecedor.Name = "cd_fornecedor";
            this.cd_fornecedor.NM_Alias = "";
            this.cd_fornecedor.NM_Campo = "cd_clifor";
            this.cd_fornecedor.NM_CampoBusca = "cd_clifor";
            this.cd_fornecedor.NM_Param = "@P_CD_CLIFOR";
            this.cd_fornecedor.QTD_Zero = 0;
            this.cd_fornecedor.Size = new System.Drawing.Size(81, 20);
            this.cd_fornecedor.ST_AutoInc = false;
            this.cd_fornecedor.ST_DisableAuto = false;
            this.cd_fornecedor.ST_Float = false;
            this.cd_fornecedor.ST_Gravar = false;
            this.cd_fornecedor.ST_Int = false;
            this.cd_fornecedor.ST_LimpaCampo = true;
            this.cd_fornecedor.ST_NotNull = false;
            this.cd_fornecedor.ST_PrimaryKey = false;
            this.cd_fornecedor.TabIndex = 2;
            this.cd_fornecedor.TextOld = null;
            this.cd_fornecedor.Leave += new System.EventHandler(this.CD_CLIFOR_Leave);
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "obs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(7, 175);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(486, 81);
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
            this.label18.Location = new System.Drawing.Point(4, 159);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 137;
            this.label18.Text = "Observação";
            // 
            // tp_pagamento
            // 
            this.tp_pagamento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsDespesas, "Tp_pagamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_pagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_pagamento.FormattingEnabled = true;
            this.tp_pagamento.Location = new System.Drawing.Point(7, 135);
            this.tp_pagamento.Name = "tp_pagamento";
            this.tp_pagamento.NM_Alias = "";
            this.tp_pagamento.NM_Campo = "";
            this.tp_pagamento.NM_Param = "";
            this.tp_pagamento.Size = new System.Drawing.Size(145, 21);
            this.tp_pagamento.ST_Gravar = true;
            this.tp_pagamento.ST_LimparCampo = true;
            this.tp_pagamento.ST_NotNull = true;
            this.tp_pagamento.TabIndex = 8;
            this.tp_pagamento.SelectedIndexChanged += new System.EventHandler(this.tp_pagamento_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 119);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 13);
            this.label17.TabIndex = 136;
            this.label17.Text = "Tipo Pagamento";
            // 
            // valor
            // 
            this.valor.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDespesas, "vl_executado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.valor.DecimalPlaces = 2;
            this.valor.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valor.Location = new System.Drawing.Point(229, 97);
            this.valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.valor.Name = "valor";
            this.valor.NM_Alias = "";
            this.valor.NM_Campo = "";
            this.valor.NM_Param = "";
            this.valor.Operador = "";
            this.valor.Size = new System.Drawing.Size(85, 20);
            this.valor.ST_AutoInc = false;
            this.valor.ST_DisableAuto = false;
            this.valor.ST_Gravar = true;
            this.valor.ST_LimparCampo = true;
            this.valor.ST_NotNull = true;
            this.valor.ST_PrimaryKey = false;
            this.valor.TabIndex = 6;
            this.valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valor.ThousandsSeparator = true;
            this.valor.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valor.Leave += new System.EventHandler(this.valor_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(227, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 134;
            this.label15.Text = "Valor";
            // 
            // bb_fornecedor
            // 
            this.bb_fornecedor.Image = ((System.Drawing.Image)(resources.GetObject("bb_fornecedor.Image")));
            this.bb_fornecedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_fornecedor.Location = new System.Drawing.Point(94, 59);
            this.bb_fornecedor.Name = "bb_fornecedor";
            this.bb_fornecedor.Size = new System.Drawing.Size(28, 22);
            this.bb_fornecedor.TabIndex = 3;
            this.bb_fornecedor.UseVisualStyleBackColor = true;
            this.bb_fornecedor.Click += new System.EventHandler(this.bb_fornecedor_Click);
            // 
            // nm_fornecedor
            // 
            this.nm_fornecedor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_fornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_fornecedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Nm_fornecedor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_fornecedor.Enabled = false;
            this.nm_fornecedor.Location = new System.Drawing.Point(157, 59);
            this.nm_fornecedor.Name = "nm_fornecedor";
            this.nm_fornecedor.NM_Alias = "";
            this.nm_fornecedor.NM_Campo = "nm_clifor";
            this.nm_fornecedor.NM_CampoBusca = "nm_clifor";
            this.nm_fornecedor.NM_Param = "@P_NM_FORNECEDOR";
            this.nm_fornecedor.QTD_Zero = 0;
            this.nm_fornecedor.Size = new System.Drawing.Size(336, 20);
            this.nm_fornecedor.ST_AutoInc = false;
            this.nm_fornecedor.ST_DisableAuto = false;
            this.nm_fornecedor.ST_Float = false;
            this.nm_fornecedor.ST_Gravar = false;
            this.nm_fornecedor.ST_Int = false;
            this.nm_fornecedor.ST_LimpaCampo = true;
            this.nm_fornecedor.ST_NotNull = false;
            this.nm_fornecedor.ST_PrimaryKey = false;
            this.nm_fornecedor.TabIndex = 123;
            this.nm_fornecedor.TextOld = null;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 132;
            this.label13.Text = "Fornecedor";
            // 
            // nr_notafiscal
            // 
            this.nr_notafiscal.BackColor = System.Drawing.SystemColors.Window;
            this.nr_notafiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_notafiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_notafiscal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Nr_docto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_notafiscal.Location = new System.Drawing.Point(94, 97);
            this.nr_notafiscal.Name = "nr_notafiscal";
            this.nr_notafiscal.NM_Alias = "";
            this.nr_notafiscal.NM_Campo = "nr_notafiscal";
            this.nr_notafiscal.NM_CampoBusca = "nr_notafiscal";
            this.nr_notafiscal.NM_Param = "@P_NR_NOTAFISCAL";
            this.nr_notafiscal.QTD_Zero = 0;
            this.nr_notafiscal.Size = new System.Drawing.Size(129, 20);
            this.nr_notafiscal.ST_AutoInc = false;
            this.nr_notafiscal.ST_DisableAuto = false;
            this.nr_notafiscal.ST_Float = false;
            this.nr_notafiscal.ST_Gravar = true;
            this.nr_notafiscal.ST_Int = false;
            this.nr_notafiscal.ST_LimpaCampo = true;
            this.nr_notafiscal.ST_NotNull = true;
            this.nr_notafiscal.ST_PrimaryKey = false;
            this.nr_notafiscal.TabIndex = 5;
            this.nr_notafiscal.TextOld = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(91, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 131;
            this.label12.Text = "Nº Docto";
            // 
            // dt_despesa
            // 
            this.dt_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Dt_execucaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_despesa.Location = new System.Drawing.Point(7, 97);
            this.dt_despesa.Mask = "00/00/0000";
            this.dt_despesa.Name = "dt_despesa";
            this.dt_despesa.NM_Alias = "";
            this.dt_despesa.NM_Campo = "dt_despesa";
            this.dt_despesa.NM_CampoBusca = "dt_despesa";
            this.dt_despesa.NM_Param = "@P_DT_DESPESA";
            this.dt_despesa.Operador = "";
            this.dt_despesa.Size = new System.Drawing.Size(81, 20);
            this.dt_despesa.ST_Gravar = true;
            this.dt_despesa.ST_LimpaCampo = true;
            this.dt_despesa.ST_NotNull = true;
            this.dt_despesa.ST_PrimaryKey = false;
            this.dt_despesa.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 130;
            this.label11.Text = "Dt. Despesa";
            // 
            // ds_desp
            // 
            this.ds_desp.BackColor = System.Drawing.SystemColors.Window;
            this.ds_desp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_desp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_desp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesas, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_desp.Enabled = false;
            this.ds_desp.Location = new System.Drawing.Point(129, 22);
            this.ds_desp.Name = "ds_desp";
            this.ds_desp.NM_Alias = "";
            this.ds_desp.NM_Campo = "ds_despesa";
            this.ds_desp.NM_CampoBusca = "ds_despesa";
            this.ds_desp.NM_Param = "@P_DS_DESPESA";
            this.ds_desp.QTD_Zero = 0;
            this.ds_desp.Size = new System.Drawing.Size(364, 20);
            this.ds_desp.ST_AutoInc = false;
            this.ds_desp.ST_DisableAuto = false;
            this.ds_desp.ST_Float = false;
            this.ds_desp.ST_Gravar = false;
            this.ds_desp.ST_Int = false;
            this.ds_desp.ST_LimpaCampo = true;
            this.ds_desp.ST_NotNull = false;
            this.ds_desp.ST_PrimaryKey = false;
            this.ds_desp.TabIndex = 13;
            this.ds_desp.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(94, 22);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Despesa";
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdempresaDataGridViewTextBoxColumn,
            this.stimportarDataGridViewCheckBoxColumn,
            this.idRegDespDataGridViewTextBoxColumn,
            this.idRegDespstrDataGridViewTextBoxColumn,
            this.idorcamentoDataGridViewTextBoxColumn,
            this.idorcamentostrDataGridViewTextBoxColumn,
            this.nrversaoDataGridViewTextBoxColumn,
            this.nrversaostrDataGridViewTextBoxColumn,
            this.iddespesaDataGridViewTextBoxColumn,
            this.iddespesastrDataGridViewTextBoxColumn,
            this.dsdespesaDataGridViewTextBoxColumn,
            this.cdunidadeDataGridViewTextBoxColumn,
            this.dsunidadeDataGridViewTextBoxColumn,
            this.siglaunidadeDataGridViewTextBoxColumn,
            this.idcargoDataGridViewTextBoxColumn,
            this.idcargostrDataGridViewTextBoxColumn,
            this.dscargoDataGridViewTextBoxColumn,
            this.vlbasesalarioDataGridViewTextBoxColumn,
            this.cargahorariamesDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.vlunitarioDataGridViewTextBoxColumn,
            this.vlsubtotalDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsDespesas;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(857, 193);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stimportarDataGridViewCheckBoxColumn
            // 
            this.stimportarDataGridViewCheckBoxColumn.DataPropertyName = "st_importar";
            this.stimportarDataGridViewCheckBoxColumn.HeaderText = "st_importar";
            this.stimportarDataGridViewCheckBoxColumn.Name = "stimportarDataGridViewCheckBoxColumn";
            this.stimportarDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // idRegDespDataGridViewTextBoxColumn
            // 
            this.idRegDespDataGridViewTextBoxColumn.DataPropertyName = "Id_RegDesp";
            this.idRegDespDataGridViewTextBoxColumn.HeaderText = "Id_RegDesp";
            this.idRegDespDataGridViewTextBoxColumn.Name = "idRegDespDataGridViewTextBoxColumn";
            this.idRegDespDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idRegDespstrDataGridViewTextBoxColumn
            // 
            this.idRegDespstrDataGridViewTextBoxColumn.DataPropertyName = "Id_RegDespstr";
            this.idRegDespstrDataGridViewTextBoxColumn.HeaderText = "Id_RegDespstr";
            this.idRegDespstrDataGridViewTextBoxColumn.Name = "idRegDespstrDataGridViewTextBoxColumn";
            this.idRegDespstrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idorcamentoDataGridViewTextBoxColumn
            // 
            this.idorcamentoDataGridViewTextBoxColumn.DataPropertyName = "Id_orcamento";
            this.idorcamentoDataGridViewTextBoxColumn.HeaderText = "Id_orcamento";
            this.idorcamentoDataGridViewTextBoxColumn.Name = "idorcamentoDataGridViewTextBoxColumn";
            this.idorcamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idorcamentostrDataGridViewTextBoxColumn
            // 
            this.idorcamentostrDataGridViewTextBoxColumn.DataPropertyName = "Id_orcamentostr";
            this.idorcamentostrDataGridViewTextBoxColumn.HeaderText = "Id_orcamentostr";
            this.idorcamentostrDataGridViewTextBoxColumn.Name = "idorcamentostrDataGridViewTextBoxColumn";
            this.idorcamentostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrversaoDataGridViewTextBoxColumn
            // 
            this.nrversaoDataGridViewTextBoxColumn.DataPropertyName = "Nr_versao";
            this.nrversaoDataGridViewTextBoxColumn.HeaderText = "Nr_versao";
            this.nrversaoDataGridViewTextBoxColumn.Name = "nrversaoDataGridViewTextBoxColumn";
            this.nrversaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrversaostrDataGridViewTextBoxColumn
            // 
            this.nrversaostrDataGridViewTextBoxColumn.DataPropertyName = "Nr_versaostr";
            this.nrversaostrDataGridViewTextBoxColumn.HeaderText = "Nr_versaostr";
            this.nrversaostrDataGridViewTextBoxColumn.Name = "nrversaostrDataGridViewTextBoxColumn";
            this.nrversaostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iddespesaDataGridViewTextBoxColumn
            // 
            this.iddespesaDataGridViewTextBoxColumn.DataPropertyName = "Id_despesa";
            this.iddespesaDataGridViewTextBoxColumn.HeaderText = "Id_despesa";
            this.iddespesaDataGridViewTextBoxColumn.Name = "iddespesaDataGridViewTextBoxColumn";
            this.iddespesaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iddespesastrDataGridViewTextBoxColumn
            // 
            this.iddespesastrDataGridViewTextBoxColumn.DataPropertyName = "Id_despesastr";
            this.iddespesastrDataGridViewTextBoxColumn.HeaderText = "Id_despesastr";
            this.iddespesastrDataGridViewTextBoxColumn.Name = "iddespesastrDataGridViewTextBoxColumn";
            this.iddespesastrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsdespesaDataGridViewTextBoxColumn
            // 
            this.dsdespesaDataGridViewTextBoxColumn.DataPropertyName = "Ds_despesa";
            this.dsdespesaDataGridViewTextBoxColumn.HeaderText = "Ds_despesa";
            this.dsdespesaDataGridViewTextBoxColumn.Name = "dsdespesaDataGridViewTextBoxColumn";
            this.dsdespesaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdunidadeDataGridViewTextBoxColumn
            // 
            this.cdunidadeDataGridViewTextBoxColumn.DataPropertyName = "Cd_unidade";
            this.cdunidadeDataGridViewTextBoxColumn.HeaderText = "Cd_unidade";
            this.cdunidadeDataGridViewTextBoxColumn.Name = "cdunidadeDataGridViewTextBoxColumn";
            this.cdunidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsunidadeDataGridViewTextBoxColumn
            // 
            this.dsunidadeDataGridViewTextBoxColumn.DataPropertyName = "Ds_unidade";
            this.dsunidadeDataGridViewTextBoxColumn.HeaderText = "Ds_unidade";
            this.dsunidadeDataGridViewTextBoxColumn.Name = "dsunidadeDataGridViewTextBoxColumn";
            this.dsunidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siglaunidadeDataGridViewTextBoxColumn
            // 
            this.siglaunidadeDataGridViewTextBoxColumn.DataPropertyName = "Sigla_unidade";
            this.siglaunidadeDataGridViewTextBoxColumn.HeaderText = "Sigla_unidade";
            this.siglaunidadeDataGridViewTextBoxColumn.Name = "siglaunidadeDataGridViewTextBoxColumn";
            this.siglaunidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idcargoDataGridViewTextBoxColumn
            // 
            this.idcargoDataGridViewTextBoxColumn.DataPropertyName = "Id_cargo";
            this.idcargoDataGridViewTextBoxColumn.HeaderText = "Id_cargo";
            this.idcargoDataGridViewTextBoxColumn.Name = "idcargoDataGridViewTextBoxColumn";
            this.idcargoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idcargostrDataGridViewTextBoxColumn
            // 
            this.idcargostrDataGridViewTextBoxColumn.DataPropertyName = "Id_cargostr";
            this.idcargostrDataGridViewTextBoxColumn.HeaderText = "Id_cargostr";
            this.idcargostrDataGridViewTextBoxColumn.Name = "idcargostrDataGridViewTextBoxColumn";
            this.idcargostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dscargoDataGridViewTextBoxColumn
            // 
            this.dscargoDataGridViewTextBoxColumn.DataPropertyName = "Ds_cargo";
            this.dscargoDataGridViewTextBoxColumn.HeaderText = "Ds_cargo";
            this.dscargoDataGridViewTextBoxColumn.Name = "dscargoDataGridViewTextBoxColumn";
            this.dscargoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlbasesalarioDataGridViewTextBoxColumn
            // 
            this.vlbasesalarioDataGridViewTextBoxColumn.DataPropertyName = "Vl_basesalario";
            this.vlbasesalarioDataGridViewTextBoxColumn.HeaderText = "Vl_basesalario";
            this.vlbasesalarioDataGridViewTextBoxColumn.Name = "vlbasesalarioDataGridViewTextBoxColumn";
            this.vlbasesalarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cargahorariamesDataGridViewTextBoxColumn
            // 
            this.cargahorariamesDataGridViewTextBoxColumn.DataPropertyName = "Cargahorariames";
            this.cargahorariamesDataGridViewTextBoxColumn.HeaderText = "Cargahorariames";
            this.cargahorariamesDataGridViewTextBoxColumn.Name = "cargahorariamesDataGridViewTextBoxColumn";
            this.cargahorariamesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlunitarioDataGridViewTextBoxColumn
            // 
            this.vlunitarioDataGridViewTextBoxColumn.DataPropertyName = "Vl_unitario";
            this.vlunitarioDataGridViewTextBoxColumn.HeaderText = "Vl_unitario";
            this.vlunitarioDataGridViewTextBoxColumn.Name = "vlunitarioDataGridViewTextBoxColumn";
            this.vlunitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlsubtotalDataGridViewTextBoxColumn
            // 
            this.vlsubtotalDataGridViewTextBoxColumn.DataPropertyName = "Vl_subtotal";
            this.vlsubtotalDataGridViewTextBoxColumn.HeaderText = "Vl_subtotal";
            this.vlsubtotalDataGridViewTextBoxColumn.Name = "vlsubtotalDataGridViewTextBoxColumn";
            this.vlsubtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FExecucaoDespesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 314);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FExecucaoDespesas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Execução de despesas";
            this.Load += new System.EventHandler(this.FExecucaoDespesas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FExecucaoDespesas_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDespesas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor_total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bbBuscar;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stimportarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRegDespDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRegDespstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idorcamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idorcamentostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrversaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrversaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddespesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddespesastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsdespesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcargostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlbasesalarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargahorariamesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlsubtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsDespesas;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault ds_desp;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label18;
        private Componentes.ComboBoxDefault tp_pagamento;
        private System.Windows.Forms.Label label17;
        private Componentes.EditFloat valor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bb_fornecedor;
        private Componentes.EditDefault nm_fornecedor;
        private System.Windows.Forms.Label label13;
        private Componentes.EditDefault nr_notafiscal;
        private System.Windows.Forms.Label label12;
        private Componentes.EditData dt_despesa;
        private System.Windows.Forms.Label label11;
        private Componentes.EditDefault cd_fornecedor;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.EditDefault id_regDesp;
        private Componentes.EditFloat valor_total;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private Componentes.EditDefault cd_funcionario;
        private System.Windows.Forms.Button bbFuncionario;
        private Componentes.EditDefault nm_funcionario;
        private System.Windows.Forms.Label lblFuncionario;
    }
}