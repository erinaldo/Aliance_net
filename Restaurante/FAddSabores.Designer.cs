namespace Restaurante
{
    partial class TFAddSabores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAddSabores));
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gAssistente = new Componentes.DataGridDefault(this.components);
            this.st_agregar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dSSaborDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsSabores = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_total = new System.Windows.Forms.Label();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gAssistente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSabores)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.gAssistente);
            this.panelDados1.Controls.Add(this.lbl_total);
            this.panelDados1.Controls.Add(this.barraMenu);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 0);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(544, 339);
            this.panelDados1.TabIndex = 0;
            // 
            // gAssistente
            // 
            this.gAssistente.AllowUserToAddRows = false;
            this.gAssistente.AllowUserToDeleteRows = false;
            this.gAssistente.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gAssistente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gAssistente.AutoGenerateColumns = false;
            this.gAssistente.BackgroundColor = System.Drawing.Color.LightGray;
            this.gAssistente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gAssistente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAssistente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gAssistente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gAssistente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.st_agregar,
            this.dSSaborDataGridViewTextBoxColumn});
            this.gAssistente.DataSource = this.bsSabores;
            this.gAssistente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gAssistente.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gAssistente.Location = new System.Drawing.Point(0, 58);
            this.gAssistente.Name = "gAssistente";
            this.gAssistente.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAssistente.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gAssistente.RowHeadersWidth = 23;
            this.gAssistente.Size = new System.Drawing.Size(544, 281);
            this.gAssistente.TabIndex = 873;
            this.gAssistente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gAssistente_CellClick);
            // 
            // st_agregar
            // 
            this.st_agregar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.st_agregar.DataPropertyName = "st_agregar";
            this.st_agregar.HeaderText = "Adicionar";
            this.st_agregar.Name = "st_agregar";
            this.st_agregar.ReadOnly = true;
            this.st_agregar.Width = 57;
            // 
            // dSSaborDataGridViewTextBoxColumn
            // 
            this.dSSaborDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSSaborDataGridViewTextBoxColumn.DataPropertyName = "DS_Sabor";
            this.dSSaborDataGridViewTextBoxColumn.HeaderText = "Sabor";
            this.dSSaborDataGridViewTextBoxColumn.Name = "dSSaborDataGridViewTextBoxColumn";
            this.dSSaborDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSSaborDataGridViewTextBoxColumn.Width = 60;
            // 
            // bsSabores
            // 
            this.bsSabores.DataSource = typeof(CamadaDados.Restaurante.Cadastro.TList_Sabores);
            // 
            // lbl_total
            // 
            this.lbl_total.BackColor = System.Drawing.Color.Silver;
            this.lbl_total.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(0, 43);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(544, 15);
            this.lbl_total.TabIndex = 874;
            this.lbl_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar,
            this.toolStripSeparator1});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(544, 43);
            this.barraMenu.TabIndex = 871;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nAdicionar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6/ESC)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // TFAddSabores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 339);
            this.Controls.Add(this.panelDados1);
            this.KeyPreview = true;
            this.Name = "TFAddSabores";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sabores";
            this.Load += new System.EventHandler(this.FAddSabores_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FAddSabores_KeyDown);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gAssistente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSabores)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados panelDados1;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Componentes.DataGridDefault gAssistente;
        private System.Windows.Forms.BindingSource bsSabores;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_agregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSSaborDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lbl_total;
    }
}