namespace Compra
{
    partial class TFValorNegociacao
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
            System.Windows.Forms.Label label11;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFValorNegociacao));
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.sigla = new Componentes.EditDefault(this.components);
            this.vl_unitario_negociado = new Componentes.EditFloat(this.components);
            this.qtd_porcompra = new Componentes.EditFloat(this.components);
            this.qtd_min_compra = new Componentes.EditFloat(this.components);
            label11 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario_negociado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_porcompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_min_compra)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            label11.AccessibleDescription = null;
            label11.AccessibleName = null;
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // label8
            // 
            label8.AccessibleDescription = null;
            label8.AccessibleName = null;
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // label7
            // 
            label7.AccessibleDescription = null;
            label7.AccessibleName = null;
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Font = null;
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AccessibleDescription = null;
            this.BB_Gravar.AccessibleName = null;
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.BackgroundImage = null;
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AccessibleDescription = null;
            this.BB_Cancelar.AccessibleName = null;
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.BackgroundImage = null;
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.sigla);
            this.pDados.Controls.Add(label11);
            this.pDados.Controls.Add(this.vl_unitario_negociado);
            this.pDados.Controls.Add(label8);
            this.pDados.Controls.Add(this.qtd_porcompra);
            this.pDados.Controls.Add(label7);
            this.pDados.Controls.Add(this.qtd_min_compra);
            this.pDados.Font = null;
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // sigla
            // 
            this.sigla.AccessibleDescription = null;
            this.sigla.AccessibleName = null;
            resources.ApplyResources(this.sigla, "sigla");
            this.sigla.BackColor = System.Drawing.SystemColors.Window;
            this.sigla.BackgroundImage = null;
            this.sigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla.Font = null;
            this.sigla.Name = "sigla";
            this.sigla.NM_Alias = "";
            this.sigla.NM_Campo = "sigla";
            this.sigla.NM_CampoBusca = "sigla";
            this.sigla.NM_Param = "@P_DS_PRODUTO";
            this.sigla.QTD_Zero = 0;
            this.sigla.ST_AutoInc = false;
            this.sigla.ST_DisableAuto = false;
            this.sigla.ST_Float = false;
            this.sigla.ST_Gravar = false;
            this.sigla.ST_Int = false;
            this.sigla.ST_LimpaCampo = true;
            this.sigla.ST_NotNull = false;
            this.sigla.ST_PrimaryKey = false;
            // 
            // vl_unitario_negociado
            // 
            this.vl_unitario_negociado.AccessibleDescription = null;
            this.vl_unitario_negociado.AccessibleName = null;
            resources.ApplyResources(this.vl_unitario_negociado, "vl_unitario_negociado");
            this.vl_unitario_negociado.DecimalPlaces = 2;
            this.vl_unitario_negociado.Font = null;
            this.vl_unitario_negociado.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_unitario_negociado.Name = "vl_unitario_negociado";
            this.vl_unitario_negociado.NM_Alias = "";
            this.vl_unitario_negociado.NM_Campo = "";
            this.vl_unitario_negociado.NM_Param = "";
            this.vl_unitario_negociado.Operador = "";
            this.vl_unitario_negociado.ST_AutoInc = false;
            this.vl_unitario_negociado.ST_DisableAuto = false;
            this.vl_unitario_negociado.ST_Gravar = true;
            this.vl_unitario_negociado.ST_LimparCampo = true;
            this.vl_unitario_negociado.ST_NotNull = true;
            this.vl_unitario_negociado.ST_PrimaryKey = false;
            // 
            // qtd_porcompra
            // 
            this.qtd_porcompra.AccessibleDescription = null;
            this.qtd_porcompra.AccessibleName = null;
            resources.ApplyResources(this.qtd_porcompra, "qtd_porcompra");
            this.qtd_porcompra.Font = null;
            this.qtd_porcompra.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_porcompra.Name = "qtd_porcompra";
            this.qtd_porcompra.NM_Alias = "";
            this.qtd_porcompra.NM_Campo = "";
            this.qtd_porcompra.NM_Param = "";
            this.qtd_porcompra.Operador = "";
            this.qtd_porcompra.ST_AutoInc = false;
            this.qtd_porcompra.ST_DisableAuto = false;
            this.qtd_porcompra.ST_Gravar = true;
            this.qtd_porcompra.ST_LimparCampo = true;
            this.qtd_porcompra.ST_NotNull = false;
            this.qtd_porcompra.ST_PrimaryKey = false;
            // 
            // qtd_min_compra
            // 
            this.qtd_min_compra.AccessibleDescription = null;
            this.qtd_min_compra.AccessibleName = null;
            resources.ApplyResources(this.qtd_min_compra, "qtd_min_compra");
            this.qtd_min_compra.Font = null;
            this.qtd_min_compra.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_min_compra.Name = "qtd_min_compra";
            this.qtd_min_compra.NM_Alias = "";
            this.qtd_min_compra.NM_Campo = "";
            this.qtd_min_compra.NM_Param = "";
            this.qtd_min_compra.Operador = "";
            this.qtd_min_compra.ST_AutoInc = false;
            this.qtd_min_compra.ST_DisableAuto = false;
            this.qtd_min_compra.ST_Gravar = true;
            this.qtd_min_compra.ST_LimparCampo = true;
            this.qtd_min_compra.ST_NotNull = false;
            this.qtd_min_compra.ST_PrimaryKey = false;
            // 
            // TFValorNegociacao
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFValorNegociacao";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFValorNegociacao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFValorNegociacao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario_negociado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_porcompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_min_compra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditFloat vl_unitario_negociado;
        private Componentes.EditFloat qtd_porcompra;
        private Componentes.EditFloat qtd_min_compra;
        private Componentes.EditDefault sigla;
    }
}