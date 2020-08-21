namespace Financeiro.Cadastros
{
    partial class TFVendedorEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFVendedorEmpresa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.cbRecebimento = new Componentes.CheckBoxDefault(this.components);
            this.st_comservico = new Componentes.CheckBoxDefault(this.components);
            this.bsVendEmpresa = new System.Windows.Forms.BindingSource(this.components);
            this.pc_fixocomissao = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tp_comissao = new Componentes.ComboBoxDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsVendEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_fixocomissao)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(573, 43);
            this.barraMenu.TabIndex = 536;
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
            this.pDados.Controls.Add(this.cbRecebimento);
            this.pDados.Controls.Add(this.st_comservico);
            this.pDados.Controls.Add(this.pc_fixocomissao);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.tp_comissao);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(573, 106);
            this.pDados.TabIndex = 537;
            // 
            // cbRecebimento
            // 
            this.cbRecebimento.AutoSize = true;
            this.cbRecebimento.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsVendEmpresa, "st_recebimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbRecebimento.Location = new System.Drawing.Point(265, 79);
            this.cbRecebimento.Name = "cbRecebimento";
            this.cbRecebimento.NM_Alias = "";
            this.cbRecebimento.NM_Campo = "";
            this.cbRecebimento.NM_Param = "";
            this.cbRecebimento.Size = new System.Drawing.Size(137, 17);
            this.cbRecebimento.ST_Gravar = false;
            this.cbRecebimento.ST_LimparCampo = true;
            this.cbRecebimento.ST_NotNull = false;
            this.cbRecebimento.TabIndex = 73;
            this.cbRecebimento.Text = "Comissão Recebimento";
            this.cbRecebimento.UseVisualStyleBackColor = true;
            this.cbRecebimento.Vl_False = "";
            this.cbRecebimento.Vl_True = "";
            // 
            // st_comservico
            // 
            this.st_comservico.AutoSize = true;
            this.st_comservico.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsVendEmpresa, "St_comservicobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_comservico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_comservico.Location = new System.Drawing.Point(68, 79);
            this.st_comservico.Name = "st_comservico";
            this.st_comservico.NM_Alias = "";
            this.st_comservico.NM_Campo = "";
            this.st_comservico.NM_Param = "";
            this.st_comservico.Size = new System.Drawing.Size(140, 17);
            this.st_comservico.ST_Gravar = true;
            this.st_comservico.ST_LimparCampo = true;
            this.st_comservico.ST_NotNull = false;
            this.st_comservico.TabIndex = 6;
            this.st_comservico.Text = "Comissionar Serviço";
            this.st_comservico.UseVisualStyleBackColor = true;
            this.st_comservico.Vl_False = "";
            this.st_comservico.Vl_True = "";
            // 
            // bsVendEmpresa
            // 
            this.bsVendEmpresa.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_Empresa);
            // 
            // pc_fixocomissao
            // 
            this.pc_fixocomissao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsVendEmpresa, "Pc_fixocomissao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_fixocomissao.DecimalPlaces = 2;
            this.pc_fixocomissao.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pc_fixocomissao.Location = new System.Drawing.Point(266, 52);
            this.pc_fixocomissao.Name = "pc_fixocomissao";
            this.pc_fixocomissao.NM_Alias = "";
            this.pc_fixocomissao.NM_Campo = "";
            this.pc_fixocomissao.NM_Param = "";
            this.pc_fixocomissao.Operador = "";
            this.pc_fixocomissao.Size = new System.Drawing.Size(113, 20);
            this.pc_fixocomissao.ST_AutoInc = false;
            this.pc_fixocomissao.ST_DisableAuto = false;
            this.pc_fixocomissao.ST_Gravar = false;
            this.pc_fixocomissao.ST_LimparCampo = true;
            this.pc_fixocomissao.ST_NotNull = false;
            this.pc_fixocomissao.ST_PrimaryKey = false;
            this.pc_fixocomissao.TabIndex = 3;
            this.pc_fixocomissao.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(263, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "% Fixo Comissão";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(65, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Tipo Comissão";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tp_comissao
            // 
            this.tp_comissao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsVendEmpresa, "Tp_comissao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_comissao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_comissao.FormattingEnabled = true;
            this.tp_comissao.Location = new System.Drawing.Point(68, 52);
            this.tp_comissao.Name = "tp_comissao";
            this.tp_comissao.NM_Alias = "";
            this.tp_comissao.NM_Campo = "";
            this.tp_comissao.NM_Param = "";
            this.tp_comissao.Size = new System.Drawing.Size(160, 21);
            this.tp_comissao.ST_Gravar = true;
            this.tp_comissao.ST_LimparCampo = true;
            this.tp_comissao.ST_NotNull = true;
            this.tp_comissao.TabIndex = 2;
            this.tp_comissao.SelectedIndexChanged += new System.EventHandler(this.tp_comissao_SelectedIndexChanged);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVendEmpresa, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_empresa.Location = new System.Drawing.Point(187, 7);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(376, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 69;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(151, 7);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(30, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVendEmpresa, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(68, 7);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "a";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_ID_CATEGORIACLIFOR";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(82, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(11, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 68;
            this.label10.Text = "Empresa:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TFVendedorEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 149);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFVendedorEmpresa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração Vendedor";
            this.Load += new System.EventHandler(this.TFVendedorEmpresa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFVendedorEmpresa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsVendEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_fixocomissao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.BindingSource bsVendEmpresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label10;
        private Componentes.EditFloat pc_fixocomissao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault tp_comissao;
        private Componentes.CheckBoxDefault st_comservico;
        private Componentes.CheckBoxDefault cbRecebimento;
    }
}