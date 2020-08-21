namespace Frota.Cadastros
{
    partial class TFPneu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFPneu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpPneu = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.dsobservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFotoPneu = new System.Windows.Forms.BindingSource(this.components);
            this.bsPneus = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.TS_Rota = new System.Windows.Forms.ToolStrip();
            this.ts_btn_InserirFoto = new System.Windows.Forms.ToolStripButton();
            this.ts_btn_DeletarFoto = new System.Windows.Forms.ToolStripButton();
            this.ptbImagem = new System.Windows.Forms.PictureBox();
            this.pDadosPneu = new Componentes.PanelDados(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.nr_serieFabric = new Componentes.EditMask(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpPneu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFotoPneu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPneus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.TS_Rota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagem)).BeginInit();
            this.pDadosPneu.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(883, 43);
            this.barraMenu.TabIndex = 5;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // tlpPneu
            // 
            this.tlpPneu.ColumnCount = 1;
            this.tlpPneu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPneu.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tlpPneu.Controls.Add(this.pDadosPneu, 0, 0);
            this.tlpPneu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPneu.Location = new System.Drawing.Point(0, 43);
            this.tlpPneu.Name = "tlpPneu";
            this.tlpPneu.RowCount = 2;
            this.tlpPneu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.04918F));
            this.tlpPneu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.95082F));
            this.tlpPneu.Size = new System.Drawing.Size(883, 483);
            this.tlpPneu.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.59179F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.40821F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptbImagem, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 133);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(877, 347);
            this.tableLayoutPanel1.TabIndex = 153;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.dataGridDefault1);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Controls.Add(this.TS_Rota);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(463, 341);
            this.panelDados1.TabIndex = 1;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dsobservacaoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsFotoPneu;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 25);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(463, 291);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // dsobservacaoDataGridViewTextBoxColumn
            // 
            this.dsobservacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_observacao";
            this.dsobservacaoDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.dsobservacaoDataGridViewTextBoxColumn.Name = "dsobservacaoDataGridViewTextBoxColumn";
            this.dsobservacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsobservacaoDataGridViewTextBoxColumn.Width = 90;
            // 
            // bsFotoPneu
            // 
            this.bsFotoPneu.DataMember = "lPneu";
            this.bsFotoPneu.DataSource = this.bsPneus;
            // 
            // bsPneus
            // 
            this.bsPneus.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_LanPneu);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsFotoPneu;
            this.bindingNavigator1.CountItem = this.toolStripLabel1;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton6});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 316);
            this.bindingNavigator1.MoveFirstItem = this.toolStripButton3;
            this.bindingNavigator1.MoveLastItem = this.toolStripButton6;
            this.bindingNavigator1.MoveNextItem = this.toolStripButton5;
            this.bindingNavigator1.MovePreviousItem = this.toolStripButton4;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.toolStripTextBox1;
            this.bindingNavigator1.Size = new System.Drawing.Size(463, 25);
            this.bindingNavigator1.TabIndex = 48;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel1.Text = "de {0}";
            this.toolStripLabel1.ToolTipText = "Total Registros";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Primeiro Registro";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Registro Anterior";
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
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 21);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Registro Corrente";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Proximo Registro";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Ultimo Registro";
            // 
            // TS_Rota
            // 
            this.TS_Rota.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_btn_InserirFoto,
            this.ts_btn_DeletarFoto});
            this.TS_Rota.Location = new System.Drawing.Point(0, 0);
            this.TS_Rota.Name = "TS_Rota";
            this.TS_Rota.Size = new System.Drawing.Size(463, 25);
            this.TS_Rota.TabIndex = 45;
            // 
            // ts_btn_InserirFoto
            // 
            this.ts_btn_InserirFoto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ts_btn_InserirFoto.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_InserirFoto.Image")));
            this.ts_btn_InserirFoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btn_InserirFoto.Name = "ts_btn_InserirFoto";
            this.ts_btn_InserirFoto.Size = new System.Drawing.Size(141, 22);
            this.ts_btn_InserirFoto.Text = "(CTRL + F10) Inserir";
            this.ts_btn_InserirFoto.Click += new System.EventHandler(this.ts_btn_InserirFoto_Click);
            // 
            // ts_btn_DeletarFoto
            // 
            this.ts_btn_DeletarFoto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ts_btn_DeletarFoto.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_DeletarFoto.Image")));
            this.ts_btn_DeletarFoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btn_DeletarFoto.Name = "ts_btn_DeletarFoto";
            this.ts_btn_DeletarFoto.Size = new System.Drawing.Size(140, 22);
            this.ts_btn_DeletarFoto.Text = "(CTRL + F12) Excluir";
            this.ts_btn_DeletarFoto.Click += new System.EventHandler(this.ts_btn_DeletarFoto_Click);
            // 
            // ptbImagem
            // 
            this.ptbImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbImagem.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.bsFotoPneu, "Imagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ptbImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbImagem.Location = new System.Drawing.Point(472, 3);
            this.ptbImagem.Name = "ptbImagem";
            this.ptbImagem.Size = new System.Drawing.Size(402, 341);
            this.ptbImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbImagem.TabIndex = 2;
            this.ptbImagem.TabStop = false;
            this.ptbImagem.DoubleClick += new System.EventHandler(this.ptbImagem_DoubleClick);
            // 
            // pDadosPneu
            // 
            this.pDadosPneu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDadosPneu.Controls.Add(this.label13);
            this.pDadosPneu.Controls.Add(this.ds_observacao);
            this.pDadosPneu.Controls.Add(this.nm_empresa);
            this.pDadosPneu.Controls.Add(this.label4);
            this.pDadosPneu.Controls.Add(this.bb_empresa);
            this.pDadosPneu.Controls.Add(this.cd_empresa);
            this.pDadosPneu.Controls.Add(this.nr_serieFabric);
            this.pDadosPneu.Controls.Add(this.label5);
            this.pDadosPneu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDadosPneu.Location = new System.Drawing.Point(3, 3);
            this.pDadosPneu.Name = "pDadosPneu";
            this.pDadosPneu.NM_ProcDeletar = "";
            this.pDadosPneu.NM_ProcGravar = "";
            this.pDadosPneu.Size = new System.Drawing.Size(877, 124);
            this.pDadosPneu.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(37, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 152;
            this.label13.Text = "Obs:";
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPneus, "DS_Observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(77, 61);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(777, 56);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 18;
            this.ds_observacao.TextOld = null;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPneus, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(176, 9);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(678, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 137;
            this.nm_empresa.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 138;
            this.label4.Text = "Empresa:";
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(142, 9);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPneus, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(77, 9);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(59, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // nr_serieFabric
            // 
            this.nr_serieFabric.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPneus, "Nr_serieFabricacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_serieFabric.Location = new System.Drawing.Point(77, 35);
            this.nr_serieFabric.Name = "nr_serieFabric";
            this.nr_serieFabric.NM_Alias = "";
            this.nr_serieFabric.NM_Campo = "";
            this.nr_serieFabric.NM_CampoBusca = "";
            this.nr_serieFabric.NM_Param = "";
            this.nr_serieFabric.Size = new System.Drawing.Size(104, 20);
            this.nr_serieFabric.ST_Gravar = true;
            this.nr_serieFabric.ST_LimpaCampo = true;
            this.nr_serieFabric.ST_NotNull = true;
            this.nr_serieFabric.ST_PrimaryKey = false;
            this.nr_serieFabric.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 121;
            this.label5.Text = "Nr.Série:";
            // 
            // TFPneu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 526);
            this.Controls.Add(this.tlpPneu);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFPneu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Pneus";
            this.Load += new System.EventHandler(this.TFPneu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFPneu_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpPneu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFotoPneu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPneus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.TS_Rota.ResumeLayout(false);
            this.TS_Rota.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagem)).EndInit();
            this.pDadosPneu.ResumeLayout(false);
            this.pDadosPneu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsPneus;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpPneu;
        private Componentes.PanelDados pDadosPneu;
        private Componentes.EditMask nr_serieFabric;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.BindingSource bsFotoPneu;
        private Componentes.DataGridDefault dataGridDefault1;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.ToolStrip TS_Rota;
        private System.Windows.Forms.ToolStripButton ts_btn_InserirFoto;
        private System.Windows.Forms.ToolStripButton ts_btn_DeletarFoto;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox ptbImagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn;
    }
}