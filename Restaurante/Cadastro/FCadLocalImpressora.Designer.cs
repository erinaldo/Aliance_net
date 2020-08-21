namespace Restaurante.Cadastro
{
    partial class FCadLocalImpressora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadLocalImpressora));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.iDLocalImpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSLocalImpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portaImpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stImpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsLocalImp = new System.Windows.Forms.BindingSource(this.components);
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.editDefault3 = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDefault1 = new Componentes.ComboBoxDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocalImp)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.comboBoxDefault1);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.editDefault3);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.editDefault2);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Size = new System.Drawing.Size(516, 137);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(528, 352);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(520, 326);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDLocalImpDataGridViewTextBoxColumn,
            this.dSLocalImpDataGridViewTextBoxColumn,
            this.portaImpDataGridViewTextBoxColumn,
            this.stImpDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsLocalImp;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 137);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(516, 185);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // iDLocalImpDataGridViewTextBoxColumn
            // 
            this.iDLocalImpDataGridViewTextBoxColumn.DataPropertyName = "ID_LocalImp";
            this.iDLocalImpDataGridViewTextBoxColumn.HeaderText = "ID_LocalImp";
            this.iDLocalImpDataGridViewTextBoxColumn.Name = "iDLocalImpDataGridViewTextBoxColumn";
            this.iDLocalImpDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSLocalImpDataGridViewTextBoxColumn
            // 
            this.dSLocalImpDataGridViewTextBoxColumn.DataPropertyName = "DS_LocalImp";
            this.dSLocalImpDataGridViewTextBoxColumn.HeaderText = "DS_LocalImp";
            this.dSLocalImpDataGridViewTextBoxColumn.Name = "dSLocalImpDataGridViewTextBoxColumn";
            this.dSLocalImpDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // portaImpDataGridViewTextBoxColumn
            // 
            this.portaImpDataGridViewTextBoxColumn.DataPropertyName = "Porta_Imp";
            this.portaImpDataGridViewTextBoxColumn.HeaderText = "Porta_Imp";
            this.portaImpDataGridViewTextBoxColumn.Name = "portaImpDataGridViewTextBoxColumn";
            this.portaImpDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stImpDataGridViewTextBoxColumn
            // 
            this.stImpDataGridViewTextBoxColumn.DataPropertyName = "St_Imp";
            this.stImpDataGridViewTextBoxColumn.HeaderText = "St_Imp";
            this.stImpDataGridViewTextBoxColumn.Name = "stImpDataGridViewTextBoxColumn";
            this.stImpDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsLocalImp
            // 
            this.bsLocalImp.DataSource = typeof(CamadaDados.Restaurante.Cadastro.TList_LocalImp);
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocalImp, "ID_LocalImp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(63, 1);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(100, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = true;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 0;
            this.editDefault1.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID.Local";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local";
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocalImp, "DS_LocalImp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Enabled = false;
            this.editDefault2.Location = new System.Drawing.Point(63, 26);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "";
            this.editDefault2.NM_CampoBusca = "";
            this.editDefault2.NM_Param = "";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.Size = new System.Drawing.Size(271, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = true;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = false;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 3;
            this.editDefault2.TextOld = null;
            // 
            // editDefault3
            // 
            this.editDefault3.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocalImp, "Porta_Imp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault3.Enabled = false;
            this.editDefault3.Location = new System.Drawing.Point(63, 53);
            this.editDefault3.Name = "editDefault3";
            this.editDefault3.NM_Alias = "";
            this.editDefault3.NM_Campo = "";
            this.editDefault3.NM_CampoBusca = "";
            this.editDefault3.NM_Param = "";
            this.editDefault3.QTD_Zero = 0;
            this.editDefault3.Size = new System.Drawing.Size(271, 20);
            this.editDefault3.ST_AutoInc = false;
            this.editDefault3.ST_DisableAuto = false;
            this.editDefault3.ST_Float = false;
            this.editDefault3.ST_Gravar = true;
            this.editDefault3.ST_Int = false;
            this.editDefault3.ST_LimpaCampo = true;
            this.editDefault3.ST_NotNull = false;
            this.editDefault3.ST_PrimaryKey = false;
            this.editDefault3.TabIndex = 5;
            this.editDefault3.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Porta Imp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tipo";
            // 
            // comboBoxDefault1
            // 
            this.comboBoxDefault1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsLocalImp, "St_Imp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocalImp, "Status", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxDefault1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDefault1.Enabled = false;
            this.comboBoxDefault1.FormattingEnabled = true;
            this.comboBoxDefault1.Location = new System.Drawing.Point(63, 79);
            this.comboBoxDefault1.Name = "comboBoxDefault1";
            this.comboBoxDefault1.NM_Alias = "";
            this.comboBoxDefault1.NM_Campo = "";
            this.comboBoxDefault1.NM_Param = "";
            this.comboBoxDefault1.Size = new System.Drawing.Size(271, 21);
            this.comboBoxDefault1.ST_Gravar = true;
            this.comboBoxDefault1.ST_LimparCampo = true;
            this.comboBoxDefault1.ST_NotNull = false;
            this.comboBoxDefault1.TabIndex = 7;
            // 
            // FCadLocalImpressora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 395);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCadLocalImpressora";
            this.Text = "FCadLocalImpressora";
            this.Load += new System.EventHandler(this.FCadLocalImpressora_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCadLocalImpressora_KeyDown);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocalImp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDLocalImpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSLocalImpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portaImpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stImpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsLocalImp;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault editDefault1;
        private Componentes.EditDefault editDefault2;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault editDefault3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Componentes.ComboBoxDefault comboBoxDefault1;
    }
}