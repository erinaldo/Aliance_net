namespace Aliance.NET
{
    partial class FLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLogin));
            this.lblAcessoRemoto = new System.Windows.Forms.Label();
            this.lblSuporte = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_Sair = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pIcone = new System.Windows.Forms.PictureBox();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.bb_alterar = new System.Windows.Forms.Button();
            this.st_lembrarsenha = new Componentes.CheckBoxDefault(this.components);
            this.pTop = new Componentes.PanelDados(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.cbIdioma = new Componentes.ComboBoxDefault(this.components);
            this.Senha = new Componentes.EditDefault(this.components);
            this.Login = new Componentes.EditDefault(this.components);
            this.lblTicket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pIcone)).BeginInit();
            this.pTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAcessoRemoto
            // 
            this.lblAcessoRemoto.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblAcessoRemoto, "lblAcessoRemoto");
            this.lblAcessoRemoto.ForeColor = System.Drawing.Color.Green;
            this.lblAcessoRemoto.Name = "lblAcessoRemoto";
            this.lblAcessoRemoto.Click += new System.EventHandler(this.lblAcessoRemoto_Click);
            // 
            // lblSuporte
            // 
            this.lblSuporte.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblSuporte, "lblSuporte");
            this.lblSuporte.ForeColor = System.Drawing.Color.Green;
            this.lblSuporte.Name = "lblSuporte";
            this.lblSuporte.Click += new System.EventHandler(this.lblSuporte_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BTN_OK
            // 
            this.BTN_OK.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.BTN_OK, "BTN_OK");
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.UseVisualStyleBackColor = false;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // BTN_Sair
            // 
            this.BTN_Sair.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_Sair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.BTN_Sair, "BTN_Sair");
            this.BTN_Sair.Name = "BTN_Sair";
            this.BTN_Sair.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // pIcone
            // 
            resources.ApplyResources(this.pIcone, "pIcone");
            this.pIcone.Name = "pIcone";
            this.pIcone.TabStop = false;
            // 
            // bb_empresa
            // 
            resources.ApplyResources(this.bb_empresa, "bb_empresa");
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // bb_alterar
            // 
            resources.ApplyResources(this.bb_alterar, "bb_alterar");
            this.bb_alterar.Name = "bb_alterar";
            this.bb_alterar.UseVisualStyleBackColor = true;
            this.bb_alterar.Click += new System.EventHandler(this.bb_alterar_Click);
            // 
            // st_lembrarsenha
            // 
            resources.ApplyResources(this.st_lembrarsenha, "st_lembrarsenha");
            this.st_lembrarsenha.Name = "st_lembrarsenha";
            this.st_lembrarsenha.NM_Alias = "";
            this.st_lembrarsenha.NM_Campo = "";
            this.st_lembrarsenha.NM_Param = "";
            this.st_lembrarsenha.ST_Gravar = false;
            this.st_lembrarsenha.ST_LimparCampo = true;
            this.st_lembrarsenha.ST_NotNull = false;
            this.st_lembrarsenha.UseVisualStyleBackColor = true;
            this.st_lembrarsenha.Vl_False = "";
            this.st_lembrarsenha.Vl_True = "";
            // 
            // pTop
            // 
            this.pTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(88)))));
            this.pTop.Controls.Add(this.label3);
            this.pTop.Controls.Add(this.label7);
            resources.ApplyResources(this.pTop, "pTop");
            this.pTop.Name = "pTop";
            this.pTop.NM_ProcDeletar = "";
            this.pTop.NM_ProcGravar = "";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            resources.ApplyResources(this.cbEmpresa, "cbEmpresa");
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            // 
            // cbIdioma
            // 
            this.cbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdioma.FormattingEnabled = true;
            resources.ApplyResources(this.cbIdioma, "cbIdioma");
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.NM_Alias = "";
            this.cbIdioma.NM_Campo = "";
            this.cbIdioma.NM_Param = "";
            this.cbIdioma.ST_Gravar = false;
            this.cbIdioma.ST_LimparCampo = true;
            this.cbIdioma.ST_NotNull = false;
            this.cbIdioma.SelectionChangeCommitted += new System.EventHandler(this.cbIdioma_SelectionChangeCommitted);
            // 
            // Senha
            // 
            this.Senha.BackColor = System.Drawing.SystemColors.Window;
            this.Senha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Senha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.Senha, "Senha");
            this.Senha.Name = "Senha";
            this.Senha.NM_Alias = "";
            this.Senha.NM_Campo = "";
            this.Senha.NM_CampoBusca = "";
            this.Senha.NM_Param = "";
            this.Senha.QTD_Zero = 0;
            this.Senha.ST_AutoInc = false;
            this.Senha.ST_DisableAuto = false;
            this.Senha.ST_Float = false;
            this.Senha.ST_Gravar = true;
            this.Senha.ST_Int = false;
            this.Senha.ST_LimpaCampo = true;
            this.Senha.ST_NotNull = false;
            this.Senha.ST_PrimaryKey = false;
            this.Senha.TextOld = null;
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.Login, "Login");
            this.Login.Name = "Login";
            this.Login.NM_Alias = "";
            this.Login.NM_Campo = "";
            this.Login.NM_CampoBusca = "";
            this.Login.NM_Param = "";
            this.Login.QTD_Zero = 0;
            this.Login.ST_AutoInc = false;
            this.Login.ST_DisableAuto = false;
            this.Login.ST_Float = false;
            this.Login.ST_Gravar = true;
            this.Login.ST_Int = false;
            this.Login.ST_LimpaCampo = true;
            this.Login.ST_NotNull = false;
            this.Login.ST_PrimaryKey = false;
            this.Login.TextOld = null;
            this.Login.Leave += new System.EventHandler(this.Login_Leave);
            // 
            // lblTicket
            // 
            this.lblTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblTicket, "lblTicket");
            this.lblTicket.ForeColor = System.Drawing.Color.Green;
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Click += new System.EventHandler(this.lblTicket_Click);
            // 
            // FLogin
            // 
            this.AcceptButton = this.BTN_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_Sair;
            this.ControlBox = false;
            this.Controls.Add(this.lblTicket);
            this.Controls.Add(this.bb_alterar);
            this.Controls.Add(this.st_lembrarsenha);
            this.Controls.Add(this.bb_empresa);
            this.Controls.Add(this.pIcone);
            this.Controls.Add(this.pTop);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.BTN_Sair);
            this.Controls.Add(this.lblAcessoRemoto);
            this.Controls.Add(this.lblSuporte);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbIdioma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Senha);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FLogin";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FLogin_FormClosing);
            this.Load += new System.EventHandler(this.FLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pIcone)).EndInit();
            this.pTop.ResumeLayout(false);
            this.pTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_Sair;
        public System.Windows.Forms.Button BTN_OK;
        private Componentes.EditDefault Login;
        private Componentes.EditDefault Senha;
        private Componentes.ComboBoxDefault cbIdioma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSuporte;
        private System.Windows.Forms.Label lblAcessoRemoto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Componentes.ComboBoxDefault cbEmpresa;
        private Componentes.PanelDados pTop;
        private System.Windows.Forms.PictureBox pIcone;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.CheckBoxDefault st_lembrarsenha;
        private System.Windows.Forms.Button bb_alterar;
        private System.Windows.Forms.Label lblTicket;
    }
}