namespace Financeiro.Cadastros
{
    partial class TFPessoasAutorizadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFPessoasAutorizadas));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dt_autorizacao = new Componentes.EditData(this.components);
            this.bsPessoas = new System.Windows.Forms.BindingSource(this.components);
            this.tp_relacionamento = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.NR_CPF = new Componentes.EditMask(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nm_pessoa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPessoas)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(539, 43);
            this.barraMenu.TabIndex = 21;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.Green;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(95, 40);
            this.toolStripButton1.Text = "(F3)Capturar";
            this.toolStripButton1.ToolTipText = "Cancelar Procedimento";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.dt_autorizacao);
            this.pDados.Controls.Add(this.tp_relacionamento);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.NR_CPF);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.nm_pessoa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(539, 94);
            this.pDados.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data Autorização";
            // 
            // dt_autorizacao
            // 
            this.dt_autorizacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_autorizacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPessoas, "dt_autorizacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_autorizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dt_autorizacao.Location = new System.Drawing.Point(444, 23);
            this.dt_autorizacao.Mask = "00/00/0000";
            this.dt_autorizacao.Name = "dt_autorizacao";
            this.dt_autorizacao.NM_Alias = "";
            this.dt_autorizacao.NM_Campo = "DT_NascFirma";
            this.dt_autorizacao.NM_CampoBusca = "DT_NascFirma";
            this.dt_autorizacao.NM_Param = "@P_DT_NASCIMENTO";
            this.dt_autorizacao.Operador = "";
            this.dt_autorizacao.Size = new System.Drawing.Size(86, 20);
            this.dt_autorizacao.ST_Gravar = true;
            this.dt_autorizacao.ST_LimpaCampo = true;
            this.dt_autorizacao.ST_NotNull = false;
            this.dt_autorizacao.ST_PrimaryKey = false;
            this.dt_autorizacao.TabIndex = 1;
            // 
            // bsPessoas
            // 
            this.bsPessoas.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_PessoasAutorizadas);
            // 
            // tp_relacionamento
            // 
            this.tp_relacionamento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsPessoas, "Tp_relacionamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_relacionamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_relacionamento.FormattingEnabled = true;
            this.tp_relacionamento.Location = new System.Drawing.Point(130, 62);
            this.tp_relacionamento.Name = "tp_relacionamento";
            this.tp_relacionamento.NM_Alias = "";
            this.tp_relacionamento.NM_Campo = "";
            this.tp_relacionamento.NM_Param = "";
            this.tp_relacionamento.Size = new System.Drawing.Size(400, 21);
            this.tp_relacionamento.ST_Gravar = true;
            this.tp_relacionamento.ST_LimparCampo = true;
            this.tp_relacionamento.ST_NotNull = false;
            this.tp_relacionamento.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parentesco";
            // 
            // NR_CPF
            // 
            this.NR_CPF.BackColor = System.Drawing.Color.White;
            this.NR_CPF.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPessoas, "Nr_cpf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NR_CPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NR_CPF.Location = new System.Drawing.Point(12, 62);
            this.NR_CPF.Mask = "000\\.000\\.000-00";
            this.NR_CPF.Name = "NR_CPF";
            this.NR_CPF.NM_Alias = "a";
            this.NR_CPF.NM_Campo = "NR_CGC_CPF";
            this.NR_CPF.NM_CampoBusca = "NR_CPF";
            this.NR_CPF.NM_Param = "@P_NR_CPF";
            this.NR_CPF.Size = new System.Drawing.Size(112, 20);
            this.NR_CPF.ST_Gravar = true;
            this.NR_CPF.ST_LimpaCampo = true;
            this.NR_CPF.ST_NotNull = false;
            this.NR_CPF.ST_PrimaryKey = false;
            this.NR_CPF.TabIndex = 2;
            this.NR_CPF.Leave += new System.EventHandler(this.NR_CPF_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPF";
            // 
            // nm_pessoa
            // 
            this.nm_pessoa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_pessoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_pessoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_pessoa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPessoas, "Nm_pessoa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_pessoa.Location = new System.Drawing.Point(12, 23);
            this.nm_pessoa.Name = "nm_pessoa";
            this.nm_pessoa.NM_Alias = "";
            this.nm_pessoa.NM_Campo = "";
            this.nm_pessoa.NM_CampoBusca = "";
            this.nm_pessoa.NM_Param = "";
            this.nm_pessoa.QTD_Zero = 0;
            this.nm_pessoa.Size = new System.Drawing.Size(426, 20);
            this.nm_pessoa.ST_AutoInc = false;
            this.nm_pessoa.ST_DisableAuto = false;
            this.nm_pessoa.ST_Float = false;
            this.nm_pessoa.ST_Gravar = true;
            this.nm_pessoa.ST_Int = false;
            this.nm_pessoa.ST_LimpaCampo = true;
            this.nm_pessoa.ST_NotNull = true;
            this.nm_pessoa.ST_PrimaryKey = false;
            this.nm_pessoa.TabIndex = 0;
            this.nm_pessoa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // TFPessoasAutorizadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 137);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFPessoasAutorizadas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pessoas Autorizadas";
            this.Load += new System.EventHandler(this.TFPessoasAutorizadas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFPessoasAutorizadas_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPessoas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nm_pessoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditMask NR_CPF;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault tp_relacionamento;
        private System.Windows.Forms.BindingSource bsPessoas;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label4;
        private Componentes.EditData dt_autorizacao;
    }
}