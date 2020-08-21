namespace Financeiro.Cadastros
{
    partial class TFCadCotacaoMoeda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCotacaoMoeda));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.cdmoedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmoedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdmoedaresultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmoedaresultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCotacao = new System.Windows.Forms.BindingSource(this.components);
            this.LB_CD_Moeda = new System.Windows.Forms.Label();
            this.LB_Data = new System.Windows.Forms.Label();
            this.LB_CD_moedaResult = new System.Windows.Forms.Label();
            this.LB_Valor = new System.Windows.Forms.Label();
            this.CD_Moeda = new Componentes.EditDefault(this.components);
            this.CD_moedaResult = new Componentes.EditDefault(this.components);
            this.valor = new Componentes.EditFloat(this.components);
            this.bb_moedaresult = new System.Windows.Forms.Button();
            this.ds_moeda = new Componentes.EditDefault(this.components);
            this.ds_moedaresult = new Componentes.EditDefault(this.components);
            this.bb_moeda = new System.Windows.Forms.Button();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.op = new Componentes.ComboBoxDefault(this.components);
            this.data = new Componentes.EditData(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCotacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.data);
            this.pDados.Controls.Add(this.op);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_moedaresult);
            this.pDados.Controls.Add(this.ds_moeda);
            this.pDados.Controls.Add(this.bb_moedaresult);
            this.pDados.Controls.Add(this.bb_moeda);
            this.pDados.Controls.Add(this.valor);
            this.pDados.Controls.Add(this.LB_CD_Moeda);
            this.pDados.Controls.Add(this.LB_Data);
            this.pDados.Controls.Add(this.LB_CD_moedaResult);
            this.pDados.Controls.Add(this.LB_Valor);
            this.pDados.Controls.Add(this.CD_Moeda);
            this.pDados.Controls.Add(this.CD_moedaResult);
            this.pDados.Font = null;
            this.pDados.NM_ProcDeletar = "EXCLUI_FIN_COTACAOMOEDA";
            this.pDados.NM_ProcGravar = "IA_FIN_COTACAOMOEDA";
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            this.tcCentral.Font = null;
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // gCadastro
            // 
            this.gCadastro.AccessibleDescription = null;
            this.gCadastro.AccessibleName = null;
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BackgroundImage = null;
            this.gCadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdmoedaDataGridViewTextBoxColumn,
            this.dsmoedaDataGridViewTextBoxColumn,
            this.cdmoedaresultDataGridViewTextBoxColumn,
            this.dsmoedaresultDataGridViewTextBoxColumn,
            this.datastrDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.opDataGridViewTextBoxColumn});
            this.gCadastro.DataSource = this.bsCotacao;
            this.gCadastro.Font = null;
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gCadastro.TabStop = false;
            // 
            // cdmoedaDataGridViewTextBoxColumn
            // 
            this.cdmoedaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdmoedaDataGridViewTextBoxColumn.DataPropertyName = "Cd_moeda";
            resources.ApplyResources(this.cdmoedaDataGridViewTextBoxColumn, "cdmoedaDataGridViewTextBoxColumn");
            this.cdmoedaDataGridViewTextBoxColumn.Name = "cdmoedaDataGridViewTextBoxColumn";
            this.cdmoedaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsmoedaDataGridViewTextBoxColumn
            // 
            this.dsmoedaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmoedaDataGridViewTextBoxColumn.DataPropertyName = "Ds_moeda";
            resources.ApplyResources(this.dsmoedaDataGridViewTextBoxColumn, "dsmoedaDataGridViewTextBoxColumn");
            this.dsmoedaDataGridViewTextBoxColumn.Name = "dsmoedaDataGridViewTextBoxColumn";
            this.dsmoedaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdmoedaresultDataGridViewTextBoxColumn
            // 
            this.cdmoedaresultDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdmoedaresultDataGridViewTextBoxColumn.DataPropertyName = "Cd_moedaresult";
            resources.ApplyResources(this.cdmoedaresultDataGridViewTextBoxColumn, "cdmoedaresultDataGridViewTextBoxColumn");
            this.cdmoedaresultDataGridViewTextBoxColumn.Name = "cdmoedaresultDataGridViewTextBoxColumn";
            this.cdmoedaresultDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsmoedaresultDataGridViewTextBoxColumn
            // 
            this.dsmoedaresultDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmoedaresultDataGridViewTextBoxColumn.DataPropertyName = "Ds_moedaresult";
            resources.ApplyResources(this.dsmoedaresultDataGridViewTextBoxColumn, "dsmoedaresultDataGridViewTextBoxColumn");
            this.dsmoedaresultDataGridViewTextBoxColumn.Name = "dsmoedaresultDataGridViewTextBoxColumn";
            this.dsmoedaresultDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // datastrDataGridViewTextBoxColumn
            // 
            this.datastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.datastrDataGridViewTextBoxColumn.DataPropertyName = "Datastr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.datastrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.datastrDataGridViewTextBoxColumn, "datastrDataGridViewTextBoxColumn");
            this.datastrDataGridViewTextBoxColumn.Name = "datastrDataGridViewTextBoxColumn";
            this.datastrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            resources.ApplyResources(this.valorDataGridViewTextBoxColumn, "valorDataGridViewTextBoxColumn");
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // opDataGridViewTextBoxColumn
            // 
            this.opDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.opDataGridViewTextBoxColumn.DataPropertyName = "Op";
            resources.ApplyResources(this.opDataGridViewTextBoxColumn, "opDataGridViewTextBoxColumn");
            this.opDataGridViewTextBoxColumn.Name = "opDataGridViewTextBoxColumn";
            this.opDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsCotacao
            // 
            this.bsCotacao.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CotacaoMoeda);
            // 
            // LB_CD_Moeda
            // 
            this.LB_CD_Moeda.AccessibleDescription = null;
            this.LB_CD_Moeda.AccessibleName = null;
            resources.ApplyResources(this.LB_CD_Moeda, "LB_CD_Moeda");
            this.LB_CD_Moeda.Name = "LB_CD_Moeda";
            // 
            // LB_Data
            // 
            this.LB_Data.AccessibleDescription = null;
            this.LB_Data.AccessibleName = null;
            resources.ApplyResources(this.LB_Data, "LB_Data");
            this.LB_Data.Name = "LB_Data";
            // 
            // LB_CD_moedaResult
            // 
            this.LB_CD_moedaResult.AccessibleDescription = null;
            this.LB_CD_moedaResult.AccessibleName = null;
            resources.ApplyResources(this.LB_CD_moedaResult, "LB_CD_moedaResult");
            this.LB_CD_moedaResult.Name = "LB_CD_moedaResult";
            // 
            // LB_Valor
            // 
            this.LB_Valor.AccessibleDescription = null;
            this.LB_Valor.AccessibleName = null;
            resources.ApplyResources(this.LB_Valor, "LB_Valor");
            this.LB_Valor.Name = "LB_Valor";
            // 
            // CD_Moeda
            // 
            this.CD_Moeda.AccessibleDescription = null;
            this.CD_Moeda.AccessibleName = null;
            resources.ApplyResources(this.CD_Moeda, "CD_Moeda");
            this.CD_Moeda.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Moeda.BackgroundImage = null;
            this.CD_Moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Moeda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCotacao, "Cd_moeda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Moeda.Font = null;
            this.CD_Moeda.Name = "CD_Moeda";
            this.CD_Moeda.NM_Alias = "a";
            this.CD_Moeda.NM_Campo = "CD_Moeda";
            this.CD_Moeda.NM_CampoBusca = "CD_Moeda";
            this.CD_Moeda.NM_Param = "@P_CD_MOEDA";
            this.CD_Moeda.QTD_Zero = 0;
            this.CD_Moeda.ST_AutoInc = false;
            this.CD_Moeda.ST_DisableAuto = false;
            this.CD_Moeda.ST_Float = false;
            this.CD_Moeda.ST_Gravar = true;
            this.CD_Moeda.ST_Int = false;
            this.CD_Moeda.ST_LimpaCampo = true;
            this.CD_Moeda.ST_NotNull = true;
            this.CD_Moeda.ST_PrimaryKey = true;
            this.CD_Moeda.Leave += new System.EventHandler(this.CD_Moeda_Leave);
            // 
            // CD_moedaResult
            // 
            this.CD_moedaResult.AccessibleDescription = null;
            this.CD_moedaResult.AccessibleName = null;
            resources.ApplyResources(this.CD_moedaResult, "CD_moedaResult");
            this.CD_moedaResult.BackColor = System.Drawing.SystemColors.Window;
            this.CD_moedaResult.BackgroundImage = null;
            this.CD_moedaResult.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_moedaResult.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCotacao, "Cd_moedaresult", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_moedaResult.Font = null;
            this.CD_moedaResult.Name = "CD_moedaResult";
            this.CD_moedaResult.NM_Alias = "";
            this.CD_moedaResult.NM_Campo = "CD_moedaResult";
            this.CD_moedaResult.NM_CampoBusca = "CD_moeda";
            this.CD_moedaResult.NM_Param = "@P_CD_MOEDARESULT";
            this.CD_moedaResult.QTD_Zero = 0;
            this.CD_moedaResult.ST_AutoInc = false;
            this.CD_moedaResult.ST_DisableAuto = false;
            this.CD_moedaResult.ST_Float = false;
            this.CD_moedaResult.ST_Gravar = true;
            this.CD_moedaResult.ST_Int = false;
            this.CD_moedaResult.ST_LimpaCampo = true;
            this.CD_moedaResult.ST_NotNull = true;
            this.CD_moedaResult.ST_PrimaryKey = true;
            this.CD_moedaResult.Leave += new System.EventHandler(this.CD_moedaResult_Leave);
            // 
            // valor
            // 
            this.valor.AccessibleDescription = null;
            this.valor.AccessibleName = null;
            resources.ApplyResources(this.valor, "valor");
            this.valor.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCotacao, "Valor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.valor.DecimalPlaces = 5;
            this.valor.Font = null;
            this.valor.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.valor.Name = "valor";
            this.valor.NM_Alias = "a";
            this.valor.NM_Campo = "valor";
            this.valor.NM_Param = "@P_VALOR";
            this.valor.Operador = "";
            this.valor.ST_AutoInc = false;
            this.valor.ST_DisableAuto = false;
            this.valor.ST_Gravar = true;
            this.valor.ST_LimparCampo = true;
            this.valor.ST_NotNull = false;
            this.valor.ST_PrimaryKey = false;
            // 
            // bb_moedaresult
            // 
            this.bb_moedaresult.AccessibleDescription = null;
            this.bb_moedaresult.AccessibleName = null;
            resources.ApplyResources(this.bb_moedaresult, "bb_moedaresult");
            this.bb_moedaresult.BackgroundImage = null;
            this.bb_moedaresult.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_moedaresult.Font = null;
            this.bb_moedaresult.Name = "bb_moedaresult";
            this.bb_moedaresult.UseVisualStyleBackColor = true;
            this.bb_moedaresult.Click += new System.EventHandler(this.bb_moedaresult_Click);
            // 
            // ds_moeda
            // 
            this.ds_moeda.AccessibleDescription = null;
            this.ds_moeda.AccessibleName = null;
            resources.ApplyResources(this.ds_moeda, "ds_moeda");
            this.ds_moeda.BackColor = System.Drawing.SystemColors.Window;
            this.ds_moeda.BackgroundImage = null;
            this.ds_moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_moeda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCotacao, "Ds_moeda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_moeda.Font = null;
            this.ds_moeda.Name = "ds_moeda";
            this.ds_moeda.NM_Alias = "";
            this.ds_moeda.NM_Campo = "ds_moeda";
            this.ds_moeda.NM_CampoBusca = "ds_moeda_singular";
            this.ds_moeda.NM_Param = "@P_DS_MOEDA_SINGULAR";
            this.ds_moeda.QTD_Zero = 0;
            this.ds_moeda.ST_AutoInc = false;
            this.ds_moeda.ST_DisableAuto = false;
            this.ds_moeda.ST_Float = false;
            this.ds_moeda.ST_Gravar = false;
            this.ds_moeda.ST_Int = false;
            this.ds_moeda.ST_LimpaCampo = true;
            this.ds_moeda.ST_NotNull = false;
            this.ds_moeda.ST_PrimaryKey = false;
            // 
            // ds_moedaresult
            // 
            this.ds_moedaresult.AccessibleDescription = null;
            this.ds_moedaresult.AccessibleName = null;
            resources.ApplyResources(this.ds_moedaresult, "ds_moedaresult");
            this.ds_moedaresult.BackColor = System.Drawing.SystemColors.Window;
            this.ds_moedaresult.BackgroundImage = null;
            this.ds_moedaresult.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_moedaresult.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCotacao, "Ds_moedaresult", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_moedaresult.Font = null;
            this.ds_moedaresult.Name = "ds_moedaresult";
            this.ds_moedaresult.NM_Alias = "";
            this.ds_moedaresult.NM_Campo = "ds_moedaresult";
            this.ds_moedaresult.NM_CampoBusca = "ds_moeda_singular";
            this.ds_moedaresult.NM_Param = "@P_DS_MOEDARESULT";
            this.ds_moedaresult.QTD_Zero = 0;
            this.ds_moedaresult.ST_AutoInc = false;
            this.ds_moedaresult.ST_DisableAuto = false;
            this.ds_moedaresult.ST_Float = false;
            this.ds_moedaresult.ST_Gravar = false;
            this.ds_moedaresult.ST_Int = false;
            this.ds_moedaresult.ST_LimpaCampo = true;
            this.ds_moedaresult.ST_NotNull = false;
            this.ds_moedaresult.ST_PrimaryKey = false;
            // 
            // bb_moeda
            // 
            this.bb_moeda.AccessibleDescription = null;
            this.bb_moeda.AccessibleName = null;
            resources.ApplyResources(this.bb_moeda, "bb_moeda");
            this.bb_moeda.BackgroundImage = null;
            this.bb_moeda.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_moeda.Font = null;
            this.bb_moeda.Name = "bb_moeda";
            this.bb_moeda.UseVisualStyleBackColor = true;
            this.bb_moeda.Click += new System.EventHandler(this.bb_moeda_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AccessibleDescription = null;
            this.bindingNavigator1.AccessibleName = null;
            this.bindingNavigator1.AddNewItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.BackgroundImage = null;
            this.bindingNavigator1.BindingSource = this.bsCotacao;
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
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // op
            // 
            this.op.AccessibleDescription = null;
            this.op.AccessibleName = null;
            resources.ApplyResources(this.op, "op");
            this.op.BackgroundImage = null;
            this.op.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCotacao, "Op", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.op.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.op.Font = null;
            this.op.FormattingEnabled = true;
            this.op.Name = "op";
            this.op.NM_Alias = "";
            this.op.NM_Campo = "";
            this.op.NM_Param = "";
            this.op.ST_Gravar = true;
            this.op.ST_LimparCampo = true;
            this.op.ST_NotNull = true;
            // 
            // data
            // 
            this.data.AccessibleDescription = null;
            this.data.AccessibleName = null;
            resources.ApplyResources(this.data, "data");
            this.data.BackgroundImage = null;
            this.data.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCotacao, "Datastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "d"));
            this.data.Font = null;
            this.data.Name = "data";
            this.data.NM_Alias = "";
            this.data.NM_Campo = "";
            this.data.NM_CampoBusca = "";
            this.data.NM_Param = "";
            this.data.Operador = "";
            this.data.ST_Gravar = true;
            this.data.ST_LimpaCampo = true;
            this.data.ST_NotNull = true;
            this.data.ST_PrimaryKey = false;
            // 
            // TFCadCotacaoMoeda
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadCotacaoMoeda";
            this.Load += new System.EventHandler(this.TFCadCotacaoMoeda_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCotacaoMoeda_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCotacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label LB_CD_Moeda;
        private System.Windows.Forms.Label LB_Data;
        private System.Windows.Forms.Label LB_CD_moedaResult;
        private System.Windows.Forms.Label LB_Valor;
        private Componentes.EditDefault CD_Moeda;
        private Componentes.EditDefault CD_moedaResult;
        private Componentes.EditFloat valor;
        private Componentes.EditDefault ds_moedaresult;
        private Componentes.EditDefault ds_moeda;
        public System.Windows.Forms.Button bb_moedaresult;
        public System.Windows.Forms.Button bb_moeda;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.BindingSource bsCotacao;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.ComboBoxDefault op;
        private System.Windows.Forms.Label label1;
        private Componentes.EditData data;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdmoedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmoedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdmoedaresultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmoedaresultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn opDataGridViewTextBoxColumn;
    }
}
