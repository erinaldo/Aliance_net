namespace Servicos
{
    partial class TFLanItemNfTerceiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanItemNfTerceiro));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.qtd_os = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_os)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
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
            this.pDados.Controls.Add(this.vl_subtotal);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.qtd_os);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.vl_unitario);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.label22);
            this.pDados.Font = null;
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.AccessibleDescription = null;
            this.vl_subtotal.AccessibleName = null;
            resources.ApplyResources(this.vl_subtotal, "vl_subtotal");
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Font = null;
            this.vl_subtotal.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_subtotal.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_subtotal.Name = "vl_subtotal";
            this.vl_subtotal.NM_Alias = "";
            this.vl_subtotal.NM_Campo = "";
            this.vl_subtotal.NM_Param = "";
            this.vl_subtotal.Operador = "";
            this.vl_subtotal.ReadOnly = true;
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = false;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = false;
            this.vl_subtotal.ST_PrimaryKey = false;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // qtd_os
            // 
            this.qtd_os.AccessibleDescription = null;
            this.qtd_os.AccessibleName = null;
            resources.ApplyResources(this.qtd_os, "qtd_os");
            this.qtd_os.Font = null;
            this.qtd_os.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qtd_os.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_os.Name = "qtd_os";
            this.qtd_os.NM_Alias = "";
            this.qtd_os.NM_Campo = "";
            this.qtd_os.NM_Param = "";
            this.qtd_os.Operador = "";
            this.qtd_os.ReadOnly = true;
            this.qtd_os.ST_AutoInc = false;
            this.qtd_os.ST_DisableAuto = false;
            this.qtd_os.ST_Gravar = false;
            this.qtd_os.ST_LimparCampo = true;
            this.qtd_os.ST_NotNull = false;
            this.qtd_os.ST_PrimaryKey = false;
            this.qtd_os.TabStop = false;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // vl_unitario
            // 
            this.vl_unitario.AccessibleDescription = null;
            this.vl_unitario.AccessibleName = null;
            resources.ApplyResources(this.vl_unitario, "vl_unitario");
            this.vl_unitario.DecimalPlaces = 2;
            this.vl_unitario.Font = null;
            this.vl_unitario.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_unitario.Name = "vl_unitario";
            this.vl_unitario.NM_Alias = "";
            this.vl_unitario.NM_Campo = "";
            this.vl_unitario.NM_Param = "";
            this.vl_unitario.Operador = "";
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = false;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = false;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.ValueChanged += new System.EventHandler(this.vl_unitario_ValueChanged);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ds_produto
            // 
            this.ds_produto.AccessibleDescription = null;
            this.ds_produto.AccessibleName = null;
            resources.ApplyResources(this.ds_produto, "ds_produto");
            this.ds_produto.BackColor = System.Drawing.Color.White;
            this.ds_produto.BackgroundImage = null;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "";
            this.ds_produto.NM_CampoBusca = "";
            this.ds_produto.NM_Param = "";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = true;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            // 
            // cd_produto
            // 
            this.cd_produto.AccessibleDescription = null;
            this.cd_produto.AccessibleName = null;
            resources.ApplyResources(this.cd_produto, "cd_produto");
            this.cd_produto.BackColor = System.Drawing.Color.White;
            this.cd_produto.BackgroundImage = null;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "";
            this.cd_produto.NM_CampoBusca = "";
            this.cd_produto.NM_Param = "";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = false;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            // 
            // label22
            // 
            this.label22.AccessibleDescription = null;
            this.label22.AccessibleName = null;
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // TFLanItemNfTerceiro
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
            this.Name = "TFLanItemNfTerceiro";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanItemNfTerceiro_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanItemNfTerceiro_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_os)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Label label22;
        private Componentes.EditFloat vl_unitario;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat vl_subtotal;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat qtd_os;
        private System.Windows.Forms.Label label2;
    }
}