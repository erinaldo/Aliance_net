namespace Financeiro
{
    partial class TFLanListaCheques
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanListaCheques));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.gCheque = new Componentes.DataGridDefault(this.components);
            this.FNr_cheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FTp_titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FStatus_compensado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FNomeclifor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nomeclifor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FNomebanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FVl_titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDt_emissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDt_vencto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDt_compensacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nm_clifor_origem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nm_clifor_repasse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCd_empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FFone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCd_banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCd_portador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FObservacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCd_historico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FNr_cgccpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FSt_impresso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FNr_lanctocheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCheque = new System.Windows.Forms.BindingSource(this.components);
            this.bnCheque = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pValores = new Componentes.PanelDados(this.components);
            this.vl_saldo = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vl_totcheques = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.vl_totalliquidar = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnCheque)).BeginInit();
            this.bnCheque.SuspendLayout();
            this.pValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totcheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totalliquidar)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Gravar,
            this.BB_Excluir,
            this.BB_Cancelar});
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Novo
            // 
            resources.ApplyResources(this.BB_Novo, "BB_Novo");
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Gravar
            // 
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Excluir
            // 
            resources.ApplyResources(this.BB_Excluir, "BB_Excluir");
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
            // 
            // BB_Cancelar
            // 
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tlpCentral
            // 
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.Controls.Add(this.pGrid, 0, 0);
            this.tlpCentral.Controls.Add(this.pValores, 0, 1);
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pGrid
            // 
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pGrid.Controls.Add(this.gCheque);
            this.pGrid.Controls.Add(this.bnCheque);
            resources.ApplyResources(this.pGrid, "pGrid");
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            // 
            // gCheque
            // 
            this.gCheque.AllowUserToAddRows = false;
            this.gCheque.AllowUserToDeleteRows = false;
            this.gCheque.AllowUserToOrderColumns = true;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Lavender;
            this.gCheque.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.gCheque.AutoGenerateColumns = false;
            this.gCheque.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCheque.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCheque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(this.gCheque, "gCheque");
            this.gCheque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FNr_cheque,
            this.FTp_titulo,
            this.FStatus_compensado,
            this.FNomeclifor,
            this.Nomeclifor,
            this.FNomebanco,
            this.FVl_titulo,
            this.FDt_emissao,
            this.FDt_vencto,
            this.FDt_compensacao,
            this.Nm_clifor_origem,
            this.Nm_clifor_repasse,
            this.FCd_empresa,
            this.FFone,
            this.FCd_banco,
            this.FCd_portador,
            this.FObservacao,
            this.FCd_historico,
            this.FNr_cgccpf,
            this.FSt_impresso,
            this.FNr_lanctocheque});
            this.gCheque.DataSource = this.bsCheque;
            this.gCheque.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCheque.Name = "gCheque";
            this.gCheque.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCheque.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gCheque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // FNr_cheque
            // 
            this.FNr_cheque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FNr_cheque.DataPropertyName = "Nr_cheque";
            resources.ApplyResources(this.FNr_cheque, "FNr_cheque");
            this.FNr_cheque.Name = "FNr_cheque";
            this.FNr_cheque.ReadOnly = true;
            // 
            // FTp_titulo
            // 
            this.FTp_titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FTp_titulo.DataPropertyName = "Tipo_titulo";
            resources.ApplyResources(this.FTp_titulo, "FTp_titulo");
            this.FTp_titulo.Name = "FTp_titulo";
            this.FTp_titulo.ReadOnly = true;
            // 
            // FStatus_compensado
            // 
            this.FStatus_compensado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FStatus_compensado.DataPropertyName = "St_compensado";
            resources.ApplyResources(this.FStatus_compensado, "FStatus_compensado");
            this.FStatus_compensado.Name = "FStatus_compensado";
            this.FStatus_compensado.ReadOnly = true;
            // 
            // FNomeclifor
            // 
            this.FNomeclifor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FNomeclifor.DataPropertyName = "Nm_clifor_nominal";
            resources.ApplyResources(this.FNomeclifor, "FNomeclifor");
            this.FNomeclifor.Name = "FNomeclifor";
            this.FNomeclifor.ReadOnly = true;
            // 
            // Nomeclifor
            // 
            this.Nomeclifor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nomeclifor.DataPropertyName = "Nomeclifor";
            resources.ApplyResources(this.Nomeclifor, "Nomeclifor");
            this.Nomeclifor.Name = "Nomeclifor";
            this.Nomeclifor.ReadOnly = true;
            // 
            // FNomebanco
            // 
            this.FNomebanco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FNomebanco.DataPropertyName = "Nomebanco";
            resources.ApplyResources(this.FNomebanco, "FNomebanco");
            this.FNomebanco.Name = "FNomebanco";
            this.FNomebanco.ReadOnly = true;
            // 
            // FVl_titulo
            // 
            this.FVl_titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FVl_titulo.DataPropertyName = "Vl_titulo";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0";
            this.FVl_titulo.DefaultCellStyle = dataGridViewCellStyle10;
            resources.ApplyResources(this.FVl_titulo, "FVl_titulo");
            this.FVl_titulo.Name = "FVl_titulo";
            this.FVl_titulo.ReadOnly = true;
            // 
            // FDt_emissao
            // 
            this.FDt_emissao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FDt_emissao.DataPropertyName = "Dt_emissaostring";
            dataGridViewCellStyle11.Format = "d";
            dataGridViewCellStyle11.NullValue = null;
            this.FDt_emissao.DefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(this.FDt_emissao, "FDt_emissao");
            this.FDt_emissao.Name = "FDt_emissao";
            this.FDt_emissao.ReadOnly = true;
            // 
            // FDt_vencto
            // 
            this.FDt_vencto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FDt_vencto.DataPropertyName = "Dt_venctostring";
            dataGridViewCellStyle12.Format = "d";
            dataGridViewCellStyle12.NullValue = null;
            this.FDt_vencto.DefaultCellStyle = dataGridViewCellStyle12;
            resources.ApplyResources(this.FDt_vencto, "FDt_vencto");
            this.FDt_vencto.Name = "FDt_vencto";
            this.FDt_vencto.ReadOnly = true;
            // 
            // FDt_compensacao
            // 
            this.FDt_compensacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FDt_compensacao.DataPropertyName = "Dt_compensacaostring";
            dataGridViewCellStyle13.Format = "d";
            dataGridViewCellStyle13.NullValue = null;
            this.FDt_compensacao.DefaultCellStyle = dataGridViewCellStyle13;
            resources.ApplyResources(this.FDt_compensacao, "FDt_compensacao");
            this.FDt_compensacao.Name = "FDt_compensacao";
            this.FDt_compensacao.ReadOnly = true;
            // 
            // Nm_clifor_origem
            // 
            this.Nm_clifor_origem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nm_clifor_origem.DataPropertyName = "Nm_clifor_origem";
            resources.ApplyResources(this.Nm_clifor_origem, "Nm_clifor_origem");
            this.Nm_clifor_origem.Name = "Nm_clifor_origem";
            this.Nm_clifor_origem.ReadOnly = true;
            // 
            // Nm_clifor_repasse
            // 
            this.Nm_clifor_repasse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nm_clifor_repasse.DataPropertyName = "Nm_clifor_repasse";
            resources.ApplyResources(this.Nm_clifor_repasse, "Nm_clifor_repasse");
            this.Nm_clifor_repasse.Name = "Nm_clifor_repasse";
            this.Nm_clifor_repasse.ReadOnly = true;
            // 
            // FCd_empresa
            // 
            this.FCd_empresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FCd_empresa.DataPropertyName = "Cd_empresa";
            resources.ApplyResources(this.FCd_empresa, "FCd_empresa");
            this.FCd_empresa.Name = "FCd_empresa";
            this.FCd_empresa.ReadOnly = true;
            // 
            // FFone
            // 
            this.FFone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FFone.DataPropertyName = "Fone";
            resources.ApplyResources(this.FFone, "FFone");
            this.FFone.Name = "FFone";
            this.FFone.ReadOnly = true;
            // 
            // FCd_banco
            // 
            this.FCd_banco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FCd_banco.DataPropertyName = "Cd_banco";
            resources.ApplyResources(this.FCd_banco, "FCd_banco");
            this.FCd_banco.Name = "FCd_banco";
            this.FCd_banco.ReadOnly = true;
            // 
            // FCd_portador
            // 
            this.FCd_portador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FCd_portador.DataPropertyName = "Cd_portador";
            resources.ApplyResources(this.FCd_portador, "FCd_portador");
            this.FCd_portador.Name = "FCd_portador";
            this.FCd_portador.ReadOnly = true;
            // 
            // FObservacao
            // 
            this.FObservacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FObservacao.DataPropertyName = "Observacao";
            resources.ApplyResources(this.FObservacao, "FObservacao");
            this.FObservacao.Name = "FObservacao";
            this.FObservacao.ReadOnly = true;
            // 
            // FCd_historico
            // 
            this.FCd_historico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FCd_historico.DataPropertyName = "Cd_historico";
            resources.ApplyResources(this.FCd_historico, "FCd_historico");
            this.FCd_historico.Name = "FCd_historico";
            this.FCd_historico.ReadOnly = true;
            // 
            // FNr_cgccpf
            // 
            this.FNr_cgccpf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FNr_cgccpf.DataPropertyName = "Nr_cgccpf";
            resources.ApplyResources(this.FNr_cgccpf, "FNr_cgccpf");
            this.FNr_cgccpf.Name = "FNr_cgccpf";
            this.FNr_cgccpf.ReadOnly = true;
            // 
            // FSt_impresso
            // 
            this.FSt_impresso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FSt_impresso.DataPropertyName = "Status_impressao";
            resources.ApplyResources(this.FSt_impresso, "FSt_impresso");
            this.FSt_impresso.Name = "FSt_impresso";
            this.FSt_impresso.ReadOnly = true;
            // 
            // FNr_lanctocheque
            // 
            this.FNr_lanctocheque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FNr_lanctocheque.DataPropertyName = "Nr_lanctocheque";
            resources.ApplyResources(this.FNr_lanctocheque, "FNr_lanctocheque");
            this.FNr_lanctocheque.Name = "FNr_lanctocheque";
            this.FNr_lanctocheque.ReadOnly = true;
            // 
            // bsCheque
            // 
            this.bsCheque.DataSource = typeof(CamadaDados.Financeiro.Titulo.TList_RegLanTitulo);
            this.bsCheque.Sort = "";
            this.bsCheque.PositionChanged += new System.EventHandler(this.bsCheque_PositionChanged);
            // 
            // bnCheque
            // 
            this.bnCheque.AddNewItem = null;
            this.bnCheque.BindingSource = this.bsCheque;
            this.bnCheque.CountItem = this.bindingNavigatorCountItem;
            this.bnCheque.CountItemFormat = "de {0}";
            this.bnCheque.DeleteItem = null;
            resources.ApplyResources(this.bnCheque, "bnCheque");
            this.bnCheque.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnCheque.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnCheque.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnCheque.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnCheque.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnCheque.Name = "bnCheque";
            this.bnCheque.PositionItem = this.bindingNavigatorPositionItem;
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
            // pValores
            // 
            this.pValores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pValores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pValores.Controls.Add(this.vl_saldo);
            this.pValores.Controls.Add(this.label3);
            this.pValores.Controls.Add(this.vl_totcheques);
            this.pValores.Controls.Add(this.label2);
            this.pValores.Controls.Add(this.vl_totalliquidar);
            this.pValores.Controls.Add(this.label1);
            resources.ApplyResources(this.pValores, "pValores");
            this.pValores.Name = "pValores";
            this.pValores.NM_ProcDeletar = "";
            this.pValores.NM_ProcGravar = "";
            // 
            // vl_saldo
            // 
            this.vl_saldo.DecimalPlaces = 2;
            resources.ApplyResources(this.vl_saldo, "vl_saldo");
            this.vl_saldo.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_saldo.Minimum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            -2147483648});
            this.vl_saldo.Name = "vl_saldo";
            this.vl_saldo.NM_Alias = "";
            this.vl_saldo.NM_Campo = "";
            this.vl_saldo.NM_Param = "";
            this.vl_saldo.Operador = "";
            this.vl_saldo.ReadOnly = true;
            this.vl_saldo.ST_AutoInc = false;
            this.vl_saldo.ST_DisableAuto = false;
            this.vl_saldo.ST_Gravar = false;
            this.vl_saldo.ST_LimparCampo = true;
            this.vl_saldo.ST_NotNull = false;
            this.vl_saldo.ST_PrimaryKey = false;
            this.vl_saldo.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // vl_totcheques
            // 
            this.vl_totcheques.DecimalPlaces = 2;
            resources.ApplyResources(this.vl_totcheques, "vl_totcheques");
            this.vl_totcheques.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_totcheques.Name = "vl_totcheques";
            this.vl_totcheques.NM_Alias = "";
            this.vl_totcheques.NM_Campo = "";
            this.vl_totcheques.NM_Param = "";
            this.vl_totcheques.Operador = "";
            this.vl_totcheques.ReadOnly = true;
            this.vl_totcheques.ST_AutoInc = false;
            this.vl_totcheques.ST_DisableAuto = false;
            this.vl_totcheques.ST_Gravar = false;
            this.vl_totcheques.ST_LimparCampo = true;
            this.vl_totcheques.ST_NotNull = false;
            this.vl_totcheques.ST_PrimaryKey = false;
            this.vl_totcheques.TabStop = false;
            this.vl_totcheques.ValueChanged += new System.EventHandler(this.vl_totcheques_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // vl_totalliquidar
            // 
            this.vl_totalliquidar.DecimalPlaces = 2;
            resources.ApplyResources(this.vl_totalliquidar, "vl_totalliquidar");
            this.vl_totalliquidar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_totalliquidar.Name = "vl_totalliquidar";
            this.vl_totalliquidar.NM_Alias = "";
            this.vl_totalliquidar.NM_Campo = "";
            this.vl_totalliquidar.NM_Param = "";
            this.vl_totalliquidar.Operador = "";
            this.vl_totalliquidar.ReadOnly = true;
            this.vl_totalliquidar.ST_AutoInc = false;
            this.vl_totalliquidar.ST_DisableAuto = false;
            this.vl_totalliquidar.ST_Gravar = false;
            this.vl_totalliquidar.ST_LimparCampo = true;
            this.vl_totalliquidar.ST_NotNull = false;
            this.vl_totalliquidar.ST_PrimaryKey = false;
            this.vl_totalliquidar.TabStop = false;
            this.vl_totalliquidar.ValueChanged += new System.EventHandler(this.vl_totalliquidar_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // TFLanListaCheques
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanListaCheques";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanListaCheques_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanListaCheques_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanListaCheques_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnCheque)).EndInit();
            this.bnCheque.ResumeLayout(false);
            this.bnCheque.PerformLayout();
            this.pValores.ResumeLayout(false);
            this.pValores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totcheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totalliquidar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pGrid;
        private Componentes.PanelDados pValores;
        private System.Windows.Forms.BindingSource bsCheque;
        private Componentes.DataGridDefault gCheque;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat vl_totalliquidar;
        private System.Windows.Forms.BindingNavigator bnCheque;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditFloat vl_saldo;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat vl_totcheques;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNr_cheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn FTp_titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FStatus_compensado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNomeclifor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nomeclifor;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNomebanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn FVl_titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDt_emissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDt_vencto;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDt_compensacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nm_clifor_origem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nm_clifor_repasse;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCd_empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn FFone;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCd_banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCd_portador;
        private System.Windows.Forms.DataGridViewTextBoxColumn FObservacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCd_historico;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNr_cgccpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn FSt_impresso;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNr_lanctocheque;
    }
}