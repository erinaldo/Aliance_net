namespace PDV
{
    partial class TFLoginDesconto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLoginDesconto));
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Senha = new Componentes.EditDefault(this.components);
            this.Login = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pc_desconto = new Componentes.EditFloat(this.components);
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_Sair = new System.Windows.Forms.Button();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desconto)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(88)))));
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Location = new System.Drawing.Point(2, 2);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(346, 67);
            this.panelDados1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(10, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Liberação % de Desconto";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(347, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(30, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Usuário";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Senha
            // 
            this.Senha.BackColor = System.Drawing.SystemColors.Window;
            this.Senha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Senha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Senha.Location = new System.Drawing.Point(229, 150);
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
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(33, 150);
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
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(225, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "Senha";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(98, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "% Desconto:";
            // 
            // pc_desconto
            // 
            this.pc_desconto.DecimalPlaces = 2;
            this.pc_desconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pc_desconto.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pc_desconto.Location = new System.Drawing.Point(230, 83);
            this.pc_desconto.Name = "pc_desconto";
            this.pc_desconto.NM_Alias = "";
            this.pc_desconto.NM_Campo = "";
            this.pc_desconto.NM_Param = "";
            this.pc_desconto.Operador = "";
            this.pc_desconto.ReadOnly = true;
            this.pc_desconto.Size = new System.Drawing.Size(120, 29);
            this.pc_desconto.ST_AutoInc = false;
            this.pc_desconto.ST_DisableAuto = false;
            this.pc_desconto.ST_Gravar = false;
            this.pc_desconto.ST_LimparCampo = true;
            this.pc_desconto.ST_NotNull = false;
            this.pc_desconto.ST_PrimaryKey = false;
            this.pc_desconto.TabIndex = 24;
            this.pc_desconto.TabStop = false;
            this.pc_desconto.ThousandsSeparator = true;
            // 
            // BTN_OK
            // 
            this.BTN_OK.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BTN_OK.Location = new System.Drawing.Point(122, 185);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(99, 32);
            this.BTN_OK.TabIndex = 2;
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
            this.BTN_Sair.Location = new System.Drawing.Point(228, 185);
            this.BTN_Sair.Name = "BTN_Sair";
            this.BTN_Sair.Size = new System.Drawing.Size(99, 32);
            this.BTN_Sair.TabIndex = 3;
            this.BTN_Sair.Text = "Sair";
            this.BTN_Sair.UseVisualStyleBackColor = false;
            this.BTN_Sair.Click += new System.EventHandler(this.BTN_Sair_Click);
            // 
            // TFLoginDesconto
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.BTN_Sair;
            this.ClientSize = new System.Drawing.Size(448, 224);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.BTN_Sair);
            this.Controls.Add(this.pc_desconto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Senha);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelDados1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFLoginDesconto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FLoginDesconto";
            this.Load += new System.EventHandler(this.FLoginDesconto_Load);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desconto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault Senha;
        private Componentes.EditDefault Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat pc_desconto;
        public System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_Sair;
        private System.Windows.Forms.Label label4;
    }
}