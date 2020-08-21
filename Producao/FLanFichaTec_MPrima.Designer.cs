namespace Producao
{
    partial class TFLanFichaTec_MPrima
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
            System.Windows.Forms.Label quantidadeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanFichaTec_MPrima));
            System.Windows.Forms.Label pc_quebratecnicaLabel;
            System.Windows.Forms.Label label2;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.PC_QuebraTecnica = new Componentes.EditFloat(this.components);
            this.bsFichaTec_MPrima = new System.Windows.Forms.BindingSource(this.components);
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.SG_UniQTD = new Componentes.EditDefault(this.components);
            this.bb_versao_mprima = new System.Windows.Forms.Button();
            this.cd_versao_mprima = new Componentes.EditDefault(this.components);
            this.DS_Local = new Componentes.EditDefault(this.components);
            this.BB_Local = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Local = new Componentes.EditDefault(this.components);
            this.DS_Unidade = new Componentes.EditDefault(this.components);
            this.BB_Unidade = new System.Windows.Forms.Button();
            this.label57 = new System.Windows.Forms.Label();
            this.CD_Unidade = new Componentes.EditDefault(this.components);
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.BB_Produto = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            quantidadeLabel = new System.Windows.Forms.Label();
            pc_quebratecnicaLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PC_QuebraTecnica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec_MPrima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // quantidadeLabel
            // 
            resources.ApplyResources(quantidadeLabel, "quantidadeLabel");
            quantidadeLabel.Name = "quantidadeLabel";
            // 
            // pc_quebratecnicaLabel
            // 
            resources.ApplyResources(pc_quebratecnicaLabel, "pc_quebratecnicaLabel");
            pc_quebratecnicaLabel.Name = "pc_quebratecnicaLabel";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
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
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.bb_versao_mprima);
            this.pDados.Controls.Add(this.cd_versao_mprima);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.DS_Local);
            this.pDados.Controls.Add(this.BB_Local);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.CD_Local);
            this.pDados.Controls.Add(this.DS_Unidade);
            this.pDados.Controls.Add(this.BB_Unidade);
            this.pDados.Controls.Add(this.label57);
            this.pDados.Controls.Add(this.CD_Unidade);
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.BB_Produto);
            this.pDados.Controls.Add(this.label55);
            this.pDados.Controls.Add(this.CD_Produto);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.panelDados1);
            resources.ApplyResources(this.radioGroup1, "radioGroup1");
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabStop = false;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.SystemColors.Control;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.PC_QuebraTecnica);
            this.panelDados1.Controls.Add(this.Quantidade);
            this.panelDados1.Controls.Add(quantidadeLabel);
            this.panelDados1.Controls.Add(pc_quebratecnicaLabel);
            this.panelDados1.Controls.Add(this.SG_UniQTD);
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // PC_QuebraTecnica
            // 
            this.PC_QuebraTecnica.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec_MPrima, "Pc_quebra_tec", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N5"));
            this.PC_QuebraTecnica.DecimalPlaces = 5;
            resources.ApplyResources(this.PC_QuebraTecnica, "PC_QuebraTecnica");
            this.PC_QuebraTecnica.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PC_QuebraTecnica.Name = "PC_QuebraTecnica";
            this.PC_QuebraTecnica.NM_Alias = "";
            this.PC_QuebraTecnica.NM_Campo = "";
            this.PC_QuebraTecnica.NM_Param = "";
            this.PC_QuebraTecnica.Operador = "";
            this.PC_QuebraTecnica.ST_AutoInc = false;
            this.PC_QuebraTecnica.ST_DisableAuto = false;
            this.PC_QuebraTecnica.ST_Gravar = true;
            this.PC_QuebraTecnica.ST_LimparCampo = true;
            this.PC_QuebraTecnica.ST_NotNull = false;
            this.PC_QuebraTecnica.ST_PrimaryKey = false;
            // 
            // bsFichaTec_MPrima
            // 
            this.bsFichaTec_MPrima.DataSource = typeof(CamadaDados.Producao.Producao.TRegistro_FichaTec_MPrima);
            // 
            // Quantidade
            // 
            this.Quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec_MPrima, "Qtd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N3"));
            this.Quantidade.DecimalPlaces = 3;
            resources.ApplyResources(this.Quantidade, "Quantidade");
            this.Quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Quantidade.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.NM_Alias = "";
            this.Quantidade.NM_Campo = "";
            this.Quantidade.NM_Param = "";
            this.Quantidade.Operador = "";
            this.Quantidade.ST_AutoInc = false;
            this.Quantidade.ST_DisableAuto = false;
            this.Quantidade.ST_Gravar = true;
            this.Quantidade.ST_LimparCampo = true;
            this.Quantidade.ST_NotNull = true;
            this.Quantidade.ST_PrimaryKey = false;
            // 
            // SG_UniQTD
            // 
            this.SG_UniQTD.BackColor = System.Drawing.SystemColors.Window;
            this.SG_UniQTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SG_UniQTD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SG_UniQTD.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec_MPrima, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.SG_UniQTD, "SG_UniQTD");
            this.SG_UniQTD.Name = "SG_UniQTD";
            this.SG_UniQTD.NM_Alias = "";
            this.SG_UniQTD.NM_Campo = "Sigla_Unidade";
            this.SG_UniQTD.NM_CampoBusca = "Sigla_Unidade";
            this.SG_UniQTD.NM_Param = "@P_SIGLA_UNIDADE";
            this.SG_UniQTD.QTD_Zero = 0;
            this.SG_UniQTD.ReadOnly = true;
            this.SG_UniQTD.ST_AutoInc = false;
            this.SG_UniQTD.ST_DisableAuto = false;
            this.SG_UniQTD.ST_Float = false;
            this.SG_UniQTD.ST_Gravar = false;
            this.SG_UniQTD.ST_Int = false;
            this.SG_UniQTD.ST_LimpaCampo = true;
            this.SG_UniQTD.ST_NotNull = false;
            this.SG_UniQTD.ST_PrimaryKey = false;
            this.SG_UniQTD.TextOld = null;
            // 
            // bb_versao_mprima
            // 
            this.bb_versao_mprima.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_versao_mprima, "bb_versao_mprima");
            this.bb_versao_mprima.Name = "bb_versao_mprima";
            this.bb_versao_mprima.UseVisualStyleBackColor = false;
            this.bb_versao_mprima.Click += new System.EventHandler(this.bb_versao_mprima_Click);
            // 
            // cd_versao_mprima
            // 
            this.cd_versao_mprima.BackColor = System.Drawing.SystemColors.Window;
            this.cd_versao_mprima.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_versao_mprima.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_versao_mprima.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec_MPrima, "Id_formulacao_mprimastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_versao_mprima, "cd_versao_mprima");
            this.cd_versao_mprima.Name = "cd_versao_mprima";
            this.cd_versao_mprima.NM_Alias = "";
            this.cd_versao_mprima.NM_Campo = "id_formulacao";
            this.cd_versao_mprima.NM_CampoBusca = "id_formulacao";
            this.cd_versao_mprima.NM_Param = "@P_CD_VERSAO_MPRIMA";
            this.cd_versao_mprima.QTD_Zero = 7;
            this.cd_versao_mprima.ST_AutoInc = false;
            this.cd_versao_mprima.ST_DisableAuto = false;
            this.cd_versao_mprima.ST_Float = false;
            this.cd_versao_mprima.ST_Gravar = true;
            this.cd_versao_mprima.ST_Int = false;
            this.cd_versao_mprima.ST_LimpaCampo = true;
            this.cd_versao_mprima.ST_NotNull = false;
            this.cd_versao_mprima.ST_PrimaryKey = false;
            this.cd_versao_mprima.TextOld = null;
            this.cd_versao_mprima.Leave += new System.EventHandler(this.cd_versao_mprima_Leave);
            // 
            // DS_Local
            // 
            this.DS_Local.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec_MPrima, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Local, "DS_Local");
            this.DS_Local.Name = "DS_Local";
            this.DS_Local.NM_Alias = "";
            this.DS_Local.NM_Campo = "DS_Local";
            this.DS_Local.NM_CampoBusca = "DS_Local";
            this.DS_Local.NM_Param = "@P_DS_UNIDADE";
            this.DS_Local.QTD_Zero = 0;
            this.DS_Local.ReadOnly = true;
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
            // BB_Local
            // 
            resources.ApplyResources(this.BB_Local, "BB_Local");
            this.BB_Local.Name = "BB_Local";
            this.BB_Local.UseVisualStyleBackColor = true;
            this.BB_Local.Click += new System.EventHandler(this.BB_Local_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CD_Local
            // 
            this.CD_Local.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec_MPrima, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Local, "CD_Local");
            this.CD_Local.Name = "CD_Local";
            this.CD_Local.NM_Alias = "";
            this.CD_Local.NM_Campo = "CD_Local";
            this.CD_Local.NM_CampoBusca = "CD_Local";
            this.CD_Local.NM_Param = "@P_CD_UNIDADE";
            this.CD_Local.QTD_Zero = 0;
            this.CD_Local.ST_AutoInc = false;
            this.CD_Local.ST_DisableAuto = false;
            this.CD_Local.ST_Float = false;
            this.CD_Local.ST_Gravar = true;
            this.CD_Local.ST_Int = false;
            this.CD_Local.ST_LimpaCampo = true;
            this.CD_Local.ST_NotNull = false;
            this.CD_Local.ST_PrimaryKey = false;
            this.CD_Local.TextOld = null;
            this.CD_Local.Leave += new System.EventHandler(this.CD_Local_Leave);
            // 
            // DS_Unidade
            // 
            this.DS_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec_MPrima, "Ds_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Unidade, "DS_Unidade");
            this.DS_Unidade.Name = "DS_Unidade";
            this.DS_Unidade.NM_Alias = "";
            this.DS_Unidade.NM_Campo = "DS_Unidade";
            this.DS_Unidade.NM_CampoBusca = "DS_Unidade";
            this.DS_Unidade.NM_Param = "@P_DS_UNIDADE";
            this.DS_Unidade.QTD_Zero = 0;
            this.DS_Unidade.ReadOnly = true;
            this.DS_Unidade.ST_AutoInc = false;
            this.DS_Unidade.ST_DisableAuto = false;
            this.DS_Unidade.ST_Float = false;
            this.DS_Unidade.ST_Gravar = false;
            this.DS_Unidade.ST_Int = false;
            this.DS_Unidade.ST_LimpaCampo = true;
            this.DS_Unidade.ST_NotNull = false;
            this.DS_Unidade.ST_PrimaryKey = false;
            this.DS_Unidade.TextOld = null;
            // 
            // BB_Unidade
            // 
            resources.ApplyResources(this.BB_Unidade, "BB_Unidade");
            this.BB_Unidade.Name = "BB_Unidade";
            this.BB_Unidade.UseVisualStyleBackColor = true;
            this.BB_Unidade.Click += new System.EventHandler(this.BB_Unidade_Click);
            // 
            // label57
            // 
            resources.ApplyResources(this.label57, "label57");
            this.label57.Name = "label57";
            // 
            // CD_Unidade
            // 
            this.CD_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec_MPrima, "Cd_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Unidade, "CD_Unidade");
            this.CD_Unidade.Name = "CD_Unidade";
            this.CD_Unidade.NM_Alias = "";
            this.CD_Unidade.NM_Campo = "CD_Unidade";
            this.CD_Unidade.NM_CampoBusca = "CD_Unidade";
            this.CD_Unidade.NM_Param = "@P_CD_UNIDADE";
            this.CD_Unidade.QTD_Zero = 0;
            this.CD_Unidade.ST_AutoInc = false;
            this.CD_Unidade.ST_DisableAuto = false;
            this.CD_Unidade.ST_Float = false;
            this.CD_Unidade.ST_Gravar = true;
            this.CD_Unidade.ST_Int = false;
            this.CD_Unidade.ST_LimpaCampo = true;
            this.CD_Unidade.ST_NotNull = true;
            this.CD_Unidade.ST_PrimaryKey = false;
            this.CD_Unidade.TextOld = null;
            this.CD_Unidade.Leave += new System.EventHandler(this.CD_Unidade_Leave);
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec_MPrima, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Produto, "DS_Produto");
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.ReadOnly = true;
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
            // BB_Produto
            // 
            resources.ApplyResources(this.BB_Produto, "BB_Produto");
            this.BB_Produto.Name = "BB_Produto";
            this.BB_Produto.UseVisualStyleBackColor = true;
            this.BB_Produto.Click += new System.EventHandler(this.BB_Produto_Click);
            // 
            // label55
            // 
            resources.ApplyResources(this.label55, "label55");
            this.label55.Name = "label55";
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec_MPrima, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Produto, "CD_Produto");
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // TFLanFichaTec_MPrima
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanFichaTec_MPrima";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanFichaTec_MPrima_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanFichaTec_MPrima_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PC_QuebraTecnica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec_MPrima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Button BB_Unidade;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Button BB_Local;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_versao_mprima;
        private Componentes.EditDefault cd_versao_mprima;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditFloat PC_QuebraTecnica;
        private Componentes.EditFloat Quantidade;
        private System.Windows.Forms.BindingSource bsFichaTec_MPrima;
        private Componentes.EditDefault DS_Produto;
        private System.Windows.Forms.Button BB_Produto;
        private Componentes.EditDefault CD_Produto;
        private Componentes.EditDefault SG_UniQTD;
        private Componentes.EditDefault DS_Unidade;
        private Componentes.EditDefault CD_Unidade;
        private Componentes.EditDefault DS_Local;
        private Componentes.EditDefault CD_Local;
    }
}