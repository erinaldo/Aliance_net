namespace Contabil
{
    partial class TFCFGFaturamento
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
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label30;
            System.Windows.Forms.Label label50;
            System.Windows.Forms.Label label28;
            System.Windows.Forms.Label label29;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCFGFaturamento));
            System.Windows.Forms.Label label1;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.classificacaodeb = new Componentes.EditDefault(this.components);
            this.bsCfgFat = new System.Windows.Forms.BindingSource(this.components);
            this.ds_contacred = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.cd_contadeb = new Componentes.EditDefault(this.components);
            this.ds_contadeb = new Componentes.EditDefault(this.components);
            this.btn_Empresa = new System.Windows.Forms.Button();
            this.cd_contacred = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.bb_contadeb = new System.Windows.Forms.Button();
            this.bb_contacred = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.classificacaocred = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.ds_movimentacao = new Componentes.EditDefault(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.bb_movimentacao = new System.Windows.Forms.Button();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.cd_movimentacao = new Componentes.EditDefault(this.components);
            this.cd_grupo = new Componentes.EditDefault(this.components);
            this.ds_grupo = new Componentes.EditDefault(this.components);
            this.bb_grupo = new System.Windows.Forms.Button();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label50 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgFat)).BeginInit();
            this.SuspendLayout();
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label26.Location = new System.Drawing.Point(1, 162);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(88, 13);
            label26.TabIndex = 90;
            label26.Text = "Conta Crédito:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label27.Location = new System.Drawing.Point(4, 136);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(85, 13);
            label27.TabIndex = 94;
            label27.Text = "Conta Débito:";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label30.Location = new System.Drawing.Point(38, 6);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(51, 13);
            label30.TabIndex = 105;
            label30.Text = "Empresa:";
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label50.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label50.Location = new System.Drawing.Point(42, 84);
            label50.Name = "label50";
            label50.Size = new System.Drawing.Size(47, 13);
            label50.TabIndex = 103;
            label50.Text = "Produto:";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label28.Location = new System.Drawing.Point(9, 31);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(80, 13);
            label28.TabIndex = 101;
            label28.Text = "Movimentação:";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label29.Location = new System.Drawing.Point(6, 58);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(83, 13);
            label29.TabIndex = 102;
            label29.Text = "Cliente/Fornec.:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(725, 43);
            this.barraMenu.TabIndex = 12;
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
            this.pDados.Controls.Add(this.cd_grupo);
            this.pDados.Controls.Add(this.ds_grupo);
            this.pDados.Controls.Add(this.bb_grupo);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.classificacaodeb);
            this.pDados.Controls.Add(this.ds_contacred);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.cd_contadeb);
            this.pDados.Controls.Add(this.ds_contadeb);
            this.pDados.Controls.Add(this.btn_Empresa);
            this.pDados.Controls.Add(this.cd_contacred);
            this.pDados.Controls.Add(label26);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.bb_contadeb);
            this.pDados.Controls.Add(label27);
            this.pDados.Controls.Add(this.bb_contacred);
            this.pDados.Controls.Add(label30);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.classificacaocred);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(label50);
            this.pDados.Controls.Add(this.nm_clifor);
            this.pDados.Controls.Add(this.ds_movimentacao);
            this.pDados.Controls.Add(this.bb_clifor);
            this.pDados.Controls.Add(this.bb_movimentacao);
            this.pDados.Controls.Add(this.cd_clifor);
            this.pDados.Controls.Add(label28);
            this.pDados.Controls.Add(label29);
            this.pDados.Controls.Add(this.cd_movimentacao);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(725, 184);
            this.pDados.TabIndex = 0;
            // 
            // classificacaodeb
            // 
            this.classificacaodeb.BackColor = System.Drawing.SystemColors.Window;
            this.classificacaodeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacaodeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacaodeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "CD_Classificacao_DEB", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.classificacaodeb.Enabled = false;
            this.classificacaodeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.classificacaodeb.Location = new System.Drawing.Point(597, 132);
            this.classificacaodeb.Name = "classificacaodeb";
            this.classificacaodeb.NM_Alias = "";
            this.classificacaodeb.NM_Campo = "CD_Classificacao";
            this.classificacaodeb.NM_CampoBusca = "CD_Classificacao";
            this.classificacaodeb.NM_Param = "@P_CD_CLASSIFICACAO";
            this.classificacaodeb.QTD_Zero = 0;
            this.classificacaodeb.Size = new System.Drawing.Size(123, 20);
            this.classificacaodeb.ST_AutoInc = false;
            this.classificacaodeb.ST_DisableAuto = false;
            this.classificacaodeb.ST_Float = false;
            this.classificacaodeb.ST_Gravar = false;
            this.classificacaodeb.ST_Int = false;
            this.classificacaodeb.ST_LimpaCampo = true;
            this.classificacaodeb.ST_NotNull = false;
            this.classificacaodeb.ST_PrimaryKey = false;
            this.classificacaodeb.TabIndex = 96;
            this.classificacaodeb.TextOld = null;
            // 
            // bsCfgFat
            // 
            this.bsCfgFat.DataSource = typeof(CamadaDados.Contabil.TList_CTB_CFGFaturamento);
            // 
            // ds_contacred
            // 
            this.ds_contacred.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contacred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contacred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contacred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "DS_Conta_CTB_CRED", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contacred.Enabled = false;
            this.ds_contacred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contacred.Location = new System.Drawing.Point(205, 158);
            this.ds_contacred.Name = "ds_contacred";
            this.ds_contacred.NM_Alias = "";
            this.ds_contacred.NM_Campo = "ds_contaCTB";
            this.ds_contacred.NM_CampoBusca = "ds_contaCTB";
            this.ds_contacred.NM_Param = "";
            this.ds_contacred.QTD_Zero = 0;
            this.ds_contacred.Size = new System.Drawing.Size(391, 20);
            this.ds_contacred.ST_AutoInc = false;
            this.ds_contacred.ST_DisableAuto = false;
            this.ds_contacred.ST_Float = false;
            this.ds_contacred.ST_Gravar = false;
            this.ds_contacred.ST_Int = false;
            this.ds_contacred.ST_LimpaCampo = true;
            this.ds_contacred.ST_NotNull = false;
            this.ds_contacred.ST_PrimaryKey = false;
            this.ds_contacred.TabIndex = 88;
            this.ds_contacred.TextOld = null;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "CD_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(95, 3);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "a";
            this.CD_Empresa.NM_Campo = "Cd_Empresa";
            this.CD_Empresa.NM_CampoBusca = "Cd_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(73, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // cd_contadeb
            // 
            this.cd_contadeb.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contadeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contadeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contadeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "CD_Conta_CTB_DEB_String", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contadeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contadeb.Location = new System.Drawing.Point(95, 133);
            this.cd_contadeb.Name = "cd_contadeb";
            this.cd_contadeb.NM_Alias = "a";
            this.cd_contadeb.NM_Campo = "cd_conta_CTB";
            this.cd_contadeb.NM_CampoBusca = "cd_conta_CTB";
            this.cd_contadeb.NM_Param = "@P_CD_CONTA_CTB";
            this.cd_contadeb.QTD_Zero = 0;
            this.cd_contadeb.Size = new System.Drawing.Size(73, 20);
            this.cd_contadeb.ST_AutoInc = false;
            this.cd_contadeb.ST_DisableAuto = false;
            this.cd_contadeb.ST_Float = false;
            this.cd_contadeb.ST_Gravar = true;
            this.cd_contadeb.ST_Int = false;
            this.cd_contadeb.ST_LimpaCampo = true;
            this.cd_contadeb.ST_NotNull = true;
            this.cd_contadeb.ST_PrimaryKey = false;
            this.cd_contadeb.TabIndex = 10;
            this.cd_contadeb.TextOld = null;
            this.cd_contadeb.Leave += new System.EventHandler(this.cd_contadeb_Leave);
            // 
            // ds_contadeb
            // 
            this.ds_contadeb.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contadeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contadeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contadeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "DS_Conta_CTB_DEB", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contadeb.Enabled = false;
            this.ds_contadeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contadeb.Location = new System.Drawing.Point(205, 132);
            this.ds_contadeb.Name = "ds_contadeb";
            this.ds_contadeb.NM_Alias = "";
            this.ds_contadeb.NM_Campo = "ds_contaCTB";
            this.ds_contadeb.NM_CampoBusca = "ds_contaCTB";
            this.ds_contadeb.NM_Param = "";
            this.ds_contadeb.QTD_Zero = 0;
            this.ds_contadeb.Size = new System.Drawing.Size(391, 20);
            this.ds_contadeb.ST_AutoInc = false;
            this.ds_contadeb.ST_DisableAuto = false;
            this.ds_contadeb.ST_Float = false;
            this.ds_contadeb.ST_Gravar = false;
            this.ds_contadeb.ST_Int = false;
            this.ds_contadeb.ST_LimpaCampo = true;
            this.ds_contadeb.ST_NotNull = false;
            this.ds_contadeb.ST_PrimaryKey = false;
            this.ds_contadeb.TabIndex = 81;
            this.ds_contadeb.TextOld = null;
            // 
            // btn_Empresa
            // 
            this.btn_Empresa.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Empresa.Image")));
            this.btn_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Empresa.Location = new System.Drawing.Point(172, 3);
            this.btn_Empresa.Name = "btn_Empresa";
            this.btn_Empresa.Size = new System.Drawing.Size(30, 20);
            this.btn_Empresa.TabIndex = 1;
            this.btn_Empresa.UseVisualStyleBackColor = false;
            this.btn_Empresa.Click += new System.EventHandler(this.btn_Empresa_Click);
            // 
            // cd_contacred
            // 
            this.cd_contacred.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contacred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contacred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contacred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "CD_Conta_CTB_CRED_String", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contacred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contacred.Location = new System.Drawing.Point(95, 159);
            this.cd_contacred.Name = "cd_contacred";
            this.cd_contacred.NM_Alias = "a";
            this.cd_contacred.NM_Campo = "cd_conta_CTB";
            this.cd_contacred.NM_CampoBusca = "cd_conta_CTB";
            this.cd_contacred.NM_Param = "";
            this.cd_contacred.QTD_Zero = 0;
            this.cd_contacred.Size = new System.Drawing.Size(73, 20);
            this.cd_contacred.ST_AutoInc = false;
            this.cd_contacred.ST_DisableAuto = false;
            this.cd_contacred.ST_Float = false;
            this.cd_contacred.ST_Gravar = true;
            this.cd_contacred.ST_Int = false;
            this.cd_contacred.ST_LimpaCampo = true;
            this.cd_contacred.ST_NotNull = true;
            this.cd_contacred.ST_PrimaryKey = false;
            this.cd_contacred.TabIndex = 12;
            this.cd_contacred.TextOld = null;
            this.cd_contacred.Leave += new System.EventHandler(this.cd_contacred_Leave);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "NM_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(205, 3);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "a";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(515, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 104;
            this.NM_Empresa.TextOld = null;
            // 
            // bb_contadeb
            // 
            this.bb_contadeb.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contadeb.Image = ((System.Drawing.Image)(resources.GetObject("bb_contadeb.Image")));
            this.bb_contadeb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contadeb.Location = new System.Drawing.Point(172, 133);
            this.bb_contadeb.Name = "bb_contadeb";
            this.bb_contadeb.Size = new System.Drawing.Size(30, 20);
            this.bb_contadeb.TabIndex = 11;
            this.bb_contadeb.UseVisualStyleBackColor = false;
            this.bb_contadeb.Click += new System.EventHandler(this.bb_contadeb_Click);
            // 
            // bb_contacred
            // 
            this.bb_contacred.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contacred.Image = ((System.Drawing.Image)(resources.GetObject("bb_contacred.Image")));
            this.bb_contacred.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contacred.Location = new System.Drawing.Point(172, 158);
            this.bb_contacred.Name = "bb_contacred";
            this.bb_contacred.Size = new System.Drawing.Size(30, 20);
            this.bb_contacred.TabIndex = 13;
            this.bb_contacred.UseVisualStyleBackColor = false;
            this.bb_contacred.Click += new System.EventHandler(this.bb_contacred_Click);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "CD_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(95, 81);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "a";
            this.cd_produto.NM_Campo = "Cd_produto";
            this.cd_produto.NM_CampoBusca = "Cd_Produto";
            this.cd_produto.NM_Param = "";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(73, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 6;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // classificacaocred
            // 
            this.classificacaocred.BackColor = System.Drawing.SystemColors.Window;
            this.classificacaocred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacaocred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacaocred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "CD_Classificacao_CRED", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.classificacaocred.Enabled = false;
            this.classificacaocred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.classificacaocred.Location = new System.Drawing.Point(597, 158);
            this.classificacaocred.Name = "classificacaocred";
            this.classificacaocred.NM_Alias = "";
            this.classificacaocred.NM_Campo = "CD_Classificacao";
            this.classificacaocred.NM_CampoBusca = "CD_Classificacao";
            this.classificacaocred.NM_Param = "@P_CD_CLASSIFICACAO";
            this.classificacaocred.QTD_Zero = 0;
            this.classificacaocred.Size = new System.Drawing.Size(123, 20);
            this.classificacaocred.ST_AutoInc = false;
            this.classificacaocred.ST_DisableAuto = false;
            this.classificacaocred.ST_Float = false;
            this.classificacaocred.ST_Gravar = false;
            this.classificacaocred.ST_Int = false;
            this.classificacaocred.ST_LimpaCampo = true;
            this.classificacaocred.ST_NotNull = false;
            this.classificacaocred.ST_PrimaryKey = false;
            this.classificacaocred.TabIndex = 97;
            this.classificacaocred.TextOld = null;
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "DS_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_produto.Location = new System.Drawing.Point(205, 81);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "a";
            this.ds_produto.NM_Campo = "DS_produto";
            this.ds_produto.NM_CampoBusca = "DS_produto";
            this.ds_produto.NM_Param = "";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(515, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 100;
            this.ds_produto.TextOld = null;
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(172, 81);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(30, 20);
            this.bb_produto.TabIndex = 7;
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "NM_Clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_clifor.Location = new System.Drawing.Point(205, 55);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "a";
            this.nm_clifor.NM_Campo = "NM_CLIFOR";
            this.nm_clifor.NM_CampoBusca = "NM_CLIFOR";
            this.nm_clifor.NM_Param = "@P_DS_CLIFOR";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(515, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 99;
            this.nm_clifor.TextOld = null;
            // 
            // ds_movimentacao
            // 
            this.ds_movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_movimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "DS_Movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_movimentacao.Enabled = false;
            this.ds_movimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_movimentacao.Location = new System.Drawing.Point(205, 29);
            this.ds_movimentacao.Name = "ds_movimentacao";
            this.ds_movimentacao.NM_Alias = "a";
            this.ds_movimentacao.NM_Campo = "DS_Movimentacao";
            this.ds_movimentacao.NM_CampoBusca = "DS_Movimentacao";
            this.ds_movimentacao.NM_Param = "@P_DS_MOVIMENTACAO";
            this.ds_movimentacao.QTD_Zero = 0;
            this.ds_movimentacao.Size = new System.Drawing.Size(515, 20);
            this.ds_movimentacao.ST_AutoInc = false;
            this.ds_movimentacao.ST_DisableAuto = false;
            this.ds_movimentacao.ST_Float = false;
            this.ds_movimentacao.ST_Gravar = false;
            this.ds_movimentacao.ST_Int = false;
            this.ds_movimentacao.ST_LimpaCampo = true;
            this.ds_movimentacao.ST_NotNull = false;
            this.ds_movimentacao.ST_PrimaryKey = false;
            this.ds_movimentacao.TabIndex = 98;
            this.ds_movimentacao.TextOld = null;
            // 
            // bb_clifor
            // 
            this.bb_clifor.BackColor = System.Drawing.SystemColors.Control;
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(172, 55);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(30, 20);
            this.bb_clifor.TabIndex = 5;
            this.bb_clifor.UseVisualStyleBackColor = false;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // bb_movimentacao
            // 
            this.bb_movimentacao.BackColor = System.Drawing.SystemColors.Control;
            this.bb_movimentacao.Image = ((System.Drawing.Image)(resources.GetObject("bb_movimentacao.Image")));
            this.bb_movimentacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_movimentacao.Location = new System.Drawing.Point(172, 30);
            this.bb_movimentacao.Name = "bb_movimentacao";
            this.bb_movimentacao.Size = new System.Drawing.Size(30, 20);
            this.bb_movimentacao.TabIndex = 3;
            this.bb_movimentacao.UseVisualStyleBackColor = false;
            this.bb_movimentacao.Click += new System.EventHandler(this.bb_movimentacao_Click);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "CD_Clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_clifor.Location = new System.Drawing.Point(95, 55);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "a";
            this.cd_clifor.NM_Campo = "Cd_Clifor";
            this.cd_clifor.NM_CampoBusca = "Cd_Clifor";
            this.cd_clifor.NM_Param = "@P_CD_CLIFOR";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(73, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = false;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 4;
            this.cd_clifor.TextOld = null;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // cd_movimentacao
            // 
            this.cd_movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.cd_movimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "CD_Movimentacao_String", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_movimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_movimentacao.Location = new System.Drawing.Point(95, 29);
            this.cd_movimentacao.Name = "cd_movimentacao";
            this.cd_movimentacao.NM_Alias = "a";
            this.cd_movimentacao.NM_Campo = "CD_Movimentacao";
            this.cd_movimentacao.NM_CampoBusca = "CD_Movimentacao";
            this.cd_movimentacao.NM_Param = "@P_CD_MOVIMENTACAO";
            this.cd_movimentacao.QTD_Zero = 0;
            this.cd_movimentacao.Size = new System.Drawing.Size(73, 20);
            this.cd_movimentacao.ST_AutoInc = false;
            this.cd_movimentacao.ST_DisableAuto = false;
            this.cd_movimentacao.ST_Float = false;
            this.cd_movimentacao.ST_Gravar = true;
            this.cd_movimentacao.ST_Int = true;
            this.cd_movimentacao.ST_LimpaCampo = true;
            this.cd_movimentacao.ST_NotNull = true;
            this.cd_movimentacao.ST_PrimaryKey = false;
            this.cd_movimentacao.TabIndex = 2;
            this.cd_movimentacao.TextOld = null;
            this.cd_movimentacao.Leave += new System.EventHandler(this.cd_movimentacao_Leave);
            // 
            // cd_grupo
            // 
            this.cd_grupo.BackColor = System.Drawing.SystemColors.Window;
            this.cd_grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "Cd_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_grupo.Location = new System.Drawing.Point(95, 107);
            this.cd_grupo.Name = "cd_grupo";
            this.cd_grupo.NM_Alias = "a";
            this.cd_grupo.NM_Campo = "cd_grupo";
            this.cd_grupo.NM_CampoBusca = "cd_grupo";
            this.cd_grupo.NM_Param = "@P_CD_GRUPO";
            this.cd_grupo.QTD_Zero = 0;
            this.cd_grupo.Size = new System.Drawing.Size(73, 20);
            this.cd_grupo.ST_AutoInc = false;
            this.cd_grupo.ST_DisableAuto = false;
            this.cd_grupo.ST_Float = false;
            this.cd_grupo.ST_Gravar = true;
            this.cd_grupo.ST_Int = false;
            this.cd_grupo.ST_LimpaCampo = true;
            this.cd_grupo.ST_NotNull = false;
            this.cd_grupo.ST_PrimaryKey = false;
            this.cd_grupo.TabIndex = 8;
            this.cd_grupo.TextOld = null;
            this.cd_grupo.Leave += new System.EventHandler(this.cd_grupo_Leave);
            // 
            // ds_grupo
            // 
            this.ds_grupo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgFat, "Ds_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_grupo.Enabled = false;
            this.ds_grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_grupo.Location = new System.Drawing.Point(205, 107);
            this.ds_grupo.Name = "ds_grupo";
            this.ds_grupo.NM_Alias = "a";
            this.ds_grupo.NM_Campo = "ds_grupo";
            this.ds_grupo.NM_CampoBusca = "ds_grupo";
            this.ds_grupo.NM_Param = "@P_DS_GURPO";
            this.ds_grupo.QTD_Zero = 0;
            this.ds_grupo.Size = new System.Drawing.Size(515, 20);
            this.ds_grupo.ST_AutoInc = false;
            this.ds_grupo.ST_DisableAuto = false;
            this.ds_grupo.ST_Float = false;
            this.ds_grupo.ST_Gravar = false;
            this.ds_grupo.ST_Int = false;
            this.ds_grupo.ST_LimpaCampo = true;
            this.ds_grupo.ST_NotNull = false;
            this.ds_grupo.ST_PrimaryKey = false;
            this.ds_grupo.TabIndex = 108;
            this.ds_grupo.TextOld = null;
            // 
            // bb_grupo
            // 
            this.bb_grupo.BackColor = System.Drawing.SystemColors.Control;
            this.bb_grupo.Image = ((System.Drawing.Image)(resources.GetObject("bb_grupo.Image")));
            this.bb_grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_grupo.Location = new System.Drawing.Point(172, 107);
            this.bb_grupo.Name = "bb_grupo";
            this.bb_grupo.Size = new System.Drawing.Size(30, 20);
            this.bb_grupo.TabIndex = 9;
            this.bb_grupo.UseVisualStyleBackColor = false;
            this.bb_grupo.Click += new System.EventHandler(this.bb_grupo_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(50, 110);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 13);
            label1.TabIndex = 109;
            label1.Text = "Grupo:";
            // 
            // TFCFGFaturamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 227);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCFGFaturamento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração Faturamento";
            this.Load += new System.EventHandler(this.TFCFGFaturamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCFGFaturamento_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgFat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault classificacaodeb;
        private Componentes.EditDefault ds_contacred;
        private Componentes.EditDefault ds_contadeb;
        private System.Windows.Forms.Button btn_Empresa;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button bb_contadeb;
        private System.Windows.Forms.Button bb_contacred;
        private Componentes.EditDefault classificacaocred;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault nm_clifor;
        private Componentes.EditDefault ds_movimentacao;
        private System.Windows.Forms.Button bb_clifor;
        private System.Windows.Forms.Button bb_movimentacao;
        private Componentes.EditDefault cd_movimentacao;
        private Componentes.EditDefault cd_clifor;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault cd_contadeb;
        private Componentes.EditDefault cd_contacred;
        private System.Windows.Forms.BindingSource bsCfgFat;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditDefault cd_grupo;
        private Componentes.EditDefault ds_grupo;
        private System.Windows.Forms.Button bb_grupo;
    }
}