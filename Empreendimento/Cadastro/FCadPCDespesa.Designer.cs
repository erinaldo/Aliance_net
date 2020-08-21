namespace Empreendimento.Cadastro
{
    partial class FCadPCDespesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadPCDespesa));
            this.editFloat3 = new Componentes.EditFloat(this.components);
            this.bsCadDespesa = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cd_vendedor = new Componentes.EditDefault(this.components);
            this.bb_vendedor = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.iddespesastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsdespesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcmargemcontDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadDespesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.cd_vendedor);
            this.pDados.Controls.Add(this.bb_vendedor);
            this.pDados.Controls.Add(this.label12);
            this.pDados.Controls.Add(this.editFloat3);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Size = new System.Drawing.Size(571, 66);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(583, 284);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(575, 258);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // editFloat3
            // 
            this.editFloat3.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCadDespesa, "Pc_margemcont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat3.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat3.Location = new System.Drawing.Point(77, 35);
            this.editFloat3.Name = "editFloat3";
            this.editFloat3.NM_Alias = "";
            this.editFloat3.NM_Campo = "";
            this.editFloat3.NM_Param = "";
            this.editFloat3.Operador = "";
            this.editFloat3.Size = new System.Drawing.Size(90, 20);
            this.editFloat3.ST_AutoInc = false;
            this.editFloat3.ST_DisableAuto = false;
            this.editFloat3.ST_Gravar = true;
            this.editFloat3.ST_LimparCampo = true;
            this.editFloat3.ST_NotNull = true;
            this.editFloat3.ST_PrimaryKey = false;
            this.editFloat3.TabIndex = 48;
            this.editFloat3.ThousandsSeparator = true;
            // 
            // bsCadDespesa
            // 
            this.bsCadDespesa.DataSource = typeof(CamadaDados.Empreendimento.Cadastro.TList_CadDespesa);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "PC. Despesa:";
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iddespesastrDataGridViewTextBoxColumn,
            this.dsdespesaDataGridViewTextBoxColumn,
            this.pcmargemcontDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsCadDespesa;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 66);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(571, 188);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // cd_vendedor
            // 
            this.cd_vendedor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_vendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_vendedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadDespesa, "Id_despesastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_vendedor.Location = new System.Drawing.Point(58, 3);
            this.cd_vendedor.Name = "cd_vendedor";
            this.cd_vendedor.NM_Alias = "";
            this.cd_vendedor.NM_Campo = "id_despesa";
            this.cd_vendedor.NM_CampoBusca = "id_despesa";
            this.cd_vendedor.NM_Param = "@P_ID_DESPESA";
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
            this.cd_vendedor.TabIndex = 49;
            this.cd_vendedor.TextOld = null;
            this.cd_vendedor.Leave += new System.EventHandler(this.cd_vendedor_Leave);
            // 
            // bb_vendedor
            // 
            this.bb_vendedor.Image = ((System.Drawing.Image)(resources.GetObject("bb_vendedor.Image")));
            this.bb_vendedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_vendedor.Location = new System.Drawing.Point(152, 3);
            this.bb_vendedor.Name = "bb_vendedor";
            this.bb_vendedor.Size = new System.Drawing.Size(28, 20);
            this.bb_vendedor.TabIndex = 50;
            this.bb_vendedor.UseVisualStyleBackColor = true;
            this.bb_vendedor.Click += new System.EventHandler(this.bb_vendedor_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 51;
            this.label12.Text = "Despesa";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadDespesa, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(186, 3);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "ds_despesa";
            this.editDefault1.NM_CampoBusca = "ds_despesa";
            this.editDefault1.NM_Param = "@P_DS_DESPESA";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(377, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 52;
            this.editDefault1.TextOld = null;
            // 
            // iddespesastrDataGridViewTextBoxColumn
            // 
            this.iddespesastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iddespesastrDataGridViewTextBoxColumn.DataPropertyName = "Id_despesastr";
            this.iddespesastrDataGridViewTextBoxColumn.HeaderText = "Id. Despesa";
            this.iddespesastrDataGridViewTextBoxColumn.Name = "iddespesastrDataGridViewTextBoxColumn";
            this.iddespesastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.iddespesastrDataGridViewTextBoxColumn.Width = 89;
            // 
            // dsdespesaDataGridViewTextBoxColumn
            // 
            this.dsdespesaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsdespesaDataGridViewTextBoxColumn.DataPropertyName = "Ds_despesa";
            this.dsdespesaDataGridViewTextBoxColumn.HeaderText = "Despesa";
            this.dsdespesaDataGridViewTextBoxColumn.Name = "dsdespesaDataGridViewTextBoxColumn";
            this.dsdespesaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsdespesaDataGridViewTextBoxColumn.Width = 74;
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
            // FCadPCDespesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 327);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCadPCDespesa";
            this.Text = "Lançar Percentual Despesa";
            this.Load += new System.EventHandler(this.FCadPCDespesa_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editFloat3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadDespesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditFloat editFloat3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bsCadDespesa;
        private Componentes.DataGridDefault dataGridDefault1;
        private Componentes.EditDefault cd_vendedor;
        private System.Windows.Forms.Button bb_vendedor;
        private System.Windows.Forms.Label label12;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddespesastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsdespesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcmargemcontDataGridViewTextBoxColumn;
    }
}