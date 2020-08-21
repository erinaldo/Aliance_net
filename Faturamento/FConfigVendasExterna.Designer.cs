namespace Faturamento
{
    partial class TFConfigVendasExterna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFConfigVendasExterna));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.ds_config = new Componentes.EditDefault(this.components);
            this.bsCfgVendasExterna = new System.Windows.Forms.BindingSource(this.components);
            this.bb_config = new System.Windows.Forms.Button();
            this.id_config = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.bbHistorico = new System.Windows.Forms.Button();
            this.cd_historico = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.ds_condpgto = new Componentes.EditDefault(this.components);
            this.bb_condpgto = new System.Windows.Forms.Button();
            this.cd_condpgto = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.ds_tpdocto = new Componentes.EditDefault(this.components);
            this.bb_tpdocto = new System.Windows.Forms.Button();
            this.tp_docto = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.ds_tpduplicata = new Componentes.EditDefault(this.components);
            this.bb_tpduplicata = new System.Windows.Forms.Button();
            this.tp_duplicata = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.bbIntegracao = new System.Windows.Forms.Button();
            this.bbLicenca = new System.Windows.Forms.Button();
            this.Integracao = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.licenca = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.senha = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.login = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.ds_tipopedido = new Componentes.EditDefault(this.components);
            this.bbCfgPedido = new System.Windows.Forms.Button();
            this.cfg_pedido = new Componentes.EditDefault(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgVendasExterna)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(611, 43);
            this.barraMenu.TabIndex = 20;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(102, 40);
            this.BB_Gravar.Text = " (F4)\r\n Confirmar";
            this.BB_Gravar.ToolTipText = "Confirmar";
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
            this.pDados.Controls.Add(this.ds_tipopedido);
            this.pDados.Controls.Add(this.bbCfgPedido);
            this.pDados.Controls.Add(this.cfg_pedido);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.bbIntegracao);
            this.pDados.Controls.Add(this.bbLicenca);
            this.pDados.Controls.Add(this.Integracao);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.licenca);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.senha);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.login);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(611, 341);
            this.pDados.TabIndex = 0;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.ds_config);
            this.radioGroup1.Controls.Add(this.bb_config);
            this.radioGroup1.Controls.Add(this.id_config);
            this.radioGroup1.Controls.Add(this.label10);
            this.radioGroup1.Controls.Add(this.ds_historico);
            this.radioGroup1.Controls.Add(this.bbHistorico);
            this.radioGroup1.Controls.Add(this.cd_historico);
            this.radioGroup1.Controls.Add(this.label9);
            this.radioGroup1.Controls.Add(this.ds_condpgto);
            this.radioGroup1.Controls.Add(this.bb_condpgto);
            this.radioGroup1.Controls.Add(this.cd_condpgto);
            this.radioGroup1.Controls.Add(this.label7);
            this.radioGroup1.Controls.Add(this.ds_tpdocto);
            this.radioGroup1.Controls.Add(this.bb_tpdocto);
            this.radioGroup1.Controls.Add(this.tp_docto);
            this.radioGroup1.Controls.Add(this.label6);
            this.radioGroup1.Controls.Add(this.ds_tpduplicata);
            this.radioGroup1.Controls.Add(this.bb_tpduplicata);
            this.radioGroup1.Controls.Add(this.tp_duplicata);
            this.radioGroup1.Controls.Add(this.label5);
            this.radioGroup1.Location = new System.Drawing.Point(75, 107);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(530, 218);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 10;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Configuração Financeira Importação Boleto";
            // 
            // ds_config
            // 
            this.ds_config.BackColor = System.Drawing.SystemColors.Window;
            this.ds_config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_config.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_config.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Ds_config", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_config.Enabled = false;
            this.ds_config.Location = new System.Drawing.Point(119, 190);
            this.ds_config.Name = "ds_config";
            this.ds_config.NM_Alias = "";
            this.ds_config.NM_Campo = "ds_config";
            this.ds_config.NM_CampoBusca = "ds_config";
            this.ds_config.NM_Param = "@P_NM_EMPRESA";
            this.ds_config.QTD_Zero = 0;
            this.ds_config.Size = new System.Drawing.Size(405, 20);
            this.ds_config.ST_AutoInc = false;
            this.ds_config.ST_DisableAuto = false;
            this.ds_config.ST_Float = false;
            this.ds_config.ST_Gravar = false;
            this.ds_config.ST_Int = false;
            this.ds_config.ST_LimpaCampo = true;
            this.ds_config.ST_NotNull = false;
            this.ds_config.ST_PrimaryKey = false;
            this.ds_config.TabIndex = 164;
            this.ds_config.TextOld = null;
            // 
            // bsCfgVendasExterna
            // 
            this.bsCfgVendasExterna.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CFGVendasExterna);
            // 
            // bb_config
            // 
            this.bb_config.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_config.Image = ((System.Drawing.Image)(resources.GetObject("bb_config.Image")));
            this.bb_config.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_config.Location = new System.Drawing.Point(83, 190);
            this.bb_config.Name = "bb_config";
            this.bb_config.Size = new System.Drawing.Size(30, 20);
            this.bb_config.TabIndex = 163;
            this.bb_config.UseVisualStyleBackColor = true;
            this.bb_config.Click += new System.EventHandler(this.bb_config_Click);
            // 
            // id_config
            // 
            this.id_config.BackColor = System.Drawing.SystemColors.Window;
            this.id_config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_config.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_config.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Id_configstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_config.Location = new System.Drawing.Point(9, 191);
            this.id_config.Name = "id_config";
            this.id_config.NM_Alias = "";
            this.id_config.NM_Campo = "id_config";
            this.id_config.NM_CampoBusca = "id_config";
            this.id_config.NM_Param = "@P_CD_EMPRESA";
            this.id_config.QTD_Zero = 0;
            this.id_config.Size = new System.Drawing.Size(73, 20);
            this.id_config.ST_AutoInc = false;
            this.id_config.ST_DisableAuto = false;
            this.id_config.ST_Float = false;
            this.id_config.ST_Gravar = true;
            this.id_config.ST_Int = false;
            this.id_config.ST_LimpaCampo = true;
            this.id_config.ST_NotNull = false;
            this.id_config.ST_PrimaryKey = false;
            this.id_config.TabIndex = 162;
            this.id_config.TextOld = null;
            this.id_config.Leave += new System.EventHandler(this.id_config_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(6, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 165;
            this.label10.Text = "Config. Boleto";
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_historico.Enabled = false;
            this.ds_historico.Location = new System.Drawing.Point(119, 151);
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "ds_historico";
            this.ds_historico.NM_CampoBusca = "ds_historico";
            this.ds_historico.NM_Param = "@P_NM_EMPRESA";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.Size = new System.Drawing.Size(405, 20);
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = false;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = false;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TabIndex = 160;
            this.ds_historico.TextOld = null;
            // 
            // bbHistorico
            // 
            this.bbHistorico.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bbHistorico.Image = ((System.Drawing.Image)(resources.GetObject("bbHistorico.Image")));
            this.bbHistorico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbHistorico.Location = new System.Drawing.Point(83, 151);
            this.bbHistorico.Name = "bbHistorico";
            this.bbHistorico.Size = new System.Drawing.Size(30, 20);
            this.bbHistorico.TabIndex = 159;
            this.bbHistorico.UseVisualStyleBackColor = true;
            this.bbHistorico.Click += new System.EventHandler(this.bbHistorico_Click);
            // 
            // cd_historico
            // 
            this.cd_historico.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Cd_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_historico.Location = new System.Drawing.Point(9, 152);
            this.cd_historico.Name = "cd_historico";
            this.cd_historico.NM_Alias = "";
            this.cd_historico.NM_Campo = "cd_historico";
            this.cd_historico.NM_CampoBusca = "cd_historico";
            this.cd_historico.NM_Param = "@P_CD_EMPRESA";
            this.cd_historico.QTD_Zero = 0;
            this.cd_historico.Size = new System.Drawing.Size(73, 20);
            this.cd_historico.ST_AutoInc = false;
            this.cd_historico.ST_DisableAuto = false;
            this.cd_historico.ST_Float = false;
            this.cd_historico.ST_Gravar = true;
            this.cd_historico.ST_Int = false;
            this.cd_historico.ST_LimpaCampo = true;
            this.cd_historico.ST_NotNull = false;
            this.cd_historico.ST_PrimaryKey = false;
            this.cd_historico.TabIndex = 158;
            this.cd_historico.TextOld = null;
            this.cd_historico.Leave += new System.EventHandler(this.cd_historico_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(6, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 161;
            this.label9.Text = "Histórico";
            // 
            // ds_condpgto
            // 
            this.ds_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Ds_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_condpgto.Enabled = false;
            this.ds_condpgto.Location = new System.Drawing.Point(119, 112);
            this.ds_condpgto.Name = "ds_condpgto";
            this.ds_condpgto.NM_Alias = "";
            this.ds_condpgto.NM_Campo = "ds_condpgto";
            this.ds_condpgto.NM_CampoBusca = "ds_condpgto";
            this.ds_condpgto.NM_Param = "@P_NM_EMPRESA";
            this.ds_condpgto.QTD_Zero = 0;
            this.ds_condpgto.Size = new System.Drawing.Size(405, 20);
            this.ds_condpgto.ST_AutoInc = false;
            this.ds_condpgto.ST_DisableAuto = false;
            this.ds_condpgto.ST_Float = false;
            this.ds_condpgto.ST_Gravar = false;
            this.ds_condpgto.ST_Int = false;
            this.ds_condpgto.ST_LimpaCampo = true;
            this.ds_condpgto.ST_NotNull = false;
            this.ds_condpgto.ST_PrimaryKey = false;
            this.ds_condpgto.TabIndex = 156;
            this.ds_condpgto.TextOld = null;
            // 
            // bb_condpgto
            // 
            this.bb_condpgto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_condpgto.Image = ((System.Drawing.Image)(resources.GetObject("bb_condpgto.Image")));
            this.bb_condpgto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_condpgto.Location = new System.Drawing.Point(83, 112);
            this.bb_condpgto.Name = "bb_condpgto";
            this.bb_condpgto.Size = new System.Drawing.Size(30, 20);
            this.bb_condpgto.TabIndex = 155;
            this.bb_condpgto.UseVisualStyleBackColor = true;
            this.bb_condpgto.Click += new System.EventHandler(this.bb_condpgto_Click);
            // 
            // cd_condpgto
            // 
            this.cd_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Cd_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_condpgto.Location = new System.Drawing.Point(9, 113);
            this.cd_condpgto.Name = "cd_condpgto";
            this.cd_condpgto.NM_Alias = "";
            this.cd_condpgto.NM_Campo = "cd_condpgto";
            this.cd_condpgto.NM_CampoBusca = "cd_condpgto";
            this.cd_condpgto.NM_Param = "@P_CD_EMPRESA";
            this.cd_condpgto.QTD_Zero = 0;
            this.cd_condpgto.Size = new System.Drawing.Size(73, 20);
            this.cd_condpgto.ST_AutoInc = false;
            this.cd_condpgto.ST_DisableAuto = false;
            this.cd_condpgto.ST_Float = false;
            this.cd_condpgto.ST_Gravar = true;
            this.cd_condpgto.ST_Int = false;
            this.cd_condpgto.ST_LimpaCampo = true;
            this.cd_condpgto.ST_NotNull = false;
            this.cd_condpgto.ST_PrimaryKey = false;
            this.cd_condpgto.TabIndex = 154;
            this.cd_condpgto.TextOld = null;
            this.cd_condpgto.Leave += new System.EventHandler(this.cd_condpgto_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(6, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 157;
            this.label7.Text = "Condição Pagamento";
            // 
            // ds_tpdocto
            // 
            this.ds_tpdocto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpdocto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpdocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpdocto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Ds_tpdocto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpdocto.Enabled = false;
            this.ds_tpdocto.Location = new System.Drawing.Point(119, 74);
            this.ds_tpdocto.Name = "ds_tpdocto";
            this.ds_tpdocto.NM_Alias = "";
            this.ds_tpdocto.NM_Campo = "ds_tpdocto";
            this.ds_tpdocto.NM_CampoBusca = "ds_tpdocto";
            this.ds_tpdocto.NM_Param = "@P_NM_EMPRESA";
            this.ds_tpdocto.QTD_Zero = 0;
            this.ds_tpdocto.Size = new System.Drawing.Size(405, 20);
            this.ds_tpdocto.ST_AutoInc = false;
            this.ds_tpdocto.ST_DisableAuto = false;
            this.ds_tpdocto.ST_Float = false;
            this.ds_tpdocto.ST_Gravar = false;
            this.ds_tpdocto.ST_Int = false;
            this.ds_tpdocto.ST_LimpaCampo = true;
            this.ds_tpdocto.ST_NotNull = false;
            this.ds_tpdocto.ST_PrimaryKey = false;
            this.ds_tpdocto.TabIndex = 152;
            this.ds_tpdocto.TextOld = null;
            // 
            // bb_tpdocto
            // 
            this.bb_tpdocto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_tpdocto.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpdocto.Image")));
            this.bb_tpdocto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpdocto.Location = new System.Drawing.Point(83, 74);
            this.bb_tpdocto.Name = "bb_tpdocto";
            this.bb_tpdocto.Size = new System.Drawing.Size(30, 20);
            this.bb_tpdocto.TabIndex = 151;
            this.bb_tpdocto.UseVisualStyleBackColor = true;
            this.bb_tpdocto.Click += new System.EventHandler(this.bb_tpdocto_Click);
            // 
            // tp_docto
            // 
            this.tp_docto.BackColor = System.Drawing.SystemColors.Window;
            this.tp_docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_docto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Tp_doctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_docto.Location = new System.Drawing.Point(9, 75);
            this.tp_docto.Name = "tp_docto";
            this.tp_docto.NM_Alias = "";
            this.tp_docto.NM_Campo = "tp_docto";
            this.tp_docto.NM_CampoBusca = "tp_docto";
            this.tp_docto.NM_Param = "@P_CD_EMPRESA";
            this.tp_docto.QTD_Zero = 0;
            this.tp_docto.Size = new System.Drawing.Size(73, 20);
            this.tp_docto.ST_AutoInc = false;
            this.tp_docto.ST_DisableAuto = false;
            this.tp_docto.ST_Float = false;
            this.tp_docto.ST_Gravar = true;
            this.tp_docto.ST_Int = false;
            this.tp_docto.ST_LimpaCampo = true;
            this.tp_docto.ST_NotNull = false;
            this.tp_docto.ST_PrimaryKey = false;
            this.tp_docto.TabIndex = 150;
            this.tp_docto.TextOld = null;
            this.tp_docto.Leave += new System.EventHandler(this.tp_docto_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 153;
            this.label6.Text = "Tipo Documento";
            // 
            // ds_tpduplicata
            // 
            this.ds_tpduplicata.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpduplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpduplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpduplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Ds_tpduplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpduplicata.Enabled = false;
            this.ds_tpduplicata.Location = new System.Drawing.Point(119, 31);
            this.ds_tpduplicata.Name = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Alias = "";
            this.ds_tpduplicata.NM_Campo = "ds_tpduplicata";
            this.ds_tpduplicata.NM_CampoBusca = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Param = "@P_NM_EMPRESA";
            this.ds_tpduplicata.QTD_Zero = 0;
            this.ds_tpduplicata.Size = new System.Drawing.Size(405, 20);
            this.ds_tpduplicata.ST_AutoInc = false;
            this.ds_tpduplicata.ST_DisableAuto = false;
            this.ds_tpduplicata.ST_Float = false;
            this.ds_tpduplicata.ST_Gravar = false;
            this.ds_tpduplicata.ST_Int = false;
            this.ds_tpduplicata.ST_LimpaCampo = true;
            this.ds_tpduplicata.ST_NotNull = false;
            this.ds_tpduplicata.ST_PrimaryKey = false;
            this.ds_tpduplicata.TabIndex = 148;
            this.ds_tpduplicata.TextOld = null;
            // 
            // bb_tpduplicata
            // 
            this.bb_tpduplicata.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_tpduplicata.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpduplicata.Image")));
            this.bb_tpduplicata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpduplicata.Location = new System.Drawing.Point(83, 31);
            this.bb_tpduplicata.Name = "bb_tpduplicata";
            this.bb_tpduplicata.Size = new System.Drawing.Size(30, 20);
            this.bb_tpduplicata.TabIndex = 147;
            this.bb_tpduplicata.UseVisualStyleBackColor = true;
            this.bb_tpduplicata.Click += new System.EventHandler(this.bb_tpduplicata_Click);
            // 
            // tp_duplicata
            // 
            this.tp_duplicata.BackColor = System.Drawing.SystemColors.Window;
            this.tp_duplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_duplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_duplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Tp_duplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_duplicata.Location = new System.Drawing.Point(9, 32);
            this.tp_duplicata.Name = "tp_duplicata";
            this.tp_duplicata.NM_Alias = "";
            this.tp_duplicata.NM_Campo = "tp_duplicata";
            this.tp_duplicata.NM_CampoBusca = "tp_duplicata";
            this.tp_duplicata.NM_Param = "@P_CD_EMPRESA";
            this.tp_duplicata.QTD_Zero = 0;
            this.tp_duplicata.Size = new System.Drawing.Size(73, 20);
            this.tp_duplicata.ST_AutoInc = false;
            this.tp_duplicata.ST_DisableAuto = false;
            this.tp_duplicata.ST_Float = false;
            this.tp_duplicata.ST_Gravar = true;
            this.tp_duplicata.ST_Int = false;
            this.tp_duplicata.ST_LimpaCampo = true;
            this.tp_duplicata.ST_NotNull = false;
            this.tp_duplicata.ST_PrimaryKey = false;
            this.tp_duplicata.TabIndex = 146;
            this.tp_duplicata.TextOld = null;
            this.tp_duplicata.Leave += new System.EventHandler(this.tp_duplicata_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 149;
            this.label5.Text = "Tipo Duplicata";
            // 
            // bbIntegracao
            // 
            this.bbIntegracao.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bbIntegracao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbIntegracao.Location = new System.Drawing.Point(399, 55);
            this.bbIntegracao.Name = "bbIntegracao";
            this.bbIntegracao.Size = new System.Drawing.Size(95, 20);
            this.bbIntegracao.TabIndex = 7;
            this.bbIntegracao.Text = "Obter Integração";
            this.bbIntegracao.UseVisualStyleBackColor = true;
            this.bbIntegracao.Click += new System.EventHandler(this.bbIntegracao_Click);
            // 
            // bbLicenca
            // 
            this.bbLicenca.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bbLicenca.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbLicenca.Location = new System.Drawing.Point(154, 55);
            this.bbLicenca.Name = "bbLicenca";
            this.bbLicenca.Size = new System.Drawing.Size(82, 20);
            this.bbLicenca.TabIndex = 5;
            this.bbLicenca.Text = "Obter Licença";
            this.bbLicenca.UseVisualStyleBackColor = true;
            this.bbLicenca.Click += new System.EventHandler(this.bbLicenca_Click);
            // 
            // Integracao
            // 
            this.Integracao.BackColor = System.Drawing.SystemColors.Window;
            this.Integracao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Integracao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Integracao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Integracao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Integracao.Location = new System.Drawing.Point(309, 55);
            this.Integracao.Name = "Integracao";
            this.Integracao.NM_Alias = "";
            this.Integracao.NM_Campo = "";
            this.Integracao.NM_CampoBusca = "";
            this.Integracao.NM_Param = "";
            this.Integracao.QTD_Zero = 0;
            this.Integracao.Size = new System.Drawing.Size(84, 20);
            this.Integracao.ST_AutoInc = false;
            this.Integracao.ST_DisableAuto = false;
            this.Integracao.ST_Float = false;
            this.Integracao.ST_Gravar = false;
            this.Integracao.ST_Int = false;
            this.Integracao.ST_LimpaCampo = true;
            this.Integracao.ST_NotNull = false;
            this.Integracao.ST_PrimaryKey = false;
            this.Integracao.TabIndex = 6;
            this.Integracao.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(242, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 152;
            this.label4.Text = "Integração:";
            // 
            // licenca
            // 
            this.licenca.BackColor = System.Drawing.SystemColors.Window;
            this.licenca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.licenca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.licenca.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Licenca", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.licenca.Location = new System.Drawing.Point(75, 55);
            this.licenca.Name = "licenca";
            this.licenca.NM_Alias = "";
            this.licenca.NM_Campo = "";
            this.licenca.NM_CampoBusca = "";
            this.licenca.NM_Param = "";
            this.licenca.QTD_Zero = 0;
            this.licenca.Size = new System.Drawing.Size(73, 20);
            this.licenca.ST_AutoInc = false;
            this.licenca.ST_DisableAuto = false;
            this.licenca.ST_Float = false;
            this.licenca.ST_Gravar = false;
            this.licenca.ST_Int = false;
            this.licenca.ST_LimpaCampo = true;
            this.licenca.ST_NotNull = false;
            this.licenca.ST_PrimaryKey = false;
            this.licenca.TabIndex = 4;
            this.licenca.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(21, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 150;
            this.label3.Text = "Licença:";
            // 
            // senha
            // 
            this.senha.BackColor = System.Drawing.SystemColors.Window;
            this.senha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.senha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.senha.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Senha", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.senha.Location = new System.Drawing.Point(483, 29);
            this.senha.Name = "senha";
            this.senha.NM_Alias = "";
            this.senha.NM_Campo = "";
            this.senha.NM_CampoBusca = "";
            this.senha.NM_Param = "";
            this.senha.PasswordChar = '#';
            this.senha.QTD_Zero = 0;
            this.senha.Size = new System.Drawing.Size(122, 20);
            this.senha.ST_AutoInc = false;
            this.senha.ST_DisableAuto = false;
            this.senha.ST_Float = false;
            this.senha.ST_Gravar = false;
            this.senha.ST_Int = false;
            this.senha.ST_LimpaCampo = true;
            this.senha.ST_NotNull = false;
            this.senha.ST_PrimaryKey = false;
            this.senha.TabIndex = 3;
            this.senha.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(436, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 148;
            this.label2.Text = "Senha:";
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.SystemColors.Window;
            this.login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.login.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Login", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.login.Location = new System.Drawing.Point(75, 29);
            this.login.Name = "login";
            this.login.NM_Alias = "";
            this.login.NM_Campo = "";
            this.login.NM_CampoBusca = "";
            this.login.NM_Param = "";
            this.login.QTD_Zero = 0;
            this.login.Size = new System.Drawing.Size(355, 20);
            this.login.ST_AutoInc = false;
            this.login.ST_DisableAuto = false;
            this.login.ST_Float = false;
            this.login.ST_Gravar = false;
            this.login.ST_Int = false;
            this.login.ST_LimpaCampo = true;
            this.login.ST_NotNull = false;
            this.login.ST_PrimaryKey = false;
            this.login.TabIndex = 2;
            this.login.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 146;
            this.label1.Text = "Login:";
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Location = new System.Drawing.Point(185, 3);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(420, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 144;
            this.NM_Empresa.TextOld = null;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(149, 3);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(30, 20);
            this.BB_Empresa.TabIndex = 1;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Location = new System.Drawing.Point(75, 4);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(73, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = false;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(18, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 145;
            this.label8.Text = "Empresa:";
            // 
            // ds_tipopedido
            // 
            this.ds_tipopedido.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tipopedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tipopedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tipopedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Ds_tipopedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tipopedido.Enabled = false;
            this.ds_tipopedido.Location = new System.Drawing.Point(185, 80);
            this.ds_tipopedido.Name = "ds_tipopedido";
            this.ds_tipopedido.NM_Alias = "";
            this.ds_tipopedido.NM_Campo = "ds_tipopedido";
            this.ds_tipopedido.NM_CampoBusca = "ds_tipopedido";
            this.ds_tipopedido.NM_Param = "@P_NM_EMPRESA";
            this.ds_tipopedido.QTD_Zero = 0;
            this.ds_tipopedido.Size = new System.Drawing.Size(420, 20);
            this.ds_tipopedido.ST_AutoInc = false;
            this.ds_tipopedido.ST_DisableAuto = false;
            this.ds_tipopedido.ST_Float = false;
            this.ds_tipopedido.ST_Gravar = false;
            this.ds_tipopedido.ST_Int = false;
            this.ds_tipopedido.ST_LimpaCampo = true;
            this.ds_tipopedido.ST_NotNull = false;
            this.ds_tipopedido.ST_PrimaryKey = false;
            this.ds_tipopedido.TabIndex = 156;
            this.ds_tipopedido.TextOld = null;
            // 
            // bbCfgPedido
            // 
            this.bbCfgPedido.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bbCfgPedido.Image = ((System.Drawing.Image)(resources.GetObject("bbCfgPedido.Image")));
            this.bbCfgPedido.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbCfgPedido.Location = new System.Drawing.Point(149, 80);
            this.bbCfgPedido.Name = "bbCfgPedido";
            this.bbCfgPedido.Size = new System.Drawing.Size(30, 20);
            this.bbCfgPedido.TabIndex = 9;
            this.bbCfgPedido.UseVisualStyleBackColor = true;
            this.bbCfgPedido.Click += new System.EventHandler(this.bbCfgPedido_Click);
            // 
            // cfg_pedido
            // 
            this.cfg_pedido.BackColor = System.Drawing.SystemColors.Window;
            this.cfg_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cfg_pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cfg_pedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgVendasExterna, "Cfg_pedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cfg_pedido.Location = new System.Drawing.Point(75, 81);
            this.cfg_pedido.Name = "cfg_pedido";
            this.cfg_pedido.NM_Alias = "";
            this.cfg_pedido.NM_Campo = "cfg_pedido";
            this.cfg_pedido.NM_CampoBusca = "cfg_pedido";
            this.cfg_pedido.NM_Param = "@P_CD_EMPRESA";
            this.cfg_pedido.QTD_Zero = 0;
            this.cfg_pedido.Size = new System.Drawing.Size(73, 20);
            this.cfg_pedido.ST_AutoInc = false;
            this.cfg_pedido.ST_DisableAuto = false;
            this.cfg_pedido.ST_Float = false;
            this.cfg_pedido.ST_Gravar = true;
            this.cfg_pedido.ST_Int = false;
            this.cfg_pedido.ST_LimpaCampo = true;
            this.cfg_pedido.ST_NotNull = false;
            this.cfg_pedido.ST_PrimaryKey = false;
            this.cfg_pedido.TabIndex = 8;
            this.cfg_pedido.TextOld = null;
            this.cfg_pedido.Leave += new System.EventHandler(this.cfg_pedido_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(3, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 157;
            this.label11.Text = "Ped. Venda:";
            // 
            // TFConfigVendasExterna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 384);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFConfigVendasExterna";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Vendas Externa";
            this.Load += new System.EventHandler(this.TFConfigVendasExterna_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFConfigVendasExterna_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgVendasExterna)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault senha;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault login;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bbIntegracao;
        private System.Windows.Forms.Button bbLicenca;
        private Componentes.EditDefault Integracao;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault licenca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bsCfgVendasExterna;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.EditDefault ds_config;
        private System.Windows.Forms.Button bb_config;
        private Componentes.EditDefault id_config;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault ds_historico;
        private System.Windows.Forms.Button bbHistorico;
        private Componentes.EditDefault cd_historico;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault ds_condpgto;
        private System.Windows.Forms.Button bb_condpgto;
        private Componentes.EditDefault cd_condpgto;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault ds_tpdocto;
        private System.Windows.Forms.Button bb_tpdocto;
        private Componentes.EditDefault tp_docto;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault ds_tpduplicata;
        private System.Windows.Forms.Button bb_tpduplicata;
        private Componentes.EditDefault tp_duplicata;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault ds_tipopedido;
        private System.Windows.Forms.Button bbCfgPedido;
        private Componentes.EditDefault cfg_pedido;
        private System.Windows.Forms.Label label11;
    }
}