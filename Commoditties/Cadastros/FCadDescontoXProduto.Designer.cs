namespace Commoditties.Cadastros
{
    partial class TFCadDescontoXProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadDescontoXProduto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.g_CadDesconto_X_Produto = new Componentes.DataGridDefault(this.components);
            this.BS_CadDescontoxProduto = new System.Windows.Forms.BindingSource(this.components);
            this.LB_CD_TabelaDesconto = new System.Windows.Forms.Label();
            this.LB_CD_Produto = new System.Windows.Forms.Label();
            this.CD_TabelaDesconto = new Componentes.EditDefault(this.components);
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.ds_tabelaDesconto = new Componentes.EditDefault(this.components);
            this.bb_TabelaDesconto = new System.Windows.Forms.Button();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bb_Produto = new System.Windows.Forms.Button();
            this.BN_CadDescontoxProduto = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cdTabelaDescontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fds_TabelaDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fds_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadDesconto_X_Produto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadDescontoxProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadDescontoxProduto)).BeginInit();
            this.BN_CadDescontoxProduto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_Produto);
            this.pDados.Controls.Add(this.ds_tabelaDesconto);
            this.pDados.Controls.Add(this.bb_TabelaDesconto);
            this.pDados.Controls.Add(this.LB_CD_TabelaDesconto);
            this.pDados.Controls.Add(this.LB_CD_Produto);
            this.pDados.Controls.Add(this.CD_TabelaDesconto);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.NM_ProcDeletar = "EXCLUI_GRO_DESCONTOXPRODUTO";
            this.pDados.NM_ProcGravar = "IA_GRO_DESCONTOXPRODUTO";
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
            this.tpPadrao.Controls.Add(this.g_CadDesconto_X_Produto);
            this.tpPadrao.Controls.Add(this.BN_CadDescontoxProduto);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadDescontoxProduto, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_CadDesconto_X_Produto, 0);
            // 
            // g_CadDesconto_X_Produto
            // 
            this.g_CadDesconto_X_Produto.AccessibleDescription = null;
            this.g_CadDesconto_X_Produto.AccessibleName = null;
            this.g_CadDesconto_X_Produto.AllowUserToAddRows = false;
            this.g_CadDesconto_X_Produto.AllowUserToDeleteRows = false;
            this.g_CadDesconto_X_Produto.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.g_CadDesconto_X_Produto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.g_CadDesconto_X_Produto, "g_CadDesconto_X_Produto");
            this.g_CadDesconto_X_Produto.AutoGenerateColumns = false;
            this.g_CadDesconto_X_Produto.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_CadDesconto_X_Produto.BackgroundImage = null;
            this.g_CadDesconto_X_Produto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_CadDesconto_X_Produto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadDesconto_X_Produto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_CadDesconto_X_Produto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_CadDesconto_X_Produto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdTabelaDescontoDataGridViewTextBoxColumn,
            this.fds_TabelaDesconto,
            this.cdProdutoDataGridViewTextBoxColumn,
            this.Fds_produto});
            this.g_CadDesconto_X_Produto.DataSource = this.BS_CadDescontoxProduto;
            this.g_CadDesconto_X_Produto.Font = null;
            this.g_CadDesconto_X_Produto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_CadDesconto_X_Produto.Name = "g_CadDesconto_X_Produto";
            this.g_CadDesconto_X_Produto.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadDesconto_X_Produto.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_CadDesconto_X_Produto.TabStop = false;
            // 
            // BS_CadDescontoxProduto
            // 
            this.BS_CadDescontoxProduto.DataSource = typeof(CamadaDados.Graos.TList_CadDescontoxProduto);
            // 
            // LB_CD_TabelaDesconto
            // 
            this.LB_CD_TabelaDesconto.AccessibleDescription = null;
            this.LB_CD_TabelaDesconto.AccessibleName = null;
            resources.ApplyResources(this.LB_CD_TabelaDesconto, "LB_CD_TabelaDesconto");
            this.LB_CD_TabelaDesconto.Font = null;
            this.LB_CD_TabelaDesconto.Name = "LB_CD_TabelaDesconto";
            // 
            // LB_CD_Produto
            // 
            this.LB_CD_Produto.AccessibleDescription = null;
            this.LB_CD_Produto.AccessibleName = null;
            resources.ApplyResources(this.LB_CD_Produto, "LB_CD_Produto");
            this.LB_CD_Produto.Font = null;
            this.LB_CD_Produto.Name = "LB_CD_Produto";
            // 
            // CD_TabelaDesconto
            // 
            this.CD_TabelaDesconto.AccessibleDescription = null;
            this.CD_TabelaDesconto.AccessibleName = null;
            resources.ApplyResources(this.CD_TabelaDesconto, "CD_TabelaDesconto");
            this.CD_TabelaDesconto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_TabelaDesconto.BackgroundImage = null;
            this.CD_TabelaDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_TabelaDesconto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadDescontoxProduto, "Cd_TabelaDesconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_TabelaDesconto.Name = "CD_TabelaDesconto";
            this.CD_TabelaDesconto.NM_Alias = "a";
            this.CD_TabelaDesconto.NM_Campo = "CD_TabelaDesconto";
            this.CD_TabelaDesconto.NM_CampoBusca = "CD_TabelaDesconto";
            this.CD_TabelaDesconto.NM_Param = "@P_CD_TABELADESCONTO";
            this.CD_TabelaDesconto.QTD_Zero = 0;
            this.CD_TabelaDesconto.ST_AutoInc = false;
            this.CD_TabelaDesconto.ST_DisableAuto = false;
            this.CD_TabelaDesconto.ST_Float = false;
            this.CD_TabelaDesconto.ST_Gravar = true;
            this.CD_TabelaDesconto.ST_Int = true;
            this.CD_TabelaDesconto.ST_LimpaCampo = true;
            this.CD_TabelaDesconto.ST_NotNull = true;
            this.CD_TabelaDesconto.ST_PrimaryKey = true;
            this.CD_TabelaDesconto.Leave += new System.EventHandler(this.CD_TabelaDesconto_Leave);
            // 
            // CD_Produto
            // 
            this.CD_Produto.AccessibleDescription = null;
            this.CD_Produto.AccessibleName = null;
            resources.ApplyResources(this.CD_Produto, "CD_Produto");
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BackgroundImage = null;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadDescontoxProduto, "Cd_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.CD_Produto.ST_Int = true;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = true;
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // ds_tabelaDesconto
            // 
            this.ds_tabelaDesconto.AccessibleDescription = null;
            this.ds_tabelaDesconto.AccessibleName = null;
            resources.ApplyResources(this.ds_tabelaDesconto, "ds_tabelaDesconto");
            this.ds_tabelaDesconto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelaDesconto.BackgroundImage = null;
            this.ds_tabelaDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelaDesconto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadDescontoxProduto, "Ds_tabeladesconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tabelaDesconto.Name = "ds_tabelaDesconto";
            this.ds_tabelaDesconto.NM_Alias = "";
            this.ds_tabelaDesconto.NM_Campo = "ds_tabelaDesconto";
            this.ds_tabelaDesconto.NM_CampoBusca = "ds_tabelaDesconto";
            this.ds_tabelaDesconto.NM_Param = "";
            this.ds_tabelaDesconto.QTD_Zero = 0;
            this.ds_tabelaDesconto.ReadOnly = true;
            this.ds_tabelaDesconto.ST_AutoInc = false;
            this.ds_tabelaDesconto.ST_DisableAuto = false;
            this.ds_tabelaDesconto.ST_Float = false;
            this.ds_tabelaDesconto.ST_Gravar = false;
            this.ds_tabelaDesconto.ST_Int = false;
            this.ds_tabelaDesconto.ST_LimpaCampo = true;
            this.ds_tabelaDesconto.ST_NotNull = false;
            this.ds_tabelaDesconto.ST_PrimaryKey = false;
            // 
            // bb_TabelaDesconto
            // 
            this.bb_TabelaDesconto.AccessibleDescription = null;
            this.bb_TabelaDesconto.AccessibleName = null;
            resources.ApplyResources(this.bb_TabelaDesconto, "bb_TabelaDesconto");
            this.bb_TabelaDesconto.BackgroundImage = null;
            this.bb_TabelaDesconto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_TabelaDesconto.Font = null;
            this.bb_TabelaDesconto.Name = "bb_TabelaDesconto";
            this.bb_TabelaDesconto.UseVisualStyleBackColor = true;
            this.bb_TabelaDesconto.Click += new System.EventHandler(this.bb_TabelaDesconto_Click);
            // 
            // ds_produto
            // 
            this.ds_produto.AccessibleDescription = null;
            this.ds_produto.AccessibleName = null;
            resources.ApplyResources(this.ds_produto, "ds_produto");
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BackgroundImage = null;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadDescontoxProduto, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_PRODUTO";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.ReadOnly = true;
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            // 
            // bb_Produto
            // 
            this.bb_Produto.AccessibleDescription = null;
            this.bb_Produto.AccessibleName = null;
            resources.ApplyResources(this.bb_Produto, "bb_Produto");
            this.bb_Produto.BackgroundImage = null;
            this.bb_Produto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_Produto.Font = null;
            this.bb_Produto.Name = "bb_Produto";
            this.bb_Produto.UseVisualStyleBackColor = true;
            this.bb_Produto.Click += new System.EventHandler(this.bb_Produto_Click);
            // 
            // BN_CadDescontoxProduto
            // 
            this.BN_CadDescontoxProduto.AccessibleDescription = null;
            this.BN_CadDescontoxProduto.AccessibleName = null;
            this.BN_CadDescontoxProduto.AddNewItem = null;
            resources.ApplyResources(this.BN_CadDescontoxProduto, "BN_CadDescontoxProduto");
            this.BN_CadDescontoxProduto.BackgroundImage = null;
            this.BN_CadDescontoxProduto.BindingSource = this.BS_CadDescontoxProduto;
            this.BN_CadDescontoxProduto.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadDescontoxProduto.DeleteItem = null;
            this.BN_CadDescontoxProduto.Font = null;
            this.BN_CadDescontoxProduto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadDescontoxProduto.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadDescontoxProduto.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadDescontoxProduto.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadDescontoxProduto.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadDescontoxProduto.Name = "BN_CadDescontoxProduto";
            this.BN_CadDescontoxProduto.PositionItem = this.bindingNavigatorPositionItem;
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
            // cdTabelaDescontoDataGridViewTextBoxColumn
            // 
            this.cdTabelaDescontoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdTabelaDescontoDataGridViewTextBoxColumn.DataPropertyName = "Cd_TabelaDesconto";
            resources.ApplyResources(this.cdTabelaDescontoDataGridViewTextBoxColumn, "cdTabelaDescontoDataGridViewTextBoxColumn");
            this.cdTabelaDescontoDataGridViewTextBoxColumn.Name = "cdTabelaDescontoDataGridViewTextBoxColumn";
            this.cdTabelaDescontoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fds_TabelaDesconto
            // 
            this.fds_TabelaDesconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fds_TabelaDesconto.DataPropertyName = "Ds_tabeladesconto";
            resources.ApplyResources(this.fds_TabelaDesconto, "fds_TabelaDesconto");
            this.fds_TabelaDesconto.Name = "fds_TabelaDesconto";
            this.fds_TabelaDesconto.ReadOnly = true;
            // 
            // cdProdutoDataGridViewTextBoxColumn
            // 
            this.cdProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdProdutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_Produto";
            resources.ApplyResources(this.cdProdutoDataGridViewTextBoxColumn, "cdProdutoDataGridViewTextBoxColumn");
            this.cdProdutoDataGridViewTextBoxColumn.Name = "cdProdutoDataGridViewTextBoxColumn";
            this.cdProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Fds_produto
            // 
            this.Fds_produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Fds_produto.DataPropertyName = "Ds_produto";
            resources.ApplyResources(this.Fds_produto, "Fds_produto");
            this.Fds_produto.Name = "Fds_produto";
            this.Fds_produto.ReadOnly = true;
            // 
            // TFCadDescontoXProduto
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadDescontoXProduto";
            this.Load += new System.EventHandler(this.TFCadDescontoXProduto_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadDesconto_X_Produto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadDescontoxProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadDescontoxProduto)).EndInit();
            this.BN_CadDescontoxProduto.ResumeLayout(false);
            this.BN_CadDescontoxProduto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault g_CadDesconto_X_Produto;
        private System.Windows.Forms.Label LB_CD_TabelaDesconto;
        private System.Windows.Forms.Label LB_CD_Produto;



        private Componentes.EditDefault CD_TabelaDesconto;
        private Componentes.EditDefault CD_Produto;
        private Componentes.EditDefault ds_produto;
        public System.Windows.Forms.Button bb_Produto;
        private Componentes.EditDefault ds_tabelaDesconto;
        public System.Windows.Forms.Button bb_TabelaDesconto;
        private System.Windows.Forms.BindingSource BS_CadDescontoxProduto;
        private System.Windows.Forms.BindingNavigator BN_CadDescontoxProduto;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdTabelaDescontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fds_TabelaDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fds_produto;


    }
}
