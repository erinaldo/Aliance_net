namespace Empreendimento
{
    partial class FDesconto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDesconto));
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.tot_orcamento = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bsOrcamento = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.vl_desconto = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pc_desconto = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tot_orcamento_liq = new Componentes.EditFloat(this.components);
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tot_orcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_desconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_orcamento_liq)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.tot_orcamento_liq);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.pc_desconto);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.vl_desconto);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.tot_orcamento);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(297, 133);
            this.panelDados1.TabIndex = 0;
            // 
            // tot_orcamento
            // 
            this.tot_orcamento.DecimalPlaces = 2;
            this.tot_orcamento.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tot_orcamento.Location = new System.Drawing.Point(12, 23);
            this.tot_orcamento.Maximum = new decimal(new int[] {
            153581795,
            12935,
            0,
            0});
            this.tot_orcamento.Name = "tot_orcamento";
            this.tot_orcamento.NM_Alias = "";
            this.tot_orcamento.NM_Campo = "";
            this.tot_orcamento.NM_Param = "";
            this.tot_orcamento.Operador = "";
            this.tot_orcamento.ReadOnly = true;
            this.tot_orcamento.Size = new System.Drawing.Size(120, 20);
            this.tot_orcamento.ST_AutoInc = false;
            this.tot_orcamento.ST_DisableAuto = false;
            this.tot_orcamento.ST_Gravar = false;
            this.tot_orcamento.ST_LimparCampo = true;
            this.tot_orcamento.ST_NotNull = false;
            this.tot_orcamento.ST_PrimaryKey = false;
            this.tot_orcamento.TabIndex = 0;
            this.tot_orcamento.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Orçamento";
            // 
            // bsOrcamento
            // 
            this.bsOrcamento.DataSource = typeof(CamadaDados.Empreendimento.TList_Orcamento);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor desconto";
            // 
            // vl_desconto
            // 
            this.vl_desconto.DecimalPlaces = 2;
            this.vl_desconto.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_desconto.Location = new System.Drawing.Point(12, 63);
            this.vl_desconto.Maximum = new decimal(new int[] {
            -2132125469,
            1293,
            0,
            0});
            this.vl_desconto.Name = "vl_desconto";
            this.vl_desconto.NM_Alias = "";
            this.vl_desconto.NM_Campo = "";
            this.vl_desconto.NM_Param = "";
            this.vl_desconto.Operador = "";
            this.vl_desconto.Size = new System.Drawing.Size(120, 20);
            this.vl_desconto.ST_AutoInc = false;
            this.vl_desconto.ST_DisableAuto = false;
            this.vl_desconto.ST_Gravar = false;
            this.vl_desconto.ST_LimparCampo = true;
            this.vl_desconto.ST_NotNull = false;
            this.vl_desconto.ST_PrimaryKey = false;
            this.vl_desconto.TabIndex = 2;
            this.vl_desconto.ThousandsSeparator = true;
            this.vl_desconto.Leave += new System.EventHandler(this.vl_desconto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "% desconto";
            // 
            // pc_desconto
            // 
            this.pc_desconto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsOrcamento, "Pc_desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_desconto.DecimalPlaces = 2;
            this.pc_desconto.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pc_desconto.Location = new System.Drawing.Point(12, 101);
            this.pc_desconto.Name = "pc_desconto";
            this.pc_desconto.NM_Alias = "";
            this.pc_desconto.NM_Campo = "";
            this.pc_desconto.NM_Param = "";
            this.pc_desconto.Operador = "";
            this.pc_desconto.Size = new System.Drawing.Size(120, 20);
            this.pc_desconto.ST_AutoInc = false;
            this.pc_desconto.ST_DisableAuto = false;
            this.pc_desconto.ST_Gravar = false;
            this.pc_desconto.ST_LimparCampo = true;
            this.pc_desconto.ST_NotNull = false;
            this.pc_desconto.ST_PrimaryKey = false;
            this.pc_desconto.TabIndex = 4;
            this.pc_desconto.ThousandsSeparator = true;
            this.pc_desconto.Leave += new System.EventHandler(this.pc_desconto_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total Orçamento Liq.";
            // 
            // tot_orcamento_liq
            // 
            this.tot_orcamento_liq.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsOrcamento, "vl_orcamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tot_orcamento_liq.DecimalPlaces = 2;
            this.tot_orcamento_liq.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tot_orcamento_liq.Location = new System.Drawing.Point(148, 23);
            this.tot_orcamento_liq.Maximum = new decimal(new int[] {
            1037115619,
            2341,
            0,
            0});
            this.tot_orcamento_liq.Name = "tot_orcamento_liq";
            this.tot_orcamento_liq.NM_Alias = "";
            this.tot_orcamento_liq.NM_Campo = "";
            this.tot_orcamento_liq.NM_Param = "";
            this.tot_orcamento_liq.Operador = "";
            this.tot_orcamento_liq.ReadOnly = true;
            this.tot_orcamento_liq.Size = new System.Drawing.Size(120, 20);
            this.tot_orcamento_liq.ST_AutoInc = false;
            this.tot_orcamento_liq.ST_DisableAuto = false;
            this.tot_orcamento_liq.ST_Gravar = false;
            this.tot_orcamento_liq.ST_LimparCampo = true;
            this.tot_orcamento_liq.ST_NotNull = false;
            this.tot_orcamento_liq.ST_PrimaryKey = false;
            this.tot_orcamento_liq.TabIndex = 6;
            this.tot_orcamento_liq.ThousandsSeparator = true;
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(297, 43);
            this.barraMenu.TabIndex = 13;
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
            this.bb_inutilizar.ToolTipText = "Gravar";
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
            // FDesconto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 176);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FDesconto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FDesconto";
            this.Load += new System.EventHandler(this.FDesconto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FDesconto_KeyDown);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tot_orcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_desconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_orcamento_liq)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat tot_orcamento;
        private System.Windows.Forms.BindingSource bsOrcamento;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat vl_desconto;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat pc_desconto;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat tot_orcamento_liq;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
    }
}