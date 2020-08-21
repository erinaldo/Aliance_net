namespace Commoditties.Cadastros
{
    partial class TFCad_Headge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Headge));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Id_Headge = new Componentes.EditFloat(this.components);
            this.DS_Headge = new Componentes.EditDefault(this.components);
            this.CB_TipoHeadge = new Componentes.ComboBoxDefault(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.BS_headge = new System.Windows.Forms.BindingSource(this.components);
            this.iDHeadgeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsHeadgeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpHeadgeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Id_Headge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_headge)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.CB_TipoHeadge);
            this.pDados.Controls.Add(this.DS_Headge);
            this.pDados.Controls.Add(this.Id_Headge);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Font = null;
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            this.tcCentral.Font = null;
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Id_Headge
            // 
            this.Id_Headge.AccessibleDescription = null;
            this.Id_Headge.AccessibleName = null;
            resources.ApplyResources(this.Id_Headge, "Id_Headge");
            this.Id_Headge.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_headge, "ID_Headge", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Id_Headge.Font = null;
            this.Id_Headge.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Id_Headge.Name = "Id_Headge";
            this.Id_Headge.NM_Alias = "";
            this.Id_Headge.NM_Campo = "";
            this.Id_Headge.NM_Param = "";
            this.Id_Headge.Operador = "";
            this.Id_Headge.ST_AutoInc = false;
            this.Id_Headge.ST_DisableAuto = false;
            this.Id_Headge.ST_Gravar = false;
            this.Id_Headge.ST_LimparCampo = true;
            this.Id_Headge.ST_NotNull = false;
            this.Id_Headge.ST_PrimaryKey = false;
            // 
            // DS_Headge
            // 
            this.DS_Headge.AccessibleDescription = null;
            this.DS_Headge.AccessibleName = null;
            resources.ApplyResources(this.DS_Headge, "DS_Headge");
            this.DS_Headge.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Headge.BackgroundImage = null;
            this.DS_Headge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Headge.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_headge, "Ds_Headge", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Headge.Font = null;
            this.DS_Headge.Name = "DS_Headge";
            this.DS_Headge.NM_Alias = "";
            this.DS_Headge.NM_Campo = "";
            this.DS_Headge.NM_CampoBusca = "";
            this.DS_Headge.NM_Param = "";
            this.DS_Headge.QTD_Zero = 0;
            this.DS_Headge.ST_AutoInc = false;
            this.DS_Headge.ST_DisableAuto = false;
            this.DS_Headge.ST_Float = false;
            this.DS_Headge.ST_Gravar = true;
            this.DS_Headge.ST_Int = false;
            this.DS_Headge.ST_LimpaCampo = true;
            this.DS_Headge.ST_NotNull = true;
            this.DS_Headge.ST_PrimaryKey = false;
            // 
            // CB_TipoHeadge
            // 
            this.CB_TipoHeadge.AccessibleDescription = null;
            this.CB_TipoHeadge.AccessibleName = null;
            resources.ApplyResources(this.CB_TipoHeadge, "CB_TipoHeadge");
            this.CB_TipoHeadge.BackgroundImage = null;
            this.CB_TipoHeadge.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_headge, "Tp_Headge", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CB_TipoHeadge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TipoHeadge.Font = null;
            this.CB_TipoHeadge.FormattingEnabled = true;
            this.CB_TipoHeadge.Name = "CB_TipoHeadge";
            this.CB_TipoHeadge.NM_Alias = "";
            this.CB_TipoHeadge.NM_Campo = "";
            this.CB_TipoHeadge.NM_Param = "";
            this.CB_TipoHeadge.ST_Gravar = true;
            this.CB_TipoHeadge.ST_LimparCampo = true;
            this.CB_TipoHeadge.ST_NotNull = true;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AccessibleDescription = null;
            this.dataGridDefault1.AccessibleName = null;
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridDefault1, "dataGridDefault1");
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BackgroundImage = null;
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
            this.iDHeadgeDataGridViewTextBoxColumn,
            this.dsHeadgeDataGridViewTextBoxColumn,
            this.tpHeadgeDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.BS_headge;
            this.dataGridDefault1.Font = null;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
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
            // 
            // BS_headge
            // 
            this.BS_headge.DataSource = typeof(CamadaDados.Graos.TList_CadHeadge);
            // 
            // iDHeadgeDataGridViewTextBoxColumn
            // 
            this.iDHeadgeDataGridViewTextBoxColumn.DataPropertyName = "ID_Headge";
            resources.ApplyResources(this.iDHeadgeDataGridViewTextBoxColumn, "iDHeadgeDataGridViewTextBoxColumn");
            this.iDHeadgeDataGridViewTextBoxColumn.Name = "iDHeadgeDataGridViewTextBoxColumn";
            this.iDHeadgeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsHeadgeDataGridViewTextBoxColumn
            // 
            this.dsHeadgeDataGridViewTextBoxColumn.DataPropertyName = "Ds_Headge";
            resources.ApplyResources(this.dsHeadgeDataGridViewTextBoxColumn, "dsHeadgeDataGridViewTextBoxColumn");
            this.dsHeadgeDataGridViewTextBoxColumn.Name = "dsHeadgeDataGridViewTextBoxColumn";
            this.dsHeadgeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpHeadgeDataGridViewTextBoxColumn
            // 
            this.tpHeadgeDataGridViewTextBoxColumn.DataPropertyName = "Tp_Headge";
            resources.ApplyResources(this.tpHeadgeDataGridViewTextBoxColumn, "tpHeadgeDataGridViewTextBoxColumn");
            this.tpHeadgeDataGridViewTextBoxColumn.Name = "tpHeadgeDataGridViewTextBoxColumn";
            this.tpHeadgeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCad_Headge
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCad_Headge";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Id_Headge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_headge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat Id_Headge;
        private Componentes.EditDefault DS_Headge;
        private Componentes.ComboBoxDefault CB_TipoHeadge;
        private System.Windows.Forms.BindingSource BS_headge;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDHeadgeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsHeadgeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpHeadgeDataGridViewTextBoxColumn;
    }
}