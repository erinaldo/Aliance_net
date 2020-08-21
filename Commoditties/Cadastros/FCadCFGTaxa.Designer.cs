namespace Commoditties.Cadastros
{
    partial class TFCadCFGTaxa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCFGTaxa));
            this.gCfgTaxa = new Componentes.DataGridDefault(this.components);
            this.tipotaxaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfgpedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstipopedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sigla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCfgTaxa = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.tp_taxa = new Componentes.ComboBoxDefault(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.DS_TipoPedido = new Componentes.EditDefault(this.components);
            this.BB_CFG_Pedido = new System.Windows.Forms.Button();
            this.CFG_Pedido = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_moeda = new Componentes.EditDefault(this.components);
            this.bb_moeda = new System.Windows.Forms.Button();
            this.cd_moeda = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.sigla_moeda = new Componentes.EditDefault(this.components);
            this.tp_fiscal = new Componentes.ComboBoxDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCfgTaxa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgTaxa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.tp_fiscal);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.sigla_moeda);
            this.pDados.Controls.Add(this.ds_moeda);
            this.pDados.Controls.Add(this.bb_moeda);
            this.pDados.Controls.Add(this.cd_moeda);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.DS_TipoPedido);
            this.pDados.Controls.Add(this.BB_CFG_Pedido);
            this.pDados.Controls.Add(this.CFG_Pedido);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.tp_taxa);
            this.pDados.Controls.Add(this.label34);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCfgTaxa);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCfgTaxa, 0);
            // 
            // gCfgTaxa
            // 
            this.gCfgTaxa.AllowUserToAddRows = false;
            this.gCfgTaxa.AllowUserToDeleteRows = false;
            this.gCfgTaxa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gCfgTaxa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCfgTaxa.AutoGenerateColumns = false;
            this.gCfgTaxa.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCfgTaxa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCfgTaxa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCfgTaxa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCfgTaxa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCfgTaxa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipotaxaDataGridViewTextBoxColumn,
            this.cfgpedidoDataGridViewTextBoxColumn,
            this.dstipopedidoDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Sigla});
            this.gCfgTaxa.DataSource = this.bsCfgTaxa;
            resources.ApplyResources(this.gCfgTaxa, "gCfgTaxa");
            this.gCfgTaxa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCfgTaxa.Name = "gCfgTaxa";
            this.gCfgTaxa.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCfgTaxa.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // tipotaxaDataGridViewTextBoxColumn
            // 
            this.tipotaxaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipotaxaDataGridViewTextBoxColumn.DataPropertyName = "Tipo_taxa";
            resources.ApplyResources(this.tipotaxaDataGridViewTextBoxColumn, "tipotaxaDataGridViewTextBoxColumn");
            this.tipotaxaDataGridViewTextBoxColumn.Name = "tipotaxaDataGridViewTextBoxColumn";
            this.tipotaxaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cfgpedidoDataGridViewTextBoxColumn
            // 
            this.cfgpedidoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cfgpedidoDataGridViewTextBoxColumn.DataPropertyName = "Cfg_pedido";
            resources.ApplyResources(this.cfgpedidoDataGridViewTextBoxColumn, "cfgpedidoDataGridViewTextBoxColumn");
            this.cfgpedidoDataGridViewTextBoxColumn.Name = "cfgpedidoDataGridViewTextBoxColumn";
            this.cfgpedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dstipopedidoDataGridViewTextBoxColumn
            // 
            this.dstipopedidoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstipopedidoDataGridViewTextBoxColumn.DataPropertyName = "Ds_tipopedido";
            resources.ApplyResources(this.dstipopedidoDataGridViewTextBoxColumn, "dstipopedidoDataGridViewTextBoxColumn");
            this.dstipopedidoDataGridViewTextBoxColumn.Name = "dstipopedidoDataGridViewTextBoxColumn";
            this.dstipopedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            resources.ApplyResources(this.cdprodutoDataGridViewTextBoxColumn, "cdprodutoDataGridViewTextBoxColumn");
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            resources.ApplyResources(this.dsprodutoDataGridViewTextBoxColumn, "dsprodutoDataGridViewTextBoxColumn");
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cd_moeda";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_moeda";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Sigla
            // 
            this.Sigla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Sigla.DataPropertyName = "Sigla";
            resources.ApplyResources(this.Sigla, "Sigla");
            this.Sigla.Name = "Sigla";
            this.Sigla.ReadOnly = true;
            // 
            // bsCfgTaxa
            // 
            this.bsCfgTaxa.DataSource = typeof(CamadaDados.Graos.TList_CFGTaxa);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCfgTaxa;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
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
            // tp_taxa
            // 
            this.tp_taxa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCfgTaxa, "Tp_taxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_taxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.tp_taxa, "tp_taxa");
            this.tp_taxa.FormattingEnabled = true;
            this.tp_taxa.Name = "tp_taxa";
            this.tp_taxa.NM_Alias = "";
            this.tp_taxa.NM_Campo = "";
            this.tp_taxa.NM_Param = "";
            this.tp_taxa.ST_Gravar = true;
            this.tp_taxa.ST_LimparCampo = true;
            this.tp_taxa.ST_NotNull = true;
            this.tp_taxa.SelectedIndexChanged += new System.EventHandler(this.tp_taxa_SelectedIndexChanged);
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // DS_TipoPedido
            // 
            this.DS_TipoPedido.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TipoPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TipoPedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgTaxa, "Ds_tipopedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_TipoPedido, "DS_TipoPedido");
            this.DS_TipoPedido.Name = "DS_TipoPedido";
            this.DS_TipoPedido.NM_Alias = "";
            this.DS_TipoPedido.NM_Campo = "DS_TipoPedido";
            this.DS_TipoPedido.NM_CampoBusca = "DS_TipoPedido";
            this.DS_TipoPedido.NM_Param = "@P_DS_TIPOPEDIDO";
            this.DS_TipoPedido.QTD_Zero = 0;
            this.DS_TipoPedido.ST_AutoInc = false;
            this.DS_TipoPedido.ST_DisableAuto = false;
            this.DS_TipoPedido.ST_Float = false;
            this.DS_TipoPedido.ST_Gravar = false;
            this.DS_TipoPedido.ST_Int = false;
            this.DS_TipoPedido.ST_LimpaCampo = true;
            this.DS_TipoPedido.ST_NotNull = false;
            this.DS_TipoPedido.ST_PrimaryKey = false;
            // 
            // BB_CFG_Pedido
            // 
            resources.ApplyResources(this.BB_CFG_Pedido, "BB_CFG_Pedido");
            this.BB_CFG_Pedido.Name = "BB_CFG_Pedido";
            this.BB_CFG_Pedido.UseVisualStyleBackColor = true;
            this.BB_CFG_Pedido.Click += new System.EventHandler(this.BB_CFG_Pedido_Click);
            // 
            // CFG_Pedido
            // 
            this.CFG_Pedido.BackColor = System.Drawing.SystemColors.Window;
            this.CFG_Pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CFG_Pedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgTaxa, "Cfg_pedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CFG_Pedido, "CFG_Pedido");
            this.CFG_Pedido.Name = "CFG_Pedido";
            this.CFG_Pedido.NM_Alias = "a";
            this.CFG_Pedido.NM_Campo = "CFG_Pedido";
            this.CFG_Pedido.NM_CampoBusca = "CFG_Pedido";
            this.CFG_Pedido.NM_Param = "@P_CFG_PEDIDO";
            this.CFG_Pedido.QTD_Zero = 0;
            this.CFG_Pedido.ST_AutoInc = false;
            this.CFG_Pedido.ST_DisableAuto = false;
            this.CFG_Pedido.ST_Float = false;
            this.CFG_Pedido.ST_Gravar = true;
            this.CFG_Pedido.ST_Int = true;
            this.CFG_Pedido.ST_LimpaCampo = true;
            this.CFG_Pedido.ST_NotNull = false;
            this.CFG_Pedido.ST_PrimaryKey = false;
            this.CFG_Pedido.Leave += new System.EventHandler(this.CFG_Pedido_Leave);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgTaxa, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_produto, "ds_produto");
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_TIPOPEDIDO";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            // 
            // bb_produto
            // 
            resources.ApplyResources(this.bb_produto, "bb_produto");
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.UseVisualStyleBackColor = true;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgTaxa, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_produto, "cd_produto");
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "a";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CFG_PEDIDO";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ds_moeda
            // 
            this.ds_moeda.BackColor = System.Drawing.SystemColors.Window;
            this.ds_moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_moeda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgTaxa, "Ds_moeda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_moeda, "ds_moeda");
            this.ds_moeda.Name = "ds_moeda";
            this.ds_moeda.NM_Alias = "";
            this.ds_moeda.NM_Campo = "ds_moeda_singular";
            this.ds_moeda.NM_CampoBusca = "ds_moeda_singular";
            this.ds_moeda.NM_Param = "@P_DS_TIPOPEDIDO";
            this.ds_moeda.QTD_Zero = 0;
            this.ds_moeda.ST_AutoInc = false;
            this.ds_moeda.ST_DisableAuto = false;
            this.ds_moeda.ST_Float = false;
            this.ds_moeda.ST_Gravar = false;
            this.ds_moeda.ST_Int = false;
            this.ds_moeda.ST_LimpaCampo = true;
            this.ds_moeda.ST_NotNull = false;
            this.ds_moeda.ST_PrimaryKey = false;
            // 
            // bb_moeda
            // 
            resources.ApplyResources(this.bb_moeda, "bb_moeda");
            this.bb_moeda.Name = "bb_moeda";
            this.bb_moeda.UseVisualStyleBackColor = true;
            this.bb_moeda.Click += new System.EventHandler(this.bb_moeda_Click);
            // 
            // cd_moeda
            // 
            this.cd_moeda.BackColor = System.Drawing.SystemColors.Window;
            this.cd_moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_moeda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgTaxa, "Cd_moeda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_moeda, "cd_moeda");
            this.cd_moeda.Name = "cd_moeda";
            this.cd_moeda.NM_Alias = "a";
            this.cd_moeda.NM_Campo = "cd_moeda";
            this.cd_moeda.NM_CampoBusca = "cd_moeda";
            this.cd_moeda.NM_Param = "@P_CFG_PEDIDO";
            this.cd_moeda.QTD_Zero = 0;
            this.cd_moeda.ST_AutoInc = false;
            this.cd_moeda.ST_DisableAuto = false;
            this.cd_moeda.ST_Float = false;
            this.cd_moeda.ST_Gravar = true;
            this.cd_moeda.ST_Int = true;
            this.cd_moeda.ST_LimpaCampo = true;
            this.cd_moeda.ST_NotNull = false;
            this.cd_moeda.ST_PrimaryKey = false;
            this.cd_moeda.Leave += new System.EventHandler(this.cd_moeda_Leave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // sigla_moeda
            // 
            this.sigla_moeda.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_moeda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgTaxa, "Sigla", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.sigla_moeda, "sigla_moeda");
            this.sigla_moeda.Name = "sigla_moeda";
            this.sigla_moeda.NM_Alias = "";
            this.sigla_moeda.NM_Campo = "sigla";
            this.sigla_moeda.NM_CampoBusca = "sigla";
            this.sigla_moeda.NM_Param = "@P_DS_TIPOPEDIDO";
            this.sigla_moeda.QTD_Zero = 0;
            this.sigla_moeda.ST_AutoInc = false;
            this.sigla_moeda.ST_DisableAuto = false;
            this.sigla_moeda.ST_Float = false;
            this.sigla_moeda.ST_Gravar = false;
            this.sigla_moeda.ST_Int = false;
            this.sigla_moeda.ST_LimpaCampo = true;
            this.sigla_moeda.ST_NotNull = false;
            this.sigla_moeda.ST_PrimaryKey = false;
            // 
            // tp_fiscal
            // 
            this.tp_fiscal.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCfgTaxa, "Tp_fiscal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_fiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.tp_fiscal, "tp_fiscal");
            this.tp_fiscal.FormattingEnabled = true;
            this.tp_fiscal.Name = "tp_fiscal";
            this.tp_fiscal.NM_Alias = "";
            this.tp_fiscal.NM_Campo = "";
            this.tp_fiscal.NM_Param = "";
            this.tp_fiscal.ST_Gravar = true;
            this.tp_fiscal.ST_LimparCampo = true;
            this.tp_fiscal.ST_NotNull = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // TFCadCFGTaxa
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadCFGTaxa";
            this.Load += new System.EventHandler(this.TFCadCFGTaxa_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCFGTaxa_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCfgTaxa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgTaxa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCfgTaxa;
        private System.Windows.Forms.BindingSource bsCfgTaxa;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.ComboBoxDefault tp_taxa;
        private System.Windows.Forms.Label label34;
        private Componentes.EditDefault DS_TipoPedido;
        private System.Windows.Forms.Button BB_CFG_Pedido;
        private Componentes.EditDefault CFG_Pedido;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_moeda;
        private System.Windows.Forms.Button bb_moeda;
        private Componentes.EditDefault cd_moeda;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault sigla_moeda;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipotaxaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfgpedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstipopedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sigla;
        private Componentes.ComboBoxDefault tp_fiscal;
        private System.Windows.Forms.Label label4;
    }
}
