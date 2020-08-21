namespace Compra
{
    partial class TFGerarOrdemCompra
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFGerarOrdemCompra));
            System.Windows.Forms.Label cd_produtoLabel;
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label cd_clifor_requisitanteLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.bb_clifor_requisitante = new System.Windows.Forms.Button();
            this.cd_clifor_requisitante = new Componentes.EditDefault(this.components);
            this.bsRequisicao = new System.Windows.Forms.BindingSource(this.components);
            this.rG_FiltroData = new Componentes.RadioGroup(this.components);
            this.panelDados6 = new Componentes.PanelDados(this.components);
            this.DT_Final = new Componentes.EditData(this.components);
            this.DT_Inic = new Componentes.EditData(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.id_requisicao = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.tlpDetalhes = new System.Windows.Forms.TableLayoutPanel();
            this.pRequisicoes = new Componentes.PanelDados(this.components);
            this.gRequisicao = new Componentes.DataGridDefault(this.components);
            this.St_integrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idrequisicaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaunidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdaprovadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtrequisicaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcliforrequisitanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforrequisitanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcliforaprovadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforaprovadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcliforcompradorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforcompradorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            label1 = new System.Windows.Forms.Label();
            cd_produtoLabel = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            cd_clifor_requisitanteLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicao)).BeginInit();
            this.rG_FiltroData.SuspendLayout();
            this.panelDados6.SuspendLayout();
            this.tlpDetalhes.SuspendLayout();
            this.pRequisicoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gRequisicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // cd_produtoLabel
            // 
            resources.ApplyResources(cd_produtoLabel, "cd_produtoLabel");
            cd_produtoLabel.Name = "cd_produtoLabel";
            // 
            // cd_empresaLabel
            // 
            resources.ApplyResources(cd_empresaLabel, "cd_empresaLabel");
            cd_empresaLabel.Name = "cd_empresaLabel";
            // 
            // cd_clifor_requisitanteLabel
            // 
            resources.ApplyResources(cd_clifor_requisitanteLabel, "cd_clifor_requisitanteLabel");
            cd_clifor_requisitanteLabel.Name = "cd_clifor_requisitanteLabel";
            // 
            // barraMenu
            // 
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Buscar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Buscar
            // 
            resources.ApplyResources(this.BB_Buscar, "BB_Buscar");
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // BB_Fechar
            // 
            resources.ApplyResources(this.BB_Fechar, "BB_Fechar");
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tlpCentral
            // 
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.tlpDetalhes, 0, 1);
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pFiltro
            // 
            resources.ApplyResources(this.pFiltro, "pFiltro");
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.bb_clifor_requisitante);
            this.pFiltro.Controls.Add(cd_clifor_requisitanteLabel);
            this.pFiltro.Controls.Add(this.cd_clifor_requisitante);
            this.pFiltro.Controls.Add(this.rG_FiltroData);
            this.pFiltro.Controls.Add(label1);
            this.pFiltro.Controls.Add(this.id_requisicao);
            this.pFiltro.Controls.Add(this.bb_produto);
            this.pFiltro.Controls.Add(cd_produtoLabel);
            this.pFiltro.Controls.Add(this.cd_produto);
            this.pFiltro.Controls.Add(this.bb_empresa);
            this.pFiltro.Controls.Add(cd_empresaLabel);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            // 
            // bb_clifor_requisitante
            // 
            resources.ApplyResources(this.bb_clifor_requisitante, "bb_clifor_requisitante");
            this.bb_clifor_requisitante.BackColor = System.Drawing.SystemColors.Control;
            this.bb_clifor_requisitante.Name = "bb_clifor_requisitante";
            this.bb_clifor_requisitante.UseVisualStyleBackColor = false;
            this.bb_clifor_requisitante.Click += new System.EventHandler(this.bb_clifor_requisitante_Click);
            // 
            // cd_clifor_requisitante
            // 
            resources.ApplyResources(this.cd_clifor_requisitante, "cd_clifor_requisitante");
            this.cd_clifor_requisitante.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor_requisitante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor_requisitante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor_requisitante.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Cd_clifor_requisitante", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor_requisitante.Name = "cd_clifor_requisitante";
            this.cd_clifor_requisitante.NM_Alias = "";
            this.cd_clifor_requisitante.NM_Campo = "cd_clifor";
            this.cd_clifor_requisitante.NM_CampoBusca = "cd_clifor";
            this.cd_clifor_requisitante.NM_Param = "@P_CD_CLIFOR";
            this.cd_clifor_requisitante.QTD_Zero = 0;
            this.cd_clifor_requisitante.ST_AutoInc = false;
            this.cd_clifor_requisitante.ST_DisableAuto = false;
            this.cd_clifor_requisitante.ST_Float = false;
            this.cd_clifor_requisitante.ST_Gravar = true;
            this.cd_clifor_requisitante.ST_Int = false;
            this.cd_clifor_requisitante.ST_LimpaCampo = true;
            this.cd_clifor_requisitante.ST_NotNull = true;
            this.cd_clifor_requisitante.ST_PrimaryKey = false;
            this.cd_clifor_requisitante.TextOld = null;
            this.cd_clifor_requisitante.Leave += new System.EventHandler(this.cd_clifor_requisitante_Leave);
            // 
            // bsRequisicao
            // 
            this.bsRequisicao.DataSource = typeof(CamadaDados.Compra.Lancamento.TList_Requisicao);
            this.bsRequisicao.PositionChanged += new System.EventHandler(this.bsRequisicao_PositionChanged);
            // 
            // rG_FiltroData
            // 
            resources.ApplyResources(this.rG_FiltroData, "rG_FiltroData");
            this.rG_FiltroData.Controls.Add(this.panelDados6);
            this.rG_FiltroData.Name = "rG_FiltroData";
            this.rG_FiltroData.NM_Alias = "";
            this.rG_FiltroData.NM_Campo = "";
            this.rG_FiltroData.NM_Param = "";
            this.rG_FiltroData.NM_Valor = "";
            this.rG_FiltroData.ST_Gravar = false;
            this.rG_FiltroData.ST_NotNull = false;
            this.rG_FiltroData.TabStop = false;
            // 
            // panelDados6
            // 
            resources.ApplyResources(this.panelDados6, "panelDados6");
            this.panelDados6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.panelDados6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados6.Controls.Add(this.DT_Final);
            this.panelDados6.Controls.Add(this.DT_Inic);
            this.panelDados6.Controls.Add(this.label13);
            this.panelDados6.Controls.Add(this.label15);
            this.panelDados6.Name = "panelDados6";
            this.panelDados6.NM_ProcDeletar = "";
            this.panelDados6.NM_ProcGravar = "";
            // 
            // DT_Final
            // 
            resources.ApplyResources(this.DT_Final, "DT_Final");
            this.DT_Final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.NM_Alias = "";
            this.DT_Final.NM_Campo = "DT_NascFirma";
            this.DT_Final.NM_CampoBusca = "DT_NascFirma";
            this.DT_Final.NM_Param = "@P_DT_NASCIMENTO";
            this.DT_Final.Operador = "";
            this.DT_Final.ST_Gravar = true;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = false;
            this.DT_Final.ST_PrimaryKey = false;
            // 
            // DT_Inic
            // 
            resources.ApplyResources(this.DT_Inic, "DT_Inic");
            this.DT_Inic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Inic.Name = "DT_Inic";
            this.DT_Inic.NM_Alias = "";
            this.DT_Inic.NM_Campo = "DT_NascFirma";
            this.DT_Inic.NM_CampoBusca = "DT_NascFirma";
            this.DT_Inic.NM_Param = "@P_DT_NASCIMENTO";
            this.DT_Inic.Operador = "";
            this.DT_Inic.ST_Gravar = true;
            this.DT_Inic.ST_LimpaCampo = true;
            this.DT_Inic.ST_NotNull = false;
            this.DT_Inic.ST_PrimaryKey = false;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // id_requisicao
            // 
            resources.ApplyResources(this.id_requisicao, "id_requisicao");
            this.id_requisicao.BackColor = System.Drawing.SystemColors.Window;
            this.id_requisicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_requisicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_requisicao.Name = "id_requisicao";
            this.id_requisicao.NM_Alias = "";
            this.id_requisicao.NM_Campo = "cd_empresa";
            this.id_requisicao.NM_CampoBusca = "cd_empresa";
            this.id_requisicao.NM_Param = "@P_CD_EMPRESA";
            this.id_requisicao.QTD_Zero = 0;
            this.id_requisicao.ST_AutoInc = false;
            this.id_requisicao.ST_DisableAuto = false;
            this.id_requisicao.ST_Float = false;
            this.id_requisicao.ST_Gravar = true;
            this.id_requisicao.ST_Int = true;
            this.id_requisicao.ST_LimpaCampo = true;
            this.id_requisicao.ST_NotNull = false;
            this.id_requisicao.ST_PrimaryKey = false;
            this.id_requisicao.TextOld = null;
            // 
            // bb_produto
            // 
            resources.ApplyResources(this.bb_produto, "bb_produto");
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // cd_produto
            // 
            resources.ApplyResources(this.cd_produto, "cd_produto");
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
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
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // bb_empresa
            // 
            resources.ApplyResources(this.bb_empresa, "bb_empresa");
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
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
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // tlpDetalhes
            // 
            resources.ApplyResources(this.tlpDetalhes, "tlpDetalhes");
            this.tlpDetalhes.Controls.Add(this.pRequisicoes, 0, 0);
            this.tlpDetalhes.Name = "tlpDetalhes";
            // 
            // pRequisicoes
            // 
            resources.ApplyResources(this.pRequisicoes, "pRequisicoes");
            this.pRequisicoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pRequisicoes.Controls.Add(this.gRequisicao);
            this.pRequisicoes.Controls.Add(this.bindingNavigator1);
            this.pRequisicoes.Name = "pRequisicoes";
            this.pRequisicoes.NM_ProcDeletar = "";
            this.pRequisicoes.NM_ProcGravar = "";
            // 
            // gRequisicao
            // 
            resources.ApplyResources(this.gRequisicao, "gRequisicao");
            this.gRequisicao.AllowUserToAddRows = false;
            this.gRequisicao.AllowUserToDeleteRows = false;
            this.gRequisicao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gRequisicao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gRequisicao.AutoGenerateColumns = false;
            this.gRequisicao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gRequisicao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gRequisicao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRequisicao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gRequisicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gRequisicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_integrar,
            this.statusDataGridViewTextBoxColumn,
            this.idrequisicaoDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.siglaunidadeDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.qtdaprovadaDataGridViewTextBoxColumn,
            this.dtrequisicaostrDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.cdcliforrequisitanteDataGridViewTextBoxColumn,
            this.nmcliforrequisitanteDataGridViewTextBoxColumn,
            this.cdcliforaprovadorDataGridViewTextBoxColumn,
            this.nmcliforaprovadorDataGridViewTextBoxColumn,
            this.cdcliforcompradorDataGridViewTextBoxColumn,
            this.nmcliforcompradorDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn});
            this.gRequisicao.DataSource = this.bsRequisicao;
            this.gRequisicao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gRequisicao.Name = "gRequisicao";
            this.gRequisicao.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRequisicao.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gRequisicao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gRequisicao_CellClick);
            // 
            // St_integrar
            // 
            this.St_integrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_integrar.DataPropertyName = "St_integrar";
            resources.ApplyResources(this.St_integrar, "St_integrar");
            this.St_integrar.Name = "St_integrar";
            this.St_integrar.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            resources.ApplyResources(this.statusDataGridViewTextBoxColumn, "statusDataGridViewTextBoxColumn");
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idrequisicaoDataGridViewTextBoxColumn
            // 
            this.idrequisicaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idrequisicaoDataGridViewTextBoxColumn.DataPropertyName = "Id_requisicao";
            resources.ApplyResources(this.idrequisicaoDataGridViewTextBoxColumn, "idrequisicaoDataGridViewTextBoxColumn");
            this.idrequisicaoDataGridViewTextBoxColumn.Name = "idrequisicaoDataGridViewTextBoxColumn";
            this.idrequisicaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            resources.ApplyResources(this.cdprodutoDataGridViewTextBoxColumn, "cdprodutoDataGridViewTextBoxColumn");
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            resources.ApplyResources(this.dsprodutoDataGridViewTextBoxColumn, "dsprodutoDataGridViewTextBoxColumn");
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siglaunidadeDataGridViewTextBoxColumn
            // 
            this.siglaunidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaunidadeDataGridViewTextBoxColumn.DataPropertyName = "Sigla_unidade";
            resources.ApplyResources(this.siglaunidadeDataGridViewTextBoxColumn, "siglaunidadeDataGridViewTextBoxColumn");
            this.siglaunidadeDataGridViewTextBoxColumn.Name = "siglaunidadeDataGridViewTextBoxColumn";
            this.siglaunidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.quantidadeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.quantidadeDataGridViewTextBoxColumn, "quantidadeDataGridViewTextBoxColumn");
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdaprovadaDataGridViewTextBoxColumn
            // 
            this.qtdaprovadaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdaprovadaDataGridViewTextBoxColumn.DataPropertyName = "Qtd_aprovada";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.qtdaprovadaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.qtdaprovadaDataGridViewTextBoxColumn, "qtdaprovadaDataGridViewTextBoxColumn");
            this.qtdaprovadaDataGridViewTextBoxColumn.Name = "qtdaprovadaDataGridViewTextBoxColumn";
            this.qtdaprovadaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtrequisicaostrDataGridViewTextBoxColumn
            // 
            this.dtrequisicaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtrequisicaostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_requisicaostr";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.dtrequisicaostrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.dtrequisicaostrDataGridViewTextBoxColumn, "dtrequisicaostrDataGridViewTextBoxColumn");
            this.dtrequisicaostrDataGridViewTextBoxColumn.Name = "dtrequisicaostrDataGridViewTextBoxColumn";
            this.dtrequisicaostrDataGridViewTextBoxColumn.ReadOnly = true;
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
            // cdcliforrequisitanteDataGridViewTextBoxColumn
            // 
            this.cdcliforrequisitanteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcliforrequisitanteDataGridViewTextBoxColumn.DataPropertyName = "Cd_clifor_requisitante";
            resources.ApplyResources(this.cdcliforrequisitanteDataGridViewTextBoxColumn, "cdcliforrequisitanteDataGridViewTextBoxColumn");
            this.cdcliforrequisitanteDataGridViewTextBoxColumn.Name = "cdcliforrequisitanteDataGridViewTextBoxColumn";
            this.cdcliforrequisitanteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmcliforrequisitanteDataGridViewTextBoxColumn
            // 
            this.nmcliforrequisitanteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforrequisitanteDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor_requisitante";
            resources.ApplyResources(this.nmcliforrequisitanteDataGridViewTextBoxColumn, "nmcliforrequisitanteDataGridViewTextBoxColumn");
            this.nmcliforrequisitanteDataGridViewTextBoxColumn.Name = "nmcliforrequisitanteDataGridViewTextBoxColumn";
            this.nmcliforrequisitanteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdcliforaprovadorDataGridViewTextBoxColumn
            // 
            this.cdcliforaprovadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcliforaprovadorDataGridViewTextBoxColumn.DataPropertyName = "Cd_clifor_aprovador";
            resources.ApplyResources(this.cdcliforaprovadorDataGridViewTextBoxColumn, "cdcliforaprovadorDataGridViewTextBoxColumn");
            this.cdcliforaprovadorDataGridViewTextBoxColumn.Name = "cdcliforaprovadorDataGridViewTextBoxColumn";
            this.cdcliforaprovadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmcliforaprovadorDataGridViewTextBoxColumn
            // 
            this.nmcliforaprovadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforaprovadorDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor_aprovador";
            resources.ApplyResources(this.nmcliforaprovadorDataGridViewTextBoxColumn, "nmcliforaprovadorDataGridViewTextBoxColumn");
            this.nmcliforaprovadorDataGridViewTextBoxColumn.Name = "nmcliforaprovadorDataGridViewTextBoxColumn";
            this.nmcliforaprovadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdcliforcompradorDataGridViewTextBoxColumn
            // 
            this.cdcliforcompradorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcliforcompradorDataGridViewTextBoxColumn.DataPropertyName = "Cd_clifor_comprador";
            resources.ApplyResources(this.cdcliforcompradorDataGridViewTextBoxColumn, "cdcliforcompradorDataGridViewTextBoxColumn");
            this.cdcliforcompradorDataGridViewTextBoxColumn.Name = "cdcliforcompradorDataGridViewTextBoxColumn";
            this.cdcliforcompradorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmcliforcompradorDataGridViewTextBoxColumn
            // 
            this.nmcliforcompradorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforcompradorDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor_comprador";
            resources.ApplyResources(this.nmcliforcompradorDataGridViewTextBoxColumn, "nmcliforcompradorDataGridViewTextBoxColumn");
            this.nmcliforcompradorDataGridViewTextBoxColumn.Name = "nmcliforcompradorDataGridViewTextBoxColumn";
            this.nmcliforcompradorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsobservacaoDataGridViewTextBoxColumn
            // 
            this.dsobservacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_observacao";
            resources.ApplyResources(this.dsobservacaoDataGridViewTextBoxColumn, "dsobservacaoDataGridViewTextBoxColumn");
            this.dsobservacaoDataGridViewTextBoxColumn.Name = "dsobservacaoDataGridViewTextBoxColumn";
            this.dsobservacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingNavigator1
            // 
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsRequisicao;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
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
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            // 
            // bindingNavigatorMoveNextItem
            // 
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // TFGerarOrdemCompra
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFGerarOrdemCompra";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFGerarOrdemCompra_FormClosing);
            this.Load += new System.EventHandler(this.TFGerarOrdemCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFGerarOrdemCompra_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicao)).EndInit();
            this.rG_FiltroData.ResumeLayout(false);
            this.panelDados6.ResumeLayout(false);
            this.panelDados6.PerformLayout();
            this.tlpDetalhes.ResumeLayout(false);
            this.pRequisicoes.ResumeLayout(false);
            this.pRequisicoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gRequisicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.TableLayoutPanel tlpDetalhes;
        private Componentes.PanelDados pRequisicoes;
        private Componentes.RadioGroup rG_FiltroData;
        private Componentes.PanelDados panelDados6;
        private Componentes.EditData DT_Final;
        private Componentes.EditData DT_Inic;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private Componentes.EditDefault id_requisicao;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.BindingSource bsRequisicao;
        private Componentes.DataGridDefault gRequisicao;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Button bb_clifor_requisitante;
        private Componentes.EditDefault cd_clifor_requisitante;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_integrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idrequisicaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdaprovadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtrequisicaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcliforrequisitanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforrequisitanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcliforaprovadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforaprovadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcliforcompradorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforcompradorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn;
    }
}