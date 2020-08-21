namespace Fiscal.Cadastros
{
    partial class TFCadSitTrib_PisCofins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadSitTrib_PisCofins));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_sitTrib = new Componentes.EditDefault(this.components);
            this.BS_SitTribPisCofins = new System.Windows.Forms.BindingSource(this.components);
            this.ds_sitTrib = new Componentes.EditDefault(this.components);
            this.gPesquisa = new Componentes.DataGridDefault(this.components);
            this.BN_SitTribPisCofins = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cdsittribDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dssittribDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_SitTribPisCofins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPesquisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_SitTribPisCofins)).BeginInit();
            this.BN_SitTribPisCofins.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.ds_sitTrib);
            this.pDados.Controls.Add(this.cd_sitTrib);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Font = null;
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            this.tcCentral.Font = null;
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.gPesquisa);
            this.tpPadrao.Controls.Add(this.BN_SitTribPisCofins);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.BN_SitTribPisCofins, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gPesquisa, 0);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cd_sitTrib
            // 
            this.cd_sitTrib.AccessibleDescription = null;
            this.cd_sitTrib.AccessibleName = null;
            resources.ApplyResources(this.cd_sitTrib, "cd_sitTrib");
            this.cd_sitTrib.BackColor = System.Drawing.SystemColors.Window;
            this.cd_sitTrib.BackgroundImage = null;
            this.cd_sitTrib.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_sitTrib.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_SitTribPisCofins, "Cd_sittrib", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_sitTrib.Font = null;
            this.cd_sitTrib.Name = "cd_sitTrib";
            this.cd_sitTrib.NM_Alias = "";
            this.cd_sitTrib.NM_Campo = "cd_sitTrib";
            this.cd_sitTrib.NM_CampoBusca = "cd_sitTrib";
            this.cd_sitTrib.NM_Param = "@P_CD_SITTRIB";
            this.cd_sitTrib.QTD_Zero = 0;
            this.cd_sitTrib.ST_AutoInc = false;
            this.cd_sitTrib.ST_DisableAuto = true;
            this.cd_sitTrib.ST_Float = false;
            this.cd_sitTrib.ST_Gravar = true;
            this.cd_sitTrib.ST_Int = true;
            this.cd_sitTrib.ST_LimpaCampo = true;
            this.cd_sitTrib.ST_NotNull = true;
            this.cd_sitTrib.ST_PrimaryKey = true;
            this.cd_sitTrib.Leave += new System.EventHandler(this.cd_sitTrib_Leave);
            // 
            // BS_SitTribPisCofins
            // 
            this.BS_SitTribPisCofins.DataSource = typeof(CamadaDados.Fiscal.TList_CadSitTrib_Piscofins);
            // 
            // ds_sitTrib
            // 
            this.ds_sitTrib.AccessibleDescription = null;
            this.ds_sitTrib.AccessibleName = null;
            resources.ApplyResources(this.ds_sitTrib, "ds_sitTrib");
            this.ds_sitTrib.BackColor = System.Drawing.SystemColors.Window;
            this.ds_sitTrib.BackgroundImage = null;
            this.ds_sitTrib.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_sitTrib.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_SitTribPisCofins, "Ds_sittrib", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_sitTrib.Font = null;
            this.ds_sitTrib.Name = "ds_sitTrib";
            this.ds_sitTrib.NM_Alias = "";
            this.ds_sitTrib.NM_Campo = "ds_sitTrib";
            this.ds_sitTrib.NM_CampoBusca = "ds_sitTrib";
            this.ds_sitTrib.NM_Param = "@P_DS_SITTRIB";
            this.ds_sitTrib.QTD_Zero = 0;
            this.ds_sitTrib.ST_AutoInc = false;
            this.ds_sitTrib.ST_DisableAuto = false;
            this.ds_sitTrib.ST_Float = false;
            this.ds_sitTrib.ST_Gravar = true;
            this.ds_sitTrib.ST_Int = false;
            this.ds_sitTrib.ST_LimpaCampo = true;
            this.ds_sitTrib.ST_NotNull = true;
            this.ds_sitTrib.ST_PrimaryKey = true;
            // 
            // gPesquisa
            // 
            this.gPesquisa.AccessibleDescription = null;
            this.gPesquisa.AccessibleName = null;
            this.gPesquisa.AllowUserToAddRows = false;
            this.gPesquisa.AllowUserToDeleteRows = false;
            this.gPesquisa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPesquisa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gPesquisa, "gPesquisa");
            this.gPesquisa.AutoGenerateColumns = false;
            this.gPesquisa.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPesquisa.BackgroundImage = null;
            this.gPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPesquisa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPesquisa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdsittribDataGridViewTextBoxColumn,
            this.dssittribDataGridViewTextBoxColumn});
            this.gPesquisa.DataSource = this.BS_SitTribPisCofins;
            this.gPesquisa.Font = null;
            this.gPesquisa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPesquisa.Name = "gPesquisa";
            this.gPesquisa.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPesquisa.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // BN_SitTribPisCofins
            // 
            this.BN_SitTribPisCofins.AccessibleDescription = null;
            this.BN_SitTribPisCofins.AccessibleName = null;
            this.BN_SitTribPisCofins.AddNewItem = null;
            resources.ApplyResources(this.BN_SitTribPisCofins, "BN_SitTribPisCofins");
            this.BN_SitTribPisCofins.BackgroundImage = null;
            this.BN_SitTribPisCofins.CountItem = this.bindingNavigatorCountItem;
            this.BN_SitTribPisCofins.DeleteItem = null;
            this.BN_SitTribPisCofins.Font = null;
            this.BN_SitTribPisCofins.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_SitTribPisCofins.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_SitTribPisCofins.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_SitTribPisCofins.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_SitTribPisCofins.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_SitTribPisCofins.Name = "BN_SitTribPisCofins";
            this.BN_SitTribPisCofins.PositionItem = this.bindingNavigatorPositionItem;
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
            // cdsittribDataGridViewTextBoxColumn
            // 
            this.cdsittribDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdsittribDataGridViewTextBoxColumn.DataPropertyName = "Cd_sittrib";
            resources.ApplyResources(this.cdsittribDataGridViewTextBoxColumn, "cdsittribDataGridViewTextBoxColumn");
            this.cdsittribDataGridViewTextBoxColumn.Name = "cdsittribDataGridViewTextBoxColumn";
            this.cdsittribDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dssittribDataGridViewTextBoxColumn
            // 
            this.dssittribDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dssittribDataGridViewTextBoxColumn.DataPropertyName = "Ds_sittrib";
            resources.ApplyResources(this.dssittribDataGridViewTextBoxColumn, "dssittribDataGridViewTextBoxColumn");
            this.dssittribDataGridViewTextBoxColumn.Name = "dssittribDataGridViewTextBoxColumn";
            this.dssittribDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCadSitTrib_PisCofins
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadSitTrib_PisCofins";
            this.Load += new System.EventHandler(this.TFCadSitTrib_PisCofins_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_SitTribPisCofins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPesquisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_SitTribPisCofins)).EndInit();
            this.BN_SitTribPisCofins.ResumeLayout(false);
            this.BN_SitTribPisCofins.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault cd_sitTrib;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_sitTrib;
        private System.Windows.Forms.BindingNavigator BN_SitTribPisCofins;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault gPesquisa;
        private System.Windows.Forms.BindingSource BS_SitTribPisCofins;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdsittribDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dssittribDataGridViewTextBoxColumn;

    }
}
