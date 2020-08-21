namespace Financeiro.Cadastros
{
    partial class TFCadHistorico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadHistorico));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gCadastro_Historico = new Componentes.DataGridDefault(this.components);
            this.bsHistorico = new System.Windows.Forms.BindingSource(this.components);
            this.LB_CD_Historico = new System.Windows.Forms.Label();
            this.LB_DS_Historico = new System.Windows.Forms.Label();
            this.LB_Tp_Hist = new System.Windows.Forms.Label();
            this.CD_Historico = new Componentes.EditDefault(this.components);
            this.DS_Historico = new Componentes.EditDefault(this.components);
            this.Tp_Hist = new Componentes.EditDefault(this.components);
            this.bb_historico = new System.Windows.Forms.Button();
            this.DS_TpHist = new Componentes.EditDefault(this.components);
            this.DS_Historico_Quitacao = new Componentes.EditDefault(this.components);
            this.BB_Historico_Quitacao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Historico_Quitacao = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tp_mov = new Componentes.ComboBoxDefault(this.components);
            this.bnHistorico = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.ds_grupocf_juro = new Componentes.EditDefault(this.components);
            this.bb_grupocf_juro = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cd_grupocf_juro = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Ds_aplicacao = new Componentes.EditDefault(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.st_transferencia = new Componentes.CheckBoxDefault(this.components);
            this.cdhistoricoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dshistoricoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipomovimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSHistoricoQuitacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstphistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_transferenciabool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dsgrupoCFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsaplicacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro_Historico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHistorico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnHistorico)).BeginInit();
            this.bnHistorico.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.panelDados1);
            this.pDados.Controls.Add(this.Ds_aplicacao);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_grupocf_juro);
            this.pDados.Controls.Add(this.bb_grupocf_juro);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.cd_grupocf_juro);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.tp_mov);
            this.pDados.Controls.Add(this.DS_Historico_Quitacao);
            this.pDados.Controls.Add(this.BB_Historico_Quitacao);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.CD_Historico_Quitacao);
            this.pDados.Controls.Add(this.DS_TpHist);
            this.pDados.Controls.Add(this.bb_historico);
            this.pDados.Controls.Add(this.LB_CD_Historico);
            this.pDados.Controls.Add(this.LB_DS_Historico);
            this.pDados.Controls.Add(this.LB_Tp_Hist);
            this.pDados.Controls.Add(this.CD_Historico);
            this.pDados.Controls.Add(this.DS_Historico);
            this.pDados.Controls.Add(this.Tp_Hist);
            this.pDados.NM_ProcDeletar = "EXCLUI_FIN_HISTORICO";
            this.pDados.NM_ProcGravar = "IA_FIN_HISTORICO";
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro_Historico);
            this.tpPadrao.Controls.Add(this.bnHistorico);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bnHistorico, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro_Historico, 0);
            // 
            // gCadastro_Historico
            // 
            this.gCadastro_Historico.AllowUserToAddRows = false;
            this.gCadastro_Historico.AllowUserToDeleteRows = false;
            this.gCadastro_Historico.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro_Historico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gCadastro_Historico.AutoGenerateColumns = false;
            this.gCadastro_Historico.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro_Historico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro_Historico.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro_Historico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gCadastro_Historico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro_Historico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdhistoricoDataGridViewTextBoxColumn,
            this.dshistoricoDataGridViewTextBoxColumn,
            this.tipomovimentoDataGridViewTextBoxColumn,
            this.dSHistoricoQuitacaoDataGridViewTextBoxColumn,
            this.dstphistDataGridViewTextBoxColumn,
            this.St_transferenciabool,
            this.dsgrupoCFDataGridViewTextBoxColumn,
            this.dsaplicacaoDataGridViewTextBoxColumn});
            this.gCadastro_Historico.DataSource = this.bsHistorico;
            resources.ApplyResources(this.gCadastro_Historico, "gCadastro_Historico");
            this.gCadastro_Historico.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro_Historico.Name = "gCadastro_Historico";
            this.gCadastro_Historico.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro_Historico.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gCadastro_Historico.TabStop = false;
            this.gCadastro_Historico.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gCadastro_Historico_ColumnHeaderMouseClick);
            // 
            // bsHistorico
            // 
            this.bsHistorico.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TRegistro_CadHistorico);
            // 
            // LB_CD_Historico
            // 
            resources.ApplyResources(this.LB_CD_Historico, "LB_CD_Historico");
            this.LB_CD_Historico.Name = "LB_CD_Historico";
            // 
            // LB_DS_Historico
            // 
            resources.ApplyResources(this.LB_DS_Historico, "LB_DS_Historico");
            this.LB_DS_Historico.Name = "LB_DS_Historico";
            // 
            // LB_Tp_Hist
            // 
            resources.ApplyResources(this.LB_Tp_Hist, "LB_Tp_Hist");
            this.LB_Tp_Hist.Name = "LB_Tp_Hist";
            // 
            // CD_Historico
            // 
            this.CD_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "Cd_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Historico, "CD_Historico");
            this.CD_Historico.Name = "CD_Historico";
            this.CD_Historico.NM_Alias = "a";
            this.CD_Historico.NM_Campo = "CD_Historico";
            this.CD_Historico.NM_CampoBusca = "CD_Historico";
            this.CD_Historico.NM_Param = "@P_CD_HISTORICO";
            this.CD_Historico.QTD_Zero = 0;
            this.CD_Historico.ST_AutoInc = false;
            this.CD_Historico.ST_DisableAuto = true;
            this.CD_Historico.ST_Float = false;
            this.CD_Historico.ST_Gravar = true;
            this.CD_Historico.ST_Int = false;
            this.CD_Historico.ST_LimpaCampo = true;
            this.CD_Historico.ST_NotNull = true;
            this.CD_Historico.ST_PrimaryKey = true;
            // 
            // DS_Historico
            // 
            this.DS_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "Ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Historico, "DS_Historico");
            this.DS_Historico.Name = "DS_Historico";
            this.DS_Historico.NM_Alias = "a";
            this.DS_Historico.NM_Campo = "DS_Historico";
            this.DS_Historico.NM_CampoBusca = "DS_Historico";
            this.DS_Historico.NM_Param = "@P_DS_HISTORICO";
            this.DS_Historico.QTD_Zero = 0;
            this.DS_Historico.ST_AutoInc = false;
            this.DS_Historico.ST_DisableAuto = false;
            this.DS_Historico.ST_Float = false;
            this.DS_Historico.ST_Gravar = true;
            this.DS_Historico.ST_Int = false;
            this.DS_Historico.ST_LimpaCampo = true;
            this.DS_Historico.ST_NotNull = true;
            this.DS_Historico.ST_PrimaryKey = false;
            // 
            // Tp_Hist
            // 
            this.Tp_Hist.BackColor = System.Drawing.SystemColors.Window;
            this.Tp_Hist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tp_Hist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Tp_Hist.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "Tp_hist", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Tp_Hist, "Tp_Hist");
            this.Tp_Hist.Name = "Tp_Hist";
            this.Tp_Hist.NM_Alias = "a";
            this.Tp_Hist.NM_Campo = "Tp_Hist";
            this.Tp_Hist.NM_CampoBusca = "Tp_Hist";
            this.Tp_Hist.NM_Param = "@P_TP_HIST";
            this.Tp_Hist.QTD_Zero = 0;
            this.Tp_Hist.ST_AutoInc = false;
            this.Tp_Hist.ST_DisableAuto = false;
            this.Tp_Hist.ST_Float = false;
            this.Tp_Hist.ST_Gravar = true;
            this.Tp_Hist.ST_Int = false;
            this.Tp_Hist.ST_LimpaCampo = true;
            this.Tp_Hist.ST_NotNull = false;
            this.Tp_Hist.ST_PrimaryKey = false;
            this.Tp_Hist.Leave += new System.EventHandler(this.Tp_Hist_Leave);
            // 
            // bb_historico
            // 
            resources.ApplyResources(this.bb_historico, "bb_historico");
            this.bb_historico.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_historico.Name = "bb_historico";
            this.bb_historico.UseVisualStyleBackColor = true;
            this.bb_historico.Click += new System.EventHandler(this.bb_historico_Click);
            // 
            // DS_TpHist
            // 
            this.DS_TpHist.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TpHist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_TpHist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TpHist.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "Ds_tphist", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_TpHist, "DS_TpHist");
            this.DS_TpHist.Name = "DS_TpHist";
            this.DS_TpHist.NM_Alias = "";
            this.DS_TpHist.NM_Campo = "DS_TpHist";
            this.DS_TpHist.NM_CampoBusca = "DS_TpHist";
            this.DS_TpHist.NM_Param = "@P_DS_TPHIST";
            this.DS_TpHist.QTD_Zero = 0;
            this.DS_TpHist.ReadOnly = true;
            this.DS_TpHist.ST_AutoInc = false;
            this.DS_TpHist.ST_DisableAuto = false;
            this.DS_TpHist.ST_Float = false;
            this.DS_TpHist.ST_Gravar = false;
            this.DS_TpHist.ST_Int = false;
            this.DS_TpHist.ST_LimpaCampo = true;
            this.DS_TpHist.ST_NotNull = false;
            this.DS_TpHist.ST_PrimaryKey = false;
            // 
            // DS_Historico_Quitacao
            // 
            this.DS_Historico_Quitacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Historico_Quitacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Historico_Quitacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Historico_Quitacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "DS_Historico_Quitacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Historico_Quitacao, "DS_Historico_Quitacao");
            this.DS_Historico_Quitacao.Name = "DS_Historico_Quitacao";
            this.DS_Historico_Quitacao.NM_Alias = "";
            this.DS_Historico_Quitacao.NM_Campo = "DS_Historico_Quitacao";
            this.DS_Historico_Quitacao.NM_CampoBusca = "DS_Historico";
            this.DS_Historico_Quitacao.NM_Param = "@P_DS_HISTORICO";
            this.DS_Historico_Quitacao.QTD_Zero = 0;
            this.DS_Historico_Quitacao.ReadOnly = true;
            this.DS_Historico_Quitacao.ST_AutoInc = false;
            this.DS_Historico_Quitacao.ST_DisableAuto = false;
            this.DS_Historico_Quitacao.ST_Float = false;
            this.DS_Historico_Quitacao.ST_Gravar = false;
            this.DS_Historico_Quitacao.ST_Int = false;
            this.DS_Historico_Quitacao.ST_LimpaCampo = true;
            this.DS_Historico_Quitacao.ST_NotNull = false;
            this.DS_Historico_Quitacao.ST_PrimaryKey = false;
            // 
            // BB_Historico_Quitacao
            // 
            resources.ApplyResources(this.BB_Historico_Quitacao, "BB_Historico_Quitacao");
            this.BB_Historico_Quitacao.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Historico_Quitacao.Name = "BB_Historico_Quitacao";
            this.BB_Historico_Quitacao.UseVisualStyleBackColor = true;
            this.BB_Historico_Quitacao.Click += new System.EventHandler(this.BB_Historioco_Quitacao_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CD_Historico_Quitacao
            // 
            this.CD_Historico_Quitacao.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Historico_Quitacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Historico_Quitacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Historico_Quitacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "CD_Historico_Quitacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Historico_Quitacao, "CD_Historico_Quitacao");
            this.CD_Historico_Quitacao.Name = "CD_Historico_Quitacao";
            this.CD_Historico_Quitacao.NM_Alias = "a";
            this.CD_Historico_Quitacao.NM_Campo = "CD_Historico_Quitacao";
            this.CD_Historico_Quitacao.NM_CampoBusca = "CD_Historico";
            this.CD_Historico_Quitacao.NM_Param = "@P_CD_HISTORICO_QUITACAO";
            this.CD_Historico_Quitacao.QTD_Zero = 0;
            this.CD_Historico_Quitacao.ST_AutoInc = false;
            this.CD_Historico_Quitacao.ST_DisableAuto = false;
            this.CD_Historico_Quitacao.ST_Float = false;
            this.CD_Historico_Quitacao.ST_Gravar = true;
            this.CD_Historico_Quitacao.ST_Int = false;
            this.CD_Historico_Quitacao.ST_LimpaCampo = true;
            this.CD_Historico_Quitacao.ST_NotNull = false;
            this.CD_Historico_Quitacao.ST_PrimaryKey = false;
            this.CD_Historico_Quitacao.Leave += new System.EventHandler(this.CD_Historioco_Quitacao_Leave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tp_mov
            // 
            this.tp_mov.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHistorico, "Tp_mov", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_mov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.tp_mov, "tp_mov");
            this.tp_mov.FormattingEnabled = true;
            this.tp_mov.Name = "tp_mov";
            this.tp_mov.NM_Alias = "a";
            this.tp_mov.NM_Campo = "tp_mov";
            this.tp_mov.NM_Param = "@P_TP_MOV";
            this.tp_mov.ST_Gravar = true;
            this.tp_mov.ST_LimparCampo = true;
            this.tp_mov.ST_NotNull = true;
            this.tp_mov.SelectedIndexChanged += new System.EventHandler(this.tp_mov_SelectedIndexChanged);
            // 
            // bnHistorico
            // 
            this.bnHistorico.AddNewItem = null;
            this.bnHistorico.BindingSource = this.bsHistorico;
            this.bnHistorico.CountItem = this.bindingNavigatorCountItem;
            this.bnHistorico.CountItemFormat = "de {0}";
            this.bnHistorico.DeleteItem = null;
            resources.ApplyResources(this.bnHistorico, "bnHistorico");
            this.bnHistorico.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnHistorico.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnHistorico.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnHistorico.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnHistorico.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnHistorico.Name = "bnHistorico";
            this.bnHistorico.PositionItem = this.bindingNavigatorPositionItem;
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
            // ds_grupocf_juro
            // 
            this.ds_grupocf_juro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_grupocf_juro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_grupocf_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_grupocf_juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "Ds_grupoCF", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_grupocf_juro, "ds_grupocf_juro");
            this.ds_grupocf_juro.Name = "ds_grupocf_juro";
            this.ds_grupocf_juro.NM_Alias = "";
            this.ds_grupocf_juro.NM_Campo = "ds_grupocf";
            this.ds_grupocf_juro.NM_CampoBusca = "ds_grupocf";
            this.ds_grupocf_juro.NM_Param = "@P_DS_HISTORICO_DESCONTO";
            this.ds_grupocf_juro.QTD_Zero = 0;
            this.ds_grupocf_juro.ReadOnly = true;
            this.ds_grupocf_juro.ST_AutoInc = false;
            this.ds_grupocf_juro.ST_DisableAuto = false;
            this.ds_grupocf_juro.ST_Float = false;
            this.ds_grupocf_juro.ST_Gravar = false;
            this.ds_grupocf_juro.ST_Int = false;
            this.ds_grupocf_juro.ST_LimpaCampo = true;
            this.ds_grupocf_juro.ST_NotNull = false;
            this.ds_grupocf_juro.ST_PrimaryKey = false;
            // 
            // bb_grupocf_juro
            // 
            resources.ApplyResources(this.bb_grupocf_juro, "bb_grupocf_juro");
            this.bb_grupocf_juro.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_grupocf_juro.Name = "bb_grupocf_juro";
            this.bb_grupocf_juro.UseVisualStyleBackColor = true;
            this.bb_grupocf_juro.Click += new System.EventHandler(this.bb_grupocf_juro_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // cd_grupocf_juro
            // 
            this.cd_grupocf_juro.BackColor = System.Drawing.SystemColors.Window;
            this.cd_grupocf_juro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_grupocf_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_grupocf_juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "Cd_grupoCF", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_grupocf_juro, "cd_grupocf_juro");
            this.cd_grupocf_juro.Name = "cd_grupocf_juro";
            this.cd_grupocf_juro.NM_Alias = "a";
            this.cd_grupocf_juro.NM_Campo = "cd_grupocf";
            this.cd_grupocf_juro.NM_CampoBusca = "cd_grupocf";
            this.cd_grupocf_juro.NM_Param = "@P_CD_HISTORICO_DCAMB_PASSIVA";
            this.cd_grupocf_juro.QTD_Zero = 0;
            this.cd_grupocf_juro.ST_AutoInc = false;
            this.cd_grupocf_juro.ST_DisableAuto = false;
            this.cd_grupocf_juro.ST_Float = false;
            this.cd_grupocf_juro.ST_Gravar = true;
            this.cd_grupocf_juro.ST_Int = false;
            this.cd_grupocf_juro.ST_LimpaCampo = true;
            this.cd_grupocf_juro.ST_NotNull = false;
            this.cd_grupocf_juro.ST_PrimaryKey = false;
            this.cd_grupocf_juro.Leave += new System.EventHandler(this.cd_grupocf_juro_Leave);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Ds_aplicacao
            // 
            this.Ds_aplicacao.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_aplicacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_aplicacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_aplicacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "Ds_aplicacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Ds_aplicacao, "Ds_aplicacao");
            this.Ds_aplicacao.Name = "Ds_aplicacao";
            this.Ds_aplicacao.NM_Alias = "";
            this.Ds_aplicacao.NM_Campo = "";
            this.Ds_aplicacao.NM_CampoBusca = "";
            this.Ds_aplicacao.NM_Param = "";
            this.Ds_aplicacao.QTD_Zero = 0;
            this.Ds_aplicacao.ST_AutoInc = false;
            this.Ds_aplicacao.ST_DisableAuto = false;
            this.Ds_aplicacao.ST_Float = false;
            this.Ds_aplicacao.ST_Gravar = true;
            this.Ds_aplicacao.ST_Int = false;
            this.Ds_aplicacao.ST_LimpaCampo = true;
            this.Ds_aplicacao.ST_NotNull = false;
            this.Ds_aplicacao.ST_PrimaryKey = false;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.st_transferencia);
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // st_transferencia
            // 
            this.st_transferencia.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsHistorico, "St_transferenciabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.st_transferencia, "st_transferencia");
            this.st_transferencia.Name = "st_transferencia";
            this.st_transferencia.NM_Alias = "";
            this.st_transferencia.NM_Campo = "";
            this.st_transferencia.NM_Param = "";
            this.st_transferencia.ST_Gravar = true;
            this.st_transferencia.ST_LimparCampo = true;
            this.st_transferencia.ST_NotNull = false;
            this.st_transferencia.UseVisualStyleBackColor = true;
            this.st_transferencia.Vl_False = "";
            this.st_transferencia.Vl_True = "";
            // 
            // cdhistoricoDataGridViewTextBoxColumn
            // 
            this.cdhistoricoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdhistoricoDataGridViewTextBoxColumn.DataPropertyName = "Cd_historico";
            resources.ApplyResources(this.cdhistoricoDataGridViewTextBoxColumn, "cdhistoricoDataGridViewTextBoxColumn");
            this.cdhistoricoDataGridViewTextBoxColumn.Name = "cdhistoricoDataGridViewTextBoxColumn";
            this.cdhistoricoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dshistoricoDataGridViewTextBoxColumn
            // 
            this.dshistoricoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dshistoricoDataGridViewTextBoxColumn.DataPropertyName = "Ds_historico";
            resources.ApplyResources(this.dshistoricoDataGridViewTextBoxColumn, "dshistoricoDataGridViewTextBoxColumn");
            this.dshistoricoDataGridViewTextBoxColumn.Name = "dshistoricoDataGridViewTextBoxColumn";
            this.dshistoricoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipomovimentoDataGridViewTextBoxColumn
            // 
            this.tipomovimentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipomovimentoDataGridViewTextBoxColumn.DataPropertyName = "Tipo_movimento";
            resources.ApplyResources(this.tipomovimentoDataGridViewTextBoxColumn, "tipomovimentoDataGridViewTextBoxColumn");
            this.tipomovimentoDataGridViewTextBoxColumn.Name = "tipomovimentoDataGridViewTextBoxColumn";
            this.tipomovimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSHistoricoQuitacaoDataGridViewTextBoxColumn
            // 
            this.dSHistoricoQuitacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSHistoricoQuitacaoDataGridViewTextBoxColumn.DataPropertyName = "DS_Historico_Quitacao";
            resources.ApplyResources(this.dSHistoricoQuitacaoDataGridViewTextBoxColumn, "dSHistoricoQuitacaoDataGridViewTextBoxColumn");
            this.dSHistoricoQuitacaoDataGridViewTextBoxColumn.Name = "dSHistoricoQuitacaoDataGridViewTextBoxColumn";
            this.dSHistoricoQuitacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dstphistDataGridViewTextBoxColumn
            // 
            this.dstphistDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstphistDataGridViewTextBoxColumn.DataPropertyName = "Ds_tphist";
            resources.ApplyResources(this.dstphistDataGridViewTextBoxColumn, "dstphistDataGridViewTextBoxColumn");
            this.dstphistDataGridViewTextBoxColumn.Name = "dstphistDataGridViewTextBoxColumn";
            this.dstphistDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // St_transferenciabool
            // 
            this.St_transferenciabool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_transferenciabool.DataPropertyName = "St_transferenciabool";
            resources.ApplyResources(this.St_transferenciabool, "St_transferenciabool");
            this.St_transferenciabool.Name = "St_transferenciabool";
            this.St_transferenciabool.ReadOnly = true;
            // 
            // dsgrupoCFDataGridViewTextBoxColumn
            // 
            this.dsgrupoCFDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsgrupoCFDataGridViewTextBoxColumn.DataPropertyName = "Ds_grupoCF";
            resources.ApplyResources(this.dsgrupoCFDataGridViewTextBoxColumn, "dsgrupoCFDataGridViewTextBoxColumn");
            this.dsgrupoCFDataGridViewTextBoxColumn.Name = "dsgrupoCFDataGridViewTextBoxColumn";
            this.dsgrupoCFDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsaplicacaoDataGridViewTextBoxColumn
            // 
            this.dsaplicacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsaplicacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_aplicacao";
            resources.ApplyResources(this.dsaplicacaoDataGridViewTextBoxColumn, "dsaplicacaoDataGridViewTextBoxColumn");
            this.dsaplicacaoDataGridViewTextBoxColumn.Name = "dsaplicacaoDataGridViewTextBoxColumn";
            this.dsaplicacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCadHistorico
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadHistorico";
            this.Load += new System.EventHandler(this.TFCadHistorico_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadHistorico_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro_Historico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHistorico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnHistorico)).EndInit();
            this.bnHistorico.ResumeLayout(false);
            this.bnHistorico.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro_Historico;
        private System.Windows.Forms.Label LB_CD_Historico;
        private System.Windows.Forms.Label LB_DS_Historico;
        private System.Windows.Forms.Label LB_Tp_Hist;
        private Componentes.EditDefault CD_Historico;
        private Componentes.EditDefault DS_Historico;
        private Componentes.EditDefault Tp_Hist;
        private Componentes.EditDefault DS_TpHist;
        public System.Windows.Forms.Button bb_historico;
        private Componentes.EditDefault DS_Historico_Quitacao;
        public System.Windows.Forms.Button BB_Historico_Quitacao;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Historico_Quitacao;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault tp_mov;
        private System.Windows.Forms.BindingSource bsHistorico;
        private System.Windows.Forms.BindingNavigator bnHistorico;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stativadoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stcustofixoboolDataGridViewCheckBoxColumn;
        private Componentes.EditDefault ds_grupocf_juro;
        private System.Windows.Forms.Button bb_grupocf_juro;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault cd_grupocf_juro;
        private Componentes.EditDefault Ds_aplicacao;
        private System.Windows.Forms.Label label2;
        private Componentes.PanelDados panelDados1;
        private Componentes.CheckBoxDefault st_transferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdhistoricoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dshistoricoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipomovimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSHistoricoQuitacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstphistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_transferenciabool;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsgrupoCFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsaplicacaoDataGridViewTextBoxColumn;
    }
}
