namespace Financeiro
{
    partial class TFLanContaDescCheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanContaDescCheque));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.DT_Pgto = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.bb_contager = new System.Windows.Forms.Button();
            this.ds_contager_destino = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cd_contager_destino = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
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
            this.pDados.Controls.Add(this.DT_Pgto);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.bb_contager);
            this.pDados.Controls.Add(this.ds_contager_destino);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.cd_contager_destino);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Font = null;
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // DT_Pgto
            // 
            this.DT_Pgto.AccessibleDescription = null;
            this.DT_Pgto.AccessibleName = null;
            resources.ApplyResources(this.DT_Pgto, "DT_Pgto");
            this.DT_Pgto.BackgroundImage = null;
            this.DT_Pgto.Font = null;
            this.DT_Pgto.Name = "DT_Pgto";
            this.DT_Pgto.NM_Alias = "";
            this.DT_Pgto.NM_Campo = "";
            this.DT_Pgto.NM_CampoBusca = "";
            this.DT_Pgto.NM_Param = "";
            this.DT_Pgto.Operador = "";
            this.DT_Pgto.ST_Gravar = true;
            this.DT_Pgto.ST_LimpaCampo = true;
            this.DT_Pgto.ST_NotNull = true;
            this.DT_Pgto.ST_PrimaryKey = false;
            // 
            // label8
            // 
            this.label8.AccessibleDescription = null;
            this.label8.AccessibleName = null;
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // bb_contager
            // 
            this.bb_contager.AccessibleDescription = null;
            this.bb_contager.AccessibleName = null;
            resources.ApplyResources(this.bb_contager, "bb_contager");
            this.bb_contager.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contager.BackgroundImage = null;
            this.bb_contager.Font = null;
            this.bb_contager.Name = "bb_contager";
            this.bb_contager.UseVisualStyleBackColor = false;
            this.bb_contager.Click += new System.EventHandler(this.bb_contager_Click);
            // 
            // ds_contager_destino
            // 
            this.ds_contager_destino.AccessibleDescription = null;
            this.ds_contager_destino.AccessibleName = null;
            resources.ApplyResources(this.ds_contager_destino, "ds_contager_destino");
            this.ds_contager_destino.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contager_destino.BackgroundImage = null;
            this.ds_contager_destino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contager_destino.Font = null;
            this.ds_contager_destino.Name = "ds_contager_destino";
            this.ds_contager_destino.NM_Alias = "";
            this.ds_contager_destino.NM_Campo = "ds_contager";
            this.ds_contager_destino.NM_CampoBusca = "ds_contager";
            this.ds_contager_destino.NM_Param = "@P_DS_BANCO";
            this.ds_contager_destino.QTD_Zero = 0;
            this.ds_contager_destino.ST_AutoInc = false;
            this.ds_contager_destino.ST_DisableAuto = false;
            this.ds_contager_destino.ST_Float = false;
            this.ds_contager_destino.ST_Gravar = true;
            this.ds_contager_destino.ST_Int = false;
            this.ds_contager_destino.ST_LimpaCampo = true;
            this.ds_contager_destino.ST_NotNull = true;
            this.ds_contager_destino.ST_PrimaryKey = false;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cd_contager_destino
            // 
            this.cd_contager_destino.AccessibleDescription = null;
            this.cd_contager_destino.AccessibleName = null;
            resources.ApplyResources(this.cd_contager_destino, "cd_contager_destino");
            this.cd_contager_destino.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contager_destino.BackgroundImage = null;
            this.cd_contager_destino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contager_destino.Font = null;
            this.cd_contager_destino.Name = "cd_contager_destino";
            this.cd_contager_destino.NM_Alias = "";
            this.cd_contager_destino.NM_Campo = "cd_contager";
            this.cd_contager_destino.NM_CampoBusca = "cd_contager";
            this.cd_contager_destino.NM_Param = "@P_CD_BANCO";
            this.cd_contager_destino.QTD_Zero = 0;
            this.cd_contager_destino.ST_AutoInc = false;
            this.cd_contager_destino.ST_DisableAuto = true;
            this.cd_contager_destino.ST_Float = false;
            this.cd_contager_destino.ST_Gravar = true;
            this.cd_contager_destino.ST_Int = false;
            this.cd_contager_destino.ST_LimpaCampo = true;
            this.cd_contager_destino.ST_NotNull = true;
            this.cd_contager_destino.ST_PrimaryKey = false;
            this.cd_contager_destino.Leave += new System.EventHandler(this.cd_contager_destino_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.AccessibleDescription = null;
            this.nm_empresa.AccessibleName = null;
            resources.ApplyResources(this.nm_empresa, "nm_empresa");
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BackgroundImage = null;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Font = null;
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "ds_banco";
            this.nm_empresa.NM_CampoBusca = "ds_banco";
            this.nm_empresa.NM_Param = "@P_DS_BANCO";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = true;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = true;
            this.nm_empresa.ST_PrimaryKey = false;
            // 
            // label10
            // 
            this.label10.AccessibleDescription = null;
            this.label10.AccessibleName = null;
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // cd_empresa
            // 
            this.cd_empresa.AccessibleDescription = null;
            this.cd_empresa.AccessibleName = null;
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BackgroundImage = null;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = null;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_banco";
            this.cd_empresa.NM_CampoBusca = "cd_banco";
            this.cd_empresa.NM_Param = "@P_CD_BANCO";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = true;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            // 
            // TFLanContaDescCheque
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
            this.Name = "TFLanContaDescCheque";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFLanContaDescCheque_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanContaDescCheque_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_contager;
        private Componentes.EditDefault ds_contager_destino;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault cd_contager_destino;
        public Componentes.EditData DT_Pgto;
        private System.Windows.Forms.Label label8;
    }
}