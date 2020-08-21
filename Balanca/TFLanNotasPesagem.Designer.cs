namespace Balanca
{
    partial class TFLanNotasPesagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanNotasPesagem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.qtd_desdobro = new System.Windows.Forms.ToolStripTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.dt_emissao = new Componentes.EditMask(this.components);
            this.qtd_nota = new Componentes.EditFloat(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.vl_basecalc = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.vl_icms = new Componentes.EditFloat(this.components);
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pc_desdobro = new Componentes.EditFloat(this.components);
            this.ds_serie = new Componentes.EditDefault(this.components);
            this.bb_serie = new System.Windows.Forms.Button();
            this.nr_serie = new Componentes.EditDefault(this.components);
            this.nr_notafiscal = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.gNotasDesdobro = new Componentes.DataGridDefault(this.components);
            this.bsBalProdutos = new System.Windows.Forms.BindingSource(this.components);
            this.fnr_notafiscal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fnr_serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fdt_emissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fqtd_nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fvl_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fvl_subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fvl_basecalc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fvl_icms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fpc_desdobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_nota)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_basecalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_icms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desdobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNotasDesdobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBalProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Excluir,
            this.BB_Gravar,
            this.toolStripSeparator1,
            this.BB_Fechar,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.qtd_desdobro});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(780, 43);
            this.barraMenu.TabIndex = 2;
            // 
            // BB_Novo
            // 
            this.BB_Novo.AutoSize = false;
            this.BB_Novo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Novo.Image")));
            this.BB_Novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Novo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Novo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BB_Novo.Size = new System.Drawing.Size(75, 40);
            this.BB_Novo.Text = "(F2)Novo";
            this.BB_Novo.ToolTipText = "Novo Registro";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(75, 40);
            this.BB_Excluir.Text = "(F5)";
            this.BB_Excluir.ToolTipText = "Excluir Registro";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(75, 40);
            this.BB_Gravar.Text = "(F4)";
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
            this.BB_Fechar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(50, 40);
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Green;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(90, 40);
            this.toolStripLabel1.Text = "Qtd. Desdobro:";
            // 
            // qtd_desdobro
            // 
            this.qtd_desdobro.Enabled = false;
            this.qtd_desdobro.Name = "qtd_desdobro";
            this.qtd_desdobro.Size = new System.Drawing.Size(50, 43);
            this.qtd_desdobro.Text = "0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pDados, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gNotasDesdobro, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.69471F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.30529F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 399);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pDados
            // 
            this.pDados.BackColor = System.Drawing.SystemColors.Control;
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.dt_emissao);
            this.pDados.Controls.Add(this.qtd_nota);
            this.pDados.Controls.Add(this.groupBox1);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.pc_desdobro);
            this.pDados.Controls.Add(this.ds_serie);
            this.pDados.Controls.Add(this.bb_serie);
            this.pDados.Controls.Add(this.nr_serie);
            this.pDados.Controls.Add(this.nr_notafiscal);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.lblProduto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pDados.Location = new System.Drawing.Point(6, 6);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(768, 141);
            this.pDados.TabIndex = 0;
            // 
            // dt_emissao
            // 
            this.dt_emissao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBalProdutos, "Dt_emissao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_emissao.Enabled = false;
            this.dt_emissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_emissao.Location = new System.Drawing.Point(99, 80);
            this.dt_emissao.Mask = "00/00/0000";
            this.dt_emissao.Name = "dt_emissao";
            this.dt_emissao.NM_Alias = "a";
            this.dt_emissao.NM_Campo = "dt_emissao";
            this.dt_emissao.NM_CampoBusca = "dt_emissao";
            this.dt_emissao.NM_Param = "@P_DT_EMISSAO";
            this.dt_emissao.Size = new System.Drawing.Size(68, 20);
            this.dt_emissao.ST_Gravar = true;
            this.dt_emissao.ST_LimpaCampo = true;
            this.dt_emissao.ST_NotNull = false;
            this.dt_emissao.ST_PrimaryKey = false;
            this.dt_emissao.TabIndex = 3;
            this.dt_emissao.ValidatingType = typeof(System.DateTime);
            // 
            // qtd_nota
            // 
            this.qtd_nota.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBalProdutos, "Qtd_nota", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"));
            this.qtd_nota.Enabled = false;
            this.qtd_nota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtd_nota.Location = new System.Drawing.Point(436, 80);
            this.qtd_nota.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.qtd_nota.Name = "qtd_nota";
            this.qtd_nota.NM_Alias = "a";
            this.qtd_nota.NM_Campo = "qtd_nota";
            this.qtd_nota.NM_Param = "@P_QTD_NOTA";
            this.qtd_nota.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.qtd_nota.Size = new System.Drawing.Size(100, 20);
            this.qtd_nota.ST_AutoInc = false;
            this.qtd_nota.ST_DisableAuto = false;
            this.qtd_nota.ST_Gravar = true;
            this.qtd_nota.ST_LimparCampo = true;
            this.qtd_nota.ST_NotNull = false;
            this.qtd_nota.ST_PrimaryKey = false;
            this.qtd_nota.TabIndex = 5;
            this.qtd_nota.Leave += new System.EventHandler(this.qtd_nota_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelDados1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(544, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 128);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valores Nota Fiscal:";
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.vl_basecalc);
            this.panelDados1.Controls.Add(this.label8);
            this.panelDados1.Controls.Add(this.vl_unitario);
            this.panelDados1.Controls.Add(this.vl_icms);
            this.panelDados1.Controls.Add(this.vl_subtotal);
            this.panelDados1.Controls.Add(this.label9);
            this.panelDados1.Controls.Add(this.label6);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDados1.Location = new System.Drawing.Point(7, 14);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(200, 110);
            this.panelDados1.TabIndex = 0;
            // 
            // vl_basecalc
            // 
            this.vl_basecalc.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBalProdutos, "Vl_basecalc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.vl_basecalc.DecimalPlaces = 2;
            this.vl_basecalc.Enabled = false;
            this.vl_basecalc.Location = new System.Drawing.Point(89, 58);
            this.vl_basecalc.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.vl_basecalc.Name = "vl_basecalc";
            this.vl_basecalc.NM_Alias = "a";
            this.vl_basecalc.NM_Campo = "vl_basecalc";
            this.vl_basecalc.NM_Param = "@P_VL_BASECALC";
            this.vl_basecalc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_basecalc.Size = new System.Drawing.Size(105, 20);
            this.vl_basecalc.ST_AutoInc = false;
            this.vl_basecalc.ST_DisableAuto = false;
            this.vl_basecalc.ST_Gravar = true;
            this.vl_basecalc.ST_LimparCampo = true;
            this.vl_basecalc.ST_NotNull = false;
            this.vl_basecalc.ST_PrimaryKey = false;
            this.vl_basecalc.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Valor B. Calc:";
            // 
            // vl_unitario
            // 
            this.vl_unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBalProdutos, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N6"));
            this.vl_unitario.DecimalPlaces = 7;
            this.vl_unitario.Enabled = false;
            this.vl_unitario.Location = new System.Drawing.Point(89, 10);
            this.vl_unitario.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.vl_unitario.Name = "vl_unitario";
            this.vl_unitario.NM_Alias = "a";
            this.vl_unitario.NM_Campo = "vl_unitario";
            this.vl_unitario.NM_Param = "@P_VL_UNITARIO";
            this.vl_unitario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_unitario.Size = new System.Drawing.Size(105, 20);
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = true;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = false;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.TabIndex = 0;
            this.vl_unitario.Leave += new System.EventHandler(this.vl_unitario_Leave);
            // 
            // vl_icms
            // 
            this.vl_icms.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBalProdutos, "Vl_icms", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.vl_icms.DecimalPlaces = 2;
            this.vl_icms.Enabled = false;
            this.vl_icms.Location = new System.Drawing.Point(89, 83);
            this.vl_icms.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.vl_icms.Name = "vl_icms";
            this.vl_icms.NM_Alias = "a";
            this.vl_icms.NM_Campo = "vl_icms";
            this.vl_icms.NM_Param = "@P_VL_ICMS";
            this.vl_icms.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_icms.Size = new System.Drawing.Size(105, 20);
            this.vl_icms.ST_AutoInc = false;
            this.vl_icms.ST_DisableAuto = false;
            this.vl_icms.ST_Gravar = true;
            this.vl_icms.ST_LimparCampo = true;
            this.vl_icms.ST_NotNull = false;
            this.vl_icms.ST_PrimaryKey = false;
            this.vl_icms.TabIndex = 3;
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBalProdutos, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Enabled = false;
            this.vl_subtotal.Location = new System.Drawing.Point(89, 34);
            this.vl_subtotal.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.vl_subtotal.Name = "vl_subtotal";
            this.vl_subtotal.NM_Alias = "a";
            this.vl_subtotal.NM_Campo = "vl_subtotal";
            this.vl_subtotal.NM_Param = "@P_VL_SUBTOTAL";
            this.vl_subtotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_subtotal.Size = new System.Drawing.Size(105, 20);
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = true;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = false;
            this.vl_subtotal.ST_PrimaryKey = false;
            this.vl_subtotal.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "Valor ICMS:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "Valor Unitário:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Valor NF:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Peso NF:";
            // 
            // pc_desdobro
            // 
            this.pc_desdobro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBalProdutos, "Pc_desdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N3"));
            this.pc_desdobro.DecimalPlaces = 3;
            this.pc_desdobro.Enabled = false;
            this.pc_desdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pc_desdobro.Location = new System.Drawing.Point(251, 80);
            this.pc_desdobro.Name = "pc_desdobro";
            this.pc_desdobro.NM_Alias = "a";
            this.pc_desdobro.NM_Campo = "pc_desdobro";
            this.pc_desdobro.NM_Param = "@P_PC_DESDOBRO";
            this.pc_desdobro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pc_desdobro.Size = new System.Drawing.Size(100, 20);
            this.pc_desdobro.ST_AutoInc = false;
            this.pc_desdobro.ST_DisableAuto = false;
            this.pc_desdobro.ST_Gravar = true;
            this.pc_desdobro.ST_LimparCampo = true;
            this.pc_desdobro.ST_NotNull = false;
            this.pc_desdobro.ST_PrimaryKey = false;
            this.pc_desdobro.TabIndex = 4;
            // 
            // ds_serie
            // 
            this.ds_serie.BackColor = System.Drawing.SystemColors.Window;
            this.ds_serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_serie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBalProdutos, "Ds_serienf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_serie.Enabled = false;
            this.ds_serie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ds_serie.Location = new System.Drawing.Point(338, 55);
            this.ds_serie.Name = "ds_serie";
            this.ds_serie.NM_Alias = "";
            this.ds_serie.NM_Campo = "ds_serienf";
            this.ds_serie.NM_CampoBusca = "ds_serienf";
            this.ds_serie.NM_Param = "@P_DS_SERIE";
            this.ds_serie.QTD_Zero = 0;
            this.ds_serie.Size = new System.Drawing.Size(198, 20);
            this.ds_serie.ST_AutoInc = false;
            this.ds_serie.ST_DisableAuto = false;
            this.ds_serie.ST_Float = false;
            this.ds_serie.ST_Gravar = false;
            this.ds_serie.ST_Int = false;
            this.ds_serie.ST_LimpaCampo = true;
            this.ds_serie.ST_NotNull = false;
            this.ds_serie.ST_PrimaryKey = false;
            this.ds_serie.TabIndex = 60;
            // 
            // bb_serie
            // 
            this.bb_serie.Enabled = false;
            this.bb_serie.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_serie.Image = ((System.Drawing.Image)(resources.GetObject("bb_serie.Image")));
            this.bb_serie.Location = new System.Drawing.Point(302, 55);
            this.bb_serie.Name = "bb_serie";
            this.bb_serie.Size = new System.Drawing.Size(30, 20);
            this.bb_serie.TabIndex = 2;
            this.bb_serie.UseVisualStyleBackColor = true;
            this.bb_serie.Click += new System.EventHandler(this.bb_serie_Click);
            // 
            // nr_serie
            // 
            this.nr_serie.BackColor = System.Drawing.SystemColors.Window;
            this.nr_serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_serie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBalProdutos, "Nr_serie", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_serie.Enabled = false;
            this.nr_serie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nr_serie.Location = new System.Drawing.Point(251, 55);
            this.nr_serie.MaxLength = 5;
            this.nr_serie.Name = "nr_serie";
            this.nr_serie.NM_Alias = "a";
            this.nr_serie.NM_Campo = "nr_serie";
            this.nr_serie.NM_CampoBusca = "nr_serie";
            this.nr_serie.NM_Param = "@P_NR_SERIE";
            this.nr_serie.QTD_Zero = 0;
            this.nr_serie.Size = new System.Drawing.Size(51, 20);
            this.nr_serie.ST_AutoInc = false;
            this.nr_serie.ST_DisableAuto = false;
            this.nr_serie.ST_Float = false;
            this.nr_serie.ST_Gravar = true;
            this.nr_serie.ST_Int = false;
            this.nr_serie.ST_LimpaCampo = true;
            this.nr_serie.ST_NotNull = false;
            this.nr_serie.ST_PrimaryKey = false;
            this.nr_serie.TabIndex = 1;
            this.nr_serie.Leave += new System.EventHandler(this.nr_serie_Leave);
            // 
            // nr_notafiscal
            // 
            this.nr_notafiscal.BackColor = System.Drawing.SystemColors.Window;
            this.nr_notafiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_notafiscal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBalProdutos, "Nr_notafiscal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_notafiscal.Enabled = false;
            this.nr_notafiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nr_notafiscal.Location = new System.Drawing.Point(99, 54);
            this.nr_notafiscal.MaxLength = 9;
            this.nr_notafiscal.Name = "nr_notafiscal";
            this.nr_notafiscal.NM_Alias = "a";
            this.nr_notafiscal.NM_Campo = "nr_notafiscal";
            this.nr_notafiscal.NM_CampoBusca = "nr_notafiscal";
            this.nr_notafiscal.NM_Param = "@P_NR_NOTAFISCAL";
            this.nr_notafiscal.QTD_Zero = 0;
            this.nr_notafiscal.Size = new System.Drawing.Size(68, 20);
            this.nr_notafiscal.ST_AutoInc = false;
            this.nr_notafiscal.ST_DisableAuto = false;
            this.nr_notafiscal.ST_Float = false;
            this.nr_notafiscal.ST_Gravar = true;
            this.nr_notafiscal.ST_Int = false;
            this.nr_notafiscal.ST_LimpaCampo = true;
            this.nr_notafiscal.ST_NotNull = false;
            this.nr_notafiscal.ST_PrimaryKey = false;
            this.nr_notafiscal.TabIndex = 0;
            this.nr_notafiscal.Leave += new System.EventHandler(this.nr_notafiscal_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data Emissão:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "% Desdobro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Núm. Série:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nota Fiscal:";
            // 
            // lblProduto
            // 
            this.lblProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(213)))), ((int)(((byte)(153)))));
            this.lblProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblProduto.Location = new System.Drawing.Point(11, 10);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(527, 23);
            this.lblProduto.TabIndex = 0;
            this.lblProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gNotasDesdobro
            // 
            this.gNotasDesdobro.AllowUserToAddRows = false;
            this.gNotasDesdobro.AllowUserToDeleteRows = false;
            this.gNotasDesdobro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gNotasDesdobro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gNotasDesdobro.AutoGenerateColumns = false;
            this.gNotasDesdobro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gNotasDesdobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gNotasDesdobro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gNotasDesdobro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gNotasDesdobro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fnr_notafiscal,
            this.fnr_serie,
            this.fdt_emissao,
            this.fqtd_nota,
            this.fvl_unitario,
            this.fvl_subtotal,
            this.fvl_basecalc,
            this.fvl_icms,
            this.fpc_desdobro});
            this.gNotasDesdobro.DataSource = this.bsBalProdutos;
            this.gNotasDesdobro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gNotasDesdobro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gNotasDesdobro.Location = new System.Drawing.Point(6, 156);
            this.gNotasDesdobro.Name = "gNotasDesdobro";
            this.gNotasDesdobro.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gNotasDesdobro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gNotasDesdobro.RowHeadersWidth = 23;
            this.gNotasDesdobro.Size = new System.Drawing.Size(768, 237);
            this.gNotasDesdobro.TabIndex = 1;
            this.gNotasDesdobro.CurrentCellChanged += new System.EventHandler(this.gNotasDesdobro_CurrentCellChanged);
            // 
            // bsBalProdutos
            // 
            this.bsBalProdutos.DataSource = typeof(CamadaDados.Balanca.TList_RegLanPesagemProduto);
            // 
            // fnr_notafiscal
            // 
            this.fnr_notafiscal.DataPropertyName = "Nr_notafiscal";
            this.fnr_notafiscal.HeaderText = "Nota Fiscal";
            this.fnr_notafiscal.Name = "fnr_notafiscal";
            this.fnr_notafiscal.ReadOnly = true;
            this.fnr_notafiscal.Width = 90;
            // 
            // fnr_serie
            // 
            this.fnr_serie.DataPropertyName = "Nr_serie";
            this.fnr_serie.HeaderText = "Série";
            this.fnr_serie.Name = "fnr_serie";
            this.fnr_serie.ReadOnly = true;
            this.fnr_serie.Width = 40;
            // 
            // fdt_emissao
            // 
            this.fdt_emissao.DataPropertyName = "Dt_emissao";
            this.fdt_emissao.HeaderText = "Dt. Emissão";
            this.fdt_emissao.Name = "fdt_emissao";
            this.fdt_emissao.ReadOnly = true;
            this.fdt_emissao.Width = 70;
            // 
            // fqtd_nota
            // 
            this.fqtd_nota.DataPropertyName = "Qtd_nota";
            this.fqtd_nota.HeaderText = "Peso NF";
            this.fqtd_nota.Name = "fqtd_nota";
            this.fqtd_nota.ReadOnly = true;
            this.fqtd_nota.Width = 80;
            // 
            // fvl_unitario
            // 
            this.fvl_unitario.DataPropertyName = "Vl_unitario";
            this.fvl_unitario.HeaderText = "Vl. Unitário";
            this.fvl_unitario.Name = "fvl_unitario";
            this.fvl_unitario.ReadOnly = true;
            this.fvl_unitario.Width = 90;
            // 
            // fvl_subtotal
            // 
            this.fvl_subtotal.DataPropertyName = "Vl_subtotal";
            this.fvl_subtotal.HeaderText = "Valor NF";
            this.fvl_subtotal.Name = "fvl_subtotal";
            this.fvl_subtotal.ReadOnly = true;
            this.fvl_subtotal.Width = 80;
            // 
            // fvl_basecalc
            // 
            this.fvl_basecalc.DataPropertyName = "Vl_basecalc";
            this.fvl_basecalc.HeaderText = "Vl. Base Calc.";
            this.fvl_basecalc.Name = "fvl_basecalc";
            this.fvl_basecalc.ReadOnly = true;
            // 
            // fvl_icms
            // 
            this.fvl_icms.DataPropertyName = "Vl_icms";
            this.fvl_icms.HeaderText = "Valor ICMS";
            this.fvl_icms.Name = "fvl_icms";
            this.fvl_icms.ReadOnly = true;
            this.fvl_icms.Width = 90;
            // 
            // fpc_desdobro
            // 
            this.fpc_desdobro.DataPropertyName = "Pc_desdobro";
            this.fpc_desdobro.HeaderText = "% Desdobro";
            this.fpc_desdobro.Name = "fpc_desdobro";
            this.fpc_desdobro.ReadOnly = true;
            // 
            // TFLanNotasPesagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 446);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanNotasPesagem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notas Fiscais de Pesagem";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanNotasPesagem_KeyDown);
            this.Load += new System.EventHandler(this.TFLanNotasPesagem_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_nota)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_basecalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_icms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desdobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNotasDesdobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBalProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados pDados;
        private Componentes.DataGridDefault gNotasDesdobro;
        public System.Windows.Forms.Label lblProduto;
        public System.Windows.Forms.ToolStripTextBox qtd_desdobro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault nr_serie;
        private Componentes.EditDefault nr_notafiscal;
        public System.Windows.Forms.Button bb_serie;
        private Componentes.EditDefault ds_serie;
        private Componentes.EditFloat pc_desdobro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat vl_icms;
        private Componentes.EditFloat vl_basecalc;
        private Componentes.EditFloat vl_subtotal;
        private Componentes.EditFloat vl_unitario;
        private Componentes.EditFloat qtd_nota;
        private System.Windows.Forms.GroupBox groupBox1;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditMask dt_emissao;
        private System.Windows.Forms.BindingSource bsBalProdutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnr_notafiscal;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnr_serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn fdt_emissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn fqtd_nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn fvl_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fvl_subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn fvl_basecalc;
        private System.Windows.Forms.DataGridViewTextBoxColumn fvl_icms;
        private System.Windows.Forms.DataGridViewTextBoxColumn fpc_desdobro;
    }
}