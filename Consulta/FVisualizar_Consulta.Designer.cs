namespace Consulta
{
    partial class TFVisualizar_Consulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFVisualizar_Consulta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabSQLConsulta = new System.Windows.Forms.TabPage();
            this.groupBoxSQL = new System.Windows.Forms.GroupBox();
            this.DS_SQL = new Componentes.EditDefault(this.components);
            this.tabVisualizar = new System.Windows.Forms.TabPage();
            this.groupBoxGrid = new System.Windows.Forms.GroupBox();
            this.Grid_Visualizador = new Componentes.DataGridDefault(this.components);
            this.BS_Visualizador = new System.Windows.Forms.BindingSource(this.components);
            this.BN_Visualidor = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ID_Consulta = new Componentes.EditDefault(this.components);
            this.DS_Consulta = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.ds_login = new Componentes.EditDefault(this.components);
            this.BB_Login = new System.Windows.Forms.Button();
            this.login = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.BB_Clifor = new System.Windows.Forms.Button();
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BS_Consulta = new System.Windows.Forms.BindingSource(this.components);
            this.grid_Consulta = new Componentes.DataGridDefault(this.components);
            this.iDConsultaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSConsultaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTConsultaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BN_Consulta = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            this.tabSQLConsulta.SuspendLayout();
            this.groupBoxSQL.SuspendLayout();
            this.tabVisualizar.SuspendLayout();
            this.groupBoxGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Visualizador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Visualizador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Visualidor)).BeginInit();
            this.BN_Visualidor.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Consulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Consulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Consulta)).BeginInit();
            this.BN_Consulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCentral
            // 
            this.tcCentral.Controls.Add(this.tabSQLConsulta);
            this.tcCentral.Controls.Add(this.tabVisualizar);
            this.tcCentral.Size = new System.Drawing.Size(642, 480);
            this.tcCentral.Controls.SetChildIndex(this.tabVisualizar, 0);
            this.tcCentral.Controls.SetChildIndex(this.tabSQLConsulta, 0);
            this.tcCentral.Controls.SetChildIndex(this.tpPadrao, 0);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.grid_Consulta);
            this.tpPadrao.Controls.Add(this.BN_Consulta);
            this.tpPadrao.Controls.Add(this.pDados);
            this.tpPadrao.Size = new System.Drawing.Size(634, 454);
            this.tpPadrao.Text = "Consulta";
            // 
            // tabSQLConsulta
            // 
            this.tabSQLConsulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabSQLConsulta.Controls.Add(this.groupBoxSQL);
            this.tabSQLConsulta.Location = new System.Drawing.Point(4, 22);
            this.tabSQLConsulta.Name = "tabSQLConsulta";
            this.tabSQLConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tabSQLConsulta.Size = new System.Drawing.Size(594, 364);
            this.tabSQLConsulta.TabIndex = 1;
            this.tabSQLConsulta.Text = "SQL Consulta";
            this.tabSQLConsulta.UseVisualStyleBackColor = true;
            this.tabSQLConsulta.Enter += new System.EventHandler(this.tabSQLConsulta_Enter);
            // 
            // groupBoxSQL
            // 
            this.groupBoxSQL.Controls.Add(this.DS_SQL);
            this.groupBoxSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSQL.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSQL.Name = "groupBoxSQL";
            this.groupBoxSQL.Size = new System.Drawing.Size(584, 354);
            this.groupBoxSQL.TabIndex = 0;
            this.groupBoxSQL.TabStop = false;
            this.groupBoxSQL.Text = "SQL";
            // 
            // DS_SQL
            // 
            this.DS_SQL.BackColor = System.Drawing.SystemColors.Window;
            this.DS_SQL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_SQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DS_SQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_SQL.Location = new System.Drawing.Point(3, 16);
            this.DS_SQL.MaxLength = 5024;
            this.DS_SQL.Multiline = true;
            this.DS_SQL.Name = "DS_SQL";
            this.DS_SQL.NM_Alias = "";
            this.DS_SQL.NM_Campo = "";
            this.DS_SQL.NM_CampoBusca = "";
            this.DS_SQL.NM_Param = "";
            this.DS_SQL.QTD_Zero = 0;
            this.DS_SQL.ReadOnly = true;
            this.DS_SQL.Size = new System.Drawing.Size(578, 335);
            this.DS_SQL.ST_AutoInc = false;
            this.DS_SQL.ST_DisableAuto = false;
            this.DS_SQL.ST_Float = false;
            this.DS_SQL.ST_Gravar = true;
            this.DS_SQL.ST_Int = false;
            this.DS_SQL.ST_LimpaCampo = true;
            this.DS_SQL.ST_NotNull = false;
            this.DS_SQL.ST_PrimaryKey = false;
            this.DS_SQL.TabIndex = 8;
            // 
            // tabVisualizar
            // 
            this.tabVisualizar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabVisualizar.Controls.Add(this.groupBoxGrid);
            this.tabVisualizar.Location = new System.Drawing.Point(4, 22);
            this.tabVisualizar.Name = "tabVisualizar";
            this.tabVisualizar.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisualizar.Size = new System.Drawing.Size(594, 364);
            this.tabVisualizar.TabIndex = 2;
            this.tabVisualizar.Text = "Visualizar Resultado";
            this.tabVisualizar.UseVisualStyleBackColor = true;
            this.tabVisualizar.Enter += new System.EventHandler(this.tabVisualizar_Enter);
            // 
            // groupBoxGrid
            // 
            this.groupBoxGrid.Controls.Add(this.Grid_Visualizador);
            this.groupBoxGrid.Controls.Add(this.BN_Visualidor);
            this.groupBoxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGrid.Location = new System.Drawing.Point(3, 3);
            this.groupBoxGrid.Name = "groupBoxGrid";
            this.groupBoxGrid.Size = new System.Drawing.Size(584, 354);
            this.groupBoxGrid.TabIndex = 0;
            this.groupBoxGrid.TabStop = false;
            this.groupBoxGrid.Text = "Dados da Consulta";
            // 
            // Grid_Visualizador
            // 
            this.Grid_Visualizador.AllowUserToAddRows = false;
            this.Grid_Visualizador.AllowUserToDeleteRows = false;
            this.Grid_Visualizador.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.Grid_Visualizador.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Visualizador.AutoGenerateColumns = false;
            this.Grid_Visualizador.BackgroundColor = System.Drawing.Color.LightGray;
            this.Grid_Visualizador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grid_Visualizador.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Visualizador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_Visualizador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Visualizador.DataSource = this.BS_Visualizador;
            this.Grid_Visualizador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Visualizador.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Grid_Visualizador.Location = new System.Drawing.Point(3, 16);
            this.Grid_Visualizador.Name = "Grid_Visualizador";
            this.Grid_Visualizador.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Visualizador.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_Visualizador.RowHeadersWidth = 23;
            this.Grid_Visualizador.Size = new System.Drawing.Size(578, 310);
            this.Grid_Visualizador.TabIndex = 0;
            // 
            // BN_Visualidor
            // 
            this.BN_Visualidor.AddNewItem = null;
            this.BN_Visualidor.BindingSource = this.BS_Visualizador;
            this.BN_Visualidor.CountItem = this.bindingNavigatorCountItem1;
            this.BN_Visualidor.DeleteItem = null;
            this.BN_Visualidor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_Visualidor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1});
            this.BN_Visualidor.Location = new System.Drawing.Point(3, 326);
            this.BN_Visualidor.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.BN_Visualidor.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.BN_Visualidor.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.BN_Visualidor.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.BN_Visualidor.Name = "BN_Visualidor";
            this.BN_Visualidor.PositionItem = this.bindingNavigatorPositionItem1;
            this.BN_Visualidor.Size = new System.Drawing.Size(578, 25);
            this.BN_Visualidor.TabIndex = 1;
            this.BN_Visualidor.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem1.Text = "of {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ID_Consulta);
            this.pDados.Controls.Add(this.DS_Consulta);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.ds_login);
            this.pDados.Controls.Add(this.BB_Login);
            this.pDados.Controls.Add(this.login);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.NM_Clifor);
            this.pDados.Controls.Add(this.BB_Clifor);
            this.pDados.Controls.Add(this.CD_Clifor);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Top;
            this.pDados.Location = new System.Drawing.Point(0, 0);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(630, 110);
            this.pDados.TabIndex = 0;
            // 
            // ID_Consulta
            // 
            this.ID_Consulta.BackColor = System.Drawing.SystemColors.Window;
            this.ID_Consulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Consulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_Consulta.Location = new System.Drawing.Point(107, 9);
            this.ID_Consulta.MaxLength = 9;
            this.ID_Consulta.Name = "ID_Consulta";
            this.ID_Consulta.NM_Alias = "";
            this.ID_Consulta.NM_Campo = "";
            this.ID_Consulta.NM_CampoBusca = "";
            this.ID_Consulta.NM_Param = "";
            this.ID_Consulta.QTD_Zero = 0;
            this.ID_Consulta.Size = new System.Drawing.Size(70, 20);
            this.ID_Consulta.ST_AutoInc = false;
            this.ID_Consulta.ST_DisableAuto = false;
            this.ID_Consulta.ST_Float = false;
            this.ID_Consulta.ST_Gravar = true;
            this.ID_Consulta.ST_Int = false;
            this.ID_Consulta.ST_LimpaCampo = true;
            this.ID_Consulta.ST_NotNull = false;
            this.ID_Consulta.ST_PrimaryKey = false;
            this.ID_Consulta.TabIndex = 0;
            // 
            // DS_Consulta
            // 
            this.DS_Consulta.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Consulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Consulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_Consulta.Location = new System.Drawing.Point(106, 78);
            this.DS_Consulta.MaxLength = 150;
            this.DS_Consulta.Name = "DS_Consulta";
            this.DS_Consulta.NM_Alias = "";
            this.DS_Consulta.NM_Campo = "";
            this.DS_Consulta.NM_CampoBusca = "";
            this.DS_Consulta.NM_Param = "";
            this.DS_Consulta.QTD_Zero = 0;
            this.DS_Consulta.Size = new System.Drawing.Size(508, 20);
            this.DS_Consulta.ST_AutoInc = false;
            this.DS_Consulta.ST_DisableAuto = false;
            this.DS_Consulta.ST_Float = false;
            this.DS_Consulta.ST_Gravar = false;
            this.DS_Consulta.ST_Int = false;
            this.DS_Consulta.ST_LimpaCampo = true;
            this.DS_Consulta.ST_NotNull = false;
            this.DS_Consulta.ST_PrimaryKey = false;
            this.DS_Consulta.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Nome Consulta:";
            // 
            // ds_login
            // 
            this.ds_login.BackColor = System.Drawing.SystemColors.Window;
            this.ds_login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_login.Enabled = false;
            this.ds_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ds_login.Location = new System.Drawing.Point(214, 55);
            this.ds_login.Name = "ds_login";
            this.ds_login.NM_Alias = "";
            this.ds_login.NM_Campo = "nome_usuario";
            this.ds_login.NM_CampoBusca = "nome_usuario";
            this.ds_login.NM_Param = "";
            this.ds_login.QTD_Zero = 0;
            this.ds_login.Size = new System.Drawing.Size(400, 20);
            this.ds_login.ST_AutoInc = false;
            this.ds_login.ST_DisableAuto = true;
            this.ds_login.ST_Float = false;
            this.ds_login.ST_Gravar = false;
            this.ds_login.ST_Int = false;
            this.ds_login.ST_LimpaCampo = true;
            this.ds_login.ST_NotNull = false;
            this.ds_login.ST_PrimaryKey = false;
            this.ds_login.TabIndex = 56;
            // 
            // BB_Login
            // 
            this.BB_Login.Image = ((System.Drawing.Image)(resources.GetObject("BB_Login.Image")));
            this.BB_Login.Location = new System.Drawing.Point(180, 56);
            this.BB_Login.Name = "BB_Login";
            this.BB_Login.Size = new System.Drawing.Size(30, 20);
            this.BB_Login.TabIndex = 4;
            this.BB_Login.UseVisualStyleBackColor = true;
            this.BB_Login.Click += new System.EventHandler(this.BB_Login_Click);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.SystemColors.Window;
            this.login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.Location = new System.Drawing.Point(107, 55);
            this.login.MaxLength = 10;
            this.login.Name = "login";
            this.login.NM_Alias = "a";
            this.login.NM_Campo = "login";
            this.login.NM_CampoBusca = "login";
            this.login.NM_Param = "";
            this.login.QTD_Zero = 0;
            this.login.Size = new System.Drawing.Size(70, 20);
            this.login.ST_AutoInc = false;
            this.login.ST_DisableAuto = false;
            this.login.ST_Float = false;
            this.login.ST_Gravar = true;
            this.login.ST_Int = true;
            this.login.ST_LimpaCampo = true;
            this.login.ST_NotNull = false;
            this.login.ST_PrimaryKey = false;
            this.login.TabIndex = 3;
            this.login.Leave += new System.EventHandler(this.login_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Clifor:";
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.Enabled = false;
            this.NM_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NM_Clifor.Location = new System.Drawing.Point(214, 32);
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "c";
            this.NM_Clifor.NM_Campo = "NM_Clifor";
            this.NM_Clifor.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.Size = new System.Drawing.Size(400, 20);
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = true;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = false;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TabIndex = 48;
            // 
            // BB_Clifor
            // 
            this.BB_Clifor.Image = ((System.Drawing.Image)(resources.GetObject("BB_Clifor.Image")));
            this.BB_Clifor.Location = new System.Drawing.Point(180, 31);
            this.BB_Clifor.Name = "BB_Clifor";
            this.BB_Clifor.Size = new System.Drawing.Size(30, 20);
            this.BB_Clifor.TabIndex = 2;
            this.BB_Clifor.UseVisualStyleBackColor = true;
            this.BB_Clifor.Click += new System.EventHandler(this.BB_Clifor_Click);
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_Clifor.Location = new System.Drawing.Point(107, 32);
            this.CD_Clifor.MaxLength = 4;
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "a";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.Size = new System.Drawing.Size(70, 20);
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = true;
            this.CD_Clifor.ST_Int = true;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = false;
            this.CD_Clifor.ST_PrimaryKey = false;
            this.CD_Clifor.TabIndex = 1;
            this.CD_Clifor.Leave += new System.EventHandler(this.CD_Clifor_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Cód. Consulta:";
            // 
            // BS_Consulta
            // 
            this.BS_Consulta.DataSource = typeof(CamadaDados.Consulta.Cadastro.TList_Cad_Consulta);
            // 
            // grid_Consulta
            // 
            this.grid_Consulta.AllowUserToAddRows = false;
            this.grid_Consulta.AllowUserToDeleteRows = false;
            this.grid_Consulta.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.grid_Consulta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grid_Consulta.AutoGenerateColumns = false;
            this.grid_Consulta.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid_Consulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_Consulta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Consulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grid_Consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Consulta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDConsultaDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.dSConsultaDataGridViewTextBoxColumn,
            this.dTConsultaDataGridViewTextBoxColumn});
            this.grid_Consulta.DataSource = this.BS_Consulta;
            this.grid_Consulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Consulta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grid_Consulta.Location = new System.Drawing.Point(0, 110);
            this.grid_Consulta.MultiSelect = false;
            this.grid_Consulta.Name = "grid_Consulta";
            this.grid_Consulta.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Consulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grid_Consulta.RowHeadersWidth = 23;
            this.grid_Consulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_Consulta.Size = new System.Drawing.Size(630, 315);
            this.grid_Consulta.TabIndex = 1;
            // 
            // iDConsultaDataGridViewTextBoxColumn
            // 
            this.iDConsultaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDConsultaDataGridViewTextBoxColumn.DataPropertyName = "ID_Consulta";
            this.iDConsultaDataGridViewTextBoxColumn.HeaderText = "Cód. Consulta";
            this.iDConsultaDataGridViewTextBoxColumn.Name = "iDConsultaDataGridViewTextBoxColumn";
            this.iDConsultaDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDConsultaDataGridViewTextBoxColumn.Width = 98;
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
            // dSConsultaDataGridViewTextBoxColumn
            // 
            this.dSConsultaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSConsultaDataGridViewTextBoxColumn.DataPropertyName = "DS_Consulta";
            this.dSConsultaDataGridViewTextBoxColumn.HeaderText = "Consulta";
            this.dSConsultaDataGridViewTextBoxColumn.Name = "dSConsultaDataGridViewTextBoxColumn";
            this.dSConsultaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSConsultaDataGridViewTextBoxColumn.Width = 73;
            // 
            // dTConsultaDataGridViewTextBoxColumn
            // 
            this.dTConsultaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dTConsultaDataGridViewTextBoxColumn.DataPropertyName = "DT_Consulta";
            this.dTConsultaDataGridViewTextBoxColumn.HeaderText = "Data Consulta";
            this.dTConsultaDataGridViewTextBoxColumn.Name = "dTConsultaDataGridViewTextBoxColumn";
            this.dTConsultaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dTConsultaDataGridViewTextBoxColumn.Width = 99;
            // 
            // BN_Consulta
            // 
            this.BN_Consulta.AddNewItem = null;
            this.BN_Consulta.BindingSource = this.BS_Consulta;
            this.BN_Consulta.CountItem = this.bindingNavigatorCountItem;
            this.BN_Consulta.DeleteItem = null;
            this.BN_Consulta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_Consulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_Consulta.Location = new System.Drawing.Point(0, 425);
            this.BN_Consulta.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_Consulta.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_Consulta.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_Consulta.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_Consulta.Name = "BN_Consulta";
            this.BN_Consulta.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_Consulta.Size = new System.Drawing.Size(630, 25);
            this.BN_Consulta.TabIndex = 2;
            this.BN_Consulta.Text = "bindingNavigator1";
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
            // TFVisualizar_Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(642, 523);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TFVisualizar_Consulta";
            this.Text = "Visualizador de Consultas";
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            this.tabSQLConsulta.ResumeLayout(false);
            this.groupBoxSQL.ResumeLayout(false);
            this.groupBoxSQL.PerformLayout();
            this.tabVisualizar.ResumeLayout(false);
            this.groupBoxGrid.ResumeLayout(false);
            this.groupBoxGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Visualizador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Visualizador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Visualidor)).EndInit();
            this.BN_Visualidor.ResumeLayout(false);
            this.BN_Visualidor.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Consulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Consulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Consulta)).EndInit();
            this.BN_Consulta.ResumeLayout(false);
            this.BN_Consulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabSQLConsulta;
        private System.Windows.Forms.TabPage tabVisualizar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource BS_Consulta;
        private Componentes.DataGridDefault grid_Consulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDConsultaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSConsultaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTConsultaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator BN_Consulta;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault ID_Consulta;
        private Componentes.EditDefault DS_Consulta;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault ds_login;
        private System.Windows.Forms.Button BB_Login;
        private Componentes.EditDefault login;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault NM_Clifor;
        private System.Windows.Forms.Button BB_Clifor;
        private Componentes.EditDefault CD_Clifor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxSQL;
        private Componentes.EditDefault DS_SQL;
        private System.Windows.Forms.GroupBox groupBoxGrid;
        private System.Windows.Forms.BindingSource BS_Visualizador;
        private Componentes.DataGridDefault Grid_Visualizador;
        private System.Windows.Forms.BindingNavigator BN_Visualidor;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
    }
}
