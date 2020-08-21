namespace Parametros.Diversos
{
    partial class TFInscSubstEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFInscSubstEmpresa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_uf = new System.Windows.Forms.Button();
            this.ds_uf = new Componentes.EditDefault(this.components);
            this.lbl = new System.Windows.Forms.Label();
            this.cd_uf = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.insc_estadual_subst = new Componentes.EditDefault(this.components);
            this.bsSubst = new System.Windows.Forms.BindingSource(this.components);
            this.uf = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSubst)).BeginInit();
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
            this.pDados.Controls.Add(this.uf);
            this.pDados.Controls.Add(this.insc_estadual_subst);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.bb_uf);
            this.pDados.Controls.Add(this.ds_uf);
            this.pDados.Controls.Add(this.lbl);
            this.pDados.Controls.Add(this.cd_uf);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(518, 86);
            this.pDados.TabIndex = 11;
            // 
            // bb_uf
            // 
            this.bb_uf.Image = ((System.Drawing.Image)(resources.GetObject("bb_uf.Image")));
            this.bb_uf.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_uf.Location = new System.Drawing.Point(84, 19);
            this.bb_uf.Name = "bb_uf";
            this.bb_uf.Size = new System.Drawing.Size(28, 20);
            this.bb_uf.TabIndex = 92;
            this.bb_uf.UseVisualStyleBackColor = true;
            this.bb_uf.Click += new System.EventHandler(this.bb_uf_Click);
            // 
            // ds_uf
            // 
            this.ds_uf.BackColor = System.Drawing.SystemColors.Window;
            this.ds_uf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_uf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_uf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSubst, "Ds_uf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_uf.Enabled = false;
            this.ds_uf.Location = new System.Drawing.Point(118, 19);
            this.ds_uf.Name = "ds_uf";
            this.ds_uf.NM_Alias = "";
            this.ds_uf.NM_Campo = "ds_uf";
            this.ds_uf.NM_CampoBusca = "ds_uf";
            this.ds_uf.NM_Param = "@P_DS_PDV";
            this.ds_uf.QTD_Zero = 0;
            this.ds_uf.Size = new System.Drawing.Size(358, 20);
            this.ds_uf.ST_AutoInc = false;
            this.ds_uf.ST_DisableAuto = false;
            this.ds_uf.ST_Float = false;
            this.ds_uf.ST_Gravar = false;
            this.ds_uf.ST_Int = false;
            this.ds_uf.ST_LimpaCampo = true;
            this.ds_uf.ST_NotNull = false;
            this.ds_uf.ST_PrimaryKey = false;
            this.ds_uf.TabIndex = 94;
            this.ds_uf.TextOld = null;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl.Location = new System.Drawing.Point(3, 3);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(21, 13);
            this.lbl.TabIndex = 93;
            this.lbl.Text = "UF";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_uf
            // 
            this.cd_uf.BackColor = System.Drawing.SystemColors.Window;
            this.cd_uf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_uf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_uf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSubst, "Cd_uf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_uf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_uf.Location = new System.Drawing.Point(6, 19);
            this.cd_uf.Name = "cd_uf";
            this.cd_uf.NM_Alias = "";
            this.cd_uf.NM_Campo = "cd_uf";
            this.cd_uf.NM_CampoBusca = "cd_uf";
            this.cd_uf.NM_Param = "@P_CD_EMPRESA";
            this.cd_uf.QTD_Zero = 0;
            this.cd_uf.Size = new System.Drawing.Size(75, 20);
            this.cd_uf.ST_AutoInc = false;
            this.cd_uf.ST_DisableAuto = false;
            this.cd_uf.ST_Float = false;
            this.cd_uf.ST_Gravar = true;
            this.cd_uf.ST_Int = true;
            this.cd_uf.ST_LimpaCampo = true;
            this.cd_uf.ST_NotNull = true;
            this.cd_uf.ST_PrimaryKey = false;
            this.cd_uf.TabIndex = 91;
            this.cd_uf.TextOld = null;
            this.cd_uf.Leave += new System.EventHandler(this.cd_uf_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 95;
            this.label1.Text = "Inscrição Estadual Substituto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // insc_estadual_subst
            // 
            this.insc_estadual_subst.BackColor = System.Drawing.SystemColors.Window;
            this.insc_estadual_subst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.insc_estadual_subst.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.insc_estadual_subst.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSubst, "Insc_estadual_subst", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.insc_estadual_subst.Location = new System.Drawing.Point(6, 58);
            this.insc_estadual_subst.Name = "insc_estadual_subst";
            this.insc_estadual_subst.NM_Alias = "";
            this.insc_estadual_subst.NM_Campo = "";
            this.insc_estadual_subst.NM_CampoBusca = "";
            this.insc_estadual_subst.NM_Param = "";
            this.insc_estadual_subst.QTD_Zero = 0;
            this.insc_estadual_subst.Size = new System.Drawing.Size(141, 20);
            this.insc_estadual_subst.ST_AutoInc = false;
            this.insc_estadual_subst.ST_DisableAuto = false;
            this.insc_estadual_subst.ST_Float = false;
            this.insc_estadual_subst.ST_Gravar = true;
            this.insc_estadual_subst.ST_Int = false;
            this.insc_estadual_subst.ST_LimpaCampo = true;
            this.insc_estadual_subst.ST_NotNull = true;
            this.insc_estadual_subst.ST_PrimaryKey = false;
            this.insc_estadual_subst.TabIndex = 96;
            this.insc_estadual_subst.TextOld = null;
            this.insc_estadual_subst.Leave += new System.EventHandler(this.insc_estadual_subst_Leave);
            // 
            // bsSubst
            // 
            this.bsSubst.DataSource = typeof(CamadaDados.Diversos.TList_InscSubstEmpresa);
            // 
            // uf
            // 
            this.uf.BackColor = System.Drawing.SystemColors.Window;
            this.uf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.uf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSubst, "Uf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.uf.Enabled = false;
            this.uf.Location = new System.Drawing.Point(478, 19);
            this.uf.Name = "uf";
            this.uf.NM_Alias = "";
            this.uf.NM_Campo = "uf";
            this.uf.NM_CampoBusca = "uf";
            this.uf.NM_Param = "@P_DS_PDV";
            this.uf.QTD_Zero = 0;
            this.uf.Size = new System.Drawing.Size(35, 20);
            this.uf.ST_AutoInc = false;
            this.uf.ST_DisableAuto = false;
            this.uf.ST_Float = false;
            this.uf.ST_Gravar = false;
            this.uf.ST_Int = false;
            this.uf.ST_LimpaCampo = true;
            this.uf.ST_NotNull = false;
            this.uf.ST_PrimaryKey = false;
            this.uf.TabIndex = 97;
            this.uf.TextOld = null;
            // 
            // TFInscSubstEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 129);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFInscSubstEmpresa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inscrição Estadual Substituição Tributaria";
            this.Load += new System.EventHandler(this.TFInscSubstEmpresa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFInscSubstEmpresa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSubst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Button bb_uf;
        private Componentes.EditDefault ds_uf;
        private System.Windows.Forms.Label lbl;
        private Componentes.EditDefault cd_uf;
        private Componentes.EditDefault insc_estadual_subst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsSubst;
        private Componentes.EditDefault uf;
    }
}