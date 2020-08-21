namespace FormBusca
{
    partial class TFPlanoContas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFPlanoContas));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bsConta = new System.Windows.Forms.BindingSource(this.components);
            this.cd_classificacao = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cd_conta = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.bb_referencia = new System.Windows.Forms.Button();
            this.ds_referencia = new Componentes.EditDefault(this.components);
            this.cd_referencia = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.tp_contasped = new Componentes.ComboBoxDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.st_contadeducao = new Componentes.CheckBoxDefault(this.components);
            this.natureza = new Componentes.ComboBoxDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tp_conta = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_contactbpai = new System.Windows.Forms.Button();
            this.ds_conta_ctbpai = new Componentes.EditDefault(this.components);
            this.cd_contactbpai = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_contactb = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cd_classif_pai = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConta)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(650, 43);
            this.barraMenu.TabIndex = 16;
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
            this.pDados.Controls.Add(this.cd_classif_pai);
            this.pDados.Controls.Add(this.cd_classificacao);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.cd_conta);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.bb_referencia);
            this.pDados.Controls.Add(this.ds_referencia);
            this.pDados.Controls.Add(this.cd_referencia);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.tp_contasped);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.st_contadeducao);
            this.pDados.Controls.Add(this.natureza);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.tp_conta);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.bb_contactbpai);
            this.pDados.Controls.Add(this.ds_conta_ctbpai);
            this.pDados.Controls.Add(this.cd_contactbpai);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_contactb);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(650, 174);
            this.pDados.TabIndex = 0;
            // 
            // bsConta
            // 
            this.bsConta.DataSource = typeof(CamadaDados.Contabil.Cadastro.TList_CadPlanoContas);
            // 
            // cd_classificacao
            // 
            this.cd_classificacao.BackColor = System.Drawing.SystemColors.Window;
            this.cd_classificacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_classificacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_classificacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConta, "Cd_classificacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_classificacao.Location = new System.Drawing.Point(106, 107);
            this.cd_classificacao.MaxLength = 1;
            this.cd_classificacao.Name = "cd_classificacao";
            this.cd_classificacao.NM_Alias = "";
            this.cd_classificacao.NM_Campo = "";
            this.cd_classificacao.NM_CampoBusca = "";
            this.cd_classificacao.NM_Param = "";
            this.cd_classificacao.QTD_Zero = 0;
            this.cd_classificacao.Size = new System.Drawing.Size(223, 20);
            this.cd_classificacao.ST_AutoInc = false;
            this.cd_classificacao.ST_DisableAuto = false;
            this.cd_classificacao.ST_Float = false;
            this.cd_classificacao.ST_Gravar = true;
            this.cd_classificacao.ST_Int = false;
            this.cd_classificacao.ST_LimpaCampo = true;
            this.cd_classificacao.ST_NotNull = true;
            this.cd_classificacao.ST_PrimaryKey = false;
            this.cd_classificacao.TabIndex = 7;
            this.cd_classificacao.TextOld = null;
            this.cd_classificacao.TextChanged += new System.EventHandler(this.cd_classificacao_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Classificação:";
            // 
            // cd_conta
            // 
            this.cd_conta.BackColor = System.Drawing.SystemColors.Window;
            this.cd_conta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_conta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_conta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConta, "Cd_conta_ctbstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_conta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_conta.Location = new System.Drawing.Point(106, 2);
            this.cd_conta.MaxLength = 6;
            this.cd_conta.Name = "cd_conta";
            this.cd_conta.NM_Alias = "a";
            this.cd_conta.NM_Campo = "CD_Conta_CTBPai";
            this.cd_conta.NM_CampoBusca = "CD_Conta_CTB";
            this.cd_conta.NM_Param = "@P_CD_CONTA_CTBPAI";
            this.cd_conta.QTD_Zero = 0;
            this.cd_conta.Size = new System.Drawing.Size(96, 20);
            this.cd_conta.ST_AutoInc = false;
            this.cd_conta.ST_DisableAuto = false;
            this.cd_conta.ST_Float = false;
            this.cd_conta.ST_Gravar = true;
            this.cd_conta.ST_Int = true;
            this.cd_conta.ST_LimpaCampo = true;
            this.cd_conta.ST_NotNull = false;
            this.cd_conta.ST_PrimaryKey = false;
            this.cd_conta.TabIndex = 0;
            this.cd_conta.TextOld = null;
            this.cd_conta.Leave += new System.EventHandler(this.cd_conta_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "CD.Conta:";
            // 
            // bb_referencia
            // 
            this.bb_referencia.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_referencia.Image = ((System.Drawing.Image)(resources.GetObject("bb_referencia.Image")));
            this.bb_referencia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_referencia.Location = new System.Drawing.Point(250, 133);
            this.bb_referencia.Name = "bb_referencia";
            this.bb_referencia.Size = new System.Drawing.Size(30, 21);
            this.bb_referencia.TabIndex = 10;
            this.bb_referencia.UseVisualStyleBackColor = true;
            this.bb_referencia.Click += new System.EventHandler(this.bb_referencia_Click);
            // 
            // ds_referencia
            // 
            this.ds_referencia.BackColor = System.Drawing.SystemColors.Window;
            this.ds_referencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_referencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_referencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConta, "Ds_referencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_referencia.Enabled = false;
            this.ds_referencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_referencia.Location = new System.Drawing.Point(286, 134);
            this.ds_referencia.Name = "ds_referencia";
            this.ds_referencia.NM_Alias = "";
            this.ds_referencia.NM_Campo = "nome";
            this.ds_referencia.NM_CampoBusca = "nome";
            this.ds_referencia.NM_Param = "@P_CONTA_CTBPAI";
            this.ds_referencia.QTD_Zero = 0;
            this.ds_referencia.Size = new System.Drawing.Size(359, 20);
            this.ds_referencia.ST_AutoInc = false;
            this.ds_referencia.ST_DisableAuto = true;
            this.ds_referencia.ST_Float = false;
            this.ds_referencia.ST_Gravar = false;
            this.ds_referencia.ST_Int = false;
            this.ds_referencia.ST_LimpaCampo = true;
            this.ds_referencia.ST_NotNull = false;
            this.ds_referencia.ST_PrimaryKey = false;
            this.ds_referencia.TabIndex = 16;
            this.ds_referencia.TextOld = null;
            // 
            // cd_referencia
            // 
            this.cd_referencia.BackColor = System.Drawing.SystemColors.Window;
            this.cd_referencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_referencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_referencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConta, "Cd_referencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_referencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_referencia.Location = new System.Drawing.Point(106, 134);
            this.cd_referencia.MaxLength = 6;
            this.cd_referencia.Name = "cd_referencia";
            this.cd_referencia.NM_Alias = "a";
            this.cd_referencia.NM_Campo = "cd_referencia";
            this.cd_referencia.NM_CampoBusca = "cd_referencia";
            this.cd_referencia.NM_Param = "@P_CD_CONTA_CTBPAI";
            this.cd_referencia.QTD_Zero = 0;
            this.cd_referencia.Size = new System.Drawing.Size(141, 20);
            this.cd_referencia.ST_AutoInc = false;
            this.cd_referencia.ST_DisableAuto = false;
            this.cd_referencia.ST_Float = false;
            this.cd_referencia.ST_Gravar = true;
            this.cd_referencia.ST_Int = true;
            this.cd_referencia.ST_LimpaCampo = true;
            this.cd_referencia.ST_NotNull = false;
            this.cd_referencia.ST_PrimaryKey = false;
            this.cd_referencia.TabIndex = 9;
            this.cd_referencia.TextOld = null;
            this.cd_referencia.EnabledChanged += new System.EventHandler(this.cd_referencia_EnabledChanged);
            this.cd_referencia.Leave += new System.EventHandler(this.cd_referencia_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Conta Referencia:";
            // 
            // tp_contasped
            // 
            this.tp_contasped.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsConta, "Tp_contasped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_contasped.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_contasped.FormattingEnabled = true;
            this.tp_contasped.Location = new System.Drawing.Point(412, 107);
            this.tp_contasped.Name = "tp_contasped";
            this.tp_contasped.NM_Alias = "";
            this.tp_contasped.NM_Campo = "";
            this.tp_contasped.NM_Param = "";
            this.tp_contasped.Size = new System.Drawing.Size(233, 21);
            this.tp_contasped.ST_Gravar = true;
            this.tp_contasped.ST_LimparCampo = true;
            this.tp_contasped.ST_NotNull = false;
            this.tp_contasped.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Classif. Sped:";
            // 
            // st_contadeducao
            // 
            this.st_contadeducao.AutoSize = true;
            this.st_contadeducao.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.st_contadeducao.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsConta, "St_deducaobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_contadeducao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_contadeducao.Location = new System.Drawing.Point(531, 82);
            this.st_contadeducao.Name = "st_contadeducao";
            this.st_contadeducao.NM_Alias = "";
            this.st_contadeducao.NM_Campo = "";
            this.st_contadeducao.NM_Param = "";
            this.st_contadeducao.Size = new System.Drawing.Size(114, 17);
            this.st_contadeducao.ST_Gravar = false;
            this.st_contadeducao.ST_LimparCampo = true;
            this.st_contadeducao.ST_NotNull = false;
            this.st_contadeducao.TabIndex = 6;
            this.st_contadeducao.Text = "Conta Dedução";
            this.st_contadeducao.UseVisualStyleBackColor = true;
            this.st_contadeducao.Vl_False = "";
            this.st_contadeducao.Vl_True = "";
            // 
            // natureza
            // 
            this.natureza.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsConta, "Natureza", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.natureza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.natureza.FormattingEnabled = true;
            this.natureza.Location = new System.Drawing.Point(345, 80);
            this.natureza.Name = "natureza";
            this.natureza.NM_Alias = "a.nr_natureza";
            this.natureza.NM_Campo = "a.nr_natureza";
            this.natureza.NM_Param = "@P_A.NR_NATUREZA";
            this.natureza.Size = new System.Drawing.Size(180, 21);
            this.natureza.ST_Gravar = true;
            this.natureza.ST_LimparCampo = true;
            this.natureza.ST_NotNull = true;
            this.natureza.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Natureza:";
            // 
            // tp_conta
            // 
            this.tp_conta.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsConta, "Tp_conta", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_conta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_conta.FormattingEnabled = true;
            this.tp_conta.Location = new System.Drawing.Point(106, 80);
            this.tp_conta.Name = "tp_conta";
            this.tp_conta.NM_Alias = "";
            this.tp_conta.NM_Campo = "";
            this.tp_conta.NM_Param = "";
            this.tp_conta.Size = new System.Drawing.Size(174, 21);
            this.tp_conta.ST_Gravar = true;
            this.tp_conta.ST_LimparCampo = true;
            this.tp_conta.ST_NotNull = true;
            this.tp_conta.TabIndex = 4;
            this.tp_conta.SelectedIndexChanged += new System.EventHandler(this.tp_conta_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo Conta:";
            // 
            // bb_contactbpai
            // 
            this.bb_contactbpai.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_contactbpai.Image = ((System.Drawing.Image)(resources.GetObject("bb_contactbpai.Image")));
            this.bb_contactbpai.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contactbpai.Location = new System.Drawing.Point(172, 53);
            this.bb_contactbpai.Name = "bb_contactbpai";
            this.bb_contactbpai.Size = new System.Drawing.Size(30, 20);
            this.bb_contactbpai.TabIndex = 3;
            this.bb_contactbpai.UseVisualStyleBackColor = true;
            this.bb_contactbpai.Click += new System.EventHandler(this.bb_contactbpai_Click);
            // 
            // ds_conta_ctbpai
            // 
            this.ds_conta_ctbpai.BackColor = System.Drawing.SystemColors.Window;
            this.ds_conta_ctbpai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_conta_ctbpai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_conta_ctbpai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConta, "Ds_contactb_pai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_conta_ctbpai.Enabled = false;
            this.ds_conta_ctbpai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_conta_ctbpai.Location = new System.Drawing.Point(208, 54);
            this.ds_conta_ctbpai.Name = "ds_conta_ctbpai";
            this.ds_conta_ctbpai.NM_Alias = "";
            this.ds_conta_ctbpai.NM_Campo = "DS_Conta_CTBPai";
            this.ds_conta_ctbpai.NM_CampoBusca = "DS_ContaCTB";
            this.ds_conta_ctbpai.NM_Param = "@P_CONTA_CTBPAI";
            this.ds_conta_ctbpai.QTD_Zero = 0;
            this.ds_conta_ctbpai.Size = new System.Drawing.Size(317, 20);
            this.ds_conta_ctbpai.ST_AutoInc = false;
            this.ds_conta_ctbpai.ST_DisableAuto = true;
            this.ds_conta_ctbpai.ST_Float = false;
            this.ds_conta_ctbpai.ST_Gravar = false;
            this.ds_conta_ctbpai.ST_Int = false;
            this.ds_conta_ctbpai.ST_LimpaCampo = true;
            this.ds_conta_ctbpai.ST_NotNull = false;
            this.ds_conta_ctbpai.ST_PrimaryKey = false;
            this.ds_conta_ctbpai.TabIndex = 8;
            this.ds_conta_ctbpai.TextOld = null;
            // 
            // cd_contactbpai
            // 
            this.cd_contactbpai.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contactbpai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contactbpai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contactbpai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConta, "Cd_conta_ctbpaistr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contactbpai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contactbpai.Location = new System.Drawing.Point(106, 54);
            this.cd_contactbpai.MaxLength = 6;
            this.cd_contactbpai.Name = "cd_contactbpai";
            this.cd_contactbpai.NM_Alias = "a";
            this.cd_contactbpai.NM_Campo = "CD_Conta_CTBPai";
            this.cd_contactbpai.NM_CampoBusca = "CD_Conta_CTB";
            this.cd_contactbpai.NM_Param = "@P_CD_CONTA_CTBPAI";
            this.cd_contactbpai.QTD_Zero = 0;
            this.cd_contactbpai.Size = new System.Drawing.Size(60, 20);
            this.cd_contactbpai.ST_AutoInc = false;
            this.cd_contactbpai.ST_DisableAuto = false;
            this.cd_contactbpai.ST_Float = false;
            this.cd_contactbpai.ST_Gravar = true;
            this.cd_contactbpai.ST_Int = true;
            this.cd_contactbpai.ST_LimpaCampo = true;
            this.cd_contactbpai.ST_NotNull = false;
            this.cd_contactbpai.ST_PrimaryKey = false;
            this.cd_contactbpai.TabIndex = 2;
            this.cd_contactbpai.TextOld = null;
            this.cd_contactbpai.Leave += new System.EventHandler(this.cd_contactbpai_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Conta Pai:";
            // 
            // ds_contactb
            // 
            this.ds_contactb.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contactb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contactb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contactb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConta, "Ds_contactb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contactb.Location = new System.Drawing.Point(106, 28);
            this.ds_contactb.Name = "ds_contactb";
            this.ds_contactb.NM_Alias = "";
            this.ds_contactb.NM_Campo = "";
            this.ds_contactb.NM_CampoBusca = "";
            this.ds_contactb.NM_Param = "";
            this.ds_contactb.QTD_Zero = 0;
            this.ds_contactb.Size = new System.Drawing.Size(539, 20);
            this.ds_contactb.ST_AutoInc = false;
            this.ds_contactb.ST_DisableAuto = false;
            this.ds_contactb.ST_Float = false;
            this.ds_contactb.ST_Gravar = true;
            this.ds_contactb.ST_Int = false;
            this.ds_contactb.ST_LimpaCampo = true;
            this.ds_contactb.ST_NotNull = true;
            this.ds_contactb.ST_PrimaryKey = false;
            this.ds_contactb.TabIndex = 1;
            this.ds_contactb.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição Conta:";
            // 
            // cd_classif_pai
            // 
            this.cd_classif_pai.BackColor = System.Drawing.SystemColors.Window;
            this.cd_classif_pai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_classif_pai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_classif_pai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConta, "Cd_classif_pai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_classif_pai.Enabled = false;
            this.cd_classif_pai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_classif_pai.Location = new System.Drawing.Point(531, 54);
            this.cd_classif_pai.Name = "cd_classif_pai";
            this.cd_classif_pai.NM_Alias = "";
            this.cd_classif_pai.NM_Campo = "cd_classificacao";
            this.cd_classif_pai.NM_CampoBusca = "cd_classificacao";
            this.cd_classif_pai.NM_Param = "@P_CONTA_CTBPAI";
            this.cd_classif_pai.QTD_Zero = 0;
            this.cd_classif_pai.Size = new System.Drawing.Size(114, 20);
            this.cd_classif_pai.ST_AutoInc = false;
            this.cd_classif_pai.ST_DisableAuto = true;
            this.cd_classif_pai.ST_Float = false;
            this.cd_classif_pai.ST_Gravar = false;
            this.cd_classif_pai.ST_Int = false;
            this.cd_classif_pai.ST_LimpaCampo = true;
            this.cd_classif_pai.ST_NotNull = false;
            this.cd_classif_pai.ST_PrimaryKey = false;
            this.cd_classif_pai.TabIndex = 21;
            this.cd_classif_pai.TextOld = null;
            this.cd_classif_pai.TextChanged += new System.EventHandler(this.cd_classif_pai_TextChanged);
            // 
            // TFPlanoContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 217);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFPlanoContas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano Contas Contabeis";
            this.Load += new System.EventHandler(this.TFPlanoContas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFPlanoContas_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_contactb;
        private System.Windows.Forms.BindingSource bsConta;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_conta_ctbpai;
        private Componentes.EditDefault cd_contactbpai;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault natureza;
        private System.Windows.Forms.Label label4;
        private Componentes.ComboBoxDefault tp_conta;
        private Componentes.CheckBoxDefault st_contadeducao;
        private System.Windows.Forms.Button bb_contactbpai;
        private Componentes.ComboBoxDefault tp_contasped;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bb_referencia;
        private Componentes.EditDefault ds_referencia;
        private Componentes.EditDefault cd_referencia;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault cd_conta;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault cd_classificacao;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault cd_classif_pai;
    }
}