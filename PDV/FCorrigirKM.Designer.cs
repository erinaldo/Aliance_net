namespace PDV
{
    partial class TFCorrigirKM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCorrigirKM));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ultimo_km = new Componentes.EditFloat(this.components);
            this.km_corrigido = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.km_atual = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultimo_km)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_corrigido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_atual)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(203, 43);
            this.barraMenu.TabIndex = 18;
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.km_atual);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.km_corrigido);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ultimo_km);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(203, 132);
            this.pDados.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ultimo KM";
            // 
            // ultimo_km
            // 
            this.ultimo_km.Enabled = false;
            this.ultimo_km.Location = new System.Drawing.Point(11, 21);
            this.ultimo_km.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.ultimo_km.Name = "ultimo_km";
            this.ultimo_km.NM_Alias = "";
            this.ultimo_km.NM_Campo = "";
            this.ultimo_km.NM_Param = "";
            this.ultimo_km.Operador = "";
            this.ultimo_km.Size = new System.Drawing.Size(120, 20);
            this.ultimo_km.ST_AutoInc = false;
            this.ultimo_km.ST_DisableAuto = false;
            this.ultimo_km.ST_Gravar = false;
            this.ultimo_km.ST_LimparCampo = true;
            this.ultimo_km.ST_NotNull = false;
            this.ultimo_km.ST_PrimaryKey = false;
            this.ultimo_km.TabIndex = 1;
            this.ultimo_km.ThousandsSeparator = true;
            // 
            // km_corrigido
            // 
            this.km_corrigido.Location = new System.Drawing.Point(11, 60);
            this.km_corrigido.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.km_corrigido.Name = "km_corrigido";
            this.km_corrigido.NM_Alias = "";
            this.km_corrigido.NM_Campo = "";
            this.km_corrigido.NM_Param = "";
            this.km_corrigido.Operador = "";
            this.km_corrigido.Size = new System.Drawing.Size(120, 20);
            this.km_corrigido.ST_AutoInc = false;
            this.km_corrigido.ST_DisableAuto = false;
            this.km_corrigido.ST_Gravar = false;
            this.km_corrigido.ST_LimparCampo = true;
            this.km_corrigido.ST_NotNull = false;
            this.km_corrigido.ST_PrimaryKey = false;
            this.km_corrigido.TabIndex = 0;
            this.km_corrigido.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "KM Corrigido";
            // 
            // km_atual
            // 
            this.km_atual.Enabled = false;
            this.km_atual.Location = new System.Drawing.Point(11, 99);
            this.km_atual.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.km_atual.Name = "km_atual";
            this.km_atual.NM_Alias = "";
            this.km_atual.NM_Campo = "";
            this.km_atual.NM_Param = "";
            this.km_atual.Operador = "";
            this.km_atual.Size = new System.Drawing.Size(120, 20);
            this.km_atual.ST_AutoInc = false;
            this.km_atual.ST_DisableAuto = false;
            this.km_atual.ST_Gravar = false;
            this.km_atual.ST_LimparCampo = true;
            this.km_atual.ST_NotNull = false;
            this.km_atual.ST_PrimaryKey = false;
            this.km_atual.TabIndex = 5;
            this.km_atual.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "KM Abastecida Atual";
            // 
            // TFCorrigirKM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 175);
            this.ControlBox = false;
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCorrigirKM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corrigir KM";
            this.Load += new System.EventHandler(this.TFCorrigirKM_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCorrigirKM_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultimo_km)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_corrigido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_atual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat km_atual;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat km_corrigido;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat ultimo_km;
    }
}