namespace FormRelPadrao
{
    partial class TFPreviewChart
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
            this.chartViewer = new PerpetuumSoft.Charts.Windows.Forms.ChartViewer();
            this.SuspendLayout();
            // 
            // chartViewer
            // 
            this.chartViewer.ChartStream = global::FormRelPadrao.Resources.RDCPadrao.Code_DataCube;
            this.chartViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartViewer.Location = new System.Drawing.Point(0, 0);
            this.chartViewer.Name = "chartViewer";
            this.chartViewer.Size = new System.Drawing.Size(772, 523);
            this.chartViewer.TabIndex = 1;
            // 
            // TFPreviewChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 523);
            this.Controls.Add(this.chartViewer);
            this.Name = "TFPreviewChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview Gráfico";
            this.Load += new System.EventHandler(this.FPreviewChart_Load);
            this.ResumeLayout(false);

        }

        #endregion        

        public PerpetuumSoft.Charts.Windows.Forms.ChartViewer chartViewer;

    }
}