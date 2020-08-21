namespace PostoCombustivel
{
    partial class TFEmpConcedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFEmpConcedido));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_motorista = new System.Windows.Forms.Button();
            this.nm_motorista = new Componentes.EditDefault(this.components);
            this.bsEmprestimo = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.placa = new Componentes.EditMask(this.components);
            this.vl_documento = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.gParcelas = new Componentes.DataGridDefault(this.components);
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmprestimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gParcelas)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(592, 43);
            this.barraMenu.TabIndex = 13;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.bb_motorista);
            this.pDados.Controls.Add(this.nm_motorista);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.placa);
            this.pDados.Controls.Add(this.vl_documento);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.nm_clifor);
            this.pDados.Controls.Add(this.bb_clifor);
            this.pDados.Controls.Add(this.cd_clifor);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(592, 123);
            this.pDados.TabIndex = 14;
            // 
            // bb_motorista
            // 
            this.bb_motorista.Image = ((System.Drawing.Image)(resources.GetObject("bb_motorista.Image")));
            this.bb_motorista.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_motorista.Location = new System.Drawing.Point(559, 96);
            this.bb_motorista.Name = "bb_motorista";
            this.bb_motorista.Size = new System.Drawing.Size(28, 21);
            this.bb_motorista.TabIndex = 5;
            this.bb_motorista.UseVisualStyleBackColor = true;
            this.bb_motorista.Click += new System.EventHandler(this.bb_motorista_Click);
            // 
            // nm_motorista
            // 
            this.nm_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.nm_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_motorista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Nm_motorista", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_motorista.Location = new System.Drawing.Point(199, 97);
            this.nm_motorista.Name = "nm_motorista";
            this.nm_motorista.NM_Alias = "";
            this.nm_motorista.NM_Campo = "nm_clifor";
            this.nm_motorista.NM_CampoBusca = "nm_clifor";
            this.nm_motorista.NM_Param = "@P_NM_CLIFOR";
            this.nm_motorista.QTD_Zero = 0;
            this.nm_motorista.Size = new System.Drawing.Size(359, 20);
            this.nm_motorista.ST_AutoInc = false;
            this.nm_motorista.ST_DisableAuto = false;
            this.nm_motorista.ST_Float = false;
            this.nm_motorista.ST_Gravar = false;
            this.nm_motorista.ST_Int = false;
            this.nm_motorista.ST_LimpaCampo = true;
            this.nm_motorista.ST_NotNull = false;
            this.nm_motorista.ST_PrimaryKey = false;
            this.nm_motorista.TabIndex = 4;
            this.nm_motorista.TextOld = null;
            // 
            // bsEmprestimo
            // 
            this.bsEmprestimo.DataSource = typeof(CamadaDados.Faturamento.PDV.TList_EmprestimoConcedido);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 449;
            this.label4.Text = "Motorista";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 448;
            this.label3.Text = "Placa";
            // 
            // placa
            // 
            this.placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Placa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.placa.Location = new System.Drawing.Point(133, 97);
            this.placa.Mask = "AAA-AAAA";
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "";
            this.placa.NM_CampoBusca = "";
            this.placa.NM_Param = "";
            this.placa.Size = new System.Drawing.Size(60, 20);
            this.placa.ST_Gravar = true;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = true;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 3;
            this.placa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.placa_KeyPress);
            // 
            // vl_documento
            // 
            this.vl_documento.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEmprestimo, "Vl_emprestimo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_documento.DecimalPlaces = 2;
            this.vl_documento.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_documento.Location = new System.Drawing.Point(7, 97);
            this.vl_documento.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_documento.Name = "vl_documento";
            this.vl_documento.NM_Alias = "";
            this.vl_documento.NM_Campo = "";
            this.vl_documento.NM_Param = "";
            this.vl_documento.Operador = "";
            this.vl_documento.Size = new System.Drawing.Size(120, 20);
            this.vl_documento.ST_AutoInc = false;
            this.vl_documento.ST_DisableAuto = false;
            this.vl_documento.ST_Gravar = true;
            this.vl_documento.ST_LimparCampo = true;
            this.vl_documento.ST_NotNull = true;
            this.vl_documento.ST_PrimaryKey = false;
            this.vl_documento.TabIndex = 2;
            this.vl_documento.ThousandsSeparator = true;
            this.vl_documento.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 445;
            this.label6.Text = "Valor Emprestimo";
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Nm_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_clifor.Location = new System.Drawing.Point(115, 58);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_NM_EMPRESA";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.ReadOnly = true;
            this.nm_clifor.Size = new System.Drawing.Size(472, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 423;
            this.nm_clifor.TextOld = null;
            // 
            // bb_clifor
            // 
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(84, 58);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(28, 19);
            this.bb_clifor.TabIndex = 1;
            this.bb_clifor.UseVisualStyleBackColor = true;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_clifor.Location = new System.Drawing.Point(7, 58);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_EMPRESA";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(75, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = true;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = true;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 0;
            this.cd_clifor.TextOld = null;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cliente";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(58, 19);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "";
            this.nm_empresa.NM_CampoBusca = "";
            this.nm_empresa.NM_Param = "";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(529, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 1;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(7, 19);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "";
            this.cd_empresa.NM_CampoBusca = "";
            this.cd_empresa.NM_Param = "";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(45, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa";
            // 
            // gParcelas
            // 
            this.gParcelas.AllowUserToAddRows = false;
            this.gParcelas.AllowUserToDeleteRows = false;
            this.gParcelas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gParcelas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gParcelas.AutoGenerateColumns = false;
            this.gParcelas.BackgroundColor = System.Drawing.Color.LightGray;
            this.gParcelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gParcelas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gParcelas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gParcelas.ColumnHeadersHeight = 22;
            this.gParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.gParcelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gParcelas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gParcelas.Location = new System.Drawing.Point(0, 0);
            this.gParcelas.Name = "gParcelas";
            this.gParcelas.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gParcelas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gParcelas.RowHeadersWidth = 23;
            this.gParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gParcelas.Size = new System.Drawing.Size(366, 140);
            this.gParcelas.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Vl_parcela";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "Vl. Parcela";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 83;
            // 
            // TFEmpConcedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 166);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFEmpConcedido";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emprestimo Concedido";
            this.Load += new System.EventHandler(this.TFEmpConcedido_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFEmpConcedido_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmprestimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gParcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nm_clifor;
        private System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault cd_clifor;
        private Componentes.EditFloat vl_documento;
        private System.Windows.Forms.Label label6;
        private Componentes.DataGridDefault gParcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label3;
        private Componentes.EditMask placa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_motorista;
        private Componentes.EditDefault nm_motorista;
        private System.Windows.Forms.BindingSource bsEmprestimo;
    }
}