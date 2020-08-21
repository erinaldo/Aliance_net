namespace Estoque.Cadastros
{
    partial class TFCadGrupoProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadGrupoProduto));
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.cDGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpGrupoExtendidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDGrupoPaiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSGrupoPaiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QT_vl_bi_Extendido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_GrupoProduto = new System.Windows.Forms.BindingSource(this.components);
            this.LB_DS_Grupo = new System.Windows.Forms.Label();
            this.LB_CD_Grupo_Pai = new System.Windows.Forms.Label();
            this.DS_Grupo = new Componentes.EditDefault(this.components);
            this.DS_Grupo_Pai = new Componentes.EditDefault(this.components);
            this.BB_Grupo = new System.Windows.Forms.Button();
            this.BN_CadGrupoProduto = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Tp_Grupo = new Componentes.ComboBoxDefault(this.components);
            this.CD_Grupo_Pai = new Componentes.EditDefault(this.components);
            this.qt_vl_bi = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxDefault1 = new Componentes.CheckBoxDefault(this.components);
            this.checkBoxDefault2 = new Componentes.CheckBoxDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_GrupoProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadGrupoProduto)).BeginInit();
            this.BN_CadGrupoProduto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.checkBoxDefault2);
            this.pDados.Controls.Add(this.checkBoxDefault1);
            this.pDados.Controls.Add(this.qt_vl_bi);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.CD_Grupo_Pai);
            this.pDados.Controls.Add(this.Tp_Grupo);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.BB_Grupo);
            this.pDados.Controls.Add(this.DS_Grupo_Pai);
            this.pDados.Controls.Add(this.LB_DS_Grupo);
            this.pDados.Controls.Add(this.LB_CD_Grupo_Pai);
            this.pDados.Controls.Add(this.DS_Grupo);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.NM_ProcDeletar = "EXCLUI_EST_GRUPOPRODUTO";
            this.pDados.NM_ProcGravar = "IA_EST_GRUPOPRODUTO";
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.BN_CadGrupoProduto);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadGrupoProduto, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // gCadastro
            // 
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDGrupoDataGridViewTextBoxColumn,
            this.dSGrupoDataGridViewTextBoxColumn,
            this.tpGrupoExtendidoDataGridViewTextBoxColumn,
            this.nivelDataGridViewTextBoxColumn,
            this.cDGrupoPaiDataGridViewTextBoxColumn,
            this.dSGrupoPaiDataGridViewTextBoxColumn,
            this.QT_vl_bi_Extendido});
            this.gCadastro.DataSource = this.BS_GrupoProduto;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gCadastro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gCadastro.TabStop = false;
            // 
            // cDGrupoDataGridViewTextBoxColumn
            // 
            this.cDGrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDGrupoDataGridViewTextBoxColumn.DataPropertyName = "CD_Grupo";
            resources.ApplyResources(this.cDGrupoDataGridViewTextBoxColumn, "cDGrupoDataGridViewTextBoxColumn");
            this.cDGrupoDataGridViewTextBoxColumn.Name = "cDGrupoDataGridViewTextBoxColumn";
            this.cDGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSGrupoDataGridViewTextBoxColumn
            // 
            this.dSGrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSGrupoDataGridViewTextBoxColumn.DataPropertyName = "DS_Grupo";
            resources.ApplyResources(this.dSGrupoDataGridViewTextBoxColumn, "dSGrupoDataGridViewTextBoxColumn");
            this.dSGrupoDataGridViewTextBoxColumn.Name = "dSGrupoDataGridViewTextBoxColumn";
            this.dSGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpGrupoExtendidoDataGridViewTextBoxColumn
            // 
            this.tpGrupoExtendidoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpGrupoExtendidoDataGridViewTextBoxColumn.DataPropertyName = "Tp_Grupo_Extendido";
            resources.ApplyResources(this.tpGrupoExtendidoDataGridViewTextBoxColumn, "tpGrupoExtendidoDataGridViewTextBoxColumn");
            this.tpGrupoExtendidoDataGridViewTextBoxColumn.Name = "tpGrupoExtendidoDataGridViewTextBoxColumn";
            this.tpGrupoExtendidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nivelDataGridViewTextBoxColumn
            // 
            this.nivelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nivelDataGridViewTextBoxColumn.DataPropertyName = "Nivel";
            resources.ApplyResources(this.nivelDataGridViewTextBoxColumn, "nivelDataGridViewTextBoxColumn");
            this.nivelDataGridViewTextBoxColumn.Name = "nivelDataGridViewTextBoxColumn";
            this.nivelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cDGrupoPaiDataGridViewTextBoxColumn
            // 
            this.cDGrupoPaiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDGrupoPaiDataGridViewTextBoxColumn.DataPropertyName = "CD_Grupo_Pai";
            resources.ApplyResources(this.cDGrupoPaiDataGridViewTextBoxColumn, "cDGrupoPaiDataGridViewTextBoxColumn");
            this.cDGrupoPaiDataGridViewTextBoxColumn.Name = "cDGrupoPaiDataGridViewTextBoxColumn";
            this.cDGrupoPaiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSGrupoPaiDataGridViewTextBoxColumn
            // 
            this.dSGrupoPaiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSGrupoPaiDataGridViewTextBoxColumn.DataPropertyName = "DS_Grupo_Pai";
            resources.ApplyResources(this.dSGrupoPaiDataGridViewTextBoxColumn, "dSGrupoPaiDataGridViewTextBoxColumn");
            this.dSGrupoPaiDataGridViewTextBoxColumn.Name = "dSGrupoPaiDataGridViewTextBoxColumn";
            this.dSGrupoPaiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // QT_vl_bi_Extendido
            // 
            this.QT_vl_bi_Extendido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.QT_vl_bi_Extendido.DataPropertyName = "QT_vl_bi_Extendido";
            resources.ApplyResources(this.QT_vl_bi_Extendido, "QT_vl_bi_Extendido");
            this.QT_vl_bi_Extendido.Name = "QT_vl_bi_Extendido";
            this.QT_vl_bi_Extendido.ReadOnly = true;
            // 
            // BS_GrupoProduto
            // 
            this.BS_GrupoProduto.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadGrupoProduto);
            this.BS_GrupoProduto.PositionChanged += new System.EventHandler(this.BS_GrupoProduto_PositionChanged);
            // 
            // LB_DS_Grupo
            // 
            resources.ApplyResources(this.LB_DS_Grupo, "LB_DS_Grupo");
            this.LB_DS_Grupo.Name = "LB_DS_Grupo";
            // 
            // LB_CD_Grupo_Pai
            // 
            resources.ApplyResources(this.LB_CD_Grupo_Pai, "LB_CD_Grupo_Pai");
            this.LB_CD_Grupo_Pai.Name = "LB_CD_Grupo_Pai";
            // 
            // DS_Grupo
            // 
            this.DS_Grupo.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_GrupoProduto, "DS_Grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Grupo, "DS_Grupo");
            this.DS_Grupo.Name = "DS_Grupo";
            this.DS_Grupo.NM_Alias = "a";
            this.DS_Grupo.NM_Campo = "Grupo";
            this.DS_Grupo.NM_CampoBusca = "DS_Grupo";
            this.DS_Grupo.NM_Param = "@P_DS_GRUPO";
            this.DS_Grupo.QTD_Zero = 0;
            this.DS_Grupo.ST_AutoInc = false;
            this.DS_Grupo.ST_DisableAuto = false;
            this.DS_Grupo.ST_Float = false;
            this.DS_Grupo.ST_Gravar = true;
            this.DS_Grupo.ST_Int = false;
            this.DS_Grupo.ST_LimpaCampo = true;
            this.DS_Grupo.ST_NotNull = true;
            this.DS_Grupo.ST_PrimaryKey = false;
            this.DS_Grupo.TextOld = null;
            // 
            // DS_Grupo_Pai
            // 
            this.DS_Grupo_Pai.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Grupo_Pai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Grupo_Pai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Grupo_Pai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_GrupoProduto, "DS_Grupo_Pai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Grupo_Pai, "DS_Grupo_Pai");
            this.DS_Grupo_Pai.Name = "DS_Grupo_Pai";
            this.DS_Grupo_Pai.NM_Alias = "";
            this.DS_Grupo_Pai.NM_Campo = "DS_Grupo_Pai";
            this.DS_Grupo_Pai.NM_CampoBusca = "DS_Grupo";
            this.DS_Grupo_Pai.NM_Param = "@P_DS_GRUPO_PAI";
            this.DS_Grupo_Pai.QTD_Zero = 0;
            this.DS_Grupo_Pai.ST_AutoInc = false;
            this.DS_Grupo_Pai.ST_DisableAuto = true;
            this.DS_Grupo_Pai.ST_Float = false;
            this.DS_Grupo_Pai.ST_Gravar = false;
            this.DS_Grupo_Pai.ST_Int = false;
            this.DS_Grupo_Pai.ST_LimpaCampo = true;
            this.DS_Grupo_Pai.ST_NotNull = false;
            this.DS_Grupo_Pai.ST_PrimaryKey = false;
            this.DS_Grupo_Pai.TextOld = null;
            // 
            // BB_Grupo
            // 
            resources.ApplyResources(this.BB_Grupo, "BB_Grupo");
            this.BB_Grupo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Grupo.Name = "BB_Grupo";
            this.BB_Grupo.UseVisualStyleBackColor = true;
            this.BB_Grupo.Click += new System.EventHandler(this.BB_Grupo_Click);
            // 
            // BN_CadGrupoProduto
            // 
            this.BN_CadGrupoProduto.AddNewItem = null;
            this.BN_CadGrupoProduto.BindingSource = this.BS_GrupoProduto;
            this.BN_CadGrupoProduto.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadGrupoProduto.DeleteItem = null;
            resources.ApplyResources(this.BN_CadGrupoProduto, "BN_CadGrupoProduto");
            this.BN_CadGrupoProduto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadGrupoProduto.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadGrupoProduto.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadGrupoProduto.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadGrupoProduto.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadGrupoProduto.Name = "BN_CadGrupoProduto";
            this.BN_CadGrupoProduto.PositionItem = this.bindingNavigatorPositionItem;
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
            // Tp_Grupo
            // 
            this.Tp_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_GrupoProduto, "Tp_Grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Tp_Grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.Tp_Grupo, "Tp_Grupo");
            this.Tp_Grupo.FormattingEnabled = true;
            this.Tp_Grupo.Name = "Tp_Grupo";
            this.Tp_Grupo.NM_Alias = "a";
            this.Tp_Grupo.NM_Campo = "Tipo Grupo";
            this.Tp_Grupo.NM_Param = "@P_TP_GRUPO";
            this.Tp_Grupo.ST_Gravar = true;
            this.Tp_Grupo.ST_LimparCampo = true;
            this.Tp_Grupo.ST_NotNull = true;
            this.Tp_Grupo.SelectedIndexChanged += new System.EventHandler(this.Tp_Grupo_SelectedIndexChanged);
            // 
            // CD_Grupo_Pai
            // 
            this.CD_Grupo_Pai.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Grupo_Pai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Grupo_Pai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Grupo_Pai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_GrupoProduto, "CD_Grupo_Pai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Grupo_Pai, "CD_Grupo_Pai");
            this.CD_Grupo_Pai.Name = "CD_Grupo_Pai";
            this.CD_Grupo_Pai.NM_Alias = "a";
            this.CD_Grupo_Pai.NM_Campo = "CD_Grupo_Pai";
            this.CD_Grupo_Pai.NM_CampoBusca = "CD_Grupo";
            this.CD_Grupo_Pai.NM_Param = "@P_CD_GRUPO_PAI";
            this.CD_Grupo_Pai.QTD_Zero = 0;
            this.CD_Grupo_Pai.ST_AutoInc = false;
            this.CD_Grupo_Pai.ST_DisableAuto = false;
            this.CD_Grupo_Pai.ST_Float = false;
            this.CD_Grupo_Pai.ST_Gravar = true;
            this.CD_Grupo_Pai.ST_Int = false;
            this.CD_Grupo_Pai.ST_LimpaCampo = true;
            this.CD_Grupo_Pai.ST_NotNull = false;
            this.CD_Grupo_Pai.ST_PrimaryKey = false;
            this.CD_Grupo_Pai.TextOld = null;
            this.CD_Grupo_Pai.EnabledChanged += new System.EventHandler(this.CD_Grupo_Pai_EnabledChanged);
            this.CD_Grupo_Pai.Leave += new System.EventHandler(this.CD_Grupo_Pai_Leave);
            // 
            // qt_vl_bi
            // 
            this.qt_vl_bi.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_GrupoProduto, "QT_vl_bi", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qt_vl_bi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.qt_vl_bi, "qt_vl_bi");
            this.qt_vl_bi.FormattingEnabled = true;
            this.qt_vl_bi.Name = "qt_vl_bi";
            this.qt_vl_bi.NM_Alias = "a";
            this.qt_vl_bi.NM_Campo = "Tipo BI";
            this.qt_vl_bi.NM_Param = "@P_QT_VL_BI";
            this.qt_vl_bi.ST_Gravar = true;
            this.qt_vl_bi.ST_LimparCampo = true;
            this.qt_vl_bi.ST_NotNull = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // checkBoxDefault1
            // 
            resources.ApplyResources(this.checkBoxDefault1, "checkBoxDefault1");
            this.checkBoxDefault1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_GrupoProduto, "st_menor_idade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxDefault1.Name = "checkBoxDefault1";
            this.checkBoxDefault1.NM_Alias = "";
            this.checkBoxDefault1.NM_Campo = "";
            this.checkBoxDefault1.NM_Param = "";
            this.checkBoxDefault1.ST_Gravar = true;
            this.checkBoxDefault1.ST_LimparCampo = true;
            this.checkBoxDefault1.ST_NotNull = false;
            this.checkBoxDefault1.UseVisualStyleBackColor = true;
            this.checkBoxDefault1.Vl_False = "";
            this.checkBoxDefault1.Vl_True = "";
            // 
            // checkBoxDefault2
            // 
            resources.ApplyResources(this.checkBoxDefault2, "checkBoxDefault2");
            this.checkBoxDefault2.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_GrupoProduto, "st_obs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxDefault2.Name = "checkBoxDefault2";
            this.checkBoxDefault2.NM_Alias = "";
            this.checkBoxDefault2.NM_Campo = "";
            this.checkBoxDefault2.NM_Param = "";
            this.checkBoxDefault2.ST_Gravar = true;
            this.checkBoxDefault2.ST_LimparCampo = true;
            this.checkBoxDefault2.ST_NotNull = false;
            this.checkBoxDefault2.UseVisualStyleBackColor = true;
            this.checkBoxDefault2.Vl_False = "";
            this.checkBoxDefault2.Vl_True = "";
            // 
            // TFCadGrupoProduto
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadGrupoProduto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadGrupoProduto_FormClosing);
            this.Load += new System.EventHandler(this.TFCadGrupoProduto_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_GrupoProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadGrupoProduto)).EndInit();
            this.BN_CadGrupoProduto.ResumeLayout(false);
            this.BN_CadGrupoProduto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label LB_DS_Grupo;
        private System.Windows.Forms.Label LB_CD_Grupo_Pai;
        private Componentes.EditDefault DS_Grupo;
        private Componentes.EditDefault DS_Grupo_Pai;
        public System.Windows.Forms.Button BB_Grupo;
        private System.Windows.Forms.BindingSource BS_GrupoProduto;
        private System.Windows.Forms.BindingNavigator BN_CadGrupoProduto;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label1;
        public Componentes.ComboBoxDefault Tp_Grupo;
        private Componentes.EditDefault CD_Grupo_Pai;
        public Componentes.ComboBoxDefault qt_vl_bi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpGrupoExtendidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDGrupoPaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSGrupoPaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QT_vl_bi_Extendido;
        private Componentes.CheckBoxDefault checkBoxDefault1;
        private Componentes.CheckBoxDefault checkBoxDefault2;
    }
}
