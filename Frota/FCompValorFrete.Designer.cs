namespace Frota
{
    partial class TFCompValorFrete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCompValorFrete));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.vl_componente = new Componentes.EditFloat(this.components);
            this.bsCompValorFrete = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nm_componente = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_componente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCompValorFrete)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(328, 43);
            this.barraMenu.TabIndex = 23;
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
            this.pDados.Controls.Add(this.vl_componente);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.nm_componente);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(328, 55);
            this.pDados.TabIndex = 0;
            // 
            // vl_componente
            // 
            this.vl_componente.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCompValorFrete, "Vl_componente", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_componente.DecimalPlaces = 2;
            this.vl_componente.Location = new System.Drawing.Point(205, 21);
            this.vl_componente.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_componente.Name = "vl_componente";
            this.vl_componente.NM_Alias = "";
            this.vl_componente.NM_Campo = "";
            this.vl_componente.NM_Param = "";
            this.vl_componente.Operador = "";
            this.vl_componente.Size = new System.Drawing.Size(113, 20);
            this.vl_componente.ST_AutoInc = false;
            this.vl_componente.ST_DisableAuto = false;
            this.vl_componente.ST_Gravar = true;
            this.vl_componente.ST_LimparCampo = true;
            this.vl_componente.ST_NotNull = true;
            this.vl_componente.ST_PrimaryKey = false;
            this.vl_componente.TabIndex = 1;
            this.vl_componente.ThousandsSeparator = true;
            // 
            // bsCompValorFrete
            // 
            this.bsCompValorFrete.DataSource = typeof(CamadaDados.Faturamento.CTRC.TList_CTRCompValorFrete);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(202, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor Componente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome Componente";
            // 
            // nm_componente
            // 
            this.nm_componente.BackColor = System.Drawing.SystemColors.Window;
            this.nm_componente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_componente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_componente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCompValorFrete, "Nm_componente", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_componente.Location = new System.Drawing.Point(11, 21);
            this.nm_componente.MaxLength = 15;
            this.nm_componente.Name = "nm_componente";
            this.nm_componente.NM_Alias = "";
            this.nm_componente.NM_Campo = "";
            this.nm_componente.NM_CampoBusca = "";
            this.nm_componente.NM_Param = "";
            this.nm_componente.QTD_Zero = 0;
            this.nm_componente.Size = new System.Drawing.Size(188, 20);
            this.nm_componente.ST_AutoInc = false;
            this.nm_componente.ST_DisableAuto = false;
            this.nm_componente.ST_Float = false;
            this.nm_componente.ST_Gravar = true;
            this.nm_componente.ST_Int = false;
            this.nm_componente.ST_LimpaCampo = true;
            this.nm_componente.ST_NotNull = true;
            this.nm_componente.ST_PrimaryKey = false;
            this.nm_componente.TabIndex = 0;
            this.nm_componente.TextOld = null;
            // 
            // TFCompValorFrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 98);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCompValorFrete";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Componente Valor Frete";
            this.Load += new System.EventHandler(this.TFCompValorFrete_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCompValorFrete_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_componente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCompValorFrete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault nm_componente;
        private Componentes.EditFloat vl_componente;
        private System.Windows.Forms.BindingSource bsCompValorFrete;
    }
}