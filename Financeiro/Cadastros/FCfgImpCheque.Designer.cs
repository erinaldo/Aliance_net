namespace Financeiro.Cadastros
{
    partial class TFCfgImpCheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCfgImpCheque));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.st_negrito = new Componentes.CheckBoxDefault(this.components);
            this.bsCfgImpCheque = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.tp_fonte = new Componentes.ComboBoxDefault(this.components);
            this.nm_campo = new Componentes.ComboBoxDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tp_alinhamento = new Componentes.ComboBoxDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tamanho = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.coluna = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.linha = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgImpCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tamanho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coluna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linha)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(454, 43);
            this.barraMenu.TabIndex = 537;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
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
            this.pDados.Controls.Add(this.st_negrito);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.tp_fonte);
            this.pDados.Controls.Add(this.nm_campo);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.tp_alinhamento);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.tamanho);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.coluna);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.linha);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(454, 85);
            this.pDados.TabIndex = 538;
            // 
            // st_negrito
            // 
            this.st_negrito.AutoSize = true;
            this.st_negrito.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCfgImpCheque, "St_negritobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_negrito.Location = new System.Drawing.Point(387, 57);
            this.st_negrito.Name = "st_negrito";
            this.st_negrito.NM_Alias = "";
            this.st_negrito.NM_Campo = "";
            this.st_negrito.NM_Param = "";
            this.st_negrito.Size = new System.Drawing.Size(60, 17);
            this.st_negrito.ST_Gravar = true;
            this.st_negrito.ST_LimparCampo = true;
            this.st_negrito.ST_NotNull = false;
            this.st_negrito.TabIndex = 6;
            this.st_negrito.Text = "Negrito";
            this.st_negrito.UseVisualStyleBackColor = true;
            this.st_negrito.Vl_False = "";
            this.st_negrito.Vl_True = "";
            // 
            // bsCfgImpCheque
            // 
            this.bsCfgImpCheque.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CFGImpCheque);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fonte";
            // 
            // tp_fonte
            // 
            this.tp_fonte.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCfgImpCheque, "Tp_fonte", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_fonte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_fonte.FormattingEnabled = true;
            this.tp_fonte.Location = new System.Drawing.Point(258, 55);
            this.tp_fonte.Name = "tp_fonte";
            this.tp_fonte.NM_Alias = "";
            this.tp_fonte.NM_Campo = "";
            this.tp_fonte.NM_Param = "";
            this.tp_fonte.Size = new System.Drawing.Size(123, 21);
            this.tp_fonte.ST_Gravar = true;
            this.tp_fonte.ST_LimparCampo = true;
            this.tp_fonte.ST_NotNull = false;
            this.tp_fonte.TabIndex = 5;
            // 
            // nm_campo
            // 
            this.nm_campo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCfgImpCheque, "Nm_campo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_campo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nm_campo.FormattingEnabled = true;
            this.nm_campo.Location = new System.Drawing.Point(91, 3);
            this.nm_campo.Name = "nm_campo";
            this.nm_campo.NM_Alias = "";
            this.nm_campo.NM_Campo = "";
            this.nm_campo.NM_Param = "";
            this.nm_campo.Size = new System.Drawing.Size(356, 21);
            this.nm_campo.ST_Gravar = true;
            this.nm_campo.ST_LimparCampo = true;
            this.nm_campo.ST_NotNull = true;
            this.nm_campo.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Alinhamento:";
            // 
            // tp_alinhamento
            // 
            this.tp_alinhamento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCfgImpCheque, "Tp_alinhamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_alinhamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_alinhamento.FormattingEnabled = true;
            this.tp_alinhamento.Location = new System.Drawing.Point(91, 55);
            this.tp_alinhamento.Name = "tp_alinhamento";
            this.tp_alinhamento.NM_Alias = "";
            this.tp_alinhamento.NM_Campo = "";
            this.tp_alinhamento.NM_Param = "";
            this.tp_alinhamento.Size = new System.Drawing.Size(121, 21);
            this.tp_alinhamento.ST_Gravar = true;
            this.tp_alinhamento.ST_LimparCampo = true;
            this.tp_alinhamento.ST_NotNull = true;
            this.tp_alinhamento.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tamanho:";
            // 
            // tamanho
            // 
            this.tamanho.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCfgImpCheque, "Tamanho", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"));
            this.tamanho.Location = new System.Drawing.Point(369, 29);
            this.tamanho.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.tamanho.Name = "tamanho";
            this.tamanho.NM_Alias = "";
            this.tamanho.NM_Campo = "";
            this.tamanho.NM_Param = "";
            this.tamanho.Operador = "";
            this.tamanho.Size = new System.Drawing.Size(78, 20);
            this.tamanho.ST_AutoInc = false;
            this.tamanho.ST_DisableAuto = false;
            this.tamanho.ST_Gravar = true;
            this.tamanho.ST_LimparCampo = true;
            this.tamanho.ST_NotNull = true;
            this.tamanho.ST_PrimaryKey = false;
            this.tamanho.TabIndex = 3;
            this.tamanho.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Coluna:";
            // 
            // coluna
            // 
            this.coluna.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCfgImpCheque, "Coluna", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.coluna.Location = new System.Drawing.Point(224, 29);
            this.coluna.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.coluna.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.coluna.Name = "coluna";
            this.coluna.NM_Alias = "";
            this.coluna.NM_Campo = "";
            this.coluna.NM_Param = "";
            this.coluna.Operador = "";
            this.coluna.Size = new System.Drawing.Size(78, 20);
            this.coluna.ST_AutoInc = false;
            this.coluna.ST_DisableAuto = false;
            this.coluna.ST_Gravar = true;
            this.coluna.ST_LimparCampo = true;
            this.coluna.ST_NotNull = true;
            this.coluna.ST_PrimaryKey = false;
            this.coluna.TabIndex = 2;
            this.coluna.ThousandsSeparator = true;
            this.coluna.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Linha:";
            // 
            // linha
            // 
            this.linha.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCfgImpCheque, "Linha", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"));
            this.linha.Location = new System.Drawing.Point(91, 29);
            this.linha.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.linha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.linha.Name = "linha";
            this.linha.NM_Alias = "";
            this.linha.NM_Campo = "";
            this.linha.NM_Param = "";
            this.linha.Operador = "";
            this.linha.Size = new System.Drawing.Size(78, 20);
            this.linha.ST_AutoInc = false;
            this.linha.ST_DisableAuto = false;
            this.linha.ST_Gravar = true;
            this.linha.ST_LimparCampo = true;
            this.linha.ST_NotNull = true;
            this.linha.ST_PrimaryKey = false;
            this.linha.TabIndex = 1;
            this.linha.ThousandsSeparator = true;
            this.linha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome Campo:";
            // 
            // TFCfgImpCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 128);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCfgImpCheque";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração Impressão Cheque";
            this.Load += new System.EventHandler(this.TFCfgImpCheque_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCfgImpCheque_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgImpCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tamanho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coluna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label5;
        private Componentes.ComboBoxDefault tp_alinhamento;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat tamanho;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat coluna;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat linha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsCfgImpCheque;
        private Componentes.ComboBoxDefault nm_campo;
        private Componentes.CheckBoxDefault st_negrito;
        private System.Windows.Forms.Label label6;
        private Componentes.ComboBoxDefault tp_fonte;
    }
}