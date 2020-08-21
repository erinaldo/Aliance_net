namespace Financeiro.Cadastros
{
    partial class TFCondPGTO_X_Parcelas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCondPGTO_X_Parcelas));
            this.tc = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gCondicaoXparcelas = new Componentes.DataGridDefault(this.components);
            this.cdcondpgtoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idparcelaDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdiasDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcrateioDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_CondPgtoXParcelas = new System.Windows.Forms.BindingSource(this.components);
            this.pDadosParcelas = new Componentes.PanelDados(this.components);
            this.ds_condpgto = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pcRateio = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.diasDesdobro = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.BS_CondPagamento = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idparcelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdiasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcrateioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_gravar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancela = new System.Windows.Forms.ToolStripButton();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bbGravar = new System.Windows.Forms.ToolStripButton();
            this.bbCancelar = new System.Windows.Forms.ToolStripButton();
            this.tc.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCondicaoXparcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CondPgtoXParcelas)).BeginInit();
            this.pDadosParcelas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcRateio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasDesdobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CondPagamento)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc
            // 
            this.tc.Controls.Add(this.tabPage1);
            this.tc.Location = new System.Drawing.Point(0, 46);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(596, 263);
            this.tc.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.panelDados1);
            this.tabPage1.Controls.Add(this.pDadosParcelas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(588, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cadastro";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.gCondicaoXparcelas);
            this.panelDados1.Location = new System.Drawing.Point(1, 75);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(582, 157);
            this.panelDados1.TabIndex = 1;
            // 
            // gCondicaoXparcelas
            // 
            this.gCondicaoXparcelas.AllowUserToAddRows = false;
            this.gCondicaoXparcelas.AllowUserToDeleteRows = false;
            this.gCondicaoXparcelas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gCondicaoXparcelas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.gCondicaoXparcelas.AutoGenerateColumns = false;
            this.gCondicaoXparcelas.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCondicaoXparcelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCondicaoXparcelas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCondicaoXparcelas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.gCondicaoXparcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCondicaoXparcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdcondpgtoDataGridViewTextBoxColumn1,
            this.idparcelaDataGridViewTextBoxColumn2,
            this.qtdiasDataGridViewTextBoxColumn1,
            this.pcrateioDataGridViewTextBoxColumn2});
            this.gCondicaoXparcelas.DataSource = this.BS_CondPgtoXParcelas;
            this.gCondicaoXparcelas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCondicaoXparcelas.Location = new System.Drawing.Point(-2, -1);
            this.gCondicaoXparcelas.Name = "gCondicaoXparcelas";
            this.gCondicaoXparcelas.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCondicaoXparcelas.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.gCondicaoXparcelas.RowHeadersWidth = 23;
            this.gCondicaoXparcelas.Size = new System.Drawing.Size(582, 154);
            this.gCondicaoXparcelas.TabIndex = 2;
            // 
            // cdcondpgtoDataGridViewTextBoxColumn1
            // 
            this.cdcondpgtoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcondpgtoDataGridViewTextBoxColumn1.DataPropertyName = "Cd_condpgto";
            this.cdcondpgtoDataGridViewTextBoxColumn1.HeaderText = "Cond. PGTO";
            this.cdcondpgtoDataGridViewTextBoxColumn1.Name = "cdcondpgtoDataGridViewTextBoxColumn1";
            this.cdcondpgtoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.cdcondpgtoDataGridViewTextBoxColumn1.Width = 93;
            // 
            // idparcelaDataGridViewTextBoxColumn2
            // 
            this.idparcelaDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idparcelaDataGridViewTextBoxColumn2.DataPropertyName = "Id_parcela";
            this.idparcelaDataGridViewTextBoxColumn2.HeaderText = "Parcela";
            this.idparcelaDataGridViewTextBoxColumn2.Name = "idparcelaDataGridViewTextBoxColumn2";
            this.idparcelaDataGridViewTextBoxColumn2.ReadOnly = true;
            this.idparcelaDataGridViewTextBoxColumn2.Width = 68;
            // 
            // qtdiasDataGridViewTextBoxColumn1
            // 
            this.qtdiasDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdiasDataGridViewTextBoxColumn1.DataPropertyName = "Qt_dias";
            this.qtdiasDataGridViewTextBoxColumn1.HeaderText = "Dias Desdobro";
            this.qtdiasDataGridViewTextBoxColumn1.Name = "qtdiasDataGridViewTextBoxColumn1";
            this.qtdiasDataGridViewTextBoxColumn1.ReadOnly = true;
            this.qtdiasDataGridViewTextBoxColumn1.Width = 102;
            // 
            // pcrateioDataGridViewTextBoxColumn2
            // 
            this.pcrateioDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pcrateioDataGridViewTextBoxColumn2.DataPropertyName = "Pc_rateio";
            this.pcrateioDataGridViewTextBoxColumn2.HeaderText = "% Rateio";
            this.pcrateioDataGridViewTextBoxColumn2.Name = "pcrateioDataGridViewTextBoxColumn2";
            this.pcrateioDataGridViewTextBoxColumn2.ReadOnly = true;
            this.pcrateioDataGridViewTextBoxColumn2.Width = 74;
            // 
            // BS_CondPgtoXParcelas
            // 
            this.BS_CondPgtoXParcelas.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadCondPgto_X_Parcelas);
            // 
            // pDadosParcelas
            // 
            this.pDadosParcelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDadosParcelas.Controls.Add(this.ds_condpgto);
            this.pDadosParcelas.Controls.Add(this.label4);
            this.pDadosParcelas.Controls.Add(this.pcRateio);
            this.pDadosParcelas.Controls.Add(this.label3);
            this.pDadosParcelas.Controls.Add(this.diasDesdobro);
            this.pDadosParcelas.Controls.Add(this.label2);
            this.pDadosParcelas.Controls.Add(this.editFloat1);
            this.pDadosParcelas.Controls.Add(this.label1);
            this.pDadosParcelas.Location = new System.Drawing.Point(1, 1);
            this.pDadosParcelas.Name = "pDadosParcelas";
            this.pDadosParcelas.NM_ProcDeletar = "";
            this.pDadosParcelas.NM_ProcGravar = "";
            this.pDadosParcelas.Size = new System.Drawing.Size(582, 72);
            this.pDadosParcelas.TabIndex = 0;
            // 
            // ds_condpgto
            // 
            this.ds_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condpgto.Enabled = false;
            this.ds_condpgto.Location = new System.Drawing.Point(125, 13);
            this.ds_condpgto.Name = "ds_condpgto";
            this.ds_condpgto.NM_Alias = "";
            this.ds_condpgto.NM_Campo = "";
            this.ds_condpgto.NM_CampoBusca = "";
            this.ds_condpgto.NM_Param = "";
            this.ds_condpgto.QTD_Zero = 0;
            this.ds_condpgto.Size = new System.Drawing.Size(427, 20);
            this.ds_condpgto.ST_AutoInc = false;
            this.ds_condpgto.ST_DisableAuto = false;
            this.ds_condpgto.ST_Float = false;
            this.ds_condpgto.ST_Gravar = false;
            this.ds_condpgto.ST_Int = false;
            this.ds_condpgto.ST_LimpaCampo = true;
            this.ds_condpgto.ST_NotNull = false;
            this.ds_condpgto.ST_PrimaryKey = false;
            this.ds_condpgto.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cond. Pagamento:";
            // 
            // pcRateio
            // 
            this.pcRateio.Location = new System.Drawing.Point(460, 37);
            this.pcRateio.Name = "pcRateio";
            this.pcRateio.NM_Alias = "";
            this.pcRateio.NM_Campo = "";
            this.pcRateio.NM_Param = "";
            this.pcRateio.Operador = "";
            this.pcRateio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pcRateio.Size = new System.Drawing.Size(92, 20);
            this.pcRateio.ST_AutoInc = false;
            this.pcRateio.ST_DisableAuto = false;
            this.pcRateio.ST_Gravar = false;
            this.pcRateio.ST_LimparCampo = true;
            this.pcRateio.ST_NotNull = false;
            this.pcRateio.ST_PrimaryKey = false;
            this.pcRateio.TabIndex = 5;
            this.pcRateio.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(398, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "% Rateio:";
            // 
            // diasDesdobro
            // 
            this.diasDesdobro.Location = new System.Drawing.Point(294, 37);
            this.diasDesdobro.Name = "diasDesdobro";
            this.diasDesdobro.NM_Alias = "";
            this.diasDesdobro.NM_Campo = "";
            this.diasDesdobro.NM_Param = "";
            this.diasDesdobro.Operador = "";
            this.diasDesdobro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.diasDesdobro.Size = new System.Drawing.Size(91, 20);
            this.diasDesdobro.ST_AutoInc = false;
            this.diasDesdobro.ST_DisableAuto = false;
            this.diasDesdobro.ST_Gravar = false;
            this.diasDesdobro.ST_LimparCampo = true;
            this.diasDesdobro.ST_NotNull = false;
            this.diasDesdobro.ST_PrimaryKey = false;
            this.diasDesdobro.TabIndex = 3;
            this.diasDesdobro.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dias Desdobro:";
            // 
            // editFloat1
            // 
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_CondPagamento, "Qt_parcelas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat1.Enabled = false;
            this.editFloat1.Location = new System.Drawing.Point(125, 37);
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editFloat1.Size = new System.Drawing.Size(60, 20);
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = false;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = false;
            this.editFloat1.ST_PrimaryKey = false;
            this.editFloat1.TabIndex = 1;
            this.editFloat1.ThousandsSeparator = true;
            // 
            // BS_CondPagamento
            // 
            this.BS_CondPagamento.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadCondPgto);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Núm. de Parcelas:";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.DataPropertyName = "Cd_condpgto";
            this.Column1.HeaderText = "Cond. PGTO";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // idparcelaDataGridViewTextBoxColumn
            // 
            this.idparcelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idparcelaDataGridViewTextBoxColumn.DataPropertyName = "Id_parcela";
            this.idparcelaDataGridViewTextBoxColumn.HeaderText = "Parcela";
            this.idparcelaDataGridViewTextBoxColumn.Name = "idparcelaDataGridViewTextBoxColumn";
            this.idparcelaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdiasDataGridViewTextBoxColumn
            // 
            this.qtdiasDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdiasDataGridViewTextBoxColumn.DataPropertyName = "Qt_dias";
            this.qtdiasDataGridViewTextBoxColumn.HeaderText = "Dias Desdobro";
            this.qtdiasDataGridViewTextBoxColumn.Name = "qtdiasDataGridViewTextBoxColumn";
            this.qtdiasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pcrateioDataGridViewTextBoxColumn
            // 
            this.pcrateioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pcrateioDataGridViewTextBoxColumn.DataPropertyName = "Pc_rateio";
            this.pcrateioDataGridViewTextBoxColumn.HeaderText = "% Rateio";
            this.pcrateioDataGridViewTextBoxColumn.Name = "pcrateioDataGridViewTextBoxColumn";
            this.pcrateioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bb_gravar
            // 
            this.bb_gravar.AutoSize = false;
            this.bb_gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_gravar.ForeColor = System.Drawing.Color.Green;
            this.bb_gravar.Image = ((System.Drawing.Image)(resources.GetObject("bb_gravar.Image")));
            this.bb_gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_gravar.Name = "bb_gravar";
            this.bb_gravar.Size = new System.Drawing.Size(95, 40);
            this.bb_gravar.Text = "(F4)\r\nGravar";
            this.bb_gravar.ToolTipText = "Inutilizar NF-e";
            // 
            // bb_cancela
            // 
            this.bb_cancela.AutoSize = false;
            this.bb_cancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancela.ForeColor = System.Drawing.Color.Green;
            this.bb_cancela.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancela.Image")));
            this.bb_cancela.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancela.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancela.Name = "bb_cancela";
            this.bb_cancela.Size = new System.Drawing.Size(95, 40);
            this.bb_cancela.Text = "(F6)\r\nCancelar";
            this.bb_cancela.ToolTipText = "Cancelar Procedimento";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bbGravar,
            this.bbCancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(596, 43);
            this.barraMenu.TabIndex = 22;
            // 
            // bbGravar
            // 
            this.bbGravar.AutoSize = false;
            this.bbGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbGravar.ForeColor = System.Drawing.Color.Green;
            this.bbGravar.Image = ((System.Drawing.Image)(resources.GetObject("bbGravar.Image")));
            this.bbGravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbGravar.Name = "bbGravar";
            this.bbGravar.Size = new System.Drawing.Size(95, 40);
            this.bbGravar.Text = "(F4)\r\nGravar";
            this.bbGravar.ToolTipText = "Inutilizar NF-e";
            this.bbGravar.Click += new System.EventHandler(this.bbGravar_Click);
            // 
            // bbCancelar
            // 
            this.bbCancelar.AutoSize = false;
            this.bbCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbCancelar.ForeColor = System.Drawing.Color.Green;
            this.bbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("bbCancelar.Image")));
            this.bbCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbCancelar.Name = "bbCancelar";
            this.bbCancelar.Size = new System.Drawing.Size(95, 40);
            this.bbCancelar.Text = "(F6)\r\nCancelar";
            this.bbCancelar.ToolTipText = "Cancelar Procedimento";
            this.bbCancelar.Click += new System.EventHandler(this.bbCancelar_Click);
            // 
            // TFCondPGTO_X_Parcelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(596, 311);
            this.Controls.Add(this.barraMenu);
            this.Controls.Add(this.tc);
            this.Name = "TFCondPGTO_X_Parcelas";
            this.Text = "Condição de Pagamento X Parcelas";
            this.tc.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gCondicaoXparcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CondPgtoXParcelas)).EndInit();
            this.pDadosParcelas.ResumeLayout(false);
            this.pDadosParcelas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcRateio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasDesdobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CondPagamento)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tabPage1;
        private Componentes.PanelDados pDadosParcelas;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat pcRateio;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat diasDesdobro;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat editFloat1;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingSource BS_CondPgtoXParcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idparcelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdiasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcrateioDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault ds_condpgto;
        private System.Windows.Forms.BindingSource BS_CondPagamento;
        private System.Windows.Forms.ToolStripButton bb_gravar;
        private System.Windows.Forms.ToolStripButton bb_cancela;
        private Componentes.DataGridDefault gCondicaoXparcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcondpgtoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idparcelaDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdiasDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcrateioDataGridViewTextBoxColumn2;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bbGravar;
        private System.Windows.Forms.ToolStripButton bbCancelar;
    }
}