namespace Servicos.Cadastros
{
    partial class TFCad_OseProximaEtapa
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
            System.Windows.Forms.Label id_EtapaLabel;
            System.Windows.Forms.Label id_ProximaEtapaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_OseProximaEtapa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Bs_CadOseProximaEtapa = new System.Windows.Forms.BindingSource(this.components);
            this.BB_Etapa = new System.Windows.Forms.Button();
            this.BB_ProximaEtapa = new System.Windows.Forms.Button();
            this.Id_Etapa = new Componentes.EditDefault(this.components);
            this.Id_ProximaEtapa = new Componentes.EditDefault(this.components);
            this.Ds_Etapa = new Componentes.EditDefault(this.components);
            this.Ds_ProximaEtapa = new Componentes.EditDefault(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.idetapastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idproximaetapastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            id_EtapaLabel = new System.Windows.Forms.Label();
            id_ProximaEtapaLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bs_CadOseProximaEtapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.Ds_ProximaEtapa);
            this.pDados.Controls.Add(this.Ds_Etapa);
            this.pDados.Controls.Add(this.Id_ProximaEtapa);
            this.pDados.Controls.Add(this.Id_Etapa);
            this.pDados.Controls.Add(this.BB_ProximaEtapa);
            this.pDados.Controls.Add(this.BB_Etapa);
            this.pDados.Controls.Add(id_ProximaEtapaLabel);
            this.pDados.Controls.Add(id_EtapaLabel);
            this.pDados.Size = new System.Drawing.Size(650, 61);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(662, 348);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(654, 322);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // id_EtapaLabel
            // 
            id_EtapaLabel.AutoSize = true;
            id_EtapaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            id_EtapaLabel.Location = new System.Drawing.Point(17, 9);
            id_EtapaLabel.Name = "id_EtapaLabel";
            id_EtapaLabel.Size = new System.Drawing.Size(65, 13);
            id_EtapaLabel.TabIndex = 0;
            id_EtapaLabel.Text = "Etapa Atual:";
            // 
            // id_ProximaEtapaLabel
            // 
            id_ProximaEtapaLabel.AutoSize = true;
            id_ProximaEtapaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            id_ProximaEtapaLabel.Location = new System.Drawing.Point(4, 32);
            id_ProximaEtapaLabel.Name = "id_ProximaEtapaLabel";
            id_ProximaEtapaLabel.Size = new System.Drawing.Size(78, 13);
            id_ProximaEtapaLabel.TabIndex = 2;
            id_ProximaEtapaLabel.Text = "Proxima Etapa:";
            // 
            // Bs_CadOseProximaEtapa
            // 
            this.Bs_CadOseProximaEtapa.DataSource = typeof(CamadaDados.Servicos.Cadastros.TList_ProximaEtapa);
            // 
            // BB_Etapa
            // 
            this.BB_Etapa.Enabled = false;
            this.BB_Etapa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Etapa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Etapa.Image")));
            this.BB_Etapa.Location = new System.Drawing.Point(161, 6);
            this.BB_Etapa.Name = "BB_Etapa";
            this.BB_Etapa.Size = new System.Drawing.Size(32, 20);
            this.BB_Etapa.TabIndex = 1;
            this.BB_Etapa.UseVisualStyleBackColor = true;
            this.BB_Etapa.Click += new System.EventHandler(this.BB_Etapa_Click);
            // 
            // BB_ProximaEtapa
            // 
            this.BB_ProximaEtapa.Enabled = false;
            this.BB_ProximaEtapa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_ProximaEtapa.Image = ((System.Drawing.Image)(resources.GetObject("BB_ProximaEtapa.Image")));
            this.BB_ProximaEtapa.Location = new System.Drawing.Point(161, 29);
            this.BB_ProximaEtapa.Name = "BB_ProximaEtapa";
            this.BB_ProximaEtapa.Size = new System.Drawing.Size(32, 20);
            this.BB_ProximaEtapa.TabIndex = 3;
            this.BB_ProximaEtapa.UseVisualStyleBackColor = true;
            this.BB_ProximaEtapa.Click += new System.EventHandler(this.BB_ProximaEtapa_Click);
            // 
            // Id_Etapa
            // 
            this.Id_Etapa.BackColor = System.Drawing.SystemColors.Window;
            this.Id_Etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Id_Etapa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_CadOseProximaEtapa, "Id_etapastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Id_Etapa.Enabled = false;
            this.Id_Etapa.Location = new System.Drawing.Point(88, 6);
            this.Id_Etapa.Name = "Id_Etapa";
            this.Id_Etapa.NM_Alias = "";
            this.Id_Etapa.NM_Campo = "id_etapa";
            this.Id_Etapa.NM_CampoBusca = "id_etapa";
            this.Id_Etapa.NM_Param = "@P_ID_ETAPA";
            this.Id_Etapa.QTD_Zero = 0;
            this.Id_Etapa.Size = new System.Drawing.Size(67, 20);
            this.Id_Etapa.ST_AutoInc = false;
            this.Id_Etapa.ST_DisableAuto = false;
            this.Id_Etapa.ST_Float = false;
            this.Id_Etapa.ST_Gravar = true;
            this.Id_Etapa.ST_Int = true;
            this.Id_Etapa.ST_LimpaCampo = true;
            this.Id_Etapa.ST_NotNull = true;
            this.Id_Etapa.ST_PrimaryKey = true;
            this.Id_Etapa.TabIndex = 0;
            this.Id_Etapa.Leave += new System.EventHandler(this.id_Etapa_Leave);
            // 
            // Id_ProximaEtapa
            // 
            this.Id_ProximaEtapa.BackColor = System.Drawing.SystemColors.Window;
            this.Id_ProximaEtapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Id_ProximaEtapa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_CadOseProximaEtapa, "Id_proximaetapastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Id_ProximaEtapa.Enabled = false;
            this.Id_ProximaEtapa.Location = new System.Drawing.Point(88, 29);
            this.Id_ProximaEtapa.Name = "Id_ProximaEtapa";
            this.Id_ProximaEtapa.NM_Alias = "";
            this.Id_ProximaEtapa.NM_Campo = "id_Etapa";
            this.Id_ProximaEtapa.NM_CampoBusca = "id_Etapa";
            this.Id_ProximaEtapa.NM_Param = "@P_ID_ETAPA";
            this.Id_ProximaEtapa.QTD_Zero = 0;
            this.Id_ProximaEtapa.Size = new System.Drawing.Size(67, 20);
            this.Id_ProximaEtapa.ST_AutoInc = false;
            this.Id_ProximaEtapa.ST_DisableAuto = false;
            this.Id_ProximaEtapa.ST_Float = false;
            this.Id_ProximaEtapa.ST_Gravar = true;
            this.Id_ProximaEtapa.ST_Int = true;
            this.Id_ProximaEtapa.ST_LimpaCampo = true;
            this.Id_ProximaEtapa.ST_NotNull = true;
            this.Id_ProximaEtapa.ST_PrimaryKey = true;
            this.Id_ProximaEtapa.TabIndex = 2;
            this.Id_ProximaEtapa.Leave += new System.EventHandler(this.id_ProximaEtapa_Leave);
            // 
            // Ds_Etapa
            // 
            this.Ds_Etapa.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_Etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_Etapa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_CadOseProximaEtapa, "Ds_etapa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_Etapa.Enabled = false;
            this.Ds_Etapa.Location = new System.Drawing.Point(199, 6);
            this.Ds_Etapa.Name = "Ds_Etapa";
            this.Ds_Etapa.NM_Alias = "";
            this.Ds_Etapa.NM_Campo = "ds_etapa";
            this.Ds_Etapa.NM_CampoBusca = "ds_etapa";
            this.Ds_Etapa.NM_Param = "@P_DS_ETAPA";
            this.Ds_Etapa.QTD_Zero = 0;
            this.Ds_Etapa.Size = new System.Drawing.Size(404, 20);
            this.Ds_Etapa.ST_AutoInc = false;
            this.Ds_Etapa.ST_DisableAuto = false;
            this.Ds_Etapa.ST_Float = false;
            this.Ds_Etapa.ST_Gravar = false;
            this.Ds_Etapa.ST_Int = false;
            this.Ds_Etapa.ST_LimpaCampo = true;
            this.Ds_Etapa.ST_NotNull = false;
            this.Ds_Etapa.ST_PrimaryKey = false;
            this.Ds_Etapa.TabIndex = 13;
            // 
            // Ds_ProximaEtapa
            // 
            this.Ds_ProximaEtapa.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_ProximaEtapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_ProximaEtapa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_CadOseProximaEtapa, "Ds_proximaetapa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_ProximaEtapa.Enabled = false;
            this.Ds_ProximaEtapa.Location = new System.Drawing.Point(199, 29);
            this.Ds_ProximaEtapa.Name = "Ds_ProximaEtapa";
            this.Ds_ProximaEtapa.NM_Alias = "a";
            this.Ds_ProximaEtapa.NM_Campo = "ds_etapa";
            this.Ds_ProximaEtapa.NM_CampoBusca = "ds_etapa";
            this.Ds_ProximaEtapa.NM_Param = "@P_DS_ETAPA";
            this.Ds_ProximaEtapa.QTD_Zero = 0;
            this.Ds_ProximaEtapa.Size = new System.Drawing.Size(404, 20);
            this.Ds_ProximaEtapa.ST_AutoInc = false;
            this.Ds_ProximaEtapa.ST_DisableAuto = false;
            this.Ds_ProximaEtapa.ST_Float = false;
            this.Ds_ProximaEtapa.ST_Gravar = false;
            this.Ds_ProximaEtapa.ST_Int = false;
            this.Ds_ProximaEtapa.ST_LimpaCampo = true;
            this.Ds_ProximaEtapa.ST_NotNull = false;
            this.Ds_ProximaEtapa.ST_PrimaryKey = false;
            this.Ds_ProximaEtapa.TabIndex = 14;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idetapastrDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.idproximaetapastrDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn4});
            this.dataGridDefault1.DataSource = this.Bs_CadOseProximaEtapa;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 61);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(650, 232);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // idetapastrDataGridViewTextBoxColumn
            // 
            this.idetapastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idetapastrDataGridViewTextBoxColumn.DataPropertyName = "Id_etapastr";
            this.idetapastrDataGridViewTextBoxColumn.HeaderText = "Id. Etapa";
            this.idetapastrDataGridViewTextBoxColumn.Name = "idetapastrDataGridViewTextBoxColumn";
            this.idetapastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idetapastrDataGridViewTextBoxColumn.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_etapa";
            this.dataGridViewTextBoxColumn2.HeaderText = "Etapa Atual";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 87;
            // 
            // idproximaetapastrDataGridViewTextBoxColumn
            // 
            this.idproximaetapastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idproximaetapastrDataGridViewTextBoxColumn.DataPropertyName = "Id_proximaetapastr";
            this.idproximaetapastrDataGridViewTextBoxColumn.HeaderText = "Id. Proxima";
            this.idproximaetapastrDataGridViewTextBoxColumn.Name = "idproximaetapastrDataGridViewTextBoxColumn";
            this.idproximaetapastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idproximaetapastrDataGridViewTextBoxColumn.Width = 84;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Ds_proximaetapa";
            this.dataGridViewTextBoxColumn4.HeaderText = "Proxima Etapa";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.Bs_CadOseProximaEtapa;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 293);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(650, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total de Registros";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.ToolTipText = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.ToolTipText = "Registro Anterior";
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
            // TFCad_OseProximaEtapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(662, 391);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCad_OseProximaEtapa";
            this.Text = "Próxima Etapa";
            this.Load += new System.EventHandler(this.TFCad_OseProximaEtapa_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_OseProximaEtapa_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bs_CadOseProximaEtapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource Bs_CadOseProximaEtapa;
        public System.Windows.Forms.Button BB_ProximaEtapa;
        public System.Windows.Forms.Button BB_Etapa;
        private Componentes.EditDefault Id_ProximaEtapa;
        private Componentes.EditDefault Id_Etapa;
        private Componentes.EditDefault Ds_Etapa;
        private Componentes.EditDefault Ds_ProximaEtapa;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEtapaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsEtapaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProximaEtapaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsProximaEtapaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idetapastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproximaetapastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
