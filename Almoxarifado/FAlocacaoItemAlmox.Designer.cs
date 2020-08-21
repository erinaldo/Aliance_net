namespace Almoxarifado
{
    partial class TFAlocacaoItemAlmox
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAlocacaoItemAlmox));
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pPedido = new Componentes.PanelDados(this.components);
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nr_pedido = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tlpItens = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gPedidoItens = new Componentes.DataGridDefault(this.components);
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgunidadeestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd_alocada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsItensPedido = new System.Windows.Forms.BindingSource(this.components);
            this.TS_Conferencia = new System.Windows.Forms.ToolStrip();
            this.bb_alocar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pAlocacao = new Componentes.PanelDados(this.components);
            this.id_rua = new Componentes.EditDefault(this.components);
            this.bsAlocacao = new System.Windows.Forms.BindingSource(this.components);
            this.ds_rua = new Componentes.EditDefault(this.components);
            this.id_secao = new Componentes.EditDefault(this.components);
            this.ds_secao = new Componentes.EditDefault(this.components);
            this.id_celula = new Componentes.EditDefault(this.components);
            this.ds_celula = new Componentes.EditDefault(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.id_almox = new Componentes.EditDefault(this.components);
            this.ds_almoxarifado = new Componentes.EditDefault(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tlpCentral.SuspendLayout();
            this.pPedido.SuspendLayout();
            this.tlpItens.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPedidoItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensPedido)).BeginInit();
            this.TS_Conferencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pAlocacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAlocacao)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pPedido, 0, 0);
            this.tlpCentral.Controls.Add(this.tlpItens, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(952, 552);
            this.tlpCentral.TabIndex = 0;
            // 
            // pPedido
            // 
            this.pPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPedido.Controls.Add(this.nm_clifor);
            this.pPedido.Controls.Add(this.cd_clifor);
            this.pPedido.Controls.Add(this.label3);
            this.pPedido.Controls.Add(this.nm_empresa);
            this.pPedido.Controls.Add(this.cd_empresa);
            this.pPedido.Controls.Add(this.label2);
            this.pPedido.Controls.Add(this.nr_pedido);
            this.pPedido.Controls.Add(this.label1);
            this.pPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPedido.Location = new System.Drawing.Point(5, 5);
            this.pPedido.Name = "pPedido";
            this.pPedido.NM_ProcDeletar = "";
            this.pPedido.NM_ProcGravar = "";
            this.pPedido.Size = new System.Drawing.Size(942, 81);
            this.pPedido.TabIndex = 0;
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Location = new System.Drawing.Point(160, 55);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "";
            this.nm_clifor.NM_CampoBusca = "";
            this.nm_clifor.NM_Param = "";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(378, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 7;
            this.nm_clifor.TextOld = null;
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.Enabled = false;
            this.cd_clifor.Location = new System.Drawing.Point(84, 55);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "";
            this.cd_clifor.NM_Campo = "";
            this.cd_clifor.NM_CampoBusca = "";
            this.cd_clifor.NM_Param = "";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(73, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = false;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = false;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 6;
            this.cd_clifor.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fornecedor:";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(160, 29);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "";
            this.nm_empresa.NM_CampoBusca = "";
            this.nm_empresa.NM_Param = "";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(378, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 4;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(84, 29);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "";
            this.cd_empresa.NM_CampoBusca = "";
            this.cd_empresa.NM_Param = "";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(73, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 3;
            this.cd_empresa.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Empresa:";
            // 
            // nr_pedido
            // 
            this.nr_pedido.BackColor = System.Drawing.SystemColors.Window;
            this.nr_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_pedido.Location = new System.Drawing.Point(84, 3);
            this.nr_pedido.Name = "nr_pedido";
            this.nr_pedido.NM_Alias = "";
            this.nr_pedido.NM_Campo = "";
            this.nr_pedido.NM_CampoBusca = "";
            this.nr_pedido.NM_Param = "";
            this.nr_pedido.QTD_Zero = 0;
            this.nr_pedido.Size = new System.Drawing.Size(73, 20);
            this.nr_pedido.ST_AutoInc = false;
            this.nr_pedido.ST_DisableAuto = false;
            this.nr_pedido.ST_Float = false;
            this.nr_pedido.ST_Gravar = false;
            this.nr_pedido.ST_Int = true;
            this.nr_pedido.ST_LimpaCampo = true;
            this.nr_pedido.ST_NotNull = false;
            this.nr_pedido.ST_PrimaryKey = false;
            this.nr_pedido.TabIndex = 0;
            this.nr_pedido.TextOld = null;
            this.nr_pedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nr_pedido_KeyDown);
            this.nr_pedido.Leave += new System.EventHandler(this.nr_pedido_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pedido:";
            // 
            // tlpItens
            // 
            this.tlpItens.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpItens.ColumnCount = 1;
            this.tlpItens.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItens.Controls.Add(this.panelDados1, 0, 0);
            this.tlpItens.Controls.Add(this.pAlocacao, 0, 1);
            this.tlpItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpItens.Location = new System.Drawing.Point(5, 94);
            this.tlpItens.Name = "tlpItens";
            this.tlpItens.RowCount = 2;
            this.tlpItens.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItens.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tlpItens.Size = new System.Drawing.Size(942, 453);
            this.tlpItens.TabIndex = 1;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.gPedidoItens);
            this.panelDados1.Controls.Add(this.TS_Conferencia);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 5);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(932, 312);
            this.panelDados1.TabIndex = 1;
            // 
            // gPedidoItens
            // 
            this.gPedidoItens.AllowUserToAddRows = false;
            this.gPedidoItens.AllowUserToDeleteRows = false;
            this.gPedidoItens.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPedidoItens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gPedidoItens.AutoGenerateColumns = false;
            this.gPedidoItens.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPedidoItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPedidoItens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPedidoItens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gPedidoItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPedidoItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.sgunidadeestDataGridViewTextBoxColumn,
            this.Qtd_alocada});
            this.gPedidoItens.DataSource = this.bsItensPedido;
            this.gPedidoItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gPedidoItens.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPedidoItens.Location = new System.Drawing.Point(0, 25);
            this.gPedidoItens.Name = "gPedidoItens";
            this.gPedidoItens.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPedidoItens.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gPedidoItens.RowHeadersWidth = 23;
            this.gPedidoItens.Size = new System.Drawing.Size(928, 258);
            this.gPedidoItens.TabIndex = 0;
            this.gPedidoItens.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gPedidoItens_CellContentClick);
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
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // sgunidadeestDataGridViewTextBoxColumn
            // 
            this.sgunidadeestDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sgunidadeestDataGridViewTextBoxColumn.DataPropertyName = "Sg_unidade_est";
            this.sgunidadeestDataGridViewTextBoxColumn.HeaderText = "UND";
            this.sgunidadeestDataGridViewTextBoxColumn.Name = "sgunidadeestDataGridViewTextBoxColumn";
            this.sgunidadeestDataGridViewTextBoxColumn.ReadOnly = true;
            this.sgunidadeestDataGridViewTextBoxColumn.Width = 56;
            // 
            // Qtd_alocada
            // 
            this.Qtd_alocada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Qtd_alocada.DataPropertyName = "Qtd_conferida";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = "0";
            this.Qtd_alocada.DefaultCellStyle = dataGridViewCellStyle3;
            this.Qtd_alocada.HeaderText = "Qtd. Alocada";
            this.Qtd_alocada.Name = "Qtd_alocada";
            this.Qtd_alocada.ReadOnly = true;
            this.Qtd_alocada.Width = 94;
            // 
            // bsItensPedido
            // 
            this.bsItensPedido.DataSource = typeof(CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item);
            this.bsItensPedido.PositionChanged += new System.EventHandler(this.bsItensPedido_PositionChanged);
            // 
            // TS_Conferencia
            // 
            this.TS_Conferencia.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_alocar,
            this.bb_cancelar});
            this.TS_Conferencia.Location = new System.Drawing.Point(0, 0);
            this.TS_Conferencia.Name = "TS_Conferencia";
            this.TS_Conferencia.Size = new System.Drawing.Size(928, 25);
            this.TS_Conferencia.TabIndex = 33;
            // 
            // bb_alocar
            // 
            this.bb_alocar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_alocar.Image = ((System.Drawing.Image)(resources.GetObject("bb_alocar.Image")));
            this.bb_alocar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_alocar.Name = "bb_alocar";
            this.bb_alocar.Size = new System.Drawing.Size(132, 22);
            this.bb_alocar.Text = "(CTRL + F2) Alocar";
            this.bb_alocar.ToolTipText = "Alocar Item Almoxarifado";
            this.bb_alocar.Click += new System.EventHandler(this.bb_alocar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(145, 22);
            this.bb_cancelar.Text = "(CTRL + F5) Cancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Alocação";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsItensPedido;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 283);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(928, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
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
            // pAlocacao
            // 
            this.pAlocacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAlocacao.Controls.Add(this.id_rua);
            this.pAlocacao.Controls.Add(this.ds_rua);
            this.pAlocacao.Controls.Add(this.id_secao);
            this.pAlocacao.Controls.Add(this.ds_secao);
            this.pAlocacao.Controls.Add(this.id_celula);
            this.pAlocacao.Controls.Add(this.ds_celula);
            this.pAlocacao.Controls.Add(this.label13);
            this.pAlocacao.Controls.Add(this.label14);
            this.pAlocacao.Controls.Add(this.label15);
            this.pAlocacao.Controls.Add(this.id_almox);
            this.pAlocacao.Controls.Add(this.ds_almoxarifado);
            this.pAlocacao.Controls.Add(this.label17);
            this.pAlocacao.Controls.Add(this.label4);
            this.pAlocacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAlocacao.Location = new System.Drawing.Point(5, 325);
            this.pAlocacao.Name = "pAlocacao";
            this.pAlocacao.NM_ProcDeletar = "";
            this.pAlocacao.NM_ProcGravar = "";
            this.pAlocacao.Size = new System.Drawing.Size(932, 123);
            this.pAlocacao.TabIndex = 1;
            // 
            // id_rua
            // 
            this.id_rua.BackColor = System.Drawing.SystemColors.Window;
            this.id_rua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAlocacao, "Id_rua", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_rua.Enabled = false;
            this.id_rua.Location = new System.Drawing.Point(57, 49);
            this.id_rua.Name = "id_rua";
            this.id_rua.NM_Alias = "";
            this.id_rua.NM_Campo = "id_rua";
            this.id_rua.NM_CampoBusca = "id_rua";
            this.id_rua.NM_Param = "@P_ID_RUA";
            this.id_rua.QTD_Zero = 0;
            this.id_rua.Size = new System.Drawing.Size(45, 20);
            this.id_rua.ST_AutoInc = false;
            this.id_rua.ST_DisableAuto = false;
            this.id_rua.ST_Float = false;
            this.id_rua.ST_Gravar = false;
            this.id_rua.ST_Int = false;
            this.id_rua.ST_LimpaCampo = true;
            this.id_rua.ST_NotNull = false;
            this.id_rua.ST_PrimaryKey = false;
            this.id_rua.TabIndex = 142;
            this.id_rua.TextOld = null;
            // 
            // bsAlocacao
            // 
            this.bsAlocacao.DataMember = "EntregaPedido";
            this.bsAlocacao.DataSource = this.bsItensPedido;
            // 
            // ds_rua
            // 
            this.ds_rua.BackColor = System.Drawing.Color.White;
            this.ds_rua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAlocacao, "Ds_rua", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_rua.Enabled = false;
            this.ds_rua.Location = new System.Drawing.Point(105, 49);
            this.ds_rua.Name = "ds_rua";
            this.ds_rua.NM_Alias = "";
            this.ds_rua.NM_Campo = "ds_rua";
            this.ds_rua.NM_CampoBusca = "ds_rua";
            this.ds_rua.NM_Param = "@P_DS_RUA";
            this.ds_rua.QTD_Zero = 0;
            this.ds_rua.Size = new System.Drawing.Size(428, 20);
            this.ds_rua.ST_AutoInc = false;
            this.ds_rua.ST_DisableAuto = false;
            this.ds_rua.ST_Float = false;
            this.ds_rua.ST_Gravar = false;
            this.ds_rua.ST_Int = false;
            this.ds_rua.ST_LimpaCampo = true;
            this.ds_rua.ST_NotNull = false;
            this.ds_rua.ST_PrimaryKey = false;
            this.ds_rua.TabIndex = 152;
            this.ds_rua.TextOld = null;
            // 
            // id_secao
            // 
            this.id_secao.BackColor = System.Drawing.SystemColors.Window;
            this.id_secao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_secao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAlocacao, "Id_secao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_secao.Enabled = false;
            this.id_secao.Location = new System.Drawing.Point(57, 72);
            this.id_secao.Name = "id_secao";
            this.id_secao.NM_Alias = "";
            this.id_secao.NM_Campo = "id_secao";
            this.id_secao.NM_CampoBusca = "id_secao";
            this.id_secao.NM_Param = "@P_ID_SECAO";
            this.id_secao.QTD_Zero = 0;
            this.id_secao.Size = new System.Drawing.Size(45, 20);
            this.id_secao.ST_AutoInc = false;
            this.id_secao.ST_DisableAuto = false;
            this.id_secao.ST_Float = false;
            this.id_secao.ST_Gravar = false;
            this.id_secao.ST_Int = false;
            this.id_secao.ST_LimpaCampo = true;
            this.id_secao.ST_NotNull = false;
            this.id_secao.ST_PrimaryKey = false;
            this.id_secao.TabIndex = 143;
            this.id_secao.TextOld = null;
            // 
            // ds_secao
            // 
            this.ds_secao.BackColor = System.Drawing.Color.White;
            this.ds_secao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_secao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAlocacao, "Ds_secao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_secao.Enabled = false;
            this.ds_secao.Location = new System.Drawing.Point(105, 72);
            this.ds_secao.Name = "ds_secao";
            this.ds_secao.NM_Alias = "";
            this.ds_secao.NM_Campo = "ds_secao";
            this.ds_secao.NM_CampoBusca = "ds_secao";
            this.ds_secao.NM_Param = "@P_DS_SECAO";
            this.ds_secao.QTD_Zero = 0;
            this.ds_secao.Size = new System.Drawing.Size(428, 20);
            this.ds_secao.ST_AutoInc = false;
            this.ds_secao.ST_DisableAuto = false;
            this.ds_secao.ST_Float = false;
            this.ds_secao.ST_Gravar = false;
            this.ds_secao.ST_Int = false;
            this.ds_secao.ST_LimpaCampo = true;
            this.ds_secao.ST_NotNull = false;
            this.ds_secao.ST_PrimaryKey = false;
            this.ds_secao.TabIndex = 151;
            this.ds_secao.TextOld = null;
            // 
            // id_celula
            // 
            this.id_celula.BackColor = System.Drawing.SystemColors.Window;
            this.id_celula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_celula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_celula.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAlocacao, "Id_celula", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_celula.Enabled = false;
            this.id_celula.Location = new System.Drawing.Point(57, 97);
            this.id_celula.Name = "id_celula";
            this.id_celula.NM_Alias = "";
            this.id_celula.NM_Campo = "id_nivel";
            this.id_celula.NM_CampoBusca = "id_nivel";
            this.id_celula.NM_Param = "@P_ID_NIVEL";
            this.id_celula.QTD_Zero = 0;
            this.id_celula.Size = new System.Drawing.Size(45, 20);
            this.id_celula.ST_AutoInc = false;
            this.id_celula.ST_DisableAuto = false;
            this.id_celula.ST_Float = false;
            this.id_celula.ST_Gravar = false;
            this.id_celula.ST_Int = false;
            this.id_celula.ST_LimpaCampo = true;
            this.id_celula.ST_NotNull = false;
            this.id_celula.ST_PrimaryKey = false;
            this.id_celula.TabIndex = 144;
            this.id_celula.TextOld = null;
            // 
            // ds_celula
            // 
            this.ds_celula.BackColor = System.Drawing.Color.White;
            this.ds_celula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_celula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_celula.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAlocacao, "Ds_celula", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_celula.Enabled = false;
            this.ds_celula.Location = new System.Drawing.Point(105, 97);
            this.ds_celula.Name = "ds_celula";
            this.ds_celula.NM_Alias = "";
            this.ds_celula.NM_Campo = "ds_nivel";
            this.ds_celula.NM_CampoBusca = "ds_nivel";
            this.ds_celula.NM_Param = "@P_DS_NIVEL";
            this.ds_celula.QTD_Zero = 0;
            this.ds_celula.Size = new System.Drawing.Size(428, 20);
            this.ds_celula.ST_AutoInc = false;
            this.ds_celula.ST_DisableAuto = false;
            this.ds_celula.ST_Float = false;
            this.ds_celula.ST_Gravar = false;
            this.ds_celula.ST_Int = false;
            this.ds_celula.ST_LimpaCampo = true;
            this.ds_celula.ST_NotNull = false;
            this.ds_celula.ST_PrimaryKey = false;
            this.ds_celula.TabIndex = 150;
            this.ds_celula.TextOld = null;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 149;
            this.label13.Text = "Rua:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 148;
            this.label14.Text = "Seção:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 147;
            this.label15.Text = "Celula:";
            // 
            // id_almox
            // 
            this.id_almox.BackColor = System.Drawing.SystemColors.Window;
            this.id_almox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAlocacao, "Id_almoxstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_almox.Enabled = false;
            this.id_almox.Location = new System.Drawing.Point(57, 23);
            this.id_almox.Name = "id_almox";
            this.id_almox.NM_Alias = "";
            this.id_almox.NM_Campo = "id_almox";
            this.id_almox.NM_CampoBusca = "id_almox";
            this.id_almox.NM_Param = "@P_ID_ALMOX";
            this.id_almox.QTD_Zero = 0;
            this.id_almox.Size = new System.Drawing.Size(45, 20);
            this.id_almox.ST_AutoInc = false;
            this.id_almox.ST_DisableAuto = false;
            this.id_almox.ST_Float = false;
            this.id_almox.ST_Gravar = false;
            this.id_almox.ST_Int = false;
            this.id_almox.ST_LimpaCampo = true;
            this.id_almox.ST_NotNull = true;
            this.id_almox.ST_PrimaryKey = false;
            this.id_almox.TabIndex = 140;
            this.id_almox.TextOld = null;
            // 
            // ds_almoxarifado
            // 
            this.ds_almoxarifado.BackColor = System.Drawing.Color.White;
            this.ds_almoxarifado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_almoxarifado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_almoxarifado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAlocacao, "Ds_almoxarifado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_almoxarifado.Enabled = false;
            this.ds_almoxarifado.Location = new System.Drawing.Point(105, 23);
            this.ds_almoxarifado.Name = "ds_almoxarifado";
            this.ds_almoxarifado.NM_Alias = "";
            this.ds_almoxarifado.NM_Campo = "ds_almoxarifado";
            this.ds_almoxarifado.NM_CampoBusca = "ds_almoxarifado";
            this.ds_almoxarifado.NM_Param = "@P_DS_ALMOXARIFADO";
            this.ds_almoxarifado.QTD_Zero = 0;
            this.ds_almoxarifado.Size = new System.Drawing.Size(428, 20);
            this.ds_almoxarifado.ST_AutoInc = false;
            this.ds_almoxarifado.ST_DisableAuto = false;
            this.ds_almoxarifado.ST_Float = false;
            this.ds_almoxarifado.ST_Gravar = false;
            this.ds_almoxarifado.ST_Int = false;
            this.ds_almoxarifado.ST_LimpaCampo = true;
            this.ds_almoxarifado.ST_NotNull = false;
            this.ds_almoxarifado.ST_PrimaryKey = false;
            this.ds_almoxarifado.TabIndex = 146;
            this.ds_almoxarifado.TextOld = null;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 145;
            this.label17.Text = "Almox.:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(930, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "ALOCAÇÃO ITEM ALMOXARIFADO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TFAlocacaoItemAlmox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 552);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAlocacaoItemAlmox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alocação Itens Almoxarifado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFAlocacaoItemAlmox_FormClosing);
            this.Load += new System.EventHandler(this.TFAlocacaoItemAlmox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAlocacaoItemAlmox_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.pPedido.ResumeLayout(false);
            this.pPedido.PerformLayout();
            this.tlpItens.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPedidoItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensPedido)).EndInit();
            this.TS_Conferencia.ResumeLayout(false);
            this.TS_Conferencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pAlocacao.ResumeLayout(false);
            this.pAlocacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAlocacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pPedido;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault nr_pedido;
        private Componentes.EditDefault nm_clifor;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label2;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gPedidoItens;
        private System.Windows.Forms.BindingSource bsItensPedido;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.PanelDados pAlocacao;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault id_rua;
        private Componentes.EditDefault ds_rua;
        private Componentes.EditDefault id_secao;
        private Componentes.EditDefault ds_secao;
        private Componentes.EditDefault id_celula;
        private Componentes.EditDefault ds_celula;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private Componentes.EditDefault id_almox;
        private Componentes.EditDefault ds_almoxarifado;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TableLayoutPanel tlpItens;
        private System.Windows.Forms.ToolStrip TS_Conferencia;
        private System.Windows.Forms.ToolStripButton bb_alocar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.BindingSource bsAlocacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgunidadeestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd_alocada;
    }
}