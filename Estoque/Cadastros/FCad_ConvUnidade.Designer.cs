namespace Estoque.Cadastros
{
    partial class TFCad_ConvUnidade
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_ConvUnidade));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VL_Indice = new Componentes.EditFloat(this.components);
            this.BS_CadConvUnidade = new System.Windows.Forms.BindingSource(this.components);
            this.CD_Unidade_Orig = new Componentes.EditDefault(this.components);
            this.CD_Unidade_Dest = new Componentes.EditDefault(this.components);
            this.BB_UNIDADE_ORIG = new System.Windows.Forms.Button();
            this.BB_UNIDADE_DEST = new System.Windows.Forms.Button();
            this.DS_Unidade_Orig = new Componentes.EditDefault(this.components);
            this.DS_Unidade_Dest = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.g_convUnidade = new Componentes.DataGridDefault(this.components);
            this.cDUnidadeOrigDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDUnidadeDestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTFatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ST_Fator_Extendido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BN_CadConvUnidade = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.ST_Fator = new Componentes.ComboBoxDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Indice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadConvUnidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_convUnidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadConvUnidade)).BeginInit();
            this.BN_CadConvUnidade.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ST_Fator);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.DS_Unidade_Dest);
            this.pDados.Controls.Add(this.DS_Unidade_Orig);
            this.pDados.Controls.Add(this.BB_UNIDADE_DEST);
            this.pDados.Controls.Add(this.BB_UNIDADE_ORIG);
            this.pDados.Controls.Add(this.CD_Unidade_Dest);
            this.pDados.Controls.Add(this.CD_Unidade_Orig);
            this.pDados.Controls.Add(this.VL_Indice);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.label3);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_convUnidade);
            this.tpPadrao.Controls.Add(this.BN_CadConvUnidade);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadConvUnidade, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_convUnidade, 0);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            // VL_Indice
            // 
            this.VL_Indice.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_CadConvUnidade, "VL_Indice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Indice.DecimalPlaces = 5;
            resources.ApplyResources(this.VL_Indice, "VL_Indice");
            this.VL_Indice.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.VL_Indice.Name = "VL_Indice";
            this.VL_Indice.NM_Alias = "a";
            this.VL_Indice.NM_Campo = "VL_Indice";
            this.VL_Indice.NM_Param = "@P_VL_INDICE";
            this.VL_Indice.Operador = "";
            this.VL_Indice.ST_AutoInc = false;
            this.VL_Indice.ST_DisableAuto = true;
            this.VL_Indice.ST_Gravar = true;
            this.VL_Indice.ST_LimparCampo = true;
            this.VL_Indice.ST_NotNull = true;
            this.VL_Indice.ST_PrimaryKey = false;
            // 
            // BS_CadConvUnidade
            // 
            this.BS_CadConvUnidade.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadConvUnidade);
            // 
            // CD_Unidade_Orig
            // 
            this.CD_Unidade_Orig.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Unidade_Orig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Unidade_Orig.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadConvUnidade, "CD_Unidade_Orig", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Unidade_Orig, "CD_Unidade_Orig");
            this.CD_Unidade_Orig.Name = "CD_Unidade_Orig";
            this.CD_Unidade_Orig.NM_Alias = "";
            this.CD_Unidade_Orig.NM_Campo = "CD_Unidade_Orig";
            this.CD_Unidade_Orig.NM_CampoBusca = "CD_UNIDADE";
            this.CD_Unidade_Orig.NM_Param = "@P_CD_UNIDADE_ORIG";
            this.CD_Unidade_Orig.QTD_Zero = 0;
            this.CD_Unidade_Orig.ST_AutoInc = false;
            this.CD_Unidade_Orig.ST_DisableAuto = false;
            this.CD_Unidade_Orig.ST_Float = false;
            this.CD_Unidade_Orig.ST_Gravar = true;
            this.CD_Unidade_Orig.ST_Int = true;
            this.CD_Unidade_Orig.ST_LimpaCampo = true;
            this.CD_Unidade_Orig.ST_NotNull = true;
            this.CD_Unidade_Orig.ST_PrimaryKey = true;
            this.CD_Unidade_Orig.Leave += new System.EventHandler(this.CD_UNIDADE_ORIG_Leave);
            // 
            // CD_Unidade_Dest
            // 
            this.CD_Unidade_Dest.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Unidade_Dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Unidade_Dest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadConvUnidade, "CD_Unidade_Dest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Unidade_Dest, "CD_Unidade_Dest");
            this.CD_Unidade_Dest.Name = "CD_Unidade_Dest";
            this.CD_Unidade_Dest.NM_Alias = "";
            this.CD_Unidade_Dest.NM_Campo = "CD_Unidade_Dest";
            this.CD_Unidade_Dest.NM_CampoBusca = "CD_UNIDADE";
            this.CD_Unidade_Dest.NM_Param = "@P_CD_UNIDADE_DEST";
            this.CD_Unidade_Dest.QTD_Zero = 0;
            this.CD_Unidade_Dest.ST_AutoInc = false;
            this.CD_Unidade_Dest.ST_DisableAuto = false;
            this.CD_Unidade_Dest.ST_Float = false;
            this.CD_Unidade_Dest.ST_Gravar = true;
            this.CD_Unidade_Dest.ST_Int = true;
            this.CD_Unidade_Dest.ST_LimpaCampo = true;
            this.CD_Unidade_Dest.ST_NotNull = true;
            this.CD_Unidade_Dest.ST_PrimaryKey = true;
            this.CD_Unidade_Dest.Leave += new System.EventHandler(this.CD_UNIDADE_DEST_Leave);
            // 
            // BB_UNIDADE_ORIG
            // 
            resources.ApplyResources(this.BB_UNIDADE_ORIG, "BB_UNIDADE_ORIG");
            this.BB_UNIDADE_ORIG.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_UNIDADE_ORIG.Name = "BB_UNIDADE_ORIG";
            this.BB_UNIDADE_ORIG.UseVisualStyleBackColor = true;
            this.BB_UNIDADE_ORIG.Click += new System.EventHandler(this.BB_UNIDADE_ORIG_Click);
            // 
            // BB_UNIDADE_DEST
            // 
            resources.ApplyResources(this.BB_UNIDADE_DEST, "BB_UNIDADE_DEST");
            this.BB_UNIDADE_DEST.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_UNIDADE_DEST.Name = "BB_UNIDADE_DEST";
            this.BB_UNIDADE_DEST.UseVisualStyleBackColor = true;
            this.BB_UNIDADE_DEST.Click += new System.EventHandler(this.BB_UNIDADE_DEST_Click);
            // 
            // DS_Unidade_Orig
            // 
            this.DS_Unidade_Orig.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Unidade_Orig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Unidade_Orig.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadConvUnidade, "DS_Unidade_Orig", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Unidade_Orig, "DS_Unidade_Orig");
            this.DS_Unidade_Orig.Name = "DS_Unidade_Orig";
            this.DS_Unidade_Orig.NM_Alias = "";
            this.DS_Unidade_Orig.NM_Campo = "DS_Unidade_Orig";
            this.DS_Unidade_Orig.NM_CampoBusca = "DS_Unidade";
            this.DS_Unidade_Orig.NM_Param = "@P_DS_UNIDADE_ORIG";
            this.DS_Unidade_Orig.QTD_Zero = 0;
            this.DS_Unidade_Orig.ST_AutoInc = false;
            this.DS_Unidade_Orig.ST_DisableAuto = true;
            this.DS_Unidade_Orig.ST_Float = false;
            this.DS_Unidade_Orig.ST_Gravar = false;
            this.DS_Unidade_Orig.ST_Int = false;
            this.DS_Unidade_Orig.ST_LimpaCampo = true;
            this.DS_Unidade_Orig.ST_NotNull = false;
            this.DS_Unidade_Orig.ST_PrimaryKey = false;
            // 
            // DS_Unidade_Dest
            // 
            this.DS_Unidade_Dest.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Unidade_Dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Unidade_Dest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadConvUnidade, "DS_Unidade_Dest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Unidade_Dest, "DS_Unidade_Dest");
            this.DS_Unidade_Dest.Name = "DS_Unidade_Dest";
            this.DS_Unidade_Dest.NM_Alias = "";
            this.DS_Unidade_Dest.NM_Campo = "DS_Unidade_Dest";
            this.DS_Unidade_Dest.NM_CampoBusca = "DS_Unidade";
            this.DS_Unidade_Dest.NM_Param = "@P_DS_UNIDADE_DEST";
            this.DS_Unidade_Dest.QTD_Zero = 0;
            this.DS_Unidade_Dest.ST_AutoInc = false;
            this.DS_Unidade_Dest.ST_DisableAuto = true;
            this.DS_Unidade_Dest.ST_Float = false;
            this.DS_Unidade_Dest.ST_Gravar = false;
            this.DS_Unidade_Dest.ST_Int = false;
            this.DS_Unidade_Dest.ST_LimpaCampo = true;
            this.DS_Unidade_Dest.ST_NotNull = false;
            this.DS_Unidade_Dest.ST_PrimaryKey = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // g_convUnidade
            // 
            this.g_convUnidade.AllowUserToAddRows = false;
            this.g_convUnidade.AllowUserToDeleteRows = false;
            this.g_convUnidade.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_convUnidade.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_convUnidade.AutoGenerateColumns = false;
            this.g_convUnidade.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_convUnidade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_convUnidade.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_convUnidade.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_convUnidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_convUnidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDUnidadeOrigDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.cDUnidadeDestDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.sTFatorDataGridViewTextBoxColumn,
            this.ST_Fator_Extendido});
            this.g_convUnidade.DataSource = this.BS_CadConvUnidade;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.g_convUnidade.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.g_convUnidade, "g_convUnidade");
            this.g_convUnidade.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_convUnidade.Name = "g_convUnidade";
            this.g_convUnidade.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_convUnidade.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.g_convUnidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_convUnidade.TabStop = false;
            this.g_convUnidade.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.g_convUnidade_ColumnHeaderMouseClick);
            // 
            // cDUnidadeOrigDataGridViewTextBoxColumn
            // 
            this.cDUnidadeOrigDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDUnidadeOrigDataGridViewTextBoxColumn.DataPropertyName = "CD_Unidade_Orig";
            resources.ApplyResources(this.cDUnidadeOrigDataGridViewTextBoxColumn, "cDUnidadeOrigDataGridViewTextBoxColumn");
            this.cDUnidadeOrigDataGridViewTextBoxColumn.Name = "cDUnidadeOrigDataGridViewTextBoxColumn";
            this.cDUnidadeOrigDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DS_Unidade_Orig";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cDUnidadeDestDataGridViewTextBoxColumn
            // 
            this.cDUnidadeDestDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDUnidadeDestDataGridViewTextBoxColumn.DataPropertyName = "CD_Unidade_Dest";
            resources.ApplyResources(this.cDUnidadeDestDataGridViewTextBoxColumn, "cDUnidadeDestDataGridViewTextBoxColumn");
            this.cDUnidadeDestDataGridViewTextBoxColumn.Name = "cDUnidadeDestDataGridViewTextBoxColumn";
            this.cDUnidadeDestDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DS_Unidade_Dest";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // sTFatorDataGridViewTextBoxColumn
            // 
            this.sTFatorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sTFatorDataGridViewTextBoxColumn.DataPropertyName = "VL_Indice";
            resources.ApplyResources(this.sTFatorDataGridViewTextBoxColumn, "sTFatorDataGridViewTextBoxColumn");
            this.sTFatorDataGridViewTextBoxColumn.Name = "sTFatorDataGridViewTextBoxColumn";
            this.sTFatorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ST_Fator_Extendido
            // 
            this.ST_Fator_Extendido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ST_Fator_Extendido.DataPropertyName = "ST_Fator_Extendido";
            resources.ApplyResources(this.ST_Fator_Extendido, "ST_Fator_Extendido");
            this.ST_Fator_Extendido.Name = "ST_Fator_Extendido";
            this.ST_Fator_Extendido.ReadOnly = true;
            // 
            // BN_CadConvUnidade
            // 
            this.BN_CadConvUnidade.AddNewItem = null;
            this.BN_CadConvUnidade.BindingSource = this.BS_CadConvUnidade;
            this.BN_CadConvUnidade.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadConvUnidade.DeleteItem = null;
            resources.ApplyResources(this.BN_CadConvUnidade, "BN_CadConvUnidade");
            this.BN_CadConvUnidade.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadConvUnidade.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadConvUnidade.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadConvUnidade.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadConvUnidade.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadConvUnidade.Name = "BN_CadConvUnidade";
            this.BN_CadConvUnidade.PositionItem = this.bindingNavigatorPositionItem;
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
            // ST_Fator
            // 
            this.ST_Fator.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_CadConvUnidade, "ST_Fator", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Fator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.ST_Fator, "ST_Fator");
            this.ST_Fator.FormattingEnabled = true;
            this.ST_Fator.Name = "ST_Fator";
            this.ST_Fator.NM_Alias = "a";
            this.ST_Fator.NM_Campo = "Fator Conversão";
            this.ST_Fator.NM_Param = "@P_FATOR_CONVERSAO";
            this.ST_Fator.ST_Gravar = true;
            this.ST_Fator.ST_LimparCampo = true;
            this.ST_Fator.ST_NotNull = true;
            // 
            // TFCad_ConvUnidade
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCad_ConvUnidade";
            this.Load += new System.EventHandler(this.TFCad_ConvUnidade_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_ConvUnidade_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Indice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadConvUnidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_convUnidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadConvUnidade)).EndInit();
            this.BN_CadConvUnidade.ResumeLayout(false);
            this.BN_CadConvUnidade.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat VL_Indice;
        private Componentes.EditDefault CD_Unidade_Orig;
        private Componentes.EditDefault CD_Unidade_Dest;
        public System.Windows.Forms.Button BB_UNIDADE_ORIG;
        public System.Windows.Forms.Button BB_UNIDADE_DEST;
        private Componentes.EditDefault DS_Unidade_Orig;
        private Componentes.EditDefault DS_Unidade_Dest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingNavigator BN_CadConvUnidade;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault g_convUnidade;
        private System.Windows.Forms.BindingSource BS_CadConvUnidade;
        public Componentes.ComboBoxDefault ST_Fator;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDUnidadeOrigDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDUnidadeDestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTFatorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ST_Fator_Extendido;
    }
}