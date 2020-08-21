namespace PostoCombustivel
{
    partial class TFMedicaoTanque
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFMedicaoTanque));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_calcmedicao = new System.Windows.Forms.Button();
            this.pDetalhes = new Componentes.PanelDados(this.components);
            this.compras_dia = new Componentes.EditFloat(this.components);
            this.vendas_dia = new Componentes.EditFloat(this.components);
            this.ultima_afericao = new Componentes.EditFloat(this.components);
            this.tp_medicao = new Componentes.ComboBoxDefault(this.components);
            this.bsMedicao = new System.Windows.Forms.BindingSource(this.components);
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.qtd_combustivel = new Componentes.EditFloat(this.components);
            this.dt_medicao = new Componentes.EditData(this.components);
            this.cd_combustivel = new Componentes.EditDefault(this.components);
            this.ds_combustivel = new Componentes.EditDefault(this.components);
            this.nm_funcionario = new Componentes.EditDefault(this.components);
            this.bb_funcionario = new System.Windows.Forms.Button();
            this.cd_funcionario = new Componentes.EditDefault(this.components);
            this.bb_tanque = new System.Windows.Forms.Button();
            this.id_tanque = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pDetalhes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compras_dia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendas_dia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultima_afericao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMedicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_combustivel)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(6, 33);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(67, 13);
            label5.TabIndex = 102;
            label5.Text = "Combustivel:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(7, 110);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 13);
            label4.TabIndex = 101;
            label4.Text = "Qtd. Aferida:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(7, 85);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(66, 13);
            label7.TabIndex = 99;
            label7.Text = "Dt. Aferição:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(8, 59);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 13);
            label3.TabIndex = 94;
            label3.Text = "Funcionario:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(552, 7);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 13);
            label1.TabIndex = 91;
            label1.Text = "Tanque:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(22, 8);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 13);
            label2.TabIndex = 89;
            label2.Text = "Empresa:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(175, 85);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(73, 13);
            label6.TabIndex = 104;
            label6.Text = "Tipo Aferição:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(12, 6);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(81, 13);
            label8.TabIndex = 103;
            label8.Text = "Ultima Aferição:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label9.Location = new System.Drawing.Point(21, 32);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(72, 13);
            label9.TabIndex = 105;
            label9.Text = "Vendas Data:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label10.Location = new System.Drawing.Point(16, 58);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(77, 13);
            label10.TabIndex = 107;
            label10.Text = "Compras Data:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(688, 43);
            this.barraMenu.TabIndex = 16;
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
            this.pDados.Controls.Add(this.bb_calcmedicao);
            this.pDados.Controls.Add(this.pDetalhes);
            this.pDados.Controls.Add(this.tp_medicao);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.sigla_unidade);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.qtd_combustivel);
            this.pDados.Controls.Add(this.dt_medicao);
            this.pDados.Controls.Add(label7);
            this.pDados.Controls.Add(this.cd_combustivel);
            this.pDados.Controls.Add(this.ds_combustivel);
            this.pDados.Controls.Add(this.nm_funcionario);
            this.pDados.Controls.Add(this.bb_funcionario);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.cd_funcionario);
            this.pDados.Controls.Add(this.bb_tanque);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.id_tanque);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(688, 169);
            this.pDados.TabIndex = 17;
            // 
            // bb_calcmedicao
            // 
            this.bb_calcmedicao.Image = ((System.Drawing.Image)(resources.GetObject("bb_calcmedicao.Image")));
            this.bb_calcmedicao.Location = new System.Drawing.Point(239, 108);
            this.bb_calcmedicao.Name = "bb_calcmedicao";
            this.bb_calcmedicao.Size = new System.Drawing.Size(34, 20);
            this.bb_calcmedicao.TabIndex = 107;
            this.bb_calcmedicao.UseVisualStyleBackColor = true;
            this.bb_calcmedicao.Click += new System.EventHandler(this.bb_calcmedicao_Click);
            // 
            // pDetalhes
            // 
            this.pDetalhes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pDetalhes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDetalhes.Controls.Add(label10);
            this.pDetalhes.Controls.Add(this.compras_dia);
            this.pDetalhes.Controls.Add(label9);
            this.pDetalhes.Controls.Add(this.vendas_dia);
            this.pDetalhes.Controls.Add(label8);
            this.pDetalhes.Controls.Add(this.ultima_afericao);
            this.pDetalhes.Location = new System.Drawing.Point(458, 82);
            this.pDetalhes.Name = "pDetalhes";
            this.pDetalhes.NM_ProcDeletar = "";
            this.pDetalhes.NM_ProcGravar = "";
            this.pDetalhes.Size = new System.Drawing.Size(224, 82);
            this.pDetalhes.TabIndex = 106;
            // 
            // compras_dia
            // 
            this.compras_dia.DecimalPlaces = 3;
            this.compras_dia.Enabled = false;
            this.compras_dia.Location = new System.Drawing.Point(99, 56);
            this.compras_dia.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.compras_dia.Name = "compras_dia";
            this.compras_dia.NM_Alias = "";
            this.compras_dia.NM_Campo = "";
            this.compras_dia.NM_Param = "";
            this.compras_dia.Operador = "";
            this.compras_dia.Size = new System.Drawing.Size(120, 20);
            this.compras_dia.ST_AutoInc = false;
            this.compras_dia.ST_DisableAuto = false;
            this.compras_dia.ST_Gravar = true;
            this.compras_dia.ST_LimparCampo = true;
            this.compras_dia.ST_NotNull = false;
            this.compras_dia.ST_PrimaryKey = false;
            this.compras_dia.TabIndex = 106;
            this.compras_dia.ThousandsSeparator = true;
            // 
            // vendas_dia
            // 
            this.vendas_dia.DecimalPlaces = 3;
            this.vendas_dia.Enabled = false;
            this.vendas_dia.Location = new System.Drawing.Point(99, 30);
            this.vendas_dia.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.vendas_dia.Name = "vendas_dia";
            this.vendas_dia.NM_Alias = "";
            this.vendas_dia.NM_Campo = "";
            this.vendas_dia.NM_Param = "";
            this.vendas_dia.Operador = "";
            this.vendas_dia.Size = new System.Drawing.Size(120, 20);
            this.vendas_dia.ST_AutoInc = false;
            this.vendas_dia.ST_DisableAuto = false;
            this.vendas_dia.ST_Gravar = true;
            this.vendas_dia.ST_LimparCampo = true;
            this.vendas_dia.ST_NotNull = false;
            this.vendas_dia.ST_PrimaryKey = false;
            this.vendas_dia.TabIndex = 104;
            this.vendas_dia.ThousandsSeparator = true;
            // 
            // ultima_afericao
            // 
            this.ultima_afericao.DecimalPlaces = 3;
            this.ultima_afericao.Enabled = false;
            this.ultima_afericao.Location = new System.Drawing.Point(99, 4);
            this.ultima_afericao.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.ultima_afericao.Name = "ultima_afericao";
            this.ultima_afericao.NM_Alias = "";
            this.ultima_afericao.NM_Campo = "";
            this.ultima_afericao.NM_Param = "";
            this.ultima_afericao.Operador = "";
            this.ultima_afericao.Size = new System.Drawing.Size(120, 20);
            this.ultima_afericao.ST_AutoInc = false;
            this.ultima_afericao.ST_DisableAuto = false;
            this.ultima_afericao.ST_Gravar = true;
            this.ultima_afericao.ST_LimparCampo = true;
            this.ultima_afericao.ST_NotNull = false;
            this.ultima_afericao.ST_PrimaryKey = false;
            this.ultima_afericao.TabIndex = 102;
            this.ultima_afericao.ThousandsSeparator = true;
            // 
            // tp_medicao
            // 
            this.tp_medicao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMedicao, "Tp_medicao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_medicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_medicao.FormattingEnabled = true;
            this.tp_medicao.Location = new System.Drawing.Point(254, 81);
            this.tp_medicao.Name = "tp_medicao";
            this.tp_medicao.NM_Alias = "";
            this.tp_medicao.NM_Campo = "";
            this.tp_medicao.NM_Param = "";
            this.tp_medicao.Size = new System.Drawing.Size(198, 21);
            this.tp_medicao.ST_Gravar = false;
            this.tp_medicao.ST_LimparCampo = true;
            this.tp_medicao.ST_NotNull = true;
            this.tp_medicao.TabIndex = 9;
            this.tp_medicao.SelectedIndexChanged += new System.EventHandler(this.tp_medicao_SelectedIndexChanged);
            // 
            // bsMedicao
            // 
            this.bsMedicao.DataSource = typeof(CamadaDados.PostoCombustivel.TList_MedicaoTanque);
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMedicao, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Location = new System.Drawing.Point(200, 108);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "sg_produto";
            this.sigla_unidade.NM_CampoBusca = "sg_produto";
            this.sigla_unidade.NM_Param = "@P_NM_CLIFOR";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.Size = new System.Drawing.Size(33, 20);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 103;
            this.sigla_unidade.TextOld = null;
            // 
            // qtd_combustivel
            // 
            this.qtd_combustivel.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsMedicao, "Qtd_combustivel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_combustivel.DecimalPlaces = 3;
            this.qtd_combustivel.Location = new System.Drawing.Point(79, 108);
            this.qtd_combustivel.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.qtd_combustivel.Name = "qtd_combustivel";
            this.qtd_combustivel.NM_Alias = "";
            this.qtd_combustivel.NM_Campo = "";
            this.qtd_combustivel.NM_Param = "";
            this.qtd_combustivel.Operador = "";
            this.qtd_combustivel.Size = new System.Drawing.Size(120, 20);
            this.qtd_combustivel.ST_AutoInc = false;
            this.qtd_combustivel.ST_DisableAuto = false;
            this.qtd_combustivel.ST_Gravar = true;
            this.qtd_combustivel.ST_LimparCampo = true;
            this.qtd_combustivel.ST_NotNull = true;
            this.qtd_combustivel.ST_PrimaryKey = false;
            this.qtd_combustivel.TabIndex = 10;
            this.qtd_combustivel.ThousandsSeparator = true;
            this.qtd_combustivel.Leave += new System.EventHandler(this.qtd_combustivel_Leave);
            // 
            // dt_medicao
            // 
            this.dt_medicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_medicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMedicao, "Dt_medicaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_medicao.Location = new System.Drawing.Point(79, 82);
            this.dt_medicao.Mask = "00/00/0000";
            this.dt_medicao.Name = "dt_medicao";
            this.dt_medicao.NM_Alias = "";
            this.dt_medicao.NM_Campo = "";
            this.dt_medicao.NM_CampoBusca = "";
            this.dt_medicao.NM_Param = "";
            this.dt_medicao.Operador = "";
            this.dt_medicao.Size = new System.Drawing.Size(88, 20);
            this.dt_medicao.ST_Gravar = true;
            this.dt_medicao.ST_LimpaCampo = true;
            this.dt_medicao.ST_NotNull = true;
            this.dt_medicao.ST_PrimaryKey = false;
            this.dt_medicao.TabIndex = 8;
            this.dt_medicao.Leave += new System.EventHandler(this.dt_medicao_Leave);
            // 
            // cd_combustivel
            // 
            this.cd_combustivel.BackColor = System.Drawing.SystemColors.Window;
            this.cd_combustivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_combustivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_combustivel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMedicao, "Cd_combustivel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_combustivel.Enabled = false;
            this.cd_combustivel.Location = new System.Drawing.Point(79, 30);
            this.cd_combustivel.Name = "cd_combustivel";
            this.cd_combustivel.NM_Alias = "";
            this.cd_combustivel.NM_Campo = "cd_produto";
            this.cd_combustivel.NM_CampoBusca = "cd_produto";
            this.cd_combustivel.NM_Param = "@P_NM_CLIFOR";
            this.cd_combustivel.QTD_Zero = 0;
            this.cd_combustivel.Size = new System.Drawing.Size(88, 20);
            this.cd_combustivel.ST_AutoInc = false;
            this.cd_combustivel.ST_DisableAuto = false;
            this.cd_combustivel.ST_Float = false;
            this.cd_combustivel.ST_Gravar = false;
            this.cd_combustivel.ST_Int = false;
            this.cd_combustivel.ST_LimpaCampo = true;
            this.cd_combustivel.ST_NotNull = false;
            this.cd_combustivel.ST_PrimaryKey = false;
            this.cd_combustivel.TabIndex = 4;
            this.cd_combustivel.TextOld = null;
            // 
            // ds_combustivel
            // 
            this.ds_combustivel.BackColor = System.Drawing.SystemColors.Window;
            this.ds_combustivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_combustivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_combustivel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMedicao, "Ds_combustivel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_combustivel.Enabled = false;
            this.ds_combustivel.Location = new System.Drawing.Point(168, 30);
            this.ds_combustivel.Name = "ds_combustivel";
            this.ds_combustivel.NM_Alias = "";
            this.ds_combustivel.NM_Campo = "ds_produto";
            this.ds_combustivel.NM_CampoBusca = "ds_produto";
            this.ds_combustivel.NM_Param = "@P_NM_CLIFOR";
            this.ds_combustivel.QTD_Zero = 0;
            this.ds_combustivel.Size = new System.Drawing.Size(514, 20);
            this.ds_combustivel.ST_AutoInc = false;
            this.ds_combustivel.ST_DisableAuto = false;
            this.ds_combustivel.ST_Float = false;
            this.ds_combustivel.ST_Gravar = false;
            this.ds_combustivel.ST_Int = false;
            this.ds_combustivel.ST_LimpaCampo = true;
            this.ds_combustivel.ST_NotNull = false;
            this.ds_combustivel.ST_PrimaryKey = false;
            this.ds_combustivel.TabIndex = 5;
            this.ds_combustivel.TextOld = null;
            // 
            // nm_funcionario
            // 
            this.nm_funcionario.BackColor = System.Drawing.SystemColors.Window;
            this.nm_funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_funcionario.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMedicao, "Nm_funcionario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_funcionario.Enabled = false;
            this.nm_funcionario.Location = new System.Drawing.Point(202, 55);
            this.nm_funcionario.Name = "nm_funcionario";
            this.nm_funcionario.NM_Alias = "";
            this.nm_funcionario.NM_Campo = "nm_clifor";
            this.nm_funcionario.NM_CampoBusca = "nm_clifor";
            this.nm_funcionario.NM_Param = "@P_NM_CLIFOR";
            this.nm_funcionario.QTD_Zero = 0;
            this.nm_funcionario.Size = new System.Drawing.Size(480, 20);
            this.nm_funcionario.ST_AutoInc = false;
            this.nm_funcionario.ST_DisableAuto = false;
            this.nm_funcionario.ST_Float = false;
            this.nm_funcionario.ST_Gravar = false;
            this.nm_funcionario.ST_Int = false;
            this.nm_funcionario.ST_LimpaCampo = true;
            this.nm_funcionario.ST_NotNull = false;
            this.nm_funcionario.ST_PrimaryKey = false;
            this.nm_funcionario.TabIndex = 95;
            this.nm_funcionario.TextOld = null;
            // 
            // bb_funcionario
            // 
            this.bb_funcionario.BackColor = System.Drawing.SystemColors.Control;
            this.bb_funcionario.Image = ((System.Drawing.Image)(resources.GetObject("bb_funcionario.Image")));
            this.bb_funcionario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_funcionario.Location = new System.Drawing.Point(168, 55);
            this.bb_funcionario.Name = "bb_funcionario";
            this.bb_funcionario.Size = new System.Drawing.Size(28, 20);
            this.bb_funcionario.TabIndex = 7;
            this.bb_funcionario.UseVisualStyleBackColor = false;
            this.bb_funcionario.Click += new System.EventHandler(this.bb_funcionario_Click);
            // 
            // cd_funcionario
            // 
            this.cd_funcionario.BackColor = System.Drawing.Color.White;
            this.cd_funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_funcionario.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMedicao, "Cd_funcionario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_funcionario.Location = new System.Drawing.Point(79, 56);
            this.cd_funcionario.Name = "cd_funcionario";
            this.cd_funcionario.NM_Alias = "";
            this.cd_funcionario.NM_Campo = "cd_clifor";
            this.cd_funcionario.NM_CampoBusca = "cd_clifor";
            this.cd_funcionario.NM_Param = "@P_CD_EMPRESA";
            this.cd_funcionario.QTD_Zero = 0;
            this.cd_funcionario.Size = new System.Drawing.Size(88, 20);
            this.cd_funcionario.ST_AutoInc = false;
            this.cd_funcionario.ST_DisableAuto = false;
            this.cd_funcionario.ST_Float = false;
            this.cd_funcionario.ST_Gravar = true;
            this.cd_funcionario.ST_Int = true;
            this.cd_funcionario.ST_LimpaCampo = true;
            this.cd_funcionario.ST_NotNull = false;
            this.cd_funcionario.ST_PrimaryKey = false;
            this.cd_funcionario.TabIndex = 6;
            this.cd_funcionario.TextOld = null;
            this.cd_funcionario.Leave += new System.EventHandler(this.cd_funcionario_Leave);
            // 
            // bb_tanque
            // 
            this.bb_tanque.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tanque.Image = ((System.Drawing.Image)(resources.GetObject("bb_tanque.Image")));
            this.bb_tanque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tanque.Location = new System.Drawing.Point(654, 3);
            this.bb_tanque.Name = "bb_tanque";
            this.bb_tanque.Size = new System.Drawing.Size(28, 20);
            this.bb_tanque.TabIndex = 3;
            this.bb_tanque.UseVisualStyleBackColor = false;
            this.bb_tanque.Click += new System.EventHandler(this.bb_tanque_Click);
            // 
            // id_tanque
            // 
            this.id_tanque.BackColor = System.Drawing.Color.White;
            this.id_tanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_tanque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tanque.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMedicao, "Id_tanquestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_tanque.Location = new System.Drawing.Point(605, 4);
            this.id_tanque.Name = "id_tanque";
            this.id_tanque.NM_Alias = "";
            this.id_tanque.NM_Campo = "id_tanque";
            this.id_tanque.NM_CampoBusca = "id_tanque";
            this.id_tanque.NM_Param = "@P_CD_EMPRESA";
            this.id_tanque.QTD_Zero = 0;
            this.id_tanque.Size = new System.Drawing.Size(47, 20);
            this.id_tanque.ST_AutoInc = false;
            this.id_tanque.ST_DisableAuto = false;
            this.id_tanque.ST_Float = false;
            this.id_tanque.ST_Gravar = true;
            this.id_tanque.ST_Int = true;
            this.id_tanque.ST_LimpaCampo = true;
            this.id_tanque.ST_NotNull = true;
            this.id_tanque.ST_PrimaryKey = false;
            this.id_tanque.TabIndex = 2;
            this.id_tanque.TextOld = null;
            this.id_tanque.Leave += new System.EventHandler(this.id_tanque_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMedicao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(202, 4);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_CLIFOR";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(348, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 90;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(168, 4);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMedicao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(79, 5);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(88, 20);
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
            // TFMedicaoTanque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 212);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFMedicaoTanque";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aferição Tanque Combustivel";
            this.Load += new System.EventHandler(this.TFMedicaoTanque_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFMedicaoTanque_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pDetalhes.ResumeLayout(false);
            this.pDetalhes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compras_dia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendas_dia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultima_afericao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMedicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_combustivel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Button bb_tanque;
        private Componentes.EditDefault id_tanque;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_funcionario;
        private System.Windows.Forms.Button bb_funcionario;
        private Componentes.EditDefault cd_funcionario;
        private Componentes.EditDefault cd_combustivel;
        private Componentes.EditDefault ds_combustivel;
        private Componentes.EditFloat qtd_combustivel;
        private Componentes.EditData dt_medicao;
        private System.Windows.Forms.BindingSource bsMedicao;
        private Componentes.EditDefault sigla_unidade;
        private Componentes.ComboBoxDefault tp_medicao;
        private Componentes.PanelDados pDetalhes;
        private Componentes.EditFloat ultima_afericao;
        private Componentes.EditFloat compras_dia;
        private Componentes.EditFloat vendas_dia;
        private System.Windows.Forms.Button bb_calcmedicao;
    }
}