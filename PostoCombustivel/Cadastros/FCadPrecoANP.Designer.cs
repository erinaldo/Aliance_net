namespace PostoCombustivel.Cadastros
{
    partial class TFCadPrecoANP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadPrecoANP));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gPrecoANP = new Componentes.DataGridDefault(this.components);
            this.bsPrecoANP = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_preco = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bb_combustivel = new System.Windows.Forms.Button();
            this.cd_combustivel = new Componentes.EditDefault(this.components);
            this.ds_combustivel = new Componentes.EditDefault(this.components);
            this.vl_preco = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dt_preco = new Componentes.EditData(this.components);
            this.idprecostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcombustivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscombustivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlprecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtprecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPrecoANP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPrecoANP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_preco)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.dt_preco);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.vl_preco);
            this.pDados.Controls.Add(this.ds_combustivel);
            this.pDados.Controls.Add(this.bb_combustivel);
            this.pDados.Controls.Add(this.cd_combustivel);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.id_preco);
            this.pDados.Size = new System.Drawing.Size(659, 81);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gPrecoANP);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gPrecoANP, 0);
            // 
            // gPrecoANP
            // 
            this.gPrecoANP.AllowUserToAddRows = false;
            this.gPrecoANP.AllowUserToDeleteRows = false;
            this.gPrecoANP.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPrecoANP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gPrecoANP.AutoGenerateColumns = false;
            this.gPrecoANP.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPrecoANP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPrecoANP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPrecoANP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gPrecoANP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPrecoANP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idprecostrDataGridViewTextBoxColumn,
            this.cdcombustivelDataGridViewTextBoxColumn,
            this.dscombustivelDataGridViewTextBoxColumn,
            this.vlprecoDataGridViewTextBoxColumn,
            this.dtprecoDataGridViewTextBoxColumn});
            this.gPrecoANP.DataSource = this.bsPrecoANP;
            this.gPrecoANP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gPrecoANP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPrecoANP.Location = new System.Drawing.Point(0, 81);
            this.gPrecoANP.Name = "gPrecoANP";
            this.gPrecoANP.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPrecoANP.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gPrecoANP.RowHeadersWidth = 23;
            this.gPrecoANP.Size = new System.Drawing.Size(659, 254);
            this.gPrecoANP.TabIndex = 1;
            this.gPrecoANP.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gPrecoANP_ColumnHeaderMouseClick);
            // 
            // bsPrecoANP
            // 
            this.bsPrecoANP.DataSource = typeof(CamadaDados.PostoCombustivel.Cadastros.TList_PrecoANP);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsPrecoANP;
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
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
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
            // id_preco
            // 
            this.id_preco.BackColor = System.Drawing.SystemColors.Window;
            this.id_preco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_preco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrecoANP, "Id_precostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_preco.Enabled = false;
            this.id_preco.Location = new System.Drawing.Point(77, 3);
            this.id_preco.Name = "id_preco";
            this.id_preco.NM_Alias = "";
            this.id_preco.NM_Campo = "id_preco";
            this.id_preco.NM_CampoBusca = "id_preco";
            this.id_preco.NM_Param = "@P_ID_PRECO";
            this.id_preco.QTD_Zero = 0;
            this.id_preco.Size = new System.Drawing.Size(81, 20);
            this.id_preco.ST_AutoInc = false;
            this.id_preco.ST_DisableAuto = true;
            this.id_preco.ST_Float = false;
            this.id_preco.ST_Gravar = true;
            this.id_preco.ST_Int = true;
            this.id_preco.ST_LimpaCampo = true;
            this.id_preco.ST_NotNull = true;
            this.id_preco.ST_PrimaryKey = true;
            this.id_preco.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id. Preço:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Combustivel:";
            // 
            // bb_combustivel
            // 
            this.bb_combustivel.BackColor = System.Drawing.SystemColors.Control;
            this.bb_combustivel.Enabled = false;
            this.bb_combustivel.Image = ((System.Drawing.Image)(resources.GetObject("bb_combustivel.Image")));
            this.bb_combustivel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_combustivel.Location = new System.Drawing.Point(160, 29);
            this.bb_combustivel.Name = "bb_combustivel";
            this.bb_combustivel.Size = new System.Drawing.Size(28, 19);
            this.bb_combustivel.TabIndex = 2;
            this.bb_combustivel.UseVisualStyleBackColor = false;
            this.bb_combustivel.Click += new System.EventHandler(this.bb_combustivel_Click);
            // 
            // cd_combustivel
            // 
            this.cd_combustivel.BackColor = System.Drawing.Color.White;
            this.cd_combustivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_combustivel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrecoANP, "Cd_combustivel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_combustivel.Enabled = false;
            this.cd_combustivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_combustivel.Location = new System.Drawing.Point(77, 29);
            this.cd_combustivel.Name = "cd_combustivel";
            this.cd_combustivel.NM_Alias = "";
            this.cd_combustivel.NM_Campo = "cd_produto";
            this.cd_combustivel.NM_CampoBusca = "cd_produto";
            this.cd_combustivel.NM_Param = "@P_CD_EMPRESA";
            this.cd_combustivel.QTD_Zero = 0;
            this.cd_combustivel.Size = new System.Drawing.Size(81, 20);
            this.cd_combustivel.ST_AutoInc = false;
            this.cd_combustivel.ST_DisableAuto = false;
            this.cd_combustivel.ST_Float = false;
            this.cd_combustivel.ST_Gravar = true;
            this.cd_combustivel.ST_Int = false;
            this.cd_combustivel.ST_LimpaCampo = true;
            this.cd_combustivel.ST_NotNull = true;
            this.cd_combustivel.ST_PrimaryKey = true;
            this.cd_combustivel.TabIndex = 1;
            this.cd_combustivel.Leave += new System.EventHandler(this.cd_combustivel_Leave);
            // 
            // ds_combustivel
            // 
            this.ds_combustivel.BackColor = System.Drawing.SystemColors.Window;
            this.ds_combustivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_combustivel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrecoANP, "Ds_combustivel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_combustivel.Enabled = false;
            this.ds_combustivel.Location = new System.Drawing.Point(194, 29);
            this.ds_combustivel.Name = "ds_combustivel";
            this.ds_combustivel.NM_Alias = "";
            this.ds_combustivel.NM_Campo = "ds_produto";
            this.ds_combustivel.NM_CampoBusca = "ds_produto";
            this.ds_combustivel.NM_Param = "@P_DS_PRODUTO";
            this.ds_combustivel.QTD_Zero = 0;
            this.ds_combustivel.Size = new System.Drawing.Size(457, 20);
            this.ds_combustivel.ST_AutoInc = false;
            this.ds_combustivel.ST_DisableAuto = false;
            this.ds_combustivel.ST_Float = false;
            this.ds_combustivel.ST_Gravar = false;
            this.ds_combustivel.ST_Int = false;
            this.ds_combustivel.ST_LimpaCampo = true;
            this.ds_combustivel.ST_NotNull = false;
            this.ds_combustivel.ST_PrimaryKey = false;
            this.ds_combustivel.TabIndex = 126;
            // 
            // vl_preco
            // 
            this.vl_preco.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPrecoANP, "Vl_preco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_preco.DecimalPlaces = 3;
            this.vl_preco.Enabled = false;
            this.vl_preco.Location = new System.Drawing.Point(77, 55);
            this.vl_preco.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_preco.Name = "vl_preco";
            this.vl_preco.NM_Alias = "";
            this.vl_preco.NM_Campo = "";
            this.vl_preco.NM_Param = "";
            this.vl_preco.Operador = "";
            this.vl_preco.Size = new System.Drawing.Size(120, 20);
            this.vl_preco.ST_AutoInc = false;
            this.vl_preco.ST_DisableAuto = false;
            this.vl_preco.ST_Gravar = true;
            this.vl_preco.ST_LimparCampo = true;
            this.vl_preco.ST_NotNull = true;
            this.vl_preco.ST_PrimaryKey = false;
            this.vl_preco.TabIndex = 3;
            this.vl_preco.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "Preço ANP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 129;
            this.label4.Text = "Dt. Preço:";
            // 
            // dt_preco
            // 
            this.dt_preco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrecoANP, "Dt_precostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_preco.Enabled = false;
            this.dt_preco.Location = new System.Drawing.Point(264, 55);
            this.dt_preco.Mask = "00/00/0000";
            this.dt_preco.Name = "dt_preco";
            this.dt_preco.NM_Alias = "";
            this.dt_preco.NM_Campo = "";
            this.dt_preco.NM_CampoBusca = "";
            this.dt_preco.NM_Param = "";
            this.dt_preco.Operador = "";
            this.dt_preco.Size = new System.Drawing.Size(75, 20);
            this.dt_preco.ST_Gravar = true;
            this.dt_preco.ST_LimpaCampo = true;
            this.dt_preco.ST_NotNull = true;
            this.dt_preco.ST_PrimaryKey = false;
            this.dt_preco.TabIndex = 4;
            // 
            // idprecostrDataGridViewTextBoxColumn
            // 
            this.idprecostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idprecostrDataGridViewTextBoxColumn.DataPropertyName = "Id_precostr";
            this.idprecostrDataGridViewTextBoxColumn.HeaderText = "Id. Preço";
            this.idprecostrDataGridViewTextBoxColumn.Name = "idprecostrDataGridViewTextBoxColumn";
            this.idprecostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idprecostrDataGridViewTextBoxColumn.Width = 75;
            // 
            // cdcombustivelDataGridViewTextBoxColumn
            // 
            this.cdcombustivelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcombustivelDataGridViewTextBoxColumn.DataPropertyName = "Cd_combustivel";
            this.cdcombustivelDataGridViewTextBoxColumn.HeaderText = "Cd. Combustivel";
            this.cdcombustivelDataGridViewTextBoxColumn.Name = "cdcombustivelDataGridViewTextBoxColumn";
            this.cdcombustivelDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcombustivelDataGridViewTextBoxColumn.Width = 99;
            // 
            // dscombustivelDataGridViewTextBoxColumn
            // 
            this.dscombustivelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscombustivelDataGridViewTextBoxColumn.DataPropertyName = "Ds_combustivel";
            this.dscombustivelDataGridViewTextBoxColumn.HeaderText = "Combustivel";
            this.dscombustivelDataGridViewTextBoxColumn.Name = "dscombustivelDataGridViewTextBoxColumn";
            this.dscombustivelDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscombustivelDataGridViewTextBoxColumn.Width = 89;
            // 
            // vlprecoDataGridViewTextBoxColumn
            // 
            this.vlprecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlprecoDataGridViewTextBoxColumn.DataPropertyName = "Vl_preco";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = "0";
            this.vlprecoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.vlprecoDataGridViewTextBoxColumn.HeaderText = "Preço ANP";
            this.vlprecoDataGridViewTextBoxColumn.Name = "vlprecoDataGridViewTextBoxColumn";
            this.vlprecoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlprecoDataGridViewTextBoxColumn.Width = 79;
            // 
            // dtprecoDataGridViewTextBoxColumn
            // 
            this.dtprecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtprecoDataGridViewTextBoxColumn.DataPropertyName = "Dt_preco";
            this.dtprecoDataGridViewTextBoxColumn.HeaderText = "Dt. Preço";
            this.dtprecoDataGridViewTextBoxColumn.Name = "dtprecoDataGridViewTextBoxColumn";
            this.dtprecoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtprecoDataGridViewTextBoxColumn.Width = 71;
            // 
            // TFCadPrecoANP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadPrecoANP";
            this.Text = "Cadastro Preço ANP";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPrecoANP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPrecoANP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_preco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gPrecoANP;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.BindingSource bsPrecoANP;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_preco;
        private Componentes.EditData dt_preco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat vl_preco;
        private Componentes.EditDefault ds_combustivel;
        private System.Windows.Forms.Button bb_combustivel;
        private Componentes.EditDefault cd_combustivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprecostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcombustivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscombustivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlprecoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtprecoDataGridViewTextBoxColumn;
    }
}
