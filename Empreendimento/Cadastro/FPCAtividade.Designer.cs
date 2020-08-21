namespace Empreendimento.Cadastro
{
    partial class FPCAtividade
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPCAtividade));
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.bsCadAtividade = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.dataGridDefault2 = new Componentes.DataGridDefault(this.components);
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.cd_vendedor = new Componentes.EditDefault(this.components);
            this.bb_vendedor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.idatividadestrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsatividadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcmargemcontDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadAtividade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault2)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.editDefault2);
            this.pDados.Controls.Add(this.cd_vendedor);
            this.pDados.Controls.Add(this.bb_vendedor);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.button1);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Size = new System.Drawing.Size(584, 58);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(596, 303);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault2);
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(588, 277);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault2, 0);
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadAtividade, "Pc_margemcont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(67, 27);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "id_atividade";
            this.editDefault1.NM_CampoBusca = "id_atividade";
            this.editDefault1.NM_Param = "@P_ID_ATIVIDADE";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(45, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = true;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = true;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 39;
            this.editDefault1.TextOld = null;
            this.editDefault1.Leave += new System.EventHandler(this.editDefault1_Leave);
            // 
            // bsCadAtividade
            // 
            this.bsCadAtividade.DataSource = typeof(CamadaDados.Empreendimento.Cadastro.TList_CadAtividade);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(114, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 20);
            this.button1.TabIndex = 40;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Percentual:";
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 58);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(584, 215);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // dataGridDefault2
            // 
            this.dataGridDefault2.AllowUserToAddRows = false;
            this.dataGridDefault2.AllowUserToDeleteRows = false;
            this.dataGridDefault2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridDefault2.AutoGenerateColumns = false;
            this.dataGridDefault2.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridDefault2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idatividadestrDataGridViewTextBoxColumn,
            this.dsatividadeDataGridViewTextBoxColumn,
            this.pcmargemcontDataGridViewTextBoxColumn});
            this.dataGridDefault2.DataSource = this.bsCadAtividade;
            this.dataGridDefault2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault2.Location = new System.Drawing.Point(0, 58);
            this.dataGridDefault2.Name = "dataGridDefault2";
            this.dataGridDefault2.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault2.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridDefault2.RowHeadersWidth = 23;
            this.dataGridDefault2.Size = new System.Drawing.Size(584, 215);
            this.dataGridDefault2.TabIndex = 2;
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadAtividade, "Ds_atividade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Location = new System.Drawing.Point(193, 3);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "DS_ATIVIDADE";
            this.editDefault2.NM_CampoBusca = "DS_ATIVIDADE";
            this.editDefault2.NM_Param = "@P_DS_ATIVIDADE";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.Size = new System.Drawing.Size(232, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = false;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = false;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 45;
            this.editDefault2.TextOld = null;
            // 
            // cd_vendedor
            // 
            this.cd_vendedor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_vendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_vendedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadAtividade, "Id_atividadestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_vendedor.Location = new System.Drawing.Point(64, 3);
            this.cd_vendedor.Name = "cd_vendedor";
            this.cd_vendedor.NM_Alias = "";
            this.cd_vendedor.NM_Campo = "id_atividade";
            this.cd_vendedor.NM_CampoBusca = "id_atividade";
            this.cd_vendedor.NM_Param = "@P_ID_ATIVIDADE";
            this.cd_vendedor.QTD_Zero = 0;
            this.cd_vendedor.Size = new System.Drawing.Size(93, 20);
            this.cd_vendedor.ST_AutoInc = false;
            this.cd_vendedor.ST_DisableAuto = false;
            this.cd_vendedor.ST_Float = false;
            this.cd_vendedor.ST_Gravar = true;
            this.cd_vendedor.ST_Int = false;
            this.cd_vendedor.ST_LimpaCampo = true;
            this.cd_vendedor.ST_NotNull = true;
            this.cd_vendedor.ST_PrimaryKey = false;
            this.cd_vendedor.TabIndex = 43;
            this.cd_vendedor.TextOld = null;
            this.cd_vendedor.Leave += new System.EventHandler(this.cd_vendedor_Leave);
            // 
            // bb_vendedor
            // 
            this.bb_vendedor.Image = ((System.Drawing.Image)(resources.GetObject("bb_vendedor.Image")));
            this.bb_vendedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_vendedor.Location = new System.Drawing.Point(159, 3);
            this.bb_vendedor.Name = "bb_vendedor";
            this.bb_vendedor.Size = new System.Drawing.Size(28, 20);
            this.bb_vendedor.TabIndex = 44;
            this.bb_vendedor.UseVisualStyleBackColor = true;
            this.bb_vendedor.Click += new System.EventHandler(this.bb_vendedor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Atividade:";
            // 
            // idatividadestrDataGridViewTextBoxColumn
            // 
            this.idatividadestrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idatividadestrDataGridViewTextBoxColumn.DataPropertyName = "Id_atividadestr";
            this.idatividadestrDataGridViewTextBoxColumn.HeaderText = "Id. Atividade";
            this.idatividadestrDataGridViewTextBoxColumn.Name = "idatividadestrDataGridViewTextBoxColumn";
            this.idatividadestrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idatividadestrDataGridViewTextBoxColumn.Width = 91;
            // 
            // dsatividadeDataGridViewTextBoxColumn
            // 
            this.dsatividadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsatividadeDataGridViewTextBoxColumn.DataPropertyName = "Ds_atividade";
            this.dsatividadeDataGridViewTextBoxColumn.HeaderText = "Atividade";
            this.dsatividadeDataGridViewTextBoxColumn.Name = "dsatividadeDataGridViewTextBoxColumn";
            this.dsatividadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsatividadeDataGridViewTextBoxColumn.Width = 76;
            // 
            // pcmargemcontDataGridViewTextBoxColumn
            // 
            this.pcmargemcontDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pcmargemcontDataGridViewTextBoxColumn.DataPropertyName = "Pc_margemcont";
            this.pcmargemcontDataGridViewTextBoxColumn.HeaderText = "Percentual";
            this.pcmargemcontDataGridViewTextBoxColumn.Name = "pcmargemcontDataGridViewTextBoxColumn";
            this.pcmargemcontDataGridViewTextBoxColumn.ReadOnly = true;
            this.pcmargemcontDataGridViewTextBoxColumn.Width = 83;
            // 
            // FPCAtividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 346);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FPCAtividade";
            this.Text = "Lançar Percentual Atividade";
            this.Load += new System.EventHandler(this.FPCAtividade_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCadAtividade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsCadAtividade;
        private Componentes.DataGridDefault dataGridDefault2;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault editDefault2;
        private Componentes.EditDefault cd_vendedor;
        private System.Windows.Forms.Button bb_vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idatividadestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsatividadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcmargemcontDataGridViewTextBoxColumn;
    }
}