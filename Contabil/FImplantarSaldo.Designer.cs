namespace Contabil
{
    partial class TFImplantarSaldo
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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFImplantarSaldo));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.compHistorico = new Componentes.EditDefault(this.components);
            this.deb_cred = new Componentes.ComboBoxDefault(this.components);
            this.vl_lancto = new Componentes.EditFloat(this.components);
            this.dt_lancto = new Componentes.EditData(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.classificacao = new Componentes.EditDefault(this.components);
            this.ds_conta_ctb = new Componentes.EditDefault(this.components);
            this.bb_conta_ctb = new System.Windows.Forms.Button();
            this.cd_conta_ctb = new Componentes.EditDefault(this.components);
            label10 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_lancto)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label10.Location = new System.Drawing.Point(11, 32);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(79, 13);
            label10.TabIndex = 61;
            label10.Text = "Conta Contabil:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(39, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 13);
            label1.TabIndex = 66;
            label1.Text = "Empresa:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(57, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 13);
            label2.TabIndex = 68;
            label2.Text = "Data:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(186, 58);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(34, 13);
            label3.TabIndex = 71;
            label3.Text = "Valor:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(361, 58);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(63, 13);
            label4.TabIndex = 73;
            label4.Text = "Déb./Créd.:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(93, 79);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(71, 13);
            label5.TabIndex = 74;
            label5.Text = "Complemento";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(665, 43);
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
            this.pDados.Controls.Add(this.compHistorico);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.deb_cred);
            this.pDados.Controls.Add(this.vl_lancto);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.dt_lancto);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.classificacao);
            this.pDados.Controls.Add(this.ds_conta_ctb);
            this.pDados.Controls.Add(this.bb_conta_ctb);
            this.pDados.Controls.Add(label10);
            this.pDados.Controls.Add(this.cd_conta_ctb);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(665, 168);
            this.pDados.TabIndex = 0;
            // 
            // compHistorico
            // 
            this.compHistorico.BackColor = System.Drawing.SystemColors.Window;
            this.compHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.compHistorico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.compHistorico.Location = new System.Drawing.Point(96, 95);
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
            this.compHistorico.TabIndex = 7;
            this.compHistorico.TextOld = null;
            // 
            // deb_cred
            // 
            this.deb_cred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deb_cred.FormattingEnabled = true;
            this.deb_cred.Location = new System.Drawing.Point(430, 55);
            this.deb_cred.Name = "deb_cred";
            this.deb_cred.NM_Alias = "";
            this.deb_cred.NM_Campo = "";
            this.deb_cred.NM_Param = "";
            this.deb_cred.Size = new System.Drawing.Size(225, 21);
            this.deb_cred.ST_Gravar = true;
            this.deb_cred.ST_LimparCampo = true;
            this.deb_cred.ST_NotNull = true;
            this.deb_cred.TabIndex = 6;
            // 
            // vl_lancto
            // 
            this.vl_lancto.DecimalPlaces = 2;
            this.vl_lancto.Location = new System.Drawing.Point(226, 56);
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
            this.vl_lancto.TabIndex = 5;
            this.vl_lancto.ThousandsSeparator = true;
            // 
            // dt_lancto
            // 
            this.dt_lancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_lancto.Location = new System.Drawing.Point(96, 56);
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
            this.dt_lancto.TabIndex = 4;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.Color.White;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(186, 3);
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
            this.nm_empresa.TabIndex = 67;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(152, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Location = new System.Drawing.Point(96, 3);
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
            // classificacao
            // 
            this.classificacao.BackColor = System.Drawing.Color.White;
            this.classificacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacao.Enabled = false;
            this.classificacao.Location = new System.Drawing.Point(501, 30);
            this.classificacao.Name = "classificacao";
            this.classificacao.NM_Alias = "";
            this.classificacao.NM_Campo = "CD_Classificacao";
            this.classificacao.NM_CampoBusca = "CD_Classificacao";
            this.classificacao.NM_Param = "@P_CD_EMPRESA";
            this.classificacao.QTD_Zero = 0;
            this.classificacao.Size = new System.Drawing.Size(154, 20);
            this.classificacao.ST_AutoInc = false;
            this.classificacao.ST_DisableAuto = false;
            this.classificacao.ST_Float = false;
            this.classificacao.ST_Gravar = false;
            this.classificacao.ST_Int = true;
            this.classificacao.ST_LimpaCampo = true;
            this.classificacao.ST_NotNull = false;
            this.classificacao.ST_PrimaryKey = false;
            this.classificacao.TabIndex = 63;
            this.classificacao.TextOld = null;
            // 
            // ds_conta_ctb
            // 
            this.ds_conta_ctb.BackColor = System.Drawing.Color.White;
            this.ds_conta_ctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_conta_ctb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_conta_ctb.Enabled = false;
            this.ds_conta_ctb.Location = new System.Drawing.Point(200, 30);
            this.ds_conta_ctb.Name = "ds_conta_ctb";
            this.ds_conta_ctb.NM_Alias = "";
            this.ds_conta_ctb.NM_Campo = "DS_ContaCTB";
            this.ds_conta_ctb.NM_CampoBusca = "DS_ContaCTB";
            this.ds_conta_ctb.NM_Param = "@P_CD_EMPRESA";
            this.ds_conta_ctb.QTD_Zero = 0;
            this.ds_conta_ctb.Size = new System.Drawing.Size(300, 20);
            this.ds_conta_ctb.ST_AutoInc = false;
            this.ds_conta_ctb.ST_DisableAuto = false;
            this.ds_conta_ctb.ST_Float = false;
            this.ds_conta_ctb.ST_Gravar = false;
            this.ds_conta_ctb.ST_Int = true;
            this.ds_conta_ctb.ST_LimpaCampo = true;
            this.ds_conta_ctb.ST_NotNull = false;
            this.ds_conta_ctb.ST_PrimaryKey = false;
            this.ds_conta_ctb.TabIndex = 62;
            this.ds_conta_ctb.TextOld = null;
            // 
            // bb_conta_ctb
            // 
            this.bb_conta_ctb.BackColor = System.Drawing.SystemColors.Control;
            this.bb_conta_ctb.Image = ((System.Drawing.Image)(resources.GetObject("bb_conta_ctb.Image")));
            this.bb_conta_ctb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_conta_ctb.Location = new System.Drawing.Point(166, 30);
            this.bb_conta_ctb.Name = "bb_conta_ctb";
            this.bb_conta_ctb.Size = new System.Drawing.Size(28, 19);
            this.bb_conta_ctb.TabIndex = 3;
            this.bb_conta_ctb.UseVisualStyleBackColor = false;
            this.bb_conta_ctb.Click += new System.EventHandler(this.bb_conta_ctb_Click);
            // 
            // cd_conta_ctb
            // 
            this.cd_conta_ctb.BackColor = System.Drawing.Color.White;
            this.cd_conta_ctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_conta_ctb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_conta_ctb.Location = new System.Drawing.Point(96, 29);
            this.cd_conta_ctb.Name = "cd_conta_ctb";
            this.cd_conta_ctb.NM_Alias = "";
            this.cd_conta_ctb.NM_Campo = "CD_Conta_CTB";
            this.cd_conta_ctb.NM_CampoBusca = "CD_Conta_CTB";
            this.cd_conta_ctb.NM_Param = "@P_CD_EMPRESA";
            this.cd_conta_ctb.QTD_Zero = 0;
            this.cd_conta_ctb.Size = new System.Drawing.Size(68, 20);
            this.cd_conta_ctb.ST_AutoInc = false;
            this.cd_conta_ctb.ST_DisableAuto = false;
            this.cd_conta_ctb.ST_Float = false;
            this.cd_conta_ctb.ST_Gravar = true;
            this.cd_conta_ctb.ST_Int = true;
            this.cd_conta_ctb.ST_LimpaCampo = true;
            this.cd_conta_ctb.ST_NotNull = true;
            this.cd_conta_ctb.ST_PrimaryKey = false;
            this.cd_conta_ctb.TabIndex = 2;
            this.cd_conta_ctb.TextOld = null;
            this.cd_conta_ctb.Leave += new System.EventHandler(this.cd_conta_ctb_Leave);
            // 
            // TFImplantarSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 211);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFImplantarSaldo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Implantar Saldo Contas";
            this.Load += new System.EventHandler(this.TFImplantarSaldo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFImplantarSaldo_KeyDown);
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
        private Componentes.EditDefault classificacao;
        private Componentes.EditDefault ds_conta_ctb;
        private System.Windows.Forms.Button bb_conta_ctb;
        private Componentes.EditDefault cd_conta_ctb;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditData dt_lancto;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditFloat vl_lancto;
        private Componentes.ComboBoxDefault deb_cred;
        private Componentes.EditDefault compHistorico;
    }
}