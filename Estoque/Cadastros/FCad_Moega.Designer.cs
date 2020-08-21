namespace Estoque.Cadastros
{
    partial class TFCad_Moega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Moega));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.g_CadMoega = new Componentes.DataGridDefault(this.components);
            this.CD_Moega = new Componentes.EditDefault(this.components);
            this.DS_Moega = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.BN_Cad_Moega = new System.Windows.Forms.BindingNavigator(this.components);
            this.BS_CadMoega = new System.Windows.Forms.BindingSource(this.components);
            this.cDMoegaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSMoegaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadMoega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Cad_Moega)).BeginInit();
            this.BN_Cad_Moega.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadMoega)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.DS_Moega);
            this.pDados.Controls.Add(this.CD_Moega);
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
            this.tpPadrao.Controls.Add(this.g_CadMoega);
            this.tpPadrao.Controls.Add(this.BN_Cad_Moega);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.BN_Cad_Moega, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_CadMoega, 0);
            // 
            // g_CadMoega
            // 
            this.g_CadMoega.AccessibleDescription = null;
            resources.ApplyResources(this.g_CadMoega, "g_CadMoega");
            this.g_CadMoega.AllowUserToAddRows = false;
            this.g_CadMoega.AllowUserToDeleteRows = false;
            this.g_CadMoega.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_CadMoega.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_CadMoega.AutoGenerateColumns = false;
            this.g_CadMoega.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_CadMoega.BackgroundImage = null;
            this.g_CadMoega.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_CadMoega.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadMoega.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_CadMoega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_CadMoega.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDMoegaDataGridViewTextBoxColumn,
            this.dSMoegaDataGridViewTextBoxColumn});
            this.g_CadMoega.DataSource = this.BS_CadMoega;
            this.g_CadMoega.Font = null;
            this.g_CadMoega.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_CadMoega.Name = "g_CadMoega";
            this.g_CadMoega.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadMoega.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_CadMoega.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_CadMoega.TabStop = false;
            // 
            // CD_Moega
            // 
            this.CD_Moega.AccessibleDescription = null;
            this.CD_Moega.AccessibleName = null;
            resources.ApplyResources(this.CD_Moega, "CD_Moega");
            this.CD_Moega.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Moega.BackgroundImage = null;
            this.CD_Moega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Moega.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadMoega, "CD_Moega", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Moega.Font = null;
            this.CD_Moega.Name = "CD_Moega";
            this.CD_Moega.NM_Alias = "a";
            this.CD_Moega.NM_Campo = "Cód. Moega";
            this.CD_Moega.NM_CampoBusca = "CD_Moega";
            this.CD_Moega.NM_Param = "@P_CD_MOEGA";
            this.CD_Moega.QTD_Zero = 0;
            this.CD_Moega.ST_AutoInc = false;
            this.CD_Moega.ST_DisableAuto = true;
            this.CD_Moega.ST_Float = false;
            this.CD_Moega.ST_Gravar = true;
            this.CD_Moega.ST_Int = true;
            this.CD_Moega.ST_LimpaCampo = true;
            this.CD_Moega.ST_NotNull = true;
            this.CD_Moega.ST_PrimaryKey = true;
            this.CD_Moega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CD_Moega_KeyPress);
            // 
            // DS_Moega
            // 
            this.DS_Moega.AccessibleDescription = null;
            this.DS_Moega.AccessibleName = null;
            resources.ApplyResources(this.DS_Moega, "DS_Moega");
            this.DS_Moega.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Moega.BackgroundImage = null;
            this.DS_Moega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Moega.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadMoega, "DS_Moega", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Moega.Font = null;
            this.DS_Moega.Name = "DS_Moega";
            this.DS_Moega.NM_Alias = "";
            this.DS_Moega.NM_Campo = "Descrição";
            this.DS_Moega.NM_CampoBusca = "CD_MOEGA";
            this.DS_Moega.NM_Param = "@P_DS_MOEGA";
            this.DS_Moega.QTD_Zero = 0;
            this.DS_Moega.ST_AutoInc = false;
            this.DS_Moega.ST_DisableAuto = false;
            this.DS_Moega.ST_Float = false;
            this.DS_Moega.ST_Gravar = true;
            this.DS_Moega.ST_Int = false;
            this.DS_Moega.ST_LimpaCampo = true;
            this.DS_Moega.ST_NotNull = true;
            this.DS_Moega.ST_PrimaryKey = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.AccessibleDescription = null;
            this.bindingNavigatorCountItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.BackgroundImage = null;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
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
            // BN_Cad_Moega
            // 
            this.BN_Cad_Moega.AccessibleDescription = null;
            this.BN_Cad_Moega.AccessibleName = null;
            this.BN_Cad_Moega.AddNewItem = null;
            resources.ApplyResources(this.BN_Cad_Moega, "BN_Cad_Moega");
            this.BN_Cad_Moega.BackgroundImage = null;
            this.BN_Cad_Moega.BindingSource = this.BS_CadMoega;
            this.BN_Cad_Moega.CountItem = this.bindingNavigatorCountItem;
            this.BN_Cad_Moega.DeleteItem = null;
            this.BN_Cad_Moega.Font = null;
            this.BN_Cad_Moega.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_Cad_Moega.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_Cad_Moega.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_Cad_Moega.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_Cad_Moega.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_Cad_Moega.Name = "BN_Cad_Moega";
            this.BN_Cad_Moega.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // BS_CadMoega
            // 
            this.BS_CadMoega.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadMoega);
            // 
            // cDMoegaDataGridViewTextBoxColumn
            // 
            this.cDMoegaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDMoegaDataGridViewTextBoxColumn.DataPropertyName = "CD_Moega";
            resources.ApplyResources(this.cDMoegaDataGridViewTextBoxColumn, "cDMoegaDataGridViewTextBoxColumn");
            this.cDMoegaDataGridViewTextBoxColumn.Name = "cDMoegaDataGridViewTextBoxColumn";
            this.cDMoegaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSMoegaDataGridViewTextBoxColumn
            // 
            this.dSMoegaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSMoegaDataGridViewTextBoxColumn.DataPropertyName = "DS_Moega";
            resources.ApplyResources(this.dSMoegaDataGridViewTextBoxColumn, "dSMoegaDataGridViewTextBoxColumn");
            this.dSMoegaDataGridViewTextBoxColumn.Name = "dSMoegaDataGridViewTextBoxColumn";
            this.dSMoegaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCad_Moega
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCad_Moega";
            this.Load += new System.EventHandler(this.TFCad_Moega_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadMoega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Cad_Moega)).EndInit();
            this.BN_Cad_Moega.ResumeLayout(false);
            this.BN_Cad_Moega.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadMoega)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BS_CadMoega;
        private Componentes.DataGridDefault g_CadMoega;
        private Componentes.EditDefault DS_Moega;
        private Componentes.EditDefault CD_Moega;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingNavigator BN_Cad_Moega;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDMoegaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSMoegaDataGridViewTextBoxColumn;
    }
}