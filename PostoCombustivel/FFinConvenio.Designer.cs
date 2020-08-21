namespace PostoCombustivel
{
    partial class TFFinConvenio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFFinConvenio));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.rgFin = new Componentes.RadioGroup(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.diavencto = new Componentes.EditFloat(this.components);
            this.bsFinConvenio = new System.Windows.Forms.BindingSource(this.components);
            this.ds_condpgto = new Componentes.EditDefault(this.components);
            this.bb_condpgto = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cd_condpgto = new Componentes.EditDefault(this.components);
            this.ds_tpdocto = new Componentes.EditDefault(this.components);
            this.bb_tpdocto = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tp_docto = new Componentes.EditDefault(this.components);
            this.ds_tpduplicata = new Componentes.EditDefault(this.components);
            this.bb_tpduplicata = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tp_duplicata = new Componentes.EditDefault(this.components);
            this.tp_desconto = new Componentes.ComboBoxDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.desconto = new Componentes.EditFloat(this.components);
            this.ds_portador = new Componentes.EditDefault(this.components);
            this.bb_portador = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_portador = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.rgFin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diavencto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFinConvenio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.desconto)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(686, 43);
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.rgFin);
            this.pDados.Controls.Add(this.tp_desconto);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.desconto);
            this.pDados.Controls.Add(this.ds_portador);
            this.pDados.Controls.Add(this.bb_portador);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_portador);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(686, 268);
            this.pDados.TabIndex = 13;
            // 
            // rgFin
            // 
            this.rgFin.Controls.Add(this.label9);
            this.rgFin.Controls.Add(this.diavencto);
            this.rgFin.Controls.Add(this.ds_condpgto);
            this.rgFin.Controls.Add(this.bb_condpgto);
            this.rgFin.Controls.Add(this.label7);
            this.rgFin.Controls.Add(this.cd_condpgto);
            this.rgFin.Controls.Add(this.ds_tpdocto);
            this.rgFin.Controls.Add(this.bb_tpdocto);
            this.rgFin.Controls.Add(this.label6);
            this.rgFin.Controls.Add(this.tp_docto);
            this.rgFin.Controls.Add(this.ds_tpduplicata);
            this.rgFin.Controls.Add(this.bb_tpduplicata);
            this.rgFin.Controls.Add(this.label5);
            this.rgFin.Controls.Add(this.tp_duplicata);
            this.rgFin.Location = new System.Drawing.Point(76, 84);
            this.rgFin.Name = "rgFin";
            this.rgFin.NM_Alias = "";
            this.rgFin.NM_Campo = "";
            this.rgFin.NM_Param = "";
            this.rgFin.NM_Valor = "";
            this.rgFin.Size = new System.Drawing.Size(603, 176);
            this.rgFin.ST_Gravar = false;
            this.rgFin.ST_NotNull = false;
            this.rgFin.TabIndex = 6;
            this.rgFin.TabStop = false;
            this.rgFin.Text = "Parametros Financeiro";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(4, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 60;
            this.label9.Text = "Dia Vencimento";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diavencto
            // 
            this.diavencto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFinConvenio, "Diavencto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"));
            this.diavencto.Location = new System.Drawing.Point(7, 149);
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
            this.diavencto.Size = new System.Drawing.Size(75, 20);
            this.diavencto.ST_AutoInc = false;
            this.diavencto.ST_DisableAuto = false;
            this.diavencto.ST_Gravar = true;
            this.diavencto.ST_LimparCampo = true;
            this.diavencto.ST_NotNull = false;
            this.diavencto.ST_PrimaryKey = false;
            this.diavencto.TabIndex = 8;
            this.diavencto.ThousandsSeparator = true;
            // 
            // bsFinConvenio
            // 
            this.bsFinConvenio.DataSource = typeof(CamadaDados.PostoCombustivel.TList_FinConvenio);
            // 
            // ds_condpgto
            // 
            this.ds_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinConvenio, "Ds_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_condpgto.Enabled = false;
            this.ds_condpgto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_condpgto.Location = new System.Drawing.Point(115, 110);
            this.ds_condpgto.Name = "ds_condpgto";
            this.ds_condpgto.NM_Alias = "";
            this.ds_condpgto.NM_Campo = "ds_condpgto";
            this.ds_condpgto.NM_CampoBusca = "ds_condpgto";
            this.ds_condpgto.NM_Param = "@P_NM_EMPRESA";
            this.ds_condpgto.QTD_Zero = 0;
            this.ds_condpgto.ReadOnly = true;
            this.ds_condpgto.Size = new System.Drawing.Size(482, 20);
            this.ds_condpgto.ST_AutoInc = false;
            this.ds_condpgto.ST_DisableAuto = false;
            this.ds_condpgto.ST_Float = false;
            this.ds_condpgto.ST_Gravar = false;
            this.ds_condpgto.ST_Int = false;
            this.ds_condpgto.ST_LimpaCampo = true;
            this.ds_condpgto.ST_NotNull = false;
            this.ds_condpgto.ST_PrimaryKey = false;
            this.ds_condpgto.TabIndex = 54;
            // 
            // bb_condpgto
            // 
            this.bb_condpgto.Image = ((System.Drawing.Image)(resources.GetObject("bb_condpgto.Image")));
            this.bb_condpgto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_condpgto.Location = new System.Drawing.Point(84, 110);
            this.bb_condpgto.Name = "bb_condpgto";
            this.bb_condpgto.Size = new System.Drawing.Size(28, 19);
            this.bb_condpgto.TabIndex = 5;
            this.bb_condpgto.UseVisualStyleBackColor = true;
            this.bb_condpgto.Click += new System.EventHandler(this.bb_condpgto_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(4, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Condição Pagamento";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_condpgto
            // 
            this.cd_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinConvenio, "Cd_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_condpgto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_condpgto.Location = new System.Drawing.Point(7, 110);
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
            this.cd_condpgto.TabIndex = 4;
            this.cd_condpgto.Leave += new System.EventHandler(this.cd_condpgto_Leave);
            // 
            // ds_tpdocto
            // 
            this.ds_tpdocto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpdocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpdocto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinConvenio, "Ds_tpdocto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpdocto.Enabled = false;
            this.ds_tpdocto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tpdocto.Location = new System.Drawing.Point(115, 71);
            this.ds_tpdocto.Name = "ds_tpdocto";
            this.ds_tpdocto.NM_Alias = "";
            this.ds_tpdocto.NM_Campo = "ds_tpdocto";
            this.ds_tpdocto.NM_CampoBusca = "ds_tpdocto";
            this.ds_tpdocto.NM_Param = "@P_NM_EMPRESA";
            this.ds_tpdocto.QTD_Zero = 0;
            this.ds_tpdocto.ReadOnly = true;
            this.ds_tpdocto.Size = new System.Drawing.Size(482, 20);
            this.ds_tpdocto.ST_AutoInc = false;
            this.ds_tpdocto.ST_DisableAuto = false;
            this.ds_tpdocto.ST_Float = false;
            this.ds_tpdocto.ST_Gravar = false;
            this.ds_tpdocto.ST_Int = false;
            this.ds_tpdocto.ST_LimpaCampo = true;
            this.ds_tpdocto.ST_NotNull = false;
            this.ds_tpdocto.ST_PrimaryKey = false;
            this.ds_tpdocto.TabIndex = 50;
            // 
            // bb_tpdocto
            // 
            this.bb_tpdocto.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpdocto.Image")));
            this.bb_tpdocto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpdocto.Location = new System.Drawing.Point(84, 71);
            this.bb_tpdocto.Name = "bb_tpdocto";
            this.bb_tpdocto.Size = new System.Drawing.Size(28, 19);
            this.bb_tpdocto.TabIndex = 3;
            this.bb_tpdocto.UseVisualStyleBackColor = true;
            this.bb_tpdocto.Click += new System.EventHandler(this.bb_tpdocto_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(4, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Tipo Documento";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_docto
            // 
            this.tp_docto.BackColor = System.Drawing.SystemColors.Window;
            this.tp_docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_docto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinConvenio, "Tp_doctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_docto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_docto.Location = new System.Drawing.Point(7, 71);
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
            this.tp_docto.TabIndex = 2;
            this.tp_docto.Leave += new System.EventHandler(this.tp_docto_Leave);
            // 
            // ds_tpduplicata
            // 
            this.ds_tpduplicata.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpduplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpduplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinConvenio, "Ds_tpduplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpduplicata.Enabled = false;
            this.ds_tpduplicata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tpduplicata.Location = new System.Drawing.Point(114, 32);
            this.ds_tpduplicata.Name = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Alias = "";
            this.ds_tpduplicata.NM_Campo = "ds_tpduplicata";
            this.ds_tpduplicata.NM_CampoBusca = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Param = "@P_NM_EMPRESA";
            this.ds_tpduplicata.QTD_Zero = 0;
            this.ds_tpduplicata.ReadOnly = true;
            this.ds_tpduplicata.Size = new System.Drawing.Size(482, 20);
            this.ds_tpduplicata.ST_AutoInc = false;
            this.ds_tpduplicata.ST_DisableAuto = false;
            this.ds_tpduplicata.ST_Float = false;
            this.ds_tpduplicata.ST_Gravar = false;
            this.ds_tpduplicata.ST_Int = false;
            this.ds_tpduplicata.ST_LimpaCampo = true;
            this.ds_tpduplicata.ST_NotNull = false;
            this.ds_tpduplicata.ST_PrimaryKey = false;
            this.ds_tpduplicata.TabIndex = 46;
            // 
            // bb_tpduplicata
            // 
            this.bb_tpduplicata.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpduplicata.Image")));
            this.bb_tpduplicata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpduplicata.Location = new System.Drawing.Point(83, 32);
            this.bb_tpduplicata.Name = "bb_tpduplicata";
            this.bb_tpduplicata.Size = new System.Drawing.Size(28, 19);
            this.bb_tpduplicata.TabIndex = 1;
            this.bb_tpduplicata.UseVisualStyleBackColor = true;
            this.bb_tpduplicata.Click += new System.EventHandler(this.bb_tpduplicata_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(3, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Tipo Duplicata";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_duplicata
            // 
            this.tp_duplicata.BackColor = System.Drawing.SystemColors.Window;
            this.tp_duplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_duplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinConvenio, "Tp_duplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_duplicata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_duplicata.Location = new System.Drawing.Point(6, 32);
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
            this.tp_duplicata.TabIndex = 0;
            this.tp_duplicata.Leave += new System.EventHandler(this.tp_duplicata_Leave);
            // 
            // tp_desconto
            // 
            this.tp_desconto.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsFinConvenio, "Tp_desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_desconto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_desconto.FormattingEnabled = true;
            this.tp_desconto.Location = new System.Drawing.Point(243, 57);
            this.tp_desconto.Name = "tp_desconto";
            this.tp_desconto.NM_Alias = "";
            this.tp_desconto.NM_Campo = "";
            this.tp_desconto.NM_Param = "";
            this.tp_desconto.Size = new System.Drawing.Size(146, 21);
            this.tp_desconto.ST_Gravar = true;
            this.tp_desconto.ST_LimparCampo = true;
            this.tp_desconto.ST_NotNull = false;
            this.tp_desconto.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(157, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Tipo Desconto:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(14, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Desconto:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // desconto
            // 
            this.desconto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFinConvenio, "Desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.desconto.DecimalPlaces = 2;
            this.desconto.Location = new System.Drawing.Point(76, 57);
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
            this.desconto.Size = new System.Drawing.Size(75, 20);
            this.desconto.ST_AutoInc = false;
            this.desconto.ST_DisableAuto = false;
            this.desconto.ST_Gravar = true;
            this.desconto.ST_LimparCampo = true;
            this.desconto.ST_NotNull = false;
            this.desconto.ST_PrimaryKey = false;
            this.desconto.TabIndex = 4;
            this.desconto.ThousandsSeparator = true;
            // 
            // ds_portador
            // 
            this.ds_portador.BackColor = System.Drawing.SystemColors.Window;
            this.ds_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinConvenio, "Ds_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_portador.Enabled = false;
            this.ds_portador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_portador.Location = new System.Drawing.Point(184, 31);
            this.ds_portador.Name = "ds_portador";
            this.ds_portador.NM_Alias = "";
            this.ds_portador.NM_Campo = "ds_portador";
            this.ds_portador.NM_CampoBusca = "ds_portador";
            this.ds_portador.NM_Param = "@P_NM_EMPRESA";
            this.ds_portador.QTD_Zero = 0;
            this.ds_portador.ReadOnly = true;
            this.ds_portador.Size = new System.Drawing.Size(495, 20);
            this.ds_portador.ST_AutoInc = false;
            this.ds_portador.ST_DisableAuto = false;
            this.ds_portador.ST_Float = false;
            this.ds_portador.ST_Gravar = false;
            this.ds_portador.ST_Int = false;
            this.ds_portador.ST_LimpaCampo = true;
            this.ds_portador.ST_NotNull = false;
            this.ds_portador.ST_PrimaryKey = false;
            this.ds_portador.TabIndex = 42;
            // 
            // bb_portador
            // 
            this.bb_portador.Image = ((System.Drawing.Image)(resources.GetObject("bb_portador.Image")));
            this.bb_portador.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_portador.Location = new System.Drawing.Point(153, 31);
            this.bb_portador.Name = "bb_portador";
            this.bb_portador.Size = new System.Drawing.Size(28, 19);
            this.bb_portador.TabIndex = 3;
            this.bb_portador.UseVisualStyleBackColor = true;
            this.bb_portador.Click += new System.EventHandler(this.bb_portador_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(20, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Portador:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_portador
            // 
            this.cd_portador.BackColor = System.Drawing.SystemColors.Window;
            this.cd_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinConvenio, "Cd_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_portador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_portador.Location = new System.Drawing.Point(76, 31);
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
            this.cd_portador.ST_NotNull = true;
            this.cd_portador.ST_PrimaryKey = false;
            this.cd_portador.TabIndex = 2;
            this.cd_portador.Leave += new System.EventHandler(this.cd_portador_Leave);
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinConvenio, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_produto.Location = new System.Drawing.Point(184, 5);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_NM_EMPRESA";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.ReadOnly = true;
            this.ds_produto.Size = new System.Drawing.Size(495, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 40;
            // 
            // bb_produto
            // 
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(153, 5);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 1;
            this.bb_produto.UseVisualStyleBackColor = true;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Combustivel:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinConvenio, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(76, 5);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
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
            this.cd_produto.TabIndex = 0;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // TFFinConvenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 311);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFFinConvenio";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financeiro Convenio";
            this.Load += new System.EventHandler(this.TFFinConvenio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFFinConvenio_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.rgFin.ResumeLayout(false);
            this.rgFin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diavencto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFinConvenio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.desconto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_portador;
        private System.Windows.Forms.Button bb_portador;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_portador;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Button bb_produto;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_produto;
        private Componentes.ComboBoxDefault tp_desconto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat desconto;
        private System.Windows.Forms.BindingSource bsFinConvenio;
        private Componentes.RadioGroup rgFin;
        private Componentes.EditDefault ds_condpgto;
        private System.Windows.Forms.Button bb_condpgto;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault cd_condpgto;
        private Componentes.EditDefault ds_tpdocto;
        private System.Windows.Forms.Button bb_tpdocto;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault tp_docto;
        private Componentes.EditDefault ds_tpduplicata;
        private System.Windows.Forms.Button bb_tpduplicata;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault tp_duplicata;
        private System.Windows.Forms.Label label9;
        private Componentes.EditFloat diavencto;
    }
}