namespace Utils
{
    partial class TFNumero_Nota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFNumero_Nota));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.NR_Nota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pNota = new System.Windows.Forms.Panel();
            this.pCabecalho = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tp_nota = new System.Windows.Forms.TextBox();
            this.ds_serie = new System.Windows.Forms.TextBox();
            this.nr_serie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nm_clifor = new System.Windows.Forms.TextBox();
            this.cd_clifor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nm_empresa = new System.Windows.Forms.TextBox();
            this.cd_empresa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bb_serie = new System.Windows.Forms.Button();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pNota.SuspendLayout();
            this.pCabecalho.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(426, 43);
            this.barraMenu.TabIndex = 1;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(105, 40);
            this.BB_Gravar.Text = "(F4)\r\nConfirmar";
            this.BB_Gravar.ToolTipText = "Confirmar Numero da Nota Fiscal";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // NR_Nota
            // 
            this.NR_Nota.BackColor = System.Drawing.SystemColors.Window;
            this.NR_Nota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NR_Nota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NR_Nota.Location = new System.Drawing.Point(74, 32);
            this.NR_Nota.Name = "NR_Nota";
            this.NR_Nota.Size = new System.Drawing.Size(91, 20);
            this.NR_Nota.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nº Nota:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pNota, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pCabecalho, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(426, 161);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // pNota
            // 
            this.pNota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pNota.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pNota.Controls.Add(this.bb_serie);
            this.pNota.Controls.Add(this.label1);
            this.pNota.Controls.Add(this.NR_Nota);
            this.pNota.Controls.Add(this.ds_serie);
            this.pNota.Controls.Add(this.nr_serie);
            this.pNota.Controls.Add(this.label4);
            this.pNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pNota.Location = new System.Drawing.Point(6, 96);
            this.pNota.Name = "pNota";
            this.pNota.Size = new System.Drawing.Size(414, 59);
            this.pNota.TabIndex = 1;
            // 
            // pCabecalho
            // 
            this.pCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pCabecalho.Controls.Add(this.label5);
            this.pCabecalho.Controls.Add(this.tp_nota);
            this.pCabecalho.Controls.Add(this.nm_clifor);
            this.pCabecalho.Controls.Add(this.cd_clifor);
            this.pCabecalho.Controls.Add(this.label3);
            this.pCabecalho.Controls.Add(this.nm_empresa);
            this.pCabecalho.Controls.Add(this.cd_empresa);
            this.pCabecalho.Controls.Add(this.label2);
            this.pCabecalho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCabecalho.Location = new System.Drawing.Point(6, 6);
            this.pCabecalho.Name = "pCabecalho";
            this.pCabecalho.Size = new System.Drawing.Size(414, 81);
            this.pCabecalho.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-2, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tipo Nota:";
            // 
            // tp_nota
            // 
            this.tp_nota.Enabled = false;
            this.tp_nota.Location = new System.Drawing.Point(61, 54);
            this.tp_nota.Name = "tp_nota";
            this.tp_nota.Size = new System.Drawing.Size(61, 20);
            this.tp_nota.TabIndex = 9;
            // 
            // ds_serie
            // 
            this.ds_serie.Enabled = false;
            this.ds_serie.Location = new System.Drawing.Point(149, 6);
            this.ds_serie.Name = "ds_serie";
            this.ds_serie.Size = new System.Drawing.Size(257, 20);
            this.ds_serie.TabIndex = 8;
            // 
            // nr_serie
            // 
            this.nr_serie.Enabled = false;
            this.nr_serie.Location = new System.Drawing.Point(74, 6);
            this.nr_serie.Name = "nr_serie";
            this.nr_serie.Size = new System.Drawing.Size(38, 20);
            this.nr_serie.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Serie:";
            // 
            // nm_clifor
            // 
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Location = new System.Drawing.Point(143, 29);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.Size = new System.Drawing.Size(263, 20);
            this.nm_clifor.TabIndex = 5;
            // 
            // cd_clifor
            // 
            this.cd_clifor.Enabled = false;
            this.cd_clifor.Location = new System.Drawing.Point(61, 29);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.Size = new System.Drawing.Size(81, 20);
            this.cd_clifor.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Clifor:";
            // 
            // nm_empresa
            // 
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(113, 5);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.Size = new System.Drawing.Size(293, 20);
            this.nm_empresa.TabIndex = 2;
            // 
            // cd_empresa
            // 
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(61, 5);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.Size = new System.Drawing.Size(51, 20);
            this.cd_empresa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Empresa:";
            // 
            // bb_serie
            // 
            this.bb_serie.BackColor = System.Drawing.SystemColors.Control;
            this.bb_serie.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_serie.Image = ((System.Drawing.Image)(resources.GetObject("bb_serie.Image")));
            this.bb_serie.Location = new System.Drawing.Point(113, 6);
            this.bb_serie.Name = "bb_serie";
            this.bb_serie.Size = new System.Drawing.Size(30, 20);
            this.bb_serie.TabIndex = 71;
            this.bb_serie.UseVisualStyleBackColor = false;
            this.bb_serie.Click += new System.EventHandler(this.bb_serie_Click);
            // 
            // TFNumero_Nota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 204);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFNumero_Nota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Número Nota";
            this.Load += new System.EventHandler(this.TFNumero_Nota_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFNumero_Nota_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pNota.ResumeLayout(false);
            this.pNota.PerformLayout();
            this.pCabecalho.ResumeLayout(false);
            this.pCabecalho.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TextBox NR_Nota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pNota;
        private System.Windows.Forms.Panel pCabecalho;
        private System.Windows.Forms.TextBox ds_serie;
        private System.Windows.Forms.TextBox nr_serie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nm_clifor;
        private System.Windows.Forms.TextBox cd_clifor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nm_empresa;
        private System.Windows.Forms.TextBox cd_empresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tp_nota;
        private System.Windows.Forms.Button bb_serie;
    }
}