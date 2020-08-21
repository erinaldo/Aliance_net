namespace Contabil
{
    partial class TFLanctoNormalAvulso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanctoNormalAvulso));
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.compHistorico = new Componentes.EditDefault(this.components);
            this.vl_lancto = new Componentes.EditFloat(this.components);
            this.dt_lancto = new Componentes.EditData(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.classificacaodeb = new Componentes.EditDefault(this.components);
            this.ds_contadeb = new Componentes.EditDefault(this.components);
            this.bb_contadeb = new System.Windows.Forms.Button();
            this.cd_contadeb = new Componentes.EditDefault(this.components);
            this.classificacaocred = new Componentes.EditDefault(this.components);
            this.ds_contacred = new Componentes.EditDefault(this.components);
            this.bb_contacred = new System.Windows.Forms.Button();
            this.cd_contacred = new Componentes.EditDefault(this.components);
            this.nr_docto = new Componentes.EditDefault(this.components);
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_lancto)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(659, 43);
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
            this.pDados.Controls.Add(this.nr_docto);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.classificacaocred);
            this.pDados.Controls.Add(this.ds_contacred);
            this.pDados.Controls.Add(this.bb_contacred);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.cd_contacred);
            this.pDados.Controls.Add(this.compHistorico);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(this.vl_lancto);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.dt_lancto);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.classificacaodeb);
            this.pDados.Controls.Add(this.ds_contadeb);
            this.pDados.Controls.Add(this.bb_contadeb);
            this.pDados.Controls.Add(label10);
            this.pDados.Controls.Add(this.cd_contadeb);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(659, 200);
            this.pDados.TabIndex = 0;
            // 
            // compHistorico
            // 
            this.compHistorico.BackColor = System.Drawing.SystemColors.Window;
            this.compHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.compHistorico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.compHistorico.Location = new System.Drawing.Point(85, 123);
            this.compHistorico.MaxLength = 1024;
            this.compHistorico.Multiline = true;
            this.compHistorico.Name = "compHistorico";
            this.compHistorico.NM_Alias = "";
            this.compHistorico.NM_Campo = "";
            this.compHistorico.NM_CampoBusca = "";
            this.compHistorico.NM_Param = "";
            this.compHistorico.QTD_Zero = 0;
            this.compHistorico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.compHistorico.Size = new System.Drawing.Size(559, 68);
            this.compHistorico.ST_AutoInc = false;
            this.compHistorico.ST_DisableAuto = false;
            this.compHistorico.ST_Float = false;
            this.compHistorico.ST_Gravar = false;
            this.compHistorico.ST_Int = false;
            this.compHistorico.ST_LimpaCampo = true;
            this.compHistorico.ST_NotNull = false;
            this.compHistorico.ST_PrimaryKey = false;
            this.compHistorico.TabIndex = 9;
            this.compHistorico.TextOld = null;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(82, 107);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(71, 13);
            label5.TabIndex = 89;
            label5.Text = "Complemento";
            // 
            // vl_lancto
            // 
            this.vl_lancto.DecimalPlaces = 2;
            this.vl_lancto.Location = new System.Drawing.Point(215, 84);
            this.vl_lancto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_lancto.Name = "vl_lancto";
            this.vl_lancto.NM_Alias = "";
            this.vl_lancto.NM_Campo = "";
            this.vl_lancto.NM_Param = "";
            this.vl_lancto.Operador = "";
            this.vl_lancto.Size = new System.Drawing.Size(129, 20);
            this.vl_lancto.ST_AutoInc = false;
            this.vl_lancto.ST_DisableAuto = false;
            this.vl_lancto.ST_Gravar = true;
            this.vl_lancto.ST_LimparCampo = true;
            this.vl_lancto.ST_NotNull = true;
            this.vl_lancto.ST_PrimaryKey = false;
            this.vl_lancto.TabIndex = 7;
            this.vl_lancto.ThousandsSeparator = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(175, 86);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(34, 13);
            label3.TabIndex = 88;
            label3.Text = "Valor:";
            // 
            // dt_lancto
            // 
            this.dt_lancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_lancto.Location = new System.Drawing.Point(85, 84);
            this.dt_lancto.Mask = "00/00/0000";
            this.dt_lancto.Name = "dt_lancto";
            this.dt_lancto.NM_Alias = "";
            this.dt_lancto.NM_Campo = "";
            this.dt_lancto.NM_CampoBusca = "";
            this.dt_lancto.NM_Param = "";
            this.dt_lancto.Operador = "";
            this.dt_lancto.Size = new System.Drawing.Size(84, 20);
            this.dt_lancto.ST_Gravar = true;
            this.dt_lancto.ST_LimpaCampo = true;
            this.dt_lancto.ST_NotNull = true;
            this.dt_lancto.ST_PrimaryKey = false;
            this.dt_lancto.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(46, 86);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 13);
            label2.TabIndex = 87;
            label2.Text = "Data:";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.Color.White;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(175, 6);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_CD_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(469, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = true;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 86;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(141, 6);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(28, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 13);
            label1.TabIndex = 85;
            label1.Text = "Empresa:";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Location = new System.Drawing.Point(85, 6);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(55, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // classificacaodeb
            // 
            this.classificacaodeb.BackColor = System.Drawing.Color.White;
            this.classificacaodeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacaodeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacaodeb.Enabled = false;
            this.classificacaodeb.Location = new System.Drawing.Point(490, 33);
            this.classificacaodeb.Name = "classificacaodeb";
            this.classificacaodeb.NM_Alias = "";
            this.classificacaodeb.NM_Campo = "CD_Classificacao";
            this.classificacaodeb.NM_CampoBusca = "CD_Classificacao";
            this.classificacaodeb.NM_Param = "@P_CD_EMPRESA";
            this.classificacaodeb.QTD_Zero = 0;
            this.classificacaodeb.Size = new System.Drawing.Size(154, 20);
            this.classificacaodeb.ST_AutoInc = false;
            this.classificacaodeb.ST_DisableAuto = false;
            this.classificacaodeb.ST_Float = false;
            this.classificacaodeb.ST_Gravar = false;
            this.classificacaodeb.ST_Int = true;
            this.classificacaodeb.ST_LimpaCampo = true;
            this.classificacaodeb.ST_NotNull = false;
            this.classificacaodeb.ST_PrimaryKey = false;
            this.classificacaodeb.TabIndex = 84;
            this.classificacaodeb.TextOld = null;
            // 
            // ds_contadeb
            // 
            this.ds_contadeb.BackColor = System.Drawing.Color.White;
            this.ds_contadeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contadeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contadeb.Enabled = false;
            this.ds_contadeb.Location = new System.Drawing.Point(189, 33);
            this.ds_contadeb.Name = "ds_contadeb";
            this.ds_contadeb.NM_Alias = "";
            this.ds_contadeb.NM_Campo = "DS_ContaCTB";
            this.ds_contadeb.NM_CampoBusca = "DS_ContaCTB";
            this.ds_contadeb.NM_Param = "@P_CD_EMPRESA";
            this.ds_contadeb.QTD_Zero = 0;
            this.ds_contadeb.Size = new System.Drawing.Size(300, 20);
            this.ds_contadeb.ST_AutoInc = false;
            this.ds_contadeb.ST_DisableAuto = false;
            this.ds_contadeb.ST_Float = false;
            this.ds_contadeb.ST_Gravar = false;
            this.ds_contadeb.ST_Int = true;
            this.ds_contadeb.ST_LimpaCampo = true;
            this.ds_contadeb.ST_NotNull = false;
            this.ds_contadeb.ST_PrimaryKey = false;
            this.ds_contadeb.TabIndex = 83;
            this.ds_contadeb.TextOld = null;
            // 
            // bb_contadeb
            // 
            this.bb_contadeb.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contadeb.Image = ((System.Drawing.Image)(resources.GetObject("bb_contadeb.Image")));
            this.bb_contadeb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contadeb.Location = new System.Drawing.Point(155, 33);
            this.bb_contadeb.Name = "bb_contadeb";
            this.bb_contadeb.Size = new System.Drawing.Size(28, 19);
            this.bb_contadeb.TabIndex = 3;
            this.bb_contadeb.UseVisualStyleBackColor = false;
            this.bb_contadeb.Click += new System.EventHandler(this.bb_contadeb_Click);
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label10.Location = new System.Drawing.Point(7, 35);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(72, 13);
            label10.TabIndex = 82;
            label10.Text = "Conta Débito:";
            // 
            // cd_contadeb
            // 
            this.cd_contadeb.BackColor = System.Drawing.Color.White;
            this.cd_contadeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contadeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contadeb.Location = new System.Drawing.Point(85, 32);
            this.cd_contadeb.Name = "cd_contadeb";
            this.cd_contadeb.NM_Alias = "";
            this.cd_contadeb.NM_Campo = "CD_Conta_CTB";
            this.cd_contadeb.NM_CampoBusca = "CD_Conta_CTB";
            this.cd_contadeb.NM_Param = "@P_CD_EMPRESA";
            this.cd_contadeb.QTD_Zero = 0;
            this.cd_contadeb.Size = new System.Drawing.Size(68, 20);
            this.cd_contadeb.ST_AutoInc = false;
            this.cd_contadeb.ST_DisableAuto = false;
            this.cd_contadeb.ST_Float = false;
            this.cd_contadeb.ST_Gravar = true;
            this.cd_contadeb.ST_Int = true;
            this.cd_contadeb.ST_LimpaCampo = true;
            this.cd_contadeb.ST_NotNull = true;
            this.cd_contadeb.ST_PrimaryKey = false;
            this.cd_contadeb.TabIndex = 2;
            this.cd_contadeb.TextOld = null;
            this.cd_contadeb.Leave += new System.EventHandler(this.cd_contadeb_Leave);
            // 
            // classificacaocred
            // 
            this.classificacaocred.BackColor = System.Drawing.Color.White;
            this.classificacaocred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacaocred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacaocred.Enabled = false;
            this.classificacaocred.Location = new System.Drawing.Point(490, 59);
            this.classificacaocred.Name = "classificacaocred";
            this.classificacaocred.NM_Alias = "";
            this.classificacaocred.NM_Campo = "CD_Classificacao";
            this.classificacaocred.NM_CampoBusca = "CD_Classificacao";
            this.classificacaocred.NM_Param = "@P_CD_EMPRESA";
            this.classificacaocred.QTD_Zero = 0;
            this.classificacaocred.Size = new System.Drawing.Size(154, 20);
            this.classificacaocred.ST_AutoInc = false;
            this.classificacaocred.ST_DisableAuto = false;
            this.classificacaocred.ST_Float = false;
            this.classificacaocred.ST_Gravar = false;
            this.classificacaocred.ST_Int = true;
            this.classificacaocred.ST_LimpaCampo = true;
            this.classificacaocred.ST_NotNull = false;
            this.classificacaocred.ST_PrimaryKey = false;
            this.classificacaocred.TabIndex = 94;
            this.classificacaocred.TextOld = null;
            // 
            // ds_contacred
            // 
            this.ds_contacred.BackColor = System.Drawing.Color.White;
            this.ds_contacred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contacred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contacred.Enabled = false;
            this.ds_contacred.Location = new System.Drawing.Point(189, 59);
            this.ds_contacred.Name = "ds_contacred";
            this.ds_contacred.NM_Alias = "";
            this.ds_contacred.NM_Campo = "DS_ContaCTB";
            this.ds_contacred.NM_CampoBusca = "DS_ContaCTB";
            this.ds_contacred.NM_Param = "@P_CD_EMPRESA";
            this.ds_contacred.QTD_Zero = 0;
            this.ds_contacred.Size = new System.Drawing.Size(300, 20);
            this.ds_contacred.ST_AutoInc = false;
            this.ds_contacred.ST_DisableAuto = false;
            this.ds_contacred.ST_Float = false;
            this.ds_contacred.ST_Gravar = false;
            this.ds_contacred.ST_Int = true;
            this.ds_contacred.ST_LimpaCampo = true;
            this.ds_contacred.ST_NotNull = false;
            this.ds_contacred.ST_PrimaryKey = false;
            this.ds_contacred.TabIndex = 93;
            this.ds_contacred.TextOld = null;
            // 
            // bb_contacred
            // 
            this.bb_contacred.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contacred.Image = ((System.Drawing.Image)(resources.GetObject("bb_contacred.Image")));
            this.bb_contacred.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contacred.Location = new System.Drawing.Point(155, 59);
            this.bb_contacred.Name = "bb_contacred";
            this.bb_contacred.Size = new System.Drawing.Size(28, 19);
            this.bb_contacred.TabIndex = 5;
            this.bb_contacred.UseVisualStyleBackColor = false;
            this.bb_contacred.Click += new System.EventHandler(this.bb_contacred_Click);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(5, 61);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(74, 13);
            label4.TabIndex = 92;
            label4.Text = "Conta Crédito:";
            // 
            // cd_contacred
            // 
            this.cd_contacred.BackColor = System.Drawing.Color.White;
            this.cd_contacred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contacred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contacred.Location = new System.Drawing.Point(85, 58);
            this.cd_contacred.Name = "cd_contacred";
            this.cd_contacred.NM_Alias = "";
            this.cd_contacred.NM_Campo = "CD_Conta_CTB";
            this.cd_contacred.NM_CampoBusca = "CD_Conta_CTB";
            this.cd_contacred.NM_Param = "@P_CD_EMPRESA";
            this.cd_contacred.QTD_Zero = 0;
            this.cd_contacred.Size = new System.Drawing.Size(68, 20);
            this.cd_contacred.ST_AutoInc = false;
            this.cd_contacred.ST_DisableAuto = false;
            this.cd_contacred.ST_Float = false;
            this.cd_contacred.ST_Gravar = true;
            this.cd_contacred.ST_Int = true;
            this.cd_contacred.ST_LimpaCampo = true;
            this.cd_contacred.ST_NotNull = true;
            this.cd_contacred.ST_PrimaryKey = false;
            this.cd_contacred.TabIndex = 4;
            this.cd_contacred.TextOld = null;
            this.cd_contacred.Leave += new System.EventHandler(this.cd_contacred_Leave);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(350, 86);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(80, 13);
            label6.TabIndex = 95;
            label6.Text = "Nº Documento:";
            // 
            // nr_docto
            // 
            this.nr_docto.BackColor = System.Drawing.SystemColors.Window;
            this.nr_docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_docto.Location = new System.Drawing.Point(436, 85);
            this.nr_docto.Name = "nr_docto";
            this.nr_docto.NM_Alias = "";
            this.nr_docto.NM_Campo = "";
            this.nr_docto.NM_CampoBusca = "";
            this.nr_docto.NM_Param = "";
            this.nr_docto.QTD_Zero = 0;
            this.nr_docto.Size = new System.Drawing.Size(100, 20);
            this.nr_docto.ST_AutoInc = false;
            this.nr_docto.ST_DisableAuto = false;
            this.nr_docto.ST_Float = false;
            this.nr_docto.ST_Gravar = false;
            this.nr_docto.ST_Int = false;
            this.nr_docto.ST_LimpaCampo = true;
            this.nr_docto.ST_NotNull = false;
            this.nr_docto.ST_PrimaryKey = false;
            this.nr_docto.TabIndex = 8;
            this.nr_docto.TextOld = null;
            // 
            // TFLanctoNormalAvulso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 243);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanctoNormalAvulso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento Normal Avulso";
            this.Load += new System.EventHandler(this.TFLanctoNormalAvulso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanctoNormalAvulso_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_lancto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault classificacaocred;
        private Componentes.EditDefault ds_contacred;
        private System.Windows.Forms.Button bb_contacred;
        private Componentes.EditDefault cd_contacred;
        private Componentes.EditDefault compHistorico;
        private Componentes.EditFloat vl_lancto;
        private Componentes.EditData dt_lancto;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault classificacaodeb;
        private Componentes.EditDefault ds_contadeb;
        private System.Windows.Forms.Button bb_contadeb;
        private Componentes.EditDefault cd_contadeb;
        private Componentes.EditDefault nr_docto;
    }
}