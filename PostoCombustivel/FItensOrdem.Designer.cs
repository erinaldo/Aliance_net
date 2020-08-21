namespace PostoCombustivel
{
    partial class TFItensOrdem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItensOrdem));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.pValores = new Componentes.PanelDados(this.components);
            this.dias_validade = new Componentes.EditFloat(this.components);
            this.bsItens = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.km_validade = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.quantidade = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ds_local = new Componentes.EditDefault(this.components);
            this.bb_local = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_local = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dias_validade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_validade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(578, 43);
            this.barraMenu.TabIndex = 13;
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
            this.pDados.Controls.Add(this.pValores);
            this.pDados.Controls.Add(this.ds_local);
            this.pDados.Controls.Add(this.bb_local);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_local);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(578, 147);
            this.pDados.TabIndex = 14;
            // 
            // pValores
            // 
            this.pValores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pValores.Controls.Add(this.dias_validade);
            this.pValores.Controls.Add(this.label7);
            this.pValores.Controls.Add(this.km_validade);
            this.pValores.Controls.Add(this.label6);
            this.pValores.Controls.Add(this.vl_subtotal);
            this.pValores.Controls.Add(this.label5);
            this.pValores.Controls.Add(this.sigla_unidade);
            this.pValores.Controls.Add(this.vl_unitario);
            this.pValores.Controls.Add(this.label4);
            this.pValores.Controls.Add(this.quantidade);
            this.pValores.Controls.Add(this.label3);
            this.pValores.Location = new System.Drawing.Point(64, 55);
            this.pValores.Name = "pValores";
            this.pValores.NM_ProcDeletar = "";
            this.pValores.NM_ProcGravar = "";
            this.pValores.Size = new System.Drawing.Size(509, 86);
            this.pValores.TabIndex = 4;
            // 
            // dias_validade
            // 
            this.dias_validade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItens, "Dias_validade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dias_validade.Location = new System.Drawing.Point(132, 58);
            this.dias_validade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.dias_validade.Name = "dias_validade";
            this.dias_validade.NM_Alias = "";
            this.dias_validade.NM_Campo = "";
            this.dias_validade.NM_Param = "";
            this.dias_validade.Operador = "";
            this.dias_validade.Size = new System.Drawing.Size(120, 20);
            this.dias_validade.ST_AutoInc = false;
            this.dias_validade.ST_DisableAuto = false;
            this.dias_validade.ST_Gravar = true;
            this.dias_validade.ST_LimparCampo = true;
            this.dias_validade.ST_NotNull = false;
            this.dias_validade.ST_PrimaryKey = false;
            this.dias_validade.TabIndex = 4;
            this.dias_validade.ThousandsSeparator = true;
            // 
            // bsItens
            // 
            this.bsItens.DataSource = typeof(CamadaDados.PostoCombustivel.TList_ItensOrdemServico);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(129, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Validade - Dias";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // km_validade
            // 
            this.km_validade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItens, "Km_validade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.km_validade.Location = new System.Drawing.Point(6, 58);
            this.km_validade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.km_validade.Name = "km_validade";
            this.km_validade.NM_Alias = "";
            this.km_validade.NM_Campo = "";
            this.km_validade.NM_Param = "";
            this.km_validade.Operador = "";
            this.km_validade.Size = new System.Drawing.Size(120, 20);
            this.km_validade.ST_AutoInc = false;
            this.km_validade.ST_DisableAuto = false;
            this.km_validade.ST_Gravar = true;
            this.km_validade.ST_LimparCampo = true;
            this.km_validade.ST_NotNull = false;
            this.km_validade.ST_PrimaryKey = false;
            this.km_validade.TabIndex = 3;
            this.km_validade.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Validade - KM";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItens, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Enabled = false;
            this.vl_subtotal.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_subtotal.Location = new System.Drawing.Point(295, 19);
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
            this.vl_subtotal.Size = new System.Drawing.Size(120, 20);
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = true;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = true;
            this.vl_subtotal.ST_PrimaryKey = false;
            this.vl_subtotal.TabIndex = 2;
            this.vl_subtotal.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(292, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "SubTotal";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Location = new System.Drawing.Point(128, 19);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "sigla_unidade";
            this.sigla_unidade.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidade.NM_Param = "@P_SIGLA_UNIDADE";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.Size = new System.Drawing.Size(35, 20);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 46;
            // 
            // vl_unitario
            // 
            this.vl_unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItens, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_unitario.DecimalPlaces = 5;
            this.vl_unitario.Location = new System.Drawing.Point(169, 19);
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
            this.vl_unitario.Size = new System.Drawing.Size(120, 20);
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = true;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = true;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.TabIndex = 1;
            this.vl_unitario.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(166, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Vl. Unitario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // quantidade
            // 
            this.quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItens, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Location = new System.Drawing.Point(6, 19);
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
            this.quantidade.Size = new System.Drawing.Size(120, 20);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = true;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = false;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 0;
            this.quantidade.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Quantidade";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_local.Enabled = false;
            this.ds_local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_local.Location = new System.Drawing.Point(172, 29);
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_NM_EMPRESA";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.ReadOnly = true;
            this.ds_local.Size = new System.Drawing.Size(401, 20);
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = false;
            this.ds_local.ST_Int = false;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = false;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TabIndex = 39;
            // 
            // bb_local
            // 
            this.bb_local.Image = ((System.Drawing.Image)(resources.GetObject("bb_local.Image")));
            this.bb_local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_local.Location = new System.Drawing.Point(141, 29);
            this.bb_local.Name = "bb_local";
            this.bb_local.Size = new System.Drawing.Size(28, 19);
            this.bb_local.TabIndex = 3;
            this.bb_local.UseVisualStyleBackColor = true;
            this.bb_local.Click += new System.EventHandler(this.bb_local_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(-2, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Local Arm.:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_local
            // 
            this.cd_local.BackColor = System.Drawing.SystemColors.Window;
            this.cd_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_local.Location = new System.Drawing.Point(64, 29);
            this.cd_local.Name = "cd_local";
            this.cd_local.NM_Alias = "";
            this.cd_local.NM_Campo = "cd_local";
            this.cd_local.NM_CampoBusca = "cd_local";
            this.cd_local.NM_Param = "@P_CD_EMPRESA";
            this.cd_local.QTD_Zero = 0;
            this.cd_local.Size = new System.Drawing.Size(75, 20);
            this.cd_local.ST_AutoInc = false;
            this.cd_local.ST_DisableAuto = false;
            this.cd_local.ST_Float = false;
            this.cd_local.ST_Gravar = true;
            this.cd_local.ST_Int = true;
            this.cd_local.ST_LimpaCampo = true;
            this.cd_local.ST_NotNull = true;
            this.cd_local.ST_PrimaryKey = false;
            this.cd_local.TabIndex = 2;
            this.cd_local.Leave += new System.EventHandler(this.cd_local_Leave);
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_produto.Location = new System.Drawing.Point(172, 3);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_NM_EMPRESA";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.ReadOnly = true;
            this.ds_produto.Size = new System.Drawing.Size(401, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 35;
            // 
            // bb_produto
            // 
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(141, 3);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 1;
            this.bb_produto.UseVisualStyleBackColor = true;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Produto:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(64, 3);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(75, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 0;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // TFItensOrdem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 190);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItensOrdem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itens Ordem Serviço";
            this.Load += new System.EventHandler(this.TFItensOrdem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensOrdem_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pValores.ResumeLayout(false);
            this.pValores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dias_validade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_validade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsItens;
        private Componentes.EditDefault ds_local;
        private System.Windows.Forms.Button bb_local;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_local;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Button bb_produto;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_produto;
        private Componentes.PanelDados pValores;
        private Componentes.EditFloat vl_subtotal;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault sigla_unidade;
        private Componentes.EditFloat vl_unitario;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat quantidade;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat dias_validade;
        private System.Windows.Forms.Label label7;
        private Componentes.EditFloat km_validade;
        private System.Windows.Forms.Label label6;
    }
}