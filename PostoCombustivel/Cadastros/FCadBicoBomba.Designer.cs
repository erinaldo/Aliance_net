namespace PostoCombustivel.Cadastros
{
    partial class TFCadBicoBomba
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadBicoBomba));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.dt_desativacao = new Componentes.EditData(this.components);
            this.bsBico = new System.Windows.Forms.BindingSource(this.components);
            this.lblDtDesativacao = new System.Windows.Forms.Label();
            this.st_registro = new Componentes.ComboBoxDefault(this.components);
            this.ds_label = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.enderecofisicobico = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bb_tanque = new System.Windows.Forms.Button();
            this.id_tanque = new Componentes.EditDefault(this.components);
            this.dt_ativacao = new Componentes.EditData(this.components);
            this.lblDtAtivacao = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBico)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(39, 32);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 13);
            label3.TabIndex = 66;
            label3.Text = "Tanque:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(19, 58);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(67, 13);
            label1.TabIndex = 69;
            label1.Text = "Combustivel:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(0, 84);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(86, 13);
            label2.TabIndex = 70;
            label2.Text = "End. Fisico Bico:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(35, 6);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(51, 13);
            label4.TabIndex = 73;
            label4.Text = "Empresa:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(144, 84);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(60, 13);
            label5.TabIndex = 75;
            label5.Text = "Label Bico:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(262, 84);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(40, 13);
            label6.TabIndex = 77;
            label6.Text = "Status:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(628, 43);
            this.barraMenu.TabIndex = 13;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.dt_ativacao);
            this.pDados.Controls.Add(this.lblDtAtivacao);
            this.pDados.Controls.Add(this.dt_desativacao);
            this.pDados.Controls.Add(this.lblDtDesativacao);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.st_registro);
            this.pDados.Controls.Add(this.ds_label);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.enderecofisicobico);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_tanque);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.id_tanque);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(628, 109);
            this.pDados.TabIndex = 14;
            // 
            // dt_desativacao
            // 
            this.dt_desativacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_desativacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBico, "Dt_desativacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_desativacao.Location = new System.Drawing.Point(552, 81);
            this.dt_desativacao.Mask = "00/00/0000";
            this.dt_desativacao.Name = "dt_desativacao";
            this.dt_desativacao.NM_Alias = "";
            this.dt_desativacao.NM_Campo = "";
            this.dt_desativacao.NM_CampoBusca = "";
            this.dt_desativacao.NM_Param = "";
            this.dt_desativacao.Operador = "";
            this.dt_desativacao.Size = new System.Drawing.Size(69, 20);
            this.dt_desativacao.ST_Gravar = true;
            this.dt_desativacao.ST_LimpaCampo = true;
            this.dt_desativacao.ST_NotNull = true;
            this.dt_desativacao.ST_PrimaryKey = false;
            this.dt_desativacao.TabIndex = 79;
            this.dt_desativacao.Visible = false;
            // 
            // bsBico
            // 
            this.bsBico.DataSource = typeof(CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba);
            // 
            // lblDtDesativacao
            // 
            this.lblDtDesativacao.AutoSize = true;
            this.lblDtDesativacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDtDesativacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDtDesativacao.Location = new System.Drawing.Point(459, 84);
            this.lblDtDesativacao.Name = "lblDtDesativacao";
            this.lblDtDesativacao.Size = new System.Drawing.Size(87, 13);
            this.lblDtDesativacao.TabIndex = 78;
            this.lblDtDesativacao.Text = "Dt. Desativação:";
            this.lblDtDesativacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDtDesativacao.Visible = false;
            // 
            // st_registro
            // 
            this.st_registro.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsBico, "St_registro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_registro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.st_registro.FormattingEnabled = true;
            this.st_registro.Location = new System.Drawing.Point(308, 80);
            this.st_registro.Name = "st_registro";
            this.st_registro.NM_Alias = "";
            this.st_registro.NM_Campo = "";
            this.st_registro.NM_Param = "";
            this.st_registro.Size = new System.Drawing.Size(147, 21);
            this.st_registro.ST_Gravar = false;
            this.st_registro.ST_LimparCampo = true;
            this.st_registro.ST_NotNull = false;
            this.st_registro.TabIndex = 76;
            this.st_registro.SelectedIndexChanged += new System.EventHandler(this.st_registro_SelectedIndexChanged);
            // 
            // ds_label
            // 
            this.ds_label.BackColor = System.Drawing.SystemColors.Window;
            this.ds_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_label.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_label.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBico, "Ds_label", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_label.Location = new System.Drawing.Point(210, 81);
            this.ds_label.MaxLength = 2;
            this.ds_label.Name = "ds_label";
            this.ds_label.NM_Alias = "";
            this.ds_label.NM_Campo = "";
            this.ds_label.NM_CampoBusca = "";
            this.ds_label.NM_Param = "@P_NM_CLIFOR";
            this.ds_label.QTD_Zero = 0;
            this.ds_label.Size = new System.Drawing.Size(46, 20);
            this.ds_label.ST_AutoInc = false;
            this.ds_label.ST_DisableAuto = false;
            this.ds_label.ST_Float = false;
            this.ds_label.ST_Gravar = true;
            this.ds_label.ST_Int = false;
            this.ds_label.ST_LimpaCampo = true;
            this.ds_label.ST_NotNull = true;
            this.ds_label.ST_PrimaryKey = false;
            this.ds_label.TabIndex = 5;
            this.ds_label.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBico, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(92, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_produto";
            this.cd_empresa.NM_CampoBusca = "cd_produto";
            this.cd_empresa.NM_Param = "@P_NM_CLIFOR";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(88, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 6;
            this.cd_empresa.TextOld = null;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBico, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(181, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "ds_produto";
            this.nm_empresa.NM_CampoBusca = "ds_produto";
            this.nm_empresa.NM_Param = "@P_NM_CLIFOR";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(440, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 7;
            this.nm_empresa.TextOld = null;
            // 
            // enderecofisicobico
            // 
            this.enderecofisicobico.BackColor = System.Drawing.SystemColors.Window;
            this.enderecofisicobico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enderecofisicobico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.enderecofisicobico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBico, "Enderecofisicobico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.enderecofisicobico.Location = new System.Drawing.Point(92, 81);
            this.enderecofisicobico.MaxLength = 2;
            this.enderecofisicobico.Name = "enderecofisicobico";
            this.enderecofisicobico.NM_Alias = "";
            this.enderecofisicobico.NM_Campo = "";
            this.enderecofisicobico.NM_CampoBusca = "";
            this.enderecofisicobico.NM_Param = "@P_NM_CLIFOR";
            this.enderecofisicobico.QTD_Zero = 0;
            this.enderecofisicobico.Size = new System.Drawing.Size(46, 20);
            this.enderecofisicobico.ST_AutoInc = false;
            this.enderecofisicobico.ST_DisableAuto = false;
            this.enderecofisicobico.ST_Float = false;
            this.enderecofisicobico.ST_Gravar = true;
            this.enderecofisicobico.ST_Int = false;
            this.enderecofisicobico.ST_LimpaCampo = true;
            this.enderecofisicobico.ST_NotNull = true;
            this.enderecofisicobico.ST_PrimaryKey = false;
            this.enderecofisicobico.TabIndex = 4;
            this.enderecofisicobico.TextOld = null;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBico, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Enabled = false;
            this.cd_produto.Location = new System.Drawing.Point(92, 55);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_NM_CLIFOR";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(117, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = false;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 2;
            this.cd_produto.TextOld = null;
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBico, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(212, 55);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_NM_CLIFOR";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(409, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 3;
            this.ds_produto.TextOld = null;
            // 
            // bb_tanque
            // 
            this.bb_tanque.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tanque.Image = ((System.Drawing.Image)(resources.GetObject("bb_tanque.Image")));
            this.bb_tanque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tanque.Location = new System.Drawing.Point(181, 29);
            this.bb_tanque.Name = "bb_tanque";
            this.bb_tanque.Size = new System.Drawing.Size(28, 19);
            this.bb_tanque.TabIndex = 1;
            this.bb_tanque.UseVisualStyleBackColor = false;
            this.bb_tanque.Click += new System.EventHandler(this.bb_tanque_Click);
            // 
            // id_tanque
            // 
            this.id_tanque.BackColor = System.Drawing.Color.White;
            this.id_tanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_tanque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tanque.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBico, "Id_tanquestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_tanque.Location = new System.Drawing.Point(92, 29);
            this.id_tanque.Name = "id_tanque";
            this.id_tanque.NM_Alias = "";
            this.id_tanque.NM_Campo = "id_tanque";
            this.id_tanque.NM_CampoBusca = "id_tanque";
            this.id_tanque.NM_Param = "@P_CD_EMPRESA";
            this.id_tanque.QTD_Zero = 0;
            this.id_tanque.Size = new System.Drawing.Size(88, 20);
            this.id_tanque.ST_AutoInc = false;
            this.id_tanque.ST_DisableAuto = false;
            this.id_tanque.ST_Float = false;
            this.id_tanque.ST_Gravar = true;
            this.id_tanque.ST_Int = true;
            this.id_tanque.ST_LimpaCampo = true;
            this.id_tanque.ST_NotNull = true;
            this.id_tanque.ST_PrimaryKey = false;
            this.id_tanque.TabIndex = 0;
            this.id_tanque.TextOld = null;
            this.id_tanque.Leave += new System.EventHandler(this.id_tanque_Leave);
            // 
            // dt_ativacao
            // 
            this.dt_ativacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ativacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBico, "Dt_ativacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_ativacao.Location = new System.Drawing.Point(552, 81);
            this.dt_ativacao.Mask = "00/00/0000";
            this.dt_ativacao.Name = "dt_ativacao";
            this.dt_ativacao.NM_Alias = "";
            this.dt_ativacao.NM_Campo = "";
            this.dt_ativacao.NM_CampoBusca = "";
            this.dt_ativacao.NM_Param = "";
            this.dt_ativacao.Operador = "";
            this.dt_ativacao.Size = new System.Drawing.Size(69, 20);
            this.dt_ativacao.ST_Gravar = true;
            this.dt_ativacao.ST_LimpaCampo = true;
            this.dt_ativacao.ST_NotNull = true;
            this.dt_ativacao.ST_PrimaryKey = false;
            this.dt_ativacao.TabIndex = 81;
            this.dt_ativacao.Visible = false;
            // 
            // lblDtAtivacao
            // 
            this.lblDtAtivacao.AutoSize = true;
            this.lblDtAtivacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDtAtivacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDtAtivacao.Location = new System.Drawing.Point(477, 84);
            this.lblDtAtivacao.Name = "lblDtAtivacao";
            this.lblDtAtivacao.Size = new System.Drawing.Size(69, 13);
            this.lblDtAtivacao.TabIndex = 80;
            this.lblDtAtivacao.Text = "Dt. Ativação:";
            this.lblDtAtivacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDtAtivacao.Visible = false;
            // 
            // TFCadBicoBomba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 152);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCadBicoBomba";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Bico Bomba";
            this.Load += new System.EventHandler(this.TFCadBicoBomba_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCadBicoBomba_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Button bb_tanque;
        private Componentes.EditDefault id_tanque;
        private System.Windows.Forms.BindingSource bsBico;
        private Componentes.EditDefault enderecofisicobico;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault ds_label;
        private Componentes.ComboBoxDefault st_registro;
        private Componentes.EditData dt_desativacao;
        private System.Windows.Forms.Label lblDtDesativacao;
        private Componentes.EditData dt_ativacao;
        private System.Windows.Forms.Label lblDtAtivacao;
    }
}