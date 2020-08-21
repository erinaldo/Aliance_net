namespace Commoditties
{
    partial class TFRoyaltiesGMO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRoyaltiesGMO));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.tp_gmo = new Componentes.EditDefault(this.components);
            this.bsRoyaltiesGMO = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.tp_lancto = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.qtd_credito = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_contrato = new System.Windows.Forms.Button();
            this.nr_contrato = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRoyaltiesGMO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_credito)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(609, 43);
            this.barraMenu.TabIndex = 12;
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
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
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
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.tp_gmo);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.tp_lancto);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.qtd_credito);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.Controls.Add(this.CD_Clifor);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.NM_Clifor);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.bb_contrato);
            this.pDados.Controls.Add(this.nr_contrato);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(609, 219);
            this.pDados.TabIndex = 13;
            // 
            // tp_gmo
            // 
            this.tp_gmo.BackColor = System.Drawing.SystemColors.Window;
            this.tp_gmo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_gmo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_gmo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRoyaltiesGMO, "Tipo_GMO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_gmo.Enabled = false;
            this.tp_gmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_gmo.Location = new System.Drawing.Point(290, 106);
            this.tp_gmo.Name = "tp_gmo";
            this.tp_gmo.NM_Alias = "";
            this.tp_gmo.NM_Campo = "NR_Contrato";
            this.tp_gmo.NM_CampoBusca = "NR_Contrato";
            this.tp_gmo.NM_Param = "@P_NR_CONTRATOP";
            this.tp_gmo.QTD_Zero = 0;
            this.tp_gmo.ReadOnly = true;
            this.tp_gmo.Size = new System.Drawing.Size(125, 20);
            this.tp_gmo.ST_AutoInc = false;
            this.tp_gmo.ST_DisableAuto = false;
            this.tp_gmo.ST_Float = false;
            this.tp_gmo.ST_Gravar = false;
            this.tp_gmo.ST_Int = false;
            this.tp_gmo.ST_LimpaCampo = true;
            this.tp_gmo.ST_NotNull = false;
            this.tp_gmo.ST_PrimaryKey = false;
            this.tp_gmo.TabIndex = 75;
            this.tp_gmo.TextOld = null;
            // 
            // bsRoyaltiesGMO
            // 
            this.bsRoyaltiesGMO.DataSource = typeof(CamadaDados.Graos.TList_LanRoyaltiesGMO);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(25, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 74;
            this.label10.Text = "Observação:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRoyaltiesGMO, "DS_Observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(99, 134);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(500, 75);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 4;
            this.ds_observacao.TextOld = null;
            // 
            // tp_lancto
            // 
            this.tp_lancto.BackColor = System.Drawing.SystemColors.Window;
            this.tp_lancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_lancto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRoyaltiesGMO, "Tipo_Lancto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_lancto.Enabled = false;
            this.tp_lancto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_lancto.Location = new System.Drawing.Point(494, 106);
            this.tp_lancto.Name = "tp_lancto";
            this.tp_lancto.NM_Alias = "";
            this.tp_lancto.NM_Campo = "NR_Contrato";
            this.tp_lancto.NM_CampoBusca = "NR_Contrato";
            this.tp_lancto.NM_Param = "@P_NR_CONTRATOP";
            this.tp_lancto.QTD_Zero = 0;
            this.tp_lancto.ReadOnly = true;
            this.tp_lancto.Size = new System.Drawing.Size(105, 20);
            this.tp_lancto.ST_AutoInc = false;
            this.tp_lancto.ST_DisableAuto = false;
            this.tp_lancto.ST_Float = false;
            this.tp_lancto.ST_Gravar = false;
            this.tp_lancto.ST_Int = false;
            this.tp_lancto.ST_LimpaCampo = true;
            this.tp_lancto.ST_NotNull = false;
            this.tp_lancto.ST_PrimaryKey = false;
            this.tp_lancto.TabIndex = 72;
            this.tp_lancto.TextOld = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(421, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 71;
            this.label9.Text = "Tipo Lancto:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(225, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 69;
            this.label8.Text = "Tipo GMO:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qtd_credito
            // 
            this.qtd_credito.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRoyaltiesGMO, "QTD_Credito", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_credito.DecimalPlaces = 3;
            this.qtd_credito.Location = new System.Drawing.Point(99, 107);
            this.qtd_credito.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_credito.Name = "qtd_credito";
            this.qtd_credito.NM_Alias = "";
            this.qtd_credito.NM_Campo = "";
            this.qtd_credito.NM_Param = "";
            this.qtd_credito.Operador = "";
            this.qtd_credito.Size = new System.Drawing.Size(120, 20);
            this.qtd_credito.ST_AutoInc = false;
            this.qtd_credito.ST_DisableAuto = false;
            this.qtd_credito.ST_Gravar = true;
            this.qtd_credito.ST_LimparCampo = true;
            this.qtd_credito.ST_NotNull = true;
            this.qtd_credito.ST_PrimaryKey = false;
            this.qtd_credito.TabIndex = 2;
            this.qtd_credito.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(27, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Qtd. Credito:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(178, 30);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(421, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 56;
            this.NM_Empresa.TextOld = null;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Enabled = false;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(99, 30);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(74, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = true;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 55;
            this.CD_Empresa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(42, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(46, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "Produto:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRoyaltiesGMO, "DS_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Enabled = false;
            this.DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Produto.Location = new System.Drawing.Point(177, 81);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.ReadOnly = true;
            this.DS_Produto.Size = new System.Drawing.Size(422, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 62;
            this.DS_Produto.TextOld = null;
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRoyaltiesGMO, "CD_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Produto.Location = new System.Drawing.Point(99, 81);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(74, 20);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = true;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 52;
            this.CD_Produto.TextOld = null;
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRoyaltiesGMO, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Clifor.Enabled = false;
            this.CD_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Clifor.Location = new System.Drawing.Point(99, 55);
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.ReadOnly = true;
            this.CD_Clifor.Size = new System.Drawing.Size(74, 20);
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = false;
            this.CD_Clifor.ST_Int = false;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = false;
            this.CD_Clifor.ST_PrimaryKey = false;
            this.CD_Clifor.TabIndex = 57;
            this.CD_Clifor.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(10, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Cliente/Fornec.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRoyaltiesGMO, "nm_Clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Clifor.Enabled = false;
            this.NM_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Clifor.Location = new System.Drawing.Point(177, 55);
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "NM_Clifor";
            this.NM_Clifor.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.ReadOnly = true;
            this.NM_Clifor.Size = new System.Drawing.Size(422, 20);
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = false;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TabIndex = 58;
            this.NM_Clifor.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(28, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Nº Contrato:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_contrato
            // 
            this.bb_contrato.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contrato.Image = ((System.Drawing.Image)(resources.GetObject("bb_contrato.Image")));
            this.bb_contrato.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contrato.Location = new System.Drawing.Point(176, 6);
            this.bb_contrato.Name = "bb_contrato";
            this.bb_contrato.Size = new System.Drawing.Size(28, 19);
            this.bb_contrato.TabIndex = 1;
            this.bb_contrato.UseVisualStyleBackColor = false;
            this.bb_contrato.Click += new System.EventHandler(this.BB_Pedido_Click);
            // 
            // nr_contrato
            // 
            this.nr_contrato.BackColor = System.Drawing.SystemColors.Window;
            this.nr_contrato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_contrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_contrato.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRoyaltiesGMO, "Nr_Contratostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_contrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nr_contrato.Location = new System.Drawing.Point(99, 6);
            this.nr_contrato.Name = "nr_contrato";
            this.nr_contrato.NM_Alias = "";
            this.nr_contrato.NM_Campo = "nr_contrato";
            this.nr_contrato.NM_CampoBusca = "nr_contrato";
            this.nr_contrato.NM_Param = "@P_NR_CONTRATO";
            this.nr_contrato.QTD_Zero = 0;
            this.nr_contrato.Size = new System.Drawing.Size(74, 20);
            this.nr_contrato.ST_AutoInc = false;
            this.nr_contrato.ST_DisableAuto = false;
            this.nr_contrato.ST_Float = true;
            this.nr_contrato.ST_Gravar = true;
            this.nr_contrato.ST_Int = true;
            this.nr_contrato.ST_LimpaCampo = true;
            this.nr_contrato.ST_NotNull = true;
            this.nr_contrato.ST_PrimaryKey = false;
            this.nr_contrato.TabIndex = 0;
            this.nr_contrato.TextOld = null;
            this.nr_contrato.Leave += new System.EventHandler(this.NR_Pedido_Leave);
            // 
            // TFRoyaltiesGMO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 262);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFRoyaltiesGMO";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento Credito Royalties GMO";
            this.Load += new System.EventHandler(this.TFRoyaltiesGMO_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFRoyaltiesGMO_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRoyaltiesGMO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_credito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault DS_Produto;
        private Componentes.EditDefault CD_Produto;
        private Componentes.EditDefault CD_Clifor;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault NM_Clifor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_contrato;
        private Componentes.EditDefault nr_contrato;
        private Componentes.EditFloat qtd_credito;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault ds_observacao;
        private Componentes.EditDefault tp_lancto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bsRoyaltiesGMO;
        private Componentes.EditDefault tp_gmo;
    }
}