namespace Fazenda.Cadastros
{
    partial class TFCad_Equipamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Equipamento));
            this.gEquipamento = new Componentes.DataGridDefault(this.components);
            this.cdequipamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsequipamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdfazendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmfazendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoequipamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoconservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtaquisicaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlequipamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anoFabricDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsEquipamento = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.ds_equipamento = new Componentes.EditDefault(this.components);
            this.bb_equipamento = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_equipamento = new Componentes.EditDefault(this.components);
            this.nm_fazenda = new Componentes.EditDefault(this.components);
            this.bb_fazenda = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_fazenda = new Componentes.EditDefault(this.components);
            this.tp_equipamento = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tp_conservacao = new Componentes.ComboBoxDefault(this.components);
            this.dt_aquisicao = new Componentes.EditData(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.vl_equipamento = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.placa = new Componentes.EditMask(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.anofabric = new Componentes.EditDefault(this.components);
            this.observacao = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.vl_custohora = new Componentes.EditFloat(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEquipamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEquipamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_equipamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_custohora)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.vl_custohora);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.observacao);
            this.pDados.Controls.Add(this.anofabric);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.placa);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.vl_equipamento);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.dt_aquisicao);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.tp_conservacao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.tp_equipamento);
            this.pDados.Controls.Add(this.nm_fazenda);
            this.pDados.Controls.Add(this.bb_fazenda);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_fazenda);
            this.pDados.Controls.Add(this.ds_equipamento);
            this.pDados.Controls.Add(this.bb_equipamento);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_equipamento);
            this.pDados.Size = new System.Drawing.Size(842, 192);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(854, 485);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gEquipamento);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(846, 459);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gEquipamento, 0);
            // 
            // gEquipamento
            // 
            this.gEquipamento.AllowUserToAddRows = false;
            this.gEquipamento.AllowUserToDeleteRows = false;
            this.gEquipamento.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gEquipamento.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gEquipamento.AutoGenerateColumns = false;
            this.gEquipamento.BackgroundColor = System.Drawing.Color.LightGray;
            this.gEquipamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gEquipamento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEquipamento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gEquipamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gEquipamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdequipamentoDataGridViewTextBoxColumn,
            this.dsequipamentoDataGridViewTextBoxColumn,
            this.cdfazendaDataGridViewTextBoxColumn,
            this.nmfazendaDataGridViewTextBoxColumn,
            this.tipoequipamentoDataGridViewTextBoxColumn,
            this.tipoconservacaoDataGridViewTextBoxColumn,
            this.dtaquisicaoDataGridViewTextBoxColumn,
            this.vlequipamentoDataGridViewTextBoxColumn,
            this.placaDataGridViewTextBoxColumn,
            this.anoFabricDataGridViewTextBoxColumn,
            this.observacaoDataGridViewTextBoxColumn});
            this.gEquipamento.DataSource = this.bsEquipamento;
            this.gEquipamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gEquipamento.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gEquipamento.Location = new System.Drawing.Point(0, 192);
            this.gEquipamento.Name = "gEquipamento";
            this.gEquipamento.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEquipamento.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gEquipamento.RowHeadersWidth = 23;
            this.gEquipamento.Size = new System.Drawing.Size(842, 238);
            this.gEquipamento.TabIndex = 1;
            this.gEquipamento.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gEquipamento_ColumnHeaderMouseClick);
            // 
            // cdequipamentoDataGridViewTextBoxColumn
            // 
            this.cdequipamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdequipamentoDataGridViewTextBoxColumn.DataPropertyName = "Cd_equipamento";
            this.cdequipamentoDataGridViewTextBoxColumn.HeaderText = "Cd. Equipamento";
            this.cdequipamentoDataGridViewTextBoxColumn.Name = "cdequipamentoDataGridViewTextBoxColumn";
            this.cdequipamentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdequipamentoDataGridViewTextBoxColumn.Width = 104;
            // 
            // dsequipamentoDataGridViewTextBoxColumn
            // 
            this.dsequipamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsequipamentoDataGridViewTextBoxColumn.DataPropertyName = "Ds_equipamento";
            this.dsequipamentoDataGridViewTextBoxColumn.HeaderText = "Equipamento";
            this.dsequipamentoDataGridViewTextBoxColumn.Name = "dsequipamentoDataGridViewTextBoxColumn";
            this.dsequipamentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsequipamentoDataGridViewTextBoxColumn.Width = 94;
            // 
            // cdfazendaDataGridViewTextBoxColumn
            // 
            this.cdfazendaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdfazendaDataGridViewTextBoxColumn.DataPropertyName = "Cd_fazenda";
            this.cdfazendaDataGridViewTextBoxColumn.HeaderText = "Cd. Fazenda";
            this.cdfazendaDataGridViewTextBoxColumn.Name = "cdfazendaDataGridViewTextBoxColumn";
            this.cdfazendaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdfazendaDataGridViewTextBoxColumn.Width = 85;
            // 
            // nmfazendaDataGridViewTextBoxColumn
            // 
            this.nmfazendaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmfazendaDataGridViewTextBoxColumn.DataPropertyName = "Nm_fazenda";
            this.nmfazendaDataGridViewTextBoxColumn.HeaderText = "Fazenda";
            this.nmfazendaDataGridViewTextBoxColumn.Name = "nmfazendaDataGridViewTextBoxColumn";
            this.nmfazendaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmfazendaDataGridViewTextBoxColumn.Width = 73;
            // 
            // tipoequipamentoDataGridViewTextBoxColumn
            // 
            this.tipoequipamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipoequipamentoDataGridViewTextBoxColumn.DataPropertyName = "Tipo_equipamento";
            this.tipoequipamentoDataGridViewTextBoxColumn.HeaderText = "Tipo Equipamento";
            this.tipoequipamentoDataGridViewTextBoxColumn.Name = "tipoequipamentoDataGridViewTextBoxColumn";
            this.tipoequipamentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoequipamentoDataGridViewTextBoxColumn.Width = 108;
            // 
            // tipoconservacaoDataGridViewTextBoxColumn
            // 
            this.tipoconservacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipoconservacaoDataGridViewTextBoxColumn.DataPropertyName = "Tipo_conservacao";
            this.tipoconservacaoDataGridViewTextBoxColumn.HeaderText = "Estado Conservação";
            this.tipoconservacaoDataGridViewTextBoxColumn.Name = "tipoconservacaoDataGridViewTextBoxColumn";
            this.tipoconservacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoconservacaoDataGridViewTextBoxColumn.Width = 120;
            // 
            // dtaquisicaoDataGridViewTextBoxColumn
            // 
            this.dtaquisicaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtaquisicaoDataGridViewTextBoxColumn.DataPropertyName = "Dt_aquisicao";
            this.dtaquisicaoDataGridViewTextBoxColumn.HeaderText = "Dt. Aquisição";
            this.dtaquisicaoDataGridViewTextBoxColumn.Name = "dtaquisicaoDataGridViewTextBoxColumn";
            this.dtaquisicaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtaquisicaoDataGridViewTextBoxColumn.Width = 88;
            // 
            // vlequipamentoDataGridViewTextBoxColumn
            // 
            this.vlequipamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlequipamentoDataGridViewTextBoxColumn.DataPropertyName = "Vl_equipamento";
            this.vlequipamentoDataGridViewTextBoxColumn.HeaderText = "Vl. Equipamento";
            this.vlequipamentoDataGridViewTextBoxColumn.Name = "vlequipamentoDataGridViewTextBoxColumn";
            this.vlequipamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // placaDataGridViewTextBoxColumn
            // 
            this.placaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.placaDataGridViewTextBoxColumn.DataPropertyName = "Placa";
            this.placaDataGridViewTextBoxColumn.HeaderText = "Placa";
            this.placaDataGridViewTextBoxColumn.Name = "placaDataGridViewTextBoxColumn";
            this.placaDataGridViewTextBoxColumn.ReadOnly = true;
            this.placaDataGridViewTextBoxColumn.Width = 59;
            // 
            // anoFabricDataGridViewTextBoxColumn
            // 
            this.anoFabricDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.anoFabricDataGridViewTextBoxColumn.DataPropertyName = "AnoFabric";
            this.anoFabricDataGridViewTextBoxColumn.HeaderText = "Ano Fabricação";
            this.anoFabricDataGridViewTextBoxColumn.Name = "anoFabricDataGridViewTextBoxColumn";
            this.anoFabricDataGridViewTextBoxColumn.ReadOnly = true;
            this.anoFabricDataGridViewTextBoxColumn.Width = 98;
            // 
            // observacaoDataGridViewTextBoxColumn
            // 
            this.observacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.observacaoDataGridViewTextBoxColumn.DataPropertyName = "Observacao";
            this.observacaoDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.observacaoDataGridViewTextBoxColumn.Name = "observacaoDataGridViewTextBoxColumn";
            this.observacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.observacaoDataGridViewTextBoxColumn.Width = 90;
            // 
            // bsEquipamento
            // 
            this.bsEquipamento.DataSource = typeof(CamadaDados.Fazenda.Cadastros.TList_Equipamento);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsEquipamento;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 430);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(842, 25);
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
            // ds_equipamento
            // 
            this.ds_equipamento.BackColor = System.Drawing.SystemColors.Window;
            this.ds_equipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_equipamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEquipamento, "Ds_equipamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_equipamento.Enabled = false;
            this.ds_equipamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_equipamento.Location = new System.Drawing.Point(205, 3);
            this.ds_equipamento.Name = "ds_equipamento";
            this.ds_equipamento.NM_Alias = "";
            this.ds_equipamento.NM_Campo = "ds_produto";
            this.ds_equipamento.NM_CampoBusca = "ds_produto";
            this.ds_equipamento.NM_Param = "@P_NM_EMPRESA";
            this.ds_equipamento.QTD_Zero = 0;
            this.ds_equipamento.ReadOnly = true;
            this.ds_equipamento.Size = new System.Drawing.Size(482, 20);
            this.ds_equipamento.ST_AutoInc = false;
            this.ds_equipamento.ST_DisableAuto = false;
            this.ds_equipamento.ST_Float = false;
            this.ds_equipamento.ST_Gravar = false;
            this.ds_equipamento.ST_Int = false;
            this.ds_equipamento.ST_LimpaCampo = true;
            this.ds_equipamento.ST_NotNull = false;
            this.ds_equipamento.ST_PrimaryKey = false;
            this.ds_equipamento.TabIndex = 428;
            // 
            // bb_equipamento
            // 
            this.bb_equipamento.Enabled = false;
            this.bb_equipamento.Image = ((System.Drawing.Image)(resources.GetObject("bb_equipamento.Image")));
            this.bb_equipamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_equipamento.Location = new System.Drawing.Point(174, 3);
            this.bb_equipamento.Name = "bb_equipamento";
            this.bb_equipamento.Size = new System.Drawing.Size(28, 19);
            this.bb_equipamento.TabIndex = 1;
            this.bb_equipamento.UseVisualStyleBackColor = true;
            this.bb_equipamento.Click += new System.EventHandler(this.bb_equipamento_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(19, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 427;
            this.label2.Text = "Equipamento:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_equipamento
            // 
            this.cd_equipamento.BackColor = System.Drawing.SystemColors.Window;
            this.cd_equipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_equipamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEquipamento, "Cd_equipamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_equipamento.Enabled = false;
            this.cd_equipamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_equipamento.Location = new System.Drawing.Point(97, 3);
            this.cd_equipamento.Name = "cd_equipamento";
            this.cd_equipamento.NM_Alias = "";
            this.cd_equipamento.NM_Campo = "cd_produto";
            this.cd_equipamento.NM_CampoBusca = "cd_produto";
            this.cd_equipamento.NM_Param = "@P_CD_EMPRESA";
            this.cd_equipamento.QTD_Zero = 0;
            this.cd_equipamento.Size = new System.Drawing.Size(75, 20);
            this.cd_equipamento.ST_AutoInc = false;
            this.cd_equipamento.ST_DisableAuto = false;
            this.cd_equipamento.ST_Float = false;
            this.cd_equipamento.ST_Gravar = true;
            this.cd_equipamento.ST_Int = true;
            this.cd_equipamento.ST_LimpaCampo = true;
            this.cd_equipamento.ST_NotNull = true;
            this.cd_equipamento.ST_PrimaryKey = true;
            this.cd_equipamento.TabIndex = 0;
            this.cd_equipamento.Leave += new System.EventHandler(this.cd_equipamento_Leave);
            // 
            // nm_fazenda
            // 
            this.nm_fazenda.BackColor = System.Drawing.SystemColors.Window;
            this.nm_fazenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_fazenda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEquipamento, "Nm_fazenda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_fazenda.Enabled = false;
            this.nm_fazenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_fazenda.Location = new System.Drawing.Point(205, 29);
            this.nm_fazenda.Name = "nm_fazenda";
            this.nm_fazenda.NM_Alias = "";
            this.nm_fazenda.NM_Campo = "nm_fazenda";
            this.nm_fazenda.NM_CampoBusca = "nm_fazenda";
            this.nm_fazenda.NM_Param = "@P_NM_EMPRESA";
            this.nm_fazenda.QTD_Zero = 0;
            this.nm_fazenda.ReadOnly = true;
            this.nm_fazenda.Size = new System.Drawing.Size(482, 20);
            this.nm_fazenda.ST_AutoInc = false;
            this.nm_fazenda.ST_DisableAuto = false;
            this.nm_fazenda.ST_Float = false;
            this.nm_fazenda.ST_Gravar = false;
            this.nm_fazenda.ST_Int = false;
            this.nm_fazenda.ST_LimpaCampo = true;
            this.nm_fazenda.ST_NotNull = false;
            this.nm_fazenda.ST_PrimaryKey = false;
            this.nm_fazenda.TabIndex = 432;
            // 
            // bb_fazenda
            // 
            this.bb_fazenda.Enabled = false;
            this.bb_fazenda.Image = ((System.Drawing.Image)(resources.GetObject("bb_fazenda.Image")));
            this.bb_fazenda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_fazenda.Location = new System.Drawing.Point(174, 29);
            this.bb_fazenda.Name = "bb_fazenda";
            this.bb_fazenda.Size = new System.Drawing.Size(28, 19);
            this.bb_fazenda.TabIndex = 3;
            this.bb_fazenda.UseVisualStyleBackColor = true;
            this.bb_fazenda.Click += new System.EventHandler(this.bb_fazenda_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 431;
            this.label1.Text = "Fazenda:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_fazenda
            // 
            this.cd_fazenda.BackColor = System.Drawing.SystemColors.Window;
            this.cd_fazenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_fazenda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEquipamento, "Cd_fazenda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_fazenda.Enabled = false;
            this.cd_fazenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_fazenda.Location = new System.Drawing.Point(97, 29);
            this.cd_fazenda.Name = "cd_fazenda";
            this.cd_fazenda.NM_Alias = "";
            this.cd_fazenda.NM_Campo = "cd_fazenda";
            this.cd_fazenda.NM_CampoBusca = "cd_fazenda";
            this.cd_fazenda.NM_Param = "@P_CD_EMPRESA";
            this.cd_fazenda.QTD_Zero = 0;
            this.cd_fazenda.Size = new System.Drawing.Size(75, 20);
            this.cd_fazenda.ST_AutoInc = false;
            this.cd_fazenda.ST_DisableAuto = false;
            this.cd_fazenda.ST_Float = false;
            this.cd_fazenda.ST_Gravar = true;
            this.cd_fazenda.ST_Int = true;
            this.cd_fazenda.ST_LimpaCampo = true;
            this.cd_fazenda.ST_NotNull = true;
            this.cd_fazenda.ST_PrimaryKey = false;
            this.cd_fazenda.TabIndex = 2;
            this.cd_fazenda.Leave += new System.EventHandler(this.cd_fazenda_Leave);
            // 
            // tp_equipamento
            // 
            this.tp_equipamento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsEquipamento, "Tp_equipamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_equipamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_equipamento.Enabled = false;
            this.tp_equipamento.FormattingEnabled = true;
            this.tp_equipamento.Location = new System.Drawing.Point(97, 55);
            this.tp_equipamento.Name = "tp_equipamento";
            this.tp_equipamento.NM_Alias = "";
            this.tp_equipamento.NM_Campo = "";
            this.tp_equipamento.NM_Param = "";
            this.tp_equipamento.Size = new System.Drawing.Size(170, 21);
            this.tp_equipamento.ST_Gravar = true;
            this.tp_equipamento.ST_LimparCampo = true;
            this.tp_equipamento.ST_NotNull = true;
            this.tp_equipamento.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(60, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 434;
            this.label3.Text = "Tipo:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(273, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 436;
            this.label4.Text = "Estado Conservação:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_conservacao
            // 
            this.tp_conservacao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsEquipamento, "Tp_conservacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_conservacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_conservacao.Enabled = false;
            this.tp_conservacao.FormattingEnabled = true;
            this.tp_conservacao.Location = new System.Drawing.Point(388, 55);
            this.tp_conservacao.Name = "tp_conservacao";
            this.tp_conservacao.NM_Alias = "";
            this.tp_conservacao.NM_Campo = "";
            this.tp_conservacao.NM_Param = "";
            this.tp_conservacao.Size = new System.Drawing.Size(143, 21);
            this.tp_conservacao.ST_Gravar = true;
            this.tp_conservacao.ST_LimparCampo = true;
            this.tp_conservacao.ST_NotNull = false;
            this.tp_conservacao.TabIndex = 5;
            // 
            // dt_aquisicao
            // 
            this.dt_aquisicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEquipamento, "Dt_aquisicaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_aquisicao.Enabled = false;
            this.dt_aquisicao.Location = new System.Drawing.Point(616, 55);
            this.dt_aquisicao.Mask = "00/00/0000";
            this.dt_aquisicao.Name = "dt_aquisicao";
            this.dt_aquisicao.NM_Alias = "";
            this.dt_aquisicao.NM_Campo = "";
            this.dt_aquisicao.NM_CampoBusca = "";
            this.dt_aquisicao.NM_Param = "";
            this.dt_aquisicao.Operador = "";
            this.dt_aquisicao.Size = new System.Drawing.Size(71, 20);
            this.dt_aquisicao.ST_Gravar = true;
            this.dt_aquisicao.ST_LimpaCampo = true;
            this.dt_aquisicao.ST_NotNull = false;
            this.dt_aquisicao.ST_PrimaryKey = false;
            this.dt_aquisicao.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(537, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 438;
            this.label5.Text = "Dt. Aquisição:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(4, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 439;
            this.label6.Text = "Vl. Equipamento:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vl_equipamento
            // 
            this.vl_equipamento.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEquipamento, "Vl_equipamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_equipamento.DecimalPlaces = 2;
            this.vl_equipamento.Enabled = false;
            this.vl_equipamento.Location = new System.Drawing.Point(97, 82);
            this.vl_equipamento.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_equipamento.Name = "vl_equipamento";
            this.vl_equipamento.NM_Alias = "";
            this.vl_equipamento.NM_Campo = "";
            this.vl_equipamento.NM_Param = "";
            this.vl_equipamento.Operador = "";
            this.vl_equipamento.Size = new System.Drawing.Size(105, 20);
            this.vl_equipamento.ST_AutoInc = false;
            this.vl_equipamento.ST_DisableAuto = false;
            this.vl_equipamento.ST_Gravar = true;
            this.vl_equipamento.ST_LimparCampo = true;
            this.vl_equipamento.ST_NotNull = false;
            this.vl_equipamento.ST_PrimaryKey = false;
            this.vl_equipamento.TabIndex = 7;
            this.vl_equipamento.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(208, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 441;
            this.label7.Text = "Placa:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // placa
            // 
            this.placa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEquipamento, "Placa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.placa.Enabled = false;
            this.placa.Location = new System.Drawing.Point(251, 82);
            this.placa.Mask = "AAA-9999";
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "";
            this.placa.NM_CampoBusca = "";
            this.placa.NM_Param = "";
            this.placa.Size = new System.Drawing.Size(60, 20);
            this.placa.ST_Gravar = true;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = false;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(317, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 443;
            this.label8.Text = "Ano Fabricação:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // anofabric
            // 
            this.anofabric.BackColor = System.Drawing.SystemColors.Window;
            this.anofabric.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.anofabric.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEquipamento, "AnoFabric", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.anofabric.Location = new System.Drawing.Point(408, 82);
            this.anofabric.Name = "anofabric";
            this.anofabric.NM_Alias = "";
            this.anofabric.NM_Campo = "";
            this.anofabric.NM_CampoBusca = "";
            this.anofabric.NM_Param = "";
            this.anofabric.QTD_Zero = 0;
            this.anofabric.Size = new System.Drawing.Size(100, 20);
            this.anofabric.ST_AutoInc = false;
            this.anofabric.ST_DisableAuto = false;
            this.anofabric.ST_Float = false;
            this.anofabric.ST_Gravar = true;
            this.anofabric.ST_Int = true;
            this.anofabric.ST_LimpaCampo = true;
            this.anofabric.ST_NotNull = false;
            this.anofabric.ST_PrimaryKey = false;
            this.anofabric.TabIndex = 9;
            // 
            // observacao
            // 
            this.observacao.BackColor = System.Drawing.SystemColors.Window;
            this.observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEquipamento, "Observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.observacao.Location = new System.Drawing.Point(97, 108);
            this.observacao.Multiline = true;
            this.observacao.Name = "observacao";
            this.observacao.NM_Alias = "";
            this.observacao.NM_Campo = "";
            this.observacao.NM_CampoBusca = "";
            this.observacao.NM_Param = "";
            this.observacao.QTD_Zero = 0;
            this.observacao.Size = new System.Drawing.Size(590, 75);
            this.observacao.ST_AutoInc = false;
            this.observacao.ST_DisableAuto = false;
            this.observacao.ST_Float = false;
            this.observacao.ST_Gravar = true;
            this.observacao.ST_Int = false;
            this.observacao.ST_LimpaCampo = true;
            this.observacao.ST_NotNull = false;
            this.observacao.ST_PrimaryKey = false;
            this.observacao.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(23, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 446;
            this.label9.Text = "Observação:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vl_custohora
            // 
            this.vl_custohora.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEquipamento, "Vl_custohora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_custohora.DecimalPlaces = 5;
            this.vl_custohora.Enabled = false;
            this.vl_custohora.Location = new System.Drawing.Point(592, 82);
            this.vl_custohora.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_custohora.Name = "vl_custohora";
            this.vl_custohora.NM_Alias = "";
            this.vl_custohora.NM_Campo = "";
            this.vl_custohora.NM_Param = "";
            this.vl_custohora.Operador = "";
            this.vl_custohora.Size = new System.Drawing.Size(95, 20);
            this.vl_custohora.ST_AutoInc = false;
            this.vl_custohora.ST_DisableAuto = false;
            this.vl_custohora.ST_Gravar = true;
            this.vl_custohora.ST_LimparCampo = true;
            this.vl_custohora.ST_NotNull = false;
            this.vl_custohora.ST_PrimaryKey = false;
            this.vl_custohora.TabIndex = 10;
            this.vl_custohora.ThousandsSeparator = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(514, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 447;
            this.label10.Text = "Vl. Custo (Hr):";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFCad_Equipamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(854, 528);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCad_Equipamento";
            this.Text = "Cadastro de Maquinas/Implementos Agricolas";
            this.Load += new System.EventHandler(this.TFCad_Equipamento_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_Equipamento_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEquipamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEquipamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_equipamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_custohora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gEquipamento;
        private System.Windows.Forms.BindingSource bsEquipamento;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdequipamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsequipamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdfazendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmfazendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoequipamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoconservacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtaquisicaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlequipamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anoFabricDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacaoDataGridViewTextBoxColumn;
        private Componentes.EditData dt_aquisicao;
        private System.Windows.Forms.Label label4;
        private Componentes.ComboBoxDefault tp_conservacao;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault tp_equipamento;
        private Componentes.EditDefault nm_fazenda;
        private System.Windows.Forms.Button bb_fazenda;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_fazenda;
        private Componentes.EditDefault ds_equipamento;
        private System.Windows.Forms.Button bb_equipamento;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_equipamento;
        private Componentes.EditFloat vl_equipamento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault observacao;
        private Componentes.EditDefault anofabric;
        private System.Windows.Forms.Label label8;
        private Componentes.EditMask placa;
        private System.Windows.Forms.Label label7;
        private Componentes.EditFloat vl_custohora;
        private System.Windows.Forms.Label label10;
    }
}
