namespace Proc_Commoditties
{
    partial class TFLanSessaoPDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanSessaoPDV));
            this.label3 = new System.Windows.Forms.Label();
            this.lblPdv = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.lblMsg = new System.Windows.Forms.Label();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_Sair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Senha = new Componentes.EditDefault(this.components);
            this.Login = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblLoginCorrente = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 26);
            this.label3.TabIndex = 12;
            // 
            // lblPdv
            // 
            this.lblPdv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPdv.ForeColor = System.Drawing.Color.White;
            this.lblPdv.Location = new System.Drawing.Point(106, 7);
            this.lblPdv.Name = "lblPdv";
            this.lblPdv.Size = new System.Drawing.Size(240, 23);
            this.lblPdv.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(347, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(88)))));
            this.panelDados1.Controls.Add(this.lblMsg);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.lblPdv);
            this.panelDados1.Location = new System.Drawing.Point(2, 2);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(346, 67);
            this.panelDados1.TabIndex = 19;
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Gold;
            this.lblMsg.Location = new System.Drawing.Point(10, 36);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(329, 23);
            this.lblMsg.TabIndex = 14;
            // 
            // BTN_OK
            // 
            this.BTN_OK.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BTN_OK.Location = new System.Drawing.Point(122, 138);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(99, 32);
            this.BTN_OK.TabIndex = 25;
            this.BTN_OK.Text = "Entrar";
            this.BTN_OK.UseVisualStyleBackColor = false;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // BTN_Sair
            // 
            this.BTN_Sair.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_Sair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_Sair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BTN_Sair.Location = new System.Drawing.Point(228, 138);
            this.BTN_Sair.Name = "BTN_Sair";
            this.BTN_Sair.Size = new System.Drawing.Size(99, 32);
            this.BTN_Sair.TabIndex = 26;
            this.BTN_Sair.Text = "Sair";
            this.BTN_Sair.UseVisualStyleBackColor = false;
            this.BTN_Sair.Click += new System.EventHandler(this.BTN_Sair_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(30, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Usuário";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Senha
            // 
            this.Senha.BackColor = System.Drawing.SystemColors.Window;
            this.Senha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Senha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Senha.Location = new System.Drawing.Point(229, 103);
            this.Senha.MaxLength = 20;
            this.Senha.Name = "Senha";
            this.Senha.NM_Alias = "";
            this.Senha.NM_Campo = "";
            this.Senha.NM_CampoBusca = "";
            this.Senha.NM_Param = "";
            this.Senha.PasswordChar = '#';
            this.Senha.QTD_Zero = 0;
            this.Senha.Size = new System.Drawing.Size(189, 29);
            this.Senha.ST_AutoInc = false;
            this.Senha.ST_DisableAuto = false;
            this.Senha.ST_Float = false;
            this.Senha.ST_Gravar = true;
            this.Senha.ST_Int = false;
            this.Senha.ST_LimpaCampo = true;
            this.Senha.ST_NotNull = false;
            this.Senha.ST_PrimaryKey = false;
            this.Senha.TabIndex = 1;
            this.Senha.TextOld = null;
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(33, 103);
            this.Login.MaxLength = 20;
            this.Login.Name = "Login";
            this.Login.NM_Alias = "";
            this.Login.NM_Campo = "";
            this.Login.NM_CampoBusca = "";
            this.Login.NM_Param = "";
            this.Login.QTD_Zero = 0;
            this.Login.Size = new System.Drawing.Size(189, 29);
            this.Login.ST_AutoInc = false;
            this.Login.ST_DisableAuto = false;
            this.Login.ST_Float = false;
            this.Login.ST_Gravar = true;
            this.Login.ST_Int = false;
            this.Login.ST_LimpaCampo = true;
            this.Login.ST_NotNull = false;
            this.Login.ST_PrimaryKey = false;
            this.Login.TabIndex = 0;
            this.Login.TextOld = null;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(225, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 28;
            this.label2.Text = "Senha";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLoginCorrente
            // 
            this.lblLoginCorrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginCorrente.Location = new System.Drawing.Point(337, 138);
            this.lblLoginCorrente.Name = "lblLoginCorrente";
            this.lblLoginCorrente.Size = new System.Drawing.Size(100, 50);
            this.lblLoginCorrente.TabIndex = 29;
            this.lblLoginCorrente.TabStop = true;
            this.lblLoginCorrente.Text = "Utilizar Login Corrente";
            this.lblLoginCorrente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLoginCorrente.Click += new System.EventHandler(this.lblLoginCorrente_Click);
            // 
            // TFLanSessaoPDV
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.BTN_Sair;
            this.ClientSize = new System.Drawing.Size(449, 197);
            this.Controls.Add(this.lblLoginCorrente);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.BTN_Sair);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Senha);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelDados1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanSessaoPDV";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Frente Caixa";
            this.Load += new System.EventHandler(this.TFLanSessaoPDV_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanSessaoPDV_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPdv;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Componentes.PanelDados panelDados1;
        public System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_Sair;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault Senha;
        private Componentes.EditDefault Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.LinkLabel lblLoginCorrente;
    }
}