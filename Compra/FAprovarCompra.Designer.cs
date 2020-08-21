namespace Compra
{
    partial class TFAprovarCompra
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
            System.Windows.Forms.Label ds_observacaoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAprovarCompra));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label dt_requisicaostrLabel;
            System.Windows.Forms.Label cd_produtoLabel;
            System.Windows.Forms.Label cd_clifor_requisitanteLabel;
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scNegociacao = new System.Windows.Forms.SplitContainer();
            this.gNegociacoes = new Componentes.DataGridDefault(this.components);
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idnegociacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdporcompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdmincompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlunitarionegociadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscondpgtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsportadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nrdiaspagamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmvendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailvendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foneFaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcondpgtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdportadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsNegociacao = new System.Windows.Forms.BindingSource(this.components);
            this.bsRequisicao = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.bsEntrega = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.editDefault3 = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lblConciliacao = new System.Windows.Forms.Label();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_aprovar = new System.Windows.Forms.ToolStripButton();
            this.bb_reprovar = new System.Windows.Forms.ToolStripButton();
            this.bb_renegociar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.quantidade = new Componentes.EditFloat(this.components);
            this.dt_requisicao = new Componentes.EditData(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.nm_clifor_requisitante = new Componentes.EditDefault(this.components);
            this.cd_clifor_requisitante = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.tcDetalhes = new System.Windows.Forms.TabControl();
            this.tpNegociacoes = new System.Windows.Forms.TabPage();
            this.tpCotacoes = new System.Windows.Forms.TabPage();
            this.gCotacao = new Componentes.DataGridDefault(this.components);
            this.St_integrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cdfornecedorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmfornecedorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtcotacaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dt_validadecotacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdatendidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlunitariocotadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcondpgtoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscondpgtoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdmoedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmoedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdportadorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsportadorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdtransportadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmtransportadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipofreteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prazoentregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmvendedorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailvendedorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fonefaxDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrdiasvigenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCotacao = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem2 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem2 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem2 = new System.Windows.Forms.ToolStripButton();
            this.pAprovar = new Componentes.PanelDados(this.components);
            this.ds_motivorenegociar = new Componentes.EditDefault(this.components);
            this.lblMotivoRepRen = new System.Windows.Forms.Label();
            this.qtd_aprovada = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            ds_observacaoLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            dt_requisicaostrLabel = new System.Windows.Forms.Label();
            cd_produtoLabel = new System.Windows.Forms.Label();
            cd_clifor_requisitanteLabel = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            this.scNegociacao.Panel1.SuspendLayout();
            this.scNegociacao.Panel2.SuspendLayout();
            this.scNegociacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gNegociacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNegociacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEntrega)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.tcDetalhes.SuspendLayout();
            this.tpNegociacoes.SuspendLayout();
            this.tpCotacoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCotacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCotacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
            this.pAprovar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_aprovada)).BeginInit();
            this.SuspendLayout();
            // 
            // ds_observacaoLabel
            // 
            ds_observacaoLabel.AccessibleDescription = null;
            ds_observacaoLabel.AccessibleName = null;
            resources.ApplyResources(ds_observacaoLabel, "ds_observacaoLabel");
            ds_observacaoLabel.Font = null;
            ds_observacaoLabel.Name = "ds_observacaoLabel";
            // 
            // scNegociacao
            // 
            this.scNegociacao.AccessibleDescription = null;
            this.scNegociacao.AccessibleName = null;
            resources.ApplyResources(this.scNegociacao, "scNegociacao");
            this.scNegociacao.BackgroundImage = null;
            this.scNegociacao.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scNegociacao.Font = null;
            this.scNegociacao.Name = "scNegociacao";
            // 
            // scNegociacao.Panel1
            // 
            this.scNegociacao.Panel1.AccessibleDescription = null;
            this.scNegociacao.Panel1.AccessibleName = null;
            resources.ApplyResources(this.scNegociacao.Panel1, "scNegociacao.Panel1");
            this.scNegociacao.Panel1.BackgroundImage = null;
            this.scNegociacao.Panel1.Controls.Add(this.gNegociacoes);
            this.scNegociacao.Panel1.Controls.Add(this.bindingNavigator1);
            this.scNegociacao.Panel1.Font = null;
            // 
            // scNegociacao.Panel2
            // 
            this.scNegociacao.Panel2.AccessibleDescription = null;
            this.scNegociacao.Panel2.AccessibleName = null;
            resources.ApplyResources(this.scNegociacao.Panel2, "scNegociacao.Panel2");
            this.scNegociacao.Panel2.BackgroundImage = null;
            this.scNegociacao.Panel2.Controls.Add(this.label4);
            this.scNegociacao.Panel2.Controls.Add(this.editFloat1);
            this.scNegociacao.Panel2.Controls.Add(this.label3);
            this.scNegociacao.Panel2.Controls.Add(this.editDefault3);
            this.scNegociacao.Panel2.Controls.Add(this.label2);
            this.scNegociacao.Panel2.Controls.Add(this.editDefault2);
            this.scNegociacao.Panel2.Controls.Add(this.label5);
            this.scNegociacao.Panel2.Controls.Add(this.lblConciliacao);
            this.scNegociacao.Panel2.Font = null;
            // 
            // gNegociacoes
            // 
            this.gNegociacoes.AccessibleDescription = null;
            this.gNegociacoes.AccessibleName = null;
            this.gNegociacoes.AllowUserToAddRows = false;
            this.gNegociacoes.AllowUserToDeleteRows = false;
            this.gNegociacoes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gNegociacoes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gNegociacoes, "gNegociacoes");
            this.gNegociacoes.AutoGenerateColumns = false;
            this.gNegociacoes.BackgroundColor = System.Drawing.Color.LightGray;
            this.gNegociacoes.BackgroundImage = null;
            this.gNegociacoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gNegociacoes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gNegociacoes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gNegociacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gNegociacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.idnegociacaoDataGridViewTextBoxColumn,
            this.nmfornecedorDataGridViewTextBoxColumn,
            this.qtdporcompraDataGridViewTextBoxColumn,
            this.qtdmincompraDataGridViewTextBoxColumn,
            this.vlunitarionegociadoDataGridViewTextBoxColumn,
            this.siglaDataGridViewTextBoxColumn,
            this.dscondpgtoDataGridViewTextBoxColumn,
            this.dsportadorDataGridViewTextBoxColumn,
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn,
            this.nrdiaspagamentoDataGridViewTextBoxColumn,
            this.nmvendedorDataGridViewTextBoxColumn,
            this.emailvendedorDataGridViewTextBoxColumn,
            this.foneFaxDataGridViewTextBoxColumn,
            this.cdfornecedorDataGridViewTextBoxColumn,
            this.cdcondpgtoDataGridViewTextBoxColumn,
            this.cdportadorDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn1});
            this.gNegociacoes.DataSource = this.bsNegociacao;
            this.gNegociacoes.Font = null;
            this.gNegociacoes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gNegociacoes.Name = "gNegociacoes";
            this.gNegociacoes.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gNegociacoes.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gNegociacoes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gNegociacoes_CellClick);
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            resources.ApplyResources(this.St_processar, "St_processar");
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            // 
            // idnegociacaoDataGridViewTextBoxColumn
            // 
            this.idnegociacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idnegociacaoDataGridViewTextBoxColumn.DataPropertyName = "Id_negociacao";
            resources.ApplyResources(this.idnegociacaoDataGridViewTextBoxColumn, "idnegociacaoDataGridViewTextBoxColumn");
            this.idnegociacaoDataGridViewTextBoxColumn.Name = "idnegociacaoDataGridViewTextBoxColumn";
            this.idnegociacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmfornecedorDataGridViewTextBoxColumn
            // 
            this.nmfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Nm_fornecedor";
            resources.ApplyResources(this.nmfornecedorDataGridViewTextBoxColumn, "nmfornecedorDataGridViewTextBoxColumn");
            this.nmfornecedorDataGridViewTextBoxColumn.Name = "nmfornecedorDataGridViewTextBoxColumn";
            this.nmfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdporcompraDataGridViewTextBoxColumn
            // 
            this.qtdporcompraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdporcompraDataGridViewTextBoxColumn.DataPropertyName = "Qtd_porcompra";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.qtdporcompraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.qtdporcompraDataGridViewTextBoxColumn, "qtdporcompraDataGridViewTextBoxColumn");
            this.qtdporcompraDataGridViewTextBoxColumn.Name = "qtdporcompraDataGridViewTextBoxColumn";
            this.qtdporcompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdmincompraDataGridViewTextBoxColumn
            // 
            this.qtdmincompraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdmincompraDataGridViewTextBoxColumn.DataPropertyName = "Qtd_min_compra";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.qtdmincompraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.qtdmincompraDataGridViewTextBoxColumn, "qtdmincompraDataGridViewTextBoxColumn");
            this.qtdmincompraDataGridViewTextBoxColumn.Name = "qtdmincompraDataGridViewTextBoxColumn";
            this.qtdmincompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlunitarionegociadoDataGridViewTextBoxColumn
            // 
            this.vlunitarionegociadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlunitarionegociadoDataGridViewTextBoxColumn.DataPropertyName = "Vl_unitario_negociado";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.vlunitarionegociadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.vlunitarionegociadoDataGridViewTextBoxColumn, "vlunitarionegociadoDataGridViewTextBoxColumn");
            this.vlunitarionegociadoDataGridViewTextBoxColumn.Name = "vlunitarionegociadoDataGridViewTextBoxColumn";
            this.vlunitarionegociadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siglaDataGridViewTextBoxColumn
            // 
            this.siglaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaDataGridViewTextBoxColumn.DataPropertyName = "Sigla";
            resources.ApplyResources(this.siglaDataGridViewTextBoxColumn, "siglaDataGridViewTextBoxColumn");
            this.siglaDataGridViewTextBoxColumn.Name = "siglaDataGridViewTextBoxColumn";
            this.siglaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dscondpgtoDataGridViewTextBoxColumn
            // 
            this.dscondpgtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscondpgtoDataGridViewTextBoxColumn.DataPropertyName = "Ds_condpgto";
            resources.ApplyResources(this.dscondpgtoDataGridViewTextBoxColumn, "dscondpgtoDataGridViewTextBoxColumn");
            this.dscondpgtoDataGridViewTextBoxColumn.Name = "dscondpgtoDataGridViewTextBoxColumn";
            this.dscondpgtoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsportadorDataGridViewTextBoxColumn
            // 
            this.dsportadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsportadorDataGridViewTextBoxColumn.DataPropertyName = "Ds_portador";
            resources.ApplyResources(this.dsportadorDataGridViewTextBoxColumn, "dsportadorDataGridViewTextBoxColumn");
            this.dsportadorDataGridViewTextBoxColumn.Name = "dsportadorDataGridViewTextBoxColumn";
            this.dsportadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stdepositarpagtoboolDataGridViewCheckBoxColumn
            // 
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_depositarpagtobool";
            resources.ApplyResources(this.stdepositarpagtoboolDataGridViewCheckBoxColumn, "stdepositarpagtoboolDataGridViewCheckBoxColumn");
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn.Name = "stdepositarpagtoboolDataGridViewCheckBoxColumn";
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // nrdiaspagamentoDataGridViewTextBoxColumn
            // 
            this.nrdiaspagamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrdiaspagamentoDataGridViewTextBoxColumn.DataPropertyName = "Nr_diaspagamento";
            resources.ApplyResources(this.nrdiaspagamentoDataGridViewTextBoxColumn, "nrdiaspagamentoDataGridViewTextBoxColumn");
            this.nrdiaspagamentoDataGridViewTextBoxColumn.Name = "nrdiaspagamentoDataGridViewTextBoxColumn";
            this.nrdiaspagamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmvendedorDataGridViewTextBoxColumn
            // 
            this.nmvendedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmvendedorDataGridViewTextBoxColumn.DataPropertyName = "Nm_vendedor";
            resources.ApplyResources(this.nmvendedorDataGridViewTextBoxColumn, "nmvendedorDataGridViewTextBoxColumn");
            this.nmvendedorDataGridViewTextBoxColumn.Name = "nmvendedorDataGridViewTextBoxColumn";
            this.nmvendedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailvendedorDataGridViewTextBoxColumn
            // 
            this.emailvendedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.emailvendedorDataGridViewTextBoxColumn.DataPropertyName = "Email_vendedor";
            resources.ApplyResources(this.emailvendedorDataGridViewTextBoxColumn, "emailvendedorDataGridViewTextBoxColumn");
            this.emailvendedorDataGridViewTextBoxColumn.Name = "emailvendedorDataGridViewTextBoxColumn";
            this.emailvendedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // foneFaxDataGridViewTextBoxColumn
            // 
            this.foneFaxDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.foneFaxDataGridViewTextBoxColumn.DataPropertyName = "FoneFax";
            resources.ApplyResources(this.foneFaxDataGridViewTextBoxColumn, "foneFaxDataGridViewTextBoxColumn");
            this.foneFaxDataGridViewTextBoxColumn.Name = "foneFaxDataGridViewTextBoxColumn";
            this.foneFaxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdfornecedorDataGridViewTextBoxColumn
            // 
            this.cdfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Cd_fornecedor";
            resources.ApplyResources(this.cdfornecedorDataGridViewTextBoxColumn, "cdfornecedorDataGridViewTextBoxColumn");
            this.cdfornecedorDataGridViewTextBoxColumn.Name = "cdfornecedorDataGridViewTextBoxColumn";
            this.cdfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdcondpgtoDataGridViewTextBoxColumn
            // 
            this.cdcondpgtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcondpgtoDataGridViewTextBoxColumn.DataPropertyName = "Cd_condpgto";
            resources.ApplyResources(this.cdcondpgtoDataGridViewTextBoxColumn, "cdcondpgtoDataGridViewTextBoxColumn");
            this.cdcondpgtoDataGridViewTextBoxColumn.Name = "cdcondpgtoDataGridViewTextBoxColumn";
            this.cdcondpgtoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdportadorDataGridViewTextBoxColumn
            // 
            this.cdportadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdportadorDataGridViewTextBoxColumn.DataPropertyName = "Cd_portador";
            resources.ApplyResources(this.cdportadorDataGridViewTextBoxColumn, "cdportadorDataGridViewTextBoxColumn");
            this.cdportadorDataGridViewTextBoxColumn.Name = "cdportadorDataGridViewTextBoxColumn";
            this.cdportadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsobservacaoDataGridViewTextBoxColumn1
            // 
            this.dsobservacaoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn1.DataPropertyName = "Ds_observacao";
            resources.ApplyResources(this.dsobservacaoDataGridViewTextBoxColumn1, "dsobservacaoDataGridViewTextBoxColumn1");
            this.dsobservacaoDataGridViewTextBoxColumn1.Name = "dsobservacaoDataGridViewTextBoxColumn1";
            this.dsobservacaoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // bsNegociacao
            // 
            this.bsNegociacao.DataMember = "lReqneg";
            this.bsNegociacao.DataSource = this.bsRequisicao;
            // 
            // bsRequisicao
            // 
            this.bsRequisicao.DataSource = typeof(CamadaDados.Compra.Lancamento.TList_Requisicao);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AccessibleDescription = null;
            this.bindingNavigator1.AccessibleName = null;
            this.bindingNavigator1.AddNewItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.BackgroundImage = null;
            this.bindingNavigator1.BindingSource = this.bsNegociacao;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem1;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Font = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1});
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem1;
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.AccessibleDescription = null;
            this.bindingNavigatorCountItem1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem1, "bindingNavigatorCountItem1");
            this.bindingNavigatorCountItem1.BackgroundImage = null;
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem1, "bindingNavigatorMoveFirstItem1");
            this.bindingNavigatorMoveFirstItem1.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem1, "bindingNavigatorMovePreviousItem1");
            this.bindingNavigatorMovePreviousItem1.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.AccessibleDescription = null;
            this.bindingNavigatorSeparator2.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem1, "bindingNavigatorPositionItem1");
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.AccessibleDescription = null;
            this.bindingNavigatorSeparator3.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator3, "bindingNavigatorSeparator3");
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem1, "bindingNavigatorMoveNextItem1");
            this.bindingNavigatorMoveNextItem1.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem1, "bindingNavigatorMoveLastItem1");
            this.bindingNavigatorMoveLastItem1.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Font = null;
            this.label4.Name = "label4";
            // 
            // editFloat1
            // 
            this.editFloat1.AccessibleDescription = null;
            this.editFloat1.AccessibleName = null;
            resources.ApplyResources(this.editFloat1, "editFloat1");
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEntrega, "Prazo_entrega", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat1.Font = null;
            this.editFloat1.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = false;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = false;
            this.editFloat1.ST_PrimaryKey = false;
            // 
            // bsEntrega
            // 
            this.bsEntrega.DataMember = "lPrazoEntrega";
            this.bsEntrega.DataSource = this.bsNegociacao;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // editDefault3
            // 
            this.editDefault3.AccessibleDescription = null;
            this.editDefault3.AccessibleName = null;
            resources.ApplyResources(this.editDefault3, "editDefault3");
            this.editDefault3.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault3.BackgroundImage = null;
            this.editDefault3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEntrega, "Tipo_frete", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault3.Font = null;
            this.editDefault3.Name = "editDefault3";
            this.editDefault3.NM_Alias = "";
            this.editDefault3.NM_Campo = "";
            this.editDefault3.NM_CampoBusca = "";
            this.editDefault3.NM_Param = "";
            this.editDefault3.QTD_Zero = 0;
            this.editDefault3.ST_AutoInc = false;
            this.editDefault3.ST_DisableAuto = false;
            this.editDefault3.ST_Float = false;
            this.editDefault3.ST_Gravar = false;
            this.editDefault3.ST_Int = false;
            this.editDefault3.ST_LimpaCampo = true;
            this.editDefault3.ST_NotNull = false;
            this.editDefault3.ST_PrimaryKey = false;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // editDefault2
            // 
            this.editDefault2.AccessibleDescription = null;
            this.editDefault2.AccessibleName = null;
            resources.ApplyResources(this.editDefault2, "editDefault2");
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BackgroundImage = null;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEntrega, "Nm_transportadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Font = null;
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "";
            this.editDefault2.NM_CampoBusca = "";
            this.editDefault2.NM_Param = "";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = false;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = false;
            this.editDefault2.ST_PrimaryKey = false;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Font = null;
            this.label5.Name = "label5";
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
            // label1
            // 
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.Font = null;
            label1.Name = "label1";
            // 
            // dt_requisicaostrLabel
            // 
            dt_requisicaostrLabel.AccessibleDescription = null;
            dt_requisicaostrLabel.AccessibleName = null;
            resources.ApplyResources(dt_requisicaostrLabel, "dt_requisicaostrLabel");
            dt_requisicaostrLabel.Font = null;
            dt_requisicaostrLabel.Name = "dt_requisicaostrLabel";
            // 
            // cd_produtoLabel
            // 
            cd_produtoLabel.AccessibleDescription = null;
            cd_produtoLabel.AccessibleName = null;
            resources.ApplyResources(cd_produtoLabel, "cd_produtoLabel");
            cd_produtoLabel.Font = null;
            cd_produtoLabel.Name = "cd_produtoLabel";
            // 
            // cd_clifor_requisitanteLabel
            // 
            cd_clifor_requisitanteLabel.AccessibleDescription = null;
            cd_clifor_requisitanteLabel.AccessibleName = null;
            resources.ApplyResources(cd_clifor_requisitanteLabel, "cd_clifor_requisitanteLabel");
            cd_clifor_requisitanteLabel.Font = null;
            cd_clifor_requisitanteLabel.Name = "cd_clifor_requisitanteLabel";
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AccessibleDescription = null;
            cd_empresaLabel.AccessibleName = null;
            resources.ApplyResources(cd_empresaLabel, "cd_empresaLabel");
            cd_empresaLabel.Font = null;
            cd_empresaLabel.Name = "cd_empresaLabel";
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Font = null;
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_aprovar,
            this.bb_reprovar,
            this.bb_renegociar,
            this.toolStripSeparator1,
            this.BB_Cancelar});
            this.barraMenu.Name = "barraMenu";
            // 
            // bb_aprovar
            // 
            this.bb_aprovar.AccessibleDescription = null;
            this.bb_aprovar.AccessibleName = null;
            resources.ApplyResources(this.bb_aprovar, "bb_aprovar");
            this.bb_aprovar.BackgroundImage = null;
            this.bb_aprovar.ForeColor = System.Drawing.Color.Green;
            this.bb_aprovar.Name = "bb_aprovar";
            this.bb_aprovar.Click += new System.EventHandler(this.bb_aprovar_Click);
            // 
            // bb_reprovar
            // 
            this.bb_reprovar.AccessibleDescription = null;
            this.bb_reprovar.AccessibleName = null;
            resources.ApplyResources(this.bb_reprovar, "bb_reprovar");
            this.bb_reprovar.BackgroundImage = null;
            this.bb_reprovar.ForeColor = System.Drawing.Color.Green;
            this.bb_reprovar.Name = "bb_reprovar";
            this.bb_reprovar.Click += new System.EventHandler(this.bb_reprovar_Click);
            // 
            // bb_renegociar
            // 
            this.bb_renegociar.AccessibleDescription = null;
            this.bb_renegociar.AccessibleName = null;
            resources.ApplyResources(this.bb_renegociar, "bb_renegociar");
            this.bb_renegociar.BackgroundImage = null;
            this.bb_renegociar.ForeColor = System.Drawing.Color.Green;
            this.bb_renegociar.Name = "bb_renegociar";
            this.bb_renegociar.Click += new System.EventHandler(this.bb_renegociar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
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
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 1);
            this.tlpCentral.Controls.Add(this.pAprovar, 0, 2);
            this.tlpCentral.Font = null;
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.sigla_unidade);
            this.pDados.Controls.Add(this.quantidade);
            this.pDados.Controls.Add(this.dt_requisicao);
            this.pDados.Controls.Add(ds_observacaoLabel);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(dt_requisicaostrLabel);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(cd_produtoLabel);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.nm_clifor_requisitante);
            this.pDados.Controls.Add(cd_clifor_requisitanteLabel);
            this.pDados.Controls.Add(this.cd_clifor_requisitante);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Font = null;
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.AccessibleDescription = null;
            this.sigla_unidade.AccessibleName = null;
            resources.ApplyResources(this.sigla_unidade, "sigla_unidade");
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.BackgroundImage = null;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidade.Font = null;
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
            // 
            // quantidade
            // 
            this.quantidade.AccessibleDescription = null;
            this.quantidade.AccessibleName = null;
            resources.ApplyResources(this.quantidade, "quantidade");
            this.quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRequisicao, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.quantidade.Font = null;
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
            this.dt_requisicao.AccessibleDescription = null;
            this.dt_requisicao.AccessibleName = null;
            resources.ApplyResources(this.dt_requisicao, "dt_requisicao");
            this.dt_requisicao.BackgroundImage = null;
            this.dt_requisicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Dt_requisicaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_requisicao.Font = null;
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
            // ds_observacao
            // 
            this.ds_observacao.AccessibleDescription = null;
            this.ds_observacao.AccessibleName = null;
            resources.ApplyResources(this.ds_observacao, "ds_observacao");
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BackgroundImage = null;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Font = null;
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
            // 
            // ds_produto
            // 
            this.ds_produto.AccessibleDescription = null;
            this.ds_produto.AccessibleName = null;
            resources.ApplyResources(this.ds_produto, "ds_produto");
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BackgroundImage = null;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Font = null;
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
            // 
            // cd_produto
            // 
            this.cd_produto.AccessibleDescription = null;
            this.cd_produto.AccessibleName = null;
            resources.ApplyResources(this.cd_produto, "cd_produto");
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BackgroundImage = null;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Font = null;
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
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            // 
            // nm_clifor_requisitante
            // 
            this.nm_clifor_requisitante.AccessibleDescription = null;
            this.nm_clifor_requisitante.AccessibleName = null;
            resources.ApplyResources(this.nm_clifor_requisitante, "nm_clifor_requisitante");
            this.nm_clifor_requisitante.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor_requisitante.BackgroundImage = null;
            this.nm_clifor_requisitante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor_requisitante.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Nm_clifor_requisitante", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_clifor_requisitante.Font = null;
            this.nm_clifor_requisitante.Name = "nm_clifor_requisitante";
            this.nm_clifor_requisitante.NM_Alias = "";
            this.nm_clifor_requisitante.NM_Campo = "nm_clifor";
            this.nm_clifor_requisitante.NM_CampoBusca = "nm_clifor";
            this.nm_clifor_requisitante.NM_Param = "@P_NM_CLIFOR_CMP";
            this.nm_clifor_requisitante.QTD_Zero = 0;
            this.nm_clifor_requisitante.ST_AutoInc = false;
            this.nm_clifor_requisitante.ST_DisableAuto = false;
            this.nm_clifor_requisitante.ST_Float = false;
            this.nm_clifor_requisitante.ST_Gravar = false;
            this.nm_clifor_requisitante.ST_Int = false;
            this.nm_clifor_requisitante.ST_LimpaCampo = true;
            this.nm_clifor_requisitante.ST_NotNull = false;
            this.nm_clifor_requisitante.ST_PrimaryKey = false;
            // 
            // cd_clifor_requisitante
            // 
            this.cd_clifor_requisitante.AccessibleDescription = null;
            this.cd_clifor_requisitante.AccessibleName = null;
            resources.ApplyResources(this.cd_clifor_requisitante, "cd_clifor_requisitante");
            this.cd_clifor_requisitante.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor_requisitante.BackgroundImage = null;
            this.cd_clifor_requisitante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor_requisitante.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Cd_clifor_requisitante", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor_requisitante.Font = null;
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
            // 
            // nm_empresa
            // 
            this.nm_empresa.AccessibleDescription = null;
            this.nm_empresa.AccessibleName = null;
            resources.ApplyResources(this.nm_empresa, "nm_empresa");
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BackgroundImage = null;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            // cd_empresa
            // 
            this.cd_empresa.AccessibleDescription = null;
            this.cd_empresa.AccessibleName = null;
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
            this.cd_empresa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(137)))));
            this.cd_empresa.BackgroundImage = null;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            // 
            // panelDados1
            // 
            this.panelDados1.AccessibleDescription = null;
            this.panelDados1.AccessibleName = null;
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.BackgroundImage = null;
            this.panelDados1.Controls.Add(this.tcDetalhes);
            this.panelDados1.Font = null;
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // tcDetalhes
            // 
            this.tcDetalhes.AccessibleDescription = null;
            this.tcDetalhes.AccessibleName = null;
            resources.ApplyResources(this.tcDetalhes, "tcDetalhes");
            this.tcDetalhes.BackgroundImage = null;
            this.tcDetalhes.Controls.Add(this.tpNegociacoes);
            this.tcDetalhes.Controls.Add(this.tpCotacoes);
            this.tcDetalhes.Font = null;
            this.tcDetalhes.Name = "tcDetalhes";
            this.tcDetalhes.SelectedIndex = 0;
            // 
            // tpNegociacoes
            // 
            this.tpNegociacoes.AccessibleDescription = null;
            this.tpNegociacoes.AccessibleName = null;
            resources.ApplyResources(this.tpNegociacoes, "tpNegociacoes");
            this.tpNegociacoes.BackgroundImage = null;
            this.tpNegociacoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpNegociacoes.Controls.Add(this.scNegociacao);
            this.tpNegociacoes.Font = null;
            this.tpNegociacoes.Name = "tpNegociacoes";
            this.tpNegociacoes.UseVisualStyleBackColor = true;
            // 
            // tpCotacoes
            // 
            this.tpCotacoes.AccessibleDescription = null;
            this.tpCotacoes.AccessibleName = null;
            resources.ApplyResources(this.tpCotacoes, "tpCotacoes");
            this.tpCotacoes.BackgroundImage = null;
            this.tpCotacoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpCotacoes.Controls.Add(this.gCotacao);
            this.tpCotacoes.Controls.Add(this.bindingNavigator2);
            this.tpCotacoes.Font = null;
            this.tpCotacoes.Name = "tpCotacoes";
            this.tpCotacoes.UseVisualStyleBackColor = true;
            // 
            // gCotacao
            // 
            this.gCotacao.AccessibleDescription = null;
            this.gCotacao.AccessibleName = null;
            this.gCotacao.AllowUserToAddRows = false;
            this.gCotacao.AllowUserToDeleteRows = false;
            this.gCotacao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gCotacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.gCotacao, "gCotacao");
            this.gCotacao.AutoGenerateColumns = false;
            this.gCotacao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCotacao.BackgroundImage = null;
            this.gCotacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCotacao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCotacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gCotacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCotacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_integrar,
            this.cdfornecedorDataGridViewTextBoxColumn1,
            this.nmfornecedorDataGridViewTextBoxColumn1,
            this.dtcotacaostrDataGridViewTextBoxColumn,
            this.Dt_validadecotacao,
            this.qtdatendidaDataGridViewTextBoxColumn,
            this.vlunitariocotadoDataGridViewTextBoxColumn,
            this.siglaDataGridViewTextBoxColumn1,
            this.cdcondpgtoDataGridViewTextBoxColumn1,
            this.dscondpgtoDataGridViewTextBoxColumn1,
            this.cdmoedaDataGridViewTextBoxColumn,
            this.dsmoedaDataGridViewTextBoxColumn,
            this.cdportadorDataGridViewTextBoxColumn1,
            this.dsportadorDataGridViewTextBoxColumn1,
            this.cdtransportadoraDataGridViewTextBoxColumn,
            this.nmtransportadoraDataGridViewTextBoxColumn,
            this.tipofreteDataGridViewTextBoxColumn,
            this.prazoentregaDataGridViewTextBoxColumn,
            this.nmvendedorDataGridViewTextBoxColumn1,
            this.emailvendedorDataGridViewTextBoxColumn1,
            this.fonefaxDataGridViewTextBoxColumn1,
            this.nrdiasvigenciaDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn2,
            this.statusDataGridViewTextBoxColumn});
            this.gCotacao.DataSource = this.bsCotacao;
            this.gCotacao.Font = null;
            this.gCotacao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCotacao.Name = "gCotacao";
            this.gCotacao.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCotacao.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gCotacao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gCotacao_CellClick);
            // 
            // St_integrar
            // 
            this.St_integrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_integrar.DataPropertyName = "St_integrar";
            resources.ApplyResources(this.St_integrar, "St_integrar");
            this.St_integrar.Name = "St_integrar";
            this.St_integrar.ReadOnly = true;
            // 
            // cdfornecedorDataGridViewTextBoxColumn1
            // 
            this.cdfornecedorDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdfornecedorDataGridViewTextBoxColumn1.DataPropertyName = "Cd_fornecedor";
            resources.ApplyResources(this.cdfornecedorDataGridViewTextBoxColumn1, "cdfornecedorDataGridViewTextBoxColumn1");
            this.cdfornecedorDataGridViewTextBoxColumn1.Name = "cdfornecedorDataGridViewTextBoxColumn1";
            this.cdfornecedorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nmfornecedorDataGridViewTextBoxColumn1
            // 
            this.nmfornecedorDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmfornecedorDataGridViewTextBoxColumn1.DataPropertyName = "Nm_fornecedor";
            resources.ApplyResources(this.nmfornecedorDataGridViewTextBoxColumn1, "nmfornecedorDataGridViewTextBoxColumn1");
            this.nmfornecedorDataGridViewTextBoxColumn1.Name = "nmfornecedorDataGridViewTextBoxColumn1";
            this.nmfornecedorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dtcotacaostrDataGridViewTextBoxColumn
            // 
            this.dtcotacaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtcotacaostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_cotacaostr";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            this.dtcotacaostrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(this.dtcotacaostrDataGridViewTextBoxColumn, "dtcotacaostrDataGridViewTextBoxColumn");
            this.dtcotacaostrDataGridViewTextBoxColumn.Name = "dtcotacaostrDataGridViewTextBoxColumn";
            this.dtcotacaostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Dt_validadecotacao
            // 
            this.Dt_validadecotacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dt_validadecotacao.DataPropertyName = "Dt_validadecotacao";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "d";
            dataGridViewCellStyle10.NullValue = null;
            this.Dt_validadecotacao.DefaultCellStyle = dataGridViewCellStyle10;
            resources.ApplyResources(this.Dt_validadecotacao, "Dt_validadecotacao");
            this.Dt_validadecotacao.Name = "Dt_validadecotacao";
            this.Dt_validadecotacao.ReadOnly = true;
            // 
            // qtdatendidaDataGridViewTextBoxColumn
            // 
            this.qtdatendidaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdatendidaDataGridViewTextBoxColumn.DataPropertyName = "Qtd_atendida";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = "0";
            this.qtdatendidaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(this.qtdatendidaDataGridViewTextBoxColumn, "qtdatendidaDataGridViewTextBoxColumn");
            this.qtdatendidaDataGridViewTextBoxColumn.Name = "qtdatendidaDataGridViewTextBoxColumn";
            this.qtdatendidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlunitariocotadoDataGridViewTextBoxColumn
            // 
            this.vlunitariocotadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlunitariocotadoDataGridViewTextBoxColumn.DataPropertyName = "Vl_unitario_cotado";
            resources.ApplyResources(this.vlunitariocotadoDataGridViewTextBoxColumn, "vlunitariocotadoDataGridViewTextBoxColumn");
            this.vlunitariocotadoDataGridViewTextBoxColumn.Name = "vlunitariocotadoDataGridViewTextBoxColumn";
            this.vlunitariocotadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siglaDataGridViewTextBoxColumn1
            // 
            this.siglaDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaDataGridViewTextBoxColumn1.DataPropertyName = "Sigla";
            resources.ApplyResources(this.siglaDataGridViewTextBoxColumn1, "siglaDataGridViewTextBoxColumn1");
            this.siglaDataGridViewTextBoxColumn1.Name = "siglaDataGridViewTextBoxColumn1";
            this.siglaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cdcondpgtoDataGridViewTextBoxColumn1
            // 
            this.cdcondpgtoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcondpgtoDataGridViewTextBoxColumn1.DataPropertyName = "Cd_condpgto";
            resources.ApplyResources(this.cdcondpgtoDataGridViewTextBoxColumn1, "cdcondpgtoDataGridViewTextBoxColumn1");
            this.cdcondpgtoDataGridViewTextBoxColumn1.Name = "cdcondpgtoDataGridViewTextBoxColumn1";
            this.cdcondpgtoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dscondpgtoDataGridViewTextBoxColumn1
            // 
            this.dscondpgtoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscondpgtoDataGridViewTextBoxColumn1.DataPropertyName = "Ds_condpgto";
            resources.ApplyResources(this.dscondpgtoDataGridViewTextBoxColumn1, "dscondpgtoDataGridViewTextBoxColumn1");
            this.dscondpgtoDataGridViewTextBoxColumn1.Name = "dscondpgtoDataGridViewTextBoxColumn1";
            this.dscondpgtoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cdmoedaDataGridViewTextBoxColumn
            // 
            this.cdmoedaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdmoedaDataGridViewTextBoxColumn.DataPropertyName = "Cd_moeda";
            resources.ApplyResources(this.cdmoedaDataGridViewTextBoxColumn, "cdmoedaDataGridViewTextBoxColumn");
            this.cdmoedaDataGridViewTextBoxColumn.Name = "cdmoedaDataGridViewTextBoxColumn";
            this.cdmoedaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsmoedaDataGridViewTextBoxColumn
            // 
            this.dsmoedaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmoedaDataGridViewTextBoxColumn.DataPropertyName = "Ds_moeda";
            resources.ApplyResources(this.dsmoedaDataGridViewTextBoxColumn, "dsmoedaDataGridViewTextBoxColumn");
            this.dsmoedaDataGridViewTextBoxColumn.Name = "dsmoedaDataGridViewTextBoxColumn";
            this.dsmoedaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdportadorDataGridViewTextBoxColumn1
            // 
            this.cdportadorDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdportadorDataGridViewTextBoxColumn1.DataPropertyName = "Cd_portador";
            resources.ApplyResources(this.cdportadorDataGridViewTextBoxColumn1, "cdportadorDataGridViewTextBoxColumn1");
            this.cdportadorDataGridViewTextBoxColumn1.Name = "cdportadorDataGridViewTextBoxColumn1";
            this.cdportadorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dsportadorDataGridViewTextBoxColumn1
            // 
            this.dsportadorDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsportadorDataGridViewTextBoxColumn1.DataPropertyName = "Ds_portador";
            resources.ApplyResources(this.dsportadorDataGridViewTextBoxColumn1, "dsportadorDataGridViewTextBoxColumn1");
            this.dsportadorDataGridViewTextBoxColumn1.Name = "dsportadorDataGridViewTextBoxColumn1";
            this.dsportadorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cdtransportadoraDataGridViewTextBoxColumn
            // 
            this.cdtransportadoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdtransportadoraDataGridViewTextBoxColumn.DataPropertyName = "Cd_transportadora";
            resources.ApplyResources(this.cdtransportadoraDataGridViewTextBoxColumn, "cdtransportadoraDataGridViewTextBoxColumn");
            this.cdtransportadoraDataGridViewTextBoxColumn.Name = "cdtransportadoraDataGridViewTextBoxColumn";
            this.cdtransportadoraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmtransportadoraDataGridViewTextBoxColumn
            // 
            this.nmtransportadoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmtransportadoraDataGridViewTextBoxColumn.DataPropertyName = "Nm_transportadora";
            resources.ApplyResources(this.nmtransportadoraDataGridViewTextBoxColumn, "nmtransportadoraDataGridViewTextBoxColumn");
            this.nmtransportadoraDataGridViewTextBoxColumn.Name = "nmtransportadoraDataGridViewTextBoxColumn";
            this.nmtransportadoraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipofreteDataGridViewTextBoxColumn
            // 
            this.tipofreteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipofreteDataGridViewTextBoxColumn.DataPropertyName = "Tipo_frete";
            resources.ApplyResources(this.tipofreteDataGridViewTextBoxColumn, "tipofreteDataGridViewTextBoxColumn");
            this.tipofreteDataGridViewTextBoxColumn.Name = "tipofreteDataGridViewTextBoxColumn";
            this.tipofreteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prazoentregaDataGridViewTextBoxColumn
            // 
            this.prazoentregaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.prazoentregaDataGridViewTextBoxColumn.DataPropertyName = "Prazo_entrega";
            resources.ApplyResources(this.prazoentregaDataGridViewTextBoxColumn, "prazoentregaDataGridViewTextBoxColumn");
            this.prazoentregaDataGridViewTextBoxColumn.Name = "prazoentregaDataGridViewTextBoxColumn";
            this.prazoentregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmvendedorDataGridViewTextBoxColumn1
            // 
            this.nmvendedorDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmvendedorDataGridViewTextBoxColumn1.DataPropertyName = "Nm_vendedor";
            resources.ApplyResources(this.nmvendedorDataGridViewTextBoxColumn1, "nmvendedorDataGridViewTextBoxColumn1");
            this.nmvendedorDataGridViewTextBoxColumn1.Name = "nmvendedorDataGridViewTextBoxColumn1";
            this.nmvendedorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // emailvendedorDataGridViewTextBoxColumn1
            // 
            this.emailvendedorDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.emailvendedorDataGridViewTextBoxColumn1.DataPropertyName = "Emailvendedor";
            resources.ApplyResources(this.emailvendedorDataGridViewTextBoxColumn1, "emailvendedorDataGridViewTextBoxColumn1");
            this.emailvendedorDataGridViewTextBoxColumn1.Name = "emailvendedorDataGridViewTextBoxColumn1";
            this.emailvendedorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // fonefaxDataGridViewTextBoxColumn1
            // 
            this.fonefaxDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fonefaxDataGridViewTextBoxColumn1.DataPropertyName = "Fonefax";
            resources.ApplyResources(this.fonefaxDataGridViewTextBoxColumn1, "fonefaxDataGridViewTextBoxColumn1");
            this.fonefaxDataGridViewTextBoxColumn1.Name = "fonefaxDataGridViewTextBoxColumn1";
            this.fonefaxDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nrdiasvigenciaDataGridViewTextBoxColumn
            // 
            this.nrdiasvigenciaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrdiasvigenciaDataGridViewTextBoxColumn.DataPropertyName = "Nr_diasvigencia";
            resources.ApplyResources(this.nrdiasvigenciaDataGridViewTextBoxColumn, "nrdiasvigenciaDataGridViewTextBoxColumn");
            this.nrdiasvigenciaDataGridViewTextBoxColumn.Name = "nrdiasvigenciaDataGridViewTextBoxColumn";
            this.nrdiasvigenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsobservacaoDataGridViewTextBoxColumn2
            // 
            this.dsobservacaoDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn2.DataPropertyName = "Ds_observacao";
            resources.ApplyResources(this.dsobservacaoDataGridViewTextBoxColumn2, "dsobservacaoDataGridViewTextBoxColumn2");
            this.dsobservacaoDataGridViewTextBoxColumn2.Name = "dsobservacaoDataGridViewTextBoxColumn2";
            this.dsobservacaoDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            resources.ApplyResources(this.statusDataGridViewTextBoxColumn, "statusDataGridViewTextBoxColumn");
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsCotacao
            // 
            this.bsCotacao.DataMember = "lCotacoes";
            this.bsCotacao.DataSource = this.bsRequisicao;
            // 
            // bindingNavigator2
            // 
            this.bindingNavigator2.AccessibleDescription = null;
            this.bindingNavigator2.AccessibleName = null;
            this.bindingNavigator2.AddNewItem = null;
            resources.ApplyResources(this.bindingNavigator2, "bindingNavigator2");
            this.bindingNavigator2.BackgroundImage = null;
            this.bindingNavigator2.BindingSource = this.bsCotacao;
            this.bindingNavigator2.CountItem = this.bindingNavigatorCountItem2;
            this.bindingNavigator2.DeleteItem = null;
            this.bindingNavigator2.Font = null;
            this.bindingNavigator2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem2,
            this.bindingNavigatorMovePreviousItem2,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorPositionItem2,
            this.bindingNavigatorCountItem2,
            this.bindingNavigatorSeparator5,
            this.bindingNavigatorMoveNextItem2,
            this.bindingNavigatorMoveLastItem2});
            this.bindingNavigator2.MoveFirstItem = this.bindingNavigatorMoveFirstItem2;
            this.bindingNavigator2.MoveLastItem = this.bindingNavigatorMoveLastItem2;
            this.bindingNavigator2.MoveNextItem = this.bindingNavigatorMoveNextItem2;
            this.bindingNavigator2.MovePreviousItem = this.bindingNavigatorMovePreviousItem2;
            this.bindingNavigator2.Name = "bindingNavigator2";
            this.bindingNavigator2.PositionItem = this.bindingNavigatorPositionItem2;
            // 
            // bindingNavigatorCountItem2
            // 
            this.bindingNavigatorCountItem2.AccessibleDescription = null;
            this.bindingNavigatorCountItem2.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem2, "bindingNavigatorCountItem2");
            this.bindingNavigatorCountItem2.BackgroundImage = null;
            this.bindingNavigatorCountItem2.Name = "bindingNavigatorCountItem2";
            // 
            // bindingNavigatorMoveFirstItem2
            // 
            this.bindingNavigatorMoveFirstItem2.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem2.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem2, "bindingNavigatorMoveFirstItem2");
            this.bindingNavigatorMoveFirstItem2.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem2.Name = "bindingNavigatorMoveFirstItem2";
            // 
            // bindingNavigatorMovePreviousItem2
            // 
            this.bindingNavigatorMovePreviousItem2.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem2.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem2, "bindingNavigatorMovePreviousItem2");
            this.bindingNavigatorMovePreviousItem2.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem2.Name = "bindingNavigatorMovePreviousItem2";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.AccessibleDescription = null;
            this.bindingNavigatorSeparator4.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator4, "bindingNavigatorSeparator4");
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            // 
            // bindingNavigatorPositionItem2
            // 
            this.bindingNavigatorPositionItem2.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem2, "bindingNavigatorPositionItem2");
            this.bindingNavigatorPositionItem2.Name = "bindingNavigatorPositionItem2";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.AccessibleDescription = null;
            this.bindingNavigatorSeparator5.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator5, "bindingNavigatorSeparator5");
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            // 
            // bindingNavigatorMoveNextItem2
            // 
            this.bindingNavigatorMoveNextItem2.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem2.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem2, "bindingNavigatorMoveNextItem2");
            this.bindingNavigatorMoveNextItem2.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem2.Name = "bindingNavigatorMoveNextItem2";
            // 
            // bindingNavigatorMoveLastItem2
            // 
            this.bindingNavigatorMoveLastItem2.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem2.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem2, "bindingNavigatorMoveLastItem2");
            this.bindingNavigatorMoveLastItem2.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem2.Name = "bindingNavigatorMoveLastItem2";
            // 
            // pAprovar
            // 
            this.pAprovar.AccessibleDescription = null;
            this.pAprovar.AccessibleName = null;
            resources.ApplyResources(this.pAprovar, "pAprovar");
            this.pAprovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pAprovar.BackgroundImage = null;
            this.pAprovar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAprovar.Controls.Add(this.ds_motivorenegociar);
            this.pAprovar.Controls.Add(this.lblMotivoRepRen);
            this.pAprovar.Controls.Add(this.qtd_aprovada);
            this.pAprovar.Controls.Add(this.label6);
            this.pAprovar.Font = null;
            this.pAprovar.Name = "pAprovar";
            this.pAprovar.NM_ProcDeletar = "";
            this.pAprovar.NM_ProcGravar = "";
            // 
            // ds_motivorenegociar
            // 
            this.ds_motivorenegociar.AccessibleDescription = null;
            this.ds_motivorenegociar.AccessibleName = null;
            resources.ApplyResources(this.ds_motivorenegociar, "ds_motivorenegociar");
            this.ds_motivorenegociar.BackColor = System.Drawing.SystemColors.Window;
            this.ds_motivorenegociar.BackgroundImage = null;
            this.ds_motivorenegociar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_motivorenegociar.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisicao, "Ds_motivorenegociar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_motivorenegociar.Font = null;
            this.ds_motivorenegociar.Name = "ds_motivorenegociar";
            this.ds_motivorenegociar.NM_Alias = "";
            this.ds_motivorenegociar.NM_Campo = "";
            this.ds_motivorenegociar.NM_CampoBusca = "";
            this.ds_motivorenegociar.NM_Param = "";
            this.ds_motivorenegociar.QTD_Zero = 0;
            this.ds_motivorenegociar.ST_AutoInc = false;
            this.ds_motivorenegociar.ST_DisableAuto = false;
            this.ds_motivorenegociar.ST_Float = false;
            this.ds_motivorenegociar.ST_Gravar = true;
            this.ds_motivorenegociar.ST_Int = false;
            this.ds_motivorenegociar.ST_LimpaCampo = true;
            this.ds_motivorenegociar.ST_NotNull = false;
            this.ds_motivorenegociar.ST_PrimaryKey = false;
            // 
            // lblMotivoRepRen
            // 
            this.lblMotivoRepRen.AccessibleDescription = null;
            this.lblMotivoRepRen.AccessibleName = null;
            resources.ApplyResources(this.lblMotivoRepRen, "lblMotivoRepRen");
            this.lblMotivoRepRen.Name = "lblMotivoRepRen";
            // 
            // qtd_aprovada
            // 
            this.qtd_aprovada.AccessibleDescription = null;
            this.qtd_aprovada.AccessibleName = null;
            resources.ApplyResources(this.qtd_aprovada, "qtd_aprovada");
            this.qtd_aprovada.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRequisicao, "Qtd_aprovada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_aprovada.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_aprovada.Name = "qtd_aprovada";
            this.qtd_aprovada.NM_Alias = "";
            this.qtd_aprovada.NM_Campo = "";
            this.qtd_aprovada.NM_Param = "";
            this.qtd_aprovada.Operador = "";
            this.qtd_aprovada.ST_AutoInc = false;
            this.qtd_aprovada.ST_DisableAuto = false;
            this.qtd_aprovada.ST_Gravar = false;
            this.qtd_aprovada.ST_LimparCampo = true;
            this.qtd_aprovada.ST_NotNull = false;
            this.qtd_aprovada.ST_PrimaryKey = false;
            this.qtd_aprovada.Leave += new System.EventHandler(this.qtd_aprovada_Leave);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // TFAprovarCompra
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
            this.Name = "TFAprovarCompra";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFAprovarCompra_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFAprovarCompra_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAprovarCompra_KeyDown);
            this.scNegociacao.Panel1.ResumeLayout(false);
            this.scNegociacao.Panel1.PerformLayout();
            this.scNegociacao.Panel2.ResumeLayout(false);
            this.scNegociacao.Panel2.PerformLayout();
            this.scNegociacao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gNegociacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNegociacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEntrega)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.tcDetalhes.ResumeLayout(false);
            this.tpNegociacoes.ResumeLayout(false);
            this.tpCotacoes.ResumeLayout(false);
            this.tpCotacoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCotacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCotacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.pAprovar.ResumeLayout(false);
            this.pAprovar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_aprovada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_aprovar;
        private System.Windows.Forms.ToolStripButton bb_reprovar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private System.Windows.Forms.BindingSource bsRequisicao;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault sigla_unidade;
        private Componentes.EditFloat quantidade;
        private Componentes.EditData dt_requisicao;
        private Componentes.EditDefault ds_observacao;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault nm_clifor_requisitante;
        private Componentes.EditDefault cd_clifor_requisitante;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.BindingSource bsNegociacao;
        private System.Windows.Forms.BindingSource bsEntrega;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.TabControl tcDetalhes;
        private System.Windows.Forms.TabPage tpNegociacoes;
        private System.Windows.Forms.SplitContainer scNegociacao;
        private Componentes.DataGridDefault gNegociacoes;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat editFloat1;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault editDefault3;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault editDefault2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblConciliacao;
        private System.Windows.Forms.TabPage tpCotacoes;
        private Componentes.PanelDados pAprovar;
        private Componentes.EditFloat qtd_aprovada;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMotivoRepRen;
        private Componentes.EditDefault ds_motivorenegociar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.ToolStripButton bb_renegociar;
        private System.Windows.Forms.BindingSource bsCotacao;
        private Componentes.DataGridDefault gCotacao;
        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_integrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdfornecedorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmfornecedorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtcotacaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_validadecotacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdatendidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitariocotadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcondpgtoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscondpgtoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdmoedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmoedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdportadorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsportadorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdtransportadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtransportadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipofreteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prazoentregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmvendedorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailvendedorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fonefaxDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrdiasvigenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idnegociacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdporcompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdmincompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarionegociadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsportadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stdepositarpagtoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrdiaspagamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foneFaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdportadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn1;
    }
}