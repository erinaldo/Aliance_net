namespace Proc_Commoditties
{
    partial class TFGerarXMLCTe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFGerarXMLCTe));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_gerararquivo = new System.Windows.Forms.ToolStripButton();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_destinatario = new System.Windows.Forms.Button();
            this.cd_destinatario = new Componentes.EditDefault(this.components);
            this.nm_destinatario = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.nr_cte = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_remetente = new System.Windows.Forms.Button();
            this.cd_remetente = new Componentes.EditDefault(this.components);
            this.nm_remente = new Componentes.EditDefault(this.components);
            this.dt_final = new Componentes.EditData(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.dt_inicial = new Componentes.EditData(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.st_compactar = new Componentes.CheckBoxDefault(this.components);
            this.st_email = new Componentes.CheckBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_gerararquivo,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(610, 43);
            this.barraMenu.TabIndex = 9;
            // 
            // bb_gerararquivo
            // 
            this.bb_gerararquivo.AutoSize = false;
            this.bb_gerararquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_gerararquivo.ForeColor = System.Drawing.Color.Green;
            this.bb_gerararquivo.Image = ((System.Drawing.Image)(resources.GetObject("bb_gerararquivo.Image")));
            this.bb_gerararquivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_gerararquivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_gerararquivo.Name = "bb_gerararquivo";
            this.bb_gerararquivo.Size = new System.Drawing.Size(125, 40);
            this.bb_gerararquivo.Text = "(F4)\r\nGerar Arquivo";
            this.bb_gerararquivo.ToolTipText = "Gerar Arquivo NF-e";
            this.bb_gerararquivo.Click += new System.EventHandler(this.bb_gerararquivo_Click);
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(54, 40);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.panelDados1);
            this.pFiltro.Controls.Add(this.label4);
            this.pFiltro.Controls.Add(this.bb_destinatario);
            this.pFiltro.Controls.Add(this.cd_destinatario);
            this.pFiltro.Controls.Add(this.nm_destinatario);
            this.pFiltro.Controls.Add(this.label5);
            this.pFiltro.Controls.Add(this.nr_cte);
            this.pFiltro.Controls.Add(this.NM_Empresa);
            this.pFiltro.Controls.Add(this.BB_Empresa);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.CD_Empresa);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.bb_remetente);
            this.pFiltro.Controls.Add(this.cd_remetente);
            this.pFiltro.Controls.Add(this.nm_remente);
            this.pFiltro.Controls.Add(this.dt_final);
            this.pFiltro.Controls.Add(this.label16);
            this.pFiltro.Controls.Add(this.dt_inicial);
            this.pFiltro.Controls.Add(this.label17);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(0, 43);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(610, 168);
            this.pFiltro.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Destinatario:";
            // 
            // bb_destinatario
            // 
            this.bb_destinatario.BackColor = System.Drawing.SystemColors.Control;
            this.bb_destinatario.Image = ((System.Drawing.Image)(resources.GetObject("bb_destinatario.Image")));
            this.bb_destinatario.Location = new System.Drawing.Point(211, 86);
            this.bb_destinatario.Name = "bb_destinatario";
            this.bb_destinatario.Size = new System.Drawing.Size(28, 19);
            this.bb_destinatario.TabIndex = 48;
            this.bb_destinatario.UseVisualStyleBackColor = false;
            this.bb_destinatario.Click += new System.EventHandler(this.bb_destinatario_Click);
            // 
            // cd_destinatario
            // 
            this.cd_destinatario.BackColor = System.Drawing.SystemColors.Window;
            this.cd_destinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_destinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_destinatario.Location = new System.Drawing.Point(109, 86);
            this.cd_destinatario.MaxLength = 10;
            this.cd_destinatario.Name = "cd_destinatario";
            this.cd_destinatario.NM_Alias = "";
            this.cd_destinatario.NM_Campo = "cd_clifor";
            this.cd_destinatario.NM_CampoBusca = "cd_clifor";
            this.cd_destinatario.NM_Param = "@P_CD_CLIFOR";
            this.cd_destinatario.QTD_Zero = 0;
            this.cd_destinatario.Size = new System.Drawing.Size(100, 20);
            this.cd_destinatario.ST_AutoInc = false;
            this.cd_destinatario.ST_DisableAuto = false;
            this.cd_destinatario.ST_Float = false;
            this.cd_destinatario.ST_Gravar = true;
            this.cd_destinatario.ST_Int = false;
            this.cd_destinatario.ST_LimpaCampo = true;
            this.cd_destinatario.ST_NotNull = false;
            this.cd_destinatario.ST_PrimaryKey = false;
            this.cd_destinatario.TabIndex = 47;
            this.cd_destinatario.TextOld = null;
            this.cd_destinatario.Leave += new System.EventHandler(this.cd_destinatario_Leave);
            // 
            // nm_destinatario
            // 
            this.nm_destinatario.BackColor = System.Drawing.SystemColors.Window;
            this.nm_destinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_destinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_destinatario.Enabled = false;
            this.nm_destinatario.Location = new System.Drawing.Point(245, 86);
            this.nm_destinatario.Name = "nm_destinatario";
            this.nm_destinatario.NM_Alias = "";
            this.nm_destinatario.NM_Campo = "nm_clifor";
            this.nm_destinatario.NM_CampoBusca = "nm_clifor";
            this.nm_destinatario.NM_Param = "@P_NM_CLIFOR";
            this.nm_destinatario.QTD_Zero = 0;
            this.nm_destinatario.Size = new System.Drawing.Size(357, 20);
            this.nm_destinatario.ST_AutoInc = false;
            this.nm_destinatario.ST_DisableAuto = false;
            this.nm_destinatario.ST_Float = false;
            this.nm_destinatario.ST_Gravar = false;
            this.nm_destinatario.ST_Int = false;
            this.nm_destinatario.ST_LimpaCampo = true;
            this.nm_destinatario.ST_NotNull = false;
            this.nm_destinatario.ST_PrimaryKey = false;
            this.nm_destinatario.TabIndex = 46;
            this.nm_destinatario.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(322, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Nº CTe:";
            // 
            // nr_cte
            // 
            this.nr_cte.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_cte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cte.Location = new System.Drawing.Point(380, 8);
            this.nr_cte.Name = "nr_cte";
            this.nr_cte.NM_Alias = "";
            this.nr_cte.NM_Campo = "";
            this.nr_cte.NM_CampoBusca = "";
            this.nr_cte.NM_Param = "";
            this.nr_cte.QTD_Zero = 0;
            this.nr_cte.Size = new System.Drawing.Size(100, 20);
            this.nr_cte.ST_AutoInc = false;
            this.nr_cte.ST_DisableAuto = false;
            this.nr_cte.ST_Float = false;
            this.nr_cte.ST_Gravar = false;
            this.nr_cte.ST_Int = true;
            this.nr_cte.ST_LimpaCampo = true;
            this.nr_cte.ST_NotNull = false;
            this.nr_cte.ST_PrimaryKey = false;
            this.nr_cte.TabIndex = 2;
            this.nr_cte.TextOld = null;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(217, 34);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(385, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 43;
            this.NM_Empresa.TextOld = null;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(186, 34);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 4;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Transportadora:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(109, 34);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(75, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = false;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 3;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Remetente:";
            // 
            // bb_remetente
            // 
            this.bb_remetente.BackColor = System.Drawing.SystemColors.Control;
            this.bb_remetente.Image = ((System.Drawing.Image)(resources.GetObject("bb_remetente.Image")));
            this.bb_remetente.Location = new System.Drawing.Point(211, 60);
            this.bb_remetente.Name = "bb_remetente";
            this.bb_remetente.Size = new System.Drawing.Size(28, 19);
            this.bb_remetente.TabIndex = 6;
            this.bb_remetente.UseVisualStyleBackColor = false;
            this.bb_remetente.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // cd_remetente
            // 
            this.cd_remetente.BackColor = System.Drawing.SystemColors.Window;
            this.cd_remetente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_remetente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_remetente.Location = new System.Drawing.Point(109, 60);
            this.cd_remetente.MaxLength = 10;
            this.cd_remetente.Name = "cd_remetente";
            this.cd_remetente.NM_Alias = "";
            this.cd_remetente.NM_Campo = "cd_clifor";
            this.cd_remetente.NM_CampoBusca = "cd_clifor";
            this.cd_remetente.NM_Param = "@P_CD_CLIFOR";
            this.cd_remetente.QTD_Zero = 0;
            this.cd_remetente.Size = new System.Drawing.Size(100, 20);
            this.cd_remetente.ST_AutoInc = false;
            this.cd_remetente.ST_DisableAuto = false;
            this.cd_remetente.ST_Float = false;
            this.cd_remetente.ST_Gravar = true;
            this.cd_remetente.ST_Int = false;
            this.cd_remetente.ST_LimpaCampo = true;
            this.cd_remetente.ST_NotNull = false;
            this.cd_remetente.ST_PrimaryKey = false;
            this.cd_remetente.TabIndex = 5;
            this.cd_remetente.TextOld = null;
            this.cd_remetente.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // nm_remente
            // 
            this.nm_remente.BackColor = System.Drawing.SystemColors.Window;
            this.nm_remente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_remente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_remente.Enabled = false;
            this.nm_remente.Location = new System.Drawing.Point(245, 60);
            this.nm_remente.Name = "nm_remente";
            this.nm_remente.NM_Alias = "";
            this.nm_remente.NM_Campo = "nm_clifor";
            this.nm_remente.NM_CampoBusca = "nm_clifor";
            this.nm_remente.NM_Param = "@P_NM_CLIFOR";
            this.nm_remente.QTD_Zero = 0;
            this.nm_remente.Size = new System.Drawing.Size(357, 20);
            this.nm_remente.ST_AutoInc = false;
            this.nm_remente.ST_DisableAuto = false;
            this.nm_remente.ST_Float = false;
            this.nm_remente.ST_Gravar = false;
            this.nm_remente.ST_Int = false;
            this.nm_remente.ST_LimpaCampo = true;
            this.nm_remente.ST_NotNull = false;
            this.nm_remente.ST_PrimaryKey = false;
            this.nm_remente.TabIndex = 4;
            this.nm_remente.TextOld = null;
            // 
            // dt_final
            // 
            this.dt_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_final.Location = new System.Drawing.Point(246, 8);
            this.dt_final.Mask = "00/00/0000";
            this.dt_final.Name = "dt_final";
            this.dt_final.NM_Alias = "";
            this.dt_final.NM_Campo = "";
            this.dt_final.NM_CampoBusca = "";
            this.dt_final.NM_Param = "";
            this.dt_final.Operador = "";
            this.dt_final.Size = new System.Drawing.Size(70, 20);
            this.dt_final.ST_Gravar = false;
            this.dt_final.ST_LimpaCampo = true;
            this.dt_final.ST_NotNull = false;
            this.dt_final.ST_PrimaryKey = false;
            this.dt_final.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(185, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Dt. Final";
            // 
            // dt_inicial
            // 
            this.dt_inicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_inicial.Location = new System.Drawing.Point(109, 8);
            this.dt_inicial.Mask = "00/00/0000";
            this.dt_inicial.Name = "dt_inicial";
            this.dt_inicial.NM_Alias = "";
            this.dt_inicial.NM_Campo = "";
            this.dt_inicial.NM_CampoBusca = "";
            this.dt_inicial.NM_Param = "";
            this.dt_inicial.Operador = "";
            this.dt_inicial.Size = new System.Drawing.Size(70, 20);
            this.dt_inicial.ST_Gravar = false;
            this.dt_inicial.ST_LimpaCampo = true;
            this.dt_inicial.ST_NotNull = false;
            this.dt_inicial.ST_PrimaryKey = false;
            this.dt_inicial.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(41, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Dt. Inicial";
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.LightGray;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.st_email);
            this.panelDados1.Controls.Add(this.st_compactar);
            this.panelDados1.Location = new System.Drawing.Point(109, 112);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(493, 43);
            this.panelDados1.TabIndex = 50;
            // 
            // st_compactar
            // 
            this.st_compactar.AutoSize = true;
            this.st_compactar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_compactar.Location = new System.Drawing.Point(3, 12);
            this.st_compactar.Name = "st_compactar";
            this.st_compactar.NM_Alias = "";
            this.st_compactar.NM_Campo = "";
            this.st_compactar.NM_Param = "";
            this.st_compactar.Size = new System.Drawing.Size(218, 17);
            this.st_compactar.ST_Gravar = false;
            this.st_compactar.ST_LimparCampo = true;
            this.st_compactar.ST_NotNull = false;
            this.st_compactar.TabIndex = 0;
            this.st_compactar.Text = "Compactar Arquivos Gerados(ZIP)";
            this.st_compactar.UseVisualStyleBackColor = true;
            this.st_compactar.Vl_False = "";
            this.st_compactar.Vl_True = "";
            // 
            // st_email
            // 
            this.st_email.AutoSize = true;
            this.st_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_email.Location = new System.Drawing.Point(316, 12);
            this.st_email.Name = "st_email";
            this.st_email.NM_Alias = "";
            this.st_email.NM_Campo = "";
            this.st_email.NM_Param = "";
            this.st_email.Size = new System.Drawing.Size(171, 17);
            this.st_email.ST_Gravar = false;
            this.st_email.ST_LimparCampo = true;
            this.st_email.ST_NotNull = false;
            this.st_email.TabIndex = 1;
            this.st_email.Text = "Enviar Arquivos por Email";
            this.st_email.UseVisualStyleBackColor = true;
            this.st_email.Vl_False = "";
            this.st_email.Vl_True = "";
            // 
            // TFGerarXMLCTe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 211);
            this.Controls.Add(this.pFiltro);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFGerarXMLCTe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar XML CTe Emitidos";
            this.Load += new System.EventHandler(this.TFGerarXMLCTe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFGerarXMLCTe_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_gerararquivo;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault nr_cte;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_remetente;
        private Componentes.EditDefault cd_remetente;
        private Componentes.EditDefault nm_remente;
        private Componentes.EditData dt_final;
        private System.Windows.Forms.Label label16;
        private Componentes.EditData dt_inicial;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_destinatario;
        private Componentes.EditDefault cd_destinatario;
        private Componentes.EditDefault nm_destinatario;
        private Componentes.PanelDados panelDados1;
        private Componentes.CheckBoxDefault st_compactar;
        private Componentes.CheckBoxDefault st_email;
    }
}