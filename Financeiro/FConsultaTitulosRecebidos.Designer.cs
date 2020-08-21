namespace Financeiro
{
    partial class TFConsultaTitulosRecebidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFConsultaTitulosRecebidos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pConciliacao = new Componentes.PanelDados(this.components);
            this.Vl_Saldo = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Vl_TotalTitulo = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Vl_SD_Conciliar = new Componentes.EditFloat(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.lblConciliacao = new System.Windows.Forms.Label();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.gTitulos = new Componentes.DataGridDefault(this.components);
            this.stconciliarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nrlanctochequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.BB_Localizar = new System.Windows.Forms.Button();
            this.nr_cheque = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bnCheques = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pConciliacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Saldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_TotalTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_SD_Conciliar)).BeginInit();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTitulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulos)).BeginInit();
            this.pFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnCheques)).BeginInit();
            this.bnCheques.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.pConciliacao, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pGrid, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // pConciliacao
            // 
            this.pConciliacao.BackColor = System.Drawing.Color.Transparent;
            this.pConciliacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pConciliacao.Controls.Add(this.Vl_Saldo);
            this.pConciliacao.Controls.Add(this.label2);
            this.pConciliacao.Controls.Add(this.Vl_TotalTitulo);
            this.pConciliacao.Controls.Add(this.label1);
            this.pConciliacao.Controls.Add(this.Vl_SD_Conciliar);
            this.pConciliacao.Controls.Add(this.label10);
            this.pConciliacao.Controls.Add(this.lblConciliacao);
            resources.ApplyResources(this.pConciliacao, "pConciliacao");
            this.pConciliacao.Name = "pConciliacao";
            this.pConciliacao.NM_ProcDeletar = "";
            this.pConciliacao.NM_ProcGravar = "";
            // 
            // Vl_Saldo
            // 
            this.Vl_Saldo.DecimalPlaces = 2;
            resources.ApplyResources(this.Vl_Saldo, "Vl_Saldo");
            this.Vl_Saldo.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.Vl_Saldo.Minimum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            -2147483648});
            this.Vl_Saldo.Name = "Vl_Saldo";
            this.Vl_Saldo.NM_Alias = "";
            this.Vl_Saldo.NM_Campo = "";
            this.Vl_Saldo.NM_Param = "";
            this.Vl_Saldo.Operador = "";
            this.Vl_Saldo.ST_AutoInc = false;
            this.Vl_Saldo.ST_DisableAuto = false;
            this.Vl_Saldo.ST_Gravar = false;
            this.Vl_Saldo.ST_LimparCampo = true;
            this.Vl_Saldo.ST_NotNull = false;
            this.Vl_Saldo.ST_PrimaryKey = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Name = "label2";
            // 
            // Vl_TotalTitulo
            // 
            this.Vl_TotalTitulo.DecimalPlaces = 2;
            resources.ApplyResources(this.Vl_TotalTitulo, "Vl_TotalTitulo");
            this.Vl_TotalTitulo.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.Vl_TotalTitulo.Name = "Vl_TotalTitulo";
            this.Vl_TotalTitulo.NM_Alias = "";
            this.Vl_TotalTitulo.NM_Campo = "";
            this.Vl_TotalTitulo.NM_Param = "";
            this.Vl_TotalTitulo.Operador = "";
            this.Vl_TotalTitulo.ST_AutoInc = false;
            this.Vl_TotalTitulo.ST_DisableAuto = false;
            this.Vl_TotalTitulo.ST_Gravar = false;
            this.Vl_TotalTitulo.ST_LimparCampo = true;
            this.Vl_TotalTitulo.ST_NotNull = false;
            this.Vl_TotalTitulo.ST_PrimaryKey = false;
            this.Vl_TotalTitulo.ValueChanged += new System.EventHandler(this.Vl_TotalTitulo_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Name = "label1";
            // 
            // Vl_SD_Conciliar
            // 
            this.Vl_SD_Conciliar.DecimalPlaces = 2;
            resources.ApplyResources(this.Vl_SD_Conciliar, "Vl_SD_Conciliar");
            this.Vl_SD_Conciliar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.Vl_SD_Conciliar.Name = "Vl_SD_Conciliar";
            this.Vl_SD_Conciliar.NM_Alias = "";
            this.Vl_SD_Conciliar.NM_Campo = "";
            this.Vl_SD_Conciliar.NM_Param = "";
            this.Vl_SD_Conciliar.Operador = "";
            this.Vl_SD_Conciliar.ST_AutoInc = false;
            this.Vl_SD_Conciliar.ST_DisableAuto = false;
            this.Vl_SD_Conciliar.ST_Gravar = false;
            this.Vl_SD_Conciliar.ST_LimparCampo = true;
            this.Vl_SD_Conciliar.ST_NotNull = false;
            this.Vl_SD_Conciliar.ST_PrimaryKey = false;
            this.Vl_SD_Conciliar.ValueChanged += new System.EventHandler(this.Vl_SD_Conciliar_ValueChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Name = "label10";
            // 
            // lblConciliacao
            // 
            this.lblConciliacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.lblConciliacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblConciliacao, "lblConciliacao");
            this.lblConciliacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblConciliacao.ForeColor = System.Drawing.Color.White;
            this.lblConciliacao.Name = "lblConciliacao";
            // 
            // pGrid
            // 
            resources.ApplyResources(this.pGrid, "pGrid");
            this.pGrid.BackColor = System.Drawing.SystemColors.Control;
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pGrid.Controls.Add(this.gTitulos);
            this.pGrid.Controls.Add(this.pFiltro);
            this.pGrid.Controls.Add(this.bnCheques);
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
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
            this.stconciliarDataGridViewCheckBoxColumn,
            this.nrlanctochequeDataGridViewTextBoxColumn,
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
            resources.ApplyResources(this.gTitulos, "gTitulos");
            this.gTitulos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
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
            this.gTitulos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gTitulos_ColumnHeaderMouseClick);
            this.gTitulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gTitulos_CellClick);
            // 
            // stconciliarDataGridViewCheckBoxColumn
            // 
            this.stconciliarDataGridViewCheckBoxColumn.DataPropertyName = "St_conciliar";
            resources.ApplyResources(this.stconciliarDataGridViewCheckBoxColumn, "stconciliarDataGridViewCheckBoxColumn");
            this.stconciliarDataGridViewCheckBoxColumn.Name = "stconciliarDataGridViewCheckBoxColumn";
            this.stconciliarDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // nrlanctochequeDataGridViewTextBoxColumn
            // 
            this.nrlanctochequeDataGridViewTextBoxColumn.DataPropertyName = "Nr_lanctocheque";
            resources.ApplyResources(this.nrlanctochequeDataGridViewTextBoxColumn, "nrlanctochequeDataGridViewTextBoxColumn");
            this.nrlanctochequeDataGridViewTextBoxColumn.Name = "nrlanctochequeDataGridViewTextBoxColumn";
            this.nrlanctochequeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrchequeDataGridViewTextBoxColumn
            // 
            this.nrchequeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrchequeDataGridViewTextBoxColumn.DataPropertyName = "Nr_cheque";
            resources.ApplyResources(this.nrchequeDataGridViewTextBoxColumn, "nrchequeDataGridViewTextBoxColumn");
            this.nrchequeDataGridViewTextBoxColumn.Name = "nrchequeDataGridViewTextBoxColumn";
            this.nrchequeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtemissaoDataGridViewTextBoxColumn
            // 
            this.dtemissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaoDataGridViewTextBoxColumn.DataPropertyName = "Dt_emissao";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dtemissaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dtemissaoDataGridViewTextBoxColumn, "dtemissaoDataGridViewTextBoxColumn");
            this.dtemissaoDataGridViewTextBoxColumn.Name = "dtemissaoDataGridViewTextBoxColumn";
            this.dtemissaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vltituloDataGridViewTextBoxColumn
            // 
            this.vltituloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vltituloDataGridViewTextBoxColumn.DataPropertyName = "Vl_titulo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vltituloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.vltituloDataGridViewTextBoxColumn, "vltituloDataGridViewTextBoxColumn");
            this.vltituloDataGridViewTextBoxColumn.Name = "vltituloDataGridViewTextBoxColumn";
            this.vltituloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtvenctoDataGridViewTextBoxColumn
            // 
            this.dtvenctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvenctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_vencto";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.dtvenctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.dtvenctoDataGridViewTextBoxColumn, "dtvenctoDataGridViewTextBoxColumn");
            this.dtvenctoDataGridViewTextBoxColumn.Name = "dtvenctoDataGridViewTextBoxColumn";
            this.dtvenctoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomecliforDataGridViewTextBoxColumn
            // 
            this.nomecliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nomecliforDataGridViewTextBoxColumn.DataPropertyName = "Nomeclifor";
            resources.ApplyResources(this.nomecliforDataGridViewTextBoxColumn, "nomecliforDataGridViewTextBoxColumn");
            this.nomecliforDataGridViewTextBoxColumn.Name = "nomecliforDataGridViewTextBoxColumn";
            this.nomecliforDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrcgccpfDataGridViewTextBoxColumn
            // 
            this.nrcgccpfDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrcgccpfDataGridViewTextBoxColumn.DataPropertyName = "Nr_cgccpf";
            resources.ApplyResources(this.nrcgccpfDataGridViewTextBoxColumn, "nrcgccpfDataGridViewTextBoxColumn");
            this.nrcgccpfDataGridViewTextBoxColumn.Name = "nrcgccpfDataGridViewTextBoxColumn";
            this.nrcgccpfDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // foneDataGridViewTextBoxColumn
            // 
            this.foneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.foneDataGridViewTextBoxColumn.DataPropertyName = "Fone";
            resources.ApplyResources(this.foneDataGridViewTextBoxColumn, "foneDataGridViewTextBoxColumn");
            this.foneDataGridViewTextBoxColumn.Name = "foneDataGridViewTextBoxColumn";
            this.foneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdbancoDataGridViewTextBoxColumn
            // 
            this.cdbancoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdbancoDataGridViewTextBoxColumn.DataPropertyName = "Cd_banco";
            resources.ApplyResources(this.cdbancoDataGridViewTextBoxColumn, "cdbancoDataGridViewTextBoxColumn");
            this.cdbancoDataGridViewTextBoxColumn.Name = "cdbancoDataGridViewTextBoxColumn";
            this.cdbancoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsbancoDataGridViewTextBoxColumn
            // 
            this.dsbancoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsbancoDataGridViewTextBoxColumn.DataPropertyName = "Ds_banco";
            resources.ApplyResources(this.dsbancoDataGridViewTextBoxColumn, "dsbancoDataGridViewTextBoxColumn");
            this.dsbancoDataGridViewTextBoxColumn.Name = "dsbancoDataGridViewTextBoxColumn";
            this.dsbancoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            resources.ApplyResources(this.cdempresaDataGridViewTextBoxColumn, "cdempresaDataGridViewTextBoxColumn");
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            resources.ApplyResources(this.nmempresaDataGridViewTextBoxColumn, "nmempresaDataGridViewTextBoxColumn");
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observacaoDataGridViewTextBoxColumn
            // 
            this.observacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.observacaoDataGridViewTextBoxColumn.DataPropertyName = "Observacao";
            resources.ApplyResources(this.observacaoDataGridViewTextBoxColumn, "observacaoDataGridViewTextBoxColumn");
            this.observacaoDataGridViewTextBoxColumn.Name = "observacaoDataGridViewTextBoxColumn";
            this.observacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsTitulos
            // 
            this.bsTitulos.DataSource = typeof(CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo);
            // 
            // pFiltro
            // 
            this.pFiltro.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.BB_Localizar);
            this.pFiltro.Controls.Add(this.nr_cheque);
            this.pFiltro.Controls.Add(this.label3);
            resources.ApplyResources(this.pFiltro, "pFiltro");
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            // 
            // BB_Localizar
            // 
            this.BB_Localizar.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Localizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BB_Localizar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.BB_Localizar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BB_Localizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(207)))), ((int)(((byte)(169)))));
            resources.ApplyResources(this.BB_Localizar, "BB_Localizar");
            this.BB_Localizar.ForeColor = System.Drawing.Color.Green;
            this.BB_Localizar.Name = "BB_Localizar";
            this.BB_Localizar.UseVisualStyleBackColor = false;
            this.BB_Localizar.Click += new System.EventHandler(this.BB_Localizar_Click);
            // 
            // nr_cheque
            // 
            this.nr_cheque.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_cheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.nr_cheque, "nr_cheque");
            this.nr_cheque.Name = "nr_cheque";
            this.nr_cheque.NM_Alias = "";
            this.nr_cheque.NM_Campo = "";
            this.nr_cheque.NM_CampoBusca = "";
            this.nr_cheque.NM_Param = "";
            this.nr_cheque.QTD_Zero = 0;
            this.nr_cheque.ST_AutoInc = false;
            this.nr_cheque.ST_DisableAuto = false;
            this.nr_cheque.ST_Float = false;
            this.nr_cheque.ST_Gravar = false;
            this.nr_cheque.ST_Int = false;
            this.nr_cheque.ST_LimpaCampo = true;
            this.nr_cheque.ST_NotNull = false;
            this.nr_cheque.ST_PrimaryKey = false;
            this.nr_cheque.TextOld = null;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // bnCheques
            // 
            this.bnCheques.AddNewItem = null;
            this.bnCheques.BindingSource = this.bsTitulos;
            this.bnCheques.CountItem = this.bindingNavigatorCountItem;
            this.bnCheques.CountItemFormat = "de {0}";
            this.bnCheques.DeleteItem = null;
            resources.ApplyResources(this.bnCheques, "bnCheques");
            this.bnCheques.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnCheques.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnCheques.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnCheques.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnCheques.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnCheques.Name = "bnCheques";
            this.bnCheques.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // TFConsultaTitulosRecebidos
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFConsultaTitulosRecebidos";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFConsultaTitulosRecebidos_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFConsultaTitulosRecebidos_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFConsultaTitulosRecebidos_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pConciliacao.ResumeLayout(false);
            this.pConciliacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Saldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_TotalTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_SD_Conciliar)).EndInit();
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTitulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulos)).EndInit();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados pGrid;
        private Componentes.PanelDados pConciliacao;
        private System.Windows.Forms.Label lblConciliacao;
        private Componentes.EditFloat Vl_SD_Conciliar;
        private System.Windows.Forms.Label label10;
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
        public System.Windows.Forms.BindingSource bsTitulos;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados pFiltro;
        private Componentes.EditFloat Vl_Saldo;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nr_cheque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BB_Localizar;
        public Componentes.EditFloat Vl_TotalTitulo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stconciliarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrlanctochequeDataGridViewTextBoxColumn;
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
    }
}