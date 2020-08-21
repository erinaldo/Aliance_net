namespace Frota
{
    partial class TFRequisicao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRequisicao));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_viagem = new Componentes.EditDefault(this.components);
            this.bb_viagem = new System.Windows.Forms.Button();
            this.id_viagem = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.volume_requisicao = new Componentes.EditFloat(this.components);
            this.dt_requisicao = new Componentes.EditData(this.components);
            this.label5 = new System.Windows.Forms.Label();
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
            this.bsAbastecimento = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.ds_combustivel = new Componentes.EditDefault(this.components);
            this.cd_combustivel = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volume_requisicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAbastecimento)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(759, 43);
            this.barraMenu.TabIndex = 17;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.ds_combustivel);
            this.pDados.Controls.Add(this.cd_combustivel);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.ds_viagem);
            this.pDados.Controls.Add(this.bb_viagem);
            this.pDados.Controls.Add(this.id_viagem);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.volume_requisicao);
            this.pDados.Controls.Add(this.dt_requisicao);
            this.pDados.Controls.Add(this.label5);
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
            this.pDados.Size = new System.Drawing.Size(759, 244);
            this.pDados.TabIndex = 18;
            // 
            // ds_viagem
            // 
            this.ds_viagem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_viagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_viagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_viagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_viagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_viagem.Enabled = false;
            this.ds_viagem.Location = new System.Drawing.Point(183, 30);
            this.ds_viagem.Name = "ds_viagem";
            this.ds_viagem.NM_Alias = "";
            this.ds_viagem.NM_Campo = "ds_viagem";
            this.ds_viagem.NM_CampoBusca = "ds_viagem";
            this.ds_viagem.NM_Param = "@P_NM_EMPRESA";
            this.ds_viagem.QTD_Zero = 0;
            this.ds_viagem.Size = new System.Drawing.Size(563, 20);
            this.ds_viagem.ST_AutoInc = false;
            this.ds_viagem.ST_DisableAuto = false;
            this.ds_viagem.ST_Float = false;
            this.ds_viagem.ST_Gravar = false;
            this.ds_viagem.ST_Int = false;
            this.ds_viagem.ST_LimpaCampo = true;
            this.ds_viagem.ST_NotNull = false;
            this.ds_viagem.ST_PrimaryKey = false;
            this.ds_viagem.TabIndex = 46;
            // 
            // bb_viagem
            // 
            this.bb_viagem.Image = ((System.Drawing.Image)(resources.GetObject("bb_viagem.Image")));
            this.bb_viagem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_viagem.Location = new System.Drawing.Point(149, 30);
            this.bb_viagem.Name = "bb_viagem";
            this.bb_viagem.Size = new System.Drawing.Size(28, 20);
            this.bb_viagem.TabIndex = 3;
            this.bb_viagem.UseVisualStyleBackColor = true;
            this.bb_viagem.Click += new System.EventHandler(this.bb_viagem_Click);
            // 
            // id_viagem
            // 
            this.id_viagem.BackColor = System.Drawing.SystemColors.Window;
            this.id_viagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_viagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_viagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Id_viagemstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_viagem.Location = new System.Drawing.Point(77, 30);
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
            this.id_viagem.TabIndex = 2;
            this.id_viagem.TextChanged += new System.EventHandler(this.id_viagem_TextChanged);
            this.id_viagem.Leave += new System.EventHandler(this.id_viagem_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Viagem:";
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(77, 160);
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
            this.ds_observacao.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Observação:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Volume Requisição:";
            // 
            // volume_requisicao
            // 
            this.volume_requisicao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAbastecimento, "Volume_requisicao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.volume_requisicao.Location = new System.Drawing.Point(290, 134);
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
            this.volume_requisicao.Size = new System.Drawing.Size(120, 20);
            this.volume_requisicao.ST_AutoInc = false;
            this.volume_requisicao.ST_DisableAuto = false;
            this.volume_requisicao.ST_Gravar = true;
            this.volume_requisicao.ST_LimparCampo = true;
            this.volume_requisicao.ST_NotNull = false;
            this.volume_requisicao.ST_PrimaryKey = false;
            this.volume_requisicao.TabIndex = 9;
            this.volume_requisicao.ThousandsSeparator = true;
            // 
            // dt_requisicao
            // 
            this.dt_requisicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_requisicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Dt_requisicaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_requisicao.Location = new System.Drawing.Point(77, 134);
            this.dt_requisicao.Mask = "00/00/0000";
            this.dt_requisicao.Name = "dt_requisicao";
            this.dt_requisicao.NM_Alias = "";
            this.dt_requisicao.NM_Campo = "";
            this.dt_requisicao.NM_CampoBusca = "";
            this.dt_requisicao.NM_Param = "";
            this.dt_requisicao.Operador = "";
            this.dt_requisicao.Size = new System.Drawing.Size(100, 20);
            this.dt_requisicao.ST_Gravar = true;
            this.dt_requisicao.ST_LimpaCampo = true;
            this.dt_requisicao.ST_NotNull = true;
            this.dt_requisicao.ST_PrimaryKey = false;
            this.dt_requisicao.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Data:";
            // 
            // ds_despesa
            // 
            this.ds_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_despesa.Enabled = false;
            this.ds_despesa.Location = new System.Drawing.Point(183, 82);
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
            this.ds_despesa.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Despesa:";
            // 
            // bb_despesa
            // 
            this.bb_despesa.Image = ((System.Drawing.Image)(resources.GetObject("bb_despesa.Image")));
            this.bb_despesa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_despesa.Location = new System.Drawing.Point(149, 82);
            this.bb_despesa.Name = "bb_despesa";
            this.bb_despesa.Size = new System.Drawing.Size(28, 20);
            this.bb_despesa.TabIndex = 7;
            this.bb_despesa.UseVisualStyleBackColor = true;
            this.bb_despesa.Click += new System.EventHandler(this.bb_despesa_Click);
            // 
            // id_despesa
            // 
            this.id_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.id_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Id_despesastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_despesa.Location = new System.Drawing.Point(77, 82);
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
            this.id_despesa.TabIndex = 6;
            this.id_despesa.Leave += new System.EventHandler(this.id_despesa_Leave);
            // 
            // placa
            // 
            this.placa.BackColor = System.Drawing.SystemColors.Window;
            this.placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.placa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Placa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.placa.Enabled = false;
            this.placa.Location = new System.Drawing.Point(641, 56);
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
            this.placa.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(598, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Placa:";
            // 
            // ds_veiculo
            // 
            this.ds_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_veiculo.Enabled = false;
            this.ds_veiculo.Location = new System.Drawing.Point(183, 56);
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
            this.ds_veiculo.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Veiculo:";
            // 
            // bb_veiculo
            // 
            this.bb_veiculo.Image = ((System.Drawing.Image)(resources.GetObject("bb_veiculo.Image")));
            this.bb_veiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_veiculo.Location = new System.Drawing.Point(149, 56);
            this.bb_veiculo.Name = "bb_veiculo";
            this.bb_veiculo.Size = new System.Drawing.Size(28, 20);
            this.bb_veiculo.TabIndex = 5;
            this.bb_veiculo.UseVisualStyleBackColor = true;
            this.bb_veiculo.Click += new System.EventHandler(this.bb_veiculo_Click);
            // 
            // id_veiculo
            // 
            this.id_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.id_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Id_veiculostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_veiculo.Location = new System.Drawing.Point(77, 56);
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
            this.id_veiculo.TabIndex = 4;
            this.id_veiculo.Leave += new System.EventHandler(this.id_veiculo_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(183, 4);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(563, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Empresa:";
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(149, 4);
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
            this.cd_empresa.Location = new System.Drawing.Point(77, 4);
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
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // bsAbastecimento
            // 
            this.bsAbastecimento.DataSource = typeof(CamadaDados.Frota.TList_AbastVeiculo);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Combustivel:";
            // 
            // ds_combustivel
            // 
            this.ds_combustivel.BackColor = System.Drawing.SystemColors.Window;
            this.ds_combustivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_combustivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_combustivel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_combustivel.Enabled = false;
            this.ds_combustivel.Location = new System.Drawing.Point(183, 108);
            this.ds_combustivel.Name = "ds_combustivel";
            this.ds_combustivel.NM_Alias = "";
            this.ds_combustivel.NM_Campo = "ds_despesa";
            this.ds_combustivel.NM_CampoBusca = "ds_despesa";
            this.ds_combustivel.NM_Param = "@P_DS_DESPESA";
            this.ds_combustivel.QTD_Zero = 0;
            this.ds_combustivel.Size = new System.Drawing.Size(563, 20);
            this.ds_combustivel.ST_AutoInc = false;
            this.ds_combustivel.ST_DisableAuto = false;
            this.ds_combustivel.ST_Float = false;
            this.ds_combustivel.ST_Gravar = false;
            this.ds_combustivel.ST_Int = false;
            this.ds_combustivel.ST_LimpaCampo = true;
            this.ds_combustivel.ST_NotNull = false;
            this.ds_combustivel.ST_PrimaryKey = false;
            this.ds_combustivel.TabIndex = 49;
            // 
            // cd_combustivel
            // 
            this.cd_combustivel.BackColor = System.Drawing.SystemColors.Window;
            this.cd_combustivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_combustivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_combustivel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_combustivel.Enabled = false;
            this.cd_combustivel.Location = new System.Drawing.Point(77, 108);
            this.cd_combustivel.Name = "cd_combustivel";
            this.cd_combustivel.NM_Alias = "";
            this.cd_combustivel.NM_Campo = "id_despesa";
            this.cd_combustivel.NM_CampoBusca = "id_despesa";
            this.cd_combustivel.NM_Param = "@P_CD_EMPRESA";
            this.cd_combustivel.QTD_Zero = 0;
            this.cd_combustivel.Size = new System.Drawing.Size(100, 20);
            this.cd_combustivel.ST_AutoInc = false;
            this.cd_combustivel.ST_DisableAuto = false;
            this.cd_combustivel.ST_Float = false;
            this.cd_combustivel.ST_Gravar = true;
            this.cd_combustivel.ST_Int = false;
            this.cd_combustivel.ST_LimpaCampo = true;
            this.cd_combustivel.ST_NotNull = true;
            this.cd_combustivel.ST_PrimaryKey = false;
            this.cd_combustivel.TabIndex = 48;
            // 
            // TFRequisicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 287);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFRequisicao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requisição Abastecimento";
            this.Load += new System.EventHandler(this.TFRequisicao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRequisicao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volume_requisicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAbastecimento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat volume_requisicao;
        private Componentes.EditData dt_requisicao;
        private System.Windows.Forms.Label label5;
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
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource bsAbastecimento;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault ds_viagem;
        private System.Windows.Forms.Button bb_viagem;
        private Componentes.EditDefault id_viagem;
        private Componentes.EditDefault ds_combustivel;
        private Componentes.EditDefault cd_combustivel;
        private System.Windows.Forms.Label label9;
    }
}