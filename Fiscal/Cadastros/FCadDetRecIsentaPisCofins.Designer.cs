namespace Fiscal.Cadastros
{
    partial class TFCadDetRecIsentaPisCofins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadDetRecIsentaPisCofins));
            this.gDetRecIsenta = new Componentes.DataGridDefault(this.components);
            this.iddetrecisentastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsdetrecisentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_impostostr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDetRecIsenta = new System.Windows.Forms.BindingSource(this.components);
            this.id_detrecisenta = new Componentes.EditDefault(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.ds_detrecisenta = new Componentes.EditDefault(this.components);
            this.ds_imposto = new Componentes.EditDefault(this.components);
            this.CD_Imposto = new Componentes.EditDefault(this.components);
            this.LB_CD_Imposto = new System.Windows.Forms.Label();
            this.bb_imposto = new System.Windows.Forms.Button();
            this.ds_situacao = new Componentes.EditDefault(this.components);
            this.cd_st = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_st = new System.Windows.Forms.Button();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gDetRecIsenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetRecIsenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ds_situacao);
            this.pDados.Controls.Add(this.cd_st);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.bb_st);
            this.pDados.Controls.Add(this.ds_imposto);
            this.pDados.Controls.Add(this.CD_Imposto);
            this.pDados.Controls.Add(this.LB_CD_Imposto);
            this.pDados.Controls.Add(this.bb_imposto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_detrecisenta);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.id_detrecisenta);
            this.pDados.Size = new System.Drawing.Size(659, 109);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gDetRecIsenta);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gDetRecIsenta, 0);
            // 
            // gDetRecIsenta
            // 
            this.gDetRecIsenta.AllowUserToAddRows = false;
            this.gDetRecIsenta.AllowUserToDeleteRows = false;
            this.gDetRecIsenta.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gDetRecIsenta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gDetRecIsenta.AutoGenerateColumns = false;
            this.gDetRecIsenta.BackgroundColor = System.Drawing.Color.LightGray;
            this.gDetRecIsenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gDetRecIsenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gDetRecIsenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gDetRecIsenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gDetRecIsenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iddetrecisentastrDataGridViewTextBoxColumn,
            this.dsdetrecisentaDataGridViewTextBoxColumn,
            this.Cd_impostostr,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.gDetRecIsenta.DataSource = this.bsDetRecIsenta;
            this.gDetRecIsenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gDetRecIsenta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gDetRecIsenta.Location = new System.Drawing.Point(0, 109);
            this.gDetRecIsenta.Name = "gDetRecIsenta";
            this.gDetRecIsenta.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gDetRecIsenta.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gDetRecIsenta.RowHeadersWidth = 23;
            this.gDetRecIsenta.Size = new System.Drawing.Size(659, 226);
            this.gDetRecIsenta.TabIndex = 1;
            this.gDetRecIsenta.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gDetRecIsenta_ColumnHeaderMouseClick);
            // 
            // iddetrecisentastrDataGridViewTextBoxColumn
            // 
            this.iddetrecisentastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iddetrecisentastrDataGridViewTextBoxColumn.DataPropertyName = "Id_detrecisentastr";
            this.iddetrecisentastrDataGridViewTextBoxColumn.HeaderText = "Id. Natureza";
            this.iddetrecisentastrDataGridViewTextBoxColumn.Name = "iddetrecisentastrDataGridViewTextBoxColumn";
            this.iddetrecisentastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.iddetrecisentastrDataGridViewTextBoxColumn.Width = 90;
            // 
            // dsdetrecisentaDataGridViewTextBoxColumn
            // 
            this.dsdetrecisentaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsdetrecisentaDataGridViewTextBoxColumn.DataPropertyName = "Ds_detrecisenta";
            this.dsdetrecisentaDataGridViewTextBoxColumn.HeaderText = "Natureza Receita";
            this.dsdetrecisentaDataGridViewTextBoxColumn.Name = "dsdetrecisentaDataGridViewTextBoxColumn";
            this.dsdetrecisentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsdetrecisentaDataGridViewTextBoxColumn.Width = 106;
            // 
            // Cd_impostostr
            // 
            this.Cd_impostostr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_impostostr.DataPropertyName = "Cd_impostostr";
            this.Cd_impostostr.HeaderText = "Cd. Imposto";
            this.Cd_impostostr.Name = "Cd_impostostr";
            this.Cd_impostostr.ReadOnly = true;
            this.Cd_impostostr.Width = 81;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ds_imposto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Imposto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 69;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Cd_st";
            this.dataGridViewTextBoxColumn2.HeaderText = "Cd. St";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 48;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Ds_situacao";
            this.dataGridViewTextBoxColumn3.HeaderText = "Situação Tributaria";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 111;
            // 
            // bsDetRecIsenta
            // 
            this.bsDetRecIsenta.DataSource = typeof(CamadaDados.Fiscal.TList_DetRecIsentaPisCofins);
            // 
            // id_detrecisenta
            // 
            this.id_detrecisenta.BackColor = System.Drawing.SystemColors.Window;
            this.id_detrecisenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_detrecisenta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDetRecIsenta, "Id_detrecisentastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_detrecisenta.Enabled = false;
            this.id_detrecisenta.Location = new System.Drawing.Point(68, 55);
            this.id_detrecisenta.Name = "id_detrecisenta";
            this.id_detrecisenta.NM_Alias = "";
            this.id_detrecisenta.NM_Campo = "";
            this.id_detrecisenta.NM_CampoBusca = "";
            this.id_detrecisenta.NM_Param = "";
            this.id_detrecisenta.QTD_Zero = 0;
            this.id_detrecisenta.Size = new System.Drawing.Size(71, 20);
            this.id_detrecisenta.ST_AutoInc = false;
            this.id_detrecisenta.ST_DisableAuto = true;
            this.id_detrecisenta.ST_Float = false;
            this.id_detrecisenta.ST_Gravar = true;
            this.id_detrecisenta.ST_Int = true;
            this.id_detrecisenta.ST_LimpaCampo = true;
            this.id_detrecisenta.ST_NotNull = true;
            this.id_detrecisenta.ST_PrimaryKey = true;
            this.id_detrecisenta.TabIndex = 4;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsDetRecIsenta;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 335);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(659, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
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
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descrição:";
            // 
            // ds_detrecisenta
            // 
            this.ds_detrecisenta.BackColor = System.Drawing.SystemColors.Window;
            this.ds_detrecisenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_detrecisenta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDetRecIsenta, "Ds_detrecisenta", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_detrecisenta.Enabled = false;
            this.ds_detrecisenta.Location = new System.Drawing.Point(68, 81);
            this.ds_detrecisenta.Name = "ds_detrecisenta";
            this.ds_detrecisenta.NM_Alias = "";
            this.ds_detrecisenta.NM_Campo = "";
            this.ds_detrecisenta.NM_CampoBusca = "";
            this.ds_detrecisenta.NM_Param = "";
            this.ds_detrecisenta.QTD_Zero = 0;
            this.ds_detrecisenta.Size = new System.Drawing.Size(583, 20);
            this.ds_detrecisenta.ST_AutoInc = false;
            this.ds_detrecisenta.ST_DisableAuto = false;
            this.ds_detrecisenta.ST_Float = false;
            this.ds_detrecisenta.ST_Gravar = true;
            this.ds_detrecisenta.ST_Int = false;
            this.ds_detrecisenta.ST_LimpaCampo = true;
            this.ds_detrecisenta.ST_NotNull = true;
            this.ds_detrecisenta.ST_PrimaryKey = false;
            this.ds_detrecisenta.TabIndex = 5;
            // 
            // ds_imposto
            // 
            this.ds_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDetRecIsenta, "Ds_imposto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_imposto.Enabled = false;
            this.ds_imposto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_imposto.Location = new System.Drawing.Point(159, 3);
            this.ds_imposto.Name = "ds_imposto";
            this.ds_imposto.NM_Alias = "";
            this.ds_imposto.NM_Campo = "ds_imposto";
            this.ds_imposto.NM_CampoBusca = "ds_imposto";
            this.ds_imposto.NM_Param = "";
            this.ds_imposto.QTD_Zero = 0;
            this.ds_imposto.ReadOnly = true;
            this.ds_imposto.Size = new System.Drawing.Size(492, 20);
            this.ds_imposto.ST_AutoInc = false;
            this.ds_imposto.ST_DisableAuto = false;
            this.ds_imposto.ST_Float = false;
            this.ds_imposto.ST_Gravar = false;
            this.ds_imposto.ST_Int = false;
            this.ds_imposto.ST_LimpaCampo = true;
            this.ds_imposto.ST_NotNull = false;
            this.ds_imposto.ST_PrimaryKey = false;
            this.ds_imposto.TabIndex = 52;
            // 
            // CD_Imposto
            // 
            this.CD_Imposto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDetRecIsenta, "Cd_impostostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Imposto.Enabled = false;
            this.CD_Imposto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Imposto.Location = new System.Drawing.Point(68, 3);
            this.CD_Imposto.MaxLength = 3;
            this.CD_Imposto.Name = "CD_Imposto";
            this.CD_Imposto.NM_Alias = "a";
            this.CD_Imposto.NM_Campo = "CD_Imposto";
            this.CD_Imposto.NM_CampoBusca = "CD_Imposto";
            this.CD_Imposto.NM_Param = "@P_CD_IMPOSTO";
            this.CD_Imposto.QTD_Zero = 0;
            this.CD_Imposto.Size = new System.Drawing.Size(55, 20);
            this.CD_Imposto.ST_AutoInc = false;
            this.CD_Imposto.ST_DisableAuto = false;
            this.CD_Imposto.ST_Float = false;
            this.CD_Imposto.ST_Gravar = true;
            this.CD_Imposto.ST_Int = false;
            this.CD_Imposto.ST_LimpaCampo = true;
            this.CD_Imposto.ST_NotNull = true;
            this.CD_Imposto.ST_PrimaryKey = true;
            this.CD_Imposto.TabIndex = 0;
            this.CD_Imposto.Leave += new System.EventHandler(this.CD_Imposto_Leave);
            // 
            // LB_CD_Imposto
            // 
            this.LB_CD_Imposto.AutoSize = true;
            this.LB_CD_Imposto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Imposto.Location = new System.Drawing.Point(15, 6);
            this.LB_CD_Imposto.Name = "LB_CD_Imposto";
            this.LB_CD_Imposto.Size = new System.Drawing.Size(47, 13);
            this.LB_CD_Imposto.TabIndex = 51;
            this.LB_CD_Imposto.Text = "Imposto:";
            // 
            // bb_imposto
            // 
            this.bb_imposto.Enabled = false;
            this.bb_imposto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_imposto.Image = ((System.Drawing.Image)(resources.GetObject("bb_imposto.Image")));
            this.bb_imposto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_imposto.Location = new System.Drawing.Point(125, 3);
            this.bb_imposto.Name = "bb_imposto";
            this.bb_imposto.Size = new System.Drawing.Size(30, 20);
            this.bb_imposto.TabIndex = 1;
            this.bb_imposto.UseVisualStyleBackColor = true;
            this.bb_imposto.Click += new System.EventHandler(this.bb_imposto_Click);
            // 
            // ds_situacao
            // 
            this.ds_situacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_situacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_situacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDetRecIsenta, "Ds_situacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_situacao.Enabled = false;
            this.ds_situacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_situacao.Location = new System.Drawing.Point(159, 29);
            this.ds_situacao.Name = "ds_situacao";
            this.ds_situacao.NM_Alias = "";
            this.ds_situacao.NM_Campo = "ds_situacao";
            this.ds_situacao.NM_CampoBusca = "ds_situacao";
            this.ds_situacao.NM_Param = "@P_DS_SITUACAO";
            this.ds_situacao.QTD_Zero = 0;
            this.ds_situacao.ReadOnly = true;
            this.ds_situacao.Size = new System.Drawing.Size(492, 20);
            this.ds_situacao.ST_AutoInc = false;
            this.ds_situacao.ST_DisableAuto = false;
            this.ds_situacao.ST_Float = false;
            this.ds_situacao.ST_Gravar = false;
            this.ds_situacao.ST_Int = false;
            this.ds_situacao.ST_LimpaCampo = true;
            this.ds_situacao.ST_NotNull = false;
            this.ds_situacao.ST_PrimaryKey = false;
            this.ds_situacao.TabIndex = 56;
            // 
            // cd_st
            // 
            this.cd_st.BackColor = System.Drawing.SystemColors.Window;
            this.cd_st.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_st.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDetRecIsenta, "Cd_st", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_st.Enabled = false;
            this.cd_st.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_st.Location = new System.Drawing.Point(68, 29);
            this.cd_st.MaxLength = 3;
            this.cd_st.Name = "cd_st";
            this.cd_st.NM_Alias = "a";
            this.cd_st.NM_Campo = "cd_st";
            this.cd_st.NM_CampoBusca = "cd_st";
            this.cd_st.NM_Param = "@P_CD_IMPOSTO";
            this.cd_st.QTD_Zero = 0;
            this.cd_st.Size = new System.Drawing.Size(55, 20);
            this.cd_st.ST_AutoInc = false;
            this.cd_st.ST_DisableAuto = false;
            this.cd_st.ST_Float = false;
            this.cd_st.ST_Gravar = true;
            this.cd_st.ST_Int = false;
            this.cd_st.ST_LimpaCampo = true;
            this.cd_st.ST_NotNull = true;
            this.cd_st.ST_PrimaryKey = true;
            this.cd_st.TabIndex = 2;
            this.cd_st.Leave += new System.EventHandler(this.cd_st_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(13, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Sit. Trib.:";
            // 
            // bb_st
            // 
            this.bb_st.Enabled = false;
            this.bb_st.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_st.Image = ((System.Drawing.Image)(resources.GetObject("bb_st.Image")));
            this.bb_st.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_st.Location = new System.Drawing.Point(125, 29);
            this.bb_st.Name = "bb_st";
            this.bb_st.Size = new System.Drawing.Size(30, 20);
            this.bb_st.TabIndex = 3;
            this.bb_st.UseVisualStyleBackColor = true;
            this.bb_st.Click += new System.EventHandler(this.bb_st_Click);
            // 
            // TFCadDetRecIsentaPisCofins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadDetRecIsentaPisCofins";
            this.Text = "Cadastro Natureza Receita Isenta PIS/COFINS";
            this.Load += new System.EventHandler(this.TFCadDetRecIsentaPisCofins_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadDetRecIsentaPisCofins_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gDetRecIsenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetRecIsenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gDetRecIsenta;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_detrecisenta;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_detrecisenta;
        private System.Windows.Forms.BindingSource bsDetRecIsenta;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault ds_situacao;
        private Componentes.EditDefault cd_st;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button bb_st;
        private Componentes.EditDefault ds_imposto;
        private Componentes.EditDefault CD_Imposto;
        private System.Windows.Forms.Label LB_CD_Imposto;
        public System.Windows.Forms.Button bb_imposto;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddetrecisentastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsdetrecisentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_impostostr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}
