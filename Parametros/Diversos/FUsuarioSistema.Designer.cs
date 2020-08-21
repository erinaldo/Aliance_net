namespace Parametros.Diversos
{
    partial class TFUsuarioSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFUsuarioSistema));
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.lblMsg = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Senha = new Componentes.EditDefault(this.components);
            this.LoginUser = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_Sair = new System.Windows.Forms.Button();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(88)))));
            this.panelDados1.Controls.Add(this.lblMsg);
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // lblMsg
            // 
            resources.ApplyResources(this.lblMsg, "lblMsg");
            this.lblMsg.ForeColor = System.Drawing.Color.Gold;
            this.lblMsg.Name = "lblMsg";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // LoginUser
            // 
            this.LoginUser.BackColor = System.Drawing.Color.White;
            this.LoginUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.LoginUser, "LoginUser");
            this.LoginUser.Name = "LoginUser";
            this.LoginUser.NM_Alias = "";
            this.LoginUser.NM_Campo = "";
            this.LoginUser.NM_CampoBusca = "";
            this.LoginUser.NM_Param = "";
            this.LoginUser.QTD_Zero = 0;
            this.LoginUser.ST_AutoInc = false;
            this.LoginUser.ST_DisableAuto = false;
            this.LoginUser.ST_Float = false;
            this.LoginUser.ST_Gravar = true;
            this.LoginUser.ST_Int = false;
            this.LoginUser.ST_LimpaCampo = true;
            this.LoginUser.ST_NotNull = false;
            this.LoginUser.ST_PrimaryKey = false;
            this.LoginUser.TextOld = null;
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
            this.BTN_Sair.Click += new System.EventHandler(this.BTN_Sair_Click);
            // 
            // TFUsuarioSistema
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Senha);
            this.Controls.Add(this.LoginUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.BTN_Sair);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFUsuarioSistema";
            this.Load += new System.EventHandler(this.TFUsuarioSistema_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFUsuarioSistema_KeyDown);
            this.panelDados1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault Senha;
        private Componentes.EditDefault LoginUser;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_Sair;
    }
}