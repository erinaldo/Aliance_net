namespace Estoque
{
    partial class TFEtiqueta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFEtiqueta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsCodBarra = new System.Windows.Forms.BindingSource(this.components);
            this.TS_ItensPedido = new System.Windows.Forms.ToolStrip();
            this.btn_Deleta_Item = new System.Windows.Forms.ToolStripButton();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.panelDados3 = new Componentes.PanelDados(this.components);
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.toolStripDropDown_Relatorios = new System.Windows.Forms.ToolStripDropDownButton();
            this.tmRelEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_codbarra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_venda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cd_empresaLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCodBarra)).BeginInit();
            this.TS_ItensPedido.SuspendLayout();
            this.panelDados2.SuspendLayout();
            this.panelDados3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(5, 10);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(59, 13);
            cd_empresaLabel.TabIndex = 116;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 521);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1080, 521);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.dataGridDefault1);
            this.panelDados1.Controls.Add(this.TS_ItensPedido);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 171);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1074, 347);
            this.panelDados1.TabIndex = 2;
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
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.pReferencia,
            this.Cd_codbarra,
            this.dataGridViewTextBoxColumn1,
            this.Vl_venda,
            this.uni});
            this.dataGridDefault1.DataSource = this.bsCodBarra;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 25);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(1074, 322);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // bsCodBarra
            // 
            this.bsCodBarra.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CodBarra);
            // 
            // TS_ItensPedido
            // 
            this.TS_ItensPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Deleta_Item});
            this.TS_ItensPedido.Location = new System.Drawing.Point(0, 0);
            this.TS_ItensPedido.Name = "TS_ItensPedido";
            this.TS_ItensPedido.Size = new System.Drawing.Size(1074, 25);
            this.TS_ItensPedido.TabIndex = 5;
            // 
            // btn_Deleta_Item
            // 
            this.btn_Deleta_Item.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Deleta_Item.Image = ((System.Drawing.Image)(resources.GetObject("btn_Deleta_Item.Image")));
            this.btn_Deleta_Item.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Deleta_Item.Name = "btn_Deleta_Item";
            this.btn_Deleta_Item.Size = new System.Drawing.Size(79, 22);
            this.btn_Deleta_Item.Text = "Remover";
            this.btn_Deleta_Item.ToolTipText = "Excluir Item Pedido";
            this.btn_Deleta_Item.Click += new System.EventHandler(this.btn_Deleta_Item_Click);
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.panelDados3);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 3);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(1074, 162);
            this.panelDados2.TabIndex = 3;
            // 
            // panelDados3
            // 
            this.panelDados3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados3.Controls.Add(this.cbEmpresa);
            this.panelDados3.Controls.Add(cd_empresaLabel);
            this.panelDados3.Controls.Add(this.ds_produto);
            this.panelDados3.Controls.Add(this.Quantidade);
            this.panelDados3.Controls.Add(this.label58);
            this.panelDados3.Controls.Add(this.label1);
            this.panelDados3.Controls.Add(this.CD_Produto);
            this.panelDados3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados3.Location = new System.Drawing.Point(0, 0);
            this.panelDados3.Name = "panelDados3";
            this.panelDados3.NM_ProcDeletar = "";
            this.panelDados3.NM_ProcGravar = "";
            this.panelDados3.Size = new System.Drawing.Size(1074, 162);
            this.panelDados3.TabIndex = 13;
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(66, 7);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(452, 21);
            this.cbEmpresa.ST_Gravar = true;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = true;
            this.cbEmpresa.TabIndex = 117;
            this.cbEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cbEmpresa_SelectionChangeCommitted);
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.Enabled = false;
            this.ds_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ds_produto.Location = new System.Drawing.Point(15, 86);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_CD_PRODUTO";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(503, 29);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = true;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 115;
            this.ds_produto.TextOld = null;
            // 
            // Quantidade
            // 
            this.Quantidade.DecimalPlaces = 3;
            this.Quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Quantidade.Location = new System.Drawing.Point(15, 134);
            this.Quantidade.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.NM_Alias = "";
            this.Quantidade.NM_Campo = "Quantidade";
            this.Quantidade.NM_Param = "@P_QUANTIDADE";
            this.Quantidade.Operador = "";
            this.Quantidade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Quantidade.Size = new System.Drawing.Size(104, 20);
            this.Quantidade.ST_AutoInc = false;
            this.Quantidade.ST_DisableAuto = false;
            this.Quantidade.ST_Gravar = true;
            this.Quantidade.ST_LimparCampo = true;
            this.Quantidade.ST_NotNull = true;
            this.Quantidade.ST_PrimaryKey = false;
            this.Quantidade.TabIndex = 1;
            this.Quantidade.ThousandsSeparator = true;
            this.Quantidade.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Quantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Quantidade_KeyDown);
            this.Quantidade.Leave += new System.EventHandler(this.Quantidade_Leave);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label58.Location = new System.Drawing.Point(12, 118);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(72, 13);
            this.label58.TabIndex = 114;
            this.label58.Text = "Quantidade";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 105;
            this.label1.Text = "Código do produto";
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_Produto.Location = new System.Drawing.Point(15, 51);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(116, 29);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = false;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 0;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CD_Produto_KeyDown);
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // toolStripDropDown_Relatorios
            // 
            this.toolStripDropDown_Relatorios.AutoSize = false;
            this.toolStripDropDown_Relatorios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripDropDown_Relatorios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmRelEstoque});
            this.toolStripDropDown_Relatorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.toolStripDropDown_Relatorios.ForeColor = System.Drawing.Color.Green;
            this.toolStripDropDown_Relatorios.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDown_Relatorios.Image")));
            this.toolStripDropDown_Relatorios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDown_Relatorios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDown_Relatorios.Name = "toolStripDropDown_Relatorios";
            this.toolStripDropDown_Relatorios.Size = new System.Drawing.Size(105, 40);
            this.toolStripDropDown_Relatorios.Text = "Relatórios";
            // 
            // tmRelEstoque
            // 
            this.tmRelEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.tmRelEstoque.Name = "tmRelEstoque";
            this.tmRelEstoque.Size = new System.Drawing.Size(173, 22);
            this.tmRelEstoque.Text = "Imprimir etiquetas";
            this.tmRelEstoque.Click += new System.EventHandler(this.tmRelEstoque_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(54, 40);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDown_Relatorios,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1080, 43);
            this.barraMenu.TabIndex = 1;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 65;
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
            // pReferencia
            // 
            this.pReferencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pReferencia.DataPropertyName = "Referencia";
            this.pReferencia.HeaderText = "Referência";
            this.pReferencia.Name = "pReferencia";
            this.pReferencia.ReadOnly = true;
            this.pReferencia.Width = 84;
            // 
            // Cd_codbarra
            // 
            this.Cd_codbarra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_codbarra.DataPropertyName = "Cd_codbarra";
            this.Cd_codbarra.HeaderText = "Cod. Barra";
            this.Cd_codbarra.Name = "Cd_codbarra";
            this.Cd_codbarra.ReadOnly = true;
            this.Cd_codbarra.Width = 82;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Quantidade";
            this.dataGridViewTextBoxColumn1.HeaderText = "Quantidade";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Vl_venda
            // 
            this.Vl_venda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_venda.DataPropertyName = "Vl_venda";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.Vl_venda.DefaultCellStyle = dataGridViewCellStyle3;
            this.Vl_venda.HeaderText = "Vl. Venda";
            this.Vl_venda.Name = "Vl_venda";
            this.Vl_venda.ReadOnly = true;
            this.Vl_venda.Width = 78;
            // 
            // uni
            // 
            this.uni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.uni.DataPropertyName = "uni";
            this.uni.HeaderText = "Unidade";
            this.uni.Name = "uni";
            this.uni.ReadOnly = true;
            this.uni.Width = 72;
            // 
            // TFEtiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFEtiqueta";
            this.ShowInTaskbar = false;
            this.Text = "Listagem de impressão de etiquetas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FEtiqueta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFEtiqueta_KeyDown);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCodBarra)).EndInit();
            this.TS_ItensPedido.ResumeLayout(false);
            this.TS_ItensPedido.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados3.ResumeLayout(false);
            this.panelDados3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.DataGridDefault dataGridDefault1;
        private Componentes.PanelDados panelDados2;
        private Componentes.PanelDados panelDados3;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditFloat Quantidade;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDown_Relatorios;
        private System.Windows.Forms.ToolStripMenuItem tmRelEstoque;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        public System.Windows.Forms.ToolStrip barraMenu;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.ToolStrip TS_ItensPedido;
        private System.Windows.Forms.ToolStripButton btn_Deleta_Item;
        private System.Windows.Forms.BindingSource bsCodBarra;
        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_codbarra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_venda;
        private System.Windows.Forms.DataGridViewTextBoxColumn uni;
    }
}