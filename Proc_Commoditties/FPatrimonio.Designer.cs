namespace Proc_Commoditties
{
    partial class TFPatrimonio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFPatrimonio));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsPatrimonio = new System.Windows.Forms.BindingSource(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.label27 = new System.Windows.Forms.Label();
            this.qtd_horas = new Componentes.EditFloat(this.components);
            this.st_controlehora = new Componentes.CheckBoxDefault(this.components);
            this.TP_VidaUtil = new Componentes.ComboBoxDefault(this.components);
            this.quantidade = new Componentes.EditFloat(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.VidaUtil = new Componentes.EditFloat(this.components);
            this.vl_compra = new Componentes.EditFloat(this.components);
            this.Nm_fornecedor = new Componentes.EditDefault(this.components);
            this.DT_Compra = new Componentes.EditData(this.components);
            this.Nr_NFCompra = new Componentes.EditDefault(this.components);
            this.Nr_patrimonio = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPatrimonio)).BeginInit();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_horas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VidaUtil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_compra)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(751, 43);
            this.barraMenu.TabIndex = 537;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // bsPatrimonio
            // 
            this.bsPatrimonio.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadPatrimonio);
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label27);
            this.pDados.Controls.Add(this.qtd_horas);
            this.pDados.Controls.Add(this.st_controlehora);
            this.pDados.Controls.Add(this.TP_VidaUtil);
            this.pDados.Controls.Add(this.quantidade);
            this.pDados.Controls.Add(this.label25);
            this.pDados.Controls.Add(this.label24);
            this.pDados.Controls.Add(this.label23);
            this.pDados.Controls.Add(this.label22);
            this.pDados.Controls.Add(this.label21);
            this.pDados.Controls.Add(this.label17);
            this.pDados.Controls.Add(this.label14);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.label13);
            this.pDados.Controls.Add(this.VidaUtil);
            this.pDados.Controls.Add(this.vl_compra);
            this.pDados.Controls.Add(this.Nm_fornecedor);
            this.pDados.Controls.Add(this.DT_Compra);
            this.pDados.Controls.Add(this.Nr_NFCompra);
            this.pDados.Controls.Add(this.Nr_patrimonio);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(751, 134);
            this.pDados.TabIndex = 0;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(232, 112);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(74, 13);
            this.label27.TabIndex = 929;
            this.label27.Text = "QTD.Horas:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qtd_horas
            // 
            this.qtd_horas.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPatrimonio, "Qtd_horas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_horas.DecimalPlaces = 2;
            this.qtd_horas.Enabled = false;
            this.qtd_horas.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qtd_horas.Location = new System.Drawing.Point(313, 109);
            this.qtd_horas.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.qtd_horas.Name = "qtd_horas";
            this.qtd_horas.NM_Alias = "";
            this.qtd_horas.NM_Campo = "";
            this.qtd_horas.NM_Param = "";
            this.qtd_horas.Operador = "";
            this.qtd_horas.Size = new System.Drawing.Size(81, 20);
            this.qtd_horas.ST_AutoInc = false;
            this.qtd_horas.ST_DisableAuto = false;
            this.qtd_horas.ST_Gravar = true;
            this.qtd_horas.ST_LimparCampo = true;
            this.qtd_horas.ST_NotNull = false;
            this.qtd_horas.ST_PrimaryKey = false;
            this.qtd_horas.TabIndex = 11;
            this.qtd_horas.ThousandsSeparator = true;
            this.qtd_horas.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // st_controlehora
            // 
            this.st_controlehora.AutoSize = true;
            this.st_controlehora.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPatrimonio, "St_controlehorabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_controlehora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.st_controlehora.Location = new System.Drawing.Point(98, 111);
            this.st_controlehora.Name = "st_controlehora";
            this.st_controlehora.NM_Alias = "";
            this.st_controlehora.NM_Campo = "";
            this.st_controlehora.NM_Param = "";
            this.st_controlehora.Size = new System.Drawing.Size(128, 17);
            this.st_controlehora.ST_Gravar = false;
            this.st_controlehora.ST_LimparCampo = true;
            this.st_controlehora.ST_NotNull = false;
            this.st_controlehora.TabIndex = 10;
            this.st_controlehora.Text = "Controle de Horas";
            this.st_controlehora.UseVisualStyleBackColor = true;
            this.st_controlehora.Vl_False = "";
            this.st_controlehora.Vl_True = "";
            // 
            // TP_VidaUtil
            // 
            this.TP_VidaUtil.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsPatrimonio, "Tp_vidautil", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_VidaUtil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TP_VidaUtil.FormattingEnabled = true;
            this.TP_VidaUtil.Location = new System.Drawing.Point(375, 82);
            this.TP_VidaUtil.Name = "TP_VidaUtil";
            this.TP_VidaUtil.NM_Alias = "";
            this.TP_VidaUtil.NM_Campo = "";
            this.TP_VidaUtil.NM_Param = "";
            this.TP_VidaUtil.Size = new System.Drawing.Size(234, 21);
            this.TP_VidaUtil.ST_Gravar = true;
            this.TP_VidaUtil.ST_LimparCampo = true;
            this.TP_VidaUtil.ST_NotNull = false;
            this.TP_VidaUtil.TabIndex = 8;
            // 
            // quantidade
            // 
            this.quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPatrimonio, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.quantidade.Location = new System.Drawing.Point(658, 83);
            this.quantidade.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.quantidade.Name = "quantidade";
            this.quantidade.NM_Alias = "";
            this.quantidade.NM_Campo = "";
            this.quantidade.NM_Param = "";
            this.quantidade.Operador = "";
            this.quantidade.Size = new System.Drawing.Size(88, 20);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = true;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = false;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 9;
            this.quantidade.ThousandsSeparator = true;
            this.quantidade.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(615, 85);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 13);
            this.label25.TabIndex = 928;
            this.label25.Text = "QTD:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(219, 85);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 13);
            this.label24.TabIndex = 927;
            this.label24.Text = "Vida Útil:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(24, 83);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 13);
            this.label23.TabIndex = 926;
            this.label23.Text = "Vl.Compra:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(372, 59);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 13);
            this.label22.TabIndex = 925;
            this.label22.Text = "Fornecedor:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(218, 58);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 13);
            this.label21.TabIndex = 924;
            this.label21.Text = "DT.Compra:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(4, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 13);
            this.label17.TabIndex = 923;
            this.label17.Text = "Nº NF Compra:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(4, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 922;
            this.label14.Text = "Nº Patrimônio:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(170, 3);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 1;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(33, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 920;
            this.label13.Text = "Empresa:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // VidaUtil
            // 
            this.VidaUtil.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPatrimonio, "VidaUtil", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VidaUtil.DecimalPlaces = 2;
            this.VidaUtil.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.VidaUtil.Location = new System.Drawing.Point(284, 83);
            this.VidaUtil.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.VidaUtil.Name = "VidaUtil";
            this.VidaUtil.NM_Alias = "";
            this.VidaUtil.NM_Campo = "";
            this.VidaUtil.NM_Param = "";
            this.VidaUtil.Operador = "";
            this.VidaUtil.Size = new System.Drawing.Size(81, 20);
            this.VidaUtil.ST_AutoInc = false;
            this.VidaUtil.ST_DisableAuto = false;
            this.VidaUtil.ST_Gravar = true;
            this.VidaUtil.ST_LimparCampo = true;
            this.VidaUtil.ST_NotNull = false;
            this.VidaUtil.ST_PrimaryKey = false;
            this.VidaUtil.TabIndex = 7;
            this.VidaUtil.ThousandsSeparator = true;
            this.VidaUtil.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // vl_compra
            // 
            this.vl_compra.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPatrimonio, "Vl_compra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_compra.DecimalPlaces = 2;
            this.vl_compra.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_compra.Location = new System.Drawing.Point(98, 81);
            this.vl_compra.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.vl_compra.Name = "vl_compra";
            this.vl_compra.NM_Alias = "";
            this.vl_compra.NM_Campo = "";
            this.vl_compra.NM_Param = "";
            this.vl_compra.Operador = "";
            this.vl_compra.Size = new System.Drawing.Size(110, 20);
            this.vl_compra.ST_AutoInc = false;
            this.vl_compra.ST_DisableAuto = false;
            this.vl_compra.ST_Gravar = true;
            this.vl_compra.ST_LimparCampo = true;
            this.vl_compra.ST_NotNull = false;
            this.vl_compra.ST_PrimaryKey = false;
            this.vl_compra.TabIndex = 6;
            this.vl_compra.ThousandsSeparator = true;
            this.vl_compra.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // Nm_fornecedor
            // 
            this.Nm_fornecedor.BackColor = System.Drawing.SystemColors.Window;
            this.Nm_fornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nm_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nm_fornecedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPatrimonio, "Nm_fornecedor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nm_fornecedor.Location = new System.Drawing.Point(453, 56);
            this.Nm_fornecedor.Name = "Nm_fornecedor";
            this.Nm_fornecedor.NM_Alias = "";
            this.Nm_fornecedor.NM_Campo = "";
            this.Nm_fornecedor.NM_CampoBusca = "";
            this.Nm_fornecedor.NM_Param = "";
            this.Nm_fornecedor.QTD_Zero = 0;
            this.Nm_fornecedor.Size = new System.Drawing.Size(293, 20);
            this.Nm_fornecedor.ST_AutoInc = false;
            this.Nm_fornecedor.ST_DisableAuto = false;
            this.Nm_fornecedor.ST_Float = false;
            this.Nm_fornecedor.ST_Gravar = true;
            this.Nm_fornecedor.ST_Int = false;
            this.Nm_fornecedor.ST_LimpaCampo = true;
            this.Nm_fornecedor.ST_NotNull = false;
            this.Nm_fornecedor.ST_PrimaryKey = false;
            this.Nm_fornecedor.TabIndex = 5;
            this.Nm_fornecedor.TextOld = null;
            // 
            // DT_Compra
            // 
            this.DT_Compra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Compra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPatrimonio, "Dt_comprastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Compra.Location = new System.Drawing.Point(298, 55);
            this.DT_Compra.Mask = "00/00/0000";
            this.DT_Compra.Name = "DT_Compra";
            this.DT_Compra.NM_Alias = "";
            this.DT_Compra.NM_Campo = "";
            this.DT_Compra.NM_CampoBusca = "";
            this.DT_Compra.NM_Param = "";
            this.DT_Compra.Operador = "";
            this.DT_Compra.Size = new System.Drawing.Size(67, 20);
            this.DT_Compra.ST_Gravar = true;
            this.DT_Compra.ST_LimpaCampo = true;
            this.DT_Compra.ST_NotNull = false;
            this.DT_Compra.ST_PrimaryKey = false;
            this.DT_Compra.TabIndex = 4;
            // 
            // Nr_NFCompra
            // 
            this.Nr_NFCompra.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_NFCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_NFCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_NFCompra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPatrimonio, "Nr_NFCompra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nr_NFCompra.Location = new System.Drawing.Point(98, 54);
            this.Nr_NFCompra.Name = "Nr_NFCompra";
            this.Nr_NFCompra.NM_Alias = "";
            this.Nr_NFCompra.NM_Campo = "";
            this.Nr_NFCompra.NM_CampoBusca = "";
            this.Nr_NFCompra.NM_Param = "";
            this.Nr_NFCompra.QTD_Zero = 0;
            this.Nr_NFCompra.Size = new System.Drawing.Size(110, 20);
            this.Nr_NFCompra.ST_AutoInc = false;
            this.Nr_NFCompra.ST_DisableAuto = false;
            this.Nr_NFCompra.ST_Float = false;
            this.Nr_NFCompra.ST_Gravar = true;
            this.Nr_NFCompra.ST_Int = false;
            this.Nr_NFCompra.ST_LimpaCampo = true;
            this.Nr_NFCompra.ST_NotNull = false;
            this.Nr_NFCompra.ST_PrimaryKey = false;
            this.Nr_NFCompra.TabIndex = 3;
            this.Nr_NFCompra.TextOld = null;
            // 
            // Nr_patrimonio
            // 
            this.Nr_patrimonio.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_patrimonio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_patrimonio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_patrimonio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPatrimonio, "Nr_patrimonio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nr_patrimonio.Location = new System.Drawing.Point(98, 28);
            this.Nr_patrimonio.Name = "Nr_patrimonio";
            this.Nr_patrimonio.NM_Alias = "";
            this.Nr_patrimonio.NM_Campo = "";
            this.Nr_patrimonio.NM_CampoBusca = "";
            this.Nr_patrimonio.NM_Param = "";
            this.Nr_patrimonio.QTD_Zero = 0;
            this.Nr_patrimonio.Size = new System.Drawing.Size(648, 20);
            this.Nr_patrimonio.ST_AutoInc = false;
            this.Nr_patrimonio.ST_DisableAuto = false;
            this.Nr_patrimonio.ST_Float = false;
            this.Nr_patrimonio.ST_Gravar = true;
            this.Nr_patrimonio.ST_Int = false;
            this.Nr_patrimonio.ST_LimpaCampo = true;
            this.Nr_patrimonio.ST_NotNull = false;
            this.Nr_patrimonio.ST_PrimaryKey = false;
            this.Nr_patrimonio.TabIndex = 2;
            this.Nr_patrimonio.TextOld = null;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPatrimonio, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(203, 3);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(543, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 921;
            this.NM_Empresa.TextOld = null;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.Color.White;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPatrimonio, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(98, 3);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(70, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = false;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.TextOld = "";
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // TFPatrimonio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 177);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFPatrimonio";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Patrimonio";
            this.Load += new System.EventHandler(this.TFPatrimonio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFPatrimonio_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPatrimonio)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_horas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VidaUtil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_compra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.BindingSource bsPatrimonio;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label27;
        private Componentes.EditFloat qtd_horas;
        private Componentes.CheckBoxDefault st_controlehora;
        private Componentes.ComboBoxDefault TP_VidaUtil;
        private Componentes.EditFloat quantidade;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.Label label13;
        private Componentes.EditFloat VidaUtil;
        private Componentes.EditFloat vl_compra;
        private Componentes.EditDefault Nm_fornecedor;
        private Componentes.EditData DT_Compra;
        private Componentes.EditDefault Nr_NFCompra;
        private Componentes.EditDefault Nr_patrimonio;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault CD_Empresa;
    }
}