namespace Faturamento
{
    partial class TFLan_GeraPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLan_GeraPedido));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pnl_Base = new Componentes.PanelDados(this.components);
            this.pnl_Gera_Pedido = new Componentes.PanelDados(this.components);
            this.nomevendedor = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.cd_vendedor = new Componentes.EditDefault(this.components);
            this.ds_endtransp = new Componentes.EditDefault(this.components);
            this.bb_endtransp = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cd_endtransp = new Componentes.EditDefault(this.components);
            this.ds_transportadora = new Componentes.EditDefault(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cd_transportadora = new Componentes.EditDefault(this.components);
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.BB_Clifor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.DS_LocalEntrega = new Componentes.EditDefault(this.components);
            this.DS_Endereco = new Componentes.EditDefault(this.components);
            this.BB_Endereco = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CD_Endereco = new Componentes.EditDefault(this.components);
            this.Sigla_Moeda = new Componentes.EditDefault(this.components);
            this.DS_Moeda = new Componentes.EditDefault(this.components);
            this.BB_Moeda = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.CD_Moeda = new Componentes.EditDefault(this.components);
            this.DT_Pedido = new Componentes.EditData(this.components);
            this.TP_Mov = new Componentes.EditDefault(this.components);
            this.DS_CFGPedido = new Componentes.EditDefault(this.components);
            this.BB_CFGPedido = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.CFG_Pedido = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pnl_Base.SuspendLayout();
            this.pnl_Gera_Pedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(632, 43);
            this.barraMenu.TabIndex = 0;
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
            this.BB_Gravar.Size = new System.Drawing.Size(120, 40);
            this.BB_Gravar.Text = "(F4)\r\nGera Pedido";
            this.BB_Gravar.ToolTipText = "Gera Pedido";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pnl_Base
            // 
            this.pnl_Base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Base.Controls.Add(this.pnl_Gera_Pedido);
            this.pnl_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Base.Location = new System.Drawing.Point(0, 43);
            this.pnl_Base.Name = "pnl_Base";
            this.pnl_Base.NM_ProcDeletar = "";
            this.pnl_Base.NM_ProcGravar = "";
            this.pnl_Base.Padding = new System.Windows.Forms.Padding(4);
            this.pnl_Base.Size = new System.Drawing.Size(632, 255);
            this.pnl_Base.TabIndex = 3;
            // 
            // pnl_Gera_Pedido
            // 
            this.pnl_Gera_Pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Gera_Pedido.Controls.Add(this.nomevendedor);
            this.pnl_Gera_Pedido.Controls.Add(this.label9);
            this.pnl_Gera_Pedido.Controls.Add(this.cd_vendedor);
            this.pnl_Gera_Pedido.Controls.Add(this.ds_endtransp);
            this.pnl_Gera_Pedido.Controls.Add(this.bb_endtransp);
            this.pnl_Gera_Pedido.Controls.Add(this.label6);
            this.pnl_Gera_Pedido.Controls.Add(this.cd_endtransp);
            this.pnl_Gera_Pedido.Controls.Add(this.ds_transportadora);
            this.pnl_Gera_Pedido.Controls.Add(this.button1);
            this.pnl_Gera_Pedido.Controls.Add(this.label4);
            this.pnl_Gera_Pedido.Controls.Add(this.cd_transportadora);
            this.pnl_Gera_Pedido.Controls.Add(this.NM_Clifor);
            this.pnl_Gera_Pedido.Controls.Add(this.BB_Clifor);
            this.pnl_Gera_Pedido.Controls.Add(this.label2);
            this.pnl_Gera_Pedido.Controls.Add(this.CD_Clifor);
            this.pnl_Gera_Pedido.Controls.Add(this.label5);
            this.pnl_Gera_Pedido.Controls.Add(this.DS_LocalEntrega);
            this.pnl_Gera_Pedido.Controls.Add(this.DS_Endereco);
            this.pnl_Gera_Pedido.Controls.Add(this.BB_Endereco);
            this.pnl_Gera_Pedido.Controls.Add(this.label3);
            this.pnl_Gera_Pedido.Controls.Add(this.CD_Endereco);
            this.pnl_Gera_Pedido.Controls.Add(this.Sigla_Moeda);
            this.pnl_Gera_Pedido.Controls.Add(this.DS_Moeda);
            this.pnl_Gera_Pedido.Controls.Add(this.BB_Moeda);
            this.pnl_Gera_Pedido.Controls.Add(this.label30);
            this.pnl_Gera_Pedido.Controls.Add(this.CD_Moeda);
            this.pnl_Gera_Pedido.Controls.Add(this.DT_Pedido);
            this.pnl_Gera_Pedido.Controls.Add(this.TP_Mov);
            this.pnl_Gera_Pedido.Controls.Add(this.DS_CFGPedido);
            this.pnl_Gera_Pedido.Controls.Add(this.BB_CFGPedido);
            this.pnl_Gera_Pedido.Controls.Add(this.label7);
            this.pnl_Gera_Pedido.Controls.Add(this.CFG_Pedido);
            this.pnl_Gera_Pedido.Controls.Add(this.label8);
            this.pnl_Gera_Pedido.Controls.Add(this.NM_Empresa);
            this.pnl_Gera_Pedido.Controls.Add(this.BB_Empresa);
            this.pnl_Gera_Pedido.Controls.Add(this.label1);
            this.pnl_Gera_Pedido.Controls.Add(this.CD_Empresa);
            this.pnl_Gera_Pedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Gera_Pedido.Location = new System.Drawing.Point(4, 4);
            this.pnl_Gera_Pedido.Name = "pnl_Gera_Pedido";
            this.pnl_Gera_Pedido.NM_ProcDeletar = "";
            this.pnl_Gera_Pedido.NM_ProcGravar = "";
            this.pnl_Gera_Pedido.Size = new System.Drawing.Size(622, 245);
            this.pnl_Gera_Pedido.TabIndex = 0;
            // 
            // nomevendedor
            // 
            this.nomevendedor.BackColor = System.Drawing.SystemColors.Window;
            this.nomevendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomevendedor.Enabled = false;
            this.nomevendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomevendedor.Location = new System.Drawing.Point(195, 35);
            this.nomevendedor.Name = "nomevendedor";
            this.nomevendedor.NM_Alias = "";
            this.nomevendedor.NM_Campo = "";
            this.nomevendedor.NM_CampoBusca = "";
            this.nomevendedor.NM_Param = "";
            this.nomevendedor.QTD_Zero = 0;
            this.nomevendedor.ReadOnly = true;
            this.nomevendedor.Size = new System.Drawing.Size(418, 20);
            this.nomevendedor.ST_AutoInc = false;
            this.nomevendedor.ST_DisableAuto = false;
            this.nomevendedor.ST_Float = false;
            this.nomevendedor.ST_Gravar = false;
            this.nomevendedor.ST_Int = false;
            this.nomevendedor.ST_LimpaCampo = true;
            this.nomevendedor.ST_NotNull = false;
            this.nomevendedor.ST_PrimaryKey = false;
            this.nomevendedor.TabIndex = 109;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(36, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 108;
            this.label9.Text = "Vendedor:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_vendedor
            // 
            this.cd_vendedor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_vendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_vendedor.Enabled = false;
            this.cd_vendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_vendedor.Location = new System.Drawing.Point(104, 35);
            this.cd_vendedor.Name = "cd_vendedor";
            this.cd_vendedor.NM_Alias = "";
            this.cd_vendedor.NM_Campo = "";
            this.cd_vendedor.NM_CampoBusca = "";
            this.cd_vendedor.NM_Param = "";
            this.cd_vendedor.QTD_Zero = 0;
            this.cd_vendedor.ReadOnly = true;
            this.cd_vendedor.Size = new System.Drawing.Size(90, 20);
            this.cd_vendedor.ST_AutoInc = false;
            this.cd_vendedor.ST_DisableAuto = false;
            this.cd_vendedor.ST_Float = false;
            this.cd_vendedor.ST_Gravar = false;
            this.cd_vendedor.ST_Int = false;
            this.cd_vendedor.ST_LimpaCampo = true;
            this.cd_vendedor.ST_NotNull = false;
            this.cd_vendedor.ST_PrimaryKey = false;
            this.cd_vendedor.TabIndex = 107;
            // 
            // ds_endtransp
            // 
            this.ds_endtransp.BackColor = System.Drawing.SystemColors.Window;
            this.ds_endtransp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_endtransp.Enabled = false;
            this.ds_endtransp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ds_endtransp.Location = new System.Drawing.Point(198, 190);
            this.ds_endtransp.Name = "ds_endtransp";
            this.ds_endtransp.NM_Alias = "";
            this.ds_endtransp.NM_Campo = "ds_endereco";
            this.ds_endtransp.NM_CampoBusca = "ds_endereco";
            this.ds_endtransp.NM_Param = "@P_NM_CLIFOR";
            this.ds_endtransp.QTD_Zero = 0;
            this.ds_endtransp.ReadOnly = true;
            this.ds_endtransp.Size = new System.Drawing.Size(417, 20);
            this.ds_endtransp.ST_AutoInc = false;
            this.ds_endtransp.ST_DisableAuto = false;
            this.ds_endtransp.ST_Float = false;
            this.ds_endtransp.ST_Gravar = false;
            this.ds_endtransp.ST_Int = false;
            this.ds_endtransp.ST_LimpaCampo = true;
            this.ds_endtransp.ST_NotNull = false;
            this.ds_endtransp.ST_PrimaryKey = false;
            this.ds_endtransp.TabIndex = 106;
            // 
            // bb_endtransp
            // 
            this.bb_endtransp.Image = ((System.Drawing.Image)(resources.GetObject("bb_endtransp.Image")));
            this.bb_endtransp.Location = new System.Drawing.Point(167, 191);
            this.bb_endtransp.Name = "bb_endtransp";
            this.bb_endtransp.Size = new System.Drawing.Size(28, 19);
            this.bb_endtransp.TabIndex = 14;
            this.bb_endtransp.UseVisualStyleBackColor = true;
            this.bb_endtransp.Click += new System.EventHandler(this.bb_endtransp_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 105;
            this.label6.Text = "End. Transp.:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_endtransp
            // 
            this.cd_endtransp.BackColor = System.Drawing.SystemColors.Window;
            this.cd_endtransp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_endtransp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_endtransp.Location = new System.Drawing.Point(105, 191);
            this.cd_endtransp.Name = "cd_endtransp";
            this.cd_endtransp.NM_Alias = "";
            this.cd_endtransp.NM_Campo = "cd_endereco";
            this.cd_endtransp.NM_CampoBusca = "cd_endereco";
            this.cd_endtransp.NM_Param = "@P_CD_CLIFOR";
            this.cd_endtransp.QTD_Zero = 0;
            this.cd_endtransp.Size = new System.Drawing.Size(60, 20);
            this.cd_endtransp.ST_AutoInc = false;
            this.cd_endtransp.ST_DisableAuto = false;
            this.cd_endtransp.ST_Float = false;
            this.cd_endtransp.ST_Gravar = true;
            this.cd_endtransp.ST_Int = true;
            this.cd_endtransp.ST_LimpaCampo = true;
            this.cd_endtransp.ST_NotNull = true;
            this.cd_endtransp.ST_PrimaryKey = false;
            this.cd_endtransp.TabIndex = 13;
            this.cd_endtransp.Leave += new System.EventHandler(this.cd_endtransp_Leave);
            this.cd_endtransp.Enter += new System.EventHandler(this.cd_endtransp_Enter);
            // 
            // ds_transportadora
            // 
            this.ds_transportadora.BackColor = System.Drawing.SystemColors.Window;
            this.ds_transportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_transportadora.Enabled = false;
            this.ds_transportadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ds_transportadora.Location = new System.Drawing.Point(197, 164);
            this.ds_transportadora.Name = "ds_transportadora";
            this.ds_transportadora.NM_Alias = "";
            this.ds_transportadora.NM_Campo = "NM_Clifor";
            this.ds_transportadora.NM_CampoBusca = "NM_Clifor";
            this.ds_transportadora.NM_Param = "@P_NM_CLIFOR";
            this.ds_transportadora.QTD_Zero = 0;
            this.ds_transportadora.ReadOnly = true;
            this.ds_transportadora.Size = new System.Drawing.Size(417, 20);
            this.ds_transportadora.ST_AutoInc = false;
            this.ds_transportadora.ST_DisableAuto = false;
            this.ds_transportadora.ST_Float = false;
            this.ds_transportadora.ST_Gravar = false;
            this.ds_transportadora.ST_Int = false;
            this.ds_transportadora.ST_LimpaCampo = true;
            this.ds_transportadora.ST_NotNull = false;
            this.ds_transportadora.ST_PrimaryKey = false;
            this.ds_transportadora.TabIndex = 102;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(166, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 19);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 101;
            this.label4.Text = "Transportadora:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_transportadora
            // 
            this.cd_transportadora.BackColor = System.Drawing.SystemColors.Window;
            this.cd_transportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_transportadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_transportadora.Location = new System.Drawing.Point(104, 165);
            this.cd_transportadora.Name = "cd_transportadora";
            this.cd_transportadora.NM_Alias = "";
            this.cd_transportadora.NM_Campo = "CD_Clifor";
            this.cd_transportadora.NM_CampoBusca = "CD_Clifor";
            this.cd_transportadora.NM_Param = "@P_CD_CLIFOR";
            this.cd_transportadora.QTD_Zero = 0;
            this.cd_transportadora.Size = new System.Drawing.Size(60, 20);
            this.cd_transportadora.ST_AutoInc = false;
            this.cd_transportadora.ST_DisableAuto = false;
            this.cd_transportadora.ST_Float = false;
            this.cd_transportadora.ST_Gravar = true;
            this.cd_transportadora.ST_Int = true;
            this.cd_transportadora.ST_LimpaCampo = true;
            this.cd_transportadora.ST_NotNull = true;
            this.cd_transportadora.ST_PrimaryKey = false;
            this.cd_transportadora.TabIndex = 11;
            this.cd_transportadora.Leave += new System.EventHandler(this.cd_transportadora_Leave);
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.Enabled = false;
            this.NM_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NM_Clifor.Location = new System.Drawing.Point(196, 112);
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "NM_Clifor";
            this.NM_Clifor.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.ReadOnly = true;
            this.NM_Clifor.Size = new System.Drawing.Size(417, 20);
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = false;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TabIndex = 98;
            // 
            // BB_Clifor
            // 
            this.BB_Clifor.Enabled = false;
            this.BB_Clifor.Image = ((System.Drawing.Image)(resources.GetObject("BB_Clifor.Image")));
            this.BB_Clifor.Location = new System.Drawing.Point(165, 113);
            this.BB_Clifor.Name = "BB_Clifor";
            this.BB_Clifor.Size = new System.Drawing.Size(28, 19);
            this.BB_Clifor.TabIndex = 8;
            this.BB_Clifor.UseVisualStyleBackColor = true;
            this.BB_Clifor.Click += new System.EventHandler(this.BB_Clifor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 97;
            this.label2.Text = "Cliente:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.Enabled = false;
            this.CD_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_Clifor.Location = new System.Drawing.Point(103, 113);
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.Size = new System.Drawing.Size(60, 20);
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = true;
            this.CD_Clifor.ST_Int = true;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = true;
            this.CD_Clifor.ST_PrimaryKey = false;
            this.CD_Clifor.TabIndex = 7;
            this.CD_Clifor.Leave += new System.EventHandler(this.CD_Clifor_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 94;
            this.label5.Text = "Local Entrega:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_LocalEntrega
            // 
            this.DS_LocalEntrega.BackColor = System.Drawing.SystemColors.Window;
            this.DS_LocalEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_LocalEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_LocalEntrega.Location = new System.Drawing.Point(104, 217);
            this.DS_LocalEntrega.Name = "DS_LocalEntrega";
            this.DS_LocalEntrega.NM_Alias = "";
            this.DS_LocalEntrega.NM_Campo = "";
            this.DS_LocalEntrega.NM_CampoBusca = "";
            this.DS_LocalEntrega.NM_Param = "";
            this.DS_LocalEntrega.QTD_Zero = 0;
            this.DS_LocalEntrega.Size = new System.Drawing.Size(509, 20);
            this.DS_LocalEntrega.ST_AutoInc = false;
            this.DS_LocalEntrega.ST_DisableAuto = false;
            this.DS_LocalEntrega.ST_Float = false;
            this.DS_LocalEntrega.ST_Gravar = true;
            this.DS_LocalEntrega.ST_Int = false;
            this.DS_LocalEntrega.ST_LimpaCampo = true;
            this.DS_LocalEntrega.ST_NotNull = false;
            this.DS_LocalEntrega.ST_PrimaryKey = false;
            this.DS_LocalEntrega.TabIndex = 15;
            // 
            // DS_Endereco
            // 
            this.DS_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Endereco.Enabled = false;
            this.DS_Endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_Endereco.Location = new System.Drawing.Point(196, 139);
            this.DS_Endereco.Name = "DS_Endereco";
            this.DS_Endereco.NM_Alias = "";
            this.DS_Endereco.NM_Campo = "DS_Endereco";
            this.DS_Endereco.NM_CampoBusca = "DS_Endereco";
            this.DS_Endereco.NM_Param = "@P_DS_ENDERECO";
            this.DS_Endereco.QTD_Zero = 0;
            this.DS_Endereco.ReadOnly = true;
            this.DS_Endereco.Size = new System.Drawing.Size(417, 20);
            this.DS_Endereco.ST_AutoInc = false;
            this.DS_Endereco.ST_DisableAuto = false;
            this.DS_Endereco.ST_Float = false;
            this.DS_Endereco.ST_Gravar = false;
            this.DS_Endereco.ST_Int = false;
            this.DS_Endereco.ST_LimpaCampo = true;
            this.DS_Endereco.ST_NotNull = false;
            this.DS_Endereco.ST_PrimaryKey = false;
            this.DS_Endereco.TabIndex = 91;
            // 
            // BB_Endereco
            // 
            this.BB_Endereco.Image = ((System.Drawing.Image)(resources.GetObject("BB_Endereco.Image")));
            this.BB_Endereco.Location = new System.Drawing.Point(166, 139);
            this.BB_Endereco.Name = "BB_Endereco";
            this.BB_Endereco.Size = new System.Drawing.Size(28, 19);
            this.BB_Endereco.TabIndex = 10;
            this.BB_Endereco.UseVisualStyleBackColor = true;
            this.BB_Endereco.Click += new System.EventHandler(this.BB_Endereco_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "Endereço:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Endereco
            // 
            this.CD_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_Endereco.Location = new System.Drawing.Point(104, 139);
            this.CD_Endereco.Name = "CD_Endereco";
            this.CD_Endereco.NM_Alias = "";
            this.CD_Endereco.NM_Campo = "CD_Endereco";
            this.CD_Endereco.NM_CampoBusca = "CD_Endereco";
            this.CD_Endereco.NM_Param = "@P_CD_ENDERECO";
            this.CD_Endereco.QTD_Zero = 0;
            this.CD_Endereco.Size = new System.Drawing.Size(60, 20);
            this.CD_Endereco.ST_AutoInc = false;
            this.CD_Endereco.ST_DisableAuto = false;
            this.CD_Endereco.ST_Float = false;
            this.CD_Endereco.ST_Gravar = true;
            this.CD_Endereco.ST_Int = true;
            this.CD_Endereco.ST_LimpaCampo = true;
            this.CD_Endereco.ST_NotNull = true;
            this.CD_Endereco.ST_PrimaryKey = false;
            this.CD_Endereco.TabIndex = 9;
            this.CD_Endereco.Leave += new System.EventHandler(this.CD_Endereco_Leave);
            this.CD_Endereco.Enter += new System.EventHandler(this.CD_Endereco_Enter);
            // 
            // Sigla_Moeda
            // 
            this.Sigla_Moeda.BackColor = System.Drawing.SystemColors.Window;
            this.Sigla_Moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Sigla_Moeda.Enabled = false;
            this.Sigla_Moeda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sigla_Moeda.Location = new System.Drawing.Point(562, 87);
            this.Sigla_Moeda.Name = "Sigla_Moeda";
            this.Sigla_Moeda.NM_Alias = "";
            this.Sigla_Moeda.NM_Campo = "Sigla";
            this.Sigla_Moeda.NM_CampoBusca = "Sigla";
            this.Sigla_Moeda.NM_Param = "@P_DS_MOEDA_SINGULAR";
            this.Sigla_Moeda.QTD_Zero = 0;
            this.Sigla_Moeda.ReadOnly = true;
            this.Sigla_Moeda.Size = new System.Drawing.Size(51, 20);
            this.Sigla_Moeda.ST_AutoInc = false;
            this.Sigla_Moeda.ST_DisableAuto = false;
            this.Sigla_Moeda.ST_Float = false;
            this.Sigla_Moeda.ST_Gravar = false;
            this.Sigla_Moeda.ST_Int = false;
            this.Sigla_Moeda.ST_LimpaCampo = true;
            this.Sigla_Moeda.ST_NotNull = false;
            this.Sigla_Moeda.ST_PrimaryKey = false;
            this.Sigla_Moeda.TabIndex = 86;
            // 
            // DS_Moeda
            // 
            this.DS_Moeda.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Moeda.Enabled = false;
            this.DS_Moeda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_Moeda.Location = new System.Drawing.Point(196, 86);
            this.DS_Moeda.Name = "DS_Moeda";
            this.DS_Moeda.NM_Alias = "";
            this.DS_Moeda.NM_Campo = "DS_Moeda_Singular";
            this.DS_Moeda.NM_CampoBusca = "DS_Moeda_Singular";
            this.DS_Moeda.NM_Param = "@P_DS_MOEDA_SINGULAR";
            this.DS_Moeda.QTD_Zero = 0;
            this.DS_Moeda.ReadOnly = true;
            this.DS_Moeda.Size = new System.Drawing.Size(360, 20);
            this.DS_Moeda.ST_AutoInc = false;
            this.DS_Moeda.ST_DisableAuto = false;
            this.DS_Moeda.ST_Float = false;
            this.DS_Moeda.ST_Gravar = false;
            this.DS_Moeda.ST_Int = false;
            this.DS_Moeda.ST_LimpaCampo = true;
            this.DS_Moeda.ST_NotNull = false;
            this.DS_Moeda.ST_PrimaryKey = false;
            this.DS_Moeda.TabIndex = 81;
            // 
            // BB_Moeda
            // 
            this.BB_Moeda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Moeda.Image = ((System.Drawing.Image)(resources.GetObject("BB_Moeda.Image")));
            this.BB_Moeda.Location = new System.Drawing.Point(166, 86);
            this.BB_Moeda.Name = "BB_Moeda";
            this.BB_Moeda.Size = new System.Drawing.Size(28, 19);
            this.BB_Moeda.TabIndex = 6;
            this.BB_Moeda.UseVisualStyleBackColor = true;
            this.BB_Moeda.Click += new System.EventHandler(this.BB_Moeda_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(52, 90);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 13);
            this.label30.TabIndex = 78;
            this.label30.Text = "Moeda:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Moeda
            // 
            this.CD_Moeda.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Moeda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_Moeda.Location = new System.Drawing.Point(104, 87);
            this.CD_Moeda.Name = "CD_Moeda";
            this.CD_Moeda.NM_Alias = "";
            this.CD_Moeda.NM_Campo = "CD_Moeda";
            this.CD_Moeda.NM_CampoBusca = "CD_Moeda";
            this.CD_Moeda.NM_Param = "@P_CD_MOEDA";
            this.CD_Moeda.QTD_Zero = 0;
            this.CD_Moeda.Size = new System.Drawing.Size(60, 20);
            this.CD_Moeda.ST_AutoInc = false;
            this.CD_Moeda.ST_DisableAuto = false;
            this.CD_Moeda.ST_Float = false;
            this.CD_Moeda.ST_Gravar = true;
            this.CD_Moeda.ST_Int = true;
            this.CD_Moeda.ST_LimpaCampo = true;
            this.CD_Moeda.ST_NotNull = true;
            this.CD_Moeda.ST_PrimaryKey = false;
            this.CD_Moeda.TabIndex = 5;
            this.CD_Moeda.Leave += new System.EventHandler(this.CD_Moeda_Leave);
            // 
            // DT_Pedido
            // 
            this.DT_Pedido.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.DT_Pedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_Pedido.Location = new System.Drawing.Point(525, 8);
            this.DT_Pedido.Mask = "00/00/0000";
            this.DT_Pedido.Name = "DT_Pedido";
            this.DT_Pedido.NM_Alias = "";
            this.DT_Pedido.NM_Campo = "";
            this.DT_Pedido.NM_CampoBusca = "";
            this.DT_Pedido.NM_Param = "";
            this.DT_Pedido.Operador = "";
            this.DT_Pedido.Size = new System.Drawing.Size(88, 23);
            this.DT_Pedido.ST_Gravar = false;
            this.DT_Pedido.ST_LimpaCampo = true;
            this.DT_Pedido.ST_NotNull = true;
            this.DT_Pedido.ST_PrimaryKey = false;
            this.DT_Pedido.TabIndex = 2;
            // 
            // TP_Mov
            // 
            this.TP_Mov.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Mov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Mov.Enabled = false;
            this.TP_Mov.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TP_Mov.Location = new System.Drawing.Point(562, 62);
            this.TP_Mov.Name = "TP_Mov";
            this.TP_Mov.NM_Alias = "";
            this.TP_Mov.NM_Campo = "TP_Movimento";
            this.TP_Mov.NM_CampoBusca = "TP_Movimento";
            this.TP_Mov.NM_Param = "";
            this.TP_Mov.QTD_Zero = 0;
            this.TP_Mov.ReadOnly = true;
            this.TP_Mov.Size = new System.Drawing.Size(51, 20);
            this.TP_Mov.ST_AutoInc = false;
            this.TP_Mov.ST_DisableAuto = false;
            this.TP_Mov.ST_Float = false;
            this.TP_Mov.ST_Gravar = false;
            this.TP_Mov.ST_Int = false;
            this.TP_Mov.ST_LimpaCampo = true;
            this.TP_Mov.ST_NotNull = false;
            this.TP_Mov.ST_PrimaryKey = false;
            this.TP_Mov.TabIndex = 62;
            // 
            // DS_CFGPedido
            // 
            this.DS_CFGPedido.BackColor = System.Drawing.SystemColors.Window;
            this.DS_CFGPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_CFGPedido.Enabled = false;
            this.DS_CFGPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_CFGPedido.Location = new System.Drawing.Point(196, 61);
            this.DS_CFGPedido.Name = "DS_CFGPedido";
            this.DS_CFGPedido.NM_Alias = "";
            this.DS_CFGPedido.NM_Campo = "DS_TipoPedido";
            this.DS_CFGPedido.NM_CampoBusca = "DS_TipoPedido";
            this.DS_CFGPedido.NM_Param = "@P_DS_TIPOPEDIDO";
            this.DS_CFGPedido.QTD_Zero = 0;
            this.DS_CFGPedido.ReadOnly = true;
            this.DS_CFGPedido.Size = new System.Drawing.Size(360, 20);
            this.DS_CFGPedido.ST_AutoInc = false;
            this.DS_CFGPedido.ST_DisableAuto = false;
            this.DS_CFGPedido.ST_Float = false;
            this.DS_CFGPedido.ST_Gravar = false;
            this.DS_CFGPedido.ST_Int = false;
            this.DS_CFGPedido.ST_LimpaCampo = true;
            this.DS_CFGPedido.ST_NotNull = false;
            this.DS_CFGPedido.ST_PrimaryKey = false;
            this.DS_CFGPedido.TabIndex = 60;
            // 
            // BB_CFGPedido
            // 
            this.BB_CFGPedido.Image = ((System.Drawing.Image)(resources.GetObject("BB_CFGPedido.Image")));
            this.BB_CFGPedido.Location = new System.Drawing.Point(166, 61);
            this.BB_CFGPedido.Name = "BB_CFGPedido";
            this.BB_CFGPedido.Size = new System.Drawing.Size(28, 19);
            this.BB_CFGPedido.TabIndex = 4;
            this.BB_CFGPedido.UseVisualStyleBackColor = true;
            this.BB_CFGPedido.Click += new System.EventHandler(this.BB_CFGPedido_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Tipo de Pedido:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CFG_Pedido
            // 
            this.CFG_Pedido.BackColor = System.Drawing.SystemColors.Window;
            this.CFG_Pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CFG_Pedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CFG_Pedido.Location = new System.Drawing.Point(104, 60);
            this.CFG_Pedido.Name = "CFG_Pedido";
            this.CFG_Pedido.NM_Alias = "";
            this.CFG_Pedido.NM_Campo = "CFG_Pedido";
            this.CFG_Pedido.NM_CampoBusca = "CFG_Pedido";
            this.CFG_Pedido.NM_Param = "@P_CFG_PEDIDO";
            this.CFG_Pedido.QTD_Zero = 0;
            this.CFG_Pedido.Size = new System.Drawing.Size(60, 20);
            this.CFG_Pedido.ST_AutoInc = false;
            this.CFG_Pedido.ST_DisableAuto = false;
            this.CFG_Pedido.ST_Float = false;
            this.CFG_Pedido.ST_Gravar = true;
            this.CFG_Pedido.ST_Int = true;
            this.CFG_Pedido.ST_LimpaCampo = true;
            this.CFG_Pedido.ST_NotNull = true;
            this.CFG_Pedido.ST_PrimaryKey = false;
            this.CFG_Pedido.TabIndex = 3;
            this.CFG_Pedido.Leave += new System.EventHandler(this.CFG_Pedido_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(443, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Data Pedido:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NM_Empresa.Location = new System.Drawing.Point(196, 9);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(242, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 58;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.Location = new System.Drawing.Point(166, 9);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 1;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_Empresa.Location = new System.Drawing.Point(104, 9);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(60, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // TFLan_GeraPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 298);
            this.Controls.Add(this.pnl_Base);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLan_GeraPedido";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Pedido";
            this.Load += new System.EventHandler(this.TFLan_GeraPedido_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLan_GeraPedido_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pnl_Base.ResumeLayout(false);
            this.pnl_Gera_Pedido.ResumeLayout(false);
            this.pnl_Gera_Pedido.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.PanelDados pnl_Base;
        private Componentes.PanelDados pnl_Gera_Pedido;
        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.EditDefault DS_CFGPedido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault Sigla_Moeda;
        private Componentes.EditDefault DS_Moeda;
        private System.Windows.Forms.Label label30;
        public Componentes.EditData DT_Pedido;
        public Componentes.EditDefault TP_Mov;
        public Componentes.EditDefault CFG_Pedido;
        public Componentes.EditDefault CD_Empresa;
        public Componentes.EditDefault CD_Moeda;
        private System.Windows.Forms.Label label2;
        public Componentes.EditDefault NM_Clifor;
        public Componentes.EditDefault CD_Clifor;
        public System.Windows.Forms.Label label5;
        public Componentes.EditDefault DS_LocalEntrega;
        public Componentes.EditDefault DS_Endereco;
        public System.Windows.Forms.Button BB_Endereco;
        public System.Windows.Forms.Label label3;
        public Componentes.EditDefault CD_Endereco;
        public Componentes.EditDefault ds_transportadora;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        public Componentes.EditDefault cd_transportadora;
        public System.Windows.Forms.Button BB_Clifor;
        private System.Windows.Forms.Button BB_Moeda;
        private System.Windows.Forms.Button BB_CFGPedido;
        public Componentes.EditDefault ds_endtransp;
        public System.Windows.Forms.Button bb_endtransp;
        private System.Windows.Forms.Label label6;
        public Componentes.EditDefault cd_endtransp;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault nomevendedor;
        public Componentes.EditDefault cd_vendedor;
    }
}