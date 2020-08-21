namespace Contabil.Cadastros
{
    partial class TFCad_PlanoContas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_PlanoContas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.bb_imprimir = new System.Windows.Forms.ToolStripButton();
            this.bbPlanoReferencial = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cd_conta_ctb = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_conta = new Componentes.EditDefault(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.gPlanoContas = new Componentes.DataGridDefault(this.components);
            this.cdcontactbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdclassificacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscontactbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocontaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.natDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdeducaoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cdcontactbpaiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscontactbpaiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_contasped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPlanoContas = new System.Windows.Forms.BindingSource(this.components);
            this.bnPlanoContas = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cmsPlano = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aplicarPlanoReferencialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPlanoContas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanoContas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnPlanoContas)).BeginInit();
            this.bnPlanoContas.SuspendLayout();
            this.cmsPlano.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Alterar,
            this.BB_Excluir,
            this.BB_Buscar,
            this.bb_imprimir,
            this.bbPlanoReferencial,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(927, 43);
            this.barraMenu.TabIndex = 2;
            // 
            // BB_Novo
            // 
            this.BB_Novo.AutoSize = false;
            this.BB_Novo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BB_Novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Novo.Image")));
            this.BB_Novo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Novo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BB_Novo.Size = new System.Drawing.Size(75, 40);
            this.BB_Novo.Text = "(F2)\r\nNovo";
            this.BB_Novo.ToolTipText = "Novo Registro";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Alterar
            // 
            this.BB_Alterar.AutoSize = false;
            this.BB_Alterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Alterar.ForeColor = System.Drawing.Color.Green;
            this.BB_Alterar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Alterar.Image")));
            this.BB_Alterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Alterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Alterar.Name = "BB_Alterar";
            this.BB_Alterar.Size = new System.Drawing.Size(75, 40);
            this.BB_Alterar.Text = "(F3)\r\nAlterar";
            this.BB_Alterar.ToolTipText = "Alterar Registro";
            this.BB_Alterar.Click += new System.EventHandler(this.BB_Alterar_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(100, 40);
            this.BB_Excluir.Text = "(F5)\r\nExcluir";
            this.BB_Excluir.ToolTipText = "Excluir Registro";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
            // 
            // BB_Buscar
            // 
            this.BB_Buscar.AutoSize = false;
            this.BB_Buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BB_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Buscar.Image")));
            this.BB_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Size = new System.Drawing.Size(80, 40);
            this.BB_Buscar.Text = "(F7)\r\nBuscar";
            this.BB_Buscar.ToolTipText = "Localizar Registros";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // bb_imprimir
            // 
            this.bb_imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bb_imprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.bb_imprimir.ForeColor = System.Drawing.Color.Green;
            this.bb_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("bb_imprimir.Image")));
            this.bb_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bb_imprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_imprimir.Name = "bb_imprimir";
            this.bb_imprimir.Size = new System.Drawing.Size(86, 40);
            this.bb_imprimir.Text = "(F8)\r\nImprimir";
            this.bb_imprimir.ToolTipText = "Localizar Registros";
            this.bb_imprimir.Click += new System.EventHandler(this.bb_imprimir_Click);
            // 
            // bbPlanoReferencial
            // 
            this.bbPlanoReferencial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bbPlanoReferencial.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.bbPlanoReferencial.ForeColor = System.Drawing.Color.Green;
            this.bbPlanoReferencial.Image = ((System.Drawing.Image)(resources.GetObject("bbPlanoReferencial.Image")));
            this.bbPlanoReferencial.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bbPlanoReferencial.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbPlanoReferencial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbPlanoReferencial.Name = "bbPlanoReferencial";
            this.bbPlanoReferencial.Size = new System.Drawing.Size(106, 40);
            this.bbPlanoReferencial.Text = "Plano\r\nReferencial";
            this.bbPlanoReferencial.ToolTipText = "Plano Contas Referencial";
            this.bbPlanoReferencial.Click += new System.EventHandler(this.bbPlanoReferencial_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(54, 40);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(927, 459);
            this.tlpCentral.TabIndex = 3;
            // 
            // pFiltro
            // 
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.cd_conta_ctb);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.ds_conta);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 3);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(921, 48);
            this.pFiltro.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Código";
            // 
            // cd_conta_ctb
            // 
            this.cd_conta_ctb.BackColor = System.Drawing.SystemColors.Window;
            this.cd_conta_ctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_conta_ctb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_conta_ctb.Location = new System.Drawing.Point(6, 21);
            this.cd_conta_ctb.Name = "cd_conta_ctb";
            this.cd_conta_ctb.NM_Alias = "";
            this.cd_conta_ctb.NM_Campo = "";
            this.cd_conta_ctb.NM_CampoBusca = "";
            this.cd_conta_ctb.NM_Param = "";
            this.cd_conta_ctb.QTD_Zero = 0;
            this.cd_conta_ctb.Size = new System.Drawing.Size(71, 20);
            this.cd_conta_ctb.ST_AutoInc = false;
            this.cd_conta_ctb.ST_DisableAuto = false;
            this.cd_conta_ctb.ST_Float = false;
            this.cd_conta_ctb.ST_Gravar = false;
            this.cd_conta_ctb.ST_Int = false;
            this.cd_conta_ctb.ST_LimpaCampo = true;
            this.cd_conta_ctb.ST_NotNull = false;
            this.cd_conta_ctb.ST_PrimaryKey = false;
            this.cd_conta_ctb.TabIndex = 2;
            this.cd_conta_ctb.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descrição";
            // 
            // ds_conta
            // 
            this.ds_conta.BackColor = System.Drawing.SystemColors.Window;
            this.ds_conta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_conta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_conta.Location = new System.Drawing.Point(83, 21);
            this.ds_conta.Name = "ds_conta";
            this.ds_conta.NM_Alias = "";
            this.ds_conta.NM_Campo = "";
            this.ds_conta.NM_CampoBusca = "";
            this.ds_conta.NM_Param = "";
            this.ds_conta.QTD_Zero = 0;
            this.ds_conta.Size = new System.Drawing.Size(496, 20);
            this.ds_conta.ST_AutoInc = false;
            this.ds_conta.ST_DisableAuto = false;
            this.ds_conta.ST_Float = false;
            this.ds_conta.ST_Gravar = false;
            this.ds_conta.ST_Int = false;
            this.ds_conta.ST_LimpaCampo = true;
            this.ds_conta.ST_NotNull = false;
            this.ds_conta.ST_PrimaryKey = false;
            this.ds_conta.TabIndex = 0;
            this.ds_conta.TextOld = null;
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.gPlanoContas);
            this.pDados.Controls.Add(this.bnPlanoContas);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(3, 57);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(921, 399);
            this.pDados.TabIndex = 1;
            // 
            // gPlanoContas
            // 
            this.gPlanoContas.AllowUserToAddRows = false;
            this.gPlanoContas.AllowUserToDeleteRows = false;
            this.gPlanoContas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPlanoContas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gPlanoContas.AutoGenerateColumns = false;
            this.gPlanoContas.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPlanoContas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPlanoContas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPlanoContas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gPlanoContas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPlanoContas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdcontactbDataGridViewTextBoxColumn,
            this.cdclassificacaoDataGridViewTextBoxColumn,
            this.dscontactbDataGridViewTextBoxColumn,
            this.tipocontaDataGridViewTextBoxColumn,
            this.natDataGridViewTextBoxColumn,
            this.stdeducaoboolDataGridViewCheckBoxColumn,
            this.cdcontactbpaiDataGridViewTextBoxColumn,
            this.dscontactbpaiDataGridViewTextBoxColumn,
            this.Tipo_contasped,
            this.Cd_referencia,
            this.dataGridViewTextBoxColumn1});
            this.gPlanoContas.ContextMenuStrip = this.cmsPlano;
            this.gPlanoContas.DataSource = this.bsPlanoContas;
            this.gPlanoContas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gPlanoContas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPlanoContas.Location = new System.Drawing.Point(0, 0);
            this.gPlanoContas.Name = "gPlanoContas";
            this.gPlanoContas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPlanoContas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gPlanoContas.RowHeadersWidth = 23;
            this.gPlanoContas.Size = new System.Drawing.Size(921, 374);
            this.gPlanoContas.TabIndex = 0;
            this.gPlanoContas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gPlanoContas_CellFormatting);
            // 
            // cdcontactbDataGridViewTextBoxColumn
            // 
            this.cdcontactbDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcontactbDataGridViewTextBoxColumn.DataPropertyName = "Cd_conta_ctb";
            this.cdcontactbDataGridViewTextBoxColumn.HeaderText = "Código";
            this.cdcontactbDataGridViewTextBoxColumn.Name = "cdcontactbDataGridViewTextBoxColumn";
            this.cdcontactbDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcontactbDataGridViewTextBoxColumn.Width = 65;
            // 
            // cdclassificacaoDataGridViewTextBoxColumn
            // 
            this.cdclassificacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdclassificacaoDataGridViewTextBoxColumn.DataPropertyName = "Cd_classificacao";
            this.cdclassificacaoDataGridViewTextBoxColumn.HeaderText = "Classificação";
            this.cdclassificacaoDataGridViewTextBoxColumn.Name = "cdclassificacaoDataGridViewTextBoxColumn";
            this.cdclassificacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdclassificacaoDataGridViewTextBoxColumn.Width = 94;
            // 
            // dscontactbDataGridViewTextBoxColumn
            // 
            this.dscontactbDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscontactbDataGridViewTextBoxColumn.DataPropertyName = "Ds_contactb";
            this.dscontactbDataGridViewTextBoxColumn.HeaderText = "Descrição Conta";
            this.dscontactbDataGridViewTextBoxColumn.Name = "dscontactbDataGridViewTextBoxColumn";
            this.dscontactbDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscontactbDataGridViewTextBoxColumn.Width = 102;
            // 
            // tipocontaDataGridViewTextBoxColumn
            // 
            this.tipocontaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipocontaDataGridViewTextBoxColumn.DataPropertyName = "Tipo_conta";
            this.tipocontaDataGridViewTextBoxColumn.HeaderText = "Tipo Conta";
            this.tipocontaDataGridViewTextBoxColumn.Name = "tipocontaDataGridViewTextBoxColumn";
            this.tipocontaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipocontaDataGridViewTextBoxColumn.Width = 78;
            // 
            // natDataGridViewTextBoxColumn
            // 
            this.natDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.natDataGridViewTextBoxColumn.DataPropertyName = "Nat";
            this.natDataGridViewTextBoxColumn.HeaderText = "Natureza";
            this.natDataGridViewTextBoxColumn.Name = "natDataGridViewTextBoxColumn";
            this.natDataGridViewTextBoxColumn.ReadOnly = true;
            this.natDataGridViewTextBoxColumn.Width = 75;
            // 
            // stdeducaoboolDataGridViewCheckBoxColumn
            // 
            this.stdeducaoboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stdeducaoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_deducaobool";
            this.stdeducaoboolDataGridViewCheckBoxColumn.HeaderText = "Conta Dedução";
            this.stdeducaoboolDataGridViewCheckBoxColumn.Name = "stdeducaoboolDataGridViewCheckBoxColumn";
            this.stdeducaoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stdeducaoboolDataGridViewCheckBoxColumn.Width = 79;
            // 
            // cdcontactbpaiDataGridViewTextBoxColumn
            // 
            this.cdcontactbpaiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcontactbpaiDataGridViewTextBoxColumn.DataPropertyName = "Cd_conta_ctbpai";
            this.cdcontactbpaiDataGridViewTextBoxColumn.HeaderText = "Cd. Conta Pai";
            this.cdcontactbpaiDataGridViewTextBoxColumn.Name = "cdcontactbpaiDataGridViewTextBoxColumn";
            this.cdcontactbpaiDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcontactbpaiDataGridViewTextBoxColumn.Width = 89;
            // 
            // dscontactbpaiDataGridViewTextBoxColumn
            // 
            this.dscontactbpaiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscontactbpaiDataGridViewTextBoxColumn.DataPropertyName = "Ds_contactb_pai";
            this.dscontactbpaiDataGridViewTextBoxColumn.HeaderText = "Descrição Conta Pai";
            this.dscontactbpaiDataGridViewTextBoxColumn.Name = "dscontactbpaiDataGridViewTextBoxColumn";
            this.dscontactbpaiDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscontactbpaiDataGridViewTextBoxColumn.Width = 105;
            // 
            // Tipo_contasped
            // 
            this.Tipo_contasped.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_contasped.DataPropertyName = "Tipo_contasped";
            this.Tipo_contasped.HeaderText = "Classif. Conta Sped";
            this.Tipo_contasped.Name = "Tipo_contasped";
            this.Tipo_contasped.ReadOnly = true;
            this.Tipo_contasped.Width = 91;
            // 
            // Cd_referencia
            // 
            this.Cd_referencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_referencia.DataPropertyName = "Cd_referencia";
            this.Cd_referencia.HeaderText = "Cd. Referencia";
            this.Cd_referencia.Name = "Cd_referencia";
            this.Cd_referencia.ReadOnly = true;
            this.Cd_referencia.Width = 95;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ds_referencia";
            this.dataGridViewTextBoxColumn1.HeaderText = "Referencia";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 84;
            // 
            // bsPlanoContas
            // 
            this.bsPlanoContas.DataSource = typeof(CamadaDados.Contabil.Cadastro.TList_CadPlanoContas);
            // 
            // bnPlanoContas
            // 
            this.bnPlanoContas.AddNewItem = null;
            this.bnPlanoContas.BindingSource = this.bsPlanoContas;
            this.bnPlanoContas.CountItem = this.bindingNavigatorCountItem;
            this.bnPlanoContas.CountItemFormat = "de {0}";
            this.bnPlanoContas.DeleteItem = null;
            this.bnPlanoContas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnPlanoContas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnPlanoContas.Location = new System.Drawing.Point(0, 374);
            this.bnPlanoContas.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnPlanoContas.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnPlanoContas.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnPlanoContas.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnPlanoContas.Name = "bnPlanoContas";
            this.bnPlanoContas.PositionItem = this.bindingNavigatorPositionItem;
            this.bnPlanoContas.Size = new System.Drawing.Size(921, 25);
            this.bnPlanoContas.TabIndex = 1;
            this.bnPlanoContas.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posição Corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // cmsPlano
            // 
            this.cmsPlano.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aplicarPlanoReferencialToolStripMenuItem});
            this.cmsPlano.Name = "cmsPlano";
            this.cmsPlano.Size = new System.Drawing.Size(206, 48);
            // 
            // aplicarPlanoReferencialToolStripMenuItem
            // 
            this.aplicarPlanoReferencialToolStripMenuItem.Name = "aplicarPlanoReferencialToolStripMenuItem";
            this.aplicarPlanoReferencialToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.aplicarPlanoReferencialToolStripMenuItem.Text = "Aplicar Plano Referencial";
            this.aplicarPlanoReferencialToolStripMenuItem.Click += new System.EventHandler(this.aplicarPlanoReferencialToolStripMenuItem_Click);
            // 
            // TFCad_PlanoContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 502);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFCad_PlanoContas";
            this.ShowInTaskbar = false;
            this.Text = "Plano de Contas Contabeis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFCad_PlanoContas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCad_PlanoContas_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPlanoContas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanoContas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnPlanoContas)).EndInit();
            this.bnPlanoContas.ResumeLayout(false);
            this.bnPlanoContas.PerformLayout();
            this.cmsPlano.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Alterar;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.ToolStripButton bb_imprimir;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.PanelDados pDados;
        private Componentes.DataGridDefault gPlanoContas;
        private System.Windows.Forms.BindingSource bsPlanoContas;
        private System.Windows.Forms.BindingNavigator bnPlanoContas;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_conta;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_conta_ctb;
        private System.Windows.Forms.ToolStripButton bbPlanoReferencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcontactbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdclassificacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscontactbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocontaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn natDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stdeducaoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcontactbpaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscontactbpaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_contasped;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ContextMenuStrip cmsPlano;
        private System.Windows.Forms.ToolStripMenuItem aplicarPlanoReferencialToolStripMenuItem;
    }
}