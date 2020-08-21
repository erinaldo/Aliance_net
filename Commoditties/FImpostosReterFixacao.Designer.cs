namespace Commoditties
{
    partial class TFImpostosReterFixacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFImpostosReterFixacao));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.pc_reducaobasecalc = new Componentes.EditFloat(this.components);
            this.bsImpostosReterFixacao = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pc_aliquota = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cd_imposto = new Componentes.EditDefault(this.components);
            this.ds_imposto = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.bb_imposto = new System.Windows.Forms.Button();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_reducaobasecalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsImpostosReterFixacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_aliquota)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(591, 43);
            this.barraMenu.TabIndex = 12;
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.pc_reducaobasecalc);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.pc_aliquota);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_imposto);
            this.pDados.Controls.Add(this.ds_imposto);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.bb_imposto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(591, 89);
            this.pDados.TabIndex = 13;
            // 
            // pc_reducaobasecalc
            // 
            this.pc_reducaobasecalc.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsImpostosReterFixacao, "Pc_reducaobasecalc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_reducaobasecalc.DecimalPlaces = 2;
            this.pc_reducaobasecalc.Location = new System.Drawing.Point(114, 59);
            this.pc_reducaobasecalc.Name = "pc_reducaobasecalc";
            this.pc_reducaobasecalc.NM_Alias = "";
            this.pc_reducaobasecalc.NM_Campo = "";
            this.pc_reducaobasecalc.NM_Param = "";
            this.pc_reducaobasecalc.Operador = "";
            this.pc_reducaobasecalc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pc_reducaobasecalc.Size = new System.Drawing.Size(120, 20);
            this.pc_reducaobasecalc.ST_AutoInc = false;
            this.pc_reducaobasecalc.ST_DisableAuto = false;
            this.pc_reducaobasecalc.ST_Gravar = true;
            this.pc_reducaobasecalc.ST_LimparCampo = true;
            this.pc_reducaobasecalc.ST_NotNull = false;
            this.pc_reducaobasecalc.ST_PrimaryKey = false;
            this.pc_reducaobasecalc.TabIndex = 3;
            this.pc_reducaobasecalc.ThousandsSeparator = true;
            // 
            // bsImpostosReterFixacao
            // 
            this.bsImpostosReterFixacao.DataSource = typeof(CamadaDados.Graos.TList_ImpostosReterFixacao);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 143;
            this.label2.Text = "% Red. Base Calc.:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pc_aliquota
            // 
            this.pc_aliquota.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsImpostosReterFixacao, "Pc_aliquota", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_aliquota.DecimalPlaces = 2;
            this.pc_aliquota.Location = new System.Drawing.Point(114, 33);
            this.pc_aliquota.Name = "pc_aliquota";
            this.pc_aliquota.NM_Alias = "";
            this.pc_aliquota.NM_Campo = "";
            this.pc_aliquota.NM_Param = "";
            this.pc_aliquota.Operador = "";
            this.pc_aliquota.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pc_aliquota.Size = new System.Drawing.Size(120, 20);
            this.pc_aliquota.ST_AutoInc = false;
            this.pc_aliquota.ST_DisableAuto = false;
            this.pc_aliquota.ST_Gravar = false;
            this.pc_aliquota.ST_LimparCampo = true;
            this.pc_aliquota.ST_NotNull = true;
            this.pc_aliquota.ST_PrimaryKey = false;
            this.pc_aliquota.TabIndex = 2;
            this.pc_aliquota.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(49, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 141;
            this.label1.Text = "% Aliquota:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_imposto
            // 
            this.cd_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsImpostosReterFixacao, "Cd_impostostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_imposto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_imposto.Location = new System.Drawing.Point(114, 6);
            this.cd_imposto.Name = "cd_imposto";
            this.cd_imposto.NM_Alias = "";
            this.cd_imposto.NM_Campo = "cd_imposto";
            this.cd_imposto.NM_CampoBusca = "cd_imposto";
            this.cd_imposto.NM_Param = "@P_CD_CLIFOR";
            this.cd_imposto.QTD_Zero = 0;
            this.cd_imposto.Size = new System.Drawing.Size(73, 20);
            this.cd_imposto.ST_AutoInc = false;
            this.cd_imposto.ST_DisableAuto = false;
            this.cd_imposto.ST_Float = false;
            this.cd_imposto.ST_Gravar = true;
            this.cd_imposto.ST_Int = true;
            this.cd_imposto.ST_LimpaCampo = true;
            this.cd_imposto.ST_NotNull = true;
            this.cd_imposto.ST_PrimaryKey = false;
            this.cd_imposto.TabIndex = 0;
            this.cd_imposto.Leave += new System.EventHandler(this.cd_imposto_Leave);
            // 
            // ds_imposto
            // 
            this.ds_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsImpostosReterFixacao, "Ds_imposto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_imposto.Enabled = false;
            this.ds_imposto.Location = new System.Drawing.Point(221, 7);
            this.ds_imposto.Name = "ds_imposto";
            this.ds_imposto.NM_Alias = "a";
            this.ds_imposto.NM_Campo = "ds_imposto";
            this.ds_imposto.NM_CampoBusca = "ds_imposto";
            this.ds_imposto.NM_Param = "@P_DS_SAFRA";
            this.ds_imposto.QTD_Zero = 0;
            this.ds_imposto.Size = new System.Drawing.Size(356, 20);
            this.ds_imposto.ST_AutoInc = false;
            this.ds_imposto.ST_DisableAuto = false;
            this.ds_imposto.ST_Float = false;
            this.ds_imposto.ST_Gravar = false;
            this.ds_imposto.ST_Int = false;
            this.ds_imposto.ST_LimpaCampo = true;
            this.ds_imposto.ST_NotNull = false;
            this.ds_imposto.ST_PrimaryKey = false;
            this.ds_imposto.TabIndex = 140;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(61, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 139;
            this.label5.Text = "Imposto:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_imposto
            // 
            this.bb_imposto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_imposto.Image = ((System.Drawing.Image)(resources.GetObject("bb_imposto.Image")));
            this.bb_imposto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_imposto.Location = new System.Drawing.Point(189, 7);
            this.bb_imposto.Name = "bb_imposto";
            this.bb_imposto.Size = new System.Drawing.Size(30, 19);
            this.bb_imposto.TabIndex = 1;
            this.bb_imposto.UseVisualStyleBackColor = false;
            this.bb_imposto.Click += new System.EventHandler(this.bb_imposto_Click);
            // 
            // TFImpostosReterFixacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 132);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFImpostosReterFixacao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impostos Reter Fixação";
            this.Load += new System.EventHandler(this.TFImpostosReterFixacao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFImpostosReterFixacao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_reducaobasecalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsImpostosReterFixacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_aliquota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsImpostosReterFixacao;
        private Componentes.EditFloat pc_reducaobasecalc;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat pc_aliquota;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_imposto;
        private Componentes.EditDefault ds_imposto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bb_imposto;
    }
}