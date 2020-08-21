namespace Frota
{
    partial class TFLanMovPneu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanMovPneu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tcDetalhes = new System.Windows.Forms.TabControl();
            this.tpPneus = new System.Windows.Forms.TabPage();
            this.gPneu = new Componentes.DataGridDefault(this.components);
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpneustrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrserieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_desenho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_pneunovobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dSObservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsPneus = new System.Windows.Forms.BindingSource(this.components);
            this.TS_ItensPedido = new System.Windows.Forms.ToolStrip();
            this.BB_Movimentacao = new System.Windows.Forms.ToolStripButton();
            this.btn_manutencao = new System.Windows.Forms.ToolStripButton();
            this.btn_retornarManut = new System.Windows.Forms.ToolStripButton();
            this.btn_enviarAlmoxarifado = new System.Windows.Forms.ToolStripButton();
            this.btn_desativacao = new System.Windows.Forms.ToolStripButton();
            this.bb_exclusao = new System.Windows.Forms.ToolStripButton();
            this.BB_Trocar = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bb_adicionar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Alterar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Observacao = new System.Windows.Forms.ToolStripButton();
            this.tpHistorico = new System.Windows.Forms.TabPage();
            this.g = new Componentes.DataGridDefault(this.components);
            this.bsMovPneu = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.pConsulta = new Componentes.PanelDados(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.nr_placa = new Componentes.EditDefault(this.components);
            this.btn_fechar = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.rbManutencao = new Componentes.RadioButtonDefault(this.components);
            this.rbDesativado = new Componentes.RadioButtonDefault(this.components);
            this.rbTodos = new Componentes.RadioButtonDefault(this.components);
            this.rbAlmoxarifado = new Componentes.RadioButtonDefault(this.components);
            this.rbRodando = new Componentes.RadioButtonDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_rodado = new System.Windows.Forms.Button();
            this.id_rodado = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_veiculo = new System.Windows.Forms.Button();
            this.id_veiculo = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nr_serie = new Componentes.EditDefault(this.components);
            this.Tipo_movimentacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_recap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalPneu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_rodado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtmovimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dt_movimentofinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HodometroInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HodometroFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NM_recapador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Espessura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tcDetalhes.SuspendLayout();
            this.tpPneus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPneu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPneus)).BeginInit();
            this.TS_ItensPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.tpHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovPneu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
            this.pConsulta.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tcDetalhes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pConsulta, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1136, 486);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tcDetalhes
            // 
            this.tcDetalhes.Controls.Add(this.tpPneus);
            this.tcDetalhes.Controls.Add(this.tpHistorico);
            this.tcDetalhes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDetalhes.Location = new System.Drawing.Point(4, 82);
            this.tcDetalhes.Name = "tcDetalhes";
            this.tcDetalhes.SelectedIndex = 0;
            this.tcDetalhes.Size = new System.Drawing.Size(1128, 400);
            this.tcDetalhes.TabIndex = 0;
            // 
            // tpPneus
            // 
            this.tpPneus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpPneus.Controls.Add(this.gPneu);
            this.tpPneus.Controls.Add(this.TS_ItensPedido);
            this.tpPneus.Controls.Add(this.bindingNavigator1);
            this.tpPneus.Location = new System.Drawing.Point(4, 22);
            this.tpPneus.Name = "tpPneus";
            this.tpPneus.Padding = new System.Windows.Forms.Padding(3);
            this.tpPneus.Size = new System.Drawing.Size(1120, 374);
            this.tpPneus.TabIndex = 0;
            this.tpPneus.Text = "PNEUS";
            this.tpPneus.UseVisualStyleBackColor = true;
            // 
            // gPneu
            // 
            this.gPneu.AllowUserToAddRows = false;
            this.gPneu.AllowUserToDeleteRows = false;
            this.gPneu.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPneu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gPneu.AutoGenerateColumns = false;
            this.gPneu.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPneu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPneu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPneu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gPneu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPneu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.idpneustrDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.nrserieDataGridViewTextBoxColumn,
            this.Tipo_estado,
            this.Ds_desenho,
            this.Placa,
            this.Ds_veiculo,
            this.St_pneunovobool,
            this.dSObservacaoDataGridViewTextBoxColumn,
            this.St_processar});
            this.gPneu.DataSource = this.bsPneus;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gPneu.DefaultCellStyle = dataGridViewCellStyle3;
            this.gPneu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gPneu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPneu.Location = new System.Drawing.Point(3, 28);
            this.gPneu.Name = "gPneu";
            this.gPneu.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPneu.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gPneu.RowHeadersWidth = 23;
            this.gPneu.Size = new System.Drawing.Size(1112, 316);
            this.gPneu.TabIndex = 0;
            this.gPneu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gPneu_CellFormatting);
            this.gPneu.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gPneu_ColumnHeaderMouseClick);
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 62;
            // 
            // idpneustrDataGridViewTextBoxColumn
            // 
            this.idpneustrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idpneustrDataGridViewTextBoxColumn.DataPropertyName = "Id_pneustr";
            this.idpneustrDataGridViewTextBoxColumn.HeaderText = "Id.Pneu";
            this.idpneustrDataGridViewTextBoxColumn.Name = "idpneustrDataGridViewTextBoxColumn";
            this.idpneustrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idpneustrDataGridViewTextBoxColumn.Visible = false;
            this.idpneustrDataGridViewTextBoxColumn.Width = 69;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd.Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 85;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // nrserieDataGridViewTextBoxColumn
            // 
            this.nrserieDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrserieDataGridViewTextBoxColumn.DataPropertyName = "Nr_serie";
            this.nrserieDataGridViewTextBoxColumn.HeaderText = "Nº Fogo";
            this.nrserieDataGridViewTextBoxColumn.Name = "nrserieDataGridViewTextBoxColumn";
            this.nrserieDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrserieDataGridViewTextBoxColumn.Width = 71;
            // 
            // Tipo_estado
            // 
            this.Tipo_estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_estado.DataPropertyName = "Tipo_estado";
            this.Tipo_estado.HeaderText = "Estado Pneu";
            this.Tipo_estado.Name = "Tipo_estado";
            this.Tipo_estado.ReadOnly = true;
            this.Tipo_estado.Width = 93;
            // 
            // Ds_desenho
            // 
            this.Ds_desenho.DataPropertyName = "Ds_desenho";
            this.Ds_desenho.HeaderText = "Ds. Desenho";
            this.Ds_desenho.Name = "Ds_desenho";
            this.Ds_desenho.ReadOnly = true;
            // 
            // Placa
            // 
            this.Placa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Placa.DataPropertyName = "Placa";
            this.Placa.HeaderText = "Placa";
            this.Placa.Name = "Placa";
            this.Placa.ReadOnly = true;
            this.Placa.Width = 59;
            // 
            // Ds_veiculo
            // 
            this.Ds_veiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_veiculo.DataPropertyName = "Ds_veiculo";
            this.Ds_veiculo.HeaderText = "Veículo";
            this.Ds_veiculo.Name = "Ds_veiculo";
            this.Ds_veiculo.ReadOnly = true;
            this.Ds_veiculo.Width = 69;
            // 
            // St_pneunovobool
            // 
            this.St_pneunovobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_pneunovobool.DataPropertyName = "St_pneunovobool";
            this.St_pneunovobool.HeaderText = "Pneu Novo";
            this.St_pneunovobool.Name = "St_pneunovobool";
            this.St_pneunovobool.ReadOnly = true;
            this.St_pneunovobool.Width = 67;
            // 
            // dSObservacaoDataGridViewTextBoxColumn
            // 
            this.dSObservacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dSObservacaoDataGridViewTextBoxColumn.DataPropertyName = "DS_Observacao";
            this.dSObservacaoDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.dSObservacaoDataGridViewTextBoxColumn.Name = "dSObservacaoDataGridViewTextBoxColumn";
            this.dSObservacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSObservacaoDataGridViewTextBoxColumn.Width = 90;
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Trocar";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Visible = false;
            this.St_processar.Width = 44;
            // 
            // bsPneus
            // 
            this.bsPneus.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_LanPneu);
            this.bsPneus.PositionChanged += new System.EventHandler(this.bsPneus_PositionChanged);
            // 
            // TS_ItensPedido
            // 
            this.TS_ItensPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Movimentacao,
            this.btn_manutencao,
            this.btn_retornarManut,
            this.btn_enviarAlmoxarifado,
            this.btn_desativacao,
            this.bb_exclusao,
            this.BB_Trocar});
            this.TS_ItensPedido.Location = new System.Drawing.Point(3, 3);
            this.TS_ItensPedido.Name = "TS_ItensPedido";
            this.TS_ItensPedido.Size = new System.Drawing.Size(1112, 25);
            this.TS_ItensPedido.TabIndex = 206;
            // 
            // BB_Movimentacao
            // 
            this.BB_Movimentacao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BB_Movimentacao.Image = ((System.Drawing.Image)(resources.GetObject("BB_Movimentacao.Image")));
            this.BB_Movimentacao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Movimentacao.Name = "BB_Movimentacao";
            this.BB_Movimentacao.Size = new System.Drawing.Size(108, 22);
            this.BB_Movimentacao.Text = "MOVIMENTAR";
            this.BB_Movimentacao.Click += new System.EventHandler(this.BB_Movimentacao_Click);
            // 
            // btn_manutencao
            // 
            this.btn_manutencao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_manutencao.Image = ((System.Drawing.Image)(resources.GetObject("btn_manutencao.Image")));
            this.btn_manutencao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_manutencao.Name = "btn_manutencao";
            this.btn_manutencao.Size = new System.Drawing.Size(110, 22);
            this.btn_manutencao.Text = "MANUTENÇÃO";
            this.btn_manutencao.Click += new System.EventHandler(this.btn_manutencao_Click);
            // 
            // btn_retornarManut
            // 
            this.btn_retornarManut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_retornarManut.Image = ((System.Drawing.Image)(resources.GetObject("btn_retornarManut.Image")));
            this.btn_retornarManut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_retornarManut.Name = "btn_retornarManut";
            this.btn_retornarManut.Size = new System.Drawing.Size(140, 22);
            this.btn_retornarManut.Text = "RETORNAR MANUT.";
            this.btn_retornarManut.Click += new System.EventHandler(this.btn_retornarManut_Click);
            // 
            // btn_enviarAlmoxarifado
            // 
            this.btn_enviarAlmoxarifado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_enviarAlmoxarifado.Image = ((System.Drawing.Image)(resources.GetObject("btn_enviarAlmoxarifado.Image")));
            this.btn_enviarAlmoxarifado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_enviarAlmoxarifado.Name = "btn_enviarAlmoxarifado";
            this.btn_enviarAlmoxarifado.Size = new System.Drawing.Size(167, 22);
            this.btn_enviarAlmoxarifado.Text = "ENVIAR ALMOXARIFADO";
            this.btn_enviarAlmoxarifado.Click += new System.EventHandler(this.btn_enviarAlmoxarifado_Click);
            // 
            // btn_desativacao
            // 
            this.btn_desativacao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_desativacao.Image = ((System.Drawing.Image)(resources.GetObject("btn_desativacao.Image")));
            this.btn_desativacao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_desativacao.Name = "btn_desativacao";
            this.btn_desativacao.Size = new System.Drawing.Size(108, 22);
            this.btn_desativacao.Text = "DESATIVAÇÃO";
            this.btn_desativacao.Click += new System.EventHandler(this.btn_desativacao_Click);
            // 
            // bb_exclusao
            // 
            this.bb_exclusao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bb_exclusao.Image = ((System.Drawing.Image)(resources.GetObject("bb_exclusao.Image")));
            this.bb_exclusao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_exclusao.Name = "bb_exclusao";
            this.bb_exclusao.Size = new System.Drawing.Size(87, 22);
            this.bb_exclusao.Text = "EXCLUSÃO";
            this.bb_exclusao.Click += new System.EventHandler(this.bb_exclusao_Click);
            // 
            // BB_Trocar
            // 
            this.BB_Trocar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BB_Trocar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Trocar.Image")));
            this.BB_Trocar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Trocar.Name = "BB_Trocar";
            this.BB_Trocar.Size = new System.Drawing.Size(204, 22);
            this.BB_Trocar.Text = "TROCAR CAVALO/ CARROCERIA";
            this.BB_Trocar.Click += new System.EventHandler(this.BB_Trocar_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsPneus;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bb_adicionar,
            this.toolStripSeparator3,
            this.BB_Alterar,
            this.toolStripSeparator4,
            this.BB_Observacao});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 344);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1112, 25);
            this.bindingNavigator1.TabIndex = 5;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
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
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
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
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
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
            // bb_adicionar
            // 
            this.bb_adicionar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bb_adicionar.Image = ((System.Drawing.Image)(resources.GetObject("bb_adicionar.Image")));
            this.bb_adicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_adicionar.Name = "bb_adicionar";
            this.bb_adicionar.Size = new System.Drawing.Size(93, 22);
            this.bb_adicionar.Text = "ADICIONAR";
            this.bb_adicionar.Click += new System.EventHandler(this.bb_adicionar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // BB_Alterar
            // 
            this.BB_Alterar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BB_Alterar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Alterar.Image")));
            this.BB_Alterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Alterar.Name = "BB_Alterar";
            this.BB_Alterar.Size = new System.Drawing.Size(78, 22);
            this.BB_Alterar.Text = "ALTERAR";
            this.BB_Alterar.Click += new System.EventHandler(this.BB_Alterar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // BB_Observacao
            // 
            this.BB_Observacao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BB_Observacao.Image = ((System.Drawing.Image)(resources.GetObject("BB_Observacao.Image")));
            this.BB_Observacao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Observacao.Name = "BB_Observacao";
            this.BB_Observacao.Size = new System.Drawing.Size(105, 22);
            this.BB_Observacao.Text = "OBSERVAÇÃO";
            this.BB_Observacao.Click += new System.EventHandler(this.BB_Observacao_Click);
            // 
            // tpHistorico
            // 
            this.tpHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpHistorico.Controls.Add(this.g);
            this.tpHistorico.Controls.Add(this.bindingNavigator2);
            this.tpHistorico.Location = new System.Drawing.Point(4, 22);
            this.tpHistorico.Name = "tpHistorico";
            this.tpHistorico.Padding = new System.Windows.Forms.Padding(3);
            this.tpHistorico.Size = new System.Drawing.Size(1120, 374);
            this.tpHistorico.TabIndex = 1;
            this.tpHistorico.Text = "HISTÓRICO";
            this.tpHistorico.UseVisualStyleBackColor = true;
            // 
            // g
            // 
            this.g.AllowUserToAddRows = false;
            this.g.AllowUserToDeleteRows = false;
            this.g.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.g.AutoGenerateColumns = false;
            this.g.BackgroundColor = System.Drawing.Color.LightGray;
            this.g.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.g.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo_movimentacao,
            this.Tipo_recap,
            this.LocalPneu,
            this.placaDataGridViewTextBoxColumn,
            this.Ds_rodado,
            this.dtmovimentoDataGridViewTextBoxColumn,
            this.Dt_movimentofinal,
            this.HodometroInicial,
            this.HodometroFinal,
            this.KmTotal,
            this.obsDataGridViewTextBoxColumn,
            this.NM_recapador,
            this.Espessura,
            this.nrOSDataGridViewTextBoxColumn});
            this.g.DataSource = this.bsMovPneu;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.g.DefaultCellStyle = dataGridViewCellStyle7;
            this.g.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g.Location = new System.Drawing.Point(3, 3);
            this.g.Name = "g";
            this.g.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.g.RowHeadersWidth = 23;
            this.g.Size = new System.Drawing.Size(1112, 341);
            this.g.TabIndex = 0;
            // 
            // bsMovPneu
            // 
            this.bsMovPneu.DataMember = "lMovPneu";
            this.bsMovPneu.DataSource = this.bsPneus;
            // 
            // bindingNavigator2
            // 
            this.bindingNavigator2.AddNewItem = null;
            this.bindingNavigator2.BindingSource = this.bsMovPneu;
            this.bindingNavigator2.CountItem = this.toolStripLabel1;
            this.bindingNavigator2.DeleteItem = null;
            this.bindingNavigator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.bindingNavigator2.Location = new System.Drawing.Point(3, 344);
            this.bindingNavigator2.MoveFirstItem = this.toolStripButton1;
            this.bindingNavigator2.MoveLastItem = this.toolStripButton4;
            this.bindingNavigator2.MoveNextItem = this.toolStripButton3;
            this.bindingNavigator2.MovePreviousItem = this.toolStripButton2;
            this.bindingNavigator2.Name = "bindingNavigator2";
            this.bindingNavigator2.PositionItem = this.toolStripTextBox1;
            this.bindingNavigator2.Size = new System.Drawing.Size(1112, 25);
            this.bindingNavigator2.TabIndex = 6;
            this.bindingNavigator2.Text = "bindingNavigator2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel1.Text = "de {0}";
            this.toolStripLabel1.ToolTipText = "Total Registros";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Move first";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Move previous";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Position";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Registro Corrente";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Proximo Registro";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Ultimo Registro";
            // 
            // pConsulta
            // 
            this.pConsulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pConsulta.Controls.Add(this.label5);
            this.pConsulta.Controls.Add(this.nr_placa);
            this.pConsulta.Controls.Add(this.btn_fechar);
            this.pConsulta.Controls.Add(this.btn_buscar);
            this.pConsulta.Controls.Add(this.cbEmpresa);
            this.pConsulta.Controls.Add(this.label4);
            this.pConsulta.Controls.Add(this.radioGroup1);
            this.pConsulta.Controls.Add(this.label2);
            this.pConsulta.Controls.Add(this.bb_rodado);
            this.pConsulta.Controls.Add(this.id_rodado);
            this.pConsulta.Controls.Add(this.label3);
            this.pConsulta.Controls.Add(this.bb_veiculo);
            this.pConsulta.Controls.Add(this.id_veiculo);
            this.pConsulta.Controls.Add(this.label1);
            this.pConsulta.Controls.Add(this.nr_serie);
            this.pConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pConsulta.Location = new System.Drawing.Point(4, 4);
            this.pConsulta.Name = "pConsulta";
            this.pConsulta.NM_ProcDeletar = "";
            this.pConsulta.NM_ProcGravar = "";
            this.pConsulta.Size = new System.Drawing.Size(1128, 71);
            this.pConsulta.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Placa:";
            // 
            // nr_placa
            // 
            this.nr_placa.BackColor = System.Drawing.SystemColors.Window;
            this.nr_placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_placa.Location = new System.Drawing.Point(462, 37);
            this.nr_placa.Name = "nr_placa";
            this.nr_placa.NM_Alias = "";
            this.nr_placa.NM_Campo = "id_veiculo";
            this.nr_placa.NM_CampoBusca = "id_veiculo";
            this.nr_placa.NM_Param = "@P_ID_VEICULO";
            this.nr_placa.QTD_Zero = 0;
            this.nr_placa.Size = new System.Drawing.Size(100, 20);
            this.nr_placa.ST_AutoInc = false;
            this.nr_placa.ST_DisableAuto = false;
            this.nr_placa.ST_Float = false;
            this.nr_placa.ST_Gravar = false;
            this.nr_placa.ST_Int = false;
            this.nr_placa.ST_LimpaCampo = true;
            this.nr_placa.ST_NotNull = false;
            this.nr_placa.ST_PrimaryKey = false;
            this.nr_placa.TabIndex = 60;
            this.nr_placa.TextOld = null;
            // 
            // btn_fechar
            // 
            this.btn_fechar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_fechar.BackgroundImage")));
            this.btn_fechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_fechar.Location = new System.Drawing.Point(982, 14);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(65, 39);
            this.btn_fechar.TabIndex = 59;
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(855, 9);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(108, 55);
            this.btn_buscar.TabIndex = 58;
            this.btn_buscar.Text = "Buscar (F7)";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(76, 5);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(328, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(22, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Empresa:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.rbManutencao);
            this.radioGroup1.Controls.Add(this.rbDesativado);
            this.radioGroup1.Controls.Add(this.rbTodos);
            this.radioGroup1.Controls.Add(this.rbAlmoxarifado);
            this.radioGroup1.Controls.Add(this.rbRodando);
            this.radioGroup1.Location = new System.Drawing.Point(577, 5);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(272, 59);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 55;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Status Pneu";
            // 
            // rbManutencao
            // 
            this.rbManutencao.AutoSize = true;
            this.rbManutencao.Checked = true;
            this.rbManutencao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbManutencao.ForeColor = System.Drawing.Color.Blue;
            this.rbManutencao.Location = new System.Drawing.Point(99, 35);
            this.rbManutencao.Name = "rbManutencao";
            this.rbManutencao.Size = new System.Drawing.Size(95, 17);
            this.rbManutencao.TabIndex = 5;
            this.rbManutencao.TabStop = true;
            this.rbManutencao.Text = "Manutenção";
            this.rbManutencao.UseVisualStyleBackColor = true;
            this.rbManutencao.Valor = "";
            // 
            // rbDesativado
            // 
            this.rbDesativado.AutoSize = true;
            this.rbDesativado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDesativado.ForeColor = System.Drawing.Color.Red;
            this.rbDesativado.Location = new System.Drawing.Point(99, 14);
            this.rbDesativado.Name = "rbDesativado";
            this.rbDesativado.Size = new System.Drawing.Size(89, 17);
            this.rbDesativado.TabIndex = 3;
            this.rbDesativado.Text = "Desativado";
            this.rbDesativado.UseVisualStyleBackColor = true;
            this.rbDesativado.Valor = "";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Location = new System.Drawing.Point(203, 14);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(60, 17);
            this.rbTodos.TabIndex = 4;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.Valor = "";
            // 
            // rbAlmoxarifado
            // 
            this.rbAlmoxarifado.AutoSize = true;
            this.rbAlmoxarifado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAlmoxarifado.Location = new System.Drawing.Point(4, 14);
            this.rbAlmoxarifado.Name = "rbAlmoxarifado";
            this.rbAlmoxarifado.Size = new System.Drawing.Size(95, 17);
            this.rbAlmoxarifado.TabIndex = 0;
            this.rbAlmoxarifado.Text = "Almofarifado";
            this.rbAlmoxarifado.UseVisualStyleBackColor = true;
            this.rbAlmoxarifado.Valor = "";
            // 
            // rbRodando
            // 
            this.rbRodando.AutoSize = true;
            this.rbRodando.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRodando.ForeColor = System.Drawing.Color.Green;
            this.rbRodando.Location = new System.Drawing.Point(4, 35);
            this.rbRodando.Name = "rbRodando";
            this.rbRodando.Size = new System.Drawing.Size(76, 17);
            this.rbRodando.TabIndex = 1;
            this.rbRodando.Text = "Rodando";
            this.rbRodando.UseVisualStyleBackColor = true;
            this.rbRodando.Valor = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Rodado:";
            // 
            // bb_rodado
            // 
            this.bb_rodado.Image = ((System.Drawing.Image)(resources.GetObject("bb_rodado.Image")));
            this.bb_rodado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_rodado.Location = new System.Drawing.Point(317, 39);
            this.bb_rodado.Name = "bb_rodado";
            this.bb_rodado.Size = new System.Drawing.Size(29, 20);
            this.bb_rodado.TabIndex = 53;
            this.bb_rodado.UseVisualStyleBackColor = true;
            this.bb_rodado.Click += new System.EventHandler(this.bb_rodado_Click);
            // 
            // id_rodado
            // 
            this.id_rodado.BackColor = System.Drawing.SystemColors.Window;
            this.id_rodado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_rodado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_rodado.Location = new System.Drawing.Point(239, 39);
            this.id_rodado.Name = "id_rodado";
            this.id_rodado.NM_Alias = "";
            this.id_rodado.NM_Campo = "";
            this.id_rodado.NM_CampoBusca = "id_rodado";
            this.id_rodado.NM_Param = "";
            this.id_rodado.QTD_Zero = 0;
            this.id_rodado.Size = new System.Drawing.Size(72, 20);
            this.id_rodado.ST_AutoInc = false;
            this.id_rodado.ST_DisableAuto = false;
            this.id_rodado.ST_Float = false;
            this.id_rodado.ST_Gravar = false;
            this.id_rodado.ST_Int = false;
            this.id_rodado.ST_LimpaCampo = true;
            this.id_rodado.ST_NotNull = false;
            this.id_rodado.ST_PrimaryKey = false;
            this.id_rodado.TabIndex = 52;
            this.id_rodado.TextOld = null;
            this.id_rodado.Leave += new System.EventHandler(this.id_rodado_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Veiculo:";
            // 
            // bb_veiculo
            // 
            this.bb_veiculo.Image = ((System.Drawing.Image)(resources.GetObject("bb_veiculo.Image")));
            this.bb_veiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_veiculo.Location = new System.Drawing.Point(154, 37);
            this.bb_veiculo.Name = "bb_veiculo";
            this.bb_veiculo.Size = new System.Drawing.Size(29, 20);
            this.bb_veiculo.TabIndex = 50;
            this.bb_veiculo.UseVisualStyleBackColor = true;
            this.bb_veiculo.Click += new System.EventHandler(this.bb_veiculo_Click);
            // 
            // id_veiculo
            // 
            this.id_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.id_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculo.Location = new System.Drawing.Point(76, 37);
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.NM_Alias = "";
            this.id_veiculo.NM_Campo = "id_veiculo";
            this.id_veiculo.NM_CampoBusca = "id_veiculo";
            this.id_veiculo.NM_Param = "@P_ID_VEICULO";
            this.id_veiculo.QTD_Zero = 0;
            this.id_veiculo.Size = new System.Drawing.Size(72, 20);
            this.id_veiculo.ST_AutoInc = false;
            this.id_veiculo.ST_DisableAuto = false;
            this.id_veiculo.ST_Float = false;
            this.id_veiculo.ST_Gravar = false;
            this.id_veiculo.ST_Int = true;
            this.id_veiculo.ST_LimpaCampo = true;
            this.id_veiculo.ST_NotNull = false;
            this.id_veiculo.ST_PrimaryKey = false;
            this.id_veiculo.TabIndex = 49;
            this.id_veiculo.TextOld = null;
            this.id_veiculo.Leave += new System.EventHandler(this.id_veiculo_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nº Fogo:";
            // 
            // nr_serie
            // 
            this.nr_serie.BackColor = System.Drawing.SystemColors.Window;
            this.nr_serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_serie.Location = new System.Drawing.Point(462, 5);
            this.nr_serie.Name = "nr_serie";
            this.nr_serie.NM_Alias = "";
            this.nr_serie.NM_Campo = "";
            this.nr_serie.NM_CampoBusca = "";
            this.nr_serie.NM_Param = "";
            this.nr_serie.QTD_Zero = 0;
            this.nr_serie.Size = new System.Drawing.Size(100, 20);
            this.nr_serie.ST_AutoInc = false;
            this.nr_serie.ST_DisableAuto = false;
            this.nr_serie.ST_Float = false;
            this.nr_serie.ST_Gravar = false;
            this.nr_serie.ST_Int = false;
            this.nr_serie.ST_LimpaCampo = true;
            this.nr_serie.ST_NotNull = false;
            this.nr_serie.ST_PrimaryKey = false;
            this.nr_serie.TabIndex = 0;
            this.nr_serie.TextOld = null;
            // 
            // Tipo_movimentacao
            // 
            this.Tipo_movimentacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_movimentacao.DataPropertyName = "Tipo_movimentacao";
            this.Tipo_movimentacao.HeaderText = "Tipo Movimentação";
            this.Tipo_movimentacao.Name = "Tipo_movimentacao";
            this.Tipo_movimentacao.ReadOnly = true;
            this.Tipo_movimentacao.Width = 115;
            // 
            // Tipo_recap
            // 
            this.Tipo_recap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_recap.DataPropertyName = "Tipo_recap";
            this.Tipo_recap.HeaderText = "Tipo Recap";
            this.Tipo_recap.Name = "Tipo_recap";
            this.Tipo_recap.ReadOnly = true;
            this.Tipo_recap.Width = 81;
            // 
            // LocalPneu
            // 
            this.LocalPneu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LocalPneu.DataPropertyName = "LocalPneu";
            this.LocalPneu.HeaderText = "Localização Pneu";
            this.LocalPneu.Name = "LocalPneu";
            this.LocalPneu.ReadOnly = true;
            this.LocalPneu.Width = 107;
            // 
            // placaDataGridViewTextBoxColumn
            // 
            this.placaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.placaDataGridViewTextBoxColumn.DataPropertyName = "Placa";
            this.placaDataGridViewTextBoxColumn.HeaderText = "Placa";
            this.placaDataGridViewTextBoxColumn.Name = "placaDataGridViewTextBoxColumn";
            this.placaDataGridViewTextBoxColumn.ReadOnly = true;
            this.placaDataGridViewTextBoxColumn.Width = 59;
            // 
            // Ds_rodado
            // 
            this.Ds_rodado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_rodado.DataPropertyName = "Ds_rodado";
            this.Ds_rodado.HeaderText = "Rodado";
            this.Ds_rodado.Name = "Ds_rodado";
            this.Ds_rodado.ReadOnly = true;
            this.Ds_rodado.Width = 70;
            // 
            // dtmovimentoDataGridViewTextBoxColumn
            // 
            this.dtmovimentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtmovimentoDataGridViewTextBoxColumn.DataPropertyName = "Dt_movimento";
            this.dtmovimentoDataGridViewTextBoxColumn.HeaderText = "Dt.Movimento Origem";
            this.dtmovimentoDataGridViewTextBoxColumn.Name = "dtmovimentoDataGridViewTextBoxColumn";
            this.dtmovimentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtmovimentoDataGridViewTextBoxColumn.Width = 123;
            // 
            // Dt_movimentofinal
            // 
            this.Dt_movimentofinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dt_movimentofinal.DataPropertyName = "Dt_movimentofinal";
            this.Dt_movimentofinal.HeaderText = "Dt.Movimento Destino";
            this.Dt_movimentofinal.Name = "Dt_movimentofinal";
            this.Dt_movimentofinal.ReadOnly = true;
            this.Dt_movimentofinal.Width = 125;
            // 
            // HodometroInicial
            // 
            this.HodometroInicial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.HodometroInicial.DataPropertyName = "HodometroInicial";
            this.HodometroInicial.HeaderText = "Hodometro Inicial";
            this.HodometroInicial.Name = "HodometroInicial";
            this.HodometroInicial.ReadOnly = true;
            this.HodometroInicial.Width = 105;
            // 
            // HodometroFinal
            // 
            this.HodometroFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.HodometroFinal.DataPropertyName = "HodometroFinal";
            this.HodometroFinal.HeaderText = "Hodometro Final";
            this.HodometroFinal.Name = "HodometroFinal";
            this.HodometroFinal.ReadOnly = true;
            // 
            // KmTotal
            // 
            this.KmTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.KmTotal.DataPropertyName = "KmTotal";
            this.KmTotal.HeaderText = "Km Total";
            this.KmTotal.Name = "KmTotal";
            this.KmTotal.ReadOnly = true;
            this.KmTotal.Width = 69;
            // 
            // obsDataGridViewTextBoxColumn
            // 
            this.obsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.obsDataGridViewTextBoxColumn.DataPropertyName = "Obs";
            this.obsDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.obsDataGridViewTextBoxColumn.Name = "obsDataGridViewTextBoxColumn";
            this.obsDataGridViewTextBoxColumn.ReadOnly = true;
            this.obsDataGridViewTextBoxColumn.Width = 90;
            // 
            // NM_recapador
            // 
            this.NM_recapador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NM_recapador.DataPropertyName = "NM_recapador";
            this.NM_recapador.HeaderText = "Recapador";
            this.NM_recapador.Name = "NM_recapador";
            this.NM_recapador.ReadOnly = true;
            this.NM_recapador.Width = 85;
            // 
            // Espessura
            // 
            this.Espessura.DataPropertyName = "EspessuraBorracha";
            this.Espessura.HeaderText = "Profundidade";
            this.Espessura.Name = "Espessura";
            this.Espessura.ReadOnly = true;
            // 
            // nrOSDataGridViewTextBoxColumn
            // 
            this.nrOSDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrOSDataGridViewTextBoxColumn.DataPropertyName = "Nr_OS";
            this.nrOSDataGridViewTextBoxColumn.HeaderText = "Nº OS";
            this.nrOSDataGridViewTextBoxColumn.Name = "nrOSDataGridViewTextBoxColumn";
            this.nrOSDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrOSDataGridViewTextBoxColumn.Width = 58;
            // 
            // TFLanMovPneu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 486);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "TFLanMovPneu";
            this.ShowInTaskbar = false;
            this.Text = "Gestão de Pneus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFLanMovPneu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanMovPneu_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tcDetalhes.ResumeLayout(false);
            this.tpPneus.ResumeLayout(false);
            this.tpPneus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPneu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPneus)).EndInit();
            this.TS_ItensPedido.ResumeLayout(false);
            this.TS_ItensPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.tpHistorico.ResumeLayout(false);
            this.tpHistorico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovPneu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.pConsulta.ResumeLayout(false);
            this.pConsulta.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tcDetalhes;
        private System.Windows.Forms.TabPage tpPneus;
        private Componentes.DataGridDefault gPneu;
        private System.Windows.Forms.BindingSource bsPneus;
        private System.Windows.Forms.TabPage tpHistorico;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault g;
        private System.Windows.Forms.DataGridViewTextBoxColumn hodometroDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStrip TS_ItensPedido;
        private System.Windows.Forms.ToolStripButton btn_manutencao;
        private System.Windows.Forms.ToolStripButton btn_desativacao;
        private Componentes.PanelDados pConsulta;
        private Componentes.EditDefault nr_serie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_veiculo;
        private Componentes.EditDefault id_veiculo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_rodado;
        private Componentes.EditDefault id_rodado;
        private System.Windows.Forms.ToolStripButton bb_exclusao;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.RadioButtonDefault rbManutencao;
        private Componentes.RadioButtonDefault rbDesativado;
        private Componentes.RadioButtonDefault rbTodos;
        private Componentes.RadioButtonDefault rbAlmoxarifado;
        private Componentes.RadioButtonDefault rbRodando;
        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.BindingSource bsMovPneu;
        private System.Windows.Forms.ToolStripButton btn_retornarManut;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.ToolStripButton btn_enviarAlmoxarifado;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault nr_placa;
        private System.Windows.Forms.ToolStripButton BB_Movimentacao;
        private System.Windows.Forms.ToolStripButton bb_adicionar;
        private System.Windows.Forms.ToolStripButton BB_Alterar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpneustrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrserieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_desenho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_veiculo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_pneunovobool;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSObservacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BB_Observacao;
        private System.Windows.Forms.ToolStripButton BB_Trocar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_movimentacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_recap;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalPneu;
        private System.Windows.Forms.DataGridViewTextBoxColumn placaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_rodado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtmovimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_movimentofinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn HodometroInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn HodometroFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn KmTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn obsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NM_recapador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Espessura;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrOSDataGridViewTextBoxColumn;
    }
}