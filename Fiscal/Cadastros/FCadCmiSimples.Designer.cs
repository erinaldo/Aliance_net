namespace Fiscal.Cadastros
{
    partial class FCadCmiSimples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadCmiSimples));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_cmii = new Componentes.EditDefault(this.components);
            this.bs_cmi = new System.Windows.Forms.BindingSource(this.components);
            this.cd_cmii = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tp_movimento = new Componentes.ComboBoxDefault(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.panelDados3 = new Componentes.PanelDados(this.components);
            this.st_retorno = new Componentes.CheckBoxDefault(this.components);
            this.st_compdevimposto = new Componentes.CheckBoxDefault(this.components);
            this.ST_Mestra = new Componentes.CheckBoxDefault(this.components);
            this.ST_Devolucao = new Componentes.CheckBoxDefault(this.components);
            this.ST_Complementar = new Componentes.CheckBoxDefault(this.components);
            this.ST_SimplesRemessa = new Componentes.CheckBoxDefault(this.components);
            this.ST_GeraEstoque = new Componentes.CheckBoxDefault(this.components);
            this.ds_condpgto = new Componentes.EditDefault(this.components);
            this.ds_tpduplicata = new Componentes.EditDefault(this.components);
            this.ds_tpDocto = new Componentes.EditDefault(this.components);
            this.bbDocto = new System.Windows.Forms.Button();
            this.bb_condpgto = new System.Windows.Forms.Button();
            this.bb_duplicata = new System.Windows.Forms.Button();
            this.LB_CD_CMI = new System.Windows.Forms.Label();
            this.LB_TP_Duplicata = new System.Windows.Forms.Label();
            this.LB_Tp_Docto = new System.Windows.Forms.Label();
            this.LB_DS_CMI = new System.Windows.Forms.Label();
            this.LB_CD_CondPGTO = new System.Windows.Forms.Label();
            this.TP_Duplicata = new Componentes.EditDefault(this.components);
            this.Tp_Docto = new Componentes.EditDefault(this.components);
            this.CD_CondPGTO = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_cmi)).BeginInit();
            this.radioGroup1.SuspendLayout();
            this.panelDados3.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(883, 43);
            this.barraMenu.TabIndex = 46;
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
            this.pDados.Controls.Add(this.ds_cmii);
            this.pDados.Controls.Add(this.cd_cmii);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.tp_movimento);
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.ds_condpgto);
            this.pDados.Controls.Add(this.ds_tpduplicata);
            this.pDados.Controls.Add(this.ds_tpDocto);
            this.pDados.Controls.Add(this.bbDocto);
            this.pDados.Controls.Add(this.bb_condpgto);
            this.pDados.Controls.Add(this.bb_duplicata);
            this.pDados.Controls.Add(this.LB_CD_CMI);
            this.pDados.Controls.Add(this.LB_TP_Duplicata);
            this.pDados.Controls.Add(this.LB_Tp_Docto);
            this.pDados.Controls.Add(this.LB_DS_CMI);
            this.pDados.Controls.Add(this.LB_CD_CondPGTO);
            this.pDados.Controls.Add(this.TP_Duplicata);
            this.pDados.Controls.Add(this.Tp_Docto);
            this.pDados.Controls.Add(this.CD_CondPGTO);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(883, 180);
            this.pDados.TabIndex = 47;
            // 
            // ds_cmii
            // 
            this.ds_cmii.BackColor = System.Drawing.SystemColors.Window;
            this.ds_cmii.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_cmii.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_cmii.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cmi, "Ds_cmi", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_cmii.Location = new System.Drawing.Point(93, 32);
            this.ds_cmii.Name = "ds_cmii";
            this.ds_cmii.NM_Alias = "";
            this.ds_cmii.NM_Campo = "";
            this.ds_cmii.NM_CampoBusca = "";
            this.ds_cmii.NM_Param = "";
            this.ds_cmii.QTD_Zero = 0;
            this.ds_cmii.Size = new System.Drawing.Size(425, 20);
            this.ds_cmii.ST_AutoInc = false;
            this.ds_cmii.ST_DisableAuto = false;
            this.ds_cmii.ST_Float = false;
            this.ds_cmii.ST_Gravar = false;
            this.ds_cmii.ST_Int = false;
            this.ds_cmii.ST_LimpaCampo = true;
            this.ds_cmii.ST_NotNull = false;
            this.ds_cmii.ST_PrimaryKey = false;
            this.ds_cmii.TabIndex = 0;
            this.ds_cmii.TextOld = null;
            // 
            // bs_cmi
            // 
            this.bs_cmi.DataSource = typeof(CamadaDados.Fiscal.TList_CadCMI);
            // 
            // cd_cmii
            // 
            this.cd_cmii.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cmii.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_cmii.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cmii.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cmi, "Cd_cmi", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_cmii.Enabled = false;
            this.cd_cmii.Location = new System.Drawing.Point(93, 6);
            this.cd_cmii.Name = "cd_cmii";
            this.cd_cmii.NM_Alias = "";
            this.cd_cmii.NM_Campo = "";
            this.cd_cmii.NM_CampoBusca = "";
            this.cd_cmii.NM_Param = "";
            this.cd_cmii.QTD_Zero = 0;
            this.cd_cmii.Size = new System.Drawing.Size(92, 20);
            this.cd_cmii.ST_AutoInc = false;
            this.cd_cmii.ST_DisableAuto = false;
            this.cd_cmii.ST_Float = false;
            this.cd_cmii.ST_Gravar = false;
            this.cd_cmii.ST_Int = false;
            this.cd_cmii.ST_LimpaCampo = true;
            this.cd_cmii.ST_NotNull = false;
            this.cd_cmii.ST_PrimaryKey = false;
            this.cd_cmii.TabIndex = 65;
            this.cd_cmii.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(24, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Movimento:";
            // 
            // tp_movimento
            // 
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bs_cmi, "Tp_movimento", true));
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cmi, "Tipo_movimento", true));
            this.tp_movimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_movimento.FormattingEnabled = true;
            this.tp_movimento.Location = new System.Drawing.Point(93, 57);
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "";
            this.tp_movimento.NM_Campo = "";
            this.tp_movimento.NM_Param = "";
            this.tp_movimento.Size = new System.Drawing.Size(214, 21);
            this.tp_movimento.ST_Gravar = true;
            this.tp_movimento.ST_LimparCampo = true;
            this.tp_movimento.ST_NotNull = true;
            this.tp_movimento.TabIndex = 1;
            this.tp_movimento.SelectedIndexChanged += new System.EventHandler(this.tp_movimento_SelectedIndexChanged);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.panelDados3);
            this.radioGroup1.Location = new System.Drawing.Point(524, 20);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(299, 109);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 62;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Configurações:";
            // 
            // panelDados3
            // 
            this.panelDados3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelDados3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados3.Controls.Add(this.st_retorno);
            this.panelDados3.Controls.Add(this.st_compdevimposto);
            this.panelDados3.Controls.Add(this.ST_Mestra);
            this.panelDados3.Controls.Add(this.ST_Devolucao);
            this.panelDados3.Controls.Add(this.ST_Complementar);
            this.panelDados3.Controls.Add(this.ST_SimplesRemessa);
            this.panelDados3.Controls.Add(this.ST_GeraEstoque);
            this.panelDados3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados3.Location = new System.Drawing.Point(3, 16);
            this.panelDados3.Name = "panelDados3";
            this.panelDados3.NM_ProcDeletar = "";
            this.panelDados3.NM_ProcGravar = "";
            this.panelDados3.Size = new System.Drawing.Size(293, 90);
            this.panelDados3.TabIndex = 0;
            // 
            // st_retorno
            // 
            this.st_retorno.AutoSize = true;
            this.st_retorno.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_cmi, "St_retornobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_retorno.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_retorno.Location = new System.Drawing.Point(5, 67);
            this.st_retorno.Name = "st_retorno";
            this.st_retorno.NM_Alias = "";
            this.st_retorno.NM_Campo = "st_retorno";
            this.st_retorno.NM_Param = "@P_ST_GERAESTOQUE";
            this.st_retorno.Size = new System.Drawing.Size(64, 17);
            this.st_retorno.ST_Gravar = true;
            this.st_retorno.ST_LimparCampo = true;
            this.st_retorno.ST_NotNull = false;
            this.st_retorno.TabIndex = 6;
            this.st_retorno.Text = "Retorno";
            this.st_retorno.UseVisualStyleBackColor = true;
            this.st_retorno.Vl_False = "N";
            this.st_retorno.Vl_True = "S";
            this.st_retorno.CheckedChanged += new System.EventHandler(this.st_retorno_CheckedChanged);
            // 
            // st_compdevimposto
            // 
            this.st_compdevimposto.AutoSize = true;
            this.st_compdevimposto.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_cmi, "St_compdevimpostobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_compdevimposto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_compdevimposto.Location = new System.Drawing.Point(156, 46);
            this.st_compdevimposto.Name = "st_compdevimposto";
            this.st_compdevimposto.NM_Alias = "";
            this.st_compdevimposto.NM_Campo = "ST_CompDevImposto";
            this.st_compdevimposto.NM_Param = "@P_ST_MESTRA";
            this.st_compdevimposto.Size = new System.Drawing.Size(118, 17);
            this.st_compdevimposto.ST_Gravar = true;
            this.st_compdevimposto.ST_LimparCampo = true;
            this.st_compdevimposto.ST_NotNull = false;
            this.st_compdevimposto.TabIndex = 5;
            this.st_compdevimposto.Text = "Comp/Dev Imposto";
            this.st_compdevimposto.UseVisualStyleBackColor = true;
            this.st_compdevimposto.Vl_False = "N";
            this.st_compdevimposto.Vl_True = "S";
            this.st_compdevimposto.CheckedChanged += new System.EventHandler(this.st_compdevimposto_CheckedChanged);
            // 
            // ST_Mestra
            // 
            this.ST_Mestra.AutoSize = true;
            this.ST_Mestra.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_cmi, "St_mestrabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Mestra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ST_Mestra.Location = new System.Drawing.Point(5, 25);
            this.ST_Mestra.Name = "ST_Mestra";
            this.ST_Mestra.NM_Alias = "";
            this.ST_Mestra.NM_Campo = "ST_Mestra";
            this.ST_Mestra.NM_Param = "@P_ST_MESTRA";
            this.ST_Mestra.Size = new System.Drawing.Size(58, 17);
            this.ST_Mestra.ST_Gravar = true;
            this.ST_Mestra.ST_LimparCampo = true;
            this.ST_Mestra.ST_NotNull = false;
            this.ST_Mestra.TabIndex = 2;
            this.ST_Mestra.Text = "Mestra";
            this.ST_Mestra.UseVisualStyleBackColor = true;
            this.ST_Mestra.Vl_False = "N";
            this.ST_Mestra.Vl_True = "S";
            this.ST_Mestra.CheckedChanged += new System.EventHandler(this.ST_Mestra_CheckedChanged);
            // 
            // ST_Devolucao
            // 
            this.ST_Devolucao.AutoSize = true;
            this.ST_Devolucao.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_cmi, "St_devolucaobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Devolucao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ST_Devolucao.Location = new System.Drawing.Point(5, 4);
            this.ST_Devolucao.Name = "ST_Devolucao";
            this.ST_Devolucao.NM_Alias = "";
            this.ST_Devolucao.NM_Campo = "ST_Devolucao";
            this.ST_Devolucao.NM_Param = "@P_ST_DEVOLUCAO";
            this.ST_Devolucao.Size = new System.Drawing.Size(78, 17);
            this.ST_Devolucao.ST_Gravar = true;
            this.ST_Devolucao.ST_LimparCampo = true;
            this.ST_Devolucao.ST_NotNull = false;
            this.ST_Devolucao.TabIndex = 0;
            this.ST_Devolucao.Text = "Devolução";
            this.ST_Devolucao.UseVisualStyleBackColor = true;
            this.ST_Devolucao.Vl_False = "N";
            this.ST_Devolucao.Vl_True = "S";
            this.ST_Devolucao.CheckedChanged += new System.EventHandler(this.ST_Devolucao_CheckedChanged);
            // 
            // ST_Complementar
            // 
            this.ST_Complementar.AutoSize = true;
            this.ST_Complementar.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_cmi, "St_complementarbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Complementar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ST_Complementar.Location = new System.Drawing.Point(156, 4);
            this.ST_Complementar.Name = "ST_Complementar";
            this.ST_Complementar.NM_Alias = "";
            this.ST_Complementar.NM_Campo = "ST_Complementar";
            this.ST_Complementar.NM_Param = "@P_ST_COMPLEMENTAR";
            this.ST_Complementar.Size = new System.Drawing.Size(90, 17);
            this.ST_Complementar.ST_Gravar = true;
            this.ST_Complementar.ST_LimparCampo = true;
            this.ST_Complementar.ST_NotNull = false;
            this.ST_Complementar.TabIndex = 1;
            this.ST_Complementar.Text = "Complemento";
            this.ST_Complementar.UseVisualStyleBackColor = true;
            this.ST_Complementar.Vl_False = "N";
            this.ST_Complementar.Vl_True = "S";
            this.ST_Complementar.CheckedChanged += new System.EventHandler(this.ST_Complementar_CheckedChanged);
            // 
            // ST_SimplesRemessa
            // 
            this.ST_SimplesRemessa.AutoSize = true;
            this.ST_SimplesRemessa.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_cmi, "St_simplesremessabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_SimplesRemessa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ST_SimplesRemessa.Location = new System.Drawing.Point(156, 25);
            this.ST_SimplesRemessa.Name = "ST_SimplesRemessa";
            this.ST_SimplesRemessa.NM_Alias = "";
            this.ST_SimplesRemessa.NM_Campo = "ST_SimplesRemessa";
            this.ST_SimplesRemessa.NM_Param = "@P_ST_SIMPLESREMESSA";
            this.ST_SimplesRemessa.Size = new System.Drawing.Size(109, 17);
            this.ST_SimplesRemessa.ST_Gravar = true;
            this.ST_SimplesRemessa.ST_LimparCampo = true;
            this.ST_SimplesRemessa.ST_NotNull = false;
            this.ST_SimplesRemessa.TabIndex = 3;
            this.ST_SimplesRemessa.Text = "Simples Remessa";
            this.ST_SimplesRemessa.UseVisualStyleBackColor = true;
            this.ST_SimplesRemessa.Vl_False = "N";
            this.ST_SimplesRemessa.Vl_True = "S";
            this.ST_SimplesRemessa.CheckedChanged += new System.EventHandler(this.ST_SimplesRemessa_CheckedChanged);
            // 
            // ST_GeraEstoque
            // 
            this.ST_GeraEstoque.AutoSize = true;
            this.ST_GeraEstoque.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_cmi, "St_geraestoquebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_GeraEstoque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ST_GeraEstoque.Location = new System.Drawing.Point(5, 46);
            this.ST_GeraEstoque.Name = "ST_GeraEstoque";
            this.ST_GeraEstoque.NM_Alias = "";
            this.ST_GeraEstoque.NM_Campo = "ST_GeraEstoque";
            this.ST_GeraEstoque.NM_Param = "@P_ST_GERAESTOQUE";
            this.ST_GeraEstoque.Size = new System.Drawing.Size(130, 17);
            this.ST_GeraEstoque.ST_Gravar = true;
            this.ST_GeraEstoque.ST_LimparCampo = true;
            this.ST_GeraEstoque.ST_NotNull = false;
            this.ST_GeraEstoque.TabIndex = 4;
            this.ST_GeraEstoque.Text = "Estoque/Almoxarifado";
            this.ST_GeraEstoque.UseVisualStyleBackColor = true;
            this.ST_GeraEstoque.Vl_False = "N";
            this.ST_GeraEstoque.Vl_True = "S";
            // 
            // ds_condpgto
            // 
            this.ds_condpgto.BackColor = System.Drawing.Color.White;
            this.ds_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cmi, "ds_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_condpgto.Enabled = false;
            this.ds_condpgto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_condpgto.Location = new System.Drawing.Point(209, 135);
            this.ds_condpgto.Name = "ds_condpgto";
            this.ds_condpgto.NM_Alias = "";
            this.ds_condpgto.NM_Campo = "ds_condpgto";
            this.ds_condpgto.NM_CampoBusca = "ds_condpgto";
            this.ds_condpgto.NM_Param = "";
            this.ds_condpgto.QTD_Zero = 0;
            this.ds_condpgto.ReadOnly = true;
            this.ds_condpgto.Size = new System.Drawing.Size(614, 20);
            this.ds_condpgto.ST_AutoInc = false;
            this.ds_condpgto.ST_DisableAuto = false;
            this.ds_condpgto.ST_Float = false;
            this.ds_condpgto.ST_Gravar = false;
            this.ds_condpgto.ST_Int = false;
            this.ds_condpgto.ST_LimpaCampo = true;
            this.ds_condpgto.ST_NotNull = false;
            this.ds_condpgto.ST_PrimaryKey = false;
            this.ds_condpgto.TabIndex = 61;
            this.ds_condpgto.TextOld = null;
            // 
            // ds_tpduplicata
            // 
            this.ds_tpduplicata.BackColor = System.Drawing.Color.White;
            this.ds_tpduplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpduplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpduplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cmi, "ds_tpduplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpduplicata.Enabled = false;
            this.ds_tpduplicata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tpduplicata.Location = new System.Drawing.Point(209, 109);
            this.ds_tpduplicata.Name = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Alias = "";
            this.ds_tpduplicata.NM_Campo = "ds_tpduplicata";
            this.ds_tpduplicata.NM_CampoBusca = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Param = "";
            this.ds_tpduplicata.QTD_Zero = 0;
            this.ds_tpduplicata.ReadOnly = true;
            this.ds_tpduplicata.Size = new System.Drawing.Size(309, 20);
            this.ds_tpduplicata.ST_AutoInc = false;
            this.ds_tpduplicata.ST_DisableAuto = false;
            this.ds_tpduplicata.ST_Float = false;
            this.ds_tpduplicata.ST_Gravar = false;
            this.ds_tpduplicata.ST_Int = false;
            this.ds_tpduplicata.ST_LimpaCampo = true;
            this.ds_tpduplicata.ST_NotNull = false;
            this.ds_tpduplicata.ST_PrimaryKey = false;
            this.ds_tpduplicata.TabIndex = 59;
            this.ds_tpduplicata.TextOld = null;
            // 
            // ds_tpDocto
            // 
            this.ds_tpDocto.BackColor = System.Drawing.Color.White;
            this.ds_tpDocto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpDocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpDocto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cmi, "ds_tpdocto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpDocto.Enabled = false;
            this.ds_tpDocto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tpDocto.Location = new System.Drawing.Point(209, 84);
            this.ds_tpDocto.Name = "ds_tpDocto";
            this.ds_tpDocto.NM_Alias = "";
            this.ds_tpDocto.NM_Campo = "ds_tpdocto";
            this.ds_tpDocto.NM_CampoBusca = "ds_tpdocto";
            this.ds_tpDocto.NM_Param = "";
            this.ds_tpDocto.QTD_Zero = 0;
            this.ds_tpDocto.ReadOnly = true;
            this.ds_tpDocto.Size = new System.Drawing.Size(309, 20);
            this.ds_tpDocto.ST_AutoInc = false;
            this.ds_tpDocto.ST_DisableAuto = false;
            this.ds_tpDocto.ST_Float = false;
            this.ds_tpDocto.ST_Gravar = false;
            this.ds_tpDocto.ST_Int = false;
            this.ds_tpDocto.ST_LimpaCampo = true;
            this.ds_tpDocto.ST_NotNull = false;
            this.ds_tpDocto.ST_PrimaryKey = false;
            this.ds_tpDocto.TabIndex = 56;
            this.ds_tpDocto.TextOld = null;
            // 
            // bbDocto
            // 
            this.bbDocto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bbDocto.Image = ((System.Drawing.Image)(resources.GetObject("bbDocto.Image")));
            this.bbDocto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbDocto.Location = new System.Drawing.Point(177, 84);
            this.bbDocto.Name = "bbDocto";
            this.bbDocto.Size = new System.Drawing.Size(30, 20);
            this.bbDocto.TabIndex = 3;
            this.bbDocto.UseVisualStyleBackColor = true;
            this.bbDocto.Click += new System.EventHandler(this.bbDocto_Click);
            // 
            // bb_condpgto
            // 
            this.bb_condpgto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_condpgto.Image = ((System.Drawing.Image)(resources.GetObject("bb_condpgto.Image")));
            this.bb_condpgto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_condpgto.Location = new System.Drawing.Point(177, 135);
            this.bb_condpgto.Name = "bb_condpgto";
            this.bb_condpgto.Size = new System.Drawing.Size(30, 20);
            this.bb_condpgto.TabIndex = 7;
            this.bb_condpgto.UseVisualStyleBackColor = true;
            this.bb_condpgto.Click += new System.EventHandler(this.bb_condpgto_Click);
            // 
            // bb_duplicata
            // 
            this.bb_duplicata.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_duplicata.Image = ((System.Drawing.Image)(resources.GetObject("bb_duplicata.Image")));
            this.bb_duplicata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_duplicata.Location = new System.Drawing.Point(177, 109);
            this.bb_duplicata.Name = "bb_duplicata";
            this.bb_duplicata.Size = new System.Drawing.Size(30, 20);
            this.bb_duplicata.TabIndex = 5;
            this.bb_duplicata.UseVisualStyleBackColor = true;
            this.bb_duplicata.Click += new System.EventHandler(this.bb_duplicata_Click);
            // 
            // LB_CD_CMI
            // 
            this.LB_CD_CMI.AutoSize = true;
            this.LB_CD_CMI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_CMI.Location = new System.Drawing.Point(43, 8);
            this.LB_CD_CMI.Name = "LB_CD_CMI";
            this.LB_CD_CMI.Size = new System.Drawing.Size(43, 13);
            this.LB_CD_CMI.TabIndex = 47;
            this.LB_CD_CMI.Text = "Código:";
            // 
            // LB_TP_Duplicata
            // 
            this.LB_TP_Duplicata.AutoSize = true;
            this.LB_TP_Duplicata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_TP_Duplicata.Location = new System.Drawing.Point(11, 112);
            this.LB_TP_Duplicata.Name = "LB_TP_Duplicata";
            this.LB_TP_Duplicata.Size = new System.Drawing.Size(74, 13);
            this.LB_TP_Duplicata.TabIndex = 50;
            this.LB_TP_Duplicata.Text = "Tp. Duplicata:";
            // 
            // LB_Tp_Docto
            // 
            this.LB_Tp_Docto.AutoSize = true;
            this.LB_Tp_Docto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Tp_Docto.Location = new System.Drawing.Point(23, 87);
            this.LB_Tp_Docto.Name = "LB_Tp_Docto";
            this.LB_Tp_Docto.Size = new System.Drawing.Size(64, 13);
            this.LB_Tp_Docto.TabIndex = 51;
            this.LB_Tp_Docto.Text = "Tp.  Docto.:";
            // 
            // LB_DS_CMI
            // 
            this.LB_DS_CMI.AutoSize = true;
            this.LB_DS_CMI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_CMI.Location = new System.Drawing.Point(55, 34);
            this.LB_DS_CMI.Name = "LB_DS_CMI";
            this.LB_DS_CMI.Size = new System.Drawing.Size(29, 13);
            this.LB_DS_CMI.TabIndex = 54;
            this.LB_DS_CMI.Text = "CMI:";
            // 
            // LB_CD_CondPGTO
            // 
            this.LB_CD_CondPGTO.AutoSize = true;
            this.LB_CD_CondPGTO.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_CondPGTO.Location = new System.Drawing.Point(13, 138);
            this.LB_CD_CondPGTO.Name = "LB_CD_CondPGTO";
            this.LB_CD_CondPGTO.Size = new System.Drawing.Size(74, 13);
            this.LB_CD_CondPGTO.TabIndex = 63;
            this.LB_CD_CondPGTO.Text = "Cond. PGTO.:";
            // 
            // TP_Duplicata
            // 
            this.TP_Duplicata.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Duplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Duplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Duplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cmi, "Tp_duplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Duplicata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TP_Duplicata.Location = new System.Drawing.Point(93, 109);
            this.TP_Duplicata.Name = "TP_Duplicata";
            this.TP_Duplicata.NM_Alias = "a";
            this.TP_Duplicata.NM_Campo = "TP_Duplicata";
            this.TP_Duplicata.NM_CampoBusca = "TP_Duplicata";
            this.TP_Duplicata.NM_Param = "@P_TP_DUPLICATA";
            this.TP_Duplicata.QTD_Zero = 0;
            this.TP_Duplicata.Size = new System.Drawing.Size(80, 20);
            this.TP_Duplicata.ST_AutoInc = false;
            this.TP_Duplicata.ST_DisableAuto = false;
            this.TP_Duplicata.ST_Float = false;
            this.TP_Duplicata.ST_Gravar = true;
            this.TP_Duplicata.ST_Int = true;
            this.TP_Duplicata.ST_LimpaCampo = true;
            this.TP_Duplicata.ST_NotNull = false;
            this.TP_Duplicata.ST_PrimaryKey = false;
            this.TP_Duplicata.TabIndex = 4;
            this.TP_Duplicata.TextOld = null;
            this.TP_Duplicata.Leave += new System.EventHandler(this.TP_Duplicata_Leave);
            // 
            // Tp_Docto
            // 
            this.Tp_Docto.BackColor = System.Drawing.SystemColors.Window;
            this.Tp_Docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tp_Docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Tp_Docto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cmi, "Tp_doctostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Tp_Docto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Tp_Docto.Location = new System.Drawing.Point(93, 84);
            this.Tp_Docto.Name = "Tp_Docto";
            this.Tp_Docto.NM_Alias = "a";
            this.Tp_Docto.NM_Campo = "Tp_Docto";
            this.Tp_Docto.NM_CampoBusca = "Tp_Docto";
            this.Tp_Docto.NM_Param = "@P_TP_DOCTO";
            this.Tp_Docto.QTD_Zero = 0;
            this.Tp_Docto.Size = new System.Drawing.Size(80, 20);
            this.Tp_Docto.ST_AutoInc = false;
            this.Tp_Docto.ST_DisableAuto = false;
            this.Tp_Docto.ST_Float = false;
            this.Tp_Docto.ST_Gravar = true;
            this.Tp_Docto.ST_Int = true;
            this.Tp_Docto.ST_LimpaCampo = true;
            this.Tp_Docto.ST_NotNull = false;
            this.Tp_Docto.ST_PrimaryKey = false;
            this.Tp_Docto.TabIndex = 2;
            this.Tp_Docto.TextOld = null;
            this.Tp_Docto.Leave += new System.EventHandler(this.Tp_Docto_Leave);
            // 
            // CD_CondPGTO
            // 
            this.CD_CondPGTO.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CondPGTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CondPGTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CondPGTO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cmi, "Cd_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_CondPGTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_CondPGTO.Location = new System.Drawing.Point(93, 135);
            this.CD_CondPGTO.Name = "CD_CondPGTO";
            this.CD_CondPGTO.NM_Alias = "a";
            this.CD_CondPGTO.NM_Campo = "CD_CondPGTO";
            this.CD_CondPGTO.NM_CampoBusca = "CD_CondPGTO";
            this.CD_CondPGTO.NM_Param = "@P_CD_CONDPGTO";
            this.CD_CondPGTO.QTD_Zero = 0;
            this.CD_CondPGTO.Size = new System.Drawing.Size(80, 20);
            this.CD_CondPGTO.ST_AutoInc = false;
            this.CD_CondPGTO.ST_DisableAuto = false;
            this.CD_CondPGTO.ST_Float = false;
            this.CD_CondPGTO.ST_Gravar = true;
            this.CD_CondPGTO.ST_Int = true;
            this.CD_CondPGTO.ST_LimpaCampo = true;
            this.CD_CondPGTO.ST_NotNull = false;
            this.CD_CondPGTO.ST_PrimaryKey = false;
            this.CD_CondPGTO.TabIndex = 6;
            this.CD_CondPGTO.TextOld = null;
            this.CD_CondPGTO.Leave += new System.EventHandler(this.CD_CondPGTO_Leave);
            // 
            // FCadCmiSimples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 223);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.Name = "FCadCmiSimples";
            this.Text = "Cadastro de CMI";
            this.Load += new System.EventHandler(this.FCadCmiSimples_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_cmi)).EndInit();
            this.radioGroup1.ResumeLayout(false);
            this.panelDados3.ResumeLayout(false);
            this.panelDados3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault tp_movimento;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.PanelDados panelDados3;
        private Componentes.CheckBoxDefault st_retorno;
        private Componentes.CheckBoxDefault st_compdevimposto;
        private Componentes.CheckBoxDefault ST_Mestra;
        private Componentes.CheckBoxDefault ST_Devolucao;
        private Componentes.CheckBoxDefault ST_Complementar;
        private Componentes.CheckBoxDefault ST_SimplesRemessa;
        private Componentes.CheckBoxDefault ST_GeraEstoque;
        private Componentes.EditDefault ds_condpgto;
        private Componentes.EditDefault ds_tpduplicata;
        private Componentes.EditDefault ds_tpDocto;
        public System.Windows.Forms.Button bbDocto;
        public System.Windows.Forms.Button bb_condpgto;
        public System.Windows.Forms.Button bb_duplicata;
        private System.Windows.Forms.Label LB_CD_CMI;
        private System.Windows.Forms.Label LB_TP_Duplicata;
        private System.Windows.Forms.Label LB_Tp_Docto;
        private System.Windows.Forms.Label LB_DS_CMI;
        private System.Windows.Forms.Label LB_CD_CondPGTO;
        private Componentes.EditDefault TP_Duplicata;
        private Componentes.EditDefault Tp_Docto;
        private Componentes.EditDefault CD_CondPGTO;
        private System.Windows.Forms.BindingSource bs_cmi;
        private Componentes.EditDefault ds_cmii;
        private Componentes.EditDefault cd_cmii;
    }
}