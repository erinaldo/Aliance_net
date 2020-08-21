namespace PostoCombustivel
{
    partial class TFCancelarNFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCancelarNFe));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.cbSerie = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nr_notafiscal = new Componentes.EditDefault(this.components);
            this.lblNumero = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(432, 39);
            this.barraMenu.TabIndex = 13;
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(118, 36);
            this.bb_cancelar.Text = "(F4)\r\nCancelar NFe";
            this.bb_cancelar.ToolTipText = "Cancelar NFe";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.cbSerie);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.nr_notafiscal);
            this.pDados.Controls.Add(this.lblNumero);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 39);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(432, 125);
            this.pDados.TabIndex = 14;
            // 
            // cbSerie
            // 
            this.cbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerie.FormattingEnabled = true;
            this.cbSerie.Location = new System.Drawing.Point(6, 58);
            this.cbSerie.Name = "cbSerie";
            this.cbSerie.NM_Alias = "";
            this.cbSerie.NM_Campo = "";
            this.cbSerie.NM_Param = "";
            this.cbSerie.Size = new System.Drawing.Size(419, 21);
            this.cbSerie.ST_Gravar = false;
            this.cbSerie.ST_LimparCampo = true;
            this.cbSerie.ST_NotNull = false;
            this.cbSerie.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Serie NF";
            // 
            // nr_notafiscal
            // 
            this.nr_notafiscal.BackColor = System.Drawing.SystemColors.Window;
            this.nr_notafiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_notafiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_notafiscal.Location = new System.Drawing.Point(6, 97);
            this.nr_notafiscal.Name = "nr_notafiscal";
            this.nr_notafiscal.NM_Alias = "";
            this.nr_notafiscal.NM_Campo = "";
            this.nr_notafiscal.NM_CampoBusca = "";
            this.nr_notafiscal.NM_Param = "";
            this.nr_notafiscal.QTD_Zero = 0;
            this.nr_notafiscal.Size = new System.Drawing.Size(126, 20);
            this.nr_notafiscal.ST_AutoInc = false;
            this.nr_notafiscal.ST_DisableAuto = false;
            this.nr_notafiscal.ST_Float = false;
            this.nr_notafiscal.ST_Gravar = false;
            this.nr_notafiscal.ST_Int = false;
            this.nr_notafiscal.ST_LimpaCampo = true;
            this.nr_notafiscal.ST_NotNull = false;
            this.nr_notafiscal.ST_PrimaryKey = false;
            this.nr_notafiscal.TabIndex = 0;
            this.nr_notafiscal.TextOld = null;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(3, 81);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(60, 13);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.Text = "Nota Fiscal";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(76, 19);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "";
            this.nm_empresa.NM_CampoBusca = "";
            this.nm_empresa.NM_Param = "";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(349, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 4;
            this.nm_empresa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Empresa";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(6, 19);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "";
            this.cd_empresa.NM_CampoBusca = "";
            this.cd_empresa.NM_Param = "";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(67, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 3;
            this.cd_empresa.TextOld = null;
            // 
            // TFCancelarNFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 164);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCancelarNFe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar NFe";
            this.Load += new System.EventHandler(this.TFCancelarNFe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCancelarNFe_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nr_notafiscal;
        private System.Windows.Forms.Label lblNumero;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault cbSerie;
    }
}