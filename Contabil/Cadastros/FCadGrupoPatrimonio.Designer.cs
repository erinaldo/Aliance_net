namespace Contabil.Cadastros
{
    partial class TFCadGrupoPatrimonio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadGrupoPatrimonio));
            System.Windows.Forms.Label ds_PatrimonioLabel;
            System.Windows.Forms.Label cd_PatrimonioStringLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.g_GrupoPatrimonio = new Componentes.DataGridDefault(this.components);
            this.BN_GrupoPatrimonio = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.Ds_GrupoPatrim = new Componentes.EditDefault(this.components);
            this.ID_GrupoPatrim = new Componentes.EditDefault(this.components);
            this.BS_GrupoPatrimonio = new System.Windows.Forms.BindingSource(this.components);
            this.iDGrupoPatrimDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSGrupoPatrimDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ds_PatrimonioLabel = new System.Windows.Forms.Label();
            cd_PatrimonioStringLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrupoPatrimonio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_GrupoPatrimonio)).BeginInit();
            this.BN_GrupoPatrimonio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_GrupoPatrimonio)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(ds_PatrimonioLabel);
            this.pDados.Controls.Add(this.Ds_GrupoPatrim);
            this.pDados.Controls.Add(cd_PatrimonioStringLabel);
            this.pDados.Controls.Add(this.ID_GrupoPatrim);
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
            this.tpPadrao.Controls.Add(this.g_GrupoPatrimonio);
            this.tpPadrao.Controls.Add(this.BN_GrupoPatrimonio);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.BN_GrupoPatrimonio, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_GrupoPatrimonio, 0);
            // 
            // ds_PatrimonioLabel
            // 
            ds_PatrimonioLabel.AccessibleDescription = null;
            ds_PatrimonioLabel.AccessibleName = null;
            resources.ApplyResources(ds_PatrimonioLabel, "ds_PatrimonioLabel");
            ds_PatrimonioLabel.Name = "ds_PatrimonioLabel";
            // 
            // cd_PatrimonioStringLabel
            // 
            cd_PatrimonioStringLabel.AccessibleDescription = null;
            cd_PatrimonioStringLabel.AccessibleName = null;
            resources.ApplyResources(cd_PatrimonioStringLabel, "cd_PatrimonioStringLabel");
            cd_PatrimonioStringLabel.Name = "cd_PatrimonioStringLabel";
            // 
            // g_GrupoPatrimonio
            // 
            this.g_GrupoPatrimonio.AccessibleDescription = null;
            this.g_GrupoPatrimonio.AccessibleName = null;
            this.g_GrupoPatrimonio.AllowUserToAddRows = false;
            this.g_GrupoPatrimonio.AllowUserToDeleteRows = false;
            this.g_GrupoPatrimonio.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_GrupoPatrimonio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.g_GrupoPatrimonio, "g_GrupoPatrimonio");
            this.g_GrupoPatrimonio.AutoGenerateColumns = false;
            this.g_GrupoPatrimonio.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_GrupoPatrimonio.BackgroundImage = null;
            this.g_GrupoPatrimonio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_GrupoPatrimonio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_GrupoPatrimonio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_GrupoPatrimonio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_GrupoPatrimonio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDGrupoPatrimDataGridViewTextBoxColumn,
            this.dSGrupoPatrimDataGridViewTextBoxColumn});
            this.g_GrupoPatrimonio.DataSource = this.BS_GrupoPatrimonio;
            this.g_GrupoPatrimonio.Font = null;
            this.g_GrupoPatrimonio.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_GrupoPatrimonio.Name = "g_GrupoPatrimonio";
            this.g_GrupoPatrimonio.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_GrupoPatrimonio.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // BN_GrupoPatrimonio
            // 
            this.BN_GrupoPatrimonio.AccessibleDescription = null;
            this.BN_GrupoPatrimonio.AccessibleName = null;
            this.BN_GrupoPatrimonio.AddNewItem = null;
            resources.ApplyResources(this.BN_GrupoPatrimonio, "BN_GrupoPatrimonio");
            this.BN_GrupoPatrimonio.BackgroundImage = null;
            this.BN_GrupoPatrimonio.BindingSource = this.BS_GrupoPatrimonio;
            this.BN_GrupoPatrimonio.CountItem = this.bindingNavigatorCountItem;
            this.BN_GrupoPatrimonio.DeleteItem = null;
            this.BN_GrupoPatrimonio.Font = null;
            this.BN_GrupoPatrimonio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_GrupoPatrimonio.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_GrupoPatrimonio.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_GrupoPatrimonio.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_GrupoPatrimonio.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_GrupoPatrimonio.Name = "BN_GrupoPatrimonio";
            this.BN_GrupoPatrimonio.PositionItem = this.bindingNavigatorPositionItem;
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
            // Ds_GrupoPatrim
            // 
            this.Ds_GrupoPatrim.AccessibleDescription = null;
            this.Ds_GrupoPatrim.AccessibleName = null;
            resources.ApplyResources(this.Ds_GrupoPatrim, "Ds_GrupoPatrim");
            this.Ds_GrupoPatrim.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_GrupoPatrim.BackgroundImage = null;
            this.Ds_GrupoPatrim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_GrupoPatrim.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_GrupoPatrimonio, "DS_GrupoPatrim", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_GrupoPatrim.Font = null;
            this.Ds_GrupoPatrim.Name = "Ds_GrupoPatrim";
            this.Ds_GrupoPatrim.NM_Alias = "";
            this.Ds_GrupoPatrim.NM_Campo = "DS_GrupoPatrim";
            this.Ds_GrupoPatrim.NM_CampoBusca = "DS_GrupoPatrim";
            this.Ds_GrupoPatrim.NM_Param = "@P_DS_GRUPOPATRIM";
            this.Ds_GrupoPatrim.QTD_Zero = 0;
            this.Ds_GrupoPatrim.ST_AutoInc = false;
            this.Ds_GrupoPatrim.ST_DisableAuto = false;
            this.Ds_GrupoPatrim.ST_Float = false;
            this.Ds_GrupoPatrim.ST_Gravar = true;
            this.Ds_GrupoPatrim.ST_Int = false;
            this.Ds_GrupoPatrim.ST_LimpaCampo = true;
            this.Ds_GrupoPatrim.ST_NotNull = true;
            this.Ds_GrupoPatrim.ST_PrimaryKey = false;
            // 
            // ID_GrupoPatrim
            // 
            this.ID_GrupoPatrim.AccessibleDescription = null;
            this.ID_GrupoPatrim.AccessibleName = null;
            resources.ApplyResources(this.ID_GrupoPatrim, "ID_GrupoPatrim");
            this.ID_GrupoPatrim.BackColor = System.Drawing.SystemColors.Window;
            this.ID_GrupoPatrim.BackgroundImage = null;
            this.ID_GrupoPatrim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_GrupoPatrim.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_GrupoPatrimonio, "ID_GrupoPatrim_String", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_GrupoPatrim.Font = null;
            this.ID_GrupoPatrim.Name = "ID_GrupoPatrim";
            this.ID_GrupoPatrim.NM_Alias = "";
            this.ID_GrupoPatrim.NM_Campo = "ID_GrupoPatrim";
            this.ID_GrupoPatrim.NM_CampoBusca = "ID_GrupoPatrim";
            this.ID_GrupoPatrim.NM_Param = "@P_CD_GRUPOPATRIM";
            this.ID_GrupoPatrim.QTD_Zero = 0;
            this.ID_GrupoPatrim.ST_AutoInc = false;
            this.ID_GrupoPatrim.ST_DisableAuto = true;
            this.ID_GrupoPatrim.ST_Float = false;
            this.ID_GrupoPatrim.ST_Gravar = true;
            this.ID_GrupoPatrim.ST_Int = true;
            this.ID_GrupoPatrim.ST_LimpaCampo = true;
            this.ID_GrupoPatrim.ST_NotNull = true;
            this.ID_GrupoPatrim.ST_PrimaryKey = true;
            // 
            // BS_GrupoPatrimonio
            // 
            this.BS_GrupoPatrimonio.DataSource = typeof(CamadaDados.Contabil.Cadastro.TList_CadGrupoPatrimonio);
            // 
            // iDGrupoPatrimDataGridViewTextBoxColumn
            // 
            this.iDGrupoPatrimDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDGrupoPatrimDataGridViewTextBoxColumn.DataPropertyName = "ID_GrupoPatrim";
            resources.ApplyResources(this.iDGrupoPatrimDataGridViewTextBoxColumn, "iDGrupoPatrimDataGridViewTextBoxColumn");
            this.iDGrupoPatrimDataGridViewTextBoxColumn.Name = "iDGrupoPatrimDataGridViewTextBoxColumn";
            this.iDGrupoPatrimDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSGrupoPatrimDataGridViewTextBoxColumn
            // 
            this.dSGrupoPatrimDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSGrupoPatrimDataGridViewTextBoxColumn.DataPropertyName = "DS_GrupoPatrim";
            resources.ApplyResources(this.dSGrupoPatrimDataGridViewTextBoxColumn, "dSGrupoPatrimDataGridViewTextBoxColumn");
            this.dSGrupoPatrimDataGridViewTextBoxColumn.Name = "dSGrupoPatrimDataGridViewTextBoxColumn";
            this.dSGrupoPatrimDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCadGrupoPatrimonio
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadGrupoPatrimonio";
            this.Load += new System.EventHandler(this.TFCadGrupoPatrimonio_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrupoPatrimonio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_GrupoPatrimonio)).EndInit();
            this.BN_GrupoPatrimonio.ResumeLayout(false);
            this.BN_GrupoPatrimonio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_GrupoPatrimonio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault g_GrupoPatrimonio;
        private System.Windows.Forms.BindingNavigator BN_GrupoPatrimonio;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource BS_GrupoPatrimonio;
        private Componentes.EditDefault Ds_GrupoPatrim;
        private Componentes.EditDefault ID_GrupoPatrim;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDGrupoPatrimDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSGrupoPatrimDataGridViewTextBoxColumn;
    }
}