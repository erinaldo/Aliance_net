namespace PostoCombustivel.Cadastros
{
    partial class TFCadProgCombustivel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadProgCombustivel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gProg = new Componentes.DataGridDefault(this.components);
            this.bsProgCombustivel = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.ds_prod = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cd_prod = new Componentes.EditDefault(this.components);
            this.pc_desconto = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tp_desconto = new Componentes.ComboBoxDefault(this.components);
            this.st_descvlunit = new Componentes.CheckBoxDefault(this.components);
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcdescontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_descvlunitbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gProg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProgCombustivel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desconto)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.st_descvlunit);
            this.pDados.Controls.Add(this.tp_desconto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_prod);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.cd_prod);
            this.pDados.Controls.Add(this.pc_desconto);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Size = new System.Drawing.Size(659, 82);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gProg);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gProg, 0);
            // 
            // gProg
            // 
            this.gProg.AllowUserToAddRows = false;
            this.gProg.AllowUserToDeleteRows = false;
            this.gProg.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gProg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gProg.AutoGenerateColumns = false;
            this.gProg.BackgroundColor = System.Drawing.Color.LightGray;
            this.gProg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gProg.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gProg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gProg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.Tipo_desconto,
            this.pcdescontoDataGridViewTextBoxColumn,
            this.St_descvlunitbool});
            this.gProg.DataSource = this.bsProgCombustivel;
            this.gProg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gProg.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gProg.Location = new System.Drawing.Point(0, 82);
            this.gProg.Name = "gProg";
            this.gProg.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProg.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gProg.RowHeadersWidth = 23;
            this.gProg.Size = new System.Drawing.Size(659, 253);
            this.gProg.TabIndex = 1;
            this.gProg.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gProg_ColumnHeaderMouseClick);
            // 
            // bsProgCombustivel
            // 
            this.bsProgCombustivel.DataSource = typeof(CamadaDados.PostoCombustivel.Cadastros.TList_ProgCombustivel);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsProgCombustivel;
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
            // ds_prod
            // 
            this.ds_prod.BackColor = System.Drawing.SystemColors.Window;
            this.ds_prod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_prod.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgCombustivel, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_prod.Enabled = false;
            this.ds_prod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_prod.Location = new System.Drawing.Point(188, 29);
            this.ds_prod.Name = "ds_prod";
            this.ds_prod.NM_Alias = "";
            this.ds_prod.NM_Campo = "ds_produto";
            this.ds_prod.NM_CampoBusca = "ds_produto";
            this.ds_prod.NM_Param = "@P_CD_EMPRESA";
            this.ds_prod.QTD_Zero = 0;
            this.ds_prod.Size = new System.Drawing.Size(343, 20);
            this.ds_prod.ST_AutoInc = false;
            this.ds_prod.ST_DisableAuto = false;
            this.ds_prod.ST_Float = false;
            this.ds_prod.ST_Gravar = false;
            this.ds_prod.ST_Int = true;
            this.ds_prod.ST_LimpaCampo = true;
            this.ds_prod.ST_NotNull = false;
            this.ds_prod.ST_PrimaryKey = false;
            this.ds_prod.TabIndex = 65;
            // 
            // bb_produto
            // 
            this.bb_produto.Enabled = false;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(154, 29);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 3;
            this.bb_produto.UseVisualStyleBackColor = true;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(4, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Combustivel:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_prod
            // 
            this.cd_prod.BackColor = System.Drawing.SystemColors.Window;
            this.cd_prod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_prod.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgCombustivel, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_prod.Enabled = false;
            this.cd_prod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_prod.Location = new System.Drawing.Point(77, 29);
            this.cd_prod.Name = "cd_prod";
            this.cd_prod.NM_Alias = "";
            this.cd_prod.NM_Campo = "cd_produto";
            this.cd_prod.NM_CampoBusca = "cd_produto";
            this.cd_prod.NM_Param = "@P_CD_EMPRESA";
            this.cd_prod.QTD_Zero = 0;
            this.cd_prod.Size = new System.Drawing.Size(75, 20);
            this.cd_prod.ST_AutoInc = false;
            this.cd_prod.ST_DisableAuto = false;
            this.cd_prod.ST_Float = false;
            this.cd_prod.ST_Gravar = true;
            this.cd_prod.ST_Int = true;
            this.cd_prod.ST_LimpaCampo = true;
            this.cd_prod.ST_NotNull = true;
            this.cd_prod.ST_PrimaryKey = true;
            this.cd_prod.TabIndex = 2;
            this.cd_prod.Leave += new System.EventHandler(this.cd_prod_Leave);
            // 
            // pc_desconto
            // 
            this.pc_desconto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProgCombustivel, "Pc_desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_desconto.DecimalPlaces = 2;
            this.pc_desconto.Enabled = false;
            this.pc_desconto.Location = new System.Drawing.Point(266, 55);
            this.pc_desconto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_desconto.Name = "pc_desconto";
            this.pc_desconto.NM_Alias = "";
            this.pc_desconto.NM_Campo = "";
            this.pc_desconto.NM_Param = "";
            this.pc_desconto.Operador = "";
            this.pc_desconto.Size = new System.Drawing.Size(86, 20);
            this.pc_desconto.ST_AutoInc = false;
            this.pc_desconto.ST_DisableAuto = false;
            this.pc_desconto.ST_Gravar = true;
            this.pc_desconto.ST_LimparCampo = true;
            this.pc_desconto.ST_NotNull = true;
            this.pc_desconto.ST_PrimaryKey = false;
            this.pc_desconto.TabIndex = 5;
            this.pc_desconto.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(204, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "Desconto:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgCombustivel, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_empresa.Location = new System.Drawing.Point(188, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_CD_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(343, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = true;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 62;
            // 
            // bb_empresa
            // 
            this.bb_empresa.Enabled = false;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(154, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(20, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Empresa:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgCombustivel, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(77, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "CD_Empresa";
            this.cd_empresa.NM_CampoBusca = "CD_Empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(75, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = true;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Tipo Desc.:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_desconto
            // 
            this.tp_desconto.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsProgCombustivel, "Tp_desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_desconto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_desconto.Enabled = false;
            this.tp_desconto.FormattingEnabled = true;
            this.tp_desconto.Location = new System.Drawing.Point(77, 55);
            this.tp_desconto.Name = "tp_desconto";
            this.tp_desconto.NM_Alias = "";
            this.tp_desconto.NM_Campo = "";
            this.tp_desconto.NM_Param = "";
            this.tp_desconto.Size = new System.Drawing.Size(121, 21);
            this.tp_desconto.ST_Gravar = true;
            this.tp_desconto.ST_LimparCampo = true;
            this.tp_desconto.ST_NotNull = true;
            this.tp_desconto.TabIndex = 4;
            // 
            // st_descvlunit
            // 
            this.st_descvlunit.AutoSize = true;
            this.st_descvlunit.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsProgCombustivel, "St_descvlunitbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_descvlunit.Enabled = false;
            this.st_descvlunit.Location = new System.Drawing.Point(358, 57);
            this.st_descvlunit.Name = "st_descvlunit";
            this.st_descvlunit.NM_Alias = "";
            this.st_descvlunit.NM_Campo = "";
            this.st_descvlunit.NM_Param = "";
            this.st_descvlunit.Size = new System.Drawing.Size(173, 17);
            this.st_descvlunit.ST_Gravar = true;
            this.st_descvlunit.ST_LimparCampo = true;
            this.st_descvlunit.ST_NotNull = false;
            this.st_descvlunit.TabIndex = 6;
            this.st_descvlunit.Text = "Aplicar Desconto Valor Unitario";
            this.st_descvlunit.UseVisualStyleBackColor = true;
            this.st_descvlunit.Vl_False = "";
            this.st_descvlunit.Vl_True = "";
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
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd. Combustivel";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 99;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Combustivel";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 89;
            // 
            // Tipo_desconto
            // 
            this.Tipo_desconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_desconto.DataPropertyName = "Tipo_desconto";
            this.Tipo_desconto.HeaderText = "Tipo Desconto";
            this.Tipo_desconto.Name = "Tipo_desconto";
            this.Tipo_desconto.ReadOnly = true;
            this.Tipo_desconto.Width = 94;
            // 
            // pcdescontoDataGridViewTextBoxColumn
            // 
            this.pcdescontoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pcdescontoDataGridViewTextBoxColumn.DataPropertyName = "Pc_desconto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.pcdescontoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.pcdescontoDataGridViewTextBoxColumn.HeaderText = "Desconto";
            this.pcdescontoDataGridViewTextBoxColumn.Name = "pcdescontoDataGridViewTextBoxColumn";
            this.pcdescontoDataGridViewTextBoxColumn.ReadOnly = true;
            this.pcdescontoDataGridViewTextBoxColumn.Width = 78;
            // 
            // St_descvlunitbool
            // 
            this.St_descvlunitbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_descvlunitbool.DataPropertyName = "St_descvlunitbool";
            this.St_descvlunitbool.HeaderText = "Aplicar Desconto Valor Unitario";
            this.St_descvlunitbool.Name = "St_descvlunitbool";
            this.St_descvlunitbool.ReadOnly = true;
            this.St_descvlunitbool.Width = 112;
            // 
            // TFCadProgCombustivel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadProgCombustivel";
            this.Text = "Cadastro Programação Combustivel";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gProg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProgCombustivel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desconto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gProg;
        private System.Windows.Forms.BindingSource bsProgCombustivel;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault ds_prod;
        private System.Windows.Forms.Button bb_produto;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault cd_prod;
        private Componentes.EditFloat pc_desconto;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault cd_empresa;
        private Componentes.CheckBoxDefault st_descvlunit;
        private Componentes.ComboBoxDefault tp_desconto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcdescontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_descvlunitbool;
    }
}
