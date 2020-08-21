namespace Financeiro
{
    partial class TFValidaLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFValidaLogin));
            this.label3 = new System.Windows.Forms.Label();
            this.Senha = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.Login = new Componentes.EditDefault(this.components);
            this.bb_confirma = new System.Windows.Forms.Button();
            this.bb_cancela = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Usuário:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Senha
            // 
            this.Senha.BackColor = System.Drawing.SystemColors.Window;
            this.Senha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Senha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Senha.Location = new System.Drawing.Point(118, 45);
            this.Senha.MaxLength = 20;
            this.Senha.Name = "Senha";
            this.Senha.NM_Alias = "";
            this.Senha.NM_Campo = "";
            this.Senha.NM_CampoBusca = "";
            this.Senha.NM_Param = "";
            this.Senha.PasswordChar = '#';
            this.Senha.QTD_Zero = 0;
            this.Senha.Size = new System.Drawing.Size(132, 20);
            this.Senha.ST_AutoInc = false;
            this.Senha.ST_DisableAuto = false;
            this.Senha.ST_Float = false;
            this.Senha.ST_Gravar = true;
            this.Senha.ST_Int = false;
            this.Senha.ST_LimpaCampo = true;
            this.Senha.ST_NotNull = false;
            this.Senha.ST_PrimaryKey = false;
            this.Senha.TabIndex = 17;
            this.Senha.TextOld = null;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(23, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Senha:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Login.Location = new System.Drawing.Point(118, 10);
            this.Login.MaxLength = 20;
            this.Login.Name = "Login";
            this.Login.NM_Alias = "";
            this.Login.NM_Campo = "";
            this.Login.NM_CampoBusca = "";
            this.Login.NM_Param = "";
            this.Login.QTD_Zero = 0;
            this.Login.Size = new System.Drawing.Size(132, 20);
            this.Login.ST_AutoInc = false;
            this.Login.ST_DisableAuto = false;
            this.Login.ST_Float = false;
            this.Login.ST_Gravar = true;
            this.Login.ST_Int = false;
            this.Login.ST_LimpaCampo = true;
            this.Login.ST_NotNull = false;
            this.Login.ST_PrimaryKey = false;
            this.Login.TabIndex = 16;
            this.Login.TextOld = null;
            // 
            // bb_confirma
            // 
            this.bb_confirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_confirma.Image = ((System.Drawing.Image)(resources.GetObject("bb_confirma.Image")));
            this.bb_confirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_confirma.Location = new System.Drawing.Point(32, 81);
            this.bb_confirma.Name = "bb_confirma";
            this.bb_confirma.Size = new System.Drawing.Size(95, 36);
            this.bb_confirma.TabIndex = 20;
            this.bb_confirma.Text = "Confirma";
            this.bb_confirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_confirma.UseVisualStyleBackColor = true;
            this.bb_confirma.Click += new System.EventHandler(this.bb_confirma_Click);
            // 
            // bb_cancela
            // 
            this.bb_cancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancela.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancela.Image")));
            this.bb_cancela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_cancela.Location = new System.Drawing.Point(134, 80);
            this.bb_cancela.Name = "bb_cancela";
            this.bb_cancela.Size = new System.Drawing.Size(95, 36);
            this.bb_cancela.TabIndex = 21;
            this.bb_cancela.Text = "Cancela";
            this.bb_cancela.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_cancela.UseVisualStyleBackColor = true;
            this.bb_cancela.Click += new System.EventHandler(this.bb_cancela_Click);
            // 
            // TFValidaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 126);
            this.Controls.Add(this.bb_cancela);
            this.Controls.Add(this.bb_confirma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Senha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFValidaLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FValidaLogin";
            this.Load += new System.EventHandler(this.TFValidaLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault Senha;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault Login;
        private System.Windows.Forms.Button bb_confirma;
        private System.Windows.Forms.Button bb_cancela;
    }
}