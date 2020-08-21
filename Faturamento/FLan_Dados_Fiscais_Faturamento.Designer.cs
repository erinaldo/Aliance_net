namespace Faturamento
{
    partial class TFLan_Dados_Fiscais_Faturamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLan_Dados_Fiscais_Faturamento));
            this.TP_Fiscal = new Componentes.ComboBoxDefault(this.components);
            this.BS_Dados_Fiscais = new System.Windows.Forms.BindingSource(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.DS_CMI = new Componentes.EditDefault(this.components);
            this.label47 = new System.Windows.Forms.Label();
            this.CD_CMI = new Componentes.EditDefault(this.components);
            this.DS_Movto = new Componentes.EditDefault(this.components);
            this.label46 = new System.Windows.Forms.Label();
            this.CD_Movto = new Componentes.EditDefault(this.components);
            this.DS_Serie = new Componentes.EditDefault(this.components);
            this.label45 = new System.Windows.Forms.Label();
            this.Nr_Serie = new Componentes.EditDefault(this.components);
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pnl_Fiscais_Base = new Componentes.PanelDados(this.components);
            this.pnl_Fiscais = new Componentes.PanelDados(this.components);
            this.BB_CMI_NORMAL = new System.Windows.Forms.Button();
            this.BB_Serie_NORMAL = new System.Windows.Forms.Button();
            this.BB_Movto_NORMAL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Dados_Fiscais)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.pnl_Fiscais_Base.SuspendLayout();
            this.pnl_Fiscais.SuspendLayout();
            this.SuspendLayout();
            // 
            // TP_Fiscal
            // 
            this.TP_Fiscal.AccessibleDescription = null;
            this.TP_Fiscal.AccessibleName = null;
            resources.ApplyResources(this.TP_Fiscal, "TP_Fiscal");
            this.TP_Fiscal.BackgroundImage = null;
            this.TP_Fiscal.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_Dados_Fiscais, "Tp_fiscal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Fiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TP_Fiscal.FormattingEnabled = true;
            this.TP_Fiscal.Name = "TP_Fiscal";
            this.TP_Fiscal.NM_Alias = "";
            this.TP_Fiscal.NM_Campo = "";
            this.TP_Fiscal.NM_Param = "";
            this.TP_Fiscal.ST_Gravar = true;
            this.TP_Fiscal.ST_LimparCampo = true;
            this.TP_Fiscal.ST_NotNull = true;
            // 
            // label34
            // 
            this.label34.AccessibleDescription = null;
            this.label34.AccessibleName = null;
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // DS_CMI
            // 
            this.DS_CMI.AccessibleDescription = null;
            this.DS_CMI.AccessibleName = null;
            resources.ApplyResources(this.DS_CMI, "DS_CMI");
            this.DS_CMI.BackColor = System.Drawing.SystemColors.Window;
            this.DS_CMI.BackgroundImage = null;
            this.DS_CMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_CMI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Dados_Fiscais, "ds_cmi", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_CMI.Name = "DS_CMI";
            this.DS_CMI.NM_Alias = "";
            this.DS_CMI.NM_Campo = "DS_CMI";
            this.DS_CMI.NM_CampoBusca = "DS_CMI";
            this.DS_CMI.NM_Param = "@P_DS_CMI";
            this.DS_CMI.QTD_Zero = 0;
            this.DS_CMI.ReadOnly = true;
            this.DS_CMI.ST_AutoInc = false;
            this.DS_CMI.ST_DisableAuto = false;
            this.DS_CMI.ST_Float = false;
            this.DS_CMI.ST_Gravar = false;
            this.DS_CMI.ST_Int = false;
            this.DS_CMI.ST_LimpaCampo = true;
            this.DS_CMI.ST_NotNull = false;
            this.DS_CMI.ST_PrimaryKey = false;
            // 
            // label47
            // 
            this.label47.AccessibleDescription = null;
            this.label47.AccessibleName = null;
            resources.ApplyResources(this.label47, "label47");
            this.label47.Name = "label47";
            // 
            // CD_CMI
            // 
            this.CD_CMI.AccessibleDescription = null;
            this.CD_CMI.AccessibleName = null;
            resources.ApplyResources(this.CD_CMI, "CD_CMI");
            this.CD_CMI.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CMI.BackgroundImage = null;
            this.CD_CMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CMI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Dados_Fiscais, "Cd_cmistring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_CMI.Name = "CD_CMI";
            this.CD_CMI.NM_Alias = "";
            this.CD_CMI.NM_Campo = "CD_CMI_NORMAL";
            this.CD_CMI.NM_CampoBusca = "CD_CMI";
            this.CD_CMI.NM_Param = "@P_CD_CMI_NORMAL";
            this.CD_CMI.QTD_Zero = 0;
            this.CD_CMI.ST_AutoInc = false;
            this.CD_CMI.ST_DisableAuto = false;
            this.CD_CMI.ST_Float = false;
            this.CD_CMI.ST_Gravar = true;
            this.CD_CMI.ST_Int = false;
            this.CD_CMI.ST_LimpaCampo = true;
            this.CD_CMI.ST_NotNull = false;
            this.CD_CMI.ST_PrimaryKey = false;
            this.CD_CMI.Leave += new System.EventHandler(this.CD_CMI_Leave);
            // 
            // DS_Movto
            // 
            this.DS_Movto.AccessibleDescription = null;
            this.DS_Movto.AccessibleName = null;
            resources.ApplyResources(this.DS_Movto, "DS_Movto");
            this.DS_Movto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Movto.BackgroundImage = null;
            this.DS_Movto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Movto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Dados_Fiscais, "ds_movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Movto.Name = "DS_Movto";
            this.DS_Movto.NM_Alias = "";
            this.DS_Movto.NM_Campo = "DS_Movimentacao";
            this.DS_Movto.NM_CampoBusca = "DS_Movimentacao";
            this.DS_Movto.NM_Param = "@P_DS_MOVIMENTACAO";
            this.DS_Movto.QTD_Zero = 0;
            this.DS_Movto.ReadOnly = true;
            this.DS_Movto.ST_AutoInc = false;
            this.DS_Movto.ST_DisableAuto = false;
            this.DS_Movto.ST_Float = false;
            this.DS_Movto.ST_Gravar = false;
            this.DS_Movto.ST_Int = false;
            this.DS_Movto.ST_LimpaCampo = true;
            this.DS_Movto.ST_NotNull = false;
            this.DS_Movto.ST_PrimaryKey = false;
            // 
            // label46
            // 
            this.label46.AccessibleDescription = null;
            this.label46.AccessibleName = null;
            resources.ApplyResources(this.label46, "label46");
            this.label46.Name = "label46";
            // 
            // CD_Movto
            // 
            this.CD_Movto.AccessibleDescription = null;
            this.CD_Movto.AccessibleName = null;
            resources.ApplyResources(this.CD_Movto, "CD_Movto");
            this.CD_Movto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Movto.BackgroundImage = null;
            this.CD_Movto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Movto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Dados_Fiscais, "Cd_movtostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Movto.Name = "CD_Movto";
            this.CD_Movto.NM_Alias = "";
            this.CD_Movto.NM_Campo = "CD_Movto_Normal";
            this.CD_Movto.NM_CampoBusca = "CD_Movimentacao";
            this.CD_Movto.NM_Param = "@P_CD_MOVTO_NORMAL";
            this.CD_Movto.QTD_Zero = 0;
            this.CD_Movto.ST_AutoInc = false;
            this.CD_Movto.ST_DisableAuto = false;
            this.CD_Movto.ST_Float = false;
            this.CD_Movto.ST_Gravar = true;
            this.CD_Movto.ST_Int = false;
            this.CD_Movto.ST_LimpaCampo = true;
            this.CD_Movto.ST_NotNull = false;
            this.CD_Movto.ST_PrimaryKey = false;
            this.CD_Movto.Leave += new System.EventHandler(this.CD_Movto_Leave);
            // 
            // DS_Serie
            // 
            this.DS_Serie.AccessibleDescription = null;
            this.DS_Serie.AccessibleName = null;
            resources.ApplyResources(this.DS_Serie, "DS_Serie");
            this.DS_Serie.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Serie.BackgroundImage = null;
            this.DS_Serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Serie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Dados_Fiscais, "Ds_SerieNf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Serie.Name = "DS_Serie";
            this.DS_Serie.NM_Alias = "";
            this.DS_Serie.NM_Campo = "DS_SerieNF";
            this.DS_Serie.NM_CampoBusca = "DS_SerieNF";
            this.DS_Serie.NM_Param = "@P_DS_SERIENF";
            this.DS_Serie.QTD_Zero = 0;
            this.DS_Serie.ReadOnly = true;
            this.DS_Serie.ST_AutoInc = false;
            this.DS_Serie.ST_DisableAuto = false;
            this.DS_Serie.ST_Float = false;
            this.DS_Serie.ST_Gravar = false;
            this.DS_Serie.ST_Int = false;
            this.DS_Serie.ST_LimpaCampo = true;
            this.DS_Serie.ST_NotNull = false;
            this.DS_Serie.ST_PrimaryKey = false;
            // 
            // label45
            // 
            this.label45.AccessibleDescription = null;
            this.label45.AccessibleName = null;
            resources.ApplyResources(this.label45, "label45");
            this.label45.Name = "label45";
            // 
            // Nr_Serie
            // 
            this.Nr_Serie.AccessibleDescription = null;
            this.Nr_Serie.AccessibleName = null;
            resources.ApplyResources(this.Nr_Serie, "Nr_Serie");
            this.Nr_Serie.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_Serie.BackgroundImage = null;
            this.Nr_Serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_Serie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Dados_Fiscais, "Nr_serie", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nr_Serie.Name = "Nr_Serie";
            this.Nr_Serie.NM_Alias = "";
            this.Nr_Serie.NM_Campo = "Nr_Serie_Normal";
            this.Nr_Serie.NM_CampoBusca = "Nr_Serie";
            this.Nr_Serie.NM_Param = "@P_NR_SERIE_NORMAL";
            this.Nr_Serie.QTD_Zero = 0;
            this.Nr_Serie.ST_AutoInc = false;
            this.Nr_Serie.ST_DisableAuto = false;
            this.Nr_Serie.ST_Float = false;
            this.Nr_Serie.ST_Gravar = true;
            this.Nr_Serie.ST_Int = false;
            this.Nr_Serie.ST_LimpaCampo = true;
            this.Nr_Serie.ST_NotNull = false;
            this.Nr_Serie.ST_PrimaryKey = false;
            this.Nr_Serie.Leave += new System.EventHandler(this.Nr_Serie_Leave);
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
            // pnl_Fiscais_Base
            // 
            this.pnl_Fiscais_Base.AccessibleDescription = null;
            this.pnl_Fiscais_Base.AccessibleName = null;
            resources.ApplyResources(this.pnl_Fiscais_Base, "pnl_Fiscais_Base");
            this.pnl_Fiscais_Base.BackgroundImage = null;
            this.pnl_Fiscais_Base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Fiscais_Base.Controls.Add(this.pnl_Fiscais);
            this.pnl_Fiscais_Base.Font = null;
            this.pnl_Fiscais_Base.Name = "pnl_Fiscais_Base";
            this.pnl_Fiscais_Base.NM_ProcDeletar = "";
            this.pnl_Fiscais_Base.NM_ProcGravar = "";
            // 
            // pnl_Fiscais
            // 
            this.pnl_Fiscais.AccessibleDescription = null;
            this.pnl_Fiscais.AccessibleName = null;
            resources.ApplyResources(this.pnl_Fiscais, "pnl_Fiscais");
            this.pnl_Fiscais.BackgroundImage = null;
            this.pnl_Fiscais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Fiscais.Controls.Add(this.TP_Fiscal);
            this.pnl_Fiscais.Controls.Add(this.DS_Movto);
            this.pnl_Fiscais.Controls.Add(this.label34);
            this.pnl_Fiscais.Controls.Add(this.Nr_Serie);
            this.pnl_Fiscais.Controls.Add(this.DS_CMI);
            this.pnl_Fiscais.Controls.Add(this.label45);
            this.pnl_Fiscais.Controls.Add(this.BB_CMI_NORMAL);
            this.pnl_Fiscais.Controls.Add(this.BB_Serie_NORMAL);
            this.pnl_Fiscais.Controls.Add(this.label47);
            this.pnl_Fiscais.Controls.Add(this.DS_Serie);
            this.pnl_Fiscais.Controls.Add(this.CD_CMI);
            this.pnl_Fiscais.Controls.Add(this.CD_Movto);
            this.pnl_Fiscais.Controls.Add(this.label46);
            this.pnl_Fiscais.Controls.Add(this.BB_Movto_NORMAL);
            this.pnl_Fiscais.Font = null;
            this.pnl_Fiscais.Name = "pnl_Fiscais";
            this.pnl_Fiscais.NM_ProcDeletar = "";
            this.pnl_Fiscais.NM_ProcGravar = "";
            // 
            // BB_CMI_NORMAL
            // 
            this.BB_CMI_NORMAL.AccessibleDescription = null;
            this.BB_CMI_NORMAL.AccessibleName = null;
            resources.ApplyResources(this.BB_CMI_NORMAL, "BB_CMI_NORMAL");
            this.BB_CMI_NORMAL.BackgroundImage = null;
            this.BB_CMI_NORMAL.Name = "BB_CMI_NORMAL";
            this.BB_CMI_NORMAL.UseVisualStyleBackColor = true;
            this.BB_CMI_NORMAL.Click += new System.EventHandler(this.BB_CMI_NORMAL_Click);
            // 
            // BB_Serie_NORMAL
            // 
            this.BB_Serie_NORMAL.AccessibleDescription = null;
            this.BB_Serie_NORMAL.AccessibleName = null;
            resources.ApplyResources(this.BB_Serie_NORMAL, "BB_Serie_NORMAL");
            this.BB_Serie_NORMAL.BackgroundImage = null;
            this.BB_Serie_NORMAL.Name = "BB_Serie_NORMAL";
            this.BB_Serie_NORMAL.UseVisualStyleBackColor = true;
            this.BB_Serie_NORMAL.Click += new System.EventHandler(this.BB_Serie_NORMAL_Click);
            // 
            // BB_Movto_NORMAL
            // 
            this.BB_Movto_NORMAL.AccessibleDescription = null;
            this.BB_Movto_NORMAL.AccessibleName = null;
            resources.ApplyResources(this.BB_Movto_NORMAL, "BB_Movto_NORMAL");
            this.BB_Movto_NORMAL.BackgroundImage = null;
            this.BB_Movto_NORMAL.Name = "BB_Movto_NORMAL";
            this.BB_Movto_NORMAL.UseVisualStyleBackColor = true;
            this.BB_Movto_NORMAL.Click += new System.EventHandler(this.BB_Movto_NORMAL_Click);
            // 
            // TFLan_Dados_Fiscais_Faturamento
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pnl_Fiscais_Base);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.Icon = null;
            this.KeyPreview = true;
            this.Name = "TFLan_Dados_Fiscais_Faturamento";
            this.Load += new System.EventHandler(this.Lan_Dados_Fiscais_Faturamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLan_Dados_Fiscais_Faturamento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.BS_Dados_Fiscais)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pnl_Fiscais_Base.ResumeLayout(false);
            this.pnl_Fiscais.ResumeLayout(false);
            this.pnl_Fiscais.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button BB_CMI_NORMAL;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button BB_Movto_NORMAL;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Button BB_Serie_NORMAL;
        private System.Windows.Forms.Label label45;
        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pnl_Fiscais_Base;
        private Componentes.PanelDados pnl_Fiscais;
        public System.Windows.Forms.BindingSource BS_Dados_Fiscais;
        public Componentes.ComboBoxDefault TP_Fiscal;
        public Componentes.EditDefault DS_CMI;
        public Componentes.EditDefault CD_CMI;
        public Componentes.EditDefault DS_Movto;
        public Componentes.EditDefault CD_Movto;
        public Componentes.EditDefault DS_Serie;
        public Componentes.EditDefault Nr_Serie;
    }
}