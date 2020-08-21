namespace Faturamento.Cadastros
{
    partial class TFCadVendedor_X_RegiaoVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadVendedor_X_RegiaoVenda));
            System.Windows.Forms.Label cD_VendedorLabel;
            System.Windows.Forms.Label iD_RegiaoLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault = new Componentes.DataGridDefault(this.components);
            this.BS_CadVendedor_X_RegiaoVenda = new System.Windows.Forms.BindingSource(this.components);
            this.CD_Vendedor = new Componentes.EditDefault(this.components);
            this.ID_Regiao = new Componentes.EditDefault(this.components);
            this.nm_regiao = new Componentes.EditDefault(this.components);
            this.nomevendedor = new Componentes.EditDefault(this.components);
            this.BB_Vendedor = new System.Windows.Forms.Button();
            this.BB_Regiao = new System.Windows.Forms.Button();
            this.bn_CadVendedor_X_RegiaoVenda = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bb_cd_tabelaPreco = new System.Windows.Forms.Button();
            this.ds_tabelapreco = new Componentes.EditDefault(this.components);
            this.cd_tabelapreco_padrao = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Cd_vendedorString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOMEVENDEDORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDRegiaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMregiaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdtabelaprecopadraodataGridViewTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstabelaprecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cD_VendedorLabel = new System.Windows.Forms.Label();
            iD_RegiaoLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tList_CadVendedor_X_RegiaoVendaDataGridDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadVendedor_X_RegiaoVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadVendedor_X_RegiaoVenda)).BeginInit();
            this.bn_CadVendedor_X_RegiaoVenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackColor = System.Drawing.Color.YellowGreen;
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.bb_cd_tabelaPreco);
            this.pDados.Controls.Add(this.ds_tabelapreco);
            this.pDados.Controls.Add(this.cd_tabelapreco_padrao);
            this.pDados.Controls.Add(this.BB_Regiao);
            this.pDados.Controls.Add(this.BB_Vendedor);
            this.pDados.Controls.Add(this.nomevendedor);
            this.pDados.Controls.Add(this.nm_regiao);
            this.pDados.Controls.Add(iD_RegiaoLabel);
            this.pDados.Controls.Add(this.ID_Regiao);
            this.pDados.Controls.Add(cD_VendedorLabel);
            this.pDados.Controls.Add(this.CD_Vendedor);
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
            this.tpPadrao.Controls.Add(this.bn_CadVendedor_X_RegiaoVenda);
            this.tpPadrao.Controls.Add(this.tList_CadVendedor_X_RegiaoVendaDataGridDefault);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.tList_CadVendedor_X_RegiaoVendaDataGridDefault, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bn_CadVendedor_X_RegiaoVenda, 0);
            // 
            // cD_VendedorLabel
            // 
            cD_VendedorLabel.AccessibleDescription = null;
            cD_VendedorLabel.AccessibleName = null;
            resources.ApplyResources(cD_VendedorLabel, "cD_VendedorLabel");
            cD_VendedorLabel.Name = "cD_VendedorLabel";
            // 
            // iD_RegiaoLabel
            // 
            iD_RegiaoLabel.AccessibleDescription = null;
            iD_RegiaoLabel.AccessibleName = null;
            resources.ApplyResources(iD_RegiaoLabel, "iD_RegiaoLabel");
            iD_RegiaoLabel.Name = "iD_RegiaoLabel";
            // 
            // tList_CadVendedor_X_RegiaoVendaDataGridDefault
            // 
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.AccessibleDescription = null;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.AccessibleName = null;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.AllowUserToAddRows = false;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.AllowUserToDeleteRows = false;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.tList_CadVendedor_X_RegiaoVendaDataGridDefault, "tList_CadVendedor_X_RegiaoVendaDataGridDefault");
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.AutoGenerateColumns = false;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.BackgroundColor = System.Drawing.Color.LightGray;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.BackgroundImage = null;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cd_vendedorString,
            this.nOMEVENDEDORDataGridViewTextBoxColumn,
            this.iDRegiaoDataGridViewTextBoxColumn,
            this.nMregiaoDataGridViewTextBoxColumn,
            this.cdtabelaprecopadraodataGridViewTextBox,
            this.dstabelaprecoDataGridViewTextBoxColumn});
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.DataSource = this.BS_CadVendedor_X_RegiaoVenda;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.Font = null;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.Name = "tList_CadVendedor_X_RegiaoVendaDataGridDefault";
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tList_CadVendedor_X_RegiaoVendaDataGridDefault.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // BS_CadVendedor_X_RegiaoVenda
            // 
            this.BS_CadVendedor_X_RegiaoVenda.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CadVendedor_X_RegiaoVenda);
            // 
            // CD_Vendedor
            // 
            this.CD_Vendedor.AccessibleDescription = null;
            this.CD_Vendedor.AccessibleName = null;
            resources.ApplyResources(this.CD_Vendedor, "CD_Vendedor");
            this.CD_Vendedor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Vendedor.BackgroundImage = null;
            this.CD_Vendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Vendedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadVendedor_X_RegiaoVenda, "Cd_vendedorString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Vendedor.Font = null;
            this.CD_Vendedor.Name = "CD_Vendedor";
            this.CD_Vendedor.NM_Alias = "a";
            this.CD_Vendedor.NM_Campo = "CD_Vendedor";
            this.CD_Vendedor.NM_CampoBusca = "CD_Vendedor";
            this.CD_Vendedor.NM_Param = "@P_CD_VENDEDOR";
            this.CD_Vendedor.QTD_Zero = 0;
            this.CD_Vendedor.ST_AutoInc = false;
            this.CD_Vendedor.ST_DisableAuto = false;
            this.CD_Vendedor.ST_Float = false;
            this.CD_Vendedor.ST_Gravar = true;
            this.CD_Vendedor.ST_Int = true;
            this.CD_Vendedor.ST_LimpaCampo = true;
            this.CD_Vendedor.ST_NotNull = true;
            this.CD_Vendedor.ST_PrimaryKey = true;
            this.CD_Vendedor.Leave += new System.EventHandler(this.cd_vendedor_Leave);
            // 
            // ID_Regiao
            // 
            this.ID_Regiao.AccessibleDescription = null;
            this.ID_Regiao.AccessibleName = null;
            resources.ApplyResources(this.ID_Regiao, "ID_Regiao");
            this.ID_Regiao.BackColor = System.Drawing.SystemColors.Window;
            this.ID_Regiao.BackgroundImage = null;
            this.ID_Regiao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Regiao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadVendedor_X_RegiaoVenda, "Id_regiaoString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_Regiao.Font = null;
            this.ID_Regiao.Name = "ID_Regiao";
            this.ID_Regiao.NM_Alias = "a";
            this.ID_Regiao.NM_Campo = "ID_Regiao";
            this.ID_Regiao.NM_CampoBusca = "ID_Regiao";
            this.ID_Regiao.NM_Param = "@P_ID_REGIAO";
            this.ID_Regiao.QTD_Zero = 0;
            this.ID_Regiao.ST_AutoInc = false;
            this.ID_Regiao.ST_DisableAuto = false;
            this.ID_Regiao.ST_Float = false;
            this.ID_Regiao.ST_Gravar = true;
            this.ID_Regiao.ST_Int = true;
            this.ID_Regiao.ST_LimpaCampo = true;
            this.ID_Regiao.ST_NotNull = true;
            this.ID_Regiao.ST_PrimaryKey = true;
            this.ID_Regiao.Leave += new System.EventHandler(this.id_regiao_Leave);
            // 
            // nm_regiao
            // 
            this.nm_regiao.AccessibleDescription = null;
            this.nm_regiao.AccessibleName = null;
            resources.ApplyResources(this.nm_regiao, "nm_regiao");
            this.nm_regiao.BackColor = System.Drawing.SystemColors.Window;
            this.nm_regiao.BackgroundImage = null;
            this.nm_regiao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_regiao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadVendedor_X_RegiaoVenda, "NM_regiao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_regiao.Font = null;
            this.nm_regiao.Name = "nm_regiao";
            this.nm_regiao.NM_Alias = "";
            this.nm_regiao.NM_Campo = "NM_Regiao";
            this.nm_regiao.NM_CampoBusca = "NM_Regiao";
            this.nm_regiao.NM_Param = "@P_NM_REGIAO";
            this.nm_regiao.QTD_Zero = 0;
            this.nm_regiao.ST_AutoInc = false;
            this.nm_regiao.ST_DisableAuto = false;
            this.nm_regiao.ST_Float = false;
            this.nm_regiao.ST_Gravar = false;
            this.nm_regiao.ST_Int = false;
            this.nm_regiao.ST_LimpaCampo = true;
            this.nm_regiao.ST_NotNull = false;
            this.nm_regiao.ST_PrimaryKey = false;
            // 
            // nomevendedor
            // 
            this.nomevendedor.AccessibleDescription = null;
            this.nomevendedor.AccessibleName = null;
            resources.ApplyResources(this.nomevendedor, "nomevendedor");
            this.nomevendedor.BackColor = System.Drawing.SystemColors.Window;
            this.nomevendedor.BackgroundImage = null;
            this.nomevendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomevendedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadVendedor_X_RegiaoVenda, "NOMEVENDEDOR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nomevendedor.Font = null;
            this.nomevendedor.Name = "nomevendedor";
            this.nomevendedor.NM_Alias = "";
            this.nomevendedor.NM_Campo = "NomeVendedor";
            this.nomevendedor.NM_CampoBusca = "NomeVendedor";
            this.nomevendedor.NM_Param = "@P_NOMEVENDEDOR";
            this.nomevendedor.QTD_Zero = 0;
            this.nomevendedor.ST_AutoInc = false;
            this.nomevendedor.ST_DisableAuto = false;
            this.nomevendedor.ST_Float = false;
            this.nomevendedor.ST_Gravar = false;
            this.nomevendedor.ST_Int = false;
            this.nomevendedor.ST_LimpaCampo = true;
            this.nomevendedor.ST_NotNull = false;
            this.nomevendedor.ST_PrimaryKey = false;
            // 
            // BB_Vendedor
            // 
            this.BB_Vendedor.AccessibleDescription = null;
            this.BB_Vendedor.AccessibleName = null;
            resources.ApplyResources(this.BB_Vendedor, "BB_Vendedor");
            this.BB_Vendedor.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Vendedor.BackgroundImage = null;
            this.BB_Vendedor.Font = null;
            this.BB_Vendedor.Name = "BB_Vendedor";
            this.BB_Vendedor.UseVisualStyleBackColor = false;
            this.BB_Vendedor.Click += new System.EventHandler(this.BB_Vendedor_Click);
            // 
            // BB_Regiao
            // 
            this.BB_Regiao.AccessibleDescription = null;
            this.BB_Regiao.AccessibleName = null;
            resources.ApplyResources(this.BB_Regiao, "BB_Regiao");
            this.BB_Regiao.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Regiao.BackgroundImage = null;
            this.BB_Regiao.Font = null;
            this.BB_Regiao.Name = "BB_Regiao";
            this.BB_Regiao.UseVisualStyleBackColor = false;
            this.BB_Regiao.Click += new System.EventHandler(this.BB_Regiao_Click);
            // 
            // bn_CadVendedor_X_RegiaoVenda
            // 
            this.bn_CadVendedor_X_RegiaoVenda.AccessibleDescription = null;
            this.bn_CadVendedor_X_RegiaoVenda.AccessibleName = null;
            this.bn_CadVendedor_X_RegiaoVenda.AddNewItem = null;
            resources.ApplyResources(this.bn_CadVendedor_X_RegiaoVenda, "bn_CadVendedor_X_RegiaoVenda");
            this.bn_CadVendedor_X_RegiaoVenda.BackgroundImage = null;
            this.bn_CadVendedor_X_RegiaoVenda.BindingSource = this.BS_CadVendedor_X_RegiaoVenda;
            this.bn_CadVendedor_X_RegiaoVenda.CountItem = this.bindingNavigatorCountItem;
            this.bn_CadVendedor_X_RegiaoVenda.CountItemFormat = "de {0}";
            this.bn_CadVendedor_X_RegiaoVenda.DeleteItem = null;
            this.bn_CadVendedor_X_RegiaoVenda.Font = null;
            this.bn_CadVendedor_X_RegiaoVenda.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bn_CadVendedor_X_RegiaoVenda.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn_CadVendedor_X_RegiaoVenda.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn_CadVendedor_X_RegiaoVenda.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn_CadVendedor_X_RegiaoVenda.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn_CadVendedor_X_RegiaoVenda.Name = "bn_CadVendedor_X_RegiaoVenda";
            this.bn_CadVendedor_X_RegiaoVenda.PositionItem = this.bindingNavigatorPositionItem;
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
            // bb_cd_tabelaPreco
            // 
            this.bb_cd_tabelaPreco.AccessibleDescription = null;
            this.bb_cd_tabelaPreco.AccessibleName = null;
            resources.ApplyResources(this.bb_cd_tabelaPreco, "bb_cd_tabelaPreco");
            this.bb_cd_tabelaPreco.BackColor = System.Drawing.SystemColors.Control;
            this.bb_cd_tabelaPreco.BackgroundImage = null;
            this.bb_cd_tabelaPreco.Font = null;
            this.bb_cd_tabelaPreco.Name = "bb_cd_tabelaPreco";
            this.bb_cd_tabelaPreco.UseVisualStyleBackColor = false;
            this.bb_cd_tabelaPreco.Click += new System.EventHandler(this.bb_cd_tabelaPreco_Click);
            // 
            // ds_tabelapreco
            // 
            this.ds_tabelapreco.AccessibleDescription = null;
            this.ds_tabelapreco.AccessibleName = null;
            resources.ApplyResources(this.ds_tabelapreco, "ds_tabelapreco");
            this.ds_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelapreco.BackgroundImage = null;
            this.ds_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadVendedor_X_RegiaoVenda, "Ds_tabelapreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tabelapreco.Font = null;
            this.ds_tabelapreco.Name = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Alias = "";
            this.ds_tabelapreco.NM_Campo = "DS_TabelaPreco";
            this.ds_tabelapreco.NM_CampoBusca = "DS_TabelaPreco";
            this.ds_tabelapreco.NM_Param = "@P_DS_TABELAPRECO";
            this.ds_tabelapreco.QTD_Zero = 0;
            this.ds_tabelapreco.ST_AutoInc = false;
            this.ds_tabelapreco.ST_DisableAuto = false;
            this.ds_tabelapreco.ST_Float = false;
            this.ds_tabelapreco.ST_Gravar = false;
            this.ds_tabelapreco.ST_Int = false;
            this.ds_tabelapreco.ST_LimpaCampo = true;
            this.ds_tabelapreco.ST_NotNull = false;
            this.ds_tabelapreco.ST_PrimaryKey = false;
            // 
            // cd_tabelapreco_padrao
            // 
            this.cd_tabelapreco_padrao.AccessibleDescription = null;
            this.cd_tabelapreco_padrao.AccessibleName = null;
            resources.ApplyResources(this.cd_tabelapreco_padrao, "cd_tabelapreco_padrao");
            this.cd_tabelapreco_padrao.BackColor = System.Drawing.SystemColors.Window;
            this.cd_tabelapreco_padrao.BackgroundImage = null;
            this.cd_tabelapreco_padrao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tabelapreco_padrao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadVendedor_X_RegiaoVenda, "Cd_tabelapreco_padrao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_tabelapreco_padrao.Font = null;
            this.cd_tabelapreco_padrao.Name = "cd_tabelapreco_padrao";
            this.cd_tabelapreco_padrao.NM_Alias = "a";
            this.cd_tabelapreco_padrao.NM_Campo = "CD_tabelapreco";
            this.cd_tabelapreco_padrao.NM_CampoBusca = "CD_tabelapreco";
            this.cd_tabelapreco_padrao.NM_Param = "@P_CD_TABELAPRECO_PADRAO";
            this.cd_tabelapreco_padrao.QTD_Zero = 0;
            this.cd_tabelapreco_padrao.ST_AutoInc = false;
            this.cd_tabelapreco_padrao.ST_DisableAuto = false;
            this.cd_tabelapreco_padrao.ST_Float = false;
            this.cd_tabelapreco_padrao.ST_Gravar = true;
            this.cd_tabelapreco_padrao.ST_Int = true;
            this.cd_tabelapreco_padrao.ST_LimpaCampo = true;
            this.cd_tabelapreco_padrao.ST_NotNull = true;
            this.cd_tabelapreco_padrao.ST_PrimaryKey = true;
            this.cd_tabelapreco_padrao.Leave += new System.EventHandler(this.cd_tabelapreco_padrao_Leave);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Cd_vendedorString
            // 
            this.Cd_vendedorString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_vendedorString.DataPropertyName = "Cd_vendedorString";
            resources.ApplyResources(this.Cd_vendedorString, "Cd_vendedorString");
            this.Cd_vendedorString.Name = "Cd_vendedorString";
            this.Cd_vendedorString.ReadOnly = true;
            // 
            // nOMEVENDEDORDataGridViewTextBoxColumn
            // 
            this.nOMEVENDEDORDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nOMEVENDEDORDataGridViewTextBoxColumn.DataPropertyName = "NOMEVENDEDOR";
            resources.ApplyResources(this.nOMEVENDEDORDataGridViewTextBoxColumn, "nOMEVENDEDORDataGridViewTextBoxColumn");
            this.nOMEVENDEDORDataGridViewTextBoxColumn.Name = "nOMEVENDEDORDataGridViewTextBoxColumn";
            this.nOMEVENDEDORDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDRegiaoDataGridViewTextBoxColumn
            // 
            this.iDRegiaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDRegiaoDataGridViewTextBoxColumn.DataPropertyName = "ID_Regiao";
            resources.ApplyResources(this.iDRegiaoDataGridViewTextBoxColumn, "iDRegiaoDataGridViewTextBoxColumn");
            this.iDRegiaoDataGridViewTextBoxColumn.Name = "iDRegiaoDataGridViewTextBoxColumn";
            this.iDRegiaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nMregiaoDataGridViewTextBoxColumn
            // 
            this.nMregiaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMregiaoDataGridViewTextBoxColumn.DataPropertyName = "NM_regiao";
            resources.ApplyResources(this.nMregiaoDataGridViewTextBoxColumn, "nMregiaoDataGridViewTextBoxColumn");
            this.nMregiaoDataGridViewTextBoxColumn.Name = "nMregiaoDataGridViewTextBoxColumn";
            this.nMregiaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdtabelaprecopadraodataGridViewTextBox
            // 
            this.cdtabelaprecopadraodataGridViewTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdtabelaprecopadraodataGridViewTextBox.DataPropertyName = "Cd_tabelapreco_padrao";
            resources.ApplyResources(this.cdtabelaprecopadraodataGridViewTextBox, "cdtabelaprecopadraodataGridViewTextBox");
            this.cdtabelaprecopadraodataGridViewTextBox.Name = "cdtabelaprecopadraodataGridViewTextBox";
            this.cdtabelaprecopadraodataGridViewTextBox.ReadOnly = true;
            // 
            // dstabelaprecoDataGridViewTextBoxColumn
            // 
            this.dstabelaprecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstabelaprecoDataGridViewTextBoxColumn.DataPropertyName = "Ds_tabelapreco";
            resources.ApplyResources(this.dstabelaprecoDataGridViewTextBoxColumn, "dstabelaprecoDataGridViewTextBoxColumn");
            this.dstabelaprecoDataGridViewTextBoxColumn.Name = "dstabelaprecoDataGridViewTextBoxColumn";
            this.dstabelaprecoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCadVendedor_X_RegiaoVenda
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadVendedor_X_RegiaoVenda";
            this.Load += new System.EventHandler(this.TFCadVendedor_X_RegiaoVenda_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tList_CadVendedor_X_RegiaoVendaDataGridDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadVendedor_X_RegiaoVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadVendedor_X_RegiaoVenda)).EndInit();
            this.bn_CadVendedor_X_RegiaoVenda.ResumeLayout(false);
            this.bn_CadVendedor_X_RegiaoVenda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault nomevendedor;
        private Componentes.EditDefault nm_regiao;
        private Componentes.EditDefault ID_Regiao;
        private Componentes.EditDefault CD_Vendedor;
        private Componentes.DataGridDefault tList_CadVendedor_X_RegiaoVendaDataGridDefault;
        private System.Windows.Forms.Button BB_Regiao;
        private System.Windows.Forms.Button BB_Vendedor;
        private System.Windows.Forms.BindingNavigator bn_CadVendedor_X_RegiaoVenda;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource BS_CadVendedor_X_RegiaoVenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_cd_tabelaPreco;
        private Componentes.EditDefault ds_tabelapreco;
        private Componentes.EditDefault cd_tabelapreco_padrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_vendedorString;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMEVENDEDORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDRegiaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMregiaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdtabelaprecopadraodataGridViewTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstabelaprecoDataGridViewTextBoxColumn;
    }
}