namespace Almoxarifado.Cadastros
{
    partial class TFCadAMX_Usuario_X_AMX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadAMX_Usuario_X_AMX));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAlmoxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTOperacaoEntradaBoolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sTOperacaoSaidaBoolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sTOperacaoConferenciaBoolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BS_CadAMX_Usuario_X_AMX = new System.Windows.Forms.BindingSource(this.components);
            this.BN_CadAMX_Usuario_X_AMX = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.Login = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.BB_Almoxarifado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DS_Almoxarifado = new Componentes.EditDefault(this.components);
            this.Id_Almox = new Componentes.EditDefault(this.components);
            this.rg_operacao = new Componentes.RadioGroup(this.components);
            this.pd_Operacao = new Componentes.PanelDados(this.components);
            this.ST_Operacao_Conferencia = new Componentes.CheckBoxDefault(this.components);
            this.ST_Operacao_Saida = new Componentes.CheckBoxDefault(this.components);
            this.ST_Operacao_Entrada = new Componentes.CheckBoxDefault(this.components);
            this.bbLogin = new System.Windows.Forms.Button();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadAMX_Usuario_X_AMX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadAMX_Usuario_X_AMX)).BeginInit();
            this.BN_CadAMX_Usuario_X_AMX.SuspendLayout();
            this.rg_operacao.SuspendLayout();
            this.pd_Operacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.bbLogin);
            this.pDados.Controls.Add(this.rg_operacao);
            this.pDados.Controls.Add(this.BB_Almoxarifado);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.DS_Almoxarifado);
            this.pDados.Controls.Add(this.Id_Almox);
            this.pDados.Controls.Add(this.Login);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Size = new System.Drawing.Size(616, 104);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(628, 335);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.BN_CadAMX_Usuario_X_AMX);
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(620, 309);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadAMX_Usuario_X_AMX, 0);
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
            this.loginDataGridViewTextBoxColumn,
            this.idAlmoxDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.sTOperacaoEntradaBoolDataGridViewCheckBoxColumn,
            this.sTOperacaoSaidaBoolDataGridViewCheckBoxColumn,
            this.sTOperacaoConferenciaBoolDataGridViewCheckBoxColumn});
            this.dataGridDefault1.DataSource = this.BS_CadAMX_Usuario_X_AMX;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 104);
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
            this.dataGridDefault1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDefault1.Size = new System.Drawing.Size(616, 201);
            this.dataGridDefault1.TabIndex = 1;
            this.dataGridDefault1.TabStop = false;
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
            // idAlmoxDataGridViewTextBoxColumn
            // 
            this.idAlmoxDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idAlmoxDataGridViewTextBoxColumn.DataPropertyName = "Id_Almox";
            this.idAlmoxDataGridViewTextBoxColumn.HeaderText = "Cód. Almox.";
            this.idAlmoxDataGridViewTextBoxColumn.Name = "idAlmoxDataGridViewTextBoxColumn";
            this.idAlmoxDataGridViewTextBoxColumn.ReadOnly = true;
            this.idAlmoxDataGridViewTextBoxColumn.Width = 88;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DS_Almoxarifado";
            this.dataGridViewTextBoxColumn1.HeaderText = "Desc.Local Almoxarifado";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 136;
            // 
            // sTOperacaoEntradaBoolDataGridViewCheckBoxColumn
            // 
            this.sTOperacaoEntradaBoolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sTOperacaoEntradaBoolDataGridViewCheckBoxColumn.DataPropertyName = "ST_Operacao_EntradaBool";
            this.sTOperacaoEntradaBoolDataGridViewCheckBoxColumn.HeaderText = "Operação Entrada";
            this.sTOperacaoEntradaBoolDataGridViewCheckBoxColumn.Name = "sTOperacaoEntradaBoolDataGridViewCheckBoxColumn";
            this.sTOperacaoEntradaBoolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.sTOperacaoEntradaBoolDataGridViewCheckBoxColumn.Width = 90;
            // 
            // sTOperacaoSaidaBoolDataGridViewCheckBoxColumn
            // 
            this.sTOperacaoSaidaBoolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sTOperacaoSaidaBoolDataGridViewCheckBoxColumn.DataPropertyName = "ST_Operacao_SaidaBool";
            this.sTOperacaoSaidaBoolDataGridViewCheckBoxColumn.HeaderText = "Operação Saída";
            this.sTOperacaoSaidaBoolDataGridViewCheckBoxColumn.Name = "sTOperacaoSaidaBoolDataGridViewCheckBoxColumn";
            this.sTOperacaoSaidaBoolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.sTOperacaoSaidaBoolDataGridViewCheckBoxColumn.Width = 83;
            // 
            // sTOperacaoConferenciaBoolDataGridViewCheckBoxColumn
            // 
            this.sTOperacaoConferenciaBoolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sTOperacaoConferenciaBoolDataGridViewCheckBoxColumn.DataPropertyName = "ST_Operacao_ConferenciaBool";
            this.sTOperacaoConferenciaBoolDataGridViewCheckBoxColumn.HeaderText = "Operação Conferencia";
            this.sTOperacaoConferenciaBoolDataGridViewCheckBoxColumn.Name = "sTOperacaoConferenciaBoolDataGridViewCheckBoxColumn";
            this.sTOperacaoConferenciaBoolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.sTOperacaoConferenciaBoolDataGridViewCheckBoxColumn.Width = 108;
            // 
            // BS_CadAMX_Usuario_X_AMX
            // 
            this.BS_CadAMX_Usuario_X_AMX.DataSource = typeof(CamadaDados.Almoxarifado.TList_CadAMX_Usuario_X_AMX);
            // 
            // BN_CadAMX_Usuario_X_AMX
            // 
            this.BN_CadAMX_Usuario_X_AMX.AddNewItem = null;
            this.BN_CadAMX_Usuario_X_AMX.BindingSource = this.BS_CadAMX_Usuario_X_AMX;
            this.BN_CadAMX_Usuario_X_AMX.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadAMX_Usuario_X_AMX.DeleteItem = null;
            this.BN_CadAMX_Usuario_X_AMX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_CadAMX_Usuario_X_AMX.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadAMX_Usuario_X_AMX.Location = new System.Drawing.Point(0, 280);
            this.BN_CadAMX_Usuario_X_AMX.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadAMX_Usuario_X_AMX.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadAMX_Usuario_X_AMX.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadAMX_Usuario_X_AMX.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadAMX_Usuario_X_AMX.Name = "BN_CadAMX_Usuario_X_AMX";
            this.BN_CadAMX_Usuario_X_AMX.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_CadAMX_Usuario_X_AMX.Size = new System.Drawing.Size(616, 25);
            this.BN_CadAMX_Usuario_X_AMX.TabIndex = 2;
            this.BN_CadAMX_Usuario_X_AMX.Text = "bindingNavigator1";
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
            // Login
            // 
            this.Login.BackColor = System.Drawing.SystemColors.Window;
            this.Login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Login.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadAMX_Usuario_X_AMX, "Login", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Login.Enabled = false;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(88, 11);
            this.Login.MaxLength = 20;
            this.Login.Name = "Login";
            this.Login.NM_Alias = "a";
            this.Login.NM_Campo = "Login";
            this.Login.NM_CampoBusca = "Login";
            this.Login.NM_Param = "@P_LOGIN";
            this.Login.QTD_Zero = 0;
            this.Login.Size = new System.Drawing.Size(160, 20);
            this.Login.ST_AutoInc = false;
            this.Login.ST_DisableAuto = true;
            this.Login.ST_Float = false;
            this.Login.ST_Gravar = true;
            this.Login.ST_Int = false;
            this.Login.ST_LimpaCampo = true;
            this.Login.ST_NotNull = true;
            this.Login.ST_PrimaryKey = true;
            this.Login.TabIndex = 0;
            this.Login.Leave += new System.EventHandler(this.Login_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Login:";
            // 
            // BB_Almoxarifado
            // 
            this.BB_Almoxarifado.Enabled = false;
            this.BB_Almoxarifado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Almoxarifado.Image = ((System.Drawing.Image)(resources.GetObject("BB_Almoxarifado.Image")));
            this.BB_Almoxarifado.Location = new System.Drawing.Point(140, 37);
            this.BB_Almoxarifado.Name = "BB_Almoxarifado";
            this.BB_Almoxarifado.Size = new System.Drawing.Size(28, 20);
            this.BB_Almoxarifado.TabIndex = 3;
            this.BB_Almoxarifado.UseVisualStyleBackColor = true;
            this.BB_Almoxarifado.Click += new System.EventHandler(this.BB_Almoxarifado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Cód. Almox.:";
            // 
            // DS_Almoxarifado
            // 
            this.DS_Almoxarifado.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Almoxarifado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Almoxarifado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadAMX_Usuario_X_AMX, "DS_Almoxarifado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Almoxarifado.Enabled = false;
            this.DS_Almoxarifado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_Almoxarifado.Location = new System.Drawing.Point(170, 37);
            this.DS_Almoxarifado.Name = "DS_Almoxarifado";
            this.DS_Almoxarifado.NM_Alias = "b";
            this.DS_Almoxarifado.NM_Campo = "DS_Almoxarifado";
            this.DS_Almoxarifado.NM_CampoBusca = "DS_Almoxarifado";
            this.DS_Almoxarifado.NM_Param = "@P_DS_ALMOXARIFADO";
            this.DS_Almoxarifado.QTD_Zero = 0;
            this.DS_Almoxarifado.Size = new System.Drawing.Size(398, 20);
            this.DS_Almoxarifado.ST_AutoInc = false;
            this.DS_Almoxarifado.ST_DisableAuto = true;
            this.DS_Almoxarifado.ST_Float = false;
            this.DS_Almoxarifado.ST_Gravar = false;
            this.DS_Almoxarifado.ST_Int = false;
            this.DS_Almoxarifado.ST_LimpaCampo = true;
            this.DS_Almoxarifado.ST_NotNull = false;
            this.DS_Almoxarifado.ST_PrimaryKey = false;
            this.DS_Almoxarifado.TabIndex = 0;
            // 
            // Id_Almox
            // 
            this.Id_Almox.BackColor = System.Drawing.SystemColors.Window;
            this.Id_Almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Id_Almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadAMX_Usuario_X_AMX, "ID_AlmoxString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Id_Almox.Enabled = false;
            this.Id_Almox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Id_Almox.Location = new System.Drawing.Point(88, 37);
            this.Id_Almox.MaxLength = 5;
            this.Id_Almox.Name = "Id_Almox";
            this.Id_Almox.NM_Alias = "a";
            this.Id_Almox.NM_Campo = "Id_Almox";
            this.Id_Almox.NM_CampoBusca = "Id_Almox";
            this.Id_Almox.NM_Param = "@P_ID_ALMOX";
            this.Id_Almox.QTD_Zero = 0;
            this.Id_Almox.Size = new System.Drawing.Size(50, 20);
            this.Id_Almox.ST_AutoInc = false;
            this.Id_Almox.ST_DisableAuto = false;
            this.Id_Almox.ST_Float = false;
            this.Id_Almox.ST_Gravar = true;
            this.Id_Almox.ST_Int = false;
            this.Id_Almox.ST_LimpaCampo = true;
            this.Id_Almox.ST_NotNull = true;
            this.Id_Almox.ST_PrimaryKey = true;
            this.Id_Almox.TabIndex = 2;
            this.Id_Almox.Leave += new System.EventHandler(this.Id_Almox_Leave);
            // 
            // rg_operacao
            // 
            this.rg_operacao.Controls.Add(this.pd_Operacao);
            this.rg_operacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rg_operacao.Location = new System.Drawing.Point(88, 58);
            this.rg_operacao.Name = "rg_operacao";
            this.rg_operacao.NM_Alias = "";
            this.rg_operacao.NM_Campo = "";
            this.rg_operacao.NM_Param = "";
            this.rg_operacao.NM_Valor = "";
            this.rg_operacao.Size = new System.Drawing.Size(283, 39);
            this.rg_operacao.ST_Gravar = false;
            this.rg_operacao.ST_NotNull = false;
            this.rg_operacao.TabIndex = 24;
            this.rg_operacao.TabStop = false;
            this.rg_operacao.Text = "Operação";
            // 
            // pd_Operacao
            // 
            this.pd_Operacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pd_Operacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pd_Operacao.Controls.Add(this.ST_Operacao_Conferencia);
            this.pd_Operacao.Controls.Add(this.ST_Operacao_Saida);
            this.pd_Operacao.Controls.Add(this.ST_Operacao_Entrada);
            this.pd_Operacao.Location = new System.Drawing.Point(5, 13);
            this.pd_Operacao.Name = "pd_Operacao";
            this.pd_Operacao.NM_ProcDeletar = "";
            this.pd_Operacao.NM_ProcGravar = "";
            this.pd_Operacao.Size = new System.Drawing.Size(274, 23);
            this.pd_Operacao.TabIndex = 0;
            // 
            // ST_Operacao_Conferencia
            // 
            this.ST_Operacao_Conferencia.AutoSize = true;
            this.ST_Operacao_Conferencia.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadAMX_Usuario_X_AMX, "ST_Operacao_ConferenciaBool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Operacao_Conferencia.Enabled = false;
            this.ST_Operacao_Conferencia.Location = new System.Drawing.Point(173, 1);
            this.ST_Operacao_Conferencia.Name = "ST_Operacao_Conferencia";
            this.ST_Operacao_Conferencia.NM_Alias = "a";
            this.ST_Operacao_Conferencia.NM_Campo = "ST_Operacao_Conferencia";
            this.ST_Operacao_Conferencia.NM_Param = "@P_ST_OPERACAO_CONFERENCIA";
            this.ST_Operacao_Conferencia.Size = new System.Drawing.Size(94, 17);
            this.ST_Operacao_Conferencia.ST_Gravar = true;
            this.ST_Operacao_Conferencia.ST_LimparCampo = true;
            this.ST_Operacao_Conferencia.ST_NotNull = false;
            this.ST_Operacao_Conferencia.TabIndex = 2;
            this.ST_Operacao_Conferencia.Text = "Conferencia";
            this.ST_Operacao_Conferencia.UseVisualStyleBackColor = true;
            this.ST_Operacao_Conferencia.Vl_False = "N";
            this.ST_Operacao_Conferencia.Vl_True = "S";
            // 
            // ST_Operacao_Saida
            // 
            this.ST_Operacao_Saida.AutoSize = true;
            this.ST_Operacao_Saida.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadAMX_Usuario_X_AMX, "ST_Operacao_SaidaBool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Operacao_Saida.Enabled = false;
            this.ST_Operacao_Saida.Location = new System.Drawing.Point(95, 1);
            this.ST_Operacao_Saida.Name = "ST_Operacao_Saida";
            this.ST_Operacao_Saida.NM_Alias = "a";
            this.ST_Operacao_Saida.NM_Campo = "ST_Operacao_Saida";
            this.ST_Operacao_Saida.NM_Param = "@P_ST_OPERACAO_SAIDA";
            this.ST_Operacao_Saida.Size = new System.Drawing.Size(58, 17);
            this.ST_Operacao_Saida.ST_Gravar = true;
            this.ST_Operacao_Saida.ST_LimparCampo = true;
            this.ST_Operacao_Saida.ST_NotNull = false;
            this.ST_Operacao_Saida.TabIndex = 1;
            this.ST_Operacao_Saida.Text = "Saida";
            this.ST_Operacao_Saida.UseVisualStyleBackColor = true;
            this.ST_Operacao_Saida.Vl_False = "N";
            this.ST_Operacao_Saida.Vl_True = "S";
            // 
            // ST_Operacao_Entrada
            // 
            this.ST_Operacao_Entrada.AutoSize = true;
            this.ST_Operacao_Entrada.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadAMX_Usuario_X_AMX, "ST_Operacao_EntradaBool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Operacao_Entrada.Enabled = false;
            this.ST_Operacao_Entrada.Location = new System.Drawing.Point(19, 1);
            this.ST_Operacao_Entrada.Name = "ST_Operacao_Entrada";
            this.ST_Operacao_Entrada.NM_Alias = "a";
            this.ST_Operacao_Entrada.NM_Campo = "ST_Operacao_Entrada";
            this.ST_Operacao_Entrada.NM_Param = "@P_ST_OPERACAO_ENTRADA";
            this.ST_Operacao_Entrada.Size = new System.Drawing.Size(70, 17);
            this.ST_Operacao_Entrada.ST_Gravar = true;
            this.ST_Operacao_Entrada.ST_LimparCampo = true;
            this.ST_Operacao_Entrada.ST_NotNull = false;
            this.ST_Operacao_Entrada.TabIndex = 0;
            this.ST_Operacao_Entrada.Text = "Entrada";
            this.ST_Operacao_Entrada.UseVisualStyleBackColor = true;
            this.ST_Operacao_Entrada.Vl_False = "N";
            this.ST_Operacao_Entrada.Vl_True = "S";
            // 
            // bbLogin
            // 
            this.bbLogin.Enabled = false;
            this.bbLogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bbLogin.Image = ((System.Drawing.Image)(resources.GetObject("bbLogin.Image")));
            this.bbLogin.Location = new System.Drawing.Point(254, 11);
            this.bbLogin.Name = "bbLogin";
            this.bbLogin.Size = new System.Drawing.Size(28, 20);
            this.bbLogin.TabIndex = 1;
            this.bbLogin.UseVisualStyleBackColor = true;
            this.bbLogin.Click += new System.EventHandler(this.bbLogin_Click);
            // 
            // TFCadAMX_Usuario_X_AMX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(628, 378);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadAMX_Usuario_X_AMX";
            this.Text = "Cadastro de Usuário Almoxarifado";
            this.Load += new System.EventHandler(this.TFCadAMX_Usuario_X_AMX_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadAMX_Usuario_X_AMX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadAMX_Usuario_X_AMX)).EndInit();
            this.BN_CadAMX_Usuario_X_AMX.ResumeLayout(false);
            this.BN_CadAMX_Usuario_X_AMX.PerformLayout();
            this.rg_operacao.ResumeLayout(false);
            this.pd_Operacao.ResumeLayout(false);
            this.pd_Operacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingNavigator BN_CadAMX_Usuario_X_AMX;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource BS_CadAMX_Usuario_X_AMX;
        private Componentes.EditDefault Login;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button BB_Almoxarifado;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault DS_Almoxarifado;
        private Componentes.EditDefault Id_Almox;
        private Componentes.RadioGroup rg_operacao;
        private Componentes.PanelDados pd_Operacao;
        private Componentes.CheckBoxDefault ST_Operacao_Conferencia;
        private Componentes.CheckBoxDefault ST_Operacao_Saida;
        private Componentes.CheckBoxDefault ST_Operacao_Entrada;
        public System.Windows.Forms.Button bbLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAlmoxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sTOperacaoEntradaBoolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sTOperacaoSaidaBoolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sTOperacaoConferenciaBoolDataGridViewCheckBoxColumn;
    }
}
