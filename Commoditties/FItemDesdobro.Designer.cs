namespace Commoditties
{
    partial class TFItemDesdobro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItemDesdobro));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_contratante = new System.Windows.Forms.Button();
            this.vl_desdobro = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbQtdPerc = new Componentes.ComboBoxDefault(this.components);
            this.rgnfProdutorRural = new Componentes.RadioGroup(this.components);
            this.pNfProdutor = new Componentes.PanelDados(this.components);
            this.label42 = new System.Windows.Forms.Label();
            this.vl_nfprodutor = new Componentes.EditFloat(this.components);
            this.label33 = new System.Windows.Forms.Label();
            this.qt_nfprodutor = new Componentes.EditFloat(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.dt_emissaonfprodutor = new Componentes.EditData(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.nr_notaprodutor = new Componentes.EditDefault(this.components);
            this.ds_tabela_dest = new Componentes.EditDefault(this.components);
            this.cd_tabela_dest = new Componentes.EditDefault(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.ds_produto_dest = new Componentes.EditDefault(this.components);
            this.cd_produto_dest = new Componentes.EditDefault(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.nm_empresa_dest = new Componentes.EditDefault(this.components);
            this.cd_empresa_dest = new Componentes.EditDefault(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.cd_contratante_dest = new Componentes.EditDefault(this.components);
            this.nm_contratante_dest = new Componentes.EditDefault(this.components);
            this.bb_Contrato_dest = new System.Windows.Forms.Button();
            this.nr_contrato_dest = new Componentes.EditDefault(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.rgRatearDesconto = new Componentes.RadioGroup(this.components);
            this.st_psliquido = new Componentes.RadioButtonDefault(this.components);
            this.st_psbruto = new Componentes.RadioButtonDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_desdobro)).BeginInit();
            this.rgnfProdutorRural.SuspendLayout();
            this.pNfProdutor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_nfprodutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_nfprodutor)).BeginInit();
            this.rgRatearDesconto.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(699, 43);
            this.barraMenu.TabIndex = 6;
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
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.bb_contratante);
            this.pDados.Controls.Add(this.vl_desdobro);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cbQtdPerc);
            this.pDados.Controls.Add(this.rgnfProdutorRural);
            this.pDados.Controls.Add(this.ds_tabela_dest);
            this.pDados.Controls.Add(this.cd_tabela_dest);
            this.pDados.Controls.Add(this.label18);
            this.pDados.Controls.Add(this.ds_produto_dest);
            this.pDados.Controls.Add(this.cd_produto_dest);
            this.pDados.Controls.Add(this.label19);
            this.pDados.Controls.Add(this.nm_empresa_dest);
            this.pDados.Controls.Add(this.cd_empresa_dest);
            this.pDados.Controls.Add(this.label20);
            this.pDados.Controls.Add(this.cd_contratante_dest);
            this.pDados.Controls.Add(this.nm_contratante_dest);
            this.pDados.Controls.Add(this.bb_Contrato_dest);
            this.pDados.Controls.Add(this.nr_contrato_dest);
            this.pDados.Controls.Add(this.label17);
            this.pDados.Controls.Add(this.label15);
            this.pDados.Controls.Add(this.rgRatearDesconto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(699, 257);
            this.pDados.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "Contratante:";
            // 
            // bb_contratante
            // 
            this.bb_contratante.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contratante.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_contratante.Image = ((System.Drawing.Image)(resources.GetObject("bb_contratante.Image")));
            this.bb_contratante.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contratante.Location = new System.Drawing.Point(194, 30);
            this.bb_contratante.Name = "bb_contratante";
            this.bb_contratante.Size = new System.Drawing.Size(30, 20);
            this.bb_contratante.TabIndex = 3;
            this.bb_contratante.UseVisualStyleBackColor = false;
            this.bb_contratante.Click += new System.EventHandler(this.bb_contratante_Click);
            // 
            // vl_desdobro
            // 
            this.vl_desdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_desdobro.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_desdobro.Location = new System.Drawing.Point(559, 220);
            this.vl_desdobro.Name = "vl_desdobro";
            this.vl_desdobro.NM_Alias = "";
            this.vl_desdobro.NM_Campo = "";
            this.vl_desdobro.NM_Param = "";
            this.vl_desdobro.Operador = "";
            this.vl_desdobro.Size = new System.Drawing.Size(127, 26);
            this.vl_desdobro.ST_AutoInc = false;
            this.vl_desdobro.ST_DisableAuto = false;
            this.vl_desdobro.ST_Gravar = false;
            this.vl_desdobro.ST_LimparCampo = true;
            this.vl_desdobro.ST_NotNull = false;
            this.vl_desdobro.ST_PrimaryKey = false;
            this.vl_desdobro.TabIndex = 8;
            this.vl_desdobro.ThousandsSeparator = true;
            this.vl_desdobro.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Quantidade/Percentual";
            // 
            // cbQtdPerc
            // 
            this.cbQtdPerc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQtdPerc.FormattingEnabled = true;
            this.cbQtdPerc.Items.AddRange(new object[] {
            "PERCENTUAL",
            "QUANTIDADE"});
            this.cbQtdPerc.Location = new System.Drawing.Point(426, 226);
            this.cbQtdPerc.Name = "cbQtdPerc";
            this.cbQtdPerc.NM_Alias = "";
            this.cbQtdPerc.NM_Campo = "";
            this.cbQtdPerc.NM_Param = "";
            this.cbQtdPerc.Size = new System.Drawing.Size(127, 21);
            this.cbQtdPerc.ST_Gravar = false;
            this.cbQtdPerc.ST_LimparCampo = true;
            this.cbQtdPerc.ST_NotNull = false;
            this.cbQtdPerc.TabIndex = 7;
            this.cbQtdPerc.SelectedIndexChanged += new System.EventHandler(this.cbQtdPerc_SelectedIndexChanged);
            // 
            // rgnfProdutorRural
            // 
            this.rgnfProdutorRural.Controls.Add(this.pNfProdutor);
            this.rgnfProdutorRural.Location = new System.Drawing.Point(86, 134);
            this.rgnfProdutorRural.Name = "rgnfProdutorRural";
            this.rgnfProdutorRural.NM_Alias = "";
            this.rgnfProdutorRural.NM_Campo = "";
            this.rgnfProdutorRural.NM_Param = "";
            this.rgnfProdutorRural.NM_Valor = "";
            this.rgnfProdutorRural.Size = new System.Drawing.Size(605, 67);
            this.rgnfProdutorRural.ST_Gravar = false;
            this.rgnfProdutorRural.ST_NotNull = false;
            this.rgnfProdutorRural.TabIndex = 5;
            this.rgnfProdutorRural.TabStop = false;
            this.rgnfProdutorRural.Text = "Nota Fiscal Produtor Rural";
            // 
            // pNfProdutor
            // 
            this.pNfProdutor.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pNfProdutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pNfProdutor.Controls.Add(this.label42);
            this.pNfProdutor.Controls.Add(this.vl_nfprodutor);
            this.pNfProdutor.Controls.Add(this.label33);
            this.pNfProdutor.Controls.Add(this.qt_nfprodutor);
            this.pNfProdutor.Controls.Add(this.label22);
            this.pNfProdutor.Controls.Add(this.dt_emissaonfprodutor);
            this.pNfProdutor.Controls.Add(this.label21);
            this.pNfProdutor.Controls.Add(this.nr_notaprodutor);
            this.pNfProdutor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pNfProdutor.Location = new System.Drawing.Point(3, 16);
            this.pNfProdutor.Name = "pNfProdutor";
            this.pNfProdutor.NM_ProcDeletar = "";
            this.pNfProdutor.NM_ProcGravar = "";
            this.pNfProdutor.Size = new System.Drawing.Size(599, 48);
            this.pNfProdutor.TabIndex = 0;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(341, 4);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(48, 13);
            this.label42.TabIndex = 16;
            this.label42.Text = "Valor NF";
            this.label42.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // vl_nfprodutor
            // 
            this.vl_nfprodutor.DecimalPlaces = 2;
            this.vl_nfprodutor.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_nfprodutor.Location = new System.Drawing.Point(344, 20);
            this.vl_nfprodutor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_nfprodutor.Name = "vl_nfprodutor";
            this.vl_nfprodutor.NM_Alias = "";
            this.vl_nfprodutor.NM_Campo = "";
            this.vl_nfprodutor.NM_Param = "";
            this.vl_nfprodutor.Operador = "";
            this.vl_nfprodutor.Size = new System.Drawing.Size(120, 20);
            this.vl_nfprodutor.ST_AutoInc = false;
            this.vl_nfprodutor.ST_DisableAuto = false;
            this.vl_nfprodutor.ST_Gravar = true;
            this.vl_nfprodutor.ST_LimparCampo = true;
            this.vl_nfprodutor.ST_NotNull = false;
            this.vl_nfprodutor.ST_PrimaryKey = false;
            this.vl_nfprodutor.TabIndex = 3;
            this.vl_nfprodutor.ThousandsSeparator = true;
            this.vl_nfprodutor.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(215, 4);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(79, 13);
            this.label33.TabIndex = 14;
            this.label33.Text = "Quantidade NF";
            this.label33.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // qt_nfprodutor
            // 
            this.qt_nfprodutor.DecimalPlaces = 3;
            this.qt_nfprodutor.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qt_nfprodutor.Location = new System.Drawing.Point(218, 20);
            this.qt_nfprodutor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qt_nfprodutor.Name = "qt_nfprodutor";
            this.qt_nfprodutor.NM_Alias = "";
            this.qt_nfprodutor.NM_Campo = "";
            this.qt_nfprodutor.NM_Param = "";
            this.qt_nfprodutor.Operador = "";
            this.qt_nfprodutor.Size = new System.Drawing.Size(120, 20);
            this.qt_nfprodutor.ST_AutoInc = false;
            this.qt_nfprodutor.ST_DisableAuto = false;
            this.qt_nfprodutor.ST_Gravar = true;
            this.qt_nfprodutor.ST_LimparCampo = true;
            this.qt_nfprodutor.ST_NotNull = false;
            this.qt_nfprodutor.ST_PrimaryKey = false;
            this.qt_nfprodutor.TabIndex = 2;
            this.qt_nfprodutor.ThousandsSeparator = true;
            this.qt_nfprodutor.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(109, 4);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "Data Emissão";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dt_emissaonfprodutor
            // 
            this.dt_emissaonfprodutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_emissaonfprodutor.Location = new System.Drawing.Point(112, 20);
            this.dt_emissaonfprodutor.Mask = "00/00/0000";
            this.dt_emissaonfprodutor.Name = "dt_emissaonfprodutor";
            this.dt_emissaonfprodutor.NM_Alias = "";
            this.dt_emissaonfprodutor.NM_Campo = "";
            this.dt_emissaonfprodutor.NM_CampoBusca = "";
            this.dt_emissaonfprodutor.NM_Param = "";
            this.dt_emissaonfprodutor.Operador = "";
            this.dt_emissaonfprodutor.Size = new System.Drawing.Size(100, 20);
            this.dt_emissaonfprodutor.ST_Gravar = true;
            this.dt_emissaonfprodutor.ST_LimpaCampo = true;
            this.dt_emissaonfprodutor.ST_NotNull = false;
            this.dt_emissaonfprodutor.ST_PrimaryKey = false;
            this.dt_emissaonfprodutor.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(3, 4);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 13);
            this.label21.TabIndex = 10;
            this.label21.Text = "Nº Nota Fiscal";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nr_notaprodutor
            // 
            this.nr_notaprodutor.BackColor = System.Drawing.SystemColors.Window;
            this.nr_notaprodutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_notaprodutor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_notaprodutor.Location = new System.Drawing.Point(6, 20);
            this.nr_notaprodutor.Name = "nr_notaprodutor";
            this.nr_notaprodutor.NM_Alias = "";
            this.nr_notaprodutor.NM_Campo = "";
            this.nr_notaprodutor.NM_CampoBusca = "";
            this.nr_notaprodutor.NM_Param = "";
            this.nr_notaprodutor.QTD_Zero = 0;
            this.nr_notaprodutor.Size = new System.Drawing.Size(100, 20);
            this.nr_notaprodutor.ST_AutoInc = false;
            this.nr_notaprodutor.ST_DisableAuto = false;
            this.nr_notaprodutor.ST_Float = false;
            this.nr_notaprodutor.ST_Gravar = true;
            this.nr_notaprodutor.ST_Int = false;
            this.nr_notaprodutor.ST_LimpaCampo = true;
            this.nr_notaprodutor.ST_NotNull = false;
            this.nr_notaprodutor.ST_PrimaryKey = false;
            this.nr_notaprodutor.TabIndex = 0;
            this.nr_notaprodutor.TextOld = null;
            // 
            // ds_tabela_dest
            // 
            this.ds_tabela_dest.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabela_dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tabela_dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabela_dest.Enabled = false;
            this.ds_tabela_dest.Location = new System.Drawing.Point(188, 108);
            this.ds_tabela_dest.Name = "ds_tabela_dest";
            this.ds_tabela_dest.NM_Alias = "";
            this.ds_tabela_dest.NM_Campo = "ds_tabeladesconto";
            this.ds_tabela_dest.NM_CampoBusca = "ds_tabeladesconto";
            this.ds_tabela_dest.NM_Param = "@P_DS_TABELADESCONTO";
            this.ds_tabela_dest.QTD_Zero = 0;
            this.ds_tabela_dest.Size = new System.Drawing.Size(503, 20);
            this.ds_tabela_dest.ST_AutoInc = false;
            this.ds_tabela_dest.ST_DisableAuto = false;
            this.ds_tabela_dest.ST_Float = false;
            this.ds_tabela_dest.ST_Gravar = false;
            this.ds_tabela_dest.ST_Int = false;
            this.ds_tabela_dest.ST_LimpaCampo = true;
            this.ds_tabela_dest.ST_NotNull = false;
            this.ds_tabela_dest.ST_PrimaryKey = false;
            this.ds_tabela_dest.TabIndex = 46;
            this.ds_tabela_dest.TextOld = null;
            // 
            // cd_tabela_dest
            // 
            this.cd_tabela_dest.BackColor = System.Drawing.SystemColors.Window;
            this.cd_tabela_dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_tabela_dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tabela_dest.Enabled = false;
            this.cd_tabela_dest.Location = new System.Drawing.Point(86, 108);
            this.cd_tabela_dest.Name = "cd_tabela_dest";
            this.cd_tabela_dest.NM_Alias = "";
            this.cd_tabela_dest.NM_Campo = "cd_tabeladesconto";
            this.cd_tabela_dest.NM_CampoBusca = "cd_tabeladesconto";
            this.cd_tabela_dest.NM_Param = "@P_CD_TABELA_DEST";
            this.cd_tabela_dest.QTD_Zero = 0;
            this.cd_tabela_dest.Size = new System.Drawing.Size(100, 20);
            this.cd_tabela_dest.ST_AutoInc = false;
            this.cd_tabela_dest.ST_DisableAuto = false;
            this.cd_tabela_dest.ST_Float = false;
            this.cd_tabela_dest.ST_Gravar = false;
            this.cd_tabela_dest.ST_Int = false;
            this.cd_tabela_dest.ST_LimpaCampo = true;
            this.cd_tabela_dest.ST_NotNull = false;
            this.cd_tabela_dest.ST_PrimaryKey = false;
            this.cd_tabela_dest.TabIndex = 45;
            this.cd_tabela_dest.TextOld = null;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 110);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 44;
            this.label18.Text = "Tabela Desc.:";
            // 
            // ds_produto_dest
            // 
            this.ds_produto_dest.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto_dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto_dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto_dest.Enabled = false;
            this.ds_produto_dest.Location = new System.Drawing.Point(188, 82);
            this.ds_produto_dest.Name = "ds_produto_dest";
            this.ds_produto_dest.NM_Alias = "";
            this.ds_produto_dest.NM_Campo = "ds_produto";
            this.ds_produto_dest.NM_CampoBusca = "ds_produto";
            this.ds_produto_dest.NM_Param = "@P_DS_PRODUTO_DEST";
            this.ds_produto_dest.QTD_Zero = 0;
            this.ds_produto_dest.Size = new System.Drawing.Size(503, 20);
            this.ds_produto_dest.ST_AutoInc = false;
            this.ds_produto_dest.ST_DisableAuto = false;
            this.ds_produto_dest.ST_Float = false;
            this.ds_produto_dest.ST_Gravar = false;
            this.ds_produto_dest.ST_Int = false;
            this.ds_produto_dest.ST_LimpaCampo = true;
            this.ds_produto_dest.ST_NotNull = false;
            this.ds_produto_dest.ST_PrimaryKey = false;
            this.ds_produto_dest.TabIndex = 43;
            this.ds_produto_dest.TextOld = null;
            // 
            // cd_produto_dest
            // 
            this.cd_produto_dest.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto_dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto_dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto_dest.Enabled = false;
            this.cd_produto_dest.Location = new System.Drawing.Point(86, 82);
            this.cd_produto_dest.Name = "cd_produto_dest";
            this.cd_produto_dest.NM_Alias = "";
            this.cd_produto_dest.NM_Campo = "cd_produto";
            this.cd_produto_dest.NM_CampoBusca = "cd_produto";
            this.cd_produto_dest.NM_Param = "@P_CD_PRODUTO";
            this.cd_produto_dest.QTD_Zero = 0;
            this.cd_produto_dest.Size = new System.Drawing.Size(100, 20);
            this.cd_produto_dest.ST_AutoInc = false;
            this.cd_produto_dest.ST_DisableAuto = false;
            this.cd_produto_dest.ST_Float = false;
            this.cd_produto_dest.ST_Gravar = false;
            this.cd_produto_dest.ST_Int = false;
            this.cd_produto_dest.ST_LimpaCampo = true;
            this.cd_produto_dest.ST_NotNull = false;
            this.cd_produto_dest.ST_PrimaryKey = false;
            this.cd_produto_dest.TabIndex = 42;
            this.cd_produto_dest.TextOld = null;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(33, 84);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 41;
            this.label19.Text = "Produto:";
            // 
            // nm_empresa_dest
            // 
            this.nm_empresa_dest.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa_dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa_dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa_dest.Enabled = false;
            this.nm_empresa_dest.Location = new System.Drawing.Point(152, 56);
            this.nm_empresa_dest.Name = "nm_empresa_dest";
            this.nm_empresa_dest.NM_Alias = "";
            this.nm_empresa_dest.NM_Campo = "nm_empresa";
            this.nm_empresa_dest.NM_CampoBusca = "nm_empresa";
            this.nm_empresa_dest.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa_dest.QTD_Zero = 0;
            this.nm_empresa_dest.Size = new System.Drawing.Size(539, 20);
            this.nm_empresa_dest.ST_AutoInc = false;
            this.nm_empresa_dest.ST_DisableAuto = false;
            this.nm_empresa_dest.ST_Float = false;
            this.nm_empresa_dest.ST_Gravar = false;
            this.nm_empresa_dest.ST_Int = false;
            this.nm_empresa_dest.ST_LimpaCampo = true;
            this.nm_empresa_dest.ST_NotNull = false;
            this.nm_empresa_dest.ST_PrimaryKey = false;
            this.nm_empresa_dest.TabIndex = 40;
            this.nm_empresa_dest.TextOld = null;
            // 
            // cd_empresa_dest
            // 
            this.cd_empresa_dest.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa_dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa_dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa_dest.Enabled = false;
            this.cd_empresa_dest.Location = new System.Drawing.Point(86, 56);
            this.cd_empresa_dest.Name = "cd_empresa_dest";
            this.cd_empresa_dest.NM_Alias = "";
            this.cd_empresa_dest.NM_Campo = "cd_empresa";
            this.cd_empresa_dest.NM_CampoBusca = "cd_empresa";
            this.cd_empresa_dest.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa_dest.QTD_Zero = 0;
            this.cd_empresa_dest.Size = new System.Drawing.Size(64, 20);
            this.cd_empresa_dest.ST_AutoInc = false;
            this.cd_empresa_dest.ST_DisableAuto = false;
            this.cd_empresa_dest.ST_Float = false;
            this.cd_empresa_dest.ST_Gravar = false;
            this.cd_empresa_dest.ST_Int = false;
            this.cd_empresa_dest.ST_LimpaCampo = true;
            this.cd_empresa_dest.ST_NotNull = false;
            this.cd_empresa_dest.ST_PrimaryKey = false;
            this.cd_empresa_dest.TabIndex = 39;
            this.cd_empresa_dest.TextOld = null;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(29, 58);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "Empresa:";
            // 
            // cd_contratante_dest
            // 
            this.cd_contratante_dest.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contratante_dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contratante_dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contratante_dest.Location = new System.Drawing.Point(86, 30);
            this.cd_contratante_dest.MaxLength = 10;
            this.cd_contratante_dest.Name = "cd_contratante_dest";
            this.cd_contratante_dest.NM_Alias = "a";
            this.cd_contratante_dest.NM_Campo = "CD_Clifor";
            this.cd_contratante_dest.NM_CampoBusca = "CD_Clifor";
            this.cd_contratante_dest.NM_Param = "@P_CD_CLIFOR";
            this.cd_contratante_dest.QTD_Zero = 0;
            this.cd_contratante_dest.Size = new System.Drawing.Size(106, 20);
            this.cd_contratante_dest.ST_AutoInc = false;
            this.cd_contratante_dest.ST_DisableAuto = false;
            this.cd_contratante_dest.ST_Float = false;
            this.cd_contratante_dest.ST_Gravar = true;
            this.cd_contratante_dest.ST_Int = false;
            this.cd_contratante_dest.ST_LimpaCampo = true;
            this.cd_contratante_dest.ST_NotNull = false;
            this.cd_contratante_dest.ST_PrimaryKey = false;
            this.cd_contratante_dest.TabIndex = 2;
            this.cd_contratante_dest.TextOld = null;
            this.cd_contratante_dest.Leave += new System.EventHandler(this.cd_contratante_dest_Leave);
            // 
            // nm_contratante_dest
            // 
            this.nm_contratante_dest.BackColor = System.Drawing.SystemColors.Window;
            this.nm_contratante_dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_contratante_dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_contratante_dest.Location = new System.Drawing.Point(230, 30);
            this.nm_contratante_dest.Name = "nm_contratante_dest";
            this.nm_contratante_dest.NM_Alias = "a";
            this.nm_contratante_dest.NM_Campo = "nm_clifor";
            this.nm_contratante_dest.NM_CampoBusca = "nm_clifor";
            this.nm_contratante_dest.NM_Param = "@P_NM_CLIFOR";
            this.nm_contratante_dest.QTD_Zero = 0;
            this.nm_contratante_dest.Size = new System.Drawing.Size(461, 20);
            this.nm_contratante_dest.ST_AutoInc = false;
            this.nm_contratante_dest.ST_DisableAuto = false;
            this.nm_contratante_dest.ST_Float = false;
            this.nm_contratante_dest.ST_Gravar = true;
            this.nm_contratante_dest.ST_Int = false;
            this.nm_contratante_dest.ST_LimpaCampo = true;
            this.nm_contratante_dest.ST_NotNull = false;
            this.nm_contratante_dest.ST_PrimaryKey = false;
            this.nm_contratante_dest.TabIndex = 4;
            this.nm_contratante_dest.TextOld = null;
            // 
            // bb_Contrato_dest
            // 
            this.bb_Contrato_dest.BackColor = System.Drawing.SystemColors.Control;
            this.bb_Contrato_dest.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_Contrato_dest.Image = ((System.Drawing.Image)(resources.GetObject("bb_Contrato_dest.Image")));
            this.bb_Contrato_dest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_Contrato_dest.Location = new System.Drawing.Point(194, 4);
            this.bb_Contrato_dest.Name = "bb_Contrato_dest";
            this.bb_Contrato_dest.Size = new System.Drawing.Size(30, 20);
            this.bb_Contrato_dest.TabIndex = 1;
            this.bb_Contrato_dest.UseVisualStyleBackColor = false;
            this.bb_Contrato_dest.Click += new System.EventHandler(this.bb_Contrato_dest_Click);
            // 
            // nr_contrato_dest
            // 
            this.nr_contrato_dest.BackColor = System.Drawing.SystemColors.Window;
            this.nr_contrato_dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_contrato_dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_contrato_dest.Location = new System.Drawing.Point(86, 4);
            this.nr_contrato_dest.MaxLength = 10;
            this.nr_contrato_dest.Name = "nr_contrato_dest";
            this.nr_contrato_dest.NM_Alias = "a";
            this.nr_contrato_dest.NM_Campo = "nr_contrato";
            this.nr_contrato_dest.NM_CampoBusca = "nr_contrato";
            this.nr_contrato_dest.NM_Param = "@P_NR_CONTRATO";
            this.nr_contrato_dest.QTD_Zero = 0;
            this.nr_contrato_dest.Size = new System.Drawing.Size(106, 20);
            this.nr_contrato_dest.ST_AutoInc = false;
            this.nr_contrato_dest.ST_DisableAuto = false;
            this.nr_contrato_dest.ST_Float = false;
            this.nr_contrato_dest.ST_Gravar = true;
            this.nr_contrato_dest.ST_Int = false;
            this.nr_contrato_dest.ST_LimpaCampo = true;
            this.nr_contrato_dest.ST_NotNull = false;
            this.nr_contrato_dest.ST_PrimaryKey = false;
            this.nr_contrato_dest.TabIndex = 0;
            this.nr_contrato_dest.TextOld = null;
            this.nr_contrato_dest.Leave += new System.EventHandler(this.nr_contrato_dest_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(2, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Contrato Dest.:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(556, 202);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Quantidade Desdobro";
            // 
            // rgRatearDesconto
            // 
            this.rgRatearDesconto.Controls.Add(this.st_psliquido);
            this.rgRatearDesconto.Controls.Add(this.st_psbruto);
            this.rgRatearDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgRatearDesconto.ForeColor = System.Drawing.Color.Maroon;
            this.rgRatearDesconto.Location = new System.Drawing.Point(86, 207);
            this.rgRatearDesconto.Name = "rgRatearDesconto";
            this.rgRatearDesconto.NM_Alias = "";
            this.rgRatearDesconto.NM_Campo = "";
            this.rgRatearDesconto.NM_Param = "";
            this.rgRatearDesconto.NM_Valor = "";
            this.rgRatearDesconto.Size = new System.Drawing.Size(334, 39);
            this.rgRatearDesconto.ST_Gravar = false;
            this.rgRatearDesconto.ST_NotNull = false;
            this.rgRatearDesconto.TabIndex = 6;
            this.rgRatearDesconto.TabStop = false;
            this.rgRatearDesconto.Text = "Ratear Desconto sobre";
            // 
            // st_psliquido
            // 
            this.st_psliquido.AutoSize = true;
            this.st_psliquido.Checked = true;
            this.st_psliquido.ForeColor = System.Drawing.SystemColors.ControlText;
            this.st_psliquido.Location = new System.Drawing.Point(230, 16);
            this.st_psliquido.Name = "st_psliquido";
            this.st_psliquido.Size = new System.Drawing.Size(98, 17);
            this.st_psliquido.TabIndex = 2;
            this.st_psliquido.TabStop = true;
            this.st_psliquido.Text = "Peso Liquido";
            this.st_psliquido.UseVisualStyleBackColor = true;
            this.st_psliquido.Valor = "";
            // 
            // st_psbruto
            // 
            this.st_psbruto.AutoSize = true;
            this.st_psbruto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.st_psbruto.Location = new System.Drawing.Point(10, 16);
            this.st_psbruto.Name = "st_psbruto";
            this.st_psbruto.Size = new System.Drawing.Size(116, 17);
            this.st_psbruto.TabIndex = 0;
            this.st_psbruto.Text = "Liquido Balança";
            this.st_psbruto.UseVisualStyleBackColor = true;
            this.st_psbruto.Valor = "";
            // 
            // TFItemDesdobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 300);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItemDesdobro";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itens Desdobro";
            this.Load += new System.EventHandler(this.TFItemDesdobro_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItemDesdobro_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_desdobro)).EndInit();
            this.rgnfProdutorRural.ResumeLayout(false);
            this.pNfProdutor.ResumeLayout(false);
            this.pNfProdutor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_nfprodutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_nfprodutor)).EndInit();
            this.rgRatearDesconto.ResumeLayout(false);
            this.rgRatearDesconto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.RadioGroup rgnfProdutorRural;
        private Componentes.PanelDados pNfProdutor;
        private System.Windows.Forms.Label label42;
        private Componentes.EditFloat vl_nfprodutor;
        private System.Windows.Forms.Label label33;
        private Componentes.EditFloat qt_nfprodutor;
        private System.Windows.Forms.Label label22;
        private Componentes.EditData dt_emissaonfprodutor;
        private System.Windows.Forms.Label label21;
        private Componentes.EditDefault nr_notaprodutor;
        private Componentes.EditDefault ds_tabela_dest;
        private Componentes.EditDefault cd_tabela_dest;
        private System.Windows.Forms.Label label18;
        private Componentes.EditDefault ds_produto_dest;
        private Componentes.EditDefault cd_produto_dest;
        private System.Windows.Forms.Label label19;
        private Componentes.EditDefault nm_empresa_dest;
        private Componentes.EditDefault cd_empresa_dest;
        private System.Windows.Forms.Label label20;
        private Componentes.EditDefault cd_contratante_dest;
        private Componentes.EditDefault nm_contratante_dest;
        private System.Windows.Forms.Button bb_Contrato_dest;
        private Componentes.EditDefault nr_contrato_dest;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private Componentes.RadioGroup rgRatearDesconto;
        private Componentes.RadioButtonDefault st_psbruto;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault cbQtdPerc;
        private Componentes.EditFloat vl_desdobro;
        private System.Windows.Forms.Button bb_contratante;
        private System.Windows.Forms.Label label2;
        private Componentes.RadioButtonDefault st_psliquido;
    }
}