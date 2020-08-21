namespace Almoxarifado
{
    partial class TFMovAvulso
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFMovAvulso));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.BB_NovoProduto = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.bsMovimentacao = new System.Windows.Forms.BindingSource(this.components);
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.quantidade = new Componentes.EditFloat(this.components);
            this.tp_movimento = new Componentes.ComboBoxDefault(this.components);
            this.dt_movimento = new Componentes.EditData(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.bb_almox = new System.Windows.Forms.Button();
            this.ds_almoxarifado = new Componentes.EditDefault(this.components);
            this.id_almox = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            cd_empresaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimentacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(30, 6);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(51, 13);
            cd_empresaLabel.TabIndex = 4;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(11, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(70, 13);
            label1.TabIndex = 8;
            label1.Text = "Almoxarifado:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(34, 57);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 12;
            label2.Text = "Produto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(48, 83);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(33, 13);
            label3.TabIndex = 17;
            label3.Text = "Data:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(172, 83);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(62, 13);
            label4.TabIndex = 19;
            label4.Text = "Movimento:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(16, 110);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(65, 13);
            label5.TabIndex = 21;
            label5.Text = "Quantidade:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(13, 136);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(68, 13);
            label6.TabIndex = 24;
            label6.Text = "Observação:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(236, 110);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(61, 13);
            label7.TabIndex = 26;
            label7.Text = "Vl. Unitario:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(409, 110);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(68, 13);
            label8.TabIndex = 28;
            label8.Text = "Vl. SubTotal:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar,
            this.BB_NovoProduto});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(681, 43);
            this.barraMenu.TabIndex = 12;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            // BB_NovoProduto
            // 
            this.BB_NovoProduto.AutoSize = false;
            this.BB_NovoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_NovoProduto.ForeColor = System.Drawing.Color.Green;
            this.BB_NovoProduto.Image = ((System.Drawing.Image)(resources.GetObject("BB_NovoProduto.Image")));
            this.BB_NovoProduto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_NovoProduto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_NovoProduto.Name = "BB_NovoProduto";
            this.BB_NovoProduto.Size = new System.Drawing.Size(95, 40);
            this.BB_NovoProduto.Text = "(F8)\r\nProduto";
            this.BB_NovoProduto.ToolTipText = "Cancelar Operação";
            this.BB_NovoProduto.Click += new System.EventHandler(this.BB_NovoProduto_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(label8);
            this.pDados.Controls.Add(this.vl_subtotal);
            this.pDados.Controls.Add(label7);
            this.pDados.Controls.Add(this.vl_unitario);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.sigla_unidade);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(this.quantidade);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.tp_movimento);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.dt_movimento);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.bb_almox);
            this.pDados.Controls.Add(this.ds_almoxarifado);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.id_almox);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(681, 242);
            this.pDados.TabIndex = 13;
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsMovimentacao, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Enabled = false;
            this.vl_subtotal.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_subtotal.Location = new System.Drawing.Point(483, 107);
            this.vl_subtotal.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_subtotal.Name = "vl_subtotal";
            this.vl_subtotal.NM_Alias = "";
            this.vl_subtotal.NM_Campo = "";
            this.vl_subtotal.NM_Param = "";
            this.vl_subtotal.Operador = "";
            this.vl_subtotal.Size = new System.Drawing.Size(100, 20);
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = true;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = false;
            this.vl_subtotal.ST_PrimaryKey = false;
            this.vl_subtotal.TabIndex = 27;
            this.vl_subtotal.ThousandsSeparator = true;
            this.vl_subtotal.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // bsMovimentacao
            // 
            this.bsMovimentacao.DataSource = typeof(CamadaDados.Almoxarifado.TList_Movimentacao);
            // 
            // vl_unitario
            // 
            this.vl_unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsMovimentacao, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_unitario.DecimalPlaces = 5;
            this.vl_unitario.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_unitario.Location = new System.Drawing.Point(303, 107);
            this.vl_unitario.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_unitario.Name = "vl_unitario";
            this.vl_unitario.NM_Alias = "";
            this.vl_unitario.NM_Campo = "";
            this.vl_unitario.NM_Param = "";
            this.vl_unitario.Operador = "";
            this.vl_unitario.Size = new System.Drawing.Size(100, 20);
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = true;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = true;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.TabIndex = 9;
            this.vl_unitario.ThousandsSeparator = true;
            this.vl_unitario.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_unitario.Leave += new System.EventHandler(this.vl_unitario_Leave);
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(87, 133);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(587, 101);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 10;
            this.ds_observacao.TextOld = null;
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Location = new System.Drawing.Point(189, 107);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "sigla_unidade";
            this.sigla_unidade.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidade.NM_Param = "@P_SIGLA_UNIDADE";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.Size = new System.Drawing.Size(41, 20);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 22;
            this.sigla_unidade.TextOld = null;
            // 
            // quantidade
            // 
            this.quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsMovimentacao, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.quantidade.Location = new System.Drawing.Point(87, 107);
            this.quantidade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.quantidade.Name = "quantidade";
            this.quantidade.NM_Alias = "";
            this.quantidade.NM_Campo = "";
            this.quantidade.NM_Param = "";
            this.quantidade.Operador = "";
            this.quantidade.Size = new System.Drawing.Size(100, 20);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = true;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = true;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 8;
            this.quantidade.ThousandsSeparator = true;
            this.quantidade.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.quantidade.Leave += new System.EventHandler(this.quantidade_Leave);
            // 
            // tp_movimento
            // 
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMovimentacao, "Tp_movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_movimento.FormattingEnabled = true;
            this.tp_movimento.Location = new System.Drawing.Point(240, 80);
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "";
            this.tp_movimento.NM_Campo = "";
            this.tp_movimento.NM_Param = "";
            this.tp_movimento.Size = new System.Drawing.Size(190, 21);
            this.tp_movimento.ST_Gravar = true;
            this.tp_movimento.ST_LimparCampo = true;
            this.tp_movimento.ST_NotNull = true;
            this.tp_movimento.TabIndex = 7;
            // 
            // dt_movimento
            // 
            this.dt_movimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_movimento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Dt_movimentostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_movimento.Location = new System.Drawing.Point(87, 80);
            this.dt_movimento.Mask = "00/00/0000";
            this.dt_movimento.Name = "dt_movimento";
            this.dt_movimento.NM_Alias = "";
            this.dt_movimento.NM_Campo = "";
            this.dt_movimento.NM_CampoBusca = "";
            this.dt_movimento.NM_Param = "";
            this.dt_movimento.Operador = "";
            this.dt_movimento.Size = new System.Drawing.Size(79, 20);
            this.dt_movimento.ST_Gravar = true;
            this.dt_movimento.ST_LimpaCampo = true;
            this.dt_movimento.ST_NotNull = true;
            this.dt_movimento.ST_PrimaryKey = false;
            this.dt_movimento.TabIndex = 6;
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(188, 54);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 5;
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(222, 54);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_NM_EMPRESA";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(452, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 15;
            this.ds_produto.TextOld = null;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Location = new System.Drawing.Point(87, 54);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(100, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 4;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // bb_almox
            // 
            this.bb_almox.BackColor = System.Drawing.SystemColors.Control;
            this.bb_almox.Image = ((System.Drawing.Image)(resources.GetObject("bb_almox.Image")));
            this.bb_almox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_almox.Location = new System.Drawing.Point(188, 29);
            this.bb_almox.Name = "bb_almox";
            this.bb_almox.Size = new System.Drawing.Size(28, 19);
            this.bb_almox.TabIndex = 3;
            this.bb_almox.UseVisualStyleBackColor = false;
            this.bb_almox.Click += new System.EventHandler(this.bb_almox_Click);
            // 
            // ds_almoxarifado
            // 
            this.ds_almoxarifado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_almoxarifado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_almoxarifado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_almoxarifado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Ds_almoxarifado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_almoxarifado.Enabled = false;
            this.ds_almoxarifado.Location = new System.Drawing.Point(222, 29);
            this.ds_almoxarifado.Name = "ds_almoxarifado";
            this.ds_almoxarifado.NM_Alias = "";
            this.ds_almoxarifado.NM_Campo = "ds_almoxarifado";
            this.ds_almoxarifado.NM_CampoBusca = "ds_almoxarifado";
            this.ds_almoxarifado.NM_Param = "@P_NM_EMPRESA";
            this.ds_almoxarifado.QTD_Zero = 0;
            this.ds_almoxarifado.Size = new System.Drawing.Size(452, 20);
            this.ds_almoxarifado.ST_AutoInc = false;
            this.ds_almoxarifado.ST_DisableAuto = false;
            this.ds_almoxarifado.ST_Float = false;
            this.ds_almoxarifado.ST_Gravar = false;
            this.ds_almoxarifado.ST_Int = false;
            this.ds_almoxarifado.ST_LimpaCampo = true;
            this.ds_almoxarifado.ST_NotNull = false;
            this.ds_almoxarifado.ST_PrimaryKey = false;
            this.ds_almoxarifado.TabIndex = 11;
            this.ds_almoxarifado.TextOld = null;
            // 
            // id_almox
            // 
            this.id_almox.BackColor = System.Drawing.SystemColors.Window;
            this.id_almox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Id_almoxstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_almox.Location = new System.Drawing.Point(87, 29);
            this.id_almox.Name = "id_almox";
            this.id_almox.NM_Alias = "";
            this.id_almox.NM_Campo = "id_almox";
            this.id_almox.NM_CampoBusca = "id_almox";
            this.id_almox.NM_Param = "@P_CD_EMPRESA";
            this.id_almox.QTD_Zero = 0;
            this.id_almox.Size = new System.Drawing.Size(100, 20);
            this.id_almox.ST_AutoInc = false;
            this.id_almox.ST_DisableAuto = false;
            this.id_almox.ST_Float = false;
            this.id_almox.ST_Gravar = true;
            this.id_almox.ST_Int = false;
            this.id_almox.ST_LimpaCampo = true;
            this.id_almox.ST_NotNull = true;
            this.id_almox.ST_PrimaryKey = false;
            this.id_almox.TabIndex = 2;
            this.id_almox.TextOld = null;
            this.id_almox.Leave += new System.EventHandler(this.id_almox_Leave);
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(188, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(222, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(452, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 7;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(87, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(100, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // TFMovAvulso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 285);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFMovAvulso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimentação Avulsa Almoxarifado";
            this.Load += new System.EventHandler(this.TFMovAvulso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFMovAvulso_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimentacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_observacao;
        private Componentes.EditDefault sigla_unidade;
        private Componentes.EditFloat quantidade;
        private Componentes.ComboBoxDefault tp_movimento;
        private Componentes.EditData dt_movimento;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Button bb_almox;
        private Componentes.EditDefault ds_almoxarifado;
        private Componentes.EditDefault id_almox;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.BindingSource bsMovimentacao;
        private Componentes.EditFloat vl_subtotal;
        private Componentes.EditFloat vl_unitario;
        public System.Windows.Forms.ToolStripButton BB_NovoProduto;
    }
}