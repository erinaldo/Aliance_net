namespace Compra
{
    partial class TFRequisicao
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
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRequisicao));
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label ds_observacaoLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label dt_requisicaostrLabel;
            System.Windows.Forms.Label cd_produtoLabel;
            System.Windows.Forms.Label cd_clifor_requisitanteLabel;
            System.Windows.Forms.Label cd_empresaLabel;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.cbRequisicao = new Componentes.ComboBoxDefault(this.components);
            this.bsRequisicao = new System.Windows.Forms.BindingSource(this.components);
            this.cbRequisitante = new Componentes.ComboBoxDefault(this.components);
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.bb_addProduto = new System.Windows.Forms.Button();
            this.bb_local = new System.Windows.Forms.Button();
            this.ds_local = new Componentes.EditDefault(this.components);
            this.cd_local = new Componentes.EditDefault(this.components);
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.quantidade = new Componentes.EditFloat(this.components);
            this.dt_requisicao = new Componentes.EditData(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ds_observacaoLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            dt_requisicaostrLabel = new System.Windows.Forms.Label();
            cd_produtoLabel = new System.Windows.Forms.Label();
            cd_clifor_requisitanteLabel = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // ds_observacaoLabel
            // 
            resources.ApplyResources(ds_observacaoLabel, "ds_observacaoLabel");
            ds_observacaoLabel.Name = "ds_observacaoLabel";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // dt_requisicaostrLabel
            // 
            resources.ApplyResources(dt_requisicaostrLabel, "dt_requisicaostrLabel");
            dt_requisicaostrLabel.Name = "dt_requisicaostrLabel";
            // 
            // cd_produtoLabel
            // 
            resources.ApplyResources(cd_produtoLabel, "cd_produtoLabel");
            cd_produtoLabel.Name = "cd_produtoLabel";
            // 
            // cd_clifor_requisitanteLabel
            // 
            resources.ApplyResources(cd_clifor_requisitanteLabel, "cd_clifor_requisitanteLabel");
            cd_clifor_requisitanteLabel.Name = "cd_clifor_requisitanteLabel";
            // 
            // cd_empresaLabel
            // 
            resources.ApplyResources(cd_empresaLabel, "cd_empresaLabel");
            cd_empresaLabel.Name = "cd_empresaLabel";
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
            // tlpCentral
            // 
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pDados
            // 
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.Controls.Add(this.cbRequisicao);
            this.pDados.Controls.Add(this.cbRequisitante);
            this.pDados.Controls.Add(this.cbEmpresa);
            this.pDados.Controls.Add(this.bb_addProduto);
            this.pDados.Controls.Add(this.bb_local);
            this.pDados.Controls.Add(this.ds_local);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.cd_local);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.sigla_unidade);
            this.pDados.Controls.Add(this.quantidade);
            this.pDados.Controls.Add(this.dt_requisicao);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(ds_observacaoLabel);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(dt_requisicaostrLabel);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(cd_produtoLabel);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(cd_clifor_requisitanteLabel);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // cbRequisicao
            // 
            this.cbRequisicao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRequisicao, "Id_tprequisicao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbRequisicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRequisicao.FormattingEnabled = true;
            resources.ApplyResources(this.cbRequisicao, "cbRequisicao");
            this.cbRequisicao.Name = "cbRequisicao";
            this.cbRequisicao.NM_Alias = "";
            this.cbRequisicao.NM_Campo = "";
            this.cbRequisicao.NM_Param = "";
            this.cbRequisicao.ST_Gravar = true;
            this.cbRequisicao.ST_LimparCampo = true;
            this.cbRequisicao.ST_NotNull = true;
            this.cbRequisicao.SelectedIndexChanged += new System.EventHandler(this.cbRequisicao_SelectedIndexChanged);
            // 
            // bsRequisicao
            // 
            this.bsRequisicao.DataSource = typeof(CamadaDados.Compra.Lancamento.TList_Requisicao);
            // 
            // cbRequisitante
            // 
            this.cbRequisitante.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRequisicao, "Cd_clifor_requisitante", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbRequisitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRequisitante.FormattingEnabled = true;
            resources.ApplyResources(this.cbRequisitante, "cbRequisitante");
            this.cbRequisitante.Name = "cbRequisitante";
            this.cbRequisitante.NM_Alias = "";
            this.cbRequisitante.NM_Campo = "";
            this.cbRequisitante.NM_Param = "";
            this.cbRequisitante.ST_Gravar = true;
            this.cbRequisitante.ST_LimparCampo = true;
            this.cbRequisitante.ST_NotNull = true;
            this.cbRequisitante.SelectedIndexChanged += new System.EventHandler(this.cbRequisitante_SelectedIndexChanged);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRequisicao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            resources.ApplyResources(this.cbEmpresa, "cbEmpresa");
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.ST_Gravar = true;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = true;
            // 
            // bb_addProduto
            // 
            resources.ApplyResources(this.bb_addProduto, "bb_addProduto");
            this.bb_addProduto.Name = "bb_addProduto";
            this.bb_addProduto.TabStop = false;
            this.bb_addProduto.UseVisualStyleBackColor = true;
            this.bb_addProduto.Click += new System.EventHandler(this.bb_addProduto_Click);
            // 
            // bb_local
            // 
            this.bb_local.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_local, "bb_local");
            this.bb_local.Name = "bb_local";
            this.bb_local.UseVisualStyleBackColor = false;
            this.bb_local.Click += new System.EventHandler(this.bb_local_Click);
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_local, "ds_local");
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_DS_CCUSTO";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = false;
            this.ds_local.ST_Int = false;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = false;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TextOld = null;
            // 
            // cd_local
            // 
            this.cd_local.BackColor = System.Drawing.SystemColors.Window;
            this.cd_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_local, "cd_local");
            this.cd_local.Name = "cd_local";
            this.cd_local.NM_Alias = "";
            this.cd_local.NM_Campo = "cd_local";
            this.cd_local.NM_CampoBusca = "cd_local";
            this.cd_local.NM_Param = "@P_CD_CCUSTO";
            this.cd_local.QTD_Zero = 0;
            this.cd_local.ST_AutoInc = false;
            this.cd_local.ST_DisableAuto = false;
            this.cd_local.ST_Float = false;
            this.cd_local.ST_Gravar = true;
            this.cd_local.ST_Int = false;
            this.cd_local.ST_LimpaCampo = true;
            this.cd_local.ST_NotNull = false;
            this.cd_local.ST_PrimaryKey = false;
            this.cd_local.TextOld = null;
            this.cd_local.Leave += new System.EventHandler(this.cd_local_Leave);
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.sigla_unidade, "sigla_unidade");
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "sigla_unidade";
            this.sigla_unidade.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidade.NM_Param = "@P_SIGLA_UNIDADE";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TextOld = null;
            // 
            // quantidade
            // 
            this.quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRequisicao, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            resources.ApplyResources(this.quantidade, "quantidade");
            this.quantidade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.quantidade.Name = "quantidade";
            this.quantidade.NM_Alias = "";
            this.quantidade.NM_Campo = "";
            this.quantidade.NM_Param = "";
            this.quantidade.Operador = "";
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = true;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = true;
            this.quantidade.ST_PrimaryKey = false;
            // 
            // dt_requisicao
            // 
            this.dt_requisicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_requisicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Dt_requisicaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.dt_requisicao, "dt_requisicao");
            this.dt_requisicao.Name = "dt_requisicao";
            this.dt_requisicao.NM_Alias = "";
            this.dt_requisicao.NM_Campo = "";
            this.dt_requisicao.NM_CampoBusca = "";
            this.dt_requisicao.NM_Param = "";
            this.dt_requisicao.Operador = "";
            this.dt_requisicao.ST_Gravar = true;
            this.dt_requisicao.ST_LimpaCampo = true;
            this.dt_requisicao.ST_NotNull = true;
            this.dt_requisicao.ST_PrimaryKey = false;
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_produto, "bb_produto");
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_produto, "ds_produto");
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_PRODUTO";
            this.ds_produto.QTD_Zero = 0;
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
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_produto, "cd_produto");
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_PRODUTO";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TextOld = null;
            this.cd_produto.TextChanged += new System.EventHandler(this.cd_produto_TextChanged);
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // TFRequisicao
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFRequisicao";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFRequisicao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRequisicao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsRequisicao;
        private Componentes.EditDefault ds_observacao;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditFloat quantidade;
        private Componentes.EditData dt_requisicao;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault sigla_unidade;
        private System.Windows.Forms.Button bb_local;
        private Componentes.EditDefault ds_local;
        private Componentes.EditDefault cd_local;
        private System.Windows.Forms.Button bb_addProduto;
        private Componentes.ComboBoxDefault cbEmpresa;
        private Componentes.ComboBoxDefault cbRequisitante;
        private Componentes.ComboBoxDefault cbRequisicao;
    }
}