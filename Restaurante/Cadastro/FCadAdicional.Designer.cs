namespace Restaurante.Cadastro
{
    partial class FCadAdicional
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadAdicional));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.editDefault5 = new Componentes.EditDefault(this.components);
            this.editDefault6 = new Componentes.EditDefault(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.editDefault3 = new Componentes.EditDefault(this.components);
            this.editDefault4 = new Componentes.EditDefault(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.bsAdicionais = new System.Windows.Forms.BindingSource(this.components);
            this.cDGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAdicionais)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.editDefault3);
            this.pDados.Controls.Add(this.editDefault4);
            this.pDados.Controls.Add(this.button2);
            this.pDados.Controls.Add(this.editFloat1);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.editDefault2);
            this.pDados.Controls.Add(this.button1);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.editDefault5);
            this.pDados.Controls.Add(this.editDefault6);
            this.pDados.Controls.Add(this.button3);
            this.pDados.Size = new System.Drawing.Size(432, 106);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(444, 329);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(436, 303);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDGrupoDataGridViewTextBoxColumn,
            this.dSGrupoDataGridViewTextBoxColumn,
            this.cDProdutoDataGridViewTextBoxColumn,
            this.dSProdutoDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsAdicionais;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 106);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(432, 193);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 187;
            this.label9.Text = "Cd. Grupo Prod";
            // 
            // editDefault5
            // 
            this.editDefault5.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAdicionais, "CD_Grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault5.Enabled = false;
            this.editDefault5.Location = new System.Drawing.Point(104, 3);
            this.editDefault5.Name = "editDefault5";
            this.editDefault5.NM_Alias = "";
            this.editDefault5.NM_Campo = "CD_GRUPO";
            this.editDefault5.NM_CampoBusca = "CD_GRUPO";
            this.editDefault5.NM_Param = "@P_CD_GRUPO";
            this.editDefault5.QTD_Zero = 0;
            this.editDefault5.Size = new System.Drawing.Size(57, 20);
            this.editDefault5.ST_AutoInc = false;
            this.editDefault5.ST_DisableAuto = false;
            this.editDefault5.ST_Float = false;
            this.editDefault5.ST_Gravar = true;
            this.editDefault5.ST_Int = false;
            this.editDefault5.ST_LimpaCampo = true;
            this.editDefault5.ST_NotNull = true;
            this.editDefault5.ST_PrimaryKey = false;
            this.editDefault5.TabIndex = 184;
            this.editDefault5.TextOld = null;
            this.editDefault5.Leave += new System.EventHandler(this.editDefault5_Leave_1);
            // 
            // editDefault6
            // 
            this.editDefault6.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAdicionais, "DS_Grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault6.Enabled = false;
            this.editDefault6.Location = new System.Drawing.Point(193, 3);
            this.editDefault6.Name = "editDefault6";
            this.editDefault6.NM_Alias = "";
            this.editDefault6.NM_Campo = "DS_GRUPO";
            this.editDefault6.NM_CampoBusca = "DS_GRUPO";
            this.editDefault6.NM_Param = "@P_DS_GRUPO";
            this.editDefault6.QTD_Zero = 0;
            this.editDefault6.Size = new System.Drawing.Size(231, 20);
            this.editDefault6.ST_AutoInc = false;
            this.editDefault6.ST_DisableAuto = false;
            this.editDefault6.ST_Float = false;
            this.editDefault6.ST_Gravar = false;
            this.editDefault6.ST_Int = false;
            this.editDefault6.ST_LimpaCampo = true;
            this.editDefault6.ST_NotNull = false;
            this.editDefault6.ST_PrimaryKey = false;
            this.editDefault6.TabIndex = 186;
            this.editDefault6.TextOld = null;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(161, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 20);
            this.button3.TabIndex = 185;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 191;
            this.label1.Text = "Cd. Produto Adic.";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAdicionais, "CD_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(104, 28);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "CD_PRODUTO";
            this.editDefault1.NM_CampoBusca = "CD_PRODUTO";
            this.editDefault1.NM_Param = "@P_CD_PRODUTO";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(57, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = true;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 188;
            this.editDefault1.TextOld = null;
            this.editDefault1.Leave += new System.EventHandler(this.editDefault1_Leave);
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAdicionais, "DS_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Enabled = false;
            this.editDefault2.Location = new System.Drawing.Point(193, 28);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "DS_PRODUTO";
            this.editDefault2.NM_CampoBusca = "DS_PRODUTO";
            this.editDefault2.NM_Param = "@P_DS_PRODUTO";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.Size = new System.Drawing.Size(231, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = false;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = false;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 190;
            this.editDefault2.TextOld = null;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(162, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 20);
            this.button1.TabIndex = 189;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 193;
            this.label2.Text = "Quantidade";
            // 
            // editFloat1
            // 
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAdicionais, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat1.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat1.Location = new System.Drawing.Point(64, 78);
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.Size = new System.Drawing.Size(360, 20);
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = true;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = true;
            this.editFloat1.ST_PrimaryKey = false;
            this.editFloat1.TabIndex = 194;
            this.editFloat1.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 198;
            this.label3.Text = "Cd. Grupo Adic.";
            // 
            // editDefault3
            // 
            this.editDefault3.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAdicionais, "CD_Grupo_prod", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault3.Enabled = false;
            this.editDefault3.Location = new System.Drawing.Point(104, 53);
            this.editDefault3.Name = "editDefault3";
            this.editDefault3.NM_Alias = "";
            this.editDefault3.NM_Campo = "CD_GRUPO";
            this.editDefault3.NM_CampoBusca = "CD_GRUPO";
            this.editDefault3.NM_Param = "@P_CD_GRUPO";
            this.editDefault3.QTD_Zero = 0;
            this.editDefault3.Size = new System.Drawing.Size(57, 20);
            this.editDefault3.ST_AutoInc = false;
            this.editDefault3.ST_DisableAuto = false;
            this.editDefault3.ST_Float = false;
            this.editDefault3.ST_Gravar = true;
            this.editDefault3.ST_Int = false;
            this.editDefault3.ST_LimpaCampo = true;
            this.editDefault3.ST_NotNull = false;
            this.editDefault3.ST_PrimaryKey = false;
            this.editDefault3.TabIndex = 195;
            this.editDefault3.TextOld = null;
            this.editDefault3.Leave += new System.EventHandler(this.editDefault3_Leave);
            // 
            // editDefault4
            // 
            this.editDefault4.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAdicionais, "DS_Grupo_prod", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault4.Enabled = false;
            this.editDefault4.Location = new System.Drawing.Point(193, 53);
            this.editDefault4.Name = "editDefault4";
            this.editDefault4.NM_Alias = "";
            this.editDefault4.NM_Campo = "DS_GRUPO";
            this.editDefault4.NM_CampoBusca = "DS_GRUPO";
            this.editDefault4.NM_Param = "@P_DS_GRUPO";
            this.editDefault4.QTD_Zero = 0;
            this.editDefault4.Size = new System.Drawing.Size(232, 20);
            this.editDefault4.ST_AutoInc = false;
            this.editDefault4.ST_DisableAuto = false;
            this.editDefault4.ST_Float = false;
            this.editDefault4.ST_Gravar = false;
            this.editDefault4.ST_Int = false;
            this.editDefault4.ST_LimpaCampo = true;
            this.editDefault4.ST_NotNull = false;
            this.editDefault4.ST_PrimaryKey = false;
            this.editDefault4.TabIndex = 197;
            this.editDefault4.TextOld = null;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(162, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 20);
            this.button2.TabIndex = 196;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bsAdicionais
            // 
            this.bsAdicionais.DataSource = typeof(CamadaDados.Restaurante.Cadastro.TList_Adicionais);
            // 
            // cDGrupoDataGridViewTextBoxColumn
            // 
            this.cDGrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDGrupoDataGridViewTextBoxColumn.DataPropertyName = "CD_Grupo";
            this.cDGrupoDataGridViewTextBoxColumn.HeaderText = "Cd. Grupo";
            this.cDGrupoDataGridViewTextBoxColumn.Name = "cDGrupoDataGridViewTextBoxColumn";
            this.cDGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDGrupoDataGridViewTextBoxColumn.Width = 80;
            // 
            // dSGrupoDataGridViewTextBoxColumn
            // 
            this.dSGrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.dSGrupoDataGridViewTextBoxColumn.DataPropertyName = "DS_Grupo";
            this.dSGrupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.dSGrupoDataGridViewTextBoxColumn.Name = "dSGrupoDataGridViewTextBoxColumn";
            this.dSGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSGrupoDataGridViewTextBoxColumn.Width = 5;
            // 
            // cDProdutoDataGridViewTextBoxColumn
            // 
            this.cDProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDProdutoDataGridViewTextBoxColumn.DataPropertyName = "CD_Produto";
            this.cDProdutoDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cDProdutoDataGridViewTextBoxColumn.Name = "cDProdutoDataGridViewTextBoxColumn";
            this.cDProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDProdutoDataGridViewTextBoxColumn.Width = 88;
            // 
            // dSProdutoDataGridViewTextBoxColumn
            // 
            this.dSProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSProdutoDataGridViewTextBoxColumn.DataPropertyName = "DS_Produto";
            this.dSProdutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dSProdutoDataGridViewTextBoxColumn.Name = "dSProdutoDataGridViewTextBoxColumn";
            this.dSProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSProdutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantidadeDataGridViewTextBoxColumn.Width = 87;
            // 
            // FCadAdicional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 372);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCadAdicional";
            this.Text = "Cadastro de Adicionais";
            this.Load += new System.EventHandler(this.FCadAdicional_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAdicionais)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsAdicionais;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault editDefault5;
        private Componentes.EditDefault editDefault6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault editDefault1;
        private Componentes.EditDefault editDefault2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat editFloat1;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault editDefault3;
        private Componentes.EditDefault editDefault4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
    }
}