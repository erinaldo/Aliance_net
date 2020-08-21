namespace FormRelPadrao
{
    partial class FRelPadrao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRelPadrao));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.BB_DataCube = new System.Windows.Forms.ToolStripButton();
            this.BB_Chart = new System.Windows.Forms.ToolStripButton();
            this.BB_Atualizar = new System.Windows.Forms.ToolStripButton();
            this.BB_Publicar = new System.Windows.Forms.ToolStripButton();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.reportManager1 = new PerpetuumSoft.Reporting.Components.ReportManager(this.components);
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Imprimir,
            this.BB_DataCube,
            this.BB_Chart,
            this.BB_Atualizar,
            this.BB_Publicar,
            this.BB_Fechar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Novo
            // 
            resources.ApplyResources(this.BB_Novo, "BB_Novo");
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Imprimir
            // 
            resources.ApplyResources(this.BB_Imprimir, "BB_Imprimir");
            this.BB_Imprimir.ForeColor = System.Drawing.Color.Green;
            this.BB_Imprimir.Name = "BB_Imprimir";
            // 
            // BB_DataCube
            // 
            resources.ApplyResources(this.BB_DataCube, "BB_DataCube");
            this.BB_DataCube.ForeColor = System.Drawing.Color.Green;
            this.BB_DataCube.Name = "BB_DataCube";
            // 
            // BB_Chart
            // 
            resources.ApplyResources(this.BB_Chart, "BB_Chart");
            this.BB_Chart.ForeColor = System.Drawing.Color.Green;
            this.BB_Chart.Name = "BB_Chart";
            // 
            // BB_Atualizar
            // 
            resources.ApplyResources(this.BB_Atualizar, "BB_Atualizar");
            this.BB_Atualizar.ForeColor = System.Drawing.Color.Green;
            this.BB_Atualizar.Name = "BB_Atualizar";
            // 
            // BB_Publicar
            // 
            resources.ApplyResources(this.BB_Publicar, "BB_Publicar");
            this.BB_Publicar.ForeColor = System.Drawing.Color.Green;
            this.BB_Publicar.Name = "BB_Publicar";
            // 
            // BB_Fechar
            // 
            resources.ApplyResources(this.BB_Fechar, "BB_Fechar");
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // pFiltro
            // 
            resources.ApplyResources(this.pFiltro, "pFiltro");
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            // 
            // reportManager1
            // 
            this.reportManager1.DataSources = new PerpetuumSoft.Reporting.Components.ObjectPointerCollection(new string[0], new object[0]);
            this.reportManager1.OwnerForm = this;
            // 
            // FRelPadrao
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pFiltro);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "FRelPadrao";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRelPadrao_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Novo;
        public System.Windows.Forms.ToolStripButton BB_Imprimir;
        public Componentes.PanelDados pFiltro;
        public System.Windows.Forms.ToolStripButton BB_DataCube;
        public System.Windows.Forms.ToolStripButton BB_Chart;
        public System.Windows.Forms.ToolStripButton BB_Atualizar;
        public System.Windows.Forms.ToolStripButton BB_Publicar;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private PerpetuumSoft.Reporting.Components.ReportManager reportManager1;
    }
}