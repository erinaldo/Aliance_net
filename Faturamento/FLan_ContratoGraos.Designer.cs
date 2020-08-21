namespace Faturamento
{
    partial class FLan_ContratoGraos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLan_ContratoGraos));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar = new System.Windows.Forms.ToolStripButton();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.Pn_Graos = new Componentes.PanelDados(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.Pn_CFGPedDeposito = new Componentes.PanelDados(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.Frequencia_Quebra = new Componentes.EditFloat(this.components);
            this.label26 = new System.Windows.Forms.Label();
            this.Carencia_Quebra = new Componentes.EditFloat(this.components);
            this.label24 = new System.Windows.Forms.Label();
            this.Vl_QuebraTecnica = new Componentes.EditFloat(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.Frequencia_TXArm = new Componentes.EditFloat(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.Carencia_TXArm = new Componentes.EditFloat(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.Vl_Tx_Armazenagem = new Componentes.EditFloat(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.Vl_Tx_Expedicao = new Componentes.EditFloat(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.Vl_Tx_Recepcao = new Componentes.EditFloat(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.DS_ObsGraos = new Componentes.EditDefault(this.components);
            this.ST_FretePago = new Componentes.CheckBoxDefault(this.components);
            this.ST_GMO = new Componentes.CheckBoxDefault(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.DT_Prazo = new Componentes.EditData(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.Tp_Natureza = new Componentes.ComboBoxDefault(this.components);
            this.DS_AnoSafra = new Componentes.EditDefault(this.components);
            this.BB_AnoSafra = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.AnoSafra = new Componentes.EditDefault(this.components);
            this.NM_TabelaDesconto = new Componentes.EditDefault(this.components);
            this.BB_TabelaDesconto = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.CD_TabelaDesconto = new Componentes.EditDefault(this.components);
            this.DS_EnderecoEntrega = new Componentes.EditDefault(this.components);
            this.BB_EnderecoEntrega = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.CD_EnderecoEntrega = new Componentes.EditDefault(this.components);
            this.NM_CliforEntrega = new Componentes.EditDefault(this.components);
            this.BB_CliforEntrega = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.CD_CliforEntrega = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.Nr_CGCCPF = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.Pn_Graos.SuspendLayout();
            this.Pn_CFGPedDeposito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Frequencia_Quebra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carencia_Quebra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_QuebraTecnica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frequencia_TXArm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carencia_TXArm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Tx_Armazenagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Tx_Expedicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Tx_Recepcao)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Alterar,
            this.BB_Gravar,
            this.BB_Excluir,
            this.BB_Cancelar,
            this.BB_Buscar,
            this.BB_Imprimir,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(785, 43);
            this.barraMenu.TabIndex = 3;
            this.barraMenu.TabStop = true;
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
            this.BB_Novo.Text = "(F2)";
            this.BB_Novo.ToolTipText = "Novo Registro";
            // 
            // BB_Alterar
            // 
            this.BB_Alterar.AutoSize = false;
            this.BB_Alterar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Alterar.ForeColor = System.Drawing.Color.Green;
            this.BB_Alterar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Alterar.Image")));
            this.BB_Alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Alterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Alterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Alterar.Name = "BB_Alterar";
            this.BB_Alterar.Size = new System.Drawing.Size(75, 40);
            this.BB_Alterar.Text = "(F3)";
            this.BB_Alterar.ToolTipText = "Alterar Registro";
            this.BB_Alterar.Visible = false;
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
            this.BB_Gravar.Text = " (F4)";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Visible = false;
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(75, 40);
            this.BB_Excluir.Text = " (F5)";
            this.BB_Excluir.ToolTipText = "Excluir Registro";
            this.BB_Excluir.Visible = false;
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(75, 40);
            this.BB_Cancelar.Text = "(F6)";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Visible = false;
            // 
            // BB_Buscar
            // 
            this.BB_Buscar.AutoSize = false;
            this.BB_Buscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Buscar.Image")));
            this.BB_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Size = new System.Drawing.Size(75, 40);
            this.BB_Buscar.Text = "(F7)";
            this.BB_Buscar.ToolTipText = "Buscar Registros";
            this.BB_Buscar.Visible = false;
            // 
            // BB_Imprimir
            // 
            this.BB_Imprimir.AutoSize = false;
            this.BB_Imprimir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Imprimir.ForeColor = System.Drawing.Color.Green;
            this.BB_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Imprimir.Image")));
            this.BB_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Imprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Imprimir.Name = "BB_Imprimir";
            this.BB_Imprimir.Size = new System.Drawing.Size(75, 40);
            this.BB_Imprimir.Text = "(F8)";
            this.BB_Imprimir.ToolTipText = "Imprimir Registros";
            this.BB_Imprimir.Visible = false;
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
            // 
            // Pn_Graos
            // 
            this.Pn_Graos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pn_Graos.Controls.Add(this.label18);
            this.Pn_Graos.Controls.Add(this.Pn_CFGPedDeposito);
            this.Pn_Graos.Controls.Add(this.label17);
            this.Pn_Graos.Controls.Add(this.DS_ObsGraos);
            this.Pn_Graos.Controls.Add(this.ST_FretePago);
            this.Pn_Graos.Controls.Add(this.ST_GMO);
            this.Pn_Graos.Controls.Add(this.label16);
            this.Pn_Graos.Controls.Add(this.DT_Prazo);
            this.Pn_Graos.Controls.Add(this.label15);
            this.Pn_Graos.Controls.Add(this.Tp_Natureza);
            this.Pn_Graos.Controls.Add(this.DS_AnoSafra);
            this.Pn_Graos.Controls.Add(this.BB_AnoSafra);
            this.Pn_Graos.Controls.Add(this.label14);
            this.Pn_Graos.Controls.Add(this.AnoSafra);
            this.Pn_Graos.Controls.Add(this.NM_TabelaDesconto);
            this.Pn_Graos.Controls.Add(this.BB_TabelaDesconto);
            this.Pn_Graos.Controls.Add(this.label13);
            this.Pn_Graos.Controls.Add(this.CD_TabelaDesconto);
            this.Pn_Graos.Controls.Add(this.DS_EnderecoEntrega);
            this.Pn_Graos.Controls.Add(this.BB_EnderecoEntrega);
            this.Pn_Graos.Controls.Add(this.label12);
            this.Pn_Graos.Controls.Add(this.CD_EnderecoEntrega);
            this.Pn_Graos.Controls.Add(this.NM_CliforEntrega);
            this.Pn_Graos.Controls.Add(this.BB_CliforEntrega);
            this.Pn_Graos.Controls.Add(this.label11);
            this.Pn_Graos.Controls.Add(this.CD_CliforEntrega);
            this.Pn_Graos.Controls.Add(this.label10);
            this.Pn_Graos.Controls.Add(this.Nr_CGCCPF);
            this.Pn_Graos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pn_Graos.Location = new System.Drawing.Point(0, 43);
            this.Pn_Graos.Name = "Pn_Graos";
            this.Pn_Graos.NM_ProcDeletar = "";
            this.Pn_Graos.NM_ProcGravar = "";
            this.Pn_Graos.Size = new System.Drawing.Size(785, 293);
            this.Pn_Graos.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(491, -2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(189, 13);
            this.label18.TabIndex = 40;
            this.label18.Text = "Configurações de Pedido de Depósito:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Pn_CFGPedDeposito
            // 
            this.Pn_CFGPedDeposito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(213)))), ((int)(((byte)(153)))));
            this.Pn_CFGPedDeposito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pn_CFGPedDeposito.Controls.Add(this.label25);
            this.Pn_CFGPedDeposito.Controls.Add(this.Frequencia_Quebra);
            this.Pn_CFGPedDeposito.Controls.Add(this.label26);
            this.Pn_CFGPedDeposito.Controls.Add(this.Carencia_Quebra);
            this.Pn_CFGPedDeposito.Controls.Add(this.label24);
            this.Pn_CFGPedDeposito.Controls.Add(this.Vl_QuebraTecnica);
            this.Pn_CFGPedDeposito.Controls.Add(this.label23);
            this.Pn_CFGPedDeposito.Controls.Add(this.Frequencia_TXArm);
            this.Pn_CFGPedDeposito.Controls.Add(this.label22);
            this.Pn_CFGPedDeposito.Controls.Add(this.Carencia_TXArm);
            this.Pn_CFGPedDeposito.Controls.Add(this.label21);
            this.Pn_CFGPedDeposito.Controls.Add(this.Vl_Tx_Armazenagem);
            this.Pn_CFGPedDeposito.Controls.Add(this.label20);
            this.Pn_CFGPedDeposito.Controls.Add(this.Vl_Tx_Expedicao);
            this.Pn_CFGPedDeposito.Controls.Add(this.label19);
            this.Pn_CFGPedDeposito.Controls.Add(this.Vl_Tx_Recepcao);
            this.Pn_CFGPedDeposito.Location = new System.Drawing.Point(488, 12);
            this.Pn_CFGPedDeposito.Name = "Pn_CFGPedDeposito";
            this.Pn_CFGPedDeposito.NM_ProcDeletar = "";
            this.Pn_CFGPedDeposito.NM_ProcGravar = "";
            this.Pn_CFGPedDeposito.Size = new System.Drawing.Size(283, 255);
            this.Pn_CFGPedDeposito.TabIndex = 18;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(128, 230);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 13);
            this.label25.TabIndex = 15;
            this.label25.Text = "Frequência:";
            // 
            // Frequencia_Quebra
            // 
            this.Frequencia_Quebra.Enabled = false;
            this.Frequencia_Quebra.Location = new System.Drawing.Point(196, 228);
            this.Frequencia_Quebra.Name = "Frequencia_Quebra";
            this.Frequencia_Quebra.NM_Alias = "";
            this.Frequencia_Quebra.NM_Campo = "Frequencia_QuebraTec";
            this.Frequencia_Quebra.NM_Param = "@P_FREQUENCIA_QUEBRATEC";
            this.Frequencia_Quebra.Operador = "";
            this.Frequencia_Quebra.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Frequencia_Quebra.Size = new System.Drawing.Size(54, 20);
            this.Frequencia_Quebra.ST_AutoInc = false;
            this.Frequencia_Quebra.ST_DisableAuto = false;
            this.Frequencia_Quebra.ST_Gravar = true;
            this.Frequencia_Quebra.ST_LimparCampo = true;
            this.Frequencia_Quebra.ST_NotNull = false;
            this.Frequencia_Quebra.ST_PrimaryKey = false;
            this.Frequencia_Quebra.TabIndex = 8;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(83, 202);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(108, 13);
            this.label26.TabIndex = 13;
            this.label26.Text = "Período de Carência:";
            // 
            // Carencia_Quebra
            // 
            this.Carencia_Quebra.Enabled = false;
            this.Carencia_Quebra.Location = new System.Drawing.Point(196, 200);
            this.Carencia_Quebra.Name = "Carencia_Quebra";
            this.Carencia_Quebra.NM_Alias = "";
            this.Carencia_Quebra.NM_Campo = "PeriodoCarencia_QuebraTec";
            this.Carencia_Quebra.NM_Param = "@P_PERIODOCARENCIA_QUEBRATEC";
            this.Carencia_Quebra.Operador = "";
            this.Carencia_Quebra.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Carencia_Quebra.Size = new System.Drawing.Size(54, 20);
            this.Carencia_Quebra.ST_AutoInc = false;
            this.Carencia_Quebra.ST_DisableAuto = false;
            this.Carencia_Quebra.ST_Gravar = true;
            this.Carencia_Quebra.ST_LimparCampo = true;
            this.Carencia_Quebra.ST_NotNull = false;
            this.Carencia_Quebra.ST_PrimaryKey = false;
            this.Carencia_Quebra.TabIndex = 6;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(36, 174);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(155, 13);
            this.label24.TabIndex = 11;
            this.label24.Text = "Valor da Quebra técnica p/UN:";
            // 
            // Vl_QuebraTecnica
            // 
            this.Vl_QuebraTecnica.DecimalPlaces = 7;
            this.Vl_QuebraTecnica.Enabled = false;
            this.Vl_QuebraTecnica.Location = new System.Drawing.Point(196, 172);
            this.Vl_QuebraTecnica.Name = "Vl_QuebraTecnica";
            this.Vl_QuebraTecnica.NM_Alias = "";
            this.Vl_QuebraTecnica.NM_Campo = "Vl_QuebraTecnica";
            this.Vl_QuebraTecnica.NM_Param = "@P_VL_QUEBRATECNICA";
            this.Vl_QuebraTecnica.Operador = "";
            this.Vl_QuebraTecnica.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Vl_QuebraTecnica.Size = new System.Drawing.Size(83, 20);
            this.Vl_QuebraTecnica.ST_AutoInc = false;
            this.Vl_QuebraTecnica.ST_DisableAuto = false;
            this.Vl_QuebraTecnica.ST_Gravar = true;
            this.Vl_QuebraTecnica.ST_LimparCampo = true;
            this.Vl_QuebraTecnica.ST_NotNull = false;
            this.Vl_QuebraTecnica.ST_PrimaryKey = false;
            this.Vl_QuebraTecnica.TabIndex = 5;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(128, 138);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 13);
            this.label23.TabIndex = 9;
            this.label23.Text = "Frequência:";
            // 
            // Frequencia_TXArm
            // 
            this.Frequencia_TXArm.Enabled = false;
            this.Frequencia_TXArm.Location = new System.Drawing.Point(197, 136);
            this.Frequencia_TXArm.Name = "Frequencia_TXArm";
            this.Frequencia_TXArm.NM_Alias = "";
            this.Frequencia_TXArm.NM_Campo = "Frequencia_TXARM";
            this.Frequencia_TXArm.NM_Param = "@P_FREQUENCIA_";
            this.Frequencia_TXArm.Operador = "";
            this.Frequencia_TXArm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Frequencia_TXArm.Size = new System.Drawing.Size(54, 20);
            this.Frequencia_TXArm.ST_AutoInc = false;
            this.Frequencia_TXArm.ST_DisableAuto = false;
            this.Frequencia_TXArm.ST_Gravar = true;
            this.Frequencia_TXArm.ST_LimparCampo = true;
            this.Frequencia_TXArm.ST_NotNull = false;
            this.Frequencia_TXArm.ST_PrimaryKey = false;
            this.Frequencia_TXArm.TabIndex = 4;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(83, 110);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(108, 13);
            this.label22.TabIndex = 7;
            this.label22.Text = "Período de Carência:";
            // 
            // Carencia_TXArm
            // 
            this.Carencia_TXArm.Enabled = false;
            this.Carencia_TXArm.Location = new System.Drawing.Point(197, 108);
            this.Carencia_TXArm.Name = "Carencia_TXArm";
            this.Carencia_TXArm.NM_Alias = "";
            this.Carencia_TXArm.NM_Campo = "PeriodoCarencia_TXArm";
            this.Carencia_TXArm.NM_Param = "@P_PERIODOCARENCIA";
            this.Carencia_TXArm.Operador = "";
            this.Carencia_TXArm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Carencia_TXArm.Size = new System.Drawing.Size(54, 20);
            this.Carencia_TXArm.ST_AutoInc = false;
            this.Carencia_TXArm.ST_DisableAuto = false;
            this.Carencia_TXArm.ST_Gravar = true;
            this.Carencia_TXArm.ST_LimparCampo = true;
            this.Carencia_TXArm.ST_NotNull = false;
            this.Carencia_TXArm.ST_PrimaryKey = false;
            this.Carencia_TXArm.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(-2, 82);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(193, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "VL da taxa de ARMAZENAGEM p/UN:";
            // 
            // Vl_Tx_Armazenagem
            // 
            this.Vl_Tx_Armazenagem.DecimalPlaces = 7;
            this.Vl_Tx_Armazenagem.Enabled = false;
            this.Vl_Tx_Armazenagem.Location = new System.Drawing.Point(196, 80);
            this.Vl_Tx_Armazenagem.Name = "Vl_Tx_Armazenagem";
            this.Vl_Tx_Armazenagem.NM_Alias = "";
            this.Vl_Tx_Armazenagem.NM_Campo = "Vl_TX_Armazenagem";
            this.Vl_Tx_Armazenagem.NM_Param = "@P_VL_TX_ARMAZENAGEM";
            this.Vl_Tx_Armazenagem.Operador = "";
            this.Vl_Tx_Armazenagem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Vl_Tx_Armazenagem.Size = new System.Drawing.Size(83, 20);
            this.Vl_Tx_Armazenagem.ST_AutoInc = false;
            this.Vl_Tx_Armazenagem.ST_DisableAuto = false;
            this.Vl_Tx_Armazenagem.ST_Gravar = true;
            this.Vl_Tx_Armazenagem.ST_LimparCampo = true;
            this.Vl_Tx_Armazenagem.ST_NotNull = false;
            this.Vl_Tx_Armazenagem.ST_PrimaryKey = false;
            this.Vl_Tx_Armazenagem.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(181, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "Valor da taxa de EXPEDIÇÃO p/UN:";
            // 
            // Vl_Tx_Expedicao
            // 
            this.Vl_Tx_Expedicao.DecimalPlaces = 7;
            this.Vl_Tx_Expedicao.Enabled = false;
            this.Vl_Tx_Expedicao.Location = new System.Drawing.Point(196, 37);
            this.Vl_Tx_Expedicao.Name = "Vl_Tx_Expedicao";
            this.Vl_Tx_Expedicao.NM_Alias = "";
            this.Vl_Tx_Expedicao.NM_Campo = "Vl_TX_Expedicao";
            this.Vl_Tx_Expedicao.NM_Param = "@P_VL_TX_EXPEDICAO";
            this.Vl_Tx_Expedicao.Operador = "";
            this.Vl_Tx_Expedicao.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Vl_Tx_Expedicao.Size = new System.Drawing.Size(83, 20);
            this.Vl_Tx_Expedicao.ST_AutoInc = false;
            this.Vl_Tx_Expedicao.ST_DisableAuto = false;
            this.Vl_Tx_Expedicao.ST_Gravar = true;
            this.Vl_Tx_Expedicao.ST_LimparCampo = true;
            this.Vl_Tx_Expedicao.ST_NotNull = false;
            this.Vl_Tx_Expedicao.ST_PrimaryKey = false;
            this.Vl_Tx_Expedicao.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(178, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Valor da taxa de RECEPÇÃO p/UN:";
            // 
            // Vl_Tx_Recepcao
            // 
            this.Vl_Tx_Recepcao.DecimalPlaces = 7;
            this.Vl_Tx_Recepcao.Enabled = false;
            this.Vl_Tx_Recepcao.Location = new System.Drawing.Point(196, 9);
            this.Vl_Tx_Recepcao.Name = "Vl_Tx_Recepcao";
            this.Vl_Tx_Recepcao.NM_Alias = "";
            this.Vl_Tx_Recepcao.NM_Campo = "Vl_TX_Recepcao";
            this.Vl_Tx_Recepcao.NM_Param = "@P_VL_TX_RECEPCAO";
            this.Vl_Tx_Recepcao.Operador = "";
            this.Vl_Tx_Recepcao.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Vl_Tx_Recepcao.Size = new System.Drawing.Size(83, 20);
            this.Vl_Tx_Recepcao.ST_AutoInc = false;
            this.Vl_Tx_Recepcao.ST_DisableAuto = false;
            this.Vl_Tx_Recepcao.ST_Gravar = true;
            this.Vl_Tx_Recepcao.ST_LimparCampo = true;
            this.Vl_Tx_Recepcao.ST_NotNull = false;
            this.Vl_Tx_Recepcao.ST_PrimaryKey = false;
            this.Vl_Tx_Recepcao.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(56, 192);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "Observação:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_ObsGraos
            // 
            this.DS_ObsGraos.BackColor = System.Drawing.SystemColors.Window;
            this.DS_ObsGraos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_ObsGraos.Enabled = false;
            this.DS_ObsGraos.Location = new System.Drawing.Point(124, 192);
            this.DS_ObsGraos.Multiline = true;
            this.DS_ObsGraos.Name = "DS_ObsGraos";
            this.DS_ObsGraos.NM_Alias = "";
            this.DS_ObsGraos.NM_Campo = "";
            this.DS_ObsGraos.NM_CampoBusca = "";
            this.DS_ObsGraos.NM_Param = "";
            this.DS_ObsGraos.QTD_Zero = 0;
            this.DS_ObsGraos.Size = new System.Drawing.Size(358, 74);
            this.DS_ObsGraos.ST_AutoInc = false;
            this.DS_ObsGraos.ST_DisableAuto = false;
            this.DS_ObsGraos.ST_Float = false;
            this.DS_ObsGraos.ST_Gravar = true;
            this.DS_ObsGraos.ST_Int = false;
            this.DS_ObsGraos.ST_LimpaCampo = true;
            this.DS_ObsGraos.ST_NotNull = false;
            this.DS_ObsGraos.ST_PrimaryKey = false;
            this.DS_ObsGraos.TabIndex = 17;
            // 
            // ST_FretePago
            // 
            this.ST_FretePago.AutoSize = true;
            this.ST_FretePago.Enabled = false;
            this.ST_FretePago.Location = new System.Drawing.Point(252, 168);
            this.ST_FretePago.Name = "ST_FretePago";
            this.ST_FretePago.NM_Alias = "";
            this.ST_FretePago.NM_Campo = "";
            this.ST_FretePago.NM_Param = "";
            this.ST_FretePago.Size = new System.Drawing.Size(145, 17);
            this.ST_FretePago.ST_Gravar = false;
            this.ST_FretePago.ST_LimparCampo = true;
            this.ST_FretePago.ST_NotNull = false;
            this.ST_FretePago.TabIndex = 16;
            this.ST_FretePago.Text = "Frete Pago pelo Emitente";
            this.ST_FretePago.UseVisualStyleBackColor = true;
            this.ST_FretePago.Vl_False = "N";
            this.ST_FretePago.Vl_True = "S";
            // 
            // ST_GMO
            // 
            this.ST_GMO.AutoSize = true;
            this.ST_GMO.Enabled = false;
            this.ST_GMO.Location = new System.Drawing.Point(252, 142);
            this.ST_GMO.Name = "ST_GMO";
            this.ST_GMO.NM_Alias = "";
            this.ST_GMO.NM_Campo = "";
            this.ST_GMO.NM_Param = "";
            this.ST_GMO.Size = new System.Drawing.Size(240, 17);
            this.ST_GMO.ST_Gravar = false;
            this.ST_GMO.ST_LimparCampo = true;
            this.ST_GMO.ST_NotNull = false;
            this.ST_GMO.TabIndex = 14;
            this.ST_GMO.Text = "Contém produtos modificados Genéticamente";
            this.ST_GMO.UseVisualStyleBackColor = true;
            this.ST_GMO.Vl_False = "N";
            this.ST_GMO.Vl_True = "S";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(-1, 169);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Data Prazo Atendimento:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DT_Prazo
            // 
            this.DT_Prazo.Enabled = false;
            this.DT_Prazo.Location = new System.Drawing.Point(124, 166);
            this.DT_Prazo.Mask = "00/00/0000";
            this.DT_Prazo.Name = "DT_Prazo";
            this.DT_Prazo.NM_Alias = "";
            this.DT_Prazo.NM_Campo = "";
            this.DT_Prazo.NM_CampoBusca = "";
            this.DT_Prazo.NM_Param = "";
            this.DT_Prazo.Operador = "";
            this.DT_Prazo.Size = new System.Drawing.Size(73, 20);
            this.DT_Prazo.ST_Gravar = true;
            this.DT_Prazo.ST_LimpaCampo = true;
            this.DT_Prazo.ST_NotNull = false;
            this.DT_Prazo.ST_PrimaryKey = false;
            this.DT_Prazo.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Tp.Natureza de Classif:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Tp_Natureza
            // 
            this.Tp_Natureza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tp_Natureza.Enabled = false;
            this.Tp_Natureza.FormattingEnabled = true;
            this.Tp_Natureza.Items.AddRange(new object[] {
            "ORIGEM",
            "DESTINO"});
            this.Tp_Natureza.Location = new System.Drawing.Point(124, 139);
            this.Tp_Natureza.Name = "Tp_Natureza";
            this.Tp_Natureza.NM_Alias = "";
            this.Tp_Natureza.NM_Campo = "Tp_Natureza";
            this.Tp_Natureza.NM_Param = "@P_TP_NATUREZA";
            this.Tp_Natureza.Size = new System.Drawing.Size(121, 21);
            this.Tp_Natureza.ST_Gravar = true;
            this.Tp_Natureza.ST_LimparCampo = true;
            this.Tp_Natureza.ST_NotNull = true;
            this.Tp_Natureza.TabIndex = 13;
            // 
            // DS_AnoSafra
            // 
            this.DS_AnoSafra.BackColor = System.Drawing.SystemColors.Window;
            this.DS_AnoSafra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_AnoSafra.Enabled = false;
            this.DS_AnoSafra.Location = new System.Drawing.Point(204, 112);
            this.DS_AnoSafra.Name = "DS_AnoSafra";
            this.DS_AnoSafra.NM_Alias = "";
            this.DS_AnoSafra.NM_Campo = "DS_Safra";
            this.DS_AnoSafra.NM_CampoBusca = "DS_Safra";
            this.DS_AnoSafra.NM_Param = "@P_DS_SAFRA";
            this.DS_AnoSafra.QTD_Zero = 0;
            this.DS_AnoSafra.ReadOnly = true;
            this.DS_AnoSafra.Size = new System.Drawing.Size(279, 20);
            this.DS_AnoSafra.ST_AutoInc = false;
            this.DS_AnoSafra.ST_DisableAuto = false;
            this.DS_AnoSafra.ST_Float = false;
            this.DS_AnoSafra.ST_Gravar = false;
            this.DS_AnoSafra.ST_Int = false;
            this.DS_AnoSafra.ST_LimpaCampo = true;
            this.DS_AnoSafra.ST_NotNull = false;
            this.DS_AnoSafra.ST_PrimaryKey = false;
            this.DS_AnoSafra.TabIndex = 12;
            // 
            // BB_AnoSafra
            // 
            this.BB_AnoSafra.Enabled = false;
            this.BB_AnoSafra.Image = ((System.Drawing.Image)(resources.GetObject("BB_AnoSafra.Image")));
            this.BB_AnoSafra.Location = new System.Drawing.Point(175, 112);
            this.BB_AnoSafra.Name = "BB_AnoSafra";
            this.BB_AnoSafra.Size = new System.Drawing.Size(28, 19);
            this.BB_AnoSafra.TabIndex = 11;
            this.BB_AnoSafra.UseVisualStyleBackColor = true;
            this.BB_AnoSafra.Click += new System.EventHandler(this.BB_AnoSafra_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(67, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Ano Safra:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AnoSafra
            // 
            this.AnoSafra.BackColor = System.Drawing.SystemColors.Window;
            this.AnoSafra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AnoSafra.Enabled = false;
            this.AnoSafra.Location = new System.Drawing.Point(124, 112);
            this.AnoSafra.Name = "AnoSafra";
            this.AnoSafra.NM_Alias = "";
            this.AnoSafra.NM_Campo = "AnoSafra";
            this.AnoSafra.NM_CampoBusca = "AnoSafra";
            this.AnoSafra.NM_Param = "@P_ANOSAFRA";
            this.AnoSafra.QTD_Zero = 0;
            this.AnoSafra.Size = new System.Drawing.Size(49, 20);
            this.AnoSafra.ST_AutoInc = false;
            this.AnoSafra.ST_DisableAuto = false;
            this.AnoSafra.ST_Float = false;
            this.AnoSafra.ST_Gravar = true;
            this.AnoSafra.ST_Int = false;
            this.AnoSafra.ST_LimpaCampo = true;
            this.AnoSafra.ST_NotNull = true;
            this.AnoSafra.ST_PrimaryKey = false;
            this.AnoSafra.TabIndex = 10;
            this.AnoSafra.Leave += new System.EventHandler(this.AnoSafra_Leave);
            // 
            // NM_TabelaDesconto
            // 
            this.NM_TabelaDesconto.BackColor = System.Drawing.SystemColors.Window;
            this.NM_TabelaDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_TabelaDesconto.Enabled = false;
            this.NM_TabelaDesconto.Location = new System.Drawing.Point(233, 87);
            this.NM_TabelaDesconto.Name = "NM_TabelaDesconto";
            this.NM_TabelaDesconto.NM_Alias = "";
            this.NM_TabelaDesconto.NM_Campo = "DS_TabelaDesconto";
            this.NM_TabelaDesconto.NM_CampoBusca = "DS_TabelaDesconto";
            this.NM_TabelaDesconto.NM_Param = "@P_DS_TABELADESCONTO";
            this.NM_TabelaDesconto.QTD_Zero = 0;
            this.NM_TabelaDesconto.ReadOnly = true;
            this.NM_TabelaDesconto.Size = new System.Drawing.Size(250, 20);
            this.NM_TabelaDesconto.ST_AutoInc = false;
            this.NM_TabelaDesconto.ST_DisableAuto = false;
            this.NM_TabelaDesconto.ST_Float = false;
            this.NM_TabelaDesconto.ST_Gravar = false;
            this.NM_TabelaDesconto.ST_Int = false;
            this.NM_TabelaDesconto.ST_LimpaCampo = true;
            this.NM_TabelaDesconto.ST_NotNull = false;
            this.NM_TabelaDesconto.ST_PrimaryKey = false;
            this.NM_TabelaDesconto.TabIndex = 9;
            // 
            // BB_TabelaDesconto
            // 
            this.BB_TabelaDesconto.Enabled = false;
            this.BB_TabelaDesconto.Image = ((System.Drawing.Image)(resources.GetObject("BB_TabelaDesconto.Image")));
            this.BB_TabelaDesconto.Location = new System.Drawing.Point(204, 87);
            this.BB_TabelaDesconto.Name = "BB_TabelaDesconto";
            this.BB_TabelaDesconto.Size = new System.Drawing.Size(28, 19);
            this.BB_TabelaDesconto.TabIndex = 8;
            this.BB_TabelaDesconto.UseVisualStyleBackColor = true;
            this.BB_TabelaDesconto.Click += new System.EventHandler(this.BB_TabelaDesconto_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "CD.Tabela Desconto:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_TabelaDesconto
            // 
            this.CD_TabelaDesconto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_TabelaDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_TabelaDesconto.Enabled = false;
            this.CD_TabelaDesconto.Location = new System.Drawing.Point(124, 87);
            this.CD_TabelaDesconto.Name = "CD_TabelaDesconto";
            this.CD_TabelaDesconto.NM_Alias = "";
            this.CD_TabelaDesconto.NM_Campo = "CD_TabelaDesconto";
            this.CD_TabelaDesconto.NM_CampoBusca = "CD_TabelaDesconto";
            this.CD_TabelaDesconto.NM_Param = "@P_CD_TABELADESCONTO";
            this.CD_TabelaDesconto.QTD_Zero = 0;
            this.CD_TabelaDesconto.Size = new System.Drawing.Size(79, 20);
            this.CD_TabelaDesconto.ST_AutoInc = false;
            this.CD_TabelaDesconto.ST_DisableAuto = false;
            this.CD_TabelaDesconto.ST_Float = false;
            this.CD_TabelaDesconto.ST_Gravar = true;
            this.CD_TabelaDesconto.ST_Int = false;
            this.CD_TabelaDesconto.ST_LimpaCampo = true;
            this.CD_TabelaDesconto.ST_NotNull = true;
            this.CD_TabelaDesconto.ST_PrimaryKey = false;
            this.CD_TabelaDesconto.TabIndex = 7;
            this.CD_TabelaDesconto.Leave += new System.EventHandler(this.CD_TabelaDesconto_Leave);
            // 
            // DS_EnderecoEntrega
            // 
            this.DS_EnderecoEntrega.BackColor = System.Drawing.SystemColors.Window;
            this.DS_EnderecoEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_EnderecoEntrega.Enabled = false;
            this.DS_EnderecoEntrega.Location = new System.Drawing.Point(203, 62);
            this.DS_EnderecoEntrega.Name = "DS_EnderecoEntrega";
            this.DS_EnderecoEntrega.NM_Alias = "";
            this.DS_EnderecoEntrega.NM_Campo = "DS_Endereco";
            this.DS_EnderecoEntrega.NM_CampoBusca = "DS_Endereco";
            this.DS_EnderecoEntrega.NM_Param = "@P_DS_ENDERECO";
            this.DS_EnderecoEntrega.QTD_Zero = 0;
            this.DS_EnderecoEntrega.ReadOnly = true;
            this.DS_EnderecoEntrega.Size = new System.Drawing.Size(280, 20);
            this.DS_EnderecoEntrega.ST_AutoInc = false;
            this.DS_EnderecoEntrega.ST_DisableAuto = false;
            this.DS_EnderecoEntrega.ST_Float = false;
            this.DS_EnderecoEntrega.ST_Gravar = false;
            this.DS_EnderecoEntrega.ST_Int = false;
            this.DS_EnderecoEntrega.ST_LimpaCampo = true;
            this.DS_EnderecoEntrega.ST_NotNull = false;
            this.DS_EnderecoEntrega.ST_PrimaryKey = false;
            this.DS_EnderecoEntrega.TabIndex = 6;
            // 
            // BB_EnderecoEntrega
            // 
            this.BB_EnderecoEntrega.Enabled = false;
            this.BB_EnderecoEntrega.Image = ((System.Drawing.Image)(resources.GetObject("BB_EnderecoEntrega.Image")));
            this.BB_EnderecoEntrega.Location = new System.Drawing.Point(174, 62);
            this.BB_EnderecoEntrega.Name = "BB_EnderecoEntrega";
            this.BB_EnderecoEntrega.Size = new System.Drawing.Size(28, 19);
            this.BB_EnderecoEntrega.TabIndex = 5;
            this.BB_EnderecoEntrega.UseVisualStyleBackColor = true;
            this.BB_EnderecoEntrega.Click += new System.EventHandler(this.BB_EnderecoEntrega_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "CD.Endereço/Entrega:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_EnderecoEntrega
            // 
            this.CD_EnderecoEntrega.BackColor = System.Drawing.SystemColors.Window;
            this.CD_EnderecoEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_EnderecoEntrega.Enabled = false;
            this.CD_EnderecoEntrega.Location = new System.Drawing.Point(124, 62);
            this.CD_EnderecoEntrega.Name = "CD_EnderecoEntrega";
            this.CD_EnderecoEntrega.NM_Alias = "";
            this.CD_EnderecoEntrega.NM_Campo = "CD_Endereco";
            this.CD_EnderecoEntrega.NM_CampoBusca = "CD_Endereco";
            this.CD_EnderecoEntrega.NM_Param = "@P_CD_ENDERECO";
            this.CD_EnderecoEntrega.QTD_Zero = 0;
            this.CD_EnderecoEntrega.Size = new System.Drawing.Size(49, 20);
            this.CD_EnderecoEntrega.ST_AutoInc = false;
            this.CD_EnderecoEntrega.ST_DisableAuto = false;
            this.CD_EnderecoEntrega.ST_Float = false;
            this.CD_EnderecoEntrega.ST_Gravar = true;
            this.CD_EnderecoEntrega.ST_Int = false;
            this.CD_EnderecoEntrega.ST_LimpaCampo = true;
            this.CD_EnderecoEntrega.ST_NotNull = true;
            this.CD_EnderecoEntrega.ST_PrimaryKey = false;
            this.CD_EnderecoEntrega.TabIndex = 4;
            this.CD_EnderecoEntrega.Leave += new System.EventHandler(this.CD_EnderecoEntrega_Leave);
            // 
            // NM_CliforEntrega
            // 
            this.NM_CliforEntrega.BackColor = System.Drawing.SystemColors.Window;
            this.NM_CliforEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_CliforEntrega.Enabled = false;
            this.NM_CliforEntrega.Location = new System.Drawing.Point(233, 36);
            this.NM_CliforEntrega.Name = "NM_CliforEntrega";
            this.NM_CliforEntrega.NM_Alias = "";
            this.NM_CliforEntrega.NM_Campo = "NM_Clifor";
            this.NM_CliforEntrega.NM_CampoBusca = "NM_Clifor";
            this.NM_CliforEntrega.NM_Param = "@P_NM_CLIFOR";
            this.NM_CliforEntrega.QTD_Zero = 0;
            this.NM_CliforEntrega.ReadOnly = true;
            this.NM_CliforEntrega.Size = new System.Drawing.Size(250, 20);
            this.NM_CliforEntrega.ST_AutoInc = false;
            this.NM_CliforEntrega.ST_DisableAuto = false;
            this.NM_CliforEntrega.ST_Float = false;
            this.NM_CliforEntrega.ST_Gravar = false;
            this.NM_CliforEntrega.ST_Int = false;
            this.NM_CliforEntrega.ST_LimpaCampo = true;
            this.NM_CliforEntrega.ST_NotNull = false;
            this.NM_CliforEntrega.ST_PrimaryKey = false;
            this.NM_CliforEntrega.TabIndex = 3;
            // 
            // BB_CliforEntrega
            // 
            this.BB_CliforEntrega.Enabled = false;
            this.BB_CliforEntrega.Image = ((System.Drawing.Image)(resources.GetObject("BB_CliforEntrega.Image")));
            this.BB_CliforEntrega.Location = new System.Drawing.Point(204, 36);
            this.BB_CliforEntrega.Name = "BB_CliforEntrega";
            this.BB_CliforEntrega.Size = new System.Drawing.Size(28, 19);
            this.BB_CliforEntrega.TabIndex = 2;
            this.BB_CliforEntrega.UseVisualStyleBackColor = true;
            this.BB_CliforEntrega.Click += new System.EventHandler(this.BB_CliforEntrega_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "CD.Clifor/Local Entrega:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_CliforEntrega
            // 
            this.CD_CliforEntrega.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CliforEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CliforEntrega.Enabled = false;
            this.CD_CliforEntrega.Location = new System.Drawing.Point(124, 36);
            this.CD_CliforEntrega.Name = "CD_CliforEntrega";
            this.CD_CliforEntrega.NM_Alias = "";
            this.CD_CliforEntrega.NM_Campo = "CD_Clifor";
            this.CD_CliforEntrega.NM_CampoBusca = "CD_Clifor";
            this.CD_CliforEntrega.NM_Param = "@P_CD_CLIFOR";
            this.CD_CliforEntrega.QTD_Zero = 0;
            this.CD_CliforEntrega.Size = new System.Drawing.Size(79, 20);
            this.CD_CliforEntrega.ST_AutoInc = false;
            this.CD_CliforEntrega.ST_DisableAuto = false;
            this.CD_CliforEntrega.ST_Float = false;
            this.CD_CliforEntrega.ST_Gravar = true;
            this.CD_CliforEntrega.ST_Int = false;
            this.CD_CliforEntrega.ST_LimpaCampo = true;
            this.CD_CliforEntrega.ST_NotNull = true;
            this.CD_CliforEntrega.ST_PrimaryKey = false;
            this.CD_CliforEntrega.TabIndex = 1;
            this.CD_CliforEntrega.Leave += new System.EventHandler(this.CD_CliforEntrega_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "CNPJ/CPF:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Nr_CGCCPF
            // 
            this.Nr_CGCCPF.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_CGCCPF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_CGCCPF.Enabled = false;
            this.Nr_CGCCPF.Location = new System.Drawing.Point(124, 10);
            this.Nr_CGCCPF.Name = "Nr_CGCCPF";
            this.Nr_CGCCPF.NM_Alias = "";
            this.Nr_CGCCPF.NM_Campo = "";
            this.Nr_CGCCPF.NM_CampoBusca = "";
            this.Nr_CGCCPF.NM_Param = "";
            this.Nr_CGCCPF.QTD_Zero = 0;
            this.Nr_CGCCPF.ReadOnly = true;
            this.Nr_CGCCPF.Size = new System.Drawing.Size(128, 20);
            this.Nr_CGCCPF.ST_AutoInc = false;
            this.Nr_CGCCPF.ST_DisableAuto = false;
            this.Nr_CGCCPF.ST_Float = false;
            this.Nr_CGCCPF.ST_Gravar = false;
            this.Nr_CGCCPF.ST_Int = false;
            this.Nr_CGCCPF.ST_LimpaCampo = true;
            this.Nr_CGCCPF.ST_NotNull = false;
            this.Nr_CGCCPF.ST_PrimaryKey = false;
            this.Nr_CGCCPF.TabIndex = 0;
            // 
            // FLan_ContratoGraos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 336);
            this.Controls.Add(this.Pn_Graos);
            this.Controls.Add(this.barraMenu);
            this.Name = "FLan_ContratoGraos";
            this.Text = "FLan_ContratoGraos";
            this.Load += new System.EventHandler(this.FLan_ContratoGraos_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.Pn_Graos.ResumeLayout(false);
            this.Pn_Graos.PerformLayout();
            this.Pn_CFGPedDeposito.ResumeLayout(false);
            this.Pn_CFGPedDeposito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Frequencia_Quebra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carencia_Quebra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_QuebraTecnica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frequencia_TXArm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carencia_TXArm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Tx_Armazenagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Tx_Expedicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Tx_Recepcao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Alterar;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripButton BB_Imprimir;
        private System.Windows.Forms.ToolStripButton BB_Fechar;
        private Componentes.PanelDados Pn_Graos;
        private System.Windows.Forms.Label label18;
        private Componentes.PanelDados Pn_CFGPedDeposito;
        private System.Windows.Forms.Label label25;
        private Componentes.EditFloat Frequencia_Quebra;
        private System.Windows.Forms.Label label26;
        private Componentes.EditFloat Carencia_Quebra;
        private System.Windows.Forms.Label label24;
        private Componentes.EditFloat Vl_QuebraTecnica;
        private System.Windows.Forms.Label label23;
        private Componentes.EditFloat Frequencia_TXArm;
        private System.Windows.Forms.Label label22;
        private Componentes.EditFloat Carencia_TXArm;
        private System.Windows.Forms.Label label21;
        private Componentes.EditFloat Vl_Tx_Armazenagem;
        private System.Windows.Forms.Label label20;
        private Componentes.EditFloat Vl_Tx_Expedicao;
        private System.Windows.Forms.Label label19;
        private Componentes.EditFloat Vl_Tx_Recepcao;
        private System.Windows.Forms.Label label17;
        private Componentes.EditDefault DS_ObsGraos;
        private Componentes.CheckBoxDefault ST_FretePago;
        private Componentes.CheckBoxDefault ST_GMO;
        private System.Windows.Forms.Label label16;
        private Componentes.EditData DT_Prazo;
        private System.Windows.Forms.Label label15;
        private Componentes.ComboBoxDefault Tp_Natureza;
        private Componentes.EditDefault DS_AnoSafra;
        private System.Windows.Forms.Button BB_AnoSafra;
        private System.Windows.Forms.Label label14;
        private Componentes.EditDefault AnoSafra;
        private Componentes.EditDefault NM_TabelaDesconto;
        private System.Windows.Forms.Button BB_TabelaDesconto;
        private System.Windows.Forms.Label label13;
        private Componentes.EditDefault CD_TabelaDesconto;
        private Componentes.EditDefault DS_EnderecoEntrega;
        private System.Windows.Forms.Button BB_EnderecoEntrega;
        private System.Windows.Forms.Label label12;
        private Componentes.EditDefault CD_EnderecoEntrega;
        private Componentes.EditDefault NM_CliforEntrega;
        private System.Windows.Forms.Button BB_CliforEntrega;
        private System.Windows.Forms.Label label11;
        private Componentes.EditDefault CD_CliforEntrega;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault Nr_CGCCPF;
    }
}