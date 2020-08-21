namespace Servico.Cadastros
{
    partial class TFCadOseEtapaOrdem
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
            System.Windows.Forms.Label ds_etapaLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadOseEtapaOrdem));
            this.Ds_etapa = new Componentes.EditDefault(this.components);
            this.BS_CadOseEtapaOrdem = new System.Windows.Forms.BindingSource(this.components);
            this.g_etapaOrdem = new Componentes.DataGridDefault(this.components);
            this.idetapastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stiniciarOSboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stfinalizarOSboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stetapaorcamentoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stenvterceiroboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BN_EtapaOrdem = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_etapa = new Componentes.EditDefault(this.components);
            this.St_IniciarOs = new Componentes.CheckBoxDefault(this.components);
            this.St_FinalizarOs = new Componentes.CheckBoxDefault(this.components);
            this.St_envterceiro = new Componentes.CheckBoxDefault(this.components);
            this.pDetalhes = new Componentes.PanelDados(this.components);
            this.st_etapaorcamento = new Componentes.CheckBoxDefault(this.components);
            id_etapaLabel = new System.Windows.Forms.Label();
            ds_etapaLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadOseEtapaOrdem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_etapaOrdem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_EtapaOrdem)).BeginInit();
            this.BN_EtapaOrdem.SuspendLayout();
            this.pDetalhes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.pDetalhes);
            this.pDados.Controls.Add(this.id_etapa);
            this.pDados.Controls.Add(ds_etapaLabel);
            this.pDados.Controls.Add(this.Ds_etapa);
            this.pDados.Controls.Add(id_etapaLabel);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_etapaOrdem);
            this.tpPadrao.Controls.Add(this.BN_EtapaOrdem);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_EtapaOrdem, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_etapaOrdem, 0);
            // 
            // id_etapaLabel
            // 
            resources.ApplyResources(id_etapaLabel, "id_etapaLabel");
            id_etapaLabel.Name = "id_etapaLabel";
            // 
            // ds_etapaLabel
            // 
            resources.ApplyResources(ds_etapaLabel, "ds_etapaLabel");
            ds_etapaLabel.Name = "ds_etapaLabel";
            // 
            // Ds_etapa
            // 
            this.Ds_etapa.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_etapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_etapa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadOseEtapaOrdem, "Ds_etapa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Ds_etapa, "Ds_etapa");
            this.Ds_etapa.Name = "Ds_etapa";
            this.Ds_etapa.NM_Alias = "a";
            this.Ds_etapa.NM_Campo = "Ds. Etapa";
            this.Ds_etapa.NM_CampoBusca = "ds_etapa";
            this.Ds_etapa.NM_Param = "@P_DS_ETAPA";
            this.Ds_etapa.QTD_Zero = 0;
            this.Ds_etapa.ST_AutoInc = false;
            this.Ds_etapa.ST_DisableAuto = false;
            this.Ds_etapa.ST_Float = false;
            this.Ds_etapa.ST_Gravar = true;
            this.Ds_etapa.ST_Int = false;
            this.Ds_etapa.ST_LimpaCampo = true;
            this.Ds_etapa.ST_NotNull = false;
            this.Ds_etapa.ST_PrimaryKey = false;
            this.Ds_etapa.TextOld = null;
            // 
            // BS_CadOseEtapaOrdem
            // 
            this.BS_CadOseEtapaOrdem.DataSource = typeof(CamadaDados.Servicos.Cadastros.TList_EtapaOrdem);
            this.BS_CadOseEtapaOrdem.PositionChanged += new System.EventHandler(this.BS_CadOseEtapaOrdem_PositionChanged);
            // 
            // g_etapaOrdem
            // 
            this.g_etapaOrdem.AllowUserToAddRows = false;
            this.g_etapaOrdem.AllowUserToDeleteRows = false;
            this.g_etapaOrdem.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_etapaOrdem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_etapaOrdem.AutoGenerateColumns = false;
            this.g_etapaOrdem.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_etapaOrdem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_etapaOrdem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_etapaOrdem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_etapaOrdem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_etapaOrdem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idetapastrDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.stiniciarOSboolDataGridViewCheckBoxColumn,
            this.stfinalizarOSboolDataGridViewCheckBoxColumn,
            this.stetapaorcamentoboolDataGridViewCheckBoxColumn,
            this.stenvterceiroboolDataGridViewCheckBoxColumn});
            this.g_etapaOrdem.DataSource = this.BS_CadOseEtapaOrdem;
            resources.ApplyResources(this.g_etapaOrdem, "g_etapaOrdem");
            this.g_etapaOrdem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_etapaOrdem.Name = "g_etapaOrdem";
            this.g_etapaOrdem.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_etapaOrdem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_etapaOrdem.TabStop = false;
            // 
            // idetapastrDataGridViewTextBoxColumn
            // 
            this.idetapastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idetapastrDataGridViewTextBoxColumn.DataPropertyName = "Id_etapastr";
            resources.ApplyResources(this.idetapastrDataGridViewTextBoxColumn, "idetapastrDataGridViewTextBoxColumn");
            this.idetapastrDataGridViewTextBoxColumn.Name = "idetapastrDataGridViewTextBoxColumn";
            this.idetapastrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_etapa";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // stiniciarOSboolDataGridViewCheckBoxColumn
            // 
            this.stiniciarOSboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stiniciarOSboolDataGridViewCheckBoxColumn.DataPropertyName = "St_iniciarOSbool";
            resources.ApplyResources(this.stiniciarOSboolDataGridViewCheckBoxColumn, "stiniciarOSboolDataGridViewCheckBoxColumn");
            this.stiniciarOSboolDataGridViewCheckBoxColumn.Name = "stiniciarOSboolDataGridViewCheckBoxColumn";
            this.stiniciarOSboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // stfinalizarOSboolDataGridViewCheckBoxColumn
            // 
            this.stfinalizarOSboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stfinalizarOSboolDataGridViewCheckBoxColumn.DataPropertyName = "St_finalizarOSbool";
            resources.ApplyResources(this.stfinalizarOSboolDataGridViewCheckBoxColumn, "stfinalizarOSboolDataGridViewCheckBoxColumn");
            this.stfinalizarOSboolDataGridViewCheckBoxColumn.Name = "stfinalizarOSboolDataGridViewCheckBoxColumn";
            this.stfinalizarOSboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // stetapaorcamentoboolDataGridViewCheckBoxColumn
            // 
            this.stetapaorcamentoboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stetapaorcamentoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_etapaorcamentobool";
            resources.ApplyResources(this.stetapaorcamentoboolDataGridViewCheckBoxColumn, "stetapaorcamentoboolDataGridViewCheckBoxColumn");
            this.stetapaorcamentoboolDataGridViewCheckBoxColumn.Name = "stetapaorcamentoboolDataGridViewCheckBoxColumn";
            this.stetapaorcamentoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // stenvterceiroboolDataGridViewCheckBoxColumn
            // 
            this.stenvterceiroboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stenvterceiroboolDataGridViewCheckBoxColumn.DataPropertyName = "St_envterceirobool";
            resources.ApplyResources(this.stenvterceiroboolDataGridViewCheckBoxColumn, "stenvterceiroboolDataGridViewCheckBoxColumn");
            this.stenvterceiroboolDataGridViewCheckBoxColumn.Name = "stenvterceiroboolDataGridViewCheckBoxColumn";
            this.stenvterceiroboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // BN_EtapaOrdem
            // 
            this.BN_EtapaOrdem.AddNewItem = null;
            this.BN_EtapaOrdem.BindingSource = this.BS_CadOseEtapaOrdem;
            this.BN_EtapaOrdem.CountItem = this.bindingNavigatorCountItem;
            this.BN_EtapaOrdem.DeleteItem = null;
            resources.ApplyResources(this.BN_EtapaOrdem, "BN_EtapaOrdem");
            this.BN_EtapaOrdem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_EtapaOrdem.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_EtapaOrdem.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_EtapaOrdem.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_EtapaOrdem.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_EtapaOrdem.Name = "BN_EtapaOrdem";
            this.BN_EtapaOrdem.PositionItem = this.bindingNavigatorPositionItem;
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
            // id_etapa
            // 
            this.id_etapa.BackColor = System.Drawing.SystemColors.Window;
            this.id_etapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_etapa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadOseEtapaOrdem, "Id_etapastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.id_etapa, "id_etapa");
            this.id_etapa.Name = "id_etapa";
            this.id_etapa.NM_Alias = "a";
            this.id_etapa.NM_Campo = "id_etapa";
            this.id_etapa.NM_CampoBusca = "id_etapa";
            this.id_etapa.NM_Param = "@P_ID_ETAPA";
            this.id_etapa.QTD_Zero = 0;
            this.id_etapa.ST_AutoInc = false;
            this.id_etapa.ST_DisableAuto = true;
            this.id_etapa.ST_Float = false;
            this.id_etapa.ST_Gravar = true;
            this.id_etapa.ST_Int = true;
            this.id_etapa.ST_LimpaCampo = true;
            this.id_etapa.ST_NotNull = true;
            this.id_etapa.ST_PrimaryKey = true;
            this.id_etapa.TextOld = null;
            // 
            // St_IniciarOs
            // 
            resources.ApplyResources(this.St_IniciarOs, "St_IniciarOs");
            this.St_IniciarOs.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadOseEtapaOrdem, "St_iniciarOSbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.St_IniciarOs.Name = "St_IniciarOs";
            this.St_IniciarOs.NM_Alias = "";
            this.St_IniciarOs.NM_Campo = "";
            this.St_IniciarOs.NM_Param = "";
            this.St_IniciarOs.ST_Gravar = true;
            this.St_IniciarOs.ST_LimparCampo = true;
            this.St_IniciarOs.ST_NotNull = false;
            this.St_IniciarOs.UseVisualStyleBackColor = true;
            this.St_IniciarOs.Vl_False = "";
            this.St_IniciarOs.Vl_True = "";
            this.St_IniciarOs.Click += new System.EventHandler(this.St_IniciarOs_Click);
            // 
            // St_FinalizarOs
            // 
            resources.ApplyResources(this.St_FinalizarOs, "St_FinalizarOs");
            this.St_FinalizarOs.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadOseEtapaOrdem, "St_finalizarOSbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.St_FinalizarOs.Name = "St_FinalizarOs";
            this.St_FinalizarOs.NM_Alias = "";
            this.St_FinalizarOs.NM_Campo = "";
            this.St_FinalizarOs.NM_Param = "";
            this.St_FinalizarOs.ST_Gravar = true;
            this.St_FinalizarOs.ST_LimparCampo = true;
            this.St_FinalizarOs.ST_NotNull = false;
            this.St_FinalizarOs.UseVisualStyleBackColor = true;
            this.St_FinalizarOs.Vl_False = "";
            this.St_FinalizarOs.Vl_True = "";
            this.St_FinalizarOs.Click += new System.EventHandler(this.St_FinalizarOs_Click);
            // 
            // St_envterceiro
            // 
            resources.ApplyResources(this.St_envterceiro, "St_envterceiro");
            this.St_envterceiro.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadOseEtapaOrdem, "St_envterceirobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.St_envterceiro.Name = "St_envterceiro";
            this.St_envterceiro.NM_Alias = "";
            this.St_envterceiro.NM_Campo = "";
            this.St_envterceiro.NM_Param = "";
            this.St_envterceiro.ST_Gravar = true;
            this.St_envterceiro.ST_LimparCampo = true;
            this.St_envterceiro.ST_NotNull = false;
            this.St_envterceiro.UseVisualStyleBackColor = true;
            this.St_envterceiro.Vl_False = "";
            this.St_envterceiro.Vl_True = "";
            // 
            // pDetalhes
            // 
            this.pDetalhes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pDetalhes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDetalhes.Controls.Add(this.st_etapaorcamento);
            this.pDetalhes.Controls.Add(this.St_IniciarOs);
            this.pDetalhes.Controls.Add(this.St_envterceiro);
            this.pDetalhes.Controls.Add(this.St_FinalizarOs);
            resources.ApplyResources(this.pDetalhes, "pDetalhes");
            this.pDetalhes.Name = "pDetalhes";
            this.pDetalhes.NM_ProcDeletar = "";
            this.pDetalhes.NM_ProcGravar = "";
            // 
            // st_etapaorcamento
            // 
            resources.ApplyResources(this.st_etapaorcamento, "st_etapaorcamento");
            this.st_etapaorcamento.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadOseEtapaOrdem, "St_etapaorcamentobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_etapaorcamento.Name = "st_etapaorcamento";
            this.st_etapaorcamento.NM_Alias = "";
            this.st_etapaorcamento.NM_Campo = "";
            this.st_etapaorcamento.NM_Param = "";
            this.st_etapaorcamento.ST_Gravar = true;
            this.st_etapaorcamento.ST_LimparCampo = true;
            this.st_etapaorcamento.ST_NotNull = false;
            this.st_etapaorcamento.UseVisualStyleBackColor = true;
            this.st_etapaorcamento.Vl_False = "";
            this.st_etapaorcamento.Vl_True = "";
            // 
            // TFCadOseEtapaOrdem
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadOseEtapaOrdem";
            this.Load += new System.EventHandler(this.TFCadOseEtapaOrdem_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadOseEtapaOrdem_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadOseEtapaOrdem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_etapaOrdem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_EtapaOrdem)).EndInit();
            this.BN_EtapaOrdem.ResumeLayout(false);
            this.BN_EtapaOrdem.PerformLayout();
            this.pDetalhes.ResumeLayout(false);
            this.pDetalhes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BS_CadOseEtapaOrdem;
        private Componentes.EditDefault Ds_etapa;
        private Componentes.DataGridDefault g_etapaOrdem;
        private System.Windows.Forms.BindingNavigator BN_EtapaOrdem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault id_etapa;
        private Componentes.CheckBoxDefault St_FinalizarOs;
        private Componentes.CheckBoxDefault St_IniciarOs;
        private Componentes.CheckBoxDefault St_envterceiro;
        private Componentes.PanelDados pDetalhes;
        private System.Windows.Forms.DataGridViewTextBoxColumn idetapaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsetapaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idetapastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stiniciarOSboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stfinalizarOSboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stetapaorcamentoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stenvterceiroboolDataGridViewCheckBoxColumn;
        private Componentes.CheckBoxDefault st_etapaorcamento;
    }
}
