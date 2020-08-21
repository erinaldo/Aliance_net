namespace Commoditties
{
    partial class TFImportIndice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFImportIndice));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_amostra = new Componentes.EditDefault(this.components);
            this.bb_Amostra = new System.Windows.Forms.Button();
            this.ds_tabelaDesconto = new Componentes.EditDefault(this.components);
            this.bb_TabelaDesconto = new System.Windows.Forms.Button();
            this.LB_CD_TabelaDesconto = new System.Windows.Forms.Label();
            this.LB_CD_TipoAmostra = new System.Windows.Forms.Label();
            this.CD_TabelaDesconto = new Componentes.EditDefault(this.components);
            this.CD_TipoAmostra = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(427, 43);
            this.barraMenu.TabIndex = 5;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.ds_amostra);
            this.pDados.Controls.Add(this.bb_Amostra);
            this.pDados.Controls.Add(this.ds_tabelaDesconto);
            this.pDados.Controls.Add(this.bb_TabelaDesconto);
            this.pDados.Controls.Add(this.LB_CD_TabelaDesconto);
            this.pDados.Controls.Add(this.LB_CD_TipoAmostra);
            this.pDados.Controls.Add(this.CD_TabelaDesconto);
            this.pDados.Controls.Add(this.CD_TipoAmostra);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(427, 62);
            this.pDados.TabIndex = 6;
            // 
            // ds_amostra
            // 
            this.ds_amostra.BackColor = System.Drawing.SystemColors.Window;
            this.ds_amostra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_amostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_amostra.Enabled = false;
            this.ds_amostra.Location = new System.Drawing.Point(185, 34);
            this.ds_amostra.Name = "ds_amostra";
            this.ds_amostra.NM_Alias = "";
            this.ds_amostra.NM_Campo = "ds_amostra";
            this.ds_amostra.NM_CampoBusca = "ds_amostra";
            this.ds_amostra.NM_Param = "@P_DS_AMOSTRA";
            this.ds_amostra.QTD_Zero = 0;
            this.ds_amostra.ReadOnly = true;
            this.ds_amostra.Size = new System.Drawing.Size(229, 20);
            this.ds_amostra.ST_AutoInc = false;
            this.ds_amostra.ST_DisableAuto = false;
            this.ds_amostra.ST_Float = false;
            this.ds_amostra.ST_Gravar = false;
            this.ds_amostra.ST_Int = false;
            this.ds_amostra.ST_LimpaCampo = true;
            this.ds_amostra.ST_NotNull = false;
            this.ds_amostra.ST_PrimaryKey = false;
            this.ds_amostra.TabIndex = 80;
            // 
            // bb_Amostra
            // 
            this.bb_Amostra.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_Amostra.Image = ((System.Drawing.Image)(resources.GetObject("bb_Amostra.Image")));
            this.bb_Amostra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_Amostra.Location = new System.Drawing.Point(152, 34);
            this.bb_Amostra.Name = "bb_Amostra";
            this.bb_Amostra.Size = new System.Drawing.Size(30, 20);
            this.bb_Amostra.TabIndex = 78;
            this.bb_Amostra.UseVisualStyleBackColor = true;
            this.bb_Amostra.Click += new System.EventHandler(this.bb_Amostra_Click);
            // 
            // ds_tabelaDesconto
            // 
            this.ds_tabelaDesconto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelaDesconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tabelaDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelaDesconto.Enabled = false;
            this.ds_tabelaDesconto.Location = new System.Drawing.Point(185, 6);
            this.ds_tabelaDesconto.Name = "ds_tabelaDesconto";
            this.ds_tabelaDesconto.NM_Alias = "";
            this.ds_tabelaDesconto.NM_Campo = "ds_tabelaDesconto";
            this.ds_tabelaDesconto.NM_CampoBusca = "ds_tabelaDesconto";
            this.ds_tabelaDesconto.NM_Param = "";
            this.ds_tabelaDesconto.QTD_Zero = 0;
            this.ds_tabelaDesconto.ReadOnly = true;
            this.ds_tabelaDesconto.Size = new System.Drawing.Size(229, 20);
            this.ds_tabelaDesconto.ST_AutoInc = false;
            this.ds_tabelaDesconto.ST_DisableAuto = false;
            this.ds_tabelaDesconto.ST_Float = false;
            this.ds_tabelaDesconto.ST_Gravar = false;
            this.ds_tabelaDesconto.ST_Int = false;
            this.ds_tabelaDesconto.ST_LimpaCampo = true;
            this.ds_tabelaDesconto.ST_NotNull = false;
            this.ds_tabelaDesconto.ST_PrimaryKey = false;
            this.ds_tabelaDesconto.TabIndex = 79;
            // 
            // bb_TabelaDesconto
            // 
            this.bb_TabelaDesconto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_TabelaDesconto.Image = ((System.Drawing.Image)(resources.GetObject("bb_TabelaDesconto.Image")));
            this.bb_TabelaDesconto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_TabelaDesconto.Location = new System.Drawing.Point(152, 6);
            this.bb_TabelaDesconto.Name = "bb_TabelaDesconto";
            this.bb_TabelaDesconto.Size = new System.Drawing.Size(30, 20);
            this.bb_TabelaDesconto.TabIndex = 74;
            this.bb_TabelaDesconto.UseVisualStyleBackColor = true;
            this.bb_TabelaDesconto.Click += new System.EventHandler(this.bb_TabelaDesconto_Click);
            // 
            // LB_CD_TabelaDesconto
            // 
            this.LB_CD_TabelaDesconto.AutoSize = true;
            this.LB_CD_TabelaDesconto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_TabelaDesconto.Location = new System.Drawing.Point(11, 10);
            this.LB_CD_TabelaDesconto.Name = "LB_CD_TabelaDesconto";
            this.LB_CD_TabelaDesconto.Size = new System.Drawing.Size(78, 13);
            this.LB_CD_TabelaDesconto.TabIndex = 75;
            this.LB_CD_TabelaDesconto.Text = "Tab.Desconto:";
            // 
            // LB_CD_TipoAmostra
            // 
            this.LB_CD_TipoAmostra.AutoSize = true;
            this.LB_CD_TipoAmostra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_TipoAmostra.Location = new System.Drawing.Point(17, 38);
            this.LB_CD_TipoAmostra.Name = "LB_CD_TipoAmostra";
            this.LB_CD_TipoAmostra.Size = new System.Drawing.Size(72, 13);
            this.LB_CD_TipoAmostra.TabIndex = 76;
            this.LB_CD_TipoAmostra.Text = "Tipo Amostra:";
            // 
            // CD_TabelaDesconto
            // 
            this.CD_TabelaDesconto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_TabelaDesconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_TabelaDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_TabelaDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_TabelaDesconto.Location = new System.Drawing.Point(95, 6);
            this.CD_TabelaDesconto.Name = "CD_TabelaDesconto";
            this.CD_TabelaDesconto.NM_Alias = "a";
            this.CD_TabelaDesconto.NM_Campo = "CD_TabelaDesconto";
            this.CD_TabelaDesconto.NM_CampoBusca = "CD_TabelaDesconto";
            this.CD_TabelaDesconto.NM_Param = "@P_CD_TABELADESCONTO";
            this.CD_TabelaDesconto.QTD_Zero = 0;
            this.CD_TabelaDesconto.Size = new System.Drawing.Size(56, 20);
            this.CD_TabelaDesconto.ST_AutoInc = false;
            this.CD_TabelaDesconto.ST_DisableAuto = false;
            this.CD_TabelaDesconto.ST_Float = false;
            this.CD_TabelaDesconto.ST_Gravar = true;
            this.CD_TabelaDesconto.ST_Int = true;
            this.CD_TabelaDesconto.ST_LimpaCampo = true;
            this.CD_TabelaDesconto.ST_NotNull = true;
            this.CD_TabelaDesconto.ST_PrimaryKey = false;
            this.CD_TabelaDesconto.TabIndex = 73;
            this.CD_TabelaDesconto.Leave += new System.EventHandler(this.CD_TabelaDesconto_Leave);
            // 
            // CD_TipoAmostra
            // 
            this.CD_TipoAmostra.BackColor = System.Drawing.SystemColors.Window;
            this.CD_TipoAmostra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_TipoAmostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_TipoAmostra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_TipoAmostra.Location = new System.Drawing.Point(95, 34);
            this.CD_TipoAmostra.Name = "CD_TipoAmostra";
            this.CD_TipoAmostra.NM_Alias = "a";
            this.CD_TipoAmostra.NM_Campo = "CD_TipoAmostra";
            this.CD_TipoAmostra.NM_CampoBusca = "CD_TipoAmostra";
            this.CD_TipoAmostra.NM_Param = "@P_CD_TIPOAMOSTRA";
            this.CD_TipoAmostra.QTD_Zero = 0;
            this.CD_TipoAmostra.Size = new System.Drawing.Size(56, 20);
            this.CD_TipoAmostra.ST_AutoInc = false;
            this.CD_TipoAmostra.ST_DisableAuto = false;
            this.CD_TipoAmostra.ST_Float = false;
            this.CD_TipoAmostra.ST_Gravar = true;
            this.CD_TipoAmostra.ST_Int = true;
            this.CD_TipoAmostra.ST_LimpaCampo = true;
            this.CD_TipoAmostra.ST_NotNull = true;
            this.CD_TipoAmostra.ST_PrimaryKey = false;
            this.CD_TipoAmostra.TabIndex = 77;
            this.CD_TipoAmostra.Leave += new System.EventHandler(this.CD_TipoAmostra_Leave);
            // 
            // TFImportIndice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 105);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFImportIndice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Indice";
            this.Load += new System.EventHandler(this.TFImportIndice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFImportIndice_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_amostra;
        public System.Windows.Forms.Button bb_Amostra;
        private Componentes.EditDefault ds_tabelaDesconto;
        public System.Windows.Forms.Button bb_TabelaDesconto;
        private System.Windows.Forms.Label LB_CD_TabelaDesconto;
        private System.Windows.Forms.Label LB_CD_TipoAmostra;
        private Componentes.EditDefault CD_TabelaDesconto;
        private Componentes.EditDefault CD_TipoAmostra;
    }
}