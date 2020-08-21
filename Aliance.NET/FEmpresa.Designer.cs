namespace Aliance.NET
{
    partial class TFEmpresa
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
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.txtBancoDados = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bb_gravar = new System.Windows.Forms.Button();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bb_conexao = new System.Windows.Forms.Button();
            this.bb_deletar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor (Nome ou IP)";
            // 
            // txtServidor
            // 
            this.txtServidor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtServidor.Location = new System.Drawing.Point(15, 64);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(388, 20);
            this.txtServidor.TabIndex = 1;
            // 
            // txtBancoDados
            // 
            this.txtBancoDados.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBancoDados.Location = new System.Drawing.Point(12, 103);
            this.txtBancoDados.Name = "txtBancoDados";
            this.txtBancoDados.Size = new System.Drawing.Size(256, 20);
            this.txtBancoDados.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Banco de Dados";
            // 
            // bb_gravar
            // 
            this.bb_gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_gravar.Location = new System.Drawing.Point(146, 129);
            this.bb_gravar.Name = "bb_gravar";
            this.bb_gravar.Size = new System.Drawing.Size(122, 23);
            this.bb_gravar.TabIndex = 3;
            this.bb_gravar.Text = "Gravar";
            this.bb_gravar.UseVisualStyleBackColor = true;
            this.bb_gravar.Click += new System.EventHandler(this.bb_gravar_Click);
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmpresa.Enabled = false;
            this.txtEmpresa.Location = new System.Drawing.Point(15, 25);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(388, 20);
            this.txtEmpresa.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Empresa";
            // 
            // bb_conexao
            // 
            this.bb_conexao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_conexao.Location = new System.Drawing.Point(274, 103);
            this.bb_conexao.Name = "bb_conexao";
            this.bb_conexao.Size = new System.Drawing.Size(129, 20);
            this.bb_conexao.TabIndex = 6;
            this.bb_conexao.Text = "Testar Conexão";
            this.bb_conexao.UseVisualStyleBackColor = true;
            this.bb_conexao.Click += new System.EventHandler(this.bb_conexao_Click);
            // 
            // bb_deletar
            // 
            this.bb_deletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_deletar.Location = new System.Drawing.Point(274, 129);
            this.bb_deletar.Name = "bb_deletar";
            this.bb_deletar.Size = new System.Drawing.Size(122, 23);
            this.bb_deletar.TabIndex = 7;
            this.bb_deletar.Text = "Deletar";
            this.bb_deletar.UseVisualStyleBackColor = true;
            this.bb_deletar.Visible = false;
            this.bb_deletar.Click += new System.EventHandler(this.bb_deletar_Click);
            // 
            // TFEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 157);
            this.Controls.Add(this.bb_deletar);
            this.Controls.Add(this.bb_conexao);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bb_gravar);
            this.Controls.Add(this.txtBancoDados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFEmpresa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Empresas";
            this.Load += new System.EventHandler(this.TFEmpresa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.TextBox txtBancoDados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_gravar;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_conexao;
        private System.Windows.Forms.Button bb_deletar;

    }
}