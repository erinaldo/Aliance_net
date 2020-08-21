namespace Financeiro.Cadastros
{
    partial class TFDadosBanc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDadosBanc));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pnl_Dados_Bancarios = new Componentes.PanelDados(this.components);
            this.cbTpConta = new Componentes.ComboBoxDefault(this.components);
            this.bsDados = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Ds_Banco = new Componentes.EditDefault(this.components);
            this.BB_Banco = new System.Windows.Forms.Button();
            this.LB_Nr_Agencia = new System.Windows.Forms.Label();
            this.LB_Nr_Conta = new System.Windows.Forms.Label();
            this.LB_CD_Banco = new System.Windows.Forms.Label();
            this.Nr_Agencia = new Componentes.EditDefault(this.components);
            this.Nr_Conta = new Componentes.EditDefault(this.components);
            this.CD_Banco = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nm_favorecido = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.doc_favorecido = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pnl_Dados_Bancarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDados)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(525, 43);
            this.barraMenu.TabIndex = 538;
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
            // pnl_Dados_Bancarios
            // 
            this.pnl_Dados_Bancarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Dados_Bancarios.Controls.Add(this.label3);
            this.pnl_Dados_Bancarios.Controls.Add(this.doc_favorecido);
            this.pnl_Dados_Bancarios.Controls.Add(this.label2);
            this.pnl_Dados_Bancarios.Controls.Add(this.nm_favorecido);
            this.pnl_Dados_Bancarios.Controls.Add(this.cbTpConta);
            this.pnl_Dados_Bancarios.Controls.Add(this.label1);
            this.pnl_Dados_Bancarios.Controls.Add(this.Ds_Banco);
            this.pnl_Dados_Bancarios.Controls.Add(this.BB_Banco);
            this.pnl_Dados_Bancarios.Controls.Add(this.LB_Nr_Agencia);
            this.pnl_Dados_Bancarios.Controls.Add(this.LB_Nr_Conta);
            this.pnl_Dados_Bancarios.Controls.Add(this.LB_CD_Banco);
            this.pnl_Dados_Bancarios.Controls.Add(this.Nr_Agencia);
            this.pnl_Dados_Bancarios.Controls.Add(this.Nr_Conta);
            this.pnl_Dados_Bancarios.Controls.Add(this.CD_Banco);
            this.pnl_Dados_Bancarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Dados_Bancarios.Location = new System.Drawing.Point(0, 43);
            this.pnl_Dados_Bancarios.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Dados_Bancarios.Name = "pnl_Dados_Bancarios";
            this.pnl_Dados_Bancarios.NM_ProcDeletar = "";
            this.pnl_Dados_Bancarios.NM_ProcGravar = "";
            this.pnl_Dados_Bancarios.Size = new System.Drawing.Size(525, 114);
            this.pnl_Dados_Bancarios.TabIndex = 539;
            // 
            // cbTpConta
            // 
            this.cbTpConta.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsDados, "Tp_conta", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbTpConta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTpConta.FormattingEnabled = true;
            this.cbTpConta.Location = new System.Drawing.Point(412, 33);
            this.cbTpConta.Name = "cbTpConta";
            this.cbTpConta.NM_Alias = "";
            this.cbTpConta.NM_Campo = "";
            this.cbTpConta.NM_Param = "";
            this.cbTpConta.Size = new System.Drawing.Size(105, 21);
            this.cbTpConta.ST_Gravar = false;
            this.cbTpConta.ST_LimparCampo = true;
            this.cbTpConta.ST_NotNull = false;
            this.cbTpConta.TabIndex = 4;
            // 
            // bsDados
            // 
            this.bsDados.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadDados_Bancarios_Clifor);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(348, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "TP. Conta:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Ds_Banco
            // 
            this.Ds_Banco.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_Banco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_Banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_Banco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDados, "DS_Banco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_Banco.Enabled = false;
            this.Ds_Banco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Ds_Banco.Location = new System.Drawing.Point(201, 11);
            this.Ds_Banco.Name = "Ds_Banco";
            this.Ds_Banco.NM_Alias = "ban";
            this.Ds_Banco.NM_Campo = "Ds_Banco";
            this.Ds_Banco.NM_CampoBusca = "Ds_Banco";
            this.Ds_Banco.NM_Param = "@P_DS_BANCO";
            this.Ds_Banco.QTD_Zero = 0;
            this.Ds_Banco.Size = new System.Drawing.Size(316, 20);
            this.Ds_Banco.ST_AutoInc = false;
            this.Ds_Banco.ST_DisableAuto = false;
            this.Ds_Banco.ST_Float = false;
            this.Ds_Banco.ST_Gravar = false;
            this.Ds_Banco.ST_Int = false;
            this.Ds_Banco.ST_LimpaCampo = true;
            this.Ds_Banco.ST_NotNull = false;
            this.Ds_Banco.ST_PrimaryKey = false;
            this.Ds_Banco.TabIndex = 7;
            this.Ds_Banco.TextOld = null;
            // 
            // BB_Banco
            // 
            this.BB_Banco.Image = ((System.Drawing.Image)(resources.GetObject("BB_Banco.Image")));
            this.BB_Banco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Banco.Location = new System.Drawing.Point(168, 10);
            this.BB_Banco.Name = "BB_Banco";
            this.BB_Banco.Size = new System.Drawing.Size(30, 20);
            this.BB_Banco.TabIndex = 1;
            this.BB_Banco.UseVisualStyleBackColor = true;
            this.BB_Banco.Click += new System.EventHandler(this.BB_Banco_Click);
            // 
            // LB_Nr_Agencia
            // 
            this.LB_Nr_Agencia.AutoSize = true;
            this.LB_Nr_Agencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Nr_Agencia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Nr_Agencia.Location = new System.Drawing.Point(11, 36);
            this.LB_Nr_Agencia.Name = "LB_Nr_Agencia";
            this.LB_Nr_Agencia.Size = new System.Drawing.Size(72, 13);
            this.LB_Nr_Agencia.TabIndex = 8;
            this.LB_Nr_Agencia.Text = "NRº Agência:";
            this.LB_Nr_Agencia.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_Nr_Conta
            // 
            this.LB_Nr_Conta.AutoSize = true;
            this.LB_Nr_Conta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Nr_Conta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Nr_Conta.Location = new System.Drawing.Point(173, 36);
            this.LB_Nr_Conta.Name = "LB_Nr_Conta";
            this.LB_Nr_Conta.Size = new System.Drawing.Size(53, 13);
            this.LB_Nr_Conta.TabIndex = 9;
            this.LB_Nr_Conta.Text = "Nº Conta:";
            this.LB_Nr_Conta.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_CD_Banco
            // 
            this.LB_CD_Banco.AutoSize = true;
            this.LB_CD_Banco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Banco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Banco.Location = new System.Drawing.Point(42, 13);
            this.LB_CD_Banco.Name = "LB_CD_Banco";
            this.LB_CD_Banco.Size = new System.Drawing.Size(41, 13);
            this.LB_CD_Banco.TabIndex = 11;
            this.LB_CD_Banco.Text = "Banco:";
            this.LB_CD_Banco.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Nr_Agencia
            // 
            this.Nr_Agencia.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_Agencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_Agencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_Agencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDados, "NR_Agencia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nr_Agencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Nr_Agencia.Location = new System.Drawing.Point(89, 33);
            this.Nr_Agencia.Name = "Nr_Agencia";
            this.Nr_Agencia.NM_Alias = "a";
            this.Nr_Agencia.NM_Campo = "Nr_Agencia";
            this.Nr_Agencia.NM_CampoBusca = "Nr_Agencia";
            this.Nr_Agencia.NM_Param = "@P_NR_AGENCIA";
            this.Nr_Agencia.QTD_Zero = 0;
            this.Nr_Agencia.Size = new System.Drawing.Size(78, 20);
            this.Nr_Agencia.ST_AutoInc = false;
            this.Nr_Agencia.ST_DisableAuto = false;
            this.Nr_Agencia.ST_Float = false;
            this.Nr_Agencia.ST_Gravar = true;
            this.Nr_Agencia.ST_Int = false;
            this.Nr_Agencia.ST_LimpaCampo = true;
            this.Nr_Agencia.ST_NotNull = true;
            this.Nr_Agencia.ST_PrimaryKey = false;
            this.Nr_Agencia.TabIndex = 2;
            this.Nr_Agencia.TextOld = null;
            // 
            // Nr_Conta
            // 
            this.Nr_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_Conta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_Conta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_Conta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDados, "NR_Conta", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nr_Conta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Nr_Conta.Location = new System.Drawing.Point(232, 33);
            this.Nr_Conta.Name = "Nr_Conta";
            this.Nr_Conta.NM_Alias = "a";
            this.Nr_Conta.NM_Campo = "Nr_Conta";
            this.Nr_Conta.NM_CampoBusca = "Nr_Conta";
            this.Nr_Conta.NM_Param = "@P_NR_CONTA";
            this.Nr_Conta.QTD_Zero = 0;
            this.Nr_Conta.Size = new System.Drawing.Size(110, 20);
            this.Nr_Conta.ST_AutoInc = false;
            this.Nr_Conta.ST_DisableAuto = false;
            this.Nr_Conta.ST_Float = false;
            this.Nr_Conta.ST_Gravar = true;
            this.Nr_Conta.ST_Int = false;
            this.Nr_Conta.ST_LimpaCampo = true;
            this.Nr_Conta.ST_NotNull = true;
            this.Nr_Conta.ST_PrimaryKey = false;
            this.Nr_Conta.TabIndex = 3;
            this.Nr_Conta.TextOld = null;
            // 
            // CD_Banco
            // 
            this.CD_Banco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Banco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Banco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDados, "CD_Banco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Banco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Banco.Location = new System.Drawing.Point(88, 10);
            this.CD_Banco.Name = "CD_Banco";
            this.CD_Banco.NM_Alias = "a";
            this.CD_Banco.NM_Campo = "CD_Banco";
            this.CD_Banco.NM_CampoBusca = "CD_Banco";
            this.CD_Banco.NM_Param = "@P_CD_BANCO";
            this.CD_Banco.QTD_Zero = 0;
            this.CD_Banco.Size = new System.Drawing.Size(79, 20);
            this.CD_Banco.ST_AutoInc = false;
            this.CD_Banco.ST_DisableAuto = false;
            this.CD_Banco.ST_Float = false;
            this.CD_Banco.ST_Gravar = true;
            this.CD_Banco.ST_Int = false;
            this.CD_Banco.ST_LimpaCampo = true;
            this.CD_Banco.ST_NotNull = true;
            this.CD_Banco.ST_PrimaryKey = false;
            this.CD_Banco.TabIndex = 0;
            this.CD_Banco.TextOld = null;
            this.CD_Banco.Leave += new System.EventHandler(this.CD_Banco_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(20, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Favorecido:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nm_favorecido
            // 
            this.nm_favorecido.BackColor = System.Drawing.SystemColors.Window;
            this.nm_favorecido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_favorecido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_favorecido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDados, "NM_Favorecido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_favorecido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_favorecido.Location = new System.Drawing.Point(89, 59);
            this.nm_favorecido.Name = "nm_favorecido";
            this.nm_favorecido.NM_Alias = "a";
            this.nm_favorecido.NM_Campo = "Nr_Agencia";
            this.nm_favorecido.NM_CampoBusca = "Nr_Agencia";
            this.nm_favorecido.NM_Param = "@P_NR_AGENCIA";
            this.nm_favorecido.QTD_Zero = 0;
            this.nm_favorecido.Size = new System.Drawing.Size(428, 20);
            this.nm_favorecido.ST_AutoInc = false;
            this.nm_favorecido.ST_DisableAuto = false;
            this.nm_favorecido.ST_Float = false;
            this.nm_favorecido.ST_Gravar = true;
            this.nm_favorecido.ST_Int = false;
            this.nm_favorecido.ST_LimpaCampo = true;
            this.nm_favorecido.ST_NotNull = true;
            this.nm_favorecido.ST_PrimaryKey = false;
            this.nm_favorecido.TabIndex = 5;
            this.nm_favorecido.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(21, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "CPF/CNPJ:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // doc_favorecido
            // 
            this.doc_favorecido.BackColor = System.Drawing.SystemColors.Window;
            this.doc_favorecido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doc_favorecido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.doc_favorecido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDados, "DOC_Favorecido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.doc_favorecido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.doc_favorecido.Location = new System.Drawing.Point(89, 85);
            this.doc_favorecido.Name = "doc_favorecido";
            this.doc_favorecido.NM_Alias = "a";
            this.doc_favorecido.NM_Campo = "Nr_Agencia";
            this.doc_favorecido.NM_CampoBusca = "Nr_Agencia";
            this.doc_favorecido.NM_Param = "@P_NR_AGENCIA";
            this.doc_favorecido.QTD_Zero = 0;
            this.doc_favorecido.Size = new System.Drawing.Size(141, 20);
            this.doc_favorecido.ST_AutoInc = false;
            this.doc_favorecido.ST_DisableAuto = false;
            this.doc_favorecido.ST_Float = false;
            this.doc_favorecido.ST_Gravar = true;
            this.doc_favorecido.ST_Int = false;
            this.doc_favorecido.ST_LimpaCampo = true;
            this.doc_favorecido.ST_NotNull = true;
            this.doc_favorecido.ST_PrimaryKey = false;
            this.doc_favorecido.TabIndex = 6;
            this.doc_favorecido.TextOld = null;
            // 
            // TFDadosBanc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 157);
            this.Controls.Add(this.pnl_Dados_Bancarios);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDadosBanc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dados Bancarios";
            this.Load += new System.EventHandler(this.TFDadosBanc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDadosBanc_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pnl_Dados_Bancarios.ResumeLayout(false);
            this.pnl_Dados_Bancarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pnl_Dados_Bancarios;
        private Componentes.EditDefault Ds_Banco;
        private System.Windows.Forms.Button BB_Banco;
        private System.Windows.Forms.Label LB_Nr_Agencia;
        private System.Windows.Forms.Label LB_Nr_Conta;
        private System.Windows.Forms.Label LB_CD_Banco;
        private Componentes.EditDefault Nr_Agencia;
        private Componentes.EditDefault Nr_Conta;
        private Componentes.EditDefault CD_Banco;
        private System.Windows.Forms.BindingSource bsDados;
        private Componentes.ComboBoxDefault cbTpConta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault doc_favorecido;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nm_favorecido;
    }
}