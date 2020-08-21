namespace Servicos
{
    partial class TFListaVeiculoCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaVeiculoCliente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gVeiculoCliente = new Componentes.DataGridDefault(this.components);
            this.stprocessarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nmcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placaveiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsveiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmarcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsVeiculoCliente = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gVeiculoCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVeiculoCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(801, 43);
            this.barraMenu.TabIndex = 12;
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
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
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
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.gVeiculoCliente);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(801, 352);
            this.panelDados1.TabIndex = 13;
            // 
            // gVeiculoCliente
            // 
            this.gVeiculoCliente.AllowUserToAddRows = false;
            this.gVeiculoCliente.AllowUserToDeleteRows = false;
            this.gVeiculoCliente.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gVeiculoCliente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gVeiculoCliente.AutoGenerateColumns = false;
            this.gVeiculoCliente.BackgroundColor = System.Drawing.Color.LightGray;
            this.gVeiculoCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gVeiculoCliente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gVeiculoCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gVeiculoCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gVeiculoCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stprocessarDataGridViewCheckBoxColumn,
            this.nmcliforDataGridViewTextBoxColumn,
            this.placaveiculoDataGridViewTextBoxColumn,
            this.dsveiculoDataGridViewTextBoxColumn,
            this.dsmarcaDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn});
            this.gVeiculoCliente.DataSource = this.bsVeiculoCliente;
            this.gVeiculoCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gVeiculoCliente.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gVeiculoCliente.Location = new System.Drawing.Point(0, 0);
            this.gVeiculoCliente.Name = "gVeiculoCliente";
            this.gVeiculoCliente.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gVeiculoCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gVeiculoCliente.RowHeadersWidth = 23;
            this.gVeiculoCliente.Size = new System.Drawing.Size(797, 348);
            this.gVeiculoCliente.TabIndex = 0;
            this.gVeiculoCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gVeiculoCliente_CellClick);
            // 
            // stprocessarDataGridViewCheckBoxColumn
            // 
            this.stprocessarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stprocessarDataGridViewCheckBoxColumn.DataPropertyName = "St_processar";
            this.stprocessarDataGridViewCheckBoxColumn.HeaderText = "Selecionar";
            this.stprocessarDataGridViewCheckBoxColumn.Name = "stprocessarDataGridViewCheckBoxColumn";
            this.stprocessarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stprocessarDataGridViewCheckBoxColumn.Width = 63;
            // 
            // nmcliforDataGridViewTextBoxColumn
            // 
            this.nmcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor";
            this.nmcliforDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.nmcliforDataGridViewTextBoxColumn.Name = "nmcliforDataGridViewTextBoxColumn";
            this.nmcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcliforDataGridViewTextBoxColumn.Width = 64;
            // 
            // placaveiculoDataGridViewTextBoxColumn
            // 
            this.placaveiculoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.placaveiculoDataGridViewTextBoxColumn.DataPropertyName = "Placaveiculo";
            this.placaveiculoDataGridViewTextBoxColumn.HeaderText = "Placa";
            this.placaveiculoDataGridViewTextBoxColumn.Name = "placaveiculoDataGridViewTextBoxColumn";
            this.placaveiculoDataGridViewTextBoxColumn.ReadOnly = true;
            this.placaveiculoDataGridViewTextBoxColumn.Width = 59;
            // 
            // dsveiculoDataGridViewTextBoxColumn
            // 
            this.dsveiculoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsveiculoDataGridViewTextBoxColumn.DataPropertyName = "Ds_veiculo";
            this.dsveiculoDataGridViewTextBoxColumn.HeaderText = "Veiculo";
            this.dsveiculoDataGridViewTextBoxColumn.Name = "dsveiculoDataGridViewTextBoxColumn";
            this.dsveiculoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsveiculoDataGridViewTextBoxColumn.Width = 67;
            // 
            // dsmarcaDataGridViewTextBoxColumn
            // 
            this.dsmarcaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmarcaDataGridViewTextBoxColumn.DataPropertyName = "Ds_marca";
            this.dsmarcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.dsmarcaDataGridViewTextBoxColumn.Name = "dsmarcaDataGridViewTextBoxColumn";
            this.dsmarcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsmarcaDataGridViewTextBoxColumn.Width = 62;
            // 
            // dsobservacaoDataGridViewTextBoxColumn
            // 
            this.dsobservacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_observacao";
            this.dsobservacaoDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.dsobservacaoDataGridViewTextBoxColumn.Name = "dsobservacaoDataGridViewTextBoxColumn";
            this.dsobservacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsobservacaoDataGridViewTextBoxColumn.Width = 90;
            // 
            // bsVeiculoCliente
            // 
            this.bsVeiculoCliente.DataSource = typeof(CamadaDados.Servicos.Cadastros.TList_VeiculoCliente);
            // 
            // TFListaVeiculoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 395);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaVeiculoCliente";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Veiculo Cliente";
            this.Load += new System.EventHandler(this.TFListaVeiculoCliente_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFListaVeiculoCliente_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaVeiculoCliente_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gVeiculoCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVeiculoCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gVeiculoCliente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placaveiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsveiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmarcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsVeiculoCliente;
    }
}