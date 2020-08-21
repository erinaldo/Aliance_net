namespace Servico.Cadastros
{
    partial class TFCad_TPOrdem
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
            System.Windows.Forms.Label tp_ordemLabel;
            System.Windows.Forms.Label ds_tipoordemLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_TPOrdem));
            this.ds_tipoordem = new Componentes.EditDefault(this.components);
            this.bsTpOrdem = new System.Windows.Forms.BindingSource(this.components);
            this.BN_TpOrdemServico = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.tp_ordem = new Componentes.EditDefault(this.components);
            this.gTpOrdem = new Componentes.DataGridDefault(this.components);
            this.st_exigirconferencia = new Componentes.CheckBoxDefault(this.components);
            this.tp_os = new Componentes.ComboBoxDefault(this.components);
            this.st_infDtAbertura = new Componentes.CheckBoxDefault(this.components);
            this.st_fechamentoComissao = new Componentes.CheckBoxDefault(this.components);
            this.st_procestoque = new Componentes.CheckBoxDefault(this.components);
            this.tp_faturamento = new Componentes.ComboBoxDefault(this.components);
            this.tpordemstrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_os = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_faturamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_exigirconferenciabool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_infDtAberturabool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_comissaofechamentobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            tp_ordemLabel = new System.Windows.Forms.Label();
            ds_tipoordemLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpOrdem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TpOrdemServico)).BeginInit();
            this.BN_TpOrdemServico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTpOrdem)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.tp_faturamento);
            this.pDados.Controls.Add(this.st_procestoque);
            this.pDados.Controls.Add(this.st_fechamentoComissao);
            this.pDados.Controls.Add(this.st_infDtAbertura);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.tp_os);
            this.pDados.Controls.Add(this.st_exigirconferencia);
            this.pDados.Controls.Add(this.tp_ordem);
            this.pDados.Controls.Add(ds_tipoordemLabel);
            this.pDados.Controls.Add(this.ds_tipoordem);
            this.pDados.Controls.Add(tp_ordemLabel);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gTpOrdem);
            this.tpPadrao.Controls.Add(this.BN_TpOrdemServico);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_TpOrdemServico, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gTpOrdem, 0);
            // 
            // tp_ordemLabel
            // 
            resources.ApplyResources(tp_ordemLabel, "tp_ordemLabel");
            tp_ordemLabel.Name = "tp_ordemLabel";
            // 
            // ds_tipoordemLabel
            // 
            resources.ApplyResources(ds_tipoordemLabel, "ds_tipoordemLabel");
            ds_tipoordemLabel.Name = "ds_tipoordemLabel";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // ds_tipoordem
            // 
            this.ds_tipoordem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tipoordem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tipoordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tipoordem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpOrdem, "Ds_tipoordem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_tipoordem, "ds_tipoordem");
            this.ds_tipoordem.Name = "ds_tipoordem";
            this.ds_tipoordem.NM_Alias = "a";
            this.ds_tipoordem.NM_Campo = "Desc. Ordem";
            this.ds_tipoordem.NM_CampoBusca = "ds_tipoordem";
            this.ds_tipoordem.NM_Param = "@P_DS_TIPOORDEM";
            this.ds_tipoordem.QTD_Zero = 0;
            this.ds_tipoordem.ST_AutoInc = false;
            this.ds_tipoordem.ST_DisableAuto = false;
            this.ds_tipoordem.ST_Float = false;
            this.ds_tipoordem.ST_Gravar = true;
            this.ds_tipoordem.ST_Int = false;
            this.ds_tipoordem.ST_LimpaCampo = true;
            this.ds_tipoordem.ST_NotNull = true;
            this.ds_tipoordem.ST_PrimaryKey = false;
            this.ds_tipoordem.TextOld = null;
            // 
            // bsTpOrdem
            // 
            this.bsTpOrdem.DataSource = typeof(CamadaDados.Servicos.Cadastros.TList_TpOrdem);
            // 
            // BN_TpOrdemServico
            // 
            this.BN_TpOrdemServico.AddNewItem = null;
            this.BN_TpOrdemServico.BindingSource = this.bsTpOrdem;
            this.BN_TpOrdemServico.CountItem = this.bindingNavigatorCountItem;
            this.BN_TpOrdemServico.CountItemFormat = "de {0}";
            this.BN_TpOrdemServico.DeleteItem = null;
            resources.ApplyResources(this.BN_TpOrdemServico, "BN_TpOrdemServico");
            this.BN_TpOrdemServico.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_TpOrdemServico.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_TpOrdemServico.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_TpOrdemServico.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_TpOrdemServico.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_TpOrdemServico.Name = "BN_TpOrdemServico";
            this.BN_TpOrdemServico.PositionItem = this.bindingNavigatorPositionItem;
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
            // tp_ordem
            // 
            this.tp_ordem.BackColor = System.Drawing.SystemColors.Window;
            this.tp_ordem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_ordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_ordem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpOrdem, "Tp_ordemstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.tp_ordem, "tp_ordem");
            this.tp_ordem.Name = "tp_ordem";
            this.tp_ordem.NM_Alias = "";
            this.tp_ordem.NM_Campo = "tp_ordem";
            this.tp_ordem.NM_CampoBusca = "tp_ordem";
            this.tp_ordem.NM_Param = "@P_TP_ORDEM";
            this.tp_ordem.QTD_Zero = 0;
            this.tp_ordem.ST_AutoInc = false;
            this.tp_ordem.ST_DisableAuto = true;
            this.tp_ordem.ST_Float = false;
            this.tp_ordem.ST_Gravar = true;
            this.tp_ordem.ST_Int = true;
            this.tp_ordem.ST_LimpaCampo = true;
            this.tp_ordem.ST_NotNull = true;
            this.tp_ordem.ST_PrimaryKey = true;
            this.tp_ordem.TextOld = null;
            // 
            // gTpOrdem
            // 
            this.gTpOrdem.AllowUserToAddRows = false;
            this.gTpOrdem.AllowUserToDeleteRows = false;
            this.gTpOrdem.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTpOrdem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gTpOrdem.AutoGenerateColumns = false;
            this.gTpOrdem.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTpOrdem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTpOrdem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTpOrdem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gTpOrdem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTpOrdem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tpordemstrDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.Tipo_os,
            this.Tipo_faturamento,
            this.St_exigirconferenciabool,
            this.St_infDtAberturabool,
            this.St_comissaofechamentobool});
            this.gTpOrdem.DataSource = this.bsTpOrdem;
            resources.ApplyResources(this.gTpOrdem, "gTpOrdem");
            this.gTpOrdem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTpOrdem.Name = "gTpOrdem";
            this.gTpOrdem.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTpOrdem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gTpOrdem.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gTpOrdem_ColumnHeaderMouseClick);
            // 
            // st_exigirconferencia
            // 
            resources.ApplyResources(this.st_exigirconferencia, "st_exigirconferencia");
            this.st_exigirconferencia.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsTpOrdem, "St_exigirconferenciabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_exigirconferencia.Name = "st_exigirconferencia";
            this.st_exigirconferencia.NM_Alias = "";
            this.st_exigirconferencia.NM_Campo = "";
            this.st_exigirconferencia.NM_Param = "";
            this.st_exigirconferencia.ST_Gravar = true;
            this.st_exigirconferencia.ST_LimparCampo = true;
            this.st_exigirconferencia.ST_NotNull = false;
            this.st_exigirconferencia.UseVisualStyleBackColor = true;
            this.st_exigirconferencia.Vl_False = "";
            this.st_exigirconferencia.Vl_True = "";
            // 
            // tp_os
            // 
            this.tp_os.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsTpOrdem, "Tp_os", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_os.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.tp_os, "tp_os");
            this.tp_os.FormattingEnabled = true;
            this.tp_os.Name = "tp_os";
            this.tp_os.NM_Alias = "";
            this.tp_os.NM_Campo = "";
            this.tp_os.NM_Param = "";
            this.tp_os.ST_Gravar = true;
            this.tp_os.ST_LimparCampo = true;
            this.tp_os.ST_NotNull = true;
            // 
            // st_infDtAbertura
            // 
            resources.ApplyResources(this.st_infDtAbertura, "st_infDtAbertura");
            this.st_infDtAbertura.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsTpOrdem, "St_infDtAberturabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_infDtAbertura.Name = "st_infDtAbertura";
            this.st_infDtAbertura.NM_Alias = "";
            this.st_infDtAbertura.NM_Campo = "";
            this.st_infDtAbertura.NM_Param = "";
            this.st_infDtAbertura.ST_Gravar = true;
            this.st_infDtAbertura.ST_LimparCampo = true;
            this.st_infDtAbertura.ST_NotNull = false;
            this.st_infDtAbertura.UseVisualStyleBackColor = true;
            this.st_infDtAbertura.Vl_False = "";
            this.st_infDtAbertura.Vl_True = "";
            // 
            // st_fechamentoComissao
            // 
            resources.ApplyResources(this.st_fechamentoComissao, "st_fechamentoComissao");
            this.st_fechamentoComissao.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsTpOrdem, "St_comissaofechamentobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_fechamentoComissao.Name = "st_fechamentoComissao";
            this.st_fechamentoComissao.NM_Alias = "";
            this.st_fechamentoComissao.NM_Campo = "";
            this.st_fechamentoComissao.NM_Param = "";
            this.st_fechamentoComissao.ST_Gravar = true;
            this.st_fechamentoComissao.ST_LimparCampo = true;
            this.st_fechamentoComissao.ST_NotNull = false;
            this.st_fechamentoComissao.UseVisualStyleBackColor = true;
            this.st_fechamentoComissao.Vl_False = "";
            this.st_fechamentoComissao.Vl_True = "";
            // 
            // st_procestoque
            // 
            resources.ApplyResources(this.st_procestoque, "st_procestoque");
            this.st_procestoque.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsTpOrdem, "St_procestoquebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_procestoque.Name = "st_procestoque";
            this.st_procestoque.NM_Alias = "";
            this.st_procestoque.NM_Campo = "";
            this.st_procestoque.NM_Param = "";
            this.st_procestoque.ST_Gravar = true;
            this.st_procestoque.ST_LimparCampo = true;
            this.st_procestoque.ST_NotNull = false;
            this.st_procestoque.UseVisualStyleBackColor = true;
            this.st_procestoque.Vl_False = "";
            this.st_procestoque.Vl_True = "";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // tp_faturamento
            // 
            this.tp_faturamento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsTpOrdem, "Tp_faturamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_faturamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.tp_faturamento, "tp_faturamento");
            this.tp_faturamento.FormattingEnabled = true;
            this.tp_faturamento.Name = "tp_faturamento";
            this.tp_faturamento.NM_Alias = "";
            this.tp_faturamento.NM_Campo = "";
            this.tp_faturamento.NM_Param = "";
            this.tp_faturamento.ST_Gravar = true;
            this.tp_faturamento.ST_LimparCampo = true;
            this.tp_faturamento.ST_NotNull = true;
            // 
            // tpordemstrDataGridViewTextBoxColumn
            // 
            this.tpordemstrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpordemstrDataGridViewTextBoxColumn.DataPropertyName = "Tp_ordemstr";
            resources.ApplyResources(this.tpordemstrDataGridViewTextBoxColumn, "tpordemstrDataGridViewTextBoxColumn");
            this.tpordemstrDataGridViewTextBoxColumn.Name = "tpordemstrDataGridViewTextBoxColumn";
            this.tpordemstrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_tipoordem";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Tipo_os
            // 
            this.Tipo_os.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_os.DataPropertyName = "Tipo_os";
            resources.ApplyResources(this.Tipo_os, "Tipo_os");
            this.Tipo_os.Name = "Tipo_os";
            this.Tipo_os.ReadOnly = true;
            // 
            // Tipo_faturamento
            // 
            this.Tipo_faturamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_faturamento.DataPropertyName = "Tipo_faturamento";
            resources.ApplyResources(this.Tipo_faturamento, "Tipo_faturamento");
            this.Tipo_faturamento.Name = "Tipo_faturamento";
            this.Tipo_faturamento.ReadOnly = true;
            // 
            // St_exigirconferenciabool
            // 
            this.St_exigirconferenciabool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_exigirconferenciabool.DataPropertyName = "St_exigirconferenciabool";
            resources.ApplyResources(this.St_exigirconferenciabool, "St_exigirconferenciabool");
            this.St_exigirconferenciabool.Name = "St_exigirconferenciabool";
            this.St_exigirconferenciabool.ReadOnly = true;
            // 
            // St_infDtAberturabool
            // 
            this.St_infDtAberturabool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_infDtAberturabool.DataPropertyName = "St_infDtAberturabool";
            resources.ApplyResources(this.St_infDtAberturabool, "St_infDtAberturabool");
            this.St_infDtAberturabool.Name = "St_infDtAberturabool";
            this.St_infDtAberturabool.ReadOnly = true;
            // 
            // St_comissaofechamentobool
            // 
            this.St_comissaofechamentobool.DataPropertyName = "St_comissaofechamentobool";
            resources.ApplyResources(this.St_comissaofechamentobool, "St_comissaofechamentobool");
            this.St_comissaofechamentobool.Name = "St_comissaofechamentobool";
            this.St_comissaofechamentobool.ReadOnly = true;
            // 
            // TFCad_TPOrdem
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCad_TPOrdem";
            this.Load += new System.EventHandler(this.TFCad_TPOrdem_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_TPOrdem_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpOrdem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TpOrdemServico)).EndInit();
            this.BN_TpOrdemServico.ResumeLayout(false);
            this.BN_TpOrdemServico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTpOrdem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault ds_tipoordem;
        private System.Windows.Forms.BindingSource bsTpOrdem;
        private System.Windows.Forms.BindingNavigator BN_TpOrdemServico;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault tp_ordem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpordemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstipoordemDataGridViewTextBoxColumn;
        private Componentes.DataGridDefault gTpOrdem;
        private Componentes.CheckBoxDefault st_exigirconferencia;
        private Componentes.ComboBoxDefault tp_os;
        private Componentes.CheckBoxDefault st_infDtAbertura;
        private Componentes.CheckBoxDefault st_fechamentoComissao;
        private Componentes.CheckBoxDefault st_procestoque;
        private Componentes.ComboBoxDefault tp_faturamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpordemstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_os;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_faturamento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_exigirconferenciabool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_infDtAberturabool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_comissaofechamentobool;
    }
}