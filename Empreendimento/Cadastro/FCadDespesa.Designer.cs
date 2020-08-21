namespace Empreendimento.Cadastro
{
    partial class FCadDespesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadDespesa));
            this.label1 = new System.Windows.Forms.Label();
            this.id = new Componentes.EditDefault(this.components);
            this.bsCadDespesa = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.iddespesastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsdespesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadDespesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.editDefault2);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.id);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Size = new System.Drawing.Size(474, 33);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(486, 219);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(478, 193);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Despesa:";
            // 
            // id
            // 
            this.id.BackColor = System.Drawing.SystemColors.Window;
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadDespesa, "Id_despesastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id.Location = new System.Drawing.Point(74, 3);
            this.id.Name = "id";
            this.id.NM_Alias = "";
            this.id.NM_Campo = "id_despesa";
            this.id.NM_CampoBusca = "id_despesa";
            this.id.NM_Param = "@P_ID_DESPESA";
            this.id.QTD_Zero = 0;
            this.id.Size = new System.Drawing.Size(56, 20);
            this.id.ST_AutoInc = true;
            this.id.ST_DisableAuto = false;
            this.id.ST_Float = true;
            this.id.ST_Gravar = true;
            this.id.ST_Int = false;
            this.id.ST_LimpaCampo = true;
            this.id.ST_NotNull = true;
            this.id.ST_PrimaryKey = false;
            this.id.TabIndex = 1;
            this.id.TextOld = null;
            // 
            // bsCadDespesa
            // 
            this.bsCadDespesa.DataSource = typeof(CamadaDados.Empreendimento.Cadastro.TList_CadDespesa);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ds Despesa:";
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadDespesa, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Location = new System.Drawing.Point(210, 4);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "ds_despesa";
            this.editDefault2.NM_CampoBusca = "ds_despesa";
            this.editDefault2.NM_Param = "@P_DS_DESPESA";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.Size = new System.Drawing.Size(252, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = true;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = true;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 3;
            this.editDefault2.TextOld = null;
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
            this.dsdespesaDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsCadDespesa;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 33);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(474, 156);
            this.dataGridDefault1.TabIndex = 1;
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
            this.dsdespesaDataGridViewTextBoxColumn.HeaderText = "Ds. Despesa";
            this.dsdespesaDataGridViewTextBoxColumn.Name = "dsdespesaDataGridViewTextBoxColumn";
            this.dsdespesaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsdespesaDataGridViewTextBoxColumn.Width = 93;
            // 
            // FCadDespesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCadDespesa";
            this.Text = "Cadastro de despesa";
            this.Load += new System.EventHandler(this.FCadDespesa_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCadDespesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault id;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault editDefault2;
        private System.Windows.Forms.Label label2;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsCadDespesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddespesastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsdespesaDataGridViewTextBoxColumn;
    }
}