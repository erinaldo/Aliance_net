namespace Parametros.Diversos
{
    partial class TFCadTabelaPreco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTabelaPreco));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LB_CD_TabelaPreco = new System.Windows.Forms.Label();
            this.LB_DS_TabelaPreco = new System.Windows.Forms.Label();
            this.CD_TabelaPreco = new Componentes.EditDefault(this.components);
            this.DS_TabelaPreco = new Componentes.EditDefault(this.components);
            this.g_cadTabelaPreco = new Componentes.DataGridDefault(this.components);
            this.BN_TabelaPreco = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.BS_TabelaPreco = new System.Windows.Forms.BindingSource(this.components);
            this.cDTabelaPrecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSTabelaPrecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_cadTabelaPreco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TabelaPreco)).BeginInit();
            this.BN_TabelaPreco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_TabelaPreco)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.LB_CD_TabelaPreco);
            this.pDados.Controls.Add(this.LB_DS_TabelaPreco);
            this.pDados.Controls.Add(this.CD_TabelaPreco);
            this.pDados.Controls.Add(this.DS_TabelaPreco);
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
            this.tpPadrao.Controls.Add(this.g_cadTabelaPreco);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_cadTabelaPreco, 0);
            // 
            // LB_CD_TabelaPreco
            // 
            this.LB_CD_TabelaPreco.AccessibleDescription = null;
            this.LB_CD_TabelaPreco.AccessibleName = null;
            resources.ApplyResources(this.LB_CD_TabelaPreco, "LB_CD_TabelaPreco");
            this.LB_CD_TabelaPreco.Name = "LB_CD_TabelaPreco";
            // 
            // LB_DS_TabelaPreco
            // 
            this.LB_DS_TabelaPreco.AccessibleDescription = null;
            this.LB_DS_TabelaPreco.AccessibleName = null;
            resources.ApplyResources(this.LB_DS_TabelaPreco, "LB_DS_TabelaPreco");
            this.LB_DS_TabelaPreco.Name = "LB_DS_TabelaPreco";
            // 
            // CD_TabelaPreco
            // 
            this.CD_TabelaPreco.AccessibleDescription = null;
            this.CD_TabelaPreco.AccessibleName = null;
            resources.ApplyResources(this.CD_TabelaPreco, "CD_TabelaPreco");
            this.CD_TabelaPreco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_TabelaPreco.BackgroundImage = null;
            this.CD_TabelaPreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_TabelaPreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TabelaPreco, "CD_TabelaPreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_TabelaPreco.Font = null;
            this.CD_TabelaPreco.Name = "CD_TabelaPreco";
            this.CD_TabelaPreco.NM_Alias = "";
            this.CD_TabelaPreco.NM_Campo = "CD_TabelaPreco";
            this.CD_TabelaPreco.NM_CampoBusca = "CD_TabelaPreco";
            this.CD_TabelaPreco.NM_Param = "@P_CD_TABELAPRECO";
            this.CD_TabelaPreco.QTD_Zero = 2;
            this.CD_TabelaPreco.ST_AutoInc = false;
            this.CD_TabelaPreco.ST_DisableAuto = true;
            this.CD_TabelaPreco.ST_Float = false;
            this.CD_TabelaPreco.ST_Gravar = true;
            this.CD_TabelaPreco.ST_Int = true;
            this.CD_TabelaPreco.ST_LimpaCampo = true;
            this.CD_TabelaPreco.ST_NotNull = true;
            this.CD_TabelaPreco.ST_PrimaryKey = true;
            // 
            // DS_TabelaPreco
            // 
            this.DS_TabelaPreco.AccessibleDescription = null;
            this.DS_TabelaPreco.AccessibleName = null;
            resources.ApplyResources(this.DS_TabelaPreco, "DS_TabelaPreco");
            this.DS_TabelaPreco.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TabelaPreco.BackgroundImage = null;
            this.DS_TabelaPreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TabelaPreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TabelaPreco, "DS_TabelaPreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_TabelaPreco.Font = null;
            this.DS_TabelaPreco.Name = "DS_TabelaPreco";
            this.DS_TabelaPreco.NM_Alias = "";
            this.DS_TabelaPreco.NM_Campo = "DS_TabelaPreco";
            this.DS_TabelaPreco.NM_CampoBusca = "DS_TabelaPreco";
            this.DS_TabelaPreco.NM_Param = "@P_DS_TABELAPRECO";
            this.DS_TabelaPreco.QTD_Zero = 0;
            this.DS_TabelaPreco.ST_AutoInc = false;
            this.DS_TabelaPreco.ST_DisableAuto = false;
            this.DS_TabelaPreco.ST_Float = false;
            this.DS_TabelaPreco.ST_Gravar = true;
            this.DS_TabelaPreco.ST_Int = false;
            this.DS_TabelaPreco.ST_LimpaCampo = true;
            this.DS_TabelaPreco.ST_NotNull = false;
            this.DS_TabelaPreco.ST_PrimaryKey = false;
            // 
            // g_cadTabelaPreco
            // 
            this.g_cadTabelaPreco.AccessibleDescription = null;
            this.g_cadTabelaPreco.AccessibleName = null;
            this.g_cadTabelaPreco.AllowUserToAddRows = false;
            this.g_cadTabelaPreco.AllowUserToDeleteRows = false;
            this.g_cadTabelaPreco.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.g_cadTabelaPreco.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.g_cadTabelaPreco, "g_cadTabelaPreco");
            this.g_cadTabelaPreco.AutoGenerateColumns = false;
            this.g_cadTabelaPreco.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_cadTabelaPreco.BackgroundImage = null;
            this.g_cadTabelaPreco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_cadTabelaPreco.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_cadTabelaPreco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_cadTabelaPreco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_cadTabelaPreco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDTabelaPrecoDataGridViewTextBoxColumn,
            this.dSTabelaPrecoDataGridViewTextBoxColumn});
            this.g_cadTabelaPreco.DataSource = this.BS_TabelaPreco;
            this.g_cadTabelaPreco.Font = null;
            this.g_cadTabelaPreco.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_cadTabelaPreco.Name = "g_cadTabelaPreco";
            this.g_cadTabelaPreco.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_cadTabelaPreco.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_cadTabelaPreco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_cadTabelaPreco.TabStop = false;
            // 
            // BN_TabelaPreco
            // 
            this.BN_TabelaPreco.AccessibleDescription = null;
            this.BN_TabelaPreco.AccessibleName = null;
            this.BN_TabelaPreco.AddNewItem = null;
            resources.ApplyResources(this.BN_TabelaPreco, "BN_TabelaPreco");
            this.BN_TabelaPreco.BackgroundImage = null;
            this.BN_TabelaPreco.BindingSource = this.BS_TabelaPreco;
            this.BN_TabelaPreco.CountItem = this.bindingNavigatorCountItem;
            this.BN_TabelaPreco.DeleteItem = null;
            this.BN_TabelaPreco.Font = null;
            this.BN_TabelaPreco.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_TabelaPreco.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_TabelaPreco.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_TabelaPreco.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_TabelaPreco.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_TabelaPreco.Name = "BN_TabelaPreco";
            this.BN_TabelaPreco.PositionItem = this.bindingNavigatorPositionItem;
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
            // BS_TabelaPreco
            // 
            this.BS_TabelaPreco.DataSource = typeof(CamadaDados.Diversos.TList_CadTbPreco);
            // 
            // cDTabelaPrecoDataGridViewTextBoxColumn
            // 
            this.cDTabelaPrecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDTabelaPrecoDataGridViewTextBoxColumn.DataPropertyName = "CD_TabelaPreco";
            resources.ApplyResources(this.cDTabelaPrecoDataGridViewTextBoxColumn, "cDTabelaPrecoDataGridViewTextBoxColumn");
            this.cDTabelaPrecoDataGridViewTextBoxColumn.Name = "cDTabelaPrecoDataGridViewTextBoxColumn";
            this.cDTabelaPrecoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSTabelaPrecoDataGridViewTextBoxColumn
            // 
            this.dSTabelaPrecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSTabelaPrecoDataGridViewTextBoxColumn.DataPropertyName = "DS_TabelaPreco";
            resources.ApplyResources(this.dSTabelaPrecoDataGridViewTextBoxColumn, "dSTabelaPrecoDataGridViewTextBoxColumn");
            this.dSTabelaPrecoDataGridViewTextBoxColumn.Name = "dSTabelaPrecoDataGridViewTextBoxColumn";
            this.dSTabelaPrecoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCadTabelaPreco
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.BN_TabelaPreco);
            this.Font = null;
            this.Name = "TFCadTabelaPreco";
            this.Load += new System.EventHandler(this.TFCadTabelaPreco_Load);
            this.Controls.SetChildIndex(this.BN_TabelaPreco, 0);
            this.Controls.SetChildIndex(this.tcCentral, 0);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g_cadTabelaPreco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TabelaPreco)).EndInit();
            this.BN_TabelaPreco.ResumeLayout(false);
            this.BN_TabelaPreco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_TabelaPreco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_CD_TabelaPreco;
        private System.Windows.Forms.Label LB_DS_TabelaPreco;

        private Componentes.EditDefault CD_TabelaPreco;
        private Componentes.EditDefault DS_TabelaPreco;
        private Componentes.DataGridDefault g_cadTabelaPreco;
        private System.Windows.Forms.BindingNavigator BN_TabelaPreco;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource BS_TabelaPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDTabelaPrecoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSTabelaPrecoDataGridViewTextBoxColumn;

                                                                                                            

    }
}
