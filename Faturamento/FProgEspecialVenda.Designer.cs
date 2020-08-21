namespace Faturamento
{
    partial class TFProgEspecialVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFProgEspecialVenda));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.dt_finvigencia = new Componentes.EditData(this.components);
            this.bsProgEspecialVenda = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.dt_inivigencia = new Componentes.EditData(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.ds_tabelaprecoloc = new Componentes.EditDefault(this.components);
            this.bb_tabelaprecoloc = new System.Windows.Forms.Button();
            this.id_tabelaprecoloc = new Componentes.EditDefault(this.components);
            this.lbTabelalocacao = new System.Windows.Forms.Label();
            this.qtd_minvenda = new Componentes.EditFloat(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.ds_tabelapreco = new Componentes.EditDefault(this.components);
            this.bb_tabelapreco = new System.Windows.Forms.Button();
            this.cd_tabelapreco = new Componentes.EditDefault(this.components);
            this.lbTabela = new System.Windows.Forms.Label();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.tp_acresdesc = new Componentes.ComboBoxDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.tp_valor = new Componentes.ComboBoxDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.valor = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tp_preco = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ds_grupo = new Componentes.EditDefault(this.components);
            this.bb_grupo = new System.Windows.Forms.Button();
            this.cd_grupo = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_categoriaclifor = new Componentes.EditDefault(this.components);
            this.bb_categoriaclifor = new System.Windows.Forms.Button();
            this.id_categoriaclifor = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label37 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProgEspecialVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_minvenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(597, 43);
            this.barraMenu.TabIndex = 15;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.dt_finvigencia);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(this.dt_inivigencia);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.ds_tabelaprecoloc);
            this.pDados.Controls.Add(this.bb_tabelaprecoloc);
            this.pDados.Controls.Add(this.id_tabelaprecoloc);
            this.pDados.Controls.Add(this.lbTabelalocacao);
            this.pDados.Controls.Add(this.qtd_minvenda);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.ds_tabelapreco);
            this.pDados.Controls.Add(this.bb_tabelapreco);
            this.pDados.Controls.Add(this.cd_tabelapreco);
            this.pDados.Controls.Add(this.lbTabela);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.nm_clifor);
            this.pDados.Controls.Add(this.bb_clifor);
            this.pDados.Controls.Add(this.cd_clifor);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.tp_acresdesc);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.tp_valor);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.valor);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.tp_preco);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.ds_grupo);
            this.pDados.Controls.Add(this.bb_grupo);
            this.pDados.Controls.Add(this.cd_grupo);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_categoriaclifor);
            this.pDados.Controls.Add(this.bb_categoriaclifor);
            this.pDados.Controls.Add(this.id_categoriaclifor);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label37);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(597, 352);
            this.pDados.TabIndex = 16;
            // 
            // dt_finvigencia
            // 
            this.dt_finvigencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_finvigencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Dt_finvigenciastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_finvigencia.Location = new System.Drawing.Point(255, 322);
            this.dt_finvigencia.Mask = "00/00/0000";
            this.dt_finvigencia.Name = "dt_finvigencia";
            this.dt_finvigencia.NM_Alias = "";
            this.dt_finvigencia.NM_Campo = "";
            this.dt_finvigencia.NM_CampoBusca = "";
            this.dt_finvigencia.NM_Param = "";
            this.dt_finvigencia.Operador = "";
            this.dt_finvigencia.Size = new System.Drawing.Size(75, 20);
            this.dt_finvigencia.ST_Gravar = true;
            this.dt_finvigencia.ST_LimpaCampo = true;
            this.dt_finvigencia.ST_NotNull = false;
            this.dt_finvigencia.ST_PrimaryKey = false;
            this.dt_finvigencia.TabIndex = 121;
            // 
            // bsProgEspecialVenda
            // 
            this.bsProgEspecialVenda.DataSource = typeof(CamadaDados.Faturamento.ProgEspecialVenda.TList_ProgEspecialVenda);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(173, 324);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 120;
            this.label11.Text = "Final Vigência:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_inivigencia
            // 
            this.dt_inivigencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_inivigencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Dt_inivigenciastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_inivigencia.Location = new System.Drawing.Point(93, 322);
            this.dt_inivigencia.Mask = "00/00/0000";
            this.dt_inivigencia.Name = "dt_inivigencia";
            this.dt_inivigencia.NM_Alias = "";
            this.dt_inivigencia.NM_Campo = "";
            this.dt_inivigencia.NM_CampoBusca = "";
            this.dt_inivigencia.NM_Param = "";
            this.dt_inivigencia.Operador = "";
            this.dt_inivigencia.Size = new System.Drawing.Size(75, 20);
            this.dt_inivigencia.ST_Gravar = true;
            this.dt_inivigencia.ST_LimpaCampo = true;
            this.dt_inivigencia.ST_NotNull = true;
            this.dt_inivigencia.ST_PrimaryKey = false;
            this.dt_inivigencia.TabIndex = 119;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(8, 324);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 118;
            this.label9.Text = "Inicio Vigência:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_tabelaprecoloc
            // 
            this.ds_tabelaprecoloc.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelaprecoloc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tabelaprecoloc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelaprecoloc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Ds_tabprecoloc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tabelaprecoloc.Enabled = false;
            this.ds_tabelaprecoloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tabelaprecoloc.Location = new System.Drawing.Point(112, 255);
            this.ds_tabelaprecoloc.Name = "ds_tabelaprecoloc";
            this.ds_tabelaprecoloc.NM_Alias = "";
            this.ds_tabelaprecoloc.NM_Campo = "ds_tabela";
            this.ds_tabelaprecoloc.NM_CampoBusca = "ds_tabela";
            this.ds_tabelaprecoloc.NM_Param = "@P_CD_EMPRESA";
            this.ds_tabelaprecoloc.QTD_Zero = 0;
            this.ds_tabelaprecoloc.Size = new System.Drawing.Size(472, 20);
            this.ds_tabelaprecoloc.ST_AutoInc = false;
            this.ds_tabelaprecoloc.ST_DisableAuto = false;
            this.ds_tabelaprecoloc.ST_Float = false;
            this.ds_tabelaprecoloc.ST_Gravar = false;
            this.ds_tabelaprecoloc.ST_Int = true;
            this.ds_tabelaprecoloc.ST_LimpaCampo = true;
            this.ds_tabelaprecoloc.ST_NotNull = false;
            this.ds_tabelaprecoloc.ST_PrimaryKey = false;
            this.ds_tabelaprecoloc.TabIndex = 117;
            this.ds_tabelaprecoloc.TextOld = null;
            this.ds_tabelaprecoloc.Visible = false;
            // 
            // bb_tabelaprecoloc
            // 
            this.bb_tabelaprecoloc.Image = ((System.Drawing.Image)(resources.GetObject("bb_tabelaprecoloc.Image")));
            this.bb_tabelaprecoloc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tabelaprecoloc.Location = new System.Drawing.Point(78, 255);
            this.bb_tabelaprecoloc.Name = "bb_tabelaprecoloc";
            this.bb_tabelaprecoloc.Size = new System.Drawing.Size(28, 19);
            this.bb_tabelaprecoloc.TabIndex = 115;
            this.bb_tabelaprecoloc.UseVisualStyleBackColor = true;
            this.bb_tabelaprecoloc.Visible = false;
            this.bb_tabelaprecoloc.Click += new System.EventHandler(this.bb_tabelaprecoloc_Click);
            // 
            // id_tabelaprecoloc
            // 
            this.id_tabelaprecoloc.BackColor = System.Drawing.SystemColors.Window;
            this.id_tabelaprecoloc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_tabelaprecoloc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tabelaprecoloc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Id_tabprecoloc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_tabelaprecoloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_tabelaprecoloc.Location = new System.Drawing.Point(11, 255);
            this.id_tabelaprecoloc.Name = "id_tabelaprecoloc";
            this.id_tabelaprecoloc.NM_Alias = "";
            this.id_tabelaprecoloc.NM_Campo = "Id_tabela";
            this.id_tabelaprecoloc.NM_CampoBusca = "Id_tabela";
            this.id_tabelaprecoloc.NM_Param = "@P_CD_EMPRESA";
            this.id_tabelaprecoloc.QTD_Zero = 0;
            this.id_tabelaprecoloc.Size = new System.Drawing.Size(65, 20);
            this.id_tabelaprecoloc.ST_AutoInc = false;
            this.id_tabelaprecoloc.ST_DisableAuto = false;
            this.id_tabelaprecoloc.ST_Float = false;
            this.id_tabelaprecoloc.ST_Gravar = true;
            this.id_tabelaprecoloc.ST_Int = true;
            this.id_tabelaprecoloc.ST_LimpaCampo = true;
            this.id_tabelaprecoloc.ST_NotNull = false;
            this.id_tabelaprecoloc.ST_PrimaryKey = false;
            this.id_tabelaprecoloc.TabIndex = 114;
            this.id_tabelaprecoloc.TextOld = null;
            this.id_tabelaprecoloc.Visible = false;
            this.id_tabelaprecoloc.Leave += new System.EventHandler(this.id_tabelaprecoloc_Leave);
            // 
            // lbTabelalocacao
            // 
            this.lbTabelalocacao.AutoSize = true;
            this.lbTabelalocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbTabelalocacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTabelalocacao.Location = new System.Drawing.Point(8, 239);
            this.lbTabelalocacao.Name = "lbTabelalocacao";
            this.lbTabelalocacao.Size = new System.Drawing.Size(116, 13);
            this.lbTabelalocacao.TabIndex = 116;
            this.lbTabelalocacao.Text = "Tabela Preço Locação";
            this.lbTabelalocacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTabelalocacao.Visible = false;
            // 
            // qtd_minvenda
            // 
            this.qtd_minvenda.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProgEspecialVenda, "Qtd_minVenda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_minvenda.DecimalPlaces = 3;
            this.qtd_minvenda.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qtd_minvenda.Location = new System.Drawing.Point(487, 294);
            this.qtd_minvenda.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_minvenda.Name = "qtd_minvenda";
            this.qtd_minvenda.NM_Alias = "";
            this.qtd_minvenda.NM_Campo = "";
            this.qtd_minvenda.NM_Param = "";
            this.qtd_minvenda.Operador = "";
            this.qtd_minvenda.Size = new System.Drawing.Size(97, 20);
            this.qtd_minvenda.ST_AutoInc = false;
            this.qtd_minvenda.ST_DisableAuto = false;
            this.qtd_minvenda.ST_Gravar = true;
            this.qtd_minvenda.ST_LimparCampo = true;
            this.qtd_minvenda.ST_NotNull = false;
            this.qtd_minvenda.ST_PrimaryKey = false;
            this.qtd_minvenda.TabIndex = 112;
            this.qtd_minvenda.ThousandsSeparator = true;
            this.qtd_minvenda.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(484, 278);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 113;
            this.label10.Text = "Qtd.Min.Venda";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_tabelapreco
            // 
            this.ds_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Ds_tabelapreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tabelapreco.Enabled = false;
            this.ds_tabelapreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tabelapreco.Location = new System.Drawing.Point(113, 217);
            this.ds_tabelapreco.Name = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Alias = "";
            this.ds_tabelapreco.NM_Campo = "ds_tabelapreco";
            this.ds_tabelapreco.NM_CampoBusca = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Param = "@P_CD_EMPRESA";
            this.ds_tabelapreco.QTD_Zero = 0;
            this.ds_tabelapreco.Size = new System.Drawing.Size(472, 20);
            this.ds_tabelapreco.ST_AutoInc = false;
            this.ds_tabelapreco.ST_DisableAuto = false;
            this.ds_tabelapreco.ST_Float = false;
            this.ds_tabelapreco.ST_Gravar = false;
            this.ds_tabelapreco.ST_Int = true;
            this.ds_tabelapreco.ST_LimpaCampo = true;
            this.ds_tabelapreco.ST_NotNull = false;
            this.ds_tabelapreco.ST_PrimaryKey = false;
            this.ds_tabelapreco.TabIndex = 111;
            this.ds_tabelapreco.TextOld = null;
            // 
            // bb_tabelapreco
            // 
            this.bb_tabelapreco.Image = ((System.Drawing.Image)(resources.GetObject("bb_tabelapreco.Image")));
            this.bb_tabelapreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tabelapreco.Location = new System.Drawing.Point(79, 217);
            this.bb_tabelapreco.Name = "bb_tabelapreco";
            this.bb_tabelapreco.Size = new System.Drawing.Size(28, 19);
            this.bb_tabelapreco.TabIndex = 11;
            this.bb_tabelapreco.UseVisualStyleBackColor = true;
            this.bb_tabelapreco.Click += new System.EventHandler(this.bb_tabelapreco_Click);
            // 
            // cd_tabelapreco
            // 
            this.cd_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Cd_tabelapreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_tabelapreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_tabelapreco.Location = new System.Drawing.Point(12, 217);
            this.cd_tabelapreco.Name = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Alias = "";
            this.cd_tabelapreco.NM_Campo = "cd_tabelapreco";
            this.cd_tabelapreco.NM_CampoBusca = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Param = "@P_CD_EMPRESA";
            this.cd_tabelapreco.QTD_Zero = 0;
            this.cd_tabelapreco.Size = new System.Drawing.Size(65, 20);
            this.cd_tabelapreco.ST_AutoInc = false;
            this.cd_tabelapreco.ST_DisableAuto = false;
            this.cd_tabelapreco.ST_Float = false;
            this.cd_tabelapreco.ST_Gravar = true;
            this.cd_tabelapreco.ST_Int = true;
            this.cd_tabelapreco.ST_LimpaCampo = true;
            this.cd_tabelapreco.ST_NotNull = false;
            this.cd_tabelapreco.ST_PrimaryKey = false;
            this.cd_tabelapreco.TabIndex = 10;
            this.cd_tabelapreco.TextOld = null;
            this.cd_tabelapreco.Leave += new System.EventHandler(this.cd_tabelapreco_Leave);
            // 
            // lbTabela
            // 
            this.lbTabela.AutoSize = true;
            this.lbTabela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbTabela.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTabela.Location = new System.Drawing.Point(9, 201);
            this.lbTabela.Name = "lbTabela";
            this.lbTabela.Size = new System.Drawing.Size(71, 13);
            this.lbTabela.TabIndex = 110;
            this.lbTabela.Text = "Tabela Preço";
            this.lbTabela.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_produto.Location = new System.Drawing.Point(147, 178);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_CD_EMPRESA";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(438, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = true;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 107;
            this.ds_produto.TextOld = null;
            // 
            // bb_produto
            // 
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(113, 178);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 9;
            this.bb_produto.UseVisualStyleBackColor = true;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(12, 178);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(98, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 8;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(9, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 106;
            this.label8.Text = "Produto";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Nm_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_clifor.Location = new System.Drawing.Point(147, 100);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_CD_EMPRESA";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(438, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = true;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 103;
            this.nm_clifor.TextOld = null;
            // 
            // bb_clifor
            // 
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(113, 100);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(28, 19);
            this.bb_clifor.TabIndex = 5;
            this.bb_clifor.UseVisualStyleBackColor = true;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_clifor.Location = new System.Drawing.Point(12, 100);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_EMPRESA";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(98, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = true;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = false;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 4;
            this.cd_clifor.TextOld = null;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(9, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 102;
            this.label7.Text = "Cliente";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_acresdesc
            // 
            this.tp_acresdesc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsProgEspecialVenda, "Tp_acresdesc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_acresdesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_acresdesc.FormattingEnabled = true;
            this.tp_acresdesc.Location = new System.Drawing.Point(136, 295);
            this.tp_acresdesc.Name = "tp_acresdesc";
            this.tp_acresdesc.NM_Alias = "";
            this.tp_acresdesc.NM_Campo = "";
            this.tp_acresdesc.NM_Param = "";
            this.tp_acresdesc.Size = new System.Drawing.Size(116, 21);
            this.tp_acresdesc.ST_Gravar = true;
            this.tp_acresdesc.ST_LimparCampo = true;
            this.tp_acresdesc.ST_NotNull = true;
            this.tp_acresdesc.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(133, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Acres/Desc.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_valor
            // 
            this.tp_valor.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsProgEspecialVenda, "Tp_valor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_valor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_valor.FormattingEnabled = true;
            this.tp_valor.Location = new System.Drawing.Point(363, 294);
            this.tp_valor.Name = "tp_valor";
            this.tp_valor.NM_Alias = "";
            this.tp_valor.NM_Campo = "";
            this.tp_valor.NM_Param = "";
            this.tp_valor.Size = new System.Drawing.Size(116, 21);
            this.tp_valor.ST_Gravar = true;
            this.tp_valor.ST_LimparCampo = true;
            this.tp_valor.ST_NotNull = true;
            this.tp_valor.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(360, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 97;
            this.label5.Text = "Tipo Valor";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // valor
            // 
            this.valor.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProgEspecialVenda, "Valor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.valor.DecimalPlaces = 2;
            this.valor.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valor.Location = new System.Drawing.Point(258, 295);
            this.valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.valor.Name = "valor";
            this.valor.NM_Alias = "";
            this.valor.NM_Campo = "";
            this.valor.NM_Param = "";
            this.valor.Operador = "";
            this.valor.Size = new System.Drawing.Size(97, 20);
            this.valor.ST_AutoInc = false;
            this.valor.ST_DisableAuto = false;
            this.valor.ST_Gravar = true;
            this.valor.ST_LimparCampo = true;
            this.valor.ST_NotNull = true;
            this.valor.ST_PrimaryKey = false;
            this.valor.TabIndex = 14;
            this.valor.ThousandsSeparator = true;
            this.valor.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(255, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 95;
            this.label4.Text = "Valor";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_preco
            // 
            this.tp_preco.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsProgEspecialVenda, "Tp_preco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_preco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_preco.FormattingEnabled = true;
            this.tp_preco.Location = new System.Drawing.Point(11, 295);
            this.tp_preco.Name = "tp_preco";
            this.tp_preco.NM_Alias = "";
            this.tp_preco.NM_Campo = "";
            this.tp_preco.NM_Param = "";
            this.tp_preco.Size = new System.Drawing.Size(116, 21);
            this.tp_preco.ST_Gravar = true;
            this.tp_preco.ST_LimparCampo = true;
            this.tp_preco.ST_NotNull = true;
            this.tp_preco.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(8, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 93;
            this.label3.Text = "Tipo Preço";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_grupo
            // 
            this.ds_grupo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Ds_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_grupo.Enabled = false;
            this.ds_grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_grupo.Location = new System.Drawing.Point(116, 139);
            this.ds_grupo.Name = "ds_grupo";
            this.ds_grupo.NM_Alias = "";
            this.ds_grupo.NM_Campo = "ds_grupo";
            this.ds_grupo.NM_CampoBusca = "ds_grupo";
            this.ds_grupo.NM_Param = "@P_CD_EMPRESA";
            this.ds_grupo.QTD_Zero = 0;
            this.ds_grupo.Size = new System.Drawing.Size(469, 20);
            this.ds_grupo.ST_AutoInc = false;
            this.ds_grupo.ST_DisableAuto = false;
            this.ds_grupo.ST_Float = false;
            this.ds_grupo.ST_Gravar = false;
            this.ds_grupo.ST_Int = true;
            this.ds_grupo.ST_LimpaCampo = true;
            this.ds_grupo.ST_NotNull = false;
            this.ds_grupo.ST_PrimaryKey = false;
            this.ds_grupo.TabIndex = 92;
            this.ds_grupo.TextOld = null;
            // 
            // bb_grupo
            // 
            this.bb_grupo.Image = ((System.Drawing.Image)(resources.GetObject("bb_grupo.Image")));
            this.bb_grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_grupo.Location = new System.Drawing.Point(82, 139);
            this.bb_grupo.Name = "bb_grupo";
            this.bb_grupo.Size = new System.Drawing.Size(28, 19);
            this.bb_grupo.TabIndex = 7;
            this.bb_grupo.UseVisualStyleBackColor = true;
            this.bb_grupo.Click += new System.EventHandler(this.bb_grupo_Click);
            // 
            // cd_grupo
            // 
            this.cd_grupo.BackColor = System.Drawing.SystemColors.Window;
            this.cd_grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Cd_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_grupo.Location = new System.Drawing.Point(14, 139);
            this.cd_grupo.Name = "cd_grupo";
            this.cd_grupo.NM_Alias = "";
            this.cd_grupo.NM_Campo = "cd_grupo";
            this.cd_grupo.NM_CampoBusca = "cd_grupo";
            this.cd_grupo.NM_Param = "@P_CD_EMPRESA";
            this.cd_grupo.QTD_Zero = 0;
            this.cd_grupo.Size = new System.Drawing.Size(66, 20);
            this.cd_grupo.ST_AutoInc = false;
            this.cd_grupo.ST_DisableAuto = false;
            this.cd_grupo.ST_Float = false;
            this.cd_grupo.ST_Gravar = true;
            this.cd_grupo.ST_Int = true;
            this.cd_grupo.ST_LimpaCampo = true;
            this.cd_grupo.ST_NotNull = false;
            this.cd_grupo.ST_PrimaryKey = false;
            this.cd_grupo.TabIndex = 6;
            this.cd_grupo.TextOld = null;
            this.cd_grupo.Leave += new System.EventHandler(this.cd_grupo_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(11, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Grupo Produto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_categoriaclifor
            // 
            this.ds_categoriaclifor.BackColor = System.Drawing.SystemColors.Window;
            this.ds_categoriaclifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_categoriaclifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_categoriaclifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Ds_categoriaclifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_categoriaclifor.Enabled = false;
            this.ds_categoriaclifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_categoriaclifor.Location = new System.Drawing.Point(113, 62);
            this.ds_categoriaclifor.Name = "ds_categoriaclifor";
            this.ds_categoriaclifor.NM_Alias = "";
            this.ds_categoriaclifor.NM_Campo = "ds_categoriaclifor";
            this.ds_categoriaclifor.NM_CampoBusca = "ds_categoriaclifor";
            this.ds_categoriaclifor.NM_Param = "@P_CD_EMPRESA";
            this.ds_categoriaclifor.QTD_Zero = 0;
            this.ds_categoriaclifor.Size = new System.Drawing.Size(472, 20);
            this.ds_categoriaclifor.ST_AutoInc = false;
            this.ds_categoriaclifor.ST_DisableAuto = false;
            this.ds_categoriaclifor.ST_Float = false;
            this.ds_categoriaclifor.ST_Gravar = false;
            this.ds_categoriaclifor.ST_Int = true;
            this.ds_categoriaclifor.ST_LimpaCampo = true;
            this.ds_categoriaclifor.ST_NotNull = false;
            this.ds_categoriaclifor.ST_PrimaryKey = false;
            this.ds_categoriaclifor.TabIndex = 88;
            this.ds_categoriaclifor.TextOld = null;
            // 
            // bb_categoriaclifor
            // 
            this.bb_categoriaclifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_categoriaclifor.Image")));
            this.bb_categoriaclifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_categoriaclifor.Location = new System.Drawing.Point(79, 62);
            this.bb_categoriaclifor.Name = "bb_categoriaclifor";
            this.bb_categoriaclifor.Size = new System.Drawing.Size(28, 19);
            this.bb_categoriaclifor.TabIndex = 3;
            this.bb_categoriaclifor.UseVisualStyleBackColor = true;
            this.bb_categoriaclifor.Click += new System.EventHandler(this.bb_categoriaclifor_Click);
            // 
            // id_categoriaclifor
            // 
            this.id_categoriaclifor.BackColor = System.Drawing.SystemColors.Window;
            this.id_categoriaclifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_categoriaclifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_categoriaclifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Id_categoriacliforstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_categoriaclifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_categoriaclifor.Location = new System.Drawing.Point(11, 62);
            this.id_categoriaclifor.Name = "id_categoriaclifor";
            this.id_categoriaclifor.NM_Alias = "";
            this.id_categoriaclifor.NM_Campo = "id_categoriaclifor";
            this.id_categoriaclifor.NM_CampoBusca = "id_categoriaclifor";
            this.id_categoriaclifor.NM_Param = "@P_CD_EMPRESA";
            this.id_categoriaclifor.QTD_Zero = 0;
            this.id_categoriaclifor.Size = new System.Drawing.Size(66, 20);
            this.id_categoriaclifor.ST_AutoInc = false;
            this.id_categoriaclifor.ST_DisableAuto = false;
            this.id_categoriaclifor.ST_Float = false;
            this.id_categoriaclifor.ST_Gravar = true;
            this.id_categoriaclifor.ST_Int = true;
            this.id_categoriaclifor.ST_LimpaCampo = true;
            this.id_categoriaclifor.ST_NotNull = false;
            this.id_categoriaclifor.ST_PrimaryKey = false;
            this.id_categoriaclifor.TabIndex = 2;
            this.id_categoriaclifor.TextOld = null;
            this.id_categoriaclifor.Leave += new System.EventHandler(this.id_categoriaclifor_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Categoria Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_empresa.Location = new System.Drawing.Point(113, 23);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_CD_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(472, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = true;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 84;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(79, 23);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProgEspecialVenda, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(11, 23);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "CD_Empresa";
            this.cd_empresa.NM_CampoBusca = "CD_Empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(66, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(8, 7);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(51, 13);
            this.label37.TabIndex = 83;
            this.label37.Text = "Empresa:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFProgEspecialVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 395);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFProgEspecialVenda";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programação Especial Venda";
            this.Load += new System.EventHandler(this.TFProgEspecialVenda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFProgEspecialVenda_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProgEspecialVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_minvenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.ComboBoxDefault tp_valor;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat valor;
        private System.Windows.Forms.Label label4;
        private Componentes.ComboBoxDefault tp_preco;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault ds_grupo;
        private System.Windows.Forms.Button bb_grupo;
        private Componentes.EditDefault cd_grupo;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_categoriaclifor;
        private System.Windows.Forms.Button bb_categoriaclifor;
        private Componentes.EditDefault id_categoriaclifor;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label37;
        private Componentes.ComboBoxDefault tp_acresdesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bsProgEspecialVenda;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault nm_clifor;
        private System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault ds_tabelapreco;
        private System.Windows.Forms.Button bb_tabelapreco;
        private Componentes.EditDefault cd_tabelapreco;
        private System.Windows.Forms.Label lbTabela;
        private Componentes.EditFloat qtd_minvenda;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault ds_tabelaprecoloc;
        private System.Windows.Forms.Button bb_tabelaprecoloc;
        private Componentes.EditDefault id_tabelaprecoloc;
        private System.Windows.Forms.Label lbTabelalocacao;
        private Componentes.EditData dt_finvigencia;
        private System.Windows.Forms.Label label11;
        private Componentes.EditData dt_inivigencia;
        private System.Windows.Forms.Label label9;
    }
}