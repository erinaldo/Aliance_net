namespace Parametros.Diversos
{
    partial class TFLogEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLogEmail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scDefault = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.pFiltros = new Componentes.PanelDados(this.components);
            this.st_emailLogin = new Componentes.CheckBoxDefault(this.components);
            this.panelDados6 = new Componentes.PanelDados(this.components);
            this.dt_final = new Componentes.EditData(this.components);
            this.dt_inicial = new Componentes.EditData(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.mensagem = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.titulo = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.destinatario = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.gLogEmail = new Componentes.DataGridDefault(this.components);
            this.Loginremetente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSDestinatarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dt_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSTituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsLogEmail = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.DS_MENSAGEM = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.pAnexo = new Componentes.PanelDados(this.components);
            this.lbAnexos = new System.Windows.Forms.ListBox();
            this.lblConciliacao = new System.Windows.Forms.Label();
            this.scDefault.Panel1.SuspendLayout();
            this.scDefault.Panel2.SuspendLayout();
            this.scDefault.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltros.SuspendLayout();
            this.panelDados6.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gLogEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLogEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.pAnexo.SuspendLayout();
            this.SuspendLayout();
            // 
            // scDefault
            // 
            this.scDefault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.scDefault, "scDefault");
            this.scDefault.Name = "scDefault";
            // 
            // scDefault.Panel1
            // 
            this.scDefault.Panel1.Controls.Add(this.pGrid);
            // 
            // scDefault.Panel2
            // 
            this.scDefault.Panel2.Controls.Add(this.tableLayoutPanel1);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pAnexo, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Buscar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Buscar
            // 
            resources.ApplyResources(this.BB_Buscar, "BB_Buscar");
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tlpCentral
            // 
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.Controls.Add(this.pFiltros, 0, 0);
            this.tlpCentral.Controls.Add(this.scDefault, 0, 1);
            this.tlpCentral.Name = "tlpCentral";
            // 
            // BB_Fechar
            // 
            resources.ApplyResources(this.BB_Fechar, "BB_Fechar");
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // pFiltros
            // 
            this.pFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltros.Controls.Add(this.st_emailLogin);
            this.pFiltros.Controls.Add(this.panelDados6);
            this.pFiltros.Controls.Add(this.mensagem);
            this.pFiltros.Controls.Add(this.label4);
            this.pFiltros.Controls.Add(this.titulo);
            this.pFiltros.Controls.Add(this.label3);
            this.pFiltros.Controls.Add(this.destinatario);
            this.pFiltros.Controls.Add(this.label2);
            resources.ApplyResources(this.pFiltros, "pFiltros");
            this.pFiltros.Name = "pFiltros";
            this.pFiltros.NM_ProcDeletar = "";
            this.pFiltros.NM_ProcGravar = "";
            // 
            // st_emailLogin
            // 
            resources.ApplyResources(this.st_emailLogin, "st_emailLogin");
            this.st_emailLogin.Name = "st_emailLogin";
            this.st_emailLogin.NM_Alias = "";
            this.st_emailLogin.NM_Campo = "";
            this.st_emailLogin.NM_Param = "";
            this.st_emailLogin.ST_Gravar = false;
            this.st_emailLogin.ST_LimparCampo = true;
            this.st_emailLogin.ST_NotNull = false;
            this.st_emailLogin.UseVisualStyleBackColor = true;
            this.st_emailLogin.Vl_False = "";
            this.st_emailLogin.Vl_True = "";
            // 
            // panelDados6
            // 
            this.panelDados6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.panelDados6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados6.Controls.Add(this.dt_final);
            this.panelDados6.Controls.Add(this.dt_inicial);
            this.panelDados6.Controls.Add(this.label25);
            this.panelDados6.Controls.Add(this.label26);
            resources.ApplyResources(this.panelDados6, "panelDados6");
            this.panelDados6.Name = "panelDados6";
            this.panelDados6.NM_ProcDeletar = "";
            this.panelDados6.NM_ProcGravar = "";
            // 
            // dt_final
            // 
            this.dt_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.dt_final, "dt_final");
            this.dt_final.Name = "dt_final";
            this.dt_final.NM_Alias = "";
            this.dt_final.NM_Campo = "DT_NascFirma";
            this.dt_final.NM_CampoBusca = "DT_NascFirma";
            this.dt_final.NM_Param = "@P_DT_NASCIMENTO";
            this.dt_final.Operador = "";
            this.dt_final.ST_Gravar = true;
            this.dt_final.ST_LimpaCampo = true;
            this.dt_final.ST_NotNull = false;
            this.dt_final.ST_PrimaryKey = false;
            // 
            // dt_inicial
            // 
            this.dt_inicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.dt_inicial, "dt_inicial");
            this.dt_inicial.Name = "dt_inicial";
            this.dt_inicial.NM_Alias = "";
            this.dt_inicial.NM_Campo = "DT_NascFirma";
            this.dt_inicial.NM_CampoBusca = "DT_NascFirma";
            this.dt_inicial.NM_Param = "@P_DT_NASCIMENTO";
            this.dt_inicial.Operador = "";
            this.dt_inicial.ST_Gravar = true;
            this.dt_inicial.ST_LimpaCampo = true;
            this.dt_inicial.ST_NotNull = false;
            this.dt_inicial.ST_PrimaryKey = false;
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // mensagem
            // 
            this.mensagem.BackColor = System.Drawing.SystemColors.Window;
            this.mensagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mensagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.mensagem, "mensagem");
            this.mensagem.Name = "mensagem";
            this.mensagem.NM_Alias = "";
            this.mensagem.NM_Campo = "";
            this.mensagem.NM_CampoBusca = "";
            this.mensagem.NM_Param = "";
            this.mensagem.QTD_Zero = 0;
            this.mensagem.ST_AutoInc = false;
            this.mensagem.ST_DisableAuto = false;
            this.mensagem.ST_Float = false;
            this.mensagem.ST_Gravar = false;
            this.mensagem.ST_Int = false;
            this.mensagem.ST_LimpaCampo = true;
            this.mensagem.ST_NotNull = false;
            this.mensagem.ST_PrimaryKey = false;
            this.mensagem.TextOld = null;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // titulo
            // 
            this.titulo.BackColor = System.Drawing.SystemColors.Window;
            this.titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.titulo, "titulo");
            this.titulo.Name = "titulo";
            this.titulo.NM_Alias = "";
            this.titulo.NM_Campo = "";
            this.titulo.NM_CampoBusca = "";
            this.titulo.NM_Param = "";
            this.titulo.QTD_Zero = 0;
            this.titulo.ST_AutoInc = false;
            this.titulo.ST_DisableAuto = false;
            this.titulo.ST_Float = false;
            this.titulo.ST_Gravar = false;
            this.titulo.ST_Int = false;
            this.titulo.ST_LimpaCampo = true;
            this.titulo.ST_NotNull = false;
            this.titulo.ST_PrimaryKey = false;
            this.titulo.TextOld = null;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // destinatario
            // 
            this.destinatario.BackColor = System.Drawing.SystemColors.Window;
            this.destinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.destinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.destinatario, "destinatario");
            this.destinatario.Name = "destinatario";
            this.destinatario.NM_Alias = "";
            this.destinatario.NM_Campo = "";
            this.destinatario.NM_CampoBusca = "";
            this.destinatario.NM_Param = "";
            this.destinatario.QTD_Zero = 0;
            this.destinatario.ST_AutoInc = false;
            this.destinatario.ST_DisableAuto = false;
            this.destinatario.ST_Float = false;
            this.destinatario.ST_Gravar = false;
            this.destinatario.ST_Int = false;
            this.destinatario.ST_LimpaCampo = true;
            this.destinatario.ST_NotNull = false;
            this.destinatario.ST_PrimaryKey = false;
            this.destinatario.TextOld = null;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // pGrid
            // 
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pGrid.Controls.Add(this.gLogEmail);
            this.pGrid.Controls.Add(this.bindingNavigator1);
            resources.ApplyResources(this.pGrid, "pGrid");
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            // 
            // gLogEmail
            // 
            this.gLogEmail.AllowUserToAddRows = false;
            this.gLogEmail.AllowUserToDeleteRows = false;
            this.gLogEmail.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gLogEmail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gLogEmail.AutoGenerateColumns = false;
            this.gLogEmail.BackgroundColor = System.Drawing.Color.LightGray;
            this.gLogEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gLogEmail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gLogEmail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gLogEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gLogEmail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Loginremetente,
            this.dSDestinatarioDataGridViewTextBoxColumn,
            this.Dt_email,
            this.dSTituloDataGridViewTextBoxColumn});
            this.gLogEmail.DataSource = this.bsLogEmail;
            resources.ApplyResources(this.gLogEmail, "gLogEmail");
            this.gLogEmail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gLogEmail.Name = "gLogEmail";
            this.gLogEmail.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gLogEmail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gLogEmail.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gLogEmail_ColumnHeaderMouseClick);
            // 
            // Loginremetente
            // 
            this.Loginremetente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Loginremetente.DataPropertyName = "Loginremetente";
            resources.ApplyResources(this.Loginremetente, "Loginremetente");
            this.Loginremetente.Name = "Loginremetente";
            this.Loginremetente.ReadOnly = true;
            // 
            // dSDestinatarioDataGridViewTextBoxColumn
            // 
            this.dSDestinatarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSDestinatarioDataGridViewTextBoxColumn.DataPropertyName = "DS_Destinatario";
            resources.ApplyResources(this.dSDestinatarioDataGridViewTextBoxColumn, "dSDestinatarioDataGridViewTextBoxColumn");
            this.dSDestinatarioDataGridViewTextBoxColumn.Name = "dSDestinatarioDataGridViewTextBoxColumn";
            this.dSDestinatarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Dt_email
            // 
            this.Dt_email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dt_email.DataPropertyName = "Dt_email";
            resources.ApplyResources(this.Dt_email, "Dt_email");
            this.Dt_email.Name = "Dt_email";
            this.Dt_email.ReadOnly = true;
            // 
            // dSTituloDataGridViewTextBoxColumn
            // 
            this.dSTituloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSTituloDataGridViewTextBoxColumn.DataPropertyName = "DS_Titulo";
            resources.ApplyResources(this.dSTituloDataGridViewTextBoxColumn, "dSTituloDataGridViewTextBoxColumn");
            this.dSTituloDataGridViewTextBoxColumn.Name = "dSTituloDataGridViewTextBoxColumn";
            this.dSTituloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsLogEmail
            // 
            this.bsLogEmail.DataSource = typeof(CamadaDados.Diversos.TList_CadLogEmail);
            this.bsLogEmail.PositionChanged += new System.EventHandler(this.bsLogEmail_PositionChanged);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsLogEmail;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.DS_MENSAGEM);
            this.panelDados1.Controls.Add(this.label5);
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // DS_MENSAGEM
            // 
            this.DS_MENSAGEM.BackColor = System.Drawing.SystemColors.Window;
            this.DS_MENSAGEM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_MENSAGEM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_MENSAGEM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLogEmail, "Mensagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_MENSAGEM, "DS_MENSAGEM");
            this.DS_MENSAGEM.Name = "DS_MENSAGEM";
            this.DS_MENSAGEM.NM_Alias = "";
            this.DS_MENSAGEM.NM_Campo = "";
            this.DS_MENSAGEM.NM_CampoBusca = "";
            this.DS_MENSAGEM.NM_Param = "";
            this.DS_MENSAGEM.QTD_Zero = 0;
            this.DS_MENSAGEM.ST_AutoInc = false;
            this.DS_MENSAGEM.ST_DisableAuto = false;
            this.DS_MENSAGEM.ST_Float = false;
            this.DS_MENSAGEM.ST_Gravar = false;
            this.DS_MENSAGEM.ST_Int = false;
            this.DS_MENSAGEM.ST_LimpaCampo = true;
            this.DS_MENSAGEM.ST_NotNull = false;
            this.DS_MENSAGEM.ST_PrimaryKey = false;
            this.DS_MENSAGEM.TextOld = null;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label5, "label5");
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // pAnexo
            // 
            this.pAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAnexo.Controls.Add(this.lbAnexos);
            this.pAnexo.Controls.Add(this.lblConciliacao);
            resources.ApplyResources(this.pAnexo, "pAnexo");
            this.pAnexo.Name = "pAnexo";
            this.pAnexo.NM_ProcDeletar = "";
            this.pAnexo.NM_ProcGravar = "";
            // 
            // lbAnexos
            // 
            resources.ApplyResources(this.lbAnexos, "lbAnexos");
            this.lbAnexos.FormattingEnabled = true;
            this.lbAnexos.Name = "lbAnexos";
            this.lbAnexos.DoubleClick += new System.EventHandler(this.lbAnexos_DoubleClick);
            // 
            // lblConciliacao
            // 
            this.lblConciliacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.lblConciliacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblConciliacao, "lblConciliacao");
            this.lblConciliacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblConciliacao.ForeColor = System.Drawing.Color.White;
            this.lblConciliacao.Name = "lblConciliacao";
            // 
            // TFLogEmail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFLogEmail";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFLogEmail_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLogEmail_KeyDown);
            this.scDefault.Panel1.ResumeLayout(false);
            this.scDefault.Panel2.ResumeLayout(false);
            this.scDefault.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltros.ResumeLayout(false);
            this.pFiltros.PerformLayout();
            this.panelDados6.ResumeLayout(false);
            this.panelDados6.PerformLayout();
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gLogEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLogEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.pAnexo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltros;
        private Componentes.PanelDados pGrid;
        private Componentes.DataGridDefault gLogEmail;
        private System.Windows.Forms.BindingSource bsLogEmail;
        private Componentes.EditDefault mensagem;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault titulo;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault destinatario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.PanelDados panelDados6;
        private Componentes.EditData dt_final;
        private Componentes.EditData dt_inicial;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer scDefault;
        private Componentes.PanelDados pAnexo;
        private Componentes.EditDefault DS_MENSAGEM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblConciliacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.ListBox lbAnexos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loginremetente;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSDestinatarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSTituloDataGridViewTextBoxColumn;
        private Componentes.CheckBoxDefault st_emailLogin;
    }
}