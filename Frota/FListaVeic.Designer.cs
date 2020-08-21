namespace Frota
{
    partial class TFListaVeic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaVeic));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.gVeiculo = new Componentes.DataGridDefault(this.components);
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idveiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsveiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.renavanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsveiculoprincipalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpveiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tprodadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocarroceriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ufveiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsVeiculo = new System.Windows.Forms.BindingSource(this.components);
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gVeiculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVeiculo)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(762, 43);
            this.barraMenu.TabIndex = 20;
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
            // gVeiculo
            // 
            this.gVeiculo.AllowUserToAddRows = false;
            this.gVeiculo.AllowUserToDeleteRows = false;
            this.gVeiculo.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gVeiculo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gVeiculo.AutoGenerateColumns = false;
            this.gVeiculo.BackgroundColor = System.Drawing.Color.LightGray;
            this.gVeiculo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gVeiculo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gVeiculo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gVeiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gVeiculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.idveiculoDataGridViewTextBoxColumn,
            this.dsveiculoDataGridViewTextBoxColumn,
            this.placaDataGridViewTextBoxColumn,
            this.renavanDataGridViewTextBoxColumn,
            this.dsveiculoprincipalDataGridViewTextBoxColumn,
            this.tpveiculoDataGridViewTextBoxColumn,
            this.tprodadoDataGridViewTextBoxColumn,
            this.tipocarroceriaDataGridViewTextBoxColumn,
            this.ufveiculoDataGridViewTextBoxColumn});
            this.gVeiculo.DataSource = this.bsVeiculo;
            this.gVeiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gVeiculo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gVeiculo.Location = new System.Drawing.Point(0, 43);
            this.gVeiculo.Name = "gVeiculo";
            this.gVeiculo.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gVeiculo.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gVeiculo.RowHeadersWidth = 23;
            this.gVeiculo.Size = new System.Drawing.Size(762, 406);
            this.gVeiculo.TabIndex = 21;
            this.gVeiculo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gVeiculo_ColumnHeaderMouseClick);
            this.gVeiculo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gVeiculo_CellClick);
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Marcar";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Width = 46;
            // 
            // idveiculoDataGridViewTextBoxColumn
            // 
            this.idveiculoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idveiculoDataGridViewTextBoxColumn.DataPropertyName = "Id_veiculo";
            this.idveiculoDataGridViewTextBoxColumn.HeaderText = "Id. Veiculo";
            this.idveiculoDataGridViewTextBoxColumn.Name = "idveiculoDataGridViewTextBoxColumn";
            this.idveiculoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idveiculoDataGridViewTextBoxColumn.Width = 82;
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
            // placaDataGridViewTextBoxColumn
            // 
            this.placaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.placaDataGridViewTextBoxColumn.DataPropertyName = "placa";
            this.placaDataGridViewTextBoxColumn.HeaderText = "Placa";
            this.placaDataGridViewTextBoxColumn.Name = "placaDataGridViewTextBoxColumn";
            this.placaDataGridViewTextBoxColumn.ReadOnly = true;
            this.placaDataGridViewTextBoxColumn.Width = 59;
            // 
            // renavanDataGridViewTextBoxColumn
            // 
            this.renavanDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.renavanDataGridViewTextBoxColumn.DataPropertyName = "renavan";
            this.renavanDataGridViewTextBoxColumn.HeaderText = "Renavan";
            this.renavanDataGridViewTextBoxColumn.Name = "renavanDataGridViewTextBoxColumn";
            this.renavanDataGridViewTextBoxColumn.ReadOnly = true;
            this.renavanDataGridViewTextBoxColumn.Width = 76;
            // 
            // dsveiculoprincipalDataGridViewTextBoxColumn
            // 
            this.dsveiculoprincipalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsveiculoprincipalDataGridViewTextBoxColumn.DataPropertyName = "Ds_veiculo_principal";
            this.dsveiculoprincipalDataGridViewTextBoxColumn.HeaderText = "Veiculo Principal";
            this.dsveiculoprincipalDataGridViewTextBoxColumn.Name = "dsveiculoprincipalDataGridViewTextBoxColumn";
            this.dsveiculoprincipalDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsveiculoprincipalDataGridViewTextBoxColumn.Width = 101;
            // 
            // tpveiculoDataGridViewTextBoxColumn
            // 
            this.tpveiculoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpveiculoDataGridViewTextBoxColumn.DataPropertyName = "Tp_veiculo";
            this.tpveiculoDataGridViewTextBoxColumn.HeaderText = "TP. Veiculo";
            this.tpveiculoDataGridViewTextBoxColumn.Name = "tpveiculoDataGridViewTextBoxColumn";
            this.tpveiculoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tpveiculoDataGridViewTextBoxColumn.Width = 80;
            // 
            // tprodadoDataGridViewTextBoxColumn
            // 
            this.tprodadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tprodadoDataGridViewTextBoxColumn.DataPropertyName = "Tp_rodado";
            this.tprodadoDataGridViewTextBoxColumn.HeaderText = "TP. Rodado";
            this.tprodadoDataGridViewTextBoxColumn.Name = "tprodadoDataGridViewTextBoxColumn";
            this.tprodadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tprodadoDataGridViewTextBoxColumn.Width = 83;
            // 
            // tipocarroceriaDataGridViewTextBoxColumn
            // 
            this.tipocarroceriaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipocarroceriaDataGridViewTextBoxColumn.DataPropertyName = "Tipo_carroceria";
            this.tipocarroceriaDataGridViewTextBoxColumn.HeaderText = "Carroceria";
            this.tipocarroceriaDataGridViewTextBoxColumn.Name = "tipocarroceriaDataGridViewTextBoxColumn";
            this.tipocarroceriaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipocarroceriaDataGridViewTextBoxColumn.Width = 80;
            // 
            // ufveiculoDataGridViewTextBoxColumn
            // 
            this.ufveiculoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ufveiculoDataGridViewTextBoxColumn.DataPropertyName = "Uf_veiculo";
            this.ufveiculoDataGridViewTextBoxColumn.HeaderText = "UF";
            this.ufveiculoDataGridViewTextBoxColumn.Name = "ufveiculoDataGridViewTextBoxColumn";
            this.ufveiculoDataGridViewTextBoxColumn.ReadOnly = true;
            this.ufveiculoDataGridViewTextBoxColumn.Width = 46;
            // 
            // bsVeiculo
            // 
            this.bsVeiculo.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_CadVeiculo);
            // 
            // cbTodos
            // 
            this.cbTodos.Location = new System.Drawing.Point(6, 54);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.NM_Alias = "";
            this.cbTodos.NM_Campo = "";
            this.cbTodos.NM_Param = "";
            this.cbTodos.Size = new System.Drawing.Size(15, 14);
            this.cbTodos.ST_Gravar = false;
            this.cbTodos.ST_LimparCampo = true;
            this.cbTodos.ST_NotNull = false;
            this.cbTodos.TabIndex = 22;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            this.cbTodos.Click += new System.EventHandler(this.cbTodos_Click);
            // 
            // TFListaVeic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 449);
            this.Controls.Add(this.cbTodos);
            this.Controls.Add(this.gVeiculo);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaVeic";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Veiculos";
            this.Load += new System.EventHandler(this.TFListaVeic_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaVeic_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gVeiculo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVeiculo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.DataGridDefault gVeiculo;
        private System.Windows.Forms.BindingSource bsVeiculo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idveiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsveiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn renavanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsveiculoprincipalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpveiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tprodadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocarroceriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ufveiculoDataGridViewTextBoxColumn;
        private Componentes.CheckBoxDefault cbTodos;
    }
}