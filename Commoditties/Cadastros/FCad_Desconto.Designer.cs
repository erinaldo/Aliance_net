namespace Commoditties.Cadastros
{
    partial class TFCad_Desconto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Desconto));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CD_TabelaDesconto = new Componentes.EditDefault(this.components);
            this.BS_CadDesconto = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Desconto = new Componentes.EditDefault(this.components);
            this.g_cad_tabelaDesconto = new Componentes.DataGridDefault(this.components);
            this.cDDescontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSDescontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BN_CadDesconto = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.Padrao_Qualidade = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadDesconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_cad_tabelaDesconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadDesconto)).BeginInit();
            this.BN_CadDesconto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.Padrao_Qualidade);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.DS_Desconto);
            this.pDados.Controls.Add(this.CD_TabelaDesconto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_cad_tabelaDesconto);
            this.tpPadrao.Controls.Add(this.BN_CadDesconto);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadDesconto, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_cad_tabelaDesconto, 0);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // CD_TabelaDesconto
            // 
            this.CD_TabelaDesconto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_TabelaDesconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_TabelaDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_TabelaDesconto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadDesconto, "CD_Desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_TabelaDesconto, "CD_TabelaDesconto");
            this.CD_TabelaDesconto.Name = "CD_TabelaDesconto";
            this.CD_TabelaDesconto.NM_Alias = "a";
            this.CD_TabelaDesconto.NM_Campo = "CD_tabelaDesconto";
            this.CD_TabelaDesconto.NM_CampoBusca = "CD_tabelaDesconto";
            this.CD_TabelaDesconto.NM_Param = "@P_CD_TABELADESCONTO";
            this.CD_TabelaDesconto.QTD_Zero = 0;
            this.CD_TabelaDesconto.ST_AutoInc = false;
            this.CD_TabelaDesconto.ST_DisableAuto = true;
            this.CD_TabelaDesconto.ST_Float = false;
            this.CD_TabelaDesconto.ST_Gravar = true;
            this.CD_TabelaDesconto.ST_Int = true;
            this.CD_TabelaDesconto.ST_LimpaCampo = true;
            this.CD_TabelaDesconto.ST_NotNull = true;
            this.CD_TabelaDesconto.ST_PrimaryKey = true;
            // 
            // BS_CadDesconto
            // 
            this.BS_CadDesconto.DataSource = typeof(CamadaDados.Graos.TList_CadDesconto);
            // 
            // DS_Desconto
            // 
            this.DS_Desconto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Desconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Desconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Desconto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadDesconto, "DS_Desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Desconto, "DS_Desconto");
            this.DS_Desconto.Name = "DS_Desconto";
            this.DS_Desconto.NM_Alias = "a";
            this.DS_Desconto.NM_Campo = "DS_tabelaDesconto";
            this.DS_Desconto.NM_CampoBusca = "DS_tabelaDesconto";
            this.DS_Desconto.NM_Param = "@P_DS_TABELADESCONTO";
            this.DS_Desconto.QTD_Zero = 0;
            this.DS_Desconto.ST_AutoInc = false;
            this.DS_Desconto.ST_DisableAuto = false;
            this.DS_Desconto.ST_Float = false;
            this.DS_Desconto.ST_Gravar = true;
            this.DS_Desconto.ST_Int = false;
            this.DS_Desconto.ST_LimpaCampo = true;
            this.DS_Desconto.ST_NotNull = false;
            this.DS_Desconto.ST_PrimaryKey = false;
            // 
            // g_cad_tabelaDesconto
            // 
            this.g_cad_tabelaDesconto.AllowUserToAddRows = false;
            this.g_cad_tabelaDesconto.AllowUserToDeleteRows = false;
            this.g_cad_tabelaDesconto.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_cad_tabelaDesconto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_cad_tabelaDesconto.AutoGenerateColumns = false;
            this.g_cad_tabelaDesconto.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_cad_tabelaDesconto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_cad_tabelaDesconto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_cad_tabelaDesconto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_cad_tabelaDesconto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_cad_tabelaDesconto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDDescontoDataGridViewTextBoxColumn,
            this.dSDescontoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1});
            this.g_cad_tabelaDesconto.DataSource = this.BS_CadDesconto;
            resources.ApplyResources(this.g_cad_tabelaDesconto, "g_cad_tabelaDesconto");
            this.g_cad_tabelaDesconto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_cad_tabelaDesconto.Name = "g_cad_tabelaDesconto";
            this.g_cad_tabelaDesconto.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_cad_tabelaDesconto.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_cad_tabelaDesconto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_cad_tabelaDesconto.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.g_cad_tabelaDesconto_ColumnHeaderMouseClick);
            // 
            // cDDescontoDataGridViewTextBoxColumn
            // 
            this.cDDescontoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDDescontoDataGridViewTextBoxColumn.DataPropertyName = "CD_Desconto";
            resources.ApplyResources(this.cDDescontoDataGridViewTextBoxColumn, "cDDescontoDataGridViewTextBoxColumn");
            this.cDDescontoDataGridViewTextBoxColumn.Name = "cDDescontoDataGridViewTextBoxColumn";
            this.cDDescontoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSDescontoDataGridViewTextBoxColumn
            // 
            this.dSDescontoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSDescontoDataGridViewTextBoxColumn.DataPropertyName = "DS_Desconto";
            resources.ApplyResources(this.dSDescontoDataGridViewTextBoxColumn, "dSDescontoDataGridViewTextBoxColumn");
            this.dSDescontoDataGridViewTextBoxColumn.Name = "dSDescontoDataGridViewTextBoxColumn";
            this.dSDescontoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Padrao_Qualidade";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // BN_CadDesconto
            // 
            this.BN_CadDesconto.AddNewItem = null;
            this.BN_CadDesconto.BindingSource = this.BS_CadDesconto;
            this.BN_CadDesconto.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadDesconto.CountItemFormat = "de {0}";
            this.BN_CadDesconto.DeleteItem = null;
            resources.ApplyResources(this.BN_CadDesconto, "BN_CadDesconto");
            this.BN_CadDesconto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadDesconto.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadDesconto.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadDesconto.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadDesconto.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadDesconto.Name = "BN_CadDesconto";
            this.BN_CadDesconto.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // Padrao_Qualidade
            // 
            this.Padrao_Qualidade.BackColor = System.Drawing.SystemColors.Window;
            this.Padrao_Qualidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Padrao_Qualidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Padrao_Qualidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadDesconto, "Padrao_Qualidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Padrao_Qualidade, "Padrao_Qualidade");
            this.Padrao_Qualidade.Name = "Padrao_Qualidade";
            this.Padrao_Qualidade.NM_Alias = "a";
            this.Padrao_Qualidade.NM_Campo = "Padrao_Qualidade";
            this.Padrao_Qualidade.NM_CampoBusca = "Padrao_Qualidade";
            this.Padrao_Qualidade.NM_Param = "@P_PADRAO_QUALIDADE";
            this.Padrao_Qualidade.QTD_Zero = 0;
            this.Padrao_Qualidade.ST_AutoInc = false;
            this.Padrao_Qualidade.ST_DisableAuto = false;
            this.Padrao_Qualidade.ST_Float = false;
            this.Padrao_Qualidade.ST_Gravar = true;
            this.Padrao_Qualidade.ST_Int = false;
            this.Padrao_Qualidade.ST_LimpaCampo = true;
            this.Padrao_Qualidade.ST_NotNull = false;
            this.Padrao_Qualidade.ST_PrimaryKey = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // TFCad_Desconto
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCad_Desconto";
            this.Load += new System.EventHandler(this.TFCad_Desconto_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadDesconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_cad_tabelaDesconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadDesconto)).EndInit();
            this.BN_CadDesconto.ResumeLayout(false);
            this.BN_CadDesconto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingNavigator BN_CadDesconto;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault g_cad_tabelaDesconto;
        private System.Windows.Forms.BindingSource BS_CadDesconto;
        private Componentes.EditDefault CD_TabelaDesconto;
        private Componentes.EditDefault DS_Desconto;
        private Componentes.EditDefault Padrao_Qualidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDDescontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSDescontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}