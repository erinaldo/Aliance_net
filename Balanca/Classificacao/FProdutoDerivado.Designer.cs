namespace Balanca.Classificacao
{
    partial class TFProdutoDerivado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFProdutoDerivado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.pStatus = new Componentes.PanelDados(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.bs_PesagemGraos = new System.Windows.Forms.BindingSource(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.id_ticket = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.NM_TPPesagem = new Componentes.EditDefault(this.components);
            this.TP_Pesagem = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.BB_Placa = new System.Windows.Forms.Button();
            this.Placa = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tlpDetalhes = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gProduto = new Componentes.DataGridDefault(this.components);
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdembalagemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsProdutoDerivado = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.BT_Classificacao = new System.Windows.Forms.ToolStrip();
            this.BB_Voltar = new System.Windows.Forms.ToolStripButton();
            this.BB_Avancar = new System.Windows.Forms.ToolStripButton();
            this.qtd_bolsas = new Componentes.EditFloat(this.components);
            this.Lbl_PercenualDestino = new System.Windows.Forms.Label();
            this.Lbl_TabelaDesconto = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_PesagemGraos)).BeginInit();
            this.tlpDetalhes.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProdutoDerivado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pDados.SuspendLayout();
            this.BT_Classificacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_bolsas)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Gravar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(801, 43);
            this.barraMenu.TabIndex = 1;
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
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.AutoSize = false;
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(50, 40);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.tlpDetalhes, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(801, 379);
            this.tlpCentral.TabIndex = 2;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.pStatus);
            this.pFiltro.Controls.Add(this.id_ticket);
            this.pFiltro.Controls.Add(this.label5);
            this.pFiltro.Controls.Add(this.NM_TPPesagem);
            this.pFiltro.Controls.Add(this.TP_Pesagem);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.NM_Empresa);
            this.pFiltro.Controls.Add(this.CD_Empresa);
            this.pFiltro.Controls.Add(this.label8);
            this.pFiltro.Controls.Add(this.BB_Placa);
            this.pFiltro.Controls.Add(this.Placa);
            this.pFiltro.Controls.Add(this.label3);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(791, 83);
            this.pFiltro.TabIndex = 0;
            // 
            // pStatus
            // 
            this.pStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pStatus.Controls.Add(this.label20);
            this.pStatus.Controls.Add(this.label15);
            this.pStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.pStatus.Location = new System.Drawing.Point(549, 0);
            this.pStatus.Name = "pStatus";
            this.pStatus.NM_ProcDeletar = "";
            this.pStatus.NM_ProcGravar = "";
            this.pStatus.Size = new System.Drawing.Size(240, 81);
            this.pStatus.TabIndex = 149;
            // 
            // label20
            // 
            this.label20.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_PesagemGraos, "Status", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(0, 31);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(238, 48);
            this.label20.TabIndex = 2;
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label20.TextChanged += new System.EventHandler(this.label20_TextChanged);
            // 
            // bs_PesagemGraos
            // 
            this.bs_PesagemGraos.DataSource = typeof(CamadaDados.Balanca.TRegistro_LanPesagemGraos);
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(238, 31);
            this.label15.TabIndex = 1;
            this.label15.Text = "STATUS";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // id_ticket
            // 
            this.id_ticket.BackColor = System.Drawing.SystemColors.Window;
            this.id_ticket.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_ticket.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_PesagemGraos, "Id_ticket", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_ticket.Enabled = false;
            this.id_ticket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_ticket.Location = new System.Drawing.Point(284, 5);
            this.id_ticket.Name = "id_ticket";
            this.id_ticket.NM_Alias = "";
            this.id_ticket.NM_Campo = "TP_Pesagem";
            this.id_ticket.NM_CampoBusca = "TP_Pesagem";
            this.id_ticket.NM_Param = "@P_TP_PESAGEM";
            this.id_ticket.QTD_Zero = 0;
            this.id_ticket.Size = new System.Drawing.Size(79, 20);
            this.id_ticket.ST_AutoInc = false;
            this.id_ticket.ST_DisableAuto = false;
            this.id_ticket.ST_Float = false;
            this.id_ticket.ST_Gravar = true;
            this.id_ticket.ST_Int = false;
            this.id_ticket.ST_LimpaCampo = true;
            this.id_ticket.ST_NotNull = true;
            this.id_ticket.ST_PrimaryKey = false;
            this.id_ticket.TabIndex = 148;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(213, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 147;
            this.label5.Text = "Nº Ticket:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NM_TPPesagem
            // 
            this.NM_TPPesagem.BackColor = System.Drawing.SystemColors.Window;
            this.NM_TPPesagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_TPPesagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_PesagemGraos, "Nm_tppesagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_TPPesagem.Enabled = false;
            this.NM_TPPesagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_TPPesagem.Location = new System.Drawing.Point(151, 55);
            this.NM_TPPesagem.Name = "NM_TPPesagem";
            this.NM_TPPesagem.NM_Alias = "";
            this.NM_TPPesagem.NM_Campo = "NM_TPPesagem";
            this.NM_TPPesagem.NM_CampoBusca = "NM_TPPesagem";
            this.NM_TPPesagem.NM_Param = "@P_NM_TPPESAGEM";
            this.NM_TPPesagem.QTD_Zero = 0;
            this.NM_TPPesagem.Size = new System.Drawing.Size(324, 20);
            this.NM_TPPesagem.ST_AutoInc = false;
            this.NM_TPPesagem.ST_DisableAuto = false;
            this.NM_TPPesagem.ST_Float = false;
            this.NM_TPPesagem.ST_Gravar = false;
            this.NM_TPPesagem.ST_Int = false;
            this.NM_TPPesagem.ST_LimpaCampo = true;
            this.NM_TPPesagem.ST_NotNull = false;
            this.NM_TPPesagem.ST_PrimaryKey = false;
            this.NM_TPPesagem.TabIndex = 145;
            // 
            // TP_Pesagem
            // 
            this.TP_Pesagem.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Pesagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Pesagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_PesagemGraos, "Tp_pesagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Pesagem.Enabled = false;
            this.TP_Pesagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TP_Pesagem.Location = new System.Drawing.Point(71, 55);
            this.TP_Pesagem.Name = "TP_Pesagem";
            this.TP_Pesagem.NM_Alias = "";
            this.TP_Pesagem.NM_Campo = "TP_Pesagem";
            this.TP_Pesagem.NM_CampoBusca = "TP_Pesagem";
            this.TP_Pesagem.NM_Param = "@P_TP_PESAGEM";
            this.TP_Pesagem.QTD_Zero = 0;
            this.TP_Pesagem.Size = new System.Drawing.Size(79, 20);
            this.TP_Pesagem.ST_AutoInc = false;
            this.TP_Pesagem.ST_DisableAuto = false;
            this.TP_Pesagem.ST_Float = false;
            this.TP_Pesagem.ST_Gravar = true;
            this.TP_Pesagem.ST_Int = false;
            this.TP_Pesagem.ST_LimpaCampo = true;
            this.TP_Pesagem.ST_NotNull = true;
            this.TP_Pesagem.ST_PrimaryKey = false;
            this.TP_Pesagem.TabIndex = 141;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 146;
            this.label1.Text = "Pesagem:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_PesagemGraos, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(151, 30);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(324, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 143;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_PesagemGraos, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Enabled = false;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(71, 29);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "a";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(79, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 140;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(6, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 144;
            this.label8.Text = "Empresa:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BB_Placa
            // 
            this.BB_Placa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Placa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Placa.Image")));
            this.BB_Placa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Placa.Location = new System.Drawing.Point(177, 4);
            this.BB_Placa.Name = "BB_Placa";
            this.BB_Placa.Size = new System.Drawing.Size(30, 20);
            this.BB_Placa.TabIndex = 138;
            this.BB_Placa.UseVisualStyleBackColor = true;
            this.BB_Placa.Click += new System.EventHandler(this.BB_Placa_Click);
            // 
            // Placa
            // 
            this.Placa.BackColor = System.Drawing.SystemColors.Window;
            this.Placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Placa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_PesagemGraos, "Placacarreta", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Placa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Placa.Location = new System.Drawing.Point(71, 3);
            this.Placa.Name = "Placa";
            this.Placa.NM_Alias = "a";
            this.Placa.NM_Campo = "";
            this.Placa.NM_CampoBusca = "placaCarreta";
            this.Placa.NM_Param = "@P_PLACACARRETA";
            this.Placa.QTD_Zero = 0;
            this.Placa.Size = new System.Drawing.Size(103, 20);
            this.Placa.ST_AutoInc = false;
            this.Placa.ST_DisableAuto = false;
            this.Placa.ST_Float = false;
            this.Placa.ST_Gravar = true;
            this.Placa.ST_Int = false;
            this.Placa.ST_LimpaCampo = true;
            this.Placa.ST_NotNull = true;
            this.Placa.ST_PrimaryKey = false;
            this.Placa.TabIndex = 137;
            this.Placa.Leave += new System.EventHandler(this.Placa_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(26, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 139;
            this.label3.Text = "Placa:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tlpDetalhes
            // 
            this.tlpDetalhes.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpDetalhes.ColumnCount = 2;
            this.tlpDetalhes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetalhes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 451F));
            this.tlpDetalhes.Controls.Add(this.panelDados1, 0, 0);
            this.tlpDetalhes.Controls.Add(this.pDados, 1, 0);
            this.tlpDetalhes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetalhes.Location = new System.Drawing.Point(5, 96);
            this.tlpDetalhes.Name = "tlpDetalhes";
            this.tlpDetalhes.RowCount = 1;
            this.tlpDetalhes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetalhes.Size = new System.Drawing.Size(791, 278);
            this.tlpDetalhes.TabIndex = 1;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.gProduto);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 5);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(328, 268);
            this.panelDados1.TabIndex = 0;
            // 
            // gProduto
            // 
            this.gProduto.AllowUserToAddRows = false;
            this.gProduto.AllowUserToDeleteRows = false;
            this.gProduto.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gProduto.AutoGenerateColumns = false;
            this.gProduto.BackgroundColor = System.Drawing.Color.LightGray;
            this.gProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gProduto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProduto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.qtdembalagemDataGridViewTextBoxColumn});
            this.gProduto.DataSource = this.bsProdutoDerivado;
            this.gProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gProduto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gProduto.Location = new System.Drawing.Point(0, 0);
            this.gProduto.Name = "gProduto";
            this.gProduto.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProduto.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gProduto.RowHeadersWidth = 23;
            this.gProduto.Size = new System.Drawing.Size(328, 243);
            this.gProduto.TabIndex = 0;
            this.gProduto.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gProduto_ColumnHeaderMouseClick);
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 88;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto Derivado";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 106;
            // 
            // qtdembalagemDataGridViewTextBoxColumn
            // 
            this.qtdembalagemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdembalagemDataGridViewTextBoxColumn.DataPropertyName = "Qtd_embalagem";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.qtdembalagemDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.qtdembalagemDataGridViewTextBoxColumn.HeaderText = "Quantidade Bolsas";
            this.qtdembalagemDataGridViewTextBoxColumn.Name = "qtdembalagemDataGridViewTextBoxColumn";
            this.qtdembalagemDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtdembalagemDataGridViewTextBoxColumn.Width = 111;
            // 
            // bsProdutoDerivado
            // 
            this.bsProdutoDerivado.DataMember = "lProdutoDerivado";
            this.bsProdutoDerivado.DataSource = this.bs_PesagemGraos;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsProdutoDerivado;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
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
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 243);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(328, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.BT_Classificacao);
            this.pDados.Controls.Add(this.qtd_bolsas);
            this.pDados.Controls.Add(this.Lbl_PercenualDestino);
            this.pDados.Controls.Add(this.Lbl_TabelaDesconto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(341, 5);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(445, 268);
            this.pDados.TabIndex = 1;
            // 
            // BT_Classificacao
            // 
            this.BT_Classificacao.AutoSize = false;
            this.BT_Classificacao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BT_Classificacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Voltar,
            this.BB_Avancar});
            this.BT_Classificacao.Location = new System.Drawing.Point(0, 214);
            this.BT_Classificacao.Name = "BT_Classificacao";
            this.BT_Classificacao.Size = new System.Drawing.Size(441, 50);
            this.BT_Classificacao.TabIndex = 4;
            // 
            // BB_Voltar
            // 
            this.BB_Voltar.AutoSize = false;
            this.BB_Voltar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.BB_Voltar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Voltar.Image")));
            this.BB_Voltar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Voltar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Voltar.Name = "BB_Voltar";
            this.BB_Voltar.Size = new System.Drawing.Size(125, 47);
            this.BB_Voltar.Text = "Voltar";
            this.BB_Voltar.Click += new System.EventHandler(this.BB_Voltar_Click);
            // 
            // BB_Avancar
            // 
            this.BB_Avancar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BB_Avancar.AutoSize = false;
            this.BB_Avancar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.BB_Avancar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Avancar.Image")));
            this.BB_Avancar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Avancar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Avancar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Avancar.Name = "BB_Avancar";
            this.BB_Avancar.Size = new System.Drawing.Size(125, 47);
            this.BB_Avancar.Text = "Avançar";
            this.BB_Avancar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BB_Avancar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BB_Avancar.Click += new System.EventHandler(this.BB_Avancar_Click);
            // 
            // qtd_bolsas
            // 
            this.qtd_bolsas.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProdutoDerivado, "Qtd_embalagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_bolsas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.qtd_bolsas.Location = new System.Drawing.Point(141, 126);
            this.qtd_bolsas.Maximum = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            0});
            this.qtd_bolsas.Name = "qtd_bolsas";
            this.qtd_bolsas.NM_Alias = "";
            this.qtd_bolsas.NM_Campo = "";
            this.qtd_bolsas.NM_Param = "";
            this.qtd_bolsas.Operador = "";
            this.qtd_bolsas.Size = new System.Drawing.Size(162, 32);
            this.qtd_bolsas.ST_AutoInc = false;
            this.qtd_bolsas.ST_DisableAuto = false;
            this.qtd_bolsas.ST_Gravar = false;
            this.qtd_bolsas.ST_LimparCampo = true;
            this.qtd_bolsas.ST_NotNull = false;
            this.qtd_bolsas.ST_PrimaryKey = false;
            this.qtd_bolsas.TabIndex = 2;
            this.qtd_bolsas.ThousandsSeparator = true;
            this.qtd_bolsas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qtd_bolsas_KeyDown);
            // 
            // Lbl_PercenualDestino
            // 
            this.Lbl_PercenualDestino.AutoSize = true;
            this.Lbl_PercenualDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Lbl_PercenualDestino.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Lbl_PercenualDestino.Location = new System.Drawing.Point(138, 106);
            this.Lbl_PercenualDestino.Name = "Lbl_PercenualDestino";
            this.Lbl_PercenualDestino.Size = new System.Drawing.Size(150, 17);
            this.Lbl_PercenualDestino.TabIndex = 3;
            this.Lbl_PercenualDestino.Text = "Quantidade Bolsas:";
            // 
            // Lbl_TabelaDesconto
            // 
            this.Lbl_TabelaDesconto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.Lbl_TabelaDesconto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lbl_TabelaDesconto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProdutoDerivado, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Lbl_TabelaDesconto.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_TabelaDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Lbl_TabelaDesconto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Lbl_TabelaDesconto.Location = new System.Drawing.Point(0, 0);
            this.Lbl_TabelaDesconto.Name = "Lbl_TabelaDesconto";
            this.Lbl_TabelaDesconto.Size = new System.Drawing.Size(441, 31);
            this.Lbl_TabelaDesconto.TabIndex = 1;
            this.Lbl_TabelaDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TFProdutoDerivado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 422);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFProdutoDerivado";
            this.ShowInTaskbar = false;
            this.Text = "Informar Produtos Derivados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFProdutoDerivado_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFProdutoDerivado_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFProdutoDerivado_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bs_PesagemGraos)).EndInit();
            this.tlpDetalhes.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProdutoDerivado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.BT_Classificacao.ResumeLayout(false);
            this.BT_Classificacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_bolsas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.TableLayoutPanel tlpDetalhes;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gProduto;
        private System.Windows.Forms.BindingSource bsProdutoDerivado;
        private System.Windows.Forms.BindingSource bs_PesagemGraos;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label Lbl_TabelaDesconto;
        private Componentes.EditFloat qtd_bolsas;
        private System.Windows.Forms.Label Lbl_PercenualDestino;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStrip BT_Classificacao;
        private System.Windows.Forms.ToolStripButton BB_Voltar;
        private System.Windows.Forms.ToolStripButton BB_Avancar;
        public System.Windows.Forms.Button BB_Placa;
        private Componentes.EditDefault Placa;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault id_ticket;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault NM_TPPesagem;
        private Componentes.EditDefault TP_Pesagem;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdembalagemDataGridViewTextBoxColumn;
        private Componentes.PanelDados pStatus;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
    }
}