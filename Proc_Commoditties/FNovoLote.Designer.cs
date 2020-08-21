namespace Proc_Commoditties
{
    partial class TFNovoLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFNovoLote));
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label10;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados();
            this.ds_formulacao = new Componentes.EditDefault();
            this.bsLoteSemente = new System.Windows.Forms.BindingSource();
            this.renasem = new Componentes.EditDefault();
            this.pAnalise = new Componentes.PanelDados();
            this.cd_certificado = new Componentes.EditDefault();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pc_pureza = new Componentes.EditFloat();
            this.label9 = new System.Windows.Forms.Label();
            this.pc_germinacao = new Componentes.EditFloat();
            this.dt_valgerminacao = new Componentes.EditData();
            this.label13 = new System.Windows.Forms.Label();
            this.Conformidade = new Componentes.EditDefault();
            this.label7 = new System.Windows.Forms.Label();
            this.ds_produto = new Componentes.EditDefault();
            this.nr_lote = new Componentes.EditDefault();
            this.label6 = new System.Windows.Forms.Label();
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault();
            this.dt_lote = new Componentes.EditData();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.nm_empresa = new Componentes.EditDefault();
            this.cd_empresa = new Componentes.EditDefault();
            label16 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoteSemente)).BeginInit();
            this.pAnalise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_pureza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_germinacao)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(608, 43);
            this.barraMenu.TabIndex = 3;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(label16);
            this.pDados.Controls.Add(this.ds_formulacao);
            this.pDados.Controls.Add(this.renasem);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.pAnalise);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.nr_lote);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.dt_lote);
            this.pDados.Controls.Add(label8);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(label10);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(608, 182);
            this.pDados.TabIndex = 12;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label16.Location = new System.Drawing.Point(14, 133);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(65, 13);
            label16.TabIndex = 86;
            label16.Text = "Formulação:";
            // 
            // ds_formulacao
            // 
            this.ds_formulacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_formulacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_formulacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_formulacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Ds_formulacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_formulacao.Location = new System.Drawing.Point(84, 131);
            this.ds_formulacao.Multiline = true;
            this.ds_formulacao.Name = "ds_formulacao";
            this.ds_formulacao.NM_Alias = "";
            this.ds_formulacao.NM_Campo = "nm_empresa";
            this.ds_formulacao.NM_CampoBusca = "nm_empresa";
            this.ds_formulacao.NM_Param = "@P_NM_EMPRESA";
            this.ds_formulacao.QTD_Zero = 0;
            this.ds_formulacao.Size = new System.Drawing.Size(500, 46);
            this.ds_formulacao.ST_AutoInc = false;
            this.ds_formulacao.ST_DisableAuto = false;
            this.ds_formulacao.ST_Float = false;
            this.ds_formulacao.ST_Gravar = false;
            this.ds_formulacao.ST_Int = false;
            this.ds_formulacao.ST_LimpaCampo = true;
            this.ds_formulacao.ST_NotNull = false;
            this.ds_formulacao.ST_PrimaryKey = false;
            this.ds_formulacao.TabIndex = 9;
            this.ds_formulacao.TextOld = null;
            // 
            // bsLoteSemente
            // 
            this.bsLoteSemente.DataSource = typeof(CamadaDados.Sementes.TList_LoteSemente);
            // 
            // renasem
            // 
            this.renasem.BackColor = System.Drawing.SystemColors.Window;
            this.renasem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renasem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.renasem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Renasem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.renasem.Location = new System.Drawing.Point(443, 29);
            this.renasem.Name = "renasem";
            this.renasem.NM_Alias = "";
            this.renasem.NM_Campo = "";
            this.renasem.NM_CampoBusca = "";
            this.renasem.NM_Param = "";
            this.renasem.QTD_Zero = 0;
            this.renasem.Size = new System.Drawing.Size(140, 20);
            this.renasem.ST_AutoInc = false;
            this.renasem.ST_DisableAuto = false;
            this.renasem.ST_Float = false;
            this.renasem.ST_Gravar = false;
            this.renasem.ST_Int = false;
            this.renasem.ST_LimpaCampo = true;
            this.renasem.ST_NotNull = true;
            this.renasem.ST_PrimaryKey = false;
            this.renasem.TabIndex = 4;
            this.renasem.TextOld = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(383, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 13);
            label1.TabIndex = 74;
            label1.Text = "Renasem:";
            // 
            // pAnalise
            // 
            this.pAnalise.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pAnalise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAnalise.Controls.Add(this.cd_certificado);
            this.pAnalise.Controls.Add(this.label15);
            this.pAnalise.Controls.Add(this.label14);
            this.pAnalise.Controls.Add(this.pc_pureza);
            this.pAnalise.Controls.Add(this.label9);
            this.pAnalise.Controls.Add(this.pc_germinacao);
            this.pAnalise.Controls.Add(this.dt_valgerminacao);
            this.pAnalise.Controls.Add(this.label13);
            this.pAnalise.Controls.Add(this.Conformidade);
            this.pAnalise.Controls.Add(this.label7);
            this.pAnalise.Location = new System.Drawing.Point(84, 81);
            this.pAnalise.Name = "pAnalise";
            this.pAnalise.NM_ProcDeletar = "";
            this.pAnalise.NM_ProcGravar = "";
            this.pAnalise.Size = new System.Drawing.Size(500, 44);
            this.pAnalise.TabIndex = 7;
            // 
            // cd_certificado
            // 
            this.cd_certificado.BackColor = System.Drawing.SystemColors.Window;
            this.cd_certificado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_certificado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_certificado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Cd_certificado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_certificado.Location = new System.Drawing.Point(125, 18);
            this.cd_certificado.Name = "cd_certificado";
            this.cd_certificado.NM_Alias = "";
            this.cd_certificado.NM_Campo = "";
            this.cd_certificado.NM_CampoBusca = "";
            this.cd_certificado.NM_Param = "";
            this.cd_certificado.QTD_Zero = 0;
            this.cd_certificado.Size = new System.Drawing.Size(121, 20);
            this.cd_certificado.ST_AutoInc = false;
            this.cd_certificado.ST_DisableAuto = false;
            this.cd_certificado.ST_Float = false;
            this.cd_certificado.ST_Gravar = false;
            this.cd_certificado.ST_Int = false;
            this.cd_certificado.ST_LimpaCampo = true;
            this.cd_certificado.ST_NotNull = false;
            this.cd_certificado.ST_PrimaryKey = false;
            this.cd_certificado.TabIndex = 1;
            this.cd_certificado.TextOld = null;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(122, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 13);
            this.label15.TabIndex = 76;
            this.label15.Text = "Cd. Certificado";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(411, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 74;
            this.label14.Text = "% Pureza";
            // 
            // pc_pureza
            // 
            this.pc_pureza.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsLoteSemente, "Pc_pureza", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_pureza.DecimalPlaces = 2;
            this.pc_pureza.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pc_pureza.Location = new System.Drawing.Point(414, 18);
            this.pc_pureza.Name = "pc_pureza";
            this.pc_pureza.NM_Alias = "";
            this.pc_pureza.NM_Campo = "";
            this.pc_pureza.NM_Param = "";
            this.pc_pureza.Operador = "";
            this.pc_pureza.Size = new System.Drawing.Size(81, 20);
            this.pc_pureza.ST_AutoInc = false;
            this.pc_pureza.ST_DisableAuto = false;
            this.pc_pureza.ST_Gravar = false;
            this.pc_pureza.ST_LimparCampo = true;
            this.pc_pureza.ST_NotNull = false;
            this.pc_pureza.ST_PrimaryKey = false;
            this.pc_pureza.TabIndex = 4;
            this.pc_pureza.ThousandsSeparator = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(330, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 72;
            this.label9.Text = "% Germinação";
            // 
            // pc_germinacao
            // 
            this.pc_germinacao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsLoteSemente, "Pc_germinacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_germinacao.DecimalPlaces = 2;
            this.pc_germinacao.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pc_germinacao.Location = new System.Drawing.Point(333, 18);
            this.pc_germinacao.Name = "pc_germinacao";
            this.pc_germinacao.NM_Alias = "";
            this.pc_germinacao.NM_Campo = "";
            this.pc_germinacao.NM_Param = "";
            this.pc_germinacao.Operador = "";
            this.pc_germinacao.Size = new System.Drawing.Size(75, 20);
            this.pc_germinacao.ST_AutoInc = false;
            this.pc_germinacao.ST_DisableAuto = false;
            this.pc_germinacao.ST_Gravar = false;
            this.pc_germinacao.ST_LimparCampo = true;
            this.pc_germinacao.ST_NotNull = false;
            this.pc_germinacao.ST_PrimaryKey = false;
            this.pc_germinacao.TabIndex = 3;
            this.pc_germinacao.ThousandsSeparator = true;
            // 
            // dt_valgerminacao
            // 
            this.dt_valgerminacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_valgerminacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Dt_valgerminacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_valgerminacao.Location = new System.Drawing.Point(252, 18);
            this.dt_valgerminacao.Mask = "00/00/0000";
            this.dt_valgerminacao.Name = "dt_valgerminacao";
            this.dt_valgerminacao.NM_Alias = "";
            this.dt_valgerminacao.NM_Campo = "";
            this.dt_valgerminacao.NM_CampoBusca = "";
            this.dt_valgerminacao.NM_Param = "";
            this.dt_valgerminacao.Operador = "";
            this.dt_valgerminacao.Size = new System.Drawing.Size(73, 20);
            this.dt_valgerminacao.ST_Gravar = true;
            this.dt_valgerminacao.ST_LimpaCampo = true;
            this.dt_valgerminacao.ST_NotNull = false;
            this.dt_valgerminacao.ST_PrimaryKey = false;
            this.dt_valgerminacao.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(249, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 70;
            this.label13.Text = "Validade";
            // 
            // Conformidade
            // 
            this.Conformidade.BackColor = System.Drawing.SystemColors.Window;
            this.Conformidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Conformidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Conformidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Conformidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Conformidade.Location = new System.Drawing.Point(3, 18);
            this.Conformidade.Name = "Conformidade";
            this.Conformidade.NM_Alias = "";
            this.Conformidade.NM_Campo = "";
            this.Conformidade.NM_CampoBusca = "";
            this.Conformidade.NM_Param = "";
            this.Conformidade.QTD_Zero = 0;
            this.Conformidade.Size = new System.Drawing.Size(116, 20);
            this.Conformidade.ST_AutoInc = false;
            this.Conformidade.ST_DisableAuto = false;
            this.Conformidade.ST_Float = false;
            this.Conformidade.ST_Gravar = false;
            this.Conformidade.ST_Int = false;
            this.Conformidade.ST_LimpaCampo = true;
            this.Conformidade.ST_NotNull = false;
            this.Conformidade.ST_PrimaryKey = false;
            this.Conformidade.TabIndex = 0;
            this.Conformidade.TextOld = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(0, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "N° Conformidade";
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(174, 55);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_NM_EMPRESA";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(409, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 73;
            this.ds_produto.TextOld = null;
            // 
            // nr_lote
            // 
            this.nr_lote.BackColor = System.Drawing.SystemColors.Window;
            this.nr_lote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_lote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Nr_lote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_lote.Location = new System.Drawing.Point(83, 29);
            this.nr_lote.Name = "nr_lote";
            this.nr_lote.NM_Alias = "";
            this.nr_lote.NM_Campo = "";
            this.nr_lote.NM_CampoBusca = "";
            this.nr_lote.NM_Param = "";
            this.nr_lote.QTD_Zero = 0;
            this.nr_lote.Size = new System.Drawing.Size(152, 20);
            this.nr_lote.ST_AutoInc = false;
            this.nr_lote.ST_DisableAuto = false;
            this.nr_lote.ST_Float = false;
            this.nr_lote.ST_Gravar = false;
            this.nr_lote.ST_Int = false;
            this.nr_lote.ST_LimpaCampo = true;
            this.nr_lote.ST_NotNull = true;
            this.nr_lote.ST_PrimaryKey = false;
            this.nr_lote.TabIndex = 2;
            this.nr_lote.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(31, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Nº Lote:";
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(140, 55);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 6;
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(26, 58);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(52, 13);
            label3.TabIndex = 72;
            label3.Text = "Semente:";
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.Color.White;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Location = new System.Drawing.Point(84, 55);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(55, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 5;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // dt_lote
            // 
            this.dt_lote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_lote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Dt_lotestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_lote.Location = new System.Drawing.Point(304, 29);
            this.dt_lote.Mask = "00/00/0000";
            this.dt_lote.Name = "dt_lote";
            this.dt_lote.NM_Alias = "";
            this.dt_lote.NM_Campo = "";
            this.dt_lote.NM_CampoBusca = "";
            this.dt_lote.NM_Param = "";
            this.dt_lote.Operador = "";
            this.dt_lote.Size = new System.Drawing.Size(73, 20);
            this.dt_lote.ST_Gravar = true;
            this.dt_lote.ST_LimpaCampo = true;
            this.dt_lote.ST_NotNull = true;
            this.dt_lote.ST_PrimaryKey = false;
            this.dt_lote.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(241, 32);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(57, 13);
            label8.TabIndex = 59;
            label8.Text = "Data Lote:";
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(140, 3);
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
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(174, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(409, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 40;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(84, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(55, 20);
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
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label10.Location = new System.Drawing.Point(27, 6);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(51, 13);
            label10.TabIndex = 39;
            label10.Text = "Empresa:";
            // 
            // TFNovoLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 225);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFNovoLote";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Lote";
            this.Load += new System.EventHandler(this.TFNovoLote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFNovoLote_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoteSemente)).EndInit();
            this.pAnalise.ResumeLayout(false);
            this.pAnalise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_pureza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_germinacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.BindingSource bsLoteSemente;
        private Componentes.PanelDados pDados;
        private Componentes.PanelDados pAnalise;
        private Componentes.EditDefault cd_certificado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private Componentes.EditFloat pc_pureza;
        private System.Windows.Forms.Label label9;
        private Componentes.EditFloat pc_germinacao;
        private Componentes.EditData dt_valgerminacao;
        private System.Windows.Forms.Label label13;
        private Componentes.EditDefault Conformidade;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault nr_lote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditData dt_lote;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault renasem;
        private Componentes.EditDefault ds_formulacao;
    }
}