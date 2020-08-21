namespace Proc_Commoditties
{
    partial class TFGerarXmlNfe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFGerarXmlNfe));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_gerararquivo = new System.Windows.Forms.ToolStripButton();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.st_email = new Componentes.CheckBoxDefault(this.components);
            this.st_compactar = new Componentes.CheckBoxDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.nr_notafiscal = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bb_clifor = new System.Windows.Forms.Button();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.dt_final = new Componentes.EditData(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.dt_inicial = new Componentes.EditData(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
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
            this.barraMenu.Size = new System.Drawing.Size(614, 43);
            this.barraMenu.TabIndex = 8;
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
            this.pFiltro.Controls.Add(this.cbEmpresa);
            this.pFiltro.Controls.Add(this.panelDados1);
            this.pFiltro.Controls.Add(this.label5);
            this.pFiltro.Controls.Add(this.nr_notafiscal);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.bb_clifor);
            this.pFiltro.Controls.Add(this.cd_clifor);
            this.pFiltro.Controls.Add(this.nm_clifor);
            this.pFiltro.Controls.Add(this.dt_final);
            this.pFiltro.Controls.Add(this.label16);
            this.pFiltro.Controls.Add(this.dt_inicial);
            this.pFiltro.Controls.Add(this.label17);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(0, 43);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(614, 139);
            this.pFiltro.TabIndex = 7;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.LightGray;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.st_email);
            this.panelDados1.Controls.Add(this.st_compactar);
            this.panelDados1.Location = new System.Drawing.Point(109, 86);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(493, 43);
            this.panelDados1.TabIndex = 6;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(322, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Nº NFe:";
            // 
            // nr_notafiscal
            // 
            this.nr_notafiscal.BackColor = System.Drawing.SystemColors.Window;
            this.nr_notafiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_notafiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_notafiscal.Location = new System.Drawing.Point(380, 8);
            this.nr_notafiscal.Name = "nr_notafiscal";
            this.nr_notafiscal.NM_Alias = "";
            this.nr_notafiscal.NM_Campo = "";
            this.nr_notafiscal.NM_CampoBusca = "";
            this.nr_notafiscal.NM_Param = "";
            this.nr_notafiscal.QTD_Zero = 0;
            this.nr_notafiscal.Size = new System.Drawing.Size(100, 20);
            this.nr_notafiscal.ST_AutoInc = false;
            this.nr_notafiscal.ST_DisableAuto = false;
            this.nr_notafiscal.ST_Float = false;
            this.nr_notafiscal.ST_Gravar = false;
            this.nr_notafiscal.ST_Int = true;
            this.nr_notafiscal.ST_LimpaCampo = true;
            this.nr_notafiscal.ST_NotNull = false;
            this.nr_notafiscal.ST_PrimaryKey = false;
            this.nr_notafiscal.TabIndex = 2;
            this.nr_notafiscal.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(44, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Cliente:";
            // 
            // bb_clifor
            // 
            this.bb_clifor.BackColor = System.Drawing.SystemColors.Control;
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.Location = new System.Drawing.Point(211, 60);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(28, 19);
            this.bb_clifor.TabIndex = 5;
            this.bb_clifor.UseVisualStyleBackColor = false;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.Location = new System.Drawing.Point(109, 60);
            this.cd_clifor.MaxLength = 10;
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_CLIFOR";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(100, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = false;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 4;
            this.cd_clifor.TextOld = null;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Location = new System.Drawing.Point(245, 60);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_NM_CLIFOR";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(357, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 4;
            this.nm_clifor.TextOld = null;
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
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(109, 33);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(371, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 3;
            this.cbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbEmpresa_SelectedIndexChanged);
            // 
            // TFGerarXmlNfe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 182);
            this.Controls.Add(this.pFiltro);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFGerarXmlNfe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Arquivo XML NF-e";
            this.Load += new System.EventHandler(this.TFGerarXmlNfe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFGerarXmlNfe_KeyDown);
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

        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault cd_clifor;
        private Componentes.EditDefault nm_clifor;
        private Componentes.EditData dt_final;
        private System.Windows.Forms.Label label16;
        private Componentes.EditData dt_inicial;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_gerararquivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault nr_notafiscal;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private Componentes.PanelDados panelDados1;
        private Componentes.CheckBoxDefault st_email;
        private Componentes.CheckBoxDefault st_compactar;
        private Componentes.ComboBoxDefault cbEmpresa;
    }
}