namespace PostoCombustivel.Cadastros
{
    partial class TFCadTrans_X_UnidPag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTrans_X_UnidPag));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bb_transportadora = new System.Windows.Forms.Button();
            this.CD_Transportadora = new Componentes.EditDefault(this.components);
            this.bsTrans_X_UnidPag = new System.Windows.Forms.BindingSource(this.components);
            this.NM_Transportadora = new Componentes.EditDefault(this.components);
            this.bb_unidpag = new System.Windows.Forms.Button();
            this.CD_UnidPag = new Componentes.EditDefault(this.components);
            this.NM_UnidPag = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cDTransportadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMTransportadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDUnidPagadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMUnidPagadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTrans_X_UNidPag = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrans_X_UnidPag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTrans_X_UNidPag)).BeginInit();
            this.nTrans_X_UNidPag.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.bb_unidpag);
            this.pDados.Controls.Add(this.CD_UnidPag);
            this.pDados.Controls.Add(this.NM_UnidPag);
            this.pDados.Controls.Add(this.bb_transportadora);
            this.pDados.Controls.Add(this.CD_Transportadora);
            this.pDados.Controls.Add(this.NM_Transportadora);
            this.pDados.Size = new System.Drawing.Size(715, 75);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(727, 356);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.nTrans_X_UNidPag);
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(719, 330);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.nTrans_X_UNidPag, 0);
            // 
            // bb_transportadora
            // 
            this.bb_transportadora.BackColor = System.Drawing.SystemColors.Control;
            this.bb_transportadora.Enabled = false;
            this.bb_transportadora.Image = ((System.Drawing.Image)(resources.GetObject("bb_transportadora.Image")));
            this.bb_transportadora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_transportadora.Location = new System.Drawing.Point(194, 12);
            this.bb_transportadora.Name = "bb_transportadora";
            this.bb_transportadora.Size = new System.Drawing.Size(28, 22);
            this.bb_transportadora.TabIndex = 96;
            this.bb_transportadora.UseVisualStyleBackColor = false;
            this.bb_transportadora.Click += new System.EventHandler(this.bb_transportadora_Click);
            // 
            // CD_Transportadora
            // 
            this.CD_Transportadora.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Transportadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Transportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Transportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTrans_X_UnidPag, "CD_Transportadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Transportadora.Enabled = false;
            this.CD_Transportadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Transportadora.Location = new System.Drawing.Point(110, 13);
            this.CD_Transportadora.Name = "CD_Transportadora";
            this.CD_Transportadora.NM_Alias = "";
            this.CD_Transportadora.NM_Campo = "cd_clifor";
            this.CD_Transportadora.NM_CampoBusca = "cd_clifor";
            this.CD_Transportadora.NM_Param = "@P_NM_CLIFOR";
            this.CD_Transportadora.QTD_Zero = 0;
            this.CD_Transportadora.Size = new System.Drawing.Size(84, 20);
            this.CD_Transportadora.ST_AutoInc = false;
            this.CD_Transportadora.ST_DisableAuto = false;
            this.CD_Transportadora.ST_Float = false;
            this.CD_Transportadora.ST_Gravar = true;
            this.CD_Transportadora.ST_Int = false;
            this.CD_Transportadora.ST_LimpaCampo = true;
            this.CD_Transportadora.ST_NotNull = true;
            this.CD_Transportadora.ST_PrimaryKey = true;
            this.CD_Transportadora.TabIndex = 95;
            this.CD_Transportadora.TextOld = null;
            this.CD_Transportadora.Leave += new System.EventHandler(this.CD_Transportadora_Leave);
            // 
            // bsTrans_X_UnidPag
            // 
            this.bsTrans_X_UnidPag.DataSource = typeof(CamadaDados.PostoCombustivel.Cadastros.TList_Trans_X_UnidPag);
            // 
            // NM_Transportadora
            // 
            this.NM_Transportadora.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Transportadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Transportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Transportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTrans_X_UnidPag, "NM_Transportadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Transportadora.Enabled = false;
            this.NM_Transportadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Transportadora.Location = new System.Drawing.Point(224, 13);
            this.NM_Transportadora.Name = "NM_Transportadora";
            this.NM_Transportadora.NM_Alias = "";
            this.NM_Transportadora.NM_Campo = "NM_Clifor";
            this.NM_Transportadora.NM_CampoBusca = "NM_Clifor";
            this.NM_Transportadora.NM_Param = "@P_NM_CLIFOR";
            this.NM_Transportadora.QTD_Zero = 0;
            this.NM_Transportadora.Size = new System.Drawing.Size(483, 20);
            this.NM_Transportadora.ST_AutoInc = false;
            this.NM_Transportadora.ST_DisableAuto = false;
            this.NM_Transportadora.ST_Float = false;
            this.NM_Transportadora.ST_Gravar = false;
            this.NM_Transportadora.ST_Int = false;
            this.NM_Transportadora.ST_LimpaCampo = true;
            this.NM_Transportadora.ST_NotNull = false;
            this.NM_Transportadora.ST_PrimaryKey = false;
            this.NM_Transportadora.TabIndex = 94;
            this.NM_Transportadora.TextOld = null;
            // 
            // bb_unidpag
            // 
            this.bb_unidpag.BackColor = System.Drawing.SystemColors.Control;
            this.bb_unidpag.Enabled = false;
            this.bb_unidpag.Image = ((System.Drawing.Image)(resources.GetObject("bb_unidpag.Image")));
            this.bb_unidpag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_unidpag.Location = new System.Drawing.Point(194, 38);
            this.bb_unidpag.Name = "bb_unidpag";
            this.bb_unidpag.Size = new System.Drawing.Size(28, 22);
            this.bb_unidpag.TabIndex = 99;
            this.bb_unidpag.UseVisualStyleBackColor = false;
            this.bb_unidpag.Click += new System.EventHandler(this.bb_unidpag_Click);
            // 
            // CD_UnidPag
            // 
            this.CD_UnidPag.BackColor = System.Drawing.SystemColors.Window;
            this.CD_UnidPag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_UnidPag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_UnidPag.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTrans_X_UnidPag, "CD_UnidPagadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_UnidPag.Enabled = false;
            this.CD_UnidPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_UnidPag.Location = new System.Drawing.Point(110, 39);
            this.CD_UnidPag.Name = "CD_UnidPag";
            this.CD_UnidPag.NM_Alias = "";
            this.CD_UnidPag.NM_Campo = "cd_clifor";
            this.CD_UnidPag.NM_CampoBusca = "cd_clifor";
            this.CD_UnidPag.NM_Param = "@P_NM_CLIFOR";
            this.CD_UnidPag.QTD_Zero = 0;
            this.CD_UnidPag.Size = new System.Drawing.Size(84, 20);
            this.CD_UnidPag.ST_AutoInc = false;
            this.CD_UnidPag.ST_DisableAuto = false;
            this.CD_UnidPag.ST_Float = false;
            this.CD_UnidPag.ST_Gravar = true;
            this.CD_UnidPag.ST_Int = false;
            this.CD_UnidPag.ST_LimpaCampo = true;
            this.CD_UnidPag.ST_NotNull = true;
            this.CD_UnidPag.ST_PrimaryKey = true;
            this.CD_UnidPag.TabIndex = 98;
            this.CD_UnidPag.TextOld = null;
            this.CD_UnidPag.Leave += new System.EventHandler(this.CD_UnidPag_Leave);
            // 
            // NM_UnidPag
            // 
            this.NM_UnidPag.BackColor = System.Drawing.SystemColors.Window;
            this.NM_UnidPag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_UnidPag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_UnidPag.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTrans_X_UnidPag, "NM_UnidPagadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_UnidPag.Enabled = false;
            this.NM_UnidPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_UnidPag.Location = new System.Drawing.Point(224, 39);
            this.NM_UnidPag.Name = "NM_UnidPag";
            this.NM_UnidPag.NM_Alias = "";
            this.NM_UnidPag.NM_Campo = "NM_Clifor";
            this.NM_UnidPag.NM_CampoBusca = "NM_Clifor";
            this.NM_UnidPag.NM_Param = "@P_NM_CLIFOR";
            this.NM_UnidPag.QTD_Zero = 0;
            this.NM_UnidPag.Size = new System.Drawing.Size(483, 20);
            this.NM_UnidPag.ST_AutoInc = false;
            this.NM_UnidPag.ST_DisableAuto = false;
            this.NM_UnidPag.ST_Float = false;
            this.NM_UnidPag.ST_Gravar = false;
            this.NM_UnidPag.ST_Int = false;
            this.NM_UnidPag.ST_LimpaCampo = true;
            this.NM_UnidPag.ST_NotNull = false;
            this.NM_UnidPag.ST_PrimaryKey = false;
            this.NM_UnidPag.TabIndex = 97;
            this.NM_UnidPag.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "CD.Transportadora:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "CD.UnidPag:";
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDTransportadoraDataGridViewTextBoxColumn,
            this.nMTransportadoraDataGridViewTextBoxColumn,
            this.cDUnidPagadoraDataGridViewTextBoxColumn,
            this.nMUnidPagadoraDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsTrans_X_UnidPag;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 75);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(715, 251);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // cDTransportadoraDataGridViewTextBoxColumn
            // 
            this.cDTransportadoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDTransportadoraDataGridViewTextBoxColumn.DataPropertyName = "CD_Transportadora";
            this.cDTransportadoraDataGridViewTextBoxColumn.HeaderText = "CD.Transportadora";
            this.cDTransportadoraDataGridViewTextBoxColumn.Name = "cDTransportadoraDataGridViewTextBoxColumn";
            this.cDTransportadoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDTransportadoraDataGridViewTextBoxColumn.Width = 122;
            // 
            // nMTransportadoraDataGridViewTextBoxColumn
            // 
            this.nMTransportadoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMTransportadoraDataGridViewTextBoxColumn.DataPropertyName = "NM_Transportadora";
            this.nMTransportadoraDataGridViewTextBoxColumn.HeaderText = "Transportadora";
            this.nMTransportadoraDataGridViewTextBoxColumn.Name = "nMTransportadoraDataGridViewTextBoxColumn";
            this.nMTransportadoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.nMTransportadoraDataGridViewTextBoxColumn.Width = 104;
            // 
            // cDUnidPagadoraDataGridViewTextBoxColumn
            // 
            this.cDUnidPagadoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDUnidPagadoraDataGridViewTextBoxColumn.DataPropertyName = "CD_UnidPagadora";
            this.cDUnidPagadoraDataGridViewTextBoxColumn.HeaderText = "CD.UnidPagadora";
            this.cDUnidPagadoraDataGridViewTextBoxColumn.Name = "cDUnidPagadoraDataGridViewTextBoxColumn";
            this.cDUnidPagadoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDUnidPagadoraDataGridViewTextBoxColumn.Width = 118;
            // 
            // nMUnidPagadoraDataGridViewTextBoxColumn
            // 
            this.nMUnidPagadoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMUnidPagadoraDataGridViewTextBoxColumn.DataPropertyName = "NM_UnidPagadora";
            this.nMUnidPagadoraDataGridViewTextBoxColumn.HeaderText = "Unid.Pagadora";
            this.nMUnidPagadoraDataGridViewTextBoxColumn.Name = "nMUnidPagadoraDataGridViewTextBoxColumn";
            this.nMUnidPagadoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.nMUnidPagadoraDataGridViewTextBoxColumn.Width = 103;
            // 
            // nTrans_X_UNidPag
            // 
            this.nTrans_X_UNidPag.AddNewItem = null;
            this.nTrans_X_UNidPag.BindingSource = this.bsTrans_X_UnidPag;
            this.nTrans_X_UNidPag.CountItem = this.bindingNavigatorCountItem;
            this.nTrans_X_UNidPag.DeleteItem = null;
            this.nTrans_X_UNidPag.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nTrans_X_UNidPag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.nTrans_X_UNidPag.Location = new System.Drawing.Point(0, 301);
            this.nTrans_X_UNidPag.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.nTrans_X_UNidPag.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.nTrans_X_UNidPag.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.nTrans_X_UNidPag.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.nTrans_X_UNidPag.Name = "nTrans_X_UNidPag";
            this.nTrans_X_UNidPag.PositionItem = this.bindingNavigatorPositionItem;
            this.nTrans_X_UNidPag.Size = new System.Drawing.Size(715, 25);
            this.nTrans_X_UNidPag.TabIndex = 3;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total de Registros";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Próximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // TFCadTrans_X_UnidPag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 399);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadTrans_X_UnidPag";
            this.Text = "Transportadora X Unidade Pagamento";
            this.Load += new System.EventHandler(this.TFCadTrans_X_UnidPag_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrans_X_UnidPag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTrans_X_UNidPag)).EndInit();
            this.nTrans_X_UNidPag.ResumeLayout(false);
            this.nTrans_X_UNidPag.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_unidpag;
        private Componentes.EditDefault CD_UnidPag;
        private Componentes.EditDefault NM_UnidPag;
        private System.Windows.Forms.Button bb_transportadora;
        private Componentes.EditDefault CD_Transportadora;
        private Componentes.EditDefault NM_Transportadora;
        private System.Windows.Forms.BindingSource bsTrans_X_UnidPag;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDTransportadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMTransportadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDUnidPagadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMUnidPagadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator nTrans_X_UNidPag;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
    }
}