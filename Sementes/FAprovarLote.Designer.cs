namespace Sementes
{
    partial class TFAprovarLote
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
            System.Windows.Forms.Label label14;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAprovarLote));
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_formula = new Componentes.EditDefault(this.components);
            this.bsLoteSemente = new System.Windows.Forms.BindingSource(this.components);
            this.bb_formulacao = new System.Windows.Forms.Button();
            this.id_formulacao = new Componentes.EditDefault(this.components);
            this.dt_valgerminacao = new Componentes.EditData(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pc_pureza = new Componentes.EditFloat(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.pc_germinacao = new Componentes.EditFloat(this.components);
            this.cd_atestado = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.pDetalhe = new Componentes.PanelDados(this.components);
            this.sigla_unidamostra = new Componentes.EditDefault(this.components);
            this.qtd_amostra = new Componentes.EditFloat(this.components);
            this.dt_lote = new Componentes.EditData(this.components);
            this.ds_amostra = new Componentes.EditDefault(this.components);
            this.cd_amostra = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.id_lote = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.anosafra = new Componentes.EditDefault(this.components);
            this.ds_safra = new Componentes.EditDefault(this.components);
            this.cd_certificado = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoteSemente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_pureza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_germinacao)).BeginInit();
            this.pDetalhe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_amostra)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.Name = "label14";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.cd_certificado);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.ds_formula);
            this.pDados.Controls.Add(this.bb_formulacao);
            this.pDados.Controls.Add(label14);
            this.pDados.Controls.Add(this.id_formulacao);
            this.pDados.Controls.Add(this.dt_valgerminacao);
            this.pDados.Controls.Add(this.label13);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.pc_pureza);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.pc_germinacao);
            this.pDados.Controls.Add(this.cd_atestado);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.pDetalhe);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // ds_formula
            // 
            this.ds_formula.BackColor = System.Drawing.SystemColors.Window;
            this.ds_formula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_formula.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Ds_formula", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_formula, "ds_formula");
            this.ds_formula.Name = "ds_formula";
            this.ds_formula.NM_Alias = "";
            this.ds_formula.NM_Campo = "ds_formula";
            this.ds_formula.NM_CampoBusca = "ds_formula";
            this.ds_formula.NM_Param = "@P_NM_EMPRESA";
            this.ds_formula.QTD_Zero = 0;
            this.ds_formula.ST_AutoInc = false;
            this.ds_formula.ST_DisableAuto = false;
            this.ds_formula.ST_Float = false;
            this.ds_formula.ST_Gravar = false;
            this.ds_formula.ST_Int = false;
            this.ds_formula.ST_LimpaCampo = true;
            this.ds_formula.ST_NotNull = false;
            this.ds_formula.ST_PrimaryKey = false;
            // 
            // bsLoteSemente
            // 
            this.bsLoteSemente.DataSource = typeof(CamadaDados.Sementes.TList_LoteSemente);
            // 
            // bb_formulacao
            // 
            this.bb_formulacao.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_formulacao, "bb_formulacao");
            this.bb_formulacao.Name = "bb_formulacao";
            this.bb_formulacao.UseVisualStyleBackColor = false;
            this.bb_formulacao.Click += new System.EventHandler(this.bb_formulacao_Click);
            // 
            // id_formulacao
            // 
            this.id_formulacao.BackColor = System.Drawing.Color.White;
            this.id_formulacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_formulacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Id_formulacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.id_formulacao, "id_formulacao");
            this.id_formulacao.Name = "id_formulacao";
            this.id_formulacao.NM_Alias = "";
            this.id_formulacao.NM_Campo = "id_formulacao";
            this.id_formulacao.NM_CampoBusca = "id_formulacao";
            this.id_formulacao.NM_Param = "@P_CD_EMPRESA";
            this.id_formulacao.QTD_Zero = 0;
            this.id_formulacao.ST_AutoInc = false;
            this.id_formulacao.ST_DisableAuto = false;
            this.id_formulacao.ST_Float = false;
            this.id_formulacao.ST_Gravar = true;
            this.id_formulacao.ST_Int = true;
            this.id_formulacao.ST_LimpaCampo = true;
            this.id_formulacao.ST_NotNull = true;
            this.id_formulacao.ST_PrimaryKey = false;
            this.id_formulacao.Leave += new System.EventHandler(this.id_formulacao_Leave);
            // 
            // dt_valgerminacao
            // 
            this.dt_valgerminacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Dt_valgerminacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.dt_valgerminacao, "dt_valgerminacao");
            this.dt_valgerminacao.Name = "dt_valgerminacao";
            this.dt_valgerminacao.NM_Alias = "";
            this.dt_valgerminacao.NM_Campo = "";
            this.dt_valgerminacao.NM_CampoBusca = "";
            this.dt_valgerminacao.NM_Param = "";
            this.dt_valgerminacao.Operador = "";
            this.dt_valgerminacao.ST_Gravar = true;
            this.dt_valgerminacao.ST_LimpaCampo = true;
            this.dt_valgerminacao.ST_NotNull = true;
            this.dt_valgerminacao.ST_PrimaryKey = false;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // pc_pureza
            // 
            this.pc_pureza.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsLoteSemente, "Pc_pureza", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_pureza.DecimalPlaces = 2;
            resources.ApplyResources(this.pc_pureza, "pc_pureza");
            this.pc_pureza.Name = "pc_pureza";
            this.pc_pureza.NM_Alias = "";
            this.pc_pureza.NM_Campo = "";
            this.pc_pureza.NM_Param = "";
            this.pc_pureza.Operador = "";
            this.pc_pureza.ST_AutoInc = false;
            this.pc_pureza.ST_DisableAuto = false;
            this.pc_pureza.ST_Gravar = false;
            this.pc_pureza.ST_LimparCampo = true;
            this.pc_pureza.ST_NotNull = false;
            this.pc_pureza.ST_PrimaryKey = false;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // pc_germinacao
            // 
            this.pc_germinacao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsLoteSemente, "Pc_germinacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_germinacao.DecimalPlaces = 2;
            resources.ApplyResources(this.pc_germinacao, "pc_germinacao");
            this.pc_germinacao.Name = "pc_germinacao";
            this.pc_germinacao.NM_Alias = "";
            this.pc_germinacao.NM_Campo = "";
            this.pc_germinacao.NM_Param = "";
            this.pc_germinacao.Operador = "";
            this.pc_germinacao.ST_AutoInc = false;
            this.pc_germinacao.ST_DisableAuto = false;
            this.pc_germinacao.ST_Gravar = false;
            this.pc_germinacao.ST_LimparCampo = true;
            this.pc_germinacao.ST_NotNull = false;
            this.pc_germinacao.ST_PrimaryKey = false;
            // 
            // cd_atestado
            // 
            this.cd_atestado.BackColor = System.Drawing.SystemColors.Window;
            this.cd_atestado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_atestado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Cd_atestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_atestado, "cd_atestado");
            this.cd_atestado.Name = "cd_atestado";
            this.cd_atestado.NM_Alias = "";
            this.cd_atestado.NM_Campo = "";
            this.cd_atestado.NM_CampoBusca = "";
            this.cd_atestado.NM_Param = "";
            this.cd_atestado.QTD_Zero = 0;
            this.cd_atestado.ST_AutoInc = false;
            this.cd_atestado.ST_DisableAuto = false;
            this.cd_atestado.ST_Float = false;
            this.cd_atestado.ST_Gravar = false;
            this.cd_atestado.ST_Int = false;
            this.cd_atestado.ST_LimpaCampo = true;
            this.cd_atestado.ST_NotNull = false;
            this.cd_atestado.ST_PrimaryKey = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_produto, "ds_produto");
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_NM_EMPRESA";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_produto, "bb_produto");
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.Color.White;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_produto, "cd_produto");
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // pDetalhe
            // 
            this.pDetalhe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pDetalhe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDetalhe.Controls.Add(this.sigla_unidamostra);
            this.pDetalhe.Controls.Add(this.qtd_amostra);
            this.pDetalhe.Controls.Add(label11);
            this.pDetalhe.Controls.Add(this.dt_lote);
            this.pDetalhe.Controls.Add(label8);
            this.pDetalhe.Controls.Add(this.ds_amostra);
            this.pDetalhe.Controls.Add(label4);
            this.pDetalhe.Controls.Add(this.cd_amostra);
            this.pDetalhe.Controls.Add(this.nm_empresa);
            this.pDetalhe.Controls.Add(this.cd_empresa);
            this.pDetalhe.Controls.Add(this.label2);
            this.pDetalhe.Controls.Add(this.id_lote);
            this.pDetalhe.Controls.Add(this.label1);
            this.pDetalhe.Controls.Add(this.anosafra);
            this.pDetalhe.Controls.Add(label3);
            this.pDetalhe.Controls.Add(this.ds_safra);
            resources.ApplyResources(this.pDetalhe, "pDetalhe");
            this.pDetalhe.Name = "pDetalhe";
            this.pDetalhe.NM_ProcDeletar = "";
            this.pDetalhe.NM_ProcGravar = "";
            // 
            // sigla_unidamostra
            // 
            this.sigla_unidamostra.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidamostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidamostra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Sigla_unidamostra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.sigla_unidamostra, "sigla_unidamostra");
            this.sigla_unidamostra.Name = "sigla_unidamostra";
            this.sigla_unidamostra.NM_Alias = "";
            this.sigla_unidamostra.NM_Campo = "sigla_unidade";
            this.sigla_unidamostra.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidamostra.NM_Param = "@P_NM_EMPRESA";
            this.sigla_unidamostra.QTD_Zero = 0;
            this.sigla_unidamostra.ST_AutoInc = false;
            this.sigla_unidamostra.ST_DisableAuto = false;
            this.sigla_unidamostra.ST_Float = false;
            this.sigla_unidamostra.ST_Gravar = false;
            this.sigla_unidamostra.ST_Int = false;
            this.sigla_unidamostra.ST_LimpaCampo = true;
            this.sigla_unidamostra.ST_NotNull = false;
            this.sigla_unidamostra.ST_PrimaryKey = false;
            // 
            // qtd_amostra
            // 
            this.qtd_amostra.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsLoteSemente, "Qtd_lote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_amostra.DecimalPlaces = 3;
            resources.ApplyResources(this.qtd_amostra, "qtd_amostra");
            this.qtd_amostra.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_amostra.Name = "qtd_amostra";
            this.qtd_amostra.NM_Alias = "";
            this.qtd_amostra.NM_Campo = "";
            this.qtd_amostra.NM_Param = "";
            this.qtd_amostra.Operador = "";
            this.qtd_amostra.ST_AutoInc = false;
            this.qtd_amostra.ST_DisableAuto = false;
            this.qtd_amostra.ST_Gravar = true;
            this.qtd_amostra.ST_LimparCampo = true;
            this.qtd_amostra.ST_NotNull = true;
            this.qtd_amostra.ST_PrimaryKey = false;
            // 
            // dt_lote
            // 
            this.dt_lote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Dt_lotestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.dt_lote, "dt_lote");
            this.dt_lote.Name = "dt_lote";
            this.dt_lote.NM_Alias = "";
            this.dt_lote.NM_Campo = "";
            this.dt_lote.NM_CampoBusca = "";
            this.dt_lote.NM_Param = "";
            this.dt_lote.Operador = "";
            this.dt_lote.ST_Gravar = true;
            this.dt_lote.ST_LimpaCampo = true;
            this.dt_lote.ST_NotNull = true;
            this.dt_lote.ST_PrimaryKey = false;
            // 
            // ds_amostra
            // 
            this.ds_amostra.BackColor = System.Drawing.SystemColors.Window;
            this.ds_amostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_amostra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Ds_amostra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_amostra, "ds_amostra");
            this.ds_amostra.Name = "ds_amostra";
            this.ds_amostra.NM_Alias = "";
            this.ds_amostra.NM_Campo = "ds_produto";
            this.ds_amostra.NM_CampoBusca = "ds_produto";
            this.ds_amostra.NM_Param = "@P_NM_EMPRESA";
            this.ds_amostra.QTD_Zero = 0;
            this.ds_amostra.ST_AutoInc = false;
            this.ds_amostra.ST_DisableAuto = false;
            this.ds_amostra.ST_Float = false;
            this.ds_amostra.ST_Gravar = false;
            this.ds_amostra.ST_Int = false;
            this.ds_amostra.ST_LimpaCampo = true;
            this.ds_amostra.ST_NotNull = false;
            this.ds_amostra.ST_PrimaryKey = false;
            // 
            // cd_amostra
            // 
            this.cd_amostra.BackColor = System.Drawing.Color.White;
            this.cd_amostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_amostra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Cd_amostra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_amostra, "cd_amostra");
            this.cd_amostra.Name = "cd_amostra";
            this.cd_amostra.NM_Alias = "";
            this.cd_amostra.NM_Campo = "cd_produto";
            this.cd_amostra.NM_CampoBusca = "cd_produto";
            this.cd_amostra.NM_Param = "@P_CD_EMPRESA";
            this.cd_amostra.QTD_Zero = 0;
            this.cd_amostra.ST_AutoInc = false;
            this.cd_amostra.ST_DisableAuto = false;
            this.cd_amostra.ST_Float = false;
            this.cd_amostra.ST_Gravar = true;
            this.cd_amostra.ST_Int = true;
            this.cd_amostra.ST_LimpaCampo = true;
            this.cd_amostra.ST_NotNull = true;
            this.cd_amostra.ST_PrimaryKey = false;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nm_empresa, "nm_empresa");
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "";
            this.nm_empresa.NM_CampoBusca = "";
            this.nm_empresa.NM_Param = "";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "";
            this.cd_empresa.NM_CampoBusca = "";
            this.cd_empresa.NM_Param = "";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // id_lote
            // 
            this.id_lote.BackColor = System.Drawing.SystemColors.Window;
            this.id_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_lote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Id_lote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.id_lote, "id_lote");
            this.id_lote.Name = "id_lote";
            this.id_lote.NM_Alias = "";
            this.id_lote.NM_Campo = "";
            this.id_lote.NM_CampoBusca = "";
            this.id_lote.NM_Param = "";
            this.id_lote.QTD_Zero = 0;
            this.id_lote.ST_AutoInc = false;
            this.id_lote.ST_DisableAuto = false;
            this.id_lote.ST_Float = false;
            this.id_lote.ST_Gravar = false;
            this.id_lote.ST_Int = false;
            this.id_lote.ST_LimpaCampo = true;
            this.id_lote.ST_NotNull = false;
            this.id_lote.ST_PrimaryKey = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // anosafra
            // 
            this.anosafra.BackColor = System.Drawing.Color.White;
            this.anosafra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.anosafra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Anosafra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.anosafra, "anosafra");
            this.anosafra.Name = "anosafra";
            this.anosafra.NM_Alias = "";
            this.anosafra.NM_Campo = "anosafra";
            this.anosafra.NM_CampoBusca = "anosafra";
            this.anosafra.NM_Param = "@P_CD_EMPRESA";
            this.anosafra.QTD_Zero = 0;
            this.anosafra.ST_AutoInc = false;
            this.anosafra.ST_DisableAuto = false;
            this.anosafra.ST_Float = false;
            this.anosafra.ST_Gravar = true;
            this.anosafra.ST_Int = true;
            this.anosafra.ST_LimpaCampo = true;
            this.anosafra.ST_NotNull = false;
            this.anosafra.ST_PrimaryKey = false;
            // 
            // ds_safra
            // 
            this.ds_safra.BackColor = System.Drawing.SystemColors.Window;
            this.ds_safra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_safra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Ds_safra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_safra, "ds_safra");
            this.ds_safra.Name = "ds_safra";
            this.ds_safra.NM_Alias = "";
            this.ds_safra.NM_Campo = "ds_safra";
            this.ds_safra.NM_CampoBusca = "ds_safra";
            this.ds_safra.NM_Param = "@P_NM_EMPRESA";
            this.ds_safra.QTD_Zero = 0;
            this.ds_safra.ST_AutoInc = false;
            this.ds_safra.ST_DisableAuto = false;
            this.ds_safra.ST_Float = false;
            this.ds_safra.ST_Gravar = false;
            this.ds_safra.ST_Int = false;
            this.ds_safra.ST_LimpaCampo = true;
            this.ds_safra.ST_NotNull = false;
            this.ds_safra.ST_PrimaryKey = false;
            // 
            // cd_certificado
            // 
            this.cd_certificado.BackColor = System.Drawing.SystemColors.Window;
            this.cd_certificado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_certificado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteSemente, "Cd_certificado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_certificado, "cd_certificado");
            this.cd_certificado.Name = "cd_certificado";
            this.cd_certificado.NM_Alias = "";
            this.cd_certificado.NM_Campo = "";
            this.cd_certificado.NM_CampoBusca = "";
            this.cd_certificado.NM_Param = "";
            this.cd_certificado.QTD_Zero = 0;
            this.cd_certificado.ST_AutoInc = false;
            this.cd_certificado.ST_DisableAuto = false;
            this.cd_certificado.ST_Float = false;
            this.cd_certificado.ST_Gravar = false;
            this.cd_certificado.ST_Int = false;
            this.cd_certificado.ST_LimpaCampo = true;
            this.cd_certificado.ST_NotNull = false;
            this.cd_certificado.ST_PrimaryKey = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // TFAprovarLote
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAprovarLote";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFAprovarLote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAprovarLote_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoteSemente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_pureza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_germinacao)).EndInit();
            this.pDetalhe.ResumeLayout(false);
            this.pDetalhe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_amostra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.BindingSource bsLoteSemente;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_formula;
        private System.Windows.Forms.Button bb_formulacao;
        private Componentes.EditDefault id_formulacao;
        private Componentes.EditData dt_valgerminacao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private Componentes.EditFloat pc_pureza;
        private System.Windows.Forms.Label label9;
        private Componentes.EditFloat pc_germinacao;
        private Componentes.EditDefault cd_atestado;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault cd_produto;
        private Componentes.PanelDados pDetalhe;
        private Componentes.EditDefault sigla_unidamostra;
        private Componentes.EditFloat qtd_amostra;
        private Componentes.EditData dt_lote;
        private Componentes.EditDefault ds_amostra;
        private Componentes.EditDefault cd_amostra;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault id_lote;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault anosafra;
        private Componentes.EditDefault ds_safra;
        private Componentes.EditDefault cd_certificado;
        private System.Windows.Forms.Label label6;
    }
}