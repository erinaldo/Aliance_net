namespace Parametros.Diversos
{
    partial class TFCopiarPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCopiarPerfil));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pLoginImport = new Componentes.PanelDados(this.components);
            this.bsUsuario = new System.Windows.Forms.BindingSource(this.components);
            this.pUsuario = new Componentes.PanelDados(this.components);
            this.email_padrao = new Componentes.EditDefault(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.Login = new Componentes.EditDefault(this.components);
            this.Nome_Usuario = new Componentes.EditDefault(this.components);
            this.rgConfig = new Componentes.RadioGroup(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.qt_diasexpirar = new Componentes.EditFloat(this.components);
            this.st_AlterarSenha = new Componentes.CheckBoxDefault(this.components);
            this.ST_ExpirarSenha = new Componentes.CheckBoxDefault(this.components);
            this.LB_QT_DiasExpirar = new System.Windows.Forms.Label();
            this.Senha = new Componentes.EditDefault(this.components);
            this.LB_Nome_Usuario = new System.Windows.Forms.Label();
            this.LB_Login = new System.Windows.Forms.Label();
            this.LB_Senha = new System.Windows.Forms.Label();
            this.login_import = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bb_usuario = new System.Windows.Forms.Button();
            this.nm_usuario = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pLoginImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuario)).BeginInit();
            this.pUsuario.SuspendLayout();
            this.rgConfig.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qt_diasexpirar)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(635, 43);
            this.barraMenu.TabIndex = 12;
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
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
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
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pUsuario, 0, 1);
            this.tlpCentral.Controls.Add(this.pLoginImport, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(635, 134);
            this.tlpCentral.TabIndex = 13;
            // 
            // pLoginImport
            // 
            this.pLoginImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pLoginImport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLoginImport.Controls.Add(this.nm_usuario);
            this.pLoginImport.Controls.Add(this.bb_usuario);
            this.pLoginImport.Controls.Add(this.login_import);
            this.pLoginImport.Controls.Add(this.label1);
            this.pLoginImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLoginImport.Location = new System.Drawing.Point(5, 5);
            this.pLoginImport.Name = "pLoginImport";
            this.pLoginImport.NM_ProcDeletar = "";
            this.pLoginImport.NM_ProcGravar = "";
            this.pLoginImport.Size = new System.Drawing.Size(625, 28);
            this.pLoginImport.TabIndex = 0;
            // 
            // bsUsuario
            // 
            this.bsUsuario.DataSource = typeof(CamadaDados.Diversos.TList_CadUsuario);
            // 
            // pUsuario
            // 
            this.pUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pUsuario.Controls.Add(this.email_padrao);
            this.pUsuario.Controls.Add(this.label16);
            this.pUsuario.Controls.Add(this.Login);
            this.pUsuario.Controls.Add(this.Nome_Usuario);
            this.pUsuario.Controls.Add(this.rgConfig);
            this.pUsuario.Controls.Add(this.Senha);
            this.pUsuario.Controls.Add(this.LB_Nome_Usuario);
            this.pUsuario.Controls.Add(this.LB_Login);
            this.pUsuario.Controls.Add(this.LB_Senha);
            this.pUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pUsuario.Location = new System.Drawing.Point(5, 41);
            this.pUsuario.Name = "pUsuario";
            this.pUsuario.NM_ProcDeletar = "";
            this.pUsuario.NM_ProcGravar = "";
            this.pUsuario.Size = new System.Drawing.Size(625, 88);
            this.pUsuario.TabIndex = 1;
            // 
            // email_padrao
            // 
            this.email_padrao.BackColor = System.Drawing.SystemColors.Window;
            this.email_padrao.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.email_padrao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsUsuario, "Email_padrao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.email_padrao.Location = new System.Drawing.Point(89, 60);
            this.email_padrao.Name = "email_padrao";
            this.email_padrao.NM_Alias = "";
            this.email_padrao.NM_Campo = "email_padrao";
            this.email_padrao.NM_CampoBusca = "email_padrao";
            this.email_padrao.NM_Param = "@P_EMAIL_PADRAO";
            this.email_padrao.QTD_Zero = 0;
            this.email_padrao.Size = new System.Drawing.Size(311, 20);
            this.email_padrao.ST_AutoInc = false;
            this.email_padrao.ST_DisableAuto = false;
            this.email_padrao.ST_Float = false;
            this.email_padrao.ST_Gravar = true;
            this.email_padrao.ST_Int = false;
            this.email_padrao.ST_LimpaCampo = true;
            this.email_padrao.ST_NotNull = false;
            this.email_padrao.ST_PrimaryKey = false;
            this.email_padrao.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(9, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "Email Usuário:";
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Login.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsUsuario, "Login", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Login.Location = new System.Drawing.Point(89, 9);
            this.Login.Name = "Login";
            this.Login.NM_Alias = "";
            this.Login.NM_Campo = "Login";
            this.Login.NM_CampoBusca = "Login";
            this.Login.NM_Param = "@P_LOGIN";
            this.Login.QTD_Zero = 0;
            this.Login.Size = new System.Drawing.Size(108, 20);
            this.Login.ST_AutoInc = false;
            this.Login.ST_DisableAuto = false;
            this.Login.ST_Float = false;
            this.Login.ST_Gravar = true;
            this.Login.ST_Int = false;
            this.Login.ST_LimpaCampo = true;
            this.Login.ST_NotNull = true;
            this.Login.ST_PrimaryKey = false;
            this.Login.TabIndex = 0;
            this.Login.Leave += new System.EventHandler(this.Login_Leave);
            // 
            // Nome_Usuario
            // 
            this.Nome_Usuario.BackColor = System.Drawing.SystemColors.Window;
            this.Nome_Usuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nome_Usuario.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsUsuario, "Nome_usuario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nome_Usuario.Location = new System.Drawing.Point(89, 35);
            this.Nome_Usuario.Name = "Nome_Usuario";
            this.Nome_Usuario.NM_Alias = "";
            this.Nome_Usuario.NM_Campo = "Nome_Usuario";
            this.Nome_Usuario.NM_CampoBusca = "Nome_Usuario";
            this.Nome_Usuario.NM_Param = "@P_NOME_USUARIO";
            this.Nome_Usuario.QTD_Zero = 0;
            this.Nome_Usuario.Size = new System.Drawing.Size(311, 20);
            this.Nome_Usuario.ST_AutoInc = false;
            this.Nome_Usuario.ST_DisableAuto = false;
            this.Nome_Usuario.ST_Float = false;
            this.Nome_Usuario.ST_Gravar = true;
            this.Nome_Usuario.ST_Int = false;
            this.Nome_Usuario.ST_LimpaCampo = true;
            this.Nome_Usuario.ST_NotNull = false;
            this.Nome_Usuario.ST_PrimaryKey = false;
            this.Nome_Usuario.TabIndex = 2;
            // 
            // rgConfig
            // 
            this.rgConfig.Controls.Add(this.panelDados2);
            this.rgConfig.Location = new System.Drawing.Point(406, 3);
            this.rgConfig.Name = "rgConfig";
            this.rgConfig.NM_Alias = "";
            this.rgConfig.NM_Campo = "";
            this.rgConfig.NM_Param = "";
            this.rgConfig.NM_Valor = "";
            this.rgConfig.Size = new System.Drawing.Size(209, 77);
            this.rgConfig.ST_Gravar = false;
            this.rgConfig.ST_NotNull = false;
            this.rgConfig.TabIndex = 4;
            this.rgConfig.TabStop = false;
            this.rgConfig.Text = "Configurações:";
            // 
            // panelDados2
            // 
            this.panelDados2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados2.Controls.Add(this.qt_diasexpirar);
            this.panelDados2.Controls.Add(this.st_AlterarSenha);
            this.panelDados2.Controls.Add(this.ST_ExpirarSenha);
            this.panelDados2.Controls.Add(this.LB_QT_DiasExpirar);
            this.panelDados2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.panelDados2.Location = new System.Drawing.Point(6, 12);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(197, 60);
            this.panelDados2.TabIndex = 0;
            this.panelDados2.TabStop = true;
            // 
            // qt_diasexpirar
            // 
            this.qt_diasexpirar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsUsuario, "Qt_DiasExpirar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qt_diasexpirar.Location = new System.Drawing.Point(125, 7);
            this.qt_diasexpirar.Name = "qt_diasexpirar";
            this.qt_diasexpirar.NM_Alias = "";
            this.qt_diasexpirar.NM_Campo = "";
            this.qt_diasexpirar.NM_Param = "";
            this.qt_diasexpirar.Operador = "";
            this.qt_diasexpirar.Size = new System.Drawing.Size(34, 20);
            this.qt_diasexpirar.ST_AutoInc = false;
            this.qt_diasexpirar.ST_DisableAuto = false;
            this.qt_diasexpirar.ST_Gravar = true;
            this.qt_diasexpirar.ST_LimparCampo = true;
            this.qt_diasexpirar.ST_NotNull = false;
            this.qt_diasexpirar.ST_PrimaryKey = false;
            this.qt_diasexpirar.TabIndex = 1;
            this.qt_diasexpirar.ThousandsSeparator = true;
            // 
            // st_AlterarSenha
            // 
            this.st_AlterarSenha.AutoSize = true;
            this.st_AlterarSenha.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsUsuario, "St_alterarsenhabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_AlterarSenha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_AlterarSenha.Location = new System.Drawing.Point(3, 32);
            this.st_AlterarSenha.Name = "st_AlterarSenha";
            this.st_AlterarSenha.NM_Alias = "";
            this.st_AlterarSenha.NM_Campo = "ST_ALTERARSENHA";
            this.st_AlterarSenha.NM_Param = "@P_ST_ALTERARSENHA";
            this.st_AlterarSenha.Size = new System.Drawing.Size(189, 17);
            this.st_AlterarSenha.ST_Gravar = true;
            this.st_AlterarSenha.ST_LimparCampo = false;
            this.st_AlterarSenha.ST_NotNull = false;
            this.st_AlterarSenha.TabIndex = 2;
            this.st_AlterarSenha.Text = "Alterar Senha no Prox. Login";
            this.st_AlterarSenha.UseVisualStyleBackColor = true;
            this.st_AlterarSenha.Vl_False = "N";
            this.st_AlterarSenha.Vl_True = "S";
            // 
            // ST_ExpirarSenha
            // 
            this.ST_ExpirarSenha.AutoSize = true;
            this.ST_ExpirarSenha.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsUsuario, "St_expirarsenhabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_ExpirarSenha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ST_ExpirarSenha.Location = new System.Drawing.Point(3, 8);
            this.ST_ExpirarSenha.Name = "ST_ExpirarSenha";
            this.ST_ExpirarSenha.NM_Alias = "";
            this.ST_ExpirarSenha.NM_Campo = "ST_ExpirarSenha";
            this.ST_ExpirarSenha.NM_Param = "@P_ST_EXPIRARSENHA";
            this.ST_ExpirarSenha.Size = new System.Drawing.Size(125, 17);
            this.ST_ExpirarSenha.ST_Gravar = true;
            this.ST_ExpirarSenha.ST_LimparCampo = false;
            this.ST_ExpirarSenha.ST_NotNull = false;
            this.ST_ExpirarSenha.TabIndex = 0;
            this.ST_ExpirarSenha.Text = "Expirar Senha em";
            this.ST_ExpirarSenha.UseVisualStyleBackColor = true;
            this.ST_ExpirarSenha.Vl_False = "N";
            this.ST_ExpirarSenha.Vl_True = "S";
            // 
            // LB_QT_DiasExpirar
            // 
            this.LB_QT_DiasExpirar.AutoSize = true;
            this.LB_QT_DiasExpirar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_QT_DiasExpirar.Location = new System.Drawing.Point(159, 9);
            this.LB_QT_DiasExpirar.Name = "LB_QT_DiasExpirar";
            this.LB_QT_DiasExpirar.Size = new System.Drawing.Size(36, 13);
            this.LB_QT_DiasExpirar.TabIndex = 6;
            this.LB_QT_DiasExpirar.Text = "Dias.";
            // 
            // Senha
            // 
            this.Senha.BackColor = System.Drawing.SystemColors.Window;
            this.Senha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Senha.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsUsuario, "Senha", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Senha.Location = new System.Drawing.Point(250, 9);
            this.Senha.Name = "Senha";
            this.Senha.NM_Alias = "";
            this.Senha.NM_Campo = "Senha";
            this.Senha.NM_CampoBusca = "Senha";
            this.Senha.NM_Param = "@P_SENHA";
            this.Senha.PasswordChar = '*';
            this.Senha.QTD_Zero = 0;
            this.Senha.Size = new System.Drawing.Size(108, 20);
            this.Senha.ST_AutoInc = false;
            this.Senha.ST_DisableAuto = false;
            this.Senha.ST_Float = false;
            this.Senha.ST_Gravar = true;
            this.Senha.ST_Int = false;
            this.Senha.ST_LimpaCampo = true;
            this.Senha.ST_NotNull = false;
            this.Senha.ST_PrimaryKey = false;
            this.Senha.TabIndex = 1;
            // 
            // LB_Nome_Usuario
            // 
            this.LB_Nome_Usuario.AutoSize = true;
            this.LB_Nome_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Nome_Usuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Nome_Usuario.Location = new System.Drawing.Point(6, 38);
            this.LB_Nome_Usuario.Name = "LB_Nome_Usuario";
            this.LB_Nome_Usuario.Size = new System.Drawing.Size(77, 13);
            this.LB_Nome_Usuario.TabIndex = 12;
            this.LB_Nome_Usuario.Text = "Nome Usuário:";
            // 
            // LB_Login
            // 
            this.LB_Login.AutoSize = true;
            this.LB_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Login.Location = new System.Drawing.Point(47, 12);
            this.LB_Login.Name = "LB_Login";
            this.LB_Login.Size = new System.Drawing.Size(36, 13);
            this.LB_Login.TabIndex = 9;
            this.LB_Login.Text = "Login:";
            // 
            // LB_Senha
            // 
            this.LB_Senha.AutoSize = true;
            this.LB_Senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Senha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Senha.Location = new System.Drawing.Point(203, 12);
            this.LB_Senha.Name = "LB_Senha";
            this.LB_Senha.Size = new System.Drawing.Size(41, 13);
            this.LB_Senha.TabIndex = 11;
            this.LB_Senha.Text = "Senha:";
            // 
            // login_import
            // 
            this.login_import.BackColor = System.Drawing.Color.White;
            this.login_import.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.login_import.Location = new System.Drawing.Point(89, 3);
            this.login_import.Name = "login_import";
            this.login_import.NM_Alias = "";
            this.login_import.NM_Campo = "Login";
            this.login_import.NM_CampoBusca = "Login";
            this.login_import.NM_Param = "@P_LOGIN";
            this.login_import.QTD_Zero = 0;
            this.login_import.Size = new System.Drawing.Size(108, 20);
            this.login_import.ST_AutoInc = false;
            this.login_import.ST_DisableAuto = false;
            this.login_import.ST_Float = false;
            this.login_import.ST_Gravar = true;
            this.login_import.ST_Int = false;
            this.login_import.ST_LimpaCampo = true;
            this.login_import.ST_NotNull = true;
            this.login_import.ST_PrimaryKey = false;
            this.login_import.TabIndex = 10;
            this.login_import.Leave += new System.EventHandler(this.login_import_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Login Origem:";
            // 
            // bb_usuario
            // 
            this.bb_usuario.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_usuario.Image = ((System.Drawing.Image)(resources.GetObject("bb_usuario.Image")));
            this.bb_usuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_usuario.Location = new System.Drawing.Point(199, 2);
            this.bb_usuario.Name = "bb_usuario";
            this.bb_usuario.Size = new System.Drawing.Size(30, 20);
            this.bb_usuario.TabIndex = 12;
            this.bb_usuario.UseVisualStyleBackColor = true;
            this.bb_usuario.Click += new System.EventHandler(this.bb_usuario_Click);
            // 
            // nm_usuario
            // 
            this.nm_usuario.BackColor = System.Drawing.Color.White;
            this.nm_usuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_usuario.Location = new System.Drawing.Point(235, 3);
            this.nm_usuario.Name = "nm_usuario";
            this.nm_usuario.NM_Alias = "";
            this.nm_usuario.NM_Campo = "nome_usuario";
            this.nm_usuario.NM_CampoBusca = "nome_usuario";
            this.nm_usuario.NM_Param = "@P_LOGIN";
            this.nm_usuario.QTD_Zero = 0;
            this.nm_usuario.Size = new System.Drawing.Size(380, 20);
            this.nm_usuario.ST_AutoInc = false;
            this.nm_usuario.ST_DisableAuto = false;
            this.nm_usuario.ST_Float = false;
            this.nm_usuario.ST_Gravar = true;
            this.nm_usuario.ST_Int = false;
            this.nm_usuario.ST_LimpaCampo = true;
            this.nm_usuario.ST_NotNull = true;
            this.nm_usuario.ST_PrimaryKey = false;
            this.nm_usuario.TabIndex = 13;
            // 
            // TFCopiarPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 177);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCopiarPerfil";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copiar Perfil Usuario";
            this.Load += new System.EventHandler(this.TFCopiarPerfil_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCopiarPerfil_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pLoginImport.ResumeLayout(false);
            this.pLoginImport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuario)).EndInit();
            this.pUsuario.ResumeLayout(false);
            this.pUsuario.PerformLayout();
            this.rgConfig.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qt_diasexpirar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pLoginImport;
        private System.Windows.Forms.BindingSource bsUsuario;
        private Componentes.PanelDados pUsuario;
        private Componentes.EditDefault email_padrao;
        private System.Windows.Forms.Label label16;
        private Componentes.EditDefault Login;
        private Componentes.EditDefault Nome_Usuario;
        private Componentes.RadioGroup rgConfig;
        private Componentes.PanelDados panelDados2;
        private Componentes.EditFloat qt_diasexpirar;
        private Componentes.CheckBoxDefault st_AlterarSenha;
        private Componentes.CheckBoxDefault ST_ExpirarSenha;
        private System.Windows.Forms.Label LB_QT_DiasExpirar;
        private Componentes.EditDefault Senha;
        private System.Windows.Forms.Label LB_Nome_Usuario;
        private System.Windows.Forms.Label LB_Login;
        private System.Windows.Forms.Label LB_Senha;
        private Componentes.EditDefault login_import;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault nm_usuario;
        public System.Windows.Forms.Button bb_usuario;
    }
}