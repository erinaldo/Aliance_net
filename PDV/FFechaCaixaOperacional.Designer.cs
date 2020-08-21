namespace PDV
{
    partial class TFFechaCaixaOperacional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFFechaCaixaOperacional));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.gPortador = new Componentes.DataGridDefault(this.components);
            this.cdportadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlpagtoPDVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsportadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPortador = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_avancar = new System.Windows.Forms.Button();
            this.bb_voltar = new System.Windows.Forms.Button();
            this.vl_fechamento = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ds_portador = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPortador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPortador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_fechamento)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(701, 43);
            this.barraMenu.TabIndex = 10;
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
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 2;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 254F));
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 1, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(701, 400);
            this.tlpCentral.TabIndex = 12;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.gPortador);
            this.pDados.Controls.Add(this.bindingNavigator1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 5);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(435, 390);
            this.pDados.TabIndex = 11;
            // 
            // gPortador
            // 
            this.gPortador.AllowUserToAddRows = false;
            this.gPortador.AllowUserToDeleteRows = false;
            this.gPortador.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPortador.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gPortador.AutoGenerateColumns = false;
            this.gPortador.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPortador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPortador.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPortador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gPortador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPortador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdportadorDataGridViewTextBoxColumn,
            this.vlpagtoPDVDataGridViewTextBoxColumn,
            this.dsportadorDataGridViewTextBoxColumn});
            this.gPortador.DataSource = this.bsPortador;
            this.gPortador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gPortador.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPortador.Location = new System.Drawing.Point(0, 0);
            this.gPortador.MultiSelect = false;
            this.gPortador.Name = "gPortador";
            this.gPortador.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPortador.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gPortador.RowHeadersWidth = 23;
            this.gPortador.Size = new System.Drawing.Size(431, 361);
            this.gPortador.TabIndex = 0;
            this.gPortador.TabStop = false;
            this.gPortador.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gPortador_ColumnHeaderMouseClick);
            // 
            // cdportadorDataGridViewTextBoxColumn
            // 
            this.cdportadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdportadorDataGridViewTextBoxColumn.DataPropertyName = "Cd_portador";
            this.cdportadorDataGridViewTextBoxColumn.HeaderText = "Cd. Portador";
            this.cdportadorDataGridViewTextBoxColumn.Name = "cdportadorDataGridViewTextBoxColumn";
            this.cdportadorDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdportadorDataGridViewTextBoxColumn.Width = 91;
            // 
            // vlpagtoPDVDataGridViewTextBoxColumn
            // 
            this.vlpagtoPDVDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlpagtoPDVDataGridViewTextBoxColumn.DataPropertyName = "Vl_pagtoPDV";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.vlpagtoPDVDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.vlpagtoPDVDataGridViewTextBoxColumn.HeaderText = "Vl. Fechamento";
            this.vlpagtoPDVDataGridViewTextBoxColumn.Name = "vlpagtoPDVDataGridViewTextBoxColumn";
            this.vlpagtoPDVDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlpagtoPDVDataGridViewTextBoxColumn.Width = 97;
            // 
            // dsportadorDataGridViewTextBoxColumn
            // 
            this.dsportadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsportadorDataGridViewTextBoxColumn.DataPropertyName = "Ds_portador";
            this.dsportadorDataGridViewTextBoxColumn.HeaderText = "Portador";
            this.dsportadorDataGridViewTextBoxColumn.Name = "dsportadorDataGridViewTextBoxColumn";
            this.dsportadorDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsportadorDataGridViewTextBoxColumn.Width = 72;
            // 
            // bsPortador
            // 
            this.bsPortador.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadPortador);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsPortador;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 361);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(431, 25);
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
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.bb_avancar);
            this.panelDados1.Controls.Add(this.bb_voltar);
            this.panelDados1.Controls.Add(this.vl_fechamento);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.ds_portador);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(448, 5);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(248, 390);
            this.panelDados1.TabIndex = 12;
            // 
            // bb_avancar
            // 
            this.bb_avancar.Location = new System.Drawing.Point(128, 128);
            this.bb_avancar.Name = "bb_avancar";
            this.bb_avancar.Size = new System.Drawing.Size(88, 23);
            this.bb_avancar.TabIndex = 1;
            this.bb_avancar.Text = "AVANÇAR>>";
            this.bb_avancar.UseVisualStyleBackColor = true;
            this.bb_avancar.Click += new System.EventHandler(this.bb_avancar_Click);
            // 
            // bb_voltar
            // 
            this.bb_voltar.Location = new System.Drawing.Point(26, 128);
            this.bb_voltar.Name = "bb_voltar";
            this.bb_voltar.Size = new System.Drawing.Size(88, 23);
            this.bb_voltar.TabIndex = 2;
            this.bb_voltar.Text = "<<VOLTAR";
            this.bb_voltar.UseVisualStyleBackColor = true;
            this.bb_voltar.Click += new System.EventHandler(this.bb_voltar_Click);
            // 
            // vl_fechamento
            // 
            this.vl_fechamento.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPortador, "Vl_pagtoPDV", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_fechamento.DecimalPlaces = 2;
            this.vl_fechamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_fechamento.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_fechamento.Location = new System.Drawing.Point(6, 93);
            this.vl_fechamento.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_fechamento.Name = "vl_fechamento";
            this.vl_fechamento.NM_Alias = "";
            this.vl_fechamento.NM_Campo = "";
            this.vl_fechamento.NM_Param = "";
            this.vl_fechamento.Operador = "";
            this.vl_fechamento.Size = new System.Drawing.Size(230, 29);
            this.vl_fechamento.ST_AutoInc = false;
            this.vl_fechamento.ST_DisableAuto = false;
            this.vl_fechamento.ST_Gravar = false;
            this.vl_fechamento.ST_LimparCampo = true;
            this.vl_fechamento.ST_NotNull = false;
            this.vl_fechamento.ST_PrimaryKey = false;
            this.vl_fechamento.TabIndex = 0;
            this.vl_fechamento.ThousandsSeparator = true;
            this.vl_fechamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vl_fechamento_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor Fechamento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Portador";
            // 
            // ds_portador
            // 
            this.ds_portador.BackColor = System.Drawing.SystemColors.Window;
            this.ds_portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPortador, "Ds_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_portador.Enabled = false;
            this.ds_portador.Location = new System.Drawing.Point(3, 43);
            this.ds_portador.Name = "ds_portador";
            this.ds_portador.NM_Alias = "";
            this.ds_portador.NM_Campo = "";
            this.ds_portador.NM_CampoBusca = "";
            this.ds_portador.NM_Param = "";
            this.ds_portador.QTD_Zero = 0;
            this.ds_portador.Size = new System.Drawing.Size(233, 20);
            this.ds_portador.ST_AutoInc = false;
            this.ds_portador.ST_DisableAuto = false;
            this.ds_portador.ST_Float = false;
            this.ds_portador.ST_Gravar = false;
            this.ds_portador.ST_Int = false;
            this.ds_portador.ST_LimpaCampo = true;
            this.ds_portador.ST_NotNull = false;
            this.ds_portador.ST_PrimaryKey = false;
            this.ds_portador.TabIndex = 0;
            this.ds_portador.TextOld = null;
            // 
            // TFFechaCaixaOperacional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 443);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFFechaCaixaOperacional";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fechar Caixa Operacional";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFFechaCaixaOperacional_FormClosing);
            this.Load += new System.EventHandler(this.TFFechaCaixaOperacional_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFFechaCaixaOperacional_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPortador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPortador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_fechamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.DataGridDefault gPortador;
        private System.Windows.Forms.BindingSource bsPortador;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_portador;
        private System.Windows.Forms.Button bb_avancar;
        private System.Windows.Forms.Button bb_voltar;
        private Componentes.EditFloat vl_fechamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdportadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlpagtoPDVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsportadorDataGridViewTextBoxColumn;
    }
}