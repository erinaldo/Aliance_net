namespace PDV
{
    partial class TFDuplicataPDV
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label11;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDuplicataPDV));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.vl_documento = new Componentes.EditDefault(this.components);
            this.bsDuplicata = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbCondPgto = new Componentes.ComboBoxDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pParcelas = new Componentes.PanelDados(this.components);
            this.bb_voltar = new System.Windows.Forms.Button();
            this.bb_avancar = new System.Windows.Forms.Button();
            this.vl_parcela_padrao = new Componentes.EditFloat(this.components);
            this.bsParcelas = new System.Windows.Forms.BindingSource(this.components);
            this.dt_vencto = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.gParcelas = new Componentes.DataGridDefault(this.components);
            this.cdparcelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvenctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlparcelapadraoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbBoleto = new Componentes.ComboBoxDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDuplicata)).BeginInit();
            this.pParcelas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_parcela_padrao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(373, 43);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(77, 13);
            label4.TabIndex = 69;
            label4.Text = "Vencimento:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label11.Location = new System.Drawing.Point(370, 88);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(40, 13);
            label11.TabIndex = 75;
            label11.Text = "Valor:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(546, 43);
            this.barraMenu.TabIndex = 5;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Duplicata";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Lançamento";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Controls.Add(this.pParcelas, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(546, 295);
            this.tlpCentral.TabIndex = 6;
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.cbBoleto);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.vl_documento);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cbCondPgto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(3, 3);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(540, 113);
            this.pDados.TabIndex = 0;
            // 
            // vl_documento
            // 
            this.vl_documento.BackColor = System.Drawing.SystemColors.Window;
            this.vl_documento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vl_documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.vl_documento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDuplicata, "Vl_documento_padrao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.vl_documento.Enabled = false;
            this.vl_documento.Location = new System.Drawing.Point(110, 90);
            this.vl_documento.Name = "vl_documento";
            this.vl_documento.NM_Alias = "";
            this.vl_documento.NM_Campo = "";
            this.vl_documento.NM_CampoBusca = "";
            this.vl_documento.NM_Param = "";
            this.vl_documento.QTD_Zero = 0;
            this.vl_documento.Size = new System.Drawing.Size(114, 20);
            this.vl_documento.ST_AutoInc = false;
            this.vl_documento.ST_DisableAuto = false;
            this.vl_documento.ST_Float = false;
            this.vl_documento.ST_Gravar = false;
            this.vl_documento.ST_Int = false;
            this.vl_documento.ST_LimpaCampo = true;
            this.vl_documento.ST_NotNull = false;
            this.vl_documento.ST_PrimaryKey = false;
            this.vl_documento.TabIndex = 4;
            this.vl_documento.TextOld = null;
            // 
            // bsDuplicata
            // 
            this.bsDuplicata.DataSource = typeof(CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor Documento:";
            // 
            // cbCondPgto
            // 
            this.cbCondPgto.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsDuplicata, "Cd_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbCondPgto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondPgto.FormattingEnabled = true;
            this.cbCondPgto.Location = new System.Drawing.Point(12, 21);
            this.cbCondPgto.Name = "cbCondPgto";
            this.cbCondPgto.NM_Alias = "";
            this.cbCondPgto.NM_Campo = "";
            this.cbCondPgto.NM_Param = "";
            this.cbCondPgto.Size = new System.Drawing.Size(519, 21);
            this.cbCondPgto.ST_Gravar = false;
            this.cbCondPgto.ST_LimparCampo = true;
            this.cbCondPgto.ST_NotNull = false;
            this.cbCondPgto.TabIndex = 1;
            this.cbCondPgto.SelectedIndexChanged += new System.EventHandler(this.cbCondPgto_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Condição Pagamento";
            // 
            // pParcelas
            // 
            this.pParcelas.Controls.Add(this.bb_voltar);
            this.pParcelas.Controls.Add(this.bb_avancar);
            this.pParcelas.Controls.Add(label11);
            this.pParcelas.Controls.Add(this.vl_parcela_padrao);
            this.pParcelas.Controls.Add(label4);
            this.pParcelas.Controls.Add(this.dt_vencto);
            this.pParcelas.Controls.Add(this.label3);
            this.pParcelas.Controls.Add(this.gParcelas);
            this.pParcelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pParcelas.Location = new System.Drawing.Point(3, 122);
            this.pParcelas.Name = "pParcelas";
            this.pParcelas.NM_ProcDeletar = "";
            this.pParcelas.NM_ProcGravar = "";
            this.pParcelas.Size = new System.Drawing.Size(540, 170);
            this.pParcelas.TabIndex = 1;
            // 
            // bb_voltar
            // 
            this.bb_voltar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_voltar.Location = new System.Drawing.Point(455, 135);
            this.bb_voltar.Name = "bb_voltar";
            this.bb_voltar.Size = new System.Drawing.Size(76, 26);
            this.bb_voltar.TabIndex = 78;
            this.bb_voltar.Text = "Voltar";
            this.bb_voltar.UseVisualStyleBackColor = true;
            this.bb_voltar.Click += new System.EventHandler(this.bb_voltar_Click);
            // 
            // bb_avancar
            // 
            this.bb_avancar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_avancar.Location = new System.Drawing.Point(373, 135);
            this.bb_avancar.Name = "bb_avancar";
            this.bb_avancar.Size = new System.Drawing.Size(76, 26);
            this.bb_avancar.TabIndex = 77;
            this.bb_avancar.Text = "Avançar";
            this.bb_avancar.UseVisualStyleBackColor = true;
            this.bb_avancar.Click += new System.EventHandler(this.bb_avancar_Click);
            // 
            // vl_parcela_padrao
            // 
            this.vl_parcela_padrao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsParcelas, "Vl_parcela_padrao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_parcela_padrao.DecimalPlaces = 2;
            this.vl_parcela_padrao.Enabled = false;
            this.vl_parcela_padrao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.vl_parcela_padrao.Location = new System.Drawing.Point(373, 104);
            this.vl_parcela_padrao.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.vl_parcela_padrao.Name = "vl_parcela_padrao";
            this.vl_parcela_padrao.NM_Alias = "";
            this.vl_parcela_padrao.NM_Campo = "";
            this.vl_parcela_padrao.NM_Param = "";
            this.vl_parcela_padrao.Operador = "";
            this.vl_parcela_padrao.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_parcela_padrao.Size = new System.Drawing.Size(158, 26);
            this.vl_parcela_padrao.ST_AutoInc = false;
            this.vl_parcela_padrao.ST_DisableAuto = false;
            this.vl_parcela_padrao.ST_Gravar = false;
            this.vl_parcela_padrao.ST_LimparCampo = true;
            this.vl_parcela_padrao.ST_NotNull = false;
            this.vl_parcela_padrao.ST_PrimaryKey = false;
            this.vl_parcela_padrao.TabIndex = 74;
            this.vl_parcela_padrao.ThousandsSeparator = true;
            this.vl_parcela_padrao.Leave += new System.EventHandler(this.vl_parcela_padrao_Leave);
            // 
            // bsParcelas
            // 
            this.bsParcelas.DataMember = "Parcelas";
            this.bsParcelas.DataSource = this.bsDuplicata;
            this.bsParcelas.PositionChanged += new System.EventHandler(this.bsParcelas_PositionChanged);
            // 
            // dt_vencto
            // 
            this.dt_vencto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_vencto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsParcelas, "Dt_venctostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_vencto.Enabled = false;
            this.dt_vencto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dt_vencto.Location = new System.Drawing.Point(373, 59);
            this.dt_vencto.Mask = "00/00/0000";
            this.dt_vencto.Name = "dt_vencto";
            this.dt_vencto.NM_Alias = "";
            this.dt_vencto.NM_Campo = "";
            this.dt_vencto.NM_CampoBusca = "";
            this.dt_vencto.NM_Param = "";
            this.dt_vencto.Operador = "";
            this.dt_vencto.Size = new System.Drawing.Size(158, 26);
            this.dt_vencto.ST_Gravar = false;
            this.dt_vencto.ST_LimpaCampo = true;
            this.dt_vencto.ST_NotNull = false;
            this.dt_vencto.ST_PrimaryKey = false;
            this.dt_vencto.TabIndex = 68;
            this.dt_vencto.Leave += new System.EventHandler(this.dt_vencto_Leave);
            this.dt_vencto.Enter += new System.EventHandler(this.dt_vencto_Enter);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(540, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "PARCELAS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gParcelas
            // 
            this.gParcelas.AllowUserToAddRows = false;
            this.gParcelas.AllowUserToDeleteRows = false;
            this.gParcelas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gParcelas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.gParcelas.AutoGenerateColumns = false;
            this.gParcelas.BackgroundColor = System.Drawing.Color.LightGray;
            this.gParcelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gParcelas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gParcelas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdparcelaDataGridViewTextBoxColumn,
            this.dtvenctoDataGridViewTextBoxColumn,
            this.vlparcelapadraoDataGridViewTextBoxColumn});
            this.gParcelas.DataSource = this.bsParcelas;
            this.gParcelas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gParcelas.Location = new System.Drawing.Point(3, 21);
            this.gParcelas.Name = "gParcelas";
            this.gParcelas.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gParcelas.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.gParcelas.RowHeadersWidth = 23;
            this.gParcelas.Size = new System.Drawing.Size(364, 149);
            this.gParcelas.TabIndex = 0;
            // 
            // cdparcelaDataGridViewTextBoxColumn
            // 
            this.cdparcelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdparcelaDataGridViewTextBoxColumn.DataPropertyName = "Cd_parcela";
            this.cdparcelaDataGridViewTextBoxColumn.HeaderText = "Parcela";
            this.cdparcelaDataGridViewTextBoxColumn.Name = "cdparcelaDataGridViewTextBoxColumn";
            this.cdparcelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdparcelaDataGridViewTextBoxColumn.Width = 68;
            // 
            // dtvenctoDataGridViewTextBoxColumn
            // 
            this.dtvenctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvenctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_vencto";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Format = "d";
            dataGridViewCellStyle13.NullValue = null;
            this.dtvenctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.dtvenctoDataGridViewTextBoxColumn.HeaderText = "Vencimento";
            this.dtvenctoDataGridViewTextBoxColumn.Name = "dtvenctoDataGridViewTextBoxColumn";
            this.dtvenctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtvenctoDataGridViewTextBoxColumn.Width = 88;
            // 
            // vlparcelapadraoDataGridViewTextBoxColumn
            // 
            this.vlparcelapadraoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlparcelapadraoDataGridViewTextBoxColumn.DataPropertyName = "Vl_parcela_padrao";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = "0";
            this.vlparcelapadraoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.vlparcelapadraoDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.vlparcelapadraoDataGridViewTextBoxColumn.Name = "vlparcelapadraoDataGridViewTextBoxColumn";
            this.vlparcelapadraoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlparcelapadraoDataGridViewTextBoxColumn.Width = 56;
            // 
            // cbBoleto
            // 
            this.cbBoleto.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsDuplicata, "Id_configBoleto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbBoleto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoleto.FormattingEnabled = true;
            this.cbBoleto.Location = new System.Drawing.Point(12, 63);
            this.cbBoleto.Name = "cbBoleto";
            this.cbBoleto.NM_Alias = "";
            this.cbBoleto.NM_Campo = "";
            this.cbBoleto.NM_Param = "";
            this.cbBoleto.Size = new System.Drawing.Size(519, 21);
            this.cbBoleto.ST_Gravar = false;
            this.cbBoleto.ST_LimparCampo = true;
            this.cbBoleto.ST_NotNull = false;
            this.cbBoleto.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Boleto Bancario";
            // 
            // TFDuplicataPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 338);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDuplicataPDV";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duplicata Frente Caixa";
            this.Load += new System.EventHandler(this.TFDuplicataPDV_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDuplicataPDV_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDuplicata)).EndInit();
            this.pParcelas.ResumeLayout(false);
            this.pParcelas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_parcela_padrao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gParcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private Componentes.ComboBoxDefault cbCondPgto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.PanelDados pParcelas;
        private Componentes.EditDefault vl_documento;
        private System.Windows.Forms.BindingSource bsDuplicata;
        private Componentes.DataGridDefault gParcelas;
        private System.Windows.Forms.BindingSource bsParcelas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdparcelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvenctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlparcelapadraoDataGridViewTextBoxColumn;
        private Componentes.EditData dt_vencto;
        private Componentes.EditFloat vl_parcela_padrao;
        private System.Windows.Forms.Button bb_voltar;
        private System.Windows.Forms.Button bb_avancar;
        private Componentes.ComboBoxDefault cbBoleto;
        private System.Windows.Forms.Label label5;
    }
}