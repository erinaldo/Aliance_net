namespace Balanca
{
    partial class TFDesdobroEspecial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDesdobroEspecial));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.gDesdobroEspecial = new Componentes.DataGridDefault(this.components);
            this.iddesdobroespecialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idticketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tppesagemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtpdesdobrostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstpdesdobroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocalcpesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipolandesdobroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrpedidodeststrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutodestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcdesdobroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pesodesdobroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutodestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDesdobroEspecial = new System.Windows.Forms.BindingSource(this.components);
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
            this.tlpCentral.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gDesdobroEspecial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDesdobroEspecial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Alterar,
            this.BB_Excluir,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1073, 43);
            this.barraMenu.TabIndex = 1;
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
            // BB_Alterar
            // 
            this.BB_Alterar.AutoSize = false;
            this.BB_Alterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Alterar.ForeColor = System.Drawing.Color.Green;
            this.BB_Alterar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Alterar.Image")));
            this.BB_Alterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Alterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Alterar.Name = "BB_Alterar";
            this.BB_Alterar.Size = new System.Drawing.Size(75, 40);
            this.BB_Alterar.Text = "(F3)\r\nAlterar";
            this.BB_Alterar.ToolTipText = "Alterar Registro";
            this.BB_Alterar.Click += new System.EventHandler(this.BB_Alterar_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.AutoSize = false;
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(50, 40);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Controls.Add(this.pGrid, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Size = new System.Drawing.Size(1073, 419);
            this.tlpCentral.TabIndex = 2;
            // 
            // pGrid
            // 
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pGrid.Controls.Add(this.gDesdobroEspecial);
            this.pGrid.Controls.Add(this.bindingNavigator1);
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid.Location = new System.Drawing.Point(5, 5);
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            this.pGrid.Size = new System.Drawing.Size(1063, 409);
            this.pGrid.TabIndex = 0;
            // 
            // gDesdobroEspecial
            // 
            this.gDesdobroEspecial.AllowUserToAddRows = false;
            this.gDesdobroEspecial.AllowUserToDeleteRows = false;
            this.gDesdobroEspecial.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gDesdobroEspecial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gDesdobroEspecial.AutoGenerateColumns = false;
            this.gDesdobroEspecial.BackgroundColor = System.Drawing.Color.LightGray;
            this.gDesdobroEspecial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gDesdobroEspecial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gDesdobroEspecial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gDesdobroEspecial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gDesdobroEspecial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iddesdobroespecialDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.idticketDataGridViewTextBoxColumn,
            this.tppesagemDataGridViewTextBoxColumn,
            this.idtpdesdobrostrDataGridViewTextBoxColumn,
            this.dstpdesdobroDataGridViewTextBoxColumn,
            this.tipocalcpesoDataGridViewTextBoxColumn,
            this.tipolandesdobroDataGridViewTextBoxColumn,
            this.nrpedidodeststrDataGridViewTextBoxColumn,
            this.cdprodutodestDataGridViewTextBoxColumn,
            this.pcdesdobroDataGridViewTextBoxColumn,
            this.pesodesdobroDataGridViewTextBoxColumn,
            this.dsprodutodestDataGridViewTextBoxColumn});
            this.gDesdobroEspecial.DataSource = this.bsDesdobroEspecial;
            this.gDesdobroEspecial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gDesdobroEspecial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gDesdobroEspecial.Location = new System.Drawing.Point(0, 0);
            this.gDesdobroEspecial.Name = "gDesdobroEspecial";
            this.gDesdobroEspecial.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gDesdobroEspecial.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gDesdobroEspecial.RowHeadersWidth = 23;
            this.gDesdobroEspecial.Size = new System.Drawing.Size(1059, 380);
            this.gDesdobroEspecial.TabIndex = 0;
            this.gDesdobroEspecial.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gDesdobroEspecial_ColumnHeaderMouseClick);
            // 
            // iddesdobroespecialDataGridViewTextBoxColumn
            // 
            this.iddesdobroespecialDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iddesdobroespecialDataGridViewTextBoxColumn.DataPropertyName = "Id_desdobroespecial";
            this.iddesdobroespecialDataGridViewTextBoxColumn.HeaderText = "Id. Desdobro";
            this.iddesdobroespecialDataGridViewTextBoxColumn.Name = "iddesdobroespecialDataGridViewTextBoxColumn";
            this.iddesdobroespecialDataGridViewTextBoxColumn.ReadOnly = true;
            this.iddesdobroespecialDataGridViewTextBoxColumn.Width = 93;
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
            // idticketDataGridViewTextBoxColumn
            // 
            this.idticketDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idticketDataGridViewTextBoxColumn.DataPropertyName = "Id_ticket";
            this.idticketDataGridViewTextBoxColumn.HeaderText = "Id. Ticket";
            this.idticketDataGridViewTextBoxColumn.Name = "idticketDataGridViewTextBoxColumn";
            this.idticketDataGridViewTextBoxColumn.ReadOnly = true;
            this.idticketDataGridViewTextBoxColumn.Width = 77;
            // 
            // tppesagemDataGridViewTextBoxColumn
            // 
            this.tppesagemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tppesagemDataGridViewTextBoxColumn.DataPropertyName = "Tp_pesagem";
            this.tppesagemDataGridViewTextBoxColumn.HeaderText = "TP. Pesagem";
            this.tppesagemDataGridViewTextBoxColumn.Name = "tppesagemDataGridViewTextBoxColumn";
            this.tppesagemDataGridViewTextBoxColumn.ReadOnly = true;
            this.tppesagemDataGridViewTextBoxColumn.Width = 96;
            // 
            // idtpdesdobrostrDataGridViewTextBoxColumn
            // 
            this.idtpdesdobrostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idtpdesdobrostrDataGridViewTextBoxColumn.DataPropertyName = "Id_tpdesdobrostr";
            this.idtpdesdobrostrDataGridViewTextBoxColumn.HeaderText = "TP. Desdobro";
            this.idtpdesdobrostrDataGridViewTextBoxColumn.Name = "idtpdesdobrostrDataGridViewTextBoxColumn";
            this.idtpdesdobrostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idtpdesdobrostrDataGridViewTextBoxColumn.Width = 98;
            // 
            // dstpdesdobroDataGridViewTextBoxColumn
            // 
            this.dstpdesdobroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstpdesdobroDataGridViewTextBoxColumn.DataPropertyName = "Ds_tpdesdobro";
            this.dstpdesdobroDataGridViewTextBoxColumn.HeaderText = "Tipo Desdobro";
            this.dstpdesdobroDataGridViewTextBoxColumn.Name = "dstpdesdobroDataGridViewTextBoxColumn";
            this.dstpdesdobroDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstpdesdobroDataGridViewTextBoxColumn.Width = 102;
            // 
            // tipocalcpesoDataGridViewTextBoxColumn
            // 
            this.tipocalcpesoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipocalcpesoDataGridViewTextBoxColumn.DataPropertyName = "Tipo_calcpeso";
            this.tipocalcpesoDataGridViewTextBoxColumn.HeaderText = "Base Calculo";
            this.tipocalcpesoDataGridViewTextBoxColumn.Name = "tipocalcpesoDataGridViewTextBoxColumn";
            this.tipocalcpesoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipocalcpesoDataGridViewTextBoxColumn.Width = 94;
            // 
            // tipolandesdobroDataGridViewTextBoxColumn
            // 
            this.tipolandesdobroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipolandesdobroDataGridViewTextBoxColumn.DataPropertyName = "Tipo_landesdobro";
            this.tipolandesdobroDataGridViewTextBoxColumn.HeaderText = "Tipo Lan. Desdobro";
            this.tipolandesdobroDataGridViewTextBoxColumn.Name = "tipolandesdobroDataGridViewTextBoxColumn";
            this.tipolandesdobroDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipolandesdobroDataGridViewTextBoxColumn.Width = 115;
            // 
            // nrpedidodeststrDataGridViewTextBoxColumn
            // 
            this.nrpedidodeststrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrpedidodeststrDataGridViewTextBoxColumn.DataPropertyName = "Nr_pedidodeststr";
            this.nrpedidodeststrDataGridViewTextBoxColumn.HeaderText = "Nº Pedido Destino";
            this.nrpedidodeststrDataGridViewTextBoxColumn.Name = "nrpedidodeststrDataGridViewTextBoxColumn";
            this.nrpedidodeststrDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrpedidodeststrDataGridViewTextBoxColumn.Width = 109;
            // 
            // cdprodutodestDataGridViewTextBoxColumn
            // 
            this.cdprodutodestDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutodestDataGridViewTextBoxColumn.DataPropertyName = "Cd_produtodest";
            this.cdprodutodestDataGridViewTextBoxColumn.HeaderText = "Cd. Produto Dest.";
            this.cdprodutodestDataGridViewTextBoxColumn.Name = "cdprodutodestDataGridViewTextBoxColumn";
            this.cdprodutodestDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutodestDataGridViewTextBoxColumn.Width = 106;
            // 
            // pcdesdobroDataGridViewTextBoxColumn
            // 
            this.pcdesdobroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pcdesdobroDataGridViewTextBoxColumn.DataPropertyName = "Pc_desdobro";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.pcdesdobroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.pcdesdobroDataGridViewTextBoxColumn.HeaderText = "% Desdobro";
            this.pcdesdobroDataGridViewTextBoxColumn.Name = "pcdesdobroDataGridViewTextBoxColumn";
            this.pcdesdobroDataGridViewTextBoxColumn.ReadOnly = true;
            this.pcdesdobroDataGridViewTextBoxColumn.Width = 82;
            // 
            // pesodesdobroDataGridViewTextBoxColumn
            // 
            this.pesodesdobroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pesodesdobroDataGridViewTextBoxColumn.DataPropertyName = "Peso_desdobro";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = "0";
            this.pesodesdobroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.pesodesdobroDataGridViewTextBoxColumn.HeaderText = "Peso Desdobro";
            this.pesodesdobroDataGridViewTextBoxColumn.Name = "pesodesdobroDataGridViewTextBoxColumn";
            this.pesodesdobroDataGridViewTextBoxColumn.ReadOnly = true;
            this.pesodesdobroDataGridViewTextBoxColumn.Width = 97;
            // 
            // dsprodutodestDataGridViewTextBoxColumn
            // 
            this.dsprodutodestDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutodestDataGridViewTextBoxColumn.DataPropertyName = "Ds_produtodest";
            this.dsprodutodestDataGridViewTextBoxColumn.HeaderText = "Produto Destino";
            this.dsprodutodestDataGridViewTextBoxColumn.Name = "dsprodutodestDataGridViewTextBoxColumn";
            this.dsprodutodestDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutodestDataGridViewTextBoxColumn.Width = 99;
            // 
            // bsDesdobroEspecial
            // 
            this.bsDesdobroEspecial.DataSource = typeof(CamadaDados.Balanca.TList_DesdobroEspecial);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsDesdobroEspecial;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 380);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1059, 25);
            this.bindingNavigator1.TabIndex = 1;
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
            // TFDesdobroEspecial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 462);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDesdobroEspecial";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desdobros Especiais";
            this.Load += new System.EventHandler(this.TFDesdobroEspecial_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFDesdobroEspecial_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDesdobroEspecial_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gDesdobroEspecial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDesdobroEspecial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Novo;
        public System.Windows.Forms.ToolStripButton BB_Alterar;
        public System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pGrid;
        private Componentes.DataGridDefault gDesdobroEspecial;
        private System.Windows.Forms.BindingSource bsDesdobroEspecial;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddesdobroespecialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idticketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tppesagemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtpdesdobrostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstpdesdobroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocalcpesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipolandesdobroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrpedidodeststrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutodestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcdesdobroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pesodesdobroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutodestDataGridViewTextBoxColumn;
    }
}