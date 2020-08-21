namespace Empreendimento
{
    partial class FListMaoDeObra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FListMaoDeObra));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.idcargostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtd_executada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd_horas150 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd_exec_150 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdhorascenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtd_exec_100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdhorascincoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtd_exec_50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdadNoturnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtd_exec_20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsMaoObra = new System.Windows.Forms.BindingSource(this.components);
            this.bsOrcamento = new System.Windows.Forms.BindingSource(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMaoObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrcamento)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_cancelar,
            this.toolStripSeparator1});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1153, 43);
            this.barraMenu.TabIndex = 12;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
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
            this.idcargostrDataGridViewTextBoxColumn,
            this.dscargoDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.qtd_executada,
            this.Qtd_horas150,
            this.Qtd_exec_150,
            this.qtdhorascenDataGridViewTextBoxColumn,
            this.qtd_exec_100,
            this.qtdhorascincoDataGridViewTextBoxColumn,
            this.qtd_exec_50,
            this.qtdadNoturnoDataGridViewTextBoxColumn,
            this.qtd_exec_20});
            this.dataGridDefault1.DataSource = this.bsMaoObra;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 58);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(1153, 385);
            this.dataGridDefault1.TabIndex = 13;
            this.dataGridDefault1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDefault1_CellContentClick);
            this.dataGridDefault1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDefault1_CellDoubleClick);
            // 
            // idcargostrDataGridViewTextBoxColumn
            // 
            this.idcargostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idcargostrDataGridViewTextBoxColumn.DataPropertyName = "Id_cargostr";
            this.idcargostrDataGridViewTextBoxColumn.HeaderText = "Id. Cargo";
            this.idcargostrDataGridViewTextBoxColumn.Name = "idcargostrDataGridViewTextBoxColumn";
            this.idcargostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idcargostrDataGridViewTextBoxColumn.Width = 75;
            // 
            // dscargoDataGridViewTextBoxColumn
            // 
            this.dscargoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscargoDataGridViewTextBoxColumn.DataPropertyName = "ds_cargo";
            this.dscargoDataGridViewTextBoxColumn.HeaderText = "Cargo";
            this.dscargoDataGridViewTextBoxColumn.Name = "dscargoDataGridViewTextBoxColumn";
            this.dscargoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscargoDataGridViewTextBoxColumn.Width = 60;
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
            // qtd_executada
            // 
            this.qtd_executada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtd_executada.DataPropertyName = "qtd_executada";
            this.qtd_executada.HeaderText = "Quantidade executada";
            this.qtd_executada.Name = "qtd_executada";
            this.qtd_executada.ReadOnly = true;
            this.qtd_executada.Width = 128;
            // 
            // Qtd_horas150
            // 
            this.Qtd_horas150.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Qtd_horas150.DataPropertyName = "Qtd_horas150";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.Qtd_horas150.DefaultCellStyle = dataGridViewCellStyle3;
            this.Qtd_horas150.HeaderText = "Quantidade 150%";
            this.Qtd_horas150.Name = "Qtd_horas150";
            this.Qtd_horas150.ReadOnly = true;
            this.Qtd_horas150.Width = 106;
            // 
            // Qtd_exec_150
            // 
            this.Qtd_exec_150.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Qtd_exec_150.DataPropertyName = "Qtd_exec_150";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.Qtd_exec_150.DefaultCellStyle = dataGridViewCellStyle4;
            this.Qtd_exec_150.HeaderText = "Quantidade exec. 150%";
            this.Qtd_exec_150.Name = "Qtd_exec_150";
            this.Qtd_exec_150.ReadOnly = true;
            this.Qtd_exec_150.Width = 109;
            // 
            // qtdhorascenDataGridViewTextBoxColumn
            // 
            this.qtdhorascenDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdhorascenDataGridViewTextBoxColumn.DataPropertyName = "qtd_horascen";
            this.qtdhorascenDataGridViewTextBoxColumn.HeaderText = "Quantidade 100%";
            this.qtdhorascenDataGridViewTextBoxColumn.Name = "qtdhorascenDataGridViewTextBoxColumn";
            this.qtdhorascenDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtdhorascenDataGridViewTextBoxColumn.Width = 106;
            // 
            // qtd_exec_100
            // 
            this.qtd_exec_100.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtd_exec_100.DataPropertyName = "qtd_exec_100";
            this.qtd_exec_100.HeaderText = "Quantidade exe. 100%";
            this.qtd_exec_100.Name = "qtd_exec_100";
            this.qtd_exec_100.ReadOnly = true;
            this.qtd_exec_100.Width = 104;
            // 
            // qtdhorascincoDataGridViewTextBoxColumn
            // 
            this.qtdhorascincoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdhorascincoDataGridViewTextBoxColumn.DataPropertyName = "qtd_horascinco";
            this.qtdhorascincoDataGridViewTextBoxColumn.HeaderText = "Quantidade 50%";
            this.qtdhorascincoDataGridViewTextBoxColumn.Name = "qtdhorascincoDataGridViewTextBoxColumn";
            this.qtdhorascincoDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtdhorascincoDataGridViewTextBoxColumn.Width = 101;
            // 
            // qtd_exec_50
            // 
            this.qtd_exec_50.DataPropertyName = "qtd_exec_50";
            this.qtd_exec_50.HeaderText = "Quantidade exec. 50%";
            this.qtd_exec_50.Name = "qtd_exec_50";
            this.qtd_exec_50.ReadOnly = true;
            // 
            // qtdadNoturnoDataGridViewTextBoxColumn
            // 
            this.qtdadNoturnoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdadNoturnoDataGridViewTextBoxColumn.DataPropertyName = "qtd_adNoturno";
            this.qtdadNoturnoDataGridViewTextBoxColumn.HeaderText = "Quantidade Ad. Noturno";
            this.qtdadNoturnoDataGridViewTextBoxColumn.Name = "qtdadNoturnoDataGridViewTextBoxColumn";
            this.qtdadNoturnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtd_exec_20
            // 
            this.qtd_exec_20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtd_exec_20.DataPropertyName = "qtd_exec_20";
            this.qtd_exec_20.HeaderText = "Quantidade Ad. Noturno exec.";
            this.qtd_exec_20.Name = "qtd_exec_20";
            this.qtd_exec_20.ReadOnly = true;
            this.qtd_exec_20.Width = 137;
            // 
            // bsMaoObra
            // 
            this.bsMaoObra.DataMember = "lMaoObra";
            this.bsMaoObra.DataSource = this.bsOrcamento;
            // 
            // bsOrcamento
            // 
            this.bsOrcamento.DataSource = typeof(CamadaDados.Empreendimento.TList_Orcamento);
            this.bsOrcamento.PositionChanged += new System.EventHandler(this.bsOrcamento_PositionChanged);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Silver;
            this.label21.Dock = System.Windows.Forms.DockStyle.Top;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(0, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(1153, 15);
            this.label21.TabIndex = 18;
            this.label21.Text = "MÃO DE OBRA (DUPLO CLICK EXECUTAR)";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FListMaoDeObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 443);
            this.Controls.Add(this.dataGridDefault1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FListMaoDeObra";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mão de obra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FListMaoDeObra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FListMaoDeObra_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMaoObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrcamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsOrcamento;
        private System.Windows.Forms.BindingSource bsMaoObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcargostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtd_executada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd_horas150;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd_exec_150;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdhorascenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtd_exec_100;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdhorascincoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtd_exec_50;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdadNoturnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtd_exec_20;
        private System.Windows.Forms.Label label21;
    }
}