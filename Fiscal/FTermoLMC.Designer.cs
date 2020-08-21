namespace Fiscal
{
    partial class TFTermoLMC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTermoLMC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.nr_ordem = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblQtPaginas = new System.Windows.Forms.Label();
            this.qt_paginas = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dt_referencia = new System.Windows.Forms.DateTimePicker();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.bsProduto = new System.Windows.Forms.BindingSource(this.components);
            this.gProduto = new Componentes.DataGridDefault(this.components);
            this.stprocessarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dSProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nr_ordem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_paginas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(540, 43);
            this.barraMenu.TabIndex = 19;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(102, 40);
            this.BB_Gravar.Text = " (F4)\r\n Confirmar";
            this.BB_Gravar.ToolTipText = "Confirmar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.gProduto);
            this.pDados.Controls.Add(this.nr_ordem);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.lblQtPaginas);
            this.pDados.Controls.Add(this.qt_paginas);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.dt_referencia);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(540, 220);
            this.pDados.TabIndex = 20;
            // 
            // nr_ordem
            // 
            this.nr_ordem.Location = new System.Drawing.Point(451, 5);
            this.nr_ordem.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.nr_ordem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nr_ordem.Name = "nr_ordem";
            this.nr_ordem.NM_Alias = "";
            this.nr_ordem.NM_Campo = "";
            this.nr_ordem.NM_Param = "";
            this.nr_ordem.Operador = "";
            this.nr_ordem.Size = new System.Drawing.Size(67, 20);
            this.nr_ordem.ST_AutoInc = false;
            this.nr_ordem.ST_DisableAuto = false;
            this.nr_ordem.ST_Gravar = false;
            this.nr_ordem.ST_LimparCampo = true;
            this.nr_ordem.ST_NotNull = false;
            this.nr_ordem.ST_PrimaryKey = false;
            this.nr_ordem.TabIndex = 2;
            this.nr_ordem.ThousandsSeparator = true;
            this.nr_ordem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(389, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 164;
            this.label3.Text = "Nº Ordem:";
            // 
            // lblQtPaginas
            // 
            this.lblQtPaginas.AutoSize = true;
            this.lblQtPaginas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblQtPaginas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQtPaginas.Location = new System.Drawing.Point(202, 8);
            this.lblQtPaginas.Name = "lblQtPaginas";
            this.lblQtPaginas.Size = new System.Drawing.Size(74, 13);
            this.lblQtPaginas.TabIndex = 163;
            this.lblQtPaginas.Text = "Qtde Paginas:";
            // 
            // qt_paginas
            // 
            this.qt_paginas.Location = new System.Drawing.Point(282, 6);
            this.qt_paginas.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.qt_paginas.Name = "qt_paginas";
            this.qt_paginas.NM_Alias = "";
            this.qt_paginas.NM_Campo = "";
            this.qt_paginas.NM_Param = "";
            this.qt_paginas.Operador = "";
            this.qt_paginas.Size = new System.Drawing.Size(101, 20);
            this.qt_paginas.ST_AutoInc = false;
            this.qt_paginas.ST_DisableAuto = false;
            this.qt_paginas.ST_Gravar = false;
            this.qt_paginas.ST_LimparCampo = true;
            this.qt_paginas.ST_NotNull = false;
            this.qt_paginas.ST_PrimaryKey = false;
            this.qt_paginas.TabIndex = 1;
            this.qt_paginas.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 161;
            this.label1.Text = "Dt. Referência:";
            // 
            // dt_referencia
            // 
            this.dt_referencia.CustomFormat = "MM/yyyy";
            this.dt_referencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_referencia.Location = new System.Drawing.Point(92, 6);
            this.dt_referencia.Name = "dt_referencia";
            this.dt_referencia.Size = new System.Drawing.Size(104, 20);
            this.dt_referencia.TabIndex = 0;
            this.dt_referencia.ValueChanged += new System.EventHandler(this.dt_referencia_ValueChanged);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Location = new System.Drawing.Point(202, 31);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(316, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 156;
            this.NM_Empresa.TextOld = null;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(166, 31);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(30, 20);
            this.BB_Empresa.TabIndex = 4;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Location = new System.Drawing.Point(92, 32);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(73, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = false;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 3;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(35, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 157;
            this.label8.Text = "Empresa:";
            // 
            // bsProduto
            // 
            this.bsProduto.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadProduto);
            // 
            // gProduto
            // 
            this.gProduto.AllowUserToAddRows = false;
            this.gProduto.AllowUserToDeleteRows = false;
            this.gProduto.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gProduto.AutoGenerateColumns = false;
            this.gProduto.BackgroundColor = System.Drawing.Color.LightGray;
            this.gProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gProduto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProduto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stprocessarDataGridViewCheckBoxColumn,
            this.dSProdutoDataGridViewTextBoxColumn});
            this.gProduto.DataSource = this.bsProduto;
            this.gProduto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gProduto.Location = new System.Drawing.Point(92, 58);
            this.gProduto.Name = "gProduto";
            this.gProduto.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProduto.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gProduto.RowHeadersWidth = 23;
            this.gProduto.Size = new System.Drawing.Size(426, 148);
            this.gProduto.TabIndex = 5;
            this.gProduto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gProduto_CellClick);
            // 
            // stprocessarDataGridViewCheckBoxColumn
            // 
            this.stprocessarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stprocessarDataGridViewCheckBoxColumn.DataPropertyName = "St_processar";
            this.stprocessarDataGridViewCheckBoxColumn.HeaderText = "Marcar";
            this.stprocessarDataGridViewCheckBoxColumn.Name = "stprocessarDataGridViewCheckBoxColumn";
            this.stprocessarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stprocessarDataGridViewCheckBoxColumn.Width = 46;
            // 
            // dSProdutoDataGridViewTextBoxColumn
            // 
            this.dSProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSProdutoDataGridViewTextBoxColumn.DataPropertyName = "DS_Produto";
            this.dSProdutoDataGridViewTextBoxColumn.HeaderText = "Combustivel";
            this.dSProdutoDataGridViewTextBoxColumn.Name = "dSProdutoDataGridViewTextBoxColumn";
            this.dSProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSProdutoDataGridViewTextBoxColumn.Width = 89;
            // 
            // TFTermoLMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 263);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFTermoLMC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Termo Abertura/Encerramento LMC";
            this.Load += new System.EventHandler(this.TFTermoLMC_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFTermoLMC_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nr_ordem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_paginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_referencia;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblQtPaginas;
        private Componentes.EditFloat qt_paginas;
        private Componentes.EditFloat nr_ordem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bsProduto;
        private Componentes.DataGridDefault gProduto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSProdutoDataGridViewTextBoxColumn;
    }
}