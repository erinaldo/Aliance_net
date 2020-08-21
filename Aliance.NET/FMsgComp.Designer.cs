namespace Aliance.NET
{
    partial class TFMsgComp
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
            this.tmpFechar = new System.Windows.Forms.Timer(this.components);
            this.lbl_DTComp = new System.Windows.Forms.Label();
            this.lblComp = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // tmpFechar
            // 
            this.tmpFechar.Interval = 10000;
            // 
            // lbl_DTComp
            // 
            this.lbl_DTComp.AutoSize = true;
            this.lbl_DTComp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DTComp.Location = new System.Drawing.Point(21, 58);
            this.lbl_DTComp.Name = "lbl_DTComp";
            this.lbl_DTComp.Size = new System.Drawing.Size(73, 14);
            this.lbl_DTComp.TabIndex = 8;
            this.lbl_DTComp.Text = "lbl_DTComp";
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblComp.LinkColor = System.Drawing.Color.DarkGreen;
            this.lblComp.Location = new System.Drawing.Point(14, 29);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(79, 16);
            this.lblComp.TabIndex = 9;
            this.lblComp.TabStop = true;
            this.lblComp.Text = "linkLabel1";
            this.lblComp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblComp_LinkClicked);
            // 
            // TFMsgComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(503, 150);
            this.Controls.Add(this.lblComp);
            this.Controls.Add(this.lbl_DTComp);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "TFMsgComp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AGENDA";
            this.Load += new System.EventHandler(this.TFMsgComp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmpFechar;
        private System.Windows.Forms.Label lbl_DTComp;
        private System.Windows.Forms.LinkLabel lblComp;
    }
}