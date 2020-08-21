namespace Contabil
{
    partial class TFCFGCartao_DC
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label30;
            System.Windows.Forms.Label label28;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCFGCartao_DC));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_contagersai = new Componentes.EditDefault(this.components);
            this.bb_contagersai = new System.Windows.Forms.Button();
            this.cd_contagersai = new Componentes.EditDefault(this.components);
            this.tp_movimento = new Componentes.ComboBoxDefault(this.components);
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
            this.ds_contagerent = new Componentes.EditDefault(this.components);
            this.bb_contagerent = new System.Windows.Forms.Button();
            this.cd_contagerent = new Componentes.EditDefault(this.components);
            this.bsCartao = new System.Windows.Forms.BindingSource(this.components);
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartao)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(21, 59);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 13);
            label1.TabIndex = 208;
            label1.Text = "Conta Ger. Saida:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(50, 87);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 13);
            label2.TabIndex = 204;
            label2.Text = "Movimento:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label26.Location = new System.Drawing.Point(24, 140);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(88, 13);
            label26.TabIndex = 196;
            label26.Text = "Conta Crédito:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label27.Location = new System.Drawing.Point(27, 114);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(85, 13);
            label27.TabIndex = 197;
            label27.Text = "Conta Débito:";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label30.Location = new System.Drawing.Point(61, 8);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(51, 13);
            label30.TabIndex = 203;
            label30.Text = "Empresa:";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label28.Location = new System.Drawing.Point(11, 33);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(101, 13);
            label28.TabIndex = 201;
            label28.Text = "Conta Ger. Entrada:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(752, 43);
            this.barraMenu.TabIndex = 17;
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
            this.pDados.Controls.Add(this.ds_contagersai);
            this.pDados.Controls.Add(this.bb_contagersai);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.cd_contagersai);
            this.pDados.Controls.Add(this.tp_movimento);
            this.pDados.Controls.Add(label2);
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
            this.pDados.Controls.Add(this.ds_contagerent);
            this.pDados.Controls.Add(this.bb_contagerent);
            this.pDados.Controls.Add(label28);
            this.pDados.Controls.Add(this.cd_contagerent);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(752, 166);
            this.pDados.TabIndex = 18;
            // 
            // ds_contagersai
            // 
            this.ds_contagersai.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contagersai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contagersai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contagersai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Ds_contager_saida", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contagersai.Enabled = false;
            this.ds_contagersai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contagersai.Location = new System.Drawing.Point(228, 57);
            this.ds_contagersai.Name = "ds_contagersai";
            this.ds_contagersai.NM_Alias = "a";
            this.ds_contagersai.NM_Campo = "ds_contager";
            this.ds_contagersai.NM_CampoBusca = "ds_contager";
            this.ds_contagersai.NM_Param = "@P_DS_MOVIMENTACAO";
            this.ds_contagersai.QTD_Zero = 0;
            this.ds_contagersai.Size = new System.Drawing.Size(515, 20);
            this.ds_contagersai.ST_AutoInc = false;
            this.ds_contagersai.ST_DisableAuto = false;
            this.ds_contagersai.ST_Float = false;
            this.ds_contagersai.ST_Gravar = false;
            this.ds_contagersai.ST_Int = false;
            this.ds_contagersai.ST_LimpaCampo = true;
            this.ds_contagersai.ST_NotNull = false;
            this.ds_contagersai.ST_PrimaryKey = false;
            this.ds_contagersai.TabIndex = 207;
            this.ds_contagersai.TextOld = null;
            // 
            // bb_contagersai
            // 
            this.bb_contagersai.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contagersai.Image = ((System.Drawing.Image)(resources.GetObject("bb_contagersai.Image")));
            this.bb_contagersai.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contagersai.Location = new System.Drawing.Point(195, 58);
            this.bb_contagersai.Name = "bb_contagersai";
            this.bb_contagersai.Size = new System.Drawing.Size(30, 20);
            this.bb_contagersai.TabIndex = 5;
            this.bb_contagersai.UseVisualStyleBackColor = false;
            this.bb_contagersai.Click += new System.EventHandler(this.bb_contagersai_Click);
            // 
            // cd_contagersai
            // 
            this.cd_contagersai.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contagersai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contagersai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contagersai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Cd_contager_saida", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contagersai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contagersai.Location = new System.Drawing.Point(118, 57);
            this.cd_contagersai.Name = "cd_contagersai";
            this.cd_contagersai.NM_Alias = "a";
            this.cd_contagersai.NM_Campo = "cd_contager";
            this.cd_contagersai.NM_CampoBusca = "cd_contager";
            this.cd_contagersai.NM_Param = "@P_CD_MOVIMENTACAO";
            this.cd_contagersai.QTD_Zero = 0;
            this.cd_contagersai.Size = new System.Drawing.Size(73, 20);
            this.cd_contagersai.ST_AutoInc = false;
            this.cd_contagersai.ST_DisableAuto = false;
            this.cd_contagersai.ST_Float = false;
            this.cd_contagersai.ST_Gravar = true;
            this.cd_contagersai.ST_Int = true;
            this.cd_contagersai.ST_LimpaCampo = true;
            this.cd_contagersai.ST_NotNull = true;
            this.cd_contagersai.ST_PrimaryKey = false;
            this.cd_contagersai.TabIndex = 4;
            this.cd_contagersai.TextOld = null;
            this.cd_contagersai.Leave += new System.EventHandler(this.cd_contagersai_Leave);
            // 
            // tp_movimento
            // 
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCartao, "TP_Movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_movimento.FormattingEnabled = true;
            this.tp_movimento.Location = new System.Drawing.Point(118, 84);
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
            // classificacaodeb
            // 
            this.classificacaodeb.BackColor = System.Drawing.SystemColors.Window;
            this.classificacaodeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacaodeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacaodeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Cd_classificacao_deb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.classificacaodeb.Enabled = false;
            this.classificacaodeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.classificacaodeb.Location = new System.Drawing.Point(620, 110);
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
            this.classificacaodeb.TabIndex = 198;
            this.classificacaodeb.TextOld = null;
            // 
            // ds_contacred
            // 
            this.ds_contacred.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contacred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contacred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contacred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Ds_conta_ctb_cred", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contacred.Enabled = false;
            this.ds_contacred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contacred.Location = new System.Drawing.Point(228, 136);
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
            this.ds_contacred.TabIndex = 195;
            this.ds_contacred.TextOld = null;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(118, 5);
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
            this.cd_contadeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Cd_conta_ctb_debstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contadeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contadeb.Location = new System.Drawing.Point(118, 111);
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
            this.ds_contadeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Ds_conta_ctb_deb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contadeb.Enabled = false;
            this.ds_contadeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contadeb.Location = new System.Drawing.Point(228, 110);
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
            this.ds_contadeb.TabIndex = 194;
            this.ds_contadeb.TextOld = null;
            // 
            // btn_Empresa
            // 
            this.btn_Empresa.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Empresa.Image")));
            this.btn_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Empresa.Location = new System.Drawing.Point(195, 5);
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
            this.cd_contacred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Cd_conta_ctb_credstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contacred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contacred.Location = new System.Drawing.Point(118, 137);
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
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(228, 5);
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
            this.NM_Empresa.TabIndex = 202;
            this.NM_Empresa.TextOld = null;
            // 
            // bb_contadeb
            // 
            this.bb_contadeb.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contadeb.Image = ((System.Drawing.Image)(resources.GetObject("bb_contadeb.Image")));
            this.bb_contadeb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contadeb.Location = new System.Drawing.Point(195, 111);
            this.bb_contadeb.Name = "bb_contadeb";
            this.bb_contadeb.Size = new System.Drawing.Size(30, 20);
            this.bb_contadeb.TabIndex = 8;
            this.bb_contadeb.UseVisualStyleBackColor = false;
            this.bb_contadeb.Click += new System.EventHandler(this.bb_contadeb_Click);
            // 
            // bb_contacred
            // 
            this.bb_contacred.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contacred.Image = ((System.Drawing.Image)(resources.GetObject("bb_contacred.Image")));
            this.bb_contacred.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contacred.Location = new System.Drawing.Point(195, 136);
            this.bb_contacred.Name = "bb_contacred";
            this.bb_contacred.Size = new System.Drawing.Size(30, 20);
            this.bb_contacred.TabIndex = 10;
            this.bb_contacred.UseVisualStyleBackColor = false;
            this.bb_contacred.Click += new System.EventHandler(this.bb_contacred_Click);
            // 
            // classificacaocred
            // 
            this.classificacaocred.BackColor = System.Drawing.SystemColors.Window;
            this.classificacaocred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacaocred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacaocred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Cd_classificacao_cred", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.classificacaocred.Enabled = false;
            this.classificacaocred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.classificacaocred.Location = new System.Drawing.Point(620, 136);
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
            this.classificacaocred.TabIndex = 199;
            this.classificacaocred.TextOld = null;
            // 
            // ds_contagerent
            // 
            this.ds_contagerent.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contagerent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contagerent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contagerent.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Ds_contager_entrada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contagerent.Enabled = false;
            this.ds_contagerent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contagerent.Location = new System.Drawing.Point(228, 31);
            this.ds_contagerent.Name = "ds_contagerent";
            this.ds_contagerent.NM_Alias = "a";
            this.ds_contagerent.NM_Campo = "ds_contager";
            this.ds_contagerent.NM_CampoBusca = "ds_contager";
            this.ds_contagerent.NM_Param = "@P_DS_MOVIMENTACAO";
            this.ds_contagerent.QTD_Zero = 0;
            this.ds_contagerent.Size = new System.Drawing.Size(515, 20);
            this.ds_contagerent.ST_AutoInc = false;
            this.ds_contagerent.ST_DisableAuto = false;
            this.ds_contagerent.ST_Float = false;
            this.ds_contagerent.ST_Gravar = false;
            this.ds_contagerent.ST_Int = false;
            this.ds_contagerent.ST_LimpaCampo = true;
            this.ds_contagerent.ST_NotNull = false;
            this.ds_contagerent.ST_PrimaryKey = false;
            this.ds_contagerent.TabIndex = 200;
            this.ds_contagerent.TextOld = null;
            // 
            // bb_contagerent
            // 
            this.bb_contagerent.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contagerent.Image = ((System.Drawing.Image)(resources.GetObject("bb_contagerent.Image")));
            this.bb_contagerent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contagerent.Location = new System.Drawing.Point(195, 32);
            this.bb_contagerent.Name = "bb_contagerent";
            this.bb_contagerent.Size = new System.Drawing.Size(30, 20);
            this.bb_contagerent.TabIndex = 3;
            this.bb_contagerent.UseVisualStyleBackColor = false;
            this.bb_contagerent.Click += new System.EventHandler(this.bb_contagerent_Click);
            // 
            // cd_contagerent
            // 
            this.cd_contagerent.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contagerent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contagerent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contagerent.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartao, "Cd_contager_entrada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contagerent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contagerent.Location = new System.Drawing.Point(118, 31);
            this.cd_contagerent.Name = "cd_contagerent";
            this.cd_contagerent.NM_Alias = "a";
            this.cd_contagerent.NM_Campo = "cd_contager";
            this.cd_contagerent.NM_CampoBusca = "cd_contager";
            this.cd_contagerent.NM_Param = "@P_CD_MOVIMENTACAO";
            this.cd_contagerent.QTD_Zero = 0;
            this.cd_contagerent.Size = new System.Drawing.Size(73, 20);
            this.cd_contagerent.ST_AutoInc = false;
            this.cd_contagerent.ST_DisableAuto = false;
            this.cd_contagerent.ST_Float = false;
            this.cd_contagerent.ST_Gravar = true;
            this.cd_contagerent.ST_Int = true;
            this.cd_contagerent.ST_LimpaCampo = true;
            this.cd_contagerent.ST_NotNull = true;
            this.cd_contagerent.ST_PrimaryKey = false;
            this.cd_contagerent.TabIndex = 2;
            this.cd_contagerent.TextOld = null;
            this.cd_contagerent.Leave += new System.EventHandler(this.cd_contagerent_Leave);
            // 
            // bsCartao
            // 
            this.bsCartao.DataSource = typeof(CamadaDados.Contabil.TList_CTB_CFGCartao_DC);
            // 
            // TFCFGCartao_DC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 209);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCFGCartao_DC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração Cartão Crédito/Débito";
            this.Load += new System.EventHandler(this.TFCFGCartao_DC_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCFGCartao_DC_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_contagersai;
        private System.Windows.Forms.Button bb_contagersai;
        private Componentes.EditDefault cd_contagersai;
        private Componentes.ComboBoxDefault tp_movimento;
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
        private Componentes.EditDefault ds_contagerent;
        private System.Windows.Forms.Button bb_contagerent;
        private Componentes.EditDefault cd_contagerent;
        private System.Windows.Forms.BindingSource bsCartao;
    }
}