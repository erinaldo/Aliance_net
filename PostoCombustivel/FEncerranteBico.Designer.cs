namespace PostoCombustivel
{
    partial class TFEncerranteBico
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
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFEncerranteBico));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.qtd_encerrante = new Componentes.EditFloat(this.components);
            this.bsEncerrante = new System.Windows.Forms.BindingSource(this.components);
            this.tp_encerrante = new Componentes.ComboBoxDefault(this.components);
            this.dt_encerrante = new Componentes.EditData(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.ds_label = new Componentes.EditDefault(this.components);
            this.bb_bico = new System.Windows.Forms.Button();
            this.id_bico = new Componentes.EditDefault(this.components);
            this.bb_encerrante = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_encerrante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEncerrante)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(218, 42);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(82, 13);
            label7.TabIndex = 106;
            label7.Text = "Qtd. Encerrante";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(94, 42);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(83, 13);
            label6.TabIndex = 104;
            label6.Text = "Tipo Encerrante";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(3, 42);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(85, 13);
            label5.TabIndex = 102;
            label5.Text = "Data Encerrante";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(383, 3);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 13);
            label4.TabIndex = 100;
            label4.Text = "Combustivel";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(124, 3);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(48, 13);
            label3.TabIndex = 98;
            label3.Text = "Empresa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(68, 4);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 13);
            label2.TabIndex = 96;
            label2.Text = "Label Bico";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(3, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 13);
            label1.TabIndex = 94;
            label1.Text = "Bico:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(598, 43);
            this.barraMenu.TabIndex = 17;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.bb_encerrante);
            this.pDados.Controls.Add(label7);
            this.pDados.Controls.Add(this.qtd_encerrante);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.tp_encerrante);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(this.dt_encerrante);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.ds_label);
            this.pDados.Controls.Add(this.bb_bico);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.id_bico);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(598, 85);
            this.pDados.TabIndex = 18;
            // 
            // qtd_encerrante
            // 
            this.qtd_encerrante.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEncerrante, "Qtd_encerrante", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_encerrante.DecimalPlaces = 3;
            this.qtd_encerrante.Location = new System.Drawing.Point(221, 58);
            this.qtd_encerrante.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_encerrante.Name = "qtd_encerrante";
            this.qtd_encerrante.NM_Alias = "";
            this.qtd_encerrante.NM_Campo = "";
            this.qtd_encerrante.NM_Param = "";
            this.qtd_encerrante.Operador = "";
            this.qtd_encerrante.Size = new System.Drawing.Size(120, 20);
            this.qtd_encerrante.ST_AutoInc = false;
            this.qtd_encerrante.ST_DisableAuto = false;
            this.qtd_encerrante.ST_Gravar = true;
            this.qtd_encerrante.ST_LimparCampo = true;
            this.qtd_encerrante.ST_NotNull = true;
            this.qtd_encerrante.ST_PrimaryKey = false;
            this.qtd_encerrante.TabIndex = 4;
            this.qtd_encerrante.ThousandsSeparator = true;
            // 
            // bsEncerrante
            // 
            this.bsEncerrante.DataSource = typeof(CamadaDados.PostoCombustivel.TList_EncerranteBico);
            // 
            // tp_encerrante
            // 
            this.tp_encerrante.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsEncerrante, "Tp_encerrante", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_encerrante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_encerrante.FormattingEnabled = true;
            this.tp_encerrante.Location = new System.Drawing.Point(94, 58);
            this.tp_encerrante.Name = "tp_encerrante";
            this.tp_encerrante.NM_Alias = "";
            this.tp_encerrante.NM_Campo = "";
            this.tp_encerrante.NM_Param = "";
            this.tp_encerrante.Size = new System.Drawing.Size(121, 21);
            this.tp_encerrante.ST_Gravar = true;
            this.tp_encerrante.ST_LimparCampo = true;
            this.tp_encerrante.ST_NotNull = true;
            this.tp_encerrante.TabIndex = 3;
            // 
            // dt_encerrante
            // 
            this.dt_encerrante.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEncerrante, "Dt_encerrantestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_encerrante.Location = new System.Drawing.Point(6, 58);
            this.dt_encerrante.Mask = "00/00/0000";
            this.dt_encerrante.Name = "dt_encerrante";
            this.dt_encerrante.NM_Alias = "";
            this.dt_encerrante.NM_Campo = "";
            this.dt_encerrante.NM_CampoBusca = "";
            this.dt_encerrante.NM_Param = "";
            this.dt_encerrante.Operador = "";
            this.dt_encerrante.Size = new System.Drawing.Size(82, 20);
            this.dt_encerrante.ST_Gravar = true;
            this.dt_encerrante.ST_LimpaCampo = true;
            this.dt_encerrante.ST_NotNull = true;
            this.dt_encerrante.ST_PrimaryKey = false;
            this.dt_encerrante.TabIndex = 2;
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEncerrante, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(383, 19);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_NM_CLIFOR";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(210, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 99;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEncerrante, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(179, 19);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_CLIFOR";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(198, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 97;
            // 
            // ds_label
            // 
            this.ds_label.BackColor = System.Drawing.SystemColors.Window;
            this.ds_label.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_label.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEncerrante, "Labelbico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_label.Enabled = false;
            this.ds_label.Location = new System.Drawing.Point(71, 19);
            this.ds_label.Name = "ds_label";
            this.ds_label.NM_Alias = "";
            this.ds_label.NM_Campo = "ds_label";
            this.ds_label.NM_CampoBusca = "ds_label";
            this.ds_label.NM_Param = "@P_NM_CLIFOR";
            this.ds_label.QTD_Zero = 0;
            this.ds_label.Size = new System.Drawing.Size(50, 20);
            this.ds_label.ST_AutoInc = false;
            this.ds_label.ST_DisableAuto = false;
            this.ds_label.ST_Float = false;
            this.ds_label.ST_Gravar = false;
            this.ds_label.ST_Int = false;
            this.ds_label.ST_LimpaCampo = true;
            this.ds_label.ST_NotNull = false;
            this.ds_label.ST_PrimaryKey = false;
            this.ds_label.TabIndex = 95;
            // 
            // bb_bico
            // 
            this.bb_bico.BackColor = System.Drawing.SystemColors.Control;
            this.bb_bico.Image = ((System.Drawing.Image)(resources.GetObject("bb_bico.Image")));
            this.bb_bico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_bico.Location = new System.Drawing.Point(41, 19);
            this.bb_bico.Name = "bb_bico";
            this.bb_bico.Size = new System.Drawing.Size(28, 21);
            this.bb_bico.TabIndex = 1;
            this.bb_bico.UseVisualStyleBackColor = false;
            this.bb_bico.Click += new System.EventHandler(this.bb_bico_Click);
            // 
            // id_bico
            // 
            this.id_bico.BackColor = System.Drawing.Color.White;
            this.id_bico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_bico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEncerrante, "Id_bicostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_bico.Location = new System.Drawing.Point(6, 20);
            this.id_bico.Name = "id_bico";
            this.id_bico.NM_Alias = "";
            this.id_bico.NM_Campo = "id_bico";
            this.id_bico.NM_CampoBusca = "id_bico";
            this.id_bico.NM_Param = "@P_CD_EMPRESA";
            this.id_bico.QTD_Zero = 0;
            this.id_bico.Size = new System.Drawing.Size(33, 20);
            this.id_bico.ST_AutoInc = false;
            this.id_bico.ST_DisableAuto = false;
            this.id_bico.ST_Float = false;
            this.id_bico.ST_Gravar = true;
            this.id_bico.ST_Int = true;
            this.id_bico.ST_LimpaCampo = true;
            this.id_bico.ST_NotNull = true;
            this.id_bico.ST_PrimaryKey = false;
            this.id_bico.TabIndex = 0;
            this.id_bico.Leave += new System.EventHandler(this.id_bico_Leave);
            // 
            // bb_encerrante
            // 
            this.bb_encerrante.Location = new System.Drawing.Point(347, 56);
            this.bb_encerrante.Name = "bb_encerrante";
            this.bb_encerrante.Size = new System.Drawing.Size(109, 23);
            this.bb_encerrante.TabIndex = 107;
            this.bb_encerrante.Text = "Buscar Encerrante";
            this.bb_encerrante.UseVisualStyleBackColor = true;
            this.bb_encerrante.Click += new System.EventHandler(this.bb_encerrante_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEncerrante, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(127, 19);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_NM_CLIFOR";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(50, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 108;
            // 
            // TFEncerranteBico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 128);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFEncerranteBico";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encerrante Bico";
            this.Load += new System.EventHandler(this.TFEncerranteBico_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFEncerranteBico_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_encerrante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEncerrante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Button bb_bico;
        private Componentes.EditDefault id_bico;
        private Componentes.EditDefault ds_label;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.BindingSource bsEncerrante;
        private Componentes.ComboBoxDefault tp_encerrante;
        private Componentes.EditData dt_encerrante;
        private Componentes.EditFloat qtd_encerrante;
        private System.Windows.Forms.Button bb_encerrante;
        private Componentes.EditDefault cd_empresa;
    }
}