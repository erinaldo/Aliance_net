namespace Commoditties
{
    partial class TFTaxaContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTaxaContrato));
            System.Windows.Forms.Label cd_tipoamostraLabel;
            System.Windows.Forms.Label pc_result_maiorqueLabel;
            System.Windows.Forms.Label pc_result_menorqueLabel;
            System.Windows.Forms.Label frequenciaLabel;
            System.Windows.Forms.Label periodocarenciaLabel;
            System.Windows.Forms.Label valortaxaLabel;
            System.Windows.Forms.Label cd_unidadetaxaLabel;
            System.Windows.Forms.Label id_taxastrLabel;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.st_gerartxsomente = new Componentes.ComboBoxDefault(this.components);
            this.bsTaxa = new System.Windows.Forms.BindingSource(this.components);
            this.pAmostra = new Componentes.PanelDados(this.components);
            this.bb_amostra = new System.Windows.Forms.Button();
            this.cd_tipoamostra = new Componentes.EditDefault(this.components);
            this.ds_tipoamostra = new Componentes.EditDefault(this.components);
            this.pc_result_maiorque = new Componentes.EditFloat(this.components);
            this.pc_result_menorque = new Componentes.EditFloat(this.components);
            this.tp_taxa = new Componentes.EditDefault(this.components);
            this.bb_unidade = new System.Windows.Forms.Button();
            this.bb_taxa = new System.Windows.Forms.Button();
            this.frequencia = new Componentes.EditFloat(this.components);
            this.periodocarencia = new Componentes.EditFloat(this.components);
            this.valortaxa = new Componentes.EditFloat(this.components);
            this.sg_unidadetaxa = new Componentes.EditDefault(this.components);
            this.ds_unidadetaxa = new Componentes.EditDefault(this.components);
            this.cd_unidadetaxa = new Componentes.EditDefault(this.components);
            this.ds_taxa = new Componentes.EditDefault(this.components);
            this.id_taxa = new Componentes.EditDefault(this.components);
            label5 = new System.Windows.Forms.Label();
            cd_tipoamostraLabel = new System.Windows.Forms.Label();
            pc_result_maiorqueLabel = new System.Windows.Forms.Label();
            pc_result_menorqueLabel = new System.Windows.Forms.Label();
            frequenciaLabel = new System.Windows.Forms.Label();
            periodocarenciaLabel = new System.Windows.Forms.Label();
            valortaxaLabel = new System.Windows.Forms.Label();
            cd_unidadetaxaLabel = new System.Windows.Forms.Label();
            id_taxastrLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTaxa)).BeginInit();
            this.pAmostra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_result_maiorque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_result_menorque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodocarencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valortaxa)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // cd_tipoamostraLabel
            // 
            resources.ApplyResources(cd_tipoamostraLabel, "cd_tipoamostraLabel");
            cd_tipoamostraLabel.Name = "cd_tipoamostraLabel";
            // 
            // pc_result_maiorqueLabel
            // 
            resources.ApplyResources(pc_result_maiorqueLabel, "pc_result_maiorqueLabel");
            pc_result_maiorqueLabel.Name = "pc_result_maiorqueLabel";
            // 
            // pc_result_menorqueLabel
            // 
            resources.ApplyResources(pc_result_menorqueLabel, "pc_result_menorqueLabel");
            pc_result_menorqueLabel.Name = "pc_result_menorqueLabel";
            // 
            // frequenciaLabel
            // 
            resources.ApplyResources(frequenciaLabel, "frequenciaLabel");
            frequenciaLabel.Name = "frequenciaLabel";
            // 
            // periodocarenciaLabel
            // 
            resources.ApplyResources(periodocarenciaLabel, "periodocarenciaLabel");
            periodocarenciaLabel.Name = "periodocarenciaLabel";
            // 
            // valortaxaLabel
            // 
            resources.ApplyResources(valortaxaLabel, "valortaxaLabel");
            valortaxaLabel.Name = "valortaxaLabel";
            // 
            // cd_unidadetaxaLabel
            // 
            resources.ApplyResources(cd_unidadetaxaLabel, "cd_unidadetaxaLabel");
            cd_unidadetaxaLabel.Name = "cd_unidadetaxaLabel";
            // 
            // id_taxastrLabel
            // 
            resources.ApplyResources(id_taxastrLabel, "id_taxastrLabel");
            id_taxastrLabel.Name = "id_taxastrLabel";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.st_gerartxsomente);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(this.pAmostra);
            this.pDados.Controls.Add(this.tp_taxa);
            this.pDados.Controls.Add(this.bb_unidade);
            this.pDados.Controls.Add(this.bb_taxa);
            this.pDados.Controls.Add(frequenciaLabel);
            this.pDados.Controls.Add(this.frequencia);
            this.pDados.Controls.Add(periodocarenciaLabel);
            this.pDados.Controls.Add(this.periodocarencia);
            this.pDados.Controls.Add(valortaxaLabel);
            this.pDados.Controls.Add(this.valortaxa);
            this.pDados.Controls.Add(this.sg_unidadetaxa);
            this.pDados.Controls.Add(this.ds_unidadetaxa);
            this.pDados.Controls.Add(cd_unidadetaxaLabel);
            this.pDados.Controls.Add(this.cd_unidadetaxa);
            this.pDados.Controls.Add(this.ds_taxa);
            this.pDados.Controls.Add(id_taxastrLabel);
            this.pDados.Controls.Add(this.id_taxa);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // st_gerartxsomente
            // 
            this.st_gerartxsomente.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsTaxa, "St_gerartxsomente", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_gerartxsomente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.st_gerartxsomente.FormattingEnabled = true;
            resources.ApplyResources(this.st_gerartxsomente, "st_gerartxsomente");
            this.st_gerartxsomente.Name = "st_gerartxsomente";
            this.st_gerartxsomente.NM_Alias = "a";
            this.st_gerartxsomente.NM_Campo = "st_gerartxsomente";
            this.st_gerartxsomente.NM_Param = "";
            this.st_gerartxsomente.ST_Gravar = true;
            this.st_gerartxsomente.ST_LimparCampo = true;
            this.st_gerartxsomente.ST_NotNull = true;
            // 
            // bsTaxa
            // 
            this.bsTaxa.DataSource = typeof(CamadaDados.Graos.TList_CadContratoTaxaDeposito);
            // 
            // pAmostra
            // 
            this.pAmostra.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pAmostra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAmostra.Controls.Add(this.bb_amostra);
            this.pAmostra.Controls.Add(this.cd_tipoamostra);
            this.pAmostra.Controls.Add(cd_tipoamostraLabel);
            this.pAmostra.Controls.Add(this.ds_tipoamostra);
            this.pAmostra.Controls.Add(this.pc_result_maiorque);
            this.pAmostra.Controls.Add(pc_result_maiorqueLabel);
            this.pAmostra.Controls.Add(pc_result_menorqueLabel);
            this.pAmostra.Controls.Add(this.pc_result_menorque);
            resources.ApplyResources(this.pAmostra, "pAmostra");
            this.pAmostra.Name = "pAmostra";
            this.pAmostra.NM_ProcDeletar = "";
            this.pAmostra.NM_ProcGravar = "";
            // 
            // bb_amostra
            // 
            this.bb_amostra.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_amostra, "bb_amostra");
            this.bb_amostra.Name = "bb_amostra";
            this.bb_amostra.UseVisualStyleBackColor = false;
            this.bb_amostra.Click += new System.EventHandler(this.bb_amostra_Click);
            // 
            // cd_tipoamostra
            // 
            this.cd_tipoamostra.BackColor = System.Drawing.SystemColors.Window;
            this.cd_tipoamostra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_tipoamostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tipoamostra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxa, "Cd_tipoamostra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_tipoamostra, "cd_tipoamostra");
            this.cd_tipoamostra.Name = "cd_tipoamostra";
            this.cd_tipoamostra.NM_Alias = "a";
            this.cd_tipoamostra.NM_Campo = "cd_tipoamostra";
            this.cd_tipoamostra.NM_CampoBusca = "cd_tipoamostra";
            this.cd_tipoamostra.NM_Param = "@P_CD_TIPOAMOSTRA";
            this.cd_tipoamostra.QTD_Zero = 0;
            this.cd_tipoamostra.ST_AutoInc = false;
            this.cd_tipoamostra.ST_DisableAuto = false;
            this.cd_tipoamostra.ST_Float = false;
            this.cd_tipoamostra.ST_Gravar = true;
            this.cd_tipoamostra.ST_Int = true;
            this.cd_tipoamostra.ST_LimpaCampo = true;
            this.cd_tipoamostra.ST_NotNull = false;
            this.cd_tipoamostra.ST_PrimaryKey = false;
            this.cd_tipoamostra.TextOld = null;
            this.cd_tipoamostra.Leave += new System.EventHandler(this.cd_tipoamostra_Leave);
            // 
            // ds_tipoamostra
            // 
            this.ds_tipoamostra.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tipoamostra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tipoamostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tipoamostra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxa, "Ds_tipoamostra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_tipoamostra, "ds_tipoamostra");
            this.ds_tipoamostra.Name = "ds_tipoamostra";
            this.ds_tipoamostra.NM_Alias = "a";
            this.ds_tipoamostra.NM_Campo = "ds_tipoamostra";
            this.ds_tipoamostra.NM_CampoBusca = "ds_amostra";
            this.ds_tipoamostra.NM_Param = "@P_DS_TIPOAMOSTRA";
            this.ds_tipoamostra.QTD_Zero = 0;
            this.ds_tipoamostra.ST_AutoInc = false;
            this.ds_tipoamostra.ST_DisableAuto = false;
            this.ds_tipoamostra.ST_Float = false;
            this.ds_tipoamostra.ST_Gravar = false;
            this.ds_tipoamostra.ST_Int = false;
            this.ds_tipoamostra.ST_LimpaCampo = true;
            this.ds_tipoamostra.ST_NotNull = false;
            this.ds_tipoamostra.ST_PrimaryKey = false;
            this.ds_tipoamostra.TextOld = null;
            // 
            // pc_result_maiorque
            // 
            this.pc_result_maiorque.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTaxa, "Pc_result_maiorque", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_result_maiorque.DecimalPlaces = 3;
            resources.ApplyResources(this.pc_result_maiorque, "pc_result_maiorque");
            this.pc_result_maiorque.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_result_maiorque.Name = "pc_result_maiorque";
            this.pc_result_maiorque.NM_Alias = "a";
            this.pc_result_maiorque.NM_Campo = "pc_result_maiorque";
            this.pc_result_maiorque.NM_Param = "PC_RESULT_MAIORQUE";
            this.pc_result_maiorque.Operador = "";
            this.pc_result_maiorque.ST_AutoInc = false;
            this.pc_result_maiorque.ST_DisableAuto = false;
            this.pc_result_maiorque.ST_Gravar = true;
            this.pc_result_maiorque.ST_LimparCampo = true;
            this.pc_result_maiorque.ST_NotNull = false;
            this.pc_result_maiorque.ST_PrimaryKey = false;
            // 
            // pc_result_menorque
            // 
            this.pc_result_menorque.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTaxa, "Pc_result_menorque", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_result_menorque.DecimalPlaces = 3;
            resources.ApplyResources(this.pc_result_menorque, "pc_result_menorque");
            this.pc_result_menorque.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_result_menorque.Name = "pc_result_menorque";
            this.pc_result_menorque.NM_Alias = "a";
            this.pc_result_menorque.NM_Campo = "pc_result_menorque";
            this.pc_result_menorque.NM_Param = "PC_RESULT_MENORQUE";
            this.pc_result_menorque.Operador = "";
            this.pc_result_menorque.ST_AutoInc = false;
            this.pc_result_menorque.ST_DisableAuto = false;
            this.pc_result_menorque.ST_Gravar = true;
            this.pc_result_menorque.ST_LimparCampo = true;
            this.pc_result_menorque.ST_NotNull = false;
            this.pc_result_menorque.ST_PrimaryKey = false;
            // 
            // tp_taxa
            // 
            this.tp_taxa.BackColor = System.Drawing.SystemColors.Window;
            this.tp_taxa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_taxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_taxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxa, "Tp_taxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.tp_taxa, "tp_taxa");
            this.tp_taxa.Name = "tp_taxa";
            this.tp_taxa.NM_Alias = "a";
            this.tp_taxa.NM_Campo = "tp_taxa";
            this.tp_taxa.NM_CampoBusca = "tp_taxa";
            this.tp_taxa.NM_Param = "@P_TP_TAXA";
            this.tp_taxa.QTD_Zero = 0;
            this.tp_taxa.ST_AutoInc = false;
            this.tp_taxa.ST_DisableAuto = false;
            this.tp_taxa.ST_Float = false;
            this.tp_taxa.ST_Gravar = false;
            this.tp_taxa.ST_Int = false;
            this.tp_taxa.ST_LimpaCampo = true;
            this.tp_taxa.ST_NotNull = false;
            this.tp_taxa.ST_PrimaryKey = false;
            this.tp_taxa.TextOld = null;
            // 
            // bb_unidade
            // 
            resources.ApplyResources(this.bb_unidade, "bb_unidade");
            this.bb_unidade.Name = "bb_unidade";
            this.bb_unidade.UseVisualStyleBackColor = true;
            this.bb_unidade.Click += new System.EventHandler(this.bb_unidade_Click);
            // 
            // bb_taxa
            // 
            resources.ApplyResources(this.bb_taxa, "bb_taxa");
            this.bb_taxa.Name = "bb_taxa";
            this.bb_taxa.UseVisualStyleBackColor = true;
            this.bb_taxa.Click += new System.EventHandler(this.bb_taxa_Click);
            // 
            // frequencia
            // 
            this.frequencia.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTaxa, "Frequencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.frequencia, "frequencia");
            this.frequencia.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.frequencia.Name = "frequencia";
            this.frequencia.NM_Alias = "a";
            this.frequencia.NM_Campo = "frequencia";
            this.frequencia.NM_Param = "FREQUENCIA";
            this.frequencia.Operador = "";
            this.frequencia.ST_AutoInc = false;
            this.frequencia.ST_DisableAuto = false;
            this.frequencia.ST_Gravar = true;
            this.frequencia.ST_LimparCampo = true;
            this.frequencia.ST_NotNull = false;
            this.frequencia.ST_PrimaryKey = false;
            // 
            // periodocarencia
            // 
            this.periodocarencia.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTaxa, "Periodocarencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.periodocarencia, "periodocarencia");
            this.periodocarencia.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.periodocarencia.Name = "periodocarencia";
            this.periodocarencia.NM_Alias = "a";
            this.periodocarencia.NM_Campo = "periodocarencia";
            this.periodocarencia.NM_Param = "PERIODOCARENCIA";
            this.periodocarencia.Operador = "";
            this.periodocarencia.ST_AutoInc = false;
            this.periodocarencia.ST_DisableAuto = false;
            this.periodocarencia.ST_Gravar = true;
            this.periodocarencia.ST_LimparCampo = true;
            this.periodocarencia.ST_NotNull = false;
            this.periodocarencia.ST_PrimaryKey = false;
            // 
            // valortaxa
            // 
            this.valortaxa.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTaxa, "Valortaxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.valortaxa.DecimalPlaces = 7;
            resources.ApplyResources(this.valortaxa, "valortaxa");
            this.valortaxa.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.valortaxa.Name = "valortaxa";
            this.valortaxa.NM_Alias = "a";
            this.valortaxa.NM_Campo = "valortaxa";
            this.valortaxa.NM_Param = "VALORTAXA";
            this.valortaxa.Operador = "";
            this.valortaxa.ST_AutoInc = false;
            this.valortaxa.ST_DisableAuto = false;
            this.valortaxa.ST_Gravar = true;
            this.valortaxa.ST_LimparCampo = true;
            this.valortaxa.ST_NotNull = false;
            this.valortaxa.ST_PrimaryKey = false;
            // 
            // sg_unidadetaxa
            // 
            this.sg_unidadetaxa.BackColor = System.Drawing.SystemColors.Window;
            this.sg_unidadetaxa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sg_unidadetaxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sg_unidadetaxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxa, "Sg_unidadetaxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.sg_unidadetaxa, "sg_unidadetaxa");
            this.sg_unidadetaxa.Name = "sg_unidadetaxa";
            this.sg_unidadetaxa.NM_Alias = "a";
            this.sg_unidadetaxa.NM_Campo = "sg_unidadetaxa";
            this.sg_unidadetaxa.NM_CampoBusca = "sigla_unidade";
            this.sg_unidadetaxa.NM_Param = "@P_SG_UNIDADETAXA";
            this.sg_unidadetaxa.QTD_Zero = 0;
            this.sg_unidadetaxa.ST_AutoInc = false;
            this.sg_unidadetaxa.ST_DisableAuto = false;
            this.sg_unidadetaxa.ST_Float = false;
            this.sg_unidadetaxa.ST_Gravar = false;
            this.sg_unidadetaxa.ST_Int = false;
            this.sg_unidadetaxa.ST_LimpaCampo = true;
            this.sg_unidadetaxa.ST_NotNull = false;
            this.sg_unidadetaxa.ST_PrimaryKey = false;
            this.sg_unidadetaxa.TextOld = null;
            // 
            // ds_unidadetaxa
            // 
            this.ds_unidadetaxa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_unidadetaxa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_unidadetaxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_unidadetaxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxa, "Ds_unidadetaxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_unidadetaxa, "ds_unidadetaxa");
            this.ds_unidadetaxa.Name = "ds_unidadetaxa";
            this.ds_unidadetaxa.NM_Alias = "a";
            this.ds_unidadetaxa.NM_Campo = "ds_unidadetaxa";
            this.ds_unidadetaxa.NM_CampoBusca = "ds_unidade";
            this.ds_unidadetaxa.NM_Param = "@P_DS_UNIDADETAXA";
            this.ds_unidadetaxa.QTD_Zero = 0;
            this.ds_unidadetaxa.ST_AutoInc = false;
            this.ds_unidadetaxa.ST_DisableAuto = false;
            this.ds_unidadetaxa.ST_Float = false;
            this.ds_unidadetaxa.ST_Gravar = false;
            this.ds_unidadetaxa.ST_Int = false;
            this.ds_unidadetaxa.ST_LimpaCampo = true;
            this.ds_unidadetaxa.ST_NotNull = false;
            this.ds_unidadetaxa.ST_PrimaryKey = false;
            this.ds_unidadetaxa.TextOld = null;
            // 
            // cd_unidadetaxa
            // 
            this.cd_unidadetaxa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_unidadetaxa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_unidadetaxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidadetaxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxa, "Cd_unidadetaxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_unidadetaxa, "cd_unidadetaxa");
            this.cd_unidadetaxa.Name = "cd_unidadetaxa";
            this.cd_unidadetaxa.NM_Alias = "a";
            this.cd_unidadetaxa.NM_Campo = "cd_unidade";
            this.cd_unidadetaxa.NM_CampoBusca = "cd_unidade";
            this.cd_unidadetaxa.NM_Param = "@P_CD_UNIDADETAXA";
            this.cd_unidadetaxa.QTD_Zero = 0;
            this.cd_unidadetaxa.ST_AutoInc = false;
            this.cd_unidadetaxa.ST_DisableAuto = false;
            this.cd_unidadetaxa.ST_Float = false;
            this.cd_unidadetaxa.ST_Gravar = true;
            this.cd_unidadetaxa.ST_Int = true;
            this.cd_unidadetaxa.ST_LimpaCampo = true;
            this.cd_unidadetaxa.ST_NotNull = true;
            this.cd_unidadetaxa.ST_PrimaryKey = false;
            this.cd_unidadetaxa.TextOld = null;
            this.cd_unidadetaxa.Leave += new System.EventHandler(this.cd_unidadetaxa_Leave);
            // 
            // ds_taxa
            // 
            this.ds_taxa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_taxa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_taxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_taxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxa, "Ds_taxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_taxa, "ds_taxa");
            this.ds_taxa.Name = "ds_taxa";
            this.ds_taxa.NM_Alias = "a";
            this.ds_taxa.NM_Campo = "ds_taxa";
            this.ds_taxa.NM_CampoBusca = "ds_taxa";
            this.ds_taxa.NM_Param = "@P_DS_TAXA";
            this.ds_taxa.QTD_Zero = 0;
            this.ds_taxa.ST_AutoInc = false;
            this.ds_taxa.ST_DisableAuto = false;
            this.ds_taxa.ST_Float = false;
            this.ds_taxa.ST_Gravar = false;
            this.ds_taxa.ST_Int = false;
            this.ds_taxa.ST_LimpaCampo = true;
            this.ds_taxa.ST_NotNull = false;
            this.ds_taxa.ST_PrimaryKey = false;
            this.ds_taxa.TextOld = null;
            // 
            // id_taxa
            // 
            this.id_taxa.BackColor = System.Drawing.SystemColors.Window;
            this.id_taxa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_taxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_taxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxa, "Id_taxastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.id_taxa, "id_taxa");
            this.id_taxa.Name = "id_taxa";
            this.id_taxa.NM_Alias = "a";
            this.id_taxa.NM_Campo = "id_taxa";
            this.id_taxa.NM_CampoBusca = "id_taxa";
            this.id_taxa.NM_Param = "@P_ID_TAXA";
            this.id_taxa.QTD_Zero = 0;
            this.id_taxa.ST_AutoInc = false;
            this.id_taxa.ST_DisableAuto = false;
            this.id_taxa.ST_Float = false;
            this.id_taxa.ST_Gravar = true;
            this.id_taxa.ST_Int = true;
            this.id_taxa.ST_LimpaCampo = true;
            this.id_taxa.ST_NotNull = true;
            this.id_taxa.ST_PrimaryKey = false;
            this.id_taxa.TextOld = null;
            this.id_taxa.Leave += new System.EventHandler(this.id_taxa_Leave);
            // 
            // TFTaxaContrato
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFTaxaContrato";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFTaxaContrato_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFTaxaContrato_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTaxa)).EndInit();
            this.pAmostra.ResumeLayout(false);
            this.pAmostra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_result_maiorque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_result_menorque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodocarencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valortaxa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.ComboBoxDefault st_gerartxsomente;
        private Componentes.PanelDados pAmostra;
        private System.Windows.Forms.Button bb_amostra;
        private Componentes.EditDefault cd_tipoamostra;
        private Componentes.EditDefault ds_tipoamostra;
        private Componentes.EditFloat pc_result_maiorque;
        private Componentes.EditFloat pc_result_menorque;
        private Componentes.EditDefault tp_taxa;
        private System.Windows.Forms.Button bb_unidade;
        private System.Windows.Forms.Button bb_taxa;
        private Componentes.EditFloat frequencia;
        private Componentes.EditFloat periodocarencia;
        private Componentes.EditFloat valortaxa;
        private Componentes.EditDefault sg_unidadetaxa;
        private Componentes.EditDefault ds_unidadetaxa;
        private Componentes.EditDefault cd_unidadetaxa;
        private Componentes.EditDefault ds_taxa;
        private Componentes.EditDefault id_taxa;
        private System.Windows.Forms.BindingSource bsTaxa;
    }
}