namespace FormPadrao
{
    partial class FFormPadrao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFormPadrao));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar = new System.Windows.Forms.ToolStripButton();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.bb_saldoInventario = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tcCentral = new System.Windows.Forms.TabControl();
            this.tpPadrao = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.barraMenu.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Alterar,
            this.BB_Gravar,
            this.BB_Excluir,
            this.BB_Buscar,
            this.BB_Cancelar,
            this.BB_Imprimir,
            this.bb_saldoInventario,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Name = "barraMenu";
            this.toolTip1.SetToolTip(this.barraMenu, resources.GetString("barraMenu.ToolTip"));
            // 
            // BB_Novo
            // 
            resources.ApplyResources(this.BB_Novo, "BB_Novo");
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Alterar
            // 
            resources.ApplyResources(this.BB_Alterar, "BB_Alterar");
            this.BB_Alterar.ForeColor = System.Drawing.Color.Green;
            this.BB_Alterar.Name = "BB_Alterar";
            this.BB_Alterar.Click += new System.EventHandler(this.BB_Alterar_Click);
            // 
            // BB_Gravar
            // 
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Excluir
            // 
            resources.ApplyResources(this.BB_Excluir, "BB_Excluir");
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
            // 
            // BB_Buscar
            // 
            resources.ApplyResources(this.BB_Buscar, "BB_Buscar");
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // BB_Cancelar
            // 
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // BB_Imprimir
            // 
            resources.ApplyResources(this.BB_Imprimir, "BB_Imprimir");
            this.BB_Imprimir.ForeColor = System.Drawing.Color.Green;
            this.BB_Imprimir.Name = "BB_Imprimir";
            this.BB_Imprimir.Click += new System.EventHandler(this.BB_Imprimir_Click);
            // 
            // bb_saldoInventario
            // 
            resources.ApplyResources(this.bb_saldoInventario, "bb_saldoInventario");
            this.bb_saldoInventario.ForeColor = System.Drawing.Color.Green;
            this.bb_saldoInventario.Name = "bb_saldoInventario";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // BB_Fechar
            // 
            resources.ApplyResources(this.BB_Fechar, "BB_Fechar");
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tcCentral
            // 
            this.tcCentral.Controls.Add(this.tpPadrao);
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.Multiline = true;
            this.tcCentral.Name = "tcCentral";
            this.tcCentral.SelectedIndex = 0;
            this.tcCentral.SelectedIndexChanged += new System.EventHandler(this.tcCentral_SelectedIndexChanged);
            // 
            // tpPadrao
            // 
            this.tpPadrao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Name = "tpPadrao";
            this.tpPadrao.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            // 
            // FFormPadrao
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "FFormPadrao";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FFormPadrao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FFormPadrao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TabControl tcCentral;
        public System.Windows.Forms.TabPage tpPadrao;
        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Novo;
        public System.Windows.Forms.ToolStripButton BB_Alterar;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Excluir;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        public System.Windows.Forms.ToolStripButton BB_Buscar;
        public System.Windows.Forms.ToolStripButton BB_Imprimir;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ToolStripButton bb_saldoInventario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}