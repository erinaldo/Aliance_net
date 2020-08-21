namespace Compra.Cadastros
{
    partial class TFCadUsuarioCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadUsuarioCompra));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_clifor_cmp = new Componentes.EditDefault(this.components);
            this.bs_userCompra = new System.Windows.Forms.BindingSource(this.components);
            this.login = new Componentes.EditDefault(this.components);
            this.bb_Clifor = new System.Windows.Forms.Button();
            this.ds_clifor_cmp = new Componentes.EditDefault(this.components);
            this.bb_login = new System.Windows.Forms.Button();
            this.ds_login = new Componentes.EditDefault(this.components);
            this.gPesquisa = new Componentes.DataGridDefault(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforcmpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strequisitarboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.staprovarboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stcomprarboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BN_UsuarioCompra = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.tp_usuario = new Componentes.RadioGroup(this.components);
            this.pFlag = new Componentes.PanelDados(this.components);
            this.st_comprar = new Componentes.CheckBoxDefault(this.components);
            this.st_aprovar = new Componentes.CheckBoxDefault(this.components);
            this.st_requisitar = new Componentes.CheckBoxDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_userCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPesquisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_UsuarioCompra)).BeginInit();
            this.BN_UsuarioCompra.SuspendLayout();
            this.tp_usuario.SuspendLayout();
            this.pFlag.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BackColor = System.Drawing.SystemColors.Control;
            this.pDados.Controls.Add(this.tp_usuario);
            this.pDados.Controls.Add(this.ds_login);
            this.pDados.Controls.Add(this.bb_login);
            this.pDados.Controls.Add(this.ds_clifor_cmp);
            this.pDados.Controls.Add(this.bb_Clifor);
            this.pDados.Controls.Add(this.login);
            this.pDados.Controls.Add(this.cd_clifor_cmp);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gPesquisa);
            this.tpPadrao.Controls.Add(this.BN_UsuarioCompra);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_UsuarioCompra, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gPesquisa, 0);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cd_clifor_cmp
            // 
            this.cd_clifor_cmp.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor_cmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor_cmp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_userCompra, "Cd_clifor_cmp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_clifor_cmp, "cd_clifor_cmp");
            this.cd_clifor_cmp.Name = "cd_clifor_cmp";
            this.cd_clifor_cmp.NM_Alias = "a";
            this.cd_clifor_cmp.NM_Campo = "cd_clifor_cmp";
            this.cd_clifor_cmp.NM_CampoBusca = "cd_clifor";
            this.cd_clifor_cmp.NM_Param = "@P_CD_CLIFOR_CMP";
            this.cd_clifor_cmp.QTD_Zero = 0;
            this.cd_clifor_cmp.ST_AutoInc = false;
            this.cd_clifor_cmp.ST_DisableAuto = false;
            this.cd_clifor_cmp.ST_Float = false;
            this.cd_clifor_cmp.ST_Gravar = true;
            this.cd_clifor_cmp.ST_Int = false;
            this.cd_clifor_cmp.ST_LimpaCampo = true;
            this.cd_clifor_cmp.ST_NotNull = true;
            this.cd_clifor_cmp.ST_PrimaryKey = true;
            this.cd_clifor_cmp.Leave += new System.EventHandler(this.cd_clifor_cmp_Leave);
            // 
            // bs_userCompra
            // 
            this.bs_userCompra.DataSource = typeof(CamadaDados.Compra.TList_CadUsuarioCompra);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.SystemColors.Window;
            this.login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.login.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_userCompra, "Login", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.login, "login");
            this.login.Name = "login";
            this.login.NM_Alias = "a";
            this.login.NM_Campo = "login";
            this.login.NM_CampoBusca = "login";
            this.login.NM_Param = "@P_LOGIN";
            this.login.QTD_Zero = 0;
            this.login.ST_AutoInc = false;
            this.login.ST_DisableAuto = false;
            this.login.ST_Float = false;
            this.login.ST_Gravar = true;
            this.login.ST_Int = false;
            this.login.ST_LimpaCampo = true;
            this.login.ST_NotNull = true;
            this.login.ST_PrimaryKey = false;
            this.login.Leave += new System.EventHandler(this.login_Leave);
            // 
            // bb_Clifor
            // 
            this.bb_Clifor.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_Clifor, "bb_Clifor");
            this.bb_Clifor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_Clifor.Name = "bb_Clifor";
            this.bb_Clifor.UseVisualStyleBackColor = false;
            this.bb_Clifor.Click += new System.EventHandler(this.bb_Clifor_Click);
            // 
            // ds_clifor_cmp
            // 
            this.ds_clifor_cmp.BackColor = System.Drawing.SystemColors.Window;
            this.ds_clifor_cmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_clifor_cmp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_userCompra, "Nm_clifor_cmp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_clifor_cmp, "ds_clifor_cmp");
            this.ds_clifor_cmp.Name = "ds_clifor_cmp";
            this.ds_clifor_cmp.NM_Alias = "c";
            this.ds_clifor_cmp.NM_Campo = "nm_clifor";
            this.ds_clifor_cmp.NM_CampoBusca = "nm_clifor";
            this.ds_clifor_cmp.NM_Param = "";
            this.ds_clifor_cmp.QTD_Zero = 0;
            this.ds_clifor_cmp.ST_AutoInc = false;
            this.ds_clifor_cmp.ST_DisableAuto = false;
            this.ds_clifor_cmp.ST_Float = false;
            this.ds_clifor_cmp.ST_Gravar = false;
            this.ds_clifor_cmp.ST_Int = false;
            this.ds_clifor_cmp.ST_LimpaCampo = true;
            this.ds_clifor_cmp.ST_NotNull = false;
            this.ds_clifor_cmp.ST_PrimaryKey = false;
            // 
            // bb_login
            // 
            this.bb_login.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_login, "bb_login");
            this.bb_login.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_login.Name = "bb_login";
            this.bb_login.UseVisualStyleBackColor = false;
            this.bb_login.Click += new System.EventHandler(this.bb_login_Click);
            // 
            // ds_login
            // 
            this.ds_login.BackColor = System.Drawing.SystemColors.Window;
            this.ds_login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_login.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_userCompra, "Nome_usuario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_login, "ds_login");
            this.ds_login.Name = "ds_login";
            this.ds_login.NM_Alias = "";
            this.ds_login.NM_Campo = "nome_usuario";
            this.ds_login.NM_CampoBusca = "nome_usuario";
            this.ds_login.NM_Param = "@P_NOME_USUARIO";
            this.ds_login.QTD_Zero = 0;
            this.ds_login.ST_AutoInc = false;
            this.ds_login.ST_DisableAuto = false;
            this.ds_login.ST_Float = false;
            this.ds_login.ST_Gravar = false;
            this.ds_login.ST_Int = false;
            this.ds_login.ST_LimpaCampo = true;
            this.ds_login.ST_NotNull = false;
            this.ds_login.ST_PrimaryKey = false;
            // 
            // gPesquisa
            // 
            this.gPesquisa.AllowUserToAddRows = false;
            this.gPesquisa.AllowUserToDeleteRows = false;
            this.gPesquisa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPesquisa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gPesquisa.AutoGenerateColumns = false;
            this.gPesquisa.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPesquisa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPesquisa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.nmcliforcmpDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.strequisitarboolDataGridViewCheckBoxColumn,
            this.staprovarboolDataGridViewCheckBoxColumn,
            this.stcomprarboolDataGridViewCheckBoxColumn});
            this.gPesquisa.DataSource = this.bs_userCompra;
            resources.ApplyResources(this.gPesquisa, "gPesquisa");
            this.gPesquisa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPesquisa.Name = "gPesquisa";
            this.gPesquisa.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPesquisa.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gPesquisa.TabStop = false;
            this.gPesquisa.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gPesquisa_ColumnHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cd_clifor_cmp";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nmcliforcmpDataGridViewTextBoxColumn
            // 
            this.nmcliforcmpDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforcmpDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor_cmp";
            resources.ApplyResources(this.nmcliforcmpDataGridViewTextBoxColumn, "nmcliforcmpDataGridViewTextBoxColumn");
            this.nmcliforcmpDataGridViewTextBoxColumn.Name = "nmcliforcmpDataGridViewTextBoxColumn";
            this.nmcliforcmpDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loginDataGridViewTextBoxColumn
            // 
            this.loginDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.loginDataGridViewTextBoxColumn.DataPropertyName = "Login";
            resources.ApplyResources(this.loginDataGridViewTextBoxColumn, "loginDataGridViewTextBoxColumn");
            this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
            this.loginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // strequisitarboolDataGridViewCheckBoxColumn
            // 
            this.strequisitarboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.strequisitarboolDataGridViewCheckBoxColumn.DataPropertyName = "St_requisitarbool";
            resources.ApplyResources(this.strequisitarboolDataGridViewCheckBoxColumn, "strequisitarboolDataGridViewCheckBoxColumn");
            this.strequisitarboolDataGridViewCheckBoxColumn.Name = "strequisitarboolDataGridViewCheckBoxColumn";
            this.strequisitarboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // staprovarboolDataGridViewCheckBoxColumn
            // 
            this.staprovarboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.staprovarboolDataGridViewCheckBoxColumn.DataPropertyName = "St_aprovarbool";
            resources.ApplyResources(this.staprovarboolDataGridViewCheckBoxColumn, "staprovarboolDataGridViewCheckBoxColumn");
            this.staprovarboolDataGridViewCheckBoxColumn.Name = "staprovarboolDataGridViewCheckBoxColumn";
            this.staprovarboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // stcomprarboolDataGridViewCheckBoxColumn
            // 
            this.stcomprarboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stcomprarboolDataGridViewCheckBoxColumn.DataPropertyName = "St_comprarbool";
            resources.ApplyResources(this.stcomprarboolDataGridViewCheckBoxColumn, "stcomprarboolDataGridViewCheckBoxColumn");
            this.stcomprarboolDataGridViewCheckBoxColumn.Name = "stcomprarboolDataGridViewCheckBoxColumn";
            this.stcomprarboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // BN_UsuarioCompra
            // 
            this.BN_UsuarioCompra.AddNewItem = null;
            this.BN_UsuarioCompra.BindingSource = this.bs_userCompra;
            this.BN_UsuarioCompra.CountItem = this.bindingNavigatorCountItem;
            this.BN_UsuarioCompra.DeleteItem = null;
            resources.ApplyResources(this.BN_UsuarioCompra, "BN_UsuarioCompra");
            this.BN_UsuarioCompra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_UsuarioCompra.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_UsuarioCompra.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_UsuarioCompra.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_UsuarioCompra.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_UsuarioCompra.Name = "BN_UsuarioCompra";
            this.BN_UsuarioCompra.PositionItem = this.bindingNavigatorPositionItem;
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
            // tp_usuario
            // 
            this.tp_usuario.Controls.Add(this.pFlag);
            resources.ApplyResources(this.tp_usuario, "tp_usuario");
            this.tp_usuario.Name = "tp_usuario";
            this.tp_usuario.NM_Alias = "";
            this.tp_usuario.NM_Campo = "";
            this.tp_usuario.NM_Param = "";
            this.tp_usuario.NM_Valor = "";
            this.tp_usuario.ST_Gravar = false;
            this.tp_usuario.ST_NotNull = false;
            this.tp_usuario.TabStop = false;
            // 
            // pFlag
            // 
            this.pFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pFlag.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pFlag.Controls.Add(this.st_comprar);
            this.pFlag.Controls.Add(this.st_aprovar);
            this.pFlag.Controls.Add(this.st_requisitar);
            resources.ApplyResources(this.pFlag, "pFlag");
            this.pFlag.Name = "pFlag";
            this.pFlag.NM_ProcDeletar = "";
            this.pFlag.NM_ProcGravar = "";
            // 
            // st_comprar
            // 
            resources.ApplyResources(this.st_comprar, "st_comprar");
            this.st_comprar.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_userCompra, "St_comprarbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_comprar.Name = "st_comprar";
            this.st_comprar.NM_Alias = "";
            this.st_comprar.NM_Campo = "";
            this.st_comprar.NM_Param = "";
            this.st_comprar.ST_Gravar = true;
            this.st_comprar.ST_LimparCampo = true;
            this.st_comprar.ST_NotNull = false;
            this.st_comprar.UseVisualStyleBackColor = true;
            this.st_comprar.Vl_False = "";
            this.st_comprar.Vl_True = "";
            // 
            // st_aprovar
            // 
            resources.ApplyResources(this.st_aprovar, "st_aprovar");
            this.st_aprovar.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_userCompra, "St_aprovarbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_aprovar.Name = "st_aprovar";
            this.st_aprovar.NM_Alias = "";
            this.st_aprovar.NM_Campo = "";
            this.st_aprovar.NM_Param = "";
            this.st_aprovar.ST_Gravar = true;
            this.st_aprovar.ST_LimparCampo = true;
            this.st_aprovar.ST_NotNull = false;
            this.st_aprovar.UseVisualStyleBackColor = true;
            this.st_aprovar.Vl_False = "";
            this.st_aprovar.Vl_True = "";
            // 
            // st_requisitar
            // 
            resources.ApplyResources(this.st_requisitar, "st_requisitar");
            this.st_requisitar.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_userCompra, "St_requisitarbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_requisitar.Name = "st_requisitar";
            this.st_requisitar.NM_Alias = "";
            this.st_requisitar.NM_Campo = "";
            this.st_requisitar.NM_Param = "";
            this.st_requisitar.ST_Gravar = true;
            this.st_requisitar.ST_LimparCampo = true;
            this.st_requisitar.ST_NotNull = false;
            this.st_requisitar.UseVisualStyleBackColor = true;
            this.st_requisitar.Vl_False = "";
            this.st_requisitar.Vl_True = "";
            // 
            // TFCadUsuarioCompra
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadUsuarioCompra";
            this.Load += new System.EventHandler(this.TFCadUsuarioCompra_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadUsuarioCompra_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_userCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPesquisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_UsuarioCompra)).EndInit();
            this.BN_UsuarioCompra.ResumeLayout(false);
            this.BN_UsuarioCompra.PerformLayout();
            this.tp_usuario.ResumeLayout(false);
            this.pFlag.ResumeLayout(false);
            this.pFlag.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault login;
        private Componentes.EditDefault cd_clifor_cmp;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_login;
        public System.Windows.Forms.Button bb_login;
        private Componentes.EditDefault ds_clifor_cmp;
        public System.Windows.Forms.Button bb_Clifor;
        private System.Windows.Forms.BindingNavigator BN_UsuarioCompra;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault gPesquisa;
        private System.Windows.Forms.BindingSource bs_userCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDCliforCMPDataGridViewTextBoxColumn;
        private Componentes.RadioGroup tp_usuario;
        private Componentes.PanelDados pFlag;
        private Componentes.CheckBoxDefault st_requisitar;
        private Componentes.CheckBoxDefault st_comprar;
        private Componentes.CheckBoxDefault st_aprovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforcmpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn strequisitarboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn staprovarboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stcomprarboolDataGridViewCheckBoxColumn;
    }
}
