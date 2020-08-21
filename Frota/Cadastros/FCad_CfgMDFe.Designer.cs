namespace Frota.Cadastros
{
    partial class TFCad_CfgMDFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_CfgMDFe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bb_pathschemas = new System.Windows.Forms.Button();
            this.path_schemas = new Componentes.EditDefault(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.nr_certificado = new Componentes.EditDefault(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.tp_ambiente = new Componentes.ComboBoxDefault(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.cd_versaolayout = new Componentes.EditDefault(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.cd_versaomodal = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsMDFe = new System.Windows.Forms.BindingSource(this.components);
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathschemasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrcertificadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoambienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdversaomdfeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdversaomodalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnMDFe = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMDFe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnMDFe)).BeginInit();
            this.bnMDFe.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.cd_versaomodal);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_versaolayout);
            this.pDados.Controls.Add(this.label20);
            this.pDados.Controls.Add(this.tp_ambiente);
            this.pDados.Controls.Add(this.label19);
            this.pDados.Controls.Add(this.nr_certificado);
            this.pDados.Controls.Add(this.label18);
            this.pDados.Controls.Add(this.bb_pathschemas);
            this.pDados.Controls.Add(this.path_schemas);
            this.pDados.Controls.Add(this.label17);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Size = new System.Drawing.Size(659, 110);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bnMDFe);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bnMDFe, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMDFe, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(200, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(349, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 62;
            this.nm_empresa.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Empresa:";
            // 
            // bb_empresa
            // 
            this.bb_empresa.Enabled = false;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(166, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMDFe, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(94, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(72, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = true;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // bb_pathschemas
            // 
            this.bb_pathschemas.BackColor = System.Drawing.SystemColors.Control;
            this.bb_pathschemas.Location = new System.Drawing.Point(521, 29);
            this.bb_pathschemas.Name = "bb_pathschemas";
            this.bb_pathschemas.Size = new System.Drawing.Size(28, 19);
            this.bb_pathschemas.TabIndex = 3;
            this.bb_pathschemas.Text = "...";
            this.bb_pathschemas.UseVisualStyleBackColor = false;
            this.bb_pathschemas.Click += new System.EventHandler(this.bb_pathschemas_Click);
            // 
            // path_schemas
            // 
            this.path_schemas.BackColor = System.Drawing.SystemColors.Window;
            this.path_schemas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.path_schemas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.path_schemas.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMDFe, "Path_schemas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.path_schemas.Enabled = false;
            this.path_schemas.Location = new System.Drawing.Point(94, 29);
            this.path_schemas.Name = "path_schemas";
            this.path_schemas.NM_Alias = "";
            this.path_schemas.NM_Campo = "";
            this.path_schemas.NM_CampoBusca = "";
            this.path_schemas.NM_Param = "";
            this.path_schemas.QTD_Zero = 0;
            this.path_schemas.Size = new System.Drawing.Size(425, 20);
            this.path_schemas.ST_AutoInc = false;
            this.path_schemas.ST_DisableAuto = false;
            this.path_schemas.ST_Float = false;
            this.path_schemas.ST_Gravar = true;
            this.path_schemas.ST_Int = false;
            this.path_schemas.ST_LimpaCampo = true;
            this.path_schemas.ST_NotNull = false;
            this.path_schemas.ST_PrimaryKey = false;
            this.path_schemas.TabIndex = 2;
            this.path_schemas.TextOld = null;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(9, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 13);
            this.label17.TabIndex = 66;
            this.label17.Text = "Path Schemas:";
            // 
            // nr_certificado
            // 
            this.nr_certificado.BackColor = System.Drawing.SystemColors.Window;
            this.nr_certificado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_certificado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_certificado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMDFe, "Nr_certificado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_certificado.Enabled = false;
            this.nr_certificado.Location = new System.Drawing.Point(94, 55);
            this.nr_certificado.Name = "nr_certificado";
            this.nr_certificado.NM_Alias = "";
            this.nr_certificado.NM_Campo = "";
            this.nr_certificado.NM_CampoBusca = "";
            this.nr_certificado.NM_Param = "";
            this.nr_certificado.QTD_Zero = 0;
            this.nr_certificado.Size = new System.Drawing.Size(279, 20);
            this.nr_certificado.ST_AutoInc = false;
            this.nr_certificado.ST_DisableAuto = false;
            this.nr_certificado.ST_Float = false;
            this.nr_certificado.ST_Gravar = true;
            this.nr_certificado.ST_Int = false;
            this.nr_certificado.ST_LimpaCampo = true;
            this.nr_certificado.ST_NotNull = false;
            this.nr_certificado.ST_PrimaryKey = false;
            this.nr_certificado.TabIndex = 4;
            this.nr_certificado.TextOld = null;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(1, 57);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 13);
            this.label18.TabIndex = 68;
            this.label18.Text = "Série Certificado:";
            // 
            // tp_ambiente
            // 
            this.tp_ambiente.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMDFe, "Tp_ambiente", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_ambiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_ambiente.Enabled = false;
            this.tp_ambiente.FormattingEnabled = true;
            this.tp_ambiente.Location = new System.Drawing.Point(439, 55);
            this.tp_ambiente.Name = "tp_ambiente";
            this.tp_ambiente.NM_Alias = "";
            this.tp_ambiente.NM_Campo = "";
            this.tp_ambiente.NM_Param = "";
            this.tp_ambiente.Size = new System.Drawing.Size(110, 21);
            this.tp_ambiente.ST_Gravar = true;
            this.tp_ambiente.ST_LimparCampo = true;
            this.tp_ambiente.ST_NotNull = true;
            this.tp_ambiente.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(379, 59);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 13);
            this.label19.TabIndex = 70;
            this.label19.Text = "Ambiente:";
            // 
            // cd_versaolayout
            // 
            this.cd_versaolayout.BackColor = System.Drawing.SystemColors.Window;
            this.cd_versaolayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_versaolayout.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_versaolayout.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMDFe, "Cd_versaomdfe", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_versaolayout.Enabled = false;
            this.cd_versaolayout.Location = new System.Drawing.Point(94, 81);
            this.cd_versaolayout.Name = "cd_versaolayout";
            this.cd_versaolayout.NM_Alias = "";
            this.cd_versaolayout.NM_Campo = "";
            this.cd_versaolayout.NM_CampoBusca = "";
            this.cd_versaolayout.NM_Param = "";
            this.cd_versaolayout.QTD_Zero = 0;
            this.cd_versaolayout.Size = new System.Drawing.Size(41, 20);
            this.cd_versaolayout.ST_AutoInc = false;
            this.cd_versaolayout.ST_DisableAuto = false;
            this.cd_versaolayout.ST_Float = false;
            this.cd_versaolayout.ST_Gravar = true;
            this.cd_versaolayout.ST_Int = false;
            this.cd_versaolayout.ST_LimpaCampo = true;
            this.cd_versaolayout.ST_NotNull = false;
            this.cd_versaolayout.ST_PrimaryKey = false;
            this.cd_versaolayout.TabIndex = 6;
            this.cd_versaolayout.TextOld = null;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(13, 85);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 13);
            this.label20.TabIndex = 72;
            this.label20.Text = "Versão MDFe:";
            // 
            // cd_versaomodal
            // 
            this.cd_versaomodal.BackColor = System.Drawing.SystemColors.Window;
            this.cd_versaomodal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_versaomodal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_versaomodal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMDFe, "Cd_versaomodal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_versaomodal.Enabled = false;
            this.cd_versaomodal.Location = new System.Drawing.Point(222, 81);
            this.cd_versaomodal.Name = "cd_versaomodal";
            this.cd_versaomodal.NM_Alias = "";
            this.cd_versaomodal.NM_Campo = "";
            this.cd_versaomodal.NM_CampoBusca = "";
            this.cd_versaomodal.NM_Param = "";
            this.cd_versaomodal.QTD_Zero = 0;
            this.cd_versaomodal.Size = new System.Drawing.Size(41, 20);
            this.cd_versaomodal.ST_AutoInc = false;
            this.cd_versaomodal.ST_DisableAuto = false;
            this.cd_versaomodal.ST_Float = false;
            this.cd_versaomodal.ST_Gravar = true;
            this.cd_versaomodal.ST_Int = false;
            this.cd_versaomodal.ST_LimpaCampo = true;
            this.cd_versaomodal.ST_NotNull = false;
            this.cd_versaomodal.ST_PrimaryKey = false;
            this.cd_versaomodal.TabIndex = 7;
            this.cd_versaomodal.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(141, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Versão Modal:";
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
            this.pathschemasDataGridViewTextBoxColumn,
            this.nrcertificadoDataGridViewTextBoxColumn,
            this.tipoambienteDataGridViewTextBoxColumn,
            this.cdversaomdfeDataGridViewTextBoxColumn,
            this.cdversaomodalDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsMDFe;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 110);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(659, 225);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // bsMDFe
            // 
            this.bsMDFe.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_CfgMDFe);
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
            // pathschemasDataGridViewTextBoxColumn
            // 
            this.pathschemasDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pathschemasDataGridViewTextBoxColumn.DataPropertyName = "Path_schemas";
            this.pathschemasDataGridViewTextBoxColumn.HeaderText = "Path Schemas";
            this.pathschemasDataGridViewTextBoxColumn.Name = "pathschemasDataGridViewTextBoxColumn";
            this.pathschemasDataGridViewTextBoxColumn.ReadOnly = true;
            this.pathschemasDataGridViewTextBoxColumn.Width = 101;
            // 
            // nrcertificadoDataGridViewTextBoxColumn
            // 
            this.nrcertificadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrcertificadoDataGridViewTextBoxColumn.DataPropertyName = "Nr_certificado";
            this.nrcertificadoDataGridViewTextBoxColumn.HeaderText = "Série Certificado";
            this.nrcertificadoDataGridViewTextBoxColumn.Name = "nrcertificadoDataGridViewTextBoxColumn";
            this.nrcertificadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoambienteDataGridViewTextBoxColumn
            // 
            this.tipoambienteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipoambienteDataGridViewTextBoxColumn.DataPropertyName = "Tipo_ambiente";
            this.tipoambienteDataGridViewTextBoxColumn.HeaderText = "Ambiente";
            this.tipoambienteDataGridViewTextBoxColumn.Name = "tipoambienteDataGridViewTextBoxColumn";
            this.tipoambienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoambienteDataGridViewTextBoxColumn.Width = 76;
            // 
            // cdversaomdfeDataGridViewTextBoxColumn
            // 
            this.cdversaomdfeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdversaomdfeDataGridViewTextBoxColumn.DataPropertyName = "Cd_versaomdfe";
            this.cdversaomdfeDataGridViewTextBoxColumn.HeaderText = "Versão MDF-e";
            this.cdversaomdfeDataGridViewTextBoxColumn.Name = "cdversaomdfeDataGridViewTextBoxColumn";
            this.cdversaomdfeDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdversaomdfeDataGridViewTextBoxColumn.Width = 92;
            // 
            // cdversaomodalDataGridViewTextBoxColumn
            // 
            this.cdversaomodalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdversaomodalDataGridViewTextBoxColumn.DataPropertyName = "Cd_versaomodal";
            this.cdversaomodalDataGridViewTextBoxColumn.HeaderText = "Versão Modal";
            this.cdversaomodalDataGridViewTextBoxColumn.Name = "cdversaomodalDataGridViewTextBoxColumn";
            this.cdversaomodalDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdversaomodalDataGridViewTextBoxColumn.Width = 89;
            // 
            // bnMDFe
            // 
            this.bnMDFe.AddNewItem = null;
            this.bnMDFe.BindingSource = this.bsMDFe;
            this.bnMDFe.CountItem = this.bindingNavigatorCountItem;
            this.bnMDFe.CountItemFormat = "de {0}";
            this.bnMDFe.DeleteItem = null;
            this.bnMDFe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnMDFe.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnMDFe.Location = new System.Drawing.Point(0, 335);
            this.bnMDFe.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnMDFe.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnMDFe.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnMDFe.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnMDFe.Name = "bnMDFe";
            this.bnMDFe.PositionItem = this.bindingNavigatorPositionItem;
            this.bnMDFe.Size = new System.Drawing.Size(659, 25);
            this.bnMDFe.TabIndex = 2;
            this.bnMDFe.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            // TFCad_CfgMDFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCad_CfgMDFe";
            this.Text = "Configuração MDF-e";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMDFe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnMDFe)).EndInit();
            this.bnMDFe.ResumeLayout(false);
            this.bnMDFe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_pathschemas;
        private Componentes.EditDefault path_schemas;
        private System.Windows.Forms.Label label17;
        private Componentes.EditDefault nr_certificado;
        private System.Windows.Forms.Label label18;
        private Componentes.ComboBoxDefault tp_ambiente;
        private System.Windows.Forms.Label label19;
        private Componentes.EditDefault cd_versaomodal;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_versaolayout;
        private System.Windows.Forms.Label label20;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathschemasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcertificadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoambienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdversaomdfeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdversaomodalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsMDFe;
        private System.Windows.Forms.BindingNavigator bnMDFe;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
    }
}
