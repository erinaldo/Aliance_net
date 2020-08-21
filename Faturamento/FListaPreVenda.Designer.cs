namespace Faturamento
{
    partial class TFListaPreVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaPreVenda));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsPreVenda = new System.Windows.Forms.BindingSource(this.components);
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.cbProcessar = new Componentes.CheckBoxDefault(this.components);
            this.gPreVenda = new Componentes.DataGridDefault(this.components);
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
            this.tot_selecionado = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tot_venda = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.empresa = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtBuscaCliente = new System.Windows.Forms.ToolStripTextBox();
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idprevendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlprevendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_devcred = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_condicionalbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ds_portador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_tabelaPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_condPgto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtemissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pNm_clifor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nm_pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_locacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_os = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmvendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPreVenda)).BeginInit();
            this.tlpCentral.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPreVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tot_selecionado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_venda)).BeginInit();
            this.panelDados2.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.txtBuscaCliente});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(994, 43);
            this.barraMenu.TabIndex = 0;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(105, 40);
            this.BB_Gravar.Text = "(F4)\r\nConfirmar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // bsPreVenda
            // 
            this.bsPreVenda.DataSource = typeof(CamadaDados.Faturamento.PDV.TList_PreVenda);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 1);
            this.tlpCentral.Controls.Add(this.pTotal, 0, 2);
            this.tlpCentral.Controls.Add(this.panelDados2, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 3;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpCentral.Size = new System.Drawing.Size(994, 529);
            this.tlpCentral.TabIndex = 1;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.cbProcessar);
            this.panelDados1.Controls.Add(this.gPreVenda);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(984, 443);
            this.panelDados1.TabIndex = 6;
            // 
            // cbProcessar
            // 
            this.cbProcessar.AutoSize = true;
            this.cbProcessar.Location = new System.Drawing.Point(7, 12);
            this.cbProcessar.Name = "cbProcessar";
            this.cbProcessar.NM_Alias = "";
            this.cbProcessar.NM_Campo = "";
            this.cbProcessar.NM_Param = "";
            this.cbProcessar.Size = new System.Drawing.Size(15, 14);
            this.cbProcessar.ST_Gravar = false;
            this.cbProcessar.ST_LimparCampo = true;
            this.cbProcessar.ST_NotNull = false;
            this.cbProcessar.TabIndex = 3;
            this.cbProcessar.UseVisualStyleBackColor = true;
            this.cbProcessar.Vl_False = "";
            this.cbProcessar.Vl_True = "";
            this.cbProcessar.Click += new System.EventHandler(this.cbProcessar_Click);
            // 
            // gPreVenda
            // 
            this.gPreVenda.AllowUserToAddRows = false;
            this.gPreVenda.AllowUserToDeleteRows = false;
            this.gPreVenda.AllowUserToOrderColumns = true;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPreVenda.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.gPreVenda.AutoGenerateColumns = false;
            this.gPreVenda.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPreVenda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPreVenda.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPreVenda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.gPreVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPreVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.idprevendaDataGridViewTextBoxColumn,
            this.vlprevendaDataGridViewTextBoxColumn,
            this.Vl_devcred,
            this.St_condicionalbool,
            this.Ds_portador,
            this.Cd_tabelaPreco,
            this.Ds_condPgto,
            this.dtemissaoDataGridViewTextBoxColumn,
            this.pNm_clifor,
            this.Nm_pessoa,
            this.Id_locacao,
            this.Id_os,
            this.Ds_observacao,
            this.nmvendedorDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn});
            this.gPreVenda.DataSource = this.bsPreVenda;
            this.gPreVenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gPreVenda.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPreVenda.Location = new System.Drawing.Point(0, 0);
            this.gPreVenda.Name = "gPreVenda";
            this.gPreVenda.ReadOnly = true;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPreVenda.RowHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.gPreVenda.RowHeadersWidth = 23;
            this.gPreVenda.Size = new System.Drawing.Size(982, 416);
            this.gPreVenda.TabIndex = 0;
            this.gPreVenda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gPreVenda_CellClick);
            this.gPreVenda.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gPreVenda_ColumnHeaderMouseClick);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsPreVenda;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 416);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(982, 25);
            this.bindingNavigator1.TabIndex = 4;
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
            this.pTotal.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTotal.Controls.Add(this.tot_selecionado);
            this.pTotal.Controls.Add(this.label2);
            this.pTotal.Controls.Add(this.tot_venda);
            this.pTotal.Controls.Add(this.label1);
            this.pTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTotal.Location = new System.Drawing.Point(5, 494);
            this.pTotal.Name = "pTotal";
            this.pTotal.NM_ProcDeletar = "";
            this.pTotal.NM_ProcGravar = "";
            this.pTotal.Size = new System.Drawing.Size(984, 30);
            this.pTotal.TabIndex = 7;
            // 
            // tot_selecionado
            // 
            this.tot_selecionado.DecimalPlaces = 2;
            this.tot_selecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_selecionado.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tot_selecionado.Location = new System.Drawing.Point(351, 3);
            this.tot_selecionado.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tot_selecionado.Name = "tot_selecionado";
            this.tot_selecionado.NM_Alias = "";
            this.tot_selecionado.NM_Campo = "";
            this.tot_selecionado.NM_Param = "";
            this.tot_selecionado.Operador = "";
            this.tot_selecionado.ReadOnly = true;
            this.tot_selecionado.Size = new System.Drawing.Size(120, 22);
            this.tot_selecionado.ST_AutoInc = false;
            this.tot_selecionado.ST_DisableAuto = false;
            this.tot_selecionado.ST_Gravar = false;
            this.tot_selecionado.ST_LimparCampo = true;
            this.tot_selecionado.ST_NotNull = false;
            this.tot_selecionado.ST_PrimaryKey = false;
            this.tot_selecionado.TabIndex = 3;
            this.tot_selecionado.TabStop = false;
            this.tot_selecionado.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Selecionado:";
            // 
            // tot_venda
            // 
            this.tot_venda.DecimalPlaces = 2;
            this.tot_venda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_venda.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tot_venda.Location = new System.Drawing.Point(97, 4);
            this.tot_venda.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tot_venda.Name = "tot_venda";
            this.tot_venda.NM_Alias = "";
            this.tot_venda.NM_Campo = "";
            this.tot_venda.NM_Param = "";
            this.tot_venda.Operador = "";
            this.tot_venda.ReadOnly = true;
            this.tot_venda.Size = new System.Drawing.Size(120, 22);
            this.tot_venda.ST_AutoInc = false;
            this.tot_venda.ST_DisableAuto = false;
            this.tot_venda.ST_Gravar = false;
            this.tot_venda.ST_LimparCampo = true;
            this.tot_venda.ST_NotNull = false;
            this.tot_venda.ST_PrimaryKey = false;
            this.tot_venda.TabIndex = 1;
            this.tot_venda.TabStop = false;
            this.tot_venda.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Venda:";
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(this.empresa);
            this.panelDados2.Controls.Add(this.label3);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(5, 5);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(984, 30);
            this.panelDados2.TabIndex = 0;
            // 
            // empresa
            // 
            this.empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresa.FormattingEnabled = true;
            this.empresa.Location = new System.Drawing.Point(71, 3);
            this.empresa.Name = "empresa";
            this.empresa.NM_Alias = "";
            this.empresa.NM_Campo = "";
            this.empresa.NM_Param = "";
            this.empresa.Size = new System.Drawing.Size(905, 21);
            this.empresa.ST_Gravar = false;
            this.empresa.ST_LimparCampo = true;
            this.empresa.ST_NotNull = false;
            this.empresa.TabIndex = 1;
            this.empresa.SelectedIndexChanged += new System.EventHandler(this.empresa_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Empresa:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(93, 40);
            this.toolStripLabel1.Text = "CLIENTE:";
            // 
            // txtBuscaCliente
            // 
            this.txtBuscaCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscaCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscaCliente.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtBuscaCliente.Name = "txtBuscaCliente";
            this.txtBuscaCliente.Size = new System.Drawing.Size(500, 43);
            this.txtBuscaCliente.TextChanged += new System.EventHandler(this.txtBuscaCliente_TextChanged);
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Selecionar";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Width = 63;
            // 
            // idprevendaDataGridViewTextBoxColumn
            // 
            this.idprevendaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idprevendaDataGridViewTextBoxColumn.DataPropertyName = "Id_prevenda";
            this.idprevendaDataGridViewTextBoxColumn.HeaderText = "Nº Venda";
            this.idprevendaDataGridViewTextBoxColumn.Name = "idprevendaDataGridViewTextBoxColumn";
            this.idprevendaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idprevendaDataGridViewTextBoxColumn.Width = 78;
            // 
            // vlprevendaDataGridViewTextBoxColumn
            // 
            this.vlprevendaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlprevendaDataGridViewTextBoxColumn.DataPropertyName = "Vl_prevenda";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "N2";
            dataGridViewCellStyle23.NullValue = "0";
            this.vlprevendaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle23;
            this.vlprevendaDataGridViewTextBoxColumn.HeaderText = "Valor Faturar";
            this.vlprevendaDataGridViewTextBoxColumn.Name = "vlprevendaDataGridViewTextBoxColumn";
            this.vlprevendaDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlprevendaDataGridViewTextBoxColumn.Width = 92;
            // 
            // Vl_devcred
            // 
            this.Vl_devcred.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_devcred.DataPropertyName = "Vl_devcred";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Format = "N2";
            dataGridViewCellStyle24.NullValue = "0";
            this.Vl_devcred.DefaultCellStyle = dataGridViewCellStyle24;
            this.Vl_devcred.HeaderText = "Vl. Cred. Devolver";
            this.Vl_devcred.Name = "Vl_devcred";
            this.Vl_devcred.ReadOnly = true;
            this.Vl_devcred.Width = 108;
            // 
            // St_condicionalbool
            // 
            this.St_condicionalbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_condicionalbool.DataPropertyName = "St_condicionalbool";
            this.St_condicionalbool.HeaderText = "Condicional";
            this.St_condicionalbool.Name = "St_condicionalbool";
            this.St_condicionalbool.ReadOnly = true;
            this.St_condicionalbool.Width = 68;
            // 
            // Ds_portador
            // 
            this.Ds_portador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_portador.DataPropertyName = "Ds_portador";
            this.Ds_portador.HeaderText = "Portador";
            this.Ds_portador.Name = "Ds_portador";
            this.Ds_portador.ReadOnly = true;
            this.Ds_portador.Width = 72;
            // 
            // Cd_tabelaPreco
            // 
            this.Cd_tabelaPreco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_tabelaPreco.DataPropertyName = "Cd_tabelaPreco";
            this.Cd_tabelaPreco.HeaderText = "Cd.Tabela Preço";
            this.Cd_tabelaPreco.Name = "Cd_tabelaPreco";
            this.Cd_tabelaPreco.ReadOnly = true;
            this.Cd_tabelaPreco.Width = 103;
            // 
            // Ds_condPgto
            // 
            this.Ds_condPgto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_condPgto.DataPropertyName = "Ds_condPgto";
            this.Ds_condPgto.HeaderText = "Cond.Pagto";
            this.Ds_condPgto.Name = "Ds_condPgto";
            this.Ds_condPgto.ReadOnly = true;
            this.Ds_condPgto.Width = 88;
            // 
            // dtemissaoDataGridViewTextBoxColumn
            // 
            this.dtemissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaoDataGridViewTextBoxColumn.DataPropertyName = "Dt_emissao";
            this.dtemissaoDataGridViewTextBoxColumn.HeaderText = "Dt. Emissão";
            this.dtemissaoDataGridViewTextBoxColumn.Name = "dtemissaoDataGridViewTextBoxColumn";
            this.dtemissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtemissaoDataGridViewTextBoxColumn.Width = 81;
            // 
            // pNm_clifor
            // 
            this.pNm_clifor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pNm_clifor.DataPropertyName = "Nm_clifor";
            this.pNm_clifor.HeaderText = "Cliente";
            this.pNm_clifor.Name = "pNm_clifor";
            this.pNm_clifor.ReadOnly = true;
            this.pNm_clifor.Width = 64;
            // 
            // Nm_pessoa
            // 
            this.Nm_pessoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nm_pessoa.DataPropertyName = "Nm_pessoa";
            this.Nm_pessoa.HeaderText = "Autorizado";
            this.Nm_pessoa.Name = "Nm_pessoa";
            this.Nm_pessoa.ReadOnly = true;
            this.Nm_pessoa.Width = 82;
            // 
            // Id_locacao
            // 
            this.Id_locacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Id_locacao.DataPropertyName = "Id_locacao";
            this.Id_locacao.HeaderText = "Nº Locação";
            this.Id_locacao.Name = "Id_locacao";
            this.Id_locacao.ReadOnly = true;
            this.Id_locacao.Width = 82;
            // 
            // Id_os
            // 
            this.Id_os.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Id_os.DataPropertyName = "Id_os";
            this.Id_os.HeaderText = "Nº Orderm Serviço";
            this.Id_os.Name = "Id_os";
            this.Id_os.ReadOnly = true;
            this.Id_os.Width = 110;
            // 
            // Ds_observacao
            // 
            this.Ds_observacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_observacao.DataPropertyName = "Ds_observacao";
            this.Ds_observacao.HeaderText = "Observação";
            this.Ds_observacao.Name = "Ds_observacao";
            this.Ds_observacao.ReadOnly = true;
            this.Ds_observacao.Width = 90;
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
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 85;
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
            // TFListaPreVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 572);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaPreVenda";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Pré Venda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFListaPreVenda_FormClosing);
            this.Load += new System.EventHandler(this.TFListaPreVenda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaPreVenda_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TFListaPreVenda_KeyPress);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPreVenda)).EndInit();
            this.tlpCentral.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPreVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pTotal.ResumeLayout(false);
            this.pTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tot_selecionado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_venda)).EndInit();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gPreVenda;
        private System.Windows.Forms.BindingSource bsPreVenda;
        private Componentes.CheckBoxDefault cbProcessar;
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
        private Componentes.PanelDados pTotal;
        private Componentes.EditFloat tot_selecionado;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat tot_venda;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault empresa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtBuscaCliente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprevendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlprevendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_devcred;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_condicionalbool;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_portador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_tabelaPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_condPgto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtemissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pNm_clifor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nm_pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_locacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_os;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_observacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
    }
}