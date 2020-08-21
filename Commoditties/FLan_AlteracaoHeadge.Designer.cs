namespace Commoditties
{
    partial class TFLan_AlteracaoHeadge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLan_AlteracaoHeadge));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid_LanctoNFHeadge = new Componentes.DataGridDefault(this.components);
            this.pDadosTitulo = new Componentes.PanelDados(this.components);
            this.labelProduto = new System.Windows.Forms.Label();
            this.labelNr_Pedido = new System.Windows.Forms.Label();
            this.labelNr_Contrato = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pDadosSubTitulo = new Componentes.PanelDados(this.components);
            this.labelTitulo = new System.Windows.Forms.Label();
            this.BS_LanctoNFHeadge = new System.Windows.Forms.BindingSource(this.components);
            this.iDLanctoHeadgeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDHeadgeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSHeadgeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VL_Lancto_Grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_LanctoNFHeadge)).BeginInit();
            this.pDadosTitulo.SuspendLayout();
            this.pDadosSubTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_LanctoNFHeadge)).BeginInit();
            this.SuspendLayout();
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            this.tcCentral.Font = null;
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.grid_LanctoNFHeadge);
            this.tpPadrao.Controls.Add(this.pDadosTitulo);
            this.tpPadrao.Font = null;
            // 
            // grid_LanctoNFHeadge
            // 
            this.grid_LanctoNFHeadge.AccessibleDescription = null;
            this.grid_LanctoNFHeadge.AccessibleName = null;
            this.grid_LanctoNFHeadge.AllowUserToAddRows = false;
            this.grid_LanctoNFHeadge.AllowUserToDeleteRows = false;
            this.grid_LanctoNFHeadge.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.grid_LanctoNFHeadge.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.grid_LanctoNFHeadge, "grid_LanctoNFHeadge");
            this.grid_LanctoNFHeadge.AutoGenerateColumns = false;
            this.grid_LanctoNFHeadge.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid_LanctoNFHeadge.BackgroundImage = null;
            this.grid_LanctoNFHeadge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_LanctoNFHeadge.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_LanctoNFHeadge.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_LanctoNFHeadge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_LanctoNFHeadge.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDLanctoHeadgeDataGridViewTextBoxColumn,
            this.iDHeadgeDataGridViewTextBoxColumn,
            this.dSHeadgeDataGridViewTextBoxColumn,
            this.VL_Lancto_Grid});
            this.grid_LanctoNFHeadge.DataSource = this.BS_LanctoNFHeadge;
            this.grid_LanctoNFHeadge.Font = null;
            this.grid_LanctoNFHeadge.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grid_LanctoNFHeadge.Name = "grid_LanctoNFHeadge";
            this.grid_LanctoNFHeadge.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_LanctoNFHeadge.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_LanctoNFHeadge.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid_LanctoNFHeadge.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_LanctoNFHeadge_CellBeginEdit);
            this.grid_LanctoNFHeadge.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grid_LanctoNFHeadge_CellFormatting);
            this.grid_LanctoNFHeadge.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_LanctoNFHeadge_CellEndEdit);
            // 
            // pDadosTitulo
            // 
            this.pDadosTitulo.AccessibleDescription = null;
            this.pDadosTitulo.AccessibleName = null;
            resources.ApplyResources(this.pDadosTitulo, "pDadosTitulo");
            this.pDadosTitulo.BackgroundImage = null;
            this.pDadosTitulo.Controls.Add(this.labelProduto);
            this.pDadosTitulo.Controls.Add(this.labelNr_Pedido);
            this.pDadosTitulo.Controls.Add(this.labelNr_Contrato);
            this.pDadosTitulo.Controls.Add(this.label3);
            this.pDadosTitulo.Controls.Add(this.label2);
            this.pDadosTitulo.Controls.Add(this.label1);
            this.pDadosTitulo.Controls.Add(this.pDadosSubTitulo);
            this.pDadosTitulo.Font = null;
            this.pDadosTitulo.Name = "pDadosTitulo";
            this.pDadosTitulo.NM_ProcDeletar = "";
            this.pDadosTitulo.NM_ProcGravar = "";
            // 
            // labelProduto
            // 
            this.labelProduto.AccessibleDescription = null;
            this.labelProduto.AccessibleName = null;
            resources.ApplyResources(this.labelProduto, "labelProduto");
            this.labelProduto.Font = null;
            this.labelProduto.Name = "labelProduto";
            // 
            // labelNr_Pedido
            // 
            this.labelNr_Pedido.AccessibleDescription = null;
            this.labelNr_Pedido.AccessibleName = null;
            resources.ApplyResources(this.labelNr_Pedido, "labelNr_Pedido");
            this.labelNr_Pedido.Font = null;
            this.labelNr_Pedido.Name = "labelNr_Pedido";
            // 
            // labelNr_Contrato
            // 
            this.labelNr_Contrato.AccessibleDescription = null;
            this.labelNr_Contrato.AccessibleName = null;
            resources.ApplyResources(this.labelNr_Contrato, "labelNr_Contrato");
            this.labelNr_Contrato.Font = null;
            this.labelNr_Contrato.Name = "labelNr_Contrato";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pDadosSubTitulo
            // 
            this.pDadosSubTitulo.AccessibleDescription = null;
            this.pDadosSubTitulo.AccessibleName = null;
            resources.ApplyResources(this.pDadosSubTitulo, "pDadosSubTitulo");
            this.pDadosSubTitulo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pDadosSubTitulo.BackgroundImage = null;
            this.pDadosSubTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDadosSubTitulo.Controls.Add(this.labelTitulo);
            this.pDadosSubTitulo.Font = null;
            this.pDadosSubTitulo.Name = "pDadosSubTitulo";
            this.pDadosSubTitulo.NM_ProcDeletar = "";
            this.pDadosSubTitulo.NM_ProcGravar = "";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AccessibleDescription = null;
            this.labelTitulo.AccessibleName = null;
            resources.ApplyResources(this.labelTitulo, "labelTitulo");
            this.labelTitulo.Name = "labelTitulo";
            // 
            // BS_LanctoNFHeadge
            // 
            this.BS_LanctoNFHeadge.DataSource = typeof(CamadaDados.Graos.TList_Lan_NFHeadge);
            // 
            // iDLanctoHeadgeDataGridViewTextBoxColumn
            // 
            this.iDLanctoHeadgeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDLanctoHeadgeDataGridViewTextBoxColumn.DataPropertyName = "ID_LanctoHeadge";
            resources.ApplyResources(this.iDLanctoHeadgeDataGridViewTextBoxColumn, "iDLanctoHeadgeDataGridViewTextBoxColumn");
            this.iDLanctoHeadgeDataGridViewTextBoxColumn.Name = "iDLanctoHeadgeDataGridViewTextBoxColumn";
            this.iDLanctoHeadgeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDHeadgeDataGridViewTextBoxColumn
            // 
            this.iDHeadgeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDHeadgeDataGridViewTextBoxColumn.DataPropertyName = "ID_Headge";
            resources.ApplyResources(this.iDHeadgeDataGridViewTextBoxColumn, "iDHeadgeDataGridViewTextBoxColumn");
            this.iDHeadgeDataGridViewTextBoxColumn.Name = "iDHeadgeDataGridViewTextBoxColumn";
            this.iDHeadgeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSHeadgeDataGridViewTextBoxColumn
            // 
            this.dSHeadgeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSHeadgeDataGridViewTextBoxColumn.DataPropertyName = "DS_Headge";
            resources.ApplyResources(this.dSHeadgeDataGridViewTextBoxColumn, "dSHeadgeDataGridViewTextBoxColumn");
            this.dSHeadgeDataGridViewTextBoxColumn.Name = "dSHeadgeDataGridViewTextBoxColumn";
            this.dSHeadgeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // VL_Lancto_Grid
            // 
            this.VL_Lancto_Grid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.VL_Lancto_Grid.DataPropertyName = "VL_Lancto";
            resources.ApplyResources(this.VL_Lancto_Grid, "VL_Lancto_Grid");
            this.VL_Lancto_Grid.Name = "VL_Lancto_Grid";
            this.VL_Lancto_Grid.ReadOnly = true;
            // 
            // TFLan_AlteracaoHeadge
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFLan_AlteracaoHeadge";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.TFLan_AlteracaoHeadge_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FLan_AlteracaoHeadge_FormClosing);
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_LanctoNFHeadge)).EndInit();
            this.pDadosTitulo.ResumeLayout(false);
            this.pDadosTitulo.PerformLayout();
            this.pDadosSubTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BS_LanctoNFHeadge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault grid_LanctoNFHeadge;
        public System.Windows.Forms.BindingSource BS_LanctoNFHeadge;
        private Componentes.PanelDados pDadosTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados pDadosSubTitulo;
        public System.Windows.Forms.Label labelTitulo;
        public System.Windows.Forms.Label labelProduto;
        public System.Windows.Forms.Label labelNr_Pedido;
        public System.Windows.Forms.Label labelNr_Contrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDLanctoHeadgeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDHeadgeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSHeadgeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VL_Lancto_Grid;
    }
}
