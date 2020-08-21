namespace Financeiro
{
    partial class TFLan_FechamentoCaixa
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
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLan_FechamentoCaixa));
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label dt_fechamentostringLabel;
            System.Windows.Forms.Label vl_atualLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pCentral = new Componentes.PanelDados(this.components);
            this.VL_SaldoLiquido = new Componentes.EditFloat(this.components);
            this.bsFechamentoCaixa = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Tot_Ch_PAG = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.Tot_Ch_REC = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.vl_anterior = new Componentes.EditFloat(this.components);
            this.dt_ultimofechamento = new Componentes.EditData(this.components);
            this.dt_fechamento = new Componentes.EditData(this.components);
            this.vl_atual = new Componentes.EditFloat(this.components);
            this.pFiltros = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.dtfechamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlanteriorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlatualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcontagerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscontagerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsListaFechamentos = new System.Windows.Forms.BindingSource(this.components);
            this.DS_ContaGer = new Componentes.EditDefault(this.components);
            this.CD_ContaGer = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            dt_fechamentostringLabel = new System.Windows.Forms.Label();
            vl_atualLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_SaldoLiquido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFechamentoCaixa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tot_Ch_PAG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tot_Ch_REC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_anterior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_atual)).BeginInit();
            this.pFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListaFechamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // dt_fechamentostringLabel
            // 
            resources.ApplyResources(dt_fechamentostringLabel, "dt_fechamentostringLabel");
            dt_fechamentostringLabel.Name = "dt_fechamentostringLabel";
            // 
            // vl_atualLabel
            // 
            resources.ApplyResources(vl_atualLabel, "vl_atualLabel");
            vl_atualLabel.Name = "vl_atualLabel";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Excluir,
            this.BB_Imprimir});
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
            // BB_Excluir
            // 
            resources.ApplyResources(this.BB_Excluir, "BB_Excluir");
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
            // 
            // BB_Imprimir
            // 
            resources.ApplyResources(this.BB_Imprimir, "BB_Imprimir");
            this.BB_Imprimir.ForeColor = System.Drawing.Color.Green;
            this.BB_Imprimir.Name = "BB_Imprimir";
            this.BB_Imprimir.Click += new System.EventHandler(this.BB_Imprimir_Click);
            // 
            // tlpCentral
            // 
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.Controls.Add(this.pCentral, 0, 1);
            this.tlpCentral.Controls.Add(this.pFiltros, 0, 0);
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pCentral
            // 
            resources.ApplyResources(this.pCentral, "pCentral");
            this.pCentral.BackColor = System.Drawing.SystemColors.Control;
            this.pCentral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCentral.Controls.Add(this.VL_SaldoLiquido);
            this.pCentral.Controls.Add(this.label3);
            this.pCentral.Controls.Add(this.Tot_Ch_PAG);
            this.pCentral.Controls.Add(this.label5);
            this.pCentral.Controls.Add(this.Tot_Ch_REC);
            this.pCentral.Controls.Add(this.label4);
            this.pCentral.Controls.Add(label2);
            this.pCentral.Controls.Add(this.vl_anterior);
            this.pCentral.Controls.Add(label1);
            this.pCentral.Controls.Add(this.dt_ultimofechamento);
            this.pCentral.Controls.Add(this.dt_fechamento);
            this.pCentral.Controls.Add(dt_fechamentostringLabel);
            this.pCentral.Controls.Add(vl_atualLabel);
            this.pCentral.Controls.Add(this.vl_atual);
            this.pCentral.Name = "pCentral";
            this.pCentral.NM_ProcDeletar = "";
            this.pCentral.NM_ProcGravar = "";
            // 
            // VL_SaldoLiquido
            // 
            this.VL_SaldoLiquido.BackColor = System.Drawing.SystemColors.Control;
            this.VL_SaldoLiquido.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFechamentoCaixa, "Vl_saldofuturo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_SaldoLiquido.DecimalPlaces = 2;
            resources.ApplyResources(this.VL_SaldoLiquido, "VL_SaldoLiquido");
            this.VL_SaldoLiquido.ForeColor = System.Drawing.SystemColors.WindowText;
            this.VL_SaldoLiquido.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.VL_SaldoLiquido.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.VL_SaldoLiquido.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.VL_SaldoLiquido.Name = "VL_SaldoLiquido";
            this.VL_SaldoLiquido.NM_Alias = "";
            this.VL_SaldoLiquido.NM_Campo = "";
            this.VL_SaldoLiquido.NM_Param = "";
            this.VL_SaldoLiquido.Operador = "";
            this.VL_SaldoLiquido.ReadOnly = true;
            this.VL_SaldoLiquido.ST_AutoInc = false;
            this.VL_SaldoLiquido.ST_DisableAuto = false;
            this.VL_SaldoLiquido.ST_Gravar = false;
            this.VL_SaldoLiquido.ST_LimparCampo = true;
            this.VL_SaldoLiquido.ST_NotNull = false;
            this.VL_SaldoLiquido.ST_PrimaryKey = false;
            this.VL_SaldoLiquido.TabStop = false;
            // 
            // bsFechamentoCaixa
            // 
            this.bsFechamentoCaixa.DataSource = typeof(CamadaDados.Financeiro.Caixa.TRegistro_LanFechamentoCaixa);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Tot_Ch_PAG
            // 
            this.Tot_Ch_PAG.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFechamentoCaixa, "Vl_ch_emit_compensar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Tot_Ch_PAG.DecimalPlaces = 2;
            resources.ApplyResources(this.Tot_Ch_PAG, "Tot_Ch_PAG");
            this.Tot_Ch_PAG.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Tot_Ch_PAG.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.Tot_Ch_PAG.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.Tot_Ch_PAG.Name = "Tot_Ch_PAG";
            this.Tot_Ch_PAG.NM_Alias = "";
            this.Tot_Ch_PAG.NM_Campo = "";
            this.Tot_Ch_PAG.NM_Param = "";
            this.Tot_Ch_PAG.Operador = "";
            this.Tot_Ch_PAG.ReadOnly = true;
            this.Tot_Ch_PAG.ST_AutoInc = false;
            this.Tot_Ch_PAG.ST_DisableAuto = false;
            this.Tot_Ch_PAG.ST_Gravar = false;
            this.Tot_Ch_PAG.ST_LimparCampo = true;
            this.Tot_Ch_PAG.ST_NotNull = false;
            this.Tot_Ch_PAG.ST_PrimaryKey = false;
            this.Tot_Ch_PAG.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // Tot_Ch_REC
            // 
            this.Tot_Ch_REC.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFechamentoCaixa, "Vl_ch_rec_compensar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Tot_Ch_REC.DecimalPlaces = 2;
            resources.ApplyResources(this.Tot_Ch_REC, "Tot_Ch_REC");
            this.Tot_Ch_REC.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Tot_Ch_REC.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.Tot_Ch_REC.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.Tot_Ch_REC.Name = "Tot_Ch_REC";
            this.Tot_Ch_REC.NM_Alias = "";
            this.Tot_Ch_REC.NM_Campo = "";
            this.Tot_Ch_REC.NM_Param = "";
            this.Tot_Ch_REC.Operador = "";
            this.Tot_Ch_REC.ReadOnly = true;
            this.Tot_Ch_REC.ST_AutoInc = false;
            this.Tot_Ch_REC.ST_DisableAuto = false;
            this.Tot_Ch_REC.ST_Gravar = false;
            this.Tot_Ch_REC.ST_LimparCampo = true;
            this.Tot_Ch_REC.ST_NotNull = false;
            this.Tot_Ch_REC.ST_PrimaryKey = false;
            this.Tot_Ch_REC.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // vl_anterior
            // 
            this.vl_anterior.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFechamentoCaixa, "Vl_anterior", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_anterior.DecimalPlaces = 2;
            resources.ApplyResources(this.vl_anterior, "vl_anterior");
            this.vl_anterior.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_anterior.Minimum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            -2147483648});
            this.vl_anterior.Name = "vl_anterior";
            this.vl_anterior.NM_Alias = "";
            this.vl_anterior.NM_Campo = "";
            this.vl_anterior.NM_Param = "";
            this.vl_anterior.Operador = "";
            this.vl_anterior.ReadOnly = true;
            this.vl_anterior.ST_AutoInc = false;
            this.vl_anterior.ST_DisableAuto = false;
            this.vl_anterior.ST_Gravar = false;
            this.vl_anterior.ST_LimparCampo = true;
            this.vl_anterior.ST_NotNull = false;
            this.vl_anterior.ST_PrimaryKey = false;
            this.vl_anterior.TabStop = false;
            // 
            // dt_ultimofechamento
            // 
            this.dt_ultimofechamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ultimofechamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFechamentoCaixa, "Dt_ultimofechamentostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.dt_ultimofechamento, "dt_ultimofechamento");
            this.dt_ultimofechamento.Name = "dt_ultimofechamento";
            this.dt_ultimofechamento.NM_Alias = "";
            this.dt_ultimofechamento.NM_Campo = "";
            this.dt_ultimofechamento.NM_CampoBusca = "";
            this.dt_ultimofechamento.NM_Param = "";
            this.dt_ultimofechamento.Operador = "";
            this.dt_ultimofechamento.ST_Gravar = false;
            this.dt_ultimofechamento.ST_LimpaCampo = true;
            this.dt_ultimofechamento.ST_NotNull = false;
            this.dt_ultimofechamento.ST_PrimaryKey = false;
            // 
            // dt_fechamento
            // 
            this.dt_fechamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fechamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFechamentoCaixa, "Dt_fechamentostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.dt_fechamento, "dt_fechamento");
            this.dt_fechamento.Name = "dt_fechamento";
            this.dt_fechamento.NM_Alias = "";
            this.dt_fechamento.NM_Campo = "";
            this.dt_fechamento.NM_CampoBusca = "";
            this.dt_fechamento.NM_Param = "";
            this.dt_fechamento.Operador = "";
            this.dt_fechamento.ST_Gravar = false;
            this.dt_fechamento.ST_LimpaCampo = true;
            this.dt_fechamento.ST_NotNull = false;
            this.dt_fechamento.ST_PrimaryKey = false;
            this.dt_fechamento.Leave += new System.EventHandler(this.dt_fechamento_Leave);
            // 
            // vl_atual
            // 
            this.vl_atual.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFechamentoCaixa, "Vl_atual", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_atual.DecimalPlaces = 2;
            resources.ApplyResources(this.vl_atual, "vl_atual");
            this.vl_atual.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_atual.Minimum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            -2147483648});
            this.vl_atual.Name = "vl_atual";
            this.vl_atual.NM_Alias = "";
            this.vl_atual.NM_Campo = "";
            this.vl_atual.NM_Param = "";
            this.vl_atual.Operador = "";
            this.vl_atual.ReadOnly = true;
            this.vl_atual.ST_AutoInc = false;
            this.vl_atual.ST_DisableAuto = false;
            this.vl_atual.ST_Gravar = false;
            this.vl_atual.ST_LimparCampo = true;
            this.vl_atual.ST_NotNull = false;
            this.vl_atual.ST_PrimaryKey = false;
            this.vl_atual.TabStop = false;
            // 
            // pFiltros
            // 
            resources.ApplyResources(this.pFiltros, "pFiltros");
            this.pFiltros.BackColor = System.Drawing.Color.Transparent;
            this.pFiltros.Controls.Add(this.dataGridDefault1);
            this.pFiltros.Controls.Add(this.DS_ContaGer);
            this.pFiltros.Controls.Add(this.CD_ContaGer);
            this.pFiltros.Controls.Add(this.label6);
            this.pFiltros.Name = "pFiltros";
            this.pFiltros.NM_ProcDeletar = "";
            this.pFiltros.NM_ProcGravar = "";
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtfechamentoDataGridViewTextBoxColumn,
            this.vlanteriorDataGridViewTextBoxColumn,
            this.vlatualDataGridViewTextBoxColumn,
            this.cdcontagerDataGridViewTextBoxColumn,
            this.dscontagerDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsListaFechamentos;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.dataGridDefault1, "dataGridDefault1");
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridDefault1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // dtfechamentoDataGridViewTextBoxColumn
            // 
            this.dtfechamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtfechamentoDataGridViewTextBoxColumn.DataPropertyName = "Dt_fechamento";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dtfechamentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dtfechamentoDataGridViewTextBoxColumn, "dtfechamentoDataGridViewTextBoxColumn");
            this.dtfechamentoDataGridViewTextBoxColumn.Name = "dtfechamentoDataGridViewTextBoxColumn";
            this.dtfechamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlanteriorDataGridViewTextBoxColumn
            // 
            this.vlanteriorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlanteriorDataGridViewTextBoxColumn.DataPropertyName = "Vl_anterior";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vlanteriorDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.vlanteriorDataGridViewTextBoxColumn, "vlanteriorDataGridViewTextBoxColumn");
            this.vlanteriorDataGridViewTextBoxColumn.Name = "vlanteriorDataGridViewTextBoxColumn";
            this.vlanteriorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlatualDataGridViewTextBoxColumn
            // 
            this.vlatualDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlatualDataGridViewTextBoxColumn.DataPropertyName = "Vl_atual";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.vlatualDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.vlatualDataGridViewTextBoxColumn, "vlatualDataGridViewTextBoxColumn");
            this.vlatualDataGridViewTextBoxColumn.Name = "vlatualDataGridViewTextBoxColumn";
            this.vlatualDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdcontagerDataGridViewTextBoxColumn
            // 
            this.cdcontagerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcontagerDataGridViewTextBoxColumn.DataPropertyName = "Cd_contager";
            resources.ApplyResources(this.cdcontagerDataGridViewTextBoxColumn, "cdcontagerDataGridViewTextBoxColumn");
            this.cdcontagerDataGridViewTextBoxColumn.Name = "cdcontagerDataGridViewTextBoxColumn";
            this.cdcontagerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dscontagerDataGridViewTextBoxColumn
            // 
            this.dscontagerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscontagerDataGridViewTextBoxColumn.DataPropertyName = "Ds_contager";
            resources.ApplyResources(this.dscontagerDataGridViewTextBoxColumn, "dscontagerDataGridViewTextBoxColumn");
            this.dscontagerDataGridViewTextBoxColumn.Name = "dscontagerDataGridViewTextBoxColumn";
            this.dscontagerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsListaFechamentos
            // 
            this.bsListaFechamentos.DataSource = typeof(CamadaDados.Financeiro.Caixa.TList_LanFechamentoCaixa);
            // 
            // DS_ContaGer
            // 
            this.DS_ContaGer.BackColor = System.Drawing.SystemColors.Window;
            this.DS_ContaGer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_ContaGer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFechamentoCaixa, "Ds_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_ContaGer, "DS_ContaGer");
            this.DS_ContaGer.Name = "DS_ContaGer";
            this.DS_ContaGer.NM_Alias = "";
            this.DS_ContaGer.NM_Campo = "DS_ContaGer";
            this.DS_ContaGer.NM_CampoBusca = "DS_ContaGer";
            this.DS_ContaGer.NM_Param = "@P_DS_CONTAGER";
            this.DS_ContaGer.QTD_Zero = 0;
            this.DS_ContaGer.ST_AutoInc = false;
            this.DS_ContaGer.ST_DisableAuto = false;
            this.DS_ContaGer.ST_Float = false;
            this.DS_ContaGer.ST_Gravar = false;
            this.DS_ContaGer.ST_Int = false;
            this.DS_ContaGer.ST_LimpaCampo = true;
            this.DS_ContaGer.ST_NotNull = false;
            this.DS_ContaGer.ST_PrimaryKey = false;
            this.DS_ContaGer.TextOld = null;
            // 
            // CD_ContaGer
            // 
            this.CD_ContaGer.BackColor = System.Drawing.SystemColors.Window;
            this.CD_ContaGer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_ContaGer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFechamentoCaixa, "Cd_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_ContaGer, "CD_ContaGer");
            this.CD_ContaGer.Name = "CD_ContaGer";
            this.CD_ContaGer.NM_Alias = "";
            this.CD_ContaGer.NM_Campo = "CD_ContaGer";
            this.CD_ContaGer.NM_CampoBusca = "CD_ContaGer";
            this.CD_ContaGer.NM_Param = "@P_CD_CONTAGER";
            this.CD_ContaGer.QTD_Zero = 0;
            this.CD_ContaGer.ST_AutoInc = false;
            this.CD_ContaGer.ST_DisableAuto = false;
            this.CD_ContaGer.ST_Float = false;
            this.CD_ContaGer.ST_Gravar = true;
            this.CD_ContaGer.ST_Int = false;
            this.CD_ContaGer.ST_LimpaCampo = true;
            this.CD_ContaGer.ST_NotNull = true;
            this.CD_ContaGer.ST_PrimaryKey = false;
            this.CD_ContaGer.TextOld = null;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // TFLan_FechamentoCaixa
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLan_FechamentoCaixa";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLan_FechamentoCaixa_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLan_FechamentoCaixa_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLan_FechamentoCaixa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pCentral.ResumeLayout(false);
            this.pCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_SaldoLiquido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFechamentoCaixa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tot_Ch_PAG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tot_Ch_REC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_anterior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_atual)).EndInit();
            this.pFiltros.ResumeLayout(false);
            this.pFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListaFechamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltros;
        private Componentes.PanelDados pCentral;
        private Componentes.EditDefault DS_ContaGer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bsFechamentoCaixa;
        private Componentes.EditData dt_fechamento;
        private Componentes.EditFloat vl_atual;
        private Componentes.EditDefault CD_ContaGer;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsListaFechamentos;
        private Componentes.EditFloat vl_anterior;
        private Componentes.EditData dt_ultimofechamento;
        public System.Windows.Forms.ToolStripButton BB_Imprimir;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtfechamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlanteriorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlatualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcontagerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscontagerDataGridViewTextBoxColumn;
        private Componentes.EditFloat Tot_Ch_REC;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat Tot_Ch_PAG;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat VL_SaldoLiquido;
        private System.Windows.Forms.Label label3;
    }
}