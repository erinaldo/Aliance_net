namespace Faturamento
{
    partial class TFLanFrenteCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanFrenteCaixa));
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pCabec = new Componentes.PanelDados(this.components);
            this.lblHoraIni = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPdv = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblVendaCombustivel = new System.Windows.Forms.Label();
            this.lblMovimento = new System.Windows.Forms.Label();
            this.lblAbrirCaixa = new System.Windows.Forms.Label();
            this.lblConveniencia = new System.Windows.Forms.Label();
            this.lblFecharCaixa = new System.Windows.Forms.Label();
            this.lblAbrirGaveta = new System.Windows.Forms.Label();
            this.lblVendaPDV = new System.Windows.Forms.Label();
            this.lblRetirada = new System.Windows.Forms.Label();
            this.lblSair = new System.Windows.Forms.Label();
            this.lbFechaSessao = new System.Windows.Forms.Label();
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
            this.tlpCentral.Size = new System.Drawing.Size(1139, 648);
            this.tlpCentral.TabIndex = 0;
            // 
            // pCabec
            // 
            this.pCabec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCabec.Controls.Add(this.lblHoraIni);
            this.pCabec.Controls.Add(this.label5);
            this.pCabec.Controls.Add(this.lblPdv);
            this.pCabec.Controls.Add(this.label4);
            this.pCabec.Controls.Add(this.lblDisplay);
            this.pCabec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCabec.Location = new System.Drawing.Point(6, 6);
            this.pCabec.Name = "pCabec";
            this.pCabec.NM_ProcDeletar = "";
            this.pCabec.NM_ProcGravar = "";
            this.pCabec.Size = new System.Drawing.Size(1127, 115);
            this.pCabec.TabIndex = 0;
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
            // lblDisplay
            // 
            this.lblDisplay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(0, 0);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(1125, 24);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "FRENTE DE CAIXA";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblVendaCombustivel);
            this.flowLayoutPanel1.Controls.Add(this.lblMovimento);
            this.flowLayoutPanel1.Controls.Add(this.lblAbrirCaixa);
            this.flowLayoutPanel1.Controls.Add(this.lblConveniencia);
            this.flowLayoutPanel1.Controls.Add(this.lblFecharCaixa);
            this.flowLayoutPanel1.Controls.Add(this.lblAbrirGaveta);
            this.flowLayoutPanel1.Controls.Add(this.lblVendaPDV);
            this.flowLayoutPanel1.Controls.Add(this.lblRetirada);
            this.flowLayoutPanel1.Controls.Add(this.lbFechaSessao);
            this.flowLayoutPanel1.Controls.Add(this.lblSair);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 130);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1127, 512);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // lblVendaCombustivel
            // 
            this.lblVendaCombustivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendaCombustivel.Image = ((System.Drawing.Image)(resources.GetObject("lblVendaCombustivel.Image")));
            this.lblVendaCombustivel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblVendaCombustivel.Location = new System.Drawing.Point(3, 0);
            this.lblVendaCombustivel.Name = "lblVendaCombustivel";
            this.lblVendaCombustivel.Size = new System.Drawing.Size(150, 150);
            this.lblVendaCombustivel.TabIndex = 14;
            this.lblVendaCombustivel.Text = "(F10) \r\nVenda Combustivel";
            this.lblVendaCombustivel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblVendaCombustivel.Click += new System.EventHandler(this.lblVendaCombustivel_Click);
            this.lblVendaCombustivel.MouseEnter += new System.EventHandler(this.lblVendaCombustivel_MouseEnter);
            this.lblVendaCombustivel.MouseLeave += new System.EventHandler(this.lblVendaCombustivel_MouseLeave);
            // 
            // lblMovimento
            // 
            this.lblMovimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovimento.Image = ((System.Drawing.Image)(resources.GetObject("lblMovimento.Image")));
            this.lblMovimento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMovimento.Location = new System.Drawing.Point(159, 0);
            this.lblMovimento.Name = "lblMovimento";
            this.lblMovimento.Size = new System.Drawing.Size(150, 150);
            this.lblMovimento.TabIndex = 2;
            this.lblMovimento.Text = "(F2)\r\nVenda Rapida";
            this.lblMovimento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMovimento.Click += new System.EventHandler(this.lblMovimento_Click);
            this.lblMovimento.MouseEnter += new System.EventHandler(this.lblMovimento_MouseEnter);
            this.lblMovimento.MouseLeave += new System.EventHandler(this.lblMovimento_MouseLeave);
            // 
            // lblAbrirCaixa
            // 
            this.lblAbrirCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbrirCaixa.Image = ((System.Drawing.Image)(resources.GetObject("lblAbrirCaixa.Image")));
            this.lblAbrirCaixa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAbrirCaixa.Location = new System.Drawing.Point(315, 0);
            this.lblAbrirCaixa.Name = "lblAbrirCaixa";
            this.lblAbrirCaixa.Size = new System.Drawing.Size(150, 150);
            this.lblAbrirCaixa.TabIndex = 3;
            this.lblAbrirCaixa.Text = "(F3) \r\nAbrir Caixa";
            this.lblAbrirCaixa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblAbrirCaixa.Click += new System.EventHandler(this.lblAbrirCaixa_Click);
            this.lblAbrirCaixa.MouseEnter += new System.EventHandler(this.lblAbrirCaixa_MouseEnter);
            this.lblAbrirCaixa.MouseLeave += new System.EventHandler(this.lblAbrirCaixa_MouseLeave);
            // 
            // lblConveniencia
            // 
            this.lblConveniencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConveniencia.Image = ((System.Drawing.Image)(resources.GetObject("lblConveniencia.Image")));
            this.lblConveniencia.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblConveniencia.Location = new System.Drawing.Point(471, 0);
            this.lblConveniencia.Name = "lblConveniencia";
            this.lblConveniencia.Size = new System.Drawing.Size(150, 150);
            this.lblConveniencia.TabIndex = 17;
            this.lblConveniencia.Text = "(F11) \r\nVenda Conveniencia";
            this.lblConveniencia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblConveniencia.Click += new System.EventHandler(this.lblConveniencia_Click);
            this.lblConveniencia.MouseEnter += new System.EventHandler(this.lblConveniencia_MouseEnter);
            this.lblConveniencia.MouseLeave += new System.EventHandler(this.lblConveniencia_MouseLeave);
            // 
            // lblFecharCaixa
            // 
            this.lblFecharCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecharCaixa.Image = ((System.Drawing.Image)(resources.GetObject("lblFecharCaixa.Image")));
            this.lblFecharCaixa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblFecharCaixa.Location = new System.Drawing.Point(627, 0);
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
            this.lblAbrirGaveta.Location = new System.Drawing.Point(783, 0);
            this.lblAbrirGaveta.Name = "lblAbrirGaveta";
            this.lblAbrirGaveta.Size = new System.Drawing.Size(150, 150);
            this.lblAbrirGaveta.TabIndex = 20;
            this.lblAbrirGaveta.Text = "Abrir Gaveta";
            this.lblAbrirGaveta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblAbrirGaveta.Click += new System.EventHandler(this.lblAbrirGaveta_Click);
            this.lblAbrirGaveta.MouseEnter += new System.EventHandler(this.lblAbrirGaveta_MouseEnter);
            this.lblAbrirGaveta.MouseLeave += new System.EventHandler(this.lblAbrirGaveta_MouseLeave);
            // 
            // lblVendaPDV
            // 
            this.lblVendaPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendaPDV.Image = ((System.Drawing.Image)(resources.GetObject("lblVendaPDV.Image")));
            this.lblVendaPDV.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblVendaPDV.Location = new System.Drawing.Point(939, 0);
            this.lblVendaPDV.Name = "lblVendaPDV";
            this.lblVendaPDV.Size = new System.Drawing.Size(150, 150);
            this.lblVendaPDV.TabIndex = 21;
            this.lblVendaPDV.Text = "Venda PDV";
            this.lblVendaPDV.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblVendaPDV.Click += new System.EventHandler(this.lblVendaPDV_Click);
            this.lblVendaPDV.MouseEnter += new System.EventHandler(this.lblVendaPDV_MouseEnter);
            this.lblVendaPDV.MouseLeave += new System.EventHandler(this.lblVendaPDV_MouseLeave);
            // 
            // lblRetirada
            // 
            this.lblRetirada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetirada.Image = ((System.Drawing.Image)(resources.GetObject("lblRetirada.Image")));
            this.lblRetirada.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblRetirada.Location = new System.Drawing.Point(3, 150);
            this.lblRetirada.Name = "lblRetirada";
            this.lblRetirada.Size = new System.Drawing.Size(150, 150);
            this.lblRetirada.TabIndex = 12;
            this.lblRetirada.Text = "(F5) \r\nSuprimento\r\nRetirada";
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
            this.lblSair.Location = new System.Drawing.Point(315, 150);
            this.lblSair.Name = "lblSair";
            this.lblSair.Size = new System.Drawing.Size(150, 150);
            this.lblSair.TabIndex = 8;
            this.lblSair.Text = "(CTRL + F4)\r\n";
            this.lblSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSair.Click += new System.EventHandler(this.lblSair_Click);
            this.lblSair.MouseEnter += new System.EventHandler(this.lblSair_MouseEnter);
            this.lblSair.MouseLeave += new System.EventHandler(this.lblSair_MouseLeave);
            // 
            // lbFechaSessao
            // 
            this.lbFechaSessao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFechaSessao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaSessao.Image = ((System.Drawing.Image)(resources.GetObject("lbFechaSessao.Image")));
            this.lbFechaSessao.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbFechaSessao.Location = new System.Drawing.Point(159, 150);
            this.lbFechaSessao.Name = "lbFechaSessao";
            this.lbFechaSessao.Size = new System.Drawing.Size(150, 150);
            this.lbFechaSessao.TabIndex = 22;
            this.lbFechaSessao.Text = "Fechar Sessão";
            this.lbFechaSessao.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbFechaSessao.Click += new System.EventHandler(this.lbFechaSessao_Click);
            this.lbFechaSessao.MouseEnter += new System.EventHandler(this.lbFechaSessao_MouseEnter);
            this.lbFechaSessao.MouseLeave += new System.EventHandler(this.lbFechaSessao_MouseLeave);
            // 
            // TFLanFrenteCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 648);
            this.Controls.Add(this.tlpCentral);
            this.KeyPreview = true;
            this.Name = "TFLanFrenteCaixa";
            this.ShowInTaskbar = false;
            this.Text = "Frente Caixa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFLanFrenteCaixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanFrenteCaixa_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.pCabec.ResumeLayout(false);
            this.pCabec.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pCabec;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblHoraIni;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPdv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFecharCaixa;
        private System.Windows.Forms.Label lblAbrirCaixa;
        private System.Windows.Forms.Label lblMovimento;
        private System.Windows.Forms.Label lblSair;
        private System.Windows.Forms.Label lblRetirada;
        private System.Windows.Forms.Label lblVendaCombustivel;
        private System.Windows.Forms.Label lblConveniencia;
        private System.Windows.Forms.Label lblAbrirGaveta;
        private System.Windows.Forms.Label lblVendaPDV;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbFechaSessao;
    }
}