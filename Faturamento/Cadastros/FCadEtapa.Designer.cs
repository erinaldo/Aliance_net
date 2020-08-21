namespace Faturamento.Cadastros
{
    partial class TFCadEtapa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadEtapa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridProcesso = new Componentes.DataGridDefault(this.components);
            this.bsProcessor = new System.Windows.Forms.BindingSource(this.components);
            this.bsEtapa = new System.Windows.Forms.BindingSource(this.components);
            this.tsProcesso = new System.Windows.Forms.ToolStrip();
            this.bbInserirProcesso = new System.Windows.Forms.ToolStripButton();
            this.bbAlterarProcesso = new System.Windows.Forms.ToolStripButton();
            this.bbExcluirProcesso = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridEtapa = new Componentes.DataGridDefault(this.components);
            this.tsEtapa = new System.Windows.Forms.ToolStrip();
            this.bbInserirEtapa = new System.Windows.Forms.ToolStripButton();
            this.bbAlterarEtapa = new System.Windows.Forms.ToolStripButton();
            this.bbExcluirEtapa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.bb_cima = new System.Windows.Forms.ToolStripButton();
            this.bb_baixo = new System.Windows.Forms.ToolStripButton();
            this.Cd_conta_CTBstr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DS_Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSEtapaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTFecharPedBoolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ST_LiberarExpedBool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iDProcessostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSProcessoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProcesso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProcessor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEtapa)).BeginInit();
            this.tsProcesso.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEtapa)).BeginInit();
            this.tsEtapa.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Buscar,
            this.toolStripSeparator5,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(905, 43);
            this.barraMenu.TabIndex = 4;
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 43);
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 905F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(905, 392);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridProcesso);
            this.panel2.Controls.Add(this.tsProcesso);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 223);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(899, 176);
            this.panel2.TabIndex = 2;
            // 
            // gridProcesso
            // 
            this.gridProcesso.AllowUserToAddRows = false;
            this.gridProcesso.AllowUserToDeleteRows = false;
            this.gridProcesso.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gridProcesso.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridProcesso.AutoGenerateColumns = false;
            this.gridProcesso.BackgroundColor = System.Drawing.Color.LightGray;
            this.gridProcesso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridProcesso.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProcesso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridProcesso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProcesso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDProcessostrDataGridViewTextBoxColumn,
            this.dSProcessoDataGridViewTextBoxColumn});
            this.gridProcesso.DataSource = this.bsProcessor;
            this.gridProcesso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProcesso.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridProcesso.Location = new System.Drawing.Point(0, 25);
            this.gridProcesso.Name = "gridProcesso";
            this.gridProcesso.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProcesso.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridProcesso.RowHeadersWidth = 23;
            this.gridProcesso.Size = new System.Drawing.Size(899, 151);
            this.gridProcesso.TabIndex = 7;
            // 
            // bsProcessor
            // 
            this.bsProcessor.DataMember = "lprocesso";
            this.bsProcessor.DataSource = this.bsEtapa;
            // 
            // bsEtapa
            // 
            this.bsEtapa.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CadEtapa);
            this.bsEtapa.PositionChanged += new System.EventHandler(this.bsEtapa_PositionChanged);
            // 
            // tsProcesso
            // 
            this.tsProcesso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bbInserirProcesso,
            this.bbAlterarProcesso,
            this.bbExcluirProcesso});
            this.tsProcesso.Location = new System.Drawing.Point(0, 0);
            this.tsProcesso.Name = "tsProcesso";
            this.tsProcesso.Size = new System.Drawing.Size(899, 25);
            this.tsProcesso.TabIndex = 8;
            // 
            // bbInserirProcesso
            // 
            this.bbInserirProcesso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbInserirProcesso.Image = ((System.Drawing.Image)(resources.GetObject("bbInserirProcesso.Image")));
            this.bbInserirProcesso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbInserirProcesso.Name = "bbInserirProcesso";
            this.bbInserirProcesso.Size = new System.Drawing.Size(65, 22);
            this.bbInserirProcesso.Text = "Inserir";
            this.bbInserirProcesso.ToolTipText = "Inserir Novo Item Pedido";
            this.bbInserirProcesso.Click += new System.EventHandler(this.bbInserirProcesso_Click);
            // 
            // bbAlterarProcesso
            // 
            this.bbAlterarProcesso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbAlterarProcesso.Image = ((System.Drawing.Image)(resources.GetObject("bbAlterarProcesso.Image")));
            this.bbAlterarProcesso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbAlterarProcesso.Name = "bbAlterarProcesso";
            this.bbAlterarProcesso.Size = new System.Drawing.Size(67, 22);
            this.bbAlterarProcesso.Text = "Alterar";
            this.bbAlterarProcesso.ToolTipText = "Inserir Novo Item Pedido";
            this.bbAlterarProcesso.Click += new System.EventHandler(this.bbAlterarProcesso_Click);
            // 
            // bbExcluirProcesso
            // 
            this.bbExcluirProcesso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbExcluirProcesso.Image = ((System.Drawing.Image)(resources.GetObject("bbExcluirProcesso.Image")));
            this.bbExcluirProcesso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbExcluirProcesso.Name = "bbExcluirProcesso";
            this.bbExcluirProcesso.Size = new System.Drawing.Size(64, 22);
            this.bbExcluirProcesso.Text = "Excluir";
            this.bbExcluirProcesso.ToolTipText = "Excluir Item Pedido";
            this.bbExcluirProcesso.Click += new System.EventHandler(this.bbExcluirProcesso_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.editDefault2);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.editDefault1);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(899, 32);
            this.panelDados1.TabIndex = 0;
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.Location = new System.Drawing.Point(320, 7);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "";
            this.editDefault2.NM_CampoBusca = "";
            this.editDefault2.NM_Param = "";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.Size = new System.Drawing.Size(207, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = false;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = false;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 3;
            this.editDefault2.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Processo:";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.Location = new System.Drawing.Point(51, 7);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(207, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 1;
            this.editDefault1.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Etapa:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridEtapa);
            this.panel1.Controls.Add(this.tsEtapa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 176);
            this.panel1.TabIndex = 1;
            // 
            // gridEtapa
            // 
            this.gridEtapa.AllowUserToAddRows = false;
            this.gridEtapa.AllowUserToDeleteRows = false;
            this.gridEtapa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gridEtapa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridEtapa.AutoGenerateColumns = false;
            this.gridEtapa.BackgroundColor = System.Drawing.Color.LightGray;
            this.gridEtapa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridEtapa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEtapa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridEtapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEtapa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dSEtapaDataGridViewTextBoxColumn,
            this.sTFecharPedBoolDataGridViewCheckBoxColumn,
            this.ST_LiberarExpedBool});
            this.gridEtapa.DataSource = this.bsEtapa;
            this.gridEtapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEtapa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridEtapa.Location = new System.Drawing.Point(0, 25);
            this.gridEtapa.Name = "gridEtapa";
            this.gridEtapa.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEtapa.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridEtapa.RowHeadersWidth = 23;
            this.gridEtapa.Size = new System.Drawing.Size(899, 151);
            this.gridEtapa.TabIndex = 6;
            // 
            // tsEtapa
            // 
            this.tsEtapa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bbInserirEtapa,
            this.bbAlterarEtapa,
            this.bbExcluirEtapa,
            this.toolStripSeparator12,
            this.bb_cima,
            this.bb_baixo});
            this.tsEtapa.Location = new System.Drawing.Point(0, 0);
            this.tsEtapa.Name = "tsEtapa";
            this.tsEtapa.Size = new System.Drawing.Size(899, 25);
            this.tsEtapa.TabIndex = 7;
            // 
            // bbInserirEtapa
            // 
            this.bbInserirEtapa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbInserirEtapa.Image = ((System.Drawing.Image)(resources.GetObject("bbInserirEtapa.Image")));
            this.bbInserirEtapa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbInserirEtapa.Name = "bbInserirEtapa";
            this.bbInserirEtapa.Size = new System.Drawing.Size(65, 22);
            this.bbInserirEtapa.Text = "Inserir";
            this.bbInserirEtapa.ToolTipText = "Inserir Novo Item Pedido";
            this.bbInserirEtapa.Click += new System.EventHandler(this.bbInserirEtapa_Click);
            // 
            // bbAlterarEtapa
            // 
            this.bbAlterarEtapa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbAlterarEtapa.Image = ((System.Drawing.Image)(resources.GetObject("bbAlterarEtapa.Image")));
            this.bbAlterarEtapa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbAlterarEtapa.Name = "bbAlterarEtapa";
            this.bbAlterarEtapa.Size = new System.Drawing.Size(67, 22);
            this.bbAlterarEtapa.Text = "Alterar";
            this.bbAlterarEtapa.ToolTipText = "Inserir Novo Item Pedido";
            this.bbAlterarEtapa.Click += new System.EventHandler(this.bbAlterarEtapa_Click);
            // 
            // bbExcluirEtapa
            // 
            this.bbExcluirEtapa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbExcluirEtapa.Image = ((System.Drawing.Image)(resources.GetObject("bbExcluirEtapa.Image")));
            this.bbExcluirEtapa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbExcluirEtapa.Name = "bbExcluirEtapa";
            this.bbExcluirEtapa.Size = new System.Drawing.Size(64, 22);
            this.bbExcluirEtapa.Text = "Excluir";
            this.bbExcluirEtapa.ToolTipText = "Excluir Item Pedido";
            this.bbExcluirEtapa.Click += new System.EventHandler(this.bbExcluirEtapa_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // bb_cima
            // 
            this.bb_cima.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bb_cima.Image = ((System.Drawing.Image)(resources.GetObject("bb_cima.Image")));
            this.bb_cima.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cima.Name = "bb_cima";
            this.bb_cima.Size = new System.Drawing.Size(23, 22);
            this.bb_cima.Text = "toolStripButton18";
            this.bb_cima.ToolTipText = "Mover para Cima";
            this.bb_cima.Click += new System.EventHandler(this.bb_cima_Click);
            // 
            // bb_baixo
            // 
            this.bb_baixo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bb_baixo.Image = ((System.Drawing.Image)(resources.GetObject("bb_baixo.Image")));
            this.bb_baixo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_baixo.Name = "bb_baixo";
            this.bb_baixo.Size = new System.Drawing.Size(23, 22);
            this.bb_baixo.Text = "toolStripButton19";
            this.bb_baixo.ToolTipText = "Mover para  Baixo";
            this.bb_baixo.Click += new System.EventHandler(this.bb_baixo_Click);
            // 
            // Cd_conta_CTBstr
            // 
            this.Cd_conta_CTBstr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_conta_CTBstr.DataPropertyName = "Cd_conta_CTBstr";
            this.Cd_conta_CTBstr.HeaderText = "CD.conta";
            this.Cd_conta_CTBstr.Name = "Cd_conta_CTBstr";
            this.Cd_conta_CTBstr.ReadOnly = true;
            // 
            // DS_Conta
            // 
            this.DS_Conta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DS_Conta.DataPropertyName = "DS_Conta";
            this.DS_Conta.HeaderText = "Conta";
            this.DS_Conta.Name = "DS_Conta";
            this.DS_Conta.ReadOnly = true;
            // 
            // dSEtapaDataGridViewTextBoxColumn
            // 
            this.dSEtapaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSEtapaDataGridViewTextBoxColumn.DataPropertyName = "DS_Etapa";
            this.dSEtapaDataGridViewTextBoxColumn.HeaderText = "Etapa";
            this.dSEtapaDataGridViewTextBoxColumn.Name = "dSEtapaDataGridViewTextBoxColumn";
            this.dSEtapaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSEtapaDataGridViewTextBoxColumn.Width = 60;
            // 
            // sTFecharPedBoolDataGridViewCheckBoxColumn
            // 
            this.sTFecharPedBoolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sTFecharPedBoolDataGridViewCheckBoxColumn.DataPropertyName = "ST_FecharPedBool";
            this.sTFecharPedBoolDataGridViewCheckBoxColumn.HeaderText = "Fechamento";
            this.sTFecharPedBoolDataGridViewCheckBoxColumn.Name = "sTFecharPedBoolDataGridViewCheckBoxColumn";
            this.sTFecharPedBoolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.sTFecharPedBoolDataGridViewCheckBoxColumn.Width = 72;
            // 
            // ST_LiberarExpedBool
            // 
            this.ST_LiberarExpedBool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ST_LiberarExpedBool.DataPropertyName = "ST_LiberarExpedBool";
            this.ST_LiberarExpedBool.HeaderText = "Liberar Expedição";
            this.ST_LiberarExpedBool.Name = "ST_LiberarExpedBool";
            this.ST_LiberarExpedBool.ReadOnly = true;
            this.ST_LiberarExpedBool.Width = 88;
            // 
            // iDProcessostrDataGridViewTextBoxColumn
            // 
            this.iDProcessostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDProcessostrDataGridViewTextBoxColumn.DataPropertyName = "ID_Processo";
            this.iDProcessostrDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.iDProcessostrDataGridViewTextBoxColumn.Name = "iDProcessostrDataGridViewTextBoxColumn";
            this.iDProcessostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDProcessostrDataGridViewTextBoxColumn.Width = 65;
            // 
            // dSProcessoDataGridViewTextBoxColumn
            // 
            this.dSProcessoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSProcessoDataGridViewTextBoxColumn.DataPropertyName = "DS_Processo";
            this.dSProcessoDataGridViewTextBoxColumn.HeaderText = "Processo";
            this.dSProcessoDataGridViewTextBoxColumn.Name = "dSProcessoDataGridViewTextBoxColumn";
            this.dSProcessoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSProcessoDataGridViewTextBoxColumn.Width = 76;
            // 
            // TFCadEtapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 435);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.barraMenu);
            this.Name = "TFCadEtapa";
            this.Text = "Cadastro de etapa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FCadEtapa_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProcesso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProcessor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEtapa)).EndInit();
            this.tsProcesso.ResumeLayout(false);
            this.tsProcesso.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEtapa)).EndInit();
            this.tsEtapa.ResumeLayout(false);
            this.tsEtapa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_conta_CTBstr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DS_Conta;
        private System.Windows.Forms.Panel panel1;
        private Componentes.DataGridDefault gridEtapa;
        private System.Windows.Forms.Panel panel2;
        private Componentes.DataGridDefault gridProcesso;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault editDefault2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip tsEtapa;
        private System.Windows.Forms.ToolStripButton bbInserirEtapa;
        private System.Windows.Forms.ToolStripButton bbAlterarEtapa;
        private System.Windows.Forms.ToolStripButton bbExcluirEtapa;
        private System.Windows.Forms.ToolStrip tsProcesso;
        private System.Windows.Forms.ToolStripButton bbInserirProcesso;
        private System.Windows.Forms.ToolStripButton bbAlterarProcesso;
        private System.Windows.Forms.ToolStripButton bbExcluirProcesso;
        private System.Windows.Forms.BindingSource bsEtapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDEtapaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDEtapaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDEtapastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton bb_cima;
        private System.Windows.Forms.ToolStripButton bb_baixo;
        private System.Windows.Forms.BindingSource bsProcessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDProcessostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSProcessoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSEtapaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sTFecharPedBoolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ST_LiberarExpedBool;
    }
}