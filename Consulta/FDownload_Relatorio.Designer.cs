namespace Consulta
{
    partial class TFDownload_Relatorio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDownload_Relatorio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcCentral = new System.Windows.Forms.TabControl();
            this.tpRDC = new System.Windows.Forms.TabPage();
            this.grid_Download = new Componentes.DataGridDefault(this.components);
            this.dSRDCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_Download = new System.Windows.Forms.BindingSource(this.components);
            this.BN_Download = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Limpar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.BB_Relatorio = new System.Windows.Forms.ToolStripButton();
            this.BB_Download = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tcCentral.SuspendLayout();
            this.tpRDC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Download)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Download)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Download)).BeginInit();
            this.BN_Download.SuspendLayout();
            this.pDadosFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCentral
            // 
            this.tcCentral.Controls.Add(this.tpRDC);
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.Multiline = true;
            this.tcCentral.Name = "tcCentral";
            this.tcCentral.SelectedIndex = 0;
            // 
            // tpRDC
            // 
            this.tpRDC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tpRDC.Controls.Add(this.grid_Download);
            this.tpRDC.Controls.Add(this.BN_Download);
            this.tpRDC.Controls.Add(this.pDadosFiltros);
            resources.ApplyResources(this.tpRDC, "tpRDC");
            this.tpRDC.Name = "tpRDC";
            this.tpRDC.UseVisualStyleBackColor = true;
            // 
            // grid_Download
            // 
            this.grid_Download.AllowUserToAddRows = false;
            this.grid_Download.AllowUserToDeleteRows = false;
            this.grid_Download.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.grid_Download.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Download.AutoGenerateColumns = false;
            this.grid_Download.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid_Download.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_Download.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Download.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Download.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Download.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dSRDCDataGridViewTextBoxColumn,
            this.versaoDataGridViewTextBoxColumn,
            this.moduloDataGridViewTextBoxColumn});
            this.grid_Download.DataSource = this.BS_Download;
            resources.ApplyResources(this.grid_Download, "grid_Download");
            this.grid_Download.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grid_Download.Name = "grid_Download";
            this.grid_Download.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Download.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            // BS_Download
            // 
            this.BS_Download.DataSource = typeof(CamadaDados.WS_RDC.TRegistro_Cad_RDC);
            // 
            // BN_Download
            // 
            this.BN_Download.AddNewItem = null;
            this.BN_Download.BindingSource = this.BS_Download;
            this.BN_Download.CountItem = this.bindingNavigatorCountItem;
            this.BN_Download.CountItemFormat = "de {0}";
            this.BN_Download.DeleteItem = null;
            resources.ApplyResources(this.BN_Download, "BN_Download");
            this.BN_Download.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_Download.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_Download.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_Download.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_Download.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_Download.Name = "BN_Download";
            this.BN_Download.PositionItem = this.bindingNavigatorPositionItem;
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
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
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
            resources.ApplyResources(this.dataGridDefault1, "dataGridDefault1");
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
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
            // 
            // barraMenu
            // 
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Limpar,
            this.BB_Buscar,
            this.BB_Relatorio,
            this.BB_Download,
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
            // BB_Download
            // 
            resources.ApplyResources(this.BB_Download, "BB_Download");
            this.BB_Download.ForeColor = System.Drawing.Color.Green;
            this.BB_Download.Name = "BB_Download";
            this.BB_Download.Click += new System.EventHandler(this.BB_Download_Click);
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
            // TFDownload_Relatorio
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDownload_Relatorio";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFDownload_Relatorio_Load);
            this.tcCentral.ResumeLayout(false);
            this.tpRDC.ResumeLayout(false);
            this.tpRDC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Download)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Download)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Download)).EndInit();
            this.BN_Download.ResumeLayout(false);
            this.BN_Download.PerformLayout();
            this.pDadosFiltros.ResumeLayout(false);
            this.pDadosFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TabControl tcCentral;
        public System.Windows.Forms.TabPage tpRDC;
        private Componentes.PanelDados pDadosFiltros;
        private Componentes.DataGridDefault dataGridDefault1;
        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Limpar;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripButton BB_Relatorio;
        private Componentes.ComboBoxDefault cbModulo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LB_DS_TabelaPreco;
        private Componentes.EditDefault DS_RDC;
        private System.Windows.Forms.ToolStripButton BB_Download;
        private System.Windows.Forms.BindingSource BS_Download;
        private Componentes.DataGridDefault grid_Download;
        private System.Windows.Forms.BindingNavigator BN_Download;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSRDCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduloDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
    }
}