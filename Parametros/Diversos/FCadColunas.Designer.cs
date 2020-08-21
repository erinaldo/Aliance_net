namespace Parametros.Diversos
{
    partial class FCadColunas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadColunas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.nmtabelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcolunaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscolunaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcolunaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmtabelaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcolunaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscolunaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nmtabelaDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcolunaDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscolunaDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsColunas = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColunas)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(416, 43);
            this.barraMenu.TabIndex = 15;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.Green;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(95, 40);
            this.toolStripButton1.Text = "(F4)\r\nConfirmar";
            this.toolStripButton1.ToolTipText = "Confirmar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // nmtabelaDataGridViewTextBoxColumn
            // 
            this.nmtabelaDataGridViewTextBoxColumn.DataPropertyName = "nm_tabela";
            this.nmtabelaDataGridViewTextBoxColumn.HeaderText = "nm_tabela";
            this.nmtabelaDataGridViewTextBoxColumn.Name = "nmtabelaDataGridViewTextBoxColumn";
            this.nmtabelaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmcolunaDataGridViewTextBoxColumn
            // 
            this.nmcolunaDataGridViewTextBoxColumn.DataPropertyName = "nm_coluna";
            this.nmcolunaDataGridViewTextBoxColumn.HeaderText = "nm_coluna";
            this.nmcolunaDataGridViewTextBoxColumn.Name = "nmcolunaDataGridViewTextBoxColumn";
            this.nmcolunaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dscolunaDataGridViewTextBoxColumn
            // 
            this.dscolunaDataGridViewTextBoxColumn.DataPropertyName = "ds_coluna";
            this.dscolunaDataGridViewTextBoxColumn.HeaderText = "ds_coluna";
            this.dscolunaDataGridViewTextBoxColumn.Name = "dscolunaDataGridViewTextBoxColumn";
            this.dscolunaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idcolunaDataGridViewTextBoxColumn
            // 
            this.idcolunaDataGridViewTextBoxColumn.DataPropertyName = "id_coluna";
            this.idcolunaDataGridViewTextBoxColumn.HeaderText = "id_coluna";
            this.idcolunaDataGridViewTextBoxColumn.Name = "idcolunaDataGridViewTextBoxColumn";
            // 
            // nmtabelaDataGridViewTextBoxColumn1
            // 
            this.nmtabelaDataGridViewTextBoxColumn1.DataPropertyName = "nm_tabela";
            this.nmtabelaDataGridViewTextBoxColumn1.HeaderText = "nm_tabela";
            this.nmtabelaDataGridViewTextBoxColumn1.Name = "nmtabelaDataGridViewTextBoxColumn1";
            // 
            // nmcolunaDataGridViewTextBoxColumn1
            // 
            this.nmcolunaDataGridViewTextBoxColumn1.DataPropertyName = "nm_coluna";
            this.nmcolunaDataGridViewTextBoxColumn1.HeaderText = "nm_coluna";
            this.nmcolunaDataGridViewTextBoxColumn1.Name = "nmcolunaDataGridViewTextBoxColumn1";
            // 
            // dscolunaDataGridViewTextBoxColumn1
            // 
            this.dscolunaDataGridViewTextBoxColumn1.DataPropertyName = "ds_coluna";
            this.dscolunaDataGridViewTextBoxColumn1.HeaderText = "ds_coluna";
            this.dscolunaDataGridViewTextBoxColumn1.Name = "dscolunaDataGridViewTextBoxColumn1";
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.dataGridView1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(416, 547);
            this.panelDados1.TabIndex = 16;
            this.panelDados1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDados1_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nmtabelaDataGridViewTextBoxColumn2,
            this.nmcolunaDataGridViewTextBoxColumn2,
            this.dscolunaDataGridViewTextBoxColumn2});
            this.dataGridView1.DataSource = this.bsColunas;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(416, 547);
            this.dataGridView1.TabIndex = 1;
            // 
            // nmtabelaDataGridViewTextBoxColumn2
            // 
            this.nmtabelaDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmtabelaDataGridViewTextBoxColumn2.DataPropertyName = "nm_tabela";
            this.nmtabelaDataGridViewTextBoxColumn2.HeaderText = "Tabela";
            this.nmtabelaDataGridViewTextBoxColumn2.Name = "nmtabelaDataGridViewTextBoxColumn2";
            this.nmtabelaDataGridViewTextBoxColumn2.ReadOnly = true;
            this.nmtabelaDataGridViewTextBoxColumn2.Width = 65;
            // 
            // nmcolunaDataGridViewTextBoxColumn2
            // 
            this.nmcolunaDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcolunaDataGridViewTextBoxColumn2.DataPropertyName = "nm_coluna";
            this.nmcolunaDataGridViewTextBoxColumn2.HeaderText = "Coluna";
            this.nmcolunaDataGridViewTextBoxColumn2.Name = "nmcolunaDataGridViewTextBoxColumn2";
            this.nmcolunaDataGridViewTextBoxColumn2.ReadOnly = true;
            this.nmcolunaDataGridViewTextBoxColumn2.Width = 65;
            // 
            // dscolunaDataGridViewTextBoxColumn2
            // 
            this.dscolunaDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscolunaDataGridViewTextBoxColumn2.DataPropertyName = "ds_coluna";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dscolunaDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dscolunaDataGridViewTextBoxColumn2.HeaderText = "Label";
            this.dscolunaDataGridViewTextBoxColumn2.Name = "dscolunaDataGridViewTextBoxColumn2";
            this.dscolunaDataGridViewTextBoxColumn2.Width = 58;
            // 
            // bsColunas
            // 
            this.bsColunas.DataSource = typeof(CamadaDados.Diversos.TList_Colunas);
            // 
            // FCadColunas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 590);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "FCadColunas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Cad Label.";
            this.Load += new System.EventHandler(this.FCadColunas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCadColunas_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColunas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingSource bsColunas;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtabelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcolunaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscolunaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcolunaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtabelaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcolunaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscolunaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtabelaDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcolunaDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscolunaDataGridViewTextBoxColumn2;
    }
}