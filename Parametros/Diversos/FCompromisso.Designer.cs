namespace Parametros.Diversos
{
    partial class TFCompromisso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCompromisso));
            this.pDados = new Componentes.PanelDados(this.components);
            this.st_enviaremail = new Componentes.CheckBoxDefault(this.components);
            this.bsComp = new System.Windows.Forms.BindingSource(this.components);
            this.ds_login = new Componentes.EditDefault(this.components);
            this.dt_compromisso = new Componentes.EditData(this.components);
            this.ds_compromisso = new Componentes.EditDefault(this.components);
            this.Descrição = new System.Windows.Forms.Label();
            this.login = new Componentes.EditDefault(this.components);
            this.BB_Usuario = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nm_compromisso = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.idCompromissoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDCompromissoStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmCompromissoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsCompromissoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCompromissoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hrCompromissoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCompromissoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioCompromissoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stCompromissoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bb_calcula = new System.Windows.Forms.ToolStripButton();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_gravar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancela = new System.Windows.Forms.ToolStripButton();
            this.email_padrao = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsComp)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.email_padrao);
            this.pDados.Controls.Add(this.st_enviaremail);
            this.pDados.Controls.Add(this.ds_login);
            this.pDados.Controls.Add(this.dt_compromisso);
            this.pDados.Controls.Add(this.ds_compromisso);
            this.pDados.Controls.Add(this.Descrição);
            this.pDados.Controls.Add(this.login);
            this.pDados.Controls.Add(this.BB_Usuario);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.nm_compromisso);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(581, 265);
            this.pDados.TabIndex = 0;
            // 
            // st_enviaremail
            // 
            this.st_enviaremail.AutoSize = true;
            this.st_enviaremail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.st_enviaremail.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsComp, "St_enviaremailbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_enviaremail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_enviaremail.Location = new System.Drawing.Point(345, 45);
            this.st_enviaremail.Name = "st_enviaremail";
            this.st_enviaremail.NM_Alias = "";
            this.st_enviaremail.NM_Campo = "";
            this.st_enviaremail.NM_Param = "";
            this.st_enviaremail.Size = new System.Drawing.Size(229, 17);
            this.st_enviaremail.ST_Gravar = false;
            this.st_enviaremail.ST_LimparCampo = true;
            this.st_enviaremail.ST_NotNull = false;
            this.st_enviaremail.TabIndex = 2;
            this.st_enviaremail.Text = "Enviar Email Avisando Compromisso";
            this.st_enviaremail.UseVisualStyleBackColor = true;
            this.st_enviaremail.Vl_False = "";
            this.st_enviaremail.Vl_True = "";
            // 
            // bsComp
            // 
            this.bsComp.DataSource = typeof(CamadaDados.Diversos.TList_LanCompromisso);
            // 
            // ds_login
            // 
            this.ds_login.BackColor = System.Drawing.SystemColors.Window;
            this.ds_login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_login.Enabled = false;
            this.ds_login.Location = new System.Drawing.Point(278, 70);
            this.ds_login.Name = "ds_login";
            this.ds_login.NM_Alias = "";
            this.ds_login.NM_Campo = "nome_usuario";
            this.ds_login.NM_CampoBusca = "nome_usuario";
            this.ds_login.NM_Param = "@P_NOME_USUARIO";
            this.ds_login.QTD_Zero = 0;
            this.ds_login.Size = new System.Drawing.Size(296, 20);
            this.ds_login.ST_AutoInc = false;
            this.ds_login.ST_DisableAuto = false;
            this.ds_login.ST_Float = false;
            this.ds_login.ST_Gravar = false;
            this.ds_login.ST_Int = false;
            this.ds_login.ST_LimpaCampo = true;
            this.ds_login.ST_NotNull = false;
            this.ds_login.ST_PrimaryKey = false;
            this.ds_login.TabIndex = 4;
            this.ds_login.TextOld = null;
            // 
            // dt_compromisso
            // 
            this.dt_compromisso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_compromisso.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComp, "DtCompromisso", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_compromisso.Location = new System.Drawing.Point(106, 44);
            this.dt_compromisso.Mask = "00/00/0000 00:00";
            this.dt_compromisso.Name = "dt_compromisso";
            this.dt_compromisso.NM_Alias = "";
            this.dt_compromisso.NM_Campo = "";
            this.dt_compromisso.NM_CampoBusca = "";
            this.dt_compromisso.NM_Param = "";
            this.dt_compromisso.Operador = "";
            this.dt_compromisso.Size = new System.Drawing.Size(109, 20);
            this.dt_compromisso.ST_Gravar = false;
            this.dt_compromisso.ST_LimpaCampo = true;
            this.dt_compromisso.ST_NotNull = true;
            this.dt_compromisso.ST_PrimaryKey = false;
            this.dt_compromisso.TabIndex = 1;
            this.dt_compromisso.ValidatingType = typeof(System.DateTime);
            // 
            // ds_compromisso
            // 
            this.ds_compromisso.BackColor = System.Drawing.SystemColors.Window;
            this.ds_compromisso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_compromisso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_compromisso.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComp, "Ds_Compromisso", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_compromisso.Location = new System.Drawing.Point(106, 122);
            this.ds_compromisso.Multiline = true;
            this.ds_compromisso.Name = "ds_compromisso";
            this.ds_compromisso.NM_Alias = "";
            this.ds_compromisso.NM_Campo = "";
            this.ds_compromisso.NM_CampoBusca = "";
            this.ds_compromisso.NM_Param = "";
            this.ds_compromisso.QTD_Zero = 0;
            this.ds_compromisso.Size = new System.Drawing.Size(468, 136);
            this.ds_compromisso.ST_AutoInc = false;
            this.ds_compromisso.ST_DisableAuto = false;
            this.ds_compromisso.ST_Float = false;
            this.ds_compromisso.ST_Gravar = false;
            this.ds_compromisso.ST_Int = false;
            this.ds_compromisso.ST_LimpaCampo = true;
            this.ds_compromisso.ST_NotNull = false;
            this.ds_compromisso.ST_PrimaryKey = false;
            this.ds_compromisso.TabIndex = 5;
            this.ds_compromisso.TextOld = null;
            // 
            // Descrição
            // 
            this.Descrição.AutoSize = true;
            this.Descrição.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Descrição.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Descrição.Location = new System.Drawing.Point(32, 124);
            this.Descrição.Name = "Descrição";
            this.Descrição.Size = new System.Drawing.Size(68, 13);
            this.Descrição.TabIndex = 74;
            this.Descrição.Text = "Descrição:";
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.SystemColors.Window;
            this.login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.login.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComp, "UsuarioCompromisso", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.login.Location = new System.Drawing.Point(106, 70);
            this.login.Name = "login";
            this.login.NM_Alias = "";
            this.login.NM_Campo = "login";
            this.login.NM_CampoBusca = "login";
            this.login.NM_Param = "@P_LOGIN";
            this.login.QTD_Zero = 0;
            this.login.Size = new System.Drawing.Size(130, 20);
            this.login.ST_AutoInc = false;
            this.login.ST_DisableAuto = false;
            this.login.ST_Float = false;
            this.login.ST_Gravar = false;
            this.login.ST_Int = false;
            this.login.ST_LimpaCampo = true;
            this.login.ST_NotNull = true;
            this.login.ST_PrimaryKey = false;
            this.login.TabIndex = 3;
            this.login.TextOld = null;
            this.login.Leave += new System.EventHandler(this.login_Leave);
            // 
            // BB_Usuario
            // 
            this.BB_Usuario.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Usuario.Image = ((System.Drawing.Image)(resources.GetObject("BB_Usuario.Image")));
            this.BB_Usuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Usuario.Location = new System.Drawing.Point(242, 70);
            this.BB_Usuario.Name = "BB_Usuario";
            this.BB_Usuario.Size = new System.Drawing.Size(30, 20);
            this.BB_Usuario.TabIndex = 4;
            this.BB_Usuario.UseVisualStyleBackColor = true;
            this.BB_Usuario.Click += new System.EventHandler(this.BB_Usuario_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(21, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Data / Hora:";
            // 
            // nm_compromisso
            // 
            this.nm_compromisso.BackColor = System.Drawing.SystemColors.Window;
            this.nm_compromisso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_compromisso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_compromisso.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComp, "Nm_Compromisso", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_compromisso.Location = new System.Drawing.Point(106, 18);
            this.nm_compromisso.Name = "nm_compromisso";
            this.nm_compromisso.NM_Alias = "";
            this.nm_compromisso.NM_Campo = "";
            this.nm_compromisso.NM_CampoBusca = "";
            this.nm_compromisso.NM_Param = "";
            this.nm_compromisso.QTD_Zero = 0;
            this.nm_compromisso.Size = new System.Drawing.Size(468, 20);
            this.nm_compromisso.ST_AutoInc = false;
            this.nm_compromisso.ST_DisableAuto = false;
            this.nm_compromisso.ST_Float = false;
            this.nm_compromisso.ST_Gravar = false;
            this.nm_compromisso.ST_Int = false;
            this.nm_compromisso.ST_LimpaCampo = true;
            this.nm_compromisso.ST_NotNull = true;
            this.nm_compromisso.ST_PrimaryKey = false;
            this.nm_compromisso.TabIndex = 0;
            this.nm_compromisso.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(46, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Usuário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Compromisso:";
            // 
            // idCompromissoDataGridViewTextBoxColumn
            // 
            this.idCompromissoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idCompromissoDataGridViewTextBoxColumn.DataPropertyName = "Id_Compromisso";
            this.idCompromissoDataGridViewTextBoxColumn.HeaderText = "Cód. Compromisso";
            this.idCompromissoDataGridViewTextBoxColumn.Name = "idCompromissoDataGridViewTextBoxColumn";
            this.idCompromissoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDCompromissoStringDataGridViewTextBoxColumn
            // 
            this.iDCompromissoStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDCompromissoStringDataGridViewTextBoxColumn.DataPropertyName = "ID_Compromisso_String";
            this.iDCompromissoStringDataGridViewTextBoxColumn.HeaderText = "Cód. Compromisso str";
            this.iDCompromissoStringDataGridViewTextBoxColumn.Name = "iDCompromissoStringDataGridViewTextBoxColumn";
            this.iDCompromissoStringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmCompromissoDataGridViewTextBoxColumn
            // 
            this.nmCompromissoDataGridViewTextBoxColumn.DataPropertyName = "Nm_Compromisso";
            this.nmCompromissoDataGridViewTextBoxColumn.HeaderText = "Compromisso";
            this.nmCompromissoDataGridViewTextBoxColumn.Name = "nmCompromissoDataGridViewTextBoxColumn";
            this.nmCompromissoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsCompromissoDataGridViewTextBoxColumn
            // 
            this.dsCompromissoDataGridViewTextBoxColumn.DataPropertyName = "Ds_Compromisso";
            this.dsCompromissoDataGridViewTextBoxColumn.HeaderText = "Desc. Compromisso";
            this.dsCompromissoDataGridViewTextBoxColumn.Name = "dsCompromissoDataGridViewTextBoxColumn";
            this.dsCompromissoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtCompromissoDataGridViewTextBoxColumn
            // 
            this.dtCompromissoDataGridViewTextBoxColumn.DataPropertyName = "Dt_Compromisso";
            this.dtCompromissoDataGridViewTextBoxColumn.HeaderText = "Dt Compromisso";
            this.dtCompromissoDataGridViewTextBoxColumn.Name = "dtCompromissoDataGridViewTextBoxColumn";
            this.dtCompromissoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hrCompromissoDataGridViewTextBoxColumn
            // 
            this.hrCompromissoDataGridViewTextBoxColumn.DataPropertyName = "Hr_Compromisso";
            this.hrCompromissoDataGridViewTextBoxColumn.HeaderText = "Hr Compromisso";
            this.hrCompromissoDataGridViewTextBoxColumn.Name = "hrCompromissoDataGridViewTextBoxColumn";
            this.hrCompromissoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtCompromissoDataGridViewTextBoxColumn1
            // 
            this.dtCompromissoDataGridViewTextBoxColumn1.DataPropertyName = "DtCompromisso";
            this.dtCompromissoDataGridViewTextBoxColumn1.HeaderText = "Dt Compromisso";
            this.dtCompromissoDataGridViewTextBoxColumn1.Name = "dtCompromissoDataGridViewTextBoxColumn1";
            this.dtCompromissoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // usuarioCompromissoDataGridViewTextBoxColumn
            // 
            this.usuarioCompromissoDataGridViewTextBoxColumn.DataPropertyName = "UsuarioCompromisso";
            this.usuarioCompromissoDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.usuarioCompromissoDataGridViewTextBoxColumn.Name = "usuarioCompromissoDataGridViewTextBoxColumn";
            this.usuarioCompromissoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stCompromissoDataGridViewCheckBoxColumn
            // 
            this.stCompromissoDataGridViewCheckBoxColumn.DataPropertyName = "St_Compromisso";
            this.stCompromissoDataGridViewCheckBoxColumn.HeaderText = "Status";
            this.stCompromissoDataGridViewCheckBoxColumn.Name = "stCompromissoDataGridViewCheckBoxColumn";
            this.stCompromissoDataGridViewCheckBoxColumn.ReadOnly = true;
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
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // bb_calcula
            // 
            this.bb_calcula.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_calcula.ForeColor = System.Drawing.Color.Green;
            this.bb_calcula.Image = ((System.Drawing.Image)(resources.GetObject("bb_calcula.Image")));
            this.bb_calcula.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bb_calcula.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_calcula.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_calcula.Name = "bb_calcula";
            this.bb_calcula.Size = new System.Drawing.Size(146, 40);
            this.bb_calcula.Text = "(F9)\r\n Simular Impostos";
            this.bb_calcula.ToolTipText = "Calcular Impostos";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_gravar,
            this.bb_cancela});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(581, 43);
            this.barraMenu.TabIndex = 21;
            // 
            // bb_gravar
            // 
            this.bb_gravar.AutoSize = false;
            this.bb_gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_gravar.ForeColor = System.Drawing.Color.Green;
            this.bb_gravar.Image = ((System.Drawing.Image)(resources.GetObject("bb_gravar.Image")));
            this.bb_gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_gravar.Name = "bb_gravar";
            this.bb_gravar.Size = new System.Drawing.Size(95, 40);
            this.bb_gravar.Text = "(F4)\r\nGravar";
            this.bb_gravar.ToolTipText = "Inutilizar NF-e";
            this.bb_gravar.Click += new System.EventHandler(this.bb_gravar_Click);
            // 
            // bb_cancela
            // 
            this.bb_cancela.AutoSize = false;
            this.bb_cancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancela.ForeColor = System.Drawing.Color.Green;
            this.bb_cancela.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancela.Image")));
            this.bb_cancela.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancela.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancela.Name = "bb_cancela";
            this.bb_cancela.Size = new System.Drawing.Size(95, 40);
            this.bb_cancela.Text = "(F6)\r\nCancelar";
            this.bb_cancela.ToolTipText = "Cancelar Procedimento";
            this.bb_cancela.Click += new System.EventHandler(this.bb_cancela_Click);
            // 
            // email_padrao
            // 
            this.email_padrao.BackColor = System.Drawing.SystemColors.Window;
            this.email_padrao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email_padrao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.email_padrao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComp, "EmailUsuarioCompromisso", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.email_padrao.Enabled = false;
            this.email_padrao.Location = new System.Drawing.Point(106, 96);
            this.email_padrao.Name = "email_padrao";
            this.email_padrao.NM_Alias = "";
            this.email_padrao.NM_Campo = "email_padrao";
            this.email_padrao.NM_CampoBusca = "email_padrao";
            this.email_padrao.NM_Param = "@P_NOME_USUARIO";
            this.email_padrao.QTD_Zero = 0;
            this.email_padrao.Size = new System.Drawing.Size(468, 20);
            this.email_padrao.ST_AutoInc = false;
            this.email_padrao.ST_DisableAuto = false;
            this.email_padrao.ST_Float = false;
            this.email_padrao.ST_Gravar = false;
            this.email_padrao.ST_Int = false;
            this.email_padrao.ST_LimpaCampo = true;
            this.email_padrao.ST_NotNull = false;
            this.email_padrao.ST_PrimaryKey = false;
            this.email_padrao.TabIndex = 75;
            this.email_padrao.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Email Usuário:";
            // 
            // TFCompromisso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(581, 308);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCompromisso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agendamento de Compromissos";
            this.Load += new System.EventHandler(this.TFCompromisso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCompromisso_KeyDown);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsComp)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn idCompromissoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCompromissoStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmCompromissoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsCompromissoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCompromissoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hrCompromissoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCompromissoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn htCompromissoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioCompromissoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stCompromissoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bb_calcula;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_gravar;
        private System.Windows.Forms.ToolStripButton bb_cancela;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label Descrição;
        private Componentes.EditDefault login;
        public System.Windows.Forms.Button BB_Usuario;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nm_compromisso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsComp;
        private Componentes.EditDefault ds_compromisso;
        private Componentes.EditData dt_compromisso;
        private Componentes.EditDefault ds_login;
        private Componentes.CheckBoxDefault st_enviaremail;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault email_padrao;
    }
}