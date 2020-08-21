namespace PostoCombustivel
{
    partial class TFEncerranteManual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFEncerranteManual));
            this.pDados = new Componentes.PanelDados(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_processarDiferenca = new System.Windows.Forms.Button();
            this.volumediferenca = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.bb_calcfechamento = new System.Windows.Forms.Button();
            this.bb_calcabertura = new System.Windows.Forms.Button();
            this.bb_fechamento = new System.Windows.Forms.Button();
            this.bb_abertura = new System.Windows.Forms.Button();
            this.encerrantefechamento = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.volumevendido = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.encerranteabertura = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dt_encerrante = new Componentes.EditData(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_bico = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.id_bico = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumediferenca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encerrantefechamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumevendido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encerranteabertura)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.panelDados1);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.dt_encerrante);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_bico);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.id_bico);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 0);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(610, 193);
            this.pDados.TabIndex = 14;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.bb_processarDiferenca);
            this.panelDados1.Controls.Add(this.volumediferenca);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Controls.Add(this.bb_calcfechamento);
            this.panelDados1.Controls.Add(this.bb_calcabertura);
            this.panelDados1.Controls.Add(this.bb_fechamento);
            this.panelDados1.Controls.Add(this.bb_abertura);
            this.panelDados1.Controls.Add(this.encerrantefechamento);
            this.panelDados1.Controls.Add(this.label6);
            this.panelDados1.Controls.Add(this.volumevendido);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.encerranteabertura);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Location = new System.Drawing.Point(76, 58);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(550, 141);
            this.panelDados1.TabIndex = 48;
            // 
            // bb_processarDiferenca
            // 
            this.bb_processarDiferenca.Location = new System.Drawing.Point(375, 100);
            this.bb_processarDiferenca.Name = "bb_processarDiferenca";
            this.bb_processarDiferenca.Size = new System.Drawing.Size(151, 26);
            this.bb_processarDiferenca.TabIndex = 60;
            this.bb_processarDiferenca.Text = "Processar Diferença";
            this.bb_processarDiferenca.UseVisualStyleBackColor = true;
            this.bb_processarDiferenca.Click += new System.EventHandler(this.bb_processarDiferenca_Click);
            // 
            // volumediferenca
            // 
            this.volumediferenca.DecimalPlaces = 3;
            this.volumediferenca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumediferenca.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.volumediferenca.Location = new System.Drawing.Point(217, 100);
            this.volumediferenca.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.volumediferenca.Minimum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            -2147483648});
            this.volumediferenca.Name = "volumediferenca";
            this.volumediferenca.NM_Alias = "";
            this.volumediferenca.NM_Campo = "";
            this.volumediferenca.NM_Param = "";
            this.volumediferenca.Operador = "";
            this.volumediferenca.ReadOnly = true;
            this.volumediferenca.Size = new System.Drawing.Size(157, 26);
            this.volumediferenca.ST_AutoInc = false;
            this.volumediferenca.ST_DisableAuto = false;
            this.volumediferenca.ST_Gravar = false;
            this.volumediferenca.ST_LimparCampo = true;
            this.volumediferenca.ST_NotNull = false;
            this.volumediferenca.ST_PrimaryKey = false;
            this.volumediferenca.TabIndex = 59;
            this.volumediferenca.TabStop = false;
            this.volumediferenca.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(54, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 20);
            this.label7.TabIndex = 58;
            this.label7.Text = "Diferença Volume:";
            // 
            // bb_calcfechamento
            // 
            this.bb_calcfechamento.Image = ((System.Drawing.Image)(resources.GetObject("bb_calcfechamento.Image")));
            this.bb_calcfechamento.Location = new System.Drawing.Point(375, 68);
            this.bb_calcfechamento.Name = "bb_calcfechamento";
            this.bb_calcfechamento.Size = new System.Drawing.Size(35, 26);
            this.bb_calcfechamento.TabIndex = 57;
            this.bb_calcfechamento.UseVisualStyleBackColor = true;
            this.bb_calcfechamento.Click += new System.EventHandler(this.bb_calcfechamento_Click);
            // 
            // bb_calcabertura
            // 
            this.bb_calcabertura.Image = ((System.Drawing.Image)(resources.GetObject("bb_calcabertura.Image")));
            this.bb_calcabertura.Location = new System.Drawing.Point(375, 4);
            this.bb_calcabertura.Name = "bb_calcabertura";
            this.bb_calcabertura.Size = new System.Drawing.Size(35, 26);
            this.bb_calcabertura.TabIndex = 56;
            this.bb_calcabertura.UseVisualStyleBackColor = true;
            this.bb_calcabertura.Click += new System.EventHandler(this.bb_calcabertura_Click);
            // 
            // bb_fechamento
            // 
            this.bb_fechamento.Location = new System.Drawing.Point(416, 68);
            this.bb_fechamento.Name = "bb_fechamento";
            this.bb_fechamento.Size = new System.Drawing.Size(110, 26);
            this.bb_fechamento.TabIndex = 55;
            this.bb_fechamento.Text = "Gravar Fechamento";
            this.bb_fechamento.UseVisualStyleBackColor = true;
            this.bb_fechamento.Click += new System.EventHandler(this.bb_fechamento_Click);
            // 
            // bb_abertura
            // 
            this.bb_abertura.Location = new System.Drawing.Point(416, 4);
            this.bb_abertura.Name = "bb_abertura";
            this.bb_abertura.Size = new System.Drawing.Size(110, 26);
            this.bb_abertura.TabIndex = 54;
            this.bb_abertura.Text = "Gravar Abertura";
            this.bb_abertura.UseVisualStyleBackColor = true;
            this.bb_abertura.Click += new System.EventHandler(this.bb_abertura_Click);
            // 
            // encerrantefechamento
            // 
            this.encerrantefechamento.DecimalPlaces = 3;
            this.encerrantefechamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encerrantefechamento.Location = new System.Drawing.Point(217, 68);
            this.encerrantefechamento.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.encerrantefechamento.Name = "encerrantefechamento";
            this.encerrantefechamento.NM_Alias = "";
            this.encerrantefechamento.NM_Campo = "";
            this.encerrantefechamento.NM_Param = "";
            this.encerrantefechamento.Operador = "";
            this.encerrantefechamento.Size = new System.Drawing.Size(157, 26);
            this.encerrantefechamento.ST_AutoInc = false;
            this.encerrantefechamento.ST_DisableAuto = false;
            this.encerrantefechamento.ST_Gravar = false;
            this.encerrantefechamento.ST_LimparCampo = true;
            this.encerrantefechamento.ST_NotNull = false;
            this.encerrantefechamento.ST_PrimaryKey = false;
            this.encerrantefechamento.TabIndex = 53;
            this.encerrantefechamento.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 20);
            this.label6.TabIndex = 52;
            this.label6.Text = "Encerrante Fechamento:";
            // 
            // volumevendido
            // 
            this.volumevendido.DecimalPlaces = 3;
            this.volumevendido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumevendido.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.volumevendido.Location = new System.Drawing.Point(217, 36);
            this.volumevendido.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.volumevendido.Name = "volumevendido";
            this.volumevendido.NM_Alias = "";
            this.volumevendido.NM_Campo = "";
            this.volumevendido.NM_Param = "";
            this.volumevendido.Operador = "";
            this.volumevendido.ReadOnly = true;
            this.volumevendido.Size = new System.Drawing.Size(157, 26);
            this.volumevendido.ST_AutoInc = false;
            this.volumevendido.ST_DisableAuto = false;
            this.volumevendido.ST_Gravar = false;
            this.volumevendido.ST_LimparCampo = true;
            this.volumevendido.ST_NotNull = false;
            this.volumevendido.ST_PrimaryKey = false;
            this.volumevendido.TabIndex = 51;
            this.volumevendido.TabStop = false;
            this.volumevendido.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Volume Vendido:";
            // 
            // encerranteabertura
            // 
            this.encerranteabertura.DecimalPlaces = 3;
            this.encerranteabertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encerranteabertura.Location = new System.Drawing.Point(217, 4);
            this.encerranteabertura.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.encerranteabertura.Name = "encerranteabertura";
            this.encerranteabertura.NM_Alias = "";
            this.encerranteabertura.NM_Campo = "";
            this.encerranteabertura.NM_Param = "";
            this.encerranteabertura.Operador = "";
            this.encerranteabertura.Size = new System.Drawing.Size(157, 26);
            this.encerranteabertura.ST_AutoInc = false;
            this.encerranteabertura.ST_DisableAuto = false;
            this.encerranteabertura.ST_Gravar = false;
            this.encerranteabertura.ST_LimparCampo = true;
            this.encerranteabertura.ST_NotNull = false;
            this.encerranteabertura.ST_PrimaryKey = false;
            this.encerranteabertura.TabIndex = 49;
            this.encerranteabertura.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "Encerrante Abertura:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Data:";
            // 
            // dt_encerrante
            // 
            this.dt_encerrante.Location = new System.Drawing.Point(76, 32);
            this.dt_encerrante.Mask = "00/00/0000";
            this.dt_encerrante.Name = "dt_encerrante";
            this.dt_encerrante.NM_Alias = "";
            this.dt_encerrante.NM_Campo = "";
            this.dt_encerrante.NM_CampoBusca = "";
            this.dt_encerrante.NM_Param = "";
            this.dt_encerrante.Operador = "";
            this.dt_encerrante.Size = new System.Drawing.Size(75, 20);
            this.dt_encerrante.ST_Gravar = false;
            this.dt_encerrante.ST_LimpaCampo = true;
            this.dt_encerrante.ST_NotNull = false;
            this.dt_encerrante.ST_PrimaryKey = false;
            this.dt_encerrante.TabIndex = 46;
            this.dt_encerrante.Leave += new System.EventHandler(this.dt_encerrante_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(187, 6);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(295, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 44;
            // 
            // bb_bico
            // 
            this.bb_bico.BackColor = System.Drawing.SystemColors.Control;
            this.bb_bico.Image = ((System.Drawing.Image)(resources.GetObject("bb_bico.Image")));
            this.bb_bico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_bico.Location = new System.Drawing.Point(576, 6);
            this.bb_bico.Name = "bb_bico";
            this.bb_bico.Size = new System.Drawing.Size(28, 19);
            this.bb_bico.TabIndex = 42;
            this.bb_bico.UseVisualStyleBackColor = false;
            this.bb_bico.Click += new System.EventHandler(this.bb_bico_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(488, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Bico:";
            // 
            // id_bico
            // 
            this.id_bico.BackColor = System.Drawing.SystemColors.Window;
            this.id_bico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_bico.Location = new System.Drawing.Point(530, 6);
            this.id_bico.Name = "id_bico";
            this.id_bico.NM_Alias = "";
            this.id_bico.NM_Campo = "id_bico";
            this.id_bico.NM_CampoBusca = "id_bico";
            this.id_bico.NM_Param = "@P_ID_BOMBA";
            this.id_bico.QTD_Zero = 0;
            this.id_bico.Size = new System.Drawing.Size(44, 20);
            this.id_bico.ST_AutoInc = false;
            this.id_bico.ST_DisableAuto = false;
            this.id_bico.ST_Float = false;
            this.id_bico.ST_Gravar = false;
            this.id_bico.ST_Int = true;
            this.id_bico.ST_LimpaCampo = true;
            this.id_bico.ST_NotNull = false;
            this.id_bico.ST_PrimaryKey = false;
            this.id_bico.TabIndex = 41;
            this.id_bico.Leave += new System.EventHandler(this.id_bico_Leave);
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(153, 6);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 26;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.Color.White;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(76, 6);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(75, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = false;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 25;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // TFEncerranteManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 193);
            this.Controls.Add(this.pDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFEncerranteManual";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encerrante Manual Bico";
            this.Load += new System.EventHandler(this.TFEncerranteManual_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumediferenca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encerrantefechamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumevendido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encerranteabertura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Button bb_bico;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault id_bico;
        private System.Windows.Forms.Label label2;
        private Componentes.EditData dt_encerrante;
        private Componentes.EditDefault nm_empresa;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditFloat encerrantefechamento;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat volumevendido;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat encerranteabertura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_fechamento;
        private System.Windows.Forms.Button bb_abertura;
        private System.Windows.Forms.Button bb_processarDiferenca;
        private Componentes.EditFloat volumediferenca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bb_calcfechamento;
        private System.Windows.Forms.Button bb_calcabertura;
    }
}