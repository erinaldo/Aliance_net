namespace Restaurante.Cadastro
{
    partial class FCadLocal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadLocal));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.id_local = new Componentes.EditDefault(this.components);
            this.ds_local = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bsLocal = new System.Windows.Forms.BindingSource(this.components);
            this.idLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocal)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_local);
            this.pDados.Controls.Add(this.id_local);
            this.pDados.Size = new System.Drawing.Size(556, 61);
            this.pDados.Paint += new System.Windows.Forms.PaintEventHandler(this.pDados_Paint);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(568, 332);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(560, 306);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridDefault1.AutoGenerateColumns = false;
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
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idLocalDataGridViewTextBoxColumn,
            this.dsLocalDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsLocal;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 61);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(556, 241);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // id_local
            // 
            this.id_local.BackColor = System.Drawing.SystemColors.Window;
            this.id_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "Id_Local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_local.Enabled = false;
            this.id_local.Location = new System.Drawing.Point(56, 3);
            this.id_local.Name = "id_local";
            this.id_local.NM_Alias = "id_local";
            this.id_local.NM_Campo = "id_local";
            this.id_local.NM_CampoBusca = "id_local";
            this.id_local.NM_Param = "@P_ID_LOCAL";
            this.id_local.QTD_Zero = 0;
            this.id_local.Size = new System.Drawing.Size(97, 20);
            this.id_local.ST_AutoInc = false;
            this.id_local.ST_DisableAuto = false;
            this.id_local.ST_Float = false;
            this.id_local.ST_Gravar = true;
            this.id_local.ST_Int = false;
            this.id_local.ST_LimpaCampo = true;
            this.id_local.ST_NotNull = true;
            this.id_local.ST_PrimaryKey = true;
            this.id_local.TabIndex = 0;
            this.id_local.TextOld = null;
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "Ds_Local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_local.Enabled = false;
            this.ds_local.Location = new System.Drawing.Point(56, 30);
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "ds_local";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_DS_LOCAL";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.Size = new System.Drawing.Size(492, 20);
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = true;
            this.ds_local.ST_Int = false;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = true;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TabIndex = 1;
            this.ds_local.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Local:";
            // 
            // bsLocal
            // 
            this.bsLocal.DataSource = typeof(CamadaDados.Restaurante.Cadastro.TList_Local);
            // 
            // idLocalDataGridViewTextBoxColumn
            // 
            this.idLocalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idLocalDataGridViewTextBoxColumn.DataPropertyName = "Id_Local";
            this.idLocalDataGridViewTextBoxColumn.HeaderText = "Id. Local";
            this.idLocalDataGridViewTextBoxColumn.Name = "idLocalDataGridViewTextBoxColumn";
            this.idLocalDataGridViewTextBoxColumn.ReadOnly = true;
            this.idLocalDataGridViewTextBoxColumn.Width = 73;
            // 
            // dsLocalDataGridViewTextBoxColumn
            // 
            this.dsLocalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsLocalDataGridViewTextBoxColumn.DataPropertyName = "Ds_Local";
            this.dsLocalDataGridViewTextBoxColumn.HeaderText = "Local";
            this.dsLocalDataGridViewTextBoxColumn.Name = "dsLocalDataGridViewTextBoxColumn";
            this.dsLocalDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsLocalDataGridViewTextBoxColumn.Width = 58;
            // 
            // FCadLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 375);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCadLocal";
            this.Text = "Local";
            this.Load += new System.EventHandler(this.FCadLocal_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsLocal;
        private Componentes.EditDefault ds_local;
        private Componentes.EditDefault id_local;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsLocalDataGridViewTextBoxColumn;
    }
}