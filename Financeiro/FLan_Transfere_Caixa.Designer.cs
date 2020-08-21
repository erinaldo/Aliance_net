namespace Financeiro
{
    partial class TFLan_Transfere_Caixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLan_Transfere_Caixa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_Transfere = new Componentes.PanelDados(this.components);
            this.DS_ContaGer_Saida = new Componentes.EditDefault(this.components);
            this.CD_ContaGer_Saida = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Nr_Docto = new Componentes.EditDefault(this.components);
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
            this.label3 = new System.Windows.Forms.Label();
            this.pValores = new Componentes.PanelDados(this.components);
            this.operador = new Componentes.ComboBoxDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.vl_cotacao = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.vl_saida_transferencia = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.VL_Transferencia = new Componentes.EditFloat(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.BS_Transfere_Caixa = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnl_Transfere.SuspendLayout();
            this.pValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_cotacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saida_transferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Transferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Transfere_Caixa)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Font = null;
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AccessibleDescription = null;
            this.BB_Gravar.AccessibleName = null;
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.BackgroundImage = null;
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AccessibleDescription = null;
            this.BB_Cancelar.AccessibleName = null;
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.BackgroundImage = null;
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AccessibleDescription = null;
            this.tableLayoutPanel1.AccessibleName = null;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.BackgroundImage = null;
            this.tableLayoutPanel1.Controls.Add(this.pnl_Transfere, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pValores, 0, 1);
            this.tableLayoutPanel1.Font = null;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // pnl_Transfere
            // 
            this.pnl_Transfere.AccessibleDescription = null;
            this.pnl_Transfere.AccessibleName = null;
            resources.ApplyResources(this.pnl_Transfere, "pnl_Transfere");
            this.pnl_Transfere.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_Transfere.BackgroundImage = null;
            this.pnl_Transfere.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Transfere.Controls.Add(this.DS_ContaGer_Saida);
            this.pnl_Transfere.Controls.Add(this.CD_ContaGer_Saida);
            this.pnl_Transfere.Controls.Add(this.label1);
            this.pnl_Transfere.Controls.Add(this.Nr_Docto);
            this.pnl_Transfere.Controls.Add(this.label9);
            this.pnl_Transfere.Controls.Add(this.NM_Empresa);
            this.pnl_Transfere.Controls.Add(this.BB_Empresa);
            this.pnl_Transfere.Controls.Add(this.CD_Empresa);
            this.pnl_Transfere.Controls.Add(this.label8);
            this.pnl_Transfere.Controls.Add(this.DT_Lancto);
            this.pnl_Transfere.Controls.Add(this.label7);
            this.pnl_Transfere.Controls.Add(this.ComplHistorico);
            this.pnl_Transfere.Controls.Add(this.DS_Historico);
            this.pnl_Transfere.Controls.Add(this.DS_ContaGer);
            this.pnl_Transfere.Controls.Add(this.label5);
            this.pnl_Transfere.Controls.Add(this.BB_Historico);
            this.pnl_Transfere.Controls.Add(this.BB_ContaGer);
            this.pnl_Transfere.Controls.Add(this.CD_ContaGer);
            this.pnl_Transfere.Controls.Add(this.CD_Historico);
            this.pnl_Transfere.Controls.Add(this.label6);
            this.pnl_Transfere.Controls.Add(this.label3);
            this.pnl_Transfere.Font = null;
            this.pnl_Transfere.Name = "pnl_Transfere";
            this.pnl_Transfere.NM_ProcDeletar = "";
            this.pnl_Transfere.NM_ProcGravar = "";
            // 
            // DS_ContaGer_Saida
            // 
            this.DS_ContaGer_Saida.AccessibleDescription = null;
            this.DS_ContaGer_Saida.AccessibleName = null;
            resources.ApplyResources(this.DS_ContaGer_Saida, "DS_ContaGer_Saida");
            this.DS_ContaGer_Saida.BackColor = System.Drawing.SystemColors.Window;
            this.DS_ContaGer_Saida.BackgroundImage = null;
            this.DS_ContaGer_Saida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_ContaGer_Saida.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "DS_ContaGer_Saida", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_ContaGer_Saida.Font = null;
            this.DS_ContaGer_Saida.Name = "DS_ContaGer_Saida";
            this.DS_ContaGer_Saida.NM_Alias = "";
            this.DS_ContaGer_Saida.NM_Campo = "DS_ContaGer";
            this.DS_ContaGer_Saida.NM_CampoBusca = "DS_ContaGer";
            this.DS_ContaGer_Saida.NM_Param = "@P_DS_CONTAGER";
            this.DS_ContaGer_Saida.QTD_Zero = 0;
            this.DS_ContaGer_Saida.ST_AutoInc = false;
            this.DS_ContaGer_Saida.ST_DisableAuto = false;
            this.DS_ContaGer_Saida.ST_Float = false;
            this.DS_ContaGer_Saida.ST_Gravar = false;
            this.DS_ContaGer_Saida.ST_Int = false;
            this.DS_ContaGer_Saida.ST_LimpaCampo = true;
            this.DS_ContaGer_Saida.ST_NotNull = false;
            this.DS_ContaGer_Saida.ST_PrimaryKey = false;
            // 
            // CD_ContaGer_Saida
            // 
            this.CD_ContaGer_Saida.AccessibleDescription = null;
            this.CD_ContaGer_Saida.AccessibleName = null;
            resources.ApplyResources(this.CD_ContaGer_Saida, "CD_ContaGer_Saida");
            this.CD_ContaGer_Saida.BackColor = System.Drawing.SystemColors.Window;
            this.CD_ContaGer_Saida.BackgroundImage = null;
            this.CD_ContaGer_Saida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_ContaGer_Saida.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "CD_ContaGer_Saida", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_ContaGer_Saida.Font = null;
            this.CD_ContaGer_Saida.Name = "CD_ContaGer_Saida";
            this.CD_ContaGer_Saida.NM_Alias = "";
            this.CD_ContaGer_Saida.NM_Campo = "CD_ContaGer";
            this.CD_ContaGer_Saida.NM_CampoBusca = "CD_ContaGer";
            this.CD_ContaGer_Saida.NM_Param = "@P_CD_CONTAGER";
            this.CD_ContaGer_Saida.QTD_Zero = 0;
            this.CD_ContaGer_Saida.ST_AutoInc = false;
            this.CD_ContaGer_Saida.ST_DisableAuto = false;
            this.CD_ContaGer_Saida.ST_Float = false;
            this.CD_ContaGer_Saida.ST_Gravar = true;
            this.CD_ContaGer_Saida.ST_Int = false;
            this.CD_ContaGer_Saida.ST_LimpaCampo = true;
            this.CD_ContaGer_Saida.ST_NotNull = true;
            this.CD_ContaGer_Saida.ST_PrimaryKey = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Nr_Docto
            // 
            this.Nr_Docto.AccessibleDescription = null;
            this.Nr_Docto.AccessibleName = null;
            resources.ApplyResources(this.Nr_Docto, "Nr_Docto");
            this.Nr_Docto.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_Docto.BackgroundImage = null;
            this.Nr_Docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_Docto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "NR_Docto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nr_Docto.Font = null;
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
            // 
            // label9
            // 
            this.label9.AccessibleDescription = null;
            this.label9.AccessibleName = null;
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.AccessibleDescription = null;
            this.NM_Empresa.AccessibleName = null;
            resources.ApplyResources(this.NM_Empresa, "NM_Empresa");
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BackgroundImage = null;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "NM_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Font = null;
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
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.AccessibleDescription = null;
            this.BB_Empresa.AccessibleName = null;
            resources.ApplyResources(this.BB_Empresa, "BB_Empresa");
            this.BB_Empresa.BackgroundImage = null;
            this.BB_Empresa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Empresa.Font = null;
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.AccessibleDescription = null;
            this.CD_Empresa.AccessibleName = null;
            resources.ApplyResources(this.CD_Empresa, "CD_Empresa");
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BackgroundImage = null;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "CD_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Font = null;
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
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = null;
            this.label8.AccessibleName = null;
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // DT_Lancto
            // 
            this.DT_Lancto.AccessibleDescription = null;
            this.DT_Lancto.AccessibleName = null;
            resources.ApplyResources(this.DT_Lancto, "DT_Lancto");
            this.DT_Lancto.BackgroundImage = null;
            this.DT_Lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "DT_Lancto_String", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Lancto.Font = null;
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
            // 
            // label7
            // 
            this.label7.AccessibleDescription = null;
            this.label7.AccessibleName = null;
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // ComplHistorico
            // 
            this.ComplHistorico.AccessibleDescription = null;
            this.ComplHistorico.AccessibleName = null;
            resources.ApplyResources(this.ComplHistorico, "ComplHistorico");
            this.ComplHistorico.BackColor = System.Drawing.SystemColors.Window;
            this.ComplHistorico.BackgroundImage = null;
            this.ComplHistorico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ComplHistorico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "Complemento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ComplHistorico.Font = null;
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
            // 
            // DS_Historico
            // 
            this.DS_Historico.AccessibleDescription = null;
            this.DS_Historico.AccessibleName = null;
            resources.ApplyResources(this.DS_Historico, "DS_Historico");
            this.DS_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Historico.BackgroundImage = null;
            this.DS_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "DS_Historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Historico.Font = null;
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
            // 
            // DS_ContaGer
            // 
            this.DS_ContaGer.AccessibleDescription = null;
            this.DS_ContaGer.AccessibleName = null;
            resources.ApplyResources(this.DS_ContaGer, "DS_ContaGer");
            this.DS_ContaGer.BackColor = System.Drawing.SystemColors.Window;
            this.DS_ContaGer.BackgroundImage = null;
            this.DS_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_ContaGer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "DS_ContaGer_Entrada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_ContaGer.Font = null;
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
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // BB_Historico
            // 
            this.BB_Historico.AccessibleDescription = null;
            this.BB_Historico.AccessibleName = null;
            resources.ApplyResources(this.BB_Historico, "BB_Historico");
            this.BB_Historico.BackgroundImage = null;
            this.BB_Historico.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Historico.Font = null;
            this.BB_Historico.Name = "BB_Historico";
            this.BB_Historico.UseVisualStyleBackColor = true;
            this.BB_Historico.Click += new System.EventHandler(this.BB_Historico_Click);
            // 
            // BB_ContaGer
            // 
            this.BB_ContaGer.AccessibleDescription = null;
            this.BB_ContaGer.AccessibleName = null;
            resources.ApplyResources(this.BB_ContaGer, "BB_ContaGer");
            this.BB_ContaGer.BackgroundImage = null;
            this.BB_ContaGer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_ContaGer.Font = null;
            this.BB_ContaGer.Name = "BB_ContaGer";
            this.BB_ContaGer.UseVisualStyleBackColor = true;
            this.BB_ContaGer.Click += new System.EventHandler(this.BB_ContaGer_Click);
            // 
            // CD_ContaGer
            // 
            this.CD_ContaGer.AccessibleDescription = null;
            this.CD_ContaGer.AccessibleName = null;
            resources.ApplyResources(this.CD_ContaGer, "CD_ContaGer");
            this.CD_ContaGer.BackColor = System.Drawing.SystemColors.Window;
            this.CD_ContaGer.BackgroundImage = null;
            this.CD_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_ContaGer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "CD_ContaGer_Entrada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_ContaGer.Font = null;
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
            this.CD_ContaGer.Leave += new System.EventHandler(this.CD_ContaGer_Leave);
            // 
            // CD_Historico
            // 
            this.CD_Historico.AccessibleDescription = null;
            this.CD_Historico.AccessibleName = null;
            resources.ApplyResources(this.CD_Historico, "CD_Historico");
            this.CD_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Historico.BackgroundImage = null;
            this.CD_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "CD_Historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Historico.Font = null;
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
            this.CD_Historico.Leave += new System.EventHandler(this.CD_Historico_Leave);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // pValores
            // 
            this.pValores.AccessibleDescription = null;
            this.pValores.AccessibleName = null;
            resources.ApplyResources(this.pValores, "pValores");
            this.pValores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pValores.BackgroundImage = null;
            this.pValores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pValores.Controls.Add(this.operador);
            this.pValores.Controls.Add(this.label10);
            this.pValores.Controls.Add(this.vl_cotacao);
            this.pValores.Controls.Add(this.label4);
            this.pValores.Controls.Add(this.editDefault2);
            this.pValores.Controls.Add(this.vl_saida_transferencia);
            this.pValores.Controls.Add(this.label2);
            this.pValores.Controls.Add(this.editDefault1);
            this.pValores.Controls.Add(this.VL_Transferencia);
            this.pValores.Controls.Add(this.label14);
            this.pValores.Font = null;
            this.pValores.Name = "pValores";
            this.pValores.NM_ProcDeletar = "";
            this.pValores.NM_ProcGravar = "";
            // 
            // operador
            // 
            this.operador.AccessibleDescription = null;
            this.operador.AccessibleName = null;
            resources.ApplyResources(this.operador, "operador");
            this.operador.BackgroundImage = null;
            this.operador.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_Transfere_Caixa, "Operador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.operador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operador.Font = null;
            this.operador.FormattingEnabled = true;
            this.operador.Name = "operador";
            this.operador.NM_Alias = "";
            this.operador.NM_Campo = "";
            this.operador.NM_Param = "";
            this.operador.ST_Gravar = false;
            this.operador.ST_LimparCampo = true;
            this.operador.ST_NotNull = false;
            // 
            // label10
            // 
            this.label10.AccessibleDescription = null;
            this.label10.AccessibleName = null;
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // vl_cotacao
            // 
            this.vl_cotacao.AccessibleDescription = null;
            this.vl_cotacao.AccessibleName = null;
            resources.ApplyResources(this.vl_cotacao, "vl_cotacao");
            this.vl_cotacao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Transfere_Caixa, "Vl_cotacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_cotacao.DecimalPlaces = 2;
            this.vl_cotacao.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.vl_cotacao.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.vl_cotacao.Name = "vl_cotacao";
            this.vl_cotacao.NM_Alias = "";
            this.vl_cotacao.NM_Campo = "VL_Pagar";
            this.vl_cotacao.NM_Param = "@P_VL_PAGAR";
            this.vl_cotacao.Operador = "";
            this.vl_cotacao.ST_AutoInc = false;
            this.vl_cotacao.ST_DisableAuto = false;
            this.vl_cotacao.ST_Gravar = true;
            this.vl_cotacao.ST_LimparCampo = true;
            this.vl_cotacao.ST_NotNull = true;
            this.vl_cotacao.ST_PrimaryKey = false;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // editDefault2
            // 
            this.editDefault2.AccessibleDescription = null;
            this.editDefault2.AccessibleName = null;
            resources.ApplyResources(this.editDefault2, "editDefault2");
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BackgroundImage = null;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "Sigla_moeda_entrada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "DS_ContaGer";
            this.editDefault2.NM_CampoBusca = "DS_ContaGer";
            this.editDefault2.NM_Param = "@P_DS_CONTAGER";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = false;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = false;
            this.editDefault2.ST_PrimaryKey = false;
            // 
            // vl_saida_transferencia
            // 
            this.vl_saida_transferencia.AccessibleDescription = null;
            this.vl_saida_transferencia.AccessibleName = null;
            resources.ApplyResources(this.vl_saida_transferencia, "vl_saida_transferencia");
            this.vl_saida_transferencia.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Transfere_Caixa, "Vl_saida_transferencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_saida_transferencia.DecimalPlaces = 2;
            this.vl_saida_transferencia.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.vl_saida_transferencia.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.vl_saida_transferencia.Name = "vl_saida_transferencia";
            this.vl_saida_transferencia.NM_Alias = "";
            this.vl_saida_transferencia.NM_Campo = "VL_Pagar";
            this.vl_saida_transferencia.NM_Param = "@P_VL_PAGAR";
            this.vl_saida_transferencia.Operador = "";
            this.vl_saida_transferencia.ST_AutoInc = false;
            this.vl_saida_transferencia.ST_DisableAuto = false;
            this.vl_saida_transferencia.ST_Gravar = true;
            this.vl_saida_transferencia.ST_LimparCampo = true;
            this.vl_saida_transferencia.ST_NotNull = true;
            this.vl_saida_transferencia.ST_PrimaryKey = false;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // editDefault1
            // 
            this.editDefault1.AccessibleDescription = null;
            this.editDefault1.AccessibleName = null;
            resources.ApplyResources(this.editDefault1, "editDefault1");
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BackgroundImage = null;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Transfere_Caixa, "Sigla_moeda_saida", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "DS_ContaGer";
            this.editDefault1.NM_CampoBusca = "DS_ContaGer";
            this.editDefault1.NM_Param = "@P_DS_CONTAGER";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            // 
            // VL_Transferencia
            // 
            this.VL_Transferencia.AccessibleDescription = null;
            this.VL_Transferencia.AccessibleName = null;
            resources.ApplyResources(this.VL_Transferencia, "VL_Transferencia");
            this.VL_Transferencia.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Transfere_Caixa, "Valor_Transferencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Transferencia.DecimalPlaces = 2;
            this.VL_Transferencia.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.VL_Transferencia.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.VL_Transferencia.Name = "VL_Transferencia";
            this.VL_Transferencia.NM_Alias = "";
            this.VL_Transferencia.NM_Campo = "VL_Pagar";
            this.VL_Transferencia.NM_Param = "@P_VL_PAGAR";
            this.VL_Transferencia.Operador = "";
            this.VL_Transferencia.ST_AutoInc = false;
            this.VL_Transferencia.ST_DisableAuto = false;
            this.VL_Transferencia.ST_Gravar = true;
            this.VL_Transferencia.ST_LimparCampo = true;
            this.VL_Transferencia.ST_NotNull = true;
            this.VL_Transferencia.ST_PrimaryKey = false;
            // 
            // label14
            // 
            this.label14.AccessibleDescription = null;
            this.label14.AccessibleName = null;
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // BS_Transfere_Caixa
            // 
            this.BS_Transfere_Caixa.DataSource = typeof(CamadaDados.Financeiro.Caixa.TList_Lan_Transfere_Caixa);
            // 
            // TFLan_Transfere_Caixa
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLan_Transfere_Caixa";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLan_Transfere_Caixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLan_Transfere_Caixa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnl_Transfere.ResumeLayout(false);
            this.pnl_Transfere.PerformLayout();
            this.pValores.ResumeLayout(false);
            this.pValores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_cotacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saida_transferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Transferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Transfere_Caixa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados pnl_Transfere;
        public Componentes.EditDefault Nr_Docto;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button BB_Empresa;
        public Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label8;
        public Componentes.EditData DT_Lancto;
        private System.Windows.Forms.Label label7;
        public Componentes.EditDefault ComplHistorico;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button BB_Historico;
        public System.Windows.Forms.Button BB_ContaGer;
        public Componentes.EditDefault CD_ContaGer;
        public Componentes.EditDefault CD_Historico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private Componentes.PanelDados pValores;
        public Componentes.EditFloat VL_Transferencia;
        private System.Windows.Forms.Label label14;
        public Componentes.EditDefault CD_ContaGer_Saida;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.BindingSource BS_Transfere_Caixa;
        public Componentes.EditDefault NM_Empresa;
        public Componentes.EditDefault DS_Historico;
        public Componentes.EditDefault DS_ContaGer;
        public Componentes.EditDefault DS_ContaGer_Saida;
        public Componentes.EditDefault editDefault1;
        public Componentes.EditFloat vl_cotacao;
        private System.Windows.Forms.Label label4;
        public Componentes.EditDefault editDefault2;
        public Componentes.EditFloat vl_saida_transferencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private Componentes.ComboBoxDefault operador;
    }
}