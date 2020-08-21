namespace Servico.Cadastros
{
    partial class TFCadOseTpOrdemxEtapa
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
            System.Windows.Forms.Label id_etapaLabel;
            System.Windows.Forms.Label tp_ordemLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadOseTpOrdemxEtapa));
            this.Tp_ordem = new Componentes.EditDefault(this.components);
            this.BS_CadOseTpOrdemxEtapa = new System.Windows.Forms.BindingSource(this.components);
            this.bb_idEtapa = new System.Windows.Forms.Button();
            this.bb_idTpordem = new System.Windows.Forms.Button();
            this.Ds_Etapa = new Componentes.EditDefault(this.components);
            this.Ds_TipoOrdem = new Componentes.EditDefault(this.components);
            this.g_ordem_X_Etapa = new Componentes.DataGridDefault(this.components);
            this.tpordemstrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstipoordemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idetapastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsetapaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Etapa = new Componentes.EditDefault(this.components);
            this.BN_TpOrdem_X_Etapa = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bb_ordenar = new System.Windows.Forms.Button();
            id_etapaLabel = new System.Windows.Forms.Label();
            tp_ordemLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadOseTpOrdemxEtapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ordem_X_Etapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TpOrdem_X_Etapa)).BeginInit();
            this.BN_TpOrdem_X_Etapa.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.bb_ordenar);
            this.pDados.Controls.Add(this.Id_Etapa);
            this.pDados.Controls.Add(this.Ds_TipoOrdem);
            this.pDados.Controls.Add(this.Ds_Etapa);
            this.pDados.Controls.Add(this.bb_idTpordem);
            this.pDados.Controls.Add(this.bb_idEtapa);
            this.pDados.Controls.Add(tp_ordemLabel);
            this.pDados.Controls.Add(this.Tp_ordem);
            this.pDados.Controls.Add(id_etapaLabel);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_ordem_X_Etapa);
            this.tpPadrao.Controls.Add(this.BN_TpOrdem_X_Etapa);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_TpOrdem_X_Etapa, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_ordem_X_Etapa, 0);
            // 
            // id_etapaLabel
            // 
            resources.ApplyResources(id_etapaLabel, "id_etapaLabel");
            id_etapaLabel.Name = "id_etapaLabel";
            // 
            // tp_ordemLabel
            // 
            resources.ApplyResources(tp_ordemLabel, "tp_ordemLabel");
            tp_ordemLabel.Name = "tp_ordemLabel";
            // 
            // Tp_ordem
            // 
            this.Tp_ordem.BackColor = System.Drawing.SystemColors.Window;
            this.Tp_ordem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tp_ordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Tp_ordem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadOseTpOrdemxEtapa, "Tp_ordemstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Tp_ordem, "Tp_ordem");
            this.Tp_ordem.Name = "Tp_ordem";
            this.Tp_ordem.NM_Alias = "a";
            this.Tp_ordem.NM_Campo = "tp_ordem";
            this.Tp_ordem.NM_CampoBusca = "tp_ordem";
            this.Tp_ordem.NM_Param = "@P_TP_ORDEM";
            this.Tp_ordem.QTD_Zero = 0;
            this.Tp_ordem.ST_AutoInc = false;
            this.Tp_ordem.ST_DisableAuto = false;
            this.Tp_ordem.ST_Float = false;
            this.Tp_ordem.ST_Gravar = true;
            this.Tp_ordem.ST_Int = true;
            this.Tp_ordem.ST_LimpaCampo = true;
            this.Tp_ordem.ST_NotNull = true;
            this.Tp_ordem.ST_PrimaryKey = false;
            this.Tp_ordem.TextOld = null;
            this.Tp_ordem.Leave += new System.EventHandler(this.Tp_ordem_Leave);
            // 
            // BS_CadOseTpOrdemxEtapa
            // 
            this.BS_CadOseTpOrdemxEtapa.DataSource = typeof(CamadaDados.Servicos.Cadastros.TList_TpOrdem_X_Etapa);
            // 
            // bb_idEtapa
            // 
            resources.ApplyResources(this.bb_idEtapa, "bb_idEtapa");
            this.bb_idEtapa.Name = "bb_idEtapa";
            this.bb_idEtapa.UseVisualStyleBackColor = true;
            this.bb_idEtapa.Click += new System.EventHandler(this.bb_idEtapa_Click);
            // 
            // bb_idTpordem
            // 
            resources.ApplyResources(this.bb_idTpordem, "bb_idTpordem");
            this.bb_idTpordem.Name = "bb_idTpordem";
            this.bb_idTpordem.UseVisualStyleBackColor = true;
            this.bb_idTpordem.Click += new System.EventHandler(this.bb_idTpordem_Click);
            // 
            // Ds_Etapa
            // 
            this.Ds_Etapa.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_Etapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_Etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_Etapa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadOseTpOrdemxEtapa, "Ds_etapa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Ds_Etapa, "Ds_Etapa");
            this.Ds_Etapa.Name = "Ds_Etapa";
            this.Ds_Etapa.NM_Alias = "c";
            this.Ds_Etapa.NM_Campo = "ds_etapa";
            this.Ds_Etapa.NM_CampoBusca = "ds_etapa";
            this.Ds_Etapa.NM_Param = "@P_DS_ETAPA";
            this.Ds_Etapa.QTD_Zero = 0;
            this.Ds_Etapa.ST_AutoInc = false;
            this.Ds_Etapa.ST_DisableAuto = false;
            this.Ds_Etapa.ST_Float = false;
            this.Ds_Etapa.ST_Gravar = false;
            this.Ds_Etapa.ST_Int = false;
            this.Ds_Etapa.ST_LimpaCampo = true;
            this.Ds_Etapa.ST_NotNull = false;
            this.Ds_Etapa.ST_PrimaryKey = false;
            this.Ds_Etapa.TextOld = null;
            // 
            // Ds_TipoOrdem
            // 
            this.Ds_TipoOrdem.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_TipoOrdem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_TipoOrdem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_TipoOrdem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadOseTpOrdemxEtapa, "Ds_tipoordem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Ds_TipoOrdem, "Ds_TipoOrdem");
            this.Ds_TipoOrdem.Name = "Ds_TipoOrdem";
            this.Ds_TipoOrdem.NM_Alias = "";
            this.Ds_TipoOrdem.NM_Campo = "ds_tipoordem";
            this.Ds_TipoOrdem.NM_CampoBusca = "ds_tipoordem";
            this.Ds_TipoOrdem.NM_Param = "@P_DS_TIPOORDEM";
            this.Ds_TipoOrdem.QTD_Zero = 0;
            this.Ds_TipoOrdem.ST_AutoInc = false;
            this.Ds_TipoOrdem.ST_DisableAuto = false;
            this.Ds_TipoOrdem.ST_Float = false;
            this.Ds_TipoOrdem.ST_Gravar = false;
            this.Ds_TipoOrdem.ST_Int = false;
            this.Ds_TipoOrdem.ST_LimpaCampo = true;
            this.Ds_TipoOrdem.ST_NotNull = false;
            this.Ds_TipoOrdem.ST_PrimaryKey = false;
            this.Ds_TipoOrdem.TextOld = null;
            // 
            // g_ordem_X_Etapa
            // 
            this.g_ordem_X_Etapa.AllowUserToAddRows = false;
            this.g_ordem_X_Etapa.AllowUserToDeleteRows = false;
            this.g_ordem_X_Etapa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_ordem_X_Etapa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_ordem_X_Etapa.AutoGenerateColumns = false;
            this.g_ordem_X_Etapa.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_ordem_X_Etapa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_ordem_X_Etapa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_ordem_X_Etapa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_ordem_X_Etapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_ordem_X_Etapa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tpordemstrDataGridViewTextBoxColumn,
            this.dstipoordemDataGridViewTextBoxColumn,
            this.idetapastrDataGridViewTextBoxColumn,
            this.dsetapaDataGridViewTextBoxColumn});
            this.g_ordem_X_Etapa.DataSource = this.BS_CadOseTpOrdemxEtapa;
            resources.ApplyResources(this.g_ordem_X_Etapa, "g_ordem_X_Etapa");
            this.g_ordem_X_Etapa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_ordem_X_Etapa.Name = "g_ordem_X_Etapa";
            this.g_ordem_X_Etapa.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_ordem_X_Etapa.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_ordem_X_Etapa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_ordem_X_Etapa.TabStop = false;
            // 
            // tpordemstrDataGridViewTextBoxColumn
            // 
            this.tpordemstrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpordemstrDataGridViewTextBoxColumn.DataPropertyName = "Tp_ordemstr";
            resources.ApplyResources(this.tpordemstrDataGridViewTextBoxColumn, "tpordemstrDataGridViewTextBoxColumn");
            this.tpordemstrDataGridViewTextBoxColumn.Name = "tpordemstrDataGridViewTextBoxColumn";
            this.tpordemstrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dstipoordemDataGridViewTextBoxColumn
            // 
            this.dstipoordemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstipoordemDataGridViewTextBoxColumn.DataPropertyName = "Ds_tipoordem";
            resources.ApplyResources(this.dstipoordemDataGridViewTextBoxColumn, "dstipoordemDataGridViewTextBoxColumn");
            this.dstipoordemDataGridViewTextBoxColumn.Name = "dstipoordemDataGridViewTextBoxColumn";
            this.dstipoordemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idetapastrDataGridViewTextBoxColumn
            // 
            this.idetapastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idetapastrDataGridViewTextBoxColumn.DataPropertyName = "Id_etapastr";
            resources.ApplyResources(this.idetapastrDataGridViewTextBoxColumn, "idetapastrDataGridViewTextBoxColumn");
            this.idetapastrDataGridViewTextBoxColumn.Name = "idetapastrDataGridViewTextBoxColumn";
            this.idetapastrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsetapaDataGridViewTextBoxColumn
            // 
            this.dsetapaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsetapaDataGridViewTextBoxColumn.DataPropertyName = "Ds_etapa";
            resources.ApplyResources(this.dsetapaDataGridViewTextBoxColumn, "dsetapaDataGridViewTextBoxColumn");
            this.dsetapaDataGridViewTextBoxColumn.Name = "dsetapaDataGridViewTextBoxColumn";
            this.dsetapaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Id_Etapa
            // 
            this.Id_Etapa.BackColor = System.Drawing.SystemColors.Window;
            this.Id_Etapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Id_Etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Id_Etapa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadOseTpOrdemxEtapa, "Id_etapastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Id_Etapa, "Id_Etapa");
            this.Id_Etapa.Name = "Id_Etapa";
            this.Id_Etapa.NM_Alias = "a";
            this.Id_Etapa.NM_Campo = "id_etapa";
            this.Id_Etapa.NM_CampoBusca = "id_etapa";
            this.Id_Etapa.NM_Param = "@P_ID_ETAPA";
            this.Id_Etapa.QTD_Zero = 0;
            this.Id_Etapa.ST_AutoInc = false;
            this.Id_Etapa.ST_DisableAuto = false;
            this.Id_Etapa.ST_Float = false;
            this.Id_Etapa.ST_Gravar = true;
            this.Id_Etapa.ST_Int = true;
            this.Id_Etapa.ST_LimpaCampo = true;
            this.Id_Etapa.ST_NotNull = true;
            this.Id_Etapa.ST_PrimaryKey = false;
            this.Id_Etapa.TextOld = null;
            this.Id_Etapa.Leave += new System.EventHandler(this.Id_Etapa_Leave);
            // 
            // BN_TpOrdem_X_Etapa
            // 
            this.BN_TpOrdem_X_Etapa.AddNewItem = null;
            this.BN_TpOrdem_X_Etapa.BindingSource = this.BS_CadOseTpOrdemxEtapa;
            this.BN_TpOrdem_X_Etapa.CountItem = this.bindingNavigatorCountItem;
            this.BN_TpOrdem_X_Etapa.DeleteItem = null;
            resources.ApplyResources(this.BN_TpOrdem_X_Etapa, "BN_TpOrdem_X_Etapa");
            this.BN_TpOrdem_X_Etapa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_TpOrdem_X_Etapa.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_TpOrdem_X_Etapa.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_TpOrdem_X_Etapa.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_TpOrdem_X_Etapa.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_TpOrdem_X_Etapa.Name = "BN_TpOrdem_X_Etapa";
            this.BN_TpOrdem_X_Etapa.PositionItem = this.bindingNavigatorPositionItem;
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
            // bb_ordenar
            // 
            resources.ApplyResources(this.bb_ordenar, "bb_ordenar");
            this.bb_ordenar.Name = "bb_ordenar";
            this.bb_ordenar.UseVisualStyleBackColor = true;
            this.bb_ordenar.Click += new System.EventHandler(this.bb_ordenar_Click);
            // 
            // TFCadOseTpOrdemxEtapa
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadOseTpOrdemxEtapa";
            this.Load += new System.EventHandler(this.TFCadOseTpOrdemxEtapa_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadOseTpOrdemxEtapa_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadOseTpOrdemxEtapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ordem_X_Etapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TpOrdem_X_Etapa)).EndInit();
            this.BN_TpOrdem_X_Etapa.ResumeLayout(false);
            this.BN_TpOrdem_X_Etapa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault Tp_ordem;
        private System.Windows.Forms.BindingSource BS_CadOseTpOrdemxEtapa;
        private Componentes.EditDefault Ds_TipoOrdem;
        private Componentes.EditDefault Ds_Etapa;
        private System.Windows.Forms.Button bb_idTpordem;
        private System.Windows.Forms.Button bb_idEtapa;
        private Componentes.DataGridDefault g_ordem_X_Etapa;
        private Componentes.EditDefault Id_Etapa;
        private System.Windows.Forms.BindingNavigator BN_TpOrdem_X_Etapa;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpordemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idetapaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpordemstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstipoordemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idetapastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsetapaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button bb_ordenar;
    }
}
