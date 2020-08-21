namespace Proc_Commoditties
{
    partial class TFLeitorCodBarras
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.BB_Cancelar = new System.Windows.Forms.Button();
            this.TxtLeitura = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(332, 40);
            this.lblTitulo.TabIndex = 15;
            this.lblTitulo.Text = "Aguardando o Código de Barras";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Red;
            this.BB_Cancelar.Location = new System.Drawing.Point(52, 89);
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(228, 33);
            this.BB_Cancelar.TabIndex = 18;
            this.BB_Cancelar.TabStop = false;
            this.BB_Cancelar.Text = "Cancelar";
            this.BB_Cancelar.UseVisualStyleBackColor = true;
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // TxtLeitura
            // 
            this.TxtLeitura.BackColor = System.Drawing.SystemColors.Control;
            this.TxtLeitura.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLeitura.ForeColor = System.Drawing.Color.Red;
            this.TxtLeitura.Location = new System.Drawing.Point(11, 45);
            this.TxtLeitura.Name = "TxtLeitura";
            this.TxtLeitura.PasswordChar = '*';
            this.TxtLeitura.Size = new System.Drawing.Size(310, 32);
            this.TxtLeitura.TabIndex = 19;
            this.TxtLeitura.TabStop = false;
            this.TxtLeitura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtLeitura.TextChanged += new System.EventHandler(this.TxtLeitura_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BB_Cancelar);
            this.panel1.Controls.Add(this.TxtLeitura);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 136);
            this.panel1.TabIndex = 20;
            // 
            // TFLeitorCodBarras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 136);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TFLeitorCodBarras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LeitorCodBarras";
            this.Load += new System.EventHandler(this.LeitorCodBarras_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button BB_Cancelar;
        private System.Windows.Forms.TextBox TxtLeitura;
        private System.Windows.Forms.Panel panel1;
    }
}