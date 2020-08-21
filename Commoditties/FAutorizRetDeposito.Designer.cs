namespace Commoditties
{
    partial class TFAutorizRetDeposito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAutorizRetDeposito));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.cd_unidproduto = new Componentes.EditDefault(this.components);
            this.bsAutoriz = new System.Windows.Forms.BindingSource(this.components);
            this.sg_produto = new Componentes.EditDefault(this.components);
            this.qtd_saldocontrato = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.qtd_retirar = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dt_lancto = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.sigla_unidvalor = new Componentes.EditDefault(this.components);
            this.bb_unidade = new System.Windows.Forms.Button();
            this.ds_unidade = new Componentes.EditDefault(this.components);
            this.cd_unidade = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.bb_contrato = new System.Windows.Forms.Button();
            this.nr_Contrato = new Componentes.EditDefault(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAutoriz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_saldocontrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_retirar)).BeginInit();
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.nm_clifor);
            this.pDados.Controls.Add(this.cd_clifor);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.cd_unidproduto);
            this.pDados.Controls.Add(this.sg_produto);
            this.pDados.Controls.Add(this.qtd_saldocontrato);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.qtd_retirar);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.dt_lancto);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.sigla_unidvalor);
            this.pDados.Controls.Add(this.bb_unidade);
            this.pDados.Controls.Add(this.ds_unidade);
            this.pDados.Controls.Add(this.cd_unidade);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.bb_contrato);
            this.pDados.Controls.Add(this.nr_Contrato);
            this.pDados.Controls.Add(this.label11);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // cd_unidproduto
            // 
            this.cd_unidproduto.BackColor = System.Drawing.Color.White;
            this.cd_unidproduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_unidproduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidproduto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Cd_unidproduto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_unidproduto, "cd_unidproduto");
            this.cd_unidproduto.Name = "cd_unidproduto";
            this.cd_unidproduto.NM_Alias = "a";
            this.cd_unidproduto.NM_Campo = "cd_unid_produto";
            this.cd_unidproduto.NM_CampoBusca = "cd_unid_produto";
            this.cd_unidproduto.NM_Param = "@P_NR_PEDIDO";
            this.cd_unidproduto.QTD_Zero = 0;
            this.cd_unidproduto.ST_AutoInc = false;
            this.cd_unidproduto.ST_DisableAuto = false;
            this.cd_unidproduto.ST_Float = false;
            this.cd_unidproduto.ST_Gravar = false;
            this.cd_unidproduto.ST_Int = false;
            this.cd_unidproduto.ST_LimpaCampo = true;
            this.cd_unidproduto.ST_NotNull = false;
            this.cd_unidproduto.ST_PrimaryKey = false;
            this.cd_unidproduto.TextOld = null;
            // 
            // bsAutoriz
            // 
            this.bsAutoriz.DataSource = typeof(CamadaDados.Graos.TList_AutorizRetDeposito);
            // 
            // sg_produto
            // 
            this.sg_produto.BackColor = System.Drawing.Color.White;
            this.sg_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sg_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sg_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Sg_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.sg_produto, "sg_produto");
            this.sg_produto.Name = "sg_produto";
            this.sg_produto.NM_Alias = "a";
            this.sg_produto.NM_Campo = "sg_unidade_est";
            this.sg_produto.NM_CampoBusca = "sg_unidade_est";
            this.sg_produto.NM_Param = "@P_NR_PEDIDO";
            this.sg_produto.QTD_Zero = 0;
            this.sg_produto.ST_AutoInc = false;
            this.sg_produto.ST_DisableAuto = false;
            this.sg_produto.ST_Float = false;
            this.sg_produto.ST_Gravar = false;
            this.sg_produto.ST_Int = false;
            this.sg_produto.ST_LimpaCampo = true;
            this.sg_produto.ST_NotNull = false;
            this.sg_produto.ST_PrimaryKey = false;
            this.sg_produto.TextOld = null;
            // 
            // qtd_saldocontrato
            // 
            this.qtd_saldocontrato.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAutoriz, "Qtd_saldocontrato", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_saldocontrato.DecimalPlaces = 3;
            resources.ApplyResources(this.qtd_saldocontrato, "qtd_saldocontrato");
            this.qtd_saldocontrato.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_saldocontrato.Name = "qtd_saldocontrato";
            this.qtd_saldocontrato.NM_Alias = "";
            this.qtd_saldocontrato.NM_Campo = "";
            this.qtd_saldocontrato.NM_Param = "";
            this.qtd_saldocontrato.Operador = "";
            this.qtd_saldocontrato.ST_AutoInc = false;
            this.qtd_saldocontrato.ST_DisableAuto = false;
            this.qtd_saldocontrato.ST_Gravar = true;
            this.qtd_saldocontrato.ST_LimparCampo = true;
            this.qtd_saldocontrato.ST_NotNull = true;
            this.qtd_saldocontrato.ST_PrimaryKey = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.Color.White;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Sg_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.editDefault1, "editDefault1");
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "a";
            this.editDefault1.NM_Campo = "sigla_unidade";
            this.editDefault1.NM_CampoBusca = "sigla_unidade";
            this.editDefault1.NM_Param = "@P_NR_PEDIDO";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TextOld = null;
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_observacao, "ds_observacao");
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TextOld = null;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // qtd_retirar
            // 
            this.qtd_retirar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAutoriz, "Qtd_retirar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_retirar.DecimalPlaces = 3;
            resources.ApplyResources(this.qtd_retirar, "qtd_retirar");
            this.qtd_retirar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_retirar.Name = "qtd_retirar";
            this.qtd_retirar.NM_Alias = "";
            this.qtd_retirar.NM_Campo = "";
            this.qtd_retirar.NM_Param = "";
            this.qtd_retirar.Operador = "";
            this.qtd_retirar.ST_AutoInc = false;
            this.qtd_retirar.ST_DisableAuto = false;
            this.qtd_retirar.ST_Gravar = true;
            this.qtd_retirar.ST_LimparCampo = true;
            this.qtd_retirar.ST_NotNull = true;
            this.qtd_retirar.ST_PrimaryKey = false;
            this.qtd_retirar.Leave += new System.EventHandler(this.qtd_retirar_Leave);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // dt_lancto
            // 
            this.dt_lancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Dt_lanctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.dt_lancto, "dt_lancto");
            this.dt_lancto.Name = "dt_lancto";
            this.dt_lancto.NM_Alias = "";
            this.dt_lancto.NM_Campo = "";
            this.dt_lancto.NM_CampoBusca = "";
            this.dt_lancto.NM_Param = "";
            this.dt_lancto.Operador = "";
            this.dt_lancto.ST_Gravar = true;
            this.dt_lancto.ST_LimpaCampo = true;
            this.dt_lancto.ST_NotNull = true;
            this.dt_lancto.ST_PrimaryKey = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // sigla_unidvalor
            // 
            this.sigla_unidvalor.BackColor = System.Drawing.Color.White;
            this.sigla_unidvalor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_unidvalor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidvalor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Sg_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.sigla_unidvalor, "sigla_unidvalor");
            this.sigla_unidvalor.Name = "sigla_unidvalor";
            this.sigla_unidvalor.NM_Alias = "a";
            this.sigla_unidvalor.NM_Campo = "sigla_unidade";
            this.sigla_unidvalor.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidvalor.NM_Param = "@P_NR_PEDIDO";
            this.sigla_unidvalor.QTD_Zero = 0;
            this.sigla_unidvalor.ST_AutoInc = false;
            this.sigla_unidvalor.ST_DisableAuto = false;
            this.sigla_unidvalor.ST_Float = false;
            this.sigla_unidvalor.ST_Gravar = false;
            this.sigla_unidvalor.ST_Int = false;
            this.sigla_unidvalor.ST_LimpaCampo = true;
            this.sigla_unidvalor.ST_NotNull = false;
            this.sigla_unidvalor.ST_PrimaryKey = false;
            this.sigla_unidvalor.TextOld = null;
            // 
            // bb_unidade
            // 
            this.bb_unidade.BackColor = System.Drawing.SystemColors.Control;
            this.bb_unidade.FlatAppearance.BorderColor = System.Drawing.Color.White;
            resources.ApplyResources(this.bb_unidade, "bb_unidade");
            this.bb_unidade.Name = "bb_unidade";
            this.bb_unidade.UseVisualStyleBackColor = false;
            this.bb_unidade.Click += new System.EventHandler(this.bb_unidade_Click);
            // 
            // ds_unidade
            // 
            this.ds_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.ds_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Ds_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_unidade, "ds_unidade");
            this.ds_unidade.Name = "ds_unidade";
            this.ds_unidade.NM_Alias = "a";
            this.ds_unidade.NM_Campo = "ds_unidade";
            this.ds_unidade.NM_CampoBusca = "ds_unidade";
            this.ds_unidade.NM_Param = "@P_DS_PRODUTO";
            this.ds_unidade.QTD_Zero = 0;
            this.ds_unidade.ReadOnly = true;
            this.ds_unidade.ST_AutoInc = false;
            this.ds_unidade.ST_DisableAuto = false;
            this.ds_unidade.ST_Float = false;
            this.ds_unidade.ST_Gravar = false;
            this.ds_unidade.ST_Int = false;
            this.ds_unidade.ST_LimpaCampo = true;
            this.ds_unidade.ST_NotNull = false;
            this.ds_unidade.ST_PrimaryKey = false;
            this.ds_unidade.TextOld = null;
            // 
            // cd_unidade
            // 
            this.cd_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.cd_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Cd_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_unidade, "cd_unidade");
            this.cd_unidade.Name = "cd_unidade";
            this.cd_unidade.NM_Alias = "a";
            this.cd_unidade.NM_Campo = "cd_unidade";
            this.cd_unidade.NM_CampoBusca = "cd_unidade";
            this.cd_unidade.NM_Param = "@P_CD_PRODUTO";
            this.cd_unidade.QTD_Zero = 0;
            this.cd_unidade.ST_AutoInc = false;
            this.cd_unidade.ST_DisableAuto = false;
            this.cd_unidade.ST_Float = false;
            this.cd_unidade.ST_Gravar = true;
            this.cd_unidade.ST_Int = false;
            this.cd_unidade.ST_LimpaCampo = true;
            this.cd_unidade.ST_NotNull = true;
            this.cd_unidade.ST_PrimaryKey = false;
            this.cd_unidade.TextOld = null;
            this.cd_unidade.Leave += new System.EventHandler(this.cd_unidade_Leave);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_produto, "ds_produto");
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "a";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_PRODUTO";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.ReadOnly = true;
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TextOld = null;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_produto, "cd_produto");
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "b";
            this.cd_produto.NM_Campo = "CD_Produto";
            this.cd_produto.NM_CampoBusca = "CD_Produto";
            this.cd_produto.NM_Param = "@P_CD_PRODUTO";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = false;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TextOld = null;
            // 
            // bb_contrato
            // 
            this.bb_contrato.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contrato.FlatAppearance.BorderColor = System.Drawing.Color.White;
            resources.ApplyResources(this.bb_contrato, "bb_contrato");
            this.bb_contrato.Name = "bb_contrato";
            this.bb_contrato.UseVisualStyleBackColor = false;
            this.bb_contrato.Click += new System.EventHandler(this.bb_contrato_Click);
            // 
            // nr_Contrato
            // 
            this.nr_Contrato.BackColor = System.Drawing.SystemColors.Window;
            this.nr_Contrato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_Contrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_Contrato.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Nr_contratostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nr_Contrato, "nr_Contrato");
            this.nr_Contrato.Name = "nr_Contrato";
            this.nr_Contrato.NM_Alias = "a";
            this.nr_Contrato.NM_Campo = "nr_contrato";
            this.nr_Contrato.NM_CampoBusca = "nr_contrato";
            this.nr_Contrato.NM_Param = "@P_NR_CONTRATO";
            this.nr_Contrato.QTD_Zero = 0;
            this.nr_Contrato.ST_AutoInc = false;
            this.nr_Contrato.ST_DisableAuto = false;
            this.nr_Contrato.ST_Float = false;
            this.nr_Contrato.ST_Gravar = false;
            this.nr_Contrato.ST_Int = false;
            this.nr_Contrato.ST_LimpaCampo = true;
            this.nr_Contrato.ST_NotNull = true;
            this.nr_Contrato.ST_PrimaryKey = false;
            this.nr_Contrato.TextOld = null;
            this.nr_Contrato.Leave += new System.EventHandler(this.nr_Contrato_Leave);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nm_empresa, "nm_empresa");
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "a";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_DS_PRODUTO";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.ReadOnly = true;
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "b";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_PRODUTO";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TextOld = null;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Nm_cliforcontrato", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nm_clifor, "nm_clifor");
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "a";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_DS_PRODUTO";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.ReadOnly = true;
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TextOld = null;
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAutoriz, "Cd_cliforcontrato", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_clifor, "cd_clifor");
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "b";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_PRODUTO";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = false;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = false;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TextOld = null;
            // 
            // TFAutorizRetDeposito
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAutorizRetDeposito";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFAutorizRetDeposito_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAutorizRetDeposito_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAutoriz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_saldocontrato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_retirar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nr_Contrato;
        private System.Windows.Forms.Label label11;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat qtd_retirar;
        private System.Windows.Forms.Label label4;
        private Componentes.EditData dt_lancto;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault sigla_unidvalor;
        private System.Windows.Forms.Button bb_unidade;
        private Componentes.EditDefault ds_unidade;
        private Componentes.EditDefault cd_unidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_contrato;
        private System.Windows.Forms.BindingSource bsAutoriz;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault sg_produto;
        private Componentes.EditFloat qtd_saldocontrato;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault cd_unidproduto;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault nm_clifor;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
    }
}