namespace PDV
{
    partial class TFClienteCupom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFClienteCupom));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.email = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.Nr_requisicao = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cpf_motorista = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.bb_motorista = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.nm_motorista = new Componentes.EditDefault(this.components);
            this.ds_portador = new Componentes.EditDefault(this.components);
            this.bb_portador = new System.Windows.Forms.Button();
            this.cd_portador = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.km = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.placa = new Componentes.EditMask(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.cpfcnpj = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.km)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(560, 43);
            this.barraMenu.TabIndex = 4;
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
            this.BB_Gravar.Size = new System.Drawing.Size(95, 40);
            this.BB_Gravar.Text = "(F4)\r\nConfirmar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.cpfcnpj);
            this.pDados.Controls.Add(this.email);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.Nr_requisicao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.cpf_motorista);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.bb_motorista);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.nm_motorista);
            this.pDados.Controls.Add(this.ds_portador);
            this.pDados.Controls.Add(this.bb_portador);
            this.pDados.Controls.Add(this.cd_portador);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.km);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.placa);
            this.pDados.Controls.Add(this.bb_clifor);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.nm_clifor);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(560, 92);
            this.pDados.TabIndex = 5;
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.SystemColors.Window;
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.email.Location = new System.Drawing.Point(261, 30);
            this.email.Name = "email";
            this.email.NM_Alias = "";
            this.email.NM_Campo = "";
            this.email.NM_CampoBusca = "";
            this.email.NM_Param = "";
            this.email.QTD_Zero = 0;
            this.email.Size = new System.Drawing.Size(294, 20);
            this.email.ST_AutoInc = false;
            this.email.ST_DisableAuto = false;
            this.email.ST_Float = false;
            this.email.ST_Gravar = false;
            this.email.ST_Int = false;
            this.email.ST_LimpaCampo = true;
            this.email.ST_NotNull = false;
            this.email.ST_PrimaryKey = false;
            this.email.TabIndex = 3;
            this.email.TextOld = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(217, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 448;
            this.label9.Text = "E-mail:";
            // 
            // Nr_requisicao
            // 
            this.Nr_requisicao.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_requisicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_requisicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_requisicao.Location = new System.Drawing.Point(340, 108);
            this.Nr_requisicao.Name = "Nr_requisicao";
            this.Nr_requisicao.NM_Alias = "";
            this.Nr_requisicao.NM_Campo = "nr_cpf";
            this.Nr_requisicao.NM_CampoBusca = "nr_cpf";
            this.Nr_requisicao.NM_Param = "@P_NR_CPF";
            this.Nr_requisicao.QTD_Zero = 0;
            this.Nr_requisicao.Size = new System.Drawing.Size(165, 20);
            this.Nr_requisicao.ST_AutoInc = false;
            this.Nr_requisicao.ST_DisableAuto = false;
            this.Nr_requisicao.ST_Float = false;
            this.Nr_requisicao.ST_Gravar = false;
            this.Nr_requisicao.ST_Int = false;
            this.Nr_requisicao.ST_LimpaCampo = true;
            this.Nr_requisicao.ST_NotNull = false;
            this.Nr_requisicao.ST_PrimaryKey = false;
            this.Nr_requisicao.TabIndex = 447;
            this.Nr_requisicao.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 446;
            this.label3.Text = "Nº  Req.:";
            // 
            // cpf_motorista
            // 
            this.cpf_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.cpf_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpf_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cpf_motorista.Location = new System.Drawing.Point(71, 160);
            this.cpf_motorista.Name = "cpf_motorista";
            this.cpf_motorista.NM_Alias = "";
            this.cpf_motorista.NM_Campo = "nr_cpf";
            this.cpf_motorista.NM_CampoBusca = "nr_cpf";
            this.cpf_motorista.NM_Param = "@P_NR_CPF";
            this.cpf_motorista.QTD_Zero = 0;
            this.cpf_motorista.Size = new System.Drawing.Size(165, 20);
            this.cpf_motorista.ST_AutoInc = false;
            this.cpf_motorista.ST_DisableAuto = false;
            this.cpf_motorista.ST_Float = false;
            this.cpf_motorista.ST_Gravar = false;
            this.cpf_motorista.ST_Int = false;
            this.cpf_motorista.ST_LimpaCampo = true;
            this.cpf_motorista.ST_NotNull = false;
            this.cpf_motorista.ST_PrimaryKey = false;
            this.cpf_motorista.TabIndex = 445;
            this.cpf_motorista.TextOld = null;
            this.cpf_motorista.TextChanged += new System.EventHandler(this.cpf_motorista_TextChanged);
            this.cpf_motorista.Leave += new System.EventHandler(this.cpf_motorista_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 444;
            this.label8.Text = "CPF Mot.:";
            // 
            // bb_motorista
            // 
            this.bb_motorista.Image = ((System.Drawing.Image)(resources.GetObject("bb_motorista.Image")));
            this.bb_motorista.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_motorista.Location = new System.Drawing.Point(477, 134);
            this.bb_motorista.Name = "bb_motorista";
            this.bb_motorista.Size = new System.Drawing.Size(28, 20);
            this.bb_motorista.TabIndex = 9;
            this.bb_motorista.UseVisualStyleBackColor = true;
            this.bb_motorista.Click += new System.EventHandler(this.bb_motorista_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 443;
            this.label7.Text = "Motorista:";
            // 
            // nm_motorista
            // 
            this.nm_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.nm_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_motorista.Location = new System.Drawing.Point(71, 134);
            this.nm_motorista.Name = "nm_motorista";
            this.nm_motorista.NM_Alias = "";
            this.nm_motorista.NM_Campo = "nm_clifor";
            this.nm_motorista.NM_CampoBusca = "nm_clifor";
            this.nm_motorista.NM_Param = "@P_NM_CLIFOR";
            this.nm_motorista.QTD_Zero = 0;
            this.nm_motorista.Size = new System.Drawing.Size(405, 20);
            this.nm_motorista.ST_AutoInc = false;
            this.nm_motorista.ST_DisableAuto = false;
            this.nm_motorista.ST_Float = false;
            this.nm_motorista.ST_Gravar = true;
            this.nm_motorista.ST_Int = false;
            this.nm_motorista.ST_LimpaCampo = true;
            this.nm_motorista.ST_NotNull = false;
            this.nm_motorista.ST_PrimaryKey = false;
            this.nm_motorista.TabIndex = 8;
            this.nm_motorista.TextOld = null;
            // 
            // ds_portador
            // 
            this.ds_portador.BackColor = System.Drawing.SystemColors.Window;
            this.ds_portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_portador.Enabled = false;
            this.ds_portador.Location = new System.Drawing.Point(169, 56);
            this.ds_portador.Name = "ds_portador";
            this.ds_portador.NM_Alias = "";
            this.ds_portador.NM_Campo = "ds_portador";
            this.ds_portador.NM_CampoBusca = "ds_portador";
            this.ds_portador.NM_Param = "@P_DS_PORTADOR";
            this.ds_portador.QTD_Zero = 0;
            this.ds_portador.Size = new System.Drawing.Size(386, 20);
            this.ds_portador.ST_AutoInc = false;
            this.ds_portador.ST_DisableAuto = false;
            this.ds_portador.ST_Float = false;
            this.ds_portador.ST_Gravar = false;
            this.ds_portador.ST_Int = false;
            this.ds_portador.ST_LimpaCampo = true;
            this.ds_portador.ST_NotNull = false;
            this.ds_portador.ST_PrimaryKey = false;
            this.ds_portador.TabIndex = 440;
            this.ds_portador.TextOld = null;
            // 
            // bb_portador
            // 
            this.bb_portador.Image = ((System.Drawing.Image)(resources.GetObject("bb_portador.Image")));
            this.bb_portador.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_portador.Location = new System.Drawing.Point(135, 56);
            this.bb_portador.Name = "bb_portador";
            this.bb_portador.Size = new System.Drawing.Size(28, 20);
            this.bb_portador.TabIndex = 5;
            this.bb_portador.UseVisualStyleBackColor = true;
            this.bb_portador.Click += new System.EventHandler(this.bb_portador_Click);
            // 
            // cd_portador
            // 
            this.cd_portador.BackColor = System.Drawing.SystemColors.Window;
            this.cd_portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_portador.Location = new System.Drawing.Point(71, 56);
            this.cd_portador.Name = "cd_portador";
            this.cd_portador.NM_Alias = "";
            this.cd_portador.NM_Campo = "cd_portador";
            this.cd_portador.NM_CampoBusca = "cd_portador";
            this.cd_portador.NM_Param = "@P_CD_PORTADOR";
            this.cd_portador.QTD_Zero = 0;
            this.cd_portador.Size = new System.Drawing.Size(60, 20);
            this.cd_portador.ST_AutoInc = false;
            this.cd_portador.ST_DisableAuto = false;
            this.cd_portador.ST_Float = false;
            this.cd_portador.ST_Gravar = true;
            this.cd_portador.ST_Int = false;
            this.cd_portador.ST_LimpaCampo = true;
            this.cd_portador.ST_NotNull = false;
            this.cd_portador.ST_PrimaryKey = false;
            this.cd_portador.TabIndex = 4;
            this.cd_portador.TextOld = null;
            this.cd_portador.Leave += new System.EventHandler(this.cd_portador_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(11, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 437;
            this.label5.Text = "Portador:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // km
            // 
            this.km.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.km.Location = new System.Drawing.Point(169, 108);
            this.km.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.km.Name = "km";
            this.km.NM_Alias = "";
            this.km.NM_Campo = "";
            this.km.NM_Param = "";
            this.km.Operador = "";
            this.km.Size = new System.Drawing.Size(120, 20);
            this.km.ST_AutoInc = false;
            this.km.ST_DisableAuto = false;
            this.km.ST_Gravar = true;
            this.km.ST_LimparCampo = true;
            this.km.ST_NotNull = false;
            this.km.ST_PrimaryKey = false;
            this.km.TabIndex = 7;
            this.km.ThousandsSeparator = true;
            this.km.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(137, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 436;
            this.label4.Text = "KM:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(28, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 435;
            this.label6.Text = "Placa:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // placa
            // 
            this.placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placa.Location = new System.Drawing.Point(71, 108);
            this.placa.Mask = "AAA-9999";
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "";
            this.placa.NM_CampoBusca = "";
            this.placa.NM_Param = "";
            this.placa.Size = new System.Drawing.Size(60, 20);
            this.placa.ST_Gravar = true;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = false;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 6;
            this.placa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.placa_KeyPress);
            // 
            // bb_clifor
            // 
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(527, 4);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(28, 20);
            this.bb_clifor.TabIndex = 1;
            this.bb_clifor.UseVisualStyleBackColor = true;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CNPJ/CPF:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente:";
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.Location = new System.Drawing.Point(71, 4);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_NM_CLIFOR";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(450, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = true;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 0;
            this.nm_clifor.TextOld = null;
            // 
            // cpfcnpj
            // 
            this.cpfcnpj.BackColor = System.Drawing.SystemColors.Window;
            this.cpfcnpj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpfcnpj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cpfcnpj.Location = new System.Drawing.Point(71, 30);
            this.cpfcnpj.MaxLength = 18;
            this.cpfcnpj.Name = "cpfcnpj";
            this.cpfcnpj.NM_Alias = "";
            this.cpfcnpj.NM_Campo = "";
            this.cpfcnpj.NM_CampoBusca = "";
            this.cpfcnpj.NM_Param = "";
            this.cpfcnpj.QTD_Zero = 0;
            this.cpfcnpj.Size = new System.Drawing.Size(140, 20);
            this.cpfcnpj.ST_AutoInc = false;
            this.cpfcnpj.ST_DisableAuto = false;
            this.cpfcnpj.ST_Float = false;
            this.cpfcnpj.ST_Gravar = false;
            this.cpfcnpj.ST_Int = false;
            this.cpfcnpj.ST_LimpaCampo = true;
            this.cpfcnpj.ST_NotNull = false;
            this.cpfcnpj.ST_PrimaryKey = false;
            this.cpfcnpj.TabIndex = 2;
            this.cpfcnpj.TextOld = null;
            // 
            // TFClienteCupom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 135);
            this.ControlBox = false;
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFClienteCupom";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dados Cliente Cupom";
            this.Load += new System.EventHandler(this.TFClienteCupom_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFClienteCupom_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.km)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault nm_clifor;
        private System.Windows.Forms.Button bb_clifor;
        private Componentes.EditFloat km;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private Componentes.EditMask placa;
        private Componentes.EditDefault ds_portador;
        private System.Windows.Forms.Button bb_portador;
        private Componentes.EditDefault cd_portador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bb_motorista;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault nm_motorista;
        private Componentes.EditDefault cpf_motorista;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault Nr_requisicao;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault email;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault cpfcnpj;
    }
}