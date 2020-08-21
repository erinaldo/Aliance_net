namespace Frota
{
    partial class TFSeguroMDFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFSeguroMDFe));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.nr_averbacao = new Componentes.EditDefault(this.components);
            this.bsSeguro = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nr_apolice = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_seguradora = new System.Windows.Forms.Button();
            this.nm_seguradora = new Componentes.EditDefault(this.components);
            this.cd_seguradora = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_responsavel = new System.Windows.Forms.Button();
            this.nm_responsavel = new Componentes.EditDefault(this.components);
            this.cd_responsavel = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tp_responsavel = new Componentes.ComboBoxDefault(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSeguro)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(518, 43);
            this.barraMenu.TabIndex = 22;
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
            this.pDados.Controls.Add(this.nr_averbacao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.nr_apolice);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.bb_seguradora);
            this.pDados.Controls.Add(this.nm_seguradora);
            this.pDados.Controls.Add(this.cd_seguradora);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.bb_responsavel);
            this.pDados.Controls.Add(this.nm_responsavel);
            this.pDados.Controls.Add(this.cd_responsavel);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.tp_responsavel);
            this.pDados.Controls.Add(this.label14);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(518, 126);
            this.pDados.TabIndex = 0;
            // 
            // nr_averbacao
            // 
            this.nr_averbacao.BackColor = System.Drawing.SystemColors.Window;
            this.nr_averbacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_averbacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_averbacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguro, "Nr_averbacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_averbacao.Location = new System.Drawing.Point(215, 98);
            this.nr_averbacao.Name = "nr_averbacao";
            this.nr_averbacao.NM_Alias = "";
            this.nr_averbacao.NM_Campo = "";
            this.nr_averbacao.NM_CampoBusca = "";
            this.nr_averbacao.NM_Param = "";
            this.nr_averbacao.QTD_Zero = 0;
            this.nr_averbacao.Size = new System.Drawing.Size(298, 20);
            this.nr_averbacao.ST_AutoInc = false;
            this.nr_averbacao.ST_DisableAuto = false;
            this.nr_averbacao.ST_Float = false;
            this.nr_averbacao.ST_Gravar = false;
            this.nr_averbacao.ST_Int = false;
            this.nr_averbacao.ST_LimpaCampo = true;
            this.nr_averbacao.ST_NotNull = false;
            this.nr_averbacao.ST_PrimaryKey = false;
            this.nr_averbacao.TabIndex = 6;
            this.nr_averbacao.TextOld = null;
            // 
            // bsSeguro
            // 
            this.bsSeguro.DataSource = typeof(CamadaDados.Frota.TList_MDFe_Seguro);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "Averbação";
            // 
            // nr_apolice
            // 
            this.nr_apolice.BackColor = System.Drawing.SystemColors.Window;
            this.nr_apolice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_apolice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_apolice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguro, "Nr_apolice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_apolice.Location = new System.Drawing.Point(6, 98);
            this.nr_apolice.Name = "nr_apolice";
            this.nr_apolice.NM_Alias = "";
            this.nr_apolice.NM_Campo = "";
            this.nr_apolice.NM_CampoBusca = "";
            this.nr_apolice.NM_Param = "";
            this.nr_apolice.QTD_Zero = 0;
            this.nr_apolice.Size = new System.Drawing.Size(203, 20);
            this.nr_apolice.ST_AutoInc = false;
            this.nr_apolice.ST_DisableAuto = false;
            this.nr_apolice.ST_Float = false;
            this.nr_apolice.ST_Gravar = false;
            this.nr_apolice.ST_Int = false;
            this.nr_apolice.ST_LimpaCampo = true;
            this.nr_apolice.ST_NotNull = false;
            this.nr_apolice.ST_PrimaryKey = false;
            this.nr_apolice.TabIndex = 5;
            this.nr_apolice.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 108;
            this.label4.Text = "Apolice";
            // 
            // bb_seguradora
            // 
            this.bb_seguradora.Image = ((System.Drawing.Image)(resources.GetObject("bb_seguradora.Image")));
            this.bb_seguradora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_seguradora.Location = new System.Drawing.Point(75, 59);
            this.bb_seguradora.Name = "bb_seguradora";
            this.bb_seguradora.Size = new System.Drawing.Size(28, 20);
            this.bb_seguradora.TabIndex = 4;
            this.bb_seguradora.UseVisualStyleBackColor = true;
            this.bb_seguradora.Click += new System.EventHandler(this.bb_seguradora_Click);
            // 
            // nm_seguradora
            // 
            this.nm_seguradora.BackColor = System.Drawing.SystemColors.Window;
            this.nm_seguradora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_seguradora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_seguradora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguro, "Nm_seguradora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_seguradora.Enabled = false;
            this.nm_seguradora.Location = new System.Drawing.Point(109, 59);
            this.nm_seguradora.Name = "nm_seguradora";
            this.nm_seguradora.NM_Alias = "";
            this.nm_seguradora.NM_Campo = "nm_clifor";
            this.nm_seguradora.NM_CampoBusca = "nm_clifor";
            this.nm_seguradora.NM_Param = "@P_NM_CLIFOR";
            this.nm_seguradora.QTD_Zero = 0;
            this.nm_seguradora.Size = new System.Drawing.Size(404, 20);
            this.nm_seguradora.ST_AutoInc = false;
            this.nm_seguradora.ST_DisableAuto = false;
            this.nm_seguradora.ST_Float = false;
            this.nm_seguradora.ST_Gravar = false;
            this.nm_seguradora.ST_Int = false;
            this.nm_seguradora.ST_LimpaCampo = true;
            this.nm_seguradora.ST_NotNull = false;
            this.nm_seguradora.ST_PrimaryKey = false;
            this.nm_seguradora.TabIndex = 107;
            this.nm_seguradora.TextOld = null;
            // 
            // cd_seguradora
            // 
            this.cd_seguradora.BackColor = System.Drawing.SystemColors.Window;
            this.cd_seguradora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_seguradora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_seguradora.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguro, "Cd_seguradora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_seguradora.Location = new System.Drawing.Point(6, 59);
            this.cd_seguradora.Name = "cd_seguradora";
            this.cd_seguradora.NM_Alias = "";
            this.cd_seguradora.NM_Campo = "cd_clifor";
            this.cd_seguradora.NM_CampoBusca = "cd_clifor";
            this.cd_seguradora.NM_Param = "@P_CD_CLIFOR";
            this.cd_seguradora.QTD_Zero = 0;
            this.cd_seguradora.Size = new System.Drawing.Size(66, 20);
            this.cd_seguradora.ST_AutoInc = false;
            this.cd_seguradora.ST_DisableAuto = false;
            this.cd_seguradora.ST_Float = false;
            this.cd_seguradora.ST_Gravar = true;
            this.cd_seguradora.ST_Int = true;
            this.cd_seguradora.ST_LimpaCampo = true;
            this.cd_seguradora.ST_NotNull = true;
            this.cd_seguradora.ST_PrimaryKey = false;
            this.cd_seguradora.TabIndex = 3;
            this.cd_seguradora.TextOld = null;
            this.cd_seguradora.Leave += new System.EventHandler(this.cd_seguradora_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Seguradora";
            // 
            // bb_responsavel
            // 
            this.bb_responsavel.Image = ((System.Drawing.Image)(resources.GetObject("bb_responsavel.Image")));
            this.bb_responsavel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_responsavel.Location = new System.Drawing.Point(215, 19);
            this.bb_responsavel.Name = "bb_responsavel";
            this.bb_responsavel.Size = new System.Drawing.Size(28, 20);
            this.bb_responsavel.TabIndex = 2;
            this.bb_responsavel.UseVisualStyleBackColor = true;
            this.bb_responsavel.Click += new System.EventHandler(this.bb_responsavel_Click);
            // 
            // nm_responsavel
            // 
            this.nm_responsavel.BackColor = System.Drawing.SystemColors.Window;
            this.nm_responsavel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_responsavel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_responsavel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguro, "Nm_responsavel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_responsavel.Enabled = false;
            this.nm_responsavel.Location = new System.Drawing.Point(249, 19);
            this.nm_responsavel.Name = "nm_responsavel";
            this.nm_responsavel.NM_Alias = "";
            this.nm_responsavel.NM_Campo = "nm_clifor";
            this.nm_responsavel.NM_CampoBusca = "nm_clifor";
            this.nm_responsavel.NM_Param = "@P_NM_CLIFOR";
            this.nm_responsavel.QTD_Zero = 0;
            this.nm_responsavel.Size = new System.Drawing.Size(264, 20);
            this.nm_responsavel.ST_AutoInc = false;
            this.nm_responsavel.ST_DisableAuto = false;
            this.nm_responsavel.ST_Float = false;
            this.nm_responsavel.ST_Gravar = false;
            this.nm_responsavel.ST_Int = false;
            this.nm_responsavel.ST_LimpaCampo = true;
            this.nm_responsavel.ST_NotNull = false;
            this.nm_responsavel.ST_PrimaryKey = false;
            this.nm_responsavel.TabIndex = 103;
            this.nm_responsavel.TextOld = null;
            // 
            // cd_responsavel
            // 
            this.cd_responsavel.BackColor = System.Drawing.SystemColors.Window;
            this.cd_responsavel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_responsavel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_responsavel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSeguro, "Cd_responsavel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_responsavel.Location = new System.Drawing.Point(146, 19);
            this.cd_responsavel.Name = "cd_responsavel";
            this.cd_responsavel.NM_Alias = "";
            this.cd_responsavel.NM_Campo = "cd_clifor";
            this.cd_responsavel.NM_CampoBusca = "cd_clifor";
            this.cd_responsavel.NM_Param = "@P_CD_CLIFOR";
            this.cd_responsavel.QTD_Zero = 0;
            this.cd_responsavel.Size = new System.Drawing.Size(66, 20);
            this.cd_responsavel.ST_AutoInc = false;
            this.cd_responsavel.ST_DisableAuto = false;
            this.cd_responsavel.ST_Float = false;
            this.cd_responsavel.ST_Gravar = true;
            this.cd_responsavel.ST_Int = true;
            this.cd_responsavel.ST_LimpaCampo = true;
            this.cd_responsavel.ST_NotNull = false;
            this.cd_responsavel.ST_PrimaryKey = false;
            this.cd_responsavel.TabIndex = 1;
            this.cd_responsavel.TextOld = null;
            this.cd_responsavel.Leave += new System.EventHandler(this.cd_responsavel_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Responsavel";
            // 
            // tp_responsavel
            // 
            this.tp_responsavel.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsSeguro, "Tp_responsavel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_responsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_responsavel.FormattingEnabled = true;
            this.tp_responsavel.Location = new System.Drawing.Point(6, 19);
            this.tp_responsavel.Name = "tp_responsavel";
            this.tp_responsavel.NM_Alias = "";
            this.tp_responsavel.NM_Campo = "";
            this.tp_responsavel.NM_Param = "";
            this.tp_responsavel.Size = new System.Drawing.Size(134, 21);
            this.tp_responsavel.ST_Gravar = true;
            this.tp_responsavel.ST_LimparCampo = true;
            this.tp_responsavel.ST_NotNull = true;
            this.tp_responsavel.TabIndex = 0;
            this.tp_responsavel.SelectedIndexChanged += new System.EventHandler(this.tp_responsavel_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 98;
            this.label14.Text = "TP. Responsavel";
            // 
            // TFSeguroMDFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 169);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFSeguroMDFe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguro MDF-e";
            this.Load += new System.EventHandler(this.TFSeguroMDFe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFSeguroMDFe_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSeguro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label14;
        private Componentes.ComboBoxDefault tp_responsavel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_seguradora;
        private Componentes.EditDefault nm_seguradora;
        private Componentes.EditDefault cd_seguradora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_responsavel;
        private Componentes.EditDefault nm_responsavel;
        private Componentes.EditDefault cd_responsavel;
        private Componentes.EditDefault nr_averbacao;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nr_apolice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bsSeguro;
    }
}