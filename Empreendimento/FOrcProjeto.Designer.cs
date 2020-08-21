namespace Empreendimento
{
    partial class TFOrcProjeto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFOrcProjeto));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.obs = new Componentes.EditDefault(this.components);
            this.bsOrcProjeto = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_projeto = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrcProjeto)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(455, 43);
            this.barraMenu.TabIndex = 19;
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
            this.pDados.Controls.Add(this.obs);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_projeto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(455, 178);
            this.pDados.TabIndex = 0;
            // 
            // obs
            // 
            this.obs.BackColor = System.Drawing.SystemColors.Window;
            this.obs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.obs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.obs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrcProjeto, "Obs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.obs.Location = new System.Drawing.Point(12, 60);
            this.obs.Multiline = true;
            this.obs.Name = "obs";
            this.obs.NM_Alias = "";
            this.obs.NM_Campo = "";
            this.obs.NM_CampoBusca = "";
            this.obs.NM_Param = "";
            this.obs.QTD_Zero = 0;
            this.obs.Size = new System.Drawing.Size(431, 106);
            this.obs.ST_AutoInc = false;
            this.obs.ST_DisableAuto = false;
            this.obs.ST_Float = false;
            this.obs.ST_Gravar = false;
            this.obs.ST_Int = false;
            this.obs.ST_LimpaCampo = true;
            this.obs.ST_NotNull = false;
            this.obs.ST_PrimaryKey = false;
            this.obs.TabIndex = 1;
            this.obs.TextOld = null;
            // 
            // bsOrcProjeto
            // 
            this.bsOrcProjeto.DataSource = typeof(CamadaDados.Empreendimento.TList_OrcProjeto);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Obs.";
            // 
            // ds_projeto
            // 
            this.ds_projeto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_projeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_projeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_projeto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrcProjeto, "Ds_projeto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_projeto.Enabled = false;
            this.ds_projeto.Location = new System.Drawing.Point(12, 21);
            this.ds_projeto.MaxLength = 50;
            this.ds_projeto.Name = "ds_projeto";
            this.ds_projeto.NM_Alias = "";
            this.ds_projeto.NM_Campo = "";
            this.ds_projeto.NM_CampoBusca = "";
            this.ds_projeto.NM_Param = "";
            this.ds_projeto.QTD_Zero = 0;
            this.ds_projeto.Size = new System.Drawing.Size(431, 20);
            this.ds_projeto.ST_AutoInc = false;
            this.ds_projeto.ST_DisableAuto = false;
            this.ds_projeto.ST_Float = false;
            this.ds_projeto.ST_Gravar = true;
            this.ds_projeto.ST_Int = false;
            this.ds_projeto.ST_LimpaCampo = true;
            this.ds_projeto.ST_NotNull = true;
            this.ds_projeto.ST_PrimaryKey = false;
            this.ds_projeto.TabIndex = 0;
            this.ds_projeto.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Atividade";
            // 
            // TFOrcProjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 221);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFOrcProjeto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TFOrcProjeto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFOrcProjeto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrcProjeto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault obs;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_projeto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsOrcProjeto;
    }
}