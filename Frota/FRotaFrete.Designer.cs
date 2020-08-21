namespace Frota
{
    partial class TFRotaFrete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFRotaFrete));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pRota = new Componentes.PanelDados(this.components);
            this.bsRotaFrete = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ds_unidFrete = new Componentes.EditDefault(this.components);
            this.ds_cidadeDestino = new Componentes.EditDefault(this.components);
            this.ds_cidadeOrigem = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_Origem = new System.Windows.Forms.Button();
            this.cd_cidadeOrigem = new Componentes.EditDefault(this.components);
            this.bb_Destino = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bb_unidFrete = new System.Windows.Forms.Button();
            this.cd_unidFrete = new Componentes.EditDefault(this.components);
            this.Cd_cidadeDestino = new Componentes.EditDefault(this.components);
            this.ds_rota = new Componentes.EditDefault(this.components);
            this.vl_freteFixo = new Componentes.EditFloat(this.components);
            this.vl_freteUnidade = new Componentes.EditFloat(this.components);
            this.Vl_pedagios = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.St_registro = new Componentes.ComboBoxDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pRota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRotaFrete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_freteFixo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_freteUnidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_pedagios)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(632, 43);
            this.barraMenu.TabIndex = 11;
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
            // pRota
            // 
            this.pRota.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pRota.Controls.Add(this.label10);
            this.pRota.Controls.Add(this.ds_observacao);
            this.pRota.Controls.Add(this.label5);
            this.pRota.Controls.Add(this.editDefault1);
            this.pRota.Controls.Add(this.label9);
            this.pRota.Controls.Add(this.label8);
            this.pRota.Controls.Add(this.St_registro);
            this.pRota.Controls.Add(this.label7);
            this.pRota.Controls.Add(this.label6);
            this.pRota.Controls.Add(this.label1);
            this.pRota.Controls.Add(this.Vl_pedagios);
            this.pRota.Controls.Add(this.vl_freteUnidade);
            this.pRota.Controls.Add(this.vl_freteFixo);
            this.pRota.Controls.Add(this.ds_rota);
            this.pRota.Controls.Add(this.label3);
            this.pRota.Controls.Add(this.ds_unidFrete);
            this.pRota.Controls.Add(this.ds_cidadeDestino);
            this.pRota.Controls.Add(this.ds_cidadeOrigem);
            this.pRota.Controls.Add(this.label4);
            this.pRota.Controls.Add(this.bb_Origem);
            this.pRota.Controls.Add(this.cd_cidadeOrigem);
            this.pRota.Controls.Add(this.bb_Destino);
            this.pRota.Controls.Add(this.label2);
            this.pRota.Controls.Add(this.bb_unidFrete);
            this.pRota.Controls.Add(this.cd_unidFrete);
            this.pRota.Controls.Add(this.Cd_cidadeDestino);
            this.pRota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRota.Location = new System.Drawing.Point(0, 43);
            this.pRota.Name = "pRota";
            this.pRota.NM_ProcDeletar = "";
            this.pRota.NM_ProcGravar = "";
            this.pRota.Size = new System.Drawing.Size(632, 191);
            this.pRota.TabIndex = 12;
            // 
            // bsRotaFrete
            // 
            this.bsRotaFrete.DataSource = typeof(CamadaDados.Frota.TList_RotaFrete);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Destino:";
            // 
            // ds_unidFrete
            // 
            this.ds_unidFrete.BackColor = System.Drawing.SystemColors.Window;
            this.ds_unidFrete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_unidFrete.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaFrete, "Ds_unidade_frete", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_unidFrete.Location = new System.Drawing.Point(193, 66);
            this.ds_unidFrete.Name = "ds_unidFrete";
            this.ds_unidFrete.NM_Alias = "";
            this.ds_unidFrete.NM_Campo = "ds_unidade";
            this.ds_unidFrete.NM_CampoBusca = "ds_unidade";
            this.ds_unidFrete.NM_Param = "@P_DS_UNIDADE";
            this.ds_unidFrete.QTD_Zero = 0;
            this.ds_unidFrete.Size = new System.Drawing.Size(218, 20);
            this.ds_unidFrete.ST_AutoInc = false;
            this.ds_unidFrete.ST_DisableAuto = false;
            this.ds_unidFrete.ST_Float = false;
            this.ds_unidFrete.ST_Gravar = false;
            this.ds_unidFrete.ST_Int = false;
            this.ds_unidFrete.ST_LimpaCampo = true;
            this.ds_unidFrete.ST_NotNull = false;
            this.ds_unidFrete.ST_PrimaryKey = false;
            this.ds_unidFrete.TabIndex = 84;
            // 
            // ds_cidadeDestino
            // 
            this.ds_cidadeDestino.BackColor = System.Drawing.SystemColors.Window;
            this.ds_cidadeDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_cidadeDestino.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaFrete, "Ds_cidade_destino", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_cidadeDestino.Location = new System.Drawing.Point(194, 41);
            this.ds_cidadeDestino.Name = "ds_cidadeDestino";
            this.ds_cidadeDestino.NM_Alias = "";
            this.ds_cidadeDestino.NM_Campo = "ds_cidade";
            this.ds_cidadeDestino.NM_CampoBusca = "ds_cidade";
            this.ds_cidadeDestino.NM_Param = "@P_DS_CIDADE";
            this.ds_cidadeDestino.QTD_Zero = 0;
            this.ds_cidadeDestino.Size = new System.Drawing.Size(217, 20);
            this.ds_cidadeDestino.ST_AutoInc = false;
            this.ds_cidadeDestino.ST_DisableAuto = false;
            this.ds_cidadeDestino.ST_Float = false;
            this.ds_cidadeDestino.ST_Gravar = false;
            this.ds_cidadeDestino.ST_Int = false;
            this.ds_cidadeDestino.ST_LimpaCampo = true;
            this.ds_cidadeDestino.ST_NotNull = false;
            this.ds_cidadeDestino.ST_PrimaryKey = false;
            this.ds_cidadeDestino.TabIndex = 83;
            // 
            // ds_cidadeOrigem
            // 
            this.ds_cidadeOrigem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_cidadeOrigem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_cidadeOrigem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaFrete, "Ds_cidade_origem", true));
            this.ds_cidadeOrigem.Location = new System.Drawing.Point(194, 14);
            this.ds_cidadeOrigem.Name = "ds_cidadeOrigem";
            this.ds_cidadeOrigem.NM_Alias = "";
            this.ds_cidadeOrigem.NM_Campo = "ds_cidade";
            this.ds_cidadeOrigem.NM_CampoBusca = "ds_cidade";
            this.ds_cidadeOrigem.NM_Param = "@P_DS_CIDADE";
            this.ds_cidadeOrigem.QTD_Zero = 0;
            this.ds_cidadeOrigem.Size = new System.Drawing.Size(217, 20);
            this.ds_cidadeOrigem.ST_AutoInc = false;
            this.ds_cidadeOrigem.ST_DisableAuto = false;
            this.ds_cidadeOrigem.ST_Float = false;
            this.ds_cidadeOrigem.ST_Gravar = false;
            this.ds_cidadeOrigem.ST_Int = false;
            this.ds_cidadeOrigem.ST_LimpaCampo = true;
            this.ds_cidadeOrigem.ST_NotNull = false;
            this.ds_cidadeOrigem.ST_PrimaryKey = false;
            this.ds_cidadeOrigem.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "Origem:";
            // 
            // bb_Origem
            // 
            this.bb_Origem.Image = ((System.Drawing.Image)(resources.GetObject("bb_Origem.Image")));
            this.bb_Origem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_Origem.Location = new System.Drawing.Point(160, 14);
            this.bb_Origem.Name = "bb_Origem";
            this.bb_Origem.Size = new System.Drawing.Size(28, 19);
            this.bb_Origem.TabIndex = 80;
            this.bb_Origem.UseVisualStyleBackColor = true;
            this.bb_Origem.Click += new System.EventHandler(this.bb_Origem_Click);
            // 
            // cd_cidadeOrigem
            // 
            this.cd_cidadeOrigem.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cidadeOrigem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cidadeOrigem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaFrete, "Cd_cidade_origem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_cidadeOrigem.Location = new System.Drawing.Point(83, 13);
            this.cd_cidadeOrigem.Name = "cd_cidadeOrigem";
            this.cd_cidadeOrigem.NM_Alias = "";
            this.cd_cidadeOrigem.NM_Campo = "cd_cidade";
            this.cd_cidadeOrigem.NM_CampoBusca = "cd_cidade";
            this.cd_cidadeOrigem.NM_Param = "";
            this.cd_cidadeOrigem.QTD_Zero = 0;
            this.cd_cidadeOrigem.Size = new System.Drawing.Size(72, 20);
            this.cd_cidadeOrigem.ST_AutoInc = false;
            this.cd_cidadeOrigem.ST_DisableAuto = false;
            this.cd_cidadeOrigem.ST_Float = false;
            this.cd_cidadeOrigem.ST_Gravar = false;
            this.cd_cidadeOrigem.ST_Int = false;
            this.cd_cidadeOrigem.ST_LimpaCampo = true;
            this.cd_cidadeOrigem.ST_NotNull = false;
            this.cd_cidadeOrigem.ST_PrimaryKey = false;
            this.cd_cidadeOrigem.TabIndex = 79;
            this.cd_cidadeOrigem.Leave += new System.EventHandler(this.cd_cidadeOrigem_Leave);
            // 
            // bb_Destino
            // 
            this.bb_Destino.Image = ((System.Drawing.Image)(resources.GetObject("bb_Destino.Image")));
            this.bb_Destino.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_Destino.Location = new System.Drawing.Point(160, 41);
            this.bb_Destino.Name = "bb_Destino";
            this.bb_Destino.Size = new System.Drawing.Size(28, 19);
            this.bb_Destino.TabIndex = 78;
            this.bb_Destino.UseVisualStyleBackColor = true;
            this.bb_Destino.Click += new System.EventHandler(this.bb_Destino_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "Unid. Frete:";
            // 
            // bb_unidFrete
            // 
            this.bb_unidFrete.Image = ((System.Drawing.Image)(resources.GetObject("bb_unidFrete.Image")));
            this.bb_unidFrete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_unidFrete.Location = new System.Drawing.Point(159, 67);
            this.bb_unidFrete.Name = "bb_unidFrete";
            this.bb_unidFrete.Size = new System.Drawing.Size(28, 19);
            this.bb_unidFrete.TabIndex = 76;
            this.bb_unidFrete.UseVisualStyleBackColor = true;
            this.bb_unidFrete.Click += new System.EventHandler(this.bb_unidFrete_Click);
            // 
            // cd_unidFrete
            // 
            this.cd_unidFrete.BackColor = System.Drawing.SystemColors.Window;
            this.cd_unidFrete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidFrete.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaFrete, "Cd_unidade_frete", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_unidFrete.Location = new System.Drawing.Point(83, 67);
            this.cd_unidFrete.Name = "cd_unidFrete";
            this.cd_unidFrete.NM_Alias = "";
            this.cd_unidFrete.NM_Campo = "cd_unidade";
            this.cd_unidFrete.NM_CampoBusca = "cd_unidade";
            this.cd_unidFrete.NM_Param = "@P_CD_UNIDADE";
            this.cd_unidFrete.QTD_Zero = 0;
            this.cd_unidFrete.Size = new System.Drawing.Size(72, 20);
            this.cd_unidFrete.ST_AutoInc = false;
            this.cd_unidFrete.ST_DisableAuto = false;
            this.cd_unidFrete.ST_Float = false;
            this.cd_unidFrete.ST_Gravar = false;
            this.cd_unidFrete.ST_Int = false;
            this.cd_unidFrete.ST_LimpaCampo = true;
            this.cd_unidFrete.ST_NotNull = false;
            this.cd_unidFrete.ST_PrimaryKey = false;
            this.cd_unidFrete.TabIndex = 75;
            this.cd_unidFrete.Leave += new System.EventHandler(this.cd_unidFrete_Leave);
            // 
            // Cd_cidadeDestino
            // 
            this.Cd_cidadeDestino.BackColor = System.Drawing.SystemColors.Window;
            this.Cd_cidadeDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cd_cidadeDestino.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaFrete, "Cd_cidade_destino", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Cd_cidadeDestino.Location = new System.Drawing.Point(82, 39);
            this.Cd_cidadeDestino.Name = "Cd_cidadeDestino";
            this.Cd_cidadeDestino.NM_Alias = "";
            this.Cd_cidadeDestino.NM_Campo = "cd_cidade";
            this.Cd_cidadeDestino.NM_CampoBusca = "cd_cidade";
            this.Cd_cidadeDestino.NM_Param = "@P_CD_CIDADE";
            this.Cd_cidadeDestino.QTD_Zero = 0;
            this.Cd_cidadeDestino.Size = new System.Drawing.Size(72, 20);
            this.Cd_cidadeDestino.ST_AutoInc = false;
            this.Cd_cidadeDestino.ST_DisableAuto = false;
            this.Cd_cidadeDestino.ST_Float = false;
            this.Cd_cidadeDestino.ST_Gravar = false;
            this.Cd_cidadeDestino.ST_Int = false;
            this.Cd_cidadeDestino.ST_LimpaCampo = true;
            this.Cd_cidadeDestino.ST_NotNull = false;
            this.Cd_cidadeDestino.ST_PrimaryKey = false;
            this.Cd_cidadeDestino.TabIndex = 74;
            this.Cd_cidadeDestino.Leave += new System.EventHandler(this.Cd_cidadeDestino_Leave);
            // 
            // ds_rota
            // 
            this.ds_rota.BackColor = System.Drawing.SystemColors.Window;
            this.ds_rota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_rota.Location = new System.Drawing.Point(82, 92);
            this.ds_rota.Name = "ds_rota";
            this.ds_rota.NM_Alias = "";
            this.ds_rota.NM_Campo = "";
            this.ds_rota.NM_CampoBusca = "";
            this.ds_rota.NM_Param = "";
            this.ds_rota.QTD_Zero = 0;
            this.ds_rota.Size = new System.Drawing.Size(182, 20);
            this.ds_rota.ST_AutoInc = false;
            this.ds_rota.ST_DisableAuto = false;
            this.ds_rota.ST_Float = false;
            this.ds_rota.ST_Gravar = false;
            this.ds_rota.ST_Int = false;
            this.ds_rota.ST_LimpaCampo = true;
            this.ds_rota.ST_NotNull = false;
            this.ds_rota.ST_PrimaryKey = false;
            this.ds_rota.TabIndex = 86;
            // 
            // vl_freteFixo
            // 
            this.vl_freteFixo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRotaFrete, "Vl_freteFixo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_freteFixo.Location = new System.Drawing.Point(531, 13);
            this.vl_freteFixo.Name = "vl_freteFixo";
            this.vl_freteFixo.NM_Alias = "";
            this.vl_freteFixo.NM_Campo = "";
            this.vl_freteFixo.NM_Param = "";
            this.vl_freteFixo.Operador = "";
            this.vl_freteFixo.Size = new System.Drawing.Size(79, 20);
            this.vl_freteFixo.ST_AutoInc = false;
            this.vl_freteFixo.ST_DisableAuto = false;
            this.vl_freteFixo.ST_Gravar = false;
            this.vl_freteFixo.ST_LimparCampo = true;
            this.vl_freteFixo.ST_NotNull = false;
            this.vl_freteFixo.ST_PrimaryKey = false;
            this.vl_freteFixo.TabIndex = 87;
            this.vl_freteFixo.ThousandsSeparator = true;
            // 
            // vl_freteUnidade
            // 
            this.vl_freteUnidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRotaFrete, "Vl_freteUnidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_freteUnidade.Location = new System.Drawing.Point(531, 41);
            this.vl_freteUnidade.Name = "vl_freteUnidade";
            this.vl_freteUnidade.NM_Alias = "";
            this.vl_freteUnidade.NM_Campo = "";
            this.vl_freteUnidade.NM_Param = "";
            this.vl_freteUnidade.Operador = "";
            this.vl_freteUnidade.Size = new System.Drawing.Size(79, 20);
            this.vl_freteUnidade.ST_AutoInc = false;
            this.vl_freteUnidade.ST_DisableAuto = false;
            this.vl_freteUnidade.ST_Gravar = false;
            this.vl_freteUnidade.ST_LimparCampo = true;
            this.vl_freteUnidade.ST_NotNull = false;
            this.vl_freteUnidade.ST_PrimaryKey = false;
            this.vl_freteUnidade.TabIndex = 88;
            this.vl_freteUnidade.ThousandsSeparator = true;
            // 
            // Vl_pedagios
            // 
            this.Vl_pedagios.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRotaFrete, "Vl_pedagios", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Vl_pedagios.Location = new System.Drawing.Point(531, 69);
            this.Vl_pedagios.Name = "Vl_pedagios";
            this.Vl_pedagios.NM_Alias = "";
            this.Vl_pedagios.NM_Campo = "";
            this.Vl_pedagios.NM_Param = "";
            this.Vl_pedagios.Operador = "";
            this.Vl_pedagios.Size = new System.Drawing.Size(79, 20);
            this.Vl_pedagios.ST_AutoInc = false;
            this.Vl_pedagios.ST_DisableAuto = false;
            this.Vl_pedagios.ST_Gravar = false;
            this.Vl_pedagios.ST_LimparCampo = true;
            this.Vl_pedagios.ST_NotNull = false;
            this.Vl_pedagios.ST_PrimaryKey = false;
            this.Vl_pedagios.TabIndex = 90;
            this.Vl_pedagios.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(457, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "Vl.Pedágios:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(433, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 93;
            this.label6.Text = "Vl. Frete Unidade:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(457, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 94;
            this.label7.Text = "Vl.Frete Fixo:";
            // 
            // St_registro
            // 
            this.St_registro.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRotaFrete, "St_registro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.St_registro.FormattingEnabled = true;
            this.St_registro.Location = new System.Drawing.Point(330, 91);
            this.St_registro.Name = "St_registro";
            this.St_registro.NM_Alias = "";
            this.St_registro.NM_Campo = "";
            this.St_registro.NM_Param = "";
            this.St_registro.Size = new System.Drawing.Size(101, 21);
            this.St_registro.ST_Gravar = false;
            this.St_registro.ST_LimparCampo = true;
            this.St_registro.ST_NotNull = false;
            this.St_registro.TabIndex = 95;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(284, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 96;
            this.label8.Text = "Status:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 97;
            this.label9.Text = "Rota:";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaFrete, "Distancia_KM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Location = new System.Drawing.Point(531, 95);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(79, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 98;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(451, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Distancia Km:";
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaFrete, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(83, 121);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(527, 59);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 100;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 101;
            this.label10.Text = "Obs::";
            // 
            // TFRotaFrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 234);
            this.Controls.Add(this.pRota);
            this.Controls.Add(this.barraMenu);
            this.Name = "TFRotaFrete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Rotas/Frete";
            this.Load += new System.EventHandler(this.TFRotaFrete_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pRota.ResumeLayout(false);
            this.pRota.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRotaFrete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_freteFixo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_freteUnidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_pedagios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pRota;
        private System.Windows.Forms.BindingSource bsRotaFrete;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault ds_unidFrete;
        private Componentes.EditDefault ds_cidadeDestino;
        private Componentes.EditDefault ds_cidadeOrigem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_Origem;
        private Componentes.EditDefault cd_cidadeOrigem;
        private System.Windows.Forms.Button bb_Destino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_unidFrete;
        private Componentes.EditDefault cd_unidFrete;
        private Componentes.EditDefault Cd_cidadeDestino;
        private Componentes.EditFloat Vl_pedagios;
        private Componentes.EditFloat vl_freteUnidade;
        private Componentes.EditFloat vl_freteFixo;
        private Componentes.EditDefault ds_rota;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Componentes.ComboBoxDefault St_registro;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault ds_observacao;
    }
}