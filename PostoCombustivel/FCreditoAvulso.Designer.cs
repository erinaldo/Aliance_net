namespace PostoCombustivel
{
    partial class TFCreditoAvulso
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCreditoAvulso));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.VL_Adiantamento = new Componentes.EditFloat(this.components);
            this.UF = new Componentes.EditDefault(this.components);
            this.Cidade = new Componentes.EditDefault(this.components);
            this.bb_endereco = new System.Windows.Forms.Button();
            this.CD_Endereco = new Componentes.EditDefault(this.components);
            this.DS_Endereco = new Componentes.EditDefault(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Adiantamento)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(4, 57);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(56, 13);
            label4.TabIndex = 183;
            label4.Text = "Endereço:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(18, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 13);
            label1.TabIndex = 181;
            label1.Text = "Cliente:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label27.Location = new System.Drawing.Point(9, 6);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(51, 13);
            label27.TabIndex = 178;
            label27.Text = "Empresa:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label17.Location = new System.Drawing.Point(63, 77);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(98, 13);
            label17.TabIndex = 187;
            label17.Text = "Valor do Credito";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(63, 122);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 13);
            label2.TabIndex = 189;
            label2.Text = "Observação";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(568, 43);
            this.barraMenu.TabIndex = 1;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.VL_Adiantamento);
            this.pDados.Controls.Add(label17);
            this.pDados.Controls.Add(this.UF);
            this.pDados.Controls.Add(this.Cidade);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.bb_endereco);
            this.pDados.Controls.Add(this.CD_Endereco);
            this.pDados.Controls.Add(this.DS_Endereco);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.bb_clifor);
            this.pDados.Controls.Add(this.cd_clifor);
            this.pDados.Controls.Add(this.nm_clifor);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(label27);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(568, 199);
            this.pDados.TabIndex = 2;
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.Location = new System.Drawing.Point(66, 138);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(496, 55);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 5;
            this.ds_observacao.TextOld = null;
            // 
            // VL_Adiantamento
            // 
            this.VL_Adiantamento.DecimalPlaces = 2;
            this.VL_Adiantamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.VL_Adiantamento.Location = new System.Drawing.Point(66, 93);
            this.VL_Adiantamento.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.VL_Adiantamento.Name = "VL_Adiantamento";
            this.VL_Adiantamento.NM_Alias = "";
            this.VL_Adiantamento.NM_Campo = "VL_Unitario";
            this.VL_Adiantamento.NM_Param = "@P_VL_UNITARIO";
            this.VL_Adiantamento.Operador = "";
            this.VL_Adiantamento.Size = new System.Drawing.Size(151, 26);
            this.VL_Adiantamento.ST_AutoInc = false;
            this.VL_Adiantamento.ST_DisableAuto = false;
            this.VL_Adiantamento.ST_Gravar = true;
            this.VL_Adiantamento.ST_LimparCampo = true;
            this.VL_Adiantamento.ST_NotNull = true;
            this.VL_Adiantamento.ST_PrimaryKey = false;
            this.VL_Adiantamento.TabIndex = 4;
            this.VL_Adiantamento.ThousandsSeparator = true;
            // 
            // UF
            // 
            this.UF.BackColor = System.Drawing.SystemColors.Window;
            this.UF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UF.Enabled = false;
            this.UF.Location = new System.Drawing.Point(515, 54);
            this.UF.Name = "UF";
            this.UF.NM_Alias = "";
            this.UF.NM_Campo = "UF";
            this.UF.NM_CampoBusca = "UF";
            this.UF.NM_Param = "@P_UF";
            this.UF.QTD_Zero = 0;
            this.UF.Size = new System.Drawing.Size(47, 20);
            this.UF.ST_AutoInc = false;
            this.UF.ST_DisableAuto = false;
            this.UF.ST_Float = false;
            this.UF.ST_Gravar = false;
            this.UF.ST_Int = false;
            this.UF.ST_LimpaCampo = true;
            this.UF.ST_NotNull = false;
            this.UF.ST_PrimaryKey = false;
            this.UF.TabIndex = 185;
            this.UF.TextOld = null;
            // 
            // Cidade
            // 
            this.Cidade.BackColor = System.Drawing.SystemColors.Window;
            this.Cidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cidade.Enabled = false;
            this.Cidade.Location = new System.Drawing.Point(389, 54);
            this.Cidade.Name = "Cidade";
            this.Cidade.NM_Alias = "";
            this.Cidade.NM_Campo = "ds_cidade";
            this.Cidade.NM_CampoBusca = "ds_cidade";
            this.Cidade.NM_Param = "";
            this.Cidade.QTD_Zero = 0;
            this.Cidade.Size = new System.Drawing.Size(120, 20);
            this.Cidade.ST_AutoInc = false;
            this.Cidade.ST_DisableAuto = false;
            this.Cidade.ST_Float = false;
            this.Cidade.ST_Gravar = false;
            this.Cidade.ST_Int = false;
            this.Cidade.ST_LimpaCampo = true;
            this.Cidade.ST_NotNull = false;
            this.Cidade.ST_PrimaryKey = false;
            this.Cidade.TabIndex = 184;
            this.Cidade.TextOld = null;
            // 
            // bb_endereco
            // 
            this.bb_endereco.BackColor = System.Drawing.SystemColors.Control;
            this.bb_endereco.Image = ((System.Drawing.Image)(resources.GetObject("bb_endereco.Image")));
            this.bb_endereco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_endereco.Location = new System.Drawing.Point(150, 54);
            this.bb_endereco.Name = "bb_endereco";
            this.bb_endereco.Size = new System.Drawing.Size(28, 19);
            this.bb_endereco.TabIndex = 3;
            this.bb_endereco.UseVisualStyleBackColor = false;
            this.bb_endereco.Click += new System.EventHandler(this.bb_endereco_Click);
            // 
            // CD_Endereco
            // 
            this.CD_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Endereco.Location = new System.Drawing.Point(66, 54);
            this.CD_Endereco.MaxLength = 10;
            this.CD_Endereco.Name = "CD_Endereco";
            this.CD_Endereco.NM_Alias = "";
            this.CD_Endereco.NM_Campo = "cd_endereco";
            this.CD_Endereco.NM_CampoBusca = "cd_endereco";
            this.CD_Endereco.NM_Param = "";
            this.CD_Endereco.QTD_Zero = 0;
            this.CD_Endereco.Size = new System.Drawing.Size(82, 20);
            this.CD_Endereco.ST_AutoInc = false;
            this.CD_Endereco.ST_DisableAuto = false;
            this.CD_Endereco.ST_Float = false;
            this.CD_Endereco.ST_Gravar = true;
            this.CD_Endereco.ST_Int = false;
            this.CD_Endereco.ST_LimpaCampo = true;
            this.CD_Endereco.ST_NotNull = false;
            this.CD_Endereco.ST_PrimaryKey = false;
            this.CD_Endereco.TabIndex = 2;
            this.CD_Endereco.TextOld = null;
            this.CD_Endereco.Leave += new System.EventHandler(this.CD_Endereco_Leave);
            // 
            // DS_Endereco
            // 
            this.DS_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Endereco.Enabled = false;
            this.DS_Endereco.Location = new System.Drawing.Point(181, 54);
            this.DS_Endereco.Name = "DS_Endereco";
            this.DS_Endereco.NM_Alias = "";
            this.DS_Endereco.NM_Campo = "ds_endereco";
            this.DS_Endereco.NM_CampoBusca = "ds_endereco";
            this.DS_Endereco.NM_Param = "@P_NM_CLIFOR";
            this.DS_Endereco.QTD_Zero = 0;
            this.DS_Endereco.Size = new System.Drawing.Size(202, 20);
            this.DS_Endereco.ST_AutoInc = false;
            this.DS_Endereco.ST_DisableAuto = false;
            this.DS_Endereco.ST_Float = false;
            this.DS_Endereco.ST_Gravar = false;
            this.DS_Endereco.ST_Int = false;
            this.DS_Endereco.ST_LimpaCampo = true;
            this.DS_Endereco.ST_NotNull = false;
            this.DS_Endereco.ST_PrimaryKey = false;
            this.DS_Endereco.TabIndex = 182;
            this.DS_Endereco.TextOld = null;
            // 
            // bb_clifor
            // 
            this.bb_clifor.BackColor = System.Drawing.SystemColors.Control;
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(150, 29);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(28, 19);
            this.bb_clifor.TabIndex = 1;
            this.bb_clifor.UseVisualStyleBackColor = false;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.Location = new System.Drawing.Point(66, 29);
            this.cd_clifor.MaxLength = 10;
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_CLIFOR";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(82, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = false;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 0;
            this.cd_clifor.TextOld = null;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Location = new System.Drawing.Point(181, 29);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_NM_CLIFOR";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(381, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 180;
            this.nm_clifor.TextOld = null;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(150, 3);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "nm_empresa";
            this.NM_Empresa.NM_CampoBusca = "nm_empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(412, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 179;
            this.NM_Empresa.TextOld = null;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.Color.White;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(66, 3);
            this.CD_Empresa.MaxLength = 4;
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "cd_empresa";
            this.CD_Empresa.NM_CampoBusca = "cd_empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(82, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 173;
            this.CD_Empresa.TextOld = null;
            // 
            // TFCreditoAvulso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 242);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCreditoAvulso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credito Avulso";
            this.Load += new System.EventHandler(this.TFCreditoAvulso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCreditoAvulso_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Adiantamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditFloat VL_Adiantamento;
        private Componentes.EditDefault Cidade;
        private System.Windows.Forms.Button bb_endereco;
        private Componentes.EditDefault CD_Endereco;
        private Componentes.EditDefault DS_Endereco;
        private System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault cd_clifor;
        private Componentes.EditDefault nm_clifor;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditDefault UF;
        private Componentes.EditDefault ds_observacao;
    }
}