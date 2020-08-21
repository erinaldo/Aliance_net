namespace Faturamento.Cadastros
{
    partial class TFCadCfgCompraAvulsa
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
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCfgCompraAvulsa));
            System.Windows.Forms.Label label1;
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfgpedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstipopedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdlocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dslocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCompraAvulsa = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cfg_pedido = new Componentes.EditDefault(this.components);
            this.ds_tipopedido = new Componentes.EditDefault(this.components);
            this.bb_cfgpedido = new System.Windows.Forms.Button();
            this.cd_local = new Componentes.EditDefault(this.components);
            this.ds_local = new Componentes.EditDefault(this.components);
            this.bb_local = new System.Windows.Forms.Button();
            this.bb_almox = new System.Windows.Forms.Button();
            this.ds_almoxarifado = new Componentes.EditDefault(this.components);
            this.id_almox = new Componentes.EditDefault(this.components);
            cd_empresaLabel = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCompraAvulsa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.bb_almox);
            this.pDados.Controls.Add(this.ds_almoxarifado);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.id_almox);
            this.pDados.Controls.Add(this.cd_local);
            this.pDados.Controls.Add(this.ds_local);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.bb_local);
            this.pDados.Controls.Add(this.cfg_pedido);
            this.pDados.Controls.Add(this.ds_tipopedido);
            this.pDados.Controls.Add(label17);
            this.pDados.Controls.Add(this.bb_cfgpedido);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Size = new System.Drawing.Size(659, 113);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(28, 6);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(51, 13);
            cd_empresaLabel.TabIndex = 36;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label17.Location = new System.Drawing.Point(6, 32);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(73, 13);
            label17.TabIndex = 103;
            label17.Text = "CFG. Compra:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(8, 58);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(71, 13);
            label4.TabIndex = 107;
            label4.Text = "Local Armaz.:";
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.cfgpedidoDataGridViewTextBoxColumn,
            this.dstipopedidoDataGridViewTextBoxColumn,
            this.cdlocalDataGridViewTextBoxColumn,
            this.dslocalDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsCompraAvulsa;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 113);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(659, 222);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 92;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            this.nmempresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmempresaDataGridViewTextBoxColumn.Width = 73;
            // 
            // cfgpedidoDataGridViewTextBoxColumn
            // 
            this.cfgpedidoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cfgpedidoDataGridViewTextBoxColumn.DataPropertyName = "Cfg_pedido";
            this.cfgpedidoDataGridViewTextBoxColumn.HeaderText = "CFG. Pedido Compra";
            this.cfgpedidoDataGridViewTextBoxColumn.Name = "cfgpedidoDataGridViewTextBoxColumn";
            this.cfgpedidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cfgpedidoDataGridViewTextBoxColumn.Width = 120;
            // 
            // dstipopedidoDataGridViewTextBoxColumn
            // 
            this.dstipopedidoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstipopedidoDataGridViewTextBoxColumn.DataPropertyName = "Ds_tipopedido";
            this.dstipopedidoDataGridViewTextBoxColumn.HeaderText = "Tipo Pedido Compra";
            this.dstipopedidoDataGridViewTextBoxColumn.Name = "dstipopedidoDataGridViewTextBoxColumn";
            this.dstipopedidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstipopedidoDataGridViewTextBoxColumn.Width = 117;
            // 
            // cdlocalDataGridViewTextBoxColumn
            // 
            this.cdlocalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdlocalDataGridViewTextBoxColumn.DataPropertyName = "Cd_local";
            this.cdlocalDataGridViewTextBoxColumn.HeaderText = "Cd. Local";
            this.cdlocalDataGridViewTextBoxColumn.Name = "cdlocalDataGridViewTextBoxColumn";
            this.cdlocalDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdlocalDataGridViewTextBoxColumn.Width = 71;
            // 
            // dslocalDataGridViewTextBoxColumn
            // 
            this.dslocalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dslocalDataGridViewTextBoxColumn.DataPropertyName = "Ds_local";
            this.dslocalDataGridViewTextBoxColumn.HeaderText = "Local Armazenagem";
            this.dslocalDataGridViewTextBoxColumn.Name = "dslocalDataGridViewTextBoxColumn";
            this.dslocalDataGridViewTextBoxColumn.ReadOnly = true;
            this.dslocalDataGridViewTextBoxColumn.Width = 117;
            // 
            // bsCompraAvulsa
            // 
            this.bsCompraAvulsa.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CfgCompraAvulsa);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCompraAvulsa;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 335);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(659, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompraAvulsa, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(85, 3);
            this.cd_empresa.MaxLength = 4;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(67, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = true;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompraAvulsa, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(187, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(442, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 37;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Enabled = false;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(153, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cfg_pedido
            // 
            this.cfg_pedido.BackColor = System.Drawing.Color.White;
            this.cfg_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cfg_pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cfg_pedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompraAvulsa, "Cfg_pedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cfg_pedido.Enabled = false;
            this.cfg_pedido.Location = new System.Drawing.Point(85, 29);
            this.cfg_pedido.MaxLength = 4;
            this.cfg_pedido.Name = "cfg_pedido";
            this.cfg_pedido.NM_Alias = "";
            this.cfg_pedido.NM_Campo = "cfg_pedido";
            this.cfg_pedido.NM_CampoBusca = "cfg_pedido";
            this.cfg_pedido.NM_Param = "@P_CD_EMPRESA";
            this.cfg_pedido.QTD_Zero = 0;
            this.cfg_pedido.Size = new System.Drawing.Size(67, 20);
            this.cfg_pedido.ST_AutoInc = false;
            this.cfg_pedido.ST_DisableAuto = false;
            this.cfg_pedido.ST_Float = false;
            this.cfg_pedido.ST_Gravar = true;
            this.cfg_pedido.ST_Int = false;
            this.cfg_pedido.ST_LimpaCampo = true;
            this.cfg_pedido.ST_NotNull = true;
            this.cfg_pedido.ST_PrimaryKey = false;
            this.cfg_pedido.TabIndex = 2;
            this.cfg_pedido.TextOld = null;
            this.cfg_pedido.Leave += new System.EventHandler(this.cfg_pedido_Leave);
            // 
            // ds_tipopedido
            // 
            this.ds_tipopedido.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tipopedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tipopedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tipopedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompraAvulsa, "Ds_tipopedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tipopedido.Enabled = false;
            this.ds_tipopedido.Location = new System.Drawing.Point(187, 29);
            this.ds_tipopedido.Name = "ds_tipopedido";
            this.ds_tipopedido.NM_Alias = "";
            this.ds_tipopedido.NM_Campo = "ds_tipopedido";
            this.ds_tipopedido.NM_CampoBusca = "ds_tipopedido";
            this.ds_tipopedido.NM_Param = "@P_NM_EMPRESA";
            this.ds_tipopedido.QTD_Zero = 0;
            this.ds_tipopedido.Size = new System.Drawing.Size(442, 20);
            this.ds_tipopedido.ST_AutoInc = false;
            this.ds_tipopedido.ST_DisableAuto = false;
            this.ds_tipopedido.ST_Float = false;
            this.ds_tipopedido.ST_Gravar = false;
            this.ds_tipopedido.ST_Int = false;
            this.ds_tipopedido.ST_LimpaCampo = true;
            this.ds_tipopedido.ST_NotNull = false;
            this.ds_tipopedido.ST_PrimaryKey = false;
            this.ds_tipopedido.TabIndex = 104;
            this.ds_tipopedido.TextOld = null;
            // 
            // bb_cfgpedido
            // 
            this.bb_cfgpedido.BackColor = System.Drawing.SystemColors.Control;
            this.bb_cfgpedido.Enabled = false;
            this.bb_cfgpedido.Image = ((System.Drawing.Image)(resources.GetObject("bb_cfgpedido.Image")));
            this.bb_cfgpedido.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_cfgpedido.Location = new System.Drawing.Point(153, 29);
            this.bb_cfgpedido.Name = "bb_cfgpedido";
            this.bb_cfgpedido.Size = new System.Drawing.Size(28, 19);
            this.bb_cfgpedido.TabIndex = 3;
            this.bb_cfgpedido.UseVisualStyleBackColor = false;
            this.bb_cfgpedido.Click += new System.EventHandler(this.bb_cfgpedido_Click);
            // 
            // cd_local
            // 
            this.cd_local.BackColor = System.Drawing.Color.White;
            this.cd_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompraAvulsa, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_local.Enabled = false;
            this.cd_local.Location = new System.Drawing.Point(85, 55);
            this.cd_local.MaxLength = 4;
            this.cd_local.Name = "cd_local";
            this.cd_local.NM_Alias = "";
            this.cd_local.NM_Campo = "cd_local";
            this.cd_local.NM_CampoBusca = "cd_local";
            this.cd_local.NM_Param = "@P_CD_EMPRESA";
            this.cd_local.QTD_Zero = 0;
            this.cd_local.Size = new System.Drawing.Size(67, 20);
            this.cd_local.ST_AutoInc = false;
            this.cd_local.ST_DisableAuto = false;
            this.cd_local.ST_Float = false;
            this.cd_local.ST_Gravar = true;
            this.cd_local.ST_Int = false;
            this.cd_local.ST_LimpaCampo = true;
            this.cd_local.ST_NotNull = true;
            this.cd_local.ST_PrimaryKey = false;
            this.cd_local.TabIndex = 4;
            this.cd_local.TextOld = null;
            this.cd_local.Leave += new System.EventHandler(this.cd_local_Leave);
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompraAvulsa, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_local.Enabled = false;
            this.ds_local.Location = new System.Drawing.Point(187, 55);
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_NM_EMPRESA";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.Size = new System.Drawing.Size(442, 20);
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = false;
            this.ds_local.ST_Int = false;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = false;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TabIndex = 108;
            this.ds_local.TextOld = null;
            // 
            // bb_local
            // 
            this.bb_local.BackColor = System.Drawing.SystemColors.Control;
            this.bb_local.Enabled = false;
            this.bb_local.Image = ((System.Drawing.Image)(resources.GetObject("bb_local.Image")));
            this.bb_local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_local.Location = new System.Drawing.Point(153, 55);
            this.bb_local.Name = "bb_local";
            this.bb_local.Size = new System.Drawing.Size(28, 19);
            this.bb_local.TabIndex = 5;
            this.bb_local.UseVisualStyleBackColor = false;
            this.bb_local.Click += new System.EventHandler(this.bb_local_Click);
            // 
            // bb_almox
            // 
            this.bb_almox.BackColor = System.Drawing.SystemColors.Control;
            this.bb_almox.Image = ((System.Drawing.Image)(resources.GetObject("bb_almox.Image")));
            this.bb_almox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_almox.Location = new System.Drawing.Point(153, 81);
            this.bb_almox.Name = "bb_almox";
            this.bb_almox.Size = new System.Drawing.Size(28, 19);
            this.bb_almox.TabIndex = 110;
            this.bb_almox.UseVisualStyleBackColor = false;
            this.bb_almox.Click += new System.EventHandler(this.bb_almox_Click);
            // 
            // ds_almoxarifado
            // 
            this.ds_almoxarifado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_almoxarifado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_almoxarifado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_almoxarifado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompraAvulsa, "Ds_almox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_almoxarifado.Enabled = false;
            this.ds_almoxarifado.Location = new System.Drawing.Point(187, 80);
            this.ds_almoxarifado.Name = "ds_almoxarifado";
            this.ds_almoxarifado.NM_Alias = "";
            this.ds_almoxarifado.NM_Campo = "ds_almoxarifado";
            this.ds_almoxarifado.NM_CampoBusca = "ds_almoxarifado";
            this.ds_almoxarifado.NM_Param = "@P_NM_EMPRESA";
            this.ds_almoxarifado.QTD_Zero = 0;
            this.ds_almoxarifado.Size = new System.Drawing.Size(442, 20);
            this.ds_almoxarifado.ST_AutoInc = false;
            this.ds_almoxarifado.ST_DisableAuto = false;
            this.ds_almoxarifado.ST_Float = false;
            this.ds_almoxarifado.ST_Gravar = false;
            this.ds_almoxarifado.ST_Int = false;
            this.ds_almoxarifado.ST_LimpaCampo = true;
            this.ds_almoxarifado.ST_NotNull = false;
            this.ds_almoxarifado.ST_PrimaryKey = false;
            this.ds_almoxarifado.TabIndex = 112;
            this.ds_almoxarifado.TextOld = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(9, 84);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(70, 13);
            label1.TabIndex = 111;
            label1.Text = "Almoxarifado:";
            // 
            // id_almox
            // 
            this.id_almox.BackColor = System.Drawing.SystemColors.Window;
            this.id_almox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompraAvulsa, "Id_almox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_almox.Location = new System.Drawing.Point(85, 81);
            this.id_almox.Name = "id_almox";
            this.id_almox.NM_Alias = "";
            this.id_almox.NM_Campo = "id_almox";
            this.id_almox.NM_CampoBusca = "id_almox";
            this.id_almox.NM_Param = "@P_CD_EMPRESA";
            this.id_almox.QTD_Zero = 0;
            this.id_almox.Size = new System.Drawing.Size(67, 20);
            this.id_almox.ST_AutoInc = false;
            this.id_almox.ST_DisableAuto = false;
            this.id_almox.ST_Float = false;
            this.id_almox.ST_Gravar = true;
            this.id_almox.ST_Int = false;
            this.id_almox.ST_LimpaCampo = true;
            this.id_almox.ST_NotNull = true;
            this.id_almox.ST_PrimaryKey = false;
            this.id_almox.TabIndex = 109;
            this.id_almox.TextOld = null;
            this.id_almox.Leave += new System.EventHandler(this.id_almox_Leave);
            // 
            // TFCadCfgCompraAvulsa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadCfgCompraAvulsa";
            this.Text = "Configuração Romaneio Compra";
            this.Load += new System.EventHandler(this.TFCadCfgCompraAvulsa_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCfgCompraAvulsa_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCompraAvulsa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfgpedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstipopedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdlocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dslocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsCompraAvulsa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cfg_pedido;
        private Componentes.EditDefault ds_tipopedido;
        private System.Windows.Forms.Button bb_cfgpedido;
        private Componentes.EditDefault cd_local;
        private Componentes.EditDefault ds_local;
        private System.Windows.Forms.Button bb_local;
        private System.Windows.Forms.Button bb_almox;
        private Componentes.EditDefault ds_almoxarifado;
        private Componentes.EditDefault id_almox;
    }
}
