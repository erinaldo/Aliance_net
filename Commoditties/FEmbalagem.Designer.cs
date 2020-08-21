namespace Commoditties
{
    partial class TFEmbalagem
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
            System.Windows.Forms.Label label11;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFEmbalagem));
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label27;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pnl_Lan_Estoque = new Componentes.PanelDados(this.components);
            this.tp_movimento = new Componentes.ComboBoxDefault(this.components);
            this.DT_Lancamento = new Componentes.EditData(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.VL_Unitario = new Componentes.EditFloat(this.components);
            this.Qtd_Saida = new Componentes.EditFloat(this.components);
            this.Qtd_Entrada = new Componentes.EditFloat(this.components);
            this.lbl_quantidade = new System.Windows.Forms.Label();
            this.Sigla = new Componentes.EditDefault(this.components);
            this.DS_Observacao = new Componentes.EditDefault(this.components);
            this.DS_Local = new Componentes.EditDefault(this.components);
            this.CD_Local = new Componentes.EditDefault(this.components);
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.BS_Lan_Estoque = new System.Windows.Forms.BindingSource(this.components);
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pnl_Lan_Estoque.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qtd_Saida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qtd_Entrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Lan_Estoque)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            label11.AccessibleDescription = null;
            label11.AccessibleName = null;
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // label10
            // 
            label10.AccessibleDescription = null;
            label10.AccessibleName = null;
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // label17
            // 
            label17.AccessibleDescription = null;
            label17.AccessibleName = null;
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            // 
            // label22
            // 
            label22.AccessibleDescription = null;
            label22.AccessibleName = null;
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            // 
            // label23
            // 
            label23.AccessibleDescription = null;
            label23.AccessibleName = null;
            resources.ApplyResources(label23, "label23");
            label23.Name = "label23";
            // 
            // label25
            // 
            label25.AccessibleDescription = null;
            label25.AccessibleName = null;
            resources.ApplyResources(label25, "label25");
            label25.Name = "label25";
            // 
            // label27
            // 
            label27.AccessibleDescription = null;
            label27.AccessibleName = null;
            resources.ApplyResources(label27, "label27");
            label27.Name = "label27";
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
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
            // pnl_Lan_Estoque
            // 
            this.pnl_Lan_Estoque.AccessibleDescription = null;
            this.pnl_Lan_Estoque.AccessibleName = null;
            resources.ApplyResources(this.pnl_Lan_Estoque, "pnl_Lan_Estoque");
            this.pnl_Lan_Estoque.BackgroundImage = null;
            this.pnl_Lan_Estoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Lan_Estoque.Controls.Add(this.tp_movimento);
            this.pnl_Lan_Estoque.Controls.Add(this.DT_Lancamento);
            this.pnl_Lan_Estoque.Controls.Add(label11);
            this.pnl_Lan_Estoque.Controls.Add(label10);
            this.pnl_Lan_Estoque.Controls.Add(this.radioGroup1);
            this.pnl_Lan_Estoque.Controls.Add(this.DS_Observacao);
            this.pnl_Lan_Estoque.Controls.Add(label22);
            this.pnl_Lan_Estoque.Controls.Add(this.DS_Local);
            this.pnl_Lan_Estoque.Controls.Add(this.CD_Local);
            this.pnl_Lan_Estoque.Controls.Add(label23);
            this.pnl_Lan_Estoque.Controls.Add(this.DS_Produto);
            this.pnl_Lan_Estoque.Controls.Add(this.CD_Produto);
            this.pnl_Lan_Estoque.Controls.Add(label25);
            this.pnl_Lan_Estoque.Controls.Add(this.NM_Empresa);
            this.pnl_Lan_Estoque.Controls.Add(this.CD_Empresa);
            this.pnl_Lan_Estoque.Controls.Add(label27);
            this.pnl_Lan_Estoque.Font = null;
            this.pnl_Lan_Estoque.Name = "pnl_Lan_Estoque";
            this.pnl_Lan_Estoque.NM_ProcDeletar = "";
            this.pnl_Lan_Estoque.NM_ProcGravar = "";
            // 
            // tp_movimento
            // 
            this.tp_movimento.AccessibleDescription = null;
            this.tp_movimento.AccessibleName = null;
            resources.ApplyResources(this.tp_movimento, "tp_movimento");
            this.tp_movimento.BackgroundImage = null;
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_Lan_Estoque, "Tp_movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_movimento.Font = null;
            this.tp_movimento.FormattingEnabled = true;
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "";
            this.tp_movimento.NM_Campo = "";
            this.tp_movimento.NM_Param = "";
            this.tp_movimento.ST_Gravar = false;
            this.tp_movimento.ST_LimparCampo = true;
            this.tp_movimento.ST_NotNull = false;
            this.tp_movimento.SelectedIndexChanged += new System.EventHandler(this.tp_movimento_SelectedIndexChanged);
            // 
            // DT_Lancamento
            // 
            this.DT_Lancamento.AccessibleDescription = null;
            this.DT_Lancamento.AccessibleName = null;
            resources.ApplyResources(this.DT_Lancamento, "DT_Lancamento");
            this.DT_Lancamento.BackgroundImage = null;
            this.DT_Lancamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Dt_lancto_STR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Lancamento.Name = "DT_Lancamento";
            this.DT_Lancamento.NM_Alias = "";
            this.DT_Lancamento.NM_Campo = "";
            this.DT_Lancamento.NM_CampoBusca = "";
            this.DT_Lancamento.NM_Param = "";
            this.DT_Lancamento.Operador = "";
            this.DT_Lancamento.ST_Gravar = true;
            this.DT_Lancamento.ST_LimpaCampo = true;
            this.DT_Lancamento.ST_NotNull = true;
            this.DT_Lancamento.ST_PrimaryKey = false;
            // 
            // radioGroup1
            // 
            this.radioGroup1.AccessibleDescription = null;
            this.radioGroup1.AccessibleName = null;
            resources.ApplyResources(this.radioGroup1, "radioGroup1");
            this.radioGroup1.BackgroundImage = null;
            this.radioGroup1.Controls.Add(this.panelDados2);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabStop = false;
            // 
            // panelDados2
            // 
            this.panelDados2.AccessibleDescription = null;
            this.panelDados2.AccessibleName = null;
            resources.ApplyResources(this.panelDados2, "panelDados2");
            this.panelDados2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.panelDados2.BackgroundImage = null;
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados2.Controls.Add(this.VL_Unitario);
            this.panelDados2.Controls.Add(label17);
            this.panelDados2.Controls.Add(this.Qtd_Saida);
            this.panelDados2.Controls.Add(this.Qtd_Entrada);
            this.panelDados2.Controls.Add(this.lbl_quantidade);
            this.panelDados2.Controls.Add(this.Sigla);
            this.panelDados2.Font = null;
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            // 
            // VL_Unitario
            // 
            this.VL_Unitario.AccessibleDescription = null;
            this.VL_Unitario.AccessibleName = null;
            resources.ApplyResources(this.VL_Unitario, "VL_Unitario");
            this.VL_Unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Lan_Estoque, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Unitario.DecimalPlaces = 5;
            this.VL_Unitario.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.VL_Unitario.Name = "VL_Unitario";
            this.VL_Unitario.NM_Alias = "";
            this.VL_Unitario.NM_Campo = "VL_Unitario";
            this.VL_Unitario.NM_Param = "@P_VL_UNITARIO";
            this.VL_Unitario.Operador = "";
            this.VL_Unitario.ST_AutoInc = false;
            this.VL_Unitario.ST_DisableAuto = false;
            this.VL_Unitario.ST_Gravar = true;
            this.VL_Unitario.ST_LimparCampo = true;
            this.VL_Unitario.ST_NotNull = true;
            this.VL_Unitario.ST_PrimaryKey = false;
            // 
            // Qtd_Saida
            // 
            this.Qtd_Saida.AccessibleDescription = null;
            this.Qtd_Saida.AccessibleName = null;
            resources.ApplyResources(this.Qtd_Saida, "Qtd_Saida");
            this.Qtd_Saida.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Lan_Estoque, "Qtd_saida", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Qtd_Saida.DecimalPlaces = 3;
            this.Qtd_Saida.Maximum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            0});
            this.Qtd_Saida.Name = "Qtd_Saida";
            this.Qtd_Saida.NM_Alias = "";
            this.Qtd_Saida.NM_Campo = "";
            this.Qtd_Saida.NM_Param = "";
            this.Qtd_Saida.Operador = "";
            this.Qtd_Saida.ST_AutoInc = false;
            this.Qtd_Saida.ST_DisableAuto = false;
            this.Qtd_Saida.ST_Gravar = true;
            this.Qtd_Saida.ST_LimparCampo = true;
            this.Qtd_Saida.ST_NotNull = true;
            this.Qtd_Saida.ST_PrimaryKey = false;
            // 
            // Qtd_Entrada
            // 
            this.Qtd_Entrada.AccessibleDescription = null;
            this.Qtd_Entrada.AccessibleName = null;
            resources.ApplyResources(this.Qtd_Entrada, "Qtd_Entrada");
            this.Qtd_Entrada.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Lan_Estoque, "Qtd_entrada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Qtd_Entrada.DecimalPlaces = 3;
            this.Qtd_Entrada.Maximum = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            0});
            this.Qtd_Entrada.Name = "Qtd_Entrada";
            this.Qtd_Entrada.NM_Alias = "";
            this.Qtd_Entrada.NM_Campo = "";
            this.Qtd_Entrada.NM_Param = "";
            this.Qtd_Entrada.Operador = "";
            this.Qtd_Entrada.ST_AutoInc = false;
            this.Qtd_Entrada.ST_DisableAuto = false;
            this.Qtd_Entrada.ST_Gravar = true;
            this.Qtd_Entrada.ST_LimparCampo = true;
            this.Qtd_Entrada.ST_NotNull = false;
            this.Qtd_Entrada.ST_PrimaryKey = false;
            // 
            // lbl_quantidade
            // 
            this.lbl_quantidade.AccessibleDescription = null;
            this.lbl_quantidade.AccessibleName = null;
            resources.ApplyResources(this.lbl_quantidade, "lbl_quantidade");
            this.lbl_quantidade.Name = "lbl_quantidade";
            // 
            // Sigla
            // 
            this.Sigla.AccessibleDescription = null;
            this.Sigla.AccessibleName = null;
            resources.ApplyResources(this.Sigla, "Sigla");
            this.Sigla.BackColor = System.Drawing.SystemColors.Window;
            this.Sigla.BackgroundImage = null;
            this.Sigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Sigla.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Sigla_Unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Sigla.Name = "Sigla";
            this.Sigla.NM_Alias = "";
            this.Sigla.NM_Campo = "Sigla_Unidade";
            this.Sigla.NM_CampoBusca = "Sigla_Unidade";
            this.Sigla.NM_Param = "@P_SIGLA_UNIDADE";
            this.Sigla.QTD_Zero = 0;
            this.Sigla.ReadOnly = true;
            this.Sigla.ST_AutoInc = false;
            this.Sigla.ST_DisableAuto = false;
            this.Sigla.ST_Float = false;
            this.Sigla.ST_Gravar = false;
            this.Sigla.ST_Int = false;
            this.Sigla.ST_LimpaCampo = true;
            this.Sigla.ST_NotNull = false;
            this.Sigla.ST_PrimaryKey = false;
            this.Sigla.TabStop = false;
            // 
            // DS_Observacao
            // 
            this.DS_Observacao.AccessibleDescription = null;
            this.DS_Observacao.AccessibleName = null;
            resources.ApplyResources(this.DS_Observacao, "DS_Observacao");
            this.DS_Observacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Observacao.BackgroundImage = null;
            this.DS_Observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Observacao.Name = "DS_Observacao";
            this.DS_Observacao.NM_Alias = "";
            this.DS_Observacao.NM_Campo = "cd_empresa";
            this.DS_Observacao.NM_CampoBusca = "cd_empresa";
            this.DS_Observacao.NM_Param = "@P_CD_EMPRESA";
            this.DS_Observacao.QTD_Zero = 0;
            this.DS_Observacao.ST_AutoInc = false;
            this.DS_Observacao.ST_DisableAuto = false;
            this.DS_Observacao.ST_Float = false;
            this.DS_Observacao.ST_Gravar = true;
            this.DS_Observacao.ST_Int = false;
            this.DS_Observacao.ST_LimpaCampo = true;
            this.DS_Observacao.ST_NotNull = false;
            this.DS_Observacao.ST_PrimaryKey = false;
            // 
            // DS_Local
            // 
            this.DS_Local.AccessibleDescription = null;
            this.DS_Local.AccessibleName = null;
            resources.ApplyResources(this.DS_Local, "DS_Local");
            this.DS_Local.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Local.BackgroundImage = null;
            this.DS_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Local.Name = "DS_Local";
            this.DS_Local.NM_Alias = "";
            this.DS_Local.NM_Campo = "ds_local";
            this.DS_Local.NM_CampoBusca = "ds_local";
            this.DS_Local.NM_Param = "@P_NM_EMPRESA";
            this.DS_Local.QTD_Zero = 0;
            this.DS_Local.ST_AutoInc = false;
            this.DS_Local.ST_DisableAuto = false;
            this.DS_Local.ST_Float = false;
            this.DS_Local.ST_Gravar = false;
            this.DS_Local.ST_Int = false;
            this.DS_Local.ST_LimpaCampo = true;
            this.DS_Local.ST_NotNull = false;
            this.DS_Local.ST_PrimaryKey = false;
            // 
            // CD_Local
            // 
            this.CD_Local.AccessibleDescription = null;
            this.CD_Local.AccessibleName = null;
            resources.ApplyResources(this.CD_Local, "CD_Local");
            this.CD_Local.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local.BackgroundImage = null;
            this.CD_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Local.Name = "CD_Local";
            this.CD_Local.NM_Alias = "";
            this.CD_Local.NM_Campo = "cd_local";
            this.CD_Local.NM_CampoBusca = "cd_local";
            this.CD_Local.NM_Param = "@P_CD_EMPRESA";
            this.CD_Local.QTD_Zero = 0;
            this.CD_Local.ST_AutoInc = false;
            this.CD_Local.ST_DisableAuto = false;
            this.CD_Local.ST_Float = false;
            this.CD_Local.ST_Gravar = true;
            this.CD_Local.ST_Int = false;
            this.CD_Local.ST_LimpaCampo = true;
            this.CD_Local.ST_NotNull = true;
            this.CD_Local.ST_PrimaryKey = false;
            // 
            // DS_Produto
            // 
            this.DS_Produto.AccessibleDescription = null;
            this.DS_Produto.AccessibleName = null;
            resources.ApplyResources(this.DS_Produto, "DS_Produto");
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BackgroundImage = null;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "ds_produto";
            this.DS_Produto.NM_CampoBusca = "ds_produto";
            this.DS_Produto.NM_Param = "@P_NM_EMPRESA";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            // 
            // CD_Produto
            // 
            this.CD_Produto.AccessibleDescription = null;
            this.CD_Produto.AccessibleName = null;
            resources.ApplyResources(this.CD_Produto, "CD_Produto");
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BackgroundImage = null;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "cd_Produto";
            this.CD_Produto.NM_CampoBusca = "cd_Produto";
            this.CD_Produto.NM_Param = "@P_CD_";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = true;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = false;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.AccessibleDescription = null;
            this.NM_Empresa.AccessibleName = null;
            resources.ApplyResources(this.NM_Empresa, "NM_Empresa");
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BackgroundImage = null;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "nm_empresa";
            this.NM_Empresa.NM_CampoBusca = "nm_empresa";
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
            // CD_Empresa
            // 
            this.CD_Empresa.AccessibleDescription = null;
            this.CD_Empresa.AccessibleName = null;
            resources.ApplyResources(this.CD_Empresa, "CD_Empresa");
            this.CD_Empresa.BackColor = System.Drawing.Color.White;
            this.CD_Empresa.BackgroundImage = null;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "cd_empresa";
            this.CD_Empresa.NM_CampoBusca = "cd_empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            // 
            // BS_Lan_Estoque
            // 
            this.BS_Lan_Estoque.DataSource = typeof(CamadaDados.Estoque.TList_RegLanEstoque);
            // 
            // TFEmbalagem
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pnl_Lan_Estoque);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFEmbalagem";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFEmbalagem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFEmbalagem_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pnl_Lan_Estoque.ResumeLayout(false);
            this.pnl_Lan_Estoque.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qtd_Saida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qtd_Entrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Lan_Estoque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        public System.Windows.Forms.BindingSource BS_Lan_Estoque;
        private Componentes.PanelDados pnl_Lan_Estoque;
        private Componentes.EditData DT_Lancamento;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.PanelDados panelDados2;
        private Componentes.EditFloat Qtd_Entrada;
        private System.Windows.Forms.Label lbl_quantidade;
        private Componentes.EditDefault Sigla;
        private Componentes.EditDefault DS_Observacao;
        private Componentes.EditDefault DS_Local;
        private Componentes.EditDefault DS_Produto;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.ComboBoxDefault tp_movimento;
        private Componentes.EditFloat VL_Unitario;
        private Componentes.EditFloat Qtd_Saida;
        private Componentes.EditDefault CD_Local;
        private Componentes.EditDefault CD_Produto;
        private Componentes.EditDefault CD_Empresa;
    }
}