namespace Financeiro.Cadastros
{
    partial class TFCadCFGContratoFin
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
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCFGContratoFin));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpduplicataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstpduplicataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpdoctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstpdoctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdhistoricoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dshistoricoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCFGContratoFin = new System.Windows.Forms.BindingSource(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.tp_duplicata = new Componentes.EditDefault(this.components);
            this.bb_tpduplicata = new System.Windows.Forms.Button();
            this.ds_tpduplicata = new Componentes.EditDefault(this.components);
            this.tp_docto = new Componentes.EditDefault(this.components);
            this.bb_tpdocto = new System.Windows.Forms.Button();
            this.ds_tpdocto = new Componentes.EditDefault(this.components);
            this.cd_historico = new Componentes.EditDefault(this.components);
            this.bb_historico = new System.Windows.Forms.Button();
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.tp_movDup = new Componentes.EditDefault(this.components);
            this.tp_movHist = new Componentes.EditDefault(this.components);
            cd_empresaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCFGContratoFin)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.tp_movHist);
            this.pDados.Controls.Add(this.tp_movDup);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.cd_historico);
            this.pDados.Controls.Add(this.bb_historico);
            this.pDados.Controls.Add(this.ds_historico);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.tp_docto);
            this.pDados.Controls.Add(this.bb_tpdocto);
            this.pDados.Controls.Add(this.ds_tpdocto);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.tp_duplicata);
            this.pDados.Controls.Add(this.bb_tpduplicata);
            this.pDados.Controls.Add(this.ds_tpduplicata);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.bb_empresa);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(24, 17);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(51, 13);
            cd_empresaLabel.TabIndex = 48;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(4, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 13);
            label1.TabIndex = 82;
            label1.Text = "Tp.Duplicata:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(19, 68);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 13);
            label2.TabIndex = 86;
            label2.Text = "Tp.Docto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(24, 94);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 13);
            label3.TabIndex = 90;
            label3.Text = "Histórico:";
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.tpduplicataDataGridViewTextBoxColumn,
            this.dstpduplicataDataGridViewTextBoxColumn,
            this.tpdoctoDataGridViewTextBoxColumn,
            this.dstpdoctoDataGridViewTextBoxColumn,
            this.cdhistoricoDataGridViewTextBoxColumn,
            this.dshistoricoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsCFGContratoFin;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 137);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(659, 223);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd.Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 89;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            this.nmempresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmempresaDataGridViewTextBoxColumn.Width = 73;
            // 
            // tpduplicataDataGridViewTextBoxColumn
            // 
            this.tpduplicataDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpduplicataDataGridViewTextBoxColumn.DataPropertyName = "Tp_duplicata";
            this.tpduplicataDataGridViewTextBoxColumn.HeaderText = "Tp.Duplicata";
            this.tpduplicataDataGridViewTextBoxColumn.Name = "tpduplicataDataGridViewTextBoxColumn";
            this.tpduplicataDataGridViewTextBoxColumn.ReadOnly = true;
            this.tpduplicataDataGridViewTextBoxColumn.Width = 93;
            // 
            // dstpduplicataDataGridViewTextBoxColumn
            // 
            this.dstpduplicataDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstpduplicataDataGridViewTextBoxColumn.DataPropertyName = "Ds_tpduplicata";
            this.dstpduplicataDataGridViewTextBoxColumn.HeaderText = "Tipo Duplicata";
            this.dstpduplicataDataGridViewTextBoxColumn.Name = "dstpduplicataDataGridViewTextBoxColumn";
            this.dstpduplicataDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstpduplicataDataGridViewTextBoxColumn.Width = 101;
            // 
            // tpdoctoDataGridViewTextBoxColumn
            // 
            this.tpdoctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpdoctoDataGridViewTextBoxColumn.DataPropertyName = "Tp_docto";
            this.tpdoctoDataGridViewTextBoxColumn.HeaderText = "Tp.Docto";
            this.tpdoctoDataGridViewTextBoxColumn.Name = "tpdoctoDataGridViewTextBoxColumn";
            this.tpdoctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tpdoctoDataGridViewTextBoxColumn.Width = 77;
            // 
            // dstpdoctoDataGridViewTextBoxColumn
            // 
            this.dstpdoctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstpdoctoDataGridViewTextBoxColumn.DataPropertyName = "Ds_tpdocto";
            this.dstpdoctoDataGridViewTextBoxColumn.HeaderText = "Tipo Docto";
            this.dstpdoctoDataGridViewTextBoxColumn.Name = "dstpdoctoDataGridViewTextBoxColumn";
            this.dstpdoctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstpdoctoDataGridViewTextBoxColumn.Width = 85;
            // 
            // cdhistoricoDataGridViewTextBoxColumn
            // 
            this.cdhistoricoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdhistoricoDataGridViewTextBoxColumn.DataPropertyName = "Cd_historico";
            this.cdhistoricoDataGridViewTextBoxColumn.HeaderText = "Cd.Histórico";
            this.cdhistoricoDataGridViewTextBoxColumn.Name = "cdhistoricoDataGridViewTextBoxColumn";
            this.cdhistoricoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdhistoricoDataGridViewTextBoxColumn.Width = 89;
            // 
            // dshistoricoDataGridViewTextBoxColumn
            // 
            this.dshistoricoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dshistoricoDataGridViewTextBoxColumn.DataPropertyName = "Ds_historico";
            this.dshistoricoDataGridViewTextBoxColumn.HeaderText = "Histórico";
            this.dshistoricoDataGridViewTextBoxColumn.Name = "dshistoricoDataGridViewTextBoxColumn";
            this.dshistoricoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dshistoricoDataGridViewTextBoxColumn.Width = 73;
            // 
            // bsCFGContratoFin
            // 
            this.bsCFGContratoFin.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CFGContratoFin);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGContratoFin, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(75, 14);
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
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = true;
            this.cd_empresa.TabIndex = 46;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGContratoFin, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(177, 14);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(466, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 49;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Enabled = false;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(143, 14);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 47;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // tp_duplicata
            // 
            this.tp_duplicata.BackColor = System.Drawing.SystemColors.Window;
            this.tp_duplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_duplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_duplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGContratoFin, "Tp_duplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_duplicata.Enabled = false;
            this.tp_duplicata.Location = new System.Drawing.Point(76, 40);
            this.tp_duplicata.MaxLength = 4;
            this.tp_duplicata.Name = "tp_duplicata";
            this.tp_duplicata.NM_Alias = "";
            this.tp_duplicata.NM_Campo = "tp_duplicata";
            this.tp_duplicata.NM_CampoBusca = "tp_duplicata";
            this.tp_duplicata.NM_Param = "@P_CD_HISTORICO";
            this.tp_duplicata.QTD_Zero = 0;
            this.tp_duplicata.Size = new System.Drawing.Size(67, 20);
            this.tp_duplicata.ST_AutoInc = false;
            this.tp_duplicata.ST_DisableAuto = false;
            this.tp_duplicata.ST_Float = false;
            this.tp_duplicata.ST_Gravar = true;
            this.tp_duplicata.ST_Int = false;
            this.tp_duplicata.ST_LimpaCampo = true;
            this.tp_duplicata.ST_NotNull = false;
            this.tp_duplicata.ST_PrimaryKey = false;
            this.tp_duplicata.TabIndex = 79;
            this.tp_duplicata.TextOld = null;
            this.tp_duplicata.Leave += new System.EventHandler(this.tp_duplicata_Leave);
            // 
            // bb_tpduplicata
            // 
            this.bb_tpduplicata.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tpduplicata.Enabled = false;
            this.bb_tpduplicata.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpduplicata.Image")));
            this.bb_tpduplicata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpduplicata.Location = new System.Drawing.Point(144, 40);
            this.bb_tpduplicata.Name = "bb_tpduplicata";
            this.bb_tpduplicata.Size = new System.Drawing.Size(28, 19);
            this.bb_tpduplicata.TabIndex = 80;
            this.bb_tpduplicata.UseVisualStyleBackColor = false;
            this.bb_tpduplicata.Click += new System.EventHandler(this.bb_tpduplicata_Click);
            // 
            // ds_tpduplicata
            // 
            this.ds_tpduplicata.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpduplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpduplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpduplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGContratoFin, "Ds_tpduplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpduplicata.Enabled = false;
            this.ds_tpduplicata.Location = new System.Drawing.Point(177, 40);
            this.ds_tpduplicata.Name = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Alias = "";
            this.ds_tpduplicata.NM_Campo = "ds_tpduplicata";
            this.ds_tpduplicata.NM_CampoBusca = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Param = "@P_DS_HISTORICO";
            this.ds_tpduplicata.QTD_Zero = 0;
            this.ds_tpduplicata.Size = new System.Drawing.Size(416, 20);
            this.ds_tpduplicata.ST_AutoInc = false;
            this.ds_tpduplicata.ST_DisableAuto = false;
            this.ds_tpduplicata.ST_Float = false;
            this.ds_tpduplicata.ST_Gravar = false;
            this.ds_tpduplicata.ST_Int = false;
            this.ds_tpduplicata.ST_LimpaCampo = true;
            this.ds_tpduplicata.ST_NotNull = false;
            this.ds_tpduplicata.ST_PrimaryKey = false;
            this.ds_tpduplicata.TabIndex = 81;
            this.ds_tpduplicata.TextOld = null;
            // 
            // tp_docto
            // 
            this.tp_docto.BackColor = System.Drawing.SystemColors.Window;
            this.tp_docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_docto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGContratoFin, "Tp_docto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_docto.Enabled = false;
            this.tp_docto.Location = new System.Drawing.Point(76, 66);
            this.tp_docto.MaxLength = 4;
            this.tp_docto.Name = "tp_docto";
            this.tp_docto.NM_Alias = "";
            this.tp_docto.NM_Campo = "TP_DOCTO";
            this.tp_docto.NM_CampoBusca = "TP_DOCTO";
            this.tp_docto.NM_Param = "@P_CD_HISTORICO";
            this.tp_docto.QTD_Zero = 0;
            this.tp_docto.Size = new System.Drawing.Size(67, 20);
            this.tp_docto.ST_AutoInc = false;
            this.tp_docto.ST_DisableAuto = false;
            this.tp_docto.ST_Float = false;
            this.tp_docto.ST_Gravar = true;
            this.tp_docto.ST_Int = false;
            this.tp_docto.ST_LimpaCampo = true;
            this.tp_docto.ST_NotNull = false;
            this.tp_docto.ST_PrimaryKey = false;
            this.tp_docto.TabIndex = 83;
            this.tp_docto.TextOld = null;
            this.tp_docto.Leave += new System.EventHandler(this.tp_docto_Leave);
            // 
            // bb_tpdocto
            // 
            this.bb_tpdocto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tpdocto.Enabled = false;
            this.bb_tpdocto.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpdocto.Image")));
            this.bb_tpdocto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpdocto.Location = new System.Drawing.Point(144, 66);
            this.bb_tpdocto.Name = "bb_tpdocto";
            this.bb_tpdocto.Size = new System.Drawing.Size(28, 19);
            this.bb_tpdocto.TabIndex = 84;
            this.bb_tpdocto.UseVisualStyleBackColor = false;
            this.bb_tpdocto.Click += new System.EventHandler(this.bb_tpdocto_Click);
            // 
            // ds_tpdocto
            // 
            this.ds_tpdocto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpdocto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpdocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpdocto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGContratoFin, "Ds_tpdocto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpdocto.Enabled = false;
            this.ds_tpdocto.Location = new System.Drawing.Point(177, 66);
            this.ds_tpdocto.Name = "ds_tpdocto";
            this.ds_tpdocto.NM_Alias = "";
            this.ds_tpdocto.NM_Campo = "ds_tpdocto";
            this.ds_tpdocto.NM_CampoBusca = "ds_tpdocto";
            this.ds_tpdocto.NM_Param = "@P_DS_HISTORICO";
            this.ds_tpdocto.QTD_Zero = 0;
            this.ds_tpdocto.Size = new System.Drawing.Size(466, 20);
            this.ds_tpdocto.ST_AutoInc = false;
            this.ds_tpdocto.ST_DisableAuto = false;
            this.ds_tpdocto.ST_Float = false;
            this.ds_tpdocto.ST_Gravar = false;
            this.ds_tpdocto.ST_Int = false;
            this.ds_tpdocto.ST_LimpaCampo = true;
            this.ds_tpdocto.ST_NotNull = false;
            this.ds_tpdocto.ST_PrimaryKey = false;
            this.ds_tpdocto.TabIndex = 85;
            this.ds_tpdocto.TextOld = null;
            // 
            // cd_historico
            // 
            this.cd_historico.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGContratoFin, "Cd_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_historico.Enabled = false;
            this.cd_historico.Location = new System.Drawing.Point(76, 92);
            this.cd_historico.MaxLength = 4;
            this.cd_historico.Name = "cd_historico";
            this.cd_historico.NM_Alias = "";
            this.cd_historico.NM_Campo = "cd_historico";
            this.cd_historico.NM_CampoBusca = "cd_historico";
            this.cd_historico.NM_Param = "@P_CD_HISTORICO";
            this.cd_historico.QTD_Zero = 0;
            this.cd_historico.Size = new System.Drawing.Size(67, 20);
            this.cd_historico.ST_AutoInc = false;
            this.cd_historico.ST_DisableAuto = false;
            this.cd_historico.ST_Float = false;
            this.cd_historico.ST_Gravar = true;
            this.cd_historico.ST_Int = false;
            this.cd_historico.ST_LimpaCampo = true;
            this.cd_historico.ST_NotNull = false;
            this.cd_historico.ST_PrimaryKey = false;
            this.cd_historico.TabIndex = 87;
            this.cd_historico.TextOld = null;
            this.cd_historico.Leave += new System.EventHandler(this.cd_historico_Leave);
            // 
            // bb_historico
            // 
            this.bb_historico.BackColor = System.Drawing.SystemColors.Control;
            this.bb_historico.Enabled = false;
            this.bb_historico.Image = ((System.Drawing.Image)(resources.GetObject("bb_historico.Image")));
            this.bb_historico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_historico.Location = new System.Drawing.Point(144, 92);
            this.bb_historico.Name = "bb_historico";
            this.bb_historico.Size = new System.Drawing.Size(28, 19);
            this.bb_historico.TabIndex = 88;
            this.bb_historico.UseVisualStyleBackColor = false;
            this.bb_historico.Click += new System.EventHandler(this.bb_historico_Click);
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGContratoFin, "Ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_historico.Enabled = false;
            this.ds_historico.Location = new System.Drawing.Point(177, 92);
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "ds_historico";
            this.ds_historico.NM_CampoBusca = "ds_historico";
            this.ds_historico.NM_Param = "@P_DS_HISTORICO";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.Size = new System.Drawing.Size(416, 20);
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = false;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = false;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TabIndex = 89;
            this.ds_historico.TextOld = null;
            // 
            // tp_movDup
            // 
            this.tp_movDup.BackColor = System.Drawing.SystemColors.Window;
            this.tp_movDup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_movDup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_movDup.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGContratoFin, "Tp_movDup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movDup.Enabled = false;
            this.tp_movDup.Location = new System.Drawing.Point(599, 41);
            this.tp_movDup.Name = "tp_movDup";
            this.tp_movDup.NM_Alias = "";
            this.tp_movDup.NM_Campo = "tp_mov";
            this.tp_movDup.NM_CampoBusca = "tp_mov";
            this.tp_movDup.NM_Param = "@P_TP_MOV";
            this.tp_movDup.QTD_Zero = 0;
            this.tp_movDup.Size = new System.Drawing.Size(44, 20);
            this.tp_movDup.ST_AutoInc = false;
            this.tp_movDup.ST_DisableAuto = false;
            this.tp_movDup.ST_Float = false;
            this.tp_movDup.ST_Gravar = false;
            this.tp_movDup.ST_Int = false;
            this.tp_movDup.ST_LimpaCampo = true;
            this.tp_movDup.ST_NotNull = false;
            this.tp_movDup.ST_PrimaryKey = false;
            this.tp_movDup.TabIndex = 91;
            this.tp_movDup.TextOld = null;
            // 
            // tp_movHist
            // 
            this.tp_movHist.BackColor = System.Drawing.SystemColors.Window;
            this.tp_movHist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_movHist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_movHist.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGContratoFin, "Tp_movHist", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movHist.Enabled = false;
            this.tp_movHist.Location = new System.Drawing.Point(599, 91);
            this.tp_movHist.Name = "tp_movHist";
            this.tp_movHist.NM_Alias = "";
            this.tp_movHist.NM_Campo = "tp_mov";
            this.tp_movHist.NM_CampoBusca = "tp_mov";
            this.tp_movHist.NM_Param = "@P_TP_MOV";
            this.tp_movHist.QTD_Zero = 0;
            this.tp_movHist.Size = new System.Drawing.Size(44, 20);
            this.tp_movHist.ST_AutoInc = false;
            this.tp_movHist.ST_DisableAuto = false;
            this.tp_movHist.ST_Float = false;
            this.tp_movHist.ST_Gravar = false;
            this.tp_movHist.ST_Int = false;
            this.tp_movHist.ST_LimpaCampo = true;
            this.tp_movHist.ST_NotNull = false;
            this.tp_movHist.ST_PrimaryKey = false;
            this.tp_movHist.TabIndex = 92;
            this.tp_movHist.TextOld = null;
            // 
            // TFCadCFGContratoFin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadCFGContratoFin";
            this.Text = "Configuração Contrato Financeiro";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCFGContratoFin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsCFGContratoFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpduplicataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstpduplicataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpdoctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstpdoctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdhistoricoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dshistoricoDataGridViewTextBoxColumn;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault tp_docto;
        private System.Windows.Forms.Button bb_tpdocto;
        private Componentes.EditDefault ds_tpdocto;
        private Componentes.EditDefault tp_duplicata;
        private System.Windows.Forms.Button bb_tpduplicata;
        private Componentes.EditDefault ds_tpduplicata;
        private Componentes.EditDefault cd_historico;
        private System.Windows.Forms.Button bb_historico;
        private Componentes.EditDefault ds_historico;
        private Componentes.EditDefault tp_movHist;
        private Componentes.EditDefault tp_movDup;
    }
}