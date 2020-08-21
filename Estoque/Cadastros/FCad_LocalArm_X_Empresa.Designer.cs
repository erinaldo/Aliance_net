namespace Estoque.Cadastros
{
    partial class TFCad_LocalArm_X_Empresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_LocalArm_X_Empresa));
            this.g_CadLocalArm_X_Empresa = new Componentes.DataGridDefault(this.components);
            this.cDEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_CadLocalArm_X_Empresa = new System.Windows.Forms.BindingSource(this.components);
            this.BN_CadLocalArm_X_Empresa = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CD_Local = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Local = new System.Windows.Forms.Button();
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.DS_Local = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadLocalArm_X_Empresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadLocalArm_X_Empresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadLocalArm_X_Empresa)).BeginInit();
            this.BN_CadLocalArm_X_Empresa.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.DS_Local);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.BB_Local);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.CD_Local);
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
            this.tpPadrao.Controls.Add(this.g_CadLocalArm_X_Empresa);
            this.tpPadrao.Controls.Add(this.BN_CadLocalArm_X_Empresa);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadLocalArm_X_Empresa, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_CadLocalArm_X_Empresa, 0);
            // 
            // g_CadLocalArm_X_Empresa
            // 
            this.g_CadLocalArm_X_Empresa.AllowUserToAddRows = false;
            this.g_CadLocalArm_X_Empresa.AllowUserToDeleteRows = false;
            this.g_CadLocalArm_X_Empresa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_CadLocalArm_X_Empresa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_CadLocalArm_X_Empresa.AutoGenerateColumns = false;
            this.g_CadLocalArm_X_Empresa.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_CadLocalArm_X_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_CadLocalArm_X_Empresa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadLocalArm_X_Empresa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_CadLocalArm_X_Empresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_CadLocalArm_X_Empresa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDEmpresaDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.cDLocalDataGridViewTextBoxColumn,
            this.dSLocalDataGridViewTextBoxColumn});
            this.g_CadLocalArm_X_Empresa.DataSource = this.BS_CadLocalArm_X_Empresa;
            resources.ApplyResources(this.g_CadLocalArm_X_Empresa, "g_CadLocalArm_X_Empresa");
            this.g_CadLocalArm_X_Empresa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_CadLocalArm_X_Empresa.Name = "g_CadLocalArm_X_Empresa";
            this.g_CadLocalArm_X_Empresa.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadLocalArm_X_Empresa.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_CadLocalArm_X_Empresa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_CadLocalArm_X_Empresa.TabStop = false;
            // 
            // cDEmpresaDataGridViewTextBoxColumn
            // 
            this.cDEmpresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDEmpresaDataGridViewTextBoxColumn.DataPropertyName = "CD_Empresa";
            resources.ApplyResources(this.cDEmpresaDataGridViewTextBoxColumn, "cDEmpresaDataGridViewTextBoxColumn");
            this.cDEmpresaDataGridViewTextBoxColumn.Name = "cDEmpresaDataGridViewTextBoxColumn";
            this.cDEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NM_Empresa";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cDLocalDataGridViewTextBoxColumn
            // 
            this.cDLocalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDLocalDataGridViewTextBoxColumn.DataPropertyName = "CD_Local";
            resources.ApplyResources(this.cDLocalDataGridViewTextBoxColumn, "cDLocalDataGridViewTextBoxColumn");
            this.cDLocalDataGridViewTextBoxColumn.Name = "cDLocalDataGridViewTextBoxColumn";
            this.cDLocalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSLocalDataGridViewTextBoxColumn
            // 
            this.dSLocalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSLocalDataGridViewTextBoxColumn.DataPropertyName = "DS_Local";
            resources.ApplyResources(this.dSLocalDataGridViewTextBoxColumn, "dSLocalDataGridViewTextBoxColumn");
            this.dSLocalDataGridViewTextBoxColumn.Name = "dSLocalDataGridViewTextBoxColumn";
            this.dSLocalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BS_CadLocalArm_X_Empresa
            // 
            this.BS_CadLocalArm_X_Empresa.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Empresa);
            // 
            // BN_CadLocalArm_X_Empresa
            // 
            this.BN_CadLocalArm_X_Empresa.AddNewItem = null;
            this.BN_CadLocalArm_X_Empresa.BindingSource = this.BS_CadLocalArm_X_Empresa;
            this.BN_CadLocalArm_X_Empresa.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadLocalArm_X_Empresa.CountItemFormat = "de {0}";
            this.BN_CadLocalArm_X_Empresa.DeleteItem = null;
            resources.ApplyResources(this.BN_CadLocalArm_X_Empresa, "BN_CadLocalArm_X_Empresa");
            this.BN_CadLocalArm_X_Empresa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadLocalArm_X_Empresa.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadLocalArm_X_Empresa.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadLocalArm_X_Empresa.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadLocalArm_X_Empresa.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadLocalArm_X_Empresa.Name = "BN_CadLocalArm_X_Empresa";
            this.BN_CadLocalArm_X_Empresa.PositionItem = this.bindingNavigatorPositionItem;
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
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // CD_Local
            // 
            this.CD_Local.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadLocalArm_X_Empresa, "CD_Local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Local, "CD_Local");
            this.CD_Local.Name = "CD_Local";
            this.CD_Local.NM_Alias = "";
            this.CD_Local.NM_Campo = "CD_Local";
            this.CD_Local.NM_CampoBusca = "CD_Local";
            this.CD_Local.NM_Param = "@P_CD_LOCAL";
            this.CD_Local.QTD_Zero = 0;
            this.CD_Local.ST_AutoInc = false;
            this.CD_Local.ST_DisableAuto = false;
            this.CD_Local.ST_Float = false;
            this.CD_Local.ST_Gravar = true;
            this.CD_Local.ST_Int = false;
            this.CD_Local.ST_LimpaCampo = true;
            this.CD_Local.ST_NotNull = true;
            this.CD_Local.ST_PrimaryKey = true;
            this.CD_Local.TextOld = null;
            this.CD_Local.Leave += new System.EventHandler(this.CD_Local_Leave);
            this.CD_Local.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CD_Local_KeyPress);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadLocalArm_X_Empresa, "CD_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Empresa, "CD_Empresa");
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = true;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            this.CD_Empresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CD_Empresa_KeyPress);
            // 
            // BB_Local
            // 
            resources.ApplyResources(this.BB_Local, "BB_Local");
            this.BB_Local.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Local.Name = "BB_Local";
            this.BB_Local.UseVisualStyleBackColor = true;
            this.BB_Local.Click += new System.EventHandler(this.BB_Local_Click);
            // 
            // BB_Empresa
            // 
            resources.ApplyResources(this.BB_Empresa, "BB_Empresa");
            this.BB_Empresa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // DS_Local
            // 
            this.DS_Local.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadLocalArm_X_Empresa, "DS_Local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Local, "DS_Local");
            this.DS_Local.Name = "DS_Local";
            this.DS_Local.NM_Alias = "";
            this.DS_Local.NM_Campo = "DS_Local";
            this.DS_Local.NM_CampoBusca = "DS_Local";
            this.DS_Local.NM_Param = "@P_DS_LOCAL";
            this.DS_Local.QTD_Zero = 0;
            this.DS_Local.ST_AutoInc = false;
            this.DS_Local.ST_DisableAuto = true;
            this.DS_Local.ST_Float = false;
            this.DS_Local.ST_Gravar = false;
            this.DS_Local.ST_Int = false;
            this.DS_Local.ST_LimpaCampo = true;
            this.DS_Local.ST_NotNull = false;
            this.DS_Local.ST_PrimaryKey = false;
            this.DS_Local.TextOld = null;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadLocalArm_X_Empresa, "NM_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.NM_Empresa, "NM_Empresa");
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = true;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TextOld = null;
            // 
            // TFCad_LocalArm_X_Empresa
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCad_LocalArm_X_Empresa";
            this.Load += new System.EventHandler(this.TFCad_LocalArm_X_Empresa_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_LocalArm_X_Empresa_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadLocalArm_X_Empresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadLocalArm_X_Empresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadLocalArm_X_Empresa)).EndInit();
            this.BN_CadLocalArm_X_Empresa.ResumeLayout(false);
            this.BN_CadLocalArm_X_Empresa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault g_CadLocalArm_X_Empresa;
        private System.Windows.Forms.BindingSource BS_CadLocalArm_X_Empresa;
        private System.Windows.Forms.BindingNavigator BN_CadLocalArm_X_Empresa;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault CD_Local;
        private Componentes.EditDefault CD_Empresa;
        public System.Windows.Forms.Button BB_Local;
        public System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault DS_Local;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDLocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSLocalDataGridViewTextBoxColumn;
    }
}