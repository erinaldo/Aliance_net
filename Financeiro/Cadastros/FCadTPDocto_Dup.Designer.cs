namespace Financeiro.Cadastros
{
    partial class TFCadTPDocto_Dup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTPDocto_Dup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LB_Tp_Docto = new System.Windows.Forms.Label();
            this.LB_DS_TpDocto = new System.Windows.Forms.Label();
            this.Tp_Docto = new Componentes.EditDefault(this.components);
            this.BS_TpDocumentoDup = new System.Windows.Forms.BindingSource(this.components);
            this.DS_TpDocto = new Componentes.EditDefault(this.components);
            this.st_duplicata = new Componentes.CheckBoxDefault(this.components);
            this.tpdoctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpdoctoStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstpdoctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stativarsequenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdsequenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stregistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_tpdoctoDup = new Componentes.DataGridDefault(this.components);
            this.tpdoctoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstpdoctoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_duplicatabool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BN_TpDoctoDup = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_TpDocumentoDup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_tpdoctoDup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TpDoctoDup)).BeginInit();
            this.BN_TpDoctoDup.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.panelDados1);
            this.pDados.Controls.Add(this.LB_Tp_Docto);
            this.pDados.Controls.Add(this.LB_DS_TpDocto);
            this.pDados.Controls.Add(this.Tp_Docto);
            this.pDados.Controls.Add(this.DS_TpDocto);
            this.pDados.NM_ProcDeletar = "EXCLUI_FIN_TPDOCTO_DUP";
            this.pDados.NM_ProcGravar = "IA_FIN_TPDOCTO_DUP";
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_tpdoctoDup);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_tpdoctoDup, 0);
            // 
            // LB_Tp_Docto
            // 
            resources.ApplyResources(this.LB_Tp_Docto, "LB_Tp_Docto");
            this.LB_Tp_Docto.Name = "LB_Tp_Docto";
            // 
            // LB_DS_TpDocto
            // 
            resources.ApplyResources(this.LB_DS_TpDocto, "LB_DS_TpDocto");
            this.LB_DS_TpDocto.Name = "LB_DS_TpDocto";
            // 
            // Tp_Docto
            // 
            this.Tp_Docto.BackColor = System.Drawing.SystemColors.Window;
            this.Tp_Docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Tp_Docto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TpDocumentoDup, "Tp_docto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Tp_Docto, "Tp_Docto");
            this.Tp_Docto.Name = "Tp_Docto";
            this.Tp_Docto.NM_Alias = "";
            this.Tp_Docto.NM_Campo = "Tp_Docto";
            this.Tp_Docto.NM_CampoBusca = "Tp_Docto";
            this.Tp_Docto.NM_Param = "@P_TP_DOCTO";
            this.Tp_Docto.QTD_Zero = 0;
            this.Tp_Docto.ST_AutoInc = false;
            this.Tp_Docto.ST_DisableAuto = true;
            this.Tp_Docto.ST_Float = false;
            this.Tp_Docto.ST_Gravar = true;
            this.Tp_Docto.ST_Int = false;
            this.Tp_Docto.ST_LimpaCampo = true;
            this.Tp_Docto.ST_NotNull = true;
            this.Tp_Docto.ST_PrimaryKey = true;
            // 
            // BS_TpDocumentoDup
            // 
            this.BS_TpDocumentoDup.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadTpDoctoDup);
            // 
            // DS_TpDocto
            // 
            this.DS_TpDocto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TpDocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TpDocto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TpDocumentoDup, "Ds_tpdocto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_TpDocto, "DS_TpDocto");
            this.DS_TpDocto.Name = "DS_TpDocto";
            this.DS_TpDocto.NM_Alias = "";
            this.DS_TpDocto.NM_Campo = "DS_TpDocto";
            this.DS_TpDocto.NM_CampoBusca = "DS_TpDocto";
            this.DS_TpDocto.NM_Param = "@P_DS_TPDOCTO";
            this.DS_TpDocto.QTD_Zero = 0;
            this.DS_TpDocto.ST_AutoInc = false;
            this.DS_TpDocto.ST_DisableAuto = false;
            this.DS_TpDocto.ST_Float = false;
            this.DS_TpDocto.ST_Gravar = true;
            this.DS_TpDocto.ST_Int = false;
            this.DS_TpDocto.ST_LimpaCampo = true;
            this.DS_TpDocto.ST_NotNull = false;
            this.DS_TpDocto.ST_PrimaryKey = false;
            // 
            // st_duplicata
            // 
            resources.ApplyResources(this.st_duplicata, "st_duplicata");
            this.st_duplicata.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.BS_TpDocumentoDup, "St_duplicatabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_duplicata.Name = "st_duplicata";
            this.st_duplicata.NM_Alias = "";
            this.st_duplicata.NM_Campo = "ST_AtivarSequencia";
            this.st_duplicata.NM_Param = "@P_ST_ATIVARSEQUENCIA";
            this.st_duplicata.ST_Gravar = true;
            this.st_duplicata.ST_LimparCampo = true;
            this.st_duplicata.ST_NotNull = false;
            this.st_duplicata.UseVisualStyleBackColor = true;
            this.st_duplicata.Vl_False = "N";
            this.st_duplicata.Vl_True = "S";
            // 
            // tpdoctoDataGridViewTextBoxColumn
            // 
            this.tpdoctoDataGridViewTextBoxColumn.DataPropertyName = "Tp_docto";
            resources.ApplyResources(this.tpdoctoDataGridViewTextBoxColumn, "tpdoctoDataGridViewTextBoxColumn");
            this.tpdoctoDataGridViewTextBoxColumn.Name = "tpdoctoDataGridViewTextBoxColumn";
            this.tpdoctoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpdoctoStringDataGridViewTextBoxColumn
            // 
            this.tpdoctoStringDataGridViewTextBoxColumn.DataPropertyName = "Tp_doctoString";
            resources.ApplyResources(this.tpdoctoStringDataGridViewTextBoxColumn, "tpdoctoStringDataGridViewTextBoxColumn");
            this.tpdoctoStringDataGridViewTextBoxColumn.Name = "tpdoctoStringDataGridViewTextBoxColumn";
            this.tpdoctoStringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dstpdoctoDataGridViewTextBoxColumn
            // 
            this.dstpdoctoDataGridViewTextBoxColumn.DataPropertyName = "Ds_tpdocto";
            resources.ApplyResources(this.dstpdoctoDataGridViewTextBoxColumn, "dstpdoctoDataGridViewTextBoxColumn");
            this.dstpdoctoDataGridViewTextBoxColumn.Name = "dstpdoctoDataGridViewTextBoxColumn";
            this.dstpdoctoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stativarsequenciaDataGridViewTextBoxColumn
            // 
            this.stativarsequenciaDataGridViewTextBoxColumn.DataPropertyName = "St_ativarsequencia";
            resources.ApplyResources(this.stativarsequenciaDataGridViewTextBoxColumn, "stativarsequenciaDataGridViewTextBoxColumn");
            this.stativarsequenciaDataGridViewTextBoxColumn.Name = "stativarsequenciaDataGridViewTextBoxColumn";
            this.stativarsequenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdsequenciaDataGridViewTextBoxColumn
            // 
            this.cdsequenciaDataGridViewTextBoxColumn.DataPropertyName = "Cd_sequencia";
            resources.ApplyResources(this.cdsequenciaDataGridViewTextBoxColumn, "cdsequenciaDataGridViewTextBoxColumn");
            this.cdsequenciaDataGridViewTextBoxColumn.Name = "cdsequenciaDataGridViewTextBoxColumn";
            this.cdsequenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stregistroDataGridViewTextBoxColumn
            // 
            this.stregistroDataGridViewTextBoxColumn.DataPropertyName = "St_registro";
            resources.ApplyResources(this.stregistroDataGridViewTextBoxColumn, "stregistroDataGridViewTextBoxColumn");
            this.stregistroDataGridViewTextBoxColumn.Name = "stregistroDataGridViewTextBoxColumn";
            this.stregistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // g_tpdoctoDup
            // 
            this.g_tpdoctoDup.AllowUserToAddRows = false;
            this.g_tpdoctoDup.AllowUserToDeleteRows = false;
            this.g_tpdoctoDup.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_tpdoctoDup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_tpdoctoDup.AutoGenerateColumns = false;
            this.g_tpdoctoDup.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_tpdoctoDup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_tpdoctoDup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_tpdoctoDup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_tpdoctoDup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_tpdoctoDup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tpdoctoDataGridViewTextBoxColumn1,
            this.dstpdoctoDataGridViewTextBoxColumn1,
            this.St_duplicatabool});
            this.g_tpdoctoDup.DataSource = this.BS_TpDocumentoDup;
            resources.ApplyResources(this.g_tpdoctoDup, "g_tpdoctoDup");
            this.g_tpdoctoDup.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_tpdoctoDup.Name = "g_tpdoctoDup";
            this.g_tpdoctoDup.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_tpdoctoDup.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // tpdoctoDataGridViewTextBoxColumn1
            // 
            this.tpdoctoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpdoctoDataGridViewTextBoxColumn1.DataPropertyName = "Tp_docto";
            resources.ApplyResources(this.tpdoctoDataGridViewTextBoxColumn1, "tpdoctoDataGridViewTextBoxColumn1");
            this.tpdoctoDataGridViewTextBoxColumn1.Name = "tpdoctoDataGridViewTextBoxColumn1";
            this.tpdoctoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dstpdoctoDataGridViewTextBoxColumn1
            // 
            this.dstpdoctoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstpdoctoDataGridViewTextBoxColumn1.DataPropertyName = "Ds_tpdocto";
            resources.ApplyResources(this.dstpdoctoDataGridViewTextBoxColumn1, "dstpdoctoDataGridViewTextBoxColumn1");
            this.dstpdoctoDataGridViewTextBoxColumn1.Name = "dstpdoctoDataGridViewTextBoxColumn1";
            this.dstpdoctoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // St_duplicatabool
            // 
            this.St_duplicatabool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_duplicatabool.DataPropertyName = "St_duplicatabool";
            resources.ApplyResources(this.St_duplicatabool, "St_duplicatabool");
            this.St_duplicatabool.Name = "St_duplicatabool";
            this.St_duplicatabool.ReadOnly = true;
            // 
            // BN_TpDoctoDup
            // 
            this.BN_TpDoctoDup.AddNewItem = null;
            this.BN_TpDoctoDup.BindingSource = this.BS_TpDocumentoDup;
            this.BN_TpDoctoDup.CountItem = this.bindingNavigatorCountItem;
            this.BN_TpDoctoDup.DeleteItem = null;
            resources.ApplyResources(this.BN_TpDoctoDup, "BN_TpDoctoDup");
            this.BN_TpDoctoDup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_TpDoctoDup.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_TpDoctoDup.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_TpDoctoDup.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_TpDoctoDup.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_TpDoctoDup.Name = "BN_TpDoctoDup";
            this.BN_TpDoctoDup.PositionItem = this.bindingNavigatorPositionItem;
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
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.st_duplicata);
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // TFCadTPDocto_Dup
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.BN_TpDoctoDup);
            this.Name = "TFCadTPDocto_Dup";
            this.Load += new System.EventHandler(this.TFCadTPDocto_Dup_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadTPDocto_Dup_FormClosing);
            this.Controls.SetChildIndex(this.tcCentral, 0);
            this.Controls.SetChildIndex(this.BN_TpDoctoDup, 0);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BS_TpDocumentoDup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_tpdoctoDup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TpDoctoDup)).EndInit();
            this.BN_TpDoctoDup.ResumeLayout(false);
            this.BN_TpDoctoDup.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_Tp_Docto;
        private System.Windows.Forms.Label LB_DS_TpDocto;
        private Componentes.EditDefault Tp_Docto;
        private Componentes.EditDefault DS_TpDocto;
        private Componentes.CheckBoxDefault st_duplicata;
        private System.Windows.Forms.BindingSource BS_TpDocumentoDup;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpdoctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpdoctoStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstpdoctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stativarsequenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdsequenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stregistroDataGridViewTextBoxColumn;
        private Componentes.DataGridDefault g_tpdoctoDup;
        private System.Windows.Forms.BindingNavigator BN_TpDoctoDup;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn stativarsequenciaDataGridViewTextBoxColumn1;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpdoctoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstpdoctoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_duplicatabool;



    }
}
