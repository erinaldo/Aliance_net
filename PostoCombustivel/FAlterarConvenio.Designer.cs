namespace PostoCombustivel
{
    partial class TFAlterarConvenio
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
            System.Windows.Forms.Label qt_dias_desdobroLabel;
            System.Windows.Forms.Label qt_parcelasLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAlterarConvenio));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.qt_dias_desdobro = new Componentes.EditFloat(this.components);
            this.bsConvenio = new System.Windows.Forms.BindingSource(this.components);
            this.qt_parcelas = new Componentes.EditFloat(this.components);
            this.diasemana = new Componentes.ComboBoxDefault(this.components);
            this.lblSemana = new System.Windows.Forms.Label();
            this.st_utilizardiascondpgto = new Componentes.CheckBoxDefault(this.components);
            this.periodofatura = new Componentes.ComboBoxDefault(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.qtd_duppendente = new Componentes.EditFloat(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.DS_convenio = new Componentes.EditDefault(this.components);
            this.st_descvlunit = new Componentes.CheckBoxDefault(this.components);
            this.tp_acresdesc = new Componentes.ComboBoxDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.diafechamentofat = new Componentes.EditFloat(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.diavencto = new Componentes.EditFloat(this.components);
            this.tp_desconto = new Componentes.ComboBoxDefault(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.desconto = new Componentes.EditFloat(this.components);
            this.ds_condpgto = new Componentes.EditDefault(this.components);
            this.bb_condpgto = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cd_condpgto = new Componentes.EditDefault(this.components);
            this.ds_tpdocto = new Componentes.EditDefault(this.components);
            this.bb_tpdocto = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tp_docto = new Componentes.EditDefault(this.components);
            this.ds_tpduplicata = new Componentes.EditDefault(this.components);
            this.bb_tpduplicata = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tp_duplicata = new Componentes.EditDefault(this.components);
            this.ds_portador = new Componentes.EditDefault(this.components);
            this.bb_portador = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_portador = new Componentes.EditDefault(this.components);
            this.st_registro = new Componentes.ComboBoxDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.diasvalidade = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dt_convenio = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            qt_dias_desdobroLabel = new System.Windows.Forms.Label();
            qt_parcelasLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qt_dias_desdobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConvenio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_parcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_duppendente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diafechamentofat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diavencto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.desconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasvalidade)).BeginInit();
            this.SuspendLayout();
            // 
            // qt_dias_desdobroLabel
            // 
            qt_dias_desdobroLabel.AutoSize = true;
            qt_dias_desdobroLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            qt_dias_desdobroLabel.Location = new System.Drawing.Point(572, 111);
            qt_dias_desdobroLabel.Name = "qt_dias_desdobroLabel";
            qt_dias_desdobroLabel.Size = new System.Drawing.Size(77, 13);
            qt_dias_desdobroLabel.TabIndex = 455;
            qt_dias_desdobroLabel.Text = "Nº Dias Desd.:";
            // 
            // qt_parcelasLabel
            // 
            qt_parcelasLabel.AutoSize = true;
            qt_parcelasLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            qt_parcelasLabel.Location = new System.Drawing.Point(699, 111);
            qt_parcelasLabel.Name = "qt_parcelasLabel";
            qt_parcelasLabel.Size = new System.Drawing.Size(66, 13);
            qt_parcelasLabel.TabIndex = 457;
            qt_parcelasLabel.Text = "Nº Parcelas:";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(818, 43);
            this.barraMenu.TabIndex = 12;
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
            this.pDados.Controls.Add(this.qt_dias_desdobro);
            this.pDados.Controls.Add(qt_dias_desdobroLabel);
            this.pDados.Controls.Add(this.qt_parcelas);
            this.pDados.Controls.Add(qt_parcelasLabel);
            this.pDados.Controls.Add(this.diasemana);
            this.pDados.Controls.Add(this.lblSemana);
            this.pDados.Controls.Add(this.st_utilizardiascondpgto);
            this.pDados.Controls.Add(this.periodofatura);
            this.pDados.Controls.Add(this.label19);
            this.pDados.Controls.Add(this.qtd_duppendente);
            this.pDados.Controls.Add(this.label17);
            this.pDados.Controls.Add(this.label15);
            this.pDados.Controls.Add(this.DS_convenio);
            this.pDados.Controls.Add(this.st_descvlunit);
            this.pDados.Controls.Add(this.tp_acresdesc);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.label14);
            this.pDados.Controls.Add(this.diafechamentofat);
            this.pDados.Controls.Add(this.label13);
            this.pDados.Controls.Add(this.diavencto);
            this.pDados.Controls.Add(this.tp_desconto);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(this.label12);
            this.pDados.Controls.Add(this.desconto);
            this.pDados.Controls.Add(this.ds_condpgto);
            this.pDados.Controls.Add(this.bb_condpgto);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.cd_condpgto);
            this.pDados.Controls.Add(this.ds_tpdocto);
            this.pDados.Controls.Add(this.bb_tpdocto);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.tp_docto);
            this.pDados.Controls.Add(this.ds_tpduplicata);
            this.pDados.Controls.Add(this.bb_tpduplicata);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.tp_duplicata);
            this.pDados.Controls.Add(this.ds_portador);
            this.pDados.Controls.Add(this.bb_portador);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_portador);
            this.pDados.Controls.Add(this.st_registro);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.diasvalidade);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.dt_convenio);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(818, 313);
            this.pDados.TabIndex = 13;
            // 
            // qt_dias_desdobro
            // 
            this.qt_dias_desdobro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsConvenio, "Qt_diasdesdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qt_dias_desdobro.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qt_dias_desdobro.Location = new System.Drawing.Point(648, 108);
            this.qt_dias_desdobro.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.qt_dias_desdobro.Name = "qt_dias_desdobro";
            this.qt_dias_desdobro.NM_Alias = "";
            this.qt_dias_desdobro.NM_Campo = "qt_dias_desdobro";
            this.qt_dias_desdobro.NM_Param = "@P_QT_DIAS_DESDOBRO";
            this.qt_dias_desdobro.Operador = "";
            this.qt_dias_desdobro.ReadOnly = true;
            this.qt_dias_desdobro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.qt_dias_desdobro.Size = new System.Drawing.Size(45, 20);
            this.qt_dias_desdobro.ST_AutoInc = false;
            this.qt_dias_desdobro.ST_DisableAuto = false;
            this.qt_dias_desdobro.ST_Gravar = false;
            this.qt_dias_desdobro.ST_LimparCampo = true;
            this.qt_dias_desdobro.ST_NotNull = false;
            this.qt_dias_desdobro.ST_PrimaryKey = false;
            this.qt_dias_desdobro.TabIndex = 456;
            this.qt_dias_desdobro.TabStop = false;
            this.qt_dias_desdobro.ThousandsSeparator = true;
            // 
            // bsConvenio
            // 
            this.bsConvenio.DataSource = typeof(CamadaDados.PostoCombustivel.TList_Convenio);
            // 
            // qt_parcelas
            // 
            this.qt_parcelas.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsConvenio, "Qt_parcelas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qt_parcelas.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qt_parcelas.Location = new System.Drawing.Point(764, 108);
            this.qt_parcelas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.qt_parcelas.Name = "qt_parcelas";
            this.qt_parcelas.NM_Alias = "";
            this.qt_parcelas.NM_Campo = "qt_parcelas";
            this.qt_parcelas.NM_Param = "@P_QT_PARCELAS";
            this.qt_parcelas.Operador = "";
            this.qt_parcelas.ReadOnly = true;
            this.qt_parcelas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.qt_parcelas.Size = new System.Drawing.Size(45, 20);
            this.qt_parcelas.ST_AutoInc = false;
            this.qt_parcelas.ST_DisableAuto = false;
            this.qt_parcelas.ST_Gravar = false;
            this.qt_parcelas.ST_LimparCampo = true;
            this.qt_parcelas.ST_NotNull = false;
            this.qt_parcelas.ST_PrimaryKey = false;
            this.qt_parcelas.TabIndex = 458;
            this.qt_parcelas.TabStop = false;
            this.qt_parcelas.ThousandsSeparator = true;
            // 
            // diasemana
            // 
            this.diasemana.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsConvenio, "Diasemanastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.diasemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diasemana.FormattingEnabled = true;
            this.diasemana.Location = new System.Drawing.Point(317, 134);
            this.diasemana.Name = "diasemana";
            this.diasemana.NM_Alias = "";
            this.diasemana.NM_Campo = "";
            this.diasemana.NM_Param = "";
            this.diasemana.Size = new System.Drawing.Size(155, 21);
            this.diasemana.ST_Gravar = false;
            this.diasemana.ST_LimparCampo = true;
            this.diasemana.ST_NotNull = false;
            this.diasemana.TabIndex = 10;
            // 
            // lblSemana
            // 
            this.lblSemana.AutoSize = true;
            this.lblSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSemana.Location = new System.Drawing.Point(231, 137);
            this.lblSemana.Name = "lblSemana";
            this.lblSemana.Size = new System.Drawing.Size(80, 13);
            this.lblSemana.TabIndex = 450;
            this.lblSemana.Text = "Iniciar Semana:";
            this.lblSemana.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // st_utilizardiascondpgto
            // 
            this.st_utilizardiascondpgto.AutoSize = true;
            this.st_utilizardiascondpgto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.st_utilizardiascondpgto.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsConvenio, "St_utilizardiascondpgtobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_utilizardiascondpgto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_utilizardiascondpgto.Location = new System.Drawing.Point(478, 136);
            this.st_utilizardiascondpgto.Name = "st_utilizardiascondpgto";
            this.st_utilizardiascondpgto.NM_Alias = "";
            this.st_utilizardiascondpgto.NM_Campo = "";
            this.st_utilizardiascondpgto.NM_Param = "";
            this.st_utilizardiascondpgto.Size = new System.Drawing.Size(331, 17);
            this.st_utilizardiascondpgto.ST_Gravar = false;
            this.st_utilizardiascondpgto.ST_LimparCampo = true;
            this.st_utilizardiascondpgto.ST_NotNull = false;
            this.st_utilizardiascondpgto.TabIndex = 11;
            this.st_utilizardiascondpgto.Text = "Utilizar Condição Pagamento no vencimento da fatura";
            this.st_utilizardiascondpgto.UseVisualStyleBackColor = true;
            this.st_utilizardiascondpgto.Vl_False = "";
            this.st_utilizardiascondpgto.Vl_True = "";
            // 
            // periodofatura
            // 
            this.periodofatura.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsConvenio, "Periodofatura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.periodofatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodofatura.FormattingEnabled = true;
            this.periodofatura.Location = new System.Drawing.Point(92, 134);
            this.periodofatura.Name = "periodofatura";
            this.periodofatura.NM_Alias = "";
            this.periodofatura.NM_Campo = "";
            this.periodofatura.NM_Param = "";
            this.periodofatura.Size = new System.Drawing.Size(136, 21);
            this.periodofatura.ST_Gravar = true;
            this.periodofatura.ST_LimparCampo = true;
            this.periodofatura.ST_NotNull = false;
            this.periodofatura.TabIndex = 9;
            this.periodofatura.SelectedIndexChanged += new System.EventHandler(this.periodofatura_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(19, 137);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 449;
            this.label19.Text = "Periodo Fat.:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qtd_duppendente
            // 
            this.qtd_duppendente.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsConvenio, "Qtd_duppendente", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_duppendente.Location = new System.Drawing.Point(751, 161);
            this.qtd_duppendente.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.qtd_duppendente.Name = "qtd_duppendente";
            this.qtd_duppendente.NM_Alias = "";
            this.qtd_duppendente.NM_Campo = "";
            this.qtd_duppendente.NM_Param = "";
            this.qtd_duppendente.Operador = "";
            this.qtd_duppendente.Size = new System.Drawing.Size(58, 20);
            this.qtd_duppendente.ST_AutoInc = false;
            this.qtd_duppendente.ST_DisableAuto = false;
            this.qtd_duppendente.ST_Gravar = false;
            this.qtd_duppendente.ST_LimparCampo = true;
            this.qtd_duppendente.ST_NotNull = false;
            this.qtd_duppendente.ST_PrimaryKey = false;
            this.qtd_duppendente.TabIndex = 15;
            this.qtd_duppendente.ThousandsSeparator = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(640, 164);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 13);
            this.label17.TabIndex = 445;
            this.label17.Text = "Qtd. Dup. Pendente:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(31, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 444;
            this.label15.Text = "Descrição";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_convenio
            // 
            this.DS_convenio.BackColor = System.Drawing.SystemColors.Window;
            this.DS_convenio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_convenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_convenio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConvenio, "DS_convenio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_convenio.Location = new System.Drawing.Point(92, 30);
            this.DS_convenio.Name = "DS_convenio";
            this.DS_convenio.NM_Alias = "";
            this.DS_convenio.NM_Campo = "";
            this.DS_convenio.NM_CampoBusca = "";
            this.DS_convenio.NM_Param = "";
            this.DS_convenio.QTD_Zero = 0;
            this.DS_convenio.Size = new System.Drawing.Size(717, 20);
            this.DS_convenio.ST_AutoInc = false;
            this.DS_convenio.ST_DisableAuto = false;
            this.DS_convenio.ST_Float = false;
            this.DS_convenio.ST_Gravar = false;
            this.DS_convenio.ST_Int = false;
            this.DS_convenio.ST_LimpaCampo = true;
            this.DS_convenio.ST_NotNull = false;
            this.DS_convenio.ST_PrimaryKey = false;
            this.DS_convenio.TabIndex = 2;
            this.DS_convenio.TextOld = null;
            // 
            // st_descvlunit
            // 
            this.st_descvlunit.AutoSize = true;
            this.st_descvlunit.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsConvenio, "St_descvlunitbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_descvlunit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_descvlunit.Location = new System.Drawing.Point(648, 190);
            this.st_descvlunit.Name = "st_descvlunit";
            this.st_descvlunit.NM_Alias = "";
            this.st_descvlunit.NM_Campo = "";
            this.st_descvlunit.NM_Param = "";
            this.st_descvlunit.Size = new System.Drawing.Size(161, 17);
            this.st_descvlunit.ST_Gravar = false;
            this.st_descvlunit.ST_LimparCampo = true;
            this.st_descvlunit.ST_NotNull = false;
            this.st_descvlunit.TabIndex = 19;
            this.st_descvlunit.Text = "Desconto Valor Unitario";
            this.st_descvlunit.UseVisualStyleBackColor = true;
            this.st_descvlunit.Vl_False = "";
            this.st_descvlunit.Vl_True = "";
            // 
            // tp_acresdesc
            // 
            this.tp_acresdesc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsConvenio, "Tp_acresdesc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_acresdesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_acresdesc.FormattingEnabled = true;
            this.tp_acresdesc.Location = new System.Drawing.Point(92, 188);
            this.tp_acresdesc.Name = "tp_acresdesc";
            this.tp_acresdesc.NM_Alias = "";
            this.tp_acresdesc.NM_Campo = "";
            this.tp_acresdesc.NM_Param = "";
            this.tp_acresdesc.Size = new System.Drawing.Size(200, 21);
            this.tp_acresdesc.ST_Gravar = true;
            this.tp_acresdesc.ST_LimparCampo = true;
            this.tp_acresdesc.ST_NotNull = false;
            this.tp_acresdesc.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(19, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 438;
            this.label1.Text = "Acres/Desc:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(156, 217);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 13);
            this.label14.TabIndex = 436;
            this.label14.Text = "Fechar Fatura todo dia:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diafechamentofat
            // 
            this.diafechamentofat.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsConvenio, "DiaFechamentoFat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.diafechamentofat.Location = new System.Drawing.Point(279, 215);
            this.diafechamentofat.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.diafechamentofat.Name = "diafechamentofat";
            this.diafechamentofat.NM_Alias = "";
            this.diafechamentofat.NM_Campo = "";
            this.diafechamentofat.NM_Param = "";
            this.diafechamentofat.Operador = "";
            this.diafechamentofat.Size = new System.Drawing.Size(47, 20);
            this.diafechamentofat.ST_AutoInc = false;
            this.diafechamentofat.ST_DisableAuto = false;
            this.diafechamentofat.ST_Gravar = true;
            this.diafechamentofat.ST_LimparCampo = true;
            this.diafechamentofat.ST_NotNull = false;
            this.diafechamentofat.ST_PrimaryKey = false;
            this.diafechamentofat.TabIndex = 21;
            this.diafechamentofat.ThousandsSeparator = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(25, 217);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 434;
            this.label13.Text = "Vencto dia:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diavencto
            // 
            this.diavencto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsConvenio, "Diavencto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.diavencto.Location = new System.Drawing.Point(92, 215);
            this.diavencto.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.diavencto.Name = "diavencto";
            this.diavencto.NM_Alias = "";
            this.diavencto.NM_Campo = "";
            this.diavencto.NM_Param = "";
            this.diavencto.Operador = "";
            this.diavencto.Size = new System.Drawing.Size(58, 20);
            this.diavencto.ST_AutoInc = false;
            this.diavencto.ST_DisableAuto = false;
            this.diavencto.ST_Gravar = true;
            this.diavencto.ST_LimparCampo = true;
            this.diavencto.ST_NotNull = false;
            this.diavencto.ST_PrimaryKey = false;
            this.diavencto.TabIndex = 20;
            this.diavencto.ThousandsSeparator = true;
            // 
            // tp_desconto
            // 
            this.tp_desconto.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsConvenio, "Tp_desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_desconto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_desconto.FormattingEnabled = true;
            this.tp_desconto.Location = new System.Drawing.Point(472, 188);
            this.tp_desconto.Name = "tp_desconto";
            this.tp_desconto.NM_Alias = "";
            this.tp_desconto.NM_Campo = "";
            this.tp_desconto.NM_Param = "";
            this.tp_desconto.Size = new System.Drawing.Size(162, 21);
            this.tp_desconto.ST_Gravar = true;
            this.tp_desconto.ST_LimparCampo = true;
            this.tp_desconto.ST_NotNull = false;
            this.tp_desconto.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(408, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 432;
            this.label11.Text = "Tipo Valor:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(298, 191);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 431;
            this.label12.Text = "Valor:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // desconto
            // 
            this.desconto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsConvenio, "Desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.desconto.DecimalPlaces = 2;
            this.desconto.Location = new System.Drawing.Point(338, 188);
            this.desconto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.desconto.Name = "desconto";
            this.desconto.NM_Alias = "";
            this.desconto.NM_Campo = "";
            this.desconto.NM_Param = "";
            this.desconto.Operador = "";
            this.desconto.Size = new System.Drawing.Size(64, 20);
            this.desconto.ST_AutoInc = false;
            this.desconto.ST_DisableAuto = false;
            this.desconto.ST_Gravar = true;
            this.desconto.ST_LimparCampo = true;
            this.desconto.ST_NotNull = false;
            this.desconto.ST_PrimaryKey = false;
            this.desconto.TabIndex = 17;
            this.desconto.ThousandsSeparator = true;
            // 
            // ds_condpgto
            // 
            this.ds_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConvenio, "Ds_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_condpgto.Enabled = false;
            this.ds_condpgto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_condpgto.Location = new System.Drawing.Point(200, 108);
            this.ds_condpgto.Name = "ds_condpgto";
            this.ds_condpgto.NM_Alias = "";
            this.ds_condpgto.NM_Campo = "ds_condpgto";
            this.ds_condpgto.NM_CampoBusca = "ds_condpgto";
            this.ds_condpgto.NM_Param = "@P_NM_EMPRESA";
            this.ds_condpgto.QTD_Zero = 0;
            this.ds_condpgto.ReadOnly = true;
            this.ds_condpgto.Size = new System.Drawing.Size(366, 20);
            this.ds_condpgto.ST_AutoInc = false;
            this.ds_condpgto.ST_DisableAuto = false;
            this.ds_condpgto.ST_Float = false;
            this.ds_condpgto.ST_Gravar = false;
            this.ds_condpgto.ST_Int = false;
            this.ds_condpgto.ST_LimpaCampo = true;
            this.ds_condpgto.ST_NotNull = false;
            this.ds_condpgto.ST_PrimaryKey = false;
            this.ds_condpgto.TabIndex = 428;
            this.ds_condpgto.TextOld = null;
            // 
            // bb_condpgto
            // 
            this.bb_condpgto.Image = ((System.Drawing.Image)(resources.GetObject("bb_condpgto.Image")));
            this.bb_condpgto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_condpgto.Location = new System.Drawing.Point(169, 108);
            this.bb_condpgto.Name = "bb_condpgto";
            this.bb_condpgto.Size = new System.Drawing.Size(28, 20);
            this.bb_condpgto.TabIndex = 8;
            this.bb_condpgto.UseVisualStyleBackColor = true;
            this.bb_condpgto.Click += new System.EventHandler(this.bb_condpgto_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(23, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 427;
            this.label7.Text = "Cond. Pgto:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_condpgto
            // 
            this.cd_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConvenio, "Cd_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_condpgto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_condpgto.Location = new System.Drawing.Point(92, 108);
            this.cd_condpgto.Name = "cd_condpgto";
            this.cd_condpgto.NM_Alias = "";
            this.cd_condpgto.NM_Campo = "cd_condpgto";
            this.cd_condpgto.NM_CampoBusca = "cd_condpgto";
            this.cd_condpgto.NM_Param = "@P_CD_EMPRESA";
            this.cd_condpgto.QTD_Zero = 0;
            this.cd_condpgto.Size = new System.Drawing.Size(75, 20);
            this.cd_condpgto.ST_AutoInc = false;
            this.cd_condpgto.ST_DisableAuto = false;
            this.cd_condpgto.ST_Float = false;
            this.cd_condpgto.ST_Gravar = true;
            this.cd_condpgto.ST_Int = true;
            this.cd_condpgto.ST_LimpaCampo = true;
            this.cd_condpgto.ST_NotNull = false;
            this.cd_condpgto.ST_PrimaryKey = false;
            this.cd_condpgto.TabIndex = 7;
            this.cd_condpgto.TextOld = null;
            this.cd_condpgto.Leave += new System.EventHandler(this.cd_condpgto_Leave);
            // 
            // ds_tpdocto
            // 
            this.ds_tpdocto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpdocto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpdocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpdocto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConvenio, "Ds_tpdocto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpdocto.Enabled = false;
            this.ds_tpdocto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tpdocto.Location = new System.Drawing.Point(200, 82);
            this.ds_tpdocto.Name = "ds_tpdocto";
            this.ds_tpdocto.NM_Alias = "";
            this.ds_tpdocto.NM_Campo = "ds_tpdocto";
            this.ds_tpdocto.NM_CampoBusca = "ds_tpdocto";
            this.ds_tpdocto.NM_Param = "@P_NM_EMPRESA";
            this.ds_tpdocto.QTD_Zero = 0;
            this.ds_tpdocto.ReadOnly = true;
            this.ds_tpdocto.Size = new System.Drawing.Size(609, 20);
            this.ds_tpdocto.ST_AutoInc = false;
            this.ds_tpdocto.ST_DisableAuto = false;
            this.ds_tpdocto.ST_Float = false;
            this.ds_tpdocto.ST_Gravar = false;
            this.ds_tpdocto.ST_Int = false;
            this.ds_tpdocto.ST_LimpaCampo = true;
            this.ds_tpdocto.ST_NotNull = false;
            this.ds_tpdocto.ST_PrimaryKey = false;
            this.ds_tpdocto.TabIndex = 426;
            this.ds_tpdocto.TextOld = null;
            // 
            // bb_tpdocto
            // 
            this.bb_tpdocto.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpdocto.Image")));
            this.bb_tpdocto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpdocto.Location = new System.Drawing.Point(169, 82);
            this.bb_tpdocto.Name = "bb_tpdocto";
            this.bb_tpdocto.Size = new System.Drawing.Size(28, 19);
            this.bb_tpdocto.TabIndex = 6;
            this.bb_tpdocto.UseVisualStyleBackColor = true;
            this.bb_tpdocto.Click += new System.EventHandler(this.bb_tpdocto_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(4, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 425;
            this.label9.Text = "TP. Documento";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_docto
            // 
            this.tp_docto.BackColor = System.Drawing.SystemColors.Window;
            this.tp_docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_docto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConvenio, "Tp_doctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_docto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_docto.Location = new System.Drawing.Point(92, 82);
            this.tp_docto.Name = "tp_docto";
            this.tp_docto.NM_Alias = "";
            this.tp_docto.NM_Campo = "tp_docto";
            this.tp_docto.NM_CampoBusca = "tp_docto";
            this.tp_docto.NM_Param = "@P_CD_EMPRESA";
            this.tp_docto.QTD_Zero = 0;
            this.tp_docto.Size = new System.Drawing.Size(75, 20);
            this.tp_docto.ST_AutoInc = false;
            this.tp_docto.ST_DisableAuto = false;
            this.tp_docto.ST_Float = false;
            this.tp_docto.ST_Gravar = true;
            this.tp_docto.ST_Int = true;
            this.tp_docto.ST_LimpaCampo = true;
            this.tp_docto.ST_NotNull = false;
            this.tp_docto.ST_PrimaryKey = false;
            this.tp_docto.TabIndex = 5;
            this.tp_docto.TextOld = null;
            this.tp_docto.Leave += new System.EventHandler(this.tp_docto_Leave);
            // 
            // ds_tpduplicata
            // 
            this.ds_tpduplicata.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpduplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpduplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpduplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConvenio, "Ds_tpduplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpduplicata.Enabled = false;
            this.ds_tpduplicata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tpduplicata.Location = new System.Drawing.Point(200, 56);
            this.ds_tpduplicata.Name = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Alias = "";
            this.ds_tpduplicata.NM_Campo = "ds_tpduplicata";
            this.ds_tpduplicata.NM_CampoBusca = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Param = "@P_NM_EMPRESA";
            this.ds_tpduplicata.QTD_Zero = 0;
            this.ds_tpduplicata.ReadOnly = true;
            this.ds_tpduplicata.Size = new System.Drawing.Size(609, 20);
            this.ds_tpduplicata.ST_AutoInc = false;
            this.ds_tpduplicata.ST_DisableAuto = false;
            this.ds_tpduplicata.ST_Float = false;
            this.ds_tpduplicata.ST_Gravar = false;
            this.ds_tpduplicata.ST_Int = false;
            this.ds_tpduplicata.ST_LimpaCampo = true;
            this.ds_tpduplicata.ST_NotNull = false;
            this.ds_tpduplicata.ST_PrimaryKey = false;
            this.ds_tpduplicata.TabIndex = 424;
            this.ds_tpduplicata.TextOld = null;
            // 
            // bb_tpduplicata
            // 
            this.bb_tpduplicata.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpduplicata.Image")));
            this.bb_tpduplicata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpduplicata.Location = new System.Drawing.Point(169, 56);
            this.bb_tpduplicata.Name = "bb_tpduplicata";
            this.bb_tpduplicata.Size = new System.Drawing.Size(28, 19);
            this.bb_tpduplicata.TabIndex = 4;
            this.bb_tpduplicata.UseVisualStyleBackColor = true;
            this.bb_tpduplicata.Click += new System.EventHandler(this.bb_tpduplicata_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(10, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 423;
            this.label10.Text = "Tipo Duplicata";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_duplicata
            // 
            this.tp_duplicata.BackColor = System.Drawing.SystemColors.Window;
            this.tp_duplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_duplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_duplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConvenio, "Tp_duplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_duplicata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_duplicata.Location = new System.Drawing.Point(92, 56);
            this.tp_duplicata.Name = "tp_duplicata";
            this.tp_duplicata.NM_Alias = "";
            this.tp_duplicata.NM_Campo = "tp_duplicata";
            this.tp_duplicata.NM_CampoBusca = "tp_duplicata";
            this.tp_duplicata.NM_Param = "@P_CD_EMPRESA";
            this.tp_duplicata.QTD_Zero = 0;
            this.tp_duplicata.Size = new System.Drawing.Size(75, 20);
            this.tp_duplicata.ST_AutoInc = false;
            this.tp_duplicata.ST_DisableAuto = false;
            this.tp_duplicata.ST_Float = false;
            this.tp_duplicata.ST_Gravar = true;
            this.tp_duplicata.ST_Int = true;
            this.tp_duplicata.ST_LimpaCampo = true;
            this.tp_duplicata.ST_NotNull = false;
            this.tp_duplicata.ST_PrimaryKey = false;
            this.tp_duplicata.TabIndex = 3;
            this.tp_duplicata.TextOld = null;
            this.tp_duplicata.Leave += new System.EventHandler(this.tp_duplicata_Leave);
            // 
            // ds_portador
            // 
            this.ds_portador.BackColor = System.Drawing.SystemColors.Window;
            this.ds_portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConvenio, "Ds_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_portador.Enabled = false;
            this.ds_portador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_portador.Location = new System.Drawing.Point(200, 5);
            this.ds_portador.Name = "ds_portador";
            this.ds_portador.NM_Alias = "";
            this.ds_portador.NM_Campo = "ds_portador";
            this.ds_portador.NM_CampoBusca = "ds_portador";
            this.ds_portador.NM_Param = "@P_NM_EMPRESA";
            this.ds_portador.QTD_Zero = 0;
            this.ds_portador.ReadOnly = true;
            this.ds_portador.Size = new System.Drawing.Size(609, 20);
            this.ds_portador.ST_AutoInc = false;
            this.ds_portador.ST_DisableAuto = false;
            this.ds_portador.ST_Float = false;
            this.ds_portador.ST_Gravar = false;
            this.ds_portador.ST_Int = false;
            this.ds_portador.ST_LimpaCampo = true;
            this.ds_portador.ST_NotNull = false;
            this.ds_portador.ST_PrimaryKey = false;
            this.ds_portador.TabIndex = 416;
            this.ds_portador.TextOld = null;
            // 
            // bb_portador
            // 
            this.bb_portador.Image = ((System.Drawing.Image)(resources.GetObject("bb_portador.Image")));
            this.bb_portador.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_portador.Location = new System.Drawing.Point(169, 5);
            this.bb_portador.Name = "bb_portador";
            this.bb_portador.Size = new System.Drawing.Size(28, 19);
            this.bb_portador.TabIndex = 1;
            this.bb_portador.UseVisualStyleBackColor = true;
            this.bb_portador.Click += new System.EventHandler(this.bb_portador_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(36, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 415;
            this.label2.Text = "Portador:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_portador
            // 
            this.cd_portador.BackColor = System.Drawing.SystemColors.Window;
            this.cd_portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConvenio, "Cd_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_portador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_portador.Location = new System.Drawing.Point(92, 5);
            this.cd_portador.Name = "cd_portador";
            this.cd_portador.NM_Alias = "";
            this.cd_portador.NM_Campo = "cd_portador";
            this.cd_portador.NM_CampoBusca = "cd_portador";
            this.cd_portador.NM_Param = "@P_CD_EMPRESA";
            this.cd_portador.QTD_Zero = 0;
            this.cd_portador.Size = new System.Drawing.Size(75, 20);
            this.cd_portador.ST_AutoInc = false;
            this.cd_portador.ST_DisableAuto = false;
            this.cd_portador.ST_Float = false;
            this.cd_portador.ST_Gravar = true;
            this.cd_portador.ST_Int = true;
            this.cd_portador.ST_LimpaCampo = true;
            this.cd_portador.ST_NotNull = false;
            this.cd_portador.ST_PrimaryKey = false;
            this.cd_portador.TabIndex = 0;
            this.cd_portador.TextOld = null;
            this.cd_portador.Leave += new System.EventHandler(this.cd_portador_Leave);
            // 
            // st_registro
            // 
            this.st_registro.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsConvenio, "St_registro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_registro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.st_registro.FormattingEnabled = true;
            this.st_registro.Location = new System.Drawing.Point(360, 161);
            this.st_registro.Name = "st_registro";
            this.st_registro.NM_Alias = "";
            this.st_registro.NM_Campo = "";
            this.st_registro.NM_Param = "";
            this.st_registro.Size = new System.Drawing.Size(274, 21);
            this.st_registro.ST_Gravar = true;
            this.st_registro.ST_LimparCampo = true;
            this.st_registro.ST_NotNull = false;
            this.st_registro.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(314, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 412;
            this.label6.Text = "Status:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(18, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 411;
            this.label5.Text = "Observação:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConvenio, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(92, 241);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(717, 63);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 23;
            this.ds_observacao.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(282, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 409;
            this.label4.Text = "dias";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diasvalidade
            // 
            this.diasvalidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsConvenio, "Diasvalidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.diasvalidade.Location = new System.Drawing.Point(231, 162);
            this.diasvalidade.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.diasvalidade.Name = "diasvalidade";
            this.diasvalidade.NM_Alias = "";
            this.diasvalidade.NM_Campo = "";
            this.diasvalidade.NM_Param = "";
            this.diasvalidade.Operador = "";
            this.diasvalidade.Size = new System.Drawing.Size(45, 20);
            this.diasvalidade.ST_AutoInc = false;
            this.diasvalidade.ST_DisableAuto = false;
            this.diasvalidade.ST_Gravar = false;
            this.diasvalidade.ST_LimparCampo = true;
            this.diasvalidade.ST_NotNull = false;
            this.diasvalidade.ST_PrimaryKey = false;
            this.diasvalidade.TabIndex = 13;
            this.diasvalidade.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(174, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 407;
            this.label3.Text = "Valido por";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_convenio
            // 
            this.dt_convenio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_convenio.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dt_convenio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConvenio, "Dt_conveniostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_convenio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_convenio.Location = new System.Drawing.Point(92, 161);
            this.dt_convenio.Mask = "00/00/0000";
            this.dt_convenio.Name = "dt_convenio";
            this.dt_convenio.NM_Alias = "";
            this.dt_convenio.NM_Campo = "";
            this.dt_convenio.NM_CampoBusca = "";
            this.dt_convenio.NM_Param = "";
            this.dt_convenio.Operador = "";
            this.dt_convenio.Size = new System.Drawing.Size(76, 20);
            this.dt_convenio.ST_Gravar = false;
            this.dt_convenio.ST_LimpaCampo = true;
            this.dt_convenio.ST_NotNull = true;
            this.dt_convenio.ST_PrimaryKey = false;
            this.dt_convenio.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(14, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 406;
            this.label8.Text = "Dt. Convenio:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFAlterarConvenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 356);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAlterarConvenio";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Convenio";
            this.Load += new System.EventHandler(this.FAlterarConvenio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FAlterarConvenio_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qt_dias_desdobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConvenio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_parcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_duppendente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diafechamentofat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diavencto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.desconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasvalidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.BindingSource bsConvenio;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label14;
        private Componentes.EditFloat diafechamentofat;
        private System.Windows.Forms.Label label13;
        private Componentes.EditFloat diavencto;
        private Componentes.ComboBoxDefault tp_desconto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Componentes.EditFloat desconto;
        private Componentes.EditDefault ds_condpgto;
        private System.Windows.Forms.Button bb_condpgto;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault cd_condpgto;
        private Componentes.EditDefault ds_tpdocto;
        private System.Windows.Forms.Button bb_tpdocto;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault tp_docto;
        private Componentes.EditDefault ds_tpduplicata;
        private System.Windows.Forms.Button bb_tpduplicata;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault tp_duplicata;
        private Componentes.EditDefault ds_portador;
        private System.Windows.Forms.Button bb_portador;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_portador;
        private Componentes.ComboBoxDefault st_registro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat diasvalidade;
        private System.Windows.Forms.Label label3;
        private Componentes.EditData dt_convenio;
        private System.Windows.Forms.Label label8;
        private Componentes.ComboBoxDefault tp_acresdesc;
        private System.Windows.Forms.Label label1;
        private Componentes.CheckBoxDefault st_descvlunit;
        private System.Windows.Forms.Label label15;
        private Componentes.EditDefault DS_convenio;
        private Componentes.EditFloat qtd_duppendente;
        private System.Windows.Forms.Label label17;
        private Componentes.CheckBoxDefault st_utilizardiascondpgto;
        private Componentes.ComboBoxDefault periodofatura;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblSemana;
        private Componentes.ComboBoxDefault diasemana;
        private Componentes.EditFloat qt_dias_desdobro;
        private Componentes.EditFloat qt_parcelas;
    }
}