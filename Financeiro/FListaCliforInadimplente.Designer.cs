namespace Financeiro
{
    partial class TFListaCliforInadimplente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaCliforInadimplente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_imprimir = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.gGrid = new Componentes.DataGridDefault(this.components);
            this.cdcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vllimitecreditoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vllimitecredCHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vldebitoabertoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stbloqdebitovencidoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vldebitovenctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stbloqcreditoavulsoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dsmotivobloqavulsoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtrenovacaocadastroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strenovarcadastroDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vlchdevolvidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlchpredatadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stbloqueiospcboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtconsultaSPCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDadosBloqueio = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDadosBloqueio)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_imprimir});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1018, 43);
            this.barraMenu.TabIndex = 14;
            // 
            // bb_imprimir
            // 
            this.bb_imprimir.AutoSize = false;
            this.bb_imprimir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_imprimir.ForeColor = System.Drawing.Color.Green;
            this.bb_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("bb_imprimir.Image")));
            this.bb_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_imprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_imprimir.Name = "bb_imprimir";
            this.bb_imprimir.Size = new System.Drawing.Size(90, 40);
            this.bb_imprimir.Text = " (F8)\r\n Imprimir";
            this.bb_imprimir.ToolTipText = "Gravar Registro";
            this.bb_imprimir.Click += new System.EventHandler(this.bb_imprimir_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsDadosBloqueio;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 646);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1018, 25);
            this.bindingNavigator1.TabIndex = 16;
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
            // gGrid
            // 
            this.gGrid.AllowUserToAddRows = false;
            this.gGrid.AllowUserToDeleteRows = false;
            this.gGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gGrid.AutoGenerateColumns = false;
            this.gGrid.BackgroundColor = System.Drawing.Color.LightGray;
            this.gGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdcliforDataGridViewTextBoxColumn,
            this.nmcliforDataGridViewTextBoxColumn,
            this.vllimitecreditoDataGridViewTextBoxColumn,
            this.vllimitecredCHDataGridViewTextBoxColumn,
            this.vldebitoabertoDataGridViewTextBoxColumn,
            this.stbloqdebitovencidoboolDataGridViewCheckBoxColumn,
            this.vldebitovenctoDataGridViewTextBoxColumn,
            this.stbloqcreditoavulsoboolDataGridViewCheckBoxColumn,
            this.dsmotivobloqavulsoDataGridViewTextBoxColumn,
            this.dtrenovacaocadastroDataGridViewTextBoxColumn,
            this.strenovarcadastroDataGridViewCheckBoxColumn,
            this.vlchdevolvidoDataGridViewTextBoxColumn,
            this.vlchpredatadoDataGridViewTextBoxColumn,
            this.stbloqueiospcboolDataGridViewCheckBoxColumn,
            this.dtconsultaSPCDataGridViewTextBoxColumn});
            this.gGrid.DataSource = this.bsDadosBloqueio;
            this.gGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gGrid.Location = new System.Drawing.Point(0, 43);
            this.gGrid.Name = "gGrid";
            this.gGrid.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gGrid.RowHeadersWidth = 23;
            this.gGrid.Size = new System.Drawing.Size(1018, 603);
            this.gGrid.TabIndex = 15;
            this.gGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gGrid_ColumnHeaderMouseClick);
            // 
            // cdcliforDataGridViewTextBoxColumn
            // 
            this.cdcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcliforDataGridViewTextBoxColumn.DataPropertyName = "Cd_clifor";
            this.cdcliforDataGridViewTextBoxColumn.HeaderText = "Cd. Cliente";
            this.cdcliforDataGridViewTextBoxColumn.Name = "cdcliforDataGridViewTextBoxColumn";
            this.cdcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcliforDataGridViewTextBoxColumn.Width = 83;
            // 
            // nmcliforDataGridViewTextBoxColumn
            // 
            this.nmcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor";
            this.nmcliforDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.nmcliforDataGridViewTextBoxColumn.Name = "nmcliforDataGridViewTextBoxColumn";
            this.nmcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcliforDataGridViewTextBoxColumn.Width = 64;
            // 
            // vllimitecreditoDataGridViewTextBoxColumn
            // 
            this.vllimitecreditoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vllimitecreditoDataGridViewTextBoxColumn.DataPropertyName = "Vl_limitecredito";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.vllimitecreditoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.vllimitecreditoDataGridViewTextBoxColumn.HeaderText = "Limite Credido";
            this.vllimitecreditoDataGridViewTextBoxColumn.Name = "vllimitecreditoDataGridViewTextBoxColumn";
            this.vllimitecreditoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vllimitecreditoDataGridViewTextBoxColumn.Width = 98;
            // 
            // vllimitecredCHDataGridViewTextBoxColumn
            // 
            this.vllimitecredCHDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vllimitecredCHDataGridViewTextBoxColumn.DataPropertyName = "Vl_limitecredCH";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vllimitecredCHDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.vllimitecredCHDataGridViewTextBoxColumn.HeaderText = "Limite Credito CH.";
            this.vllimitecredCHDataGridViewTextBoxColumn.Name = "vllimitecredCHDataGridViewTextBoxColumn";
            this.vllimitecredCHDataGridViewTextBoxColumn.ReadOnly = true;
            this.vllimitecredCHDataGridViewTextBoxColumn.Width = 90;
            // 
            // vldebitoabertoDataGridViewTextBoxColumn
            // 
            this.vldebitoabertoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vldebitoabertoDataGridViewTextBoxColumn.DataPropertyName = "Vl_debito_aberto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.vldebitoabertoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.vldebitoabertoDataGridViewTextBoxColumn.HeaderText = "Debito Aberto";
            this.vldebitoabertoDataGridViewTextBoxColumn.Name = "vldebitoabertoDataGridViewTextBoxColumn";
            this.vldebitoabertoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vldebitoabertoDataGridViewTextBoxColumn.Width = 89;
            // 
            // stbloqdebitovencidoboolDataGridViewCheckBoxColumn
            // 
            this.stbloqdebitovencidoboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stbloqdebitovencidoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_bloq_debitovencidobool";
            this.stbloqdebitovencidoboolDataGridViewCheckBoxColumn.HeaderText = "Bloquear Deb. Vencido";
            this.stbloqdebitovencidoboolDataGridViewCheckBoxColumn.Name = "stbloqdebitovencidoboolDataGridViewCheckBoxColumn";
            this.stbloqdebitovencidoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stbloqdebitovencidoboolDataGridViewCheckBoxColumn.Width = 111;
            // 
            // vldebitovenctoDataGridViewTextBoxColumn
            // 
            this.vldebitovenctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vldebitovenctoDataGridViewTextBoxColumn.DataPropertyName = "Vl_debito_vencto";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.vldebitovenctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.vldebitovenctoDataGridViewTextBoxColumn.HeaderText = "Debito Vencido";
            this.vldebitovenctoDataGridViewTextBoxColumn.Name = "vldebitovenctoDataGridViewTextBoxColumn";
            this.vldebitovenctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vldebitovenctoDataGridViewTextBoxColumn.Width = 97;
            // 
            // stbloqcreditoavulsoboolDataGridViewCheckBoxColumn
            // 
            this.stbloqcreditoavulsoboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stbloqcreditoavulsoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_bloqcreditoavulsobool";
            this.stbloqcreditoavulsoboolDataGridViewCheckBoxColumn.HeaderText = "Bloqueio Avulso";
            this.stbloqcreditoavulsoboolDataGridViewCheckBoxColumn.Name = "stbloqcreditoavulsoboolDataGridViewCheckBoxColumn";
            this.stbloqcreditoavulsoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stbloqcreditoavulsoboolDataGridViewCheckBoxColumn.Width = 80;
            // 
            // dsmotivobloqavulsoDataGridViewTextBoxColumn
            // 
            this.dsmotivobloqavulsoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmotivobloqavulsoDataGridViewTextBoxColumn.DataPropertyName = "Ds_motivobloqavulso";
            this.dsmotivobloqavulsoDataGridViewTextBoxColumn.HeaderText = "Motivo Bloqueio";
            this.dsmotivobloqavulsoDataGridViewTextBoxColumn.Name = "dsmotivobloqavulsoDataGridViewTextBoxColumn";
            this.dsmotivobloqavulsoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsmotivobloqavulsoDataGridViewTextBoxColumn.Width = 99;
            // 
            // dtrenovacaocadastroDataGridViewTextBoxColumn
            // 
            this.dtrenovacaocadastroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtrenovacaocadastroDataGridViewTextBoxColumn.DataPropertyName = "Dt_renovacaocadastro";
            this.dtrenovacaocadastroDataGridViewTextBoxColumn.HeaderText = "Dt. Renovar Cad.";
            this.dtrenovacaocadastroDataGridViewTextBoxColumn.Name = "dtrenovacaocadastroDataGridViewTextBoxColumn";
            this.dtrenovacaocadastroDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtrenovacaocadastroDataGridViewTextBoxColumn.Width = 106;
            // 
            // strenovarcadastroDataGridViewCheckBoxColumn
            // 
            this.strenovarcadastroDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.strenovarcadastroDataGridViewCheckBoxColumn.DataPropertyName = "St_renovarcadastro";
            this.strenovarcadastroDataGridViewCheckBoxColumn.HeaderText = "Renovar Cadastro";
            this.strenovarcadastroDataGridViewCheckBoxColumn.Name = "strenovarcadastroDataGridViewCheckBoxColumn";
            this.strenovarcadastroDataGridViewCheckBoxColumn.ReadOnly = true;
            this.strenovarcadastroDataGridViewCheckBoxColumn.Width = 89;
            // 
            // vlchdevolvidoDataGridViewTextBoxColumn
            // 
            this.vlchdevolvidoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlchdevolvidoDataGridViewTextBoxColumn.DataPropertyName = "Vl_ch_devolvido";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.vlchdevolvidoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.vlchdevolvidoDataGridViewTextBoxColumn.HeaderText = "Ch. Devolvido";
            this.vlchdevolvidoDataGridViewTextBoxColumn.Name = "vlchdevolvidoDataGridViewTextBoxColumn";
            this.vlchdevolvidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlchdevolvidoDataGridViewTextBoxColumn.Width = 91;
            // 
            // vlchpredatadoDataGridViewTextBoxColumn
            // 
            this.vlchpredatadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlchpredatadoDataGridViewTextBoxColumn.DataPropertyName = "Vl_ch_predatado";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0";
            this.vlchpredatadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.vlchpredatadoDataGridViewTextBoxColumn.HeaderText = "Ch. Compensar";
            this.vlchpredatadoDataGridViewTextBoxColumn.Name = "vlchpredatadoDataGridViewTextBoxColumn";
            this.vlchpredatadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlchpredatadoDataGridViewTextBoxColumn.Width = 96;
            // 
            // stbloqueiospcboolDataGridViewCheckBoxColumn
            // 
            this.stbloqueiospcboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stbloqueiospcboolDataGridViewCheckBoxColumn.DataPropertyName = "St_bloqueiospcbool";
            this.stbloqueiospcboolDataGridViewCheckBoxColumn.HeaderText = "Bloqueio SPC";
            this.stbloqueiospcboolDataGridViewCheckBoxColumn.Name = "stbloqueiospcboolDataGridViewCheckBoxColumn";
            this.stbloqueiospcboolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stbloqueiospcboolDataGridViewCheckBoxColumn.Width = 70;
            // 
            // dtconsultaSPCDataGridViewTextBoxColumn
            // 
            this.dtconsultaSPCDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtconsultaSPCDataGridViewTextBoxColumn.DataPropertyName = "Dt_consultaSPC";
            this.dtconsultaSPCDataGridViewTextBoxColumn.HeaderText = "Dt. Consulta SPC";
            this.dtconsultaSPCDataGridViewTextBoxColumn.Name = "dtconsultaSPCDataGridViewTextBoxColumn";
            this.dtconsultaSPCDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtconsultaSPCDataGridViewTextBoxColumn.Width = 105;
            // 
            // bsDadosBloqueio
            // 
            this.bsDadosBloqueio.DataSource = typeof(CamadaDados.Financeiro.Duplicata.TList_DadosBloqueio);
            // 
            // TFListaCliforInadimplente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 671);
            this.Controls.Add(this.gGrid);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaCliforInadimplente";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listagem Clientes Inadimplentes";
            this.Load += new System.EventHandler(this.TFListaCliforInadimplente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaCliforInadimplente_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDadosBloqueio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_imprimir;
        private Componentes.DataGridDefault gGrid;
        private System.Windows.Forms.BindingSource bsDadosBloqueio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vllimitecreditoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vllimitecredCHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vldebitoabertoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stbloqdebitovencidoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vldebitovenctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stbloqcreditoavulsoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmotivobloqavulsoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtrenovacaocadastroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn strenovarcadastroDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlchdevolvidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlchpredatadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stbloqueiospcboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtconsultaSPCDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
    }
}