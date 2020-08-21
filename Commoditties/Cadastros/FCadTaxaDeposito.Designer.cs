namespace Commoditties.Cadastros
{
    partial class TFCadTaxaDeposito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTaxaDeposito));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.Ds_Taxa = new Componentes.EditDefault(this.components);
            this.BS_TaxaDeposito = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.g_TaxaDeposito = new Componentes.DataGridDefault(this.components);
            this.Tp_Taxa2 = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_taxa = new Componentes.EditDefault(this.components);
            this.idTaxastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsTaxaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_TaxaDeposito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TaxaDeposito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.id_taxa);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.Tp_Taxa2);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.Ds_Taxa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Font = null;
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
            this.tpPadrao.Controls.Add(this.g_TaxaDeposito);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_TaxaDeposito, 0);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Ds_Taxa
            // 
            this.Ds_Taxa.AccessibleDescription = null;
            this.Ds_Taxa.AccessibleName = null;
            resources.ApplyResources(this.Ds_Taxa, "Ds_Taxa");
            this.Ds_Taxa.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_Taxa.BackgroundImage = null;
            this.Ds_Taxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_Taxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TaxaDeposito, "Ds_Taxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_Taxa.Font = null;
            this.Ds_Taxa.Name = "Ds_Taxa";
            this.Ds_Taxa.NM_Alias = "";
            this.Ds_Taxa.NM_Campo = "DS_TAXA";
            this.Ds_Taxa.NM_CampoBusca = "DS_TAXA";
            this.Ds_Taxa.NM_Param = "@P_DS_TAXA";
            this.Ds_Taxa.QTD_Zero = 0;
            this.Ds_Taxa.ST_AutoInc = false;
            this.Ds_Taxa.ST_DisableAuto = false;
            this.Ds_Taxa.ST_Float = false;
            this.Ds_Taxa.ST_Gravar = true;
            this.Ds_Taxa.ST_Int = false;
            this.Ds_Taxa.ST_LimpaCampo = true;
            this.Ds_Taxa.ST_NotNull = false;
            this.Ds_Taxa.ST_PrimaryKey = false;
            // 
            // BS_TaxaDeposito
            // 
            this.BS_TaxaDeposito.DataSource = typeof(CamadaDados.Graos.TList_CadTaxaDeposito);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // g_TaxaDeposito
            // 
            this.g_TaxaDeposito.AccessibleDescription = null;
            this.g_TaxaDeposito.AccessibleName = null;
            this.g_TaxaDeposito.AllowUserToAddRows = false;
            this.g_TaxaDeposito.AllowUserToDeleteRows = false;
            this.g_TaxaDeposito.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_TaxaDeposito.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.g_TaxaDeposito, "g_TaxaDeposito");
            this.g_TaxaDeposito.AutoGenerateColumns = false;
            this.g_TaxaDeposito.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_TaxaDeposito.BackgroundImage = null;
            this.g_TaxaDeposito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_TaxaDeposito.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_TaxaDeposito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_TaxaDeposito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_TaxaDeposito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTaxastrDataGridViewTextBoxColumn,
            this.dsTaxaDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1});
            this.g_TaxaDeposito.DataSource = this.BS_TaxaDeposito;
            this.g_TaxaDeposito.Font = null;
            this.g_TaxaDeposito.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_TaxaDeposito.Name = "g_TaxaDeposito";
            this.g_TaxaDeposito.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_TaxaDeposito.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // Tp_Taxa2
            // 
            this.Tp_Taxa2.AccessibleDescription = null;
            this.Tp_Taxa2.AccessibleName = null;
            resources.ApplyResources(this.Tp_Taxa2, "Tp_Taxa2");
            this.Tp_Taxa2.BackgroundImage = null;
            this.Tp_Taxa2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_TaxaDeposito, "TP_Taxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Tp_Taxa2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tp_Taxa2.Font = null;
            this.Tp_Taxa2.FormattingEnabled = true;
            this.Tp_Taxa2.Name = "Tp_Taxa2";
            this.Tp_Taxa2.NM_Alias = "";
            this.Tp_Taxa2.NM_Campo = "";
            this.Tp_Taxa2.NM_Param = "";
            this.Tp_Taxa2.ST_Gravar = true;
            this.Tp_Taxa2.ST_LimparCampo = true;
            this.Tp_Taxa2.ST_NotNull = true;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AccessibleDescription = null;
            this.bindingNavigator1.AccessibleName = null;
            this.bindingNavigator1.AddNewItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.BackgroundImage = null;
            this.bindingNavigator1.BindingSource = this.BS_TaxaDeposito;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Font = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.AccessibleDescription = null;
            this.bindingNavigatorCountItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.BackgroundImage = null;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.AccessibleDescription = null;
            this.bindingNavigatorSeparator.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.AccessibleDescription = null;
            this.bindingNavigatorSeparator1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // id_taxa
            // 
            this.id_taxa.AccessibleDescription = null;
            this.id_taxa.AccessibleName = null;
            resources.ApplyResources(this.id_taxa, "id_taxa");
            this.id_taxa.BackColor = System.Drawing.SystemColors.Window;
            this.id_taxa.BackgroundImage = null;
            this.id_taxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_taxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TaxaDeposito, "Id_Taxa_str", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_taxa.Font = null;
            this.id_taxa.Name = "id_taxa";
            this.id_taxa.NM_Alias = "";
            this.id_taxa.NM_Campo = "";
            this.id_taxa.NM_CampoBusca = "";
            this.id_taxa.NM_Param = "";
            this.id_taxa.QTD_Zero = 0;
            this.id_taxa.ST_AutoInc = false;
            this.id_taxa.ST_DisableAuto = false;
            this.id_taxa.ST_Float = false;
            this.id_taxa.ST_Gravar = true;
            this.id_taxa.ST_Int = true;
            this.id_taxa.ST_LimpaCampo = true;
            this.id_taxa.ST_NotNull = true;
            this.id_taxa.ST_PrimaryKey = true;
            // 
            // idTaxastrDataGridViewTextBoxColumn
            // 
            this.idTaxastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idTaxastrDataGridViewTextBoxColumn.DataPropertyName = "Id_Taxa_str";
            resources.ApplyResources(this.idTaxastrDataGridViewTextBoxColumn, "idTaxastrDataGridViewTextBoxColumn");
            this.idTaxastrDataGridViewTextBoxColumn.Name = "idTaxastrDataGridViewTextBoxColumn";
            this.idTaxastrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsTaxaDataGridViewTextBoxColumn
            // 
            this.dsTaxaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsTaxaDataGridViewTextBoxColumn.DataPropertyName = "Ds_Taxa";
            resources.ApplyResources(this.dsTaxaDataGridViewTextBoxColumn, "dsTaxaDataGridViewTextBoxColumn");
            this.dsTaxaDataGridViewTextBoxColumn.Name = "dsTaxaDataGridViewTextBoxColumn";
            this.dsTaxaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TP_TAXA_str";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // TFCadTaxaDeposito
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadTaxaDeposito";
            this.Load += new System.EventHandler(this.TFCadTaxaDeposito_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BS_TaxaDeposito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TaxaDeposito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault Ds_Taxa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource BS_TaxaDeposito;
        private Componentes.DataGridDefault g_TaxaDeposito;
        private Componentes.ComboBoxDefault Tp_Taxa2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault id_taxa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTaxastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsTaxaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}