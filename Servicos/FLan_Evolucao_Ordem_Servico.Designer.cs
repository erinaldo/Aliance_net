namespace Servicos
{
    partial class TFLan_Evolucao_Ordem_Servico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLan_Evolucao_Ordem_Servico));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pnl_Evolucao = new Componentes.PanelDados(this.components);
            this.cbEtapa = new Componentes.ComboBoxDefault(this.components);
            this.BS_Evolucao = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Endereco = new Componentes.EditDefault(this.components);
            this.BB_Endereco = new System.Windows.Forms.Button();
            this.CD_Endereco = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bbAddOficina = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.bb_Oficina = new System.Windows.Forms.Button();
            this.nm_cliforOficina = new Componentes.EditDefault(this.components);
            this.cd_cliforOficina = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.BB_Tecnico = new System.Windows.Forms.Button();
            this.RG_Data = new Componentes.RadioGroup(this.components);
            this.panelDados6 = new Componentes.PanelDados(this.components);
            this.DT_Final = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.DT_Inicio = new Componentes.EditData(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.DS_Evolucao = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.DS_Funcao = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ID_Tecnico = new Componentes.EditDefault(this.components);
            this.dsetapaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stiniciarOSboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stfinalizarOSboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stetapaorcamentoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stenvterceiroboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.barraMenu.SuspendLayout();
            this.pnl_Evolucao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Evolucao)).BeginInit();
            this.RG_Data.SuspendLayout();
            this.panelDados6.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
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
            // pnl_Evolucao
            // 
            this.pnl_Evolucao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Evolucao.Controls.Add(this.cbEtapa);
            this.pnl_Evolucao.Controls.Add(this.DS_Endereco);
            this.pnl_Evolucao.Controls.Add(this.BB_Endereco);
            this.pnl_Evolucao.Controls.Add(this.CD_Endereco);
            this.pnl_Evolucao.Controls.Add(this.label4);
            this.pnl_Evolucao.Controls.Add(this.bbAddOficina);
            this.pnl_Evolucao.Controls.Add(this.label15);
            this.pnl_Evolucao.Controls.Add(this.bb_Oficina);
            this.pnl_Evolucao.Controls.Add(this.nm_cliforOficina);
            this.pnl_Evolucao.Controls.Add(this.cd_cliforOficina);
            this.pnl_Evolucao.Controls.Add(this.label1);
            this.pnl_Evolucao.Controls.Add(this.BB_Tecnico);
            this.pnl_Evolucao.Controls.Add(this.RG_Data);
            this.pnl_Evolucao.Controls.Add(this.DS_Evolucao);
            this.pnl_Evolucao.Controls.Add(this.label5);
            this.pnl_Evolucao.Controls.Add(this.DS_Funcao);
            this.pnl_Evolucao.Controls.Add(this.label2);
            this.pnl_Evolucao.Controls.Add(this.ID_Tecnico);
            resources.ApplyResources(this.pnl_Evolucao, "pnl_Evolucao");
            this.pnl_Evolucao.Name = "pnl_Evolucao";
            this.pnl_Evolucao.NM_ProcDeletar = "";
            this.pnl_Evolucao.NM_ProcGravar = "";
            // 
            // cbEtapa
            // 
            this.cbEtapa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_Evolucao, "Id_etapa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEtapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEtapa.FormattingEnabled = true;
            resources.ApplyResources(this.cbEtapa, "cbEtapa");
            this.cbEtapa.Name = "cbEtapa";
            this.cbEtapa.NM_Alias = "";
            this.cbEtapa.NM_Campo = "";
            this.cbEtapa.NM_Param = "";
            this.cbEtapa.ST_Gravar = true;
            this.cbEtapa.ST_LimparCampo = true;
            this.cbEtapa.ST_NotNull = true;
            // 
            // BS_Evolucao
            // 
            this.BS_Evolucao.DataSource = typeof(CamadaDados.Servicos.TList_LanServicoEvolucao);
            // 
            // DS_Endereco
            // 
            this.DS_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Evolucao, "Ds_EndOficina", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Endereco, "DS_Endereco");
            this.DS_Endereco.Name = "DS_Endereco";
            this.DS_Endereco.NM_Alias = "";
            this.DS_Endereco.NM_Campo = "DS_Endereco";
            this.DS_Endereco.NM_CampoBusca = "DS_Endereco";
            this.DS_Endereco.NM_Param = "@P_DS_ENDERECO";
            this.DS_Endereco.QTD_Zero = 0;
            this.DS_Endereco.ReadOnly = true;
            this.DS_Endereco.ST_AutoInc = false;
            this.DS_Endereco.ST_DisableAuto = false;
            this.DS_Endereco.ST_Float = false;
            this.DS_Endereco.ST_Gravar = false;
            this.DS_Endereco.ST_Int = false;
            this.DS_Endereco.ST_LimpaCampo = true;
            this.DS_Endereco.ST_NotNull = false;
            this.DS_Endereco.ST_PrimaryKey = false;
            this.DS_Endereco.TextOld = null;
            // 
            // BB_Endereco
            // 
            resources.ApplyResources(this.BB_Endereco, "BB_Endereco");
            this.BB_Endereco.Name = "BB_Endereco";
            this.BB_Endereco.UseVisualStyleBackColor = true;
            this.BB_Endereco.Click += new System.EventHandler(this.BB_Endereco_Click);
            // 
            // CD_Endereco
            // 
            this.CD_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Evolucao, "Cd_EndOficina", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Endereco, "CD_Endereco");
            this.CD_Endereco.Name = "CD_Endereco";
            this.CD_Endereco.NM_Alias = "";
            this.CD_Endereco.NM_Campo = "CD_Endereco";
            this.CD_Endereco.NM_CampoBusca = "CD_Endereco";
            this.CD_Endereco.NM_Param = "@P_CD_ENDERECO";
            this.CD_Endereco.QTD_Zero = 0;
            this.CD_Endereco.ST_AutoInc = false;
            this.CD_Endereco.ST_DisableAuto = false;
            this.CD_Endereco.ST_Float = false;
            this.CD_Endereco.ST_Gravar = true;
            this.CD_Endereco.ST_Int = false;
            this.CD_Endereco.ST_LimpaCampo = true;
            this.CD_Endereco.ST_NotNull = true;
            this.CD_Endereco.ST_PrimaryKey = false;
            this.CD_Endereco.TextOld = null;
            this.CD_Endereco.Leave += new System.EventHandler(this.CD_Endereco_Leave);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // bbAddOficina
            // 
            resources.ApplyResources(this.bbAddOficina, "bbAddOficina");
            this.bbAddOficina.Name = "bbAddOficina";
            this.bbAddOficina.UseVisualStyleBackColor = true;
            this.bbAddOficina.Click += new System.EventHandler(this.bbAddOficina_Click);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // bb_Oficina
            // 
            resources.ApplyResources(this.bb_Oficina, "bb_Oficina");
            this.bb_Oficina.Name = "bb_Oficina";
            this.bb_Oficina.UseVisualStyleBackColor = true;
            this.bb_Oficina.Click += new System.EventHandler(this.bb_Oficina_Click);
            // 
            // nm_cliforOficina
            // 
            this.nm_cliforOficina.BackColor = System.Drawing.SystemColors.Window;
            this.nm_cliforOficina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_cliforOficina.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_cliforOficina.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Evolucao, "Nm_oficina", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nm_cliforOficina, "nm_cliforOficina");
            this.nm_cliforOficina.Name = "nm_cliforOficina";
            this.nm_cliforOficina.NM_Alias = "";
            this.nm_cliforOficina.NM_Campo = "nm_clifor";
            this.nm_cliforOficina.NM_CampoBusca = "nm_clifor";
            this.nm_cliforOficina.NM_Param = "@P_NM_CLIFOR";
            this.nm_cliforOficina.QTD_Zero = 0;
            this.nm_cliforOficina.ST_AutoInc = false;
            this.nm_cliforOficina.ST_DisableAuto = false;
            this.nm_cliforOficina.ST_Float = false;
            this.nm_cliforOficina.ST_Gravar = false;
            this.nm_cliforOficina.ST_Int = false;
            this.nm_cliforOficina.ST_LimpaCampo = true;
            this.nm_cliforOficina.ST_NotNull = false;
            this.nm_cliforOficina.ST_PrimaryKey = false;
            this.nm_cliforOficina.TextOld = null;
            // 
            // cd_cliforOficina
            // 
            this.cd_cliforOficina.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cliforOficina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_cliforOficina.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cliforOficina.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Evolucao, "Cd_oficina", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_cliforOficina, "cd_cliforOficina");
            this.cd_cliforOficina.Name = "cd_cliforOficina";
            this.cd_cliforOficina.NM_Alias = "";
            this.cd_cliforOficina.NM_Campo = "cd_clifor";
            this.cd_cliforOficina.NM_CampoBusca = "cd_clifor";
            this.cd_cliforOficina.NM_Param = "@P_CD_CLIFOR";
            this.cd_cliforOficina.QTD_Zero = 0;
            this.cd_cliforOficina.ST_AutoInc = false;
            this.cd_cliforOficina.ST_DisableAuto = false;
            this.cd_cliforOficina.ST_Float = false;
            this.cd_cliforOficina.ST_Gravar = true;
            this.cd_cliforOficina.ST_Int = false;
            this.cd_cliforOficina.ST_LimpaCampo = true;
            this.cd_cliforOficina.ST_NotNull = false;
            this.cd_cliforOficina.ST_PrimaryKey = false;
            this.cd_cliforOficina.TextOld = null;
            this.cd_cliforOficina.Leave += new System.EventHandler(this.cd_cliforOficina_Leave);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // BB_Tecnico
            // 
            resources.ApplyResources(this.BB_Tecnico, "BB_Tecnico");
            this.BB_Tecnico.Name = "BB_Tecnico";
            this.BB_Tecnico.UseVisualStyleBackColor = true;
            this.BB_Tecnico.Click += new System.EventHandler(this.BB_Tecnico_Click);
            // 
            // RG_Data
            // 
            this.RG_Data.Controls.Add(this.panelDados6);
            resources.ApplyResources(this.RG_Data, "RG_Data");
            this.RG_Data.Name = "RG_Data";
            this.RG_Data.NM_Alias = "a";
            this.RG_Data.NM_Campo = "TP_Movimento";
            this.RG_Data.NM_Param = "@P_TP_MOVIMENTO";
            this.RG_Data.NM_Valor = "";
            this.RG_Data.ST_Gravar = false;
            this.RG_Data.ST_NotNull = false;
            this.RG_Data.TabStop = false;
            // 
            // panelDados6
            // 
            this.panelDados6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.panelDados6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados6.Controls.Add(this.DT_Final);
            this.panelDados6.Controls.Add(this.label8);
            this.panelDados6.Controls.Add(this.DT_Inicio);
            this.panelDados6.Controls.Add(this.label6);
            resources.ApplyResources(this.panelDados6, "panelDados6");
            this.panelDados6.Name = "panelDados6";
            this.panelDados6.NM_ProcDeletar = "";
            this.panelDados6.NM_ProcGravar = "";
            // 
            // DT_Final
            // 
            this.DT_Final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Final.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.DT_Final.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Evolucao, "Dt_previstaterminostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DT_Final, "DT_Final");
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.NM_Alias = "";
            this.DT_Final.NM_Campo = "";
            this.DT_Final.NM_CampoBusca = "";
            this.DT_Final.NM_Param = "";
            this.DT_Final.Operador = "";
            this.DT_Final.ST_Gravar = false;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = true;
            this.DT_Final.ST_PrimaryKey = false;
            this.DT_Final.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // DT_Inicio
            // 
            this.DT_Inicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Inicio.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.DT_Inicio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Evolucao, "Dt_iniciostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DT_Inicio, "DT_Inicio");
            this.DT_Inicio.Name = "DT_Inicio";
            this.DT_Inicio.NM_Alias = "";
            this.DT_Inicio.NM_Campo = "";
            this.DT_Inicio.NM_CampoBusca = "";
            this.DT_Inicio.NM_Param = "";
            this.DT_Inicio.Operador = "";
            this.DT_Inicio.ST_Gravar = false;
            this.DT_Inicio.ST_LimpaCampo = true;
            this.DT_Inicio.ST_NotNull = true;
            this.DT_Inicio.ST_PrimaryKey = false;
            this.DT_Inicio.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // DS_Evolucao
            // 
            this.DS_Evolucao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Evolucao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Evolucao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Evolucao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Evolucao, "Ds_evolucao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Evolucao, "DS_Evolucao");
            this.DS_Evolucao.Name = "DS_Evolucao";
            this.DS_Evolucao.NM_Alias = "";
            this.DS_Evolucao.NM_Campo = "";
            this.DS_Evolucao.NM_CampoBusca = "";
            this.DS_Evolucao.NM_Param = "";
            this.DS_Evolucao.QTD_Zero = 0;
            this.DS_Evolucao.ST_AutoInc = false;
            this.DS_Evolucao.ST_DisableAuto = false;
            this.DS_Evolucao.ST_Float = false;
            this.DS_Evolucao.ST_Gravar = true;
            this.DS_Evolucao.ST_Int = false;
            this.DS_Evolucao.ST_LimpaCampo = true;
            this.DS_Evolucao.ST_NotNull = false;
            this.DS_Evolucao.ST_PrimaryKey = false;
            this.DS_Evolucao.TextOld = null;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // DS_Funcao
            // 
            this.DS_Funcao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Funcao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Funcao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Funcao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Evolucao, "NM_Tecnico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Funcao, "DS_Funcao");
            this.DS_Funcao.Name = "DS_Funcao";
            this.DS_Funcao.NM_Alias = "";
            this.DS_Funcao.NM_Campo = "nm_clifor";
            this.DS_Funcao.NM_CampoBusca = "nm_clifor";
            this.DS_Funcao.NM_Param = "@P_NM_CLIFOR";
            this.DS_Funcao.QTD_Zero = 0;
            this.DS_Funcao.ReadOnly = true;
            this.DS_Funcao.ST_AutoInc = false;
            this.DS_Funcao.ST_DisableAuto = false;
            this.DS_Funcao.ST_Float = false;
            this.DS_Funcao.ST_Gravar = false;
            this.DS_Funcao.ST_Int = false;
            this.DS_Funcao.ST_LimpaCampo = true;
            this.DS_Funcao.ST_NotNull = false;
            this.DS_Funcao.ST_PrimaryKey = false;
            this.DS_Funcao.TextOld = null;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ID_Tecnico
            // 
            this.ID_Tecnico.BackColor = System.Drawing.Color.White;
            this.ID_Tecnico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_Tecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Tecnico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Evolucao, "Cd_tecnico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ID_Tecnico, "ID_Tecnico");
            this.ID_Tecnico.Name = "ID_Tecnico";
            this.ID_Tecnico.NM_Alias = "";
            this.ID_Tecnico.NM_Campo = "cd_clifor";
            this.ID_Tecnico.NM_CampoBusca = "cd_clifor";
            this.ID_Tecnico.NM_Param = "@P_CD_CLIFOR";
            this.ID_Tecnico.QTD_Zero = 0;
            this.ID_Tecnico.ST_AutoInc = false;
            this.ID_Tecnico.ST_DisableAuto = false;
            this.ID_Tecnico.ST_Float = false;
            this.ID_Tecnico.ST_Gravar = true;
            this.ID_Tecnico.ST_Int = false;
            this.ID_Tecnico.ST_LimpaCampo = true;
            this.ID_Tecnico.ST_NotNull = false;
            this.ID_Tecnico.ST_PrimaryKey = false;
            this.ID_Tecnico.TextOld = null;
            this.ID_Tecnico.Leave += new System.EventHandler(this.ID_Tecnico_Leave);
            // 
            // dsetapaDataGridViewTextBoxColumn
            // 
            this.dsetapaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsetapaDataGridViewTextBoxColumn.DataPropertyName = "Ds_etapa";
            resources.ApplyResources(this.dsetapaDataGridViewTextBoxColumn, "dsetapaDataGridViewTextBoxColumn");
            this.dsetapaDataGridViewTextBoxColumn.Name = "dsetapaDataGridViewTextBoxColumn";
            this.dsetapaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stiniciarOSboolDataGridViewCheckBoxColumn
            // 
            this.stiniciarOSboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stiniciarOSboolDataGridViewCheckBoxColumn.DataPropertyName = "St_iniciarOSbool";
            resources.ApplyResources(this.stiniciarOSboolDataGridViewCheckBoxColumn, "stiniciarOSboolDataGridViewCheckBoxColumn");
            this.stiniciarOSboolDataGridViewCheckBoxColumn.Name = "stiniciarOSboolDataGridViewCheckBoxColumn";
            this.stiniciarOSboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // stfinalizarOSboolDataGridViewCheckBoxColumn
            // 
            this.stfinalizarOSboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stfinalizarOSboolDataGridViewCheckBoxColumn.DataPropertyName = "St_finalizarOSbool";
            resources.ApplyResources(this.stfinalizarOSboolDataGridViewCheckBoxColumn, "stfinalizarOSboolDataGridViewCheckBoxColumn");
            this.stfinalizarOSboolDataGridViewCheckBoxColumn.Name = "stfinalizarOSboolDataGridViewCheckBoxColumn";
            this.stfinalizarOSboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // stetapaorcamentoboolDataGridViewCheckBoxColumn
            // 
            this.stetapaorcamentoboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stetapaorcamentoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_etapaorcamentobool";
            resources.ApplyResources(this.stetapaorcamentoboolDataGridViewCheckBoxColumn, "stetapaorcamentoboolDataGridViewCheckBoxColumn");
            this.stetapaorcamentoboolDataGridViewCheckBoxColumn.Name = "stetapaorcamentoboolDataGridViewCheckBoxColumn";
            this.stetapaorcamentoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // stenvterceiroboolDataGridViewCheckBoxColumn
            // 
            this.stenvterceiroboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stenvterceiroboolDataGridViewCheckBoxColumn.DataPropertyName = "St_envterceirobool";
            resources.ApplyResources(this.stenvterceiroboolDataGridViewCheckBoxColumn, "stenvterceiroboolDataGridViewCheckBoxColumn");
            this.stenvterceiroboolDataGridViewCheckBoxColumn.Name = "stenvterceiroboolDataGridViewCheckBoxColumn";
            this.stenvterceiroboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // TFLan_Evolucao_Ordem_Servico
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_Evolucao);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLan_Evolucao_Ordem_Servico";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FLan_Evolucao_Ordem_Servico_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FLan_Evolucao_Ordem_Servico_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pnl_Evolucao.ResumeLayout(false);
            this.pnl_Evolucao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Evolucao)).EndInit();
            this.RG_Data.ResumeLayout(false);
            this.panelDados6.ResumeLayout(false);
            this.panelDados6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pnl_Evolucao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private Componentes.RadioGroup RG_Data;
        private Componentes.PanelDados panelDados6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        public Componentes.EditDefault DS_Funcao;
        public Componentes.EditDefault ID_Tecnico;
        public Componentes.EditDefault DS_Evolucao;
        public Componentes.EditData DT_Inicio;
        public System.Windows.Forms.BindingSource BS_Evolucao;
        public System.Windows.Forms.Button BB_Tecnico;
        private System.Windows.Forms.Label label1;
        public Componentes.EditData DT_Final;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsetapaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stiniciarOSboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stfinalizarOSboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stetapaorcamentoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stenvterceiroboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button bbAddOficina;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bb_Oficina;
        private Componentes.EditDefault nm_cliforOficina;
        private Componentes.EditDefault cd_cliforOficina;
        private Componentes.EditDefault DS_Endereco;
        private System.Windows.Forms.Button BB_Endereco;
        private Componentes.EditDefault CD_Endereco;
        private System.Windows.Forms.Label label4;
        private Componentes.ComboBoxDefault cbEtapa;
    }
}