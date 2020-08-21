namespace FormBusca
{
    partial class TFBuscarContasReferenciais
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFBuscarContasReferenciais));
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.ds_conta = new Componentes.EditDefault(this.components);
            this.pGrid = new Componentes.PanelDados(this.components);
            this.gPlanoReferencial = new Componentes.DataGridDefault(this.components);
            this.bsPlanoReferencial = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cdreferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocontaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naturezastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbSequencia = new System.Windows.Forms.ToolStripLabel();
            this.lbResultados = new System.Windows.Forms.ToolStripLabel();
            label2 = new System.Windows.Forms.Label();
            this.tlpCentral.SuspendLayout();
            this.panelDados2.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPlanoReferencial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanoReferencial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(23, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 13);
            label2.TabIndex = 63;
            label2.Text = "Conta:";
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.panelDados2, 0, 0);
            this.tlpCentral.Controls.Add(this.pGrid, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(974, 474);
            this.tlpCentral.TabIndex = 1;
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(label2);
            this.panelDados2.Controls.Add(this.ds_conta);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 3);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(968, 33);
            this.panelDados2.TabIndex = 1;
            // 
            // ds_conta
            // 
            this.ds_conta.BackColor = System.Drawing.Color.White;
            this.ds_conta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_conta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_conta.Location = new System.Drawing.Point(67, 6);
            this.ds_conta.Name = "ds_conta";
            this.ds_conta.NM_Alias = "";
            this.ds_conta.NM_Campo = "";
            this.ds_conta.NM_CampoBusca = "";
            this.ds_conta.NM_Param = "";
            this.ds_conta.QTD_Zero = 0;
            this.ds_conta.Size = new System.Drawing.Size(727, 20);
            this.ds_conta.ST_AutoInc = false;
            this.ds_conta.ST_DisableAuto = false;
            this.ds_conta.ST_Float = false;
            this.ds_conta.ST_Gravar = false;
            this.ds_conta.ST_Int = false;
            this.ds_conta.ST_LimpaCampo = true;
            this.ds_conta.ST_NotNull = false;
            this.ds_conta.ST_PrimaryKey = false;
            this.ds_conta.TabIndex = 0;
            this.ds_conta.TextOld = null;
            this.ds_conta.TextChanged += new System.EventHandler(this.ds_conta_TextChanged);
            // 
            // pGrid
            // 
            this.pGrid.Controls.Add(this.gPlanoReferencial);
            this.pGrid.Controls.Add(this.bindingNavigator1);
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid.Location = new System.Drawing.Point(3, 42);
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            this.pGrid.Size = new System.Drawing.Size(968, 429);
            this.pGrid.TabIndex = 2;
            // 
            // gPlanoReferencial
            // 
            this.gPlanoReferencial.AllowUserToAddRows = false;
            this.gPlanoReferencial.AllowUserToDeleteRows = false;
            this.gPlanoReferencial.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPlanoReferencial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gPlanoReferencial.AutoGenerateColumns = false;
            this.gPlanoReferencial.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPlanoReferencial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPlanoReferencial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPlanoReferencial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gPlanoReferencial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPlanoReferencial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdreferenciaDataGridViewTextBoxColumn,
            this.pNome,
            this.tipocontaDataGridViewTextBoxColumn,
            this.nivelDataGridViewTextBoxColumn,
            this.naturezastrDataGridViewTextBoxColumn});
            this.gPlanoReferencial.DataSource = this.bsPlanoReferencial;
            this.gPlanoReferencial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gPlanoReferencial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPlanoReferencial.Location = new System.Drawing.Point(0, 0);
            this.gPlanoReferencial.Name = "gPlanoReferencial";
            this.gPlanoReferencial.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPlanoReferencial.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gPlanoReferencial.RowHeadersWidth = 23;
            this.gPlanoReferencial.Size = new System.Drawing.Size(968, 404);
            this.gPlanoReferencial.TabIndex = 0;
            this.gPlanoReferencial.DoubleClick += new System.EventHandler(this.gPlanoReferencial_DoubleClick);
            this.gPlanoReferencial.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gPlanoReferencial_CellFormatting);
            // 
            // bsPlanoReferencial
            // 
            this.bsPlanoReferencial.DataSource = typeof(CamadaDados.Contabil.Cadastro.TList_PlanoReferencial);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
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
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator1,
            this.lbSequencia,
            this.lbResultados});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 404);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(968, 25);
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
            // cdreferenciaDataGridViewTextBoxColumn
            // 
            this.cdreferenciaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdreferenciaDataGridViewTextBoxColumn.DataPropertyName = "Cd_referencia";
            this.cdreferenciaDataGridViewTextBoxColumn.HeaderText = "Código";
            this.cdreferenciaDataGridViewTextBoxColumn.Name = "cdreferenciaDataGridViewTextBoxColumn";
            this.cdreferenciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdreferenciaDataGridViewTextBoxColumn.Width = 65;
            // 
            // pNome
            // 
            this.pNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pNome.DataPropertyName = "Nome";
            this.pNome.HeaderText = "Conta";
            this.pNome.Name = "pNome";
            this.pNome.ReadOnly = true;
            this.pNome.Width = 60;
            // 
            // tipocontaDataGridViewTextBoxColumn
            // 
            this.tipocontaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipocontaDataGridViewTextBoxColumn.DataPropertyName = "Tipo_conta";
            this.tipocontaDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipocontaDataGridViewTextBoxColumn.Name = "tipocontaDataGridViewTextBoxColumn";
            this.tipocontaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipocontaDataGridViewTextBoxColumn.Width = 53;
            // 
            // nivelDataGridViewTextBoxColumn
            // 
            this.nivelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nivelDataGridViewTextBoxColumn.DataPropertyName = "Nivel";
            this.nivelDataGridViewTextBoxColumn.HeaderText = "Nivel";
            this.nivelDataGridViewTextBoxColumn.Name = "nivelDataGridViewTextBoxColumn";
            this.nivelDataGridViewTextBoxColumn.ReadOnly = true;
            this.nivelDataGridViewTextBoxColumn.Width = 56;
            // 
            // naturezastrDataGridViewTextBoxColumn
            // 
            this.naturezastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.naturezastrDataGridViewTextBoxColumn.DataPropertyName = "Naturezastr";
            this.naturezastrDataGridViewTextBoxColumn.HeaderText = "Natureza";
            this.naturezastrDataGridViewTextBoxColumn.Name = "naturezastrDataGridViewTextBoxColumn";
            this.naturezastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.naturezastrDataGridViewTextBoxColumn.Width = 75;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lbSequencia
            // 
            this.lbSequencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbSequencia.ForeColor = System.Drawing.Color.Blue;
            this.lbSequencia.Name = "lbSequencia";
            this.lbSequencia.Size = new System.Drawing.Size(0, 22);
            // 
            // lbResultados
            // 
            this.lbResultados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbResultados.ForeColor = System.Drawing.Color.Blue;
            this.lbResultados.Name = "lbResultados";
            this.lbResultados.Size = new System.Drawing.Size(0, 22);
            // 
            // TFBuscarContasReferenciais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 474);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFBuscarContasReferenciais";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Contas Referenciais";
            this.Load += new System.EventHandler(this.TFBuscarContasReferenciais_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFBuscarContasReferenciais_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPlanoReferencial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanoReferencial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados2;
        private Componentes.EditDefault ds_conta;
        private Componentes.PanelDados pGrid;
        private Componentes.DataGridDefault gPlanoReferencial;
        private System.Windows.Forms.BindingSource bsPlanoReferencial;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdreferenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocontaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn naturezastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lbSequencia;
        private System.Windows.Forms.ToolStripLabel lbResultados;
    }
}