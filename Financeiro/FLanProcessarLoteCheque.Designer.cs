namespace Financeiro
{
    partial class TFLanProcessarLoteCheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanProcessarLoteCheque));
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
            this.pGrid = new Componentes.PanelDados(this.components);
            this.gCheques = new Componentes.DataGridDefault(this.components);
            this.St_conciliar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nrchequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrlanctochequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vltituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtemissaostringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvenctostringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipotituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomecliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmclifornominalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCheques = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.vl_credito = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.vl_taxa = new Componentes.EditFloat(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.vl_totalchequecompensar = new Componentes.EditFloat(this.components);
            this.DT_Inic = new Componentes.EditData(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_credito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_taxa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totalchequecompensar)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AccessibleDescription = null;
            this.BB_Gravar.AccessibleName = null;
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.BackgroundImage = null;
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AccessibleDescription = null;
            this.BB_Cancelar.AccessibleName = null;
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.BackgroundImage = null;
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.AccessibleDescription = null;
            this.tlpCentral.AccessibleName = null;
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.BackgroundImage = null;
            this.tlpCentral.Controls.Add(this.pGrid, 0, 0);
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Font = null;
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pGrid
            // 
            this.pGrid.AccessibleDescription = null;
            this.pGrid.AccessibleName = null;
            resources.ApplyResources(this.pGrid, "pGrid");
            this.pGrid.BackgroundImage = null;
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGrid.Controls.Add(this.gCheques);
            this.pGrid.Controls.Add(this.bindingNavigator1);
            this.pGrid.Font = null;
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            // 
            // gCheques
            // 
            this.gCheques.AccessibleDescription = null;
            this.gCheques.AccessibleName = null;
            this.gCheques.AllowUserToAddRows = false;
            this.gCheques.AllowUserToDeleteRows = false;
            this.gCheques.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gCheques.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gCheques, "gCheques");
            this.gCheques.AutoGenerateColumns = false;
            this.gCheques.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCheques.BackgroundImage = null;
            this.gCheques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCheques.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCheques.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_conciliar,
            this.nrchequeDataGridViewTextBoxColumn,
            this.nrlanctochequeDataGridViewTextBoxColumn,
            this.vltituloDataGridViewTextBoxColumn,
            this.dtemissaostringDataGridViewTextBoxColumn,
            this.dtvenctostringDataGridViewTextBoxColumn,
            this.cdbancoDataGridViewTextBoxColumn,
            this.dsbancoDataGridViewTextBoxColumn,
            this.tipotituloDataGridViewTextBoxColumn,
            this.nomecliforDataGridViewTextBoxColumn,
            this.nmclifornominalDataGridViewTextBoxColumn});
            this.gCheques.DataSource = this.bsCheques;
            this.gCheques.Font = null;
            this.gCheques.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCheques.Name = "gCheques";
            this.gCheques.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCheques.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gCheques.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gCheques_CellClick);
            // 
            // St_conciliar
            // 
            this.St_conciliar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_conciliar.DataPropertyName = "St_conciliar";
            resources.ApplyResources(this.St_conciliar, "St_conciliar");
            this.St_conciliar.Name = "St_conciliar";
            this.St_conciliar.ReadOnly = true;
            // 
            // nrchequeDataGridViewTextBoxColumn
            // 
            this.nrchequeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrchequeDataGridViewTextBoxColumn.DataPropertyName = "Nr_cheque";
            resources.ApplyResources(this.nrchequeDataGridViewTextBoxColumn, "nrchequeDataGridViewTextBoxColumn");
            this.nrchequeDataGridViewTextBoxColumn.Name = "nrchequeDataGridViewTextBoxColumn";
            this.nrchequeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrlanctochequeDataGridViewTextBoxColumn
            // 
            this.nrlanctochequeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrlanctochequeDataGridViewTextBoxColumn.DataPropertyName = "Nr_lanctocheque";
            resources.ApplyResources(this.nrlanctochequeDataGridViewTextBoxColumn, "nrlanctochequeDataGridViewTextBoxColumn");
            this.nrlanctochequeDataGridViewTextBoxColumn.Name = "nrlanctochequeDataGridViewTextBoxColumn";
            this.nrlanctochequeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vltituloDataGridViewTextBoxColumn
            // 
            this.vltituloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vltituloDataGridViewTextBoxColumn.DataPropertyName = "Vl_titulo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.vltituloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.vltituloDataGridViewTextBoxColumn, "vltituloDataGridViewTextBoxColumn");
            this.vltituloDataGridViewTextBoxColumn.Name = "vltituloDataGridViewTextBoxColumn";
            this.vltituloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtemissaostringDataGridViewTextBoxColumn
            // 
            this.dtemissaostringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaostringDataGridViewTextBoxColumn.DataPropertyName = "Dt_emissaostring";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.dtemissaostringDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dtemissaostringDataGridViewTextBoxColumn, "dtemissaostringDataGridViewTextBoxColumn");
            this.dtemissaostringDataGridViewTextBoxColumn.Name = "dtemissaostringDataGridViewTextBoxColumn";
            this.dtemissaostringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtvenctostringDataGridViewTextBoxColumn
            // 
            this.dtvenctostringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvenctostringDataGridViewTextBoxColumn.DataPropertyName = "Dt_venctostring";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.dtvenctostringDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.dtvenctostringDataGridViewTextBoxColumn, "dtvenctostringDataGridViewTextBoxColumn");
            this.dtvenctostringDataGridViewTextBoxColumn.Name = "dtvenctostringDataGridViewTextBoxColumn";
            this.dtvenctostringDataGridViewTextBoxColumn.ReadOnly = true;
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
            // tipotituloDataGridViewTextBoxColumn
            // 
            this.tipotituloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipotituloDataGridViewTextBoxColumn.DataPropertyName = "Tipo_titulo";
            resources.ApplyResources(this.tipotituloDataGridViewTextBoxColumn, "tipotituloDataGridViewTextBoxColumn");
            this.tipotituloDataGridViewTextBoxColumn.Name = "tipotituloDataGridViewTextBoxColumn";
            this.tipotituloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomecliforDataGridViewTextBoxColumn
            // 
            this.nomecliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nomecliforDataGridViewTextBoxColumn.DataPropertyName = "Nomeclifor";
            resources.ApplyResources(this.nomecliforDataGridViewTextBoxColumn, "nomecliforDataGridViewTextBoxColumn");
            this.nomecliforDataGridViewTextBoxColumn.Name = "nomecliforDataGridViewTextBoxColumn";
            this.nomecliforDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmclifornominalDataGridViewTextBoxColumn
            // 
            this.nmclifornominalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmclifornominalDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor_nominal";
            resources.ApplyResources(this.nmclifornominalDataGridViewTextBoxColumn, "nmclifornominalDataGridViewTextBoxColumn");
            this.nmclifornominalDataGridViewTextBoxColumn.Name = "nmclifornominalDataGridViewTextBoxColumn";
            this.nmclifornominalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsCheques
            // 
            this.bsCheques.DataSource = typeof(CamadaDados.Financeiro.Titulo.TList_RegLanTitulo);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AccessibleDescription = null;
            this.bindingNavigator1.AccessibleName = null;
            this.bindingNavigator1.AddNewItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.BackgroundImage = null;
            this.bindingNavigator1.BindingSource = this.bsCheques;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Font = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.AccessibleDescription = null;
            this.bindingNavigatorCountItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.BackgroundImage = null;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.AccessibleDescription = null;
            this.bindingNavigatorSeparator.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.AccessibleDescription = null;
            this.bindingNavigatorSeparator1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pDados.BackgroundImage = null;
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.vl_credito);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.vl_taxa);
            this.pDados.Controls.Add(this.label12);
            this.pDados.Controls.Add(this.vl_totalchequecompensar);
            this.pDados.Controls.Add(this.DT_Inic);
            this.pDados.Controls.Add(this.label15);
            this.pDados.Font = null;
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // vl_credito
            // 
            this.vl_credito.AccessibleDescription = null;
            this.vl_credito.AccessibleName = null;
            resources.ApplyResources(this.vl_credito, "vl_credito");
            this.vl_credito.DecimalPlaces = 2;
            this.vl_credito.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_credito.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_credito.Name = "vl_credito";
            this.vl_credito.NM_Alias = "";
            this.vl_credito.NM_Campo = "";
            this.vl_credito.NM_Param = "";
            this.vl_credito.Operador = "";
            this.vl_credito.ST_AutoInc = false;
            this.vl_credito.ST_DisableAuto = false;
            this.vl_credito.ST_Gravar = true;
            this.vl_credito.ST_LimparCampo = true;
            this.vl_credito.ST_NotNull = false;
            this.vl_credito.ST_PrimaryKey = false;
            this.vl_credito.ValueChanged += new System.EventHandler(this.vl_credito_ValueChanged);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // vl_taxa
            // 
            this.vl_taxa.AccessibleDescription = null;
            this.vl_taxa.AccessibleName = null;
            resources.ApplyResources(this.vl_taxa, "vl_taxa");
            this.vl_taxa.DecimalPlaces = 2;
            this.vl_taxa.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_taxa.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_taxa.Name = "vl_taxa";
            this.vl_taxa.NM_Alias = "";
            this.vl_taxa.NM_Campo = "";
            this.vl_taxa.NM_Param = "";
            this.vl_taxa.Operador = "";
            this.vl_taxa.ST_AutoInc = false;
            this.vl_taxa.ST_DisableAuto = false;
            this.vl_taxa.ST_Gravar = true;
            this.vl_taxa.ST_LimparCampo = true;
            this.vl_taxa.ST_NotNull = false;
            this.vl_taxa.ST_PrimaryKey = false;
            this.vl_taxa.ValueChanged += new System.EventHandler(this.vl_taxa_ValueChanged);
            // 
            // label12
            // 
            this.label12.AccessibleDescription = null;
            this.label12.AccessibleName = null;
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // vl_totalchequecompensar
            // 
            this.vl_totalchequecompensar.AccessibleDescription = null;
            this.vl_totalchequecompensar.AccessibleName = null;
            resources.ApplyResources(this.vl_totalchequecompensar, "vl_totalchequecompensar");
            this.vl_totalchequecompensar.DecimalPlaces = 2;
            this.vl_totalchequecompensar.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_totalchequecompensar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_totalchequecompensar.Name = "vl_totalchequecompensar";
            this.vl_totalchequecompensar.NM_Alias = "";
            this.vl_totalchequecompensar.NM_Campo = "";
            this.vl_totalchequecompensar.NM_Param = "";
            this.vl_totalchequecompensar.Operador = "";
            this.vl_totalchequecompensar.ReadOnly = true;
            this.vl_totalchequecompensar.ST_AutoInc = false;
            this.vl_totalchequecompensar.ST_DisableAuto = false;
            this.vl_totalchequecompensar.ST_Gravar = true;
            this.vl_totalchequecompensar.ST_LimparCampo = true;
            this.vl_totalchequecompensar.ST_NotNull = false;
            this.vl_totalchequecompensar.ST_PrimaryKey = false;
            this.vl_totalchequecompensar.TabStop = false;
            // 
            // DT_Inic
            // 
            this.DT_Inic.AccessibleDescription = null;
            this.DT_Inic.AccessibleName = null;
            resources.ApplyResources(this.DT_Inic, "DT_Inic");
            this.DT_Inic.BackgroundImage = null;
            this.DT_Inic.Font = null;
            this.DT_Inic.Name = "DT_Inic";
            this.DT_Inic.NM_Alias = "";
            this.DT_Inic.NM_Campo = "DT_NascFirma";
            this.DT_Inic.NM_CampoBusca = "DT_NascFirma";
            this.DT_Inic.NM_Param = "@P_DT_NASCIMENTO";
            this.DT_Inic.Operador = "";
            this.DT_Inic.ST_Gravar = true;
            this.DT_Inic.ST_LimpaCampo = true;
            this.DT_Inic.ST_NotNull = false;
            this.DT_Inic.ST_PrimaryKey = false;
            // 
            // label15
            // 
            this.label15.AccessibleDescription = null;
            this.label15.AccessibleName = null;
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // TFLanProcessarLoteCheque
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanProcessarLoteCheque";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanProcessarLoteCheque_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanProcessarLoteCheque_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanProcessarLoteCheque_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_credito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_taxa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totalchequecompensar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pGrid;
        private System.Windows.Forms.BindingSource bsCheques;
        private Componentes.DataGridDefault gCheques;
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
        private Componentes.EditData DT_Inic;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private Componentes.EditFloat vl_totalchequecompensar;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat vl_credito;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat vl_taxa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_conciliar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrchequeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrlanctochequeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vltituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtemissaostringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvenctostringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipotituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomecliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmclifornominalDataGridViewTextBoxColumn;
    }
}