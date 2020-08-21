namespace Restaurante.Cadastro
{
    partial class FCadSabores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadSabores));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.iDSaborDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSSaborDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsSabores = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.CD_Grupo = new Componentes.EditDefault(this.components);
            this.LB_CD_Grupo = new System.Windows.Forms.Label();
            this.DS_Grupo = new Componentes.EditDefault(this.components);
            this.BB_GrupoProduto = new System.Windows.Forms.Button();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSabores)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.CD_Grupo);
            this.pDados.Controls.Add(this.LB_CD_Grupo);
            this.pDados.Controls.Add(this.DS_Grupo);
            this.pDados.Controls.Add(this.BB_GrupoProduto);
            this.pDados.Controls.Add(this.editDefault2);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Size = new System.Drawing.Size(361, 96);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(373, 272);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(365, 246);
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
            this.iDSaborDataGridViewTextBoxColumn,
            this.dSSaborDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridDefault1.DataSource = this.bsSabores;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 96);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(361, 146);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // iDSaborDataGridViewTextBoxColumn
            // 
            this.iDSaborDataGridViewTextBoxColumn.DataPropertyName = "ID_Sabor";
            this.iDSaborDataGridViewTextBoxColumn.HeaderText = "ID_Sabor";
            this.iDSaborDataGridViewTextBoxColumn.Name = "iDSaborDataGridViewTextBoxColumn";
            this.iDSaborDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSSaborDataGridViewTextBoxColumn
            // 
            this.dSSaborDataGridViewTextBoxColumn.DataPropertyName = "DS_Sabor";
            this.dSSaborDataGridViewTextBoxColumn.HeaderText = "DS_Sabor";
            this.dSSaborDataGridViewTextBoxColumn.Name = "dSSaborDataGridViewTextBoxColumn";
            this.dSSaborDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "cd_grupo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cd. Grupo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ds_grupo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Grupo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 61;
            // 
            // bsSabores
            // 
            this.bsSabores.DataSource = typeof(CamadaDados.Restaurante.Cadastro.TList_Sabores);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cd. Sabores";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSabores, "ID_Sabor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Location = new System.Drawing.Point(4, 24);
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
            this.editDefault1.ST_NotNull = true;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 1;
            this.editDefault1.TextOld = null;
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSabores, "DS_Sabor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Location = new System.Drawing.Point(119, 24);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "";
            this.editDefault2.NM_CampoBusca = "";
            this.editDefault2.NM_Param = "";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.Size = new System.Drawing.Size(234, 20);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sabores";
            // 
            // CD_Grupo
            // 
            this.CD_Grupo.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSabores, "cd_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Grupo.Location = new System.Drawing.Point(6, 63);
            this.CD_Grupo.Name = "CD_Grupo";
            this.CD_Grupo.NM_Alias = "a";
            this.CD_Grupo.NM_Campo = "CD_Grupo";
            this.CD_Grupo.NM_CampoBusca = "CD_Grupo";
            this.CD_Grupo.NM_Param = "@P_CD_GRUPO";
            this.CD_Grupo.QTD_Zero = 0;
            this.CD_Grupo.Size = new System.Drawing.Size(56, 20);
            this.CD_Grupo.ST_AutoInc = false;
            this.CD_Grupo.ST_DisableAuto = false;
            this.CD_Grupo.ST_Float = false;
            this.CD_Grupo.ST_Gravar = true;
            this.CD_Grupo.ST_Int = false;
            this.CD_Grupo.ST_LimpaCampo = true;
            this.CD_Grupo.ST_NotNull = true;
            this.CD_Grupo.ST_PrimaryKey = true;
            this.CD_Grupo.TabIndex = 894;
            this.CD_Grupo.TextOld = null;
            this.CD_Grupo.Leave += new System.EventHandler(this.CD_Grupo_Leave);
            // 
            // LB_CD_Grupo
            // 
            this.LB_CD_Grupo.AutoSize = true;
            this.LB_CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Grupo.Location = new System.Drawing.Point(-1, 47);
            this.LB_CD_Grupo.Name = "LB_CD_Grupo";
            this.LB_CD_Grupo.Size = new System.Drawing.Size(67, 13);
            this.LB_CD_Grupo.TabIndex = 897;
            this.LB_CD_Grupo.Text = "Grupo Prod.:";
            this.LB_CD_Grupo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DS_Grupo
            // 
            this.DS_Grupo.BackColor = System.Drawing.Color.White;
            this.DS_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSabores, "ds_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Grupo.Enabled = false;
            this.DS_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Grupo.Location = new System.Drawing.Point(101, 63);
            this.DS_Grupo.Name = "DS_Grupo";
            this.DS_Grupo.NM_Alias = "a";
            this.DS_Grupo.NM_Campo = "ds_grupo";
            this.DS_Grupo.NM_CampoBusca = "ds_grupo";
            this.DS_Grupo.NM_Param = "";
            this.DS_Grupo.QTD_Zero = 0;
            this.DS_Grupo.ReadOnly = true;
            this.DS_Grupo.Size = new System.Drawing.Size(252, 20);
            this.DS_Grupo.ST_AutoInc = false;
            this.DS_Grupo.ST_DisableAuto = false;
            this.DS_Grupo.ST_Float = false;
            this.DS_Grupo.ST_Gravar = false;
            this.DS_Grupo.ST_Int = false;
            this.DS_Grupo.ST_LimpaCampo = true;
            this.DS_Grupo.ST_NotNull = false;
            this.DS_Grupo.ST_PrimaryKey = false;
            this.DS_Grupo.TabIndex = 896;
            this.DS_Grupo.TextOld = null;
            // 
            // BB_GrupoProduto
            // 
            this.BB_GrupoProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_GrupoProduto.Image = ((System.Drawing.Image)(resources.GetObject("BB_GrupoProduto.Image")));
            this.BB_GrupoProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_GrupoProduto.Location = new System.Drawing.Point(66, 63);
            this.BB_GrupoProduto.Name = "BB_GrupoProduto";
            this.BB_GrupoProduto.Size = new System.Drawing.Size(30, 20);
            this.BB_GrupoProduto.TabIndex = 895;
            this.BB_GrupoProduto.UseVisualStyleBackColor = true;
            this.BB_GrupoProduto.Click += new System.EventHandler(this.BB_GrupoProduto_Click);
            // 
            // FCadSabores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 315);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCadSabores";
            this.Text = "Cadastro de sabores";
            this.Load += new System.EventHandler(this.FCadSabores_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSabores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsSabores;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault editDefault2;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault editDefault1;
        private Componentes.EditDefault CD_Grupo;
        private System.Windows.Forms.Label LB_CD_Grupo;
        private Componentes.EditDefault DS_Grupo;
        public System.Windows.Forms.Button BB_GrupoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDSaborDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSSaborDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}