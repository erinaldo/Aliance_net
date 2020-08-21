namespace Faturamento.Cadastros
{
    partial class TFProgFid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFProgFid));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bsProgFid = new System.Windows.Forms.BindingSource(this.components);
            this.qt_pontosind = new Componentes.EditFloat(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.pc_maxpontosutilizar = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nr_dias = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.qt_pontos = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tp_vl_pc = new Componentes.ComboBoxDefault(this.components);
            this.valor = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoqtvlpcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtpontosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProgFid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_pontosind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_maxpontosutilizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_dias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_pontos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(549, 43);
            this.barraMenu.TabIndex = 10;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.qt_pontosind);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.pc_maxpontosutilizar);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.nr_dias);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.qt_pontos);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.tp_vl_pc);
            this.pDados.Controls.Add(this.valor);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(549, 83);
            this.pDados.TabIndex = 11;
            // 
            // bsProgFid
            // 
            this.bsProgFid.DataSource = typeof(CamadaDados.Faturamento.Fidelizacao.TList_ProgFidelidade);
            // 
            // qt_pontosind
            // 
            this.qt_pontosind.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProgFid, "Qt_pontosind", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qt_pontosind.DecimalPlaces = 2;
            this.qt_pontosind.Location = new System.Drawing.Point(475, 29);
            this.qt_pontosind.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qt_pontosind.Name = "qt_pontosind";
            this.qt_pontosind.NM_Alias = "";
            this.qt_pontosind.NM_Campo = "";
            this.qt_pontosind.NM_Param = "";
            this.qt_pontosind.Operador = "";
            this.qt_pontosind.Size = new System.Drawing.Size(66, 20);
            this.qt_pontosind.ST_AutoInc = false;
            this.qt_pontosind.ST_DisableAuto = false;
            this.qt_pontosind.ST_Gravar = true;
            this.qt_pontosind.ST_LimparCampo = true;
            this.qt_pontosind.ST_NotNull = false;
            this.qt_pontosind.ST_PrimaryKey = false;
            this.qt_pontosind.TabIndex = 5;
            this.qt_pontosind.ThousandsSeparator = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(376, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 113;
            this.label10.Text = "Pontos Indicação:";
            // 
            // pc_maxpontosutilizar
            // 
            this.pc_maxpontosutilizar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProgFid, "Pc_maxpontosutilizar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_maxpontosutilizar.DecimalPlaces = 2;
            this.pc_maxpontosutilizar.Location = new System.Drawing.Point(376, 56);
            this.pc_maxpontosutilizar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_maxpontosutilizar.Name = "pc_maxpontosutilizar";
            this.pc_maxpontosutilizar.NM_Alias = "";
            this.pc_maxpontosutilizar.NM_Campo = "";
            this.pc_maxpontosutilizar.NM_Param = "";
            this.pc_maxpontosutilizar.Operador = "";
            this.pc_maxpontosutilizar.Size = new System.Drawing.Size(83, 20);
            this.pc_maxpontosutilizar.ST_AutoInc = false;
            this.pc_maxpontosutilizar.ST_DisableAuto = false;
            this.pc_maxpontosutilizar.ST_Gravar = true;
            this.pc_maxpontosutilizar.ST_LimparCampo = true;
            this.pc_maxpontosutilizar.ST_NotNull = false;
            this.pc_maxpontosutilizar.ST_PrimaryKey = false;
            this.pc_maxpontosutilizar.TabIndex = 8;
            this.pc_maxpontosutilizar.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "% Max. Pontos Resgatar por venda:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 102;
            this.label5.Text = "dias";
            // 
            // nr_dias
            // 
            this.nr_dias.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProgFid, "Nr_diasvalidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_dias.Location = new System.Drawing.Point(111, 56);
            this.nr_dias.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nr_dias.Name = "nr_dias";
            this.nr_dias.NM_Alias = "";
            this.nr_dias.NM_Campo = "";
            this.nr_dias.NM_Param = "";
            this.nr_dias.Operador = "";
            this.nr_dias.Size = new System.Drawing.Size(46, 20);
            this.nr_dias.ST_AutoInc = false;
            this.nr_dias.ST_DisableAuto = false;
            this.nr_dias.ST_Gravar = false;
            this.nr_dias.ST_LimparCampo = true;
            this.nr_dias.ST_NotNull = false;
            this.nr_dias.ST_PrimaryKey = false;
            this.nr_dias.TabIndex = 6;
            this.nr_dias.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 100;
            this.label4.Text = "Pontos validos por";
            // 
            // qt_pontos
            // 
            this.qt_pontos.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProgFid, "Qt_pontos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qt_pontos.DecimalPlaces = 2;
            this.qt_pontos.Location = new System.Drawing.Point(304, 29);
            this.qt_pontos.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qt_pontos.Name = "qt_pontos";
            this.qt_pontos.NM_Alias = "";
            this.qt_pontos.NM_Campo = "";
            this.qt_pontos.NM_Param = "";
            this.qt_pontos.Operador = "";
            this.qt_pontos.Size = new System.Drawing.Size(66, 20);
            this.qt_pontos.ST_AutoInc = false;
            this.qt_pontos.ST_DisableAuto = false;
            this.qt_pontos.ST_Gravar = true;
            this.qt_pontos.ST_LimparCampo = true;
            this.qt_pontos.ST_NotNull = false;
            this.qt_pontos.ST_PrimaryKey = false;
            this.qt_pontos.TabIndex = 4;
            this.qt_pontos.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "Pontos Gerados:";
            // 
            // tp_vl_pc
            // 
            this.tp_vl_pc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsProgFid, "Tp_vl_pc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_vl_pc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_vl_pc.FormattingEnabled = true;
            this.tp_vl_pc.Location = new System.Drawing.Point(160, 29);
            this.tp_vl_pc.Name = "tp_vl_pc";
            this.tp_vl_pc.NM_Alias = "";
            this.tp_vl_pc.NM_Campo = "";
            this.tp_vl_pc.NM_Param = "";
            this.tp_vl_pc.Size = new System.Drawing.Size(46, 21);
            this.tp_vl_pc.ST_Gravar = true;
            this.tp_vl_pc.ST_LimparCampo = true;
            this.tp_vl_pc.ST_NotNull = false;
            this.tp_vl_pc.TabIndex = 3;
            // 
            // valor
            // 
            this.valor.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProgFid, "Valor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.valor.DecimalPlaces = 2;
            this.valor.Location = new System.Drawing.Point(88, 29);
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
            this.valor.Size = new System.Drawing.Size(69, 20);
            this.valor.ST_AutoInc = false;
            this.valor.ST_DisableAuto = false;
            this.valor.ST_Gravar = true;
            this.valor.ST_LimparCampo = true;
            this.valor.ST_NotNull = false;
            this.valor.ST_PrimaryKey = false;
            this.valor.TabIndex = 2;
            this.valor.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Valor Base:";
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(143, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgFid, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(177, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_DS_PDV";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(364, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 94;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgFid, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(88, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(53, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Empresa:";
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoqtvlpcDataGridViewTextBoxColumn
            // 
            this.tipoqtvlpcDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipoqtvlpcDataGridViewTextBoxColumn.DataPropertyName = "Tipo_qt_vl_pc";
            this.tipoqtvlpcDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoqtvlpcDataGridViewTextBoxColumn.Name = "tipoqtvlpcDataGridViewTextBoxColumn";
            this.tipoqtvlpcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = "0";
            this.valorDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtpontosDataGridViewTextBoxColumn
            // 
            this.qtpontosDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtpontosDataGridViewTextBoxColumn.DataPropertyName = "Qt_pontos";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.qtpontosDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.qtpontosDataGridViewTextBoxColumn.HeaderText = "Qtd. Pontos";
            this.qtpontosDataGridViewTextBoxColumn.Name = "qtpontosDataGridViewTextBoxColumn";
            this.qtpontosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Qt_pontosind";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Qtd. Pontos Indicação";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // TFProgFid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 126);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFProgFid";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programação Fidelização";
            this.Load += new System.EventHandler(this.TFProgFid_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFProgFid_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProgFid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_pontosind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_maxpontosutilizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_dias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_pontos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.BindingSource bsProgFid;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat valor;
        private System.Windows.Forms.Label label2;
        private Componentes.ComboBoxDefault tp_vl_pc;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat qt_pontos;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat nr_dias;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat pc_maxpontosutilizar;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat qt_pontosind;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoqtvlpcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtpontosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}