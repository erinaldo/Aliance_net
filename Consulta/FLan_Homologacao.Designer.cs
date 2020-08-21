namespace Consulta
{
    partial class TFLan_Homologacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLan_Homologacao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Limpar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.BB_Relatorio = new System.Windows.Forms.ToolStripButton();
            this.BB_Homologar = new System.Windows.Forms.ToolStripButton();
            this.BB_EditSQL = new System.Windows.Forms.ToolStripButton();
            this.tcCentral = new System.Windows.Forms.TabControl();
            this.tpRDC = new System.Windows.Forms.TabPage();
            this.grid_Homologacao = new Componentes.DataGridDefault(this.components);
            this.dSRDCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_Homologacao = new System.Windows.Forms.BindingSource(this.components);
            this.BN_Homologacao = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDadosFiltros = new Componentes.PanelDados(this.components);
            this.cbModulo = new Componentes.ComboBoxDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.LB_DS_TabelaPreco = new System.Windows.Forms.Label();
            this.DS_RDC = new Componentes.EditDefault(this.components);
            this.tabDTS = new System.Windows.Forms.TabPage();
            this.grid_DTS = new Componentes.DataGridDefault(this.components);
            this.dSDataSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTDataSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_DTS = new System.Windows.Forms.BindingSource(this.components);
            this.BN_DTS = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.barraMenu.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpRDC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Homologacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Homologacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Homologacao)).BeginInit();
            this.BN_Homologacao.SuspendLayout();
            this.pDadosFiltros.SuspendLayout();
            this.tabDTS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_DTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_DTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_DTS)).BeginInit();
            this.BN_DTS.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Limpar,
            this.BB_Buscar,
            this.BB_Relatorio,
            this.BB_Homologar,
            this.BB_EditSQL,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Limpar
            // 
            resources.ApplyResources(this.BB_Limpar, "BB_Limpar");
            this.BB_Limpar.ForeColor = System.Drawing.Color.Green;
            this.BB_Limpar.Name = "BB_Limpar";
            this.BB_Limpar.Click += new System.EventHandler(this.BB_Limpar_Click);
            // 
            // BB_Buscar
            // 
            resources.ApplyResources(this.BB_Buscar, "BB_Buscar");
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // BB_Relatorio
            // 
            resources.ApplyResources(this.BB_Relatorio, "BB_Relatorio");
            this.BB_Relatorio.ForeColor = System.Drawing.Color.Green;
            this.BB_Relatorio.Name = "BB_Relatorio";
            this.BB_Relatorio.Click += new System.EventHandler(this.BB_Relatorio_Click);
            // 
            // BB_Homologar
            // 
            resources.ApplyResources(this.BB_Homologar, "BB_Homologar");
            this.BB_Homologar.ForeColor = System.Drawing.Color.Green;
            this.BB_Homologar.Name = "BB_Homologar";
            this.BB_Homologar.Click += new System.EventHandler(this.BB_Homologar_Click);
            // 
            // BB_EditSQL
            // 
            resources.ApplyResources(this.BB_EditSQL, "BB_EditSQL");
            this.BB_EditSQL.ForeColor = System.Drawing.Color.Green;
            this.BB_EditSQL.Name = "BB_EditSQL";
            this.BB_EditSQL.Click += new System.EventHandler(this.BB_EditSQL_Click);
            // 
            // tcCentral
            // 
            this.tcCentral.Controls.Add(this.tpRDC);
            this.tcCentral.Controls.Add(this.tabDTS);
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.Multiline = true;
            this.tcCentral.Name = "tcCentral";
            this.tcCentral.SelectedIndex = 0;
            // 
            // tpRDC
            // 
            this.tpRDC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tpRDC.Controls.Add(this.grid_Homologacao);
            this.tpRDC.Controls.Add(this.BN_Homologacao);
            this.tpRDC.Controls.Add(this.pDadosFiltros);
            resources.ApplyResources(this.tpRDC, "tpRDC");
            this.tpRDC.Name = "tpRDC";
            this.tpRDC.UseVisualStyleBackColor = true;
            this.tpRDC.Enter += new System.EventHandler(this.tpRDC_Enter);
            // 
            // grid_Homologacao
            // 
            this.grid_Homologacao.AllowUserToAddRows = false;
            this.grid_Homologacao.AllowUserToDeleteRows = false;
            this.grid_Homologacao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.grid_Homologacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Homologacao.AutoGenerateColumns = false;
            this.grid_Homologacao.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid_Homologacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_Homologacao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Homologacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Homologacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Homologacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dSRDCDataGridViewTextBoxColumn,
            this.versaoDataGridViewTextBoxColumn,
            this.moduloDataGridViewTextBoxColumn});
            this.grid_Homologacao.DataSource = this.BS_Homologacao;
            resources.ApplyResources(this.grid_Homologacao, "grid_Homologacao");
            this.grid_Homologacao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grid_Homologacao.Name = "grid_Homologacao";
            this.grid_Homologacao.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Homologacao.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // dSRDCDataGridViewTextBoxColumn
            // 
            this.dSRDCDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSRDCDataGridViewTextBoxColumn.DataPropertyName = "DS_RDC";
            resources.ApplyResources(this.dSRDCDataGridViewTextBoxColumn, "dSRDCDataGridViewTextBoxColumn");
            this.dSRDCDataGridViewTextBoxColumn.Name = "dSRDCDataGridViewTextBoxColumn";
            this.dSRDCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // versaoDataGridViewTextBoxColumn
            // 
            this.versaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.versaoDataGridViewTextBoxColumn.DataPropertyName = "Versao";
            resources.ApplyResources(this.versaoDataGridViewTextBoxColumn, "versaoDataGridViewTextBoxColumn");
            this.versaoDataGridViewTextBoxColumn.Name = "versaoDataGridViewTextBoxColumn";
            this.versaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // moduloDataGridViewTextBoxColumn
            // 
            this.moduloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.moduloDataGridViewTextBoxColumn.DataPropertyName = "Modulo";
            resources.ApplyResources(this.moduloDataGridViewTextBoxColumn, "moduloDataGridViewTextBoxColumn");
            this.moduloDataGridViewTextBoxColumn.Name = "moduloDataGridViewTextBoxColumn";
            this.moduloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BS_Homologacao
            // 
            this.BS_Homologacao.DataSource = typeof(CamadaDados.WS_RDC.TRegistro_Cad_RDC);
            // 
            // BN_Homologacao
            // 
            this.BN_Homologacao.AddNewItem = null;
            this.BN_Homologacao.BindingSource = this.BS_Homologacao;
            this.BN_Homologacao.CountItem = this.bindingNavigatorCountItem;
            this.BN_Homologacao.DeleteItem = null;
            resources.ApplyResources(this.BN_Homologacao, "BN_Homologacao");
            this.BN_Homologacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_Homologacao.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_Homologacao.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_Homologacao.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_Homologacao.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_Homologacao.Name = "BN_Homologacao";
            this.BN_Homologacao.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
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
            // pDadosFiltros
            // 
            this.pDadosFiltros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDadosFiltros.Controls.Add(this.cbModulo);
            this.pDadosFiltros.Controls.Add(this.label8);
            this.pDadosFiltros.Controls.Add(this.LB_DS_TabelaPreco);
            this.pDadosFiltros.Controls.Add(this.DS_RDC);
            resources.ApplyResources(this.pDadosFiltros, "pDadosFiltros");
            this.pDadosFiltros.Name = "pDadosFiltros";
            // 
            // cbModulo
            // 
            this.cbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModulo.FormattingEnabled = true;
            resources.ApplyResources(this.cbModulo, "cbModulo");
            this.cbModulo.Name = "cbModulo";
            this.cbModulo.ST_Gravar = true;
            this.cbModulo.ST_LimparCampo = true;
            this.cbModulo.ST_NotNull = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // LB_DS_TabelaPreco
            // 
            resources.ApplyResources(this.LB_DS_TabelaPreco, "LB_DS_TabelaPreco");
            this.LB_DS_TabelaPreco.Name = "LB_DS_TabelaPreco";
            // 
            // DS_RDC
            // 
            this.DS_RDC.BackColor = System.Drawing.SystemColors.Window;
            this.DS_RDC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.DS_RDC, "DS_RDC");
            this.DS_RDC.Name = "DS_RDC";
            this.DS_RDC.NM_Campo = "DS_Report";
            this.DS_RDC.NM_CampoBusca = "DS_Report";
            this.DS_RDC.NM_Param = "@P_DS_REPORT";
            this.DS_RDC.QTD_Zero = 0;
            this.DS_RDC.ST_AutoInc = false;
            this.DS_RDC.ST_DisableAuto = false;
            this.DS_RDC.ST_Float = false;
            this.DS_RDC.ST_Gravar = true;
            this.DS_RDC.ST_Int = false;
            this.DS_RDC.ST_LimpaCampo = true;
            this.DS_RDC.ST_NotNull = true;
            this.DS_RDC.ST_PrimaryKey = false;
            // 
            // tabDTS
            // 
            this.tabDTS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDTS.Controls.Add(this.grid_DTS);
            this.tabDTS.Controls.Add(this.BN_DTS);
            resources.ApplyResources(this.tabDTS, "tabDTS");
            this.tabDTS.Name = "tabDTS";
            this.tabDTS.UseVisualStyleBackColor = true;
            this.tabDTS.Enter += new System.EventHandler(this.tabDTS_Enter);
            // 
            // grid_DTS
            // 
            this.grid_DTS.AllowUserToAddRows = false;
            this.grid_DTS.AllowUserToDeleteRows = false;
            this.grid_DTS.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.grid_DTS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grid_DTS.AutoGenerateColumns = false;
            this.grid_DTS.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid_DTS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_DTS.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_DTS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grid_DTS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_DTS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dSDataSourceDataGridViewTextBoxColumn,
            this.dTDataSourceDataGridViewTextBoxColumn});
            this.grid_DTS.DataSource = this.BS_DTS;
            resources.ApplyResources(this.grid_DTS, "grid_DTS");
            this.grid_DTS.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grid_DTS.Name = "grid_DTS";
            this.grid_DTS.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_DTS.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            // 
            // dSDataSourceDataGridViewTextBoxColumn
            // 
            this.dSDataSourceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSDataSourceDataGridViewTextBoxColumn.DataPropertyName = "DS_DataSource";
            resources.ApplyResources(this.dSDataSourceDataGridViewTextBoxColumn, "dSDataSourceDataGridViewTextBoxColumn");
            this.dSDataSourceDataGridViewTextBoxColumn.Name = "dSDataSourceDataGridViewTextBoxColumn";
            this.dSDataSourceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dTDataSourceDataGridViewTextBoxColumn
            // 
            this.dTDataSourceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dTDataSourceDataGridViewTextBoxColumn.DataPropertyName = "DT_DataSource";
            resources.ApplyResources(this.dTDataSourceDataGridViewTextBoxColumn, "dTDataSourceDataGridViewTextBoxColumn");
            this.dTDataSourceDataGridViewTextBoxColumn.Name = "dTDataSourceDataGridViewTextBoxColumn";
            this.dTDataSourceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BS_DTS
            // 
            this.BS_DTS.DataMember = "lCad_DataSource";
            this.BS_DTS.DataSource = this.BS_Homologacao;
            // 
            // BN_DTS
            // 
            this.BN_DTS.AddNewItem = null;
            this.BN_DTS.BindingSource = this.BS_DTS;
            this.BN_DTS.CountItem = this.bindingNavigatorCountItem1;
            this.BN_DTS.DeleteItem = null;
            resources.ApplyResources(this.BN_DTS, "BN_DTS");
            this.BN_DTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1});
            this.BN_DTS.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.BN_DTS.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.BN_DTS.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.BN_DTS.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.BN_DTS.Name = "BN_DTS";
            this.BN_DTS.PositionItem = this.bindingNavigatorPositionItem1;
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            resources.ApplyResources(this.bindingNavigatorCountItem1, "bindingNavigatorCountItem1");
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem1, "bindingNavigatorMoveFirstItem1");
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem1, "bindingNavigatorMovePreviousItem1");
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            resources.ApplyResources(this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
            // 
            // bindingNavigatorPositionItem1
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem1, "bindingNavigatorPositionItem1");
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            resources.ApplyResources(this.bindingNavigatorSeparator3, "bindingNavigatorSeparator3");
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem1, "bindingNavigatorMoveNextItem1");
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem1, "bindingNavigatorMoveLastItem1");
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // BB_Fechar
            // 
            resources.ApplyResources(this.BB_Fechar, "BB_Fechar");
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // TFLan_Homologacao
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLan_Homologacao";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLan_Homologacao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLan_Homologacao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpRDC.ResumeLayout(false);
            this.tpRDC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Homologacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Homologacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Homologacao)).EndInit();
            this.BN_Homologacao.ResumeLayout(false);
            this.BN_Homologacao.PerformLayout();
            this.pDadosFiltros.ResumeLayout(false);
            this.pDadosFiltros.PerformLayout();
            this.tabDTS.ResumeLayout(false);
            this.tabDTS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_DTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_DTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_DTS)).EndInit();
            this.BN_DTS.ResumeLayout(false);
            this.BN_DTS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Limpar;
        public System.Windows.Forms.TabControl tcCentral;
        public System.Windows.Forms.TabPage tpRDC;
        private Componentes.PanelDados pDadosFiltros;
        private System.Windows.Forms.ToolStripButton BB_Relatorio;
        private System.Windows.Forms.ToolStripButton BB_Homologar;
        private Componentes.DataGridDefault grid_Homologacao;
        private System.Windows.Forms.BindingSource BS_Homologacao;
        private Componentes.ComboBoxDefault cbModulo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LB_DS_TabelaPreco;
        private Componentes.EditDefault DS_RDC;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripButton BB_EditSQL;
        private System.Windows.Forms.TabPage tabDTS;
        private Componentes.DataGridDefault grid_DTS;
        private System.Windows.Forms.BindingSource BS_DTS;
        private System.Windows.Forms.BindingNavigator BN_Homologacao;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingNavigator BN_DTS;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSDataSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTDataSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSRDCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduloDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
    }
}