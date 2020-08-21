namespace Proc_Commoditties
{
    partial class TFAtualizaCadProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAtualizaCadProduto));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDadosProd = new Componentes.PanelDados(this.components);
            this.bb_saldoest = new System.Windows.Forms.Button();
            this.tp_item = new Componentes.ComboBoxDefault(this.components);
            this.bsProduto = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.DS_Tecnica = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.codigo_alternativo = new Componentes.EditDefault(this.components);
            this.ds_anp = new Componentes.EditDefault(this.components);
            this.bb_anp = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cd_anp = new Componentes.EditDefault(this.components);
            this.ncm = new Componentes.EditDefault(this.components);
            this.LB_cd_ClassifFiscal = new System.Windows.Forms.Label();
            this.bb_ncm = new System.Windows.Forms.Button();
            this.ds_ncm = new Componentes.EditDefault(this.components);
            this.lblCodAlternativo = new System.Windows.Forms.Label();
            this.LB_CD_Produto = new System.Windows.Forms.Label();
            this.CD_Grupo = new Componentes.EditDefault(this.components);
            this.ds_tpproduto = new Componentes.EditDefault(this.components);
            this.BB_TpProduto = new System.Windows.Forms.Button();
            this.LB_CD_Grupo = new System.Windows.Forms.Label();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.CD_Unidade = new Componentes.EditDefault(this.components);
            this.LB_CD_Unidade = new System.Windows.Forms.Label();
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.ds_condfiscal_produto = new Componentes.EditDefault(this.components);
            this.LB_DS_Produto = new System.Windows.Forms.Label();
            this.CD_CondFiscal_Produto = new Componentes.EditDefault(this.components);
            this.BB_CondFiscalProduto = new System.Windows.Forms.Button();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.LB_TP_Produto = new System.Windows.Forms.Label();
            this.LB_CD_CondFiscal_Produto = new System.Windows.Forms.Label();
            this.DS_Grupo = new Componentes.EditDefault(this.components);
            this.BB_Unidade = new System.Windows.Forms.Button();
            this.BB_GrupoProduto = new System.Windows.Forms.Button();
            this.ds_unidade = new Componentes.EditDefault(this.components);
            this.TP_Produto = new Componentes.EditDefault(this.components);
            this.cod_barras = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDadosProd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(614, 43);
            this.barraMenu.TabIndex = 14;
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
            // pDadosProd
            // 
            this.pDadosProd.BackColor = System.Drawing.SystemColors.Control;
            this.pDadosProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDadosProd.Controls.Add(this.label1);
            this.pDadosProd.Controls.Add(this.cod_barras);
            this.pDadosProd.Controls.Add(this.bb_saldoest);
            this.pDadosProd.Controls.Add(this.tp_item);
            this.pDadosProd.Controls.Add(this.label11);
            this.pDadosProd.Controls.Add(this.DS_Tecnica);
            this.pDadosProd.Controls.Add(this.label4);
            this.pDadosProd.Controls.Add(this.label8);
            this.pDadosProd.Controls.Add(this.codigo_alternativo);
            this.pDadosProd.Controls.Add(this.ds_anp);
            this.pDadosProd.Controls.Add(this.bb_anp);
            this.pDadosProd.Controls.Add(this.label12);
            this.pDadosProd.Controls.Add(this.cd_anp);
            this.pDadosProd.Controls.Add(this.ncm);
            this.pDadosProd.Controls.Add(this.LB_cd_ClassifFiscal);
            this.pDadosProd.Controls.Add(this.bb_ncm);
            this.pDadosProd.Controls.Add(this.ds_ncm);
            this.pDadosProd.Controls.Add(this.lblCodAlternativo);
            this.pDadosProd.Controls.Add(this.LB_CD_Produto);
            this.pDadosProd.Controls.Add(this.CD_Grupo);
            this.pDadosProd.Controls.Add(this.ds_tpproduto);
            this.pDadosProd.Controls.Add(this.BB_TpProduto);
            this.pDadosProd.Controls.Add(this.LB_CD_Grupo);
            this.pDadosProd.Controls.Add(this.DS_Produto);
            this.pDadosProd.Controls.Add(this.CD_Unidade);
            this.pDadosProd.Controls.Add(this.LB_CD_Unidade);
            this.pDadosProd.Controls.Add(this.sigla_unidade);
            this.pDadosProd.Controls.Add(this.ds_condfiscal_produto);
            this.pDadosProd.Controls.Add(this.LB_DS_Produto);
            this.pDadosProd.Controls.Add(this.CD_CondFiscal_Produto);
            this.pDadosProd.Controls.Add(this.BB_CondFiscalProduto);
            this.pDadosProd.Controls.Add(this.CD_Produto);
            this.pDadosProd.Controls.Add(this.LB_TP_Produto);
            this.pDadosProd.Controls.Add(this.LB_CD_CondFiscal_Produto);
            this.pDadosProd.Controls.Add(this.DS_Grupo);
            this.pDadosProd.Controls.Add(this.BB_Unidade);
            this.pDadosProd.Controls.Add(this.BB_GrupoProduto);
            this.pDadosProd.Controls.Add(this.ds_unidade);
            this.pDadosProd.Controls.Add(this.TP_Produto);
            this.pDadosProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDadosProd.Location = new System.Drawing.Point(0, 43);
            this.pDadosProd.Name = "pDadosProd";
            this.pDadosProd.NM_ProcDeletar = "";
            this.pDadosProd.NM_ProcGravar = "";
            this.pDadosProd.Size = new System.Drawing.Size(614, 373);
            this.pDadosProd.TabIndex = 15;
            // 
            // bb_saldoest
            // 
            this.bb_saldoest.Location = new System.Drawing.Point(345, 211);
            this.bb_saldoest.Name = "bb_saldoest";
            this.bb_saldoest.Size = new System.Drawing.Size(261, 23);
            this.bb_saldoest.TabIndex = 918;
            this.bb_saldoest.Text = "Incluir Saldo Estoque/Preço Venda";
            this.bb_saldoest.UseVisualStyleBackColor = true;
            this.bb_saldoest.Click += new System.EventHandler(this.bb_saldoest_Click);
            // 
            // tp_item
            // 
            this.tp_item.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsProduto, "Tp_item", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_item.FormattingEnabled = true;
            this.tp_item.Location = new System.Drawing.Point(87, 211);
            this.tp_item.Name = "tp_item";
            this.tp_item.NM_Alias = "";
            this.tp_item.NM_Campo = "";
            this.tp_item.NM_Param = "";
            this.tp_item.Size = new System.Drawing.Size(240, 21);
            this.tp_item.ST_Gravar = true;
            this.tp_item.ST_LimparCampo = true;
            this.tp_item.ST_NotNull = false;
            this.tp_item.TabIndex = 15;
            // 
            // bsProduto
            // 
            this.bsProduto.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadProduto);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(29, 214);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 917;
            this.label11.Text = "Tipo Item:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DS_Tecnica
            // 
            this.DS_Tecnica.AcceptsReturn = true;
            this.DS_Tecnica.AcceptsTab = true;
            this.DS_Tecnica.BackColor = System.Drawing.Color.White;
            this.DS_Tecnica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Tecnica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Tecnica.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "DS_TecnicaAssistencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Tecnica.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.DS_Tecnica.Location = new System.Drawing.Point(87, 275);
            this.DS_Tecnica.Multiline = true;
            this.DS_Tecnica.Name = "DS_Tecnica";
            this.DS_Tecnica.NM_Alias = "";
            this.DS_Tecnica.NM_Campo = "DS_Tecnica";
            this.DS_Tecnica.NM_CampoBusca = "DS_Tecnica";
            this.DS_Tecnica.NM_Param = "@P_DS_TECNICA";
            this.DS_Tecnica.QTD_Zero = 0;
            this.DS_Tecnica.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DS_Tecnica.Size = new System.Drawing.Size(519, 86);
            this.DS_Tecnica.ST_AutoInc = false;
            this.DS_Tecnica.ST_DisableAuto = false;
            this.DS_Tecnica.ST_Float = false;
            this.DS_Tecnica.ST_Gravar = true;
            this.DS_Tecnica.ST_Int = false;
            this.DS_Tecnica.ST_LimpaCampo = true;
            this.DS_Tecnica.ST_NotNull = false;
            this.DS_Tecnica.ST_PrimaryKey = false;
            this.DS_Tecnica.TabIndex = 16;
            this.DS_Tecnica.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(85, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 915;
            this.label4.Text = "Descrição Técnica";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(185, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 913;
            this.label8.Text = "Referencia:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // codigo_alternativo
            // 
            this.codigo_alternativo.BackColor = System.Drawing.Color.White;
            this.codigo_alternativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codigo_alternativo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.codigo_alternativo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "Codigo_alternativo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codigo_alternativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.codigo_alternativo.Location = new System.Drawing.Point(253, 3);
            this.codigo_alternativo.Name = "codigo_alternativo";
            this.codigo_alternativo.NM_Alias = "a";
            this.codigo_alternativo.NM_Campo = "codigo_alternativo";
            this.codigo_alternativo.NM_CampoBusca = "codigo_alternativo";
            this.codigo_alternativo.NM_Param = "@P_CD_PRODUTO";
            this.codigo_alternativo.QTD_Zero = 0;
            this.codigo_alternativo.Size = new System.Drawing.Size(255, 20);
            this.codigo_alternativo.ST_AutoInc = false;
            this.codigo_alternativo.ST_DisableAuto = true;
            this.codigo_alternativo.ST_Float = false;
            this.codigo_alternativo.ST_Gravar = true;
            this.codigo_alternativo.ST_Int = false;
            this.codigo_alternativo.ST_LimpaCampo = true;
            this.codigo_alternativo.ST_NotNull = false;
            this.codigo_alternativo.ST_PrimaryKey = false;
            this.codigo_alternativo.TabIndex = 1;
            this.codigo_alternativo.TextOld = null;
            // 
            // ds_anp
            // 
            this.ds_anp.BackColor = System.Drawing.Color.White;
            this.ds_anp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_anp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_anp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "Ds_anp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_anp.Enabled = false;
            this.ds_anp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_anp.Location = new System.Drawing.Point(202, 185);
            this.ds_anp.Name = "ds_anp";
            this.ds_anp.NM_Alias = "";
            this.ds_anp.NM_Campo = "ds_anp";
            this.ds_anp.NM_CampoBusca = "ds_anp";
            this.ds_anp.NM_Param = "@P_DS_NCM";
            this.ds_anp.QTD_Zero = 0;
            this.ds_anp.ReadOnly = true;
            this.ds_anp.Size = new System.Drawing.Size(404, 20);
            this.ds_anp.ST_AutoInc = false;
            this.ds_anp.ST_DisableAuto = false;
            this.ds_anp.ST_Float = false;
            this.ds_anp.ST_Gravar = false;
            this.ds_anp.ST_Int = false;
            this.ds_anp.ST_LimpaCampo = true;
            this.ds_anp.ST_NotNull = false;
            this.ds_anp.ST_PrimaryKey = false;
            this.ds_anp.TabIndex = 911;
            this.ds_anp.TextOld = null;
            // 
            // bb_anp
            // 
            this.bb_anp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_anp.Image = ((System.Drawing.Image)(resources.GetObject("bb_anp.Image")));
            this.bb_anp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_anp.Location = new System.Drawing.Point(166, 185);
            this.bb_anp.Name = "bb_anp";
            this.bb_anp.Size = new System.Drawing.Size(30, 20);
            this.bb_anp.TabIndex = 14;
            this.bb_anp.UseVisualStyleBackColor = true;
            this.bb_anp.Click += new System.EventHandler(this.bb_anp_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(26, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 910;
            this.label12.Text = "Cod. ANP:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cd_anp
            // 
            this.cd_anp.BackColor = System.Drawing.SystemColors.Window;
            this.cd_anp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_anp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_anp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "Cd_anp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_anp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_anp.Location = new System.Drawing.Point(87, 185);
            this.cd_anp.Name = "cd_anp";
            this.cd_anp.NM_Alias = "a";
            this.cd_anp.NM_Campo = "cd_anp";
            this.cd_anp.NM_CampoBusca = "cd_anp";
            this.cd_anp.NM_Param = "@P_CD_CLASSIFFISCAL";
            this.cd_anp.QTD_Zero = 0;
            this.cd_anp.Size = new System.Drawing.Size(78, 20);
            this.cd_anp.ST_AutoInc = false;
            this.cd_anp.ST_DisableAuto = false;
            this.cd_anp.ST_Float = false;
            this.cd_anp.ST_Gravar = true;
            this.cd_anp.ST_Int = false;
            this.cd_anp.ST_LimpaCampo = true;
            this.cd_anp.ST_NotNull = false;
            this.cd_anp.ST_PrimaryKey = false;
            this.cd_anp.TabIndex = 13;
            this.cd_anp.TextOld = null;
            this.cd_anp.Leave += new System.EventHandler(this.cd_anp_Leave);
            // 
            // ncm
            // 
            this.ncm.BackColor = System.Drawing.SystemColors.Window;
            this.ncm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ncm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ncm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "Ncm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ncm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ncm.Location = new System.Drawing.Point(87, 159);
            this.ncm.Name = "ncm";
            this.ncm.NM_Alias = "a";
            this.ncm.NM_Campo = "ncm";
            this.ncm.NM_CampoBusca = "ncm";
            this.ncm.NM_Param = "@P_CD_CLASSIFFISCAL";
            this.ncm.QTD_Zero = 0;
            this.ncm.Size = new System.Drawing.Size(104, 20);
            this.ncm.ST_AutoInc = false;
            this.ncm.ST_DisableAuto = false;
            this.ncm.ST_Float = false;
            this.ncm.ST_Gravar = true;
            this.ncm.ST_Int = false;
            this.ncm.ST_LimpaCampo = true;
            this.ncm.ST_NotNull = false;
            this.ncm.ST_PrimaryKey = false;
            this.ncm.TabIndex = 11;
            this.ncm.TextOld = null;
            this.ncm.Leave += new System.EventHandler(this.ncm_Leave);
            // 
            // LB_cd_ClassifFiscal
            // 
            this.LB_cd_ClassifFiscal.AutoSize = true;
            this.LB_cd_ClassifFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_cd_ClassifFiscal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_cd_ClassifFiscal.Location = new System.Drawing.Point(48, 162);
            this.LB_cd_ClassifFiscal.Name = "LB_cd_ClassifFiscal";
            this.LB_cd_ClassifFiscal.Size = new System.Drawing.Size(34, 13);
            this.LB_cd_ClassifFiscal.TabIndex = 885;
            this.LB_cd_ClassifFiscal.Text = "NCM:";
            this.LB_cd_ClassifFiscal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bb_ncm
            // 
            this.bb_ncm.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_ncm.Image = ((System.Drawing.Image)(resources.GetObject("bb_ncm.Image")));
            this.bb_ncm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_ncm.Location = new System.Drawing.Point(196, 159);
            this.bb_ncm.Name = "bb_ncm";
            this.bb_ncm.Size = new System.Drawing.Size(30, 20);
            this.bb_ncm.TabIndex = 12;
            this.bb_ncm.UseVisualStyleBackColor = true;
            this.bb_ncm.Click += new System.EventHandler(this.bb_ncm_Click);
            // 
            // ds_ncm
            // 
            this.ds_ncm.BackColor = System.Drawing.Color.White;
            this.ds_ncm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_ncm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_ncm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "Ds_ncm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_ncm.Enabled = false;
            this.ds_ncm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_ncm.Location = new System.Drawing.Point(230, 159);
            this.ds_ncm.Name = "ds_ncm";
            this.ds_ncm.NM_Alias = "";
            this.ds_ncm.NM_Campo = "ds_ncm";
            this.ds_ncm.NM_CampoBusca = "ds_ncm";
            this.ds_ncm.NM_Param = "@P_DS_NCM";
            this.ds_ncm.QTD_Zero = 0;
            this.ds_ncm.ReadOnly = true;
            this.ds_ncm.Size = new System.Drawing.Size(376, 20);
            this.ds_ncm.ST_AutoInc = false;
            this.ds_ncm.ST_DisableAuto = false;
            this.ds_ncm.ST_Float = false;
            this.ds_ncm.ST_Gravar = false;
            this.ds_ncm.ST_Int = false;
            this.ds_ncm.ST_LimpaCampo = true;
            this.ds_ncm.ST_NotNull = false;
            this.ds_ncm.ST_PrimaryKey = false;
            this.ds_ncm.TabIndex = 894;
            this.ds_ncm.TextOld = null;
            // 
            // lblCodAlternativo
            // 
            this.lblCodAlternativo.AutoSize = true;
            this.lblCodAlternativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCodAlternativo.ForeColor = System.Drawing.Color.Red;
            this.lblCodAlternativo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodAlternativo.Location = new System.Drawing.Point(562, 6);
            this.lblCodAlternativo.Name = "lblCodAlternativo";
            this.lblCodAlternativo.Size = new System.Drawing.Size(0, 13);
            this.lblCodAlternativo.TabIndex = 873;
            // 
            // LB_CD_Produto
            // 
            this.LB_CD_Produto.AutoSize = true;
            this.LB_CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Produto.Location = new System.Drawing.Point(38, 6);
            this.LB_CD_Produto.Name = "LB_CD_Produto";
            this.LB_CD_Produto.Size = new System.Drawing.Size(43, 13);
            this.LB_CD_Produto.TabIndex = 0;
            this.LB_CD_Produto.Text = "Código:";
            this.LB_CD_Produto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CD_Grupo
            // 
            this.CD_Grupo.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "CD_Grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Grupo.Location = new System.Drawing.Point(87, 55);
            this.CD_Grupo.Name = "CD_Grupo";
            this.CD_Grupo.NM_Alias = "a";
            this.CD_Grupo.NM_Campo = "CD_Grupo";
            this.CD_Grupo.NM_CampoBusca = "CD_Grupo";
            this.CD_Grupo.NM_Param = "@P_CD_GRUPO";
            this.CD_Grupo.QTD_Zero = 0;
            this.CD_Grupo.Size = new System.Drawing.Size(56, 20);
            this.CD_Grupo.ST_AutoInc = false;
            this.CD_Grupo.ST_DisableAuto = false;
            this.CD_Grupo.ST_Float = false;
            this.CD_Grupo.ST_Gravar = true;
            this.CD_Grupo.ST_Int = false;
            this.CD_Grupo.ST_LimpaCampo = true;
            this.CD_Grupo.ST_NotNull = true;
            this.CD_Grupo.ST_PrimaryKey = false;
            this.CD_Grupo.TabIndex = 3;
            this.CD_Grupo.TextOld = null;
            this.CD_Grupo.Leave += new System.EventHandler(this.CD_Grupo_Leave);
            // 
            // ds_tpproduto
            // 
            this.ds_tpproduto.BackColor = System.Drawing.Color.White;
            this.ds_tpproduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpproduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpproduto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "DS_TpProduto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpproduto.Enabled = false;
            this.ds_tpproduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tpproduto.Location = new System.Drawing.Point(182, 107);
            this.ds_tpproduto.Name = "ds_tpproduto";
            this.ds_tpproduto.NM_Alias = "";
            this.ds_tpproduto.NM_Campo = "ds_tpproduto";
            this.ds_tpproduto.NM_CampoBusca = "ds_tpproduto";
            this.ds_tpproduto.NM_Param = "";
            this.ds_tpproduto.QTD_Zero = 0;
            this.ds_tpproduto.ReadOnly = true;
            this.ds_tpproduto.Size = new System.Drawing.Size(424, 20);
            this.ds_tpproduto.ST_AutoInc = false;
            this.ds_tpproduto.ST_DisableAuto = false;
            this.ds_tpproduto.ST_Float = false;
            this.ds_tpproduto.ST_Gravar = false;
            this.ds_tpproduto.ST_Int = false;
            this.ds_tpproduto.ST_LimpaCampo = true;
            this.ds_tpproduto.ST_NotNull = false;
            this.ds_tpproduto.ST_PrimaryKey = false;
            this.ds_tpproduto.TabIndex = 9;
            this.ds_tpproduto.TextOld = null;
            // 
            // BB_TpProduto
            // 
            this.BB_TpProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_TpProduto.Image = ((System.Drawing.Image)(resources.GetObject("BB_TpProduto.Image")));
            this.BB_TpProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_TpProduto.Location = new System.Drawing.Point(147, 107);
            this.BB_TpProduto.Name = "BB_TpProduto";
            this.BB_TpProduto.Size = new System.Drawing.Size(30, 20);
            this.BB_TpProduto.TabIndex = 8;
            this.BB_TpProduto.UseVisualStyleBackColor = true;
            this.BB_TpProduto.Click += new System.EventHandler(this.BB_TpProduto_Click);
            // 
            // LB_CD_Grupo
            // 
            this.LB_CD_Grupo.AutoSize = true;
            this.LB_CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Grupo.Location = new System.Drawing.Point(14, 59);
            this.LB_CD_Grupo.Name = "LB_CD_Grupo";
            this.LB_CD_Grupo.Size = new System.Drawing.Size(67, 13);
            this.LB_CD_Grupo.TabIndex = 4;
            this.LB_CD_Grupo.Text = "Grupo Prod.:";
            this.LB_CD_Grupo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "DS_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Produto.Location = new System.Drawing.Point(87, 29);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "a";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.Size = new System.Drawing.Size(519, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = true;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = true;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 2;
            this.DS_Produto.TextOld = null;
            // 
            // CD_Unidade
            // 
            this.CD_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "CD_Unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Unidade.Location = new System.Drawing.Point(87, 133);
            this.CD_Unidade.Name = "CD_Unidade";
            this.CD_Unidade.NM_Alias = "a";
            this.CD_Unidade.NM_Campo = "CD_Unidade";
            this.CD_Unidade.NM_CampoBusca = "CD_Unidade";
            this.CD_Unidade.NM_Param = "@P_CD_UNIDADE";
            this.CD_Unidade.QTD_Zero = 0;
            this.CD_Unidade.Size = new System.Drawing.Size(56, 20);
            this.CD_Unidade.ST_AutoInc = false;
            this.CD_Unidade.ST_DisableAuto = false;
            this.CD_Unidade.ST_Float = false;
            this.CD_Unidade.ST_Gravar = true;
            this.CD_Unidade.ST_Int = false;
            this.CD_Unidade.ST_LimpaCampo = true;
            this.CD_Unidade.ST_NotNull = true;
            this.CD_Unidade.ST_PrimaryKey = false;
            this.CD_Unidade.TabIndex = 9;
            this.CD_Unidade.TextOld = null;
            this.CD_Unidade.Leave += new System.EventHandler(this.CD_Unidade_Leave);
            // 
            // LB_CD_Unidade
            // 
            this.LB_CD_Unidade.AutoSize = true;
            this.LB_CD_Unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Unidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Unidade.Location = new System.Drawing.Point(31, 136);
            this.LB_CD_Unidade.Name = "LB_CD_Unidade";
            this.LB_CD_Unidade.Size = new System.Drawing.Size(50, 13);
            this.LB_CD_Unidade.TabIndex = 5;
            this.LB_CD_Unidade.Text = "Unidade:";
            this.LB_CD_Unidade.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.Color.White;
            this.sigla_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sigla_unidade.Location = new System.Drawing.Point(584, 133);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "sigla_unidade";
            this.sigla_unidade.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidade.NM_Param = "";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.ReadOnly = true;
            this.sigla_unidade.Size = new System.Drawing.Size(22, 20);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 18;
            this.sigla_unidade.TextOld = null;
            // 
            // ds_condfiscal_produto
            // 
            this.ds_condfiscal_produto.BackColor = System.Drawing.Color.White;
            this.ds_condfiscal_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_condfiscal_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condfiscal_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "DS_CondFiscal_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_condfiscal_produto.Enabled = false;
            this.ds_condfiscal_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_condfiscal_produto.Location = new System.Drawing.Point(182, 81);
            this.ds_condfiscal_produto.Name = "ds_condfiscal_produto";
            this.ds_condfiscal_produto.NM_Alias = "";
            this.ds_condfiscal_produto.NM_Campo = "ds_condfiscal_produto";
            this.ds_condfiscal_produto.NM_CampoBusca = "ds_condfiscal_produto";
            this.ds_condfiscal_produto.NM_Param = "";
            this.ds_condfiscal_produto.QTD_Zero = 0;
            this.ds_condfiscal_produto.ReadOnly = true;
            this.ds_condfiscal_produto.Size = new System.Drawing.Size(424, 20);
            this.ds_condfiscal_produto.ST_AutoInc = false;
            this.ds_condfiscal_produto.ST_DisableAuto = false;
            this.ds_condfiscal_produto.ST_Float = false;
            this.ds_condfiscal_produto.ST_Gravar = false;
            this.ds_condfiscal_produto.ST_Int = false;
            this.ds_condfiscal_produto.ST_LimpaCampo = true;
            this.ds_condfiscal_produto.ST_NotNull = false;
            this.ds_condfiscal_produto.ST_PrimaryKey = false;
            this.ds_condfiscal_produto.TabIndex = 6;
            this.ds_condfiscal_produto.TextOld = null;
            // 
            // LB_DS_Produto
            // 
            this.LB_DS_Produto.AutoSize = true;
            this.LB_DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_DS_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_Produto.Location = new System.Drawing.Point(34, 32);
            this.LB_DS_Produto.Name = "LB_DS_Produto";
            this.LB_DS_Produto.Size = new System.Drawing.Size(47, 13);
            this.LB_DS_Produto.TabIndex = 2;
            this.LB_DS_Produto.Text = "Produto:";
            this.LB_DS_Produto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CD_CondFiscal_Produto
            // 
            this.CD_CondFiscal_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CondFiscal_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CondFiscal_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CondFiscal_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "CD_CondFiscal_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_CondFiscal_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_CondFiscal_Produto.Location = new System.Drawing.Point(87, 81);
            this.CD_CondFiscal_Produto.Name = "CD_CondFiscal_Produto";
            this.CD_CondFiscal_Produto.NM_Alias = "a";
            this.CD_CondFiscal_Produto.NM_Campo = "CD_CondFiscal_Produto";
            this.CD_CondFiscal_Produto.NM_CampoBusca = "CD_CondFiscal_Produto";
            this.CD_CondFiscal_Produto.NM_Param = "@P_CD_CONDFISCAL_PRODUTO";
            this.CD_CondFiscal_Produto.QTD_Zero = 0;
            this.CD_CondFiscal_Produto.Size = new System.Drawing.Size(56, 20);
            this.CD_CondFiscal_Produto.ST_AutoInc = false;
            this.CD_CondFiscal_Produto.ST_DisableAuto = false;
            this.CD_CondFiscal_Produto.ST_Float = false;
            this.CD_CondFiscal_Produto.ST_Gravar = true;
            this.CD_CondFiscal_Produto.ST_Int = false;
            this.CD_CondFiscal_Produto.ST_LimpaCampo = true;
            this.CD_CondFiscal_Produto.ST_NotNull = true;
            this.CD_CondFiscal_Produto.ST_PrimaryKey = false;
            this.CD_CondFiscal_Produto.TabIndex = 5;
            this.CD_CondFiscal_Produto.TextOld = null;
            this.CD_CondFiscal_Produto.Leave += new System.EventHandler(this.CD_CondFiscal_Produto_Leave);
            // 
            // BB_CondFiscalProduto
            // 
            this.BB_CondFiscalProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_CondFiscalProduto.Image = ((System.Drawing.Image)(resources.GetObject("BB_CondFiscalProduto.Image")));
            this.BB_CondFiscalProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_CondFiscalProduto.Location = new System.Drawing.Point(147, 81);
            this.BB_CondFiscalProduto.Name = "BB_CondFiscalProduto";
            this.BB_CondFiscalProduto.Size = new System.Drawing.Size(30, 20);
            this.BB_CondFiscalProduto.TabIndex = 6;
            this.BB_CondFiscalProduto.UseVisualStyleBackColor = true;
            this.BB_CondFiscalProduto.Click += new System.EventHandler(this.BB_CondFiscalProduto_Click);
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.Color.White;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "CD_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Produto.Location = new System.Drawing.Point(87, 3);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "a";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(92, 20);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = true;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 0;
            this.CD_Produto.TextOld = null;
            // 
            // LB_TP_Produto
            // 
            this.LB_TP_Produto.AutoSize = true;
            this.LB_TP_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_TP_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_TP_Produto.Location = new System.Drawing.Point(10, 110);
            this.LB_TP_Produto.Name = "LB_TP_Produto";
            this.LB_TP_Produto.Size = new System.Drawing.Size(71, 13);
            this.LB_TP_Produto.TabIndex = 6;
            this.LB_TP_Produto.Text = "Tipo Produto:";
            this.LB_TP_Produto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_CD_CondFiscal_Produto
            // 
            this.LB_CD_CondFiscal_Produto.AutoSize = true;
            this.LB_CD_CondFiscal_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_CondFiscal_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_CondFiscal_Produto.Location = new System.Drawing.Point(13, 84);
            this.LB_CD_CondFiscal_Produto.Name = "LB_CD_CondFiscal_Produto";
            this.LB_CD_CondFiscal_Produto.Size = new System.Drawing.Size(68, 13);
            this.LB_CD_CondFiscal_Produto.TabIndex = 10;
            this.LB_CD_CondFiscal_Produto.Text = "Cond. Fiscal:";
            this.LB_CD_CondFiscal_Produto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DS_Grupo
            // 
            this.DS_Grupo.BackColor = System.Drawing.Color.White;
            this.DS_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "DS_Grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Grupo.Enabled = false;
            this.DS_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Grupo.Location = new System.Drawing.Point(182, 55);
            this.DS_Grupo.Name = "DS_Grupo";
            this.DS_Grupo.NM_Alias = "a";
            this.DS_Grupo.NM_Campo = "ds_grupo";
            this.DS_Grupo.NM_CampoBusca = "ds_grupo";
            this.DS_Grupo.NM_Param = "";
            this.DS_Grupo.QTD_Zero = 0;
            this.DS_Grupo.ReadOnly = true;
            this.DS_Grupo.Size = new System.Drawing.Size(424, 20);
            this.DS_Grupo.ST_AutoInc = false;
            this.DS_Grupo.ST_DisableAuto = false;
            this.DS_Grupo.ST_Float = false;
            this.DS_Grupo.ST_Gravar = false;
            this.DS_Grupo.ST_Int = false;
            this.DS_Grupo.ST_LimpaCampo = true;
            this.DS_Grupo.ST_NotNull = false;
            this.DS_Grupo.ST_PrimaryKey = false;
            this.DS_Grupo.TabIndex = 4;
            this.DS_Grupo.TextOld = null;
            // 
            // BB_Unidade
            // 
            this.BB_Unidade.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Unidade.Image = ((System.Drawing.Image)(resources.GetObject("BB_Unidade.Image")));
            this.BB_Unidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Unidade.Location = new System.Drawing.Point(147, 133);
            this.BB_Unidade.Name = "BB_Unidade";
            this.BB_Unidade.Size = new System.Drawing.Size(30, 20);
            this.BB_Unidade.TabIndex = 10;
            this.BB_Unidade.UseVisualStyleBackColor = true;
            this.BB_Unidade.Click += new System.EventHandler(this.BB_Unidade_Click);
            // 
            // BB_GrupoProduto
            // 
            this.BB_GrupoProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_GrupoProduto.Image = ((System.Drawing.Image)(resources.GetObject("BB_GrupoProduto.Image")));
            this.BB_GrupoProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_GrupoProduto.Location = new System.Drawing.Point(147, 55);
            this.BB_GrupoProduto.Name = "BB_GrupoProduto";
            this.BB_GrupoProduto.Size = new System.Drawing.Size(30, 20);
            this.BB_GrupoProduto.TabIndex = 4;
            this.BB_GrupoProduto.UseVisualStyleBackColor = true;
            this.BB_GrupoProduto.Click += new System.EventHandler(this.BB_GrupoProduto_Click);
            // 
            // ds_unidade
            // 
            this.ds_unidade.BackColor = System.Drawing.Color.White;
            this.ds_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "DS_Unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_unidade.Enabled = false;
            this.ds_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_unidade.Location = new System.Drawing.Point(182, 133);
            this.ds_unidade.Name = "ds_unidade";
            this.ds_unidade.NM_Alias = "";
            this.ds_unidade.NM_Campo = "ds_unidade";
            this.ds_unidade.NM_CampoBusca = "ds_unidade";
            this.ds_unidade.NM_Param = "@P_DS_UNIDADE";
            this.ds_unidade.QTD_Zero = 0;
            this.ds_unidade.ReadOnly = true;
            this.ds_unidade.Size = new System.Drawing.Size(400, 20);
            this.ds_unidade.ST_AutoInc = false;
            this.ds_unidade.ST_DisableAuto = false;
            this.ds_unidade.ST_Float = false;
            this.ds_unidade.ST_Gravar = false;
            this.ds_unidade.ST_Int = false;
            this.ds_unidade.ST_LimpaCampo = true;
            this.ds_unidade.ST_NotNull = false;
            this.ds_unidade.ST_PrimaryKey = false;
            this.ds_unidade.TabIndex = 17;
            this.ds_unidade.TextOld = null;
            // 
            // TP_Produto
            // 
            this.TP_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "TP_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TP_Produto.Location = new System.Drawing.Point(87, 107);
            this.TP_Produto.Name = "TP_Produto";
            this.TP_Produto.NM_Alias = "a";
            this.TP_Produto.NM_Campo = "TP_Produto";
            this.TP_Produto.NM_CampoBusca = "TP_Produto";
            this.TP_Produto.NM_Param = "@P_TP_PRODUTO";
            this.TP_Produto.QTD_Zero = 0;
            this.TP_Produto.Size = new System.Drawing.Size(56, 20);
            this.TP_Produto.ST_AutoInc = false;
            this.TP_Produto.ST_DisableAuto = false;
            this.TP_Produto.ST_Float = false;
            this.TP_Produto.ST_Gravar = true;
            this.TP_Produto.ST_Int = false;
            this.TP_Produto.ST_LimpaCampo = true;
            this.TP_Produto.ST_NotNull = true;
            this.TP_Produto.ST_PrimaryKey = false;
            this.TP_Produto.TabIndex = 7;
            this.TP_Produto.TextOld = null;
            this.TP_Produto.Leave += new System.EventHandler(this.TP_Produto_Leave);
            // 
            // cod_barras
            // 
            this.cod_barras.BackColor = System.Drawing.SystemColors.Window;
            this.cod_barras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cod_barras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cod_barras.Location = new System.Drawing.Point(87, 238);
            this.cod_barras.Name = "cod_barras";
            this.cod_barras.NM_Alias = "";
            this.cod_barras.NM_Campo = "";
            this.cod_barras.NM_CampoBusca = "";
            this.cod_barras.NM_Param = "";
            this.cod_barras.QTD_Zero = 0;
            this.cod_barras.Size = new System.Drawing.Size(519, 20);
            this.cod_barras.ST_AutoInc = false;
            this.cod_barras.ST_DisableAuto = false;
            this.cod_barras.ST_Float = false;
            this.cod_barras.ST_Gravar = false;
            this.cod_barras.ST_Int = false;
            this.cod_barras.ST_LimpaCampo = true;
            this.cod_barras.ST_NotNull = false;
            this.cod_barras.ST_PrimaryKey = false;
            this.cod_barras.TabIndex = 919;
            this.cod_barras.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(18, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 920;
            this.label1.Text = "Cód. Barras:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TFAtualizaCadProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 416);
            this.Controls.Add(this.pDadosProd);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAtualizaCadProduto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizar Cadastro Produto";
            this.Load += new System.EventHandler(this.TFAtualizaCadProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAtualizaCadProduto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDadosProd.ResumeLayout(false);
            this.pDadosProd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDadosProd;
        private Componentes.EditDefault ncm;
        private System.Windows.Forms.Label LB_cd_ClassifFiscal;
        private System.Windows.Forms.Button bb_ncm;
        private Componentes.EditDefault ds_ncm;
        private System.Windows.Forms.Label lblCodAlternativo;
        private System.Windows.Forms.Label LB_CD_Produto;
        private Componentes.EditDefault CD_Grupo;
        private Componentes.EditDefault ds_tpproduto;
        public System.Windows.Forms.Button BB_TpProduto;
        private System.Windows.Forms.Label LB_CD_Grupo;
        private Componentes.EditDefault DS_Produto;
        private Componentes.EditDefault CD_Unidade;
        private System.Windows.Forms.Label LB_CD_Unidade;
        private Componentes.EditDefault sigla_unidade;
        private Componentes.EditDefault ds_condfiscal_produto;
        private System.Windows.Forms.Label LB_DS_Produto;
        private Componentes.EditDefault CD_CondFiscal_Produto;
        public System.Windows.Forms.Button BB_CondFiscalProduto;
        private Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.Label LB_TP_Produto;
        private System.Windows.Forms.Label LB_CD_CondFiscal_Produto;
        private Componentes.EditDefault DS_Grupo;
        public System.Windows.Forms.Button BB_Unidade;
        public System.Windows.Forms.Button BB_GrupoProduto;
        private Componentes.EditDefault ds_unidade;
        private Componentes.EditDefault TP_Produto;
        private Componentes.EditDefault ds_anp;
        private System.Windows.Forms.Button bb_anp;
        private System.Windows.Forms.Label label12;
        private Componentes.EditDefault cd_anp;
        private System.Windows.Forms.BindingSource bsProduto;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault codigo_alternativo;
        private Componentes.EditDefault DS_Tecnica;
        private System.Windows.Forms.Label label4;
        private Componentes.ComboBoxDefault tp_item;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bb_saldoest;
        private Componentes.EditDefault cod_barras;
        private System.Windows.Forms.Label label1;
    }
}