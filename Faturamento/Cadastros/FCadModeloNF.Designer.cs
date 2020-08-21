namespace Faturamento.Cadastros
{
    partial class TFCadModeloNF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadModeloNF));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FCD_Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDS_Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FQT_ItensNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FTamanhoNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FTam_DadosAdic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FST_FonteCompacta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LB_CD_Modelo = new System.Windows.Forms.Label();
            this.LB_DS_Modelo = new System.Windows.Forms.Label();
            this.CD_Modelo = new Componentes.EditDefault(this.components);
            this.BS_CadModeloNF = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Modelo = new Componentes.EditDefault(this.components);
            this.BN_CadModeloNF = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.grid_CadModeloNF = new Componentes.DataGridDefault(this.components);
            this.cDModeloDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDModeloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTItensNotaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tamDadosAdicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadModeloNF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadModeloNF)).BeginInit();
            this.BN_CadModeloNF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_CadModeloNF)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.LB_CD_Modelo);
            this.pDados.Controls.Add(this.LB_DS_Modelo);
            this.pDados.Controls.Add(this.CD_Modelo);
            this.pDados.Controls.Add(this.DS_Modelo);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.NM_ProcDeletar = "EXCLUI_FAT_MODELONF";
            this.pDados.NM_ProcGravar = "IA_FAT_MODELONF";
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.grid_CadModeloNF);
            this.tpPadrao.Controls.Add(this.BN_CadModeloNF);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadModeloNF, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.grid_CadModeloNF, 0);
            // 
            // FCD_Modelo
            // 
            this.FCD_Modelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FCD_Modelo.DataPropertyName = "CD_Modelo";
            resources.ApplyResources(this.FCD_Modelo, "FCD_Modelo");
            this.FCD_Modelo.Name = "FCD_Modelo";
            this.FCD_Modelo.ReadOnly = true;
            // 
            // FDS_Modelo
            // 
            this.FDS_Modelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FDS_Modelo.DataPropertyName = "DS_Modelo";
            resources.ApplyResources(this.FDS_Modelo, "FDS_Modelo");
            this.FDS_Modelo.Name = "FDS_Modelo";
            this.FDS_Modelo.ReadOnly = true;
            // 
            // FQT_ItensNota
            // 
            this.FQT_ItensNota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FQT_ItensNota.DataPropertyName = "QT_ItensNota";
            resources.ApplyResources(this.FQT_ItensNota, "FQT_ItensNota");
            this.FQT_ItensNota.Name = "FQT_ItensNota";
            this.FQT_ItensNota.ReadOnly = true;
            // 
            // FTamanhoNota
            // 
            this.FTamanhoNota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FTamanhoNota.DataPropertyName = "TamanhoNota";
            resources.ApplyResources(this.FTamanhoNota, "FTamanhoNota");
            this.FTamanhoNota.Name = "FTamanhoNota";
            this.FTamanhoNota.ReadOnly = true;
            // 
            // FTam_DadosAdic
            // 
            this.FTam_DadosAdic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FTam_DadosAdic.DataPropertyName = "Tam_DadosAdic";
            resources.ApplyResources(this.FTam_DadosAdic, "FTam_DadosAdic");
            this.FTam_DadosAdic.Name = "FTam_DadosAdic";
            this.FTam_DadosAdic.ReadOnly = true;
            // 
            // FST_FonteCompacta
            // 
            this.FST_FonteCompacta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FST_FonteCompacta.DataPropertyName = "ST_FonteCompacta";
            resources.ApplyResources(this.FST_FonteCompacta, "FST_FonteCompacta");
            this.FST_FonteCompacta.Name = "FST_FonteCompacta";
            this.FST_FonteCompacta.ReadOnly = true;
            // 
            // LB_CD_Modelo
            // 
            resources.ApplyResources(this.LB_CD_Modelo, "LB_CD_Modelo");
            this.LB_CD_Modelo.Name = "LB_CD_Modelo";
            // 
            // LB_DS_Modelo
            // 
            resources.ApplyResources(this.LB_DS_Modelo, "LB_DS_Modelo");
            this.LB_DS_Modelo.Name = "LB_DS_Modelo";
            // 
            // CD_Modelo
            // 
            this.CD_Modelo.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Modelo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadModeloNF, "CD_Modelo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Modelo, "CD_Modelo");
            this.CD_Modelo.Name = "CD_Modelo";
            this.CD_Modelo.NM_Alias = "a";
            this.CD_Modelo.NM_Campo = "CD_Modelo";
            this.CD_Modelo.NM_CampoBusca = "CD_Modelo";
            this.CD_Modelo.NM_Param = "@P_CD_MODELO";
            this.CD_Modelo.QTD_Zero = 0;
            this.CD_Modelo.ST_AutoInc = false;
            this.CD_Modelo.ST_DisableAuto = true;
            this.CD_Modelo.ST_Float = false;
            this.CD_Modelo.ST_Gravar = true;
            this.CD_Modelo.ST_Int = false;
            this.CD_Modelo.ST_LimpaCampo = true;
            this.CD_Modelo.ST_NotNull = true;
            this.CD_Modelo.ST_PrimaryKey = true;
            // 
            // BS_CadModeloNF
            // 
            this.BS_CadModeloNF.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CadModeloNF);
            // 
            // DS_Modelo
            // 
            this.DS_Modelo.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Modelo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadModeloNF, "DS_Modelo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Modelo, "DS_Modelo");
            this.DS_Modelo.Name = "DS_Modelo";
            this.DS_Modelo.NM_Alias = "a";
            this.DS_Modelo.NM_Campo = "DS_Modelo";
            this.DS_Modelo.NM_CampoBusca = "DS_Modelo";
            this.DS_Modelo.NM_Param = "@P_DS_MODELO";
            this.DS_Modelo.QTD_Zero = 0;
            this.DS_Modelo.ST_AutoInc = false;
            this.DS_Modelo.ST_DisableAuto = false;
            this.DS_Modelo.ST_Float = false;
            this.DS_Modelo.ST_Gravar = true;
            this.DS_Modelo.ST_Int = false;
            this.DS_Modelo.ST_LimpaCampo = true;
            this.DS_Modelo.ST_NotNull = true;
            this.DS_Modelo.ST_PrimaryKey = false;
            // 
            // BN_CadModeloNF
            // 
            this.BN_CadModeloNF.AddNewItem = null;
            this.BN_CadModeloNF.BindingSource = this.BS_CadModeloNF;
            this.BN_CadModeloNF.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadModeloNF.CountItemFormat = "de {0}";
            this.BN_CadModeloNF.DeleteItem = null;
            resources.ApplyResources(this.BN_CadModeloNF, "BN_CadModeloNF");
            this.BN_CadModeloNF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadModeloNF.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadModeloNF.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadModeloNF.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadModeloNF.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadModeloNF.Name = "BN_CadModeloNF";
            this.BN_CadModeloNF.PositionItem = this.bindingNavigatorPositionItem;
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
            // grid_CadModeloNF
            // 
            this.grid_CadModeloNF.AllowUserToAddRows = false;
            this.grid_CadModeloNF.AllowUserToDeleteRows = false;
            this.grid_CadModeloNF.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.grid_CadModeloNF.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_CadModeloNF.AutoGenerateColumns = false;
            this.grid_CadModeloNF.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid_CadModeloNF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_CadModeloNF.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_CadModeloNF.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_CadModeloNF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_CadModeloNF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDModeloDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn1});
            this.grid_CadModeloNF.DataSource = this.BS_CadModeloNF;
            resources.ApplyResources(this.grid_CadModeloNF, "grid_CadModeloNF");
            this.grid_CadModeloNF.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grid_CadModeloNF.Name = "grid_CadModeloNF";
            this.grid_CadModeloNF.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_CadModeloNF.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // cDModeloDataGridViewTextBoxColumn1
            // 
            this.cDModeloDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDModeloDataGridViewTextBoxColumn1.DataPropertyName = "CD_Modelo";
            resources.ApplyResources(this.cDModeloDataGridViewTextBoxColumn1, "cDModeloDataGridViewTextBoxColumn1");
            this.cDModeloDataGridViewTextBoxColumn1.Name = "cDModeloDataGridViewTextBoxColumn1";
            this.cDModeloDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DS_Modelo";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cDModeloDataGridViewTextBoxColumn
            // 
            this.cDModeloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDModeloDataGridViewTextBoxColumn.DataPropertyName = "CD_Modelo";
            resources.ApplyResources(this.cDModeloDataGridViewTextBoxColumn, "cDModeloDataGridViewTextBoxColumn");
            this.cDModeloDataGridViewTextBoxColumn.Name = "cDModeloDataGridViewTextBoxColumn";
            this.cDModeloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qTItensNotaDataGridViewTextBoxColumn
            // 
            this.qTItensNotaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qTItensNotaDataGridViewTextBoxColumn.DataPropertyName = "QT_ItensNota";
            resources.ApplyResources(this.qTItensNotaDataGridViewTextBoxColumn, "qTItensNotaDataGridViewTextBoxColumn");
            this.qTItensNotaDataGridViewTextBoxColumn.Name = "qTItensNotaDataGridViewTextBoxColumn";
            this.qTItensNotaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tamDadosAdicDataGridViewTextBoxColumn
            // 
            this.tamDadosAdicDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tamDadosAdicDataGridViewTextBoxColumn.DataPropertyName = "Tam_DadosAdic";
            resources.ApplyResources(this.tamDadosAdicDataGridViewTextBoxColumn, "tamDadosAdicDataGridViewTextBoxColumn");
            this.tamDadosAdicDataGridViewTextBoxColumn.Name = "tamDadosAdicDataGridViewTextBoxColumn";
            this.tamDadosAdicDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCadModeloNF
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadModeloNF";
            this.Load += new System.EventHandler(this.TFCad_ModeloNF_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadModeloNF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadModeloNF)).EndInit();
            this.BN_CadModeloNF.ResumeLayout(false);
            this.BN_CadModeloNF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_CadModeloNF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_CD_Modelo;
        private System.Windows.Forms.Label LB_DS_Modelo;
        private Componentes.EditDefault CD_Modelo;
        private Componentes.EditDefault DS_Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCD_Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDS_Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FQT_ItensNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn FTamanhoNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn FTam_DadosAdic;
        private System.Windows.Forms.DataGridViewTextBoxColumn FST_FonteCompacta;
        private System.Windows.Forms.BindingNavigator BN_CadModeloNF;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource BS_CadModeloNF;
        private Componentes.DataGridDefault grid_CadModeloNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDModeloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTItensNotaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamDadosAdicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTItensNotaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamDadosAdicDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDModeloDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

    }
}
