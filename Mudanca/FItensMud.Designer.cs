namespace Mudanca
{
    partial class TFItensMud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItensMud));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsItensMud = new System.Windows.Forms.BindingSource(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_itemBusca = new Componentes.EditDefault(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.gItens = new Componentes.DataGridDefault(this.components);
            this.pSt_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pId_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pds_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pMetragemCub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pTot_metragemCub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pVlseguro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tot_seguro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tot_mtcubico = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tot_vlseguro = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.excluirItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverParaCimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverParaBaixoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensMud)).BeginInit();
            this.pDados.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gItens)).BeginInit();
            this.cmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(948, 43);
            this.barraMenu.TabIndex = 14;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // bsItensMud
            // 
            this.bsItensMud.DataSource = typeof(CamadaDados.Mudanca.TList_LanItensMud);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.tableLayoutPanel1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(948, 528);
            this.pDados.TabIndex = 15;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(946, 526);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.ds_itemBusca);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(940, 28);
            this.panelDados1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Localizar Item:";
            // 
            // ds_itemBusca
            // 
            this.ds_itemBusca.BackColor = System.Drawing.SystemColors.Window;
            this.ds_itemBusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_itemBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_itemBusca.Location = new System.Drawing.Point(88, 3);
            this.ds_itemBusca.Name = "ds_itemBusca";
            this.ds_itemBusca.NM_Alias = "";
            this.ds_itemBusca.NM_Campo = "";
            this.ds_itemBusca.NM_CampoBusca = "";
            this.ds_itemBusca.NM_Param = "";
            this.ds_itemBusca.QTD_Zero = 0;
            this.ds_itemBusca.Size = new System.Drawing.Size(404, 20);
            this.ds_itemBusca.ST_AutoInc = false;
            this.ds_itemBusca.ST_DisableAuto = false;
            this.ds_itemBusca.ST_Float = false;
            this.ds_itemBusca.ST_Gravar = false;
            this.ds_itemBusca.ST_Int = false;
            this.ds_itemBusca.ST_LimpaCampo = true;
            this.ds_itemBusca.ST_NotNull = false;
            this.ds_itemBusca.ST_PrimaryKey = false;
            this.ds_itemBusca.TabIndex = 0;
            this.ds_itemBusca.TextOld = null;
            this.ds_itemBusca.TextChanged += new System.EventHandler(this.ds_itemBusca_TextChanged);
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(this.gItens);
            this.panelDados2.Controls.Add(this.bindingNavigator1);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 37);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(940, 486);
            this.panelDados2.TabIndex = 1;
            // 
            // gItens
            // 
            this.gItens.AllowUserToAddRows = false;
            this.gItens.AllowUserToDeleteRows = false;
            this.gItens.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gItens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gItens.AutoGenerateColumns = false;
            this.gItens.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gItens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pSt_processar,
            this.pId_item,
            this.pds_item,
            this.pQuantidade,
            this.pMetragemCub,
            this.pTot_metragemCub,
            this.pVlseguro,
            this.Tot_seguro});
            this.gItens.ContextMenuStrip = this.cmMenu;
            this.gItens.DataSource = this.bsItensMud;
            this.gItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gItens.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gItens.Location = new System.Drawing.Point(0, 0);
            this.gItens.MultiSelect = false;
            this.gItens.Name = "gItens";
            this.gItens.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItens.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gItens.RowHeadersWidth = 23;
            this.gItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gItens.Size = new System.Drawing.Size(938, 459);
            this.gItens.TabIndex = 0;
            this.gItens.DoubleClick += new System.EventHandler(this.gItens_DoubleClick);
            this.gItens.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gItens_CellFormatting);
            this.gItens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gItens_CellClick);
            // 
            // pSt_processar
            // 
            this.pSt_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pSt_processar.DataPropertyName = "St_processar";
            this.pSt_processar.HeaderText = "Selecionar";
            this.pSt_processar.Name = "pSt_processar";
            this.pSt_processar.ReadOnly = true;
            this.pSt_processar.Width = 63;
            // 
            // pId_item
            // 
            this.pId_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pId_item.DataPropertyName = "Id_item";
            this.pId_item.HeaderText = "Id.Item";
            this.pId_item.Name = "pId_item";
            this.pId_item.ReadOnly = true;
            this.pId_item.Width = 64;
            // 
            // pds_item
            // 
            this.pds_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pds_item.DataPropertyName = "Ds_item";
            this.pds_item.HeaderText = "Item";
            this.pds_item.Name = "pds_item";
            this.pds_item.ReadOnly = true;
            this.pds_item.Width = 52;
            // 
            // pQuantidade
            // 
            this.pQuantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pQuantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = "0";
            this.pQuantidade.DefaultCellStyle = dataGridViewCellStyle3;
            this.pQuantidade.HeaderText = "Quantidade";
            this.pQuantidade.Name = "pQuantidade";
            this.pQuantidade.ReadOnly = true;
            this.pQuantidade.Width = 87;
            // 
            // pMetragemCub
            // 
            this.pMetragemCub.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pMetragemCub.DataPropertyName = "MetragemCub";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.pMetragemCub.DefaultCellStyle = dataGridViewCellStyle4;
            this.pMetragemCub.HeaderText = "MT Cub.";
            this.pMetragemCub.Name = "pMetragemCub";
            this.pMetragemCub.ReadOnly = true;
            this.pMetragemCub.Width = 73;
            // 
            // pTot_metragemCub
            // 
            this.pTot_metragemCub.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pTot_metragemCub.DataPropertyName = "Tot_metragemCub";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.pTot_metragemCub.DefaultCellStyle = dataGridViewCellStyle5;
            this.pTot_metragemCub.HeaderText = "Total MT Cub.";
            this.pTot_metragemCub.Name = "pTot_metragemCub";
            this.pTot_metragemCub.ReadOnly = true;
            // 
            // pVlseguro
            // 
            this.pVlseguro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pVlseguro.DataPropertyName = "Vl_seguro";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.pVlseguro.DefaultCellStyle = dataGridViewCellStyle6;
            this.pVlseguro.HeaderText = "Vl.Seguro";
            this.pVlseguro.Name = "pVlseguro";
            this.pVlseguro.ReadOnly = true;
            this.pVlseguro.Width = 78;
            // 
            // Tot_seguro
            // 
            this.Tot_seguro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tot_seguro.DataPropertyName = "Tot_seguro";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.Tot_seguro.DefaultCellStyle = dataGridViewCellStyle7;
            this.Tot_seguro.HeaderText = "Total Seguro";
            this.Tot_seguro.Name = "Tot_seguro";
            this.Tot_seguro.ReadOnly = true;
            this.Tot_seguro.Width = 93;
            // 
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNovo,
            this.excluirItemToolStripMenuItem,
            this.moverParaCimaToolStripMenuItem,
            this.moverParaBaixoToolStripMenuItem});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(166, 114);
            // 
            // tsmNovo
            // 
            this.tsmNovo.Name = "tsmNovo";
            this.tsmNovo.Size = new System.Drawing.Size(165, 22);
            this.tsmNovo.Text = "Novo Item";
            this.tsmNovo.Click += new System.EventHandler(this.tsmNovo_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsItensMud;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
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
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tot_mtcubico,
            this.toolStripLabel5,
            this.tot_vlseguro,
            this.toolStripSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 459);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(938, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(98, 22);
            this.toolStripLabel1.Text = "Total MT Cubico:";
            // 
            // tot_mtcubico
            // 
            this.tot_mtcubico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tot_mtcubico.Enabled = false;
            this.tot_mtcubico.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tot_mtcubico.Name = "tot_mtcubico";
            this.tot_mtcubico.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(94, 22);
            this.toolStripLabel5.Text = "Total Vl.Seguro:";
            // 
            // tot_vlseguro
            // 
            this.tot_vlseguro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tot_vlseguro.Enabled = false;
            this.tot_vlseguro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tot_vlseguro.Name = "tot_vlseguro";
            this.tot_vlseguro.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // excluirItemToolStripMenuItem
            // 
            this.excluirItemToolStripMenuItem.Name = "excluirItemToolStripMenuItem";
            this.excluirItemToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.excluirItemToolStripMenuItem.Text = "Excluir Item";
            this.excluirItemToolStripMenuItem.Click += new System.EventHandler(this.excluirItemToolStripMenuItem_Click);
            // 
            // moverParaCimaToolStripMenuItem
            // 
            this.moverParaCimaToolStripMenuItem.Name = "moverParaCimaToolStripMenuItem";
            this.moverParaCimaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.moverParaCimaToolStripMenuItem.Text = "Mover Para Cima";
            this.moverParaCimaToolStripMenuItem.Click += new System.EventHandler(this.moverParaCimaToolStripMenuItem_Click);
            // 
            // moverParaBaixoToolStripMenuItem
            // 
            this.moverParaBaixoToolStripMenuItem.Name = "moverParaBaixoToolStripMenuItem";
            this.moverParaBaixoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.moverParaBaixoToolStripMenuItem.Text = "Mover Para Baixo";
            this.moverParaBaixoToolStripMenuItem.Click += new System.EventHandler(this.moverParaBaixoToolStripMenuItem_Click);
            // 
            // TFItensMud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 571);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItensMud";
            this.ShowInTaskbar = false;
            this.Text = "Lista Itens Mudança";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFItensMud_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensMud_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensMud)).EndInit();
            this.pDados.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gItens)).EndInit();
            this.cmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsItensMud;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_itemBusca;
        private Componentes.DataGridDefault gItens;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tot_mtcubico;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox tot_vlseguro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmNovo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pSt_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn pId_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn pds_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn pQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn pMetragemCub;
        private System.Windows.Forms.DataGridViewTextBoxColumn pTot_metragemCub;
        private System.Windows.Forms.DataGridViewTextBoxColumn pVlseguro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tot_seguro;
        private System.Windows.Forms.ToolStripMenuItem excluirItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverParaCimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverParaBaixoToolStripMenuItem;
    }
}