namespace Frota
{
    partial class TFListaViagemMot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaViagemMot));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.Placa = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DsViagem = new Componentes.EditDefault(this.components);
            this.dt_fin = new Componentes.EditData(this.components);
            this.dt_ini = new Componentes.EditData(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IdViagem = new Componentes.EditDefault(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.checkBoxDefault1 = new Componentes.CheckBoxDefault(this.components);
            this.gViagem = new Componentes.DataGridDefault(this.components);
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id_viagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsviagemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsveiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmmotoristaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtviagemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kMinicialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsViagem = new System.Windows.Forms.BindingSource(this.components);
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gViagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsViagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar,
            this.BB_Buscar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(977, 43);
            this.barraMenu.TabIndex = 19;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // BB_Buscar
            // 
            this.BB_Buscar.AutoSize = false;
            this.BB_Buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BB_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Buscar.Image")));
            this.BB_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Size = new System.Drawing.Size(80, 40);
            this.BB_Buscar.Text = "(F7)\r\nBuscar";
            this.BB_Buscar.ToolTipText = "Localizar Registros";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.tableLayoutPanel1);
            this.pDados.Controls.Add(this.bindingNavigator1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(977, 444);
            this.pDados.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(973, 409);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.Placa);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.DsViagem);
            this.panelDados1.Controls.Add(this.dt_fin);
            this.panelDados1.Controls.Add(this.dt_ini);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Controls.Add(this.label6);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.IdViagem);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(967, 34);
            this.panelDados1.TabIndex = 0;
            // 
            // Placa
            // 
            this.Placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Placa.Location = new System.Drawing.Point(656, 7);
            this.Placa.Mask = "AAA-AAAA";
            this.Placa.Name = "Placa";
            this.Placa.NM_Alias = "";
            this.Placa.NM_Campo = "";
            this.Placa.NM_CampoBusca = "";
            this.Placa.NM_Param = "";
            this.Placa.Operador = "";
            this.Placa.Size = new System.Drawing.Size(67, 20);
            this.Placa.ST_Gravar = false;
            this.Placa.ST_LimpaCampo = true;
            this.Placa.ST_NotNull = false;
            this.Placa.ST_PrimaryKey = false;
            this.Placa.TabIndex = 97;
            this.Placa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Placa_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(613, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Placa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "Viagem:";
            // 
            // DsViagem
            // 
            this.DsViagem.BackColor = System.Drawing.Color.White;
            this.DsViagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DsViagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DsViagem.Location = new System.Drawing.Point(204, 8);
            this.DsViagem.Name = "DsViagem";
            this.DsViagem.NM_Alias = "";
            this.DsViagem.NM_Campo = "";
            this.DsViagem.NM_CampoBusca = "";
            this.DsViagem.NM_Param = "";
            this.DsViagem.QTD_Zero = 0;
            this.DsViagem.Size = new System.Drawing.Size(354, 20);
            this.DsViagem.ST_AutoInc = false;
            this.DsViagem.ST_DisableAuto = false;
            this.DsViagem.ST_Float = false;
            this.DsViagem.ST_Gravar = false;
            this.DsViagem.ST_Int = false;
            this.DsViagem.ST_LimpaCampo = true;
            this.DsViagem.ST_NotNull = false;
            this.DsViagem.ST_PrimaryKey = false;
            this.DsViagem.TabIndex = 93;
            this.DsViagem.TextOld = null;
            // 
            // dt_fin
            // 
            this.dt_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin.Location = new System.Drawing.Point(893, 8);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Operador = "";
            this.dt_fin.Size = new System.Drawing.Size(67, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 92;
            // 
            // dt_ini
            // 
            this.dt_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini.Location = new System.Drawing.Point(773, 8);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Operador = "";
            this.dt_ini.Size = new System.Drawing.Size(67, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 91;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(846, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 90;
            this.label7.Text = "Dt. Fin:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(729, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "Dt. Ini:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Id.Viagem:";
            // 
            // IdViagem
            // 
            this.IdViagem.BackColor = System.Drawing.Color.White;
            this.IdViagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IdViagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.IdViagem.Location = new System.Drawing.Point(63, 8);
            this.IdViagem.Name = "IdViagem";
            this.IdViagem.NM_Alias = "";
            this.IdViagem.NM_Campo = "";
            this.IdViagem.NM_CampoBusca = "";
            this.IdViagem.NM_Param = "";
            this.IdViagem.QTD_Zero = 0;
            this.IdViagem.Size = new System.Drawing.Size(84, 20);
            this.IdViagem.ST_AutoInc = false;
            this.IdViagem.ST_DisableAuto = false;
            this.IdViagem.ST_Float = false;
            this.IdViagem.ST_Gravar = false;
            this.IdViagem.ST_Int = false;
            this.IdViagem.ST_LimpaCampo = true;
            this.IdViagem.ST_NotNull = false;
            this.IdViagem.ST_PrimaryKey = false;
            this.IdViagem.TabIndex = 87;
            this.IdViagem.TextOld = null;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.checkBoxDefault1);
            this.panelDados2.Controls.Add(this.gViagem);
            this.panelDados2.Controls.Add(this.cbTodos);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 43);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(967, 363);
            this.panelDados2.TabIndex = 1;
            // 
            // checkBoxDefault1
            // 
            this.checkBoxDefault1.Location = new System.Drawing.Point(6, 5);
            this.checkBoxDefault1.Name = "checkBoxDefault1";
            this.checkBoxDefault1.NM_Alias = "";
            this.checkBoxDefault1.NM_Campo = "";
            this.checkBoxDefault1.NM_Param = "";
            this.checkBoxDefault1.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDefault1.ST_Gravar = false;
            this.checkBoxDefault1.ST_LimparCampo = true;
            this.checkBoxDefault1.ST_NotNull = false;
            this.checkBoxDefault1.TabIndex = 13;
            this.checkBoxDefault1.UseVisualStyleBackColor = true;
            this.checkBoxDefault1.Vl_False = "";
            this.checkBoxDefault1.Vl_True = "";
            // 
            // gViagem
            // 
            this.gViagem.AllowUserToAddRows = false;
            this.gViagem.AllowUserToDeleteRows = false;
            this.gViagem.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gViagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gViagem.AutoGenerateColumns = false;
            this.gViagem.BackgroundColor = System.Drawing.Color.LightGray;
            this.gViagem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gViagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gViagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gViagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gViagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.Id_viagem,
            this.dsviagemDataGridViewTextBoxColumn,
            this.dsveiculoDataGridViewTextBoxColumn,
            this.placaDataGridViewTextBoxColumn,
            this.nmmotoristaDataGridViewTextBoxColumn,
            this.dtviagemDataGridViewTextBoxColumn,
            this.kMinicialDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn});
            this.gViagem.DataSource = this.bsViagem;
            this.gViagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gViagem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gViagem.Location = new System.Drawing.Point(0, 0);
            this.gViagem.MultiSelect = false;
            this.gViagem.Name = "gViagem";
            this.gViagem.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gViagem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gViagem.RowHeadersWidth = 23;
            this.gViagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gViagem.Size = new System.Drawing.Size(967, 363);
            this.gViagem.TabIndex = 0;
            this.gViagem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gViagem_CellClick);
            this.gViagem.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gViagem_ColumnHeaderMouseClick);
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Processar";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Width = 60;
            // 
            // Id_viagem
            // 
            this.Id_viagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Id_viagem.DataPropertyName = "Id_viagem";
            this.Id_viagem.HeaderText = "Id. Viagem";
            this.Id_viagem.Name = "Id_viagem";
            this.Id_viagem.ReadOnly = true;
            this.Id_viagem.Width = 82;
            // 
            // dsviagemDataGridViewTextBoxColumn
            // 
            this.dsviagemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsviagemDataGridViewTextBoxColumn.DataPropertyName = "Ds_viagem";
            this.dsviagemDataGridViewTextBoxColumn.HeaderText = "Viagem";
            this.dsviagemDataGridViewTextBoxColumn.Name = "dsviagemDataGridViewTextBoxColumn";
            this.dsviagemDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsviagemDataGridViewTextBoxColumn.Width = 67;
            // 
            // dsveiculoDataGridViewTextBoxColumn
            // 
            this.dsveiculoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsveiculoDataGridViewTextBoxColumn.DataPropertyName = "Ds_veiculo";
            this.dsveiculoDataGridViewTextBoxColumn.HeaderText = "Veiculo";
            this.dsveiculoDataGridViewTextBoxColumn.Name = "dsveiculoDataGridViewTextBoxColumn";
            this.dsveiculoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsveiculoDataGridViewTextBoxColumn.Width = 67;
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
            // nmmotoristaDataGridViewTextBoxColumn
            // 
            this.nmmotoristaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmmotoristaDataGridViewTextBoxColumn.DataPropertyName = "Nm_motorista";
            this.nmmotoristaDataGridViewTextBoxColumn.HeaderText = "Motorista";
            this.nmmotoristaDataGridViewTextBoxColumn.Name = "nmmotoristaDataGridViewTextBoxColumn";
            this.nmmotoristaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmmotoristaDataGridViewTextBoxColumn.Width = 75;
            // 
            // dtviagemDataGridViewTextBoxColumn
            // 
            this.dtviagemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtviagemDataGridViewTextBoxColumn.DataPropertyName = "Dt_viagem";
            this.dtviagemDataGridViewTextBoxColumn.HeaderText = "Dt. Viagem";
            this.dtviagemDataGridViewTextBoxColumn.Name = "dtviagemDataGridViewTextBoxColumn";
            this.dtviagemDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtviagemDataGridViewTextBoxColumn.Width = 84;
            // 
            // kMinicialDataGridViewTextBoxColumn
            // 
            this.kMinicialDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.kMinicialDataGridViewTextBoxColumn.DataPropertyName = "KM_inicial";
            this.kMinicialDataGridViewTextBoxColumn.HeaderText = "KM Inicial";
            this.kMinicialDataGridViewTextBoxColumn.Name = "kMinicialDataGridViewTextBoxColumn";
            this.kMinicialDataGridViewTextBoxColumn.ReadOnly = true;
            this.kMinicialDataGridViewTextBoxColumn.Width = 78;
            // 
            // dsobservacaoDataGridViewTextBoxColumn
            // 
            this.dsobservacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_observacao";
            this.dsobservacaoDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.dsobservacaoDataGridViewTextBoxColumn.Name = "dsobservacaoDataGridViewTextBoxColumn";
            this.dsobservacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsobservacaoDataGridViewTextBoxColumn.Width = 90;
            // 
            // bsViagem
            // 
            this.bsViagem.DataSource = typeof(CamadaDados.Frota.TList_Viagem);
            // 
            // cbTodos
            // 
            this.cbTodos.Location = new System.Drawing.Point(29, 15);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.NM_Alias = "";
            this.cbTodos.NM_Campo = "";
            this.cbTodos.NM_Param = "";
            this.cbTodos.Size = new System.Drawing.Size(15, 14);
            this.cbTodos.ST_Gravar = false;
            this.cbTodos.ST_LimparCampo = true;
            this.cbTodos.ST_NotNull = false;
            this.cbTodos.TabIndex = 12;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsViagem;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 415);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(973, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
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
            // TFListaViagemMot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 487);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaViagemMot";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viagem Motorista";
            this.Load += new System.EventHandler(this.TFListaViagemMot_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaViagemMot_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gViagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsViagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsViagem;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.CheckBoxDefault cbTodos;
        private Componentes.DataGridDefault gViagem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private Componentes.PanelDados panelDados2;
        private Componentes.CheckBoxDefault checkBoxDefault1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault IdViagem;
        private Componentes.EditData dt_fin;
        private Componentes.EditData dt_ini;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault DsViagem;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private Componentes.EditData Placa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_viagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsviagemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsveiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmmotoristaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtviagemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kMinicialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn;
    }
}