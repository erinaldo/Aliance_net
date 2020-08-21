namespace Estoque.Cadastros
{
    partial class TFCadEmpresa_X_Moega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadEmpresa_X_Moega));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BS_CadEmpresa_X_Moega = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Moega = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.g_TFCadEmpresa_X_Moega = new Componentes.DataGridDefault(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSMoegaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BB_Moega = new System.Windows.Forms.Button();
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.BN_CadEmpresa_X_Moega = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.CD_Moega = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadEmpresa_X_Moega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TFCadEmpresa_X_Moega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadEmpresa_X_Moega)).BeginInit();
            this.BN_CadEmpresa_X_Moega.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.CD_Moega);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.BB_Moega);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.DS_Moega);
            this.pDados.NM_ProcDeletar = "EXCLUI_EST_EMPRESA_X_MOEGA";
            this.pDados.NM_ProcGravar = "IA_EST_EMPRESA_X_MOEGA";
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            this.tcCentral.Font = null;
            this.tcCentral.SelectedIndexChanged += new System.EventHandler(this.tcCentral_SelectedIndexChanged);
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.BN_CadEmpresa_X_Moega);
            this.tpPadrao.Controls.Add(this.g_TFCadEmpresa_X_Moega);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_TFCadEmpresa_X_Moega, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadEmpresa_X_Moega, 0);
            // 
            // BS_CadEmpresa_X_Moega
            // 
            this.BS_CadEmpresa_X_Moega.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadEmpresa_X_Moega);
            // 
            // DS_Moega
            // 
            this.DS_Moega.AccessibleDescription = null;
            this.DS_Moega.AccessibleName = null;
            resources.ApplyResources(this.DS_Moega, "DS_Moega");
            this.DS_Moega.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Moega.BackgroundImage = null;
            this.DS_Moega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Moega.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadEmpresa_X_Moega, "DS_Moega", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Moega.Name = "DS_Moega";
            this.DS_Moega.NM_Alias = "";
            this.DS_Moega.NM_Campo = "DS_Moega";
            this.DS_Moega.NM_CampoBusca = "DS_Moega";
            this.DS_Moega.NM_Param = "@P_DS_MOEGA";
            this.DS_Moega.QTD_Zero = 0;
            this.DS_Moega.ST_AutoInc = false;
            this.DS_Moega.ST_DisableAuto = true;
            this.DS_Moega.ST_Float = false;
            this.DS_Moega.ST_Gravar = false;
            this.DS_Moega.ST_Int = false;
            this.DS_Moega.ST_LimpaCampo = true;
            this.DS_Moega.ST_NotNull = false;
            this.DS_Moega.ST_PrimaryKey = false;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.AccessibleDescription = null;
            this.CD_Empresa.AccessibleName = null;
            resources.ApplyResources(this.CD_Empresa, "CD_Empresa");
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BackgroundImage = null;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadEmpresa_X_Moega, "CD_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "a";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = true;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.AccessibleDescription = null;
            this.NM_Empresa.AccessibleName = null;
            resources.ApplyResources(this.NM_Empresa, "NM_Empresa");
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BackgroundImage = null;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadEmpresa_X_Moega, "NM_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = true;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // g_TFCadEmpresa_X_Moega
            // 
            this.g_TFCadEmpresa_X_Moega.AccessibleDescription = null;
            this.g_TFCadEmpresa_X_Moega.AccessibleName = null;
            this.g_TFCadEmpresa_X_Moega.AllowUserToAddRows = false;
            this.g_TFCadEmpresa_X_Moega.AllowUserToDeleteRows = false;
            this.g_TFCadEmpresa_X_Moega.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.g_TFCadEmpresa_X_Moega.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.g_TFCadEmpresa_X_Moega, "g_TFCadEmpresa_X_Moega");
            this.g_TFCadEmpresa_X_Moega.AutoGenerateColumns = false;
            this.g_TFCadEmpresa_X_Moega.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_TFCadEmpresa_X_Moega.BackgroundImage = null;
            this.g_TFCadEmpresa_X_Moega.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_TFCadEmpresa_X_Moega.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_TFCadEmpresa_X_Moega.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_TFCadEmpresa_X_Moega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_TFCadEmpresa_X_Moega.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dSMoegaDataGridViewTextBoxColumn,
            this.cDEmpresaDataGridViewTextBoxColumn,
            this.nMEmpresaDataGridViewTextBoxColumn});
            this.g_TFCadEmpresa_X_Moega.DataSource = this.BS_CadEmpresa_X_Moega;
            this.g_TFCadEmpresa_X_Moega.Font = null;
            this.g_TFCadEmpresa_X_Moega.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_TFCadEmpresa_X_Moega.Name = "g_TFCadEmpresa_X_Moega";
            this.g_TFCadEmpresa_X_Moega.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_TFCadEmpresa_X_Moega.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_TFCadEmpresa_X_Moega.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_TFCadEmpresa_X_Moega.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CD_Moega";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dSMoegaDataGridViewTextBoxColumn
            // 
            this.dSMoegaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSMoegaDataGridViewTextBoxColumn.DataPropertyName = "DS_Moega";
            resources.ApplyResources(this.dSMoegaDataGridViewTextBoxColumn, "dSMoegaDataGridViewTextBoxColumn");
            this.dSMoegaDataGridViewTextBoxColumn.Name = "dSMoegaDataGridViewTextBoxColumn";
            this.dSMoegaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cDEmpresaDataGridViewTextBoxColumn
            // 
            this.cDEmpresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDEmpresaDataGridViewTextBoxColumn.DataPropertyName = "CD_Empresa";
            resources.ApplyResources(this.cDEmpresaDataGridViewTextBoxColumn, "cDEmpresaDataGridViewTextBoxColumn");
            this.cDEmpresaDataGridViewTextBoxColumn.Name = "cDEmpresaDataGridViewTextBoxColumn";
            this.cDEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nMEmpresaDataGridViewTextBoxColumn
            // 
            this.nMEmpresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMEmpresaDataGridViewTextBoxColumn.DataPropertyName = "NM_Empresa";
            resources.ApplyResources(this.nMEmpresaDataGridViewTextBoxColumn, "nMEmpresaDataGridViewTextBoxColumn");
            this.nMEmpresaDataGridViewTextBoxColumn.Name = "nMEmpresaDataGridViewTextBoxColumn";
            this.nMEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BB_Moega
            // 
            this.BB_Moega.AccessibleDescription = null;
            this.BB_Moega.AccessibleName = null;
            resources.ApplyResources(this.BB_Moega, "BB_Moega");
            this.BB_Moega.BackgroundImage = null;
            this.BB_Moega.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Moega.Font = null;
            this.BB_Moega.Name = "BB_Moega";
            this.BB_Moega.UseVisualStyleBackColor = true;
            this.BB_Moega.Click += new System.EventHandler(this.BB_Moega_Click);
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.AccessibleDescription = null;
            this.BB_Empresa.AccessibleName = null;
            resources.ApplyResources(this.BB_Empresa, "BB_Empresa");
            this.BB_Empresa.BackgroundImage = null;
            this.BB_Empresa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Empresa.Font = null;
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // BN_CadEmpresa_X_Moega
            // 
            this.BN_CadEmpresa_X_Moega.AccessibleDescription = null;
            this.BN_CadEmpresa_X_Moega.AccessibleName = null;
            this.BN_CadEmpresa_X_Moega.AddNewItem = null;
            resources.ApplyResources(this.BN_CadEmpresa_X_Moega, "BN_CadEmpresa_X_Moega");
            this.BN_CadEmpresa_X_Moega.BackgroundImage = null;
            this.BN_CadEmpresa_X_Moega.BindingSource = this.BS_CadEmpresa_X_Moega;
            this.BN_CadEmpresa_X_Moega.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadEmpresa_X_Moega.DeleteItem = null;
            this.BN_CadEmpresa_X_Moega.Font = null;
            this.BN_CadEmpresa_X_Moega.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadEmpresa_X_Moega.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadEmpresa_X_Moega.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadEmpresa_X_Moega.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadEmpresa_X_Moega.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadEmpresa_X_Moega.Name = "BN_CadEmpresa_X_Moega";
            this.BN_CadEmpresa_X_Moega.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.AccessibleDescription = null;
            this.bindingNavigatorCountItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.BackgroundImage = null;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.AccessibleDescription = null;
            this.bindingNavigatorSeparator.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.AccessibleDescription = null;
            this.bindingNavigatorSeparator1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // CD_Moega
            // 
            this.CD_Moega.AccessibleDescription = null;
            this.CD_Moega.AccessibleName = null;
            resources.ApplyResources(this.CD_Moega, "CD_Moega");
            this.CD_Moega.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Moega.BackgroundImage = null;
            this.CD_Moega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Moega.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadEmpresa_X_Moega, "CD_Moega", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Moega.Name = "CD_Moega";
            this.CD_Moega.NM_Alias = "a";
            this.CD_Moega.NM_Campo = "CD_Moega";
            this.CD_Moega.NM_CampoBusca = "CD_Moega";
            this.CD_Moega.NM_Param = "@P_CD_MOEGA";
            this.CD_Moega.QTD_Zero = 0;
            this.CD_Moega.ST_AutoInc = false;
            this.CD_Moega.ST_DisableAuto = false;
            this.CD_Moega.ST_Float = false;
            this.CD_Moega.ST_Gravar = true;
            this.CD_Moega.ST_Int = true;
            this.CD_Moega.ST_LimpaCampo = true;
            this.CD_Moega.ST_NotNull = true;
            this.CD_Moega.ST_PrimaryKey = true;
            this.CD_Moega.Leave += new System.EventHandler(this.CD_Moega_Leave);
            // 
            // TFCadEmpresa_X_Moega
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadEmpresa_X_Moega";
            this.Load += new System.EventHandler(this.TFCadEmpresa_X_Moega_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadEmpresa_X_Moega_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadEmpresa_X_Moega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TFCadEmpresa_X_Moega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadEmpresa_X_Moega)).EndInit();
            this.BN_CadEmpresa_X_Moega.ResumeLayout(false);
            this.BN_CadEmpresa_X_Moega.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditDefault DS_Moega;
        private Componentes.DataGridDefault g_TFCadEmpresa_X_Moega;
        public System.Windows.Forms.Button BB_Moega;
        public System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.BindingSource BS_CadEmpresa_X_Moega;
        private System.Windows.Forms.BindingNavigator BN_CadEmpresa_X_Moega;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault CD_Moega;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSMoegaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMEmpresaDataGridViewTextBoxColumn;

    }
}
