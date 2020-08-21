namespace Fiscal.Cadastros
{
    partial class TFCadMov_X_CMI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadMov_X_CMI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bs_CadMovXCMI = new System.Windows.Forms.BindingSource(this.components);
            this.LB_CD_Movimentacao = new System.Windows.Forms.Label();
            this.LB_CD_CMI = new System.Windows.Forms.Label();
            this.CD_Movimentacao = new Componentes.EditDefault(this.components);
            this.CD_CMI = new Componentes.EditDefault(this.components);
            this.ds_Movimentacao = new Componentes.EditDefault(this.components);
            this.ds_cmi = new Componentes.EditDefault(this.components);
            this.bb_Movimentacao = new System.Windows.Forms.Button();
            this.bb_cmi = new System.Windows.Forms.Button();
            this.tp_movMovimentacao = new Componentes.EditDefault(this.components);
            this.tp_movCMI = new Componentes.EditDefault(this.components);
            this.bn_CadMovXCMI = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.g_cadastro = new Componentes.DataGridDefault(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmovimentacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpMovMovimentacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscmiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpMovCMIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_CadMovXCMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadMovXCMI)).BeginInit();
            this.bn_CadMovXCMI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_cadastro)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.tp_movCMI);
            this.pDados.Controls.Add(this.tp_movMovimentacao);
            this.pDados.Controls.Add(this.ds_Movimentacao);
            this.pDados.Controls.Add(this.ds_cmi);
            this.pDados.Controls.Add(this.bb_Movimentacao);
            this.pDados.Controls.Add(this.bb_cmi);
            this.pDados.Controls.Add(this.LB_CD_Movimentacao);
            this.pDados.Controls.Add(this.LB_CD_CMI);
            this.pDados.Controls.Add(this.CD_Movimentacao);
            this.pDados.Controls.Add(this.CD_CMI);
            this.pDados.NM_ProcDeletar = "EXCLUI_FIS_MOV_X_CMI";
            this.pDados.NM_ProcGravar = "IA_FIS_MOV_X_CMI";
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            this.tcCentral.Font = null;
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.g_cadastro);
            this.tpPadrao.Controls.Add(this.bn_CadMovXCMI);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bn_CadMovXCMI, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_cadastro, 0);
            // 
            // bs_CadMovXCMI
            // 
            this.bs_CadMovXCMI.DataSource = typeof(CamadaDados.Fiscal.TList_CadMov_x_CMI);
            // 
            // LB_CD_Movimentacao
            // 
            this.LB_CD_Movimentacao.AccessibleDescription = null;
            this.LB_CD_Movimentacao.AccessibleName = null;
            resources.ApplyResources(this.LB_CD_Movimentacao, "LB_CD_Movimentacao");
            this.LB_CD_Movimentacao.Font = null;
            this.LB_CD_Movimentacao.Name = "LB_CD_Movimentacao";
            // 
            // LB_CD_CMI
            // 
            this.LB_CD_CMI.AccessibleDescription = null;
            this.LB_CD_CMI.AccessibleName = null;
            resources.ApplyResources(this.LB_CD_CMI, "LB_CD_CMI");
            this.LB_CD_CMI.Font = null;
            this.LB_CD_CMI.Name = "LB_CD_CMI";
            // 
            // CD_Movimentacao
            // 
            this.CD_Movimentacao.AccessibleDescription = null;
            this.CD_Movimentacao.AccessibleName = null;
            resources.ApplyResources(this.CD_Movimentacao, "CD_Movimentacao");
            this.CD_Movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Movimentacao.BackgroundImage = null;
            this.CD_Movimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovXCMI, "CD_MovimentacaoString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Movimentacao.Name = "CD_Movimentacao";
            this.CD_Movimentacao.NM_Alias = "";
            this.CD_Movimentacao.NM_Campo = "CD_Movimentacao";
            this.CD_Movimentacao.NM_CampoBusca = "CD_Movimentacao";
            this.CD_Movimentacao.NM_Param = "@P_CD_MOVIMENTACAO";
            this.CD_Movimentacao.QTD_Zero = 0;
            this.CD_Movimentacao.ST_AutoInc = false;
            this.CD_Movimentacao.ST_DisableAuto = false;
            this.CD_Movimentacao.ST_Float = false;
            this.CD_Movimentacao.ST_Gravar = true;
            this.CD_Movimentacao.ST_Int = false;
            this.CD_Movimentacao.ST_LimpaCampo = true;
            this.CD_Movimentacao.ST_NotNull = true;
            this.CD_Movimentacao.ST_PrimaryKey = true;
            this.CD_Movimentacao.TextOld = null;
            this.CD_Movimentacao.Leave += new System.EventHandler(this.CD_Movimentacao_Leave);
            // 
            // CD_CMI
            // 
            this.CD_CMI.AccessibleDescription = null;
            this.CD_CMI.AccessibleName = null;
            resources.ApplyResources(this.CD_CMI, "CD_CMI");
            this.CD_CMI.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CMI.BackgroundImage = null;
            this.CD_CMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CMI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovXCMI, "CD_CMIString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_CMI.Name = "CD_CMI";
            this.CD_CMI.NM_Alias = "";
            this.CD_CMI.NM_Campo = "CD_CMI";
            this.CD_CMI.NM_CampoBusca = "CD_CMI";
            this.CD_CMI.NM_Param = "@P_CD_CMI";
            this.CD_CMI.QTD_Zero = 0;
            this.CD_CMI.ST_AutoInc = false;
            this.CD_CMI.ST_DisableAuto = false;
            this.CD_CMI.ST_Float = false;
            this.CD_CMI.ST_Gravar = true;
            this.CD_CMI.ST_Int = false;
            this.CD_CMI.ST_LimpaCampo = true;
            this.CD_CMI.ST_NotNull = true;
            this.CD_CMI.ST_PrimaryKey = true;
            this.CD_CMI.TextOld = null;
            this.CD_CMI.Leave += new System.EventHandler(this.CD_CMI_Leave);
            // 
            // ds_Movimentacao
            // 
            this.ds_Movimentacao.AccessibleDescription = null;
            this.ds_Movimentacao.AccessibleName = null;
            resources.ApplyResources(this.ds_Movimentacao, "ds_Movimentacao");
            this.ds_Movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_Movimentacao.BackgroundImage = null;
            this.ds_Movimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_Movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_Movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovXCMI, "ds_movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_Movimentacao.Name = "ds_Movimentacao";
            this.ds_Movimentacao.NM_Alias = "";
            this.ds_Movimentacao.NM_Campo = "ds_Movimentacao";
            this.ds_Movimentacao.NM_CampoBusca = "ds_Movimentacao";
            this.ds_Movimentacao.NM_Param = "";
            this.ds_Movimentacao.QTD_Zero = 0;
            this.ds_Movimentacao.ReadOnly = true;
            this.ds_Movimentacao.ST_AutoInc = false;
            this.ds_Movimentacao.ST_DisableAuto = false;
            this.ds_Movimentacao.ST_Float = false;
            this.ds_Movimentacao.ST_Gravar = false;
            this.ds_Movimentacao.ST_Int = false;
            this.ds_Movimentacao.ST_LimpaCampo = true;
            this.ds_Movimentacao.ST_NotNull = false;
            this.ds_Movimentacao.ST_PrimaryKey = false;
            this.ds_Movimentacao.TextOld = null;
            // 
            // ds_cmi
            // 
            this.ds_cmi.AccessibleDescription = null;
            this.ds_cmi.AccessibleName = null;
            resources.ApplyResources(this.ds_cmi, "ds_cmi");
            this.ds_cmi.BackColor = System.Drawing.SystemColors.Window;
            this.ds_cmi.BackgroundImage = null;
            this.ds_cmi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_cmi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_cmi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovXCMI, "ds_cmi", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_cmi.Name = "ds_cmi";
            this.ds_cmi.NM_Alias = "";
            this.ds_cmi.NM_Campo = "ds_cmi";
            this.ds_cmi.NM_CampoBusca = "ds_cmi";
            this.ds_cmi.NM_Param = "";
            this.ds_cmi.QTD_Zero = 0;
            this.ds_cmi.ReadOnly = true;
            this.ds_cmi.ST_AutoInc = false;
            this.ds_cmi.ST_DisableAuto = false;
            this.ds_cmi.ST_Float = false;
            this.ds_cmi.ST_Gravar = false;
            this.ds_cmi.ST_Int = false;
            this.ds_cmi.ST_LimpaCampo = true;
            this.ds_cmi.ST_NotNull = false;
            this.ds_cmi.ST_PrimaryKey = false;
            this.ds_cmi.TextOld = null;
            // 
            // bb_Movimentacao
            // 
            this.bb_Movimentacao.AccessibleDescription = null;
            this.bb_Movimentacao.AccessibleName = null;
            resources.ApplyResources(this.bb_Movimentacao, "bb_Movimentacao");
            this.bb_Movimentacao.BackgroundImage = null;
            this.bb_Movimentacao.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_Movimentacao.Font = null;
            this.bb_Movimentacao.Name = "bb_Movimentacao";
            this.bb_Movimentacao.UseVisualStyleBackColor = true;
            this.bb_Movimentacao.Click += new System.EventHandler(this.bb_Movimentacao_Click);
            // 
            // bb_cmi
            // 
            this.bb_cmi.AccessibleDescription = null;
            this.bb_cmi.AccessibleName = null;
            resources.ApplyResources(this.bb_cmi, "bb_cmi");
            this.bb_cmi.BackgroundImage = null;
            this.bb_cmi.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_cmi.Font = null;
            this.bb_cmi.Name = "bb_cmi";
            this.bb_cmi.UseVisualStyleBackColor = true;
            this.bb_cmi.Click += new System.EventHandler(this.bb_cmi_Click);
            // 
            // tp_movMovimentacao
            // 
            this.tp_movMovimentacao.AccessibleDescription = null;
            this.tp_movMovimentacao.AccessibleName = null;
            resources.ApplyResources(this.tp_movMovimentacao, "tp_movMovimentacao");
            this.tp_movMovimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.tp_movMovimentacao.BackgroundImage = null;
            this.tp_movMovimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_movMovimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_movMovimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovXCMI, "Tp_Mov_Movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movMovimentacao.Name = "tp_movMovimentacao";
            this.tp_movMovimentacao.NM_Alias = "";
            this.tp_movMovimentacao.NM_Campo = "tp_movMovimento";
            this.tp_movMovimentacao.NM_CampoBusca = "tp_movimento";
            this.tp_movMovimentacao.NM_Param = "@P_TP_MOVIMENTO";
            this.tp_movMovimentacao.QTD_Zero = 0;
            this.tp_movMovimentacao.ReadOnly = true;
            this.tp_movMovimentacao.ST_AutoInc = false;
            this.tp_movMovimentacao.ST_DisableAuto = false;
            this.tp_movMovimentacao.ST_Float = false;
            this.tp_movMovimentacao.ST_Gravar = false;
            this.tp_movMovimentacao.ST_Int = false;
            this.tp_movMovimentacao.ST_LimpaCampo = true;
            this.tp_movMovimentacao.ST_NotNull = false;
            this.tp_movMovimentacao.ST_PrimaryKey = false;
            this.tp_movMovimentacao.TextOld = null;
            // 
            // tp_movCMI
            // 
            this.tp_movCMI.AccessibleDescription = null;
            this.tp_movCMI.AccessibleName = null;
            resources.ApplyResources(this.tp_movCMI, "tp_movCMI");
            this.tp_movCMI.BackColor = System.Drawing.SystemColors.Window;
            this.tp_movCMI.BackgroundImage = null;
            this.tp_movCMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_movCMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_movCMI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovXCMI, "Tp_MovCMI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movCMI.Name = "tp_movCMI";
            this.tp_movCMI.NM_Alias = "";
            this.tp_movCMI.NM_Campo = "tp_movcmi";
            this.tp_movCMI.NM_CampoBusca = "tp_movimento";
            this.tp_movCMI.NM_Param = "@P_TP_MOVIMENTO";
            this.tp_movCMI.QTD_Zero = 0;
            this.tp_movCMI.ReadOnly = true;
            this.tp_movCMI.ST_AutoInc = false;
            this.tp_movCMI.ST_DisableAuto = false;
            this.tp_movCMI.ST_Float = false;
            this.tp_movCMI.ST_Gravar = false;
            this.tp_movCMI.ST_Int = false;
            this.tp_movCMI.ST_LimpaCampo = true;
            this.tp_movCMI.ST_NotNull = false;
            this.tp_movCMI.ST_PrimaryKey = false;
            this.tp_movCMI.TextOld = null;
            // 
            // bn_CadMovXCMI
            // 
            this.bn_CadMovXCMI.AccessibleDescription = null;
            this.bn_CadMovXCMI.AccessibleName = null;
            this.bn_CadMovXCMI.AddNewItem = null;
            resources.ApplyResources(this.bn_CadMovXCMI, "bn_CadMovXCMI");
            this.bn_CadMovXCMI.BackgroundImage = null;
            this.bn_CadMovXCMI.BindingSource = this.bs_CadMovXCMI;
            this.bn_CadMovXCMI.CountItem = this.bindingNavigatorCountItem;
            this.bn_CadMovXCMI.DeleteItem = null;
            this.bn_CadMovXCMI.Font = null;
            this.bn_CadMovXCMI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bn_CadMovXCMI.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn_CadMovXCMI.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn_CadMovXCMI.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn_CadMovXCMI.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn_CadMovXCMI.Name = "bn_CadMovXCMI";
            this.bn_CadMovXCMI.PositionItem = this.bindingNavigatorPositionItem;
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
            // g_cadastro
            // 
            this.g_cadastro.AccessibleDescription = null;
            this.g_cadastro.AccessibleName = null;
            this.g_cadastro.AllowUserToAddRows = false;
            this.g_cadastro.AllowUserToDeleteRows = false;
            this.g_cadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_cadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.g_cadastro, "g_cadastro");
            this.g_cadastro.AutoGenerateColumns = false;
            this.g_cadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_cadastro.BackgroundImage = null;
            this.g_cadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_cadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_cadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_cadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_cadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dsmovimentacaoDataGridViewTextBoxColumn,
            this.tpMovMovimentacaoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.dscmiDataGridViewTextBoxColumn,
            this.tpMovCMIDataGridViewTextBoxColumn});
            this.g_cadastro.DataSource = this.bs_CadMovXCMI;
            this.g_cadastro.Font = null;
            this.g_cadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_cadastro.Name = "g_cadastro";
            this.g_cadastro.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_cadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_cadastro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CD_Movimentacao";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dsmovimentacaoDataGridViewTextBoxColumn
            // 
            this.dsmovimentacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmovimentacaoDataGridViewTextBoxColumn.DataPropertyName = "ds_movimentacao";
            resources.ApplyResources(this.dsmovimentacaoDataGridViewTextBoxColumn, "dsmovimentacaoDataGridViewTextBoxColumn");
            this.dsmovimentacaoDataGridViewTextBoxColumn.Name = "dsmovimentacaoDataGridViewTextBoxColumn";
            this.dsmovimentacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpMovMovimentacaoDataGridViewTextBoxColumn
            // 
            this.tpMovMovimentacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpMovMovimentacaoDataGridViewTextBoxColumn.DataPropertyName = "Tp_Mov_Movimentacao";
            resources.ApplyResources(this.tpMovMovimentacaoDataGridViewTextBoxColumn, "tpMovMovimentacaoDataGridViewTextBoxColumn");
            this.tpMovMovimentacaoDataGridViewTextBoxColumn.Name = "tpMovMovimentacaoDataGridViewTextBoxColumn";
            this.tpMovMovimentacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CD_CMI";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dscmiDataGridViewTextBoxColumn
            // 
            this.dscmiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscmiDataGridViewTextBoxColumn.DataPropertyName = "ds_cmi";
            resources.ApplyResources(this.dscmiDataGridViewTextBoxColumn, "dscmiDataGridViewTextBoxColumn");
            this.dscmiDataGridViewTextBoxColumn.Name = "dscmiDataGridViewTextBoxColumn";
            this.dscmiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpMovCMIDataGridViewTextBoxColumn
            // 
            this.tpMovCMIDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpMovCMIDataGridViewTextBoxColumn.DataPropertyName = "Tp_MovCMI";
            resources.ApplyResources(this.tpMovCMIDataGridViewTextBoxColumn, "tpMovCMIDataGridViewTextBoxColumn");
            this.tpMovCMIDataGridViewTextBoxColumn.Name = "tpMovCMIDataGridViewTextBoxColumn";
            this.tpMovCMIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCadMov_X_CMI
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadMov_X_CMI";
            this.Load += new System.EventHandler(this.TFCadMov_X_CMI_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadMov_X_CMI_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_CadMovXCMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadMovXCMI)).EndInit();
            this.bn_CadMovXCMI.ResumeLayout(false);
            this.bn_CadMovXCMI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_cadastro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_CD_Movimentacao;
        private System.Windows.Forms.Label LB_CD_CMI;
        private Componentes.EditDefault CD_Movimentacao;
        private Componentes.EditDefault CD_CMI;
        private Componentes.EditDefault ds_Movimentacao;
        private Componentes.EditDefault ds_cmi;
        public System.Windows.Forms.Button bb_Movimentacao;
        public System.Windows.Forms.Button bb_cmi;
        private Componentes.EditDefault tp_movCMI;
        private Componentes.EditDefault tp_movMovimentacao;
        private System.Windows.Forms.BindingNavigator bn_CadMovXCMI;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource bs_CadMovXCMI;
        private Componentes.DataGridDefault g_cadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmovimentacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpMovMovimentacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscmiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpMovCMIDataGridViewTextBoxColumn;
    }
}
