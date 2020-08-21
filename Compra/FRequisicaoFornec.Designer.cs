namespace Compra
{
    partial class TFRequisicaoFornec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRequisicaoFornec));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label cd_produtoLabel;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gClifor = new Componentes.DataGridDefault(this.components);
            this.pCd_clifor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsClifor = new System.Windows.Forms.BindingSource(this.components);
            this.bnClifor = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.bb_fornecedor = new System.Windows.Forms.Button();
            this.cd_fornecedor = new Componentes.EditDefault(this.components);
            this.cbCotacao = new Componentes.CheckBoxDefault(this.components);
            this.cbCompras = new Componentes.CheckBoxDefault(this.components);
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            label17 = new System.Windows.Forms.Label();
            cd_produtoLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gClifor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClifor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnClifor)).BeginInit();
            this.bnClifor.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Imprimir,
            this.BB_Buscar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1053, 43);
            this.barraMenu.TabIndex = 12;
            // 
            // BB_Imprimir
            // 
            this.BB_Imprimir.AutoSize = false;
            this.BB_Imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BB_Imprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Imprimir.ForeColor = System.Drawing.Color.Green;
            this.BB_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Imprimir.Image")));
            this.BB_Imprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Imprimir.Name = "BB_Imprimir";
            this.BB_Imprimir.Size = new System.Drawing.Size(95, 40);
            this.BB_Imprimir.Text = "(F8)\r\nImprimir";
            this.BB_Imprimir.ToolTipText = "Imprimir Registros";
            this.BB_Imprimir.Click += new System.EventHandler(this.BB_Imprimir_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.gClifor);
            this.panelDados1.Controls.Add(this.bnClifor);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 48);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1047, 487);
            this.panelDados1.TabIndex = 13;
            // 
            // gClifor
            // 
            this.gClifor.AllowUserToAddRows = false;
            this.gClifor.AllowUserToDeleteRows = false;
            this.gClifor.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gClifor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gClifor.AutoGenerateColumns = false;
            this.gClifor.BackgroundColor = System.Drawing.Color.LightGray;
            this.gClifor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gClifor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gClifor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gClifor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gClifor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pCd_clifor,
            this.nmcliforDataGridViewTextBoxColumn});
            this.gClifor.DataSource = this.bsClifor;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gClifor.DefaultCellStyle = dataGridViewCellStyle7;
            this.gClifor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gClifor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gClifor.Location = new System.Drawing.Point(0, 0);
            this.gClifor.Name = "gClifor";
            this.gClifor.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gClifor.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gClifor.RowHeadersWidth = 23;
            this.gClifor.Size = new System.Drawing.Size(1045, 460);
            this.gClifor.TabIndex = 4;
            // 
            // pCd_clifor
            // 
            this.pCd_clifor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pCd_clifor.DataPropertyName = "Cd_clifor";
            this.pCd_clifor.HeaderText = "Cd. Clifor";
            this.pCd_clifor.Name = "pCd_clifor";
            this.pCd_clifor.ReadOnly = true;
            this.pCd_clifor.Width = 74;
            // 
            // nmcliforDataGridViewTextBoxColumn
            // 
            this.nmcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor";
            this.nmcliforDataGridViewTextBoxColumn.HeaderText = "Nome Clifor";
            this.nmcliforDataGridViewTextBoxColumn.Name = "nmcliforDataGridViewTextBoxColumn";
            this.nmcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcliforDataGridViewTextBoxColumn.Width = 86;
            // 
            // bsClifor
            // 
            this.bsClifor.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadClifor);
            // 
            // bnClifor
            // 
            this.bnClifor.AddNewItem = null;
            this.bnClifor.BindingSource = this.bsClifor;
            this.bnClifor.CountItem = this.bindingNavigatorCountItem;
            this.bnClifor.CountItemFormat = "de {0}";
            this.bnClifor.DeleteItem = null;
            this.bnClifor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnClifor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator1});
            this.bnClifor.Location = new System.Drawing.Point(0, 460);
            this.bnClifor.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnClifor.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnClifor.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnClifor.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnClifor.Name = "bnClifor";
            this.bnClifor.PositionItem = this.bindingNavigatorPositionItem;
            this.bnClifor.Size = new System.Drawing.Size(1045, 25);
            this.bnClifor.TabIndex = 5;
            this.bnClifor.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pFiltro, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1053, 538);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.bb_produto);
            this.pFiltro.Controls.Add(cd_produtoLabel);
            this.pFiltro.Controls.Add(this.cd_produto);
            this.pFiltro.Controls.Add(this.cbCompras);
            this.pFiltro.Controls.Add(this.cbCotacao);
            this.pFiltro.Controls.Add(this.bb_fornecedor);
            this.pFiltro.Controls.Add(label17);
            this.pFiltro.Controls.Add(this.cd_fornecedor);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 3);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(1047, 39);
            this.pFiltro.TabIndex = 14;
            // 
            // bb_fornecedor
            // 
            this.bb_fornecedor.BackColor = System.Drawing.SystemColors.Control;
            this.bb_fornecedor.Image = ((System.Drawing.Image)(resources.GetObject("bb_fornecedor.Image")));
            this.bb_fornecedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_fornecedor.Location = new System.Drawing.Point(155, 9);
            this.bb_fornecedor.Name = "bb_fornecedor";
            this.bb_fornecedor.Size = new System.Drawing.Size(28, 19);
            this.bb_fornecedor.TabIndex = 128;
            this.bb_fornecedor.UseVisualStyleBackColor = false;
            this.bb_fornecedor.Click += new System.EventHandler(this.bb_fornecedor_Click);
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label17.Location = new System.Drawing.Point(11, 12);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(64, 13);
            label17.TabIndex = 129;
            label17.Text = "Fornecedor:";
            // 
            // cd_fornecedor
            // 
            this.cd_fornecedor.BackColor = System.Drawing.Color.White;
            this.cd_fornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_fornecedor.Location = new System.Drawing.Point(81, 9);
            this.cd_fornecedor.Name = "cd_fornecedor";
            this.cd_fornecedor.NM_Alias = "";
            this.cd_fornecedor.NM_Campo = "cd_clifor";
            this.cd_fornecedor.NM_CampoBusca = "cd_clifor";
            this.cd_fornecedor.NM_Param = "@P_CD_EMPRESA";
            this.cd_fornecedor.QTD_Zero = 0;
            this.cd_fornecedor.Size = new System.Drawing.Size(73, 20);
            this.cd_fornecedor.ST_AutoInc = false;
            this.cd_fornecedor.ST_DisableAuto = false;
            this.cd_fornecedor.ST_Float = false;
            this.cd_fornecedor.ST_Gravar = true;
            this.cd_fornecedor.ST_Int = true;
            this.cd_fornecedor.ST_LimpaCampo = true;
            this.cd_fornecedor.ST_NotNull = true;
            this.cd_fornecedor.ST_PrimaryKey = false;
            this.cd_fornecedor.TabIndex = 127;
            this.cd_fornecedor.TextOld = null;
            this.cd_fornecedor.Leave += new System.EventHandler(this.cd_fornecedor_Leave);
            // 
            // cbCotacao
            // 
            this.cbCotacao.AutoSize = true;
            this.cbCotacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCotacao.Location = new System.Drawing.Point(513, 2);
            this.cbCotacao.Name = "cbCotacao";
            this.cbCotacao.NM_Alias = "";
            this.cbCotacao.NM_Campo = "";
            this.cbCotacao.NM_Param = "";
            this.cbCotacao.Size = new System.Drawing.Size(282, 17);
            this.cbCotacao.ST_Gravar = false;
            this.cbCotacao.ST_LimparCampo = true;
            this.cbCotacao.ST_NotNull = false;
            this.cbCotacao.TabIndex = 130;
            this.cbCotacao.Text = "BUSCAR FORNECEDORES COM COTAÇÕES";
            this.cbCotacao.UseVisualStyleBackColor = true;
            this.cbCotacao.Vl_False = "";
            this.cbCotacao.Vl_True = "";
            // 
            // cbCompras
            // 
            this.cbCompras.AutoSize = true;
            this.cbCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCompras.Location = new System.Drawing.Point(513, 19);
            this.cbCompras.Name = "cbCompras";
            this.cbCompras.NM_Alias = "";
            this.cbCompras.NM_Campo = "";
            this.cbCompras.NM_Param = "";
            this.cbCompras.Size = new System.Drawing.Size(276, 17);
            this.cbCompras.ST_Gravar = false;
            this.cbCompras.ST_LimparCampo = true;
            this.cbCompras.ST_NotNull = false;
            this.cbCompras.TabIndex = 131;
            this.cbCompras.Text = "BUSCAR FORNECEDORES COM COMPRAS";
            this.cbCompras.UseVisualStyleBackColor = true;
            this.cbCompras.Vl_False = "";
            this.cbCompras.Vl_True = "";
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
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(334, 10);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 133;
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // cd_produtoLabel
            // 
            cd_produtoLabel.AutoSize = true;
            cd_produtoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_produtoLabel.Location = new System.Drawing.Point(200, 13);
            cd_produtoLabel.Name = "cd_produtoLabel";
            cd_produtoLabel.Size = new System.Drawing.Size(47, 13);
            cd_produtoLabel.TabIndex = 134;
            cd_produtoLabel.Text = "Produto:";
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Location = new System.Drawing.Point(253, 10);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_PRODUTO";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(80, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 132;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // TFRequisicaoFornec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 581);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFRequisicaoFornec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requisição por Fornecedores";
            this.Load += new System.EventHandler(this.TFRequisicaoFornec_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRequisicaoFornec_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gClifor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClifor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnClifor)).EndInit();
            this.bnClifor.ResumeLayout(false);
            this.bnClifor.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        public System.Windows.Forms.ToolStripButton BB_Imprimir;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingSource bsClifor;
        private Componentes.DataGridDefault gClifor;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCd_clifor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bnClifor;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.Button bb_fornecedor;
        private Componentes.EditDefault cd_fornecedor;
        private Componentes.CheckBoxDefault cbCompras;
        private Componentes.CheckBoxDefault cbCotacao;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault cd_produto;
    }
}