namespace Frota
{
    partial class TFInfracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFInfracoes));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pInfracoes = new Componentes.PanelDados(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.bb_despesa = new System.Windows.Forms.Button();
            this.ds_despesa = new Componentes.EditDefault(this.components);
            this.bsInfracoes = new System.Windows.Forms.BindingSource(this.components);
            this.id_despesa = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.bb_veiculo = new System.Windows.Forms.Button();
            this.ds_veiculo = new Componentes.EditDefault(this.components);
            this.id_veiculo = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.ds_infracao = new Componentes.EditDefault(this.components);
            this.cd_infracao = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tp_gravidade = new Componentes.ComboBoxDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.vl_infracao = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dt_infracao = new Componentes.EditMask(this.components);
            this.dt_vencimento = new Componentes.EditMask(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.bb_motorista = new System.Windows.Forms.Button();
            this.bb_viagem = new System.Windows.Forms.Button();
            this.ds_motorista = new Componentes.EditDefault(this.components);
            this.ds_viagem = new Componentes.EditDefault(this.components);
            this.cd_motorista = new Componentes.EditDefault(this.components);
            this.id_viagem = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bbAddDespesa = new System.Windows.Forms.Button();
            this.barraMenu.SuspendLayout();
            this.pInfracoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsInfracoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_infracao)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(558, 43);
            this.barraMenu.TabIndex = 12;
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
            // pInfracoes
            // 
            this.pInfracoes.BackColor = System.Drawing.SystemColors.Control;
            this.pInfracoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfracoes.Controls.Add(this.bbAddDespesa);
            this.pInfracoes.Controls.Add(this.label8);
            this.pInfracoes.Controls.Add(this.bb_despesa);
            this.pInfracoes.Controls.Add(this.ds_despesa);
            this.pInfracoes.Controls.Add(this.id_despesa);
            this.pInfracoes.Controls.Add(this.label7);
            this.pInfracoes.Controls.Add(this.bb_veiculo);
            this.pInfracoes.Controls.Add(this.ds_veiculo);
            this.pInfracoes.Controls.Add(this.id_veiculo);
            this.pInfracoes.Controls.Add(this.label4);
            this.pInfracoes.Controls.Add(this.ds_infracao);
            this.pInfracoes.Controls.Add(this.cd_infracao);
            this.pInfracoes.Controls.Add(this.label1);
            this.pInfracoes.Controls.Add(this.label14);
            this.pInfracoes.Controls.Add(this.ds_observacao);
            this.pInfracoes.Controls.Add(this.label13);
            this.pInfracoes.Controls.Add(this.label12);
            this.pInfracoes.Controls.Add(this.tp_gravidade);
            this.pInfracoes.Controls.Add(this.label10);
            this.pInfracoes.Controls.Add(this.vl_infracao);
            this.pInfracoes.Controls.Add(this.label6);
            this.pInfracoes.Controls.Add(this.label5);
            this.pInfracoes.Controls.Add(this.dt_infracao);
            this.pInfracoes.Controls.Add(this.dt_vencimento);
            this.pInfracoes.Controls.Add(this.label3);
            this.pInfracoes.Controls.Add(this.label2);
            this.pInfracoes.Controls.Add(this.label11);
            this.pInfracoes.Controls.Add(this.cd_empresa);
            this.pInfracoes.Controls.Add(this.bb_empresa);
            this.pInfracoes.Controls.Add(this.bb_motorista);
            this.pInfracoes.Controls.Add(this.bb_viagem);
            this.pInfracoes.Controls.Add(this.ds_motorista);
            this.pInfracoes.Controls.Add(this.ds_viagem);
            this.pInfracoes.Controls.Add(this.cd_motorista);
            this.pInfracoes.Controls.Add(this.id_viagem);
            this.pInfracoes.Controls.Add(this.nm_empresa);
            this.pInfracoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pInfracoes.Location = new System.Drawing.Point(0, 43);
            this.pInfracoes.Name = "pInfracoes";
            this.pInfracoes.NM_ProcDeletar = "";
            this.pInfracoes.NM_ProcGravar = "";
            this.pInfracoes.Size = new System.Drawing.Size(558, 267);
            this.pInfracoes.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 120;
            this.label8.Text = "Despesa:";
            // 
            // bb_despesa
            // 
            this.bb_despesa.Image = ((System.Drawing.Image)(resources.GetObject("bb_despesa.Image")));
            this.bb_despesa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_despesa.Location = new System.Drawing.Point(159, 107);
            this.bb_despesa.Name = "bb_despesa";
            this.bb_despesa.Size = new System.Drawing.Size(28, 19);
            this.bb_despesa.TabIndex = 9;
            this.bb_despesa.UseVisualStyleBackColor = true;
            this.bb_despesa.Click += new System.EventHandler(this.bb_despesa_Click);
            // 
            // ds_despesa
            // 
            this.ds_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_despesa.Enabled = false;
            this.ds_despesa.Location = new System.Drawing.Point(222, 106);
            this.ds_despesa.Name = "ds_despesa";
            this.ds_despesa.NM_Alias = "";
            this.ds_despesa.NM_Campo = "ds_despesa";
            this.ds_despesa.NM_CampoBusca = "ds_despesa";
            this.ds_despesa.NM_Param = "@P_NM_CLIFOR";
            this.ds_despesa.QTD_Zero = 0;
            this.ds_despesa.Size = new System.Drawing.Size(330, 20);
            this.ds_despesa.ST_AutoInc = false;
            this.ds_despesa.ST_DisableAuto = false;
            this.ds_despesa.ST_Float = false;
            this.ds_despesa.ST_Gravar = false;
            this.ds_despesa.ST_Int = false;
            this.ds_despesa.ST_LimpaCampo = true;
            this.ds_despesa.ST_NotNull = false;
            this.ds_despesa.ST_PrimaryKey = false;
            this.ds_despesa.TabIndex = 119;
            this.ds_despesa.TextOld = null;
            // 
            // bsInfracoes
            // 
            this.bsInfracoes.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_Infracoes);
            // 
            // id_despesa
            // 
            this.id_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.id_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Id_despesastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_despesa.Location = new System.Drawing.Point(92, 106);
            this.id_despesa.Name = "id_despesa";
            this.id_despesa.NM_Alias = "";
            this.id_despesa.NM_Campo = "id_despesa";
            this.id_despesa.NM_CampoBusca = "id_despesa";
            this.id_despesa.NM_Param = "@P_CD_CLIFOR";
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
            this.id_despesa.TabIndex = 8;
            this.id_despesa.TextOld = null;
            this.id_despesa.Leave += new System.EventHandler(this.id_despesa_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 116;
            this.label7.Text = "Veiculo:";
            // 
            // bb_veiculo
            // 
            this.bb_veiculo.Image = ((System.Drawing.Image)(resources.GetObject("bb_veiculo.Image")));
            this.bb_veiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_veiculo.Location = new System.Drawing.Point(159, 81);
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
            this.ds_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Ds_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_veiculo.Enabled = false;
            this.ds_veiculo.Location = new System.Drawing.Point(193, 80);
            this.ds_veiculo.Name = "ds_veiculo";
            this.ds_veiculo.NM_Alias = "";
            this.ds_veiculo.NM_Campo = "ds_veiculo";
            this.ds_veiculo.NM_CampoBusca = "ds_veiculo";
            this.ds_veiculo.NM_Param = "@P_NM_CLIFOR";
            this.ds_veiculo.QTD_Zero = 0;
            this.ds_veiculo.Size = new System.Drawing.Size(359, 20);
            this.ds_veiculo.ST_AutoInc = false;
            this.ds_veiculo.ST_DisableAuto = false;
            this.ds_veiculo.ST_Float = false;
            this.ds_veiculo.ST_Gravar = false;
            this.ds_veiculo.ST_Int = false;
            this.ds_veiculo.ST_LimpaCampo = true;
            this.ds_veiculo.ST_NotNull = false;
            this.ds_veiculo.ST_PrimaryKey = false;
            this.ds_veiculo.TabIndex = 115;
            this.ds_veiculo.TextOld = null;
            // 
            // id_veiculo
            // 
            this.id_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.id_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Id_veiculostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_veiculo.Location = new System.Drawing.Point(92, 80);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Infracao:";
            // 
            // ds_infracao
            // 
            this.ds_infracao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_infracao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_infracao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_infracao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Ds_infracao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_infracao.Location = new System.Drawing.Point(214, 131);
            this.ds_infracao.Name = "ds_infracao";
            this.ds_infracao.NM_Alias = "";
            this.ds_infracao.NM_Campo = "";
            this.ds_infracao.NM_CampoBusca = "";
            this.ds_infracao.NM_Param = "";
            this.ds_infracao.QTD_Zero = 0;
            this.ds_infracao.Size = new System.Drawing.Size(196, 20);
            this.ds_infracao.ST_AutoInc = false;
            this.ds_infracao.ST_DisableAuto = false;
            this.ds_infracao.ST_Float = false;
            this.ds_infracao.ST_Gravar = true;
            this.ds_infracao.ST_Int = false;
            this.ds_infracao.ST_LimpaCampo = true;
            this.ds_infracao.ST_NotNull = false;
            this.ds_infracao.ST_PrimaryKey = false;
            this.ds_infracao.TabIndex = 11;
            this.ds_infracao.TextOld = null;
            // 
            // cd_infracao
            // 
            this.cd_infracao.BackColor = System.Drawing.SystemColors.Window;
            this.cd_infracao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_infracao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_infracao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Cd_infracao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_infracao.Location = new System.Drawing.Point(92, 132);
            this.cd_infracao.Name = "cd_infracao";
            this.cd_infracao.NM_Alias = "";
            this.cd_infracao.NM_Campo = "";
            this.cd_infracao.NM_CampoBusca = "";
            this.cd_infracao.NM_Param = "";
            this.cd_infracao.QTD_Zero = 0;
            this.cd_infracao.Size = new System.Drawing.Size(61, 20);
            this.cd_infracao.ST_AutoInc = false;
            this.cd_infracao.ST_DisableAuto = false;
            this.cd_infracao.ST_Float = false;
            this.cd_infracao.ST_Gravar = true;
            this.cd_infracao.ST_Int = false;
            this.cd_infracao.ST_LimpaCampo = true;
            this.cd_infracao.ST_NotNull = false;
            this.cd_infracao.ST_PrimaryKey = false;
            this.cd_infracao.TabIndex = 10;
            this.cd_infracao.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 112;
            this.label1.Text = "Cd.Infracao:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(57, 187);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 111;
            this.label14.Text = "Obs:";
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(92, 184);
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
            this.ds_observacao.TabIndex = 16;
            this.ds_observacao.TextOld = null;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(175, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 109;
            this.label13.Text = "Tipo Gravidade:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(169, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 108;
            // 
            // tp_gravidade
            // 
            this.tp_gravidade.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsInfracoes, "Tp_gravidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_gravidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_gravidade.FormattingEnabled = true;
            this.tp_gravidade.Location = new System.Drawing.Point(264, 157);
            this.tp_gravidade.Name = "tp_gravidade";
            this.tp_gravidade.NM_Alias = "";
            this.tp_gravidade.NM_Campo = "";
            this.tp_gravidade.NM_Param = "";
            this.tp_gravidade.Size = new System.Drawing.Size(121, 21);
            this.tp_gravidade.ST_Gravar = true;
            this.tp_gravidade.ST_LimparCampo = true;
            this.tp_gravidade.ST_NotNull = false;
            this.tp_gravidade.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 106;
            this.label10.Text = "Vl.Infracao:";
            // 
            // vl_infracao
            // 
            this.vl_infracao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsInfracoes, "Vl_infracao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_infracao.DecimalPlaces = 2;
            this.vl_infracao.Location = new System.Drawing.Point(92, 158);
            this.vl_infracao.Maximum = new decimal(new int[] {
            -469762049,
            -590869294,
            5421010,
            0});
            this.vl_infracao.Name = "vl_infracao";
            this.vl_infracao.NM_Alias = "";
            this.vl_infracao.NM_Campo = "";
            this.vl_infracao.NM_Param = "";
            this.vl_infracao.Operador = "";
            this.vl_infracao.Size = new System.Drawing.Size(77, 20);
            this.vl_infracao.ST_AutoInc = false;
            this.vl_infracao.ST_DisableAuto = false;
            this.vl_infracao.ST_Gravar = true;
            this.vl_infracao.ST_LimparCampo = true;
            this.vl_infracao.ST_NotNull = false;
            this.vl_infracao.ST_PrimaryKey = false;
            this.vl_infracao.TabIndex = 13;
            this.vl_infracao.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "Dt.Infracao:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Dt.Vencimento:";
            // 
            // dt_infracao
            // 
            this.dt_infracao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Dt_infracaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_infracao.Location = new System.Drawing.Point(482, 131);
            this.dt_infracao.Mask = "00/00/0000";
            this.dt_infracao.Name = "dt_infracao";
            this.dt_infracao.NM_Alias = "";
            this.dt_infracao.NM_Campo = "";
            this.dt_infracao.NM_CampoBusca = "";
            this.dt_infracao.NM_Param = "";
            this.dt_infracao.Size = new System.Drawing.Size(70, 20);
            this.dt_infracao.ST_Gravar = true;
            this.dt_infracao.ST_LimpaCampo = true;
            this.dt_infracao.ST_NotNull = false;
            this.dt_infracao.ST_PrimaryKey = false;
            this.dt_infracao.TabIndex = 12;
            // 
            // dt_vencimento
            // 
            this.dt_vencimento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Dt_vencimentostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_vencimento.Location = new System.Drawing.Point(482, 157);
            this.dt_vencimento.Mask = "00/00/0000";
            this.dt_vencimento.Name = "dt_vencimento";
            this.dt_vencimento.NM_Alias = "";
            this.dt_vencimento.NM_Campo = "";
            this.dt_vencimento.NM_CampoBusca = "";
            this.dt_vencimento.NM_Param = "";
            this.dt_vencimento.Size = new System.Drawing.Size(70, 20);
            this.dt_vencimento.ST_Gravar = true;
            this.dt_vencimento.ST_LimpaCampo = true;
            this.dt_vencimento.ST_NotNull = false;
            this.dt_vencimento.ST_PrimaryKey = false;
            this.dt_vencimento.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Viagem:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Motorista:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 90;
            this.label11.Text = "Empresa:";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(92, 3);
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
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(159, 2);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // bb_motorista
            // 
            this.bb_motorista.Image = ((System.Drawing.Image)(resources.GetObject("bb_motorista.Image")));
            this.bb_motorista.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_motorista.Location = new System.Drawing.Point(193, 55);
            this.bb_motorista.Name = "bb_motorista";
            this.bb_motorista.Size = new System.Drawing.Size(28, 19);
            this.bb_motorista.TabIndex = 5;
            this.bb_motorista.UseVisualStyleBackColor = true;
            this.bb_motorista.Click += new System.EventHandler(this.bb_motorista_Click);
            // 
            // bb_viagem
            // 
            this.bb_viagem.Image = ((System.Drawing.Image)(resources.GetObject("bb_viagem.Image")));
            this.bb_viagem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_viagem.Location = new System.Drawing.Point(159, 30);
            this.bb_viagem.Name = "bb_viagem";
            this.bb_viagem.Size = new System.Drawing.Size(28, 19);
            this.bb_viagem.TabIndex = 3;
            this.bb_viagem.UseVisualStyleBackColor = true;
            this.bb_viagem.Click += new System.EventHandler(this.bb_viagem_Click);
            // 
            // ds_motorista
            // 
            this.ds_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.ds_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_motorista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Nm_motorista", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_motorista.Enabled = false;
            this.ds_motorista.Location = new System.Drawing.Point(227, 54);
            this.ds_motorista.Name = "ds_motorista";
            this.ds_motorista.NM_Alias = "";
            this.ds_motorista.NM_Campo = "nm_clifor";
            this.ds_motorista.NM_CampoBusca = "nm_clifor";
            this.ds_motorista.NM_Param = "@P_NM_CLIFOR";
            this.ds_motorista.QTD_Zero = 0;
            this.ds_motorista.Size = new System.Drawing.Size(325, 20);
            this.ds_motorista.ST_AutoInc = false;
            this.ds_motorista.ST_DisableAuto = false;
            this.ds_motorista.ST_Float = false;
            this.ds_motorista.ST_Gravar = false;
            this.ds_motorista.ST_Int = false;
            this.ds_motorista.ST_LimpaCampo = true;
            this.ds_motorista.ST_NotNull = false;
            this.ds_motorista.ST_PrimaryKey = false;
            this.ds_motorista.TabIndex = 8;
            this.ds_motorista.TextOld = null;
            // 
            // ds_viagem
            // 
            this.ds_viagem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_viagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_viagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_viagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Ds_viagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_viagem.Enabled = false;
            this.ds_viagem.Location = new System.Drawing.Point(193, 29);
            this.ds_viagem.Name = "ds_viagem";
            this.ds_viagem.NM_Alias = "";
            this.ds_viagem.NM_Campo = "ds_viagem";
            this.ds_viagem.NM_CampoBusca = "ds_viagem";
            this.ds_viagem.NM_Param = "@P_DS_VIAGEM";
            this.ds_viagem.QTD_Zero = 0;
            this.ds_viagem.Size = new System.Drawing.Size(359, 20);
            this.ds_viagem.ST_AutoInc = false;
            this.ds_viagem.ST_DisableAuto = false;
            this.ds_viagem.ST_Float = false;
            this.ds_viagem.ST_Gravar = false;
            this.ds_viagem.ST_Int = false;
            this.ds_viagem.ST_LimpaCampo = true;
            this.ds_viagem.ST_NotNull = false;
            this.ds_viagem.ST_PrimaryKey = false;
            this.ds_viagem.TabIndex = 5;
            this.ds_viagem.TextOld = null;
            // 
            // cd_motorista
            // 
            this.cd_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.cd_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_motorista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Cd_motorista", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_motorista.Location = new System.Drawing.Point(92, 54);
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
            this.cd_motorista.ST_NotNull = false;
            this.cd_motorista.ST_PrimaryKey = false;
            this.cd_motorista.TabIndex = 4;
            this.cd_motorista.TextOld = null;
            this.cd_motorista.Leave += new System.EventHandler(this.cd_motorista_Leave);
            // 
            // id_viagem
            // 
            this.id_viagem.BackColor = System.Drawing.SystemColors.Window;
            this.id_viagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_viagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_viagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Id_viagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_viagem.Location = new System.Drawing.Point(92, 29);
            this.id_viagem.Name = "id_viagem";
            this.id_viagem.NM_Alias = "";
            this.id_viagem.NM_Campo = "id_viagem";
            this.id_viagem.NM_CampoBusca = "id_viagem";
            this.id_viagem.NM_Param = "@P_ID_VIAGEM";
            this.id_viagem.QTD_Zero = 0;
            this.id_viagem.Size = new System.Drawing.Size(61, 20);
            this.id_viagem.ST_AutoInc = false;
            this.id_viagem.ST_DisableAuto = false;
            this.id_viagem.ST_Float = false;
            this.id_viagem.ST_Gravar = true;
            this.id_viagem.ST_Int = false;
            this.id_viagem.ST_LimpaCampo = true;
            this.id_viagem.ST_NotNull = false;
            this.id_viagem.ST_PrimaryKey = false;
            this.id_viagem.TabIndex = 2;
            this.id_viagem.TextOld = null;
            this.id_viagem.Leave += new System.EventHandler(this.id_viagem_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInfracoes, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(193, 1);
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
            this.nm_empresa.TextOld = null;
            // 
            // bbAddDespesa
            // 
            this.bbAddDespesa.Image = ((System.Drawing.Image)(resources.GetObject("bbAddDespesa.Image")));
            this.bbAddDespesa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbAddDespesa.Location = new System.Drawing.Point(188, 107);
            this.bbAddDespesa.Name = "bbAddDespesa";
            this.bbAddDespesa.Size = new System.Drawing.Size(28, 19);
            this.bbAddDespesa.TabIndex = 121;
            this.bbAddDespesa.UseVisualStyleBackColor = true;
            this.bbAddDespesa.Click += new System.EventHandler(this.bbAddDespesa_Click);
            // 
            // TFInfracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 310);
            this.Controls.Add(this.pInfracoes);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFInfracoes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Infrações do Veiculo";
            this.Load += new System.EventHandler(this.TFInfracoes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFInfracoes_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pInfracoes.ResumeLayout(false);
            this.pInfracoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsInfracoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_infracao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.PanelDados pInfracoes;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.Label label14;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private Componentes.ComboBoxDefault tp_gravidade;
        private System.Windows.Forms.Label label10;
        private Componentes.EditFloat vl_infracao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Componentes.EditMask dt_infracao;
        private Componentes.EditMask dt_vencimento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private System.Windows.Forms.Button bb_motorista;
        private System.Windows.Forms.Button bb_viagem;
        private Componentes.EditDefault ds_motorista;
        private Componentes.EditDefault ds_viagem;
        private Componentes.EditDefault cd_motorista;
        private Componentes.EditDefault id_viagem;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_infracao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault ds_infracao;
        private System.Windows.Forms.BindingSource bsInfracoes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bb_despesa;
        private Componentes.EditDefault ds_despesa;
        private Componentes.EditDefault id_despesa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bb_veiculo;
        private Componentes.EditDefault ds_veiculo;
        private Componentes.EditDefault id_veiculo;
        private System.Windows.Forms.Button bbAddDespesa;
    }
}