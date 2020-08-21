namespace Financeiro.Cadastros
{
    partial class TFCadCFGFaturaCartao
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
            System.Windows.Forms.Label cd_historicoLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCFGFaturaCartao));
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bsCfgFaturaCartao = new System.Windows.Forms.BindingSource(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_historico_rec = new Componentes.EditDefault(this.components);
            this.bb_historico_rec = new System.Windows.Forms.Button();
            this.ds_historico_rec = new Componentes.EditDefault(this.components);
            this.cd_historico_juro = new Componentes.EditDefault(this.components);
            this.bb_historico_juro = new System.Windows.Forms.Button();
            this.ds_historico_juro = new Componentes.EditDefault(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dshistoricojuroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cd_historico_pag = new Componentes.EditDefault(this.components);
            this.bb_historico_pag = new System.Windows.Forms.Button();
            this.ds_historico_pag = new Componentes.EditDefault(this.components);
            this.cd_historico_taxa = new Componentes.EditDefault(this.components);
            this.bb_historico_taxa = new System.Windows.Forms.Button();
            this.ds_historico_taxa = new Componentes.EditDefault(this.components);
            cd_empresaLabel = new System.Windows.Forms.Label();
            cd_historicoLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgFaturaCartao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.cd_historico_taxa);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.bb_historico_taxa);
            this.pDados.Controls.Add(this.ds_historico_taxa);
            this.pDados.Controls.Add(this.cd_historico_pag);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.bb_historico_pag);
            this.pDados.Controls.Add(this.ds_historico_pag);
            this.pDados.Controls.Add(this.cd_historico_juro);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.bb_historico_juro);
            this.pDados.Controls.Add(this.ds_historico_juro);
            this.pDados.Controls.Add(this.cd_historico_rec);
            this.pDados.Controls.Add(cd_historicoLabel);
            this.pDados.Controls.Add(this.bb_historico_rec);
            this.pDados.Controls.Add(this.ds_historico_rec);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Size = new System.Drawing.Size(659, 134);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(31, 6);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(51, 13);
            cd_empresaLabel.TabIndex = 40;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // cd_historicoLabel
            // 
            cd_historicoLabel.AutoSize = true;
            cd_historicoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_historicoLabel.Location = new System.Drawing.Point(5, 32);
            cd_historicoLabel.Name = "cd_historicoLabel";
            cd_historicoLabel.Size = new System.Drawing.Size(77, 13);
            cd_historicoLabel.TabIndex = 73;
            cd_historicoLabel.Text = "Histórico Rec.:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(8, 84);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 13);
            label1.TabIndex = 77;
            label1.Text = "Histórico Juro:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(6, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(76, 13);
            label2.TabIndex = 81;
            label2.Text = "Histórico Pag.:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(4, 110);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(78, 13);
            label3.TabIndex = 85;
            label3.Text = "Histórico Taxa:";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFaturaCartao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(88, 3);
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
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // bsCfgFaturaCartao
            // 
            this.bsCfgFaturaCartao.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CFGFaturaCartao);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFaturaCartao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(190, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(410, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 41;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Enabled = false;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(156, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_historico_rec
            // 
            this.cd_historico_rec.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico_rec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico_rec.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFaturaCartao, "Cd_historico_rec", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_historico_rec.Enabled = false;
            this.cd_historico_rec.Location = new System.Drawing.Point(88, 29);
            this.cd_historico_rec.MaxLength = 4;
            this.cd_historico_rec.Name = "cd_historico_rec";
            this.cd_historico_rec.NM_Alias = "";
            this.cd_historico_rec.NM_Campo = "cd_historico";
            this.cd_historico_rec.NM_CampoBusca = "cd_historico";
            this.cd_historico_rec.NM_Param = "@P_CD_HISTORICO";
            this.cd_historico_rec.QTD_Zero = 0;
            this.cd_historico_rec.Size = new System.Drawing.Size(67, 20);
            this.cd_historico_rec.ST_AutoInc = false;
            this.cd_historico_rec.ST_DisableAuto = false;
            this.cd_historico_rec.ST_Float = false;
            this.cd_historico_rec.ST_Gravar = true;
            this.cd_historico_rec.ST_Int = false;
            this.cd_historico_rec.ST_LimpaCampo = true;
            this.cd_historico_rec.ST_NotNull = true;
            this.cd_historico_rec.ST_PrimaryKey = false;
            this.cd_historico_rec.TabIndex = 4;
            this.cd_historico_rec.Leave += new System.EventHandler(this.cd_historico_Leave);
            // 
            // bb_historico_rec
            // 
            this.bb_historico_rec.BackColor = System.Drawing.SystemColors.Control;
            this.bb_historico_rec.Enabled = false;
            this.bb_historico_rec.Image = ((System.Drawing.Image)(resources.GetObject("bb_historico_rec.Image")));
            this.bb_historico_rec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_historico_rec.Location = new System.Drawing.Point(156, 29);
            this.bb_historico_rec.Name = "bb_historico_rec";
            this.bb_historico_rec.Size = new System.Drawing.Size(28, 19);
            this.bb_historico_rec.TabIndex = 5;
            this.bb_historico_rec.UseVisualStyleBackColor = false;
            this.bb_historico_rec.Click += new System.EventHandler(this.bb_historico_Click);
            // 
            // ds_historico_rec
            // 
            this.ds_historico_rec.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico_rec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico_rec.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFaturaCartao, "Ds_historico_rec", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_historico_rec.Enabled = false;
            this.ds_historico_rec.Location = new System.Drawing.Point(190, 29);
            this.ds_historico_rec.Name = "ds_historico_rec";
            this.ds_historico_rec.NM_Alias = "";
            this.ds_historico_rec.NM_Campo = "ds_historico";
            this.ds_historico_rec.NM_CampoBusca = "ds_historico";
            this.ds_historico_rec.NM_Param = "@P_DS_HISTORICO";
            this.ds_historico_rec.QTD_Zero = 0;
            this.ds_historico_rec.Size = new System.Drawing.Size(410, 20);
            this.ds_historico_rec.ST_AutoInc = false;
            this.ds_historico_rec.ST_DisableAuto = false;
            this.ds_historico_rec.ST_Float = false;
            this.ds_historico_rec.ST_Gravar = false;
            this.ds_historico_rec.ST_Int = false;
            this.ds_historico_rec.ST_LimpaCampo = true;
            this.ds_historico_rec.ST_NotNull = false;
            this.ds_historico_rec.ST_PrimaryKey = false;
            this.ds_historico_rec.TabIndex = 74;
            // 
            // cd_historico_juro
            // 
            this.cd_historico_juro.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico_juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFaturaCartao, "Cd_historico_juro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_historico_juro.Enabled = false;
            this.cd_historico_juro.Location = new System.Drawing.Point(88, 81);
            this.cd_historico_juro.MaxLength = 4;
            this.cd_historico_juro.Name = "cd_historico_juro";
            this.cd_historico_juro.NM_Alias = "";
            this.cd_historico_juro.NM_Campo = "cd_historico";
            this.cd_historico_juro.NM_CampoBusca = "cd_historico";
            this.cd_historico_juro.NM_Param = "@P_CD_HISTORICO";
            this.cd_historico_juro.QTD_Zero = 0;
            this.cd_historico_juro.Size = new System.Drawing.Size(67, 20);
            this.cd_historico_juro.ST_AutoInc = false;
            this.cd_historico_juro.ST_DisableAuto = false;
            this.cd_historico_juro.ST_Float = false;
            this.cd_historico_juro.ST_Gravar = true;
            this.cd_historico_juro.ST_Int = false;
            this.cd_historico_juro.ST_LimpaCampo = true;
            this.cd_historico_juro.ST_NotNull = false;
            this.cd_historico_juro.ST_PrimaryKey = false;
            this.cd_historico_juro.TabIndex = 8;
            this.cd_historico_juro.Leave += new System.EventHandler(this.cd_historico_juro_Leave);
            // 
            // bb_historico_juro
            // 
            this.bb_historico_juro.BackColor = System.Drawing.SystemColors.Control;
            this.bb_historico_juro.Enabled = false;
            this.bb_historico_juro.Image = ((System.Drawing.Image)(resources.GetObject("bb_historico_juro.Image")));
            this.bb_historico_juro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_historico_juro.Location = new System.Drawing.Point(156, 81);
            this.bb_historico_juro.Name = "bb_historico_juro";
            this.bb_historico_juro.Size = new System.Drawing.Size(28, 19);
            this.bb_historico_juro.TabIndex = 9;
            this.bb_historico_juro.UseVisualStyleBackColor = false;
            this.bb_historico_juro.Click += new System.EventHandler(this.bb_historico_juro_Click);
            // 
            // ds_historico_juro
            // 
            this.ds_historico_juro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico_juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFaturaCartao, "Ds_historico_juro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_historico_juro.Enabled = false;
            this.ds_historico_juro.Location = new System.Drawing.Point(190, 81);
            this.ds_historico_juro.Name = "ds_historico_juro";
            this.ds_historico_juro.NM_Alias = "";
            this.ds_historico_juro.NM_Campo = "ds_historico";
            this.ds_historico_juro.NM_CampoBusca = "ds_historico";
            this.ds_historico_juro.NM_Param = "@P_DS_HISTORICO";
            this.ds_historico_juro.QTD_Zero = 0;
            this.ds_historico_juro.Size = new System.Drawing.Size(410, 20);
            this.ds_historico_juro.ST_AutoInc = false;
            this.ds_historico_juro.ST_DisableAuto = false;
            this.ds_historico_juro.ST_Float = false;
            this.ds_historico_juro.ST_Gravar = false;
            this.ds_historico_juro.ST_Int = false;
            this.ds_historico_juro.ST_LimpaCampo = true;
            this.ds_historico_juro.ST_NotNull = false;
            this.ds_historico_juro.ST_PrimaryKey = false;
            this.ds_historico_juro.TabIndex = 78;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dshistoricojuroDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn3});
            this.dataGridDefault1.DataSource = this.bsCfgFaturaCartao;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 134);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(659, 201);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 92;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ds_historico_rec";
            this.dataGridViewTextBoxColumn1.HeaderText = "Historico Recebimento";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 127;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_historico_pag";
            this.dataGridViewTextBoxColumn2.HeaderText = "Historico Pagamento";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 119;
            // 
            // dshistoricojuroDataGridViewTextBoxColumn
            // 
            this.dshistoricojuroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dshistoricojuroDataGridViewTextBoxColumn.DataPropertyName = "Ds_historico_juro";
            this.dshistoricojuroDataGridViewTextBoxColumn.HeaderText = "Historico Juro";
            this.dshistoricojuroDataGridViewTextBoxColumn.Name = "dshistoricojuroDataGridViewTextBoxColumn";
            this.dshistoricojuroDataGridViewTextBoxColumn.ReadOnly = true;
            this.dshistoricojuroDataGridViewTextBoxColumn.Width = 88;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Ds_historico_taxa";
            this.dataGridViewTextBoxColumn3.HeaderText = "Historico Taxa";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 92;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCfgFaturaCartao;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 335);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(659, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registro";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // cd_historico_pag
            // 
            this.cd_historico_pag.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico_pag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico_pag.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFaturaCartao, "Cd_historico_pag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_historico_pag.Enabled = false;
            this.cd_historico_pag.Location = new System.Drawing.Point(88, 55);
            this.cd_historico_pag.MaxLength = 4;
            this.cd_historico_pag.Name = "cd_historico_pag";
            this.cd_historico_pag.NM_Alias = "";
            this.cd_historico_pag.NM_Campo = "cd_historico";
            this.cd_historico_pag.NM_CampoBusca = "cd_historico";
            this.cd_historico_pag.NM_Param = "@P_CD_HISTORICO";
            this.cd_historico_pag.QTD_Zero = 0;
            this.cd_historico_pag.Size = new System.Drawing.Size(67, 20);
            this.cd_historico_pag.ST_AutoInc = false;
            this.cd_historico_pag.ST_DisableAuto = false;
            this.cd_historico_pag.ST_Float = false;
            this.cd_historico_pag.ST_Gravar = true;
            this.cd_historico_pag.ST_Int = false;
            this.cd_historico_pag.ST_LimpaCampo = true;
            this.cd_historico_pag.ST_NotNull = true;
            this.cd_historico_pag.ST_PrimaryKey = false;
            this.cd_historico_pag.TabIndex = 6;
            this.cd_historico_pag.Leave += new System.EventHandler(this.cd_historico_pag_Leave);
            // 
            // bb_historico_pag
            // 
            this.bb_historico_pag.BackColor = System.Drawing.SystemColors.Control;
            this.bb_historico_pag.Enabled = false;
            this.bb_historico_pag.Image = ((System.Drawing.Image)(resources.GetObject("bb_historico_pag.Image")));
            this.bb_historico_pag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_historico_pag.Location = new System.Drawing.Point(156, 55);
            this.bb_historico_pag.Name = "bb_historico_pag";
            this.bb_historico_pag.Size = new System.Drawing.Size(28, 19);
            this.bb_historico_pag.TabIndex = 7;
            this.bb_historico_pag.UseVisualStyleBackColor = false;
            this.bb_historico_pag.Click += new System.EventHandler(this.bb_historico_pag_Click);
            // 
            // ds_historico_pag
            // 
            this.ds_historico_pag.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico_pag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico_pag.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFaturaCartao, "Ds_historico_pag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_historico_pag.Enabled = false;
            this.ds_historico_pag.Location = new System.Drawing.Point(190, 55);
            this.ds_historico_pag.Name = "ds_historico_pag";
            this.ds_historico_pag.NM_Alias = "";
            this.ds_historico_pag.NM_Campo = "ds_historico";
            this.ds_historico_pag.NM_CampoBusca = "ds_historico";
            this.ds_historico_pag.NM_Param = "@P_DS_HISTORICO";
            this.ds_historico_pag.QTD_Zero = 0;
            this.ds_historico_pag.Size = new System.Drawing.Size(410, 20);
            this.ds_historico_pag.ST_AutoInc = false;
            this.ds_historico_pag.ST_DisableAuto = false;
            this.ds_historico_pag.ST_Float = false;
            this.ds_historico_pag.ST_Gravar = false;
            this.ds_historico_pag.ST_Int = false;
            this.ds_historico_pag.ST_LimpaCampo = true;
            this.ds_historico_pag.ST_NotNull = false;
            this.ds_historico_pag.ST_PrimaryKey = false;
            this.ds_historico_pag.TabIndex = 82;
            // 
            // cd_historico_taxa
            // 
            this.cd_historico_taxa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico_taxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico_taxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFaturaCartao, "Cd_historico_taxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_historico_taxa.Enabled = false;
            this.cd_historico_taxa.Location = new System.Drawing.Point(88, 107);
            this.cd_historico_taxa.MaxLength = 4;
            this.cd_historico_taxa.Name = "cd_historico_taxa";
            this.cd_historico_taxa.NM_Alias = "";
            this.cd_historico_taxa.NM_Campo = "cd_historico";
            this.cd_historico_taxa.NM_CampoBusca = "cd_historico";
            this.cd_historico_taxa.NM_Param = "@P_CD_HISTORICO";
            this.cd_historico_taxa.QTD_Zero = 0;
            this.cd_historico_taxa.Size = new System.Drawing.Size(67, 20);
            this.cd_historico_taxa.ST_AutoInc = false;
            this.cd_historico_taxa.ST_DisableAuto = false;
            this.cd_historico_taxa.ST_Float = false;
            this.cd_historico_taxa.ST_Gravar = true;
            this.cd_historico_taxa.ST_Int = false;
            this.cd_historico_taxa.ST_LimpaCampo = true;
            this.cd_historico_taxa.ST_NotNull = false;
            this.cd_historico_taxa.ST_PrimaryKey = false;
            this.cd_historico_taxa.TabIndex = 10;
            this.cd_historico_taxa.Leave += new System.EventHandler(this.cd_historico_taxa_Leave);
            // 
            // bb_historico_taxa
            // 
            this.bb_historico_taxa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_historico_taxa.Enabled = false;
            this.bb_historico_taxa.Image = ((System.Drawing.Image)(resources.GetObject("bb_historico_taxa.Image")));
            this.bb_historico_taxa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_historico_taxa.Location = new System.Drawing.Point(156, 107);
            this.bb_historico_taxa.Name = "bb_historico_taxa";
            this.bb_historico_taxa.Size = new System.Drawing.Size(28, 19);
            this.bb_historico_taxa.TabIndex = 11;
            this.bb_historico_taxa.UseVisualStyleBackColor = false;
            this.bb_historico_taxa.Click += new System.EventHandler(this.bb_historico_taxa_Click);
            // 
            // ds_historico_taxa
            // 
            this.ds_historico_taxa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico_taxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico_taxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFaturaCartao, "Ds_historico_taxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_historico_taxa.Enabled = false;
            this.ds_historico_taxa.Location = new System.Drawing.Point(190, 107);
            this.ds_historico_taxa.Name = "ds_historico_taxa";
            this.ds_historico_taxa.NM_Alias = "";
            this.ds_historico_taxa.NM_Campo = "ds_historico";
            this.ds_historico_taxa.NM_CampoBusca = "ds_historico";
            this.ds_historico_taxa.NM_Param = "@P_DS_HISTORICO";
            this.ds_historico_taxa.QTD_Zero = 0;
            this.ds_historico_taxa.Size = new System.Drawing.Size(410, 20);
            this.ds_historico_taxa.ST_AutoInc = false;
            this.ds_historico_taxa.ST_DisableAuto = false;
            this.ds_historico_taxa.ST_Float = false;
            this.ds_historico_taxa.ST_Gravar = false;
            this.ds_historico_taxa.ST_Int = false;
            this.ds_historico_taxa.ST_LimpaCampo = true;
            this.ds_historico_taxa.ST_NotNull = false;
            this.ds_historico_taxa.ST_PrimaryKey = false;
            this.ds_historico_taxa.TabIndex = 86;
            // 
            // TFCadCFGFaturaCartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadCFGFaturaCartao";
            this.Text = "Configuração Fatura Cartão";
            this.Load += new System.EventHandler(this.TFCadCFGFaturaCartao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCFGFaturaCartao_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgFaturaCartao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_historico_juro;
        private System.Windows.Forms.Button bb_historico_juro;
        private Componentes.EditDefault ds_historico_juro;
        private Componentes.EditDefault cd_historico_rec;
        private System.Windows.Forms.Button bb_historico_rec;
        private Componentes.EditDefault ds_historico_rec;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsCfgFaturaCartao;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdhistoricocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dshistoricocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdhistoricojurocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dshistoricojurocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdhistoricodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dshistoricodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdhistoricojurodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dshistoricojurodDataGridViewTextBoxColumn;
        private Componentes.EditDefault cd_historico_pag;
        private System.Windows.Forms.Button bb_historico_pag;
        private Componentes.EditDefault ds_historico_pag;
        private Componentes.EditDefault cd_historico_taxa;
        private System.Windows.Forms.Button bb_historico_taxa;
        private Componentes.EditDefault ds_historico_taxa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcontagerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscontagerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dshistoricojuroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}
