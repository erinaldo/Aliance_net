namespace Contabil
{
    partial class TFAuditarContaProdutor
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
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tlpCentral.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(1043, 504);
            this.tlpCentral.TabIndex = 0;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1037, 45);
            this.panelDados1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produtor";
            // 
            // TFAuditarContaProdutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 504);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFAuditarContaProdutor";
            this.ShowInTaskbar = false;
            this.Text = "Auditar Conta Produtor - Contratos Fixar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tlpCentral.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
    }
}