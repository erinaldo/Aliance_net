namespace Faturamento
{
    partial class TFItemCompraAvulsa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItemCompraAvulsa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Lbl_Produto = new System.Windows.Forms.Label();
            this.bb_novoproduto = new System.Windows.Forms.Button();
            this.RG_Data = new Componentes.RadioGroup(this.components);
            this.pValores = new Componentes.PanelDados(this.components);
            this.Vl_Despesas = new Componentes.EditFloat(this.components);
            this.bsItensCompra = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.VL_Desconto = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.Pc_DescontoItem = new Componentes.EditFloat(this.components);
            this.VL_Total = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.Sub_Total = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.Vl_Unitario = new Componentes.EditFloat(this.components);
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.RG_Data.SuspendLayout();
            this.pValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Despesas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Desconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pc_DescontoItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(586, 43);
            this.barraMenu.TabIndex = 10;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.Lbl_Produto);
            this.pDados.Controls.Add(this.bb_novoproduto);
            this.pDados.Controls.Add(this.RG_Data);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(586, 212);
            this.pDados.TabIndex = 11;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItensCompra, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Produto.Location = new System.Drawing.Point(80, 64);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_FUNCAO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.Size = new System.Drawing.Size(493, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = true;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 114;
            this.DS_Produto.TextOld = null;
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItensCompra, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CD_Produto.Location = new System.Drawing.Point(80, 29);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(454, 29);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = false;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 111;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CD_Produto_KeyDown);
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(78, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(452, 13);
            this.label3.TabIndex = 113;
            this.label3.Text = "Localiza produto por codigo interno, codigo de barras, codigo referencia ou parte" +
                " da descrição";
            // 
            // Lbl_Produto
            // 
            this.Lbl_Produto.AutoSize = true;
            this.Lbl_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Lbl_Produto.Location = new System.Drawing.Point(17, 35);
            this.Lbl_Produto.Name = "Lbl_Produto";
            this.Lbl_Produto.Size = new System.Drawing.Size(55, 13);
            this.Lbl_Produto.TabIndex = 112;
            this.Lbl_Produto.Text = "Produto:";
            this.Lbl_Produto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bb_novoproduto
            // 
            this.bb_novoproduto.Image = ((System.Drawing.Image)(resources.GetObject("bb_novoproduto.Image")));
            this.bb_novoproduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_novoproduto.Location = new System.Drawing.Point(540, 29);
            this.bb_novoproduto.Name = "bb_novoproduto";
            this.bb_novoproduto.Size = new System.Drawing.Size(38, 29);
            this.bb_novoproduto.TabIndex = 2;
            this.bb_novoproduto.UseVisualStyleBackColor = true;
            this.bb_novoproduto.Click += new System.EventHandler(this.bb_novoproduto_Click);
            // 
            // RG_Data
            // 
            this.RG_Data.Controls.Add(this.pValores);
            this.RG_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.RG_Data.Location = new System.Drawing.Point(77, 84);
            this.RG_Data.Name = "RG_Data";
            this.RG_Data.NM_Alias = "a";
            this.RG_Data.NM_Campo = "TP_Movimento";
            this.RG_Data.NM_Param = "@P_TP_MOVIMENTO";
            this.RG_Data.NM_Valor = "";
            this.RG_Data.Size = new System.Drawing.Size(504, 119);
            this.RG_Data.ST_Gravar = false;
            this.RG_Data.ST_NotNull = false;
            this.RG_Data.TabIndex = 5;
            this.RG_Data.TabStop = false;
            // 
            // pValores
            // 
            this.pValores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pValores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pValores.Controls.Add(this.Vl_Despesas);
            this.pValores.Controls.Add(this.label1);
            this.pValores.Controls.Add(this.sigla_unidade);
            this.pValores.Controls.Add(this.VL_Desconto);
            this.pValores.Controls.Add(this.label6);
            this.pValores.Controls.Add(this.label60);
            this.pValores.Controls.Add(this.Pc_DescontoItem);
            this.pValores.Controls.Add(this.VL_Total);
            this.pValores.Controls.Add(this.label8);
            this.pValores.Controls.Add(this.Sub_Total);
            this.pValores.Controls.Add(this.label7);
            this.pValores.Controls.Add(this.Vl_Unitario);
            this.pValores.Controls.Add(this.Quantidade);
            this.pValores.Controls.Add(this.label58);
            this.pValores.Controls.Add(this.label59);
            this.pValores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pValores.Location = new System.Drawing.Point(3, 16);
            this.pValores.Name = "pValores";
            this.pValores.NM_ProcDeletar = "";
            this.pValores.NM_ProcGravar = "";
            this.pValores.Size = new System.Drawing.Size(498, 100);
            this.pValores.TabIndex = 0;
            // 
            // Vl_Despesas
            // 
            this.Vl_Despesas.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItensCompra, "Vl_despesas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.Vl_Despesas.DecimalPlaces = 2;
            this.Vl_Despesas.Location = new System.Drawing.Point(423, 40);
            this.Vl_Despesas.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Vl_Despesas.Name = "Vl_Despesas";
            this.Vl_Despesas.NM_Alias = "";
            this.Vl_Despesas.NM_Campo = "Vl_Unitario";
            this.Vl_Despesas.NM_Param = "@P_VL_UNITARIO";
            this.Vl_Despesas.Operador = "";
            this.Vl_Despesas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Vl_Despesas.Size = new System.Drawing.Size(68, 20);
            this.Vl_Despesas.ST_AutoInc = false;
            this.Vl_Despesas.ST_DisableAuto = false;
            this.Vl_Despesas.ST_Gravar = true;
            this.Vl_Despesas.ST_LimparCampo = true;
            this.Vl_Despesas.ST_NotNull = false;
            this.Vl_Despesas.ST_PrimaryKey = false;
            this.Vl_Despesas.TabIndex = 127;
            this.Vl_Despesas.ThousandsSeparator = true;
            this.Vl_Despesas.Leave += new System.EventHandler(this.Vl_Despesas_Leave);
            // 
            // bsItensCompra
            // 
            this.bsItensCompra.DataSource = typeof(CamadaDados.Faturamento.CompraAvulsa.TList_Compra_Itens);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(332, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 128;
            this.label1.Text = "Vl. Despesas:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItensCompra, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sigla_unidade.Location = new System.Drawing.Point(201, 7);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "sigla_unidade";
            this.sigla_unidade.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidade.NM_Param = "@P_DS_FUNCAO";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.ReadOnly = true;
            this.sigla_unidade.Size = new System.Drawing.Size(46, 20);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 126;
            this.sigla_unidade.TextOld = null;
            // 
            // VL_Desconto
            // 
            this.VL_Desconto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItensCompra, "Vl_desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Desconto.DecimalPlaces = 2;
            this.VL_Desconto.Location = new System.Drawing.Point(257, 38);
            this.VL_Desconto.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.VL_Desconto.Name = "VL_Desconto";
            this.VL_Desconto.NM_Alias = "";
            this.VL_Desconto.NM_Campo = "Vl_Unitario";
            this.VL_Desconto.NM_Param = "@P_VL_UNITARIO";
            this.VL_Desconto.Operador = "";
            this.VL_Desconto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VL_Desconto.Size = new System.Drawing.Size(68, 20);
            this.VL_Desconto.ST_AutoInc = false;
            this.VL_Desconto.ST_DisableAuto = false;
            this.VL_Desconto.ST_Gravar = true;
            this.VL_Desconto.ST_LimparCampo = true;
            this.VL_Desconto.ST_NotNull = false;
            this.VL_Desconto.ST_PrimaryKey = false;
            this.VL_Desconto.TabIndex = 3;
            this.VL_Desconto.ThousandsSeparator = true;
            this.VL_Desconto.Leave += new System.EventHandler(this.VL_Desconto_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(167, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 125;
            this.label6.Text = "Vl. Desconto:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label60.Location = new System.Drawing.Point(275, 12);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(78, 13);
            this.label60.TabIndex = 124;
            this.label60.Text = "% Desconto:";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Pc_DescontoItem
            // 
            this.Pc_DescontoItem.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItensCompra, "Pc_desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Pc_DescontoItem.DecimalPlaces = 2;
            this.Pc_DescontoItem.Location = new System.Drawing.Point(355, 10);
            this.Pc_DescontoItem.Name = "Pc_DescontoItem";
            this.Pc_DescontoItem.NM_Alias = "";
            this.Pc_DescontoItem.NM_Campo = "Pc_Desc";
            this.Pc_DescontoItem.NM_Param = "@P_PC_DESC";
            this.Pc_DescontoItem.Operador = "";
            this.Pc_DescontoItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Pc_DescontoItem.Size = new System.Drawing.Size(136, 20);
            this.Pc_DescontoItem.ST_AutoInc = false;
            this.Pc_DescontoItem.ST_DisableAuto = false;
            this.Pc_DescontoItem.ST_Gravar = true;
            this.Pc_DescontoItem.ST_LimparCampo = true;
            this.Pc_DescontoItem.ST_NotNull = false;
            this.Pc_DescontoItem.ST_PrimaryKey = false;
            this.Pc_DescontoItem.TabIndex = 2;
            this.Pc_DescontoItem.ThousandsSeparator = true;
            this.Pc_DescontoItem.Leave += new System.EventHandler(this.Pc_DescontoItem_Leave);
            // 
            // VL_Total
            // 
            this.VL_Total.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItensCompra, "Vl_subtotalliq", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Total.DecimalPlaces = 2;
            this.VL_Total.Enabled = false;
            this.VL_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.VL_Total.Location = new System.Drawing.Point(355, 66);
            this.VL_Total.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.VL_Total.Name = "VL_Total";
            this.VL_Total.NM_Alias = "";
            this.VL_Total.NM_Campo = "Vl_Unitario";
            this.VL_Total.NM_Param = "@P_VL_UNITARIO";
            this.VL_Total.Operador = "";
            this.VL_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VL_Total.Size = new System.Drawing.Size(136, 27);
            this.VL_Total.ST_AutoInc = false;
            this.VL_Total.ST_DisableAuto = false;
            this.VL_Total.ST_Gravar = true;
            this.VL_Total.ST_LimparCampo = true;
            this.VL_Total.ST_NotNull = false;
            this.VL_Total.ST_PrimaryKey = false;
            this.VL_Total.TabIndex = 5;
            this.VL_Total.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(264, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 121;
            this.label8.Text = "Valor Liquido:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Sub_Total
            // 
            this.Sub_Total.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItensCompra, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Sub_Total.DecimalPlaces = 2;
            this.Sub_Total.Enabled = false;
            this.Sub_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Sub_Total.Location = new System.Drawing.Point(108, 66);
            this.Sub_Total.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Sub_Total.Name = "Sub_Total";
            this.Sub_Total.NM_Alias = "";
            this.Sub_Total.NM_Campo = "Vl_Unitario";
            this.Sub_Total.NM_Param = "@P_VL_UNITARIO";
            this.Sub_Total.Operador = "";
            this.Sub_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Sub_Total.Size = new System.Drawing.Size(150, 27);
            this.Sub_Total.ST_AutoInc = false;
            this.Sub_Total.ST_DisableAuto = false;
            this.Sub_Total.ST_Gravar = true;
            this.Sub_Total.ST_LimparCampo = true;
            this.Sub_Total.ST_NotNull = false;
            this.Sub_Total.ST_PrimaryKey = false;
            this.Sub_Total.TabIndex = 4;
            this.Sub_Total.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(6, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 119;
            this.label7.Text = "Valor Sub Total:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Vl_Unitario
            // 
            this.Vl_Unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItensCompra, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Vl_Unitario.DecimalPlaces = 2;
            this.Vl_Unitario.Location = new System.Drawing.Point(91, 38);
            this.Vl_Unitario.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Vl_Unitario.Name = "Vl_Unitario";
            this.Vl_Unitario.NM_Alias = "";
            this.Vl_Unitario.NM_Campo = "Vl_Unitario";
            this.Vl_Unitario.NM_Param = "@P_VL_UNITARIO";
            this.Vl_Unitario.Operador = "";
            this.Vl_Unitario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Vl_Unitario.Size = new System.Drawing.Size(70, 20);
            this.Vl_Unitario.ST_AutoInc = false;
            this.Vl_Unitario.ST_DisableAuto = false;
            this.Vl_Unitario.ST_Gravar = true;
            this.Vl_Unitario.ST_LimparCampo = true;
            this.Vl_Unitario.ST_NotNull = true;
            this.Vl_Unitario.ST_PrimaryKey = false;
            this.Vl_Unitario.TabIndex = 1;
            this.Vl_Unitario.ThousandsSeparator = true;
            this.Vl_Unitario.Leave += new System.EventHandler(this.Vl_Unitario_Leave);
            // 
            // Quantidade
            // 
            this.Quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItensCompra, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Quantidade.DecimalPlaces = 2;
            this.Quantidade.Location = new System.Drawing.Point(91, 7);
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
            this.Quantidade.TabIndex = 0;
            this.Quantidade.ThousandsSeparator = true;
            this.Quantidade.Leave += new System.EventHandler(this.Quantidade_Leave);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label58.Location = new System.Drawing.Point(15, 9);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(76, 13);
            this.label58.TabIndex = 116;
            this.label58.Text = "Quantidade:";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label59.Location = new System.Drawing.Point(17, 40);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(74, 13);
            this.label59.TabIndex = 117;
            this.label59.Text = "Vl. Unitário:";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFItemCompraAvulsa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 255);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItemCompraAvulsa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Compra Avulsa";
            this.Load += new System.EventHandler(this.TFItemCompraAvulsa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItemCompraAvulsa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.RG_Data.ResumeLayout(false);
            this.pValores.ResumeLayout(false);
            this.pValores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Despesas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Desconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pc_DescontoItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.RadioGroup RG_Data;
        private Componentes.PanelDados pValores;
        public Componentes.EditDefault sigla_unidade;
        public Componentes.EditFloat VL_Desconto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label60;
        public Componentes.EditFloat Pc_DescontoItem;
        public Componentes.EditFloat VL_Total;
        private System.Windows.Forms.Label label8;
        public Componentes.EditFloat Sub_Total;
        private System.Windows.Forms.Label label7;
        public Componentes.EditFloat Vl_Unitario;
        public Componentes.EditFloat Quantidade;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.BindingSource bsItensCompra;
        private System.Windows.Forms.Button bb_novoproduto;
        public Componentes.EditFloat Vl_Despesas;
        private System.Windows.Forms.Label label1;
        public Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lbl_Produto;
        public Componentes.EditDefault DS_Produto;
    }
}