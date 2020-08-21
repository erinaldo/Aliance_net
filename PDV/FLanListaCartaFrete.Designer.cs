namespace PDV
{
    partial class TFLanListaCartaFrete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanListaCartaFrete));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsCartaFrete = new System.Windows.Forms.BindingSource(this.components);
            this.nrcartafreteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtemissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtentradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvencimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vldocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmtransportadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsenderecotranspDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmmotoristaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placaveiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrfrotaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kilometragemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmunidpagadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsendunidpagadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pTotais = new Componentes.PanelDados(this.components);
            this.vl_saldo = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vl_totcartafrete = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.vl_totalliquidar = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartaFrete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pTotais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totcartafrete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totalliquidar)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Gravar,
            this.BB_Excluir,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(813, 43);
            this.barraMenu.TabIndex = 535;
            // 
            // BB_Novo
            // 
            this.BB_Novo.AutoSize = false;
            this.BB_Novo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BB_Novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Novo.Image")));
            this.BB_Novo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Novo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BB_Novo.Size = new System.Drawing.Size(75, 40);
            this.BB_Novo.Text = "(F2)\r\nNovo";
            this.BB_Novo.ToolTipText = "Novo Registro";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(105, 40);
            this.BB_Gravar.Text = " (F4)\r\n Confirmar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(80, 40);
            this.BB_Excluir.Text = "(F5)\r\nExcluir";
            this.BB_Excluir.ToolTipText = "Excluir Registro";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pGrid, 0, 0);
            this.tlpCentral.Controls.Add(this.pTotais, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpCentral.Size = new System.Drawing.Size(813, 471);
            this.tlpCentral.TabIndex = 536;
            // 
            // pGrid
            // 
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pGrid.Controls.Add(this.dataGridDefault1);
            this.pGrid.Controls.Add(this.bindingNavigator1);
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid.Location = new System.Drawing.Point(4, 4);
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            this.pGrid.Size = new System.Drawing.Size(805, 419);
            this.pGrid.TabIndex = 0;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nrcartafreteDataGridViewTextBoxColumn,
            this.dtemissaoDataGridViewTextBoxColumn,
            this.dtentradaDataGridViewTextBoxColumn,
            this.dtvencimentoDataGridViewTextBoxColumn,
            this.vldocumentoDataGridViewTextBoxColumn,
            this.nmtransportadoraDataGridViewTextBoxColumn,
            this.dsenderecotranspDataGridViewTextBoxColumn,
            this.nmmotoristaDataGridViewTextBoxColumn,
            this.placaveiculoDataGridViewTextBoxColumn,
            this.nrfrotaDataGridViewTextBoxColumn,
            this.kilometragemDataGridViewTextBoxColumn,
            this.nmunidpagadoraDataGridViewTextBoxColumn,
            this.dsendunidpagadoraDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsCartaFrete;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(801, 390);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // bsCartaFrete
            // 
            this.bsCartaFrete.DataSource = typeof(CamadaDados.PostoCombustivel.TList_CartaFrete);
            this.bsCartaFrete.PositionChanged += new System.EventHandler(this.bsCartaFrete_PositionChanged);
            // 
            // nrcartafreteDataGridViewTextBoxColumn
            // 
            this.nrcartafreteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrcartafreteDataGridViewTextBoxColumn.DataPropertyName = "Nr_cartafrete";
            this.nrcartafreteDataGridViewTextBoxColumn.HeaderText = "Nº Carta Frete";
            this.nrcartafreteDataGridViewTextBoxColumn.Name = "nrcartafreteDataGridViewTextBoxColumn";
            this.nrcartafreteDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrcartafreteDataGridViewTextBoxColumn.Width = 99;
            // 
            // dtemissaoDataGridViewTextBoxColumn
            // 
            this.dtemissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaoDataGridViewTextBoxColumn.DataPropertyName = "Dt_emissao";
            this.dtemissaoDataGridViewTextBoxColumn.HeaderText = "Dt. Emissão";
            this.dtemissaoDataGridViewTextBoxColumn.Name = "dtemissaoDataGridViewTextBoxColumn";
            this.dtemissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtemissaoDataGridViewTextBoxColumn.Width = 88;
            // 
            // dtentradaDataGridViewTextBoxColumn
            // 
            this.dtentradaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtentradaDataGridViewTextBoxColumn.DataPropertyName = "Dt_entrada";
            this.dtentradaDataGridViewTextBoxColumn.HeaderText = "Dt. Entrada";
            this.dtentradaDataGridViewTextBoxColumn.Name = "dtentradaDataGridViewTextBoxColumn";
            this.dtentradaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtentradaDataGridViewTextBoxColumn.Width = 86;
            // 
            // dtvencimentoDataGridViewTextBoxColumn
            // 
            this.dtvencimentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvencimentoDataGridViewTextBoxColumn.DataPropertyName = "Dt_vencimento";
            this.dtvencimentoDataGridViewTextBoxColumn.HeaderText = "Dt. Vencimento";
            this.dtvencimentoDataGridViewTextBoxColumn.Name = "dtvencimentoDataGridViewTextBoxColumn";
            this.dtvencimentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtvencimentoDataGridViewTextBoxColumn.Width = 97;
            // 
            // vldocumentoDataGridViewTextBoxColumn
            // 
            this.vldocumentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vldocumentoDataGridViewTextBoxColumn.DataPropertyName = "Vl_documento";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N2";
            dataGridViewCellStyle19.NullValue = "0";
            this.vldocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle19;
            this.vldocumentoDataGridViewTextBoxColumn.HeaderText = "Vl. Documento";
            this.vldocumentoDataGridViewTextBoxColumn.Name = "vldocumentoDataGridViewTextBoxColumn";
            this.vldocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vldocumentoDataGridViewTextBoxColumn.Width = 94;
            // 
            // nmtransportadoraDataGridViewTextBoxColumn
            // 
            this.nmtransportadoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmtransportadoraDataGridViewTextBoxColumn.DataPropertyName = "Nm_transportadora";
            this.nmtransportadoraDataGridViewTextBoxColumn.HeaderText = "Transportadora";
            this.nmtransportadoraDataGridViewTextBoxColumn.Name = "nmtransportadoraDataGridViewTextBoxColumn";
            this.nmtransportadoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmtransportadoraDataGridViewTextBoxColumn.Width = 104;
            // 
            // dsenderecotranspDataGridViewTextBoxColumn
            // 
            this.dsenderecotranspDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsenderecotranspDataGridViewTextBoxColumn.DataPropertyName = "Ds_enderecotransp";
            this.dsenderecotranspDataGridViewTextBoxColumn.HeaderText = "Endereço";
            this.dsenderecotranspDataGridViewTextBoxColumn.Name = "dsenderecotranspDataGridViewTextBoxColumn";
            this.dsenderecotranspDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsenderecotranspDataGridViewTextBoxColumn.Width = 78;
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
            // placaveiculoDataGridViewTextBoxColumn
            // 
            this.placaveiculoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.placaveiculoDataGridViewTextBoxColumn.DataPropertyName = "Placaveiculo";
            this.placaveiculoDataGridViewTextBoxColumn.HeaderText = "Placa Veiculo";
            this.placaveiculoDataGridViewTextBoxColumn.Name = "placaveiculoDataGridViewTextBoxColumn";
            this.placaveiculoDataGridViewTextBoxColumn.ReadOnly = true;
            this.placaveiculoDataGridViewTextBoxColumn.Width = 89;
            // 
            // nrfrotaDataGridViewTextBoxColumn
            // 
            this.nrfrotaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrfrotaDataGridViewTextBoxColumn.DataPropertyName = "Nr_frota";
            this.nrfrotaDataGridViewTextBoxColumn.HeaderText = "Nº Frota";
            this.nrfrotaDataGridViewTextBoxColumn.Name = "nrfrotaDataGridViewTextBoxColumn";
            this.nrfrotaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrfrotaDataGridViewTextBoxColumn.Width = 66;
            // 
            // kilometragemDataGridViewTextBoxColumn
            // 
            this.kilometragemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.kilometragemDataGridViewTextBoxColumn.DataPropertyName = "Kilometragem";
            this.kilometragemDataGridViewTextBoxColumn.HeaderText = "KM";
            this.kilometragemDataGridViewTextBoxColumn.Name = "kilometragemDataGridViewTextBoxColumn";
            this.kilometragemDataGridViewTextBoxColumn.ReadOnly = true;
            this.kilometragemDataGridViewTextBoxColumn.Width = 48;
            // 
            // nmunidpagadoraDataGridViewTextBoxColumn
            // 
            this.nmunidpagadoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmunidpagadoraDataGridViewTextBoxColumn.DataPropertyName = "Nm_unidpagadora";
            this.nmunidpagadoraDataGridViewTextBoxColumn.HeaderText = "Unidade Pagadora";
            this.nmunidpagadoraDataGridViewTextBoxColumn.Name = "nmunidpagadoraDataGridViewTextBoxColumn";
            this.nmunidpagadoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmunidpagadoraDataGridViewTextBoxColumn.Width = 111;
            // 
            // dsendunidpagadoraDataGridViewTextBoxColumn
            // 
            this.dsendunidpagadoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsendunidpagadoraDataGridViewTextBoxColumn.DataPropertyName = "Ds_endunidpagadora";
            this.dsendunidpagadoraDataGridViewTextBoxColumn.HeaderText = "Endereço";
            this.dsendunidpagadoraDataGridViewTextBoxColumn.Name = "dsendunidpagadoraDataGridViewTextBoxColumn";
            this.dsendunidpagadoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsendunidpagadoraDataGridViewTextBoxColumn.Width = 78;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCartaFrete;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 390);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(801, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            // pTotais
            // 
            this.pTotais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pTotais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTotais.Controls.Add(this.vl_saldo);
            this.pTotais.Controls.Add(this.label3);
            this.pTotais.Controls.Add(this.vl_totcartafrete);
            this.pTotais.Controls.Add(this.label2);
            this.pTotais.Controls.Add(this.vl_totalliquidar);
            this.pTotais.Controls.Add(this.label1);
            this.pTotais.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTotais.Location = new System.Drawing.Point(4, 430);
            this.pTotais.Name = "pTotais";
            this.pTotais.NM_ProcDeletar = "";
            this.pTotais.NM_ProcGravar = "";
            this.pTotais.Size = new System.Drawing.Size(805, 37);
            this.pTotais.TabIndex = 1;
            // 
            // vl_saldo
            // 
            this.vl_saldo.DecimalPlaces = 2;
            this.vl_saldo.Enabled = false;
            this.vl_saldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.vl_saldo.Location = new System.Drawing.Point(550, 4);
            this.vl_saldo.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_saldo.Minimum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            -2147483648});
            this.vl_saldo.Name = "vl_saldo";
            this.vl_saldo.NM_Alias = "";
            this.vl_saldo.NM_Campo = "";
            this.vl_saldo.NM_Param = "";
            this.vl_saldo.Operador = "";
            this.vl_saldo.ReadOnly = true;
            this.vl_saldo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_saldo.Size = new System.Drawing.Size(120, 26);
            this.vl_saldo.ST_AutoInc = false;
            this.vl_saldo.ST_DisableAuto = false;
            this.vl_saldo.ST_Gravar = false;
            this.vl_saldo.ST_LimparCampo = true;
            this.vl_saldo.ST_NotNull = false;
            this.vl_saldo.ST_PrimaryKey = false;
            this.vl_saldo.TabIndex = 11;
            this.vl_saldo.TabStop = false;
            this.vl_saldo.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(501, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Saldo:";
            // 
            // vl_totcartafrete
            // 
            this.vl_totcartafrete.DecimalPlaces = 2;
            this.vl_totcartafrete.Enabled = false;
            this.vl_totcartafrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.vl_totcartafrete.Location = new System.Drawing.Point(363, 4);
            this.vl_totcartafrete.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_totcartafrete.Name = "vl_totcartafrete";
            this.vl_totcartafrete.NM_Alias = "";
            this.vl_totcartafrete.NM_Campo = "";
            this.vl_totcartafrete.NM_Param = "";
            this.vl_totcartafrete.Operador = "";
            this.vl_totcartafrete.ReadOnly = true;
            this.vl_totcartafrete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_totcartafrete.Size = new System.Drawing.Size(120, 26);
            this.vl_totcartafrete.ST_AutoInc = false;
            this.vl_totcartafrete.ST_DisableAuto = false;
            this.vl_totcartafrete.ST_Gravar = false;
            this.vl_totcartafrete.ST_LimparCampo = true;
            this.vl_totcartafrete.ST_NotNull = false;
            this.vl_totcartafrete.ST_PrimaryKey = false;
            this.vl_totcartafrete.TabIndex = 9;
            this.vl_totcartafrete.TabStop = false;
            this.vl_totcartafrete.ThousandsSeparator = true;
            this.vl_totcartafrete.ValueChanged += new System.EventHandler(this.vl_totcartafrete_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(250, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Total Carta Frete:";
            // 
            // vl_totalliquidar
            // 
            this.vl_totalliquidar.DecimalPlaces = 2;
            this.vl_totalliquidar.Enabled = false;
            this.vl_totalliquidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.vl_totalliquidar.Location = new System.Drawing.Point(102, 4);
            this.vl_totalliquidar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_totalliquidar.Name = "vl_totalliquidar";
            this.vl_totalliquidar.NM_Alias = "";
            this.vl_totalliquidar.NM_Campo = "";
            this.vl_totalliquidar.NM_Param = "";
            this.vl_totalliquidar.Operador = "";
            this.vl_totalliquidar.ReadOnly = true;
            this.vl_totalliquidar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_totalliquidar.Size = new System.Drawing.Size(120, 26);
            this.vl_totalliquidar.ST_AutoInc = false;
            this.vl_totalliquidar.ST_DisableAuto = false;
            this.vl_totalliquidar.ST_Gravar = false;
            this.vl_totalliquidar.ST_LimparCampo = true;
            this.vl_totalliquidar.ST_NotNull = false;
            this.vl_totalliquidar.ST_PrimaryKey = false;
            this.vl_totalliquidar.TabIndex = 7;
            this.vl_totalliquidar.TabStop = false;
            this.vl_totalliquidar.ThousandsSeparator = true;
            this.vl_totalliquidar.ValueChanged += new System.EventHandler(this.vl_totalliquidar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total Liquidar:";
            // 
            // TFLanListaCartaFrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 514);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanListaCartaFrete";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Carta Frete";
            this.Load += new System.EventHandler(this.TFLanListaCartaFrete_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanListaCartaFrete_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartaFrete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pTotais.ResumeLayout(false);
            this.pTotais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totcartafrete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totalliquidar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pGrid;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcartafreteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtemissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtentradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvencimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vldocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtransportadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsenderecotranspDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmmotoristaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placaveiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrfrotaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kilometragemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmunidpagadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsendunidpagadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsCartaFrete;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.PanelDados pTotais;
        private Componentes.EditFloat vl_saldo;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat vl_totcartafrete;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat vl_totalliquidar;
        private System.Windows.Forms.Label label1;
    }
}