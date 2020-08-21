namespace Parametros.Diversos
{
    partial class TFCfgAudit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCfgAudit));
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.gTrigger = new Componentes.DataGridDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.lbTabelas = new System.Windows.Forms.ListBox();
            this.lblTabelas = new System.Windows.Forms.Label();
            this.bsTrigger = new System.Windows.Forms.BindingSource(this.components);
            this.TS_Endereco = new System.Windows.Forms.ToolStrip();
            this.bb_buscartrigger = new System.Windows.Forms.ToolStripButton();
            this.bb_ativar = new System.Windows.Forms.ToolStripButton();
            this.bb_desativar = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.nmtriggerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tlpCentral.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTrigger)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrigger)).BeginInit();
            this.TS_Endereco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 2;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.panelDados2, 1, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(1013, 532);
            this.tlpCentral.TabIndex = 0;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.gTrigger);
            this.panelDados2.Controls.Add(this.bindingNavigator1);
            this.panelDados2.Controls.Add(this.TS_Endereco);
            this.panelDados2.Controls.Add(this.label1);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(249, 3);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(761, 526);
            this.panelDados2.TabIndex = 0;
            // 
            // gTrigger
            // 
            this.gTrigger.AllowUserToAddRows = false;
            this.gTrigger.AllowUserToDeleteRows = false;
            this.gTrigger.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTrigger.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gTrigger.AutoGenerateColumns = false;
            this.gTrigger.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTrigger.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTrigger.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTrigger.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gTrigger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTrigger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nmtriggerDataGridViewTextBoxColumn,
            this.sTEnabledDataGridViewCheckBoxColumn});
            this.gTrigger.DataSource = this.bsTrigger;
            this.gTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTrigger.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTrigger.Location = new System.Drawing.Point(0, 41);
            this.gTrigger.MultiSelect = false;
            this.gTrigger.Name = "gTrigger";
            this.gTrigger.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTrigger.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gTrigger.RowHeadersWidth = 23;
            this.gTrigger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gTrigger.Size = new System.Drawing.Size(761, 460);
            this.gTrigger.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(761, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "TRIGGER TABELA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.lbTabelas);
            this.panelDados1.Controls.Add(this.lblTabelas);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(240, 526);
            this.panelDados1.TabIndex = 0;
            // 
            // lbTabelas
            // 
            this.lbTabelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTabelas.FormattingEnabled = true;
            this.lbTabelas.Location = new System.Drawing.Point(0, 16);
            this.lbTabelas.Name = "lbTabelas";
            this.lbTabelas.Size = new System.Drawing.Size(240, 498);
            this.lbTabelas.TabIndex = 1;
            this.lbTabelas.SelectedIndexChanged += new System.EventHandler(this.lbTabelas_SelectedIndexChanged);
            // 
            // lblTabelas
            // 
            this.lblTabelas.BackColor = System.Drawing.Color.Gainsboro;
            this.lblTabelas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTabelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabelas.Location = new System.Drawing.Point(0, 0);
            this.lblTabelas.Name = "lblTabelas";
            this.lblTabelas.Size = new System.Drawing.Size(240, 16);
            this.lblTabelas.TabIndex = 0;
            this.lblTabelas.Text = "TABELAS BANCO DADOS";
            this.lblTabelas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bsTrigger
            // 
            this.bsTrigger.DataSource = typeof(CamadaDados.Diversos.TRegistro_Trigger);
            // 
            // TS_Endereco
            // 
            this.TS_Endereco.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_buscartrigger,
            this.bb_ativar,
            this.bb_desativar});
            this.TS_Endereco.Location = new System.Drawing.Point(0, 16);
            this.TS_Endereco.Name = "TS_Endereco";
            this.TS_Endereco.Size = new System.Drawing.Size(761, 25);
            this.TS_Endereco.TabIndex = 33;
            // 
            // bb_buscartrigger
            // 
            this.bb_buscartrigger.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_buscartrigger.Image = ((System.Drawing.Image)(resources.GetObject("bb_buscartrigger.Image")));
            this.bb_buscartrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_buscartrigger.Name = "bb_buscartrigger";
            this.bb_buscartrigger.Size = new System.Drawing.Size(146, 22);
            this.bb_buscartrigger.Text = "Buscar Todas Trigger";
            this.bb_buscartrigger.Click += new System.EventHandler(this.bb_buscartrigger_Click);
            // 
            // bb_ativar
            // 
            this.bb_ativar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_ativar.Image = ((System.Drawing.Image)(resources.GetObject("bb_ativar.Image")));
            this.bb_ativar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_ativar.Name = "bb_ativar";
            this.bb_ativar.Size = new System.Drawing.Size(106, 22);
            this.bb_ativar.Text = "Ativar Trigger";
            this.bb_ativar.Click += new System.EventHandler(this.bb_ativar_Click);
            // 
            // bb_desativar
            // 
            this.bb_desativar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_desativar.Image = ((System.Drawing.Image)(resources.GetObject("bb_desativar.Image")));
            this.bb_desativar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_desativar.Name = "bb_desativar";
            this.bb_desativar.Size = new System.Drawing.Size(126, 22);
            this.bb_desativar.Text = "Desativar Trigger";
            this.bb_desativar.Click += new System.EventHandler(this.bb_desativar_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsTrigger;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 501);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(761, 25);
            this.bindingNavigator1.TabIndex = 34;
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
            // nmtriggerDataGridViewTextBoxColumn
            // 
            this.nmtriggerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmtriggerDataGridViewTextBoxColumn.DataPropertyName = "Nm_trigger";
            this.nmtriggerDataGridViewTextBoxColumn.HeaderText = "Trigger";
            this.nmtriggerDataGridViewTextBoxColumn.Name = "nmtriggerDataGridViewTextBoxColumn";
            this.nmtriggerDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmtriggerDataGridViewTextBoxColumn.Width = 65;
            // 
            // sTEnabledDataGridViewCheckBoxColumn
            // 
            this.sTEnabledDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sTEnabledDataGridViewCheckBoxColumn.DataPropertyName = "ST_Enabled";
            this.sTEnabledDataGridViewCheckBoxColumn.HeaderText = "Ativo";
            this.sTEnabledDataGridViewCheckBoxColumn.Name = "sTEnabledDataGridViewCheckBoxColumn";
            this.sTEnabledDataGridViewCheckBoxColumn.ReadOnly = true;
            this.sTEnabledDataGridViewCheckBoxColumn.Width = 37;
            // 
            // TFCfgAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 532);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCfgAudit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração Auditoria Aliance.NET";
            this.Load += new System.EventHandler(this.TFCfgAudit_Load);
            this.tlpCentral.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTrigger)).EndInit();
            this.panelDados1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsTrigger)).EndInit();
            this.TS_Endereco.ResumeLayout(false);
            this.TS_Endereco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label lblTabelas;
        private System.Windows.Forms.ListBox lbTabelas;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.Label label1;
        private Componentes.DataGridDefault gTrigger;
        private System.Windows.Forms.BindingSource bsTrigger;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStrip TS_Endereco;
        private System.Windows.Forms.ToolStripButton bb_buscartrigger;
        private System.Windows.Forms.ToolStripButton bb_desativar;
        private System.Windows.Forms.ToolStripButton bb_ativar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtriggerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sTEnabledDataGridViewCheckBoxColumn;

    }
}