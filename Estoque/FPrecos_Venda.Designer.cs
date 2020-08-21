namespace Estoque
{
    partial class TFPrecos_Venda
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
            System.Windows.Forms.Label label_CD_TabelaPreco;
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFPrecos_Venda));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label label2;
            this.pnl_Preco = new Componentes.PanelDados(this.components);
            this.pnl_indice = new Componentes.PanelDados(this.components);
            this.btn_Aplicar_Indice = new System.Windows.Forms.Button();
            this.VL_Indice = new Componentes.EditFloat(this.components);
            this.DT_Preco = new Componentes.EditData(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.DS_TabelaPreco = new Componentes.EditDefault(this.components);
            this.BB_TabelaPreco = new System.Windows.Forms.Button();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.CD_TabelaPreco = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.g_Itens = new Componentes.DataGridDefault(this.components);
            this.gc_CD_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_DS_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_VL_Preco_Venda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_vl_CustoMedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_qtd_saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_Preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_Indice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label_CD_TabelaPreco = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            this.pnl_Preco.SuspendLayout();
            this.pnl_indice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Indice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_Itens)).BeginInit();
            this.SuspendLayout();
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(727, 484);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_Itens);
            this.tpPadrao.Controls.Add(this.pnl_Preco);
            this.tpPadrao.Size = new System.Drawing.Size(719, 458);
            this.tpPadrao.Text = "Lançamento de Preço de Venda";
            // 
            // label_CD_TabelaPreco
            // 
            label_CD_TabelaPreco.AutoSize = true;
            label_CD_TabelaPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_CD_TabelaPreco.Location = new System.Drawing.Point(12, 36);
            label_CD_TabelaPreco.Name = "label_CD_TabelaPreco";
            label_CD_TabelaPreco.Size = new System.Drawing.Size(87, 13);
            label_CD_TabelaPreco.TabIndex = 98;
            label_CD_TabelaPreco.Text = "Tabela Preço:";
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_empresaLabel.Location = new System.Drawing.Point(40, 11);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(59, 13);
            cd_empresaLabel.TabIndex = 99;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(21, 62);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(75, 13);
            label1.TabIndex = 100;
            label1.Text = "Data Preço:";
            // 
            // pnl_Preco
            // 
            this.pnl_Preco.Controls.Add(this.pnl_indice);
            this.pnl_Preco.Controls.Add(this.DT_Preco);
            this.pnl_Preco.Controls.Add(label1);
            this.pnl_Preco.Controls.Add(this.NM_Empresa);
            this.pnl_Preco.Controls.Add(this.DS_TabelaPreco);
            this.pnl_Preco.Controls.Add(this.BB_TabelaPreco);
            this.pnl_Preco.Controls.Add(this.bb_empresa);
            this.pnl_Preco.Controls.Add(this.CD_TabelaPreco);
            this.pnl_Preco.Controls.Add(label_CD_TabelaPreco);
            this.pnl_Preco.Controls.Add(cd_empresaLabel);
            this.pnl_Preco.Controls.Add(this.CD_Empresa);
            this.pnl_Preco.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Preco.Location = new System.Drawing.Point(0, 0);
            this.pnl_Preco.Name = "pnl_Preco";
            this.pnl_Preco.NM_ProcDeletar = "";
            this.pnl_Preco.NM_ProcGravar = "";
            this.pnl_Preco.Size = new System.Drawing.Size(715, 88);
            this.pnl_Preco.TabIndex = 0;
            // 
            // pnl_indice
            // 
            this.pnl_indice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_indice.Controls.Add(label2);
            this.pnl_indice.Controls.Add(this.btn_Aplicar_Indice);
            this.pnl_indice.Controls.Add(this.VL_Indice);
            this.pnl_indice.Location = new System.Drawing.Point(478, 11);
            this.pnl_indice.Name = "pnl_indice";
            this.pnl_indice.NM_ProcDeletar = "";
            this.pnl_indice.NM_ProcGravar = "";
            this.pnl_indice.Size = new System.Drawing.Size(226, 48);
            this.pnl_indice.TabIndex = 5;
            // 
            // btn_Aplicar_Indice
            // 
            this.btn_Aplicar_Indice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Aplicar_Indice.Image = ((System.Drawing.Image)(resources.GetObject("btn_Aplicar_Indice.Image")));
            this.btn_Aplicar_Indice.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Aplicar_Indice.Location = new System.Drawing.Point(144, 3);
            this.btn_Aplicar_Indice.Name = "btn_Aplicar_Indice";
            this.btn_Aplicar_Indice.Size = new System.Drawing.Size(75, 34);
            this.btn_Aplicar_Indice.TabIndex = 1;
            this.btn_Aplicar_Indice.Text = "Aplicar Indice";
            this.btn_Aplicar_Indice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Aplicar_Indice.UseVisualStyleBackColor = true;
            this.btn_Aplicar_Indice.Click += new System.EventHandler(this.btn_Aplicar_Indice_Click);
            // 
            // VL_Indice
            // 
            this.VL_Indice.Location = new System.Drawing.Point(3, 21);
            this.VL_Indice.Name = "VL_Indice";
            this.VL_Indice.NM_Alias = "";
            this.VL_Indice.NM_Campo = "";
            this.VL_Indice.NM_Param = "";
            this.VL_Indice.Operador = "";
            this.VL_Indice.Size = new System.Drawing.Size(120, 20);
            this.VL_Indice.ST_AutoInc = false;
            this.VL_Indice.ST_DisableAuto = false;
            this.VL_Indice.ST_Gravar = false;
            this.VL_Indice.ST_LimparCampo = true;
            this.VL_Indice.ST_NotNull = false;
            this.VL_Indice.ST_PrimaryKey = false;
            this.VL_Indice.TabIndex = 0;
            // 
            // DT_Preco
            // 
            this.DT_Preco.Enabled = false;
            this.DT_Preco.Location = new System.Drawing.Point(99, 59);
            this.DT_Preco.Mask = "00/00/0000";
            this.DT_Preco.Name = "DT_Preco";
            this.DT_Preco.NM_Alias = "";
            this.DT_Preco.NM_Campo = "";
            this.DT_Preco.NM_CampoBusca = "";
            this.DT_Preco.NM_Param = "";
            this.DT_Preco.Operador = "";
            this.DT_Preco.Size = new System.Drawing.Size(100, 20);
            this.DT_Preco.ST_Gravar = false;
            this.DT_Preco.ST_LimpaCampo = true;
            this.DT_Preco.ST_NotNull = false;
            this.DT_Preco.ST_PrimaryKey = false;
            this.DT_Preco.TabIndex = 4;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NM_Empresa.Location = new System.Drawing.Point(193, 9);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(279, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 97;
            // 
            // DS_TabelaPreco
            // 
            this.DS_TabelaPreco.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TabelaPreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TabelaPreco.Enabled = false;
            this.DS_TabelaPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_TabelaPreco.Location = new System.Drawing.Point(193, 33);
            this.DS_TabelaPreco.Name = "DS_TabelaPreco";
            this.DS_TabelaPreco.NM_Alias = "";
            this.DS_TabelaPreco.NM_Campo = "DS_TabelaPreco";
            this.DS_TabelaPreco.NM_CampoBusca = "DS_TabelaPreco";
            this.DS_TabelaPreco.NM_Param = "@P_DS_TABELAPRECO";
            this.DS_TabelaPreco.QTD_Zero = 0;
            this.DS_TabelaPreco.ReadOnly = true;
            this.DS_TabelaPreco.Size = new System.Drawing.Size(279, 20);
            this.DS_TabelaPreco.ST_AutoInc = false;
            this.DS_TabelaPreco.ST_DisableAuto = false;
            this.DS_TabelaPreco.ST_Float = false;
            this.DS_TabelaPreco.ST_Gravar = false;
            this.DS_TabelaPreco.ST_Int = false;
            this.DS_TabelaPreco.ST_LimpaCampo = true;
            this.DS_TabelaPreco.ST_NotNull = false;
            this.DS_TabelaPreco.ST_PrimaryKey = false;
            this.DS_TabelaPreco.TabIndex = 96;
            // 
            // BB_TabelaPreco
            // 
            this.BB_TabelaPreco.BackColor = System.Drawing.SystemColors.Control;
            this.BB_TabelaPreco.Enabled = false;
            this.BB_TabelaPreco.Image = ((System.Drawing.Image)(resources.GetObject("BB_TabelaPreco.Image")));
            this.BB_TabelaPreco.Location = new System.Drawing.Point(163, 34);
            this.BB_TabelaPreco.Name = "BB_TabelaPreco";
            this.BB_TabelaPreco.Size = new System.Drawing.Size(28, 19);
            this.BB_TabelaPreco.TabIndex = 3;
            this.BB_TabelaPreco.UseVisualStyleBackColor = false;
            this.BB_TabelaPreco.Click += new System.EventHandler(this.BB_TabelaPreco_Click);
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Enabled = false;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.Location = new System.Drawing.Point(163, 9);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // CD_TabelaPreco
            // 
            this.CD_TabelaPreco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_TabelaPreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_TabelaPreco.Enabled = false;
            this.CD_TabelaPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_TabelaPreco.Location = new System.Drawing.Point(99, 33);
            this.CD_TabelaPreco.MaxLength = 2;
            this.CD_TabelaPreco.Name = "CD_TabelaPreco";
            this.CD_TabelaPreco.NM_Alias = "";
            this.CD_TabelaPreco.NM_Campo = "CD_TabelaPreco";
            this.CD_TabelaPreco.NM_CampoBusca = "CD_TabelaPreco";
            this.CD_TabelaPreco.NM_Param = "@P_CD_TABELAPRECO";
            this.CD_TabelaPreco.QTD_Zero = 0;
            this.CD_TabelaPreco.Size = new System.Drawing.Size(62, 20);
            this.CD_TabelaPreco.ST_AutoInc = false;
            this.CD_TabelaPreco.ST_DisableAuto = false;
            this.CD_TabelaPreco.ST_Float = false;
            this.CD_TabelaPreco.ST_Gravar = true;
            this.CD_TabelaPreco.ST_Int = true;
            this.CD_TabelaPreco.ST_LimpaCampo = true;
            this.CD_TabelaPreco.ST_NotNull = true;
            this.CD_TabelaPreco.ST_PrimaryKey = false;
            this.CD_TabelaPreco.TabIndex = 2;
            this.CD_TabelaPreco.Leave += new System.EventHandler(this.CD_TabelaPreco_Leave);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Enabled = false;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_Empresa.Location = new System.Drawing.Point(99, 8);
            this.CD_Empresa.MaxLength = 4;
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(62, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = false;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // g_Itens
            // 
            this.g_Itens.AllowUserToAddRows = false;
            this.g_Itens.AllowUserToDeleteRows = false;
            this.g_Itens.AllowUserToOrderColumns = true;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_Itens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.g_Itens.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_Itens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_Itens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_Itens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.g_Itens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_Itens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gc_CD_Produto,
            this.gc_DS_Produto,
            this.gc_VL_Preco_Venda,
            this.gc_vl_CustoMedio,
            this.gc_qtd_saldo,
            this.gc_Preco,
            this.gc_Indice});
            this.g_Itens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g_Itens.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_Itens.Location = new System.Drawing.Point(0, 88);
            this.g_Itens.Name = "g_Itens";
            this.g_Itens.ReadOnly = true;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_Itens.RowHeadersDefaultCellStyle = dataGridViewCellStyle40;
            this.g_Itens.RowHeadersWidth = 23;
            this.g_Itens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_Itens.Size = new System.Drawing.Size(715, 366);
            this.g_Itens.TabIndex = 1;
            this.g_Itens.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.g_Itens_CellValueChanged);
            this.g_Itens.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.g_Itens_RowLeave);
            // 
            // gc_CD_Produto
            // 
            this.gc_CD_Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gc_CD_Produto.DataPropertyName = "CD_Produto";
            this.gc_CD_Produto.HeaderText = "Cód. Produto";
            this.gc_CD_Produto.Name = "gc_CD_Produto";
            this.gc_CD_Produto.ReadOnly = true;
            this.gc_CD_Produto.Width = 94;
            // 
            // gc_DS_Produto
            // 
            this.gc_DS_Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gc_DS_Produto.DataPropertyName = "ds_produto";
            this.gc_DS_Produto.HeaderText = "Produto";
            this.gc_DS_Produto.Name = "gc_DS_Produto";
            this.gc_DS_Produto.ReadOnly = true;
            this.gc_DS_Produto.Width = 69;
            // 
            // gc_VL_Preco_Venda
            // 
            this.gc_VL_Preco_Venda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gc_VL_Preco_Venda.DataPropertyName = "Vl_PrecoVenda";
            dataGridViewCellStyle35.Format = "C2";
            dataGridViewCellStyle35.NullValue = null;
            this.gc_VL_Preco_Venda.DefaultCellStyle = dataGridViewCellStyle35;
            this.gc_VL_Preco_Venda.HeaderText = "Preço Venda";
            this.gc_VL_Preco_Venda.Name = "gc_VL_Preco_Venda";
            this.gc_VL_Preco_Venda.ReadOnly = true;
            this.gc_VL_Preco_Venda.Width = 94;
            // 
            // gc_vl_CustoMedio
            // 
            this.gc_vl_CustoMedio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gc_vl_CustoMedio.DataPropertyName = "vl_customedio";
            dataGridViewCellStyle36.Format = "C2";
            dataGridViewCellStyle36.NullValue = null;
            this.gc_vl_CustoMedio.DefaultCellStyle = dataGridViewCellStyle36;
            this.gc_vl_CustoMedio.HeaderText = "VL. Custo Médio";
            this.gc_vl_CustoMedio.Name = "gc_vl_CustoMedio";
            this.gc_vl_CustoMedio.ReadOnly = true;
            this.gc_vl_CustoMedio.Width = 101;
            // 
            // gc_qtd_saldo
            // 
            this.gc_qtd_saldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gc_qtd_saldo.DataPropertyName = "QtdSaldo";
            dataGridViewCellStyle37.Format = "N3";
            dataGridViewCellStyle37.NullValue = null;
            this.gc_qtd_saldo.DefaultCellStyle = dataGridViewCellStyle37;
            this.gc_qtd_saldo.HeaderText = "Saldo Estoque";
            this.gc_qtd_saldo.Name = "gc_qtd_saldo";
            this.gc_qtd_saldo.ReadOnly = true;
            this.gc_qtd_saldo.Width = 93;
            // 
            // gc_Preco
            // 
            this.gc_Preco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gc_Preco.DataPropertyName = "VL_Preco_Lancto ";
            dataGridViewCellStyle38.Format = "C2";
            dataGridViewCellStyle38.NullValue = "0";
            this.gc_Preco.DefaultCellStyle = dataGridViewCellStyle38;
            this.gc_Preco.HeaderText = "";
            this.gc_Preco.Name = "gc_Preco";
            this.gc_Preco.ReadOnly = true;
            this.gc_Preco.Width = 19;
            // 
            // gc_Indice
            // 
            this.gc_Indice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gc_Indice.DataPropertyName = "VL_Indice";
            dataGridViewCellStyle39.Format = "N2";
            dataGridViewCellStyle39.NullValue = "0";
            this.gc_Indice.DefaultCellStyle = dataGridViewCellStyle39;
            this.gc_Indice.HeaderText = "";
            this.gc_Indice.Name = "gc_Indice";
            this.gc_Indice.ReadOnly = true;
            this.gc_Indice.Width = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(4, 4);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 13);
            label2.TabIndex = 100;
            label2.Text = "Indice:";
            // 
            // TFPrecos_Venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 527);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TFPrecos_Venda";
            this.Text = "Preço de Venda";
            this.Load += new System.EventHandler(this.TFPrecos_Venda_Load);
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.pnl_Preco.ResumeLayout(false);
            this.pnl_Preco.PerformLayout();
            this.pnl_indice.ResumeLayout(false);
            this.pnl_indice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Indice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_Itens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.PanelDados pnl_Preco;
        private Componentes.EditData DT_Preco;
        public Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault DS_TabelaPreco;
        private System.Windows.Forms.Button BB_TabelaPreco;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault CD_TabelaPreco;
        public Componentes.EditDefault CD_Empresa;
        private Componentes.DataGridDefault g_Itens;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_CD_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_DS_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_VL_Preco_Venda;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_vl_CustoMedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_qtd_saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_Preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_Indice;
        private Componentes.PanelDados pnl_indice;
        private Componentes.EditFloat VL_Indice;
        private System.Windows.Forms.Button btn_Aplicar_Indice;
    }
}