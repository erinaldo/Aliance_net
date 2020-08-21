namespace Utils
{
    partial class FTelaEspera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTelaEspera));
            this.labelMSG = new System.Windows.Forms.Label();
            this.panelComp = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxTarefa = new System.Windows.Forms.TextBox();
            this.panelComp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMSG
            // 
            this.labelMSG.BackColor = System.Drawing.SystemColors.Control;
            this.labelMSG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMSG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMSG.ForeColor = System.Drawing.Color.Green;
            this.labelMSG.Location = new System.Drawing.Point(50, 0);
            this.labelMSG.Name = "labelMSG";
            this.labelMSG.Size = new System.Drawing.Size(730, 51);
            this.labelMSG.TabIndex = 0;
            this.labelMSG.Text = "Mensagem";
            this.labelMSG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelComp
            // 
            this.panelComp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelComp.Controls.Add(this.labelMSG);
            this.panelComp.Controls.Add(this.pictureBox1);
            this.panelComp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelComp.Location = new System.Drawing.Point(0, 0);
            this.panelComp.Name = "panelComp";
            this.panelComp.Size = new System.Drawing.Size(784, 55);
            this.panelComp.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxTarefa
            // 
            this.textBoxTarefa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTarefa.Location = new System.Drawing.Point(0, 55);
            this.textBoxTarefa.Multiline = true;
            this.textBoxTarefa.Name = "textBoxTarefa";
            this.textBoxTarefa.ReadOnly = true;
            this.textBoxTarefa.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTarefa.Size = new System.Drawing.Size(784, 506);
            this.textBoxTarefa.TabIndex = 6;
            // 
            // FTelaEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.textBoxTarefa);
            this.Controls.Add(this.panelComp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FTelaEspera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Por favor aguarde...";
            this.Load += new System.EventHandler(this.TelaEspera_Load);
            this.panelComp.ResumeLayout(false);
            this.panelComp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelMSG;
        private System.Windows.Forms.Panel panelComp;
        public System.Windows.Forms.TextBox textBoxTarefa;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}