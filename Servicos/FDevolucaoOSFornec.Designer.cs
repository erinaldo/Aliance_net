namespace Servicos
{
    partial class TFDevolucaoOSFornec
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
            System.Windows.Forms.Label cd_EmpresaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDevolucaoOSFornec));
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDadosNfRetorno = new Componentes.PanelDados(this.components);
            this.vl_frete = new Componentes.EditFloat(this.components);
            this.DS_TPOrdem = new Componentes.EditDefault(this.components);
            this.BB_TPOrdem = new System.Windows.Forms.Button();
            this.TP_Ordem = new Componentes.EditDefault(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.nm_fornecedor = new Componentes.EditDefault(this.components);
            this.bb_fornecedor = new System.Windows.Forms.Button();
            this.cd_fornecedor = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.lblConciliacao = new System.Windows.Forms.Label();
            this.pOsDevolver = new Componentes.PanelDados(this.components);
            this.gOs = new Componentes.DataGridDefault(this.components);
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsOs = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.TS_ItensPedido = new System.Windows.Forms.ToolStrip();
            this.btn_Inserir_Item = new System.Windows.Forms.ToolStripButton();
            this.btn_Deleta_Item = new System.Windows.Forms.ToolStripButton();
            cd_EmpresaLabel = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDadosNfRetorno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_frete)).BeginInit();
            this.pOsDevolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.TS_ItensPedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // cd_EmpresaLabel
            // 
            cd_EmpresaLabel.AccessibleDescription = null;
            cd_EmpresaLabel.AccessibleName = null;
            resources.ApplyResources(cd_EmpresaLabel, "cd_EmpresaLabel");
            cd_EmpresaLabel.Name = "cd_EmpresaLabel";
            // 
            // label10
            // 
            label10.AccessibleDescription = null;
            label10.AccessibleName = null;
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // label1
            // 
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
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
            this.tlpCentral.Controls.Add(this.pDadosNfRetorno, 0, 0);
            this.tlpCentral.Controls.Add(this.pOsDevolver, 0, 1);
            this.tlpCentral.Font = null;
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pDadosNfRetorno
            // 
            this.pDadosNfRetorno.AccessibleDescription = null;
            this.pDadosNfRetorno.AccessibleName = null;
            resources.ApplyResources(this.pDadosNfRetorno, "pDadosNfRetorno");
            this.pDadosNfRetorno.BackgroundImage = null;
            this.pDadosNfRetorno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDadosNfRetorno.Controls.Add(label1);
            this.pDadosNfRetorno.Controls.Add(this.vl_frete);
            this.pDadosNfRetorno.Controls.Add(this.DS_TPOrdem);
            this.pDadosNfRetorno.Controls.Add(this.BB_TPOrdem);
            this.pDadosNfRetorno.Controls.Add(this.TP_Ordem);
            this.pDadosNfRetorno.Controls.Add(this.label17);
            this.pDadosNfRetorno.Controls.Add(this.nm_fornecedor);
            this.pDadosNfRetorno.Controls.Add(this.bb_fornecedor);
            this.pDadosNfRetorno.Controls.Add(cd_EmpresaLabel);
            this.pDadosNfRetorno.Controls.Add(this.cd_fornecedor);
            this.pDadosNfRetorno.Controls.Add(this.nm_empresa);
            this.pDadosNfRetorno.Controls.Add(this.bb_empresa);
            this.pDadosNfRetorno.Controls.Add(label10);
            this.pDadosNfRetorno.Controls.Add(this.cd_empresa);
            this.pDadosNfRetorno.Controls.Add(this.lblConciliacao);
            this.pDadosNfRetorno.Font = null;
            this.pDadosNfRetorno.Name = "pDadosNfRetorno";
            this.pDadosNfRetorno.NM_ProcDeletar = "";
            this.pDadosNfRetorno.NM_ProcGravar = "";
            // 
            // vl_frete
            // 
            this.vl_frete.AccessibleDescription = null;
            this.vl_frete.AccessibleName = null;
            resources.ApplyResources(this.vl_frete, "vl_frete");
            this.vl_frete.DecimalPlaces = 2;
            this.vl_frete.Font = null;
            this.vl_frete.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_frete.Name = "vl_frete";
            this.vl_frete.NM_Alias = "";
            this.vl_frete.NM_Campo = "";
            this.vl_frete.NM_Param = "";
            this.vl_frete.Operador = "";
            this.vl_frete.ST_AutoInc = false;
            this.vl_frete.ST_DisableAuto = false;
            this.vl_frete.ST_Gravar = true;
            this.vl_frete.ST_LimparCampo = true;
            this.vl_frete.ST_NotNull = false;
            this.vl_frete.ST_PrimaryKey = false;
            // 
            // DS_TPOrdem
            // 
            this.DS_TPOrdem.AccessibleDescription = null;
            this.DS_TPOrdem.AccessibleName = null;
            resources.ApplyResources(this.DS_TPOrdem, "DS_TPOrdem");
            this.DS_TPOrdem.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TPOrdem.BackgroundImage = null;
            this.DS_TPOrdem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TPOrdem.Name = "DS_TPOrdem";
            this.DS_TPOrdem.NM_Alias = "";
            this.DS_TPOrdem.NM_Campo = "DS_tipoOrdem";
            this.DS_TPOrdem.NM_CampoBusca = "DS_tipoOrdem";
            this.DS_TPOrdem.NM_Param = "@P_CD_TABELAPRECO";
            this.DS_TPOrdem.QTD_Zero = 0;
            this.DS_TPOrdem.ReadOnly = true;
            this.DS_TPOrdem.ST_AutoInc = false;
            this.DS_TPOrdem.ST_DisableAuto = false;
            this.DS_TPOrdem.ST_Float = false;
            this.DS_TPOrdem.ST_Gravar = false;
            this.DS_TPOrdem.ST_Int = false;
            this.DS_TPOrdem.ST_LimpaCampo = true;
            this.DS_TPOrdem.ST_NotNull = false;
            this.DS_TPOrdem.ST_PrimaryKey = false;
            // 
            // BB_TPOrdem
            // 
            this.BB_TPOrdem.AccessibleDescription = null;
            this.BB_TPOrdem.AccessibleName = null;
            resources.ApplyResources(this.BB_TPOrdem, "BB_TPOrdem");
            this.BB_TPOrdem.BackgroundImage = null;
            this.BB_TPOrdem.Font = null;
            this.BB_TPOrdem.Name = "BB_TPOrdem";
            this.BB_TPOrdem.UseVisualStyleBackColor = true;
            this.BB_TPOrdem.Click += new System.EventHandler(this.BB_TPOrdem_Click);
            // 
            // TP_Ordem
            // 
            this.TP_Ordem.AccessibleDescription = null;
            this.TP_Ordem.AccessibleName = null;
            resources.ApplyResources(this.TP_Ordem, "TP_Ordem");
            this.TP_Ordem.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Ordem.BackgroundImage = null;
            this.TP_Ordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Ordem.Name = "TP_Ordem";
            this.TP_Ordem.NM_Alias = "";
            this.TP_Ordem.NM_Campo = "tp_Ordem";
            this.TP_Ordem.NM_CampoBusca = "tp_Ordem";
            this.TP_Ordem.NM_Param = "@P_CD_TABELAPRECO";
            this.TP_Ordem.QTD_Zero = 0;
            this.TP_Ordem.ST_AutoInc = false;
            this.TP_Ordem.ST_DisableAuto = false;
            this.TP_Ordem.ST_Float = false;
            this.TP_Ordem.ST_Gravar = true;
            this.TP_Ordem.ST_Int = false;
            this.TP_Ordem.ST_LimpaCampo = true;
            this.TP_Ordem.ST_NotNull = true;
            this.TP_Ordem.ST_PrimaryKey = false;
            this.TP_Ordem.Leave += new System.EventHandler(this.TP_Ordem_Leave);
            // 
            // label17
            // 
            this.label17.AccessibleDescription = null;
            this.label17.AccessibleName = null;
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // nm_fornecedor
            // 
            this.nm_fornecedor.AccessibleDescription = null;
            this.nm_fornecedor.AccessibleName = null;
            resources.ApplyResources(this.nm_fornecedor, "nm_fornecedor");
            this.nm_fornecedor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_fornecedor.BackgroundImage = null;
            this.nm_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_fornecedor.Font = null;
            this.nm_fornecedor.Name = "nm_fornecedor";
            this.nm_fornecedor.NM_Alias = "";
            this.nm_fornecedor.NM_Campo = "nm_fornecedor";
            this.nm_fornecedor.NM_CampoBusca = "nm_clifor";
            this.nm_fornecedor.NM_Param = "@P_NM_EMPRESA";
            this.nm_fornecedor.QTD_Zero = 0;
            this.nm_fornecedor.ST_AutoInc = false;
            this.nm_fornecedor.ST_DisableAuto = false;
            this.nm_fornecedor.ST_Float = false;
            this.nm_fornecedor.ST_Gravar = false;
            this.nm_fornecedor.ST_Int = false;
            this.nm_fornecedor.ST_LimpaCampo = true;
            this.nm_fornecedor.ST_NotNull = false;
            this.nm_fornecedor.ST_PrimaryKey = false;
            // 
            // bb_fornecedor
            // 
            this.bb_fornecedor.AccessibleDescription = null;
            this.bb_fornecedor.AccessibleName = null;
            resources.ApplyResources(this.bb_fornecedor, "bb_fornecedor");
            this.bb_fornecedor.BackColor = System.Drawing.SystemColors.Control;
            this.bb_fornecedor.BackgroundImage = null;
            this.bb_fornecedor.Font = null;
            this.bb_fornecedor.Name = "bb_fornecedor";
            this.bb_fornecedor.UseVisualStyleBackColor = false;
            this.bb_fornecedor.Click += new System.EventHandler(this.bb_fornecedor_Click);
            // 
            // cd_fornecedor
            // 
            this.cd_fornecedor.AccessibleDescription = null;
            this.cd_fornecedor.AccessibleName = null;
            resources.ApplyResources(this.cd_fornecedor, "cd_fornecedor");
            this.cd_fornecedor.BackColor = System.Drawing.Color.White;
            this.cd_fornecedor.BackgroundImage = null;
            this.cd_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_fornecedor.Font = null;
            this.cd_fornecedor.Name = "cd_fornecedor";
            this.cd_fornecedor.NM_Alias = "";
            this.cd_fornecedor.NM_Campo = "cd_fornecedor";
            this.cd_fornecedor.NM_CampoBusca = "cd_clifor";
            this.cd_fornecedor.NM_Param = "@P_CD_EMPRESA";
            this.cd_fornecedor.QTD_Zero = 0;
            this.cd_fornecedor.ST_AutoInc = false;
            this.cd_fornecedor.ST_DisableAuto = false;
            this.cd_fornecedor.ST_Float = false;
            this.cd_fornecedor.ST_Gravar = true;
            this.cd_fornecedor.ST_Int = true;
            this.cd_fornecedor.ST_LimpaCampo = true;
            this.cd_fornecedor.ST_NotNull = true;
            this.cd_fornecedor.ST_PrimaryKey = false;
            this.cd_fornecedor.Leave += new System.EventHandler(this.cd_fornecedor_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.AccessibleDescription = null;
            this.nm_empresa.AccessibleName = null;
            resources.ApplyResources(this.nm_empresa, "nm_empresa");
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BackgroundImage = null;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Font = null;
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            // 
            // bb_empresa
            // 
            this.bb_empresa.AccessibleDescription = null;
            this.bb_empresa.AccessibleName = null;
            resources.ApplyResources(this.bb_empresa, "bb_empresa");
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.BackgroundImage = null;
            this.bb_empresa.Font = null;
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.AccessibleDescription = null;
            this.cd_empresa.AccessibleName = null;
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BackgroundImage = null;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = null;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // lblConciliacao
            // 
            this.lblConciliacao.AccessibleDescription = null;
            this.lblConciliacao.AccessibleName = null;
            resources.ApplyResources(this.lblConciliacao, "lblConciliacao");
            this.lblConciliacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.lblConciliacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConciliacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblConciliacao.ForeColor = System.Drawing.Color.White;
            this.lblConciliacao.Name = "lblConciliacao";
            // 
            // pOsDevolver
            // 
            this.pOsDevolver.AccessibleDescription = null;
            this.pOsDevolver.AccessibleName = null;
            resources.ApplyResources(this.pOsDevolver, "pOsDevolver");
            this.pOsDevolver.BackgroundImage = null;
            this.pOsDevolver.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pOsDevolver.Controls.Add(this.gOs);
            this.pOsDevolver.Controls.Add(this.bindingNavigator1);
            this.pOsDevolver.Controls.Add(this.TS_ItensPedido);
            this.pOsDevolver.Font = null;
            this.pOsDevolver.Name = "pOsDevolver";
            this.pOsDevolver.NM_ProcDeletar = "";
            this.pOsDevolver.NM_ProcGravar = "";
            // 
            // gOs
            // 
            this.gOs.AccessibleDescription = null;
            this.gOs.AccessibleName = null;
            this.gOs.AllowUserToAddRows = false;
            this.gOs.AllowUserToDeleteRows = false;
            this.gOs.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gOs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gOs, "gOs");
            this.gOs.AutoGenerateColumns = false;
            this.gOs.BackgroundColor = System.Drawing.Color.LightGray;
            this.gOs.BackgroundImage = null;
            this.gOs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gOs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gOs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gOs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gOs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewCheckBoxColumn3,
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32});
            this.gOs.DataSource = this.bsOs;
            this.gOs.Font = null;
            this.gOs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gOs.Name = "gOs";
            this.gOs.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gOs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Id_os";
            resources.ApplyResources(this.dataGridViewTextBoxColumn18, "dataGridViewTextBoxColumn18");
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Nr_serial";
            resources.ApplyResources(this.dataGridViewTextBoxColumn19, "dataGridViewTextBoxColumn19");
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "CD_ProdutoOS";
            resources.ApplyResources(this.dataGridViewTextBoxColumn20, "dataGridViewTextBoxColumn20");
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn21.DataPropertyName = "DS_ProdutoOS";
            resources.ApplyResources(this.dataGridViewTextBoxColumn21, "dataGridViewTextBoxColumn21");
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "ST_EquipamentoGarantia_Bool";
            resources.ApplyResources(this.dataGridViewCheckBoxColumn3, "dataGridViewCheckBoxColumn3");
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn31.DataPropertyName = "Nr_osorigem";
            resources.ApplyResources(this.dataGridViewTextBoxColumn31, "dataGridViewTextBoxColumn31");
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn32.DataPropertyName = "Ds_defeitocliente";
            resources.ApplyResources(this.dataGridViewTextBoxColumn32, "dataGridViewTextBoxColumn32");
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            // 
            // bsOs
            // 
            this.bsOs.DataSource = typeof(CamadaDados.Servicos.TList_LanServico);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AccessibleDescription = null;
            this.bindingNavigator1.AccessibleName = null;
            this.bindingNavigator1.AddNewItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.BackgroundImage = null;
            this.bindingNavigator1.BindingSource = this.bsOs;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Font = null;
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
            this.bindingNavigatorCountItem.AccessibleDescription = null;
            this.bindingNavigatorCountItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.BackgroundImage = null;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.AccessibleDescription = null;
            this.bindingNavigatorSeparator.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.AccessibleDescription = null;
            this.bindingNavigatorSeparator1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // TS_ItensPedido
            // 
            this.TS_ItensPedido.AccessibleDescription = null;
            this.TS_ItensPedido.AccessibleName = null;
            resources.ApplyResources(this.TS_ItensPedido, "TS_ItensPedido");
            this.TS_ItensPedido.BackgroundImage = null;
            this.TS_ItensPedido.Font = null;
            this.TS_ItensPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Inserir_Item,
            this.btn_Deleta_Item});
            this.TS_ItensPedido.Name = "TS_ItensPedido";
            // 
            // btn_Inserir_Item
            // 
            this.btn_Inserir_Item.AccessibleDescription = null;
            this.btn_Inserir_Item.AccessibleName = null;
            resources.ApplyResources(this.btn_Inserir_Item, "btn_Inserir_Item");
            this.btn_Inserir_Item.BackgroundImage = null;
            this.btn_Inserir_Item.Name = "btn_Inserir_Item";
            this.btn_Inserir_Item.Click += new System.EventHandler(this.btn_Inserir_Item_Click);
            // 
            // btn_Deleta_Item
            // 
            this.btn_Deleta_Item.AccessibleDescription = null;
            this.btn_Deleta_Item.AccessibleName = null;
            resources.ApplyResources(this.btn_Deleta_Item, "btn_Deleta_Item");
            this.btn_Deleta_Item.BackgroundImage = null;
            this.btn_Deleta_Item.Name = "btn_Deleta_Item";
            this.btn_Deleta_Item.Click += new System.EventHandler(this.btn_Deleta_Item_Click);
            // 
            // TFDevolucaoOSFornec
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
            this.Name = "TFDevolucaoOSFornec";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFDevolucaoOSFornec_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFDevolucaoOSFornec_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDevolucaoOSFornec_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDadosNfRetorno.ResumeLayout(false);
            this.pDadosNfRetorno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_frete)).EndInit();
            this.pOsDevolver.ResumeLayout(false);
            this.pOsDevolver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.TS_ItensPedido.ResumeLayout(false);
            this.TS_ItensPedido.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDadosNfRetorno;
        private Componentes.PanelDados pOsDevolver;
        private System.Windows.Forms.ToolStrip TS_ItensPedido;
        private System.Windows.Forms.ToolStripButton btn_Inserir_Item;
        private System.Windows.Forms.ToolStripButton btn_Deleta_Item;
        private System.Windows.Forms.BindingSource bsOs;
        private Componentes.DataGridDefault gOs;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label lblConciliacao;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_fornecedor;
        private System.Windows.Forms.Button bb_fornecedor;
        private Componentes.EditDefault cd_fornecedor;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.EditDefault DS_TPOrdem;
        private System.Windows.Forms.Button BB_TPOrdem;
        private Componentes.EditDefault TP_Ordem;
        private System.Windows.Forms.Label label17;
        private Componentes.EditFloat vl_frete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
    }
}