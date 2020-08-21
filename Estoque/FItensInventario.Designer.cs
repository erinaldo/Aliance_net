namespace Estoque
{
    partial class TFItensInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItensInventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.bb_tpproduto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tp_produto = new Componentes.EditDefault(this.components);
            this.bb_grupo = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cd_grupo = new Componentes.EditDefault(this.components);
            this.pGrid = new Componentes.PanelDados(this.components);
            this.st_marcatodos = new Componentes.CheckBoxDefault(this.components);
            this.gProduto = new Componentes.DataGridDefault(this.components);
            this.bsProduto = new System.Windows.Forms.BindingSource(this.components);
            this.cd_marca = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.bb_marca = new System.Windows.Forms.Button();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.stprocessarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DS_Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar,
            this.BB_Buscar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(815, 43);
            this.barraMenu.TabIndex = 536;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // BB_Buscar
            // 
            this.BB_Buscar.AutoSize = false;
            this.BB_Buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BB_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Buscar.Image")));
            this.BB_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Size = new System.Drawing.Size(80, 40);
            this.BB_Buscar.Text = "(F7)\r\nBuscar";
            this.BB_Buscar.ToolTipText = "Localizar Registros";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.pGrid, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(815, 468);
            this.tlpCentral.TabIndex = 537;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.cd_marca);
            this.pFiltro.Controls.Add(this.label5);
            this.pFiltro.Controls.Add(this.bb_marca);
            this.pFiltro.Controls.Add(this.bb_produto);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.cd_produto);
            this.pFiltro.Controls.Add(this.bb_tpproduto);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.tp_produto);
            this.pFiltro.Controls.Add(this.bb_grupo);
            this.pFiltro.Controls.Add(this.label13);
            this.pFiltro.Controls.Add(this.cd_grupo);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(805, 29);
            this.pFiltro.TabIndex = 0;
            // 
            // bb_produto
            // 
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(650, 3);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 101;
            this.bb_produto.UseVisualStyleBackColor = true;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(525, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Produto:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(578, 3);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(69, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 100;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // bb_tpproduto
            // 
            this.bb_tpproduto.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpproduto.Image")));
            this.bb_tpproduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpproduto.Location = new System.Drawing.Point(346, 3);
            this.bb_tpproduto.Name = "bb_tpproduto";
            this.bb_tpproduto.Size = new System.Drawing.Size(28, 19);
            this.bb_tpproduto.TabIndex = 98;
            this.bb_tpproduto.UseVisualStyleBackColor = true;
            this.bb_tpproduto.Click += new System.EventHandler(this.bb_tpproduto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(197, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Tipo Produto:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_produto
            // 
            this.tp_produto.BackColor = System.Drawing.SystemColors.Window;
            this.tp_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_produto.Location = new System.Drawing.Point(274, 3);
            this.tp_produto.Name = "tp_produto";
            this.tp_produto.NM_Alias = "";
            this.tp_produto.NM_Campo = "tp_produto";
            this.tp_produto.NM_CampoBusca = "tp_produto";
            this.tp_produto.NM_Param = "@P_CD_EMPRESA";
            this.tp_produto.QTD_Zero = 0;
            this.tp_produto.Size = new System.Drawing.Size(69, 20);
            this.tp_produto.ST_AutoInc = false;
            this.tp_produto.ST_DisableAuto = false;
            this.tp_produto.ST_Float = false;
            this.tp_produto.ST_Gravar = true;
            this.tp_produto.ST_Int = true;
            this.tp_produto.ST_LimpaCampo = true;
            this.tp_produto.ST_NotNull = false;
            this.tp_produto.ST_PrimaryKey = false;
            this.tp_produto.TabIndex = 97;
            this.tp_produto.TextOld = null;
            this.tp_produto.Leave += new System.EventHandler(this.tp_produto_Leave);
            // 
            // bb_grupo
            // 
            this.bb_grupo.Image = ((System.Drawing.Image)(resources.GetObject("bb_grupo.Image")));
            this.bb_grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_grupo.Location = new System.Drawing.Point(163, 3);
            this.bb_grupo.Name = "bb_grupo";
            this.bb_grupo.Size = new System.Drawing.Size(28, 19);
            this.bb_grupo.TabIndex = 95;
            this.bb_grupo.UseVisualStyleBackColor = true;
            this.bb_grupo.Click += new System.EventHandler(this.bb_grupo_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(6, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 96;
            this.label13.Text = "Grupo Produto:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_grupo
            // 
            this.cd_grupo.BackColor = System.Drawing.SystemColors.Window;
            this.cd_grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_grupo.Location = new System.Drawing.Point(91, 3);
            this.cd_grupo.Name = "cd_grupo";
            this.cd_grupo.NM_Alias = "";
            this.cd_grupo.NM_Campo = "cd_grupo";
            this.cd_grupo.NM_CampoBusca = "cd_grupo";
            this.cd_grupo.NM_Param = "@P_CD_EMPRESA";
            this.cd_grupo.QTD_Zero = 0;
            this.cd_grupo.Size = new System.Drawing.Size(69, 20);
            this.cd_grupo.ST_AutoInc = false;
            this.cd_grupo.ST_DisableAuto = false;
            this.cd_grupo.ST_Float = false;
            this.cd_grupo.ST_Gravar = true;
            this.cd_grupo.ST_Int = true;
            this.cd_grupo.ST_LimpaCampo = true;
            this.cd_grupo.ST_NotNull = false;
            this.cd_grupo.ST_PrimaryKey = false;
            this.cd_grupo.TabIndex = 94;
            this.cd_grupo.TextOld = null;
            this.cd_grupo.Leave += new System.EventHandler(this.cd_grupo_Leave);
            // 
            // pGrid
            // 
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pGrid.Controls.Add(this.bindingNavigator1);
            this.pGrid.Controls.Add(this.st_marcatodos);
            this.pGrid.Controls.Add(this.gProduto);
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid.Location = new System.Drawing.Point(5, 42);
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            this.pGrid.Size = new System.Drawing.Size(805, 421);
            this.pGrid.TabIndex = 1;
            // 
            // st_marcatodos
            // 
            this.st_marcatodos.AutoSize = true;
            this.st_marcatodos.Location = new System.Drawing.Point(8, 4);
            this.st_marcatodos.Name = "st_marcatodos";
            this.st_marcatodos.NM_Alias = "";
            this.st_marcatodos.NM_Campo = "";
            this.st_marcatodos.NM_Param = "";
            this.st_marcatodos.Size = new System.Drawing.Size(15, 14);
            this.st_marcatodos.ST_Gravar = false;
            this.st_marcatodos.ST_LimparCampo = true;
            this.st_marcatodos.ST_NotNull = false;
            this.st_marcatodos.TabIndex = 1;
            this.st_marcatodos.UseVisualStyleBackColor = true;
            this.st_marcatodos.Vl_False = "";
            this.st_marcatodos.Vl_True = "";
            this.st_marcatodos.Click += new System.EventHandler(this.st_marcatodos_Click);
            // 
            // gProduto
            // 
            this.gProduto.AllowUserToAddRows = false;
            this.gProduto.AllowUserToDeleteRows = false;
            this.gProduto.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gProduto.AutoGenerateColumns = false;
            this.gProduto.BackgroundColor = System.Drawing.Color.LightGray;
            this.gProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gProduto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProduto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stprocessarDataGridViewCheckBoxColumn,
            this.cDProdutoDataGridViewTextBoxColumn,
            this.dSProdutoDataGridViewTextBoxColumn,
            this.DS_Marca});
            this.gProduto.DataSource = this.bsProduto;
            this.gProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gProduto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gProduto.Location = new System.Drawing.Point(0, 0);
            this.gProduto.Name = "gProduto";
            this.gProduto.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProduto.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gProduto.RowHeadersWidth = 23;
            this.gProduto.Size = new System.Drawing.Size(801, 417);
            this.gProduto.TabIndex = 0;
            this.gProduto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gProduto_CellClick);
            // 
            // bsProduto
            // 
            this.bsProduto.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadProduto);
            // 
            // cd_marca
            // 
            this.cd_marca.BackColor = System.Drawing.SystemColors.Window;
            this.cd_marca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_marca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_marca.Location = new System.Drawing.Point(428, 3);
            this.cd_marca.Name = "cd_marca";
            this.cd_marca.NM_Alias = "a";
            this.cd_marca.NM_Campo = "cd_marca";
            this.cd_marca.NM_CampoBusca = "cd_marca";
            this.cd_marca.NM_Param = "@P_CD_UNIDADE";
            this.cd_marca.QTD_Zero = 0;
            this.cd_marca.Size = new System.Drawing.Size(56, 20);
            this.cd_marca.ST_AutoInc = false;
            this.cd_marca.ST_DisableAuto = false;
            this.cd_marca.ST_Float = false;
            this.cd_marca.ST_Gravar = true;
            this.cd_marca.ST_Int = false;
            this.cd_marca.ST_LimpaCampo = true;
            this.cd_marca.ST_NotNull = true;
            this.cd_marca.ST_PrimaryKey = false;
            this.cd_marca.TabIndex = 103;
            this.cd_marca.TextOld = null;
            this.cd_marca.Leave += new System.EventHandler(this.cd_marca_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(382, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 105;
            this.label5.Text = "Marca:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bb_marca
            // 
            this.bb_marca.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_marca.Image = ((System.Drawing.Image)(resources.GetObject("bb_marca.Image")));
            this.bb_marca.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_marca.Location = new System.Drawing.Point(488, 3);
            this.bb_marca.Name = "bb_marca";
            this.bb_marca.Size = new System.Drawing.Size(30, 20);
            this.bb_marca.TabIndex = 104;
            this.bb_marca.UseVisualStyleBackColor = true;
            this.bb_marca.Click += new System.EventHandler(this.bb_marca_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsProduto;
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
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 392);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(801, 25);
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
            // stprocessarDataGridViewCheckBoxColumn
            // 
            this.stprocessarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stprocessarDataGridViewCheckBoxColumn.DataPropertyName = "St_processar";
            this.stprocessarDataGridViewCheckBoxColumn.HeaderText = "Inventariar";
            this.stprocessarDataGridViewCheckBoxColumn.Name = "stprocessarDataGridViewCheckBoxColumn";
            this.stprocessarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stprocessarDataGridViewCheckBoxColumn.Width = 63;
            // 
            // cDProdutoDataGridViewTextBoxColumn
            // 
            this.cDProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDProdutoDataGridViewTextBoxColumn.DataPropertyName = "CD_Produto";
            this.cDProdutoDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cDProdutoDataGridViewTextBoxColumn.Name = "cDProdutoDataGridViewTextBoxColumn";
            this.cDProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDProdutoDataGridViewTextBoxColumn.Width = 88;
            // 
            // dSProdutoDataGridViewTextBoxColumn
            // 
            this.dSProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSProdutoDataGridViewTextBoxColumn.DataPropertyName = "DS_Produto";
            this.dSProdutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dSProdutoDataGridViewTextBoxColumn.Name = "dSProdutoDataGridViewTextBoxColumn";
            this.dSProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSProdutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // DS_Marca
            // 
            this.DS_Marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DS_Marca.DataPropertyName = "DS_Marca";
            this.DS_Marca.HeaderText = "Marca";
            this.DS_Marca.Name = "DS_Marca";
            this.DS_Marca.ReadOnly = true;
            this.DS_Marca.Width = 62;
            // 
            // TFItensInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 511);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItensInventario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itens Inventariar";
            this.Load += new System.EventHandler(this.TFItensInventario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensInventario_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.PanelDados pGrid;
        private Componentes.DataGridDefault gProduto;
        private System.Windows.Forms.BindingSource bsProduto;
        private System.Windows.Forms.Button bb_grupo;
        private System.Windows.Forms.Label label13;
        private Componentes.EditDefault cd_grupo;
        private System.Windows.Forms.Button bb_produto;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Button bb_tpproduto;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault tp_produto;
        public System.Windows.Forms.ToolStripButton BB_Buscar;
        private Componentes.CheckBoxDefault st_marcatodos;
        private Componentes.EditDefault cd_marca;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button bb_marca;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DS_Marca;
    }
}