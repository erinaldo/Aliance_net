namespace Parametros.Diversos
{
    partial class TFIntegraService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFIntegraService));
            Parametros.Diversos.configIntegracao configIntegracao1 = new Parametros.Diversos.configIntegracao();
            Parametros.Diversos.configIntegracao configIntegracao2 = new Parametros.Diversos.configIntegracao();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpGeral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_path = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.path_arquivo = new Componentes.EditDefault(this.components);
            this.ds_tabelapreco = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cd_tabelapreco = new Componentes.EditDefault(this.components);
            this.bb_tabelapreco = new System.Windows.Forms.Button();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.barraMenu.SuspendLayout();
            this.tlpGeral.SuspendLayout();
            this.pDados.SuspendLayout();
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
            this.BB_Novo,
            this.BB_Gravar,
            this.BB_Fechar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Novo
            // 
            this.BB_Novo.AccessibleDescription = null;
            this.BB_Novo.AccessibleName = null;
            resources.ApplyResources(this.BB_Novo, "BB_Novo");
            this.BB_Novo.BackgroundImage = null;
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
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
            // BB_Fechar
            // 
            this.BB_Fechar.AccessibleDescription = null;
            this.BB_Fechar.AccessibleName = null;
            resources.ApplyResources(this.BB_Fechar, "BB_Fechar");
            this.BB_Fechar.BackgroundImage = null;
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tlpGeral
            // 
            this.tlpGeral.AccessibleDescription = null;
            this.tlpGeral.AccessibleName = null;
            resources.ApplyResources(this.tlpGeral, "tlpGeral");
            this.tlpGeral.BackgroundImage = null;
            this.tlpGeral.Controls.Add(this.pDados, 0, 0);
            this.tlpGeral.Font = null;
            this.tlpGeral.Name = "tlpGeral";
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.bb_path);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.path_arquivo);
            this.pDados.Controls.Add(this.ds_tabelapreco);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_tabelapreco);
            this.pDados.Controls.Add(this.bb_tabelapreco);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Font = null;
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // bb_path
            // 
            this.bb_path.AccessibleDescription = null;
            this.bb_path.AccessibleName = null;
            resources.ApplyResources(this.bb_path, "bb_path");
            this.bb_path.BackColor = System.Drawing.SystemColors.Control;
            this.bb_path.BackgroundImage = null;
            this.bb_path.Font = null;
            this.bb_path.Name = "bb_path";
            this.bb_path.UseVisualStyleBackColor = false;
            this.bb_path.Click += new System.EventHandler(this.bb_path_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // path_arquivo
            // 
            this.path_arquivo.AccessibleDescription = null;
            this.path_arquivo.AccessibleName = null;
            resources.ApplyResources(this.path_arquivo, "path_arquivo");
            this.path_arquivo.BackColor = System.Drawing.SystemColors.Window;
            this.path_arquivo.BackgroundImage = null;
            this.path_arquivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            configIntegracao1.cd_empresa = "";
            configIntegracao1.cd_tabelapreco = "";
            configIntegracao1.ds_tabelapreco = "";
            configIntegracao1.nm_empresa = "";
            configIntegracao1.path_arquivo = "";
            configIntegracao1.SettingsKey = "";
            this.path_arquivo.DataBindings.Add(new System.Windows.Forms.Binding("Text", configIntegracao1, "path_arquivo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.path_arquivo.Font = null;
            this.path_arquivo.Name = "path_arquivo";
            this.path_arquivo.NM_Alias = "";
            this.path_arquivo.NM_Campo = "CD_Empresa";
            this.path_arquivo.NM_CampoBusca = "CD_Empresa";
            this.path_arquivo.NM_Param = "@P_CD_EMPRESA";
            this.path_arquivo.QTD_Zero = 0;
            this.path_arquivo.ST_AutoInc = false;
            this.path_arquivo.ST_DisableAuto = false;
            this.path_arquivo.ST_Float = false;
            this.path_arquivo.ST_Gravar = true;
            this.path_arquivo.ST_Int = false;
            this.path_arquivo.ST_LimpaCampo = true;
            this.path_arquivo.ST_NotNull = false;
            this.path_arquivo.ST_PrimaryKey = false;
            configIntegracao2.cd_empresa = "";
            configIntegracao2.cd_tabelapreco = "";
            configIntegracao2.ds_tabelapreco = "";
            configIntegracao2.nm_empresa = "";
            configIntegracao2.path_arquivo = "";
            configIntegracao2.SettingsKey = "";
            this.path_arquivo.Text = configIntegracao2.path_arquivo;
            // 
            // ds_tabelapreco
            // 
            this.ds_tabelapreco.AccessibleDescription = null;
            this.ds_tabelapreco.AccessibleName = null;
            resources.ApplyResources(this.ds_tabelapreco, "ds_tabelapreco");
            this.ds_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelapreco.BackgroundImage = null;
            this.ds_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", configIntegracao2, "ds_tabelapreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tabelapreco.Font = null;
            this.ds_tabelapreco.Name = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Alias = "";
            this.ds_tabelapreco.NM_Campo = "ds_tabelapreco";
            this.ds_tabelapreco.NM_CampoBusca = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Param = "@P_CD_EMPRESA";
            this.ds_tabelapreco.QTD_Zero = 0;
            this.ds_tabelapreco.ST_AutoInc = false;
            this.ds_tabelapreco.ST_DisableAuto = false;
            this.ds_tabelapreco.ST_Float = false;
            this.ds_tabelapreco.ST_Gravar = true;
            this.ds_tabelapreco.ST_Int = false;
            this.ds_tabelapreco.ST_LimpaCampo = true;
            this.ds_tabelapreco.ST_NotNull = false;
            this.ds_tabelapreco.ST_PrimaryKey = false;
            this.ds_tabelapreco.Text = configIntegracao2.ds_tabelapreco;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cd_tabelapreco
            // 
            this.cd_tabelapreco.AccessibleDescription = null;
            this.cd_tabelapreco.AccessibleName = null;
            resources.ApplyResources(this.cd_tabelapreco, "cd_tabelapreco");
            this.cd_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_tabelapreco.BackgroundImage = null;
            this.cd_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", configIntegracao2, "cd_tabelapreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_tabelapreco.Font = null;
            this.cd_tabelapreco.Name = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Alias = "";
            this.cd_tabelapreco.NM_Campo = "cd_tabelapreco";
            this.cd_tabelapreco.NM_CampoBusca = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Param = "@P_CD_EMPRESA";
            this.cd_tabelapreco.QTD_Zero = 0;
            this.cd_tabelapreco.ST_AutoInc = false;
            this.cd_tabelapreco.ST_DisableAuto = false;
            this.cd_tabelapreco.ST_Float = false;
            this.cd_tabelapreco.ST_Gravar = true;
            this.cd_tabelapreco.ST_Int = false;
            this.cd_tabelapreco.ST_LimpaCampo = true;
            this.cd_tabelapreco.ST_NotNull = false;
            this.cd_tabelapreco.ST_PrimaryKey = false;
            this.cd_tabelapreco.Text = configIntegracao2.cd_tabelapreco;
            this.cd_tabelapreco.Leave += new System.EventHandler(this.cd_tabelapreco_Leave);
            // 
            // bb_tabelapreco
            // 
            this.bb_tabelapreco.AccessibleDescription = null;
            this.bb_tabelapreco.AccessibleName = null;
            resources.ApplyResources(this.bb_tabelapreco, "bb_tabelapreco");
            this.bb_tabelapreco.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tabelapreco.BackgroundImage = null;
            this.bb_tabelapreco.Font = null;
            this.bb_tabelapreco.Name = "bb_tabelapreco";
            this.bb_tabelapreco.UseVisualStyleBackColor = false;
            this.bb_tabelapreco.Click += new System.EventHandler(this.bb_tabelapreco_Click);
            // 
            // nm_empresa
            // 
            this.nm_empresa.AccessibleDescription = null;
            this.nm_empresa.AccessibleName = null;
            resources.ApplyResources(this.nm_empresa, "nm_empresa");
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BackgroundImage = null;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", configIntegracao2, "nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Font = null;
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_CD_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.Text = configIntegracao2.nm_empresa;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.AccessibleDescription = null;
            this.CD_Empresa.AccessibleName = null;
            resources.ApplyResources(this.CD_Empresa, "CD_Empresa");
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BackgroundImage = null;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", configIntegracao2, "cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.CD_Empresa.ST_NotNull = false;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.Text = configIntegracao2.cd_empresa;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.AccessibleDescription = null;
            this.BB_Empresa.AccessibleName = null;
            resources.ApplyResources(this.BB_Empresa, "BB_Empresa");
            this.BB_Empresa.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Empresa.BackgroundImage = null;
            this.BB_Empresa.Font = null;
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.UseVisualStyleBackColor = false;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // TFIntegraService
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tlpGeral);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.Icon = null;
            this.KeyPreview = true;
            this.Name = "TFIntegraService";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFIntegraService_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFIntegraService_FormClosing);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpGeral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tlpGeral;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_tabelapreco;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_tabelapreco;
        private System.Windows.Forms.Button bb_tabelapreco;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.Button bb_path;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault path_arquivo;
    }
}