namespace Estoque.Cadastros
{
    partial class TFCad_Genero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Genero));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.id_Genero = new Componentes.EditDefault(this.components);
            this.ds_Genero = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bs_CadGenero = new System.Windows.Forms.BindingSource(this.components);
            this.idgeneroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsgeneroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_CadGenero)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_Genero);
            this.pDados.Controls.Add(this.id_Genero);
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
            // id_Genero
            // 
            this.id_Genero.AccessibleDescription = null;
            this.id_Genero.AccessibleName = null;
            resources.ApplyResources(this.id_Genero, "id_Genero");
            this.id_Genero.BackColor = System.Drawing.SystemColors.Window;
            this.id_Genero.BackgroundImage = null;
            this.id_Genero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_Genero.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadGenero, "Id_generoString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_Genero.Font = null;
            this.id_Genero.Name = "id_Genero";
            this.id_Genero.NM_Alias = "a";
            this.id_Genero.NM_Campo = "id_genero";
            this.id_Genero.NM_CampoBusca = "id_genero";
            this.id_Genero.NM_Param = "@P_ID_GENERO";
            this.id_Genero.QTD_Zero = 0;
            this.id_Genero.ST_AutoInc = false;
            this.id_Genero.ST_DisableAuto = true;
            this.id_Genero.ST_Float = false;
            this.id_Genero.ST_Gravar = true;
            this.id_Genero.ST_Int = true;
            this.id_Genero.ST_LimpaCampo = true;
            this.id_Genero.ST_NotNull = true;
            this.id_Genero.ST_PrimaryKey = true;
            // 
            // ds_Genero
            // 
            this.ds_Genero.AccessibleDescription = null;
            this.ds_Genero.AccessibleName = null;
            resources.ApplyResources(this.ds_Genero, "ds_Genero");
            this.ds_Genero.BackColor = System.Drawing.SystemColors.Window;
            this.ds_Genero.BackgroundImage = null;
            this.ds_Genero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_Genero.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadGenero, "ds_genero", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_Genero.Font = null;
            this.ds_Genero.Name = "ds_Genero";
            this.ds_Genero.NM_Alias = "a";
            this.ds_Genero.NM_Campo = "ds_genero";
            this.ds_Genero.NM_CampoBusca = "ds_genero";
            this.ds_Genero.NM_Param = "@P_DS_GENERO";
            this.ds_Genero.QTD_Zero = 0;
            this.ds_Genero.ST_AutoInc = false;
            this.ds_Genero.ST_DisableAuto = false;
            this.ds_Genero.ST_Float = false;
            this.ds_Genero.ST_Gravar = true;
            this.ds_Genero.ST_Int = false;
            this.ds_Genero.ST_LimpaCampo = true;
            this.ds_Genero.ST_NotNull = false;
            this.ds_Genero.ST_PrimaryKey = false;
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
            this.idgeneroDataGridViewTextBoxColumn,
            this.dsgeneroDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bs_CadGenero;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDefault1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault1.Font = null;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            // 
            // bs_CadGenero
            // 
            this.bs_CadGenero.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_Cad_Genero);
            // 
            // idgeneroDataGridViewTextBoxColumn
            // 
            this.idgeneroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idgeneroDataGridViewTextBoxColumn.DataPropertyName = "Id_genero";
            resources.ApplyResources(this.idgeneroDataGridViewTextBoxColumn, "idgeneroDataGridViewTextBoxColumn");
            this.idgeneroDataGridViewTextBoxColumn.Name = "idgeneroDataGridViewTextBoxColumn";
            this.idgeneroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsgeneroDataGridViewTextBoxColumn
            // 
            this.dsgeneroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsgeneroDataGridViewTextBoxColumn.DataPropertyName = "ds_genero";
            resources.ApplyResources(this.dsgeneroDataGridViewTextBoxColumn, "dsgeneroDataGridViewTextBoxColumn");
            this.dsgeneroDataGridViewTextBoxColumn.Name = "dsgeneroDataGridViewTextBoxColumn";
            this.dsgeneroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCad_Genero
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCad_Genero";
            this.Load += new System.EventHandler(this.TFCad_Genero_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_CadGenero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault id_Genero;
        private Componentes.EditDefault ds_Genero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bs_CadGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn idgeneroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsgeneroDataGridViewTextBoxColumn;
    }
}
