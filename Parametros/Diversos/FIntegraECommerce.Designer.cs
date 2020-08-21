namespace Parametros.Diversos
{
    partial class TFIntegraECommerce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFIntegraECommerce));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Sincronizar = new System.Windows.Forms.ToolStripButton();
            this.BB_Iniciar = new System.Windows.Forms.ToolStripSplitButton();
            this.iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sincronizarPedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BB_Parar = new System.Windows.Forms.ToolStripSplitButton();
            this.sincronizarCadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sincronizarPedidosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tcCentral = new System.Windows.Forms.TabControl();
            this.tpCfgServico = new System.Windows.Forms.TabPage();
            this.pConfig = new Componentes.PanelDados(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.tmp3 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tmp2 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tmp_atualizapedido = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.rgTempo = new Componentes.RadioGroup(this.components);
            this.rbTempo3 = new Componentes.RadioButtonDefault(this.components);
            this.rbTempo2 = new Componentes.RadioButtonDefault(this.components);
            this.rbTempo1 = new Componentes.RadioButtonDefault(this.components);
            this.dt_sincronizar = new Componentes.EditData(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cb_sincronizarauto = new Componentes.CheckBoxDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbItemSincronizar = new Componentes.ComboBoxDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.st_cadastro = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.st_pedido = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmp1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.tpSincManual = new System.Windows.Forms.TabPage();
            this.tlpSincManual = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.DT_Final = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.DT_Inicial = new Componentes.EditData(this.components);
            this.label69 = new System.Windows.Forms.Label();
            this.tlpSinc = new System.Windows.Forms.TableLayoutPanel();
            this.cbSincClientes = new Componentes.CheckBoxDefault(this.components);
            this.cbSincPrecoProd = new Componentes.CheckBoxDefault(this.components);
            this.cbSincCondPgto = new Componentes.CheckBoxDefault(this.components);
            this.cbSincTabPreco = new Componentes.CheckBoxDefault(this.components);
            this.cbSincImagens = new Componentes.CheckBoxDefault(this.components);
            this.cbSincProdutos = new Componentes.CheckBoxDefault(this.components);
            this.cbSincOpcoesEnvio = new Componentes.CheckBoxDefault(this.components);
            this.cbSincCategoriaProdutos = new Componentes.CheckBoxDefault(this.components);
            this.cbSincPedidos = new Componentes.CheckBoxDefault(this.components);
            this.cbSincClienteXTpProduto = new Componentes.CheckBoxDefault(this.components);
            this.cbSincTpProduto = new Componentes.CheckBoxDefault(this.components);
            this.cbSincEnderecos = new Componentes.CheckBoxDefault(this.components);
            this.scIntegraEcommerce = new System.ServiceProcess.ServiceController();
            this.tempo = new System.Windows.Forms.Timer(this.components);
            this.scIntegraPedido = new System.ServiceProcess.ServiceController();
            this.barraMenu.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpCfgServico.SuspendLayout();
            this.pConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmp_atualizapedido)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.rgTempo.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmp1)).BeginInit();
            this.tpSincManual.SuspendLayout();
            this.tlpSincManual.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.tlpSinc.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Sincronizar,
            this.BB_Iniciar,
            this.BB_Parar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(791, 43);
            this.barraMenu.TabIndex = 7;
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
            this.BB_Gravar.Size = new System.Drawing.Size(95, 40);
            this.BB_Gravar.Text = " (F4)\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Sincronizar
            // 
            this.BB_Sincronizar.AutoSize = false;
            this.BB_Sincronizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Sincronizar.ForeColor = System.Drawing.Color.Green;
            this.BB_Sincronizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Sincronizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Sincronizar.Name = "BB_Sincronizar";
            this.BB_Sincronizar.Size = new System.Drawing.Size(95, 40);
            this.BB_Sincronizar.Text = "(F9)\r\nSincronizar";
            this.BB_Sincronizar.ToolTipText = "Sincronizar Itens Manualmente";
            this.BB_Sincronizar.Visible = false;
            this.BB_Sincronizar.Click += new System.EventHandler(this.BB_Sincronizar_Click);
            // 
            // BB_Iniciar
            // 
            this.BB_Iniciar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BB_Iniciar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iToolStripMenuItem,
            this.sincronizarPedidosToolStripMenuItem});
            this.BB_Iniciar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Iniciar.ForeColor = System.Drawing.Color.Green;
            this.BB_Iniciar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Iniciar.Image")));
            this.BB_Iniciar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Iniciar.Name = "BB_Iniciar";
            this.BB_Iniciar.Size = new System.Drawing.Size(130, 40);
            this.BB_Iniciar.Text = "(F5) Iniciar Serviço";
            // 
            // iToolStripMenuItem
            // 
            this.iToolStripMenuItem.Name = "iToolStripMenuItem";
            this.iToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.iToolStripMenuItem.Text = "Sincronizar Cadastros";
            this.iToolStripMenuItem.Click += new System.EventHandler(this.iToolStripMenuItem_Click);
            // 
            // sincronizarPedidosToolStripMenuItem
            // 
            this.sincronizarPedidosToolStripMenuItem.Name = "sincronizarPedidosToolStripMenuItem";
            this.sincronizarPedidosToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.sincronizarPedidosToolStripMenuItem.Text = "Sincronizar Pedidos";
            this.sincronizarPedidosToolStripMenuItem.Click += new System.EventHandler(this.sincronizarPedidosToolStripMenuItem_Click);
            // 
            // BB_Parar
            // 
            this.BB_Parar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BB_Parar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sincronizarCadastrosToolStripMenuItem,
            this.sincronizarPedidosToolStripMenuItem1});
            this.BB_Parar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Parar.ForeColor = System.Drawing.Color.Green;
            this.BB_Parar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Parar.Image")));
            this.BB_Parar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Parar.Name = "BB_Parar";
            this.BB_Parar.Size = new System.Drawing.Size(125, 40);
            this.BB_Parar.Text = "(F6) Parar Serviço";
            // 
            // sincronizarCadastrosToolStripMenuItem
            // 
            this.sincronizarCadastrosToolStripMenuItem.Name = "sincronizarCadastrosToolStripMenuItem";
            this.sincronizarCadastrosToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.sincronizarCadastrosToolStripMenuItem.Text = "Sincronizar Cadastros";
            this.sincronizarCadastrosToolStripMenuItem.Click += new System.EventHandler(this.sincronizarCadastrosToolStripMenuItem_Click);
            // 
            // sincronizarPedidosToolStripMenuItem1
            // 
            this.sincronizarPedidosToolStripMenuItem1.Name = "sincronizarPedidosToolStripMenuItem1";
            this.sincronizarPedidosToolStripMenuItem1.Size = new System.Drawing.Size(197, 22);
            this.sincronizarPedidosToolStripMenuItem1.Text = "Sincronizar Pedidos";
            this.sincronizarPedidosToolStripMenuItem1.Click += new System.EventHandler(this.sincronizarPedidosToolStripMenuItem1_Click);
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
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(75, 40);
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tcCentral
            // 
            this.tcCentral.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcCentral.Controls.Add(this.tpCfgServico);
            this.tcCentral.Controls.Add(this.tpSincManual);
            this.tcCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCentral.Location = new System.Drawing.Point(0, 43);
            this.tcCentral.Name = "tcCentral";
            this.tcCentral.SelectedIndex = 0;
            this.tcCentral.Size = new System.Drawing.Size(791, 390);
            this.tcCentral.TabIndex = 8;
            this.tcCentral.SelectedIndexChanged += new System.EventHandler(this.tcCentral_SelectedIndexChanged);
            // 
            // tpCfgServico
            // 
            this.tpCfgServico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tpCfgServico.Controls.Add(this.pConfig);
            this.tpCfgServico.Location = new System.Drawing.Point(4, 25);
            this.tpCfgServico.Name = "tpCfgServico";
            this.tpCfgServico.Padding = new System.Windows.Forms.Padding(3);
            this.tpCfgServico.Size = new System.Drawing.Size(783, 361);
            this.tpCfgServico.TabIndex = 0;
            this.tpCfgServico.Text = "CONFIGURAÇÃO SERVIÇO";
            this.tpCfgServico.UseVisualStyleBackColor = true;
            // 
            // pConfig
            // 
            this.pConfig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pConfig.Controls.Add(this.label8);
            this.pConfig.Controls.Add(this.tmp3);
            this.pConfig.Controls.Add(this.label11);
            this.pConfig.Controls.Add(this.label6);
            this.pConfig.Controls.Add(this.tmp2);
            this.pConfig.Controls.Add(this.label7);
            this.pConfig.Controls.Add(this.label4);
            this.pConfig.Controls.Add(this.tmp_atualizapedido);
            this.pConfig.Controls.Add(this.label5);
            this.pConfig.Controls.Add(this.panelDados1);
            this.pConfig.Controls.Add(this.label9);
            this.pConfig.Controls.Add(this.statusStrip1);
            this.pConfig.Controls.Add(this.tmp1);
            this.pConfig.Controls.Add(this.label10);
            this.pConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pConfig.Location = new System.Drawing.Point(3, 3);
            this.pConfig.Name = "pConfig";
            this.pConfig.NM_ProcDeletar = "";
            this.pConfig.NM_ProcGravar = "";
            this.pConfig.Size = new System.Drawing.Size(773, 351);
            this.pConfig.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Tempo 3:";
            // 
            // tmp3
            // 
            this.tmp3.Location = new System.Drawing.Point(344, 255);
            this.tmp3.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tmp3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tmp3.Name = "tmp3";
            this.tmp3.Size = new System.Drawing.Size(63, 20);
            this.tmp3.TabIndex = 20;
            this.tmp3.Value = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(413, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "minutos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Tempo 2:";
            // 
            // tmp2
            // 
            this.tmp2.Location = new System.Drawing.Point(344, 229);
            this.tmp2.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tmp2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tmp2.Name = "tmp2";
            this.tmp2.Size = new System.Drawing.Size(63, 20);
            this.tmp2.TabIndex = 17;
            this.tmp2.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "minutos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tempo de Atualização Pedidos:";
            // 
            // tmp_atualizapedido
            // 
            this.tmp_atualizapedido.Location = new System.Drawing.Point(344, 281);
            this.tmp_atualizapedido.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tmp_atualizapedido.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tmp_atualizapedido.Name = "tmp_atualizapedido";
            this.tmp_atualizapedido.Size = new System.Drawing.Size(63, 20);
            this.tmp_atualizapedido.TabIndex = 14;
            this.tmp_atualizapedido.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(413, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "minutos";
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.rgTempo);
            this.panelDados1.Controls.Add(this.dt_sincronizar);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.cb_sincronizarauto);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.cbItemSincronizar);
            this.panelDados1.Location = new System.Drawing.Point(225, 24);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(318, 166);
            this.panelDados1.TabIndex = 13;
            // 
            // rgTempo
            // 
            this.rgTempo.Controls.Add(this.rbTempo3);
            this.rgTempo.Controls.Add(this.rbTempo2);
            this.rgTempo.Controls.Add(this.rbTempo1);
            this.rgTempo.Location = new System.Drawing.Point(202, 75);
            this.rgTempo.Name = "rgTempo";
            this.rgTempo.NM_Alias = "";
            this.rgTempo.NM_Campo = "";
            this.rgTempo.NM_Param = "";
            this.rgTempo.NM_Valor = "3";
            this.rgTempo.Size = new System.Drawing.Size(92, 84);
            this.rgTempo.ST_Gravar = false;
            this.rgTempo.ST_NotNull = false;
            this.rgTempo.TabIndex = 16;
            this.rgTempo.TabStop = false;
            this.rgTempo.Text = "Prioridade:";
            // 
            // rbTempo3
            // 
            this.rbTempo3.AutoSize = true;
            this.rbTempo3.Checked = true;
            this.rbTempo3.Location = new System.Drawing.Point(6, 59);
            this.rbTempo3.Name = "rbTempo3";
            this.rbTempo3.Size = new System.Drawing.Size(67, 17);
            this.rbTempo3.TabIndex = 2;
            this.rbTempo3.TabStop = true;
            this.rbTempo3.Text = "Tempo 3";
            this.rbTempo3.UseVisualStyleBackColor = true;
            this.rbTempo3.Valor = "3";
            // 
            // rbTempo2
            // 
            this.rbTempo2.AutoSize = true;
            this.rbTempo2.Location = new System.Drawing.Point(6, 39);
            this.rbTempo2.Name = "rbTempo2";
            this.rbTempo2.Size = new System.Drawing.Size(67, 17);
            this.rbTempo2.TabIndex = 1;
            this.rbTempo2.Text = "Tempo 2";
            this.rbTempo2.UseVisualStyleBackColor = true;
            this.rbTempo2.Valor = "2";
            // 
            // rbTempo1
            // 
            this.rbTempo1.AutoSize = true;
            this.rbTempo1.Location = new System.Drawing.Point(6, 19);
            this.rbTempo1.Name = "rbTempo1";
            this.rbTempo1.Size = new System.Drawing.Size(67, 17);
            this.rbTempo1.TabIndex = 0;
            this.rbTempo1.Text = "Tempo 1";
            this.rbTempo1.UseVisualStyleBackColor = true;
            this.rbTempo1.Valor = "1";
            // 
            // dt_sincronizar
            // 
            this.dt_sincronizar.Location = new System.Drawing.Point(23, 111);
            this.dt_sincronizar.Mask = "00/00/0000 00:00:00";
            this.dt_sincronizar.Name = "dt_sincronizar";
            this.dt_sincronizar.NM_Alias = "";
            this.dt_sincronizar.NM_Campo = "";
            this.dt_sincronizar.NM_CampoBusca = "";
            this.dt_sincronizar.NM_Param = "";
            this.dt_sincronizar.Operador = "";
            this.dt_sincronizar.Size = new System.Drawing.Size(119, 20);
            this.dt_sincronizar.ST_Gravar = false;
            this.dt_sincronizar.ST_LimpaCampo = true;
            this.dt_sincronizar.ST_NotNull = false;
            this.dt_sincronizar.ST_PrimaryKey = false;
            this.dt_sincronizar.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ultima Sincronização:";
            // 
            // cb_sincronizarauto
            // 
            this.cb_sincronizarauto.AutoSize = true;
            this.cb_sincronizarauto.Location = new System.Drawing.Point(23, 75);
            this.cb_sincronizarauto.Name = "cb_sincronizarauto";
            this.cb_sincronizarauto.NM_Alias = "";
            this.cb_sincronizarauto.NM_Campo = "";
            this.cb_sincronizarauto.NM_Param = "";
            this.cb_sincronizarauto.Size = new System.Drawing.Size(163, 17);
            this.cb_sincronizarauto.ST_Gravar = false;
            this.cb_sincronizarauto.ST_LimparCampo = true;
            this.cb_sincronizarauto.ST_NotNull = false;
            this.cb_sincronizarauto.TabIndex = 13;
            this.cb_sincronizarauto.Text = "Sincronizar Automaticamente";
            this.cb_sincronizarauto.UseVisualStyleBackColor = true;
            this.cb_sincronizarauto.Vl_False = "";
            this.cb_sincronizarauto.Vl_True = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Item Sincronizar:";
            // 
            // cbItemSincronizar
            // 
            this.cbItemSincronizar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemSincronizar.FormattingEnabled = true;
            this.cbItemSincronizar.Location = new System.Drawing.Point(23, 48);
            this.cbItemSincronizar.Name = "cbItemSincronizar";
            this.cbItemSincronizar.NM_Alias = "";
            this.cbItemSincronizar.NM_Campo = "";
            this.cbItemSincronizar.NM_Param = "";
            this.cbItemSincronizar.Size = new System.Drawing.Size(271, 21);
            this.cbItemSincronizar.ST_Gravar = false;
            this.cbItemSincronizar.ST_LimparCampo = true;
            this.cbItemSincronizar.ST_NotNull = false;
            this.cbItemSincronizar.TabIndex = 11;
            this.cbItemSincronizar.SelectedIndexChanged += new System.EventHandler(this.cbItemSincronizar_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(286, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Tempo 1:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.st_cadastro,
            this.toolStripStatusLabel2,
            this.st_pedido});
            this.statusStrip1.Location = new System.Drawing.Point(0, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(769, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(171, 17);
            this.toolStripStatusLabel1.Text = "STATUS SERVIÇO CADASTROS:";
            // 
            // st_cadastro
            // 
            this.st_cadastro.Name = "st_cadastro";
            this.st_cadastro.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 17);
            this.toolStripStatusLabel2.Text = "STATUS SERVIÇO PEDIDOS:";
            // 
            // st_pedido
            // 
            this.st_pedido.Name = "st_pedido";
            this.st_pedido.Size = new System.Drawing.Size(0, 17);
            // 
            // tmp1
            // 
            this.tmp1.Location = new System.Drawing.Point(344, 203);
            this.tmp1.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tmp1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tmp1.Name = "tmp1";
            this.tmp1.Size = new System.Drawing.Size(63, 20);
            this.tmp1.TabIndex = 8;
            this.tmp1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(413, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "minutos";
            // 
            // tpSincManual
            // 
            this.tpSincManual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tpSincManual.Controls.Add(this.tlpSincManual);
            this.tpSincManual.Location = new System.Drawing.Point(4, 25);
            this.tpSincManual.Name = "tpSincManual";
            this.tpSincManual.Padding = new System.Windows.Forms.Padding(3);
            this.tpSincManual.Size = new System.Drawing.Size(783, 361);
            this.tpSincManual.TabIndex = 1;
            this.tpSincManual.Text = "SINCRONIZAÇÃO MANUAL";
            this.tpSincManual.UseVisualStyleBackColor = true;
            // 
            // tlpSincManual
            // 
            this.tlpSincManual.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpSincManual.ColumnCount = 1;
            this.tlpSincManual.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSincManual.Controls.Add(this.pFiltro, 0, 0);
            this.tlpSincManual.Controls.Add(this.tlpSinc, 0, 1);
            this.tlpSincManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSincManual.Location = new System.Drawing.Point(3, 3);
            this.tlpSincManual.Name = "tlpSincManual";
            this.tlpSincManual.RowCount = 2;
            this.tlpSincManual.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpSincManual.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSincManual.Size = new System.Drawing.Size(773, 351);
            this.tlpSincManual.TabIndex = 0;
            // 
            // pFiltro
            // 
            this.pFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pFiltro.Controls.Add(this.DT_Final);
            this.pFiltro.Controls.Add(this.label3);
            this.pFiltro.Controls.Add(this.DT_Inicial);
            this.pFiltro.Controls.Add(this.label69);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(763, 32);
            this.pFiltro.TabIndex = 0;
            // 
            // DT_Final
            // 
            this.DT_Final.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_Final.Location = new System.Drawing.Point(293, 5);
            this.DT_Final.Mask = "00/00/0000 00:00:00";
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.NM_Alias = "";
            this.DT_Final.NM_Campo = "";
            this.DT_Final.NM_CampoBusca = "";
            this.DT_Final.NM_Param = "";
            this.DT_Final.Operador = "";
            this.DT_Final.Size = new System.Drawing.Size(120, 20);
            this.DT_Final.ST_Gravar = true;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = false;
            this.DT_Final.ST_PrimaryKey = false;
            this.DT_Final.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(218, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Data Final:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DT_Inicial
            // 
            this.DT_Inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_Inicial.Location = new System.Drawing.Point(85, 5);
            this.DT_Inicial.Mask = "00/00/0000 00:00:00";
            this.DT_Inicial.Name = "DT_Inicial";
            this.DT_Inicial.NM_Alias = "";
            this.DT_Inicial.NM_Campo = "";
            this.DT_Inicial.NM_CampoBusca = "";
            this.DT_Inicial.NM_Param = "";
            this.DT_Inicial.Operador = "";
            this.DT_Inicial.Size = new System.Drawing.Size(120, 20);
            this.DT_Inicial.ST_Gravar = true;
            this.DT_Inicial.ST_LimpaCampo = true;
            this.DT_Inicial.ST_NotNull = false;
            this.DT_Inicial.ST_PrimaryKey = false;
            this.DT_Inicial.TabIndex = 60;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(3, 8);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(76, 13);
            this.label69.TabIndex = 61;
            this.label69.Text = "Data Inicial:";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlpSinc
            // 
            this.tlpSinc.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tlpSinc.ColumnCount = 3;
            this.tlpSinc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSinc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpSinc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpSinc.Controls.Add(this.cbSincClientes, 1, 2);
            this.tlpSinc.Controls.Add(this.cbSincPrecoProd, 0, 2);
            this.tlpSinc.Controls.Add(this.cbSincCondPgto, 2, 1);
            this.tlpSinc.Controls.Add(this.cbSincTabPreco, 1, 1);
            this.tlpSinc.Controls.Add(this.cbSincImagens, 0, 1);
            this.tlpSinc.Controls.Add(this.cbSincProdutos, 2, 0);
            this.tlpSinc.Controls.Add(this.cbSincOpcoesEnvio, 1, 0);
            this.tlpSinc.Controls.Add(this.cbSincCategoriaProdutos, 0, 0);
            this.tlpSinc.Controls.Add(this.cbSincPedidos, 2, 3);
            this.tlpSinc.Controls.Add(this.cbSincClienteXTpProduto, 1, 3);
            this.tlpSinc.Controls.Add(this.cbSincTpProduto, 0, 3);
            this.tlpSinc.Controls.Add(this.cbSincEnderecos, 2, 2);
            this.tlpSinc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSinc.Location = new System.Drawing.Point(5, 45);
            this.tlpSinc.Name = "tlpSinc";
            this.tlpSinc.RowCount = 4;
            this.tlpSinc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSinc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSinc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSinc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSinc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSinc.Size = new System.Drawing.Size(763, 301);
            this.tlpSinc.TabIndex = 1;
            // 
            // cbSincClientes
            // 
            this.cbSincClientes.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincClientes.FlatAppearance.BorderSize = 5;
            this.cbSincClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincClientes.Image = ((System.Drawing.Image)(resources.GetObject("cbSincClientes.Image")));
            this.cbSincClientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincClientes.Location = new System.Drawing.Point(259, 154);
            this.cbSincClientes.Name = "cbSincClientes";
            this.cbSincClientes.NM_Alias = "";
            this.cbSincClientes.NM_Campo = "";
            this.cbSincClientes.NM_Param = "";
            this.cbSincClientes.Size = new System.Drawing.Size(244, 65);
            this.cbSincClientes.ST_Gravar = false;
            this.cbSincClientes.ST_LimparCampo = true;
            this.cbSincClientes.ST_NotNull = false;
            this.cbSincClientes.TabIndex = 7;
            this.cbSincClientes.Text = "Sincronizar Clientes";
            this.cbSincClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincClientes.UseVisualStyleBackColor = true;
            this.cbSincClientes.Vl_False = "";
            this.cbSincClientes.Vl_True = "";
            // 
            // cbSincPrecoProd
            // 
            this.cbSincPrecoProd.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincPrecoProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincPrecoProd.FlatAppearance.BorderSize = 5;
            this.cbSincPrecoProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincPrecoProd.Image = ((System.Drawing.Image)(resources.GetObject("cbSincPrecoProd.Image")));
            this.cbSincPrecoProd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincPrecoProd.Location = new System.Drawing.Point(6, 154);
            this.cbSincPrecoProd.Name = "cbSincPrecoProd";
            this.cbSincPrecoProd.NM_Alias = "";
            this.cbSincPrecoProd.NM_Campo = "";
            this.cbSincPrecoProd.NM_Param = "";
            this.cbSincPrecoProd.Size = new System.Drawing.Size(244, 65);
            this.cbSincPrecoProd.ST_Gravar = false;
            this.cbSincPrecoProd.ST_LimparCampo = true;
            this.cbSincPrecoProd.ST_NotNull = false;
            this.cbSincPrecoProd.TabIndex = 6;
            this.cbSincPrecoProd.Text = "Sincronizar Preço dos Produtos";
            this.cbSincPrecoProd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincPrecoProd.UseVisualStyleBackColor = true;
            this.cbSincPrecoProd.Vl_False = "";
            this.cbSincPrecoProd.Vl_True = "";
            // 
            // cbSincCondPgto
            // 
            this.cbSincCondPgto.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincCondPgto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincCondPgto.FlatAppearance.BorderSize = 5;
            this.cbSincCondPgto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincCondPgto.Image = ((System.Drawing.Image)(resources.GetObject("cbSincCondPgto.Image")));
            this.cbSincCondPgto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincCondPgto.Location = new System.Drawing.Point(512, 80);
            this.cbSincCondPgto.Name = "cbSincCondPgto";
            this.cbSincCondPgto.NM_Alias = "";
            this.cbSincCondPgto.NM_Campo = "";
            this.cbSincCondPgto.NM_Param = "";
            this.cbSincCondPgto.Size = new System.Drawing.Size(245, 65);
            this.cbSincCondPgto.ST_Gravar = false;
            this.cbSincCondPgto.ST_LimparCampo = true;
            this.cbSincCondPgto.ST_NotNull = false;
            this.cbSincCondPgto.TabIndex = 5;
            this.cbSincCondPgto.Text = "Sincronizar Condições Pagamento";
            this.cbSincCondPgto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincCondPgto.UseVisualStyleBackColor = true;
            this.cbSincCondPgto.Vl_False = "";
            this.cbSincCondPgto.Vl_True = "";
            // 
            // cbSincTabPreco
            // 
            this.cbSincTabPreco.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincTabPreco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincTabPreco.FlatAppearance.BorderSize = 5;
            this.cbSincTabPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincTabPreco.Image = ((System.Drawing.Image)(resources.GetObject("cbSincTabPreco.Image")));
            this.cbSincTabPreco.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincTabPreco.Location = new System.Drawing.Point(259, 80);
            this.cbSincTabPreco.Name = "cbSincTabPreco";
            this.cbSincTabPreco.NM_Alias = "";
            this.cbSincTabPreco.NM_Campo = "";
            this.cbSincTabPreco.NM_Param = "";
            this.cbSincTabPreco.Size = new System.Drawing.Size(244, 65);
            this.cbSincTabPreco.ST_Gravar = false;
            this.cbSincTabPreco.ST_LimparCampo = true;
            this.cbSincTabPreco.ST_NotNull = false;
            this.cbSincTabPreco.TabIndex = 4;
            this.cbSincTabPreco.Text = "Sincronizar Tabela Preço";
            this.cbSincTabPreco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincTabPreco.UseVisualStyleBackColor = true;
            this.cbSincTabPreco.Vl_False = "";
            this.cbSincTabPreco.Vl_True = "";
            // 
            // cbSincImagens
            // 
            this.cbSincImagens.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincImagens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincImagens.FlatAppearance.BorderSize = 5;
            this.cbSincImagens.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincImagens.Image = ((System.Drawing.Image)(resources.GetObject("cbSincImagens.Image")));
            this.cbSincImagens.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincImagens.Location = new System.Drawing.Point(6, 80);
            this.cbSincImagens.Name = "cbSincImagens";
            this.cbSincImagens.NM_Alias = "";
            this.cbSincImagens.NM_Campo = "";
            this.cbSincImagens.NM_Param = "";
            this.cbSincImagens.Size = new System.Drawing.Size(244, 65);
            this.cbSincImagens.ST_Gravar = false;
            this.cbSincImagens.ST_LimparCampo = true;
            this.cbSincImagens.ST_NotNull = false;
            this.cbSincImagens.TabIndex = 3;
            this.cbSincImagens.Text = "Sincronizar Imagens dos Produtos";
            this.cbSincImagens.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincImagens.UseVisualStyleBackColor = true;
            this.cbSincImagens.Vl_False = "";
            this.cbSincImagens.Vl_True = "";
            // 
            // cbSincProdutos
            // 
            this.cbSincProdutos.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincProdutos.FlatAppearance.BorderSize = 5;
            this.cbSincProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincProdutos.Image = ((System.Drawing.Image)(resources.GetObject("cbSincProdutos.Image")));
            this.cbSincProdutos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincProdutos.Location = new System.Drawing.Point(512, 6);
            this.cbSincProdutos.Name = "cbSincProdutos";
            this.cbSincProdutos.NM_Alias = "";
            this.cbSincProdutos.NM_Campo = "";
            this.cbSincProdutos.NM_Param = "";
            this.cbSincProdutos.Size = new System.Drawing.Size(245, 65);
            this.cbSincProdutos.ST_Gravar = false;
            this.cbSincProdutos.ST_LimparCampo = true;
            this.cbSincProdutos.ST_NotNull = false;
            this.cbSincProdutos.TabIndex = 2;
            this.cbSincProdutos.Text = "Sincronizar Produtos";
            this.cbSincProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincProdutos.UseVisualStyleBackColor = true;
            this.cbSincProdutos.Vl_False = "";
            this.cbSincProdutos.Vl_True = "";
            // 
            // cbSincOpcoesEnvio
            // 
            this.cbSincOpcoesEnvio.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincOpcoesEnvio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincOpcoesEnvio.FlatAppearance.BorderSize = 5;
            this.cbSincOpcoesEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincOpcoesEnvio.Image = ((System.Drawing.Image)(resources.GetObject("cbSincOpcoesEnvio.Image")));
            this.cbSincOpcoesEnvio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincOpcoesEnvio.Location = new System.Drawing.Point(259, 6);
            this.cbSincOpcoesEnvio.Name = "cbSincOpcoesEnvio";
            this.cbSincOpcoesEnvio.NM_Alias = "";
            this.cbSincOpcoesEnvio.NM_Campo = "";
            this.cbSincOpcoesEnvio.NM_Param = "";
            this.cbSincOpcoesEnvio.Size = new System.Drawing.Size(244, 65);
            this.cbSincOpcoesEnvio.ST_Gravar = false;
            this.cbSincOpcoesEnvio.ST_LimparCampo = true;
            this.cbSincOpcoesEnvio.ST_NotNull = false;
            this.cbSincOpcoesEnvio.TabIndex = 1;
            this.cbSincOpcoesEnvio.Text = "Sincronizar Opções de Envio";
            this.cbSincOpcoesEnvio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincOpcoesEnvio.UseVisualStyleBackColor = true;
            this.cbSincOpcoesEnvio.Vl_False = "";
            this.cbSincOpcoesEnvio.Vl_True = "";
            // 
            // cbSincCategoriaProdutos
            // 
            this.cbSincCategoriaProdutos.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincCategoriaProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincCategoriaProdutos.FlatAppearance.BorderSize = 5;
            this.cbSincCategoriaProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincCategoriaProdutos.Image = ((System.Drawing.Image)(resources.GetObject("cbSincCategoriaProdutos.Image")));
            this.cbSincCategoriaProdutos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincCategoriaProdutos.Location = new System.Drawing.Point(6, 6);
            this.cbSincCategoriaProdutos.Name = "cbSincCategoriaProdutos";
            this.cbSincCategoriaProdutos.NM_Alias = "";
            this.cbSincCategoriaProdutos.NM_Campo = "";
            this.cbSincCategoriaProdutos.NM_Param = "";
            this.cbSincCategoriaProdutos.Size = new System.Drawing.Size(244, 65);
            this.cbSincCategoriaProdutos.ST_Gravar = false;
            this.cbSincCategoriaProdutos.ST_LimparCampo = true;
            this.cbSincCategoriaProdutos.ST_NotNull = false;
            this.cbSincCategoriaProdutos.TabIndex = 0;
            this.cbSincCategoriaProdutos.Text = "Sincronizar Categoria de Produtos";
            this.cbSincCategoriaProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincCategoriaProdutos.UseVisualStyleBackColor = true;
            this.cbSincCategoriaProdutos.Vl_False = "";
            this.cbSincCategoriaProdutos.Vl_True = "";
            // 
            // cbSincPedidos
            // 
            this.cbSincPedidos.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincPedidos.FlatAppearance.BorderSize = 5;
            this.cbSincPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincPedidos.Image = ((System.Drawing.Image)(resources.GetObject("cbSincPedidos.Image")));
            this.cbSincPedidos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincPedidos.Location = new System.Drawing.Point(512, 228);
            this.cbSincPedidos.Name = "cbSincPedidos";
            this.cbSincPedidos.NM_Alias = "";
            this.cbSincPedidos.NM_Campo = "";
            this.cbSincPedidos.NM_Param = "";
            this.cbSincPedidos.Size = new System.Drawing.Size(245, 67);
            this.cbSincPedidos.ST_Gravar = false;
            this.cbSincPedidos.ST_LimparCampo = true;
            this.cbSincPedidos.ST_NotNull = false;
            this.cbSincPedidos.TabIndex = 10;
            this.cbSincPedidos.Text = "Sincronizar Pedidos";
            this.cbSincPedidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincPedidos.UseVisualStyleBackColor = true;
            this.cbSincPedidos.Vl_False = "";
            this.cbSincPedidos.Vl_True = "";
            // 
            // cbSincClienteXTpProduto
            // 
            this.cbSincClienteXTpProduto.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincClienteXTpProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincClienteXTpProduto.FlatAppearance.BorderSize = 5;
            this.cbSincClienteXTpProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincClienteXTpProduto.Image = ((System.Drawing.Image)(resources.GetObject("cbSincClienteXTpProduto.Image")));
            this.cbSincClienteXTpProduto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincClienteXTpProduto.Location = new System.Drawing.Point(259, 228);
            this.cbSincClienteXTpProduto.Name = "cbSincClienteXTpProduto";
            this.cbSincClienteXTpProduto.NM_Alias = "";
            this.cbSincClienteXTpProduto.NM_Campo = "";
            this.cbSincClienteXTpProduto.NM_Param = "";
            this.cbSincClienteXTpProduto.Size = new System.Drawing.Size(244, 67);
            this.cbSincClienteXTpProduto.ST_Gravar = false;
            this.cbSincClienteXTpProduto.ST_LimparCampo = true;
            this.cbSincClienteXTpProduto.ST_NotNull = false;
            this.cbSincClienteXTpProduto.TabIndex = 9;
            this.cbSincClienteXTpProduto.Text = "Sincronizar Clientes X Tipo Produto";
            this.cbSincClienteXTpProduto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincClienteXTpProduto.UseVisualStyleBackColor = true;
            this.cbSincClienteXTpProduto.Vl_False = "";
            this.cbSincClienteXTpProduto.Vl_True = "";
            // 
            // cbSincTpProduto
            // 
            this.cbSincTpProduto.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincTpProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincTpProduto.FlatAppearance.BorderSize = 5;
            this.cbSincTpProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincTpProduto.Image = ((System.Drawing.Image)(resources.GetObject("cbSincTpProduto.Image")));
            this.cbSincTpProduto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincTpProduto.Location = new System.Drawing.Point(6, 228);
            this.cbSincTpProduto.Name = "cbSincTpProduto";
            this.cbSincTpProduto.NM_Alias = "";
            this.cbSincTpProduto.NM_Campo = "";
            this.cbSincTpProduto.NM_Param = "";
            this.cbSincTpProduto.Size = new System.Drawing.Size(244, 67);
            this.cbSincTpProduto.ST_Gravar = false;
            this.cbSincTpProduto.ST_LimparCampo = true;
            this.cbSincTpProduto.ST_NotNull = false;
            this.cbSincTpProduto.TabIndex = 8;
            this.cbSincTpProduto.Text = "Sincronizar Tipo de Produto";
            this.cbSincTpProduto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincTpProduto.UseVisualStyleBackColor = true;
            this.cbSincTpProduto.Vl_False = "";
            this.cbSincTpProduto.Vl_True = "";
            // 
            // cbSincEnderecos
            // 
            this.cbSincEnderecos.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbSincEnderecos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSincEnderecos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSincEnderecos.Image = ((System.Drawing.Image)(resources.GetObject("cbSincEnderecos.Image")));
            this.cbSincEnderecos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbSincEnderecos.Location = new System.Drawing.Point(512, 154);
            this.cbSincEnderecos.Name = "cbSincEnderecos";
            this.cbSincEnderecos.NM_Alias = "";
            this.cbSincEnderecos.NM_Campo = "";
            this.cbSincEnderecos.NM_Param = "";
            this.cbSincEnderecos.Size = new System.Drawing.Size(245, 65);
            this.cbSincEnderecos.ST_Gravar = false;
            this.cbSincEnderecos.ST_LimparCampo = true;
            this.cbSincEnderecos.ST_NotNull = false;
            this.cbSincEnderecos.TabIndex = 11;
            this.cbSincEnderecos.Text = "Sincronizar Endereços";
            this.cbSincEnderecos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSincEnderecos.UseVisualStyleBackColor = true;
            this.cbSincEnderecos.Vl_False = "";
            this.cbSincEnderecos.Vl_True = "";
            // 
            // scIntegraEcommerce
            // 
            this.scIntegraEcommerce.ServiceName = "IntegraViaseg";
            // 
            // tempo
            // 
            this.tempo.Tick += new System.EventHandler(this.tempo_Tick);
            // 
            // scIntegraPedido
            // 
            this.scIntegraPedido.ServiceName = "IntegraPedido";
            // 
            // TFIntegraECommerce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 433);
            this.Controls.Add(this.tcCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFIntegraECommerce";
            this.ShowInTaskbar = false;
            this.Text = "Integração E-Commerce";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFIntegraECommerce_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFIntegraECommerce_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpCfgServico.ResumeLayout(false);
            this.pConfig.ResumeLayout(false);
            this.pConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmp_atualizapedido)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.rgTempo.ResumeLayout(false);
            this.rgTempo.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmp1)).EndInit();
            this.tpSincManual.ResumeLayout(false);
            this.tlpSincManual.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.tlpSinc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.TabControl tcCentral;
        private System.Windows.Forms.TabPage tpCfgServico;
        private System.Windows.Forms.TabPage tpSincManual;
        private Componentes.PanelDados pConfig;
        private Componentes.ComboBoxDefault cbItemSincronizar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown tmp1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditData dt_sincronizar;
        private System.Windows.Forms.Label label2;
        private Componentes.CheckBoxDefault cb_sincronizarauto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.ToolStripButton BB_Sincronizar;
        private System.Windows.Forms.TableLayoutPanel tlpSincManual;
        private Componentes.PanelDados pFiltro;
        private Componentes.EditData DT_Final;
        private System.Windows.Forms.Label label3;
        private Componentes.EditData DT_Inicial;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TableLayoutPanel tlpSinc;
        private Componentes.CheckBoxDefault cbSincCategoriaProdutos;
        private Componentes.CheckBoxDefault cbSincCondPgto;
        private Componentes.CheckBoxDefault cbSincTabPreco;
        private Componentes.CheckBoxDefault cbSincImagens;
        private Componentes.CheckBoxDefault cbSincProdutos;
        private Componentes.CheckBoxDefault cbSincOpcoesEnvio;
        private Componentes.CheckBoxDefault cbSincTpProduto;
        private Componentes.CheckBoxDefault cbSincClientes;
        private Componentes.CheckBoxDefault cbSincPrecoProd;
        private Componentes.CheckBoxDefault cbSincClienteXTpProduto;
        private Componentes.CheckBoxDefault cbSincPedidos;
        private System.ServiceProcess.ServiceController scIntegraEcommerce;
        private System.Windows.Forms.Timer tempo;
        private Componentes.CheckBoxDefault cbSincEnderecos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown tmp_atualizapedido;
        private System.Windows.Forms.Label label5;
        private System.ServiceProcess.ServiceController scIntegraPedido;
        private System.Windows.Forms.ToolStripSplitButton BB_Iniciar;
        private System.Windows.Forms.ToolStripSplitButton BB_Parar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem iToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sincronizarPedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sincronizarCadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sincronizarPedidosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel st_cadastro;
        private System.Windows.Forms.ToolStripStatusLabel st_pedido;
        private Componentes.RadioGroup rgTempo;
        private Componentes.RadioButtonDefault rbTempo3;
        private Componentes.RadioButtonDefault rbTempo2;
        private Componentes.RadioButtonDefault rbTempo1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown tmp2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown tmp3;
        private System.Windows.Forms.Label label11;
    }
}