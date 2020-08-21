namespace Frota
{
    partial class TFAbastAvulso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAbastAvulso));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bb_xmlNFe = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.chave_acesso_nfe = new System.Windows.Forms.ToolStripTextBox();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bbAddFornecedor = new System.Windows.Forms.Button();
            this.bb_abast = new System.Windows.Forms.Button();
            this.tp_pagamento = new Componentes.ComboBoxDefault(this.components);
            this.bsAbastecimento = new System.Windows.Forms.BindingSource(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.bb_fornecedor = new System.Windows.Forms.Button();
            this.nm_fornecedor = new Componentes.EditDefault(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.nr_notafiscal = new Componentes.EditDefault(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.km_atual = new Componentes.EditFloat(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.tp_abastecimento = new Componentes.ComboBoxDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.volume_requisicao = new Componentes.EditFloat(this.components);
            this.dt_requisicao = new Componentes.EditData(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.ds_viagem = new Componentes.EditDefault(this.components);
            this.bb_viagem = new System.Windows.Forms.Button();
            this.id_viagem = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.ds_despesa = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_despesa = new System.Windows.Forms.Button();
            this.id_despesa = new Componentes.EditDefault(this.components);
            this.placa = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_veiculo = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bb_veiculo = new System.Windows.Forms.Button();
            this.id_veiculo = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAbastecimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_atual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume_requisicao)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar,
            this.toolStripSeparator1,
            this.bb_xmlNFe,
            this.toolStripLabel1,
            this.chave_acesso_nfe});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(866, 43);
            this.barraMenu.TabIndex = 18;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // bb_xmlNFe
            // 
            this.bb_xmlNFe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_xmlNFe.ForeColor = System.Drawing.Color.Green;
            this.bb_xmlNFe.Image = ((System.Drawing.Image)(resources.GetObject("bb_xmlNFe.Image")));
            this.bb_xmlNFe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_xmlNFe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_xmlNFe.Name = "bb_xmlNFe";
            this.bb_xmlNFe.Size = new System.Drawing.Size(106, 40);
            this.bb_xmlNFe.Text = "XML NFe\r\nTransportar";
            this.bb_xmlNFe.ToolTipText = "Localizar XML NFe a Transportar";
            this.bb_xmlNFe.Click += new System.EventHandler(this.bb_xmlNFe_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Green;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(117, 40);
            this.toolStripLabel1.Text = "Chave Acesso NFe:";
            // 
            // chave_acesso_nfe
            // 
            this.chave_acesso_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chave_acesso_nfe.MaxLength = 44;
            this.chave_acesso_nfe.Name = "chave_acesso_nfe";
            this.chave_acesso_nfe.Size = new System.Drawing.Size(400, 43);
            this.chave_acesso_nfe.ToolTipText = "Informar Chave Acesso NFe a Pesquisar";
            this.chave_acesso_nfe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chave_acesso_nfe_KeyPress);
            this.chave_acesso_nfe.TextChanged += new System.EventHandler(this.chave_acesso_nfe_TextChanged);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.bbAddFornecedor);
            this.pDados.Controls.Add(this.bb_abast);
            this.pDados.Controls.Add(this.tp_pagamento);
            this.pDados.Controls.Add(this.label16);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.label15);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label14);
            this.pDados.Controls.Add(this.bb_fornecedor);
            this.pDados.Controls.Add(this.nm_fornecedor);
            this.pDados.Controls.Add(this.label13);
            this.pDados.Controls.Add(this.nr_notafiscal);
            this.pDados.Controls.Add(this.label12);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(this.km_atual);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.vl_subtotal);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.vl_unitario);
            this.pDados.Controls.Add(this.tp_abastecimento);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.volume_requisicao);
            this.pDados.Controls.Add(this.dt_requisicao);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.ds_viagem);
            this.pDados.Controls.Add(this.bb_viagem);
            this.pDados.Controls.Add(this.id_viagem);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.ds_despesa);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.bb_despesa);
            this.pDados.Controls.Add(this.id_despesa);
            this.pDados.Controls.Add(this.placa);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_veiculo);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.bb_veiculo);
            this.pDados.Controls.Add(this.id_veiculo);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(866, 269);
            this.pDados.TabIndex = 19;
            // 
            // bbAddFornecedor
            // 
            this.bbAddFornecedor.Image = ((System.Drawing.Image)(resources.GetObject("bbAddFornecedor.Image")));
            this.bbAddFornecedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbAddFornecedor.Location = new System.Drawing.Point(720, 163);
            this.bbAddFornecedor.Name = "bbAddFornecedor";
            this.bbAddFornecedor.Size = new System.Drawing.Size(28, 20);
            this.bbAddFornecedor.TabIndex = 105;
            this.bbAddFornecedor.UseVisualStyleBackColor = true;
            this.bbAddFornecedor.Click += new System.EventHandler(this.bbAddFornecedor_Click);
            // 
            // bb_abast
            // 
            this.bb_abast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bb_abast.Image = ((System.Drawing.Image)(resources.GetObject("bb_abast.Image")));
            this.bb_abast.Location = new System.Drawing.Point(278, 137);
            this.bb_abast.Name = "bb_abast";
            this.bb_abast.Size = new System.Drawing.Size(27, 20);
            this.bb_abast.TabIndex = 104;
            this.bb_abast.UseVisualStyleBackColor = true;
            this.bb_abast.Click += new System.EventHandler(this.bb_abast_Click);
            // 
            // tp_pagamento
            // 
            this.tp_pagamento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAbastecimento, "Tp_pagamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_pagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_pagamento.Enabled = false;
            this.tp_pagamento.FormattingEnabled = true;
            this.tp_pagamento.Location = new System.Drawing.Point(652, 32);
            this.tp_pagamento.Name = "tp_pagamento";
            this.tp_pagamento.NM_Alias = "";
            this.tp_pagamento.NM_Campo = "";
            this.tp_pagamento.NM_Param = "";
            this.tp_pagamento.Size = new System.Drawing.Size(96, 21);
            this.tp_pagamento.ST_Gravar = true;
            this.tp_pagamento.ST_LimparCampo = true;
            this.tp_pagamento.ST_NotNull = false;
            this.tp_pagamento.TabIndex = 5;
            this.tp_pagamento.EnabledChanged += new System.EventHandler(this.tp_pagamento_EnabledChanged);
            // 
            // bsAbastecimento
            // 
            this.bsAbastecimento.DataSource = typeof(CamadaDados.Frota.TList_AbastVeiculo);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(582, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 88;
            this.label16.Text = "Tipo Pag.:";
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(185, 111);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_DESPESA";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(563, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 87;
            this.ds_produto.TextOld = null;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 86;
            this.label15.Text = "Combustivel:";
            // 
            // bb_produto
            // 
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(151, 111);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 20);
            this.bb_produto.TabIndex = 11;
            this.bb_produto.UseVisualStyleBackColor = true;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Location = new System.Drawing.Point(79, 111);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(72, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 10;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(79, 189);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(669, 73);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 20;
            this.ds_observacao.TextOld = null;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 191);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 83;
            this.label14.Text = "Observação:";
            // 
            // bb_fornecedor
            // 
            this.bb_fornecedor.Image = ((System.Drawing.Image)(resources.GetObject("bb_fornecedor.Image")));
            this.bb_fornecedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_fornecedor.Location = new System.Drawing.Point(691, 163);
            this.bb_fornecedor.Name = "bb_fornecedor";
            this.bb_fornecedor.Size = new System.Drawing.Size(28, 20);
            this.bb_fornecedor.TabIndex = 19;
            this.bb_fornecedor.UseVisualStyleBackColor = true;
            this.bb_fornecedor.Click += new System.EventHandler(this.bb_fornecedor_Click);
            // 
            // nm_fornecedor
            // 
            this.nm_fornecedor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_fornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_fornecedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Nm_fornecedor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_fornecedor.Location = new System.Drawing.Point(260, 163);
            this.nm_fornecedor.Name = "nm_fornecedor";
            this.nm_fornecedor.NM_Alias = "";
            this.nm_fornecedor.NM_Campo = "nm_clifor";
            this.nm_fornecedor.NM_CampoBusca = "nm_clifor";
            this.nm_fornecedor.NM_Param = "@P_PLACA";
            this.nm_fornecedor.QTD_Zero = 0;
            this.nm_fornecedor.Size = new System.Drawing.Size(430, 20);
            this.nm_fornecedor.ST_AutoInc = false;
            this.nm_fornecedor.ST_DisableAuto = false;
            this.nm_fornecedor.ST_Float = false;
            this.nm_fornecedor.ST_Gravar = false;
            this.nm_fornecedor.ST_Int = false;
            this.nm_fornecedor.ST_LimpaCampo = true;
            this.nm_fornecedor.ST_NotNull = false;
            this.nm_fornecedor.ST_PrimaryKey = false;
            this.nm_fornecedor.TabIndex = 18;
            this.nm_fornecedor.TextOld = null;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(190, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 79;
            this.label13.Text = "Fornecedor:";
            // 
            // nr_notafiscal
            // 
            this.nr_notafiscal.BackColor = System.Drawing.SystemColors.Window;
            this.nr_notafiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_notafiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_notafiscal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Nr_notafiscal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_notafiscal.Location = new System.Drawing.Point(79, 163);
            this.nr_notafiscal.Name = "nr_notafiscal";
            this.nr_notafiscal.NM_Alias = "";
            this.nr_notafiscal.NM_Campo = "placa";
            this.nr_notafiscal.NM_CampoBusca = "placa";
            this.nr_notafiscal.NM_Param = "@P_PLACA";
            this.nr_notafiscal.QTD_Zero = 0;
            this.nr_notafiscal.Size = new System.Drawing.Size(105, 20);
            this.nr_notafiscal.ST_AutoInc = false;
            this.nr_notafiscal.ST_DisableAuto = false;
            this.nr_notafiscal.ST_Float = false;
            this.nr_notafiscal.ST_Gravar = false;
            this.nr_notafiscal.ST_Int = false;
            this.nr_notafiscal.ST_LimpaCampo = true;
            this.nr_notafiscal.ST_NotNull = false;
            this.nr_notafiscal.ST_PrimaryKey = false;
            this.nr_notafiscal.TabIndex = 17;
            this.nr_notafiscal.TextOld = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 77;
            this.label12.Text = "Nota Fiscal:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(618, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 76;
            this.label11.Text = "KM Atual:";
            // 
            // km_atual
            // 
            this.km_atual.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAbastecimento, "Km_atual", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.km_atual.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.km_atual.Location = new System.Drawing.Point(677, 137);
            this.km_atual.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.km_atual.Name = "km_atual";
            this.km_atual.NM_Alias = "";
            this.km_atual.NM_Campo = "";
            this.km_atual.NM_Param = "";
            this.km_atual.Operador = "";
            this.km_atual.Size = new System.Drawing.Size(71, 20);
            this.km_atual.ST_AutoInc = false;
            this.km_atual.ST_DisableAuto = false;
            this.km_atual.ST_Gravar = true;
            this.km_atual.ST_LimparCampo = true;
            this.km_atual.ST_NotNull = false;
            this.km_atual.ST_PrimaryKey = false;
            this.km_atual.TabIndex = 16;
            this.km_atual.ThousandsSeparator = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(457, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 74;
            this.label10.Text = "Vl. SubTotal:";
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAbastecimento, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_subtotal.Location = new System.Drawing.Point(530, 137);
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
            this.vl_subtotal.Size = new System.Drawing.Size(75, 20);
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = true;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = true;
            this.vl_subtotal.ST_PrimaryKey = false;
            this.vl_subtotal.TabIndex = 15;
            this.vl_subtotal.ThousandsSeparator = true;
            this.vl_subtotal.Leave += new System.EventHandler(this.vl_subtotal_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(311, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 72;
            this.label9.Text = "Vl. Unitario:";
            // 
            // vl_unitario
            // 
            this.vl_unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAbastecimento, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_unitario.DecimalPlaces = 3;
            this.vl_unitario.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_unitario.Location = new System.Drawing.Point(378, 137);
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
            this.vl_unitario.Size = new System.Drawing.Size(73, 20);
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = true;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = true;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.TabIndex = 14;
            this.vl_unitario.ThousandsSeparator = true;
            this.vl_unitario.Leave += new System.EventHandler(this.vl_unitario_Leave);
            // 
            // tp_abastecimento
            // 
            this.tp_abastecimento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAbastecimento, "Tp_abastecimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_abastecimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_abastecimento.FormattingEnabled = true;
            this.tp_abastecimento.Location = new System.Drawing.Point(652, 7);
            this.tp_abastecimento.Name = "tp_abastecimento";
            this.tp_abastecimento.NM_Alias = "";
            this.tp_abastecimento.NM_Campo = "";
            this.tp_abastecimento.NM_Param = "";
            this.tp_abastecimento.Size = new System.Drawing.Size(96, 21);
            this.tp_abastecimento.ST_Gravar = true;
            this.tp_abastecimento.ST_LimparCampo = true;
            this.tp_abastecimento.ST_NotNull = true;
            this.tp_abastecimento.TabIndex = 2;
            this.tp_abastecimento.SelectedIndexChanged += new System.EventHandler(this.tp_abastecimento_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(582, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 69;
            this.label7.Text = "Tipo Abast.:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = "Volume:";
            // 
            // volume_requisicao
            // 
            this.volume_requisicao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAbastecimento, "Volume", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.volume_requisicao.DecimalPlaces = 3;
            this.volume_requisicao.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.volume_requisicao.Location = new System.Drawing.Point(208, 137);
            this.volume_requisicao.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.volume_requisicao.Name = "volume_requisicao";
            this.volume_requisicao.NM_Alias = "";
            this.volume_requisicao.NM_Campo = "";
            this.volume_requisicao.NM_Param = "";
            this.volume_requisicao.Operador = "";
            this.volume_requisicao.Size = new System.Drawing.Size(68, 20);
            this.volume_requisicao.ST_AutoInc = false;
            this.volume_requisicao.ST_DisableAuto = false;
            this.volume_requisicao.ST_Gravar = true;
            this.volume_requisicao.ST_LimparCampo = true;
            this.volume_requisicao.ST_NotNull = true;
            this.volume_requisicao.ST_PrimaryKey = false;
            this.volume_requisicao.TabIndex = 13;
            this.volume_requisicao.ThousandsSeparator = true;
            this.volume_requisicao.Leave += new System.EventHandler(this.volume_requisicao_Leave);
            // 
            // dt_requisicao
            // 
            this.dt_requisicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_requisicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Dt_abastecimentostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_requisicao.Location = new System.Drawing.Point(79, 137);
            this.dt_requisicao.Mask = "00/00/0000";
            this.dt_requisicao.Name = "dt_requisicao";
            this.dt_requisicao.NM_Alias = "";
            this.dt_requisicao.NM_Campo = "";
            this.dt_requisicao.NM_CampoBusca = "";
            this.dt_requisicao.NM_Param = "";
            this.dt_requisicao.Operador = "";
            this.dt_requisicao.Size = new System.Drawing.Size(72, 20);
            this.dt_requisicao.ST_Gravar = true;
            this.dt_requisicao.ST_LimpaCampo = true;
            this.dt_requisicao.ST_NotNull = true;
            this.dt_requisicao.ST_PrimaryKey = false;
            this.dt_requisicao.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Data:";
            // 
            // ds_viagem
            // 
            this.ds_viagem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_viagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_viagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_viagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_viagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_viagem.Enabled = false;
            this.ds_viagem.Location = new System.Drawing.Point(185, 33);
            this.ds_viagem.Name = "ds_viagem";
            this.ds_viagem.NM_Alias = "";
            this.ds_viagem.NM_Campo = "ds_viagem";
            this.ds_viagem.NM_CampoBusca = "ds_viagem";
            this.ds_viagem.NM_Param = "@P_NM_EMPRESA";
            this.ds_viagem.QTD_Zero = 0;
            this.ds_viagem.Size = new System.Drawing.Size(391, 20);
            this.ds_viagem.ST_AutoInc = false;
            this.ds_viagem.ST_DisableAuto = false;
            this.ds_viagem.ST_Float = false;
            this.ds_viagem.ST_Gravar = false;
            this.ds_viagem.ST_Int = false;
            this.ds_viagem.ST_LimpaCampo = true;
            this.ds_viagem.ST_NotNull = false;
            this.ds_viagem.ST_PrimaryKey = false;
            this.ds_viagem.TabIndex = 64;
            this.ds_viagem.TextOld = null;
            // 
            // bb_viagem
            // 
            this.bb_viagem.Image = ((System.Drawing.Image)(resources.GetObject("bb_viagem.Image")));
            this.bb_viagem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_viagem.Location = new System.Drawing.Point(151, 33);
            this.bb_viagem.Name = "bb_viagem";
            this.bb_viagem.Size = new System.Drawing.Size(28, 20);
            this.bb_viagem.TabIndex = 4;
            this.bb_viagem.UseVisualStyleBackColor = true;
            this.bb_viagem.Click += new System.EventHandler(this.bb_viagem_Click);
            // 
            // id_viagem
            // 
            this.id_viagem.BackColor = System.Drawing.SystemColors.Window;
            this.id_viagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_viagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_viagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Id_viagemstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_viagem.Location = new System.Drawing.Point(79, 33);
            this.id_viagem.Name = "id_viagem";
            this.id_viagem.NM_Alias = "";
            this.id_viagem.NM_Campo = "id_viagem";
            this.id_viagem.NM_CampoBusca = "id_viagem";
            this.id_viagem.NM_Param = "@P_CD_EMPRESA";
            this.id_viagem.QTD_Zero = 0;
            this.id_viagem.Size = new System.Drawing.Size(72, 20);
            this.id_viagem.ST_AutoInc = false;
            this.id_viagem.ST_DisableAuto = false;
            this.id_viagem.ST_Float = false;
            this.id_viagem.ST_Gravar = true;
            this.id_viagem.ST_Int = false;
            this.id_viagem.ST_LimpaCampo = true;
            this.id_viagem.ST_NotNull = false;
            this.id_viagem.ST_PrimaryKey = false;
            this.id_viagem.TabIndex = 3;
            this.id_viagem.TextOld = null;
            this.id_viagem.TextChanged += new System.EventHandler(this.id_viagem_TextChanged);
            this.id_viagem.Leave += new System.EventHandler(this.id_viagem_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "Viagem:";
            // 
            // ds_despesa
            // 
            this.ds_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_despesa.Enabled = false;
            this.ds_despesa.Location = new System.Drawing.Point(185, 85);
            this.ds_despesa.Name = "ds_despesa";
            this.ds_despesa.NM_Alias = "";
            this.ds_despesa.NM_Campo = "ds_despesa";
            this.ds_despesa.NM_CampoBusca = "ds_despesa";
            this.ds_despesa.NM_Param = "@P_DS_DESPESA";
            this.ds_despesa.QTD_Zero = 0;
            this.ds_despesa.Size = new System.Drawing.Size(563, 20);
            this.ds_despesa.ST_AutoInc = false;
            this.ds_despesa.ST_DisableAuto = false;
            this.ds_despesa.ST_Float = false;
            this.ds_despesa.ST_Gravar = false;
            this.ds_despesa.ST_Int = false;
            this.ds_despesa.ST_LimpaCampo = true;
            this.ds_despesa.ST_NotNull = false;
            this.ds_despesa.ST_PrimaryKey = false;
            this.ds_despesa.TabIndex = 62;
            this.ds_despesa.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Despesa:";
            // 
            // bb_despesa
            // 
            this.bb_despesa.Image = ((System.Drawing.Image)(resources.GetObject("bb_despesa.Image")));
            this.bb_despesa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_despesa.Location = new System.Drawing.Point(151, 85);
            this.bb_despesa.Name = "bb_despesa";
            this.bb_despesa.Size = new System.Drawing.Size(28, 20);
            this.bb_despesa.TabIndex = 9;
            this.bb_despesa.UseVisualStyleBackColor = true;
            this.bb_despesa.Click += new System.EventHandler(this.bb_despesa_Click);
            // 
            // id_despesa
            // 
            this.id_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.id_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Id_despesastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_despesa.Location = new System.Drawing.Point(79, 85);
            this.id_despesa.Name = "id_despesa";
            this.id_despesa.NM_Alias = "";
            this.id_despesa.NM_Campo = "id_despesa";
            this.id_despesa.NM_CampoBusca = "id_despesa";
            this.id_despesa.NM_Param = "@P_CD_EMPRESA";
            this.id_despesa.QTD_Zero = 0;
            this.id_despesa.Size = new System.Drawing.Size(72, 20);
            this.id_despesa.ST_AutoInc = false;
            this.id_despesa.ST_DisableAuto = false;
            this.id_despesa.ST_Float = false;
            this.id_despesa.ST_Gravar = true;
            this.id_despesa.ST_Int = false;
            this.id_despesa.ST_LimpaCampo = true;
            this.id_despesa.ST_NotNull = true;
            this.id_despesa.ST_PrimaryKey = false;
            this.id_despesa.TabIndex = 8;
            this.id_despesa.TextOld = null;
            this.id_despesa.Leave += new System.EventHandler(this.id_despesa_Leave);
            // 
            // placa
            // 
            this.placa.BackColor = System.Drawing.SystemColors.Window;
            this.placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.placa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Placa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.placa.Enabled = false;
            this.placa.Location = new System.Drawing.Point(643, 59);
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "placa";
            this.placa.NM_CampoBusca = "placa";
            this.placa.NM_Param = "@P_PLACA";
            this.placa.QTD_Zero = 0;
            this.placa.Size = new System.Drawing.Size(105, 20);
            this.placa.ST_AutoInc = false;
            this.placa.ST_DisableAuto = false;
            this.placa.ST_Float = false;
            this.placa.ST_Gravar = false;
            this.placa.ST_Int = false;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = false;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 60;
            this.placa.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Placa:";
            // 
            // ds_veiculo
            // 
            this.ds_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_veiculo.Enabled = false;
            this.ds_veiculo.Location = new System.Drawing.Point(185, 59);
            this.ds_veiculo.Name = "ds_veiculo";
            this.ds_veiculo.NM_Alias = "";
            this.ds_veiculo.NM_Campo = "ds_veiculo";
            this.ds_veiculo.NM_CampoBusca = "ds_veiculo";
            this.ds_veiculo.NM_Param = "@P_DS_VEICULO";
            this.ds_veiculo.QTD_Zero = 0;
            this.ds_veiculo.Size = new System.Drawing.Size(409, 20);
            this.ds_veiculo.ST_AutoInc = false;
            this.ds_veiculo.ST_DisableAuto = false;
            this.ds_veiculo.ST_Float = false;
            this.ds_veiculo.ST_Gravar = false;
            this.ds_veiculo.ST_Int = false;
            this.ds_veiculo.ST_LimpaCampo = true;
            this.ds_veiculo.ST_NotNull = false;
            this.ds_veiculo.ST_PrimaryKey = false;
            this.ds_veiculo.TabIndex = 58;
            this.ds_veiculo.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Veiculo:";
            // 
            // bb_veiculo
            // 
            this.bb_veiculo.Image = ((System.Drawing.Image)(resources.GetObject("bb_veiculo.Image")));
            this.bb_veiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_veiculo.Location = new System.Drawing.Point(151, 59);
            this.bb_veiculo.Name = "bb_veiculo";
            this.bb_veiculo.Size = new System.Drawing.Size(28, 20);
            this.bb_veiculo.TabIndex = 7;
            this.bb_veiculo.UseVisualStyleBackColor = true;
            this.bb_veiculo.Click += new System.EventHandler(this.bb_veiculo_Click);
            // 
            // id_veiculo
            // 
            this.id_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.id_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Id_veiculostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_veiculo.Location = new System.Drawing.Point(79, 59);
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.NM_Alias = "";
            this.id_veiculo.NM_Campo = "id_veiculo";
            this.id_veiculo.NM_CampoBusca = "id_veiculo";
            this.id_veiculo.NM_Param = "@P_CD_EMPRESA";
            this.id_veiculo.QTD_Zero = 0;
            this.id_veiculo.Size = new System.Drawing.Size(72, 20);
            this.id_veiculo.ST_AutoInc = false;
            this.id_veiculo.ST_DisableAuto = false;
            this.id_veiculo.ST_Float = false;
            this.id_veiculo.ST_Gravar = true;
            this.id_veiculo.ST_Int = false;
            this.id_veiculo.ST_LimpaCampo = true;
            this.id_veiculo.ST_NotNull = true;
            this.id_veiculo.ST_PrimaryKey = false;
            this.id_veiculo.TabIndex = 6;
            this.id_veiculo.TextOld = null;
            this.id_veiculo.Leave += new System.EventHandler(this.id_veiculo_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(185, 7);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(391, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 56;
            this.nm_empresa.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Empresa:";
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(151, 7);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(79, 7);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(72, 20);
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
            // TFAbastAvulso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 312);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAbastAvulso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abastecimento Veiculo";
            this.Load += new System.EventHandler(this.TFAbastAvulso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAbastAvulso_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAbastecimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_atual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume_requisicao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsAbastecimento;
        private Componentes.EditDefault ds_viagem;
        private System.Windows.Forms.Button bb_viagem;
        private Componentes.EditDefault id_viagem;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault ds_despesa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_despesa;
        private Componentes.EditDefault id_despesa;
        private Componentes.EditDefault placa;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_veiculo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_veiculo;
        private Componentes.EditDefault id_veiculo;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.ComboBoxDefault tp_abastecimento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat volume_requisicao;
        private Componentes.EditData dt_requisicao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private Componentes.EditFloat vl_subtotal;
        private System.Windows.Forms.Label label9;
        private Componentes.EditFloat vl_unitario;
        private System.Windows.Forms.Button bb_fornecedor;
        private Componentes.EditDefault nm_fornecedor;
        private System.Windows.Forms.Label label13;
        private Componentes.EditDefault nr_notafiscal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Componentes.EditFloat km_atual;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label14;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault cd_produto;
        private Componentes.ComboBoxDefault tp_pagamento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button bb_abast;
        private System.Windows.Forms.Button bbAddFornecedor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bb_xmlNFe;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox chave_acesso_nfe;
    }
}