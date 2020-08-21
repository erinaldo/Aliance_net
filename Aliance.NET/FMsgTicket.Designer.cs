namespace Aliance.NET
{
    partial class TFMsgTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFMsgTicket));
            this.label1 = new System.Windows.Forms.Label();
            this.lblTicket = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEvolucao = new System.Windows.Forms.Label();
            this.pFechar = new System.Windows.Forms.PictureBox();
            this.tmpFechar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº Ticket:";
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicket.Location = new System.Drawing.Point(118, 9);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(0, 22);
            this.lblTicket.TabIndex = 1;
            this.lblTicket.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTicket_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Operador/Evolução";
            // 
            // lblEvolucao
            // 
            this.lblEvolucao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvolucao.Location = new System.Drawing.Point(12, 51);
            this.lblEvolucao.Name = "lblEvolucao";
            this.lblEvolucao.Size = new System.Drawing.Size(423, 263);
            this.lblEvolucao.TabIndex = 3;
            // 
            // pFechar
            // 
            this.pFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pFechar.Image = ((System.Drawing.Image)(resources.GetObject("pFechar.Image")));
            this.pFechar.Location = new System.Drawing.Point(402, 9);
            this.pFechar.Name = "pFechar";
            this.pFechar.Size = new System.Drawing.Size(33, 29);
            this.pFechar.TabIndex = 4;
            this.pFechar.TabStop = false;
            this.pFechar.Click += new System.EventHandler(this.pFechar_Click);
            // 
            // tmpFechar
            // 
            this.tmpFechar.Interval = 10000;
            this.tmpFechar.Tick += new System.EventHandler(this.tmpFechar_Tick);
            // 
            // TFMsgTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(447, 323);
            this.Controls.Add(this.pFechar);
            this.Controls.Add(this.lblEvolucao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTicket);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "TFMsgTicket";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Aliance - Help Desk";
            this.Load += new System.EventHandler(this.TFMsgTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblTicket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEvolucao;
        private System.Windows.Forms.PictureBox pFechar;
        private System.Windows.Forms.Timer tmpFechar;
    }
}