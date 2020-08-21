namespace Faturamento
{
    partial class TFWordPDF
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bb_pdf = new System.Windows.Forms.Button();
            this.bb_word = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.bb_pdf, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bb_word, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 178);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // bb_pdf
            // 
            this.bb_pdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bb_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_pdf.Location = new System.Drawing.Point(239, 4);
            this.bb_pdf.Name = "bb_pdf";
            this.bb_pdf.Size = new System.Drawing.Size(228, 170);
            this.bb_pdf.TabIndex = 0;
            this.bb_pdf.Text = "PDF\r\n(F3)";
            this.bb_pdf.UseVisualStyleBackColor = true;
            this.bb_pdf.Click += new System.EventHandler(this.bb_pdf_Click);
            // 
            // bb_word
            // 
            this.bb_word.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bb_word.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_word.Location = new System.Drawing.Point(4, 4);
            this.bb_word.Name = "bb_word";
            this.bb_word.Size = new System.Drawing.Size(228, 170);
            this.bb_word.TabIndex = 1;
            this.bb_word.Text = " WORD\r\n (F2)";
            this.bb_word.UseVisualStyleBackColor = true;
            this.bb_word.Click += new System.EventHandler(this.bb_word_Click);
            // 
            // TFWordPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 178);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFWordPDF";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FWordPDF";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFWordPDF_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bb_pdf;
        private System.Windows.Forms.Button bb_word;
    }
}