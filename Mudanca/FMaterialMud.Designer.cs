namespace Mudanca
{
    partial class TFMaterialMud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFMaterialMud));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Lbl_Produto = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.quantidade = new Componentes.EditFloat(this.components);
            this.Sub_Total = new Componentes.EditFloat(this.components);
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Saldo_Almox = new Componentes.EditFloat(this.components);
            this.label59 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.bb_almox = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ds_almox = new Componentes.EditDefault(this.components);
            this.id_almox = new Componentes.EditDefault(this.components);
            this.bsMaterialMud = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Saldo_Almox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMaterialMud)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(675, 43);
            this.barraMenu.TabIndex = 13;
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
            this.pDados.Controls.Add(this.panelDados1);
            this.pDados.Controls.Add(this.bb_almox);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.ds_almox);
            this.pDados.Controls.Add(this.id_almox);
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.Lbl_Produto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(675, 210);
            this.pDados.TabIndex = 14;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMaterialMud, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Enabled = false;
            this.DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Produto.Location = new System.Drawing.Point(92, 60);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_FUNCAO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.Size = new System.Drawing.Size(574, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = true;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 173;
            this.DS_Produto.TextOld = null;
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMaterialMud, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CD_Produto.Location = new System.Drawing.Point(92, 25);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(574, 29);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = false;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 0;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CD_Produto_KeyDown);
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(89, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(452, 13);
            this.label3.TabIndex = 172;
            this.label3.Text = "Localiza produto por codigo interno, codigo de barras, codigo referencia ou parte" +
                " da descrição";
            // 
            // Lbl_Produto
            // 
            this.Lbl_Produto.AutoSize = true;
            this.Lbl_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Lbl_Produto.Location = new System.Drawing.Point(35, 31);
            this.Lbl_Produto.Name = "Lbl_Produto";
            this.Lbl_Produto.Size = new System.Drawing.Size(55, 13);
            this.Lbl_Produto.TabIndex = 171;
            this.Lbl_Produto.Text = "Produto:";
            this.Lbl_Produto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.quantidade);
            this.panelDados1.Controls.Add(this.Sub_Total);
            this.panelDados1.Controls.Add(this.vl_unitario);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.Saldo_Almox);
            this.panelDados1.Controls.Add(this.label59);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.sigla_unidade);
            this.panelDados1.Location = new System.Drawing.Point(92, 109);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(574, 88);
            this.panelDados1.TabIndex = 186;
            // 
            // quantidade
            // 
            this.quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsMaterialMud, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Location = new System.Drawing.Point(87, 16);
            this.quantidade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.quantidade.Name = "quantidade";
            this.quantidade.NM_Alias = "";
            this.quantidade.NM_Campo = "";
            this.quantidade.NM_Param = "";
            this.quantidade.Operador = "";
            this.quantidade.Size = new System.Drawing.Size(76, 20);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = false;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = false;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 4;
            this.quantidade.ThousandsSeparator = true;
            this.quantidade.Leave += new System.EventHandler(this.quantidade_Leave);
            // 
            // Sub_Total
            // 
            this.Sub_Total.DecimalPlaces = 2;
            this.Sub_Total.Enabled = false;
            this.Sub_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Sub_Total.Location = new System.Drawing.Point(278, 51);
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
            this.Sub_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Sub_Total.Size = new System.Drawing.Size(132, 27);
            this.Sub_Total.ST_AutoInc = false;
            this.Sub_Total.ST_DisableAuto = false;
            this.Sub_Total.ST_Gravar = true;
            this.Sub_Total.ST_LimparCampo = true;
            this.Sub_Total.ST_NotNull = false;
            this.Sub_Total.ST_PrimaryKey = false;
            this.Sub_Total.TabIndex = 176;
            this.Sub_Total.ThousandsSeparator = true;
            // 
            // vl_unitario
            // 
            this.vl_unitario.DecimalPlaces = 2;
            this.vl_unitario.Enabled = false;
            this.vl_unitario.Location = new System.Drawing.Point(87, 51);
            this.vl_unitario.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.vl_unitario.Name = "vl_unitario";
            this.vl_unitario.NM_Alias = "";
            this.vl_unitario.NM_Campo = "Vl_Unitario";
            this.vl_unitario.NM_Param = "@P_VL_UNITARIO";
            this.vl_unitario.Operador = "";
            this.vl_unitario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_unitario.Size = new System.Drawing.Size(90, 20);
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = true;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = true;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.TabIndex = 179;
            this.vl_unitario.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(196, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 177;
            this.label7.Text = "Custo Total:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 180;
            this.label2.Text = "Valor Custo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Saldo_Almox
            // 
            this.Saldo_Almox.DecimalPlaces = 2;
            this.Saldo_Almox.Enabled = false;
            this.Saldo_Almox.Location = new System.Drawing.Point(278, 16);
            this.Saldo_Almox.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Saldo_Almox.Name = "Saldo_Almox";
            this.Saldo_Almox.NM_Alias = "";
            this.Saldo_Almox.NM_Campo = "Vl_Unitario";
            this.Saldo_Almox.NM_Param = "@P_VL_UNITARIO";
            this.Saldo_Almox.Operador = "";
            this.Saldo_Almox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Saldo_Almox.Size = new System.Drawing.Size(86, 20);
            this.Saldo_Almox.ST_AutoInc = false;
            this.Saldo_Almox.ST_DisableAuto = false;
            this.Saldo_Almox.ST_Gravar = true;
            this.Saldo_Almox.ST_LimparCampo = true;
            this.Saldo_Almox.ST_NotNull = true;
            this.Saldo_Almox.ST_PrimaryKey = false;
            this.Saldo_Almox.TabIndex = 174;
            this.Saldo_Almox.ThousandsSeparator = true;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label59.Location = new System.Drawing.Point(229, 18);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(43, 13);
            this.label59.TabIndex = 175;
            this.label59.Text = "Saldo:";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantidade:";
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMaterialMud, "Sigla_Unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sigla_unidade.Location = new System.Drawing.Point(169, 16);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "sigla_unidade";
            this.sigla_unidade.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidade.NM_Param = "@P_DS_FUNCAO";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.ReadOnly = true;
            this.sigla_unidade.Size = new System.Drawing.Size(46, 20);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 178;
            this.sigla_unidade.TextOld = null;
            // 
            // bb_almox
            // 
            this.bb_almox.BackColor = System.Drawing.SystemColors.Control;
            this.bb_almox.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_almox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_almox.Image = ((System.Drawing.Image)(resources.GetObject("bb_almox.Image")));
            this.bb_almox.Location = new System.Drawing.Point(178, 83);
            this.bb_almox.Name = "bb_almox";
            this.bb_almox.Size = new System.Drawing.Size(32, 20);
            this.bb_almox.TabIndex = 183;
            this.bb_almox.UseVisualStyleBackColor = false;
            this.bb_almox.Click += new System.EventHandler(this.bb_almox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 185;
            this.label5.Text = "Almoxarifado:";
            // 
            // ds_almox
            // 
            this.ds_almox.BackColor = System.Drawing.SystemColors.Window;
            this.ds_almox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_almox.Enabled = false;
            this.ds_almox.Location = new System.Drawing.Point(213, 83);
            this.ds_almox.MaxLength = 20;
            this.ds_almox.Name = "ds_almox";
            this.ds_almox.NM_Alias = "";
            this.ds_almox.NM_Campo = "ds_almoxarifado";
            this.ds_almox.NM_CampoBusca = "ds_almoxarifado";
            this.ds_almox.NM_Param = "";
            this.ds_almox.QTD_Zero = 0;
            this.ds_almox.Size = new System.Drawing.Size(452, 20);
            this.ds_almox.ST_AutoInc = false;
            this.ds_almox.ST_DisableAuto = false;
            this.ds_almox.ST_Float = false;
            this.ds_almox.ST_Gravar = false;
            this.ds_almox.ST_Int = false;
            this.ds_almox.ST_LimpaCampo = true;
            this.ds_almox.ST_NotNull = false;
            this.ds_almox.ST_PrimaryKey = false;
            this.ds_almox.TabIndex = 184;
            this.ds_almox.TextOld = null;
            // 
            // id_almox
            // 
            this.id_almox.BackColor = System.Drawing.SystemColors.Window;
            this.id_almox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_almox.Location = new System.Drawing.Point(92, 83);
            this.id_almox.MaxLength = 5;
            this.id_almox.Name = "id_almox";
            this.id_almox.NM_Alias = "a";
            this.id_almox.NM_Campo = "id_almox";
            this.id_almox.NM_CampoBusca = "id_almox";
            this.id_almox.NM_Param = "@P_ID_ALMOX";
            this.id_almox.QTD_Zero = 0;
            this.id_almox.Size = new System.Drawing.Size(86, 20);
            this.id_almox.ST_AutoInc = false;
            this.id_almox.ST_DisableAuto = false;
            this.id_almox.ST_Float = false;
            this.id_almox.ST_Gravar = true;
            this.id_almox.ST_Int = true;
            this.id_almox.ST_LimpaCampo = true;
            this.id_almox.ST_NotNull = true;
            this.id_almox.ST_PrimaryKey = false;
            this.id_almox.TabIndex = 182;
            this.id_almox.TextOld = null;
            this.id_almox.Leave += new System.EventHandler(this.id_almox_Leave);
            // 
            // bsMaterialMud
            // 
            this.bsMaterialMud.DataSource = typeof(CamadaDados.Mudanca.TList_MaterialMud);
            // 
            // TFMaterialMud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 253);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFMaterialMud";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Materiais Mudanças";
            this.Load += new System.EventHandler(this.TFMaterialMud_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFMaterialMud_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Saldo_Almox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMaterialMud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        public Componentes.EditDefault DS_Produto;
        public Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lbl_Produto;
        private System.Windows.Forms.BindingSource bsMaterialMud;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditFloat quantidade;
        public Componentes.EditFloat Sub_Total;
        public Componentes.EditFloat vl_unitario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        public Componentes.EditFloat Saldo_Almox;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label1;
        public Componentes.EditDefault sigla_unidade;
        public System.Windows.Forms.Button bb_almox;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault ds_almox;
        private Componentes.EditDefault id_almox;
    }
}