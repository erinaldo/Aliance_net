namespace Almoxarifado.Cadastros
{
    partial class TFCadCelulaArm
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
            System.Windows.Forms.Label id_ruaLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label ds_secaoLabel;
            System.Windows.Forms.Label id_secaoLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCelulaArm));
            this.gCelulaArm = new Componentes.DataGridDefault(this.components);
            this.idruastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsruaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idsecaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dssecaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcelulastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscelulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCelulaArm = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.Id_Rua = new Componentes.EditDefault(this.components);
            this.Ds_Rua = new Componentes.EditDefault(this.components);
            this.bb_Rua = new System.Windows.Forms.Button();
            this.id_secao = new Componentes.EditDefault(this.components);
            this.ds_secao = new Componentes.EditDefault(this.components);
            this.bb_secao = new System.Windows.Forms.Button();
            this.id_celula = new Componentes.EditDefault(this.components);
            this.ds_celula = new Componentes.EditDefault(this.components);
            id_ruaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ds_secaoLabel = new System.Windows.Forms.Label();
            id_secaoLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCelulaArm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCelulaArm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.id_celula);
            this.pDados.Controls.Add(ds_secaoLabel);
            this.pDados.Controls.Add(this.ds_celula);
            this.pDados.Controls.Add(id_secaoLabel);
            this.pDados.Controls.Add(this.id_secao);
            this.pDados.Controls.Add(this.ds_secao);
            this.pDados.Controls.Add(this.bb_secao);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.Id_Rua);
            this.pDados.Controls.Add(this.Ds_Rua);
            this.pDados.Controls.Add(this.bb_Rua);
            this.pDados.Controls.Add(id_ruaLabel);
            this.pDados.Size = new System.Drawing.Size(882, 109);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(894, 475);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCelulaArm);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(886, 449);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCelulaArm, 0);
            // 
            // id_ruaLabel
            // 
            id_ruaLabel.AutoSize = true;
            id_ruaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            id_ruaLabel.Location = new System.Drawing.Point(31, 6);
            id_ruaLabel.Name = "id_ruaLabel";
            id_ruaLabel.Size = new System.Drawing.Size(34, 13);
            id_ruaLabel.TabIndex = 7;
            id_ruaLabel.Text = "Rua:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(18, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 13);
            label1.TabIndex = 11;
            label1.Text = "Seção:";
            // 
            // ds_secaoLabel
            // 
            ds_secaoLabel.AutoSize = true;
            ds_secaoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ds_secaoLabel.Location = new System.Drawing.Point(19, 84);
            ds_secaoLabel.Name = "ds_secaoLabel";
            ds_secaoLabel.Size = new System.Drawing.Size(46, 13);
            ds_secaoLabel.TabIndex = 16;
            ds_secaoLabel.Text = "Celula:";
            // 
            // id_secaoLabel
            // 
            id_secaoLabel.AutoSize = true;
            id_secaoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            id_secaoLabel.Location = new System.Drawing.Point(0, 57);
            id_secaoLabel.Name = "id_secaoLabel";
            id_secaoLabel.Size = new System.Drawing.Size(65, 13);
            id_secaoLabel.TabIndex = 13;
            id_secaoLabel.Text = "Id. Celula:";
            // 
            // gCelulaArm
            // 
            this.gCelulaArm.AllowUserToAddRows = false;
            this.gCelulaArm.AllowUserToDeleteRows = false;
            this.gCelulaArm.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gCelulaArm.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gCelulaArm.AutoGenerateColumns = false;
            this.gCelulaArm.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCelulaArm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCelulaArm.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCelulaArm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gCelulaArm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCelulaArm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idruastrDataGridViewTextBoxColumn,
            this.dsruaDataGridViewTextBoxColumn,
            this.idsecaostrDataGridViewTextBoxColumn,
            this.dssecaoDataGridViewTextBoxColumn,
            this.idcelulastrDataGridViewTextBoxColumn,
            this.dscelulaDataGridViewTextBoxColumn});
            this.gCelulaArm.DataSource = this.bsCelulaArm;
            this.gCelulaArm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCelulaArm.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCelulaArm.Location = new System.Drawing.Point(0, 109);
            this.gCelulaArm.Name = "gCelulaArm";
            this.gCelulaArm.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCelulaArm.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gCelulaArm.RowHeadersWidth = 23;
            this.gCelulaArm.Size = new System.Drawing.Size(882, 311);
            this.gCelulaArm.TabIndex = 1;
            this.gCelulaArm.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gCelulaArm_ColumnHeaderMouseClick);
            // 
            // idruastrDataGridViewTextBoxColumn
            // 
            this.idruastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idruastrDataGridViewTextBoxColumn.DataPropertyName = "Id_ruastr";
            this.idruastrDataGridViewTextBoxColumn.HeaderText = "Id. Rua";
            this.idruastrDataGridViewTextBoxColumn.Name = "idruastrDataGridViewTextBoxColumn";
            this.idruastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idruastrDataGridViewTextBoxColumn.Width = 67;
            // 
            // dsruaDataGridViewTextBoxColumn
            // 
            this.dsruaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsruaDataGridViewTextBoxColumn.DataPropertyName = "Ds_rua";
            this.dsruaDataGridViewTextBoxColumn.HeaderText = "Rua";
            this.dsruaDataGridViewTextBoxColumn.Name = "dsruaDataGridViewTextBoxColumn";
            this.dsruaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsruaDataGridViewTextBoxColumn.Width = 52;
            // 
            // idsecaostrDataGridViewTextBoxColumn
            // 
            this.idsecaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idsecaostrDataGridViewTextBoxColumn.DataPropertyName = "Id_secaostr";
            this.idsecaostrDataGridViewTextBoxColumn.HeaderText = "Id. Seção";
            this.idsecaostrDataGridViewTextBoxColumn.Name = "idsecaostrDataGridViewTextBoxColumn";
            this.idsecaostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idsecaostrDataGridViewTextBoxColumn.Width = 78;
            // 
            // dssecaoDataGridViewTextBoxColumn
            // 
            this.dssecaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dssecaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_secao";
            this.dssecaoDataGridViewTextBoxColumn.HeaderText = "Seção";
            this.dssecaoDataGridViewTextBoxColumn.Name = "dssecaoDataGridViewTextBoxColumn";
            this.dssecaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dssecaoDataGridViewTextBoxColumn.Width = 63;
            // 
            // idcelulastrDataGridViewTextBoxColumn
            // 
            this.idcelulastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idcelulastrDataGridViewTextBoxColumn.DataPropertyName = "Id_celulastr";
            this.idcelulastrDataGridViewTextBoxColumn.HeaderText = "Id. Celula";
            this.idcelulastrDataGridViewTextBoxColumn.Name = "idcelulastrDataGridViewTextBoxColumn";
            this.idcelulastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idcelulastrDataGridViewTextBoxColumn.Width = 76;
            // 
            // dscelulaDataGridViewTextBoxColumn
            // 
            this.dscelulaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscelulaDataGridViewTextBoxColumn.DataPropertyName = "Ds_celula";
            this.dscelulaDataGridViewTextBoxColumn.HeaderText = "Celula";
            this.dscelulaDataGridViewTextBoxColumn.Name = "dscelulaDataGridViewTextBoxColumn";
            this.dscelulaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscelulaDataGridViewTextBoxColumn.Width = 61;
            // 
            // bsCelulaArm
            // 
            this.bsCelulaArm.DataSource = typeof(CamadaDados.Almoxarifado.TList_CadCelulaArm);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCelulaArm;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 420);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(882, 25);
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
            // Id_Rua
            // 
            this.Id_Rua.BackColor = System.Drawing.SystemColors.Window;
            this.Id_Rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Id_Rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCelulaArm, "Id_ruastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Id_Rua.Enabled = false;
            this.Id_Rua.Location = new System.Drawing.Point(71, 3);
            this.Id_Rua.MaxLength = 9999;
            this.Id_Rua.Name = "Id_Rua";
            this.Id_Rua.NM_Alias = "";
            this.Id_Rua.NM_Campo = "id_rua";
            this.Id_Rua.NM_CampoBusca = "id_rua";
            this.Id_Rua.NM_Param = "@P_ID_RUA";
            this.Id_Rua.QTD_Zero = 0;
            this.Id_Rua.Size = new System.Drawing.Size(66, 20);
            this.Id_Rua.ST_AutoInc = false;
            this.Id_Rua.ST_DisableAuto = false;
            this.Id_Rua.ST_Float = false;
            this.Id_Rua.ST_Gravar = true;
            this.Id_Rua.ST_Int = true;
            this.Id_Rua.ST_LimpaCampo = true;
            this.Id_Rua.ST_NotNull = true;
            this.Id_Rua.ST_PrimaryKey = true;
            this.Id_Rua.TabIndex = 5;
            this.Id_Rua.Leave += new System.EventHandler(this.Id_Rua_Leave);
            // 
            // Ds_Rua
            // 
            this.Ds_Rua.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_Rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_Rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCelulaArm, "Ds_rua", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_Rua.Enabled = false;
            this.Ds_Rua.Location = new System.Drawing.Point(179, 3);
            this.Ds_Rua.Name = "Ds_Rua";
            this.Ds_Rua.NM_Alias = "";
            this.Ds_Rua.NM_Campo = "ds_rua";
            this.Ds_Rua.NM_CampoBusca = "ds_rua";
            this.Ds_Rua.NM_Param = "@P_DS_RUA";
            this.Ds_Rua.QTD_Zero = 0;
            this.Ds_Rua.Size = new System.Drawing.Size(415, 20);
            this.Ds_Rua.ST_AutoInc = false;
            this.Ds_Rua.ST_DisableAuto = false;
            this.Ds_Rua.ST_Float = false;
            this.Ds_Rua.ST_Gravar = false;
            this.Ds_Rua.ST_Int = false;
            this.Ds_Rua.ST_LimpaCampo = true;
            this.Ds_Rua.ST_NotNull = false;
            this.Ds_Rua.ST_PrimaryKey = false;
            this.Ds_Rua.TabIndex = 8;
            // 
            // bb_Rua
            // 
            this.bb_Rua.Enabled = false;
            this.bb_Rua.Image = ((System.Drawing.Image)(resources.GetObject("bb_Rua.Image")));
            this.bb_Rua.Location = new System.Drawing.Point(143, 2);
            this.bb_Rua.Name = "bb_Rua";
            this.bb_Rua.Size = new System.Drawing.Size(30, 20);
            this.bb_Rua.TabIndex = 6;
            this.bb_Rua.UseVisualStyleBackColor = true;
            this.bb_Rua.Click += new System.EventHandler(this.bb_Rua_Click);
            // 
            // id_secao
            // 
            this.id_secao.BackColor = System.Drawing.SystemColors.Window;
            this.id_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_secao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCelulaArm, "Id_secaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_secao.Enabled = false;
            this.id_secao.Location = new System.Drawing.Point(71, 29);
            this.id_secao.MaxLength = 9999;
            this.id_secao.Name = "id_secao";
            this.id_secao.NM_Alias = "";
            this.id_secao.NM_Campo = "id_rua";
            this.id_secao.NM_CampoBusca = "id_rua";
            this.id_secao.NM_Param = "@P_ID_RUA";
            this.id_secao.QTD_Zero = 0;
            this.id_secao.Size = new System.Drawing.Size(66, 20);
            this.id_secao.ST_AutoInc = false;
            this.id_secao.ST_DisableAuto = false;
            this.id_secao.ST_Float = false;
            this.id_secao.ST_Gravar = true;
            this.id_secao.ST_Int = true;
            this.id_secao.ST_LimpaCampo = true;
            this.id_secao.ST_NotNull = true;
            this.id_secao.ST_PrimaryKey = true;
            this.id_secao.TabIndex = 9;
            this.id_secao.Leave += new System.EventHandler(this.id_secao_Leave);
            // 
            // ds_secao
            // 
            this.ds_secao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_secao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCelulaArm, "Ds_secao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_secao.Enabled = false;
            this.ds_secao.Location = new System.Drawing.Point(179, 29);
            this.ds_secao.Name = "ds_secao";
            this.ds_secao.NM_Alias = "";
            this.ds_secao.NM_Campo = "ds_secao";
            this.ds_secao.NM_CampoBusca = "ds_secao";
            this.ds_secao.NM_Param = "@P_DS_RUA";
            this.ds_secao.QTD_Zero = 0;
            this.ds_secao.Size = new System.Drawing.Size(415, 20);
            this.ds_secao.ST_AutoInc = false;
            this.ds_secao.ST_DisableAuto = false;
            this.ds_secao.ST_Float = false;
            this.ds_secao.ST_Gravar = false;
            this.ds_secao.ST_Int = false;
            this.ds_secao.ST_LimpaCampo = true;
            this.ds_secao.ST_NotNull = false;
            this.ds_secao.ST_PrimaryKey = false;
            this.ds_secao.TabIndex = 12;
            // 
            // bb_secao
            // 
            this.bb_secao.Enabled = false;
            this.bb_secao.Image = ((System.Drawing.Image)(resources.GetObject("bb_secao.Image")));
            this.bb_secao.Location = new System.Drawing.Point(143, 28);
            this.bb_secao.Name = "bb_secao";
            this.bb_secao.Size = new System.Drawing.Size(30, 20);
            this.bb_secao.TabIndex = 10;
            this.bb_secao.UseVisualStyleBackColor = true;
            this.bb_secao.Click += new System.EventHandler(this.bb_secao_Click);
            // 
            // id_celula
            // 
            this.id_celula.BackColor = System.Drawing.SystemColors.Window;
            this.id_celula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_celula.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCelulaArm, "Id_celulastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_celula.Enabled = false;
            this.id_celula.Location = new System.Drawing.Point(71, 55);
            this.id_celula.Name = "id_celula";
            this.id_celula.NM_Alias = "";
            this.id_celula.NM_Campo = "id_celula";
            this.id_celula.NM_CampoBusca = "id_celula";
            this.id_celula.NM_Param = "@P_ID_SECAO";
            this.id_celula.QTD_Zero = 0;
            this.id_celula.Size = new System.Drawing.Size(66, 20);
            this.id_celula.ST_AutoInc = false;
            this.id_celula.ST_DisableAuto = true;
            this.id_celula.ST_Float = false;
            this.id_celula.ST_Gravar = true;
            this.id_celula.ST_Int = true;
            this.id_celula.ST_LimpaCampo = true;
            this.id_celula.ST_NotNull = true;
            this.id_celula.ST_PrimaryKey = true;
            this.id_celula.TabIndex = 14;
            // 
            // ds_celula
            // 
            this.ds_celula.BackColor = System.Drawing.SystemColors.Window;
            this.ds_celula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_celula.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCelulaArm, "Ds_celula", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_celula.Enabled = false;
            this.ds_celula.Location = new System.Drawing.Point(71, 81);
            this.ds_celula.MaxLength = 20;
            this.ds_celula.Name = "ds_celula";
            this.ds_celula.NM_Alias = "";
            this.ds_celula.NM_Campo = "";
            this.ds_celula.NM_CampoBusca = "";
            this.ds_celula.NM_Param = "";
            this.ds_celula.QTD_Zero = 0;
            this.ds_celula.Size = new System.Drawing.Size(523, 20);
            this.ds_celula.ST_AutoInc = false;
            this.ds_celula.ST_DisableAuto = false;
            this.ds_celula.ST_Float = false;
            this.ds_celula.ST_Gravar = true;
            this.ds_celula.ST_Int = false;
            this.ds_celula.ST_LimpaCampo = true;
            this.ds_celula.ST_NotNull = true;
            this.ds_celula.ST_PrimaryKey = false;
            this.ds_celula.TabIndex = 15;
            // 
            // TFCadCelulaArm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(894, 518);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadCelulaArm";
            this.Text = "Cadastro Celula Almoxarifado";
            this.Load += new System.EventHandler(this.TFCadCelulaArm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCelulaArm_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCelulaArm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCelulaArm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCelulaArm;
        private System.Windows.Forms.DataGridViewTextBoxColumn idruastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsruaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idsecaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dssecaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcelulastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscelulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsCelulaArm;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault id_secao;
        private Componentes.EditDefault ds_secao;
        private System.Windows.Forms.Button bb_secao;
        private Componentes.EditDefault Id_Rua;
        private Componentes.EditDefault Ds_Rua;
        private System.Windows.Forms.Button bb_Rua;
        private Componentes.EditDefault id_celula;
        private Componentes.EditDefault ds_celula;
    }
}
