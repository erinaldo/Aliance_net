namespace Financeiro.Cadastros
{
    partial class TFCadVendedorCondPgto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadVendedorCondPgto));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_condpgto = new Componentes.EditDefault(this.components);
            this.bb_condpgto = new System.Windows.Forms.Button();
            this.cd_condpgto = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.pc_basecalccomissao = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bsVendCond = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_basecalccomissao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVendCond)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(571, 43);
            this.barraMenu.TabIndex = 537;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.pc_basecalccomissao);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_condpgto);
            this.pDados.Controls.Add(this.bb_condpgto);
            this.pDados.Controls.Add(this.cd_condpgto);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(571, 91);
            this.pDados.TabIndex = 538;
            // 
            // ds_condpgto
            // 
            this.ds_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVendCond, "Ds_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_condpgto.Enabled = false;
            this.ds_condpgto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_condpgto.Location = new System.Drawing.Point(131, 21);
            this.ds_condpgto.Name = "ds_condpgto";
            this.ds_condpgto.NM_Alias = "";
            this.ds_condpgto.NM_Campo = "ds_condpgto";
            this.ds_condpgto.NM_CampoBusca = "ds_condpgto";
            this.ds_condpgto.NM_Param = "@P_NM_EMPRESA";
            this.ds_condpgto.QTD_Zero = 0;
            this.ds_condpgto.Size = new System.Drawing.Size(434, 20);
            this.ds_condpgto.ST_AutoInc = false;
            this.ds_condpgto.ST_DisableAuto = false;
            this.ds_condpgto.ST_Float = false;
            this.ds_condpgto.ST_Gravar = false;
            this.ds_condpgto.ST_Int = false;
            this.ds_condpgto.ST_LimpaCampo = true;
            this.ds_condpgto.ST_NotNull = false;
            this.ds_condpgto.ST_PrimaryKey = false;
            this.ds_condpgto.TabIndex = 73;
            this.ds_condpgto.TextOld = null;
            // 
            // bb_condpgto
            // 
            this.bb_condpgto.Image = ((System.Drawing.Image)(resources.GetObject("bb_condpgto.Image")));
            this.bb_condpgto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_condpgto.Location = new System.Drawing.Point(95, 21);
            this.bb_condpgto.Name = "bb_condpgto";
            this.bb_condpgto.Size = new System.Drawing.Size(30, 20);
            this.bb_condpgto.TabIndex = 1;
            this.bb_condpgto.UseVisualStyleBackColor = true;
            this.bb_condpgto.Click += new System.EventHandler(this.bb_condpgto_Click);
            // 
            // cd_condpgto
            // 
            this.cd_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVendCond, "Cd_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_condpgto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_condpgto.Location = new System.Drawing.Point(12, 21);
            this.cd_condpgto.Name = "cd_condpgto";
            this.cd_condpgto.NM_Alias = "a";
            this.cd_condpgto.NM_Campo = "cd_condpgto";
            this.cd_condpgto.NM_CampoBusca = "cd_condpgto";
            this.cd_condpgto.NM_Param = "@P_ID_CATEGORIACLIFOR";
            this.cd_condpgto.QTD_Zero = 0;
            this.cd_condpgto.Size = new System.Drawing.Size(82, 20);
            this.cd_condpgto.ST_AutoInc = false;
            this.cd_condpgto.ST_DisableAuto = false;
            this.cd_condpgto.ST_Float = false;
            this.cd_condpgto.ST_Gravar = true;
            this.cd_condpgto.ST_Int = true;
            this.cd_condpgto.ST_LimpaCampo = true;
            this.cd_condpgto.ST_NotNull = true;
            this.cd_condpgto.ST_PrimaryKey = false;
            this.cd_condpgto.TabIndex = 0;
            this.cd_condpgto.TextOld = null;
            this.cd_condpgto.Leave += new System.EventHandler(this.cd_condpgto_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(9, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 13);
            this.label10.TabIndex = 72;
            this.label10.Text = "Condição Pagamento";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pc_basecalccomissao
            // 
            this.pc_basecalccomissao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsVendCond, "Pc_basecalc_comissao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_basecalccomissao.DecimalPlaces = 2;
            this.pc_basecalccomissao.Location = new System.Drawing.Point(12, 60);
            this.pc_basecalccomissao.Name = "pc_basecalccomissao";
            this.pc_basecalccomissao.NM_Alias = "";
            this.pc_basecalccomissao.NM_Campo = "";
            this.pc_basecalccomissao.NM_Param = "";
            this.pc_basecalccomissao.Operador = "";
            this.pc_basecalccomissao.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pc_basecalccomissao.Size = new System.Drawing.Size(100, 20);
            this.pc_basecalccomissao.ST_AutoInc = false;
            this.pc_basecalccomissao.ST_DisableAuto = false;
            this.pc_basecalccomissao.ST_Gravar = false;
            this.pc_basecalccomissao.ST_LimparCampo = true;
            this.pc_basecalccomissao.ST_NotNull = false;
            this.pc_basecalccomissao.ST_PrimaryKey = false;
            this.pc_basecalccomissao.TabIndex = 2;
            this.pc_basecalccomissao.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "% Base Calculo";
            // 
            // bsVendCond
            // 
            this.bsVendCond.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_CondPgto);
            // 
            // TFCadVendedorCondPgto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 134);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCadVendedorCondPgto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Condição Pagamento Vendedor";
            this.Load += new System.EventHandler(this.TFCadVendedorCondPgto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCadVendedorCondPgto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_basecalccomissao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVendCond)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_condpgto;
        private System.Windows.Forms.Button bb_condpgto;
        private Componentes.EditDefault cd_condpgto;
        private System.Windows.Forms.Label label10;
        private Componentes.EditFloat pc_basecalccomissao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bsVendCond;
    }
}