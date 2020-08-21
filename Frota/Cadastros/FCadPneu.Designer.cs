namespace Frota
{
    partial class TFCadPneu
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
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadPneu));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.edt_saldodisponivel = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.ds_almoxarifado = new Componentes.EditDefault(this.components);
            this.id_almox = new Componentes.EditDefault(this.components);
            this.bsPneu = new System.Windows.Forms.BindingSource(this.components);
            this.bb_almox = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.edtCusto = new Componentes.EditFloat(this.components);
            this.cbGerarAlmoxarifado = new Componentes.CheckBoxDefault(this.components);
            this.BB_Novo_Desenho = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDesenho = new Componentes.ComboBoxDefault(this.components);
            this.lblCusto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tp_estado = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.Nr_serie = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.label37 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPneu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCusto)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(3, 47);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(70, 13);
            label5.TabIndex = 583;
            label5.Text = "Almoxarifado:";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(652, 43);
            this.barraMenu.TabIndex = 0;
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
            this.pDados.Controls.Add(this.edt_saldodisponivel);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.ds_almoxarifado);
            this.pDados.Controls.Add(this.id_almox);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(this.bb_almox);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.edtCusto);
            this.pDados.Controls.Add(this.cbGerarAlmoxarifado);
            this.pDados.Controls.Add(this.BB_Novo_Desenho);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.cbxDesenho);
            this.pDados.Controls.Add(this.lblCusto);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.tp_estado);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.Nr_serie);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.cbEmpresa);
            this.pDados.Controls.Add(this.label37);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(652, 219);
            this.pDados.TabIndex = 21;
            // 
            // edt_saldodisponivel
            // 
            this.edt_saldodisponivel.BackColor = System.Drawing.SystemColors.Window;
            this.edt_saldodisponivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_saldodisponivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edt_saldodisponivel.Enabled = false;
            this.edt_saldodisponivel.Location = new System.Drawing.Point(582, 129);
            this.edt_saldodisponivel.Name = "edt_saldodisponivel";
            this.edt_saldodisponivel.NM_Alias = "";
            this.edt_saldodisponivel.NM_Campo = "";
            this.edt_saldodisponivel.NM_CampoBusca = "";
            this.edt_saldodisponivel.NM_Param = "";
            this.edt_saldodisponivel.QTD_Zero = 0;
            this.edt_saldodisponivel.Size = new System.Drawing.Size(57, 20);
            this.edt_saldodisponivel.ST_AutoInc = false;
            this.edt_saldodisponivel.ST_DisableAuto = false;
            this.edt_saldodisponivel.ST_Float = false;
            this.edt_saldodisponivel.ST_Gravar = false;
            this.edt_saldodisponivel.ST_Int = true;
            this.edt_saldodisponivel.ST_LimpaCampo = false;
            this.edt_saldodisponivel.ST_NotNull = false;
            this.edt_saldodisponivel.ST_PrimaryKey = false;
            this.edt_saldodisponivel.TabIndex = 586;
            this.edt_saldodisponivel.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(485, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 585;
            this.label6.Text = "Saldo Disponível:";
            // 
            // ds_almoxarifado
            // 
            this.ds_almoxarifado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_almoxarifado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_almoxarifado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_almoxarifado.Enabled = false;
            this.ds_almoxarifado.Location = new System.Drawing.Point(195, 44);
            this.ds_almoxarifado.Name = "ds_almoxarifado";
            this.ds_almoxarifado.NM_Alias = "";
            this.ds_almoxarifado.NM_Campo = "ds_almoxarifado";
            this.ds_almoxarifado.NM_CampoBusca = "ds_almoxarifado";
            this.ds_almoxarifado.NM_Param = "@P_ALMOXARIFADO";
            this.ds_almoxarifado.QTD_Zero = 0;
            this.ds_almoxarifado.Size = new System.Drawing.Size(444, 20);
            this.ds_almoxarifado.ST_AutoInc = false;
            this.ds_almoxarifado.ST_DisableAuto = false;
            this.ds_almoxarifado.ST_Float = false;
            this.ds_almoxarifado.ST_Gravar = false;
            this.ds_almoxarifado.ST_Int = false;
            this.ds_almoxarifado.ST_LimpaCampo = true;
            this.ds_almoxarifado.ST_NotNull = false;
            this.ds_almoxarifado.ST_PrimaryKey = false;
            this.ds_almoxarifado.TabIndex = 584;
            this.ds_almoxarifado.TextOld = null;
            // 
            // id_almox
            // 
            this.id_almox.BackColor = System.Drawing.Color.White;
            this.id_almox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPneu, "Id_almox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_almox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_almox.Location = new System.Drawing.Point(75, 44);
            this.id_almox.MaxLength = 4;
            this.id_almox.Name = "id_almox";
            this.id_almox.NM_Alias = "";
            this.id_almox.NM_Campo = "id_almox";
            this.id_almox.NM_CampoBusca = "id_almox";
            this.id_almox.NM_Param = "@P_CD_EMPRESA";
            this.id_almox.QTD_Zero = 0;
            this.id_almox.Size = new System.Drawing.Size(80, 20);
            this.id_almox.ST_AutoInc = false;
            this.id_almox.ST_DisableAuto = false;
            this.id_almox.ST_Float = false;
            this.id_almox.ST_Gravar = false;
            this.id_almox.ST_Int = false;
            this.id_almox.ST_LimpaCampo = true;
            this.id_almox.ST_NotNull = false;
            this.id_almox.ST_PrimaryKey = false;
            this.id_almox.TabIndex = 0;
            this.id_almox.TextOld = null;
            this.id_almox.Leave += new System.EventHandler(this.id_almox_Leave);
            // 
            // bsPneu
            // 
            this.bsPneu.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_LanPneu);
            // 
            // bb_almox
            // 
            this.bb_almox.BackColor = System.Drawing.SystemColors.Control;
            this.bb_almox.Image = ((System.Drawing.Image)(resources.GetObject("bb_almox.Image")));
            this.bb_almox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_almox.Location = new System.Drawing.Point(161, 44);
            this.bb_almox.Name = "bb_almox";
            this.bb_almox.Size = new System.Drawing.Size(28, 20);
            this.bb_almox.TabIndex = 1;
            this.bb_almox.UseVisualStyleBackColor = false;
            this.bb_almox.Click += new System.EventHandler(this.bb_almox_Click);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPneu, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(75, 71);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(80, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 2;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // edtCusto
            // 
            this.edtCusto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPneu, "CustoPneuAlmoxarifado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.edtCusto.DecimalPlaces = 2;
            this.edtCusto.Enabled = false;
            this.edtCusto.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edtCusto.Location = new System.Drawing.Point(205, 128);
            this.edtCusto.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.edtCusto.Name = "edtCusto";
            this.edtCusto.NM_Alias = "";
            this.edtCusto.NM_Campo = "";
            this.edtCusto.NM_Param = "";
            this.edtCusto.Operador = "";
            this.edtCusto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edtCusto.Size = new System.Drawing.Size(105, 20);
            this.edtCusto.ST_AutoInc = false;
            this.edtCusto.ST_DisableAuto = false;
            this.edtCusto.ST_Gravar = false;
            this.edtCusto.ST_LimparCampo = true;
            this.edtCusto.ST_NotNull = false;
            this.edtCusto.ST_PrimaryKey = false;
            this.edtCusto.TabIndex = 8;
            this.edtCusto.ThousandsSeparator = true;
            this.edtCusto.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // cbGerarAlmoxarifado
            // 
            this.cbGerarAlmoxarifado.AutoSize = true;
            this.cbGerarAlmoxarifado.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPneu, "GerarAlmoxarifado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbGerarAlmoxarifado.Location = new System.Drawing.Point(316, 129);
            this.cbGerarAlmoxarifado.Name = "cbGerarAlmoxarifado";
            this.cbGerarAlmoxarifado.NM_Alias = "";
            this.cbGerarAlmoxarifado.NM_Campo = "";
            this.cbGerarAlmoxarifado.NM_Param = "";
            this.cbGerarAlmoxarifado.Size = new System.Drawing.Size(78, 17);
            this.cbGerarAlmoxarifado.ST_Gravar = false;
            this.cbGerarAlmoxarifado.ST_LimparCampo = true;
            this.cbGerarAlmoxarifado.ST_NotNull = false;
            this.cbGerarAlmoxarifado.TabIndex = 9;
            this.cbGerarAlmoxarifado.Text = "Pneu novo";
            this.cbGerarAlmoxarifado.UseVisualStyleBackColor = true;
            this.cbGerarAlmoxarifado.Vl_False = "";
            this.cbGerarAlmoxarifado.Vl_True = "";
            this.cbGerarAlmoxarifado.CheckedChanged += new System.EventHandler(this.cbGerarAlmoxarifado_CheckedChanged);
            // 
            // BB_Novo_Desenho
            // 
            this.BB_Novo_Desenho.Image = ((System.Drawing.Image)(resources.GetObject("BB_Novo_Desenho.Image")));
            this.BB_Novo_Desenho.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Novo_Desenho.Location = new System.Drawing.Point(611, 97);
            this.BB_Novo_Desenho.Name = "BB_Novo_Desenho";
            this.BB_Novo_Desenho.Size = new System.Drawing.Size(28, 20);
            this.BB_Novo_Desenho.TabIndex = 6;
            this.BB_Novo_Desenho.UseVisualStyleBackColor = true;
            this.BB_Novo_Desenho.Click += new System.EventHandler(this.BB_Novo_Desenho_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 576;
            this.label4.Text = "Desenho:";
            // 
            // cbxDesenho
            // 
            this.cbxDesenho.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsPneu, "Id_desenho", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxDesenho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDesenho.FormattingEnabled = true;
            this.cbxDesenho.Location = new System.Drawing.Point(352, 97);
            this.cbxDesenho.Name = "cbxDesenho";
            this.cbxDesenho.NM_Alias = "";
            this.cbxDesenho.NM_Campo = "desenho";
            this.cbxDesenho.NM_Param = "@P_TIPO MOVIMENTO";
            this.cbxDesenho.Size = new System.Drawing.Size(253, 21);
            this.cbxDesenho.ST_Gravar = true;
            this.cbxDesenho.ST_LimparCampo = true;
            this.cbxDesenho.ST_NotNull = false;
            this.cbxDesenho.TabIndex = 5;
            // 
            // lblCusto
            // 
            this.lblCusto.AutoSize = true;
            this.lblCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCusto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCusto.Location = new System.Drawing.Point(161, 131);
            this.lblCusto.Name = "lblCusto";
            this.lblCusto.Size = new System.Drawing.Size(37, 13);
            this.lblCusto.TabIndex = 574;
            this.lblCusto.Text = "Custo:";
            this.lblCusto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 570;
            this.label3.Text = "Estado:";
            // 
            // tp_estado
            // 
            this.tp_estado.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsPneu, "Tp_estado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_estado.FormattingEnabled = true;
            this.tp_estado.Location = new System.Drawing.Point(75, 97);
            this.tp_estado.Name = "tp_estado";
            this.tp_estado.NM_Alias = "";
            this.tp_estado.NM_Campo = "Tipo Estado";
            this.tp_estado.NM_Param = "@P_TIPO MOVIMENTO";
            this.tp_estado.Size = new System.Drawing.Size(212, 21);
            this.tp_estado.ST_Gravar = true;
            this.tp_estado.ST_LimparCampo = true;
            this.tp_estado.ST_NotNull = true;
            this.tp_estado.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(40, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 568;
            this.label2.Text = "Obs:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPneu, "DS_Observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(75, 155);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(564, 56);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 10;
            this.ds_observacao.TextOld = null;
            // 
            // Nr_serie
            // 
            this.Nr_serie.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_serie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPneu, "Nr_serie", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nr_serie.Location = new System.Drawing.Point(75, 129);
            this.Nr_serie.Name = "Nr_serie";
            this.Nr_serie.NM_Alias = "";
            this.Nr_serie.NM_Campo = "";
            this.Nr_serie.NM_CampoBusca = "";
            this.Nr_serie.NM_Param = "";
            this.Nr_serie.QTD_Zero = 0;
            this.Nr_serie.Size = new System.Drawing.Size(80, 20);
            this.Nr_serie.ST_AutoInc = false;
            this.Nr_serie.ST_DisableAuto = false;
            this.Nr_serie.ST_Float = false;
            this.Nr_serie.ST_Gravar = true;
            this.Nr_serie.ST_Int = false;
            this.Nr_serie.ST_LimpaCampo = true;
            this.Nr_serie.ST_NotNull = false;
            this.Nr_serie.ST_PrimaryKey = false;
            this.Nr_serie.TabIndex = 7;
            this.Nr_serie.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(21, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 565;
            this.label1.Text = "Nº Fogo:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPneu, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(195, 71);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "Produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_PRODUTO";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(444, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 564;
            this.ds_produto.TextOld = null;
            // 
            // bb_produto
            // 
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(161, 71);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 20);
            this.bb_produto.TabIndex = 3;
            this.bb_produto.UseVisualStyleBackColor = true;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(22, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 563;
            this.label7.Text = "Produto:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsPneu, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPneu, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(76, 15);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(563, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 0;
            this.cbEmpresa.Leave += new System.EventHandler(this.cbEmpresa_Leave);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(19, 18);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(51, 13);
            this.label37.TabIndex = 559;
            this.label37.Text = "Empresa:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFCadPneu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 262);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCadPneu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Pneu";
            this.Load += new System.EventHandler(this.TFPneu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFPneu_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPneu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCusto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button bb_produto;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.BindingSource bsPneu;
        private Componentes.EditDefault Nr_serie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault tp_estado;
        private System.Windows.Forms.Label lblCusto;
        private System.Windows.Forms.Label label4;
        private Componentes.ComboBoxDefault cbxDesenho;
        private System.Windows.Forms.Button BB_Novo_Desenho;
        private Componentes.CheckBoxDefault cbGerarAlmoxarifado;
        private Componentes.EditFloat edtCusto;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault ds_almoxarifado;
        private Componentes.EditDefault id_almox;
        private System.Windows.Forms.Button bb_almox;
        private Componentes.EditDefault edt_saldodisponivel;
        private System.Windows.Forms.Label label6;
    }
}