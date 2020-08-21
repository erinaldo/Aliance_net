namespace PostoCombustivel
{
    partial class TFListaTrocaEspecie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaTrocaEspecie));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.gTroca = new Componentes.DataGridDefault(this.components);
            this.bsTrocaEspecie = new System.Windows.Forms.BindingSource(this.components);
            this.vltrocoCHTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vltrocoCHPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vltrocoDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dttrocaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlespecieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsportadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTroca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrocaEspecie)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(848, 43);
            this.barraMenu.TabIndex = 3;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // gTroca
            // 
            this.gTroca.AllowUserToAddRows = false;
            this.gTroca.AllowUserToDeleteRows = false;
            this.gTroca.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTroca.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.gTroca.AutoGenerateColumns = false;
            this.gTroca.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTroca.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTroca.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTroca.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gTroca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTroca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dsportadorDataGridViewTextBoxColumn,
            this.vlespecieDataGridViewTextBoxColumn,
            this.dttrocaDataGridViewTextBoxColumn,
            this.vltrocoDDataGridViewTextBoxColumn,
            this.vltrocoCHPDataGridViewTextBoxColumn,
            this.vltrocoCHTDataGridViewTextBoxColumn});
            this.gTroca.DataSource = this.bsTrocaEspecie;
            this.gTroca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTroca.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTroca.Location = new System.Drawing.Point(0, 43);
            this.gTroca.MultiSelect = false;
            this.gTroca.Name = "gTroca";
            this.gTroca.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTroca.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.gTroca.RowHeadersWidth = 23;
            this.gTroca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gTroca.Size = new System.Drawing.Size(848, 421);
            this.gTroca.TabIndex = 4;
            // 
            // bsTrocaEspecie
            // 
            this.bsTrocaEspecie.DataSource = typeof(CamadaDados.Faturamento.PDV.TList_TrocaEspecie);
            // 
            // vltrocoCHTDataGridViewTextBoxColumn
            // 
            this.vltrocoCHTDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vltrocoCHTDataGridViewTextBoxColumn.DataPropertyName = "Vl_trocoCHT";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = "0";
            this.vltrocoCHTDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.vltrocoCHTDataGridViewTextBoxColumn.HeaderText = "Cheque Repasse";
            this.vltrocoCHTDataGridViewTextBoxColumn.Name = "vltrocoCHTDataGridViewTextBoxColumn";
            this.vltrocoCHTDataGridViewTextBoxColumn.ReadOnly = true;
            this.vltrocoCHTDataGridViewTextBoxColumn.Width = 105;
            // 
            // vltrocoCHPDataGridViewTextBoxColumn
            // 
            this.vltrocoCHPDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vltrocoCHPDataGridViewTextBoxColumn.DataPropertyName = "Vl_trocoCHP";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = "0";
            this.vltrocoCHPDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.vltrocoCHPDataGridViewTextBoxColumn.HeaderText = "Cheque Troco";
            this.vltrocoCHPDataGridViewTextBoxColumn.Name = "vltrocoCHPDataGridViewTextBoxColumn";
            this.vltrocoCHPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vltrocoDDataGridViewTextBoxColumn
            // 
            this.vltrocoDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vltrocoDDataGridViewTextBoxColumn.DataPropertyName = "Vl_trocoD";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = "0";
            this.vltrocoDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.vltrocoDDataGridViewTextBoxColumn.HeaderText = "Troco Dinheiro";
            this.vltrocoDDataGridViewTextBoxColumn.Name = "vltrocoDDataGridViewTextBoxColumn";
            this.vltrocoDDataGridViewTextBoxColumn.ReadOnly = true;
            this.vltrocoDDataGridViewTextBoxColumn.Width = 102;
            // 
            // dttrocaDataGridViewTextBoxColumn
            // 
            this.dttrocaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dttrocaDataGridViewTextBoxColumn.DataPropertyName = "Dt_troca";
            dataGridViewCellStyle12.Format = "d";
            dataGridViewCellStyle12.NullValue = null;
            this.dttrocaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.dttrocaDataGridViewTextBoxColumn.HeaderText = "Dt. Troca";
            this.dttrocaDataGridViewTextBoxColumn.Name = "dttrocaDataGridViewTextBoxColumn";
            this.dttrocaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dttrocaDataGridViewTextBoxColumn.Width = 77;
            // 
            // vlespecieDataGridViewTextBoxColumn
            // 
            this.vlespecieDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlespecieDataGridViewTextBoxColumn.DataPropertyName = "Vl_especie";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0";
            this.vlespecieDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.vlespecieDataGridViewTextBoxColumn.HeaderText = "Vl. Especie";
            this.vlespecieDataGridViewTextBoxColumn.Name = "vlespecieDataGridViewTextBoxColumn";
            this.vlespecieDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlespecieDataGridViewTextBoxColumn.Width = 85;
            // 
            // dsportadorDataGridViewTextBoxColumn
            // 
            this.dsportadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsportadorDataGridViewTextBoxColumn.DataPropertyName = "Ds_portador";
            this.dsportadorDataGridViewTextBoxColumn.HeaderText = "Especie";
            this.dsportadorDataGridViewTextBoxColumn.Name = "dsportadorDataGridViewTextBoxColumn";
            this.dsportadorDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsportadorDataGridViewTextBoxColumn.Width = 70;
            // 
            // TFListaTrocaEspecie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 464);
            this.Controls.Add(this.gTroca);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaTrocaEspecie";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Troca Especie";
            this.Load += new System.EventHandler(this.TFListaTrocaEspecie_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaTrocaEspecie_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTroca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrocaEspecie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.DataGridDefault gTroca;
        private System.Windows.Forms.BindingSource bsTrocaEspecie;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsportadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlespecieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dttrocaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vltrocoDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vltrocoCHPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vltrocoCHTDataGridViewTextBoxColumn;
    }
}