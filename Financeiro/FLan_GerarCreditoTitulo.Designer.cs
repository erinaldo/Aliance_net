namespace Financeiro
{
    partial class TFLan_GerarCreditoTitulo
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
            System.Windows.Forms.Label vl_tituloLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLan_GerarCreditoTitulo));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nr_cheque = new Componentes.EditDefault(this.components);
            this.ds_banco = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cd_banco = new Componentes.EditDefault(this.components);
            this.ds_contager = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cd_contager = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_empresa_credito = new System.Windows.Forms.Button();
            this.nm_empresa_credito = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cd_empresa_credito = new Componentes.EditDefault(this.components);
            this.bb_historico = new System.Windows.Forms.Button();
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cd_historico = new Componentes.EditDefault(this.components);
            this.Compl_Historico = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.vl_titulo = new Componentes.EditFloat(this.components);
            this.dt_lancto = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.bb_contagercredito = new System.Windows.Forms.Button();
            this.ds_contagercredito = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cd_contager_credito = new Componentes.EditDefault(this.components);
            this.bsCreditoTitulo = new System.Windows.Forms.BindingSource(this.components);
            vl_tituloLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_titulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreditoTitulo)).BeginInit();
            this.SuspendLayout();
            // 
            // vl_tituloLabel
            // 
            vl_tituloLabel.AccessibleDescription = null;
            vl_tituloLabel.AccessibleName = null;
            resources.ApplyResources(vl_tituloLabel, "vl_tituloLabel");
            vl_tituloLabel.Name = "vl_tituloLabel";
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Font = null;
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
            // tlpCentral
            // 
            this.tlpCentral.AccessibleDescription = null;
            this.tlpCentral.AccessibleName = null;
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.BackgroundImage = null;
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Font = null;
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pFiltro
            // 
            this.pFiltro.AccessibleDescription = null;
            this.pFiltro.AccessibleName = null;
            resources.ApplyResources(this.pFiltro, "pFiltro");
            this.pFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pFiltro.BackgroundImage = null;
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pFiltro.Controls.Add(this.label3);
            this.pFiltro.Controls.Add(this.nr_cheque);
            this.pFiltro.Controls.Add(this.ds_banco);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.cd_banco);
            this.pFiltro.Controls.Add(this.ds_contager);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.cd_contager);
            this.pFiltro.Controls.Add(this.nm_empresa);
            this.pFiltro.Controls.Add(this.label10);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Font = null;
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // nr_cheque
            // 
            this.nr_cheque.AccessibleDescription = null;
            this.nr_cheque.AccessibleName = null;
            resources.ApplyResources(this.nr_cheque, "nr_cheque");
            this.nr_cheque.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cheque.BackgroundImage = null;
            this.nr_cheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cheque.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Nr_cheque", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_cheque.Font = null;
            this.nr_cheque.Name = "nr_cheque";
            this.nr_cheque.NM_Alias = "";
            this.nr_cheque.NM_Campo = "cd_banco";
            this.nr_cheque.NM_CampoBusca = "cd_banco";
            this.nr_cheque.NM_Param = "@P_CD_BANCO";
            this.nr_cheque.QTD_Zero = 0;
            this.nr_cheque.ST_AutoInc = false;
            this.nr_cheque.ST_DisableAuto = true;
            this.nr_cheque.ST_Float = false;
            this.nr_cheque.ST_Gravar = true;
            this.nr_cheque.ST_Int = false;
            this.nr_cheque.ST_LimpaCampo = true;
            this.nr_cheque.ST_NotNull = true;
            this.nr_cheque.ST_PrimaryKey = false;
            // 
            // ds_banco
            // 
            this.ds_banco.AccessibleDescription = null;
            this.ds_banco.AccessibleName = null;
            resources.ApplyResources(this.ds_banco, "ds_banco");
            this.ds_banco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_banco.BackgroundImage = null;
            this.ds_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_banco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Ds_banco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_banco.Font = null;
            this.ds_banco.Name = "ds_banco";
            this.ds_banco.NM_Alias = "";
            this.ds_banco.NM_Campo = "ds_banco";
            this.ds_banco.NM_CampoBusca = "ds_banco";
            this.ds_banco.NM_Param = "@P_DS_BANCO";
            this.ds_banco.QTD_Zero = 0;
            this.ds_banco.ST_AutoInc = false;
            this.ds_banco.ST_DisableAuto = false;
            this.ds_banco.ST_Float = false;
            this.ds_banco.ST_Gravar = true;
            this.ds_banco.ST_Int = false;
            this.ds_banco.ST_LimpaCampo = true;
            this.ds_banco.ST_NotNull = true;
            this.ds_banco.ST_PrimaryKey = false;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cd_banco
            // 
            this.cd_banco.AccessibleDescription = null;
            this.cd_banco.AccessibleName = null;
            resources.ApplyResources(this.cd_banco, "cd_banco");
            this.cd_banco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_banco.BackgroundImage = null;
            this.cd_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_banco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Cd_banco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_banco.Font = null;
            this.cd_banco.Name = "cd_banco";
            this.cd_banco.NM_Alias = "";
            this.cd_banco.NM_Campo = "cd_banco";
            this.cd_banco.NM_CampoBusca = "cd_banco";
            this.cd_banco.NM_Param = "@P_CD_BANCO";
            this.cd_banco.QTD_Zero = 0;
            this.cd_banco.ST_AutoInc = false;
            this.cd_banco.ST_DisableAuto = true;
            this.cd_banco.ST_Float = false;
            this.cd_banco.ST_Gravar = true;
            this.cd_banco.ST_Int = false;
            this.cd_banco.ST_LimpaCampo = true;
            this.cd_banco.ST_NotNull = true;
            this.cd_banco.ST_PrimaryKey = false;
            // 
            // ds_contager
            // 
            this.ds_contager.AccessibleDescription = null;
            this.ds_contager.AccessibleName = null;
            resources.ApplyResources(this.ds_contager, "ds_contager");
            this.ds_contager.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contager.BackgroundImage = null;
            this.ds_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Ds_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contager.Font = null;
            this.ds_contager.Name = "ds_contager";
            this.ds_contager.NM_Alias = "";
            this.ds_contager.NM_Campo = "ds_banco";
            this.ds_contager.NM_CampoBusca = "ds_banco";
            this.ds_contager.NM_Param = "@P_DS_BANCO";
            this.ds_contager.QTD_Zero = 0;
            this.ds_contager.ST_AutoInc = false;
            this.ds_contager.ST_DisableAuto = false;
            this.ds_contager.ST_Float = false;
            this.ds_contager.ST_Gravar = true;
            this.ds_contager.ST_Int = false;
            this.ds_contager.ST_LimpaCampo = true;
            this.ds_contager.ST_NotNull = true;
            this.ds_contager.ST_PrimaryKey = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cd_contager
            // 
            this.cd_contager.AccessibleDescription = null;
            this.cd_contager.AccessibleName = null;
            resources.ApplyResources(this.cd_contager, "cd_contager");
            this.cd_contager.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contager.BackgroundImage = null;
            this.cd_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Cd_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contager.Font = null;
            this.cd_contager.Name = "cd_contager";
            this.cd_contager.NM_Alias = "";
            this.cd_contager.NM_Campo = "cd_banco";
            this.cd_contager.NM_CampoBusca = "cd_banco";
            this.cd_contager.NM_Param = "@P_CD_BANCO";
            this.cd_contager.QTD_Zero = 0;
            this.cd_contager.ST_AutoInc = false;
            this.cd_contager.ST_DisableAuto = true;
            this.cd_contager.ST_Float = false;
            this.cd_contager.ST_Gravar = true;
            this.cd_contager.ST_Int = false;
            this.cd_contager.ST_LimpaCampo = true;
            this.cd_contager.ST_NotNull = true;
            this.cd_contager.ST_PrimaryKey = false;
            // 
            // nm_empresa
            // 
            this.nm_empresa.AccessibleDescription = null;
            this.nm_empresa.AccessibleName = null;
            resources.ApplyResources(this.nm_empresa, "nm_empresa");
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BackgroundImage = null;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Font = null;
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "ds_banco";
            this.nm_empresa.NM_CampoBusca = "ds_banco";
            this.nm_empresa.NM_Param = "@P_DS_BANCO";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = true;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = true;
            this.nm_empresa.ST_PrimaryKey = false;
            // 
            // label10
            // 
            this.label10.AccessibleDescription = null;
            this.label10.AccessibleName = null;
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // cd_empresa
            // 
            this.cd_empresa.AccessibleDescription = null;
            this.cd_empresa.AccessibleName = null;
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BackgroundImage = null;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Font = null;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_banco";
            this.cd_empresa.NM_CampoBusca = "cd_banco";
            this.cd_empresa.NM_Param = "@P_CD_BANCO";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = true;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.bb_empresa_credito);
            this.pDados.Controls.Add(this.nm_empresa_credito);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.cd_empresa_credito);
            this.pDados.Controls.Add(this.bb_historico);
            this.pDados.Controls.Add(this.ds_historico);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.cd_historico);
            this.pDados.Controls.Add(this.Compl_Historico);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(vl_tituloLabel);
            this.pDados.Controls.Add(this.vl_titulo);
            this.pDados.Controls.Add(this.dt_lancto);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.bb_contagercredito);
            this.pDados.Controls.Add(this.ds_contagercredito);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.cd_contager_credito);
            this.pDados.Font = null;
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // bb_empresa_credito
            // 
            this.bb_empresa_credito.AccessibleDescription = null;
            this.bb_empresa_credito.AccessibleName = null;
            resources.ApplyResources(this.bb_empresa_credito, "bb_empresa_credito");
            this.bb_empresa_credito.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa_credito.BackgroundImage = null;
            this.bb_empresa_credito.Font = null;
            this.bb_empresa_credito.Name = "bb_empresa_credito";
            this.bb_empresa_credito.UseVisualStyleBackColor = false;
            this.bb_empresa_credito.Click += new System.EventHandler(this.bb_empresa_credito_Click);
            // 
            // nm_empresa_credito
            // 
            this.nm_empresa_credito.AccessibleDescription = null;
            this.nm_empresa_credito.AccessibleName = null;
            resources.ApplyResources(this.nm_empresa_credito, "nm_empresa_credito");
            this.nm_empresa_credito.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa_credito.BackgroundImage = null;
            this.nm_empresa_credito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa_credito.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Nm_empresacredito", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa_credito.Font = null;
            this.nm_empresa_credito.Name = "nm_empresa_credito";
            this.nm_empresa_credito.NM_Alias = "";
            this.nm_empresa_credito.NM_Campo = "nm_empresa";
            this.nm_empresa_credito.NM_CampoBusca = "nm_empresa";
            this.nm_empresa_credito.NM_Param = "@P_DS_BANCO";
            this.nm_empresa_credito.QTD_Zero = 0;
            this.nm_empresa_credito.ST_AutoInc = false;
            this.nm_empresa_credito.ST_DisableAuto = false;
            this.nm_empresa_credito.ST_Float = false;
            this.nm_empresa_credito.ST_Gravar = true;
            this.nm_empresa_credito.ST_Int = false;
            this.nm_empresa_credito.ST_LimpaCampo = true;
            this.nm_empresa_credito.ST_NotNull = true;
            this.nm_empresa_credito.ST_PrimaryKey = false;
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // cd_empresa_credito
            // 
            this.cd_empresa_credito.AccessibleDescription = null;
            this.cd_empresa_credito.AccessibleName = null;
            resources.ApplyResources(this.cd_empresa_credito, "cd_empresa_credito");
            this.cd_empresa_credito.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa_credito.BackgroundImage = null;
            this.cd_empresa_credito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa_credito.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Cd_empresacredito", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa_credito.Font = null;
            this.cd_empresa_credito.Name = "cd_empresa_credito";
            this.cd_empresa_credito.NM_Alias = "";
            this.cd_empresa_credito.NM_Campo = "cd_empresa";
            this.cd_empresa_credito.NM_CampoBusca = "cd_empresa";
            this.cd_empresa_credito.NM_Param = "@P_CD_BANCO";
            this.cd_empresa_credito.QTD_Zero = 0;
            this.cd_empresa_credito.ST_AutoInc = false;
            this.cd_empresa_credito.ST_DisableAuto = true;
            this.cd_empresa_credito.ST_Float = false;
            this.cd_empresa_credito.ST_Gravar = true;
            this.cd_empresa_credito.ST_Int = false;
            this.cd_empresa_credito.ST_LimpaCampo = true;
            this.cd_empresa_credito.ST_NotNull = true;
            this.cd_empresa_credito.ST_PrimaryKey = false;
            this.cd_empresa_credito.Leave += new System.EventHandler(this.cd_empresa_credito_Leave);
            // 
            // bb_historico
            // 
            this.bb_historico.AccessibleDescription = null;
            this.bb_historico.AccessibleName = null;
            resources.ApplyResources(this.bb_historico, "bb_historico");
            this.bb_historico.BackColor = System.Drawing.SystemColors.Control;
            this.bb_historico.BackgroundImage = null;
            this.bb_historico.Font = null;
            this.bb_historico.Name = "bb_historico";
            this.bb_historico.UseVisualStyleBackColor = false;
            this.bb_historico.Click += new System.EventHandler(this.bb_historico_Click);
            // 
            // ds_historico
            // 
            this.ds_historico.AccessibleDescription = null;
            this.ds_historico.AccessibleName = null;
            resources.ApplyResources(this.ds_historico, "ds_historico");
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BackgroundImage = null;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_historico.Font = null;
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "ds_historico";
            this.ds_historico.NM_CampoBusca = "ds_historico";
            this.ds_historico.NM_Param = "@P_DS_BANCO";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = true;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = true;
            this.ds_historico.ST_PrimaryKey = false;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cd_historico
            // 
            this.cd_historico.AccessibleDescription = null;
            this.cd_historico.AccessibleName = null;
            resources.ApplyResources(this.cd_historico, "cd_historico");
            this.cd_historico.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico.BackgroundImage = null;
            this.cd_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Cd_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_historico.Font = null;
            this.cd_historico.Name = "cd_historico";
            this.cd_historico.NM_Alias = "";
            this.cd_historico.NM_Campo = "cd_historico";
            this.cd_historico.NM_CampoBusca = "cd_historico";
            this.cd_historico.NM_Param = "@P_CD_BANCO";
            this.cd_historico.QTD_Zero = 0;
            this.cd_historico.ST_AutoInc = false;
            this.cd_historico.ST_DisableAuto = true;
            this.cd_historico.ST_Float = false;
            this.cd_historico.ST_Gravar = true;
            this.cd_historico.ST_Int = false;
            this.cd_historico.ST_LimpaCampo = true;
            this.cd_historico.ST_NotNull = true;
            this.cd_historico.ST_PrimaryKey = false;
            this.cd_historico.Leave += new System.EventHandler(this.cd_historico_Leave);
            // 
            // Compl_Historico
            // 
            this.Compl_Historico.AccessibleDescription = null;
            this.Compl_Historico.AccessibleName = null;
            resources.ApplyResources(this.Compl_Historico, "Compl_Historico");
            this.Compl_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.Compl_Historico.BackgroundImage = null;
            this.Compl_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Compl_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "CompHistorico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Compl_Historico.Font = null;
            this.Compl_Historico.Name = "Compl_Historico";
            this.Compl_Historico.NM_Alias = "";
            this.Compl_Historico.NM_Campo = "";
            this.Compl_Historico.NM_CampoBusca = "";
            this.Compl_Historico.NM_Param = "";
            this.Compl_Historico.QTD_Zero = 0;
            this.Compl_Historico.ST_AutoInc = false;
            this.Compl_Historico.ST_DisableAuto = false;
            this.Compl_Historico.ST_Float = false;
            this.Compl_Historico.ST_Gravar = true;
            this.Compl_Historico.ST_Int = false;
            this.Compl_Historico.ST_LimpaCampo = true;
            this.Compl_Historico.ST_NotNull = false;
            this.Compl_Historico.ST_PrimaryKey = false;
            // 
            // label7
            // 
            this.label7.AccessibleDescription = null;
            this.label7.AccessibleName = null;
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // vl_titulo
            // 
            this.vl_titulo.AccessibleDescription = null;
            this.vl_titulo.AccessibleName = null;
            resources.ApplyResources(this.vl_titulo, "vl_titulo");
            this.vl_titulo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCreditoTitulo, "Vl_titulo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_titulo.DecimalPlaces = 2;
            this.vl_titulo.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.vl_titulo.Name = "vl_titulo";
            this.vl_titulo.NM_Alias = "";
            this.vl_titulo.NM_Campo = "";
            this.vl_titulo.NM_Param = "";
            this.vl_titulo.Operador = "";
            this.vl_titulo.ReadOnly = true;
            this.vl_titulo.ST_AutoInc = false;
            this.vl_titulo.ST_DisableAuto = false;
            this.vl_titulo.ST_Gravar = true;
            this.vl_titulo.ST_LimparCampo = true;
            this.vl_titulo.ST_NotNull = true;
            this.vl_titulo.ST_PrimaryKey = false;
            this.vl_titulo.TabStop = false;
            // 
            // dt_lancto
            // 
            this.dt_lancto.AccessibleDescription = null;
            this.dt_lancto.AccessibleName = null;
            resources.ApplyResources(this.dt_lancto, "dt_lancto");
            this.dt_lancto.BackgroundImage = null;
            this.dt_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Dt_lanctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_lancto.Font = null;
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
            // label8
            // 
            this.label8.AccessibleDescription = null;
            this.label8.AccessibleName = null;
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // bb_contagercredito
            // 
            this.bb_contagercredito.AccessibleDescription = null;
            this.bb_contagercredito.AccessibleName = null;
            resources.ApplyResources(this.bb_contagercredito, "bb_contagercredito");
            this.bb_contagercredito.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contagercredito.BackgroundImage = null;
            this.bb_contagercredito.Font = null;
            this.bb_contagercredito.Name = "bb_contagercredito";
            this.bb_contagercredito.UseVisualStyleBackColor = false;
            this.bb_contagercredito.Click += new System.EventHandler(this.bb_contagercredito_Click);
            // 
            // ds_contagercredito
            // 
            this.ds_contagercredito.AccessibleDescription = null;
            this.ds_contagercredito.AccessibleName = null;
            resources.ApplyResources(this.ds_contagercredito, "ds_contagercredito");
            this.ds_contagercredito.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contagercredito.BackgroundImage = null;
            this.ds_contagercredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contagercredito.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Ds_contagercredito", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contagercredito.Font = null;
            this.ds_contagercredito.Name = "ds_contagercredito";
            this.ds_contagercredito.NM_Alias = "";
            this.ds_contagercredito.NM_Campo = "ds_contager";
            this.ds_contagercredito.NM_CampoBusca = "ds_contager";
            this.ds_contagercredito.NM_Param = "@P_DS_BANCO";
            this.ds_contagercredito.QTD_Zero = 0;
            this.ds_contagercredito.ST_AutoInc = false;
            this.ds_contagercredito.ST_DisableAuto = false;
            this.ds_contagercredito.ST_Float = false;
            this.ds_contagercredito.ST_Gravar = true;
            this.ds_contagercredito.ST_Int = false;
            this.ds_contagercredito.ST_LimpaCampo = true;
            this.ds_contagercredito.ST_NotNull = true;
            this.ds_contagercredito.ST_PrimaryKey = false;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cd_contager_credito
            // 
            this.cd_contager_credito.AccessibleDescription = null;
            this.cd_contager_credito.AccessibleName = null;
            resources.ApplyResources(this.cd_contager_credito, "cd_contager_credito");
            this.cd_contager_credito.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contager_credito.BackgroundImage = null;
            this.cd_contager_credito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contager_credito.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCreditoTitulo, "Cd_contagercredito", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contager_credito.Font = null;
            this.cd_contager_credito.Name = "cd_contager_credito";
            this.cd_contager_credito.NM_Alias = "";
            this.cd_contager_credito.NM_Campo = "cd_contager";
            this.cd_contager_credito.NM_CampoBusca = "cd_contager";
            this.cd_contager_credito.NM_Param = "@P_CD_BANCO";
            this.cd_contager_credito.QTD_Zero = 0;
            this.cd_contager_credito.ST_AutoInc = false;
            this.cd_contager_credito.ST_DisableAuto = true;
            this.cd_contager_credito.ST_Float = false;
            this.cd_contager_credito.ST_Gravar = true;
            this.cd_contager_credito.ST_Int = false;
            this.cd_contager_credito.ST_LimpaCampo = true;
            this.cd_contager_credito.ST_NotNull = true;
            this.cd_contager_credito.ST_PrimaryKey = false;
            this.cd_contager_credito.Leave += new System.EventHandler(this.cd_contager_credito_Leave);
            // 
            // bsCreditoTitulo
            // 
            this.bsCreditoTitulo.DataSource = typeof(CamadaDados.Financeiro.Titulo.TList_CreditoTitulo);
            // 
            // TFLan_GerarCreditoTitulo
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLan_GerarCreditoTitulo";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLan_GerarCreditoTitulo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLan_GerarCreditoTitulo_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_titulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreditoTitulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsCreditoTitulo;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault ds_banco;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_banco;
        private Componentes.EditDefault ds_contager;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_contager;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nr_cheque;
        private System.Windows.Forms.Button bb_contagercredito;
        private Componentes.EditDefault ds_contagercredito;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault cd_contager_credito;
        private Componentes.EditFloat vl_titulo;
        private Componentes.EditData dt_lancto;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault Compl_Historico;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bb_historico;
        private Componentes.EditDefault ds_historico;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault cd_historico;
        private Componentes.EditDefault nm_empresa_credito;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault cd_empresa_credito;
        private System.Windows.Forms.Button bb_empresa_credito;
    }
}