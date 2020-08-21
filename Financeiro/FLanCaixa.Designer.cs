namespace Financeiro
{
    partial class TFLanCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanCaixa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_cadhistorico = new System.Windows.Forms.Button();
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.dsLanCaixa = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Nr_Docto = new Componentes.EditDefault(this.components);
            this.rg_TP_Movimento = new System.Windows.Forms.GroupBox();
            this.RB_Receber = new Componentes.RadioButtonDefault(this.components);
            this.RB_Pagar = new Componentes.RadioButtonDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.DT_Lancto = new Componentes.EditData(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.ComplHistorico = new Componentes.EditDefault(this.components);
            this.DS_Historico = new Componentes.EditDefault(this.components);
            this.DS_ContaGer = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.BB_Historico = new System.Windows.Forms.Button();
            this.BB_ContaGer = new System.Windows.Forms.Button();
            this.CD_ContaGer = new Componentes.EditDefault(this.components);
            this.CD_Historico = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.CD_LanctoCaixa = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pValores = new Componentes.PanelDados(this.components);
            this.VL_Pagar = new Componentes.EditFloat(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.VL_Receber = new Componentes.EditFloat(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsLanCaixa)).BeginInit();
            this.rg_TP_Movimento.SuspendLayout();
            this.pValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Pagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Receber)).BeginInit();
            this.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pValores, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.SystemColors.Control;
            this.panelDados1.Controls.Add(this.bb_cadhistorico);
            this.panelDados1.Controls.Add(this.NM_Clifor);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.Nr_Docto);
            this.panelDados1.Controls.Add(this.rg_TP_Movimento);
            this.panelDados1.Controls.Add(this.label9);
            this.panelDados1.Controls.Add(this.NM_Empresa);
            this.panelDados1.Controls.Add(this.BB_Empresa);
            this.panelDados1.Controls.Add(this.CD_Empresa);
            this.panelDados1.Controls.Add(this.label8);
            this.panelDados1.Controls.Add(this.DT_Lancto);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Controls.Add(this.ComplHistorico);
            this.panelDados1.Controls.Add(this.DS_Historico);
            this.panelDados1.Controls.Add(this.DS_ContaGer);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.BB_Historico);
            this.panelDados1.Controls.Add(this.BB_ContaGer);
            this.panelDados1.Controls.Add(this.CD_ContaGer);
            this.panelDados1.Controls.Add(this.CD_Historico);
            this.panelDados1.Controls.Add(this.label6);
            this.panelDados1.Controls.Add(this.CD_LanctoCaixa);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.label3);
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // bb_cadhistorico
            // 
            resources.ApplyResources(this.bb_cadhistorico, "bb_cadhistorico");
            this.bb_cadhistorico.Name = "bb_cadhistorico";
            this.bb_cadhistorico.UseVisualStyleBackColor = true;
            this.bb_cadhistorico.Click += new System.EventHandler(this.bb_cadhistorico_Click);
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsLanCaixa, "NM_Clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.NM_Clifor, "NM_Clifor");
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "Nr_Docto";
            this.NM_Clifor.NM_CampoBusca = "Nr_Docto";
            this.NM_Clifor.NM_Param = "@P_NR_DOCTO";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = true;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TextOld = null;
            // 
            // dsLanCaixa
            // 
            this.dsLanCaixa.DataSource = typeof(CamadaDados.Financeiro.Caixa.TList_LanCaixa);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Nr_Docto
            // 
            this.Nr_Docto.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_Docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_Docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_Docto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsLanCaixa, "Nr_Docto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Nr_Docto, "Nr_Docto");
            this.Nr_Docto.Name = "Nr_Docto";
            this.Nr_Docto.NM_Alias = "";
            this.Nr_Docto.NM_Campo = "Nr_Docto";
            this.Nr_Docto.NM_CampoBusca = "Nr_Docto";
            this.Nr_Docto.NM_Param = "@P_NR_DOCTO";
            this.Nr_Docto.QTD_Zero = 0;
            this.Nr_Docto.ST_AutoInc = false;
            this.Nr_Docto.ST_DisableAuto = false;
            this.Nr_Docto.ST_Float = false;
            this.Nr_Docto.ST_Gravar = true;
            this.Nr_Docto.ST_Int = false;
            this.Nr_Docto.ST_LimpaCampo = true;
            this.Nr_Docto.ST_NotNull = true;
            this.Nr_Docto.ST_PrimaryKey = false;
            this.Nr_Docto.TextOld = null;
            // 
            // rg_TP_Movimento
            // 
            this.rg_TP_Movimento.BackColor = System.Drawing.SystemColors.Control;
            this.rg_TP_Movimento.Controls.Add(this.RB_Receber);
            this.rg_TP_Movimento.Controls.Add(this.RB_Pagar);
            resources.ApplyResources(this.rg_TP_Movimento, "rg_TP_Movimento");
            this.rg_TP_Movimento.Name = "rg_TP_Movimento";
            this.rg_TP_Movimento.TabStop = false;
            // 
            // RB_Receber
            // 
            resources.ApplyResources(this.RB_Receber, "RB_Receber");
            this.RB_Receber.Checked = true;
            this.RB_Receber.Name = "RB_Receber";
            this.RB_Receber.TabStop = true;
            this.RB_Receber.UseVisualStyleBackColor = true;
            this.RB_Receber.Valor = "";
            this.RB_Receber.Click += new System.EventHandler(this.RB_Receber_Click);
            this.RB_Receber.CheckedChanged += new System.EventHandler(this.RB_Receber_CheckedChanged);
            // 
            // RB_Pagar
            // 
            resources.ApplyResources(this.RB_Pagar, "RB_Pagar");
            this.RB_Pagar.Name = "RB_Pagar";
            this.RB_Pagar.UseVisualStyleBackColor = true;
            this.RB_Pagar.Valor = "";
            this.RB_Pagar.Click += new System.EventHandler(this.RB_Pagar_Click);
            this.RB_Pagar.CheckedChanged += new System.EventHandler(this.RB_Pagar_CheckedChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsLanCaixa, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.NM_Empresa, "NM_Empresa");
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TextOld = null;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            resources.ApplyResources(this.BB_Empresa, "BB_Empresa");
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsLanCaixa, "Cd_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Empresa, "CD_Empresa");
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // DT_Lancto
            // 
            this.DT_Lancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsLanCaixa, "Dt_lanctostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DT_Lancto, "DT_Lancto");
            this.DT_Lancto.Name = "DT_Lancto";
            this.DT_Lancto.NM_Alias = "";
            this.DT_Lancto.NM_Campo = "DT_Lancto";
            this.DT_Lancto.NM_CampoBusca = "DT_Lancto";
            this.DT_Lancto.NM_Param = "@P_DT_LANCTO";
            this.DT_Lancto.Operador = "";
            this.DT_Lancto.ST_Gravar = true;
            this.DT_Lancto.ST_LimpaCampo = true;
            this.DT_Lancto.ST_NotNull = true;
            this.DT_Lancto.ST_PrimaryKey = false;
            this.DT_Lancto.Enter += new System.EventHandler(this.DT_Lancto_Enter);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // ComplHistorico
            // 
            this.ComplHistorico.BackColor = System.Drawing.SystemColors.Window;
            this.ComplHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComplHistorico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ComplHistorico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsLanCaixa, "ComplHistorico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ComplHistorico, "ComplHistorico");
            this.ComplHistorico.Name = "ComplHistorico";
            this.ComplHistorico.NM_Alias = "";
            this.ComplHistorico.NM_Campo = "ComplHistorico";
            this.ComplHistorico.NM_CampoBusca = "ComplHistorico";
            this.ComplHistorico.NM_Param = "@P_COMPLHISTORICO";
            this.ComplHistorico.QTD_Zero = 0;
            this.ComplHistorico.ST_AutoInc = false;
            this.ComplHistorico.ST_DisableAuto = false;
            this.ComplHistorico.ST_Float = false;
            this.ComplHistorico.ST_Gravar = true;
            this.ComplHistorico.ST_Int = false;
            this.ComplHistorico.ST_LimpaCampo = true;
            this.ComplHistorico.ST_NotNull = false;
            this.ComplHistorico.ST_PrimaryKey = false;
            this.ComplHistorico.TextOld = null;
            // 
            // DS_Historico
            // 
            this.DS_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsLanCaixa, "Ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Historico, "DS_Historico");
            this.DS_Historico.Name = "DS_Historico";
            this.DS_Historico.NM_Alias = "";
            this.DS_Historico.NM_Campo = "DS_Historico";
            this.DS_Historico.NM_CampoBusca = "DS_Historico";
            this.DS_Historico.NM_Param = "@P_DS_HISTORICO";
            this.DS_Historico.QTD_Zero = 0;
            this.DS_Historico.ST_AutoInc = false;
            this.DS_Historico.ST_DisableAuto = false;
            this.DS_Historico.ST_Float = false;
            this.DS_Historico.ST_Gravar = false;
            this.DS_Historico.ST_Int = false;
            this.DS_Historico.ST_LimpaCampo = true;
            this.DS_Historico.ST_NotNull = false;
            this.DS_Historico.ST_PrimaryKey = false;
            this.DS_Historico.TextOld = null;
            // 
            // DS_ContaGer
            // 
            this.DS_ContaGer.BackColor = System.Drawing.SystemColors.Window;
            this.DS_ContaGer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_ContaGer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsLanCaixa, "Ds_ContaGer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_ContaGer, "DS_ContaGer");
            this.DS_ContaGer.Name = "DS_ContaGer";
            this.DS_ContaGer.NM_Alias = "";
            this.DS_ContaGer.NM_Campo = "DS_ContaGer";
            this.DS_ContaGer.NM_CampoBusca = "DS_ContaGer";
            this.DS_ContaGer.NM_Param = "@P_DS_CONTAGER";
            this.DS_ContaGer.QTD_Zero = 0;
            this.DS_ContaGer.ST_AutoInc = false;
            this.DS_ContaGer.ST_DisableAuto = false;
            this.DS_ContaGer.ST_Float = false;
            this.DS_ContaGer.ST_Gravar = false;
            this.DS_ContaGer.ST_Int = false;
            this.DS_ContaGer.ST_LimpaCampo = true;
            this.DS_ContaGer.ST_NotNull = false;
            this.DS_ContaGer.ST_PrimaryKey = false;
            this.DS_ContaGer.TextOld = null;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // BB_Historico
            // 
            this.BB_Historico.FlatAppearance.BorderColor = System.Drawing.Color.White;
            resources.ApplyResources(this.BB_Historico, "BB_Historico");
            this.BB_Historico.Name = "BB_Historico";
            this.BB_Historico.UseVisualStyleBackColor = true;
            this.BB_Historico.Click += new System.EventHandler(this.BB_Historico_Click);
            // 
            // BB_ContaGer
            // 
            this.BB_ContaGer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            resources.ApplyResources(this.BB_ContaGer, "BB_ContaGer");
            this.BB_ContaGer.Name = "BB_ContaGer";
            this.BB_ContaGer.UseVisualStyleBackColor = true;
            this.BB_ContaGer.Click += new System.EventHandler(this.BB_ContaGer_Click);
            // 
            // CD_ContaGer
            // 
            this.CD_ContaGer.BackColor = System.Drawing.SystemColors.Window;
            this.CD_ContaGer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_ContaGer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsLanCaixa, "Cd_ContaGer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_ContaGer, "CD_ContaGer");
            this.CD_ContaGer.Name = "CD_ContaGer";
            this.CD_ContaGer.NM_Alias = "";
            this.CD_ContaGer.NM_Campo = "CD_ContaGer";
            this.CD_ContaGer.NM_CampoBusca = "CD_ContaGer";
            this.CD_ContaGer.NM_Param = "@P_CD_CONTAGER";
            this.CD_ContaGer.QTD_Zero = 0;
            this.CD_ContaGer.ST_AutoInc = false;
            this.CD_ContaGer.ST_DisableAuto = false;
            this.CD_ContaGer.ST_Float = false;
            this.CD_ContaGer.ST_Gravar = true;
            this.CD_ContaGer.ST_Int = false;
            this.CD_ContaGer.ST_LimpaCampo = true;
            this.CD_ContaGer.ST_NotNull = true;
            this.CD_ContaGer.ST_PrimaryKey = false;
            this.CD_ContaGer.TextOld = null;
            this.CD_ContaGer.Leave += new System.EventHandler(this.CD_ContaGer_Leave);
            // 
            // CD_Historico
            // 
            this.CD_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsLanCaixa, "Cd_Historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Historico, "CD_Historico");
            this.CD_Historico.Name = "CD_Historico";
            this.CD_Historico.NM_Alias = "";
            this.CD_Historico.NM_Campo = "CD_Historico";
            this.CD_Historico.NM_CampoBusca = "CD_Historico";
            this.CD_Historico.NM_Param = "@P_CD_HISTORICO";
            this.CD_Historico.QTD_Zero = 0;
            this.CD_Historico.ST_AutoInc = false;
            this.CD_Historico.ST_DisableAuto = false;
            this.CD_Historico.ST_Float = false;
            this.CD_Historico.ST_Gravar = true;
            this.CD_Historico.ST_Int = false;
            this.CD_Historico.ST_LimpaCampo = true;
            this.CD_Historico.ST_NotNull = true;
            this.CD_Historico.ST_PrimaryKey = false;
            this.CD_Historico.TextOld = null;
            this.CD_Historico.Click += new System.EventHandler(this.CD_Historico_Leave);
            this.CD_Historico.Leave += new System.EventHandler(this.CD_Historico_Leave);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // CD_LanctoCaixa
            // 
            this.CD_LanctoCaixa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_LanctoCaixa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_LanctoCaixa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_LanctoCaixa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsLanCaixa, "Cd_LanctoCaixa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_LanctoCaixa, "CD_LanctoCaixa");
            this.CD_LanctoCaixa.Name = "CD_LanctoCaixa";
            this.CD_LanctoCaixa.NM_Alias = "";
            this.CD_LanctoCaixa.NM_Campo = "CD_LanctoCaixa";
            this.CD_LanctoCaixa.NM_CampoBusca = "CD_LanctoCaixa";
            this.CD_LanctoCaixa.NM_Param = "@P_CD_LANCTOCAIXA";
            this.CD_LanctoCaixa.QTD_Zero = 0;
            this.CD_LanctoCaixa.ReadOnly = true;
            this.CD_LanctoCaixa.ST_AutoInc = false;
            this.CD_LanctoCaixa.ST_DisableAuto = false;
            this.CD_LanctoCaixa.ST_Float = false;
            this.CD_LanctoCaixa.ST_Gravar = true;
            this.CD_LanctoCaixa.ST_Int = false;
            this.CD_LanctoCaixa.ST_LimpaCampo = true;
            this.CD_LanctoCaixa.ST_NotNull = true;
            this.CD_LanctoCaixa.ST_PrimaryKey = true;
            this.CD_LanctoCaixa.TextOld = null;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // pValores
            // 
            this.pValores.BackColor = System.Drawing.Color.Silver;
            this.pValores.Controls.Add(this.VL_Pagar);
            this.pValores.Controls.Add(this.label14);
            this.pValores.Controls.Add(this.VL_Receber);
            this.pValores.Controls.Add(this.label15);
            resources.ApplyResources(this.pValores, "pValores");
            this.pValores.Name = "pValores";
            this.pValores.NM_ProcDeletar = "";
            this.pValores.NM_ProcGravar = "";
            // 
            // VL_Pagar
            // 
            this.VL_Pagar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dsLanCaixa, "Vl_PAGAR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Pagar.DecimalPlaces = 2;
            resources.ApplyResources(this.VL_Pagar, "VL_Pagar");
            this.VL_Pagar.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.VL_Pagar.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.VL_Pagar.Name = "VL_Pagar";
            this.VL_Pagar.NM_Alias = "";
            this.VL_Pagar.NM_Campo = "VL_Pagar";
            this.VL_Pagar.NM_Param = "@P_VL_PAGAR";
            this.VL_Pagar.Operador = "";
            this.VL_Pagar.ST_AutoInc = false;
            this.VL_Pagar.ST_DisableAuto = false;
            this.VL_Pagar.ST_Gravar = true;
            this.VL_Pagar.ST_LimparCampo = true;
            this.VL_Pagar.ST_NotNull = false;
            this.VL_Pagar.ST_PrimaryKey = false;
            this.VL_Pagar.Enter += new System.EventHandler(this.VL_Pagar_Enter);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // VL_Receber
            // 
            this.VL_Receber.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dsLanCaixa, "Vl_RECEBER", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Receber.DecimalPlaces = 2;
            resources.ApplyResources(this.VL_Receber, "VL_Receber");
            this.VL_Receber.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.VL_Receber.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.VL_Receber.Name = "VL_Receber";
            this.VL_Receber.NM_Alias = "";
            this.VL_Receber.NM_Campo = "VL_Receber";
            this.VL_Receber.NM_Param = "@P_VL_RECEBER";
            this.VL_Receber.Operador = "";
            this.VL_Receber.ST_AutoInc = false;
            this.VL_Receber.ST_DisableAuto = false;
            this.VL_Receber.ST_Gravar = true;
            this.VL_Receber.ST_LimparCampo = true;
            this.VL_Receber.ST_NotNull = false;
            this.VL_Receber.ST_PrimaryKey = false;
            this.VL_Receber.Enter += new System.EventHandler(this.VL_Receber_Enter);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // TFLanCaixa
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanCaixa";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanCaixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanCaixa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsLanCaixa)).EndInit();
            this.rg_TP_Movimento.ResumeLayout(false);
            this.rg_TP_Movimento.PerformLayout();
            this.pValores.ResumeLayout(false);
            this.pValores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Pagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Receber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        public System.Windows.Forms.BindingSource dsLanCaixa;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault NM_Empresa;
        public System.Windows.Forms.Button BB_Empresa;
        public Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault DS_ContaGer;
        public System.Windows.Forms.Button BB_ContaGer;
        public Componentes.EditDefault CD_ContaGer;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault CD_LanctoCaixa;
        private System.Windows.Forms.Label label4;
        private Componentes.PanelDados pValores;
        public Componentes.RadioButtonDefault RB_Pagar;
        public Componentes.RadioButtonDefault RB_Receber;
        private Componentes.EditDefault DS_Historico;
        public System.Windows.Forms.Button BB_Historico;
        public Componentes.EditDefault ComplHistorico;
        public Componentes.EditDefault CD_Historico;
        public Componentes.EditData DT_Lancto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        public Componentes.EditFloat VL_Receber;
        public Componentes.EditFloat VL_Pagar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        public Componentes.EditDefault Nr_Docto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox rg_TP_Movimento;
        private System.Windows.Forms.Label label1;
        public Componentes.EditDefault NM_Clifor;
        private System.Windows.Forms.Button bb_cadhistorico;
    }
}