namespace Financeiro
{
    partial class TFAnaliseCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAnaliseCredito));
            this.bsClifor = new System.Windows.Forms.BindingSource(this.components);
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pClifor = new Componentes.PanelDados(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.vl_limitecredCH = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.radioGroup3 = new Componentes.RadioGroup(this.components);
            this.st_bloqueioSPC = new Componentes.CheckBoxDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ds_consultaSPC = new Componentes.EditDefault(this.components);
            this.dt_consulaSPC = new Componentes.EditData(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.ds_motivobloqueio = new Componentes.EditDefault(this.components);
            this.st_bloqcreditoavulso = new Componentes.CheckBoxDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.diascarenciadebvencto = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.st_bloq_debitovencido = new Componentes.CheckBoxDefault(this.components);
            this.vl_limitecredito = new Componentes.EditFloat(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.radioGroup2 = new Componentes.RadioGroup(this.components);
            this.ID_RamoAtividade = new Componentes.EditDefault(this.components);
            this.LB_DS_RamoAtividade = new System.Windows.Forms.Label();
            this.DS_RamoAtividade = new Componentes.EditDefault(this.components);
            this.lbvlrenda = new System.Windows.Forms.Label();
            this.vl_renda = new Componentes.EditFloat(this.components);
            this.ds_cargo = new Componentes.EditDefault(this.components);
            this.lbcargo = new System.Windows.Forms.Label();
            this.nm_localtrabalho = new Componentes.EditDefault(this.components);
            this.lbLocaltrab = new System.Windows.Forms.Label();
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bsClifor)).BeginInit();
            this.tlpCentral.SuspendLayout();
            this.pClifor.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_limitecredCH)).BeginInit();
            this.radioGroup3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diascarenciadebvencto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_limitecredito)).BeginInit();
            this.radioGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_renda)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsClifor
            // 
            this.bsClifor.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadClifor);
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Controls.Add(this.pClifor, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.74172F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 393F));
            this.tlpCentral.Size = new System.Drawing.Size(904, 393);
            this.tlpCentral.TabIndex = 0;
            // 
            // pClifor
            // 
            this.pClifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pClifor.Controls.Add(this.radioGroup1);
            this.pClifor.Controls.Add(this.radioGroup2);
            this.pClifor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pClifor.Location = new System.Drawing.Point(3, 3);
            this.pClifor.Name = "pClifor";
            this.pClifor.NM_ProcDeletar = "";
            this.pClifor.NM_ProcGravar = "";
            this.pClifor.Size = new System.Drawing.Size(898, 387);
            this.pClifor.TabIndex = 0;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.vl_limitecredCH);
            this.radioGroup1.Controls.Add(this.label8);
            this.radioGroup1.Controls.Add(this.radioGroup3);
            this.radioGroup1.Controls.Add(this.label19);
            this.radioGroup1.Controls.Add(this.ds_motivobloqueio);
            this.radioGroup1.Controls.Add(this.st_bloqcreditoavulso);
            this.radioGroup1.Controls.Add(this.label9);
            this.radioGroup1.Controls.Add(this.diascarenciadebvencto);
            this.radioGroup1.Controls.Add(this.label6);
            this.radioGroup1.Controls.Add(this.st_bloq_debitovencido);
            this.radioGroup1.Controls.Add(this.vl_limitecredito);
            this.radioGroup1.Controls.Add(this.label10);
            this.radioGroup1.Location = new System.Drawing.Point(8, 142);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(879, 236);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 191;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "DADOS CRÉDITO";
            // 
            // vl_limitecredCH
            // 
            this.vl_limitecredCH.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsClifor, "Vl_limitecredCH", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_limitecredCH.DecimalPlaces = 2;
            this.vl_limitecredCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.vl_limitecredCH.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_limitecredCH.Location = new System.Drawing.Point(322, 29);
            this.vl_limitecredCH.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.vl_limitecredCH.Name = "vl_limitecredCH";
            this.vl_limitecredCH.NM_Alias = "a";
            this.vl_limitecredCH.NM_Campo = "VL_LIMITETOTAL";
            this.vl_limitecredCH.NM_Param = "@P_VL_LIMITETOTAL";
            this.vl_limitecredCH.Operador = "";
            this.vl_limitecredCH.Size = new System.Drawing.Size(85, 20);
            this.vl_limitecredCH.ST_AutoInc = false;
            this.vl_limitecredCH.ST_DisableAuto = false;
            this.vl_limitecredCH.ST_Gravar = true;
            this.vl_limitecredCH.ST_LimparCampo = true;
            this.vl_limitecredCH.ST_NotNull = true;
            this.vl_limitecredCH.ST_PrimaryKey = false;
            this.vl_limitecredCH.TabIndex = 191;
            this.vl_limitecredCH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vl_limitecredCH.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(225, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 201;
            this.label8.Text = "Limite Credito CH:";
            // 
            // radioGroup3
            // 
            this.radioGroup3.Controls.Add(this.st_bloqueioSPC);
            this.radioGroup3.Controls.Add(this.label7);
            this.radioGroup3.Controls.Add(this.label5);
            this.radioGroup3.Controls.Add(this.ds_consultaSPC);
            this.radioGroup3.Controls.Add(this.dt_consulaSPC);
            this.radioGroup3.Location = new System.Drawing.Point(438, 13);
            this.radioGroup3.Name = "radioGroup3";
            this.radioGroup3.NM_Alias = "";
            this.radioGroup3.NM_Campo = "";
            this.radioGroup3.NM_Param = "";
            this.radioGroup3.NM_Valor = "";
            this.radioGroup3.Size = new System.Drawing.Size(435, 85);
            this.radioGroup3.ST_Gravar = false;
            this.radioGroup3.ST_NotNull = false;
            this.radioGroup3.TabIndex = 200;
            this.radioGroup3.TabStop = false;
            this.radioGroup3.Text = "Consulta SPC";
            // 
            // st_bloqueioSPC
            // 
            this.st_bloqueioSPC.AutoSize = true;
            this.st_bloqueioSPC.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsClifor, "St_bloqueiospcbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_bloqueioSPC.Location = new System.Drawing.Point(352, 47);
            this.st_bloqueioSPC.Name = "st_bloqueioSPC";
            this.st_bloqueioSPC.NM_Alias = "";
            this.st_bloqueioSPC.NM_Campo = "";
            this.st_bloqueioSPC.NM_Param = "";
            this.st_bloqueioSPC.Size = new System.Drawing.Size(77, 17);
            this.st_bloqueioSPC.ST_Gravar = false;
            this.st_bloqueioSPC.ST_LimparCampo = true;
            this.st_bloqueioSPC.ST_NotNull = false;
            this.st_bloqueioSPC.TabIndex = 2;
            this.st_bloqueioSPC.Text = "Bloqueado";
            this.st_bloqueioSPC.UseVisualStyleBackColor = true;
            this.st_bloqueioSPC.Vl_False = "";
            this.st_bloqueioSPC.Vl_True = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(26, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 177;
            this.label7.Text = "Data:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(3, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 176;
            this.label5.Text = "Descrição:";
            // 
            // ds_consultaSPC
            // 
            this.ds_consultaSPC.BackColor = System.Drawing.SystemColors.Window;
            this.ds_consultaSPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_consultaSPC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_consultaSPC.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClifor, "Ds_ConsultaSPC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_consultaSPC.Location = new System.Drawing.Point(65, 18);
            this.ds_consultaSPC.Name = "ds_consultaSPC";
            this.ds_consultaSPC.NM_Alias = "";
            this.ds_consultaSPC.NM_Campo = "";
            this.ds_consultaSPC.NM_CampoBusca = "";
            this.ds_consultaSPC.NM_Param = "";
            this.ds_consultaSPC.QTD_Zero = 0;
            this.ds_consultaSPC.Size = new System.Drawing.Size(364, 20);
            this.ds_consultaSPC.ST_AutoInc = false;
            this.ds_consultaSPC.ST_DisableAuto = false;
            this.ds_consultaSPC.ST_Float = false;
            this.ds_consultaSPC.ST_Gravar = false;
            this.ds_consultaSPC.ST_Int = false;
            this.ds_consultaSPC.ST_LimpaCampo = true;
            this.ds_consultaSPC.ST_NotNull = false;
            this.ds_consultaSPC.ST_PrimaryKey = false;
            this.ds_consultaSPC.TabIndex = 0;
            this.ds_consultaSPC.TextOld = null;
            // 
            // dt_consulaSPC
            // 
            this.dt_consulaSPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_consulaSPC.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClifor, "Dt_consultaSPCstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_consulaSPC.Location = new System.Drawing.Point(65, 44);
            this.dt_consulaSPC.Mask = "00/00/0000";
            this.dt_consulaSPC.Name = "dt_consulaSPC";
            this.dt_consulaSPC.NM_Alias = "";
            this.dt_consulaSPC.NM_Campo = "";
            this.dt_consulaSPC.NM_CampoBusca = "";
            this.dt_consulaSPC.NM_Param = "";
            this.dt_consulaSPC.Operador = "";
            this.dt_consulaSPC.Size = new System.Drawing.Size(100, 20);
            this.dt_consulaSPC.ST_Gravar = false;
            this.dt_consulaSPC.ST_LimpaCampo = true;
            this.dt_consulaSPC.ST_NotNull = false;
            this.dt_consulaSPC.ST_PrimaryKey = false;
            this.dt_consulaSPC.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(13, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 13);
            this.label19.TabIndex = 199;
            this.label19.Text = "Motivo Bloqueio:";
            // 
            // ds_motivobloqueio
            // 
            this.ds_motivobloqueio.BackColor = System.Drawing.SystemColors.Window;
            this.ds_motivobloqueio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_motivobloqueio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_motivobloqueio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClifor, "Ds_motivobloqavulso", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_motivobloqueio.Location = new System.Drawing.Point(105, 102);
            this.ds_motivobloqueio.Multiline = true;
            this.ds_motivobloqueio.Name = "ds_motivobloqueio";
            this.ds_motivobloqueio.NM_Alias = "";
            this.ds_motivobloqueio.NM_Campo = "";
            this.ds_motivobloqueio.NM_CampoBusca = "";
            this.ds_motivobloqueio.NM_Param = "";
            this.ds_motivobloqueio.QTD_Zero = 0;
            this.ds_motivobloqueio.Size = new System.Drawing.Size(762, 127);
            this.ds_motivobloqueio.ST_AutoInc = false;
            this.ds_motivobloqueio.ST_DisableAuto = false;
            this.ds_motivobloqueio.ST_Float = false;
            this.ds_motivobloqueio.ST_Gravar = true;
            this.ds_motivobloqueio.ST_Int = false;
            this.ds_motivobloqueio.ST_LimpaCampo = true;
            this.ds_motivobloqueio.ST_NotNull = false;
            this.ds_motivobloqueio.ST_PrimaryKey = false;
            this.ds_motivobloqueio.TabIndex = 195;
            this.ds_motivobloqueio.TextOld = null;
            // 
            // st_bloqcreditoavulso
            // 
            this.st_bloqcreditoavulso.AutoSize = true;
            this.st_bloqcreditoavulso.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsClifor, "St_bloqcreditoavulsobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_bloqcreditoavulso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_bloqcreditoavulso.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_bloqcreditoavulso.Location = new System.Drawing.Point(48, 78);
            this.st_bloqcreditoavulso.Name = "st_bloqcreditoavulso";
            this.st_bloqcreditoavulso.NM_Alias = "a";
            this.st_bloqcreditoavulso.NM_Campo = "ST_Bloq_DebitoVencido";
            this.st_bloqcreditoavulso.NM_Param = "@P_ST_BLOQ_DEBITOVENCIDO";
            this.st_bloqcreditoavulso.Size = new System.Drawing.Size(139, 17);
            this.st_bloqcreditoavulso.ST_Gravar = true;
            this.st_bloqcreditoavulso.ST_LimparCampo = true;
            this.st_bloqcreditoavulso.ST_NotNull = false;
            this.st_bloqcreditoavulso.TabIndex = 194;
            this.st_bloqcreditoavulso.Text = "Bloquear Credito Cliente";
            this.st_bloqcreditoavulso.UseVisualStyleBackColor = true;
            this.st_bloqcreditoavulso.Vl_False = "N";
            this.st_bloqcreditoavulso.Vl_True = "S";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(413, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 198;
            this.label9.Text = "dias";
            // 
            // diascarenciadebvencto
            // 
            this.diascarenciadebvencto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsClifor, "DiasCarenciaDebVencto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.diascarenciadebvencto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.diascarenciadebvencto.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.diascarenciadebvencto.Location = new System.Drawing.Point(322, 55);
            this.diascarenciadebvencto.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.diascarenciadebvencto.Name = "diascarenciadebvencto";
            this.diascarenciadebvencto.NM_Alias = "a";
            this.diascarenciadebvencto.NM_Campo = "VL_LIMITETOTAL";
            this.diascarenciadebvencto.NM_Param = "@P_VL_LIMITETOTAL";
            this.diascarenciadebvencto.Operador = "";
            this.diascarenciadebvencto.Size = new System.Drawing.Size(85, 20);
            this.diascarenciadebvencto.ST_AutoInc = false;
            this.diascarenciadebvencto.ST_DisableAuto = false;
            this.diascarenciadebvencto.ST_Gravar = true;
            this.diascarenciadebvencto.ST_LimparCampo = true;
            this.diascarenciadebvencto.ST_NotNull = true;
            this.diascarenciadebvencto.ST_PrimaryKey = false;
            this.diascarenciadebvencto.TabIndex = 192;
            this.diascarenciadebvencto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.diascarenciadebvencto.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(204, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 196;
            this.label6.Text = "Carencia Deb. Vencto";
            // 
            // st_bloq_debitovencido
            // 
            this.st_bloq_debitovencido.AutoSize = true;
            this.st_bloq_debitovencido.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsClifor, "St_bloq_debitovencidobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_bloq_debitovencido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_bloq_debitovencido.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_bloq_debitovencido.Location = new System.Drawing.Point(48, 55);
            this.st_bloq_debitovencido.Name = "st_bloq_debitovencido";
            this.st_bloq_debitovencido.NM_Alias = "a";
            this.st_bloq_debitovencido.NM_Campo = "ST_Bloq_DebitoVencido";
            this.st_bloq_debitovencido.NM_Param = "@P_ST_BLOQ_DEBITOVENCIDO";
            this.st_bloq_debitovencido.Size = new System.Drawing.Size(136, 17);
            this.st_bloq_debitovencido.ST_Gravar = true;
            this.st_bloq_debitovencido.ST_LimparCampo = true;
            this.st_bloq_debitovencido.ST_NotNull = false;
            this.st_bloq_debitovencido.TabIndex = 193;
            this.st_bloq_debitovencido.Text = "Bloquear Deb. Vencido";
            this.st_bloq_debitovencido.UseVisualStyleBackColor = true;
            this.st_bloq_debitovencido.Vl_False = "N";
            this.st_bloq_debitovencido.Vl_True = "S";
            // 
            // vl_limitecredito
            // 
            this.vl_limitecredito.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsClifor, "Vl_limitecredito", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_limitecredito.DecimalPlaces = 2;
            this.vl_limitecredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.vl_limitecredito.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_limitecredito.Location = new System.Drawing.Point(108, 30);
            this.vl_limitecredito.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.vl_limitecredito.Name = "vl_limitecredito";
            this.vl_limitecredito.NM_Alias = "a";
            this.vl_limitecredito.NM_Campo = "VL_LIMITETOTAL";
            this.vl_limitecredito.NM_Param = "@P_VL_LIMITETOTAL";
            this.vl_limitecredito.Operador = "";
            this.vl_limitecredito.Size = new System.Drawing.Size(95, 20);
            this.vl_limitecredito.ST_AutoInc = false;
            this.vl_limitecredito.ST_DisableAuto = false;
            this.vl_limitecredito.ST_Gravar = true;
            this.vl_limitecredito.ST_LimparCampo = true;
            this.vl_limitecredito.ST_NotNull = true;
            this.vl_limitecredito.ST_PrimaryKey = false;
            this.vl_limitecredito.TabIndex = 190;
            this.vl_limitecredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vl_limitecredito.ThousandsSeparator = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(21, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 197;
            this.label10.Text = "Limite Credito:";
            // 
            // radioGroup2
            // 
            this.radioGroup2.Controls.Add(this.ID_RamoAtividade);
            this.radioGroup2.Controls.Add(this.LB_DS_RamoAtividade);
            this.radioGroup2.Controls.Add(this.DS_RamoAtividade);
            this.radioGroup2.Controls.Add(this.lbvlrenda);
            this.radioGroup2.Controls.Add(this.vl_renda);
            this.radioGroup2.Controls.Add(this.ds_cargo);
            this.radioGroup2.Controls.Add(this.lbcargo);
            this.radioGroup2.Controls.Add(this.nm_localtrabalho);
            this.radioGroup2.Controls.Add(this.lbLocaltrab);
            this.radioGroup2.Controls.Add(this.nm_clifor);
            this.radioGroup2.Controls.Add(this.cd_clifor);
            this.radioGroup2.Controls.Add(this.label1);
            this.radioGroup2.Location = new System.Drawing.Point(20, 8);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.NM_Alias = "";
            this.radioGroup2.NM_Campo = "";
            this.radioGroup2.NM_Param = "";
            this.radioGroup2.NM_Valor = "";
            this.radioGroup2.Size = new System.Drawing.Size(867, 128);
            this.radioGroup2.ST_Gravar = false;
            this.radioGroup2.ST_NotNull = false;
            this.radioGroup2.TabIndex = 190;
            this.radioGroup2.TabStop = false;
            this.radioGroup2.Text = "DADOS CLIENTE";
            // 
            // ID_RamoAtividade
            // 
            this.ID_RamoAtividade.BackColor = System.Drawing.SystemColors.Window;
            this.ID_RamoAtividade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_RamoAtividade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_RamoAtividade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClifor, "Id_ramoatividadestring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_RamoAtividade.Enabled = false;
            this.ID_RamoAtividade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ID_RamoAtividade.Location = new System.Drawing.Point(95, 46);
            this.ID_RamoAtividade.Name = "ID_RamoAtividade";
            this.ID_RamoAtividade.NM_Alias = "a";
            this.ID_RamoAtividade.NM_Campo = "ID_RamoAtividade";
            this.ID_RamoAtividade.NM_CampoBusca = "ID_RamoAtividade";
            this.ID_RamoAtividade.NM_Param = "@P_ID_RAMOATIVIDADE";
            this.ID_RamoAtividade.QTD_Zero = 0;
            this.ID_RamoAtividade.Size = new System.Drawing.Size(52, 20);
            this.ID_RamoAtividade.ST_AutoInc = false;
            this.ID_RamoAtividade.ST_DisableAuto = false;
            this.ID_RamoAtividade.ST_Float = false;
            this.ID_RamoAtividade.ST_Gravar = true;
            this.ID_RamoAtividade.ST_Int = false;
            this.ID_RamoAtividade.ST_LimpaCampo = true;
            this.ID_RamoAtividade.ST_NotNull = false;
            this.ID_RamoAtividade.ST_PrimaryKey = false;
            this.ID_RamoAtividade.TabIndex = 71;
            this.ID_RamoAtividade.TextOld = null;
            // 
            // LB_DS_RamoAtividade
            // 
            this.LB_DS_RamoAtividade.AutoSize = true;
            this.LB_DS_RamoAtividade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_DS_RamoAtividade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_RamoAtividade.Location = new System.Drawing.Point(4, 49);
            this.LB_DS_RamoAtividade.Name = "LB_DS_RamoAtividade";
            this.LB_DS_RamoAtividade.Size = new System.Drawing.Size(85, 13);
            this.LB_DS_RamoAtividade.TabIndex = 74;
            this.LB_DS_RamoAtividade.Text = "Ramo Atividade:";
            this.LB_DS_RamoAtividade.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DS_RamoAtividade
            // 
            this.DS_RamoAtividade.BackColor = System.Drawing.SystemColors.Window;
            this.DS_RamoAtividade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_RamoAtividade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_RamoAtividade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClifor, "Ds_ramoatividade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_RamoAtividade.Enabled = false;
            this.DS_RamoAtividade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_RamoAtividade.Location = new System.Drawing.Point(149, 46);
            this.DS_RamoAtividade.Name = "DS_RamoAtividade";
            this.DS_RamoAtividade.NM_Alias = "";
            this.DS_RamoAtividade.NM_Campo = "DS_RamoAtividade";
            this.DS_RamoAtividade.NM_CampoBusca = "DS_RamoAtividade";
            this.DS_RamoAtividade.NM_Param = "@P_DS_RAMOATIVIDADE";
            this.DS_RamoAtividade.QTD_Zero = 0;
            this.DS_RamoAtividade.Size = new System.Drawing.Size(706, 20);
            this.DS_RamoAtividade.ST_AutoInc = false;
            this.DS_RamoAtividade.ST_DisableAuto = false;
            this.DS_RamoAtividade.ST_Float = false;
            this.DS_RamoAtividade.ST_Gravar = false;
            this.DS_RamoAtividade.ST_Int = false;
            this.DS_RamoAtividade.ST_LimpaCampo = true;
            this.DS_RamoAtividade.ST_NotNull = false;
            this.DS_RamoAtividade.ST_PrimaryKey = false;
            this.DS_RamoAtividade.TabIndex = 72;
            this.DS_RamoAtividade.TextOld = null;
            // 
            // lbvlrenda
            // 
            this.lbvlrenda.AutoSize = true;
            this.lbvlrenda.Location = new System.Drawing.Point(33, 100);
            this.lbvlrenda.Name = "lbvlrenda";
            this.lbvlrenda.Size = new System.Drawing.Size(57, 13);
            this.lbvlrenda.TabIndex = 70;
            this.lbvlrenda.Text = "Vl. Renda:";
            // 
            // vl_renda
            // 
            this.vl_renda.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsClifor, "Vl_renda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_renda.DecimalPlaces = 2;
            this.vl_renda.Enabled = false;
            this.vl_renda.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_renda.Location = new System.Drawing.Point(96, 98);
            this.vl_renda.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_renda.Name = "vl_renda";
            this.vl_renda.NM_Alias = "";
            this.vl_renda.NM_Campo = "";
            this.vl_renda.NM_Param = "";
            this.vl_renda.Operador = "";
            this.vl_renda.ReadOnly = true;
            this.vl_renda.Size = new System.Drawing.Size(120, 20);
            this.vl_renda.ST_AutoInc = false;
            this.vl_renda.ST_DisableAuto = false;
            this.vl_renda.ST_Gravar = false;
            this.vl_renda.ST_LimparCampo = true;
            this.vl_renda.ST_NotNull = false;
            this.vl_renda.ST_PrimaryKey = false;
            this.vl_renda.TabIndex = 69;
            this.vl_renda.TabStop = false;
            this.vl_renda.ThousandsSeparator = true;
            // 
            // ds_cargo
            // 
            this.ds_cargo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_cargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_cargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_cargo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClifor, "Ds_cargo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_cargo.Enabled = false;
            this.ds_cargo.Location = new System.Drawing.Point(96, 72);
            this.ds_cargo.Name = "ds_cargo";
            this.ds_cargo.NM_Alias = "";
            this.ds_cargo.NM_Campo = "";
            this.ds_cargo.NM_CampoBusca = "";
            this.ds_cargo.NM_Param = "";
            this.ds_cargo.QTD_Zero = 0;
            this.ds_cargo.ReadOnly = true;
            this.ds_cargo.Size = new System.Drawing.Size(759, 20);
            this.ds_cargo.ST_AutoInc = false;
            this.ds_cargo.ST_DisableAuto = false;
            this.ds_cargo.ST_Float = false;
            this.ds_cargo.ST_Gravar = false;
            this.ds_cargo.ST_Int = false;
            this.ds_cargo.ST_LimpaCampo = true;
            this.ds_cargo.ST_NotNull = false;
            this.ds_cargo.ST_PrimaryKey = false;
            this.ds_cargo.TabIndex = 68;
            this.ds_cargo.TabStop = false;
            this.ds_cargo.TextOld = null;
            // 
            // lbcargo
            // 
            this.lbcargo.AutoSize = true;
            this.lbcargo.Location = new System.Drawing.Point(52, 74);
            this.lbcargo.Name = "lbcargo";
            this.lbcargo.Size = new System.Drawing.Size(38, 13);
            this.lbcargo.TabIndex = 67;
            this.lbcargo.Text = "Cargo:";
            // 
            // nm_localtrabalho
            // 
            this.nm_localtrabalho.BackColor = System.Drawing.SystemColors.Window;
            this.nm_localtrabalho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_localtrabalho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_localtrabalho.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClifor, "Nm_localtrabalho", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_localtrabalho.Enabled = false;
            this.nm_localtrabalho.Location = new System.Drawing.Point(96, 46);
            this.nm_localtrabalho.Name = "nm_localtrabalho";
            this.nm_localtrabalho.NM_Alias = "";
            this.nm_localtrabalho.NM_Campo = "";
            this.nm_localtrabalho.NM_CampoBusca = "";
            this.nm_localtrabalho.NM_Param = "";
            this.nm_localtrabalho.QTD_Zero = 0;
            this.nm_localtrabalho.ReadOnly = true;
            this.nm_localtrabalho.Size = new System.Drawing.Size(759, 20);
            this.nm_localtrabalho.ST_AutoInc = false;
            this.nm_localtrabalho.ST_DisableAuto = false;
            this.nm_localtrabalho.ST_Float = false;
            this.nm_localtrabalho.ST_Gravar = false;
            this.nm_localtrabalho.ST_Int = false;
            this.nm_localtrabalho.ST_LimpaCampo = true;
            this.nm_localtrabalho.ST_NotNull = false;
            this.nm_localtrabalho.ST_PrimaryKey = false;
            this.nm_localtrabalho.TabIndex = 66;
            this.nm_localtrabalho.TabStop = false;
            this.nm_localtrabalho.TextOld = null;
            // 
            // lbLocaltrab
            // 
            this.lbLocaltrab.AutoSize = true;
            this.lbLocaltrab.Location = new System.Drawing.Point(9, 48);
            this.lbLocaltrab.Name = "lbLocaltrab";
            this.lbLocaltrab.Size = new System.Drawing.Size(81, 13);
            this.lbLocaltrab.TabIndex = 65;
            this.lbLocaltrab.Text = "Local Trabalho:";
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClifor, "Nm_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Location = new System.Drawing.Point(159, 20);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "";
            this.nm_clifor.NM_CampoBusca = "";
            this.nm_clifor.NM_Param = "";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.ReadOnly = true;
            this.nm_clifor.Size = new System.Drawing.Size(696, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 64;
            this.nm_clifor.TextOld = null;
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClifor, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor.Enabled = false;
            this.cd_clifor.Location = new System.Drawing.Point(57, 20);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "";
            this.cd_clifor.NM_Campo = "";
            this.cd_clifor.NM_CampoBusca = "";
            this.cd_clifor.NM_Param = "";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.ReadOnly = true;
            this.cd_clifor.Size = new System.Drawing.Size(100, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = false;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = false;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 63;
            this.cd_clifor.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Cliente:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(904, 43);
            this.barraMenu.TabIndex = 538;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
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
            // TFAnaliseCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 436);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAnaliseCredito";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analise Credito Cliente";
            this.Load += new System.EventHandler(this.TFAnaliseCredito_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAnaliseCredito_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsClifor)).EndInit();
            this.tlpCentral.ResumeLayout(false);
            this.pClifor.ResumeLayout(false);
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_limitecredCH)).EndInit();
            this.radioGroup3.ResumeLayout(false);
            this.radioGroup3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diascarenciadebvencto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_limitecredito)).EndInit();
            this.radioGroup2.ResumeLayout(false);
            this.radioGroup2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_renda)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsClifor;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pClifor;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.EditFloat vl_limitecredCH;
        private System.Windows.Forms.Label label8;
        private Componentes.RadioGroup radioGroup3;
        private Componentes.CheckBoxDefault st_bloqueioSPC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault ds_consultaSPC;
        private Componentes.EditData dt_consulaSPC;
        private System.Windows.Forms.Label label19;
        private Componentes.EditDefault ds_motivobloqueio;
        private Componentes.CheckBoxDefault st_bloqcreditoavulso;
        private System.Windows.Forms.Label label9;
        private Componentes.EditFloat diascarenciadebvencto;
        private System.Windows.Forms.Label label6;
        private Componentes.CheckBoxDefault st_bloq_debitovencido;
        private Componentes.EditFloat vl_limitecredito;
        private System.Windows.Forms.Label label10;
        private Componentes.RadioGroup radioGroup2;
        private System.Windows.Forms.Label lbvlrenda;
        private Componentes.EditFloat vl_renda;
        private Componentes.EditDefault ds_cargo;
        private System.Windows.Forms.Label lbcargo;
        private Componentes.EditDefault nm_localtrabalho;
        private System.Windows.Forms.Label lbLocaltrab;
        private Componentes.EditDefault nm_clifor;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.EditDefault ID_RamoAtividade;
        private System.Windows.Forms.Label LB_DS_RamoAtividade;
        private Componentes.EditDefault DS_RamoAtividade;
    }
}