namespace Locacao
{
    partial class FLocOrdemServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLocOrdemServico));
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new Componentes.PanelDados(this.components);
            this.gbHorimetro = new System.Windows.Forms.GroupBox();
            this.horimetro = new Componentes.EditFloat(this.components);
            this.bsOrdemServico = new System.Windows.Forms.BindingSource(this.components);
            this.label36 = new System.Windows.Forms.Label();
            this.ds_defeitocliente = new Componentes.EditDefault(this.components);
            this.RG_Data = new Componentes.RadioGroup(this.components);
            this.pData = new Componentes.PanelDados(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.DT_Prevista = new Componentes.EditData(this.components);
            this.DT_Abertura = new Componentes.EditData(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new Componentes.PanelDados(this.components);
            this.Nr_patrimonio = new Componentes.EditDefault(this.components);
            this.id_os = new Componentes.EditFloat(this.components);
            this.label28 = new System.Windows.Forms.Label();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.DS_TPOrdem = new Componentes.EditDefault(this.components);
            this.BB_TPOrdem = new System.Windows.Forms.Button();
            this.TP_Ordem = new Componentes.EditDefault(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbHorimetro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horimetro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdemServico)).BeginInit();
            this.RG_Data.SuspendLayout();
            this.pData.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_os)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.tableLayoutPanel1);
            this.panelDados1.Controls.Add(this.barraMenu);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 0);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(795, 266);
            this.panelDados1.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(795, 223);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.gbHorimetro);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.ds_defeitocliente);
            this.panel2.Controls.Add(this.RG_Data);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 88);
            this.panel2.Name = "panel2";
            this.panel2.NM_ProcDeletar = "";
            this.panel2.NM_ProcGravar = "";
            this.panel2.Size = new System.Drawing.Size(789, 132);
            this.panel2.TabIndex = 14;
            // 
            // gbHorimetro
            // 
            this.gbHorimetro.Controls.Add(this.horimetro);
            this.gbHorimetro.Location = new System.Drawing.Point(411, 3);
            this.gbHorimetro.Name = "gbHorimetro";
            this.gbHorimetro.Size = new System.Drawing.Size(96, 49);
            this.gbHorimetro.TabIndex = 1;
            this.gbHorimetro.TabStop = false;
            this.gbHorimetro.Text = "Horimetro";
            this.gbHorimetro.Visible = false;
            // 
            // horimetro
            // 
            this.horimetro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsOrdemServico, "Horimetro", true));
            this.horimetro.DecimalPlaces = 2;
            this.horimetro.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.horimetro.Location = new System.Drawing.Point(6, 19);
            this.horimetro.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.horimetro.Name = "horimetro";
            this.horimetro.NM_Alias = "";
            this.horimetro.NM_Campo = "";
            this.horimetro.NM_Param = "";
            this.horimetro.Operador = "";
            this.horimetro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.horimetro.Size = new System.Drawing.Size(76, 20);
            this.horimetro.ST_AutoInc = false;
            this.horimetro.ST_DisableAuto = false;
            this.horimetro.ST_Gravar = true;
            this.horimetro.ST_LimparCampo = true;
            this.horimetro.ST_NotNull = true;
            this.horimetro.ST_PrimaryKey = false;
            this.horimetro.TabIndex = 5;
            this.horimetro.ThousandsSeparator = true;
            this.horimetro.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // bsOrdemServico
            // 
            this.bsOrdemServico.DataSource = typeof(CamadaDados.Servicos.TList_LanServico);
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(37, 61);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(55, 70);
            this.label36.TabIndex = 89;
            this.label36.Text = "Problema relatado pelo cliente";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_defeitocliente
            // 
            this.ds_defeitocliente.BackColor = System.Drawing.SystemColors.Window;
            this.ds_defeitocliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_defeitocliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_defeitocliente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemServico, "Ds_defeitocliente", true));
            this.ds_defeitocliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_defeitocliente.Location = new System.Drawing.Point(101, 58);
            this.ds_defeitocliente.Multiline = true;
            this.ds_defeitocliente.Name = "ds_defeitocliente";
            this.ds_defeitocliente.NM_Alias = "";
            this.ds_defeitocliente.NM_Campo = "CD_Clifor";
            this.ds_defeitocliente.NM_CampoBusca = "CD_Clifor";
            this.ds_defeitocliente.NM_Param = "@P_CD_CLIFOR";
            this.ds_defeitocliente.QTD_Zero = 0;
            this.ds_defeitocliente.Size = new System.Drawing.Size(682, 68);
            this.ds_defeitocliente.ST_AutoInc = false;
            this.ds_defeitocliente.ST_DisableAuto = false;
            this.ds_defeitocliente.ST_Float = false;
            this.ds_defeitocliente.ST_Gravar = true;
            this.ds_defeitocliente.ST_Int = false;
            this.ds_defeitocliente.ST_LimpaCampo = true;
            this.ds_defeitocliente.ST_NotNull = false;
            this.ds_defeitocliente.ST_PrimaryKey = false;
            this.ds_defeitocliente.TabIndex = 6;
            this.ds_defeitocliente.TextOld = null;
            this.ds_defeitocliente.TextChanged += new System.EventHandler(this.ds_defeitocliente_TextChanged);
            // 
            // RG_Data
            // 
            this.RG_Data.Controls.Add(this.pData);
            this.RG_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.RG_Data.Location = new System.Drawing.Point(101, 3);
            this.RG_Data.Name = "RG_Data";
            this.RG_Data.NM_Alias = "a";
            this.RG_Data.NM_Campo = "TP_Movimento";
            this.RG_Data.NM_Param = "@P_TP_MOVIMENTO";
            this.RG_Data.NM_Valor = "";
            this.RG_Data.Size = new System.Drawing.Size(304, 49);
            this.RG_Data.ST_Gravar = false;
            this.RG_Data.ST_NotNull = false;
            this.RG_Data.TabIndex = 0;
            this.RG_Data.TabStop = false;
            this.RG_Data.Text = "Data";
            // 
            // pData
            // 
            this.pData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pData.Controls.Add(this.label8);
            this.pData.Controls.Add(this.DT_Prevista);
            this.pData.Controls.Add(this.DT_Abertura);
            this.pData.Controls.Add(this.label6);
            this.pData.Location = new System.Drawing.Point(6, 13);
            this.pData.Name = "pData";
            this.pData.NM_ProcDeletar = "";
            this.pData.NM_ProcGravar = "";
            this.pData.Size = new System.Drawing.Size(295, 29);
            this.pData.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(118, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 69;
            this.label8.Text = "Prev. Encerramento:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DT_Prevista
            // 
            this.DT_Prevista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Prevista.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.DT_Prevista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemServico, "Dt_previsao", true));
            this.DT_Prevista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DT_Prevista.Location = new System.Drawing.Point(222, 2);
            this.DT_Prevista.Mask = "00/00/0000";
            this.DT_Prevista.Name = "DT_Prevista";
            this.DT_Prevista.NM_Alias = "";
            this.DT_Prevista.NM_Campo = "";
            this.DT_Prevista.NM_CampoBusca = "";
            this.DT_Prevista.NM_Param = "";
            this.DT_Prevista.Operador = "";
            this.DT_Prevista.Size = new System.Drawing.Size(66, 20);
            this.DT_Prevista.ST_Gravar = true;
            this.DT_Prevista.ST_LimpaCampo = true;
            this.DT_Prevista.ST_NotNull = false;
            this.DT_Prevista.ST_PrimaryKey = false;
            this.DT_Prevista.TabIndex = 1;
            this.DT_Prevista.TextChanged += new System.EventHandler(this.DT_Prevista_TextChanged);
            // 
            // DT_Abertura
            // 
            this.DT_Abertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Abertura.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.DT_Abertura.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemServico, "Dt_abertura", true));
            this.DT_Abertura.Enabled = false;
            this.DT_Abertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DT_Abertura.Location = new System.Drawing.Point(52, 2);
            this.DT_Abertura.Mask = "00/00/0000";
            this.DT_Abertura.Name = "DT_Abertura";
            this.DT_Abertura.NM_Alias = "";
            this.DT_Abertura.NM_Campo = "";
            this.DT_Abertura.NM_CampoBusca = "";
            this.DT_Abertura.NM_Param = "";
            this.DT_Abertura.Operador = "";
            this.DT_Abertura.Size = new System.Drawing.Size(64, 20);
            this.DT_Abertura.ST_Gravar = true;
            this.DT_Abertura.ST_LimpaCampo = true;
            this.DT_Abertura.ST_NotNull = false;
            this.DT_Abertura.ST_PrimaryKey = false;
            this.DT_Abertura.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = "Abertura:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Nr_patrimonio);
            this.panel1.Controls.Add(this.id_os);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.DS_Produto);
            this.panel1.Controls.Add(this.CD_Produto);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.DS_TPOrdem);
            this.panel1.Controls.Add(this.BB_TPOrdem);
            this.panel1.Controls.Add(this.TP_Ordem);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.NM_Empresa);
            this.panel1.Controls.Add(this.BB_Empresa);
            this.panel1.Controls.Add(this.CD_Empresa);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.NM_ProcDeletar = "";
            this.panel1.NM_ProcGravar = "";
            this.panel1.Size = new System.Drawing.Size(789, 79);
            this.panel1.TabIndex = 13;
            // 
            // Nr_patrimonio
            // 
            this.Nr_patrimonio.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_patrimonio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_patrimonio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_patrimonio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemServico, "Nr_patrimonio", true));
            this.Nr_patrimonio.Enabled = false;
            this.Nr_patrimonio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Nr_patrimonio.Location = new System.Drawing.Point(711, 53);
            this.Nr_patrimonio.Name = "Nr_patrimonio";
            this.Nr_patrimonio.NM_Alias = "";
            this.Nr_patrimonio.NM_Campo = "Nr_patrimonio";
            this.Nr_patrimonio.NM_CampoBusca = "Nr_patrimonio";
            this.Nr_patrimonio.NM_Param = "";
            this.Nr_patrimonio.QTD_Zero = 0;
            this.Nr_patrimonio.ReadOnly = true;
            this.Nr_patrimonio.Size = new System.Drawing.Size(72, 20);
            this.Nr_patrimonio.ST_AutoInc = false;
            this.Nr_patrimonio.ST_DisableAuto = false;
            this.Nr_patrimonio.ST_Float = false;
            this.Nr_patrimonio.ST_Gravar = false;
            this.Nr_patrimonio.ST_Int = false;
            this.Nr_patrimonio.ST_LimpaCampo = true;
            this.Nr_patrimonio.ST_NotNull = false;
            this.Nr_patrimonio.ST_PrimaryKey = false;
            this.Nr_patrimonio.TabIndex = 94;
            this.Nr_patrimonio.TextOld = null;
            // 
            // id_os
            // 
            this.id_os.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsOrdemServico, "Id_os", true));
            this.id_os.Enabled = false;
            this.id_os.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.id_os.Location = new System.Drawing.Point(523, 28);
            this.id_os.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.id_os.Name = "id_os";
            this.id_os.NM_Alias = "";
            this.id_os.NM_Campo = "";
            this.id_os.NM_Param = "";
            this.id_os.Operador = "";
            this.id_os.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.id_os.Size = new System.Drawing.Size(76, 20);
            this.id_os.ST_AutoInc = false;
            this.id_os.ST_DisableAuto = false;
            this.id_os.ST_Gravar = true;
            this.id_os.ST_LimparCampo = true;
            this.id_os.ST_NotNull = true;
            this.id_os.ST_PrimaryKey = false;
            this.id_os.TabIndex = 4;
            this.id_os.ThousandsSeparator = true;
            this.id_os.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(461, 30);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(56, 13);
            this.label28.TabIndex = 93;
            this.label28.Text = "Nº Ordem:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemServico, "DS_ProdutoOS", true));
            this.DS_Produto.Enabled = false;
            this.DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Produto.Location = new System.Drawing.Point(237, 53);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_PRODUTO";
            this.DS_Produto.NM_CampoBusca = "DS_PRODUTO";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.ReadOnly = true;
            this.DS_Produto.Size = new System.Drawing.Size(468, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 90;
            this.DS_Produto.TextOld = null;
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.Color.White;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemServico, "CD_ProdutoOS", true));
            this.CD_Produto.Enabled = false;
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Produto.Location = new System.Drawing.Point(102, 53);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(129, 20);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 9;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.TextChanged += new System.EventHandler(this.CD_Produto_TextChanged);
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(48, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 13);
            this.label21.TabIndex = 89;
            this.label21.Text = "Produto:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DS_TPOrdem
            // 
            this.DS_TPOrdem.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TPOrdem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_TPOrdem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TPOrdem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemServico, "Ds_tipoordem", true));
            this.DS_TPOrdem.Enabled = false;
            this.DS_TPOrdem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_TPOrdem.Location = new System.Drawing.Point(179, 27);
            this.DS_TPOrdem.Name = "DS_TPOrdem";
            this.DS_TPOrdem.NM_Alias = "";
            this.DS_TPOrdem.NM_Campo = "DS_tipoOrdem";
            this.DS_TPOrdem.NM_CampoBusca = "DS_tipoOrdem";
            this.DS_TPOrdem.NM_Param = "@P_CD_TABELAPRECO";
            this.DS_TPOrdem.QTD_Zero = 0;
            this.DS_TPOrdem.ReadOnly = true;
            this.DS_TPOrdem.Size = new System.Drawing.Size(276, 20);
            this.DS_TPOrdem.ST_AutoInc = false;
            this.DS_TPOrdem.ST_DisableAuto = false;
            this.DS_TPOrdem.ST_Float = false;
            this.DS_TPOrdem.ST_Gravar = false;
            this.DS_TPOrdem.ST_Int = false;
            this.DS_TPOrdem.ST_LimpaCampo = true;
            this.DS_TPOrdem.ST_NotNull = false;
            this.DS_TPOrdem.ST_PrimaryKey = false;
            this.DS_TPOrdem.TabIndex = 85;
            this.DS_TPOrdem.TextOld = null;
            // 
            // BB_TPOrdem
            // 
            this.BB_TPOrdem.Enabled = false;
            this.BB_TPOrdem.Image = ((System.Drawing.Image)(resources.GetObject("BB_TPOrdem.Image")));
            this.BB_TPOrdem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_TPOrdem.Location = new System.Drawing.Point(145, 27);
            this.BB_TPOrdem.Name = "BB_TPOrdem";
            this.BB_TPOrdem.Size = new System.Drawing.Size(28, 19);
            this.BB_TPOrdem.TabIndex = 3;
            this.BB_TPOrdem.UseVisualStyleBackColor = true;
            this.BB_TPOrdem.Click += new System.EventHandler(this.BB_TPOrdem_Click);
            // 
            // TP_Ordem
            // 
            this.TP_Ordem.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Ordem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Ordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Ordem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemServico, "Tp_ordemstr", true));
            this.TP_Ordem.Enabled = false;
            this.TP_Ordem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TP_Ordem.Location = new System.Drawing.Point(102, 27);
            this.TP_Ordem.Name = "TP_Ordem";
            this.TP_Ordem.NM_Alias = "";
            this.TP_Ordem.NM_Campo = "tp_Ordem";
            this.TP_Ordem.NM_CampoBusca = "tp_Ordem";
            this.TP_Ordem.NM_Param = "@P_CD_TABELAPRECO";
            this.TP_Ordem.QTD_Zero = 0;
            this.TP_Ordem.Size = new System.Drawing.Size(41, 20);
            this.TP_Ordem.ST_AutoInc = false;
            this.TP_Ordem.ST_DisableAuto = false;
            this.TP_Ordem.ST_Float = false;
            this.TP_Ordem.ST_Gravar = true;
            this.TP_Ordem.ST_Int = false;
            this.TP_Ordem.ST_LimpaCampo = true;
            this.TP_Ordem.ST_NotNull = true;
            this.TP_Ordem.ST_PrimaryKey = false;
            this.TP_Ordem.TabIndex = 2;
            this.TP_Ordem.TextOld = null;
            this.TP_Ordem.Leave += new System.EventHandler(this.TP_Ordem_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(15, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 13);
            this.label17.TabIndex = 86;
            this.label17.Text = "Tipo de Ordem:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemServico, "Nm_empresa", true));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(207, 3);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(576, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 68;
            this.NM_Empresa.TextOld = null;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Enabled = false;
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(173, 3);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 1;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.Color.White;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemServico, "Cd_empresa", true));
            this.CD_Empresa.Enabled = false;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(102, 3);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(68, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(44, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Empresa:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(795, 43);
            this.barraMenu.TabIndex = 14;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(95, 40);
            this.BB_Gravar.Text = "\r\nGravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "\r\nCancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // FLocOrdemServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 266);
            this.Controls.Add(this.panelDados1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FLocOrdemServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nova Ordem de Serviço";
            this.Load += new System.EventHandler(this.FLocOrdemServico_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FLocOrdemServico_KeyDown);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbHorimetro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.horimetro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdemServico)).EndInit();
            this.RG_Data.ResumeLayout(false);
            this.pData.ResumeLayout(false);
            this.pData.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_os)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panel1;
        private Componentes.EditDefault Nr_patrimonio;
        private Componentes.EditFloat id_os;
        private System.Windows.Forms.Label label28;
        private Componentes.EditDefault DS_Produto;
        private Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.Label label21;
        private Componentes.EditDefault DS_TPOrdem;
        private System.Windows.Forms.Button BB_TPOrdem;
        private Componentes.EditDefault TP_Ordem;
        private System.Windows.Forms.Label label17;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bsOrdemServico;
        private Componentes.PanelDados panel2;
        private System.Windows.Forms.GroupBox gbHorimetro;
        private Componentes.EditFloat horimetro;
        private System.Windows.Forms.Label label36;
        private Componentes.EditDefault ds_defeitocliente;
        private Componentes.RadioGroup RG_Data;
        private Componentes.PanelDados pData;
        private System.Windows.Forms.Label label8;
        private Componentes.EditData DT_Prevista;
        private Componentes.EditData DT_Abertura;
        private System.Windows.Forms.Label label6;
        private Componentes.PanelDados panelDados1;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
    }
}