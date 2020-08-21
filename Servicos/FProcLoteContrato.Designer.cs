namespace Servicos
{
    partial class TFProcLoteContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFProcLoteContrato));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dtPeriodo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pDados = new Componentes.PanelDados(this.components);
            this.gContrato = new Componentes.DataGridDefault(this.components);
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nrcontratostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_contrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcontratanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcontratanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdendcontratanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsendcontratanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdvendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmvendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrcontratorigemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtaberturastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtencerramentostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diavenctofaturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscontratoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsContrato = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pTotal = new Componentes.PanelDados(this.components);
            this.tot_faturar = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tot_contrato = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gContrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tot_faturar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_contrato)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(1018, 43);
            this.barraMenu.TabIndex = 11;
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
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Controls.Add(this.pTotal, 0, 2);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 3;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlpCentral.Size = new System.Drawing.Size(1018, 529);
            this.tlpCentral.TabIndex = 12;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.cbEmpresa);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.dtPeriodo);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(1008, 33);
            this.pFiltro.TabIndex = 0;
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(71, 5);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(721, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 153;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(798, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 152;
            this.label2.Text = "Dt. Referencia:";
            // 
            // dtPeriodo
            // 
            this.dtPeriodo.CustomFormat = "MMMM/yyyy";
            this.dtPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPeriodo.Location = new System.Drawing.Point(883, 5);
            this.dtPeriodo.Name = "dtPeriodo";
            this.dtPeriodo.ShowUpDown = true;
            this.dtPeriodo.Size = new System.Drawing.Size(115, 20);
            this.dtPeriodo.TabIndex = 151;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.cbTodos);
            this.pDados.Controls.Add(this.gContrato);
            this.pDados.Controls.Add(this.bindingNavigator1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 46);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(1008, 435);
            this.pDados.TabIndex = 1;
            // 
            // gContrato
            // 
            this.gContrato.AllowUserToAddRows = false;
            this.gContrato.AllowUserToDeleteRows = false;
            this.gContrato.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gContrato.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gContrato.AutoGenerateColumns = false;
            this.gContrato.BackgroundColor = System.Drawing.Color.LightGray;
            this.gContrato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gContrato.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gContrato.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gContrato.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.nrcontratostrDataGridViewTextBoxColumn,
            this.Vl_contrato,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.cdcontratanteDataGridViewTextBoxColumn,
            this.nmcontratanteDataGridViewTextBoxColumn,
            this.cdendcontratanteDataGridViewTextBoxColumn,
            this.dsendcontratanteDataGridViewTextBoxColumn,
            this.cdvendedorDataGridViewTextBoxColumn,
            this.nmvendedorDataGridViewTextBoxColumn,
            this.nrcontratorigemDataGridViewTextBoxColumn,
            this.dtaberturastrDataGridViewTextBoxColumn,
            this.dtencerramentostrDataGridViewTextBoxColumn,
            this.diavenctofaturaDataGridViewTextBoxColumn,
            this.dscontratoDataGridViewTextBoxColumn});
            this.gContrato.DataSource = this.bsContrato;
            this.gContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gContrato.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gContrato.Location = new System.Drawing.Point(0, 0);
            this.gContrato.Name = "gContrato";
            this.gContrato.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gContrato.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gContrato.RowHeadersWidth = 23;
            this.gContrato.Size = new System.Drawing.Size(1004, 406);
            this.gContrato.TabIndex = 0;
            this.gContrato.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gContrato_ColumnHeaderMouseClick);
            this.gContrato.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gContrato_CellClick);
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
            // nrcontratostrDataGridViewTextBoxColumn
            // 
            this.nrcontratostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrcontratostrDataGridViewTextBoxColumn.DataPropertyName = "Nr_contratostr";
            this.nrcontratostrDataGridViewTextBoxColumn.HeaderText = "Nº Contrato";
            this.nrcontratostrDataGridViewTextBoxColumn.Name = "nrcontratostrDataGridViewTextBoxColumn";
            this.nrcontratostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrcontratostrDataGridViewTextBoxColumn.Width = 87;
            // 
            // Vl_contrato
            // 
            this.Vl_contrato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_contrato.DataPropertyName = "Vl_contrato";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.Vl_contrato.DefaultCellStyle = dataGridViewCellStyle3;
            this.Vl_contrato.HeaderText = "Vl. Contrato";
            this.Vl_contrato.Name = "Vl_contrato";
            this.Vl_contrato.ReadOnly = true;
            this.Vl_contrato.Width = 87;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 92;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            this.nmempresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmempresaDataGridViewTextBoxColumn.Width = 73;
            // 
            // cdcontratanteDataGridViewTextBoxColumn
            // 
            this.cdcontratanteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcontratanteDataGridViewTextBoxColumn.DataPropertyName = "Cd_contratante";
            this.cdcontratanteDataGridViewTextBoxColumn.HeaderText = "Cd. Contratante";
            this.cdcontratanteDataGridViewTextBoxColumn.Name = "cdcontratanteDataGridViewTextBoxColumn";
            this.cdcontratanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcontratanteDataGridViewTextBoxColumn.Width = 97;
            // 
            // nmcontratanteDataGridViewTextBoxColumn
            // 
            this.nmcontratanteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcontratanteDataGridViewTextBoxColumn.DataPropertyName = "Nm_contratante";
            this.nmcontratanteDataGridViewTextBoxColumn.HeaderText = "Contratante";
            this.nmcontratanteDataGridViewTextBoxColumn.Name = "nmcontratanteDataGridViewTextBoxColumn";
            this.nmcontratanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcontratanteDataGridViewTextBoxColumn.Width = 87;
            // 
            // cdendcontratanteDataGridViewTextBoxColumn
            // 
            this.cdendcontratanteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdendcontratanteDataGridViewTextBoxColumn.DataPropertyName = "Cd_endcontratante";
            this.cdendcontratanteDataGridViewTextBoxColumn.HeaderText = "Cd. Endereço";
            this.cdendcontratanteDataGridViewTextBoxColumn.Name = "cdendcontratanteDataGridViewTextBoxColumn";
            this.cdendcontratanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdendcontratanteDataGridViewTextBoxColumn.Width = 89;
            // 
            // dsendcontratanteDataGridViewTextBoxColumn
            // 
            this.dsendcontratanteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsendcontratanteDataGridViewTextBoxColumn.DataPropertyName = "Ds_endcontratante";
            this.dsendcontratanteDataGridViewTextBoxColumn.HeaderText = "Endereço Contratante";
            this.dsendcontratanteDataGridViewTextBoxColumn.Name = "dsendcontratanteDataGridViewTextBoxColumn";
            this.dsendcontratanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsendcontratanteDataGridViewTextBoxColumn.Width = 124;
            // 
            // cdvendedorDataGridViewTextBoxColumn
            // 
            this.cdvendedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdvendedorDataGridViewTextBoxColumn.DataPropertyName = "Cd_vendedor";
            this.cdvendedorDataGridViewTextBoxColumn.HeaderText = "Cd. Vendedor";
            this.cdvendedorDataGridViewTextBoxColumn.Name = "cdvendedorDataGridViewTextBoxColumn";
            this.cdvendedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdvendedorDataGridViewTextBoxColumn.Width = 89;
            // 
            // nmvendedorDataGridViewTextBoxColumn
            // 
            this.nmvendedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmvendedorDataGridViewTextBoxColumn.DataPropertyName = "Nm_vendedor";
            this.nmvendedorDataGridViewTextBoxColumn.HeaderText = "Vendedor";
            this.nmvendedorDataGridViewTextBoxColumn.Name = "nmvendedorDataGridViewTextBoxColumn";
            this.nmvendedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmvendedorDataGridViewTextBoxColumn.Width = 78;
            // 
            // nrcontratorigemDataGridViewTextBoxColumn
            // 
            this.nrcontratorigemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrcontratorigemDataGridViewTextBoxColumn.DataPropertyName = "Nr_contratorigem";
            this.nrcontratorigemDataGridViewTextBoxColumn.HeaderText = "Contrato Origem";
            this.nrcontratorigemDataGridViewTextBoxColumn.Name = "nrcontratorigemDataGridViewTextBoxColumn";
            this.nrcontratorigemDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrcontratorigemDataGridViewTextBoxColumn.Width = 99;
            // 
            // dtaberturastrDataGridViewTextBoxColumn
            // 
            this.dtaberturastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtaberturastrDataGridViewTextBoxColumn.DataPropertyName = "Dt_aberturastr";
            this.dtaberturastrDataGridViewTextBoxColumn.HeaderText = "Dt. Abertura";
            this.dtaberturastrDataGridViewTextBoxColumn.Name = "dtaberturastrDataGridViewTextBoxColumn";
            this.dtaberturastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtaberturastrDataGridViewTextBoxColumn.Width = 82;
            // 
            // dtencerramentostrDataGridViewTextBoxColumn
            // 
            this.dtencerramentostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtencerramentostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_encerramentostr";
            this.dtencerramentostrDataGridViewTextBoxColumn.HeaderText = "Dt. Encerramento";
            this.dtencerramentostrDataGridViewTextBoxColumn.Name = "dtencerramentostrDataGridViewTextBoxColumn";
            this.dtencerramentostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtencerramentostrDataGridViewTextBoxColumn.Width = 106;
            // 
            // diavenctofaturaDataGridViewTextBoxColumn
            // 
            this.diavenctofaturaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.diavenctofaturaDataGridViewTextBoxColumn.DataPropertyName = "Diavenctofatura";
            this.diavenctofaturaDataGridViewTextBoxColumn.HeaderText = "Vencimento Fatura";
            this.diavenctofaturaDataGridViewTextBoxColumn.Name = "diavenctofaturaDataGridViewTextBoxColumn";
            this.diavenctofaturaDataGridViewTextBoxColumn.ReadOnly = true;
            this.diavenctofaturaDataGridViewTextBoxColumn.Width = 111;
            // 
            // dscontratoDataGridViewTextBoxColumn
            // 
            this.dscontratoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscontratoDataGridViewTextBoxColumn.DataPropertyName = "Ds_contrato";
            this.dscontratoDataGridViewTextBoxColumn.HeaderText = "Descrição Contrato";
            this.dscontratoDataGridViewTextBoxColumn.Name = "dscontratoDataGridViewTextBoxColumn";
            this.dscontratoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscontratoDataGridViewTextBoxColumn.Width = 113;
            // 
            // bsContrato
            // 
            this.bsContrato.DataSource = typeof(CamadaDados.Servicos.TList_Contrato);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsContrato;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 406);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1004, 25);
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
            // pTotal
            // 
            this.pTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTotal.Controls.Add(this.tot_faturar);
            this.pTotal.Controls.Add(this.label4);
            this.pTotal.Controls.Add(this.tot_contrato);
            this.pTotal.Controls.Add(this.label3);
            this.pTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTotal.Location = new System.Drawing.Point(5, 489);
            this.pTotal.Name = "pTotal";
            this.pTotal.NM_ProcDeletar = "";
            this.pTotal.NM_ProcGravar = "";
            this.pTotal.Size = new System.Drawing.Size(1008, 35);
            this.pTotal.TabIndex = 2;
            // 
            // tot_faturar
            // 
            this.tot_faturar.DecimalPlaces = 2;
            this.tot_faturar.Enabled = false;
            this.tot_faturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_faturar.Location = new System.Drawing.Point(334, 3);
            this.tot_faturar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tot_faturar.Name = "tot_faturar";
            this.tot_faturar.NM_Alias = "";
            this.tot_faturar.NM_Campo = "";
            this.tot_faturar.NM_Param = "";
            this.tot_faturar.Operador = "";
            this.tot_faturar.Size = new System.Drawing.Size(128, 26);
            this.tot_faturar.ST_AutoInc = false;
            this.tot_faturar.ST_DisableAuto = false;
            this.tot_faturar.ST_Gravar = false;
            this.tot_faturar.ST_LimparCampo = true;
            this.tot_faturar.ST_NotNull = false;
            this.tot_faturar.ST_PrimaryKey = false;
            this.tot_faturar.TabIndex = 35;
            this.tot_faturar.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(244, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Total Faturar:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tot_contrato
            // 
            this.tot_contrato.DecimalPlaces = 2;
            this.tot_contrato.Enabled = false;
            this.tot_contrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_contrato.Location = new System.Drawing.Point(110, 3);
            this.tot_contrato.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tot_contrato.Name = "tot_contrato";
            this.tot_contrato.NM_Alias = "";
            this.tot_contrato.NM_Campo = "";
            this.tot_contrato.NM_Param = "";
            this.tot_contrato.Operador = "";
            this.tot_contrato.Size = new System.Drawing.Size(128, 26);
            this.tot_contrato.ST_AutoInc = false;
            this.tot_contrato.ST_DisableAuto = false;
            this.tot_contrato.ST_Gravar = false;
            this.tot_contrato.ST_LimparCampo = true;
            this.tot_contrato.ST_NotNull = false;
            this.tot_contrato.ST_PrimaryKey = false;
            this.tot_contrato.TabIndex = 33;
            this.tot_contrato.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Total Contratos:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTodos
            // 
            this.cbTodos.AutoSize = true;
            this.cbTodos.Location = new System.Drawing.Point(7, 12);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.NM_Alias = "";
            this.cbTodos.NM_Campo = "";
            this.cbTodos.NM_Param = "";
            this.cbTodos.Size = new System.Drawing.Size(15, 14);
            this.cbTodos.ST_Gravar = false;
            this.cbTodos.ST_LimparCampo = true;
            this.cbTodos.ST_NotNull = false;
            this.cbTodos.TabIndex = 17;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            this.cbTodos.Click += new System.EventHandler(this.cbTodos_Click);
            // 
            // TFProcLoteContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 572);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFProcLoteContrato";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faturar Contratos em Lote";
            this.Load += new System.EventHandler(this.TFProcLoteContrato_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFProcLoteContrato_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFProcLoteContrato_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gContrato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContrato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pTotal.ResumeLayout(false);
            this.pTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tot_faturar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_contrato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.Label label1;
        private Componentes.DataGridDefault gContrato;
        private System.Windows.Forms.BindingSource bsContrato;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcontratostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_contrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcontratanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcontratanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdendcontratanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsendcontratanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcontratorigemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtaberturastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtencerramentostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diavenctofaturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscontratoDataGridViewTextBoxColumn;
        private Componentes.PanelDados pDados;
        private Componentes.PanelDados pTotal;
        private Componentes.EditFloat tot_faturar;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat tot_contrato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPeriodo;
        private Componentes.ComboBoxDefault cbEmpresa;
        private Componentes.CheckBoxDefault cbTodos;
    }
}