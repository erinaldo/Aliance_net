namespace Faturamento
{
    partial class TFTotalizadorECF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTotalizadorECF));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.vl_totalizador = new Componentes.EditFloat(this.components);
            this.bsTotalizador = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_totalizador = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tp_aliquota = new Componentes.ComboBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totalizador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTotalizador)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(240, 43);
            this.barraMenu.TabIndex = 10;
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.tp_aliquota);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.vl_totalizador);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_totalizador);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(240, 85);
            this.pDados.TabIndex = 11;
            // 
            // vl_totalizador
            // 
            this.vl_totalizador.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTotalizador, "Vl_totalizador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.vl_totalizador.DecimalPlaces = 2;
            this.vl_totalizador.Location = new System.Drawing.Point(90, 29);
            this.vl_totalizador.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_totalizador.Name = "vl_totalizador";
            this.vl_totalizador.NM_Alias = "";
            this.vl_totalizador.NM_Campo = "";
            this.vl_totalizador.NM_Param = "";
            this.vl_totalizador.Operador = "";
            this.vl_totalizador.Size = new System.Drawing.Size(100, 20);
            this.vl_totalizador.ST_AutoInc = false;
            this.vl_totalizador.ST_DisableAuto = false;
            this.vl_totalizador.ST_Gravar = true;
            this.vl_totalizador.ST_LimparCampo = true;
            this.vl_totalizador.ST_NotNull = true;
            this.vl_totalizador.ST_PrimaryKey = false;
            this.vl_totalizador.TabIndex = 1;
            this.vl_totalizador.ThousandsSeparator = true;
            // 
            // bsTotalizador
            // 
            this.bsTotalizador.DataSource = typeof(CamadaDados.Faturamento.PDV.TList_TotalizadorMapa);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vl. Totalizador:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cd. Totalizador:";
            // 
            // cd_totalizador
            // 
            this.cd_totalizador.BackColor = System.Drawing.SystemColors.Window;
            this.cd_totalizador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_totalizador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTotalizador, "Cd_totalizador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_totalizador.Location = new System.Drawing.Point(90, 3);
            this.cd_totalizador.Name = "cd_totalizador";
            this.cd_totalizador.NM_Alias = "";
            this.cd_totalizador.NM_Campo = "";
            this.cd_totalizador.NM_CampoBusca = "";
            this.cd_totalizador.NM_Param = "";
            this.cd_totalizador.QTD_Zero = 0;
            this.cd_totalizador.Size = new System.Drawing.Size(100, 20);
            this.cd_totalizador.ST_AutoInc = false;
            this.cd_totalizador.ST_DisableAuto = false;
            this.cd_totalizador.ST_Float = false;
            this.cd_totalizador.ST_Gravar = true;
            this.cd_totalizador.ST_Int = false;
            this.cd_totalizador.ST_LimpaCampo = true;
            this.cd_totalizador.ST_NotNull = true;
            this.cd_totalizador.ST_PrimaryKey = false;
            this.cd_totalizador.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Aliquota:";
            // 
            // tp_aliquota
            // 
            this.tp_aliquota.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsTotalizador, "Tp_aliquota", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_aliquota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_aliquota.FormattingEnabled = true;
            this.tp_aliquota.Location = new System.Drawing.Point(90, 55);
            this.tp_aliquota.Name = "tp_aliquota";
            this.tp_aliquota.NM_Alias = "";
            this.tp_aliquota.NM_Campo = "";
            this.tp_aliquota.NM_Param = "";
            this.tp_aliquota.Size = new System.Drawing.Size(100, 21);
            this.tp_aliquota.ST_Gravar = true;
            this.tp_aliquota.ST_LimparCampo = true;
            this.tp_aliquota.ST_NotNull = true;
            this.tp_aliquota.TabIndex = 4;
            // 
            // TFTotalizadorECF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 128);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFTotalizadorECF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Totalizador Mapa Resumo ECF";
            this.Load += new System.EventHandler(this.TFTotalizadorECF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFTotalizadorECF_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_totalizador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTotalizador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditFloat vl_totalizador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_totalizador;
        private System.Windows.Forms.BindingSource bsTotalizador;
        private Componentes.ComboBoxDefault tp_aliquota;
        private System.Windows.Forms.Label label3;
    }
}