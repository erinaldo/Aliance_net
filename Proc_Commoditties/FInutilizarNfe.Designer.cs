namespace Proc_Commoditties
{
    partial class TFInutilizarNfe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFInutilizarNfe));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.pDetalhe = new Componentes.PanelDados(this.components);
            this.lblCaracteres = new System.Windows.Forms.Label();
            this.justificativa = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.nfe_final = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.ano = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nfe_inicial = new Componentes.EditFloat(this.components);
            this.cd_modelo = new Componentes.EditDefault(this.components);
            this.ds_serienf = new Componentes.EditDefault(this.components);
            this.nr_serie = new Componentes.EditDefault(this.components);
            this.bb_serie = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.label43 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pDetalhe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nfe_final)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nfe_inicial)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(554, 43);
            this.barraMenu.TabIndex = 6;
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
            this.bb_inutilizar.Text = "(F4)\r\nInutilizar";
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.pDetalhe);
            this.pDados.Controls.Add(this.cd_modelo);
            this.pDados.Controls.Add(this.ds_serienf);
            this.pDados.Controls.Add(this.nr_serie);
            this.pDados.Controls.Add(this.bb_serie);
            this.pDados.Controls.Add(this.label55);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.label43);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(554, 260);
            this.pDados.TabIndex = 7;
            // 
            // pDetalhe
            // 
            this.pDetalhe.BackColor = System.Drawing.SystemColors.Control;
            this.pDetalhe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDetalhe.Controls.Add(this.lblCaracteres);
            this.pDetalhe.Controls.Add(this.justificativa);
            this.pDetalhe.Controls.Add(this.label6);
            this.pDetalhe.Controls.Add(this.nfe_final);
            this.pDetalhe.Controls.Add(this.label5);
            this.pDetalhe.Controls.Add(this.ano);
            this.pDetalhe.Controls.Add(this.label3);
            this.pDetalhe.Controls.Add(this.label4);
            this.pDetalhe.Controls.Add(this.nfe_inicial);
            this.pDetalhe.Location = new System.Drawing.Point(67, 55);
            this.pDetalhe.Name = "pDetalhe";
            this.pDetalhe.NM_ProcDeletar = "";
            this.pDetalhe.NM_ProcGravar = "";
            this.pDetalhe.Size = new System.Drawing.Size(480, 198);
            this.pDetalhe.TabIndex = 4;
            // 
            // lblCaracteres
            // 
            this.lblCaracteres.AutoSize = true;
            this.lblCaracteres.Location = new System.Drawing.Point(3, 180);
            this.lblCaracteres.Name = "lblCaracteres";
            this.lblCaracteres.Size = new System.Drawing.Size(88, 13);
            this.lblCaracteres.TabIndex = 25;
            this.lblCaracteres.Text = "Total Caracteres:";
            // 
            // justificativa
            // 
            this.justificativa.BackColor = System.Drawing.SystemColors.Window;
            this.justificativa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.justificativa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.justificativa.Location = new System.Drawing.Point(6, 64);
            this.justificativa.Multiline = true;
            this.justificativa.Name = "justificativa";
            this.justificativa.NM_Alias = "";
            this.justificativa.NM_Campo = "";
            this.justificativa.NM_CampoBusca = "";
            this.justificativa.NM_Param = "";
            this.justificativa.QTD_Zero = 0;
            this.justificativa.Size = new System.Drawing.Size(469, 113);
            this.justificativa.ST_AutoInc = false;
            this.justificativa.ST_DisableAuto = false;
            this.justificativa.ST_Float = false;
            this.justificativa.ST_Gravar = false;
            this.justificativa.ST_Int = false;
            this.justificativa.ST_LimpaCampo = true;
            this.justificativa.ST_NotNull = true;
            this.justificativa.ST_PrimaryKey = false;
            this.justificativa.TabIndex = 3;
            this.justificativa.TextOld = null;
            this.justificativa.TextChanged += new System.EventHandler(this.justificativa_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Justificativa (Minimo 15 caracteres):";
            // 
            // nfe_final
            // 
            this.nfe_final.Location = new System.Drawing.Point(234, 19);
            this.nfe_final.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.nfe_final.Name = "nfe_final";
            this.nfe_final.NM_Alias = "";
            this.nfe_final.NM_Campo = "";
            this.nfe_final.NM_Param = "";
            this.nfe_final.Operador = "";
            this.nfe_final.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nfe_final.Size = new System.Drawing.Size(120, 20);
            this.nfe_final.ST_AutoInc = false;
            this.nfe_final.ST_DisableAuto = false;
            this.nfe_final.ST_Gravar = false;
            this.nfe_final.ST_LimparCampo = true;
            this.nfe_final.ST_NotNull = true;
            this.nfe_final.ST_PrimaryKey = false;
            this.nfe_final.TabIndex = 2;
            this.nfe_final.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(231, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Nº Final";
            // 
            // ano
            // 
            this.ano.CustomFormat = "yyyy";
            this.ano.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ano.Location = new System.Drawing.Point(6, 19);
            this.ano.Name = "ano";
            this.ano.ShowUpDown = true;
            this.ano.Size = new System.Drawing.Size(82, 20);
            this.ano.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Ano Inutilização";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Nº Inicial";
            // 
            // nfe_inicial
            // 
            this.nfe_inicial.Location = new System.Drawing.Point(101, 19);
            this.nfe_inicial.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.nfe_inicial.Name = "nfe_inicial";
            this.nfe_inicial.NM_Alias = "";
            this.nfe_inicial.NM_Campo = "";
            this.nfe_inicial.NM_Param = "";
            this.nfe_inicial.Operador = "";
            this.nfe_inicial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nfe_inicial.Size = new System.Drawing.Size(120, 20);
            this.nfe_inicial.ST_AutoInc = false;
            this.nfe_inicial.ST_DisableAuto = false;
            this.nfe_inicial.ST_Gravar = false;
            this.nfe_inicial.ST_LimparCampo = true;
            this.nfe_inicial.ST_NotNull = true;
            this.nfe_inicial.ST_PrimaryKey = false;
            this.nfe_inicial.TabIndex = 1;
            this.nfe_inicial.ThousandsSeparator = true;
            // 
            // cd_modelo
            // 
            this.cd_modelo.BackColor = System.Drawing.SystemColors.Window;
            this.cd_modelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_modelo.Enabled = false;
            this.cd_modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_modelo.Location = new System.Drawing.Point(496, 29);
            this.cd_modelo.Name = "cd_modelo";
            this.cd_modelo.NM_Alias = "";
            this.cd_modelo.NM_Campo = "cd_modelo";
            this.cd_modelo.NM_CampoBusca = "cd_modelo";
            this.cd_modelo.NM_Param = "@P_NM_EMPRESA";
            this.cd_modelo.QTD_Zero = 0;
            this.cd_modelo.ReadOnly = true;
            this.cd_modelo.Size = new System.Drawing.Size(51, 20);
            this.cd_modelo.ST_AutoInc = false;
            this.cd_modelo.ST_DisableAuto = false;
            this.cd_modelo.ST_Float = false;
            this.cd_modelo.ST_Gravar = false;
            this.cd_modelo.ST_Int = false;
            this.cd_modelo.ST_LimpaCampo = true;
            this.cd_modelo.ST_NotNull = false;
            this.cd_modelo.ST_PrimaryKey = false;
            this.cd_modelo.TabIndex = 16;
            this.cd_modelo.TextOld = null;
            // 
            // ds_serienf
            // 
            this.ds_serienf.BackColor = System.Drawing.SystemColors.Window;
            this.ds_serienf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_serienf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_serienf.Enabled = false;
            this.ds_serienf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_serienf.Location = new System.Drawing.Point(157, 29);
            this.ds_serienf.Name = "ds_serienf";
            this.ds_serienf.NM_Alias = "";
            this.ds_serienf.NM_Campo = "ds_serienf";
            this.ds_serienf.NM_CampoBusca = "ds_serienf";
            this.ds_serienf.NM_Param = "@P_NM_EMPRESA";
            this.ds_serienf.QTD_Zero = 0;
            this.ds_serienf.ReadOnly = true;
            this.ds_serienf.Size = new System.Drawing.Size(338, 20);
            this.ds_serienf.ST_AutoInc = false;
            this.ds_serienf.ST_DisableAuto = false;
            this.ds_serienf.ST_Float = false;
            this.ds_serienf.ST_Gravar = false;
            this.ds_serienf.ST_Int = false;
            this.ds_serienf.ST_LimpaCampo = true;
            this.ds_serienf.ST_NotNull = false;
            this.ds_serienf.ST_PrimaryKey = false;
            this.ds_serienf.TabIndex = 15;
            this.ds_serienf.TextOld = null;
            // 
            // nr_serie
            // 
            this.nr_serie.BackColor = System.Drawing.SystemColors.Window;
            this.nr_serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_serie.Location = new System.Drawing.Point(67, 29);
            this.nr_serie.Name = "nr_serie";
            this.nr_serie.NM_Alias = "";
            this.nr_serie.NM_Campo = "nr_serie";
            this.nr_serie.NM_CampoBusca = "nr_serie";
            this.nr_serie.NM_Param = "";
            this.nr_serie.QTD_Zero = 0;
            this.nr_serie.Size = new System.Drawing.Size(53, 20);
            this.nr_serie.ST_AutoInc = false;
            this.nr_serie.ST_DisableAuto = false;
            this.nr_serie.ST_Float = false;
            this.nr_serie.ST_Gravar = true;
            this.nr_serie.ST_Int = false;
            this.nr_serie.ST_LimpaCampo = true;
            this.nr_serie.ST_NotNull = true;
            this.nr_serie.ST_PrimaryKey = false;
            this.nr_serie.TabIndex = 2;
            this.nr_serie.TextOld = null;
            this.nr_serie.Leave += new System.EventHandler(this.nr_serie_Leave);
            // 
            // bb_serie
            // 
            this.bb_serie.BackColor = System.Drawing.SystemColors.Control;
            this.bb_serie.Image = ((System.Drawing.Image)(resources.GetObject("bb_serie.Image")));
            this.bb_serie.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_serie.Location = new System.Drawing.Point(121, 29);
            this.bb_serie.Name = "bb_serie";
            this.bb_serie.Size = new System.Drawing.Size(30, 20);
            this.bb_serie.TabIndex = 3;
            this.bb_serie.UseVisualStyleBackColor = false;
            this.bb_serie.Click += new System.EventHandler(this.bb_serie_Click);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(27, 32);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(34, 13);
            this.label55.TabIndex = 14;
            this.label55.Text = "Série:";
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(157, 3);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(390, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 5;
            this.NM_Empresa.TextOld = null;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label43.Location = new System.Drawing.Point(10, 6);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(51, 13);
            this.label43.TabIndex = 4;
            this.label43.Text = "Empresa:";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(67, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "CD_empresa";
            this.cd_empresa.NM_CampoBusca = "CD_empresa";
            this.cd_empresa.NM_Param = "";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(84, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            // 
            // TFInutilizarNfe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 303);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFInutilizarNfe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inutilizar Sequencia";
            this.Load += new System.EventHandler(this.TFInutilizarNfe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFInutilizarNfe_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pDetalhe.ResumeLayout(false);
            this.pDetalhe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nfe_final)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nfe_inicial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label43;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault nr_serie;
        private System.Windows.Forms.Button bb_serie;
        private System.Windows.Forms.Label label55;
        private Componentes.EditDefault ds_serienf;
        private Componentes.EditDefault cd_modelo;
        private Componentes.PanelDados pDetalhe;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat nfe_final;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat nfe_inicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker ano;
        private System.Windows.Forms.Label lblCaracteres;
        private Componentes.EditDefault justificativa;
        private System.Windows.Forms.Label label6;
    }
}