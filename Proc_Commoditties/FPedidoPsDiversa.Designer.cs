namespace Proc_Commoditties
{
    partial class TFPedidoPsDiversa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFPedidoPsDiversa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bbProduto = new System.Windows.Forms.Button();
            this.bbCliente = new System.Windows.Forms.Button();
            this.Sub_Total = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.Vl_Unitario = new Componentes.EditFloat(this.components);
            this.label59 = new System.Windows.Forms.Label();
            this.SG_UniQTD = new Componentes.EditDefault(this.components);
            this.SG_Unidade_Estoque = new Componentes.EditDefault(this.components);
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.DS_Local = new Componentes.EditDefault(this.components);
            this.BB_Local = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CD_Local = new Componentes.EditDefault(this.components);
            this.DS_Unidade = new Componentes.EditDefault(this.components);
            this.BB_Unidade = new System.Windows.Forms.Button();
            this.label57 = new System.Windows.Forms.Label();
            this.CD_Unidade = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.TP_Mov = new Componentes.EditDefault(this.components);
            this.DS_CFGPedido = new Componentes.EditDefault(this.components);
            this.BB_CFGPedido = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.CFG_Pedido = new Componentes.EditDefault(this.components);
            this.BB_Endereco = new System.Windows.Forms.Button();
            this.DS_Endereco = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.CD_Endereco = new Componentes.EditDefault(this.components);
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.lblClifor = new System.Windows.Forms.Label();
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(734, 43);
            this.barraMenu.TabIndex = 14;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.bbProduto);
            this.pDados.Controls.Add(this.bbCliente);
            this.pDados.Controls.Add(this.Sub_Total);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.Vl_Unitario);
            this.pDados.Controls.Add(this.label59);
            this.pDados.Controls.Add(this.SG_UniQTD);
            this.pDados.Controls.Add(this.SG_Unidade_Estoque);
            this.pDados.Controls.Add(this.Quantidade);
            this.pDados.Controls.Add(this.label58);
            this.pDados.Controls.Add(this.DS_Local);
            this.pDados.Controls.Add(this.BB_Local);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.CD_Local);
            this.pDados.Controls.Add(this.DS_Unidade);
            this.pDados.Controls.Add(this.BB_Unidade);
            this.pDados.Controls.Add(this.label57);
            this.pDados.Controls.Add(this.CD_Unidade);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.TP_Mov);
            this.pDados.Controls.Add(this.DS_CFGPedido);
            this.pDados.Controls.Add(this.BB_CFGPedido);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.CFG_Pedido);
            this.pDados.Controls.Add(this.BB_Endereco);
            this.pDados.Controls.Add(this.DS_Endereco);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.CD_Endereco);
            this.pDados.Controls.Add(this.NM_Clifor);
            this.pDados.Controls.Add(this.lblClifor);
            this.pDados.Controls.Add(this.CD_Clifor);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(734, 212);
            this.pDados.TabIndex = 15;
            // 
            // bbProduto
            // 
            this.bbProduto.Image = ((System.Drawing.Image)(resources.GetObject("bbProduto.Image")));
            this.bbProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbProduto.Location = new System.Drawing.Point(170, 107);
            this.bbProduto.Name = "bbProduto";
            this.bbProduto.Size = new System.Drawing.Size(28, 19);
            this.bbProduto.TabIndex = 171;
            this.bbProduto.UseVisualStyleBackColor = true;
            this.bbProduto.Click += new System.EventHandler(this.bbProduto_Click);
            // 
            // bbCliente
            // 
            this.bbCliente.Image = ((System.Drawing.Image)(resources.GetObject("bbCliente.Image")));
            this.bbCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbCliente.Location = new System.Drawing.Point(170, 56);
            this.bbCliente.Name = "bbCliente";
            this.bbCliente.Size = new System.Drawing.Size(28, 19);
            this.bbCliente.TabIndex = 170;
            this.bbCliente.UseVisualStyleBackColor = true;
            this.bbCliente.Click += new System.EventHandler(this.bbCliente_Click);
            // 
            // Sub_Total
            // 
            this.Sub_Total.DecimalPlaces = 2;
            this.Sub_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Sub_Total.Location = new System.Drawing.Point(499, 185);
            this.Sub_Total.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Sub_Total.Name = "Sub_Total";
            this.Sub_Total.NM_Alias = "";
            this.Sub_Total.NM_Campo = "Vl_Unitario";
            this.Sub_Total.NM_Param = "@P_VL_UNITARIO";
            this.Sub_Total.Operador = "";
            this.Sub_Total.Size = new System.Drawing.Size(109, 20);
            this.Sub_Total.ST_AutoInc = false;
            this.Sub_Total.ST_DisableAuto = false;
            this.Sub_Total.ST_Gravar = true;
            this.Sub_Total.ST_LimparCampo = true;
            this.Sub_Total.ST_NotNull = false;
            this.Sub_Total.ST_PrimaryKey = false;
            this.Sub_Total.TabIndex = 10;
            this.Sub_Total.ThousandsSeparator = true;
            this.Sub_Total.Leave += new System.EventHandler(this.Sub_Total_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(442, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 169;
            this.label4.Text = "Vl. Total:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Vl_Unitario
            // 
            this.Vl_Unitario.DecimalPlaces = 5;
            this.Vl_Unitario.Location = new System.Drawing.Point(307, 185);
            this.Vl_Unitario.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Vl_Unitario.Name = "Vl_Unitario";
            this.Vl_Unitario.NM_Alias = "";
            this.Vl_Unitario.NM_Campo = "Vl_Unitario";
            this.Vl_Unitario.NM_Param = "@P_VL_UNITARIO";
            this.Vl_Unitario.Operador = "";
            this.Vl_Unitario.Size = new System.Drawing.Size(91, 20);
            this.Vl_Unitario.ST_AutoInc = false;
            this.Vl_Unitario.ST_DisableAuto = false;
            this.Vl_Unitario.ST_Gravar = true;
            this.Vl_Unitario.ST_LimparCampo = true;
            this.Vl_Unitario.ST_NotNull = true;
            this.Vl_Unitario.ST_PrimaryKey = false;
            this.Vl_Unitario.TabIndex = 9;
            this.Vl_Unitario.ThousandsSeparator = true;
            this.Vl_Unitario.Leave += new System.EventHandler(this.Vl_Unitario_Leave);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label59.Location = new System.Drawing.Point(228, 188);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(73, 13);
            this.label59.TabIndex = 167;
            this.label59.Text = "Valor Unitário:";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SG_UniQTD
            // 
            this.SG_UniQTD.BackColor = System.Drawing.SystemColors.Window;
            this.SG_UniQTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SG_UniQTD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SG_UniQTD.Enabled = false;
            this.SG_UniQTD.Location = new System.Drawing.Point(398, 185);
            this.SG_UniQTD.Name = "SG_UniQTD";
            this.SG_UniQTD.NM_Alias = "";
            this.SG_UniQTD.NM_Campo = "Sigla_Unidade";
            this.SG_UniQTD.NM_CampoBusca = "Sigla_Unidade";
            this.SG_UniQTD.NM_Param = "@P_SIGLA_UNIDADE";
            this.SG_UniQTD.QTD_Zero = 0;
            this.SG_UniQTD.ReadOnly = true;
            this.SG_UniQTD.Size = new System.Drawing.Size(38, 20);
            this.SG_UniQTD.ST_AutoInc = false;
            this.SG_UniQTD.ST_DisableAuto = false;
            this.SG_UniQTD.ST_Float = false;
            this.SG_UniQTD.ST_Gravar = false;
            this.SG_UniQTD.ST_Int = false;
            this.SG_UniQTD.ST_LimpaCampo = true;
            this.SG_UniQTD.ST_NotNull = false;
            this.SG_UniQTD.ST_PrimaryKey = false;
            this.SG_UniQTD.TabIndex = 166;
            this.SG_UniQTD.TextOld = null;
            // 
            // SG_Unidade_Estoque
            // 
            this.SG_Unidade_Estoque.BackColor = System.Drawing.SystemColors.Window;
            this.SG_Unidade_Estoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SG_Unidade_Estoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SG_Unidade_Estoque.Enabled = false;
            this.SG_Unidade_Estoque.Location = new System.Drawing.Point(184, 185);
            this.SG_Unidade_Estoque.Name = "SG_Unidade_Estoque";
            this.SG_Unidade_Estoque.NM_Alias = "";
            this.SG_Unidade_Estoque.NM_Campo = "Sigla_Unidade";
            this.SG_Unidade_Estoque.NM_CampoBusca = "Sigla_Unidade";
            this.SG_Unidade_Estoque.NM_Param = "@P_SIGLA_UNIDADE";
            this.SG_Unidade_Estoque.QTD_Zero = 0;
            this.SG_Unidade_Estoque.ReadOnly = true;
            this.SG_Unidade_Estoque.Size = new System.Drawing.Size(38, 20);
            this.SG_Unidade_Estoque.ST_AutoInc = false;
            this.SG_Unidade_Estoque.ST_DisableAuto = false;
            this.SG_Unidade_Estoque.ST_Float = false;
            this.SG_Unidade_Estoque.ST_Gravar = false;
            this.SG_Unidade_Estoque.ST_Int = false;
            this.SG_Unidade_Estoque.ST_LimpaCampo = true;
            this.SG_Unidade_Estoque.ST_NotNull = false;
            this.SG_Unidade_Estoque.ST_PrimaryKey = false;
            this.SG_Unidade_Estoque.TabIndex = 163;
            this.SG_Unidade_Estoque.TextOld = null;
            // 
            // Quantidade
            // 
            this.Quantidade.DecimalPlaces = 3;
            this.Quantidade.Location = new System.Drawing.Point(93, 185);
            this.Quantidade.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.NM_Alias = "";
            this.Quantidade.NM_Campo = "Quantidade";
            this.Quantidade.NM_Param = "@P_QUANTIDADE";
            this.Quantidade.Operador = "";
            this.Quantidade.Size = new System.Drawing.Size(91, 20);
            this.Quantidade.ST_AutoInc = false;
            this.Quantidade.ST_DisableAuto = false;
            this.Quantidade.ST_Gravar = true;
            this.Quantidade.ST_LimparCampo = true;
            this.Quantidade.ST_NotNull = true;
            this.Quantidade.ST_PrimaryKey = false;
            this.Quantidade.TabIndex = 8;
            this.Quantidade.ThousandsSeparator = true;
            this.Quantidade.Leave += new System.EventHandler(this.Quantidade_Leave);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label58.Location = new System.Drawing.Point(22, 187);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(65, 13);
            this.label58.TabIndex = 164;
            this.label58.Text = "Quantidade:";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_Local
            // 
            this.DS_Local.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Local.Enabled = false;
            this.DS_Local.Location = new System.Drawing.Point(195, 159);
            this.DS_Local.Name = "DS_Local";
            this.DS_Local.NM_Alias = "";
            this.DS_Local.NM_Campo = "DS_Local";
            this.DS_Local.NM_CampoBusca = "DS_Local";
            this.DS_Local.NM_Param = "@P_DS_UNIDADE";
            this.DS_Local.QTD_Zero = 0;
            this.DS_Local.ReadOnly = true;
            this.DS_Local.Size = new System.Drawing.Size(534, 20);
            this.DS_Local.ST_AutoInc = false;
            this.DS_Local.ST_DisableAuto = false;
            this.DS_Local.ST_Float = false;
            this.DS_Local.ST_Gravar = false;
            this.DS_Local.ST_Int = false;
            this.DS_Local.ST_LimpaCampo = true;
            this.DS_Local.ST_NotNull = false;
            this.DS_Local.ST_PrimaryKey = false;
            this.DS_Local.TabIndex = 160;
            this.DS_Local.TextOld = null;
            // 
            // BB_Local
            // 
            this.BB_Local.Image = ((System.Drawing.Image)(resources.GetObject("BB_Local.Image")));
            this.BB_Local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Local.Location = new System.Drawing.Point(161, 159);
            this.BB_Local.Name = "BB_Local";
            this.BB_Local.Size = new System.Drawing.Size(28, 19);
            this.BB_Local.TabIndex = 7;
            this.BB_Local.UseVisualStyleBackColor = true;
            this.BB_Local.Click += new System.EventHandler(this.BB_Local_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(48, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 161;
            this.label2.Text = "Local:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Local
            // 
            this.CD_Local.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local.Location = new System.Drawing.Point(93, 159);
            this.CD_Local.Name = "CD_Local";
            this.CD_Local.NM_Alias = "";
            this.CD_Local.NM_Campo = "CD_Local";
            this.CD_Local.NM_CampoBusca = "CD_Local";
            this.CD_Local.NM_Param = "@P_CD_UNIDADE";
            this.CD_Local.QTD_Zero = 0;
            this.CD_Local.Size = new System.Drawing.Size(65, 20);
            this.CD_Local.ST_AutoInc = false;
            this.CD_Local.ST_DisableAuto = false;
            this.CD_Local.ST_Float = false;
            this.CD_Local.ST_Gravar = true;
            this.CD_Local.ST_Int = false;
            this.CD_Local.ST_LimpaCampo = true;
            this.CD_Local.ST_NotNull = false;
            this.CD_Local.ST_PrimaryKey = false;
            this.CD_Local.TabIndex = 6;
            this.CD_Local.TextOld = null;
            this.CD_Local.Leave += new System.EventHandler(this.CD_Local_Leave);
            // 
            // DS_Unidade
            // 
            this.DS_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Unidade.Enabled = false;
            this.DS_Unidade.Location = new System.Drawing.Point(163, 133);
            this.DS_Unidade.Name = "DS_Unidade";
            this.DS_Unidade.NM_Alias = "";
            this.DS_Unidade.NM_Campo = "DS_Unidade";
            this.DS_Unidade.NM_CampoBusca = "DS_Unidade";
            this.DS_Unidade.NM_Param = "@P_DS_UNIDADE";
            this.DS_Unidade.QTD_Zero = 0;
            this.DS_Unidade.ReadOnly = true;
            this.DS_Unidade.Size = new System.Drawing.Size(566, 20);
            this.DS_Unidade.ST_AutoInc = false;
            this.DS_Unidade.ST_DisableAuto = false;
            this.DS_Unidade.ST_Float = false;
            this.DS_Unidade.ST_Gravar = false;
            this.DS_Unidade.ST_Int = false;
            this.DS_Unidade.ST_LimpaCampo = true;
            this.DS_Unidade.ST_NotNull = false;
            this.DS_Unidade.ST_PrimaryKey = false;
            this.DS_Unidade.TabIndex = 158;
            this.DS_Unidade.TextOld = null;
            // 
            // BB_Unidade
            // 
            this.BB_Unidade.Image = ((System.Drawing.Image)(resources.GetObject("BB_Unidade.Image")));
            this.BB_Unidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Unidade.Location = new System.Drawing.Point(131, 133);
            this.BB_Unidade.Name = "BB_Unidade";
            this.BB_Unidade.Size = new System.Drawing.Size(28, 19);
            this.BB_Unidade.TabIndex = 5;
            this.BB_Unidade.UseVisualStyleBackColor = true;
            this.BB_Unidade.Click += new System.EventHandler(this.BB_Unidade_Click);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label57.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label57.Location = new System.Drawing.Point(17, 135);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(70, 13);
            this.label57.TabIndex = 159;
            this.label57.Text = "Unidade Fin.:";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Unidade
            // 
            this.CD_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Unidade.Location = new System.Drawing.Point(93, 133);
            this.CD_Unidade.Name = "CD_Unidade";
            this.CD_Unidade.NM_Alias = "";
            this.CD_Unidade.NM_Campo = "CD_Unidade";
            this.CD_Unidade.NM_CampoBusca = "CD_Unidade";
            this.CD_Unidade.NM_Param = "@P_CD_UNIDADE";
            this.CD_Unidade.QTD_Zero = 0;
            this.CD_Unidade.Size = new System.Drawing.Size(37, 20);
            this.CD_Unidade.ST_AutoInc = false;
            this.CD_Unidade.ST_DisableAuto = false;
            this.CD_Unidade.ST_Float = false;
            this.CD_Unidade.ST_Gravar = true;
            this.CD_Unidade.ST_Int = false;
            this.CD_Unidade.ST_LimpaCampo = true;
            this.CD_Unidade.ST_NotNull = true;
            this.CD_Unidade.ST_PrimaryKey = false;
            this.CD_Unidade.TabIndex = 4;
            this.CD_Unidade.TextOld = null;
            this.CD_Unidade.Leave += new System.EventHandler(this.CD_Unidade_Leave);
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.Enabled = false;
            this.ds_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_produto.Location = new System.Drawing.Point(201, 107);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_ENDERECO";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(528, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = true;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 152;
            this.ds_produto.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(40, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 153;
            this.label1.Text = "Produto:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(93, 107);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_ENDERECO";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(75, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 151;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // TP_Mov
            // 
            this.TP_Mov.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Mov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Mov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Mov.Enabled = false;
            this.TP_Mov.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TP_Mov.Location = new System.Drawing.Point(698, 30);
            this.TP_Mov.Name = "TP_Mov";
            this.TP_Mov.NM_Alias = "";
            this.TP_Mov.NM_Campo = "TP_Movimento";
            this.TP_Mov.NM_CampoBusca = "TP_Movimento";
            this.TP_Mov.NM_Param = "@P_TP_MOVIMENTO";
            this.TP_Mov.QTD_Zero = 0;
            this.TP_Mov.ReadOnly = true;
            this.TP_Mov.Size = new System.Drawing.Size(31, 20);
            this.TP_Mov.ST_AutoInc = false;
            this.TP_Mov.ST_DisableAuto = false;
            this.TP_Mov.ST_Float = false;
            this.TP_Mov.ST_Gravar = false;
            this.TP_Mov.ST_Int = false;
            this.TP_Mov.ST_LimpaCampo = true;
            this.TP_Mov.ST_NotNull = false;
            this.TP_Mov.ST_PrimaryKey = false;
            this.TP_Mov.TabIndex = 150;
            this.TP_Mov.TextOld = null;
            // 
            // DS_CFGPedido
            // 
            this.DS_CFGPedido.BackColor = System.Drawing.SystemColors.Window;
            this.DS_CFGPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_CFGPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_CFGPedido.Enabled = false;
            this.DS_CFGPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_CFGPedido.Location = new System.Drawing.Point(201, 30);
            this.DS_CFGPedido.Name = "DS_CFGPedido";
            this.DS_CFGPedido.NM_Alias = "";
            this.DS_CFGPedido.NM_Campo = "DS_TipoPedido";
            this.DS_CFGPedido.NM_CampoBusca = "DS_TipoPedido";
            this.DS_CFGPedido.NM_Param = "@P_DS_TIPOPEDIDO";
            this.DS_CFGPedido.QTD_Zero = 0;
            this.DS_CFGPedido.ReadOnly = true;
            this.DS_CFGPedido.Size = new System.Drawing.Size(491, 20);
            this.DS_CFGPedido.ST_AutoInc = false;
            this.DS_CFGPedido.ST_DisableAuto = false;
            this.DS_CFGPedido.ST_Float = false;
            this.DS_CFGPedido.ST_Gravar = false;
            this.DS_CFGPedido.ST_Int = false;
            this.DS_CFGPedido.ST_LimpaCampo = true;
            this.DS_CFGPedido.ST_NotNull = false;
            this.DS_CFGPedido.ST_PrimaryKey = false;
            this.DS_CFGPedido.TabIndex = 148;
            this.DS_CFGPedido.TextOld = null;
            // 
            // BB_CFGPedido
            // 
            this.BB_CFGPedido.Image = ((System.Drawing.Image)(resources.GetObject("BB_CFGPedido.Image")));
            this.BB_CFGPedido.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_CFGPedido.Location = new System.Drawing.Point(170, 30);
            this.BB_CFGPedido.Name = "BB_CFGPedido";
            this.BB_CFGPedido.Size = new System.Drawing.Size(28, 19);
            this.BB_CFGPedido.TabIndex = 1;
            this.BB_CFGPedido.UseVisualStyleBackColor = true;
            this.BB_CFGPedido.Click += new System.EventHandler(this.BB_CFGPedido_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(5, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 149;
            this.label7.Text = "Tipo de Pedido:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CFG_Pedido
            // 
            this.CFG_Pedido.BackColor = System.Drawing.SystemColors.Window;
            this.CFG_Pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CFG_Pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CFG_Pedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CFG_Pedido.Location = new System.Drawing.Point(93, 29);
            this.CFG_Pedido.Name = "CFG_Pedido";
            this.CFG_Pedido.NM_Alias = "";
            this.CFG_Pedido.NM_Campo = "CFG_Pedido";
            this.CFG_Pedido.NM_CampoBusca = "CFG_Pedido";
            this.CFG_Pedido.NM_Param = "@P_CFG_PEDIDO";
            this.CFG_Pedido.QTD_Zero = 0;
            this.CFG_Pedido.Size = new System.Drawing.Size(75, 20);
            this.CFG_Pedido.ST_AutoInc = false;
            this.CFG_Pedido.ST_DisableAuto = false;
            this.CFG_Pedido.ST_Float = false;
            this.CFG_Pedido.ST_Gravar = true;
            this.CFG_Pedido.ST_Int = true;
            this.CFG_Pedido.ST_LimpaCampo = true;
            this.CFG_Pedido.ST_NotNull = true;
            this.CFG_Pedido.ST_PrimaryKey = false;
            this.CFG_Pedido.TabIndex = 0;
            this.CFG_Pedido.TextOld = null;
            this.CFG_Pedido.Leave += new System.EventHandler(this.CFG_Pedido_Leave);
            // 
            // BB_Endereco
            // 
            this.BB_Endereco.Image = ((System.Drawing.Image)(resources.GetObject("BB_Endereco.Image")));
            this.BB_Endereco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Endereco.Location = new System.Drawing.Point(132, 81);
            this.BB_Endereco.Name = "BB_Endereco";
            this.BB_Endereco.Size = new System.Drawing.Size(28, 20);
            this.BB_Endereco.TabIndex = 3;
            this.BB_Endereco.UseVisualStyleBackColor = true;
            this.BB_Endereco.Click += new System.EventHandler(this.BB_Endereco_Click);
            // 
            // DS_Endereco
            // 
            this.DS_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Endereco.Enabled = false;
            this.DS_Endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Endereco.Location = new System.Drawing.Point(163, 81);
            this.DS_Endereco.Name = "DS_Endereco";
            this.DS_Endereco.NM_Alias = "";
            this.DS_Endereco.NM_Campo = "DS_Endereco";
            this.DS_Endereco.NM_CampoBusca = "DS_Endereco";
            this.DS_Endereco.NM_Param = "@P_DS_ENDERECO";
            this.DS_Endereco.QTD_Zero = 0;
            this.DS_Endereco.Size = new System.Drawing.Size(566, 20);
            this.DS_Endereco.ST_AutoInc = false;
            this.DS_Endereco.ST_DisableAuto = false;
            this.DS_Endereco.ST_Float = false;
            this.DS_Endereco.ST_Gravar = true;
            this.DS_Endereco.ST_Int = false;
            this.DS_Endereco.ST_LimpaCampo = true;
            this.DS_Endereco.ST_NotNull = false;
            this.DS_Endereco.ST_PrimaryKey = false;
            this.DS_Endereco.TabIndex = 143;
            this.DS_Endereco.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(31, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 144;
            this.label3.Text = "Endereço:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Endereco
            // 
            this.CD_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Endereco.Location = new System.Drawing.Point(93, 81);
            this.CD_Endereco.Name = "CD_Endereco";
            this.CD_Endereco.NM_Alias = "";
            this.CD_Endereco.NM_Campo = "CD_Endereco";
            this.CD_Endereco.NM_CampoBusca = "CD_Endereco";
            this.CD_Endereco.NM_Param = "@P_CD_ENDERECO";
            this.CD_Endereco.QTD_Zero = 0;
            this.CD_Endereco.Size = new System.Drawing.Size(37, 20);
            this.CD_Endereco.ST_AutoInc = false;
            this.CD_Endereco.ST_DisableAuto = false;
            this.CD_Endereco.ST_Float = false;
            this.CD_Endereco.ST_Gravar = true;
            this.CD_Endereco.ST_Int = true;
            this.CD_Endereco.ST_LimpaCampo = true;
            this.CD_Endereco.ST_NotNull = true;
            this.CD_Endereco.ST_PrimaryKey = false;
            this.CD_Endereco.TabIndex = 2;
            this.CD_Endereco.TextOld = null;
            this.CD_Endereco.Leave += new System.EventHandler(this.CD_Endereco_Leave);
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.Enabled = false;
            this.NM_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Clifor.Location = new System.Drawing.Point(201, 55);
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "NM_Clifor";
            this.NM_Clifor.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.Size = new System.Drawing.Size(528, 20);
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = true;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TabIndex = 138;
            this.NM_Clifor.TextOld = null;
            // 
            // lblClifor
            // 
            this.lblClifor.AutoSize = true;
            this.lblClifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblClifor.Location = new System.Drawing.Point(45, 58);
            this.lblClifor.Name = "lblClifor";
            this.lblClifor.Size = new System.Drawing.Size(42, 13);
            this.lblClifor.TabIndex = 139;
            this.lblClifor.Text = "Cliente:";
            this.lblClifor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Clifor.Location = new System.Drawing.Point(93, 55);
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.Size = new System.Drawing.Size(75, 20);
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = true;
            this.CD_Clifor.ST_Int = true;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = true;
            this.CD_Clifor.ST_PrimaryKey = false;
            this.CD_Clifor.TabIndex = 137;
            this.CD_Clifor.TextOld = null;
            this.CD_Clifor.Leave += new System.EventHandler(this.CD_Clifor_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(36, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 135;
            this.label11.Text = "Empresa:";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Location = new System.Drawing.Point(93, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(61, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 133;
            this.cd_empresa.TextOld = null;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(160, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(569, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 134;
            this.nm_empresa.TextOld = null;
            // 
            // TFPedidoPsDiversa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 255);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFPedidoPsDiversa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedido Pesagem Diversa";
            this.Load += new System.EventHandler(this.TFPedidoPsDiversa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFPedidoPsDiversa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label11;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault NM_Clifor;
        private System.Windows.Forms.Label lblClifor;
        private Componentes.EditDefault CD_Clifor;
        private Componentes.EditDefault DS_Endereco;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault CD_Endereco;
        private System.Windows.Forms.Button BB_Endereco;
        private Componentes.EditDefault TP_Mov;
        private Componentes.EditDefault DS_CFGPedido;
        private System.Windows.Forms.Button BB_CFGPedido;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault CFG_Pedido;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_produto;
        public Componentes.EditDefault DS_Local;
        private System.Windows.Forms.Button BB_Local;
        private System.Windows.Forms.Label label2;
        public Componentes.EditDefault CD_Local;
        public Componentes.EditDefault DS_Unidade;
        private System.Windows.Forms.Button BB_Unidade;
        private System.Windows.Forms.Label label57;
        public Componentes.EditDefault CD_Unidade;
        public Componentes.EditDefault SG_Unidade_Estoque;
        public Componentes.EditFloat Quantidade;
        private System.Windows.Forms.Label label58;
        public Componentes.EditFloat Vl_Unitario;
        private System.Windows.Forms.Label label59;
        public Componentes.EditDefault SG_UniQTD;
        public Componentes.EditFloat Sub_Total;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bbProduto;
        private System.Windows.Forms.Button bbCliente;
    }
}