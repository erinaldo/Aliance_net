namespace PDV
{
    partial class TFCartaFrete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCartaFrete));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsCartaFrete = new System.Windows.Forms.BindingSource(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.kilometragem = new Componentes.EditFloat(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nr_frota = new Componentes.EditDefault(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.placa = new Componentes.EditMask(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.nm_motorista = new Componentes.EditDefault(this.components);
            this.ds_endunidpagadora = new Componentes.EditDefault(this.components);
            this.bb_endunidpagadora = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cd_endunidpagadora = new Componentes.EditDefault(this.components);
            this.nm_unidpagadora = new Componentes.EditDefault(this.components);
            this.bb_unidpagadora = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cd_unidpagadora = new Componentes.EditDefault(this.components);
            this.vl_documento = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dt_vencimento = new Componentes.EditData(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.dt_emissao = new Componentes.EditData(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.nr_cartafrete = new Componentes.EditDefault(this.components);
            this.ds_enderecotransp = new Componentes.EditDefault(this.components);
            this.bb_enderecotransp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cd_enderecotransp = new Componentes.EditDefault(this.components);
            this.nm_transportadora = new Componentes.EditDefault(this.components);
            this.bb_transportadora = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_transportadora = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartaFrete)).BeginInit();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kilometragem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(581, 43);
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
            // bsCartaFrete
            // 
            this.bsCartaFrete.DataSource = typeof(CamadaDados.PostoCombustivel.TList_CartaFrete);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.kilometragem);
            this.pDados.Controls.Add(this.label14);
            this.pDados.Controls.Add(this.label13);
            this.pDados.Controls.Add(this.nr_frota);
            this.pDados.Controls.Add(this.label12);
            this.pDados.Controls.Add(this.placa);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(this.nm_motorista);
            this.pDados.Controls.Add(this.ds_endunidpagadora);
            this.pDados.Controls.Add(this.bb_endunidpagadora);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.cd_endunidpagadora);
            this.pDados.Controls.Add(this.nm_unidpagadora);
            this.pDados.Controls.Add(this.bb_unidpagadora);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.cd_unidpagadora);
            this.pDados.Controls.Add(this.vl_documento);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.dt_vencimento);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.dt_emissao);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.nr_cartafrete);
            this.pDados.Controls.Add(this.ds_enderecotransp);
            this.pDados.Controls.Add(this.bb_enderecotransp);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.cd_enderecotransp);
            this.pDados.Controls.Add(this.nm_transportadora);
            this.pDados.Controls.Add(this.bb_transportadora);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_transportadora);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(581, 210);
            this.pDados.TabIndex = 14;
            // 
            // kilometragem
            // 
            this.kilometragem.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCartaFrete, "Kilometragem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.kilometragem.Location = new System.Drawing.Point(357, 185);
            this.kilometragem.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.kilometragem.Name = "kilometragem";
            this.kilometragem.NM_Alias = "";
            this.kilometragem.NM_Campo = "";
            this.kilometragem.NM_Param = "";
            this.kilometragem.Operador = "";
            this.kilometragem.Size = new System.Drawing.Size(91, 20);
            this.kilometragem.ST_AutoInc = false;
            this.kilometragem.ST_DisableAuto = false;
            this.kilometragem.ST_Gravar = false;
            this.kilometragem.ST_LimparCampo = true;
            this.kilometragem.ST_NotNull = false;
            this.kilometragem.ST_PrimaryKey = false;
            this.kilometragem.TabIndex = 18;
            this.kilometragem.ThousandsSeparator = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(278, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 453;
            this.label14.Text = "Kilometragem:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(157, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 452;
            this.label13.Text = "Frota:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nr_frota
            // 
            this.nr_frota.BackColor = System.Drawing.SystemColors.Window;
            this.nr_frota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_frota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_frota.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Nr_frota", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_frota.Location = new System.Drawing.Point(197, 186);
            this.nr_frota.Name = "nr_frota";
            this.nr_frota.NM_Alias = "";
            this.nr_frota.NM_Campo = "";
            this.nr_frota.NM_CampoBusca = "";
            this.nr_frota.NM_Param = "";
            this.nr_frota.QTD_Zero = 0;
            this.nr_frota.Size = new System.Drawing.Size(75, 20);
            this.nr_frota.ST_AutoInc = false;
            this.nr_frota.ST_DisableAuto = false;
            this.nr_frota.ST_Float = false;
            this.nr_frota.ST_Gravar = false;
            this.nr_frota.ST_Int = false;
            this.nr_frota.ST_LimpaCampo = true;
            this.nr_frota.ST_NotNull = false;
            this.nr_frota.ST_PrimaryKey = false;
            this.nr_frota.TabIndex = 17;
            this.nr_frota.TextOld = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(48, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 450;
            this.label12.Text = "Placa:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // placa
            // 
            this.placa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Placaveiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.placa.Location = new System.Drawing.Point(91, 185);
            this.placa.Mask = "AAA-9999";
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "";
            this.placa.NM_CampoBusca = "";
            this.placa.NM_Param = "";
            this.placa.Size = new System.Drawing.Size(60, 20);
            this.placa.ST_Gravar = true;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = false;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 16;
            this.placa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.placa_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(32, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 448;
            this.label11.Text = "Motorista:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nm_motorista
            // 
            this.nm_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.nm_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_motorista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Nm_motorista", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_motorista.Location = new System.Drawing.Point(91, 159);
            this.nm_motorista.Name = "nm_motorista";
            this.nm_motorista.NM_Alias = "";
            this.nm_motorista.NM_Campo = "";
            this.nm_motorista.NM_CampoBusca = "";
            this.nm_motorista.NM_Param = "";
            this.nm_motorista.QTD_Zero = 0;
            this.nm_motorista.Size = new System.Drawing.Size(485, 20);
            this.nm_motorista.ST_AutoInc = false;
            this.nm_motorista.ST_DisableAuto = false;
            this.nm_motorista.ST_Float = false;
            this.nm_motorista.ST_Gravar = false;
            this.nm_motorista.ST_Int = false;
            this.nm_motorista.ST_LimpaCampo = true;
            this.nm_motorista.ST_NotNull = false;
            this.nm_motorista.ST_PrimaryKey = false;
            this.nm_motorista.TabIndex = 15;
            this.nm_motorista.TextOld = null;
            // 
            // ds_endunidpagadora
            // 
            this.ds_endunidpagadora.BackColor = System.Drawing.SystemColors.Window;
            this.ds_endunidpagadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_endunidpagadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_endunidpagadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Ds_endunidpagadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_endunidpagadora.Enabled = false;
            this.ds_endunidpagadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_endunidpagadora.Location = new System.Drawing.Point(199, 107);
            this.ds_endunidpagadora.Name = "ds_endunidpagadora";
            this.ds_endunidpagadora.NM_Alias = "";
            this.ds_endunidpagadora.NM_Campo = "ds_endereco";
            this.ds_endunidpagadora.NM_CampoBusca = "ds_endereco";
            this.ds_endunidpagadora.NM_Param = "@P_NM_EMPRESA";
            this.ds_endunidpagadora.QTD_Zero = 0;
            this.ds_endunidpagadora.ReadOnly = true;
            this.ds_endunidpagadora.Size = new System.Drawing.Size(377, 20);
            this.ds_endunidpagadora.ST_AutoInc = false;
            this.ds_endunidpagadora.ST_DisableAuto = false;
            this.ds_endunidpagadora.ST_Float = false;
            this.ds_endunidpagadora.ST_Gravar = false;
            this.ds_endunidpagadora.ST_Int = false;
            this.ds_endunidpagadora.ST_LimpaCampo = true;
            this.ds_endunidpagadora.ST_NotNull = false;
            this.ds_endunidpagadora.ST_PrimaryKey = false;
            this.ds_endunidpagadora.TabIndex = 446;
            this.ds_endunidpagadora.TextOld = null;
            // 
            // bb_endunidpagadora
            // 
            this.bb_endunidpagadora.Image = ((System.Drawing.Image)(resources.GetObject("bb_endunidpagadora.Image")));
            this.bb_endunidpagadora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_endunidpagadora.Location = new System.Drawing.Point(168, 107);
            this.bb_endunidpagadora.Name = "bb_endunidpagadora";
            this.bb_endunidpagadora.Size = new System.Drawing.Size(28, 19);
            this.bb_endunidpagadora.TabIndex = 10;
            this.bb_endunidpagadora.UseVisualStyleBackColor = true;
            this.bb_endunidpagadora.Click += new System.EventHandler(this.bb_endunidpagadora_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(29, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 445;
            this.label9.Text = "Endereço:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_endunidpagadora
            // 
            this.cd_endunidpagadora.BackColor = System.Drawing.SystemColors.Window;
            this.cd_endunidpagadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_endunidpagadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_endunidpagadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Cd_endunidpagadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_endunidpagadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_endunidpagadora.Location = new System.Drawing.Point(91, 107);
            this.cd_endunidpagadora.Name = "cd_endunidpagadora";
            this.cd_endunidpagadora.NM_Alias = "";
            this.cd_endunidpagadora.NM_Campo = "cd_endereco";
            this.cd_endunidpagadora.NM_CampoBusca = "cd_endereco";
            this.cd_endunidpagadora.NM_Param = "@P_CD_EMPRESA";
            this.cd_endunidpagadora.QTD_Zero = 0;
            this.cd_endunidpagadora.Size = new System.Drawing.Size(75, 20);
            this.cd_endunidpagadora.ST_AutoInc = false;
            this.cd_endunidpagadora.ST_DisableAuto = false;
            this.cd_endunidpagadora.ST_Float = false;
            this.cd_endunidpagadora.ST_Gravar = true;
            this.cd_endunidpagadora.ST_Int = true;
            this.cd_endunidpagadora.ST_LimpaCampo = true;
            this.cd_endunidpagadora.ST_NotNull = false;
            this.cd_endunidpagadora.ST_PrimaryKey = false;
            this.cd_endunidpagadora.TabIndex = 9;
            this.cd_endunidpagadora.TextOld = null;
            this.cd_endunidpagadora.Leave += new System.EventHandler(this.cd_endunidpagadora_Leave);
            // 
            // nm_unidpagadora
            // 
            this.nm_unidpagadora.BackColor = System.Drawing.SystemColors.Window;
            this.nm_unidpagadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_unidpagadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_unidpagadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Nm_unidpagadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_unidpagadora.Enabled = false;
            this.nm_unidpagadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_unidpagadora.Location = new System.Drawing.Point(199, 81);
            this.nm_unidpagadora.Name = "nm_unidpagadora";
            this.nm_unidpagadora.NM_Alias = "";
            this.nm_unidpagadora.NM_Campo = "nm_clifor";
            this.nm_unidpagadora.NM_CampoBusca = "nm_clifor";
            this.nm_unidpagadora.NM_Param = "@P_NM_EMPRESA";
            this.nm_unidpagadora.QTD_Zero = 0;
            this.nm_unidpagadora.ReadOnly = true;
            this.nm_unidpagadora.Size = new System.Drawing.Size(377, 20);
            this.nm_unidpagadora.ST_AutoInc = false;
            this.nm_unidpagadora.ST_DisableAuto = false;
            this.nm_unidpagadora.ST_Float = false;
            this.nm_unidpagadora.ST_Gravar = false;
            this.nm_unidpagadora.ST_Int = false;
            this.nm_unidpagadora.ST_LimpaCampo = true;
            this.nm_unidpagadora.ST_NotNull = false;
            this.nm_unidpagadora.ST_PrimaryKey = false;
            this.nm_unidpagadora.TabIndex = 442;
            this.nm_unidpagadora.TextOld = null;
            // 
            // bb_unidpagadora
            // 
            this.bb_unidpagadora.Image = ((System.Drawing.Image)(resources.GetObject("bb_unidpagadora.Image")));
            this.bb_unidpagadora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_unidpagadora.Location = new System.Drawing.Point(168, 81);
            this.bb_unidpagadora.Name = "bb_unidpagadora";
            this.bb_unidpagadora.Size = new System.Drawing.Size(28, 19);
            this.bb_unidpagadora.TabIndex = 8;
            this.bb_unidpagadora.UseVisualStyleBackColor = true;
            this.bb_unidpagadora.Click += new System.EventHandler(this.bb_unidpagadora_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(35, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 441;
            this.label10.Text = "Pagador:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_unidpagadora
            // 
            this.cd_unidpagadora.BackColor = System.Drawing.SystemColors.Window;
            this.cd_unidpagadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_unidpagadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidpagadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Cd_unidpagadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_unidpagadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_unidpagadora.Location = new System.Drawing.Point(91, 81);
            this.cd_unidpagadora.Name = "cd_unidpagadora";
            this.cd_unidpagadora.NM_Alias = "";
            this.cd_unidpagadora.NM_Campo = "cd_clifor";
            this.cd_unidpagadora.NM_CampoBusca = "cd_clifor";
            this.cd_unidpagadora.NM_Param = "@P_CD_EMPRESA";
            this.cd_unidpagadora.QTD_Zero = 0;
            this.cd_unidpagadora.Size = new System.Drawing.Size(75, 20);
            this.cd_unidpagadora.ST_AutoInc = false;
            this.cd_unidpagadora.ST_DisableAuto = false;
            this.cd_unidpagadora.ST_Float = false;
            this.cd_unidpagadora.ST_Gravar = true;
            this.cd_unidpagadora.ST_Int = true;
            this.cd_unidpagadora.ST_LimpaCampo = true;
            this.cd_unidpagadora.ST_NotNull = false;
            this.cd_unidpagadora.ST_PrimaryKey = false;
            this.cd_unidpagadora.TabIndex = 7;
            this.cd_unidpagadora.TextOld = null;
            this.cd_unidpagadora.Leave += new System.EventHandler(this.cd_unidpagadora_Leave);
            // 
            // vl_documento
            // 
            this.vl_documento.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCartaFrete, "Vl_documento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_documento.DecimalPlaces = 2;
            this.vl_documento.Location = new System.Drawing.Point(485, 133);
            this.vl_documento.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_documento.Name = "vl_documento";
            this.vl_documento.NM_Alias = "";
            this.vl_documento.NM_Campo = "Valor Carta Frete";
            this.vl_documento.NM_Param = "@P_VALOR CARTA FRETE";
            this.vl_documento.Operador = "";
            this.vl_documento.Size = new System.Drawing.Size(91, 20);
            this.vl_documento.ST_AutoInc = false;
            this.vl_documento.ST_DisableAuto = false;
            this.vl_documento.ST_Gravar = true;
            this.vl_documento.ST_LimparCampo = true;
            this.vl_documento.ST_NotNull = true;
            this.vl_documento.ST_PrimaryKey = false;
            this.vl_documento.TabIndex = 14;
            this.vl_documento.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(445, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 437;
            this.label8.Text = "Valor:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(300, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 436;
            this.label7.Text = "Vencimento:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_vencimento
            // 
            this.dt_vencimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_vencimento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Dt_vencimentostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_vencimento.Location = new System.Drawing.Point(372, 133);
            this.dt_vencimento.Mask = "00/00/0000";
            this.dt_vencimento.Name = "dt_vencimento";
            this.dt_vencimento.NM_Alias = "";
            this.dt_vencimento.NM_Campo = "Data Vencimento";
            this.dt_vencimento.NM_CampoBusca = "Data Vencimento";
            this.dt_vencimento.NM_Param = "@P_DATA VENCIMENTO";
            this.dt_vencimento.Operador = "";
            this.dt_vencimento.Size = new System.Drawing.Size(67, 20);
            this.dt_vencimento.ST_Gravar = true;
            this.dt_vencimento.ST_LimpaCampo = true;
            this.dt_vencimento.ST_NotNull = true;
            this.dt_vencimento.ST_PrimaryKey = false;
            this.dt_vencimento.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(172, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 432;
            this.label5.Text = "Emissão:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_emissao
            // 
            this.dt_emissao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_emissao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Dt_emissaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_emissao.Location = new System.Drawing.Point(227, 133);
            this.dt_emissao.Mask = "00/00/0000";
            this.dt_emissao.Name = "dt_emissao";
            this.dt_emissao.NM_Alias = "";
            this.dt_emissao.NM_Campo = "Data Emissão";
            this.dt_emissao.NM_CampoBusca = "Data Emissão";
            this.dt_emissao.NM_Param = "@P_DATA EMISSÃO";
            this.dt_emissao.Operador = "";
            this.dt_emissao.Size = new System.Drawing.Size(67, 20);
            this.dt_emissao.ST_Gravar = true;
            this.dt_emissao.ST_LimpaCampo = true;
            this.dt_emissao.ST_NotNull = true;
            this.dt_emissao.ST_PrimaryKey = false;
            this.dt_emissao.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(23, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 430;
            this.label4.Text = "Carta Frete:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nr_cartafrete
            // 
            this.nr_cartafrete.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cartafrete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_cartafrete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cartafrete.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Nr_cartafrete", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_cartafrete.Location = new System.Drawing.Point(91, 133);
            this.nr_cartafrete.Name = "nr_cartafrete";
            this.nr_cartafrete.NM_Alias = "";
            this.nr_cartafrete.NM_Campo = "Nº Carta Frete";
            this.nr_cartafrete.NM_CampoBusca = "Nº Carta Frete";
            this.nr_cartafrete.NM_Param = "@P_Nº CARTA FRETE";
            this.nr_cartafrete.QTD_Zero = 0;
            this.nr_cartafrete.Size = new System.Drawing.Size(75, 20);
            this.nr_cartafrete.ST_AutoInc = false;
            this.nr_cartafrete.ST_DisableAuto = false;
            this.nr_cartafrete.ST_Float = false;
            this.nr_cartafrete.ST_Gravar = true;
            this.nr_cartafrete.ST_Int = false;
            this.nr_cartafrete.ST_LimpaCampo = true;
            this.nr_cartafrete.ST_NotNull = true;
            this.nr_cartafrete.ST_PrimaryKey = false;
            this.nr_cartafrete.TabIndex = 11;
            this.nr_cartafrete.TextOld = null;
            this.nr_cartafrete.Leave += new System.EventHandler(this.nr_cartafrete_Leave);
            // 
            // ds_enderecotransp
            // 
            this.ds_enderecotransp.BackColor = System.Drawing.SystemColors.Window;
            this.ds_enderecotransp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_enderecotransp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_enderecotransp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Ds_enderecotransp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_enderecotransp.Enabled = false;
            this.ds_enderecotransp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_enderecotransp.Location = new System.Drawing.Point(199, 55);
            this.ds_enderecotransp.Name = "ds_enderecotransp";
            this.ds_enderecotransp.NM_Alias = "";
            this.ds_enderecotransp.NM_Campo = "ds_endereco";
            this.ds_enderecotransp.NM_CampoBusca = "ds_endereco";
            this.ds_enderecotransp.NM_Param = "@P_NM_EMPRESA";
            this.ds_enderecotransp.QTD_Zero = 0;
            this.ds_enderecotransp.ReadOnly = true;
            this.ds_enderecotransp.Size = new System.Drawing.Size(377, 20);
            this.ds_enderecotransp.ST_AutoInc = false;
            this.ds_enderecotransp.ST_DisableAuto = false;
            this.ds_enderecotransp.ST_Float = false;
            this.ds_enderecotransp.ST_Gravar = false;
            this.ds_enderecotransp.ST_Int = false;
            this.ds_enderecotransp.ST_LimpaCampo = true;
            this.ds_enderecotransp.ST_NotNull = false;
            this.ds_enderecotransp.ST_PrimaryKey = false;
            this.ds_enderecotransp.TabIndex = 428;
            this.ds_enderecotransp.TextOld = null;
            // 
            // bb_enderecotransp
            // 
            this.bb_enderecotransp.Image = ((System.Drawing.Image)(resources.GetObject("bb_enderecotransp.Image")));
            this.bb_enderecotransp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_enderecotransp.Location = new System.Drawing.Point(168, 55);
            this.bb_enderecotransp.Name = "bb_enderecotransp";
            this.bb_enderecotransp.Size = new System.Drawing.Size(28, 19);
            this.bb_enderecotransp.TabIndex = 6;
            this.bb_enderecotransp.UseVisualStyleBackColor = true;
            this.bb_enderecotransp.Click += new System.EventHandler(this.bb_enderecotransp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(29, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 427;
            this.label3.Text = "Endereço:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_enderecotransp
            // 
            this.cd_enderecotransp.BackColor = System.Drawing.SystemColors.Window;
            this.cd_enderecotransp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_enderecotransp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_enderecotransp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Cd_enderecotransp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_enderecotransp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_enderecotransp.Location = new System.Drawing.Point(91, 55);
            this.cd_enderecotransp.Name = "cd_enderecotransp";
            this.cd_enderecotransp.NM_Alias = "";
            this.cd_enderecotransp.NM_Campo = "cd_endereco";
            this.cd_enderecotransp.NM_CampoBusca = "cd_endereco";
            this.cd_enderecotransp.NM_Param = "@P_CD_EMPRESA";
            this.cd_enderecotransp.QTD_Zero = 0;
            this.cd_enderecotransp.Size = new System.Drawing.Size(75, 20);
            this.cd_enderecotransp.ST_AutoInc = false;
            this.cd_enderecotransp.ST_DisableAuto = false;
            this.cd_enderecotransp.ST_Float = false;
            this.cd_enderecotransp.ST_Gravar = true;
            this.cd_enderecotransp.ST_Int = true;
            this.cd_enderecotransp.ST_LimpaCampo = true;
            this.cd_enderecotransp.ST_NotNull = false;
            this.cd_enderecotransp.ST_PrimaryKey = false;
            this.cd_enderecotransp.TabIndex = 5;
            this.cd_enderecotransp.TextOld = null;
            this.cd_enderecotransp.Leave += new System.EventHandler(this.cd_enderecotransp_Leave);
            // 
            // nm_transportadora
            // 
            this.nm_transportadora.BackColor = System.Drawing.SystemColors.Window;
            this.nm_transportadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_transportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_transportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Nm_transportadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_transportadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_transportadora.Location = new System.Drawing.Point(199, 29);
            this.nm_transportadora.Name = "nm_transportadora";
            this.nm_transportadora.NM_Alias = "";
            this.nm_transportadora.NM_Campo = "nm_clifor";
            this.nm_transportadora.NM_CampoBusca = "nm_clifor";
            this.nm_transportadora.NM_Param = "@P_NM_EMPRESA";
            this.nm_transportadora.QTD_Zero = 0;
            this.nm_transportadora.Size = new System.Drawing.Size(377, 20);
            this.nm_transportadora.ST_AutoInc = false;
            this.nm_transportadora.ST_DisableAuto = false;
            this.nm_transportadora.ST_Float = false;
            this.nm_transportadora.ST_Gravar = false;
            this.nm_transportadora.ST_Int = false;
            this.nm_transportadora.ST_LimpaCampo = true;
            this.nm_transportadora.ST_NotNull = false;
            this.nm_transportadora.ST_PrimaryKey = false;
            this.nm_transportadora.TabIndex = 4;
            this.nm_transportadora.TextOld = null;
            // 
            // bb_transportadora
            // 
            this.bb_transportadora.Image = ((System.Drawing.Image)(resources.GetObject("bb_transportadora.Image")));
            this.bb_transportadora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_transportadora.Location = new System.Drawing.Point(168, 29);
            this.bb_transportadora.Name = "bb_transportadora";
            this.bb_transportadora.Size = new System.Drawing.Size(28, 19);
            this.bb_transportadora.TabIndex = 3;
            this.bb_transportadora.UseVisualStyleBackColor = true;
            this.bb_transportadora.Click += new System.EventHandler(this.bb_transportadora_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 423;
            this.label1.Text = "Transportadora:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_transportadora
            // 
            this.cd_transportadora.BackColor = System.Drawing.SystemColors.Window;
            this.cd_transportadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_transportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_transportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Cd_transportadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_transportadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_transportadora.Location = new System.Drawing.Point(91, 29);
            this.cd_transportadora.Name = "cd_transportadora";
            this.cd_transportadora.NM_Alias = "";
            this.cd_transportadora.NM_Campo = "cd_clifor";
            this.cd_transportadora.NM_CampoBusca = "cd_clifor";
            this.cd_transportadora.NM_Param = "@P_CD_EMPRESA";
            this.cd_transportadora.QTD_Zero = 0;
            this.cd_transportadora.Size = new System.Drawing.Size(75, 20);
            this.cd_transportadora.ST_AutoInc = false;
            this.cd_transportadora.ST_DisableAuto = false;
            this.cd_transportadora.ST_Float = false;
            this.cd_transportadora.ST_Gravar = true;
            this.cd_transportadora.ST_Int = true;
            this.cd_transportadora.ST_LimpaCampo = true;
            this.cd_transportadora.ST_NotNull = false;
            this.cd_transportadora.ST_PrimaryKey = false;
            this.cd_transportadora.TabIndex = 2;
            this.cd_transportadora.TextOld = null;
            this.cd_transportadora.Leave += new System.EventHandler(this.cd_transportadora_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_empresa.Location = new System.Drawing.Point(199, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.ReadOnly = true;
            this.nm_empresa.Size = new System.Drawing.Size(377, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 420;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(168, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(34, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 419;
            this.label2.Text = "Empresa:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaFrete, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(91, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(75, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // TFCartaFrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 253);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCartaFrete";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carta Frete";
            this.Load += new System.EventHandler(this.TFCartaFrete_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCartaFrete_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartaFrete)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kilometragem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_enderecotransp;
        private System.Windows.Forms.Button bb_enderecotransp;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault cd_enderecotransp;
        private Componentes.EditDefault nm_transportadora;
        private System.Windows.Forms.Button bb_transportadora;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_transportadora;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label7;
        private Componentes.EditData dt_vencimento;
        private System.Windows.Forms.Label label5;
        private Componentes.EditData dt_emissao;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault nr_cartafrete;
        private System.Windows.Forms.Label label11;
        private Componentes.EditDefault nm_motorista;
        private Componentes.EditDefault ds_endunidpagadora;
        private System.Windows.Forms.Button bb_endunidpagadora;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault cd_endunidpagadora;
        private Componentes.EditDefault nm_unidpagadora;
        private System.Windows.Forms.Button bb_unidpagadora;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault cd_unidpagadora;
        private Componentes.EditFloat vl_documento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private Componentes.EditDefault nr_frota;
        private System.Windows.Forms.Label label12;
        private Componentes.EditMask placa;
        private Componentes.EditFloat kilometragem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.BindingSource bsCartaFrete;
    }
}