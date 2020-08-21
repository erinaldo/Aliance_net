namespace Faturamento.Cadastros
{
    partial class TFCadCFGPedidoFiscal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCFGPedidoFiscal));
            this.gCadCFGPedidoFiscal = new Componentes.DataGridDefault(this.components);
            this.Tipo_fiscal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFGPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpmovimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NrSérieNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CdMovimentaçãoNorma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMINormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCFGPedidoFiscal = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.DS_TipoPedido = new Componentes.EditDefault(this.components);
            this.BB_CFG_Pedido = new System.Windows.Forms.Button();
            this.CFG_Pedido = new Componentes.EditDefault(this.components);
            this.DS_CMI = new Componentes.EditDefault(this.components);
            this.BB_CMI = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.CD_CMI = new Componentes.EditDefault(this.components);
            this.DS_Movto = new Componentes.EditDefault(this.components);
            this.BB_Movto = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.CD_Movto = new Componentes.EditDefault(this.components);
            this.DS_Serie = new Componentes.EditDefault(this.components);
            this.BB_Serie = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.Nr_Serie = new Componentes.EditDefault(this.components);
            this.TP_Movimento = new Componentes.EditDefault(this.components);
            this.Cbx_TP_Fiscal = new Componentes.ComboBoxDefault(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.BN_CFGPedidoFiscal = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.st_servico = new Componentes.CheckBoxDefault(this.components);
            this.ds_modelo = new Componentes.EditDefault(this.components);
            this.bb_modelo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_modelo = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadCFGPedidoFiscal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCFGPedidoFiscal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CFGPedidoFiscal)).BeginInit();
            this.BN_CFGPedidoFiscal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ds_modelo);
            this.pDados.Controls.Add(this.bb_modelo);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_modelo);
            this.pDados.Controls.Add(this.st_servico);
            this.pDados.Controls.Add(this.Cbx_TP_Fiscal);
            this.pDados.Controls.Add(this.label34);
            this.pDados.Controls.Add(this.TP_Movimento);
            this.pDados.Controls.Add(this.DS_CMI);
            this.pDados.Controls.Add(this.BB_CMI);
            this.pDados.Controls.Add(this.label47);
            this.pDados.Controls.Add(this.CD_CMI);
            this.pDados.Controls.Add(this.DS_Movto);
            this.pDados.Controls.Add(this.BB_Movto);
            this.pDados.Controls.Add(this.label46);
            this.pDados.Controls.Add(this.CD_Movto);
            this.pDados.Controls.Add(this.DS_Serie);
            this.pDados.Controls.Add(this.BB_Serie);
            this.pDados.Controls.Add(this.label45);
            this.pDados.Controls.Add(this.Nr_Serie);
            this.pDados.Controls.Add(this.DS_TipoPedido);
            this.pDados.Controls.Add(this.BB_CFG_Pedido);
            this.pDados.Controls.Add(this.CFG_Pedido);
            this.pDados.Controls.Add(this.label1);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadCFGPedidoFiscal);
            this.tpPadrao.Controls.Add(this.BN_CFGPedidoFiscal);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CFGPedidoFiscal, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadCFGPedidoFiscal, 0);
            // 
            // gCadCFGPedidoFiscal
            // 
            this.gCadCFGPedidoFiscal.AllowUserToAddRows = false;
            this.gCadCFGPedidoFiscal.AllowUserToDeleteRows = false;
            this.gCadCFGPedidoFiscal.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadCFGPedidoFiscal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCadCFGPedidoFiscal.AutoGenerateColumns = false;
            this.gCadCFGPedidoFiscal.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadCFGPedidoFiscal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadCFGPedidoFiscal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadCFGPedidoFiscal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCadCFGPedidoFiscal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadCFGPedidoFiscal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo_fiscal,
            this.CFGPedido,
            this.TipoPedido,
            this.tpmovimentoDataGridViewTextBoxColumn,
            this.NrSérieNormal,
            this.CdMovimentaçãoNorma,
            this.CMINormal});
            this.gCadCFGPedidoFiscal.DataSource = this.bsCFGPedidoFiscal;
            resources.ApplyResources(this.gCadCFGPedidoFiscal, "gCadCFGPedidoFiscal");
            this.gCadCFGPedidoFiscal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadCFGPedidoFiscal.Name = "gCadCFGPedidoFiscal";
            this.gCadCFGPedidoFiscal.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadCFGPedidoFiscal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gCadCFGPedidoFiscal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gCadCFGPedidoFiscal.TabStop = false;
            // 
            // Tipo_fiscal
            // 
            this.Tipo_fiscal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_fiscal.DataPropertyName = "Tipo_fiscal";
            resources.ApplyResources(this.Tipo_fiscal, "Tipo_fiscal");
            this.Tipo_fiscal.Name = "Tipo_fiscal";
            this.Tipo_fiscal.ReadOnly = true;
            // 
            // CFGPedido
            // 
            this.CFGPedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CFGPedido.DataPropertyName = "Cfg_pedido";
            resources.ApplyResources(this.CFGPedido, "CFGPedido");
            this.CFGPedido.Name = "CFGPedido";
            this.CFGPedido.ReadOnly = true;
            // 
            // TipoPedido
            // 
            this.TipoPedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TipoPedido.DataPropertyName = "Ds_tipopedido";
            resources.ApplyResources(this.TipoPedido, "TipoPedido");
            this.TipoPedido.Name = "TipoPedido";
            this.TipoPedido.ReadOnly = true;
            // 
            // tpmovimentoDataGridViewTextBoxColumn
            // 
            this.tpmovimentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpmovimentoDataGridViewTextBoxColumn.DataPropertyName = "Tp_movimento";
            resources.ApplyResources(this.tpmovimentoDataGridViewTextBoxColumn, "tpmovimentoDataGridViewTextBoxColumn");
            this.tpmovimentoDataGridViewTextBoxColumn.Name = "tpmovimentoDataGridViewTextBoxColumn";
            this.tpmovimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NrSérieNormal
            // 
            this.NrSérieNormal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NrSérieNormal.DataPropertyName = "Ds_serienf";
            resources.ApplyResources(this.NrSérieNormal, "NrSérieNormal");
            this.NrSérieNormal.Name = "NrSérieNormal";
            this.NrSérieNormal.ReadOnly = true;
            // 
            // CdMovimentaçãoNorma
            // 
            this.CdMovimentaçãoNorma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CdMovimentaçãoNorma.DataPropertyName = "Ds_movimentacao";
            resources.ApplyResources(this.CdMovimentaçãoNorma, "CdMovimentaçãoNorma");
            this.CdMovimentaçãoNorma.Name = "CdMovimentaçãoNorma";
            this.CdMovimentaçãoNorma.ReadOnly = true;
            // 
            // CMINormal
            // 
            this.CMINormal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CMINormal.DataPropertyName = "Ds_cmi";
            resources.ApplyResources(this.CMINormal, "CMINormal");
            this.CMINormal.Name = "CMINormal";
            this.CMINormal.ReadOnly = true;
            // 
            // bsCFGPedidoFiscal
            // 
            this.bsCFGPedidoFiscal.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal);
            this.bsCFGPedidoFiscal.PositionChanged += new System.EventHandler(this.bsCFGPedidoFiscal_PositionChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DS_TipoPedido
            // 
            this.DS_TipoPedido.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TipoPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_TipoPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TipoPedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGPedidoFiscal, "Ds_tipopedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_TipoPedido, "DS_TipoPedido");
            this.DS_TipoPedido.Name = "DS_TipoPedido";
            this.DS_TipoPedido.NM_Alias = "";
            this.DS_TipoPedido.NM_Campo = "DS_TipoPedido";
            this.DS_TipoPedido.NM_CampoBusca = "DS_TipoPedido";
            this.DS_TipoPedido.NM_Param = "@P_DS_TIPOPEDIDO";
            this.DS_TipoPedido.QTD_Zero = 0;
            this.DS_TipoPedido.ST_AutoInc = false;
            this.DS_TipoPedido.ST_DisableAuto = false;
            this.DS_TipoPedido.ST_Float = false;
            this.DS_TipoPedido.ST_Gravar = false;
            this.DS_TipoPedido.ST_Int = false;
            this.DS_TipoPedido.ST_LimpaCampo = true;
            this.DS_TipoPedido.ST_NotNull = false;
            this.DS_TipoPedido.ST_PrimaryKey = false;
            this.DS_TipoPedido.TextOld = null;
            // 
            // BB_CFG_Pedido
            // 
            resources.ApplyResources(this.BB_CFG_Pedido, "BB_CFG_Pedido");
            this.BB_CFG_Pedido.Name = "BB_CFG_Pedido";
            this.BB_CFG_Pedido.UseVisualStyleBackColor = true;
            this.BB_CFG_Pedido.Click += new System.EventHandler(this.BB_CFG_Pedido_Click);
            // 
            // CFG_Pedido
            // 
            this.CFG_Pedido.BackColor = System.Drawing.SystemColors.Window;
            this.CFG_Pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CFG_Pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CFG_Pedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGPedidoFiscal, "Cfg_pedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CFG_Pedido, "CFG_Pedido");
            this.CFG_Pedido.Name = "CFG_Pedido";
            this.CFG_Pedido.NM_Alias = "a";
            this.CFG_Pedido.NM_Campo = "CFG_Pedido";
            this.CFG_Pedido.NM_CampoBusca = "CFG_Pedido";
            this.CFG_Pedido.NM_Param = "@P_CFG_PEDIDO";
            this.CFG_Pedido.QTD_Zero = 0;
            this.CFG_Pedido.ST_AutoInc = false;
            this.CFG_Pedido.ST_DisableAuto = false;
            this.CFG_Pedido.ST_Float = false;
            this.CFG_Pedido.ST_Gravar = true;
            this.CFG_Pedido.ST_Int = true;
            this.CFG_Pedido.ST_LimpaCampo = true;
            this.CFG_Pedido.ST_NotNull = true;
            this.CFG_Pedido.ST_PrimaryKey = false;
            this.CFG_Pedido.TextOld = null;
            this.CFG_Pedido.Leave += new System.EventHandler(this.CFG_Pedido_Leave);
            this.CFG_Pedido.Enter += new System.EventHandler(this.CFG_Pedido_Enter);
            // 
            // DS_CMI
            // 
            this.DS_CMI.BackColor = System.Drawing.SystemColors.Window;
            this.DS_CMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_CMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_CMI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGPedidoFiscal, "Ds_cmi", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_CMI, "DS_CMI");
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
            this.DS_CMI.TextOld = null;
            // 
            // BB_CMI
            // 
            resources.ApplyResources(this.BB_CMI, "BB_CMI");
            this.BB_CMI.Name = "BB_CMI";
            this.BB_CMI.UseVisualStyleBackColor = true;
            this.BB_CMI.Click += new System.EventHandler(this.BB_CMI_Click);
            // 
            // label47
            // 
            resources.ApplyResources(this.label47, "label47");
            this.label47.Name = "label47";
            // 
            // CD_CMI
            // 
            this.CD_CMI.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CMI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGPedidoFiscal, "Cd_cmistring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_CMI, "CD_CMI");
            this.CD_CMI.Name = "CD_CMI";
            this.CD_CMI.NM_Alias = "a";
            this.CD_CMI.NM_Campo = "CD_CMI";
            this.CD_CMI.NM_CampoBusca = "CD_CMI";
            this.CD_CMI.NM_Param = "@P_CD_CMI";
            this.CD_CMI.QTD_Zero = 0;
            this.CD_CMI.ST_AutoInc = false;
            this.CD_CMI.ST_DisableAuto = false;
            this.CD_CMI.ST_Float = false;
            this.CD_CMI.ST_Gravar = true;
            this.CD_CMI.ST_Int = true;
            this.CD_CMI.ST_LimpaCampo = true;
            this.CD_CMI.ST_NotNull = true;
            this.CD_CMI.ST_PrimaryKey = false;
            this.CD_CMI.TextOld = null;
            this.CD_CMI.Leave += new System.EventHandler(this.CD_CMI_Leave);
            // 
            // DS_Movto
            // 
            this.DS_Movto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Movto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Movto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Movto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGPedidoFiscal, "Ds_movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Movto, "DS_Movto");
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
            this.DS_Movto.TextOld = null;
            // 
            // BB_Movto
            // 
            resources.ApplyResources(this.BB_Movto, "BB_Movto");
            this.BB_Movto.Name = "BB_Movto";
            this.BB_Movto.UseVisualStyleBackColor = true;
            this.BB_Movto.Click += new System.EventHandler(this.BB_Movto_Click);
            // 
            // label46
            // 
            resources.ApplyResources(this.label46, "label46");
            this.label46.Name = "label46";
            // 
            // CD_Movto
            // 
            this.CD_Movto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Movto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Movto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Movto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGPedidoFiscal, "Cd_movtostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Movto, "CD_Movto");
            this.CD_Movto.Name = "CD_Movto";
            this.CD_Movto.NM_Alias = "a";
            this.CD_Movto.NM_Campo = "CD_Movto";
            this.CD_Movto.NM_CampoBusca = "CD_Movimentacao";
            this.CD_Movto.NM_Param = "@P_CD_MOVTO";
            this.CD_Movto.QTD_Zero = 0;
            this.CD_Movto.ST_AutoInc = false;
            this.CD_Movto.ST_DisableAuto = false;
            this.CD_Movto.ST_Float = false;
            this.CD_Movto.ST_Gravar = true;
            this.CD_Movto.ST_Int = true;
            this.CD_Movto.ST_LimpaCampo = true;
            this.CD_Movto.ST_NotNull = true;
            this.CD_Movto.ST_PrimaryKey = false;
            this.CD_Movto.TextOld = null;
            this.CD_Movto.TextChanged += new System.EventHandler(this.CD_Movto_TextChanged);
            this.CD_Movto.Leave += new System.EventHandler(this.CD_Movto_Leave);
            this.CD_Movto.Enter += new System.EventHandler(this.CD_Movto_Enter);
            // 
            // DS_Serie
            // 
            this.DS_Serie.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Serie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGPedidoFiscal, "Ds_serienf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Serie, "DS_Serie");
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
            this.DS_Serie.TextOld = null;
            // 
            // BB_Serie
            // 
            resources.ApplyResources(this.BB_Serie, "BB_Serie");
            this.BB_Serie.Name = "BB_Serie";
            this.BB_Serie.UseVisualStyleBackColor = true;
            this.BB_Serie.Click += new System.EventHandler(this.BB_Serie_Click);
            // 
            // label45
            // 
            resources.ApplyResources(this.label45, "label45");
            this.label45.Name = "label45";
            // 
            // Nr_Serie
            // 
            this.Nr_Serie.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_Serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_Serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_Serie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGPedidoFiscal, "Nr_serie", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Nr_Serie, "Nr_Serie");
            this.Nr_Serie.Name = "Nr_Serie";
            this.Nr_Serie.NM_Alias = "a";
            this.Nr_Serie.NM_Campo = "Nr_Serie";
            this.Nr_Serie.NM_CampoBusca = "Nr_Serie";
            this.Nr_Serie.NM_Param = "@P_NR_SERIE";
            this.Nr_Serie.QTD_Zero = 0;
            this.Nr_Serie.ST_AutoInc = false;
            this.Nr_Serie.ST_DisableAuto = false;
            this.Nr_Serie.ST_Float = false;
            this.Nr_Serie.ST_Gravar = true;
            this.Nr_Serie.ST_Int = true;
            this.Nr_Serie.ST_LimpaCampo = true;
            this.Nr_Serie.ST_NotNull = true;
            this.Nr_Serie.ST_PrimaryKey = false;
            this.Nr_Serie.TextOld = null;
            this.Nr_Serie.Leave += new System.EventHandler(this.Nr_Serie_Leave);
            // 
            // TP_Movimento
            // 
            this.TP_Movimento.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Movimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Movimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Movimento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGPedidoFiscal, "Tp_movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.TP_Movimento, "TP_Movimento");
            this.TP_Movimento.Name = "TP_Movimento";
            this.TP_Movimento.NM_Alias = "";
            this.TP_Movimento.NM_Campo = "TP_Movimento";
            this.TP_Movimento.NM_CampoBusca = "TP_Movimento";
            this.TP_Movimento.NM_Param = "@P_TP_MOVIMENTO";
            this.TP_Movimento.QTD_Zero = 0;
            this.TP_Movimento.ST_AutoInc = false;
            this.TP_Movimento.ST_DisableAuto = false;
            this.TP_Movimento.ST_Float = false;
            this.TP_Movimento.ST_Gravar = false;
            this.TP_Movimento.ST_Int = false;
            this.TP_Movimento.ST_LimpaCampo = true;
            this.TP_Movimento.ST_NotNull = false;
            this.TP_Movimento.ST_PrimaryKey = false;
            this.TP_Movimento.TextOld = null;
            // 
            // Cbx_TP_Fiscal
            // 
            this.Cbx_TP_Fiscal.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCFGPedidoFiscal, "Tp_fiscal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Cbx_TP_Fiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.Cbx_TP_Fiscal, "Cbx_TP_Fiscal");
            this.Cbx_TP_Fiscal.FormattingEnabled = true;
            this.Cbx_TP_Fiscal.Items.AddRange(new object[] {
            resources.GetString("Cbx_TP_Fiscal.Items"),
            resources.GetString("Cbx_TP_Fiscal.Items1"),
            resources.GetString("Cbx_TP_Fiscal.Items2"),
            resources.GetString("Cbx_TP_Fiscal.Items3")});
            this.Cbx_TP_Fiscal.Name = "Cbx_TP_Fiscal";
            this.Cbx_TP_Fiscal.NM_Alias = "";
            this.Cbx_TP_Fiscal.NM_Campo = "";
            this.Cbx_TP_Fiscal.NM_Param = "";
            this.Cbx_TP_Fiscal.ST_Gravar = true;
            this.Cbx_TP_Fiscal.ST_LimparCampo = true;
            this.Cbx_TP_Fiscal.ST_NotNull = true;
            this.Cbx_TP_Fiscal.Leave += new System.EventHandler(this.Cbx_TP_Fiscal_Leave);
            this.Cbx_TP_Fiscal.Enter += new System.EventHandler(this.Cbx_TP_Fiscal_Enter);
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // BN_CFGPedidoFiscal
            // 
            this.BN_CFGPedidoFiscal.AddNewItem = null;
            this.BN_CFGPedidoFiscal.BindingSource = this.bsCFGPedidoFiscal;
            this.BN_CFGPedidoFiscal.CountItem = this.bindingNavigatorCountItem;
            this.BN_CFGPedidoFiscal.CountItemFormat = "de {0}";
            this.BN_CFGPedidoFiscal.DeleteItem = null;
            resources.ApplyResources(this.BN_CFGPedidoFiscal, "BN_CFGPedidoFiscal");
            this.BN_CFGPedidoFiscal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CFGPedidoFiscal.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CFGPedidoFiscal.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CFGPedidoFiscal.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CFGPedidoFiscal.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CFGPedidoFiscal.Name = "BN_CFGPedidoFiscal";
            this.BN_CFGPedidoFiscal.PositionItem = this.bindingNavigatorPositionItem;
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
            // st_servico
            // 
            resources.ApplyResources(this.st_servico, "st_servico");
            this.st_servico.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCFGPedidoFiscal, "St_servico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_servico.Name = "st_servico";
            this.st_servico.NM_Alias = "";
            this.st_servico.NM_Campo = "";
            this.st_servico.NM_Param = "";
            this.st_servico.ST_Gravar = false;
            this.st_servico.ST_LimparCampo = true;
            this.st_servico.ST_NotNull = false;
            this.st_servico.UseVisualStyleBackColor = true;
            this.st_servico.Vl_False = "";
            this.st_servico.Vl_True = "";
            // 
            // ds_modelo
            // 
            this.ds_modelo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_modelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_modelo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGPedidoFiscal, "Ds_modelo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_modelo, "ds_modelo");
            this.ds_modelo.Name = "ds_modelo";
            this.ds_modelo.NM_Alias = "";
            this.ds_modelo.NM_Campo = "ds_modelo";
            this.ds_modelo.NM_CampoBusca = "ds_modelo";
            this.ds_modelo.NM_Param = "@P_DS_SERIENF";
            this.ds_modelo.QTD_Zero = 0;
            this.ds_modelo.ReadOnly = true;
            this.ds_modelo.ST_AutoInc = false;
            this.ds_modelo.ST_DisableAuto = false;
            this.ds_modelo.ST_Float = false;
            this.ds_modelo.ST_Gravar = false;
            this.ds_modelo.ST_Int = false;
            this.ds_modelo.ST_LimpaCampo = true;
            this.ds_modelo.ST_NotNull = false;
            this.ds_modelo.ST_PrimaryKey = false;
            this.ds_modelo.TextOld = null;
            // 
            // bb_modelo
            // 
            resources.ApplyResources(this.bb_modelo, "bb_modelo");
            this.bb_modelo.Name = "bb_modelo";
            this.bb_modelo.UseVisualStyleBackColor = true;
            this.bb_modelo.Click += new System.EventHandler(this.bb_modelo_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cd_modelo
            // 
            this.cd_modelo.BackColor = System.Drawing.SystemColors.Window;
            this.cd_modelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_modelo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGPedidoFiscal, "Cd_modelo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_modelo, "cd_modelo");
            this.cd_modelo.Name = "cd_modelo";
            this.cd_modelo.NM_Alias = "a";
            this.cd_modelo.NM_Campo = "cd_modelo";
            this.cd_modelo.NM_CampoBusca = "cd_modelo";
            this.cd_modelo.NM_Param = "@P_NR_SERIE";
            this.cd_modelo.QTD_Zero = 0;
            this.cd_modelo.ST_AutoInc = false;
            this.cd_modelo.ST_DisableAuto = false;
            this.cd_modelo.ST_Float = false;
            this.cd_modelo.ST_Gravar = true;
            this.cd_modelo.ST_Int = true;
            this.cd_modelo.ST_LimpaCampo = true;
            this.cd_modelo.ST_NotNull = true;
            this.cd_modelo.ST_PrimaryKey = false;
            this.cd_modelo.TextOld = null;
            this.cd_modelo.Leave += new System.EventHandler(this.cd_modelo_Leave);
            // 
            // TFCadCFGPedidoFiscal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCadCFGPedidoFiscal";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.TFCadCFGPedidoFiscal_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCFGPedidoFiscal_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadCFGPedidoFiscal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCFGPedidoFiscal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CFGPedidoFiscal)).EndInit();
            this.BN_CFGPedidoFiscal.ResumeLayout(false);
            this.BN_CFGPedidoFiscal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadCFGPedidoFiscal;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault DS_TipoPedido;
        private System.Windows.Forms.Button BB_CFG_Pedido;
        private Componentes.EditDefault CFG_Pedido;
        private Componentes.EditDefault DS_CMI;
        private System.Windows.Forms.Button BB_CMI;
        private System.Windows.Forms.Label label47;
        private Componentes.EditDefault CD_CMI;
        private Componentes.EditDefault DS_Movto;
        private System.Windows.Forms.Button BB_Movto;
        private System.Windows.Forms.Label label46;
        private Componentes.EditDefault CD_Movto;
        private Componentes.EditDefault DS_Serie;
        private System.Windows.Forms.Button BB_Serie;
        private System.Windows.Forms.Label label45;
        private Componentes.EditDefault Nr_Serie;
        private Componentes.EditDefault TP_Movimento;
        private Componentes.ComboBoxDefault Cbx_TP_Fiscal;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.BindingSource bsCFGPedidoFiscal;
        private System.Windows.Forms.BindingNavigator BN_CFGPedidoFiscal;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.CheckBoxDefault st_servico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_fiscal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFGPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpmovimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NrSérieNormal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CdMovimentaçãoNorma;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMINormal;
        private Componentes.EditDefault ds_modelo;
        private System.Windows.Forms.Button bb_modelo;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_modelo;

    }
}