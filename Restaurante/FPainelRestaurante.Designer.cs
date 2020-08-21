namespace Restaurante
{
    partial class FPainelRestaurante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPainelRestaurante));
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pCabec = new Componentes.PanelDados(this.components);
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblHoraIni = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPdv = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatusCartao = new System.Windows.Forms.Label();
            this.lblPistaBoliche = new System.Windows.Forms.Label();
            this.lblVendaCombustivel = new System.Windows.Forms.Label();
            this.lb_venda_pesagem = new System.Windows.Forms.Label();
            this.lblFecharCartao = new System.Windows.Forms.Label();
            this.delivery = new System.Windows.Forms.Label();
            this.lblAbrirCaixa = new System.Windows.Forms.Label();
            this.lblFecharCaixa = new System.Windows.Forms.Label();
            this.lblAbrirGaveta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHoraboliche = new System.Windows.Forms.Label();
            this.lblRetirada = new System.Windows.Forms.Label();
            this.lblSair = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.btConsultaPedidos = new System.Windows.Forms.Label();
            this.tlpCentral.SuspendLayout();
            this.pCabec.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pCabec, 0, 0);
            this.tlpCentral.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCentral.Size = new System.Drawing.Size(1241, 542);
            this.tlpCentral.TabIndex = 1;
            // 
            // pCabec
            // 
            this.pCabec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCabec.Controls.Add(this.lblDisplay);
            this.pCabec.Controls.Add(this.lblHoraIni);
            this.pCabec.Controls.Add(this.label5);
            this.pCabec.Controls.Add(this.lblPdv);
            this.pCabec.Controls.Add(this.label4);
            this.pCabec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCabec.Location = new System.Drawing.Point(6, 6);
            this.pCabec.Name = "pCabec";
            this.pCabec.NM_ProcDeletar = "";
            this.pCabec.NM_ProcGravar = "";
            this.pCabec.Size = new System.Drawing.Size(1229, 115);
            this.pCabec.TabIndex = 0;
            // 
            // lblDisplay
            // 
            this.lblDisplay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(0, 0);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(1227, 24);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "PAINEL RESTAURANTE";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHoraIni
            // 
            this.lblHoraIni.AutoSize = true;
            this.lblHoraIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraIni.Location = new System.Drawing.Point(5, 88);
            this.lblHoraIni.Name = "lblHoraIni";
            this.lblHoraIni.Size = new System.Drawing.Size(0, 13);
            this.lblHoraIni.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(5, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Início da Operação:";
            // 
            // lblPdv
            // 
            this.lblPdv.AutoSize = true;
            this.lblPdv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPdv.Location = new System.Drawing.Point(5, 50);
            this.lblPdv.Name = "lblPdv";
            this.lblPdv.Size = new System.Drawing.Size(0, 13);
            this.lblPdv.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(5, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ponto Venda (PDV):";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.lblStatusCartao);
            this.flowLayoutPanel1.Controls.Add(this.lblPistaBoliche);
            this.flowLayoutPanel1.Controls.Add(this.lblVendaCombustivel);
            this.flowLayoutPanel1.Controls.Add(this.lb_venda_pesagem);
            this.flowLayoutPanel1.Controls.Add(this.lblFecharCartao);
            this.flowLayoutPanel1.Controls.Add(this.delivery);
            this.flowLayoutPanel1.Controls.Add(this.lblAbrirCaixa);
            this.flowLayoutPanel1.Controls.Add(this.lblFecharCaixa);
            this.flowLayoutPanel1.Controls.Add(this.lblAbrirGaveta);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.lblHoraboliche);
            this.flowLayoutPanel1.Controls.Add(this.lblRetirada);
            this.flowLayoutPanel1.Controls.Add(this.btConsultaPedidos);
            this.flowLayoutPanel1.Controls.Add(this.lblSair);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 130);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1229, 406);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 150);
            this.label1.TabIndex = 21;
            this.label1.Text = "(F8) Abertura de Cartões";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // lblStatusCartao
            // 
            this.lblStatusCartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusCartao.Image = ((System.Drawing.Image)(resources.GetObject("lblStatusCartao.Image")));
            this.lblStatusCartao.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblStatusCartao.Location = new System.Drawing.Point(159, 0);
            this.lblStatusCartao.Name = "lblStatusCartao";
            this.lblStatusCartao.Size = new System.Drawing.Size(150, 150);
            this.lblStatusCartao.TabIndex = 28;
            this.lblStatusCartao.Text = "Status de Cartões";
            this.lblStatusCartao.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblStatusCartao.Click += new System.EventHandler(this.lblStatusCartao_Click);
            this.lblStatusCartao.MouseEnter += new System.EventHandler(this.lblStatusCartao_MouseEnter);
            this.lblStatusCartao.MouseLeave += new System.EventHandler(this.lblStatusCartao_MouseLeave);
            // 
            // lblPistaBoliche
            // 
            this.lblPistaBoliche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPistaBoliche.Image = ((System.Drawing.Image)(resources.GetObject("lblPistaBoliche.Image")));
            this.lblPistaBoliche.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPistaBoliche.Location = new System.Drawing.Point(315, 0);
            this.lblPistaBoliche.Name = "lblPistaBoliche";
            this.lblPistaBoliche.Size = new System.Drawing.Size(150, 150);
            this.lblPistaBoliche.TabIndex = 25;
            this.lblPistaBoliche.Text = "(F9) Controle de Serviços";
            this.lblPistaBoliche.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblPistaBoliche.Click += new System.EventHandler(this.lblPistaBoliche_Click);
            this.lblPistaBoliche.MouseEnter += new System.EventHandler(this.lblPistaBoliche_MouseEnter);
            this.lblPistaBoliche.MouseLeave += new System.EventHandler(this.lblPistaBoliche_MouseLeave);
            // 
            // lblVendaCombustivel
            // 
            this.lblVendaCombustivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendaCombustivel.Image = ((System.Drawing.Image)(resources.GetObject("lblVendaCombustivel.Image")));
            this.lblVendaCombustivel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblVendaCombustivel.Location = new System.Drawing.Point(471, 0);
            this.lblVendaCombustivel.Name = "lblVendaCombustivel";
            this.lblVendaCombustivel.Size = new System.Drawing.Size(150, 150);
            this.lblVendaCombustivel.TabIndex = 23;
            this.lblVendaCombustivel.Text = "(F10) Pre Venda";
            this.lblVendaCombustivel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblVendaCombustivel.Click += new System.EventHandler(this.lblVendaCombustivel_Click);
            this.lblVendaCombustivel.MouseEnter += new System.EventHandler(this.lblVendaCombustivel_MouseEnter);
            this.lblVendaCombustivel.MouseLeave += new System.EventHandler(this.lblVendaCombustivel_MouseLeave);
            // 
            // lb_venda_pesagem
            // 
            this.lb_venda_pesagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_venda_pesagem.Image = ((System.Drawing.Image)(resources.GetObject("lb_venda_pesagem.Image")));
            this.lb_venda_pesagem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lb_venda_pesagem.Location = new System.Drawing.Point(627, 0);
            this.lb_venda_pesagem.Name = "lb_venda_pesagem";
            this.lb_venda_pesagem.Size = new System.Drawing.Size(150, 150);
            this.lb_venda_pesagem.TabIndex = 30;
            this.lb_venda_pesagem.Text = "Venda Pesagem";
            this.lb_venda_pesagem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lb_venda_pesagem.Click += new System.EventHandler(this.lb_venda_pesagem_Click);
            this.lb_venda_pesagem.MouseEnter += new System.EventHandler(this.lb_venda_pesagem_MouseEnter);
            this.lb_venda_pesagem.MouseLeave += new System.EventHandler(this.lb_venda_pesagem_MouseLeave);
            // 
            // lblFecharCartao
            // 
            this.lblFecharCartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecharCartao.Image = ((System.Drawing.Image)(resources.GetObject("lblFecharCartao.Image")));
            this.lblFecharCartao.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblFecharCartao.Location = new System.Drawing.Point(783, 0);
            this.lblFecharCartao.Name = "lblFecharCartao";
            this.lblFecharCartao.Size = new System.Drawing.Size(150, 150);
            this.lblFecharCartao.TabIndex = 27;
            this.lblFecharCartao.Text = "(F7) Fechar Venda";
            this.lblFecharCartao.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblFecharCartao.Click += new System.EventHandler(this.lblFecharCartao_Click);
            this.lblFecharCartao.MouseEnter += new System.EventHandler(this.lblFecharCartao_MouseEnter);
            this.lblFecharCartao.MouseLeave += new System.EventHandler(this.lblFecharCartao_MouseLeave);
            // 
            // delivery
            // 
            this.delivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delivery.Image = ((System.Drawing.Image)(resources.GetObject("delivery.Image")));
            this.delivery.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.delivery.Location = new System.Drawing.Point(939, 0);
            this.delivery.Name = "delivery";
            this.delivery.Size = new System.Drawing.Size(150, 150);
            this.delivery.TabIndex = 22;
            this.delivery.Text = "(F11) Delivery";
            this.delivery.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.delivery.Click += new System.EventHandler(this.fastfood_Click);
            this.delivery.MouseEnter += new System.EventHandler(this.delivery_MouseEnter);
            this.delivery.MouseLeave += new System.EventHandler(this.delivery_MouseLeave);
            // 
            // lblAbrirCaixa
            // 
            this.lblAbrirCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbrirCaixa.Image = ((System.Drawing.Image)(resources.GetObject("lblAbrirCaixa.Image")));
            this.lblAbrirCaixa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAbrirCaixa.Location = new System.Drawing.Point(3, 150);
            this.lblAbrirCaixa.Name = "lblAbrirCaixa";
            this.lblAbrirCaixa.Size = new System.Drawing.Size(150, 150);
            this.lblAbrirCaixa.TabIndex = 3;
            this.lblAbrirCaixa.Text = "(F3) \r\nAbrir Caixa";
            this.lblAbrirCaixa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblAbrirCaixa.Click += new System.EventHandler(this.lblAbrirCaixa_Click);
            this.lblAbrirCaixa.MouseEnter += new System.EventHandler(this.lblAbrirCaixa_MouseEnter);
            this.lblAbrirCaixa.MouseLeave += new System.EventHandler(this.lblAbrirCaixa_MouseLeave);
            // 
            // lblFecharCaixa
            // 
            this.lblFecharCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecharCaixa.Image = ((System.Drawing.Image)(resources.GetObject("lblFecharCaixa.Image")));
            this.lblFecharCaixa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblFecharCaixa.Location = new System.Drawing.Point(159, 150);
            this.lblFecharCaixa.Name = "lblFecharCaixa";
            this.lblFecharCaixa.Size = new System.Drawing.Size(150, 150);
            this.lblFecharCaixa.TabIndex = 5;
            this.lblFecharCaixa.Text = "(F4) \r\nFechar Caixa";
            this.lblFecharCaixa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblFecharCaixa.Click += new System.EventHandler(this.lblFecharCaixa_Click);
            this.lblFecharCaixa.MouseEnter += new System.EventHandler(this.lblFecharCaixa_MouseEnter);
            this.lblFecharCaixa.MouseLeave += new System.EventHandler(this.lblFecharCaixa_MouseLeave);
            // 
            // lblAbrirGaveta
            // 
            this.lblAbrirGaveta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbrirGaveta.Image = ((System.Drawing.Image)(resources.GetObject("lblAbrirGaveta.Image")));
            this.lblAbrirGaveta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAbrirGaveta.Location = new System.Drawing.Point(315, 150);
            this.lblAbrirGaveta.Name = "lblAbrirGaveta";
            this.lblAbrirGaveta.Size = new System.Drawing.Size(150, 150);
            this.lblAbrirGaveta.TabIndex = 20;
            this.lblAbrirGaveta.Text = "Abrir Gaveta";
            this.lblAbrirGaveta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblAbrirGaveta.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(471, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 150);
            this.label2.TabIndex = 24;
            this.label2.Text = "(F12) Cadastro Cliente";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // lblHoraboliche
            // 
            this.lblHoraboliche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraboliche.Image = ((System.Drawing.Image)(resources.GetObject("lblHoraboliche.Image")));
            this.lblHoraboliche.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblHoraboliche.Location = new System.Drawing.Point(627, 150);
            this.lblHoraboliche.Name = "lblHoraboliche";
            this.lblHoraboliche.Size = new System.Drawing.Size(150, 150);
            this.lblHoraboliche.TabIndex = 26;
            this.lblHoraboliche.Text = "Valor Serviços";
            this.lblHoraboliche.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblHoraboliche.Visible = false;
            this.lblHoraboliche.Click += new System.EventHandler(this.lblHoraboliche_Click);
            this.lblHoraboliche.MouseEnter += new System.EventHandler(this.lblHoraboliche_MouseEnter);
            this.lblHoraboliche.MouseLeave += new System.EventHandler(this.lblHoraboliche_MouseLeave);
            // 
            // lblRetirada
            // 
            this.lblRetirada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetirada.Image = ((System.Drawing.Image)(resources.GetObject("lblRetirada.Image")));
            this.lblRetirada.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblRetirada.Location = new System.Drawing.Point(783, 150);
            this.lblRetirada.Name = "lblRetirada";
            this.lblRetirada.Size = new System.Drawing.Size(150, 150);
            this.lblRetirada.TabIndex = 29;
            this.lblRetirada.Text = "Suprimento\r\n Retirada";
            this.lblRetirada.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblRetirada.Click += new System.EventHandler(this.lblRetirada_Click);
            this.lblRetirada.MouseEnter += new System.EventHandler(this.lblRetirada_MouseEnter);
            this.lblRetirada.MouseLeave += new System.EventHandler(this.lblRetirada_MouseLeave);
            // 
            // lblSair
            // 
            this.lblSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSair.Image = ((System.Drawing.Image)(resources.GetObject("lblSair.Image")));
            this.lblSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSair.Location = new System.Drawing.Point(3, 300);
            this.lblSair.Name = "lblSair";
            this.lblSair.Size = new System.Drawing.Size(150, 150);
            this.lblSair.TabIndex = 8;
            this.lblSair.Text = "(CTRL + F4)\r\n";
            this.lblSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSair.Click += new System.EventHandler(this.lblSair_Click);
            this.lblSair.MouseEnter += new System.EventHandler(this.lblSair_MouseEnter);
            this.lblSair.MouseLeave += new System.EventHandler(this.lblSair_MouseLeave);
            // 
            // panelDados1
            // 
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 0);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1241, 542);
            this.panelDados1.TabIndex = 0;
            // 
            // btConsultaPedidos
            // 
            this.btConsultaPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultaPedidos.Image = ((System.Drawing.Image)(resources.GetObject("btConsultaPedidos.Image")));
            this.btConsultaPedidos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btConsultaPedidos.Location = new System.Drawing.Point(939, 150);
            this.btConsultaPedidos.Name = "btConsultaPedidos";
            this.btConsultaPedidos.Size = new System.Drawing.Size(150, 150);
            this.btConsultaPedidos.TabIndex = 31;
            this.btConsultaPedidos.Text = "Consulta Pedidos";
            this.btConsultaPedidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btConsultaPedidos.Click += new System.EventHandler(this.btConsultaPedidos_Click);
            this.btConsultaPedidos.MouseEnter += new System.EventHandler(this.btConsultaPedidos_MouseEnter);
            this.btConsultaPedidos.MouseLeave += new System.EventHandler(this.btConsultaPedidos_MouseLeave);
            // 
            // FPainelRestaurante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 542);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.panelDados1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FPainelRestaurante";
            this.ShowInTaskbar = false;
            this.Text = "Painel Restaurante";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FPainelRestaurante_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FPainelRestaurante_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.pCabec.ResumeLayout(false);
            this.pCabec.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pCabec;
        private System.Windows.Forms.Label lblHoraIni;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPdv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblAbrirCaixa;
        private System.Windows.Forms.Label lblFecharCaixa;
        private System.Windows.Forms.Label lblAbrirGaveta;
        private System.Windows.Forms.Label lblSair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label delivery;
        private System.Windows.Forms.Label lblVendaCombustivel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPistaBoliche;
        private System.Windows.Forms.Label lblHoraboliche;
        private System.Windows.Forms.Label lblFecharCartao;
        private System.Windows.Forms.Label lblStatusCartao;
        private System.Windows.Forms.Label lblRetirada;
        private System.Windows.Forms.Label lb_venda_pesagem;
        private System.Windows.Forms.Label btConsultaPedidos;
    }
}