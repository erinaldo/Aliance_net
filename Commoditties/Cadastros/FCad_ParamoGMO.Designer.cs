namespace Commoditties.Cadastros
{
    partial class TFCad_ParamoGMO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_ParamoGMO));
            this.cd_Empresa = new Componentes.EditDefault(this.components);
            this.Bs_ParamGMO = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_Contager = new Componentes.EditDefault(this.components);
            this.cd_Portador = new Componentes.EditDefault(this.components);
            this.histPgto = new Componentes.EditDefault(this.components);
            this.histRetencao = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.bb_Contager = new System.Windows.Forms.Button();
            this.bb_Portador = new System.Windows.Forms.Button();
            this.bb_HistPgto = new System.Windows.Forms.Button();
            this.bb_HistRetencao = new System.Windows.Forms.Button();
            this.nm_Empresa = new Componentes.EditDefault(this.components);
            this.ds_ContaGer = new Componentes.EditDefault(this.components);
            this.ds_Portador = new Componentes.EditDefault(this.components);
            this.ds_HistPgto = new Componentes.EditDefault(this.components);
            this.ds_HistRetencao = new Componentes.EditDefault(this.components);
            this.gParametros = new Componentes.DataGridDefault(this.components);
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdhistoricopgtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdhistoricoretencaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bs_ParamGMO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gParametros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ds_HistRetencao);
            this.pDados.Controls.Add(this.ds_HistPgto);
            this.pDados.Controls.Add(this.ds_Portador);
            this.pDados.Controls.Add(this.ds_ContaGer);
            this.pDados.Controls.Add(this.nm_Empresa);
            this.pDados.Controls.Add(this.bb_HistRetencao);
            this.pDados.Controls.Add(this.bb_HistPgto);
            this.pDados.Controls.Add(this.bb_Portador);
            this.pDados.Controls.Add(this.bb_Contager);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.histRetencao);
            this.pDados.Controls.Add(this.histPgto);
            this.pDados.Controls.Add(this.cd_Portador);
            this.pDados.Controls.Add(this.cd_Contager);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_Empresa);
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gParametros);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gParametros, 0);
            // 
            // cd_Empresa
            // 
            this.cd_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_ParamGMO, "cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_Empresa, "cd_Empresa");
            this.cd_Empresa.Name = "cd_Empresa";
            this.cd_Empresa.NM_Alias = "pGmo";
            this.cd_Empresa.NM_Campo = "cd_empresa";
            this.cd_Empresa.NM_CampoBusca = "cd_empresa";
            this.cd_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_Empresa.QTD_Zero = 0;
            this.cd_Empresa.ST_AutoInc = false;
            this.cd_Empresa.ST_DisableAuto = false;
            this.cd_Empresa.ST_Float = false;
            this.cd_Empresa.ST_Gravar = true;
            this.cd_Empresa.ST_Int = true;
            this.cd_Empresa.ST_LimpaCampo = false;
            this.cd_Empresa.ST_NotNull = true;
            this.cd_Empresa.ST_PrimaryKey = true;
            this.cd_Empresa.Leave += new System.EventHandler(this.cd_Empresa_Leave);
            // 
            // Bs_ParamGMO
            // 
            this.Bs_ParamGMO.DataSource = typeof(CamadaDados.Graos.TList_Cad_ParamGMO);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cd_Contager
            // 
            this.cd_Contager.BackColor = System.Drawing.SystemColors.Window;
            this.cd_Contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_Contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_ParamGMO, "cd_Contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_Contager, "cd_Contager");
            this.cd_Contager.Name = "cd_Contager";
            this.cd_Contager.NM_Alias = "pGmo";
            this.cd_Contager.NM_Campo = "cd_Contager";
            this.cd_Contager.NM_CampoBusca = "cd_Contager";
            this.cd_Contager.NM_Param = "@P_CD_CONTAGER";
            this.cd_Contager.QTD_Zero = 0;
            this.cd_Contager.ST_AutoInc = false;
            this.cd_Contager.ST_DisableAuto = false;
            this.cd_Contager.ST_Float = false;
            this.cd_Contager.ST_Gravar = true;
            this.cd_Contager.ST_Int = true;
            this.cd_Contager.ST_LimpaCampo = true;
            this.cd_Contager.ST_NotNull = false;
            this.cd_Contager.ST_PrimaryKey = false;
            this.cd_Contager.Leave += new System.EventHandler(this.cd_Contager_Leave);
            // 
            // cd_Portador
            // 
            this.cd_Portador.BackColor = System.Drawing.SystemColors.Window;
            this.cd_Portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_Portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_ParamGMO, "cd_Portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_Portador, "cd_Portador");
            this.cd_Portador.Name = "cd_Portador";
            this.cd_Portador.NM_Alias = "pGmo";
            this.cd_Portador.NM_Campo = "cd_portador";
            this.cd_Portador.NM_CampoBusca = "cd_portador";
            this.cd_Portador.NM_Param = "@P_CD_PORTADOR";
            this.cd_Portador.QTD_Zero = 0;
            this.cd_Portador.ST_AutoInc = false;
            this.cd_Portador.ST_DisableAuto = false;
            this.cd_Portador.ST_Float = false;
            this.cd_Portador.ST_Gravar = true;
            this.cd_Portador.ST_Int = true;
            this.cd_Portador.ST_LimpaCampo = true;
            this.cd_Portador.ST_NotNull = false;
            this.cd_Portador.ST_PrimaryKey = false;
            this.cd_Portador.Leave += new System.EventHandler(this.cd_Portador_Leave);
            // 
            // histPgto
            // 
            this.histPgto.BackColor = System.Drawing.SystemColors.Window;
            this.histPgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.histPgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_ParamGMO, "cd_Historico_Pgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.histPgto, "histPgto");
            this.histPgto.Name = "histPgto";
            this.histPgto.NM_Alias = "pgmo";
            this.histPgto.NM_Campo = "cd_historico_pgto";
            this.histPgto.NM_CampoBusca = "cd_historico";
            this.histPgto.NM_Param = "@P_CD_HISTORICO";
            this.histPgto.QTD_Zero = 0;
            this.histPgto.ST_AutoInc = false;
            this.histPgto.ST_DisableAuto = false;
            this.histPgto.ST_Float = false;
            this.histPgto.ST_Gravar = true;
            this.histPgto.ST_Int = true;
            this.histPgto.ST_LimpaCampo = true;
            this.histPgto.ST_NotNull = false;
            this.histPgto.ST_PrimaryKey = false;
            this.histPgto.Leave += new System.EventHandler(this.histPgto_Leave);
            // 
            // histRetencao
            // 
            this.histRetencao.BackColor = System.Drawing.SystemColors.Window;
            this.histRetencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.histRetencao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_ParamGMO, "cd_Historico_Retencao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.histRetencao, "histRetencao");
            this.histRetencao.Name = "histRetencao";
            this.histRetencao.NM_Alias = "pgmo";
            this.histRetencao.NM_Campo = "cd_historico_retencao";
            this.histRetencao.NM_CampoBusca = "cd_historico";
            this.histRetencao.NM_Param = "@P_CD_HISTORICO_RETENCAO";
            this.histRetencao.QTD_Zero = 0;
            this.histRetencao.ST_AutoInc = false;
            this.histRetencao.ST_DisableAuto = false;
            this.histRetencao.ST_Float = false;
            this.histRetencao.ST_Gravar = true;
            this.histRetencao.ST_Int = true;
            this.histRetencao.ST_LimpaCampo = true;
            this.histRetencao.ST_NotNull = false;
            this.histRetencao.ST_PrimaryKey = false;
            this.histRetencao.Leave += new System.EventHandler(this.histRetencao_Leave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // bb_empresa
            // 
            resources.ApplyResources(this.bb_empresa, "bb_empresa");
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // bb_Contager
            // 
            resources.ApplyResources(this.bb_Contager, "bb_Contager");
            this.bb_Contager.Name = "bb_Contager";
            this.bb_Contager.UseVisualStyleBackColor = true;
            this.bb_Contager.Click += new System.EventHandler(this.bb_Contager_Click);
            // 
            // bb_Portador
            // 
            resources.ApplyResources(this.bb_Portador, "bb_Portador");
            this.bb_Portador.Name = "bb_Portador";
            this.bb_Portador.UseVisualStyleBackColor = true;
            this.bb_Portador.Click += new System.EventHandler(this.bb_Portador_Click);
            // 
            // bb_HistPgto
            // 
            resources.ApplyResources(this.bb_HistPgto, "bb_HistPgto");
            this.bb_HistPgto.Name = "bb_HistPgto";
            this.bb_HistPgto.UseVisualStyleBackColor = true;
            this.bb_HistPgto.Click += new System.EventHandler(this.bb_HistPgto_Click);
            // 
            // bb_HistRetencao
            // 
            resources.ApplyResources(this.bb_HistRetencao, "bb_HistRetencao");
            this.bb_HistRetencao.Name = "bb_HistRetencao";
            this.bb_HistRetencao.UseVisualStyleBackColor = true;
            this.bb_HistRetencao.Click += new System.EventHandler(this.bb_HistRetencao_Click);
            // 
            // nm_Empresa
            // 
            this.nm_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_ParamGMO, "nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nm_Empresa, "nm_Empresa");
            this.nm_Empresa.Name = "nm_Empresa";
            this.nm_Empresa.NM_Alias = "a";
            this.nm_Empresa.NM_Campo = "nm_empresa";
            this.nm_Empresa.NM_CampoBusca = "nm_empresa";
            this.nm_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_Empresa.QTD_Zero = 0;
            this.nm_Empresa.ST_AutoInc = false;
            this.nm_Empresa.ST_DisableAuto = false;
            this.nm_Empresa.ST_Float = false;
            this.nm_Empresa.ST_Gravar = false;
            this.nm_Empresa.ST_Int = false;
            this.nm_Empresa.ST_LimpaCampo = true;
            this.nm_Empresa.ST_NotNull = false;
            this.nm_Empresa.ST_PrimaryKey = false;
            // 
            // ds_ContaGer
            // 
            this.ds_ContaGer.BackColor = System.Drawing.SystemColors.Window;
            this.ds_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_ContaGer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_ParamGMO, "ds_contaGer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_ContaGer, "ds_ContaGer");
            this.ds_ContaGer.Name = "ds_ContaGer";
            this.ds_ContaGer.NM_Alias = "c";
            this.ds_ContaGer.NM_Campo = "ds_Contager";
            this.ds_ContaGer.NM_CampoBusca = "ds_Contager";
            this.ds_ContaGer.NM_Param = "@P_DS_CONTAGER";
            this.ds_ContaGer.QTD_Zero = 0;
            this.ds_ContaGer.ST_AutoInc = false;
            this.ds_ContaGer.ST_DisableAuto = false;
            this.ds_ContaGer.ST_Float = false;
            this.ds_ContaGer.ST_Gravar = false;
            this.ds_ContaGer.ST_Int = false;
            this.ds_ContaGer.ST_LimpaCampo = true;
            this.ds_ContaGer.ST_NotNull = false;
            this.ds_ContaGer.ST_PrimaryKey = false;
            // 
            // ds_Portador
            // 
            this.ds_Portador.BackColor = System.Drawing.SystemColors.Window;
            this.ds_Portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_Portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_ParamGMO, "ds_Portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_Portador, "ds_Portador");
            this.ds_Portador.Name = "ds_Portador";
            this.ds_Portador.NM_Alias = "a";
            this.ds_Portador.NM_Campo = "ds_portador";
            this.ds_Portador.NM_CampoBusca = "ds_portador";
            this.ds_Portador.NM_Param = "@P_DS_PORTADOR";
            this.ds_Portador.QTD_Zero = 0;
            this.ds_Portador.ST_AutoInc = false;
            this.ds_Portador.ST_DisableAuto = false;
            this.ds_Portador.ST_Float = false;
            this.ds_Portador.ST_Gravar = false;
            this.ds_Portador.ST_Int = false;
            this.ds_Portador.ST_LimpaCampo = true;
            this.ds_Portador.ST_NotNull = false;
            this.ds_Portador.ST_PrimaryKey = false;
            // 
            // ds_HistPgto
            // 
            this.ds_HistPgto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_HistPgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_HistPgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_ParamGMO, "ds_Historico_Pgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_HistPgto, "ds_HistPgto");
            this.ds_HistPgto.Name = "ds_HistPgto";
            this.ds_HistPgto.NM_Alias = "a";
            this.ds_HistPgto.NM_Campo = "ds_historico";
            this.ds_HistPgto.NM_CampoBusca = "ds_historico";
            this.ds_HistPgto.NM_Param = "@P_DS_HISTORICO";
            this.ds_HistPgto.QTD_Zero = 0;
            this.ds_HistPgto.ST_AutoInc = false;
            this.ds_HistPgto.ST_DisableAuto = false;
            this.ds_HistPgto.ST_Float = false;
            this.ds_HistPgto.ST_Gravar = false;
            this.ds_HistPgto.ST_Int = false;
            this.ds_HistPgto.ST_LimpaCampo = true;
            this.ds_HistPgto.ST_NotNull = false;
            this.ds_HistPgto.ST_PrimaryKey = false;
            // 
            // ds_HistRetencao
            // 
            this.ds_HistRetencao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_HistRetencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_HistRetencao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bs_ParamGMO, "ds_Historico_Retencao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_HistRetencao, "ds_HistRetencao");
            this.ds_HistRetencao.Name = "ds_HistRetencao";
            this.ds_HistRetencao.NM_Alias = "a";
            this.ds_HistRetencao.NM_Campo = "ds_historico";
            this.ds_HistRetencao.NM_CampoBusca = "ds_historico";
            this.ds_HistRetencao.NM_Param = "@P_DS_HISTORICO";
            this.ds_HistRetencao.QTD_Zero = 0;
            this.ds_HistRetencao.ST_AutoInc = false;
            this.ds_HistRetencao.ST_DisableAuto = false;
            this.ds_HistRetencao.ST_Float = false;
            this.ds_HistRetencao.ST_Gravar = false;
            this.ds_HistRetencao.ST_Int = false;
            this.ds_HistRetencao.ST_LimpaCampo = true;
            this.ds_HistRetencao.ST_NotNull = false;
            this.ds_HistRetencao.ST_PrimaryKey = false;
            // 
            // gParametros
            // 
            this.gParametros.AllowUserToAddRows = false;
            this.gParametros.AllowUserToDeleteRows = false;
            this.gParametros.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gParametros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gParametros.AutoGenerateColumns = false;
            this.gParametros.BackgroundColor = System.Drawing.Color.LightGray;
            this.gParametros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gParametros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gParametros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gParametros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.cdhistoricopgtoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.cdhistoricoretencaoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.gParametros.DataSource = this.Bs_ParamGMO;
            resources.ApplyResources(this.gParametros, "gParametros");
            this.gParametros.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gParametros.Name = "gParametros";
            this.gParametros.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gParametros.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            resources.ApplyResources(this.cdempresaDataGridViewTextBoxColumn, "cdempresaDataGridViewTextBoxColumn");
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            resources.ApplyResources(this.nmempresaDataGridViewTextBoxColumn, "nmempresaDataGridViewTextBoxColumn");
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdhistoricopgtoDataGridViewTextBoxColumn
            // 
            this.cdhistoricopgtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdhistoricopgtoDataGridViewTextBoxColumn.DataPropertyName = "Cd_historico_pgto";
            resources.ApplyResources(this.cdhistoricopgtoDataGridViewTextBoxColumn, "cdhistoricopgtoDataGridViewTextBoxColumn");
            this.cdhistoricopgtoDataGridViewTextBoxColumn.Name = "cdhistoricopgtoDataGridViewTextBoxColumn";
            this.cdhistoricopgtoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ds_historico_pgto";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cdhistoricoretencaoDataGridViewTextBoxColumn
            // 
            this.cdhistoricoretencaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdhistoricoretencaoDataGridViewTextBoxColumn.DataPropertyName = "Cd_historico_retencao";
            resources.ApplyResources(this.cdhistoricoretencaoDataGridViewTextBoxColumn, "cdhistoricoretencaoDataGridViewTextBoxColumn");
            this.cdhistoricoretencaoDataGridViewTextBoxColumn.Name = "cdhistoricoretencaoDataGridViewTextBoxColumn";
            this.cdhistoricoretencaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_historico_retencao";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Cd_contager";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Ds_contager";
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Cd_portador";
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Ds_portador";
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.Bs_ParamGMO;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // TFCad_ParamoGMO
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCad_ParamoGMO";
            this.Load += new System.EventHandler(this.TFCad_ParamoGMO_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_ParamoGMO_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bs_ParamGMO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gParametros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault cd_Empresa;
        private Componentes.EditDefault cd_Portador;
        private Componentes.EditDefault cd_Contager;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault histRetencao;
        private Componentes.EditDefault histPgto;
        private System.Windows.Forms.Button bb_HistRetencao;
        private System.Windows.Forms.Button bb_HistPgto;
        private System.Windows.Forms.Button bb_Portador;
        private System.Windows.Forms.Button bb_Contager;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault ds_HistRetencao;
        private Componentes.EditDefault ds_HistPgto;
        private Componentes.EditDefault ds_Portador;
        private Componentes.EditDefault ds_ContaGer;
        private Componentes.EditDefault nm_Empresa;
        private Componentes.DataGridDefault gParametros;
        private System.Windows.Forms.BindingSource Bs_ParamGMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsHistoricoPgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsHistoricoRetencaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdContagerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscontaGerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdPortadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsPortadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdhistoricopgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdhistoricoretencaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}
