namespace Frota
{
    partial class TFOrdemColeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFOrdemColeta));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.dt_emissao = new Componentes.EditData(this.components);
            this.bsOrdemColeta = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nr_ordem = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nr_serie = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.uf = new Componentes.EditDefault(this.components);
            this.label42 = new System.Windows.Forms.Label();
            this.bbEndereco = new System.Windows.Forms.Button();
            this.cd_endereco = new Componentes.EditDefault(this.components);
            this.dsEndereco = new Componentes.EditDefault(this.components);
            this.cnpj_emitente = new Componentes.EditDefault(this.components);
            this.label41 = new System.Windows.Forms.Label();
            this.cd_emitente = new Componentes.EditDefault(this.components);
            this.nm_emitente = new Componentes.EditDefault(this.components);
            this.bbEmitente = new System.Windows.Forms.Button();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdemColeta)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(666, 43);
            this.barraMenu.TabIndex = 10;
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
            this.pDados.Controls.Add(this.dt_emissao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.nr_ordem);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.nr_serie);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.uf);
            this.pDados.Controls.Add(this.label42);
            this.pDados.Controls.Add(this.bbEndereco);
            this.pDados.Controls.Add(this.cd_endereco);
            this.pDados.Controls.Add(this.dsEndereco);
            this.pDados.Controls.Add(this.cnpj_emitente);
            this.pDados.Controls.Add(this.label41);
            this.pDados.Controls.Add(this.cd_emitente);
            this.pDados.Controls.Add(this.nm_emitente);
            this.pDados.Controls.Add(this.bbEmitente);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(666, 126);
            this.pDados.TabIndex = 11;
            // 
            // dt_emissao
            // 
            this.dt_emissao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_emissao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemColeta, "Dt_emissaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_emissao.Location = new System.Drawing.Point(186, 98);
            this.dt_emissao.Mask = "00/00/0000";
            this.dt_emissao.Name = "dt_emissao";
            this.dt_emissao.NM_Alias = "";
            this.dt_emissao.NM_Campo = "";
            this.dt_emissao.NM_CampoBusca = "";
            this.dt_emissao.NM_Param = "";
            this.dt_emissao.Operador = "";
            this.dt_emissao.Size = new System.Drawing.Size(74, 20);
            this.dt_emissao.ST_Gravar = true;
            this.dt_emissao.ST_LimpaCampo = true;
            this.dt_emissao.ST_NotNull = true;
            this.dt_emissao.ST_PrimaryKey = false;
            this.dt_emissao.TabIndex = 6;
            // 
            // bsOrdemColeta
            // 
            this.bsOrdemColeta.DataSource = typeof(CamadaDados.Faturamento.CTRC.TList_CTROrdemColeta);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 91;
            this.label3.Text = "Dt. Emissão";
            // 
            // nr_ordem
            // 
            this.nr_ordem.BackColor = System.Drawing.SystemColors.Window;
            this.nr_ordem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_ordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_ordem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemColeta, "Nr_ordem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_ordem.Location = new System.Drawing.Point(96, 98);
            this.nr_ordem.MaxLength = 6;
            this.nr_ordem.Name = "nr_ordem";
            this.nr_ordem.NM_Alias = "";
            this.nr_ordem.NM_Campo = "";
            this.nr_ordem.NM_CampoBusca = "";
            this.nr_ordem.NM_Param = "";
            this.nr_ordem.QTD_Zero = 0;
            this.nr_ordem.Size = new System.Drawing.Size(84, 20);
            this.nr_ordem.ST_AutoInc = false;
            this.nr_ordem.ST_DisableAuto = false;
            this.nr_ordem.ST_Float = false;
            this.nr_ordem.ST_Gravar = true;
            this.nr_ordem.ST_Int = true;
            this.nr_ordem.ST_LimpaCampo = true;
            this.nr_ordem.ST_NotNull = false;
            this.nr_ordem.ST_PrimaryKey = false;
            this.nr_ordem.TabIndex = 5;
            this.nr_ordem.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 89;
            this.label2.Text = "Nº Ordem";
            // 
            // nr_serie
            // 
            this.nr_serie.BackColor = System.Drawing.SystemColors.Window;
            this.nr_serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_serie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemColeta, "Nr_serie", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_serie.Location = new System.Drawing.Point(6, 98);
            this.nr_serie.MaxLength = 3;
            this.nr_serie.Name = "nr_serie";
            this.nr_serie.NM_Alias = "";
            this.nr_serie.NM_Campo = "";
            this.nr_serie.NM_CampoBusca = "";
            this.nr_serie.NM_Param = "";
            this.nr_serie.QTD_Zero = 0;
            this.nr_serie.Size = new System.Drawing.Size(84, 20);
            this.nr_serie.ST_AutoInc = false;
            this.nr_serie.ST_DisableAuto = false;
            this.nr_serie.ST_Float = false;
            this.nr_serie.ST_Gravar = true;
            this.nr_serie.ST_Int = false;
            this.nr_serie.ST_LimpaCampo = true;
            this.nr_serie.ST_NotNull = false;
            this.nr_serie.ST_PrimaryKey = false;
            this.nr_serie.TabIndex = 4;
            this.nr_serie.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Nº Serie";
            // 
            // uf
            // 
            this.uf.BackColor = System.Drawing.SystemColors.Window;
            this.uf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.uf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemColeta, "Uf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.uf.Enabled = false;
            this.uf.Location = new System.Drawing.Point(629, 59);
            this.uf.Name = "uf";
            this.uf.NM_Alias = "";
            this.uf.NM_Campo = "uf";
            this.uf.NM_CampoBusca = "uf";
            this.uf.NM_Param = "@P_NM_EMPRESA";
            this.uf.QTD_Zero = 0;
            this.uf.Size = new System.Drawing.Size(32, 20);
            this.uf.ST_AutoInc = false;
            this.uf.ST_DisableAuto = false;
            this.uf.ST_Float = false;
            this.uf.ST_Gravar = false;
            this.uf.ST_Int = false;
            this.uf.ST_LimpaCampo = true;
            this.uf.ST_NotNull = false;
            this.uf.ST_PrimaryKey = false;
            this.uf.TabIndex = 86;
            this.uf.TextOld = null;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(3, 43);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(53, 13);
            this.label42.TabIndex = 85;
            this.label42.Text = "Endereço";
            // 
            // bbEndereco
            // 
            this.bbEndereco.Image = ((System.Drawing.Image)(resources.GetObject("bbEndereco.Image")));
            this.bbEndereco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbEndereco.Location = new System.Drawing.Point(62, 59);
            this.bbEndereco.Name = "bbEndereco";
            this.bbEndereco.Size = new System.Drawing.Size(28, 20);
            this.bbEndereco.TabIndex = 3;
            this.bbEndereco.UseVisualStyleBackColor = true;
            this.bbEndereco.Click += new System.EventHandler(this.bbEndereco_Click);
            // 
            // cd_endereco
            // 
            this.cd_endereco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemColeta, "Cd_endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_endereco.Location = new System.Drawing.Point(6, 59);
            this.cd_endereco.Name = "cd_endereco";
            this.cd_endereco.NM_Alias = "";
            this.cd_endereco.NM_Campo = "cd_endereco";
            this.cd_endereco.NM_CampoBusca = "cd_endereco";
            this.cd_endereco.NM_Param = "@P_CD_EMPRESA";
            this.cd_endereco.QTD_Zero = 0;
            this.cd_endereco.Size = new System.Drawing.Size(50, 20);
            this.cd_endereco.ST_AutoInc = false;
            this.cd_endereco.ST_DisableAuto = false;
            this.cd_endereco.ST_Float = false;
            this.cd_endereco.ST_Gravar = true;
            this.cd_endereco.ST_Int = false;
            this.cd_endereco.ST_LimpaCampo = true;
            this.cd_endereco.ST_NotNull = true;
            this.cd_endereco.ST_PrimaryKey = false;
            this.cd_endereco.TabIndex = 2;
            this.cd_endereco.TextOld = null;
            this.cd_endereco.Leave += new System.EventHandler(this.cd_endereco_Leave);
            // 
            // dsEndereco
            // 
            this.dsEndereco.BackColor = System.Drawing.SystemColors.Window;
            this.dsEndereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dsEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dsEndereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemColeta, "Ds_endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dsEndereco.Enabled = false;
            this.dsEndereco.Location = new System.Drawing.Point(96, 59);
            this.dsEndereco.Name = "dsEndereco";
            this.dsEndereco.NM_Alias = "";
            this.dsEndereco.NM_Campo = "ds_endereco";
            this.dsEndereco.NM_CampoBusca = "ds_endereco";
            this.dsEndereco.NM_Param = "@P_NM_EMPRESA";
            this.dsEndereco.QTD_Zero = 0;
            this.dsEndereco.Size = new System.Drawing.Size(527, 20);
            this.dsEndereco.ST_AutoInc = false;
            this.dsEndereco.ST_DisableAuto = false;
            this.dsEndereco.ST_Float = false;
            this.dsEndereco.ST_Gravar = false;
            this.dsEndereco.ST_Int = false;
            this.dsEndereco.ST_LimpaCampo = true;
            this.dsEndereco.ST_NotNull = false;
            this.dsEndereco.ST_PrimaryKey = false;
            this.dsEndereco.TabIndex = 84;
            this.dsEndereco.TextOld = null;
            // 
            // cnpj_emitente
            // 
            this.cnpj_emitente.BackColor = System.Drawing.SystemColors.Window;
            this.cnpj_emitente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cnpj_emitente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cnpj_emitente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemColeta, "Cnpj_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cnpj_emitente.Enabled = false;
            this.cnpj_emitente.Location = new System.Drawing.Point(542, 20);
            this.cnpj_emitente.Name = "cnpj_emitente";
            this.cnpj_emitente.NM_Alias = "";
            this.cnpj_emitente.NM_Campo = " nr_cgc";
            this.cnpj_emitente.NM_CampoBusca = "nr_cgc";
            this.cnpj_emitente.NM_Param = "@P_NM_EMPRESA";
            this.cnpj_emitente.QTD_Zero = 0;
            this.cnpj_emitente.Size = new System.Drawing.Size(119, 20);
            this.cnpj_emitente.ST_AutoInc = false;
            this.cnpj_emitente.ST_DisableAuto = false;
            this.cnpj_emitente.ST_Float = false;
            this.cnpj_emitente.ST_Gravar = false;
            this.cnpj_emitente.ST_Int = false;
            this.cnpj_emitente.ST_LimpaCampo = true;
            this.cnpj_emitente.ST_NotNull = false;
            this.cnpj_emitente.ST_PrimaryKey = false;
            this.cnpj_emitente.TabIndex = 81;
            this.cnpj_emitente.TextOld = null;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(3, 4);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(48, 13);
            this.label41.TabIndex = 80;
            this.label41.Text = "Emitente";
            // 
            // cd_emitente
            // 
            this.cd_emitente.BackColor = System.Drawing.Color.White;
            this.cd_emitente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_emitente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_emitente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemColeta, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_emitente.Location = new System.Drawing.Point(6, 20);
            this.cd_emitente.Name = "cd_emitente";
            this.cd_emitente.NM_Alias = "";
            this.cd_emitente.NM_Campo = "cd_clifor";
            this.cd_emitente.NM_CampoBusca = "cd_clifor";
            this.cd_emitente.NM_Param = "@P_CD_EMPRESA";
            this.cd_emitente.QTD_Zero = 0;
            this.cd_emitente.Size = new System.Drawing.Size(105, 20);
            this.cd_emitente.ST_AutoInc = false;
            this.cd_emitente.ST_DisableAuto = false;
            this.cd_emitente.ST_Float = false;
            this.cd_emitente.ST_Gravar = true;
            this.cd_emitente.ST_Int = false;
            this.cd_emitente.ST_LimpaCampo = true;
            this.cd_emitente.ST_NotNull = true;
            this.cd_emitente.ST_PrimaryKey = false;
            this.cd_emitente.TabIndex = 0;
            this.cd_emitente.TextOld = null;
            this.cd_emitente.Leave += new System.EventHandler(this.cd_emitente_Leave);
            // 
            // nm_emitente
            // 
            this.nm_emitente.BackColor = System.Drawing.SystemColors.Window;
            this.nm_emitente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_emitente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_emitente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemColeta, "Nm_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_emitente.Enabled = false;
            this.nm_emitente.Location = new System.Drawing.Point(146, 20);
            this.nm_emitente.Name = "nm_emitente";
            this.nm_emitente.NM_Alias = "";
            this.nm_emitente.NM_Campo = "nm_clifor";
            this.nm_emitente.NM_CampoBusca = "nm_clifor";
            this.nm_emitente.NM_Param = "@P_NM_EMPRESA";
            this.nm_emitente.QTD_Zero = 0;
            this.nm_emitente.Size = new System.Drawing.Size(390, 20);
            this.nm_emitente.ST_AutoInc = false;
            this.nm_emitente.ST_DisableAuto = false;
            this.nm_emitente.ST_Float = false;
            this.nm_emitente.ST_Gravar = false;
            this.nm_emitente.ST_Int = false;
            this.nm_emitente.ST_LimpaCampo = true;
            this.nm_emitente.ST_NotNull = false;
            this.nm_emitente.ST_PrimaryKey = false;
            this.nm_emitente.TabIndex = 79;
            this.nm_emitente.TextOld = null;
            // 
            // bbEmitente
            // 
            this.bbEmitente.Image = ((System.Drawing.Image)(resources.GetObject("bbEmitente.Image")));
            this.bbEmitente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbEmitente.Location = new System.Drawing.Point(112, 20);
            this.bbEmitente.Name = "bbEmitente";
            this.bbEmitente.Size = new System.Drawing.Size(28, 20);
            this.bbEmitente.TabIndex = 1;
            this.bbEmitente.UseVisualStyleBackColor = true;
            this.bbEmitente.Click += new System.EventHandler(this.bbEmitente_Click);
            // 
            // TFOrdemColeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 169);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFOrdemColeta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordem Coleta";
            this.Load += new System.EventHandler(this.TFOrdemColeta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFOrdemColeta_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdemColeta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault cnpj_emitente;
        private System.Windows.Forms.BindingSource bsOrdemColeta;
        private System.Windows.Forms.Label label41;
        private Componentes.EditDefault cd_emitente;
        private Componentes.EditDefault nm_emitente;
        private System.Windows.Forms.Button bbEmitente;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button bbEndereco;
        private Componentes.EditDefault cd_endereco;
        private Componentes.EditDefault dsEndereco;
        private Componentes.EditDefault uf;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nr_ordem;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nr_serie;
        private System.Windows.Forms.Label label1;
        private Componentes.EditData dt_emissao;
    }
}