namespace Fazenda
{
    partial class TFTalhoesPlantio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTalhoesPlantio));
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label lblSiglaUnidade;
            System.Windows.Forms.Label label8;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.nm_fazenda = new Componentes.EditDefault(this.components);
            this.bb_fazenda = new System.Windows.Forms.Button();
            this.cd_fazenda = new Componentes.EditDefault(this.components);
            this.bsTalhoesPlantio = new System.Windows.Forms.BindingSource(this.components);
            this.ds_area = new Componentes.EditDefault(this.components);
            this.bb_area = new System.Windows.Forms.Button();
            this.id_area = new Componentes.EditDefault(this.components);
            this.ds_talhao = new Componentes.EditDefault(this.components);
            this.bb_talhao = new System.Windows.Forms.Button();
            this.id_talhao = new Componentes.EditDefault(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.area_talhao = new Componentes.EditFloat(this.components);
            this.und1 = new Componentes.EditDefault(this.components);
            this.und2 = new Componentes.EditDefault(this.components);
            this.area_plantada = new Componentes.EditFloat(this.components);
            this.pc_plantado = new Componentes.EditFloat(this.components);
            this.producao_prevista = new Componentes.EditFloat(this.components);
            this.undproduto = new Componentes.EditDefault(this.components);
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            lblSiglaUnidade = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTalhoesPlantio)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.area_talhao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.area_plantada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_plantado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.producao_prevista)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(609, 43);
            this.barraMenu.TabIndex = 4;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.panelDados1);
            this.pDados.Controls.Add(this.ds_talhao);
            this.pDados.Controls.Add(this.bb_talhao);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.id_talhao);
            this.pDados.Controls.Add(this.ds_area);
            this.pDados.Controls.Add(this.bb_area);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.id_area);
            this.pDados.Controls.Add(this.nm_fazenda);
            this.pDados.Controls.Add(this.bb_fazenda);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(this.cd_fazenda);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(609, 134);
            this.pDados.TabIndex = 5;
            // 
            // nm_fazenda
            // 
            this.nm_fazenda.BackColor = System.Drawing.SystemColors.Window;
            this.nm_fazenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_fazenda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTalhoesPlantio, "Nm_fazenda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_fazenda.Enabled = false;
            this.nm_fazenda.Location = new System.Drawing.Point(160, 3);
            this.nm_fazenda.Name = "nm_fazenda";
            this.nm_fazenda.NM_Alias = "";
            this.nm_fazenda.NM_Campo = "nm_fazenda";
            this.nm_fazenda.NM_CampoBusca = "nm_fazenda";
            this.nm_fazenda.NM_Param = "@P_DS_CULTURA";
            this.nm_fazenda.QTD_Zero = 0;
            this.nm_fazenda.Size = new System.Drawing.Size(444, 20);
            this.nm_fazenda.ST_AutoInc = false;
            this.nm_fazenda.ST_DisableAuto = false;
            this.nm_fazenda.ST_Float = false;
            this.nm_fazenda.ST_Gravar = false;
            this.nm_fazenda.ST_Int = false;
            this.nm_fazenda.ST_LimpaCampo = true;
            this.nm_fazenda.ST_NotNull = false;
            this.nm_fazenda.ST_PrimaryKey = false;
            this.nm_fazenda.TabIndex = 110;
            // 
            // bb_fazenda
            // 
            this.bb_fazenda.BackColor = System.Drawing.SystemColors.Control;
            this.bb_fazenda.Image = ((System.Drawing.Image)(resources.GetObject("bb_fazenda.Image")));
            this.bb_fazenda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_fazenda.Location = new System.Drawing.Point(126, 3);
            this.bb_fazenda.Name = "bb_fazenda";
            this.bb_fazenda.Size = new System.Drawing.Size(28, 19);
            this.bb_fazenda.TabIndex = 108;
            this.bb_fazenda.UseVisualStyleBackColor = false;
            this.bb_fazenda.Click += new System.EventHandler(this.bb_fazenda_Click);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(3, 6);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(51, 13);
            label5.TabIndex = 109;
            label5.Text = "Fazenda:";
            // 
            // cd_fazenda
            // 
            this.cd_fazenda.BackColor = System.Drawing.Color.White;
            this.cd_fazenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_fazenda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTalhoesPlantio, "Cd_fazenda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_fazenda.Location = new System.Drawing.Point(60, 3);
            this.cd_fazenda.Name = "cd_fazenda";
            this.cd_fazenda.NM_Alias = "";
            this.cd_fazenda.NM_Campo = "cd_fazenda";
            this.cd_fazenda.NM_CampoBusca = "cd_fazenda";
            this.cd_fazenda.NM_Param = "@P_CD_EMPRESA";
            this.cd_fazenda.QTD_Zero = 0;
            this.cd_fazenda.Size = new System.Drawing.Size(64, 20);
            this.cd_fazenda.ST_AutoInc = false;
            this.cd_fazenda.ST_DisableAuto = false;
            this.cd_fazenda.ST_Float = false;
            this.cd_fazenda.ST_Gravar = true;
            this.cd_fazenda.ST_Int = true;
            this.cd_fazenda.ST_LimpaCampo = true;
            this.cd_fazenda.ST_NotNull = true;
            this.cd_fazenda.ST_PrimaryKey = false;
            this.cd_fazenda.TabIndex = 107;
            this.cd_fazenda.Leave += new System.EventHandler(this.cd_fazenda_Leave);
            // 
            // bsTalhoesPlantio
            // 
            this.bsTalhoesPlantio.DataSource = typeof(CamadaDados.Fazenda.Cadastros.TList_Plantio_X_Talhoes);
            // 
            // ds_area
            // 
            this.ds_area.BackColor = System.Drawing.SystemColors.Window;
            this.ds_area.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_area.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTalhoesPlantio, "Ds_area", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_area.Enabled = false;
            this.ds_area.Location = new System.Drawing.Point(160, 29);
            this.ds_area.Name = "ds_area";
            this.ds_area.NM_Alias = "";
            this.ds_area.NM_Campo = "ds_area";
            this.ds_area.NM_CampoBusca = "ds_area";
            this.ds_area.NM_Param = "@P_DS_CULTURA";
            this.ds_area.QTD_Zero = 0;
            this.ds_area.Size = new System.Drawing.Size(444, 20);
            this.ds_area.ST_AutoInc = false;
            this.ds_area.ST_DisableAuto = false;
            this.ds_area.ST_Float = false;
            this.ds_area.ST_Gravar = false;
            this.ds_area.ST_Int = false;
            this.ds_area.ST_LimpaCampo = true;
            this.ds_area.ST_NotNull = false;
            this.ds_area.ST_PrimaryKey = false;
            this.ds_area.TabIndex = 114;
            // 
            // bb_area
            // 
            this.bb_area.BackColor = System.Drawing.SystemColors.Control;
            this.bb_area.Image = ((System.Drawing.Image)(resources.GetObject("bb_area.Image")));
            this.bb_area.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_area.Location = new System.Drawing.Point(126, 29);
            this.bb_area.Name = "bb_area";
            this.bb_area.Size = new System.Drawing.Size(28, 19);
            this.bb_area.TabIndex = 112;
            this.bb_area.UseVisualStyleBackColor = false;
            this.bb_area.Click += new System.EventHandler(this.bb_area_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(22, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 13);
            label1.TabIndex = 113;
            label1.Text = "Area:";
            // 
            // id_area
            // 
            this.id_area.BackColor = System.Drawing.Color.White;
            this.id_area.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_area.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTalhoesPlantio, "Id_areastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_area.Location = new System.Drawing.Point(60, 29);
            this.id_area.Name = "id_area";
            this.id_area.NM_Alias = "";
            this.id_area.NM_Campo = "id_area";
            this.id_area.NM_CampoBusca = "id_area";
            this.id_area.NM_Param = "@P_CD_EMPRESA";
            this.id_area.QTD_Zero = 0;
            this.id_area.Size = new System.Drawing.Size(64, 20);
            this.id_area.ST_AutoInc = false;
            this.id_area.ST_DisableAuto = false;
            this.id_area.ST_Float = false;
            this.id_area.ST_Gravar = true;
            this.id_area.ST_Int = true;
            this.id_area.ST_LimpaCampo = true;
            this.id_area.ST_NotNull = true;
            this.id_area.ST_PrimaryKey = false;
            this.id_area.TabIndex = 111;
            this.id_area.Leave += new System.EventHandler(this.id_area_Leave);
            // 
            // ds_talhao
            // 
            this.ds_talhao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_talhao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_talhao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTalhoesPlantio, "Ds_talhao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_talhao.Enabled = false;
            this.ds_talhao.Location = new System.Drawing.Point(160, 55);
            this.ds_talhao.Name = "ds_talhao";
            this.ds_talhao.NM_Alias = "";
            this.ds_talhao.NM_Campo = "ds_talhao";
            this.ds_talhao.NM_CampoBusca = "ds_talhao";
            this.ds_talhao.NM_Param = "@P_DS_CULTURA";
            this.ds_talhao.QTD_Zero = 0;
            this.ds_talhao.Size = new System.Drawing.Size(444, 20);
            this.ds_talhao.ST_AutoInc = false;
            this.ds_talhao.ST_DisableAuto = false;
            this.ds_talhao.ST_Float = false;
            this.ds_talhao.ST_Gravar = false;
            this.ds_talhao.ST_Int = false;
            this.ds_talhao.ST_LimpaCampo = true;
            this.ds_talhao.ST_NotNull = false;
            this.ds_talhao.ST_PrimaryKey = false;
            this.ds_talhao.TabIndex = 118;
            // 
            // bb_talhao
            // 
            this.bb_talhao.BackColor = System.Drawing.SystemColors.Control;
            this.bb_talhao.Image = ((System.Drawing.Image)(resources.GetObject("bb_talhao.Image")));
            this.bb_talhao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_talhao.Location = new System.Drawing.Point(126, 55);
            this.bb_talhao.Name = "bb_talhao";
            this.bb_talhao.Size = new System.Drawing.Size(28, 19);
            this.bb_talhao.TabIndex = 116;
            this.bb_talhao.UseVisualStyleBackColor = false;
            this.bb_talhao.Click += new System.EventHandler(this.bb_talhao_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(11, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 13);
            label2.TabIndex = 117;
            label2.Text = "Talhão:";
            // 
            // id_talhao
            // 
            this.id_talhao.BackColor = System.Drawing.Color.White;
            this.id_talhao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_talhao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTalhoesPlantio, "Id_talhaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_talhao.Location = new System.Drawing.Point(60, 55);
            this.id_talhao.Name = "id_talhao";
            this.id_talhao.NM_Alias = "";
            this.id_talhao.NM_Campo = "id_talhao";
            this.id_talhao.NM_CampoBusca = "id_talhao";
            this.id_talhao.NM_Param = "@P_CD_EMPRESA";
            this.id_talhao.QTD_Zero = 0;
            this.id_talhao.Size = new System.Drawing.Size(64, 20);
            this.id_talhao.ST_AutoInc = false;
            this.id_talhao.ST_DisableAuto = false;
            this.id_talhao.ST_Float = false;
            this.id_talhao.ST_Gravar = true;
            this.id_talhao.ST_Int = true;
            this.id_talhao.ST_LimpaCampo = true;
            this.id_talhao.ST_NotNull = true;
            this.id_talhao.ST_PrimaryKey = false;
            this.id_talhao.TabIndex = 115;
            this.id_talhao.Leave += new System.EventHandler(this.id_talhao_Leave);
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(label8);
            this.panelDados1.Controls.Add(lblSiglaUnidade);
            this.panelDados1.Controls.Add(this.undproduto);
            this.panelDados1.Controls.Add(label7);
            this.panelDados1.Controls.Add(this.producao_prevista);
            this.panelDados1.Controls.Add(label4);
            this.panelDados1.Controls.Add(this.pc_plantado);
            this.panelDados1.Controls.Add(label3);
            this.panelDados1.Controls.Add(this.und2);
            this.panelDados1.Controls.Add(this.area_plantada);
            this.panelDados1.Controls.Add(this.und1);
            this.panelDados1.Controls.Add(this.area_talhao);
            this.panelDados1.Controls.Add(label6);
            this.panelDados1.Location = new System.Drawing.Point(60, 81);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(544, 48);
            this.panelDados1.TabIndex = 119;
            // 
            // area_talhao
            // 
            this.area_talhao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTalhoesPlantio, "Area_talhao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.area_talhao.DecimalPlaces = 3;
            this.area_talhao.Enabled = false;
            this.area_talhao.Location = new System.Drawing.Point(3, 20);
            this.area_talhao.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.area_talhao.Name = "area_talhao";
            this.area_talhao.NM_Alias = "";
            this.area_talhao.NM_Campo = "";
            this.area_talhao.NM_Param = "";
            this.area_talhao.Operador = "";
            this.area_talhao.Size = new System.Drawing.Size(111, 20);
            this.area_talhao.ST_AutoInc = false;
            this.area_talhao.ST_DisableAuto = false;
            this.area_talhao.ST_Gravar = false;
            this.area_talhao.ST_LimparCampo = true;
            this.area_talhao.ST_NotNull = false;
            this.area_talhao.ST_PrimaryKey = false;
            this.area_talhao.TabIndex = 119;
            this.area_talhao.ThousandsSeparator = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(0, 3);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(76, 13);
            label6.TabIndex = 118;
            label6.Text = "Area Talhão";
            // 
            // und1
            // 
            this.und1.BackColor = System.Drawing.SystemColors.Window;
            this.und1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.und1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTalhoesPlantio, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.und1.Enabled = false;
            this.und1.Location = new System.Drawing.Point(114, 20);
            this.und1.Name = "und1";
            this.und1.NM_Alias = "";
            this.und1.NM_Campo = "";
            this.und1.NM_CampoBusca = "";
            this.und1.NM_Param = "";
            this.und1.QTD_Zero = 0;
            this.und1.Size = new System.Drawing.Size(35, 20);
            this.und1.ST_AutoInc = false;
            this.und1.ST_DisableAuto = false;
            this.und1.ST_Float = false;
            this.und1.ST_Gravar = false;
            this.und1.ST_Int = false;
            this.und1.ST_LimpaCampo = true;
            this.und1.ST_NotNull = false;
            this.und1.ST_PrimaryKey = false;
            this.und1.TabIndex = 120;
            // 
            // und2
            // 
            this.und2.BackColor = System.Drawing.SystemColors.Window;
            this.und2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.und2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTalhoesPlantio, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.und2.Enabled = false;
            this.und2.Location = new System.Drawing.Point(266, 21);
            this.und2.Name = "und2";
            this.und2.NM_Alias = "";
            this.und2.NM_Campo = "";
            this.und2.NM_CampoBusca = "";
            this.und2.NM_Param = "";
            this.und2.QTD_Zero = 0;
            this.und2.Size = new System.Drawing.Size(35, 20);
            this.und2.ST_AutoInc = false;
            this.und2.ST_DisableAuto = false;
            this.und2.ST_Float = false;
            this.und2.ST_Gravar = false;
            this.und2.ST_Int = false;
            this.und2.ST_LimpaCampo = true;
            this.und2.ST_NotNull = false;
            this.und2.ST_PrimaryKey = false;
            this.und2.TabIndex = 122;
            // 
            // area_plantada
            // 
            this.area_plantada.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTalhoesPlantio, "Area_plantada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.area_plantada.DecimalPlaces = 3;
            this.area_plantada.Location = new System.Drawing.Point(155, 21);
            this.area_plantada.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.area_plantada.Name = "area_plantada";
            this.area_plantada.NM_Alias = "";
            this.area_plantada.NM_Campo = "";
            this.area_plantada.NM_Param = "";
            this.area_plantada.Operador = "";
            this.area_plantada.Size = new System.Drawing.Size(111, 20);
            this.area_plantada.ST_AutoInc = false;
            this.area_plantada.ST_DisableAuto = false;
            this.area_plantada.ST_Gravar = true;
            this.area_plantada.ST_LimparCampo = true;
            this.area_plantada.ST_NotNull = true;
            this.area_plantada.ST_PrimaryKey = false;
            this.area_plantada.TabIndex = 121;
            this.area_plantada.ThousandsSeparator = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(152, 5);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(87, 13);
            label3.TabIndex = 123;
            label3.Text = "Area Plantada";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(304, 5);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(70, 13);
            label4.TabIndex = 125;
            label4.Text = "% Plantado";
            // 
            // pc_plantado
            // 
            this.pc_plantado.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTalhoesPlantio, "Pc_plantado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_plantado.DecimalPlaces = 2;
            this.pc_plantado.Enabled = false;
            this.pc_plantado.Location = new System.Drawing.Point(307, 21);
            this.pc_plantado.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_plantado.Name = "pc_plantado";
            this.pc_plantado.NM_Alias = "";
            this.pc_plantado.NM_Campo = "";
            this.pc_plantado.NM_Param = "";
            this.pc_plantado.Operador = "";
            this.pc_plantado.Size = new System.Drawing.Size(67, 20);
            this.pc_plantado.ST_AutoInc = false;
            this.pc_plantado.ST_DisableAuto = false;
            this.pc_plantado.ST_Gravar = false;
            this.pc_plantado.ST_LimparCampo = true;
            this.pc_plantado.ST_NotNull = false;
            this.pc_plantado.ST_PrimaryKey = false;
            this.pc_plantado.TabIndex = 124;
            this.pc_plantado.ThousandsSeparator = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(377, 5);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(115, 13);
            label7.TabIndex = 127;
            label7.Text = "Produção Prevista(";
            // 
            // producao_prevista
            // 
            this.producao_prevista.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTalhoesPlantio, "Producao_prevista", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.producao_prevista.DecimalPlaces = 3;
            this.producao_prevista.Location = new System.Drawing.Point(380, 21);
            this.producao_prevista.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.producao_prevista.Name = "producao_prevista";
            this.producao_prevista.NM_Alias = "";
            this.producao_prevista.NM_Campo = "";
            this.producao_prevista.NM_Param = "";
            this.producao_prevista.Operador = "";
            this.producao_prevista.Size = new System.Drawing.Size(111, 20);
            this.producao_prevista.ST_AutoInc = false;
            this.producao_prevista.ST_DisableAuto = false;
            this.producao_prevista.ST_Gravar = true;
            this.producao_prevista.ST_LimparCampo = true;
            this.producao_prevista.ST_NotNull = false;
            this.producao_prevista.ST_PrimaryKey = false;
            this.producao_prevista.TabIndex = 126;
            this.producao_prevista.ThousandsSeparator = true;
            // 
            // undproduto
            // 
            this.undproduto.BackColor = System.Drawing.SystemColors.Window;
            this.undproduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.undproduto.Enabled = false;
            this.undproduto.Location = new System.Drawing.Point(492, 21);
            this.undproduto.Name = "undproduto";
            this.undproduto.NM_Alias = "";
            this.undproduto.NM_Campo = "";
            this.undproduto.NM_CampoBusca = "";
            this.undproduto.NM_Param = "";
            this.undproduto.QTD_Zero = 0;
            this.undproduto.Size = new System.Drawing.Size(35, 20);
            this.undproduto.ST_AutoInc = false;
            this.undproduto.ST_DisableAuto = false;
            this.undproduto.ST_Float = false;
            this.undproduto.ST_Gravar = false;
            this.undproduto.ST_Int = false;
            this.undproduto.ST_LimpaCampo = true;
            this.undproduto.ST_NotNull = false;
            this.undproduto.ST_PrimaryKey = false;
            this.undproduto.TabIndex = 128;
            // 
            // lblSiglaUnidade
            // 
            lblSiglaUnidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTalhoesPlantio, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            lblSiglaUnidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSiglaUnidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            lblSiglaUnidade.Location = new System.Drawing.Point(489, 5);
            lblSiglaUnidade.Name = "lblSiglaUnidade";
            lblSiglaUnidade.Size = new System.Drawing.Size(27, 13);
            lblSiglaUnidade.TabIndex = 129;
            lblSiglaUnidade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(515, 5);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(11, 13);
            label8.TabIndex = 130;
            label8.Text = ")";
            // 
            // TFTalhoesPlantio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 177);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFTalhoesPlantio";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Talhões Plantados";
            this.Load += new System.EventHandler(this.TFTalhoesPlantio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFTalhoesPlantio_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTalhoesPlantio)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.area_talhao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.area_plantada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_plantado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.producao_prevista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nm_fazenda;
        private System.Windows.Forms.BindingSource bsTalhoesPlantio;
        private System.Windows.Forms.Button bb_fazenda;
        private Componentes.EditDefault cd_fazenda;
        private Componentes.EditDefault ds_talhao;
        private System.Windows.Forms.Button bb_talhao;
        private Componentes.EditDefault id_talhao;
        private Componentes.EditDefault ds_area;
        private System.Windows.Forms.Button bb_area;
        private Componentes.EditDefault id_area;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault und1;
        private Componentes.EditFloat area_talhao;
        private Componentes.EditFloat pc_plantado;
        private Componentes.EditDefault und2;
        private Componentes.EditFloat area_plantada;
        private Componentes.EditDefault undproduto;
        private Componentes.EditFloat producao_prevista;
    }
}