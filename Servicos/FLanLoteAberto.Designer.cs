namespace Servicos
{
    partial class TFLanLoteAberto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanLoteAberto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pCentral = new Componentes.PanelDados(this.components);
            this.dataGridDefault2 = new Componentes.DataGridDefault(this.components);
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlotestrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsloteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdendfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsendfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtenviolotestrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtprevdevolucaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsLote = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLote)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AccessibleDescription = null;
            this.BB_Gravar.AccessibleName = null;
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.BackgroundImage = null;
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AccessibleDescription = null;
            this.BB_Cancelar.AccessibleName = null;
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.BackgroundImage = null;
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.AccessibleDescription = null;
            this.tlpCentral.AccessibleName = null;
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.BackgroundImage = null;
            this.tlpCentral.Controls.Add(this.pCentral, 0, 0);
            this.tlpCentral.Font = null;
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pCentral
            // 
            this.pCentral.AccessibleDescription = null;
            this.pCentral.AccessibleName = null;
            resources.ApplyResources(this.pCentral, "pCentral");
            this.pCentral.BackgroundImage = null;
            this.pCentral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pCentral.Controls.Add(this.dataGridDefault2);
            this.pCentral.Font = null;
            this.pCentral.Name = "pCentral";
            this.pCentral.NM_ProcDeletar = "";
            this.pCentral.NM_ProcGravar = "";
            // 
            // dataGridDefault2
            // 
            this.dataGridDefault2.AccessibleDescription = null;
            this.dataGridDefault2.AccessibleName = null;
            this.dataGridDefault2.AllowUserToAddRows = false;
            this.dataGridDefault2.AllowUserToDeleteRows = false;
            this.dataGridDefault2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridDefault2, "dataGridDefault2");
            this.dataGridDefault2.AutoGenerateColumns = false;
            this.dataGridDefault2.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault2.BackgroundImage = null;
            this.dataGridDefault2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewTextBoxColumn,
            this.idlotestrDataGridViewTextBoxColumn,
            this.dsloteDataGridViewTextBoxColumn,
            this.cdfornecedorDataGridViewTextBoxColumn,
            this.nmfornecedorDataGridViewTextBoxColumn,
            this.cdendfornecedorDataGridViewTextBoxColumn,
            this.dsendfornecedorDataGridViewTextBoxColumn,
            this.dtenviolotestrDataGridViewTextBoxColumn,
            this.dtprevdevolucaostrDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn});
            this.dataGridDefault2.DataSource = this.bsLote;
            this.dataGridDefault2.Font = null;
            this.dataGridDefault2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault2.MultiSelect = false;
            this.dataGridDefault2.Name = "dataGridDefault2";
            this.dataGridDefault2.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault2.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            resources.ApplyResources(this.statusDataGridViewTextBoxColumn, "statusDataGridViewTextBoxColumn");
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idlotestrDataGridViewTextBoxColumn
            // 
            this.idlotestrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idlotestrDataGridViewTextBoxColumn.DataPropertyName = "Id_lotestr";
            resources.ApplyResources(this.idlotestrDataGridViewTextBoxColumn, "idlotestrDataGridViewTextBoxColumn");
            this.idlotestrDataGridViewTextBoxColumn.Name = "idlotestrDataGridViewTextBoxColumn";
            this.idlotestrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsloteDataGridViewTextBoxColumn
            // 
            this.dsloteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsloteDataGridViewTextBoxColumn.DataPropertyName = "Ds_lote";
            resources.ApplyResources(this.dsloteDataGridViewTextBoxColumn, "dsloteDataGridViewTextBoxColumn");
            this.dsloteDataGridViewTextBoxColumn.Name = "dsloteDataGridViewTextBoxColumn";
            this.dsloteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdfornecedorDataGridViewTextBoxColumn
            // 
            this.cdfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Cd_fornecedor";
            resources.ApplyResources(this.cdfornecedorDataGridViewTextBoxColumn, "cdfornecedorDataGridViewTextBoxColumn");
            this.cdfornecedorDataGridViewTextBoxColumn.Name = "cdfornecedorDataGridViewTextBoxColumn";
            this.cdfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmfornecedorDataGridViewTextBoxColumn
            // 
            this.nmfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Nm_fornecedor";
            resources.ApplyResources(this.nmfornecedorDataGridViewTextBoxColumn, "nmfornecedorDataGridViewTextBoxColumn");
            this.nmfornecedorDataGridViewTextBoxColumn.Name = "nmfornecedorDataGridViewTextBoxColumn";
            this.nmfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdendfornecedorDataGridViewTextBoxColumn
            // 
            this.cdendfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdendfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Cd_endfornecedor";
            resources.ApplyResources(this.cdendfornecedorDataGridViewTextBoxColumn, "cdendfornecedorDataGridViewTextBoxColumn");
            this.cdendfornecedorDataGridViewTextBoxColumn.Name = "cdendfornecedorDataGridViewTextBoxColumn";
            this.cdendfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsendfornecedorDataGridViewTextBoxColumn
            // 
            this.dsendfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsendfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Ds_endfornecedor";
            resources.ApplyResources(this.dsendfornecedorDataGridViewTextBoxColumn, "dsendfornecedorDataGridViewTextBoxColumn");
            this.dsendfornecedorDataGridViewTextBoxColumn.Name = "dsendfornecedorDataGridViewTextBoxColumn";
            this.dsendfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtenviolotestrDataGridViewTextBoxColumn
            // 
            this.dtenviolotestrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtenviolotestrDataGridViewTextBoxColumn.DataPropertyName = "Dt_enviolotestr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dtenviolotestrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dtenviolotestrDataGridViewTextBoxColumn, "dtenviolotestrDataGridViewTextBoxColumn");
            this.dtenviolotestrDataGridViewTextBoxColumn.Name = "dtenviolotestrDataGridViewTextBoxColumn";
            this.dtenviolotestrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtprevdevolucaostrDataGridViewTextBoxColumn
            // 
            this.dtprevdevolucaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtprevdevolucaostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_prevdevolucaostr";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.dtprevdevolucaostrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dtprevdevolucaostrDataGridViewTextBoxColumn, "dtprevdevolucaostrDataGridViewTextBoxColumn");
            this.dtprevdevolucaostrDataGridViewTextBoxColumn.Name = "dtprevdevolucaostrDataGridViewTextBoxColumn";
            this.dtprevdevolucaostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsobservacaoDataGridViewTextBoxColumn
            // 
            this.dsobservacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_observacao";
            resources.ApplyResources(this.dsobservacaoDataGridViewTextBoxColumn, "dsobservacaoDataGridViewTextBoxColumn");
            this.dsobservacaoDataGridViewTextBoxColumn.Name = "dsobservacaoDataGridViewTextBoxColumn";
            this.dsobservacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsLote
            // 
            this.bsLote.DataSource = typeof(CamadaDados.Servicos.TList_LoteOS);
            // 
            // TFLanLoteAberto
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanLoteAberto";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanLoteAberto_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanLoteAberto_FormClosing);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.BindingSource bsLote;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pCentral;
        private Componentes.DataGridDefault dataGridDefault2;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlotestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsloteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdendfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsendfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtenviolotestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtprevdevolucaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn;
    }
}