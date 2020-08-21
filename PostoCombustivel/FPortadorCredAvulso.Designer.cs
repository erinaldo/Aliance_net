namespace PostoCombustivel
{
    partial class TFPortadorCredAvulso
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
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_cartaoCred = new System.Windows.Forms.Button();
            this.bb_cheque = new System.Windows.Forms.Button();
            this.bb_dinheiro = new System.Windows.Forms.Button();
            this.bb_cartaoDeb = new System.Windows.Forms.Button();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.bb_cartaoDeb);
            this.panelDados1.Controls.Add(this.bb_cartaoCred);
            this.panelDados1.Controls.Add(this.bb_cheque);
            this.panelDados1.Controls.Add(this.bb_dinheiro);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 0);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(403, 236);
            this.panelDados1.TabIndex = 0;
            // 
            // bb_cartaoCred
            // 
            this.bb_cartaoCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cartaoCred.ForeColor = System.Drawing.Color.Green;
            this.bb_cartaoCred.Location = new System.Drawing.Point(12, 121);
            this.bb_cartaoCred.Name = "bb_cartaoCred";
            this.bb_cartaoCred.Size = new System.Drawing.Size(189, 109);
            this.bb_cartaoCred.TabIndex = 2;
            this.bb_cartaoCred.Text = "(F3)\r\nCARTÃO CREDITO";
            this.bb_cartaoCred.UseVisualStyleBackColor = true;
            this.bb_cartaoCred.Click += new System.EventHandler(this.bb_cartao_Click);
            // 
            // bb_cheque
            // 
            this.bb_cheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cheque.ForeColor = System.Drawing.Color.Green;
            this.bb_cheque.Location = new System.Drawing.Point(206, 6);
            this.bb_cheque.Name = "bb_cheque";
            this.bb_cheque.Size = new System.Drawing.Size(189, 109);
            this.bb_cheque.TabIndex = 1;
            this.bb_cheque.Text = "(F2)\r\nCHEQUE";
            this.bb_cheque.UseVisualStyleBackColor = true;
            this.bb_cheque.Click += new System.EventHandler(this.bb_cheque_Click);
            // 
            // bb_dinheiro
            // 
            this.bb_dinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_dinheiro.ForeColor = System.Drawing.Color.Green;
            this.bb_dinheiro.Location = new System.Drawing.Point(10, 6);
            this.bb_dinheiro.Name = "bb_dinheiro";
            this.bb_dinheiro.Size = new System.Drawing.Size(189, 109);
            this.bb_dinheiro.TabIndex = 0;
            this.bb_dinheiro.Text = "(F1)\r\nDINHEIRO";
            this.bb_dinheiro.UseVisualStyleBackColor = true;
            this.bb_dinheiro.Click += new System.EventHandler(this.bb_dinheiro_Click);
            // 
            // bb_cartaoDeb
            // 
            this.bb_cartaoDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cartaoDeb.ForeColor = System.Drawing.Color.Green;
            this.bb_cartaoDeb.Location = new System.Drawing.Point(207, 121);
            this.bb_cartaoDeb.Name = "bb_cartaoDeb";
            this.bb_cartaoDeb.Size = new System.Drawing.Size(189, 109);
            this.bb_cartaoDeb.TabIndex = 3;
            this.bb_cartaoDeb.Text = "(F4)\r\nCARTÃO DEBITO";
            this.bb_cartaoDeb.UseVisualStyleBackColor = true;
            this.bb_cartaoDeb.Click += new System.EventHandler(this.bb_cartaoDeb_Click);
            // 
            // TFPortadorCredAvulso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 236);
            this.Controls.Add(this.panelDados1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFPortadorCredAvulso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFPortadorCredAvulso_KeyDown);
            this.panelDados1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Button bb_cartaoCred;
        private System.Windows.Forms.Button bb_cheque;
        private System.Windows.Forms.Button bb_dinheiro;
        private System.Windows.Forms.Button bb_cartaoDeb;
    }
}