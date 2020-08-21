namespace Compra
{
    partial class TFLanOrdemCompra
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
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanOrdemCompra));
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label cd_produtoLabel;
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_processar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.bb_faturar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.nr_pedido = new Componentes.EditDefault(this.components);
            this.pFiltros = new Componentes.PanelDados(this.components);
            this.st_cancelada = new Componentes.CheckBoxDefault(this.components);
            this.st_faturada = new Componentes.CheckBoxDefault(this.components);
            this.st_aberta = new Componentes.CheckBoxDefault(this.components);
            this.bb_portador = new System.Windows.Forms.Button();
            this.cd_portador = new Componentes.EditDefault(this.components);
            this.bb_transportadora = new System.Windows.Forms.Button();
            this.cd_transportadora = new Componentes.EditDefault(this.components);
            this.bb_fornecedor = new System.Windows.Forms.Button();
            this.cd_fornecedor = new Componentes.EditDefault(this.components);
            this.bb_moeda = new System.Windows.Forms.Button();
            this.cd_moeda = new Componentes.EditDefault(this.components);
            this.bb_condpgto = new System.Windows.Forms.Button();
            this.cd_condpgto = new Componentes.EditDefault(this.components);
            this.id_os = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.pOrdemCompra = new Componentes.PanelDados(this.components);
            this.gOrdemCompra = new Componentes.DataGridDefault(this.components);
            this.bsOrdemCompra = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaunidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlunitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_cotacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_Convertido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Siglacompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtocstrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idrequisicaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrpedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpedidoitemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcondpgtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscondpgtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdmoedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmoedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdportadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsportadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdtransportadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmtransportadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipofreteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_frete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prazoentregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            cd_produtoLabel = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pFiltros.SuspendLayout();
            this.pOrdemCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gOrdemCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdemCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
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
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_processar,
            this.bb_cancelar,
            this.BB_Buscar,
            this.bb_faturar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Name = "barraMenu";
            // 
            // bb_processar
            // 
            resources.ApplyResources(this.bb_processar, "bb_processar");
            this.bb_processar.ForeColor = System.Drawing.Color.Green;
            this.bb_processar.Name = "bb_processar";
            this.bb_processar.Click += new System.EventHandler(this.bb_processar_Click);
            // 
            // bb_cancelar
            // 
            resources.ApplyResources(this.bb_cancelar, "bb_cancelar");
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // BB_Buscar
            // 
            resources.ApplyResources(this.BB_Buscar, "BB_Buscar");
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // bb_faturar
            // 
            resources.ApplyResources(this.bb_faturar, "bb_faturar");
            this.bb_faturar.ForeColor = System.Drawing.Color.Green;
            this.bb_faturar.Name = "bb_faturar";
            this.bb_faturar.Click += new System.EventHandler(this.bb_faturar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
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
            this.tlpCentral.Controls.Add(this.pOrdemCompra, 0, 1);
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(label7);
            this.pFiltro.Controls.Add(this.nr_pedido);
            this.pFiltro.Controls.Add(this.pFiltros);
            this.pFiltro.Controls.Add(this.bb_portador);
            this.pFiltro.Controls.Add(label4);
            this.pFiltro.Controls.Add(this.cd_portador);
            this.pFiltro.Controls.Add(this.bb_transportadora);
            this.pFiltro.Controls.Add(label6);
            this.pFiltro.Controls.Add(this.cd_transportadora);
            this.pFiltro.Controls.Add(this.bb_fornecedor);
            this.pFiltro.Controls.Add(label1);
            this.pFiltro.Controls.Add(this.cd_fornecedor);
            this.pFiltro.Controls.Add(this.bb_moeda);
            this.pFiltro.Controls.Add(label2);
            this.pFiltro.Controls.Add(this.cd_moeda);
            this.pFiltro.Controls.Add(this.bb_condpgto);
            this.pFiltro.Controls.Add(label3);
            this.pFiltro.Controls.Add(this.cd_condpgto);
            this.pFiltro.Controls.Add(label5);
            this.pFiltro.Controls.Add(this.id_os);
            this.pFiltro.Controls.Add(this.bb_produto);
            this.pFiltro.Controls.Add(cd_produtoLabel);
            this.pFiltro.Controls.Add(this.cd_produto);
            this.pFiltro.Controls.Add(this.bb_empresa);
            this.pFiltro.Controls.Add(cd_empresaLabel);
            this.pFiltro.Controls.Add(this.cd_empresa);
            resources.ApplyResources(this.pFiltro, "pFiltro");
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            // 
            // nr_pedido
            // 
            this.nr_pedido.BackColor = System.Drawing.SystemColors.Window;
            this.nr_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.nr_pedido, "nr_pedido");
            this.nr_pedido.Name = "nr_pedido";
            this.nr_pedido.NM_Alias = "";
            this.nr_pedido.NM_Campo = "";
            this.nr_pedido.NM_CampoBusca = "";
            this.nr_pedido.NM_Param = "@P_CD_EMPRESA";
            this.nr_pedido.QTD_Zero = 0;
            this.nr_pedido.ST_AutoInc = false;
            this.nr_pedido.ST_DisableAuto = false;
            this.nr_pedido.ST_Float = false;
            this.nr_pedido.ST_Gravar = true;
            this.nr_pedido.ST_Int = true;
            this.nr_pedido.ST_LimpaCampo = true;
            this.nr_pedido.ST_NotNull = false;
            this.nr_pedido.ST_PrimaryKey = false;
            this.nr_pedido.TextOld = null;
            // 
            // pFiltros
            // 
            this.pFiltros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pFiltros.Controls.Add(this.st_cancelada);
            this.pFiltros.Controls.Add(this.st_faturada);
            this.pFiltros.Controls.Add(this.st_aberta);
            resources.ApplyResources(this.pFiltros, "pFiltros");
            this.pFiltros.Name = "pFiltros";
            this.pFiltros.NM_ProcDeletar = "";
            this.pFiltros.NM_ProcGravar = "";
            // 
            // st_cancelada
            // 
            resources.ApplyResources(this.st_cancelada, "st_cancelada");
            this.st_cancelada.ForeColor = System.Drawing.Color.Red;
            this.st_cancelada.Name = "st_cancelada";
            this.st_cancelada.NM_Alias = "";
            this.st_cancelada.NM_Campo = "";
            this.st_cancelada.NM_Param = "";
            this.st_cancelada.ST_Gravar = false;
            this.st_cancelada.ST_LimparCampo = true;
            this.st_cancelada.ST_NotNull = false;
            this.st_cancelada.UseVisualStyleBackColor = true;
            this.st_cancelada.Vl_False = "";
            this.st_cancelada.Vl_True = "";
            // 
            // st_faturada
            // 
            resources.ApplyResources(this.st_faturada, "st_faturada");
            this.st_faturada.ForeColor = System.Drawing.Color.Blue;
            this.st_faturada.Name = "st_faturada";
            this.st_faturada.NM_Alias = "";
            this.st_faturada.NM_Campo = "";
            this.st_faturada.NM_Param = "";
            this.st_faturada.ST_Gravar = false;
            this.st_faturada.ST_LimparCampo = true;
            this.st_faturada.ST_NotNull = false;
            this.st_faturada.UseVisualStyleBackColor = true;
            this.st_faturada.Vl_False = "";
            this.st_faturada.Vl_True = "";
            // 
            // st_aberta
            // 
            resources.ApplyResources(this.st_aberta, "st_aberta");
            this.st_aberta.Checked = true;
            this.st_aberta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.st_aberta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.st_aberta.Name = "st_aberta";
            this.st_aberta.NM_Alias = "";
            this.st_aberta.NM_Campo = "";
            this.st_aberta.NM_Param = "";
            this.st_aberta.ST_Gravar = false;
            this.st_aberta.ST_LimparCampo = true;
            this.st_aberta.ST_NotNull = false;
            this.st_aberta.UseVisualStyleBackColor = true;
            this.st_aberta.Vl_False = "";
            this.st_aberta.Vl_True = "";
            // 
            // bb_portador
            // 
            this.bb_portador.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_portador, "bb_portador");
            this.bb_portador.Name = "bb_portador";
            this.bb_portador.UseVisualStyleBackColor = false;
            this.bb_portador.Click += new System.EventHandler(this.bb_portador_Click);
            // 
            // cd_portador
            // 
            this.cd_portador.BackColor = System.Drawing.SystemColors.Window;
            this.cd_portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cd_portador, "cd_portador");
            this.cd_portador.Name = "cd_portador";
            this.cd_portador.NM_Alias = "";
            this.cd_portador.NM_Campo = "cd_portador";
            this.cd_portador.NM_CampoBusca = "cd_portador";
            this.cd_portador.NM_Param = "@P_CD_EMPRESA";
            this.cd_portador.QTD_Zero = 0;
            this.cd_portador.ST_AutoInc = false;
            this.cd_portador.ST_DisableAuto = false;
            this.cd_portador.ST_Float = false;
            this.cd_portador.ST_Gravar = true;
            this.cd_portador.ST_Int = true;
            this.cd_portador.ST_LimpaCampo = true;
            this.cd_portador.ST_NotNull = false;
            this.cd_portador.ST_PrimaryKey = false;
            this.cd_portador.TextOld = null;
            this.cd_portador.Leave += new System.EventHandler(this.cd_portador_Leave);
            // 
            // bb_transportadora
            // 
            this.bb_transportadora.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_transportadora, "bb_transportadora");
            this.bb_transportadora.Name = "bb_transportadora";
            this.bb_transportadora.UseVisualStyleBackColor = false;
            this.bb_transportadora.Click += new System.EventHandler(this.bb_transportadora_Click);
            // 
            // cd_transportadora
            // 
            this.cd_transportadora.BackColor = System.Drawing.SystemColors.Window;
            this.cd_transportadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_transportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cd_transportadora, "cd_transportadora");
            this.cd_transportadora.Name = "cd_transportadora";
            this.cd_transportadora.NM_Alias = "";
            this.cd_transportadora.NM_Campo = "cd_clifor";
            this.cd_transportadora.NM_CampoBusca = "cd_clifor";
            this.cd_transportadora.NM_Param = "@P_CD_EMPRESA";
            this.cd_transportadora.QTD_Zero = 0;
            this.cd_transportadora.ST_AutoInc = false;
            this.cd_transportadora.ST_DisableAuto = false;
            this.cd_transportadora.ST_Float = false;
            this.cd_transportadora.ST_Gravar = true;
            this.cd_transportadora.ST_Int = false;
            this.cd_transportadora.ST_LimpaCampo = true;
            this.cd_transportadora.ST_NotNull = false;
            this.cd_transportadora.ST_PrimaryKey = false;
            this.cd_transportadora.TextOld = null;
            this.cd_transportadora.Leave += new System.EventHandler(this.cd_transportadora_Leave);
            // 
            // bb_fornecedor
            // 
            this.bb_fornecedor.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_fornecedor, "bb_fornecedor");
            this.bb_fornecedor.Name = "bb_fornecedor";
            this.bb_fornecedor.UseVisualStyleBackColor = false;
            this.bb_fornecedor.Click += new System.EventHandler(this.bb_fornecedor_Click);
            // 
            // cd_fornecedor
            // 
            this.cd_fornecedor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_fornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cd_fornecedor, "cd_fornecedor");
            this.cd_fornecedor.Name = "cd_fornecedor";
            this.cd_fornecedor.NM_Alias = "";
            this.cd_fornecedor.NM_Campo = "cd_clifor";
            this.cd_fornecedor.NM_CampoBusca = "cd_clifor";
            this.cd_fornecedor.NM_Param = "@P_CD_EMPRESA";
            this.cd_fornecedor.QTD_Zero = 0;
            this.cd_fornecedor.ST_AutoInc = false;
            this.cd_fornecedor.ST_DisableAuto = false;
            this.cd_fornecedor.ST_Float = false;
            this.cd_fornecedor.ST_Gravar = true;
            this.cd_fornecedor.ST_Int = true;
            this.cd_fornecedor.ST_LimpaCampo = true;
            this.cd_fornecedor.ST_NotNull = false;
            this.cd_fornecedor.ST_PrimaryKey = false;
            this.cd_fornecedor.TextOld = null;
            this.cd_fornecedor.Leave += new System.EventHandler(this.cd_fornecedor_Leave);
            // 
            // bb_moeda
            // 
            this.bb_moeda.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_moeda, "bb_moeda");
            this.bb_moeda.Name = "bb_moeda";
            this.bb_moeda.UseVisualStyleBackColor = false;
            this.bb_moeda.Click += new System.EventHandler(this.bb_moeda_Click);
            // 
            // cd_moeda
            // 
            this.cd_moeda.BackColor = System.Drawing.SystemColors.Window;
            this.cd_moeda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cd_moeda, "cd_moeda");
            this.cd_moeda.Name = "cd_moeda";
            this.cd_moeda.NM_Alias = "";
            this.cd_moeda.NM_Campo = "cd_moeda";
            this.cd_moeda.NM_CampoBusca = "cd_moeda";
            this.cd_moeda.NM_Param = "@P_CD_PRODUTO";
            this.cd_moeda.QTD_Zero = 0;
            this.cd_moeda.ST_AutoInc = false;
            this.cd_moeda.ST_DisableAuto = false;
            this.cd_moeda.ST_Float = false;
            this.cd_moeda.ST_Gravar = true;
            this.cd_moeda.ST_Int = false;
            this.cd_moeda.ST_LimpaCampo = true;
            this.cd_moeda.ST_NotNull = false;
            this.cd_moeda.ST_PrimaryKey = false;
            this.cd_moeda.TextOld = null;
            this.cd_moeda.Leave += new System.EventHandler(this.cd_moeda_Leave);
            // 
            // bb_condpgto
            // 
            this.bb_condpgto.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_condpgto, "bb_condpgto");
            this.bb_condpgto.Name = "bb_condpgto";
            this.bb_condpgto.UseVisualStyleBackColor = false;
            this.bb_condpgto.Click += new System.EventHandler(this.bb_condpgto_Click);
            // 
            // cd_condpgto
            // 
            this.cd_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cd_condpgto, "cd_condpgto");
            this.cd_condpgto.Name = "cd_condpgto";
            this.cd_condpgto.NM_Alias = "";
            this.cd_condpgto.NM_Campo = "cd_condpgto";
            this.cd_condpgto.NM_CampoBusca = "cd_condpgto";
            this.cd_condpgto.NM_Param = "@P_CD_EMPRESA";
            this.cd_condpgto.QTD_Zero = 0;
            this.cd_condpgto.ST_AutoInc = false;
            this.cd_condpgto.ST_DisableAuto = false;
            this.cd_condpgto.ST_Float = false;
            this.cd_condpgto.ST_Gravar = true;
            this.cd_condpgto.ST_Int = false;
            this.cd_condpgto.ST_LimpaCampo = true;
            this.cd_condpgto.ST_NotNull = false;
            this.cd_condpgto.ST_PrimaryKey = false;
            this.cd_condpgto.TextOld = null;
            this.cd_condpgto.Leave += new System.EventHandler(this.cd_condpgto_Leave);
            // 
            // id_os
            // 
            this.id_os.BackColor = System.Drawing.SystemColors.Window;
            this.id_os.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_os.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.id_os, "id_os");
            this.id_os.Name = "id_os";
            this.id_os.NM_Alias = "";
            this.id_os.NM_Campo = "cd_empresa";
            this.id_os.NM_CampoBusca = "cd_empresa";
            this.id_os.NM_Param = "@P_CD_EMPRESA";
            this.id_os.QTD_Zero = 0;
            this.id_os.ST_AutoInc = false;
            this.id_os.ST_DisableAuto = false;
            this.id_os.ST_Float = false;
            this.id_os.ST_Gravar = true;
            this.id_os.ST_Int = true;
            this.id_os.ST_LimpaCampo = true;
            this.id_os.ST_NotNull = false;
            this.id_os.ST_PrimaryKey = false;
            this.id_os.TextOld = null;
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_produto, "bb_produto");
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
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
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_empresa, "bb_empresa");
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
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
            // pOrdemCompra
            // 
            this.pOrdemCompra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pOrdemCompra.Controls.Add(this.gOrdemCompra);
            this.pOrdemCompra.Controls.Add(this.bindingNavigator1);
            resources.ApplyResources(this.pOrdemCompra, "pOrdemCompra");
            this.pOrdemCompra.Name = "pOrdemCompra";
            this.pOrdemCompra.NM_ProcDeletar = "";
            this.pOrdemCompra.NM_ProcGravar = "";
            // 
            // gOrdemCompra
            // 
            this.gOrdemCompra.AllowUserToAddRows = false;
            this.gOrdemCompra.AllowUserToDeleteRows = false;
            this.gOrdemCompra.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gOrdemCompra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gOrdemCompra.AutoGenerateColumns = false;
            this.gOrdemCompra.BackgroundColor = System.Drawing.Color.LightGray;
            this.gOrdemCompra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gOrdemCompra.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gOrdemCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gOrdemCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gOrdemCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewTextBoxColumn,
            this.idocDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.siglaunidadeDataGridViewTextBoxColumn,
            this.vlunitarioDataGridViewTextBoxColumn,
            this.siglaDataGridViewTextBoxColumn,
            this.Vl_subtotal,
            this.Vl_cotacao,
            this.Vl_Convertido,
            this.Siglacompra,
            this.dtocstrDataGridViewTextBoxColumn,
            this.idrequisicaostrDataGridViewTextBoxColumn,
            this.nrpedidoDataGridViewTextBoxColumn,
            this.idpedidoitemDataGridViewTextBoxColumn,
            this.cdfornecedorDataGridViewTextBoxColumn,
            this.nmfornecedorDataGridViewTextBoxColumn,
            this.cdcondpgtoDataGridViewTextBoxColumn,
            this.dscondpgtoDataGridViewTextBoxColumn,
            this.cdmoedaDataGridViewTextBoxColumn,
            this.dsmoedaDataGridViewTextBoxColumn,
            this.cdportadorDataGridViewTextBoxColumn,
            this.dsportadorDataGridViewTextBoxColumn,
            this.cdtransportadoraDataGridViewTextBoxColumn,
            this.nmtransportadoraDataGridViewTextBoxColumn,
            this.tipofreteDataGridViewTextBoxColumn,
            this.Vl_frete,
            this.prazoentregaDataGridViewTextBoxColumn});
            this.gOrdemCompra.DataSource = this.bsOrdemCompra;
            resources.ApplyResources(this.gOrdemCompra, "gOrdemCompra");
            this.gOrdemCompra.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gOrdemCompra.Name = "gOrdemCompra";
            this.gOrdemCompra.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gOrdemCompra.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gOrdemCompra.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gOrdemCompra_CellFormatting);
            // 
            // bsOrdemCompra
            // 
            this.bsOrdemCompra.DataSource = typeof(CamadaDados.Compra.Lancamento.TList_OrdemCompra);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsOrdemCompra;
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
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            resources.ApplyResources(this.statusDataGridViewTextBoxColumn, "statusDataGridViewTextBoxColumn");
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idocDataGridViewTextBoxColumn
            // 
            this.idocDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idocDataGridViewTextBoxColumn.DataPropertyName = "Id_oc";
            resources.ApplyResources(this.idocDataGridViewTextBoxColumn, "idocDataGridViewTextBoxColumn");
            this.idocDataGridViewTextBoxColumn.Name = "idocDataGridViewTextBoxColumn";
            this.idocDataGridViewTextBoxColumn.ReadOnly = true;
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
            // siglaunidadeDataGridViewTextBoxColumn
            // 
            this.siglaunidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaunidadeDataGridViewTextBoxColumn.DataPropertyName = "Sigla_unidade";
            resources.ApplyResources(this.siglaunidadeDataGridViewTextBoxColumn, "siglaunidadeDataGridViewTextBoxColumn");
            this.siglaunidadeDataGridViewTextBoxColumn.Name = "siglaunidadeDataGridViewTextBoxColumn";
            this.siglaunidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlunitarioDataGridViewTextBoxColumn
            // 
            this.vlunitarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlunitarioDataGridViewTextBoxColumn.DataPropertyName = "Vl_unitario";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vlunitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.vlunitarioDataGridViewTextBoxColumn, "vlunitarioDataGridViewTextBoxColumn");
            this.vlunitarioDataGridViewTextBoxColumn.Name = "vlunitarioDataGridViewTextBoxColumn";
            this.vlunitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siglaDataGridViewTextBoxColumn
            // 
            this.siglaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaDataGridViewTextBoxColumn.DataPropertyName = "Sigla";
            resources.ApplyResources(this.siglaDataGridViewTextBoxColumn, "siglaDataGridViewTextBoxColumn");
            this.siglaDataGridViewTextBoxColumn.Name = "siglaDataGridViewTextBoxColumn";
            this.siglaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Vl_subtotal
            // 
            this.Vl_subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_subtotal.DataPropertyName = "Vl_subtotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.Vl_subtotal.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.Vl_subtotal, "Vl_subtotal");
            this.Vl_subtotal.Name = "Vl_subtotal";
            this.Vl_subtotal.ReadOnly = true;
            // 
            // Vl_cotacao
            // 
            this.Vl_cotacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_cotacao.DataPropertyName = "Vl_cotacao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.Vl_cotacao.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.Vl_cotacao, "Vl_cotacao");
            this.Vl_cotacao.Name = "Vl_cotacao";
            this.Vl_cotacao.ReadOnly = true;
            // 
            // Vl_Convertido
            // 
            this.Vl_Convertido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_Convertido.DataPropertyName = "Vl_Convertido";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.Vl_Convertido.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.Vl_Convertido, "Vl_Convertido");
            this.Vl_Convertido.Name = "Vl_Convertido";
            this.Vl_Convertido.ReadOnly = true;
            // 
            // Siglacompra
            // 
            this.Siglacompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Siglacompra.DataPropertyName = "Siglacompra";
            resources.ApplyResources(this.Siglacompra, "Siglacompra");
            this.Siglacompra.Name = "Siglacompra";
            this.Siglacompra.ReadOnly = true;
            // 
            // dtocstrDataGridViewTextBoxColumn
            // 
            this.dtocstrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtocstrDataGridViewTextBoxColumn.DataPropertyName = "Dt_ocstr";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.dtocstrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.dtocstrDataGridViewTextBoxColumn, "dtocstrDataGridViewTextBoxColumn");
            this.dtocstrDataGridViewTextBoxColumn.Name = "dtocstrDataGridViewTextBoxColumn";
            this.dtocstrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idrequisicaostrDataGridViewTextBoxColumn
            // 
            this.idrequisicaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idrequisicaostrDataGridViewTextBoxColumn.DataPropertyName = "Id_requisicaostr";
            resources.ApplyResources(this.idrequisicaostrDataGridViewTextBoxColumn, "idrequisicaostrDataGridViewTextBoxColumn");
            this.idrequisicaostrDataGridViewTextBoxColumn.Name = "idrequisicaostrDataGridViewTextBoxColumn";
            this.idrequisicaostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrpedidoDataGridViewTextBoxColumn
            // 
            this.nrpedidoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrpedidoDataGridViewTextBoxColumn.DataPropertyName = "Nr_pedido";
            resources.ApplyResources(this.nrpedidoDataGridViewTextBoxColumn, "nrpedidoDataGridViewTextBoxColumn");
            this.nrpedidoDataGridViewTextBoxColumn.Name = "nrpedidoDataGridViewTextBoxColumn";
            this.nrpedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idpedidoitemDataGridViewTextBoxColumn
            // 
            this.idpedidoitemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idpedidoitemDataGridViewTextBoxColumn.DataPropertyName = "Id_pedidoitem";
            resources.ApplyResources(this.idpedidoitemDataGridViewTextBoxColumn, "idpedidoitemDataGridViewTextBoxColumn");
            this.idpedidoitemDataGridViewTextBoxColumn.Name = "idpedidoitemDataGridViewTextBoxColumn";
            this.idpedidoitemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdfornecedorDataGridViewTextBoxColumn
            // 
            this.cdfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Cd_fornecedor";
            resources.ApplyResources(this.cdfornecedorDataGridViewTextBoxColumn, "cdfornecedorDataGridViewTextBoxColumn");
            this.cdfornecedorDataGridViewTextBoxColumn.Name = "cdfornecedorDataGridViewTextBoxColumn";
            this.cdfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmfornecedorDataGridViewTextBoxColumn
            // 
            this.nmfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Nm_fornecedor";
            resources.ApplyResources(this.nmfornecedorDataGridViewTextBoxColumn, "nmfornecedorDataGridViewTextBoxColumn");
            this.nmfornecedorDataGridViewTextBoxColumn.Name = "nmfornecedorDataGridViewTextBoxColumn";
            this.nmfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdcondpgtoDataGridViewTextBoxColumn
            // 
            this.cdcondpgtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcondpgtoDataGridViewTextBoxColumn.DataPropertyName = "Cd_condpgto";
            resources.ApplyResources(this.cdcondpgtoDataGridViewTextBoxColumn, "cdcondpgtoDataGridViewTextBoxColumn");
            this.cdcondpgtoDataGridViewTextBoxColumn.Name = "cdcondpgtoDataGridViewTextBoxColumn";
            this.cdcondpgtoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dscondpgtoDataGridViewTextBoxColumn
            // 
            this.dscondpgtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscondpgtoDataGridViewTextBoxColumn.DataPropertyName = "Ds_condpgto";
            resources.ApplyResources(this.dscondpgtoDataGridViewTextBoxColumn, "dscondpgtoDataGridViewTextBoxColumn");
            this.dscondpgtoDataGridViewTextBoxColumn.Name = "dscondpgtoDataGridViewTextBoxColumn";
            this.dscondpgtoDataGridViewTextBoxColumn.ReadOnly = true;
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
            // cdportadorDataGridViewTextBoxColumn
            // 
            this.cdportadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdportadorDataGridViewTextBoxColumn.DataPropertyName = "Cd_portador";
            resources.ApplyResources(this.cdportadorDataGridViewTextBoxColumn, "cdportadorDataGridViewTextBoxColumn");
            this.cdportadorDataGridViewTextBoxColumn.Name = "cdportadorDataGridViewTextBoxColumn";
            this.cdportadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsportadorDataGridViewTextBoxColumn
            // 
            this.dsportadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsportadorDataGridViewTextBoxColumn.DataPropertyName = "Ds_portador";
            resources.ApplyResources(this.dsportadorDataGridViewTextBoxColumn, "dsportadorDataGridViewTextBoxColumn");
            this.dsportadorDataGridViewTextBoxColumn.Name = "dsportadorDataGridViewTextBoxColumn";
            this.dsportadorDataGridViewTextBoxColumn.ReadOnly = true;
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
            // Vl_frete
            // 
            this.Vl_frete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_frete.DataPropertyName = "Vl_frete";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0";
            this.Vl_frete.DefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(this.Vl_frete, "Vl_frete");
            this.Vl_frete.Name = "Vl_frete";
            this.Vl_frete.ReadOnly = true;
            // 
            // prazoentregaDataGridViewTextBoxColumn
            // 
            this.prazoentregaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.prazoentregaDataGridViewTextBoxColumn.DataPropertyName = "Prazo_entrega";
            resources.ApplyResources(this.prazoentregaDataGridViewTextBoxColumn, "prazoentregaDataGridViewTextBoxColumn");
            this.prazoentregaDataGridViewTextBoxColumn.Name = "prazoentregaDataGridViewTextBoxColumn";
            this.prazoentregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFLanOrdemCompra
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFLanOrdemCompra";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanOrdemCompra_FormClosing);
            this.Load += new System.EventHandler(this.TFLanOrdemCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanOrdemCompra_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pFiltros.ResumeLayout(false);
            this.pFiltros.PerformLayout();
            this.pOrdemCompra.ResumeLayout(false);
            this.pOrdemCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gOrdemCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdemCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_processar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.PanelDados pOrdemCompra;
        private Componentes.DataGridDefault gOrdemCompra;
        private System.Windows.Forms.BindingSource bsOrdemCompra;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Button bb_portador;
        private Componentes.EditDefault cd_portador;
        private System.Windows.Forms.Button bb_transportadora;
        private Componentes.EditDefault cd_transportadora;
        private System.Windows.Forms.Button bb_fornecedor;
        private Componentes.EditDefault cd_fornecedor;
        private System.Windows.Forms.Button bb_moeda;
        private Componentes.EditDefault cd_moeda;
        private System.Windows.Forms.Button bb_condpgto;
        private Componentes.EditDefault cd_condpgto;
        private Componentes.EditDefault id_os;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.PanelDados pFiltros;
        private Componentes.CheckBoxDefault st_cancelada;
        private Componentes.CheckBoxDefault st_faturada;
        private Componentes.CheckBoxDefault st_aberta;
        private System.Windows.Forms.ToolStripButton bb_faturar;
        private Componentes.EditDefault nr_pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_cotacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_Convertido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Siglacompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtocstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idrequisicaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrpedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpedidoitemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdmoedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmoedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdportadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsportadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdtransportadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtransportadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipofreteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_frete;
        private System.Windows.Forms.DataGridViewTextBoxColumn prazoentregaDataGridViewTextBoxColumn;
    }
}