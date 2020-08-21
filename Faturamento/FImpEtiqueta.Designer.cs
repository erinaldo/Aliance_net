namespace Faturamento
{
    partial class TFImpEtiqueta
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
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label label_CD_TabelaPreco;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFImpEtiqueta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.DS_TabelaPreco = new Componentes.EditDefault(this.components);
            this.BB_TabelaPreco = new System.Windows.Forms.Button();
            this.CD_TabelaPreco = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsCodBarra = new System.Windows.Forms.BindingSource(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_imprimir = new System.Windows.Forms.Button();
            this.qtde = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.vl_venda = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.agregar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcodbarraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlvendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cd_empresaLabel = new System.Windows.Forms.Label();
            label_CD_TabelaPreco = new System.Windows.Forms.Label();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCodBarra)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_venda)).BeginInit();
            this.SuspendLayout();
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(24, 6);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(51, 13);
            cd_empresaLabel.TabIndex = 94;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // label_CD_TabelaPreco
            // 
            label_CD_TabelaPreco.AutoSize = true;
            label_CD_TabelaPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label_CD_TabelaPreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label_CD_TabelaPreco.Location = new System.Drawing.Point(7, 37);
            label_CD_TabelaPreco.Name = "label_CD_TabelaPreco";
            label_CD_TabelaPreco.Size = new System.Drawing.Size(74, 13);
            label_CD_TabelaPreco.TabIndex = 98;
            label_CD_TabelaPreco.Text = "Tabela Preço:";
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.dataGridDefault1, 0, 1);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 2);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 3;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpCentral.Size = new System.Drawing.Size(857, 499);
            this.tlpCentral.TabIndex = 0;
            // 
            // pFiltro
            // 
            this.pFiltro.Controls.Add(this.bb_empresa);
            this.pFiltro.Controls.Add(this.DS_TabelaPreco);
            this.pFiltro.Controls.Add(this.BB_TabelaPreco);
            this.pFiltro.Controls.Add(this.CD_TabelaPreco);
            this.pFiltro.Controls.Add(label_CD_TabelaPreco);
            this.pFiltro.Controls.Add(this.NM_Empresa);
            this.pFiltro.Controls.Add(cd_empresaLabel);
            this.pFiltro.Controls.Add(this.CD_Empresa);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 3);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(851, 59);
            this.pFiltro.TabIndex = 0;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(134, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 99;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // DS_TabelaPreco
            // 
            this.DS_TabelaPreco.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TabelaPreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_TabelaPreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TabelaPreco.Enabled = false;
            this.DS_TabelaPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_TabelaPreco.Location = new System.Drawing.Point(164, 34);
            this.DS_TabelaPreco.Name = "DS_TabelaPreco";
            this.DS_TabelaPreco.NM_Alias = "";
            this.DS_TabelaPreco.NM_Campo = "DS_TabelaPreco";
            this.DS_TabelaPreco.NM_CampoBusca = "DS_TabelaPreco";
            this.DS_TabelaPreco.NM_Param = "@P_DS_TABELAPRECO";
            this.DS_TabelaPreco.QTD_Zero = 0;
            this.DS_TabelaPreco.ReadOnly = true;
            this.DS_TabelaPreco.Size = new System.Drawing.Size(678, 20);
            this.DS_TabelaPreco.ST_AutoInc = false;
            this.DS_TabelaPreco.ST_DisableAuto = false;
            this.DS_TabelaPreco.ST_Float = false;
            this.DS_TabelaPreco.ST_Gravar = false;
            this.DS_TabelaPreco.ST_Int = false;
            this.DS_TabelaPreco.ST_LimpaCampo = true;
            this.DS_TabelaPreco.ST_NotNull = false;
            this.DS_TabelaPreco.ST_PrimaryKey = false;
            this.DS_TabelaPreco.TabIndex = 95;
            this.DS_TabelaPreco.TextOld = null;
            // 
            // BB_TabelaPreco
            // 
            this.BB_TabelaPreco.BackColor = System.Drawing.SystemColors.Control;
            this.BB_TabelaPreco.Image = ((System.Drawing.Image)(resources.GetObject("BB_TabelaPreco.Image")));
            this.BB_TabelaPreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_TabelaPreco.Location = new System.Drawing.Point(134, 34);
            this.BB_TabelaPreco.Name = "BB_TabelaPreco";
            this.BB_TabelaPreco.Size = new System.Drawing.Size(28, 19);
            this.BB_TabelaPreco.TabIndex = 97;
            this.BB_TabelaPreco.UseVisualStyleBackColor = false;
            this.BB_TabelaPreco.Click += new System.EventHandler(this.BB_TabelaPreco_Click);
            // 
            // CD_TabelaPreco
            // 
            this.CD_TabelaPreco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_TabelaPreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_TabelaPreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_TabelaPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_TabelaPreco.Location = new System.Drawing.Point(81, 34);
            this.CD_TabelaPreco.Name = "CD_TabelaPreco";
            this.CD_TabelaPreco.NM_Alias = "";
            this.CD_TabelaPreco.NM_Campo = "CD_TabelaPreco";
            this.CD_TabelaPreco.NM_CampoBusca = "CD_TabelaPreco";
            this.CD_TabelaPreco.NM_Param = "@P_CD_TABELAPRECO";
            this.CD_TabelaPreco.QTD_Zero = 0;
            this.CD_TabelaPreco.Size = new System.Drawing.Size(51, 20);
            this.CD_TabelaPreco.ST_AutoInc = false;
            this.CD_TabelaPreco.ST_DisableAuto = false;
            this.CD_TabelaPreco.ST_Float = false;
            this.CD_TabelaPreco.ST_Gravar = true;
            this.CD_TabelaPreco.ST_Int = true;
            this.CD_TabelaPreco.ST_LimpaCampo = true;
            this.CD_TabelaPreco.ST_NotNull = true;
            this.CD_TabelaPreco.ST_PrimaryKey = false;
            this.CD_TabelaPreco.TabIndex = 96;
            this.CD_TabelaPreco.TextOld = null;
            this.CD_TabelaPreco.Leave += new System.EventHandler(this.CD_TabelaPreco_Leave);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(164, 3);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(678, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 93;
            this.NM_Empresa.TextOld = null;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(81, 3);
            this.CD_Empresa.MaxLength = 4;
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(51, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 92;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
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
            this.agregar,
            this.Quantidade,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.Referencia,
            this.cdcodbarraDataGridViewTextBoxColumn,
            this.vlvendaDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsCodBarra;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(3, 68);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(851, 363);
            this.dataGridDefault1.TabIndex = 1;
            this.dataGridDefault1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDefault1_CellClick);
            // 
            // bsCodBarra
            // 
            this.bsCodBarra.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CodBarra);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.bb_imprimir);
            this.panelDados1.Controls.Add(this.qtde);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.vl_venda);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 437);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(851, 59);
            this.panelDados1.TabIndex = 2;
            // 
            // bb_imprimir
            // 
            this.bb_imprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_imprimir.ForeColor = System.Drawing.Color.Green;
            this.bb_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("bb_imprimir.Image")));
            this.bb_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_imprimir.Location = new System.Drawing.Point(264, 4);
            this.bb_imprimir.Name = "bb_imprimir";
            this.bb_imprimir.Size = new System.Drawing.Size(95, 46);
            this.bb_imprimir.TabIndex = 4;
            this.bb_imprimir.Text = "Imprimir";
            this.bb_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_imprimir.UseVisualStyleBackColor = true;
            this.bb_imprimir.Click += new System.EventHandler(this.bb_imprimir_Click);
            // 
            // qtde
            // 
            this.qtde.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCodBarra, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtde.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qtde.Location = new System.Drawing.Point(138, 30);
            this.qtde.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtde.Name = "qtde";
            this.qtde.NM_Alias = "";
            this.qtde.NM_Campo = "";
            this.qtde.NM_Param = "";
            this.qtde.Operador = "";
            this.qtde.Size = new System.Drawing.Size(120, 20);
            this.qtde.ST_AutoInc = false;
            this.qtde.ST_DisableAuto = false;
            this.qtde.ST_Gravar = false;
            this.qtde.ST_LimparCampo = true;
            this.qtde.ST_NotNull = false;
            this.qtde.ST_PrimaryKey = false;
            this.qtde.TabIndex = 3;
            this.qtde.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Qtde Etiqueta";
            // 
            // vl_venda
            // 
            this.vl_venda.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCodBarra, "Vl_venda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_venda.DecimalPlaces = 2;
            this.vl_venda.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_venda.Location = new System.Drawing.Point(12, 30);
            this.vl_venda.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_venda.Name = "vl_venda";
            this.vl_venda.NM_Alias = "";
            this.vl_venda.NM_Campo = "";
            this.vl_venda.NM_Param = "";
            this.vl_venda.Operador = "";
            this.vl_venda.Size = new System.Drawing.Size(120, 20);
            this.vl_venda.ST_AutoInc = false;
            this.vl_venda.ST_DisableAuto = false;
            this.vl_venda.ST_Gravar = false;
            this.vl_venda.ST_LimparCampo = true;
            this.vl_venda.ST_NotNull = false;
            this.vl_venda.ST_PrimaryKey = false;
            this.vl_venda.TabIndex = 1;
            this.vl_venda.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vl. Venda";
            // 
            // agregar
            // 
            this.agregar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.agregar.DataPropertyName = "agregar";
            this.agregar.HeaderText = "Imp.";
            this.agregar.Name = "agregar";
            this.agregar.ReadOnly = true;
            this.agregar.Width = 33;
            // 
            // Quantidade
            // 
            this.Quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.Quantidade.DefaultCellStyle = dataGridViewCellStyle3;
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            this.Quantidade.Width = 87;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 88;
            // 
            // Referencia
            // 
            this.Referencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Referencia.DataPropertyName = "Referencia";
            this.Referencia.HeaderText = "Referência";
            this.Referencia.Name = "Referencia";
            this.Referencia.ReadOnly = true;
            this.Referencia.Width = 84;
            // 
            // cdcodbarraDataGridViewTextBoxColumn
            // 
            this.cdcodbarraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcodbarraDataGridViewTextBoxColumn.DataPropertyName = "Cd_codbarra";
            this.cdcodbarraDataGridViewTextBoxColumn.HeaderText = "Cod. Barra";
            this.cdcodbarraDataGridViewTextBoxColumn.Name = "cdcodbarraDataGridViewTextBoxColumn";
            this.cdcodbarraDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcodbarraDataGridViewTextBoxColumn.Width = 82;
            // 
            // vlvendaDataGridViewTextBoxColumn
            // 
            this.vlvendaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlvendaDataGridViewTextBoxColumn.DataPropertyName = "Vl_venda";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vlvendaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.vlvendaDataGridViewTextBoxColumn.HeaderText = "Vl. Venda";
            this.vlvendaDataGridViewTextBoxColumn.Name = "vlvendaDataGridViewTextBoxColumn";
            this.vlvendaDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlvendaDataGridViewTextBoxColumn.Width = 78;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // TFImpEtiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 499);
            this.Controls.Add(this.tlpCentral);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFImpEtiqueta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Etiquetas";
            this.Load += new System.EventHandler(this.TFImpEtiqueta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFImpEtiqueta_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCodBarra)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_venda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault DS_TabelaPreco;
        private System.Windows.Forms.Button BB_TabelaPreco;
        private Componentes.EditDefault CD_TabelaPreco;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsCodBarra;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Button bb_imprimir;
        private Componentes.EditFloat qtde;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat vl_venda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn agregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcodbarraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlvendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
    }
}