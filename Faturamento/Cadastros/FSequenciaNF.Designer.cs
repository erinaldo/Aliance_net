namespace Faturamento.Cadastros
{
    partial class TFSequenciaNF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFSequenciaNF));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.seq_notafiscal = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.seq_rps = new Componentes.EditFloat(this.components);
            this.bsSequencia = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seq_notafiscal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seq_rps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSequencia)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(597, 43);
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
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.seq_rps);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.seq_notafiscal);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(597, 55);
            this.pDados.TabIndex = 11;
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(123, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSequencia, "NM_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(157, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_DS_PDV";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(435, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 94;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSequencia, "CD_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(68, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(53, 20);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Empresa:";
            // 
            // seq_notafiscal
            // 
            this.seq_notafiscal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsSequencia, "Seq_NotaFiscal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.seq_notafiscal.Location = new System.Drawing.Point(68, 29);
            this.seq_notafiscal.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.seq_notafiscal.Name = "seq_notafiscal";
            this.seq_notafiscal.NM_Alias = "";
            this.seq_notafiscal.NM_Campo = "";
            this.seq_notafiscal.NM_Param = "";
            this.seq_notafiscal.Operador = "";
            this.seq_notafiscal.Size = new System.Drawing.Size(120, 20);
            this.seq_notafiscal.ST_AutoInc = false;
            this.seq_notafiscal.ST_DisableAuto = false;
            this.seq_notafiscal.ST_Gravar = true;
            this.seq_notafiscal.ST_LimparCampo = true;
            this.seq_notafiscal.ST_NotNull = false;
            this.seq_notafiscal.ST_PrimaryKey = false;
            this.seq_notafiscal.TabIndex = 2;
            this.seq_notafiscal.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 104;
            this.label4.Text = "Ultima NF:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "Ultimo RPS:";
            // 
            // seq_rps
            // 
            this.seq_rps.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsSequencia, "Seq_RPS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.seq_rps.Location = new System.Drawing.Point(264, 29);
            this.seq_rps.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.seq_rps.Name = "seq_rps";
            this.seq_rps.NM_Alias = "";
            this.seq_rps.NM_Campo = "";
            this.seq_rps.NM_Param = "";
            this.seq_rps.Operador = "";
            this.seq_rps.Size = new System.Drawing.Size(120, 20);
            this.seq_rps.ST_AutoInc = false;
            this.seq_rps.ST_DisableAuto = false;
            this.seq_rps.ST_Gravar = false;
            this.seq_rps.ST_LimparCampo = true;
            this.seq_rps.ST_NotNull = false;
            this.seq_rps.ST_PrimaryKey = false;
            this.seq_rps.TabIndex = 3;
            this.seq_rps.ThousandsSeparator = true;
            // 
            // bsSequencia
            // 
            this.bsSequencia.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CadSequenciaNF);
            // 
            // TFSequenciaNF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 98);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFSequenciaNF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sequencia NF";
            this.Load += new System.EventHandler(this.TFSequenciaNF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFSequenciaNF_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seq_notafiscal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seq_rps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSequencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat seq_rps;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat seq_notafiscal;
        private System.Windows.Forms.BindingSource bsSequencia;
    }
}