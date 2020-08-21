namespace Contabil
{
    partial class TFCFGCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCFGCaixa));
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label30;
            System.Windows.Forms.Label label28;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.tp_movimento = new Componentes.ComboBoxDefault(this.components);
            this.bsCaixa = new System.Windows.Forms.BindingSource(this.components);
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.bb_historico = new System.Windows.Forms.Button();
            this.cd_historico = new Componentes.EditDefault(this.components);
            this.classificacaodeb = new Componentes.EditDefault(this.components);
            this.ds_contacred = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.cd_contadeb = new Componentes.EditDefault(this.components);
            this.ds_contadeb = new Componentes.EditDefault(this.components);
            this.btn_Empresa = new System.Windows.Forms.Button();
            this.cd_contacred = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.bb_contadeb = new System.Windows.Forms.Button();
            this.bb_contacred = new System.Windows.Forms.Button();
            this.classificacaocred = new Componentes.EditDefault(this.components);
            this.ds_contager = new Componentes.EditDefault(this.components);
            this.bb_contager = new System.Windows.Forms.Button();
            this.cd_contager = new Componentes.EditDefault(this.components);
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCaixa)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(733, 43);
            this.barraMenu.TabIndex = 15;
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
            this.pDados.Controls.Add(this.tp_movimento);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.ds_historico);
            this.pDados.Controls.Add(this.bb_historico);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.cd_historico);
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
            this.pDados.Controls.Add(this.classificacaocred);
            this.pDados.Controls.Add(this.ds_contager);
            this.pDados.Controls.Add(this.bb_contager);
            this.pDados.Controls.Add(label28);
            this.pDados.Controls.Add(this.cd_contager);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(733, 162);
            this.pDados.TabIndex = 0;
            // 
            // tp_movimento
            // 
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCaixa, "TP_Movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_movimento.FormattingEnabled = true;
            this.tp_movimento.Location = new System.Drawing.Point(102, 83);
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "";
            this.tp_movimento.NM_Campo = "";
            this.tp_movimento.NM_Param = "";
            this.tp_movimento.Size = new System.Drawing.Size(218, 21);
            this.tp_movimento.ST_Gravar = true;
            this.tp_movimento.ST_LimparCampo = true;
            this.tp_movimento.ST_NotNull = true;
            this.tp_movimento.TabIndex = 6;
            // 
            // bsCaixa
            // 
            this.bsCaixa.DataSource = typeof(CamadaDados.Contabil.TList_CTB_CFGCaixa);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(34, 86);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 13);
            label2.TabIndex = 184;
            label2.Text = "Movimento:";
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "DS_Historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_historico.Enabled = false;
            this.ds_historico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_historico.Location = new System.Drawing.Point(212, 57);
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "a";
            this.ds_historico.NM_Campo = "ds_historico";
            this.ds_historico.NM_CampoBusca = "ds_historico";
            this.ds_historico.NM_Param = "@P_DS_MOVIMENTACAO";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.Size = new System.Drawing.Size(515, 20);
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = false;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = false;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TabIndex = 182;
            this.ds_historico.TextOld = null;
            // 
            // bb_historico
            // 
            this.bb_historico.BackColor = System.Drawing.SystemColors.Control;
            this.bb_historico.Image = ((System.Drawing.Image)(resources.GetObject("bb_historico.Image")));
            this.bb_historico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_historico.Location = new System.Drawing.Point(179, 58);
            this.bb_historico.Name = "bb_historico";
            this.bb_historico.Size = new System.Drawing.Size(30, 20);
            this.bb_historico.TabIndex = 5;
            this.bb_historico.UseVisualStyleBackColor = false;
            this.bb_historico.Click += new System.EventHandler(this.bb_historico_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(45, 59);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 13);
            label1.TabIndex = 183;
            label1.Text = "Historico:";
            // 
            // cd_historico
            // 
            this.cd_historico.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "CD_Historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_historico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_historico.Location = new System.Drawing.Point(102, 57);
            this.cd_historico.Name = "cd_historico";
            this.cd_historico.NM_Alias = "a";
            this.cd_historico.NM_Campo = "cd_historico";
            this.cd_historico.NM_CampoBusca = "cd_historico";
            this.cd_historico.NM_Param = "@P_CD_MOVIMENTACAO";
            this.cd_historico.QTD_Zero = 0;
            this.cd_historico.Size = new System.Drawing.Size(73, 20);
            this.cd_historico.ST_AutoInc = false;
            this.cd_historico.ST_DisableAuto = false;
            this.cd_historico.ST_Float = false;
            this.cd_historico.ST_Gravar = true;
            this.cd_historico.ST_Int = true;
            this.cd_historico.ST_LimpaCampo = true;
            this.cd_historico.ST_NotNull = true;
            this.cd_historico.ST_PrimaryKey = false;
            this.cd_historico.TabIndex = 4;
            this.cd_historico.TextOld = null;
            this.cd_historico.Leave += new System.EventHandler(this.cd_historico_Leave);
            // 
            // classificacaodeb
            // 
            this.classificacaodeb.BackColor = System.Drawing.SystemColors.Window;
            this.classificacaodeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacaodeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacaodeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "CD_Classificacao_DEB", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.classificacaodeb.Enabled = false;
            this.classificacaodeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.classificacaodeb.Location = new System.Drawing.Point(604, 109);
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
            this.classificacaodeb.TabIndex = 176;
            this.classificacaodeb.TextOld = null;
            // 
            // ds_contacred
            // 
            this.ds_contacred.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contacred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contacred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contacred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "DS_Conta_CTB_CRED", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contacred.Enabled = false;
            this.ds_contacred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contacred.Location = new System.Drawing.Point(212, 135);
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
            this.ds_contacred.TabIndex = 173;
            this.ds_contacred.TextOld = null;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "CD_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(102, 5);
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
            this.cd_contadeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "CD_Conta_CTB_DEB_String", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contadeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contadeb.Location = new System.Drawing.Point(102, 110);
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
            this.cd_contadeb.TabIndex = 7;
            this.cd_contadeb.TextOld = null;
            this.cd_contadeb.Leave += new System.EventHandler(this.cd_contadeb_Leave);
            // 
            // ds_contadeb
            // 
            this.ds_contadeb.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contadeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contadeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contadeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "DS_Conta_CTB_DEB", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contadeb.Enabled = false;
            this.ds_contadeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contadeb.Location = new System.Drawing.Point(212, 109);
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
            this.ds_contadeb.TabIndex = 172;
            this.ds_contadeb.TextOld = null;
            // 
            // btn_Empresa
            // 
            this.btn_Empresa.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Empresa.Image")));
            this.btn_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Empresa.Location = new System.Drawing.Point(179, 5);
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
            this.cd_contacred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "CD_Conta_CTB_CRED_String", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contacred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contacred.Location = new System.Drawing.Point(102, 136);
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
            this.cd_contacred.TabIndex = 9;
            this.cd_contacred.TextOld = null;
            this.cd_contacred.Leave += new System.EventHandler(this.cd_contacred_Leave);
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label26.Location = new System.Drawing.Point(8, 139);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(88, 13);
            label26.TabIndex = 174;
            label26.Text = "Conta Crédito:";
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "NM_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(212, 5);
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
            this.NM_Empresa.TabIndex = 180;
            this.NM_Empresa.TextOld = null;
            // 
            // bb_contadeb
            // 
            this.bb_contadeb.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contadeb.Image = ((System.Drawing.Image)(resources.GetObject("bb_contadeb.Image")));
            this.bb_contadeb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contadeb.Location = new System.Drawing.Point(179, 110);
            this.bb_contadeb.Name = "bb_contadeb";
            this.bb_contadeb.Size = new System.Drawing.Size(30, 20);
            this.bb_contadeb.TabIndex = 8;
            this.bb_contadeb.UseVisualStyleBackColor = false;
            this.bb_contadeb.Click += new System.EventHandler(this.bb_contadeb_Click);
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label27.Location = new System.Drawing.Point(11, 113);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(85, 13);
            label27.TabIndex = 175;
            label27.Text = "Conta Débito:";
            // 
            // bb_contacred
            // 
            this.bb_contacred.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contacred.Image = ((System.Drawing.Image)(resources.GetObject("bb_contacred.Image")));
            this.bb_contacred.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contacred.Location = new System.Drawing.Point(179, 135);
            this.bb_contacred.Name = "bb_contacred";
            this.bb_contacred.Size = new System.Drawing.Size(30, 20);
            this.bb_contacred.TabIndex = 10;
            this.bb_contacred.UseVisualStyleBackColor = false;
            this.bb_contacred.Click += new System.EventHandler(this.bb_contacred_Click);
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label30.Location = new System.Drawing.Point(45, 8);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(51, 13);
            label30.TabIndex = 181;
            label30.Text = "Empresa:";
            // 
            // classificacaocred
            // 
            this.classificacaocred.BackColor = System.Drawing.SystemColors.Window;
            this.classificacaocred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacaocred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacaocred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "CD_Classificacao_CRED", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.classificacaocred.Enabled = false;
            this.classificacaocred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.classificacaocred.Location = new System.Drawing.Point(604, 135);
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
            this.classificacaocred.TabIndex = 177;
            this.classificacaocred.TextOld = null;
            // 
            // ds_contager
            // 
            this.ds_contager.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "DS_ContaGer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contager.Enabled = false;
            this.ds_contager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contager.Location = new System.Drawing.Point(212, 31);
            this.ds_contager.Name = "ds_contager";
            this.ds_contager.NM_Alias = "a";
            this.ds_contager.NM_Campo = "ds_contager";
            this.ds_contager.NM_CampoBusca = "ds_contager";
            this.ds_contager.NM_Param = "@P_DS_MOVIMENTACAO";
            this.ds_contager.QTD_Zero = 0;
            this.ds_contager.Size = new System.Drawing.Size(515, 20);
            this.ds_contager.ST_AutoInc = false;
            this.ds_contager.ST_DisableAuto = false;
            this.ds_contager.ST_Float = false;
            this.ds_contager.ST_Gravar = false;
            this.ds_contager.ST_Int = false;
            this.ds_contager.ST_LimpaCampo = true;
            this.ds_contager.ST_NotNull = false;
            this.ds_contager.ST_PrimaryKey = false;
            this.ds_contager.TabIndex = 178;
            this.ds_contager.TextOld = null;
            // 
            // bb_contager
            // 
            this.bb_contager.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contager.Image = ((System.Drawing.Image)(resources.GetObject("bb_contager.Image")));
            this.bb_contager.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contager.Location = new System.Drawing.Point(179, 32);
            this.bb_contager.Name = "bb_contager";
            this.bb_contager.Size = new System.Drawing.Size(30, 20);
            this.bb_contager.TabIndex = 3;
            this.bb_contager.UseVisualStyleBackColor = false;
            this.bb_contager.Click += new System.EventHandler(this.bb_contager_Click);
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label28.Location = new System.Drawing.Point(10, 33);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(86, 13);
            label28.TabIndex = 179;
            label28.Text = "Conta Gerencial:";
            // 
            // cd_contager
            // 
            this.cd_contager.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixa, "CD_ContaGer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contager.Location = new System.Drawing.Point(102, 31);
            this.cd_contager.Name = "cd_contager";
            this.cd_contager.NM_Alias = "a";
            this.cd_contager.NM_Campo = "cd_contager";
            this.cd_contager.NM_CampoBusca = "cd_contager";
            this.cd_contager.NM_Param = "@P_CD_MOVIMENTACAO";
            this.cd_contager.QTD_Zero = 0;
            this.cd_contager.Size = new System.Drawing.Size(73, 20);
            this.cd_contager.ST_AutoInc = false;
            this.cd_contager.ST_DisableAuto = false;
            this.cd_contager.ST_Float = false;
            this.cd_contager.ST_Gravar = true;
            this.cd_contager.ST_Int = true;
            this.cd_contager.ST_LimpaCampo = true;
            this.cd_contager.ST_NotNull = true;
            this.cd_contager.ST_PrimaryKey = false;
            this.cd_contager.TabIndex = 2;
            this.cd_contager.TextOld = null;
            this.cd_contager.Leave += new System.EventHandler(this.cd_contager_Leave);
            // 
            // TFCFGCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 205);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCFGCaixa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração Caixa Avulso";
            this.Load += new System.EventHandler(this.TFCFGCaixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCFGCaixa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCaixa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_historico;
        private System.Windows.Forms.Button bb_historico;
        private Componentes.EditDefault cd_historico;
        private Componentes.EditDefault classificacaodeb;
        private Componentes.EditDefault ds_contacred;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditDefault cd_contadeb;
        private Componentes.EditDefault ds_contadeb;
        private System.Windows.Forms.Button btn_Empresa;
        private Componentes.EditDefault cd_contacred;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button bb_contadeb;
        private System.Windows.Forms.Button bb_contacred;
        private Componentes.EditDefault classificacaocred;
        private Componentes.EditDefault ds_contager;
        private System.Windows.Forms.Button bb_contager;
        private Componentes.EditDefault cd_contager;
        private System.Windows.Forms.BindingSource bsCaixa;
        private Componentes.ComboBoxDefault tp_movimento;
    }
}