namespace Frota
{
    partial class TFOutrasReceitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFOutrasReceitas));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsReceita = new System.Windows.Forms.BindingSource(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HR_FinServico = new Componentes.EditMask(this.components);
            this.HR_IniServico = new Componentes.EditMask(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.adtoViagem = new Componentes.EditFloat(this.components);
            this.bb_cadclifor = new System.Windows.Forms.Button();
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.BB_Clifor = new System.Windows.Forms.Button();
            this.lblClifor = new System.Windows.Forms.Label();
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.dt_receita = new Componentes.EditMask(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.vl_receita = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.bb_veiculo = new System.Windows.Forms.Button();
            this.ds_veiculo = new Componentes.EditDefault(this.components);
            this.id_veiculo = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_motorista = new System.Windows.Forms.Button();
            this.ds_motorista = new Componentes.EditDefault(this.components);
            this.cd_motorista = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsReceita)).BeginInit();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adtoViagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_receita)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(621, 43);
            this.barraMenu.TabIndex = 9;
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
            // bsReceita
            // 
            this.bsReceita.DataSource = typeof(CamadaDados.Frota.TList_OutrasReceitas);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.HR_FinServico);
            this.pDados.Controls.Add(this.HR_IniServico);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.adtoViagem);
            this.pDados.Controls.Add(this.bb_cadclifor);
            this.pDados.Controls.Add(this.NM_Clifor);
            this.pDados.Controls.Add(this.BB_Clifor);
            this.pDados.Controls.Add(this.lblClifor);
            this.pDados.Controls.Add(this.CD_Clifor);
            this.pDados.Controls.Add(this.label14);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.dt_receita);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.vl_receita);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.bb_veiculo);
            this.pDados.Controls.Add(this.ds_veiculo);
            this.pDados.Controls.Add(this.id_veiculo);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.bb_motorista);
            this.pDados.Controls.Add(this.ds_motorista);
            this.pDados.Controls.Add(this.cd_motorista);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(621, 307);
            this.pDados.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(184, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 550;
            this.label5.Text = "Hora. Fin.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 549;
            this.label4.Text = "Hora. Ini.:";
            // 
            // HR_FinServico
            // 
            this.HR_FinServico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "HR_FinServico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HR_FinServico.Location = new System.Drawing.Point(252, 121);
            this.HR_FinServico.Mask = "00:00";
            this.HR_FinServico.Name = "HR_FinServico";
            this.HR_FinServico.NM_Alias = "";
            this.HR_FinServico.NM_Campo = "";
            this.HR_FinServico.NM_CampoBusca = "";
            this.HR_FinServico.NM_Param = "";
            this.HR_FinServico.Size = new System.Drawing.Size(100, 20);
            this.HR_FinServico.ST_Gravar = false;
            this.HR_FinServico.ST_LimpaCampo = true;
            this.HR_FinServico.ST_NotNull = false;
            this.HR_FinServico.ST_PrimaryKey = false;
            this.HR_FinServico.TabIndex = 9;
            // 
            // HR_IniServico
            // 
            this.HR_IniServico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "HR_IniServico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HR_IniServico.Location = new System.Drawing.Point(78, 121);
            this.HR_IniServico.Mask = "00:00";
            this.HR_IniServico.Name = "HR_IniServico";
            this.HR_IniServico.NM_Alias = "";
            this.HR_IniServico.NM_Campo = "";
            this.HR_IniServico.NM_CampoBusca = "";
            this.HR_IniServico.NM_Param = "";
            this.HR_IniServico.Size = new System.Drawing.Size(100, 20);
            this.HR_IniServico.ST_Gravar = false;
            this.HR_IniServico.ST_LimpaCampo = true;
            this.HR_IniServico.ST_NotNull = false;
            this.HR_IniServico.ST_PrimaryKey = false;
            this.HR_IniServico.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(189, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 546;
            this.label3.Text = "Vl.Adiantamento:";
            // 
            // adtoViagem
            // 
            this.adtoViagem.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsReceita, "Vl_adtoViagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.adtoViagem.DecimalPlaces = 2;
            this.adtoViagem.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.adtoViagem.Location = new System.Drawing.Point(293, 150);
            this.adtoViagem.Maximum = new decimal(new int[] {
            -469762049,
            -590869294,
            5421010,
            0});
            this.adtoViagem.Name = "adtoViagem";
            this.adtoViagem.NM_Alias = "";
            this.adtoViagem.NM_Campo = "";
            this.adtoViagem.NM_Param = "";
            this.adtoViagem.Operador = "";
            this.adtoViagem.Size = new System.Drawing.Size(105, 20);
            this.adtoViagem.ST_AutoInc = false;
            this.adtoViagem.ST_DisableAuto = false;
            this.adtoViagem.ST_Gravar = true;
            this.adtoViagem.ST_LimparCampo = true;
            this.adtoViagem.ST_NotNull = false;
            this.adtoViagem.ST_PrimaryKey = false;
            this.adtoViagem.TabIndex = 11;
            this.adtoViagem.ThousandsSeparator = true;
            // 
            // bb_cadclifor
            // 
            this.bb_cadclifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_cadclifor.Image")));
            this.bb_cadclifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_cadclifor.Location = new System.Drawing.Point(184, 40);
            this.bb_cadclifor.Name = "bb_cadclifor";
            this.bb_cadclifor.Size = new System.Drawing.Size(28, 20);
            this.bb_cadclifor.TabIndex = 544;
            this.bb_cadclifor.UseVisualStyleBackColor = true;
            this.bb_cadclifor.Click += new System.EventHandler(this.bb_cadclifor_Click);
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Nm_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Clifor.Enabled = false;
            this.NM_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Clifor.Location = new System.Drawing.Point(214, 40);
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "NM_Clifor";
            this.NM_Clifor.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.Size = new System.Drawing.Size(394, 20);
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = true;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = true;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TabIndex = 542;
            this.NM_Clifor.TextOld = null;
            // 
            // BB_Clifor
            // 
            this.BB_Clifor.Image = ((System.Drawing.Image)(resources.GetObject("BB_Clifor.Image")));
            this.BB_Clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Clifor.Location = new System.Drawing.Point(155, 41);
            this.BB_Clifor.Name = "BB_Clifor";
            this.BB_Clifor.Size = new System.Drawing.Size(28, 19);
            this.BB_Clifor.TabIndex = 3;
            this.BB_Clifor.UseVisualStyleBackColor = true;
            this.BB_Clifor.Click += new System.EventHandler(this.BB_Clifor_Click);
            // 
            // lblClifor
            // 
            this.lblClifor.AutoSize = true;
            this.lblClifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblClifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblClifor.Location = new System.Drawing.Point(27, 44);
            this.lblClifor.Name = "lblClifor";
            this.lblClifor.Size = new System.Drawing.Size(50, 13);
            this.lblClifor.TabIndex = 543;
            this.lblClifor.Text = "Cliente:";
            this.lblClifor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Clifor.Location = new System.Drawing.Point(78, 41);
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.Size = new System.Drawing.Size(75, 20);
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = true;
            this.CD_Clifor.ST_Int = true;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = false;
            this.CD_Clifor.ST_PrimaryKey = false;
            this.CD_Clifor.TabIndex = 2;
            this.CD_Clifor.TextOld = null;
            this.CD_Clifor.Leave += new System.EventHandler(this.CD_Clifor_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(39, 178);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 126;
            this.label14.Text = "Obs:";
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(78, 176);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(530, 107);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 13;
            this.ds_observacao.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(415, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 124;
            this.label6.Text = "Dt.Receita:";
            // 
            // dt_receita
            // 
            this.dt_receita.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Dt_receitastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_receita.Location = new System.Drawing.Point(496, 149);
            this.dt_receita.Mask = "00/00/0000";
            this.dt_receita.Name = "dt_receita";
            this.dt_receita.NM_Alias = "";
            this.dt_receita.NM_Campo = "";
            this.dt_receita.NM_CampoBusca = "";
            this.dt_receita.NM_Param = "";
            this.dt_receita.Size = new System.Drawing.Size(90, 20);
            this.dt_receita.ST_Gravar = true;
            this.dt_receita.ST_LimpaCampo = true;
            this.dt_receita.ST_NotNull = false;
            this.dt_receita.ST_PrimaryKey = false;
            this.dt_receita.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 122;
            this.label10.Text = "Vl.Receita:";
            // 
            // vl_receita
            // 
            this.vl_receita.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsReceita, "Vl_receita", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_receita.DecimalPlaces = 2;
            this.vl_receita.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_receita.Location = new System.Drawing.Point(78, 150);
            this.vl_receita.Maximum = new decimal(new int[] {
            -469762049,
            -590869294,
            5421010,
            0});
            this.vl_receita.Name = "vl_receita";
            this.vl_receita.NM_Alias = "";
            this.vl_receita.NM_Campo = "";
            this.vl_receita.NM_Param = "";
            this.vl_receita.Operador = "";
            this.vl_receita.Size = new System.Drawing.Size(105, 20);
            this.vl_receita.ST_AutoInc = false;
            this.vl_receita.ST_DisableAuto = false;
            this.vl_receita.ST_Gravar = true;
            this.vl_receita.ST_LimparCampo = true;
            this.vl_receita.ST_NotNull = false;
            this.vl_receita.ST_PrimaryKey = false;
            this.vl_receita.TabIndex = 10;
            this.vl_receita.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 120;
            this.label7.Text = "Veiculo:";
            // 
            // bb_veiculo
            // 
            this.bb_veiculo.Image = ((System.Drawing.Image)(resources.GetObject("bb_veiculo.Image")));
            this.bb_veiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_veiculo.Location = new System.Drawing.Point(140, 96);
            this.bb_veiculo.Name = "bb_veiculo";
            this.bb_veiculo.Size = new System.Drawing.Size(28, 19);
            this.bb_veiculo.TabIndex = 7;
            this.bb_veiculo.UseVisualStyleBackColor = true;
            this.bb_veiculo.Click += new System.EventHandler(this.bb_veiculo_Click);
            // 
            // ds_veiculo
            // 
            this.ds_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Ds_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_veiculo.Enabled = false;
            this.ds_veiculo.Location = new System.Drawing.Point(169, 95);
            this.ds_veiculo.Name = "ds_veiculo";
            this.ds_veiculo.NM_Alias = "";
            this.ds_veiculo.NM_Campo = "ds_veiculo";
            this.ds_veiculo.NM_CampoBusca = "ds_veiculo";
            this.ds_veiculo.NM_Param = "@P_NM_CLIFOR";
            this.ds_veiculo.QTD_Zero = 0;
            this.ds_veiculo.Size = new System.Drawing.Size(439, 20);
            this.ds_veiculo.ST_AutoInc = false;
            this.ds_veiculo.ST_DisableAuto = false;
            this.ds_veiculo.ST_Float = false;
            this.ds_veiculo.ST_Gravar = false;
            this.ds_veiculo.ST_Int = false;
            this.ds_veiculo.ST_LimpaCampo = true;
            this.ds_veiculo.ST_NotNull = false;
            this.ds_veiculo.ST_PrimaryKey = false;
            this.ds_veiculo.TabIndex = 119;
            this.ds_veiculo.TextOld = null;
            // 
            // id_veiculo
            // 
            this.id_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.id_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Id_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_veiculo.Location = new System.Drawing.Point(78, 95);
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.NM_Alias = "";
            this.id_veiculo.NM_Campo = "id_veiculo";
            this.id_veiculo.NM_CampoBusca = "id_veiculo";
            this.id_veiculo.NM_Param = "@P_CD_CLIFOR";
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
            this.id_veiculo.TabIndex = 6;
            this.id_veiculo.TextOld = null;
            this.id_veiculo.Leave += new System.EventHandler(this.id_veiculo_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Motorista:";
            // 
            // bb_motorista
            // 
            this.bb_motorista.Image = ((System.Drawing.Image)(resources.GetObject("bb_motorista.Image")));
            this.bb_motorista.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_motorista.Location = new System.Drawing.Point(173, 70);
            this.bb_motorista.Name = "bb_motorista";
            this.bb_motorista.Size = new System.Drawing.Size(28, 19);
            this.bb_motorista.TabIndex = 5;
            this.bb_motorista.UseVisualStyleBackColor = true;
            this.bb_motorista.Click += new System.EventHandler(this.bb_motorista_Click);
            // 
            // ds_motorista
            // 
            this.ds_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.ds_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_motorista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Nm_motorista", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_motorista.Enabled = false;
            this.ds_motorista.Location = new System.Drawing.Point(204, 69);
            this.ds_motorista.Name = "ds_motorista";
            this.ds_motorista.NM_Alias = "";
            this.ds_motorista.NM_Campo = "nm_clifor";
            this.ds_motorista.NM_CampoBusca = "nm_clifor";
            this.ds_motorista.NM_Param = "@P_NM_CLIFOR";
            this.ds_motorista.QTD_Zero = 0;
            this.ds_motorista.Size = new System.Drawing.Size(404, 20);
            this.ds_motorista.ST_AutoInc = false;
            this.ds_motorista.ST_DisableAuto = false;
            this.ds_motorista.ST_Float = false;
            this.ds_motorista.ST_Gravar = false;
            this.ds_motorista.ST_Int = false;
            this.ds_motorista.ST_LimpaCampo = true;
            this.ds_motorista.ST_NotNull = false;
            this.ds_motorista.ST_PrimaryKey = false;
            this.ds_motorista.TabIndex = 94;
            this.ds_motorista.TextOld = null;
            // 
            // cd_motorista
            // 
            this.cd_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.cd_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_motorista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Cd_motorista", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_motorista.Location = new System.Drawing.Point(78, 69);
            this.cd_motorista.Name = "cd_motorista";
            this.cd_motorista.NM_Alias = "";
            this.cd_motorista.NM_Campo = "cd_clifor";
            this.cd_motorista.NM_CampoBusca = "cd_clifor";
            this.cd_motorista.NM_Param = "@P_CD_CLIFOR";
            this.cd_motorista.QTD_Zero = 0;
            this.cd_motorista.Size = new System.Drawing.Size(95, 20);
            this.cd_motorista.ST_AutoInc = false;
            this.cd_motorista.ST_DisableAuto = false;
            this.cd_motorista.ST_Float = false;
            this.cd_motorista.ST_Gravar = true;
            this.cd_motorista.ST_Int = false;
            this.cd_motorista.ST_LimpaCampo = true;
            this.cd_motorista.ST_NotNull = true;
            this.cd_motorista.ST_PrimaryKey = false;
            this.cd_motorista.TabIndex = 4;
            this.cd_motorista.TextOld = null;
            this.cd_motorista.Leave += new System.EventHandler(this.cd_motorista_Leave);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(156, 14);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(452, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 22;
            this.NM_Empresa.TextOld = null;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(125, 14);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 1;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(78, 14);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(46, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // TFOutrasReceitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 350);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFOutrasReceitas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outras Receitas";
            this.Load += new System.EventHandler(this.TFOutrasReceitas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFOutrasReceitas_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsReceita)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adtoViagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_receita)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_motorista;
        private Componentes.EditDefault ds_motorista;
        private Componentes.EditDefault cd_motorista;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bb_veiculo;
        private Componentes.EditDefault ds_veiculo;
        private Componentes.EditDefault id_veiculo;
        private System.Windows.Forms.Label label10;
        private Componentes.EditFloat vl_receita;
        private System.Windows.Forms.Label label6;
        private Componentes.EditMask dt_receita;
        private System.Windows.Forms.Label label14;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.BindingSource bsReceita;
        private System.Windows.Forms.Button bb_cadclifor;
        private Componentes.EditDefault NM_Clifor;
        private System.Windows.Forms.Button BB_Clifor;
        private System.Windows.Forms.Label lblClifor;
        private Componentes.EditDefault CD_Clifor;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat adtoViagem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Componentes.EditMask HR_FinServico;
        private Componentes.EditMask HR_IniServico;
    }
}