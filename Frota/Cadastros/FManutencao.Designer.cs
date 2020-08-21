namespace Frota.Cadastros
{
    partial class TFManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFManutencao));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pManutencao = new Componentes.PanelDados(this.components);
            this.km_prevista = new Componentes.EditFloat(this.components);
            this.bsManutencao = new System.Windows.Forms.BindingSource(this.components);
            this.km_realizada = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.bb_Oficina = new System.Windows.Forms.Button();
            this.bb_Responsavel = new System.Windows.Forms.Button();
            this.nm_cliforOficina = new Componentes.EditDefault(this.components);
            this.nm_cliforResponsavel = new Componentes.EditDefault(this.components);
            this.cd_cliforOficina = new Componentes.EditDefault(this.components);
            this.cd_cliforResponsavel = new Componentes.EditDefault(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.st_manutencao = new Componentes.ComboBoxDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.vl_realizado = new Componentes.EditFloat(this.components);
            this.vl_estimado = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dt_previsto = new Componentes.EditMask(this.components);
            this.dt_realizada = new Componentes.EditMask(this.components);
            this.dt_lancto = new Componentes.EditMask(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.bb_despesa = new System.Windows.Forms.Button();
            this.ds_despesa = new Componentes.EditDefault(this.components);
            this.id_despesa = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pManutencao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.km_prevista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManutencao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_realizada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_realizado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_estimado)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(564, 43);
            this.barraMenu.TabIndex = 11;
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
            this.pManutencao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pManutencao.Controls.Add(this.km_prevista);
            this.pManutencao.Controls.Add(this.km_realizada);
            this.pManutencao.Controls.Add(this.label1);
            this.pManutencao.Controls.Add(this.label15);
            this.pManutencao.Controls.Add(this.bb_Oficina);
            this.pManutencao.Controls.Add(this.bb_Responsavel);
            this.pManutencao.Controls.Add(this.nm_cliforOficina);
            this.pManutencao.Controls.Add(this.nm_cliforResponsavel);
            this.pManutencao.Controls.Add(this.cd_cliforOficina);
            this.pManutencao.Controls.Add(this.cd_cliforResponsavel);
            this.pManutencao.Controls.Add(this.label14);
            this.pManutencao.Controls.Add(this.ds_observacao);
            this.pManutencao.Controls.Add(this.label13);
            this.pManutencao.Controls.Add(this.label12);
            this.pManutencao.Controls.Add(this.st_manutencao);
            this.pManutencao.Controls.Add(this.label10);
            this.pManutencao.Controls.Add(this.label9);
            this.pManutencao.Controls.Add(this.vl_realizado);
            this.pManutencao.Controls.Add(this.vl_estimado);
            this.pManutencao.Controls.Add(this.label8);
            this.pManutencao.Controls.Add(this.label7);
            this.pManutencao.Controls.Add(this.label6);
            this.pManutencao.Controls.Add(this.label5);
            this.pManutencao.Controls.Add(this.label4);
            this.pManutencao.Controls.Add(this.dt_previsto);
            this.pManutencao.Controls.Add(this.dt_realizada);
            this.pManutencao.Controls.Add(this.dt_lancto);
            this.pManutencao.Controls.Add(this.label2);
            this.pManutencao.Controls.Add(this.label11);
            this.pManutencao.Controls.Add(this.cd_empresa);
            this.pManutencao.Controls.Add(this.bb_empresa);
            this.pManutencao.Controls.Add(this.bb_despesa);
            this.pManutencao.Controls.Add(this.ds_despesa);
            this.pManutencao.Controls.Add(this.id_despesa);
            this.pManutencao.Controls.Add(this.nm_empresa);
            this.pManutencao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pManutencao.Location = new System.Drawing.Point(0, 43);
            this.pManutencao.Name = "pManutencao";
            this.pManutencao.NM_ProcDeletar = "";
            this.pManutencao.NM_ProcGravar = "";
            this.pManutencao.Size = new System.Drawing.Size(564, 282);
            this.pManutencao.TabIndex = 0;
            // 
            // km_prevista
            // 
            this.km_prevista.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsManutencao, "Km_previsto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.km_prevista.Location = new System.Drawing.Point(242, 143);
            this.km_prevista.Name = "km_prevista";
            this.km_prevista.NM_Alias = "";
            this.km_prevista.NM_Campo = "";
            this.km_prevista.NM_Param = "";
            this.km_prevista.Operador = "";
            this.km_prevista.Size = new System.Drawing.Size(120, 20);
            this.km_prevista.ST_AutoInc = false;
            this.km_prevista.ST_DisableAuto = false;
            this.km_prevista.ST_Gravar = true;
            this.km_prevista.ST_LimparCampo = true;
            this.km_prevista.ST_NotNull = false;
            this.km_prevista.ST_PrimaryKey = false;
            this.km_prevista.TabIndex = 13;
            this.km_prevista.ThousandsSeparator = true;
            // 
            // bsManutencao
            // 
            this.bsManutencao.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo);
            // 
            // km_realizada
            // 
            this.km_realizada.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsManutencao, "KM_realizada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.km_realizada.Location = new System.Drawing.Point(242, 171);
            this.km_realizada.Name = "km_realizada";
            this.km_realizada.NM_Alias = "";
            this.km_realizada.NM_Campo = "";
            this.km_realizada.NM_Param = "";
            this.km_realizada.Operador = "";
            this.km_realizada.Size = new System.Drawing.Size(120, 20);
            this.km_realizada.ST_AutoInc = false;
            this.km_realizada.ST_DisableAuto = false;
            this.km_realizada.ST_Gravar = true;
            this.km_realizada.ST_LimparCampo = true;
            this.km_realizada.ST_NotNull = false;
            this.km_realizada.ST_PrimaryKey = false;
            this.km_realizada.TabIndex = 16;
            this.km_realizada.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Responsavel:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 87;
            this.label15.Text = "Oficina:";
            // 
            // bb_Oficina
            // 
            this.bb_Oficina.Image = ((System.Drawing.Image)(resources.GetObject("bb_Oficina.Image")));
            this.bb_Oficina.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_Oficina.Location = new System.Drawing.Point(149, 89);
            this.bb_Oficina.Name = "bb_Oficina";
            this.bb_Oficina.Size = new System.Drawing.Size(28, 19);
            this.bb_Oficina.TabIndex = 9;
            this.bb_Oficina.UseVisualStyleBackColor = true;
            this.bb_Oficina.Click += new System.EventHandler(this.bb_Oficina_Click);
            // 
            // bb_Responsavel
            // 
            this.bb_Responsavel.Image = ((System.Drawing.Image)(resources.GetObject("bb_Responsavel.Image")));
            this.bb_Responsavel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_Responsavel.Location = new System.Drawing.Point(149, 64);
            this.bb_Responsavel.Name = "bb_Responsavel";
            this.bb_Responsavel.Size = new System.Drawing.Size(28, 19);
            this.bb_Responsavel.TabIndex = 7;
            this.bb_Responsavel.UseVisualStyleBackColor = true;
            this.bb_Responsavel.Click += new System.EventHandler(this.bb_Responsavel_Click);
            // 
            // nm_cliforOficina
            // 
            this.nm_cliforOficina.BackColor = System.Drawing.SystemColors.Window;
            this.nm_cliforOficina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_cliforOficina.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_cliforOficina.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Nm_cliforOficina", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_cliforOficina.Enabled = false;
            this.nm_cliforOficina.Location = new System.Drawing.Point(183, 88);
            this.nm_cliforOficina.Name = "nm_cliforOficina";
            this.nm_cliforOficina.NM_Alias = "";
            this.nm_cliforOficina.NM_Campo = "nm_clifor";
            this.nm_cliforOficina.NM_CampoBusca = "nm_clifor";
            this.nm_cliforOficina.NM_Param = "@P_NM_CLIFOR";
            this.nm_cliforOficina.QTD_Zero = 0;
            this.nm_cliforOficina.Size = new System.Drawing.Size(359, 20);
            this.nm_cliforOficina.ST_AutoInc = false;
            this.nm_cliforOficina.ST_DisableAuto = false;
            this.nm_cliforOficina.ST_Float = false;
            this.nm_cliforOficina.ST_Gravar = false;
            this.nm_cliforOficina.ST_Int = false;
            this.nm_cliforOficina.ST_LimpaCampo = true;
            this.nm_cliforOficina.ST_NotNull = false;
            this.nm_cliforOficina.ST_PrimaryKey = false;
            this.nm_cliforOficina.TabIndex = 14;
            // 
            // nm_cliforResponsavel
            // 
            this.nm_cliforResponsavel.BackColor = System.Drawing.SystemColors.Window;
            this.nm_cliforResponsavel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_cliforResponsavel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_cliforResponsavel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Nm_cliforresponsavel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_cliforResponsavel.Enabled = false;
            this.nm_cliforResponsavel.Location = new System.Drawing.Point(183, 63);
            this.nm_cliforResponsavel.Name = "nm_cliforResponsavel";
            this.nm_cliforResponsavel.NM_Alias = "";
            this.nm_cliforResponsavel.NM_Campo = "nm_clifor";
            this.nm_cliforResponsavel.NM_CampoBusca = "nm_clifor";
            this.nm_cliforResponsavel.NM_Param = "@P_NM_CLIFOR";
            this.nm_cliforResponsavel.QTD_Zero = 0;
            this.nm_cliforResponsavel.Size = new System.Drawing.Size(359, 20);
            this.nm_cliforResponsavel.ST_AutoInc = false;
            this.nm_cliforResponsavel.ST_DisableAuto = false;
            this.nm_cliforResponsavel.ST_Float = false;
            this.nm_cliforResponsavel.ST_Gravar = false;
            this.nm_cliforResponsavel.ST_Int = false;
            this.nm_cliforResponsavel.ST_LimpaCampo = true;
            this.nm_cliforResponsavel.ST_NotNull = false;
            this.nm_cliforResponsavel.ST_PrimaryKey = false;
            this.nm_cliforResponsavel.TabIndex = 11;
            // 
            // cd_cliforOficina
            // 
            this.cd_cliforOficina.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cliforOficina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_cliforOficina.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cliforOficina.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Cd_cliforOficina", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_cliforOficina.Location = new System.Drawing.Point(82, 88);
            this.cd_cliforOficina.Name = "cd_cliforOficina";
            this.cd_cliforOficina.NM_Alias = "";
            this.cd_cliforOficina.NM_Campo = "cd_clifor";
            this.cd_cliforOficina.NM_CampoBusca = "cd_clifor";
            this.cd_cliforOficina.NM_Param = "@P_CD_CLIFOR";
            this.cd_cliforOficina.QTD_Zero = 0;
            this.cd_cliforOficina.Size = new System.Drawing.Size(61, 20);
            this.cd_cliforOficina.ST_AutoInc = false;
            this.cd_cliforOficina.ST_DisableAuto = false;
            this.cd_cliforOficina.ST_Float = false;
            this.cd_cliforOficina.ST_Gravar = true;
            this.cd_cliforOficina.ST_Int = false;
            this.cd_cliforOficina.ST_LimpaCampo = true;
            this.cd_cliforOficina.ST_NotNull = false;
            this.cd_cliforOficina.ST_PrimaryKey = false;
            this.cd_cliforOficina.TabIndex = 8;
            this.cd_cliforOficina.Leave += new System.EventHandler(this.cd_cliforOficina_Leave);
            // 
            // cd_cliforResponsavel
            // 
            this.cd_cliforResponsavel.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cliforResponsavel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_cliforResponsavel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cliforResponsavel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Cd_cliforResponsavel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_cliforResponsavel.Location = new System.Drawing.Point(82, 63);
            this.cd_cliforResponsavel.Name = "cd_cliforResponsavel";
            this.cd_cliforResponsavel.NM_Alias = "";
            this.cd_cliforResponsavel.NM_Campo = "cd_clifor";
            this.cd_cliforResponsavel.NM_CampoBusca = "cd_clifor";
            this.cd_cliforResponsavel.NM_Param = "@P_CD_CLIFOR";
            this.cd_cliforResponsavel.QTD_Zero = 0;
            this.cd_cliforResponsavel.Size = new System.Drawing.Size(61, 20);
            this.cd_cliforResponsavel.ST_AutoInc = false;
            this.cd_cliforResponsavel.ST_DisableAuto = false;
            this.cd_cliforResponsavel.ST_Float = false;
            this.cd_cliforResponsavel.ST_Gravar = true;
            this.cd_cliforResponsavel.ST_Int = false;
            this.cd_cliforResponsavel.ST_LimpaCampo = true;
            this.cd_cliforResponsavel.ST_NotNull = false;
            this.cd_cliforResponsavel.ST_PrimaryKey = false;
            this.cd_cliforResponsavel.TabIndex = 6;
            this.cd_cliforResponsavel.Leave += new System.EventHandler(this.cd_cliforResponsavel_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(42, 197);
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
            this.ds_observacao.Location = new System.Drawing.Point(81, 195);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(459, 76);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(192, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 78;
            this.label13.Text = "Status:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(159, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 77;
            // 
            // st_manutencao
            // 
            this.st_manutencao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsManutencao, "St_manutencao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_manutencao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.st_manutencao.FormattingEnabled = true;
            this.st_manutencao.Location = new System.Drawing.Point(241, 113);
            this.st_manutencao.Name = "st_manutencao";
            this.st_manutencao.NM_Alias = "";
            this.st_manutencao.NM_Campo = "";
            this.st_manutencao.NM_Param = "";
            this.st_manutencao.Size = new System.Drawing.Size(121, 21);
            this.st_manutencao.ST_Gravar = true;
            this.st_manutencao.ST_LimparCampo = true;
            this.st_manutencao.ST_NotNull = false;
            this.st_manutencao.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(380, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 75;
            this.label10.Text = "Vl.Estimado:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(379, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 74;
            this.label9.Text = "Vl.Realizado:";
            // 
            // vl_realizado
            // 
            this.vl_realizado.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsManutencao, "Vl_realizada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_realizado.DecimalPlaces = 2;
            this.vl_realizado.Location = new System.Drawing.Point(451, 168);
            this.vl_realizado.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.vl_realizado.Name = "vl_realizado";
            this.vl_realizado.NM_Alias = "";
            this.vl_realizado.NM_Campo = "";
            this.vl_realizado.NM_Param = "";
            this.vl_realizado.Operador = "";
            this.vl_realizado.Size = new System.Drawing.Size(90, 20);
            this.vl_realizado.ST_AutoInc = false;
            this.vl_realizado.ST_DisableAuto = false;
            this.vl_realizado.ST_Gravar = true;
            this.vl_realizado.ST_LimparCampo = true;
            this.vl_realizado.ST_NotNull = false;
            this.vl_realizado.ST_PrimaryKey = false;
            this.vl_realizado.TabIndex = 17;
            this.vl_realizado.ThousandsSeparator = true;
            // 
            // vl_estimado
            // 
            this.vl_estimado.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsManutencao, "Vl_estimado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_estimado.DecimalPlaces = 2;
            this.vl_estimado.Location = new System.Drawing.Point(451, 142);
            this.vl_estimado.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.vl_estimado.Name = "vl_estimado";
            this.vl_estimado.NM_Alias = "";
            this.vl_estimado.NM_Campo = "";
            this.vl_estimado.NM_Param = "";
            this.vl_estimado.Operador = "";
            this.vl_estimado.Size = new System.Drawing.Size(90, 20);
            this.vl_estimado.ST_AutoInc = false;
            this.vl_estimado.ST_DisableAuto = false;
            this.vl_estimado.ST_Gravar = true;
            this.vl_estimado.ST_LimparCampo = true;
            this.vl_estimado.ST_NotNull = false;
            this.vl_estimado.ST_PrimaryKey = false;
            this.vl_estimado.TabIndex = 14;
            this.vl_estimado.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(157, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 71;
            this.label8.Text = "Km.Realizada:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(166, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 70;
            this.label7.Text = "Km.Prevista:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "Dt.Prevista:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "Dt.Realizada:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Dt.Lancto:";
            // 
            // dt_previsto
            // 
            this.dt_previsto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Dt_previstastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_previsto.Location = new System.Drawing.Point(81, 142);
            this.dt_previsto.Mask = "00/00/0000";
            this.dt_previsto.Name = "dt_previsto";
            this.dt_previsto.NM_Alias = "";
            this.dt_previsto.NM_Campo = "";
            this.dt_previsto.NM_CampoBusca = "";
            this.dt_previsto.NM_Param = "";
            this.dt_previsto.Size = new System.Drawing.Size(70, 20);
            this.dt_previsto.ST_Gravar = true;
            this.dt_previsto.ST_LimpaCampo = true;
            this.dt_previsto.ST_NotNull = false;
            this.dt_previsto.ST_PrimaryKey = false;
            this.dt_previsto.TabIndex = 12;
            // 
            // dt_realizada
            // 
            this.dt_realizada.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Dt_realizadastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_realizada.Location = new System.Drawing.Point(81, 168);
            this.dt_realizada.Mask = "00/00/0000";
            this.dt_realizada.Name = "dt_realizada";
            this.dt_realizada.NM_Alias = "";
            this.dt_realizada.NM_Campo = "";
            this.dt_realizada.NM_CampoBusca = "";
            this.dt_realizada.NM_Param = "";
            this.dt_realizada.Size = new System.Drawing.Size(70, 20);
            this.dt_realizada.ST_Gravar = true;
            this.dt_realizada.ST_LimpaCampo = true;
            this.dt_realizada.ST_NotNull = false;
            this.dt_realizada.ST_PrimaryKey = false;
            this.dt_realizada.TabIndex = 15;
            // 
            // dt_lancto
            // 
            this.dt_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Dt_lanctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_lancto.Location = new System.Drawing.Point(81, 113);
            this.dt_lancto.Mask = "00/00/0000";
            this.dt_lancto.Name = "dt_lancto";
            this.dt_lancto.NM_Alias = "";
            this.dt_lancto.NM_Campo = "";
            this.dt_lancto.NM_CampoBusca = "";
            this.dt_lancto.NM_Param = "";
            this.dt_lancto.Size = new System.Drawing.Size(70, 20);
            this.dt_lancto.ST_Gravar = true;
            this.dt_lancto.ST_LimpaCampo = true;
            this.dt_lancto.ST_NotNull = false;
            this.dt_lancto.ST_PrimaryKey = false;
            this.dt_lancto.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Despesas:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 58;
            this.label11.Text = "Empresa:";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(82, 15);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(61, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(149, 14);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // bb_despesa
            // 
            this.bb_despesa.Image = ((System.Drawing.Image)(resources.GetObject("bb_despesa.Image")));
            this.bb_despesa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_despesa.Location = new System.Drawing.Point(149, 39);
            this.bb_despesa.Name = "bb_despesa";
            this.bb_despesa.Size = new System.Drawing.Size(28, 19);
            this.bb_despesa.TabIndex = 5;
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
            this.ds_despesa.Location = new System.Drawing.Point(183, 38);
            this.ds_despesa.Name = "ds_despesa";
            this.ds_despesa.NM_Alias = "";
            this.ds_despesa.NM_Campo = "ds_despesa";
            this.ds_despesa.NM_CampoBusca = "ds_despesa";
            this.ds_despesa.NM_Param = "@P_DS_DESPESA";
            this.ds_despesa.QTD_Zero = 0;
            this.ds_despesa.Size = new System.Drawing.Size(359, 20);
            this.ds_despesa.ST_AutoInc = false;
            this.ds_despesa.ST_DisableAuto = false;
            this.ds_despesa.ST_Float = false;
            this.ds_despesa.ST_Gravar = false;
            this.ds_despesa.ST_Int = false;
            this.ds_despesa.ST_LimpaCampo = true;
            this.ds_despesa.ST_NotNull = false;
            this.ds_despesa.ST_PrimaryKey = false;
            this.ds_despesa.TabIndex = 8;
            // 
            // id_despesa
            // 
            this.id_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.id_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Id_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_despesa.Location = new System.Drawing.Point(82, 38);
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
            this.id_despesa.TabIndex = 4;
            this.id_despesa.Leave += new System.EventHandler(this.id_despesa_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsManutencao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(183, 13);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(359, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 2;
            // 
            // TFManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 325);
            this.Controls.Add(this.pManutencao);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFManutencao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenção do Veículo";
            this.Load += new System.EventHandler(this.TFManutencao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFManutencao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pManutencao.ResumeLayout(false);
            this.pManutencao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.km_prevista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManutencao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_realizada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_realizado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_estimado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.PanelDados pManutencao;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.EditDefault ds_despesa;
        private Componentes.EditDefault id_despesa;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private System.Windows.Forms.Button bb_despesa;
        private Componentes.EditMask dt_previsto;
        private Componentes.EditMask dt_realizada;
        private Componentes.EditMask dt_lancto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat vl_realizado;
        private Componentes.EditFloat vl_estimado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private Componentes.ComboBoxDefault st_manutencao;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.BindingSource bsManutencao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bb_Oficina;
        private System.Windows.Forms.Button bb_Responsavel;
        private Componentes.EditDefault nm_cliforOficina;
        private Componentes.EditDefault nm_cliforResponsavel;
        private Componentes.EditDefault cd_cliforOficina;
        private Componentes.EditDefault cd_cliforResponsavel;
        private Componentes.EditFloat km_realizada;
        private Componentes.EditFloat km_prevista;
    }
}