namespace Producao
{
    partial class TFLanCustoFixoDireto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanCustoFixoDireto));
            System.Windows.Forms.Label pc_quebratecnicaLabel;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.sigla = new Componentes.EditDefault(this.components);
            this.bsCustoFixoDireto = new System.Windows.Forms.BindingSource(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.pc_custo = new Componentes.EditFloat(this.components);
            this.vl_custo = new Componentes.EditFloat(this.components);
            this.ds_moeda = new Componentes.EditDefault(this.components);
            this.bb_moeda = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SG_UniQTD = new Componentes.EditDefault(this.components);
            this.cd_moeda = new Componentes.EditDefault(this.components);
            this.DS_Unidade = new Componentes.EditDefault(this.components);
            this.BB_Unidade = new System.Windows.Forms.Button();
            this.label57 = new System.Windows.Forms.Label();
            this.CD_Unidade = new Componentes.EditDefault(this.components);
            this.ds_custo = new Componentes.EditDefault(this.components);
            this.bb_custo = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.id_custo = new Componentes.EditDefault(this.components);
            quantidadeLabel = new System.Windows.Forms.Label();
            pc_quebratecnicaLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustoFixoDireto)).BeginInit();
            this.radioGroup1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_custo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_custo)).BeginInit();
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.sigla);
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.ds_moeda);
            this.pDados.Controls.Add(this.bb_moeda);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.SG_UniQTD);
            this.pDados.Controls.Add(this.cd_moeda);
            this.pDados.Controls.Add(this.DS_Unidade);
            this.pDados.Controls.Add(this.BB_Unidade);
            this.pDados.Controls.Add(this.label57);
            this.pDados.Controls.Add(this.CD_Unidade);
            this.pDados.Controls.Add(this.ds_custo);
            this.pDados.Controls.Add(this.bb_custo);
            this.pDados.Controls.Add(this.label55);
            this.pDados.Controls.Add(this.id_custo);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // sigla
            // 
            this.sigla.BackColor = System.Drawing.SystemColors.Window;
            this.sigla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCustoFixoDireto, "Sigla", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.sigla, "sigla");
            this.sigla.Name = "sigla";
            this.sigla.NM_Alias = "";
            this.sigla.NM_Campo = "sigla";
            this.sigla.NM_CampoBusca = "sigla";
            this.sigla.NM_Param = "@P_SIGLA_UNIDADE";
            this.sigla.QTD_Zero = 0;
            this.sigla.ReadOnly = true;
            this.sigla.ST_AutoInc = false;
            this.sigla.ST_DisableAuto = false;
            this.sigla.ST_Float = false;
            this.sigla.ST_Gravar = false;
            this.sigla.ST_Int = false;
            this.sigla.ST_LimpaCampo = true;
            this.sigla.ST_NotNull = false;
            this.sigla.ST_PrimaryKey = false;
            this.sigla.TextOld = null;
            // 
            // bsCustoFixoDireto
            // 
            this.bsCustoFixoDireto.DataSource = typeof(CamadaDados.Producao.Producao.TList_CustoFixo_Direto);
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
            this.panelDados1.Controls.Add(this.pc_custo);
            this.panelDados1.Controls.Add(this.vl_custo);
            this.panelDados1.Controls.Add(quantidadeLabel);
            this.panelDados1.Controls.Add(pc_quebratecnicaLabel);
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // pc_custo
            // 
            this.pc_custo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCustoFixoDireto, "Pc_custo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N5"));
            this.pc_custo.DecimalPlaces = 5;
            resources.ApplyResources(this.pc_custo, "pc_custo");
            this.pc_custo.Name = "pc_custo";
            this.pc_custo.NM_Alias = "";
            this.pc_custo.NM_Campo = "pc_custo";
            this.pc_custo.NM_Param = "@P_PC_CUSTO";
            this.pc_custo.Operador = "";
            this.pc_custo.ST_AutoInc = false;
            this.pc_custo.ST_DisableAuto = false;
            this.pc_custo.ST_Gravar = true;
            this.pc_custo.ST_LimparCampo = true;
            this.pc_custo.ST_NotNull = false;
            this.pc_custo.ST_PrimaryKey = false;
            // 
            // vl_custo
            // 
            this.vl_custo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCustoFixoDireto, "Vl_custo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.vl_custo.DecimalPlaces = 2;
            resources.ApplyResources(this.vl_custo, "vl_custo");
            this.vl_custo.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.vl_custo.Name = "vl_custo";
            this.vl_custo.NM_Alias = "";
            this.vl_custo.NM_Campo = "vl_custo";
            this.vl_custo.NM_Param = "VL_CUSTO";
            this.vl_custo.Operador = "";
            this.vl_custo.ST_AutoInc = false;
            this.vl_custo.ST_DisableAuto = false;
            this.vl_custo.ST_Gravar = true;
            this.vl_custo.ST_LimparCampo = true;
            this.vl_custo.ST_NotNull = true;
            this.vl_custo.ST_PrimaryKey = false;
            // 
            // ds_moeda
            // 
            this.ds_moeda.BackColor = System.Drawing.SystemColors.Window;
            this.ds_moeda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_moeda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCustoFixoDireto, "Ds_moeda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_moeda, "ds_moeda");
            this.ds_moeda.Name = "ds_moeda";
            this.ds_moeda.NM_Alias = "";
            this.ds_moeda.NM_Campo = "ds_moeda_singular";
            this.ds_moeda.NM_CampoBusca = "ds_moeda_singular";
            this.ds_moeda.NM_Param = "@P_DS_UNIDADE";
            this.ds_moeda.QTD_Zero = 0;
            this.ds_moeda.ReadOnly = true;
            this.ds_moeda.ST_AutoInc = false;
            this.ds_moeda.ST_DisableAuto = false;
            this.ds_moeda.ST_Float = false;
            this.ds_moeda.ST_Gravar = false;
            this.ds_moeda.ST_Int = false;
            this.ds_moeda.ST_LimpaCampo = true;
            this.ds_moeda.ST_NotNull = false;
            this.ds_moeda.ST_PrimaryKey = false;
            this.ds_moeda.TextOld = null;
            // 
            // bb_moeda
            // 
            resources.ApplyResources(this.bb_moeda, "bb_moeda");
            this.bb_moeda.Name = "bb_moeda";
            this.bb_moeda.UseVisualStyleBackColor = true;
            this.bb_moeda.Click += new System.EventHandler(this.bb_moeda_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // SG_UniQTD
            // 
            this.SG_UniQTD.BackColor = System.Drawing.SystemColors.Window;
            this.SG_UniQTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SG_UniQTD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SG_UniQTD.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCustoFixoDireto, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            // cd_moeda
            // 
            this.cd_moeda.BackColor = System.Drawing.SystemColors.Window;
            this.cd_moeda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_moeda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCustoFixoDireto, "Cd_moeda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_moeda, "cd_moeda");
            this.cd_moeda.Name = "cd_moeda";
            this.cd_moeda.NM_Alias = "";
            this.cd_moeda.NM_Campo = "cd_moeda";
            this.cd_moeda.NM_CampoBusca = "cd_moeda";
            this.cd_moeda.NM_Param = "@P_CD_UNIDADE";
            this.cd_moeda.QTD_Zero = 0;
            this.cd_moeda.ST_AutoInc = false;
            this.cd_moeda.ST_DisableAuto = false;
            this.cd_moeda.ST_Float = false;
            this.cd_moeda.ST_Gravar = true;
            this.cd_moeda.ST_Int = true;
            this.cd_moeda.ST_LimpaCampo = true;
            this.cd_moeda.ST_NotNull = false;
            this.cd_moeda.ST_PrimaryKey = false;
            this.cd_moeda.TextOld = null;
            this.cd_moeda.Leave += new System.EventHandler(this.cd_moeda_Leave);
            // 
            // DS_Unidade
            // 
            this.DS_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCustoFixoDireto, "Ds_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.CD_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCustoFixoDireto, "Cd_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.CD_Unidade.ST_Int = true;
            this.CD_Unidade.ST_LimpaCampo = true;
            this.CD_Unidade.ST_NotNull = true;
            this.CD_Unidade.ST_PrimaryKey = false;
            this.CD_Unidade.TextOld = null;
            this.CD_Unidade.Leave += new System.EventHandler(this.CD_Unidade_Leave);
            // 
            // ds_custo
            // 
            this.ds_custo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_custo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_custo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_custo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCustoFixoDireto, "Ds_custo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_custo, "ds_custo");
            this.ds_custo.Name = "ds_custo";
            this.ds_custo.NM_Alias = "";
            this.ds_custo.NM_Campo = "ds_custo";
            this.ds_custo.NM_CampoBusca = "ds_custo";
            this.ds_custo.NM_Param = "@P_DS_PRODUTO";
            this.ds_custo.QTD_Zero = 0;
            this.ds_custo.ReadOnly = true;
            this.ds_custo.ST_AutoInc = false;
            this.ds_custo.ST_DisableAuto = false;
            this.ds_custo.ST_Float = false;
            this.ds_custo.ST_Gravar = false;
            this.ds_custo.ST_Int = false;
            this.ds_custo.ST_LimpaCampo = true;
            this.ds_custo.ST_NotNull = false;
            this.ds_custo.ST_PrimaryKey = false;
            this.ds_custo.TextOld = null;
            // 
            // bb_custo
            // 
            resources.ApplyResources(this.bb_custo, "bb_custo");
            this.bb_custo.Name = "bb_custo";
            this.bb_custo.UseVisualStyleBackColor = true;
            this.bb_custo.Click += new System.EventHandler(this.bb_custo_Click);
            // 
            // label55
            // 
            resources.ApplyResources(this.label55, "label55");
            this.label55.Name = "label55";
            // 
            // id_custo
            // 
            this.id_custo.BackColor = System.Drawing.SystemColors.Window;
            this.id_custo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_custo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_custo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCustoFixoDireto, "Id_custostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.id_custo, "id_custo");
            this.id_custo.Name = "id_custo";
            this.id_custo.NM_Alias = "";
            this.id_custo.NM_Campo = "id_custo";
            this.id_custo.NM_CampoBusca = "id_custo";
            this.id_custo.NM_Param = "@P_CD_PRODUTO";
            this.id_custo.QTD_Zero = 0;
            this.id_custo.ST_AutoInc = false;
            this.id_custo.ST_DisableAuto = false;
            this.id_custo.ST_Float = false;
            this.id_custo.ST_Gravar = true;
            this.id_custo.ST_Int = true;
            this.id_custo.ST_LimpaCampo = true;
            this.id_custo.ST_NotNull = true;
            this.id_custo.ST_PrimaryKey = false;
            this.id_custo.TextOld = null;
            this.id_custo.Leave += new System.EventHandler(this.id_custo_Leave);
            // 
            // TFLanCustoFixoDireto
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanCustoFixoDireto";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanCustoFixoDireto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanCustoFixoDireto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustoFixoDireto)).EndInit();
            this.radioGroup1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_custo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_custo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditFloat pc_custo;
        private Componentes.EditFloat vl_custo;
        private Componentes.EditDefault SG_UniQTD;
        private Componentes.EditDefault ds_moeda;
        private System.Windows.Forms.Button bb_moeda;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_moeda;
        private Componentes.EditDefault DS_Unidade;
        private System.Windows.Forms.Button BB_Unidade;
        private System.Windows.Forms.Label label57;
        private Componentes.EditDefault CD_Unidade;
        private Componentes.EditDefault ds_custo;
        private System.Windows.Forms.Button bb_custo;
        private System.Windows.Forms.Label label55;
        private Componentes.EditDefault id_custo;
        private System.Windows.Forms.BindingSource bsCustoFixoDireto;
        private Componentes.EditDefault sigla;
    }
}