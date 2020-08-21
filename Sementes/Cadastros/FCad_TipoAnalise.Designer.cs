namespace Sementes.Cadastros
{
    partial class TFCad_TipoAnalise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_TipoAnalise));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.idanaliseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsanaliseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTipoAnalise = new System.Windows.Forms.BindingSource(this.components);
            this.bnTipoAnalise = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.id_analise = new Componentes.EditDefault(this.components);
            this.ds_tipoanalise = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTipoAnalise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnTipoAnalise)).BeginInit();
            this.bnTipoAnalise.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ds_tipoanalise);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.id_analise);
            this.pDados.Controls.Add(this.label1);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bnTipoAnalise);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bnTipoAnalise, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
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
            this.idanaliseDataGridViewTextBoxColumn,
            this.dsanaliseDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsTipoAnalise;
            resources.ApplyResources(this.dataGridDefault1, "dataGridDefault1");
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // idanaliseDataGridViewTextBoxColumn
            // 
            this.idanaliseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idanaliseDataGridViewTextBoxColumn.DataPropertyName = "Id_analise";
            resources.ApplyResources(this.idanaliseDataGridViewTextBoxColumn, "idanaliseDataGridViewTextBoxColumn");
            this.idanaliseDataGridViewTextBoxColumn.Name = "idanaliseDataGridViewTextBoxColumn";
            this.idanaliseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsanaliseDataGridViewTextBoxColumn
            // 
            this.dsanaliseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsanaliseDataGridViewTextBoxColumn.DataPropertyName = "Ds_analise";
            resources.ApplyResources(this.dsanaliseDataGridViewTextBoxColumn, "dsanaliseDataGridViewTextBoxColumn");
            this.dsanaliseDataGridViewTextBoxColumn.Name = "dsanaliseDataGridViewTextBoxColumn";
            this.dsanaliseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsTipoAnalise
            // 
            this.bsTipoAnalise.DataSource = typeof(CamadaDados.Sementes.Cadastros.TList_TipoAnalise);
            // 
            // bnTipoAnalise
            // 
            this.bnTipoAnalise.AddNewItem = null;
            this.bnTipoAnalise.BindingSource = this.bsTipoAnalise;
            this.bnTipoAnalise.CountItem = this.bindingNavigatorCountItem;
            this.bnTipoAnalise.CountItemFormat = "de {0}";
            this.bnTipoAnalise.DeleteItem = null;
            resources.ApplyResources(this.bnTipoAnalise, "bnTipoAnalise");
            this.bnTipoAnalise.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnTipoAnalise.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnTipoAnalise.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnTipoAnalise.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnTipoAnalise.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnTipoAnalise.Name = "bnTipoAnalise";
            this.bnTipoAnalise.PositionItem = this.bindingNavigatorPositionItem;
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // id_analise
            // 
            this.id_analise.BackColor = System.Drawing.SystemColors.Window;
            this.id_analise.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_analise.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTipoAnalise, "Id_analise", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.id_analise, "id_analise");
            this.id_analise.Name = "id_analise";
            this.id_analise.NM_Alias = "";
            this.id_analise.NM_Campo = "id_analise";
            this.id_analise.NM_CampoBusca = "id_analise";
            this.id_analise.NM_Param = "@P_ID_ANALISE";
            this.id_analise.QTD_Zero = 0;
            this.id_analise.ST_AutoInc = false;
            this.id_analise.ST_DisableAuto = true;
            this.id_analise.ST_Float = false;
            this.id_analise.ST_Gravar = true;
            this.id_analise.ST_Int = true;
            this.id_analise.ST_LimpaCampo = true;
            this.id_analise.ST_NotNull = true;
            this.id_analise.ST_PrimaryKey = true;
            // 
            // ds_tipoanalise
            // 
            this.ds_tipoanalise.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tipoanalise.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tipoanalise.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTipoAnalise, "Ds_analise", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_tipoanalise, "ds_tipoanalise");
            this.ds_tipoanalise.Name = "ds_tipoanalise";
            this.ds_tipoanalise.NM_Alias = "";
            this.ds_tipoanalise.NM_Campo = "";
            this.ds_tipoanalise.NM_CampoBusca = "";
            this.ds_tipoanalise.NM_Param = "";
            this.ds_tipoanalise.QTD_Zero = 0;
            this.ds_tipoanalise.ST_AutoInc = false;
            this.ds_tipoanalise.ST_DisableAuto = false;
            this.ds_tipoanalise.ST_Float = false;
            this.ds_tipoanalise.ST_Gravar = true;
            this.ds_tipoanalise.ST_Int = false;
            this.ds_tipoanalise.ST_LimpaCampo = true;
            this.ds_tipoanalise.ST_NotNull = true;
            this.ds_tipoanalise.ST_PrimaryKey = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TFCad_TipoAnalise
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCad_TipoAnalise";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTipoAnalise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnTipoAnalise)).EndInit();
            this.bnTipoAnalise.ResumeLayout(false);
            this.bnTipoAnalise.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsTipoAnalise;
        private System.Windows.Forms.BindingNavigator bnTipoAnalise;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault ds_tipoanalise;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault id_analise;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idanaliseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsanaliseDataGridViewTextBoxColumn;
    }
}
