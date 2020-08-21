namespace Estoque.Cadastros
{
    partial class TFCad_TpProduto_X_Clifor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_TpProduto_X_Clifor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.BS_CadTpProduto_X_Clifor = new System.Windows.Forms.BindingSource(this.components);
            this.DS_TPProduto = new Componentes.EditDefault(this.components);
            this.BB_Clifor = new System.Windows.Forms.Button();
            this.BB_TPProduto = new System.Windows.Forms.Button();
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.TP_Produto = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.G_TpProduto_X_Clifor = new Componentes.DataGridDefault(this.components);
            this.cDCliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMCliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSTpProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BN_CadTpProduto_X_Clifor = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadTpProduto_X_Clifor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_TpProduto_X_Clifor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadTpProduto_X_Clifor)).BeginInit();
            this.BN_CadTpProduto_X_Clifor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.NM_Clifor);
            this.pDados.Controls.Add(this.CD_Clifor);
            this.pDados.Controls.Add(this.DS_TPProduto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.BB_Clifor);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.BB_TPProduto);
            this.pDados.Controls.Add(this.TP_Produto);
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
            this.tpPadrao.Controls.Add(this.BN_CadTpProduto_X_Clifor);
            this.tpPadrao.Controls.Add(this.G_TpProduto_X_Clifor);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.G_TpProduto_X_Clifor, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadTpProduto_X_Clifor, 0);
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.AccessibleDescription = null;
            this.NM_Clifor.AccessibleName = null;
            resources.ApplyResources(this.NM_Clifor, "NM_Clifor");
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.BackgroundImage = null;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadTpProduto_X_Clifor, "NM_Clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "NM_Clifor";
            this.NM_Clifor.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = true;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = false;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            // 
            // BS_CadTpProduto_X_Clifor
            // 
            this.BS_CadTpProduto_X_Clifor.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadTpProduto_X_Clifor);
            // 
            // DS_TPProduto
            // 
            this.DS_TPProduto.AccessibleDescription = null;
            this.DS_TPProduto.AccessibleName = null;
            resources.ApplyResources(this.DS_TPProduto, "DS_TPProduto");
            this.DS_TPProduto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TPProduto.BackgroundImage = null;
            this.DS_TPProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TPProduto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadTpProduto_X_Clifor, "DS_TpProduto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_TPProduto.Name = "DS_TPProduto";
            this.DS_TPProduto.NM_Alias = "";
            this.DS_TPProduto.NM_Campo = "DS_TPProduto";
            this.DS_TPProduto.NM_CampoBusca = "DS_TPProduto";
            this.DS_TPProduto.NM_Param = "@P_DS_TPPRODUTO";
            this.DS_TPProduto.QTD_Zero = 0;
            this.DS_TPProduto.ST_AutoInc = false;
            this.DS_TPProduto.ST_DisableAuto = true;
            this.DS_TPProduto.ST_Float = false;
            this.DS_TPProduto.ST_Gravar = false;
            this.DS_TPProduto.ST_Int = false;
            this.DS_TPProduto.ST_LimpaCampo = true;
            this.DS_TPProduto.ST_NotNull = false;
            this.DS_TPProduto.ST_PrimaryKey = false;
            // 
            // BB_Clifor
            // 
            this.BB_Clifor.AccessibleDescription = null;
            this.BB_Clifor.AccessibleName = null;
            resources.ApplyResources(this.BB_Clifor, "BB_Clifor");
            this.BB_Clifor.BackgroundImage = null;
            this.BB_Clifor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Clifor.Font = null;
            this.BB_Clifor.Name = "BB_Clifor";
            this.BB_Clifor.UseVisualStyleBackColor = true;
            this.BB_Clifor.Click += new System.EventHandler(this.BB_Clifor_Click);
            // 
            // BB_TPProduto
            // 
            this.BB_TPProduto.AccessibleDescription = null;
            this.BB_TPProduto.AccessibleName = null;
            resources.ApplyResources(this.BB_TPProduto, "BB_TPProduto");
            this.BB_TPProduto.BackgroundImage = null;
            this.BB_TPProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_TPProduto.Font = null;
            this.BB_TPProduto.Name = "BB_TPProduto";
            this.BB_TPProduto.UseVisualStyleBackColor = true;
            this.BB_TPProduto.Click += new System.EventHandler(this.BB_TPProduto_Click);
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.AccessibleDescription = null;
            this.CD_Clifor.AccessibleName = null;
            resources.ApplyResources(this.CD_Clifor, "CD_Clifor");
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.BackgroundImage = null;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadTpProduto_X_Clifor, "CD_Clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Clifor.Font = null;
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = true;
            this.CD_Clifor.ST_Int = false;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = true;
            this.CD_Clifor.ST_PrimaryKey = true;
            this.CD_Clifor.Leave += new System.EventHandler(this.CD_Clifor_Leave);
            this.CD_Clifor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CD_Clifor_KeyPress);
            // 
            // TP_Produto
            // 
            this.TP_Produto.AccessibleDescription = null;
            this.TP_Produto.AccessibleName = null;
            resources.ApplyResources(this.TP_Produto, "TP_Produto");
            this.TP_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Produto.BackgroundImage = null;
            this.TP_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadTpProduto_X_Clifor, "Tp_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Produto.Font = null;
            this.TP_Produto.Name = "TP_Produto";
            this.TP_Produto.NM_Alias = "";
            this.TP_Produto.NM_Campo = "TP_Produto";
            this.TP_Produto.NM_CampoBusca = "TP_Produto";
            this.TP_Produto.NM_Param = "@P_TP_PRODUTO";
            this.TP_Produto.QTD_Zero = 0;
            this.TP_Produto.ST_AutoInc = false;
            this.TP_Produto.ST_DisableAuto = false;
            this.TP_Produto.ST_Float = false;
            this.TP_Produto.ST_Gravar = true;
            this.TP_Produto.ST_Int = false;
            this.TP_Produto.ST_LimpaCampo = true;
            this.TP_Produto.ST_NotNull = true;
            this.TP_Produto.ST_PrimaryKey = true;
            this.TP_Produto.Leave += new System.EventHandler(this.TP_Produto_Leave);
            this.TP_Produto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TP_Produto_KeyPress);
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
            // G_TpProduto_X_Clifor
            // 
            this.G_TpProduto_X_Clifor.AccessibleDescription = null;
            this.G_TpProduto_X_Clifor.AccessibleName = null;
            this.G_TpProduto_X_Clifor.AllowUserToAddRows = false;
            this.G_TpProduto_X_Clifor.AllowUserToDeleteRows = false;
            this.G_TpProduto_X_Clifor.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.G_TpProduto_X_Clifor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.G_TpProduto_X_Clifor, "G_TpProduto_X_Clifor");
            this.G_TpProduto_X_Clifor.AutoGenerateColumns = false;
            this.G_TpProduto_X_Clifor.BackgroundColor = System.Drawing.Color.LightGray;
            this.G_TpProduto_X_Clifor.BackgroundImage = null;
            this.G_TpProduto_X_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.G_TpProduto_X_Clifor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.G_TpProduto_X_Clifor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.G_TpProduto_X_Clifor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.G_TpProduto_X_Clifor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDCliforDataGridViewTextBoxColumn,
            this.nMCliforDataGridViewTextBoxColumn,
            this.tpProdutoDataGridViewTextBoxColumn,
            this.dSTpProdutoDataGridViewTextBoxColumn});
            this.G_TpProduto_X_Clifor.DataSource = this.BS_CadTpProduto_X_Clifor;
            this.G_TpProduto_X_Clifor.Font = null;
            this.G_TpProduto_X_Clifor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.G_TpProduto_X_Clifor.Name = "G_TpProduto_X_Clifor";
            this.G_TpProduto_X_Clifor.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.G_TpProduto_X_Clifor.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.G_TpProduto_X_Clifor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // cDCliforDataGridViewTextBoxColumn
            // 
            this.cDCliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDCliforDataGridViewTextBoxColumn.DataPropertyName = "CD_Clifor";
            resources.ApplyResources(this.cDCliforDataGridViewTextBoxColumn, "cDCliforDataGridViewTextBoxColumn");
            this.cDCliforDataGridViewTextBoxColumn.Name = "cDCliforDataGridViewTextBoxColumn";
            this.cDCliforDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nMCliforDataGridViewTextBoxColumn
            // 
            this.nMCliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMCliforDataGridViewTextBoxColumn.DataPropertyName = "NM_Clifor";
            resources.ApplyResources(this.nMCliforDataGridViewTextBoxColumn, "nMCliforDataGridViewTextBoxColumn");
            this.nMCliforDataGridViewTextBoxColumn.Name = "nMCliforDataGridViewTextBoxColumn";
            this.nMCliforDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpProdutoDataGridViewTextBoxColumn
            // 
            this.tpProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpProdutoDataGridViewTextBoxColumn.DataPropertyName = "Tp_Produto";
            resources.ApplyResources(this.tpProdutoDataGridViewTextBoxColumn, "tpProdutoDataGridViewTextBoxColumn");
            this.tpProdutoDataGridViewTextBoxColumn.Name = "tpProdutoDataGridViewTextBoxColumn";
            this.tpProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSTpProdutoDataGridViewTextBoxColumn
            // 
            this.dSTpProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSTpProdutoDataGridViewTextBoxColumn.DataPropertyName = "DS_TpProduto";
            resources.ApplyResources(this.dSTpProdutoDataGridViewTextBoxColumn, "dSTpProdutoDataGridViewTextBoxColumn");
            this.dSTpProdutoDataGridViewTextBoxColumn.Name = "dSTpProdutoDataGridViewTextBoxColumn";
            this.dSTpProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BN_CadTpProduto_X_Clifor
            // 
            this.BN_CadTpProduto_X_Clifor.AccessibleDescription = null;
            this.BN_CadTpProduto_X_Clifor.AccessibleName = null;
            this.BN_CadTpProduto_X_Clifor.AddNewItem = null;
            resources.ApplyResources(this.BN_CadTpProduto_X_Clifor, "BN_CadTpProduto_X_Clifor");
            this.BN_CadTpProduto_X_Clifor.BackgroundImage = null;
            this.BN_CadTpProduto_X_Clifor.BindingSource = this.BS_CadTpProduto_X_Clifor;
            this.BN_CadTpProduto_X_Clifor.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadTpProduto_X_Clifor.DeleteItem = null;
            this.BN_CadTpProduto_X_Clifor.Font = null;
            this.BN_CadTpProduto_X_Clifor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadTpProduto_X_Clifor.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadTpProduto_X_Clifor.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadTpProduto_X_Clifor.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadTpProduto_X_Clifor.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadTpProduto_X_Clifor.Name = "BN_CadTpProduto_X_Clifor";
            this.BN_CadTpProduto_X_Clifor.PositionItem = this.bindingNavigatorPositionItem;
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
            // TFCad_TpProduto_X_Clifor
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCad_TpProduto_X_Clifor";
            this.Load += new System.EventHandler(this.TFCad_TpProduto_X_Clifor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_TpProduto_X_Clifor_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadTpProduto_X_Clifor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_TpProduto_X_Clifor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadTpProduto_X_Clifor)).EndInit();
            this.BN_CadTpProduto_X_Clifor.ResumeLayout(false);
            this.BN_CadTpProduto_X_Clifor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault NM_Clifor;
        private Componentes.EditDefault CD_Clifor;
        private Componentes.EditDefault DS_TPProduto;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button BB_Clifor;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button BB_TPProduto;
        private Componentes.EditDefault TP_Produto;
        private System.Windows.Forms.BindingSource BS_CadTpProduto_X_Clifor;
        private Componentes.DataGridDefault G_TpProduto_X_Clifor;
        private System.Windows.Forms.BindingNavigator BN_CadTpProduto_X_Clifor;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDCliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMCliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSTpProdutoDataGridViewTextBoxColumn;
    }
}
