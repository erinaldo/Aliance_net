namespace Fiscal.Cadastros
{
    partial class TFCadCondFiscalProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCondFiscalProduto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ds_condfiscal_produto = new Componentes.EditDefault(this.components);
            this.bs_CondFiscalProduto = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_condfiscal_produto = new Componentes.EditDefault(this.components);
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.BN_CondFiscalProduto = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cDCONDFISCALPRODUTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSCONDFISCALPRODUTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_CondFiscalProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CondFiscalProduto)).BeginInit();
            this.BN_CondFiscalProduto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.ds_condfiscal_produto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_condfiscal_produto);
            this.pDados.Font = null;
            this.pDados.NM_ProcDeletar = "EXCLUI_FIS_CONDFISCAL_PRODUTO";
            this.pDados.NM_ProcGravar = "IA_FIS_CONDFISCAL_PRODUTO";
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
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // ds_condfiscal_produto
            // 
            this.ds_condfiscal_produto.AccessibleDescription = null;
            this.ds_condfiscal_produto.AccessibleName = null;
            resources.ApplyResources(this.ds_condfiscal_produto, "ds_condfiscal_produto");
            this.ds_condfiscal_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_condfiscal_produto.BackgroundImage = null;
            this.ds_condfiscal_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condfiscal_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CondFiscalProduto, "DS_CONDFISCAL_PRODUTO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_condfiscal_produto.Font = null;
            this.ds_condfiscal_produto.Name = "ds_condfiscal_produto";
            this.ds_condfiscal_produto.NM_Alias = "";
            this.ds_condfiscal_produto.NM_Campo = "ds_condfiscal_produto";
            this.ds_condfiscal_produto.NM_CampoBusca = "ds_condfiscal_produto";
            this.ds_condfiscal_produto.NM_Param = "@P_DS_CONDFISCAL_PRODUTO";
            this.ds_condfiscal_produto.QTD_Zero = 0;
            this.ds_condfiscal_produto.ST_AutoInc = false;
            this.ds_condfiscal_produto.ST_DisableAuto = false;
            this.ds_condfiscal_produto.ST_Float = false;
            this.ds_condfiscal_produto.ST_Gravar = true;
            this.ds_condfiscal_produto.ST_Int = false;
            this.ds_condfiscal_produto.ST_LimpaCampo = true;
            this.ds_condfiscal_produto.ST_NotNull = true;
            this.ds_condfiscal_produto.ST_PrimaryKey = false;
            // 
            // bs_CondFiscalProduto
            // 
            this.bs_CondFiscalProduto.DataSource = typeof(CamadaDados.Fiscal.TList_CadCondFiscalProduto);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cd_condfiscal_produto
            // 
            this.cd_condfiscal_produto.AccessibleDescription = null;
            this.cd_condfiscal_produto.AccessibleName = null;
            resources.ApplyResources(this.cd_condfiscal_produto, "cd_condfiscal_produto");
            this.cd_condfiscal_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_condfiscal_produto.BackgroundImage = null;
            this.cd_condfiscal_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_condfiscal_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CondFiscalProduto, "CD_CONDFISCAL_PRODUTO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_condfiscal_produto.Font = null;
            this.cd_condfiscal_produto.Name = "cd_condfiscal_produto";
            this.cd_condfiscal_produto.NM_Alias = "";
            this.cd_condfiscal_produto.NM_Campo = "cd_condfiscal_produto";
            this.cd_condfiscal_produto.NM_CampoBusca = "cd_condfiscal_produto";
            this.cd_condfiscal_produto.NM_Param = "@P_CD_CONDFISCAL_PRODUTO";
            this.cd_condfiscal_produto.QTD_Zero = 0;
            this.cd_condfiscal_produto.ST_AutoInc = false;
            this.cd_condfiscal_produto.ST_DisableAuto = true;
            this.cd_condfiscal_produto.ST_Float = false;
            this.cd_condfiscal_produto.ST_Gravar = true;
            this.cd_condfiscal_produto.ST_Int = true;
            this.cd_condfiscal_produto.ST_LimpaCampo = true;
            this.cd_condfiscal_produto.ST_NotNull = true;
            this.cd_condfiscal_produto.ST_PrimaryKey = true;
            // 
            // gCadastro
            // 
            this.gCadastro.AccessibleDescription = null;
            this.gCadastro.AccessibleName = null;
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BackgroundImage = null;
            this.gCadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDCONDFISCALPRODUTODataGridViewTextBoxColumn,
            this.dSCONDFISCALPRODUTODataGridViewTextBoxColumn});
            this.gCadastro.DataSource = this.bs_CondFiscalProduto;
            this.gCadastro.Font = null;
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gCadastro.TabStop = false;
            // 
            // BN_CondFiscalProduto
            // 
            this.BN_CondFiscalProduto.AccessibleDescription = null;
            this.BN_CondFiscalProduto.AccessibleName = null;
            this.BN_CondFiscalProduto.AddNewItem = null;
            resources.ApplyResources(this.BN_CondFiscalProduto, "BN_CondFiscalProduto");
            this.BN_CondFiscalProduto.BackgroundImage = null;
            this.BN_CondFiscalProduto.CountItem = this.bindingNavigatorCountItem;
            this.BN_CondFiscalProduto.DeleteItem = null;
            this.BN_CondFiscalProduto.Font = null;
            this.BN_CondFiscalProduto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CondFiscalProduto.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CondFiscalProduto.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CondFiscalProduto.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CondFiscalProduto.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CondFiscalProduto.Name = "BN_CondFiscalProduto";
            this.BN_CondFiscalProduto.PositionItem = this.bindingNavigatorPositionItem;
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
            // cDCONDFISCALPRODUTODataGridViewTextBoxColumn
            // 
            this.cDCONDFISCALPRODUTODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDCONDFISCALPRODUTODataGridViewTextBoxColumn.DataPropertyName = "CD_CONDFISCAL_PRODUTO";
            resources.ApplyResources(this.cDCONDFISCALPRODUTODataGridViewTextBoxColumn, "cDCONDFISCALPRODUTODataGridViewTextBoxColumn");
            this.cDCONDFISCALPRODUTODataGridViewTextBoxColumn.Name = "cDCONDFISCALPRODUTODataGridViewTextBoxColumn";
            this.cDCONDFISCALPRODUTODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSCONDFISCALPRODUTODataGridViewTextBoxColumn
            // 
            this.dSCONDFISCALPRODUTODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSCONDFISCALPRODUTODataGridViewTextBoxColumn.DataPropertyName = "DS_CONDFISCAL_PRODUTO";
            resources.ApplyResources(this.dSCONDFISCALPRODUTODataGridViewTextBoxColumn, "dSCONDFISCALPRODUTODataGridViewTextBoxColumn");
            this.dSCONDFISCALPRODUTODataGridViewTextBoxColumn.Name = "dSCONDFISCALPRODUTODataGridViewTextBoxColumn";
            this.dSCONDFISCALPRODUTODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCadCondFiscalProduto
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.BN_CondFiscalProduto);
            this.Font = null;
            this.Name = "TFCadCondFiscalProduto";
            this.Load += new System.EventHandler(this.TFCadCondFiscalProduto_Load);
            this.Controls.SetChildIndex(this.BN_CondFiscalProduto, 0);
            this.Controls.SetChildIndex(this.tcCentral, 0);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bs_CondFiscalProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CondFiscalProduto)).EndInit();
            this.BN_CondFiscalProduto.ResumeLayout(false);
            this.BN_CondFiscalProduto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault ds_condfiscal_produto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_condfiscal_produto;
        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.BindingSource bs_CondFiscalProduto;
        private System.Windows.Forms.BindingNavigator BN_CondFiscalProduto;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDCONDFISCALPRODUTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSCONDFISCALPRODUTODataGridViewTextBoxColumn;
    }
}
