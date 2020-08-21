namespace Commoditties.Relatorios
{
    partial class TFRel_HistoricoContrato
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
            System.Windows.Forms.Label cD_ProdutoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRel_HistoricoContrato));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSaldosSintetico = new System.Windows.Forms.TabPage();
            this.gb_FiltroHistorico = new System.Windows.Forms.GroupBox();
            this.bb_contrato = new System.Windows.Forms.Button();
            this.Nr_Contrato = new Componentes.EditDefault(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.bbProduto = new System.Windows.Forms.Button();
            this.tp_movimento = new Componentes.RadioGroup(this.components);
            this.panelTPMovimento = new Componentes.PanelDados(this.components);
            this.rbSaida = new Componentes.RadioButtonDefault(this.components);
            this.rbEntrada = new Componentes.RadioButtonDefault(this.components);
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.ds_tipopedido = new Componentes.EditDefault(this.components);
            this.bb_tipo = new System.Windows.Forms.Button();
            this.cfg_pedido = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_pedido = new System.Windows.Forms.Button();
            this.nr_pedido = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.gb_TPPedido = new System.Windows.Forms.GroupBox();
            this.panelTPPedido = new Componentes.PanelDados(this.components);
            this.rbTodos = new Componentes.RadioButtonDefault(this.components);
            this.rbPendentes = new Componentes.RadioButtonDefault(this.components);
            this.pDadosSintetico = new Componentes.PanelDados(this.components);
            this.BS_ = new System.Windows.Forms.BindingSource(this.components);
            cD_ProdutoLabel = new System.Windows.Forms.Label();
            this.pFiltro.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSaldosSintetico.SuspendLayout();
            this.gb_FiltroHistorico.SuspendLayout();
            this.tp_movimento.SuspendLayout();
            this.panelTPMovimento.SuspendLayout();
            this.gb_TPPedido.SuspendLayout();
            this.panelTPPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_)).BeginInit();
            this.SuspendLayout();
            // 
            // pFiltro
            // 
            this.pFiltro.Controls.Add(this.gb_FiltroHistorico);
            this.pFiltro.Controls.Add(this.tabControl);
            this.pFiltro.Size = new System.Drawing.Size(742, 480);
            this.pFiltro.Controls.SetChildIndex(this.tabControl, 0);
            this.pFiltro.Controls.SetChildIndex(this.gb_FiltroHistorico, 0);
            this.pFiltro.Controls.SetChildIndex(this.BB_Menu, 0);
            // 
            // BB_Menu
            // 
            this.BB_Menu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            // 
            // cD_ProdutoLabel
            // 
            cD_ProdutoLabel.AutoSize = true;
            cD_ProdutoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cD_ProdutoLabel.Location = new System.Drawing.Point(6, 91);
            cD_ProdutoLabel.Name = "cD_ProdutoLabel";
            cD_ProdutoLabel.Size = new System.Drawing.Size(81, 13);
            cD_ProdutoLabel.TabIndex = 195;
            cD_ProdutoLabel.Text = "Cód.Produto:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSaldosSintetico);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Location = new System.Drawing.Point(0, 146);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(738, 330);
            this.tabControl.TabIndex = 0;
            // 
            // tabSaldosSintetico
            // 
            this.tabSaldosSintetico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabSaldosSintetico.Controls.Add(this.pDadosSintetico);
            this.tabSaldosSintetico.Location = new System.Drawing.Point(4, 22);
            this.tabSaldosSintetico.Name = "tabSaldosSintetico";
            this.tabSaldosSintetico.Padding = new System.Windows.Forms.Padding(3);
            this.tabSaldosSintetico.Size = new System.Drawing.Size(730, 304);
            this.tabSaldosSintetico.TabIndex = 0;
            this.tabSaldosSintetico.Text = "Saldo Sintético";
            this.tabSaldosSintetico.UseVisualStyleBackColor = true;
            // 
            // gb_FiltroHistorico
            // 
            this.gb_FiltroHistorico.Controls.Add(this.bb_contrato);
            this.gb_FiltroHistorico.Controls.Add(this.Nr_Contrato);
            this.gb_FiltroHistorico.Controls.Add(this.label13);
            this.gb_FiltroHistorico.Controls.Add(this.DS_Produto);
            this.gb_FiltroHistorico.Controls.Add(cD_ProdutoLabel);
            this.gb_FiltroHistorico.Controls.Add(this.CD_Produto);
            this.gb_FiltroHistorico.Controls.Add(this.bbProduto);
            this.gb_FiltroHistorico.Controls.Add(this.tp_movimento);
            this.gb_FiltroHistorico.Controls.Add(this.nm_clifor);
            this.gb_FiltroHistorico.Controls.Add(this.bb_clifor);
            this.gb_FiltroHistorico.Controls.Add(this.cd_clifor);
            this.gb_FiltroHistorico.Controls.Add(this.label4);
            this.gb_FiltroHistorico.Controls.Add(this.ds_tipopedido);
            this.gb_FiltroHistorico.Controls.Add(this.bb_tipo);
            this.gb_FiltroHistorico.Controls.Add(this.cfg_pedido);
            this.gb_FiltroHistorico.Controls.Add(this.label3);
            this.gb_FiltroHistorico.Controls.Add(this.bb_pedido);
            this.gb_FiltroHistorico.Controls.Add(this.nr_pedido);
            this.gb_FiltroHistorico.Controls.Add(this.label1);
            this.gb_FiltroHistorico.Controls.Add(this.nm_empresa);
            this.gb_FiltroHistorico.Controls.Add(this.bb_empresa);
            this.gb_FiltroHistorico.Controls.Add(this.cd_empresa);
            this.gb_FiltroHistorico.Controls.Add(this.label2);
            this.gb_FiltroHistorico.Controls.Add(this.gb_TPPedido);
            this.gb_FiltroHistorico.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_FiltroHistorico.Location = new System.Drawing.Point(0, 0);
            this.gb_FiltroHistorico.Name = "gb_FiltroHistorico";
            this.gb_FiltroHistorico.Size = new System.Drawing.Size(738, 145);
            this.gb_FiltroHistorico.TabIndex = 0;
            this.gb_FiltroHistorico.TabStop = false;
            this.gb_FiltroHistorico.Text = "Opções de Filtros";
            // 
            // bb_contrato
            // 
            this.bb_contrato.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_contrato.Image = ((System.Drawing.Image)(resources.GetObject("bb_contrato.Image")));
            this.bb_contrato.Location = new System.Drawing.Point(160, 111);
            this.bb_contrato.Name = "bb_contrato";
            this.bb_contrato.Size = new System.Drawing.Size(30, 20);
            this.bb_contrato.TabIndex = 11;
            this.bb_contrato.UseVisualStyleBackColor = true;
            this.bb_contrato.Click += new System.EventHandler(this.bb_contrato_Click);
            // 
            // Nr_Contrato
            // 
            this.Nr_Contrato.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_Contrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_Contrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nr_Contrato.Location = new System.Drawing.Point(87, 111);
            this.Nr_Contrato.MaxLength = 5;
            this.Nr_Contrato.Name = "Nr_Contrato";
            this.Nr_Contrato.NM_Alias = "";
            this.Nr_Contrato.NM_Campo = "Nr_Contrato";
            this.Nr_Contrato.NM_CampoBusca = "Nr_Contrato";
            this.Nr_Contrato.NM_Param = "@P_NR_CONTRATO";
            this.Nr_Contrato.QTD_Zero = 0;
            this.Nr_Contrato.Size = new System.Drawing.Size(70, 20);
            this.Nr_Contrato.ST_AutoInc = false;
            this.Nr_Contrato.ST_DisableAuto = false;
            this.Nr_Contrato.ST_Float = false;
            this.Nr_Contrato.ST_Gravar = false;
            this.Nr_Contrato.ST_Int = true;
            this.Nr_Contrato.ST_LimpaCampo = true;
            this.Nr_Contrato.ST_NotNull = false;
            this.Nr_Contrato.ST_PrimaryKey = false;
            this.Nr_Contrato.TabIndex = 10;
            this.Nr_Contrato.Leave += new System.EventHandler(this.Nr_Contrato_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 114);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 198;
            this.label13.Text = "Nº Contrato:";
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.Enabled = false;
            this.DS_Produto.Location = new System.Drawing.Point(193, 88);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "b";
            this.DS_Produto.NM_Campo = "ds_produto";
            this.DS_Produto.NM_CampoBusca = "ds_produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.Size = new System.Drawing.Size(380, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 194;
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.Location = new System.Drawing.Point(88, 88);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "a";
            this.CD_Produto.NM_Campo = "cd_produto";
            this.CD_Produto.NM_CampoBusca = "cd_produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(70, 20);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = true;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 8;
            this.CD_Produto.Leave += new System.EventHandler(this.Cd_Produto_Busca_Leave);
            // 
            // bbProduto
            // 
            this.bbProduto.BackColor = System.Drawing.SystemColors.Control;
            this.bbProduto.Enabled = false;
            this.bbProduto.Image = ((System.Drawing.Image)(resources.GetObject("bbProduto.Image")));
            this.bbProduto.Location = new System.Drawing.Point(160, 88);
            this.bbProduto.Name = "bbProduto";
            this.bbProduto.Size = new System.Drawing.Size(30, 20);
            this.bbProduto.TabIndex = 9;
            this.bbProduto.UseVisualStyleBackColor = false;
            this.bbProduto.Click += new System.EventHandler(this.bbProduto_Click);
            // 
            // tp_movimento
            // 
            this.tp_movimento.Controls.Add(this.panelTPMovimento);
            this.tp_movimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tp_movimento.Location = new System.Drawing.Point(579, 9);
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "";
            this.tp_movimento.NM_Campo = "";
            this.tp_movimento.NM_Param = "";
            this.tp_movimento.NM_Valor = "E";
            this.tp_movimento.Size = new System.Drawing.Size(155, 50);
            this.tp_movimento.ST_Gravar = true;
            this.tp_movimento.ST_NotNull = false;
            this.tp_movimento.TabIndex = 93;
            this.tp_movimento.TabStop = false;
            this.tp_movimento.Text = "Tipo Movimento:";
            // 
            // panelTPMovimento
            // 
            this.panelTPMovimento.BackColor = System.Drawing.Color.SandyBrown;
            this.panelTPMovimento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTPMovimento.Controls.Add(this.rbSaida);
            this.panelTPMovimento.Controls.Add(this.rbEntrada);
            this.panelTPMovimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTPMovimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTPMovimento.Location = new System.Drawing.Point(3, 16);
            this.panelTPMovimento.Name = "panelTPMovimento";
            this.panelTPMovimento.NM_ProcDeletar = "";
            this.panelTPMovimento.NM_ProcGravar = "";
            this.panelTPMovimento.Size = new System.Drawing.Size(149, 31);
            this.panelTPMovimento.TabIndex = 0;
            // 
            // rbSaida
            // 
            this.rbSaida.AutoSize = true;
            this.rbSaida.Location = new System.Drawing.Point(82, 5);
            this.rbSaida.Name = "rbSaida";
            this.rbSaida.Size = new System.Drawing.Size(57, 17);
            this.rbSaida.TabIndex = 1;
            this.rbSaida.Text = "Saida";
            this.rbSaida.UseVisualStyleBackColor = true;
            this.rbSaida.Valor = "S";
            // 
            // rbEntrada
            // 
            this.rbEntrada.AutoSize = true;
            this.rbEntrada.Checked = true;
            this.rbEntrada.Location = new System.Drawing.Point(7, 5);
            this.rbEntrada.Name = "rbEntrada";
            this.rbEntrada.Size = new System.Drawing.Size(69, 17);
            this.rbEntrada.TabIndex = 0;
            this.rbEntrada.TabStop = true;
            this.rbEntrada.Text = "Entrada";
            this.rbEntrada.UseVisualStyleBackColor = true;
            this.rbEntrada.Valor = "E";
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nm_clifor.Location = new System.Drawing.Point(193, 65);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_DS_SERIE";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(380, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 92;
            // 
            // bb_clifor
            // 
            this.bb_clifor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.Location = new System.Drawing.Point(160, 65);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(30, 20);
            this.bb_clifor.TabIndex = 7;
            this.bb_clifor.UseVisualStyleBackColor = true;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_clifor.Location = new System.Drawing.Point(88, 65);
            this.cd_clifor.MaxLength = 5;
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "a";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_NR_SERIE";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(70, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = false;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 6;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 90;
            this.label4.Text = "Contratante:";
            // 
            // ds_tipopedido
            // 
            this.ds_tipopedido.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tipopedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tipopedido.Enabled = false;
            this.ds_tipopedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ds_tipopedido.Location = new System.Drawing.Point(312, 42);
            this.ds_tipopedido.Name = "ds_tipopedido";
            this.ds_tipopedido.NM_Alias = "cfgped";
            this.ds_tipopedido.NM_Campo = "ds_tipopedido";
            this.ds_tipopedido.NM_CampoBusca = "ds_tipopedido";
            this.ds_tipopedido.NM_Param = "@P_DS_SERIE";
            this.ds_tipopedido.QTD_Zero = 0;
            this.ds_tipopedido.Size = new System.Drawing.Size(261, 20);
            this.ds_tipopedido.ST_AutoInc = false;
            this.ds_tipopedido.ST_DisableAuto = false;
            this.ds_tipopedido.ST_Float = false;
            this.ds_tipopedido.ST_Gravar = false;
            this.ds_tipopedido.ST_Int = false;
            this.ds_tipopedido.ST_LimpaCampo = true;
            this.ds_tipopedido.ST_NotNull = false;
            this.ds_tipopedido.ST_PrimaryKey = false;
            this.ds_tipopedido.TabIndex = 88;
            // 
            // bb_tipo
            // 
            this.bb_tipo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_tipo.Image = ((System.Drawing.Image)(resources.GetObject("bb_tipo.Image")));
            this.bb_tipo.Location = new System.Drawing.Point(279, 42);
            this.bb_tipo.Name = "bb_tipo";
            this.bb_tipo.Size = new System.Drawing.Size(30, 20);
            this.bb_tipo.TabIndex = 5;
            this.bb_tipo.UseVisualStyleBackColor = true;
            this.bb_tipo.Click += new System.EventHandler(this.bb_tipo_Click);
            // 
            // cfg_pedido
            // 
            this.cfg_pedido.BackColor = System.Drawing.SystemColors.Window;
            this.cfg_pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cfg_pedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfg_pedido.Location = new System.Drawing.Point(228, 42);
            this.cfg_pedido.MaxLength = 5;
            this.cfg_pedido.Name = "cfg_pedido";
            this.cfg_pedido.NM_Alias = "a";
            this.cfg_pedido.NM_Campo = "cfg_pedido";
            this.cfg_pedido.NM_CampoBusca = "cfg_pedido";
            this.cfg_pedido.NM_Param = "@P_NR_SERIE";
            this.cfg_pedido.QTD_Zero = 0;
            this.cfg_pedido.Size = new System.Drawing.Size(48, 20);
            this.cfg_pedido.ST_AutoInc = false;
            this.cfg_pedido.ST_DisableAuto = false;
            this.cfg_pedido.ST_Float = false;
            this.cfg_pedido.ST_Gravar = true;
            this.cfg_pedido.ST_Int = false;
            this.cfg_pedido.ST_LimpaCampo = true;
            this.cfg_pedido.ST_NotNull = false;
            this.cfg_pedido.ST_PrimaryKey = false;
            this.cfg_pedido.TabIndex = 4;
            this.cfg_pedido.Leave += new System.EventHandler(this.cfg_pedido_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(191, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 86;
            this.label3.Text = "Tipo:";
            // 
            // bb_pedido
            // 
            this.bb_pedido.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_pedido.Image = ((System.Drawing.Image)(resources.GetObject("bb_pedido.Image")));
            this.bb_pedido.Location = new System.Drawing.Point(160, 42);
            this.bb_pedido.Name = "bb_pedido";
            this.bb_pedido.Size = new System.Drawing.Size(30, 20);
            this.bb_pedido.TabIndex = 3;
            this.bb_pedido.UseVisualStyleBackColor = true;
            this.bb_pedido.Click += new System.EventHandler(this.bb_pedido_Click);
            // 
            // nr_pedido
            // 
            this.nr_pedido.BackColor = System.Drawing.SystemColors.Window;
            this.nr_pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_pedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nr_pedido.Location = new System.Drawing.Point(88, 42);
            this.nr_pedido.MaxLength = 5;
            this.nr_pedido.Name = "nr_pedido";
            this.nr_pedido.NM_Alias = "a";
            this.nr_pedido.NM_Campo = "nr_pedido";
            this.nr_pedido.NM_CampoBusca = "nr_pedido";
            this.nr_pedido.NM_Param = "@P_NR_SERIE";
            this.nr_pedido.QTD_Zero = 0;
            this.nr_pedido.Size = new System.Drawing.Size(70, 20);
            this.nr_pedido.ST_AutoInc = false;
            this.nr_pedido.ST_DisableAuto = false;
            this.nr_pedido.ST_Float = false;
            this.nr_pedido.ST_Gravar = true;
            this.nr_pedido.ST_Int = false;
            this.nr_pedido.ST_LimpaCampo = true;
            this.nr_pedido.ST_NotNull = false;
            this.nr_pedido.ST_PrimaryKey = false;
            this.nr_pedido.TabIndex = 2;
            this.nr_pedido.Leave += new System.EventHandler(this.nr_pedido_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "Nº Pedido:";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nm_empresa.Location = new System.Drawing.Point(193, 19);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_DS_SERIE";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(380, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 81;
            // 
            // bb_empresa
            // 
            this.bb_empresa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.Location = new System.Drawing.Point(160, 19);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(30, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_empresa.Location = new System.Drawing.Point(88, 19);
            this.cd_empresa.MaxLength = 5;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "a";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_NR_SERIE";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(70, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "Empresa:";
            // 
            // gb_TPPedido
            // 
            this.gb_TPPedido.Controls.Add(this.panelTPPedido);
            this.gb_TPPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_TPPedido.Location = new System.Drawing.Point(580, 62);
            this.gb_TPPedido.Name = "gb_TPPedido";
            this.gb_TPPedido.Size = new System.Drawing.Size(155, 80);
            this.gb_TPPedido.TabIndex = 77;
            this.gb_TPPedido.TabStop = false;
            this.gb_TPPedido.Text = "Tipo de Pedidos:";
            // 
            // panelTPPedido
            // 
            this.panelTPPedido.BackColor = System.Drawing.Color.SandyBrown;
            this.panelTPPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTPPedido.Controls.Add(this.rbTodos);
            this.panelTPPedido.Controls.Add(this.rbPendentes);
            this.panelTPPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTPPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTPPedido.Location = new System.Drawing.Point(3, 16);
            this.panelTPPedido.Name = "panelTPPedido";
            this.panelTPPedido.NM_ProcDeletar = "";
            this.panelTPPedido.NM_ProcGravar = "";
            this.panelTPPedido.Size = new System.Drawing.Size(149, 61);
            this.panelTPPedido.TabIndex = 0;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(3, 36);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(60, 17);
            this.rbTodos.TabIndex = 1;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.Valor = "";
            // 
            // rbPendentes
            // 
            this.rbPendentes.AutoSize = true;
            this.rbPendentes.Location = new System.Drawing.Point(3, 4);
            this.rbPendentes.Name = "rbPendentes";
            this.rbPendentes.Size = new System.Drawing.Size(146, 30);
            this.rbPendentes.TabIndex = 0;
            this.rbPendentes.Text = "Somente com \r\ndesdobros pendentes";
            this.rbPendentes.UseVisualStyleBackColor = true;
            this.rbPendentes.Valor = "";
            // 
            // pDadosSintetico
            // 
            this.pDadosSintetico.Dock = System.Windows.Forms.DockStyle.Top;
            this.pDadosSintetico.Location = new System.Drawing.Point(3, 3);
            this.pDadosSintetico.Name = "pDadosSintetico";
            this.pDadosSintetico.NM_ProcDeletar = "";
            this.pDadosSintetico.NM_ProcGravar = "";
            this.pDadosSintetico.Size = new System.Drawing.Size(720, 130);
            this.pDadosSintetico.TabIndex = 0;
            // 
            // TFRel_HistoricoContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(742, 523);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TFRel_HistoricoContrato";
            this.Text = "Relatório de Histórico de Contrato";
            this.pFiltro.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabSaldosSintetico.ResumeLayout(false);
            this.gb_FiltroHistorico.ResumeLayout(false);
            this.gb_FiltroHistorico.PerformLayout();
            this.tp_movimento.ResumeLayout(false);
            this.panelTPMovimento.ResumeLayout(false);
            this.panelTPMovimento.PerformLayout();
            this.gb_TPPedido.ResumeLayout(false);
            this.panelTPPedido.ResumeLayout(false);
            this.panelTPPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_FiltroHistorico;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSaldosSintetico;
        private Componentes.RadioGroup tp_movimento;
        private Componentes.PanelDados panelTPMovimento;
        private Componentes.RadioButtonDefault rbSaida;
        private Componentes.RadioButtonDefault rbEntrada;
        private Componentes.EditDefault nm_clifor;
        public System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault ds_tipopedido;
        public System.Windows.Forms.Button bb_tipo;
        private Componentes.EditDefault cfg_pedido;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button bb_pedido;
        private Componentes.EditDefault nr_pedido;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault nm_empresa;
        public System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_TPPedido;
        private Componentes.PanelDados panelTPPedido;
        private Componentes.RadioButtonDefault rbTodos;
        private Componentes.RadioButtonDefault rbPendentes;
        private Componentes.EditDefault DS_Produto;
        private Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.Button bbProduto;
        private System.Windows.Forms.Button bb_contrato;
        private Componentes.EditDefault Nr_Contrato;
        private System.Windows.Forms.Label label13;
        private Componentes.PanelDados pDadosSintetico;
        private System.Windows.Forms.BindingSource BS_;
    }
}
