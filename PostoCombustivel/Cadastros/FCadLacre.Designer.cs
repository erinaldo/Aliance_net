namespace PostoCombustivel.Cadastros
{
    partial class TFCadLacre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadLacre));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pLacre = new Componentes.PanelDados(this.components);
            this.dt_lacre = new Componentes.EditData(this.components);
            this.bsLacre = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nr_lacre = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pLacre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLacre)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(412, 43);
            this.barraMenu.TabIndex = 14;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            // pLacre
            // 
            this.pLacre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLacre.Controls.Add(this.dt_lacre);
            this.pLacre.Controls.Add(this.label2);
            this.pLacre.Controls.Add(this.label1);
            this.pLacre.Controls.Add(this.nr_lacre);
            this.pLacre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLacre.Location = new System.Drawing.Point(0, 43);
            this.pLacre.Name = "pLacre";
            this.pLacre.NM_ProcDeletar = "";
            this.pLacre.NM_ProcGravar = "";
            this.pLacre.Size = new System.Drawing.Size(412, 55);
            this.pLacre.TabIndex = 15;
            // 
            // dt_lacre
            // 
            this.dt_lacre.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLacre, "Dt_aplicacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_lacre.Location = new System.Drawing.Point(83, 29);
            this.dt_lacre.Mask = "00/00/0000";
            this.dt_lacre.Name = "dt_lacre";
            this.dt_lacre.NM_Alias = "";
            this.dt_lacre.NM_Campo = "";
            this.dt_lacre.NM_CampoBusca = "";
            this.dt_lacre.NM_Param = "";
            this.dt_lacre.Operador = "";
            this.dt_lacre.Size = new System.Drawing.Size(71, 20);
            this.dt_lacre.ST_Gravar = true;
            this.dt_lacre.ST_LimpaCampo = true;
            this.dt_lacre.ST_NotNull = true;
            this.dt_lacre.ST_PrimaryKey = false;
            this.dt_lacre.TabIndex = 3;
            // 
            // bsLacre
            // 
            this.bsLacre.DataSource = typeof(CamadaDados.PostoCombustivel.Cadastros.TList_LacreBomba);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dt. Aplicação:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nº Lacre:";
            // 
            // nr_lacre
            // 
            this.nr_lacre.BackColor = System.Drawing.SystemColors.Window;
            this.nr_lacre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_lacre.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLacre, "Nr_lacre", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_lacre.Location = new System.Drawing.Point(83, 3);
            this.nr_lacre.Name = "nr_lacre";
            this.nr_lacre.NM_Alias = "";
            this.nr_lacre.NM_Campo = "";
            this.nr_lacre.NM_CampoBusca = "";
            this.nr_lacre.NM_Param = "";
            this.nr_lacre.QTD_Zero = 0;
            this.nr_lacre.Size = new System.Drawing.Size(324, 20);
            this.nr_lacre.ST_AutoInc = false;
            this.nr_lacre.ST_DisableAuto = false;
            this.nr_lacre.ST_Float = false;
            this.nr_lacre.ST_Gravar = true;
            this.nr_lacre.ST_Int = false;
            this.nr_lacre.ST_LimpaCampo = true;
            this.nr_lacre.ST_NotNull = true;
            this.nr_lacre.ST_PrimaryKey = false;
            this.nr_lacre.TabIndex = 0;
            // 
            // TFCadLacre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 98);
            this.Controls.Add(this.pLacre);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCadLacre";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Lacre Bomba";
            this.Load += new System.EventHandler(this.TFCadLacre_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCadLacre_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pLacre.ResumeLayout(false);
            this.pLacre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLacre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pLacre;
        private Componentes.EditData dt_lacre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault nr_lacre;
        private System.Windows.Forms.BindingSource bsLacre;
    }
}