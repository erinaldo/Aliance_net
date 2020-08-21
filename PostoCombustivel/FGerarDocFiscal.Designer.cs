namespace PostoCombustivel
{
    partial class TFGerarDocFiscal
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
            this.bb_cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.bbNFCeComNFe = new System.Windows.Forms.Button();
            this.bbNFCe = new System.Windows.Forms.Button();
            this.bbNFe = new System.Windows.Forms.Button();
            this.tlpCentral.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gerar Documento Fiscal?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bb_cancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Red;
            this.bb_cancelar.Location = new System.Drawing.Point(193, 94);
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(184, 85);
            this.bb_cancelar.TabIndex = 4;
            this.bb_cancelar.TabStop = false;
            this.bb_cancelar.Text = "CANCELAR\r\n[ESC]";
            this.bb_cancelar.UseVisualStyleBackColor = true;
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(34, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Venda Finalizada com Sucesso.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 2;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCentral.Controls.Add(this.bbNFCeComNFe, 1, 0);
            this.tlpCentral.Controls.Add(this.bbNFCe, 0, 0);
            this.tlpCentral.Controls.Add(this.bbNFe, 0, 1);
            this.tlpCentral.Controls.Add(this.bb_cancelar, 1, 1);
            this.tlpCentral.Location = new System.Drawing.Point(38, 65);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Size = new System.Drawing.Size(380, 182);
            this.tlpCentral.TabIndex = 7;
            // 
            // bbNFCeComNFe
            // 
            this.bbNFCeComNFe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bbNFCeComNFe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbNFCeComNFe.ForeColor = System.Drawing.Color.Green;
            this.bbNFCeComNFe.Location = new System.Drawing.Point(193, 3);
            this.bbNFCeComNFe.Name = "bbNFCeComNFe";
            this.bbNFCeComNFe.Size = new System.Drawing.Size(184, 85);
            this.bbNFCeComNFe.TabIndex = 2;
            this.bbNFCeComNFe.TabStop = false;
            this.bbNFCeComNFe.Text = "(F4)\r\nNFC-e com NF-e Vinculada";
            this.bbNFCeComNFe.UseVisualStyleBackColor = true;
            this.bbNFCeComNFe.Click += new System.EventHandler(this.bbNFCeComNFe_Click);
            // 
            // bbNFCe
            // 
            this.bbNFCe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bbNFCe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbNFCe.ForeColor = System.Drawing.Color.Green;
            this.bbNFCe.Location = new System.Drawing.Point(3, 3);
            this.bbNFCe.Name = "bbNFCe";
            this.bbNFCe.Size = new System.Drawing.Size(184, 85);
            this.bbNFCe.TabIndex = 1;
            this.bbNFCe.TabStop = false;
            this.bbNFCe.Text = "(F3)\r\nNFC-e";
            this.bbNFCe.UseVisualStyleBackColor = true;
            this.bbNFCe.Click += new System.EventHandler(this.bbNFCe_Click);
            // 
            // bbNFe
            // 
            this.bbNFe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bbNFe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbNFe.ForeColor = System.Drawing.Color.Green;
            this.bbNFe.Location = new System.Drawing.Point(3, 94);
            this.bbNFe.Name = "bbNFe";
            this.bbNFe.Size = new System.Drawing.Size(184, 85);
            this.bbNFe.TabIndex = 0;
            this.bbNFe.TabStop = false;
            this.bbNFe.Text = "(F5)\r\nNF-e";
            this.bbNFe.UseVisualStyleBackColor = true;
            this.bbNFe.Click += new System.EventHandler(this.bbNFe_Click);
            // 
            // TFGerarDocFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.bb_cancelar;
            this.ClientSize = new System.Drawing.Size(455, 278);
            this.ControlBox = false;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFGerarDocFiscal";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Documento Fiscal";
            this.Load += new System.EventHandler(this.TFGerarDocFiscal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFGerarDocFiscal_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private System.Windows.Forms.Button bbNFCeComNFe;
        private System.Windows.Forms.Button bbNFCe;
        private System.Windows.Forms.Button bbNFe;
    }
}