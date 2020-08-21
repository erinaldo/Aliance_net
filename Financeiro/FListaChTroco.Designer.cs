namespace Financeiro
{
    partial class TFListaChTroco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaChTroco));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.cmc7 = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vl_saldo = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.vl_troco = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.gTitulos = new Componentes.DataGridDefault(this.components);
            this.nrchequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtemissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vltituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvenctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomecliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrcgccpfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTitulos = new System.Windows.Forms.BindingSource(this.components);
            this.TS_ItensPedido = new System.Windows.Forms.ToolStrip();
            this.btn_Deleta_Item = new System.Windows.Forms.ToolStripButton();
            this.bnCheques = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_troco)).BeginInit();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTitulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulos)).BeginInit();
            this.TS_ItensPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnCheques)).BeginInit();
            this.bnCheques.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(821, 43);
            this.barraMenu.TabIndex = 535;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
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
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados2, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(821, 475);
            this.tlpCentral.TabIndex = 536;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.cd_empresa);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.cmc7);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.vl_saldo);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.vl_troco);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(4, 4);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(813, 43);
            this.panelDados1.TabIndex = 0;
            // 
            // cmc7
            // 
            this.cmc7.BackColor = System.Drawing.SystemColors.Window;
            this.cmc7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmc7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmc7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmc7.Location = new System.Drawing.Point(103, 16);
            this.cmc7.Name = "cmc7";
            this.cmc7.NM_Alias = "";
            this.cmc7.NM_Campo = "";
            this.cmc7.NM_CampoBusca = "";
            this.cmc7.NM_Param = "";
            this.cmc7.QTD_Zero = 0;
            this.cmc7.Size = new System.Drawing.Size(488, 20);
            this.cmc7.ST_AutoInc = false;
            this.cmc7.ST_DisableAuto = false;
            this.cmc7.ST_Float = false;
            this.cmc7.ST_Gravar = false;
            this.cmc7.ST_Int = false;
            this.cmc7.ST_LimpaCampo = true;
            this.cmc7.ST_NotNull = false;
            this.cmc7.ST_PrimaryKey = false;
            this.cmc7.TabIndex = 5;
            this.cmc7.TextOld = null;
            this.cmc7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmc7_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(100, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Buscar (CMC7 ou Nº Cheque)";
            // 
            // vl_saldo
            // 
            this.vl_saldo.DecimalPlaces = 2;
            this.vl_saldo.Enabled = false;
            this.vl_saldo.Location = new System.Drawing.Point(707, 16);
            this.vl_saldo.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_saldo.Name = "vl_saldo";
            this.vl_saldo.NM_Alias = "";
            this.vl_saldo.NM_Campo = "";
            this.vl_saldo.NM_Param = "";
            this.vl_saldo.Operador = "";
            this.vl_saldo.Size = new System.Drawing.Size(101, 20);
            this.vl_saldo.ST_AutoInc = false;
            this.vl_saldo.ST_DisableAuto = false;
            this.vl_saldo.ST_Gravar = false;
            this.vl_saldo.ST_LimparCampo = true;
            this.vl_saldo.ST_NotNull = false;
            this.vl_saldo.ST_PrimaryKey = false;
            this.vl_saldo.TabIndex = 3;
            this.vl_saldo.TabStop = false;
            this.vl_saldo.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(704, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Saldo";
            // 
            // vl_troco
            // 
            this.vl_troco.DecimalPlaces = 2;
            this.vl_troco.Enabled = false;
            this.vl_troco.Location = new System.Drawing.Point(597, 16);
            this.vl_troco.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_troco.Name = "vl_troco";
            this.vl_troco.NM_Alias = "";
            this.vl_troco.NM_Campo = "";
            this.vl_troco.NM_Param = "";
            this.vl_troco.Operador = "";
            this.vl_troco.Size = new System.Drawing.Size(101, 20);
            this.vl_troco.ST_AutoInc = false;
            this.vl_troco.ST_DisableAuto = false;
            this.vl_troco.ST_Gravar = false;
            this.vl_troco.ST_LimparCampo = true;
            this.vl_troco.ST_NotNull = false;
            this.vl_troco.ST_PrimaryKey = false;
            this.vl_troco.TabIndex = 1;
            this.vl_troco.TabStop = false;
            this.vl_troco.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(594, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor Troco";
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados2.Controls.Add(this.gTitulos);
            this.panelDados2.Controls.Add(this.TS_ItensPedido);
            this.panelDados2.Controls.Add(this.bnCheques);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(4, 54);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(813, 417);
            this.panelDados2.TabIndex = 1;
            // 
            // gTitulos
            // 
            this.gTitulos.AllowUserToAddRows = false;
            this.gTitulos.AllowUserToDeleteRows = false;
            this.gTitulos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTitulos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gTitulos.AutoGenerateColumns = false;
            this.gTitulos.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTitulos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTitulos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTitulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gTitulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTitulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nrchequeDataGridViewTextBoxColumn,
            this.dtemissaoDataGridViewTextBoxColumn,
            this.vltituloDataGridViewTextBoxColumn,
            this.dtvenctoDataGridViewTextBoxColumn,
            this.nomecliforDataGridViewTextBoxColumn,
            this.nrcgccpfDataGridViewTextBoxColumn,
            this.foneDataGridViewTextBoxColumn,
            this.cdbancoDataGridViewTextBoxColumn,
            this.dsbancoDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.observacaoDataGridViewTextBoxColumn});
            this.gTitulos.DataSource = this.bsTitulos;
            this.gTitulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTitulos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTitulos.Location = new System.Drawing.Point(0, 25);
            this.gTitulos.Name = "gTitulos";
            this.gTitulos.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTitulos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gTitulos.RowHeadersWidth = 23;
            this.gTitulos.Size = new System.Drawing.Size(809, 363);
            this.gTitulos.TabIndex = 3;
            this.gTitulos.TabStop = false;
            // 
            // nrchequeDataGridViewTextBoxColumn
            // 
            this.nrchequeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrchequeDataGridViewTextBoxColumn.DataPropertyName = "Nr_cheque";
            this.nrchequeDataGridViewTextBoxColumn.HeaderText = "Nº Cheque";
            this.nrchequeDataGridViewTextBoxColumn.Name = "nrchequeDataGridViewTextBoxColumn";
            this.nrchequeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrchequeDataGridViewTextBoxColumn.Width = 84;
            // 
            // dtemissaoDataGridViewTextBoxColumn
            // 
            this.dtemissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaoDataGridViewTextBoxColumn.DataPropertyName = "Dt_emissao";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dtemissaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtemissaoDataGridViewTextBoxColumn.HeaderText = "Dt. Emissão";
            this.dtemissaoDataGridViewTextBoxColumn.Name = "dtemissaoDataGridViewTextBoxColumn";
            this.dtemissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtemissaoDataGridViewTextBoxColumn.Width = 88;
            // 
            // vltituloDataGridViewTextBoxColumn
            // 
            this.vltituloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vltituloDataGridViewTextBoxColumn.DataPropertyName = "Vl_titulo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vltituloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.vltituloDataGridViewTextBoxColumn.HeaderText = "Vl. Titulo";
            this.vltituloDataGridViewTextBoxColumn.Name = "vltituloDataGridViewTextBoxColumn";
            this.vltituloDataGridViewTextBoxColumn.ReadOnly = true;
            this.vltituloDataGridViewTextBoxColumn.Width = 73;
            // 
            // dtvenctoDataGridViewTextBoxColumn
            // 
            this.dtvenctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvenctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_vencto";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.dtvenctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtvenctoDataGridViewTextBoxColumn.HeaderText = "Dt. Vencimento";
            this.dtvenctoDataGridViewTextBoxColumn.Name = "dtvenctoDataGridViewTextBoxColumn";
            this.dtvenctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtvenctoDataGridViewTextBoxColumn.Width = 97;
            // 
            // nomecliforDataGridViewTextBoxColumn
            // 
            this.nomecliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nomecliforDataGridViewTextBoxColumn.DataPropertyName = "Nomeclifor";
            this.nomecliforDataGridViewTextBoxColumn.HeaderText = "Emitente";
            this.nomecliforDataGridViewTextBoxColumn.Name = "nomecliforDataGridViewTextBoxColumn";
            this.nomecliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomecliforDataGridViewTextBoxColumn.Width = 73;
            // 
            // nrcgccpfDataGridViewTextBoxColumn
            // 
            this.nrcgccpfDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrcgccpfDataGridViewTextBoxColumn.DataPropertyName = "Nr_cgccpf";
            this.nrcgccpfDataGridViewTextBoxColumn.HeaderText = "CNPJ/CPF";
            this.nrcgccpfDataGridViewTextBoxColumn.Name = "nrcgccpfDataGridViewTextBoxColumn";
            this.nrcgccpfDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrcgccpfDataGridViewTextBoxColumn.Width = 84;
            // 
            // foneDataGridViewTextBoxColumn
            // 
            this.foneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.foneDataGridViewTextBoxColumn.DataPropertyName = "Fone";
            this.foneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            this.foneDataGridViewTextBoxColumn.Name = "foneDataGridViewTextBoxColumn";
            this.foneDataGridViewTextBoxColumn.ReadOnly = true;
            this.foneDataGridViewTextBoxColumn.Width = 74;
            // 
            // cdbancoDataGridViewTextBoxColumn
            // 
            this.cdbancoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdbancoDataGridViewTextBoxColumn.DataPropertyName = "Cd_banco";
            this.cdbancoDataGridViewTextBoxColumn.HeaderText = "Cd. Banco";
            this.cdbancoDataGridViewTextBoxColumn.Name = "cdbancoDataGridViewTextBoxColumn";
            this.cdbancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdbancoDataGridViewTextBoxColumn.Width = 76;
            // 
            // dsbancoDataGridViewTextBoxColumn
            // 
            this.dsbancoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsbancoDataGridViewTextBoxColumn.DataPropertyName = "Ds_banco";
            this.dsbancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.dsbancoDataGridViewTextBoxColumn.Name = "dsbancoDataGridViewTextBoxColumn";
            this.dsbancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsbancoDataGridViewTextBoxColumn.Width = 63;
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
            // observacaoDataGridViewTextBoxColumn
            // 
            this.observacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.observacaoDataGridViewTextBoxColumn.DataPropertyName = "Observacao";
            this.observacaoDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.observacaoDataGridViewTextBoxColumn.Name = "observacaoDataGridViewTextBoxColumn";
            this.observacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.observacaoDataGridViewTextBoxColumn.Width = 90;
            // 
            // bsTitulos
            // 
            this.bsTitulos.DataSource = typeof(CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo);
            // 
            // TS_ItensPedido
            // 
            this.TS_ItensPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Deleta_Item});
            this.TS_ItensPedido.Location = new System.Drawing.Point(0, 0);
            this.TS_ItensPedido.Name = "TS_ItensPedido";
            this.TS_ItensPedido.Size = new System.Drawing.Size(809, 25);
            this.TS_ItensPedido.TabIndex = 5;
            // 
            // btn_Deleta_Item
            // 
            this.btn_Deleta_Item.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Deleta_Item.Image = ((System.Drawing.Image)(resources.GetObject("btn_Deleta_Item.Image")));
            this.btn_Deleta_Item.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Deleta_Item.Name = "btn_Deleta_Item";
            this.btn_Deleta_Item.Size = new System.Drawing.Size(137, 22);
            this.btn_Deleta_Item.Text = "(CTRL + F12)Excluir";
            this.btn_Deleta_Item.ToolTipText = "Excluir Item Pedido";
            this.btn_Deleta_Item.Click += new System.EventHandler(this.btn_Deleta_Item_Click);
            // 
            // bnCheques
            // 
            this.bnCheques.AddNewItem = null;
            this.bnCheques.BindingSource = this.bsTitulos;
            this.bnCheques.CountItem = this.bindingNavigatorCountItem;
            this.bnCheques.CountItemFormat = "de {0}";
            this.bnCheques.DeleteItem = null;
            this.bnCheques.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnCheques.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnCheques.Location = new System.Drawing.Point(0, 388);
            this.bnCheques.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnCheques.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnCheques.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnCheques.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnCheques.Name = "bnCheques";
            this.bnCheques.PositionItem = this.bindingNavigatorPositionItem;
            this.bnCheques.Size = new System.Drawing.Size(809, 25);
            this.bnCheques.TabIndex = 4;
            this.bnCheques.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Empresa";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_empresa.Location = new System.Drawing.Point(6, 16);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "";
            this.cd_empresa.NM_CampoBusca = "";
            this.cd_empresa.NM_Param = "";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(91, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 7;
            this.cd_empresa.TextOld = null;
            // 
            // TFListaChTroco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 518);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaChTroco";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Cheque Troco";
            this.Load += new System.EventHandler(this.TFListaChTroco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaChTroco_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_troco)).EndInit();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTitulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulos)).EndInit();
            this.TS_ItensPedido.ResumeLayout(false);
            this.TS_ItensPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnCheques)).EndInit();
            this.bnCheques.ResumeLayout(false);
            this.bnCheques.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados1;
        private Componentes.PanelDados panelDados2;
        public System.Windows.Forms.BindingSource bsTitulos;
        private Componentes.DataGridDefault gTitulos;
        private System.Windows.Forms.BindingNavigator bnCheques;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault cmc7;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat vl_saldo;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat vl_troco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip TS_ItensPedido;
        private System.Windows.Forms.ToolStripButton btn_Deleta_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrchequeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtemissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vltituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvenctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomecliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcgccpfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacaoDataGridViewTextBoxColumn;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label4;
    }
}