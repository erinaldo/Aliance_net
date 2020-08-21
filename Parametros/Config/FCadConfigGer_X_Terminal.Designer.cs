namespace Parametros.Config
{
    partial class TFCadConfigGer_X_Terminal
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
            System.Windows.Forms.Label id_parametroLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadConfigGer_X_Terminal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.id_parametro = new Componentes.EditDefault(this.components);
            this.bsConfigGerTerminal = new System.Windows.Forms.BindingSource(this.components);
            this.bb_terminal = new System.Windows.Forms.Button();
            this.bb_parametro = new System.Windows.Forms.Button();
            this.cd_terminal = new Componentes.EditDefault(this.components);
            this.ds_parametro = new Componentes.EditDefault(this.components);
            this.nm_terminal = new Componentes.EditDefault(this.components);
            this.idparametroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsparametroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdTerminalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmTerminalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.nConfigGerXTerminal = new System.Windows.Forms.BindingNavigator(this.components);
            this.tList_RegParamGer_X_TerminalDataGridDefault = new Componentes.DataGridDefault(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idparametroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idparametrostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsparametroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdTerminalDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmTerminalDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cd_empresaLabel = new System.Windows.Forms.Label();
            id_parametroLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConfigGerTerminal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nConfigGerXTerminal)).BeginInit();
            this.nConfigGerXTerminal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tList_RegParamGer_X_TerminalDataGridDefault)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.id_parametro);
            this.pDados.Controls.Add(this.bb_parametro);
            this.pDados.Controls.Add(this.bb_terminal);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.cd_terminal);
            this.pDados.Controls.Add(this.ds_parametro);
            this.pDados.Controls.Add(id_parametroLabel);
            this.pDados.Controls.Add(this.nm_terminal);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.Paint += new System.Windows.Forms.PaintEventHandler(this.pDados_Paint);
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.tList_RegParamGer_X_TerminalDataGridDefault);
            this.tpPadrao.Controls.Add(this.nConfigGerXTerminal);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.nConfigGerXTerminal, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.tList_RegParamGer_X_TerminalDataGridDefault, 0);
            // 
            // cd_empresaLabel
            // 
            resources.ApplyResources(cd_empresaLabel, "cd_empresaLabel");
            cd_empresaLabel.Name = "cd_empresaLabel";
            // 
            // id_parametroLabel
            // 
            resources.ApplyResources(id_parametroLabel, "id_parametroLabel");
            id_parametroLabel.Name = "id_parametroLabel";
            id_parametroLabel.Click += new System.EventHandler(this.id_parametroLabel_Click);
            // 
            // id_parametro
            // 
            this.id_parametro.BackColor = System.Drawing.SystemColors.Window;
            this.id_parametro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_parametro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConfigGerTerminal, "Id_parametrostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.id_parametro, "id_parametro");
            this.id_parametro.Name = "id_parametro";
            this.id_parametro.NM_Campo = "id_parametro";
            this.id_parametro.NM_CampoBusca = "id_parametro";
            this.id_parametro.NM_Param = "@P_ID_PARAMETRO";
            this.id_parametro.QTD_Zero = 0;
            this.id_parametro.ST_AutoInc = false;
            this.id_parametro.ST_DisableAuto = false;
            this.id_parametro.ST_Float = false;
            this.id_parametro.ST_Gravar = true;
            this.id_parametro.ST_Int = true;
            this.id_parametro.ST_LimpaCampo = true;
            this.id_parametro.ST_NotNull = true;
            this.id_parametro.ST_PrimaryKey = true;
            this.id_parametro.Leave += new System.EventHandler(this.id_parametro_Leave);
            // 
            // bsConfigGerTerminal
            // 
            this.bsConfigGerTerminal.DataSource = typeof(CamadaDados.ConfigGer.TList_RegParamGer_X_Terminal);
            // 
            // bb_terminal
            // 
            resources.ApplyResources(this.bb_terminal, "bb_terminal");
            this.bb_terminal.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_terminal.Name = "bb_terminal";
            this.bb_terminal.UseVisualStyleBackColor = true;
            this.bb_terminal.Click += new System.EventHandler(this.bb_terminal_Click);
            // 
            // bb_parametro
            // 
            resources.ApplyResources(this.bb_parametro, "bb_parametro");
            this.bb_parametro.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_parametro.Name = "bb_parametro";
            this.bb_parametro.UseVisualStyleBackColor = true;
            this.bb_parametro.Click += new System.EventHandler(this.bb_parametro_Click);
            // 
            // cd_terminal
            // 
            this.cd_terminal.BackColor = System.Drawing.SystemColors.Window;
            this.cd_terminal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_terminal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConfigGerTerminal, "Cd_Terminal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_terminal, "cd_terminal");
            this.cd_terminal.Name = "cd_terminal";
            this.cd_terminal.NM_Campo = "cd_terminal";
            this.cd_terminal.NM_CampoBusca = "cd_terminal";
            this.cd_terminal.NM_Param = "@P_CD_TERMINAL";
            this.cd_terminal.QTD_Zero = 0;
            this.cd_terminal.ST_AutoInc = false;
            this.cd_terminal.ST_DisableAuto = false;
            this.cd_terminal.ST_Float = false;
            this.cd_terminal.ST_Gravar = true;
            this.cd_terminal.ST_Int = true;
            this.cd_terminal.ST_LimpaCampo = true;
            this.cd_terminal.ST_NotNull = true;
            this.cd_terminal.ST_PrimaryKey = true;
            this.cd_terminal.Leave += new System.EventHandler(this.cd_terminal_Leave);
            // 
            // ds_parametro
            // 
            this.ds_parametro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_parametro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_parametro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConfigGerTerminal, "Ds_parametro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_parametro, "ds_parametro");
            this.ds_parametro.Name = "ds_parametro";
            this.ds_parametro.NM_Campo = "ds_parametro";
            this.ds_parametro.NM_CampoBusca = "ds_parametro";
            this.ds_parametro.NM_Param = "@P_DS_PARAMETRO";
            this.ds_parametro.QTD_Zero = 0;
            this.ds_parametro.ST_AutoInc = false;
            this.ds_parametro.ST_DisableAuto = false;
            this.ds_parametro.ST_Float = false;
            this.ds_parametro.ST_Gravar = false;
            this.ds_parametro.ST_Int = false;
            this.ds_parametro.ST_LimpaCampo = true;
            this.ds_parametro.ST_NotNull = false;
            this.ds_parametro.ST_PrimaryKey = false;
            // 
            // nm_terminal
            // 
            this.nm_terminal.BackColor = System.Drawing.SystemColors.Window;
            this.nm_terminal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_terminal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConfigGerTerminal, "Nm_Terminal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nm_terminal, "nm_terminal");
            this.nm_terminal.Name = "nm_terminal";
            this.nm_terminal.NM_Campo = "ds_terminal";
            this.nm_terminal.NM_CampoBusca = "ds_terminal";
            this.nm_terminal.NM_Param = "@P_NM_TERMINAL";
            this.nm_terminal.QTD_Zero = 0;
            this.nm_terminal.ST_AutoInc = false;
            this.nm_terminal.ST_DisableAuto = false;
            this.nm_terminal.ST_Float = false;
            this.nm_terminal.ST_Gravar = false;
            this.nm_terminal.ST_Int = false;
            this.nm_terminal.ST_LimpaCampo = true;
            this.nm_terminal.ST_NotNull = false;
            this.nm_terminal.ST_PrimaryKey = false;
            this.nm_terminal.TextChanged += new System.EventHandler(this.nm_terminal_TextChanged);
            // 
            // idparametroDataGridViewTextBoxColumn
            // 
            this.idparametroDataGridViewTextBoxColumn.DataPropertyName = "Id_parametro";
            resources.ApplyResources(this.idparametroDataGridViewTextBoxColumn, "idparametroDataGridViewTextBoxColumn");
            this.idparametroDataGridViewTextBoxColumn.Name = "idparametroDataGridViewTextBoxColumn";
            this.idparametroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsparametroDataGridViewTextBoxColumn
            // 
            this.dsparametroDataGridViewTextBoxColumn.DataPropertyName = "Ds_parametro";
            resources.ApplyResources(this.dsparametroDataGridViewTextBoxColumn, "dsparametroDataGridViewTextBoxColumn");
            this.dsparametroDataGridViewTextBoxColumn.Name = "dsparametroDataGridViewTextBoxColumn";
            this.dsparametroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdTerminalDataGridViewTextBoxColumn
            // 
            this.cdTerminalDataGridViewTextBoxColumn.DataPropertyName = "Cd_Terminal";
            resources.ApplyResources(this.cdTerminalDataGridViewTextBoxColumn, "cdTerminalDataGridViewTextBoxColumn");
            this.cdTerminalDataGridViewTextBoxColumn.Name = "cdTerminalDataGridViewTextBoxColumn";
            this.cdTerminalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmTerminalDataGridViewTextBoxColumn
            // 
            this.nmTerminalDataGridViewTextBoxColumn.DataPropertyName = "Nm_Terminal";
            resources.ApplyResources(this.nmTerminalDataGridViewTextBoxColumn, "nmTerminalDataGridViewTextBoxColumn");
            this.nmTerminalDataGridViewTextBoxColumn.Name = "nmTerminalDataGridViewTextBoxColumn";
            this.nmTerminalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // nConfigGerXTerminal
            // 
            this.nConfigGerXTerminal.AddNewItem = null;
            this.nConfigGerXTerminal.BindingSource = this.bsConfigGerTerminal;
            this.nConfigGerXTerminal.CountItem = this.bindingNavigatorCountItem;
            this.nConfigGerXTerminal.DeleteItem = null;
            resources.ApplyResources(this.nConfigGerXTerminal, "nConfigGerXTerminal");
            this.nConfigGerXTerminal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.nConfigGerXTerminal.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.nConfigGerXTerminal.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.nConfigGerXTerminal.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.nConfigGerXTerminal.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.nConfigGerXTerminal.Name = "nConfigGerXTerminal";
            this.nConfigGerXTerminal.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // tList_RegParamGer_X_TerminalDataGridDefault
            // 
            this.tList_RegParamGer_X_TerminalDataGridDefault.AllowUserToAddRows = false;
            this.tList_RegParamGer_X_TerminalDataGridDefault.AllowUserToDeleteRows = false;
            this.tList_RegParamGer_X_TerminalDataGridDefault.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.tList_RegParamGer_X_TerminalDataGridDefault.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tList_RegParamGer_X_TerminalDataGridDefault.AutoGenerateColumns = false;
            this.tList_RegParamGer_X_TerminalDataGridDefault.BackgroundColor = System.Drawing.Color.LightGray;
            this.tList_RegParamGer_X_TerminalDataGridDefault.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tList_RegParamGer_X_TerminalDataGridDefault.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_RegParamGer_X_TerminalDataGridDefault.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.tList_RegParamGer_X_TerminalDataGridDefault, "tList_RegParamGer_X_TerminalDataGridDefault");
            this.tList_RegParamGer_X_TerminalDataGridDefault.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.dataGridViewTextBoxColumn1,
            this.Column3,
            this.idparametroDataGridViewTextBoxColumn1,
            this.idparametrostrDataGridViewTextBoxColumn,
            this.dsparametroDataGridViewTextBoxColumn1,
            this.cdTerminalDataGridViewTextBoxColumn1,
            this.nmTerminalDataGridViewTextBoxColumn1});
            this.tList_RegParamGer_X_TerminalDataGridDefault.DataSource = this.bsConfigGerTerminal;
            this.tList_RegParamGer_X_TerminalDataGridDefault.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tList_RegParamGer_X_TerminalDataGridDefault.Name = "tList_RegParamGer_X_TerminalDataGridDefault";
            this.tList_RegParamGer_X_TerminalDataGridDefault.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_RegParamGer_X_TerminalDataGridDefault.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tList_RegParamGer_X_TerminalDataGridDefault.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tList_RegParamGer_X_TerminalDataGridDefault_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.DataPropertyName = "Id_parametrostr";
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.DataPropertyName = "Ds_parametro";
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cd_Terminal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.DataPropertyName = "Nm_Terminal";
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // idparametroDataGridViewTextBoxColumn1
            // 
            this.idparametroDataGridViewTextBoxColumn1.DataPropertyName = "Id_parametro";
            resources.ApplyResources(this.idparametroDataGridViewTextBoxColumn1, "idparametroDataGridViewTextBoxColumn1");
            this.idparametroDataGridViewTextBoxColumn1.Name = "idparametroDataGridViewTextBoxColumn1";
            this.idparametroDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // idparametrostrDataGridViewTextBoxColumn
            // 
            this.idparametrostrDataGridViewTextBoxColumn.DataPropertyName = "Id_parametrostr";
            resources.ApplyResources(this.idparametrostrDataGridViewTextBoxColumn, "idparametrostrDataGridViewTextBoxColumn");
            this.idparametrostrDataGridViewTextBoxColumn.Name = "idparametrostrDataGridViewTextBoxColumn";
            this.idparametrostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsparametroDataGridViewTextBoxColumn1
            // 
            this.dsparametroDataGridViewTextBoxColumn1.DataPropertyName = "Ds_parametro";
            resources.ApplyResources(this.dsparametroDataGridViewTextBoxColumn1, "dsparametroDataGridViewTextBoxColumn1");
            this.dsparametroDataGridViewTextBoxColumn1.Name = "dsparametroDataGridViewTextBoxColumn1";
            this.dsparametroDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cdTerminalDataGridViewTextBoxColumn1
            // 
            this.cdTerminalDataGridViewTextBoxColumn1.DataPropertyName = "Cd_Terminal";
            resources.ApplyResources(this.cdTerminalDataGridViewTextBoxColumn1, "cdTerminalDataGridViewTextBoxColumn1");
            this.cdTerminalDataGridViewTextBoxColumn1.Name = "cdTerminalDataGridViewTextBoxColumn1";
            this.cdTerminalDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nmTerminalDataGridViewTextBoxColumn1
            // 
            this.nmTerminalDataGridViewTextBoxColumn1.DataPropertyName = "Nm_Terminal";
            resources.ApplyResources(this.nmTerminalDataGridViewTextBoxColumn1, "nmTerminalDataGridViewTextBoxColumn1");
            this.nmTerminalDataGridViewTextBoxColumn1.Name = "nmTerminalDataGridViewTextBoxColumn1";
            this.nmTerminalDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // TFCadConfigGer_X_Terminal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCadConfigGer_X_Terminal";
            this.Load += new System.EventHandler(this.TFCadConfigGer_X_Terminal_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadConfigGer_X_Terminal_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConfigGerTerminal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nConfigGerXTerminal)).EndInit();
            this.nConfigGerXTerminal.ResumeLayout(false);
            this.nConfigGerXTerminal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tList_RegParamGer_X_TerminalDataGridDefault)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault id_parametro;
        public System.Windows.Forms.Button bb_terminal;
        public System.Windows.Forms.Button bb_parametro;
        private Componentes.EditDefault cd_terminal;
        private Componentes.EditDefault ds_parametro;
        private Componentes.EditDefault nm_terminal;
        private System.Windows.Forms.BindingSource bsConfigGerTerminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idparametroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsparametroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdTerminalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmTerminalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator nConfigGerXTerminal;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault tList_RegParamGer_X_TerminalDataGridDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idparametroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idparametrostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsparametroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdTerminalDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmTerminalDataGridViewTextBoxColumn1;
    }
}