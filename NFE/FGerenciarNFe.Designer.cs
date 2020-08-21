namespace srvNFE
{
    partial class TFGerenciarNFe
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
            this.pStatus = new Componentes.PanelDados(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.tempo = new System.Windows.Forms.Timer(this.components);
            this.pStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pStatus
            // 
            this.pStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pStatus.Controls.Add(this.lblStatus);
            this.pStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pStatus.Location = new System.Drawing.Point(0, 0);
            this.pStatus.Name = "pStatus";
            this.pStatus.NM_ProcDeletar = "";
            this.pStatus.NM_ProcGravar = "";
            this.pStatus.Size = new System.Drawing.Size(299, 105);
            this.pStatus.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(297, 103);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Enviando Lote NFe...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tempo
            // 
            this.tempo.Enabled = true;
            this.tempo.Interval = 500;
            this.tempo.Tick += new System.EventHandler(this.tempo_Tick);
            // 
            // TFGerenciarNFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 105);
            this.Controls.Add(this.pStatus);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFGerenciarNFe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar NFe";
            this.Load += new System.EventHandler(this.TFGerenciarNFe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFGerenciarNFe_KeyDown);
            this.pStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tempo;
    }
}