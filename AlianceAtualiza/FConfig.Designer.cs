namespace AlianceAtualiza
{
    partial class TFConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bbSalvar = new System.Windows.Forms.Button();
            this.versaoAliance = new System.Windows.Forms.NumericUpDown();
            this.senhaFTP = new System.Windows.Forms.TextBox();
            this.loginFTP = new System.Windows.Forms.TextBox();
            this.servidorFTP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.versaoAliance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor FTP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome de Usuário";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Senha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Versão Atual";
            // 
            // bbSalvar
            // 
            this.bbSalvar.Location = new System.Drawing.Point(127, 100);
            this.bbSalvar.Name = "bbSalvar";
            this.bbSalvar.Size = new System.Drawing.Size(98, 23);
            this.bbSalvar.TabIndex = 5;
            this.bbSalvar.Text = "Salvar Config.";
            this.bbSalvar.UseVisualStyleBackColor = true;
            this.bbSalvar.Click += new System.EventHandler(this.bbSalvar_Click);
            // 
            // versaoAliance
            // 
            this.versaoAliance.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::AlianceAtualiza.Properties.Settings.Default, "versaoAliance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.versaoAliance.Location = new System.Drawing.Point(15, 103);
            this.versaoAliance.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.versaoAliance.Name = "versaoAliance";
            this.versaoAliance.Size = new System.Drawing.Size(106, 20);
            this.versaoAliance.TabIndex = 3;
            this.versaoAliance.Value = global::AlianceAtualiza.Properties.Settings.Default.versaoAliance;
            // 
            // senhaFTP
            // 
            this.senhaFTP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AlianceAtualiza.Properties.Settings.Default, "senhaFTP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.senhaFTP.Location = new System.Drawing.Point(207, 64);
            this.senhaFTP.Name = "senhaFTP";
            this.senhaFTP.PasswordChar = '#';
            this.senhaFTP.Size = new System.Drawing.Size(186, 20);
            this.senhaFTP.TabIndex = 2;
            this.senhaFTP.Text = global::AlianceAtualiza.Properties.Settings.Default.senhaFTP;
            // 
            // loginFTP
            // 
            this.loginFTP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AlianceAtualiza.Properties.Settings.Default, "loginFTP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.loginFTP.Location = new System.Drawing.Point(15, 64);
            this.loginFTP.Name = "loginFTP";
            this.loginFTP.Size = new System.Drawing.Size(186, 20);
            this.loginFTP.TabIndex = 1;
            this.loginFTP.Text = global::AlianceAtualiza.Properties.Settings.Default.loginFTP;
            // 
            // servidorFTP
            // 
            this.servidorFTP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AlianceAtualiza.Properties.Settings.Default, "servidorFTP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.servidorFTP.Location = new System.Drawing.Point(15, 25);
            this.servidorFTP.Name = "servidorFTP";
            this.servidorFTP.Size = new System.Drawing.Size(378, 20);
            this.servidorFTP.TabIndex = 0;
            this.servidorFTP.Text = global::AlianceAtualiza.Properties.Settings.Default.servidorFTP;
            // 
            // TFConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 138);
            this.Controls.Add(this.bbSalvar);
            this.Controls.Add(this.versaoAliance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.senhaFTP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loginFTP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.servidorFTP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Servidor";
            ((System.ComponentModel.ISupportInitialize)(this.versaoAliance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox servidorFTP;
        private System.Windows.Forms.TextBox loginFTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox senhaFTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown versaoAliance;
        private System.Windows.Forms.Button bbSalvar;
    }
}