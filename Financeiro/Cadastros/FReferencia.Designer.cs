namespace Financeiro.Cadastros
{
    partial class TFReferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFReferencia));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pReferencia = new Componentes.PanelDados(this.components);
            this.tp_parentesco = new Componentes.ComboBoxDefault(this.components);
            this.bsReferencia = new System.Windows.Forms.BindingSource(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.tipo_referencia = new Componentes.ComboBoxDefault(this.components);
            this.lblParentesco = new System.Windows.Forms.Label();
            this.Fone = new Componentes.EditDefault(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nm_referencia = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pReferencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsReferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(728, 43);
            this.barraMenu.TabIndex = 538;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pReferencia
            // 
            this.pReferencia.Controls.Add(this.tp_parentesco);
            this.pReferencia.Controls.Add(this.label13);
            this.pReferencia.Controls.Add(this.tipo_referencia);
            this.pReferencia.Controls.Add(this.lblParentesco);
            this.pReferencia.Controls.Add(this.Fone);
            this.pReferencia.Controls.Add(this.label15);
            this.pReferencia.Controls.Add(this.label1);
            this.pReferencia.Controls.Add(this.nm_referencia);
            this.pReferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pReferencia.Location = new System.Drawing.Point(0, 43);
            this.pReferencia.Name = "pReferencia";
            this.pReferencia.NM_ProcDeletar = "";
            this.pReferencia.NM_ProcGravar = "";
            this.pReferencia.Size = new System.Drawing.Size(728, 76);
            this.pReferencia.TabIndex = 539;
            // 
            // tp_parentesco
            // 
            this.tp_parentesco.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsReferencia, "Tp_parentesco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_parentesco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_parentesco.FormattingEnabled = true;
            this.tp_parentesco.Location = new System.Drawing.Point(514, 41);
            this.tp_parentesco.Name = "tp_parentesco";
            this.tp_parentesco.NM_Alias = "";
            this.tp_parentesco.NM_Campo = "";
            this.tp_parentesco.NM_Param = "";
            this.tp_parentesco.Size = new System.Drawing.Size(202, 21);
            this.tp_parentesco.ST_Gravar = true;
            this.tp_parentesco.ST_LimparCampo = true;
            this.tp_parentesco.ST_NotNull = true;
            this.tp_parentesco.TabIndex = 3;
            this.tp_parentesco.Visible = false;
            this.tp_parentesco.VisibleChanged += new System.EventHandler(this.tp_parentesco_VisibleChanged);
            // 
            // bsReferencia
            // 
            this.bsReferencia.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadReferenciaCliFor);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(447, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 550;
            this.label13.Text = "Tipo de Contato:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tipo_referencia
            // 
            this.tipo_referencia.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsReferencia, "Tp_Referencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tipo_referencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipo_referencia.FormattingEnabled = true;
            this.tipo_referencia.Location = new System.Drawing.Point(539, 14);
            this.tipo_referencia.Name = "tipo_referencia";
            this.tipo_referencia.NM_Alias = "";
            this.tipo_referencia.NM_Campo = "";
            this.tipo_referencia.NM_Param = "";
            this.tipo_referencia.Size = new System.Drawing.Size(177, 21);
            this.tipo_referencia.ST_Gravar = true;
            this.tipo_referencia.ST_LimparCampo = true;
            this.tipo_referencia.ST_NotNull = true;
            this.tipo_referencia.TabIndex = 1;
            this.tipo_referencia.SelectedIndexChanged += new System.EventHandler(this.tipo_referencia_SelectedIndexChanged);
            // 
            // lblParentesco
            // 
            this.lblParentesco.AutoSize = true;
            this.lblParentesco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblParentesco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblParentesco.Location = new System.Drawing.Point(444, 45);
            this.lblParentesco.Name = "lblParentesco";
            this.lblParentesco.Size = new System.Drawing.Size(64, 13);
            this.lblParentesco.TabIndex = 543;
            this.lblParentesco.Text = "Parentesco:";
            this.lblParentesco.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblParentesco.Visible = false;
            // 
            // Fone
            // 
            this.Fone.BackColor = System.Drawing.SystemColors.Window;
            this.Fone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Fone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReferencia, "Fone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Fone.Location = new System.Drawing.Point(74, 41);
            this.Fone.Name = "Fone";
            this.Fone.NM_Alias = "";
            this.Fone.NM_Campo = "";
            this.Fone.NM_CampoBusca = "";
            this.Fone.NM_Param = "";
            this.Fone.QTD_Zero = 0;
            this.Fone.Size = new System.Drawing.Size(164, 20);
            this.Fone.ST_AutoInc = false;
            this.Fone.ST_DisableAuto = false;
            this.Fone.ST_Float = false;
            this.Fone.ST_Gravar = false;
            this.Fone.ST_Int = false;
            this.Fone.ST_LimpaCampo = true;
            this.Fone.ST_NotNull = false;
            this.Fone.ST_PrimaryKey = false;
            this.Fone.TabIndex = 2;
            this.Fone.TextOld = null;
            this.Fone.TextChanged += new System.EventHandler(this.Fone_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(34, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 537;
            this.label15.Text = "Fone:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Referência";
            // 
            // nm_referencia
            // 
            this.nm_referencia.BackColor = System.Drawing.SystemColors.Window;
            this.nm_referencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_referencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_referencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReferencia, "Nm_referencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_referencia.Location = new System.Drawing.Point(74, 15);
            this.nm_referencia.Name = "nm_referencia";
            this.nm_referencia.NM_Alias = "";
            this.nm_referencia.NM_Campo = "";
            this.nm_referencia.NM_CampoBusca = "";
            this.nm_referencia.NM_Param = "";
            this.nm_referencia.QTD_Zero = 0;
            this.nm_referencia.Size = new System.Drawing.Size(367, 20);
            this.nm_referencia.ST_AutoInc = false;
            this.nm_referencia.ST_DisableAuto = false;
            this.nm_referencia.ST_Float = false;
            this.nm_referencia.ST_Gravar = false;
            this.nm_referencia.ST_Int = false;
            this.nm_referencia.ST_LimpaCampo = true;
            this.nm_referencia.ST_NotNull = false;
            this.nm_referencia.ST_PrimaryKey = false;
            this.nm_referencia.TabIndex = 0;
            this.nm_referencia.TextOld = null;
            // 
            // TFReferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 119);
            this.Controls.Add(this.pReferencia);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFReferencia";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Referência Comercial/Pessoal";
            this.Load += new System.EventHandler(this.TFReferencia_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFReferencia_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pReferencia.ResumeLayout(false);
            this.pReferencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsReferencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pReferencia;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault nm_referencia;
        private Componentes.EditDefault Fone;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblParentesco;
        private System.Windows.Forms.Label label13;
        private Componentes.ComboBoxDefault tipo_referencia;
        private System.Windows.Forms.BindingSource bsReferencia;
        private Componentes.ComboBoxDefault tp_parentesco;
    }
}