namespace Gerencia.Posto_Combustivel
{
    partial class TFPainelOnLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFPainelOnLine));
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.empresa = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tcCentral = new System.Windows.Forms.TabControl();
            this.tpEstoqueOnLine = new System.Windows.Forms.TabPage();
            this.flpTanques = new System.Windows.Forms.FlowLayoutPanel();
            this.wg1 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wg2 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wg3 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wg4 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wg5 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wg6 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.label1 = new System.Windows.Forms.Label();
            this.tpVendasOnLine = new System.Windows.Forms.TabPage();
            this.flpVendas = new System.Windows.Forms.FlowLayoutPanel();
            this.wgVenda1 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wgVenda2 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wgVenda3 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wgVenda4 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wgVenda5 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wgVenda6 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.label2 = new System.Windows.Forms.Label();
            this.tpFinanceiro = new System.Windows.Forms.TabPage();
            this.flpPortador = new System.Windows.Forms.FlowLayoutPanel();
            this.wgPort1 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wgPort2 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wgPort3 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wgPort4 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wgPort5 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.wgPort6 = new PerpetuumSoft.Instrumentation.Windows.Forms.Widget();
            this.label5 = new System.Windows.Forms.Label();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Sair = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpEstoqueOnLine.SuspendLayout();
            this.flpTanques.SuspendLayout();
            this.tpVendasOnLine.SuspendLayout();
            this.flpVendas.SuspendLayout();
            this.tpFinanceiro.SuspendLayout();
            this.flpPortador.SuspendLayout();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.tcCentral, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(967, 583);
            this.tlpCentral.TabIndex = 0;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.empresa);
            this.pFiltro.Controls.Add(this.label3);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.Size = new System.Drawing.Size(957, 29);
            this.pFiltro.TabIndex = 0;
            // 
            // empresa
            // 
            this.empresa.BackColor = System.Drawing.Color.White;
            this.empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresa.FormattingEnabled = true;
            this.empresa.Location = new System.Drawing.Point(129, 3);
            this.empresa.Name = "empresa";
            this.empresa.Size = new System.Drawing.Size(664, 21);
            this.empresa.ST_Gravar = false;
            this.empresa.ST_LimparCampo = true;
            this.empresa.ST_NotNull = false;
            this.empresa.TabIndex = 17;
            this.empresa.SelectedIndexChanged += new System.EventHandler(this.empresa_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Posto Combustivel:";
            // 
            // tcCentral
            // 
            this.tcCentral.Controls.Add(this.tpEstoqueOnLine);
            this.tcCentral.Controls.Add(this.tpVendasOnLine);
            this.tcCentral.Controls.Add(this.tpFinanceiro);
            this.tcCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCentral.Location = new System.Drawing.Point(5, 42);
            this.tcCentral.Name = "tcCentral";
            this.tcCentral.SelectedIndex = 0;
            this.tcCentral.Size = new System.Drawing.Size(957, 536);
            this.tcCentral.TabIndex = 1;
            this.tcCentral.SelectedIndexChanged += new System.EventHandler(this.tcCentral_SelectedIndexChanged);
            // 
            // tpEstoqueOnLine
            // 
            this.tpEstoqueOnLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpEstoqueOnLine.Controls.Add(this.flpTanques);
            this.tpEstoqueOnLine.Controls.Add(this.label1);
            this.tpEstoqueOnLine.Location = new System.Drawing.Point(4, 22);
            this.tpEstoqueOnLine.Name = "tpEstoqueOnLine";
            this.tpEstoqueOnLine.Padding = new System.Windows.Forms.Padding(3);
            this.tpEstoqueOnLine.Size = new System.Drawing.Size(949, 510);
            this.tpEstoqueOnLine.TabIndex = 1;
            this.tpEstoqueOnLine.Text = "ESTOQUE ONLINE";
            this.tpEstoqueOnLine.UseVisualStyleBackColor = true;
            // 
            // flpTanques
            // 
            this.flpTanques.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpTanques.Controls.Add(this.wg1);
            this.flpTanques.Controls.Add(this.wg2);
            this.flpTanques.Controls.Add(this.wg3);
            this.flpTanques.Controls.Add(this.wg4);
            this.flpTanques.Controls.Add(this.wg5);
            this.flpTanques.Controls.Add(this.wg6);
            this.flpTanques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTanques.Location = new System.Drawing.Point(3, 20);
            this.flpTanques.Name = "flpTanques";
            this.flpTanques.Size = new System.Drawing.Size(941, 485);
            this.flpTanques.TabIndex = 68;
            // 
            // wg1
            // 
            this.wg1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wg1.Cursor = System.Windows.Forms.Cursors.Default;
            this.wg1.Location = new System.Drawing.Point(3, 3);
            this.wg1.Name = "wg1";
            this.wg1.Size = new System.Drawing.Size(150, 478);
            this.wg1.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wg1.TabIndex = 0;
            this.wg1.DoubleClick += new System.EventHandler(this.wg1_DoubleClick);
            // 
            // wg2
            // 
            this.wg2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wg2.Cursor = System.Windows.Forms.Cursors.Default;
            this.wg2.Location = new System.Drawing.Point(159, 3);
            this.wg2.Name = "wg2";
            this.wg2.Size = new System.Drawing.Size(150, 478);
            this.wg2.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wg2.TabIndex = 1;
            // 
            // wg3
            // 
            this.wg3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wg3.Cursor = System.Windows.Forms.Cursors.Default;
            this.wg3.Location = new System.Drawing.Point(315, 3);
            this.wg3.Name = "wg3";
            this.wg3.Size = new System.Drawing.Size(150, 478);
            this.wg3.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wg3.TabIndex = 2;
            // 
            // wg4
            // 
            this.wg4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wg4.Cursor = System.Windows.Forms.Cursors.Default;
            this.wg4.Location = new System.Drawing.Point(471, 3);
            this.wg4.Name = "wg4";
            this.wg4.Size = new System.Drawing.Size(150, 478);
            this.wg4.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wg4.TabIndex = 3;
            // 
            // wg5
            // 
            this.wg5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wg5.Cursor = System.Windows.Forms.Cursors.Default;
            this.wg5.Location = new System.Drawing.Point(627, 3);
            this.wg5.Name = "wg5";
            this.wg5.Size = new System.Drawing.Size(150, 478);
            this.wg5.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wg5.TabIndex = 4;
            // 
            // wg6
            // 
            this.wg6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wg6.Cursor = System.Windows.Forms.Cursors.Default;
            this.wg6.Location = new System.Drawing.Point(783, 3);
            this.wg6.Name = "wg6";
            this.wg6.Size = new System.Drawing.Size(150, 478);
            this.wg6.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wg6.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(941, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "ESTOQUE ATUAL DOS TANQUES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpVendasOnLine
            // 
            this.tpVendasOnLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpVendasOnLine.Controls.Add(this.flpVendas);
            this.tpVendasOnLine.Controls.Add(this.label2);
            this.tpVendasOnLine.Location = new System.Drawing.Point(4, 22);
            this.tpVendasOnLine.Name = "tpVendasOnLine";
            this.tpVendasOnLine.Padding = new System.Windows.Forms.Padding(3);
            this.tpVendasOnLine.Size = new System.Drawing.Size(949, 510);
            this.tpVendasOnLine.TabIndex = 2;
            this.tpVendasOnLine.Text = "VENDAS ONLINE";
            this.tpVendasOnLine.UseVisualStyleBackColor = true;
            // 
            // flpVendas
            // 
            this.flpVendas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpVendas.Controls.Add(this.wgVenda1);
            this.flpVendas.Controls.Add(this.wgVenda2);
            this.flpVendas.Controls.Add(this.wgVenda3);
            this.flpVendas.Controls.Add(this.wgVenda4);
            this.flpVendas.Controls.Add(this.wgVenda5);
            this.flpVendas.Controls.Add(this.wgVenda6);
            this.flpVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpVendas.Location = new System.Drawing.Point(3, 20);
            this.flpVendas.Name = "flpVendas";
            this.flpVendas.Size = new System.Drawing.Size(941, 485);
            this.flpVendas.TabIndex = 69;
            // 
            // wgVenda1
            // 
            this.wgVenda1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgVenda1.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgVenda1.Location = new System.Drawing.Point(3, 3);
            this.wgVenda1.Name = "wgVenda1";
            this.wgVenda1.Size = new System.Drawing.Size(150, 478);
            this.wgVenda1.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgVenda1.TabIndex = 0;
            this.wgVenda1.DoubleClick += new System.EventHandler(this.wgVenda1_DoubleClick);
            // 
            // wgVenda2
            // 
            this.wgVenda2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgVenda2.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgVenda2.Location = new System.Drawing.Point(159, 3);
            this.wgVenda2.Name = "wgVenda2";
            this.wgVenda2.Size = new System.Drawing.Size(150, 478);
            this.wgVenda2.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgVenda2.TabIndex = 1;
            // 
            // wgVenda3
            // 
            this.wgVenda3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgVenda3.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgVenda3.Location = new System.Drawing.Point(315, 3);
            this.wgVenda3.Name = "wgVenda3";
            this.wgVenda3.Size = new System.Drawing.Size(150, 478);
            this.wgVenda3.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgVenda3.TabIndex = 2;
            // 
            // wgVenda4
            // 
            this.wgVenda4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgVenda4.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgVenda4.Location = new System.Drawing.Point(471, 3);
            this.wgVenda4.Name = "wgVenda4";
            this.wgVenda4.Size = new System.Drawing.Size(150, 478);
            this.wgVenda4.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgVenda4.TabIndex = 3;
            // 
            // wgVenda5
            // 
            this.wgVenda5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgVenda5.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgVenda5.Location = new System.Drawing.Point(627, 3);
            this.wgVenda5.Name = "wgVenda5";
            this.wgVenda5.Size = new System.Drawing.Size(150, 478);
            this.wgVenda5.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgVenda5.TabIndex = 4;
            // 
            // wgVenda6
            // 
            this.wgVenda6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgVenda6.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgVenda6.Location = new System.Drawing.Point(783, 3);
            this.wgVenda6.Name = "wgVenda6";
            this.wgVenda6.Size = new System.Drawing.Size(150, 478);
            this.wgVenda6.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgVenda6.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(941, 17);
            this.label2.TabIndex = 70;
            this.label2.Text = "VENDAS COMBUSTIVEL NO DIA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpFinanceiro
            // 
            this.tpFinanceiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpFinanceiro.Controls.Add(this.flpPortador);
            this.tpFinanceiro.Controls.Add(this.label5);
            this.tpFinanceiro.Location = new System.Drawing.Point(4, 22);
            this.tpFinanceiro.Name = "tpFinanceiro";
            this.tpFinanceiro.Padding = new System.Windows.Forms.Padding(3);
            this.tpFinanceiro.Size = new System.Drawing.Size(949, 510);
            this.tpFinanceiro.TabIndex = 0;
            this.tpFinanceiro.Text = "FINANCEIRO";
            this.tpFinanceiro.UseVisualStyleBackColor = true;
            // 
            // flpPortador
            // 
            this.flpPortador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpPortador.Controls.Add(this.wgPort1);
            this.flpPortador.Controls.Add(this.wgPort2);
            this.flpPortador.Controls.Add(this.wgPort3);
            this.flpPortador.Controls.Add(this.wgPort4);
            this.flpPortador.Controls.Add(this.wgPort5);
            this.flpPortador.Controls.Add(this.wgPort6);
            this.flpPortador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPortador.Location = new System.Drawing.Point(3, 20);
            this.flpPortador.Name = "flpPortador";
            this.flpPortador.Size = new System.Drawing.Size(941, 485);
            this.flpPortador.TabIndex = 69;
            // 
            // wgPort1
            // 
            this.wgPort1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgPort1.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgPort1.Location = new System.Drawing.Point(3, 3);
            this.wgPort1.Name = "wgPort1";
            this.wgPort1.Size = new System.Drawing.Size(150, 478);
            this.wgPort1.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgPort1.TabIndex = 0;
            this.wgPort1.DoubleClick += new System.EventHandler(this.wgPort1_DoubleClick);
            // 
            // wgPort2
            // 
            this.wgPort2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgPort2.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgPort2.Location = new System.Drawing.Point(159, 3);
            this.wgPort2.Name = "wgPort2";
            this.wgPort2.Size = new System.Drawing.Size(150, 478);
            this.wgPort2.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgPort2.TabIndex = 1;
            // 
            // wgPort3
            // 
            this.wgPort3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgPort3.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgPort3.Location = new System.Drawing.Point(315, 3);
            this.wgPort3.Name = "wgPort3";
            this.wgPort3.Size = new System.Drawing.Size(150, 478);
            this.wgPort3.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgPort3.TabIndex = 2;
            // 
            // wgPort4
            // 
            this.wgPort4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgPort4.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgPort4.Location = new System.Drawing.Point(471, 3);
            this.wgPort4.Name = "wgPort4";
            this.wgPort4.Size = new System.Drawing.Size(150, 478);
            this.wgPort4.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgPort4.TabIndex = 3;
            // 
            // wgPort5
            // 
            this.wgPort5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgPort5.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgPort5.Location = new System.Drawing.Point(627, 3);
            this.wgPort5.Name = "wgPort5";
            this.wgPort5.Size = new System.Drawing.Size(150, 478);
            this.wgPort5.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgPort5.TabIndex = 4;
            // 
            // wgPort6
            // 
            this.wgPort6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wgPort6.Cursor = System.Windows.Forms.Cursors.Default;
            this.wgPort6.Location = new System.Drawing.Point(783, 3);
            this.wgPort6.Name = "wgPort6";
            this.wgPort6.Size = new System.Drawing.Size(150, 478);
            this.wgPort6.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            this.wgPort6.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(941, 17);
            this.label5.TabIndex = 70;
            this.label5.Text = "RECEBIMENTOS NO DIA - POR PORTADOR";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Buscar,
            this.toolStripSeparator1,
            this.BB_Sair});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(967, 43);
            this.barraMenu.TabIndex = 537;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // BB_Sair
            // 
            this.BB_Sair.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Sair.ForeColor = System.Drawing.Color.Green;
            this.BB_Sair.Image = ((System.Drawing.Image)(resources.GetObject("BB_Sair.Image")));
            this.BB_Sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Sair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Sair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Sair.Name = "BB_Sair";
            this.BB_Sair.Size = new System.Drawing.Size(54, 40);
            this.BB_Sair.Click += new System.EventHandler(this.BB_Sair_Click);
            // 
            // TFPainelOnLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 626);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFPainelOnLine";
            this.ShowInTaskbar = false;
            this.Text = "Painel OnLine - Posto Combustivel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFPainelGerencial_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFPainelGerencial_FormClosing);
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpEstoqueOnLine.ResumeLayout(false);
            this.flpTanques.ResumeLayout(false);
            this.tpVendasOnLine.ResumeLayout(false);
            this.flpVendas.ResumeLayout(false);
            this.tpFinanceiro.ResumeLayout(false);
            this.flpPortador.ResumeLayout(false);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.TabControl tcCentral;
        private System.Windows.Forms.TabPage tpFinanceiro;
        private System.Windows.Forms.TabPage tpEstoqueOnLine;
        private System.Windows.Forms.FlowLayoutPanel flpTanques;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wg1;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wg2;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wg3;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wg4;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wg5;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wg6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpVendas;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgVenda1;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgVenda2;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgVenda3;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgVenda4;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgVenda5;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgVenda6;
        private System.Windows.Forms.Label label2;
        private Componentes.ComboBoxDefault empresa;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BB_Sair;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.FlowLayoutPanel flpPortador;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgPort1;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgPort2;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgPort3;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgPort4;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgPort5;
        private PerpetuumSoft.Instrumentation.Windows.Forms.Widget wgPort6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tpVendasOnLine;
    }
}