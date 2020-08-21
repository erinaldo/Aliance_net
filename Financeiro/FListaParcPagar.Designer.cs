namespace Financeiro
{
    partial class TFListaParcPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaParcPagar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label label13;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bsParcela = new System.Windows.Forms.BindingSource(this.components);
            this.gParcela = new Componentes.DataGridDefault(this.components);
            this.bnParcela = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.statusparcelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrlanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdparcelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrdoctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtemissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvenctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlparcelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlatualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.nr_lancto = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.NR_Docto = new Componentes.EditDefault(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.BB_Clifor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.rgData = new Componentes.RadioGroup(this.components);
            this.pFiltroData = new Componentes.PanelDados(this.components);
            this.DT_Final = new Componentes.EditData(this.components);
            this.DT_Inicial = new Componentes.EditData(this.components);
            this.RB_Emissao = new Componentes.RadioButtonDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RB_Vencimento = new Componentes.RadioButtonDefault(this.components);
            this.bb_buscar = new System.Windows.Forms.Button();
            label13 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsParcela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gParcela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnParcela)).BeginInit();
            this.bnParcela.SuspendLayout();
            this.rgData.SuspendLayout();
            this.pFiltroData.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(919, 43);
            this.barraMenu.TabIndex = 534;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(100, 40);
            this.BB_Gravar.Text = " (F4)\r\n Confirmar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(919, 459);
            this.tlpCentral.TabIndex = 535;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.bb_buscar);
            this.pFiltro.Controls.Add(this.rgData);
            this.pFiltro.Controls.Add(label13);
            this.pFiltro.Controls.Add(this.nr_lancto);
            this.pFiltro.Controls.Add(this.CD_Empresa);
            this.pFiltro.Controls.Add(this.label4);
            this.pFiltro.Controls.Add(this.BB_Empresa);
            this.pFiltro.Controls.Add(this.NR_Docto);
            this.pFiltro.Controls.Add(this.label11);
            this.pFiltro.Controls.Add(this.BB_Clifor);
            this.pFiltro.Controls.Add(this.label5);
            this.pFiltro.Controls.Add(this.CD_Clifor);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 3);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(913, 74);
            this.pFiltro.TabIndex = 0;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.cbTodos);
            this.panelDados1.Controls.Add(this.gParcela);
            this.panelDados1.Controls.Add(this.bnParcela);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 83);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(913, 373);
            this.panelDados1.TabIndex = 1;
            // 
            // bsParcela
            // 
            this.bsParcela.DataSource = typeof(CamadaDados.Financeiro.Duplicata.TList_RegLanParcela);
            // 
            // gParcela
            // 
            this.gParcela.AllowUserToAddRows = false;
            this.gParcela.AllowUserToDeleteRows = false;
            this.gParcela.AllowUserToOrderColumns = true;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gParcela.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.gParcela.AutoGenerateColumns = false;
            this.gParcela.BackgroundColor = System.Drawing.Color.LightGray;
            this.gParcela.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gParcela.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gParcela.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gParcela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gParcela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.statusparcelaDataGridViewTextBoxColumn,
            this.nrlanctoDataGridViewTextBoxColumn,
            this.cdparcelaDataGridViewTextBoxColumn,
            this.nrdoctoDataGridViewTextBoxColumn,
            this.dtemissaoDataGridViewTextBoxColumn,
            this.dtvenctoDataGridViewTextBoxColumn,
            this.vlparcelaDataGridViewTextBoxColumn,
            this.vlatualDataGridViewTextBoxColumn,
            this.siglaDataGridViewTextBoxColumn,
            this.cdcliforDataGridViewTextBoxColumn,
            this.nmcliforDataGridViewTextBoxColumn});
            this.gParcela.DataSource = this.bsParcela;
            this.gParcela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gParcela.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gParcela.Location = new System.Drawing.Point(0, 0);
            this.gParcela.Name = "gParcela";
            this.gParcela.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gParcela.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.gParcela.RowHeadersWidth = 23;
            this.gParcela.Size = new System.Drawing.Size(913, 348);
            this.gParcela.TabIndex = 7;
            this.gParcela.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gParcela_CellClick);
            // 
            // bnParcela
            // 
            this.bnParcela.AddNewItem = null;
            this.bnParcela.BindingSource = this.bsParcela;
            this.bnParcela.CountItem = this.bindingNavigatorCountItem;
            this.bnParcela.CountItemFormat = "de {0}";
            this.bnParcela.DeleteItem = null;
            this.bnParcela.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnParcela.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnParcela.Location = new System.Drawing.Point(0, 348);
            this.bnParcela.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnParcela.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnParcela.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnParcela.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnParcela.Name = "bnParcela";
            this.bnParcela.PositionItem = this.bindingNavigatorPositionItem;
            this.bnParcela.Size = new System.Drawing.Size(913, 25);
            this.bnParcela.TabIndex = 8;
            this.bnParcela.Text = "bindingNavigator1";
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
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Liquidar";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Width = 50;
            // 
            // statusparcelaDataGridViewTextBoxColumn
            // 
            this.statusparcelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.statusparcelaDataGridViewTextBoxColumn.DataPropertyName = "Status_parcela";
            this.statusparcelaDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusparcelaDataGridViewTextBoxColumn.Name = "statusparcelaDataGridViewTextBoxColumn";
            this.statusparcelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusparcelaDataGridViewTextBoxColumn.Width = 62;
            // 
            // nrlanctoDataGridViewTextBoxColumn
            // 
            this.nrlanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrlanctoDataGridViewTextBoxColumn.DataPropertyName = "Nr_lancto";
            this.nrlanctoDataGridViewTextBoxColumn.HeaderText = "Nº Duplicata";
            this.nrlanctoDataGridViewTextBoxColumn.Name = "nrlanctoDataGridViewTextBoxColumn";
            this.nrlanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrlanctoDataGridViewTextBoxColumn.Width = 92;
            // 
            // cdparcelaDataGridViewTextBoxColumn
            // 
            this.cdparcelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdparcelaDataGridViewTextBoxColumn.DataPropertyName = "Cd_parcela";
            this.cdparcelaDataGridViewTextBoxColumn.HeaderText = "Nº Parcela";
            this.cdparcelaDataGridViewTextBoxColumn.Name = "cdparcelaDataGridViewTextBoxColumn";
            this.cdparcelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdparcelaDataGridViewTextBoxColumn.Width = 83;
            // 
            // nrdoctoDataGridViewTextBoxColumn
            // 
            this.nrdoctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrdoctoDataGridViewTextBoxColumn.DataPropertyName = "Nr_docto";
            this.nrdoctoDataGridViewTextBoxColumn.HeaderText = "Nº Documento";
            this.nrdoctoDataGridViewTextBoxColumn.Name = "nrdoctoDataGridViewTextBoxColumn";
            this.nrdoctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrdoctoDataGridViewTextBoxColumn.Width = 102;
            // 
            // dtemissaoDataGridViewTextBoxColumn
            // 
            this.dtemissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaoDataGridViewTextBoxColumn.DataPropertyName = "Dt_emissao";
            this.dtemissaoDataGridViewTextBoxColumn.HeaderText = "Emissão";
            this.dtemissaoDataGridViewTextBoxColumn.Name = "dtemissaoDataGridViewTextBoxColumn";
            this.dtemissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtemissaoDataGridViewTextBoxColumn.Width = 71;
            // 
            // dtvenctoDataGridViewTextBoxColumn
            // 
            this.dtvenctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvenctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_vencto";
            this.dtvenctoDataGridViewTextBoxColumn.HeaderText = "Vencimento";
            this.dtvenctoDataGridViewTextBoxColumn.Name = "dtvenctoDataGridViewTextBoxColumn";
            this.dtvenctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtvenctoDataGridViewTextBoxColumn.Width = 88;
            // 
            // vlparcelaDataGridViewTextBoxColumn
            // 
            this.vlparcelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlparcelaDataGridViewTextBoxColumn.DataPropertyName = "Vl_parcela";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = "0";
            this.vlparcelaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.vlparcelaDataGridViewTextBoxColumn.HeaderText = "Vl. Nominal";
            this.vlparcelaDataGridViewTextBoxColumn.Name = "vlparcelaDataGridViewTextBoxColumn";
            this.vlparcelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlparcelaDataGridViewTextBoxColumn.Width = 85;
            // 
            // vlatualDataGridViewTextBoxColumn
            // 
            this.vlatualDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlatualDataGridViewTextBoxColumn.DataPropertyName = "Vl_atual";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = "0";
            this.vlatualDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.vlatualDataGridViewTextBoxColumn.HeaderText = "Vl. Atual";
            this.vlatualDataGridViewTextBoxColumn.Name = "vlatualDataGridViewTextBoxColumn";
            this.vlatualDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlatualDataGridViewTextBoxColumn.Width = 71;
            // 
            // siglaDataGridViewTextBoxColumn
            // 
            this.siglaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaDataGridViewTextBoxColumn.DataPropertyName = "Sigla";
            this.siglaDataGridViewTextBoxColumn.HeaderText = "$";
            this.siglaDataGridViewTextBoxColumn.Name = "siglaDataGridViewTextBoxColumn";
            this.siglaDataGridViewTextBoxColumn.ReadOnly = true;
            this.siglaDataGridViewTextBoxColumn.Width = 38;
            // 
            // cdcliforDataGridViewTextBoxColumn
            // 
            this.cdcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcliforDataGridViewTextBoxColumn.DataPropertyName = "Cd_clifor";
            this.cdcliforDataGridViewTextBoxColumn.HeaderText = "Cd. Fornecedor";
            this.cdcliforDataGridViewTextBoxColumn.Name = "cdcliforDataGridViewTextBoxColumn";
            this.cdcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcliforDataGridViewTextBoxColumn.Width = 97;
            // 
            // nmcliforDataGridViewTextBoxColumn
            // 
            this.nmcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor";
            this.nmcliforDataGridViewTextBoxColumn.HeaderText = "Fornecedor";
            this.nmcliforDataGridViewTextBoxColumn.Name = "nmcliforDataGridViewTextBoxColumn";
            this.nmcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcliforDataGridViewTextBoxColumn.Width = 86;
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
            this.cbTodos.TabIndex = 9;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            this.cbTodos.Click += new System.EventHandler(this.cbTodos_Click);
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label13.Location = new System.Drawing.Point(148, 32);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(58, 13);
            label13.TabIndex = 15;
            label13.Text = "Nº Lancto:";
            // 
            // nr_lancto
            // 
            this.nr_lancto.BackColor = System.Drawing.SystemColors.Window;
            this.nr_lancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_lancto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_lancto.Location = new System.Drawing.Point(212, 29);
            this.nr_lancto.Name = "nr_lancto";
            this.nr_lancto.NM_Alias = "";
            this.nr_lancto.NM_Campo = "nr_contrato";
            this.nr_lancto.NM_CampoBusca = "nr_contrato";
            this.nr_lancto.NM_Param = "@P_CD_HISTORICO";
            this.nr_lancto.QTD_Zero = 0;
            this.nr_lancto.Size = new System.Drawing.Size(79, 20);
            this.nr_lancto.ST_AutoInc = false;
            this.nr_lancto.ST_DisableAuto = false;
            this.nr_lancto.ST_Float = false;
            this.nr_lancto.ST_Gravar = true;
            this.nr_lancto.ST_Int = false;
            this.nr_lancto.ST_LimpaCampo = true;
            this.nr_lancto.ST_NotNull = false;
            this.nr_lancto.ST_PrimaryKey = false;
            this.nr_lancto.TabIndex = 16;
            this.nr_lancto.TextOld = null;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.Color.White;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(59, 3);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(45, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = false;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 11;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(8, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Empresa:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(106, 3);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(30, 20);
            this.BB_Empresa.TabIndex = 12;
            this.BB_Empresa.UseVisualStyleBackColor = false;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // NR_Docto
            // 
            this.NR_Docto.BackColor = System.Drawing.SystemColors.Window;
            this.NR_Docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NR_Docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NR_Docto.Location = new System.Drawing.Point(59, 29);
            this.NR_Docto.Name = "NR_Docto";
            this.NR_Docto.NM_Alias = "";
            this.NR_Docto.NM_Campo = "NR_Docto";
            this.NR_Docto.NM_CampoBusca = "NR_Docto";
            this.NR_Docto.NM_Param = "@P_NR_DOCTO";
            this.NR_Docto.QTD_Zero = 0;
            this.NR_Docto.Size = new System.Drawing.Size(77, 20);
            this.NR_Docto.ST_AutoInc = false;
            this.NR_Docto.ST_DisableAuto = false;
            this.NR_Docto.ST_Float = false;
            this.NR_Docto.ST_Gravar = false;
            this.NR_Docto.ST_Int = false;
            this.NR_Docto.ST_LimpaCampo = true;
            this.NR_Docto.ST_NotNull = false;
            this.NR_Docto.ST_PrimaryKey = false;
            this.NR_Docto.TabIndex = 14;
            this.NR_Docto.TextOld = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(2, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Nº Docto.:";
            // 
            // BB_Clifor
            // 
            this.BB_Clifor.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Clifor.Image = ((System.Drawing.Image)(resources.GetObject("BB_Clifor.Image")));
            this.BB_Clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Clifor.Location = new System.Drawing.Point(304, 4);
            this.BB_Clifor.Name = "BB_Clifor";
            this.BB_Clifor.Size = new System.Drawing.Size(30, 20);
            this.BB_Clifor.TabIndex = 19;
            this.BB_Clifor.UseVisualStyleBackColor = false;
            this.BB_Clifor.Click += new System.EventHandler(this.BB_Clifor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(142, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Fornecedor:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Clifor.Location = new System.Drawing.Point(212, 4);
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.Size = new System.Drawing.Size(88, 20);
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = true;
            this.CD_Clifor.ST_Int = false;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = false;
            this.CD_Clifor.ST_PrimaryKey = false;
            this.CD_Clifor.TabIndex = 18;
            this.CD_Clifor.TextOld = null;
            this.CD_Clifor.Leave += new System.EventHandler(this.CD_Clifor_Leave);
            // 
            // rgData
            // 
            this.rgData.BackColor = System.Drawing.SystemColors.Control;
            this.rgData.Controls.Add(this.pFiltroData);
            this.rgData.Location = new System.Drawing.Point(345, -1);
            this.rgData.Name = "rgData";
            this.rgData.NM_Alias = "";
            this.rgData.NM_Campo = "";
            this.rgData.NM_Param = "";
            this.rgData.NM_Valor = "E";
            this.rgData.Size = new System.Drawing.Size(221, 72);
            this.rgData.ST_Gravar = false;
            this.rgData.ST_NotNull = false;
            this.rgData.TabIndex = 34;
            this.rgData.TabStop = false;
            this.rgData.Text = "Data:";
            // 
            // pFiltroData
            // 
            this.pFiltroData.BackColor = System.Drawing.Color.Transparent;
            this.pFiltroData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltroData.Controls.Add(this.DT_Final);
            this.pFiltroData.Controls.Add(this.DT_Inicial);
            this.pFiltroData.Controls.Add(this.RB_Emissao);
            this.pFiltroData.Controls.Add(this.label2);
            this.pFiltroData.Controls.Add(this.label1);
            this.pFiltroData.Controls.Add(this.RB_Vencimento);
            this.pFiltroData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltroData.Location = new System.Drawing.Point(3, 16);
            this.pFiltroData.Name = "pFiltroData";
            this.pFiltroData.NM_ProcDeletar = "";
            this.pFiltroData.NM_ProcGravar = "";
            this.pFiltroData.Size = new System.Drawing.Size(215, 53);
            this.pFiltroData.TabIndex = 6;
            // 
            // DT_Final
            // 
            this.DT_Final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Final.Location = new System.Drawing.Point(139, 26);
            this.DT_Final.Mask = "00/00/0000";
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.NM_Alias = "";
            this.DT_Final.NM_Campo = "";
            this.DT_Final.NM_CampoBusca = "";
            this.DT_Final.NM_Param = "";
            this.DT_Final.Operador = "";
            this.DT_Final.Size = new System.Drawing.Size(71, 20);
            this.DT_Final.ST_Gravar = false;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = false;
            this.DT_Final.ST_PrimaryKey = false;
            this.DT_Final.TabIndex = 4;
            // 
            // DT_Inicial
            // 
            this.DT_Inicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Inicial.Location = new System.Drawing.Point(139, 1);
            this.DT_Inicial.Mask = "00/00/0000";
            this.DT_Inicial.Name = "DT_Inicial";
            this.DT_Inicial.NM_Alias = "";
            this.DT_Inicial.NM_Campo = "";
            this.DT_Inicial.NM_CampoBusca = "";
            this.DT_Inicial.NM_Param = "";
            this.DT_Inicial.Operador = "";
            this.DT_Inicial.Size = new System.Drawing.Size(71, 20);
            this.DT_Inicial.ST_Gravar = false;
            this.DT_Inicial.ST_LimpaCampo = true;
            this.DT_Inicial.ST_NotNull = false;
            this.DT_Inicial.ST_PrimaryKey = false;
            this.DT_Inicial.TabIndex = 3;
            // 
            // RB_Emissao
            // 
            this.RB_Emissao.AutoSize = true;
            this.RB_Emissao.Checked = true;
            this.RB_Emissao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RB_Emissao.Location = new System.Drawing.Point(4, 0);
            this.RB_Emissao.Name = "RB_Emissao";
            this.RB_Emissao.Size = new System.Drawing.Size(64, 17);
            this.RB_Emissao.TabIndex = 0;
            this.RB_Emissao.TabStop = true;
            this.RB_Emissao.Text = "Emissão";
            this.RB_Emissao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RB_Emissao.UseVisualStyleBackColor = true;
            this.RB_Emissao.Valor = "E";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(98, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dt. Ini.:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(90, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dt. Final:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RB_Vencimento
            // 
            this.RB_Vencimento.AutoSize = true;
            this.RB_Vencimento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RB_Vencimento.Location = new System.Drawing.Point(4, 27);
            this.RB_Vencimento.Name = "RB_Vencimento";
            this.RB_Vencimento.Size = new System.Drawing.Size(81, 17);
            this.RB_Vencimento.TabIndex = 1;
            this.RB_Vencimento.Text = "Vencimento";
            this.RB_Vencimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RB_Vencimento.UseVisualStyleBackColor = true;
            this.RB_Vencimento.Valor = "V";
            // 
            // bb_buscar
            // 
            this.bb_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_buscar.ForeColor = System.Drawing.Color.Green;
            this.bb_buscar.Image = ((System.Drawing.Image)(resources.GetObject("bb_buscar.Image")));
            this.bb_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_buscar.Location = new System.Drawing.Point(572, 15);
            this.bb_buscar.Name = "bb_buscar";
            this.bb_buscar.Size = new System.Drawing.Size(114, 53);
            this.bb_buscar.TabIndex = 35;
            this.bb_buscar.Text = "(F7) Buscar";
            this.bb_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_buscar.UseVisualStyleBackColor = true;
            this.bb_buscar.Click += new System.EventHandler(this.bb_buscar_Click);
            // 
            // TFListaParcPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 502);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaParcPagar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duplicatas a Pagar";
            this.Load += new System.EventHandler(this.TFListaParcPagar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaParcPagar_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsParcela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gParcela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnParcela)).EndInit();
            this.bnParcela.ResumeLayout(false);
            this.bnParcela.PerformLayout();
            this.rgData.ResumeLayout(false);
            this.pFiltroData.ResumeLayout(false);
            this.pFiltroData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingSource bsParcela;
        private Componentes.DataGridDefault gParcela;
        private System.Windows.Forms.BindingNavigator bnParcela;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusparcelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrlanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdparcelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrdoctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtemissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvenctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlparcelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlatualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforDataGridViewTextBoxColumn;
        private Componentes.CheckBoxDefault cbTodos;
        public Componentes.EditDefault nr_lancto;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault NR_Docto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BB_Clifor;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault CD_Clifor;
        private Componentes.RadioGroup rgData;
        private Componentes.PanelDados pFiltroData;
        private Componentes.EditData DT_Final;
        private Componentes.EditData DT_Inicial;
        private Componentes.RadioButtonDefault RB_Emissao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.RadioButtonDefault RB_Vencimento;
        private System.Windows.Forms.Button bb_buscar;
    }
}