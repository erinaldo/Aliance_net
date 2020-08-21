namespace Estoque.Cadastros
{
    partial class TFCad_LocalArm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_LocalArm));
            this.CD_Local = new Componentes.EditDefault(this.components);
            this.BS_CadLocalArm = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.LABEL2 = new System.Windows.Forms.Label();
            this.DS_Local = new Componentes.EditDefault(this.components);
            this.g_FCadLocalArm = new Componentes.DataGridDefault(this.components);
            this.BN_CadLocalArm = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.TP_Local = new Componentes.ComboBoxDefault(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.st_estterceiro = new Componentes.CheckBoxDefault(this.components);
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tplocalstrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stestterceiroboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadLocalArm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_FCadLocalArm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadLocalArm)).BeginInit();
            this.BN_CadLocalArm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.st_estterceiro);
            this.pDados.Controls.Add(this.TP_Local);
            this.pDados.Controls.Add(this.label34);
            this.pDados.Controls.Add(this.DS_Local);
            this.pDados.Controls.Add(this.LABEL2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.CD_Local);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_FCadLocalArm);
            this.tpPadrao.Controls.Add(this.BN_CadLocalArm);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadLocalArm, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_FCadLocalArm, 0);
            // 
            // CD_Local
            // 
            this.CD_Local.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadLocalArm, "CD_Local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Local, "CD_Local");
            this.CD_Local.Name = "CD_Local";
            this.CD_Local.NM_Alias = "";
            this.CD_Local.NM_Campo = "Cód. Local";
            this.CD_Local.NM_CampoBusca = "CD_LOCAL";
            this.CD_Local.NM_Param = "@P_CD_LOCAL";
            this.CD_Local.QTD_Zero = 0;
            this.CD_Local.ST_AutoInc = false;
            this.CD_Local.ST_DisableAuto = true;
            this.CD_Local.ST_Float = false;
            this.CD_Local.ST_Gravar = true;
            this.CD_Local.ST_Int = true;
            this.CD_Local.ST_LimpaCampo = true;
            this.CD_Local.ST_NotNull = true;
            this.CD_Local.ST_PrimaryKey = true;
            this.CD_Local.TextOld = null;
            this.CD_Local.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CD_Local_KeyPress);
            // 
            // BS_CadLocalArm
            // 
            this.BS_CadLocalArm.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadLocalArm);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // LABEL2
            // 
            resources.ApplyResources(this.LABEL2, "LABEL2");
            this.LABEL2.Name = "LABEL2";
            // 
            // DS_Local
            // 
            this.DS_Local.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadLocalArm, "DS_Local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Local, "DS_Local");
            this.DS_Local.Name = "DS_Local";
            this.DS_Local.NM_Alias = "a";
            this.DS_Local.NM_Campo = "Local Armazem";
            this.DS_Local.NM_CampoBusca = "DS_LOCAL";
            this.DS_Local.NM_Param = "@P_DS_LOCAL";
            this.DS_Local.QTD_Zero = 0;
            this.DS_Local.ST_AutoInc = false;
            this.DS_Local.ST_DisableAuto = true;
            this.DS_Local.ST_Float = false;
            this.DS_Local.ST_Gravar = true;
            this.DS_Local.ST_Int = false;
            this.DS_Local.ST_LimpaCampo = true;
            this.DS_Local.ST_NotNull = false;
            this.DS_Local.ST_PrimaryKey = false;
            this.DS_Local.TextOld = null;
            // 
            // g_FCadLocalArm
            // 
            this.g_FCadLocalArm.AllowUserToAddRows = false;
            this.g_FCadLocalArm.AllowUserToDeleteRows = false;
            this.g_FCadLocalArm.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_FCadLocalArm.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_FCadLocalArm.AutoGenerateColumns = false;
            this.g_FCadLocalArm.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_FCadLocalArm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_FCadLocalArm.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_FCadLocalArm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_FCadLocalArm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_FCadLocalArm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.tplocalstrDataGridViewTextBoxColumn,
            this.stestterceiroboolDataGridViewCheckBoxColumn});
            this.g_FCadLocalArm.DataSource = this.BS_CadLocalArm;
            resources.ApplyResources(this.g_FCadLocalArm, "g_FCadLocalArm");
            this.g_FCadLocalArm.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_FCadLocalArm.Name = "g_FCadLocalArm";
            this.g_FCadLocalArm.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_FCadLocalArm.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_FCadLocalArm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_FCadLocalArm.TabStop = false;
            this.g_FCadLocalArm.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.g_FCadLocalArm_ColumnHeaderMouseClick);
            this.g_FCadLocalArm.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.g_FCadLocalArm_CellFormatting);
            // 
            // BN_CadLocalArm
            // 
            this.BN_CadLocalArm.AddNewItem = null;
            this.BN_CadLocalArm.BindingSource = this.BS_CadLocalArm;
            this.BN_CadLocalArm.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadLocalArm.CountItemFormat = "de {0}";
            this.BN_CadLocalArm.DeleteItem = null;
            resources.ApplyResources(this.BN_CadLocalArm, "BN_CadLocalArm");
            this.BN_CadLocalArm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadLocalArm.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadLocalArm.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadLocalArm.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadLocalArm.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadLocalArm.Name = "BN_CadLocalArm";
            this.BN_CadLocalArm.PositionItem = this.bindingNavigatorPositionItem;
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
            // TP_Local
            // 
            this.TP_Local.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_CadLocalArm, "Tp_Local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Local.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.TP_Local, "TP_Local");
            this.TP_Local.FormattingEnabled = true;
            this.TP_Local.Name = "TP_Local";
            this.TP_Local.NM_Alias = "a";
            this.TP_Local.NM_Campo = "Tipo Local";
            this.TP_Local.NM_Param = "@P_TP_LOCAL";
            this.TP_Local.ST_Gravar = true;
            this.TP_Local.ST_LimparCampo = true;
            this.TP_Local.ST_NotNull = true;
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // st_estterceiro
            // 
            resources.ApplyResources(this.st_estterceiro, "st_estterceiro");
            this.st_estterceiro.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadLocalArm, "St_estterceirobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_estterceiro.Name = "st_estterceiro";
            this.st_estterceiro.NM_Alias = "";
            this.st_estterceiro.NM_Campo = "";
            this.st_estterceiro.NM_Param = "";
            this.st_estterceiro.ST_Gravar = true;
            this.st_estterceiro.ST_LimparCampo = true;
            this.st_estterceiro.ST_NotNull = false;
            this.st_estterceiro.UseVisualStyleBackColor = true;
            this.st_estterceiro.Vl_False = "";
            this.st_estterceiro.Vl_True = "";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            resources.ApplyResources(this.statusDataGridViewTextBoxColumn, "statusDataGridViewTextBoxColumn");
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cd_local";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_local";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // tplocalstrDataGridViewTextBoxColumn
            // 
            this.tplocalstrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tplocalstrDataGridViewTextBoxColumn.DataPropertyName = "Tp_localstr";
            resources.ApplyResources(this.tplocalstrDataGridViewTextBoxColumn, "tplocalstrDataGridViewTextBoxColumn");
            this.tplocalstrDataGridViewTextBoxColumn.Name = "tplocalstrDataGridViewTextBoxColumn";
            this.tplocalstrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stestterceiroboolDataGridViewCheckBoxColumn
            // 
            this.stestterceiroboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stestterceiroboolDataGridViewCheckBoxColumn.DataPropertyName = "St_estterceirobool";
            resources.ApplyResources(this.stestterceiroboolDataGridViewCheckBoxColumn, "stestterceiroboolDataGridViewCheckBoxColumn");
            this.stestterceiroboolDataGridViewCheckBoxColumn.Name = "stestterceiroboolDataGridViewCheckBoxColumn";
            this.stestterceiroboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // TFCad_LocalArm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCad_LocalArm";
            this.Load += new System.EventHandler(this.TFCad_LocalArm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_LocalArm_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadLocalArm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_FCadLocalArm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadLocalArm)).EndInit();
            this.BN_CadLocalArm.ResumeLayout(false);
            this.BN_CadLocalArm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault CD_Local;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LABEL2;
        private Componentes.EditDefault DS_Local;
        private Componentes.DataGridDefault g_FCadLocalArm;
        private System.Windows.Forms.BindingNavigator BN_CadLocalArm;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource BS_CadLocalArm;
        public Componentes.ComboBoxDefault TP_Local;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDLocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSLocalDataGridViewTextBoxColumn;
        private Componentes.CheckBoxDefault st_estterceiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tplocalstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stestterceiroboolDataGridViewCheckBoxColumn;
    }
}