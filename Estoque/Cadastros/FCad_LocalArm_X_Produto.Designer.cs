namespace Estoque.Cadastros
{
    partial class TFCad_LocalArm_X_Produto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_LocalArm_X_Produto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.g_CadLocalArm_X_Produto = new Componentes.DataGridDefault(this.components);
            this.cDLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_CadLocalArm_X_Produto = new System.Windows.Forms.BindingSource(this.components);
            this.BN_CadLocalArm_X_Produto = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.CD_Local = new Componentes.EditDefault(this.components);
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BB_Local = new System.Windows.Forms.Button();
            this.BB_Produto = new System.Windows.Forms.Button();
            this.DS_Local = new Componentes.EditDefault(this.components);
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadLocalArm_X_Produto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadLocalArm_X_Produto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadLocalArm_X_Produto)).BeginInit();
            this.BN_CadLocalArm_X_Produto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.DS_Local);
            this.pDados.Controls.Add(this.BB_Produto);
            this.pDados.Controls.Add(this.BB_Local);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.Controls.Add(this.CD_Local);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_CadLocalArm_X_Produto);
            this.tpPadrao.Controls.Add(this.BN_CadLocalArm_X_Produto);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadLocalArm_X_Produto, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_CadLocalArm_X_Produto, 0);
            // 
            // g_CadLocalArm_X_Produto
            // 
            this.g_CadLocalArm_X_Produto.AllowUserToAddRows = false;
            this.g_CadLocalArm_X_Produto.AllowUserToDeleteRows = false;
            this.g_CadLocalArm_X_Produto.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_CadLocalArm_X_Produto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.g_CadLocalArm_X_Produto.AutoGenerateColumns = false;
            this.g_CadLocalArm_X_Produto.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_CadLocalArm_X_Produto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_CadLocalArm_X_Produto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadLocalArm_X_Produto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.g_CadLocalArm_X_Produto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_CadLocalArm_X_Produto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDLocalDataGridViewTextBoxColumn,
            this.dSLocalDataGridViewTextBoxColumn,
            this.cDProdutoDataGridViewTextBoxColumn,
            this.dSProdutoDataGridViewTextBoxColumn});
            this.g_CadLocalArm_X_Produto.DataSource = this.BS_CadLocalArm_X_Produto;
            resources.ApplyResources(this.g_CadLocalArm_X_Produto, "g_CadLocalArm_X_Produto");
            this.g_CadLocalArm_X_Produto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_CadLocalArm_X_Produto.Name = "g_CadLocalArm_X_Produto";
            this.g_CadLocalArm_X_Produto.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadLocalArm_X_Produto.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.g_CadLocalArm_X_Produto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_CadLocalArm_X_Produto.TabStop = false;
            // 
            // cDLocalDataGridViewTextBoxColumn
            // 
            this.cDLocalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDLocalDataGridViewTextBoxColumn.DataPropertyName = "CD_Local";
            resources.ApplyResources(this.cDLocalDataGridViewTextBoxColumn, "cDLocalDataGridViewTextBoxColumn");
            this.cDLocalDataGridViewTextBoxColumn.Name = "cDLocalDataGridViewTextBoxColumn";
            this.cDLocalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSLocalDataGridViewTextBoxColumn
            // 
            this.dSLocalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSLocalDataGridViewTextBoxColumn.DataPropertyName = "DS_Local";
            resources.ApplyResources(this.dSLocalDataGridViewTextBoxColumn, "dSLocalDataGridViewTextBoxColumn");
            this.dSLocalDataGridViewTextBoxColumn.Name = "dSLocalDataGridViewTextBoxColumn";
            this.dSLocalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cDProdutoDataGridViewTextBoxColumn
            // 
            this.cDProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDProdutoDataGridViewTextBoxColumn.DataPropertyName = "CD_Produto";
            resources.ApplyResources(this.cDProdutoDataGridViewTextBoxColumn, "cDProdutoDataGridViewTextBoxColumn");
            this.cDProdutoDataGridViewTextBoxColumn.Name = "cDProdutoDataGridViewTextBoxColumn";
            this.cDProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSProdutoDataGridViewTextBoxColumn
            // 
            this.dSProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSProdutoDataGridViewTextBoxColumn.DataPropertyName = "DS_Produto";
            resources.ApplyResources(this.dSProdutoDataGridViewTextBoxColumn, "dSProdutoDataGridViewTextBoxColumn");
            this.dSProdutoDataGridViewTextBoxColumn.Name = "dSProdutoDataGridViewTextBoxColumn";
            this.dSProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BS_CadLocalArm_X_Produto
            // 
            this.BS_CadLocalArm_X_Produto.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto);
            // 
            // BN_CadLocalArm_X_Produto
            // 
            this.BN_CadLocalArm_X_Produto.AddNewItem = null;
            this.BN_CadLocalArm_X_Produto.BindingSource = this.BS_CadLocalArm_X_Produto;
            this.BN_CadLocalArm_X_Produto.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadLocalArm_X_Produto.CountItemFormat = "de {0}";
            this.BN_CadLocalArm_X_Produto.DeleteItem = null;
            resources.ApplyResources(this.BN_CadLocalArm_X_Produto, "BN_CadLocalArm_X_Produto");
            this.BN_CadLocalArm_X_Produto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadLocalArm_X_Produto.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadLocalArm_X_Produto.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadLocalArm_X_Produto.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadLocalArm_X_Produto.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadLocalArm_X_Produto.Name = "BN_CadLocalArm_X_Produto";
            this.BN_CadLocalArm_X_Produto.PositionItem = this.bindingNavigatorPositionItem;
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
            // CD_Local
            // 
            this.CD_Local.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadLocalArm_X_Produto, "CD_Local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Local, "CD_Local");
            this.CD_Local.Name = "CD_Local";
            this.CD_Local.NM_Alias = "";
            this.CD_Local.NM_Campo = "CD_Local";
            this.CD_Local.NM_CampoBusca = "CD_Local";
            this.CD_Local.NM_Param = "@P_CD_LOCAL";
            this.CD_Local.QTD_Zero = 0;
            this.CD_Local.ST_AutoInc = false;
            this.CD_Local.ST_DisableAuto = false;
            this.CD_Local.ST_Float = false;
            this.CD_Local.ST_Gravar = true;
            this.CD_Local.ST_Int = false;
            this.CD_Local.ST_LimpaCampo = true;
            this.CD_Local.ST_NotNull = true;
            this.CD_Local.ST_PrimaryKey = true;
            this.CD_Local.TextOld = null;
            this.CD_Local.Leave += new System.EventHandler(this.CD_Local_Leave);
            this.CD_Local.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CD_Local_KeyPress);
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadLocalArm_X_Produto, "CD_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Produto, "CD_Produto");
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = true;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.Leave += new System.EventHandler(this.CD_PRODUTO_Leave);
            this.CD_Produto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CD_Produto_KeyPress);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BB_Local
            // 
            resources.ApplyResources(this.BB_Local, "BB_Local");
            this.BB_Local.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Local.Name = "BB_Local";
            this.BB_Local.UseVisualStyleBackColor = true;
            this.BB_Local.Click += new System.EventHandler(this.BB_Local_Click);
            // 
            // BB_Produto
            // 
            resources.ApplyResources(this.BB_Produto, "BB_Produto");
            this.BB_Produto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Produto.Name = "BB_Produto";
            this.BB_Produto.UseVisualStyleBackColor = true;
            this.BB_Produto.Click += new System.EventHandler(this.BB_Produto_Click);
            // 
            // DS_Local
            // 
            this.DS_Local.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadLocalArm_X_Produto, "DS_Local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Local, "DS_Local");
            this.DS_Local.Name = "DS_Local";
            this.DS_Local.NM_Alias = "";
            this.DS_Local.NM_Campo = "DS_Local";
            this.DS_Local.NM_CampoBusca = "DS_Local";
            this.DS_Local.NM_Param = "@P_DS_LOCAL";
            this.DS_Local.QTD_Zero = 0;
            this.DS_Local.ST_AutoInc = false;
            this.DS_Local.ST_DisableAuto = true;
            this.DS_Local.ST_Float = false;
            this.DS_Local.ST_Gravar = false;
            this.DS_Local.ST_Int = false;
            this.DS_Local.ST_LimpaCampo = true;
            this.DS_Local.ST_NotNull = false;
            this.DS_Local.ST_PrimaryKey = false;
            this.DS_Local.TextOld = null;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadLocalArm_X_Produto, "DS_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Produto, "DS_Produto");
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = true;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TextOld = null;
            // 
            // TFCad_LocalArm_X_Produto
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCad_LocalArm_X_Produto";
            this.Load += new System.EventHandler(this.TFCad_LocalArm_X_Produto_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_LocalArm_X_Produto_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadLocalArm_X_Produto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadLocalArm_X_Produto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadLocalArm_X_Produto)).EndInit();
            this.BN_CadLocalArm_X_Produto.ResumeLayout(false);
            this.BN_CadLocalArm_X_Produto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault g_CadLocalArm_X_Produto;
        private System.Windows.Forms.BindingNavigator BN_CadLocalArm_X_Produto;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource BS_CadLocalArm_X_Produto;
        private Componentes.EditDefault CD_Local;
        private Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button BB_Local;
        public System.Windows.Forms.Button BB_Produto;
        private Componentes.EditDefault DS_Local;
        private Componentes.EditDefault DS_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDLocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSLocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSProdutoDataGridViewTextBoxColumn;
    }
}