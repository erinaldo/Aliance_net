namespace Faturamento
{
    partial class TFManutFrota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFManutFrota));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pManutencao = new Componentes.PanelDados(this.components);
            this.bbAddResponsavel = new System.Windows.Forms.Button();
            this.placa = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_veiculo = new System.Windows.Forms.Button();
            this.ds_veiculo = new Componentes.EditDefault(this.components);
            this.id_veiculo = new Componentes.EditDefault(this.components);
            this.km_realizada = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bb_Responsavel = new System.Windows.Forms.Button();
            this.nm_cliforResponsavel = new Componentes.EditDefault(this.components);
            this.cd_cliforResponsavel = new Componentes.EditDefault(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dt_realizada = new Componentes.EditMask(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_despesa = new System.Windows.Forms.Button();
            this.ds_despesa = new Componentes.EditDefault(this.components);
            this.id_despesa = new Componentes.EditDefault(this.components);
            this.bsManutencao = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.pManutencao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.km_realizada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManutencao)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(608, 43);
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
            // pManutencao
            // 
            this.pManutencao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pManutencao.Controls.Add(this.bbAddResponsavel);
            this.pManutencao.Controls.Add(this.placa);
            this.pManutencao.Controls.Add(this.label3);
            this.pManutencao.Controls.Add(this.bb_veiculo);
            this.pManutencao.Controls.Add(this.ds_veiculo);
            this.pManutencao.Controls.Add(this.id_veiculo);
            this.pManutencao.Controls.Add(this.km_realizada);
            this.pManutencao.Controls.Add(this.label1);
            this.pManutencao.Controls.Add(this.bb_Responsavel);
            this.pManutencao.Controls.Add(this.nm_cliforResponsavel);
            this.pManutencao.Controls.Add(this.cd_cliforResponsavel);
            this.pManutencao.Controls.Add(this.label14);
            this.pManutencao.Controls.Add(this.ds_observacao);
            this.pManutencao.Controls.Add(this.label12);
            this.pManutencao.Controls.Add(this.label8);
            this.pManutencao.Controls.Add(this.label5);
            this.pManutencao.Controls.Add(this.dt_realizada);
            this.pManutencao.Controls.Add(this.label2);
            this.pManutencao.Controls.Add(this.bb_despesa);
            this.pManutencao.Controls.Add(this.ds_despesa);
            this.pManutencao.Controls.Add(this.id_despesa);
            this.pManutencao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pManutencao.Location = new System.Drawing.Point(0, 43);
            this.pManutencao.Name = "pManutencao";
            this.pManutencao.NM_ProcDeletar = "";
            this.pManutencao.NM_ProcGravar = "";
            this.pManutencao.Size = new System.Drawing.Size(608, 205);
            this.pManutencao.TabIndex = 0;
            // 
            // bbAddResponsavel
            // 
            this.bbAddResponsavel.Image = ((System.Drawing.Image)(resources.GetObject("bbAddResponsavel.Image")));
            this.bbAddResponsavel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbAddResponsavel.Location = new System.Drawing.Point(211, 68);
            this.bbAddResponsavel.Name = "bbAddResponsavel";
            this.bbAddResponsavel.Size = new System.Drawing.Size(28, 19);
            this.bbAddResponsavel.TabIndex = 6;
            this.bbAddResponsavel.UseVisualStyleBackColor = true;
            this.bbAddResponsavel.Click += new System.EventHandler(this.bbAddResponsavel_Click);
            // 
            // placa
            // 
            this.placa.BackColor = System.Drawing.SystemColors.Window;
            this.placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.placa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Placa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.placa.Enabled = false;
            this.placa.Location = new System.Drawing.Point(494, 15);
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "placa";
            this.placa.NM_CampoBusca = "placa";
            this.placa.NM_Param = "@P_DS_DESPESA";
            this.placa.QTD_Zero = 0;
            this.placa.Size = new System.Drawing.Size(106, 20);
            this.placa.ST_AutoInc = false;
            this.placa.ST_DisableAuto = false;
            this.placa.ST_Float = false;
            this.placa.ST_Gravar = false;
            this.placa.ST_Int = false;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = false;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 93;
            this.placa.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Veiculo:";
            // 
            // bb_veiculo
            // 
            this.bb_veiculo.Image = ((System.Drawing.Image)(resources.GetObject("bb_veiculo.Image")));
            this.bb_veiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_veiculo.Location = new System.Drawing.Point(149, 16);
            this.bb_veiculo.Name = "bb_veiculo";
            this.bb_veiculo.Size = new System.Drawing.Size(28, 19);
            this.bb_veiculo.TabIndex = 1;
            this.bb_veiculo.UseVisualStyleBackColor = true;
            this.bb_veiculo.Click += new System.EventHandler(this.bb_veiculo_Click);
            // 
            // ds_veiculo
            // 
            this.ds_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Ds_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_veiculo.Enabled = false;
            this.ds_veiculo.Location = new System.Drawing.Point(183, 15);
            this.ds_veiculo.Name = "ds_veiculo";
            this.ds_veiculo.NM_Alias = "";
            this.ds_veiculo.NM_Campo = "ds_veiculo";
            this.ds_veiculo.NM_CampoBusca = "ds_veiculo";
            this.ds_veiculo.NM_Param = "@P_DS_DESPESA";
            this.ds_veiculo.QTD_Zero = 0;
            this.ds_veiculo.Size = new System.Drawing.Size(305, 20);
            this.ds_veiculo.ST_AutoInc = false;
            this.ds_veiculo.ST_DisableAuto = false;
            this.ds_veiculo.ST_Float = false;
            this.ds_veiculo.ST_Gravar = false;
            this.ds_veiculo.ST_Int = false;
            this.ds_veiculo.ST_LimpaCampo = true;
            this.ds_veiculo.ST_NotNull = false;
            this.ds_veiculo.ST_PrimaryKey = false;
            this.ds_veiculo.TabIndex = 91;
            this.ds_veiculo.TextOld = null;
            // 
            // id_veiculo
            // 
            this.id_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.id_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Id_veiculostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_veiculo.Location = new System.Drawing.Point(82, 15);
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.NM_Alias = "";
            this.id_veiculo.NM_Campo = "id_veiculo";
            this.id_veiculo.NM_CampoBusca = "id_veiculo";
            this.id_veiculo.NM_Param = "@P_ID_DESPESA";
            this.id_veiculo.QTD_Zero = 0;
            this.id_veiculo.Size = new System.Drawing.Size(61, 20);
            this.id_veiculo.ST_AutoInc = false;
            this.id_veiculo.ST_DisableAuto = false;
            this.id_veiculo.ST_Float = false;
            this.id_veiculo.ST_Gravar = true;
            this.id_veiculo.ST_Int = false;
            this.id_veiculo.ST_LimpaCampo = true;
            this.id_veiculo.ST_NotNull = true;
            this.id_veiculo.ST_PrimaryKey = false;
            this.id_veiculo.TabIndex = 0;
            this.id_veiculo.TextOld = null;
            this.id_veiculo.Leave += new System.EventHandler(this.id_veiculo_Leave);
            // 
            // km_realizada
            // 
            this.km_realizada.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsManutencao, "KM_realizada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.km_realizada.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.km_realizada.Location = new System.Drawing.Point(188, 94);
            this.km_realizada.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.km_realizada.Name = "km_realizada";
            this.km_realizada.NM_Alias = "";
            this.km_realizada.NM_Campo = "";
            this.km_realizada.NM_Param = "";
            this.km_realizada.Operador = "";
            this.km_realizada.Size = new System.Drawing.Size(94, 20);
            this.km_realizada.ST_AutoInc = false;
            this.km_realizada.ST_DisableAuto = false;
            this.km_realizada.ST_Gravar = true;
            this.km_realizada.ST_LimparCampo = true;
            this.km_realizada.ST_NotNull = false;
            this.km_realizada.ST_PrimaryKey = false;
            this.km_realizada.TabIndex = 8;
            this.km_realizada.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Responsavel:";
            // 
            // bb_Responsavel
            // 
            this.bb_Responsavel.Image = ((System.Drawing.Image)(resources.GetObject("bb_Responsavel.Image")));
            this.bb_Responsavel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_Responsavel.Location = new System.Drawing.Point(183, 68);
            this.bb_Responsavel.Name = "bb_Responsavel";
            this.bb_Responsavel.Size = new System.Drawing.Size(28, 19);
            this.bb_Responsavel.TabIndex = 5;
            this.bb_Responsavel.UseVisualStyleBackColor = true;
            this.bb_Responsavel.Click += new System.EventHandler(this.bb_Responsavel_Click);
            // 
            // nm_cliforResponsavel
            // 
            this.nm_cliforResponsavel.BackColor = System.Drawing.SystemColors.Window;
            this.nm_cliforResponsavel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_cliforResponsavel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_cliforResponsavel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Nm_cliforresponsavel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_cliforResponsavel.Enabled = false;
            this.nm_cliforResponsavel.Location = new System.Drawing.Point(245, 67);
            this.nm_cliforResponsavel.Name = "nm_cliforResponsavel";
            this.nm_cliforResponsavel.NM_Alias = "";
            this.nm_cliforResponsavel.NM_Campo = "nm_clifor";
            this.nm_cliforResponsavel.NM_CampoBusca = "nm_clifor";
            this.nm_cliforResponsavel.NM_Param = "@P_NM_CLIFOR";
            this.nm_cliforResponsavel.QTD_Zero = 0;
            this.nm_cliforResponsavel.Size = new System.Drawing.Size(355, 20);
            this.nm_cliforResponsavel.ST_AutoInc = false;
            this.nm_cliforResponsavel.ST_DisableAuto = false;
            this.nm_cliforResponsavel.ST_Float = false;
            this.nm_cliforResponsavel.ST_Gravar = false;
            this.nm_cliforResponsavel.ST_Int = false;
            this.nm_cliforResponsavel.ST_LimpaCampo = true;
            this.nm_cliforResponsavel.ST_NotNull = false;
            this.nm_cliforResponsavel.ST_PrimaryKey = false;
            this.nm_cliforResponsavel.TabIndex = 11;
            this.nm_cliforResponsavel.TextOld = null;
            // 
            // cd_cliforResponsavel
            // 
            this.cd_cliforResponsavel.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cliforResponsavel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_cliforResponsavel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cliforResponsavel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Cd_cliforResponsavel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_cliforResponsavel.Location = new System.Drawing.Point(82, 67);
            this.cd_cliforResponsavel.Name = "cd_cliforResponsavel";
            this.cd_cliforResponsavel.NM_Alias = "";
            this.cd_cliforResponsavel.NM_Campo = "cd_clifor";
            this.cd_cliforResponsavel.NM_CampoBusca = "cd_clifor";
            this.cd_cliforResponsavel.NM_Param = "@P_CD_CLIFOR";
            this.cd_cliforResponsavel.QTD_Zero = 0;
            this.cd_cliforResponsavel.Size = new System.Drawing.Size(100, 20);
            this.cd_cliforResponsavel.ST_AutoInc = false;
            this.cd_cliforResponsavel.ST_DisableAuto = false;
            this.cd_cliforResponsavel.ST_Float = false;
            this.cd_cliforResponsavel.ST_Gravar = true;
            this.cd_cliforResponsavel.ST_Int = false;
            this.cd_cliforResponsavel.ST_LimpaCampo = true;
            this.cd_cliforResponsavel.ST_NotNull = false;
            this.cd_cliforResponsavel.ST_PrimaryKey = false;
            this.cd_cliforResponsavel.TabIndex = 4;
            this.cd_cliforResponsavel.TextOld = null;
            this.cd_cliforResponsavel.Leave += new System.EventHandler(this.cd_cliforResponsavel_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 80;
            this.label14.Text = "Obs:";
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(81, 121);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(519, 76);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 9;
            this.ds_observacao.TextOld = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(159, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(157, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 71;
            this.label8.Text = "Km:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "Data:";
            // 
            // dt_realizada
            // 
            this.dt_realizada.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Dt_realizadastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_realizada.Location = new System.Drawing.Point(82, 94);
            this.dt_realizada.Mask = "00/00/0000";
            this.dt_realizada.Name = "dt_realizada";
            this.dt_realizada.NM_Alias = "";
            this.dt_realizada.NM_Campo = "";
            this.dt_realizada.NM_CampoBusca = "";
            this.dt_realizada.NM_Param = "";
            this.dt_realizada.Size = new System.Drawing.Size(69, 20);
            this.dt_realizada.ST_Gravar = true;
            this.dt_realizada.ST_LimpaCampo = true;
            this.dt_realizada.ST_NotNull = false;
            this.dt_realizada.ST_PrimaryKey = false;
            this.dt_realizada.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Despesas:";
            // 
            // bb_despesa
            // 
            this.bb_despesa.Image = ((System.Drawing.Image)(resources.GetObject("bb_despesa.Image")));
            this.bb_despesa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_despesa.Location = new System.Drawing.Point(149, 41);
            this.bb_despesa.Name = "bb_despesa";
            this.bb_despesa.Size = new System.Drawing.Size(28, 20);
            this.bb_despesa.TabIndex = 3;
            this.bb_despesa.UseVisualStyleBackColor = true;
            this.bb_despesa.Click += new System.EventHandler(this.bb_despesa_Click);
            // 
            // ds_despesa
            // 
            this.ds_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_despesa.Enabled = false;
            this.ds_despesa.Location = new System.Drawing.Point(183, 41);
            this.ds_despesa.Name = "ds_despesa";
            this.ds_despesa.NM_Alias = "";
            this.ds_despesa.NM_Campo = "ds_despesa";
            this.ds_despesa.NM_CampoBusca = "ds_despesa";
            this.ds_despesa.NM_Param = "@P_DS_DESPESA";
            this.ds_despesa.QTD_Zero = 0;
            this.ds_despesa.Size = new System.Drawing.Size(417, 20);
            this.ds_despesa.ST_AutoInc = false;
            this.ds_despesa.ST_DisableAuto = false;
            this.ds_despesa.ST_Float = false;
            this.ds_despesa.ST_Gravar = false;
            this.ds_despesa.ST_Int = false;
            this.ds_despesa.ST_LimpaCampo = true;
            this.ds_despesa.ST_NotNull = false;
            this.ds_despesa.ST_PrimaryKey = false;
            this.ds_despesa.TabIndex = 8;
            this.ds_despesa.TextOld = null;
            // 
            // id_despesa
            // 
            this.id_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.id_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Id_despesastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_despesa.Location = new System.Drawing.Point(82, 41);
            this.id_despesa.Name = "id_despesa";
            this.id_despesa.NM_Alias = "";
            this.id_despesa.NM_Campo = "id_despesa";
            this.id_despesa.NM_CampoBusca = "id_despesa";
            this.id_despesa.NM_Param = "@P_ID_DESPESA";
            this.id_despesa.QTD_Zero = 0;
            this.id_despesa.Size = new System.Drawing.Size(61, 20);
            this.id_despesa.ST_AutoInc = false;
            this.id_despesa.ST_DisableAuto = false;
            this.id_despesa.ST_Float = false;
            this.id_despesa.ST_Gravar = true;
            this.id_despesa.ST_Int = false;
            this.id_despesa.ST_LimpaCampo = true;
            this.id_despesa.ST_NotNull = true;
            this.id_despesa.ST_PrimaryKey = false;
            this.id_despesa.TabIndex = 2;
            this.id_despesa.TextOld = null;
            this.id_despesa.Leave += new System.EventHandler(this.id_despesa_Leave);
            // 
            // bsManutencao
            // 
            this.bsManutencao.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo);
            // 
            // TFManutFrota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 248);
            this.Controls.Add(this.pManutencao);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFManutFrota";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenção Frota";
            this.Load += new System.EventHandler(this.TFManutFrota_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFManutFrota_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pManutencao.ResumeLayout(false);
            this.pManutencao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.km_realizada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManutencao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pManutencao;
        private System.Windows.Forms.Button bbAddResponsavel;
        private Componentes.EditDefault placa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_veiculo;
        private Componentes.EditDefault ds_veiculo;
        private Componentes.EditDefault id_veiculo;
        private Componentes.EditFloat km_realizada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_Responsavel;
        private Componentes.EditDefault nm_cliforResponsavel;
        private Componentes.EditDefault cd_cliforResponsavel;
        private System.Windows.Forms.Label label14;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private Componentes.EditMask dt_realizada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_despesa;
        private Componentes.EditDefault ds_despesa;
        private Componentes.EditDefault id_despesa;
        private System.Windows.Forms.BindingSource bsManutencao;
    }
}