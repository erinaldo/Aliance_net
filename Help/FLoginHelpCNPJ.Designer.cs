namespace Help
{
    partial class TFLoginHelpCNPJ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLoginHelpCNPJ));
            this.pTop = new Componentes.PanelDados(this.components);
            this.pFechar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.edtSenha = new Componentes.EditDefault(this.components);
            this.edtLogin = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.BTN_OK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cnpj = new Componentes.EditMask(this.components);
            this.pTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pTop.Controls.Add(this.pFechar);
            this.pTop.Controls.Add(this.label1);
            this.pTop.ForeColor = System.Drawing.SystemColors.Control;
            this.pTop.Location = new System.Drawing.Point(-8, 2);
            this.pTop.Name = "pTop";
            this.pTop.NM_ProcDeletar = "";
            this.pTop.NM_ProcGravar = "";
            this.pTop.Size = new System.Drawing.Size(301, 34);
            this.pTop.TabIndex = 3;
            // 
            // pFechar
            // 
            this.pFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pFechar.Image = ((System.Drawing.Image)(resources.GetObject("pFechar.Image")));
            this.pFechar.Location = new System.Drawing.Point(265, 3);
            this.pFechar.Name = "pFechar";
            this.pFechar.Size = new System.Drawing.Size(33, 29);
            this.pFechar.TabIndex = 1;
            this.pFechar.TabStop = false;
            this.pFechar.Click += new System.EventHandler(this.pFechar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGIN HELP DESK";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.Transparent;
            this.panelDados1.Controls.Add(this.cnpj);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.edtSenha);
            this.panelDados1.Controls.Add(this.edtLogin);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Location = new System.Drawing.Point(-4, 42);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(301, 178);
            this.panelDados1.TabIndex = 0;
            // 
            // edtSenha
            // 
            this.edtSenha.BackColor = System.Drawing.SystemColors.Window;
            this.edtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtSenha.Location = new System.Drawing.Point(29, 85);
            this.edtSenha.Name = "edtSenha";
            this.edtSenha.NM_Alias = "";
            this.edtSenha.NM_Campo = "";
            this.edtSenha.NM_CampoBusca = "";
            this.edtSenha.NM_Param = "";
            this.edtSenha.PasswordChar = '*';
            this.edtSenha.QTD_Zero = 0;
            this.edtSenha.Size = new System.Drawing.Size(246, 26);
            this.edtSenha.ST_AutoInc = false;
            this.edtSenha.ST_DisableAuto = false;
            this.edtSenha.ST_Float = false;
            this.edtSenha.ST_Gravar = false;
            this.edtSenha.ST_Int = false;
            this.edtSenha.ST_LimpaCampo = true;
            this.edtSenha.ST_NotNull = false;
            this.edtSenha.ST_PrimaryKey = false;
            this.edtSenha.TabIndex = 1;
            this.edtSenha.TextOld = null;
            // 
            // edtLogin
            // 
            this.edtLogin.BackColor = System.Drawing.SystemColors.Window;
            this.edtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtLogin.Location = new System.Drawing.Point(29, 30);
            this.edtLogin.Name = "edtLogin";
            this.edtLogin.NM_Alias = "";
            this.edtLogin.NM_Campo = "";
            this.edtLogin.NM_CampoBusca = "";
            this.edtLogin.NM_Param = "";
            this.edtLogin.QTD_Zero = 0;
            this.edtLogin.Size = new System.Drawing.Size(246, 26);
            this.edtLogin.ST_AutoInc = false;
            this.edtLogin.ST_DisableAuto = false;
            this.edtLogin.ST_Float = false;
            this.edtLogin.ST_Gravar = false;
            this.edtLogin.ST_Int = false;
            this.edtLogin.ST_LimpaCampo = true;
            this.edtLogin.ST_NotNull = false;
            this.edtLogin.ST_PrimaryKey = false;
            this.edtLogin.TabIndex = 0;
            this.edtLogin.TextOld = null;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(26, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Usuário";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(26, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Senha";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelDados2
            // 
            this.panelDados2.BackColor = System.Drawing.Color.Transparent;
            this.panelDados2.Controls.Add(this.BTN_OK);
            this.panelDados2.Location = new System.Drawing.Point(-4, 226);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(301, 54);
            this.panelDados2.TabIndex = 1;
            // 
            // BTN_OK
            // 
            this.BTN_OK.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BTN_OK.Location = new System.Drawing.Point(93, 3);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(115, 48);
            this.BTN_OK.TabIndex = 0;
            this.BTN_OK.Text = "Entrar";
            this.BTN_OK.UseVisualStyleBackColor = false;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(26, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "CNPJ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cnpj
            // 
            this.cnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnpj.Location = new System.Drawing.Point(29, 140);
            this.cnpj.Mask = "00.000.000/0000-00";
            this.cnpj.Name = "cnpj";
            this.cnpj.NM_Alias = "";
            this.cnpj.NM_Campo = "";
            this.cnpj.NM_CampoBusca = "";
            this.cnpj.NM_Param = "";
            this.cnpj.Size = new System.Drawing.Size(246, 26);
            this.cnpj.ST_Gravar = false;
            this.cnpj.ST_LimpaCampo = true;
            this.cnpj.ST_NotNull = false;
            this.cnpj.ST_PrimaryKey = false;
            this.cnpj.TabIndex = 2;
            // 
            // TFLoginHelpCNPJ
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 284);
            this.Controls.Add(this.panelDados2);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.pTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TFLoginHelpCNPJ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FLoginHelpCNPJ";
            this.pTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pTop;
        private System.Windows.Forms.PictureBox pFechar;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault edtSenha;
        private Componentes.EditDefault edtLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Componentes.EditMask cnpj;
        private System.Windows.Forms.Label label4;
        private Componentes.PanelDados panelDados2;
        public System.Windows.Forms.Button BTN_OK;
    }
}