namespace Estoque
{
    partial class TFLanAcertarVlMedio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanAcertarVlMedio));
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label8;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.pnl_view = new Componentes.PanelDados(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_valores = new Componentes.PanelDados(this.components);
            this.VL_MEDIO = new Componentes.EditDefault(this.components);
            this.VL_SALDO = new Componentes.EditDefault(this.components);
            this.TOT_SALDO = new Componentes.EditDefault(this.components);
            this.DS_Observacao = new Componentes.EditDefault(this.components);
            this.BS_Lan_Estoque = new System.Windows.Forms.BindingSource(this.components);
            this.Qtd_Saida = new Componentes.EditFloat(this.components);
            this.DT_Lancamento = new Componentes.EditData(this.components);
            this.BB_Local = new System.Windows.Forms.Button();
            this.DS_Local = new Componentes.EditDefault(this.components);
            this.CD_Local = new Componentes.EditDefault(this.components);
            this.BB_Produto = new System.Windows.Forms.Button();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            label11 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pnl_view.SuspendLayout();
            this.pnl_valores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Lan_Estoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qtd_Saida)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.Name = "label23";
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.Name = "label25";
            // 
            // label27
            // 
            resources.ApplyResources(label27, "label27");
            label27.Name = "label27";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
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
            // tlpCentral
            // 
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.pnl_view);
            this.pDados.Controls.Add(this.DS_Observacao);
            this.pDados.Controls.Add(label22);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.Qtd_Saida);
            this.pDados.Controls.Add(this.DT_Lancamento);
            this.pDados.Controls.Add(label11);
            this.pDados.Controls.Add(this.BB_Local);
            this.pDados.Controls.Add(this.DS_Local);
            this.pDados.Controls.Add(this.CD_Local);
            this.pDados.Controls.Add(label23);
            this.pDados.Controls.Add(this.BB_Produto);
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.Controls.Add(label25);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(label27);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // pnl_view
            // 
            this.pnl_view.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_view.Controls.Add(this.label2);
            this.pnl_view.Controls.Add(this.pnl_valores);
            resources.ApplyResources(this.pnl_view, "pnl_view");
            this.pnl_view.Name = "pnl_view";
            this.pnl_view.NM_ProcDeletar = "";
            this.pnl_view.NM_ProcGravar = "";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Green;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label2, "label2");
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // pnl_valores
            // 
            this.pnl_valores.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_valores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_valores.Controls.Add(this.VL_MEDIO);
            this.pnl_valores.Controls.Add(this.VL_SALDO);
            this.pnl_valores.Controls.Add(this.TOT_SALDO);
            this.pnl_valores.Controls.Add(label12);
            this.pnl_valores.Controls.Add(label3);
            this.pnl_valores.Controls.Add(label8);
            resources.ApplyResources(this.pnl_valores, "pnl_valores");
            this.pnl_valores.Name = "pnl_valores";
            this.pnl_valores.NM_ProcDeletar = "";
            this.pnl_valores.NM_ProcGravar = "";
            // 
            // VL_MEDIO
            // 
            this.VL_MEDIO.BackColor = System.Drawing.SystemColors.Window;
            this.VL_MEDIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VL_MEDIO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.VL_MEDIO, "VL_MEDIO");
            this.VL_MEDIO.Name = "VL_MEDIO";
            this.VL_MEDIO.NM_Alias = "";
            this.VL_MEDIO.NM_Campo = "TP_Movimento";
            this.VL_MEDIO.NM_CampoBusca = "TP_Movimento";
            this.VL_MEDIO.NM_Param = "@P_TP_MOVIMENTO";
            this.VL_MEDIO.QTD_Zero = 0;
            this.VL_MEDIO.ST_AutoInc = false;
            this.VL_MEDIO.ST_DisableAuto = false;
            this.VL_MEDIO.ST_Float = false;
            this.VL_MEDIO.ST_Gravar = false;
            this.VL_MEDIO.ST_Int = false;
            this.VL_MEDIO.ST_LimpaCampo = true;
            this.VL_MEDIO.ST_NotNull = false;
            this.VL_MEDIO.ST_PrimaryKey = false;
            this.VL_MEDIO.TextOld = null;
            // 
            // VL_SALDO
            // 
            this.VL_SALDO.BackColor = System.Drawing.SystemColors.Window;
            this.VL_SALDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VL_SALDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.VL_SALDO, "VL_SALDO");
            this.VL_SALDO.Name = "VL_SALDO";
            this.VL_SALDO.NM_Alias = "";
            this.VL_SALDO.NM_Campo = "TP_Movimento";
            this.VL_SALDO.NM_CampoBusca = "TP_Movimento";
            this.VL_SALDO.NM_Param = "@P_TP_MOVIMENTO";
            this.VL_SALDO.QTD_Zero = 0;
            this.VL_SALDO.ST_AutoInc = false;
            this.VL_SALDO.ST_DisableAuto = false;
            this.VL_SALDO.ST_Float = false;
            this.VL_SALDO.ST_Gravar = false;
            this.VL_SALDO.ST_Int = false;
            this.VL_SALDO.ST_LimpaCampo = true;
            this.VL_SALDO.ST_NotNull = false;
            this.VL_SALDO.ST_PrimaryKey = false;
            this.VL_SALDO.TextOld = null;
            // 
            // TOT_SALDO
            // 
            this.TOT_SALDO.BackColor = System.Drawing.SystemColors.Window;
            this.TOT_SALDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TOT_SALDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.TOT_SALDO, "TOT_SALDO");
            this.TOT_SALDO.Name = "TOT_SALDO";
            this.TOT_SALDO.NM_Alias = "";
            this.TOT_SALDO.NM_Campo = "TP_Movimento";
            this.TOT_SALDO.NM_CampoBusca = "TP_Movimento";
            this.TOT_SALDO.NM_Param = "@P_TP_MOVIMENTO";
            this.TOT_SALDO.QTD_Zero = 0;
            this.TOT_SALDO.ST_AutoInc = false;
            this.TOT_SALDO.ST_DisableAuto = false;
            this.TOT_SALDO.ST_Float = false;
            this.TOT_SALDO.ST_Gravar = false;
            this.TOT_SALDO.ST_Int = false;
            this.TOT_SALDO.ST_LimpaCampo = true;
            this.TOT_SALDO.ST_NotNull = false;
            this.TOT_SALDO.ST_PrimaryKey = false;
            this.TOT_SALDO.TextOld = null;
            // 
            // DS_Observacao
            // 
            this.DS_Observacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Observacao, "DS_Observacao");
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
            this.DS_Observacao.TextOld = null;
            // 
            // BS_Lan_Estoque
            // 
            this.BS_Lan_Estoque.DataSource = typeof(CamadaDados.Estoque.TList_RegLanEstoque);
            // 
            // Qtd_Saida
            // 
            this.Qtd_Saida.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Lan_Estoque, "Vl_medioestoque", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Qtd_Saida.DecimalPlaces = 4;
            resources.ApplyResources(this.Qtd_Saida, "Qtd_Saida");
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
            this.Qtd_Saida.ST_NotNull = false;
            this.Qtd_Saida.ST_PrimaryKey = false;
            // 
            // DT_Lancamento
            // 
            this.DT_Lancamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Lancamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Dt_lancto_STR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DT_Lancamento, "DT_Lancamento");
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
            // BB_Local
            // 
            this.BB_Local.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.BB_Local, "BB_Local");
            this.BB_Local.Name = "BB_Local";
            this.BB_Local.UseVisualStyleBackColor = false;
            this.BB_Local.Click += new System.EventHandler(this.BB_Local_Click);
            // 
            // DS_Local
            // 
            this.DS_Local.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Local, "DS_Local");
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
            this.DS_Local.TextOld = null;
            // 
            // CD_Local
            // 
            this.CD_Local.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Local, "CD_Local");
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
            this.CD_Local.TextOld = null;
            this.CD_Local.Leave += new System.EventHandler(this.CD_Local_Leave);
            // 
            // BB_Produto
            // 
            this.BB_Produto.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.BB_Produto, "BB_Produto");
            this.BB_Produto.Name = "BB_Produto";
            this.BB_Produto.UseVisualStyleBackColor = false;
            this.BB_Produto.Click += new System.EventHandler(this.BB_Produto_Click);
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Produto, "DS_Produto");
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
            this.DS_Produto.TextOld = null;
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Produto, "CD_Produto");
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
            this.CD_Produto.TextOld = null;
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.BB_Empresa, "BB_Empresa");
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.UseVisualStyleBackColor = false;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.NM_Empresa, "NM_Empresa");
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
            this.NM_Empresa.TextOld = null;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.Color.White;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lan_Estoque, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Empresa, "CD_Empresa");
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
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // TFLanAcertarVlMedio
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanAcertarVlMedio";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanAcertarVlMedio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanAcertarVlMedio_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pnl_view.ResumeLayout(false);
            this.pnl_valores.ResumeLayout(false);
            this.pnl_valores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Lan_Estoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qtd_Saida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private Componentes.EditData DT_Lancamento;
        public System.Windows.Forms.Button BB_Local;
        private Componentes.EditDefault DS_Local;
        public Componentes.EditDefault CD_Local;
        public System.Windows.Forms.Button BB_Produto;
        private Componentes.EditDefault DS_Produto;
        public Componentes.EditDefault CD_Produto;
        public System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault NM_Empresa;
        public Componentes.EditDefault CD_Empresa;
        public Componentes.EditFloat Qtd_Saida;
        private Componentes.EditDefault DS_Observacao;
        public System.Windows.Forms.BindingSource BS_Lan_Estoque;
        private Componentes.PanelDados pnl_view;
        private System.Windows.Forms.Label label2;
        private Componentes.PanelDados pnl_valores;
        private Componentes.EditDefault VL_MEDIO;
        private Componentes.EditDefault VL_SALDO;
        private Componentes.EditDefault TOT_SALDO;
    }
}