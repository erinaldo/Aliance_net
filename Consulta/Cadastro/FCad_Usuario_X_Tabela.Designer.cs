namespace Consulta.Cadastro
{
    partial class TFCad_Usuario_X_Tabela
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Usuario_X_Tabela));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ds_login = new Componentes.EditDefault(this.components);
            this.BS_UsuarioXTabela = new System.Windows.Forms.BindingSource(this.components);
            this.bb_login = new System.Windows.Forms.Button();
            this.ds_clifor = new Componentes.EditDefault(this.components);
            this.bb_Clifor = new System.Windows.Forms.Button();
            this.login = new Componentes.EditDefault(this.components);
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox = new Componentes.CheckedListBoxDefault(this.components);
            this.cb_Marcar = new System.Windows.Forms.CheckBox();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.grid_UsuarioXTabela = new Componentes.DataGridDefault(this.components);
            this.iDUsuarioXTabelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMCliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMTabelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BN_UsuarioXTabela = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pConsulta = new Componentes.PanelDados(this.components);
            this.Filtro = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_UsuarioXTabela)).BeginInit();
            this.tabConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_UsuarioXTabela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_UsuarioXTabela)).BeginInit();
            this.BN_UsuarioXTabela.SuspendLayout();
            this.pConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.cb_Marcar);
            this.pDados.Controls.Add(this.ds_login);
            this.pDados.Controls.Add(this.bb_login);
            this.pDados.Controls.Add(this.ds_clifor);
            this.pDados.Controls.Add(this.bb_Clifor);
            this.pDados.Controls.Add(this.login);
            this.pDados.Controls.Add(this.cd_clifor);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Size = new System.Drawing.Size(659, 85);
            // 
            // tcCentral
            // 
            this.tcCentral.Controls.Add(this.tabConsulta);
            this.tcCentral.Controls.SetChildIndex(this.tabConsulta, 0);
            this.tcCentral.Controls.SetChildIndex(this.tpPadrao, 0);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.checkedListBox);
            this.tpPadrao.Size = new System.Drawing.Size(663, 364);
            this.tpPadrao.Text = "Cadastro Usuário X Tabelas";
            this.tpPadrao.Enter += new System.EventHandler(this.tpPadrao_Enter);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.checkedListBox, 0);
            // 
            // ds_login
            // 
            this.ds_login.BackColor = System.Drawing.SystemColors.Window;
            this.ds_login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_login.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_UsuarioXTabela, "nome_usuario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_login.Enabled = false;
            this.ds_login.Location = new System.Drawing.Point(224, 31);
            this.ds_login.Name = "ds_login";
            this.ds_login.NM_Alias = "";
            this.ds_login.NM_Campo = "nome_usuario";
            this.ds_login.NM_CampoBusca = "nome_usuario";
            this.ds_login.NM_Param = "@P_NOME_USUARIO";
            this.ds_login.QTD_Zero = 0;
            this.ds_login.Size = new System.Drawing.Size(408, 20);
            this.ds_login.ST_AutoInc = false;
            this.ds_login.ST_DisableAuto = false;
            this.ds_login.ST_Float = false;
            this.ds_login.ST_Gravar = false;
            this.ds_login.ST_Int = false;
            this.ds_login.ST_LimpaCampo = true;
            this.ds_login.ST_NotNull = false;
            this.ds_login.ST_PrimaryKey = false;
            this.ds_login.TabIndex = 25;
            // 
            // BS_UsuarioXTabela
            // 
            this.BS_UsuarioXTabela.DataSource = typeof(CamadaDados.Consulta.Cadastro.TList_Cad_Usuario_X_Tabela);
            // 
            // bb_login
            // 
            this.bb_login.BackColor = System.Drawing.SystemColors.Control;
            this.bb_login.Enabled = false;
            this.bb_login.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_login.Image = ((System.Drawing.Image)(resources.GetObject("bb_login.Image")));
            this.bb_login.Location = new System.Drawing.Point(190, 31);
            this.bb_login.Name = "bb_login";
            this.bb_login.Size = new System.Drawing.Size(30, 20);
            this.bb_login.TabIndex = 3;
            this.bb_login.UseVisualStyleBackColor = false;
            this.bb_login.Click += new System.EventHandler(this.bb_login_Click);
            // 
            // ds_clifor
            // 
            this.ds_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.ds_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_UsuarioXTabela, "NM_Clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_clifor.Enabled = false;
            this.ds_clifor.Location = new System.Drawing.Point(224, 8);
            this.ds_clifor.Name = "ds_clifor";
            this.ds_clifor.NM_Alias = "c";
            this.ds_clifor.NM_Campo = "nm_clifor";
            this.ds_clifor.NM_CampoBusca = "nm_clifor";
            this.ds_clifor.NM_Param = "";
            this.ds_clifor.QTD_Zero = 0;
            this.ds_clifor.Size = new System.Drawing.Size(408, 20);
            this.ds_clifor.ST_AutoInc = false;
            this.ds_clifor.ST_DisableAuto = false;
            this.ds_clifor.ST_Float = false;
            this.ds_clifor.ST_Gravar = false;
            this.ds_clifor.ST_Int = false;
            this.ds_clifor.ST_LimpaCampo = true;
            this.ds_clifor.ST_NotNull = false;
            this.ds_clifor.ST_PrimaryKey = false;
            this.ds_clifor.TabIndex = 24;
            // 
            // bb_Clifor
            // 
            this.bb_Clifor.BackColor = System.Drawing.SystemColors.Control;
            this.bb_Clifor.Enabled = false;
            this.bb_Clifor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_Clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_Clifor.Image")));
            this.bb_Clifor.Location = new System.Drawing.Point(190, 8);
            this.bb_Clifor.Name = "bb_Clifor";
            this.bb_Clifor.Size = new System.Drawing.Size(30, 20);
            this.bb_Clifor.TabIndex = 1;
            this.bb_Clifor.UseVisualStyleBackColor = false;
            this.bb_Clifor.Click += new System.EventHandler(this.bb_Clifor_Click);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.SystemColors.Window;
            this.login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.login.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_UsuarioXTabela, "Login", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.login.Enabled = false;
            this.login.Location = new System.Drawing.Point(116, 31);
            this.login.MaxLength = 20;
            this.login.Name = "login";
            this.login.NM_Alias = "a";
            this.login.NM_Campo = "login";
            this.login.NM_CampoBusca = "login";
            this.login.NM_Param = "@P_LOGIN";
            this.login.QTD_Zero = 0;
            this.login.Size = new System.Drawing.Size(70, 20);
            this.login.ST_AutoInc = false;
            this.login.ST_DisableAuto = false;
            this.login.ST_Float = false;
            this.login.ST_Gravar = true;
            this.login.ST_Int = false;
            this.login.ST_LimpaCampo = true;
            this.login.ST_NotNull = true;
            this.login.ST_PrimaryKey = true;
            this.login.TabIndex = 2;
            this.login.Leave += new System.EventHandler(this.login_Leave);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_UsuarioXTabela, "CD_Clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor.Enabled = false;
            this.cd_clifor.Location = new System.Drawing.Point(116, 8);
            this.cd_clifor.MaxLength = 10;
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "a";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_CLIFOR_CMP";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(70, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = true;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = true;
            this.cd_clifor.ST_PrimaryKey = true;
            this.cd_clifor.TabIndex = 0;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Usuário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Clifor Consulta:";
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.Display = "";
            this.checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox.Enabled = false;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.HorizontalScrollbar = true;
            this.checkedListBox.Location = new System.Drawing.Point(0, 85);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.NM_Alias = "";
            this.checkedListBox.NM_Campo = "";
            this.checkedListBox.Size = new System.Drawing.Size(659, 274);
            this.checkedListBox.ST_Gravar = false;
            this.checkedListBox.Tabela = null;
            this.checkedListBox.TabIndex = 1;
            this.checkedListBox.Value = "";
            this.checkedListBox.SelectedValueChanged += new System.EventHandler(this.checkedListBox_SelectedValueChanged);
            // 
            // cb_Marcar
            // 
            this.cb_Marcar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Marcar.AutoSize = true;
            this.cb_Marcar.Enabled = false;
            this.cb_Marcar.Location = new System.Drawing.Point(560, 61);
            this.cb_Marcar.Name = "cb_Marcar";
            this.cb_Marcar.Size = new System.Drawing.Size(92, 17);
            this.cb_Marcar.TabIndex = 4;
            this.cb_Marcar.Text = "Marcar Todos";
            this.cb_Marcar.UseVisualStyleBackColor = true;
            this.cb_Marcar.CheckedChanged += new System.EventHandler(this.cb_Marcar_CheckedChanged);
            // 
            // tabConsulta
            // 
            this.tabConsulta.Controls.Add(this.grid_UsuarioXTabela);
            this.tabConsulta.Controls.Add(this.BN_UsuarioXTabela);
            this.tabConsulta.Controls.Add(this.pConsulta);
            this.tabConsulta.Location = new System.Drawing.Point(4, 22);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsulta.Size = new System.Drawing.Size(663, 364);
            this.tabConsulta.TabIndex = 1;
            this.tabConsulta.Text = "Consulta";
            this.tabConsulta.UseVisualStyleBackColor = true;
            this.tabConsulta.Enter += new System.EventHandler(this.tabConsulta_Enter);
            // 
            // grid_UsuarioXTabela
            // 
            this.grid_UsuarioXTabela.AllowUserToAddRows = false;
            this.grid_UsuarioXTabela.AllowUserToDeleteRows = false;
            this.grid_UsuarioXTabela.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.grid_UsuarioXTabela.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_UsuarioXTabela.AutoGenerateColumns = false;
            this.grid_UsuarioXTabela.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid_UsuarioXTabela.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_UsuarioXTabela.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_UsuarioXTabela.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_UsuarioXTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_UsuarioXTabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDUsuarioXTabelaDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.nMCliforDataGridViewTextBoxColumn,
            this.nMTabelaDataGridViewTextBoxColumn});
            this.grid_UsuarioXTabela.DataSource = this.BS_UsuarioXTabela;
            this.grid_UsuarioXTabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_UsuarioXTabela.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grid_UsuarioXTabela.Location = new System.Drawing.Point(3, 53);
            this.grid_UsuarioXTabela.Name = "grid_UsuarioXTabela";
            this.grid_UsuarioXTabela.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_UsuarioXTabela.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_UsuarioXTabela.RowHeadersWidth = 23;
            this.grid_UsuarioXTabela.Size = new System.Drawing.Size(657, 283);
            this.grid_UsuarioXTabela.TabIndex = 1;
            // 
            // iDUsuarioXTabelaDataGridViewTextBoxColumn
            // 
            this.iDUsuarioXTabelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDUsuarioXTabelaDataGridViewTextBoxColumn.DataPropertyName = "IDUsuarioXTabela";
            this.iDUsuarioXTabelaDataGridViewTextBoxColumn.HeaderText = "Código";
            this.iDUsuarioXTabelaDataGridViewTextBoxColumn.Name = "iDUsuarioXTabelaDataGridViewTextBoxColumn";
            this.iDUsuarioXTabelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDUsuarioXTabelaDataGridViewTextBoxColumn.Width = 65;
            // 
            // loginDataGridViewTextBoxColumn
            // 
            this.loginDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.loginDataGridViewTextBoxColumn.DataPropertyName = "Login";
            this.loginDataGridViewTextBoxColumn.HeaderText = "Login";
            this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
            this.loginDataGridViewTextBoxColumn.ReadOnly = true;
            this.loginDataGridViewTextBoxColumn.Width = 58;
            // 
            // nMCliforDataGridViewTextBoxColumn
            // 
            this.nMCliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMCliforDataGridViewTextBoxColumn.DataPropertyName = "NM_Clifor";
            this.nMCliforDataGridViewTextBoxColumn.HeaderText = "Nome Clifor";
            this.nMCliforDataGridViewTextBoxColumn.Name = "nMCliforDataGridViewTextBoxColumn";
            this.nMCliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nMCliforDataGridViewTextBoxColumn.Width = 86;
            // 
            // nMTabelaDataGridViewTextBoxColumn
            // 
            this.nMTabelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMTabelaDataGridViewTextBoxColumn.DataPropertyName = "NM_Tabela";
            this.nMTabelaDataGridViewTextBoxColumn.HeaderText = "Nome Tabela";
            this.nMTabelaDataGridViewTextBoxColumn.Name = "nMTabelaDataGridViewTextBoxColumn";
            this.nMTabelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nMTabelaDataGridViewTextBoxColumn.Width = 96;
            // 
            // BN_UsuarioXTabela
            // 
            this.BN_UsuarioXTabela.AddNewItem = null;
            this.BN_UsuarioXTabela.CountItem = this.bindingNavigatorCountItem;
            this.BN_UsuarioXTabela.DeleteItem = null;
            this.BN_UsuarioXTabela.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_UsuarioXTabela.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_UsuarioXTabela.Location = new System.Drawing.Point(3, 336);
            this.BN_UsuarioXTabela.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_UsuarioXTabela.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_UsuarioXTabela.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_UsuarioXTabela.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_UsuarioXTabela.Name = "BN_UsuarioXTabela";
            this.BN_UsuarioXTabela.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_UsuarioXTabela.Size = new System.Drawing.Size(657, 25);
            this.BN_UsuarioXTabela.TabIndex = 2;
            this.BN_UsuarioXTabela.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
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
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
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
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // pConsulta
            // 
            this.pConsulta.Controls.Add(this.Filtro);
            this.pConsulta.Controls.Add(this.label3);
            this.pConsulta.Dock = System.Windows.Forms.DockStyle.Top;
            this.pConsulta.Location = new System.Drawing.Point(3, 3);
            this.pConsulta.Name = "pConsulta";
            this.pConsulta.NM_ProcDeletar = "";
            this.pConsulta.NM_ProcGravar = "";
            this.pConsulta.Size = new System.Drawing.Size(657, 50);
            this.pConsulta.TabIndex = 0;
            // 
            // Filtro
            // 
            this.Filtro.BackColor = System.Drawing.SystemColors.Window;
            this.Filtro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Filtro.Location = new System.Drawing.Point(124, 13);
            this.Filtro.MaxLength = 50;
            this.Filtro.Name = "Filtro";
            this.Filtro.NM_Alias = "c";
            this.Filtro.NM_Campo = "nm_clifor";
            this.Filtro.NM_CampoBusca = "nm_clifor";
            this.Filtro.NM_Param = "";
            this.Filtro.QTD_Zero = 0;
            this.Filtro.Size = new System.Drawing.Size(510, 20);
            this.Filtro.ST_AutoInc = false;
            this.Filtro.ST_DisableAuto = false;
            this.Filtro.ST_Float = false;
            this.Filtro.ST_Gravar = false;
            this.Filtro.ST_Int = false;
            this.Filtro.ST_LimpaCampo = true;
            this.Filtro.ST_NotNull = false;
            this.Filtro.ST_PrimaryKey = false;
            this.Filtro.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Nome da Tabela:";
            // 
            // TFCad_Usuario_X_Tabela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TFCad_Usuario_X_Tabela";
            this.Text = "Cadastro Usuário X Tabelas";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BS_UsuarioXTabela)).EndInit();
            this.tabConsulta.ResumeLayout(false);
            this.tabConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_UsuarioXTabela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_UsuarioXTabela)).EndInit();
            this.BN_UsuarioXTabela.ResumeLayout(false);
            this.BN_UsuarioXTabela.PerformLayout();
            this.pConsulta.ResumeLayout(false);
            this.pConsulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault ds_login;
        public System.Windows.Forms.Button bb_login;
        private Componentes.EditDefault ds_clifor;
        public System.Windows.Forms.Button bb_Clifor;
        private Componentes.EditDefault login;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.CheckedListBoxDefault checkedListBox;
        private System.Windows.Forms.CheckBox cb_Marcar;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.BindingNavigator BN_UsuarioXTabela;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault grid_UsuarioXTabela;
        private Componentes.PanelDados pConsulta;
        private Componentes.EditDefault Filtro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource BS_UsuarioXTabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDUsuarioXTabelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDCliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMCliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMTabelaDataGridViewTextBoxColumn;

    }
}
