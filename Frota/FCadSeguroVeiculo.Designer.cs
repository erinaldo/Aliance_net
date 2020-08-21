namespace Frota
{
    partial class TFCadSeguroVeiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadSeguroVeiculo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpSeguro = new System.Windows.Forms.TableLayoutPanel();
            this.pDadosSeguro = new Componentes.PanelDados(this.components);
            this.placa = new Componentes.EditDefault(this.components);
            this.bsSeguros = new System.Windows.Forms.BindingSource(this.components);
            this.bb_veiculo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.ds_veiculo = new Componentes.EditDefault(this.components);
            this.id_veiculo = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vl_franquia = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.vl_seguro = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.nm_corretora = new Componentes.EditDefault(this.components);
            this.bb_seguradora = new System.Windows.Forms.Button();
            this.bb_corretora = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_ini_vigencia = new Componentes.EditData(this.components);
            this.dt_fin_vigencia = new Componentes.EditData(this.components);
            this.nm_seguradora = new Componentes.EditDefault(this.components);
            this.cd_seguradora = new Componentes.EditDefault(this.components);
            this.cd_corretora = new Componentes.EditDefault(this.components);
            this.cd_ci = new Componentes.EditDefault(this.components);
            this.cd_apolice = new Componentes.EditDefault(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.dspremioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlpremioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPremios = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.TS_ItensPedido = new System.Windows.Forms.ToolStrip();
            this.btn_InserirSeguros_Item = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar_Premios = new System.Windows.Forms.ToolStripButton();
            this.btn_DeletaSeguros_Item = new System.Windows.Forms.ToolStripButton();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpSeguro.SuspendLayout();
            this.pDadosSeguro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSeguros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_franquia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_seguro)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPremios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.TS_ItensPedido.SuspendLayout();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSeguro
            // 
            this.tlpSeguro.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpSeguro.ColumnCount = 1;
            this.tlpSeguro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSeguro.Controls.Add(this.pDadosSeguro, 0, 0);
            this.tlpSeguro.Controls.Add(this.panelDados1, 0, 1);
            this.tlpSeguro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSeguro.Location = new System.Drawing.Point(0, 43);
            this.tlpSeguro.Name = "tlpSeguro";
            this.tlpSeguro.RowCount = 2;
            this.tlpSeguro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tlpSeguro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSeguro.Size = new System.Drawing.Size(628, 427);
            this.tlpSeguro.TabIndex = 1;
            // 
            // pDadosSeguro
            // 
            this.pDadosSeguro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDadosSeguro.Controls.Add(this.placa);
            this.pDadosSeguro.Controls.Add(this.bb_veiculo);
            this.pDadosSeguro.Controls.Add(this.label9);
            this.pDadosSeguro.Controls.Add(this.ds_veiculo);
            this.pDadosSeguro.Controls.Add(this.id_veiculo);
            this.pDadosSeguro.Controls.Add(this.label3);
            this.pDadosSeguro.Controls.Add(this.vl_franquia);
            this.pDadosSeguro.Controls.Add(this.label8);
            this.pDadosSeguro.Controls.Add(this.vl_seguro);
            this.pDadosSeguro.Controls.Add(this.label7);
            this.pDadosSeguro.Controls.Add(this.nm_corretora);
            this.pDadosSeguro.Controls.Add(this.bb_seguradora);
            this.pDadosSeguro.Controls.Add(this.bb_corretora);
            this.pDadosSeguro.Controls.Add(this.label5);
            this.pDadosSeguro.Controls.Add(this.label4);
            this.pDadosSeguro.Controls.Add(this.label6);
            this.pDadosSeguro.Controls.Add(this.label2);
            this.pDadosSeguro.Controls.Add(this.label1);
            this.pDadosSeguro.Controls.Add(this.dt_ini_vigencia);
            this.pDadosSeguro.Controls.Add(this.dt_fin_vigencia);
            this.pDadosSeguro.Controls.Add(this.nm_seguradora);
            this.pDadosSeguro.Controls.Add(this.cd_seguradora);
            this.pDadosSeguro.Controls.Add(this.cd_corretora);
            this.pDadosSeguro.Controls.Add(this.cd_ci);
            this.pDadosSeguro.Controls.Add(this.cd_apolice);
            this.pDadosSeguro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDadosSeguro.Location = new System.Drawing.Point(5, 5);
            this.pDadosSeguro.Name = "pDadosSeguro";
            this.pDadosSeguro.NM_ProcDeletar = "";
            this.pDadosSeguro.NM_ProcGravar = "";
            this.pDadosSeguro.Size = new System.Drawing.Size(618, 136);
            this.pDadosSeguro.TabIndex = 0;
            // 
            // placa
            // 
            this.placa.BackColor = System.Drawing.SystemColors.Window;
            this.placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.placa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguros, "Placa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.placa.Enabled = false;
            this.placa.Location = new System.Drawing.Point(544, 4);
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "placa";
            this.placa.NM_CampoBusca = "placa";
            this.placa.NM_Param = "@P_NM_CLIFOR";
            this.placa.QTD_Zero = 0;
            this.placa.Size = new System.Drawing.Size(68, 20);
            this.placa.ST_AutoInc = false;
            this.placa.ST_DisableAuto = false;
            this.placa.ST_Float = false;
            this.placa.ST_Gravar = false;
            this.placa.ST_Int = false;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = false;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 81;
            // 
            // bsSeguros
            // 
            this.bsSeguros.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_CadSeguroVeiculo);
            // 
            // bb_veiculo
            // 
            this.bb_veiculo.Image = ((System.Drawing.Image)(resources.GetObject("bb_veiculo.Image")));
            this.bb_veiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_veiculo.Location = new System.Drawing.Point(160, 4);
            this.bb_veiculo.Name = "bb_veiculo";
            this.bb_veiculo.Size = new System.Drawing.Size(28, 19);
            this.bb_veiculo.TabIndex = 1;
            this.bb_veiculo.UseVisualStyleBackColor = true;
            this.bb_veiculo.Click += new System.EventHandler(this.bb_veiculo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 80;
            this.label9.Text = "Veiculo:";
            // 
            // ds_veiculo
            // 
            this.ds_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguros, "Ds_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_veiculo.Enabled = false;
            this.ds_veiculo.Location = new System.Drawing.Point(194, 4);
            this.ds_veiculo.Name = "ds_veiculo";
            this.ds_veiculo.NM_Alias = "";
            this.ds_veiculo.NM_Campo = "ds_veiculo";
            this.ds_veiculo.NM_CampoBusca = "ds_veiculo";
            this.ds_veiculo.NM_Param = "@P_NM_CLIFOR";
            this.ds_veiculo.QTD_Zero = 0;
            this.ds_veiculo.Size = new System.Drawing.Size(347, 20);
            this.ds_veiculo.ST_AutoInc = false;
            this.ds_veiculo.ST_DisableAuto = false;
            this.ds_veiculo.ST_Float = false;
            this.ds_veiculo.ST_Gravar = false;
            this.ds_veiculo.ST_Int = false;
            this.ds_veiculo.ST_LimpaCampo = true;
            this.ds_veiculo.ST_NotNull = false;
            this.ds_veiculo.ST_PrimaryKey = false;
            this.ds_veiculo.TabIndex = 79;
            // 
            // id_veiculo
            // 
            this.id_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.id_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguros, "Id_veiculostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_veiculo.Location = new System.Drawing.Point(88, 3);
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.NM_Alias = "";
            this.id_veiculo.NM_Campo = "id_veiculo";
            this.id_veiculo.NM_CampoBusca = "id_veiculo";
            this.id_veiculo.NM_Param = "@P_CD_CLIFOR";
            this.id_veiculo.QTD_Zero = 0;
            this.id_veiculo.Size = new System.Drawing.Size(67, 20);
            this.id_veiculo.ST_AutoInc = false;
            this.id_veiculo.ST_DisableAuto = false;
            this.id_veiculo.ST_Float = false;
            this.id_veiculo.ST_Gravar = true;
            this.id_veiculo.ST_Int = true;
            this.id_veiculo.ST_LimpaCampo = true;
            this.id_veiculo.ST_NotNull = true;
            this.id_veiculo.ST_PrimaryKey = false;
            this.id_veiculo.TabIndex = 0;
            this.id_veiculo.Leave += new System.EventHandler(this.id_veiculo_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(468, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "Vl. Franquia:";
            // 
            // vl_franquia
            // 
            this.vl_franquia.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsSeguros, "Vl_franquia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_franquia.DecimalPlaces = 2;
            this.vl_franquia.Location = new System.Drawing.Point(536, 110);
            this.vl_franquia.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.vl_franquia.Name = "vl_franquia";
            this.vl_franquia.NM_Alias = "";
            this.vl_franquia.NM_Campo = "";
            this.vl_franquia.NM_Param = "";
            this.vl_franquia.Operador = "";
            this.vl_franquia.Size = new System.Drawing.Size(76, 20);
            this.vl_franquia.ST_AutoInc = false;
            this.vl_franquia.ST_DisableAuto = false;
            this.vl_franquia.ST_Gravar = false;
            this.vl_franquia.ST_LimparCampo = true;
            this.vl_franquia.ST_NotNull = false;
            this.vl_franquia.ST_PrimaryKey = false;
            this.vl_franquia.TabIndex = 11;
            this.vl_franquia.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(318, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Vl. Seguro:";
            // 
            // vl_seguro
            // 
            this.vl_seguro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsSeguros, "Vl_seguro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_seguro.DecimalPlaces = 2;
            this.vl_seguro.Location = new System.Drawing.Point(380, 109);
            this.vl_seguro.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.vl_seguro.Name = "vl_seguro";
            this.vl_seguro.NM_Alias = "";
            this.vl_seguro.NM_Campo = "";
            this.vl_seguro.NM_Param = "";
            this.vl_seguro.Operador = "";
            this.vl_seguro.Size = new System.Drawing.Size(82, 20);
            this.vl_seguro.ST_AutoInc = false;
            this.vl_seguro.ST_DisableAuto = false;
            this.vl_seguro.ST_Gravar = false;
            this.vl_seguro.ST_LimparCampo = true;
            this.vl_seguro.ST_NotNull = true;
            this.vl_seguro.ST_PrimaryKey = false;
            this.vl_seguro.TabIndex = 10;
            this.vl_seguro.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "Dt.Fin.Vigencia:";
            // 
            // nm_corretora
            // 
            this.nm_corretora.BackColor = System.Drawing.SystemColors.Window;
            this.nm_corretora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_corretora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_corretora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguros, "Nm_corretora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_corretora.Enabled = false;
            this.nm_corretora.Location = new System.Drawing.Point(228, 81);
            this.nm_corretora.Name = "nm_corretora";
            this.nm_corretora.NM_Alias = "";
            this.nm_corretora.NM_Campo = "nm_clifor";
            this.nm_corretora.NM_CampoBusca = "nm_clifor";
            this.nm_corretora.NM_Param = "@P_NM_CLIFOR";
            this.nm_corretora.QTD_Zero = 0;
            this.nm_corretora.Size = new System.Drawing.Size(384, 20);
            this.nm_corretora.ST_AutoInc = false;
            this.nm_corretora.ST_DisableAuto = false;
            this.nm_corretora.ST_Float = false;
            this.nm_corretora.ST_Gravar = false;
            this.nm_corretora.ST_Int = false;
            this.nm_corretora.ST_LimpaCampo = true;
            this.nm_corretora.ST_NotNull = false;
            this.nm_corretora.ST_PrimaryKey = false;
            this.nm_corretora.TabIndex = 7;
            // 
            // bb_seguradora
            // 
            this.bb_seguradora.Image = ((System.Drawing.Image)(resources.GetObject("bb_seguradora.Image")));
            this.bb_seguradora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_seguradora.Location = new System.Drawing.Point(194, 56);
            this.bb_seguradora.Name = "bb_seguradora";
            this.bb_seguradora.Size = new System.Drawing.Size(28, 19);
            this.bb_seguradora.TabIndex = 5;
            this.bb_seguradora.UseVisualStyleBackColor = true;
            this.bb_seguradora.Click += new System.EventHandler(this.bb_seguradora_Click);
            // 
            // bb_corretora
            // 
            this.bb_corretora.Image = ((System.Drawing.Image)(resources.GetObject("bb_corretora.Image")));
            this.bb_corretora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_corretora.Location = new System.Drawing.Point(194, 82);
            this.bb_corretora.Name = "bb_corretora";
            this.bb_corretora.Size = new System.Drawing.Size(28, 19);
            this.bb_corretora.TabIndex = 7;
            this.bb_corretora.UseVisualStyleBackColor = true;
            this.bb_corretora.Click += new System.EventHandler(this.bb_corretora_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Seguradora:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Corretora:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Apolice:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Dt.Ini.Vigencia:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "CI:";
            // 
            // dt_ini_vigencia
            // 
            this.dt_ini_vigencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini_vigencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguros, "Dt_ini_vigenciastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_ini_vigencia.Location = new System.Drawing.Point(88, 107);
            this.dt_ini_vigencia.Mask = "00/00/0000";
            this.dt_ini_vigencia.Name = "dt_ini_vigencia";
            this.dt_ini_vigencia.NM_Alias = "";
            this.dt_ini_vigencia.NM_Campo = "";
            this.dt_ini_vigencia.NM_CampoBusca = "";
            this.dt_ini_vigencia.NM_Param = "";
            this.dt_ini_vigencia.Operador = "";
            this.dt_ini_vigencia.Size = new System.Drawing.Size(67, 20);
            this.dt_ini_vigencia.ST_Gravar = false;
            this.dt_ini_vigencia.ST_LimpaCampo = true;
            this.dt_ini_vigencia.ST_NotNull = true;
            this.dt_ini_vigencia.ST_PrimaryKey = false;
            this.dt_ini_vigencia.TabIndex = 8;
            // 
            // dt_fin_vigencia
            // 
            this.dt_fin_vigencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin_vigencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguros, "Dt_fin_vigenciastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_fin_vigencia.Location = new System.Drawing.Point(246, 109);
            this.dt_fin_vigencia.Mask = "00/00/0000";
            this.dt_fin_vigencia.Name = "dt_fin_vigencia";
            this.dt_fin_vigencia.NM_Alias = "";
            this.dt_fin_vigencia.NM_Campo = "";
            this.dt_fin_vigencia.NM_CampoBusca = "";
            this.dt_fin_vigencia.NM_Param = "";
            this.dt_fin_vigencia.Operador = "";
            this.dt_fin_vigencia.Size = new System.Drawing.Size(66, 20);
            this.dt_fin_vigencia.ST_Gravar = false;
            this.dt_fin_vigencia.ST_LimpaCampo = true;
            this.dt_fin_vigencia.ST_NotNull = true;
            this.dt_fin_vigencia.ST_PrimaryKey = false;
            this.dt_fin_vigencia.TabIndex = 9;
            // 
            // nm_seguradora
            // 
            this.nm_seguradora.BackColor = System.Drawing.SystemColors.Window;
            this.nm_seguradora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_seguradora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_seguradora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguros, "Nm_seguradora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_seguradora.Enabled = false;
            this.nm_seguradora.Location = new System.Drawing.Point(228, 56);
            this.nm_seguradora.Name = "nm_seguradora";
            this.nm_seguradora.NM_Alias = "";
            this.nm_seguradora.NM_Campo = "nm_clifor";
            this.nm_seguradora.NM_CampoBusca = "nm_clifor";
            this.nm_seguradora.NM_Param = "@P_NM_CLIFOR";
            this.nm_seguradora.QTD_Zero = 0;
            this.nm_seguradora.Size = new System.Drawing.Size(384, 20);
            this.nm_seguradora.ST_AutoInc = false;
            this.nm_seguradora.ST_DisableAuto = false;
            this.nm_seguradora.ST_Float = false;
            this.nm_seguradora.ST_Gravar = false;
            this.nm_seguradora.ST_Int = false;
            this.nm_seguradora.ST_LimpaCampo = true;
            this.nm_seguradora.ST_NotNull = false;
            this.nm_seguradora.ST_PrimaryKey = false;
            this.nm_seguradora.TabIndex = 4;
            // 
            // cd_seguradora
            // 
            this.cd_seguradora.BackColor = System.Drawing.SystemColors.Window;
            this.cd_seguradora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_seguradora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_seguradora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguros, "Cd_seguradora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_seguradora.Location = new System.Drawing.Point(88, 55);
            this.cd_seguradora.Name = "cd_seguradora";
            this.cd_seguradora.NM_Alias = "";
            this.cd_seguradora.NM_Campo = "cd_clifor";
            this.cd_seguradora.NM_CampoBusca = "cd_clifor";
            this.cd_seguradora.NM_Param = "@P_CD_CLIFOR";
            this.cd_seguradora.QTD_Zero = 0;
            this.cd_seguradora.Size = new System.Drawing.Size(100, 20);
            this.cd_seguradora.ST_AutoInc = false;
            this.cd_seguradora.ST_DisableAuto = false;
            this.cd_seguradora.ST_Float = false;
            this.cd_seguradora.ST_Gravar = true;
            this.cd_seguradora.ST_Int = true;
            this.cd_seguradora.ST_LimpaCampo = true;
            this.cd_seguradora.ST_NotNull = false;
            this.cd_seguradora.ST_PrimaryKey = false;
            this.cd_seguradora.TabIndex = 4;
            this.cd_seguradora.Leave += new System.EventHandler(this.cd_seguradora_Leave);
            // 
            // cd_corretora
            // 
            this.cd_corretora.BackColor = System.Drawing.SystemColors.Window;
            this.cd_corretora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_corretora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_corretora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguros, "Cd_corretora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_corretora.Location = new System.Drawing.Point(88, 81);
            this.cd_corretora.Name = "cd_corretora";
            this.cd_corretora.NM_Alias = "";
            this.cd_corretora.NM_Campo = "cd_clifor";
            this.cd_corretora.NM_CampoBusca = "cd_clifor";
            this.cd_corretora.NM_Param = "@P_CD_CLIFOR";
            this.cd_corretora.QTD_Zero = 0;
            this.cd_corretora.Size = new System.Drawing.Size(100, 20);
            this.cd_corretora.ST_AutoInc = false;
            this.cd_corretora.ST_DisableAuto = false;
            this.cd_corretora.ST_Float = false;
            this.cd_corretora.ST_Gravar = true;
            this.cd_corretora.ST_Int = true;
            this.cd_corretora.ST_LimpaCampo = true;
            this.cd_corretora.ST_NotNull = false;
            this.cd_corretora.ST_PrimaryKey = false;
            this.cd_corretora.TabIndex = 6;
            this.cd_corretora.Leave += new System.EventHandler(this.cd_corretora_Leave);
            // 
            // cd_ci
            // 
            this.cd_ci.BackColor = System.Drawing.SystemColors.Window;
            this.cd_ci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_ci.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_ci.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguros, "Cd_ci", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_ci.Location = new System.Drawing.Point(228, 29);
            this.cd_ci.Name = "cd_ci";
            this.cd_ci.NM_Alias = "";
            this.cd_ci.NM_Campo = "";
            this.cd_ci.NM_CampoBusca = "";
            this.cd_ci.NM_Param = "";
            this.cd_ci.QTD_Zero = 0;
            this.cd_ci.Size = new System.Drawing.Size(100, 20);
            this.cd_ci.ST_AutoInc = false;
            this.cd_ci.ST_DisableAuto = false;
            this.cd_ci.ST_Float = false;
            this.cd_ci.ST_Gravar = false;
            this.cd_ci.ST_Int = false;
            this.cd_ci.ST_LimpaCampo = true;
            this.cd_ci.ST_NotNull = false;
            this.cd_ci.ST_PrimaryKey = false;
            this.cd_ci.TabIndex = 3;
            // 
            // cd_apolice
            // 
            this.cd_apolice.BackColor = System.Drawing.SystemColors.Window;
            this.cd_apolice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_apolice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_apolice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguros, "Cd_apolice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_apolice.Location = new System.Drawing.Point(88, 29);
            this.cd_apolice.Name = "cd_apolice";
            this.cd_apolice.NM_Alias = "";
            this.cd_apolice.NM_Campo = "";
            this.cd_apolice.NM_CampoBusca = "";
            this.cd_apolice.NM_Param = "";
            this.cd_apolice.QTD_Zero = 0;
            this.cd_apolice.Size = new System.Drawing.Size(97, 20);
            this.cd_apolice.ST_AutoInc = false;
            this.cd_apolice.ST_DisableAuto = false;
            this.cd_apolice.ST_Float = false;
            this.cd_apolice.ST_Gravar = false;
            this.cd_apolice.ST_Int = false;
            this.cd_apolice.ST_LimpaCampo = true;
            this.cd_apolice.ST_NotNull = false;
            this.cd_apolice.ST_PrimaryKey = false;
            this.cd_apolice.TabIndex = 2;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.dataGridDefault1);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Controls.Add(this.TS_ItensPedido);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 149);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(618, 273);
            this.panelDados1.TabIndex = 1;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dspremioDataGridViewTextBoxColumn,
            this.vlpremioDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsPremios;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 25);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(614, 219);
            this.dataGridDefault1.TabIndex = 7;
            // 
            // dspremioDataGridViewTextBoxColumn
            // 
            this.dspremioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dspremioDataGridViewTextBoxColumn.DataPropertyName = "Ds_premio";
            this.dspremioDataGridViewTextBoxColumn.HeaderText = "Descrição Premio";
            this.dspremioDataGridViewTextBoxColumn.Name = "dspremioDataGridViewTextBoxColumn";
            this.dspremioDataGridViewTextBoxColumn.ReadOnly = true;
            this.dspremioDataGridViewTextBoxColumn.Width = 106;
            // 
            // vlpremioDataGridViewTextBoxColumn
            // 
            this.vlpremioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlpremioDataGridViewTextBoxColumn.DataPropertyName = "Vl_premio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.vlpremioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.vlpremioDataGridViewTextBoxColumn.HeaderText = "Valor Premio";
            this.vlpremioDataGridViewTextBoxColumn.Name = "vlpremioDataGridViewTextBoxColumn";
            this.vlpremioDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlpremioDataGridViewTextBoxColumn.Width = 84;
            // 
            // bsPremios
            // 
            this.bsPremios.DataMember = "lPremios";
            this.bsPremios.DataSource = this.bsSeguros;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsPremios;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 244);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(614, 25);
            this.bindingNavigator1.TabIndex = 8;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // TS_ItensPedido
            // 
            this.TS_ItensPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_InserirSeguros_Item,
            this.BB_Alterar_Premios,
            this.btn_DeletaSeguros_Item});
            this.TS_ItensPedido.Location = new System.Drawing.Point(0, 0);
            this.TS_ItensPedido.Name = "TS_ItensPedido";
            this.TS_ItensPedido.Size = new System.Drawing.Size(614, 25);
            this.TS_ItensPedido.TabIndex = 6;
            // 
            // btn_InserirSeguros_Item
            // 
            this.btn_InserirSeguros_Item.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_InserirSeguros_Item.Image = ((System.Drawing.Image)(resources.GetObject("btn_InserirSeguros_Item.Image")));
            this.btn_InserirSeguros_Item.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_InserirSeguros_Item.Name = "btn_InserirSeguros_Item";
            this.btn_InserirSeguros_Item.Size = new System.Drawing.Size(138, 22);
            this.btn_InserirSeguros_Item.Text = "(CTRL + F10)Inserir";
            this.btn_InserirSeguros_Item.ToolTipText = "Inserir Novo Item Pedido";
            this.btn_InserirSeguros_Item.Click += new System.EventHandler(this.btn_InserirSeguros_Item_Click);
            // 
            // BB_Alterar_Premios
            // 
            this.BB_Alterar_Premios.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Alterar_Premios.Image = ((System.Drawing.Image)(resources.GetObject("BB_Alterar_Premios.Image")));
            this.BB_Alterar_Premios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Alterar_Premios.Name = "BB_Alterar_Premios";
            this.BB_Alterar_Premios.Size = new System.Drawing.Size(140, 22);
            this.BB_Alterar_Premios.Text = "(CTRL + F11)Alterar";
            this.BB_Alterar_Premios.ToolTipText = "Alterar Premios";
            this.BB_Alterar_Premios.Click += new System.EventHandler(this.BB_Alterar_Premios_Click);
            // 
            // btn_DeletaSeguros_Item
            // 
            this.btn_DeletaSeguros_Item.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_DeletaSeguros_Item.Image = ((System.Drawing.Image)(resources.GetObject("btn_DeletaSeguros_Item.Image")));
            this.btn_DeletaSeguros_Item.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_DeletaSeguros_Item.Name = "btn_DeletaSeguros_Item";
            this.btn_DeletaSeguros_Item.Size = new System.Drawing.Size(137, 22);
            this.btn_DeletaSeguros_Item.Text = "(CTRL + F12)Excluir";
            this.btn_DeletaSeguros_Item.ToolTipText = "Excluir Item Pedido";
            this.btn_DeletaSeguros_Item.Click += new System.EventHandler(this.btn_DeletaSeguros_Item_Click);
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(628, 43);
            this.barraMenu.TabIndex = 5;
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
            // TFCadSeguroVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 470);
            this.Controls.Add(this.tlpSeguro);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCadSeguroVeiculo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro - Seguro Veiculo";
            this.Load += new System.EventHandler(this.TFCadSeguroVeiculo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCadSeguroVeiculo_KeyDown);
            this.tlpSeguro.ResumeLayout(false);
            this.pDadosSeguro.ResumeLayout(false);
            this.pDadosSeguro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSeguros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_franquia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_seguro)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPremios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.TS_ItensPedido.ResumeLayout(false);
            this.TS_ItensPedido.PerformLayout();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSeguro;
        private Componentes.PanelDados pDadosSeguro;
        private Componentes.EditData dt_ini_vigencia;
        private Componentes.EditData dt_fin_vigencia;
        private Componentes.EditDefault nm_seguradora;
        private Componentes.EditDefault cd_seguradora;
        private Componentes.EditDefault cd_corretora;
        private Componentes.EditDefault cd_ci;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault cd_apolice;
        private Componentes.EditDefault nm_corretora;
        private System.Windows.Forms.Button bb_seguradora;
        private System.Windows.Forms.Button bb_corretora;
        private System.Windows.Forms.Label label8;
        private Componentes.EditFloat vl_seguro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource bsSeguros;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat vl_franquia;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsPremios;
        private System.Windows.Forms.ToolStrip TS_ItensPedido;
        private System.Windows.Forms.ToolStripButton btn_InserirSeguros_Item;
        private System.Windows.Forms.ToolStripButton btn_DeletaSeguros_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn dspremioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlpremioDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton BB_Alterar_Premios;
        private System.Windows.Forms.Button bb_veiculo;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault ds_veiculo;
        private Componentes.EditDefault id_veiculo;
        private Componentes.EditDefault placa;
    }
}