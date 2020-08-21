namespace Help
{
    partial class TFBoletosAliance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFBoletosAliance));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pTop = new Componentes.PanelDados(this.components);
            this.pFechar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsTitulo = new System.Windows.Forms.BindingSource(this.components);
            this.nmsacadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nossonumeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtemissaobloquetoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvencimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vldocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlatualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_imprimir = new System.Windows.Forms.Button();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pTop.Controls.Add(this.pFechar);
            this.pTop.Controls.Add(this.label1);
            this.pTop.ForeColor = System.Drawing.SystemColors.Control;
            this.pTop.Location = new System.Drawing.Point(4, 3);
            this.pTop.Name = "pTop";
            this.pTop.NM_ProcDeletar = "";
            this.pTop.NM_ProcGravar = "";
            this.pTop.Size = new System.Drawing.Size(977, 34);
            this.pTop.TabIndex = 2;
            // 
            // pFechar
            // 
            this.pFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pFechar.Image = ((System.Drawing.Image)(resources.GetObject("pFechar.Image")));
            this.pFechar.Location = new System.Drawing.Point(941, 3);
            this.pFechar.Name = "pFechar";
            this.pFechar.Size = new System.Drawing.Size(33, 29);
            this.pFechar.TabIndex = 1;
            this.pFechar.TabStop = false;
            this.pFechar.Click += new System.EventHandler(this.pFechar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(932, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "LISTAGEM BOLETOS EM ABERTO TECNOALIANCE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.bb_imprimir);
            this.panelDados1.Location = new System.Drawing.Point(4, 472);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(977, 57);
            this.panelDados1.TabIndex = 3;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.dataGridDefault1);
            this.panelDados2.Controls.Add(this.bindingNavigator1);
            this.panelDados2.Location = new System.Drawing.Point(4, 43);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(977, 423);
            this.panelDados2.TabIndex = 4;
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
            this.nmsacadoDataGridViewTextBoxColumn,
            this.nossonumeroDataGridViewTextBoxColumn,
            this.dtemissaobloquetoDataGridViewTextBoxColumn,
            this.dtvencimentoDataGridViewTextBoxColumn,
            this.vldocumentoDataGridViewTextBoxColumn,
            this.vlatualDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsTitulo;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.MultiSelect = false;
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDefault1.Size = new System.Drawing.Size(977, 398);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // bsTitulo
            // 
            this.bsTitulo.DataSource = typeof(CamadaDados.Financeiro.Bloqueto.blListaTitulo);
            // 
            // nmsacadoDataGridViewTextBoxColumn
            // 
            this.nmsacadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmsacadoDataGridViewTextBoxColumn.DataPropertyName = "Nm_sacado";
            this.nmsacadoDataGridViewTextBoxColumn.HeaderText = "Sacado";
            this.nmsacadoDataGridViewTextBoxColumn.Name = "nmsacadoDataGridViewTextBoxColumn";
            this.nmsacadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmsacadoDataGridViewTextBoxColumn.Width = 69;
            // 
            // nossonumeroDataGridViewTextBoxColumn
            // 
            this.nossonumeroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nossonumeroDataGridViewTextBoxColumn.DataPropertyName = "Nosso_numero";
            this.nossonumeroDataGridViewTextBoxColumn.HeaderText = "Nosso Numero";
            this.nossonumeroDataGridViewTextBoxColumn.Name = "nossonumeroDataGridViewTextBoxColumn";
            this.nossonumeroDataGridViewTextBoxColumn.ReadOnly = true;
            this.nossonumeroDataGridViewTextBoxColumn.Width = 102;
            // 
            // dtemissaobloquetoDataGridViewTextBoxColumn
            // 
            this.dtemissaobloquetoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaobloquetoDataGridViewTextBoxColumn.DataPropertyName = "Dt_emissaobloqueto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dtemissaobloquetoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtemissaobloquetoDataGridViewTextBoxColumn.HeaderText = "Emissão";
            this.dtemissaobloquetoDataGridViewTextBoxColumn.Name = "dtemissaobloquetoDataGridViewTextBoxColumn";
            this.dtemissaobloquetoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtemissaobloquetoDataGridViewTextBoxColumn.Width = 71;
            // 
            // dtvencimentoDataGridViewTextBoxColumn
            // 
            this.dtvencimentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvencimentoDataGridViewTextBoxColumn.DataPropertyName = "Dt_vencimento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.dtvencimentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtvencimentoDataGridViewTextBoxColumn.HeaderText = "Vencimento";
            this.dtvencimentoDataGridViewTextBoxColumn.Name = "dtvencimentoDataGridViewTextBoxColumn";
            this.dtvencimentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtvencimentoDataGridViewTextBoxColumn.Width = 88;
            // 
            // vldocumentoDataGridViewTextBoxColumn
            // 
            this.vldocumentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vldocumentoDataGridViewTextBoxColumn.DataPropertyName = "Vl_documento";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.vldocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.vldocumentoDataGridViewTextBoxColumn.HeaderText = "Vl. Nominal";
            this.vldocumentoDataGridViewTextBoxColumn.Name = "vldocumentoDataGridViewTextBoxColumn";
            this.vldocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vldocumentoDataGridViewTextBoxColumn.Width = 85;
            // 
            // vlatualDataGridViewTextBoxColumn
            // 
            this.vlatualDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlatualDataGridViewTextBoxColumn.DataPropertyName = "Vl_atual";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.vlatualDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.vlatualDataGridViewTextBoxColumn.HeaderText = "Vl. Atual";
            this.vlatualDataGridViewTextBoxColumn.Name = "vlatualDataGridViewTextBoxColumn";
            this.vlatualDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlatualDataGridViewTextBoxColumn.Width = 71;
            // 
            // bb_imprimir
            // 
            this.bb_imprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_imprimir.ForeColor = System.Drawing.Color.Green;
            this.bb_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("bb_imprimir.Image")));
            this.bb_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_imprimir.Location = new System.Drawing.Point(379, 4);
            this.bb_imprimir.Name = "bb_imprimir";
            this.bb_imprimir.Size = new System.Drawing.Size(184, 48);
            this.bb_imprimir.TabIndex = 1;
            this.bb_imprimir.Text = "(F8)\r\nImprimir Boleto";
            this.bb_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_imprimir.UseVisualStyleBackColor = true;
            this.bb_imprimir.Click += new System.EventHandler(this.bb_imprimir_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsTitulo;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 398);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(977, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // TFBoletosAliance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 533);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.pTop);
            this.Controls.Add(this.panelDados2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFBoletosAliance";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listagem Boletos em Aberto TecnoAliance";
            this.Load += new System.EventHandler(this.TFBoletosAliance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFBoletosAliance_KeyDown);
            this.pTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pFechar)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pTop;
        private System.Windows.Forms.PictureBox pFechar;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados panelDados1;
        private Componentes.PanelDados panelDados2;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmsacadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nossonumeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtemissaobloquetoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvencimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vldocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlatualDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsTitulo;
        private System.Windows.Forms.Button bb_imprimir;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
    }
}