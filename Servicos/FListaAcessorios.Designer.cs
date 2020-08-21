namespace Servicos
{
    partial class TFListaAcessorios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gAcessorios = new Componentes.DataGridDefault(this.components);
            this.bsAcessorios = new System.Windows.Forms.BindingSource(this.components);
            this.stdevolvidoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dsacessorioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gAcessorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcessorios)).BeginInit();
            this.SuspendLayout();
            // 
            // gAcessorios
            // 
            this.gAcessorios.AllowUserToAddRows = false;
            this.gAcessorios.AllowUserToDeleteRows = false;
            this.gAcessorios.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gAcessorios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gAcessorios.AutoGenerateColumns = false;
            this.gAcessorios.BackgroundColor = System.Drawing.Color.LightGray;
            this.gAcessorios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gAcessorios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAcessorios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gAcessorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gAcessorios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stdevolvidoboolDataGridViewCheckBoxColumn,
            this.dsacessorioDataGridViewTextBoxColumn});
            this.gAcessorios.DataSource = this.bsAcessorios;
            this.gAcessorios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gAcessorios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gAcessorios.Location = new System.Drawing.Point(0, 0);
            this.gAcessorios.Name = "gAcessorios";
            this.gAcessorios.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAcessorios.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gAcessorios.RowHeadersWidth = 23;
            this.gAcessorios.Size = new System.Drawing.Size(383, 322);
            this.gAcessorios.TabIndex = 0;
            this.gAcessorios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gAcessorios_CellClick);
            // 
            // bsAcessorios
            // 
            this.bsAcessorios.DataSource = typeof(CamadaDados.Servicos.TList_Acessorios);
            // 
            // stdevolvidoboolDataGridViewCheckBoxColumn
            // 
            this.stdevolvidoboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stdevolvidoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_devolvidobool";
            this.stdevolvidoboolDataGridViewCheckBoxColumn.HeaderText = "Devolver";
            this.stdevolvidoboolDataGridViewCheckBoxColumn.Name = "stdevolvidoboolDataGridViewCheckBoxColumn";
            this.stdevolvidoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stdevolvidoboolDataGridViewCheckBoxColumn.Width = 56;
            // 
            // dsacessorioDataGridViewTextBoxColumn
            // 
            this.dsacessorioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsacessorioDataGridViewTextBoxColumn.DataPropertyName = "Ds_acessorio";
            this.dsacessorioDataGridViewTextBoxColumn.HeaderText = "Acessório";
            this.dsacessorioDataGridViewTextBoxColumn.Name = "dsacessorioDataGridViewTextBoxColumn";
            this.dsacessorioDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsacessorioDataGridViewTextBoxColumn.Width = 78;
            // 
            // TFListaAcessorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 322);
            this.Controls.Add(this.gAcessorios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaAcessorios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckList Acessorios Devolver";
            this.Load += new System.EventHandler(this.TFListaAcessorios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gAcessorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcessorios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.DataGridDefault gAcessorios;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stdevolvidoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsacessorioDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsAcessorios;
    }
}